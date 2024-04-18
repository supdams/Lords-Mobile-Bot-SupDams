// Decompiled with JetBrains decompiler
// Type: UITalent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UITalent : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
  public int DataCount;
  private UISpritesArray SpriteArray;
  private int MaxItemCount = 3;
  private float CheckSendTime = 2f;
  private readonly float[] Skillpos = new float[7]
  {
    118.37f,
    312.37f,
    506.37f,
    21.87f,
    215.87f,
    412.87f,
    603.87f
  };
  private readonly float[][] HorizontalPW = new float[11][]
  {
    new float[2]{ 295f, 201f },
    new float[2]{ 195f, 395f },
    new float[2]{ 195f, 201f },
    new float[2]{ 388f, 201f },
    new float[2]{ 102f, 588f },
    new float[2]{ 102f, 392f },
    new float[2]{ 290f, 392f },
    new float[2]{ 98f, 202f },
    new float[2]{ 291f, 202f },
    new float[2]{ 486f, 202f },
    new float[2]{ 98f, 202f }
  };
  private ScrollPanel TalentTreePanel;
  protected List<float> ItemsHeight = new List<float>();
  protected List<ushort> ItemIndex = new List<ushort>();
  private ushort[] HorzontalShowFlag;
  private UITalentInfo InfoWindow;
  private UIText TalentPointText;
  private UIText[] TextRefleshArray = new UIText[5];
  private CString TalentPointStr;
  private RectTransform HintTrans;
  private RectTransform ChangeNameRect;
  private GameObject SaveTalentObj;
  private byte SaveSlot;
  private byte CheckSaveFlag;
  private byte SaveTalentCheckStep = byte.MaxValue;
  private UIButton DefaultBtn;
  private UIButton ResetBtn;
  private Image DefaultImg;
  private byte[] CheckTalentData;
  private UITalent.ItemEdit[] TreeLayer;
  private byte PassFrame = 1;
  private byte DelayLoadScroll;
  private byte InitScroll;
  private byte GraphicLoaded;
  private int[] UpdateQueue = new int[3];

  public override void OnOpen(int arg1, int arg2)
  {
    this.SaveSlot = (byte) (arg1 & (int) byte.MaxValue);
    this.CheckSaveFlag = (byte) arg2;
    if ((arg1 & 32768) > 0)
      this.DelayLoadScroll = (byte) 2;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
    GUIManager.Instance.SetTalentIconSprite("UITechIcon", this.m_eWindow);
    this.TalentPointStr = StringManager.Instance.SpawnString();
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    DataManager instance = DataManager.Instance;
    this.DataCount = instance.TalentTreeLayout.TableCount;
    UIText component1 = this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.text = instance.mStringTable.GetStringByID(1501U);
    this.TextRefleshArray[0] = component1;
    UIText component2 = this.transform.GetChild(2).GetChild(0).GetComponent<UIText>();
    component2.font = ttfFont;
    component2.text = instance.mStringTable.GetStringByID(929U);
    this.TextRefleshArray[1] = component2;
    UIText component3 = this.transform.GetChild(3).GetChild(0).GetComponent<UIText>();
    component3.font = ttfFont;
    component3.text = instance.mStringTable.GetStringByID(1508U);
    this.TextRefleshArray[2] = component3;
    if (GUIManager.Instance.bOpenOnIPhoneX)
      ((Behaviour) this.transform.GetChild(7).GetComponent<CustomImage>()).enabled = false;
    else
      this.transform.GetChild(7).GetComponent<CustomImage>().hander = (UILoadImageHander) GUIManager.Instance.m_ItemInfo;
    this.transform.GetChild(7).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) GUIManager.Instance.m_ItemInfo;
    this.SpriteArray = this.transform.GetChild(5).GetComponent<UISpritesArray>();
    Transform child = this.transform.GetChild(6);
    this.TalentTreePanel = this.transform.GetChild(5).GetComponent<ScrollPanel>();
    UIButton component4 = this.transform.GetChild(7).GetChild(0).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_BtnID1 = 2;
    this.DefaultBtn = this.transform.GetChild(2).GetComponent<UIButton>();
    this.DefaultBtn.m_BtnID1 = 0;
    this.DefaultBtn.m_Handler = (IUIButtonClickHandler) this;
    this.DefaultImg = this.transform.GetChild(2).GetComponent<Image>();
    this.SaveTalentObj = ((Component) this.DefaultBtn).gameObject;
    if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 15)
      this.SaveTalentObj.SetActive(false);
    if (this.SaveSlot == (byte) 0)
    {
      instance.SaveTalentData[0].SaveIndex = (byte) 0;
      this.DefaultBtn.m_BtnID1 = 4;
      this.TextRefleshArray[1].text = instance.mStringTable.GetStringByID(923U);
    }
    this.ResetBtn = this.transform.GetChild(3).GetComponent<UIButton>();
    this.ResetBtn.m_BtnID1 = 1;
    this.ResetBtn.m_Handler = (IUIButtonClickHandler) this;
    this.TalentPointText = this.transform.GetChild(4).GetChild(0).GetComponent<UIText>();
    this.TalentPointText.font = ttfFont;
    this.TextRefleshArray[3] = component3;
    UIButtonHint uiButtonHint = this.transform.GetChild(4).GetChild(1).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint.m_Handler = (MonoBehaviour) this;
    this.HintTrans = this.transform.GetChild(9).GetComponent<RectTransform>();
    uiButtonHint.ControlFadeOut = ((Component) this.HintTrans).gameObject;
    UIText component5 = ((Transform) this.HintTrans).GetChild(0).GetComponent<UIText>();
    component5.font = ttfFont;
    component5.text = instance.mStringTable.GetStringByID(1502U);
    this.TextRefleshArray[4] = component5;
    this.HintTrans.sizeDelta = this.HintTrans.sizeDelta with
    {
      y = component5.preferredHeight + 16f
    };
    child.GetChild(2).GetChild(1).GetComponent<UIButton>().m_BtnID1 = 3;
    child.GetChild(3).GetChild(1).GetComponent<UIButton>().m_BtnID1 = 3;
    child.GetChild(4).GetChild(1).GetComponent<UIButton>().m_BtnID1 = 3;
    child.GetChild(5).GetChild(1).GetComponent<UIButton>().m_BtnID1 = 3;
    child.GetChild(2).GetChild(6).GetComponent<UIText>().font = ttfFont;
    child.GetChild(2).GetChild(5).GetComponent<UIText>().font = ttfFont;
    child.GetChild(3).GetChild(6).GetComponent<UIText>().font = ttfFont;
    child.GetChild(3).GetChild(5).GetComponent<UIText>().font = ttfFont;
    child.GetChild(4).GetChild(6).GetComponent<UIText>().font = ttfFont;
    child.GetChild(4).GetChild(5).GetComponent<UIText>().font = ttfFont;
    child.GetChild(5).GetChild(6).GetComponent<UIText>().font = ttfFont;
    child.GetChild(5).GetChild(5).GetComponent<UIText>().font = ttfFont;
    if (this.SaveSlot > (byte) 0)
    {
      if (this.CheckSaveFlag == (byte) 0)
      {
        instance.CloneTalentSave(this.SaveSlot, (byte) 0);
        this.SetDefaultBtnEnable(false);
      }
      else if (DataManager.Instance.CompareTalentSave(this.SaveSlot) == 1)
      {
        instance.CloneTalentSave(this.SaveSlot, (byte) 0);
        this.SetDefaultBtnEnable(false);
      }
      else
      {
        this.DelSaveFlage();
        if (instance.TalentSaveZero == (byte) 0 || instance.TalentSaveQueueCount > (byte) 0 || instance.SaveTalentData[0].TagName.GetHashCode(false) != instance.SaveTalentData[(int) this.SaveSlot].TagName.GetHashCode(false))
          this.SetDefaultBtnEnable(true);
        else
          this.SetDefaultBtnEnable(false);
      }
      this.SetResetOrLoadCurrentTalent();
      instance.SaveTalentData[0].SaveIndex = instance.SaveTalentData[(int) this.SaveSlot].SaveIndex;
      this.TextRefleshArray[0].text = instance.SaveTalentData[0].GetTagName().ToString();
      this.TextRefleshArray[0].SetAllDirty();
      this.TextRefleshArray[0].cachedTextGenerator.Invalidate();
      this.TextRefleshArray[0].cachedTextGeneratorForLayout.Invalidate();
      UISpritesArray component6 = this.transform.GetComponent<UISpritesArray>();
      this.transform.GetChild(0).GetComponent<Image>().sprite = component6.GetSprite(0);
      this.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = component6.GetSprite(1);
      this.transform.GetChild(2).GetComponent<Image>().sprite = component6.GetSprite(2);
      UIButton component7 = this.transform.GetChild(1).GetComponent<UIButton>();
      component7.m_Handler = (IUIButtonClickHandler) this;
      ((Component) component7).gameObject.SetActive(true);
      component7.m_BtnID1 = 5;
      this.ChangeNameRect = ((Component) component7).GetComponent<RectTransform>();
      this.ChangeNameRect.anchoredPosition = new Vector2((float) ((double) this.TextRefleshArray[0].preferredWidth * 0.5 + 25.0), this.ChangeNameRect.anchoredPosition.y);
    }
    GameConstants.ArrayFill<ushort>(this.HorzontalShowFlag, (ushort) 0);
    this.UpdateRoleTalentPoint();
  }

  private void SetResetOrLoadCurrentTalent()
  {
    if (this.SaveSlot > (byte) 0 && DataManager.Instance.SaveTalentData[0].NoUseTalent == (byte) 1 && DataManager.Instance.TalentSaveQueueCount == (byte) 0)
    {
      this.ResetBtn.m_BtnID1 = 6;
      this.TextRefleshArray[2].text = DataManager.Instance.mStringTable.GetStringByID(10032U);
    }
    else
    {
      this.ResetBtn.m_BtnID1 = 1;
      this.TextRefleshArray[2].text = DataManager.Instance.mStringTable.GetStringByID(1508U);
    }
  }

  public void DelSaveFlage()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_WindowStack.Count <= 0)
      return;
    for (int index = menu.m_WindowStack.Count - 1; index >= 0; --index)
    {
      GUIWindowStackData mWindow = menu.m_WindowStack[index];
      if (mWindow.m_eWindow == EGUIWindow.UI_Rally)
      {
        mWindow.m_Arg2 = 0;
        menu.m_WindowStack[index] = mWindow;
        break;
      }
    }
  }

  private void SetDefaultBtnEnable(bool enable)
  {
    ((Behaviour) this.DefaultBtn).enabled = enable;
    if (enable)
    {
      ((Graphic) this.TextRefleshArray[1]).color = Color.white;
      ((Graphic) this.DefaultImg).color = Color.white;
    }
    else
    {
      ((Graphic) this.TextRefleshArray[1]).color = new Color(0.898f, 0.0f, 0.31f);
      ((Graphic) this.DefaultImg).color = Color.gray;
    }
  }

  public void UpdateRoleTalentPoint()
  {
    this.TalentPointStr.ClearString();
    if (this.SaveSlot == (byte) 0)
      this.TalentPointStr.IntToFormat((long) DataManager.Instance.RoleTalentPoint);
    else
      this.TalentPointStr.IntToFormat((long) DataManager.Instance.SaveTalentData[0].RoleTalentPoint);
    this.TalentPointStr.AppendFormat("{0}");
    this.TalentPointText.text = this.TalentPointStr.ToString();
    this.TalentPointText.SetAllDirty();
    this.TalentPointText.cachedTextGenerator.Invalidate();
    if (this.InfoWindow == null)
      return;
    this.InfoWindow.UpdateRoleTalentPoint();
  }

  public void SetItemLayout(int dataIndex, int panelIndex)
  {
    TalentTreeLayoutTbl recordByIndex = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(dataIndex);
    this.TreeLayer[panelIndex].DataIndex = dataIndex;
    this.TreeLayer[panelIndex].PanelIndex = panelIndex;
    switch (recordByIndex.TalentCount)
    {
      case 1:
        this.SetTalentItemLayout(dataIndex, panelIndex, (byte) 0, recordByIndex.TreeData[0].TalentID, recordByIndex.TreeData[0].VerticalExtend, recordByIndex.TreeData[0].HorzontalExtend);
        Vector2 anchoredPosition1 = this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[1]
        };
        this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition = anchoredPosition1;
        ((Component) this.TreeLayer[panelIndex].Tech[1].TechTransform).gameObject.SetActive(false);
        ((Component) this.TreeLayer[panelIndex].Tech[2].TechTransform).gameObject.SetActive(false);
        ((Component) this.TreeLayer[panelIndex].Tech[3].TechTransform).gameObject.SetActive(false);
        break;
      case 2:
        this.SetTalentItemLayout(dataIndex, panelIndex, (byte) 0, recordByIndex.TreeData[0].TalentID, recordByIndex.TreeData[0].VerticalExtend, recordByIndex.TreeData[0].HorzontalExtend);
        Vector2 anchoredPosition2 = this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[4]
        };
        this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition = anchoredPosition2;
        this.SetTalentItemLayout(dataIndex, panelIndex, (byte) 1, recordByIndex.TreeData[1].TalentID, recordByIndex.TreeData[1].VerticalExtend, recordByIndex.TreeData[1].HorzontalExtend);
        Vector2 anchoredPosition3 = this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[5]
        };
        this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition = anchoredPosition3;
        ((Component) this.TreeLayer[panelIndex].Tech[2].TechTransform).gameObject.SetActive(false);
        ((Component) this.TreeLayer[panelIndex].Tech[3].TechTransform).gameObject.SetActive(false);
        break;
      case 3:
        this.SetTalentItemLayout(dataIndex, panelIndex, (byte) 0, recordByIndex.TreeData[0].TalentID, recordByIndex.TreeData[0].VerticalExtend, recordByIndex.TreeData[0].HorzontalExtend);
        Vector2 anchoredPosition4 = this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[0]
        };
        this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition = anchoredPosition4;
        this.SetTalentItemLayout(dataIndex, panelIndex, (byte) 1, recordByIndex.TreeData[1].TalentID, recordByIndex.TreeData[1].VerticalExtend, recordByIndex.TreeData[1].HorzontalExtend);
        Vector2 anchoredPosition5 = this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[1]
        };
        this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition = anchoredPosition5;
        this.SetTalentItemLayout(dataIndex, panelIndex, (byte) 2, recordByIndex.TreeData[2].TalentID, recordByIndex.TreeData[2].VerticalExtend, recordByIndex.TreeData[2].HorzontalExtend);
        Vector2 anchoredPosition6 = this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[2]
        };
        this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition = anchoredPosition6;
        ((Component) this.TreeLayer[panelIndex].Tech[3].TechTransform).gameObject.SetActive(false);
        break;
      case 4:
        this.SetTalentItemLayout(dataIndex, panelIndex, (byte) 0, recordByIndex.TreeData[0].TalentID, recordByIndex.TreeData[0].VerticalExtend, recordByIndex.TreeData[0].HorzontalExtend);
        Vector2 anchoredPosition7 = this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[3]
        };
        this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition = anchoredPosition7;
        this.SetTalentItemLayout(dataIndex, panelIndex, (byte) 1, recordByIndex.TreeData[1].TalentID, recordByIndex.TreeData[1].VerticalExtend, recordByIndex.TreeData[1].HorzontalExtend);
        Vector2 anchoredPosition8 = this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[4]
        };
        this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition = anchoredPosition8;
        this.SetTalentItemLayout(dataIndex, panelIndex, (byte) 2, recordByIndex.TreeData[2].TalentID, recordByIndex.TreeData[2].VerticalExtend, recordByIndex.TreeData[2].HorzontalExtend);
        Vector2 anchoredPosition9 = this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[5]
        };
        this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition = anchoredPosition9;
        this.SetTalentItemLayout(dataIndex, panelIndex, (byte) 3, recordByIndex.TreeData[3].TalentID, recordByIndex.TreeData[3].VerticalExtend, recordByIndex.TreeData[3].HorzontalExtend);
        Vector2 anchoredPosition10 = this.TreeLayer[panelIndex].Tech[3].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[6]
        };
        this.TreeLayer[panelIndex].Tech[3].TechTransform.anchoredPosition = anchoredPosition10;
        break;
    }
    this.SetHorizontalLayout(dataIndex, panelIndex);
  }

  public void SetTalentItemLayout(
    int dataIndex,
    int panelIndex,
    byte techIndex,
    ushort TechID,
    byte UpDown,
    byte LeftRight)
  {
    if (TechID == (ushort) 0)
    {
      ((Component) this.TreeLayer[panelIndex].Tech[(int) techIndex].TechTransform).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.TreeLayer[panelIndex].Tech[(int) techIndex].TechTransform).gameObject.SetActive(true);
      this.TreeLayer[panelIndex].Tech[(int) techIndex].SetItemStyle(ref this.SpriteArray, TechID);
      if (TechID < (ushort) 1000)
      {
        this.TreeLayer[panelIndex].Tech[(int) techIndex].SetTechID(TechID);
        this.TreeLayer[panelIndex].Tech[(int) techIndex].SetTechInfo(TechID);
        Vector2 sizeDelta = this.TreeLayer[panelIndex].Tech[(int) techIndex].TechIconTrans.sizeDelta;
        sizeDelta.Set(110f, 110f);
        this.TreeLayer[panelIndex].Tech[(int) techIndex].TechIconTrans.sizeDelta = sizeDelta;
        Quaternion localRotation = ((Transform) this.TreeLayer[panelIndex].Tech[(int) techIndex].TechIconTrans).localRotation with
        {
          eulerAngles = Vector3.zero
        };
        ((Transform) this.TreeLayer[panelIndex].Tech[(int) techIndex].TechIconTrans).localRotation = localRotation;
        this.TreeLayer[panelIndex].Tech[(int) techIndex].Lines[2].SetActive(((int) UpDown & 1) > 0);
        this.TreeLayer[panelIndex].Tech[(int) techIndex].Lines[3].SetActive(((int) UpDown & 2) > 0);
        this.TreeLayer[panelIndex].Tech[(int) techIndex].Lines[1].SetActive(((int) LeftRight & 1) > 0);
        this.TreeLayer[panelIndex].Tech[(int) techIndex].Lines[0].SetActive(((int) LeftRight & 2) > 0);
      }
      else
      {
        TalentTreeLayoutTbl recordByIndex = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(dataIndex + 1);
        switch (TechID)
        {
          case 1001:
            this.TreeLayer[panelIndex].Tech[(int) techIndex].SetTechID(recordByIndex.TreeData[(int) techIndex].TalentID);
            this.TreeLayer[panelIndex].Tech[(int) techIndex].TechBtn.m_BtnID2 = (int) TechID;
            this.TreeLayer[panelIndex].Tech[(int) techIndex].TechBtn.m_BtnID3 = (int) this.GetParentTechID(ref recordByIndex, this.TreeLayer[panelIndex].DataIndex, (int) techIndex, UITalent.NeighborWay.Up);
            break;
          case 1002:
            this.TreeLayer[panelIndex].Tech[(int) techIndex].SetTechID(recordByIndex.TreeData[(int) techIndex].TalentID);
            break;
          case 1003:
            this.TreeLayer[panelIndex].Tech[(int) techIndex].SetTechID(recordByIndex.TreeData[(int) techIndex].TalentID);
            this.TreeLayer[panelIndex].Tech[(int) techIndex].TechBtn.m_BtnID2 = (int) TechID;
            this.TreeLayer[panelIndex].Tech[(int) techIndex].TechBtn.m_BtnID3 = (int) this.GetParentTechID(ref recordByIndex, this.TreeLayer[panelIndex].DataIndex, (int) techIndex, UITalent.NeighborWay.Left);
            break;
        }
        this.TreeLayer[panelIndex].Tech[(int) techIndex].Level.text = string.Empty;
      }
    }
  }

  public void SetHorizontalLayout(int dataIndex, int panelIndex)
  {
    TalentTreeLayoutTbl recordByIndex = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(dataIndex);
    this.TreeLayer[panelIndex].Line[0].LineImg.sprite = this.SpriteArray.GetSprite(1);
    this.TreeLayer[panelIndex].Line[1].LineImg.sprite = this.SpriteArray.GetSprite(1);
    if (recordByIndex.HorizontalType == (byte) 0)
    {
      ((Component) this.TreeLayer[panelIndex].Line[0].LineImg).gameObject.SetActive(false);
      ((Component) this.TreeLayer[panelIndex].Line[1].LineImg).gameObject.SetActive(false);
    }
    else if (recordByIndex.HorizontalType < (byte) 11)
    {
      ((Component) this.TreeLayer[panelIndex].Line[0].LineImg).gameObject.SetActive(true);
      Vector2 anchoredPosition = this.TreeLayer[panelIndex].Line[0].LineTrans.anchoredPosition with
      {
        x = this.HorizontalPW[(int) recordByIndex.HorizontalType - 1][0]
      };
      this.TreeLayer[panelIndex].Line[0].LineTrans.anchoredPosition = anchoredPosition;
      Vector2 sizeDelta = this.TreeLayer[panelIndex].Line[0].LineTrans.sizeDelta with
      {
        x = this.HorizontalPW[(int) recordByIndex.HorizontalType - 1][1]
      };
      this.TreeLayer[panelIndex].Line[0].LineTrans.sizeDelta = sizeDelta;
      ((Component) this.TreeLayer[panelIndex].Line[1].LineImg).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.TreeLayer[panelIndex].Line[0].LineImg).gameObject.SetActive(true);
      Vector2 anchoredPosition = this.TreeLayer[panelIndex].Line[0].LineTrans.anchoredPosition with
      {
        x = this.HorizontalPW[(int) recordByIndex.HorizontalType - 1][0]
      };
      this.TreeLayer[panelIndex].Line[0].LineTrans.anchoredPosition = anchoredPosition;
      Vector2 sizeDelta = this.TreeLayer[panelIndex].Line[0].LineTrans.sizeDelta with
      {
        x = this.HorizontalPW[(int) recordByIndex.HorizontalType - 1][1]
      };
      this.TreeLayer[panelIndex].Line[0].LineTrans.sizeDelta = sizeDelta;
      ((Component) this.TreeLayer[panelIndex].Line[1].LineImg).gameObject.SetActive(true);
    }
    byte horizontalType = recordByIndex.HorizontalType;
    this.SetNodeLayout(panelIndex, horizontalType, ref recordByIndex, true);
    if (dataIndex + 1 < this.HorzontalShowFlag.Length)
    {
      recordByIndex = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(dataIndex + 1);
      this.SetNodeLayout(panelIndex, horizontalType, ref recordByIndex, false);
    }
    this.UpdateHorizontal(dataIndex, panelIndex);
  }

  public void SetNodeLayout(
    int panelIndex,
    byte HorizontalType,
    ref TalentTreeLayoutTbl Data,
    bool bDown)
  {
    byte num1 = 2;
    if (!bDown)
      num1 = (byte) 1;
    ushort num2 = 0;
    switch (HorizontalType)
    {
      case 1:
        if (Data.TreeData[0].TalentID > (ushort) 0 && ((int) Data.TreeData[0].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 1;
        if (Data.TreeData[1].TalentID > (ushort) 0 && ((int) Data.TreeData[1].VerticalExtend & (int) num1) > 0)
        {
          num2 |= (ushort) 2;
          break;
        }
        break;
      case 2:
        if (Data.TreeData[0].TalentID > (ushort) 0 && ((int) Data.TreeData[0].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 1;
        if (Data.TreeData[1].TalentID > (ushort) 0 && ((int) Data.TreeData[1].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 2;
        if (Data.TreeData[2].TalentID > (ushort) 0 && ((int) Data.TreeData[2].VerticalExtend & (int) num1) > 0)
        {
          num2 |= (ushort) 4;
          break;
        }
        break;
      case 3:
        if (Data.TreeData[0].TalentID > (ushort) 0 && ((int) Data.TreeData[0].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 1;
        if (Data.TreeData[1].TalentID > (ushort) 0 && ((int) Data.TreeData[1].VerticalExtend & (int) num1) > 0)
        {
          num2 |= (ushort) 2;
          break;
        }
        break;
      case 4:
        if (Data.TreeData[1].TalentID > (ushort) 0 && ((int) Data.TreeData[1].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 2;
        if (Data.TreeData[2].TalentID > (ushort) 0 && ((int) Data.TreeData[2].VerticalExtend & (int) num1) > 0)
        {
          num2 |= (ushort) 4;
          break;
        }
        break;
      case 5:
        if (Data.TreeData[0].TalentID > (ushort) 0 && ((int) Data.TreeData[0].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 1;
        if (Data.TreeData[1].TalentID > (ushort) 0 && ((int) Data.TreeData[1].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 2;
        if (Data.TreeData[2].TalentID > (ushort) 0 && ((int) Data.TreeData[2].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 4;
        if (Data.TreeData[3].TalentID > (ushort) 0 && ((int) Data.TreeData[3].VerticalExtend & (int) num1) > 0)
        {
          num2 |= (ushort) 8;
          break;
        }
        break;
      case 6:
        if (Data.TreeData[0].TalentID > (ushort) 0 && ((int) Data.TreeData[0].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 1;
        if (Data.TreeData[1].TalentID > (ushort) 0 && ((int) Data.TreeData[1].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 2;
        if (Data.TreeData[2].TalentID > (ushort) 0 && ((int) Data.TreeData[2].VerticalExtend & (int) num1) > 0)
        {
          num2 |= (ushort) 4;
          break;
        }
        break;
      case 7:
        if (Data.TreeData[1].TalentID > (ushort) 0 && ((int) Data.TreeData[1].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 2;
        if (Data.TreeData[2].TalentID > (ushort) 0 && ((int) Data.TreeData[2].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 4;
        if (Data.TreeData[3].TalentID > (ushort) 0 && ((int) Data.TreeData[3].VerticalExtend & (int) num1) > 0)
        {
          num2 |= (ushort) 8;
          break;
        }
        break;
      case 8:
        if (Data.TreeData[0].TalentID > (ushort) 0 && ((int) Data.TreeData[0].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 1;
        if (Data.TreeData[1].TalentID > (ushort) 0 && ((int) Data.TreeData[1].VerticalExtend & (int) num1) > 0)
        {
          num2 |= (ushort) 2;
          break;
        }
        break;
      case 9:
        if (Data.TreeData[1].TalentID > (ushort) 0 && ((int) Data.TreeData[1].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 2;
        if (Data.TreeData[2].TalentID > (ushort) 0 && ((int) Data.TreeData[2].VerticalExtend & (int) num1) > 0)
        {
          num2 |= (ushort) 4;
          break;
        }
        break;
      case 10:
        if (Data.TreeData[2].TalentID > (ushort) 0 && ((int) Data.TreeData[2].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 4;
        if (Data.TreeData[3].TalentID > (ushort) 0 && ((int) Data.TreeData[3].VerticalExtend & (int) num1) > 0)
        {
          num2 |= (ushort) 8;
          break;
        }
        break;
      case 11:
        if (Data.TreeData[0].TalentID > (ushort) 0 && ((int) Data.TreeData[0].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 1;
        if (Data.TreeData[1].TalentID > (ushort) 0 && ((int) Data.TreeData[1].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 2;
        if (Data.TreeData[2].TalentID > (ushort) 0 && ((int) Data.TreeData[2].VerticalExtend & (int) num1) > 0)
          num2 |= (ushort) 4;
        if (Data.TreeData[3].TalentID > (ushort) 0 && ((int) Data.TreeData[3].VerticalExtend & (int) num1) > 0)
        {
          num2 |= (ushort) 8;
          break;
        }
        break;
    }
    if (Data.HorizontalType == (byte) 0)
      num2 |= (ushort) 512;
    if (bDown)
    {
      this.HorzontalShowFlag[(int) Data.ID - 1] = num2;
    }
    else
    {
      ushort num3 = (ushort) ((uint) num2 << 5);
      this.HorzontalShowFlag[(int) Data.ID - 2] |= num3;
    }
  }

  private byte CheckTechState(ushort TechID)
  {
    return DataManager.Instance.CheckTalentState(TechID, this.SaveSlot, (byte) 1);
  }

  private unsafe void UpdateHorizontal(int dataIndex, int panelIndex)
  {
    TalentTreeLayoutTbl recordByIndex = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(dataIndex);
    int index1 = dataIndex;
    int index2 = panelIndex;
    bool flag = true;
    // ISSUE: untyped stack allocation
    ushort* numPtr1 = (ushort*) __untypedstackalloc((int) checked (8U * 2U));
    // ISSUE: untyped stack allocation
    int* numPtr2 = (int*) __untypedstackalloc((int) checked (4U * 4U));
    byte num1 = 0;
    int num2 = 0;
    *numPtr1 = recordByIndex.TreeData[0].TalentID;
    numPtr1[1] = recordByIndex.TreeData[1].TalentID;
    numPtr1[2] = recordByIndex.TreeData[2].TalentID;
    numPtr1[3] = recordByIndex.TreeData[3].TalentID;
    numPtr1[4] = (ushort) (short) recordByIndex.TreeData[0].HorzontalExtend;
    numPtr1[5] = (ushort) (short) recordByIndex.TreeData[1].HorzontalExtend;
    numPtr1[6] = (ushort) (short) recordByIndex.TreeData[2].HorzontalExtend;
    numPtr1[7] = (ushort) (short) recordByIndex.TreeData[3].HorzontalExtend;
    for (int index3 = 0; index3 < (int) recordByIndex.TalentCount; ++index3)
    {
      int num3 = 1 << index3;
      if (((int) this.HorzontalShowFlag[index1] & num3) > 0)
      {
        num1 |= this.GetNodePos(recordByIndex.TalentCount, index3);
        if (numPtr1[index3] > (ushort) 0)
        {
          if (numPtr1[index3] == (ushort) 1001)
            numPtr1[index3] = this.GetParentTechID(ref recordByIndex, dataIndex, index3, UITalent.NeighborWay.Up);
          int index4;
          if (((int) this.CheckTechState(numPtr1[index3]) & 2) > 0)
          {
            num2 |= (int) this.GetNodePos(recordByIndex.TalentCount, index3);
            index4 = 2;
          }
          else
          {
            index4 = 1;
            flag = false;
          }
          this.TreeLayer[index2].Tech[index3].Lines[3].LineImage.sprite = this.SpriteArray.GetSprite(index4);
          this.TreeLayer[index2].Tech[index3].Lines[0].LineImage.sprite = this.SpriteArray.GetSprite(index4);
          this.TreeLayer[index2].Tech[index3].Lines[1].LineImage.sprite = this.SpriteArray.GetSprite(index4);
        }
      }
      else if (numPtr1[index3] > (ushort) 0)
      {
        int num4 = 2;
        TalentTreeLayoutTbl Data = recordByIndex;
        for (int way = 0; way < 4; ++way)
        {
          if (way != 2)
          {
            if (((int) this.CheckTechState(numPtr1[index3]) & 2) > 0)
            {
              Data = recordByIndex;
              numPtr2[way] = ((int) this.CheckTechState(this.GetParentTechID(ref Data, dataIndex, index3, (UITalent.NeighborWay) way)) & 1) <= 0 ? num4 : num4 - 1;
            }
            else
              numPtr2[way] = num4 - 1;
          }
        }
        this.TreeLayer[index2].Tech[index3].Lines[3].LineImage.sprite = this.SpriteArray.GetSprite(numPtr2[3]);
        this.TreeLayer[index2].Tech[index3].Lines[0].LineImage.sprite = this.SpriteArray.GetSprite(*numPtr2);
        this.TreeLayer[index2].Tech[index3].Lines[1].LineImage.sprite = this.SpriteArray.GetSprite(numPtr2[1]);
      }
      if (index3 > 0 && index3 < 4 && ((int) numPtr1[4 + index3] & 1) > 0)
      {
        this.TreeLayer[index2].Tech[index3 - 1].Lines[0].LineImage.sprite = this.TreeLayer[index2].Tech[index3].Lines[1].LineImage.sprite;
        this.TreeLayer[index2].Tech[index3 - 1].Lines[0].SetActive(true);
        this.TreeLayer[index2].Tech[index3].Lines[1].SetActive(false);
      }
    }
    if (flag)
    {
      this.HorzontalShowFlag[index1] |= (ushort) 16;
      this.TreeLayer[index2].Line[0].LineImg.sprite = this.SpriteArray.GetSprite(2);
    }
    byte num5 = 0;
    int num6 = 0;
    int index5 = (index2 + 1) % this.MaxItemCount;
    int index6 = index5 != 0 ? index5 : this.MaxItemCount - 1;
    if (this.TalentTreePanel.GetBeginIdx() + 2 == dataIndex)
    {
      int panelIndex1 = panelIndex - 1;
      if (panelIndex1 < 0)
        panelIndex1 = this.MaxItemCount - 1;
      this.UpdateHorizontal(dataIndex - 1, panelIndex1);
    }
    else if (this.DataCount > dataIndex + 1)
    {
      recordByIndex = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(dataIndex + 1);
      *numPtr1 = recordByIndex.TreeData[0].TalentID;
      numPtr1[1] = recordByIndex.TreeData[1].TalentID;
      numPtr1[2] = recordByIndex.TreeData[2].TalentID;
      numPtr1[3] = recordByIndex.TreeData[3].TalentID;
      int num7 = (int) this.HorzontalShowFlag[index1] >> 5;
      for (int index7 = 0; index7 < (int) recordByIndex.TalentCount; ++index7)
      {
        int num8 = 1 << index7;
        if ((num7 & num8) > 0)
        {
          if (numPtr1[index7] == (ushort) 1001)
            numPtr1[index7] = this.GetParentTechID(ref recordByIndex, dataIndex + 1, index7, UITalent.NeighborWay.Down);
          num5 |= this.GetNodePos(recordByIndex.TalentCount, index7);
          if (((int) this.HorzontalShowFlag[index1] & 16) > 0 || ((int) this.CheckTechState(numPtr1[index7]) & 2) > 0)
          {
            num6 |= (int) this.GetNodePos(recordByIndex.TalentCount, index7);
            this.TreeLayer[index5].Tech[index7].Lines[2].LineImage.sprite = this.SpriteArray.GetSprite(2);
          }
          else
            this.TreeLayer[index5].Tech[index7].Lines[2].LineImage.sprite = this.SpriteArray.GetSprite(1);
        }
        else
          this.TreeLayer[index5].Tech[index7].Lines[2].LineImage.sprite = ((int) this.CheckTechState(numPtr1[index7]) & 1) != 0 || ((int) this.CheckTechState(this.GetParentTechID(ref recordByIndex, dataIndex + 1, index7, UITalent.NeighborWay.Up)) & 2) <= 0 ? this.SpriteArray.GetSprite(1) : this.SpriteArray.GetSprite(2);
      }
    }
    int index8 = 0;
    int num9 = 0;
    if (index6 == index5)
    {
      index8 = 7;
      num9 = 7;
    }
    for (int index9 = 0; index9 < 7; ++index9)
    {
      int num10 = 1 << index9;
      Vector2 anchoredPosition;
      if (((int) num1 & num10) > 0 && ((int) num5 & num10) == 0)
      {
        anchoredPosition = ((Graphic) this.TreeLayer[index6].Node[index8]).rectTransform.anchoredPosition with
        {
          x = this.Skillpos[index9] + 100.3f
        };
        ((Graphic) this.TreeLayer[index6].Node[index8]).rectTransform.anchoredPosition = anchoredPosition;
        this.TreeLayer[index6].Node[index8].sprite = (num2 & num10) <= 0 ? this.SpriteArray.GetSprite(7) : this.SpriteArray.GetSprite(8);
        ++index8;
      }
      else if (((int) num5 & num10) > 0)
      {
        anchoredPosition = ((Graphic) this.TreeLayer[index6].Node[index8]).rectTransform.anchoredPosition with
        {
          x = this.Skillpos[index9] + 100.3f
        };
        ((Graphic) this.TreeLayer[index6].Node[index8]).rectTransform.anchoredPosition = anchoredPosition;
        this.TreeLayer[index6].Node[index8].sprite = (num6 & num10) <= 0 ? this.SpriteArray.GetSprite(7) : this.SpriteArray.GetSprite(8);
        ++index8;
      }
    }
    for (int index10 = num9; index10 < num9 + 7; ++index10)
    {
      if (index8 > index10)
        ((Component) this.TreeLayer[index6].Node[index10]).gameObject.SetActive(true);
      else
        ((Component) this.TreeLayer[index6].Node[index10]).gameObject.SetActive(false);
    }
  }

  public ushort GetParentTechID(
    ref TalentTreeLayoutTbl Data,
    int dataIndex,
    int techIndex,
    UITalent.NeighborWay way)
  {
    Data = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(dataIndex);
    ushort talentId1 = Data.TreeData[techIndex].TalentID;
    switch (way)
    {
      case UITalent.NeighborWay.Right:
        if (techIndex + 1 >= Data.TreeData.Length)
          return 0;
        return Data.TreeData[techIndex + 1].TalentID == (ushort) 1002 ? this.GetParentTechID(ref Data, dataIndex, techIndex, UITalent.NeighborWay.Down) : Data.TreeData[techIndex + 1].TalentID;
      case UITalent.NeighborWay.Left:
        if (techIndex == 0)
          return 0;
        return Data.TreeData[techIndex - 1].TalentID == (ushort) 1002 ? this.GetParentTechID(ref Data, dataIndex, techIndex, UITalent.NeighborWay.Down) : Data.TreeData[techIndex - 1].TalentID;
      case UITalent.NeighborWay.Up:
        if (dataIndex > 0)
        {
          Data = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(--dataIndex);
          switch (Data.TreeData[techIndex].TalentID)
          {
            case 1001:
              return this.GetParentTechID(ref Data, dataIndex, techIndex, UITalent.NeighborWay.Up);
            case 1002:
              return techIndex + 1 >= Data.TreeData.Length ? Data.TreeData[techIndex + 1].TalentID : (ushort) 0;
            case 1003:
              return techIndex == 0 ? (ushort) 0 : Data.TreeData[techIndex - 1].TalentID;
            default:
              return Data.TreeData[techIndex].TalentID;
          }
        }
        else
          break;
      case UITalent.NeighborWay.Down:
        if (dataIndex + 1 < this.HorzontalShowFlag.Length)
        {
          Data = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(++dataIndex);
          ushort talentId2 = Data.TreeData[techIndex].TalentID;
          return talentId2 == (ushort) 1001 ? talentId1 : talentId2;
        }
        break;
    }
    return 0;
  }

  public byte GetNodePos(byte NodeCount, int Index)
  {
    switch (NodeCount)
    {
      case 1:
        return 2;
      case 2:
        return (byte) (1 << 4 + Index);
      case 3:
        return (byte) (1 << Index);
      default:
        return (byte) (1 << 3 + Index);
    }
  }

  public override bool OnBackButtonClick()
  {
    if (this.InfoWindow != null && ((Component) this.InfoWindow.ThisTransform).gameObject.activeSelf)
      this.InfoWindow.SetActive(false);
    this.CheckSaveClose();
    return true;
  }

  private void CheckSaveClose()
  {
    DataManager instance = DataManager.Instance;
    StringTable mStringTable = instance.mStringTable;
    if (this.SaveSlot > (byte) 0 && instance.TalentSaveQueueCount > (byte) 0)
    {
      GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, mStringTable.GetStringByID(5893U), mStringTable.GetStringByID(936U), 2, YesText: mStringTable.GetStringByID(3U), NoText: mStringTable.GetStringByID(4U));
    }
    else
    {
      instance.SaveTalentData[0].SaveIndex = (byte) 0;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
        return;
      menu.CloseMenu();
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    DataManager instance = DataManager.Instance;
    StringTable mStringTable = instance.mStringTable;
    if (sender.m_BtnID1 == 2)
      this.CheckSaveClose();
    else if (sender.m_BtnID1 == 1)
    {
      if (this.SaveSlot > (byte) 0)
      {
        if (instance.SaveTalentData[0].NoUseTalent == (byte) 0)
          this.SetDefaultBtnEnable(true);
        instance.ClearCurTalentSave();
        this.UpdateRoleTalentPoint();
        if (this.InitScroll == (byte) 1)
          this.TalentTreePanel.GoTo(0);
        this.SetResetOrLoadCurrentTalent();
      }
      else if (instance.NoUseTalent == (byte) 1)
        GUIManager.Instance.AddHUDMessage(mStringTable.GetStringByID(1511U), (ushort) byte.MaxValue);
      else
        GUIManager.Instance.UseOrSpend((ushort) 1008, mStringTable.GetStringByID(1508U), (ushort) 0, (ushort) 0, (ushort) 0, maxcount: (ushort) 0);
    }
    else if (sender.m_BtnID1 == 6)
    {
      if (instance.NoUseTalent == (byte) 1)
      {
        GUIManager.Instance.AddHUDMessage(mStringTable.GetStringByID(10029U), (ushort) byte.MaxValue);
      }
      else
      {
        instance.ClearCurTalentSave();
        if (this.CheckTalentData == null)
          this.CheckTalentData = new byte[instance.AllTalentData.Length];
        else
          Array.Clear((Array) this.CheckTalentData, 0, this.CheckTalentData.Length);
        for (ushort index = 0; (int) index < instance.AllTalentData.Length; ++index)
        {
          if (instance.AllTalentData[(int) index] > (byte) 0 && this.CheckTalentData[(int) index] != (byte) 1)
          {
            ushort num = (ushort) ((uint) index + 1U);
            TalentTbl recordByKey = instance.TalentData.GetRecordByKey(num);
            this.TalentLevelup(ref recordByKey, num, instance.GetTalentLevel(num, (byte) 0));
          }
        }
        this.SetResetOrLoadCurrentTalent();
      }
    }
    else if (sender.m_BtnID1 == 0)
      this.SaveTalentCheckStep = (byte) 0;
    else if (sender.m_BtnID1 == 4)
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_TalentSave);
    else if (sender.m_BtnID1 == 5)
    {
      instance.OpenAllianceBox((ushort) 36, 10, Para: 0L);
    }
    else
    {
      if (((int) this.CheckTechState((ushort) sender.m_BtnID2) & 32) > 0)
        return;
      this.OpenTalentInfo((ushort) sender.m_BtnID2);
      Debug.Log((object) ("TalentID=" + (object) sender.m_BtnID2));
    }
  }

  private void TalentLevelup(ref TalentTbl talentData, ushort talentID, byte Lv)
  {
    DataManager instance = DataManager.Instance;
    if (((int) instance.CheckTalentState(talentID, this.SaveSlot, instance.GetTalentLevel(talentID, (byte) 0)) & 1) > 0)
    {
      talentData = instance.TalentData.GetRecordByKey(talentData.NeedTalentID);
      this.TalentLevelup(ref talentData, talentData.TalentID, instance.GetTalentLevel(talentData.TalentID, (byte) 0));
    }
    if (this.CheckTalentData[(int) talentID - 1] != (byte) 0)
      return;
    this.CheckTalentData[(int) talentID - 1] = (byte) 1;
    instance.sendTalentSaveQueue(talentID, this.SaveSlot, instance.GetTalentLevel(talentID, (byte) 0), (byte) 0);
  }

  public void CheckSaveTalentRule()
  {
    if (((int) this.SaveTalentCheckStep & 128) > 0)
      return;
    DataManager instance = DataManager.Instance;
    StringTable mStringTable = instance.mStringTable;
    if (((int) this.SaveTalentCheckStep & 1) == 0)
    {
      if (instance.SaveTalentData[0].TagName.Length > 0)
      {
        this.SaveTalentCheckStep |= (byte) 1;
        this.CheckSaveTalentRule();
      }
      else
      {
        this.SaveTalentCheckStep |= (byte) 128;
        GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, mStringTable.GetStringByID(5893U), mStringTable.GetStringByID(932U), arg2: 1, YesText: mStringTable.GetStringByID(3U), NoText: mStringTable.GetStringByID(4U));
      }
    }
    else if (((int) this.SaveTalentCheckStep & 2) == 0)
    {
      if (instance.SaveTalentData[0].RoleTalentPoint == (ushort) 0)
      {
        this.SaveTalentCheckStep |= (byte) 2;
        this.CheckSaveTalentRule();
      }
      else
      {
        this.SaveTalentCheckStep |= (byte) 128;
        GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, mStringTable.GetStringByID(5893U), mStringTable.GetStringByID(933U), arg2: 2, YesText: mStringTable.GetStringByID(3U), NoText: mStringTable.GetStringByID(4U));
      }
    }
    else
    {
      this.SaveTalentCheckStep = byte.MaxValue;
      GUIManager.Instance.UseOrSpend(GameConstants.TalentSaveItemID, mStringTable.GetStringByID(934U), (ushort) 0, (ushort) ((uint) this.SaveSlot - 1U), (ushort) instance.TalentSaveQueueCount, maxcount: (ushort) 0);
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (arg1 == 2 && bOK)
    {
      DataManager.Instance.SaveTalentData[0].SaveIndex = (byte) 0;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
        return;
      menu.CloseMenu();
    }
    else
    {
      if (arg1 != 0 || !bOK)
        return;
      this.SaveTalentCheckStep |= (byte) arg2;
      this.SaveTalentCheckStep &= (byte) 127;
    }
  }

  public void OpenTalentInfo(ushort talentid)
  {
    if (this.InfoWindow == null)
    {
      RectTransform transform = (UnityEngine.Object.Instantiate(this.m_AssetBundle.Load("UITalentInfo")) as GameObject).transform as RectTransform;
      ((Transform) transform).SetParent(this.transform.GetChild(8));
      transform.anchoredPosition3D = Vector3.zero;
      transform.sizeDelta = Vector2.zero;
      ((Transform) transform).localScale = Vector3.one;
      this.InfoWindow = new UITalentInfo(transform, this.SaveSlot);
      this.InfoWindow.OnOpen((int) talentid, 0);
    }
    else
      this.InfoWindow.UpdateUI((int) talentid, 0);
  }

  public override void OnClose()
  {
    if (this.InfoWindow != null)
    {
      if (this.SaveSlot > (byte) 0 && (int) this.SaveSlot == (int) DataManager.Instance.SaveTalentData[0].SaveIndex)
        this.InfoWindow.SetTalentSaveFlag();
      this.InfoWindow.OnDestroy();
    }
    StringManager.Instance.DeSpawnString(this.TalentPointStr);
    if (this.TreeLayer != null)
    {
      for (int index = 0; index < this.TreeLayer.Length; ++index)
        this.TreeLayer[index].OnClose();
    }
    if (this.PassFrame == (byte) 0 && this.InitScroll == (byte) 1)
    {
      GUIManager.Instance.TalentSaved[0] = (byte) this.TalentTreePanel.GetBeginIdx();
      GameConstants.GetBytes(this.TalentTreePanel.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition.y, GUIManager.Instance.TalentSaved, 1);
    }
    DataManager.Instance.CheckTalentSend();
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((UnityEngine.Object) this.TreeLayer[panelObjectIdx].ItemTransform == (UnityEngine.Object) null)
      this.TreeLayer[panelObjectIdx].Init(item.transform, (IUIButtonClickHandler) this, this.SaveSlot);
    else
      this.SetItemLayout(dataIdx, panelObjectIdx);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (this.PassFrame > (byte) 0)
      return;
    byte Kind = 0;
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        this.UpdateRoleTalentPoint();
        Kind |= (byte) 3;
        break;
      case NetworkNews.Refresh:
        this.UpdateRoleTalentPoint();
        if (this.InfoWindow != null)
        {
          this.InfoWindow.UpdateRoleTalentPoint();
          break;
        }
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Item)
        {
          if (networkNews != NetworkNews.Refresh_Build)
          {
            if (networkNews != NetworkNews.Refresh_Technology)
            {
              if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
              {
                this.TextRefresh();
                break;
              }
              break;
            }
          }
          else
          {
            if (!this.SaveTalentObj.activeSelf && GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 15)
              this.SaveTalentObj.SetActive(true);
            if (this.InfoWindow != null)
            {
              this.InfoWindow.UpdateBtnStyle();
              break;
            }
            break;
          }
        }
        Kind |= (byte) 3;
        if (this.SaveSlot > (byte) 0)
        {
          this.SetDefaultBtnEnable(DataManager.Instance.TalentSaveQueueCount > (byte) 0);
          break;
        }
        break;
    }
    if (((int) Kind & 1) > 0)
      this.UpdateRoleTalentPoint();
    if (((int) Kind & 2) > 0 && this.InitScroll == (byte) 1)
    {
      for (int index1 = 0; index1 < this.TreeLayer.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.TreeLayer[index1].Tech.Length; ++index2)
          this.TreeLayer[index1].Tech[index2].UpdateState(Kind);
        this.UpdateHorizontal(this.TreeLayer[index1].DataIndex, this.TreeLayer[index1].PanelIndex);
      }
    }
    if (Kind <= (byte) 0 || this.InfoWindow == null || !((Component) this.InfoWindow.ThisTransform).gameObject.activeSelf)
      return;
    this.InfoWindow.UpdateTalentInfo();
  }

  private void TextRefresh()
  {
    for (int index = 0; index < this.TextRefleshArray.Length; ++index)
    {
      ((Behaviour) this.TextRefleshArray[index]).enabled = false;
      ((Behaviour) this.TextRefleshArray[index]).enabled = true;
    }
    ((Behaviour) this.TalentPointText).enabled = false;
    ((Behaviour) this.TalentPointText).enabled = true;
    if (this.InitScroll == (byte) 1)
    {
      for (int index1 = 0; index1 < this.TreeLayer.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.TreeLayer[index1].Tech.Length; ++index2)
          this.TreeLayer[index1].Tech[index2].TextRefresh();
      }
    }
    if (this.InfoWindow == null)
      return;
    this.InfoWindow.TextRefresh();
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (this.PassFrame > (byte) 0)
    {
      this.UpdateQueue[0] = 1;
      this.UpdateQueue[1] = arg1;
      this.UpdateQueue[2] = arg2;
    }
    else
    {
      switch (arg1)
      {
        case -4:
          this.UpdateRoleTalentPoint();
          if (this.SaveSlot <= (byte) 0)
            break;
          if (DataManager.Instance.CompareTalentSave(this.SaveSlot) == 1)
          {
            (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
            break;
          }
          this.UpdateRoleTalentPoint();
          break;
        case -3:
          (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
          break;
        case -2:
          this.TextRefleshArray[0].text = DataManager.Instance.SaveTalentData[0].GetTagName().ToString();
          this.TextRefleshArray[0].SetAllDirty();
          this.TextRefleshArray[0].cachedTextGenerator.Invalidate();
          this.TextRefleshArray[0].cachedTextGeneratorForLayout.Invalidate();
          this.ChangeNameRect.anchoredPosition = new Vector2((float) ((double) this.TextRefleshArray[0].preferredWidth * 0.5 + 25.0), this.ChangeNameRect.anchoredPosition.y);
          if (DataManager.Instance.SaveTalentData[0].TagName.Length <= 0)
            break;
          this.SetDefaultBtnEnable(true);
          break;
        case -1:
          if (this.InitScroll == (byte) 1)
          {
            this.UpdateGraphic();
            this.GraphicLoaded = (byte) 1;
            break;
          }
          this.GraphicLoaded = (byte) 2;
          break;
        default:
          this.SetResetOrLoadCurrentTalent();
          this.CheckSendTime = 2f;
          break;
      }
    }
  }

  private void UpdateGraphic()
  {
    GUIManager instance = GUIManager.Instance;
    for (int index1 = 0; index1 < this.TreeLayer.Length; ++index1)
    {
      for (int index2 = 0; index2 < this.TreeLayer[index1].Tech.Length; ++index2)
      {
        if ((bool) (UnityEngine.Object) this.TreeLayer[index1].Tech[index2].FrameTransform)
          this.TreeLayer[index1].Tech[index2].TechIcon.sprite = instance.GetTechSprite(this.TreeLayer[index1].Tech[index2].GraphicID);
        ((MaskableGraphic) this.TreeLayer[index1].Tech[index2].TechIcon).material = instance.TechMaterial;
        ((Behaviour) this.TreeLayer[index1].Tech[index2].TechIcon).enabled = true;
      }
    }
    if (this.InfoWindow == null)
      return;
    this.InfoWindow.UpdateUI(-1, 0);
  }

  public void Update()
  {
    if (this.PassFrame > (byte) 0)
    {
      --this.PassFrame;
      if (this.PassFrame == (byte) 0)
      {
        this.MaxItemCount = Mathf.Min(this.MaxItemCount, this.DataCount);
        this.HorzontalShowFlag = new ushort[this.DataCount];
        this.TreeLayer = new UITalent.ItemEdit[this.MaxItemCount];
        if (this.DelayLoadScroll == (byte) 0)
        {
          this.initTalentPanel();
          this.TalentTreePanel.gameObject.SetActive(true);
          this.TextRefresh();
        }
        if (this.InitScroll == (byte) 1 && this.UpdateQueue[0] == 1)
        {
          this.UpdateUI(this.UpdateQueue[1], this.UpdateQueue[2]);
          Array.Clear((Array) this.UpdateQueue, 0, this.UpdateQueue.Length);
        }
        ushort talentid = GameConstants.ConvertBytesToUShort(GUIManager.Instance.TalentSaved, 5);
        if (talentid > (ushort) 0)
          this.OpenTalentInfo(talentid);
      }
    }
    else if (this.DelayLoadScroll > (byte) 0)
    {
      --this.DelayLoadScroll;
      if (this.DelayLoadScroll == (byte) 0)
      {
        this.initTalentPanel();
        this.TalentTreePanel.gameObject.SetActive(true);
        if (this.InitScroll == (byte) 1 && this.UpdateQueue[0] == 1)
        {
          this.UpdateUI(this.UpdateQueue[1], this.UpdateQueue[2]);
          Array.Clear((Array) this.UpdateQueue, 0, this.UpdateQueue.Length);
        }
        if (this.GraphicLoaded == (byte) 2)
        {
          this.UpdateGraphic();
          this.GraphicLoaded = (byte) 1;
        }
        this.TextRefresh();
      }
    }
    else if (this.InfoWindow != null)
    {
      this.CheckSendTime -= Time.deltaTime;
      if ((double) this.CheckSendTime < 0.0)
      {
        this.CheckSendTime = 2f;
        DataManager.Instance.CheckTalentSend();
      }
      this.InfoWindow.Update();
    }
    if (this.SaveTalentCheckStep >= byte.MaxValue)
      return;
    this.CheckSaveTalentRule();
  }

  public void initTalentPanel()
  {
    for (byte index = 0; (int) index < this.MaxItemCount; ++index)
    {
      this.ItemsHeight.Add(242f);
      this.ItemIndex.Add((ushort) index);
    }
    this.TalentTreePanel.IntiScrollPanel(446f, 0.0f, 0.0f, this.ItemsHeight, this.MaxItemCount, (IUpDateScrollPanel) this);
    if (this.DataCount > this.MaxItemCount)
    {
      for (int maxItemCount = this.MaxItemCount; maxItemCount < this.DataCount; ++maxItemCount)
      {
        this.ItemsHeight.Add(242f);
        this.ItemIndex.Add((ushort) maxItemCount);
      }
    }
    this.TalentTreePanel.AddNewDataHeight(this.ItemsHeight);
    if (this.SaveSlot == (byte) 0)
    {
      byte num = GUIManager.Instance.TalentSaved[0];
      float height = GameConstants.ConvertBytesToFloat(GUIManager.Instance.TalentSaved, 1);
      this.TalentTreePanel.GoTo((int) num, height);
      this.UpdateTopLayer((int) num);
    }
    this.InitScroll = (byte) 1;
  }

  private void UpdateTopLayer(int begin)
  {
    if (begin == 0)
      return;
    DataManager instance = DataManager.Instance;
    for (int index1 = 0; index1 < this.TreeLayer.Length; ++index1)
    {
      if (this.TreeLayer[index1].DataIndex == begin)
      {
        for (int index2 = 0; index2 < this.TreeLayer[index1].Tech.Length; ++index2)
        {
          if (((Component) this.TreeLayer[index1].Tech[index2].TechTransform).gameObject.activeSelf && this.TreeLayer[index1].Tech[index2].TechBtn.m_BtnID2 != 0 && (instance.GetTalentLevel((ushort) this.TreeLayer[index1].Tech[index2].TechBtn.m_BtnID2, (byte) 0) > (byte) 0 || ((int) this.CheckTechState((ushort) this.TreeLayer[index1].Tech[index2].TechBtn.m_BtnID2) & 1) == 0))
            this.TreeLayer[index1].Tech[index2].Lines[2].LineImage.sprite = this.SpriteArray.GetSprite(2);
        }
        break;
      }
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
    sender.GetTipPosition(this.HintTrans);
    ((Component) this.HintTrans).gameObject.SetActive(true);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    ((Component) this.HintTrans).gameObject.SetActive(false);
  }

  public enum TechSprite
  {
    FrameFull,
    Line,
    LineOn,
    Linel,
    LinelOn,
    Liner,
    LinerOn,
    Point,
    PointOn,
  }

  private enum UIControl
  {
    Background,
    ReTitleBtn,
    DefaultBtn,
    ResetBtn,
    TalentPoint,
    Scroll,
    Item,
    Close,
    InfoLink,
    Hint,
  }

  private enum ItemControl
  {
    HorizontalLineDown0,
    HorizontalLineDown1,
    Skill1,
    Skill2,
    Skill3,
    Skill4,
    Node,
  }

  private enum LeaveControl
  {
    Direction,
    SkillPic,
    Black,
    Frame,
    FrameFull,
    Name,
    LvText,
  }

  private enum eFrame
  {
    Lock,
    Degree,
  }

  private enum ClickType
  {
    SaveSlot,
    Reset,
    Close,
    Tech,
    Save,
    ChangeTitle,
    LoadCurrentTalent,
  }

  public enum NeighborWay
  {
    Right,
    Left,
    Up,
    Down,
  }

  public enum eLine
  {
    Right,
    Left,
    Up,
    Down,
  }

  private class TechItem
  {
    public RectTransform TechTransform;
    public RectTransform TechIconTrans;
    public RectTransform Degree;
    public RectTransform FrameFullTrans;
    public RectTransform FrameTrans;
    public Transform BlackFrame;
    public Transform Lock;
    public Transform FrameTransform;
    public Transform Direction;
    public Image TechIcon;
    public Image FrameFull;
    public UIButton TechBtn;
    public UIText Level;
    public UIText Name;
    private CString TechNameStr;
    private CString TechLvStr;
    public ushort GraphicID;
    private Vector2 FrameFullSize;
    public UITalent.TechItem._LineInfo[] Lines = new UITalent.TechItem._LineInfo[4];
    private byte State;
    private byte SaveSlot;
    private UISpritesArray SpriteArr;

    public void Init(Transform transform, IUIButtonClickHandler handler, byte SaveSlot)
    {
      this.SaveSlot = SaveSlot;
      this.TechTransform = transform as RectTransform;
      this.TechIconTrans = transform.GetChild(1).GetComponent<RectTransform>();
      this.TechIcon = transform.GetChild(1).GetComponent<Image>();
      this.TechBtn = transform.GetChild(1).GetComponent<UIButton>();
      this.BlackFrame = transform.GetChild(2);
      this.Direction = transform.GetChild(0);
      for (int index = 0; index < this.Lines.Length; ++index)
      {
        this.Lines[index].LintTrans = transform.GetChild(0).GetChild(index).GetComponent<RectTransform>();
        this.Lines[index].LineImage = ((Component) this.Lines[index].LintTrans).GetComponent<Image>();
        this.Lines[index].Pos = this.Lines[index].LintTrans.anchoredPosition;
        this.Lines[index].Size = this.Lines[index].LintTrans.sizeDelta;
      }
      if (GUIManager.Instance.IsArabic)
        ((Component) this.TechBtn).transform.localScale = new Vector3(-1f, 1f, 1f);
      this.TechBtn.m_Handler = handler;
      this.FrameTransform = transform.GetChild(3);
      this.Lock = transform.GetChild(3).GetChild(0);
      this.Degree = transform.GetChild(3).GetChild(1).GetComponent<RectTransform>();
      this.Level = transform.GetChild(6).GetComponent<UIText>();
      this.Name = transform.GetChild(5).GetComponent<UIText>();
      this.FrameTrans = transform.GetChild(3).GetComponent<RectTransform>();
      this.FrameFullTrans = transform.GetChild(4).GetComponent<RectTransform>();
      this.FrameFull = ((Component) this.FrameFullTrans).GetComponent<Image>();
      this.FrameFullSize = this.FrameFullTrans.sizeDelta;
      this.TechNameStr = StringManager.Instance.SpawnString();
      this.TechLvStr = StringManager.Instance.SpawnString();
    }

    public void SetItemStyle(ref UISpritesArray SpriteArray, ushort TechID)
    {
      this.SpriteArr = SpriteArray;
      switch (TechID)
      {
        case 1001:
          this.Direction.gameObject.SetActive(false);
          this.FrameTransform.gameObject.SetActive(false);
          ((Component) this.TechIcon).gameObject.SetActive(false);
          this.Name.text = string.Empty;
          this.Level.text = string.Empty;
          this.FrameFull.sprite = this.SpriteArr.GetSprite(1);
          this.FrameFullTrans.anchoredPosition = new Vector2(84.5f, -238.5f);
          ((Transform) this.FrameFullTrans).localRotation = ((Transform) this.FrameFullTrans).localRotation with
          {
            eulerAngles = new Vector3(0.0f, 0.0f, 90f)
          };
          this.FrameFullTrans.sizeDelta = new Vector2(246f, 31f);
          break;
        case 1002:
          this.Direction.gameObject.SetActive(true);
          this.FrameTransform.gameObject.SetActive(false);
          ((Component) this.TechIcon).gameObject.SetActive(false);
          this.Lines[0].SetActive(true);
          this.Lines[3].SetActive(true);
          this.Lines[2].SetActive(false);
          this.Lines[1].SetActive(false);
          this.FrameFull.sprite = this.SpriteArr.GetSprite(3);
          this.FrameFull.SetNativeSize();
          this.FrameFullTrans.anchoredPosition = new Vector2(84f, 81f);
          this.Lines[0].LintTrans.anchoredPosition = new Vector2(122.7f, -85f);
          this.Lines[0].LintTrans.sizeDelta = new Vector2(112.8f, 30f);
          this.Lines[3].ResetPos();
          this.Lines[3].LintTrans.sizeDelta = new Vector2(124f, 30f);
          this.Level.text = string.Empty;
          this.Name.text = string.Empty;
          break;
        case 1003:
          this.Direction.gameObject.SetActive(true);
          this.FrameTransform.gameObject.SetActive(false);
          ((Component) this.TechIcon).gameObject.SetActive(false);
          this.Lines[0].SetActive(false);
          this.Lines[3].SetActive(true);
          this.Lines[2].SetActive(false);
          this.Lines[1].SetActive(true);
          this.FrameFull.sprite = this.SpriteArr.GetSprite(5);
          this.FrameFull.SetNativeSize();
          this.FrameFullTrans.anchoredPosition = new Vector2(75f, 81f);
          this.Lines[1].ResetPos();
          this.Lines[1].LintTrans.sizeDelta = new Vector2(112.5f, 30f);
          this.Lines[3].ResetPos();
          this.Lines[3].LintTrans.sizeDelta = new Vector2(124f, 30f);
          this.Level.text = string.Empty;
          this.Name.text = string.Empty;
          break;
        default:
          this.FrameTransform.gameObject.SetActive(true);
          ((Component) this.TechIcon).gameObject.SetActive(true);
          this.Direction.gameObject.SetActive(true);
          this.FrameFull.sprite = this.SpriteArr.GetSprite(0);
          this.FrameFullTrans.anchoredPosition = Vector2.zero;
          this.FrameFullTrans.sizeDelta = this.FrameFullSize;
          for (int index = 0; index < this.Lines.Length; ++index)
          {
            this.Lines[index].ResetPos();
            if (index != 2)
              this.Lines[index].LineImage.sprite = this.SpriteArr.GetSprite(1);
          }
          break;
      }
      if (this.TechBtn.m_BtnID2 != 1001)
        return;
      ((Transform) this.FrameFullTrans).localRotation = ((Transform) this.FrameFullTrans).localRotation with
      {
        eulerAngles = Vector3.zero
      };
    }

    public void SetTechID(ushort TechID)
    {
      this.TechBtn.m_BtnID2 = (int) TechID;
      this.State = this.CheckTechState();
      this.UpdateState((byte) 7);
    }

    public void SetTechInfo(ushort TalentID)
    {
      DataManager instance = DataManager.Instance;
      TalentTbl recordByKey = instance.TalentData.GetRecordByKey(TalentID);
      this.TechNameStr.ClearString();
      this.TechLvStr.ClearString();
      this.TechNameStr.Insert(0, instance.mStringTable.GetStringByID((uint) recordByKey.NameID));
      this.Name.text = this.TechNameStr.ToString();
      this.Name.SetAllDirty();
      this.Name.cachedTextGenerator.Invalidate();
      byte talentLevel = instance.GetTalentLevel(TalentID, this.SaveSlot);
      float num = 163f / (float) recordByKey.LevelMax;
      this.TechLvStr.IntToFormat((long) talentLevel);
      this.TechLvStr.IntToFormat((long) recordByKey.LevelMax);
      if (GUIManager.Instance.IsArabic)
        this.TechLvStr.AppendFormat("{1}/{0}");
      else
        this.TechLvStr.AppendFormat("{0}/{1}");
      this.Level.text = this.TechLvStr.ToString();
      this.Level.SetAllDirty();
      this.Level.cachedTextGenerator.Invalidate();
      this.Degree.sizeDelta = this.Degree.sizeDelta with
      {
        x = num * (float) talentLevel
      };
      this.GraphicID = recordByKey.Graphic;
      if ((UnityEngine.Object) GUIManager.Instance.TechMaterial == (UnityEngine.Object) null)
      {
        ((Behaviour) this.TechIcon).enabled = false;
      }
      else
      {
        this.TechIcon.sprite = GUIManager.Instance.GetTechSprite(this.GraphicID);
        ((MaskableGraphic) this.TechIcon).material = GUIManager.Instance.TechMaterial;
        ((Behaviour) this.TechIcon).enabled = true;
      }
    }

    public byte CheckTechState()
    {
      ushort TalentID = (ushort) this.TechBtn.m_BtnID2;
      if (TalentID >= (ushort) 1001)
        TalentID = (ushort) this.TechBtn.m_BtnID3;
      return DataManager.Instance.CheckTalentState(TalentID, this.SaveSlot, (byte) 1);
    }

    public void UpdateState(byte Kind)
    {
      bool flag = false;
      this.State = this.CheckTechState();
      this.SetTechInfo((ushort) this.TechBtn.m_BtnID2);
      if (((int) this.State & 4) > 0)
      {
        this.BlackFrame.gameObject.SetActive(true);
        this.Lock.gameObject.SetActive(true);
      }
      else if (((int) this.State & 16) > 0)
      {
        flag = true;
      }
      else
      {
        this.BlackFrame.gameObject.SetActive(false);
        this.Lock.gameObject.SetActive(false);
      }
      ((Component) this.FrameFullTrans).gameObject.SetActive(flag);
      ((Component) this.FrameTrans).gameObject.SetActive(!flag);
      if (((int) this.State & 1) > 0)
        this.BlackFrame.gameObject.SetActive(true);
      else
        this.BlackFrame.gameObject.SetActive(false);
    }

    public void OnClose()
    {
      StringManager.Instance.DeSpawnString(this.TechNameStr);
      StringManager.Instance.DeSpawnString(this.TechLvStr);
    }

    public void TextRefresh()
    {
      ((Behaviour) this.Level).enabled = false;
      ((Behaviour) this.Name).enabled = false;
      ((Behaviour) this.Level).enabled = true;
      ((Behaviour) this.Name).enabled = true;
    }

    public struct _LineInfo
    {
      public Image LineImage;
      public RectTransform LintTrans;
      public Vector2 Pos;
      public Vector2 Size;

      public void SetActive(bool bActive)
      {
        ((Component) this.LintTrans).gameObject.SetActive(bActive);
      }

      public void ResetPos()
      {
        this.LintTrans.anchoredPosition = this.Pos;
        this.LintTrans.sizeDelta = this.Size;
      }
    }
  }

  private struct LineItem
  {
    public RectTransform LineTrans;
    public Image LineImg;

    public void Init(Transform transform)
    {
      this.LineTrans = transform.GetComponent<RectTransform>();
      this.LineImg = transform.GetComponent<Image>();
    }
  }

  private struct ItemEdit
  {
    public int DataIndex;
    public int PanelIndex;
    public RectTransform ItemTransform;
    public UITalent.TechItem[] Tech;
    public UITalent.LineItem[] Line;
    public Image[] Node;

    public void Init(Transform transform, IUIButtonClickHandler handler, byte SaveSlot)
    {
      this.ItemTransform = transform as RectTransform;
      this.Tech = new UITalent.TechItem[4];
      this.Line = new UITalent.LineItem[2];
      this.Node = new Image[14];
      for (int index = 0; index < this.Tech.Length; ++index)
      {
        this.Tech[index] = new UITalent.TechItem();
        this.Tech[index].Init(transform.GetChild(2 + index), handler, SaveSlot);
      }
      for (int index = 0; index < this.Line.Length; ++index)
        this.Line[index].Init(transform.GetChild(index));
      for (int index = 0; index < this.Node.Length; ++index)
        this.Node[index] = transform.GetChild(6).GetChild(index).GetComponent<Image>();
    }

    public void OnClose()
    {
      if (this.Tech == null)
        return;
      for (int index = 0; index < this.Tech.Length; ++index)
        this.Tech[index].OnClose();
    }
  }

  private enum SpriteArrayIdx
  {
    BoxOn,
    Line,
    LineOn,
    Linel,
    LinelOn,
    Liner,
    LinerOn,
    Linepoint,
    LinepointOn,
  }
}
