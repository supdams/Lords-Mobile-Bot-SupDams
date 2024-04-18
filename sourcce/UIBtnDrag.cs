// Decompiled with JetBrains decompiler
// Type: UIBtnDrag
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
public class UIBtnDrag : 
  MonoBehaviour,
  IPointerUpHandler,
  IDragHandler,
  IPointerDownHandler,
  IEventSystemHandler
{
  public RectTransform mHero;
  public Quaternion CameraQuaternion = Quaternion.identity;
  public float tmpX;

  public void ReSetHero()
  {
    this.tmpX = 0.0f;
    this.CameraQuaternion.eulerAngles = new Vector3(0.0f, this.tmpX, 0.0f);
    ((Transform) this.mHero).localRotation = this.CameraQuaternion;
  }

  public void OnPointerDown(PointerEventData eventData)
  {
  }

  public void OnPointerUp(PointerEventData eventData)
  {
  }

  public virtual void OnDrag(PointerEventData eventData)
  {
    if (!GUIManager.Instance.IsArabic)
      this.tmpX -= eventData.delta.x / 2f;
    else
      this.tmpX += eventData.delta.x / 2f;
    this.CameraQuaternion.eulerAngles = new Vector3(0.0f, this.tmpX, 0.0f);
    ((Transform) this.mHero).localRotation = this.CameraQuaternion;
  }

  private void Start()
  {
    this.tmpX = 0.0f;
    this.CameraQuaternion.eulerAngles = Vector3.zero;
  }

  private void Update()
  {
  }
}
