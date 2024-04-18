// Decompiled with JetBrains decompiler
// Type: UIMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIMission : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
  public UIMissionItemController ItemController;
  private Image RewardBk;
  private RectTransform[] RewardItems = new RectTransform[6];
  private UIHIBtn[] RewardHIBtn = new UIHIBtn[3];
  private RectTransform[] UsedRewardItem = new RectTransform[3];
  private UIText[] RewardNum = new UIText[6];
  private CString[] RewardNumStr = new CString[6];
  private UIMission._Reward[] RewardData = new UIMission._Reward[7];
  private RectTransform RewardPriceRect;
  private RectTransform RewardRect;
  public RectTransform HintRect;
  private UIText HintText;
  private UIMission._TagControl[] TagControl;
  private uint[] Reward;
  private ushort[] RewardItemID;
  private ushort[] RewardItemCount;
  private ushort[] RewardHintText;
  private Sprite[] RewardIcon;
  private byte DelayInit = 2;
  private Vector2 PriceList;
  private iMissionTimeDelta TimeHandle;
  private Color TagTextColor;
  private UIText[] TextRefresh = new UIText[2];
  private ArabicItemTextureRot ArabicRot;
  private GameObject UpgradeAlliancObj;
  private uTweener UpgradeTweenPosition;
  private uTweener UpgradeTweenAlpha;
  private UIButton SelectBtn;

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager instance1 = GUIManager.Instance;
    DataManager instance2 = DataManager.Instance;
    Font ttfFont = instance1.GetTTFFont();
    instance1.UpdateUI(EGUIWindow.Door, 1, 2);
    if (instance1.bOpenOnIPhoneX)
      ((Behaviour) this.transform.GetChild(11).GetComponent<CustomImage>()).enabled = false;
    else
      this.transform.GetChild(11).GetComponent<CustomImage>().hander = (UILoadImageHander) instance1.m_ItemInfo;
    this.transform.GetChild(11).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) instance1.m_ItemInfo;
    UIButton component1 = this.transform.GetChild(11).GetChild(0).GetComponent<UIButton>();
    component1.m_BtnID1 = 5;
    component1.m_Handler = (IUIButtonClickHandler) this;
    this.TextRefresh[0] = this.transform.GetChild(2).GetChild(0).GetComponent<UIText>();
    this.TextRefresh[0].font = ttfFont;
    this.TextRefresh[0].text = instance2.mStringTable.GetStringByID(1521U);
    this.RewardRect = this.transform.GetChild(5).GetComponent<RectTransform>();
    this.RewardPriceRect = this.transform.GetChild(5).GetChild(2).GetComponent<RectTransform>();
    this.TextRefresh[1] = this.transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.TextRefresh[1].font = ttfFont;
    this.TextRefresh[1].text = instance2.mStringTable.GetStringByID(1527U);
    this.PriceList = this.RewardPriceRect.anchoredPosition;
    this.RewardBk = this.transform.GetChild(5).GetChild(1).GetComponent<Image>();
    for (int index = 0; index < this.RewardItems.Length; ++index)
    {
      this.RewardItems[index] = this.transform.GetChild(5).GetChild(1).GetChild(index).GetComponent<RectTransform>();
      this.RewardNum[index] = ((Transform) this.RewardItems[index]).GetChild(0).GetComponent<UIText>();
      this.RewardNum[index].font = ttfFont;
      this.RewardNumStr[index] = StringManager.Instance.SpawnString();
    }
    this.TagControl = new UIMission._TagControl[4];
    for (int index = 0; index < 4; ++index)
    {
      this.TagControl[index].Btn = this.transform.GetChild(3).GetChild(index).GetComponent<UIButton>();
      this.TagControl[index].Btn.m_BtnID1 = 0 + index;
      this.TagControl[index].Btn.m_Handler = (IUIButtonClickHandler) this;
      this.TagControl[index].Title = this.transform.GetChild(3).GetChild(index).GetChild(1).GetComponent<UIText>();
      this.TagControl[index].Title.font = ttfFont;
      this.TagControl[index].Title.text = instance2.mStringTable.GetStringByID((uint) (1523 + index));
      this.transform.GetChild(3).GetChild(4 + index).GetComponent<CustomImage>().hander = (UILoadImageHander) instance1.m_ItemInfo;
      this.TagControl[index].Init();
      this.TagControl[index].TagAlpha = this.transform.GetChild(3).GetChild(index).GetChild(0).GetComponent<CanvasGroup>();
      this.TagControl[index].Tip = this.transform.GetChild(3).GetChild(4 + index);
      this.TagControl[index].Notice = this.transform.GetChild(3).GetChild(8 + index);
      this.TagControl[index].Notice.GetComponent<CustomImage>().hander = (UILoadImageHander) instance1.m_ItemInfo;
      this.TagControl[index].Notice.GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) instance1.m_ItemInfo;
      this.TagControl[index].Notice.GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) instance1.m_ItemInfo;
      this.TagControl[index].NumText = this.TagControl[index].Tip.GetChild(0).GetComponent<UIText>();
      this.TagControl[index].NumText.font = ttfFont;
      this.TagControl[index].SetNum(DataManager.MissionDataManager.AccessMissionCount[index]);
      this.UpdateTagInfo(index);
    }
    this.UpgradeAlliancObj = this.transform.GetChild(3).GetChild(this.transform.GetChild(3).childCount - 1).gameObject;
    this.UpgradeTweenPosition = (uTweener) this.UpgradeAlliancObj.transform.GetChild(0).GetComponent<uTweenPosition>();
    this.UpgradeTweenAlpha = (uTweener) this.UpgradeAlliancObj.transform.GetChild(0).GetComponent<uTweenAlpha>();
    this.TagTextColor = ((Graphic) this.TagControl[0].Title).color;
    this.HintRect = this.transform.GetChild(12).GetComponent<RectTransform>();
    this.HintText = ((Transform) this.HintRect).GetChild(0).GetComponent<UIText>();
    this.HintText.font = ttfFont;
    this.transform.GetChild(12).GetComponent<CustomImage>().hander = (UILoadImageHander) instance1.m_ItemInfo;
    UIButton component2 = this.transform.GetChild(1).GetComponent<UIButton>();
    ((Component) component2).gameObject.SetActive(true);
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 13;
    if (!instance1.IsArabic)
      return;
    ((Component) component2).transform.localScale = new Vector3(-1f, 1f, 1f);
  }

  public void Init()
  {
    GUIManager instance = GUIManager.Instance;
    Font ttfFont = instance.GetTTFFont();
    this.ItemController = new UIMissionItemController(this, this.transform.GetChild(6), (byte) 8);
    this.ItemController.NoMissionText.font = ttfFont;
    this.ItemController.AllianceBoundRateText.font = ttfFont;
    this.ItemController.TimeText.font = ttfFont;
    this.ItemController.ItemSample[1] = this.transform.GetChild(8);
    this.ItemController.ItemSample[0] = this.transform.GetChild(10);
    this.ItemController.ItemSample[2] = this.transform.GetChild(9);
    this.ItemController.ItemSample[3] = this.transform.GetChild(4);
    this.ItemController.ItemSample[2].GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.ItemController.ItemSample[2].GetChild(3).GetComponent<UIText>().font = ttfFont;
    this.ItemController.ItemSample[0].GetChild(0).GetComponent<UIText>().font = ttfFont;
    for (int index = 0; index < ManorAimMission.MaxSlot; ++index)
    {
      this.ItemController.ItemSample[0].GetChild(1 + index).GetChild(0).GetComponent<UIText>().font = ttfFont;
      this.ItemController.ItemSample[0].GetChild(1 + index).GetChild(1).GetChild(1).GetComponent<UIText>().font = ttfFont;
    }
    this.ItemController.ItemSample[1].GetChild(3).GetChild(1).GetComponent<UIText>().font = ttfFont;
    this.ItemController.ItemSample[1].GetChild(1).GetComponent<UIText>().font = ttfFont;
    this.ItemController.ItemSample[3].GetChild(0).GetChild(1).GetComponent<UIText>().font = ttfFont;
    this.ItemController.ItemSample[3].GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.ItemController.ItemSample[3].GetChild(10).GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(6).GetChild(4).GetChild(0).GetChild(0).GetChild(1).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(6).GetChild(4).GetChild(0).GetChild(0).GetChild(2).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(6).GetChild(4).GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(6).GetChild(4).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(6).GetChild(4).GetChild(1).GetChild(0).GetChild(2).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(6).GetChild(4).GetChild(1).GetChild(0).GetChild(3).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(3).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(4).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(5).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(6).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(7).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(8).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(9).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.TimeHandle = (iMissionTimeDelta) this.ItemController;
    this.Reward = new uint[9];
    this.RewardIcon = new Sprite[9];
    this.RewardHintText = new ushort[9];
    this.RewardItemID = new ushort[3];
    this.RewardItemCount = new ushort[3];
    Door menu = instance.FindMenu(EGUIWindow.Door) as Door;
    this.RewardIcon[0] = DataManager.Instance.UserLanguage != GameLanguage.GL_Chs ? menu.LoadSprite("UI_main_res_exp") : menu.LoadSprite("UI_main_res_exp_cn");
    this.RewardIcon[1] = menu.LoadSprite("UI_main_res_strength");
    this.RewardIcon[2] = menu.LoadSprite("UI_main_money_03");
    this.RewardIcon[3] = menu.LoadSprite("UI_main_res_food");
    this.RewardIcon[4] = menu.LoadSprite("UI_main_res_stone");
    this.RewardIcon[5] = menu.LoadSprite("UI_main_res_wood");
    this.RewardIcon[6] = menu.LoadSprite("UI_main_res_iron");
    this.RewardIcon[7] = menu.LoadSprite("UI_main_money_01");
    this.RewardIcon[8] = menu.LoadSprite("UI_main_res_league");
    this.RewardHintText[0] = (ushort) 1522;
    this.RewardHintText[1] = (ushort) 1564;
    this.RewardHintText[2] = (ushort) 1600;
    this.RewardHintText[3] = (ushort) 1581;
    this.RewardHintText[4] = (ushort) 1582;
    this.RewardHintText[5] = (ushort) 1583;
    this.RewardHintText[6] = (ushort) 1584;
    this.RewardHintText[7] = (ushort) 1529;
    this.RewardHintText[8] = (ushort) 1592;
    Material IconMat = menu.LoadMaterial();
    this.ArabicRot = this.transform.GetChild(5).GetChild(2).GetChild(0).GetChild(0).GetComponent<ArabicItemTextureRot>();
    for (int index = 0; index < this.RewardData.Length; ++index)
    {
      this.RewardData[index] = new UIMission._Reward(this.transform.GetChild(5).GetChild(2).GetChild(index), IconMat);
      this.RewardData[index].RewardText.font = ttfFont;
      this.RewardData[index].Hint.m_Handler = (MonoBehaviour) this;
      this.RewardData[index].Hint.ControlFadeOut = ((Component) this.HintRect).gameObject;
    }
    for (int index = 0; index < this.RewardItems.Length; ++index)
    {
      if (index < this.RewardItems.Length >> 1)
      {
        instance.InitianHeroItemImg((Transform) this.RewardItems[index], eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false);
        this.RewardHIBtn[index] = ((Component) this.RewardItems[index]).GetComponent<UIHIBtn>();
      }
      else
      {
        instance.InitLordEquipImg((Transform) this.RewardItems[index], (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        ((Component) this.RewardItems[index]).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
      }
    }
    if (DataManager.Instance.RoleAlliance.Id == 0U && instance.MissionSaved == (byte) 2)
      --instance.MissionSaved;
    this.OnButtonClick(this.TagControl[(int) instance.MissionSaved].Btn);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (this.ItemController == null)
      return;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    int currentTag = (int) this.ItemController.CurrentTag;
    bool flag = false;
    switch (sender.m_BtnID1)
    {
      case 0:
      case 1:
      case 2:
        flag = this.ItemController.ChangeTag((eMissionClickType) sender.m_BtnID1);
        if (flag)
        {
          this.UpdatAllianceUpGrade();
          if (!((Component) this.RewardRect).gameObject.activeSelf)
          {
            ((Component) this.RewardRect).gameObject.SetActive(true);
            break;
          }
          break;
        }
        break;
      case 3:
        flag = this.ItemController.ChangeTag((eMissionClickType) sender.m_BtnID1);
        if (flag)
        {
          this.UpdatAllianceUpGrade();
          if (((Component) this.RewardRect).gameObject.activeSelf)
          {
            ((Component) this.RewardRect).gameObject.SetActive(false);
            break;
          }
          break;
        }
        break;
      case 5:
        menu.CloseMenu();
        break;
      case 11:
        this.SelectBtn = sender;
        this.ItemController.SetSelect(sender.m_BtnID2, sender.m_BtnID4, this.Reward, this.RewardItemID, this.RewardItemCount);
        byte num1 = 0;
        int num2 = 0;
        for (int index1 = 0; index1 < this.RewardItemID.Length; ++index1)
        {
          if (this.RewardItemID[index1] == (ushort) 0)
          {
            this.UsedRewardItem[index1] = (RectTransform) null;
          }
          else
          {
            int index2;
            if (!GUIManager.Instance.IsLeadItem(DataManager.Instance.EquipTable.GetRecordByKey(this.RewardItemID[index1]).EquipKind))
            {
              index2 = (int) num1;
              ((Component) this.RewardItems[index2]).gameObject.SetActive(true);
              this.UsedRewardItem[index1] = this.RewardItems[index2];
              GUIManager.Instance.ChangeHeroItemImg((Transform) this.RewardItems[index2], eHeroOrItem.Item, this.RewardItemID[index1], (byte) 0, (byte) 0);
            }
            else
            {
              index2 = (int) num1 + 3;
              ((Component) this.RewardItems[index2]).gameObject.SetActive(true);
              this.UsedRewardItem[index1] = this.RewardItems[index2];
              GUIManager.Instance.ChangeLordEquipImg((Transform) this.RewardItems[index2], this.RewardItemID[index1], (byte) ((uint) this.ItemController.GetQuality(sender.m_BtnID2, sender.m_BtnID4) + 1U), gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
            }
            this.RewardNumStr[index2].ClearString();
            this.RewardNumStr[index2].IntToFormat((long) this.RewardItemCount[index1]);
            if (GUIManager.Instance.IsArabic)
              this.RewardNumStr[index2].AppendFormat("{0}x");
            else
              this.RewardNumStr[index2].AppendFormat("x{0}");
            this.RewardNum[index2].text = this.RewardNumStr[index2].ToString();
            this.RewardNum[index2].SetAllDirty();
            num2 |= 1 << index2;
            this.RewardNum[(int) num1++].cachedTextGenerator.Invalidate();
          }
        }
        Vector2 vector2;
        switch (num1)
        {
          case 1:
            this.UsedRewardItem[0].anchoredPosition = this.UsedRewardItem[0].anchoredPosition with
            {
              x = 1f
            };
            break;
          case 2:
            this.UsedRewardItem[0].anchoredPosition = this.UsedRewardItem[0].anchoredPosition with
            {
              x = -50.5f
            };
            this.UsedRewardItem[1].anchoredPosition = this.UsedRewardItem[1].anchoredPosition with
            {
              x = 58.5f
            };
            break;
          case 3:
            this.UsedRewardItem[0].anchoredPosition = this.UsedRewardItem[0].anchoredPosition with
            {
              x = -84f
            };
            this.UsedRewardItem[1].anchoredPosition = this.UsedRewardItem[1].anchoredPosition with
            {
              x = 1f
            };
            vector2 = this.UsedRewardItem[2].anchoredPosition with
            {
              x = 86f
            };
            this.UsedRewardItem[2].anchoredPosition = vector2;
            break;
        }
        for (int index = 0; index < this.RewardItems.Length; ++index)
        {
          if ((num2 & 1 << index) == 0)
            ((Component) this.RewardItems[index]).transform.gameObject.SetActive(false);
        }
        if (num1 == (byte) 0)
          ((Behaviour) this.RewardBk).enabled = false;
        else
          ((Behaviour) this.RewardBk).enabled = true;
        byte index3 = 0;
        for (int index4 = 0; index4 < this.Reward.Length; ++index4)
        {
          if (this.Reward[index4] != 0U)
          {
            if (this.RewardData.Length > (int) index3)
            {
              if (index4 == 0)
              {
                if (GUIManager.Instance.IsArabic)
                  ((Behaviour) this.ArabicRot).enabled = true;
                else
                  ((Behaviour) this.ArabicRot).enabled = false;
              }
              this.RewardData[(int) index3].SetReward(this.RewardIcon[index4], this.Reward[index4], this.RewardHintText[index4]);
              ++index3;
            }
            else
              break;
          }
        }
        for (int index5 = (int) index3; index5 < this.RewardData.Length; ++index5)
          this.RewardData[index5].transform.gameObject.SetActive(false);
        if (((Behaviour) this.RewardBk).enabled)
        {
          this.RewardPriceRect.anchoredPosition = this.PriceList;
          break;
        }
        vector2 = this.PriceList with
        {
          y = (float) ((int) index3 * 20 - 200)
        };
        this.RewardPriceRect.anchoredPosition = vector2;
        break;
      case 13:
        DataManager.MissionDataManager.AchievementMgr.OpenAchievementUI();
        break;
    }
    if (flag && currentTag < this.TagControl.Length)
    {
      this.TagControl[currentTag].TagAlpha.alpha = 0.0f;
      ((Graphic) this.TagControl[currentTag].Title).color = this.TagTextColor;
    }
    if (this.ItemController.CurrentTag >= (eMissionClickType) this.TagControl.Length)
      return;
    ((Graphic) this.TagControl[(int) this.ItemController.CurrentTag].Title).color = Color.white;
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    this.HintText.text = DataManager.Instance.mStringTable.GetStringByID((uint) sender.Parm1);
    this.HintRect.sizeDelta = this.HintRect.sizeDelta with
    {
      y = this.HintText.preferredHeight + 16f
    };
    sender.GetTipPosition(this.HintRect);
    Vector2 anchoredPosition = this.HintRect.anchoredPosition;
    anchoredPosition.x -= 292f;
    anchoredPosition.y -= 33f;
    this.HintRect.anchoredPosition = anchoredPosition;
    ((Component) this.HintRect).gameObject.SetActive(true);
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    ((Component) this.HintRect).gameObject.SetActive(false);
  }

  public override void OnClose()
  {
    if (this.ItemController != null)
    {
      GUIManager.Instance.MissionSaved = (byte) this.ItemController.CurrentTag;
      this.ItemController.Destroy();
    }
    for (int index = 0; index < this.TagControl.Length; ++index)
      this.TagControl[index].Destroy();
    for (int index = 0; index < this.RewardData.Length; ++index)
      this.RewardData[index].Destroy();
    for (int index = 0; index < this.RewardNumStr.Length; ++index)
      StringManager.Instance.DeSpawnString(this.RewardNumStr[index]);
    DataManager.Instance.UpdateLoadItemNotify();
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (this.ItemController == null)
      return;
    this.ItemController.UpdateItem(dataIdx, panelObjectIdx);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  private void Update()
  {
    if (this.DelayInit > (byte) 0)
    {
      --this.DelayInit;
      if (this.DelayInit != (byte) 0)
        return;
      this.Init();
    }
    else
    {
      this.ItemController.Update();
      float deltaTime = this.TimeHandle.GetDeltaTime();
      this.TagControl[(int) this.ItemController.CurrentTag].TagAlpha.alpha = (double) deltaTime <= 1.0 ? deltaTime : 2f - deltaTime;
    }
  }

  public void UpdateTagInfo(int TagIndex)
  {
    if (TagIndex >= 1)
    {
      if (((int) DataManager.MissionDataManager.MissionNotice & 1 << TagIndex) > 0)
      {
        this.TagControl[TagIndex].Notice.gameObject.SetActive(true);
        this.TagControl[TagIndex].SetNum((byte) 0);
      }
      else if (TagIndex == 2 && DataManager.Instance.RoleAlliance.Id == 0U)
      {
        this.TagControl[TagIndex].Notice.gameObject.SetActive(false);
        this.TagControl[TagIndex].SetNum((byte) 0);
      }
      else
      {
        this.TagControl[TagIndex].Notice.gameObject.SetActive(false);
        this.TagControl[TagIndex].SetNum(DataManager.MissionDataManager.AccessMissionCount[TagIndex]);
      }
    }
    else
    {
      if (TagIndex != 0)
        return;
      if (DataManager.MissionDataManager.GetRewardCount(1) > (byte) 0)
        this.TagControl[TagIndex].Notice.gameObject.SetActive(true);
      else
        this.TagControl[TagIndex].Notice.gameObject.SetActive(false);
    }
  }

  public void UpdatAllianceUpGrade()
  {
    if (this.ItemController == null)
      return;
    bool flag = false;
    if (DataManager.MissionDataManager.AllianceMissionBonusRate > (ushort) 100)
      flag = true;
    for (int index = 0; index < this.RewardData.Length; ++index)
    {
      if (this.ItemController.CurrentTag == eMissionClickType.Tag3)
      {
        this.RewardData[index].UpgradeObj.SetActive(flag);
        if (flag)
        {
          ((Graphic) this.RewardData[index].RewardText).color = new Color(0.318f, 0.89f, 0.412f);
          ((Behaviour) this.RewardData[index].textOutline).enabled = true;
        }
        else
        {
          ((Graphic) this.RewardData[index].RewardText).color = new Color(0.733f, 0.941f, 1f);
          ((Behaviour) this.RewardData[index].textOutline).enabled = false;
        }
      }
      else
      {
        this.RewardData[index].UpgradeObj.SetActive(false);
        ((Behaviour) this.RewardData[index].textOutline).enabled = false;
        ((Graphic) this.RewardData[index].RewardText).color = new Color(0.733f, 0.941f, 1f);
      }
    }
    this.UpgradeAlliancObj.SetActive(flag);
    if (!flag)
    {
      this.UpgradeTweenPosition.Reset();
      this.UpgradeTweenAlpha.Reset();
    }
    else
    {
      this.UpgradeTweenPosition.easeType = EaseType.linear;
      this.UpgradeTweenPosition.loopStyle = LoopStyle.Loop;
      this.UpgradeTweenPosition.duration = 1.2f;
      this.UpgradeTweenAlpha.easeType = EaseType.none;
      this.UpgradeTweenAlpha.loopStyle = LoopStyle.Loop;
      this.UpgradeTweenAlpha.duration = 1.2f;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 == 4 && arg2 == 0)
    {
      this.UpdatAllianceUpGrade();
      for (int TagIndex = 0; TagIndex < this.TagControl.Length; ++TagIndex)
        this.UpdateTagInfo(TagIndex);
    }
    else
    {
      switch (arg1)
      {
        case 16:
          this.UpdateTagInfo(0);
          break;
        case 32:
          if ((Object) this.SelectBtn != (Object) null)
          {
            this.OnButtonClick(this.SelectBtn);
            break;
          }
          break;
        default:
          if (arg1 > 0 && arg2 < this.TagControl.Length)
          {
            this.UpdateTagInfo(arg2);
            break;
          }
          break;
      }
    }
    if (this.ItemController == null)
      return;
    this.ItemController.Update(arg1, arg2);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_VIP:
        this.UpdateUI(4, 0);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        for (int index = 0; index < this.TextRefresh.Length; ++index)
        {
          ((Behaviour) this.TextRefresh[index]).enabled = false;
          ((Behaviour) this.TextRefresh[index]).enabled = true;
        }
        for (int index = 0; index < this.TagControl.Length; ++index)
        {
          ((Behaviour) this.TagControl[index].NumText).enabled = false;
          ((Behaviour) this.TagControl[index].NumText).enabled = true;
          ((Behaviour) this.TagControl[index].Title).enabled = false;
          ((Behaviour) this.TagControl[index].Title).enabled = true;
        }
        for (int index = 0; index < this.RewardNum.Length; ++index)
        {
          ((Behaviour) this.RewardNum[index]).enabled = false;
          ((Behaviour) this.RewardNum[index]).enabled = true;
        }
        if (((Behaviour) this.HintText).enabled)
        {
          ((Behaviour) this.HintText).enabled = false;
          ((Behaviour) this.HintText).enabled = true;
        }
        if (this.ItemController == null)
          break;
        for (int index = 0; index < this.RewardHIBtn.Length; ++index)
        {
          if (((Component) this.RewardHIBtn[index]).gameObject.activeSelf)
            this.RewardHIBtn[index].Refresh_FontTexture();
        }
        for (int index = 0; index < this.RewardData.Length; ++index)
        {
          if (this.RewardData[index].transform.gameObject.activeSelf)
          {
            ((Behaviour) this.RewardData[index].RewardText).enabled = false;
            ((Behaviour) this.RewardData[index].RewardText).enabled = true;
          }
        }
        this.ItemController.TextRefresh();
        break;
      default:
        if (networkNews != NetworkNews.Login)
          break;
        goto case NetworkNews.Refresh_VIP;
    }
  }

  private struct _TagControl
  {
    public UIButton Btn;
    public CanvasGroup TagAlpha;
    public CString NumStr;
    public UIText NumText;
    public UIText Title;
    public Transform Notice;
    public Transform Tip;

    public void Init() => this.NumStr = StringManager.Instance.SpawnString();

    public void SetNum(byte Num)
    {
      if (Num == (byte) 0)
      {
        this.Tip.gameObject.SetActive(false);
      }
      else
      {
        this.Tip.gameObject.SetActive(true);
        this.NumStr.ClearString();
        this.NumStr.IntToFormat((long) Num);
        this.NumStr.AppendFormat("{0}");
        this.NumText.text = this.NumStr.ToString();
        this.NumText.SetAllDirty();
        this.NumText.cachedTextGenerator.Invalidate();
      }
    }

    public void Destroy() => StringManager.Instance.DeSpawnString(this.NumStr);
  }

  private struct _Reward
  {
    public Transform transform;
    public Image Icon;
    public UIText RewardText;
    public CString RewardStr;
    public UIButtonHint Hint;
    private RectTransform HintRect;
    public GameObject UpgradeObj;
    public Outline textOutline;

    public _Reward(Transform trans, Material IconMat)
    {
      this.transform = trans;
      this.Icon = this.transform.GetChild(0).GetComponent<Image>();
      ((MaskableGraphic) this.Icon).material = IconMat;
      this.RewardText = this.transform.GetChild(1).GetComponent<UIText>();
      this.textOutline = this.transform.GetChild(1).GetComponent<Outline>();
      this.RewardStr = StringManager.Instance.SpawnString();
      this.Hint = this.transform.gameObject.AddComponent<UIButtonHint>();
      this.Hint.m_eHint = EUIButtonHint.DownUpHandler;
      this.HintRect = this.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
      this.UpgradeObj = this.transform.GetChild(2).gameObject;
    }

    public void Destroy() => StringManager.Instance.DeSpawnString(this.RewardStr);

    public void SetReward(Sprite sprite, uint Num, ushort HintID)
    {
      this.Hint.Parm1 = HintID;
      this.transform.gameObject.SetActive(true);
      this.RewardStr.ClearString();
      this.RewardStr.IntToFormat((long) Num, bNumber: true);
      if (GUIManager.Instance.IsArabic)
        this.RewardStr.AppendFormat("{0} +");
      else
        this.RewardStr.AppendFormat("+ {0}");
      this.Icon.sprite = sprite;
      this.Icon.SetNativeSize();
      this.RewardText.text = this.RewardStr.ToString();
      this.RewardText.SetAllDirty();
      this.RewardText.cachedTextGenerator.Invalidate();
      this.RewardText.cachedTextGeneratorForLayout.Invalidate();
      this.HintRect.offsetMax = this.HintRect.offsetMax with
      {
        x = 14f + this.RewardText.preferredWidth
      };
    }
  }

  private enum UIControl
  {
    Background,
    Google,
    Title,
    Tag,
    VIP,
    Reward,
    MissionList,
    Item,
    Affair,
    Recommand,
    Complete,
    Close,
    Hint,
  }
}
