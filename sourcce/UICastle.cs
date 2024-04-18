// Decompiled with JetBrains decompiler
// Type: UICastle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UICastle : 
  GUIWindow,
  IBuildingWindowType,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler
{
  private Transform ThisTransform;
  private Transform ScrollCont;
  private ScrollPanel CastleScroll;
  public BuildingWindow baseBuild;
  private int ManorID;
  private int RoleNameSize;
  private DataManager DM;
  private GUIManager GUIM;
  private byte DelayInit = 3;
  private List<float> ItemsHeight = new List<float>();
  private UISpritesArray RankSpriteArr;
  private UISpritesArray CastleInfoArr;
  private UICastle.ResourceInfo[] ManorResource = new UICastle.ResourceInfo[5];
  private CString VipStr;
  private CString RoleNameStr;
  private UIText RoleName;
  private UIText HintText;
  private Text VipText;
  private RectTransform RectChangeName;
  private RectTransform RectHint;
  private float RectChangeNameLeft;
  private long[] ResourceCapacity = new long[5];
  private UICastle._ItemData[] CastleItem;
  private float UpdateRate = 1f;

  private void Start()
  {
    this.baseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    RoleBuildingData roleBuildingData = this.GUIM.BuildingData.AllBuildsData[this.ManorID];
    this.baseBuild.InitBuildingWindow((byte) roleBuildingData.BuildID, (ushort) this.ManorID, (byte) 2, roleBuildingData.Level);
    this.baseBuild.baseTransform.SetAsFirstSibling();
    NewbieManager.CheckNewbie((object) this);
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.ThisTransform = this.transform.GetChild(0);
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    Font ttfFont = this.GUIM.GetTTFFont();
    this.ManorID = arg1;
    this.RankSpriteArr = this.ThisTransform.GetComponent<UISpritesArray>();
    this.ScrollCont = this.ThisTransform.GetChild(1);
    this.CastleScroll = this.ScrollCont.GetChild(0).GetComponent<ScrollPanel>();
    this.CastleInfoArr = this.ScrollCont.GetComponent<UISpritesArray>();
    this.RectHint = this.ThisTransform.GetChild(3).GetComponent<RectTransform>();
    this.HintText = ((Transform) this.RectHint).GetChild(0).GetComponent<UIText>();
    this.HintText.font = ttfFont;
    if (this.GUIM.IsArabic)
      this.ThisTransform.GetChild(0).GetChild(1).localScale = new Vector3(-1.2f, 1.2f, 1.2f);
    Image component1 = this.ThisTransform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
    if (this.DM.RoleAlliance.Id == 0U)
    {
      ((Component) component1).transform.parent.gameObject.SetActive(false);
    }
    else
    {
      UIButtonHint uiButtonHint = this.ThisTransform.GetChild(0).GetChild(1).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint.ControlFadeOut = ((Component) this.RectHint).gameObject;
      uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint.m_Handler = (MonoBehaviour) this;
      uiButtonHint.Parm1 = (ushort) 7346;
      component1.sprite = this.RankSpriteArr.GetSprite((int) (this.DM.RoleAlliance.Rank - (byte) 1));
    }
    UIButtonHint uiButtonHint1 = this.ThisTransform.GetChild(0).GetChild(2).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.ControlFadeOut = ((Component) this.RectHint).gameObject;
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    uiButtonHint1.Parm1 = (ushort) 7345;
    this.VipStr = StringManager.Instance.SpawnString();
    this.VipText = this.ThisTransform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>();
    this.VipText.font = ttfFont;
    this.VipStr.ClearString();
    this.VipStr.IntToFormat((long) this.DM.RoleAttr.VIPLevel);
    this.VipStr.AppendFormat("{0}");
    this.VipText.text = this.VipStr.ToString();
    ((Graphic) this.VipText).SetAllDirty();
    this.VipText.cachedTextGenerator.Invalidate();
    if (this.GUIM.IsArabic)
      this.ThisTransform.GetChild(0).GetChild(2).localScale = new Vector3(-1f, 1f, 1f);
    this.RoleNameStr = StringManager.Instance.SpawnString(100);
    this.RoleName = this.ThisTransform.GetChild(0).GetChild(3).GetComponent<UIText>();
    this.RoleName.font = ttfFont;
    this.RoleName.SetCheckArabic(true);
    this.RectChangeName = this.ThisTransform.GetChild(0).GetChild(4).GetComponent<RectTransform>();
    UIButton component2 = this.ThisTransform.GetChild(0).GetChild(4).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 0;
    this.RoleNameSize = this.RoleName.fontSize;
    this.RectChangeNameLeft = ((Graphic) this.RoleName).rectTransform.anchoredPosition.x;
    this.UpdateNamePos();
    Transform child = this.ThisTransform.GetChild(2);
    for (int index = 0; index < 5; ++index)
      child.GetChild(1 + index).GetComponent<UIText>().font = ttfFont;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public void UpdateNamePos()
  {
    this.RoleNameStr.ClearString();
    CString Nickname = StringManager.Instance.StaticString1024();
    if (this.DM.RoleAttr.NickName.Length == 0)
      Nickname.Append(this.DM.mStringTable.GetStringByID(9096U));
    else
      Nickname.Append(this.DM.RoleAttr.NickName);
    GameConstants.FormatRoleName(this.RoleNameStr, this.DM.RoleAttr.Name, Nickname: Nickname, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0, NickColor: "<color=#4CF5F5>");
    this.RoleName.text = this.RoleNameStr.ToString();
    this.RoleName.SetAllDirty();
    this.RoleName.cachedTextGenerator.Invalidate();
    this.RoleName.cachedTextGeneratorForLayout.Invalidate();
    this.RoleName.fontSize = this.RoleNameSize;
    this.RoleName.fontSize = this.GetFontSize();
    Vector2 anchoredPosition = this.RectChangeName.anchoredPosition with
    {
      x = (float) ((double) ((Graphic) this.RoleName).rectTransform.anchoredPosition.x + (double) this.RoleName.preferredWidth + 27.0)
    };
    if ((double) ((Transform) ((Graphic) this.RoleName).rectTransform).localScale.x < 0.0)
      anchoredPosition.x -= ((Graphic) this.RoleName).rectTransform.sizeDelta.x;
    this.RectChangeName.anchoredPosition = anchoredPosition;
  }

  private int GetFontSize()
  {
    if ((double) this.RectChangeNameLeft + (double) this.RoleName.preferredWidth + 27.0 > 393.0 && this.RoleName.fontSize > 8)
    {
      --this.RoleName.fontSize;
      ((Graphic) this.RoleName).SetLayoutDirty();
      this.RoleName.cachedTextGeneratorForLayout.Invalidate();
      this.GetFontSize();
    }
    return this.RoleName.fontSize;
  }

  public override void OnClose()
  {
    if ((UnityEngine.Object) this.baseBuild != (UnityEngine.Object) null)
      this.baseBuild.DestroyBuildingWindow();
    StringManager.Instance.DeSpawnString(this.VipStr);
    StringManager.Instance.DeSpawnString(this.RoleNameStr);
    if (this.CastleItem != null)
    {
      for (int index1 = 0; index1 < this.CastleItem.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.CastleItem[index1].TitleStr.Length; ++index2)
          StringManager.Instance.DeSpawnString(this.CastleItem[index1].TitleStr[index2]);
      }
    }
    this.GUIM.BuildingData.castleSkin.ClearCastleSkinUI();
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    this.HintText.text = DataManager.Instance.mStringTable.GetStringByID((uint) sender.Parm1);
    this.RectHint.sizeDelta = this.RectHint.sizeDelta with
    {
      y = this.HintText.preferredHeight + 16f
    };
    sender.GetTipPosition(this.RectHint);
    Vector2 anchoredPosition = this.RectHint.anchoredPosition;
    anchoredPosition.x += 20f;
    anchoredPosition.y -= 2f;
    this.RectHint.anchoredPosition = anchoredPosition;
    ((Component) this.RectHint).gameObject.SetActive(true);
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    ((Component) this.RectHint).gameObject.SetActive(false);
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
      if ((double) this.UpdateRate < 0.0)
      {
        for (int index = 0; index < this.CastleItem.Length; ++index)
        {
          if (this.CastleItem[index].dataIdx == 0)
            this.UpdateWallInfo(ref this.CastleItem[index]);
          else if (this.CastleItem[index].dataIdx == 1)
            this.UpdateArmy(ref this.CastleItem[index]);
        }
        for (int panelObjectIdx = 0; panelObjectIdx < this.CastleItem.Length; ++panelObjectIdx)
        {
          if (this.CastleItem[panelObjectIdx].transform.gameObject.activeSelf && this.CastleItem[panelObjectIdx].dataIdx >= 2)
            this.UpDateRowItem(this.CastleItem[panelObjectIdx].transform.gameObject, this.CastleItem[panelObjectIdx].dataIdx, panelObjectIdx, 0);
        }
        this.UpdateRate = 1f;
      }
      this.UpdateRate -= Time.deltaTime;
    }
  }

  private void Init()
  {
    for (int index = 0; index < this.ManorResource.Length; ++index)
    {
      ResourceType Type = (ResourceType) index;
      this.ManorResource[index] = Type != ResourceType.Grain ? new UICastle.ResourceInfo(Type) : (UICastle.ResourceInfo) new UICastle.GrainResourceInfo(Type);
      this.ManorResource[index].UpdateResourceInfo();
    }
    this.ThisTransform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
    this.GUIM.InitianHeroItemImg(this.ThisTransform.GetChild(0).GetChild(0).GetChild(0), eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.UpdateBagResourceCapacity();
    byte _PanelObjectsCount = 7;
    for (byte index = 0; (int) index < (int) _PanelObjectsCount; ++index)
    {
      if (index == (byte) 2)
        this.ItemsHeight.Add(132f);
      else
        this.ItemsHeight.Add(95f);
    }
    this.CastleItem = new UICastle._ItemData[(int) _PanelObjectsCount];
    this.CastleScroll.IntiScrollPanel(272f, 0.0f, 6f, this.ItemsHeight, (int) _PanelObjectsCount, (IUpDateScrollPanel) this);
    this.CastleItem[2].SetSize((byte) 1);
    this.CastleScroll.AddNewDataHeight(this.ItemsHeight);
    this.ScrollCont.gameObject.SetActive(true);
    this.TextRefresh();
  }

  private void UpdateBagResourceCapacity()
  {
    if (this.DelayInit > (byte) 0)
      return;
    DataManager instance = DataManager.Instance;
    instance.SortCurItemDataForBag();
    Array.Clear((Array) this.ResourceCapacity, 0, this.ResourceCapacity.Length);
    for (ushort index = instance.sortItemDataStart[10]; (int) index < (int) instance.sortItemDataStart[10] + (int) instance.sortItemDataCount[10]; ++index)
    {
      long curItemQuantity = (long) instance.GetCurItemQuantity(instance.sortItemData[(int) index], (byte) 0);
      if (curItemQuantity != 0L)
      {
        Equip recordByKey = instance.EquipTable.GetRecordByKey(instance.sortItemData[(int) index]);
        if (recordByKey.PropertiesInfo[0].Propertieskey >= (ushort) 1 && recordByKey.PropertiesInfo[0].Propertieskey <= (ushort) 5)
        {
          this.ResourceCapacity[(int) recordByKey.PropertiesInfo[0].Propertieskey - 1] += (long) ((int) recordByKey.PropertiesInfo[1].Propertieskey * (int) recordByKey.PropertiesInfo[1].PropertiesValue) * curItemQuantity;
          if (this.ResourceCapacity[(int) recordByKey.PropertiesInfo[0].Propertieskey - 1] > 999000000000L)
            this.ResourceCapacity[(int) recordByKey.PropertiesInfo[0].Propertieskey - 1] = 999000000000L;
        }
      }
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (this.DelayInit > (byte) 0)
      return;
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        break;
      case NetworkNews.Refresh:
        break;
      case NetworkNews.Refresh_Attr:
        this.UpdateNamePos();
        break;
      case NetworkNews.Refresh_Item:
        this.UpdateBagResourceCapacity();
        break;
      case NetworkNews.Refresh_Resource:
label_7:
        for (int index = 0; index < this.ManorResource.Length; ++index)
          this.ManorResource[index].UpdateResourceInfo();
        this.VipStr.ClearString();
        this.VipStr.IntToFormat((long) this.DM.RoleAttr.VIPLevel);
        this.VipStr.AppendFormat("{0}");
        this.VipText.text = this.VipStr.ToString();
        ((Graphic) this.VipText).SetAllDirty();
        this.VipText.cachedTextGenerator.Invalidate();
        if (meg[0] != (byte) 26)
          break;
        this.baseBuild.MyUpdate((byte) 0);
        break;
      default:
        switch (networkNews - (byte) 20)
        {
          case NetworkNews.Login:
            (this.ManorResource[0] as UICastle.GrainResourceInfo).UpdateResourceInfo();
            return;
          case NetworkNews.Refresh:
            this.baseBuild.MyUpdate(meg[1]);
            return;
          default:
            if (networkNews != NetworkNews.Refresh_AttribEffectVal)
            {
              if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
                return;
              this.baseBuild.Refresh_FontTexture();
              this.TextRefresh();
              return;
            }
            goto label_7;
        }
    }
  }

  private void TextRefresh()
  {
    ((Behaviour) this.VipText).enabled = false;
    ((Behaviour) this.VipText).enabled = true;
    ((Behaviour) this.RoleName).enabled = false;
    ((Behaviour) this.RoleName).enabled = true;
    ((Behaviour) this.HintText).enabled = false;
    ((Behaviour) this.HintText).enabled = true;
    for (int index = 0; index < this.CastleItem.Length; ++index)
      this.CastleItem[index].TextRefresh();
  }

  public void OnButtonClick(UIButton sender)
  {
    switch ((UICastle.ClickType) sender.m_BtnID1)
    {
      case UICastle.ClickType.ChangeName:
        if (NewbieManager.CheckRename(false))
          break;
        GUIManager.Instance.OpenMenu(EGUIWindow.UI_Name, bSecWindow: true);
        break;
      case UICastle.ClickType.Next:
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_DevelopmentDetails, sender.m_BtnID2 + 2);
        break;
    }
  }

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Upgrade)
    {
      this.ThisTransform.gameObject.SetActive(false);
    }
    else
    {
      if (buildType != e_BuildType.Normal)
        return;
      this.ThisTransform.gameObject.SetActive(true);
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((UnityEngine.Object) this.CastleItem[panelObjectIdx].Icon == (UnityEngine.Object) null)
    {
      Transform transform = item.transform;
      this.CastleItem[panelObjectIdx].transform = transform;
      this.CastleItem[panelObjectIdx].PanelItem = transform.GetComponent<ScrollPanelItem>();
      this.CastleItem[panelObjectIdx].FrameRect = transform.GetComponent<RectTransform>();
      this.CastleItem[panelObjectIdx].Icon = transform.GetChild(0).GetComponent<Image>();
      this.CastleItem[panelObjectIdx].Title1 = transform.GetChild(1).GetComponent<UIText>();
      this.CastleItem[panelObjectIdx].Title2 = transform.GetChild(2).GetComponent<UIText>();
      this.CastleItem[panelObjectIdx].Title3 = transform.GetChild(3).GetComponent<UIText>();
      this.CastleItem[panelObjectIdx].Title4 = transform.GetChild(4).GetComponent<UIText>();
      this.CastleItem[panelObjectIdx].Title5 = transform.GetChild(5).GetComponent<UIText>();
      this.CastleItem[panelObjectIdx].NextBtn = transform.GetChild(6).GetComponent<UIButton>();
      this.CastleItem[panelObjectIdx].NextBtn.m_Handler = (IUIButtonClickHandler) this;
      this.CastleItem[panelObjectIdx].NextBtn.m_BtnID1 = 1;
      this.CastleItem[panelObjectIdx].NextBtn.m_BtnID2 = dataIdx;
      this.CastleItem[panelObjectIdx].TitleStr = new CString[5];
      for (int index = 0; index < this.CastleItem[panelObjectIdx].TitleStr.Length; ++index)
        this.CastleItem[panelObjectIdx].TitleStr[index] = StringManager.Instance.SpawnString(100);
    }
    else
    {
      this.CastleItem[panelObjectIdx].dataIdx = dataIdx;
      switch (dataIdx)
      {
        case 0:
          this.UpdateWallInfo(ref this.CastleItem[panelObjectIdx]);
          ((Component) this.CastleItem[panelObjectIdx].NextBtn).gameObject.SetActive(true);
          this.CastleItem[panelObjectIdx].PanelItem.transition = (Selectable.Transition) 1;
          break;
        case 1:
          this.UpdateArmy(ref this.CastleItem[panelObjectIdx]);
          ((Component) this.CastleItem[panelObjectIdx].NextBtn).gameObject.SetActive(true);
          this.CastleItem[panelObjectIdx].PanelItem.transition = (Selectable.Transition) 1;
          break;
        default:
          this.UpdateResource(ref this.CastleItem[panelObjectIdx], dataIdx - 2);
          ((Component) this.CastleItem[panelObjectIdx].NextBtn).gameObject.SetActive(false);
          this.CastleItem[panelObjectIdx].PanelItem.transition = (Selectable.Transition) 0;
          break;
      }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    for (int index = 0; index < this.CastleItem.Length; ++index)
    {
      if (((Component) this.CastleItem[index].NextBtn).gameObject.activeSelf && this.CastleItem[index].dataIdx == dataIndex)
      {
        AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
        this.OnButtonClick(this.CastleItem[index].NextBtn);
        break;
      }
    }
  }

  private void UpdateWallInfo(ref UICastle._ItemData itemData)
  {
    CString tmpS1 = StringManager.Instance.StaticString1024();
    CString tmpS2 = StringManager.Instance.StaticString1024();
    tmpS1.Append("<color=#cbbd7bff>");
    tmpS2.Append("</color>");
    itemData.Icon.sprite = this.CastleInfoArr.GetSprite(0);
    itemData.Icon.SetNativeSize();
    itemData.TitleStr[0].ClearString();
    itemData.TitleStr[0].StringToFormat(tmpS1);
    itemData.TitleStr[0].StringToFormat(this.DM.mStringTable.GetStringByID(4928U));
    itemData.TitleStr[0].StringToFormat(tmpS2);
    itemData.TitleStr[0].IntToFormat((long) this.DM.m_WallRepairNowValue, bNumber: true);
    itemData.TitleStr[0].IntToFormat((long) this.DM.m_WallRepairMaxValue, bNumber: true);
    itemData.TitleStr[0].AppendFormat("{0}{1}{2}{3} / {4}");
    itemData.Title1.text = itemData.TitleStr[0].ToString();
    itemData.Title1.SetAllDirty();
    itemData.Title1.cachedTextGenerator.Invalidate();
    uint x1 = 0;
    RoleBuildingData buildData = this.GUIM.BuildingData.GetBuildData((ushort) 12, (ushort) 0);
    if (this.GUIM.BuildingData.GetBuildNumByID((ushort) 12) > (byte) 0)
      x1 = this.GUIM.BuildingData.GetBuildLevelRequestData(buildData.BuildID, buildData.Level).Value1;
    itemData.TitleStr[1].ClearString();
    itemData.TitleStr[1].StringToFormat(tmpS1);
    itemData.TitleStr[1].StringToFormat(this.DM.mStringTable.GetStringByID(4929U));
    itemData.TitleStr[1].StringToFormat(tmpS2);
    itemData.TitleStr[1].IntToFormat((long) this.DM.TrapTotal, bNumber: true);
    itemData.TitleStr[1].IntToFormat((long) x1, bNumber: true);
    itemData.TitleStr[1].AppendFormat("{0}{1}{2}{3} / {4}");
    itemData.Title2.text = itemData.TitleStr[1].ToString();
    itemData.Title2.SetAllDirty();
    itemData.Title2.cachedTextGenerator.Invalidate();
    itemData.TitleStr[2].ClearString();
    itemData.TitleStr[2].StringToFormat(tmpS1);
    itemData.TitleStr[2].StringToFormat(this.DM.mStringTable.GetStringByID(4930U));
    itemData.TitleStr[2].StringToFormat(tmpS2);
    int maxDefenders = this.DM.GetMaxDefenders();
    int x2 = 0;
    for (int index = 0; index < this.DM.GetMaxDefenders(); ++index)
    {
      if (this.DM.m_DefendersID[index] > (ushort) 0)
        ++x2;
    }
    itemData.TitleStr[2].IntToFormat((long) x2);
    itemData.TitleStr[2].IntToFormat((long) maxDefenders);
    itemData.TitleStr[2].AppendFormat("{0}{1}{2}{3} / {4}");
    itemData.Title3.text = itemData.TitleStr[2].ToString();
    itemData.Title3.SetAllDirty();
    itemData.Title3.cachedTextGenerator.Invalidate();
    itemData.TitleStr[3].ClearString();
    itemData.TitleStr[3].StringToFormat(tmpS1);
    itemData.TitleStr[3].StringToFormat(this.DM.mStringTable.GetStringByID(4931U));
    itemData.TitleStr[3].StringToFormat(tmpS2);
    itemData.TitleStr[3].IntToFormat((long) this.DM.TrapHospitalTotal, bNumber: true);
    itemData.TitleStr[3].IntToFormat((long) x1, bNumber: true);
    itemData.TitleStr[3].AppendFormat("{0}{1}{2}{3} / {4}");
    itemData.Title4.text = itemData.TitleStr[3].ToString();
    itemData.Title4.SetAllDirty();
    itemData.Title4.cachedTextGenerator.Invalidate();
  }

  private void UpdateArmy(ref UICastle._ItemData itemData)
  {
    CString tmpS1 = StringManager.Instance.StaticString1024();
    CString tmpS2 = StringManager.Instance.StaticString1024();
    tmpS1.Append("<color=#cbbd7bff>");
    tmpS2.Append("</color>");
    itemData.Icon.sprite = this.CastleInfoArr.GetSprite(1);
    itemData.Icon.SetNativeSize();
    itemData.TitleStr[0].ClearString();
    itemData.TitleStr[0].StringToFormat(tmpS1);
    itemData.TitleStr[0].StringToFormat(this.DM.mStringTable.GetStringByID(4943U));
    itemData.TitleStr[0].StringToFormat(tmpS2);
    itemData.TitleStr[0].IntToFormat(this.DM.SoldierTotal + (long) this.DM.AttribVal.TotalOuterSoldier + (long) this.DM.AttribVal.TotalDugoutSoldier, bNumber: true);
    itemData.TitleStr[0].AppendFormat("{0}{1}{2}{3}");
    itemData.Title1.text = itemData.TitleStr[0].ToString();
    itemData.Title1.SetAllDirty();
    itemData.Title1.cachedTextGenerator.Invalidate();
    itemData.TitleStr[1].ClearString();
    itemData.TitleStr[1].StringToFormat(tmpS1);
    itemData.TitleStr[1].StringToFormat(this.DM.mStringTable.GetStringByID(4941U));
    itemData.TitleStr[1].StringToFormat(tmpS2);
    itemData.TitleStr[1].IntToFormat((long) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_BASE_TROOP_AMOUNT), bNumber: true);
    itemData.TitleStr[1].AppendFormat("{0}{1}{2}{3}");
    itemData.Title2.text = itemData.TitleStr[1].ToString();
    itemData.Title2.SetAllDirty();
    itemData.Title2.cachedTextGenerator.Invalidate();
    itemData.TitleStr[2].ClearString();
    itemData.TitleStr[2].StringToFormat(tmpS1);
    itemData.TitleStr[2].StringToFormat(this.DM.mStringTable.GetStringByID(4940U));
    itemData.TitleStr[2].StringToFormat(tmpS2);
    itemData.TitleStr[2].IntToFormat((long) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM), bNumber: true);
    itemData.TitleStr[2].AppendFormat("{0}{1}{2}{3}");
    itemData.Title3.text = itemData.TitleStr[2].ToString();
    itemData.Title3.SetAllDirty();
    itemData.Title3.cachedTextGenerator.Invalidate();
    itemData.TitleStr[3].ClearString();
    itemData.TitleStr[3].StringToFormat(tmpS1);
    itemData.TitleStr[3].StringToFormat(this.DM.mStringTable.GetStringByID(4942U));
    itemData.TitleStr[3].StringToFormat(tmpS2);
    itemData.TitleStr[3].IntToFormat((long) this.DM.curHeroData.Count, bNumber: true);
    itemData.TitleStr[3].AppendFormat("{0}{1}{2}{3}");
    itemData.Title4.text = itemData.TitleStr[3].ToString();
    itemData.Title4.SetAllDirty();
    itemData.Title4.cachedTextGenerator.Invalidate();
  }

  private void UpdateGrain(ref UICastle._ItemData itemData)
  {
    UICastle.GrainResourceInfo grainResourceInfo = this.ManorResource[0] as UICastle.GrainResourceInfo;
    CString tmpS1 = StringManager.Instance.StaticString1024();
    CString tmpS2 = StringManager.Instance.StaticString1024();
    tmpS1.Append("<color=#cbbd7bff>");
    tmpS2.Append("</color>");
    itemData.Icon.sprite = this.CastleInfoArr.GetSprite(2);
    itemData.Icon.SetNativeSize();
    itemData.TitleStr[0].ClearString();
    itemData.TitleStr[0].StringToFormat(tmpS1);
    itemData.TitleStr[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint) grainResourceInfo.Title1));
    itemData.TitleStr[0].StringToFormat(tmpS2);
    itemData.TitleStr[0].IntToFormat((long) grainResourceInfo.Stock, bNumber: true);
    itemData.TitleStr[0].AppendFormat("{0}{1}{2}{3}");
    itemData.Title1.text = itemData.TitleStr[0].ToString();
    itemData.Title1.SetAllDirty();
    itemData.Title1.cachedTextGenerator.Invalidate();
    itemData.TitleStr[1].ClearString();
    itemData.TitleStr[1].StringToFormat(tmpS1);
    itemData.TitleStr[1].StringToFormat(this.DM.mStringTable.GetStringByID((uint) grainResourceInfo.Title5));
    itemData.TitleStr[1].StringToFormat(tmpS2);
    if (grainResourceInfo.Consume == 0L)
      itemData.TitleStr[1].StringToFormat("<color=#ffffffff>");
    else
      itemData.TitleStr[1].StringToFormat("<color=#ff6e7eff>");
    itemData.TitleStr[1].IntToFormat(grainResourceInfo.Consume * -1L, bNumber: true);
    itemData.TitleStr[1].StringToFormat("</color>");
    itemData.TitleStr[1].AppendFormat("{0}{1}{2}{3}{4}{5}");
    itemData.Title5.text = itemData.TitleStr[1].ToString();
    itemData.Title5.SetAllDirty();
    itemData.Title5.cachedTextGenerator.Invalidate();
    itemData.TitleStr[2].ClearString();
    itemData.TitleStr[2].StringToFormat(tmpS1);
    itemData.TitleStr[2].StringToFormat(this.DM.mStringTable.GetStringByID((uint) grainResourceInfo.Title2));
    itemData.TitleStr[2].StringToFormat(tmpS2);
    itemData.TitleStr[2].IntToFormat(grainResourceInfo.ProductPerHour, bNumber: true);
    itemData.TitleStr[2].AppendFormat("{0}{1}{2}{3}");
    itemData.Title3.text = itemData.TitleStr[2].ToString();
    itemData.Title3.SetAllDirty();
    itemData.Title3.cachedTextGenerator.Invalidate();
    itemData.TitleStr[3].ClearString();
    itemData.TitleStr[3].StringToFormat(tmpS1);
    itemData.TitleStr[3].StringToFormat(this.DM.mStringTable.GetStringByID((uint) grainResourceInfo.Title3));
    itemData.TitleStr[3].StringToFormat(tmpS2);
    itemData.TitleStr[3].IntToFormat((long) grainResourceInfo.Capacity, bNumber: true);
    itemData.TitleStr[3].AppendFormat("{0}{1}{2}{3}");
    itemData.Title2.text = itemData.TitleStr[3].ToString();
    itemData.Title2.SetAllDirty();
    itemData.Title2.cachedTextGenerator.Invalidate();
    itemData.TitleStr[4].ClearString();
    if (this.ResourceCapacity[0] >= 1000000000L)
    {
      CString cstring = StringManager.Instance.StaticString1024();
      this.FormatResourceValue(cstring, this.ResourceCapacity[0]);
      itemData.TitleStr[4].StringToFormat(tmpS1);
      itemData.TitleStr[4].StringToFormat(this.DM.mStringTable.GetStringByID((uint) grainResourceInfo.Title4));
      itemData.TitleStr[4].StringToFormat(tmpS2);
      itemData.TitleStr[4].StringToFormat(cstring);
    }
    else
    {
      itemData.TitleStr[4].StringToFormat(tmpS1);
      itemData.TitleStr[4].StringToFormat(this.DM.mStringTable.GetStringByID((uint) grainResourceInfo.Title4));
      itemData.TitleStr[4].StringToFormat(tmpS2);
      itemData.TitleStr[4].IntToFormat(this.ResourceCapacity[0], bNumber: true);
    }
    itemData.TitleStr[4].AppendFormat("{0}{1}{2}{3}");
    itemData.Title4.text = itemData.TitleStr[4].ToString();
    itemData.Title4.SetAllDirty();
    itemData.Title4.cachedTextGenerator.Invalidate();
  }

  private void UpdateResource(ref UICastle._ItemData itemData, int resIndex)
  {
    if (resIndex == 0)
    {
      this.UpdateGrain(ref itemData);
    }
    else
    {
      CString tmpS1 = StringManager.Instance.StaticString1024();
      CString tmpS2 = StringManager.Instance.StaticString1024();
      tmpS1.Append("<color=#cbbd7bff>");
      tmpS2.Append("</color>");
      itemData.Icon.sprite = this.CastleInfoArr.GetSprite(2 + resIndex);
      itemData.Icon.SetNativeSize();
      itemData.TitleStr[0].ClearString();
      itemData.TitleStr[0].StringToFormat(tmpS1);
      itemData.TitleStr[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.ManorResource[resIndex].Title1));
      itemData.TitleStr[0].StringToFormat(tmpS2);
      itemData.TitleStr[0].IntToFormat((long) this.ManorResource[resIndex].Stock, bNumber: true);
      itemData.TitleStr[0].AppendFormat("{0}{1}{2}{3}");
      itemData.Title1.text = itemData.TitleStr[0].ToString();
      itemData.Title1.SetAllDirty();
      itemData.Title1.cachedTextGenerator.Invalidate();
      itemData.TitleStr[1].ClearString();
      itemData.TitleStr[1].StringToFormat(tmpS1);
      itemData.TitleStr[1].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.ManorResource[resIndex].Title2));
      itemData.TitleStr[1].StringToFormat(tmpS2);
      itemData.TitleStr[1].IntToFormat(this.ManorResource[resIndex].ProductPerHour, bNumber: true);
      itemData.TitleStr[1].AppendFormat("{0}{1}{2}{3}");
      itemData.Title3.text = itemData.TitleStr[1].ToString();
      itemData.Title3.SetAllDirty();
      itemData.Title3.cachedTextGenerator.Invalidate();
      itemData.TitleStr[2].ClearString();
      itemData.TitleStr[2].StringToFormat(tmpS1);
      itemData.TitleStr[2].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.ManorResource[resIndex].Title3));
      itemData.TitleStr[2].StringToFormat(tmpS2);
      itemData.TitleStr[2].IntToFormat((long) this.ManorResource[resIndex].Capacity, bNumber: true);
      itemData.TitleStr[2].AppendFormat("{0}{1}{2}{3}");
      itemData.Title2.text = itemData.TitleStr[2].ToString();
      itemData.Title2.SetAllDirty();
      itemData.Title2.cachedTextGenerator.Invalidate();
      itemData.TitleStr[4].ClearString();
      if (this.ResourceCapacity[resIndex] >= 1000000000L)
      {
        CString cstring = StringManager.Instance.StaticString1024();
        this.FormatResourceValue(cstring, this.ResourceCapacity[resIndex]);
        itemData.TitleStr[4].StringToFormat(tmpS1);
        itemData.TitleStr[4].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.ManorResource[resIndex].Title4));
        itemData.TitleStr[4].StringToFormat(tmpS2);
        itemData.TitleStr[4].StringToFormat(cstring);
      }
      else
      {
        itemData.TitleStr[4].StringToFormat(tmpS1);
        itemData.TitleStr[4].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.ManorResource[resIndex].Title4));
        itemData.TitleStr[4].StringToFormat(tmpS2);
        itemData.TitleStr[4].IntToFormat(this.ResourceCapacity[resIndex], bNumber: true);
      }
      itemData.TitleStr[4].AppendFormat("{0}{1}{2}{3}");
      itemData.Title4.text = itemData.TitleStr[4].ToString();
      itemData.Title4.SetAllDirty();
      itemData.Title4.cachedTextGenerator.Invalidate();
      itemData.Title5.text = string.Empty;
    }
  }

  private void FormatResourceValue(CString CStr, long value)
  {
    if (value >= 1000000000L)
    {
      CStr.FloatToFormat((float) value / 1E+09f, 2, false);
      CStr.AppendFormat("{0}B");
    }
    else if (value >= 100000000L)
    {
      CStr.IntToFormat(value / 1000000L);
      CStr.AppendFormat("{0}M");
    }
    else if (value >= 10000000L)
    {
      CStr.FloatToFormat((float) value / 1000000f, 1, false);
      CStr.AppendFormat("{0}M");
    }
    else if (value >= 1000000L)
    {
      CStr.FloatToFormat((float) value / 1000000f, 2, false);
      CStr.AppendFormat("{0}M");
    }
    else if (value >= 100000L)
    {
      CStr.IntToFormat(value / 1000L);
      CStr.AppendFormat("{0}K");
    }
    else if (value >= 10000L)
    {
      CStr.FloatToFormat((float) value / 1000f, 1, false);
      CStr.AppendFormat("{0}K");
    }
    else if (value >= 1000L)
    {
      CStr.IntToFormat(value / 1000L);
      CStr.IntToFormat(value % 1000L, 3);
      CStr.AppendFormat("{0},{1}");
    }
    else
    {
      CStr.IntToFormat(value);
      CStr.AppendFormat("{0}");
    }
  }

  private enum ClickType
  {
    ChangeName,
    Next,
  }

  private enum UIControl
  {
    Title,
    ScrollCont,
    ScrollItem,
    Hint,
  }

  private enum TitleControl
  {
    Hero,
    Rank,
    VIP,
    Name,
    ChangeNamebtn,
  }

  private enum ItemControl
  {
    Icon,
    Title1,
    Title2,
    Title3,
    Title4,
    Title5,
    Next,
  }

  private struct _ItemData
  {
    public Transform transform;
    public int dataIdx;
    public Image Icon;
    public ScrollPanelItem PanelItem;
    public UIText Title1;
    public UIText Title2;
    public UIText Title3;
    public UIText Title4;
    public UIText Title5;
    public UIButton NextBtn;
    public CString[] TitleStr;
    public RectTransform FrameRect;

    public void TextRefresh()
    {
      if ((UnityEngine.Object) this.Title1 == (UnityEngine.Object) null)
        return;
      ((Behaviour) this.Title1).enabled = false;
      ((Behaviour) this.Title1).enabled = true;
      ((Behaviour) this.Title2).enabled = false;
      ((Behaviour) this.Title2).enabled = true;
      ((Behaviour) this.Title3).enabled = false;
      ((Behaviour) this.Title3).enabled = true;
      ((Behaviour) this.Title4).enabled = false;
      ((Behaviour) this.Title4).enabled = true;
      ((Behaviour) this.Title5).enabled = false;
      ((Behaviour) this.Title5).enabled = true;
    }

    public void SetSize(byte Large)
    {
      if (Large > (byte) 0)
      {
        ((Graphic) this.Icon).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Icon).rectTransform.anchoredPosition.x, -70.5f);
        this.FrameRect.sizeDelta = new Vector2(this.FrameRect.sizeDelta.x, 132f);
      }
      else
      {
        ((Graphic) this.Icon).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Icon).rectTransform.anchoredPosition.x, -51f);
        this.FrameRect.sizeDelta = new Vector2(this.FrameRect.sizeDelta.x, 95f);
      }
    }
  }

  private class ResourceInfo
  {
    protected ushort BuildID;
    protected ResourceType Type;
    public uint Capacity;
    public uint Stock;
    public long ProductPerHour;
    public ushort Title1;
    public ushort Title2;
    public ushort Title3;
    public ushort Title4;

    public ResourceInfo(ResourceType Type)
    {
      this.Type = Type;
      switch (Type)
      {
        case ResourceType.Grain:
          this.Title1 = (ushort) 4944;
          this.Title2 = (ushort) 4946;
          this.Title3 = (ushort) 4947;
          this.Title4 = (ushort) 14702;
          this.BuildID = (ushort) 4;
          break;
        case ResourceType.Rock:
          this.Title1 = (ushort) 4951;
          this.Title2 = (ushort) 4952;
          this.Title3 = (ushort) 4953;
          this.Title4 = (ushort) 14703;
          this.BuildID = (ushort) 2;
          break;
        case ResourceType.Wood:
          this.Title1 = (ushort) 4948;
          this.Title2 = (ushort) 4949;
          this.Title3 = (ushort) 4950;
          this.Title4 = (ushort) 14704;
          this.BuildID = (ushort) 1;
          break;
        case ResourceType.Steel:
          this.Title1 = (ushort) 4954;
          this.Title2 = (ushort) 4955;
          this.Title3 = (ushort) 4956;
          this.Title4 = (ushort) 14705;
          this.BuildID = (ushort) 3;
          break;
        case ResourceType.Money:
          this.Title1 = (ushort) 5767;
          this.Title2 = (ushort) 5768;
          this.Title3 = (ushort) 5769;
          this.Title4 = (ushort) 14706;
          this.BuildID = (ushort) 7;
          break;
      }
    }

    public virtual void UpdateResourceInfo()
    {
      DataManager instance = DataManager.Instance;
      this.Stock = instance.Resource[(int) this.Type].Stock;
      this.Capacity = instance.Resource[(int) this.Type].Capacity;
      this.ProductPerHour = DataManager.MissionDataManager.UpdateResourceInfo(this.Type);
    }
  }

  private class GrainResourceInfo : UICastle.ResourceInfo
  {
    public long Consume;
    public ushort Title5 = 4945;

    public GrainResourceInfo(ResourceType Type)
      : base(Type)
    {
    }

    public override void UpdateResourceInfo()
    {
      base.UpdateResourceInfo();
      this.Consume = (long) DataManager.Instance.AttribVal.TotalSoldierConsume;
    }
  }
}
