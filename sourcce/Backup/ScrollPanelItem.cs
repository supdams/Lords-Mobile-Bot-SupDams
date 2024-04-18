// Decompiled with JetBrains decompiler
// Type: ScrollPanelItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class ScrollPanelItem : Selectable, IPointerClickHandler, IEventSystemHandler
{
  public IScrollPanelItemHandler m_Handler;
  public IUIStateTransition m_StateTransitionHandler;
  public int m_BtnID1;
  public int m_BtnID2;
  public byte SoundIndex;

  public void OnPointerClick(PointerEventData eventData)
  {
    if (this.m_Handler == null)
      return;
    this.m_Handler.ButtonOnClick(this);
  }

  protected virtual void DoStateTransition(Selectable.SelectionState state, bool instant)
  {
    base.DoStateTransition(state, instant);
    if (this.m_StateTransitionHandler == null)
      return;
    this.m_StateTransitionHandler.OnStateTransition((byte) state, instant);
  }
}
