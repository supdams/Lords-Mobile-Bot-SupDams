// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.CSlider
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#nullable disable
namespace UnityEngine.UI
{
  [RequireComponent(typeof (RectTransform))]
  public class CSlider : 
    Selectable,
    IDragHandler,
    IInitializePotentialDragHandler,
    ICanvasElement,
    IEventSystemHandler
  {
    [SerializeField]
    private RectTransform m_FillRect;
    [SerializeField]
    private RectTransform m_HandleRect;
    [SerializeField]
    [Space(6f)]
    private CSlider.Direction m_Direction;
    [SerializeField]
    private double m_MinValue;
    [SerializeField]
    private double m_MaxValue = 1.0;
    [SerializeField]
    private bool m_WholeNumbers;
    [SerializeField]
    private double m_Value = 1.0;
    [Space(6f)]
    [SerializeField]
    private CSlider.SliderEvent m_OnValueChanged = new CSlider.SliderEvent();
    private Image m_FillImage;
    private Transform m_FillTransform;
    private RectTransform m_FillContainerRect;
    private Transform m_HandleTransform;
    private RectTransform m_HandleContainerRect;
    private Vector2 m_Offset = Vector2.zero;
    private DrivenRectTransformTracker m_Tracker;

    protected CSlider()
    {
    }

    public RectTransform fillRect
    {
      get => this.m_FillRect;
      set
      {
        if (!SetPropertyUtility.SetClass<RectTransform>(ref this.m_FillRect, value))
          return;
        this.UpdateCachedReferences();
        this.UpdateVisuals();
      }
    }

    public RectTransform handleRect
    {
      get => this.m_HandleRect;
      set
      {
        if (!SetPropertyUtility.SetClass<RectTransform>(ref this.m_HandleRect, value))
          return;
        this.UpdateCachedReferences();
        this.UpdateVisuals();
      }
    }

    public CSlider.Direction direction
    {
      get => this.m_Direction;
      set
      {
        if (!SetPropertyUtility.SetStruct<CSlider.Direction>(ref this.m_Direction, value))
          return;
        this.UpdateVisuals();
      }
    }

    public double minValue
    {
      get => this.m_MinValue;
      set
      {
        if (!SetPropertyUtility.SetStruct<double>(ref this.m_MinValue, value))
          return;
        this.Set(this.m_Value);
        this.UpdateVisuals();
      }
    }

    public double maxValue
    {
      get => this.m_MaxValue;
      set
      {
        if (!SetPropertyUtility.SetStruct<double>(ref this.m_MaxValue, value))
          return;
        this.Set(this.m_Value);
        this.UpdateVisuals();
      }
    }

    public bool wholeNumbers
    {
      get => this.m_WholeNumbers;
      set
      {
        if (!SetPropertyUtility.SetStruct<bool>(ref this.m_WholeNumbers, value))
          return;
        this.Set(this.m_Value);
        this.UpdateVisuals();
      }
    }

    public double value
    {
      get => this.wholeNumbers ? Math.Round(this.m_Value) : this.m_Value;
      set => this.Set(value);
    }

    public double normalizedValue
    {
      get
      {
        return Mathf.Approximately((float) this.minValue, (float) this.maxValue) ? 0.0 : (double) Mathf.InverseLerp((float) this.minValue, (float) this.maxValue, (float) this.value);
      }
      set
      {
        if (value < 0.0)
          this.value = this.minValue;
        else if (value > 1.0)
          this.value = this.maxValue;
        else
          this.value = this.minValue + value * (this.maxValue - this.minValue);
      }
    }

    public CSlider.SliderEvent onValueChanged
    {
      get => this.m_OnValueChanged;
      set => this.m_OnValueChanged = value;
    }

    private double stepSize => this.wholeNumbers ? 1.0 : (this.maxValue - this.minValue) * 0.1;

    public virtual void Rebuild(CanvasUpdate executing)
    {
    }

    protected virtual void OnEnable()
    {
      base.OnEnable();
      this.UpdateCachedReferences();
      this.Set(this.m_Value, false);
      this.UpdateVisuals();
    }

    protected virtual void OnDisable()
    {
      this.m_Tracker.Clear();
      base.OnDisable();
    }

    private void UpdateCachedReferences()
    {
      if ((bool) (UnityEngine.Object) this.m_FillRect)
      {
        this.m_FillTransform = ((Component) this.m_FillRect).transform;
        this.m_FillImage = ((Component) this.m_FillRect).GetComponent<Image>();
        if ((UnityEngine.Object) this.m_FillTransform.parent != (UnityEngine.Object) null)
          this.m_FillContainerRect = this.m_FillTransform.parent.GetComponent<RectTransform>();
      }
      else
      {
        this.m_FillContainerRect = (RectTransform) null;
        this.m_FillImage = (Image) null;
      }
      if ((bool) (UnityEngine.Object) this.m_HandleRect)
      {
        this.m_HandleTransform = ((Component) this.m_HandleRect).transform;
        if (!((UnityEngine.Object) this.m_HandleTransform.parent != (UnityEngine.Object) null))
          return;
        this.m_HandleContainerRect = this.m_HandleTransform.parent.GetComponent<RectTransform>();
      }
      else
        this.m_HandleContainerRect = (RectTransform) null;
    }

    private void Set(double input) => this.Set(input, true);

    private void Set(double input, bool sendCallback)
    {
      double a = input >= this.minValue ? (input <= this.maxValue ? input : this.maxValue) : this.minValue;
      if (this.wholeNumbers)
        a = Math.Round(a);
      if (this.m_Value == a)
        return;
      this.m_Value = a;
      this.UpdateVisuals();
      if (!sendCallback)
        return;
      this.m_OnValueChanged.Invoke(a);
    }

    protected virtual void OnRectTransformDimensionsChange()
    {
      ((UIBehaviour) this).OnRectTransformDimensionsChange();
      if (!((UIBehaviour) this).IsActive())
        return;
      this.UpdateVisuals();
    }

    private CSlider.Axis axis
    {
      get
      {
        return this.m_Direction == CSlider.Direction.LeftToRight || this.m_Direction == CSlider.Direction.RightToLeft ? CSlider.Axis.Horizontal : CSlider.Axis.Vertical;
      }
    }

    private bool reverseValue
    {
      get
      {
        return this.m_Direction == CSlider.Direction.RightToLeft || this.m_Direction == CSlider.Direction.TopToBottom;
      }
    }

    private void UpdateVisuals()
    {
      this.m_Tracker.Clear();
      if ((UnityEngine.Object) this.m_FillContainerRect != (UnityEngine.Object) null)
      {
        this.m_Tracker.Add((UnityEngine.Object) this, this.m_FillRect, (DrivenTransformProperties) 3840);
        Vector2 zero = Vector2.zero;
        Vector2 one = Vector2.one;
        if ((UnityEngine.Object) this.m_FillImage != (UnityEngine.Object) null && this.m_FillImage.type == 3)
          this.m_FillImage.fillAmount = (float) this.normalizedValue;
        else if (this.reverseValue)
          zero[(int) this.axis] = 1f - (float) this.normalizedValue;
        else
          one[(int) this.axis] = (float) this.normalizedValue;
        this.m_FillRect.anchorMin = zero;
        this.m_FillRect.anchorMax = one;
      }
      if (!((UnityEngine.Object) this.m_HandleContainerRect != (UnityEngine.Object) null))
        return;
      this.m_Tracker.Add((UnityEngine.Object) this, this.m_HandleRect, (DrivenTransformProperties) 3840);
      Vector2 zero1 = Vector2.zero;
      Vector2 one1 = Vector2.one;
      ref Vector2 local = ref zero1;
      int axis = (int) this.axis;
      float num1 = !this.reverseValue ? (float) this.normalizedValue : (float) (1.0 - this.normalizedValue);
      one1[(int) this.axis] = num1;
      double num2 = (double) num1;
      local[axis] = (float) num2;
      this.m_HandleRect.anchorMin = zero1;
      this.m_HandleRect.anchorMax = one1;
    }

    private void UpdateDrag(PointerEventData eventData, Camera cam)
    {
      RectTransform rectTransform = this.m_HandleContainerRect ?? this.m_FillContainerRect;
      Vector2 vector2;
      if (!((UnityEngine.Object) rectTransform != (UnityEngine.Object) null) || (double) rectTransform.rect.size[(int) this.axis] <= 0.0 || !RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, cam, ref vector2))
        return;
      vector2 -= rectTransform.rect.position;
      double num = (double) (vector2 - this.m_Offset)[(int) this.axis] >= 0.0 ? ((double) (vector2 - this.m_Offset)[(int) this.axis] <= (double) rectTransform.rect.size[(int) this.axis] ? (double) (vector2 - this.m_Offset)[(int) this.axis] / (double) rectTransform.rect.size[(int) this.axis] : (double) rectTransform.rect.size[(int) this.axis]) : 0.0;
      this.normalizedValue = !this.reverseValue ? num : 1.0 - num;
    }

    private bool MayDrag(PointerEventData eventData)
    {
      return ((UIBehaviour) this).IsActive() && this.IsInteractable() && eventData.button == 0;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
      if (!this.MayDrag(eventData))
        return;
      base.OnPointerDown(eventData);
      this.m_Offset = Vector2.zero;
      if ((UnityEngine.Object) this.m_HandleContainerRect != (UnityEngine.Object) null && RectTransformUtility.RectangleContainsScreenPoint(this.m_HandleRect, eventData.position, eventData.enterEventCamera))
      {
        Vector2 vector2;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(this.m_HandleRect, eventData.position, eventData.pressEventCamera, ref vector2))
          return;
        this.m_Offset = vector2;
      }
      else
        this.UpdateDrag(eventData, eventData.pressEventCamera);
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
      if (!this.MayDrag(eventData))
        return;
      this.UpdateDrag(eventData, eventData.pressEventCamera);
    }

    public virtual void OnMove(AxisEventData eventData)
    {
      if (!((UIBehaviour) this).IsActive() || !this.IsInteractable())
      {
        base.OnMove(eventData);
      }
      else
      {
        switch ((int) eventData.moveDir)
        {
          case 0:
            if (this.axis == CSlider.Axis.Horizontal && (UnityEngine.Object) this.FindSelectableOnLeft() == (UnityEngine.Object) null)
            {
              this.Set(!this.reverseValue ? this.value - this.stepSize : this.value + this.stepSize);
              break;
            }
            base.OnMove(eventData);
            break;
          case 1:
            if (this.axis == CSlider.Axis.Vertical && (UnityEngine.Object) this.FindSelectableOnUp() == (UnityEngine.Object) null)
            {
              this.Set(!this.reverseValue ? this.value + this.stepSize : this.value - this.stepSize);
              break;
            }
            base.OnMove(eventData);
            break;
          case 2:
            if (this.axis == CSlider.Axis.Horizontal && (UnityEngine.Object) this.FindSelectableOnRight() == (UnityEngine.Object) null)
            {
              this.Set(!this.reverseValue ? this.value + this.stepSize : this.value - this.stepSize);
              break;
            }
            base.OnMove(eventData);
            break;
          case 3:
            if (this.axis == CSlider.Axis.Vertical && (UnityEngine.Object) this.FindSelectableOnDown() == (UnityEngine.Object) null)
            {
              this.Set(!this.reverseValue ? this.value - this.stepSize : this.value + this.stepSize);
              break;
            }
            base.OnMove(eventData);
            break;
        }
      }
    }

    public virtual Selectable FindSelectableOnLeft()
    {
      Navigation navigation = this.navigation;
      return ((Navigation) ref navigation).mode == 3 && this.axis == CSlider.Axis.Horizontal ? (Selectable) null : base.FindSelectableOnLeft();
    }

    public virtual Selectable FindSelectableOnRight()
    {
      Navigation navigation = this.navigation;
      return ((Navigation) ref navigation).mode == 3 && this.axis == CSlider.Axis.Horizontal ? (Selectable) null : base.FindSelectableOnRight();
    }

    public virtual Selectable FindSelectableOnUp()
    {
      Navigation navigation = this.navigation;
      return ((Navigation) ref navigation).mode == 3 && this.axis == CSlider.Axis.Vertical ? (Selectable) null : base.FindSelectableOnUp();
    }

    public virtual Selectable FindSelectableOnDown()
    {
      Navigation navigation = this.navigation;
      return ((Navigation) ref navigation).mode == 3 && this.axis == CSlider.Axis.Vertical ? (Selectable) null : base.FindSelectableOnDown();
    }

    public virtual void OnInitializePotentialDrag(PointerEventData eventData)
    {
      eventData.useDragThreshold = false;
    }

    public void SetDirection(CSlider.Direction direction, bool includeRectLayouts)
    {
      CSlider.Axis axis = this.axis;
      bool reverseValue = this.reverseValue;
      this.direction = direction;
      if (!includeRectLayouts)
        return;
      if (this.axis != axis)
        RectTransformUtility.FlipLayoutAxes(((Component) this).transform as RectTransform, true, true);
      if (this.reverseValue == reverseValue)
        return;
      RectTransformUtility.FlipLayoutOnAxis(((Component) this).transform as RectTransform, (int) this.axis, true, true);
    }

    virtual Transform ICanvasElement.get_transform() => ((Component) this).transform;

    virtual bool ICanvasElement.IsDestroyed() => ((UIBehaviour) this).IsDestroyed();

    public enum Direction
    {
      LeftToRight,
      RightToLeft,
      BottomToTop,
      TopToBottom,
    }

    [Serializable]
    public class SliderEvent : UnityEvent<double>
    {
    }

    private enum Axis
    {
      Horizontal,
      Vertical,
    }
  }
}
