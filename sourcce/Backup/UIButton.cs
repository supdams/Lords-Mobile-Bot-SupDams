// Decompiled with JetBrains decompiler
// Type: UIButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIButton : 
  Selectable,
  IPointerDownHandler,
  IPointerClickHandler,
  IEventSystemHandler,
  IUIButtonScaleHandler2
{
  public IUIButtonClickHandler m_Handler;
  public int m_BtnID1;
  public int m_BtnID2;
  public int m_BtnID3;
  public int m_BtnID4;
  public e_BtnType m_BtnType;
  public Color NormalColor;
  public Color ChangeColor = new Color(0.898f, 0.0f, 0.3098f);
  public UIText m_Text;
  public e_EffectType m_EffectType;
  public byte SoundIndex;
  public int m_Tag1;
  public int m_Tag2;

  protected virtual void Start()
  {
    if (this.m_EffectType != e_EffectType.e_Scale)
      return;
    this.AddScaleComp();
  }

  public void OnPointerClick(PointerEventData eventData)
  {
    if (this.m_EffectType != e_EffectType.e_Normal)
      return;
    this.ClickFunc();
  }

  public void SetButtonEffectType(e_EffectType type)
  {
    if (type == this.m_EffectType)
      return;
    if (type == e_EffectType.e_Scale)
      this.AddScaleComp();
    this.m_EffectType = type;
  }

  private void AddScaleComp()
  {
    uButtonScale uButtonScale = ((Component) this).gameObject.GetComponent<uButtonScale>();
    if ((Object) uButtonScale == (Object) null)
      uButtonScale = ((Component) this).gameObject.AddComponent<uButtonScale>();
    uButtonScale.m_Handler = (IUIButtonScaleHandler2) this;
  }

  protected virtual void OnDisable()
  {
    base.OnDisable();
    uButtonScale component = ((Component) this).gameObject.GetComponent<uButtonScale>();
    if (!((Object) component != (Object) null))
      return;
    component.Reset();
  }

  public void ForTextChange(e_BtnType btnType)
  {
    if (btnType == this.m_BtnType)
      return;
    this.m_BtnType = btnType;
    if (btnType == e_BtnType.e_ChangeText)
    {
      ColorBlock colors = this.colors;
      ((ColorBlock) ref colors).normalColor = new Color(0.675f, 0.675f, 0.675f);
      ((ColorBlock) ref colors).highlightedColor = new Color(0.675f, 0.675f, 0.675f);
      this.colors = colors;
      if (!((Object) this.m_Text != (Object) null))
        return;
      this.NormalColor = ((Graphic) this.m_Text).color;
      ((Graphic) this.m_Text).color = this.ChangeColor;
    }
    else
    {
      ColorBlock colors = this.colors;
      ((ColorBlock) ref colors).normalColor = Color.white;
      ((ColorBlock) ref colors).highlightedColor = Color.white;
      this.colors = colors;
      if (!((Object) this.m_Text != (Object) null))
        return;
      ((Graphic) this.m_Text).color = this.NormalColor;
    }
  }

  private void ClickFunc()
  {
    if (!((UIBehaviour) this).IsActive() || !this.IsInteractable())
      return;
    if (((int) this.SoundIndex & 64) == 0)
      AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex) this.SoundIndex);
    else if (((int) this.SoundIndex & 64) > 0)
      AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex) ((int) this.SoundIndex & -65));
    if (this.m_Handler == null)
      return;
    this.m_Handler.OnButtonClick(this);
  }

  public void OnFinish() => this.ClickFunc();
}
