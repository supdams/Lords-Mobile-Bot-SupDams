// Decompiled with JetBrains decompiler
// Type: UnityEngine.EventSystems.CusPointerInputModule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
namespace UnityEngine.EventSystems
{
  public abstract class CusPointerInputModule : BaseInputModule
  {
    public const int kMouseLeftId = -1;
    public const int kMouseRightId = -2;
    public const int kMouseMiddleId = -3;
    public const int kFakeTouchesId = -4;
    protected Dictionary<int, PointerEventData> m_PointerData = new Dictionary<int, PointerEventData>();
    protected RaycastResult? MaskRay;
    protected PointerEventData MaskEvent;
    private readonly CusPointerInputModule.MouseState m_MouseState = new CusPointerInputModule.MouseState();
    protected readonly CusPointerInputModule.MouseState m_MaskMouseState = new CusPointerInputModule.MouseState();

    protected bool GetPointerData(int id, out PointerEventData data, bool create)
    {
      if (this.m_PointerData.TryGetValue(id, out data) || !create)
        return false;
      data = new PointerEventData(this.eventSystem)
      {
        pointerId = id
      };
      this.m_PointerData.Add(id, data);
      return true;
    }

    protected void RemovePointerData(PointerEventData data)
    {
      this.m_PointerData.Remove(data.pointerId);
    }

    protected PointerEventData GetTouchPointerEventData(
      Touch input,
      out bool pressed,
      out bool released)
    {
      PointerEventData data;
      bool pointerData1 = this.GetPointerData(input.fingerId, out data, true);
      ((BaseEventData) data).Reset();
      pressed = pointerData1 || input.phase == TouchPhase.Began;
      released = input.phase == TouchPhase.Canceled || input.phase == TouchPhase.Ended;
      if (pointerData1)
        data.position = input.position;
      data.delta = !pressed ? input.position - data.position : Vector2.zero;
      data.position = input.position;
      data.button = (PointerEventData.InputButton) 0;
      this.eventSystem.RaycastAll(data, this.m_RaycastResultCache);
      RaycastResult firstRaycast = this.FindFirstRaycast(this.m_RaycastResultCache, 0);
      data.pointerCurrentRaycast = firstRaycast;
      this.m_RaycastResultCache.Clear();
      if (this.MaskRay.HasValue && this.MaskEvent == null)
      {
        bool pointerData2 = this.GetPointerData(999, out this.MaskEvent, true);
        ((BaseEventData) this.MaskEvent).Reset();
        pressed = pointerData2 || input.phase == TouchPhase.Began;
        released = input.phase == TouchPhase.Canceled || input.phase == TouchPhase.Ended;
        if (pointerData2)
          this.MaskEvent.position = input.position;
        this.MaskEvent.delta = !pressed ? input.position - this.MaskEvent.position : Vector2.zero;
        this.MaskEvent.position = input.position;
        this.MaskEvent.button = (PointerEventData.InputButton) 0;
        this.MaskEvent.pointerCurrentRaycast = this.MaskRay.Value;
      }
      return data;
    }

    private void CopyFromTo(PointerEventData from, PointerEventData to)
    {
      to.position = from.position;
      to.delta = from.delta;
      to.scrollDelta = from.scrollDelta;
      to.pointerCurrentRaycast = from.pointerCurrentRaycast;
      to.pointerEnter = from.pointerEnter;
    }

    protected static PointerEventData.FramePressState StateForMouseButton(int buttonId)
    {
      bool mouseButtonDown = Input.GetMouseButtonDown(buttonId);
      bool mouseButtonUp = Input.GetMouseButtonUp(buttonId);
      if (mouseButtonDown && mouseButtonUp)
        return (PointerEventData.FramePressState) 2;
      if (mouseButtonDown)
        return (PointerEventData.FramePressState) 0;
      return mouseButtonUp ? (PointerEventData.FramePressState) 1 : (PointerEventData.FramePressState) 3;
    }

    protected virtual CusPointerInputModule.MouseState GetMousePointerEventData()
    {
      PointerEventData data1;
      bool pointerData = this.GetPointerData(-1, out data1, true);
      ((BaseEventData) data1).Reset();
      if (pointerData)
        data1.position = (Vector2) Input.mousePosition;
      Vector2 mousePosition = (Vector2) Input.mousePosition;
      data1.delta = mousePosition - data1.position;
      data1.position = mousePosition;
      data1.scrollDelta = (Vector2) Input.mouseScrollDelta;
      data1.button = (PointerEventData.InputButton) 0;
      this.eventSystem.RaycastAll(data1, this.m_RaycastResultCache);
      RaycastResult firstRaycast = this.FindFirstRaycast(this.m_RaycastResultCache, 0);
      data1.pointerCurrentRaycast = firstRaycast;
      this.m_RaycastResultCache.Clear();
      PointerEventData data2;
      this.GetPointerData(-2, out data2, true);
      this.CopyFromTo(data1, data2);
      data2.button = (PointerEventData.InputButton) 1;
      PointerEventData data3;
      this.GetPointerData(-3, out data3, true);
      this.CopyFromTo(data1, data3);
      data3.button = (PointerEventData.InputButton) 2;
      this.m_MouseState.SetButtonState((PointerEventData.InputButton) 0, CusPointerInputModule.StateForMouseButton(0), data1);
      this.m_MouseState.SetButtonState((PointerEventData.InputButton) 1, CusPointerInputModule.StateForMouseButton(1), data2);
      this.m_MouseState.SetButtonState((PointerEventData.InputButton) 2, CusPointerInputModule.StateForMouseButton(2), data3);
      if (this.MaskRay.HasValue)
      {
        if (this.GetPointerData(999, out data1, true))
          data1.pointerCurrentRaycast = this.MaskRay.Value;
        this.GetPointerData(-2, out data2, true);
        this.CopyFromTo(data1, data2);
        data2.button = (PointerEventData.InputButton) 1;
        this.GetPointerData(-3, out data3, true);
        this.CopyFromTo(data1, data3);
        data3.button = (PointerEventData.InputButton) 2;
        this.m_MaskMouseState.SetButtonState((PointerEventData.InputButton) 0, CusPointerInputModule.StateForMouseButton(0), data1);
        this.m_MaskMouseState.SetButtonState((PointerEventData.InputButton) 1, CusPointerInputModule.StateForMouseButton(1), data2);
        this.m_MaskMouseState.SetButtonState((PointerEventData.InputButton) 2, CusPointerInputModule.StateForMouseButton(2), data3);
      }
      return this.m_MouseState;
    }

    protected unsafe RaycastResult FindFirstRaycast(List<RaycastResult> candidates, int id)
    {
      for (int index = 0; index < candidates.Count; ++index)
      {
        RaycastResult candidate1 = candidates[index];
        if (!((UnityEngine.Object) ((RaycastResult) ref candidate1).gameObject == (UnityEngine.Object) null))
        {
          RaycastResult candidate2 = candidates[index];
          string str = ((RaycastResult) ref candidate2).gameObject.name;
          char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
          if (*chPtr == '*')
          {
            this.MaskRay = new RaycastResult?(candidates[index]);
          }
          else
          {
            str = (string) null;
            if (id == 0)
              return candidates[index];
            --id;
          }
        }
      }
      return new RaycastResult();
    }

    protected PointerEventData GetLastPointerEventData(int id)
    {
      PointerEventData data;
      this.GetPointerData(id, out data, false);
      return data;
    }

    private static bool ShouldStartDrag(
      Vector2 pressPos,
      Vector2 currentPos,
      float threshold,
      bool useDragThreshold)
    {
      return !useDragThreshold || (double) (pressPos - currentPos).sqrMagnitude >= (double) threshold * (double) threshold;
    }

    protected virtual void ProcessMove(PointerEventData pointerEvent)
    {
      RaycastResult pointerCurrentRaycast = pointerEvent.pointerCurrentRaycast;
      GameObject gameObject = ((RaycastResult) ref pointerCurrentRaycast).gameObject;
      this.HandlePointerExitAndEnter(pointerEvent, gameObject);
    }

    protected virtual void ProcessDrag(PointerEventData pointerEvent)
    {
      bool flag = pointerEvent.IsPointerMoving();
      if (flag && (UnityEngine.Object) pointerEvent.pointerDrag != (UnityEngine.Object) null && !pointerEvent.dragging && CusPointerInputModule.ShouldStartDrag(pointerEvent.pressPosition, pointerEvent.position, (float) this.eventSystem.pixelDragThreshold, pointerEvent.useDragThreshold))
      {
        ExecuteEvents.Execute<IBeginDragHandler>(pointerEvent.pointerDrag, (BaseEventData) pointerEvent, ExecuteEvents.beginDragHandler);
        pointerEvent.dragging = true;
      }
      if (!pointerEvent.dragging || !flag || !((UnityEngine.Object) pointerEvent.pointerDrag != (UnityEngine.Object) null))
        return;
      if ((UnityEngine.Object) pointerEvent.pointerPress != (UnityEngine.Object) pointerEvent.pointerDrag)
      {
        ExecuteEvents.Execute<IPointerUpHandler>(pointerEvent.pointerPress, (BaseEventData) pointerEvent, ExecuteEvents.pointerUpHandler);
        pointerEvent.eligibleForClick = false;
        pointerEvent.pointerPress = (GameObject) null;
        pointerEvent.rawPointerPress = (GameObject) null;
      }
      ExecuteEvents.Execute<IDragHandler>(pointerEvent.pointerDrag, (BaseEventData) pointerEvent, ExecuteEvents.dragHandler);
    }

    public virtual bool IsPointerOverGameObject(int pointerId)
    {
      PointerEventData pointerEventData = this.GetLastPointerEventData(pointerId);
      return pointerEventData != null && (UnityEngine.Object) pointerEventData.pointerEnter != (UnityEngine.Object) null;
    }

    protected void ClearSelection()
    {
      BaseEventData baseEventData = this.GetBaseEventData();
      foreach (PointerEventData pointerEventData in this.m_PointerData.Values)
        this.HandlePointerExitAndEnter(pointerEventData, (GameObject) null);
      this.m_PointerData.Clear();
      this.eventSystem.SetSelectedGameObject((GameObject) null, baseEventData);
    }

    public virtual string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder("<b>Pointer Input Module of type: </b>" + (object) ((object) this).GetType());
      stringBuilder.AppendLine();
      foreach (KeyValuePair<int, PointerEventData> keyValuePair in this.m_PointerData)
      {
        if (keyValuePair.Value != null)
        {
          stringBuilder.AppendLine("<B>Pointer:</b> " + (object) keyValuePair.Key);
          stringBuilder.AppendLine(keyValuePair.Value.ToString());
        }
      }
      return stringBuilder.ToString();
    }

    protected void DeselectIfSelectionChanged(GameObject currentOverGo, BaseEventData pointerEvent)
    {
      if (!((UnityEngine.Object) ExecuteEvents.GetEventHandler<ISelectHandler>(currentOverGo) != (UnityEngine.Object) this.eventSystem.currentSelectedGameObject))
        return;
      this.eventSystem.SetSelectedGameObject((GameObject) null, pointerEvent);
    }

    protected class ButtonState
    {
      private PointerEventData.InputButton m_Button;
      private CusPointerInputModule.MouseButtonEventData m_EventData;

      public CusPointerInputModule.MouseButtonEventData eventData
      {
        get => this.m_EventData;
        set => this.m_EventData = value;
      }

      public PointerEventData.InputButton button
      {
        get => this.m_Button;
        set => this.m_Button = value;
      }
    }

    protected class MouseState
    {
      private List<CusPointerInputModule.ButtonState> m_TrackedButtons = new List<CusPointerInputModule.ButtonState>();

      public bool AnyPressesThisFrame()
      {
        for (int index = 0; index < this.m_TrackedButtons.Count; ++index)
        {
          if (this.m_TrackedButtons[index].eventData.PressedThisFrame())
            return true;
        }
        return false;
      }

      public bool AnyReleasesThisFrame()
      {
        for (int index = 0; index < this.m_TrackedButtons.Count; ++index)
        {
          if (this.m_TrackedButtons[index].eventData.ReleasedThisFrame())
            return true;
        }
        return false;
      }

      public CusPointerInputModule.ButtonState GetButtonState(
        PointerEventData.InputButton button,
        int id = 0)
      {
        CusPointerInputModule.ButtonState buttonState = (CusPointerInputModule.ButtonState) null;
        for (int index = 0; index < this.m_TrackedButtons.Count; ++index)
        {
          if (this.m_TrackedButtons[index].button == button)
          {
            if (id == 0)
            {
              buttonState = this.m_TrackedButtons[index];
              break;
            }
            --id;
            break;
          }
        }
        if (buttonState == null)
        {
          buttonState = new CusPointerInputModule.ButtonState()
          {
            button = button,
            eventData = new CusPointerInputModule.MouseButtonEventData()
          };
          this.m_TrackedButtons.Add(buttonState);
        }
        return buttonState;
      }

      public void SetButtonState(
        PointerEventData.InputButton button,
        PointerEventData.FramePressState stateForMouseButton,
        PointerEventData data)
      {
        CusPointerInputModule.ButtonState buttonState = this.GetButtonState(button);
        buttonState.eventData.buttonState = stateForMouseButton;
        buttonState.eventData.buttonData = data;
      }
    }

    public class MouseButtonEventData
    {
      public PointerEventData.FramePressState buttonState;
      public PointerEventData buttonData;

      public bool PressedThisFrame() => this.buttonState == null || this.buttonState == 2;

      public bool ReleasedThisFrame() => this.buttonState == 1 || this.buttonState == 2;
    }
  }
}
