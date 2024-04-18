// Decompiled with JetBrains decompiler
// Type: UITechTree
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UITechTree : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private UISpritesArray SpriteArray;
  private ushort DataStart;
  private ushort DataCount;
  private int MaxItemCount = 5;
  private int BeginIndex = -1;
  private readonly float[] Skillpos = new float[7]
  {
    -191.5f,
    0.5f,
    192.5f,
    -287.5f,
    -95.5f,
    96.5f,
    288.5f
  };
  private readonly float[][] HorizontalPW = new float[11][]
  {
    new float[2]{ 295f, 201f },
    new float[2]{ 201f, 389f },
    new float[2]{ 201f, 197f },
    new float[2]{ 393f, 197f },
    new float[2]{ 103f, 584f },
    new float[2]{ 103f, 391f },
    new float[2]{ 296f, 391f },
    new float[2]{ 103f, 198f },
    new float[2]{ 296f, 198f },
    new float[2]{ 488f, 198f },
    new float[2]{ 103f, 198f }
  };
  private ScrollPanel TechTreePanel;
  protected List<float> ItemsHeight = new List<float>();
  protected List<ushort> ItemIndex = new List<ushort>();
  private ushort[] HorzontalShowFlag;
  private ushort[] HorzontalShowFlag2;
  public UITechInfo InfoWindow;
  private byte TreeKind;
  private byte InitScroll;
  private byte DelayLoadScroll;
  private RectTransform RectCont;
  private Transform BlackFrameTrans;
  private UIText NeedLvText;
  private UIText TitleText;
  private CString NeedLvStr;
  public UITechTree.ItemEdit[] TreeLayer;
  private byte PassFrame = 1;
  private byte GraphicLoaded;
  private int[] UpdateQueue = new int[3];

  public override void OnOpen(int arg1, int arg2)
  {
    if (DataManager.StageDataController.StageRecord[2] < (ushort) 8)
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
    else
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
    GUIManager.Instance.SetTalentIconSprite("UITechIcon", this.m_eWindow);
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    DataManager instance = DataManager.Instance;
    this.TreeKind = (byte) (arg1 & (int) byte.MaxValue);
    if ((arg1 & 32768) > 0)
      this.DelayLoadScroll = (byte) 2;
    instance.GetTechTreeDataRange(this.TreeKind, out this.DataStart, out this.DataCount);
    this.TitleText = this.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.TitleText.font = ttfFont;
    this.TitleText.text = instance.mStringTable.GetStringByID((uint) arg2);
    if (GUIManager.Instance.bOpenOnIPhoneX)
      ((Behaviour) this.transform.GetChild(2).GetComponent<CustomImage>()).enabled = false;
    else
      this.transform.GetChild(2).GetComponent<CustomImage>().hander = (UILoadImageHander) GUIManager.Instance.m_ItemInfo;
    this.transform.GetChild(2).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) GUIManager.Instance.m_ItemInfo;
    this.SpriteArray = this.transform.GetChild(1).GetComponent<UISpritesArray>();
    Transform child = this.transform.GetChild(3);
    this.TechTreePanel = this.transform.GetChild(1).GetComponent<ScrollPanel>();
    UIButton component = this.transform.GetChild(2).GetChild(0).GetComponent<UIButton>();
    component.m_Handler = (IUIButtonClickHandler) this;
    component.m_BtnID1 = 0;
    child.GetChild(0).GetChild(0).GetComponent<UIButton>().m_BtnID1 = 1;
    child.GetChild(1).GetChild(0).GetComponent<UIButton>().m_BtnID1 = 1;
    child.GetChild(2).GetChild(0).GetComponent<UIButton>().m_BtnID1 = 1;
    child.GetChild(3).GetChild(0).GetComponent<UIButton>().m_BtnID1 = 1;
    child.GetChild(0).GetChild(7).GetComponent<UIText>().font = ttfFont;
    child.GetChild(0).GetChild(8).GetComponent<UIText>().font = ttfFont;
    child.GetChild(1).GetChild(7).GetComponent<UIText>().font = ttfFont;
    child.GetChild(1).GetChild(8).GetComponent<UIText>().font = ttfFont;
    child.GetChild(2).GetChild(7).GetComponent<UIText>().font = ttfFont;
    child.GetChild(2).GetChild(8).GetComponent<UIText>().font = ttfFont;
    child.GetChild(3).GetChild(7).GetComponent<UIText>().font = ttfFont;
    child.GetChild(3).GetChild(8).GetComponent<UIText>().font = ttfFont;
    this.BlackFrameTrans = this.transform.GetChild(0).GetChild(0);
    this.NeedLvStr = StringManager.Instance.SpawnString();
    this.NeedLvText = this.BlackFrameTrans.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.NeedLvText.font = ttfFont;
    GameConstants.ArrayFill<ushort>(this.HorzontalShowFlag, (ushort) 0);
    GameConstants.ArrayFill<ushort>(this.HorzontalShowFlag2, (ushort) 0);
  }

  public void SetItemLayout(int dataIndex, int panelIndex)
  {
    TechTreeLayoutTbl recordByIndex = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex);
    this.TreeLayer[panelIndex].DataIndex = dataIndex;
    this.TreeLayer[panelIndex].PanelIndex = panelIndex;
    switch (recordByIndex.TechCount)
    {
      case 1:
        this.SetTechItemLayout(dataIndex, panelIndex, (byte) 0, recordByIndex.TechID1, recordByIndex.VerticalExtend1, recordByIndex.HorizontalExtend1);
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
        this.SetTechItemLayout(dataIndex, panelIndex, (byte) 0, recordByIndex.TechID1, recordByIndex.VerticalExtend1, recordByIndex.HorizontalExtend1);
        Vector2 anchoredPosition2 = this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[4]
        };
        this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition = anchoredPosition2;
        this.SetTechItemLayout(dataIndex, panelIndex, (byte) 1, recordByIndex.TechID2, recordByIndex.VerticalExtend2, recordByIndex.HorizontalExtend2);
        Vector2 anchoredPosition3 = this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[5]
        };
        this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition = anchoredPosition3;
        ((Component) this.TreeLayer[panelIndex].Tech[2].TechTransform).gameObject.SetActive(false);
        ((Component) this.TreeLayer[panelIndex].Tech[3].TechTransform).gameObject.SetActive(false);
        break;
      case 3:
        this.SetTechItemLayout(dataIndex, panelIndex, (byte) 0, recordByIndex.TechID1, recordByIndex.VerticalExtend1, recordByIndex.HorizontalExtend1);
        Vector2 anchoredPosition4 = this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[0]
        };
        this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition = anchoredPosition4;
        this.SetTechItemLayout(dataIndex, panelIndex, (byte) 1, recordByIndex.TechID2, recordByIndex.VerticalExtend2, recordByIndex.HorizontalExtend2);
        Vector2 anchoredPosition5 = this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[1]
        };
        this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition = anchoredPosition5;
        this.SetTechItemLayout(dataIndex, panelIndex, (byte) 2, recordByIndex.TechID3, recordByIndex.VerticalExtend3, recordByIndex.HorizontalExtend3);
        Vector2 anchoredPosition6 = this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[2]
        };
        this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition = anchoredPosition6;
        ((Component) this.TreeLayer[panelIndex].Tech[3].TechTransform).gameObject.SetActive(false);
        break;
      case 4:
        this.SetTechItemLayout(dataIndex, panelIndex, (byte) 0, recordByIndex.TechID1, recordByIndex.VerticalExtend1, recordByIndex.HorizontalExtend1);
        Vector2 anchoredPosition7 = this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[3]
        };
        this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition = anchoredPosition7;
        this.SetTechItemLayout(dataIndex, panelIndex, (byte) 1, recordByIndex.TechID2, recordByIndex.VerticalExtend2, recordByIndex.HorizontalExtend2);
        Vector2 anchoredPosition8 = this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[4]
        };
        this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition = anchoredPosition8;
        this.SetTechItemLayout(dataIndex, panelIndex, (byte) 2, recordByIndex.TechID3, recordByIndex.VerticalExtend3, recordByIndex.HorizontalExtend3);
        Vector2 anchoredPosition9 = this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[5]
        };
        this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition = anchoredPosition9;
        this.SetTechItemLayout(dataIndex, panelIndex, (byte) 3, recordByIndex.TechID4, recordByIndex.VerticalExtend4, recordByIndex.HorizontalExtend4);
        anchoredPosition9 = this.TreeLayer[panelIndex].Tech[3].TechTransform.anchoredPosition with
        {
          x = this.Skillpos[6]
        };
        this.TreeLayer[panelIndex].Tech[3].TechTransform.anchoredPosition = anchoredPosition9;
        break;
    }
    this.SetHorizontalLayout(dataIndex, panelIndex);
  }

  public unsafe void SetTechItemLayout(
    int dataIndex,
    int panelIndex,
    byte techIndex,
    ushort TechID,
    byte UpDown,
    byte LeftRight)
  {
    DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex);
    if (TechID == (ushort) 0)
    {
      ((Component) this.TreeLayer[panelIndex].Tech[(int) techIndex].TechTransform).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.TreeLayer[panelIndex].Tech[(int) techIndex].TechTransform).gameObject.SetActive(true);
      this.TreeLayer[panelIndex].Tech[(int) techIndex].SetItemStyle(TechID);
      if (TechID < (ushort) 1000)
      {
        int FrameIndex = 0;
        this.TreeLayer[panelIndex].Tech[(int) techIndex].SetTechID(ref this.SpriteArray, TechID, FrameIndex);
        this.TreeLayer[panelIndex].Tech[(int) techIndex].SetTechInfo(TechID);
        Vector2 sizeDelta = this.TreeLayer[panelIndex].Tech[(int) techIndex].TechIconTrans.sizeDelta;
        sizeDelta.Set(110f, 110f);
        this.TreeLayer[panelIndex].Tech[(int) techIndex].TechIconTrans.sizeDelta = sizeDelta;
        Quaternion localRotation = ((Transform) this.TreeLayer[panelIndex].Tech[(int) techIndex].TechIconTrans).localRotation with
        {
          eulerAngles = Vector3.zero
        };
        ((Transform) this.TreeLayer[panelIndex].Tech[(int) techIndex].TechIconTrans).localRotation = localRotation;
        ((Component) this.TreeLayer[panelIndex].Tech[(int) techIndex].LineUp).gameObject.SetActive(((int) UpDown & 1) > 0);
        ((Component) this.TreeLayer[panelIndex].Tech[(int) techIndex].LineDown).gameObject.SetActive(((int) UpDown & 2) > 0);
        ((Component) this.TreeLayer[panelIndex].Tech[(int) techIndex].LineLeft).gameObject.SetActive(((int) LeftRight & 1) > 0);
        ((Component) this.TreeLayer[panelIndex].Tech[(int) techIndex].LineRight).gameObject.SetActive(((int) LeftRight & 2) > 0);
      }
      else
      {
        // ISSUE: untyped stack allocation
        ushort* numPtr = (ushort*) __untypedstackalloc((int) checked (4U * 2U));
        TechTreeLayoutTbl recordByIndex = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex + 1);
        *numPtr = recordByIndex.TechID1;
        numPtr[1] = recordByIndex.TechID2;
        numPtr[2] = recordByIndex.TechID3;
        numPtr[3] = recordByIndex.TechID4;
        switch (TechID)
        {
          case 1001:
            int FrameIndex1 = 2;
            this.TreeLayer[panelIndex].Tech[(int) techIndex].SetTechID(ref this.SpriteArray, numPtr[techIndex], FrameIndex1);
            this.TreeLayer[panelIndex].Tech[(int) techIndex].TechBtn.m_BtnID2 = (int) TechID;
            this.TreeLayer[panelIndex].Tech[(int) techIndex].TechBtn.m_BtnID3 = (int) this.GetParentTechID(ref recordByIndex, this.TreeLayer[panelIndex].DataIndex, (int) techIndex, UITechTree.NeighborWay.Up);
            break;
          case 1002:
            int FrameIndex2 = 4;
            this.TreeLayer[panelIndex].Tech[(int) techIndex].SetTechID(ref this.SpriteArray, numPtr[techIndex], FrameIndex2);
            break;
          case 1003:
            int FrameIndex3 = 6;
            this.TreeLayer[panelIndex].Tech[(int) techIndex].SetTechID(ref this.SpriteArray, numPtr[techIndex], FrameIndex3);
            this.TreeLayer[panelIndex].Tech[(int) techIndex].TechBtn.m_BtnID2 = (int) TechID;
            this.TreeLayer[panelIndex].Tech[(int) techIndex].TechBtn.m_BtnID3 = (int) this.GetParentTechID(ref recordByIndex, this.TreeLayer[panelIndex].DataIndex, (int) techIndex, UITechTree.NeighborWay.Left);
            break;
        }
        this.TreeLayer[panelIndex].Tech[(int) techIndex].Name.text = string.Empty;
        this.TreeLayer[panelIndex].Tech[(int) techIndex].Level.text = string.Empty;
      }
    }
  }

  public int GetHorizontalState(ref TechTreeLayoutTbl Data, int techIndex)
  {
    if (Data.HorizontalType == (byte) 1)
      ;
    return -1;
  }

  public void SetHorizontalLayout(int dataIndex, int panelIndex)
  {
    TechTreeLayoutTbl recordByIndex = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex);
    this.TreeLayer[panelIndex].Line[0].LineImg.sprite = this.SpriteArray.GetSprite(2);
    this.TreeLayer[panelIndex].Line[0].LineImg.sprite = this.SpriteArray.GetSprite(2);
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
    if (dataIndex + 1 - (int) this.DataStart >= this.HorzontalShowFlag.Length)
      return;
    recordByIndex = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex + 1);
    this.SetNodeLayout(panelIndex, horizontalType, ref recordByIndex, false);
  }

  public void SetNodeLayout(
    int panelIndex,
    byte HorizontalType,
    ref TechTreeLayoutTbl Data,
    bool bDown)
  {
    byte num1 = 2;
    if (!bDown)
      num1 = (byte) 1;
    ushort num2 = 0;
    ushort num3 = 0;
    switch (HorizontalType)
    {
      case 1:
        if (Data.TechID1 > (ushort) 0 && ((int) Data.VerticalExtend1 & (int) num1) > 0)
          num2 |= (ushort) 1;
        if (Data.TechID2 > (ushort) 0 && ((int) Data.VerticalExtend2 & (int) num1) > 0)
        {
          num2 |= (ushort) 2;
          break;
        }
        break;
      case 2:
        if (Data.TechID1 > (ushort) 0 && ((int) Data.VerticalExtend1 & (int) num1) > 0)
          num2 |= (ushort) 1;
        if (Data.TechID2 > (ushort) 0 && ((int) Data.VerticalExtend2 & (int) num1) > 0)
          num2 |= (ushort) 2;
        if (Data.TechID3 > (ushort) 0 && ((int) Data.VerticalExtend3 & (int) num1) > 0)
        {
          num2 |= (ushort) 4;
          break;
        }
        break;
      case 3:
        if (Data.TechID1 > (ushort) 0 && ((int) Data.VerticalExtend1 & (int) num1) > 0)
          num2 |= (ushort) 1;
        if (Data.TechID2 > (ushort) 0 && ((int) Data.VerticalExtend2 & (int) num1) > 0)
        {
          num2 |= (ushort) 2;
          break;
        }
        break;
      case 4:
        if (Data.TechID2 > (ushort) 0 && ((int) Data.VerticalExtend2 & (int) num1) > 0)
          num2 |= (ushort) 2;
        if (Data.TechID3 > (ushort) 0 && ((int) Data.VerticalExtend3 & (int) num1) > 0)
        {
          num2 |= (ushort) 4;
          break;
        }
        break;
      case 5:
        if (Data.TechID1 > (ushort) 0 && ((int) Data.VerticalExtend1 & (int) num1) > 0)
          num2 |= (ushort) 1;
        if (Data.TechID2 > (ushort) 0 && ((int) Data.VerticalExtend2 & (int) num1) > 0)
          num2 |= (ushort) 2;
        if (Data.TechID3 > (ushort) 0 && ((int) Data.VerticalExtend3 & (int) num1) > 0)
          num2 |= (ushort) 4;
        if (Data.TechID4 > (ushort) 0 && ((int) Data.VerticalExtend4 & (int) num1) > 0)
        {
          num2 |= (ushort) 8;
          break;
        }
        break;
      case 6:
        if (Data.TechID1 > (ushort) 0 && ((int) Data.VerticalExtend1 & (int) num1) > 0)
          num2 |= (ushort) 1;
        if (Data.TechID2 > (ushort) 0 && ((int) Data.VerticalExtend2 & (int) num1) > 0)
          num2 |= (ushort) 2;
        if (Data.TechID3 > (ushort) 0 && ((int) Data.VerticalExtend3 & (int) num1) > 0)
        {
          num2 |= (ushort) 4;
          break;
        }
        break;
      case 7:
        if (Data.TechID2 > (ushort) 0 && ((int) Data.VerticalExtend2 & (int) num1) > 0)
          num2 |= (ushort) 2;
        if (Data.TechID3 > (ushort) 0 && ((int) Data.VerticalExtend3 & (int) num1) > 0)
          num2 |= (ushort) 4;
        if (Data.TechID4 > (ushort) 0 && ((int) Data.VerticalExtend4 & (int) num1) > 0)
        {
          num2 |= (ushort) 8;
          break;
        }
        break;
      case 8:
        if (Data.TechID1 > (ushort) 0 && ((int) Data.VerticalExtend1 & (int) num1) > 0)
          num2 |= (ushort) 1;
        if (Data.TechID2 > (ushort) 0 && ((int) Data.VerticalExtend2 & (int) num1) > 0)
        {
          num2 |= (ushort) 2;
          break;
        }
        break;
      case 9:
        if (Data.TechID2 > (ushort) 0 && ((int) Data.VerticalExtend2 & (int) num1) > 0)
          num2 |= (ushort) 2;
        if (Data.TechID3 > (ushort) 0 && ((int) Data.VerticalExtend3 & (int) num1) > 0)
        {
          num2 |= (ushort) 4;
          break;
        }
        break;
      case 10:
        if (Data.TechID3 > (ushort) 0 && ((int) Data.VerticalExtend3 & (int) num1) > 0)
          num2 |= (ushort) 4;
        if (Data.TechID4 > (ushort) 0 && ((int) Data.VerticalExtend4 & (int) num1) > 0)
        {
          num2 |= (ushort) 8;
          break;
        }
        break;
      case 11:
        if (Data.TechID1 > (ushort) 0 && ((int) Data.VerticalExtend1 & (int) num1) > 0)
          num2 |= (ushort) 1;
        if (Data.TechID2 > (ushort) 0 && ((int) Data.VerticalExtend2 & (int) num1) > 0)
          num2 |= (ushort) 2;
        if (Data.TechID3 > (ushort) 0 & ((int) Data.VerticalExtend3 & (int) num1) > 0)
          num3 |= (ushort) 4;
        if (Data.TechID4 > (ushort) 0 && ((int) Data.VerticalExtend4 & (int) num1) > 0)
        {
          num3 |= (ushort) 8;
          break;
        }
        break;
    }
    if (Data.HorizontalType == (byte) 0)
    {
      num2 |= (ushort) 512;
      num3 |= (ushort) 512;
    }
    if (bDown)
    {
      this.HorzontalShowFlag[(int) Data.ID - 1 - (int) this.DataStart] = num2;
      this.HorzontalShowFlag2[(int) Data.ID - 1 - (int) this.DataStart] = num3;
    }
    else
    {
      ushort num4 = (ushort) ((uint) num2 << 5);
      ushort num5 = (ushort) ((uint) num3 << 5);
      this.HorzontalShowFlag[(int) Data.ID - 2 - (int) this.DataStart] |= num4;
      this.HorzontalShowFlag2[(int) Data.ID - 2 - (int) this.DataStart] |= num5;
    }
  }

  private byte CheckTechState(ushort TechID) => DataManager.Instance.CheckTechState(TechID);

  private unsafe void UpdateHorizontal(int dataIndex, int panelIndex)
  {
    TechTreeLayoutTbl recordByIndex = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex);
    int index1 = dataIndex - (int) this.DataStart;
    int index2 = panelIndex;
    bool flag1 = true;
    bool flag2 = true;
    // ISSUE: untyped stack allocation
    ushort* numPtr = (ushort*) __untypedstackalloc((int) checked (8U * 2U));
    byte num1 = 0;
    int num2 = 0;
    *numPtr = recordByIndex.TechID1;
    numPtr[1] = recordByIndex.TechID2;
    numPtr[2] = recordByIndex.TechID3;
    numPtr[3] = recordByIndex.TechID4;
    numPtr[4] = (ushort) (short) recordByIndex.HorizontalExtend1;
    numPtr[5] = (ushort) (short) recordByIndex.HorizontalExtend2;
    numPtr[6] = (ushort) (short) recordByIndex.HorizontalExtend3;
    numPtr[7] = (ushort) (short) recordByIndex.HorizontalExtend4;
    this.TreeLayer[index2].UpdateLineLRState();
    for (int index3 = 0; index3 < (int) recordByIndex.TechCount; ++index3)
    {
      if (numPtr[index3] != (ushort) 0)
      {
        int num3 = 1 << index3;
        if (((int) this.HorzontalShowFlag[index1] & num3) > 0 || ((int) this.HorzontalShowFlag2[index1] & num3) > 0)
        {
          num1 |= this.GetNodePos(recordByIndex.TechCount, index3);
          if (numPtr[index3] > (ushort) 0)
          {
            if (numPtr[index3] == (ushort) 1001)
              numPtr[index3] = this.GetParentTechID(ref recordByIndex, dataIndex, index3, UITechTree.NeighborWay.Up);
            if (((int) this.CheckTechState(numPtr[index3]) & 2) > 0)
            {
              num2 |= (int) this.GetNodePos(recordByIndex.TechCount, index3);
              this.TreeLayer[index2].Tech[index3].LineDown.sprite = this.SpriteArray.GetSprite(3);
            }
            else
            {
              this.TreeLayer[index2].Tech[index3].LineDown.sprite = this.SpriteArray.GetSprite(2);
              if (((int) this.HorzontalShowFlag[index1] & num3) > 0)
                flag1 = false;
              else
                flag2 = false;
            }
          }
        }
        else if (numPtr[index3] > (ushort) 0 && ((int) this.CheckTechState(numPtr[index3]) & 2) > 0)
        {
          byte num4 = this.CheckTechState(this.GetParentTechID(ref recordByIndex, dataIndex, index3, UITechTree.NeighborWay.Down));
          recordByIndex = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex);
          this.TreeLayer[index2].Tech[index3].LineDown.sprite = ((int) num4 & 2) > 0 || ((int) num4 & 1) == 0 ? this.SpriteArray.GetSprite(3) : this.SpriteArray.GetSprite(2);
        }
        if (numPtr[4 + index3] == (ushort) 1 || numPtr[4 + index3] == (ushort) 3)
          ((Component) this.TreeLayer[index2].Tech[index3].LineLeft).gameObject.SetActive(true);
        else
          ((Component) this.TreeLayer[index2].Tech[index3].LineLeft).gameObject.SetActive(false);
        if (numPtr[4 + index3] == (ushort) 2 || numPtr[4 + index3] == (ushort) 3)
          ((Component) this.TreeLayer[index2].Tech[index3].LineRight).gameObject.SetActive(true);
        else
          ((Component) this.TreeLayer[index2].Tech[index3].LineRight).gameObject.SetActive(false);
        if (index3 > 0 && ((Component) this.TreeLayer[index2].Tech[index3].LineLeft).gameObject.activeSelf)
        {
          this.TreeLayer[index2].Tech[index3 - 1].LineRight.sprite = this.TreeLayer[index2].Tech[index3].LineLeft.sprite;
          ((Component) this.TreeLayer[index2].Tech[index3 - 1].LineRight).gameObject.SetActive(true);
          ((Component) this.TreeLayer[index2].Tech[index3].LineLeft).gameObject.SetActive(false);
        }
      }
    }
    if (flag1)
    {
      this.HorzontalShowFlag[index1] |= (ushort) 16;
      this.TreeLayer[index2].Line[0].LineImg.sprite = this.SpriteArray.GetSprite(3);
    }
    if (flag2)
    {
      if (recordByIndex.HorizontalType == (byte) 11)
      {
        this.HorzontalShowFlag2[index1] |= (ushort) 16;
        this.TreeLayer[index2].Line[1].LineImg.sprite = this.SpriteArray.GetSprite(3);
      }
      else
        flag2 = false;
    }
    byte num5 = 0;
    int num6 = 0;
    int index4 = (index2 + 1) % this.MaxItemCount;
    int index5 = index4 != 0 ? index4 : this.MaxItemCount - 1;
    if ((int) this.DataStart + this.TechTreePanel.GetBeginIdx() + 4 != dataIndex && (int) this.DataStart + (int) this.DataCount > dataIndex + 1)
    {
      recordByIndex = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex + 1);
      *numPtr = recordByIndex.TechID1;
      numPtr[1] = recordByIndex.TechID2;
      numPtr[2] = recordByIndex.TechID3;
      numPtr[3] = recordByIndex.TechID4;
      int num7 = (int) this.HorzontalShowFlag[index1] >> 5;
      int num8 = (int) this.HorzontalShowFlag2[index1] >> 5;
      for (int index6 = 0; index6 < (int) recordByIndex.TechCount; ++index6)
      {
        if (numPtr[index6] != (ushort) 0)
        {
          int num9 = 1 << index6;
          if ((num7 & num9) > 0 || (num8 & num9) > 0)
          {
            if (numPtr[index6] == (ushort) 1001)
              numPtr[index6] = this.GetParentTechID(ref recordByIndex, dataIndex + 1, index6, UITechTree.NeighborWay.Down);
            num5 |= this.GetNodePos(recordByIndex.TechCount, index6);
            if (((int) this.CheckTechState(numPtr[index6]) & 1) == 0 || ((int) this.CheckTechState(numPtr[index6]) & 2) > 0 && (flag1 || flag2))
            {
              num6 |= (int) this.GetNodePos(recordByIndex.TechCount, index6);
              this.TreeLayer[index4].Tech[index6].LineUp.sprite = this.SpriteArray.GetSprite(3);
            }
            else
              this.TreeLayer[index4].Tech[index6].LineUp.sprite = this.SpriteArray.GetSprite(2);
          }
          else if (((int) this.CheckTechState(numPtr[index6]) & 1) == 0 || ((int) this.CheckTechState(numPtr[index6]) & 2) > 0)
          {
            TechTreeLayoutTbl Data = recordByIndex;
            this.TreeLayer[index4].Tech[index6].LineUp.sprite = ((int) this.CheckTechState(this.GetParentTechID(ref Data, dataIndex + 1, index6, UITechTree.NeighborWay.Up)) & 2) <= 0 ? this.SpriteArray.GetSprite(2) : this.SpriteArray.GetSprite(3);
          }
          else
            this.TreeLayer[index4].Tech[index6].LineUp.sprite = this.SpriteArray.GetSprite(2);
        }
      }
    }
    int index7 = 0;
    int num10 = 0;
    if (index5 == index4)
    {
      index7 = 7;
      num10 = 7;
    }
    for (int index8 = 0; index8 < 7; ++index8)
    {
      int num11 = 1 << index8;
      if (((int) num1 & num11) > 0 && ((int) num5 & num11) == 0)
      {
        Vector2 anchoredPosition = ((Graphic) this.TreeLayer[index5].Node[index7]).rectTransform.anchoredPosition with
        {
          x = this.Skillpos[index8] + 386f
        };
        ((Graphic) this.TreeLayer[index5].Node[index7]).rectTransform.anchoredPosition = anchoredPosition;
        this.TreeLayer[index5].Node[index7].sprite = (num2 & num11) <= 0 ? this.SpriteArray.GetSprite(8) : this.SpriteArray.GetSprite(9);
        ++index7;
      }
      else if (((int) num5 & num11) > 0)
      {
        Vector2 anchoredPosition = ((Graphic) this.TreeLayer[index5].Node[index7]).rectTransform.anchoredPosition with
        {
          x = this.Skillpos[index8] + 386f
        };
        ((Graphic) this.TreeLayer[index5].Node[index7]).rectTransform.anchoredPosition = anchoredPosition;
        this.TreeLayer[index5].Node[index7].sprite = (num6 & num11) <= 0 ? this.SpriteArray.GetSprite(8) : this.SpriteArray.GetSprite(9);
        ++index7;
      }
    }
    if ((int) this.DataStart == dataIndex)
    {
      for (int index9 = 7; index9 < this.TreeLayer[panelIndex].Node.Length; ++index9)
        ((Component) this.TreeLayer[panelIndex].Node[index9]).gameObject.SetActive(false);
    }
    for (int index10 = num10; index10 < num10 + 7; ++index10)
    {
      if (index7 > index10)
        ((Component) this.TreeLayer[index5].Node[index10]).gameObject.SetActive(true);
      else
        ((Component) this.TreeLayer[index5].Node[index10]).gameObject.SetActive(false);
    }
  }

  public unsafe ushort GetParentTechID(
    ref TechTreeLayoutTbl Data,
    int dataIndex,
    int techIndex,
    UITechTree.NeighborWay way)
  {
    Data = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex);
    // ISSUE: untyped stack allocation
    ushort* numPtr = (ushort*) __untypedstackalloc((int) checked (4U * 2U));
    *numPtr = Data.TechID1;
    numPtr[1] = Data.TechID2;
    numPtr[2] = Data.TechID3;
    numPtr[3] = Data.TechID4;
    ushort num = numPtr[techIndex];
    switch (way)
    {
      case UITechTree.NeighborWay.Up:
        if (dataIndex > 0)
        {
          Data = DataManager.Instance.TechTreeLayout.GetRecordByIndex(--dataIndex);
          if ((int) Data.Kind != (int) this.TreeKind)
            return 0;
          *numPtr = Data.TechID1;
          numPtr[1] = Data.TechID2;
          numPtr[2] = Data.TechID3;
          numPtr[3] = Data.TechID4;
          if (numPtr[techIndex] == (ushort) 1001)
            return this.GetParentTechID(ref Data, dataIndex, techIndex, UITechTree.NeighborWay.Up);
          if (numPtr[techIndex] == (ushort) 1002)
            return techIndex == 3 ? (ushort) 0 : numPtr[techIndex + 1];
          if (numPtr[techIndex] != (ushort) 1003)
            return numPtr[techIndex];
          return techIndex == 0 ? (ushort) 0 : numPtr[techIndex - 1];
        }
        break;
      case UITechTree.NeighborWay.Down:
        if (dataIndex + 1 - (int) this.DataStart < this.HorzontalShowFlag.Length)
        {
          Data = DataManager.Instance.TechTreeLayout.GetRecordByIndex(++dataIndex);
          if ((int) Data.Kind != (int) this.TreeKind)
            return 0;
          *numPtr = Data.TechID1;
          numPtr[1] = Data.TechID2;
          numPtr[2] = Data.TechID3;
          numPtr[3] = Data.TechID4;
          return numPtr[techIndex] == (ushort) 1001 ? num : numPtr[techIndex];
        }
        break;
      case UITechTree.NeighborWay.Left:
        if (techIndex == 0)
          return 0;
        return numPtr[techIndex - 1] == (ushort) 1002 ? this.GetParentTechID(ref Data, dataIndex, techIndex, UITechTree.NeighborWay.Down) : numPtr[techIndex - 1];
      case UITechTree.NeighborWay.Right:
        if (techIndex == 3)
          return 0;
        return numPtr[techIndex + 1] == (ushort) 1002 ? this.GetParentTechID(ref Data, dataIndex, techIndex, UITechTree.NeighborWay.Down) : numPtr[techIndex + 1];
    }
    return 0;
  }

  public float GetSkillPosX(byte NodeCount, int Index)
  {
    if (NodeCount == (byte) 1)
      return this.Skillpos[1];
    return NodeCount <= (byte) 3 ? this.Skillpos[Index] : this.Skillpos[3 + Index];
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

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 0)
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
        return;
      menu.CloseMenu();
    }
    else if (((int) this.CheckTechState((ushort) sender.m_BtnID2) & 32) > 0)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7520U), (ushort) 12);
    }
    else
    {
      if (this.InfoWindow == null)
      {
        this.InfoWindow = new UITechInfo();
        this.InfoWindow.ThisTransform = this.transform.GetChild(4);
        this.InfoWindow.OnOpen(sender.m_BtnID2, 0);
      }
      else
        this.InfoWindow.UpdateUI(sender.m_BtnID2, 0);
      Debug.Log((object) ("TechID=" + (object) sender.m_BtnID2));
    }
  }

  public override void OnClose()
  {
    if (this.InfoWindow != null)
      this.InfoWindow.OnDestroy();
    if (this.TreeLayer != null)
    {
      for (int index = 0; index < this.TreeLayer.Length; ++index)
        this.TreeLayer[index].OnClose();
    }
    StringManager.Instance.DeSpawnString(this.NeedLvStr);
    if (this.PassFrame != (byte) 0 || this.InitScroll != (byte) 1)
      return;
    GUIManager.Instance.TechSaved[0] = this.TreeKind;
    GUIManager.Instance.TechSaved[1] = (byte) this.TechTreePanel.GetBeginIdx();
    GameConstants.GetBytes(this.RectCont.anchoredPosition.y, GUIManager.Instance.TechSaved, 2);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((UnityEngine.Object) this.TreeLayer[panelObjectIdx].ItemTransform == (UnityEngine.Object) null)
      this.TreeLayer[panelObjectIdx].Init(item.transform, (IUIButtonClickHandler) this, this.SpriteArray);
    else
      this.SetItemLayout((int) this.DataStart + dataIdx, panelObjectIdx);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (this.PassFrame > (byte) 0)
      return;
    byte Kind = 0;
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_BuildBase:
        this.UpdateInstitute();
        Kind |= (byte) 1;
        break;
      case NetworkNews.Refresh_Technology:
        Kind |= (byte) 2;
        break;
      default:
        switch (networkNews)
        {
          case NetworkNews.Login:
            this.UpdateInstitute();
            if (this.InitScroll == (byte) 1)
            {
              for (int index1 = 0; index1 < this.TreeLayer.Length; ++index1)
              {
                for (int index2 = 0; index2 < this.TreeLayer[index1].Tech.Length; ++index2)
                {
                  if (((Component) this.TreeLayer[index1].Tech[index2].TechTransform).gameObject.activeSelf)
                  {
                    this.TreeLayer[index1].Tech[index2].UpdateState(Kind);
                    this.TreeLayer[index1].Tech[index2].SetTechInfo((ushort) this.TreeLayer[index1].Tech[index2].TechBtn.m_BtnID2);
                  }
                }
                this.UpdateHorizontal(this.TreeLayer[index1].DataIndex, this.TreeLayer[index1].PanelIndex);
              }
            }
            if (this.InfoWindow != null && this.InfoWindow.ThisTransform.gameObject.activeSelf)
            {
              this.InfoWindow.UpdateTechInfo();
              break;
            }
            break;
          case NetworkNews.Refresh_FontTextureRebuilt:
            this.TextRefresh();
            break;
        }
        break;
    }
    if (Kind <= (byte) 0)
      return;
    if (this.InitScroll == (byte) 1)
    {
      for (int index3 = 0; index3 < this.TreeLayer.Length; ++index3)
      {
        if (((Component) this.TreeLayer[index3].ItemTransform).gameObject.activeSelf)
        {
          for (int index4 = 0; index4 < this.TreeLayer[index3].Tech.Length; ++index4)
          {
            if (((Component) this.TreeLayer[index3].Tech[index4].TechTransform).gameObject.activeSelf)
              this.TreeLayer[index3].Tech[index4].UpdateState(Kind);
          }
          if (((int) Kind & 2) > 0)
            this.UpdateHorizontal(this.TreeLayer[index3].DataIndex, this.TreeLayer[index3].PanelIndex);
        }
      }
    }
    if (this.InfoWindow == null || !this.InfoWindow.ThisTransform.gameObject.activeSelf)
      return;
    this.InfoWindow.UpdateTechInfo();
  }

  private void TextRefresh()
  {
    ((Behaviour) this.TitleText).enabled = false;
    ((Behaviour) this.TitleText).enabled = true;
    ((Behaviour) this.NeedLvText).enabled = false;
    ((Behaviour) this.NeedLvText).enabled = true;
    for (int index = 0; index < this.TreeLayer.Length; ++index)
      this.TreeLayer[index].TextRefresh();
    if (this.InfoWindow == null || !this.InfoWindow.ThisTransform.gameObject.activeSelf)
      return;
    this.InfoWindow.TextRefresh();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (this.PassFrame > (byte) 0)
    {
      this.UpdateQueue[0] = 1;
      this.UpdateQueue[1] = arg1;
      this.UpdateQueue[2] = arg2;
    }
    if (arg1 == -1)
    {
      if (this.InitScroll == (byte) 1)
      {
        this.Updategraphic();
        this.GraphicLoaded = (byte) 1;
      }
      else
        this.GraphicLoaded = (byte) 2;
    }
    else
    {
      if (this.PassFrame == (byte) 0)
        this.TechTreePanel.GoTo(arg1);
      if (this.InfoWindow == null)
      {
        this.InfoWindow = new UITechInfo();
        this.InfoWindow.ThisTransform = this.transform.GetChild(4);
        this.InfoWindow.OnOpen(arg2, 0);
      }
      else
      {
        if (this.InfoWindow.ThisTransform.gameObject.activeSelf)
          return;
        this.InfoWindow.UpdateUI(arg2, 0);
      }
    }
  }

  private void Updategraphic()
  {
    GUIManager instance = GUIManager.Instance;
    for (int index1 = 0; index1 < this.TreeLayer.Length; ++index1)
    {
      for (int index2 = 0; index2 < this.TreeLayer[index1].Tech.Length; ++index2)
      {
        if (((Component) this.TreeLayer[index1].Tech[index2].TechTransform).gameObject.activeSelf)
        {
          this.TreeLayer[index1].Tech[index2].TechIcon.sprite = instance.GetTechSprite(this.TreeLayer[index1].Tech[index2].GraphicID);
          ((MaskableGraphic) this.TreeLayer[index1].Tech[index2].TechIcon).material = instance.TechMaterial;
          ((Behaviour) this.TreeLayer[index1].Tech[index2].TechIcon).enabled = true;
        }
      }
    }
    if (this.InfoWindow == null)
      return;
    this.InfoWindow.TechImage.sprite = instance.GetTechSprite(this.InfoWindow.GraphicID);
    ((MaskableGraphic) this.InfoWindow.TechImage).material = instance.TechMaterial;
    ((Behaviour) this.InfoWindow.TechImage).enabled = true;
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void Update()
  {
    if (this.PassFrame > (byte) 0)
    {
      --this.PassFrame;
      if (this.PassFrame != (byte) 0)
        return;
      this.MaxItemCount = Mathf.Min(this.MaxItemCount, (int) this.DataCount);
      this.HorzontalShowFlag = new ushort[(int) this.DataCount];
      this.HorzontalShowFlag2 = new ushort[(int) this.DataCount];
      this.TreeLayer = new UITechTree.ItemEdit[this.MaxItemCount];
      if (this.DelayLoadScroll == (byte) 0)
        this.UpdateInstitute();
      NewbieManager.CheckTeach(ETeachKind.COLLEGE, (object) this);
      if (this.DelayLoadScroll == (byte) 0)
      {
        this.initTechPanel();
        this.TechTreePanel.gameObject.SetActive(true);
        this.UpdateBeginIndex(true);
      }
      ushort num = GameConstants.ConvertBytesToUShort(GUIManager.Instance.TechSaved, 6);
      if (num > (ushort) 0 && this.InfoWindow == null)
      {
        this.InfoWindow = new UITechInfo();
        this.InfoWindow.ThisTransform = this.transform.GetChild(4);
        this.InfoWindow.OnOpen((int) num, 0);
      }
      if (this.InitScroll == (byte) 1 && this.UpdateQueue[0] == 1)
      {
        this.UpdateUI(this.UpdateQueue[1], this.UpdateQueue[2]);
        Array.Clear((Array) this.UpdateQueue, 0, this.UpdateQueue.Length);
      }
      this.TextRefresh();
    }
    else if (this.DelayLoadScroll > (byte) 0)
    {
      --this.DelayLoadScroll;
      if (this.DelayLoadScroll != (byte) 0)
        return;
      this.UpdateInstitute();
      this.initTechPanel();
      this.TechTreePanel.gameObject.SetActive(true);
      if (this.UpdateQueue[0] == 1)
      {
        this.UpdateUI(this.UpdateQueue[1], this.UpdateQueue[2]);
        Array.Clear((Array) this.UpdateQueue, 0, this.UpdateQueue.Length);
        this.UpdateBeginIndex(true);
      }
      else
        this.UpdateBeginIndex(true);
      if (this.GraphicLoaded != (byte) 2)
        return;
      this.Updategraphic();
      this.GraphicLoaded = (byte) 1;
    }
    else
    {
      this.UpdateBeginIndex(false);
      for (int index = 0; index < this.TreeLayer.Length; ++index)
        this.TreeLayer[index].Update();
    }
  }

  private void initTechPanel()
  {
    for (byte index = 0; (int) index < this.MaxItemCount; ++index)
    {
      this.ItemsHeight.Add(239f);
      this.ItemIndex.Add((ushort) ((uint) this.DataStart + (uint) index));
    }
    this.TechTreePanel.IntiScrollPanel(492f, 0.0f, 0.0f, this.ItemsHeight, this.MaxItemCount, (IUpDateScrollPanel) this);
    if ((int) this.DataCount > this.MaxItemCount)
    {
      for (int maxItemCount = this.MaxItemCount; maxItemCount < (int) this.DataCount; ++maxItemCount)
      {
        this.ItemsHeight.Add(239f);
        this.ItemIndex.Add((ushort) maxItemCount);
      }
    }
    this.TechTreePanel.AddNewDataHeight(this.ItemsHeight);
    this.RectCont = this.TechTreePanel.transform.GetChild(0).GetComponent<RectTransform>();
    if ((int) GUIManager.Instance.TechSaved[0] == (int) this.TreeKind && !NewbieManager.IsTeachWorking(ETeachKind.COLLEGE))
    {
      byte num = GUIManager.Instance.TechSaved[1];
      float height = GameConstants.ConvertBytesToFloat(GUIManager.Instance.TechSaved, 2);
      this.TechTreePanel.GoTo((int) num, height);
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
      if (this.TreeLayer[index1].DataIndex == (int) this.DataStart + begin)
      {
        for (int index2 = 0; index2 < this.TreeLayer[index1].Tech.Length; ++index2)
        {
          if (((Component) this.TreeLayer[index1].Tech[index2].TechTransform).gameObject.activeSelf && this.TreeLayer[index1].Tech[index2].TechBtn.m_BtnID2 != 0 && (instance.GetTechLevel((ushort) this.TreeLayer[index1].Tech[index2].TechBtn.m_BtnID2) > (byte) 0 || ((int) this.CheckTechState((ushort) this.TreeLayer[index1].Tech[index2].TechBtn.m_BtnID2) & 1) == 0))
            this.TreeLayer[index1].Tech[index2].LineUp.sprite = this.SpriteArray.GetSprite(3);
        }
        break;
      }
    }
  }

  private void UpdateBeginIndex(bool bForceUpdate)
  {
    if (this.BeginIndex == this.TechTreePanel.GetBeginIdx())
      return;
    this.BeginIndex = this.TechTreePanel.GetBeginIdx();
    for (int index = 0; index < this.TreeLayer.Length; ++index)
    {
      if (bForceUpdate)
      {
        this.UpdateHorizontal(this.TreeLayer[index].DataIndex, this.TreeLayer[index].PanelIndex);
      }
      else
      {
        int num = this.TreeLayer[index].DataIndex - (int) this.DataStart;
        if (num == this.BeginIndex || num == this.BeginIndex + this.TreeLayer.Length - 1 || num == this.BeginIndex + this.TreeLayer.Length - 2)
          this.UpdateHorizontal(this.TreeLayer[index].DataIndex, this.TreeLayer[index].PanelIndex);
      }
    }
  }

  public void UpdateInstitute()
  {
    if (!this.CheckTechKindRule(this.NeedLvStr))
    {
      if (this.BlackFrameTrans.gameObject.activeSelf)
        return;
      this.BlackFrameTrans.gameObject.SetActive(true);
      this.NeedLvText.text = this.NeedLvStr.ToString();
      this.NeedLvText.SetAllDirty();
      this.NeedLvText.cachedTextGenerator.Invalidate();
      RectTransform component = this.TechTreePanel.transform.GetComponent<RectTransform>();
      Vector2 anchoredPosition = component.anchoredPosition with
      {
        y = -67.14f
      };
      component.anchoredPosition = anchoredPosition;
      Vector2 sizeDelta = component.sizeDelta with
      {
        y = 478.8f
      };
      component.sizeDelta = sizeDelta;
    }
    else
    {
      if (!this.BlackFrameTrans.gameObject.activeSelf)
        return;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
        return;
      menu.CloseMenu();
    }
  }

  public bool CheckTechKindRule(CString NeedLvStr)
  {
    TechKindTbl recordByKey = DataManager.Instance.TechKindData.GetRecordByKey((ushort) this.TreeKind);
    StringTable mStringTable = DataManager.Instance.mStringTable;
    if ((int) recordByKey.ResearchLevel > (int) GUIManager.Instance.BuildingData.GetBuildData((ushort) 10, (ushort) 0).Level)
    {
      NeedLvStr.ClearString();
      NeedLvStr.IntToFormat((long) recordByKey.ResearchLevel);
      NeedLvStr.AppendFormat(mStringTable.GetStringByID(5008U));
      return false;
    }
    return DataManager.Instance.CheckTechKind(ref recordByKey, NeedLvStr);
  }

  public enum TechSprite
  {
    Skill,
    SkillOn,
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
    Tree,
    Close,
    Item,
    Info,
  }

  private enum ItemControl
  {
    Skill1,
    Skill2,
    Skill3,
    Skill4,
    HorizontalLineDown0,
    HorizontalLineDown1,
    Node1,
    Node2,
    Node3,
    Node4,
    Node5,
    Node6,
    Node7,
    Node8,
    Node9,
    Node10,
    Node11,
    Node12,
    Node13,
    Node14,
  }

  private enum LeaveControl
  {
    Icon,
    LineUp,
    LineDown,
    LineLeft,
    LineRight,
    Frame,
    Degree,
    LvText,
    Name,
  }

  private enum ClickType
  {
    Close,
    Tech,
  }

  public enum NeighborWay
  {
    Up,
    Down,
    Left,
    Right,
  }

  public class TechItem
  {
    public RectTransform TechTransform;
    public RectTransform TechIconTrans;
    public RectTransform FrameTransform;
    public RectTransform Researching;
    public Transform BlackFrame;
    public Transform Lock;
    public Transform Lock1;
    public Image TechIcon;
    public Image LineUp;
    public Image LineDown;
    public Image LineLeft;
    public Image LineRight;
    public Image TechLock;
    public Image Degree;
    public Image Frame;
    public Image LockImg;
    public UIButton TechBtn;
    public UIText Level;
    public UIText Name;
    private CString TechNameStr;
    private CString TechLvStr;
    private float RotTime;
    private Vector2 FramePos;
    private Vector2 FrameSize;
    private Vector2 LineRPos;
    private Vector2 LineRSize;
    private Vector2 LineLPos;
    private Vector2 LineLSize;
    private Vector2 LineTPos;
    private Vector2 LineTSize;
    private Vector2 LineBPos;
    private Vector2 LineBSize;
    public ushort GraphicID;
    private byte RequireBuildLv;
    private UITechTree.TechItem._RequireTech[] RequireTech = new UITechTree.TechItem._RequireTech[4];
    public byte State;
    private UISpritesArray SpriteArr;
    public int FrameIndex;

    public void Init(Transform transform, IUIButtonClickHandler handler)
    {
      this.TechTransform = transform as RectTransform;
      this.TechIconTrans = transform.GetChild(0).GetComponent<RectTransform>();
      this.TechIcon = transform.GetChild(0).GetComponent<Image>();
      this.TechBtn = transform.GetChild(0).GetComponent<UIButton>();
      this.BlackFrame = transform.GetChild(0).GetChild(0);
      this.LineUp = transform.GetChild(1).GetComponent<Image>();
      this.LineDown = transform.GetChild(2).GetComponent<Image>();
      this.LineLeft = transform.GetChild(3).GetComponent<Image>();
      this.LineRight = transform.GetChild(4).GetComponent<Image>();
      this.TechBtn.m_Handler = handler;
      this.Frame = transform.GetChild(5).GetComponent<Image>();
      this.FrameTransform = transform.GetChild(5) as RectTransform;
      this.Lock = transform.GetChild(5).GetChild(0);
      this.LockImg = this.Lock.GetComponent<Image>();
      this.Lock1 = transform.GetChild(5).GetChild(1);
      this.Researching = transform.GetChild(5).GetChild(2).GetComponent<RectTransform>();
      this.TechLock = transform.GetChild(5).GetChild(0).GetComponent<Image>();
      this.Degree = transform.GetChild(6).GetComponent<Image>();
      this.Level = transform.GetChild(7).GetComponent<UIText>();
      this.Name = transform.GetChild(8).GetComponent<UIText>();
      if (GUIManager.Instance.IsArabic)
        ((Component) this.TechBtn).transform.localScale = new Vector3(-1f, 1f, 1f);
      this.FramePos = this.FrameTransform.anchoredPosition;
      this.FrameSize = this.FrameTransform.sizeDelta;
      RectTransform rectTransform1 = ((Graphic) this.LineRight).rectTransform;
      this.LineRPos = rectTransform1.anchoredPosition;
      this.LineRSize = rectTransform1.sizeDelta;
      RectTransform rectTransform2 = ((Graphic) this.LineLeft).rectTransform;
      this.LineLPos = rectTransform2.anchoredPosition;
      this.LineLSize = rectTransform2.sizeDelta;
      RectTransform rectTransform3 = ((Graphic) this.LineUp).rectTransform;
      this.LineTPos = rectTransform3.anchoredPosition;
      this.LineTSize = rectTransform3.sizeDelta;
      RectTransform rectTransform4 = ((Graphic) this.LineDown).rectTransform;
      this.LineBPos = rectTransform4.anchoredPosition;
      this.LineBSize = rectTransform4.sizeDelta;
      this.TechNameStr = StringManager.Instance.SpawnString();
      this.TechLvStr = StringManager.Instance.SpawnString();
    }

    public void SetItemStyle(ushort TechID)
    {
      switch (TechID)
      {
        case 1001:
          ((Component) this.TechLock).gameObject.SetActive(false);
          ((Component) this.LineUp).gameObject.SetActive(false);
          ((Component) this.LineDown).gameObject.SetActive(false);
          ((Component) this.LineLeft).gameObject.SetActive(false);
          ((Component) this.LineRight).gameObject.SetActive(false);
          ((Component) this.FrameTransform).gameObject.SetActive(false);
          ((Component) this.Degree).gameObject.SetActive(false);
          ((Component) this.TechIcon).gameObject.SetActive(false);
          this.BlackFrame.gameObject.SetActive(false);
          this.Name.text = string.Empty;
          ((Component) this.LineDown).gameObject.SetActive(true);
          RectTransform rectTransform1 = ((Graphic) this.LineDown).rectTransform;
          Vector2 anchoredPosition1 = rectTransform1.anchoredPosition;
          anchoredPosition1.Set(95f, -242f);
          rectTransform1.anchoredPosition = anchoredPosition1;
          Vector2 sizeDelta1 = rectTransform1.sizeDelta;
          sizeDelta1.Set(248.1f, 10f);
          rectTransform1.sizeDelta = sizeDelta1;
          break;
        case 1002:
          ((Component) this.TechLock).gameObject.SetActive(false);
          ((Component) this.LineUp).gameObject.SetActive(false);
          ((Component) this.LineLeft).gameObject.SetActive(false);
          ((Component) this.LineDown).gameObject.SetActive(true);
          ((Component) this.LineRight).gameObject.SetActive(true);
          ((Component) this.Degree).gameObject.SetActive(false);
          ((Component) this.TechIcon).gameObject.SetActive(false);
          this.BlackFrame.gameObject.SetActive(false);
          ((Component) this.FrameTransform).gameObject.SetActive(true);
          this.Name.text = string.Empty;
          Vector2 anchoredPosition2 = this.FrameTransform.anchoredPosition;
          anchoredPosition2.Set(10.56f, -15.2f);
          this.FrameTransform.anchoredPosition = anchoredPosition2;
          Vector2 sizeDelta2 = this.FrameTransform.sizeDelta;
          sizeDelta2.Set(30f, 30f);
          this.FrameTransform.sizeDelta = sizeDelta2;
          RectTransform rectTransform2 = ((Graphic) this.LineRight).rectTransform;
          Vector2 anchoredPosition3 = rectTransform2.anchoredPosition;
          anchoredPosition3.Set(122.6f, -110.2f);
          rectTransform2.anchoredPosition = anchoredPosition3;
          Vector2 sizeDelta3 = rectTransform2.sizeDelta;
          sizeDelta3.Set(62.6f, 10f);
          rectTransform2.sizeDelta = sizeDelta3;
          RectTransform rectTransform3 = ((Graphic) this.LineDown).rectTransform;
          anchoredPosition3 = rectTransform3.anchoredPosition;
          anchoredPosition3.Set(95f, -239.9f);
          rectTransform3.anchoredPosition = anchoredPosition3;
          Vector2 sizeDelta4 = ((Graphic) this.LineDown).rectTransform.sizeDelta;
          sizeDelta4.Set(103.6f, 10f);
          rectTransform3.sizeDelta = sizeDelta4;
          break;
        case 1003:
          ((Component) this.TechLock).gameObject.SetActive(false);
          ((Component) this.LineUp).gameObject.SetActive(false);
          ((Component) this.LineLeft).gameObject.SetActive(true);
          ((Component) this.Degree).gameObject.SetActive(false);
          ((Component) this.TechIcon).gameObject.SetActive(false);
          ((Component) this.LineRight).gameObject.SetActive(false);
          ((Component) this.LineDown).gameObject.SetActive(true);
          ((Component) this.FrameTransform).gameObject.SetActive(true);
          ((Component) this.Researching).gameObject.SetActive(false);
          this.Name.text = string.Empty;
          Vector2 anchoredPosition4 = this.FrameTransform.anchoredPosition;
          anchoredPosition4.Set(-9.5f, -15.2f);
          this.FrameTransform.anchoredPosition = anchoredPosition4;
          Vector2 sizeDelta5 = this.FrameTransform.sizeDelta;
          sizeDelta5.Set(30f, 30f);
          this.FrameTransform.sizeDelta = sizeDelta5;
          RectTransform rectTransform4 = ((Graphic) this.LineLeft).rectTransform;
          Vector2 anchoredPosition5 = rectTransform4.anchoredPosition;
          anchoredPosition5.Set(-30.7f, -110.2f);
          rectTransform4.anchoredPosition = anchoredPosition5;
          Vector2 sizeDelta6 = ((Graphic) this.LineRight).rectTransform.sizeDelta;
          sizeDelta6.Set(109.39f, 10f);
          rectTransform4.sizeDelta = sizeDelta6;
          RectTransform rectTransform5 = ((Graphic) this.LineDown).rectTransform;
          anchoredPosition5 = rectTransform5.anchoredPosition;
          anchoredPosition5.Set(95f, -235.4f);
          rectTransform5.anchoredPosition = anchoredPosition5;
          Vector2 sizeDelta7 = ((Graphic) this.LineDown).rectTransform.sizeDelta;
          sizeDelta7.Set(103.2f, 10f);
          rectTransform5.sizeDelta = sizeDelta7;
          break;
        default:
          this.FrameTransform.anchoredPosition = this.FramePos;
          this.FrameTransform.sizeDelta = this.FrameSize;
          ((Component) this.Degree).gameObject.SetActive(true);
          ((Component) this.TechIcon).gameObject.SetActive(true);
          ((Component) this.FrameTransform).gameObject.SetActive(true);
          RectTransform rectTransform6 = ((Graphic) this.LineRight).rectTransform;
          rectTransform6.anchoredPosition = this.LineRPos;
          rectTransform6.sizeDelta = this.LineRSize;
          RectTransform rectTransform7 = ((Graphic) this.LineLeft).rectTransform;
          rectTransform7.anchoredPosition = this.LineLPos;
          rectTransform7.sizeDelta = this.LineLSize;
          RectTransform rectTransform8 = ((Graphic) this.LineUp).rectTransform;
          rectTransform8.anchoredPosition = this.LineTPos;
          rectTransform8.sizeDelta = this.LineTSize;
          RectTransform rectTransform9 = ((Graphic) this.LineDown).rectTransform;
          rectTransform9.anchoredPosition = this.LineBPos;
          rectTransform9.sizeDelta = this.LineBSize;
          break;
      }
    }

    public void SetTechID(ref UISpritesArray SpriteArray, ushort TechID, int FrameIndex)
    {
      DataManager instance = DataManager.Instance;
      this.TechBtn.m_BtnID2 = (int) TechID;
      this.SpriteArr = SpriteArray;
      this.FrameIndex = FrameIndex;
      this.Frame.sprite = SpriteArray.GetSprite(FrameIndex);
      Sprite sprite = SpriteArray.GetSprite(2);
      this.LineDown.sprite = sprite;
      this.LineLeft.sprite = sprite;
      this.LineRight.sprite = sprite;
      if ((int) instance.ResearchTech == (int) TechID)
        ((Component) this.Researching).gameObject.SetActive(true);
      else
        ((Component) this.Researching).gameObject.SetActive(false);
    }

    public void SetTechInfo(ushort TechID)
    {
      if (TechID > (ushort) 1000)
        return;
      DataManager instance = DataManager.Instance;
      TechDataTbl recordByKey = instance.TechData.GetRecordByKey(TechID);
      this.TechNameStr.ClearString();
      this.TechLvStr.ClearString();
      this.TechNameStr.Insert(0, instance.mStringTable.GetStringByID((uint) recordByKey.TechName));
      this.Name.text = this.TechNameStr.ToString();
      this.Name.SetAllDirty();
      this.Name.cachedTextGenerator.Invalidate();
      byte techLevel = instance.GetTechLevel(TechID);
      float num = 173.8f / (float) recordByKey.LevelMax;
      ((Graphic) this.Degree).rectTransform.sizeDelta = ((Graphic) this.Degree).rectTransform.sizeDelta with
      {
        x = num * (float) techLevel
      };
      this.TechLvStr.IntToFormat((long) techLevel);
      this.TechLvStr.IntToFormat((long) recordByKey.LevelMax);
      if (GUIManager.Instance.IsArabic)
        this.TechLvStr.AppendFormat("{1}/{0}");
      else
        this.TechLvStr.AppendFormat("{0}/{1}");
      this.Level.text = this.TechLvStr.ToString();
      this.Level.SetAllDirty();
      this.Level.cachedTextGenerator.Invalidate();
      this.GraphicID = recordByKey.Graphic;
      if ((UnityEngine.Object) GUIManager.Instance.TechMaterial == (UnityEngine.Object) null)
      {
        ((Behaviour) this.TechIcon).enabled = false;
      }
      else
      {
        this.TechIcon.sprite = GUIManager.Instance.GetTechSprite(this.GraphicID);
        ((MaskableGraphic) this.TechIcon).material = GUIManager.Instance.TechMaterial;
        if ((UnityEngine.Object) ((MaskableGraphic) this.TechIcon).material != (UnityEngine.Object) null)
          ((Behaviour) this.TechIcon).enabled = true;
      }
      TechLevelTbl Data;
      if (instance.GetTechLevelupData(out Data, TechID, (byte) ((uint) techLevel + 1U)))
      {
        this.RequireBuildLv = Data.ResearchLevel;
        this.RequireTech[0].TechID = Data.RequireTechID1;
        this.RequireTech[1].TechID = Data.RequireTechID2;
        this.RequireTech[2].TechID = Data.RequireTechID3;
        this.RequireTech[3].TechID = Data.RequireTechID4;
        this.RequireTech[0].Lv = Data.RequireTechLv1;
        this.RequireTech[1].Lv = Data.RequireTechLv2;
        this.RequireTech[2].Lv = Data.RequireTechLv3;
        this.RequireTech[3].Lv = Data.RequireTechLv4;
      }
      this.State = instance.CheckTechState(TechID);
      this.UpdateState((byte) 7);
    }

    public byte CheckTechState()
    {
      ushort TechID = (ushort) this.TechBtn.m_BtnID2;
      if (TechID >= (ushort) 1001)
        TechID = (ushort) this.TechBtn.m_BtnID3;
      return DataManager.Instance.CheckTechState(TechID);
    }

    public void UpdateState(byte Kind)
    {
      if (((int) this.State & 32) > 0)
      {
        this.Lock1.gameObject.SetActive(false);
        this.BlackFrame.gameObject.SetActive(true);
        this.Lock.gameObject.SetActive(true);
        this.LockImg.sprite = this.SpriteArr.GetSprite(11);
        this.LockImg.SetNativeSize();
      }
      else
      {
        this.LockImg.sprite = this.SpriteArr.GetSprite(10);
        this.LockImg.SetNativeSize();
        if (((int) Kind & 2) > 0 && this.TechBtn.m_BtnID2 == (int) DataManager.Instance.CheckResearchTech && ((Component) this.Researching).gameObject.activeSelf)
        {
          ((Component) this.Researching).gameObject.SetActive(false);
          this.SetTechInfo((ushort) this.TechBtn.m_BtnID2);
        }
        else
        {
          this.State = this.CheckTechState();
          DataManager instance = DataManager.Instance;
          if (((int) Kind & 2) > 0)
          {
            if (((int) this.State & 2) == 0 && ((int) this.State & 1) > 0)
              this.BlackFrame.gameObject.SetActive(true);
            else
              this.BlackFrame.gameObject.SetActive(false);
            this.UpdateLineState();
          }
          if (((Component) this.Researching).gameObject.activeSelf)
          {
            this.Lock.gameObject.SetActive(false);
            this.Lock1.gameObject.SetActive(false);
          }
          else
          {
            if (((int) this.State & 4) > 0 && ((int) Kind & 1) > 0)
            {
              if ((int) GUIManager.Instance.BuildingData.GetBuildData((ushort) 10, (ushort) 0).Level >= (int) this.RequireBuildLv)
              {
                this.UpdateState((byte) 6);
                return;
              }
            }
            else if (((int) Kind & 2) > 0)
            {
              if (((int) this.State & 8) > 0)
              {
                bool flag = true;
                for (int index = 0; index < this.RequireTech.Length; ++index)
                {
                  if ((int) instance.GetTechLevel(this.RequireTech[index].TechID) < (int) this.RequireTech[index].Lv)
                  {
                    flag = false;
                    break;
                  }
                }
                if (flag)
                {
                  this.UpdateState((byte) 5);
                  return;
                }
              }
              else if (((int) this.State & 64) > 0)
              {
                TechDataTbl recordByKey = instance.TechData.GetRecordByKey((ushort) this.TechBtn.m_BtnID2);
                if ((int) recordByKey.LevelMax == (int) instance.GetTechLevel(recordByKey.TechID))
                {
                  this.Frame.sprite = this.SpriteArr.GetSprite(this.FrameIndex + 1);
                  Sprite sprite = this.SpriteArr.GetSprite(3);
                  this.LineDown.sprite = sprite;
                  this.LineLeft.sprite = sprite;
                  this.LineRight.sprite = sprite;
                  ((Component) this.Degree).gameObject.SetActive(false);
                  this.BlackFrame.gameObject.SetActive(false);
                  this.Lock.gameObject.SetActive(false);
                }
              }
            }
            if (((int) this.State & 1) > 0)
            {
              if (((int) this.State & 2) > 0)
              {
                this.Lock1.gameObject.SetActive(true);
                this.Lock.gameObject.SetActive(false);
              }
              else
              {
                this.Lock1.gameObject.SetActive(false);
                this.Lock.gameObject.SetActive(true);
                this.LockImg.sprite = this.SpriteArr.GetSprite(10);
              }
            }
            else
            {
              this.Lock.gameObject.SetActive(false);
              this.Lock1.gameObject.SetActive(false);
            }
          }
        }
      }
    }

    public void UpdateLineState()
    {
      if (((int) this.State & 2) != 0)
        return;
      this.Frame.sprite = this.SpriteArr.GetSprite(this.FrameIndex);
      Sprite sprite = this.SpriteArr.GetSprite(2);
      this.LineDown.sprite = sprite;
      this.LineLeft.sprite = sprite;
      this.LineRight.sprite = sprite;
    }

    public void OnClose()
    {
      StringManager.Instance.DeSpawnString(this.TechNameStr);
      StringManager.Instance.DeSpawnString(this.TechLvStr);
    }

    public void TextRefresh()
    {
      if ((UnityEngine.Object) this.Level == (UnityEngine.Object) null)
        return;
      ((Behaviour) this.Level).enabled = false;
      ((Behaviour) this.Name).enabled = false;
      ((Behaviour) this.Level).enabled = true;
      ((Behaviour) this.Name).enabled = true;
    }

    public void Update()
    {
      if (!((Component) this.Researching).gameObject.activeSelf)
        return;
      if ((double) this.RotTime <= 1.2999999523162842)
      {
        Quaternion localRotation = ((Transform) this.Researching).localRotation;
        Vector3 eulerAngles = localRotation.eulerAngles with
        {
          z = (double) this.RotTime > 0.5 ? 180f : EasingEffect.Linear(this.RotTime, 0.0f, 180f, 0.5f)
        };
        localRotation.eulerAngles = eulerAngles;
        ((Transform) this.Researching).localRotation = localRotation;
      }
      else if ((double) this.RotTime <= 2.5999999046325684)
      {
        float t = this.RotTime - 1.3f;
        Quaternion localRotation = ((Transform) this.Researching).localRotation;
        Vector3 eulerAngles = localRotation.eulerAngles with
        {
          z = (double) t > 0.5 ? 360f : EasingEffect.Linear(t, 180f, 180f, 0.5f)
        };
        localRotation.eulerAngles = eulerAngles;
        ((Transform) this.Researching).localRotation = localRotation;
      }
      else
        this.RotTime = 0.0f;
      this.RotTime += Time.smoothDeltaTime;
    }

    private struct _RequireTech
    {
      public ushort TechID;
      public byte Lv;
    }
  }

  public struct LineItem
  {
    public RectTransform LineTrans;
    public Image LineImg;

    public void Init(Transform transform)
    {
      this.LineTrans = transform.GetComponent<RectTransform>();
      this.LineImg = transform.GetComponent<Image>();
    }
  }

  public struct ItemEdit
  {
    public int DataIndex;
    public int PanelIndex;
    public RectTransform ItemTransform;
    public UITechTree.TechItem[] Tech;
    public UITechTree.LineItem[] Line;
    public Image[] Node;
    private UISpritesArray SpriteArray;

    public void Init(
      Transform transform,
      IUIButtonClickHandler handler,
      UISpritesArray spriteArray)
    {
      this.ItemTransform = transform as RectTransform;
      this.Tech = new UITechTree.TechItem[4];
      this.Line = new UITechTree.LineItem[2];
      this.Node = new Image[14];
      this.SpriteArray = spriteArray;
      for (int index = 0; index < this.Tech.Length; ++index)
      {
        this.Tech[index] = new UITechTree.TechItem();
        this.Tech[index].Init(((Transform) this.ItemTransform).GetChild(index), handler);
      }
      for (int index = 0; index < this.Line.Length; ++index)
        this.Line[index].Init(transform.GetChild(index + 4));
      for (int index = 0; index < this.Node.Length; ++index)
        this.Node[index] = transform.GetChild(index + 6).GetComponent<Image>();
    }

    public void UpdateLineLRState()
    {
      DataManager instance = DataManager.Instance;
      for (int index = 0; index < this.Tech.Length; ++index)
      {
        if (((int) this.Tech[index].State & 2) == 0)
        {
          this.Tech[index].LineDown.sprite = this.SpriteArray.GetSprite(2);
          this.Tech[index].LineLeft.sprite = this.SpriteArray.GetSprite(2);
          this.Tech[index].LineRight.sprite = this.SpriteArray.GetSprite(2);
        }
        else
        {
          if (index > 0)
          {
            byte num = instance.CheckTechState((ushort) this.Tech[index - 1].TechBtn.m_BtnID2);
            this.Tech[index].LineLeft.sprite = ((int) num & 2) <= 0 ? this.SpriteArray.GetSprite(2 + ((int) num & 1 ^ 1)) : this.SpriteArray.GetSprite(3);
          }
          if (index + 1 < this.Tech.Length)
          {
            byte num = instance.CheckTechState((ushort) this.Tech[index + 1].TechBtn.m_BtnID2);
            this.Tech[index].LineRight.sprite = ((int) num & 2) <= 0 ? this.SpriteArray.GetSprite(2 + ((int) num & 1 ^ 1)) : this.SpriteArray.GetSprite(3);
          }
        }
      }
    }

    public void OnClose()
    {
      if (this.Tech == null)
        return;
      for (int index = 0; index < this.Tech.Length; ++index)
      {
        if (this.Tech[index] != null)
          this.Tech[index].OnClose();
      }
    }

    public void TextRefresh()
    {
      if (this.Tech == null)
        return;
      for (int index = 0; index < this.Tech.Length && this.Tech[index] != null; ++index)
        this.Tech[index].TextRefresh();
    }

    public void Update()
    {
      if (!((Component) this.ItemTransform).gameObject.activeSelf)
        return;
      for (int index = 0; index < this.Tech.Length; ++index)
        this.Tech[index].Update();
    }
  }

  private enum SpriteArrayIdx
  {
    Box,
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
