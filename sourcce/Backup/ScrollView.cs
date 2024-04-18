// Decompiled with JetBrains decompiler
// Type: ScrollView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ScrollView : MonoBehaviour, IValueChanged, IScrollItemHandler
{
  private ItemObject[] gameObjectLink;
  private int headIndex;
  private int endIndex;
  private int NowIndex = 1;
  private int MaxIndex;
  private int MaxSize;
  private IUpDateRowItem handler;
  private GameObject[] resGameObjs;
  private int[] btnIndexs;
  private GameObject Content;
  private RectTransform rt;
  private RectTransform contentRt;
  private Vector2 PovitV2 = new Vector2(0.0f, 1f);
  private Vector2 AnchorMaxV2 = new Vector2(0.0f, 1f);
  private Vector2 AnchorMinV2 = new Vector2(0.0f, 1f);
  private Vector2 tempV2 = new Vector2(0.0f, 0.0f);
  private Vector2 posV2 = new Vector2(100f, 100f);
  public GameObject customItem;
  public int countX;
  public int countY;
  public float btnSzieX;
  public float btnSzieY;
  public float rangeSzieX;
  public float rangeSzieY;
  public float borderX;
  public float borderY;
  private float showSize;
  public bool bVertical = true;
  public bool bShowInEditor;
  private bool bIsBatch = true;
  private ScrollView.e_InitState initState;
  private int initInddex;
  private int tempGameObjectLinkIndex;
  private int initDataSize;
  private float preContentPosY;
  private float[] itemPosArray;
  private int[] idArray;
  private ScrollViewIndexValue scrollValue;
  private bool bInitScroll = true;
  private ScrollView.e_Arrangement Arrangement;
  private Mask mask;

  private void Update()
  {
    if (this.bVertical)
    {
      if (this.initState == ScrollView.e_InitState.e_first)
      {
        this.bInitScroll = false;
        this.gameObjectLink = new ItemObject[this.countX * (this.countY + 2)];
        this.resGameObjs = new GameObject[this.countX];
        this.btnIndexs = new int[this.countX];
        this.initState = ScrollView.e_InitState.e_middle;
      }
      if (this.initState == ScrollView.e_InitState.e_middle)
      {
        this.posV2.x = this.borderX;
        this.posV2.y = (float) (-(double) this.borderY - (double) this.initInddex * ((double) this.btnSzieY + (double) this.rangeSzieY));
        for (int index = 0; index < this.countX; ++index)
        {
          this.posV2.x = this.borderX + (float) index * (this.btnSzieX + this.rangeSzieX);
          int btnID = index + this.countX * this.initInddex;
          if (this.itemPosArray != null && this.idArray != null)
          {
            int idx = index + this.countX * this.initInddex;
            if (idx >= 0 && idx < this.idArray.Length)
              btnID = this.idArray[idx];
            this.posV2.y = this.GetPosByContentPosY(idx);
          }
          ItemObject itemObject = this.AddContentObj(this.posV2, btnID, this.customItem);
          if (this.tempGameObjectLinkIndex < this.initDataSize && btnID < this.MaxSize)
            itemObject.gameObject.SetActive(true);
          else
            itemObject.gameObject.SetActive(false);
          this.gameObjectLink[this.tempGameObjectLinkIndex] = itemObject;
          this.resGameObjs[index] = itemObject.gameObject;
          this.btnIndexs[index] = btnID;
          ++this.tempGameObjectLinkIndex;
        }
        if (this.handler != null)
          this.handler.UpDateRowItem(this.resGameObjs, this.btnIndexs);
        this.endIndex = this.tempGameObjectLinkIndex - 1;
        this.customItem.SetActive(false);
        ++this.initInddex;
        if (this.initInddex >= this.countY + 2)
          this.initState = ScrollView.e_InitState.e_last;
      }
      if (this.initState != ScrollView.e_InitState.e_last)
        return;
      this.showSize = this.gameObject.GetComponent<RectTransform>().sizeDelta.y;
      this.initState = ScrollView.e_InitState.e_end;
      if (this.idArray != null)
        this.SetScrollViewIndexValue(this.scrollValue);
      if (this.handler != null)
        this.handler.Initialized();
      this.UpdateScrollRect();
      this.bInitScroll = true;
    }
    else
    {
      if (this.initState == ScrollView.e_InitState.e_first)
      {
        this.gameObjectLink = new ItemObject[(this.countX + 2) * this.countY];
        this.resGameObjs = new GameObject[this.countY];
        this.btnIndexs = new int[this.countY];
        this.initState = ScrollView.e_InitState.e_middle;
      }
      if (this.initState == ScrollView.e_InitState.e_middle)
      {
        if (this.tempGameObjectLinkIndex < this.initDataSize)
          this.customItem.SetActive(true);
        if (this.Arrangement == ScrollView.e_Arrangement.LeftToRight)
        {
          this.posV2.x = this.borderX + (float) this.initInddex * (this.btnSzieX + this.rangeSzieX);
          this.posV2.y = -this.borderY;
          for (int index = 0; index < this.countY; ++index)
          {
            this.posV2.y = (float) (-(double) this.borderY - (double) index * ((double) this.btnSzieY + (double) this.rangeSzieY));
            int btnID = index + this.countY * this.initInddex;
            ItemObject itemObject = this.AddContentObj(this.posV2, btnID, this.customItem);
            this.gameObjectLink[this.tempGameObjectLinkIndex] = itemObject;
            this.resGameObjs[index] = itemObject.gameObject;
            this.btnIndexs[index] = btnID;
            ++this.tempGameObjectLinkIndex;
          }
          if (this.handler != null)
            this.handler.UpDateRowItem(this.resGameObjs, this.btnIndexs);
          this.endIndex = this.tempGameObjectLinkIndex - 1;
          if (this.initInddex >= this.countY + 2)
            this.initState = ScrollView.e_InitState.e_last;
        }
      }
      if (this.initState != ScrollView.e_InitState.e_last)
        return;
      this.showSize = this.gameObject.GetComponent<RectTransform>().sizeDelta.x;
      this.initState = ScrollView.e_InitState.e_end;
      if (this.handler != null)
        this.handler.Initialized();
      this.UpdateScrollRect();
    }
  }

  public void InitScrollView(
    bool _bIsBatch,
    float posY = 0,
    float[] _itemPosArray = null,
    float _contentHeight = 0.0f,
    int[] _idArray = null,
    [Optional] ScrollViewIndexValue _value)
  {
    this.preContentPosY = posY;
    this.bIsBatch = _bIsBatch;
    CScrollRect cscrollRect = this.gameObject.AddComponent<CScrollRect>();
    cscrollRect.m_Handler = (IValueChanged) this;
    cscrollRect.horizontal = !this.bVertical;
    cscrollRect.vertical = this.bVertical;
    cscrollRect.inertia = true;
    cscrollRect.decelerationRate = 0.35f;
    cscrollRect.scrollSensitivity = 1f;
    this.mask = this.gameObject.AddComponent<Mask>();
    ((Behaviour) this.mask).enabled = true;
    this.mask.showMaskGraphic = false;
    this.rt = this.gameObject.GetComponent<RectTransform>();
    this.Content = new GameObject();
    this.Content.name = "Content";
    this.rt = this.Content.AddComponent<RectTransform>();
    cscrollRect.content = this.rt;
    this.Content.transform.SetParent(this.gameObject.transform, false);
    this.posV2.x = 0.0f;
    this.posV2.y = this.preContentPosY;
    if (this.bVertical)
      this.tempV2.y = (float) (this.countY + 2) * (this.btnSzieY + this.rangeSzieY) + this.rangeSzieY;
    else
      this.tempV2.x = (float) (this.countX + 1) * (this.btnSzieX + this.rangeSzieX) + this.rangeSzieX;
    if ((double) this.preContentPosY > 0.0)
      this.tempV2.y = _contentHeight;
    this.SetPos(this.rt, this.tempV2, this.posV2);
    this.itemPosArray = _itemPosArray;
    this.idArray = _idArray;
    this.scrollValue = _value;
    if (!this.bIsBatch)
      return;
    if (this.bVertical)
    {
      this.gameObjectLink = new ItemObject[this.countX * (this.countY + 2)];
      this.resGameObjs = new GameObject[this.countX];
      this.btnIndexs = new int[this.countX];
      for (int index1 = 0; index1 < this.countY + 2; ++index1)
      {
        this.posV2.x = this.borderX;
        this.posV2.y = (float) (-(double) this.borderY - (double) index1 * ((double) this.btnSzieY + (double) this.rangeSzieY));
        for (int index2 = 0; index2 < this.countX; ++index2)
        {
          this.posV2.x = this.borderX + (float) index2 * (this.btnSzieX + this.rangeSzieX);
          int btnID = index2 + this.countX * index1;
          ItemObject itemObject = this.AddContentObj(this.posV2, btnID, this.customItem);
          this.gameObjectLink[this.tempGameObjectLinkIndex] = itemObject;
          this.resGameObjs[index2] = itemObject.gameObject;
          this.btnIndexs[index2] = btnID;
          ++this.tempGameObjectLinkIndex;
        }
        if (this.handler != null)
          this.handler.UpDateRowItem(this.resGameObjs, this.btnIndexs);
      }
      this.endIndex = this.tempGameObjectLinkIndex - 1;
      this.showSize = this.gameObject.GetComponent<RectTransform>().sizeDelta.y;
    }
    else
    {
      this.gameObjectLink = new ItemObject[(this.countX + 2) * this.countY];
      this.resGameObjs = new GameObject[this.countY];
      this.btnIndexs = new int[this.countY];
      if (this.Arrangement == ScrollView.e_Arrangement.LeftToRight)
      {
        for (int index3 = 0; index3 < this.countX + 2; ++index3)
        {
          this.posV2.x = this.borderX + (float) index3 * (this.btnSzieX + this.rangeSzieX);
          this.posV2.y = -this.borderY;
          for (int index4 = 0; index4 < this.countY; ++index4)
          {
            this.posV2.y = (float) (-(double) this.borderY - (double) index4 * ((double) this.btnSzieY + (double) this.rangeSzieY));
            int btnID = index4 + this.countY * index3;
            ItemObject itemObject = this.AddContentObj(this.posV2, btnID, this.customItem);
            this.gameObjectLink[this.tempGameObjectLinkIndex] = itemObject;
            this.resGameObjs[index4] = itemObject.gameObject;
            this.btnIndexs[index4] = btnID;
            ++this.tempGameObjectLinkIndex;
          }
          if (this.handler != null)
            this.handler.UpDateRowItem(this.resGameObjs, this.btnIndexs);
        }
        this.endIndex = this.tempGameObjectLinkIndex - 1;
        this.showSize = this.gameObject.GetComponent<RectTransform>().sizeDelta.x;
      }
    }
    this.initState = ScrollView.e_InitState.e_end;
    this.customItem.SetActive(false);
    this.SetContentSize(1);
    this.UpdateScrollRect();
  }

  private ItemObject AddContentObj(Vector2 pos, int btnID, GameObject item = null)
  {
    ItemObject itemObject = new ItemObject();
    GameObject gameObject = Object.Instantiate((Object) this.customItem) as GameObject;
    ScrollItem component1 = gameObject.GetComponent<ScrollItem>();
    component1.m_BtnID1 = btnID;
    component1.m_Handler = (IScrollItemHandler) this;
    RectTransform component2 = gameObject.GetComponent<RectTransform>();
    if ((bool) (Object) component2)
    {
      this.tempV2.x = this.btnSzieX;
      this.tempV2.y = this.btnSzieY;
      this.SetPos(component2, this.tempV2, pos);
      gameObject.transform.SetParent(this.Content.transform, false);
    }
    itemObject.rectTransform = component2;
    itemObject.scrollItem = component1;
    itemObject.gameObject = gameObject;
    return itemObject;
  }

  private void SetPos(RectTransform rt, Vector2 size, Vector2 pos)
  {
    rt.anchorMax = this.AnchorMaxV2;
    rt.anchorMin = this.AnchorMinV2;
    rt.pivot = this.PovitV2;
    rt.sizeDelta = size;
    rt.anchoredPosition = pos;
  }

  private void AddToHead()
  {
    if (this.bVertical)
    {
      this.tempV2.x = 0.0f;
      this.tempV2.y = this.btnSzieY + this.rangeSzieY;
      ItemObject itemObject1 = this.gameObjectLink[this.headIndex];
      if (itemObject1 == null)
        return;
      this.posV2 = itemObject1.rectTransform.anchoredPosition;
      --this.NowIndex;
      for (int index = this.countX - 1; index >= 0; --index)
      {
        this.tempV2.x = this.btnSzieX + this.rangeSzieX;
        ItemObject itemObject2 = this.gameObjectLink[this.endIndex];
        Vector2 anchoredPosition = itemObject2.rectTransform.anchoredPosition with
        {
          y = Mathf.Round(this.tempV2.y + this.posV2.y)
        };
        itemObject2.rectTransform.anchoredPosition = anchoredPosition;
        this.headIndex = this.endIndex;
        if (this.headIndex >= 1)
        {
          --this.endIndex;
        }
        else
        {
          this.headIndex = 0;
          this.endIndex = this.gameObjectLink.Length - 1;
        }
        this.resGameObjs[index] = itemObject2.gameObject;
        int num = (this.NowIndex - 1) * this.countX + index;
        this.btnIndexs[index] = num;
        itemObject2.scrollItem.m_BtnID1 = num;
      }
    }
    else
    {
      this.tempV2.x = -this.btnSzieX - this.rangeSzieX;
      this.tempV2.y = 0.0f;
      ItemObject itemObject3 = this.gameObjectLink[this.headIndex];
      if (itemObject3 == null)
        return;
      this.posV2 = itemObject3.rectTransform.anchoredPosition;
      --this.NowIndex;
      for (int index = this.countY - 1; index >= 0; --index)
      {
        this.tempV2.y = -this.btnSzieY - this.rangeSzieY;
        ItemObject itemObject4 = this.gameObjectLink[this.endIndex];
        Vector2 anchoredPosition = itemObject4.rectTransform.anchoredPosition with
        {
          x = Mathf.Round(this.tempV2.x + this.posV2.x)
        };
        itemObject4.rectTransform.anchoredPosition = anchoredPosition;
        this.headIndex = this.endIndex;
        if (this.headIndex >= 1)
        {
          --this.endIndex;
        }
        else
        {
          this.headIndex = 0;
          this.endIndex = this.gameObjectLink.Length - 1;
        }
        this.resGameObjs[index] = itemObject4.gameObject;
        int num = (this.NowIndex - 1) * this.countY + index;
        this.btnIndexs[index] = num;
        itemObject4.scrollItem.m_BtnID1 = num;
      }
    }
    if (this.handler == null)
      return;
    this.handler.UpDateRowItem(this.resGameObjs, this.btnIndexs);
  }

  private void AddToEnd()
  {
    if (this.bVertical)
    {
      this.tempV2.x = 0.0f;
      this.tempV2.y = (float) (-(double) this.btnSzieY + -(double) this.rangeSzieY);
      ItemObject itemObject1 = this.gameObjectLink[this.endIndex];
      if (itemObject1 == null)
        return;
      this.posV2 = itemObject1.rectTransform.anchoredPosition;
      ++this.NowIndex;
      for (int index = 0; index < this.countX; ++index)
      {
        this.tempV2.x = this.btnSzieX + this.rangeSzieX;
        ItemObject itemObject2 = this.gameObjectLink[this.headIndex];
        Vector2 anchoredPosition = itemObject2.rectTransform.anchoredPosition with
        {
          y = Mathf.Round(this.tempV2.y + this.posV2.y)
        };
        itemObject2.rectTransform.anchoredPosition = anchoredPosition;
        this.endIndex = this.headIndex;
        if (this.headIndex < this.gameObjectLink.Length - 1)
          ++this.headIndex;
        else
          this.headIndex = 0;
        int num = (this.NowIndex + this.countY) * this.countX + index;
        this.resGameObjs[index] = itemObject2.gameObject;
        this.btnIndexs[index] = num;
        itemObject2.scrollItem.m_BtnID1 = num;
      }
    }
    else
    {
      this.tempV2.x = this.btnSzieX + this.rangeSzieX;
      this.tempV2.y = 0.0f;
      ItemObject itemObject3 = this.gameObjectLink[this.endIndex];
      if (itemObject3 == null)
        return;
      this.posV2 = itemObject3.rectTransform.anchoredPosition;
      ++this.NowIndex;
      for (int index = 0; index < this.countY; ++index)
      {
        this.tempV2.y = this.btnSzieY + this.rangeSzieY;
        ItemObject itemObject4 = this.gameObjectLink[this.headIndex];
        Vector2 anchoredPosition = itemObject4.rectTransform.anchoredPosition with
        {
          x = Mathf.Round(this.tempV2.x + this.posV2.x)
        };
        itemObject4.rectTransform.anchoredPosition = anchoredPosition;
        this.endIndex = this.headIndex;
        if (this.headIndex < this.gameObjectLink.Length - 1)
          ++this.headIndex;
        else
          this.headIndex = 0;
        int num = (this.NowIndex + this.countX) * this.countY + index;
        this.resGameObjs[index] = itemObject4.gameObject;
        this.btnIndexs[index] = num;
        itemObject4.scrollItem.m_BtnID1 = num;
      }
    }
    if (this.handler == null)
      return;
    this.handler.UpDateRowItem(this.resGameObjs, this.btnIndexs);
  }

  private void Check(ItemObject itemObject)
  {
    if (itemObject == null)
      return;
    if (itemObject.scrollItem.m_BtnID1 >= this.MaxSize)
      itemObject.gameObject.SetActive(false);
    else
      itemObject.gameObject.SetActive(true);
  }

  private void CheckCanShowInMaskPanel()
  {
    if (this.bVertical)
    {
      float y = this.rt.anchoredPosition.y;
      float num1 = y + this.showSize;
      for (int index = 0; index < this.gameObjectLink.Length; ++index)
      {
        int btnId1 = this.gameObjectLink[index].scrollItem.m_BtnID1;
        float num2 = Mathf.Abs(this.gameObjectLink[index].rectTransform.anchoredPosition.y);
        float num3 = num2 + this.gameObjectLink[index].rectTransform.sizeDelta.y;
        if ((double) y > (double) num3 || (double) num1 < (double) num2 || btnId1 >= this.MaxSize)
        {
          if (this.gameObjectLink[index].gameObject.activeSelf)
            this.gameObjectLink[index].gameObject.SetActive(false);
        }
        else if (!this.gameObjectLink[index].gameObject.activeSelf)
          this.gameObjectLink[index].gameObject.SetActive(true);
      }
    }
    else
    {
      float num4 = Mathf.Abs(this.rt.anchoredPosition.x);
      float num5 = num4 + this.showSize;
      for (int index = 0; index < this.gameObjectLink.Length; ++index)
      {
        float num6 = Mathf.Abs(this.gameObjectLink[index].rectTransform.anchoredPosition.x);
        float num7 = num6 + this.gameObjectLink[index].rectTransform.sizeDelta.x;
        int btnId1 = this.gameObjectLink[index].scrollItem.m_BtnID1;
        if ((double) num4 > (double) num7 || (double) num5 < (double) num6 || btnId1 >= this.MaxSize)
        {
          if (this.gameObjectLink[index].gameObject.activeSelf)
            this.gameObjectLink[index].gameObject.SetActive(false);
        }
        else if (!this.gameObjectLink[index].gameObject.activeSelf)
          this.gameObjectLink[index].gameObject.SetActive(true);
      }
    }
  }

  public void SetContentSize(int size)
  {
    if (this.initState != ScrollView.e_InitState.e_end)
      return;
    if (size <= 0)
    {
      this.MaxSize = 0;
      this.MaxIndex = 0;
    }
    else if (this.bVertical)
    {
      this.MaxSize = size;
      int num = this.MaxSize % this.countX != 0 ? this.MaxSize / this.countX + 1 : this.MaxSize / this.countX;
      this.tempV2.y = (float) num * (this.btnSzieY + this.rangeSzieY) + this.rangeSzieY;
      this.tempV2.x = this.rt.sizeDelta.x;
      this.rt.sizeDelta = this.tempV2;
      this.MaxIndex = num - this.countY;
    }
    else
    {
      this.MaxSize = size;
      int num = this.MaxSize % this.countY != 0 ? this.MaxSize / this.countY + 1 : this.MaxSize / this.countY;
      this.tempV2.x = (float) num * (this.btnSzieX + this.rangeSzieX) + this.rangeSzieX;
      this.tempV2.y = this.rt.sizeDelta.y;
      this.rt.sizeDelta = this.tempV2;
      this.MaxIndex = num - this.countX;
    }
    int length = this.gameObjectLink.Length;
    for (int index = 0; index < length; ++index)
    {
      if (this.gameObjectLink[index] != null && (Object) this.gameObjectLink[index].gameObject != (Object) null)
        this.Check(this.gameObjectLink[index]);
    }
  }

  public void UpdateScrollRect()
  {
    if (this.initState != ScrollView.e_InitState.e_end)
      return;
    if (this.bVertical)
    {
      float num1 = (float) this.NowIndex * (this.btnSzieY + this.rangeSzieY);
      float num2 = (float) (this.NowIndex - 1) * (this.btnSzieY + this.rangeSzieY);
      if ((double) this.rt.anchoredPosition.y > (double) num1 && this.NowIndex < this.MaxIndex - 1)
        this.AddToEnd();
      else if (this.NowIndex > 1 && (double) this.rt.anchoredPosition.y < (double) num2)
        this.AddToHead();
    }
    else
    {
      float num3 = (float) -this.NowIndex * (this.btnSzieX + this.rangeSzieX);
      float num4 = (float) (this.NowIndex - 1) * (float) (-(double) this.btnSzieX + -(double) this.rangeSzieX);
      if ((double) this.rt.anchoredPosition.x < (double) num3 && this.NowIndex < this.MaxIndex - 1)
        this.AddToEnd();
      else if (this.NowIndex > 1 && (double) this.rt.anchoredPosition.x > (double) num4)
        this.AddToHead();
    }
    if (this.handler != null)
      this.handler.OnScroll(this.rt);
    this.CheckCanShowInMaskPanel();
  }

  public void Clear()
  {
  }

  public void Show()
  {
  }

  private float GetPosByContentPosY(int idx)
  {
    return this.itemPosArray != null && idx >= 0 && idx < this.itemPosArray.Length ? this.itemPosArray[idx] : 0.0f;
  }

  public float[] GetItemsPos()
  {
    int childCount = this.transform.GetChild(0).childCount;
    float[] numArray = new float[childCount];
    for (int index = 0; index < childCount; ++index)
      numArray[index] = this.transform.GetChild(0).GetChild(index).GetComponent<RectTransform>().anchoredPosition.y;
    return childCount > 0 ? numArray : (float[]) null;
  }

  public int[] GetItemsBtnID()
  {
    int childCount = this.transform.GetChild(0).childCount;
    int[] numArray = new int[childCount];
    for (int index = 0; index < childCount; ++index)
      numArray[index] = this.transform.GetChild(0).GetChild(index).GetComponent<ScrollItem>().m_BtnID1;
    return childCount > 0 ? numArray : (int[]) null;
  }

  public ScrollViewIndexValue GetScrollViewIndexValue()
  {
    ScrollViewIndexValue scrollViewIndexValue;
    scrollViewIndexValue.headIndex = this.headIndex;
    scrollViewIndexValue.endIndex = this.endIndex;
    scrollViewIndexValue.NowIndex = this.NowIndex;
    scrollViewIndexValue.MaxIndex = this.MaxIndex;
    scrollViewIndexValue.MaxSize = this.MaxSize;
    return scrollViewIndexValue;
  }

  public void SetScrollViewIndexValue(ScrollViewIndexValue _velue)
  {
    this.headIndex = _velue.headIndex;
    this.endIndex = _velue.endIndex;
    this.NowIndex = _velue.NowIndex;
    this.MaxIndex = _velue.MaxIndex;
    this.MaxSize = _velue.MaxSize;
  }

  public void SetContentPos(
    float posY = 0,
    float[] _itemPosArray = null,
    float height = 0.0f,
    int[] _idArray = null,
    [Optional] ScrollViewIndexValue _value)
  {
    int childCount = this.transform.GetChild(0).childCount;
    RectTransform component = this.transform.GetChild(0).GetComponent<RectTransform>();
    Vector2 anchoredPosition = component.anchoredPosition with
    {
      y = posY
    };
    component.anchoredPosition = anchoredPosition;
  }

  public void AddHender(
    IUpDateRowItem _handler,
    bool bIsBatch = true,
    int _initDataSize = 0,
    int _MaxSize = 0,
    float posY = 0.0f,
    float[] _itemPosArray = null,
    float height = 0.0f,
    int[] _idArray = null,
    [Optional] ScrollViewIndexValue _value)
  {
    if (this.handler != null)
      return;
    this.handler = _handler;
    this.InitScrollView(bIsBatch, posY, _itemPosArray, height, _idArray, _value);
    this.initDataSize = _initDataSize;
    this.MaxSize = _MaxSize;
  }

  public void UpDateAllItem()
  {
    if (this.initState != ScrollView.e_InitState.e_end)
      return;
    int length = this.gameObjectLink.Length;
    int index1 = 0;
    for (int index2 = 0; index2 < this.resGameObjs.Length; ++index2)
      this.UpdateScrollRect();
    if (this.handler == null)
      return;
    for (int index3 = 0; index3 < length; ++index3)
    {
      this.resGameObjs[index1] = this.gameObjectLink[index3].gameObject;
      this.btnIndexs[index1] = this.gameObjectLink[index3].scrollItem.m_BtnID1;
      ++index1;
      if (index1 >= this.resGameObjs.Length)
      {
        this.handler.UpDateRowItem(this.resGameObjs, this.btnIndexs);
        index1 = 0;
      }
    }
  }

  public void ButtonOnClick(ScrollItem sender)
  {
    if (!(bool) (Object) sender || this.handler == null)
      return;
    this.handler.ButtonOnClick(((Component) sender).gameObject, sender.m_BtnID1);
  }

  public void onValueChanged() => this.UpdateScrollRect();

  public bool IsInitState() => this.initState == ScrollView.e_InitState.e_middle;

  public bool CheckInitScroll() => this.bInitScroll;

  private enum e_InitState
  {
    e_first,
    e_middle,
    e_last,
    e_end,
  }

  public enum e_Arrangement
  {
    LeftToRight,
    RightToLeft,
  }
}
