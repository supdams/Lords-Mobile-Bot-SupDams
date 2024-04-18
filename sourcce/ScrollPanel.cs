// Decompiled with JetBrains decompiler
// Type: ScrollPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ScrollPanel : MonoBehaviour, IValueChanged, IScrollPanelItemHandler
{
  private float m_PanelHeight = 600f;
  private float m_Border = 10f;
  private float m_Range = 10f;
  private int m_MaxItemOfPage;
  private int beginIndex;
  private float viewheight;
  private float m_TotalHeight;
  private List<ItemData> m_DataList;
  private Vector2 m_PanelSize;
  private GameObject m_Content;
  private RectTransform ContentRect;
  public GameObject m_customItem;
  public PanelObject[] m_PanelObjects;
  public int m_FirstIdx;
  public int m_LastIdx;
  public IUpDateScrollPanel m_handler;
  public int m_ScrollPanelID;

  public void IntiScrollPanel(
    float _PanelHeight,
    float _Border,
    float _Range,
    List<float> _DataHeight,
    int _PanelObjectsCount,
    IUpDateScrollPanel _handler)
  {
    this.m_PanelHeight = _PanelHeight;
    this.m_Border = _Border;
    this.m_Range = _Range;
    this.m_MaxItemOfPage = _PanelObjectsCount;
    this.m_handler = _handler;
    this.m_TotalHeight = this.m_Border;
    this.m_DataList = new List<ItemData>(_DataHeight.Count);
    for (int index = 0; index < _DataHeight.Count; ++index)
    {
      this.m_DataList.Add(new ItemData()
      {
        m_Height = _DataHeight[index],
        m_limitTop = this.m_TotalHeight
      });
      this.m_TotalHeight += _DataHeight[index] + this.m_Range;
    }
    if (this.m_DataList.Count > this.beginIndex)
      this.viewheight += this.m_DataList[this.beginIndex].m_Height + this.m_Range;
    CScrollRect cscrollRect = this.gameObject.AddComponent<CScrollRect>();
    cscrollRect.m_Handler = (IValueChanged) this;
    cscrollRect.horizontal = false;
    cscrollRect.vertical = true;
    cscrollRect.inertia = true;
    cscrollRect.decelerationRate = 0.35f;
    cscrollRect.scrollSensitivity = 1f;
    Mask mask = this.gameObject.AddComponent<Mask>();
    ((Behaviour) mask).enabled = true;
    mask.showMaskGraphic = false;
    this.m_PanelSize = this.gameObject.GetComponent<RectTransform>().rect.size;
    this.m_Content = new GameObject();
    this.m_Content.name = "Content";
    this.ContentRect = this.m_Content.AddComponent<RectTransform>();
    this.ContentRect.anchorMax = new Vector2(0.0f, 1f);
    this.ContentRect.anchorMin = new Vector2(0.0f, 1f);
    this.ContentRect.pivot = new Vector2(0.0f, 1f);
    this.ContentRect.sizeDelta = new Vector2(0.0f, this.m_TotalHeight);
    cscrollRect.content = this.ContentRect;
    this.m_Content.transform.SetParent(this.gameObject.transform, false);
    this.m_PanelObjects = new PanelObject[this.m_MaxItemOfPage];
    for (int index = 0; index < this.m_MaxItemOfPage; ++index)
    {
      Vector2 pos = new Vector2(0.0f, -this.m_Border);
      this.m_PanelObjects[index] = this.AddContentObj(-1, this.m_customItem, pos, 0.0f, this.m_Content);
      this.m_LastIdx = index;
    }
    int panelObjectIdx = this.m_FirstIdx;
    for (int index = 0; index < this.m_MaxItemOfPage && index < this.m_DataList.Count; ++index)
    {
      if (this.m_handler != null && this.beginIndex + index < this.m_DataList.Count)
      {
        this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta.x, this.m_DataList[this.beginIndex + index].m_Height);
        Vector2 vector2 = new Vector2(0.0f, this.m_DataList[this.beginIndex + index].m_limitTop);
        this.m_PanelObjects[panelObjectIdx].rectTransform.anchoredPosition = -vector2;
        this.m_PanelObjects[panelObjectIdx].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + index;
        this.m_handler.UpDateRowItem(this.m_PanelObjects[panelObjectIdx].gameObject, this.beginIndex + index, panelObjectIdx, this.m_ScrollPanelID);
        ++panelObjectIdx;
        if (panelObjectIdx >= this.m_MaxItemOfPage)
          panelObjectIdx = 0;
      }
    }
    if ((bool) (Object) this.m_customItem)
      this.m_customItem.SetActive(false);
    this.MyUpdate();
  }

  public void onValueChanged() => this.MyUpdate();

  public int GetBeginIdx() => this.beginIndex;

  public int GetTopIdx()
  {
    if ((Object) this.ContentRect == (Object) null || this.m_PanelObjects == null)
      return -1;
    float y = this.ContentRect.anchoredPosition.y;
    for (int index = 0; index < this.m_MaxItemOfPage; ++index)
    {
      int btnId1 = this.m_PanelObjects[index].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1;
      if (btnId1 != -1 && (Mathf.Approximately(y, -this.m_PanelObjects[index].rectTransform.anchoredPosition.y) || (double) y >= -(double) this.m_PanelObjects[index].rectTransform.anchoredPosition.y) && (double) y <= -(double) this.m_PanelObjects[index].rectTransform.anchoredPosition.y + (double) this.m_PanelObjects[index].rectTransform.sizeDelta.y + (double) this.m_Range)
        return btnId1;
    }
    return -1;
  }

  public void AddItem(float height, bool bMoveToLast = false)
  {
    this.m_DataList.Add(new ItemData()
    {
      m_Height = height,
      m_limitTop = this.m_TotalHeight
    });
    this.m_TotalHeight += height + this.m_Range;
    this.ContentRect.sizeDelta = new Vector2(0.0f, this.m_TotalHeight);
    int panelObjectIdx;
    if (this.m_DataList.Count >= this.m_FirstIdx)
    {
      panelObjectIdx = this.m_FirstIdx;
    }
    else
    {
      panelObjectIdx = 0;
      this.m_LastIdx = 0;
    }
    for (int index = 0; index < this.m_MaxItemOfPage && index < this.m_DataList.Count; ++index)
    {
      if (this.m_handler != null && this.beginIndex + index < this.m_DataList.Count)
      {
        this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta.x, this.m_DataList[this.beginIndex + index].m_Height);
        Vector2 vector2 = new Vector2(0.0f, this.m_DataList[this.beginIndex + index].m_limitTop);
        this.m_PanelObjects[panelObjectIdx].rectTransform.anchoredPosition = -vector2;
        this.m_PanelObjects[panelObjectIdx].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + index;
        this.m_handler.UpDateRowItem(this.m_PanelObjects[panelObjectIdx].gameObject, this.beginIndex + index, panelObjectIdx, this.m_ScrollPanelID);
      }
      else
      {
        Vector2 vector2 = new Vector2(0.0f, this.ContentRect.anchoredPosition.y + this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta.y + this.m_Range);
        this.m_PanelObjects[panelObjectIdx].rectTransform.anchoredPosition = vector2;
        this.m_PanelObjects[panelObjectIdx].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = -1;
      }
      ++panelObjectIdx;
      if (panelObjectIdx >= this.m_MaxItemOfPage)
        panelObjectIdx = 0;
    }
    this.MyUpdate();
    if (!bMoveToLast)
      return;
    if ((double) this.ContentRect.sizeDelta.y <= (double) this.m_PanelHeight)
      this.ContentRect.anchoredPosition = new Vector2(0.0f, 0.0f);
    else
      this.ContentRect.anchoredPosition = new Vector2(0.0f, this.m_TotalHeight - this.m_PanelHeight);
  }

  public void AddNewDataHeight(List<float> _DataHeight, bool IsSetBeginPos = true, bool bSoptMove = true)
  {
    this.m_DataList.Clear();
    this.m_TotalHeight = this.m_Border;
    for (int index = 0; index < _DataHeight.Count; ++index)
    {
      this.m_DataList.Add(new ItemData()
      {
        m_Height = _DataHeight[index],
        m_limitTop = this.m_TotalHeight
      });
      this.m_TotalHeight += _DataHeight[index] + this.m_Range;
    }
    this.ContentRect.sizeDelta = new Vector2(0.0f, this.m_TotalHeight);
    if (IsSetBeginPos)
    {
      this.ContentRect.anchoredPosition = new Vector2(0.0f, 0.0f);
      this.beginIndex = 0;
      this.m_FirstIdx = 0;
      this.m_LastIdx = 0;
    }
    if (_DataHeight.Count > 0 && this.beginIndex >= _DataHeight.Count)
      this.beginIndex = _DataHeight.Count - 1;
    int panelObjectIdx = this.m_FirstIdx;
    for (int index = 0; index < this.m_MaxItemOfPage; ++index)
    {
      if (this.m_handler != null)
      {
        if (this.beginIndex + index >= 0 && this.beginIndex + index < _DataHeight.Count)
        {
          Vector2 vector2 = new Vector2(0.0f, this.m_DataList[this.beginIndex + index].m_limitTop);
          this.m_PanelObjects[panelObjectIdx].rectTransform.anchoredPosition = -vector2;
          this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta.x, _DataHeight[this.beginIndex + index]);
          this.m_PanelObjects[panelObjectIdx].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + index;
          this.m_handler.UpDateRowItem(this.m_PanelObjects[panelObjectIdx].gameObject, this.beginIndex + index, panelObjectIdx, this.m_ScrollPanelID);
        }
        else
        {
          Vector2 vector2 = new Vector2(0.0f, this.ContentRect.anchoredPosition.y + this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta.y + this.m_Range);
          this.m_PanelObjects[panelObjectIdx].rectTransform.anchoredPosition = vector2;
          this.m_PanelObjects[panelObjectIdx].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = -1;
        }
        ++panelObjectIdx;
        if (panelObjectIdx >= this.m_MaxItemOfPage)
          panelObjectIdx = 0;
      }
    }
    this.MyUpdate();
    if (!bSoptMove)
      return;
    CScrollRect component = this.gameObject.GetComponent<CScrollRect>();
    if (!((Object) component != (Object) null))
      return;
    component.StopMovement();
  }

  public void AddNewDataHeight(List<float> _DataHeight, float newHeight, bool IsSetBeginPos = true)
  {
    this.m_PanelHeight = newHeight;
    this.m_DataList.Clear();
    this.m_TotalHeight = this.m_Border;
    for (int index = 0; index < _DataHeight.Count; ++index)
    {
      this.m_DataList.Add(new ItemData()
      {
        m_Height = _DataHeight[index],
        m_limitTop = this.m_TotalHeight
      });
      this.m_TotalHeight += _DataHeight[index] + this.m_Range;
    }
    this.ContentRect.sizeDelta = new Vector2(0.0f, this.m_TotalHeight);
    if (IsSetBeginPos)
    {
      this.ContentRect.anchoredPosition = new Vector2(0.0f, 0.0f);
      this.beginIndex = 0;
      this.m_FirstIdx = 0;
      this.m_LastIdx = 0;
    }
    int panelObjectIdx = this.m_FirstIdx;
    for (int index = 0; index < this.m_MaxItemOfPage; ++index)
    {
      if (this.m_handler != null)
      {
        if (this.beginIndex + index < _DataHeight.Count)
        {
          Vector2 vector2 = new Vector2(0.0f, this.m_DataList[this.beginIndex + index].m_limitTop);
          this.m_PanelObjects[panelObjectIdx].rectTransform.anchoredPosition = -vector2;
          this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta.x, _DataHeight[this.beginIndex + index]);
          this.m_PanelObjects[panelObjectIdx].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + index;
          this.m_handler.UpDateRowItem(this.m_PanelObjects[panelObjectIdx].gameObject, this.beginIndex + index, panelObjectIdx, this.m_ScrollPanelID);
        }
        else
        {
          Vector2 vector2 = new Vector2(0.0f, this.ContentRect.anchoredPosition.y + this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta.y + this.m_Range);
          this.m_PanelObjects[panelObjectIdx].rectTransform.anchoredPosition = vector2;
          this.m_PanelObjects[panelObjectIdx].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = -1;
        }
        ++panelObjectIdx;
        if (panelObjectIdx >= this.m_MaxItemOfPage)
          panelObjectIdx = 0;
      }
    }
    this.MyUpdate();
    CScrollRect component = this.gameObject.GetComponent<CScrollRect>();
    if (!((Object) component != (Object) null))
      return;
    component.StopMovement();
  }

  public void GoTo(int itemidx)
  {
    if (itemidx < 0 || itemidx >= this.m_DataList.Count || (double) this.ContentRect.sizeDelta.y <= (double) this.m_PanelHeight)
      return;
    CScrollRect component = this.gameObject.GetComponent<CScrollRect>();
    if ((Object) component != (Object) null)
      component.StopMovement();
    this.beginIndex = itemidx;
    float y = 0.0f;
    if (itemidx > 0)
      y = this.m_Border;
    for (int index = 0; index < itemidx; ++index)
    {
      y += this.m_DataList[index].m_Height + this.m_Range;
      if ((double) y > (double) this.m_TotalHeight - (double) this.m_PanelHeight)
      {
        this.beginIndex = index;
        y = this.m_TotalHeight - this.m_PanelSize.y;
        break;
      }
    }
    this.ContentRect.anchoredPosition = new Vector2(0.0f, y);
    int panelObjectIdx = 0;
    this.m_FirstIdx = 0;
    this.m_LastIdx = this.m_MaxItemOfPage - 1;
    for (int index = 0; index < this.m_MaxItemOfPage && index < this.m_DataList.Count; ++index)
    {
      if (this.m_handler != null && this.beginIndex + index < this.m_DataList.Count)
      {
        this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta.x, this.m_DataList[this.beginIndex + index].m_Height);
        Vector2 vector2 = new Vector2(0.0f, this.m_DataList[this.beginIndex + index].m_limitTop);
        this.m_PanelObjects[panelObjectIdx].rectTransform.anchoredPosition = -vector2;
        this.m_PanelObjects[panelObjectIdx].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + index;
        this.m_handler.UpDateRowItem(this.m_PanelObjects[panelObjectIdx].gameObject, this.beginIndex + index, panelObjectIdx, this.m_ScrollPanelID);
      }
      else
      {
        Vector2 vector2 = new Vector2(0.0f, this.ContentRect.anchoredPosition.y + this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta.y + this.m_Range);
        this.m_PanelObjects[panelObjectIdx].rectTransform.anchoredPosition = vector2;
        this.m_PanelObjects[panelObjectIdx].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = -1;
      }
      ++panelObjectIdx;
      if (panelObjectIdx >= this.m_MaxItemOfPage)
        panelObjectIdx = 0;
    }
    this.MyUpdate();
  }

  public void GoTo(int itemidx, float height)
  {
    if (itemidx < 0 || itemidx >= this.m_DataList.Count || (double) this.ContentRect.sizeDelta.y <= (double) this.m_PanelHeight)
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
      num1 += this.m_DataList[index].m_Height + this.m_Range;
      if ((double) num1 > (double) this.m_TotalHeight - (double) this.m_PanelHeight)
      {
        this.beginIndex = index;
        float num2 = this.m_TotalHeight - this.m_PanelSize.y;
        break;
      }
    }
    int panelObjectIdx = 0;
    this.m_FirstIdx = 0;
    this.m_LastIdx = this.m_MaxItemOfPage - 1;
    for (int index = 0; index < this.m_MaxItemOfPage && index < this.m_DataList.Count; ++index)
    {
      if (this.m_handler != null && this.beginIndex + index < this.m_DataList.Count)
      {
        this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta.x, this.m_DataList[this.beginIndex + index].m_Height);
        Vector2 vector2 = new Vector2(0.0f, this.m_DataList[this.beginIndex + index].m_limitTop);
        this.m_PanelObjects[panelObjectIdx].rectTransform.anchoredPosition = -vector2;
        this.m_PanelObjects[panelObjectIdx].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + index;
        this.m_handler.UpDateRowItem(this.m_PanelObjects[panelObjectIdx].gameObject, this.beginIndex + index, panelObjectIdx, this.m_ScrollPanelID);
      }
      else
      {
        Vector2 vector2 = new Vector2(0.0f, this.ContentRect.anchoredPosition.y + this.m_PanelObjects[panelObjectIdx].rectTransform.sizeDelta.y + this.m_Range);
        this.m_PanelObjects[panelObjectIdx].rectTransform.anchoredPosition = vector2;
        this.m_PanelObjects[panelObjectIdx].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = -1;
      }
      ++panelObjectIdx;
      if (panelObjectIdx >= this.m_MaxItemOfPage)
        panelObjectIdx = 0;
    }
    this.ContentRect.anchoredPosition = new Vector2(0.0f, height);
    this.MyUpdate();
  }

  public float GetContentPos() => this.ContentRect.anchoredPosition.y;

  public void GoToLast()
  {
    if (this.CheckAtLast())
      return;
    this.GoTo(this.m_DataList.Count - 1);
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
          component2.sizeDelta = new Vector2(component1.sizeDelta.x, height);
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
    float y = this.ContentRect.anchoredPosition.y;
    if (this.beginIndex < this.m_DataList.Count)
    {
      float num1 = this.m_DataList[this.beginIndex].m_limitTop + this.m_DataList[this.beginIndex].m_Height;
      float num2 = 0.0f;
      if (this.beginIndex > 0)
        num2 = this.m_DataList[this.beginIndex - 1].m_limitTop + this.m_DataList[this.beginIndex - 1].m_Height + this.m_Range;
      bool flag = true;
      for (int index = Mathf.Clamp(this.m_MaxItemOfPage / 2, 1, this.m_MaxItemOfPage); flag && ((double) y > (double) num1 || (double) y < (double) num2) && index > 0; --index)
      {
        if ((double) y > (double) num1)
          flag = this.AddToLast();
        else if ((double) y < (double) num2)
          flag = this.AddToFirst();
        num1 = this.m_DataList[this.beginIndex].m_limitTop + this.m_DataList[this.beginIndex].m_Height;
        if (this.beginIndex > 0)
          num2 = this.m_DataList[this.beginIndex - 1].m_limitTop + this.m_DataList[this.beginIndex - 1].m_Height + this.m_Range;
      }
    }
    for (int index = 0; index < this.m_MaxItemOfPage; ++index)
    {
      if ((double) this.m_PanelObjects[index].rectTransform.anchoredPosition.y - (double) this.m_PanelObjects[index].rectTransform.sizeDelta.y < -(double) y && (double) this.m_PanelObjects[index].rectTransform.anchoredPosition.y > -(double) this.m_PanelSize.y - (double) y && this.m_PanelObjects[index].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 != -1)
      {
        if (!this.m_PanelObjects[index].gameObject.activeSelf)
          this.m_PanelObjects[index].gameObject.SetActive(true);
      }
      else if (this.m_PanelObjects[index].gameObject.activeSelf)
        this.m_PanelObjects[index].gameObject.SetActive(false);
    }
  }

  private bool AddToLast()
  {
    RectTransform rectTransform = this.m_PanelObjects[this.m_FirstIdx].rectTransform;
    int firstIdx = this.m_FirstIdx;
    if (this.beginIndex + this.m_MaxItemOfPage >= this.m_DataList.Count)
      return false;
    float height = this.m_DataList[this.beginIndex + this.m_MaxItemOfPage].m_Height;
    Vector2 vector2 = new Vector2(0.0f, this.m_DataList[this.beginIndex + this.m_MaxItemOfPage].m_limitTop);
    rectTransform.anchoredPosition = -vector2;
    rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);
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
    float height = this.m_DataList[this.beginIndex - 1].m_Height;
    Vector2 vector2 = new Vector2(0.0f, this.m_DataList[this.beginIndex - 1].m_limitTop);
    rectTransform1.anchoredPosition = -vector2;
    rectTransform1.sizeDelta = new Vector2(rectTransform2.sizeDelta.x, height);
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
    return (Object) this.ContentRect == (Object) null || (double) this.ContentRect.sizeDelta.y - (double) this.ContentRect.anchoredPosition.y <= (double) this.m_PanelHeight;
  }

  public bool CheckInPanel(int itemidx)
  {
    if (itemidx >= 0 && itemidx < this.m_DataList.Count && (Object) this.ContentRect != (Object) null && this.m_PanelObjects != null)
    {
      float y = this.ContentRect.anchoredPosition.y;
      float num = this.ContentRect.anchoredPosition.y + this.m_PanelHeight;
      float limitTop = this.m_DataList[itemidx].m_limitTop;
      if ((double) (this.m_DataList[itemidx].m_limitTop + this.m_DataList[itemidx].m_Height) >= (double) y && (double) limitTop <= (double) num)
        return true;
    }
    return false;
  }

  public void ButtonOnClick(ScrollPanelItem sender)
  {
    if (this.m_handler == null)
      return;
    this.m_handler.ButtonOnClick(((Component) sender).gameObject, sender.m_BtnID1, this.m_ScrollPanelID);
  }
}
