// Decompiled with JetBrains decompiler
// Type: uTools.uButtonScale
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
namespace uTools
{
  [AddComponentMenu("uTools/Tween/Button Scale(uTools)")]
  public class uButtonScale : 
    MonoBehaviour,
    IPointerUpHandler,
    IPointerDownHandler,
    IPointerClickHandler,
    IPointerExitHandler,
    IEventSystemHandler,
    IPointerEnterHandler,
    uIPointHandler,
    IUIButtonScaleHandler
  {
    public IUIButtonScaleHandler2 m_Handler;
    public RectTransform tweenTarget;
    public Vector3 down = new Vector3(1.2f, 1.2f, 1.2f);
    public float duration = 0.015f;
    private Vector3 mScale;
    private byte bPress;
    private static bool bLock;

    private void Start()
    {
      if ((Object) this.tweenTarget == (Object) null)
        this.tweenTarget = this.GetComponent<RectTransform>();
      this.CheckTargetScale();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      if (this.bPress != (byte) 1)
        return;
      this.Scale(this.mScale, 0.0f);
      this.ClearPara();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      if (uButtonScale.bLock && this.bPress != (byte) 0)
        return;
      this.Scale(this.down, 0.0f);
      this.bPress = (byte) 1;
      uButtonScale.bLock = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      if (uButtonScale.bLock && this.bPress == (byte) 0 || this.bPress != (byte) 1)
        return;
      this.Scale(this.mScale, 0.05f);
      this.bPress = (byte) 2;
    }

    public void CheckTargetScale()
    {
      if ((Object) this.tweenTarget == (Object) null)
        return;
      this.mScale = ((Transform) this.tweenTarget).localScale;
      if ((double) this.mScale.x >= 0.0)
        return;
      this.down.x = -this.down.x;
    }

    public void Reset()
    {
      if (this.bPress == (byte) 1)
        this.Scale(this.mScale, 0.0f);
      this.ClearPara();
    }

    private void Scale(Vector3 to, float spduration = 0)
    {
      uTweenScaleButton.Begin(((Component) this.tweenTarget).gameObject, ((Transform) this.tweenTarget).localScale, to, (double) spduration != 0.0 ? spduration : this.duration).m_Handler = (IUIButtonScaleHandler) this;
    }

    public void OnFinish()
    {
      if (this.bPress != (byte) 2)
        return;
      this.ClearPara();
      if (this.m_Handler == null)
        return;
      this.m_Handler.OnFinish();
    }

    public void ClearPara()
    {
      this.bPress = (byte) 0;
      uButtonScale.bLock = false;
    }
  }
}
