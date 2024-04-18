// Decompiled with JetBrains decompiler
// Type: ScrollPanel_Horizontal
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ScrollPanel_Horizontal : MonoBehaviour, IValueChanged, IScrollPanelItemHandler
{
  private float m_PanelWidth = 600f;
  private float m_Border = 10f;
  private float m_Range = 10f;
  private int m_MaxItemOfPage;
  private int beginIndex;
  private float viewheight;
  private float m_TotalWidth;
  private List<ItemData_H> m_DataList;
  private Vector2 m_PanelSize;
  private GameObject m_Content;
  private RectTransform ContentRect;
  public GameObject m_customItem;
  public PanelObject[] m_PanelObjects;
  public int m_FirstIdx;
  public int m_LastIdx;
  public IUpDateScrollPanel m_handler;
  public int m_ScrollPanelID;

  public void onValueChanged() => this.MyUpdate();

  public void ButtonOnClick(ScrollPanelItem sender)
  {
    if (this.m_handler == null)
      return;
    this.m_handler.ButtonOnClick(((Component) sender).gameObject, sender.m_BtnID1, this.m_ScrollPanelID);
  }

  public void IntiScrollPanel(
    float _PanelWidth,
    float _Border,
    float _Range,
    List<float> _DataHeight,
    int _PanelObjectsCount,
    IUpDateScrollPanel _handler)
  {
    this.m_PanelWidth = _PanelWidth;
    this.m_Border = _Border;
    this.m_Range = _Range;
    this.m_MaxItemOfPage = _PanelObjectsCount;
    this.m_handler = _handler;
    this.m_TotalWidth = this.GetTotalWidth(_DataHeight, _Border, _Range);
    this.m_Content = this.CreateContent(this.CreateCScrollRect(), out this.ContentRect, this.m_TotalWidth);
    this.m_PanelSize = this.gameObject.GetComponent<RectTransform>().rect.size;
    this.CreatePanelObjects(out this.m_PanelObjects, this.m_MaxItemOfPage);
    this.UpdatePanelPostion(this.m_FirstIdx);
    if ((bool) (Object) this.m_customItem)
      this.m_customItem.SetActive(false);
    this.MyUpdate();
  }

  public int GetBeginIdx() => this.beginIndex;

  public int GetTopIdx()
  {
    if ((Object) this.ContentRect == (Object) null || this.m_PanelObjects == null)
      return -1;
    float a = -this.ContentRect.anchoredPosition.x;
    for (int index = 0; index < this.m_MaxItemOfPage; ++index)
    {
      int btnId1 = this.m_PanelObjects[index].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1;
      if (btnId1 != -1 && (Mathf.Approximately(a, this.m_PanelObjects[index].rectTransform.anchoredPosition.x) || (double) a >= (double) this.m_PanelObjects[index].rectTransform.anchoredPosition.x) && (double) a <= (double) this.m_PanelObjects[index].rectTransform.anchoredPosition.x + (double) this.m_PanelObjects[index].rectTransform.sizeDelta.x + (double) this.m_Range)
        return btnId1;
    }
    return -1;
  }

  public void AddItem(float width, bool bMoveToLast = false)
  {
    this.m_DataList.Add(new ItemData_H()
    {
      m_Width = width,
      m_LimitLeft = this.m_TotalWidth
    });
    this.m_TotalWidth += width + this.m_Range;
    this.ContentRect.sizeDelta = new Vector2(this.m_TotalWidth, 0.0f);
    int _idx;
    if (this.m_DataList.Count >= this.m_FirstIdx)
    {
      _idx = this.m_FirstIdx;
    }
    else
    {
      _idx = 0;
      this.m_LastIdx = 0;
    }
    this.UpdatePanelPostion(_idx);
    if (bMoveToLast)
      this.ContentRect.anchoredPosition = (double) this.ContentRect.sizeDelta.y < (double) this.m_PanelWidth ? new Vector2((float) -((double) this.m_TotalWidth - (double) this.m_PanelWidth), 0.0f) : new Vector2(0.0f, 0.0f);
    this.MyUpdate();
  }

  public void AddNewDataHeight(List<float> _DataWidth, bool IsSetBeginPos = true, bool bSoptMove = true)
  {
    this.m_DataList.Clear();
    this.m_TotalWidth = this.m_Border;
    for (int index = 0; index < _DataWidth.Count; ++index)
    {
      this.m_DataList.Add(new ItemData_H()
      {
        m_Width = _DataWidth[index],
        m_LimitLeft = this.m_TotalWidth
      });
      this.m_TotalWidth += _DataWidth[index] + this.m_Range;
    }
    this.ContentRect.sizeDelta = new Vector2(this.m_TotalWidth, 0.0f);
    if (IsSetBeginPos)
    {
      this.ContentRect.anchoredPosition = new Vector2(0.0f, 0.0f);
      this.beginIndex = 0;
      this.m_FirstIdx = 0;
      this.m_LastIdx = 0;
    }
    if (_DataWidth.Count > 0 && this.beginIndex >= _DataWidth.Count)
      this.beginIndex = _DataWidth.Count - 1;
    this.UpdatePanelPostion(this.m_FirstIdx);
    this.MyUpdate();
    if (!bSoptMove)
      return;
    CScrollRect component = this.gameObject.GetComponent<CScrollRect>();
    if (!((Object) component != (Object) null))
      return;
    component.StopMovement();
  }

  public void AddNewDataHeight(List<float> _DataHeight, float newWidth, bool IsSetBeginPos = true)
  {
    this.m_TotalWidth = newWidth;
    this.m_DataList.Clear();
    this.m_TotalWidth = this.m_Border;
    for (int index = 0; index < _DataHeight.Count; ++index)
    {
      this.m_DataList.Add(new ItemData_H()
      {
        m_Width = _DataHeight[index],
        m_LimitLeft = this.m_TotalWidth
      });
      this.m_TotalWidth += _DataHeight[index] + this.m_Range;
    }
    this.ContentRect.sizeDelta = new Vector2(this.m_TotalWidth, 0.0f);
    if (IsSetBeginPos)
    {
      this.ContentRect.anchoredPosition = new Vector2(0.0f, 0.0f);
      this.beginIndex = 0;
      this.m_FirstIdx = 0;
      this.m_LastIdx = 0;
    }
    this.UpdatePanelPostion(this.m_FirstIdx);
    this.MyUpdate();
    CScrollRect component = this.gameObject.GetComponent<CScrollRect>();
    if (!((Object) component != (Object) null))
      return;
    component.StopMovement();
  }

  public void GoTo(int itemidx, float width)
  {
    if (itemidx < 0 || itemidx >= this.m_DataList.Count || (double) this.ContentRect.sizeDelta.x <= (double) this.m_PanelWidth)
      return;
    CScrollRect component = this.gameObject.GetComponent<CScrollRect>();
    if ((Object) component != (Object) null)
      component.StopMovement();
    this.beginIndex = itemidx;
    float num1 = 0.0f;
    if (itemidx > 0)
      num1 = this.m_Border;
    for (int index = 0; index < itemidx; ++index)
    {
      num1 += this.m_DataList[index].m_Width + this.m_Range;
      if ((double) num1 > (double) this.m_TotalWidth - (double) this.m_PanelWidth)
      {
        this.beginIndex = index;
        float num2 = this.m_TotalWidth - this.m_PanelSize.x;
        break;
      }
    }
    this.m_FirstIdx = 0;
    this.m_LastIdx = this.m_MaxItemOfPage - 1;
    this.UpdatePanelPostion(this.m_FirstIdx);
    this.ContentRect.anchoredPosition = new Vector2(width, 0.0f);
    this.MyUpdate();
  }

  public void GoTo(int itemidx)
  {
    if (itemidx < 0 || itemidx >= this.m_DataList.Count || (double) this.ContentRect.sizeDelta.x <= (double) this.m_PanelWidth)
      return;
    CScrollRect component = this.gameObject.GetComponent<CScrollRect>();
    if ((Object) component != (Object) null)
      component.StopMovement();
    this.beginIndex = itemidx;
    float num = 0.0f;
    if (itemidx > 0)
      num = this.m_Border;
    for (int index = 0; index < itemidx; ++index)
    {
      num += this.m_DataList[index].m_Width + this.m_Range;
      if ((double) num > (double) this.m_TotalWidth - (double) this.m_PanelWidth)
      {
        this.beginIndex = index;
        num = this.m_TotalWidth - this.m_PanelSize.x;
        break;
      }
    }
    this.m_FirstIdx = 0;
    this.m_LastIdx = this.m_MaxItemOfPage - 1;
    this.UpdatePanelPostion(this.m_FirstIdx);
    this.ContentRect.anchoredPosition = new Vector2(-num, 0.0f);
    this.MyUpdate();
  }

  public float GetContentPos() => this.ContentRect.anchoredPosition.x;

  public void GoToLast()
  {
    if (this.CheckAtLast())
      return;
    this.GoTo(this.m_DataList.Count - 1, (float) -((double) this.ContentRect.sizeDelta.x - (double) this.m_PanelWidth));
  }

  private PanelObject AddContentObj(
    int btnID,
    GameObject item,
    Vector2 pos,
    float height,
    GameObject content)
  {
    RectTransform component1 = item.GetComponent<RectTransform>();
    if ((Object) component1 != (Object) null)
    {
      GameObject gameObject = Object.Instantiate((Object) item) as GameObject;
      if ((Object) gameObject != (Object) null)
      {
        RectTransform component2 = gameObject.GetComponent<RectTransform>();
        ScrollPanelItem component3 = gameObject.GetComponent<ScrollPanelItem>();
        if ((Object) component2 != (Object) null && (Object) component3 != (Object) null)
        {
          component3.m_BtnID1 = btnID;
          component3.m_Handler = (IScrollPanelItemHandler) this;
          component2.anchoredPosition = pos;
          component2.anchorMax = new Vector2(0.0f, 1f);
          component2.anchorMin = new Vector2(0.0f, 1f);
          component2.pivot = new Vector2(0.0f, 1f);
          component2.sizeDelta = new Vector2(component1.sizeDelta.x, component1.sizeDelta.y);
          PanelObject panelObject = new PanelObject();
          panelObject.gameObject = gameObject;
          panelObject.rectTransform = component2;
          gameObject.transform.SetParent(content.transform, false);
          return panelObject;
        }
      }
    }
    return (PanelObject) null;
  }

  private void MyUpdate()
  {
    if ((Object) this.m_Content == (Object) null || this.m_PanelObjects == null)
      return;
    float moveheight = -this.ContentRect.anchoredPosition.x;
    if (this.beginIndex < this.m_DataList.Count)
    {
      float num1 = this.m_DataList[this.beginIndex].m_LimitLeft + this.m_DataList[this.beginIndex].m_Width;
      float num2 = 0.0f;
      if (this.beginIndex > 0)
        num2 = this.m_DataList[this.beginIndex - 1].m_LimitLeft + this.m_DataList[this.beginIndex - 1].m_Width + this.m_Range;
      bool flag = true;
      for (int index = Mathf.Clamp(this.m_MaxItemOfPage / 2, 1, this.m_MaxItemOfPage); flag && ((double) moveheight > (double) num1 || (double) moveheight < (double) num2) && index > 0; --index)
      {
        if ((double) moveheight > (double) num1)
          flag = this.AddToLast();
        else if ((double) moveheight < (double) num2)
          flag = this.AddToFirst();
        num1 = this.m_DataList[this.beginIndex].m_LimitLeft + this.m_DataList[this.beginIndex].m_Width;
        if (this.beginIndex > 0)
          num2 = this.m_DataList[this.beginIndex - 1].m_LimitLeft + this.m_DataList[this.beginIndex - 1].m_Width + this.m_Range;
      }
    }
    this.HideOutsideObjects(moveheight);
  }

  private bool AddToLast()
  {
    RectTransform rectTransform = this.m_PanelObjects[this.m_FirstIdx].rectTransform;
    int firstIdx = this.m_FirstIdx;
    if (this.beginIndex + this.m_MaxItemOfPage >= this.m_DataList.Count)
      return false;
    float width = this.m_DataList[this.beginIndex + this.m_MaxItemOfPage].m_Width;
    Vector2 vector2 = new Vector2(this.m_DataList[this.beginIndex + this.m_MaxItemOfPage].m_LimitLeft, 0.0f);
    rectTransform.anchoredPosition = vector2;
    rectTransform.sizeDelta = new Vector2(width, rectTransform.sizeDelta.y);
    this.m_LastIdx = this.m_FirstIdx;
    if (this.m_FirstIdx + 1 >= this.m_MaxItemOfPage)
      this.m_FirstIdx = 0;
    else
      ++this.m_FirstIdx;
    ++this.beginIndex;
    ((Component) rectTransform).gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + this.m_MaxItemOfPage - 1;
    if (this.m_handler != null)
      this.m_handler.UpDateRowItem(((Component) rectTransform).gameObject, this.beginIndex + this.m_MaxItemOfPage - 1, firstIdx, this.m_ScrollPanelID);
    return true;
  }

  private bool AddToFirst()
  {
    RectTransform rectTransform1 = this.m_PanelObjects[this.m_LastIdx].rectTransform;
    RectTransform rectTransform2 = this.m_PanelObjects[this.m_FirstIdx].rectTransform;
    if (this.beginIndex - 1 >= this.m_DataList.Count || this.beginIndex - 1 < 0)
      return false;
    float width = this.m_DataList[this.beginIndex - 1].m_Width;
    Vector2 vector2 = new Vector2(this.m_DataList[this.beginIndex - 1].m_LimitLeft, 0.0f);
    rectTransform1.anchoredPosition = vector2;
    rectTransform1.sizeDelta = new Vector2(width, rectTransform2.sizeDelta.y);
    this.m_FirstIdx = this.m_LastIdx;
    if (this.m_LastIdx == 0)
      this.m_LastIdx = this.m_MaxItemOfPage - 1;
    else
      --this.m_LastIdx;
    --this.beginIndex;
    ((Component) rectTransform1).gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex;
    if (this.m_handler != null)
      this.m_handler.UpDateRowItem(((Component) rectTransform1).gameObject, this.beginIndex, this.m_FirstIdx, this.m_ScrollPanelID);
    return true;
  }

  public bool CheckAtLast()
  {
    return (Object) this.ContentRect == (Object) null || (double) this.ContentRect.sizeDelta.x + (double) this.ContentRect.anchoredPosition.x <= (double) this.m_PanelWidth;
  }

  public bool CheckInPanel(int itemidx, bool CheckMiddle = false)
  {
    if (itemidx >= 0 && itemidx < this.m_DataList.Count && (Object) this.ContentRect != (Object) null)
    {
      float num1 = -this.ContentRect.anchoredPosition.x;
      if (CheckMiddle)
      {
        float num2 = this.m_DataList[itemidx].m_Width / 2f;
        if ((double) this.m_DataList[itemidx].m_LimitLeft + (double) num2 > (double) num1 && (double) this.m_DataList[itemidx].m_LimitLeft + (double) num2 < (double) this.m_PanelSize.x + (double) num1)
          return true;
      }
      else if ((double) this.m_DataList[itemidx].m_LimitLeft + (double) this.m_DataList[itemidx].m_Width > (double) num1 && (double) this.m_DataList[itemidx].m_LimitLeft < (double) this.m_PanelSize.x + (double) num1)
        return true;
    }
    return false;
  }

  private float GetTotalWidth(List<float> _DataWidth, float border, float range)
  {
    float totalWidth = border;
    this.m_DataList = new List<ItemData_H>(_DataWidth.Count);
    for (int index = 0; index < _DataWidth.Count; ++index)
    {
      this.m_DataList.Add(new ItemData_H()
      {
        m_Width = _DataWidth[index],
        m_LimitLeft = totalWidth
      });
      totalWidth += _DataWidth[index] + range;
    }
    return totalWidth;
  }

  private CScrollRect CreateCScrollRect()
  {
    CScrollRect cscrollRect = this.gameObject.AddComponent<CScrollRect>();
    cscrollRect.m_Handler = (IValueChanged) this;
    cscrollRect.horizontal = true;
    cscrollRect.vertical = false;
    cscrollRect.inertia = true;
    cscrollRect.decelerationRate = 0.35f;
    cscrollRect.scrollSensitivity = 1f;
    Mask mask = this.gameObject.AddComponent<Mask>();
    ((Behaviour) mask).enabled = true;
    mask.showMaskGraphic = false;
    return cscrollRect;
  }

  private GameObject CreateContent(
    CScrollRect rect,
    out RectTransform _ContentRect,
    float _TotalWidth)
  {
    GameObject content = new GameObject();
    content.name = "Content";
    _ContentRect = content.AddComponent<RectTransform>();
    _ContentRect.anchorMax = new Vector2(0.0f, 1f);
    _ContentRect.anchorMin = new Vector2(0.0f, 1f);
    _ContentRect.pivot = new Vector2(0.0f, 1f);
    _ContentRect.sizeDelta = new Vector2(_TotalWidth, 0.0f);
    rect.content = _ContentRect;
    ((Component) _ContentRect).transform.SetParent(this.gameObject.transform, false);
    return content;
  }

  private void CreatePanelObjects(out PanelObject[] m_PanelObjects, int Max)
  {
    m_PanelObjects = new PanelObject[this.m_MaxItemOfPage];
    for (int index = 0; index < this.m_MaxItemOfPage; ++index)
    {
      Vector2 pos = new Vector2(this.m_Border, 0.0f);
      m_PanelObjects[index] = this.AddContentObj(-1, this.m_customItem, pos, 0.0f, this.m_Content);
      this.m_LastIdx = index;
    }
  }

  private void UpdatePanelPostion() => this.UpdatePanelPostion(this.m_FirstIdx);

  private void UpdatePanelPostion(int _idx)
  {
    int panelObjectIdx = _idx;
    for (int index = 0; index < this.m_MaxItemOfPage; ++index)
    {
      if (this.m_PanelObjects[panelObjectIdx] != null)
      {
        if (this.m_handler != null && this.beginIndex + index < this.m_DataList.Count)
        {
          this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.m_DataList[this.beginIndex + index].m_Width, this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta.y);
          Vector2 vector2 = new Vector2(this.m_DataList[this.beginIndex + index].m_LimitLeft, 0.0f);
          this.m_PanelObjects[panelObjectIdx].rectTransform.anchoredPosition = vector2;
          this.m_PanelObjects[panelObjectIdx].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + index;
          this.m_handler.UpDateRowItem(this.m_PanelObjects[panelObjectIdx].gameObject, this.beginIndex + index, panelObjectIdx, this.m_ScrollPanelID);
        }
        else
        {
          Vector2 vector2 = new Vector2(-(-this.ContentRect.anchoredPosition.y - this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta.x - this.m_Range), 0.0f);
          this.m_PanelObjects[panelObjectIdx].rectTransform.anchoredPosition = vector2;
          this.m_PanelObjects[panelObjectIdx].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = -1;
        }
        ++panelObjectIdx;
        if (panelObjectIdx >= this.m_MaxItemOfPage)
          panelObjectIdx = 0;
      }
    }
  }

  private void HideOutsideObjects(float moveheight)
  {
    for (int index = 0; index < this.m_MaxItemOfPage; ++index)
    {
      if ((double) this.m_PanelObjects[index].rectTransform.anchoredPosition.x + (double) this.m_PanelObjects[index].rectTransform.sizeDelta.x > (double) moveheight && (double) this.m_PanelObjects[index].rectTransform.anchoredPosition.x < (double) this.m_PanelSize.x + (double) moveheight && this.m_PanelObjects[index].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 != -1)
      {
        if (!this.m_PanelObjects[index].gameObject.activeSelf)
          this.m_PanelObjects[index].gameObject.SetActive(true);
      }
      else if (this.m_PanelObjects[index].gameObject.activeSelf)
        this.m_PanelObjects[index].gameObject.SetActive(false);
    }
  }
}
