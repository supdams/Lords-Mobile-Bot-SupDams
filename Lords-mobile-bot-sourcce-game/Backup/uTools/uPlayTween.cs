// Decompiled with JetBrains decompiler
// Type: uTools.uPlayTween
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
namespace uTools
{
  [AddComponentMenu("uTools/Internal/Play Tween(uTools)")]
  public class uPlayTween : 
    MonoBehaviour,
    IPointerUpHandler,
    IPointerDownHandler,
    IPointerClickHandler,
    IPointerExitHandler,
    IEventSystemHandler,
    IPointerEnterHandler,
    uIPointHandler
  {
    public uTweener tweenTarget;
    public PlayDirection playDirection = PlayDirection.Forward;
    public Trigger trigger = Trigger.OnPointerClick;

    private void Start()
    {
      if (!((Object) this.tweenTarget == (Object) null))
        return;
      this.tweenTarget = this.GetComponent<uTweener>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
      this.TriggerPlay(Trigger.OnPointerEnter);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      this.TriggerPlay(Trigger.OnPointerDown);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      this.TriggerPlay(Trigger.OnPointerClick);
    }

    public void OnPointerUp(PointerEventData eventData) => this.TriggerPlay(Trigger.OnPointerUp);

    public void OnPointerExit(PointerEventData eventData)
    {
      this.TriggerPlay(Trigger.OnPointerExit);
    }

    private void TriggerPlay(Trigger _trigger)
    {
      if (_trigger != this.trigger)
        return;
      this.Play();
    }

    private void Play()
    {
      if (this.playDirection == PlayDirection.Toggle)
        this.tweenTarget.Toggle();
      else
        this.tweenTarget.Play(this.playDirection);
    }
  }
}
