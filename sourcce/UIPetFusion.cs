// Decompiled with JetBrains decompiler
// Type: UIPetFusion
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIPetFusion : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUICalculatorHandler,
  IUIHIBtnClickHandler,
  IUILEBtnClickHandler,
  IUIUnitRSliderHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private PetManager PM;
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform Tmp2;
  private Transform Tmp3;
  private Transform RD_T;
  private Transform NotRD_T;
  private Transform LockPanel;
  private Transform DResourcesT;
  private RectTransform mContentRT;
  private RectTransform mFusionItemRT;
  private RectTransform[] mHIbtnItemRT = new RectTransform[3];
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private Door door;
  private UISpritesArray spArray;
  private UIButton btn_EXIT;
  private UIButton btn_Lock;
  private UIButton btn_Fusion;
  private UIButton btn_FusionCompleted;
  private UIButton btn_RD;
  private UIButton btn_ItemInfo;
  private UIButton btn_I;
  private UIButton btn_Skill;
  private UIButton[] btn_Add = new UIButton[2];
  private UIButton[] btn_Skill_ItemStore = new UIButton[3];
  private UIButton[] btn_Contract = new UIButton[8];
  private uButtonScale btn_Scale;
  private Image Img_EXIT;
  private Image Img_Lock;
  private Image Img_LockBG;
  private Image[] Img_FusionCompleted = new Image[3];
  private Image[] Img_Fusion = new Image[2];
  private Image[] Img_Fusion_Info = new Image[2];
  private Image[] Img_Fusion_R = new Image[2];
  private Image[] Img_Fusion_Add = new Image[2];
  private Image[] Img_PetSkill = new Image[2];
  private Image Img_RDLock;
  private Image[] tmpImgSelect = new Image[8];
  private Image[] tmpImgLock = new Image[8];
  private Image[] Img_Skill_ItemStore = new Image[3];
  private UIText text_Title;
  private UIText text_Type;
  private UIText text_Kind;
  private UIText text_Fusion;
  private UIText text_FusionCompleted;
  private UIText text_Gemstone;
  private UIText text_Time;
  private UIText text_RD;
  private UIText text_RDbtn;
  private UIText text_FusionName;
  private UIText text_FusionNeedQty;
  private UIText text_SkillNeedQty;
  private UIText text_SkillName;
  private UIText text_SkillItemQty;
  private UIText[] text_NeedQty = new UIText[3];
  private UIText[] text_ItemName = new UIText[8];
  private UIText[] text_ItemNameSkill = new UIText[8];
  private UIText[] text_ItemCount = new UIText[8];
  private UIHIBtn[] Hbtn_Fusion = new UIHIBtn[2];
  private UIHIBtn[] Hbtn_Need = new UIHIBtn[3];
  private UILEBtn[] Lbtn_Need = new UILEBtn[3];
  private UIHIBtn[] Hbtn_btn = new UIHIBtn[8];
  private DemandResources m_DResources;
  private UnitResourcesSlider m_UnitRS;
  private ScrollPanel m_ScrollPanel;
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[8];
  private List<float> tmplist = new List<float>();
  private List<ushort> mFusionlist = new List<ushort>();
  private List<ushort> mSkilllist = new List<ushort>();
  private CString Cstr;
  private CString Cstr_Gemstone;
  private CString Cstr_Time;
  private CString Cstr_RD;
  private CString Cstr_FusionNeedQty;
  private CString Cstr_SkillNeedQty;
  private CString Cstr_SkillItemQty;
  private CString Cstr_Info;
  private CString Cstr_UnitRS;
  private CString Cstr_Name;
  private CString[] Cstr_SkillItemNeedQty = new CString[3];
  private CString[] Cstr_SkillItem = new CString[8];
  private CString[] Cstr_SkillItemName = new CString[8];
  private byte mType;
  private uint[] Resources = new uint[7];
  private byte RD_Kind;
  private byte RD_Rank;
  private uint UnitMax;
  private uint BarrackMax;
  private uint FusionQty;
  private float tmpEGA_Cost = 1f;
  private float tmpEGA;
  private long[] Rvalue = new long[6];
  private uint tmpValue;
  private bool bRDOutput = true;
  private ushort Quantity;
  private ushort tmpItemCraftIndex;
  private byte mItemCount;
  private bool IsItemenough = true;
  private bool IsItemenough_Store = true;
  private uint needDiamond;
  private ComboBoxItem[] m_NeedItem = new ComboBoxItem[3];
  private float ItemSelect;
  private float ItemInfo;
  private int mItemIdx = -1;
  private int mItemIdx2 = -1;
  private Equip tmpEquip;
  private PetTbl tmpPetD;
  private FusionData tmpFD;
  private PetSkillTbl skill;
  private RoleBuildingData mBD;
  private BuildLevelRequest mBR;
  private PetData CurPetData;
  private CHashTable<ushort, ushort> FusionlistItemData;
  private string AssetName;
  private ushort mPetSkillIcon;
  private StoreTbl tmpST;
  private Color c_ItemQty = new Color(0.549f, 0.878f, 1f);

  public void OnVauleChang(UnitResourcesSlider sender)
  {
    this.Cstr.ClearString();
    StringManager.IntToStr(this.Cstr, sender.Value, bNumber: true);
    sender.m_inputText.text = this.Cstr.ToString();
    sender.m_inputText.SetAllDirty();
    sender.m_inputText.cachedTextGenerator.Invalidate();
    this.SetDRformURS((double) sender.Value);
  }

  public void OnTextChang(UnitResourcesSlider sender)
  {
    this.Cstr.ClearString();
    StringManager.IntToStr(this.Cstr, sender.Value, bNumber: true);
    this.SetDRformURS((double) sender.Value);
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.PM = PetManager.Instance;
    this.GameT = this.gameObject.transform;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.spArray = this.GameT.GetComponent<UISpritesArray>();
    this.PM.SortPetData();
    Material material = this.door.LoadMaterial();
    this.AssetName = nameof (UIPetFusion);
    this.GUIM.AddSpriteAsset(this.AssetName);
    Material mmaterial = this.GUIM.LoadMaterial(this.AssetName, "UI_co_contract_tower_m");
    this.Cstr = StringManager.Instance.SpawnString();
    this.Cstr_Gemstone = StringManager.Instance.SpawnString();
    this.Cstr_Time = StringManager.Instance.SpawnString();
    this.Cstr_RD = StringManager.Instance.SpawnString(200);
    this.Cstr_FusionNeedQty = StringManager.Instance.SpawnString();
    this.Cstr_SkillNeedQty = StringManager.Instance.SpawnString();
    this.Cstr_SkillItemQty = StringManager.Instance.SpawnString();
    this.Cstr_Info = StringManager.Instance.SpawnString(1024);
    this.Cstr_UnitRS = StringManager.Instance.SpawnString();
    this.Cstr_Name = StringManager.Instance.SpawnString(200);
    for (int index = 0; index < 3; ++index)
      this.Cstr_SkillItemNeedQty[index] = StringManager.Instance.SpawnString();
    for (int index = 0; index < 8; ++index)
    {
      this.Cstr_SkillItem[index] = StringManager.Instance.SpawnString();
      this.Cstr_SkillItemName[index] = StringManager.Instance.SpawnString();
    }
    this.mType = (byte) arg1;
    this.mFusionlist.Clear();
    for (int index = 0; index < this.DM.FusionDataTable.TableCount; ++index)
    {
      this.tmpFD = this.DM.FusionDataTable.GetRecordByKey((ushort) (index + 1));
      if (this.mType == (byte) 0 && this.tmpFD.Fusion_Kind == (byte) 0)
        this.mFusionlist.Add(this.tmpFD.ID);
      else if (this.mType > (byte) 0 && this.tmpFD.Fusion_Kind > (byte) 0)
        this.mSkilllist.Add(this.tmpFD.ID);
    }
    if (this.mType == (byte) 0)
    {
      if (this.PM.mPetFusionItemID != -1)
      {
        for (int index = 0; index < this.mFusionlist.Count; ++index)
        {
          if (this.PM.mPetFusionItemID == (int) this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[index]).Fusion_ItemID)
          {
            this.tmpItemCraftIndex = (ushort) index;
            break;
          }
        }
      }
    }
    else if (this.mType == (byte) 1)
    {
      this.FusionlistItemData = new CHashTable<ushort, ushort>(this.mSkilllist.Count);
      for (int index = 0; index < this.mSkilllist.Count; ++index)
      {
        this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mSkilllist[index]);
        this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
        this.FusionlistItemData.Add(this.tmpEquip.SyntheticParts[0].SyntheticItem, this.tmpFD.ID);
      }
      for (int index1 = 0; index1 < this.PM.sortPetData.Count; ++index1)
      {
        this.tmpPetD = this.PM.PetTable.GetRecordByKey(this.PM.GetPetData((int) this.PM.sortPetData[index1]).ID);
        ushort num = 0;
        for (int index2 = 0; index2 < 4; ++index2)
        {
          if (this.tmpPetD.PetSkill[index2] > (ushort) 0)
            num = this.PM.PetSkillTable.GetRecordByKey(this.tmpPetD.PetSkill[index2]).Diamond;
          if (num > (ushort) 0)
          {
            this.mFusionlist.Add(this.FusionlistItemData.Find(this.tmpPetD.ID));
            break;
          }
        }
      }
      if (arg2 != 0)
        this.PM.mPetSkillItemID = arg2;
      if (this.PM.mPetSkillItemID != -1)
      {
        for (int index = 0; index < this.mFusionlist.Count; ++index)
        {
          if (this.PM.mPetSkillItemID == (int) this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[index]).Fusion_ItemID)
          {
            this.tmpItemCraftIndex = (ushort) index;
            break;
          }
        }
      }
    }
    this.Tmp = this.GameT.GetChild(0);
    this.Tmp1 = this.Tmp.GetChild(0);
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.text_Title = this.Tmp2.GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.text_Title.text = this.DM.mStringTable.GetStringByID(14651U);
    this.Tmp1 = this.Tmp.GetChild(1);
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.btn_ItemInfo = this.Tmp2.GetComponent<UIButton>();
    this.btn_ItemInfo.m_Handler = (IUIButtonClickHandler) this;
    this.btn_ItemInfo.m_BtnID1 = 8;
    this.btn_ItemInfo.SetButtonEffectType(e_EffectType.e_Scale);
    this.btn_ItemInfo.transition = (Selectable.Transition) 0;
    this.btn_Scale = this.Tmp2.GetComponent<uButtonScale>();
    this.Tmp2 = this.Tmp1.GetChild(0).GetChild(0);
    this.Hbtn_Fusion[0] = this.Tmp2.GetComponent<UIHIBtn>();
    this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Fusion[0]).transform, eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false, bClickSound: false);
    this.Tmp2 = this.Tmp1.GetChild(0).GetChild(1);
    this.Img_Fusion_Info[0] = this.Tmp2.GetComponent<Image>();
    this.Tmp2 = this.Tmp1.GetChild(0).GetChild(1).GetChild(0);
    this.Img_Fusion_Info[1] = this.Tmp2.GetComponent<Image>();
    this.Tmp2 = this.Tmp1.GetChild(1);
    this.btn_Add[0] = this.Tmp2.GetComponent<UIButton>();
    this.btn_Add[0].m_Handler = (IUIButtonClickHandler) this;
    this.btn_Add[0].m_BtnID1 = 9;
    this.btn_Add[0].SetButtonEffectType(e_EffectType.e_Scale);
    this.btn_Add[0].transition = (Selectable.Transition) 0;
    this.Tmp2 = this.Tmp1.GetChild(1).GetChild(0);
    this.Img_Fusion_R[0] = this.Tmp2.GetComponent<Image>();
    this.Tmp2 = this.Tmp1.GetChild(1).GetChild(0).GetChild(0);
    this.Img_Fusion_Add[0] = this.Tmp2.GetComponent<Image>();
    this.Img_Fusion_Add[0].sprite = this.door.LoadSprite("UI_con_icon_05");
    ((MaskableGraphic) this.Img_Fusion_Add[0]).material = this.door.LoadMaterial();
    this.Img_Fusion_Add[0].SetNativeSize();
    ((Component) this.Img_Fusion_Add[0]).gameObject.SetActive(false);
    this.Tmp2 = this.Tmp1.GetChild(1).GetChild(0).GetChild(1);
    this.text_FusionNeedQty = this.Tmp2.GetComponent<UIText>();
    this.text_FusionNeedQty.font = this.TTFont;
    this.Tmp2 = this.Tmp1.GetChild(2);
    this.mFusionItemRT = this.Tmp2.GetComponent<RectTransform>();
    this.btn_Add[1] = this.Tmp2.GetComponent<UIButton>();
    this.btn_Add[1].m_Handler = (IUIButtonClickHandler) this;
    this.btn_Add[1].m_BtnID1 = 9;
    this.btn_Add[1].SetButtonEffectType(e_EffectType.e_Scale);
    this.btn_Add[1].transition = (Selectable.Transition) 0;
    this.Tmp2 = this.Tmp1.GetChild(2).GetChild(0);
    this.Img_Fusion_R[1] = this.Tmp2.GetComponent<Image>();
    this.Tmp2 = this.Tmp1.GetChild(2).GetChild(0).GetChild(0);
    this.Img_Fusion_Add[1] = this.Tmp2.GetComponent<Image>();
    this.Img_Fusion_Add[1].sprite = this.door.LoadSprite("UI_con_icon_05");
    ((MaskableGraphic) this.Img_Fusion_Add[1]).material = this.door.LoadMaterial();
    this.Img_Fusion_Add[1].SetNativeSize();
    ((Component) this.Img_Fusion_Add[1]).gameObject.SetActive(false);
    this.Tmp2 = this.Tmp1.GetChild(2).GetChild(0).GetChild(1);
    this.text_SkillNeedQty = this.Tmp2.GetComponent<UIText>();
    this.text_SkillNeedQty.font = this.TTFont;
    for (int index = 0; index < 3; ++index)
    {
      this.Tmp2 = this.Tmp1.GetChild(3 + index);
      this.mHIbtnItemRT[index] = this.Tmp2.GetComponent<RectTransform>();
      this.btn_Skill_ItemStore[index] = this.Tmp2.GetComponent<UIButton>();
      this.btn_Skill_ItemStore[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Skill_ItemStore[index].m_BtnID1 = 12;
      this.btn_Skill_ItemStore[index].m_BtnID2 = index;
      this.btn_Skill_ItemStore[index].SetButtonEffectType(e_EffectType.e_Scale);
      this.btn_Skill_ItemStore[index].transition = (Selectable.Transition) 0;
      this.Hbtn_Need[index] = this.Tmp2.GetChild(0).GetComponent<UIHIBtn>();
      this.Hbtn_Need[index].m_BtnID2 = index;
      this.Hbtn_Need[index].m_Handler = (IUIHIBtnClickHandler) this;
      this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Need[index]).transform, eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false, bClickSound: false);
      this.Lbtn_Need[index] = this.Tmp2.GetChild(1).GetComponent<UILEBtn>();
      this.GUIM.InitLordEquipImg(((Component) this.Lbtn_Need[index]).transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      ((Component) this.Lbtn_Need[index]).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
      this.Img_Skill_ItemStore[index] = this.Tmp2.GetChild(2).GetComponent<Image>();
      this.text_NeedQty[index] = this.Tmp2.GetChild(3).GetComponent<UIText>();
      this.text_NeedQty[index].font = this.TTFont;
    }
    this.Tmp2 = this.Tmp1.GetChild(6);
    this.text_FusionName = this.Tmp2.GetComponent<UIText>();
    this.text_FusionName.font = this.TTFont;
    this.Tmp2 = this.Tmp1.GetChild(7);
    this.text_SkillName = this.Tmp2.GetComponent<UIText>();
    this.text_SkillName.font = this.TTFont;
    this.Tmp2 = this.Tmp1.GetChild(8);
    this.text_SkillItemQty = this.Tmp2.GetComponent<UIText>();
    this.text_SkillItemQty.font = this.TTFont;
    this.Tmp2 = this.Tmp1.GetChild(9);
    this.text_Type = this.Tmp2.GetComponent<UIText>();
    this.text_Type.font = this.TTFont;
    this.text_Type.text = this.DM.mStringTable.GetStringByID((uint) (ushort) (14653U + (uint) this.mType));
    this.Tmp2 = this.Tmp1.GetChild(10);
    this.Hbtn_Fusion[1] = this.Tmp2.GetComponent<UIHIBtn>();
    this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Fusion[1]).transform, eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0);
    this.Tmp1 = this.Tmp.GetChild(2).GetChild(1);
    this.btn_I = this.Tmp1.GetComponent<UIButton>();
    if (this.GUIM.IsArabic)
      ((Component) this.btn_I).gameObject.AddComponent<ArabicItemTextureRot>();
    this.btn_I.m_Handler = (IUIButtonClickHandler) this;
    this.btn_I.m_BtnID1 = 10;
    this.btn_I.m_EffectType = e_EffectType.e_Scale;
    this.btn_I.transition = (Selectable.Transition) 0;
    this.Tmp1 = this.Tmp.GetChild(2).GetChild(3).GetChild(0);
    this.Img_PetSkill[0] = this.Tmp1.GetComponent<Image>();
    ((MaskableGraphic) this.Img_PetSkill[0]).material = this.GUIM.GetSkillMaterial();
    this.Tmp1 = this.Tmp.GetChild(2).GetChild(3).GetChild(1);
    this.Img_PetSkill[1] = this.Tmp1.GetComponent<Image>();
    this.Img_PetSkill[1].sprite = this.GUIM.LoadFrameSprite("sk");
    ((MaskableGraphic) this.Img_PetSkill[1]).material = this.GUIM.GetFrameMaterial();
    this.Tmp1 = this.Tmp.GetChild(2).GetChild(4);
    this.btn_Skill = this.Tmp1.GetComponent<UIButton>();
    this.btn_Skill.m_BtnID1 = 11;
    this.btn_Skill.m_Handler = (IUIButtonClickHandler) this;
    UIButtonHint uiButtonHint = ((Component) this.btn_Skill).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint.m_Handler = (MonoBehaviour) this;
    if (this.mType == (byte) 0)
    {
      this.Tmp.GetChild(2).GetChild(2).gameObject.SetActive(false);
      this.Tmp.GetChild(2).GetChild(3).gameObject.SetActive(false);
      ((Component) this.btn_Skill).gameObject.SetActive(false);
    }
    this.Tmp1 = this.Tmp.GetChild(3);
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.text_Kind = this.Tmp2.GetComponent<UIText>();
    this.text_Kind.font = this.TTFont;
    this.text_Kind.text = this.DM.mStringTable.GetStringByID(14656U);
    this.Tmp1 = this.Tmp.GetChild(4);
    this.m_ScrollPanel = this.Tmp1.GetChild(0).GetComponent<ScrollPanel>();
    this.m_ScrollPanel.m_ScrollPanelID = 1;
    this.Tmp2 = this.Tmp1.GetChild(1).GetChild(0);
    this.GUIM.InitianHeroItemImg(((Component) this.Tmp2.GetComponent<UIHIBtn>()).transform, eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false, bClickSound: false);
    this.Tmp2 = this.Tmp1.GetChild(1).GetChild(6);
    this.Tmp2.GetComponent<UIButton>().m_BtnID1 = 7;
    this.Tmp2 = this.Tmp1.GetChild(1).GetChild(1);
    this.Tmp2.GetComponent<UIText>().font = this.TTFont;
    this.Tmp2 = this.Tmp1.GetChild(1).GetChild(2);
    this.Tmp2.GetComponent<UIText>().font = this.TTFont;
    this.Tmp2 = this.Tmp1.GetChild(1).GetChild(3);
    this.Tmp2.GetComponent<UIText>().font = this.TTFont;
    this.tmplist.Clear();
    for (int index = 0; index < this.mFusionlist.Count; ++index)
      this.tmplist.Add(80f);
    this.m_ScrollPanel.IntiScrollPanel(433f, 0.0f, 0.0f, this.tmplist, 8, (IUpDateScrollPanel) this);
    this.mContentRT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
    this.m_ScrollPanel.GetComponent<CScrollRect>();
    this.BarrackMax = 0U;
    uint num1 = 0;
    uint effectBaseVal;
    if (this.mType == (byte) 0)
    {
      this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETLOEETRY_TRAINING_CAPACITY);
      effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETLOEETRY_MAKE_SPEED);
    }
    else
    {
      this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_PETSKILL_SKILLCASTITEMMAKE);
      effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETSKILL_MAKE_SKILLSTONE_SPEED);
    }
    this.BarrackMax = this.BarrackMax * (10000U + num1) / 10000U;
    this.bRDOutput = this.CheckFusion(this.tmpItemCraftIndex);
    uint num2 = 0;
    Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
    if (this.mType == (byte) 0 && recordByKey.Color >= (byte) 1 && recordByKey.Color <= (byte) 4)
      num2 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM) (166 + (int) recordByKey.Color - 1));
    if (num2 >= 9900U)
      num2 = 9900U;
    this.tmpEGA_Cost = (float) (1.0 - (double) num2 / 10000.0);
    float num3 = 0.0f;
    float num4 = (float) (10000U + effectBaseVal) - num3;
    if ((double) num4 <= 100.0)
      num4 = 100f;
    this.tmpEGA = 10000f / num4;
    this.UnitMax = this.CheckMax(this.BarrackMax);
    this.Tmp = this.GameT.GetChild(1);
    this.DResourcesT = this.Tmp.GetChild(1);
    this.m_DResources = this.DResourcesT.GetComponent<DemandResources>();
    this.GUIM.InitDemandResources(this.DResourcesT, 555f, 111f, true);
    this.RD_T = this.Tmp.GetChild(2);
    this.Tmp2 = this.RD_T.GetChild(0);
    this.m_UnitRS = this.Tmp2.GetComponent<UnitResourcesSlider>();
    this.GUIM.InitUnitResourcesSlider(this.Tmp2, eUnitSlider.Barrack, 0U, this.BarrackMax, 0.7f);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.BtnIncrease, this.spArray.m_Sprites[4], mmaterial);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.BtnLessen, this.spArray.m_Sprites[5], mmaterial);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.Input, this.spArray.m_Sprites[8], mmaterial);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_sliderBG1, this.spArray.m_Sprites[6], mmaterial);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_sliderBG2, this.spArray.m_Sprites[7], mmaterial);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_Img, this.spArray.m_Sprites[9], mmaterial);
    if (this.mType == (byte) 0)
    {
      this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_micon, this.spArray.m_Sprites[11], mmaterial);
      this.GUIM.SetUnitResourcesSliderSize(this.Tmp2, eUnitSliderSize.m_micon, -95f, 33f, 40f, 40f, 0.0f, 0.0f);
    }
    else
      this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_micon, this.spArray.m_Sprites[10], mmaterial);
    this.m_UnitRS.BtnInputText.m_Handler = (IUIButtonClickHandler) this;
    this.m_UnitRS.BtnInputText.m_BtnID1 = 6;
    this.m_UnitRS.m_Handler = (IUIUnitRSliderHandler) this;
    this.m_UnitRS.m_ID = 1;
    this.Tmp2 = this.RD_T.GetChild(1);
    this.Img_FusionCompleted[0] = this.Tmp2.GetComponent<Image>();
    this.Tmp3 = this.Tmp2.GetChild(0);
    this.Img_FusionCompleted[1] = this.Tmp3.GetComponent<Image>();
    this.Tmp3 = this.Tmp2.GetChild(1);
    this.Img_FusionCompleted[2] = this.Tmp3.GetComponent<Image>();
    this.Img_FusionCompleted[2].sprite = this.door.LoadSprite("UI_main_money_02");
    ((MaskableGraphic) this.Img_FusionCompleted[2]).material = material;
    this.Img_FusionCompleted[2].SetNativeSize();
    this.Tmp3 = this.Tmp2.GetChild(2);
    this.text_Gemstone = this.Tmp3.GetComponent<UIText>();
    this.text_Gemstone.font = this.TTFont;
    this.Tmp2 = this.RD_T.GetChild(2);
    this.Img_Fusion[0] = this.Tmp2.GetComponent<Image>();
    this.Tmp3 = this.Tmp2.GetChild(0);
    this.Img_Fusion[1] = this.Tmp3.GetComponent<Image>();
    this.Tmp3 = this.Tmp2.GetChild(1);
    this.text_Time = this.Tmp3.GetComponent<UIText>();
    this.text_Time.font = this.TTFont;
    this.Tmp2 = this.RD_T.GetChild(3);
    this.btn_FusionCompleted = this.Tmp2.GetComponent<UIButton>();
    this.btn_FusionCompleted.m_Handler = (IUIButtonClickHandler) this;
    this.btn_FusionCompleted.m_BtnID1 = 4;
    this.btn_FusionCompleted.SetButtonEffectType(e_EffectType.e_Scale);
    this.btn_FusionCompleted.transition = (Selectable.Transition) 0;
    this.Tmp3 = this.Tmp2.GetChild(0);
    this.text_FusionCompleted = this.Tmp3.GetComponent<UIText>();
    this.text_FusionCompleted.font = this.TTFont;
    this.text_FusionCompleted.text = this.DM.mStringTable.GetStringByID(14658U);
    this.btn_FusionCompleted.m_Text = this.text_FusionCompleted;
    this.Tmp2 = this.RD_T.GetChild(4);
    this.btn_Fusion = this.Tmp2.GetComponent<UIButton>();
    this.btn_Fusion.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Fusion.m_BtnID1 = 3;
    this.btn_Fusion.SetButtonEffectType(e_EffectType.e_Scale);
    this.btn_Fusion.transition = (Selectable.Transition) 0;
    this.Tmp3 = this.Tmp2.GetChild(0);
    this.text_Fusion = this.Tmp3.GetComponent<UIText>();
    this.text_Fusion.font = this.TTFont;
    this.text_Fusion.text = this.DM.mStringTable.GetStringByID(14657U);
    this.btn_Fusion.m_Text = this.text_Fusion;
    this.Tmp1 = this.Tmp.GetChild(3);
    this.NotRD_T = this.Tmp1.GetComponent<Transform>();
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.Img_RDLock = this.Tmp2.GetComponent<Image>();
    this.Tmp2 = this.Tmp1.GetChild(1);
    this.btn_RD = this.Tmp2.GetComponent<UIButton>();
    this.btn_RD.m_Handler = (IUIButtonClickHandler) this;
    this.btn_RD.m_BtnID1 = 5;
    this.btn_RD.SetButtonEffectType(e_EffectType.e_Scale);
    this.btn_RD.transition = (Selectable.Transition) 0;
    this.Tmp3 = this.Tmp2.GetChild(0);
    this.text_RDbtn = this.Tmp3.GetComponent<UIText>();
    this.text_RDbtn.font = this.TTFont;
    this.Tmp2 = this.Tmp1.GetChild(2);
    this.text_RD = this.Tmp2.GetComponent<UIText>();
    this.text_RD.font = this.TTFont;
    this.Img_LockBG = this.Tmp.GetChild(0).GetComponent<Image>();
    this.Img_Lock = this.Tmp.GetChild(4).GetComponent<Image>();
    this.btn_Lock = this.Tmp.GetChild(5).GetComponent<UIButton>();
    this.btn_Lock.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Lock.m_BtnID1 = 1;
    this.btn_Lock.SetButtonEffectType(e_EffectType.e_Scale);
    this.btn_Lock.transition = (Selectable.Transition) 0;
    this.LockPanel = this.Tmp.GetChild(6);
    UIButton component1 = this.LockPanel.GetChild(0).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 2;
    UIButton component2 = this.LockPanel.GetChild(1).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 2;
    this.Tmp = this.GameT.GetChild(2);
    this.Img_EXIT = this.Tmp.GetComponent<Image>();
    this.Img_EXIT.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.Img_EXIT).material = material;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.Img_EXIT).enabled = false;
    this.Tmp = this.GameT.GetChild(2).GetChild(0);
    this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = material;
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.SetButtonEffectType(e_EffectType.e_Scale);
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    if (this.mType == (byte) 0)
    {
      ((Component) this.Img_Fusion_Info[0]).gameObject.SetActive(true);
      ((Component) this.text_FusionName).gameObject.SetActive(true);
      if ((double) this.PM.mUIFusion_Y > -1.0)
        this.m_ScrollPanel.GoTo(this.PM.mUIFusion_Idx, this.PM.mUIFusion_Y);
      ((Component) this.btn_ItemInfo).gameObject.SetActive(true);
      ((Component) this.Hbtn_Fusion[1]).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.Img_Fusion_Info[0]).gameObject.SetActive(false);
      ((Component) this.text_SkillName).gameObject.SetActive(true);
      this.m_ScrollPanel.GoTo((int) this.tmpItemCraftIndex);
      ((Component) this.btn_ItemInfo).gameObject.SetActive(false);
      ((Component) this.Hbtn_Fusion[1]).gameObject.SetActive(true);
    }
    ((Component) this.text_SkillItemQty).gameObject.SetActive(true);
    this.ReSetFusionData(this.mFusionlist[(int) this.tmpItemCraftIndex], true);
    this.UpdateLcokBtnType();
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 4);
  }

  public void ReSetFusionData(ushort mKey, bool bReSet = false)
  {
    if (this.bRDOutput)
    {
      ((Graphic) this.Img_Fusion_R[0]).color = Color.white;
      ((Graphic) this.Img_Fusion_Add[0]).color = Color.white;
      ((Graphic) this.text_FusionNeedQty).color = Color.white;
      if (this.mType == (byte) 0)
      {
        ((Graphic) this.Hbtn_Fusion[0].HIImage).color = Color.white;
        ((Graphic) this.Hbtn_Fusion[0].CircleImage).color = Color.white;
        ((Graphic) this.text_FusionName).color = Color.white;
      }
      else
      {
        ((Graphic) this.Hbtn_Fusion[1].HIImage).color = Color.white;
        ((Graphic) this.Hbtn_Fusion[1].CircleImage).color = Color.white;
        ((Graphic) this.Img_Fusion_R[1]).color = Color.white;
        ((Graphic) this.Img_Fusion_Add[1]).color = Color.white;
        ((Graphic) this.text_SkillNeedQty).color = Color.white;
        ((Graphic) this.text_SkillName).color = Color.white;
        for (int index = 0; index < 3; ++index)
        {
          ((Graphic) this.Hbtn_Need[index].HIImage).color = Color.white;
          ((Graphic) this.Hbtn_Need[index].CircleImage).color = Color.white;
          ((Graphic) this.Lbtn_Need[index].BackPanel).color = Color.white;
          ((Graphic) this.Lbtn_Need[index].LEImage).color = Color.white;
          ((Graphic) this.text_NeedQty[index]).color = Color.white;
        }
        ((Graphic) this.Img_PetSkill[0]).color = Color.white;
        ((Graphic) this.Img_PetSkill[1]).color = Color.white;
      }
      ((Graphic) this.text_SkillItemQty).color = this.c_ItemQty;
      for (int index = 0; index < 5; ++index)
      {
        ((Graphic) this.m_DResources.BtnResources[index]).color = Color.white;
        ((Graphic) this.m_DResources.ImgResources[index]).color = Color.white;
        ((Graphic) this.m_DResources.TextResources[index]).color = Color.white;
      }
    }
    else
    {
      ((Graphic) this.Img_Fusion_R[0]).color = Color.gray;
      ((Graphic) this.Img_Fusion_Add[0]).color = Color.gray;
      ((Graphic) this.text_FusionNeedQty).color = Color.gray;
      if (this.mType == (byte) 0)
      {
        ((Graphic) this.Hbtn_Fusion[0].HIImage).color = Color.gray;
        ((Graphic) this.Hbtn_Fusion[0].CircleImage).color = Color.gray;
        ((Graphic) this.text_FusionName).color = Color.gray;
      }
      else
      {
        ((Graphic) this.Hbtn_Fusion[1].HIImage).color = Color.gray;
        ((Graphic) this.Hbtn_Fusion[1].CircleImage).color = Color.gray;
        ((Graphic) this.Img_Fusion_R[1]).color = Color.gray;
        ((Graphic) this.Img_Fusion_Add[1]).color = Color.gray;
        ((Graphic) this.text_SkillNeedQty).color = Color.gray;
        ((Graphic) this.text_SkillName).color = Color.gray;
        for (int index = 0; index < 3; ++index)
        {
          ((Graphic) this.Hbtn_Need[index].HIImage).color = Color.gray;
          ((Graphic) this.Hbtn_Need[index].CircleImage).color = Color.gray;
          ((Graphic) this.Lbtn_Need[index].BackPanel).color = Color.gray;
          ((Graphic) this.Lbtn_Need[index].LEImage).color = Color.gray;
          ((Graphic) this.text_NeedQty[index]).color = Color.gray;
        }
        ((Graphic) this.Img_PetSkill[0]).color = Color.gray;
        ((Graphic) this.Img_PetSkill[1]).color = Color.gray;
      }
      ((Graphic) this.text_SkillItemQty).color = Color.gray;
      for (int index = 0; index < 5; ++index)
      {
        ((Graphic) this.m_DResources.BtnResources[index]).color = Color.gray;
        ((Graphic) this.m_DResources.ImgResources[index]).color = Color.gray;
        ((Graphic) this.m_DResources.TextResources[index]).color = Color.gray;
      }
    }
    this.mItemCount = (byte) 0;
    this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(mKey);
    if (this.tmpFD.Fusion_Kind == (byte) 2)
    {
      for (int index = 0; index < 3; ++index)
      {
        if (this.tmpFD.ItemData[index].ItemCount > (ushort) 0)
        {
          ++this.mItemCount;
          this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.ItemData[index].ItemID);
          bool flag = this.GUIM.IsLeadItem(this.tmpEquip.EquipKind);
          if ((UnityEngine.Object) this.btn_Skill_ItemStore[index] != (UnityEngine.Object) null)
          {
            ((Component) this.btn_Skill_ItemStore[index]).gameObject.SetActive(true);
            ((Component) this.Img_Skill_ItemStore[index]).gameObject.SetActive(this.DM.TotalShopItemData.Find(this.tmpFD.ItemData[index].ItemID) != (ushort) 0);
          }
          if (flag)
          {
            this.GUIM.ChangeLordEquipImg(((Component) this.Lbtn_Need[index]).transform, this.tmpFD.ItemData[index].ItemID, this.tmpFD.ItemData[index].Rank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
            ((Component) this.Lbtn_Need[index]).gameObject.SetActive(true);
            ((Component) this.Hbtn_Need[index]).gameObject.SetActive(false);
          }
          else
          {
            this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_Need[index]).transform, eHeroOrItem.Item, this.tmpFD.ItemData[index].ItemID, (byte) 0, this.tmpFD.ItemData[index].Rank);
            ((Component) this.Lbtn_Need[index]).gameObject.SetActive(false);
            ((Component) this.Hbtn_Need[index]).gameObject.SetActive(true);
          }
          ((Component) this.text_NeedQty[index]).gameObject.SetActive(true);
        }
        else
        {
          ((Component) this.Hbtn_Need[index]).gameObject.SetActive(false);
          ((Component) this.Lbtn_Need[index]).gameObject.SetActive(false);
          ((Component) this.text_NeedQty[index]).gameObject.SetActive(false);
          if ((UnityEngine.Object) this.btn_Skill_ItemStore[index] != (UnityEngine.Object) null)
            ((Component) this.btn_Skill_ItemStore[index]).gameObject.SetActive(false);
        }
      }
    }
    else
    {
      for (int index = 0; index < 3; ++index)
      {
        ((Component) this.Hbtn_Need[index]).gameObject.SetActive(false);
        ((Component) this.Lbtn_Need[index]).gameObject.SetActive(false);
        ((Component) this.text_NeedQty[index]).gameObject.SetActive(false);
      }
    }
    if (this.mItemCount == (byte) 1)
    {
      this.mFusionItemRT.anchoredPosition = new Vector2(50.5f, -182f);
      this.mHIbtnItemRT[0].anchoredPosition = new Vector2(208.5f, -182f);
    }
    else if (this.mItemCount == (byte) 2)
    {
      this.mFusionItemRT.anchoredPosition = new Vector2(-28.5f, -182f);
      this.mHIbtnItemRT[0].anchoredPosition = new Vector2(129.5f, -182f);
      this.mHIbtnItemRT[1].anchoredPosition = new Vector2(287.5f, -182f);
    }
    else if (this.mItemCount == (byte) 3)
    {
      this.mFusionItemRT.anchoredPosition = new Vector2(-73.5f, -182f);
      this.mHIbtnItemRT[0].anchoredPosition = new Vector2(56.5f, -182f);
      this.mHIbtnItemRT[1].anchoredPosition = new Vector2(187.5f, -182f);
      this.mHIbtnItemRT[2].anchoredPosition = new Vector2(318.5f, -182f);
    }
    this.UnitMax = this.CheckMax(this.BarrackMax);
    this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
    if (this.mType == (byte) 0)
    {
      this.PM.mPetFusionItemID = (int) this.tmpFD.Fusion_ItemID;
      this.text_FusionName.text = this.DM.mStringTable.GetStringByID((uint) this.tmpEquip.EquipName);
      this.text_FusionName.SetAllDirty();
      this.text_FusionName.cachedTextGenerator.Invalidate();
      this.btn_Scale.enabled = true;
    }
    else
    {
      this.PM.mPetSkillItemID = (int) this.tmpFD.Fusion_ItemID;
      UIItemInfo.SetNameProperties(this.text_SkillName, (UIText) null, this.Cstr_Name, (CString) null, ref this.tmpEquip);
      this.text_SkillName.SetAllDirty();
      this.text_SkillName.cachedTextGenerator.Invalidate();
      this.btn_Scale.enabled = false;
      this.tmpPetD = this.PM.PetTable.GetRecordByKey(this.tmpEquip.SyntheticParts[0].SyntheticItem);
      this.skill = this.PM.PetSkillTable.GetRecordByKey(this.tmpPetD.PetSkill[2]);
      CString SpriteName = StringManager.Instance.StaticString1024();
      SpriteName.Append('s');
      SpriteName.IntToFormat((long) this.skill.Icon, 5);
      SpriteName.AppendFormat("{0}");
      this.Img_PetSkill[0].sprite = this.GUIM.LoadSkillSprite(SpriteName);
    }
    this.Quantity = this.DM.GetCurItemQuantity(this.tmpFD.Fusion_ItemID, (byte) 0);
    this.Cstr_SkillItemQty.ClearString();
    this.Cstr_SkillItemQty.IntToFormat((long) this.Quantity, bNumber: true);
    this.Cstr_SkillItemQty.AppendFormat(this.DM.mStringTable.GetStringByID(79U));
    this.text_SkillItemQty.text = this.Cstr_SkillItemQty.ToString();
    this.text_SkillItemQty.SetAllDirty();
    this.text_SkillItemQty.cachedTextGenerator.Invalidate();
    uint x = !this.bRDOutput ? 1U : (!this.DM.bSoldierSave || !this.DM.bSetExpediton ? (bReSet ? this.UnitMax : (uint) this.m_UnitRS.m_slider.value) : this.PM.m_FusionQty);
    if (this.bRDOutput)
    {
      this.NotRD_T.gameObject.SetActive(false);
      this.RD_T.gameObject.SetActive(true);
      if (this.tmpFD.Fusion_Kind < (byte) 2)
        this.m_DResources.gameObject.SetActive(true);
      else if (this.tmpFD.Fusion_Kind == (byte) 2)
        this.m_DResources.gameObject.SetActive(false);
      this.DM.bSoldierSave = false;
      this.DM.bSetExpediton = false;
      this.Cstr.ClearString();
      if (this.mType == (byte) 0)
      {
        if (x > 0U || this.PM.Fusion_Lock == 1)
        {
          if (this.PM.Fusion_Lock == 2)
            this.PM.Fusion_SliderValue = (long) x;
          else if (this.PM.Fusion_Lock == 1 && this.PM.Fusion_SliderValue <= (long) this.BarrackMax)
          {
            x = (uint) this.PM.Fusion_SliderValue;
          }
          else
          {
            this.PM.Fusion_Lock = 2;
            this.PM.Fusion_SliderValue = (long) x;
          }
        }
      }
      else if (x > 0U || this.PM.FusionSkill_Lock == 1)
      {
        if (this.PM.FusionSkill_Lock == 2)
          this.PM.FusionSkill_SliderValue = (long) x;
        else if (this.PM.FusionSkill_Lock == 1 && this.PM.FusionSkill_SliderValue <= (long) this.BarrackMax)
        {
          x = (uint) this.PM.FusionSkill_SliderValue;
        }
        else
        {
          this.PM.FusionSkill_Lock = 2;
          this.PM.FusionSkill_SliderValue = (long) x;
        }
      }
      this.m_UnitRS.m_slider.value = (double) x;
      this.m_UnitRS.Value = (long) x;
      StringManager.IntToStr(this.Cstr, (long) x, bNumber: true);
      this.m_UnitRS.m_inputText.text = this.Cstr.ToString();
      this.m_UnitRS.m_inputText.SetAllDirty();
      this.m_UnitRS.m_inputText.cachedTextGenerator.Invalidate();
    }
    else
    {
      if (this.mType == (byte) 0)
      {
        this.Cstr_RD.ClearString();
        this.Cstr_RD.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.TechData.GetRecordByKey(this.tmpFD.Science).TechName));
        this.Cstr_RD.AppendFormat(this.DM.mStringTable.GetStringByID(3775U));
        this.text_RD.text = this.Cstr_RD.ToString();
        this.text_RDbtn.text = this.DM.mStringTable.GetStringByID(3776U);
      }
      else
      {
        this.text_RD.text = this.DM.mStringTable.GetStringByID(14665U);
        this.text_RDbtn.text = this.DM.mStringTable.GetStringByID(14666U);
      }
      this.text_RD.SetAllDirty();
      this.text_RD.cachedTextGenerator.Invalidate();
      this.text_RDbtn.SetAllDirty();
      this.text_RDbtn.cachedTextGenerator.Invalidate();
      this.NotRD_T.gameObject.SetActive(true);
      this.RD_T.gameObject.SetActive(false);
    }
    if (this.tmpFD.Fusion_Kind < (byte) 2)
    {
      this.m_DResources.gameObject.SetActive(true);
      ((Component) this.btn_Add[0]).gameObject.SetActive(true);
      ((Component) this.btn_Add[1]).gameObject.SetActive(false);
    }
    else
    {
      this.m_DResources.gameObject.SetActive(false);
      ((Component) this.btn_Add[0]).gameObject.SetActive(false);
      ((Component) this.btn_Add[1]).gameObject.SetActive(true);
    }
    this.SetDRformURS((double) x);
  }

  public uint CheckMax(uint MaxValue)
  {
    uint[] numArray = new uint[6];
    uint num1 = MaxValue;
    numArray[5] = (uint) this.DM.PetResource.CurrentStock;
    if (this.tmpFD.Fusion_Kind < (byte) 2)
    {
      for (int index = 0; index < 5; ++index)
        numArray[index] = this.DM.Resource[index].Stock;
      if (this.Resources[0] > 0U)
      {
        uint num2 = numArray[0] / GameConstants.appCeil((float) this.Resources[0] * this.tmpEGA_Cost);
        if (num2 < num1)
          num1 = num2;
      }
      if (this.Resources[1] > 0U)
      {
        uint num3 = numArray[1] / GameConstants.appCeil((float) this.Resources[1] * this.tmpEGA_Cost);
        if (num3 < num1)
          num1 = num3;
      }
      if (this.Resources[2] > 0U)
      {
        uint num4 = numArray[2] / GameConstants.appCeil((float) this.Resources[2] * this.tmpEGA_Cost);
        if (num4 < num1)
          num1 = num4;
      }
      if (this.Resources[3] > 0U)
      {
        uint num5 = numArray[3] / GameConstants.appCeil((float) this.Resources[3] * this.tmpEGA_Cost);
        if (num5 < num1)
          num1 = num5;
      }
      if (this.Resources[4] > 0U)
      {
        uint num6 = numArray[4] / GameConstants.appCeil((float) this.Resources[4] * this.tmpEGA_Cost);
        if (num6 < num1)
          num1 = num6;
      }
    }
    else
    {
      for (int index = 0; index < (int) this.mItemCount; ++index)
      {
        if (this.m_NeedItem[index].ItemCount > (ushort) 0)
        {
          uint num7 = (uint) this.DM.GetCurItemQuantity(this.tmpFD.ItemData[index].ItemID, this.tmpFD.ItemData[index].Rank) / GameConstants.appCeil((float) this.m_NeedItem[index].ItemCount * this.tmpEGA_Cost);
          if (num7 < num1)
            num1 = num7;
        }
      }
    }
    if (this.Resources[6] > 0U)
    {
      uint num8 = numArray[5] / GameConstants.appCeil((float) this.Resources[6] * this.tmpEGA_Cost);
      if (num8 < num1)
        num1 = num8;
    }
    return num1;
  }

  public bool CheckFusion(ushort mIndex)
  {
    bool flag = false;
    if (this.mFusionlist.Count > (int) mIndex)
    {
      this.tmpFD = this.PM.bActFusioncutdown ? this.DM.FusionDataTable_Act.GetRecordByKey(this.mFusionlist[(int) mIndex]) : this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int) mIndex]);
      Array.Clear((Array) this.m_NeedItem, 0, this.m_NeedItem.Length);
      if (this.tmpFD.Fusion_Kind < (byte) 2)
      {
        this.Resources[0] = this.tmpFD.FoodRequire;
        this.Resources[1] = this.tmpFD.StoneRequire;
        this.Resources[2] = this.tmpFD.WoodRequire;
        this.Resources[3] = this.tmpFD.IronRequire;
        this.Resources[4] = this.tmpFD.MoneyRequire;
      }
      else
      {
        for (int index = 0; index < 3; ++index)
          this.m_NeedItem[index] = this.tmpFD.ItemData[index];
      }
      this.Resources[5] = this.tmpFD.TimeRequire;
      this.Resources[6] = this.tmpFD.PetRequire;
      if (this.mType == (byte) 0 && (this.tmpFD.Science == (ushort) 0 || this.DM.GetTechLevel(this.tmpFD.Science) > (byte) 0))
        flag = true;
      if (this.mType == (byte) 1)
      {
        this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
        this.CurPetData = this.PM.FindPetData(this.tmpEquip.SyntheticParts[0].SyntheticItem);
        flag = this.CurPetData != null && this.CurPetData.Enhance == (byte) 2;
      }
      if (this.mType == (byte) 0)
        this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_Fusion[0]).transform, eHeroOrItem.Item, this.tmpFD.Fusion_ItemID, (byte) 0, (byte) 0);
      else
        this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_Fusion[1]).transform, eHeroOrItem.Item, this.tmpFD.Fusion_ItemID, (byte) 0, (byte) 0);
    }
    return flag;
  }

  public void SetDRformURS(double value)
  {
    if ((UnityEngine.Object) this.DResourcesT == (UnityEngine.Object) null)
      return;
    if (this.bRDOutput)
    {
      if (this.mType == (byte) 0)
        this.PM.Fusion_SliderValue = (long) value;
      else
        this.PM.FusionSkill_SliderValue = (long) value;
    }
    if (this.tmpFD.Fusion_Kind < (byte) 2)
    {
      for (int index = 0; index < 5; ++index)
        this.Rvalue[index] = (long) (value * (double) GameConstants.appCeil((float) this.Resources[index] * this.tmpEGA_Cost));
      this.GUIM.SetDemandResourcesText(this.DResourcesT, this.Rvalue);
    }
    this.SetPetResourcesText(value);
    this.btn_Fusion.ForTextChange(e_BtnType.e_Normal);
    this.btn_FusionCompleted.ForTextChange(e_BtnType.e_Normal);
    this.needDiamond = 0U;
    this.UnitMax = this.CheckMax(this.BarrackMax);
    if (value == 0.0)
      this.btn_FusionCompleted.ForTextChange(e_BtnType.e_ChangeText);
    else if (value > (double) this.UnitMax)
    {
      bool flag = false;
      for (int Type = 0; Type < 5; ++Type)
      {
        if (this.Rvalue[Type] > (long) this.DM.Resource[Type].Stock)
        {
          this.needDiamond += this.DM.GetResourceExchange((PriceListType) Type, (uint) this.Rvalue[Type] - this.DM.Resource[Type].Stock);
          flag = true;
        }
      }
      this.Rvalue[5] = (long) (value * (double) GameConstants.appCeil((float) this.Resources[6] * this.tmpEGA_Cost));
      if ((double) this.Rvalue[5] > this.DM.PetResource.CurrentStock)
      {
        this.needDiamond += this.DM.GetResourceExchange(PriceListType.PetResource, (uint) ((double) this.Rvalue[5] - this.DM.PetResource.CurrentStock));
        flag = true;
      }
      for (int index = 0; index < 3; ++index)
      {
        if (this.tmpFD.ItemData[index].ItemID > (ushort) 0)
        {
          ushort InKey = this.DM.TotalShopItemData.Find(this.tmpFD.ItemData[index].ItemID);
          ushort curItemQuantity = this.DM.GetCurItemQuantity(this.tmpFD.ItemData[index].ItemID, this.tmpFD.ItemData[index].Rank);
          if (InKey > (ushort) 0 && value * (double) this.tmpFD.ItemData[index].ItemCount > (double) curItemQuantity)
          {
            this.tmpST = this.DM.StoreData.GetRecordByKey(InKey);
            this.needDiamond += (uint) ((double) this.tmpST.Price * (value * (double) this.tmpFD.ItemData[index].ItemCount - (double) curItemQuantity));
          }
        }
      }
      if (flag || !this.IsItemenough)
        this.btn_Fusion.ForTextChange(e_BtnType.e_ChangeText);
    }
    uint Num = GameConstants.appCeil((float) ((uint) value * this.Resources[5]) * this.tmpEGA);
    this.needDiamond += this.DM.GetResourceExchange(PriceListType.PetFusion, Num);
    this.Cstr_Gemstone.ClearString();
    this.Cstr_Gemstone.IntToFormat((long) this.needDiamond, bNumber: true);
    this.Cstr_Gemstone.AppendFormat("{0}");
    this.text_Gemstone.text = this.Cstr_Gemstone.ToString();
    this.text_Gemstone.SetAllDirty();
    this.text_Gemstone.cachedTextGenerator.Invalidate();
    if (this.DM.RoleAttr.Diamond > this.needDiamond)
      this.btn_FusionCompleted.ForTextChange(e_BtnType.e_Normal);
    this.Cstr_Time.ClearString();
    this.Cstr_Time.Append(this.DM.mStringTable.GetStringByID(14659U));
    this.tmpValue = Num / 3600U;
    if (this.tmpValue < 24U)
    {
      this.Cstr_Time.IntToFormat((long) (this.tmpValue % 60U), 2);
      this.Cstr_Time.IntToFormat((long) (Num / 60U % 60U), 2);
      this.Cstr_Time.IntToFormat((long) (Num % 60U), 2);
      this.Cstr_Time.AppendFormat("{0}:{1}:{2}");
    }
    else if (this.GUIM.IsArabic)
    {
      this.Cstr_Time.IntToFormat((long) (this.tmpValue % 24U), 2);
      this.Cstr_Time.IntToFormat((long) (Num / 60U % 60U), 2);
      this.Cstr_Time.IntToFormat((long) (Num % 60U), 2);
      this.Cstr_Time.IntToFormat((long) (this.tmpValue / 24U));
      this.Cstr_Time.AppendFormat("{0}:{1}:{2} {3}d");
    }
    else
    {
      this.Cstr_Time.IntToFormat((long) (this.tmpValue / 24U));
      this.Cstr_Time.IntToFormat((long) (this.tmpValue % 24U), 2);
      this.Cstr_Time.IntToFormat((long) (Num / 60U % 60U), 2);
      this.Cstr_Time.IntToFormat((long) (Num % 60U), 2);
      this.Cstr_Time.AppendFormat("{0}d {1}:{2}:{3}");
    }
    this.text_Time.text = this.Cstr_Time.ToString();
    this.text_Time.SetAllDirty();
    this.text_Time.cachedTextGenerator.Invalidate();
  }

  public void SetPetResourcesText(double value)
  {
    this.IsItemenough = true;
    this.IsItemenough_Store = true;
    this.Rvalue[5] = (long) (value * (double) GameConstants.appCeil((float) this.Resources[6] * this.tmpEGA_Cost));
    if (this.tmpFD.Fusion_Kind < (byte) 2)
    {
      this.Cstr_FusionNeedQty.ClearString();
      if (this.DM.PetResource.CurrentStock < (double) this.Rvalue[5])
      {
        if (this.GUIM.IsArabic)
        {
          GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint) this.Rvalue[5]);
          this.Cstr_FusionNeedQty.Append("/<color=#E5004F>");
          GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint) this.DM.PetResource.CurrentStock);
          this.Cstr_FusionNeedQty.Append("</color>");
        }
        else
        {
          this.Cstr_FusionNeedQty.Append("<color=#E5004F>");
          GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint) this.DM.PetResource.CurrentStock);
          this.Cstr_FusionNeedQty.AppendFormat("</color>/");
          GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint) this.Rvalue[5]);
        }
        ((Component) this.Img_Fusion_Add[0]).gameObject.SetActive(true);
      }
      else
      {
        if (this.GUIM.IsArabic)
        {
          GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint) this.Rvalue[5]);
          this.Cstr_FusionNeedQty.AppendFormat("/");
          GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint) this.DM.PetResource.CurrentStock);
        }
        else
        {
          GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint) this.DM.PetResource.CurrentStock);
          this.Cstr_FusionNeedQty.AppendFormat("/");
          GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint) this.Rvalue[5]);
        }
        ((Component) this.Img_Fusion_Add[0]).gameObject.SetActive(false);
      }
      this.text_FusionNeedQty.text = this.Cstr_FusionNeedQty.ToString();
      this.text_FusionNeedQty.SetAllDirty();
      this.text_FusionNeedQty.cachedTextGenerator.Invalidate();
    }
    else
    {
      this.Cstr_SkillNeedQty.ClearString();
      if (this.DM.PetResource.CurrentStock < (double) this.Rvalue[5])
      {
        if (this.GUIM.IsArabic)
        {
          GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint) this.Rvalue[5]);
          this.Cstr_SkillNeedQty.Append("/<color=#E5004F>");
          GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint) this.DM.PetResource.CurrentStock);
          this.Cstr_SkillNeedQty.Append("</color>");
        }
        else
        {
          this.Cstr_SkillNeedQty.Append("<color=#E5004F>");
          GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint) this.DM.PetResource.CurrentStock);
          this.Cstr_SkillNeedQty.AppendFormat("</color>/");
          GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint) this.Rvalue[5]);
        }
        ((Component) this.Img_Fusion_Add[1]).gameObject.SetActive(true);
      }
      else
      {
        if (this.GUIM.IsArabic)
        {
          GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint) this.Rvalue[5]);
          this.Cstr_SkillNeedQty.AppendFormat("/");
          GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint) this.DM.PetResource.CurrentStock);
        }
        else
        {
          GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint) this.DM.PetResource.CurrentStock);
          this.Cstr_SkillNeedQty.AppendFormat("/");
          GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint) this.Rvalue[5]);
        }
        ((Component) this.Img_Fusion_Add[1]).gameObject.SetActive(false);
      }
      this.text_SkillNeedQty.text = this.Cstr_SkillNeedQty.ToString();
      this.text_SkillNeedQty.SetAllDirty();
      this.text_SkillNeedQty.cachedTextGenerator.Invalidate();
      for (int index = 0; index < 3; ++index)
      {
        this.Rvalue[5] = (long) (value * (double) GameConstants.appCeil((float) this.tmpFD.ItemData[index].ItemCount * this.tmpEGA_Cost));
        this.Cstr_SkillItemNeedQty[index].ClearString();
        if (this.tmpFD.ItemData[index].ItemCount > (ushort) 0)
        {
          this.Quantity = this.DM.GetCurItemQuantity(this.tmpFD.ItemData[index].ItemID, this.tmpFD.ItemData[index].Rank);
          if ((long) this.Quantity < this.Rvalue[5])
          {
            if (this.GUIM.IsArabic)
            {
              GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[index], (uint) this.Rvalue[5]);
              this.Cstr_SkillItemNeedQty[index].Append("/<color=#E5004F>");
              GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[index], (uint) this.Quantity);
              this.Cstr_SkillItemNeedQty[index].Append("</color>");
            }
            else
            {
              this.Cstr_SkillItemNeedQty[index].Append("<color=#E5004F>");
              GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[index], (uint) this.Quantity);
              this.Cstr_SkillItemNeedQty[index].AppendFormat("</color>/");
              GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[index], (uint) this.Rvalue[5]);
            }
            this.IsItemenough = false;
            if (this.IsItemenough_Store && this.DM.TotalShopItemData.Find(this.tmpFD.ItemData[index].ItemID) == (ushort) 0)
              this.IsItemenough_Store = false;
          }
          else if (this.GUIM.IsArabic)
          {
            GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[index], (uint) this.Rvalue[5]);
            this.Cstr_SkillItemNeedQty[index].AppendFormat("/");
            GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[index], (uint) this.Quantity);
          }
          else
          {
            GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[index], (uint) this.Quantity);
            this.Cstr_SkillItemNeedQty[index].AppendFormat("/");
            GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[index], (uint) this.Rvalue[5]);
          }
        }
        this.text_NeedQty[index].text = this.Cstr_SkillItemNeedQty[index].ToString();
        this.text_NeedQty[index].SetAllDirty();
        this.text_NeedQty[index].cachedTextGenerator.Invalidate();
      }
    }
  }

  public bool CheckCanFusion(ushort mIdxID)
  {
    bool flag = false;
    this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(mIdxID);
    this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
    this.CurPetData = this.PM.FindPetData(this.tmpEquip.SyntheticParts[0].SyntheticItem);
    if (this.CurPetData != null && this.CurPetData.Enhance > (byte) 1)
      flag = true;
    return flag;
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((UnityEngine.Object) this.tmpItem[panelObjectIdx] == (UnityEngine.Object) null)
    {
      this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
      this.Hbtn_btn[panelObjectIdx] = item.transform.GetChild(0).GetComponent<UIHIBtn>();
      this.text_ItemName[panelObjectIdx] = item.transform.GetChild(1).GetComponent<UIText>();
      this.text_ItemNameSkill[panelObjectIdx] = item.transform.GetChild(2).GetComponent<UIText>();
      this.text_ItemCount[panelObjectIdx] = item.transform.GetChild(3).GetComponent<UIText>();
      this.tmpImgLock[panelObjectIdx] = item.transform.GetChild(4).GetComponent<Image>();
      this.tmpImgSelect[panelObjectIdx] = item.transform.GetChild(5).GetComponent<Image>();
      this.btn_Contract[panelObjectIdx] = item.transform.GetChild(6).GetComponent<UIButton>();
      this.btn_Contract[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
    }
    if (!(bool) (UnityEngine.Object) this.Hbtn_btn[panelObjectIdx] || dataIdx >= this.mFusionlist.Count)
      return;
    if ((int) this.tmpItemCraftIndex == dataIdx)
    {
      ((Component) this.tmpImgSelect[panelObjectIdx]).gameObject.SetActive(true);
      this.ItemSelect = 0.0f;
      this.mItemIdx = dataIdx;
      this.mItemIdx2 = panelObjectIdx;
    }
    else
    {
      ((Component) this.tmpImgSelect[panelObjectIdx]).gameObject.SetActive(false);
      ((Graphic) this.tmpImgSelect[panelObjectIdx]).color = new Color(1f, 1f, 1f, 0.0f);
    }
    this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[dataIdx]);
    this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_btn[panelObjectIdx]).transform, eHeroOrItem.Item, this.tmpFD.Fusion_ItemID, (byte) 0, (byte) 0);
    this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
    if (this.mType == (byte) 0)
    {
      if (this.tmpFD.Science != (ushort) 0 && this.DM.GetTechLevel(this.tmpFD.Science) == (byte) 0)
      {
        ((Component) this.tmpImgLock[panelObjectIdx]).gameObject.SetActive(true);
        ((Graphic) this.Hbtn_btn[panelObjectIdx].HIImage).color = Color.gray;
        ((Graphic) this.Hbtn_btn[panelObjectIdx].CircleImage).color = Color.gray;
        ((Graphic) this.text_ItemName[panelObjectIdx]).color = Color.gray;
      }
      else
      {
        ((Component) this.tmpImgLock[panelObjectIdx]).gameObject.SetActive(false);
        ((Graphic) this.Hbtn_btn[panelObjectIdx].HIImage).color = Color.white;
        ((Graphic) this.Hbtn_btn[panelObjectIdx].CircleImage).color = Color.white;
        ((Graphic) this.text_ItemName[panelObjectIdx]).color = Color.white;
      }
      this.text_ItemName[panelObjectIdx].text = this.DM.mStringTable.GetStringByID((uint) this.tmpEquip.EquipName);
      this.text_ItemName[panelObjectIdx].SetAllDirty();
      this.text_ItemName[panelObjectIdx].cachedTextGenerator.Invalidate();
      ((Component) this.text_ItemName[panelObjectIdx]).gameObject.SetActive(true);
      ((Component) this.text_ItemNameSkill[panelObjectIdx]).gameObject.SetActive(false);
      ((Component) this.text_ItemCount[panelObjectIdx]).gameObject.SetActive(false);
    }
    else
    {
      this.Cstr_SkillItemName[panelObjectIdx].ClearString();
      UIItemInfo.SetNameProperties(this.text_ItemNameSkill[panelObjectIdx], (UIText) null, this.Cstr_SkillItemName[panelObjectIdx], (CString) null, ref this.tmpEquip);
      this.text_ItemNameSkill[panelObjectIdx].SetAllDirty();
      this.text_ItemNameSkill[panelObjectIdx].cachedTextGenerator.Invalidate();
      this.Quantity = this.DM.GetCurItemQuantity(this.tmpFD.Fusion_ItemID, (byte) 0);
      this.Cstr_SkillItem[panelObjectIdx].ClearString();
      this.Cstr_SkillItem[panelObjectIdx].IntToFormat((long) this.Quantity, bNumber: true);
      if (this.GUIM.IsArabic)
        this.Cstr_SkillItem[panelObjectIdx].AppendFormat("{0}x");
      else
        this.Cstr_SkillItem[panelObjectIdx].AppendFormat("x{0}");
      this.text_ItemCount[panelObjectIdx].text = this.Cstr_SkillItem[panelObjectIdx].ToString();
      this.text_ItemCount[panelObjectIdx].SetAllDirty();
      this.text_ItemCount[panelObjectIdx].cachedTextGenerator.Invalidate();
      ((Component) this.text_ItemName[panelObjectIdx]).gameObject.SetActive(false);
      ((Component) this.text_ItemNameSkill[panelObjectIdx]).gameObject.SetActive(true);
      ((Component) this.text_ItemCount[panelObjectIdx]).gameObject.SetActive(true);
      if (!this.CheckCanFusion(this.mFusionlist[dataIdx]))
      {
        ((Component) this.tmpImgLock[panelObjectIdx]).gameObject.SetActive(true);
        ((Graphic) this.text_ItemNameSkill[panelObjectIdx]).color = Color.gray;
        ((Graphic) this.text_ItemCount[panelObjectIdx]).color = Color.gray;
        ((Graphic) this.Hbtn_btn[panelObjectIdx].HIImage).color = Color.gray;
        ((Graphic) this.Hbtn_btn[panelObjectIdx].CircleImage).color = Color.gray;
      }
      else
      {
        ((Component) this.tmpImgLock[panelObjectIdx]).gameObject.SetActive(false);
        ((Graphic) this.text_ItemNameSkill[panelObjectIdx]).color = Color.white;
        ((Graphic) this.text_ItemCount[panelObjectIdx]).color = Color.white;
        ((Graphic) this.Hbtn_btn[panelObjectIdx].HIImage).color = Color.white;
        ((Graphic) this.Hbtn_btn[panelObjectIdx].CircleImage).color = Color.white;
      }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 1:
        ushort ID = 14684;
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.ClearString();
        if (this.mType == (byte) 0)
        {
          if (this.PM.Fusion_Lock == 2)
            this.PM.Fusion_Lock = 1;
          else if (this.PM.Fusion_Lock == 1)
          {
            this.PM.Fusion_Lock = 2;
            ID = (ushort) 14685;
          }
          cstring.IntToFormat(NetworkManager.UserID);
          cstring.AppendFormat("{0}_Fusion_Lock_UseID");
          PlayerPrefs.SetString(cstring.ToString(), NetworkManager.UserID.ToString());
          cstring.ClearString();
          cstring.IntToFormat(NetworkManager.UserID);
          cstring.AppendFormat("{0}_Fusion_Lock");
          PlayerPrefs.SetString(cstring.ToString(), this.PM.Fusion_Lock.ToString());
          cstring.ClearString();
          cstring.IntToFormat(NetworkManager.UserID);
          cstring.AppendFormat("{0}_Fusion_SliderValue");
          PlayerPrefs.SetString(cstring.ToString(), this.PM.Fusion_SliderValue.ToString());
        }
        else
        {
          if (this.PM.FusionSkill_Lock == 2)
            this.PM.FusionSkill_Lock = 1;
          else if (this.PM.FusionSkill_Lock == 1)
          {
            this.PM.FusionSkill_Lock = 2;
            ID = (ushort) 14685;
          }
          cstring.IntToFormat(NetworkManager.UserID);
          cstring.AppendFormat("{0}_FusionSkill_Lock_UseID");
          PlayerPrefs.SetString(cstring.ToString(), NetworkManager.UserID.ToString());
          cstring.ClearString();
          cstring.IntToFormat(NetworkManager.UserID);
          cstring.AppendFormat("{0}_FusionSkill_Lock");
          PlayerPrefs.SetString(cstring.ToString(), this.PM.FusionSkill_Lock.ToString());
          cstring.ClearString();
          cstring.IntToFormat(NetworkManager.UserID);
          cstring.AppendFormat("{0}_FusionSkill_SliderValue");
          PlayerPrefs.SetString(cstring.ToString(), this.PM.FusionSkill_SliderValue.ToString());
        }
        this.GUIM.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID((uint) ID), (ushort) byte.MaxValue);
        this.UpdateLcokBtnType();
        break;
      case 2:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14684U), (ushort) byte.MaxValue);
        break;
      case 3:
        if (this.DM.queueBarData[34].bActive)
        {
          this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(14660U), this.DM.mStringTable.GetStringByID(14661U), YesText: this.DM.mStringTable.GetStringByID(3925U), NoText: this.DM.mStringTable.GetStringByID(3926U));
          break;
        }
        this.FusionQty = (uint) this.m_UnitRS.Value;
        if (this.FusionQty == 0U)
        {
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(5703U), (ushort) byte.MaxValue);
          break;
        }
        if (!this.CheckMaxItem())
        {
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(887U), (ushort) byte.MaxValue);
          break;
        }
        if (sender.m_BtnType == e_BtnType.e_Normal && GUIManager.Instance.ShowUILock(EUILock.PetFusion))
        {
          this.PM.m_ItemCraftQty = (ushort) this.m_UnitRS.Value;
          this.PM.SendItemCraft_Start(this.mFusionlist[(int) this.tmpItemCraftIndex], (ushort) this.FusionQty, (byte) 0);
          if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
            break;
          this.door.CloseMenu();
          break;
        }
        if (sender.m_BtnType != e_BtnType.e_ChangeText)
          break;
        if (!this.IsItemenough)
        {
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(14686U), (ushort) byte.MaxValue);
          break;
        }
        GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(3942U), (ushort) byte.MaxValue);
        break;
      case 4:
        this.FusionQty = (uint) this.m_UnitRS.Value;
        if (this.FusionQty == 0U)
        {
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(5703U), (ushort) byte.MaxValue);
          break;
        }
        if (sender.m_BtnType != e_BtnType.e_Normal)
          break;
        if (!this.CheckMaxItem())
        {
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(887U), (ushort) byte.MaxValue);
          break;
        }
        if (!this.IsItemenough_Store)
        {
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(14686U), (ushort) byte.MaxValue);
          break;
        }
        if (this.DM.RoleAttr.Diamond >= this.needDiamond)
        {
          this.PM.m_ItemCraftQty = (ushort) this.m_UnitRS.Value;
          if (this.GUIM.OpenCheckCrystal(this.needDiamond, (byte) 5, (int) this.m_eWindow << 16 | 100) || !GUIManager.Instance.ShowUILock(EUILock.PetFusion))
            break;
          this.PM.SendItemCraft_Start(this.mFusionlist[(int) this.tmpItemCraftIndex], (ushort) this.FusionQty, (byte) 1);
          break;
        }
        GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(3966U), DataManager.Instance.mStringTable.GetStringByID(646U), 1, YesText: DataManager.Instance.mStringTable.GetStringByID(3968U), NoText: DataManager.Instance.mStringTable.GetStringByID(4025U));
        break;
      case 5:
        if (this.mType == (byte) 0)
        {
          this.GUIM.OpenTechTree(this.tmpFD.Science, true);
          break;
        }
        this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int) this.tmpItemCraftIndex]);
        this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
        this.PM.OpenPetUI(0, (int) this.tmpEquip.SyntheticParts[0].SyntheticItem);
        break;
      case 6:
        this.GUIM.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
        this.GUIM.m_UICalculator.OpenCalculator(this.m_UnitRS.MaxValue, this.m_UnitRS.Value, -283f, -45f, this.m_UnitRS, 0L);
        break;
      case 7:
        this.Tmp = ((Component) sender).gameObject.transform.parent;
        int btnId1 = this.Tmp.GetComponent<ScrollPanelItem>().m_BtnID1;
        if (btnId1 == -1)
          break;
        this.tmpItemCraftIndex = (ushort) btnId1;
        if (this.mItemIdx != -1)
        {
          ((Component) this.tmpImgSelect[this.mItemIdx2]).gameObject.SetActive(false);
          ((Graphic) this.tmpImgSelect[this.mItemIdx2]).color = new Color(1f, 1f, 1f, 0.0f);
        }
        this.mItemIdx = btnId1;
        this.mItemIdx2 = this.Tmp.GetComponent<ScrollPanelItem>().m_BtnID2;
        ((Component) this.tmpImgSelect[this.mItemIdx2]).gameObject.SetActive(true);
        this.ItemSelect = 0.0f;
        this.bRDOutput = this.CheckFusion((ushort) btnId1);
        this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int) this.tmpItemCraftIndex]);
        uint num1 = 0;
        Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
        if (this.mType == (byte) 0 && recordByKey.Color >= (byte) 1 && recordByKey.Color <= (byte) 4)
          num1 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM) (166 + (int) recordByKey.Color - 1));
        if (num1 >= 9900U)
          num1 = 9900U;
        this.tmpEGA_Cost = (float) (1.0 - (double) num1 / 10000.0);
        this.ReSetFusionData(this.mFusionlist[btnId1], true);
        this.UpdateLcokBtnType();
        break;
      case 8:
        this.door.OpenMenu(EGUIWindow.UI_OpenBox, 1, (int) this.tmpFD.Fusion_ItemID);
        break;
      case 9:
        this.DM.bSoldierSave = true;
        this.DM.bSetExpediton = true;
        int num2 = (int) (this.m_UnitRS.m_slider.value * (double) GameConstants.appCeil((float) this.Resources[6] * this.tmpEGA_Cost));
        if (!this.bRDOutput)
          num2 = 1 * (int) GameConstants.appCeil((float) this.Resources[6] * this.tmpEGA_Cost);
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, 655361, num2);
        break;
      case 10:
        if (this.mType == (byte) 0)
        {
          this.Cstr_Info.ClearString();
          this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14677U));
          this.Cstr_Info.Append("\n");
          this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14678U));
          this.Cstr_Info.Append("\n");
          this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14679U));
          this.Cstr_Info.Append("\n");
          this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14680U));
          this.Cstr_Info.Append("\n");
          this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(14671U), this.Cstr_Info.ToString(), bInfo: true, BackExit: true);
          break;
        }
        this.Cstr_Info.ClearString();
        this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14682U));
        this.Cstr_Info.Append("\n");
        this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14681U));
        this.Cstr_Info.Append("\n");
        this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(14672U), this.Cstr_Info.ToString(), bInfo: true, BackExit: true);
        break;
      case 12:
        this.DM.bSoldierSave = true;
        this.DM.bSetExpediton = true;
        if (sender.m_BtnID2 >= this.btn_Skill_ItemStore.Length || !((UnityEngine.Object) this.btn_Skill_ItemStore[sender.m_BtnID2] != (UnityEngine.Object) null))
          break;
        ushort Num = (ushort) (this.m_UnitRS.m_slider.value * (double) GameConstants.appCeil((float) this.tmpFD.ItemData[sender.m_BtnID2].ItemCount * this.tmpEGA_Cost));
        if (!this.bRDOutput)
          Num = (ushort) (1U * GameConstants.appCeil((float) this.tmpFD.ItemData[sender.m_BtnID2].ItemCount * this.tmpEGA_Cost));
        GUIManager.Instance.OpenItemFilterUI(this.tmpFD.ItemData[sender.m_BtnID2].ItemID, Num);
        break;
    }
  }

  public bool CheckMaxItem()
  {
    bool flag = false;
    ushort curItemQuantity = this.DM.GetCurItemQuantity(this.tmpFD.Fusion_ItemID, (byte) 0);
    if (this.DM.queueBarData[34].bActive && (int) this.PM.ItemCraftID == (int) this.mFusionlist[(int) this.tmpItemCraftIndex])
      curItemQuantity += this.PM.ItemCraftCount;
    if ((long) curItemQuantity + this.m_UnitRS.Value <= (long) ushort.MaxValue)
      flag = true;
    return flag;
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 0:
        this.DM.bSoldierSave = true;
        this.DM.bSetExpediton = true;
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 34);
        break;
      case 1:
        MallManager.Instance.Send_Mall_Info();
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int) this.tmpItemCraftIndex]);
    this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
    this.tmpPetD = this.PM.PetTable.GetRecordByKey(this.tmpEquip.SyntheticParts[0].SyntheticItem);
    this.CurPetData = this.PM.FindPetData(this.tmpEquip.SyntheticParts[0].SyntheticItem);
    if (this.CurPetData == null)
      return;
    int index1 = 0;
    for (int index2 = 3; index2 > 0; --index2)
    {
      if (this.PM.PetSkillTable.GetRecordByKey(this.tmpPetD.PetSkill[index2]).Diamond > (ushort) 0)
        index1 = index2;
    }
    this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.CurentLv, this.tmpPetD.ID, this.tmpPetD.PetSkill[index1], this.CurPetData.SkillLv[index1], Vector2.zero);
  }

  public void OnButtonUp(UIButtonHint sender) => this.GUIM.m_Hint.Hide(true);

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
  }

  public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
  {
    URS.m_slider.value = (double) mValue;
    URS.SliderValueChange();
    if (this.mType == (byte) 0)
      this.PM.Fusion_SliderValue = mValue;
    else
      this.PM.FusionSkill_SliderValue = mValue;
  }

  public override void OnClose()
  {
    if (this.mType == (byte) 0)
    {
      this.PM.mUIFusion_Y = this.mContentRT.anchoredPosition.y;
      this.PM.mUIFusion_Idx = this.m_ScrollPanel.GetTopIdx();
    }
    if (this.AssetName != null)
      GUIManager.Instance.RemoveSpriteAsset(this.AssetName);
    if (this.Cstr != null)
      StringManager.Instance.DeSpawnString(this.Cstr);
    if (this.Cstr_Gemstone != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Gemstone);
    if (this.Cstr_Time != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Time);
    if (this.Cstr_RD != null)
      StringManager.Instance.DeSpawnString(this.Cstr_RD);
    if (this.Cstr_FusionNeedQty != null)
      StringManager.Instance.DeSpawnString(this.Cstr_FusionNeedQty);
    if (this.Cstr_SkillNeedQty != null)
      StringManager.Instance.DeSpawnString(this.Cstr_SkillNeedQty);
    if (this.Cstr_SkillItemQty != null)
      StringManager.Instance.DeSpawnString(this.Cstr_SkillItemQty);
    if (this.Cstr_Info != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Info);
    if (this.Cstr_UnitRS != null)
      StringManager.Instance.DeSpawnString(this.Cstr_UnitRS);
    if (this.Cstr_Name != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Name);
    for (int index = 0; index < 3; ++index)
    {
      if (this.Cstr_SkillItemNeedQty[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_SkillItemNeedQty[index]);
    }
    for (int index = 0; index < 8; ++index)
    {
      if (this.Cstr_SkillItem[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_SkillItem[index]);
      if (this.Cstr_SkillItemName[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_SkillItemName[index]);
    }
    if (this.DM.bSoldierSave)
      this.PM.m_FusionQty = (uint) this.m_UnitRS.Value;
    this.GUIM.ClearCalculator();
  }

  public override void UpdateTime(bool bOnSecond)
  {
    for (int index = 0; index < 8; ++index)
    {
      if ((UnityEngine.Object) this.tmpImgSelect[index] != (UnityEngine.Object) null && ((Component) this.tmpImgSelect[index]).gameObject.activeSelf)
      {
        this.ItemSelect += Time.smoothDeltaTime;
        if ((double) this.ItemSelect >= 0.0)
        {
          if ((double) this.ItemSelect >= 2.0)
            this.ItemSelect = 0.0f;
          float a = (double) this.ItemSelect <= 1.0 ? this.ItemSelect : 2f - this.ItemSelect;
          ((Graphic) this.tmpImgSelect[index]).color = new Color(1f, 1f, 1f, a);
        }
      }
    }
    if (this.mType != (byte) 0 || !((UnityEngine.Object) this.Img_Fusion_Info[0] != (UnityEngine.Object) null) || !((Component) this.Img_Fusion_Info[0]).gameObject.activeSelf || !((UnityEngine.Object) this.Img_Fusion_Info[1] != (UnityEngine.Object) null))
      return;
    this.ItemInfo += Time.smoothDeltaTime;
    if ((double) this.ItemInfo >= 2.0)
      this.ItemInfo = 0.0f;
    ((Graphic) this.Img_Fusion_Info[1]).color = new Color(1f, 1f, 1f, (double) this.ItemInfo <= 1.0 ? this.ItemInfo : 2f - this.ItemInfo);
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.text_Title != (UnityEngine.Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Type != (UnityEngine.Object) null && ((Behaviour) this.text_Type).enabled)
    {
      ((Behaviour) this.text_Type).enabled = false;
      ((Behaviour) this.text_Type).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Kind != (UnityEngine.Object) null && ((Behaviour) this.text_Kind).enabled)
    {
      ((Behaviour) this.text_Kind).enabled = false;
      ((Behaviour) this.text_Kind).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Fusion != (UnityEngine.Object) null && ((Behaviour) this.text_Fusion).enabled)
    {
      ((Behaviour) this.text_Fusion).enabled = false;
      ((Behaviour) this.text_Fusion).enabled = true;
    }
    if ((UnityEngine.Object) this.text_FusionCompleted != (UnityEngine.Object) null && ((Behaviour) this.text_FusionCompleted).enabled)
    {
      ((Behaviour) this.text_FusionCompleted).enabled = false;
      ((Behaviour) this.text_FusionCompleted).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Gemstone != (UnityEngine.Object) null && ((Behaviour) this.text_Gemstone).enabled)
    {
      ((Behaviour) this.text_Gemstone).enabled = false;
      ((Behaviour) this.text_Gemstone).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Time != (UnityEngine.Object) null && ((Behaviour) this.text_Time).enabled)
    {
      ((Behaviour) this.text_Time).enabled = false;
      ((Behaviour) this.text_Time).enabled = true;
    }
    if ((UnityEngine.Object) this.text_RD != (UnityEngine.Object) null && ((Behaviour) this.text_RD).enabled)
    {
      ((Behaviour) this.text_RD).enabled = false;
      ((Behaviour) this.text_RD).enabled = true;
    }
    if ((UnityEngine.Object) this.text_RDbtn != (UnityEngine.Object) null && ((Behaviour) this.text_RDbtn).enabled)
    {
      ((Behaviour) this.text_RDbtn).enabled = false;
      ((Behaviour) this.text_RDbtn).enabled = true;
    }
    if ((UnityEngine.Object) this.text_FusionName != (UnityEngine.Object) null && ((Behaviour) this.text_FusionName).enabled)
    {
      ((Behaviour) this.text_FusionName).enabled = false;
      ((Behaviour) this.text_FusionName).enabled = true;
    }
    if ((UnityEngine.Object) this.text_FusionNeedQty != (UnityEngine.Object) null && ((Behaviour) this.text_FusionNeedQty).enabled)
    {
      ((Behaviour) this.text_FusionNeedQty).enabled = false;
      ((Behaviour) this.text_FusionNeedQty).enabled = true;
    }
    if ((UnityEngine.Object) this.text_SkillNeedQty != (UnityEngine.Object) null && ((Behaviour) this.text_SkillNeedQty).enabled)
    {
      ((Behaviour) this.text_SkillNeedQty).enabled = false;
      ((Behaviour) this.text_SkillNeedQty).enabled = true;
    }
    if ((UnityEngine.Object) this.text_SkillName != (UnityEngine.Object) null && ((Behaviour) this.text_SkillName).enabled)
    {
      ((Behaviour) this.text_SkillName).enabled = false;
      ((Behaviour) this.text_SkillName).enabled = true;
    }
    if ((UnityEngine.Object) this.text_SkillItemQty != (UnityEngine.Object) null && ((Behaviour) this.text_SkillItemQty).enabled)
    {
      ((Behaviour) this.text_SkillItemQty).enabled = false;
      ((Behaviour) this.text_SkillItemQty).enabled = true;
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((UnityEngine.Object) this.text_NeedQty[index] != (UnityEngine.Object) null && ((Behaviour) this.text_NeedQty[index]).enabled)
      {
        ((Behaviour) this.text_NeedQty[index]).enabled = false;
        ((Behaviour) this.text_NeedQty[index]).enabled = true;
      }
    }
    for (int index = 0; index < 8; ++index)
    {
      if ((UnityEngine.Object) this.text_ItemName[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemName[index]).enabled)
      {
        ((Behaviour) this.text_ItemName[index]).enabled = false;
        ((Behaviour) this.text_ItemName[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_ItemNameSkill[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemNameSkill[index]).enabled)
      {
        ((Behaviour) this.text_ItemNameSkill[index]).enabled = false;
        ((Behaviour) this.text_ItemNameSkill[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_ItemCount[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemCount[index]).enabled)
      {
        ((Behaviour) this.text_ItemCount[index]).enabled = false;
        ((Behaviour) this.text_ItemCount[index]).enabled = true;
      }
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((UnityEngine.Object) this.Hbtn_Fusion[index] != (UnityEngine.Object) null && ((Behaviour) this.Hbtn_Fusion[index]).enabled)
        this.Hbtn_Fusion[index].Refresh_FontTexture();
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((UnityEngine.Object) this.Hbtn_Need[index] != (UnityEngine.Object) null && ((Behaviour) this.Hbtn_Need[index]).enabled)
        this.Hbtn_Need[index].Refresh_FontTexture();
    }
    for (int index = 0; index < 8; ++index)
    {
      if ((UnityEngine.Object) this.Hbtn_btn[index] != (UnityEngine.Object) null && ((Behaviour) this.Hbtn_btn[index]).enabled)
        this.Hbtn_btn[index].Refresh_FontTexture();
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_Technology:
        if (this.mType != (byte) 0)
          break;
        this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int) this.tmpItemCraftIndex]);
        if ((int) this.DM.CheckResearchTech == (int) this.tmpFD.Science)
        {
          this.bRDOutput = this.CheckFusion(this.tmpItemCraftIndex);
          this.ReSetFusionData(this.mFusionlist[(int) this.tmpItemCraftIndex]);
          this.UpdateLcokBtnType();
        }
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        break;
      case NetworkNews.Refresh_AttribEffectVal:
        uint effectBaseVal;
        if (this.mType == (byte) 0)
        {
          this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETLOEETRY_TRAINING_CAPACITY);
          effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETLOEETRY_MAKE_SPEED);
        }
        else
        {
          this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_PETSKILL_SKILLCASTITEMMAKE);
          effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETSKILL_MAKE_SKILLSTONE_SPEED);
        }
        this.m_UnitRS.MaxValue = (long) this.BarrackMax;
        this.m_UnitRS.m_slider.maxValue = (double) this.BarrackMax;
        this.Cstr_UnitRS.ClearString();
        StringManager.IntToStr(this.Cstr_UnitRS, (long) this.BarrackMax, bNumber: true);
        this.m_UnitRS.m_TotalText.text = this.Cstr_UnitRS.ToString();
        this.m_UnitRS.m_TotalText.SetAllDirty();
        this.m_UnitRS.m_TotalText.cachedTextGenerator.Invalidate();
        float num1 = 0.0f;
        float num2 = (float) (10000U + effectBaseVal) - num1;
        if ((double) num2 <= 100.0)
          num2 = 100f;
        this.tmpEGA = 10000f / num2;
        this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int) this.tmpItemCraftIndex]);
        uint num3 = 0;
        Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
        if (this.mType == (byte) 0 && recordByKey.Color >= (byte) 1 && recordByKey.Color <= (byte) 4)
          num3 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM) (166 + (int) recordByKey.Color - 1));
        if (num3 >= 9900U)
          num3 = 9900U;
        this.tmpEGA_Cost = (float) (1.0 - (double) num3 / 10000.0);
        this.UnitMax = this.CheckMax(this.BarrackMax);
        if (this.bRDOutput)
          this.SetDRformURS(this.m_UnitRS.m_slider.value);
        else
          this.SetDRformURS(1.0);
        this.UpdateLcokBtnType();
        break;
      default:
        switch (networkNews)
        {
          case NetworkNews.Login:
            this.PM.SortPetData();
            this.UpdateLcokBtnType();
            return;
          case NetworkNews.Refresh_Item:
            this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
            this.bRDOutput = this.CheckFusion(this.tmpItemCraftIndex);
            this.ReSetFusionData(this.mFusionlist[(int) this.tmpItemCraftIndex]);
            this.UpdateLcokBtnType();
            return;
          case NetworkNews.Refresh_FontTextureRebuilt:
            if ((UnityEngine.Object) this.m_DResources != (UnityEngine.Object) null)
              this.m_DResources.Refresh_FontTexture();
            if ((UnityEngine.Object) this.m_UnitRS != (UnityEngine.Object) null)
              this.m_UnitRS.Refresh_FontTexture();
            this.Refresh_FontTexture();
            return;
          case NetworkNews.Refresh_Pet:
            this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
            this.bRDOutput = this.CheckFusion(this.tmpItemCraftIndex);
            this.ReSetFusionData(this.mFusionlist[(int) this.tmpItemCraftIndex]);
            this.UpdateLcokBtnType();
            return;
          default:
            return;
        }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        if (this.mType == (byte) 0 && this.PM.Fusion_Lock == 1 || this.mType == (byte) 1 && this.PM.FusionSkill_Lock == 1)
          break;
        uint effectBaseVal;
        if (this.mType == (byte) 0)
        {
          this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETLOEETRY_TRAINING_CAPACITY);
          effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETLOEETRY_MAKE_SPEED);
        }
        else
        {
          this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_PETSKILL_SKILLCASTITEMMAKE);
          effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETSKILL_MAKE_SKILLSTONE_SPEED);
        }
        float num1 = 0.0f;
        float num2 = (float) (10000U + effectBaseVal) - num1;
        if ((double) num2 <= 100.0)
          num2 = 100f;
        this.tmpEGA = 10000f / num2;
        this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int) this.tmpItemCraftIndex]);
        uint num3 = 0;
        Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
        if (this.mType == (byte) 0 && recordByKey.Color >= (byte) 1 && recordByKey.Color <= (byte) 4)
          num3 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM) (166 + (int) recordByKey.Color - 1));
        if (num3 >= 9900U)
          num3 = 9900U;
        this.tmpEGA_Cost = (float) (1.0 - (double) num3 / 10000.0);
        this.UnitMax = this.CheckMax(this.BarrackMax);
        this.Cstr.ClearString();
        StringManager.IntToStr(this.Cstr, (long) this.UnitMax, bNumber: true);
        this.m_UnitRS.m_slider.value = (double) this.UnitMax;
        this.m_UnitRS.Value = (long) this.UnitMax;
        this.m_UnitRS.m_inputText.text = this.Cstr.ToString();
        this.m_UnitRS.m_inputText.SetAllDirty();
        this.m_UnitRS.m_inputText.cachedTextGenerator.Invalidate();
        this.SetDRformURS((double) this.UnitMax);
        this.Quantity = this.DM.GetCurItemQuantity(this.tmpFD.Fusion_ItemID, (byte) 0);
        this.Cstr_SkillItemQty.ClearString();
        this.Cstr_SkillItemQty.IntToFormat((long) this.Quantity, bNumber: true);
        this.Cstr_SkillItemQty.AppendFormat(this.DM.mStringTable.GetStringByID(79U));
        this.text_SkillItemQty.text = this.Cstr_SkillItemQty.ToString();
        this.text_SkillItemQty.SetAllDirty();
        this.text_SkillItemQty.cachedTextGenerator.Invalidate();
        break;
      case 2:
        this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int) this.tmpItemCraftIndex]);
        this.Quantity = this.DM.GetCurItemQuantity(this.tmpFD.Fusion_ItemID, (byte) 0);
        this.Cstr_SkillItemQty.ClearString();
        this.Cstr_SkillItemQty.IntToFormat((long) this.Quantity, bNumber: true);
        this.Cstr_SkillItemQty.AppendFormat(this.DM.mStringTable.GetStringByID(79U));
        this.text_SkillItemQty.text = this.Cstr_SkillItemQty.ToString();
        this.text_SkillItemQty.SetAllDirty();
        this.text_SkillItemQty.cachedTextGenerator.Invalidate();
        break;
      case 3:
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        this.bRDOutput = this.CheckFusion(this.tmpItemCraftIndex);
        this.ReSetFusionData(this.mFusionlist[(int) this.tmpItemCraftIndex]);
        this.UpdateLcokBtnType();
        break;
      case 100:
        if (!GUIManager.Instance.ShowUILock(EUILock.PetFusion))
          break;
        this.PM.SendItemCraft_Start(this.mFusionlist[(int) this.tmpItemCraftIndex], (ushort) this.FusionQty, (byte) 1);
        break;
    }
  }

  private void SetLockBtnType(int tpye = 0)
  {
    if ((UnityEngine.Object) this.LockPanel == (UnityEngine.Object) null || (UnityEngine.Object) this.btn_Lock == (UnityEngine.Object) null || (UnityEngine.Object) this.Img_Lock == (UnityEngine.Object) null)
      return;
    switch (tpye)
    {
      case 0:
        this.LockPanel.gameObject.SetActive(false);
        ((Component) this.Img_Lock).gameObject.SetActive(false);
        ((Component) this.btn_Lock).gameObject.SetActive(false);
        ((Component) this.Img_LockBG).gameObject.SetActive(false);
        break;
      case 1:
        this.btn_Lock.image.sprite = this.spArray.GetSprite(1);
        this.Img_Lock.sprite = this.spArray.GetSprite(3);
        ((Component) this.btn_Lock).gameObject.SetActive(true);
        ((Component) this.Img_Lock).gameObject.SetActive(true);
        this.LockPanel.gameObject.SetActive(true);
        ((Component) this.Img_LockBG).gameObject.SetActive(true);
        if (!this.bRDOutput)
          break;
        this.SetLockValue();
        break;
      case 2:
        this.btn_Lock.image.sprite = this.spArray.GetSprite(0);
        this.Img_Lock.sprite = this.spArray.GetSprite(2);
        ((Component) this.btn_Lock).gameObject.SetActive(true);
        ((Component) this.Img_Lock).gameObject.SetActive(true);
        this.LockPanel.gameObject.SetActive(false);
        ((Component) this.Img_LockBG).gameObject.SetActive(false);
        break;
    }
  }

  private void UpdateLcokBtnType()
  {
    if (this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 18 || !this.bRDOutput)
      this.SetLockBtnType();
    else if (this.mType == (byte) 0)
      this.SetLockBtnType(this.PM.Fusion_Lock);
    else
      this.SetLockBtnType(this.PM.FusionSkill_Lock);
  }

  private void SetLockValue()
  {
    this.Cstr.ClearString();
    if (this.mType == (byte) 0)
    {
      StringManager.IntToStr(this.Cstr, this.PM.Fusion_SliderValue, bNumber: true);
      this.m_UnitRS.m_slider.value = (double) this.PM.Fusion_SliderValue;
      this.m_UnitRS.Value = this.PM.Fusion_SliderValue;
    }
    else
    {
      StringManager.IntToStr(this.Cstr, this.PM.FusionSkill_SliderValue, bNumber: true);
      this.m_UnitRS.m_slider.value = (double) this.PM.FusionSkill_SliderValue;
      this.m_UnitRS.Value = this.PM.FusionSkill_SliderValue;
    }
    this.m_UnitRS.m_inputText.text = this.Cstr.ToString();
    this.m_UnitRS.m_inputText.SetAllDirty();
    this.m_UnitRS.m_inputText.cachedTextGenerator.Invalidate();
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
