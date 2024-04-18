// Decompiled with JetBrains decompiler
// Type: EventPatchery
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class EventPatchery : 
  MonoBehaviour,
  IBeginDragHandler,
  IDragHandler,
  IEndDragHandler,
  IPointerExitHandler,
  IEventSystemHandler
{
  private EventReceive ReceiveObj;

  void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
  {
    if (this.ReceiveObj == null)
      return;
    this.ReceiveObj.OnPointerExit(eventData);
  }

  void IDragHandler.OnDrag(PointerEventData eventData)
  {
    if (this.ReceiveObj == null)
      return;
    this.ReceiveObj.OnDrag(eventData);
  }

  void IEndDragHandler.OnEndDrag(PointerEventData eventData)
  {
    if (this.ReceiveObj == null)
      return;
    this.ReceiveObj.OnEndDrag(eventData);
  }

  void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
  {
    if (this.ReceiveObj == null)
      return;
    this.ReceiveObj.OnBeginDrag(eventData);
  }

  public void SetEvnetObj(CScrollRect Obj)
  {
    this.ReceiveObj = (EventReceive) new CSCrollReserve(Obj);
  }
}
