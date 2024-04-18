// Decompiled with JetBrains decompiler
// Type: uTools.uDragObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
namespace uTools
{
  [AddComponentMenu("uTools/Internal/Drag Object(uTools)")]
  public class uDragObject : MonoBehaviour, IDragHandler, IEventSystemHandler
  {
    public RectTransform target;

    private RectTransform cacheTarget
    {
      get
      {
        if ((Object) this.target == (Object) null)
          this.target = this.GetComponent<RectTransform>();
        return this.target;
      }
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
      Vector3 localPosition = ((Transform) this.cacheTarget).localPosition;
      Vector3 to = localPosition + new Vector3(eventData.delta.x, eventData.delta.y, 0.0f);
      uTweenPosition.Begin(this.gameObject, localPosition, to, 0.02f);
    }
  }
}
