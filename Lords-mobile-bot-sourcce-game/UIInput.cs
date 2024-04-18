// Decompiled with JetBrains decompiler
// Type: UIInput
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIInput : InputField, ISerializationCallbackReceiver
{
  protected bool HideMobileInput;
  protected bool KeyboardDone;
  private static bool KeyboardReturn;
  public bool shouldHideMobileInput;
  public UIInput.AdjustHeight onAdjust;
  public UIInput.EndEdit onEndInput;

  public UIInput()
  {
    // ISSUE: method pointer
    ((UnityEvent<string>) this.onEndEdit).AddListener(new UnityAction<string>((object) this, __methodptr(\u003CUIInput\u003Em__F8)));
  }

  public void Destroy()
  {
    this.onAdjust = (UIInput.AdjustHeight) null;
    if (InputField.m_Keyboard == null)
      return;
    InputField.m_Keyboard.active = false;
    InputField.m_Keyboard = (TouchScreenKeyboard) null;
  }

  protected void OnEndInput(string text)
  {
    if (this.onEndInput != null && this.KeyboardDone && !UIInput.KeyboardReturn)
      this.onEndInput(text);
    this.Close();
  }

  public void Close()
  {
    UIInput.KeyboardReturn = false;
    if (InputField.m_Keyboard == null)
      return;
    InputField.m_Keyboard.active = false;
  }

  public void Open()
  {
    this.ActivateInputField();
    this.HideMobileInput = true;
  }

  public void OnBeforeSerialize()
  {
  }

  public void OnAfterDeserialize() => this.shouldHideMobileInput = false;

  protected virtual void LateUpdate()
  {
    if (this.HideMobileInput && this.shouldHideMobileInput)
      this.shouldHideMobileInput = true;
    base.LateUpdate();
    if (!this.HideMobileInput && (double) NetworkManager.SynchTime < 0.5)
      return;
    if (this.HideMobileInput)
      this.shouldHideMobileInput = this.HideMobileInput = false;
    if (!TouchScreenKeyboard.visible || this.onAdjust == null)
      return;
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
    {
      using (AndroidJavaObject androidJavaObject = new AndroidJavaObject("android.graphics.Rect", new object[0]))
      {
        androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer").Call<AndroidJavaObject>("getView").Call("getWindowVisibleDisplayFrame", (object) androidJavaObject);
        this.onAdjust(Screen.height - androidJavaObject.Call<int>("height"));
      }
    }
  }

  public virtual void OnSubmit(BaseEventData eventData)
  {
    if (!((UIBehaviour) this).IsActive() || !((Selectable) this).IsInteractable() || this.isFocused)
      return;
    this.HideMobileInput = true;
    base.OnSubmit(eventData);
  }

  public virtual void OnPointerClick(PointerEventData eventData)
  {
    if (eventData.button != null)
      return;
    this.ActivateInputField();
    this.HideMobileInput = true;
  }

  public virtual void OnSelect(BaseEventData eventData)
  {
    base.OnSelect(eventData);
    this.ActivateInputField();
    this.HideMobileInput = true;
  }

  public virtual void OnDeselect(BaseEventData eventData)
  {
    if (InputField.m_Keyboard != null)
      this.KeyboardDone = InputField.m_Keyboard.done;
    this.DeactivateInputField();
    base.OnDeselect(eventData);
    if (this.onAdjust == null)
      return;
    this.onAdjust(0);
  }

  public static bool IsOpen()
  {
    UIInput.KeyboardReturn = true;
    return InputField.m_Keyboard != null;
  }

  public delegate void AdjustHeight(int height);

  public delegate void EndEdit(string text);
}
