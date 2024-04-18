// Decompiled with JetBrains decompiler
// Type: UISuitBuilding
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UISuitBuilding : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const int MaxSortType = 3;
  private UIButton m_ExitBtn;
  private UIText m_TitleText;
  private ScrollPanel m_ScrollPanel;
  private ScrollPanel m_ArrowScrollPanel;
  private RectTransform m_ScrollContent;
  private RectTransform m_ArrowContent;
  private int m_ArrowIndx;
  private int m_MaxItemDataCount;
  private SuitBuildingItem[] m_ItemDatas;
  private ushort m_BuildKindID;
  private byte m_BuildKind;
  private StringBuilder sb;
  private int m_MaxObjCount = 5;
  private UIText[] m_TextObject1s;
  private UIText[] m_TextObject2s;
  private UIText[] m_TextObject3s;
  private UIText[] m_TextObject4s;
  private Image[] m_ImageObjects;
  private RectTransform[] m_ImageObjectsRt;
  private string m_EmptyString;
  private bool bInitScrollPanel;
  private ushort m_GuideBuildID;
  private List<ushort>[] m_BuildIdList = new List<ushort>[3];

  public ScrollPanel scrollPanel => this.m_ScrollPanel;

  public override void OnOpen(int arg1, int arg2)
  {
    this.m_EmptyString = string.Empty;
    this.sb = new StringBuilder();
    for (int index = 0; index < 3; ++index)
      this.m_BuildIdList[index] = new List<ushort>();
    this.m_BuildKindID = (ushort) arg1;
    this.m_ExitBtn = this.transform.GetChild(7).GetComponent<UIButton>();
    this.m_ExitBtn.m_BtnID1 = 1;
    this.m_ExitBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_TitleText = this.transform.GetChild(6).GetChild(0).GetComponent<UIText>();
    this.m_TitleText.font = GUIManager.Instance.GetTTFFont();
    this.m_ScrollPanel = this.transform.GetChild(2).GetComponent<ScrollPanel>();
    this.m_ArrowScrollPanel = this.transform.GetChild(3).GetComponent<ScrollPanel>();
    this.m_BuildKind = DataManager.Instance.BuildManorData.GetRecordByKey(this.m_BuildKindID).Kind;
    this.SetScrollPanel((int) this.m_BuildKind);
    this.bInitScrollPanel = true;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 1);
    NewbieManager.CheckNewbie((object) this);
    this.m_GuideBuildID = GUIManager.Instance.BuildingData.GuideBuildID;
    if (this.m_GuideBuildID != (ushort) 0)
    {
      for (int index = 0; index < this.m_ItemDatas.Length; ++index)
      {
        if ((int) this.m_ItemDatas[index].BuildID == (int) this.m_GuideBuildID)
        {
          this.SetArrow(true, index);
          this.m_ScrollPanel.GoTo(index);
          this.m_ArrowScrollPanel.GoTo(index);
        }
      }
    }
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_ItemDatas.Length; ++index)
      _DataHeight.Add((float) sbyte.MaxValue);
    this.m_ScrollPanel.AddNewDataHeight(_DataHeight, false);
    this.m_ArrowScrollPanel.AddNewDataHeight(_DataHeight, false);
  }

  public override void OnClose()
  {
    this.m_ExitBtn = (UIButton) null;
    this.m_TitleText = (UIText) null;
    this.m_ScrollPanel = (ScrollPanel) null;
    this.m_TextObject1s = (UIText[]) null;
    this.m_TextObject2s = (UIText[]) null;
    this.m_TextObject3s = (UIText[]) null;
    this.m_TextObject4s = (UIText[]) null;
    this.m_ImageObjects = (Image[]) null;
    this.m_ItemDatas = (SuitBuildingItem[]) null;
    this.sb = (StringBuilder) null;
    for (int index = 0; index < 3; ++index)
    {
      this.m_BuildIdList[index].Clear();
      this.m_BuildIdList[index] = (List<ushort>) null;
    }
    this.m_GuideBuildID = (ushort) 0;
  }

  public override void UpdateUI(int arg1, int arg2) => this.SetScrollPanel((int) this.m_BuildKind);

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.m_TitleText != (Object) null && ((Behaviour) this.m_TitleText).enabled)
    {
      ((Behaviour) this.m_TitleText).enabled = false;
      ((Behaviour) this.m_TitleText).enabled = true;
    }
    for (int index = 0; index < this.m_MaxObjCount; ++index)
    {
      if ((Object) this.m_TextObject1s[index] != (Object) null && ((Behaviour) this.m_TextObject1s[index]).enabled)
      {
        ((Behaviour) this.m_TextObject1s[index]).enabled = false;
        ((Behaviour) this.m_TextObject1s[index]).enabled = true;
      }
      if ((Object) this.m_TextObject2s[index] != (Object) null && ((Behaviour) this.m_TextObject2s[index]).enabled)
      {
        ((Behaviour) this.m_TextObject2s[index]).enabled = false;
        ((Behaviour) this.m_TextObject2s[index]).enabled = true;
      }
      if ((Object) this.m_TextObject3s[index] != (Object) null && ((Behaviour) this.m_TextObject3s[index]).enabled)
      {
        ((Behaviour) this.m_TextObject3s[index]).enabled = false;
        ((Behaviour) this.m_TextObject3s[index]).enabled = true;
      }
      if ((Object) this.m_TextObject4s[index] != (Object) null && ((Behaviour) this.m_TextObject4s[index]).enabled)
      {
        ((Behaviour) this.m_TextObject4s[index]).enabled = false;
        ((Behaviour) this.m_TextObject4s[index]).enabled = true;
      }
    }
  }

  private void Update()
  {
    if (!this.m_ArrowScrollPanel.enabled)
      return;
    this.m_ArrowContent.anchoredPosition = this.m_ScrollContent.anchoredPosition;
  }

  private int SetSortData(int buildManorKind)
  {
    int num = 0;
    DataManager instance = DataManager.Instance;
    for (int index = 0; index < 3; ++index)
      this.m_BuildIdList[index].Clear();
    int tableCount = instance.BuildsTypeData.TableCount;
    for (ushort Index = 0; (int) Index < tableCount; ++Index)
    {
      BuildTypeData recordByIndex = instance.BuildsTypeData.GetRecordByIndex((int) Index);
      if (buildManorKind == (int) recordByIndex.Kind)
      {
        byte index = GUIManager.Instance.BuildingData.CheckLevelupRule(recordByIndex.BuildID, (byte) 1);
        if (index < (byte) 3 && index >= (byte) 0)
        {
          this.m_BuildIdList[(int) index].Add(recordByIndex.BuildID);
          ++num;
        }
      }
    }
    return num;
  }

  private void SetScrollPanel(int buildManorKind)
  {
    ushort[] numArray = new ushort[7]
    {
      (ushort) 0,
      (ushort) 3811,
      (ushort) 3812,
      (ushort) 3813,
      (ushort) 3813,
      (ushort) 3813,
      (ushort) 12098
    };
    this.m_MaxItemDataCount = 0;
    DataManager instance = DataManager.Instance;
    int tableCount = instance.BuildsTypeData.TableCount;
    int index1 = 0;
    List<float> _DataHeight = new List<float>();
    if (buildManorKind >= 0 && buildManorKind < numArray.Length)
      this.m_TitleText.text = instance.mStringTable.GetStringByID((uint) numArray[buildManorKind]);
    this.m_MaxItemDataCount = this.SetSortData(buildManorKind);
    this.m_ItemDatas = new SuitBuildingItem[this.m_MaxItemDataCount];
    for (int index2 = 0; index2 < 3; ++index2)
    {
      int count = this.m_BuildIdList[index2].Count;
      for (int index3 = 0; index3 < count; ++index3)
      {
        ushort InKey = this.m_BuildIdList[index2][index3];
        BuildTypeData recordByKey = instance.BuildsTypeData.GetRecordByKey(InKey);
        this.sb.Length = 0;
        SuitBuildingItem suitBuildingItem = new SuitBuildingItem();
        suitBuildingItem.StrTexts = new string[4];
        suitBuildingItem.StrTexts[0] = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.NameID);
        suitBuildingItem.StrTexts[1] = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.StringID);
        switch (index2)
        {
          case 0:
            suitBuildingItem.StrTexts[2] = this.m_EmptyString;
            break;
          case 1:
            suitBuildingItem.StrTexts[2] = DataManager.Instance.mStringTable.GetStringByID(3815U);
            break;
          case 2:
            suitBuildingItem.StrTexts[2] = DataManager.Instance.mStringTable.GetStringByID(3816U);
            break;
        }
        this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3941U), (object) GUIManager.Instance.BuildingData.GetBuildNumByID(recordByKey.BuildID));
        suitBuildingItem.StrTexts[3] = this.sb.ToString();
        suitBuildingItem.BuildID = recordByKey.BuildID;
        this.m_ItemDatas[index1] = suitBuildingItem;
        ++index1;
        _DataHeight.Add((float) sbyte.MaxValue);
      }
    }
    this.m_TextObject1s = new UIText[this.m_MaxObjCount];
    this.m_TextObject2s = new UIText[this.m_MaxObjCount];
    this.m_TextObject3s = new UIText[this.m_MaxObjCount];
    this.m_TextObject4s = new UIText[this.m_MaxObjCount];
    this.m_ImageObjects = new Image[this.m_MaxObjCount];
    this.m_ImageObjectsRt = new RectTransform[this.m_MaxObjCount];
    if (!this.bInitScrollPanel)
    {
      this.m_ArrowScrollPanel.IntiScrollPanel(561f, 2f, 5f, _DataHeight, 5, (IUpDateScrollPanel) this);
      this.m_ScrollPanel.IntiScrollPanel(561f, 2f, 5f, _DataHeight, this.m_MaxObjCount, (IUpDateScrollPanel) this);
      this.m_ArrowContent = this.transform.GetChild(3).GetChild(0).GetComponent<RectTransform>();
      this.m_ScrollContent = this.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>();
    }
    else
    {
      this.m_ArrowScrollPanel.AddNewDataHeight(_DataHeight);
      this.m_ScrollPanel.AddNewDataHeight(_DataHeight);
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    switch (panelId)
    {
      case 0:
        if (dataIdx >= this.m_MaxItemDataCount)
          break;
        if ((Object) this.m_ImageObjects[panelObjectIdx] == (Object) null)
        {
          this.m_ImageObjects[panelObjectIdx] = item.transform.GetChild(1).GetComponent<Image>();
          this.m_ImageObjectsRt[panelObjectIdx] = item.transform.GetChild(1).GetComponent<RectTransform>();
          this.m_TextObject1s[panelObjectIdx] = item.transform.GetChild(3).GetComponent<UIText>();
          this.m_TextObject1s[panelObjectIdx].font = GUIManager.Instance.GetTTFFont();
          this.m_TextObject2s[panelObjectIdx] = item.transform.GetChild(4).GetComponent<UIText>();
          this.m_TextObject2s[panelObjectIdx].font = GUIManager.Instance.GetTTFFont();
          this.m_TextObject3s[panelObjectIdx] = item.transform.GetChild(5).GetComponent<UIText>();
          this.m_TextObject3s[panelObjectIdx].font = GUIManager.Instance.GetTTFFont();
          this.m_TextObject4s[panelObjectIdx] = item.transform.GetChild(6).GetChild(0).GetComponent<UIText>();
          this.m_TextObject4s[panelObjectIdx].font = GUIManager.Instance.GetTTFFont();
          ((MaskableGraphic) this.m_ImageObjects[panelObjectIdx]).material = GUIManager.Instance.BuildingData.mapspriteManager.SpriteUIMaterial;
        }
        this.m_TextObject1s[panelObjectIdx].text = this.m_ItemDatas[dataIdx].StrTexts[0];
        this.m_TextObject2s[panelObjectIdx].text = this.m_ItemDatas[dataIdx].StrTexts[1];
        if (!this.m_ItemDatas[dataIdx].bCanBuild)
          ((Graphic) this.m_TextObject3s[panelObjectIdx]).color = new Color(0.8f, 0.05f, 0.015f, 1f);
        else
          ((Graphic) this.m_TextObject3s[panelObjectIdx]).color = new Color(0.11f, 0.3f, 0.46f, 1f);
        this.m_TextObject3s[panelObjectIdx].text = this.m_ItemDatas[dataIdx].StrTexts[2];
        if (this.m_BuildKind == (byte) 3)
          ((Component) this.m_TextObject4s[panelObjectIdx]).transform.parent.gameObject.SetActive(false);
        else
          ((Component) this.m_TextObject4s[panelObjectIdx]).transform.parent.gameObject.SetActive(true);
        this.m_TextObject4s[panelObjectIdx].text = this.m_ItemDatas[dataIdx].StrTexts[3];
        Sprite buildSprite = GUIManager.Instance.BuildingData.GetBuildSprite(this.m_ItemDatas[dataIdx].BuildID, (byte) 0);
        if (!((Object) buildSprite != (Object) null))
          break;
        this.m_ImageObjects[panelObjectIdx].sprite = buildSprite;
        float num = 88f / buildSprite.rect.size.y;
        this.m_ImageObjectsRt[panelObjectIdx].sizeDelta = new Vector2(num * buildSprite.rect.size.x, 88f);
        if (!GUIManager.Instance.IsArabic)
          break;
        Vector3 localScale = ((Transform) ((Graphic) this.m_ImageObjects[panelObjectIdx]).rectTransform).localScale with
        {
          x = -1f
        };
        ((Transform) ((Graphic) this.m_ImageObjects[panelObjectIdx]).rectTransform).localScale = localScale;
        break;
      case 1:
        if (dataIdx == this.m_ArrowIndx)
        {
          ((Behaviour) item.transform.GetChild(0).GetComponent<Image>()).enabled = true;
          break;
        }
        ((Behaviour) item.transform.GetChild(0).GetComponent<Image>()).enabled = false;
        break;
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (panelId != 0 || this.m_ItemDatas == null || dataIndex >= this.m_ItemDatas.Length || dataIndex < 0)
      return;
    if (this.m_ItemDatas[dataIndex].BuildID == (ushort) 6)
      menu.OpenMenu(EGUIWindow.UI_Barrack, (int) this.m_BuildKindID);
    else if (this.m_ItemDatas[dataIndex].BuildID == (ushort) 7)
      menu.OpenMenu(EGUIWindow.UI_Hospital, (int) this.m_BuildKindID);
    else if (this.m_ItemDatas[dataIndex].BuildID == (ushort) 12)
      menu.OpenMenu(EGUIWindow.UI_CityWall, (int) this.m_BuildKindID);
    else if (this.m_ItemDatas[dataIndex].BuildID == (ushort) 19)
      menu.OpenMenu(EGUIWindow.UI_Altar, (int) this.m_BuildKindID, bCameraMode: true);
    else if (this.m_ItemDatas[dataIndex].BuildID == (ushort) 23)
      menu.OpenMenu(EGUIWindow.UI_PetTrainingCenter, (int) this.m_BuildKindID, bCameraMode: true);
    else
      menu.OpenMenu(EGUIWindow.UIResourceBuilding, (int) this.m_BuildKindID, (int) this.m_ItemDatas[dataIndex].BuildID);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 != 1)
      return;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((Object) menu != (Object) null))
      return;
    menu.CloseMenu();
  }

  private void SetArrow(bool bActive, int index = 0)
  {
    this.m_ArrowIndx = !bActive ? -1 : index;
    this.m_ArrowScrollPanel.gameObject.SetActive(bActive);
  }

  public float ATween(float t, float b, float c, float d)
  {
    float num1 = (t /= d) * t;
    float num2 = num1 * t;
    return b + c * (num2 * num1);
  }
}
