// Decompiled with JetBrains decompiler
// Type: UnityEngine.EventSystems.CusStandaloneInputModule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
namespace UnityEngine.EventSystems
{
  [AddComponentMenu("Event/Standalone Input Module")]
  public class CusStandaloneInputModule : CusPointerInputModule
  {
    private float m_NextAction;
    private Vector2 m_LastMousePosition;
    private Vector2 m_MousePosition;
    [SerializeField]
    private string m_HorizontalAxis = "Horizontal";
    [SerializeField]
    private string m_VerticalAxis = "Vertical";
    [SerializeField]
    private string m_SubmitButton = "Submit";
    [SerializeField]
    private string m_CancelButton = "Cancel";
    [SerializeField]
    private float m_InputActionsPerSecond = 10f;
    [SerializeField]
    private bool m_AllowActivationOnMobileDevice;

    protected CusStandaloneInputModule()
    {
    }

    [Obsolete("Mode is no longer needed on input module as it handles both mouse and keyboard simultaneously.", false)]
    public CusStandaloneInputModule.InputMode inputMode => CusStandaloneInputModule.InputMode.Mouse;

    public bool allowActivationOnMobileDevice
    {
      get => this.m_AllowActivationOnMobileDevice;
      set => this.m_AllowActivationOnMobileDevice = value;
    }

    public float inputActionsPerSecond
    {
      get => this.m_InputActionsPerSecond;
      set => this.m_InputActionsPerSecond = value;
    }

    public string horizontalAxis
    {
      get => this.m_HorizontalAxis;
      set => this.m_HorizontalAxis = value;
    }

    public string verticalAxis
    {
      get => this.m_VerticalAxis;
      set => this.m_VerticalAxis = value;
    }

    public string submitButton
    {
      get => this.m_SubmitButton;
      set => this.m_SubmitButton = value;
    }

    public string cancelButton
    {
      get => this.m_CancelButton;
      set => this.m_CancelButton = value;
    }

    public virtual void UpdateModule()
    {
      this.m_LastMousePosition = this.m_MousePosition;
      this.m_MousePosition = (Vector2) Input.mousePosition;
    }

    public virtual bool IsModuleSupported()
    {
      return this.m_AllowActivationOnMobileDevice || Input.mousePresent;
    }

    public virtual bool ShouldActivateModule()
    {
      return base.ShouldActivateModule() && Input.GetButtonDown(this.m_SubmitButton) | Input.GetButtonDown(this.m_CancelButton) | !Mathf.Approximately(Input.GetAxisRaw(this.m_HorizontalAxis), 0.0f) | !Mathf.Approximately(Input.GetAxisRaw(this.m_VerticalAxis), 0.0f) | (double) (this.m_MousePosition - this.m_LastMousePosition).sqrMagnitude > 0.0 | Input.GetMouseButtonDown(0);
    }

    public virtual void ActivateModule()
    {
      base.ActivateModule();
      this.m_MousePosition = (Vector2) Input.mousePosition;
      this.m_LastMousePosition = (Vector2) Input.mousePosition;
      GameObject selectedGameObject = this.eventSystem.currentSelectedGameObject;
      if ((UnityEngine.Object) selectedGameObject == (UnityEngine.Object) null)
        selectedGameObject = this.eventSystem.lastSelectedGameObject;
      if ((UnityEngine.Object) selectedGameObject == (UnityEngine.Object) null)
        selectedGameObject = this.eventSystem.firstSelectedGameObject;
      this.eventSystem.SetSelectedGameObject(selectedGameObject, this.GetBaseEventData());
    }

    public virtual void DeactivateModule()
    {
      base.DeactivateModule();
      this.ClearSelection();
    }

    public virtual void Process()
    {
      bool selectedObject = this.SendUpdateEventToSelectedObject();
      this.MaskRay = new RaycastResult?();
      if (this.eventSystem.sendNavigationEvents)
      {
        if (!selectedObject)
          selectedObject |= this.SendMoveEventToSelectedObject();
        if (!selectedObject)
          this.SendSubmitEventToSelectedObject();
      }
      this.ProcessMouseEvent();
    }

    private bool SendSubmitEventToSelectedObject()
    {
      if ((UnityEngine.Object) this.eventSystem.currentSelectedGameObject == (UnityEngine.Object) null)
        return false;
      BaseEventData baseEventData = this.GetBaseEventData();
      if (Input.GetButtonDown(this.m_SubmitButton))
        ExecuteEvents.Execute<ISubmitHandler>(this.eventSystem.currentSelectedGameObject, baseEventData, ExecuteEvents.submitHandler);
      if (Input.GetButtonDown(this.m_CancelButton))
        ExecuteEvents.Execute<ICancelHandler>(this.eventSystem.currentSelectedGameObject, baseEventData, ExecuteEvents.cancelHandler);
      return baseEventData.used;
    }

    private bool AllowMoveEventProcessing(float time)
    {
      return Input.GetButtonDown(this.m_HorizontalAxis) | Input.GetButtonDown(this.m_VerticalAxis) | (double) time > (double) this.m_NextAction;
    }

    private Vector2 GetRawMoveVector()
    {
      Vector2 zero = Vector2.zero with
      {
        x = Input.GetAxisRaw(this.m_HorizontalAxis),
        y = Input.GetAxisRaw(this.m_VerticalAxis)
      };
      if (Input.GetButtonDown(this.m_HorizontalAxis))
      {
        if ((double) zero.x < 0.0)
          zero.x = -1f;
        if ((double) zero.x > 0.0)
          zero.x = 1f;
      }
      if (Input.GetButtonDown(this.m_VerticalAxis))
      {
        if ((double) zero.y < 0.0)
          zero.y = -1f;
        if ((double) zero.y > 0.0)
          zero.y = 1f;
      }
      return zero;
    }

    private bool SendMoveEventToSelectedObject()
    {
      float unscaledTime = Time.unscaledTime;
      if (!this.AllowMoveEventProcessing(unscaledTime))
        return false;
      Vector2 rawMoveVector = this.GetRawMoveVector();
      AxisEventData axisEventData = this.GetAxisEventData(rawMoveVector.x, rawMoveVector.y, 0.6f);
      if (!Mathf.Approximately(axisEventData.moveVector.x, 0.0f) || !Mathf.Approximately(axisEventData.moveVector.y, 0.0f))
        ExecuteEvents.Execute<IMoveHandler>(this.eventSystem.currentSelectedGameObject, (BaseEventData) axisEventData, ExecuteEvents.moveHandler);
      this.m_NextAction = unscaledTime + 1f / this.m_InputActionsPerSecond;
      return ((BaseEventData) axisEventData).used;
    }

    private void ProcessMouseEvent()
    {
      CusPointerInputModule.MouseState pointerEventData = this.GetMousePointerEventData();
      bool pressed = pointerEventData.AnyPressesThisFrame();
      bool released = pointerEventData.AnyReleasesThisFrame();
      CusPointerInputModule.MouseButtonEventData eventData = pointerEventData.GetButtonState((PointerEventData.InputButton) 0).eventData;
      if (!CusStandaloneInputModule.UseMouse(pressed, released, eventData.buttonData))
        return;
      this.ProcessMousePress(eventData);
      this.ProcessMove(eventData.buttonData);
      this.ProcessDrag(eventData.buttonData);
      this.ProcessMousePress(pointerEventData.GetButtonState((PointerEventData.InputButton) 1).eventData);
      this.ProcessDrag(pointerEventData.GetButtonState((PointerEventData.InputButton) 1).eventData.buttonData);
      this.ProcessMousePress(pointerEventData.GetButtonState((PointerEventData.InputButton) 2).eventData);
      this.ProcessDrag(pointerEventData.GetButtonState((PointerEventData.InputButton) 2).eventData.buttonData);
      if (Mathf.Approximately(eventData.buttonData.scrollDelta.sqrMagnitude, 0.0f))
        return;
      RaycastResult pointerCurrentRaycast = eventData.buttonData.pointerCurrentRaycast;
      ExecuteEvents.ExecuteHierarchy<IScrollHandler>(ExecuteEvents.GetEventHandler<IScrollHandler>(((RaycastResult) ref pointerCurrentRaycast).gameObject), (BaseEventData) eventData.buttonData, ExecuteEvents.scrollHandler);
    }

    private static bool UseMouse(bool pressed, bool released, PointerEventData pointerData)
    {
      return pressed || released || pointerData.IsPointerMoving() || pointerData.IsScrolling();
    }

    private bool SendUpdateEventToSelectedObject()
    {
      if ((UnityEngine.Object) this.eventSystem.currentSelectedGameObject == (UnityEngine.Object) null)
        return false;
      BaseEventData baseEventData = this.GetBaseEventData();
      ExecuteEvents.Execute<IUpdateSelectedHandler>(this.eventSystem.currentSelectedGameObject, baseEventData, ExecuteEvents.updateSelectedHandler);
      return baseEventData.used;
    }

    private void ProcessMousePress(CusPointerInputModule.MouseButtonEventData data)
    {
      PointerEventData buttonData1 = data.buttonData;
      RaycastResult pointerCurrentRaycast1 = buttonData1.pointerCurrentRaycast;
      GameObject gameObject1 = ((RaycastResult) ref pointerCurrentRaycast1).gameObject;
      if (data.PressedThisFrame())
      {
        if (!UIHintMask.bPassThrough && this.MaskRay.HasValue && (UnityEngine.Object) gameObject1 != (UnityEngine.Object) null && gameObject1.name[0] != '~')
        {
          RaycastResult pointerCurrentRaycast2 = this.m_MaskMouseState.GetButtonState((PointerEventData.InputButton) 0).eventData.buttonData.pointerCurrentRaycast;
          if (((RaycastResult) ref pointerCurrentRaycast2).gameObject.activeInHierarchy)
            return;
        }
        buttonData1.eligibleForClick = true;
        buttonData1.delta = Vector2.zero;
        buttonData1.dragging = false;
        buttonData1.useDragThreshold = true;
        buttonData1.pressPosition = buttonData1.position;
        buttonData1.pointerPressRaycast = buttonData1.pointerCurrentRaycast;
        this.DeselectIfSelectionChanged(gameObject1, (BaseEventData) buttonData1);
        GameObject gameObject2 = ExecuteEvents.ExecuteHierarchy<IPointerDownHandler>(gameObject1, (BaseEventData) buttonData1, ExecuteEvents.pointerDownHandler);
        if ((UnityEngine.Object) gameObject2 == (UnityEngine.Object) null)
          gameObject2 = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject1);
        float unscaledTime = Time.unscaledTime;
        if ((UnityEngine.Object) gameObject2 == (UnityEngine.Object) buttonData1.lastPress)
        {
          if ((double) (unscaledTime - buttonData1.clickTime) < 0.30000001192092896)
            ++buttonData1.clickCount;
          else
            buttonData1.clickCount = 1;
          buttonData1.clickTime = unscaledTime;
        }
        else
          buttonData1.clickCount = 1;
        buttonData1.pointerPress = gameObject2;
        buttonData1.rawPointerPress = gameObject1;
        buttonData1.clickTime = unscaledTime;
        buttonData1.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(gameObject1);
        if ((UnityEngine.Object) buttonData1.pointerDrag != (UnityEngine.Object) null)
          ExecuteEvents.Execute<IInitializePotentialDragHandler>(buttonData1.pointerDrag, (BaseEventData) buttonData1, ExecuteEvents.initializePotentialDrag);
      }
      if (!data.ReleasedThisFrame())
        return;
      if (this.MaskRay.HasValue)
      {
        PointerEventData buttonData2 = this.m_MaskMouseState.GetButtonState((PointerEventData.InputButton) 0).eventData.buttonData;
        RaycastResult pointerCurrentRaycast3 = buttonData2.pointerCurrentRaycast;
        if (((RaycastResult) ref pointerCurrentRaycast3).gameObject.activeInHierarchy)
        {
          RaycastResult pointerCurrentRaycast4 = buttonData2.pointerCurrentRaycast;
          ExecuteEvents.Execute<IPointerClickHandler>(((RaycastResult) ref pointerCurrentRaycast4).gameObject, (BaseEventData) buttonData2, ExecuteEvents.pointerClickHandler);
          if (!UIHintMask.bPassThrough && (UnityEngine.Object) gameObject1 != (UnityEngine.Object) null && gameObject1.name[0] != '~')
          {
            buttonData1.eligibleForClick = false;
            buttonData1.pointerPress = (GameObject) null;
            buttonData1.rawPointerPress = (GameObject) null;
            buttonData1.dragging = false;
            buttonData1.pointerDrag = (GameObject) null;
            if (!((UnityEngine.Object) gameObject1 != (UnityEngine.Object) buttonData1.pointerEnter))
              return;
            this.HandlePointerExitAndEnter(buttonData1, (GameObject) null);
            this.HandlePointerExitAndEnter(buttonData1, gameObject1);
            return;
          }
        }
      }
      ExecuteEvents.Execute<IPointerUpHandler>(buttonData1.pointerPress, (BaseEventData) buttonData1, ExecuteEvents.pointerUpHandler);
      GameObject eventHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject1);
      if ((UnityEngine.Object) buttonData1.pointerPress == (UnityEngine.Object) eventHandler && buttonData1.eligibleForClick)
        ExecuteEvents.Execute<IPointerClickHandler>(buttonData1.pointerPress, (BaseEventData) buttonData1, ExecuteEvents.pointerClickHandler);
      else if ((UnityEngine.Object) buttonData1.pointerDrag != (UnityEngine.Object) null)
        ExecuteEvents.ExecuteHierarchy<IDropHandler>(gameObject1, (BaseEventData) buttonData1, ExecuteEvents.dropHandler);
      buttonData1.eligibleForClick = false;
      buttonData1.pointerPress = (GameObject) null;
      buttonData1.rawPointerPress = (GameObject) null;
      if ((UnityEngine.Object) buttonData1.pointerDrag != (UnityEngine.Object) null && buttonData1.dragging)
        ExecuteEvents.Execute<IEndDragHandler>(buttonData1.pointerDrag, (BaseEventData) buttonData1, ExecuteEvents.endDragHandler);
      buttonData1.dragging = false;
      buttonData1.pointerDrag = (GameObject) null;
      if (!((UnityEngine.Object) gameObject1 != (UnityEngine.Object) buttonData1.pointerEnter))
        return;
      this.HandlePointerExitAndEnter(buttonData1, (GameObject) null);
      this.HandlePointerExitAndEnter(buttonData1, gameObject1);
    }

    [Obsolete("Mode is no longer needed on input module as it handles both mouse and keyboard simultaneously.", false)]
    public enum InputMode
    {
      Mouse,
      Buttons,
    }
  }
}
