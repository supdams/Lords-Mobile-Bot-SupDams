// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.CScrollRect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using uTools;

#nullable disable
namespace UnityEngine.UI
{
  [AddComponentMenu("UI/Scroll Rect", 33)]
  [RequireComponent(typeof (RectTransform))]
  [SelectionBase]
  [ExecuteInEditMode]
  public class CScrollRect : 
    UIBehaviour,
    IBeginDragHandler,
    IDragHandler,
    IScrollHandler,
    IInitializePotentialDragHandler,
    IEndDragHandler,
    ICanvasElement,
    IEventSystemHandler
  {
    [SerializeField]
    private RectTransform m_Content;
    [SerializeField]
    private bool m_Horizontal = true;
    [SerializeField]
    private bool m_Vertical = true;
    [SerializeField]
    private CScrollRect.MovementType m_MovementType = CScrollRect.MovementType.Elastic;
    [SerializeField]
    private float m_Elasticity = 0.1f;
    [SerializeField]
    private bool m_Inertia = true;
    [SerializeField]
    private float m_DecelerationRate = 0.135f;
    [SerializeField]
    private float m_ScrollSensitivity = 1f;
    [SerializeField]
    private Scrollbar m_HorizontalScrollbar;
    [SerializeField]
    private Scrollbar m_VerticalScrollbar;
    [SerializeField]
    private CScrollRect.ScrollRectEvent m_OnValueChanged = new CScrollRect.ScrollRectEvent();
    private Vector2 m_PointerStartLocalCursor = Vector2.zero;
    private Vector2 m_ContentStartPosition = Vector2.zero;
    private RectTransform m_ViewRect;
    private Bounds m_ContentBounds;
    private Bounds m_ViewBounds;
    private Vector2 m_Velocity;
    private bool m_Dragging;
    private Vector2 m_PrevPosition = Vector2.zero;
    private Bounds m_PrevContentBounds;
    private Bounds m_PrevViewBounds;
    [NonSerialized]
    private bool m_HasRebuiltLayout;
    public IValueChanged m_Handler;
    private ListViewState m_ViewState;
    private bool m_bInitViewState;
    private bool m_bStopViewState = true;
    private bool m_bStopViewState_Up = true;
    private bool m_Back;
    private float m_HeadContentHeight = 50f;
    private UIText m_VSText;
    private Image m_VSImage;
    private RectTransform m_VSImageRC;
    public bool bPageMove;
    public bool bPageMoving;
    public byte NowPageIndex;
    public byte PageQuantity = 2;
    public float PageWidth = 433f;
    public Vector2 _pos1 = Vector2.zero;
    public Vector2 _pos2 = Vector2.zero;
    public float _time1;
    public float _time2;
    public float MoveEndX = -1f;
    public float PageMoveSpeed;
    public IPagemove m_PageMoveHandler;
    private Vector2 startPos = new Vector2();
    private readonly Vector3[] m_Corners = new Vector3[4];

    protected CScrollRect()
    {
    }

    public RectTransform content
    {
      get => this.m_Content;
      set => this.m_Content = value;
    }

    public bool horizontal
    {
      get => this.m_Horizontal;
      set => this.m_Horizontal = value;
    }

    public bool vertical
    {
      get => this.m_Vertical;
      set => this.m_Vertical = value;
    }

    public CScrollRect.MovementType movementType
    {
      get => this.m_MovementType;
      set => this.m_MovementType = value;
    }

    public float elasticity
    {
      get => this.m_Elasticity;
      set => this.m_Elasticity = value;
    }

    public bool inertia
    {
      get => this.m_Inertia;
      set => this.m_Inertia = value;
    }

    public float decelerationRate
    {
      get => this.m_DecelerationRate;
      set => this.m_DecelerationRate = value;
    }

    public float scrollSensitivity
    {
      get => this.m_ScrollSensitivity;
      set => this.m_ScrollSensitivity = value;
    }

    public Scrollbar horizontalScrollbar
    {
      get => this.m_HorizontalScrollbar;
      set
      {
        if ((bool) (UnityEngine.Object) this.m_HorizontalScrollbar)
          ((UnityEvent<float>) this.m_HorizontalScrollbar.onValueChanged).RemoveListener(new UnityAction<float>((object) this, __methodptr(SetHorizontalNormalizedPosition)));
        this.m_HorizontalScrollbar = value;
        if (!(bool) (UnityEngine.Object) this.m_HorizontalScrollbar)
          return;
        ((UnityEvent<float>) this.m_HorizontalScrollbar.onValueChanged).AddListener(new UnityAction<float>((object) this, __methodptr(SetHorizontalNormalizedPosition)));
      }
    }

    public Scrollbar verticalScrollbar
    {
      get => this.m_VerticalScrollbar;
      set
      {
        if ((bool) (UnityEngine.Object) this.m_VerticalScrollbar)
          ((UnityEvent<float>) this.m_VerticalScrollbar.onValueChanged).RemoveListener(new UnityAction<float>((object) this, __methodptr(SetVerticalNormalizedPosition)));
        this.m_VerticalScrollbar = value;
        if (!(bool) (UnityEngine.Object) this.m_VerticalScrollbar)
          return;
        ((UnityEvent<float>) this.m_VerticalScrollbar.onValueChanged).AddListener(new UnityAction<float>((object) this, __methodptr(SetVerticalNormalizedPosition)));
      }
    }

    public CScrollRect.ScrollRectEvent onValueChanged
    {
      get => this.m_OnValueChanged;
      set => this.m_OnValueChanged = value;
    }

    protected RectTransform viewRect
    {
      get
      {
        if ((UnityEngine.Object) this.m_ViewRect == (UnityEngine.Object) null)
          this.m_ViewRect = (RectTransform) ((Component) this).transform;
        return this.m_ViewRect;
      }
    }

    public Vector2 velocity
    {
      get => this.m_Velocity;
      set => this.m_Velocity = value;
    }

    public ListViewState ViewState => this.m_ViewState;

    public virtual void Rebuild(CanvasUpdate executing)
    {
      if (executing != 2)
        return;
      this.UpdateBounds();
      this.UpdateScrollbars(Vector2.zero);
      this.UpdatePrevData();
      this.m_HasRebuiltLayout = true;
    }

    protected virtual void OnEnable()
    {
      base.OnEnable();
      if ((bool) (UnityEngine.Object) this.m_HorizontalScrollbar)
      {
        // ISSUE: method pointer
        ((UnityEvent<float>) this.m_HorizontalScrollbar.onValueChanged).AddListener(new UnityAction<float>((object) this, __methodptr(SetHorizontalNormalizedPosition)));
      }
      if ((bool) (UnityEngine.Object) this.m_VerticalScrollbar)
      {
        // ISSUE: method pointer
        ((UnityEvent<float>) this.m_VerticalScrollbar.onValueChanged).AddListener(new UnityAction<float>((object) this, __methodptr(SetVerticalNormalizedPosition)));
      }
      CanvasUpdateRegistry.RegisterCanvasElementForLayoutRebuild((ICanvasElement) this);
      if (!this.bPageMoving)
        return;
      this.setCurrentIndex(this.NowPageIndex, true);
      if (this.m_PageMoveHandler != null)
        this.m_PageMoveHandler.EndPageMove();
      this.MoveEndX = -1f;
      this.bPageMoving = false;
    }

    protected virtual void OnDisable()
    {
      CanvasUpdateRegistry.UnRegisterCanvasElementForRebuild((ICanvasElement) this);
      if ((bool) (UnityEngine.Object) this.m_HorizontalScrollbar)
      {
        // ISSUE: method pointer
        ((UnityEvent<float>) this.m_HorizontalScrollbar.onValueChanged).RemoveListener(new UnityAction<float>((object) this, __methodptr(SetHorizontalNormalizedPosition)));
      }
      if ((bool) (UnityEngine.Object) this.m_VerticalScrollbar)
      {
        // ISSUE: method pointer
        ((UnityEvent<float>) this.m_VerticalScrollbar.onValueChanged).RemoveListener(new UnityAction<float>((object) this, __methodptr(SetVerticalNormalizedPosition)));
      }
      this.m_HasRebuiltLayout = false;
      base.OnDisable();
    }

    public virtual bool IsActive() => base.IsActive() && (UnityEngine.Object) this.m_Content != (UnityEngine.Object) null;

    private void EnsureLayoutHasRebuilt()
    {
      if (this.m_HasRebuiltLayout || CanvasUpdateRegistry.IsRebuildingLayout())
        return;
      Canvas.ForceUpdateCanvases();
    }

    public virtual void StopMovement() => this.m_Velocity = Vector2.zero;

    public bool Get_Dragging() => this.m_Dragging;

    public virtual void OnScroll(PointerEventData data)
    {
      if (!this.IsActive())
        return;
      this.EnsureLayoutHasRebuilt();
      this.UpdateBounds();
      Vector2 scrollDelta = data.scrollDelta;
      scrollDelta.y *= -1f;
      if (this.vertical && !this.horizontal)
      {
        if ((double) Mathf.Abs(scrollDelta.x) > (double) Mathf.Abs(scrollDelta.y))
          scrollDelta.y = scrollDelta.x;
        scrollDelta.x = 0.0f;
      }
      if (this.horizontal && !this.vertical)
      {
        if ((double) Mathf.Abs(scrollDelta.y) > (double) Mathf.Abs(scrollDelta.x))
          scrollDelta.x = scrollDelta.y;
        scrollDelta.y = 0.0f;
      }
      Vector2 position = this.m_Content.anchoredPosition + scrollDelta * this.m_ScrollSensitivity;
      if (this.m_MovementType == CScrollRect.MovementType.Clamped)
        position += this.CalculateOffset(position - this.m_Content.anchoredPosition);
      this.SetContentAnchoredPosition(position);
      this.UpdateBounds();
    }

    public virtual void OnInitializePotentialDrag(PointerEventData eventData)
    {
      this.m_Velocity = Vector2.zero;
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
      if (eventData.button != null || !this.IsActive())
        return;
      this.startPos = eventData.position;
      if (this.bPageMove)
      {
        this.bPageMoving = true;
        this._pos1 = this._pos2 = eventData.position;
        this._time1 = this._time2 = Time.realtimeSinceStartup;
        if (this.m_PageMoveHandler != null)
          this.m_PageMoveHandler.BeginPageMove();
      }
      this.UpdateBounds();
      this.m_PointerStartLocalCursor = Vector2.zero;
      RectTransformUtility.ScreenPointToLocalPointInRectangle(this.viewRect, eventData.position, eventData.pressEventCamera, ref this.m_PointerStartLocalCursor);
      this.m_ContentStartPosition = this.m_Content.anchoredPosition;
      this.m_Dragging = true;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
      if (eventData.button != null)
        return;
      if ((double) Vector2.Distance(this.startPos, eventData.position) < (double) (Screen.dpi / 2.54f) * 0.15000000596046448)
      {
        RaycastResult pointerPressRaycast1 = eventData.pointerPressRaycast;
        uButtonScale component1 = ((RaycastResult) ref pointerPressRaycast1).gameObject.GetComponent(typeof (uButtonScale)) as uButtonScale;
        if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
        {
          component1.OnPointerClick(eventData);
        }
        else
        {
          RaycastResult pointerPressRaycast2 = eventData.pointerPressRaycast;
          if (((RaycastResult) ref pointerPressRaycast2).gameObject.GetComponent(typeof (IPointerClickHandler)) is IPointerClickHandler component3)
          {
            component3.OnPointerClick(eventData);
          }
          else
          {
            byte num = 3;
            RaycastResult pointerPressRaycast3 = eventData.pointerPressRaycast;
            for (Transform transform = ((RaycastResult) ref pointerPressRaycast3).gameObject.transform; num > (byte) 0 && (bool) (UnityEngine.Object) transform.parent; transform = transform.parent)
            {
              if ((bool) (UnityEngine.Object) transform.parent.GetComponent<ScrollPanelItem>())
              {
                if (transform.parent.GetComponent(typeof (IPointerClickHandler)) is IPointerClickHandler component2)
                {
                  component2.OnPointerClick(eventData);
                  break;
                }
                break;
              }
              --num;
            }
          }
        }
        this.startPos = Vector2.zero;
      }
      if (this.m_bInitViewState && (this.ViewState == ListViewState.LVS_PULL_REFRESH || this.ViewState == ListViewState.LVS_PULL_REFRESH_UP))
        this.SwitchViewState(ListViewState.LVS_NORMAL);
      if (this.bPageMove)
      {
        float num1 = Time.realtimeSinceStartup - this._time2;
        float num2 = (eventData.position.x - this._pos2.x) / num1;
        if (GUIManager.Instance.IsArabic)
        {
          if (this.NowPageIndex > (byte) 0 && ((double) num2 < -500.0 || (double) this.m_Content.anchoredPosition.x - (double) this.m_ContentStartPosition.x >= (double) this.PageWidth * 0.5))
            this.setCurrentIndex((byte) ((uint) this.NowPageIndex - 1U));
          else if ((int) this.NowPageIndex < (int) this.PageQuantity - 1 && ((double) num2 > 500.0 || -((double) this.m_Content.anchoredPosition.x - (double) this.m_ContentStartPosition.x) >= (double) this.PageWidth * 0.5))
            this.setCurrentIndex((byte) ((uint) this.NowPageIndex + 1U));
          else
            this.setCurrentIndex(this.NowPageIndex);
        }
        else if (this.NowPageIndex > (byte) 0 && ((double) num2 > 500.0 || (double) this.m_Content.anchoredPosition.x - (double) this.m_ContentStartPosition.x >= (double) this.PageWidth * 0.5))
          this.setCurrentIndex((byte) ((uint) this.NowPageIndex - 1U));
        else if ((int) this.NowPageIndex < (int) this.PageQuantity - 1 && ((double) num2 < -500.0 || -((double) this.m_Content.anchoredPosition.x - (double) this.m_ContentStartPosition.x) >= (double) this.PageWidth * 0.5))
          this.setCurrentIndex((byte) ((uint) this.NowPageIndex + 1U));
        else
          this.setCurrentIndex(this.NowPageIndex);
      }
      this.m_Dragging = false;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
      if (eventData.button != null || !this.IsActive() || this.m_bInitViewState && this.CheckBeLoad())
        return;
      if (this.startPos != Vector2.zero)
      {
        float num1 = Vector2.Distance(this.startPos, eventData.position);
        float num2 = Screen.dpi / 2.54f;
        RaycastResult pointerPressRaycast1 = eventData.pointerPressRaycast;
        if ((UnityEngine.Object) ((RaycastResult) ref pointerPressRaycast1).gameObject != (UnityEngine.Object) null && (double) num1 > (double) num2 * 0.15000000596046448)
        {
          RaycastResult pointerPressRaycast2 = eventData.pointerPressRaycast;
          uButtonScale component = ((RaycastResult) ref pointerPressRaycast2).gameObject.GetComponent(typeof (uButtonScale)) as uButtonScale;
          if ((UnityEngine.Object) component != (UnityEngine.Object) null)
            component.OnPointerExit(eventData);
        }
      }
      if (this.bPageMove)
      {
        this._pos2 = this._pos1;
        this._time2 = this._time1;
        this._pos1 = eventData.position;
        this._time1 = Time.realtimeSinceStartup;
      }
      Vector2 vector2_1;
      if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(this.viewRect, eventData.position, eventData.pressEventCamera, ref vector2_1))
        return;
      this.UpdateBounds();
      Vector2 vector2_2 = this.m_ContentStartPosition + (vector2_1 - this.m_PointerStartLocalCursor);
      Vector2 offset = this.CalculateOffset(vector2_2 - this.m_Content.anchoredPosition);
      Vector2 position = vector2_2 + offset;
      if (this.m_MovementType == CScrollRect.MovementType.Elastic)
      {
        if ((double) offset.x != 0.0)
          position.x -= CScrollRect.RubberDelta(offset.x, this.m_ViewBounds.size.x);
        if ((double) offset.y != 0.0)
          position.y -= CScrollRect.RubberDelta(offset.y, this.m_ViewBounds.size.y);
      }
      this.SetContentAnchoredPosition(position);
      if (!this.m_Vertical || !this.m_Inertia)
        return;
      if (!this.m_bStopViewState && (double) offset.y > 0.0)
      {
        switch (this.m_ViewState)
        {
          case ListViewState.LVS_NORMAL:
            this.SwitchViewState(ListViewState.LVS_PULL_REFRESH);
            break;
          case ListViewState.LVS_PULL_REFRESH:
            if ((double) offset.y <= (double) this.m_HeadContentHeight)
              break;
            this.SwitchViewState(ListViewState.LVS_RELEASE_REFRESH);
            break;
          case ListViewState.LVS_RELEASE_REFRESH:
            if ((double) offset.y > (double) this.m_HeadContentHeight)
              break;
            this.m_Back = true;
            this.SwitchViewState(ListViewState.LVS_PULL_REFRESH);
            break;
        }
      }
      else if (!this.m_bStopViewState_Up && (double) offset.y < 0.0)
      {
        switch (this.m_ViewState)
        {
          case ListViewState.LVS_NORMAL:
            this.SwitchViewState(ListViewState.LVS_PULL_REFRESH_UP);
            break;
          case ListViewState.LVS_PULL_REFRESH_UP:
            if ((double) offset.y >= -(double) this.m_HeadContentHeight)
              break;
            this.SwitchViewState(ListViewState.LVS_RELEASE_REFRESH_UP);
            break;
          case ListViewState.LVS_RELEASE_REFRESH_UP:
            if ((double) offset.y < -(double) this.m_HeadContentHeight)
              break;
            this.m_Back = true;
            this.SwitchViewState(ListViewState.LVS_PULL_REFRESH_UP);
            break;
        }
      }
      else
        this.SwitchViewState(ListViewState.LVS_NORMAL);
    }

    protected virtual void SetContentAnchoredPosition(Vector2 position)
    {
      if (!this.m_Horizontal)
        position.x = this.m_Content.anchoredPosition.x;
      if (!this.m_Vertical)
        position.y = this.m_Content.anchoredPosition.y;
      if (!(position != this.m_Content.anchoredPosition))
        return;
      this.m_Content.anchoredPosition = position;
      this.UpdateBounds();
    }

    protected virtual void LateUpdate()
    {
      if (!(bool) (UnityEngine.Object) this.m_Content)
        return;
      if (this.m_bInitViewState && this.CheckBeLoad())
      {
        if (this.m_ViewState != ListViewState.LVS_WAITLOADING && this.m_ViewState != ListViewState.LVS_WAITLOADING_UP)
          return;
        ((Transform) this.m_VSImageRC).Rotate(Vector3.forward * Time.smoothDeltaTime * -200f);
      }
      else
      {
        this.EnsureLayoutHasRebuilt();
        this.UpdateBounds();
        float smoothDeltaTime = Time.smoothDeltaTime;
        Vector2 offset = this.CalculateOffset(Vector2.zero);
        if (!this.bPageMove && !this.m_Dragging && (offset != Vector2.zero || this.m_Velocity != Vector2.zero))
        {
          Vector2 anchoredPosition = this.m_Content.anchoredPosition;
          for (int index = 0; index < 2; ++index)
          {
            if (this.m_MovementType == CScrollRect.MovementType.Elastic && (double) offset[index] != 0.0)
            {
              float currentVelocity = this.m_Velocity[index];
              anchoredPosition[index] = Mathf.SmoothDamp(this.m_Content.anchoredPosition[index], this.m_Content.anchoredPosition[index] + offset[index], ref currentVelocity, this.m_Elasticity, float.PositiveInfinity, smoothDeltaTime);
              this.m_Velocity[index] = currentVelocity;
            }
            else if (this.m_Inertia)
            {
              this.m_Velocity[index] *= Mathf.Pow(this.m_DecelerationRate, smoothDeltaTime);
              if ((double) Mathf.Abs(this.m_Velocity[index]) < 1.0)
                this.m_Velocity[index] = 0.0f;
              anchoredPosition[index] += this.m_Velocity[index] * smoothDeltaTime;
            }
            else
              this.m_Velocity[index] = 0.0f;
          }
          if (this.m_Velocity != Vector2.zero)
          {
            if (this.m_MovementType == CScrollRect.MovementType.Clamped)
            {
              offset = this.CalculateOffset(anchoredPosition - this.m_Content.anchoredPosition);
              anchoredPosition += offset;
            }
            if (this.m_bInitViewState)
            {
              if (this.m_ViewState == ListViewState.LVS_RELEASE_REFRESH && (double) offset.y <= (double) this.m_HeadContentHeight)
              {
                this.SwitchViewState(ListViewState.LVS_LOADING);
                return;
              }
              if (this.m_ViewState == ListViewState.LVS_RELEASE_REFRESH_UP && (double) offset.y >= -(double) this.m_HeadContentHeight)
              {
                this.SwitchViewState(ListViewState.LVS_LOADING_UP);
                return;
              }
            }
            this.SetContentAnchoredPosition(anchoredPosition);
          }
        }
        if (this.bPageMove && !this.m_Dragging)
        {
          if ((double) this.MoveEndX != -1.0)
          {
            if ((double) this.m_Content.anchoredPosition.x == (double) this.MoveEndX)
            {
              this.MoveEndX = -1f;
            }
            else
            {
              Vector2 anchoredPosition = this.m_Content.anchoredPosition;
              anchoredPosition[0] = Mathf.SmoothDamp(this.m_Content.anchoredPosition.x, this.MoveEndX, ref this.PageMoveSpeed, this.m_Elasticity, float.PositiveInfinity, Time.unscaledDeltaTime);
              this.SetContentAnchoredPosition(anchoredPosition);
              if ((double) Mathf.Abs(Mathf.Abs(anchoredPosition[0]) - Mathf.Abs(this.MoveEndX)) <= 1.0)
                this.MoveEndX = -1f;
            }
          }
          else if (this.m_PageMoveHandler != null && this.bPageMoving)
          {
            this.m_PageMoveHandler.EndPageMove();
            this.bPageMoving = false;
          }
        }
        if (this.m_Dragging && this.m_Inertia)
          this.m_Velocity = (Vector2) Vector3.Lerp((Vector3) this.m_Velocity, (Vector3) ((this.m_Content.anchoredPosition - this.m_PrevPosition) / smoothDeltaTime), smoothDeltaTime * 10f);
        if (!(this.m_ViewBounds != this.m_PrevViewBounds) && !(this.m_ContentBounds != this.m_PrevContentBounds) && !(this.m_Content.anchoredPosition != this.m_PrevPosition))
          return;
        this.UpdateScrollbars(offset);
        if (this.m_Handler != null)
          this.m_Handler.onValueChanged();
        this.UpdatePrevData();
      }
    }

    private void UpdatePrevData()
    {
      this.m_PrevPosition = !((UnityEngine.Object) this.m_Content == (UnityEngine.Object) null) ? this.m_Content.anchoredPosition : Vector2.zero;
      this.m_PrevViewBounds = this.m_ViewBounds;
      this.m_PrevContentBounds = this.m_ContentBounds;
    }

    private void UpdateScrollbars(Vector2 offset)
    {
      if ((bool) (UnityEngine.Object) this.m_HorizontalScrollbar)
      {
        this.m_HorizontalScrollbar.size = Mathf.Clamp01((this.m_ViewBounds.size.x - Mathf.Abs(offset.x)) / this.m_ContentBounds.size.x);
        this.m_HorizontalScrollbar.value = this.horizontalNormalizedPosition;
      }
      if (!(bool) (UnityEngine.Object) this.m_VerticalScrollbar)
        return;
      this.m_VerticalScrollbar.size = Mathf.Clamp01((this.m_ViewBounds.size.y - Mathf.Abs(offset.y)) / this.m_ContentBounds.size.y);
      this.m_VerticalScrollbar.value = this.verticalNormalizedPosition;
    }

    public Vector2 normalizedPosition
    {
      get => new Vector2(this.horizontalNormalizedPosition, this.verticalNormalizedPosition);
      set
      {
        this.SetNormalizedPosition(value.x, 0);
        this.SetNormalizedPosition(value.y, 1);
      }
    }

    public float horizontalNormalizedPosition
    {
      get
      {
        this.UpdateBounds();
        return (double) this.m_ContentBounds.size.x <= (double) this.m_ViewBounds.size.x ? ((double) this.m_ViewBounds.min.x <= (double) this.m_ContentBounds.min.x ? 0.0f : 1f) : (float) (((double) this.m_ViewBounds.min.x - (double) this.m_ContentBounds.min.x) / ((double) this.m_ContentBounds.size.x - (double) this.m_ViewBounds.size.x));
      }
      set => this.SetNormalizedPosition(value, 0);
    }

    public float verticalNormalizedPosition
    {
      get
      {
        this.UpdateBounds();
        return (double) this.m_ContentBounds.size.y <= (double) this.m_ViewBounds.size.y ? ((double) this.m_ViewBounds.min.y <= (double) this.m_ContentBounds.min.y ? 0.0f : 1f) : (float) (((double) this.m_ViewBounds.min.y - (double) this.m_ContentBounds.min.y) / ((double) this.m_ContentBounds.size.y - (double) this.m_ViewBounds.size.y));
      }
      set => this.SetNormalizedPosition(value, 1);
    }

    private void SetHorizontalNormalizedPosition(float value)
    {
      this.SetNormalizedPosition(value, 0);
    }

    private void SetVerticalNormalizedPosition(float value) => this.SetNormalizedPosition(value, 1);

    private void SetNormalizedPosition(float value, int axis)
    {
      this.EnsureLayoutHasRebuilt();
      this.UpdateBounds();
      float num1 = this.m_ContentBounds.size[axis] - this.m_ViewBounds.size[axis];
      float num2 = this.m_ViewBounds.min[axis] - value * num1;
      float num3 = ((Transform) this.m_Content).localPosition[axis] + num2 - this.m_ContentBounds.min[axis];
      Vector3 localPosition = ((Transform) this.m_Content).localPosition;
      if ((double) Mathf.Abs(localPosition[axis] - num3) <= 0.0099999997764825821)
        return;
      localPosition[axis] = num3;
      ((Transform) this.m_Content).localPosition = localPosition;
      this.m_Velocity[axis] = 0.0f;
      this.UpdateBounds();
    }

    private static float RubberDelta(float overStretching, float viewSize)
    {
      return (float) (1.0 - 1.0 / ((double) Mathf.Abs(overStretching) * 0.550000011920929 / (double) viewSize + 1.0)) * viewSize * Mathf.Sign(overStretching);
    }

    private void UpdateBounds()
    {
      this.m_ViewBounds = new Bounds((Vector3) this.viewRect.rect.center, (Vector3) this.viewRect.rect.size);
      this.m_ContentBounds = this.GetBounds();
      if ((UnityEngine.Object) this.m_Content == (UnityEngine.Object) null)
        return;
      Vector3 size = this.m_ContentBounds.size;
      Vector3 center = this.m_ContentBounds.center;
      Vector3 vector3 = this.m_ViewBounds.size - size;
      if ((double) vector3.x > 0.0)
      {
        center.x -= vector3.x * (this.m_Content.pivot.x - 0.5f);
        size.x = this.m_ViewBounds.size.x;
      }
      if ((double) vector3.y > 0.0)
      {
        center.y -= vector3.y * (this.m_Content.pivot.y - 0.5f);
        size.y = this.m_ViewBounds.size.y;
      }
      this.m_ContentBounds.size = size;
      this.m_ContentBounds.center = center;
    }

    private Bounds GetBounds()
    {
      if ((UnityEngine.Object) this.m_Content == (UnityEngine.Object) null)
        return new Bounds();
      Vector3 vector3_1 = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
      Vector3 vector3_2 = new Vector3(float.MinValue, float.MinValue, float.MinValue);
      Matrix4x4 worldToLocalMatrix = ((Transform) this.viewRect).worldToLocalMatrix;
      this.m_Content.GetWorldCorners(this.m_Corners);
      for (int index = 0; index < 4; ++index)
      {
        Vector3 lhs = worldToLocalMatrix.MultiplyPoint3x4(this.m_Corners[index]);
        vector3_1 = Vector3.Min(lhs, vector3_1);
        vector3_2 = Vector3.Max(lhs, vector3_2);
      }
      Bounds bounds = new Bounds(vector3_1, Vector3.zero);
      bounds.Encapsulate(vector3_2);
      return bounds;
    }

    private Vector2 CalculateOffset(Vector2 delta)
    {
      Vector2 zero = Vector2.zero;
      if (this.m_MovementType == CScrollRect.MovementType.Unrestricted)
        return zero;
      Vector2 min = (Vector2) this.m_ContentBounds.min;
      Vector2 max = (Vector2) this.m_ContentBounds.max;
      if (this.m_Horizontal)
      {
        min.x += delta.x;
        max.x += delta.x;
        if ((double) min.x > (double) this.m_ViewBounds.min.x)
          zero.x = this.m_ViewBounds.min.x - min.x;
        else if ((double) max.x < (double) this.m_ViewBounds.max.x)
          zero.x = this.m_ViewBounds.max.x - max.x;
      }
      if (this.m_Vertical)
      {
        min.y += delta.y;
        max.y += delta.y;
        if ((double) max.y < (double) this.m_ViewBounds.max.y)
          zero.y = this.m_ViewBounds.max.y - max.y;
        else if ((double) min.y > (double) this.m_ViewBounds.min.y)
          zero.y = this.m_ViewBounds.min.y - min.y;
      }
      return zero;
    }

    public void InitViewState(UIText tmpT, Image tmpI)
    {
      if (this.m_bInitViewState)
        return;
      this.m_bInitViewState = true;
      this.m_VSText = tmpT;
      this.m_VSImage = tmpI;
      this.m_VSImageRC = ((Graphic) this.m_VSImage).rectTransform;
    }

    public bool bStopViewState
    {
      get => this.m_bStopViewState;
      set
      {
        if (this.m_bStopViewState == value)
          return;
        this.m_bStopViewState = value;
        if (this.m_ViewState < ListViewState.LVS_PULL_REFRESH || this.m_ViewState > ListViewState.LVS_WAITLOADING)
          return;
        this.m_ViewState = ListViewState.LVS_NORMAL;
        if (!this.m_bInitViewState)
          return;
        ((Behaviour) this.m_VSImage).enabled = false;
        ((Behaviour) this.m_VSText).enabled = false;
      }
    }

    public bool bStopViewState_Up
    {
      get => this.m_bStopViewState_Up;
      set
      {
        if (this.m_bStopViewState_Up == value)
          return;
        this.m_bStopViewState_Up = value;
        if (this.m_ViewState < ListViewState.LVS_PULL_REFRESH_UP || this.m_ViewState > ListViewState.LVS_WAITLOADING_UP)
          return;
        this.m_ViewState = ListViewState.LVS_NORMAL;
        if (!this.m_bInitViewState)
          return;
        ((Behaviour) this.m_VSImage).enabled = false;
        ((Behaviour) this.m_VSText).enabled = false;
      }
    }

    public void SwitchViewState(ListViewState state)
    {
      if (!this.m_bInitViewState)
        return;
      switch (state)
      {
        case ListViewState.LVS_NORMAL:
          ((Behaviour) this.m_VSImage).enabled = false;
          ((Behaviour) this.m_VSText).enabled = false;
          break;
        case ListViewState.LVS_PULL_REFRESH:
        case ListViewState.LVS_PULL_REFRESH_UP:
          ((Behaviour) this.m_VSImage).enabled = true;
          ((Behaviour) this.m_VSText).enabled = true;
          this.m_VSText.text = state != ListViewState.LVS_PULL_REFRESH ? DataManager.Instance.mStringTable.GetStringByID(200U) : DataManager.Instance.mStringTable.GetStringByID(179U);
          if (this.m_Back)
          {
            this.m_Back = false;
            break;
          }
          break;
        case ListViewState.LVS_RELEASE_REFRESH:
        case ListViewState.LVS_RELEASE_REFRESH_UP:
          ((Behaviour) this.m_VSImage).enabled = true;
          ((Behaviour) this.m_VSText).enabled = true;
          this.m_VSText.text = DataManager.Instance.mStringTable.GetStringByID(180U);
          break;
        case ListViewState.LVS_LOADING:
        case ListViewState.LVS_LOADING_UP:
          ((Behaviour) this.m_VSImage).enabled = true;
          ((Behaviour) this.m_VSText).enabled = false;
          break;
      }
      this.m_ViewState = state;
    }

    public bool CheckBeLoad()
    {
      return this.m_ViewState == ListViewState.LVS_LOADING || this.m_ViewState == ListViewState.LVS_WAITLOADING || this.m_ViewState == ListViewState.LVS_LOADING_UP || this.m_ViewState == ListViewState.LVS_WAITLOADING_UP;
    }

    public void setCurrentIndex(byte value, bool immediate = false)
    {
      if (!this.bPageMove)
        return;
      if ((int) this.NowPageIndex != (int) value)
        this.NowPageIndex = value;
      if (immediate)
        this.m_Content.anchoredPosition = new Vector2((float) this.NowPageIndex * -this.PageWidth, this.m_Content.anchoredPosition.y);
      else
        this.MoveEndX = (float) this.NowPageIndex * -this.PageWidth;
      if (this.m_PageMoveHandler == null)
        return;
      this.m_PageMoveHandler.PageIndexChange(this.NowPageIndex);
    }

    public void ChangePageWidth(float NewWidth)
    {
      if (!this.bPageMove || !((UnityEngine.Object) this.m_Content != (UnityEngine.Object) null))
        return;
      this.MoveEndX = -1f;
      this.PageWidth = NewWidth;
      this.m_Content.sizeDelta = new Vector2(this.PageWidth * (float) this.PageQuantity, this.m_Content.sizeDelta.y);
      this.m_Content.anchoredPosition = new Vector2((float) this.NowPageIndex * -this.PageWidth, this.m_Content.anchoredPosition.y);
      for (int index = 0; index < (int) this.PageQuantity; ++index)
      {
        RectTransform component = ((Transform) this.m_Content).GetChild(index).GetComponent<RectTransform>();
        component.sizeDelta = new Vector2(this.PageWidth, component.sizeDelta.y);
        component.anchoredPosition = new Vector2(this.PageWidth * (float) index, component.anchoredPosition.y);
      }
    }

    public bool IsAtLast()
    {
      return (UnityEngine.Object) this.m_Content != (UnityEngine.Object) null && (double) this.m_Content.sizeDelta.y - (double) this.m_Content.anchoredPosition.y <= (double) this.viewRect.sizeDelta.y;
    }

    virtual Transform ICanvasElement.get_transform() => ((Component) this).transform;

    virtual bool ICanvasElement.IsDestroyed() => this.IsDestroyed();

    public enum MovementType
    {
      Unrestricted,
      Elastic,
      Clamped,
    }

    [Serializable]
    public class ScrollRectEvent : UnityEvent<Vector2>
    {
    }
  }
}
