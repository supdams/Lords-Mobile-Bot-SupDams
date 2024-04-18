// Decompiled with JetBrains decompiler
// Type: uTools.uIPointHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine.EventSystems;

#nullable disable
namespace uTools
{
  public interface uIPointHandler : 
    IPointerUpHandler,
    IPointerDownHandler,
    IPointerClickHandler,
    IPointerExitHandler,
    IEventSystemHandler,
    IPointerEnterHandler
  {
    void OnPointerEnter(PointerEventData eventData);

    void OnPointerDown(PointerEventData eventData);

    void OnPointerClick(PointerEventData eventData);

    void OnPointerUp(PointerEventData eventData);

    void OnPointerExit(PointerEventData eventData);
  }
}
