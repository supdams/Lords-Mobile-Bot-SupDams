// Decompiled with JetBrains decompiler
// Type: WarControlPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class WarControlPanel : Image, IPointerUpHandler, IPointerDownHandler, IEventSystemHandler
{
  private WarManager WM;

  public WarManager warManager
  {
    set => this.WM = value;
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    if (this.WM == null || this.WM.m_WarState != WarManager.WarState.RUNNING)
      return;
    this.WM.checkPickHero(true);
  }

  public void OnPointerUp(PointerEventData eventData)
  {
  }
}
