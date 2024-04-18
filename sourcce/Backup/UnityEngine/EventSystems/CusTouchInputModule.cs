// Decompiled with JetBrains decompiler
// Type: UnityEngine.EventSystems.CusTouchInputModule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;

#nullable disable
namespace UnityEngine.EventSystems
{
  [AddComponentMenu("Event/Touch Input Module")]
  public class CusTouchInputModule : CusPointerInputModule
  {
    private Vector2 m_LastMousePosition;
    private Vector2 m_MousePosition;
    [SerializeField]
    private bool m_AllowActivationOnStandalone;

    protected CusTouchInputModule()
    {
    }

    public bool allowActivationOnStandalone
    {
      get => this.m_AllowActivationOnStandalone;
      set => this.m_AllowActivationOnStandalone = value;
    }

    public virtual void UpdateModule()
    {
      this.m_LastMousePosition = this.m_MousePosition;
      this.m_MousePosition = (Vector2) Input.mousePosition;
    }

    public virtual bool IsModuleSupported()
    {
      return this.m_AllowActivationOnStandalone || Input.touchSupported;
    }

    public virtual bool ShouldActivateModule()
    {
      if (!base.ShouldActivateModule())
        return false;
      if (this.UseFakeInput())
        return Input.GetMouseButtonDown(0) | (double) (this.m_MousePosition - this.m_LastMousePosition).sqrMagnitude > 0.0;
      for (int index = 0; index < Input.touchCount; ++index)
      {
        Touch touch = Input.GetTouch(index);
        if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
          return true;
      }
      return false;
    }

    private bool UseFakeInput() => !Input.touchSupported;

    public virtual void Process()
    {
      if (this.UseFakeInput())
        this.FakeTouches();
      else
        this.ProcessTouchEvents();
    }

    private void FakeTouches()
    {
      CusPointerInputModule.MouseButtonEventData eventData = this.GetMousePointerEventData().GetButtonState((PointerEventData.InputButton) 0).eventData;
      if (eventData.PressedThisFrame())
        eventData.buttonData.delta = Vector2.zero;
      this.ProcessTouchPress(eventData.buttonData, eventData.PressedThisFrame(), eventData.ReleasedThisFrame());
      if (!Input.GetMouseButton(0))
        return;
      this.ProcessMove(eventData.buttonData);
      this.ProcessDrag(eventData.buttonData);
    }

    private void ProcessTouchEvents()
    {
      this.MaskEvent = (PointerEventData) null;
      this.MaskRay = new RaycastResult?();
      for (int index = 0; index < Input.touchCount; ++index)
      {
        bool pressed;
        bool released;
        PointerEventData pointerEventData = this.GetTouchPointerEventData(Input.GetTouch(index), out pressed, out released);
        this.ProcessTouchPress(pointerEventData, pressed, released);
        if (!released)
        {
          this.ProcessMove(pointerEventData);
          this.ProcessDrag(pointerEventData);
        }
        else
          this.RemovePointerData(pointerEventData);
      }
    }

    private void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released)
    {
      RaycastResult pointerCurrentRaycast1 = pointerEvent.pointerCurrentRaycast;
      GameObject gameObject1 = ((RaycastResult) ref pointerCurrentRaycast1).gameObject;
      if (pressed)
      {
        if (!UIHintMask.bPassThrough && this.MaskRay.HasValue && this.MaskEvent != null && (Object) gameObject1 != (Object) null && gameObject1.name[0] != '~')
          return;
        pointerEvent.eligibleForClick = true;
        pointerEvent.delta = Vector2.zero;
        pointerEvent.dragging = false;
        pointerEvent.useDragThreshold = true;
        pointerEvent.pressPosition = pointerEvent.position;
        pointerEvent.pointerPressRaycast = pointerEvent.pointerCurrentRaycast;
        this.DeselectIfSelectionChanged(gameObject1, (BaseEventData) pointerEvent);
        if ((Object) pointerEvent.pointerEnter != (Object) gameObject1)
        {
          this.HandlePointerExitAndEnter(pointerEvent, gameObject1);
          pointerEvent.pointerEnter = gameObject1;
        }
        GameObject gameObject2 = ExecuteEvents.ExecuteHierarchy<IPointerDownHandler>(gameObject1, (BaseEventData) pointerEvent, ExecuteEvents.pointerDownHandler);
        if ((Object) gameObject2 == (Object) null)
          gameObject2 = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject1);
        float unscaledTime = Time.unscaledTime;
        if ((Object) gameObject2 == (Object) pointerEvent.lastPress)
        {
          if ((double) (unscaledTime - pointerEvent.clickTime) < 0.30000001192092896)
            ++pointerEvent.clickCount;
          else
            pointerEvent.clickCount = 1;
          pointerEvent.clickTime = unscaledTime;
        }
        else
          pointerEvent.clickCount = 1;
        pointerEvent.pointerPress = gameObject2;
        pointerEvent.rawPointerPress = gameObject1;
        pointerEvent.clickTime = unscaledTime;
        pointerEvent.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(gameObject1);
        if ((Object) pointerEvent.pointerDrag != (Object) null)
          ExecuteEvents.Execute<IInitializePotentialDragHandler>(pointerEvent.pointerDrag, (BaseEventData) pointerEvent, ExecuteEvents.initializePotentialDrag);
      }
      if (!released)
        return;
      if (this.MaskRay.HasValue)
      {
        RaycastResult pointerCurrentRaycast2 = this.MaskEvent.pointerCurrentRaycast;
        ExecuteEvents.Execute<IPointerClickHandler>(((RaycastResult) ref pointerCurrentRaycast2).gameObject, (BaseEventData) this.MaskEvent, ExecuteEvents.pointerClickHandler);
        if (!UIHintMask.bPassThrough && (Object) gameObject1 != (Object) null && gameObject1.name[0] != '~')
        {
          pointerEvent.eligibleForClick = false;
          pointerEvent.pointerPress = (GameObject) null;
          pointerEvent.rawPointerPress = (GameObject) null;
          pointerEvent.dragging = false;
          pointerEvent.pointerDrag = (GameObject) null;
          pointerEvent.pointerEnter = (GameObject) null;
          return;
        }
      }
      ExecuteEvents.Execute<IPointerUpHandler>(pointerEvent.pointerPress, (BaseEventData) pointerEvent, ExecuteEvents.pointerUpHandler);
      GameObject eventHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject1);
      if ((Object) pointerEvent.pointerPress == (Object) eventHandler && pointerEvent.eligibleForClick)
        ExecuteEvents.Execute<IPointerClickHandler>(pointerEvent.pointerPress, (BaseEventData) pointerEvent, ExecuteEvents.pointerClickHandler);
      else if ((Object) pointerEvent.pointerDrag != (Object) null)
        ExecuteEvents.ExecuteHierarchy<IDropHandler>(gameObject1, (BaseEventData) pointerEvent, ExecuteEvents.dropHandler);
      pointerEvent.eligibleForClick = false;
      pointerEvent.pointerPress = (GameObject) null;
      pointerEvent.rawPointerPress = (GameObject) null;
      if ((Object) pointerEvent.pointerDrag != (Object) null && pointerEvent.dragging)
        ExecuteEvents.Execute<IEndDragHandler>(pointerEvent.pointerDrag, (BaseEventData) pointerEvent, ExecuteEvents.endDragHandler);
      pointerEvent.dragging = false;
      pointerEvent.pointerDrag = (GameObject) null;
      if ((Object) pointerEvent.pointerDrag != (Object) null)
        ExecuteEvents.Execute<IEndDragHandler>(pointerEvent.pointerDrag, (BaseEventData) pointerEvent, ExecuteEvents.endDragHandler);
      pointerEvent.pointerDrag = (GameObject) null;
      ExecuteEvents.ExecuteHierarchy<IPointerExitHandler>(pointerEvent.pointerEnter, (BaseEventData) pointerEvent, ExecuteEvents.pointerExitHandler);
      pointerEvent.pointerEnter = (GameObject) null;
    }

    public virtual void DeactivateModule()
    {
      base.DeactivateModule();
      this.ClearSelection();
    }

    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendLine(!this.UseFakeInput() ? "Input: Touch" : "Input: Faked");
      if (this.UseFakeInput())
      {
        PointerEventData pointerEventData = this.GetLastPointerEventData(-1);
        if (pointerEventData != null)
          stringBuilder.AppendLine(pointerEventData.ToString());
      }
      else
      {
        foreach (KeyValuePair<int, PointerEventData> keyValuePair in this.m_PointerData)
          stringBuilder.AppendLine(keyValuePair.ToString());
      }
      return stringBuilder.ToString();
    }
  }
}
