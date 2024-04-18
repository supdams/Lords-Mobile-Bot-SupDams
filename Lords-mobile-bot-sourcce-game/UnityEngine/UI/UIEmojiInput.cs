// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.UIEmojiInput
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

#nullable disable
namespace UnityEngine.UI
{
  public class UIEmojiInput : 
    Selectable,
    IBeginDragHandler,
    IDragHandler,
    ISubmitHandler,
    IUpdateSelectedHandler,
    IPointerClickHandler,
    IEndDragHandler,
    ICanvasElement,
    IEventSystemHandler
  {
    private const float kHScrollSpeed = 0.05f;
    private const float kVScrollSpeed = 0.1f;
    private const string kEmailSpecialCharacters = "!#$%&'*+-/=?^_`{|}~";
    protected static TouchScreenKeyboard m_Keyboard;
    private static readonly char[] kSeparators = new char[3]
    {
      ' ',
      '.',
      ','
    };
    [SerializeField]
    [FormerlySerializedAs("text")]
    protected UIText m_TextComponent;
    [SerializeField]
    protected Graphic m_Placeholder;
    [SerializeField]
    private UIEmojiInput.ContentType m_ContentType;
    [FormerlySerializedAs("inputType")]
    [SerializeField]
    private UIEmojiInput.InputType m_InputType;
    [SerializeField]
    [FormerlySerializedAs("asteriskChar")]
    private char m_AsteriskChar = '*';
    [SerializeField]
    [FormerlySerializedAs("keyboardType")]
    private TouchScreenKeyboardType m_KeyboardType;
    [SerializeField]
    private UIEmojiInput.LineType m_LineType;
    [SerializeField]
    [FormerlySerializedAs("hideMobileInput")]
    private bool m_HideMobileInput;
    [SerializeField]
    [FormerlySerializedAs("validation")]
    private UIEmojiInput.CharacterValidation m_CharacterValidation;
    [SerializeField]
    [FormerlySerializedAs("characterLimit")]
    private int m_CharacterLimit;
    [FormerlySerializedAs("onSubmit")]
    [FormerlySerializedAs("m_OnSubmit")]
    [SerializeField]
    private UIEmojiInput.SubmitEvent m_EndEdit = new UIEmojiInput.SubmitEvent();
    [FormerlySerializedAs("onValueChange")]
    [SerializeField]
    private UIEmojiInput.OnChangeEvent m_OnValueChange = new UIEmojiInput.OnChangeEvent();
    [FormerlySerializedAs("onValidateInput")]
    [SerializeField]
    private UIEmojiInput.OnValidateInput m_OnValidateInput;
    [SerializeField]
    [FormerlySerializedAs("selectionColor")]
    private Color m_SelectionColor = new Color(0.65882355f, 0.807843149f, 1f, 0.7529412f);
    [SerializeField]
    [FormerlySerializedAs("mValue")]
    protected string m_Text = string.Empty;
    [SerializeField]
    [Range(0.0f, 8f)]
    private float m_CaretBlinkRate = 1.7f;
    protected int m_CaretPosition;
    protected int m_CaretSelectPosition;
    private RectTransform caretRectTrans;
    protected UIVertex[] m_CursorVerts;
    private TextGenerator m_InputTextCache;
    private CanvasRenderer m_CachedInputRenderer;
    private bool m_PreventFontCallback;
    private readonly List<UIVertex> m_Vbo = new List<UIVertex>();
    private bool m_AllowInput;
    private bool m_ShouldActivateNextUpdate;
    private bool m_UpdateDrag;
    private bool m_DragPositionOutOfBounds;
    protected bool m_CaretVisible;
    private Coroutine m_BlinkCoroutine;
    private float m_BlinkStartTime;
    protected int m_DrawStart;
    protected int m_DrawEnd;
    private Coroutine m_DragCoroutine;
    private string m_OriginalText = string.Empty;
    private bool m_WasCanceled;
    private bool m_HasDoneFocusTransition;
    private Event m_ProcessingEvent = new Event();

    protected UIEmojiInput()
    {
    }

    protected virtual void Awake()
    {
      base.Awake();
      if (!((UnityEngine.Object) this.textComponent != (UnityEngine.Object) null))
        return;
      this.textComponent.SetCheckArabic(true);
    }

    public void InitSet(bool mbOneLine, float mTextWidthMax)
    {
    }

    protected TextGenerator cachedInputTextGenerator
    {
      get
      {
        if (this.m_InputTextCache == null)
          this.m_InputTextCache = new TextGenerator();
        return this.m_InputTextCache;
      }
    }

    public bool shouldHideMobileInput
    {
      set => SetPropertyUtility.SetStruct<bool>(ref this.m_HideMobileInput, value);
      get
      {
        RuntimePlatform platform = Application.platform;
        switch (platform)
        {
          case RuntimePlatform.IPhonePlayer:
          case RuntimePlatform.Android:
            return this.m_HideMobileInput;
          default:
            if (platform != RuntimePlatform.BB10Player)
              return true;
            goto case RuntimePlatform.IPhonePlayer;
        }
      }
    }

    public void GetText(out string str, out eTextCheck textState)
    {
      if (UIEmojiInput.m_Keyboard != null && UIEmojiInput.m_Keyboard.active && !this.InPlaceEditing() && (UnityEngine.Object) EventSystem.current.currentSelectedGameObject == (UnityEngine.Object) ((Component) this).gameObject)
      {
        str = this.MaskEmoticon(UIEmojiInput.m_Keyboard.text);
        textState = !ArabicTransfer.Instance.IsArabicStr(str) ? eTextCheck.Text_NonArabic : eTextCheck.Text_Arabic;
      }
      if ((UnityEngine.Object) this.m_TextComponent != (UnityEngine.Object) null)
      {
        str = this.m_Text;
        textState = this.m_TextComponent.GetTextState();
      }
      else
      {
        str = string.Empty;
        textState = eTextCheck.Text_None;
      }
    }

    public string text
    {
      get
      {
        return UIEmojiInput.m_Keyboard != null && UIEmojiInput.m_Keyboard.active && !this.InPlaceEditing() && (UnityEngine.Object) EventSystem.current.currentSelectedGameObject == (UnityEngine.Object) ((Component) this).gameObject ? this.MaskEmoticon(UIEmojiInput.m_Keyboard.text) : this.m_Text;
      }
      set
      {
        if (this.text == value)
          return;
        this.m_Text = value;
        if (UIEmojiInput.m_Keyboard != null)
          UIEmojiInput.m_Keyboard.text = this.m_Text;
        if (this.m_CaretPosition > this.m_Text.Length)
          this.m_CaretPosition = this.m_CaretSelectPosition = this.m_Text.Length;
        this.SendOnValueChangedAndUpdateLabel();
      }
    }

    public unsafe string MaskEmoticon(string str)
    {
      DataManager instance = DataManager.Instance;
      string str1 = str;
      char* chPtr = (char*) ((IntPtr) str1 + RuntimeHelpers.OffsetToStringData);
      for (int index = 0; index < str.Length && chPtr[index] != char.MinValue; ++index)
      {
        if (char.GetUnicodeCategory(chPtr[index]) == UnicodeCategory.Surrogate)
          chPtr[index] = ' ';
      }
      str1 = (string) null;
      return str;
    }

    public bool isFocused => this.m_AllowInput;

    public float caretBlinkRate
    {
      get => this.m_CaretBlinkRate;
      set
      {
        if (!SetPropertyUtility.SetStruct<float>(ref this.m_CaretBlinkRate, value) || !this.m_AllowInput)
          return;
        this.SetCaretActive();
      }
    }

    public UIText textComponent
    {
      get => this.m_TextComponent;
      set => SetPropertyUtility.SetClass<UIText>(ref this.m_TextComponent, value);
    }

    public Graphic placeholder
    {
      get => this.m_Placeholder;
      set => SetPropertyUtility.SetClass<Graphic>(ref this.m_Placeholder, value);
    }

    public Color selectionColor
    {
      get => this.m_SelectionColor;
      set => SetPropertyUtility.SetColor(ref this.m_SelectionColor, value);
    }

    public UIEmojiInput.SubmitEvent onEndEdit
    {
      get => this.m_EndEdit;
      set => SetPropertyUtility.SetClass<UIEmojiInput.SubmitEvent>(ref this.m_EndEdit, value);
    }

    public UIEmojiInput.OnChangeEvent onValueChange
    {
      get => this.m_OnValueChange;
      set
      {
        SetPropertyUtility.SetClass<UIEmojiInput.OnChangeEvent>(ref this.m_OnValueChange, value);
      }
    }

    public UIEmojiInput.OnValidateInput onValidateInput
    {
      get => this.m_OnValidateInput;
      set
      {
        SetPropertyUtility.SetClass<UIEmojiInput.OnValidateInput>(ref this.m_OnValidateInput, value);
      }
    }

    public int characterLimit
    {
      get => this.m_CharacterLimit;
      set => SetPropertyUtility.SetStruct<int>(ref this.m_CharacterLimit, value);
    }

    public UIEmojiInput.ContentType contentType
    {
      get => this.m_ContentType;
      set
      {
        if (!SetPropertyUtility.SetStruct<UIEmojiInput.ContentType>(ref this.m_ContentType, value))
          return;
        this.EnforceContentType();
      }
    }

    public UIEmojiInput.LineType lineType
    {
      get => this.m_LineType;
      set
      {
        if (!SetPropertyUtility.SetStruct<UIEmojiInput.LineType>(ref this.m_LineType, value))
          return;
        this.SetToCustomIfContentTypeIsNot(UIEmojiInput.ContentType.Standard, UIEmojiInput.ContentType.Autocorrected);
      }
    }

    public UIEmojiInput.InputType inputType
    {
      get => this.m_InputType;
      set
      {
        if (!SetPropertyUtility.SetStruct<UIEmojiInput.InputType>(ref this.m_InputType, value))
          return;
        this.SetToCustom();
      }
    }

    public TouchScreenKeyboardType keyboardType
    {
      get => this.m_KeyboardType;
      set
      {
        if (!SetPropertyUtility.SetStruct<TouchScreenKeyboardType>(ref this.m_KeyboardType, value))
          return;
        this.SetToCustom();
      }
    }

    public UIEmojiInput.CharacterValidation characterValidation
    {
      get => this.m_CharacterValidation;
      set
      {
        if (!SetPropertyUtility.SetStruct<UIEmojiInput.CharacterValidation>(ref this.m_CharacterValidation, value))
          return;
        this.SetToCustom();
      }
    }

    public bool multiLine
    {
      get
      {
        return this.m_LineType == UIEmojiInput.LineType.MultiLineNewline || this.lineType == UIEmojiInput.LineType.MultiLineSubmit;
      }
    }

    public char asteriskChar
    {
      get => this.m_AsteriskChar;
      set => SetPropertyUtility.SetStruct<char>(ref this.m_AsteriskChar, value);
    }

    public bool wasCanceled => this.m_WasCanceled;

    protected void ClampPos(ref int pos)
    {
      if (pos < 0)
      {
        pos = 0;
      }
      else
      {
        if (pos <= this.text.Length)
          return;
        pos = this.text.Length;
      }
    }

    protected int caretPositionInternal
    {
      get => this.m_CaretPosition + Input.compositionString.Length;
      set
      {
        this.m_CaretPosition = value;
        this.ClampPos(ref this.m_CaretPosition);
      }
    }

    protected int caretSelectPositionInternal
    {
      get => this.m_CaretSelectPosition + Input.compositionString.Length;
      set
      {
        this.m_CaretSelectPosition = value;
        this.ClampPos(ref this.m_CaretSelectPosition);
      }
    }

    private bool hasSelection => this.caretPositionInternal != this.caretSelectPositionInternal;

    public int caretPosition
    {
      get => this.m_CaretSelectPosition + Input.compositionString.Length;
      set
      {
        this.selectionAnchorPosition = value;
        this.selectionFocusPosition = value;
      }
    }

    public int selectionAnchorPosition
    {
      get => this.m_CaretPosition + Input.compositionString.Length;
      set
      {
        if (Input.compositionString.Length != 0)
          return;
        this.m_CaretPosition = value;
        this.ClampPos(ref this.m_CaretPosition);
      }
    }

    public int selectionFocusPosition
    {
      get => this.m_CaretSelectPosition + Input.compositionString.Length;
      set
      {
        if (Input.compositionString.Length != 0)
          return;
        this.m_CaretSelectPosition = value;
        this.ClampPos(ref this.m_CaretSelectPosition);
      }
    }

    protected virtual void OnEnable()
    {
      base.OnEnable();
      if (this.m_Text == null)
        this.m_Text = string.Empty;
      this.m_DrawStart = 0;
      this.m_DrawEnd = this.m_Text.Length;
      if (!((UnityEngine.Object) this.m_TextComponent != (UnityEngine.Object) null))
        return;
      // ISSUE: method pointer
      ((Graphic) this.m_TextComponent).RegisterDirtyVerticesCallback(new UnityAction((object) this, __methodptr(MarkGeometryAsDirty)));
      // ISSUE: method pointer
      ((Graphic) this.m_TextComponent).RegisterDirtyVerticesCallback(new UnityAction((object) this, __methodptr(UpdateLabel)));
      this.UpdateLabel();
    }

    protected virtual void OnDisable()
    {
      this.m_BlinkCoroutine = (Coroutine) null;
      this.DeactivateInputField();
      if ((UnityEngine.Object) this.m_TextComponent != (UnityEngine.Object) null)
      {
        // ISSUE: method pointer
        ((Graphic) this.m_TextComponent).UnregisterDirtyVerticesCallback(new UnityAction((object) this, __methodptr(MarkGeometryAsDirty)));
        // ISSUE: method pointer
        ((Graphic) this.m_TextComponent).UnregisterDirtyVerticesCallback(new UnityAction((object) this, __methodptr(UpdateLabel)));
      }
      CanvasUpdateRegistry.UnRegisterCanvasElementForRebuild((ICanvasElement) this);
      if ((bool) (UnityEngine.Object) this.m_CachedInputRenderer)
        this.m_CachedInputRenderer.SetVertices((UIVertex[]) null, 0);
      base.OnDisable();
    }

    [DebuggerHidden]
    private IEnumerator CaretBlink()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new UIEmojiInput.\u003CCaretBlink\u003Ec__IteratorD()
      {
        \u003C\u003Ef__this = this
      };
    }

    private void SetCaretVisible()
    {
      if (!this.m_AllowInput)
        return;
      this.m_CaretVisible = true;
      this.m_BlinkStartTime = Time.unscaledTime;
      this.SetCaretActive();
    }

    private void SetCaretActive()
    {
      if (!this.m_AllowInput)
        return;
      if ((double) this.m_CaretBlinkRate > 0.0)
      {
        if (this.m_BlinkCoroutine != null)
          return;
        this.m_BlinkCoroutine = ((MonoBehaviour) this).StartCoroutine(this.CaretBlink());
      }
      else
        this.m_CaretVisible = true;
    }

    protected void OnFocus() => this.SelectAll();

    protected void SelectAll()
    {
      this.caretPositionInternal = this.text.Length;
      this.caretSelectPositionInternal = 0;
    }

    public void MoveTextEnd(bool shift)
    {
      int length = this.text.Length;
      if (shift)
      {
        this.caretSelectPositionInternal = length;
      }
      else
      {
        this.caretPositionInternal = length;
        this.caretSelectPositionInternal = this.caretPositionInternal;
      }
      this.UpdateLabel();
    }

    public void MoveTextStart(bool shift)
    {
      int num = 0;
      if (shift)
      {
        this.caretSelectPositionInternal = num;
      }
      else
      {
        this.caretPositionInternal = num;
        this.caretSelectPositionInternal = this.caretPositionInternal;
      }
      this.UpdateLabel();
    }

    private static string clipboard
    {
      get
      {
        TextEditor textEditor = new TextEditor();
        textEditor.Paste();
        return textEditor.content.text;
      }
      set
      {
        TextEditor textEditor = new TextEditor();
        textEditor.content = new GUIContent(value);
        textEditor.OnFocus();
        textEditor.Copy();
      }
    }

    private bool InPlaceEditing() => !TouchScreenKeyboard.isSupported;

    protected virtual void LateUpdate()
    {
      if (this.m_ShouldActivateNextUpdate)
      {
        if (!this.isFocused)
        {
          this.ActivateInputFieldInternal();
          this.m_ShouldActivateNextUpdate = false;
          return;
        }
        this.m_ShouldActivateNextUpdate = false;
      }
      if (this.InPlaceEditing() || !this.isFocused)
        return;
      this.AssignPositioningIfNeeded();
      if (UIEmojiInput.m_Keyboard == null || !UIEmojiInput.m_Keyboard.active)
      {
        if (UIEmojiInput.m_Keyboard != null && UIEmojiInput.m_Keyboard.wasCanceled)
          this.m_WasCanceled = true;
        this.OnDeselect((BaseEventData) null);
      }
      else
      {
        string str = this.MaskEmoticon(UIEmojiInput.m_Keyboard.text);
        if (this.m_Text != str)
        {
          this.m_Text = string.Empty;
          for (int index = 0; index < str.Length; ++index)
          {
            char ch = str[index];
            switch (ch)
            {
              case '\u0003':
              case '\r':
                ch = '\n';
                break;
            }
            if (this.onValidateInput != null)
              ch = this.onValidateInput(this.m_Text, this.m_Text.Length, ch);
            else if (this.characterValidation != UIEmojiInput.CharacterValidation.None)
              ch = this.Validate(this.m_Text, this.m_Text.Length, ch);
            if (this.lineType == UIEmojiInput.LineType.MultiLineSubmit && ch == '\n')
            {
              UIEmojiInput.m_Keyboard.text = this.m_Text;
              this.OnDeselect((BaseEventData) null);
              return;
            }
            if (ch != char.MinValue)
              this.m_Text += (string) (object) ch;
          }
          if (this.characterLimit > 0 && this.m_Text.Length > this.characterLimit)
            this.m_Text = this.m_Text.Substring(0, this.characterLimit);
          int length = this.m_Text.Length;
          this.caretSelectPositionInternal = length;
          this.caretPositionInternal = length;
          if (this.m_Text != str)
            UIEmojiInput.m_Keyboard.text = this.m_Text;
          this.SendOnValueChangedAndUpdateLabel();
        }
        if (!UIEmojiInput.m_Keyboard.done)
          return;
        if (UIEmojiInput.m_Keyboard.wasCanceled)
          this.m_WasCanceled = true;
        this.OnDeselect((BaseEventData) null);
      }
    }

    public Vector2 ScreenToLocal(Vector2 screen)
    {
      Canvas canvas = ((Graphic) this.m_TextComponent).canvas;
      if ((UnityEngine.Object) canvas == (UnityEngine.Object) null)
        return screen;
      Vector3 vector3 = Vector3.zero;
      if (canvas.renderMode == null)
        vector3 = ((Component) this.m_TextComponent).transform.InverseTransformPoint((Vector3) screen);
      else if ((UnityEngine.Object) canvas.worldCamera != (UnityEngine.Object) null)
      {
        Ray ray = canvas.worldCamera.ScreenPointToRay((Vector3) screen);
        float enter;
        new Plane(((Component) this.m_TextComponent).transform.forward, ((Component) this.m_TextComponent).transform.position).Raycast(ray, out enter);
        vector3 = ((Component) this.m_TextComponent).transform.InverseTransformPoint(ray.GetPoint(enter));
      }
      return new Vector2(vector3.x, vector3.y);
    }

    private int GetUnclampedCharacterLineFromPosition(Vector2 pos, TextGenerator generator)
    {
      if (!this.multiLine)
        return 0;
      float yMax = ((Graphic) this.m_TextComponent).rectTransform.rect.yMax;
      if ((double) pos.y > (double) yMax)
        return -1;
      for (int index = 0; index < generator.lineCount; ++index)
      {
        float num = (float) generator.lines[index].height / this.m_TextComponent.pixelsPerUnit;
        if ((double) pos.y <= (double) yMax && (double) pos.y > (double) yMax - (double) num)
          return index;
        yMax -= num;
      }
      return generator.lineCount;
    }

    protected int GetCharacterIndexFromPosition(Vector2 pos)
    {
      TextGenerator cachedTextGenerator = this.m_TextComponent.cachedTextGenerator;
      if (cachedTextGenerator.lineCount == 0)
        return 0;
      int lineFromPosition = this.GetUnclampedCharacterLineFromPosition(pos, cachedTextGenerator);
      if (lineFromPosition < 0)
        return 0;
      if (lineFromPosition >= cachedTextGenerator.lineCount)
        return cachedTextGenerator.characterCountVisible;
      int startCharIdx = cachedTextGenerator.lines[lineFromPosition].startCharIdx;
      int lineEndPosition = UIEmojiInput.GetLineEndPosition(cachedTextGenerator, lineFromPosition);
      for (int index = startCharIdx; index < lineEndPosition && index < cachedTextGenerator.characterCountVisible; ++index)
      {
        UICharInfo character = cachedTextGenerator.characters[index];
        Vector2 vector2 = character.cursorPos / this.m_TextComponent.pixelsPerUnit;
        if ((double) (pos.x - vector2.x) < (double) (vector2.x + character.charWidth / this.m_TextComponent.pixelsPerUnit - pos.x))
          return index;
      }
      return lineEndPosition;
    }

    private bool MayDrag(PointerEventData eventData)
    {
      return ((UIBehaviour) this).IsActive() && this.IsInteractable() && eventData.button == null && (UnityEngine.Object) this.m_TextComponent != (UnityEngine.Object) null && UIEmojiInput.m_Keyboard == null;
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
      if (!this.MayDrag(eventData))
        return;
      this.m_UpdateDrag = true;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
      if (!this.MayDrag(eventData))
        return;
      Vector2 pos;
      RectTransformUtility.ScreenPointToLocalPointInRectangle(((Graphic) this.textComponent).rectTransform, eventData.position, eventData.pressEventCamera, ref pos);
      this.caretSelectPositionInternal = this.GetCharacterIndexFromPosition(pos) + this.m_DrawStart;
      this.MarkGeometryAsDirty();
      this.m_DragPositionOutOfBounds = !RectTransformUtility.RectangleContainsScreenPoint(((Graphic) this.textComponent).rectTransform, eventData.position, eventData.pressEventCamera);
      if (this.m_DragPositionOutOfBounds && this.m_DragCoroutine == null)
        this.m_DragCoroutine = ((MonoBehaviour) this).StartCoroutine(this.MouseDragOutsideRect(eventData));
      ((BaseEventData) eventData).Use();
    }

    [DebuggerHidden]
    private IEnumerator MouseDragOutsideRect(PointerEventData eventData)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new UIEmojiInput.\u003CMouseDragOutsideRect\u003Ec__IteratorE()
      {
        eventData = eventData,
        \u003C\u0024\u003EeventData = eventData,
        \u003C\u003Ef__this = this
      };
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
      if (!this.MayDrag(eventData))
        return;
      this.m_UpdateDrag = false;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
      if (!this.MayDrag(eventData))
        return;
      EventSystem.current.SetSelectedGameObject(((Component) this).gameObject, (BaseEventData) eventData);
      bool allowInput = this.m_AllowInput;
      base.OnPointerDown(eventData);
      if (!this.InPlaceEditing() && (UIEmojiInput.m_Keyboard == null || !UIEmojiInput.m_Keyboard.active))
      {
        this.OnSelect((BaseEventData) eventData);
      }
      else
      {
        if (allowInput)
        {
          int num = this.GetCharacterIndexFromPosition(this.ScreenToLocal(eventData.position)) + this.m_DrawStart;
          this.caretPositionInternal = num;
          this.caretSelectPositionInternal = num;
        }
        this.UpdateLabel();
        ((BaseEventData) eventData).Use();
      }
    }

    protected UIEmojiInput.EditState KeyPressed(Event evt)
    {
      EventModifiers modifiers = evt.modifiers;
      RuntimePlatform platform = Application.platform;
      int num;
      switch (platform)
      {
        case RuntimePlatform.OSXEditor:
        case RuntimePlatform.OSXPlayer:
          num = 1;
          break;
        default:
          num = platform == RuntimePlatform.OSXWebPlayer ? 1 : 0;
          break;
      }
      bool ctrl = num == 0 ? (modifiers & EventModifiers.Control) != (EventModifiers) 0 : (modifiers & EventModifiers.Command) != (EventModifiers) 0;
      bool shift = (modifiers & EventModifiers.Shift) != (EventModifiers) 0;
      bool flag1 = (modifiers & EventModifiers.Alt) != (EventModifiers) 0;
      bool flag2 = ctrl && !flag1 && !shift;
      KeyCode keyCode = evt.keyCode;
      switch (keyCode)
      {
        case KeyCode.KeypadEnter:
label_26:
          if (this.lineType != UIEmojiInput.LineType.MultiLineNewline)
            return UIEmojiInput.EditState.Finish;
          break;
        case KeyCode.UpArrow:
          this.MoveUp(shift);
          return UIEmojiInput.EditState.Continue;
        case KeyCode.DownArrow:
          this.MoveDown(shift);
          return UIEmojiInput.EditState.Continue;
        case KeyCode.RightArrow:
          this.MoveRight(shift, ctrl);
          return UIEmojiInput.EditState.Continue;
        case KeyCode.LeftArrow:
          this.MoveLeft(shift, ctrl);
          return UIEmojiInput.EditState.Continue;
        case KeyCode.Home:
          this.MoveTextStart(shift);
          return UIEmojiInput.EditState.Continue;
        case KeyCode.End:
          this.MoveTextEnd(shift);
          return UIEmojiInput.EditState.Continue;
        default:
          switch (keyCode - 97)
          {
            case KeyCode.None:
              if (flag2)
              {
                this.SelectAll();
                return UIEmojiInput.EditState.Continue;
              }
              break;
            case (KeyCode) 2:
              if (flag2)
              {
                UIEmojiInput.clipboard = this.GetSelectedString();
                return UIEmojiInput.EditState.Continue;
              }
              break;
            default:
              switch (keyCode - 118)
              {
                case KeyCode.None:
                  if (flag2)
                  {
                    this.Append(UIEmojiInput.clipboard);
                    return UIEmojiInput.EditState.Continue;
                  }
                  break;
                case (KeyCode) 2:
                  if (flag2)
                  {
                    UIEmojiInput.clipboard = this.GetSelectedString();
                    this.Delete();
                    this.SendOnValueChangedAndUpdateLabel();
                    return UIEmojiInput.EditState.Continue;
                  }
                  break;
                default:
                  if (keyCode != KeyCode.Backspace)
                  {
                    if (keyCode != KeyCode.Return)
                    {
                      if (keyCode != KeyCode.Escape)
                      {
                        if (keyCode == KeyCode.Delete)
                        {
                          this.ForwardSpace();
                          return UIEmojiInput.EditState.Continue;
                        }
                        break;
                      }
                      this.m_WasCanceled = true;
                      return UIEmojiInput.EditState.Finish;
                    }
                    goto label_26;
                  }
                  else
                  {
                    this.Backspace();
                    return UIEmojiInput.EditState.Continue;
                  }
              }
              break;
          }
          break;
      }
      if (!this.multiLine && evt.character == '\t')
        return UIEmojiInput.EditState.Continue;
      char ch = evt.character;
      switch (ch)
      {
        case '\u0003':
        case '\r':
          ch = '\n';
          break;
      }
      if (this.IsValidChar(ch))
        this.Append(ch);
      if (ch == char.MinValue && Input.compositionString.Length > 0)
        this.UpdateLabel();
      return UIEmojiInput.EditState.Continue;
    }

    private bool IsValidChar(char c)
    {
      switch (c)
      {
        case '\t':
        case '\n':
          return true;
        case '\u007F':
          return false;
        default:
          return this.m_TextComponent.font.HasCharacter(c);
      }
    }

    public void ProcessEvent(Event e)
    {
      int num = (int) this.KeyPressed(e);
    }

    public virtual void OnUpdateSelected(BaseEventData eventData)
    {
      if (!this.isFocused)
        return;
      bool flag = false;
      while (Event.PopEvent(this.m_ProcessingEvent))
      {
        if (this.m_ProcessingEvent.rawType == EventType.KeyDown)
        {
          flag = true;
          if (this.KeyPressed(this.m_ProcessingEvent) == UIEmojiInput.EditState.Finish)
          {
            this.DeactivateInputField();
            break;
          }
        }
      }
      if (flag)
        this.UpdateLabel();
      eventData.Use();
    }

    private string GetSelectedString()
    {
      if (!this.hasSelection)
        return string.Empty;
      int num1 = this.caretPositionInternal;
      int num2 = this.caretSelectPositionInternal;
      if (num1 > num2)
      {
        int num3 = num1;
        num1 = num2;
        num2 = num3;
      }
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = num1; index < num2; ++index)
        stringBuilder.Append(this.text[index]);
      return stringBuilder.ToString();
    }

    private int FindtNextWordBegin()
    {
      if (this.caretSelectPositionInternal + 1 >= this.text.Length)
        return this.text.Length;
      int num = this.text.IndexOfAny(UIEmojiInput.kSeparators, this.caretSelectPositionInternal + 1);
      return num != -1 ? num + 1 : this.text.Length;
    }

    private void MoveRight(bool shift, bool ctrl)
    {
      if (this.hasSelection && !shift)
      {
        int num = Mathf.Max(this.caretPositionInternal, this.caretSelectPositionInternal);
        this.caretSelectPositionInternal = num;
        this.caretPositionInternal = num;
      }
      else
      {
        int num1 = !ctrl ? this.caretSelectPositionInternal + 1 : this.FindtNextWordBegin();
        if (shift)
        {
          this.caretSelectPositionInternal = num1;
        }
        else
        {
          int num2 = num1;
          this.caretPositionInternal = num2;
          this.caretSelectPositionInternal = num2;
        }
      }
    }

    private int FindtPrevWordBegin()
    {
      if (this.caretSelectPositionInternal - 2 < 0)
        return 0;
      int num = this.text.LastIndexOfAny(UIEmojiInput.kSeparators, this.caretSelectPositionInternal - 2);
      return num != -1 ? num + 1 : 0;
    }

    private void MoveLeft(bool shift, bool ctrl)
    {
      if (this.hasSelection && !shift)
      {
        int num = Mathf.Min(this.caretPositionInternal, this.caretSelectPositionInternal);
        this.caretSelectPositionInternal = num;
        this.caretPositionInternal = num;
      }
      else
      {
        int num1 = !ctrl ? this.caretSelectPositionInternal - 1 : this.FindtPrevWordBegin();
        if (shift)
        {
          this.caretSelectPositionInternal = num1;
        }
        else
        {
          int num2 = num1;
          this.caretPositionInternal = num2;
          this.caretSelectPositionInternal = num2;
        }
      }
    }

    private int DetermineCharacterLine(int charPos, TextGenerator generator)
    {
      if (!this.multiLine)
        return 0;
      for (int characterLine = 0; characterLine < generator.lineCount - 1; ++characterLine)
      {
        if (generator.lines[characterLine + 1].startCharIdx > charPos)
          return characterLine;
      }
      return generator.lineCount - 1;
    }

    private int LineUpCharacterPosition(int originalPos, bool goToFirstChar)
    {
      if (originalPos >= this.cachedInputTextGenerator.characterCountVisible)
        return 0;
      UICharInfo character = this.cachedInputTextGenerator.characters[originalPos];
      int characterLine = this.DetermineCharacterLine(originalPos, this.cachedInputTextGenerator);
      if (characterLine - 1 < 0)
        return goToFirstChar ? 0 : originalPos;
      int num = this.cachedInputTextGenerator.lines[characterLine].startCharIdx - 1;
      for (int startCharIdx = this.cachedInputTextGenerator.lines[characterLine - 1].startCharIdx; startCharIdx < num; ++startCharIdx)
      {
        if ((double) this.cachedInputTextGenerator.characters[startCharIdx].cursorPos.x >= (double) character.cursorPos.x)
          return startCharIdx;
      }
      return num;
    }

    private int LineDownCharacterPosition(int originalPos, bool goToLastChar)
    {
      if (originalPos >= this.cachedInputTextGenerator.characterCountVisible)
        return this.text.Length;
      UICharInfo character = this.cachedInputTextGenerator.characters[originalPos];
      int characterLine = this.DetermineCharacterLine(originalPos, this.cachedInputTextGenerator);
      if (characterLine + 1 >= this.cachedInputTextGenerator.lineCount)
        return goToLastChar ? this.text.Length : originalPos;
      int lineEndPosition = UIEmojiInput.GetLineEndPosition(this.cachedInputTextGenerator, characterLine + 1);
      for (int startCharIdx = this.cachedInputTextGenerator.lines[characterLine + 1].startCharIdx; startCharIdx < lineEndPosition; ++startCharIdx)
      {
        if ((double) this.cachedInputTextGenerator.characters[startCharIdx].cursorPos.x >= (double) character.cursorPos.x)
          return startCharIdx;
      }
      return lineEndPosition;
    }

    private void MoveDown(bool shift) => this.MoveDown(shift, true);

    private void MoveDown(bool shift, bool goToLastChar)
    {
      if (this.hasSelection && !shift)
      {
        int num = Mathf.Max(this.caretPositionInternal, this.caretSelectPositionInternal);
        this.caretSelectPositionInternal = num;
        this.caretPositionInternal = num;
      }
      int num1 = !this.multiLine ? this.text.Length : this.LineDownCharacterPosition(this.caretSelectPositionInternal, goToLastChar);
      if (shift)
      {
        this.caretSelectPositionInternal = num1;
      }
      else
      {
        int num2 = num1;
        this.caretSelectPositionInternal = num2;
        this.caretPositionInternal = num2;
      }
    }

    private void MoveUp(bool shift) => this.MoveUp(shift, true);

    private void MoveUp(bool shift, bool goToFirstChar)
    {
      if (this.hasSelection && !shift)
      {
        int num = Mathf.Min(this.caretPositionInternal, this.caretSelectPositionInternal);
        this.caretSelectPositionInternal = num;
        this.caretPositionInternal = num;
      }
      int num1 = !this.multiLine ? 0 : this.LineUpCharacterPosition(this.caretSelectPositionInternal, goToFirstChar);
      if (shift)
      {
        this.caretSelectPositionInternal = num1;
      }
      else
      {
        int num2 = num1;
        this.caretPositionInternal = num2;
        this.caretSelectPositionInternal = num2;
      }
    }

    private void Delete()
    {
      if (this.caretPositionInternal == this.caretSelectPositionInternal)
        return;
      if (this.caretPositionInternal < this.caretSelectPositionInternal)
      {
        this.m_Text = this.text.Substring(0, this.caretPositionInternal) + this.text.Substring(this.caretSelectPositionInternal, this.text.Length - this.caretSelectPositionInternal);
        this.caretSelectPositionInternal = this.caretPositionInternal;
      }
      else
      {
        this.m_Text = this.text.Substring(0, this.caretSelectPositionInternal) + this.text.Substring(this.caretPositionInternal, this.text.Length - this.caretPositionInternal);
        this.caretPositionInternal = this.caretSelectPositionInternal;
      }
    }

    private void ForwardSpace()
    {
      if (this.hasSelection)
      {
        this.Delete();
        this.SendOnValueChangedAndUpdateLabel();
      }
      else
      {
        if (this.caretPositionInternal >= this.text.Length)
          return;
        this.m_Text = this.text.Remove(this.caretPositionInternal, 1);
        this.SendOnValueChangedAndUpdateLabel();
      }
    }

    private void Backspace()
    {
      if (this.hasSelection)
      {
        this.Delete();
        this.SendOnValueChangedAndUpdateLabel();
      }
      else
      {
        if (this.caretPositionInternal <= 0)
          return;
        this.m_Text = this.text.Remove(this.caretPositionInternal - 1, 1);
        this.caretSelectPositionInternal = --this.caretPositionInternal;
        this.SendOnValueChangedAndUpdateLabel();
      }
    }

    private void Insert(char c)
    {
      string str = c.ToString();
      this.Delete();
      if (this.characterLimit > 0 && this.text.Length >= this.characterLimit)
        return;
      this.m_Text = this.text.Insert(this.m_CaretPosition, str);
      this.caretSelectPositionInternal = (this.caretPositionInternal += str.Length);
      this.SendOnValueChanged();
    }

    private void SendOnValueChangedAndUpdateLabel()
    {
      this.SendOnValueChanged();
      this.UpdateLabel();
    }

    private void SendOnValueChanged()
    {
      if (this.onValueChange == null)
        return;
      this.onValueChange.Invoke(this.text);
    }

    protected void SendOnSubmit()
    {
      if (this.onEndEdit == null)
        return;
      this.onEndEdit.Invoke(this.m_Text);
    }

    protected virtual void Append(string input)
    {
      if (!this.InPlaceEditing())
        return;
      int index = 0;
      for (int length = input.Length; index < length; ++index)
      {
        char input1 = input[index];
        if (input1 >= ' ')
          this.Append(input1);
      }
    }

    protected virtual void Append(char input)
    {
      if (!this.InPlaceEditing())
        return;
      if (this.onValidateInput != null)
        input = this.onValidateInput(this.text, this.caretPositionInternal, input);
      else if (this.characterValidation != UIEmojiInput.CharacterValidation.None)
        input = this.Validate(this.text, this.caretPositionInternal, input);
      if (input == char.MinValue)
        return;
      this.Insert(input);
    }

    protected void UpdateLabel()
    {
      if (!((UnityEngine.Object) this.m_TextComponent != (UnityEngine.Object) null) || !((UnityEngine.Object) this.m_TextComponent.font != (UnityEngine.Object) null) || this.m_PreventFontCallback)
        return;
      string str1 = Input.compositionString.Length <= 0 ? this.text : this.text.Substring(0, this.m_CaretPosition) + Input.compositionString + this.text.Substring(this.m_CaretPosition);
      string str2 = this.inputType != UIEmojiInput.InputType.Password ? str1 : new string(this.asteriskChar, str1.Length);
      bool flag1 = string.IsNullOrEmpty(str1);
      if ((UnityEngine.Object) this.m_Placeholder != (UnityEngine.Object) null)
        ((Behaviour) this.m_Placeholder).enabled = flag1;
      if (!this.m_AllowInput)
      {
        this.m_DrawStart = 0;
        this.m_DrawEnd = this.m_Text.Length;
      }
      bool flag2 = ArabicTransfer.Instance.IsArabicStr(str2);
      if (!flag1)
      {
        TextGenerationSettings generationSettings = this.m_TextComponent.GetGenerationSettings(((Graphic) this.m_TextComponent).rectTransform.rect.size);
        generationSettings.generateOutOfBounds = true;
        this.m_PreventFontCallback = true;
        if (flag2)
        {
          this.m_TextComponent.text = str2;
          this.cachedInputTextGenerator.Populate(this.m_TextComponent.text, generationSettings);
        }
        else
          this.cachedInputTextGenerator.Populate(str2, generationSettings);
        this.m_PreventFontCallback = false;
        this.cachedInputTextGenerator.Invalidate();
        this.SetDrawRangeToContainCaretPosition(this.cachedInputTextGenerator, this.caretSelectPositionInternal, ref this.m_DrawStart, ref this.m_DrawEnd);
        str2 = str2.Substring(this.m_DrawStart, Mathf.Min(this.m_DrawEnd, str2.Length) - this.m_DrawStart);
        this.SetCaretVisible();
      }
      else
        this.m_TextComponent.text = string.Empty;
      if (!flag2)
        this.m_TextComponent.text = str2;
      this.MarkGeometryAsDirty();
    }

    private bool IsSelectionVisible()
    {
      return this.m_DrawStart <= this.caretPositionInternal && this.m_DrawStart <= this.caretSelectPositionInternal && this.m_DrawEnd >= this.caretPositionInternal && this.m_DrawEnd >= this.caretSelectPositionInternal;
    }

    private static int GetLineStartPosition(TextGenerator gen, int line)
    {
      line = Mathf.Clamp(line, 0, gen.lines.Count - 1);
      return gen.lines[line].startCharIdx;
    }

    private static int GetLineEndPosition(TextGenerator gen, int line)
    {
      line = Mathf.Max(line, 0);
      return line + 1 < gen.lines.Count ? gen.lines[line + 1].startCharIdx : gen.characterCountVisible;
    }

    private void SetDrawRangeToContainCaretPosition(
      TextGenerator gen,
      int caretPos,
      ref int drawStart,
      ref int drawEnd)
    {
      Vector2 size = gen.rectExtents.size;
      if (this.multiLine)
      {
        IList<UILineInfo> lines = gen.lines;
        int characterLine1 = this.DetermineCharacterLine(caretPos, gen);
        int y = (int) size.y;
        if (drawEnd <= caretPos)
        {
          drawEnd = UIEmojiInput.GetLineEndPosition(gen, characterLine1);
          for (int index = characterLine1; index >= 0 && index < lines.Count; --index)
          {
            y -= lines[index].height;
            if (y < 0)
              break;
            drawStart = UIEmojiInput.GetLineStartPosition(gen, index);
          }
        }
        else
        {
          if (drawStart > caretPos)
            drawStart = UIEmojiInput.GetLineStartPosition(gen, characterLine1);
          int characterLine2 = this.DetermineCharacterLine(drawStart, gen);
          int num1 = characterLine2;
          drawEnd = UIEmojiInput.GetLineEndPosition(gen, num1);
          int num2 = y - lines[num1].height;
          while (true)
          {
            while (num1 >= lines.Count - 1)
            {
              if (characterLine2 <= 0)
                return;
              --characterLine2;
              if (num2 < lines[characterLine2].height)
                return;
              drawStart = UIEmojiInput.GetLineStartPosition(gen, characterLine2);
              num2 -= lines[characterLine2].height;
            }
            ++num1;
            if (num2 >= lines[num1].height)
            {
              drawEnd = UIEmojiInput.GetLineEndPosition(gen, num1);
              num2 -= lines[num1].height;
            }
            else
              break;
          }
        }
      }
      else
      {
        float x = size.x;
        IList<UICharInfo> characters = gen.characters;
        if (drawEnd <= caretPos)
        {
          drawEnd = Mathf.Min(caretPos, gen.characterCountVisible);
          drawStart = 0;
          for (int index = drawEnd; index > 0; --index)
          {
            x -= characters[index - 1].charWidth;
            if ((double) x < 0.0)
            {
              drawStart = index;
              break;
            }
          }
        }
        else
        {
          if (drawStart > caretPos)
            drawStart = caretPos;
          drawEnd = gen.characterCountVisible;
          for (int index = drawStart; index < gen.characterCountVisible; ++index)
          {
            x -= characters[index].charWidth;
            if ((double) x < 0.0)
            {
              drawEnd = index;
              break;
            }
          }
        }
      }
    }

    private void MarkGeometryAsDirty()
    {
      CanvasUpdateRegistry.RegisterCanvasElementForGraphicRebuild((ICanvasElement) this);
    }

    public virtual void Rebuild(CanvasUpdate update)
    {
      if (update != 4)
        return;
      this.UpdateGeometry();
    }

    private void UpdateGeometry()
    {
      if (!this.shouldHideMobileInput)
        return;
      if ((UnityEngine.Object) this.m_CachedInputRenderer == (UnityEngine.Object) null && (UnityEngine.Object) this.m_TextComponent != (UnityEngine.Object) null)
      {
        GameObject gameObject = new GameObject(((Component) this).transform.name + " Input Caret");
        gameObject.hideFlags = HideFlags.DontSave;
        gameObject.transform.SetParent(((Component) this.m_TextComponent).transform.parent);
        gameObject.transform.SetAsFirstSibling();
        gameObject.layer = ((Component) this).gameObject.layer;
        this.caretRectTrans = gameObject.AddComponent<RectTransform>();
        this.m_CachedInputRenderer = gameObject.AddComponent<CanvasRenderer>();
        this.m_CachedInputRenderer.SetMaterial(Graphic.defaultGraphicMaterial, (Texture) null);
        gameObject.AddComponent<LayoutElement>().ignoreLayout = true;
        this.AssignPositioningIfNeeded();
      }
      if ((UnityEngine.Object) this.m_CachedInputRenderer == (UnityEngine.Object) null)
        return;
      this.OnFillVBO(this.m_Vbo);
      if (this.m_Vbo.Count == 0)
        this.m_CachedInputRenderer.SetVertices((UIVertex[]) null, 0);
      else
        this.m_CachedInputRenderer.SetVertices(this.m_Vbo.ToArray(), this.m_Vbo.Count);
      this.m_Vbo.Clear();
    }

    private void AssignPositioningIfNeeded()
    {
      if (!((UnityEngine.Object) this.m_TextComponent != (UnityEngine.Object) null) || !((UnityEngine.Object) this.caretRectTrans != (UnityEngine.Object) null) || !(((Transform) this.caretRectTrans).localPosition != ((Transform) ((Graphic) this.m_TextComponent).rectTransform).localPosition) && !(((Transform) this.caretRectTrans).localRotation != ((Transform) ((Graphic) this.m_TextComponent).rectTransform).localRotation) && !(((Transform) this.caretRectTrans).localScale != ((Transform) ((Graphic) this.m_TextComponent).rectTransform).localScale) && !(this.caretRectTrans.anchorMin != ((Graphic) this.m_TextComponent).rectTransform.anchorMin) && !(this.caretRectTrans.anchorMax != ((Graphic) this.m_TextComponent).rectTransform.anchorMax) && !(this.caretRectTrans.anchoredPosition != ((Graphic) this.m_TextComponent).rectTransform.anchoredPosition) && !(this.caretRectTrans.sizeDelta != ((Graphic) this.m_TextComponent).rectTransform.sizeDelta) && !(this.caretRectTrans.pivot != ((Graphic) this.m_TextComponent).rectTransform.pivot))
        return;
      ((Transform) this.caretRectTrans).localPosition = ((Transform) ((Graphic) this.m_TextComponent).rectTransform).localPosition;
      ((Transform) this.caretRectTrans).localRotation = ((Transform) ((Graphic) this.m_TextComponent).rectTransform).localRotation;
      ((Transform) this.caretRectTrans).localScale = ((Transform) ((Graphic) this.m_TextComponent).rectTransform).localScale;
      this.caretRectTrans.anchorMin = ((Graphic) this.m_TextComponent).rectTransform.anchorMin;
      this.caretRectTrans.anchorMax = ((Graphic) this.m_TextComponent).rectTransform.anchorMax;
      this.caretRectTrans.anchoredPosition = ((Graphic) this.m_TextComponent).rectTransform.anchoredPosition;
      this.caretRectTrans.sizeDelta = ((Graphic) this.m_TextComponent).rectTransform.sizeDelta;
      this.caretRectTrans.pivot = ((Graphic) this.m_TextComponent).rectTransform.pivot;
    }

    private void OnFillVBO(List<UIVertex> vbo)
    {
      if (!this.isFocused)
        return;
      Rect rect = ((Graphic) this.m_TextComponent).rectTransform.rect;
      Vector2 size = rect.size;
      Vector2 textAnchorPivot = UnityEngine.UI.Text.GetTextAnchorPivot(this.m_TextComponent.alignment);
      Vector2 zero = Vector2.zero with
      {
        x = Mathf.Lerp(rect.xMin, rect.xMax, textAnchorPivot.x),
        y = Mathf.Lerp(rect.yMin, rect.yMax, textAnchorPivot.y)
      };
      Vector2 roundingOffset = ((Graphic) this.m_TextComponent).PixelAdjustPoint(zero) - zero + Vector2.Scale(size, textAnchorPivot);
      roundingOffset.x -= Mathf.Floor(0.5f + roundingOffset.x);
      roundingOffset.y -= Mathf.Floor(0.5f + roundingOffset.y);
      if (!this.hasSelection)
        this.GenerateCursor(vbo, roundingOffset);
      else
        this.GenerateHightlight(vbo, roundingOffset);
    }

    private void GenerateCursor(List<UIVertex> vbo, Vector2 roundingOffset)
    {
      if (!this.m_CaretVisible)
        return;
      if (this.m_CursorVerts == null)
        this.CreateCursorVerts();
      float num1 = 1f;
      float num2 = (float) this.m_TextComponent.fontSize;
      int index1 = Mathf.Max(0, this.caretPositionInternal - this.m_DrawStart);
      TextGenerator cachedTextGenerator = this.m_TextComponent.cachedTextGenerator;
      if (cachedTextGenerator == null)
        return;
      if (this.m_TextComponent.resizeTextForBestFit)
        num2 = (float) cachedTextGenerator.fontSizeUsedForBestFit / this.m_TextComponent.pixelsPerUnit;
      Vector2 zero = Vector2.zero;
      if (cachedTextGenerator.characterCountVisible + 1 > index1 || index1 == 0)
      {
        UICharInfo character = cachedTextGenerator.characters[index1];
        zero.x = character.cursorPos.x;
        zero.y = character.cursorPos.y;
      }
      zero.x /= this.m_TextComponent.pixelsPerUnit;
      if ((double) zero.x > (double) ((Graphic) this.m_TextComponent).rectTransform.rect.xMax)
        zero.x = ((Graphic) this.m_TextComponent).rectTransform.rect.xMax;
      this.m_CursorVerts[0].position = new Vector3(zero.x, zero.y - num2, 0.0f);
      this.m_CursorVerts[1].position = new Vector3(zero.x + num1, zero.y - num2, 0.0f);
      this.m_CursorVerts[2].position = new Vector3(zero.x + num1, zero.y, 0.0f);
      this.m_CursorVerts[3].position = new Vector3(zero.x, zero.y, 0.0f);
      if (roundingOffset != Vector2.zero)
      {
        for (int index2 = 0; index2 < this.m_CursorVerts.Length; ++index2)
        {
          UIVertex cursorVert = this.m_CursorVerts[index2];
          cursorVert.position.x += roundingOffset.x;
          cursorVert.position.y += roundingOffset.y;
          vbo.Add(cursorVert);
        }
      }
      else
      {
        for (int index3 = 0; index3 < this.m_CursorVerts.Length; ++index3)
          vbo.Add(this.m_CursorVerts[index3]);
      }
      zero.y = (float) Screen.height - zero.y;
      Input.compositionCursorPos = zero;
    }

    private void CreateCursorVerts()
    {
      this.m_CursorVerts = new UIVertex[4];
      for (int index = 0; index < this.m_CursorVerts.Length; ++index)
      {
        this.m_CursorVerts[index] = UIVertex.simpleVert;
        this.m_CursorVerts[index].color = (Color32) ((Graphic) this.m_TextComponent).color;
        this.m_CursorVerts[index].uv0 = Vector2.zero;
      }
    }

    private float SumLineHeights(int endLine, TextGenerator generator)
    {
      float num = 0.0f;
      for (int index = 0; index < endLine; ++index)
        num += (float) generator.lines[index].height;
      return num;
    }

    private void GenerateHightlight(List<UIVertex> vbo, Vector2 roundingOffset)
    {
      int num1 = Mathf.Max(0, this.caretPositionInternal - this.m_DrawStart);
      int num2 = Mathf.Max(0, this.caretSelectPositionInternal - this.m_DrawStart);
      if (num1 > num2)
      {
        int num3 = num1;
        num1 = num2;
        num2 = num3;
      }
      int num4 = num2 - 1;
      TextGenerator cachedTextGenerator = this.m_TextComponent.cachedTextGenerator;
      int characterLine = this.DetermineCharacterLine(num1, cachedTextGenerator);
      float num5 = (float) this.m_TextComponent.fontSize;
      if (this.m_TextComponent.resizeTextForBestFit)
        num5 = (float) cachedTextGenerator.fontSizeUsedForBestFit / this.m_TextComponent.pixelsPerUnit;
      if (this.cachedInputTextGenerator != null && this.cachedInputTextGenerator.lines.Count > 0)
        num5 = (float) this.cachedInputTextGenerator.lines[0].height;
      if (this.m_TextComponent.resizeTextForBestFit && this.cachedInputTextGenerator != null)
        num5 = (float) this.cachedInputTextGenerator.fontSizeUsedForBestFit;
      int lineEndPosition = UIEmojiInput.GetLineEndPosition(cachedTextGenerator, characterLine);
      UIVertex simpleVert = UIVertex.simpleVert;
      simpleVert.uv0 = Vector2.zero;
      simpleVert.color = (Color32) this.selectionColor;
      for (int index = num1; index <= num4 && index < cachedTextGenerator.characterCountVisible; ++index)
      {
        if (index + 1 == lineEndPosition || index == num4)
        {
          UICharInfo character1 = cachedTextGenerator.characters[num1];
          UICharInfo character2 = cachedTextGenerator.characters[index];
          Vector2 vector2_1 = new Vector2(character1.cursorPos.x / this.m_TextComponent.pixelsPerUnit, character1.cursorPos.y);
          Vector2 vector2_2 = new Vector2((character2.cursorPos.x + character2.charWidth) / this.m_TextComponent.pixelsPerUnit, vector2_1.y - num5 / this.m_TextComponent.pixelsPerUnit);
          if ((double) vector2_2.x > (double) ((Graphic) this.m_TextComponent).rectTransform.rect.xMax || (double) vector2_2.x < (double) ((Graphic) this.m_TextComponent).rectTransform.rect.xMin)
            vector2_2.x = ((Graphic) this.m_TextComponent).rectTransform.rect.xMax;
          simpleVert.position = new Vector3(vector2_1.x, vector2_2.y, 0.0f) + (Vector3) roundingOffset;
          vbo.Add(simpleVert);
          simpleVert.position = new Vector3(vector2_2.x, vector2_2.y, 0.0f) + (Vector3) roundingOffset;
          vbo.Add(simpleVert);
          simpleVert.position = new Vector3(vector2_2.x, vector2_1.y, 0.0f) + (Vector3) roundingOffset;
          vbo.Add(simpleVert);
          simpleVert.position = new Vector3(vector2_1.x, vector2_1.y, 0.0f) + (Vector3) roundingOffset;
          vbo.Add(simpleVert);
          num1 = index + 1;
          ++characterLine;
          lineEndPosition = UIEmojiInput.GetLineEndPosition(cachedTextGenerator, characterLine);
        }
      }
    }

    protected char Validate(string text, int pos, char ch)
    {
      if (this.characterValidation == UIEmojiInput.CharacterValidation.None || !((Behaviour) this).enabled)
        return ch;
      if (this.characterValidation == UIEmojiInput.CharacterValidation.Integer || this.characterValidation == UIEmojiInput.CharacterValidation.Decimal)
      {
        if ((pos != 0 || text.Length <= 0 || text[0] != '-') && (ch >= '0' && ch <= '9' || ch == '-' && pos == 0 || ch == '.' && this.characterValidation == UIEmojiInput.CharacterValidation.Decimal && !text.Contains(".")))
          return ch;
      }
      else if (this.characterValidation == UIEmojiInput.CharacterValidation.Alphanumeric)
      {
        if (ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z' || ch >= '0' && ch <= '9')
          return ch;
      }
      else if (this.characterValidation == UIEmojiInput.CharacterValidation.Name)
      {
        char ch1 = text.Length <= 0 ? ' ' : text[Mathf.Clamp(pos, 0, text.Length - 1)];
        char ch2 = text.Length <= 0 ? '\n' : text[Mathf.Clamp(pos + 1, 0, text.Length - 1)];
        if (char.IsLetter(ch))
        {
          if (char.IsLower(ch) && ch1 == ' ')
            return char.ToUpper(ch);
          return char.IsUpper(ch) && ch1 != ' ' && ch1 != '\'' ? char.ToLower(ch) : ch;
        }
        switch (ch)
        {
          case ' ':
            if (ch1 != ' ' && ch1 != '\'' && ch2 != ' ' && ch2 != '\'')
              return ch;
            break;
          case '\'':
            if (ch1 != ' ' && ch1 != '\'' && ch2 != '\'' && !text.Contains("'"))
              return ch;
            break;
        }
      }
      else if (this.characterValidation == UIEmojiInput.CharacterValidation.EmailAddress)
      {
        if (ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z' || ch >= '0' && ch <= '9' || ch == '@' && text.IndexOf('@') == -1 || "!#$%&'*+-/=?^_`{|}~".IndexOf(ch) != -1)
          return ch;
        if (ch == '.')
        {
          char ch3 = text.Length <= 0 ? ' ' : text[Mathf.Clamp(pos, 0, text.Length - 1)];
          char ch4 = text.Length <= 0 ? '\n' : text[Mathf.Clamp(pos + 1, 0, text.Length - 1)];
          if (ch3 != '.' && ch4 != '.')
            return ch;
        }
      }
      return char.MinValue;
    }

    public void ActivateInputField()
    {
      if ((UnityEngine.Object) this.m_TextComponent == (UnityEngine.Object) null || (UnityEngine.Object) this.m_TextComponent.font == (UnityEngine.Object) null || !((UIBehaviour) this).IsActive() || !this.IsInteractable())
        return;
      if (this.isFocused && UIEmojiInput.m_Keyboard != null && !UIEmojiInput.m_Keyboard.active)
      {
        UIEmojiInput.m_Keyboard.active = true;
        UIEmojiInput.m_Keyboard.text = this.m_Text;
      }
      this.m_ShouldActivateNextUpdate = true;
    }

    private void ActivateInputFieldInternal()
    {
      if ((UnityEngine.Object) EventSystem.current.currentSelectedGameObject != (UnityEngine.Object) ((Component) this).gameObject)
        EventSystem.current.SetSelectedGameObject(((Component) this).gameObject);
      if (TouchScreenKeyboard.isSupported)
      {
        if (Input.touchSupported)
          TouchScreenKeyboard.hideInput = this.shouldHideMobileInput;
        UIEmojiInput.m_Keyboard = this.inputType != UIEmojiInput.InputType.Password ? TouchScreenKeyboard.Open(this.m_Text, this.keyboardType, this.inputType == UIEmojiInput.InputType.AutoCorrect, this.multiLine) : TouchScreenKeyboard.Open(this.m_Text, this.keyboardType, false, this.multiLine, true);
      }
      else
      {
        Input.imeCompositionMode = IMECompositionMode.On;
        this.OnFocus();
      }
      this.m_AllowInput = true;
      this.m_OriginalText = this.text;
      this.m_WasCanceled = false;
      this.SetCaretVisible();
      this.UpdateLabel();
    }

    public virtual void OnSelect(BaseEventData eventData)
    {
      base.OnSelect(eventData);
      this.ActivateInputField();
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
      if (eventData.button != null)
        return;
      this.ActivateInputField();
    }

    public void DeactivateInputField()
    {
      if (!this.m_AllowInput)
        return;
      this.m_HasDoneFocusTransition = false;
      this.m_AllowInput = false;
      if ((UnityEngine.Object) this.m_TextComponent != (UnityEngine.Object) null && this.IsInteractable())
      {
        if (this.m_WasCanceled)
          this.text = this.m_OriginalText;
        if (UIEmojiInput.m_Keyboard != null)
        {
          UIEmojiInput.m_Keyboard.active = false;
          UIEmojiInput.m_Keyboard = (TouchScreenKeyboard) null;
        }
        this.m_CaretPosition = this.m_CaretSelectPosition = 0;
        this.SendOnSubmit();
        Input.imeCompositionMode = IMECompositionMode.Auto;
      }
      this.MarkGeometryAsDirty();
    }

    public virtual void OnDeselect(BaseEventData eventData)
    {
      this.DeactivateInputField();
      base.OnDeselect(eventData);
    }

    public virtual void OnSubmit(BaseEventData eventData)
    {
      if (!((UIBehaviour) this).IsActive() || !this.IsInteractable() || this.isFocused)
        return;
      this.m_ShouldActivateNextUpdate = true;
    }

    private void EnforceContentType()
    {
      switch (this.contentType)
      {
        case UIEmojiInput.ContentType.Standard:
          this.m_InputType = UIEmojiInput.InputType.Standard;
          this.m_KeyboardType = TouchScreenKeyboardType.Default;
          this.m_CharacterValidation = UIEmojiInput.CharacterValidation.None;
          break;
        case UIEmojiInput.ContentType.Autocorrected:
          this.m_InputType = UIEmojiInput.InputType.AutoCorrect;
          this.m_KeyboardType = TouchScreenKeyboardType.Default;
          this.m_CharacterValidation = UIEmojiInput.CharacterValidation.None;
          break;
        case UIEmojiInput.ContentType.IntegerNumber:
          this.m_LineType = UIEmojiInput.LineType.SingleLine;
          this.m_InputType = UIEmojiInput.InputType.Standard;
          this.m_KeyboardType = TouchScreenKeyboardType.NumberPad;
          this.m_CharacterValidation = UIEmojiInput.CharacterValidation.Integer;
          break;
        case UIEmojiInput.ContentType.DecimalNumber:
          this.m_LineType = UIEmojiInput.LineType.SingleLine;
          this.m_InputType = UIEmojiInput.InputType.Standard;
          this.m_KeyboardType = TouchScreenKeyboardType.NumbersAndPunctuation;
          this.m_CharacterValidation = UIEmojiInput.CharacterValidation.Decimal;
          break;
        case UIEmojiInput.ContentType.Alphanumeric:
          this.m_LineType = UIEmojiInput.LineType.SingleLine;
          this.m_InputType = UIEmojiInput.InputType.Standard;
          this.m_KeyboardType = TouchScreenKeyboardType.ASCIICapable;
          this.m_CharacterValidation = UIEmojiInput.CharacterValidation.Alphanumeric;
          break;
        case UIEmojiInput.ContentType.Name:
          this.m_LineType = UIEmojiInput.LineType.SingleLine;
          this.m_InputType = UIEmojiInput.InputType.Standard;
          this.m_KeyboardType = TouchScreenKeyboardType.Default;
          this.m_CharacterValidation = UIEmojiInput.CharacterValidation.Name;
          break;
        case UIEmojiInput.ContentType.EmailAddress:
          this.m_LineType = UIEmojiInput.LineType.SingleLine;
          this.m_InputType = UIEmojiInput.InputType.Standard;
          this.m_KeyboardType = TouchScreenKeyboardType.EmailAddress;
          this.m_CharacterValidation = UIEmojiInput.CharacterValidation.EmailAddress;
          break;
        case UIEmojiInput.ContentType.Password:
          this.m_LineType = UIEmojiInput.LineType.SingleLine;
          this.m_InputType = UIEmojiInput.InputType.Password;
          this.m_KeyboardType = TouchScreenKeyboardType.Default;
          this.m_CharacterValidation = UIEmojiInput.CharacterValidation.None;
          break;
        case UIEmojiInput.ContentType.Pin:
          this.m_LineType = UIEmojiInput.LineType.SingleLine;
          this.m_InputType = UIEmojiInput.InputType.Password;
          this.m_KeyboardType = TouchScreenKeyboardType.NumberPad;
          this.m_CharacterValidation = UIEmojiInput.CharacterValidation.Integer;
          break;
      }
    }

    private void SetToCustomIfContentTypeIsNot(
      params UIEmojiInput.ContentType[] allowedContentTypes)
    {
      if (this.contentType == UIEmojiInput.ContentType.Custom)
        return;
      for (int index = 0; index < allowedContentTypes.Length; ++index)
      {
        if (this.contentType == allowedContentTypes[index])
          return;
      }
      this.contentType = UIEmojiInput.ContentType.Custom;
    }

    private void SetToCustom()
    {
      if (this.contentType == UIEmojiInput.ContentType.Custom)
        return;
      this.contentType = UIEmojiInput.ContentType.Custom;
    }

    protected virtual void DoStateTransition(Selectable.SelectionState state, bool instant)
    {
      if (this.m_HasDoneFocusTransition)
        state = (Selectable.SelectionState) 1;
      else if (state == 2)
        this.m_HasDoneFocusTransition = true;
      base.DoStateTransition(state, instant);
    }

    virtual Transform ICanvasElement.get_transform() => ((Component) this).transform;

    virtual bool ICanvasElement.IsDestroyed() => ((UIBehaviour) this).IsDestroyed();

    public enum ContentType
    {
      Standard,
      Autocorrected,
      IntegerNumber,
      DecimalNumber,
      Alphanumeric,
      Name,
      EmailAddress,
      Password,
      Pin,
      Custom,
    }

    public enum InputType
    {
      Standard,
      AutoCorrect,
      Password,
    }

    public enum CharacterValidation
    {
      None,
      Integer,
      Decimal,
      Alphanumeric,
      Name,
      EmailAddress,
    }

    public enum LineType
    {
      SingleLine,
      MultiLineSubmit,
      MultiLineNewline,
    }

    [Serializable]
    public class SubmitEvent : UnityEvent<string>
    {
    }

    [Serializable]
    public class OnChangeEvent : UnityEvent<string>
    {
    }

    protected enum EditState
    {
      Continue,
      Finish,
    }

    public delegate char OnValidateInput(string text, int charIndex, char addedChar);
  }
}
