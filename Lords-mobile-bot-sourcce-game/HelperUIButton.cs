// Decompiled with JetBrains decompiler
// Type: HelperUIButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class HelperUIButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
  public IUIButtonClickHandler m_Handler;
  public int m_BtnID1;
  public int m_BtnID2;
  public UIButton Button;
  private Image Img;

  public void Start()
  {
    this.Button = this.gameObject.GetComponent<UIButton>();
    if ((Object) this.Button == (Object) null)
      this.Button = this.gameObject.AddComponent<UIButton>();
    this.Button.m_BtnID1 = this.m_BtnID1;
    this.Button.m_BtnID2 = this.m_BtnID2;
    this.Button.transition = (Selectable.Transition) 0;
    this.Img = this.transform.GetComponent<Image>();
  }

  public void OnPointerClick(PointerEventData eventData)
  {
    if (!this.enabled || this.m_Handler == null || (Object) this.Button == (Object) null || (Object) this.Img == (Object) null || !((Object) eventData.pointerEnter == (Object) ((Component) this.Img).gameObject))
      return;
    this.m_Handler.OnButtonClick(this.Button);
  }
}
