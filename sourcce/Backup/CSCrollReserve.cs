// Decompiled with JetBrains decompiler
// Type: CSCrollReserve
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class CSCrollReserve : EventReceive
{
  public CScrollRect cscrollRect;

  public CSCrollReserve(CScrollRect scrollRect) => this.cscrollRect = scrollRect;

  public override void OnBeginDrag(PointerEventData eventData)
  {
    this.cscrollRect.OnBeginDrag(eventData);
  }

  public override void OnDrag(PointerEventData eventData) => this.cscrollRect.OnDrag(eventData);

  public override void OnEndDrag(PointerEventData eventData)
  {
    this.cscrollRect.OnEndDrag(eventData);
  }
}
