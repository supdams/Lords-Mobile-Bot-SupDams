// Decompiled with JetBrains decompiler
// Type: UIExpedition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIExpedition : 
  GUIWindow,
  IComparer<byte>,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUICalculatorHandler,
  IUIUnitRSliderHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private RectTransform tmpRC;
  private RectTransform Img_TargetRT;
  private RectTransform Text_LoadRT;
  private RectTransform[] Img_HintRT = new RectTransform[3];
  private RectTransform[] Text_HintRT = new RectTransform[3];
  private RectTransform mContentRT;
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform Tmp2;
  private Transform BG_T1;
  private Transform BG_T2;
  private Transform BG_T3;
  private Transform mLoad_T;
  private Transform mLoadBG_T;
  private Transform mTime_T;
  private Transform mTroops_T;
  private Transform mSave_T;
  private Transform mSelectTeam_T;
  private Transform mSelectTeam_LT;
  private Transform mApply_T;
  private Transform mWarlobbyT;
  private UIButton btn_EXIT;
  private UIButton btn_HeroTeam;
  private UIButton btn_Formation;
  private UIButton btn_FormationMenu;
  private UIButton btn_Troops;
  private UIButton btn_Load;
  private UIButton btn_Time;
  public UIButton btn_Expedition;
  private UIButton btn_HeroFormation;
  private UIButton btn_Clear;
  private UIButton[] btn_ItemInput = new UIButton[7];
  private UIButton[] btn_Menu = new UIButton[4];
  private UIButton[] btn_SelectMenu = new UIButton[2];
  private UIButton[] btn_Hero = new UIButton[5];
  private UIButton btn_CaveCheck;
  private UIHIBtn[] btn_HeroImg = new UIHIBtn[5];
  private UIHIBtn btn_MainHeroImg;
  private UIButton btn_SetName;
  private UIButton btn_Save;
  private UIButton[] btn_SelectTeam = new UIButton[10];
  private UIButton btn_Apply;
  private UIButton[] btn_W_MenuSelect = new UIButton[2];
  private UIButton btn_W_MenuBack;
  private UIButton[] btn_W_MenuKind = new UIButton[3];
  private UIButton btn_W_MenuSet;
  private UIButton[] btn_W_InfoBack = new UIButton[2];
  private Image[] Img_Lock = new Image[5];
  private Image[] Img_AddBG = new Image[5];
  private Image[] Img_Leader = new Image[2];
  private Image Img_StatusBG;
  private Image[] Img_StatusBG2 = new Image[3];
  private Image[] Img_HintBG = new Image[3];
  private Image Img_TargetBG;
  private Image Img_MusterTimeBG;
  private Image Img_NoSoldierBG;
  private Image[] Img_Soldier_Kind = new Image[7];
  private Image[] Img_Soldier_Item = new Image[7];
  private Image[] Img_Soldier_ItemFrame = new Image[7];
  private Image Img_Frame;
  private Image[] Img_CaveMain = new Image[2];
  private Image Img_HeroStatus;
  private Image Img_CaveStatus;
  private Image[] Img_SelectMenu = new Image[2];
  private Image[] Img_SelectMenuKind = new Image[2];
  private Image Img_W_SelectIcon;
  private Image Img_W_MenuSelect;
  private Image Img_W_Menu;
  private Sprite[] m_SoldierSprite = new Sprite[16];
  private Sprite[] m_SoldierSpriteFrame = new Sprite[16];
  private Sprite[] mResources = new Sprite[6];
  private Sprite[] mWarlobbyIcon = new Sprite[4];
  private UIText Text_MusterTime;
  private UIText Text_HeroTeam;
  private UIText Text_Formation;
  private UIText[] Text_Troops = new UIText[2];
  private UIText[] Text_Load = new UIText[4];
  private UIText[] Text_Time = new UIText[3];
  private UIText[] Text_Menu = new UIText[4];
  private UIText[] Text_Hint = new UIText[3];
  private UIText[] Text_tmpStr = new UIText[3];
  private UIText[] Text_Soldier_ItemNum = new UIText[7];
  private UIText[] Text_Soldier_ItemName = new UIText[7];
  private UIText Text_CaveMain;
  private UIText[] Text_SelectMenu = new UIText[2];
  private UIText Text_Name;
  private UIText Text_Save;
  private UIText[] Text_D = new UIText[5];
  private UIText[] Text_L = new UIText[5];
  private UIText Text_Apply;
  private UIText Text_btnApply;
  private UIText[] Text_W_Select = new UIText[2];
  private UIText[] Text_W_MenuKind = new UIText[4];
  private UIText Text_W_SelectTilte;
  private UIText Text_W_MenuSet;
  private UIText[] Text_W_Scroll = new UIText[4];
  private CString Cstr;
  private CString[] Cstr_Troops = new CString[2];
  private CString Cstr_MusterTime;
  private CString Cstr_Time;
  private CString Cstr_Accelerate;
  private CString[] Cstr_LoadNum = new CString[2];
  private CString[] Cstr_Soldier_ItemNum = new CString[7];
  private CString[] Cstr_Soldier_Text = new CString[7];
  private CString Cstr_TeamName;
  private CString[] Cstr_WarSoldier_Text = new CString[11];
  private CString[] Cstr_WarSoldierRate_Text = new CString[11];
  private CString Cstr_WarlobbyKindText;
  private CString Cstr_WarlobbySolder;
  private CString Cstr_WarlobbyMaxSolder;
  private CString Cstr_HintNum;
  private ScrollPanel m_ScrollPanel;
  private CScrollRect m_ScrollRect;
  private UnitResourcesSlider m_UnitRS;
  private UnitResourcesSlider[] m_UnitRS_Item = new UnitResourcesSlider[7];
  private UISpritesArray SArray;
  private ScrollPanel m_ScrollPanel_Warlobby;
  private CScrollRect m_ScrollRect_Warlobby;
  private SoldierInfoItem[] m_Warlobby_Item = new SoldierInfoItem[11];
  private bool[] InitSoldierInfoItem = new bool[11];
  private StringBuilder tmpString = new StringBuilder();
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private SoldierData tmpSD;
  private Material FrameMaterial;
  private Material m_BW;
  private Soldier_H[] m_SoldierData = new Soldier_H[16];
  private Soldier_Select[] m_SoldierMax = new Soldier_Select[16];
  private long[] m_Soldier = new long[16];
  private uint[] Hero_ID = new uint[5];
  private uint Hero_Total;
  private uint BaseNum;
  private long SoldierMax;
  private long ExpeditionNum;
  private uint Time_Total;
  private float Distance_Total;
  private long Load_Total;
  private bool bExpeditionHero;
  private bool bLeaderHero;
  private bool bSpeed = true;
  private int LockCount = 5;
  private int tmpListIdx;
  private int MapID;
  private int mStatus;
  private int mResourcesKind;
  private int mOpenKind;
  private float fightButtonTime;
  private uint ResourcesMax;
  private float tmpL;
  private float tmpTime;
  private float tmpLoad;
  private uint EGAKind;
  private uint EGASpeed;
  private uint EGASpeed2;
  private uint EGASpeed3;
  private uint EGASpeed4;
  private uint EGALoadKind;
  private uint EGACapacityKind;
  private uint mBuffTotal;
  private int mSpeedIdx = 16;
  private MapPoint nowMapPoint;
  private int ItemBuffDataIdx;
  private bool bClear;
  private int mExpeditionlimit;
  private byte[] SpeedsortData = new byte[16];
  private byte[] LoadsortData = new byte[16];
  private byte[] ShowListIndex = new byte[16];
  private string AssetName;
  private string AssetName1;
  private string[] m_SoldierName = new string[16];
  private string[] mbtnFormation = new string[2];
  private float ShowTime;
  private Door door;
  private List<float> tmplist = new List<float>();
  private List<float> tmplist_Warlooby = new List<float>();
  private Equip mEquip;
  private Color mtextColor = new Color(1f, 0.845f, 0.1686f);
  private ushort[] mRallyCountDown = new ushort[4];
  private ushort ZoneID;
  private byte PointID;
  private uint GoToMaxSoldier;
  private bool bPVEOpen = true;
  private float[] tmpPVEPower = new float[4];
  private bool bLogin;
  private CString AllyName;
  private bool bCaveMainHero = true;
  private byte mUI_CK = byte.MaxValue;
  private bool bShowSelectC;
  private byte mNewType;
  private TroopMemoryData tmpTMD;
  private byte TMD_Idx;
  private string TMD_Name;
  private byte mWonderId;
  private bool bOpenEnd;
  private GameObject mAllianceWarImg;
  private bool bScrollItemH;
  private bool bScrollItemH1;
  private bool bScrollItemH2;
  private bool bAllZero;
  private byte mUI_WarlobbyK = byte.MaxValue;
  private byte mUI_WarlobbyK_btn = byte.MaxValue;
  private byte mWarlobbySolderList;
  private byte[] mShowSolderIdx = new byte[16];
  private double[] mWarlobbySolderValue = new double[16];
  public uint WarlobbyTroopTotalTroopNum;
  public uint[][] WarlobbyTroopData = new uint[4][];
  private long WarlobbySelectQty;
  private long WarlobbyTroopMax;
  private long[] m_WarlobbySoldier = new long[16];
  private long[] m_NeedWarlobbySoldier = new long[16];
  private byte mWarlobbyKind;
  private byte mSrcollDataIdx;

  public int Compare(byte x, byte y)
  {
    return this.bSpeed ? this.SpeedCompare(x, y) : this.LoadCompare(x, y);
  }

  public int SpeedCompare(byte x, byte y)
  {
    if ((int) x == (int) y)
      return 0;
    Soldier_H soldierH1 = this.m_SoldierData[(int) x];
    Soldier_H soldierH2 = this.m_SoldierData[(int) y];
    if ((int) soldierH1.Speed < (int) soldierH2.Speed)
      return 1;
    return (int) soldierH1.Speed > (int) soldierH2.Speed ? -1 : 0;
  }

  public int LoadCompare(byte x, byte y)
  {
    Soldier_H soldierH1 = this.m_SoldierData[(int) x];
    Soldier_H soldierH2 = this.m_SoldierData[(int) y];
    if ((int) soldierH1.Traffic < (int) soldierH2.Traffic)
      return 1;
    return (int) soldierH1.Traffic > (int) soldierH2.Traffic ? -1 : 0;
  }

  public void OnVauleChang(UnitResourcesSlider sender)
  {
    long num1 = this.ExpeditionNum - this.m_Soldier[sender.m_ID];
    if (num1 + sender.Value > (long) this.Hero_Total + (long) this.mExpeditionlimit)
    {
      double num2 = (double) ((long) this.Hero_Total + (long) this.mExpeditionlimit - num1);
      if (num2 >= 0.0)
      {
        sender.m_slider.value = num2;
        return;
      }
      sender.Value = 0L;
      sender.m_slider.value = 0.0;
    }
    this.Cstr_Soldier_Text[(int) sender.Type].ClearString();
    this.Cstr_Soldier_Text[(int) sender.Type].IntToFormat(sender.Value, bNumber: true);
    this.Cstr_Soldier_Text[(int) sender.Type].AppendFormat("{0}");
    sender.m_inputText.text = this.Cstr_Soldier_Text[(int) sender.Type].ToString();
    sender.m_inputText.SetAllDirty();
    sender.m_inputText.cachedTextGenerator.Invalidate();
    this.m_Soldier[sender.m_ID] = sender.Value;
    if (sender.Value != 0L)
      ((Graphic) sender.m_inputText).color = this.mtextColor;
    else
      ((Graphic) sender.m_inputText).color = Color.white;
    this.Cstr_Soldier_ItemNum[(int) sender.Type].ClearString();
    this.Cstr_Soldier_ItemNum[(int) sender.Type].IntToFormat((long) this.m_SoldierMax[sender.m_ID].Value[0] - this.m_Soldier[sender.m_ID], bNumber: true);
    this.Cstr_Soldier_ItemNum[(int) sender.Type].AppendFormat("{0}");
    this.Text_Soldier_ItemNum[(int) sender.Type].text = this.Cstr_Soldier_ItemNum[(int) sender.Type].ToString();
    this.Text_Soldier_ItemNum[(int) sender.Type].SetAllDirty();
    this.Text_Soldier_ItemNum[(int) sender.Type].cachedTextGenerator.Invalidate();
    this.SetDRformURS(sender.m_ID);
  }

  public void OnTextChang(UnitResourcesSlider sender)
  {
    long num = this.ExpeditionNum - this.m_Soldier[sender.m_ID];
    if (num + sender.Value > (long) this.Hero_Total + (long) this.mExpeditionlimit)
    {
      sender.Value = (long) this.Hero_Total + (long) this.mExpeditionlimit - num;
      sender.m_slider.value = (double) sender.Value;
    }
    this.Cstr_Soldier_Text[(int) sender.Type].ClearString();
    this.Cstr_Soldier_Text[(int) sender.Type].IntToFormat(sender.Value, bNumber: true);
    this.Cstr_Soldier_Text[(int) sender.Type].AppendFormat("{0}");
    sender.m_inputText.text = this.Cstr_Soldier_Text[(int) sender.Type].ToString();
    sender.m_inputText.SetAllDirty();
    sender.m_inputText.cachedTextGenerator.Invalidate();
    this.m_Soldier[sender.m_ID] = sender.Value;
    if (sender.Value != 0L)
      ((Graphic) sender.m_inputText).color = this.mtextColor;
    else
      ((Graphic) sender.m_inputText).color = Color.white;
    this.Cstr_Soldier_ItemNum[(int) sender.Type].ClearString();
    this.Cstr_Soldier_ItemNum[(int) sender.Type].IntToFormat((long) this.m_SoldierMax[sender.m_ID].Value[0] - this.m_Soldier[sender.m_ID], bNumber: true);
    this.Cstr_Soldier_ItemNum[(int) sender.Type].AppendFormat("{0}");
    this.Text_Soldier_ItemNum[(int) sender.Type].text = this.Cstr_Soldier_ItemNum[(int) sender.Type].ToString();
    this.Text_Soldier_ItemNum[(int) sender.Type].SetAllDirty();
    this.Text_Soldier_ItemNum[(int) sender.Type].cachedTextGenerator.Invalidate();
    this.SetDRformURS(sender.m_ID);
  }

  public void SetDRformURS(int Idx)
  {
    this.Load_Total = 0L;
    this.ExpeditionNum = 0L;
    bool flag = false;
    this.mSpeedIdx = 16;
    for (int index1 = 0; index1 < 16; ++index1)
    {
      this.ExpeditionNum += this.m_Soldier[index1];
      this.Load_Total += this.m_Soldier[index1] * (long) this.m_SoldierData[index1].Traffic;
      int index2 = (int) this.SpeedsortData[index1];
      if (!flag && this.m_Soldier[index2] != 0L && (index1 < this.mSpeedIdx || this.m_Soldier[index1] == 0L))
      {
        flag = true;
        this.mSpeedIdx = index1;
        this.Time_Total = GameConstants.appCeil(GameConstants.FastInvSqrt(this.Distance_Total * this.Distance_Total) * ((float) this.m_SoldierData[index2].Speed * this.tmpTime));
        this.Cstr_Time.ClearString();
        if (this.Time_Total > 3600U)
        {
          this.Cstr_Time.IntToFormat((long) (this.Time_Total / 3600U), 2);
          this.Cstr_Time.IntToFormat((long) (this.Time_Total % 3600U / 60U), 2);
          this.Cstr_Time.IntToFormat((long) (this.Time_Total % 60U), 2);
          this.Cstr_Time.AppendFormat("{0}:{1}:{2}");
        }
        else
        {
          this.Cstr_Time.IntToFormat((long) (this.Time_Total / 60U), 2);
          this.Cstr_Time.IntToFormat((long) (this.Time_Total % 60U), 2);
          this.Cstr_Time.AppendFormat("{0}:{1}");
        }
      }
    }
    if (this.ExpeditionNum == 0L)
    {
      this.Cstr_Time.ClearString();
      this.Time_Total = 0U;
      this.Cstr_Time.IntToFormat((long) (this.Time_Total / 60U), 2);
      this.Cstr_Time.IntToFormat((long) (this.Time_Total % 60U), 2);
      this.Cstr_Time.AppendFormat("{0}:{1}");
      this.mSpeedIdx = 16;
      this.bClear = false;
      this.Text_Formation.text = this.mbtnFormation[0];
      ((Graphic) this.Text_Load[0]).color = Color.white;
      ((Graphic) this.Text_Time[0]).color = Color.white;
      if (this.mStatus == 1 && this.mUI_CK != byte.MaxValue)
      {
        ((Component) this.Text_SelectMenu[0]).gameObject.SetActive(false);
        ((Component) this.Text_SelectMenu[1]).gameObject.SetActive(true);
        if (this.mUI_CK < (byte) 2)
          ((Component) this.Img_SelectMenu[0]).gameObject.SetActive(true);
        else
          ((Component) this.Img_SelectMenu[1]).gameObject.SetActive(true);
      }
      if (this.mWarlobbyKind >= (byte) 0 && this.mWarlobbyKind <= (byte) 2 && this.mUI_WarlobbyK != byte.MaxValue)
        this.Set_W_SelectText(this.mUI_WarlobbyK);
    }
    else
    {
      this.bClear = true;
      this.Text_Formation.text = this.mbtnFormation[1];
      ((Graphic) this.Text_Load[0]).color = this.mtextColor;
      ((Graphic) this.Text_Time[0]).color = this.mtextColor;
      if (this.mStatus == 1 && this.mUI_CK != byte.MaxValue)
      {
        ((Component) this.Text_SelectMenu[1]).gameObject.SetActive(false);
        ((Component) this.Img_SelectMenu[0]).gameObject.SetActive(false);
        ((Component) this.Img_SelectMenu[1]).gameObject.SetActive(false);
        ((Component) this.Text_SelectMenu[0]).gameObject.SetActive(true);
      }
      if (this.mWarlobbyKind >= (byte) 0 && this.mWarlobbyKind <= (byte) 2)
        this.Set_W_SelectText(this.mUI_WarlobbyK, true);
    }
    this.Text_Time[0].text = this.Cstr_Time.ToString();
    this.Text_Time[0].SetAllDirty();
    this.Text_Time[0].cachedTextGenerator.Invalidate();
    this.Cstr_Troops[0].ClearString();
    this.Cstr_Troops[1].ClearString();
    if (this.ExpeditionNum > (long) this.Hero_Total)
    {
      this.Cstr_Troops[0].StringToFormat("<color=#e5004fff>");
      this.Cstr_Troops[0].IntToFormat(this.ExpeditionNum, bNumber: true);
      this.Cstr_Troops[0].AppendFormat("{0}{1}</color>");
    }
    else if (this.ExpeditionNum != 0L)
    {
      this.Cstr_Troops[0].StringToFormat("<color=#ffdf2bff>");
      this.Cstr_Troops[0].IntToFormat(this.ExpeditionNum, bNumber: true);
      this.Cstr_Troops[0].AppendFormat("{0}{1}</color>");
    }
    else
    {
      this.Cstr_Troops[0].IntToFormat(this.ExpeditionNum, bNumber: true);
      this.Cstr_Troops[0].AppendFormat("{0}");
    }
    this.Text_Troops[0].text = this.Cstr_Troops[0].ToString();
    this.Text_Troops[0].SetAllDirty();
    this.Text_Troops[0].cachedTextGenerator.Invalidate();
    this.Cstr_Troops[1].IntToFormat((long) this.Hero_Total, bNumber: true);
    if (this.mOpenKind != 10)
    {
      if (this.GUIM.IsArabic)
        this.Cstr_Troops[1].AppendFormat("{0} /");
      else
        this.Cstr_Troops[1].AppendFormat("/ {0}");
    }
    else if (this.GUIM.IsArabic)
      this.Cstr_Troops[1].AppendFormat("<color=#00ff00ff>{0} /</color>");
    else
      this.Cstr_Troops[1].AppendFormat("<color=#00ff00ff>/ {0}</color>");
    this.Text_Troops[1].text = this.Cstr_Troops[1].ToString();
    this.Text_Troops[1].SetAllDirty();
    this.Text_Troops[1].cachedTextGenerator.Invalidate();
    if (this.mStatus == 0)
    {
      this.Cstr_LoadNum[0].ClearString();
      this.Load_Total = (long) ((double) this.Load_Total * (double) this.tmpLoad) / 10000L;
      this.Cstr_LoadNum[0].IntToFormat(this.Load_Total, bNumber: true);
      this.Cstr_LoadNum[0].AppendFormat("{0}");
      this.Text_Load[0].text = this.Cstr_LoadNum[0].ToString();
      this.Text_Load[0].SetAllDirty();
      this.Text_Load[0].cachedTextGenerator.Invalidate();
    }
    else if (this.mStatus == 1)
    {
      this.Load_Total = (long) ((double) this.Load_Total * (double) this.tmpLoad) / 10000L;
      this.Cstr_LoadNum[0].ClearString();
      if (this.mResourcesKind == 1)
        this.Cstr_LoadNum[0].IntToFormat(this.Load_Total / 1000L, bNumber: true);
      else
        this.Cstr_LoadNum[0].IntToFormat(this.Load_Total, bNumber: true);
      this.Cstr_LoadNum[0].AppendFormat("{0}");
      this.Text_Load[0].text = this.Cstr_LoadNum[0].ToString();
      this.Text_Load[0].SetAllDirty();
      this.Text_Load[0].cachedTextGenerator.Invalidate();
      this.Text_Load[0].cachedTextGeneratorForLayout.Invalidate();
    }
    if (!this.bOpenEnd || this.mOpenKind != 6 || this.DM.bChangSoldier || this.DM.mOpenExpeditionNum == this.ExpeditionNum)
      return;
    this.DM.bChangSoldier = true;
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.GameT = this.gameObject.transform;
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.FrameMaterial = this.GUIM.GetFrameMaterial();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.AssetName = nameof (UIExpedition);
    this.AssetName1 = "UI_legion_m";
    this.Cstr = StringManager.Instance.SpawnString();
    this.Cstr_MusterTime = StringManager.Instance.SpawnString();
    this.Cstr_Time = StringManager.Instance.SpawnString();
    this.Cstr_Accelerate = StringManager.Instance.SpawnString();
    this.AllyName = StringManager.Instance.SpawnString();
    for (int index = 0; index < 2; ++index)
    {
      this.Cstr_LoadNum[index] = StringManager.Instance.SpawnString();
      this.Cstr_Troops[index] = StringManager.Instance.SpawnString();
    }
    for (int index = 0; index < 7; ++index)
    {
      this.Cstr_Soldier_ItemNum[index] = StringManager.Instance.SpawnString();
      this.Cstr_Soldier_Text[index] = StringManager.Instance.SpawnString();
    }
    this.Cstr_TeamName = StringManager.Instance.SpawnString(50);
    this.Cstr_WarlobbyKindText = StringManager.Instance.SpawnString(200);
    this.Cstr_WarlobbySolder = StringManager.Instance.SpawnString(100);
    this.Cstr_WarlobbyMaxSolder = StringManager.Instance.SpawnString();
    this.Cstr_HintNum = StringManager.Instance.SpawnString(1024);
    for (int index = 0; index < 11; ++index)
    {
      this.Cstr_WarSoldier_Text[index] = StringManager.Instance.SpawnString(100);
      this.Cstr_WarSoldierRate_Text[index] = StringManager.Instance.SpawnString(100);
    }
    this.MapID = arg1;
    this.mOpenKind = arg2;
    this.GUIM.AddSpriteAsset(this.AssetName);
    this.m_BW = this.GUIM.LoadMaterial(this.AssetName, this.AssetName1);
    this.mbtnFormation[0] = this.DM.mStringTable.GetStringByID(694U);
    this.mbtnFormation[1] = this.DM.mStringTable.GetStringByID(823U);
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.Tmp = this.GameT.GetChild(0);
    this.Tmp1 = this.Tmp.GetChild(1);
    this.Img_Frame = this.Tmp1.GetComponent<Image>();
    this.btn_MainHeroImg = this.Tmp1.GetChild(1).GetComponent<UIHIBtn>();
    if (this.DM.curHeroData.ContainsKey((uint) this.DM.GetLeaderID()))
      this.GUIM.InitianHeroItemImg(((Component) this.btn_MainHeroImg).transform, eHeroOrItem.Hero, this.DM.GetLeaderID(), (byte) 11, (byte) 0, bAutoShowHint: false);
    ((Component) this.btn_MainHeroImg).gameObject.AddComponent<IgnoreRaycast>();
    this.Img_CaveMain[0] = this.Tmp1.GetChild(2).GetComponent<Image>();
    this.Img_CaveMain[1] = this.Tmp1.GetChild(2).GetChild(0).GetComponent<Image>();
    ((Component) this.Img_CaveMain[0]).gameObject.SetActive(true);
    this.Img_HeroStatus = this.Tmp1.GetChild(3).GetComponent<Image>();
    eHeroState heroState = this.DM.GetHeroState(this.DM.GetLeaderID());
    switch (heroState)
    {
      case eHeroState.IsFighting:
        this.Img_HeroStatus.sprite = this.SArray.m_Sprites[16];
        break;
      case eHeroState.Captured:
        this.Img_HeroStatus.sprite = this.SArray.m_Sprites[17];
        break;
      case eHeroState.Dead:
        this.Img_HeroStatus.sprite = this.SArray.m_Sprites[18];
        break;
    }
    this.btn_CaveCheck = this.Tmp1.GetChild(4).GetChild(0).GetComponent<UIButton>();
    this.btn_CaveCheck.m_Handler = (IUIButtonClickHandler) this;
    this.btn_CaveCheck.m_BtnID1 = 20;
    this.Img_CaveStatus = this.Tmp1.GetChild(5).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.Img_CaveStatus).transform.localScale = new Vector3(-1f, ((Component) this.Img_CaveStatus).transform.localScale.y, ((Component) this.Img_CaveStatus).transform.localScale.z);
    this.Text_CaveMain = this.Tmp1.GetChild(6).GetComponent<UIText>();
    this.Text_CaveMain.font = this.TTFont;
    this.Text_CaveMain.text = this.DM.mStringTable.GetStringByID(8587U);
    if (this.mOpenKind == 4)
    {
      if (heroState != eHeroState.None)
      {
        ((Component) this.Img_HeroStatus).gameObject.SetActive(true);
        ((Component) this.Img_CaveStatus).gameObject.SetActive(false);
        this.bCaveMainHero = false;
      }
      else
      {
        this.DM.LegionBattleHero.Clear();
        this.DM.LegionBattleHero.Add(this.DM.GetLeaderID());
      }
      this.bLeaderHero = true;
    }
    this.BG_T1 = this.GameT.GetChild(1);
    this.Tmp = this.BG_T1.GetChild(0);
    this.btn_HeroTeam = this.Tmp.GetComponent<UIButton>();
    this.btn_HeroTeam.m_Handler = (IUIButtonClickHandler) this;
    this.btn_HeroTeam.m_BtnID1 = 6;
    this.Tmp = this.BG_T1.GetChild(2);
    this.btn_HeroFormation = this.Tmp.GetComponent<UIButton>();
    this.btn_HeroFormation.m_Handler = (IUIButtonClickHandler) this;
    this.btn_HeroFormation.m_BtnID1 = 17;
    this.btn_HeroFormation.m_EffectType = e_EffectType.e_Scale;
    this.btn_HeroFormation.transition = (Selectable.Transition) 0;
    this.Text_tmpStr[0] = this.Tmp.GetChild(0).GetComponent<UIText>();
    this.Text_tmpStr[0].font = this.TTFont;
    this.Text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(824U);
    this.Tmp = this.BG_T1.GetChild(3);
    this.Text_HeroTeam = this.Tmp.GetComponent<UIText>();
    this.Text_HeroTeam.font = this.TTFont;
    this.BG_T2 = this.GameT.GetChild(2);
    this.Tmp = this.BG_T2.GetChild(0);
    this.btn_Clear = this.Tmp.GetComponent<UIButton>();
    this.btn_Clear.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Clear.m_BtnID1 = 18;
    this.btn_Clear.m_EffectType = e_EffectType.e_Scale;
    this.btn_Clear.transition = (Selectable.Transition) 0;
    this.Text_tmpStr[1] = this.Tmp.GetChild(0).GetComponent<UIText>();
    this.Text_tmpStr[1].font = this.TTFont;
    this.Text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(825U);
    this.LockCount = (int) (byte) this.DM.GetMaxDefenders();
    for (int index = 0; index < 5; ++index)
    {
      this.Tmp = this.BG_T2.GetChild(1 + index);
      this.btn_Hero[index] = this.Tmp.GetComponent<UIButton>();
      this.btn_Hero[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Hero[index].m_BtnID1 = 1 + index;
      this.Tmp = this.BG_T2.GetChild(6 + index);
      this.btn_HeroImg[index] = this.Tmp.GetComponent<UIHIBtn>();
      this.GUIM.InitianHeroItemImg(((Component) this.btn_HeroImg[index]).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
      this.Tmp = this.BG_T2.GetChild(11 + index);
      this.Img_AddBG[index] = this.Tmp.GetComponent<Image>();
      ((Component) this.Img_AddBG[index]).gameObject.SetActive(false);
      this.Tmp = this.BG_T2.GetChild(16 + index);
      this.Img_Lock[index] = this.Tmp.GetComponent<Image>();
    }
    this.Img_Leader[0] = this.BG_T2.GetChild(21).GetComponent<Image>();
    this.Img_Leader[1] = this.BG_T2.GetChild(21).GetChild(0).GetComponent<Image>();
    if (this.DM.LegionBattleHero.Count > 0)
      this.bExpeditionHero = true;
    else if (!this.DM.bSetExpediton && this.mOpenKind == 1)
    {
      this.DM.LegionBattleHero.Clear();
      this.DM.SetSortNonFightHeroID();
      for (int index = 0; index < this.DM.GetMaxDefenders() && (long) index < (long) this.DM.NonFightHeroCount; ++index)
        this.DM.LegionBattleHero.Add((ushort) this.DM.SortNonFightHeroID[index]);
      this.bExpeditionHero = true;
    }
    this.BG_T3 = this.GameT.GetChild(3);
    this.Tmp = this.BG_T3.GetChild(0);
    this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
    this.m_ScrollPanel.m_ScrollPanelID = 1;
    this.Tmp = this.BG_T3.GetChild(1);
    this.Tmp1 = this.Tmp.GetChild(1);
    this.m_UnitRS = this.Tmp1.GetComponent<UnitResourcesSlider>();
    this.GUIM.InitUnitResourcesSlider(this.Tmp1, eUnitSlider.Expedition, 0U, 1000U, 0.7f);
    this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.BtnIncrease, 161f, -16f, 70f, 60f, 0.0f, 0.0f);
    this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.BtnLessen, -192f, -16f, 70f, 60f, 0.0f, 0.0f);
    this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.m_slider, -14f, -16f, 264f, 19f, 0.0f, 0.0f);
    this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.m_sliderBG1, 0.0f, 0.0f, 264f, 19f, 0.0f, 0.0f);
    this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.Input, 150f, 25f, 84f, 24f, 0.0f, 0.0f);
    this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.m_Img, 95f, 22f, 26f, 34f, 0.0f, 0.0f);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.BtnIncrease, this.SArray.m_Sprites[0], this.m_BW);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.BtnLessen, this.SArray.m_Sprites[1], this.m_BW);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.Input, this.SArray.m_Sprites[4], this.m_BW);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_sliderBG1, this.SArray.m_Sprites[2], this.m_BW);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_sliderBG2, this.SArray.m_Sprites[3], this.m_BW);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_Img, this.SArray.m_Sprites[5], this.m_BW);
    this.m_UnitRS.BtnInputText.m_Handler = (IUIButtonClickHandler) this;
    this.m_UnitRS.BtnInputText.m_BtnID1 = 19;
    this.Tmp1 = this.Tmp.GetChild(2);
    Image component1 = this.Tmp1.GetComponent<Image>();
    component1.sprite = this.GUIM.LoadFrameSprite("hf004");
    ((MaskableGraphic) component1).material = this.FrameMaterial;
    ((MaskableGraphic) this.Tmp1.GetChild(0).gameObject.GetComponent<Image>()).material = this.GUIM.m_IconSpriteAsset.GetMaterial();
    this.tmpRC = this.Tmp1.GetChild(0).GetComponent<RectTransform>();
    this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
    this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
    this.tmpRC.offsetMin = Vector2.zero;
    this.tmpRC.offsetMax = Vector2.zero;
    Image component2 = this.Tmp1.GetChild(1).gameObject.GetComponent<Image>();
    component2.sprite = this.GUIM.LoadFrameSprite("hf004");
    ((MaskableGraphic) component2).material = this.FrameMaterial;
    this.tmpRC = this.Tmp1.GetChild(1).GetComponent<RectTransform>();
    this.tmpRC.anchorMin = Vector2.zero;
    this.tmpRC.anchorMax = new Vector2(1f, 1f);
    this.tmpRC.offsetMin = Vector2.zero;
    this.tmpRC.offsetMax = Vector2.zero;
    this.Tmp1 = this.Tmp.GetChild(3);
    this.Tmp1.gameObject.GetComponent<Image>();
    this.Tmp2 = this.Tmp1.GetChild(1);
    this.Tmp2.GetComponent<UIText>().font = this.TTFont;
    this.Tmp1 = this.Tmp.GetChild(4);
    this.Tmp2.GetComponent<UIText>().font = this.TTFont;
    this.SoldierMax = 0L;
    this.UpDataSoldier();
    this.Tmp = this.GameT.GetChild(4);
    int x = 0;
    this.Tmp1 = this.Tmp.GetChild(0);
    this.btn_Troops = this.Tmp1.GetComponent<UIButton>();
    this.btn_Troops.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Troops.m_BtnID1 = 14;
    UIButtonHint uiButtonHint1 = this.Tmp1.gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    this.mAllianceWarImg = this.Tmp.GetChild(0).GetChild(0).GetChild(0).gameObject;
    if (this.mOpenKind == 10)
      this.mAllianceWarImg.gameObject.SetActive(true);
    this.Tmp1 = this.Tmp.GetChild(0).GetChild(1);
    this.Img_HintBG[0] = this.Tmp1.GetComponent<Image>();
    this.Img_HintBG[0].sprite = this.door.LoadSprite("UI_main_box_012");
    ((MaskableGraphic) this.Img_HintBG[0]).material = this.door.LoadMaterial();
    this.Img_HintBG[0].type = (Image.Type) 1;
    uiButtonHint1.ControlFadeOut = ((Component) this.Img_HintBG[0]).gameObject;
    this.Img_HintRT[0] = this.Tmp1.GetComponent<RectTransform>();
    this.Tmp1 = this.Tmp.GetChild(0).GetChild(1).GetChild(0);
    this.Text_HintRT[0] = this.Tmp1.GetComponent<RectTransform>();
    this.Text_Hint[0] = this.Tmp1.GetComponent<UIText>();
    this.Text_Hint[0].font = this.TTFont;
    this.Text_Hint[0].text = this.mOpenKind == 10 ? this.DM.mStringTable.GetStringByID(17077U) : this.DM.mStringTable.GetStringByID(335U);
    this.Text_HintRT[0].sizeDelta = new Vector2(this.Text_HintRT[0].sizeDelta.x, this.Text_Hint[0].preferredHeight);
    this.Img_HintRT[0].sizeDelta = new Vector2(this.Img_HintRT[0].sizeDelta.x, this.Text_Hint[0].preferredHeight + 20f);
    if ((double) this.Text_Hint[0].preferredWidth < (double) this.Text_HintRT[0].sizeDelta.x)
    {
      this.Text_HintRT[0].sizeDelta = new Vector2(this.Text_Hint[0].preferredWidth, this.Img_HintRT[0].sizeDelta.y);
      this.Img_HintRT[0].sizeDelta = new Vector2(this.Text_Hint[0].preferredWidth + 50f, this.Img_HintRT[0].sizeDelta.y);
    }
    this.mTroops_T = this.Tmp.GetChild(0);
    this.Tmp1 = this.Tmp.GetChild(0).GetChild(3);
    this.Text_Troops[0] = this.Tmp1.GetComponent<UIText>();
    this.Text_Troops[0].font = this.TTFont;
    this.Tmp1 = this.Tmp.GetChild(0).GetChild(2);
    this.Text_Troops[1] = this.Tmp1.GetComponent<UIText>();
    this.Text_Troops[1].font = this.TTFont;
    this.mLoad_T = this.Tmp.GetChild(1);
    this.btn_Load = this.mLoad_T.GetComponent<UIButton>();
    this.btn_Load.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Load.m_BtnID1 = 15;
    UIButtonHint uiButtonHint2 = this.mLoad_T.gameObject.AddComponent<UIButtonHint>();
    uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint2.m_Handler = (MonoBehaviour) this;
    for (int index = 0; index < 3; ++index)
      this.Img_StatusBG2[index] = this.Tmp.GetChild(1).GetChild(index).GetComponent<Image>();
    this.Tmp1 = this.Tmp.GetChild(1).GetChild(3);
    this.Img_HintBG[1] = this.Tmp1.GetComponent<Image>();
    this.Img_HintBG[1].sprite = this.door.LoadSprite("UI_main_box_012");
    ((MaskableGraphic) this.Img_HintBG[1]).material = this.door.LoadMaterial();
    this.Img_HintBG[1].type = (Image.Type) 1;
    uiButtonHint2.ControlFadeOut = ((Component) this.Img_HintBG[1]).gameObject;
    this.Img_HintRT[1] = this.Tmp1.GetComponent<RectTransform>();
    this.Tmp1 = this.Tmp.GetChild(1).GetChild(3).GetChild(0);
    this.Text_HintRT[1] = this.Tmp1.GetComponent<RectTransform>();
    this.Text_Hint[1] = this.Tmp1.GetComponent<UIText>();
    this.Text_Hint[1].font = this.TTFont;
    this.Tmp1 = this.Tmp.GetChild(1).GetChild(4);
    this.Text_Load[0] = this.Tmp1.GetComponent<UIText>();
    this.Text_Load[0].font = this.TTFont;
    this.Text_Load[0].text = x.ToString();
    this.mLoadBG_T = this.Tmp.GetChild(2);
    this.Img_StatusBG = this.Tmp.GetChild(2).GetComponent<Image>();
    this.Img_TargetBG = this.Tmp.GetChild(2).GetChild(0).GetComponent<Image>();
    this.Img_TargetRT = this.Tmp.GetChild(2).GetChild(0).GetComponent<RectTransform>();
    this.Tmp1 = this.Tmp.GetChild(2).GetChild(1);
    this.Text_Load[1] = this.Tmp1.GetComponent<UIText>();
    this.Text_Load[1].font = this.TTFont;
    this.Text_Load[1].text = x.ToString();
    this.Text_LoadRT = this.Tmp1.GetComponent<RectTransform>();
    this.Tmp1 = this.Tmp.GetChild(2).GetChild(2);
    this.Text_Load[2] = this.Tmp1.GetComponent<UIText>();
    this.Text_Load[2].font = this.TTFont;
    this.Text_Load[2].text = this.DM.mStringTable.GetStringByID(691U);
    this.Tmp1 = this.Tmp.GetChild(2).GetChild(3);
    this.Text_Load[3] = this.Tmp1.GetComponent<UIText>();
    this.Text_Load[3].font = this.TTFont;
    this.mTime_T = this.Tmp.GetChild(3);
    this.btn_Time = this.mTime_T.GetComponent<UIButton>();
    this.btn_Time.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Time.m_BtnID1 = 16;
    UIButtonHint uiButtonHint3 = this.mTime_T.gameObject.AddComponent<UIButtonHint>();
    uiButtonHint3.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint3.m_Handler = (MonoBehaviour) this;
    this.Tmp1 = this.Tmp.GetChild(3).GetChild(1);
    this.Img_HintBG[2] = this.Tmp1.GetComponent<Image>();
    this.Img_HintBG[2].sprite = this.door.LoadSprite("UI_main_box_012");
    ((MaskableGraphic) this.Img_HintBG[2]).material = this.door.LoadMaterial();
    this.Img_HintBG[2].type = (Image.Type) 1;
    uiButtonHint3.ControlFadeOut = ((Component) this.Img_HintBG[2]).gameObject;
    this.Img_HintRT[2] = this.Tmp1.GetComponent<RectTransform>();
    this.Tmp1 = this.Tmp.GetChild(3).GetChild(1).GetChild(0);
    this.Text_HintRT[2] = this.Tmp1.GetComponent<RectTransform>();
    this.Text_Hint[2] = this.Tmp1.GetComponent<UIText>();
    this.Text_Hint[2].font = this.TTFont;
    this.Text_Hint[2].text = this.DM.mStringTable.GetStringByID(337U);
    this.Text_HintRT[2].sizeDelta = new Vector2(this.Text_HintRT[2].sizeDelta.x, this.Text_Hint[2].preferredHeight);
    this.Img_HintRT[2].sizeDelta = new Vector2(this.Img_HintRT[2].sizeDelta.x, this.Text_Hint[2].preferredHeight + 20f);
    if ((double) this.Text_Hint[2].preferredWidth < (double) this.Text_HintRT[2].sizeDelta.x)
    {
      this.Text_HintRT[2].sizeDelta = new Vector2(this.Text_Hint[2].preferredWidth, this.Img_HintRT[2].sizeDelta.y);
      this.Img_HintRT[2].sizeDelta = new Vector2(this.Text_Hint[2].preferredWidth + 50f, this.Img_HintRT[2].sizeDelta.y);
    }
    this.Tmp1 = this.Tmp.GetChild(3).GetChild(2);
    this.Text_Time[0] = this.Tmp1.GetComponent<UIText>();
    this.Text_Time[0].font = this.TTFont;
    this.Text_Time[0].text = x.ToString();
    this.Tmp1 = this.Tmp.GetChild(3).GetChild(3);
    this.Text_Time[1] = this.Tmp1.GetComponent<UIText>();
    this.Text_Time[1].font = this.TTFont;
    this.Text_Time[1].text = this.DM.mStringTable.GetStringByID(353U);
    if ((double) this.Text_Time[1].preferredWidth > (double) ((Graphic) this.Text_Time[1]).rectTransform.sizeDelta.x)
      ((Graphic) this.Text_Time[1]).rectTransform.sizeDelta = new Vector2(this.Text_Time[1].preferredWidth, ((Graphic) this.Text_Time[1]).rectTransform.sizeDelta.y);
    this.Tmp1 = this.Tmp.GetChild(3).GetChild(4);
    this.Text_Time[2] = this.Tmp1.GetComponent<UIText>();
    this.Text_Time[2].font = this.TTFont;
    this.Cstr_Accelerate.ClearString();
    this.Cstr_Accelerate.IntToFormat((long) x);
    if (this.GUIM.IsArabic)
      this.Cstr_Accelerate.AppendFormat("%{0}");
    else
      this.Cstr_Accelerate.AppendFormat("{0}%");
    this.Text_Time[2].text = this.Cstr_Accelerate.ToString();
    this.Text_Time[2].SetAllDirty();
    this.Text_Time[2].cachedTextGenerator.Invalidate();
    this.tmpString.Length = 0;
    this.Img_MusterTimeBG = this.Tmp.GetChild(7).GetComponent<Image>();
    this.Text_MusterTime = this.Tmp.GetChild(7).GetChild(0).GetComponent<UIText>();
    this.Text_MusterTime.font = this.TTFont;
    this.Cstr_MusterTime.ClearString();
    this.Text_MusterTime.text = this.Cstr_MusterTime.ToString();
    this.Tmp1 = this.Tmp.GetChild(4);
    this.btn_Formation = this.Tmp1.GetComponent<UIButton>();
    this.btn_Formation.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Formation.m_BtnID1 = 7;
    this.btn_Formation.m_EffectType = e_EffectType.e_Scale;
    this.btn_Formation.transition = (Selectable.Transition) 0;
    this.Tmp1 = this.Tmp.GetChild(4).GetChild(1);
    this.Text_Formation = this.Tmp1.GetComponent<UIText>();
    this.Text_Formation.font = this.TTFont;
    this.Text_Formation.text = this.DM.mStringTable.GetStringByID(694U);
    this.Tmp1 = this.Tmp.GetChild(5);
    this.btn_Expedition = this.Tmp1.GetComponent<UIButton>();
    this.btn_Expedition.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Expedition.m_BtnID1 = 9;
    this.Tmp1 = this.Tmp.GetChild(6);
    this.Img_NoSoldierBG = this.Tmp1.GetComponent<Image>();
    this.Text_tmpStr[2] = this.Tmp1.GetChild(0).GetComponent<UIText>();
    this.Text_tmpStr[2].font = this.TTFont;
    this.Text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(771U);
    if (this.SoldierMax == 0L)
      ((Component) this.Img_NoSoldierBG).gameObject.SetActive(true);
    this.Tmp1 = this.Tmp.GetChild(8);
    this.btn_SelectMenu[0] = this.Tmp1.GetComponent<UIButton>();
    this.btn_SelectMenu[0].m_Handler = (IUIButtonClickHandler) this;
    this.btn_SelectMenu[0].m_BtnID1 = 21;
    this.btn_SelectMenu[0].m_EffectType = e_EffectType.e_Scale;
    this.btn_SelectMenu[0].transition = (Selectable.Transition) 0;
    this.Tmp1 = this.Tmp.GetChild(8).GetChild(0);
    this.Img_SelectMenu[0] = this.Tmp1.GetComponent<Image>();
    this.Tmp1 = this.Tmp.GetChild(8).GetChild(1);
    this.Img_SelectMenu[1] = this.Tmp1.GetComponent<Image>();
    this.Tmp1 = this.Tmp.GetChild(8).GetChild(2);
    this.Text_SelectMenu[0] = this.Tmp1.GetComponent<UIText>();
    this.Text_SelectMenu[0].font = this.TTFont;
    this.Tmp1 = this.Tmp.GetChild(8).GetChild(3);
    this.Text_SelectMenu[1] = this.Tmp1.GetComponent<UIText>();
    this.Text_SelectMenu[1].font = this.TTFont;
    if (this.DM.mcollectionKind != byte.MaxValue)
    {
      ((Component) this.Text_SelectMenu[0]).gameObject.SetActive(false);
      this.Text_SelectMenu[1].text = (int) this.DM.mcollectionKind % 2 != 0 ? this.DM.mStringTable.GetStringByID(334U) : this.DM.mStringTable.GetStringByID(333U);
      ((Component) this.Text_SelectMenu[1]).gameObject.SetActive(true);
      this.Text_SelectMenu[0].text = this.mbtnFormation[1];
    }
    else
      this.Text_SelectMenu[0].text = this.DM.mStringTable.GetStringByID(5219U);
    this.Tmp1 = this.Tmp.GetChild(9);
    this.btn_SelectMenu[1] = this.Tmp1.GetComponent<UIButton>();
    this.btn_SelectMenu[1].m_Handler = (IUIButtonClickHandler) this;
    this.btn_SelectMenu[1].m_BtnID1 = 22;
    this.btn_SelectMenu[1].m_EffectType = e_EffectType.e_Scale;
    this.btn_SelectMenu[1].transition = (Selectable.Transition) 0;
    this.mSave_T = this.Tmp.GetChild(10);
    this.Tmp1 = this.mSave_T.GetChild(0);
    this.btn_SetName = this.Tmp1.GetComponent<UIButton>();
    this.btn_SetName.m_Handler = (IUIButtonClickHandler) this;
    this.btn_SetName.m_BtnID1 = 23;
    this.btn_SetName.m_EffectType = e_EffectType.e_Scale;
    this.btn_SetName.transition = (Selectable.Transition) 0;
    this.Tmp1 = this.mSave_T.GetChild(1);
    this.btn_Save = this.Tmp1.GetComponent<UIButton>();
    this.btn_Save.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Save.m_BtnID1 = 24;
    this.btn_Save.m_EffectType = e_EffectType.e_Scale;
    this.btn_Save.transition = (Selectable.Transition) 0;
    this.Tmp1 = this.mSave_T.GetChild(1).GetChild(0);
    this.Text_Save = this.Tmp1.GetComponent<UIText>();
    this.Text_Save.font = this.TTFont;
    this.Text_Save.text = this.DM.mStringTable.GetStringByID(929U);
    this.Tmp1 = this.mSave_T.GetChild(2);
    this.Text_Name = this.Tmp1.GetComponent<UIText>();
    this.Text_Name.font = this.TTFont;
    this.mApply_T = this.Tmp.GetChild(11);
    this.Tmp1 = this.mApply_T.GetChild(0);
    this.btn_Apply = this.Tmp1.GetComponent<UIButton>();
    this.btn_Apply.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Apply.m_BtnID1 = 26;
    this.btn_Apply.m_EffectType = e_EffectType.e_Scale;
    this.btn_Apply.transition = (Selectable.Transition) 0;
    this.Tmp1 = this.mApply_T.GetChild(0).GetChild(0);
    this.Text_btnApply = this.Tmp1.GetComponent<UIText>();
    this.Text_btnApply.font = this.TTFont;
    this.Text_btnApply.text = this.DM.mStringTable.GetStringByID(508U);
    this.Tmp1 = this.mApply_T.GetChild(1);
    this.Text_Apply = this.Tmp1.GetComponent<UIText>();
    this.Text_Apply.font = this.TTFont;
    this.Text_Apply.text = this.DM.mStringTable.GetStringByID(17016U);
    this.mWarlobbyT = this.Tmp.GetChild(12);
    this.Tmp1 = this.mWarlobbyT.GetChild(0);
    this.btn_W_MenuSelect[0] = this.Tmp1.GetComponent<UIButton>();
    this.btn_W_MenuSelect[0].m_Handler = (IUIButtonClickHandler) this;
    this.btn_W_MenuSelect[0].m_BtnID1 = 27;
    this.btn_W_MenuSelect[0].m_EffectType = e_EffectType.e_Scale;
    this.btn_W_MenuSelect[0].transition = (Selectable.Transition) 0;
    this.Tmp1 = this.mWarlobbyT.GetChild(1);
    this.btn_W_MenuSelect[1] = this.Tmp1.GetComponent<UIButton>();
    this.btn_W_MenuSelect[1].m_Handler = (IUIButtonClickHandler) this;
    this.btn_W_MenuSelect[1].m_BtnID1 = 28;
    this.btn_W_MenuSelect[1].m_EffectType = e_EffectType.e_Scale;
    this.btn_W_MenuSelect[1].transition = (Selectable.Transition) 0;
    this.Img_W_SelectIcon = this.Tmp1.GetChild(0).GetComponent<Image>();
    this.Text_W_Select[0] = this.Tmp1.GetChild(1).GetComponent<UIText>();
    this.Text_W_Select[0].font = this.TTFont;
    this.Text_W_Select[0].text = this.DM.mStringTable.GetStringByID(14710U);
    this.Text_W_Select[1] = this.Tmp1.GetChild(2).GetComponent<UIText>();
    this.Text_W_Select[1].font = this.TTFont;
    Image component3 = this.GameT.GetChild(5).GetComponent<Image>();
    component3.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component3).material = this.door.LoadMaterial();
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) component3).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(5).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.door.LoadMaterial();
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.Tmp = this.GameT.GetChild(6);
    this.btn_FormationMenu = this.Tmp.GetComponent<UIButton>();
    this.btn_FormationMenu.m_Handler = (IUIButtonClickHandler) this;
    this.btn_FormationMenu.m_BtnID1 = 8;
    this.btn_FormationMenu.image.sprite = this.door.LoadSprite("UI_main_black");
    ((MaskableGraphic) this.btn_FormationMenu.image).material = this.door.LoadMaterial();
    if (this.GUIM.bOpenOnIPhoneX)
    {
      this.Tmp.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
      this.Tmp.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
    }
    this.Tmp1 = this.Tmp.GetChild(0);
    for (int index = 0; index < 4; ++index)
    {
      this.Tmp2 = this.Tmp1.GetChild(index);
      this.btn_Menu[index] = this.Tmp2.GetComponent<UIButton>();
      this.btn_Menu[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Menu[index].m_BtnID1 = 10 + index;
      this.Tmp2 = this.Tmp1.GetChild(index).GetChild(1);
      this.Text_Menu[index] = this.Tmp2.GetComponent<UIText>();
      this.Text_Menu[index].font = this.TTFont;
      this.Text_Menu[index].text = index % 2 != 0 ? this.DM.mStringTable.GetStringByID(332U) : this.DM.mStringTable.GetStringByID(331U);
    }
    this.Img_SelectMenuKind[0] = this.Tmp1.GetChild(0).GetChild(0).GetComponent<Image>();
    this.Img_SelectMenuKind[1] = this.Tmp1.GetChild(1).GetChild(0).GetComponent<Image>();
    this.mSelectTeam_T = this.GameT.GetChild(7);
    for (int index = 0; index < 5; ++index)
    {
      this.Tmp1 = this.mSelectTeam_T.GetChild(index);
      this.btn_SelectTeam[index] = this.Tmp1.GetComponent<UIButton>();
      this.btn_SelectTeam[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_SelectTeam[index].m_BtnID1 = 25;
      this.btn_SelectTeam[index].m_BtnID2 = index;
      this.btn_SelectTeam[index].m_EffectType = e_EffectType.e_Scale;
      this.btn_SelectTeam[index].transition = (Selectable.Transition) 0;
      if ((int) this.DM.GetTechLevel((ushort) 120) < index + 1)
        this.SetaApplyEnable(this.btn_SelectTeam[index], false);
      this.Tmp1 = this.mSelectTeam_T.GetChild(index).GetChild(1);
      this.Text_D[index] = this.Tmp1.GetComponent<UIText>();
      this.Text_D[index].font = this.TTFont;
      this.Text_D[index].text = (index + 1).ToString();
    }
    this.mSelectTeam_LT = this.GameT.GetChild(8);
    for (int index = 0; index < 5; ++index)
    {
      this.Tmp1 = this.mSelectTeam_LT.GetChild(index);
      this.btn_SelectTeam[index + 5] = this.Tmp1.GetComponent<UIButton>();
      this.btn_SelectTeam[index + 5].m_Handler = (IUIButtonClickHandler) this;
      this.btn_SelectTeam[index + 5].m_BtnID1 = 25;
      this.btn_SelectTeam[index + 5].m_BtnID2 = index;
      this.btn_SelectTeam[index + 5].m_EffectType = e_EffectType.e_Scale;
      this.btn_SelectTeam[index + 5].transition = (Selectable.Transition) 0;
      if ((int) this.DM.GetTechLevel((ushort) 120) < index + 1)
        this.SetaApplyEnable(this.btn_SelectTeam[index + 5], false);
      this.Tmp1 = this.mSelectTeam_LT.GetChild(index).GetChild(1);
      this.Text_L[index] = this.Tmp1.GetComponent<UIText>();
      this.Text_L[index].font = this.TTFont;
      this.Text_L[index].text = (index + 1).ToString();
    }
    this.Tmp = this.GameT.GetChild(9);
    this.btn_W_MenuBack = this.Tmp.GetComponent<UIButton>();
    this.btn_W_MenuBack.m_Handler = (IUIButtonClickHandler) this;
    this.btn_W_MenuBack.m_BtnID1 = 29;
    this.btn_W_MenuBack.image.sprite = this.door.LoadSprite("UI_main_black");
    ((MaskableGraphic) this.btn_W_MenuBack.image).material = this.door.LoadMaterial();
    if (this.GUIM.bOpenOnIPhoneX)
    {
      this.Tmp.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
      this.Tmp.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
    }
    this.Img_W_MenuSelect = this.Tmp.GetChild(0).GetComponent<Image>();
    for (int index = 0; index < 3; ++index)
    {
      this.btn_W_MenuKind[index] = this.Tmp.GetChild(0).GetChild(index).GetComponent<UIButton>();
      this.btn_W_MenuKind[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_W_MenuKind[index].m_BtnID1 = 31 + index;
      this.btn_W_MenuKind[index].m_EffectType = e_EffectType.e_Scale;
      this.btn_W_MenuKind[index].transition = (Selectable.Transition) 0;
      this.Text_W_MenuKind[index] = index != 0 ? this.Tmp.GetChild(0).GetChild(index).GetChild(1).GetComponent<UIText>() : this.Tmp.GetChild(0).GetChild(index).GetChild(0).GetComponent<UIText>();
      this.Text_W_MenuKind[index].font = this.TTFont;
    }
    this.Text_W_MenuKind[0].text = this.DM.mStringTable.GetStringByID(694U);
    this.Text_W_MenuKind[1].text = this.DM.mStringTable.GetStringByID(14711U);
    this.Text_W_MenuKind[2].text = this.DM.mStringTable.GetStringByID(14712U);
    this.Text_W_MenuKind[3] = this.Tmp.GetChild(0).GetChild(3).GetChild(0).GetComponent<UIText>();
    this.Text_W_MenuKind[3].font = this.TTFont;
    this.Tmp1 = this.Tmp.GetChild(1);
    this.Img_W_Menu = this.Tmp1.GetComponent<Image>();
    this.Img_W_Menu.sprite = this.door.LoadSprite("UI_main_black");
    ((MaskableGraphic) this.Img_W_Menu).material = this.door.LoadMaterial();
    if (this.GUIM.bOpenOnIPhoneX)
    {
      this.Tmp1.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
      this.Tmp1.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
    }
    this.Tmp1 = this.Tmp.GetChild(1).GetChild(0);
    this.btn_W_InfoBack[0] = this.Tmp1.GetComponent<UIButton>();
    this.btn_W_InfoBack[0].m_Handler = (IUIButtonClickHandler) this;
    this.btn_W_InfoBack[0].m_BtnID1 = 30;
    this.btn_W_InfoBack[0].image.sprite = this.door.LoadSprite("UI_main_black");
    ((MaskableGraphic) this.btn_W_InfoBack[0].image).material = this.door.LoadMaterial();
    if (this.GUIM.bOpenOnIPhoneX)
    {
      this.Tmp1.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
      this.Tmp1.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
    }
    this.Tmp1 = this.Tmp.GetChild(1).GetChild(1);
    Image component4 = this.Tmp1.GetComponent<Image>();
    component4.sprite = this.door.LoadSprite("UI_main_box_009_bb");
    ((MaskableGraphic) component4).material = this.door.LoadMaterial();
    Image component5 = this.Tmp1.GetChild(0).GetComponent<Image>();
    component5.sprite = this.door.LoadSprite("UI_con_title_orange");
    ((MaskableGraphic) component5).material = this.door.LoadMaterial();
    this.Text_W_SelectTilte = this.Tmp1.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.Text_W_SelectTilte.font = this.TTFont;
    this.m_ScrollPanel_Warlobby = this.Tmp1.GetChild(1).GetComponent<ScrollPanel>();
    this.m_ScrollPanel_Warlobby.m_ScrollPanelID = 2;
    Image component6 = this.Tmp1.GetChild(1).GetComponent<Image>();
    component6.sprite = this.door.LoadSprite("UI_con_alp_02");
    ((MaskableGraphic) component6).material = this.door.LoadMaterial();
    this.Tmp2 = this.Tmp1.GetChild(2);
    Image component7 = this.Tmp2.GetChild(0).GetChild(0).GetComponent<Image>();
    component7.sprite = this.door.LoadSprite("UI_main_box_011");
    ((MaskableGraphic) component7).material = this.door.LoadMaterial();
    UIText component8 = this.Tmp2.GetChild(0).GetChild(1).GetComponent<UIText>();
    component8.font = this.TTFont;
    component8.text = this.DM.mStringTable.GetStringByID(14718U);
    this.Text_W_Scroll[0] = this.Tmp2.GetChild(0).GetChild(2).GetComponent<UIText>();
    this.Text_W_Scroll[0].font = this.TTFont;
    this.Text_W_Scroll[1] = this.Tmp2.GetChild(0).GetChild(3).GetComponent<UIText>();
    this.Text_W_Scroll[1].font = this.TTFont;
    this.Text_W_Scroll[2] = this.Tmp2.GetChild(0).GetChild(4).GetComponent<UIText>();
    this.Text_W_Scroll[2].font = this.TTFont;
    this.Text_W_Scroll[3] = this.Tmp2.GetChild(0).GetChild(5).GetComponent<UIText>();
    this.Text_W_Scroll[3].font = this.TTFont;
    this.Text_W_Scroll[0].text = this.DM.mStringTable.GetStringByID(14719U);
    this.Text_W_Scroll[0].SetAllDirty();
    this.Text_W_Scroll[0].cachedTextGenerator.Invalidate();
    this.Text_W_Scroll[0].cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.Text_W_Scroll[0].preferredHeight > (double) ((Graphic) this.Text_W_Scroll[0]).rectTransform.sizeDelta.y)
    {
      ((Graphic) this.Text_W_Scroll[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Text_W_Scroll[0]).rectTransform.sizeDelta.x, 56f);
      ((Graphic) this.Text_W_Scroll[2]).rectTransform.anchoredPosition = new Vector2(-58f, -58f);
      this.bScrollItemH = true;
      ((Graphic) this.Text_W_Scroll[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Text_W_Scroll[1]).rectTransform.anchoredPosition.x, -112f);
      ((Graphic) this.Text_W_Scroll[3]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Text_W_Scroll[3]).rectTransform.anchoredPosition.x, -112f);
    }
    else
    {
      ((Graphic) this.Text_W_Scroll[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Text_W_Scroll[0]).rectTransform.sizeDelta.x, 28f);
      ((Graphic) this.Text_W_Scroll[2]).rectTransform.anchoredPosition = new Vector2(-58f, -44f);
      ((Graphic) this.Text_W_Scroll[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Text_W_Scroll[1]).rectTransform.anchoredPosition.x, -84f);
      ((Graphic) this.Text_W_Scroll[3]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Text_W_Scroll[3]).rectTransform.anchoredPosition.x, -84f);
    }
    this.Text_W_Scroll[1].text = this.DM.mStringTable.GetStringByID(14721U);
    this.Text_W_Scroll[1].SetAllDirty();
    this.Text_W_Scroll[1].cachedTextGenerator.Invalidate();
    this.Text_W_Scroll[1].cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.Text_W_Scroll[1].preferredHeight > 28.0)
      this.bScrollItemH2 = true;
    this.Text_W_Scroll[1].text = this.DM.mStringTable.GetStringByID(14720U);
    this.Text_W_Scroll[1].SetAllDirty();
    this.Text_W_Scroll[1].cachedTextGenerator.Invalidate();
    this.Text_W_Scroll[1].cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.Text_W_Scroll[1].preferredHeight > 28.0)
      this.bScrollItemH1 = true;
    Image component9 = this.Tmp2.GetChild(1).GetChild(0).GetComponent<Image>();
    component9.sprite = this.door.LoadSprite("UI_main_box_011");
    ((MaskableGraphic) component9).material = this.door.LoadMaterial();
    UIText component10 = this.Tmp2.GetChild(1).GetChild(1).GetComponent<UIText>();
    component10.font = this.TTFont;
    component10.text = this.DM.mStringTable.GetStringByID(4925U);
    Image component11 = this.Tmp2.GetChild(2).GetChild(0).GetComponent<Image>();
    component11.sprite = this.door.LoadSprite("UI_legion_icon_a");
    ((MaskableGraphic) component11).material = this.door.LoadMaterial();
    this.Tmp2.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>().font = this.TTFont;
    this.Tmp2.GetChild(2).GetChild(0).GetChild(1).GetComponent<UIText>().font = this.TTFont;
    this.Tmp2.GetChild(2).GetChild(0).GetChild(2).GetComponent<UIText>().font = this.TTFont;
    Image component12 = this.Tmp2.GetChild(2).GetChild(1).GetComponent<Image>();
    component12.sprite = this.door.LoadSprite("UI_leg_icon_Ex");
    ((MaskableGraphic) component12).material = this.door.LoadMaterial();
    this.Tmp2.GetChild(2).GetChild(2).GetComponent<UIText>().font = this.TTFont;
    for (int index = 0; index < 11; ++index)
    {
      this.m_Warlobby_Item[index].text_T1 = new UIText[5];
      this.m_Warlobby_Item[index].text_SolderT = new UIText[4];
      this.InitSoldierInfoItem[index] = false;
    }
    this.tmplist_Warlooby.Add(118f);
    this.tmplist_Warlooby.Add(38f);
    this.m_ScrollPanel_Warlobby.IntiScrollPanel(376f, 15f, 0.0f, this.tmplist_Warlooby, 11, (IUpDateScrollPanel) this);
    this.m_ScrollRect_Warlobby = this.m_ScrollPanel_Warlobby.transform.GetComponent<CScrollRect>();
    UIButtonHint.scrollRect = this.m_ScrollRect_Warlobby;
    this.btn_W_InfoBack[1] = this.Tmp1.GetChild(3).GetComponent<UIButton>();
    this.btn_W_InfoBack[1].m_Handler = (IUIButtonClickHandler) this;
    this.btn_W_InfoBack[1].m_BtnID1 = 30;
    this.btn_W_InfoBack[1].image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_W_InfoBack[1].image).material = this.door.LoadMaterial();
    this.btn_W_InfoBack[1].m_EffectType = e_EffectType.e_Scale;
    this.btn_W_InfoBack[1].transition = (Selectable.Transition) 0;
    this.btn_W_MenuSet = this.Tmp1.GetChild(4).GetComponent<UIButton>();
    this.btn_W_MenuSet.m_Handler = (IUIButtonClickHandler) this;
    this.btn_W_MenuSet.m_BtnID1 = 34;
    this.btn_W_MenuSet.image.sprite = this.door.LoadSprite("UI_main_butt_a");
    ((MaskableGraphic) this.btn_W_MenuSet.image).material = this.door.LoadMaterial();
    this.btn_W_MenuSet.m_EffectType = e_EffectType.e_Scale;
    this.btn_W_MenuSet.transition = (Selectable.Transition) 0;
    this.Text_W_MenuSet = this.Tmp1.GetChild(4).GetChild(0).GetComponent<UIText>();
    this.Text_W_MenuSet.font = this.TTFont;
    this.Text_W_MenuSet.text = this.DM.mStringTable.GetStringByID(924U);
    this.btn_W_MenuSet.m_Text = this.Text_W_MenuSet;
    Image component13 = this.Tmp1.GetChild(5).GetComponent<Image>();
    component13.sprite = this.door.LoadSprite("UI_fr_box_005");
    ((MaskableGraphic) component13).material = this.door.LoadMaterial();
    this.mResources[0] = this.door.LoadSprite("UI_main_res_food");
    this.mResources[1] = this.door.LoadSprite("UI_main_res_wood");
    this.mResources[2] = this.door.LoadSprite("UI_main_res_iron");
    this.mResources[3] = this.door.LoadSprite("UI_main_res_stone");
    this.mResources[4] = this.door.LoadSprite("UI_main_money_01");
    this.mResources[5] = this.door.LoadSprite("UI_main_money_02");
    this.mWarlobbyIcon[0] = this.door.LoadSprite("UI_legion_icon_a");
    this.mWarlobbyIcon[1] = this.door.LoadSprite("UI_legion_icon_b");
    this.mWarlobbyIcon[2] = this.door.LoadSprite("UI_legion_icon_c");
    this.mWarlobbyIcon[3] = this.door.LoadSprite("UI_legion_icon_d");
    if (this.mOpenKind == 0)
    {
      this.nowMapPoint = DataManager.MapDataController.LayoutMapInfo[this.MapID];
      this.Distance_Total = DataManager.MapDataController.CalcDistance(this.MapID, this.DM.RoleAttr.CapitalPoint, (ushort) 0);
      switch (DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) this.MapID))
      {
        case POINT_KIND.PK_NONE:
          this.mStatus = 0;
          break;
        case POINT_KIND.PK_FOOD:
          this.mStatus = 1;
          this.Img_TargetBG.sprite = this.mResources[0];
          this.Img_SelectMenuKind[0].sprite = this.mResources[0];
          this.Img_SelectMenuKind[1].sprite = this.mResources[0];
          this.Img_SelectMenu[0].sprite = this.mResources[0];
          break;
        case POINT_KIND.PK_STONE:
          this.mStatus = 1;
          this.Img_TargetBG.sprite = this.mResources[3];
          this.Img_SelectMenuKind[0].sprite = this.mResources[3];
          this.Img_SelectMenuKind[1].sprite = this.mResources[3];
          this.Img_SelectMenu[0].sprite = this.mResources[3];
          break;
        case POINT_KIND.PK_IRON:
          this.mStatus = 1;
          this.Img_TargetBG.sprite = this.mResources[2];
          this.Img_SelectMenuKind[0].sprite = this.mResources[2];
          this.Img_SelectMenuKind[1].sprite = this.mResources[2];
          this.Img_SelectMenu[0].sprite = this.mResources[2];
          break;
        case POINT_KIND.PK_WOOD:
          this.mStatus = 1;
          this.Img_TargetBG.sprite = this.mResources[1];
          this.Img_SelectMenuKind[0].sprite = this.mResources[1];
          this.Img_SelectMenuKind[1].sprite = this.mResources[1];
          this.Img_SelectMenu[0].sprite = this.mResources[1];
          break;
        case POINT_KIND.PK_GOLD:
          this.mStatus = 1;
          this.Img_TargetBG.sprite = this.mResources[4];
          this.Img_SelectMenuKind[0].sprite = this.mResources[4];
          this.Img_SelectMenuKind[1].sprite = this.mResources[4];
          this.Img_SelectMenu[0].sprite = this.mResources[4];
          break;
        case POINT_KIND.PK_CRYSTAL:
          this.mStatus = 1;
          this.mResourcesKind = 1;
          this.Img_TargetBG.sprite = this.mResources[5];
          this.Img_SelectMenuKind[0].sprite = this.mResources[5];
          this.Img_SelectMenuKind[1].sprite = this.mResources[5];
          this.Img_SelectMenu[0].sprite = this.mResources[5];
          break;
      }
      ushort tableId = DataManager.MapDataController.LayoutMapInfo[this.MapID].tableID;
      if (this.mStatus == 1 && DataManager.MapDataController.ResourcesPointTable[(int) tableId].playerName.Length != 0)
        this.mStatus = 0;
      this.Img_TargetBG.SetNativeSize();
      ((MaskableGraphic) this.Img_SelectMenuKind[0]).material = this.door.LoadMaterial();
      this.Img_SelectMenuKind[0].SetNativeSize();
      ((MaskableGraphic) this.Img_SelectMenuKind[1]).material = this.door.LoadMaterial();
      this.Img_SelectMenuKind[1].SetNativeSize();
      ((MaskableGraphic) this.Img_SelectMenu[0]).material = this.door.LoadMaterial();
      this.Img_SelectMenu[0].SetNativeSize();
      this.Text_LoadRT.sizeDelta = new Vector2(this.Text_Load[1].preferredWidth, this.Text_LoadRT.sizeDelta.y);
      this.tmpL = Mathf.Ceil(this.Text_LoadRT.anchoredPosition.x + this.Text_Load[1].preferredWidth) - 20f;
      this.Img_TargetRT.anchoredPosition = new Vector2(-this.tmpL, this.Img_TargetRT.anchoredPosition.y);
      ((Graphic) this.Text_Load[2]).rectTransform.anchoredPosition = new Vector2(-this.tmpL - this.Img_TargetRT.sizeDelta.x, ((Graphic) this.Text_Load[2]).rectTransform.anchoredPosition.y);
    }
    else if (this.mOpenKind == 1)
    {
      this.mLoad_T.gameObject.SetActive(false);
      this.mLoadBG_T.gameObject.SetActive(false);
      this.mTime_T.gameObject.SetActive(false);
      this.tmpPVEPower[0] = 1f;
      this.tmpPVEPower[1] = 2f;
      this.tmpPVEPower[2] = 3f;
      this.tmpPVEPower[3] = 4.5f;
    }
    else if (this.mOpenKind == 2)
    {
      if (this.MapID == 2 || this.MapID == 3)
      {
        this.ZoneID = this.DM.WarlobbyDetail.AllyCapitalPoint.zoneID;
        this.PointID = this.DM.WarlobbyDetail.AllyCapitalPoint.pointID;
      }
      else if (this.MapID == 4)
      {
        this.ZoneID = this.DM.WarlobbyDetail.EnemyCapitalPoint.zoneID;
        this.PointID = this.DM.WarlobbyDetail.EnemyCapitalPoint.pointID;
        for (int index = 0; index < 4; ++index)
          this.WarlobbyTroopData[index] = new uint[4];
        if (this.DM.WarlobbyDetail.AttackOrDefense == (byte) 2 && this.DM.WarTroop.Count > 0)
        {
          this.WarlobbyTroopTotalTroopNum = this.DM.WarTroop[0].TotalTroopNum;
          for (int index = 0; index < 16; ++index)
            this.WarlobbyTroopData[index >> 2][index & 3] = this.DM.WarTroop[0].TroopData[index & 3][3 - (index >> 2)];
        }
        this.Text_W_MenuKind[3].text = this.DM.mStringTable.GetStringByID(14716U);
        this.mWarlobbyKind = (byte) 1;
      }
      else
      {
        this.ZoneID = this.DM.m_InForcePoint.zoneID;
        this.PointID = this.DM.m_InForcePoint.pointID;
      }
      this.Distance_Total = DataManager.MapDataController.CalcDistance(GameConstants.PointCodeToMapID(this.ZoneID, this.PointID), this.DM.RoleAttr.CapitalPoint, (ushort) 0);
      this.mStatus = 2;
      ((Component) this.btn_HeroFormation).gameObject.SetActive(false);
    }
    else if (this.mOpenKind == 3 || this.mOpenKind == 9)
    {
      if (this.MapID == 0)
      {
        this.ZoneID = this.DM.RallyDesPoint.zoneID;
        this.PointID = this.DM.RallyDesPoint.pointID;
      }
      else
      {
        this.ZoneID = this.DM.WarlobbyDetail.AllyCapitalPoint.zoneID;
        this.PointID = this.DM.WarlobbyDetail.AllyCapitalPoint.pointID;
      }
      this.Distance_Total = DataManager.MapDataController.CalcDistance(GameConstants.PointCodeToMapID(this.ZoneID, this.PointID), this.DM.RoleAttr.CapitalPoint, (ushort) 0);
      this.mStatus = 3;
      if (this.MapID == 1)
      {
        this.mStatus = 4;
        this.AllyName.ClearString();
        this.AllyName.Append(this.DM.WarlobbyDetail.AllyName);
        ((Component) this.btn_HeroFormation).gameObject.SetActive(false);
        for (int index = 0; index < 4; ++index)
          this.WarlobbyTroopData[index] = new uint[4];
        if (this.DM.WarlobbyDetail.AttackOrDefense == (byte) 0 && this.DM.WarTroop.Count > 0)
        {
          this.WarlobbyTroopTotalTroopNum = this.DM.WarTroop[0].TotalTroopNum;
          for (int index = 0; index < 16; ++index)
            this.WarlobbyTroopData[index >> 2][index & 3] = this.DM.WarTroop[0].TroopData[index & 3][3 - (index >> 2)];
        }
        this.Text_W_MenuKind[3].text = this.DM.mStringTable.GetStringByID(14715U);
        this.mWarlobbyKind = (byte) 0;
      }
      else
      {
        ((Component) this.Img_MusterTimeBG).gameObject.SetActive(true);
        this.Cstr_MusterTime.ClearString();
        this.mRallyCountDown[0] = (ushort) 5;
        this.mRallyCountDown[1] = (ushort) 10;
        this.mRallyCountDown[2] = (ushort) 60;
        this.mRallyCountDown[3] = (ushort) 480;
        if (this.DM.RallyCountDownIndex < (byte) 2)
        {
          this.Cstr_MusterTime.IntToFormat((long) this.mRallyCountDown[(int) this.DM.RallyCountDownIndex]);
          this.Cstr_MusterTime.AppendFormat(this.DM.mStringTable.GetStringByID(696U));
        }
        else
        {
          this.Cstr_MusterTime.IntToFormat((long) ((int) this.mRallyCountDown[(int) this.DM.RallyCountDownIndex] / 60));
          this.Cstr_MusterTime.AppendFormat(this.DM.mStringTable.GetStringByID(848U));
        }
        this.Text_MusterTime.text = this.Cstr_MusterTime.ToString();
        this.Text_MusterTime.SetAllDirty();
        this.Text_MusterTime.cachedTextGenerator.Invalidate();
      }
    }
    else if (this.mOpenKind == 4)
    {
      this.mLoad_T.gameObject.SetActive(false);
      this.mLoadBG_T.gameObject.SetActive(false);
      this.mTime_T.gameObject.SetActive(false);
      ((Component) this.Img_MusterTimeBG).gameObject.SetActive(true);
      this.mRallyCountDown[0] = (ushort) 1;
      this.mRallyCountDown[1] = (ushort) 4;
      this.mRallyCountDown[2] = (ushort) 8;
      this.mRallyCountDown[3] = (ushort) 12;
      this.Cstr_MusterTime.ClearString();
      this.Cstr_MusterTime.IntToFormat((long) this.mRallyCountDown[(int) this.DM.RallyCountDownIndex]);
      this.Cstr_MusterTime.AppendFormat(this.DM.mStringTable.GetStringByID(8588U));
      this.Text_MusterTime.text = this.Cstr_MusterTime.ToString();
      this.Text_MusterTime.SetAllDirty();
      this.Text_MusterTime.cachedTextGenerator.Invalidate();
    }
    else if (this.mOpenKind == 5)
    {
      this.Distance_Total = DataManager.MapDataController.CalcDistance(GameConstants.PointCodeToMapID(AmbushManager.Instance.ObjPoint.zoneID, AmbushManager.Instance.ObjPoint.pointID), this.DM.RoleAttr.CapitalPoint, (ushort) 0);
      this.mStatus = 0;
    }
    else if (this.mOpenKind == 6)
    {
      this.mSave_T.gameObject.SetActive(true);
      RectTransform component14 = this.mTroops_T.transform.GetComponent<RectTransform>();
      component14.anchoredPosition = new Vector2(component14.anchoredPosition.x, 123f);
      RectTransform component15 = this.mLoad_T.transform.GetComponent<RectTransform>();
      component15.anchoredPosition = new Vector2(component15.anchoredPosition.x, 40f);
      RectTransform component16 = this.mLoadBG_T.transform.GetComponent<RectTransform>();
      component16.anchoredPosition = new Vector2(component16.anchoredPosition.x, 10f);
      this.mTime_T.gameObject.SetActive(false);
      this.mStatus = 0;
      this.tmpTMD = new TroopMemoryData();
      this.tmpTMD.Leader = new ushort[5];
      this.tmpTMD.TroopData = new uint[16];
      this.TMD_Idx = (byte) arg1;
      this.TMD_Name = string.Empty;
      if (this.DM.TeamName.Length == 0 && this.DM.mTroopMemoryData[(int) this.TMD_Idx].Label != null && this.DM.mTroopMemoryData[(int) this.TMD_Idx].Label != string.Empty)
        this.TMD_Name = this.DM.mTroopMemoryData[(int) this.TMD_Idx].Label;
      else if (this.DM.TeamName.Length == 0)
      {
        this.Cstr_TeamName.ClearString();
        this.Cstr_TeamName.IntToFormat((long) ((int) this.TMD_Idx + 1));
        this.Cstr_TeamName.AppendFormat(this.DM.mStringTable.GetStringByID(993U));
        this.TMD_Name = this.Cstr_TeamName.ToString();
      }
      else
        this.TMD_Name = this.DM.TeamName.ToString();
      this.Text_Name.text = this.TMD_Name;
      this.Text_Name.SetAllDirty();
      this.Text_Name.cachedTextGenerator.Invalidate();
      if (!this.bExpeditionHero && this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader != null && this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[0] != (ushort) 0)
      {
        this.DM.LegionBattleHero.Clear();
        this.bExpeditionHero = true;
        bool flag = false;
        int index1 = 0;
        for (int index2 = 0; index2 < 5; ++index2)
        {
          if (this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index2] != (ushort) 0 && (int) this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index2] == (int) this.DM.GetLeaderID())
          {
            flag = true;
            index1 = index2;
            break;
          }
        }
        for (int index3 = 0; index3 < 5; ++index3)
        {
          if (flag && index1 != 0)
          {
            if (index3 == 0)
              this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index1]);
            else if (index3 == index1)
              this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[0]);
            else
              this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index3]);
          }
          else if (this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index3] != (ushort) 0)
            this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index3]);
        }
      }
      for (int index = 0; index < 16; ++index)
      {
        if (this.DM.mTroopMemoryData[(int) this.TMD_Idx].TroopData[index] != 0U)
          this.DM.mExpeditionSoldierList[index] = this.DM.mTroopMemoryData[(int) this.TMD_Idx].TroopData[index];
      }
      this.DM.bSetExpediton = true;
      this.UpDataSoldier();
    }
    else if (this.mOpenKind == 7)
    {
      MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.MapID];
      this.Distance_Total = DataManager.MapDataController.CalcDistance(this.MapID, this.DM.RoleAttr.CapitalPoint, (ushort) 0);
      if ((int) mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
        this.mWonderId = DataManager.MapDataController.YolkPointTable[(int) mapPoint.tableID].WonderID;
      this.mStatus = 0;
    }
    else if (this.mOpenKind == 8)
    {
      this.mWonderId = (byte) this.MapID;
      this.Distance_Total = DataManager.MapDataController.CalcDistance(GameConstants.PointCodeToMapID(this.DM.WarlobbyDetail.EnemyCapitalPoint.zoneID, this.DM.WarlobbyDetail.EnemyCapitalPoint.pointID), this.DM.RoleAttr.CapitalPoint, (ushort) 0);
      this.mStatus = 0;
      for (int index = 0; index < 4; ++index)
        this.WarlobbyTroopData[index] = new uint[4];
      if (this.DM.WarlobbyDetail.AttackOrDefense == (byte) 2 && this.DM.WarTroop.Count > 0)
      {
        this.WarlobbyTroopTotalTroopNum = this.DM.WarTroop[0].TotalTroopNum;
        for (int index = 0; index < 16; ++index)
          this.WarlobbyTroopData[index >> 2][index & 3] = this.DM.WarTroop[0].TroopData[index & 3][3 - (index >> 2)];
        this.Text_W_MenuKind[3].text = this.DM.mStringTable.GetStringByID(14716U);
        this.mWarlobbyKind = (byte) 2;
      }
    }
    else if (this.mOpenKind == 10)
    {
      this.mApply_T.gameObject.SetActive(true);
      RectTransform component17 = this.mTroops_T.transform.GetComponent<RectTransform>();
      component17.anchoredPosition = new Vector2(component17.anchoredPosition.x, 70f);
      this.mTime_T.gameObject.SetActive(false);
      this.mLoad_T.gameObject.SetActive(false);
      this.mLoadBG_T.gameObject.SetActive(false);
    }
    this.EGASpeed = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED);
    this.EGASpeed2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_DEBUFF);
    this.EGASpeed3 = 0U;
    this.EGASpeed4 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_CURSE);
    this.EGACapacityKind = 0U;
    this.BaseNum = this.GUIM.BuildingData.GetBuildLevelRequestData((ushort) 8, this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level).Value1;
    this.Hero_Total = this.BaseNum;
    if (!this.bExpeditionHero)
    {
      if (this.mOpenKind == 1)
      {
        if (this.DM.LegionBattleHero.Count > 0)
        {
          this.BG_T1.gameObject.SetActive(false);
          this.BG_T2.gameObject.SetActive(true);
        }
        else
        {
          this.BG_T1.gameObject.SetActive(true);
          this.BG_T2.gameObject.SetActive(false);
        }
        this.SetHero_Total();
      }
    }
    else if (this.mOpenKind != 4)
    {
      this.BG_T1.gameObject.SetActive(false);
      this.BG_T2.gameObject.SetActive(true);
      this.SetHero_Total();
    }
    if (this.mOpenKind == 4)
    {
      ((Component) this.Img_Frame).gameObject.SetActive(true);
      this.BG_T1.gameObject.SetActive(false);
      this.BG_T2.gameObject.SetActive(false);
      this.SetHero_Total();
    }
    switch (this.mStatus)
    {
      case 0:
        ((Component) this.Text_Load[3]).gameObject.SetActive(true);
        this.Text_Load[3].text = this.DM.mStringTable.GetStringByID(697U);
        ((Component) this.Img_StatusBG2[0]).gameObject.SetActive(true);
        this.Text_Hint[1].text = this.DM.mStringTable.GetStringByID(769U);
        this.Img_StatusBG.sprite = this.SArray.m_Sprites[13];
        this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ATTACK_MARCH_SPEED);
        this.EGALoadKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_LOAD);
        this.tmpLoad = (float) (10000U + this.EGALoadKind);
        this.Text_HeroTeam.text = this.DM.mStringTable.GetStringByID(690U);
        NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT, (object) this);
        if (this.mOpenKind == 4)
          this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_SHELTER_TROOP_AMOUNT);
        if (this.mOpenKind == 8 && this.DM.WarTroop.Count > 0)
        {
          if (this.DM.GetTechLevel((ushort) 191) != (byte) 0)
          {
            ((Component) this.btn_Formation).gameObject.SetActive(false);
            this.mWarlobbyT.gameObject.SetActive(true);
          }
          this.Set_W_SelectText(this.DM.mWarlobby_Kind);
          break;
        }
        break;
      case 1:
        if (this.DM.GetTechLevel((ushort) 119) != (byte) 0)
          this.bShowSelectC = true;
        if (this.bShowSelectC)
        {
          ((Component) this.btn_Formation).gameObject.SetActive(false);
          ((Component) this.btn_SelectMenu[0]).gameObject.SetActive(true);
          ((Component) this.btn_SelectMenu[1]).gameObject.SetActive(true);
        }
        else
        {
          ((Component) this.btn_Formation).gameObject.SetActive(true);
          ((Component) this.btn_SelectMenu[0]).gameObject.SetActive(false);
          ((Component) this.btn_SelectMenu[1]).gameObject.SetActive(false);
        }
        if (this.DM.mcollectionKind != byte.MaxValue)
        {
          this.mUI_CK = this.DM.mcollectionKind;
          this.mNewType = (byte) ((uint) this.mUI_CK + 1U);
          if (this.mUI_CK != byte.MaxValue)
          {
            if (this.mUI_CK < (byte) 2)
            {
              ((Component) this.Img_SelectMenu[0]).gameObject.SetActive(true);
              ((Component) this.Img_SelectMenu[1]).gameObject.SetActive(false);
            }
            else
            {
              ((Component) this.Img_SelectMenu[0]).gameObject.SetActive(false);
              ((Component) this.Img_SelectMenu[1]).gameObject.SetActive(true);
            }
          }
        }
        this.ResourcesMax = DataManager.MapDataController.ResourcesPointTable[(int) this.nowMapPoint.tableID].count;
        ((Component) this.Text_Load[1]).gameObject.SetActive(true);
        ((Component) this.Text_Load[2]).gameObject.SetActive(true);
        this.Cstr_LoadNum[1].ClearString();
        this.Cstr_LoadNum[1].IntToFormat((long) this.ResourcesMax, bNumber: true);
        this.Cstr_LoadNum[1].AppendFormat("{0}");
        this.Text_Load[1].text = this.Cstr_LoadNum[1].ToString();
        this.Text_Load[1].SetAllDirty();
        this.Text_Load[1].cachedTextGenerator.Invalidate();
        this.Text_Load[1].cachedTextGeneratorForLayout.Invalidate();
        this.Text_LoadRT.sizeDelta = new Vector2(this.Text_Load[1].preferredWidth, this.Text_LoadRT.sizeDelta.y);
        this.tmpL = Mathf.Ceil(this.Text_LoadRT.anchoredPosition.x + this.Text_Load[1].preferredWidth) - 20f;
        this.Img_TargetRT.anchoredPosition = new Vector2(-this.tmpL, this.Img_TargetRT.anchoredPosition.y);
        ((Graphic) this.Text_Load[2]).rectTransform.anchoredPosition = new Vector2(-this.tmpL - this.Img_TargetRT.sizeDelta.x, ((Graphic) this.Text_Load[2]).rectTransform.anchoredPosition.y);
        ((Component) this.Img_TargetBG).gameObject.SetActive(true);
        ((Component) this.Img_StatusBG2[0]).gameObject.SetActive(true);
        this.Img_StatusBG.sprite = this.SArray.m_Sprites[13];
        ((MaskableGraphic) this.Img_TargetBG).material = this.door.LoadMaterial();
        this.Text_Hint[1].text = this.DM.mStringTable.GetStringByID(336U);
        this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_GATHERING_MARCH_SPEED);
        this.EGALoadKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_LOAD);
        this.tmpLoad = (float) (10000U + this.EGALoadKind);
        this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_GATHERING_CAPACITY);
        this.Text_HeroTeam.text = this.DM.mStringTable.GetStringByID(690U);
        break;
      case 2:
        ((Component) this.Img_StatusBG2[1]).gameObject.SetActive(true);
        this.Img_StatusBG.sprite = this.SArray.m_Sprites[14];
        ((Component) this.Text_Load[3]).gameObject.SetActive(true);
        this.Text_Load[3].text = this.DM.mStringTable.GetStringByID(698U);
        this.Text_Hint[1].text = this.DM.mStringTable.GetStringByID(692U);
        this.EGAKind = this.MapID >= 3 ? 0U : this.DM.m_InForceMarchSpeedPlus;
        this.Text_HeroTeam.text = this.DM.mStringTable.GetStringByID(821U);
        this.Cstr_LoadNum[0].ClearString();
        if (this.MapID < 2)
        {
          this.GoToMaxSoldier = this.DM.m_InForceCapacity - this.DM.m_CurrTroopAmount;
        }
        else
        {
          if (this.DM.WarlobbyDetail != null)
            this.GoToMaxSoldier = this.DM.WarlobbyDetail.AllyMAXTroop - this.DM.WarlobbyDetail.AllyCurrTroop;
          if (this.MapID >= 3)
          {
            this.Text_Load[3].text = this.DM.mStringTable.GetStringByID(7267U);
            this.Text_HeroTeam.text = this.DM.mStringTable.GetStringByID(7266U);
            this.Text_Hint[1].text = this.DM.mStringTable.GetStringByID(9303U);
          }
        }
        this.Cstr_LoadNum[0].IntToFormat((long) this.GoToMaxSoldier, bNumber: true);
        this.Cstr_LoadNum[0].AppendFormat("{0}");
        this.Text_Load[0].text = this.Cstr_LoadNum[0].ToString();
        this.Text_Load[0].SetAllDirty();
        this.Text_Load[0].cachedTextGenerator.Invalidate();
        if (this.mOpenKind == 2 && this.MapID == 4)
        {
          if (this.DM.GetTechLevel((ushort) 191) != (byte) 0)
          {
            ((Component) this.btn_Formation).gameObject.SetActive(false);
            this.mWarlobbyT.gameObject.SetActive(true);
          }
          this.Set_W_SelectText(this.DM.mWarlobby_Kind);
          break;
        }
        break;
      case 3:
      case 4:
        ((Component) this.Img_StatusBG2[2]).gameObject.SetActive(true);
        this.Img_StatusBG.sprite = this.SArray.m_Sprites[15];
        ((Component) this.Text_Load[3]).gameObject.SetActive(true);
        this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RALLY_SPEED);
        if (this.mOpenKind == 9)
        {
          if (this.mStatus == 3)
            this.EGASpeed3 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_RALLY_SPEED);
          if (this.mStatus == 4)
            this.EGASpeed3 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_JOINRALLY_SPEED);
        }
        if (this.mOpenKind == 9)
          this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_TROOP_AMOUNT);
        this.Cstr_LoadNum[0].ClearString();
        if (this.mStatus == 4)
        {
          this.Cstr_LoadNum[0].IntToFormat((long) (this.DM.WarlobbyDetail.AllyMAXTroop - this.DM.WarlobbyDetail.AllyCurrTroop), bNumber: true);
          this.Text_Load[3].text = this.DM.mStringTable.GetStringByID(699U);
          this.Text_Hint[1].text = this.DM.mStringTable.GetStringByID(693U);
          this.Text_HeroTeam.text = this.DM.mStringTable.GetStringByID(822U);
          if (this.DM.GetTechLevel((ushort) 191) != (byte) 0)
          {
            ((Component) this.btn_Formation).gameObject.SetActive(false);
            this.mWarlobbyT.gameObject.SetActive(true);
          }
          this.Set_W_SelectText(this.DM.mWarlobby_Kind);
        }
        else
        {
          this.Cstr_LoadNum[0].IntToFormat((long) (this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RALLY_CAPACITY) + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_PETSKILL_RALLY_CAPACITY)), bNumber: true);
          this.Text_Load[3].text = this.DM.mStringTable.GetStringByID(5879U);
          this.Text_HeroTeam.text = this.DM.mStringTable.GetStringByID(690U);
          this.Text_Hint[1].text = this.DM.mStringTable.GetStringByID(847U);
        }
        this.Cstr_LoadNum[0].AppendFormat("{0}");
        this.Text_Load[0].text = this.Cstr_LoadNum[0].ToString();
        this.Text_Load[0].SetAllDirty();
        this.Text_Load[0].cachedTextGenerator.Invalidate();
        break;
    }
    this.tmpTime = (float) (10000U + this.EGASpeed4) / (float) (10000U + this.EGAKind + this.EGASpeed - this.EGASpeed2 + this.EGASpeed3);
    this.Hero_Total += this.EGACapacityKind;
    this.Text_HintRT[1].sizeDelta = new Vector2(this.Text_HintRT[1].sizeDelta.x, this.Text_Hint[1].preferredHeight);
    this.Img_HintRT[1].sizeDelta = new Vector2(this.Img_HintRT[1].sizeDelta.x, this.Text_Hint[1].preferredHeight + 20f);
    if ((double) this.Text_Hint[1].preferredWidth < (double) this.Text_HintRT[1].sizeDelta.x)
    {
      this.Text_HintRT[1].sizeDelta = new Vector2(this.Text_Hint[1].preferredWidth, this.Img_HintRT[1].sizeDelta.y);
      this.Img_HintRT[1].sizeDelta = new Vector2(this.Text_Hint[1].preferredWidth + 50f, this.Img_HintRT[1].sizeDelta.y);
    }
    this.ItemBuffDataIdx = this.DM.GetRecvBuffDataIdxByID((ushort) 5);
    if (this.mOpenKind != 10)
    {
      if (this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].bEnable)
      {
        this.mEquip = this.DM.EquipTable.GetRecordByKey(this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].ItemID);
        this.mBuffTotal = (uint) this.mEquip.PropertiesInfo[1].PropertiesValue;
      }
      else
        this.mBuffTotal = 0U;
    }
    else
      this.mBuffTotal = 5000U;
    this.Hero_Total = (uint) ((double) this.Hero_Total * ((double) (10000U + this.mBuffTotal) / 10000.0));
    if (this.mStatus == 2 && this.GoToMaxSoldier < this.Hero_Total)
      this.mExpeditionlimit = (int) this.GoToMaxSoldier - (int) this.Hero_Total;
    if (this.mStatus == 4)
    {
      uint num = this.DM.WarlobbyDetail.AllyMAXTroop - this.DM.WarlobbyDetail.AllyCurrTroop;
      if (num < this.Hero_Total)
        this.mExpeditionlimit = (int) num - (int) this.Hero_Total;
    }
    this.Cstr_Troops[0].ClearString();
    this.ExpeditionNum = 0L;
    this.Cstr_Troops[0].IntToFormat(this.ExpeditionNum, bNumber: true);
    this.Cstr_Troops[0].IntToFormat((long) this.Hero_Total, bNumber: true);
    this.Cstr_Troops[0].AppendFormat("{0} / {1}");
    this.Text_Troops[0].text = this.Cstr_Troops[0].ToString();
    this.Text_Troops[0].SetAllDirty();
    this.Text_Troops[0].cachedTextGenerator.Invalidate();
    this.Cstr_Accelerate.ClearString();
    int num1 = (int) this.EGAKind + (int) this.EGASpeed - (int) this.EGASpeed2 + (int) this.EGASpeed3;
    if ((double) num1 % 100.0 != 0.0)
      this.Cstr_Accelerate.FloatToFormat((float) num1 / 100f, 2, false);
    else
      this.Cstr_Accelerate.IntToFormat((long) (num1 / 100));
    if (this.GUIM.IsArabic)
      this.Cstr_Accelerate.AppendFormat("%{0}");
    else
      this.Cstr_Accelerate.AppendFormat("{0}%");
    this.Text_Time[2].text = this.Cstr_Accelerate.ToString();
    this.Text_Time[2].SetAllDirty();
    this.Text_Time[2].cachedTextGenerator.Invalidate();
    this.Text_Time[2].cachedTextGeneratorForLayout.Invalidate();
    ((Graphic) this.Text_Time[2]).rectTransform.sizeDelta = new Vector2(this.Text_Time[2].preferredWidth, ((Graphic) this.Text_Time[2]).rectTransform.sizeDelta.y);
    ((Graphic) this.Text_Time[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Text_Time[2]).rectTransform.anchoredPosition.x - ((Graphic) this.Text_Time[2]).rectTransform.sizeDelta.x, ((Graphic) this.Text_Time[2]).rectTransform.anchoredPosition.y);
    if (this.mOpenKind != 1 && this.mOpenKind != 4 && this.mOpenKind != 6 && this.DM.GetTechLevel((ushort) 120) > (byte) 0)
    {
      this.tmpRC = ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>();
      if (((double) this.tmpRC.sizeDelta.x - 843.0) / 2.0 > 90.0)
        this.mSelectTeam_LT.gameObject.SetActive(true);
      else
        this.mSelectTeam_T.gameObject.SetActive(true);
    }
    if (this.mSelectTeam_T.gameObject.activeSelf)
    {
      this.m_ScrollPanel.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(this.m_ScrollPanel.transform.GetComponent<RectTransform>().sizeDelta.x, 344f);
      this.m_ScrollPanel.IntiScrollPanel(344f, 0.0f, 0.0f, this.tmplist, 7, (IUpDateScrollPanel) this);
    }
    else
      this.m_ScrollPanel.IntiScrollPanel(412f, 0.0f, 0.0f, this.tmplist, 7, (IUpDateScrollPanel) this);
    this.m_ScrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
    this.mContentRT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
    if (this.DM.bSetExpediton)
    {
      this.m_ScrollPanel.GoTo(this.DM.mScroll_Idx);
      this.DM.bSetExpediton = false;
      this.bPVEOpen = false;
    }
    this.bSpeed = true;
    Array.Sort<byte>(this.SpeedsortData, (IComparer<byte>) this);
    this.CheckMaxSelect();
    this.SelectFormation();
    if (this.mOpenKind == 1 && this.bPVEOpen || this.mOpenKind == 4)
      this.UpPanelData((byte) 0);
    else
      this.SetDRformURS(0);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 6);
    if ((UnityEngine.Object) this.door != (UnityEngine.Object) null && this.mOpenKind != 6 && this.mOpenKind != 10)
      this.door.ShowFightButton(new Vector3(280f, -282f, -500f), 250f, BtnKind: E3DButtonKind.BK_Big);
    this.DM.bSetExpediton = true;
    for (int index = 0; index < 16; ++index)
      this.DM.mExpeditionSoldierList[index] = (uint) this.m_Soldier[index];
    if (this.mOpenKind == 6)
      this.DM.mOpenExpeditionNum = this.ExpeditionNum;
    this.bOpenEnd = true;
  }

  public void SetaApplyEnable(UIButton sender, bool Enable)
  {
    if (Enable)
      ((Graphic) sender.image).color = Color.white;
    else
      ((Graphic) sender.image).color = Color.gray;
  }

  public void OnButtonClick(UIButton sender)
  {
    if ((double) this.fightButtonTime > 0.0)
      return;
    this.m_ScrollRect.StopMovement();
    switch (sender.m_BtnID1)
    {
      case 0:
        if (this.mOpenKind == 6)
        {
          if (this.DM.bChangHero)
          {
            if (this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[0] != (ushort) 0)
            {
              byte num = 0;
              for (int index = 0; index < 5; ++index)
              {
                if (this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index] != (ushort) 0)
                  ++num;
              }
              if (this.DM.LegionBattleHero.Count != (int) num)
              {
                GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5893U), this.DM.mStringTable.GetStringByID(997U), 3, YesText: this.DM.mStringTable.GetStringByID(3U), NoText: this.DM.mStringTable.GetStringByID(4U));
                break;
              }
              for (int index = 0; index < 5 && index < this.DM.LegionBattleHero.Count; ++index)
              {
                if ((int) this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index] != (int) this.DM.LegionBattleHero[index])
                {
                  GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5893U), this.DM.mStringTable.GetStringByID(997U), 3, YesText: this.DM.mStringTable.GetStringByID(3U), NoText: this.DM.mStringTable.GetStringByID(4U));
                  return;
                }
              }
            }
            else if (this.DM.LegionBattleHero.Count > 0)
            {
              GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5893U), this.DM.mStringTable.GetStringByID(997U), 3, YesText: this.DM.mStringTable.GetStringByID(3U), NoText: this.DM.mStringTable.GetStringByID(4U));
              break;
            }
          }
          if (this.DM.bChangSoldier)
          {
            for (int index = 0; index < 16; ++index)
            {
              if ((long) this.DM.mTroopMemoryData[(int) this.TMD_Idx].TroopData[index] != this.m_Soldier[index])
              {
                GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5893U), this.DM.mStringTable.GetStringByID(997U), 3, YesText: this.DM.mStringTable.GetStringByID(3U), NoText: this.DM.mStringTable.GetStringByID(4U));
                return;
              }
            }
          }
          if (this.DM.bChangName && string.Compare(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Label, 0, this.TMD_Name, 0, this.DM.mTroopMemoryData[(int) this.TMD_Idx].Label.Length) != 0)
          {
            GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5893U), this.DM.mStringTable.GetStringByID(997U), 3, YesText: this.DM.mStringTable.GetStringByID(3U), NoText: this.DM.mStringTable.GetStringByID(4U));
            break;
          }
        }
        this.DM.bSetExpediton = false;
        for (int index = 0; index < 16; ++index)
          this.DM.mExpeditionSoldierList[index] = 0U;
        this.DM.LegionBattleHero.Clear();
        if (this.mWarlobbyKind >= (byte) 0 && this.mWarlobbyKind <= (byte) 2)
          this.mUI_WarlobbyK = byte.MaxValue;
        if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
          this.door.CloseMenu();
        if (this.mOpenKind == 4)
          HideArmyManager.Instance.OpenHideArmyUI();
        if (this.mOpenKind == 6)
          this.DM.TeamName.ClearString();
        this.DM.bChangHero = false;
        this.DM.bChangName = false;
        this.DM.bChangSoldier = false;
        break;
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
        if (this.mOpenKind == 2 || this.mStatus == 4)
          break;
        if (this.DM.NonFightHeroCount == 0U)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(875U), (ushort) byte.MaxValue);
          break;
        }
        this.DM.bSetExpediton = true;
        this.DM.mMapId = this.MapID;
        this.DM.mScroll_Y = this.mContentRT.anchoredPosition.y;
        this.DM.mScroll_Idx = this.m_ScrollPanel.GetTopIdx();
        for (int index = 0; index < 16; ++index)
          this.DM.mExpeditionSoldierList[index] = (uint) this.m_Soldier[index];
        if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
        {
          if (this.mOpenKind != 6)
            this.door.OpenMenu(EGUIWindow.UI_HeroList_Soldier2);
          else
            this.door.OpenMenu(EGUIWindow.UI_HeroList_Soldier2, arg2: 1);
        }
        if (this.mOpenKind != 6 || this.DM.bChangHero)
          break;
        this.DM.bChangHero = true;
        break;
      case 7:
        if (!this.bClear)
        {
          this.UpPanelData((byte) 0);
          break;
        }
        this.ClearSoldier();
        break;
      case 8:
        this.ShowSelectMenu(false);
        break;
      case 9:
        if (this.mOpenKind == 0 && DataManager.MapDataController.LayoutMapInfo[this.MapID].pointKind != (byte) 0)
        {
          ushort tableId = DataManager.MapDataController.LayoutMapInfo[this.MapID].tableID;
          if (DataManager.MapDataController.IsResources((uint) tableId))
          {
            if (DataManager.MapDataController.ResourcesPointTable[(int) tableId].playerName.Length != 0 && (DataManager.CompareStr(DataManager.MapDataController.ResourcesPointTable[(int) tableId].playerName, DataManager.Instance.RoleAttr.Name) == 0 || DataManager.Instance.IsSameAlliance(DataManager.MapDataController.ResourcesPointTable[(int) tableId].allianceTag)))
            {
              this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(614U), this.DM.mStringTable.GetStringByID(645U));
              break;
            }
          }
          else if (DataManager.MapDataController.IsCityOrCamp((uint) this.MapID) && (this.MapID == DataManager.Instance.RoleAttr.CapitalPoint || DataManager.Instance.IsSameAlliance(DataManager.MapDataController.PlayerPointTable[(int) tableId].allianceTag)))
          {
            this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(614U), this.DM.mStringTable.GetStringByID(645U));
            break;
          }
        }
        if ((double) this.fightButtonTime > 0.0)
          break;
        if (this.ExpeditionNum < 1L)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(695U), (ushort) byte.MaxValue);
          break;
        }
        if (this.ExpeditionNum > (long) this.Hero_Total)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(712U), (ushort) byte.MaxValue);
          break;
        }
        if (this.mOpenKind == 0)
        {
          MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.MapID];
          POINT_KIND mapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) this.MapID);
          if (DataManager.MapDataController.IsResources((uint) this.MapID))
          {
            if (DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].playerName.Length != 0 && DataManager.CompareStr(DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].playerName, DataManager.Instance.RoleAttr.Name) != 0 && this.DM.m_BuffListOpenIcon == (byte) 1)
            {
              int warBuffCd = this.DM.GetWarBuffCD();
              if (warBuffCd > 0)
              {
                this.GUIM.MsgStr.ClearString();
                this.GUIM.MsgStr.IntToFormat((long) warBuffCd);
                this.GUIM.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9933U));
                this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4840U), this.GUIM.MsgStr.ToString(), 1, YesText: this.DM.mStringTable.GetStringByID(4842U), NoText: this.DM.mStringTable.GetStringByID(4843U));
                break;
              }
              this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4840U), this.DM.mStringTable.GetStringByID(621U), 1, YesText: this.DM.mStringTable.GetStringByID(3U), NoText: this.DM.mStringTable.GetStringByID(617U));
              break;
            }
          }
          else if (this.DM.m_BuffListOpenIcon == (byte) 1 && (mapInfoPointKind == POINT_KIND.PK_CITY || mapInfoPointKind == POINT_KIND.PK_CAMP || mapInfoPointKind == POINT_KIND.PK_YOLK))
          {
            int warBuffCd = this.DM.GetWarBuffCD();
            if (warBuffCd > 0)
            {
              this.GUIM.MsgStr.ClearString();
              this.GUIM.MsgStr.IntToFormat((long) warBuffCd);
              this.GUIM.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9933U));
              this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4840U), this.GUIM.MsgStr.ToString(), 1, YesText: this.DM.mStringTable.GetStringByID(4842U), NoText: this.DM.mStringTable.GetStringByID(4843U));
              break;
            }
            this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4840U), this.DM.mStringTable.GetStringByID(621U), 1, YesText: this.DM.mStringTable.GetStringByID(3U), NoText: this.DM.mStringTable.GetStringByID(617U));
            break;
          }
        }
        if (this.mOpenKind == 3 && this.mStatus == 4)
        {
          this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4964U), this.DM.mStringTable.GetStringByID(4965U), 2, YesText: this.DM.mStringTable.GetStringByID(4966U), NoText: this.DM.mStringTable.GetStringByID(4967U));
          break;
        }
        if (this.mOpenKind == 9 && this.mStatus == 4)
        {
          this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4964U), this.DM.mStringTable.GetStringByID(4965U), 4, YesText: this.DM.mStringTable.GetStringByID(4966U), NoText: this.DM.mStringTable.GetStringByID(4967U));
          break;
        }
        if ((this.mOpenKind == 2 || this.mOpenKind == 3 || this.mOpenKind == 5 || this.mOpenKind == 7 || this.mOpenKind == 8) && this.DM.m_BuffListOpenIcon == (byte) 1)
        {
          int warBuffCd = this.DM.GetWarBuffCD();
          if (warBuffCd > 0)
          {
            this.GUIM.MsgStr.ClearString();
            this.GUIM.MsgStr.IntToFormat((long) warBuffCd);
            this.GUIM.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9933U));
            this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4840U), this.GUIM.MsgStr.ToString(), 1, YesText: this.DM.mStringTable.GetStringByID(4842U), NoText: this.DM.mStringTable.GetStringByID(4843U));
            break;
          }
          this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(614U), this.DM.mStringTable.GetStringByID(621U), 1, YesText: this.DM.mStringTable.GetStringByID(3U), NoText: this.DM.mStringTable.GetStringByID(617U));
          break;
        }
        if (this.mOpenKind == 1 && !this.CheckPower())
        {
          this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(7376U), this.DM.mStringTable.GetStringByID(7375U), 1);
          break;
        }
        if (this.mOpenKind != 4 && this.mOpenKind != 5)
        {
          this.GUIM.ShowUILock(EUILock.Expedition);
          this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_Expedition);
        }
        if (this.mOpenKind == 1)
        {
          this.SendExpedition();
          break;
        }
        this.fightButtonTime = this.door.PlayFight();
        break;
      case 10:
      case 11:
      case 12:
      case 13:
        this.mUI_CK = (byte) (sender.m_BtnID1 - 10);
        this.mNewType = (byte) ((uint) this.mUI_CK + 1U);
        this.Text_SelectMenu[1].text = (int) this.mUI_CK % 2 != 0 ? this.DM.mStringTable.GetStringByID(334U) : this.DM.mStringTable.GetStringByID(333U);
        this.Text_SelectMenu[1].SetAllDirty();
        this.Text_SelectMenu[1].cachedTextGenerator.Invalidate();
        this.Text_SelectMenu[0].text = this.mbtnFormation[1];
        this.Text_SelectMenu[0].SetAllDirty();
        this.Text_SelectMenu[0].cachedTextGenerator.Invalidate();
        this.UpPanelData(this.mNewType);
        this.ShowSelectMenu(false);
        break;
      case 17:
        if (this.mOpenKind == 2 || this.mStatus == 4)
          break;
        if (this.DM.NonFightHeroCount == 0U && this.mOpenKind != 6)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(875U), (ushort) byte.MaxValue);
          break;
        }
        this.DM.SetSortNonFightHeroID();
        for (int index = 0; index < this.DM.GetMaxDefenders() && (long) index < (long) this.DM.NonFightHeroCount; ++index)
          this.DM.LegionBattleHero.Add((ushort) this.DM.SortNonFightHeroID[index]);
        this.BG_T1.gameObject.SetActive(false);
        this.BG_T2.gameObject.SetActive(true);
        this.SetHero_Total();
        if (this.mStatus == 1 || this.mOpenKind == 9)
          this.Hero_Total += this.EGACapacityKind;
        this.Hero_Total = (uint) ((double) this.Hero_Total * ((double) (10000U + this.mBuffTotal) / 10000.0));
        for (int index = 0; index < 7; ++index)
        {
          if ((UnityEngine.Object) this.m_UnitRS_Item[index] != (UnityEngine.Object) null)
          {
            int type = (int) this.m_UnitRS_Item[index].Type;
            long heroTotal = this.m_Soldier[this.m_UnitRS_Item[type].m_ID];
            this.m_UnitRS_Item[type].MaxValue = (long) this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0];
            this.m_UnitRS_Item[type].Value = heroTotal;
            this.m_UnitRS_Item[type].m_slider.maxValue = (double) this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0];
            this.m_UnitRS_Item[type].m_slider.value = (double) heroTotal;
            if (this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0] >= this.Hero_Total)
            {
              this.m_UnitRS_Item[type].MaxValue = (long) this.Hero_Total;
              this.m_UnitRS_Item[type].m_slider.maxValue = (double) this.Hero_Total;
            }
            if (heroTotal >= (long) this.Hero_Total)
            {
              this.m_UnitRS_Item[type].Value = (long) this.Hero_Total;
              this.m_UnitRS_Item[type].m_slider.value = (double) this.Hero_Total;
              heroTotal = (long) this.Hero_Total;
            }
            this.Cstr_Soldier_Text[type].ClearString();
            this.Cstr_Soldier_Text[type].IntToFormat(heroTotal, bNumber: true);
            this.Cstr_Soldier_Text[type].AppendFormat("{0}");
            this.m_UnitRS_Item[type].m_inputText.text = this.Cstr_Soldier_Text[type].ToString();
            this.m_UnitRS_Item[type].m_inputText.SetAllDirty();
            this.m_UnitRS_Item[type].m_inputText.cachedTextGenerator.Invalidate();
            if (heroTotal != 0L)
              ((Graphic) this.m_UnitRS_Item[type].m_inputText).color = this.mtextColor;
            else
              ((Graphic) this.m_UnitRS_Item[type].m_inputText).color = Color.white;
            this.Cstr_Soldier_ItemNum[type].ClearString();
            this.Cstr_Soldier_ItemNum[type].IntToFormat((long) this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0] - heroTotal, bNumber: true);
            this.Cstr_Soldier_ItemNum[type].AppendFormat("{0}");
            this.Text_Soldier_ItemNum[type].text = this.Cstr_Soldier_ItemNum[type].ToString();
            this.Text_Soldier_ItemNum[type].SetAllDirty();
            this.Text_Soldier_ItemNum[type].cachedTextGenerator.Invalidate();
          }
        }
        this.SetDRformURS(0);
        if (this.mStatus == 1)
        {
          this.CheckMaxSelect();
          this.SelectFormation();
        }
        if (this.mOpenKind != 6 || this.DM.bChangHero)
          break;
        this.DM.bChangHero = true;
        break;
      case 18:
        this.DM.LegionBattleHero.Clear();
        this.BG_T1.gameObject.SetActive(true);
        this.BG_T2.gameObject.SetActive(false);
        this.SetHero_Total();
        if (this.mStatus == 1 || this.mOpenKind == 9)
          this.Hero_Total += this.EGACapacityKind;
        this.Hero_Total = (uint) ((double) this.Hero_Total * ((double) (10000U + this.mBuffTotal) / 10000.0));
        for (int index = 0; index < 7; ++index)
        {
          if ((UnityEngine.Object) this.m_UnitRS_Item[index] != (UnityEngine.Object) null)
          {
            int type = (int) this.m_UnitRS_Item[index].Type;
            long heroTotal = this.m_Soldier[this.m_UnitRS_Item[type].m_ID];
            this.m_UnitRS_Item[type].MaxValue = (long) this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0];
            this.m_UnitRS_Item[type].Value = heroTotal;
            this.m_UnitRS_Item[type].m_slider.maxValue = (double) this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0];
            this.m_UnitRS_Item[type].m_slider.value = (double) heroTotal;
            if (this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0] >= this.Hero_Total)
            {
              this.m_UnitRS_Item[type].MaxValue = (long) this.Hero_Total;
              this.m_UnitRS_Item[type].m_slider.maxValue = (double) this.Hero_Total;
            }
            if (heroTotal >= (long) this.Hero_Total)
            {
              this.m_UnitRS_Item[type].Value = (long) this.Hero_Total;
              this.m_UnitRS_Item[type].m_slider.value = (double) this.Hero_Total;
              heroTotal = (long) this.Hero_Total;
              this.m_Soldier[this.m_UnitRS_Item[type].m_ID] = heroTotal;
            }
            this.Cstr_Soldier_Text[type].ClearString();
            this.Cstr_Soldier_Text[type].IntToFormat(heroTotal, bNumber: true);
            this.Cstr_Soldier_Text[type].AppendFormat("{0}");
            this.m_UnitRS_Item[type].m_inputText.text = this.Cstr_Soldier_Text[type].ToString();
            this.m_UnitRS_Item[type].m_inputText.SetAllDirty();
            this.m_UnitRS_Item[type].m_inputText.cachedTextGenerator.Invalidate();
            if (heroTotal != 0L)
              ((Graphic) this.m_UnitRS_Item[type].m_inputText).color = this.mtextColor;
            else
              ((Graphic) this.m_UnitRS_Item[type].m_inputText).color = Color.white;
            this.Cstr_Soldier_ItemNum[type].ClearString();
            this.Cstr_Soldier_ItemNum[type].IntToFormat((long) this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0] - heroTotal, bNumber: true);
            this.Cstr_Soldier_ItemNum[type].AppendFormat("{0}");
            this.Text_Soldier_ItemNum[type].text = this.Cstr_Soldier_ItemNum[type].ToString();
            this.Text_Soldier_ItemNum[type].SetAllDirty();
            this.Text_Soldier_ItemNum[type].cachedTextGenerator.Invalidate();
          }
        }
        this.SetDRformURS(0);
        if (this.mStatus == 1)
        {
          this.CheckMaxSelect();
          this.SelectFormation();
        }
        if (this.mOpenKind != 6 || this.DM.bChangHero)
          break;
        this.DM.bChangHero = true;
        break;
      case 19:
        this.GUIM.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
        this.GUIM.m_UICalculator.OpenCalculator(this.m_UnitRS_Item[sender.m_BtnID2].MaxValue, this.m_UnitRS_Item[sender.m_BtnID2].Value, 289f, -100f, this.m_UnitRS_Item[sender.m_BtnID2], 0L);
        break;
      case 20:
        if (this.DM.GetHeroState(this.DM.GetLeaderID()) == eHeroState.None)
        {
          this.bCaveMainHero = !this.bCaveMainHero;
          ((Component) this.Img_CaveStatus).gameObject.SetActive(this.bCaveMainHero);
          if (this.bCaveMainHero)
            this.DM.LegionBattleHero.Add(this.DM.GetLeaderID());
          else
            this.DM.LegionBattleHero.Clear();
          this.SetHero_Total();
          if (this.mOpenKind != 10)
          {
            if (this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].bEnable)
            {
              this.mEquip = this.DM.EquipTable.GetRecordByKey(this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].ItemID);
              this.mBuffTotal = (uint) this.mEquip.PropertiesInfo[1].PropertiesValue;
            }
            else
              this.mBuffTotal = 0U;
          }
          else
            this.mBuffTotal = 5000U;
          this.Hero_Total += this.EGACapacityKind;
          this.Hero_Total = (uint) ((double) this.Hero_Total * ((double) (10000U + this.mBuffTotal) / 10000.0));
          this.SetDRformURS(0);
          break;
        }
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(708U), (ushort) byte.MaxValue);
        break;
      case 21:
        if (this.mUI_CK != byte.MaxValue)
        {
          if (!this.bClear)
          {
            this.UpPanelData(this.mNewType);
            break;
          }
          this.ClearSoldier();
          break;
        }
        this.ShowSelectMenu(true);
        break;
      case 22:
        this.ShowSelectMenu(true);
        break;
      case 23:
        if (!this.DM.bChangName)
          this.DM.bChangName = true;
        this.DM.OpenAllianceBox((ushort) 39, 10, Para: 0L);
        break;
      case 24:
        if (this.ExpeditionNum > (long) this.Hero_Total)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(712U), (ushort) byte.MaxValue);
          break;
        }
        this.SendSaveTeam();
        break;
      case 25:
        if (this.mOpenKind != 10)
        {
          if (this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].bEnable)
          {
            this.mEquip = this.DM.EquipTable.GetRecordByKey(this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].ItemID);
            this.mBuffTotal = (uint) this.mEquip.PropertiesInfo[1].PropertiesValue;
          }
          else
            this.mBuffTotal = 0U;
        }
        else
          this.mBuffTotal = 5000U;
        this.Hero_Total = this.BaseNum;
        int btnId2 = sender.m_BtnID2;
        if (btnId2 < 0 && btnId2 > 5)
          break;
        CString cstring = StringManager.Instance.StaticString1024();
        if (btnId2 + 1 > (int) this.DM.GetTechLevel((ushort) 120))
        {
          cstring.StringToFormat(this.DM.mStringTable.GetStringByID(5220U));
          cstring.AppendFormat(this.DM.mStringTable.GetStringByID(3775U));
          this.GUIM.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
          break;
        }
        long num1 = 0;
        for (int index = 0; index < 16; ++index)
          num1 += (long) this.DM.mTroopMemoryData[btnId2].TroopData[index];
        if (this.DM.mTroopMemoryData[btnId2].Leader[0] == (ushort) 0 && num1 == 0L)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(995U), (ushort) byte.MaxValue);
          break;
        }
        bool flag1 = false;
        this.DM.LegionBattleHero.Clear();
        if (this.mOpenKind != 2 && this.mStatus != 4 && this.mOpenKind != 4)
        {
          bool flag2 = false;
          int index1 = 0;
          int num2 = 0;
          for (int index2 = 0; index2 < 5; ++index2)
          {
            eHeroState heroState = this.DM.GetHeroState(this.DM.mTroopMemoryData[btnId2].Leader[index2]);
            if (this.DM.mTroopMemoryData[btnId2].Leader[index2] != (ushort) 0 && heroState == eHeroState.None)
            {
              if ((int) this.DM.mTroopMemoryData[btnId2].Leader[index2] == (int) this.DM.GetLeaderID())
              {
                flag2 = true;
                index1 = index2;
              }
              ++num2;
            }
          }
          for (int index3 = 0; index3 < 5; ++index3)
          {
            if (this.DM.mTroopMemoryData[btnId2].Leader[index3] > (ushort) 0)
            {
              if (this.DM.GetHeroState(this.DM.mTroopMemoryData[btnId2].Leader[index3]) == eHeroState.None)
              {
                if (flag2 && index1 != 0)
                {
                  if (index3 == 0)
                    this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[btnId2].Leader[index1]);
                  else if (num2 < 5 && index3 == num2 - 1)
                    this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[btnId2].Leader[0]);
                  else if (num2 == 5 && (int) this.DM.mTroopMemoryData[btnId2].Leader[index3] == (int) this.DM.GetLeaderID())
                    this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[btnId2].Leader[0]);
                  else
                    this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[btnId2].Leader[index3]);
                }
                else
                  this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[btnId2].Leader[index3]);
              }
              else
                flag1 = true;
            }
          }
          if (this.DM.LegionBattleHero.Count > 0)
          {
            this.bExpeditionHero = true;
            this.BG_T1.gameObject.SetActive(false);
            this.BG_T2.gameObject.SetActive(true);
          }
          else
          {
            this.bExpeditionHero = false;
            this.BG_T1.gameObject.SetActive(true);
            this.BG_T2.gameObject.SetActive(false);
          }
        }
        this.DM.bSetExpediton = true;
        this.SetHero_Total();
        if (this.mStatus == 1 || this.mOpenKind == 9)
          this.Hero_Total += this.EGACapacityKind;
        this.Hero_Total = (uint) ((double) this.Hero_Total * ((double) (10000U + this.mBuffTotal) / 10000.0));
        long num3 = (long) this.Hero_Total + (long) this.mExpeditionlimit;
        if (num3 < (long) this.DM.mTroopMemoryData[btnId2].MaxTroop && num1 > num3)
        {
          double num4 = (double) num3 / (double) this.DM.mTroopMemoryData[btnId2].MaxTroop;
          for (int index = 0; index < 16; ++index)
            this.DM.mExpeditionSoldierList[index] = (uint) ((double) this.DM.mTroopMemoryData[btnId2].TroopData[index] * num4);
        }
        else
        {
          for (int index = 0; index < 16; ++index)
            this.DM.mExpeditionSoldierList[index] = this.DM.mTroopMemoryData[btnId2].TroopData[index];
        }
        for (int index = 0; index < 16; ++index)
        {
          ushort num5 = (ushort) (4 - index / 4 + index % 4 * 4);
          if (this.DM.mExpeditionSoldierList[index] > this.DM.RoleAttr.m_Soldier[(int) num5 - 1])
          {
            this.DM.mExpeditionSoldierList[index] = this.DM.RoleAttr.m_Soldier[(int) num5 - 1];
            flag1 = true;
          }
        }
        this.ClearSoldier();
        this.UpDataSoldier();
        this.bSpeed = true;
        Array.Sort<byte>(this.SpeedsortData, (IComparer<byte>) this);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        this.SetDRformURS(0);
        if (flag1)
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(994U), (ushort) byte.MaxValue);
        cstring.ClearString();
        cstring.StringToFormat(this.DM.mTroopMemoryData[btnId2].Label);
        cstring.AppendFormat(this.DM.mStringTable.GetStringByID(996U));
        this.GUIM.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
        this.CheckMaxSelect();
        this.SelectFormation();
        break;
      case 26:
        this.SendExpedition();
        break;
      case 27:
        this.SetWarlobbyMenu(true, (byte) 0);
        break;
      case 28:
        if (this.mUI_WarlobbyK != byte.MaxValue)
        {
          if (!this.bClear)
          {
            if (this.mUI_WarlobbyK == (byte) 0)
            {
              this.UpPanelData((byte) 0);
              break;
            }
            this.CheckWarlobbyTroopSelect(this.mUI_WarlobbyK);
            this.SetWarlobbyMenu(true, (byte) 1);
            break;
          }
          this.ClearSoldier();
          break;
        }
        this.SetWarlobbyMenu(true, (byte) 0);
        break;
      case 29:
        this.mUI_WarlobbyK_btn = byte.MaxValue;
        this.SetWarlobbyMenu(false, (byte) 0);
        break;
      case 30:
        this.mUI_WarlobbyK_btn = byte.MaxValue;
        this.SetWarlobbyMenu(false, (byte) 0);
        break;
      case 31:
        this.mUI_WarlobbyK = (byte) 0;
        this.SetWarlobbyMenu(false, (byte) 0);
        this.Set_W_SelectText((byte) 0, true);
        this.UpPanelData((byte) 0);
        break;
      case 32:
      case 33:
        this.mUI_WarlobbyK_btn = (byte) (sender.m_BtnID1 - 31);
        this.CheckWarlobbyTroopSelect(this.mUI_WarlobbyK_btn);
        this.SetWarlobbyMenu(true, (byte) 1);
        break;
      case 34:
        if (sender.m_BtnType == e_BtnType.e_ChangeText)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(14725U), (ushort) byte.MaxValue);
          break;
        }
        if (this.WarlobbySelectQty != this.WarlobbyTroopMax && this.GUIM.OpenCheckWarlobbyTroopSelect())
          break;
        if (this.mUI_WarlobbyK_btn != byte.MaxValue)
          this.mUI_WarlobbyK = this.mUI_WarlobbyK_btn;
        this.SetWarlobbyMenu(false, (byte) 0);
        this.SetWarlobbyTroopSelect();
        break;
    }
  }

  public void SendSaveTeam()
  {
    for (int index = 0; index < 5; ++index)
      this.tmpTMD.Leader[index] = (ushort) this.Hero_ID[index];
    this.tmpTMD.MaxTroop = this.Hero_Total;
    for (int index1 = 0; index1 < 16; ++index1)
    {
      int index2 = (3 - index1 % 4) * 4 + index1 / 4;
      this.tmpTMD.TroopData[index1] = (uint) this.m_Soldier[index2];
    }
    this.Cstr_TeamName.ClearString();
    this.Cstr_TeamName.IntToFormat((long) ((int) this.TMD_Idx + 1));
    this.Cstr_TeamName.AppendFormat(this.DM.mStringTable.GetStringByID(993U));
    this.tmpTMD.Label = string.Compare(this.Cstr_TeamName.ToString(), 0, this.TMD_Name, 0, this.Cstr_TeamName.Length) != 0 ? this.TMD_Name : string.Empty;
    this.DM.SendTroopmemory_Setup(this.TMD_Idx, this.tmpTMD);
  }

  public void ShowSelectMenu(bool bopen)
  {
    if (bopen)
      ((Component) this.btn_FormationMenu).gameObject.SetActive(true);
    else
      ((Component) this.btn_FormationMenu).gameObject.SetActive(false);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 1:
        if (this.mOpenKind != 5)
        {
          this.GUIM.ShowUILock(EUILock.Expedition);
          this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_Expedition);
        }
        this.SendExpedition();
        break;
      case 2:
        if (this.DM.m_BuffListOpenIcon == (byte) 1)
        {
          int warBuffCd = this.DM.GetWarBuffCD();
          if (warBuffCd > 0)
          {
            this.GUIM.MsgStr.ClearString();
            this.GUIM.MsgStr.IntToFormat((long) warBuffCd);
            this.GUIM.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9933U));
            this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4840U), this.GUIM.MsgStr.ToString(), 1, YesText: this.DM.mStringTable.GetStringByID(4842U), NoText: this.DM.mStringTable.GetStringByID(4843U));
            break;
          }
          this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(614U), this.DM.mStringTable.GetStringByID(621U), 1, YesText: this.DM.mStringTable.GetStringByID(3U), NoText: this.DM.mStringTable.GetStringByID(617U));
          break;
        }
        this.GUIM.ShowUILock(EUILock.Expedition);
        this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_Expedition);
        this.SendExpedition();
        break;
      case 3:
        this.DM.bSetExpediton = false;
        for (int index = 0; index < 16; ++index)
          this.DM.mExpeditionSoldierList[index] = 0U;
        this.DM.LegionBattleHero.Clear();
        if (this.mOpenKind == 6)
          this.DM.TeamName.ClearString();
        if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
          this.door.CloseMenu();
        this.DM.bChangHero = false;
        this.DM.bChangName = false;
        this.DM.bChangSoldier = false;
        break;
      case 4:
        this.GUIM.ShowUILock(EUILock.Expedition);
        this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_Expedition);
        this.SendExpedition();
        break;
    }
  }

  public bool CheckPower()
  {
    StageManager stageDataController = DataManager.StageDataController;
    float num1 = 0.0f;
    float num2 = 0.0f;
    for (int index = 0; index < 16; ++index)
    {
      if (this.m_Soldier[index] > 0L)
      {
        this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) (4 - index / 4 + index % 4 * 4));
        num1 += (float) this.m_Soldier[index] * this.tmpPVEPower[(int) this.tmpSD.Tier - 1];
      }
    }
    for (int index = 0; index < (int) stageDataController.mStageTroopsCount; ++index)
    {
      if (stageDataController.NowCombatStageInfo[index].Amount > 0U)
      {
        this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) stageDataController.NowCombatStageInfo[index].SoldierTableID);
        num2 += (float) stageDataController.NowCombatStageInfo[index].Amount * this.tmpPVEPower[(int) this.tmpSD.Tier - 1];
      }
    }
    for (int stageTroopsCount = (int) stageDataController.mStageTroopsCount; stageTroopsCount < (int) stageDataController.mStageTroopsCount + (int) stageDataController.mStageTrapsCount; ++stageTroopsCount)
    {
      if (stageDataController.CorpsStageWallDefence > 0U && stageDataController.NowCombatStageInfo[stageTroopsCount].Amount > 0U)
      {
        this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) stageDataController.NowCombatStageInfo[stageTroopsCount].SoldierTableID);
        num2 += (float) stageDataController.NowCombatStageInfo[stageTroopsCount].Amount * this.tmpPVEPower[(int) this.tmpSD.Tier - 1];
      }
    }
    return (double) num1 > (double) num2;
  }

  public void SendExpedition()
  {
    if (this.ExpeditionNum < 1L)
    {
      this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(695U), (ushort) byte.MaxValue);
    }
    else
    {
      this.DM.mMapId = 0;
      this.DM.bSetExpediton = false;
      if (this.mOpenKind == 3 || this.mOpenKind == 9)
      {
        if (this.mStatus == 4)
        {
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          uint[] numArray1 = new uint[16];
          for (int index1 = 0; index1 < 16; ++index1)
          {
            int index2 = (3 - index1 % 4) * 4 + index1 / 4;
            numArray1[index1] = (uint) this.m_Soldier[index2];
          }
          messagePacket.Protocol = Protocol._MSG_REQUEST_JOIN_RALLY;
          ushort data = 0;
          int num1 = 1;
          byte[] numArray2 = new byte[64];
          int num2 = 0;
          messagePacket.AddSeqId();
          messagePacket.Add(this.AllyName.ToString(), 13);
          for (int index = 0; index < numArray1.Length; ++index)
          {
            if (numArray1[index] != 0U)
            {
              data |= (ushort) (num1 << index);
              GameConstants.GetBytes(numArray1[index], numArray2, num2);
              num2 += 4;
            }
          }
          messagePacket.Add(data);
          messagePacket.Add(numArray2, len: num2);
          messagePacket.Send();
        }
        else
        {
          ushort[] LeaderID = new ushort[5];
          uint[] TroopData = new uint[16];
          for (int index = 0; index < 5; ++index)
            LeaderID[index] = (ushort) this.Hero_ID[index];
          for (int index3 = 0; index3 < 16; ++index3)
          {
            int index4 = (3 - index3 % 4) * 4 + index3 / 4;
            TroopData[index3] = (uint) this.m_Soldier[index4];
          }
          this.DM.SendBeginRally(ref LeaderID, ref TroopData);
        }
      }
      else if (this.mOpenKind < 3)
      {
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        if (this.mOpenKind < 2)
        {
          if (this.mOpenKind == 0)
          {
            messagePacket.Protocol = Protocol._MSG_REQUEST_TROOPMARCH;
            this.DM.mMapId = this.MapID;
          }
          else
          {
            messagePacket.Protocol = Protocol._MSG_REQUEST_COMBATINIT_NPC;
            Array.Clear((Array) this.DM.pLeftTroopForce, 0, this.DM.pLeftTroopForce.Length);
            for (int index = 0; index < 5; ++index)
              this.DM.pLeftLeaderData[index] = new TroopLeaderType();
            this.DM.War_LeftHeroNum = (byte) 0;
            for (int index = 0; index < 5; ++index)
            {
              if (this.Hero_ID[index] != 0U)
              {
                CurHeroData curHeroData = this.DM.curHeroData[this.Hero_ID[index]];
                this.DM.pLeftLeaderData[index].HeroID = curHeroData.ID;
                this.DM.pLeftLeaderData[index].Rank = curHeroData.Enhance;
                this.DM.pLeftLeaderData[index].Star = curHeroData.Star;
                ++this.DM.War_LeftHeroNum;
              }
            }
            ushort[] battleHeroID = new ushort[10];
            for (int index = 0; index < 5; ++index)
              battleHeroID[index] = this.DM.pLeftLeaderData[index].HeroID;
            if (!WarManager.CheckVersion())
            {
              this.GUIM.HideUILock(EUILock.Expedition);
              return;
            }
            if (!this.DM.CheckHeroBattleResourceReady(HeroFightType.LegionBatte, battleHeroID))
            {
              this.GUIM.HideUILock(EUILock.Expedition);
              GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(8350U), (ushort) byte.MaxValue);
              return;
            }
            for (int index5 = 0; index5 < 16; ++index5)
            {
              int index6 = (3 - index5 % 4) * 4 + index5 / 4;
              this.DM.pLeftTroopForce[index5 / 4, index5 % 4] = (uint) this.m_Soldier[index6];
            }
            this.DM.War_LeftCastleLv = GUIManager.Instance.BuildingData.GetBuildData((ushort) 12, (ushort) 0).Level;
          }
          messagePacket.AddSeqId();
          for (int index = 0; index < 5; ++index)
            messagePacket.Add((ushort) this.Hero_ID[index]);
          for (int index7 = 0; index7 < 16; ++index7)
          {
            int index8 = (3 - index7 % 4) * 4 + index7 / 4;
            messagePacket.Add((uint) this.m_Soldier[index8]);
          }
          if (this.mOpenKind == 0)
          {
            Vector2 pointCode = GameConstants.MapPosToPointCode(GameConstants.getTileMapPosbySpriteID(this.MapID));
            messagePacket.Add((ushort) pointCode.x);
            messagePacket.Add((byte) pointCode.y);
          }
        }
        else if (this.mOpenKind == 2)
        {
          this.DM.bWonderFight = this.MapID >= 2 || this.MapID <= 4;
          messagePacket.Protocol = Protocol._MSG_REQUEST_SEND_INFORCE;
          messagePacket.AddSeqId();
          messagePacket.Add(this.ZoneID);
          messagePacket.Add(this.PointID);
          for (int index9 = 0; index9 < 16; ++index9)
          {
            int index10 = (3 - index9 % 4) * 4 + index9 / 4;
            messagePacket.Add((uint) this.m_Soldier[index10]);
          }
        }
        messagePacket.Send();
      }
      else if (this.mOpenKind == 4)
      {
        uint[] _TroopData = new uint[16];
        for (int index11 = 0; index11 < 16; ++index11)
        {
          int index12 = (3 - index11 % 4) * 4 + index11 / 4;
          _TroopData[index11] = (uint) this.m_Soldier[index12];
        }
        byte HideLord = 0;
        if (this.bCaveMainHero)
          HideLord = (byte) 1;
        HideArmyManager.Instance.SendHideTroopInshelter(HideLord, this.DM.RallyCountDownIndex, ref _TroopData);
      }
      else if (this.mOpenKind == 5)
      {
        ushort[] Leader = new ushort[5];
        uint[] TroopData = new uint[16];
        for (int index = 0; index < 5; ++index)
          Leader[index] = (ushort) this.Hero_ID[index];
        for (int index13 = 0; index13 < 16; ++index13)
        {
          int index14 = (3 - index13 % 4) * 4 + index13 / 4;
          TroopData[index13] = (uint) this.m_Soldier[index14];
        }
        AmbushManager.Instance.SendAmbush(Leader, TroopData);
      }
      else if (this.mOpenKind == 7 || this.mOpenKind == 8)
      {
        ushort[] LeaderID = new ushort[5];
        uint[] TroopData = new uint[16];
        for (int index = 0; index < 5; ++index)
          LeaderID[index] = (ushort) this.Hero_ID[index];
        for (int index15 = 0; index15 < 16; ++index15)
        {
          int index16 = (3 - index15 % 4) * 4 + index15 / 4;
          TroopData[index15] = (uint) this.m_Soldier[index16];
        }
        this.DM.SendWonderHost(LeaderID, TroopData, this.mWonderId);
      }
      else if (this.mOpenKind == 10)
      {
        this.GUIM.ShowUILock(EUILock.Expedition);
        this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_Expedition);
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_SIGNUP_ALLIANCEWAR;
        messagePacket.AddSeqId();
        for (int index = 0; index < this.Hero_ID.Length; ++index)
          messagePacket.Add((ushort) this.Hero_ID[index]);
        for (int index17 = 0; index17 < 16; ++index17)
        {
          int index18 = (3 - index17 % 4) * 4 + index17 / 4;
          messagePacket.Add((uint) this.m_Soldier[index18]);
        }
        messagePacket.Send();
      }
      if (this.mOpenKind == 1)
        return;
      this.DM.LegionBattleHero.Clear();
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (sender.Parm1 == (ushort) 1)
    {
      this.Cstr_HintNum.ClearString();
      this.Cstr_HintNum.IntToFormat(this.m_NeedWarlobbySoldier[(int) sender.Parm2], bNumber: true);
      this.Cstr_HintNum.IntToFormat(this.m_NeedWarlobbySoldier[(int) sender.Parm2] - (long) this.m_SoldierMax[(int) sender.Parm2].Value[0], bNumber: true);
      this.Cstr_HintNum.AppendFormat(this.DM.mStringTable.GetStringByID(14724U));
      GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.Cstr_HintNum, Vector2.zero);
    }
    else
    {
      switch ((sender.m_Button as UIButton).m_BtnID1)
      {
        case 14:
          if (((UIBehaviour) this.Img_HintBG[0]).IsActive())
            break;
          ((Component) this.Img_HintBG[0]).gameObject.SetActive(true);
          break;
        case 15:
          if (((UIBehaviour) this.Img_HintBG[1]).IsActive())
            break;
          ((Component) this.Img_HintBG[1]).gameObject.SetActive(true);
          break;
        case 16:
          if (((UIBehaviour) this.Img_HintBG[2]).IsActive())
            break;
          ((Component) this.Img_HintBG[2]).gameObject.SetActive(true);
          break;
      }
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if (sender.Parm1 == (ushort) 1)
    {
      GUIManager.Instance.m_Hint.Hide(true);
    }
    else
    {
      switch ((sender.m_Button as UIButton).m_BtnID1)
      {
        case 14:
          if (!((UIBehaviour) this.Img_HintBG[0]).IsActive())
            break;
          ((Component) this.Img_HintBG[0]).gameObject.SetActive(false);
          break;
        case 15:
          if (!((UIBehaviour) this.Img_HintBG[1]).IsActive())
            break;
          ((Component) this.Img_HintBG[1]).gameObject.SetActive(false);
          break;
        case 16:
          if (!((UIBehaviour) this.Img_HintBG[2]).IsActive())
            break;
          ((Component) this.Img_HintBG[2]).gameObject.SetActive(false);
          break;
      }
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    switch (panelId)
    {
      case 1:
        if (this.ShowListIndex[dataIdx] > (byte) 0)
          this.tmpListIdx = (int) this.ShowListIndex[dataIdx] - 1;
        if ((UnityEngine.Object) this.m_UnitRS_Item[panelObjectIdx] == (UnityEngine.Object) null)
        {
          this.m_UnitRS_Item[panelObjectIdx] = item.transform.GetChild(1).GetComponent<UnitResourcesSlider>();
          this.m_UnitRS_Item[panelObjectIdx].m_Handler = (IUIUnitRSliderHandler) this;
          this.m_UnitRS_Item[panelObjectIdx].m_ID = this.tmpListIdx;
          this.m_UnitRS_Item[panelObjectIdx].MaxValue = (long) this.m_SoldierMax[this.tmpListIdx].Value[0];
          this.m_UnitRS_Item[panelObjectIdx].Value = this.m_Soldier[this.tmpListIdx];
          this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = (double) this.m_SoldierMax[this.tmpListIdx].Value[0];
          this.m_UnitRS_Item[panelObjectIdx].m_slider.value = (double) this.m_Soldier[this.tmpListIdx];
          this.btn_ItemInput[panelObjectIdx] = this.m_UnitRS_Item[panelObjectIdx].BtnInputText;
          this.btn_ItemInput[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
          this.btn_ItemInput[panelObjectIdx].m_BtnID2 = panelObjectIdx;
          if (this.m_SoldierMax[this.tmpListIdx].Value[0] >= this.Hero_Total)
          {
            this.m_UnitRS_Item[panelObjectIdx].MaxValue = (long) this.Hero_Total;
            this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = (double) this.Hero_Total;
          }
          this.m_UnitRS_Item[panelObjectIdx].Type = (byte) panelObjectIdx;
          this.Tmp = item.transform.GetChild(2).GetChild(0);
          this.Img_Soldier_Item[panelObjectIdx] = this.Tmp.GetComponent<Image>();
          this.Tmp = item.transform.GetChild(2).GetChild(1);
          this.Img_Soldier_ItemFrame[panelObjectIdx] = this.Tmp.GetComponent<Image>();
          ((MaskableGraphic) this.Img_Soldier_ItemFrame[panelObjectIdx]).material = this.FrameMaterial;
          this.Tmp = item.transform.GetChild(3).GetChild(0);
          this.Img_Soldier_Kind[panelObjectIdx] = this.Tmp.GetComponent<Image>();
          ((MaskableGraphic) this.Img_Soldier_Kind[panelObjectIdx]).material = this.m_BW;
          this.Tmp = item.transform.GetChild(4);
          this.Text_Soldier_ItemNum[panelObjectIdx] = this.Tmp.GetComponent<UIText>();
          this.Text_Soldier_ItemNum[panelObjectIdx].font = this.TTFont;
          this.Tmp = item.transform.GetChild(3).GetChild(1);
          this.Text_Soldier_ItemName[panelObjectIdx] = this.Tmp.GetComponent<UIText>();
          this.Text_Soldier_ItemName[panelObjectIdx].font = this.TTFont;
        }
        else
        {
          this.m_UnitRS_Item[panelObjectIdx].m_ID = this.tmpListIdx;
          this.m_UnitRS_Item[panelObjectIdx].MaxValue = (long) this.m_SoldierMax[this.tmpListIdx].Value[0];
          this.m_UnitRS_Item[panelObjectIdx].Value = this.m_Soldier[this.tmpListIdx];
          if ((double) this.m_SoldierMax[this.tmpListIdx].Value[0] < this.m_UnitRS_Item[panelObjectIdx].m_slider.value)
          {
            this.m_UnitRS_Item[panelObjectIdx].m_slider.value = (double) this.m_Soldier[this.tmpListIdx];
            this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = (double) this.m_SoldierMax[this.tmpListIdx].Value[0];
          }
          else
          {
            this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = (double) this.m_SoldierMax[this.tmpListIdx].Value[0];
            this.m_UnitRS_Item[panelObjectIdx].m_slider.value = (double) this.m_Soldier[this.tmpListIdx];
          }
          if (this.m_SoldierMax[this.tmpListIdx].Value[0] >= this.Hero_Total)
          {
            this.m_UnitRS_Item[panelObjectIdx].MaxValue = (long) this.Hero_Total;
            this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = (double) this.Hero_Total;
          }
          this.m_UnitRS_Item[panelObjectIdx].Type = (byte) panelObjectIdx;
        }
        this.Img_Soldier_Item[panelObjectIdx].sprite = this.m_SoldierSprite[this.tmpListIdx];
        this.Img_Soldier_ItemFrame[panelObjectIdx].sprite = this.m_SoldierSpriteFrame[this.tmpListIdx];
        this.Img_Soldier_Kind[panelObjectIdx].sprite = this.SArray.m_Sprites[6 + this.tmpListIdx % 4];
        if (this.m_Soldier[this.tmpListIdx] != 0L)
          ((Graphic) this.m_UnitRS_Item[panelObjectIdx].m_inputText).color = this.mtextColor;
        else
          ((Graphic) this.m_UnitRS_Item[panelObjectIdx].m_inputText).color = Color.white;
        this.Cstr_Soldier_ItemNum[panelObjectIdx].ClearString();
        this.Cstr_Soldier_ItemNum[panelObjectIdx].IntToFormat((long) this.m_SoldierMax[this.tmpListIdx].Value[0] - this.m_Soldier[this.tmpListIdx], bNumber: true);
        this.Cstr_Soldier_ItemNum[panelObjectIdx].AppendFormat("{0}");
        this.Text_Soldier_ItemNum[panelObjectIdx].text = this.Cstr_Soldier_ItemNum[panelObjectIdx].ToString();
        this.Text_Soldier_ItemNum[panelObjectIdx].SetAllDirty();
        this.Text_Soldier_ItemNum[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.Text_Soldier_ItemName[panelObjectIdx].text = this.m_SoldierName[this.tmpListIdx];
        this.Cstr_Soldier_Text[panelObjectIdx].ClearString();
        this.Cstr_Soldier_Text[panelObjectIdx].IntToFormat(this.m_Soldier[this.tmpListIdx], bNumber: true);
        this.Cstr_Soldier_Text[panelObjectIdx].AppendFormat("{0}");
        this.m_UnitRS_Item[panelObjectIdx].m_inputText.text = this.Cstr_Soldier_Text[panelObjectIdx].ToString();
        this.m_UnitRS_Item[panelObjectIdx].m_inputText.SetAllDirty();
        this.m_UnitRS_Item[panelObjectIdx].m_inputText.cachedTextGenerator.Invalidate();
        break;
      case 2:
        if (!this.InitSoldierInfoItem[panelObjectIdx])
        {
          this.InitSoldierInfoItem[panelObjectIdx] = true;
          this.m_Warlobby_Item[panelObjectIdx].T1 = item.transform.GetChild(0);
          for (int index = 0; index < 5; ++index)
            this.m_Warlobby_Item[panelObjectIdx].text_T1[index] = this.m_Warlobby_Item[panelObjectIdx].T1.GetChild(1 + index).GetComponent<UIText>();
          this.m_Warlobby_Item[panelObjectIdx].T2 = item.transform.GetChild(1);
          this.m_Warlobby_Item[panelObjectIdx].text_T2 = this.m_Warlobby_Item[panelObjectIdx].T2.GetChild(1).GetComponent<UIText>();
          this.m_Warlobby_Item[panelObjectIdx].SolderT = item.transform.GetChild(2);
          this.m_Warlobby_Item[panelObjectIdx].SolderIcon = this.m_Warlobby_Item[panelObjectIdx].SolderT.GetChild(0).GetComponent<Image>();
          for (int index = 0; index < 3; ++index)
            this.m_Warlobby_Item[panelObjectIdx].text_SolderT[index] = this.m_Warlobby_Item[panelObjectIdx].SolderT.GetChild(0).GetChild(index).GetComponent<UIText>();
          this.m_Warlobby_Item[panelObjectIdx].SolderIconEX = this.m_Warlobby_Item[panelObjectIdx].SolderT.GetChild(1).GetComponent<Image>();
          this.m_Warlobby_Item[panelObjectIdx].mWarlobbybtnHint = ((Component) this.m_Warlobby_Item[panelObjectIdx].SolderIconEX).gameObject.AddComponent<UIButtonHint>();
          this.m_Warlobby_Item[panelObjectIdx].mWarlobbybtnHint.m_eHint = EUIButtonHint.DownUpHandler;
          this.m_Warlobby_Item[panelObjectIdx].mWarlobbybtnHint.m_Handler = (MonoBehaviour) this;
          this.m_Warlobby_Item[panelObjectIdx].mWarlobbybtnHint.Parm1 = (ushort) 1;
          this.m_Warlobby_Item[panelObjectIdx].text_SolderT[3] = this.m_Warlobby_Item[panelObjectIdx].SolderT.GetChild(2).GetComponent<UIText>();
        }
        switch (dataIdx)
        {
          case 0:
            this.m_Warlobby_Item[panelObjectIdx].T1.gameObject.SetActive(true);
            this.m_Warlobby_Item[panelObjectIdx].T2.gameObject.SetActive(false);
            this.m_Warlobby_Item[panelObjectIdx].SolderT.gameObject.SetActive(false);
            if (this.mWarlobbyKind == (byte) 2)
            {
              ((Component) this.m_Warlobby_Item[panelObjectIdx].text_T1[2]).gameObject.SetActive(false);
              ((Component) this.m_Warlobby_Item[panelObjectIdx].text_T1[4]).gameObject.SetActive(false);
            }
            else
            {
              ((Component) this.m_Warlobby_Item[panelObjectIdx].text_T1[2]).gameObject.SetActive(true);
              ((Component) this.m_Warlobby_Item[panelObjectIdx].text_T1[4]).gameObject.SetActive(true);
            }
            if (this.bScrollItemH)
            {
              ((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[1]).rectTransform.sizeDelta = new Vector2(((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[1]).rectTransform.sizeDelta.x, 56f);
              ((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[3]).rectTransform.anchoredPosition = new Vector2(-58f, -58f);
              ((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[2]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[2]).rectTransform.anchoredPosition.x, -112f);
            }
            else
            {
              ((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[1]).rectTransform.sizeDelta = new Vector2(((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[1]).rectTransform.sizeDelta.x, 28f);
              ((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[3]).rectTransform.anchoredPosition = new Vector2(-58f, -44f);
              ((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[2]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[2]).rectTransform.anchoredPosition.x, -84f);
            }
            if (this.bScrollItemH1 && this.mWarlobbyKind == (byte) 0 || this.bScrollItemH2 && this.mWarlobbyKind == (byte) 1)
            {
              ((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[2]).rectTransform.sizeDelta = new Vector2(((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[2]).rectTransform.sizeDelta.x, 56f);
              if (this.bScrollItemH)
                ((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[4]).rectTransform.anchoredPosition = new Vector2(-58f, -126f);
              else
                ((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[4]).rectTransform.anchoredPosition = new Vector2(-58f, -98f);
            }
            else
            {
              ((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[2]).rectTransform.sizeDelta = new Vector2(((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[2]).rectTransform.sizeDelta.x, 28f);
              if (this.bScrollItemH)
                ((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[4]).rectTransform.anchoredPosition = new Vector2(-58f, -112f);
              else
                ((Graphic) this.m_Warlobby_Item[panelObjectIdx].text_T1[4]).rectTransform.anchoredPosition = new Vector2(-58f, -84f);
            }
            this.Cstr_WarlobbySolder.ClearString();
            this.Cstr_WarlobbySolder.IntToFormat(this.WarlobbySelectQty, bNumber: true);
            this.Cstr_WarlobbySolder.IntToFormat(this.WarlobbyTroopMax, bNumber: true);
            if (this.WarlobbySelectQty < this.WarlobbyTroopMax)
            {
              if (this.GUIM.IsArabic)
                this.Cstr_WarlobbySolder.AppendFormat("{1} / <color=#ff0000ff>{0}</color>");
              else
                this.Cstr_WarlobbySolder.AppendFormat("<color=#ff0000ff>{0}</color> / {1}");
            }
            else if (this.GUIM.IsArabic)
              this.Cstr_WarlobbySolder.AppendFormat("{1} / {0}");
            else
              this.Cstr_WarlobbySolder.AppendFormat("{0} / {1}");
            this.m_Warlobby_Item[panelObjectIdx].text_T1[3].text = this.Cstr_WarlobbySolder.ToString();
            this.m_Warlobby_Item[panelObjectIdx].text_T1[3].SetAllDirty();
            this.m_Warlobby_Item[panelObjectIdx].text_T1[3].cachedTextGenerator.Invalidate();
            this.m_Warlobby_Item[panelObjectIdx].text_T1[4].text = this.Cstr_LoadNum[0].ToString();
            this.m_Warlobby_Item[panelObjectIdx].text_T1[4].SetAllDirty();
            this.m_Warlobby_Item[panelObjectIdx].text_T1[4].cachedTextGenerator.Invalidate();
            this.m_Warlobby_Item[panelObjectIdx].text_T1[2].text = this.Cstr_WarlobbyKindText.ToString();
            this.m_Warlobby_Item[panelObjectIdx].text_T1[2].SetAllDirty();
            this.m_Warlobby_Item[panelObjectIdx].text_T1[2].cachedTextGenerator.Invalidate();
            this.m_Warlobby_Item[panelObjectIdx].text_T1[2].cachedTextGeneratorForLayout.Invalidate();
            return;
          case 1:
            this.m_Warlobby_Item[panelObjectIdx].T1.gameObject.SetActive(false);
            this.m_Warlobby_Item[panelObjectIdx].T2.gameObject.SetActive(true);
            this.m_Warlobby_Item[panelObjectIdx].SolderT.gameObject.SetActive(false);
            return;
          default:
            this.m_Warlobby_Item[panelObjectIdx].T1.gameObject.SetActive(false);
            this.m_Warlobby_Item[panelObjectIdx].T2.gameObject.SetActive(false);
            this.m_Warlobby_Item[panelObjectIdx].SolderT.gameObject.SetActive(true);
            if (dataIdx <= 1)
              return;
            this.mSrcollDataIdx = this.mShowSolderIdx[dataIdx - 2];
            this.m_Warlobby_Item[panelObjectIdx].SolderIcon.sprite = this.mWarlobbyIcon[(int) this.mSrcollDataIdx % 4];
            this.m_Warlobby_Item[panelObjectIdx].text_SolderT[0].text = (4 - (int) this.mSrcollDataIdx / 4).ToString();
            this.m_Warlobby_Item[panelObjectIdx].text_SolderT[1].text = this.m_SoldierName[(int) this.mSrcollDataIdx];
            this.Cstr_WarSoldier_Text[panelObjectIdx].ClearString();
            StringManager.IntToStr(this.Cstr_WarSoldier_Text[panelObjectIdx], this.m_WarlobbySoldier[(int) this.mSrcollDataIdx], bNumber: true);
            this.m_Warlobby_Item[panelObjectIdx].text_SolderT[2].text = this.Cstr_WarSoldier_Text[panelObjectIdx].ToString();
            this.m_Warlobby_Item[panelObjectIdx].text_SolderT[2].SetAllDirty();
            this.m_Warlobby_Item[panelObjectIdx].text_SolderT[2].cachedTextGenerator.Invalidate();
            this.Cstr_WarSoldierRate_Text[panelObjectIdx].ClearString();
            if (this.WarlobbySelectQty > 0L)
              this.Cstr_WarSoldierRate_Text[panelObjectIdx].DoubleToFormat((double) this.m_WarlobbySoldier[(int) this.mSrcollDataIdx] * 100.0 / (double) this.WarlobbySelectQty, 1);
            else
              this.Cstr_WarSoldierRate_Text[panelObjectIdx].DoubleToFormat(0.0, 1);
            if (this.GUIM.IsArabic)
              this.Cstr_WarSoldierRate_Text[panelObjectIdx].AppendFormat("%{0}");
            else
              this.Cstr_WarSoldierRate_Text[panelObjectIdx].AppendFormat("{0}%");
            this.m_Warlobby_Item[panelObjectIdx].text_SolderT[3].text = this.Cstr_WarSoldierRate_Text[panelObjectIdx].ToString();
            this.m_Warlobby_Item[panelObjectIdx].text_SolderT[3].SetAllDirty();
            this.m_Warlobby_Item[panelObjectIdx].text_SolderT[3].cachedTextGenerator.Invalidate();
            this.m_Warlobby_Item[panelObjectIdx].mWarlobbybtnHint.Parm2 = this.mSrcollDataIdx;
            if ((long) this.m_SoldierMax[(int) this.mSrcollDataIdx].Value[0] < this.m_NeedWarlobbySoldier[(int) this.mSrcollDataIdx])
            {
              ((Component) this.m_Warlobby_Item[panelObjectIdx].SolderIconEX).gameObject.SetActive(true);
              return;
            }
            ((Component) this.m_Warlobby_Item[panelObjectIdx].SolderIconEX).gameObject.SetActive(false);
            return;
        }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
  {
    URS.m_slider.value = (double) mValue;
    URS.SliderValueChange();
  }

  public override bool OnBackButtonClick()
  {
    if (this.mOpenKind == 1 && (this.GUIM.GetUILock() == EUILock.Expedition || (double) this.fightButtonTime > 0.0))
      return true;
    if (this.mOpenKind == 4)
      HideArmyManager.Instance.OpenHideArmyUI();
    if (this.mOpenKind == 6)
    {
      if (this.DM.bChangHero)
      {
        if (this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[0] != (ushort) 0)
        {
          byte num = 0;
          for (int index = 0; index < 5; ++index)
          {
            if (this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index] != (ushort) 0)
              ++num;
          }
          if (this.DM.LegionBattleHero.Count != (int) num)
          {
            GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5893U), this.DM.mStringTable.GetStringByID(997U), 3, YesText: this.DM.mStringTable.GetStringByID(3U), NoText: this.DM.mStringTable.GetStringByID(4U));
            return true;
          }
          for (int index = 0; index < 5 && index < this.DM.LegionBattleHero.Count; ++index)
          {
            if ((int) this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index] != (int) this.DM.LegionBattleHero[index])
            {
              GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5893U), this.DM.mStringTable.GetStringByID(997U), 3, YesText: this.DM.mStringTable.GetStringByID(3U), NoText: this.DM.mStringTable.GetStringByID(4U));
              return true;
            }
          }
        }
        else if (this.DM.LegionBattleHero.Count > 0)
        {
          GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5893U), this.DM.mStringTable.GetStringByID(997U), 3, YesText: this.DM.mStringTable.GetStringByID(3U), NoText: this.DM.mStringTable.GetStringByID(4U));
          return true;
        }
      }
      if (this.DM.bChangSoldier)
      {
        for (int index = 0; index < 16; ++index)
        {
          if ((long) this.DM.mTroopMemoryData[(int) this.TMD_Idx].TroopData[index] != this.m_Soldier[index])
          {
            GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5893U), this.DM.mStringTable.GetStringByID(997U), 3, YesText: this.DM.mStringTable.GetStringByID(3U), NoText: this.DM.mStringTable.GetStringByID(4U));
            return true;
          }
        }
      }
      if (this.DM.bChangName && string.Compare(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Label, 0, this.TMD_Name, 0, this.DM.mTroopMemoryData[(int) this.TMD_Idx].Label.Length) != 0)
      {
        GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5893U), this.DM.mStringTable.GetStringByID(997U), 3, YesText: this.DM.mStringTable.GetStringByID(3U), NoText: this.DM.mStringTable.GetStringByID(4U));
        return true;
      }
      this.DM.TeamName.ClearString();
      this.DM.LegionBattleHero.Clear();
      for (int index = 0; index < 16; ++index)
        this.DM.mExpeditionSoldierList[index] = 0U;
      this.DM.bChangHero = false;
      this.DM.bChangName = false;
      this.DM.bChangSoldier = false;
    }
    else
    {
      this.DM.LegionBattleHero.Clear();
      for (int index = 0; index < 16; ++index)
        this.DM.mExpeditionSoldierList[index] = 0U;
    }
    if (this.mWarlobbyKind >= (byte) 0 && this.mWarlobbyKind <= (byte) 2)
      this.mUI_WarlobbyK = byte.MaxValue;
    return false;
  }

  public void UpDataSoldier()
  {
    this.SoldierMax = 0L;
    int index1 = 0;
    this.tmplist.Clear();
    for (int index2 = 0; index2 < 16; ++index2)
    {
      if (!this.bLogin)
        this.m_Soldier[index2] = 0L;
      this.m_SoldierMax[index2].Value = new uint[5];
      ushort InKey = (ushort) (4 - index2 / 4 + index2 % 4 * 4);
      if (this.DM.bSetExpediton)
        this.m_Soldier[index2] = this.DM.RoleAttr.m_Soldier[(int) InKey - 1] >= this.DM.mExpeditionSoldierList[index2] || this.mOpenKind == 6 ? (long) this.DM.mExpeditionSoldierList[index2] : (long) this.DM.RoleAttr.m_Soldier[(int) InKey - 1];
      this.m_SoldierMax[index2].Value[0] = this.DM.RoleAttr.m_Soldier[(int) InKey - 1];
      if (this.mOpenKind == 6)
      {
        for (int index3 = 0; index3 < this.DM.MarchEventData.Length; ++index3)
        {
          if (this.DM.MarchEventData[index3].Type != EMarchEventType.EMET_Standby)
            this.m_SoldierMax[index2].Value[0] += this.DM.MarchEventData[index3].TroopData[((int) InKey - 1) / 4][((int) InKey - 1) % 4];
        }
        if (this.m_Soldier[index2] > (long) this.m_SoldierMax[index2].Value[0])
          this.m_Soldier[index2] = (long) this.m_SoldierMax[index2].Value[0];
      }
      this.m_SoldierMax[index2].Value[1] = 0U;
      this.m_SoldierMax[index2].Value[2] = 0U;
      this.m_SoldierMax[index2].Value[3] = 0U;
      this.m_SoldierMax[index2].Value[4] = 0U;
      this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey(InKey);
      this.tmpString.Length = 0;
      this.m_SoldierSprite[index2] = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpSD.Icon);
      this.tmpString.Length = 0;
      this.tmpString.AppendFormat("hf00{0}", (object) this.tmpSD.Tier);
      this.m_SoldierSpriteFrame[index2] = this.GUIM.LoadFrameSprite(this.tmpString.ToString());
      this.m_SoldierName[index2] = this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name);
      this.m_SoldierData[index2].Speed = this.tmpSD.Speed;
      this.m_SoldierData[index2].Traffic = this.tmpSD.Traffic;
      this.SpeedsortData[index2] = (byte) index2;
      this.LoadsortData[index2] = (byte) index2;
      this.SoldierMax += (long) this.m_SoldierMax[index2].Value[0];
      if (this.m_SoldierMax[index2].Value[0] > 0U)
      {
        this.ShowListIndex[index1] = (byte) (index2 + 1);
        this.tmplist.Add(98f);
        ++index1;
      }
    }
  }

  public void ClearSoldier()
  {
    for (int index = 0; index < 16; ++index)
      this.m_Soldier[index] = 0L;
    for (int index = 0; index < 7; ++index)
    {
      if ((UnityEngine.Object) this.m_UnitRS_Item[index] != (UnityEngine.Object) null)
      {
        long x = this.m_Soldier[this.m_UnitRS_Item[index].m_ID];
        this.m_UnitRS_Item[index].MaxValue = (long) this.m_SoldierMax[this.m_UnitRS_Item[index].m_ID].Value[0];
        this.m_UnitRS_Item[index].Value = x;
        this.m_UnitRS_Item[index].m_slider.maxValue = (double) this.m_SoldierMax[this.m_UnitRS_Item[index].m_ID].Value[0];
        if (this.m_SoldierMax[this.m_UnitRS_Item[index].m_ID].Value[0] >= this.Hero_Total)
        {
          this.m_UnitRS_Item[index].MaxValue = (long) this.Hero_Total;
          this.m_UnitRS_Item[index].m_slider.maxValue = (double) this.Hero_Total;
        }
        this.m_UnitRS_Item[index].m_slider.value = (double) x;
        this.Cstr_Soldier_Text[index].ClearString();
        this.Cstr_Soldier_Text[index].IntToFormat(x, bNumber: true);
        this.Cstr_Soldier_Text[index].AppendFormat("{0}");
        this.m_UnitRS_Item[index].m_inputText.text = this.Cstr_Soldier_Text[index].ToString();
        this.m_UnitRS_Item[index].m_inputText.SetAllDirty();
        this.m_UnitRS_Item[index].m_inputText.cachedTextGenerator.Invalidate();
        ((Graphic) this.Text_Soldier_ItemNum[index]).color = Color.white;
        this.Cstr_Soldier_ItemNum[index].ClearString();
        this.Cstr_Soldier_ItemNum[index].IntToFormat((long) this.m_SoldierMax[this.m_UnitRS_Item[index].m_ID].Value[0] - x, bNumber: true);
        this.Cstr_Soldier_ItemNum[index].AppendFormat("{0}");
        this.Text_Soldier_ItemNum[index].text = this.Cstr_Soldier_ItemNum[index].ToString();
        this.Text_Soldier_ItemNum[index].SetAllDirty();
        this.Text_Soldier_ItemNum[index].cachedTextGenerator.Invalidate();
      }
    }
    this.SetDRformURS(0);
  }

  public void CheckMaxSelect()
  {
    uint num1 = this.Hero_Total;
    uint num2 = this.mResourcesKind != 1 ? this.ResourcesMax : this.ResourcesMax * 1000U;
    float num3 = (float) Math.Ceiling((double) num2 * (10000.0 / (double) this.tmpLoad));
    for (int index = 0; index < 16; ++index)
    {
      if ((double) (this.m_SoldierMax[index].Value[0] * (uint) this.m_SoldierData[index].Traffic) < (double) num3)
      {
        num1 -= this.m_SoldierMax[index].Value[0];
        this.m_SoldierMax[index].Value[1] = this.m_SoldierMax[index].Value[0];
        num3 -= (float) (this.m_SoldierMax[index].Value[0] * (uint) this.m_SoldierData[index].Traffic);
      }
      else
      {
        this.m_SoldierMax[index].Value[1] = GameConstants.appCeil(num3 / (float) this.m_SoldierData[index].Traffic);
        if (this.m_SoldierMax[index].Value[1] <= num1)
        {
          num1 -= this.m_SoldierMax[index].Value[1];
        }
        else
        {
          this.m_SoldierMax[index].Value[1] = num1;
          num1 = 0U;
        }
        num3 = 0.0f;
      }
      if ((double) num3 == 0.0 || num1 == 0U)
        break;
    }
    uint num4 = this.Hero_Total;
    float num5 = (float) Math.Ceiling((double) num2 * (10000.0 / (double) this.tmpLoad));
    for (int index1 = 0; index1 < 16; ++index1)
    {
      int index2 = (3 - index1 / 4) * 4 + index1 % 4;
      if ((double) (this.m_SoldierMax[index2].Value[0] * (uint) this.m_SoldierData[index2].Traffic) < (double) num5)
      {
        if (this.m_SoldierMax[index2].Value[0] <= num4)
        {
          num4 -= this.m_SoldierMax[index2].Value[0];
          this.m_SoldierMax[index2].Value[2] = this.m_SoldierMax[index2].Value[0];
          num5 -= (float) (this.m_SoldierMax[index2].Value[0] * (uint) this.m_SoldierData[index2].Traffic);
        }
        else
        {
          this.m_SoldierMax[index2].Value[2] = num4;
          num4 = 0U;
        }
      }
      else
      {
        this.m_SoldierMax[index2].Value[2] = GameConstants.appCeil(num5 / (float) this.m_SoldierData[index2].Traffic);
        if (this.m_SoldierMax[index2].Value[2] <= num4)
        {
          num4 -= this.m_SoldierMax[index2].Value[2];
        }
        else
        {
          this.m_SoldierMax[index2].Value[2] = num4;
          num4 = 0U;
        }
        num5 = 0.0f;
      }
      if ((double) num5 == 0.0 || num4 == 0U)
        break;
    }
  }

  public void SelectFormation()
  {
    uint num1 = this.Hero_Total;
    if ((long) num1 > this.SoldierMax)
    {
      for (int index = 0; index < 16; ++index)
      {
        this.m_SoldierMax[index].Value[3] = this.m_SoldierMax[index].Value[0];
        this.m_SoldierMax[index].Value[4] = this.m_SoldierMax[index].Value[0];
      }
    }
    else
    {
      for (int index = 0; index < 16; ++index)
      {
        uint num2;
        if (num1 > this.m_SoldierMax[index].Value[0])
        {
          num1 -= this.m_SoldierMax[index].Value[0];
          num2 = this.m_SoldierMax[index].Value[0];
        }
        else
        {
          num2 = num1;
          num1 = 0U;
        }
        this.m_SoldierMax[index].Value[3] = num2;
        if (num1 == 0U)
          break;
      }
      uint num3 = this.Hero_Total;
      for (int index1 = 0; index1 < 16; ++index1)
      {
        int index2 = (3 - index1 / 4) * 4 + index1 % 4;
        uint num4;
        if (num3 > this.m_SoldierMax[index2].Value[0])
        {
          num3 -= this.m_SoldierMax[index2].Value[0];
          num4 = this.m_SoldierMax[index2].Value[0];
        }
        else
        {
          num4 = num3;
          num3 = 0U;
        }
        this.m_SoldierMax[index2].Value[4] = num4;
        if (num3 == 0U)
          break;
      }
    }
  }

  public void Set_W_SelectText(byte Kind = 255, bool bClear = false)
  {
    if (Kind != byte.MaxValue)
    {
      this.mUI_WarlobbyK = Kind;
      if (Kind > (byte) 0)
      {
        this.Text_W_Select[0].text = this.mbtnFormation[1];
        ((Component) this.Img_W_SelectIcon).gameObject.SetActive(!bClear);
        ((Component) this.Text_W_Select[1]).gameObject.SetActive(!bClear);
        ((Component) this.Text_W_Select[0]).gameObject.SetActive(bClear);
        if (!bClear)
        {
          switch (Kind)
          {
            case 1:
              this.Text_W_Select[1].text = this.DM.mStringTable.GetStringByID(14713U);
              break;
            case 2:
              this.Text_W_Select[1].text = this.DM.mStringTable.GetStringByID(14714U);
              break;
          }
        }
      }
      else
      {
        ((Component) this.Img_W_SelectIcon).gameObject.SetActive(false);
        ((Component) this.Text_W_Select[1]).gameObject.SetActive(false);
        ((Component) this.Text_W_Select[0]).gameObject.SetActive(true);
        this.Text_W_Select[0].text = bClear ? this.mbtnFormation[1] : this.mbtnFormation[0];
      }
    }
    this.Text_W_Select[0].SetAllDirty();
    this.Text_W_Select[0].cachedTextGenerator.Invalidate();
    this.Text_W_Select[1].SetAllDirty();
    this.Text_W_Select[1].cachedTextGenerator.Invalidate();
  }

  public void SetWarlobbyMenu(bool bopen, byte type = 0)
  {
    if (!bopen)
    {
      if (((Component) this.Img_W_MenuSelect).gameObject.activeSelf)
        ((Component) this.Img_W_MenuSelect).gameObject.SetActive(bopen);
      else if (((Component) this.Img_W_Menu).gameObject.activeSelf)
        ((Component) this.Img_W_Menu).gameObject.SetActive(bopen);
    }
    else
    {
      ((Component) this.Img_W_MenuSelect).gameObject.SetActive(bopen && type == (byte) 0);
      ((Component) this.Img_W_Menu).gameObject.SetActive(bopen && type == (byte) 1);
    }
    ((Behaviour) this.btn_W_MenuBack).enabled = ((Component) this.Img_W_MenuSelect).gameObject.activeSelf;
    if (this.bAllZero)
    {
      this.btn_W_MenuSet.ForTextChange(e_BtnType.e_ChangeText);
      ((Graphic) this.btn_W_MenuSet.image).color = Color.gray;
    }
    else
    {
      this.btn_W_MenuSet.ForTextChange(e_BtnType.e_Normal);
      ((Graphic) this.btn_W_MenuSet.image).color = Color.white;
    }
    ((Component) this.btn_W_MenuBack).gameObject.SetActive(bopen);
  }

  public void CheckScrollH()
  {
    this.Cstr_WarlobbyKindText.ClearString();
    if (this.mWarlobbyKind == (byte) 0)
      this.Cstr_WarlobbyKindText.Append(this.DM.mStringTable.GetStringByID(14720U));
    else if (this.mWarlobbyKind == (byte) 1)
      this.Cstr_WarlobbyKindText.Append(this.DM.mStringTable.GetStringByID(14721U));
    float num = (float) (0.0 + (!this.bScrollItemH ? 0.0 : 28.0) + (!this.bScrollItemH1 || this.mWarlobbyKind != (byte) 0 ? 0.0 : 28.0) + (!this.bScrollItemH2 || this.mWarlobbyKind != (byte) 1 ? 0.0 : 28.0));
    if (this.mWarlobbyKind == (byte) 2)
      num -= 37f;
    this.tmplist_Warlooby.Clear();
    this.tmplist_Warlooby.Add(118f + num);
    this.tmplist_Warlooby.Add(38f);
    for (int index = 0; index < (int) this.mWarlobbySolderList; ++index)
      this.tmplist_Warlooby.Add(39f);
    this.m_ScrollPanel_Warlobby.AddNewDataHeight(this.tmplist_Warlooby);
  }

  public void CheckWarlobbyTroopSelect(byte mKind = 1, bool ReSetText = true)
  {
    if (mKind < (byte) 1 || mKind > (byte) 2)
      return;
    long num1 = (long) this.Hero_Total + (long) this.mExpeditionlimit;
    long num2 = (long) this.Hero_Total + (long) this.mExpeditionlimit;
    this.WarlobbyTroopMax = (long) this.Hero_Total + (long) this.mExpeditionlimit;
    bool flag = true;
    long num3 = 0;
    double num4 = 0.0;
    double num5 = 0.0;
    Array.Clear((Array) this.mShowSolderIdx, 0, this.mShowSolderIdx.Length);
    Array.Clear((Array) this.m_WarlobbySoldier, 0, this.m_WarlobbySoldier.Length);
    Array.Clear((Array) this.mWarlobbySolderValue, 0, this.mWarlobbySolderValue.Length);
    Array.Clear((Array) this.m_NeedWarlobbySoldier, 0, this.m_NeedWarlobbySoldier.Length);
    this.mWarlobbySolderList = (byte) 0;
    this.bAllZero = false;
    byte[] numArray1 = new byte[16];
    byte[] numArray2 = new byte[16];
    byte index1 = 0;
    switch (mKind)
    {
      case 1:
        this.Text_W_SelectTilte.text = this.DM.mStringTable.GetStringByID(14717U);
        for (int index2 = 0; index2 < 4; ++index2)
        {
          for (int index3 = 0; index3 < 4; ++index3)
          {
            if (this.m_SoldierMax[index3 * 4 + index2].Value[0] > 0U)
            {
              numArray1[index2] = (byte) (index3 * 4 + index2 + 1);
              break;
            }
          }
          int index4 = (int) numArray1[index2] - 1;
          if (index4 < 0)
          {
            for (int index5 = 0; index5 < 4; ++index5)
            {
              this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index2 * 4 + (4 - index5)));
              if (this.tmpSD.Science != (ushort) 0 && this.DM.GetTechLevel(this.tmpSD.Science) != (byte) 0 || this.tmpSD.Tier == (byte) 1)
              {
                index4 = index5 * 4 + index2;
                break;
              }
            }
          }
          if (index4 >= 0 && this.WarlobbyTroopTotalTroopNum > 0U)
            this.mWarlobbySolderValue[index4] = (double) (this.WarlobbyTroopData[0][index2] + this.WarlobbyTroopData[1][index2] + this.WarlobbyTroopData[2][index2] + this.WarlobbyTroopData[3][index2]) / (double) this.WarlobbyTroopTotalTroopNum;
          if (index4 >= 0 && this.mWarlobbySolderValue[index4] * 100.0 > 0.0)
          {
            numArray2[(int) index1] = (byte) index4;
            this.m_NeedWarlobbySoldier[index4] = (long) (this.mWarlobbySolderValue[index4] * (double) this.WarlobbyTroopMax);
            num2 -= this.m_NeedWarlobbySoldier[index4];
            ++index1;
          }
        }
        break;
      case 2:
        this.Text_W_SelectTilte.text = this.DM.mStringTable.GetStringByID(14723U);
        for (int index6 = 0; index6 < 16; ++index6)
        {
          if (this.WarlobbyTroopTotalTroopNum > 0U)
            this.mWarlobbySolderValue[index6] = (double) this.WarlobbyTroopData[index6 >> 2][index6 & 3] / (double) this.WarlobbyTroopTotalTroopNum;
          if (this.mWarlobbySolderValue[index6] * 100.0 > 0.0)
          {
            numArray2[(int) index1] = (byte) index6;
            this.m_NeedWarlobbySoldier[index6] = (long) (this.mWarlobbySolderValue[index6] * (double) this.WarlobbyTroopMax);
            num2 -= this.m_NeedWarlobbySoldier[index6];
            ++index1;
          }
        }
        break;
    }
    if (num2 > 0L)
    {
      byte num6 = 0;
      for (int index7 = 0; index7 < (int) index1; ++index7)
      {
        int index8 = (int) numArray2[index7];
        if (this.mWarlobbySolderValue[index8] * 100.0 > 0.0 && this.mWarlobbySolderValue[index8] * (double) this.WarlobbyTroopMax >= 1.0)
          ++num6;
      }
      if (num6 > (byte) 0)
        num3 = num2 % (long) num6 <= 0L ? num2 / (long) num6 : num2 / (long) num6 + 1L;
      for (int index9 = 0; index9 < (int) index1; ++index9)
      {
        int index10 = (int) numArray2[index9];
        if (this.mWarlobbySolderValue[index10] * 100.0 > 0.0 && this.mWarlobbySolderValue[index10] * (double) this.WarlobbyTroopMax >= 1.0 && num2 > 0L)
        {
          this.m_NeedWarlobbySoldier[index10] += num2 - num3 <= 0L ? num2 : num3;
          num2 = num2 - num3 < 0L ? num2 : num2 - num3;
          if (num2 <= 0L)
            break;
        }
      }
    }
    byte num7 = 0;
    for (int index11 = 0; index11 < (int) index1; ++index11)
    {
      int index12 = (int) numArray2[index11];
      if (this.mWarlobbySolderValue[index12] * 100.0 > 0.0 && this.mWarlobbySolderValue[index12] * (double) this.WarlobbyTroopMax >= 1.0)
      {
        if (this.m_SoldierMax[index12].Value[0] < (uint) (this.mWarlobbySolderValue[index12] * (double) this.WarlobbyTroopMax))
        {
          if (this.m_SoldierMax[index12].Value[0] == 0U)
            this.bAllZero = true;
          flag = false;
        }
        else
        {
          this.m_WarlobbySoldier[index12] = (long) (this.mWarlobbySolderValue[index12] * (double) this.WarlobbyTroopMax);
          num1 -= (long) (this.mWarlobbySolderValue[index12] * (double) this.WarlobbyTroopMax);
          ++num7;
        }
      }
    }
    if (flag && num1 > 0L)
    {
      if (num7 > (byte) 0)
        num3 = num1 % (long) num7 <= 0L ? num1 / (long) num7 : num1 / (long) num7 + 1L;
      for (int index13 = 0; index13 < (int) index1; ++index13)
      {
        int index14 = (int) numArray2[index13];
        if (this.mWarlobbySolderValue[index14] * 100.0 > 0.0 && this.mWarlobbySolderValue[index14] * (double) this.WarlobbyTroopMax >= 1.0 && num1 > 0L)
        {
          if ((long) this.m_SoldierMax[index14].Value[0] >= this.m_WarlobbySoldier[index14] + num3 || (long) this.m_SoldierMax[index14].Value[0] >= this.m_WarlobbySoldier[index14] + num1)
          {
            this.m_WarlobbySoldier[index14] += num1 - num3 <= 0L ? num1 : num3;
            num1 = num1 - num3 < 0L ? num1 : num1 - num3;
            if (num1 <= 0L)
              break;
          }
          else
          {
            flag = false;
            break;
          }
        }
      }
    }
    byte num8 = 0;
    if (!flag)
    {
      num1 = (long) this.Hero_Total + (long) this.mExpeditionlimit;
      for (int index15 = 0; index15 < (int) index1; ++index15)
      {
        int index16 = (int) numArray2[index15];
        num5 = 0.0;
        if (this.mWarlobbySolderValue[index16] * 100.0 > 0.0)
        {
          double num9 = (double) this.m_SoldierMax[index16].Value[0] / this.mWarlobbySolderValue[index16];
          if (num9 > 0.0)
          {
            if (num4 == 0.0)
            {
              num4 = num9;
              num8 = (byte) index16;
            }
            else if (num9 < num4)
            {
              num4 = num9;
              num8 = (byte) index16;
            }
          }
        }
      }
      if (num4 > 0.0)
      {
        for (int index17 = 0; index17 < (int) index1; ++index17)
        {
          int index18 = (int) numArray2[index17];
          this.m_WarlobbySoldier[index18] = (int) num8 != index18 ? (long) (num4 * this.mWarlobbySolderValue[index18]) : (long) this.m_SoldierMax[index18].Value[0];
          num1 -= this.m_WarlobbySoldier[index18];
        }
      }
    }
    for (int index19 = 0; index19 < (int) index1; ++index19)
    {
      int index20 = (int) numArray2[index19];
      if (this.m_NeedWarlobbySoldier[index20] > 0L)
      {
        this.mShowSolderIdx[(int) this.mWarlobbySolderList] = (byte) index20;
        ++this.mWarlobbySolderList;
      }
    }
    if (this.bAllZero)
    {
      num1 = (long) this.Hero_Total + (long) this.mExpeditionlimit;
      Array.Clear((Array) this.m_WarlobbySoldier, 0, this.m_WarlobbySoldier.Length);
    }
    this.WarlobbySelectQty = this.WarlobbyTroopMax - num1;
    this.Text_W_SelectTilte.SetAllDirty();
    this.Text_W_SelectTilte.cachedTextGenerator.Invalidate();
    this.CheckScrollH();
  }

  public void SetWarlobbyTroopSelect()
  {
    for (int index = 0; index < 16; ++index)
      this.m_Soldier[index] = this.m_WarlobbySoldier[index];
    for (int index = 0; index < 7; ++index)
    {
      if ((UnityEngine.Object) this.m_UnitRS_Item[index] != (UnityEngine.Object) null)
      {
        int type = (int) this.m_UnitRS_Item[index].Type;
        long x = this.m_Soldier[this.m_UnitRS_Item[type].m_ID];
        this.m_UnitRS_Item[type].MaxValue = (long) this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0];
        this.m_UnitRS_Item[type].Value = x;
        this.m_UnitRS_Item[type].m_slider.maxValue = (double) this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0];
        this.m_UnitRS_Item[type].m_slider.value = (double) x;
        if (this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0] >= this.Hero_Total)
        {
          this.m_UnitRS_Item[type].MaxValue = (long) this.Hero_Total;
          this.m_UnitRS_Item[type].m_slider.maxValue = (double) this.Hero_Total;
        }
        this.Cstr_Soldier_Text[type].ClearString();
        this.Cstr_Soldier_Text[type].IntToFormat(x, bNumber: true);
        this.Cstr_Soldier_Text[type].AppendFormat("{0}");
        this.m_UnitRS_Item[type].m_inputText.text = this.Cstr_Soldier_Text[type].ToString();
        this.m_UnitRS_Item[type].m_inputText.SetAllDirty();
        this.m_UnitRS_Item[type].m_inputText.cachedTextGenerator.Invalidate();
        if (x != 0L)
          ((Graphic) this.m_UnitRS_Item[index].m_inputText).color = this.mtextColor;
        else
          ((Graphic) this.m_UnitRS_Item[index].m_inputText).color = Color.white;
        this.Cstr_Soldier_ItemNum[type].ClearString();
        this.Cstr_Soldier_ItemNum[type].IntToFormat((long) this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0] - x, bNumber: true);
        this.Cstr_Soldier_ItemNum[type].AppendFormat("{0}");
        this.Text_Soldier_ItemNum[type].text = this.Cstr_Soldier_ItemNum[type].ToString();
        this.Text_Soldier_ItemNum[type].SetAllDirty();
        this.Text_Soldier_ItemNum[type].cachedTextGenerator.Invalidate();
      }
    }
    this.SetDRformURS(0);
  }

  public void UpPanelData(byte mKind = 0)
  {
    long num = (long) this.Hero_Total + (long) this.mExpeditionlimit;
    for (int index = 0; index < 16; ++index)
    {
      this.m_Soldier[index] = num - (long) this.m_SoldierMax[index].Value[(int) mKind] < 0L ? num : (long) this.m_SoldierMax[index].Value[(int) mKind];
      num -= this.m_Soldier[index];
    }
    for (int index = 0; index < 7; ++index)
    {
      if ((UnityEngine.Object) this.m_UnitRS_Item[index] != (UnityEngine.Object) null)
      {
        int type = (int) this.m_UnitRS_Item[index].Type;
        long x = this.m_Soldier[this.m_UnitRS_Item[type].m_ID];
        this.m_UnitRS_Item[type].MaxValue = (long) this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0];
        this.m_UnitRS_Item[type].Value = x;
        this.m_UnitRS_Item[type].m_slider.maxValue = (double) this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0];
        this.m_UnitRS_Item[type].m_slider.value = (double) x;
        if (this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0] >= this.Hero_Total)
        {
          this.m_UnitRS_Item[type].MaxValue = (long) this.Hero_Total;
          this.m_UnitRS_Item[type].m_slider.maxValue = (double) this.Hero_Total;
        }
        this.Cstr_Soldier_Text[type].ClearString();
        this.Cstr_Soldier_Text[type].IntToFormat(x, bNumber: true);
        this.Cstr_Soldier_Text[type].AppendFormat("{0}");
        this.m_UnitRS_Item[type].m_inputText.text = this.Cstr_Soldier_Text[type].ToString();
        this.m_UnitRS_Item[type].m_inputText.SetAllDirty();
        this.m_UnitRS_Item[type].m_inputText.cachedTextGenerator.Invalidate();
        if (x != 0L)
          ((Graphic) this.m_UnitRS_Item[index].m_inputText).color = this.mtextColor;
        else
          ((Graphic) this.m_UnitRS_Item[index].m_inputText).color = Color.white;
        this.Cstr_Soldier_ItemNum[type].ClearString();
        this.Cstr_Soldier_ItemNum[type].IntToFormat((long) this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0] - x, bNumber: true);
        this.Cstr_Soldier_ItemNum[type].AppendFormat("{0}");
        this.Text_Soldier_ItemNum[type].text = this.Cstr_Soldier_ItemNum[type].ToString();
        this.Text_Soldier_ItemNum[type].SetAllDirty();
        this.Text_Soldier_ItemNum[type].cachedTextGenerator.Invalidate();
      }
    }
    this.SetDRformURS(0);
  }

  public void SetHero_Total()
  {
    if (this.DM.LegionBattleHero.Count > 0 && (int) this.DM.LegionBattleHero[0] == (int) this.DM.GetLeaderID())
    {
      if (this.mOpenKind != 4)
        ((Component) this.Img_Leader[0]).gameObject.SetActive(true);
      this.bLeaderHero = true;
    }
    else
    {
      ((Component) this.Img_Leader[0]).gameObject.SetActive(false);
      this.bLeaderHero = false;
    }
    Array.Clear((Array) this.Hero_ID, 0, this.Hero_ID.Length);
    this.Hero_Total = this.BaseNum;
    for (int index = 0; index < this.DM.LegionBattleHero.Count; ++index)
    {
      uint key = (uint) this.DM.LegionBattleHero[index];
      if (this.DM.curHeroData.ContainsKey(key))
      {
        CurHeroData curHeroData = this.DM.curHeroData[key];
        this.Hero_ID[index] = (uint) curHeroData.ID;
        this.GUIM.ChangeHeroItemImg(((Component) this.btn_HeroImg[index]).transform, eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, curHeroData.Enhance, (int) curHeroData.Level);
        this.Hero_Total += (uint) this.DM.RankSoldiers[(int) curHeroData.Enhance];
        ((Component) this.Img_AddBG[index]).gameObject.SetActive(false);
        ((Component) this.btn_HeroImg[index]).gameObject.SetActive(true);
      }
    }
    for (int count = this.DM.LegionBattleHero.Count; count < 5; ++count)
      ((Component) this.btn_HeroImg[count]).gameObject.SetActive(false);
    for (int lockCount = this.LockCount; lockCount < 5; ++lockCount)
    {
      ((Component) this.Img_Lock[lockCount]).gameObject.SetActive(true);
      ((Component) this.Img_AddBG[lockCount]).gameObject.SetActive(false);
    }
  }

  public override void OnClose()
  {
    if (this.AssetName != null)
      this.GUIM.RemoveSpriteAsset(this.AssetName);
    if (this.Cstr != null)
      StringManager.Instance.DeSpawnString(this.Cstr);
    if (this.Cstr_MusterTime != null)
      StringManager.Instance.DeSpawnString(this.Cstr_MusterTime);
    if (this.Cstr_Time != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Time);
    if (this.Cstr_Accelerate != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Accelerate);
    if (this.AllyName != null)
      StringManager.Instance.DeSpawnString(this.AllyName);
    if (this.Cstr_TeamName != null)
      StringManager.Instance.DeSpawnString(this.Cstr_TeamName);
    if (this.Cstr_WarlobbyKindText != null)
      StringManager.Instance.DeSpawnString(this.Cstr_WarlobbyKindText);
    if (this.Cstr_WarlobbySolder != null)
      StringManager.Instance.DeSpawnString(this.Cstr_WarlobbySolder);
    if (this.Cstr_WarlobbyMaxSolder != null)
      StringManager.Instance.DeSpawnString(this.Cstr_WarlobbyMaxSolder);
    if (this.Cstr_HintNum != null)
      StringManager.Instance.DeSpawnString(this.Cstr_HintNum);
    for (int index = 0; index < 11; ++index)
    {
      if (this.Cstr_WarSoldier_Text[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_WarSoldier_Text[index]);
      if (this.Cstr_WarSoldierRate_Text[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_WarSoldierRate_Text[index]);
    }
    for (int index = 0; index < 2; ++index)
    {
      if (this.Cstr_LoadNum[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_LoadNum[index]);
      if (this.Cstr_Troops[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Troops[index]);
    }
    for (int index = 0; index < 7; ++index)
    {
      if (this.Cstr_Soldier_ItemNum[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Soldier_ItemNum[index]);
      if (this.Cstr_Soldier_Text[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Soldier_Text[index]);
    }
    if (!this.DM.bSetExpediton)
    {
      this.DM.mScroll_Idx = 0;
      this.DM.mScroll_Y = 0.0f;
    }
    this.GUIM.ClearCalculator();
    if ((bool) (UnityEngine.Object) this.door)
      this.door.HideFightButton();
    if (this.mUI_CK != byte.MaxValue)
    {
      this.DM.mcollectionKind = this.mUI_CK;
      PlayerPrefs.SetString("CollectionKind", this.DM.mcollectionKind.ToString());
    }
    if (this.mUI_WarlobbyK != byte.MaxValue)
    {
      this.DM.mWarlobby_Kind = this.mUI_WarlobbyK;
      PlayerPrefs.SetString("WarlobbyKind", this.DM.mWarlobby_Kind.ToString());
    }
    if (this.mOpenKind != 1)
      return;
    this.DM.LegionBattleHero.Clear();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.fightButtonTime = this.door.PlayFight();
        break;
      case 2:
        this.DM.bSetExpediton = false;
        for (int index = 0; index < 16; ++index)
          this.DM.mExpeditionSoldierList[index] = 0U;
        this.DM.LegionBattleHero.Clear();
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 3:
        if (this.DM.TeamName.Length == 0)
        {
          this.DM.TeamName.ClearString();
          this.DM.TeamName.IntToFormat((long) ((int) this.TMD_Idx + 1));
          this.DM.TeamName.AppendFormat(this.DM.mStringTable.GetStringByID(993U));
        }
        this.TMD_Name = this.DM.TeamName.ToString();
        this.Text_Name.text = this.TMD_Name;
        this.Text_Name.SetAllDirty();
        this.Text_Name.cachedTextGenerator.Invalidate();
        this.DM.LegionBattleHero.Clear();
        break;
      case 4:
        if (this.mOpenKind != 6)
          break;
        this.DM.LegionBattleHero.Clear();
        if (this.TMD_Idx >= (byte) 0 && this.TMD_Idx <= (byte) 4)
        {
          bool flag = false;
          int index1 = 0;
          for (int index2 = 0; index2 < 5; ++index2)
          {
            if (this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index2] != (ushort) 0 && (int) this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index2] == (int) this.DM.GetLeaderID())
            {
              flag = true;
              index1 = index2;
              break;
            }
          }
          for (int index3 = 0; index3 < 5; ++index3)
          {
            if (flag && index1 != 0)
            {
              if (index3 == 0)
                this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index1]);
              else if (index3 == index1)
                this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[0]);
              else
                this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index3]);
            }
            else
              this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index3]);
          }
          if (this.DM.LegionBattleHero.Count > 0)
          {
            this.BG_T1.gameObject.SetActive(false);
            this.BG_T2.gameObject.SetActive(true);
            this.bExpeditionHero = true;
          }
          this.DM.bSetExpediton = true;
          for (int index4 = 0; index4 < 16; ++index4)
            this.DM.mExpeditionSoldierList[index4] = this.DM.mTroopMemoryData[(int) this.TMD_Idx].TroopData[index4];
        }
        this.UpDataSoldier();
        this.bSpeed = true;
        Array.Sort<byte>(this.SpeedsortData, (IComparer<byte>) this);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist);
        this.SetDRformURS(0);
        if (this.SoldierMax == 0L)
          ((Component) this.Img_NoSoldierBG).gameObject.SetActive(true);
        else
          ((Component) this.Img_NoSoldierBG).gameObject.SetActive(false);
        this.CheckMaxSelect();
        this.SelectFormation();
        break;
      case 5:
        if ((this.mWarlobbyKind != (byte) 0 || this.DM.WarlobbyDetail.AttackOrDefense != (byte) 0 || this.WarlobbyTroopTotalTroopNum != 0U || this.DM.WarTroop.Count <= 0) && (this.mWarlobbyKind < (byte) 1 || this.mWarlobbyKind > (byte) 2 || this.DM.WarlobbyDetail.AttackOrDefense != (byte) 2 || this.DM.WarTroop.Count <= 0))
          break;
        this.WarlobbyTroopTotalTroopNum = this.DM.WarTroop[0].TotalTroopNum;
        for (int index = 0; index < 16; ++index)
          this.WarlobbyTroopData[index >> 2][index & 3] = this.DM.WarTroop[0].TroopData[index >> 2][3 - (index & 3)];
        break;
      case 6:
        if ((this.mWarlobbyKind != (byte) 0 || this.DM.WarlobbyDetail.AttackOrDefense != (byte) 0) && (this.mWarlobbyKind < (byte) 1 || this.mWarlobbyKind > (byte) 2 || this.DM.WarlobbyDetail.AttackOrDefense != (byte) 2))
          break;
        if (this.mUI_WarlobbyK_btn != byte.MaxValue)
          this.mUI_WarlobbyK = this.mUI_WarlobbyK_btn;
        this.SetWarlobbyMenu(false, (byte) 0);
        this.SetWarlobbyTroopSelect();
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        if (this.mOpenKind == 4)
        {
          if (HideArmyManager.Instance.IsHideArmy())
          {
            this.DM.bSetExpediton = false;
            for (int index = 0; index < 16; ++index)
              this.DM.mExpeditionSoldierList[index] = 0U;
            this.DM.LegionBattleHero.Clear();
            if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
              this.door.CloseMenu();
          }
          else
            this.door.ShowFightButton(new Vector3(280f, -282f, -500f), 250f, BtnKind: E3DButtonKind.BK_Big);
          if (this.DM.GetHeroState(this.DM.GetLeaderID()) != eHeroState.None)
          {
            ((Component) this.Img_HeroStatus).gameObject.SetActive(true);
            ((Component) this.Img_CaveStatus).gameObject.SetActive(false);
            this.bCaveMainHero = false;
          }
          else
          {
            this.DM.LegionBattleHero.Clear();
            this.DM.LegionBattleHero.Add(this.DM.GetLeaderID());
          }
          this.bLeaderHero = true;
        }
        this.bLogin = true;
        this.DM.bSetExpediton = true;
        for (int index = 0; index < 16; ++index)
          this.m_Soldier[index] = (long) this.DM.mExpeditionSoldierList[index];
        if (this.mOpenKind != 4)
        {
          this.BG_T1.gameObject.SetActive(true);
          this.BG_T2.gameObject.SetActive(false);
          if (this.mOpenKind == 1)
          {
            this.DM.LegionBattleHero.Clear();
            this.DM.SetSortNonFightHeroID();
            for (int index = 0; index < this.DM.GetMaxDefenders() && (long) index < (long) this.DM.NonFightHeroCount; ++index)
              this.DM.LegionBattleHero.Add((ushort) this.DM.SortNonFightHeroID[index]);
            if (this.DM.LegionBattleHero.Count > 0)
            {
              this.BG_T1.gameObject.SetActive(false);
              this.BG_T2.gameObject.SetActive(true);
              this.bExpeditionHero = true;
            }
          }
          else if (this.mOpenKind == 6)
          {
            this.DM.LegionBattleHero.Clear();
            if (this.TMD_Idx >= (byte) 0 && this.TMD_Idx <= (byte) 4)
            {
              bool flag = false;
              int index1 = 0;
              for (int index2 = 0; index2 < 5; ++index2)
              {
                if (this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index2] != (ushort) 0 && (int) this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index2] == (int) this.DM.GetLeaderID())
                {
                  flag = true;
                  index1 = index2;
                  break;
                }
              }
              for (int index3 = 0; index3 < 5; ++index3)
              {
                if (flag && index1 != 0)
                {
                  if (index3 == 0)
                    this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index1]);
                  else if (index3 == index1)
                    this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[0]);
                  else
                    this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index3]);
                }
                else
                  this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index3]);
              }
              if (this.DM.LegionBattleHero.Count > 0)
              {
                this.BG_T1.gameObject.SetActive(false);
                this.BG_T2.gameObject.SetActive(true);
                this.bExpeditionHero = true;
              }
              this.DM.bSetExpediton = true;
              for (int index4 = 0; index4 < 16; ++index4)
                this.DM.mExpeditionSoldierList[index4] = this.DM.mTroopMemoryData[(int) this.TMD_Idx].TroopData[index4];
            }
          }
        }
        if (this.mOpenKind != 10)
        {
          if (this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].bEnable)
          {
            this.mEquip = this.DM.EquipTable.GetRecordByKey(this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].ItemID);
            this.mBuffTotal = (uint) this.mEquip.PropertiesInfo[1].PropertiesValue;
          }
          else
            this.mBuffTotal = 0U;
        }
        else
          this.mBuffTotal = 5000U;
        this.EGASpeed = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED);
        this.EGASpeed2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_DEBUFF);
        this.EGASpeed3 = 0U;
        this.EGASpeed4 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_CURSE);
        this.EGACapacityKind = 0U;
        this.BaseNum = this.GUIM.BuildingData.GetBuildLevelRequestData((ushort) 8, this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level).Value1;
        this.Hero_Total = this.BaseNum;
        this.SetHero_Total();
        this.UpDataSoldier();
        this.bSpeed = true;
        Array.Sort<byte>(this.SpeedsortData, (IComparer<byte>) this);
        switch (this.mStatus)
        {
          case 0:
            this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ATTACK_MARCH_SPEED);
            if (this.mOpenKind == 4)
            {
              this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_SHELTER_TROOP_AMOUNT);
              break;
            }
            break;
          case 1:
            this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_GATHERING_MARCH_SPEED);
            this.EGALoadKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_LOAD);
            this.tmpLoad = (float) (10000U + this.EGALoadKind);
            this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_GATHERING_CAPACITY);
            break;
          case 2:
            this.EGAKind = this.MapID >= 3 ? 0U : this.DM.m_InForceMarchSpeedPlus;
            break;
          case 3:
            this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RALLY_SPEED);
            if (this.mOpenKind == 9)
            {
              this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_TROOP_AMOUNT);
              this.EGASpeed3 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_RALLY_SPEED);
              break;
            }
            break;
          case 4:
            this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RALLY_SPEED);
            if (this.mOpenKind == 9)
            {
              this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_TROOP_AMOUNT);
              this.EGASpeed3 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_JOINRALLY_SPEED);
              break;
            }
            break;
        }
        this.tmpTime = (float) (10000U + this.EGASpeed4) / (float) (10000U + this.EGAKind + this.EGASpeed - this.EGASpeed2 + this.EGASpeed3);
        this.Hero_Total += this.EGACapacityKind;
        this.Hero_Total = (uint) ((double) this.Hero_Total * ((double) (10000U + this.mBuffTotal) / 10000.0));
        this.SetDRformURS(0);
        this.CheckMaxSelect();
        this.SelectFormation();
        this.Cstr_Accelerate.ClearString();
        int num1 = (int) this.EGAKind + (int) this.EGASpeed - (int) this.EGASpeed2 + (int) this.EGASpeed3;
        if ((double) num1 % 100.0 != 0.0)
          this.Cstr_Accelerate.FloatToFormat((float) num1 / 100f, 2, false);
        else
          this.Cstr_Accelerate.IntToFormat((long) (num1 / 100));
        if (this.GUIM.IsArabic)
          this.Cstr_Accelerate.AppendFormat("%{0}");
        else
          this.Cstr_Accelerate.AppendFormat("{0}%");
        this.Text_Time[2].text = this.Cstr_Accelerate.ToString();
        this.Text_Time[2].SetAllDirty();
        this.Text_Time[2].cachedTextGenerator.Invalidate();
        break;
      case NetworkNews.Refresh:
        break;
      case NetworkNews.Refresh_Hero:
        if (this.mOpenKind != 4)
          break;
        eHeroState heroState = this.DM.GetHeroState(this.DM.GetLeaderID());
        if (heroState == eHeroState.None)
        {
          ((Component) this.Img_HeroStatus).gameObject.SetActive(false);
          break;
        }
        ((Component) this.Img_HeroStatus).gameObject.SetActive(true);
        this.DM.LegionBattleHero.Clear();
        this.SetHero_Total();
        this.SetDRformURS(0);
        switch (heroState - 1)
        {
          case eHeroState.None:
            this.Img_HeroStatus.sprite = this.SArray.m_Sprites[16];
            return;
          case eHeroState.IsFighting:
            this.Img_HeroStatus.sprite = this.SArray.m_Sprites[17];
            return;
          case eHeroState.Captured:
            this.Img_HeroStatus.sprite = this.SArray.m_Sprites[18];
            return;
          default:
            return;
        }
      default:
        if (networkNews != NetworkNews.Refresh_Soldier)
        {
          if (networkNews != NetworkNews.Refresh_AttribEffectVal && networkNews != NetworkNews.Refresh_BuffList)
          {
            if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
              break;
            this.Refresh_FontTexture();
            if ((UnityEngine.Object) this.m_UnitRS != (UnityEngine.Object) null)
              this.m_UnitRS.Refresh_FontTexture();
            for (int index = 0; index < 7; ++index)
            {
              if ((UnityEngine.Object) this.m_UnitRS_Item[index] != (UnityEngine.Object) null)
                this.m_UnitRS_Item[index].Refresh_FontTexture();
            }
            break;
          }
          if (this.mOpenKind != 10)
          {
            if (this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].bEnable)
            {
              this.mEquip = this.DM.EquipTable.GetRecordByKey(this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].ItemID);
              this.mBuffTotal = (uint) this.mEquip.PropertiesInfo[1].PropertiesValue;
            }
            else
              this.mBuffTotal = 0U;
          }
          else
            this.mBuffTotal = 5000U;
          this.EGASpeed = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED);
          this.EGASpeed2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_DEBUFF);
          this.EGASpeed3 = 0U;
          this.EGASpeed4 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_CURSE);
          this.EGACapacityKind = 0U;
          this.BaseNum = this.GUIM.BuildingData.GetBuildLevelRequestData((ushort) 8, this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level).Value1;
          this.Hero_Total = this.BaseNum;
          if (this.DM.LegionBattleHero.Count != 0 && this.mOpenKind != 4)
          {
            this.BG_T1.gameObject.SetActive(false);
            this.BG_T2.gameObject.SetActive(true);
          }
          this.SetHero_Total();
          switch (this.mStatus)
          {
            case 0:
              this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ATTACK_MARCH_SPEED);
              if (this.mOpenKind == 4)
              {
                this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_SHELTER_TROOP_AMOUNT);
                break;
              }
              break;
            case 1:
              this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_GATHERING_MARCH_SPEED);
              this.EGALoadKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_LOAD);
              this.tmpLoad = (float) (10000U + this.EGALoadKind);
              this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_GATHERING_CAPACITY);
              break;
            case 2:
              this.EGAKind = this.MapID >= 3 ? 0U : this.DM.m_InForceMarchSpeedPlus;
              break;
            case 3:
              this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RALLY_SPEED);
              if (this.mOpenKind == 9)
              {
                this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_TROOP_AMOUNT);
                this.EGASpeed3 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_RALLY_SPEED);
                break;
              }
              break;
            case 4:
              this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RALLY_SPEED);
              if (this.mOpenKind == 9)
              {
                this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_TROOP_AMOUNT);
                this.EGASpeed3 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_JOINRALLY_SPEED);
                break;
              }
              break;
          }
          this.tmpTime = (float) (10000U + this.EGASpeed4) / (float) (10000U + this.EGAKind + this.EGASpeed - this.EGASpeed2 + this.EGASpeed3);
          this.Hero_Total += this.EGACapacityKind;
          this.Hero_Total = (uint) ((double) this.Hero_Total * ((double) (10000U + this.mBuffTotal) / 10000.0));
          this.SetDRformURS(0);
          this.Cstr_Accelerate.ClearString();
          int num2 = (int) this.EGAKind + (int) this.EGASpeed - (int) this.EGASpeed2 + (int) this.EGASpeed3;
          if ((double) num2 % 100.0 != 0.0)
            this.Cstr_Accelerate.FloatToFormat((float) num2 / 100f, 2, false);
          else
            this.Cstr_Accelerate.IntToFormat((long) (num2 / 100));
          if (this.GUIM.IsArabic)
            this.Cstr_Accelerate.AppendFormat("%{0}");
          else
            this.Cstr_Accelerate.AppendFormat("{0}%");
          this.Text_Time[2].text = this.Cstr_Accelerate.ToString();
          this.Text_Time[2].SetAllDirty();
          this.Text_Time[2].cachedTextGenerator.Invalidate();
          break;
        }
        if (this.mOpenKind == 6)
        {
          this.DM.LegionBattleHero.Clear();
          if (this.TMD_Idx >= (byte) 0 && this.TMD_Idx <= (byte) 4)
          {
            bool flag = false;
            int index5 = 0;
            for (int index6 = 0; index6 < 5; ++index6)
            {
              if (this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index6] != (ushort) 0 && (int) this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index6] == (int) this.DM.GetLeaderID())
              {
                flag = true;
                index5 = index6;
                break;
              }
            }
            for (int index7 = 0; index7 < 5; ++index7)
            {
              if (flag && index5 != 0)
              {
                if (index7 == 0)
                  this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index5]);
                else if (index7 == index5)
                  this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[0]);
                else
                  this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index7]);
              }
              else
                this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int) this.TMD_Idx].Leader[index7]);
            }
            if (this.DM.LegionBattleHero.Count > 0)
            {
              this.BG_T1.gameObject.SetActive(false);
              this.BG_T2.gameObject.SetActive(true);
              this.bExpeditionHero = true;
            }
            this.DM.bSetExpediton = true;
            for (int index8 = 0; index8 < 16; ++index8)
              this.DM.mExpeditionSoldierList[index8] = this.DM.mTroopMemoryData[(int) this.TMD_Idx].TroopData[index8];
          }
        }
        else
        {
          for (int index = 0; index < 16; ++index)
            this.DM.mExpeditionSoldierList[index] = (uint) this.m_Soldier[index];
        }
        this.UpDataSoldier();
        this.bSpeed = true;
        Array.Sort<byte>(this.SpeedsortData, (IComparer<byte>) this);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist);
        this.SetDRformURS(0);
        if (this.SoldierMax == 0L)
          ((Component) this.Img_NoSoldierBG).gameObject.SetActive(true);
        else
          ((Component) this.Img_NoSoldierBG).gameObject.SetActive(false);
        this.CheckMaxSelect();
        this.SelectFormation();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.Text_MusterTime != (UnityEngine.Object) null && ((Behaviour) this.Text_MusterTime).enabled)
    {
      ((Behaviour) this.Text_MusterTime).enabled = false;
      ((Behaviour) this.Text_MusterTime).enabled = true;
    }
    if ((UnityEngine.Object) this.Text_HeroTeam != (UnityEngine.Object) null && ((Behaviour) this.Text_HeroTeam).enabled)
    {
      ((Behaviour) this.Text_HeroTeam).enabled = false;
      ((Behaviour) this.Text_HeroTeam).enabled = true;
    }
    if ((UnityEngine.Object) this.Text_Formation != (UnityEngine.Object) null && ((Behaviour) this.Text_Formation).enabled)
    {
      ((Behaviour) this.Text_Formation).enabled = false;
      ((Behaviour) this.Text_Formation).enabled = true;
    }
    if ((UnityEngine.Object) this.Text_CaveMain != (UnityEngine.Object) null && ((Behaviour) this.Text_CaveMain).enabled)
    {
      ((Behaviour) this.Text_CaveMain).enabled = false;
      ((Behaviour) this.Text_CaveMain).enabled = true;
    }
    if ((UnityEngine.Object) this.Text_Name != (UnityEngine.Object) null && ((Behaviour) this.Text_Name).enabled)
    {
      ((Behaviour) this.Text_Name).enabled = false;
      ((Behaviour) this.Text_Name).enabled = true;
    }
    if ((UnityEngine.Object) this.Text_Save != (UnityEngine.Object) null && ((Behaviour) this.Text_Save).enabled)
    {
      ((Behaviour) this.Text_Save).enabled = false;
      ((Behaviour) this.Text_Save).enabled = true;
    }
    if ((UnityEngine.Object) this.Text_Apply != (UnityEngine.Object) null && ((Behaviour) this.Text_Apply).enabled)
    {
      ((Behaviour) this.Text_Apply).enabled = false;
      ((Behaviour) this.Text_Apply).enabled = true;
    }
    if ((UnityEngine.Object) this.Text_btnApply != (UnityEngine.Object) null && ((Behaviour) this.Text_btnApply).enabled)
    {
      ((Behaviour) this.Text_btnApply).enabled = false;
      ((Behaviour) this.Text_btnApply).enabled = true;
    }
    if ((UnityEngine.Object) this.Text_W_SelectTilte != (UnityEngine.Object) null && ((Behaviour) this.Text_W_SelectTilte).enabled)
    {
      ((Behaviour) this.Text_W_SelectTilte).enabled = false;
      ((Behaviour) this.Text_W_SelectTilte).enabled = true;
    }
    if ((UnityEngine.Object) this.Text_W_MenuSet != (UnityEngine.Object) null && ((Behaviour) this.Text_W_MenuSet).enabled)
    {
      ((Behaviour) this.Text_W_MenuSet).enabled = false;
      ((Behaviour) this.Text_W_MenuSet).enabled = true;
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((UnityEngine.Object) this.Text_D[index] != (UnityEngine.Object) null && ((Behaviour) this.Text_D[index]).enabled)
      {
        ((Behaviour) this.Text_D[index]).enabled = false;
        ((Behaviour) this.Text_D[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.Text_L[index] != (UnityEngine.Object) null && ((Behaviour) this.Text_L[index]).enabled)
      {
        ((Behaviour) this.Text_L[index]).enabled = false;
        ((Behaviour) this.Text_L[index]).enabled = true;
      }
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((UnityEngine.Object) this.Text_Troops[index] != (UnityEngine.Object) null && ((Behaviour) this.Text_Troops[index]).enabled)
      {
        ((Behaviour) this.Text_Troops[index]).enabled = false;
        ((Behaviour) this.Text_Troops[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.Text_SelectMenu[index] != (UnityEngine.Object) null && ((Behaviour) this.Text_SelectMenu[index]).enabled)
      {
        ((Behaviour) this.Text_SelectMenu[index]).enabled = false;
        ((Behaviour) this.Text_SelectMenu[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.Text_W_Select[index] != (UnityEngine.Object) null && ((Behaviour) this.Text_W_Select[index]).enabled)
      {
        ((Behaviour) this.Text_W_Select[index]).enabled = false;
        ((Behaviour) this.Text_W_Select[index]).enabled = true;
      }
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((UnityEngine.Object) this.Text_Time[index] != (UnityEngine.Object) null && ((Behaviour) this.Text_Time[index]).enabled)
      {
        ((Behaviour) this.Text_Time[index]).enabled = false;
        ((Behaviour) this.Text_Time[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.Text_Hint[index] != (UnityEngine.Object) null && ((Behaviour) this.Text_Hint[index]).enabled)
      {
        ((Behaviour) this.Text_Hint[index]).enabled = false;
        ((Behaviour) this.Text_Hint[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.Text_tmpStr[index] != (UnityEngine.Object) null && ((Behaviour) this.Text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.Text_tmpStr[index]).enabled = false;
        ((Behaviour) this.Text_tmpStr[index]).enabled = true;
      }
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((UnityEngine.Object) this.Text_Load[index] != (UnityEngine.Object) null && ((Behaviour) this.Text_Load[index]).enabled)
      {
        ((Behaviour) this.Text_Load[index]).enabled = false;
        ((Behaviour) this.Text_Load[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.Text_Menu[index] != (UnityEngine.Object) null && ((Behaviour) this.Text_Menu[index]).enabled)
      {
        ((Behaviour) this.Text_Menu[index]).enabled = false;
        ((Behaviour) this.Text_Menu[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.Text_W_MenuKind[index] != (UnityEngine.Object) null && ((Behaviour) this.Text_W_MenuKind[index]).enabled)
      {
        ((Behaviour) this.Text_W_MenuKind[index]).enabled = false;
        ((Behaviour) this.Text_W_MenuKind[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.Text_W_Scroll[index] != (UnityEngine.Object) null && ((Behaviour) this.Text_W_Scroll[index]).enabled)
      {
        ((Behaviour) this.Text_W_Scroll[index]).enabled = false;
        ((Behaviour) this.Text_W_Scroll[index]).enabled = true;
      }
    }
    for (int index = 0; index < 7; ++index)
    {
      if ((UnityEngine.Object) this.Text_Soldier_ItemNum[index] != (UnityEngine.Object) null && ((Behaviour) this.Text_Soldier_ItemNum[index]).enabled)
      {
        ((Behaviour) this.Text_Soldier_ItemNum[index]).enabled = false;
        ((Behaviour) this.Text_Soldier_ItemNum[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.Text_Soldier_ItemName[index] != (UnityEngine.Object) null && ((Behaviour) this.Text_Soldier_ItemName[index]).enabled)
      {
        ((Behaviour) this.Text_Soldier_ItemName[index]).enabled = false;
        ((Behaviour) this.Text_Soldier_ItemName[index]).enabled = true;
      }
    }
    for (int index1 = 0; index1 < 11; ++index1)
    {
      for (int index2 = 0; index2 < 5; ++index2)
      {
        if ((UnityEngine.Object) this.m_Warlobby_Item[index1].text_T1[index2] != (UnityEngine.Object) null && ((Behaviour) this.m_Warlobby_Item[index1].text_T1[index2]).enabled)
        {
          ((Behaviour) this.m_Warlobby_Item[index1].text_T1[index2]).enabled = false;
          ((Behaviour) this.m_Warlobby_Item[index1].text_T1[index2]).enabled = true;
        }
      }
      for (int index3 = 0; index3 < 4; ++index3)
      {
        if ((UnityEngine.Object) this.m_Warlobby_Item[index1].text_SolderT[index3] != (UnityEngine.Object) null && ((Behaviour) this.m_Warlobby_Item[index1].text_SolderT[index3]).enabled)
        {
          ((Behaviour) this.m_Warlobby_Item[index1].text_SolderT[index3]).enabled = false;
          ((Behaviour) this.m_Warlobby_Item[index1].text_SolderT[index3]).enabled = true;
        }
      }
      if ((UnityEngine.Object) this.m_Warlobby_Item[index1].text_T2 != (UnityEngine.Object) null && ((Behaviour) this.m_Warlobby_Item[index1].text_T2).enabled)
      {
        ((Behaviour) this.m_Warlobby_Item[index1].text_T2).enabled = false;
        ((Behaviour) this.m_Warlobby_Item[index1].text_T2).enabled = true;
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((UnityEngine.Object) this.btn_HeroImg[index] != (UnityEngine.Object) null && ((Behaviour) this.btn_HeroImg[index]).enabled)
        this.btn_HeroImg[index].Refresh_FontTexture();
    }
    if (!((UnityEngine.Object) this.btn_MainHeroImg != (UnityEngine.Object) null) || !((Behaviour) this.btn_MainHeroImg).enabled)
      return;
    this.btn_MainHeroImg.Refresh_FontTexture();
  }

  private void Update()
  {
    if (this.bLeaderHero)
    {
      this.ShowTime += Time.smoothDeltaTime;
      if ((double) this.ShowTime >= 0.0)
      {
        if ((double) this.ShowTime >= 2.0)
          this.ShowTime = 0.0f;
        float a = (double) this.ShowTime <= 1.0 ? this.ShowTime : 2f - this.ShowTime;
        if (((UIBehaviour) this.Img_Leader[0]).IsActive())
          ((Graphic) this.Img_Leader[1]).color = new Color(1f, 1f, 1f, a);
        if (((UIBehaviour) this.Img_CaveMain[0]).IsActive())
          ((Graphic) this.Img_CaveMain[1]).color = new Color(1f, 1f, 1f, a);
      }
    }
    if ((double) this.fightButtonTime <= 0.0)
      return;
    this.fightButtonTime -= Time.deltaTime;
    if ((double) this.fightButtonTime > 0.0)
      return;
    AudioManager.Instance.PlayUISFX(UIKind.Expedition);
    if (this.mOpenKind == 1)
    {
      GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MapToWar_Stage);
      if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
      {
        this.door.m_GroundInfo.bOpenPvePanel = false;
        this.door.CloseMenu();
      }
      GameManager.OnRefresh(NetworkNews.Refresh_Soldier);
      GameManager.OnRefresh(NetworkNews.Refresh_Hospital);
      GameManager.OnRefresh(NetworkNews.Refresh_Resource);
    }
    else
      this.SendExpedition();
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Expedition);
  }

  public override void ReOnOpen()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || this.mOpenKind == 6)
      return;
    menu.ShowFightButton(new Vector3(280f, -282f, -500f), 250f, BtnKind: E3DButtonKind.BK_Big);
  }
}
