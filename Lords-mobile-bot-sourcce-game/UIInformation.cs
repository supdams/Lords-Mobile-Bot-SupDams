// Decompiled with JetBrains decompiler
// Type: UIInformation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIInformation : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const int MaxPanelObject = 15;
  private const int MaxColum = 6;
  private const int MaxJailExtra = 9;
  private int MaxBuildLevel = 25;
  private int MaxTechLevel = 10;
  private int MaxTalentLevel = 25;
  private UISpritesArray m_SpritesArray;
  private ScrollPanel m_ScrollPanel;
  private UIText m_TitleText;
  private List<InfoItem> m_ItemInfo;
  private PanelColumItem[] m_Item;
  private ushort m_ManorID;
  private ushort m_BuildID;
  private ushort m_TechID;
  private ushort m_TalentID;
  private byte m_NowLv;
  private byte m_NowLv_Extea;
  private float m_ScrollWidth = 800f;
  private Font TTF;
  private DataManager DM;
  private int[] ExtraDataLvMin = new int[9]
  {
    1,
    25,
    30,
    35,
    40,
    45,
    50,
    55,
    60
  };
  private int[] ExtraDataLvMax = new int[9]
  {
    24,
    29,
    34,
    39,
    44,
    49,
    54,
    59,
    60
  };
  private int[] AttackBonus = new int[9]
  {
    1,
    2,
    3,
    5,
    8,
    12,
    17,
    23,
    30
  };
  private UIText context;

  public override void OnOpen(int arg1, int arg2)
  {
    GameObject gameObject = new GameObject();
    this.context = gameObject.AddComponent<UIText>();
    ((Behaviour) this.context).enabled = false;
    gameObject.transform.SetParent(this.transform, false);
    this.DM = DataManager.Instance;
    this.TTF = GUIManager.Instance.GetTTFFont();
    this.m_SpritesArray = this.transform.GetComponent<UISpritesArray>();
    this.m_ItemInfo = new List<InfoItem>();
    this.m_ScrollPanel = this.transform.GetChild(2).GetComponent<ScrollPanel>();
    this.m_TitleText = this.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.m_TitleText.font = this.TTF;
    if (arg1 > 0)
    {
      this.m_ManorID = (ushort) arg2;
      if ((int) this.m_ManorID < GUIManager.Instance.BuildingData.AllBuildsData.Length)
      {
        this.m_BuildID = GUIManager.Instance.BuildingData.AllBuildsData[(int) this.m_ManorID].BuildID;
        this.m_NowLv = GUIManager.Instance.BuildingData.AllBuildsData[(int) this.m_ManorID].Level;
      }
      if (this.m_BuildID == (ushort) 0)
        this.m_BuildID = (ushort) arg1;
      if (this.m_BuildID == (ushort) 16)
        this.MaxBuildLevel = 9;
      this.m_NowLv_Extea = this.m_NowLv;
      this.SetBuildTypeData();
    }
    else
    {
      switch (arg1)
      {
        case -2:
          byte SaveIndex = (byte) (arg2 & (int) ushort.MaxValue);
          this.m_TalentID = (ushort) (arg2 >> 16);
          TalentTbl recordByKey = this.DM.TalentData.GetRecordByKey(this.m_TalentID);
          this.m_NowLv = this.DM.GetTalentLevel(this.m_TalentID, SaveIndex);
          this.MaxTalentLevel = (int) recordByKey.LevelMax;
          this.SetTalentTypeData();
          break;
        case -1:
          this.m_TechID = (ushort) arg2;
          this.m_NowLv = this.DM.GetTechLevel(this.m_TechID);
          this.MaxTechLevel = (int) this.DM.TechData.GetRecordByKey(this.m_TechID).LevelMax;
          this.SetTechTypeData();
          break;
      }
    }
    this.InitPanelColumItem();
    for (int index = 0; index < 6; ++index)
      this.transform.GetChild(4).GetChild(index).gameObject.SetActive(true);
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_ItemInfo.Count; ++index)
      _DataHeight.Add(this.m_ItemInfo[index].m_Height);
    this.m_ScrollPanel.IntiScrollPanel(509f, 0.0f, 0.0f, _DataHeight, 15, (IUpDateScrollPanel) this);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      Image component = this.transform.GetChild(5).GetComponent<Image>();
      if ((bool) (Object) component)
        ((Behaviour) component).enabled = false;
    }
    UIButton component1 = this.transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 0;
    if (arg1 > 0 && this.m_BuildID == (ushort) 20 || this.m_BuildID == (ushort) 21 || this.m_BuildID == (ushort) 22 || this.m_BuildID == (ushort) 23)
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
    else if (arg1 == -1 && DataManager.StageDataController.StageRecord[2] >= (ushort) 8)
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
    else
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  private void InitPanelColumItem()
  {
    this.m_Item = new PanelColumItem[15];
    for (int index = 0; index < this.m_Item.Length; ++index)
      this.m_Item[index].column = new PanelColumn[6];
  }

  public override void OnClose()
  {
    for (int index1 = 0; index1 < this.m_ItemInfo.Count; ++index1)
    {
      for (int index2 = 0; index2 < this.m_ItemInfo[index1].m_Column.Length; ++index2)
        StringManager.Instance.DeSpawnString(this.m_ItemInfo[index1].m_Column[index2].m_Str);
    }
  }

  private void SetBuildTypeData()
  {
    BuildTypeData recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey(this.m_BuildID);
    this.m_TitleText.text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.NameID);
    this.m_ItemInfo.Clear();
    int columNum = 0;
    UIText component = this.transform.GetChild(4).GetChild(0).GetChild(1).GetComponent<UIText>();
    component.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.ContentID);
    component.font = this.TTF;
    component.fontSize = 24;
    InfoItem infoItem1 = new InfoItem();
    infoItem1.m_Type = (byte) 0;
    infoItem1.bHaveLvColumn = false;
    infoItem1.m_ColumNum = 1;
    infoItem1.m_Height = component.preferredHeight;
    infoItem1.m_Width = this.m_ScrollWidth;
    infoItem1.m_DataIdx = -1;
    infoItem1.m_Column[0].m_StrID = (uint) recordByKey.ContentID;
    this.m_ItemInfo.Add(infoItem1);
    InfoItem infoItem2 = new InfoItem();
    infoItem2.m_Type = (byte) 1;
    infoItem2.bHaveLvColumn = false;
    infoItem2.m_ColumNum = 1;
    infoItem2.m_Height = 42f;
    infoItem2.m_Width = this.m_ScrollWidth;
    infoItem2.m_DataIdx = -2;
    infoItem2.m_Column[0].m_StrID = 3817U;
    this.m_ItemInfo.Add(infoItem2);
    InfoItem infoItem3 = new InfoItem();
    infoItem3.m_Type = (byte) 2;
    infoItem3.bHaveLvColumn = false;
    infoItem3.m_ColumNum = 1;
    infoItem3.m_Height = 46f;
    infoItem3.m_Width = this.m_ScrollWidth;
    infoItem3.m_DataIdx = -3;
    infoItem3.m_Column[0].m_StrID = 4549U;
    infoItem3.m_Column[0].ColumnWidth = 63f;
    uint[] columnName = this.GetColumnName(this.m_BuildID, out columNum);
    infoItem3.m_ColumNum = columNum;
    infoItem3.m_Column[0].bFisetColumn = true;
    infoItem3.m_Column[infoItem3.m_ColumNum].bLastColumn = true;
    for (int index1 = 0; index1 < columnName.Length; ++index1)
    {
      int index2 = index1 + 1;
      if (index2 < infoItem3.m_Column.Length)
        infoItem3.m_Column[index2].m_StrID = columnName[index1];
    }
    float width = (829f - infoItem3.m_Column[0].ColumnWidth) / (float) infoItem3.m_ColumNum;
    for (int index = 1; index < infoItem3.m_Column.Length; ++index)
      infoItem3.m_Column[index].ColumnWidth = width;
    this.m_ItemInfo.Add(infoItem3);
    bool flag1 = false;
    byte num1 = 0;
    for (byte lv = 1; (int) lv <= this.MaxBuildLevel; ++lv)
    {
      InfoItem infoItem4 = new InfoItem();
      infoItem4.m_Type = (byte) 3;
      infoItem4.bHaveLvColumn = true;
      infoItem4.m_ColumNum = columNum;
      infoItem4.m_Height = 40f;
      infoItem4.m_Width = this.m_ScrollWidth;
      infoItem4.m_DataIdx = -3;
      infoItem4.m_Column[0].ColumnWidth = 63f;
      infoItem4.m_Column[0].m_Value = (long) lv;
      long[] columnValue = this.GetColumnValue(this.m_BuildID, lv);
      uint[] columnEffect = this.GetColumnEffect(this.m_BuildID, lv);
      for (int index3 = 0; index3 < columnValue.Length; ++index3)
      {
        int index4 = index3 + 1;
        if (index4 < infoItem4.m_Column.Length)
        {
          infoItem4.m_Column[index4].m_Value = columnValue[index3];
          infoItem4.m_Column[index4].m_EffID = columnEffect[index3];
          if (infoItem4.m_Column[index4].m_EffID > 1000U)
            infoItem4.m_Height = this.CalculateTextHeight((ushort) infoItem4.m_Column[index4].m_EffID, width, this.context);
        }
      }
      for (int index = 1; index < infoItem4.m_Column.Length; ++index)
        infoItem4.m_Column[index].ColumnWidth = width;
      if (infoItem4.m_Column[1].m_EffID != 0U)
      {
        infoItem4.m_Column[0].bFisetColumn = true;
        infoItem4.m_Column[infoItem4.m_ColumNum].bLastColumn = true;
        this.m_ItemInfo.Add(infoItem4);
        if ((int) lv < (int) this.m_NowLv)
          num1 = lv;
        if ((int) this.m_NowLv == (int) lv)
          flag1 = true;
      }
    }
    if (!flag1)
      this.m_NowLv = num1;
    uint[] columnNameExtra = this.GetColumnName_extra(this.m_BuildID, out columNum);
    if (columNum > 0)
    {
      this.m_ItemInfo.Add(new InfoItem()
      {
        m_Type = (byte) 4,
        bHaveLvColumn = false,
        m_Height = 40f,
        m_Width = this.m_ScrollWidth
      });
      InfoItem infoItem5 = new InfoItem();
      infoItem5.m_Type = (byte) 1;
      infoItem5.bHaveLvColumn = false;
      infoItem5.m_ColumNum = 1;
      infoItem5.m_Height = 42f;
      infoItem5.m_Width = this.m_ScrollWidth;
      infoItem5.m_DataIdx = -2;
      infoItem5.m_Column[0].m_StrID = 152U;
      this.m_ItemInfo.Add(infoItem5);
      InfoItem infoItem6 = new InfoItem();
      infoItem6.m_Type = (byte) 2;
      infoItem6.bHaveLvColumn = false;
      infoItem6.m_ColumNum = columNum;
      infoItem6.m_Height = 46f;
      infoItem6.m_Width = this.m_ScrollWidth;
      infoItem6.m_DataIdx = -3;
      infoItem6.m_Column[0].m_StrID = 4549U;
      infoItem6.m_Column[0].ColumnWidth = 63f;
      infoItem6.m_Column[0].bFisetColumn = true;
      infoItem6.m_Column[infoItem6.m_ColumNum].bLastColumn = true;
      for (int index = 0; index < columnNameExtra.Length; ++index)
        infoItem6.m_Column[index + 1].m_StrID = columnNameExtra[index];
      float num2 = (829f - infoItem6.m_Column[0].ColumnWidth) / (float) infoItem6.m_ColumNum;
      for (int index = 1; index < infoItem6.m_Column.Length; ++index)
        infoItem6.m_Column[index].ColumnWidth = num2;
      this.m_ItemInfo.Add(infoItem6);
      uint[] numArray1 = new uint[2];
      uint[] numArray2 = new uint[2];
      byte num3 = 0;
      bool flag2 = false;
      for (byte Level = 1; (int) Level <= this.MaxBuildLevel; ++Level)
      {
        BuildLevelRequest levelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(this.m_BuildID, Level);
        if (levelRequestData.ExtEffect1 != (ushort) 0 && ((int) numArray1[0] != (int) levelRequestData.ExtEffect1 || (int) numArray2[0] != (int) levelRequestData.ExtValue1))
        {
          numArray2[0] = levelRequestData.ExtValue1;
          numArray1[0] = (uint) levelRequestData.ExtEffect1;
          InfoItem infoItem7 = new InfoItem();
          infoItem7.m_Type = (byte) 5;
          infoItem7.m_ColumNum = columNum;
          infoItem7.m_Height = 40f;
          infoItem7.m_Width = this.m_ScrollWidth;
          infoItem7.m_Column[0].ColumnWidth = 63f;
          float num4 = (829f - infoItem7.m_Column[0].ColumnWidth) / (float) infoItem7.m_ColumNum;
          infoItem7.m_Column[0].m_Value = (long) Level;
          GameConstants.GetEffectValue(infoItem7.m_Column[1].m_Str, levelRequestData.ExtEffect1, levelRequestData.ExtValue1, (byte) 3, 0.0f);
          infoItem7.m_Column[1].ColumnWidth = num4;
          infoItem7.m_Column[1].m_EffID = (uint) levelRequestData.ExtEffect1;
          if (columNum > 1 && ((int) numArray1[1] != (int) levelRequestData.ExtEffect2 || (int) numArray2[1] != (int) levelRequestData.ExtValue2))
          {
            numArray1[1] = (uint) levelRequestData.ExtEffect2;
            GameConstants.GetEffectValue(infoItem7.m_Column[2].m_Str, levelRequestData.ExtEffect2, (uint) levelRequestData.ExtValue2, (byte) 3, 0.0f);
            infoItem7.m_Column[2].m_EffID = (uint) levelRequestData.ExtEffect2;
            infoItem7.m_Column[2].ColumnWidth = num4;
          }
          this.m_ItemInfo.Add(infoItem7);
          if ((int) Level < (int) this.m_NowLv_Extea)
            num3 = Level;
          if ((int) this.m_NowLv_Extea == (int) Level)
            flag2 = true;
        }
      }
      if (!flag2)
        this.m_NowLv_Extea = num3;
    }
    if (this.m_BuildID != (ushort) 18)
      return;
    float num5 = 414.5f;
    InfoItem infoItem8 = new InfoItem();
    infoItem8.m_Type = (byte) 2;
    infoItem8.bHaveLvColumn = false;
    infoItem8.m_ColumNum = 1;
    infoItem8.m_Height = 46f;
    infoItem8.m_Width = this.m_ScrollWidth;
    infoItem8.m_DataIdx = -3;
    infoItem8.m_Column[0].m_StrID = 5902U;
    infoItem8.m_Column[0].ColumnWidth = num5;
    infoItem8.m_Column[1].m_StrID = 5903U;
    infoItem8.m_Column[1].ColumnWidth = num5;
    infoItem8.m_Column[0].bFisetColumn = true;
    infoItem8.m_Column[1].bLastColumn = true;
    this.m_ItemInfo.Add(infoItem8);
    for (int index = 0; index < 9; ++index)
    {
      InfoItem infoItem9 = new InfoItem();
      infoItem9.m_Type = (byte) 6;
      infoItem9.m_ColumNum = columNum;
      infoItem9.m_Height = 40f;
      infoItem9.m_Width = this.m_ScrollWidth;
      infoItem9.m_Column[0].ColumnWidth = num5;
      infoItem9.m_Column[0].m_EffID = (uint) this.ExtraDataLvMin[index];
      infoItem9.m_Column[0].m_Value = (long) (uint) this.ExtraDataLvMax[index];
      infoItem9.m_Column[0].bFisetColumn = true;
      infoItem9.m_Column[1].bLastColumn = true;
      infoItem9.m_Column[1].ColumnWidth = num5;
      infoItem9.m_Column[1].m_EffID = (uint) this.AttackBonus[index];
      this.m_ItemInfo.Add(infoItem9);
    }
  }

  private void SetTechTypeData()
  {
    this.m_ItemInfo.Clear();
    InfoItem infoItem1 = new InfoItem();
    infoItem1.m_Type = (byte) 1;
    infoItem1.bHaveLvColumn = false;
    infoItem1.m_ColumNum = 1;
    infoItem1.m_Height = 42f;
    infoItem1.m_Width = this.m_ScrollWidth;
    infoItem1.m_DataIdx = -2;
    infoItem1.m_Column[0].m_StrID = 3817U;
    this.m_ItemInfo.Add(infoItem1);
    InfoItem infoItem2 = new InfoItem();
    infoItem2.m_Type = (byte) 2;
    infoItem2.bHaveLvColumn = false;
    infoItem2.m_ColumNum = 1;
    infoItem2.m_Height = 46f;
    infoItem2.m_Width = this.m_ScrollWidth;
    infoItem2.m_DataIdx = -3;
    infoItem2.m_Column[0].m_StrID = 4549U;
    infoItem2.m_Column[0].ColumnWidth = 63f;
    infoItem2.m_Column[0].bFisetColumn = true;
    infoItem2.m_Column[infoItem2.m_ColumNum].bLastColumn = true;
    float width = 829f - infoItem2.m_Column[0].ColumnWidth;
    TechLevelTbl Data;
    this.DM.GetTechLevelupData(out Data, this.m_TechID, (byte) 1);
    infoItem2.m_Column[1].ColumnWidth = width;
    infoItem2.m_Column[1].m_StrID = this.GetColumnName_Tech(this.m_TechID);
    this.m_ItemInfo.Add(infoItem2);
    for (byte Level = 1; (int) Level <= this.MaxTechLevel; ++Level)
    {
      this.DM.GetTechLevelupData(out Data, this.m_TechID, Level);
      InfoItem infoItem3 = new InfoItem();
      infoItem3.m_Type = (byte) 3;
      infoItem3.bHaveLvColumn = true;
      infoItem3.m_ColumNum = 2;
      infoItem3.m_Height = 40f;
      infoItem3.m_Width = this.m_ScrollWidth;
      infoItem3.m_DataIdx = -3;
      infoItem3.m_Column[0].ColumnWidth = 63f;
      infoItem3.m_Column[0].bFisetColumn = true;
      infoItem3.m_Column[infoItem3.m_ColumNum].bLastColumn = true;
      infoItem3.m_Column[0].m_Value = (long) Level;
      infoItem3.m_Column[1].m_EffID = (uint) Data.Effect;
      infoItem3.m_Column[1].m_Value = (long) Data.EffectVal;
      infoItem3.m_Column[1].ColumnWidth = width;
      if (infoItem3.m_Column[1].m_EffID > 1000U)
        infoItem3.m_Height = this.CalculateTextHeight((ushort) infoItem3.m_Column[1].m_EffID, width, this.context);
      this.m_ItemInfo.Add(infoItem3);
    }
    this.m_TitleText.text = this.DM.mStringTable.GetStringByID((uint) this.DM.TechData.GetRecordByKey(Data.TechID).TechName);
  }

  private void SetTalentTypeData()
  {
    this.m_ItemInfo.Clear();
    InfoItem infoItem1 = new InfoItem();
    infoItem1.m_Type = (byte) 1;
    infoItem1.bHaveLvColumn = false;
    infoItem1.m_ColumNum = 1;
    infoItem1.m_Height = 42f;
    infoItem1.m_Width = this.m_ScrollWidth;
    infoItem1.m_DataIdx = -2;
    infoItem1.m_Column[0].m_StrID = 3817U;
    this.m_ItemInfo.Add(infoItem1);
    InfoItem infoItem2 = new InfoItem();
    infoItem2.m_Type = (byte) 2;
    infoItem2.bHaveLvColumn = false;
    infoItem2.m_ColumNum = 1;
    infoItem2.m_Height = 46f;
    infoItem2.m_Width = this.m_ScrollWidth;
    infoItem2.m_DataIdx = -3;
    infoItem2.m_Column[0].m_StrID = 4549U;
    infoItem2.m_Column[0].ColumnWidth = 63f;
    infoItem2.m_Column[0].bFisetColumn = true;
    infoItem2.m_Column[infoItem2.m_ColumNum].bLastColumn = true;
    float num = 829f - infoItem2.m_Column[0].ColumnWidth;
    TalentLevelTbl Data;
    this.DM.GetTalentLevelupData(out Data, this.m_TalentID, (byte) 1);
    infoItem2.m_Column[1].ColumnWidth = num;
    infoItem2.m_Column[1].m_StrID = this.GetColumName_Talent(this.m_TalentID);
    this.m_ItemInfo.Add(infoItem2);
    for (byte Level = 1; (int) Level <= this.MaxTalentLevel; ++Level)
    {
      this.DM.GetTalentLevelupData(out Data, this.m_TalentID, Level);
      InfoItem infoItem3 = new InfoItem();
      infoItem3.m_Type = (byte) 3;
      infoItem3.bHaveLvColumn = true;
      infoItem3.m_ColumNum = 2;
      infoItem3.m_Height = 40f;
      infoItem3.m_Width = this.m_ScrollWidth;
      infoItem3.m_DataIdx = -3;
      infoItem3.m_Column[0].ColumnWidth = 63f;
      infoItem3.m_Column[0].bFisetColumn = true;
      infoItem3.m_Column[infoItem3.m_ColumNum].bLastColumn = true;
      infoItem3.m_Column[0].m_Value = (long) Level;
      infoItem3.m_Column[1].m_EffID = (uint) Data.Effect;
      infoItem3.m_Column[1].m_Value = (long) Data.EffectVal;
      infoItem3.m_Column[1].ColumnWidth = num;
      this.m_ItemInfo.Add(infoItem3);
    }
    this.m_TitleText.text = this.DM.mStringTable.GetStringByID((uint) this.DM.TalentData.GetRecordByKey(this.m_TalentID).NameID);
  }

  private uint[] GetColumnName(ushort buildID, out int columNum)
  {
    uint[] columnName = new uint[5];
    for (byte Level = 1; (int) Level <= this.MaxBuildLevel; ++Level)
    {
      BuildLevelRequest levelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(this.m_BuildID, Level);
      if (levelRequestData.Effect1 != (ushort) 0)
        columnName[0] = levelRequestData.Effect1 <= (ushort) 1000 ? (uint) this.DM.EffectData.GetRecordByKey(levelRequestData.Effect1).InfoID : 1048U;
      if (levelRequestData.Effect2 != (ushort) 0)
        columnName[1] = levelRequestData.Effect2 <= (ushort) 1000 ? (uint) this.DM.EffectData.GetRecordByKey(levelRequestData.Effect2).InfoID : 1048U;
      if (levelRequestData.Effect3 != (ushort) 0)
        columnName[2] = levelRequestData.Effect3 <= (ushort) 1000 ? (uint) this.DM.EffectData.GetRecordByKey(levelRequestData.Effect3).InfoID : 1048U;
      if (levelRequestData.Effect4 != (ushort) 0)
        columnName[3] = levelRequestData.Effect4 <= (ushort) 1000 ? (uint) this.DM.EffectData.GetRecordByKey(levelRequestData.Effect4).InfoID : 1048U;
      if (levelRequestData.Value5 != (ushort) 0)
        columnName[4] = levelRequestData.Value5 <= (ushort) 1000 ? (uint) this.DM.EffectData.GetRecordByKey(levelRequestData.Value5).InfoID : 1048U;
    }
    columNum = 0;
    for (int index = 0; index < columnName.Length; ++index)
    {
      if (columnName[index] != 0U)
        ++columNum;
    }
    return columnName;
  }

  private uint GetColumnName_Tech(ushort techID)
  {
    uint columnNameTech = 0;
    TechLevelTbl Data;
    this.DM.GetTechLevelupData(out Data, techID, (byte) 1);
    if (Data.Effect != (ushort) 0)
      columnNameTech = Data.Effect <= (ushort) 1000 ? (uint) this.DM.EffectData.GetRecordByKey(Data.Effect).InfoID : 1048U;
    return columnNameTech;
  }

  private uint GetColumName_Talent(ushort talentID)
  {
    uint columNameTalent = 0;
    TalentLevelTbl Data;
    this.DM.GetTalentLevelupData(out Data, talentID, (byte) 1);
    if (Data.Effect != (ushort) 0)
      columNameTalent = Data.Effect <= (ushort) 1000 ? (uint) this.DM.EffectData.GetRecordByKey(Data.Effect).InfoID : 1048U;
    return columNameTalent;
  }

  private long[] GetColumnValue(ushort buildID, byte lv)
  {
    long[] columnValue = new long[5];
    BuildLevelRequest levelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(this.m_BuildID, lv);
    if (levelRequestData.Value1 != 0U)
      columnValue[0] = (long) levelRequestData.Value1;
    if (levelRequestData.Value2 != 0U)
      columnValue[1] = (long) levelRequestData.Value2;
    if (levelRequestData.Value3 != (ushort) 0)
      columnValue[2] = (long) levelRequestData.Value3;
    if (levelRequestData.Value4 != (ushort) 0)
      columnValue[3] = (long) levelRequestData.Value4;
    return columnValue;
  }

  private uint[] GetColumnEffect(ushort buildID, byte lv)
  {
    uint[] columnEffect = new uint[5];
    BuildLevelRequest levelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(this.m_BuildID, lv);
    if (levelRequestData.Effect1 != (ushort) 0)
      columnEffect[0] = (uint) levelRequestData.Effect1;
    if (levelRequestData.Effect2 != (ushort) 0)
      columnEffect[1] = (uint) levelRequestData.Effect2;
    if (levelRequestData.Effect3 != (ushort) 0)
      columnEffect[2] = (uint) levelRequestData.Effect3;
    if (levelRequestData.Effect4 != (ushort) 0)
      columnEffect[3] = (uint) levelRequestData.Effect4;
    if (levelRequestData.Value5 != (ushort) 0)
      columnEffect[4] = (uint) levelRequestData.Value5;
    return columnEffect;
  }

  private uint[] GetColumnName_extra(ushort buildID, out int columNum)
  {
    uint[] columnNameExtra = new uint[2];
    columNum = 0;
    for (byte Level = 1; (int) Level <= this.MaxBuildLevel; ++Level)
    {
      BuildLevelRequest levelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(this.m_BuildID, Level);
      if (levelRequestData.ExtEffect1 != (ushort) 0)
        columnNameExtra[0] = levelRequestData.ExtEffect1 <= (ushort) 1000 ? (uint) this.DM.EffectData.GetRecordByKey(levelRequestData.ExtEffect1).StringID : 1048U;
      if (levelRequestData.ExtEffect2 != (ushort) 0)
        columnNameExtra[1] = levelRequestData.ExtEffect2 <= (ushort) 1000 ? (uint) this.DM.EffectData.GetRecordByKey(levelRequestData.ExtEffect2).StringID : 1048U;
    }
    for (int index = 0; index < columnNameExtra.Length; ++index)
    {
      if (columnNameExtra[index] == 0U)
      {
        columNum = index;
        break;
      }
    }
    return columnNameExtra;
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 == 0)
    {
      this.m_NowLv = GUIManager.Instance.BuildingData.GetBuildData(this.m_BuildID, (ushort) 0).Level;
      this.SetBuildTypeData();
    }
    else
    {
      this.m_NowLv = this.DM.GetTechLevel(this.m_TechID);
      this.SetTechTypeData();
    }
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_ItemInfo.Count; ++index)
      _DataHeight.Add(this.m_ItemInfo[index].m_Height);
    this.m_ScrollPanel.AddNewDataHeight(_DataHeight);
  }

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
    if ((Object) this.context != (Object) null && ((Behaviour) this.context).enabled)
    {
      ((Behaviour) this.context).enabled = false;
      ((Behaviour) this.context).enabled = true;
    }
    for (int index1 = 0; index1 < 15; ++index1)
    {
      if (this.m_Item[index1].column != null)
      {
        for (int index2 = 0; index2 < 6; ++index2)
        {
          if ((Object) this.m_Item[index1].column[index2].text != (Object) null && ((Behaviour) this.m_Item[index1].column[index2].text).enabled)
          {
            ((Behaviour) this.m_Item[index1].column[index2].text).enabled = false;
            ((Behaviour) this.m_Item[index1].column[index2].text).enabled = true;
          }
        }
      }
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
  }

  public override bool OnBackButtonClick() => false;

  public void OnButtonClick(UIButton sender)
  {
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
  }

  private void ClearItem(GameObject item)
  {
    for (int index = 0; index < item.transform.childCount; ++index)
    {
      Transform child1 = item.transform.GetChild(index);
      ((RectTransform) child1).sizeDelta = new Vector2(829f, 40f);
      ((RectTransform) child1).anchoredPosition = new Vector2(0.0f, 0.0f);
      Transform child2 = child1.GetChild(0);
      ((RectTransform) child2).sizeDelta = new Vector2(829f, 40f);
      ((RectTransform) child2).anchoredPosition = new Vector2(0.0f, 0.0f);
      Transform child3 = child1.GetChild(1);
      ((RectTransform) child3).sizeDelta = new Vector2(829f, 40f);
      ((RectTransform) child3).anchoredPosition = new Vector2(0.0f, 0.0f);
      if (child1.gameObject.activeSelf)
        child1.gameObject.SetActive(false);
    }
  }

  private void ClearItem(int panelObjectIdx)
  {
    for (int index = 0; index < 6; ++index)
    {
      if ((Object) this.m_Item[panelObjectIdx].column[index].image != (Object) null)
      {
        this.m_Item[panelObjectIdx].column[index].rect.sizeDelta = new Vector2(829f, 40f);
        this.m_Item[panelObjectIdx].column[index].rect.anchoredPosition = new Vector2(0.0f, 0.0f);
        this.m_Item[panelObjectIdx].column[index].imageRect.sizeDelta = new Vector2(829f, 40f);
        this.m_Item[panelObjectIdx].column[index].imageRect.anchoredPosition = new Vector2(0.0f, 0.0f);
        this.m_Item[panelObjectIdx].column[index].textRect.sizeDelta = new Vector2(829f, 40f);
        this.m_Item[panelObjectIdx].column[index].textRect.anchoredPosition = new Vector2(0.0f, 0.0f);
        this.m_Item[panelObjectIdx].column[index].text.fontSize = 18;
        ((Behaviour) this.m_Item[panelObjectIdx].column[index].textShadow).enabled = false;
        ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = false;
        ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = false;
        ((Graphic) this.m_Item[panelObjectIdx].column[index].text).color = new Color(1f, 1f, 1f, 1f);
      }
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    this.ClearItem(panelObjectIdx);
    int type = (int) this.m_ItemInfo[dataIdx].m_Type;
    if ((Object) this.m_Item[panelObjectIdx].column[0].image == (Object) null)
    {
      for (int index = 0; index < 6; ++index)
      {
        Transform child = item.transform.GetChild(index);
        this.m_Item[panelObjectIdx].column[index].rect = child.GetComponent<RectTransform>();
        this.m_Item[panelObjectIdx].column[index].image = child.GetChild(0).GetComponent<Image>();
        this.m_Item[panelObjectIdx].column[index].imageRect = child.GetChild(0).GetComponent<RectTransform>();
        this.m_Item[panelObjectIdx].column[index].text = child.GetChild(1).GetComponent<UIText>();
        this.m_Item[panelObjectIdx].column[index].text.font = this.TTF;
        this.m_Item[panelObjectIdx].column[index].textRect = child.GetChild(1).GetComponent<RectTransform>();
        this.m_Item[panelObjectIdx].column[index].textShadow = child.GetChild(1).GetComponent<Shadow>();
        this.m_Item[panelObjectIdx].column[index].text.AdjuestUI();
      }
    }
    Transform child1;
    switch (type)
    {
      case 0:
        for (int index = 0; index < 6; ++index)
        {
          if (index == 0)
          {
            Vector2 vector2 = this.m_Item[panelObjectIdx].column[index].rect.sizeDelta with
            {
              y = this.m_ItemInfo[dataIdx].m_Height
            };
            this.m_Item[panelObjectIdx].column[index].rect.sizeDelta = vector2;
            if (((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = false;
            if (!((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = true;
            this.m_Item[panelObjectIdx].column[index].text.fontSize = 24;
            this.m_Item[panelObjectIdx].column[index].text.resizeTextMaxSize = 24;
            vector2 = this.m_Item[panelObjectIdx].column[index].textRect.sizeDelta with
            {
              y = this.m_ItemInfo[dataIdx].m_Height,
              x = 800f
            };
            this.m_Item[panelObjectIdx].column[index].textRect.sizeDelta = vector2;
            vector2 = this.m_Item[panelObjectIdx].column[index].textRect.anchoredPosition with
            {
              x = 20f
            };
            this.m_Item[panelObjectIdx].column[index].textRect.anchoredPosition = vector2;
            this.m_Item[panelObjectIdx].column[index].text.text = this.DM.mStringTable.GetStringByID(this.m_ItemInfo[dataIdx].m_Column[index].m_StrID);
            this.m_Item[panelObjectIdx].column[index].text.alignment = !GUIManager.Instance.IsArabic ? TextAnchor.MiddleLeft : TextAnchor.MiddleRight;
            ((Behaviour) this.m_Item[panelObjectIdx].column[index].textShadow).enabled = true;
          }
          else
          {
            if (((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = false;
            if (((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = false;
            if ((bool) (Object) this.m_Item[panelObjectIdx].column[index].textShadow)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].textShadow).enabled = false;
          }
          this.m_Item[panelObjectIdx].column[index].text.UpdateArabicPos();
        }
        break;
      case 1:
        for (int index = 0; index < 6; ++index)
        {
          if (index == 0)
          {
            Vector2 sizeDelta = this.m_Item[panelObjectIdx].column[index].rect.sizeDelta with
            {
              y = this.m_ItemInfo[dataIdx].m_Height
            };
            this.m_Item[panelObjectIdx].column[index].rect.sizeDelta = sizeDelta;
            if (!((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = true;
            if (!((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = true;
            this.m_Item[panelObjectIdx].column[index].image.sprite = this.m_SpritesArray.GetSprite(12);
            ((Graphic) this.m_Item[panelObjectIdx].column[index].image).rectTransform.sizeDelta = new Vector2(829f, 4f);
            this.m_Item[panelObjectIdx].column[index].text.fontSize = 24;
            this.m_Item[panelObjectIdx].column[index].text.resizeTextMaxSize = 24;
            this.m_Item[panelObjectIdx].column[index].text.resizeTextForBestFit = true;
            sizeDelta.y = this.m_ItemInfo[dataIdx].m_Height;
            this.m_Item[panelObjectIdx].column[index].textRect.sizeDelta = sizeDelta;
            this.m_Item[panelObjectIdx].column[index].text.text = this.DM.mStringTable.GetStringByID(this.m_ItemInfo[dataIdx].m_Column[index].m_StrID);
            this.m_Item[panelObjectIdx].column[index].text.alignment = TextAnchor.MiddleCenter;
            ((Behaviour) this.m_Item[panelObjectIdx].column[index].textShadow).enabled = true;
          }
          else
          {
            if (((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = false;
            if (((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = false;
            if ((bool) (Object) this.m_Item[panelObjectIdx].column[index].textShadow)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].textShadow).enabled = false;
          }
          ((Graphic) this.m_Item[panelObjectIdx].column[index].text).color = new Color(1f, 1f, 0.8f, 1f);
          this.m_Item[panelObjectIdx].column[index].text.UpdateArabicPos();
        }
        break;
      case 2:
        float x1 = 0.0f;
        for (int index = 0; index < 6; ++index)
        {
          if (this.m_ItemInfo[dataIdx].m_Column[index].m_StrID != 0U)
          {
            this.m_Item[panelObjectIdx].column[index].rect.anchoredPosition = new Vector2(x1, 0.0f);
            Vector2 sizeDelta = this.m_Item[panelObjectIdx].column[index].rect.sizeDelta;
            x1 += this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth;
            sizeDelta = this.m_Item[panelObjectIdx].column[index].rect.sizeDelta with
            {
              x = this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth,
              y = 46f
            };
            this.m_Item[panelObjectIdx].column[index].imageRect.sizeDelta = sizeDelta;
            this.m_Item[panelObjectIdx].column[index].rect.sizeDelta = sizeDelta;
            if (!((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = true;
            if (!((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = true;
            sizeDelta = ((Graphic) this.m_Item[panelObjectIdx].column[index].image).rectTransform.sizeDelta with
            {
              x = this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth
            };
            ((Graphic) this.m_Item[panelObjectIdx].column[index].image).rectTransform.sizeDelta = sizeDelta;
            this.m_Item[panelObjectIdx].column[index].image.sprite = !this.m_ItemInfo[dataIdx].m_Column[index].bFisetColumn ? (!this.m_ItemInfo[dataIdx].m_Column[index].bLastColumn ? this.m_SpritesArray.GetSprite(0) : this.m_SpritesArray.GetSprite(2)) : this.m_SpritesArray.GetSprite(1);
            this.m_Item[panelObjectIdx].column[index].text.font = this.TTF;
            this.m_Item[panelObjectIdx].column[index].text.fontSize = 24;
            this.m_Item[panelObjectIdx].column[index].text.resizeTextMaxSize = 24;
            this.m_Item[panelObjectIdx].column[index].text.resizeTextForBestFit = true;
            sizeDelta = this.m_Item[panelObjectIdx].column[index].textRect.sizeDelta with
            {
              x = this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth,
              y = this.m_ItemInfo[dataIdx].m_Height
            };
            this.m_Item[panelObjectIdx].column[index].textRect.sizeDelta = sizeDelta;
            this.m_Item[panelObjectIdx].column[index].text.text = this.DM.mStringTable.GetStringByID(this.m_ItemInfo[dataIdx].m_Column[index].m_StrID);
            this.m_Item[panelObjectIdx].column[index].text.alignment = TextAnchor.MiddleCenter;
            ((Graphic) this.m_Item[panelObjectIdx].column[index].text).color = new Color(1f, 1f, 0.8f, 1f);
            ((Behaviour) this.m_Item[panelObjectIdx].column[index].textShadow).enabled = false;
          }
          else
          {
            if (((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = false;
            if (((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = false;
            if ((bool) (Object) this.m_Item[panelObjectIdx].column[index].textShadow)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].textShadow).enabled = false;
          }
          this.m_Item[panelObjectIdx].column[index].text.UpdateArabicPos();
        }
        break;
      case 3:
        float x2 = 0.0f;
        for (int index = 0; index < 6; ++index)
        {
          if (index < this.m_ItemInfo[dataIdx].m_ColumNum + 1)
          {
            child1 = item.transform.GetChild(index);
            this.m_Item[panelObjectIdx].column[index].rect.anchoredPosition = new Vector2(x2, 0.0f);
            x2 += this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth;
            Vector2 vector2 = this.m_Item[panelObjectIdx].column[index].rect.sizeDelta with
            {
              y = this.m_ItemInfo[dataIdx].m_Height,
              x = this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth
            };
            this.m_Item[panelObjectIdx].column[index].rect.sizeDelta = vector2;
            this.m_Item[panelObjectIdx].column[index].imageRect.sizeDelta = vector2;
            if (!((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = true;
            if (!((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = true;
            vector2 = this.m_Item[panelObjectIdx].column[index].rect.sizeDelta with
            {
              y = this.m_ItemInfo[dataIdx].m_Height,
              x = this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth
            };
            this.m_Item[panelObjectIdx].column[index].rect.sizeDelta = vector2;
            this.m_Item[panelObjectIdx].column[index].image.sprite = this.m_ItemInfo[dataIdx].m_Column[0].m_Value == (long) this.m_NowLv ? (!this.m_ItemInfo[dataIdx].m_Column[index].bFisetColumn ? (!this.m_ItemInfo[dataIdx].m_Column[index].bLastColumn ? this.m_SpritesArray.GetSprite(9) : this.m_SpritesArray.GetSprite(11)) : this.m_SpritesArray.GetSprite(10)) : (dataIdx % 2 != 0 ? (!this.m_ItemInfo[dataIdx].m_Column[index].bFisetColumn ? (!this.m_ItemInfo[dataIdx].m_Column[index].bLastColumn ? this.m_SpritesArray.GetSprite(6) : this.m_SpritesArray.GetSprite(8)) : this.m_SpritesArray.GetSprite(7)) : (!this.m_ItemInfo[dataIdx].m_Column[index].bFisetColumn ? (!this.m_ItemInfo[dataIdx].m_Column[index].bLastColumn ? this.m_SpritesArray.GetSprite(3) : this.m_SpritesArray.GetSprite(5)) : this.m_SpritesArray.GetSprite(4)));
            this.m_Item[panelObjectIdx].column[index].text.font = this.TTF;
            this.m_Item[panelObjectIdx].column[index].text.fontSize = 18;
            this.m_Item[panelObjectIdx].column[index].text.resizeTextMaxSize = 18;
            this.m_Item[panelObjectIdx].column[index].text.resizeTextMinSize = 10;
            this.m_Item[panelObjectIdx].column[index].text.resizeTextForBestFit = true;
            vector2 = ((Graphic) this.m_Item[panelObjectIdx].column[index].text).rectTransform.sizeDelta with
            {
              y = this.m_ItemInfo[dataIdx].m_Height,
              x = this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth
            };
            ((Graphic) this.m_Item[panelObjectIdx].column[index].text).rectTransform.sizeDelta = vector2;
            if (index == 0)
            {
              this.m_Item[panelObjectIdx].column[index].text.text = this.m_ItemInfo[dataIdx].m_Column[index].m_Value.ToString();
              this.m_Item[panelObjectIdx].column[index].text.UpdateArabicPos();
            }
            else
            {
              if (this.m_BuildID == (ushort) 18)
              {
                this.m_ItemInfo[dataIdx].m_Column[index].m_Str.ClearString();
                GameConstants.GetTimeInfoString(this.m_ItemInfo[dataIdx].m_Column[index].m_Str, (uint) this.m_ItemInfo[dataIdx].m_Column[index].m_Value);
              }
              else
                GameConstants.GetEffectValue(this.m_ItemInfo[dataIdx].m_Column[index].m_Str, (ushort) this.m_ItemInfo[dataIdx].m_Column[index].m_EffID, (uint) this.m_ItemInfo[dataIdx].m_Column[index].m_Value, (byte) 3, 0.0f);
              this.m_Item[panelObjectIdx].column[index].text.text = this.m_ItemInfo[dataIdx].m_Column[index].m_Str.ToString();
              this.m_Item[panelObjectIdx].column[index].text.UpdateArabicPos();
            }
            if (this.m_ItemInfo[dataIdx].m_Column[index].m_EffID > 1000U)
            {
              vector2 = ((Graphic) this.m_Item[panelObjectIdx].column[index].text).rectTransform.anchoredPosition;
              vector2.x += 5f;
              ((Graphic) this.m_Item[panelObjectIdx].column[index].text).rectTransform.anchoredPosition = vector2;
              vector2 = ((Graphic) this.m_Item[panelObjectIdx].column[index].text).rectTransform.sizeDelta;
              vector2.x -= 5f;
              ((Graphic) this.m_Item[panelObjectIdx].column[index].text).rectTransform.sizeDelta = vector2;
              this.m_Item[panelObjectIdx].column[index].text.alignment = !GUIManager.Instance.IsArabic ? TextAnchor.MiddleLeft : TextAnchor.MiddleRight;
            }
            else
              this.m_Item[panelObjectIdx].column[index].text.alignment = TextAnchor.MiddleCenter;
            ((Behaviour) this.m_Item[panelObjectIdx].column[index].textShadow).enabled = false;
          }
          else
          {
            if (((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = false;
            if (((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = false;
            if ((bool) (Object) this.m_Item[panelObjectIdx].column[index].textShadow)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].textShadow).enabled = false;
          }
        }
        break;
      case 4:
        for (int index = 0; index < 6; ++index)
        {
          child1 = item.transform.GetChild(index);
          Vector2 sizeDelta = this.m_Item[panelObjectIdx].column[index].rect.sizeDelta with
          {
            y = this.m_ItemInfo[dataIdx].m_Height
          };
          this.m_Item[panelObjectIdx].column[index].rect.sizeDelta = sizeDelta;
          if (((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled)
            ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = false;
          if (((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled)
            ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = false;
          if ((bool) (Object) this.m_Item[panelObjectIdx].column[index].textShadow)
            ((Behaviour) this.m_Item[panelObjectIdx].column[index].textShadow).enabled = false;
        }
        break;
      case 5:
        float x3 = 0.0f;
        for (int index = 0; index < 6; ++index)
        {
          this.m_Item[panelObjectIdx].column[index].rect.anchoredPosition = new Vector2(x3, 0.0f);
          x3 += this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth;
          Vector2 sizeDelta = this.m_Item[panelObjectIdx].column[index].rect.sizeDelta with
          {
            x = this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth
          };
          this.m_Item[panelObjectIdx].column[index].rect.sizeDelta = sizeDelta;
          if (!((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled)
            ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = true;
          if (!((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled)
            ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = true;
          this.m_Item[panelObjectIdx].column[index].text.font = this.TTF;
          this.m_Item[panelObjectIdx].column[index].text.fontSize = 18;
          this.m_Item[panelObjectIdx].column[index].text.resizeTextMaxSize = 18;
          sizeDelta = ((Graphic) this.m_Item[panelObjectIdx].column[index].text).rectTransform.sizeDelta with
          {
            x = this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth
          };
          ((Graphic) this.m_Item[panelObjectIdx].column[index].text).rectTransform.sizeDelta = sizeDelta;
          this.m_Item[panelObjectIdx].column[index].text.text = this.m_ItemInfo[dataIdx].m_Column[index].m_Value.ToString();
          this.m_Item[panelObjectIdx].column[index].text.alignment = TextAnchor.MiddleCenter;
          ((Behaviour) this.m_Item[panelObjectIdx].column[index].textShadow).enabled = false;
          if (this.m_ItemInfo[dataIdx].m_Column[index].m_EffID != 0U)
          {
            if (!((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = true;
            if (!((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = true;
            this.m_Item[panelObjectIdx].column[index].text.font = this.TTF;
            this.m_Item[panelObjectIdx].column[index].text.fontSize = 18;
            this.m_Item[panelObjectIdx].column[index].text.resizeTextMaxSize = 18;
            this.m_Item[panelObjectIdx].column[index].text.resizeTextForBestFit = true;
            sizeDelta = ((Graphic) this.m_Item[panelObjectIdx].column[index].text).rectTransform.sizeDelta with
            {
              x = this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth
            };
            ((Graphic) this.m_Item[panelObjectIdx].column[index].text).rectTransform.sizeDelta = sizeDelta;
            this.m_Item[panelObjectIdx].column[index].text.text = this.m_ItemInfo[dataIdx].m_Column[index].m_Str.ToString();
          }
          else if (index == 0)
          {
            if (!((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = true;
            if (!((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = true;
          }
          else
          {
            if (((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = false;
            if (((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = false;
          }
          sizeDelta = this.m_Item[panelObjectIdx].column[index].imageRect.sizeDelta with
          {
            x = this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth
          };
          this.m_Item[panelObjectIdx].column[index].imageRect.sizeDelta = sizeDelta;
          this.m_Item[panelObjectIdx].column[index].image.sprite = this.m_ItemInfo[dataIdx].m_Column[0].m_Value == (long) this.m_NowLv_Extea ? (!this.m_ItemInfo[dataIdx].m_Column[index].bFisetColumn ? (!this.m_ItemInfo[dataIdx].m_Column[index].bLastColumn ? this.m_SpritesArray.GetSprite(9) : this.m_SpritesArray.GetSprite(11)) : this.m_SpritesArray.GetSprite(10)) : (dataIdx % 2 != 0 ? (!this.m_ItemInfo[dataIdx].m_Column[index].bFisetColumn ? (!this.m_ItemInfo[dataIdx].m_Column[index].bLastColumn ? this.m_SpritesArray.GetSprite(6) : this.m_SpritesArray.GetSprite(8)) : this.m_SpritesArray.GetSprite(7)) : (!this.m_ItemInfo[dataIdx].m_Column[index].bFisetColumn ? (!this.m_ItemInfo[dataIdx].m_Column[index].bLastColumn ? this.m_SpritesArray.GetSprite(3) : this.m_SpritesArray.GetSprite(5)) : this.m_SpritesArray.GetSprite(4)));
          this.m_Item[panelObjectIdx].column[index].text.UpdateArabicPos();
        }
        break;
      case 6:
        float x4 = 0.0f;
        for (int index = 0; index < 6; ++index)
        {
          if (index < this.m_ItemInfo[dataIdx].m_ColumNum + 1)
          {
            child1 = item.transform.GetChild(index);
            this.m_Item[panelObjectIdx].column[index].rect.anchoredPosition = new Vector2(x4, 0.0f);
            x4 += this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth;
            Vector2 sizeDelta = this.m_Item[panelObjectIdx].column[index].rect.sizeDelta with
            {
              x = this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth
            };
            this.m_Item[panelObjectIdx].column[index].rect.sizeDelta = sizeDelta;
            if (!((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = true;
            if (!((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = true;
            sizeDelta = this.m_Item[panelObjectIdx].column[index].rect.sizeDelta with
            {
              x = this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth
            };
            this.m_Item[panelObjectIdx].column[index].rect.sizeDelta = sizeDelta;
            this.m_Item[panelObjectIdx].column[index].imageRect.sizeDelta = sizeDelta;
            this.m_Item[panelObjectIdx].column[index].image.sprite = this.m_ItemInfo[dataIdx].m_Column[0].m_Value == (long) this.m_NowLv ? (!this.m_ItemInfo[dataIdx].m_Column[index].bFisetColumn ? (!this.m_ItemInfo[dataIdx].m_Column[index].bLastColumn ? this.m_SpritesArray.GetSprite(9) : this.m_SpritesArray.GetSprite(11)) : this.m_SpritesArray.GetSprite(10)) : (dataIdx % 2 != 0 ? (!this.m_ItemInfo[dataIdx].m_Column[index].bFisetColumn ? (!this.m_ItemInfo[dataIdx].m_Column[index].bLastColumn ? this.m_SpritesArray.GetSprite(6) : this.m_SpritesArray.GetSprite(8)) : this.m_SpritesArray.GetSprite(7)) : (!this.m_ItemInfo[dataIdx].m_Column[index].bFisetColumn ? (!this.m_ItemInfo[dataIdx].m_Column[index].bLastColumn ? this.m_SpritesArray.GetSprite(3) : this.m_SpritesArray.GetSprite(5)) : this.m_SpritesArray.GetSprite(4)));
            this.m_Item[panelObjectIdx].column[index].text.font = this.TTF;
            this.m_Item[panelObjectIdx].column[index].text.fontSize = 18;
            this.m_Item[panelObjectIdx].column[index].text.resizeTextMaxSize = 18;
            this.m_Item[panelObjectIdx].column[index].text.resizeTextForBestFit = true;
            sizeDelta = ((Graphic) this.m_Item[panelObjectIdx].column[index].text).rectTransform.sizeDelta with
            {
              x = this.m_ItemInfo[dataIdx].m_Column[index].ColumnWidth
            };
            ((Graphic) this.m_Item[panelObjectIdx].column[index].text).rectTransform.sizeDelta = sizeDelta;
            this.m_Item[panelObjectIdx].column[index].text.UpdateArabicPos();
            this.m_ItemInfo[dataIdx].m_Column[index].m_Str.ClearString();
            if (index == 0)
            {
              if ((int) this.m_ItemInfo[dataIdx].m_Column[index].m_EffID == (int) (uint) this.m_ItemInfo[dataIdx].m_Column[index].m_Value)
              {
                this.m_ItemInfo[dataIdx].m_Column[index].m_Str.IntToFormat((long) this.m_ItemInfo[dataIdx].m_Column[index].m_EffID);
                this.m_ItemInfo[dataIdx].m_Column[index].m_Str.AppendFormat("{0}");
              }
              else
              {
                this.m_ItemInfo[dataIdx].m_Column[index].m_Str.IntToFormat((long) this.m_ItemInfo[dataIdx].m_Column[index].m_EffID);
                this.m_ItemInfo[dataIdx].m_Column[index].m_Str.IntToFormat((long) (uint) this.m_ItemInfo[dataIdx].m_Column[index].m_Value);
                this.m_ItemInfo[dataIdx].m_Column[index].m_Str.AppendFormat(this.DM.mStringTable.GetStringByID(5900U));
              }
            }
            else
            {
              this.m_ItemInfo[dataIdx].m_Column[index].m_Str.IntToFormat((long) this.m_ItemInfo[dataIdx].m_Column[index].m_EffID);
              this.m_ItemInfo[dataIdx].m_Column[index].m_Str.AppendFormat(this.DM.mStringTable.GetStringByID(5901U));
            }
            this.m_Item[panelObjectIdx].column[index].text.text = this.m_ItemInfo[dataIdx].m_Column[index].m_Str.ToString();
            this.m_Item[panelObjectIdx].column[index].text.alignment = TextAnchor.MiddleCenter;
            ((Behaviour) this.m_Item[panelObjectIdx].column[index].textShadow).enabled = false;
          }
          else
          {
            if (((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].image).enabled = false;
            if (((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].text).enabled = false;
            if ((bool) (Object) this.m_Item[panelObjectIdx].column[index].textShadow)
              ((Behaviour) this.m_Item[panelObjectIdx].column[index].textShadow).enabled = false;
          }
          this.m_Item[panelObjectIdx].column[index].text.UpdateArabicPos();
        }
        break;
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public float CalculateTextHeight(ushort meffectId, float width, UIText context)
  {
    int num = 18;
    context.fontSize = num;
    context.font = this.TTF;
    context.resizeTextForBestFit = true;
    context.resizeTextMaxSize = num;
    context.resizeTextMinSize = 10;
    ((Graphic) context).rectTransform.sizeDelta = new Vector2(width, 40f);
    Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(meffectId);
    context.text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.InfoID);
    context.SetAllDirty();
    context.cachedTextGeneratorForLayout.Invalidate();
    return Mathf.Clamp(context.preferredHeight + 2f, 40f, context.preferredHeight + 2f);
  }
}
