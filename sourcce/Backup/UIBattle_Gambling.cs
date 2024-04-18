// Decompiled with JetBrains decompiler
// Type: UIBattle_Gambling
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIBattle_Gambling : GUIWindow, IUIButtonClickHandler, IUIUpdatePos, IUIHIBtnClickHandler
{
  private const int MaxBtnItem = 6;
  private const float MaxRandIdleTime = 10f;
  private const float TextDisplayShowTime = 1f;
  public readonly string[] NpcActStr = new string[7]
  {
    "idle",
    "idle02",
    "idle03",
    "idle04",
    "attack",
    "victory",
    "v_idle"
  };
  private Transform GameT;
  private Transform Tmp;
  private Transform P_T;
  private Transform SPT;
  private Transform InputOff;
  private Transform Hero_Pos;
  private Transform IPhoneXPanel;
  public Transform DimPanle;
  private Transform[] Particle_Pos = new Transform[6];
  private Transform PrizePos3D;
  private Transform Hero_Model;
  private Transform Prize_Modle;
  private Transform BGT;
  private Transform AlertPanel;
  private Transform ItemListT;
  private Transform GoldHintT;
  private Transform SPBgTF;
  private AssetBundle AB;
  private AssetBundle Prize_AB;
  private AssetBundleRequest AR;
  private AssetBundleRequest Prize_AR;
  private UIButton btn_EXIT;
  public UIButton btn_Hint;
  public UIButton btn_Hint2;
  private UIButton btn_ItemList;
  private UIButton btn_ChangeModel_Normal;
  public UIButton btn_ChangeModel_Turbo;
  private UIButton btn_InfoBtn;
  private Image Img_GoldHint;
  public Image Img_ItemListT;
  private Image Img_Hint2Flash;
  private Image Img_Hint2;
  private Image Img_Hint2_Black;
  private Image Img_ChangeNormalFlash;
  private Image Img_ChangeNormal;
  private Image Img_ChangeTurboFlash;
  private Image Img_ChangeTurbo;
  private UIText text_Hint;
  private UIText text_Hint2;
  private UIText text_ChangeModel_Normal;
  private UIText text_ChangeModel_Turbo;
  private UIText text_TimeValue;
  private UIText text_CostValue;
  private UIButton btn_Filter;
  private UIButton btn_SP;
  private UIText textPrize;
  private Image ImgPrize;
  private UIText[] text_ItmeNum = new UIText[6];
  private RectTransform[] btn_Item_Rect = new RectTransform[6];
  public UIHIBtn[] btn_Item = new UIHIBtn[6];
  private UILEBtn[] btn_Item2 = new UILEBtn[6];
  private ShitfHelper mShitfHelper = new ShitfHelper();
  private GameObject mJackPotDataPanel;
  private UIBattle_Gambling.JackPotUI[] mJackPotUI = new UIBattle_Gambling.JackPotUI[3];
  private GameObject mNpcHp;
  private UIText textNpcHpValue;
  private UIText textNpcHpName;
  private Image imgNpcHpSlider;
  private UISpritesArray mSpArray;
  private GUIManager GUIM;
  private Door door;
  private Font TTFont;
  private CString[] mStr = new CString[28];
  private CString[] SPStrings = new CString[4];
  private GameObject go2;
  private GameObject go;
  private int AssetKey;
  private int AssetKey2;
  private bool bOpenEnd;
  private bool ABIsDone;
  private bool ABIsDone_Prize;
  private bool bCanInput = true;
  private Animation tmpAN;
  private Animation tmpAN_Prize;
  private UIBattle_Gambling.NpcAct mNpcAct;
  private bool bNpcAttackVictory;
  private GameObject[] EffectObj = new GameObject[5];
  private float CDTime;
  private float ShowPrizeTime;
  private float RandIdleTime = 10f;
  private List<CommonItemDataType> mItemList = new List<CommonItemDataType>();
  private Image SPBG;
  private Image SPRankUpDown;
  private UIText SPName;
  private UIText SPScore;
  private UIText SPScoreFly;
  private UIText SPRank;
  private RectTransform SPFly;
  private bool bAdjustSPRankUpDownPos;
  private bool SPReady;
  private bool ShowSP;
  private float[] SPShowTiming = new float[9]
  {
    0.4f,
    0.2f,
    0.05f,
    0.1f,
    0.4f,
    0.1f,
    0.1f,
    0.8f,
    0.4f
  };
  private float SPShowTime;
  private float SPShowPhase;
  public static uint SPScoreValue;
  public static uint SPScoreFlyValue;
  public static uint SPRankChange;
  private string[] anim = new string[4]
  {
    "idle",
    "status_1",
    "status_2",
    "status_3"
  };
  private int[] animR_Idle = new int[4]{ 1, 3, 8, 88 };
  private int[] animR_Idle_Idx = new int[4]{ 3, 2, 1, 0 };
  private int[] animR_S1 = new int[4]{ 2, 8, 10, 80 };
  private int[] animR_S1_Idx = new int[4]{ 3, 2, 0, 1 };
  private int[] animR_S2 = new int[4]{ 2, 8, 10, 80 };
  private int[] animR_S2_Idx = new int[4]{ 0, 3, 1, 2 };
  private int[] animR_S3 = new int[4]{ 2, 8, 10, 80 };
  private int[] animR_S3_Idx = new int[4]{ 0, 1, 2, 3 };
  private int[] anim_R = new int[4];
  private int[] anim_Idx = new int[4];
  private bool bSpecialNpc;
  public UIRunningTextEX RunningText;
  private bool bFreeMode;
  private List<byte> DisplayQueue = new List<byte>();
  private float? TextDisplayTime;
  private Transform ComboT;
  private UIText text_ComboCount;
  private UIText text_Combo;
  private UIText textDimPanle;
  private UIButton btnDimPanle;
  private CString mStrComboCount;
  private int CountMax;
  private float mComboTime;
  private int mStatus;
  private int mCount;
  private bool bfadeout;
  private float mtextHeight;
  private float mtextTopHeight;
  private float tmpY;
  private Transform alertBlock;
  private Image alertBlock_T;
  private Image alertBlock_B;
  private Image alertBlock_L;
  private Image alertBlock_R;
  private float mShiftTime;
  private int debugIdx;
  private int debugIdx_P;

  public override void OnOpen(int arg1, int arg2)
  {
    this.SpawnString();
    this.InitUI();
    this.InitSP();
    this.UpdateUI(3, 0);
    this.UpdateUI(2, 0);
    this.DisplayQueue.Clear();
    this.TextDisplayTime = new float?();
    UIHintMask.bPassThrough = false;
    this.GUIM.CheckBattleAttackState();
  }

  public override void OnClose()
  {
    if ((UnityEngine.Object) this.BGT != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.BGT.gameObject);
    GUIManager.Instance.pDVMgr.EndMoveBossText();
    AssetManager.UnloadAssetBundle(this.AssetKey);
    AssetManager.UnloadAssetBundle(this.AssetKey2);
    this.DeSpawnString();
    if (this.EffectObj != null)
    {
      for (int index = 0; index < this.EffectObj.Length; ++index)
      {
        ParticleManager.Instance.DeSpawn(this.EffectObj[index]);
        this.EffectObj[index] = (GameObject) null;
      }
    }
    this.mItemList.Clear();
    if (GamblingManager.Instance.m_QueueGamebleItem != null)
      GamblingManager.Instance.m_QueueGamebleItem.Clear();
    UIHintMask.bPassThrough = true;
    LordEquipData.Instance().Scan_MaterialOrEquipIncreace();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        this.UpdateUI(3, 0);
        this.UpdateUI(2, 0);
        this.UpdateMoney();
        this.CDTime = 0.0f;
        break;
      case NetworkNews.Refresh:
        this.UpdateMoney();
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Item)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          this.Refresh_FontTexture();
          break;
        }
        this.UpdateUI(8, 0);
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.text_Hint != (UnityEngine.Object) null && ((Behaviour) this.text_Hint).enabled)
    {
      ((Behaviour) this.text_Hint).enabled = false;
      ((Behaviour) this.text_Hint).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Hint2 != (UnityEngine.Object) null && ((Behaviour) this.text_Hint2).enabled)
    {
      ((Behaviour) this.text_Hint2).enabled = false;
      ((Behaviour) this.text_Hint2).enabled = true;
    }
    if ((UnityEngine.Object) this.btn_ChangeModel_Normal != (UnityEngine.Object) null && ((Behaviour) this.btn_ChangeModel_Normal).enabled)
    {
      ((Behaviour) this.btn_ChangeModel_Normal).enabled = false;
      ((Behaviour) this.btn_ChangeModel_Normal).enabled = true;
    }
    if ((UnityEngine.Object) this.btn_ChangeModel_Turbo != (UnityEngine.Object) null && ((Behaviour) this.btn_ChangeModel_Turbo).enabled)
    {
      ((Behaviour) this.btn_ChangeModel_Turbo).enabled = false;
      ((Behaviour) this.btn_ChangeModel_Turbo).enabled = true;
    }
    if ((UnityEngine.Object) this.text_TimeValue != (UnityEngine.Object) null && ((Behaviour) this.text_TimeValue).enabled)
    {
      ((Behaviour) this.text_TimeValue).enabled = false;
      ((Behaviour) this.text_TimeValue).enabled = true;
    }
    if ((UnityEngine.Object) this.text_CostValue != (UnityEngine.Object) null && ((Behaviour) this.text_CostValue).enabled)
    {
      ((Behaviour) this.text_CostValue).enabled = false;
      ((Behaviour) this.text_CostValue).enabled = true;
    }
    if ((UnityEngine.Object) this.textNpcHpValue != (UnityEngine.Object) null && ((Behaviour) this.textNpcHpValue).enabled)
    {
      ((Behaviour) this.textNpcHpValue).enabled = false;
      ((Behaviour) this.textNpcHpValue).enabled = true;
    }
    if ((UnityEngine.Object) this.textNpcHpName != (UnityEngine.Object) null && ((Behaviour) this.textNpcHpName).enabled)
    {
      ((Behaviour) this.textNpcHpName).enabled = false;
      ((Behaviour) this.textNpcHpName).enabled = true;
    }
    if (this.mJackPotUI != null)
    {
      for (int index = 0; index < this.mJackPotUI.Length; ++index)
      {
        if ((UnityEngine.Object) this.mJackPotUI[index].Name != (UnityEngine.Object) null && ((Behaviour) this.mJackPotUI[index].Name).enabled)
        {
          ((Behaviour) this.mJackPotUI[index].Name).enabled = false;
          ((Behaviour) this.mJackPotUI[index].Name).enabled = true;
        }
        if ((UnityEngine.Object) this.mJackPotUI[index].Num != (UnityEngine.Object) null && ((Behaviour) this.mJackPotUI[index].Num).enabled)
        {
          ((Behaviour) this.mJackPotUI[index].Num).enabled = false;
          ((Behaviour) this.mJackPotUI[index].Num).enabled = true;
        }
        if ((UnityEngine.Object) this.mJackPotUI[index].Time != (UnityEngine.Object) null && ((Behaviour) this.mJackPotUI[index].Time).enabled)
        {
          ((Behaviour) this.mJackPotUI[index].Time).enabled = false;
          ((Behaviour) this.mJackPotUI[index].Time).enabled = true;
        }
      }
    }
    for (int index = 0; index < 6; ++index)
    {
      if ((UnityEngine.Object) this.text_ItmeNum[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItmeNum[index]).enabled)
      {
        ((Behaviour) this.text_ItmeNum[index]).enabled = false;
        ((Behaviour) this.text_ItmeNum[index]).enabled = true;
      }
    }
    if (this.btn_Item != null)
    {
      for (int index = 0; index < this.btn_Item.Length; ++index)
      {
        if ((UnityEngine.Object) this.btn_Item[index] != (UnityEngine.Object) null)
          this.btn_Item[index].Refresh_FontTexture();
      }
    }
    if (this.btn_Item2 != null)
    {
      for (int index = 0; index < this.btn_Item2.Length; ++index)
      {
        if ((UnityEngine.Object) this.btn_Item2[index] != (UnityEngine.Object) null)
          LordEquipData.ResetLordEquipFont(this.btn_Item2[index]);
      }
    }
    if ((UnityEngine.Object) this.RunningText != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.RunningText.m_RunningText1 != (UnityEngine.Object) null && ((Behaviour) this.RunningText.m_RunningText1).enabled)
      {
        ((Behaviour) this.RunningText.m_RunningText1).enabled = false;
        ((Behaviour) this.RunningText.m_RunningText1).enabled = true;
      }
      if ((UnityEngine.Object) this.RunningText.m_RunningText2 != (UnityEngine.Object) null && ((Behaviour) this.RunningText.m_RunningText2).enabled)
      {
        ((Behaviour) this.RunningText.m_RunningText2).enabled = false;
        ((Behaviour) this.RunningText.m_RunningText2).enabled = true;
      }
    }
    if ((UnityEngine.Object) this.text_ComboCount != (UnityEngine.Object) null && ((Behaviour) this.text_ComboCount).enabled)
    {
      ((Behaviour) this.text_ComboCount).enabled = false;
      ((Behaviour) this.text_ComboCount).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Combo != (UnityEngine.Object) null && ((Behaviour) this.text_Combo).enabled)
    {
      ((Behaviour) this.text_Combo).enabled = false;
      ((Behaviour) this.text_Combo).enabled = true;
    }
    if ((UnityEngine.Object) this.textPrize != (UnityEngine.Object) null && ((Behaviour) this.textPrize).enabled)
    {
      ((Behaviour) this.textPrize).enabled = false;
      ((Behaviour) this.textPrize).enabled = true;
    }
    if ((UnityEngine.Object) this.text_ChangeModel_Normal != (UnityEngine.Object) null && ((Behaviour) this.text_ChangeModel_Normal).enabled)
    {
      ((Behaviour) this.text_ChangeModel_Normal).enabled = false;
      ((Behaviour) this.text_ChangeModel_Normal).enabled = true;
    }
    if ((UnityEngine.Object) this.text_ChangeModel_Turbo != (UnityEngine.Object) null && ((Behaviour) this.text_ChangeModel_Turbo).enabled)
    {
      ((Behaviour) this.text_ChangeModel_Turbo).enabled = false;
      ((Behaviour) this.text_ChangeModel_Turbo).enabled = true;
    }
    if ((UnityEngine.Object) this.textDimPanle != (UnityEngine.Object) null && ((Behaviour) this.textDimPanle).enabled)
    {
      ((Behaviour) this.textDimPanle).enabled = false;
      ((Behaviour) this.textDimPanle).enabled = true;
    }
    if ((UnityEngine.Object) this.SPName != (UnityEngine.Object) null && ((Behaviour) this.SPName).enabled)
    {
      ((Behaviour) this.SPName).enabled = false;
      ((Behaviour) this.SPName).enabled = true;
    }
    if ((UnityEngine.Object) this.SPScore != (UnityEngine.Object) null && ((Behaviour) this.SPScore).enabled)
    {
      ((Behaviour) this.SPScore).enabled = false;
      ((Behaviour) this.SPScore).enabled = true;
    }
    if ((UnityEngine.Object) this.SPScoreFly != (UnityEngine.Object) null && ((Behaviour) this.SPScoreFly).enabled)
    {
      ((Behaviour) this.SPScoreFly).enabled = false;
      ((Behaviour) this.SPScoreFly).enabled = true;
    }
    if (!((UnityEngine.Object) this.SPRank != (UnityEngine.Object) null) || !((Behaviour) this.SPRank).enabled)
      return;
    ((Behaviour) this.SPRank).enabled = false;
    ((Behaviour) this.SPRank).enabled = true;
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        this.UpdatePrizeText();
        break;
      case 1:
        this.AddItem();
        break;
      case 2:
        this.UpdateJackPotData();
        break;
      case 3:
        this.UpdatePrizeText();
        this.UpdateBtnSprite();
        this.UpdateGambleCost();
        this.SetNpcHP();
        this.SetNpcName();
        this.UpdateCurCostValue();
        break;
      case 4:
        this.bCanInput = true;
        this.SetInputOff(false);
        break;
      case 5:
        this.bCanInput = false;
        this.SetInputOff(true);
        break;
      case 6:
        this.SetNpcHP();
        this.SetNpcName();
        break;
      case 7:
        this.SetNpcHP(UIBattle_Gambling.eHpType.Zero);
        this.SetNpcName();
        break;
      case 8:
        this.UpdateCurCostValue();
        this.UpdateGambleCost(arg2);
        break;
      case 9:
        this.UpdateJackPot_Self();
        break;
      case 10:
        this.P_T.gameObject.SetActive(true);
        this.BGT.gameObject.SetActive(false);
        ((Component) this.GUIM.m_BottomLayer).gameObject.SetActive(true);
        break;
      case 11:
        this.P_T.gameObject.SetActive(false);
        this.BGT.gameObject.SetActive(true);
        ((Component) this.GUIM.m_BottomLayer).gameObject.SetActive(false);
        break;
      case 12:
        this.SendUse();
        break;
      case 13:
        this.CloseUI();
        break;
      case 14:
        this.SetGambleBoxAnim(GambleBoxAnim.idle);
        this.bSpecialNpc = false;
        break;
      case 15:
        this.SetGambleBoxAnim(GambleBoxAnim.status_3);
        this.bSpecialNpc = true;
        break;
      case 16:
        this.SetNpcParticleType(NpcParticleType.None);
        break;
      case 17:
        GUIManager.Instance.pDVMgr.ShowBossText();
        break;
      case 18:
      case 20:
        GUIManager.Instance.pDVMgr.BeginMoveBossText();
        break;
      case 19:
        if (arg2 == 2)
        {
          this.DisplayQueue.Add((byte) 1);
          break;
        }
        GUIManager.Instance.pDVMgr.ShowGodText();
        this.TextDisplayTime = new float?(1f);
        break;
      case 21:
        if (this.DisplayQueue.Count <= 0)
          break;
        this.DisplayQueue.RemoveAt(0);
        GUIManager.Instance.pDVMgr.ShowGodText();
        this.TextDisplayTime = new float?(1f);
        break;
      case 22:
        this.bfadeout = false;
        this.mStatus = 0;
        this.mComboTime = 0.0f;
        if ((UnityEngine.Object) this.text_ComboCount != (UnityEngine.Object) null)
          ((Component) this.text_ComboCount).gameObject.SetActive(false);
        if (!((UnityEngine.Object) this.text_Combo != (UnityEngine.Object) null))
          break;
        ((Component) this.text_Combo).gameObject.SetActive(false);
        break;
      case 23:
        GamblingManager.Instance.CloseMenu(true);
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if ((double) this.ShowPrizeTime > 0.0 || !this.ShowSP && !this.bCanInput && sender.m_BtnID1 != 0)
      return;
    switch (sender.m_BtnID1)
    {
      case 0:
        this.CloseUI();
        break;
      case 1:
        if (DataManager.Instance.RoleAttr.ScardStar >= GamblingManager.Instance.GetCost() || NewbieManager.IsTeachWorking(ETeachKind.GAMBLING1))
        {
          if (!GamblingManager.Instance.bIsFirstOpen && !NewbieManager.IsTeachWorking(ETeachKind.GAMBLING1) && !NewbieManager.IsTeachWorking(ETeachKind.GAMBLING2))
          {
            this.GUIM.OpenCheckGamble();
            break;
          }
          this.SendUse();
          break;
        }
        this.OpennFilterUI();
        break;
      case 2:
        if (DataManager.Instance.RoleAttr.ScardStar >= GamblingManager.Instance.GetCost() || NewbieManager.IsTeachWorking(ETeachKind.GAMBLING1))
        {
          this.SendUse();
          break;
        }
        this.OpennFilterUI();
        break;
      case 3:
        if (GamblingManager.Instance.GambleMode == UIBattle_Gambling.eMode.Normal)
          break;
        if (GamblingManager.Instance.GetRemainFreePlay(UIBattle_Gambling.eMode.Turbo) > (byte) 0)
        {
          GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(5882U), DataManager.Instance.mStringTable.GetStringByID(9172U));
          break;
        }
        if (GamblingManager.Instance.IsSpecialType(UIBattle_Gambling.eMode.Turbo))
        {
          GUIManager.Instance.MsgStr.ClearString();
          this.SetNpcName(this.mStr[26]);
          GUIManager.Instance.MsgStr.StringToFormat(this.mStr[26]);
          GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9173U));
          GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(5882U), GUIManager.Instance.MsgStr.ToString());
          break;
        }
        this.SetBtnType(UIBattle_Gambling.eMode.Normal);
        this.GUIM.m_HUDMessage.MapHud.AddGambleMsg();
        break;
      case 4:
        if (GamblingManager.Instance.GambleMode == UIBattle_Gambling.eMode.Turbo)
          break;
        if (!DataManager.Instance.CheckPrizeFlag((byte) 9))
        {
          GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(5882U), DataManager.Instance.mStringTable.GetStringByID(9183U));
          break;
        }
        if (GamblingManager.Instance.GetRemainFreePlay(UIBattle_Gambling.eMode.Normal) > (byte) 0)
        {
          GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(5882U), DataManager.Instance.mStringTable.GetStringByID(9172U));
          break;
        }
        if (GamblingManager.Instance.IsSpecialType(UIBattle_Gambling.eMode.Normal))
        {
          GUIManager.Instance.MsgStr.ClearString();
          this.SetNpcName(this.mStr[26]);
          GUIManager.Instance.MsgStr.StringToFormat(this.mStr[26]);
          GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9173U));
          GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(5882U), GUIManager.Instance.MsgStr.ToString());
          break;
        }
        this.SetBtnType(UIBattle_Gambling.eMode.Turbo);
        this.GUIM.m_HUDMessage.MapHud.AddGambleMsg();
        break;
      case 6:
        GamblingManager.Instance.OpenMenu(EGUIWindow.UI_MonsterCrypt);
        break;
      case 7:
        GamblingManager.Instance.OpenMenu(EGUIWindow.UI_Monster_Crypt_3);
        break;
      case 8:
        GUIManager.Instance.OpenItemKindFilterUI((ushort) 10, (byte) 40, (byte) 0);
        break;
      case 9:
        this.RestSP();
        break;
      case 10:
        GamblingManager.Instance.bOpenTreasure = (byte) 1;
        GamblingManager.Instance.CloseMenu();
        this.CloseUI();
        break;
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public void UpdatePos(RectTransform Rect, RectTransform HintRect)
  {
    Vector2 anchoredPosition = ((RectTransform) ((Transform) Rect).parent.transform).anchoredPosition;
    HintRect.anchoredPosition = new Vector2(anchoredPosition.x - 18f, anchoredPosition.y + 197f);
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!bOnSecond)
      return;
    if ((double) this.ShowPrizeTime > 0.0)
      --this.ShowPrizeTime;
    else
      this.ShowPrizeTime = 0.0f;
    if ((double) this.CDTime > 0.0)
    {
      --this.CDTime;
    }
    else
    {
      this.CDTime = 10f;
      GamblingManager.Instance.Send_MSG_REQUEST_GAMBLE_PRIZE();
    }
    if ((double) this.RandIdleTime > 0.0)
    {
      --this.RandIdleTime;
    }
    else
    {
      this.RandNpcIdle();
      this.RandIdleTime = 10f;
    }
    this.UpdateTime();
  }

  public override bool OnBackButtonClick()
  {
    this.OnButtonClick(this.btn_EXIT);
    return false;
  }

  private void Update()
  {
    if (this.TextDisplayTime.HasValue)
    {
      UIBattle_Gambling uiBattleGambling = this;
      float? textDisplayTime = uiBattleGambling.TextDisplayTime;
      uiBattleGambling.TextDisplayTime = !textDisplayTime.HasValue ? new float?() : new float?(textDisplayTime.Value - Time.deltaTime);
      if ((double) this.TextDisplayTime.Value <= 0.0)
      {
        this.UpdateUI(20, 0);
        this.TextDisplayTime = new float?();
      }
    }
    if (!this.bOpenEnd)
      return;
    if (!this.ABIsDone && this.AR != null && this.AR.isDone)
    {
      this.go2 = (GameObject) UnityEngine.Object.Instantiate(this.AR.asset);
      this.go2.transform.SetParent(this.Hero_Pos, false);
      this.go2.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
      {
        eulerAngles = new Vector3(11.9199f, 157.7f, 355.7f)
      };
      this.go2.transform.localScale = new Vector3(245f, 245f, 245f);
      this.go2.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      GUIManager.Instance.SetLayer(this.go2, 5);
      this.Tmp = this.Hero_Pos.GetChild(0);
      this.Hero_Model = this.Tmp.GetComponent<Transform>();
      if ((UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null)
      {
        this.tmpAN = this.Hero_Model.GetComponent<Animation>();
        this.tmpAN.wrapMode = WrapMode.Default;
        this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
        this.tmpAN[this.NpcActStr[0]].layer = 0;
        this.tmpAN[this.NpcActStr[6]].layer = 0;
        this.tmpAN[this.NpcActStr[1]].layer = 1;
        this.tmpAN[this.NpcActStr[2]].layer = 1;
        this.tmpAN[this.NpcActStr[3]].layer = 1;
        this.tmpAN[this.NpcActStr[4]].layer = 2;
        this.tmpAN[this.NpcActStr[5]].layer = 2;
        this.tmpAN[this.NpcActStr[0]].wrapMode = WrapMode.Loop;
        this.tmpAN[this.NpcActStr[6]].wrapMode = WrapMode.Loop;
        if (this.bFreeMode)
          this.SetNpcAnim(UIBattle_Gambling.NpcAct.v_idle);
        else
          this.SetNpcAnim(UIBattle_Gambling.NpcAct.idle);
        if (this.Hero_Pos.gameObject.activeSelf)
        {
          SkinnedMeshRenderer componentInChildren = this.Hero_Model.GetComponentInChildren<SkinnedMeshRenderer>();
          componentInChildren.useLightProbes = false;
          componentInChildren.updateWhenOffscreen = true;
        }
      }
      this.ABIsDone = true;
    }
    if (!this.ABIsDone_Prize && this.Prize_AR != null && this.Prize_AR.isDone)
    {
      this.go = (GameObject) UnityEngine.Object.Instantiate(this.Prize_AR.asset);
      this.go.transform.SetParent(this.PrizePos3D, false);
      this.go.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
      {
        eulerAngles = new Vector3(26f, 180f, -4.7101f)
      };
      this.go.transform.localScale = new Vector3(450f, 450f, 450f);
      this.go.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      GUIManager.Instance.SetLayer(this.go, 5);
      this.Prize_Modle = this.PrizePos3D.GetChild(0).GetComponent<Transform>();
      if ((UnityEngine.Object) this.Prize_Modle != (UnityEngine.Object) null)
      {
        if (this.PrizePos3D.gameObject.activeSelf)
        {
          SkinnedMeshRenderer componentInChildren = this.Prize_Modle.GetComponentInChildren<SkinnedMeshRenderer>();
          componentInChildren.useLightProbes = false;
          componentInChildren.updateWhenOffscreen = true;
        }
        if (GamblingManager.Instance.IsSpecialType(GamblingManager.Instance.GambleMode))
          GamblingManager.Instance.m_GambleBoxAnim = GambleBoxAnim.status_3;
        if (GamblingManager.Instance.m_GambleBoxAnim != GambleBoxAnim.None)
          this.SetGambleBoxAnim(GamblingManager.Instance.m_GambleBoxAnim);
      }
      this.ABIsDone_Prize = true;
    }
    this.UpdateSP();
    this.UpdateCombo();
    if (this.bNpcAttackVictory)
      this.SetNpcAnim(UIBattle_Gambling.NpcAct.victory);
    this.mShitfHelper.Update();
  }

  private void SpawnString()
  {
    for (int index = 0; index < this.mStr.Length; ++index)
      this.mStr[index] = StringManager.Instance.SpawnString();
    this.mStrComboCount = StringManager.Instance.SpawnString();
  }

  private void DeSpawnString()
  {
    for (int index = 0; index < this.mStr.Length; ++index)
    {
      if (this.mStr[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.mStr[index]);
        this.mStr[index] = (CString) null;
      }
    }
    if (this.mStrComboCount == null)
      return;
    StringManager.Instance.DeSpawnString(this.mStrComboCount);
  }

  private void InitUI()
  {
    this.GUIM = GUIManager.Instance;
    this.TTFont = this.GUIM.GetTTFFont();
    this.GameT = this.gameObject.transform;
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      ((RectTransform) this.GameT).offsetMin = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.GameT).offsetMax = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    this.alertBlock = this.GameT.GetChild(0);
    this.P_T = this.GameT.GetChild(1);
    this.SPBgTF = this.GameT.GetChild(3);
    this.SPT = this.GameT.GetChild(3).GetChild(0);
    this.ComboT = this.GameT.GetChild(2);
    this.BGT = this.GameT.GetChild(4);
    this.RunningText = this.GameT.GetChild(5).GetComponent<UIRunningTextEX>();
    this.InputOff = this.GameT.GetChild(6);
    this.InputOff.gameObject.SetActive(false);
    this.DimPanle = this.GameT.GetChild(7);
    this.IPhoneXPanel = this.GameT.GetChild(8);
    if (GUIManager.Instance.bOpenOnIPhoneX)
      this.IPhoneXPanel.gameObject.SetActive(true);
    this.textDimPanle = this.DimPanle.GetChild(0).GetChild(1).GetComponent<UIText>();
    this.textDimPanle.font = this.TTFont;
    this.btnDimPanle = this.DimPanle.GetChild(0).GetChild(2).GetComponent<UIButton>();
    this.btnDimPanle.m_Handler = (IUIButtonClickHandler) this;
    this.btnDimPanle.m_BtnID1 = 10;
    this.btn_SP = this.GameT.GetChild(3).GetComponent<UIButton>();
    this.btn_SP.m_Handler = (IUIButtonClickHandler) this;
    this.btn_SP.m_BtnID1 = 9;
    this.DimPanle.SetParent((Transform) GUIManager.Instance.m_WindowsTransform, false);
    this.UpdateMoney();
    this.alertBlock_T = this.alertBlock.GetChild(0).GetComponent<Image>();
    this.alertBlock_B = this.alertBlock.GetChild(1).GetComponent<Image>();
    this.alertBlock_R = this.alertBlock.GetChild(2).GetComponent<Image>();
    this.alertBlock_L = this.alertBlock.GetChild(3).GetComponent<Image>();
    this.BGT.SetParent((Transform) GUIManager.Instance.m_WindowsTransform);
    this.BGT.localRotation = Quaternion.identity;
    this.BGT.localScale = Vector3.one;
    this.BGT.localPosition = Vector3.zero;
    int num1 = -1;
    if ((UnityEngine.Object) GUIManager.Instance.m_ChatBox != (UnityEngine.Object) null)
      num1 = ((Transform) GUIManager.Instance.m_ChatBox).GetSiblingIndex();
    if (num1 != -1)
      this.BGT.SetSiblingIndex(num1);
    ((Transform) this.P_T.GetComponent<RectTransform>()).localPosition = new Vector3(0.0f, 0.0f, 2000f);
    this.mSpArray = this.GameT.GetComponent<UISpritesArray>();
    this.btn_Hint = this.P_T.GetChild(1).GetComponent<UIButton>();
    this.btn_Hint.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Hint.m_BtnID1 = 1;
    this.btn_Hint2 = this.P_T.GetChild(2).GetComponent<UIButton>();
    this.btn_Hint2.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Hint2.m_BtnID1 = 2;
    this.btn_Hint.m_EffectType = e_EffectType.e_Scale;
    this.btn_Hint.transition = (Selectable.Transition) 0;
    float num2 = Mathf.Clamp((float) ((double) Mathf.Clamp(((RectTransform) ((Component) this.GUIM.m_UICanvas).transform).sizeDelta.x - 853f, 0.0f, 1920f) * 0.076999999582767487 + 146.0), 146f, 233f);
    Vector2 sizeDelta = this.P_T.GetChild(2).GetComponent<RectTransform>().sizeDelta with
    {
      x = num2
    };
    this.P_T.GetChild(2).GetComponent<RectTransform>().sizeDelta = sizeDelta;
    this.Img_Hint2 = this.P_T.GetChild(2).GetComponent<Image>();
    this.Img_Hint2Flash = this.P_T.GetChild(2).GetChild(0).GetComponent<Image>();
    this.text_Hint = this.P_T.GetChild(2).GetChild(2).GetComponent<UIText>();
    this.text_Hint.font = this.TTFont;
    this.text_Hint2 = this.P_T.GetChild(2).GetChild(3).GetComponent<UIText>();
    this.text_Hint2.font = this.TTFont;
    this.text_Hint2.text = DataManager.Instance.mStringTable.GetStringByID(94U);
    this.Img_Hint2_Black = this.P_T.GetChild(2).GetChild(4).GetComponent<Image>();
    this.btn_ItemList = this.P_T.GetChild(3).GetComponent<UIButton>();
    this.btn_ItemList.m_Handler = (IUIButtonClickHandler) this;
    this.btn_ItemList.m_BtnID1 = 6;
    this.ImgPrize = this.P_T.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
    this.textPrize = this.P_T.GetChild(3).GetChild(0).GetChild(0).GetChild(1).GetComponent<UIText>();
    this.textPrize.font = this.TTFont;
    this.Hero_Pos = this.P_T.GetChild(5);
    this.Particle_Pos[0] = this.P_T.GetChild(6).GetChild(0);
    this.Particle_Pos[1] = this.P_T.GetChild(6).GetChild(1);
    this.Particle_Pos[4] = this.P_T.GetChild(6).GetChild(4);
    this.Particle_Pos[5] = this.P_T.GetChild(6).GetChild(5);
    this.Particle_Pos[2] = this.P_T.GetChild(6).GetChild(2);
    this.Particle_Pos[3] = this.P_T.GetChild(6).GetChild(3);
    this.Particle_Pos[1].gameObject.SetActive(false);
    this.Particle_Pos[4].gameObject.SetActive(false);
    this.Particle_Pos[5].gameObject.SetActive(false);
    this.Particle_Pos[2].gameObject.SetActive(false);
    this.Particle_Pos[3].gameObject.SetActive(false);
    this.EffectObj[0] = ParticleManager.Instance.Spawn((ushort) 408, this.Particle_Pos[0].transform, Vector3.zero, 1f, true);
    if ((UnityEngine.Object) this.EffectObj[0] != (UnityEngine.Object) null)
    {
      GUIManager.Instance.SetLayer(this.EffectObj[0], 5);
      this.EffectObj[0].transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    }
    this.EffectObj[1] = ParticleManager.Instance.Spawn((ushort) 409, this.Particle_Pos[1].transform, Vector3.zero, 1f, true);
    if ((UnityEngine.Object) this.EffectObj[1] != (UnityEngine.Object) null)
    {
      GUIManager.Instance.SetLayer(this.EffectObj[1], 5);
      this.EffectObj[1].transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    }
    this.EffectObj[2] = ParticleManager.Instance.Spawn((ushort) 413, this.Particle_Pos[2].transform, Vector3.zero, 1f, true);
    if ((UnityEngine.Object) this.EffectObj[2] != (UnityEngine.Object) null)
    {
      GUIManager.Instance.SetLayer(this.EffectObj[2], 5);
      this.EffectObj[2].transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    }
    this.EffectObj[3] = ParticleManager.Instance.Spawn((ushort) 415, this.Particle_Pos[3].transform, Vector3.zero, 1f, true);
    if ((UnityEngine.Object) this.EffectObj[3] != (UnityEngine.Object) null)
    {
      GUIManager.Instance.SetLayer(this.EffectObj[3], 5);
      this.EffectObj[3].transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    }
    this.EffectObj[4] = ParticleManager.Instance.Spawn((ushort) 417, this.Particle_Pos[4].transform, Vector3.zero, 1f, true);
    if ((UnityEngine.Object) this.EffectObj[4] != (UnityEngine.Object) null)
    {
      GUIManager.Instance.SetLayer(this.EffectObj[4], 5);
      this.EffectObj[4].transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    }
    this.EffectObj[4] = ParticleManager.Instance.Spawn((ushort) 418, this.Particle_Pos[5].transform, Vector3.zero, 1f, true);
    if ((UnityEngine.Object) this.EffectObj[4] != (UnityEngine.Object) null)
    {
      GUIManager.Instance.SetLayer(this.EffectObj[4], 5);
      this.EffectObj[4].transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    }
    this.PrizePos3D = this.P_T.GetChild(7);
    this.AB = AssetManager.GetAssetBundle("Role/Priest", out this.AssetKey);
    if ((UnityEngine.Object) this.AB != (UnityEngine.Object) null)
    {
      this.AR = this.AB.LoadAsync("Priest", typeof (GameObject));
      this.ABIsDone = false;
    }
    this.Prize_AB = AssetManager.GetAssetBundle("Role/gamblebox", out this.AssetKey2);
    if ((UnityEngine.Object) this.Prize_AB != (UnityEngine.Object) null)
    {
      this.Prize_AR = this.Prize_AB.LoadAsync("m", typeof (GameObject));
      this.ABIsDone_Prize = false;
    }
    this.Img_ChangeNormal = this.P_T.GetChild(8).GetComponent<Image>();
    this.Img_ChangeNormalFlash = this.P_T.GetChild(8).GetChild(0).GetComponent<Image>();
    this.btn_ChangeModel_Normal = this.P_T.GetChild(8).GetComponent<UIButton>();
    this.btn_ChangeModel_Normal.m_Handler = (IUIButtonClickHandler) this;
    this.btn_ChangeModel_Normal.m_BtnID1 = 3;
    this.btn_ChangeModel_Normal.m_EffectType = e_EffectType.e_Scale;
    this.btn_ChangeModel_Normal.transition = (Selectable.Transition) 0;
    this.text_ChangeModel_Normal = this.P_T.GetChild(8).GetChild(1).GetComponent<UIText>();
    this.text_ChangeModel_Normal.font = this.TTFont;
    this.text_ChangeModel_Normal.text = DataManager.Instance.mStringTable.GetStringByID(9169U);
    this.Img_ChangeTurbo = this.P_T.GetChild(9).GetComponent<Image>();
    this.Img_ChangeTurboFlash = this.P_T.GetChild(9).GetChild(0).GetComponent<Image>();
    this.btn_ChangeModel_Turbo = this.P_T.GetChild(9).GetComponent<UIButton>();
    this.btn_ChangeModel_Turbo.m_Handler = (IUIButtonClickHandler) this;
    this.btn_ChangeModel_Turbo.m_BtnID1 = 4;
    this.btn_ChangeModel_Turbo.m_EffectType = e_EffectType.e_Scale;
    this.btn_ChangeModel_Turbo.transition = (Selectable.Transition) 0;
    this.text_ChangeModel_Turbo = this.P_T.GetChild(9).GetChild(1).GetComponent<UIText>();
    this.text_ChangeModel_Turbo.font = this.TTFont;
    this.text_ChangeModel_Turbo.text = DataManager.Instance.mStringTable.GetStringByID(9170U);
    this.AlertPanel = this.P_T.GetChild(9).GetChild(2);
    for (int index = 0; index < this.btn_Item_Rect.Length; ++index)
      this.btn_Item_Rect[index] = this.P_T.GetChild(11).GetChild(index).GetComponent<RectTransform>();
    for (int index = 0; index < this.btn_Item.Length; ++index)
    {
      this.btn_Item[index] = this.P_T.GetChild(11).GetChild(index).GetChild(0).GetComponent<UIHIBtn>();
      this.GUIM.InitianHeroItemImg(((Component) this.btn_Item[index]).transform, eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
      this.text_ItmeNum[index] = this.P_T.GetChild(11).GetChild(index).GetChild(2).GetComponent<UIText>();
      this.text_ItmeNum[index].font = this.TTFont;
      UIButtonHint uiButtonHint1 = ((Component) this.btn_Item[index]).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint1.m_ForcePos = true;
      uiButtonHint1.m_HintPosHandler = (IUIUpdatePos) this;
      uiButtonHint1.m_HIBtnOffset = new Vector2(this.btn_Item_Rect[index].anchoredPosition.x - 49f, this.btn_Item_Rect[index].anchoredPosition.y + 228f);
      ((Component) this.btn_Item[index]).gameObject.name = "~";
      this.btn_Item2[index] = this.P_T.GetChild(11).GetChild(index).GetChild(1).GetComponent<UILEBtn>();
      UIButtonHint uiButtonHint2 = ((Component) this.btn_Item2[index]).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint2.m_eHint = EUIButtonHint.UILeBtn;
      uiButtonHint2.m_ForcePos = true;
      uiButtonHint2.m_HintPosHandler = (IUIUpdatePos) this;
      uiButtonHint2.m_HIBtnOffset = new Vector2(this.btn_Item_Rect[index].anchoredPosition.x - 49f, this.btn_Item_Rect[index].anchoredPosition.y + 228f);
      this.GUIM.InitLordEquipImg(((Component) this.btn_Item2[index]).transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      ((Component) this.btn_Item2[index]).gameObject.name = "~";
    }
    this.mShitfHelper.Init(this.btn_Item_Rect);
    this.btn_InfoBtn = this.P_T.GetChild(13).GetComponent<UIButton>();
    this.btn_InfoBtn.m_BtnID1 = 7;
    this.btn_InfoBtn.m_Handler = (IUIButtonClickHandler) this;
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform component = this.P_T.GetChild(13).GetComponent<RectTransform>();
      Vector2 anchoredPosition = component.anchoredPosition with
      {
        x = 51f
      };
      component.anchoredPosition = anchoredPosition;
      Vector3 localScale = ((Transform) component).localScale;
      localScale.x *= -1f;
      ((Transform) component).localScale = localScale;
    }
    this.mJackPotDataPanel = this.P_T.GetChild(14).gameObject;
    for (int index = 0; index < 3; ++index)
    {
      this.mJackPotUI[index].obj = this.P_T.GetChild(14).GetChild(0).GetChild(index).gameObject;
      this.mJackPotUI[index].Name = this.P_T.GetChild(14).GetChild(0).GetChild(index).GetChild(0).GetComponent<UIText>();
      this.mJackPotUI[index].Num = this.P_T.GetChild(14).GetChild(0).GetChild(index).GetChild(1).GetComponent<UIText>();
      this.mJackPotUI[index].Time = this.P_T.GetChild(14).GetChild(0).GetChild(index).GetChild(2).GetComponent<UIText>();
      this.mJackPotUI[index].Name.font = this.TTFont;
      this.mJackPotUI[index].Num.font = this.TTFont;
      this.mJackPotUI[index].Time.font = this.TTFont;
    }
    GamblingManager.Instance.m_ItemPos = this.btn_Item_Rect[0].anchoredPosition + new Vector2(31f, -31f);
    this.text_TimeValue = this.P_T.GetChild(12).GetChild(0).GetChild(1).GetComponent<UIText>();
    this.text_TimeValue.font = this.TTFont;
    this.text_CostValue = this.P_T.GetChild(12).GetChild(1).GetChild(1).GetComponent<UIText>();
    this.text_CostValue.font = this.TTFont;
    this.btn_Filter = this.P_T.GetChild(12).GetChild(1).GetChild(2).GetComponent<UIButton>();
    this.btn_Filter.m_BtnID1 = 8;
    this.btn_Filter.m_Handler = (IUIButtonClickHandler) this;
    this.Img_ItemListT = this.P_T.GetChild(16).GetComponent<Image>();
    this.mNpcHp = this.P_T.GetChild(18).gameObject;
    this.imgNpcHpSlider = this.P_T.GetChild(18).GetChild(0).GetChild(0).GetComponent<Image>();
    this.textNpcHpName = this.P_T.GetChild(18).GetChild(1).GetComponent<UIText>();
    this.textNpcHpName.font = this.TTFont;
    this.textNpcHpValue = this.P_T.GetChild(18).GetChild(2).GetComponent<UIText>();
    this.textNpcHpValue.font = this.TTFont;
    this.P_T.GetChild(13).GetComponent<Image>();
    if (this.GUIM.bOpenOnIPhoneX)
    {
      Image component = this.P_T.GetChild(19).GetComponent<Image>();
      if ((bool) (UnityEngine.Object) component)
        ((Behaviour) component).enabled = false;
    }
    this.btn_EXIT = this.P_T.GetChild(19).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.RunningText.m_RunningText1.font = this.TTFont;
    this.RunningText.m_RunningText2.font = this.TTFont;
    if ((DataManager.Instance.RoleAttr.PrizeFlag & 2U) > 0U)
      this.RunningText.CheckAddStr();
    this.ComboT.gameObject.SetActive(true);
    this.text_ComboCount = this.ComboT.GetChild(0).GetComponent<UIText>();
    this.text_ComboCount.font = this.TTFont;
    this.text_ComboCount.fontStyle = FontStyle.Italic;
    this.text_Combo = this.ComboT.GetChild(1).GetComponent<UIText>();
    this.text_Combo.font = this.TTFont;
    this.text_Combo.text = DataManager.Instance.mStringTable.GetStringByID(9185U);
    this.text_Combo.fontStyle = FontStyle.Italic;
    ((Graphic) this.text_Combo).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_Combo).rectTransform.anchoredPosition.x, -60f);
    ((Graphic) this.text_Combo).rectTransform.sizeDelta = new Vector2(200f, ((Graphic) this.text_Combo).rectTransform.sizeDelta.y);
    ((Component) this.text_ComboCount).gameObject.SetActive(false);
    ((Component) this.text_Combo).gameObject.SetActive(false);
    this.bOpenEnd = true;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 6);
  }

  private void InitSP()
  {
    float num = 0.0f;
    for (int index = 0; index < this.SPShowTiming.Length; ++index)
    {
      num += this.SPShowTiming[index];
      this.SPShowTiming[index] = num;
    }
    for (int index1 = 0; index1 < this.SPStrings.Length; ++index1)
    {
      int index2 = Mathf.Clamp(22 + index1, 22, 25);
      this.SPStrings[index1] = this.mStr[index2];
      if (this.SPStrings[index1] != null)
        this.SPStrings[index1].ClearString();
    }
    this.SPStrings[0].Append(DataManager.Instance.mStringTable.GetStringByID(9181U));
    this.SPName = this.SPT.GetChild(0).GetComponent<UIText>();
    this.SPName.font = this.TTFont;
    this.SPName.text = this.SPStrings[0].ToString();
    this.SPName.SetAllDirty();
    this.SPName.cachedTextGenerator.Invalidate();
    this.SPScore = this.SPT.GetChild(1).GetComponent<UIText>();
    this.SPScore.font = this.TTFont;
    this.SPStrings[1].IntToFormat((long) UIBattle_Gambling.SPScoreValue, bNumber: true);
    this.SPStrings[1].AppendFormat("{0}");
    this.SPScore.text = this.SPStrings[1].ToString();
    this.SPScore.SetAllDirty();
    this.SPScore.cachedTextGenerator.Invalidate();
    this.SPScoreFly = this.SPT.GetChild(2).GetComponent<UIText>();
    this.SPScoreFly.font = this.TTFont;
    this.SPStrings[2].IntToFormat((long) UIBattle_Gambling.SPScoreFlyValue, bNumber: true);
    this.SPStrings[2].AppendFormat("{0}");
    this.SPScoreFly.text = this.SPStrings[2].ToString();
    this.SPScoreFly.SetAllDirty();
    this.SPScoreFly.cachedTextGenerator.Invalidate();
    this.SPFly = ((Graphic) this.SPScoreFly).rectTransform;
    this.SPRank = this.SPT.GetChild(4).GetComponent<UIText>();
    this.SPBG = this.SPT.GetComponent<Image>();
    this.SPRankUpDown = this.SPT.GetChild(3).GetComponent<Image>();
    this.SPReady = true;
    this.SPShowTime = 0.0f;
    this.SPShowPhase = 0.0f;
    this.SPBgTF.gameObject.SetActive(false);
  }

  private void UpdateSP()
  {
    if (!this.ShowSP)
      return;
    this.SPShowTime += Time.smoothDeltaTime;
    if ((double) this.SPShowTime < (double) this.SPShowTiming[0])
    {
      if ((double) this.SPShowPhase < 1.0)
      {
        this.SPShowPhase = 1f;
        ((Component) this.SPBG).gameObject.SetActive(true);
        this.SPBgTF.gameObject.SetActive(true);
        ((Component) this.SPScoreFly).gameObject.SetActive(false);
        ((Component) this.SPRankUpDown).gameObject.SetActive(false);
        ((Component) this.SPBG).gameObject.SetActive(true);
        if (!GUIManager.Instance.IsArabic)
          ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (new Vector2(2f, 2f) * 0.6f);
        else
          ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (new Vector2(-2f, 2f) * 0.6f);
        this.SPName.text = this.SPStrings[0].ToString();
        this.SPName.SetAllDirty();
        this.SPName.cachedTextGenerator.Invalidate();
        this.SPStrings[1].ClearString();
        this.SPStrings[1].IntToFormat((long) UIBattle_Gambling.SPScoreValue, bNumber: true);
        this.SPStrings[1].AppendFormat("{0}");
        this.SPScore.text = this.SPStrings[1].ToString();
        this.SPScore.SetAllDirty();
        this.SPScore.cachedTextGenerator.Invalidate();
        this.SPStrings[2].ClearString();
        this.SPStrings[2].IntToFormat((long) UIBattle_Gambling.SPScoreFlyValue, bNumber: true);
        this.SPStrings[2].AppendFormat("{0}");
        this.SPScoreFly.text = this.SPStrings[2].ToString();
        this.SPScoreFly.SetAllDirty();
        this.SPScoreFly.cachedTextGenerator.Invalidate();
      }
      float num = Mathf.InverseLerp(0.0f, this.SPShowTiming[0], this.SPShowTime);
      ((Graphic) this.SPBG).color = ((Graphic) this.SPBG).color with
      {
        a = num * 0.8f
      };
      ((Graphic) this.SPName).color = ((Graphic) this.SPName).color with
      {
        a = num
      };
      ((Graphic) this.SPScore).color = Color.white with
      {
        a = num
      };
      this.Particle_Pos[3].gameObject.SetActive(true);
    }
    else if ((double) this.SPShowTime < (double) this.SPShowTiming[2])
    {
      Color color;
      if ((double) this.SPShowPhase < 2.0)
      {
        this.SPShowPhase = 2f;
        ((Component) this.SPScoreFly).gameObject.SetActive(true);
        this.SPStrings[3].ClearString();
        this.SPStrings[3].IntToFormat(Math.Abs((long) UIBattle_Gambling.SPRankChange), bNumber: true);
        this.SPStrings[3].AppendFormat("{0}");
        this.SPRank.text = this.SPStrings[3].ToString();
        this.SPRank.SetAllDirty();
        this.SPRank.cachedTextGenerator.Invalidate();
        if (UIBattle_Gambling.SPRankChange > 0U)
        {
          ((Component) this.SPRank).gameObject.SetActive(true);
          ((Component) this.SPRankUpDown).GetComponent<UISpritesArray>().SetSpriteIndex(0);
          ((Component) this.SPRankUpDown).gameObject.SetActive(true);
        }
        else if (UIBattle_Gambling.SPRankChange < 0U)
        {
          ((Component) this.SPRank).gameObject.SetActive(true);
          ((Component) this.SPRankUpDown).GetComponent<UISpritesArray>().SetSpriteIndex(1);
          ((Component) this.SPRankUpDown).gameObject.SetActive(true);
        }
        else
          ((Component) this.SPRank).gameObject.SetActive(false);
        color = Color.white with { a = 0.0f };
        ((Graphic) this.SPRank).color = color;
        ((Graphic) this.SPRankUpDown).color = color;
      }
      float num = Mathf.InverseLerp(this.SPShowTiming[2], this.SPShowTiming[1], this.SPShowTime);
      color = ((Graphic) this.SPScoreFly).color with
      {
        a = num
      };
      ((Graphic) this.SPScoreFly).color = color;
      ((Graphic) this.SPScoreFly).rectTransform.anchoredPosition = Vector2.Lerp(new Vector2(0.0f, -265f), ((Graphic) this.SPScore).rectTransform.anchoredPosition, Mathf.InverseLerp(this.SPShowTiming[0], this.SPShowTiming[2], this.SPShowTime));
    }
    else if ((double) this.SPShowTime < (double) this.SPShowTiming[3])
    {
      if ((double) this.SPShowPhase < 3.0)
      {
        this.SPShowPhase = 3f;
        ((Component) this.SPScoreFly).gameObject.SetActive(false);
        ((Graphic) this.SPScore).color = Color.yellow;
      }
      if (!GUIManager.Instance.IsArabic)
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (new Vector2(2f, 2f) * Mathf.Lerp(0.5f, 0.8f, Mathf.InverseLerp(this.SPShowTiming[2], this.SPShowTiming[3], this.SPShowTime)));
      else
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (new Vector2(-2f, 2f) * Mathf.Lerp(0.5f, 0.8f, Mathf.InverseLerp(this.SPShowTiming[2], this.SPShowTiming[3], this.SPShowTime)));
    }
    else if ((double) this.SPShowTime < (double) this.SPShowTiming[4])
    {
      if ((double) this.SPShowPhase < 4.0)
      {
        this.SPShowPhase = 4f;
        AudioManager.Instance.PlaySFX((ushort) 40050);
      }
      this.SPStrings[1].ClearString();
      this.SPStrings[1].IntToFormat((long) (int) Mathf.Lerp((float) UIBattle_Gambling.SPScoreValue, (float) (UIBattle_Gambling.SPScoreValue + UIBattle_Gambling.SPScoreFlyValue), Mathf.InverseLerp(this.SPShowTiming[3], this.SPShowTiming[4], this.SPShowTime)), bNumber: true);
      this.SPStrings[1].AppendFormat("{0}");
      this.SPScore.text = this.SPStrings[1].ToString();
      this.SPScore.SetAllDirty();
      this.SPScore.cachedTextGenerator.Invalidate();
    }
    else if ((double) this.SPShowTime < (double) this.SPShowTiming[5])
    {
      if ((double) this.SPShowPhase < 5.0)
      {
        this.SPShowPhase = 5f;
        this.SPStrings[1].ClearString();
        this.SPStrings[1].IntToFormat((long) (UIBattle_Gambling.SPScoreValue + UIBattle_Gambling.SPScoreFlyValue), bNumber: true);
        this.SPStrings[1].AppendFormat("{0}");
        this.SPScore.text = this.SPStrings[1].ToString();
        this.SPScore.SetAllDirty();
        this.SPScore.cachedTextGenerator.Invalidate();
        AudioManager.Instance.PlaySFX((ushort) 40049);
      }
      float num = Mathf.InverseLerp(this.SPShowTiming[4], this.SPShowTiming[5], this.SPShowTime);
      Color white = Color.white with { a = num };
      ((Graphic) this.SPRank).color = white;
      ((Graphic) this.SPRankUpDown).color = white;
      if (!GUIManager.Instance.IsArabic)
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (new Vector2(2f, 2f) * Mathf.Lerp(0.6f, 2f, Mathf.InverseLerp(this.SPShowTiming[4], this.SPShowTiming[5], this.SPShowTime)));
      else
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (new Vector2(-2f, 2f) * Mathf.Lerp(0.6f, 2f, Mathf.InverseLerp(this.SPShowTiming[4], this.SPShowTiming[5], this.SPShowTime)));
    }
    else if ((double) this.SPShowTime < (double) this.SPShowTiming[6])
    {
      ((Graphic) this.SPRankUpDown).rectTransform.anchoredPosition = new Vector2(-37f - this.SPScore.preferredWidth, ((Graphic) this.SPRankUpDown).rectTransform.anchoredPosition.y);
      if (!GUIManager.Instance.IsArabic)
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (new Vector2(2f, 2f) * Mathf.Lerp(2f, 1f, Mathf.InverseLerp(this.SPShowTiming[5], this.SPShowTiming[6], this.SPShowTime)));
      else
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (new Vector2(-2f, 2f) * Mathf.Lerp(2f, 1f, Mathf.InverseLerp(this.SPShowTiming[5], this.SPShowTiming[6], this.SPShowTime)));
    }
    else
    {
      if ((double) this.SPShowTime >= (double) this.SPShowTiming[7])
        return;
      if (!GUIManager.Instance.IsArabic)
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) new Vector2(2f, 2f);
      else
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) new Vector2(-2f, 2f);
    }
  }

  private void RestSP()
  {
    ((Component) this.SPBG).gameObject.SetActive(false);
    this.SPBgTF.gameObject.SetActive(false);
    this.ShowSP = false;
    this.SPShowTime = 0.0f;
    this.Particle_Pos[3].gameObject.SetActive(false);
  }

  private void UpdatePrizeText()
  {
    float num = (float) GamblingManager.Instance.m_GambleGameInfo.SmallCost / (float) GamblingManager.Instance.m_GambleGameInfo.BigCost;
    uint x = GamblingManager.Instance.GambleMode != UIBattle_Gambling.eMode.Normal ? GamblingManager.Instance.m_GambleGameInfo.Prize : (uint) ((double) GamblingManager.Instance.m_GambleGameInfo.Prize * (double) num);
    this.mStr[0].ClearString();
    this.mStr[0].IntToFormat((long) x, bNumber: true);
    this.mStr[0].AppendFormat("{0}");
    this.textPrize.text = this.mStr[0].ToString();
    this.textPrize.SetAllDirty();
    this.textPrize.cachedTextGeneratorForLayout.Invalidate();
    this.textPrize.cachedTextGenerator.Invalidate();
    this.SetCenterText(this.ImgPrize, this.textPrize, 221.7f);
  }

  private void AddItem()
  {
    if (!this.bOpenEnd)
      return;
    if (this.mItemList != null && GamblingManager.Instance.m_QueueGamebleItem.Count > 0)
    {
      CommonItemDataType commonItemDataType;
      commonItemDataType.ItemID = GamblingManager.Instance.m_QueueGamebleItem[0].ItemID;
      commonItemDataType.Num = GamblingManager.Instance.m_QueueGamebleItem[0].Num;
      commonItemDataType.ItemRank = GamblingManager.Instance.m_QueueGamebleItem[0].ItemRank;
      GamblingManager.Instance.m_QueueGamebleItem.RemoveAt(0);
      this.mItemList.Insert(0, commonItemDataType);
    }
    if (this.mItemList.Count >= 2)
      this.mShitfHelper.Start();
    this.UpdateItems();
  }

  private void UpdateItems()
  {
    if (!this.bOpenEnd || this.mItemList == null)
      return;
    int index1 = 0;
    if (this.mShitfHelper != null)
      index1 = this.mShitfHelper.GetAddItemIdx();
    int index2 = Mathf.Clamp(12 + index1, 12, 17);
    this.mStr[index2].ClearString();
    if (this.mItemList[0].Num > (ushort) 1)
    {
      this.mStr[index2].IntToFormat((long) this.mItemList[0].Num);
      if (this.GUIM.IsArabic)
        this.mStr[index2].AppendFormat("{0}X");
      else
        this.mStr[index2].AppendFormat("X{0}");
    }
    this.text_ItmeNum[index1].text = this.mStr[index2].ToString();
    this.text_ItmeNum[index1].SetAllDirty();
    this.text_ItmeNum[index1].cachedTextGenerator.Invalidate();
    bool flag = this.GUIM.IsLeadItem(DataManager.Instance.EquipTable.GetRecordByKey(this.mItemList[0].ItemID).EquipKind);
    ((Component) this.btn_Item_Rect[index1]).gameObject.SetActive(true);
    if (flag)
    {
      this.GUIM.ChangeLordEquipImg(((Component) this.btn_Item2[index1]).transform, this.mItemList[0].ItemID, this.mItemList[0].ItemRank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      ((Component) this.btn_Item[index1]).gameObject.SetActive(false);
      ((Component) this.btn_Item2[index1]).gameObject.SetActive(true);
    }
    else
    {
      this.GUIM.ChangeHeroItemImg(((Component) this.btn_Item[index1]).transform, eHeroOrItem.Item, this.mItemList[0].ItemID, (byte) 0, this.mItemList[0].ItemRank);
      ((Component) this.btn_Item[index1]).gameObject.SetActive(true);
      ((Component) this.btn_Item2[index1]).gameObject.SetActive(false);
    }
  }

  private void UpdateJackPotData()
  {
    if (!this.bOpenEnd || GamblingManager.Instance.m_GamebleJackpots == null)
      return;
    int count = GamblingManager.Instance.m_GamebleJackpots.Count;
    for (int index1 = 0; index1 < count && index1 < this.mJackPotUI.Length; ++index1)
    {
      int index2 = Mathf.Clamp(1 + index1, 1, 3);
      this.mStr[index2].ClearString();
      GameConstants.FormatRoleName(this.mStr[index2], GamblingManager.Instance.m_GamebleJackpots[index1].Name, GamblingManager.Instance.m_GamebleJackpots[index1].Tag, bCheckedNickname: (byte) 0, KingdomID: (int) GamblingManager.Instance.m_GamebleJackpots[index1].KingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID ? GamblingManager.Instance.m_GamebleJackpots[index1].KingdomID : (ushort) 0);
      this.mJackPotUI[index1].Name.text = this.mStr[index2].ToString();
      int index3 = Mathf.Clamp(7 + index1, 7, 9);
      this.mStr[index3].ClearString();
      DataManager.Instance.SetSBTime(DataManager.Instance.ServerTime - GamblingManager.Instance.m_GamebleJackpots[index1].WonTime, this.mStr[index3]);
      this.mJackPotUI[index1].Time.text = this.mStr[index3].ToString();
      int index4 = Mathf.Clamp(4 + index1, 4, 6);
      this.mStr[index4].ClearString();
      GameConstants.FormatResourceValue(this.mStr[index4], GamblingManager.Instance.m_GamebleJackpots[index1].PrizeWins);
      this.mJackPotUI[index1].Num.text = this.mStr[index4].ToString();
      this.mJackPotUI[index1].Name.SetAllDirty();
      this.mJackPotUI[index1].Name.cachedTextGenerator.Invalidate();
      this.mJackPotUI[index1].Num.SetAllDirty();
      this.mJackPotUI[index1].Num.cachedTextGenerator.Invalidate();
      this.mJackPotUI[index1].Time.SetAllDirty();
      this.mJackPotUI[index1].Time.cachedTextGenerator.Invalidate();
      this.mJackPotUI[index1].obj.SetActive(true);
    }
    if (count <= 0 || this.mJackPotDataPanel.gameObject.activeSelf)
      return;
    this.mJackPotDataPanel.gameObject.SetActive(true);
  }

  private void SetNpcHP(UIBattle_Gambling.eHpType type = UIBattle_Gambling.eHpType.Normal)
  {
    if (!this.bOpenEnd)
      return;
    this.mNpcHp.gameObject.SetActive(true);
    int index = Mathf.Clamp((int) GamblingManager.Instance.GambleMode, 0, GamblingManager.Instance.m_GambleGameInfo.GambleData.Length - 1);
    if (GamblingManager.Instance.m_GambleGameInfo.GambleData[index].Stage <= (byte) 10)
    {
      byte stage = (byte) (11U - (uint) GamblingManager.Instance.m_GambleGameInfo.GambleData[index].Stage);
      switch (type)
      {
        case UIBattle_Gambling.eHpType.Normal:
          this.SetNpcHpByStage(stage);
          break;
        case UIBattle_Gambling.eHpType.Full:
          this.SetNpcHpByStage((byte) 10);
          break;
        case UIBattle_Gambling.eHpType.Zero:
          this.SetNpcHpByStage((byte) 0);
          break;
      }
    }
    else
      this.mNpcHp.gameObject.SetActive(false);
  }

  private void SetNpcHpByStage(byte stage)
  {
    this.mStr[10].ClearString();
    float num = (float) stage / 10f;
    if ((double) num >= 9.9999997473787516E-05)
      this.mStr[10].FloatToFormat(num * 100f, 2);
    else if ((double) num <= 0.0)
      this.mStr[10].FloatToFormat(0.0f);
    else
      this.mStr[10].FloatToFormat(0.01f);
    this.mStr[10].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(884U));
    ((Graphic) this.imgNpcHpSlider).rectTransform.sizeDelta = new Vector2(338f * num, 16f);
    this.textNpcHpValue.text = this.mStr[10].ToString();
    this.textNpcHpValue.SetAllDirty();
    this.textNpcHpValue.cachedTextGenerator.Invalidate();
  }

  private void SetNpcName()
  {
    if (!this.bOpenEnd)
      return;
    Mathf.Clamp((int) GamblingManager.Instance.GambleMode, 0, GamblingManager.Instance.m_GambleGameInfo.GambleData.Length - 1);
    ushort monsterId = GamblingManager.Instance.m_GambleEventSave.MonsterID;
    this.mStr[11].ClearString();
    MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(monsterId);
    this.mStr[11].ClearString();
    this.mStr[11].StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.NameID));
    this.mStr[11].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9168U));
    this.textNpcHpName.text = this.mStr[11].ToString();
    this.textNpcHpName.SetAllDirty();
    this.textNpcHpName.cachedTextGenerator.Invalidate();
  }

  private void UpdateBtnSprite()
  {
    if (!this.bOpenEnd)
      return;
    if (GamblingManager.Instance.GambleMode == UIBattle_Gambling.eMode.Normal)
    {
      this.btn_ChangeModel_Normal.image.sprite = this.mSpArray.GetSprite(0);
      this.btn_ChangeModel_Turbo.image.sprite = this.mSpArray.GetSprite(2);
      ((Component) this.Img_ChangeNormalFlash).gameObject.SetActive(true);
      ((Component) this.Img_ChangeTurboFlash).gameObject.SetActive(false);
    }
    else
    {
      this.btn_ChangeModel_Normal.image.sprite = this.mSpArray.GetSprite(0);
      this.btn_ChangeModel_Turbo.image.sprite = this.mSpArray.GetSprite(2);
      ((Component) this.Img_ChangeNormalFlash).gameObject.SetActive(false);
      ((Component) this.Img_ChangeTurboFlash).gameObject.SetActive(true);
    }
    this.CheckAlertType();
  }

  private void UpdateGambleCost(int arg = 0)
  {
    if (!this.bOpenEnd)
      return;
    uint cost = GamblingManager.Instance.GetCost();
    if (DataManager.Instance.RoleAttr.ScardStar < cost)
      this.btn_Hint2.ForTextChange(e_BtnType.e_ChangeText);
    else
      this.btn_Hint2.ForTextChange(e_BtnType.e_Normal);
    this.mStr[18].ClearString();
    if (cost == 0U)
    {
      this.mStr[18].Append(DataManager.Instance.mStringTable.GetStringByID(780U));
    }
    else
    {
      this.mStr[18].IntToFormat((long) cost, bNumber: true);
      this.mStr[18].AppendFormat("{0}");
    }
    this.text_Hint.text = this.mStr[18].ToString();
    this.text_Hint.SetAllDirty();
    this.text_Hint.cachedTextGenerator.Invalidate();
    this.Img_Hint2.sprite = this.mSpArray.GetSprite(4);
    ((Component) this.Img_Hint2Flash).gameObject.SetActive(false);
    if (cost == 0U)
    {
      if (GamblingManager.Instance.GetRemainFreePlay(GamblingManager.Instance.GambleMode) > (byte) 0)
      {
        this.Img_Hint2.sprite = this.mSpArray.GetSprite(5);
        this.Img_Hint2Flash.sprite = this.mSpArray.GetSprite(7);
        this.SetNpcParticleType(NpcParticleType.TypeS);
      }
      else if (GamblingManager.Instance.IsDailyFreeScardStar(GamblingManager.Instance.GambleMode))
      {
        this.Img_Hint2.sprite = this.mSpArray.GetSprite(4);
        this.Img_Hint2Flash.sprite = this.mSpArray.GetSprite(6);
      }
      ((Component) this.Img_Hint2Flash).gameObject.SetActive(true);
      if (GamblingManager.Instance.GetRemainFreePlay(GamblingManager.Instance.GambleMode) > (byte) 0)
      {
        if (!this.bFreeMode && this.ABIsDone && (UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null)
        {
          this.SetNpcAnim(UIBattle_Gambling.NpcAct.victory);
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 19, arg);
        }
        this.bFreeMode = true;
      }
      else if (GamblingManager.Instance.IsDailyFreeScardStar(GamblingManager.Instance.GambleMode))
        this.bFreeMode = false;
    }
    else
    {
      if (this.bFreeMode && this.ABIsDone && (UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null)
        this.SetNpcAnim(UIBattle_Gambling.NpcAct.idle);
      this.bFreeMode = false;
    }
    this.mCount = (int) GamblingManager.Instance.mComboMax - (int) GamblingManager.Instance.GetRemainFreePlay(GamblingManager.Instance.GambleMode);
    if (this.mCount > 0 && !this.bfadeout)
      this.AddCombo();
    NewbieManager.CheckGambleElite();
  }

  private void SetBtnType(UIBattle_Gambling.eMode m)
  {
    if (!this.bOpenEnd)
      return;
    if (m == UIBattle_Gambling.eMode.Normal)
    {
      GamblingManager.Instance.GambleMode = UIBattle_Gambling.eMode.Normal;
      GamblingManager.Instance.saveGambleMode();
      BattleNetwork.RefreshGambleMode(EGambleMode.Normal);
    }
    else
    {
      GamblingManager.Instance.GambleMode = UIBattle_Gambling.eMode.Turbo;
      GamblingManager.Instance.saveGambleMode();
      BattleNetwork.RefreshGambleMode(EGambleMode.Turbo);
    }
  }

  private void UpdateCurCostValue()
  {
    if (!this.bOpenEnd)
      return;
    this.mStr[20].ClearString();
    GameConstants.FormatResourceValue(this.mStr[20], DataManager.Instance.RoleAttr.ScardStar);
    this.text_CostValue.text = this.mStr[20].ToString();
    this.text_CostValue.SetAllDirty();
    this.text_CostValue.cachedTextGenerator.Invalidate();
  }

  private void UpdateTime()
  {
    if (!this.bOpenEnd)
      return;
    long num = GamblingManager.Instance.m_GambleEventSave.BeginTime + (long) GamblingManager.Instance.m_GambleEventSave.RequireTime;
    long sec = num <= DataManager.Instance.ServerTime ? 0L : num - DataManager.Instance.ServerTime;
    this.mStr[19].ClearString();
    GameConstants.GetTimeString(this.mStr[19], (uint) sec, hideTimeIfDays: true, showZeroHour: false);
    this.text_TimeValue.text = this.mStr[19].ToString();
    this.text_TimeValue.SetAllDirty();
    this.text_TimeValue.cachedTextGenerator.Invalidate();
  }

  private void SetGambleBoxAnim(GambleBoxAnim boxAnim)
  {
    if (!this.bOpenEnd)
      return;
    int index = 0;
    switch (boxAnim)
    {
      case GambleBoxAnim.idle:
        index = 0;
        break;
      case GambleBoxAnim.status_1:
        index = 1;
        break;
      case GambleBoxAnim.status_2:
        index = 2;
        break;
      case GambleBoxAnim.status_3:
        index = 3;
        break;
    }
    this.SetPrize_ModleAnim(this.anim[index]);
  }

  private void RandGambleBoxAnim(GambleBoxAnim boxAnim)
  {
    if (!this.bOpenEnd || this.bSpecialNpc)
      return;
    int index1 = 0;
    switch (boxAnim)
    {
      case GambleBoxAnim.None:
      case GambleBoxAnim.idle:
        this.anim_Idx = this.animR_Idle_Idx;
        this.anim_R = this.animR_Idle;
        break;
      case GambleBoxAnim.status_1:
        this.anim_R = this.animR_S1;
        this.anim_Idx = this.animR_S1_Idx;
        break;
      case GambleBoxAnim.status_2:
        this.anim_Idx = this.animR_S2_Idx;
        this.anim_R = this.animR_S2;
        break;
      case GambleBoxAnim.status_3:
        this.anim_Idx = this.animR_S3_Idx;
        this.anim_R = this.animR_S3;
        break;
    }
    if (!((UnityEngine.Object) this.Prize_Modle != (UnityEngine.Object) null))
      return;
    int num1 = UnityEngine.Random.Range(1, 101);
    int num2 = 1;
    int num3 = 1;
    this.debugIdx = num1;
    for (int index2 = 0; index2 < this.anim_Idx.Length; ++index2)
    {
      num3 += this.anim_R[index2];
      if (num1 >= num2 && num1 < num3)
      {
        index1 = this.anim_Idx[index2];
        break;
      }
      num2 = num3;
    }
    this.SetPrize_ModleAnim(this.anim[index1]);
  }

  private void SetPrize_ModleAnim(string animStr)
  {
    if (!((UnityEngine.Object) this.Prize_Modle != (UnityEngine.Object) null))
      return;
    this.tmpAN_Prize = this.Prize_Modle.GetComponent<Animation>();
    if ((UnityEngine.Object) this.tmpAN_Prize != (UnityEngine.Object) null)
    {
      this.tmpAN_Prize.wrapMode = WrapMode.Loop;
      this.tmpAN_Prize[animStr].layer = 1;
      this.tmpAN_Prize[animStr].wrapMode = WrapMode.Loop;
      this.tmpAN_Prize.CrossFade(animStr);
      this.tmpAN_Prize.clip = this.tmpAN_Prize.GetClip(animStr);
    }
    if (string.Compare(animStr, this.anim[0]) == 0)
    {
      GamblingManager.Instance.m_GambleBoxAnim = GambleBoxAnim.idle;
      this.Particle_Pos[2].gameObject.SetActive(false);
    }
    else
    {
      if (string.Compare(animStr, this.anim[1]) == 0)
        GamblingManager.Instance.m_GambleBoxAnim = GambleBoxAnim.status_1;
      if (string.Compare(animStr, this.anim[2]) == 0)
        GamblingManager.Instance.m_GambleBoxAnim = GambleBoxAnim.status_2;
      if (string.Compare(animStr, this.anim[3]) == 0)
        GamblingManager.Instance.m_GambleBoxAnim = GambleBoxAnim.status_3;
      this.Particle_Pos[2].gameObject.SetActive(true);
    }
  }

  private void SetNpcParticleType(NpcParticleType type)
  {
    switch (type)
    {
      case NpcParticleType.None:
        this.Particle_Pos[1].gameObject.SetActive(false);
        this.Particle_Pos[0].gameObject.SetActive(false);
        this.Particle_Pos[4].gameObject.SetActive(false);
        this.Particle_Pos[5].gameObject.SetActive(false);
        break;
      case NpcParticleType.Type1:
        if (!this.Particle_Pos[0].gameObject.activeSelf)
          this.Particle_Pos[0].gameObject.SetActive(true);
        this.Particle_Pos[1].gameObject.SetActive(false);
        this.Particle_Pos[4].gameObject.SetActive(false);
        this.Particle_Pos[5].gameObject.SetActive(false);
        break;
      case NpcParticleType.Type2:
        if (!this.Particle_Pos[4].gameObject.activeSelf)
          this.Particle_Pos[4].gameObject.SetActive(true);
        this.Particle_Pos[0].gameObject.SetActive(false);
        this.Particle_Pos[1].gameObject.SetActive(false);
        this.Particle_Pos[5].gameObject.SetActive(false);
        break;
      case NpcParticleType.Type3:
        if (!this.Particle_Pos[5].gameObject.activeSelf)
          this.Particle_Pos[5].gameObject.SetActive(true);
        this.Particle_Pos[0].gameObject.SetActive(false);
        this.Particle_Pos[1].gameObject.SetActive(false);
        this.Particle_Pos[4].gameObject.SetActive(false);
        break;
      case NpcParticleType.TypeS:
        if (!this.Particle_Pos[1].gameObject.activeSelf)
          this.Particle_Pos[1].gameObject.SetActive(true);
        this.Particle_Pos[0].gameObject.SetActive(false);
        this.Particle_Pos[4].gameObject.SetActive(false);
        this.Particle_Pos[5].gameObject.SetActive(false);
        break;
    }
    GamblingManager.Instance.m_NpcParticleType = type;
  }

  private void RandNpcParticleType()
  {
    if (!this.bOpenEnd)
      return;
    int num1 = 0;
    if (GamblingManager.Instance.m_NpcParticleType == NpcParticleType.None)
    {
      this.anim_Idx = this.animR_Idle_Idx;
      this.anim_R = this.animR_Idle;
    }
    else if (GamblingManager.Instance.m_NpcParticleType == NpcParticleType.Type1)
    {
      this.anim_Idx = this.animR_S1_Idx;
      this.anim_R = this.animR_S1;
    }
    else if (GamblingManager.Instance.m_NpcParticleType == NpcParticleType.Type2)
    {
      this.anim_Idx = this.animR_S2_Idx;
      this.anim_R = this.animR_S2;
    }
    else if (GamblingManager.Instance.m_NpcParticleType == NpcParticleType.Type3)
    {
      this.anim_Idx = this.animR_S3_Idx;
      this.anim_R = this.animR_S3;
    }
    int num2 = UnityEngine.Random.Range(1, 101);
    int num3 = 1;
    int num4 = 1;
    this.debugIdx_P = num2;
    for (int index = 0; index < this.anim_Idx.Length; ++index)
    {
      num4 += this.anim_R[index];
      if (num2 >= num3 && num2 < num4)
      {
        num1 = this.anim_Idx[index];
        break;
      }
      num3 = num4;
    }
    switch (num1)
    {
      case 0:
        this.SetNpcParticleType(NpcParticleType.None);
        break;
      case 1:
        this.SetNpcParticleType(NpcParticleType.Type1);
        break;
      case 2:
        this.SetNpcParticleType(NpcParticleType.Type2);
        break;
      case 3:
        this.SetNpcParticleType(NpcParticleType.Type3);
        break;
    }
    if (BattleController.GambleMode == EGambleMode.Normal)
      AudioManager.Instance.PlaySFX(DataManager.Instance.SkillTable.GetRecordByKey((ushort) 858).HitSound);
    else
      AudioManager.Instance.PlaySFX(DataManager.Instance.SkillTable.GetRecordByKey((ushort) 859).HitSound);
  }

  private void UpdateJackPot_Self()
  {
    if (!this.bOpenEnd)
      return;
    this.ShowSP = true;
    this.SPShowPhase = 0.0f;
    UIBattle_Gambling.SPRankChange = 2U;
    this.SPShowTime = 0.0f;
    UIBattle_Gambling.SPScoreValue = 0U;
    if (GamblingManager.Instance.m_GamebleJackpots.Count > 0)
    {
      UIBattle_Gambling.SPScoreFlyValue = GamblingManager.Instance.m_GamebleJackpots[0].PrizeWins;
      AudioManager.Instance.PlaySFX((ushort) 41026);
    }
    this.SPT.gameObject.SetActive(true);
    this.ShowPrizeTime = 3f;
  }

  private void SendUse()
  {
    if (!this.bOpenEnd || !this.ABIsDone || !((UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null) || this.tmpAN.IsPlaying(this.NpcActStr[4]))
      return;
    this.mNpcAct = UIBattle_Gambling.NpcAct.attack;
    if ((UnityEngine.Object) this.tmpAN.GetClip(this.mNpcAct.ToString()) != (UnityEngine.Object) null)
      this.SetNpcAnim(this.mNpcAct);
    GamblingManager.Instance.Send_MSG_REQUEST_GAMBLE_STARTGAME((byte) GamblingManager.Instance.GambleMode);
    if (GamblingManager.Instance.m_GambleBoxAnim == GambleBoxAnim.None || GamblingManager.Instance.m_GambleBoxAnim == GambleBoxAnim.idle)
      this.RandGambleBoxAnim(GamblingManager.Instance.m_GambleBoxAnim);
    else if (GamblingManager.Instance.m_GambleBoxAnim == GambleBoxAnim.status_1)
      this.RandGambleBoxAnim(GamblingManager.Instance.m_GambleBoxAnim);
    else if (GamblingManager.Instance.m_GambleBoxAnim == GambleBoxAnim.status_2)
      this.RandGambleBoxAnim(GamblingManager.Instance.m_GambleBoxAnim);
    else if (GamblingManager.Instance.m_GambleBoxAnim == GambleBoxAnim.status_3)
      this.RandGambleBoxAnim(GamblingManager.Instance.m_GambleBoxAnim);
    this.RandNpcParticleType();
  }

  private void OpennFilterUI()
  {
    CString cstring1 = StringManager.Instance.StaticString1024();
    CString cstring2 = StringManager.Instance.StaticString1024();
    cstring1.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9642U));
    cstring1.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(1545U));
    cstring2.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9642U));
    cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(1546U));
    this.GUIM.OpenMessageBox(cstring1.ToString(), cstring2.ToString(), DataManager.Instance.mStringTable.GetStringByID(5723U), (GUIWindow) this, 1, bCloseIDSet: true);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || arg1 != 1)
      return;
    GUIManager.Instance.OpenItemKindFilterUI((ushort) 10, (byte) 40, (byte) 0);
  }

  private void SetNpcName(CString str)
  {
    str.ClearString();
    Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(DataManager.Instance.TeamTable.GetRecordByKey(DataManager.MapDataController.MapMonsterTable.GetRecordByKey(GamblingManager.Instance.BattleMonsterID).MapTeamInfo[0].TeamID).Arrays[10].Hero);
    str.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.HeroName));
  }

  private void SetCenterText(Image image, UIText text, float width)
  {
    if (!this.bOpenEnd)
      return;
    float num = 10f;
    float x = (float) (((double) width - ((double) ((Graphic) image).rectTransform.sizeDelta.x + (double) text.preferredWidth + (double) num)) / 2.0);
    ((Graphic) image).rectTransform.anchoredPosition = new Vector2(x, ((Graphic) image).rectTransform.anchoredPosition.y);
    ((Graphic) text).rectTransform.anchoredPosition = new Vector2(((Graphic) image).rectTransform.anchoredPosition.x + ((Graphic) image).rectTransform.sizeDelta.x + num, ((Graphic) text).rectTransform.anchoredPosition.y);
    text.UpdateArabicPos();
  }

  public void CloseUI()
  {
    if (!this.bOpenEnd)
      return;
    this.GUIM.CloseMenu(EGUIWindow.UI_Battle_Gambling);
    this.GUIM.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
  }

  private void SetInputOff(bool bOff)
  {
    if (!this.bOpenEnd)
      return;
    this.InputOff.gameObject.SetActive(bOff);
    ((Component) this.Img_Hint2_Black).gameObject.SetActive(bOff);
  }

  private void AddCombo()
  {
    ((Component) this.text_ComboCount).gameObject.SetActive(true);
    ((Component) this.text_Combo).gameObject.SetActive(true);
    ((Graphic) this.text_ComboCount).color = new Color(1f, 0.89f, 0.38f, 1f);
    ((Graphic) this.text_Combo).color = new Color(1f, 0.89f, 0.38f, 1f);
    this.mStatus = 1;
    this.mComboTime = 0.0f;
    this.text_ComboCount.resizeTextMaxSize = 150;
    ((Graphic) this.text_ComboCount).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_ComboCount).rectTransform.anchoredPosition.x, 0.0f);
    StringManager.IntToStr(this.mStrComboCount, (long) this.mCount);
    this.text_ComboCount.text = this.mStrComboCount.ToString();
    this.text_ComboCount.SetAllDirty();
    this.text_ComboCount.cachedTextGenerator.Invalidate();
    this.text_Combo.resizeTextMaxSize = 45;
    this.mtextHeight = this.text_Combo.preferredHeight;
    if (this.mCount != (int) GamblingManager.Instance.mComboMax)
      return;
    this.bfadeout = true;
    GamblingManager.Instance.mComboMax = (byte) 0;
    this.mCount = 0;
  }

  private void UpdateCombo()
  {
    if (this.mStatus <= 0 || !((UnityEngine.Object) this.text_ComboCount != (UnityEngine.Object) null) || !((UnityEngine.Object) this.text_Combo != (UnityEngine.Object) null))
      return;
    if (this.mStatus == 1)
    {
      if ((double) this.mComboTime <= 0.05000000074505806)
      {
        this.mComboTime += Time.smoothDeltaTime;
        float t = this.mComboTime / 0.05f;
        float num1 = Mathf.Lerp(0.39f, 1f, t);
        if (this.GUIM.IsArabic)
          ((Transform) ((Graphic) this.text_ComboCount).rectTransform).localScale = new Vector3(-num1, num1, num1);
        else
          ((Transform) ((Graphic) this.text_ComboCount).rectTransform).localScale = new Vector3(num1, num1, num1);
        float num2 = Mathf.Lerp(0.32f, 1f, t);
        if (this.GUIM.IsArabic)
          ((Transform) ((Graphic) this.text_Combo).rectTransform).localScale = new Vector3(-num2, num2, num2);
        else
          ((Transform) ((Graphic) this.text_Combo).rectTransform).localScale = new Vector3(num2, num2, num2);
        ((Graphic) this.text_ComboCount).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_ComboCount).rectTransform.anchoredPosition.x, Mathf.Lerp(0.0f, 20f, t));
      }
      else
      {
        this.mStatus = 2;
        this.mtextHeight = this.text_Combo.preferredHeight;
        this.mtextTopHeight = ((Graphic) this.text_ComboCount).rectTransform.anchoredPosition.y;
        this.mComboTime = 0.0f;
      }
    }
    else if (this.mStatus == 2)
    {
      if ((double) this.mComboTime <= 0.20000000298023224)
      {
        this.mComboTime += Time.smoothDeltaTime;
        float t = this.mComboTime / 0.2f;
        float num3 = Mathf.Lerp(1f, 0.6f, t);
        if (this.GUIM.IsArabic)
          ((Transform) ((Graphic) this.text_ComboCount).rectTransform).localScale = new Vector3(-num3, num3, num3);
        else
          ((Transform) ((Graphic) this.text_ComboCount).rectTransform).localScale = new Vector3(num3, num3, num3);
        float num4 = Mathf.Lerp(1f, 0.67f, t);
        if (this.GUIM.IsArabic)
          ((Transform) ((Graphic) this.text_Combo).rectTransform).localScale = new Vector3(-num4, num4, num4);
        else
          ((Transform) ((Graphic) this.text_Combo).rectTransform).localScale = new Vector3(num4, num4, num4);
        ((Graphic) this.text_ComboCount).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_ComboCount).rectTransform.anchoredPosition.x, Mathf.Lerp(20f, 0.0f, t));
      }
      else
      {
        this.mStatus = 3;
        this.mComboTime = 0.0f;
      }
    }
    else
    {
      if (this.mStatus != 3 || !this.bfadeout)
        return;
      if ((double) this.mComboTime < 2.0)
      {
        this.mComboTime += Time.smoothDeltaTime;
        ((Graphic) this.text_ComboCount).color = new Color(1f, 0.89f, 0.38f, 2f - this.mComboTime);
        ((Graphic) this.text_Combo).color = new Color(1f, 0.89f, 0.38f, 2f - this.mComboTime);
      }
      else
      {
        this.bfadeout = false;
        this.mStatus = 0;
        this.mComboTime = 0.0f;
        ((Component) this.text_ComboCount).gameObject.SetActive(false);
        ((Component) this.text_Combo).gameObject.SetActive(false);
      }
    }
  }

  private void UpdateMoney()
  {
    if (!((UnityEngine.Object) this.textDimPanle != (UnityEngine.Object) null))
      return;
    this.mStr[27].ClearString();
    GameConstants.FormatResourceValue(this.mStr[27], DataManager.Instance.RoleAttr.Diamond);
    this.textDimPanle.text = this.mStr[27].ToString();
    this.textDimPanle.SetAllDirty();
    this.textDimPanle.cachedTextGenerator.Invalidate();
  }

  private void CheckAlertType()
  {
    if (GamblingManager.Instance.GambleMode == UIBattle_Gambling.eMode.Normal)
    {
      if (GamblingManager.Instance.IsDailyFreeScardStar(UIBattle_Gambling.eMode.Turbo))
        this.AlertPanel.gameObject.SetActive(true);
      else
        this.AlertPanel.gameObject.SetActive(false);
    }
    else
      this.AlertPanel.gameObject.SetActive(false);
  }

  private void RandNpcIdle()
  {
    int act = UnityEngine.Random.Range(1, 4);
    if (this.Particle_Pos[1].gameObject.activeSelf)
      return;
    this.SetNpcAnim((UIBattle_Gambling.NpcAct) act);
  }

  private void SetNpcAnim(UIBattle_Gambling.NpcAct act)
  {
    if (!(bool) (UnityEngine.Object) this.tmpAN)
      return;
    switch (act)
    {
      case UIBattle_Gambling.NpcAct.idle:
        this.tmpAN.CrossFade(this.NpcActStr[(int) (byte) act]);
        this.tmpAN.clip = this.tmpAN.GetClip(this.NpcActStr[(int) (byte) act]);
        break;
      case UIBattle_Gambling.NpcAct.attack:
        this.RandIdleTime = 10f;
        this.tmpAN.CrossFade(this.NpcActStr[(int) (byte) act]);
        break;
      case UIBattle_Gambling.NpcAct.victory:
        if (this.tmpAN.IsPlaying(this.NpcActStr[4]))
        {
          this.bNpcAttackVictory = true;
          break;
        }
        this.bNpcAttackVictory = false;
        this.tmpAN.CrossFade(this.NpcActStr[5]);
        this.tmpAN.CrossFade(this.NpcActStr[6]);
        this.tmpAN.clip = this.tmpAN.GetClip(this.NpcActStr[6]);
        break;
      default:
        this.tmpAN.CrossFade(this.NpcActStr[(int) (byte) act]);
        break;
    }
    this.mNpcAct = act;
  }

  public void SetAlertImageAlpha(float Alpha)
  {
    if (GUIManager.Instance.m_AlertImageIndex != 0 || !((UnityEngine.Object) this.alertBlock != (UnityEngine.Object) null) || !this.alertBlock.gameObject.activeSelf)
      return;
    Color color = new Color(1f, 1f, 1f, Alpha);
    if ((UnityEngine.Object) this.alertBlock_T != (UnityEngine.Object) null)
      ((Graphic) this.alertBlock_T).color = color;
    if ((UnityEngine.Object) this.alertBlock_B != (UnityEngine.Object) null)
      ((Graphic) this.alertBlock_B).color = color;
    if ((UnityEngine.Object) this.alertBlock_L != (UnityEngine.Object) null)
      ((Graphic) this.alertBlock_L).color = color;
    if (!((UnityEngine.Object) this.alertBlock_R != (UnityEngine.Object) null))
      return;
    ((Graphic) this.alertBlock_R).color = color;
  }

  public void SetAlertBlock(bool bOpenAlertBlock)
  {
    this.alertBlock.gameObject.SetActive(bOpenAlertBlock);
  }

  private enum GUIGambling_btn
  {
    btn_EXIT,
    btn_Hint,
    btn_Hint2,
    btn_ChangeModel_Normal,
    btn_ChangeModel_Turbo,
    btn_GoldHint,
    btn_ItemList,
    btn_Info,
    btn_Filter,
    btn_SP,
    btn_Dim,
  }

  private enum eGamblingUI
  {
    ChangBg,
    btn_hit1,
    btn_hit2,
    btn_ItemList,
    DirectionalLight,
    HeroPos,
    ParticlePos,
    PrizePos3D,
    btn_chang,
    btn_chang2,
    Text_chang,
    ItemT,
    InfoImage,
    InofBtn,
    JackPotData,
    T_goldHint,
    Img_ItemList,
    Image,
    NpcHp,
    EXIT_BG,
  }

  private enum eGamblingStr
  {
    Prize,
    JackPotName1,
    JackPotName2,
    JackPotName3,
    JackPotNum1,
    JackPotNum2,
    JackPotNum3,
    JackPotTime1,
    JackPotTime2,
    JackPotTime3,
    NpcHPValue,
    NpcName,
    ItemNum1,
    ItemNum2,
    ItemNum3,
    ItemNum4,
    ItemNum5,
    ItemNum6,
    GambleCost,
    TimeValue,
    AllCostValue,
    MesgBox,
    SPStrings1,
    SPStrings2,
    SPStrings3,
    SPStrings4,
    MesgBox_NpcNmae,
    DimStr,
    Max,
  }

  private enum eBtnSprite
  {
    Normal_Off,
    Normal_On,
    Turbo_Off,
    Turbo_On,
    Btn_Yellow,
    Btn_Purple,
    Btn_Yellow_Flash,
    Btn_Purple_Flash,
  }

  public enum eMode
  {
    Turbo,
    Normal,
    Max,
  }

  private enum eHpType
  {
    Normal,
    Full,
    Zero,
  }

  private enum eParticle
  {
    eNpc01,
    eNpc02,
    eGamebleBox,
    eNpc03,
    eJackPot,
    eMax,
  }

  private enum ePlayType
  {
    Normal,
    Free,
    Special,
  }

  private enum ParticlePos
  {
    NpcPos1,
    NpcPos2,
    BoxPos1,
    JackPot,
    NpcPos3,
    NpcPos4,
    NpcMax,
  }

  private enum NpcAct
  {
    idle,
    idle02,
    idle03,
    idle04,
    attack,
    victory,
    v_idle,
  }

  private struct JackPotUI
  {
    public UIText Name;
    public UIText Num;
    public UIText Time;
    public GameObject obj;
  }
}
