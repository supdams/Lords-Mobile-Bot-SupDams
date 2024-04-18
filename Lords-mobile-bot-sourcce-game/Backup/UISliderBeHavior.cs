// Decompiled with JetBrains decompiler
// Type: UISliderBeHavior
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UISliderBeHavior : 
  MonoBehaviour,
  IPointerUpHandler,
  IDragHandler,
  IPointerDownHandler,
  IPointerExitHandler,
  IEventSystemHandler
{
  public Selectable m_Button;
  public MonoBehaviour m_Handler;

  private void Awake() => this.m_Button = this.GetComponent<Selectable>();

  public void OnPointerDown(PointerEventData eventData)
  {
    if (!this.enabled || !this.gameObject.activeInHierarchy || (Object) this.m_Button != (Object) null && !this.m_Button.IsInteractable() || !((Object) this.m_Handler != (Object) null) || !(this.m_Handler is IUISliderBehavior handler))
      return;
    handler.OnButtonDown(this.m_Button as UIButton);
  }

  public void OnPointerUp(PointerEventData eventData)
  {
    if (!this.enabled || !this.gameObject.activeInHierarchy || (Object) this.m_Button != (Object) null && !this.m_Button.IsInteractable() || !((Object) this.m_Handler != (Object) null) || !(this.m_Handler is IUISliderBehavior handler))
      return;
    handler.OnButtonUp(this.m_Button as UIButton);
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    if (!((Object) this.m_Handler != (Object) null) || !(this.m_Handler is IUISliderBehavior handler))
      return;
    handler.OnButtonUp(this.m_Button as UIButton);
  }

  public void OnDrag(PointerEventData eventData)
  {
  }
}
