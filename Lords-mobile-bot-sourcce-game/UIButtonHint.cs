// Decompiled with JetBrains decompiler
// Type: UIButtonHint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIButtonHint : 
  MonoBehaviour,
  IPointerUpHandler,
  IDragHandler,
  IPointerDownHandler,
  IEndDragHandler,
  IPointerExitHandler,
  IEventSystemHandler,
  IUIButtonClickHandler
{
  public Selectable m_Button;
  public EUIButtonHint m_eHint;
  public IUIButtonDownUpHandler m_DownUpHandler;
  private MonoBehaviour _Handler;
  public IUIUpdatePos m_HintPosHandler;
  public bool m_ForcePos;
  public Vector2 m_HIBtnOffset = Vector2.zero;
  private GameObject _ControlFadeOut;
  private CanvasGroup FadeOutCanvas;
  private float FadeTime;
  private float MaxFadeTime = 0.2f;
  private bool bFadeOut;
  public byte SkipDisabelEvent;
  public bool bCountDown;
  public float m_Time;
  public float DelayTime = 0.7f;
  public ushort Parm1;
  public byte Parm2;
  private byte IsValidClick;
  private UIButtonHint._BntAction _BtnAction;
  private Vector3 PressPosition;
  public byte ScrollID;
  public static CScrollRect scrollRect;
  public static CScrollRect scrollRect2;
  public static ScrollRect m_scrollRect;
  public static ScrollRect m_scrollRect2;
  private static UIButtonHint DelayFadeOutHint;

  public MonoBehaviour m_Handler
  {
    set
    {
      this._Handler = value;
      this.m_DownUpHandler = this._Handler as IUIButtonDownUpHandler;
    }
    get => this._Handler;
  }

  public GameObject ControlFadeOut
  {
    set
    {
      this._ControlFadeOut = value;
      if (!((UnityEngine.Object) (this.FadeOutCanvas = this._ControlFadeOut.GetComponent<CanvasGroup>()) == (UnityEngine.Object) null))
        return;
      this.FadeOutCanvas = this._ControlFadeOut.AddComponent<CanvasGroup>();
    }
    get => this._ControlFadeOut;
  }

  private UIButtonHint._BntAction BtnAction
  {
    set => this._BtnAction = value;
    get => this._BtnAction;
  }

  private void Awake() => this.m_Button = this.GetComponent<Selectable>();

  private void OnDestroy()
  {
    if (GameManager.bQuitGame)
      return;
    GUIManager.Instance.m_SimpleItemInfo.Hide(this);
    GUIManager.Instance.m_LordInfo.Hide(this);
    if (this.m_DownUpHandler != null)
      this.m_DownUpHandler.OnButtonUp(this);
    GUIManager.Instance.HintMaskObj.Hide(this);
  }

  private void OnDisable()
  {
    if (GameManager.bQuitGame)
      return;
    if (this.SkipDisabelEvent == (byte) 1)
    {
      this.SkipDisabelEvent = (byte) 0;
    }
    else
    {
      GUIManager.Instance.m_SimpleItemInfo.Hide(this);
      GUIManager.Instance.m_LordInfo.Hide(this);
      if (((Component) GUIManager.Instance.m_SkillInfo.m_RectTransform).gameObject.activeSelf)
        GUIManager.Instance.m_SkillInfo.Hide(this);
      if (this.m_DownUpHandler != null)
        this.m_DownUpHandler.OnButtonUp(this);
      GUIManager.Instance.HintMaskObj.Hide(this);
    }
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    if (!this.enabled || !this.gameObject.activeInHierarchy || (UnityEngine.Object) this.m_Button != (UnityEngine.Object) null && !this.m_Button.IsInteractable())
      return;
    if (this.m_eHint == EUIButtonHint.UIHIBtn || this.m_eHint == EUIButtonHint.UILeBtn)
      this.SetFadeOutObject(this.m_eHint);
    if ((bool) (UnityEngine.Object) UIButtonHint.DelayFadeOutHint)
      UIButtonHint.DelayFadeOutHint.ForceCloseHint();
    if (GUIManager.Instance.HintMaskObj.HideBtn.m_Handler != null)
      GUIManager.Instance.HintMaskObj.HideBtn.m_Handler.OnButtonClick((UIButton) null);
    this.PressPosition = !((UnityEngine.Object) this.GetCScrollRect() != (UnityEngine.Object) null) || !((UnityEngine.Object) this.GetCScrollRect().content != (UnityEngine.Object) null) ? this.transform.position : (Vector3) this.GetCScrollRect().content.anchoredPosition;
    this.BtnAction = UIButtonHint._BntAction.BtnDown;
    UIButtonHint.DelayFadeOutHint = this;
    GUIManager.Instance.HintMaskObj.Hide(this);
    this.IsValidClick = (byte) 1;
    if ((bool) (UnityEngine.Object) this.FadeOutCanvas)
    {
      this.bFadeOut = false;
      this.FadeOutCanvas.alpha = 1f;
    }
    switch (this.m_eHint)
    {
      case EUIButtonHint.UIHIBtn:
        UIHIBtn button = this.m_Button as UIHIBtn;
        if (!((UnityEngine.Object) button == (UnityEngine.Object) null))
        {
          switch ((eHeroOrItem) button.HeroOrItem)
          {
            case eHeroOrItem.Hero:
              GUIManager.Instance.m_SimpleItemInfo.ShowHero(this, button.HIID, (ushort) button.m_BtnID1, (ushort) button.m_BtnID2);
              break;
            case eHeroOrItem.Item:
              GUIManager.Instance.m_SimpleItemInfo.Show(this, button.HIID);
              break;
          }
        }
        else
          break;
        break;
      case EUIButtonHint.DownUpHandler:
      case EUIButtonHint.Slider:
        if (this.m_DownUpHandler != null)
        {
          this.m_DownUpHandler.OnButtonDown(this);
          break;
        }
        break;
      case EUIButtonHint.CountDown:
        this.m_Time = 0.0f;
        this.bCountDown = true;
        break;
      case EUIButtonHint.UILeBtn:
        if (this.m_DownUpHandler != null)
        {
          this.m_DownUpHandler.OnButtonDown(this);
          break;
        }
        break;
      case EUIButtonHint.UIArena_Hint:
        if (this.m_DownUpHandler != null)
        {
          this.m_DownUpHandler.OnButtonDown(this);
          break;
        }
        break;
    }
    if ((UnityEngine.Object) this.GetCScrollRect() != (UnityEngine.Object) null)
      this.GetCScrollRect().OnBeginDrag(eventData);
    if (!((UnityEngine.Object) this.GetScrollRect() != (UnityEngine.Object) null))
      return;
    this.GetScrollRect().OnBeginDrag(eventData);
  }

  private CScrollRect GetCScrollRect()
  {
    return this.ScrollID == (byte) 0 ? UIButtonHint.scrollRect : UIButtonHint.scrollRect2;
  }

  public ScrollRect GetScrollRect()
  {
    return this.ScrollID == (byte) 0 ? UIButtonHint.m_scrollRect : UIButtonHint.m_scrollRect2;
  }

  public void OnPointerUp(PointerEventData eventData)
  {
    if (this.BtnAction == UIButtonHint._BntAction.BtnNone)
      return;
    GUIManager.Instance.HintMaskObj.Show(this);
    GUIManager.Instance.HintMaskObj.HideBtn.m_Handler = (IUIButtonClickHandler) this;
  }

  public void OnCloseHint()
  {
    GUIManager.Instance.HintMaskObj.HideBtn.m_Handler = (IUIButtonClickHandler) null;
    if ((bool) (UnityEngine.Object) this.FadeOutCanvas)
    {
      this.bFadeOut = true;
      this.FadeTime = 0.0f;
    }
    switch (this.m_eHint)
    {
      case EUIButtonHint.UIHIBtn:
        UIHIBtn button = this.m_Button as UIHIBtn;
        if ((UnityEngine.Object) button == (UnityEngine.Object) null)
          break;
        switch ((eHeroOrItem) button.HeroOrItem)
        {
          case eHeroOrItem.Hero:
          case eHeroOrItem.Item:
            this.BtnAction = UIButtonHint._BntAction.BtnUp;
            return;
          default:
            return;
        }
      case EUIButtonHint.DownUpHandler:
      case EUIButtonHint.UILeBtn:
      case EUIButtonHint.UIArena_Hint:
        this.BtnAction = UIButtonHint._BntAction.BtnUp;
        break;
      case EUIButtonHint.Slider:
        if (this.m_DownUpHandler == null)
          break;
        this.m_DownUpHandler.OnButtonUp(this);
        break;
      case EUIButtonHint.CountDown:
        this.m_Time = 0.0f;
        this.bCountDown = false;
        this.BtnAction = UIButtonHint._BntAction.BtnUp;
        break;
    }
  }

  public void OnPointerExit(PointerEventData eventData)
  {
  }

  public void OnDrag(PointerEventData eventData)
  {
    if (this.IsValidClick == (byte) 0 && eventData.eligibleForClick)
      eventData.eligibleForClick = false;
    if ((UnityEngine.Object) this.GetCScrollRect() != (UnityEngine.Object) null)
      this.GetCScrollRect().OnDrag(eventData);
    if (!((UnityEngine.Object) this.GetScrollRect() != (UnityEngine.Object) null))
      return;
    this.GetScrollRect().OnDrag(eventData);
  }

  public void OnEndDrag(PointerEventData eventData)
  {
    if ((UnityEngine.Object) this.GetCScrollRect() != (UnityEngine.Object) null)
      this.GetCScrollRect().OnEndDrag(eventData);
    if (!((UnityEngine.Object) this.GetScrollRect() != (UnityEngine.Object) null))
      return;
    this.GetScrollRect().OnEndDrag(eventData);
  }

  public void OnButtonClick(UIButton sender)
  {
    if ((UnityEngine.Object) sender == (UnityEngine.Object) null)
      this.ForceCloseHint();
    else
      this.OnCloseHint();
  }

  public void GetTipPosition(
    RectTransform tipRect,
    UIButtonHint.ePosition position = UIButtonHint.ePosition.Original,
    Vector3? upsetPoint = null)
  {
    RectTransform transform = this.transform as RectTransform;
    if ((UnityEngine.Object) transform == (UnityEngine.Object) null)
      return;
    Vector2 size = GUIManager.Instance.m_MessageBoxLayer.rect.size;
    ((Transform) tipRect).position = ((Transform) transform).position;
    Vector3 anchoredPosition3D = tipRect.anchoredPosition3D;
    if (GUIManager.Instance.bOpenOnIPhoneX)
      size.x -= GUIManager.Instance.IPhoneX_DeltaX * 2f;
    if (this.m_ForcePos)
    {
      if (this.m_HintPosHandler == null)
      {
        anchoredPosition3D.x = this.m_HIBtnOffset.x;
        anchoredPosition3D.y = this.m_HIBtnOffset.y;
        anchoredPosition3D.z = 0.0f;
        tipRect.anchoredPosition3D = anchoredPosition3D;
        tipRect.anchoredPosition = this.m_HIBtnOffset;
      }
      else
        this.m_HintPosHandler.UpdatePos(transform, tipRect);
    }
    else
    {
      if (position == UIButtonHint.ePosition.Original)
      {
        anchoredPosition3D.x += transform.rect.x;
        anchoredPosition3D.y += transform.rect.y;
      }
      else
      {
        anchoredPosition3D.x -= tipRect.rect.width;
        anchoredPosition3D.y += transform.rect.y - transform.rect.height;
      }
      if (upsetPoint.HasValue)
        anchoredPosition3D += upsetPoint.Value;
      anchoredPosition3D.z = 0.0f;
      if ((double) anchoredPosition3D.x + (double) tipRect.sizeDelta.x > (double) size.x)
        anchoredPosition3D.x = size.x - tipRect.sizeDelta.x;
      if ((double) anchoredPosition3D.y + (double) transform.rect.height + (double) tipRect.sizeDelta.y <= 0.0)
        anchoredPosition3D.y += transform.rect.height + tipRect.sizeDelta.y;
      else if (-1.0 * (double) anchoredPosition3D.y + (double) tipRect.sizeDelta.y > (double) size.y)
        anchoredPosition3D.y = (float) (-1.0 * ((double) size.y - (double) tipRect.sizeDelta.y));
      tipRect.anchoredPosition3D = anchoredPosition3D;
    }
  }

  public void ForceCloseHint()
  {
    this.BtnAction = UIButtonHint._BntAction.BtnNone;
    this.bFadeOut = false;
    this.bCountDown = false;
    if (this.m_eHint == EUIButtonHint.UIHIBtn)
      GUIManager.Instance.m_SimpleItemInfo.Hide(this);
    if (this.m_DownUpHandler != null)
      this.m_DownUpHandler.OnButtonUp(this);
    UIButtonHint.DelayFadeOutHint = (UIButtonHint) null;
    GUIManager.Instance.HintMaskObj.HideBtn.m_Handler = (IUIButtonClickHandler) null;
  }

  public void SetFadeOutObject(EUIButtonHint HintEnum)
  {
    if (HintEnum == EUIButtonHint.UIHIBtn)
    {
      this._ControlFadeOut = ((Component) GUIManager.Instance.m_SimpleItemInfo.m_RectTransform).gameObject;
      this.FadeOutCanvas = GUIManager.Instance.m_SimpleItemInfo.Canvasgroup;
    }
    else
    {
      if (HintEnum != EUIButtonHint.UILeBtn)
        return;
      this._ControlFadeOut = ((Component) GUIManager.Instance.m_LordInfo.m_RectTransform).gameObject;
      this.FadeOutCanvas = GUIManager.Instance.m_LordInfo.Canvasgroup;
    }
  }

  private void Update()
  {
    if (!this.enabled || this.BtnAction == UIButtonHint._BntAction.BtnNone)
      return;
    if ((UnityEngine.Object) this.GetCScrollRect() != (UnityEngine.Object) null && this.GetCScrollRect().Get_Dragging())
    {
      if ((UnityEngine.Object) this.GetCScrollRect().content != (UnityEngine.Object) null)
      {
        if ((double) Math.Abs(this.PressPosition.y - this.GetCScrollRect().content.anchoredPosition.y) > 20.0)
        {
          this.IsValidClick = (byte) 0;
          this.ForceCloseHint();
        }
      }
      else if ((double) Math.Abs(this.PressPosition.y - this.transform.position.y) > 20.0)
      {
        this.IsValidClick = (byte) 0;
        this.ForceCloseHint();
      }
    }
    if ((UnityEngine.Object) this.GetScrollRect() != (UnityEngine.Object) null && (double) Math.Abs(this.PressPosition.y - this.transform.position.y) > 20.0)
    {
      this.IsValidClick = (byte) 0;
      this.ForceCloseHint();
    }
    if (this.BtnAction == UIButtonHint._BntAction.BtnUp)
    {
      if (!(bool) (UnityEngine.Object) this.FadeOutCanvas)
      {
        if (this.m_DownUpHandler != null)
          this.m_DownUpHandler.OnButtonUp(this);
        this.BtnAction = UIButtonHint._BntAction.BtnNone;
        UIButtonHint.DelayFadeOutHint = (UIButtonHint) null;
      }
      if (this.bFadeOut)
      {
        if ((double) this.FadeTime < (double) this.MaxFadeTime)
        {
          this.FadeOutCanvas.alpha = Mathf.Clamp((float) (1.0 - (double) this.FadeTime / (double) this.MaxFadeTime), 0.0f, 1f);
          this.FadeTime += Time.unscaledDeltaTime;
        }
        else
        {
          this.bFadeOut = false;
          if (this.m_DownUpHandler != null)
            this.m_DownUpHandler.OnButtonUp(this);
          this.FadeOutCanvas.alpha = 1f;
          UIButtonHint.DelayFadeOutHint = (UIButtonHint) null;
          this.BtnAction = UIButtonHint._BntAction.BtnNone;
          GUIManager.Instance.m_SimpleItemInfo.Hide(this);
          GUIManager.Instance.m_LordInfo.Hide(this);
          GUIManager.Instance.HintMaskObj.Hide(this);
        }
      }
    }
    if (this.m_eHint != EUIButtonHint.CountDown || !this.bCountDown)
      return;
    this.m_Time += Time.unscaledDeltaTime;
    if ((double) this.m_Time < (double) this.DelayTime)
      return;
    if (this.m_DownUpHandler != null)
    {
      this.m_DownUpHandler.OnButtonDown(this);
      GUIManager.Instance.HintMaskObj.Show(this);
      GUIManager.Instance.HintMaskObj.HideBtn.m_Handler = (IUIButtonClickHandler) this;
    }
    this.bCountDown = false;
    this.m_Time = 0.0f;
  }

  private enum _BntAction
  {
    BtnNone,
    BtnDown,
    BtnUp,
  }

  public enum ePosition
  {
    Original,
    LeftSide,
  }
}
