// Decompiled with JetBrains decompiler
// Type: UIHIBtn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIHIBtn : 
  Selectable,
  IPointerUpHandler,
  IDragHandler,
  IPointerDownHandler,
  IPointerClickHandler,
  IEndDragHandler,
  IPointerExitHandler,
  IEventSystemHandler,
  IUIButtonScaleHandler2
{
  public IUIHIBtnClickHandler m_Handler;
  public IUIHIBtnUpDownHandler m_UpDownHandler;
  public IUIHIBtnDrag m_DHandler;
  public int m_BtnID1;
  public int m_BtnID2;
  public int m_BtnID3;
  public int m_BtnID4;
  public byte HeroOrItem;
  public ushort HIID;
  public Image HIImage;
  public Image ChipBookImage;
  public Image CircleImage;
  public Image HeroRankImage;
  public Image TextImage;
  public UIText LvOrNum;
  private UIText _PetRareText;
  private CString _PetRareStr = new CString(4);
  private e_EffectType m_EffectType;
  public byte SoundIndex;

  public UIText PetRareText
  {
    get => this._PetRareText;
    set => this._PetRareText = value;
  }

  public void SetPetRare(byte rare)
  {
    this._PetRareStr.ClearString();
    this._PetRareStr.IntToFormat((long) rare);
    this._PetRareStr.AppendFormat("{0}");
    this._PetRareText.text = this._PetRareStr.ToString();
    this._PetRareText.SetAllDirty();
    this._PetRareText.cachedTextGenerator.Invalidate();
  }

  private bool isPointerDown { get; set; }

  public void OnPointerClick(PointerEventData eventData)
  {
    if (this.m_EffectType != e_EffectType.e_Normal)
      return;
    this.ClickFunc();
  }

  public virtual void OnPointerUp(PointerEventData eventData)
  {
    base.OnPointerUp(eventData);
    if (!((UIBehaviour) this).IsActive() || !this.IsInteractable())
      return;
    this.isPointerDown = false;
    if (this.m_UpDownHandler == null)
      return;
    this.m_UpDownHandler.OnHIButtonUp(this);
  }

  public virtual void OnPointerDown(PointerEventData eventData)
  {
    base.OnPointerDown(eventData);
    if (!((UIBehaviour) this).IsActive() || !this.IsInteractable())
      return;
    if (((int) this.SoundIndex & 64) == 0 && ((UIBehaviour) this).IsActive() && this.IsInteractable())
      AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex) this.SoundIndex);
    this.isPointerDown = true;
    if (this.m_UpDownHandler == null)
      return;
    this.m_UpDownHandler.OnHIButtonDown(this);
  }

  public virtual void OnPointerExit(PointerEventData eventData)
  {
    base.OnPointerExit(eventData);
    if (!this.isPointerDown || this.m_DHandler == null)
      return;
    this.m_DHandler.OnHIButtonDragExit(this);
  }

  public void OnEndDrag(PointerEventData eventData)
  {
    if (this.m_DHandler == null)
      return;
    this.m_DHandler.OnHIButtonDragEnd(this);
  }

  public void OnDrag(PointerEventData eventData)
  {
    if (!this.isPointerDown || this.m_DHandler == null)
      return;
    this.m_DHandler.OnHIButtonDrag(this);
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.LvOrNum != (Object) null && ((Behaviour) this.LvOrNum).enabled)
    {
      ((Behaviour) this.LvOrNum).enabled = false;
      ((Behaviour) this.LvOrNum).enabled = true;
    }
    if (!((Object) this._PetRareText != (Object) null) || !((Behaviour) this._PetRareText).enabled)
      return;
    ((Behaviour) this._PetRareText).enabled = false;
    ((Behaviour) this._PetRareText).enabled = true;
  }

  private void ClickFunc()
  {
    if (!((UIBehaviour) this).IsActive() || !this.IsInteractable() || this.m_Handler == null)
      return;
    if (((int) this.SoundIndex & 64) > 0)
      AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex) ((int) this.SoundIndex & -65));
    this.m_Handler.OnHIButtonClick(this);
  }

  public void SetEffectType(e_EffectType EffectType) => this.m_EffectType = EffectType;

  public void OnFinish() => this.ClickFunc();
}
