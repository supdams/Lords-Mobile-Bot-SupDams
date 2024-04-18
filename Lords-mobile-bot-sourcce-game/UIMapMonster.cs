// Decompiled with JetBrains decompiler
// Type: UIMapMonster
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIMapMonster : 
  GUIWindow,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private Transform CrusadeTrans;
  private Transform MonsterTrans;
  private Transform SummonPriceTrans;
  private RectTransform PriceCont;
  private RectTransform FuncBtnRect;
  private RectTransform HintRect;
  private UIMapMonster.DegreeBar MonsterDegree;
  private UIMapMonster.DegreeBar EnergyDegree;
  private UIText UpperMessageText;
  private UIText TimesText;
  private UIText HurtText;
  private UIText LeftTimeText;
  private UIText DestTimeText;
  private UIText BoostsText;
  private UIText CrusadeText;
  private UIText CrusadeMText;
  private UIText CrusadeCostText;
  private UIText CrusadeMCostText;
  private UIText FuncBtnText;
  private UIText DownMessageText;
  private UIText MonsterNameText;
  private UIText MonsterPositionText;
  private UIText MonsterLvText;
  private UIText HintText;
  private UIButton FuncBtn;
  private UIButton CrusadeBtn;
  private UIButton CrusadeMBtn;
  private CString TimesStr;
  private CString HurtStr;
  private CString LeftTimeStr;
  private CString CrusadeMStr;
  private CString UpperMessageStr;
  private CString CrusadeCostStr;
  private CString CrusadeMCostStr;
  private CString DestTimeStr;
  private CString BoostsStr;
  private CString PositionStr;
  private CString MonsterLvStr;
  private CString ArrChatStr;
  private CString MonsterNameStr;
  private CScrollRect PriceScroll;
  private GameObject Panel2;
  private SkinnedMeshRenderer MonsterSkin;
  private NPCPoint MonsterPoint;
  private AssetBundle AB;
  private AssetBundleRequest AR;
  private ushort HeroID;
  private ushort Modle;
  private int AssetKey;
  private int MonsterMapID;
  private int ActionTimes;
  private int CountdownFlag;
  private bool bABInitial;
  private GameObject MonsterGo;
  private GameObject PriceGo;
  private GameObject SummonPriceGo;
  private float DelayShow = 0.2f;
  private List<UIText> RefreshTextArray = new List<UIText>();
  private UIMapMonster.eMonsterType MonsterType;
  private Animation MonsterAN;
  private CString MonsterAct;
  private int IdleHash;
  private float ActionTime;
  private float ActionTimeRandom;
  private AnimationUnit.AnimName[] ANIndex = new AnimationUnit.AnimName[5]
  {
    AnimationUnit.AnimName.ATTACK,
    AnimationUnit.AnimName.SKILL1,
    AnimationUnit.AnimName.SKILL2,
    AnimationUnit.AnimName.SKILL3,
    AnimationUnit.AnimName.VICTORY
  };
  private AnimationUnit.AnimName[] AnList;
  private uint maxRoleEnergy;
  private byte PetHitTimes;
  private short PassInit = 3;
  private bool bShowUI = true;
  private UISummonMonster._TextUnderLine PriceTitleText;

  void IUIHIBtnClickHandler.OnHIButtonClick(UIHIBtn sender)
  {
    if (sender.m_BtnID2 == 0)
      return;
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_OpenBox, 1, sender.m_BtnID2);
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.MonsterMapID = arg1;
    this.CountdownFlag = arg2;
    DataManager instance = DataManager.Instance;
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    Transform child = this.transform.GetChild(0);
    this.Panel2 = child.gameObject;
    if (arg2 == 1)
      this.DelayShow = 0.0f;
    this.maxRoleEnergy = instance.GetMaxMonsterPoint();
    this.TimesStr = StringManager.Instance.SpawnString();
    this.HurtStr = StringManager.Instance.SpawnString();
    this.LeftTimeStr = StringManager.Instance.SpawnString();
    this.CrusadeMStr = StringManager.Instance.SpawnString();
    this.UpperMessageStr = StringManager.Instance.SpawnString(100);
    this.CrusadeCostStr = StringManager.Instance.SpawnString();
    this.CrusadeMCostStr = StringManager.Instance.SpawnString();
    this.DestTimeStr = StringManager.Instance.SpawnString();
    this.BoostsStr = StringManager.Instance.SpawnString();
    this.PositionStr = StringManager.Instance.SpawnString();
    this.MonsterLvStr = StringManager.Instance.SpawnString();
    this.ArrChatStr = StringManager.Instance.SpawnString();
    this.MonsterNameStr = StringManager.Instance.SpawnString();
    this.MonsterNameText = child.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.MonsterNameText.font = ttfFont;
    this.AddRefreshText(this.MonsterNameText);
    this.MonsterPositionText = child.GetChild(7).GetChild(4).GetComponent<UIText>();
    this.MonsterPositionText.font = ttfFont;
    this.AddRefreshText(this.MonsterPositionText);
    this.MonsterLvText = child.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
    this.MonsterLvText.font = ttfFont;
    this.AddRefreshText(this.MonsterLvText);
    this.MonsterDegree.Init(child.GetChild(0).GetChild(1), (ushort) 274);
    this.AddRefreshText(this.MonsterDegree.TitleText);
    if (GUIManager.Instance.bOpenOnIPhoneX)
      ((Behaviour) child.GetChild(15).GetComponent<CustomImage>()).enabled = false;
    else
      child.GetChild(15).GetComponent<CustomImage>().hander = (UILoadImageHander) GUIManager.Instance.m_ItemInfo;
    child.GetChild(15).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) GUIManager.Instance.m_ItemInfo;
    this.MonsterTrans = child.GetChild(3);
    UIButton component1 = child.GetChild(1).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 0;
    if (GUIManager.Instance.IsArabic)
      ((Component) component1).transform.localScale = new Vector3(-1f, 1f, 1f);
    UIButton component2 = child.GetChild(2).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 1;
    UIButton component3 = child.GetChild(7).GetChild(3).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 2;
    UIButton component4 = child.GetChild(7).GetChild(5).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_BtnID1 = 3;
    this.CrusadeBtn = child.GetChild(8).GetComponent<UIButton>();
    this.CrusadeBtn.m_Handler = (IUIButtonClickHandler) this;
    this.CrusadeBtn.m_BtnID1 = 5;
    this.CrusadeMBtn = child.GetChild(9).GetComponent<UIButton>();
    this.CrusadeMBtn.m_Handler = (IUIButtonClickHandler) this;
    this.CrusadeMBtn.m_BtnID1 = 6;
    if (GUIManager.Instance.IsArabic)
    {
      ((Component) this.CrusadeBtn).transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
      ((Component) this.CrusadeMBtn).transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
    }
    this.FuncBtnRect = child.GetChild(10).GetComponent<RectTransform>();
    this.FuncBtn = child.GetChild(10).GetComponent<UIButton>();
    this.FuncBtn.m_Handler = (IUIButtonClickHandler) this;
    this.FuncBtn.m_BtnID1 = 7;
    UIButton component5 = child.GetChild(15).GetChild(0).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    component5.m_BtnID1 = 4;
    this.UpperMessageText = child.GetChild(5).GetComponent<UIText>();
    this.UpperMessageText.font = ttfFont;
    this.AddRefreshText(this.UpperMessageText);
    this.CrusadeTrans = child.GetChild(6);
    this.HurtText = this.CrusadeTrans.GetChild(0).GetComponent<UIText>();
    this.HurtText.font = ttfFont;
    this.AddRefreshText(this.HurtText);
    this.LeftTimeText = this.CrusadeTrans.GetChild(1).GetComponent<UIText>();
    this.LeftTimeText.font = ttfFont;
    this.AddRefreshText(this.LeftTimeText);
    this.TimesText = this.CrusadeTrans.GetChild(2).GetComponent<UIText>();
    this.TimesText.font = ttfFont;
    this.AddRefreshText(this.TimesText);
    UIText component6 = this.CrusadeTrans.GetChild(3).GetComponent<UIText>();
    component6.font = ttfFont;
    component6.text = instance.mStringTable.GetStringByID(8332U);
    this.AddRefreshText(component6);
    UIText component7 = this.CrusadeTrans.GetChild(4).GetComponent<UIText>();
    component7.font = ttfFont;
    component7.text = instance.mStringTable.GetStringByID(8333U);
    this.AddRefreshText(component7);
    this.DestTimeText = child.GetChild(7).GetChild(0).GetComponent<UIText>();
    this.DestTimeText.font = ttfFont;
    this.AddRefreshText(this.DestTimeText);
    this.BoostsText = child.GetChild(7).GetChild(1).GetComponent<UIText>();
    this.BoostsText.font = ttfFont;
    this.AddRefreshText(this.BoostsText);
    this.HintRect = child.GetChild(14).GetChild(0).GetComponent<RectTransform>();
    this.HintText = child.GetChild(14).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.HintText.font = ttfFont;
    this.AddRefreshText(this.HintText);
    child.GetChild(14).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) GUIManager.Instance.m_ItemInfo;
    UIButtonHint uiButtonHint1 = child.GetChild(7).GetChild(6).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.ScrollID = (byte) 1;
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    uiButtonHint1.ControlFadeOut = ((Component) this.HintRect).gameObject;
    uiButtonHint1.Parm1 = (ushort) 8352;
    this.EnergyDegree.Init(child.GetChild(7).GetChild(2), (ushort) 336);
    this.AddRefreshText(this.EnergyDegree.TitleText);
    if (GUIManager.Instance.IsArabic)
      child.GetChild(7).GetChild(2).GetChild(2).localScale = new Vector3(-1f, 1f, 1f);
    this.CrusadeCostText = child.GetChild(8).GetChild(1).GetComponent<UIText>();
    this.CrusadeCostText.font = ttfFont;
    this.AddRefreshText(this.CrusadeCostText);
    this.CrusadeText = child.GetChild(8).GetChild(2).GetComponent<UIText>();
    this.CrusadeText.font = ttfFont;
    this.CrusadeText.text = instance.mStringTable.GetStringByID(8335U);
    this.AddRefreshText(this.CrusadeText);
    this.CrusadeMCostText = child.GetChild(9).GetChild(1).GetComponent<UIText>();
    this.CrusadeMCostText.font = ttfFont;
    this.AddRefreshText(this.CrusadeMCostText);
    this.CrusadeMText = child.GetChild(9).GetChild(2).GetComponent<UIText>();
    this.CrusadeMText.font = ttfFont;
    this.AddRefreshText(this.CrusadeMText);
    this.FuncBtnText = child.GetChild(10).GetChild(0).GetComponent<UIText>();
    this.FuncBtnText.font = ttfFont;
    this.FuncBtnText.text = instance.mStringTable.GetStringByID(8337U);
    this.AddRefreshText(this.FuncBtnText);
    this.DownMessageText = child.GetChild(11).GetComponent<UIText>();
    this.DownMessageText.font = ttfFont;
    this.AddRefreshText(this.DownMessageText);
    UIText component8 = child.GetChild(12).GetChild(1).GetChild(0).GetComponent<UIText>();
    component8.font = ttfFont;
    component8.text = instance.mStringTable.GetStringByID(1590U);
    this.AddRefreshText(component8);
    this.PriceCont = child.GetChild(12).GetChild(2).GetChild(0).GetComponent<RectTransform>();
    this.PriceScroll = ((Transform) this.PriceCont).parent.GetComponent<CScrollRect>();
    if (this.CountdownFlag == 1)
    {
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 3);
      this.ShowUIVisible(this.bShowUI);
      this.DelayShow = 0.0f;
      this.PassInit = (short) 2;
    }
    this.PriceTitleText.Init(child.GetChild(13).GetChild(4).GetChild(1).GetComponent<RectTransform>(), child.GetChild(13).GetChild(4).GetChild(0), 372.5f, ttfFont);
    this.PriceTitleText.SetText(instance.mStringTable.GetStringByID(14506U));
    UIButtonHint uiButtonHint2 = ((Component) this.PriceTitleText.Button).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint2.ScrollID = (byte) 1;
    uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint2.m_Handler = (MonoBehaviour) this;
    uiButtonHint2.ControlFadeOut = ((Component) this.HintRect).gameObject;
    uiButtonHint2.Parm1 = (ushort) 14510;
    this.PriceGo = child.GetChild(12).gameObject;
    this.SummonPriceGo = child.GetChild(13).gameObject;
    this.SummonPriceTrans = child.GetChild(13).GetChild(3);
    GUIManager.Instance.InitianHeroItemImg(this.SummonPriceTrans, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.AnList = new AnimationUnit.AnimName[this.ANIndex.Length];
    this.MonsterAct = StringManager.Instance.SpawnString();
    this.MonsterAct.Append(AnimationUnit.ANIM_STRING[0]);
    this.IdleHash = this.MonsterAct.GetHashCode(false);
  }

  public override void OnClose()
  {
    this.MonsterDegree.Destroy();
    this.EnergyDegree.Destroy();
    StringManager.Instance.DeSpawnString(this.HurtStr);
    StringManager.Instance.DeSpawnString(this.LeftTimeStr);
    StringManager.Instance.DeSpawnString(this.CrusadeMStr);
    StringManager.Instance.DeSpawnString(this.UpperMessageStr);
    StringManager.Instance.DeSpawnString(this.CrusadeCostStr);
    StringManager.Instance.DeSpawnString(this.CrusadeMCostStr);
    StringManager.Instance.DeSpawnString(this.TimesStr);
    StringManager.Instance.DeSpawnString(this.DestTimeStr);
    StringManager.Instance.DeSpawnString(this.BoostsStr);
    StringManager.Instance.DeSpawnString(this.PositionStr);
    StringManager.Instance.DeSpawnString(this.MonsterLvStr);
    StringManager.Instance.DeSpawnString(this.ArrChatStr);
    StringManager.Instance.DeSpawnString(this.MonsterAct);
    StringManager.Instance.DeSpawnString(this.MonsterNameStr);
    if ((Object) this.MonsterGo != (Object) null)
      ModelLoader.Instance.Unload((Object) this.MonsterGo);
    if (this.AssetKey == 0)
      return;
    AssetManager.UnloadAssetBundle(this.AssetKey);
  }

  public void OnDisable() => this.bShowUI = false;

  public override void ReOnOpen()
  {
    this.bShowUI = true;
    this.ShowUIVisible(this.bShowUI);
    this.Set3Denvironment();
    if ((Object) this.MonsterGo != (Object) null && (Object) this.MonsterSkin == (Object) null)
    {
      this.MonsterSkin = this.MonsterGo.GetComponentInChildren<SkinnedMeshRenderer>();
      if ((Object) this.MonsterSkin != (Object) null)
        this.MonsterSkin.useLightProbes = false;
    }
    if (!((Object) this.MonsterAN != (Object) null))
      return;
    this.MonsterAN.enabled = false;
    this.MonsterAN.enabled = true;
  }

  private void ShowUIVisible(bool bShow)
  {
    this.Panel2.SetActive(bShow);
    if (this.Panel2.activeSelf)
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 3);
    else
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 9);
  }

  private bool CheckValidMapID(int mapID)
  {
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[mapID];
    if (mapPoint.pointKind != (byte) 10)
      return false;
    this.MonsterPoint = DataManager.MapDataController.NPCPointTable[(int) mapPoint.tableID];
    this.UpdatePetStateHitMonterTimes();
    this.UpdateLeftHurtAddionalTime();
    return true;
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    this.UpdatePetStateHitMonterTimes();
    this.CheckInit();
    this.UpdateData();
    this.UpdateTitle();
  }

  public void UpdateData()
  {
    DataManager instance = DataManager.Instance;
    bool flag1 = false;
    ushort num1 = (ushort) (75U + (uint) this.MonsterPoint.level);
    uint monsterPoint = instance.RoleAttr.MonsterPoint;
    ushort needEnergy = this.GetNeedEnergy(this.MonsterPoint.level);
    this.ActionTimes = (int) (byte) (monsterPoint / (uint) needEnergy);
    byte num2 = 1;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    bool flag5 = false;
    bool flag6 = false;
    bool flag7 = false;
    bool flag8 = true;
    ((Graphic) this.CrusadeCostText).color = ((Graphic) this.CrusadeMCostText).color;
    byte num3 = 1;
    if (ActivityManager.Instance.IsInKvK((ushort) 0))
    {
      if ((int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
        num2 = (byte) 0;
    }
    else if ((int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID)
      num2 = (byte) 0;
    if (instance.RoleAlliance.Id == 0U)
    {
      this.UpperMessageText.text = instance.mStringTable.GetStringByID(8340U);
      this.FuncBtnText.text = instance.mStringTable.GetStringByID(4701U);
      this.FuncBtn.m_BtnID1 = 9;
      this.FuncBtnRect.sizeDelta = new Vector2(375f, 91f);
      this.FuncBtnRect.anchoredPosition = new Vector2(199.5f, -104.5f);
      flag6 = flag2 = true;
    }
    else if (instance.GetTechLevel(num1) == (byte) 0)
    {
      TechDataTbl recordByKey = instance.TechData.GetRecordByKey(num1);
      this.UpperMessageStr.ClearString();
      this.UpperMessageStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey.TechName));
      this.UpperMessageStr.AppendFormat(instance.mStringTable.GetStringByID(8339U));
      this.UpperMessageText.text = this.UpperMessageStr.ToString();
      this.UpperMessageText.SetAllDirty();
      this.UpperMessageText.cachedTextGenerator.Invalidate();
      this.FuncBtnText.text = instance.mStringTable.GetStringByID(3776U);
      this.FuncBtn.m_BtnID1 = 8;
      this.FuncBtn.m_BtnID2 = (int) recordByKey.TechID;
      this.FuncBtnRect.sizeDelta = new Vector2(375f, 91f);
      this.FuncBtnRect.anchoredPosition = new Vector2(199.5f, -104.5f);
      flag6 = flag2 = true;
    }
    else
    {
      for (byte index = 0; (int) index < (int) instance.MaxMarchEventNum; ++index)
      {
        if (instance.MarchEventData[(int) index].Type == EMarchEventType.EMET_HitMonsterMarching || instance.MarchEventData[(int) index].Type == EMarchEventType.EMET_HitMonsterReturn || instance.MarchEventData[(int) index].Type == EMarchEventType.EMET_HitMonsterRetreat)
        {
          flag1 = true;
          break;
        }
      }
      if (num2 == (byte) 0)
      {
        this.UpperMessageText.text = instance.mStringTable.GetStringByID(7744U);
        flag2 = true;
      }
      else if ((int) instance.RoleAttr.LastHitMonsterSerialNO != (int) this.MonsterPoint.Key)
      {
        if (this.PetHitTimes == (byte) 0)
        {
          this.UpperMessageText.text = instance.mStringTable.GetStringByID(8334U);
          flag2 = true;
        }
        else
        {
          this.UpdateTitle();
          flag3 = true;
        }
      }
      else
      {
        this.UpdateTitle();
        flag3 = true;
      }
      if (flag1)
      {
        this.DownMessageText.text = instance.mStringTable.GetStringByID(8338U);
        flag7 = true;
      }
      else if (monsterPoint < (uint) needEnergy)
      {
        num3 = (byte) 0;
        ((Graphic) this.CrusadeCostText).color = ((Graphic) this.DownMessageText).color;
        flag8 = true;
        this.CrusadeCostStr.ClearString();
        this.CrusadeCostStr.IntToFormat((long) needEnergy, bNumber: true);
        this.CrusadeCostStr.AppendFormat("<color=#ff5a71ff>{0}</color>");
        this.CrusadeCostText.text = this.CrusadeCostStr.ToString();
        this.CrusadeCostText.SetAllDirty();
        this.CrusadeCostText.cachedTextGenerator.Invalidate();
        this.FuncBtnRect.sizeDelta = new Vector2(188f, 91f);
        this.FuncBtnRect.anchoredPosition = new Vector2(306f, -107.5f);
        this.FuncBtnText.text = instance.mStringTable.GetStringByID(8337U);
        this.FuncBtn.m_BtnID1 = 2;
        flag4 = flag6 = true;
        if (num2 == (byte) 0)
        {
          flag8 = false;
          ((Graphic) this.CrusadeText).color = Color.gray;
        }
      }
      else if (this.ActionTimes == 1 || this.MonsterType == UIMapMonster.eMonsterType.ResourceMonster || this.MonsterType == UIMapMonster.eMonsterType.SummonMonster)
      {
        this.CrusadeCostStr.ClearString();
        this.CrusadeCostStr.IntToFormat((long) needEnergy, bNumber: true);
        this.CrusadeCostStr.AppendFormat("{0}");
        this.CrusadeCostText.text = this.CrusadeCostStr.ToString();
        this.CrusadeCostText.SetAllDirty();
        this.CrusadeCostText.cachedTextGenerator.Invalidate();
        if (num2 == (byte) 0)
        {
          flag8 = false;
          ((Graphic) this.CrusadeText).color = Color.gray;
        }
        this.FuncBtnRect.sizeDelta = new Vector2(188f, 91f);
        this.FuncBtnRect.anchoredPosition = new Vector2(306f, -107.5f);
        this.FuncBtnText.text = instance.mStringTable.GetStringByID(8337U);
        this.FuncBtn.m_BtnID1 = 2;
        flag4 = flag6 = true;
      }
      else
      {
        this.CrusadeCostStr.ClearString();
        this.CrusadeCostStr.IntToFormat((long) needEnergy, bNumber: true);
        this.CrusadeCostStr.AppendFormat("{0}");
        this.CrusadeCostText.text = this.CrusadeCostStr.ToString();
        this.CrusadeCostText.SetAllDirty();
        this.CrusadeCostText.cachedTextGenerator.Invalidate();
        this.CrusadeMCostStr.ClearString();
        this.CrusadeMCostStr.IntToFormat((long) ((int) needEnergy * this.ActionTimes), bNumber: true);
        this.CrusadeMCostStr.AppendFormat("{0}");
        this.CrusadeMCostText.text = this.CrusadeMCostStr.ToString();
        this.CrusadeMCostText.SetAllDirty();
        this.CrusadeMCostText.cachedTextGenerator.Invalidate();
        this.CrusadeMStr.ClearString();
        this.CrusadeMStr.IntToFormat((long) this.ActionTimes);
        this.CrusadeMStr.AppendFormat(instance.mStringTable.GetStringByID(8336U));
        this.CrusadeMText.text = this.CrusadeMStr.ToString();
        this.CrusadeMText.SetAllDirty();
        this.CrusadeMText.cachedTextGenerator.Invalidate();
        flag4 = flag5 = true;
        if (num2 == (byte) 0)
        {
          flag8 = false;
          ((Behaviour) this.CrusadeMBtn).enabled = false;
          ((Graphic) this.CrusadeText).color = Color.gray;
          ((Graphic) this.CrusadeMText).color = Color.gray;
        }
      }
    }
    this.CrusadeBtn.m_BtnID3 = (int) num3;
    ((Behaviour) this.CrusadeBtn).enabled = flag8;
    ((Component) this.UpperMessageText).gameObject.SetActive(flag2);
    this.CrusadeTrans.gameObject.SetActive(flag3);
    ((Component) this.CrusadeBtn).gameObject.SetActive(flag4);
    ((Component) this.CrusadeMBtn).gameObject.SetActive(flag5);
    ((Component) this.FuncBtn).gameObject.SetActive(flag6);
    ((Component) this.DownMessageText).gameObject.SetActive(flag7);
  }

  private void UpdateTitle()
  {
    DataManager instance = DataManager.Instance;
    int x = (int) instance.RoleAttr.LastHitMonsterSerialNO == (int) this.MonsterPoint.Key ? (int) instance.RoleAttr.DamageRateForMonster + (int) this.PetHitTimes : (int) this.PetHitTimes;
    uint num = 5U + DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MONSTERKILL_COMBOMAX);
    if ((long) x > (long) num)
      x = (int) num;
    float f = (float) ((19.5 + (double) x * 0.5) * (double) x * 0.5 + 4.0);
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.TimesStr.ClearString();
    this.TimesStr.IntToFormat((long) x);
    this.TimesStr.AppendFormat(mStringTable.GetStringByID(8331U));
    this.TimesText.text = this.TimesStr.ToString();
    this.TimesText.SetAllDirty();
    this.TimesText.cachedTextGenerator.Invalidate();
    this.HurtStr.ClearString();
    this.HurtStr.FloatToFormat(f, 2, false);
    if (GUIManager.Instance.IsArabic)
      this.HurtStr.AppendFormat("%{0}");
    else
      this.HurtStr.AppendFormat("{0}%");
    this.HurtText.text = this.HurtStr.ToString();
    this.HurtText.SetAllDirty();
    this.HurtText.cachedTextGenerator.Invalidate();
  }

  private void UpdateAttrib()
  {
    DataManager instance = DataManager.Instance;
    SoldierData recordByKey = instance.SoldierDataTable.GetRecordByKey((ushort) 30);
    uint effectBaseVal1 = instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED);
    uint effectBaseVal2 = instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_HERO_MARCH_SPEED);
    uint effectBaseVal3 = instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_DEBUFF);
    float num1 = (10000f + (float) instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_CURSE)) / (float) (10000U + effectBaseVal2 + effectBaseVal1 - effectBaseVal3);
    float num2 = DataManager.MapDataController.CalcDistance(this.MonsterMapID, instance.RoleAttr.CapitalPoint, (ushort) 0);
    uint num3 = GameConstants.appCeil(GameConstants.FastInvSqrt(num2 * num2) * ((float) recordByKey.Speed * num1));
    this.DestTimeStr.ClearString();
    this.DestTimeStr.IntToFormat((long) (num3 / 60U), 2);
    this.DestTimeStr.IntToFormat((long) (num3 % 60U), 2);
    this.DestTimeStr.AppendFormat("{0} : {1}");
    this.DestTimeText.text = this.DestTimeStr.ToString();
    this.DestTimeText.SetAllDirty();
    this.DestTimeText.cachedTextGenerator.Invalidate();
    this.BoostsStr.ClearString();
    this.BoostsStr.StringToFormat(instance.mStringTable.GetStringByID(353U));
    this.BoostsStr.FloatToFormat((float) (effectBaseVal2 + effectBaseVal1 - effectBaseVal3) / 100f, 2, false);
    this.BoostsStr.AppendFormat("{0}<color=#1BF568FF>{1}%</color>");
    this.BoostsText.text = this.BoostsStr.ToString();
    this.BoostsText.SetAllDirty();
    this.BoostsText.cachedTextGenerator.Invalidate();
    this.EnergyDegree.SetValue(instance.RoleAttr.MonsterPoint, this.maxRoleEnergy);
  }

  public void UpdateMonster()
  {
    DataManager instance = DataManager.Instance;
    MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.MonsterPoint.NPCNum);
    CString Name = StringManager.Instance.StaticString1024();
    this.HeroID = recordByKey.ModelID;
    this.Modle = instance.HeroTable.GetRecordByKey(this.HeroID).Modle;
    Name.IntToFormat((long) this.Modle, 5);
    Name.AppendFormat("Role/hero_{0}");
    if (AssetManager.GetAssetBundleDownload(Name, AssetPath.Role, AssetType.Hero, this.Modle, true))
    {
      this.AB = AssetManager.GetAssetBundle(Name, out this.AssetKey);
      if ((Object) this.AB != (Object) null)
        this.AR = this.AB.LoadAsync("m", typeof (GameObject));
    }
    if (this.MonsterPoint.NPCAllianceTag.Length > 0 && this.MonsterPoint.NPCAllianceTag[0] != '0')
      this.MonsterType = UIMapMonster.eMonsterType.SummonMonster;
    else if (DataManager.MapDataController.GetMonsterType(this.MonsterPoint.NPCNum) == (ushort) 1)
      this.MonsterType = UIMapMonster.eMonsterType.ResourceMonster;
    if (this.MonsterType == UIMapMonster.eMonsterType.SummonMonster)
    {
      this.MonsterNameStr.ClearString();
      if (GUIManager.Instance.IsArabic)
      {
        this.MonsterNameStr.Append(instance.mStringTable.GetStringByID((uint) recordByKey.NameID));
        this.MonsterNameStr.StringToFormat(this.MonsterPoint.NPCAllianceTag);
        this.MonsterNameStr.AppendFormat("[{0}]");
      }
      else
      {
        this.MonsterNameStr.StringToFormat(this.MonsterPoint.NPCAllianceTag);
        this.MonsterNameStr.AppendFormat("[{0}]");
        this.MonsterNameStr.Append(instance.mStringTable.GetStringByID((uint) recordByKey.NameID));
      }
      this.MonsterNameText.text = this.MonsterNameStr.ToString();
      this.MonsterNameText.SetAllDirty();
      this.MonsterNameText.cachedTextGenerator.Invalidate();
    }
    else
    {
      this.MonsterNameStr.ClearString();
      this.MonsterNameStr.Append(instance.mStringTable.GetStringByID((uint) recordByKey.NameID));
      this.MonsterNameText.text = this.MonsterNameStr.ToString();
      this.MonsterNameText.SetAllDirty();
      this.MonsterNameText.cachedTextGenerator.Invalidate();
    }
    this.MonsterDegree.SetValue(this.MonsterPoint.Blood);
    Vector2 mapPosbySpriteId = GameConstants.getTileMapPosbySpriteID(this.MonsterMapID);
    this.PositionStr.ClearString();
    this.PositionStr.StringToFormat(instance.mStringTable.GetStringByID(4504U));
    this.PositionStr.IntToFormat((long) DataManager.MapDataController.FocusKingdomID);
    this.PositionStr.StringToFormat(instance.mStringTable.GetStringByID(4505U));
    this.PositionStr.IntToFormat((long) (int) mapPosbySpriteId.x);
    this.PositionStr.StringToFormat(instance.mStringTable.GetStringByID(4506U));
    this.PositionStr.IntToFormat((long) (int) mapPosbySpriteId.y);
    if (GUIManager.Instance.IsArabic)
      this.PositionStr.AppendFormat("{5}{4} {3}{2} {1}{0}");
    else
      this.PositionStr.AppendFormat("{0}{1} {2}{3} {4}{5}");
    this.MonsterPositionText.text = this.PositionStr.ToString();
    this.MonsterPositionText.SetAllDirty();
    this.MonsterPositionText.cachedTextGenerator.Invalidate();
    this.ArrChatStr.ClearString();
    this.ArrChatStr.StringToFormat(this.MonsterNameStr.ToString());
    this.ArrChatStr.StringToFormat(instance.mStringTable.GetStringByID(4504U));
    this.ArrChatStr.IntToFormat((long) DataManager.MapDataController.FocusKingdomID);
    this.ArrChatStr.StringToFormat(instance.mStringTable.GetStringByID(4505U));
    this.ArrChatStr.IntToFormat((long) (int) mapPosbySpriteId.x);
    this.ArrChatStr.StringToFormat(instance.mStringTable.GetStringByID(4506U));
    this.ArrChatStr.IntToFormat((long) (int) mapPosbySpriteId.y);
    if (GUIManager.Instance.IsArabic)
      this.ArrChatStr.AppendFormat("{0} {2}{1} {4}{3} {6}{5}");
    else
      this.ArrChatStr.AppendFormat("{0} {1}{2} {3}{4} {5}{6}");
    this.MonsterLvStr.ClearString();
    this.MonsterLvStr.IntToFormat((long) this.MonsterPoint.level);
    this.MonsterLvStr.AppendFormat("{0}");
    this.MonsterLvText.text = this.MonsterLvStr.ToString();
    this.MonsterLvText.SetAllDirty();
    this.MonsterLvText.cachedTextGenerator.Invalidate();
  }

  private void UpdateLeftHurtAddionalTime()
  {
    DataManager instance = DataManager.Instance;
    if ((int) instance.RoleAttr.LastHitMonsterSerialNO == (int) this.MonsterPoint.Key)
    {
      long num = instance.RoleAttr.LastHitMonsterTime + 3600L - instance.ServerTime;
      if (num <= 0L)
      {
        instance.RoleAttr.DamageRateForMonster = (byte) 0;
        instance.RoleAttr.LastHitMonsterSerialNO = 0U;
        this.UpdateData();
      }
      else
      {
        this.LeftTimeStr.ClearString();
        this.LeftTimeStr.IntToFormat(num / 60L, 2);
        this.LeftTimeStr.IntToFormat(num % 60L, 2);
        this.LeftTimeStr.AppendFormat("{0} : {1}");
        this.LeftTimeText.text = this.LeftTimeStr.ToString();
        this.LeftTimeText.SetAllDirty();
        this.LeftTimeText.cachedTextGenerator.Invalidate();
      }
    }
    else
    {
      if (this.PetHitTimes <= (byte) 0)
        return;
      this.LeftTimeText.text = "-";
    }
  }

  private ushort GetNeedEnergy(byte MonsterLv)
  {
    if (this.MonsterType == UIMapMonster.eMonsterType.ResourceMonster || this.MonsterType == UIMapMonster.eMonsterType.SummonMonster)
      return 1;
    uint num = 1;
    switch (MonsterLv)
    {
      case 1:
        num = 3000U;
        break;
      case 2:
        num = 5000U;
        break;
      case 3:
        num = 8000U;
        break;
      case 4:
        num = 14000U;
        break;
      case 5:
        num = 18000U;
        break;
    }
    return (ushort) (num - num * DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MONSTERPOINT_COST_REDUCTION) / 10000U);
  }

  private void CheckInit()
  {
    if (this.PassInit <= (short) 0)
      return;
    this.PassInit = (short) 0;
    GUIManager instance = GUIManager.Instance;
    UIButtonHint.scrollRect = this.PriceScroll;
    for (byte index = 0; index < (byte) 8; ++index)
    {
      instance.InitianHeroItemImg(((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild((int) index), eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0);
      this.AddRefreshText(((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild((int) index).GetChild(4).GetComponent<UIText>());
    }
    for (byte index = 0; index < (byte) 8; ++index)
    {
      instance.InitLordEquipImg(((Transform) this.PriceCont).GetChild(0).GetChild(1).GetChild((int) index), (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      ((Transform) this.PriceCont).GetChild(0).GetChild(1).GetChild((int) index).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
    }
    if (!this.CheckValidMapID(this.MonsterMapID))
    {
      ((Door) GUIManager.Instance.FindMenu(EGUIWindow.Door)).CloseMenu();
    }
    else
    {
      if (this.CountdownFlag == 0)
      {
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        GUIWindowStackData mWindow = menu.m_WindowStack[menu.m_WindowStack.Count - 1] with
        {
          m_Arg2 = 1
        };
        menu.m_WindowStack[menu.m_WindowStack.Count - 1] = mWindow;
      }
      else
        this.DelayShow = 0.0f;
      if ((double) this.DelayShow <= 0.0)
      {
        this.PassInit = (short) -1;
        this.ShowUIVisible(this.bShowUI);
        this.Set3Denvironment();
      }
      this.UpdateMonster();
      if (this.MonsterType != UIMapMonster.eMonsterType.SummonMonster)
        this.InitPrice();
      else
        this.InitSummonPrice();
      this.UpdateData();
      this.UpdateAttrib();
    }
  }

  private void Set3Denvironment()
  {
    DataManager.msgBuffer[0] = (byte) 84;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    GUIManager.Instance.m_UICanvas.renderMode = (RenderMode) 1;
    GUIManager.Instance.SetCanvasChanged();
  }

  private void InitPrice()
  {
    this.PriceGo.SetActive(true);
    DataManager instance = DataManager.Instance;
    byte index1 = 0;
    MapMonster recordByKey1 = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.MonsterPoint.NPCNum);
    if (this.MonsterPoint.level == (byte) 0)
      return;
    MapMonsterPrice recordByKey2 = DataManager.MapDataController.MapMonsterPriceTable.GetRecordByKey(recordByKey1.MapTeamInfo[(int) this.MonsterPoint.level - 1].ItemGroup);
    Equip recordByKey3;
    if ((ActivityManager.Instance.bSpecialMonsterTreasureEvent & 1UL) > 0UL && recordByKey2.SpecItemID > (ushort) 0)
    {
      recordByKey3 = instance.EquipTable.GetRecordByKey(recordByKey2.SpecItemID);
      if (!GUIManager.Instance.IsLeadItem(recordByKey3.EquipKind))
      {
        GUIManager.Instance.ChangeHeroItemImg(((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild((int) index1), eHeroOrItem.Item, recordByKey2.SpecItemID, (byte) 0, (byte) 0);
        ((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild((int) index1).gameObject.SetActive(true);
      }
      else
      {
        GUIManager.Instance.ChangeLordEquipImg(((Transform) this.PriceCont).GetChild(0).GetChild(1).GetChild((int) index1), recordByKey2.SpecItemID, this.MonsterPoint.level, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        ((Transform) this.PriceCont).GetChild(0).GetChild(1).GetChild((int) index1).gameObject.SetActive(true);
      }
      ++index1;
    }
    for (int index2 = 0; index2 < recordByKey2.ItemID.Length; ++index2)
    {
      if (recordByKey2.ItemID[index2] != (ushort) 0)
      {
        recordByKey3 = instance.EquipTable.GetRecordByKey(recordByKey2.ItemID[index2]);
        if (!GUIManager.Instance.IsLeadItem(recordByKey3.EquipKind))
        {
          UIHIBtn component1;
          if ((int) index1 < ((Transform) this.PriceCont).GetChild(0).GetChild(0).childCount)
          {
            GUIManager.Instance.ChangeHeroItemImg(((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild((int) index1), eHeroOrItem.Item, recordByKey2.ItemID[index2], (byte) 0, (byte) 0);
            ((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild((int) index1).gameObject.SetActive(true);
            component1 = ((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild((int) index1).GetComponent<UIHIBtn>();
          }
          else
          {
            RectTransform BtnT = Object.Instantiate((Object) ((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild(0)) as RectTransform;
            ((Transform) BtnT).SetParent(((Transform) this.PriceCont).GetChild(0).GetChild(0));
            BtnT.anchoredPosition3D = new Vector3(BtnT.anchoredPosition.x, BtnT.anchoredPosition.y, 0.0f);
            Quaternion localRotation = ((Transform) BtnT).localRotation with
            {
              eulerAngles = Vector3.zero
            };
            ((Transform) BtnT).localRotation = localRotation;
            ((Transform) BtnT).localScale = Vector3.one;
            BtnT.anchoredPosition = new Vector2((float) (36 + 74 * (int) index1), -37f);
            ((Component) BtnT).gameObject.SetActive(true);
            GUIManager.Instance.ChangeHeroItemImg((Transform) BtnT, eHeroOrItem.Item, recordByKey2.ItemID[index2], (byte) 0, (byte) 0);
            this.AddRefreshText(((Transform) BtnT).GetChild(4).GetComponent<UIText>());
            component1 = ((Component) BtnT).GetComponent<UIHIBtn>();
            ((Component) component1).GetComponent<UIButtonHint>().enabled = true;
            GUIManager.Instance.SetItemScaleClickSound(component1, false, true);
          }
          EItemType eitemType = (EItemType) ((uint) recordByKey3.EquipKind - 1U);
          if (eitemType == EItemType.EIT_ComboTreasureBox || eitemType == EItemType.EIT_MaterialTreasureBox && recordByKey3.PropertiesInfo[0].Propertieskey == (ushort) 4 || eitemType == EItemType.EIT_MaterialTreasureBox && (recordByKey3.PropertiesInfo[2].Propertieskey < (ushort) 1 || recordByKey3.PropertiesInfo[2].Propertieskey > (ushort) 3))
          {
            component1.m_BtnID2 = (int) recordByKey3.EquipKey;
            component1.m_Handler = (IUIHIBtnClickHandler) this;
            ((Component) component1).GetComponent<UIButtonHint>().enabled = false;
            EventPatchery component2 = ((Component) component1).gameObject.GetComponent<EventPatchery>();
            if ((Object) component2 == (Object) null)
              ((Component) component1).gameObject.AddComponent<EventPatchery>().SetEvnetObj(this.PriceScroll);
            else
              component2.SetEvnetObj(this.PriceScroll);
            GUIManager.Instance.SetItemScaleClickSound(component1, true, true);
          }
        }
        else if ((int) index1 < ((Transform) this.PriceCont).GetChild(0).GetChild(1).childCount)
        {
          GUIManager.Instance.ChangeLordEquipImg(((Transform) this.PriceCont).GetChild(0).GetChild(1).GetChild((int) index1), recordByKey2.ItemID[index2], this.MonsterPoint.level, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
          ((Transform) this.PriceCont).GetChild(0).GetChild(1).GetChild((int) index1).gameObject.SetActive(true);
        }
        else
        {
          RectTransform BtnT = Object.Instantiate((Object) ((Transform) this.PriceCont).GetChild(0).GetChild(1).GetChild(0)) as RectTransform;
          ((Transform) BtnT).SetParent(((Transform) this.PriceCont).GetChild(0).GetChild(1));
          BtnT.anchoredPosition3D = new Vector3(BtnT.anchoredPosition.x, BtnT.anchoredPosition.y, 0.0f);
          Quaternion localRotation = ((Transform) BtnT).localRotation with
          {
            eulerAngles = Vector3.zero
          };
          ((Transform) BtnT).localRotation = localRotation;
          ((Transform) BtnT).localScale = Vector3.one;
          BtnT.anchoredPosition = new Vector2((float) (36 + 74 * (int) index1), -37f);
          ((Component) BtnT).gameObject.SetActive(true);
          GUIManager.Instance.ChangeLordEquipImg((Transform) BtnT, recordByKey2.ItemID[index2], this.MonsterPoint.level, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        }
        ++index1;
      }
    }
    float num = (float) (4.0 + 74.0 * (double) index1);
    if ((double) this.PriceCont.sizeDelta.x < (double) num)
      this.PriceCont.sizeDelta = this.PriceCont.sizeDelta with
      {
        x = num + 4f
      };
    else
      ((Behaviour) this.PriceScroll).enabled = false;
  }

  private void InitSummonPrice()
  {
    this.SummonPriceGo.SetActive(true);
    MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.MonsterPoint.NPCNum);
    if (this.MonsterPoint.level == (byte) 0)
      return;
    GUIManager.Instance.ChangeHeroItemImg(this.SummonPriceTrans, eHeroOrItem.Item, recordByKey.MapTeamInfo[(int) this.MonsterPoint.level - 1].AllianceItem, (byte) 0, (byte) 0);
    UIHIBtn component = this.SummonPriceTrans.GetComponent<UIHIBtn>();
    component.m_Handler = (IUIHIBtnClickHandler) this;
    component.m_BtnID2 = (int) recordByKey.MapTeamInfo[(int) this.MonsterPoint.level - 1].AllianceItem;
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if ((double) this.DelayShow > 0.0)
      this.DelayShow -= Time.deltaTime;
    if (this.PassInit > (short) 0)
    {
      --this.PassInit;
      if (this.PassInit != (short) 1)
        return;
      this.CheckInit();
    }
    else
    {
      if (bOnSecond)
        this.UpdateLeftHurtAddionalTime();
      if ((double) this.DelayShow <= 0.0 && !this.bABInitial && this.AR != null && this.AR.isDone)
      {
        if (this.PassInit == (short) 0)
          this.ShowUIVisible(this.bShowUI);
        this.Set3Denvironment();
        Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.HeroID);
        this.bABInitial = true;
        this.MonsterGo = ModelLoader.Instance.Load(recordByKey.Modle, this.AB, (ushort) recordByKey.TextureNo);
        this.MonsterGo.transform.SetParent(this.MonsterTrans, false);
        if (recordByKey.Camera_Horizontal == (ushort) 0)
          this.MonsterGo.transform.localRotation = new Quaternion(0.0f, -180f, 0.0f, 0.0f);
        else
          this.MonsterGo.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
          {
            eulerAngles = new Vector3(0.0f, (float) recordByKey.Camera_Horizontal, 0.0f)
          };
        this.MonsterGo.transform.localScale = new Vector3((float) recordByKey.CameraScaleRate, (float) recordByKey.CameraScaleRate, (float) recordByKey.CameraScaleRate);
        GUIManager.Instance.SetLayer(this.MonsterGo, 5);
        if ((Object) this.MonsterGo != (Object) null)
        {
          this.MonsterAN = this.MonsterGo.GetComponent<Animation>();
          this.MonsterAN.wrapMode = WrapMode.Loop;
          this.MonsterAN.cullingType = AnimationCullingType.AlwaysAnimate;
          for (int index1 = 0; index1 < this.ANIndex.Length; ++index1)
          {
            byte index2 = (byte) this.ANIndex[index1];
            if ((Object) this.MonsterAN.GetClip(AnimationUnit.ANIM_STRING[(int) index2]) != (Object) null)
            {
              this.MonsterAN[AnimationUnit.ANIM_STRING[(int) index2]].layer = 1;
              this.MonsterAN[AnimationUnit.ANIM_STRING[(int) index2]].wrapMode = WrapMode.Once;
              this.AnList[index1] = this.ANIndex[index1];
            }
          }
          this.MonsterAN.clip = this.MonsterAN.GetClip(this.MonsterAct.ToString());
          this.MonsterAN.Play(this.MonsterAct.ToString());
          this.MonsterSkin = this.MonsterGo.GetComponentInChildren<SkinnedMeshRenderer>();
          if ((Object) this.MonsterSkin != (Object) null)
            this.MonsterSkin.useLightProbes = false;
        }
      }
      else if ((double) this.DelayShow <= 0.0 && this.PassInit == (short) 0)
      {
        this.PassInit = (short) -1;
        this.ShowUIVisible(this.bShowUI);
        this.Set3Denvironment();
      }
      if (this.Panel2.activeSelf && (Object) this.MonsterGo != (Object) null)
      {
        this.MonsterAN = this.MonsterGo.GetComponent<Animation>();
        if ((!this.MonsterAN.IsPlaying(this.MonsterAct.ToString()) || this.MonsterAct.GetHashCode(false) == this.IdleHash) && (double) this.ActionTimeRandom < 9.9999997473787516E-05)
        {
          this.ActionTimeRandom = (float) Random.Range(3, 7);
          this.ActionTime = 0.0f;
        }
        if ((double) this.ActionTimeRandom > 9.9999997473787516E-05)
        {
          this.ActionTime += Time.smoothDeltaTime;
          if ((double) this.ActionTime >= (double) this.ActionTimeRandom)
            this.MonsterActionChang();
        }
      }
      if (!bOnSecond || (int) DataManager.Instance.RoleAttr.MonsterPoint != (int) this.maxRoleEnergy)
        return;
      this.UpdateData();
    }
  }

  public void MonsterActionChang()
  {
    if ((Object) this.MonsterGo == (Object) null)
      return;
    int index = Random.Range(0, this.AnList.Length);
    this.MonsterAct.ClearString();
    this.MonsterAct.Append(AnimationUnit.ANIM_STRING[(int) this.AnList[index]]);
    AnimationClip animationClip = this.MonsterAN.GetClip(this.MonsterAct.ToString());
    if (this.AnList[index] == AnimationUnit.AnimName.SKILL1)
    {
      this.MonsterAct.Append("_ch");
      if ((Object) this.MonsterAN.GetClip(this.MonsterAct.ToString()) != (Object) null)
        animationClip = (AnimationClip) null;
    }
    if ((Object) animationClip != (Object) null)
      this.MonsterAN.CrossFade(animationClip.name);
    this.ActionTimeRandom = 0.0f;
    this.ActionTime = 0.0f;
  }

  public void UpdatePetStateHitMonterTimes()
  {
    this.PetHitTimes = (byte) 0;
    PetManager instance = PetManager.Instance;
    List<PSBuffInfoData> buffInfo = instance.BuffInfo;
    for (int index = 0; index < buffInfo.Count; ++index)
    {
      if (buffInfo[index].SkillID != (ushort) 0 && buffInfo[index].Level != (byte) 0)
      {
        PetSkillTbl recordByKey = instance.PetSkillTable.GetRecordByKey(buffInfo[index].SkillID);
        if (recordByKey.Kind == (byte) 19)
          this.PetHitTimes += (byte) instance.PetSkillValTable.GetRecordByKey(recordByKey.XValue).EffectBySkillLv[(int) buffInfo[index].Level - 1];
      }
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
        break;
      case NetworkNews.Refresh_Asset:
        if (meg[1] != (byte) 1 || meg[2] != (byte) 2 || (int) GameConstants.ConvertBytesToUShort(meg, 3) != (int) this.Modle || !((Object) this.AB == (Object) null))
          break;
        CString Name = StringManager.Instance.StaticString1024();
        Name.IntToFormat((long) this.Modle, 5);
        Name.AppendFormat("Role/hero_{0}");
        this.AB = AssetManager.GetAssetBundle(Name, out this.AssetKey);
        if (!((Object) this.AB != (Object) null))
          break;
        this.AR = this.AB.LoadAsync("m", typeof (GameObject));
        break;
      default:
        if (networkNews != NetworkNews.Refresh_MonsterPoint)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          {
            if (networkNews != NetworkNews.Refresh_AttribEffectVal)
              break;
            this.maxRoleEnergy = DataManager.Instance.GetMaxMonsterPoint();
            break;
          }
          for (int index = 0; index < this.RefreshTextArray.Count; ++index)
          {
            if ((Object) this.RefreshTextArray[index] != (Object) null && ((Behaviour) this.RefreshTextArray[index]).enabled)
            {
              ((Behaviour) this.RefreshTextArray[index]).enabled = false;
              ((Behaviour) this.RefreshTextArray[index]).enabled = true;
            }
          }
          this.PriceTitleText.TextRefresh();
          break;
        }
        this.UpdateAttrib();
        this.UpdateData();
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    switch (sender.m_BtnID1)
    {
      case 0:
        menu.OpenMenu(EGUIWindow.UI_MonsterInfo, (int) this.MonsterPoint.NPCNum, (int) this.MonsterType);
        break;
      case 1:
        menu.CloseMenu();
        menu.m_GroundInfo.OpenMonsterBookmarksPanel(true, this.MonsterMapID);
        break;
      case 2:
        GUIManager.Instance.OpenItemKindFilterUI((ushort) 10, (byte) 30, (byte) 0);
        break;
      case 3:
        this.ShowUIVisible(false);
        menu.OpenMenu(EGUIWindow.UI_Chat, (int) GUIManager.Instance.ChannelIndex + 1);
        ((UIChat) GUIManager.Instance.FindMenu(EGUIWindow.UI_Chat)).SetInputText(this.ArrChatStr.ToString());
        break;
      case 4:
        menu.CloseMenu();
        break;
      case 5:
        if (sender.m_BtnID3 == 0)
        {
          GUIManager.Instance.AddHUDMessage(mStringTable.GetStringByID(8344U), (ushort) byte.MaxValue);
          break;
        }
        if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbySpriteID(this.MonsterMapID)) == 0.0)
        {
          GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(3967U), mStringTable.GetStringByID(119U), mStringTable.GetStringByID(4034U));
          break;
        }
        menu.OpenMenu(EGUIWindow.UI_BattleHeroSelect, this.MonsterMapID, 1, true);
        break;
      case 6:
        if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbySpriteID(this.MonsterMapID)) == 0.0)
        {
          GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(3967U), mStringTable.GetStringByID(119U), mStringTable.GetStringByID(4034U));
          break;
        }
        menu.OpenMenu(EGUIWindow.UI_BattleHeroSelect, this.MonsterMapID, this.ActionTimes, true);
        break;
      case 8:
        GUIManager.Instance.OpenTechTree((ushort) sender.m_BtnID2);
        break;
      case 9:
        DataManager.Instance.SetSelectRequest = 0;
        menu.OpenMenu(EGUIWindow.UI_AllianceHint);
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    this.HintText.text = DataManager.Instance.mStringTable.GetStringByID((uint) sender.Parm1);
    this.HintRect.sizeDelta = this.HintRect.sizeDelta with
    {
      y = this.HintText.preferredHeight + 16f
    };
    sender.GetTipPosition(this.HintRect);
    ((Component) this.HintRect).gameObject.SetActive(true);
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    ((Component) this.HintRect).gameObject.SetActive(false);
  }

  public void AddRefreshText(UIText text) => this.RefreshTextArray.Add(text);

  private struct DegreeBar
  {
    private RectTransform BloodTran;
    public UIText TitleText;
    private CString TitleStr;
    private float BloodWidth;

    public void Init(Transform transform, ushort MaxWidth)
    {
      this.BloodTran = transform.GetChild(0).GetComponent<RectTransform>();
      this.TitleText = transform.GetChild(1).GetComponent<UIText>();
      this.TitleText.font = GUIManager.Instance.GetTTFFont();
      this.TitleStr = StringManager.Instance.SpawnString();
      this.BloodWidth = (float) MaxWidth;
    }

    public void SetValue(float Percentage)
    {
      float num = (float) ((double) this.BloodWidth * (double) Percentage * 0.0099999997764825821);
      this.BloodTran.sizeDelta = this.BloodTran.sizeDelta with
      {
        x = num
      };
      this.TitleStr.ClearString();
      if ((double) Percentage > 0.0099999997764825821)
        this.TitleStr.FloatToFormat(Percentage, 2, false);
      else
        this.TitleStr.StringToFormat("0.01");
      if (GUIManager.Instance.IsArabic)
        this.TitleStr.AppendFormat("%{0}");
      else
        this.TitleStr.AppendFormat("{0}%");
      this.TitleText.text = this.TitleStr.ToString();
      this.TitleText.SetAllDirty();
      this.TitleText.cachedTextGenerator.Invalidate();
    }

    public void SetValue(uint NowVal, uint MaxVal)
    {
      float num = (float) NowVal * (this.BloodWidth / (float) MaxVal);
      this.BloodTran.sizeDelta = this.BloodTran.sizeDelta with
      {
        x = num
      };
      this.TitleStr.ClearString();
      this.TitleStr.IntToFormat((long) NowVal, bNumber: true);
      this.TitleStr.IntToFormat((long) MaxVal, bNumber: true);
      if (GUIManager.Instance.IsArabic)
        this.TitleStr.AppendFormat("{1} / {0}");
      else
        this.TitleStr.AppendFormat("{0} / {1}");
      this.TitleText.text = this.TitleStr.ToString();
      this.TitleText.SetAllDirty();
      this.TitleText.cachedTextGenerator.Invalidate();
    }

    public void Destroy() => StringManager.Instance.DeSpawnString(this.TitleStr);
  }

  private enum UIControl
  {
    MonsterData,
    Info,
    BookMark,
    Monster,
    ContSkin,
    UpperMessage,
    CrusadeTitle,
    ContFunc,
    CrusadeBtn,
    CrusadeMBtn,
    ReCharge,
    DownMessage,
    Price,
    Price_Summon,
    Hint,
    Close,
  }

  private enum UIFuncControl
  {
    Time,
    Boost,
    EnemyBlood,
    Filter,
    Position,
    ChatBtn,
    TimeHintBtn,
  }

  private enum eClickType
  {
    Info,
    BookMark,
    Filter,
    AddChat,
    Close,
    Crusade,
    CrusadeM,
    GetEnergy,
    LearnTech,
    JoinAlliance,
  }

  public enum eMonsterType
  {
    ResourceMonster = 1,
    SummonMonster = 3,
  }
}
