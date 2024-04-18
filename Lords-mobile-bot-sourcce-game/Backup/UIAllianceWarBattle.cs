// Decompiled with JetBrains decompiler
// Type: UIAllianceWarBattle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIAllianceWarBattle : 
  GUIWindow,
  IActivityWindow,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private UIAllianceWarBattle.MoveStage MovieStage;
  private GameObject go;
  private GameObject Duke;
  private RectTransform Hero_PosRT;
  private Transform Tmp;
  private Transform Hero_Model;
  private Transform Hero_3D;
  private Transform Hero_Pos;
  private Transform HintButt;
  private Animation tmpAN;
  private ActivityWindow AW;
  private GameObject Autobot;
  private GameObject Decepticon;
  private GameObject DefeatEffect;
  private GameObject[] ParticleEffect = new GameObject[2];
  protected static double ReplayTime;
  protected static byte MatchID;
  private double PauseTime;
  private bool bDisabled;
  private bool PauseReplay;
  private bool BattleReplay;
  private byte BattlePosition;
  private byte BattleSide;
  private byte BattleFight;
  private byte BattleRound;
  private byte LastWinner;
  private double PassTime;
  private double NextTime;
  private double BattleTime;
  private ushort BattleWait;
  private ushort BattlePrepare;
  private uint BattleRoundTime;
  private uTweener[,] Movement = new uTweener[10, 10];
  private uTweenText[] PowerCount = new uTweenText[10];
  private uTweenScale[] EmblemScale = new uTweenScale[2];
  private uTweenPosition[] Position = new uTweenPosition[10];
  private uTweenRotation[] Rotation = new uTweenRotation[10];
  private UIButtonHint[] m_playerHint = new UIButtonHint[12];
  private CString[] AllianceStr = new CString[20];
  protected bool LeftRightInit;
  protected bool LeftRightSet;
  protected bool Preparing;
  protected bool Ready;
  protected bool SetGo;
  protected bool bRequest;
  protected bool bReturn;
  protected bool bExit;
  protected bool bEnd;
  protected Door door;
  protected Color[] m_Camp = new Color[2];
  protected UnityEngine.UI.Text[] m_label = new UnityEngine.UI.Text[28];
  protected UnityEngine.UI.Text m_limit;
  protected UnityEngine.UI.Text m_title;
  protected UnityEngine.UI.Text m_error;
  protected UnityEngine.UI.Text m_filter;
  protected UnityEngine.UI.Text m_search;
  protected UnityEngine.UI.Text m_button;
  protected UnityEngine.UI.Text m_content;
  protected UnityEngine.UI.Text[] m_default = new UnityEngine.UI.Text[3];
  protected UnityEngine.UI.Text[,] m_player = new UnityEngine.UI.Text[3, 20];
  protected UnityEngine.UI.Text m_descript;
  protected Image m_Dukedom;
  protected Image m_Defeater;
  protected Image m_MyEmperor;
  protected Image m_CrownBack;
  protected Image m_WorldWarZ;
  protected Image m_WorldPiss;
  protected UIAllianceWarBattle.Hero[] HeroButt = new UIAllianceWarBattle.Hero[2];
  protected UIText[] DeadCounts = new UIText[2];
  protected CString[] DeadCountsStr = new CString[2];
  protected UISpritesArray USArray;
  protected UIButtonHint m_UIHint;
  protected Transform Transformer;
  public static BattleStation BattleRoyale;
  public GUIManager GM = GUIManager.Instance;
  public DataManager DM = DataManager.Instance;
  public NetworkManager NM = NetworkManager.Instance;
  public Font Font = GUIManager.Instance.GetTTFFont();
  public StringBuilder Path = new StringBuilder();
  private List<float> ItemsHeight = new List<float>();
  private string[] mHeroAct = new string[7];
  private CString[] m_Str = new CString[10];
  private Effect effect;
  private ushort head;
  private uint time;
  private int Offset = 1;
  private long RequestData;
  private float ReadyGo = 10f;
  private float BattleSpeed;
  private static byte ReplaySpeed;
  private static byte RoundPeriod = 10;
  private static byte FinishPeriod = 30;
  private static byte PreparePeriod = 60;
  private float burstScaleSpeed = 1f;
  private float burstRotationSpeed = 1f;
  private float FightTimeScale = 1f;
  private GameObject ParticleEffect_Hit;
  private GameObject ParticleEffect_Burst;
  private GameObject ParticleEffect_InRight;
  private GameObject ParticleEffect_InLeft;
  private ushort LeftHurtSfx;
  private ushort RightHurtSfx;
  private ushort LeftDyingSfx;
  private ushort RightDyingSfx;
  private int Rand;

  public override void OnOpen(int arg1, int arg2)
  {
    if (ActivityManager.Instance.AW_FightTime > (byte) 0)
      this.FightTimeScale = 5.9f / (float) ActivityManager.Instance.AW_FightTime;
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (UnityEngine.Object) this.door)
      this.door.UpdateUI(1, 2);
    GUIManager.Instance.InitianHeroItemImg(this.transform.GetChild(7).GetChild(3).GetChild(0).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    if (GUIManager.Instance.InitianHeroItemImg(this.transform.GetChild(8).GetChild(3).GetChild(0).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false))
      ((Component) this.transform.GetChild(8).GetChild(3).GetChild(0).GetComponent<UIHIBtn>().HIImage).transform.localScale = new Vector3(-1f, 1f, 1f);
    this.transform.GetChild(13).GetChild(1).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(13).GetChild(1).GetChild(1).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(13).GetChild(1).GetChild(2).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(13).GetChild(1).GetChild(3).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(13).GetChild(1).GetChild(4).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(13).GetChild(1).GetChild(5).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(7).GetChild(0).GetChild(0).gameObject.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(8).GetChild(0).GetChild(0).gameObject.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(7).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
    this.transform.GetChild(8).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
    this.transform.GetChild(13).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(4).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(5).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.HeroButt[0].HeroHead = this.transform.GetChild(7).GetChild(3).GetChild(0).gameObject;
    this.HeroButt[0].HeroHint = this.HeroButt[0].HeroHead.GetComponent<UIHIBtn>();
    this.HeroButt[0].HeroHint.m_Handler = (IUIHIBtnClickHandler) this;
    this.HeroButt[0].HeroHint.m_BtnID1 = 1;
    this.HeroButt[1].HeroHead = this.transform.GetChild(8).GetChild(3).GetChild(0).gameObject;
    this.HeroButt[1].HeroHint = this.HeroButt[1].HeroHead.GetComponent<UIHIBtn>();
    this.HeroButt[1].HeroHint.m_Handler = (IUIHIBtnClickHandler) this;
    this.HeroButt[1].HeroHint.m_BtnID1 = 2;
    this.transform.GetChild(12).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(13).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_title = this.transform.GetChild(11).GetComponent<UnityEngine.UI.Text>();
    this.m_title.font = GUIManager.Instance.GetTTFFont();
    this.m_title.text = this.DM.mStringTable.GetStringByID(14611U);
    this.RequestBattleOrder(arg2 > 0);
    this.BattleWait = ActivityManager.Instance.AW_WaitTime;
    this.BattleFight = ActivityManager.Instance.AW_FightTime;
    this.BattleTime = (double) ActivityManager.Instance.AW_RoundBeginTime;
    this.BattlePrepare = ActivityManager.Instance.AW_PrepareTime;
    this.BattleRoundTime = ActivityManager.Instance.AW_OneRoundTime;
    this.transform.GetChild(0).GetChild(0).gameObject.AddComponent<ActivityWindow>().Initial(e_ActivityType.Run, (IActivityWindow) this);
    if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None || this.DM.RoleAlliance.Id == 0U)
      this.bExit = true;
    else if (!ActivityManager.Instance.AW_bcalculateEnd)
    {
      this.transform.GetChild(6).GetChild(0).GetChild(1).gameObject.SetActive(false);
      this.transform.GetChild(6).GetChild(1).GetChild(1).gameObject.SetActive(false);
      this.m_player[2, 12] = this.transform.GetChild(10).GetChild(1).GetComponent<UnityEngine.UI.Text>();
      this.m_player[2, 12].text = this.DM.mStringTable.GetStringByID(14613U);
      this.m_player[2, 12].font = GUIManager.Instance.GetTTFFont();
      this.RequestData = this.DM.ServerTime + 180L;
      this.bReturn = true;
    }
    else
    {
      if (this.BattleReplay)
      {
        this.BattleTime = (double) Time.time;
        if ((int) UIAllianceWarBattle.MatchID == (int) UIAllianceWarBattle.BattleRoyale.MatchID && UIAllianceWarBattle.ReplayTime > 0.0)
          this.BattleTime -= UIAllianceWarBattle.ReplayTime;
        this.BattlePrepare = (ushort) 2;
        this.ReadyGo = 12f;
      }
      else
      {
        if (ActivityManager.Instance.AW_State != EAllianceWarState.EAWS_Run)
        {
          this.bRequest = true;
          this.bReturn = true;
          return;
        }
        if ((int) ActivityManager.Instance.AW_Round != (int) UIAllianceWarBattle.BattleRoyale.GameRound || ActivityManager.Instance.AW_RoundBeginTime != UIAllianceWarBattle.BattleRoyale.BeginTime)
        {
          if (this.BattleSide > (byte) 0)
            this.bRequest = true;
          else
            this.bExit = true;
          this.bReturn = true;
          return;
        }
      }
      this.m_player[0, 0] = this.transform.GetChild(4).GetComponent<UnityEngine.UI.Text>();
      this.m_player[0, 0].font = GUIManager.Instance.GetTTFFont();
      for (int index = 0; index < 20; ++index)
        this.AllianceStr[index] = StringManager.Instance.SpawnString();
      if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null && UIAllianceWarBattle.BattleRoyale.Autobots > (byte) 0)
      {
        this.AllianceStr[0].StringToFormat(UIAllianceWarBattle.BattleRoyale.AutobotTag);
        if (UIAllianceWarBattle.BattleRoyale.CampAutobot > (byte) 0)
        {
          this.AllianceStr[0].StringToFormat(this.DM.mStringTable.GetStringByID(11163U));
          this.AllianceStr[0].AppendFormat("[{0}]{1}");
        }
        else
          this.AllianceStr[0].AppendFormat("[{0}]");
        this.m_player[0, 0].text = this.AllianceStr[0].ToString();
        this.transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
        ((RectTransform) this.transform.GetChild(4).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[0, 0].preferredWidth, ((Graphic) this.m_player[0, 0]).rectTransform.sizeDelta.x), 3f);
      }
      else
        this.m_player[0, 0].text = (string) null;
      this.m_player[1, 0] = this.transform.GetChild(5).GetComponent<UnityEngine.UI.Text>();
      this.m_player[1, 0].font = GUIManager.Instance.GetTTFFont();
      if (UIAllianceWarBattle.BattleRoyale.DecepticonTag != null && UIAllianceWarBattle.BattleRoyale.Decepticons > (byte) 0)
      {
        this.AllianceStr[1].StringToFormat(UIAllianceWarBattle.BattleRoyale.DecepticonTag);
        if (UIAllianceWarBattle.BattleRoyale.CampDecepticon > (byte) 0)
        {
          this.AllianceStr[1].StringToFormat(this.DM.mStringTable.GetStringByID(11163U));
          this.AllianceStr[1].AppendFormat("[{0}]{1}");
        }
        else
          this.AllianceStr[1].AppendFormat("[{0}]");
        this.m_player[1, 0].text = this.AllianceStr[1].ToString();
        this.transform.GetChild(5).GetChild(0).gameObject.SetActive(true);
        ((RectTransform) this.transform.GetChild(5).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[1, 0].preferredWidth, ((Graphic) this.m_player[1, 0]).rectTransform.sizeDelta.x), 3f);
      }
      else
        this.m_player[1, 0].text = (string) null;
      if (UIAllianceWarBattle.BattleRoyale.Autobot != null && UIAllianceWarBattle.BattleRoyale.Autobots > (byte) 0)
      {
        this.m_player[0, 1] = this.transform.GetChild(6).GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.m_player[0, 1].font = GUIManager.Instance.GetTTFFont();
        this.m_player[0, 2] = this.transform.GetChild(6).GetChild(0).GetChild(1).GetChild(1).GetComponent<UnityEngine.UI.Text>();
        this.m_player[0, 2].font = GUIManager.Instance.GetTTFFont();
        this.m_playerHint[0] = this.transform.GetChild(6).GetChild(0).GetChild(0).gameObject.AddComponent<UIButtonHint>();
        this.m_playerHint[0].m_eHint = EUIButtonHint.DownUpHandler;
        this.m_playerHint[0].m_Handler = (MonoBehaviour) this;
        this.m_playerHint[0].Parm1 = (ushort) 0;
        this.m_playerHint[0].Parm2 = UIAllianceWarBattle.BattleRoyale.Autobots;
        this.m_playerHint[0].ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
        ((RectTransform) this.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[0, 1].preferredWidth, ((Graphic) this.m_player[0, 1]).rectTransform.sizeDelta.x), 3f);
      }
      this.transform.GetChild(6).GetChild(0).GetChild(1).gameObject.SetActive(false);
      for (int index = 1; index < 6; ++index)
      {
        this.m_player[0, index + 2] = this.transform.GetChild(6).GetChild(0).GetChild(index + 1).GetComponent<UnityEngine.UI.Text>();
        this.m_player[0, index + 2].font = GUIManager.Instance.GetTTFFont();
      }
      for (int index = 0; index < 6; ++index)
      {
        if (index > 0)
        {
          this.m_playerHint[index] = this.transform.GetChild(6).GetChild(0).GetChild(index + 1).gameObject.AddComponent<UIButtonHint>();
          this.m_playerHint[index].m_eHint = EUIButtonHint.DownUpHandler;
          this.m_playerHint[index].m_Handler = (MonoBehaviour) this;
          this.m_playerHint[index].Parm1 = (ushort) 0;
          this.m_playerHint[index].Parm2 = (byte) (index - 1);
          this.m_playerHint[index].ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
        }
        this.m_player[2, index] = this.transform.GetChild(6).GetChild(0).GetChild(7 + index).GetComponent<UnityEngine.UI.Text>();
        this.m_player[2, index].font = GUIManager.Instance.GetTTFFont();
      }
      for (int index = 0; index < (int) UIAllianceWarBattle.BattleRoyale.Autobots && index < 5; ++index)
      {
        if (UIAllianceWarBattle.BattleRoyale.Autobot[index].Name != null)
          this.m_player[0, index + 3].text = UIAllianceWarBattle.BattleRoyale.Autobot[index].Name.ToString();
        ((RectTransform) this.transform.GetChild(6).GetChild(0).GetChild(index + 2).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[0, index + 3].preferredWidth, ((Graphic) this.m_player[0, index + 3]).rectTransform.sizeDelta.x), 3f);
        if (this.GM.IsArabic)
          ((RectTransform) this.transform.GetChild(6).GetChild(0).GetChild(index + 2).GetChild(0).transform).anchoredPosition = new Vector2(((Graphic) this.m_player[0, index + 3]).rectTransform.sizeDelta.x - Math.Min(this.m_player[0, index + 3].preferredWidth, ((Graphic) this.m_player[0, index + 3]).rectTransform.sizeDelta.x), -12f);
        this.m_player[2, index + 1].text = (index + 1).ToString();
      }
      if (UIAllianceWarBattle.BattleRoyale.Decepticon != null && UIAllianceWarBattle.BattleRoyale.Decepticons > (byte) 0)
      {
        this.m_playerHint[6] = this.transform.GetChild(6).GetChild(1).GetChild(0).gameObject.AddComponent<UIButtonHint>();
        this.m_playerHint[6].m_eHint = EUIButtonHint.DownUpHandler;
        this.m_playerHint[6].m_Handler = (MonoBehaviour) this;
        this.m_playerHint[6].Parm1 = (ushort) 1;
        this.m_playerHint[6].Parm2 = UIAllianceWarBattle.BattleRoyale.Decepticons;
        this.m_playerHint[6].ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
        this.m_player[1, 1] = this.transform.GetChild(6).GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.m_player[1, 1].font = GUIManager.Instance.GetTTFFont();
        this.m_player[1, 2] = this.transform.GetChild(6).GetChild(1).GetChild(1).GetChild(1).GetComponent<UnityEngine.UI.Text>();
        this.m_player[1, 2].font = GUIManager.Instance.GetTTFFont();
      }
      this.transform.GetChild(6).GetChild(1).GetChild(1).gameObject.SetActive(false);
      for (int index = 1; index < 6; ++index)
      {
        this.m_player[1, index + 2] = this.transform.GetChild(6).GetChild(1).GetChild(index + 1).GetComponent<UnityEngine.UI.Text>();
        this.m_player[1, index + 2].font = GUIManager.Instance.GetTTFFont();
      }
      for (int index = 0; index < 6; ++index)
      {
        if (index > 0)
        {
          this.m_playerHint[index + 6] = this.transform.GetChild(6).GetChild(1).GetChild(index + 1).gameObject.AddComponent<UIButtonHint>();
          this.m_playerHint[index + 6].m_eHint = EUIButtonHint.DownUpHandler;
          this.m_playerHint[index + 6].m_Handler = (MonoBehaviour) this;
          this.m_playerHint[index + 6].Parm1 = (ushort) 1;
          this.m_playerHint[index + 6].Parm2 = (byte) (index - 1);
          this.m_playerHint[index + 6].ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
        }
        this.m_player[2, index + 6] = this.transform.GetChild(6).GetChild(1).GetChild(7 + index).GetComponent<UnityEngine.UI.Text>();
        this.m_player[2, index + 6].font = GUIManager.Instance.GetTTFFont();
      }
      for (int index = 0; index < (int) UIAllianceWarBattle.BattleRoyale.Decepticons && index < 5; ++index)
      {
        if (UIAllianceWarBattle.BattleRoyale.Decepticon[index].Name != null)
          this.m_player[1, index + 3].text = UIAllianceWarBattle.BattleRoyale.Decepticon[index].Name.ToString();
        ((RectTransform) this.transform.GetChild(6).GetChild(1).GetChild(index + 2).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[1, index + 3].preferredWidth, ((Graphic) this.m_player[1, index + 3]).rectTransform.sizeDelta.x), 3f);
        if (this.GM.IsArabic)
          ((RectTransform) this.transform.GetChild(6).GetChild(1).GetChild(index + 2).GetChild(0).transform).anchoredPosition = new Vector2(((Graphic) this.m_player[1, index + 3]).rectTransform.sizeDelta.x - Math.Min(this.m_player[1, index + 3].preferredWidth, ((Graphic) this.m_player[1, index + 3]).rectTransform.sizeDelta.x), -12f);
        this.m_player[2, index + 7].text = (index + 1).ToString();
      }
      this.m_player[0, 8] = this.transform.GetChild(7).GetChild(1).GetComponent<UnityEngine.UI.Text>();
      this.m_player[0, 8].font = GUIManager.Instance.GetTTFFont();
      this.m_Camp[0] = ((Graphic) this.m_player[0, 8]).color;
      if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null && UIAllianceWarBattle.BattleRoyale.AutobotTag.Length > 0)
      {
        this.AllianceStr[4].StringToFormat(UIAllianceWarBattle.BattleRoyale.AutobotTag);
        this.AllianceStr[4].AppendFormat("[{0}]");
        this.m_player[0, 8].text = this.AllianceStr[4].ToString();
        this.transform.GetChild(6).GetChild(2).GetChild(0).gameObject.SetActive(true);
      }
      else
        this.m_player[0, 8].text = this.DM.mStringTable.GetStringByID(12061U);
      this.m_player[0, 9] = this.transform.GetChild(7).GetChild(2).GetChild(1).GetComponent<UnityEngine.UI.Text>();
      this.m_player[0, 9].font = GUIManager.Instance.GetTTFFont();
      if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null && UIAllianceWarBattle.BattleRoyale.AutobotTag.Length > 0)
      {
        this.AllianceStr[5].StringToFormat(UIAllianceWarBattle.BattleRoyale.AutobotTag);
        this.AllianceStr[5].StringToFormat(UIAllianceWarBattle.BattleRoyale.Autobot[0].Name);
        this.AllianceStr[5].AppendFormat("[{0}]{1}");
        this.m_player[0, 9].text = this.AllianceStr[5].ToString();
      }
      this.m_player[0, 10] = this.transform.GetChild(7).GetChild(2).GetChild(0).GetComponent<UnityEngine.UI.Text>();
      this.m_player[0, 10].font = GUIManager.Instance.GetTTFFont();
      if (UIAllianceWarBattle.BattleRoyale.Autobots > (byte) 0)
      {
        this.AllianceStr[6].uLongToFormat(UIAllianceWarBattle.BattleRoyale.Autobot[0].Power, bNumber: true);
        this.AllianceStr[6].AppendFormat("{0}");
        this.m_player[0, 10].text = this.AllianceStr[6].ToString();
        if (this.BattleReplay)
          ;
      }
      this.m_player[1, 8] = this.transform.GetChild(8).GetChild(1).GetComponent<UnityEngine.UI.Text>();
      this.m_player[1, 8].font = GUIManager.Instance.GetTTFFont();
      this.m_Camp[1] = ((Graphic) this.m_player[1, 8]).color;
      if (UIAllianceWarBattle.BattleRoyale.DecepticonTag != null && UIAllianceWarBattle.BattleRoyale.DecepticonTag.Length > 0)
      {
        this.AllianceStr[7].StringToFormat(UIAllianceWarBattle.BattleRoyale.DecepticonTag);
        this.AllianceStr[7].AppendFormat("[{0}]");
        this.m_player[1, 8].text = this.AllianceStr[7].ToString();
        this.transform.GetChild(6).GetChild(3).GetChild(0).gameObject.SetActive(true);
      }
      else
        this.m_player[1, 8].text = this.DM.mStringTable.GetStringByID(12061U);
      this.m_player[1, 9] = this.transform.GetChild(8).GetChild(2).GetChild(1).GetComponent<UnityEngine.UI.Text>();
      this.m_player[1, 9].font = GUIManager.Instance.GetTTFFont();
      if (UIAllianceWarBattle.BattleRoyale.DecepticonTag != null && UIAllianceWarBattle.BattleRoyale.DecepticonTag.Length > 0)
      {
        this.AllianceStr[8].StringToFormat(UIAllianceWarBattle.BattleRoyale.DecepticonTag);
        this.AllianceStr[8].StringToFormat(UIAllianceWarBattle.BattleRoyale.Decepticon[0].Name);
        this.AllianceStr[8].AppendFormat("[{0}]{1}");
        this.m_player[1, 9].text = this.AllianceStr[8].ToString();
      }
      this.m_player[1, 10] = this.transform.GetChild(8).GetChild(2).GetChild(0).GetComponent<UnityEngine.UI.Text>();
      this.m_player[1, 10].font = GUIManager.Instance.GetTTFFont();
      if (UIAllianceWarBattle.BattleRoyale.Decepticons > (byte) 0)
      {
        this.AllianceStr[9].uLongToFormat(UIAllianceWarBattle.BattleRoyale.Decepticon[0].Power, bNumber: true);
        this.AllianceStr[9].AppendFormat("{0}");
        this.m_player[1, 10].text = this.AllianceStr[9].ToString();
        if (this.BattleReplay)
          ;
      }
      this.m_player[0, 11] = this.transform.GetChild(7).GetChild(4).GetComponent<UnityEngine.UI.Text>();
      this.m_player[0, 11].font = GUIManager.Instance.GetTTFFont();
      this.m_player[0, 12] = this.transform.GetChild(7).GetChild(4).GetChild(0).GetComponent<UnityEngine.UI.Text>();
      this.m_player[0, 12].font = GUIManager.Instance.GetTTFFont();
      this.m_player[1, 11] = this.transform.GetChild(8).GetChild(4).GetComponent<UnityEngine.UI.Text>();
      this.m_player[1, 11].font = GUIManager.Instance.GetTTFFont();
      UnityEngine.UI.Text text1 = this.m_player[1, 11];
      string stringById = this.DM.mStringTable.GetStringByID(14621U);
      this.m_player[0, 11].text = stringById;
      string str1 = stringById;
      text1.text = str1;
      this.m_player[1, 12] = this.transform.GetChild(8).GetChild(4).GetChild(0).GetComponent<UnityEngine.UI.Text>();
      this.m_player[1, 12].font = GUIManager.Instance.GetTTFFont();
      this.m_player[0, 13] = this.transform.GetChild(7).GetChild(5).GetChild(0).GetComponent<UnityEngine.UI.Text>();
      this.m_player[0, 13].font = GUIManager.Instance.GetTTFFont();
      this.m_player[1, 13] = this.transform.GetChild(8).GetChild(5).GetChild(0).GetComponent<UnityEngine.UI.Text>();
      this.m_player[1, 13].font = GUIManager.Instance.GetTTFFont();
      this.m_player[0, 14] = this.transform.GetChild(7).GetChild(6).GetChild(1).GetComponent<UnityEngine.UI.Text>();
      this.m_player[0, 14].font = GUIManager.Instance.GetTTFFont();
      this.m_player[1, 14] = this.transform.GetChild(8).GetChild(6).GetChild(1).GetComponent<UnityEngine.UI.Text>();
      this.m_player[1, 14].font = GUIManager.Instance.GetTTFFont();
      this.m_player[2, 12] = this.transform.GetChild(10).GetChild(1).GetComponent<UnityEngine.UI.Text>();
      this.m_player[2, 12].font = GUIManager.Instance.GetTTFFont();
      this.m_player[2, 13] = this.transform.GetChild(9).GetChild(1).gameObject.GetComponent<UnityEngine.UI.Text>();
      this.m_player[2, 13].font = GUIManager.Instance.GetTTFFont();
      this.m_player[2, 14] = this.transform.GetChild(13).GetChild(1).GetChild(5).GetChild(1).GetComponent<UnityEngine.UI.Text>();
      this.m_player[2, 14].font = GUIManager.Instance.GetTTFFont();
      this.m_player[2, 14].text = "x1";
      this.DeadCounts[0] = this.transform.GetChild(7).GetChild(9).GetComponent<UIText>();
      this.DeadCounts[0].font = GUIManager.Instance.GetTTFFont();
      ((Graphic) this.DeadCounts[0]).color = (Color) new Color32(byte.MaxValue, (byte) 58, (byte) 58, byte.MaxValue);
      ((Graphic) this.DeadCounts[0]).rectTransform.anchoredPosition = new Vector2(-116f, -92f);
      ((Graphic) this.DeadCounts[0]).rectTransform.sizeDelta = new Vector2(220f, 60f);
      this.DeadCounts[0].resizeTextForBestFit = false;
      this.DeadCounts[0].fontSize = 36;
      this.DeadCounts[1] = this.transform.GetChild(8).GetChild(9).GetComponent<UIText>();
      this.DeadCounts[1].font = GUIManager.Instance.GetTTFFont();
      ((Graphic) this.DeadCounts[1]).color = Color.white;
      ((Graphic) this.DeadCounts[1]).rectTransform.anchoredPosition = new Vector2(116f, -92f);
      ((Graphic) this.DeadCounts[1]).rectTransform.sizeDelta = new Vector2(220f, 60f);
      ((Graphic) this.DeadCounts[1]).color = (Color) new Color32(byte.MaxValue, (byte) 58, (byte) 58, byte.MaxValue);
      this.DeadCounts[1].resizeTextForBestFit = false;
      this.DeadCounts[1].fontSize = 36;
      int x1 = 0;
      int x2 = 0;
      if (UIAllianceWarBattle.BattleRoyale.BattleMatch != null && UIAllianceWarBattle.BattleRoyale.BattleMatch.Length > 0)
      {
        for (int index = 0; index < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length; ++index)
        {
          if (UIAllianceWarBattle.BattleRoyale.BattleMatch[index].WinnerSide == (byte) 1)
            ++x1;
          else
            ++x2;
        }
      }
      else if (UIAllianceWarBattle.BattleRoyale.Decepticons > (byte) 0)
        x2 = (int) UIAllianceWarBattle.BattleRoyale.Decepticons;
      else
        x1 = (int) UIAllianceWarBattle.BattleRoyale.Autobots;
      this.AllianceStr[13].IntToFormat((long) x1);
      this.AllianceStr[13].IntToFormat((long) x2);
      this.AllianceStr[13].AppendFormat("{0} - {1}");
      this.m_player[2, 13].text = this.AllianceStr[13].ToString();
      UnityEngine.UI.Text text2 = this.m_player[2, 0];
      string str2 = "-";
      this.m_player[2, 6].text = str2;
      string str3 = str2;
      text2.text = str3;
      this.transform.GetChild(13).GetChild(0).gameObject.SetActive(false);
      this.transform.GetChild(12).gameObject.SetActive(this.BattleSide > (byte) 0 && !this.BattleReplay);
      this.transform.GetChild(7).GetChild(2).GetChild(0).gameObject.SetActive(true);
      this.transform.GetChild(8).GetChild(2).GetChild(0).gameObject.SetActive(true);
      this.transform.GetChild(13).GetChild(1).GetChild(0).gameObject.SetActive(false);
      this.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(this.DM.UserLanguage != GameLanguage.GL_Chs);
      this.transform.GetChild(2).GetChild(0).GetChild(1).gameObject.SetActive(this.DM.UserLanguage == GameLanguage.GL_Chs);
      if (UIAllianceWarBattle.BattleRoyale.BattleSide == (byte) 1)
      {
        for (int index = 2; index <= 20; index += 3)
          this.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(index).gameObject.SetActive(false);
        for (int index = 0; index <= (int) UIAllianceWarBattle.BattleRoyale.Autobots && UIAllianceWarBattle.BattleRoyale.Autobot != null && index < 6; ++index)
        {
          if (UIAllianceWarBattle.BattleRoyale.AutobotPos > (byte) 0 && (int) UIAllianceWarBattle.BattleRoyale.AutobotPos == index)
            this.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1 + index * 3).gameObject.SetActive(false);
        }
        this.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(21).GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(21).GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(7).GetChild(6).GetChild(0).gameObject.SetActive(false);
      }
      else if (UIAllianceWarBattle.BattleRoyale.BattleSide == (byte) 2)
      {
        ((Graphic) this.m_player[0, 0]).color = this.m_Camp[1];
        ((Graphic) this.m_player[1, 0]).color = this.m_Camp[0];
        ((Graphic) this.m_player[0, 8]).color = this.m_Camp[1];
        ((Graphic) this.m_player[1, 8]).color = this.m_Camp[0];
        ((Graphic) this.m_player[0, 9]).color = this.m_Camp[1];
        ((Graphic) this.m_player[1, 9]).color = this.m_Camp[0];
        for (int index = 2; index <= 20; index += 3)
          this.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(index).gameObject.SetActive(false);
        for (int index = 0; index <= (int) UIAllianceWarBattle.BattleRoyale.Decepticons && UIAllianceWarBattle.BattleRoyale.Decepticon != null && index < 6; ++index)
        {
          if (UIAllianceWarBattle.BattleRoyale.DecepticonPos > (byte) 0 && (int) UIAllianceWarBattle.BattleRoyale.DecepticonPos == index)
            this.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(1 + index * 3).gameObject.SetActive(false);
        }
        this.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(21).GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(21).GetChild(0).gameObject.SetActive(true);
        ((Graphic) this.transform.GetChild(4).GetChild(0).GetComponent<Image>()).color = this.m_Camp[1];
        ((Graphic) this.transform.GetChild(5).GetChild(0).GetComponent<Image>()).color = this.m_Camp[0];
        this.transform.GetChild(8).GetChild(6).GetChild(0).gameObject.SetActive(false);
      }
      else
      {
        ((Graphic) this.m_player[0, 0]).color = this.m_Camp[1];
        ((Graphic) this.m_player[0, 8]).color = this.m_Camp[1];
        ((Graphic) this.m_player[0, 9]).color = this.m_Camp[1];
        ((Graphic) this.transform.GetChild(4).GetChild(0).GetComponent<Image>()).color = this.m_Camp[1];
      }
      this.transform.GetChild(12).GetChild(0).gameObject.SetActive(ActivityManager.Instance.AW_PrizeGroupID > (byte) 0);
      this.DeadCountsStr[0] = StringManager.Instance.SpawnString();
      this.DeadCountsStr[1] = StringManager.Instance.SpawnString();
      AudioManager.Instance.PlayMP3SFX(BGMType.LegionWar, Vol: 0.54f);
      LeftRightFly.Instance.init();
      this.LeftRightInit = true;
      this.Refresh();
    }
  }

  private void Refresh(int arg1 = 0)
  {
    int num1 = (int) UIAllianceWarBattle.BattleRoyale.AutobotIcon & 7;
    int mBadge1 = ((int) UIAllianceWarBattle.BattleRoyale.AutobotIcon >> 3 & 7) * 8 + num1 + 1;
    if (mBadge1 > 64)
      mBadge1 = 64;
    int mTotem1 = ((int) UIAllianceWarBattle.BattleRoyale.AutobotIcon >> 6 & 63) + 1;
    if (mTotem1 > 64)
      mTotem1 = 64;
    GUIManager.Instance.SetBadgeTotemImg(this.transform.GetChild(7).GetChild(0).GetChild(0).GetChild(2).transform, mBadge1, mTotem1);
    int num2 = (int) UIAllianceWarBattle.BattleRoyale.DecepticonIcon & 7;
    int mBadge2 = ((int) UIAllianceWarBattle.BattleRoyale.DecepticonIcon >> 3 & 7) * 8 + num2 + 1;
    if (mBadge2 > 64)
      mBadge2 = 64;
    int mTotem2 = ((int) UIAllianceWarBattle.BattleRoyale.DecepticonIcon >> 6 & 63) + 1;
    if (mTotem2 > 64)
      mTotem2 = 64;
    GUIManager.Instance.SetBadgeTotemImg(this.transform.GetChild(8).GetChild(0).GetChild(0).GetChild(2).transform, mBadge2, mTotem2);
    this.transform.GetChild(7).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(UIAllianceWarBattle.BattleRoyale.Autobots > (byte) 0);
    this.transform.GetChild(8).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(UIAllianceWarBattle.BattleRoyale.Decepticons > (byte) 0);
    this.transform.GetChild(7).GetChild(2).gameObject.SetActive(false);
    this.transform.GetChild(8).GetChild(2).gameObject.SetActive(false);
    if (UIAllianceWarBattle.BattleRoyale.Autobot != null && UIAllianceWarBattle.BattleRoyale.Autobot.Length > 0)
    {
      GUIManager.Instance.ChangeHeroItemImg(this.transform.GetChild(7).GetChild(3).GetChild(0).transform, eHeroOrItem.Hero, UIAllianceWarBattle.BattleRoyale.Autobot[0].Head, (byte) 11, (byte) 0);
      global::Hero recordByKey = this.DM.HeroTable.GetRecordByKey(UIAllianceWarBattle.BattleRoyale.Autobot[0].Head);
      this.LeftDyingSfx = recordByKey.DyingSound;
      this.LeftHurtSfx = recordByKey.HurtSound;
    }
    if (UIAllianceWarBattle.BattleRoyale.Decepticon != null && UIAllianceWarBattle.BattleRoyale.Decepticon.Length > 0)
    {
      GUIManager.Instance.ChangeHeroItemImg(this.transform.GetChild(8).GetChild(3).GetChild(0).transform, eHeroOrItem.Hero, UIAllianceWarBattle.BattleRoyale.Decepticon[0].Head, (byte) 11, (byte) 0);
      global::Hero recordByKey = this.DM.HeroTable.GetRecordByKey(UIAllianceWarBattle.BattleRoyale.Decepticon[0].Head);
      this.RightDyingSfx = recordByKey.DyingSound;
      this.RightHurtSfx = recordByKey.HurtSound;
    }
    for (int index = 1; index <= 2; ++index)
      this.EmblemScale[index - 1] = this.transform.GetChild(6 + index).GetChild(0).GetComponent<uTweenScale>();
    if (this.BattleReplay || this.BattleTime > 0.0 && this.BattleTime >= (double) ActivityManager.Instance._ServerEventDeltaTime + NetworkManager.ServerTime - (double) this.BattlePrepare && !this.Preparing)
      this.SetStage(UIAllianceWarBattle.MoveStage.MS_WAITING);
    else
      this.SetStage(UIAllianceWarBattle.MoveStage.MS_STARTING);
    if (this.BattleReplay && UIAllianceWarBattle.ReplayTime > 0.0)
    {
      switch (UIAllianceWarBattle.ReplaySpeed)
      {
        case 2:
          this.m_player[2, 14].text = "x2";
          break;
        case 3:
          this.m_player[2, 14].text = "x3";
          break;
        default:
          this.m_player[2, 14].text = "x1";
          break;
      }
      this.transform.GetChild(13).GetChild(1).GetChild(4).gameObject.SetActive(false);
      for (UIAllianceWarBattle.MoveStage movieStage = this.MovieStage; movieStage < UIAllianceWarBattle.MoveStage.MS_MAX; ++movieStage)
      {
        if (!this.bEnd)
          this.Update();
      }
    }
    else
    {
      UIAllianceWarBattle.ReplaySpeed = (byte) 1;
      UIAllianceWarBattle.ReplayTime = 0.0;
    }
  }

  protected void SetStage(UIAllianceWarBattle.MoveStage MS)
  {
    this.MovieStage = MS;
    switch (this.MovieStage)
    {
      case UIAllianceWarBattle.MoveStage.MS_WAITING:
        if ((bool) (UnityEngine.Object) this.m_player[2, 12] && !this.BattleReplay)
          this.m_player[2, 12].text = this.DM.mStringTable.GetStringByID(14612U);
        this.transform.GetChild(10).gameObject.SetActive(!this.BattleReplay);
        this.Preparing = true;
        break;
      case UIAllianceWarBattle.MoveStage.MS_STARTING:
        this.transform.GetChild(13).GetChild(0).gameObject.SetActive(UIAllianceWarBattle.BattleRoyale.BattleSide > (byte) 0);
        this.transform.GetChild(6).GetChild(0).GetChild(1).gameObject.SetActive(UIAllianceWarBattle.BattleRoyale.Autobot != null && UIAllianceWarBattle.BattleRoyale.Autobots > (byte) 0);
        this.transform.GetChild(6).GetChild(1).GetChild(1).gameObject.SetActive(UIAllianceWarBattle.BattleRoyale.Decepticon != null && UIAllianceWarBattle.BattleRoyale.Decepticons > (byte) 0);
        this.transform.GetChild(10).gameObject.SetActive(false);
        this.transform.GetChild(8).GetChild(6).gameObject.SetActive(true);
        this.transform.GetChild(7).GetChild(6).gameObject.SetActive(true);
        this.transform.GetChild(6).GetChild(2).GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(6).GetChild(3).GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(7).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(8).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(21).gameObject.SetActive(false);
        this.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(21).gameObject.SetActive(false);
        this.transform.GetChild(13).GetChild(1).gameObject.SetActive(this.BattleReplay);
        this.transform.GetChild(9).GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
        if (this.BattleReplay && UIAllianceWarBattle.ReplayTime > 0.0)
        {
          float num = 0.0f;
          Time.timeScale = num;
          UIAllianceWarBattle.ReplayTime = (double) num;
        }
        this.Offset = 1;
        this.LeftRightSet = false;
        this.SetGo = true;
        this.SetStage(UIAllianceWarBattle.MoveStage.MS_FIGHTING);
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING:
        if (ActivityManager.Instance.AW_FightTime > (byte) 0)
        {
          this.BattleRound = (byte) Mathf.Clamp((int) ((double) ActivityManager.Instance._ServerEventDeltaTime + NetworkManager.ServerTime - this.BattleTime - (double) this.BattlePrepare) / (int) ActivityManager.Instance.AW_FightTime, 0, (int) UIAllianceWarBattle.BattleRoyale.BattleMatchs);
          if (this.BattleReplay)
            this.BattleRound = (byte) Mathf.Clamp((int) (this.PassTime - this.BattleTime - (double) this.BattlePrepare) / (int) ActivityManager.Instance.AW_FightTime, 0, (int) UIAllianceWarBattle.BattleRoyale.BattleMatchs);
        }
        if ((int) this.BattleRound < (int) UIAllianceWarBattle.BattleRoyale.BattleMatchs)
        {
          this.transform.GetChild(13).GetChild(0).gameObject.SetActive(UIAllianceWarBattle.BattleRoyale.BattleSide > (byte) 0 && UIAllianceWarBattle.BattleRoyale.BattleMatchs > (byte) 0 && !this.BattleReplay);
          this.transform.GetChild(13).GetChild(1).GetChild(0).gameObject.SetActive(UIAllianceWarBattle.BattleRoyale.BattleSide > (byte) 0 && UIAllianceWarBattle.BattleRoyale.BattleMatchs > (byte) 0);
          this.transform.GetChild(13).GetChild(1).gameObject.SetActive(this.BattleReplay);
          this.transform.GetChild(7).GetChild(6).gameObject.SetActive(true);
          this.transform.GetChild(8).GetChild(6).gameObject.SetActive(true);
          this.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
          this.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
        }
        else
          this.UpdateUI(6, 0);
        this.UpdateUI(7, 0);
        global::Hero recordByKey;
        if (UIAllianceWarBattle.BattleRoyale.Autobot != null && UIAllianceWarBattle.BattleRoyale.Autobots > (byte) 0 && (int) this.BattleRound <= (int) UIAllianceWarBattle.BattleRoyale.BattleMatchs)
        {
          int index1 = 0;
          for (int index2 = 0; index2 < (int) this.BattleRound; ++index2)
          {
            if (UIAllianceWarBattle.BattleRoyale.BattleMatch[index2].WinnerSide == (byte) 2)
              ++index1;
          }
          for (int index3 = 0; index3 < 6; ++index3)
          {
            if ((bool) (UnityEngine.Object) this.m_player[2, index3])
              this.m_player[2, index3].text = (string) null;
            if ((bool) (UnityEngine.Object) this.m_player[0, index3 + 2])
              this.m_player[0, index3 + 2].text = (string) null;
            if ((bool) (UnityEngine.Object) this.m_playerHint[index3])
              this.m_playerHint[index3].Parm2 = UIAllianceWarBattle.BattleRoyale.Autobots;
            ((RectTransform) this.transform.GetChild(6).GetChild(0).GetChild(index3 <= 0 ? 0 : index3 + 1).GetChild(0).transform).sizeDelta = new Vector2(0.0f, 3f);
          }
          if (index1 < (int) UIAllianceWarBattle.BattleRoyale.Autobots)
          {
            if ((bool) (UnityEngine.Object) this.m_player[0, 1] && UIAllianceWarBattle.BattleRoyale.Autobot[index1].Name != null)
              this.m_player[0, 1].text = UIAllianceWarBattle.BattleRoyale.Autobot[index1].Name.ToString();
            this.AllianceStr[2].ClearString();
            this.AllianceStr[2].uLongToFormat(UIAllianceWarBattle.BattleRoyale.Autobot[index1].Power, bNumber: true);
            this.AllianceStr[2].AppendFormat("{0}");
            if ((bool) (UnityEngine.Object) this.m_player[0, 2])
            {
              this.m_player[0, 2].text = this.AllianceStr[2].ToString();
              ((Graphic) this.m_player[0, 2]).SetAllDirty();
              this.m_player[0, 2].cachedTextGenerator.Invalidate();
            }
            if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null && UIAllianceWarBattle.BattleRoyale.AutobotTag.Length > 0)
            {
              this.AllianceStr[5].ClearString();
              this.AllianceStr[5].StringToFormat(UIAllianceWarBattle.BattleRoyale.AutobotTag);
              this.AllianceStr[5].StringToFormat(UIAllianceWarBattle.BattleRoyale.Autobot[index1].Name);
              this.AllianceStr[5].AppendFormat("[{0}]{1}");
              if ((bool) (UnityEngine.Object) this.m_player[0, 9])
              {
                this.m_player[0, 9].text = this.AllianceStr[5].ToString();
                ((Graphic) this.m_player[0, 9]).SetAllDirty();
                this.m_player[0, 9].cachedTextGenerator.Invalidate();
              }
            }
            if ((int) this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
            {
              this.AllianceStr[6].ClearString();
              this.AllianceStr[6].uLongToFormat((ulong) (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftSurvive + UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftDead), bNumber: true);
              this.AllianceStr[6].AppendFormat("{0}");
              if ((bool) (UnityEngine.Object) this.m_player[0, 10])
              {
                this.m_player[0, 10].text = this.AllianceStr[6].ToString();
                ((Graphic) this.m_player[0, 10]).SetAllDirty();
                this.m_player[0, 10].cachedTextGenerator.Invalidate();
                this.m_player[0, 10].cachedTextGeneratorForLayout.Invalidate();
              }
            }
            if (UIAllianceWarBattle.BattleRoyale.Autobots > (byte) 0)
            {
              this.GM.ChangeHeroItemImg(this.transform.GetChild(7).GetChild(3).GetChild(0).transform, eHeroOrItem.Hero, UIAllianceWarBattle.BattleRoyale.Autobot[index1].Head, (byte) 11, (byte) 0);
              if ((bool) (UnityEngine.Object) this.HeroButt[0].HeroHint)
                this.HeroButt[0].HeroHint.m_BtnID2 = index1;
              recordByKey = this.DM.HeroTable.GetRecordByKey(UIAllianceWarBattle.BattleRoyale.Autobot[index1].Head);
              this.LeftDyingSfx = recordByKey.DyingSound;
              this.LeftHurtSfx = recordByKey.HurtSound;
            }
            this.transform.GetChild(7).GetChild(2).GetChild(0).GetChild(0).transform.localPosition = new Vector3((float) ((double) this.m_player[0, 10].preferredWidth / -2.0 - 30.0), 0.0f, 0.0f);
            if ((bool) (UnityEngine.Object) this.m_player[0, 1])
            {
              ((RectTransform) this.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[0, 1].preferredWidth, ((Graphic) this.m_player[0, 1]).rectTransform.sizeDelta.x), 3f);
              if (this.GM.IsArabic)
                ((RectTransform) this.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(0).transform).anchoredPosition = new Vector2(((Graphic) this.m_player[0, 1]).rectTransform.sizeDelta.x - Math.Min(this.m_player[0, 1].preferredWidth, ((Graphic) this.m_player[0, 1]).rectTransform.sizeDelta.x), -12f);
            }
          }
          else
          {
            if ((bool) (UnityEngine.Object) this.m_player[0, 1])
              this.m_player[0, 1].text = (string) null;
            this.transform.GetChild(6).GetChild(0).GetChild(1).gameObject.SetActive(false);
          }
          this.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(21).gameObject.SetActive(true);
          for (int index4 = index1 + 1; index4 < (int) UIAllianceWarBattle.BattleRoyale.Autobots && index4 < index1 + 6; ++index4)
          {
            if ((bool) (UnityEngine.Object) this.m_player[0, index4 + 2 - index1] && UIAllianceWarBattle.BattleRoyale.Autobot[index4].Name != null)
            {
              this.m_player[0, index4 + 2 - index1].text = UIAllianceWarBattle.BattleRoyale.Autobot[index4].Name.ToString();
              ((RectTransform) this.transform.GetChild(6).GetChild(0).GetChild(index4 + 1 - index1).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[0, index4 + 2 - index1].preferredWidth, ((Graphic) this.m_player[0, index4 + 2 - index1]).rectTransform.sizeDelta.x), 3f);
              if (this.GM.IsArabic)
                ((RectTransform) this.transform.GetChild(6).GetChild(0).GetChild(index4 + 1 - index1).GetChild(0).transform).anchoredPosition = new Vector2(((Graphic) this.m_player[0, index4 + 2 - index1]).rectTransform.sizeDelta.x - Math.Min(this.m_player[0, index4 + 2 - index1].preferredWidth, ((Graphic) this.m_player[0, index4 + 2 - index1]).rectTransform.sizeDelta.x), -12f);
            }
          }
          for (int index5 = 0; index5 < 6; ++index5)
          {
            if ((bool) (UnityEngine.Object) this.m_playerHint[index5])
              this.m_playerHint[index5].Parm2 = (byte) (index5 + index1);
            if ((bool) (UnityEngine.Object) this.m_player[2, index5] && index5 + index1 + 1 <= (int) UIAllianceWarBattle.BattleRoyale.Autobots)
              this.m_player[2, index5].text = (index5 + index1 + 1).ToString();
          }
          if (UIAllianceWarBattle.BattleRoyale.AutobotPos > (byte) 0)
          {
            for (int index6 = 0; index6 < 6; ++index6)
              this.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1 + index6 * 3).gameObject.SetActive((int) UIAllianceWarBattle.BattleRoyale.AutobotPos != index1 + index6 + 1);
          }
        }
        if (UIAllianceWarBattle.BattleRoyale.Decepticon != null && UIAllianceWarBattle.BattleRoyale.Decepticons > (byte) 0 && (int) this.BattleRound <= (int) UIAllianceWarBattle.BattleRoyale.BattleMatchs)
        {
          int index7 = 0;
          for (int index8 = 0; index8 < (int) this.BattleRound; ++index8)
          {
            if (UIAllianceWarBattle.BattleRoyale.BattleMatch[index8].WinnerSide == (byte) 1)
              ++index7;
          }
          for (int index9 = 0; index9 < 6; ++index9)
          {
            if ((bool) (UnityEngine.Object) this.m_player[2, index9 + 6])
              this.m_player[2, index9 + 6].text = (string) null;
            if ((bool) (UnityEngine.Object) this.m_player[1, index9 + 2])
              this.m_player[1, index9 + 2].text = (string) null;
            if ((bool) (UnityEngine.Object) this.m_playerHint[index9 + 6])
              this.m_playerHint[index9 + 6].Parm2 = UIAllianceWarBattle.BattleRoyale.Decepticons;
            ((RectTransform) this.transform.GetChild(6).GetChild(1).GetChild(index9 <= 0 ? 0 : index9 + 1).GetChild(0).transform).sizeDelta = new Vector2(0.0f, 3f);
          }
          if (index7 < (int) UIAllianceWarBattle.BattleRoyale.Decepticons)
          {
            if ((bool) (UnityEngine.Object) this.m_player[1, 1] && UIAllianceWarBattle.BattleRoyale.Decepticon[index7].Name != null)
              this.m_player[1, 1].text = UIAllianceWarBattle.BattleRoyale.Decepticon[index7].Name.ToString();
            this.AllianceStr[3].ClearString();
            this.AllianceStr[3].uLongToFormat(UIAllianceWarBattle.BattleRoyale.Decepticon[index7].Power, bNumber: true);
            this.AllianceStr[3].AppendFormat("{0}");
            if ((bool) (UnityEngine.Object) this.m_player[1, 2])
            {
              this.m_player[1, 2].text = this.AllianceStr[3].ToString();
              ((Graphic) this.m_player[1, 2]).SetAllDirty();
              this.m_player[1, 2].cachedTextGenerator.Invalidate();
            }
            if (UIAllianceWarBattle.BattleRoyale.DecepticonTag != null && UIAllianceWarBattle.BattleRoyale.DecepticonTag.Length > 0)
            {
              this.AllianceStr[8].ClearString();
              this.AllianceStr[8].StringToFormat(UIAllianceWarBattle.BattleRoyale.DecepticonTag);
              this.AllianceStr[8].StringToFormat(UIAllianceWarBattle.BattleRoyale.Decepticon[index7].Name);
              this.AllianceStr[8].AppendFormat("[{0}]{1}");
              if ((bool) (UnityEngine.Object) this.m_player[1, 9])
              {
                this.m_player[1, 9].text = this.AllianceStr[8].ToString();
                ((Graphic) this.m_player[1, 9]).SetAllDirty();
                this.m_player[1, 9].cachedTextGenerator.Invalidate();
              }
            }
            if ((int) this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
            {
              this.AllianceStr[9].ClearString();
              this.AllianceStr[9].uLongToFormat((ulong) (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightSurvive + UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightDead), bNumber: true);
              this.AllianceStr[9].AppendFormat("{0}");
              if ((bool) (UnityEngine.Object) this.m_player[1, 10])
              {
                this.m_player[1, 10].text = this.AllianceStr[9].ToString();
                ((Graphic) this.m_player[1, 10]).SetAllDirty();
                this.m_player[1, 10].cachedTextGenerator.Invalidate();
                this.m_player[1, 10].cachedTextGeneratorForLayout.Invalidate();
              }
            }
            if (UIAllianceWarBattle.BattleRoyale.Decepticons > (byte) 0)
            {
              this.GM.ChangeHeroItemImg(this.transform.GetChild(8).GetChild(3).GetChild(0).transform, eHeroOrItem.Hero, UIAllianceWarBattle.BattleRoyale.Decepticon[index7].Head, (byte) 11, (byte) 0);
              if ((bool) (UnityEngine.Object) this.HeroButt[1].HeroHint)
                this.HeroButt[1].HeroHint.m_BtnID2 = index7;
              recordByKey = this.DM.HeroTable.GetRecordByKey(UIAllianceWarBattle.BattleRoyale.Decepticon[index7].Head);
              this.RightDyingSfx = recordByKey.DyingSound;
              this.RightHurtSfx = recordByKey.HurtSound;
            }
            if ((bool) (UnityEngine.Object) this.m_player[1, 10])
              this.transform.GetChild(8).GetChild(2).GetChild(0).GetChild(0).transform.localPosition = new Vector3((float) ((double) this.m_player[1, 10].preferredWidth / -2.0 - 30.0), 0.0f, 0.0f);
            if ((bool) (UnityEngine.Object) this.m_player[1, 1])
            {
              ((RectTransform) this.transform.GetChild(6).GetChild(1).GetChild(0).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[1, 1].preferredWidth, ((Graphic) this.m_player[1, 1]).rectTransform.sizeDelta.x), 3f);
              if (this.GM.IsArabic)
                ((RectTransform) this.transform.GetChild(6).GetChild(1).GetChild(0).GetChild(0).transform).anchoredPosition = new Vector2(((Graphic) this.m_player[1, 1]).rectTransform.sizeDelta.x - Math.Min(this.m_player[1, 1].preferredWidth, ((Graphic) this.m_player[0, 1]).rectTransform.sizeDelta.x), -12f);
            }
          }
          else
          {
            if ((bool) (UnityEngine.Object) this.m_player[1, 1])
              this.m_player[1, 1].text = (string) null;
            this.transform.GetChild(6).GetChild(1).GetChild(1).gameObject.SetActive(false);
          }
          this.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(21).gameObject.SetActive(true);
          for (int index10 = index7 + 1; index10 < (int) UIAllianceWarBattle.BattleRoyale.Decepticons && index10 < index7 + 6; ++index10)
          {
            if ((bool) (UnityEngine.Object) this.m_player[1, index10 + 2 - index7] && UIAllianceWarBattle.BattleRoyale.Decepticon[index10].Name != null)
            {
              this.m_player[1, index10 + 2 - index7].text = UIAllianceWarBattle.BattleRoyale.Decepticon[index10].Name.ToString();
              ((RectTransform) this.transform.GetChild(6).GetChild(1).GetChild(index10 + 1 - index7).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[1, index10 + 2 - index7].preferredWidth, ((Graphic) this.m_player[1, index10 + 2 - index7]).rectTransform.sizeDelta.x), 3f);
              if (this.GM.IsArabic)
                ((RectTransform) this.transform.GetChild(6).GetChild(1).GetChild(index10 + 1 - index7).GetChild(0).transform).anchoredPosition = new Vector2(((Graphic) this.m_player[1, index10 + 2 - index7]).rectTransform.sizeDelta.x - Math.Min(this.m_player[1, index10 + 2 - index7].preferredWidth, ((Graphic) this.m_player[1, index10 + 2 - index7]).rectTransform.sizeDelta.x), -12f);
            }
          }
          for (int index11 = 0; index11 < 6; ++index11)
          {
            if ((bool) (UnityEngine.Object) this.m_playerHint[index11 + 6])
              this.m_playerHint[index11 + 6].Parm2 = (byte) (index11 + index7);
            if ((bool) (UnityEngine.Object) this.m_player[2, index11 + 6] && index11 + index7 + 1 <= (int) UIAllianceWarBattle.BattleRoyale.Decepticons)
              this.m_player[2, index11 + 6].text = (index11 + index7 + 1).ToString();
          }
          if (UIAllianceWarBattle.BattleRoyale.DecepticonPos > (byte) 0)
          {
            for (int index12 = 0; index12 < 6; ++index12)
              this.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(1 + index12 * 3).gameObject.SetActive((int) UIAllianceWarBattle.BattleRoyale.DecepticonPos != index7 + index12 + 1);
          }
        }
        this.m_player[0, 14].text = this.m_player[2, 0].text;
        this.m_player[1, 14].text = this.m_player[2, 6].text;
        this.SetStage(UIAllianceWarBattle.MoveStage.MS_FIGHTING_START);
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_START:
        if ((UnityEngine.Object) this.ParticleEffect_InRight != (UnityEngine.Object) null && !this.ParticleEffect_InRight.gameObject.activeSelf)
          this.ParticleEffect_InRight = (GameObject) null;
        if ((UnityEngine.Object) this.ParticleEffect_InLeft != (UnityEngine.Object) null && !this.ParticleEffect_InLeft.gameObject.activeSelf)
          this.ParticleEffect_InLeft = (GameObject) null;
        this.Rand = this.GetRand();
        break;
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (arg1 != 5)
      ;
  }

  private void SetterWinner(bool LeftWin)
  {
    this.transform.GetChild(7).GetChild(5).gameObject.SetActive(LeftWin);
    this.transform.GetChild(8).GetChild(5).gameObject.SetActive(!LeftWin);
    if (LeftWin)
    {
      byte x = 0;
      for (int index = 0; index <= (int) this.BattleRound && index < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length; ++index)
      {
        if (UIAllianceWarBattle.BattleRoyale.BattleMatch[index].WinnerSide == (byte) 1)
          ++x;
        else
          x = (byte) 0;
      }
      if (x > (byte) 1)
      {
        this.AllianceStr[11].ClearString();
        this.AllianceStr[11].IntToFormat((long) x);
        this.AllianceStr[11].AppendFormat(this.DM.mStringTable.GetStringByID(14619U));
        this.m_player[0, 13].text = this.AllianceStr[11].ToString();
        ((Graphic) this.m_player[0, 13]).SetAllDirty();
        this.m_player[0, 13].cachedTextGenerator.Invalidate();
      }
      else
        this.m_player[0, 13].text = x <= (byte) 0 ? (string) null : this.DM.mStringTable.GetStringByID(14618U);
    }
    else
    {
      byte x = 0;
      for (int index = 0; index <= (int) this.BattleRound && index < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length; ++index)
      {
        if (UIAllianceWarBattle.BattleRoyale.BattleMatch[index].WinnerSide == (byte) 2)
          ++x;
        else
          x = (byte) 0;
      }
      if (x > (byte) 1)
      {
        this.AllianceStr[12].ClearString();
        this.AllianceStr[12].IntToFormat((long) x);
        this.AllianceStr[12].AppendFormat(this.DM.mStringTable.GetStringByID(14619U));
        this.m_player[1, 13].text = this.AllianceStr[12].ToString();
        ((Graphic) this.m_player[1, 13]).SetAllDirty();
        this.m_player[1, 13].cachedTextGenerator.Invalidate();
      }
      else
        this.m_player[1, 13].text = x <= (byte) 0 ? (string) null : this.DM.mStringTable.GetStringByID(14618U);
    }
  }

  private void CheckWinner()
  {
    if ((int) this.BattleRound >= UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
      return;
    if (UIAllianceWarBattle.BattleRoyale.BattleMatch != null && UIAllianceWarBattle.BattleRoyale.BattleMatch.Length > 0)
    {
      if (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].WinnerSide == (byte) 1)
      {
        if (UIAllianceWarBattle.BattleRoyale.BattleSide == (byte) 2)
        {
          this.m_player[1, 11].text = this.DM.mStringTable.GetStringByID(14622U);
          this.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
          this.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
        }
        else
        {
          this.m_player[0, 11].text = this.DM.mStringTable.GetStringByID(14621U);
          this.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
          this.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
        }
      }
      else if (UIAllianceWarBattle.BattleRoyale.BattleSide == (byte) 1)
      {
        this.m_player[0, 11].text = this.DM.mStringTable.GetStringByID(14622U);
        this.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
        this.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
      }
      else
      {
        this.m_player[1, 11].text = this.DM.mStringTable.GetStringByID(14621U);
        this.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
        this.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
      }
    }
    else if (UIAllianceWarBattle.BattleRoyale.Autobots > (byte) 0)
    {
      if (UIAllianceWarBattle.BattleRoyale.BattleSide == (byte) 2)
      {
        this.m_player[1, 11].text = this.DM.mStringTable.GetStringByID(14622U);
        this.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
        this.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
      }
      else
      {
        this.m_player[0, 11].text = this.DM.mStringTable.GetStringByID(14621U);
        this.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
        this.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
      }
    }
    else if (UIAllianceWarBattle.BattleRoyale.BattleSide == (byte) 1)
    {
      this.m_player[0, 11].text = this.DM.mStringTable.GetStringByID(14622U);
      this.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
      this.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
    }
    else
    {
      this.m_player[1, 11].text = this.DM.mStringTable.GetStringByID(14621U);
      this.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
      this.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
    }
  }

  private void SetHeroMove(GameObject Go, int Pos = -1, float time = 0, float scale = 0)
  {
    if ((UnityEngine.Object) Go == (UnityEngine.Object) null)
      return;
    Go.transform.localScale = Vector3.one;
    Go.transform.localPosition = Vector3.zero;
    Go.transform.localRotation = Quaternion.identity;
    this.Rotation[Pos >= 1 ? 1 : 0] = uTweenRotation.Begin(Go, Vector3.zero, new Vector3(0.0f, 0.0f, (float) (Pos * 25)), 0.2f, 0.5f);
    this.Rotation[Pos >= 1 ? 1 : 0].loopStyle = LoopStyle.Loop;
    this.Position[Pos >= 1 ? 1 : 0] = uTweenPosition.Begin(Go, Vector3.zero, new Vector3((float) (Pos * -60), 0.0f, 0.0f), 0.5f);
  }

  public void onFinish()
  {
  }

  private static void SearchChange(string input)
  {
  }

  public bool RequestBattleOrder(bool Replay = false)
  {
    if (Replay)
    {
      ActivityManager.Instance.AllianceWarMgr.ReplayGame = AllianceBattle.BattleRoyaleView.GameRound;
      this.transform.GetChild(13).GetChild(0).gameObject.SetActive(false);
    }
    else
      AllianceBattle.BattleRoyale.SetData(ActivityManager.Instance.AllianceWarMgr.RegisterData, ActivityManager.Instance.AllianceWarMgr.WaitData);
    UIAllianceWarBattle.BattleRoyale = !Replay ? AllianceBattle.BattleRoyale : AllianceBattle.BattleRoyaleView;
    ActivityManager.Instance.AllianceWarMgr.bReplaying = this.BattleReplay = UIAllianceWarBattle.BattleRoyale.OnLive == (byte) 0 && (Replay || ActivityManager.Instance.AW_bcalculateEnd);
    ActivityManager.Instance.AllianceWarMgr.MyAllySide = this.BattleSide = UIAllianceWarBattle.BattleRoyale.BattleSide;
    ActivityManager.Instance.AllianceWarMgr.MyPosition = this.BattlePosition = UIAllianceWarBattle.BattleRoyale.BattlePosition;
    return true;
  }

  public static void RecvBattleStation(MessagePacket MP)
  {
  }

  public static void RecvBattleStationView(MessagePacket MP)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (UnityEngine.Object) menu)
      return;
    menu.OpenMenu(EGUIWindow.UI_AllianceWarBattle, arg2: 1);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if ((bool) (UnityEngine.Object) this.m_WorldWarZ)
      sender.ControlFadeOut.SetActive(false);
    if (GUIManager.Instance.m_Arena_Hint == null)
      return;
    GUIManager.Instance.m_Arena_Hint.Hide();
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    ActivityManager.Instance.AllianceWarMgr.m_AllianceWarHintData.Name.ClearString();
    ActivityManager.Instance.AllianceWarMgr.m_AllianceWarHintData.AllianceTagTag = string.Empty;
    if (sender.Parm1 > (ushort) 0 && UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
      ActivityManager.Instance.AllianceWarMgr.m_AllianceWarHintData.AllianceTagTag = UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString();
    else if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
      ActivityManager.Instance.AllianceWarMgr.m_AllianceWarHintData.AllianceTagTag = UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString();
    if (sender.Parm1 > (ushort) 0 && UIAllianceWarBattle.BattleRoyale.Decepticon != null && (int) sender.Parm2 < (int) UIAllianceWarBattle.BattleRoyale.Decepticons)
    {
      ActivityManager.Instance.AllianceWarMgr.m_AllianceWarHintData.Name.Append(UIAllianceWarBattle.BattleRoyale.Decepticon[(int) sender.Parm2].Name);
    }
    else
    {
      if (sender.Parm1 > (ushort) 0 || UIAllianceWarBattle.BattleRoyale.Autobot == null || (int) sender.Parm2 >= (int) UIAllianceWarBattle.BattleRoyale.Autobots)
        return;
      ActivityManager.Instance.AllianceWarMgr.m_AllianceWarHintData.Name.Append(UIAllianceWarBattle.BattleRoyale.Autobot[(int) sender.Parm2].Name);
    }
    this.HintButt = sender.transform;
    ActivityManager.Instance.AllianceWarMgr.Send_MSG_REQUEST_ALLIANCEWAR_MATCH_PLAYERDATA((byte) ((uint) UIAllianceWarBattle.BattleRoyale.MatchID - 1U), (byte) sender.Parm1, sender.Parm1 <= (ushort) 0 ? (byte) ((int) UIAllianceWarBattle.BattleRoyale.Autobots - (int) sender.Parm2) : (byte) ((int) UIAllianceWarBattle.BattleRoyale.Decepticons - (int) sender.Parm2));
  }

  public static void ResetMatchID()
  {
    UIAllianceWarBattle.MatchID = (byte) 0;
    UIAllianceWarBattle.ReplayTime = 0.0;
  }

  public override void OnClose()
  {
    if (this.BattleReplay)
    {
      UIAllianceWarBattle.MatchID = UIAllianceWarBattle.BattleRoyale.MatchID;
      UIAllianceWarBattle.ReplayTime = (double) Time.time - this.BattleTime;
    }
    else
      UIAllianceWarBattle.ReplayTime = (double) (UIAllianceWarBattle.MatchID = (byte) 0);
    AudioManager.Instance.StopMP3AndPlayBGM();
    if (this.LeftRightInit)
      LeftRightFly.Release();
    UnityEngine.Object.Destroy((UnityEngine.Object) this.Duke);
    for (int index = 0; index < 10; ++index)
    {
      if (this.m_Str[index] != null)
        StringManager.Instance.DeSpawnString(this.m_Str[index]);
    }
    for (int index = 0; index < 20; ++index)
    {
      if (this.AllianceStr[index] != null)
        StringManager.Instance.DeSpawnString(this.AllianceStr[index]);
    }
    if ((UnityEngine.Object) this.ParticleEffect_Hit != (UnityEngine.Object) null)
    {
      if (this.ParticleEffect_Hit.activeSelf && (UnityEngine.Object) ParticleManager.Instance.AllEffectObject != (UnityEngine.Object) null)
        this.ParticleEffect_Hit.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
      this.ParticleEffect_Hit = (GameObject) null;
    }
    if ((UnityEngine.Object) this.ParticleEffect_Burst != (UnityEngine.Object) null)
    {
      if (this.ParticleEffect_Burst.activeSelf && (UnityEngine.Object) ParticleManager.Instance.AllEffectObject != (UnityEngine.Object) null)
        this.ParticleEffect_Burst.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
      this.ParticleEffect_Burst = (GameObject) null;
    }
    if ((UnityEngine.Object) this.ParticleEffect_InRight != (UnityEngine.Object) null)
    {
      if (this.ParticleEffect_InRight.activeSelf && (UnityEngine.Object) ParticleManager.Instance.AllEffectObject != (UnityEngine.Object) null)
        this.ParticleEffect_InRight.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
      this.ParticleEffect_InRight = (GameObject) null;
    }
    if ((UnityEngine.Object) this.ParticleEffect_InLeft != (UnityEngine.Object) null)
    {
      if (this.ParticleEffect_InLeft.activeSelf && (UnityEngine.Object) ParticleManager.Instance.AllEffectObject != (UnityEngine.Object) null)
        this.ParticleEffect_InLeft.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
      this.ParticleEffect_InLeft = (GameObject) null;
    }
    StringManager.Instance.DeSpawnString(this.DeadCountsStr[0]);
    StringManager.Instance.DeSpawnString(this.DeadCountsStr[1]);
    Time.timeScale = 1f;
    this.Destroy();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (!ActivityManager.Instance.AW_bcalculateEnd || this.bReturn)
      return;
    if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None || this.DM.RoleAlliance.Id == 0U)
    {
      this.bExit = true;
    }
    else
    {
      if (arg1 == 1)
        this.Refresh();
      if (arg1 == 6)
      {
        if (this.LeftRightInit)
        {
          if (UIAllianceWarBattle.BattleRoyale.BattleMatch != null && UIAllianceWarBattle.BattleRoyale.BattleMatch.Length > 0)
          {
            if (UIAllianceWarBattle.BattleRoyale.BattleSide == (byte) 1 && UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
              LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString(), (ushort) 0, this.BattleSide == (byte) 2, UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].WinnerSide == (byte) 1);
            else if (UIAllianceWarBattle.BattleRoyale.BattleSide == (byte) 2 && UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
              LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString(), (ushort) 0, this.BattleSide == (byte) 2, UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].WinnerSide == (byte) 2);
            else if (UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].WinnerSide == (byte) 1 && UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
              LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString(), (ushort) 0, false, true);
            else if (UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].WinnerSide == (byte) 2 && UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
              LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString(), (ushort) 0, true, true);
          }
          else if (UIAllianceWarBattle.BattleRoyale.BattleSide == (byte) 1)
          {
            if (UIAllianceWarBattle.BattleRoyale.Autobots > (byte) 0 && UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
              LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString(), (ushort) 0, this.BattleSide == (byte) 2, true);
            else if (UIAllianceWarBattle.BattleRoyale.Decepticons > (byte) 0 && UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
              LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString(), (ushort) 0, this.BattleSide == (byte) 2, false);
          }
          else if (UIAllianceWarBattle.BattleRoyale.BattleSide == (byte) 2)
          {
            if (UIAllianceWarBattle.BattleRoyale.Autobots > (byte) 0 && UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
              LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString(), (ushort) 0, this.BattleSide == (byte) 2, false);
            else if (UIAllianceWarBattle.BattleRoyale.Decepticons > (byte) 0 && UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
              LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString(), (ushort) 0, this.BattleSide == (byte) 2, true);
          }
          else if (UIAllianceWarBattle.BattleRoyale.Autobots > (byte) 0 && UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
            LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString(), (ushort) 0, false, true);
          else if (UIAllianceWarBattle.BattleRoyale.Decepticons > (byte) 0 && UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
            LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString(), (ushort) 0, true, true);
        }
        this.bEnd = true;
        this.transform.GetChild(13).GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(13).GetChild(1).GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(13).GetChild(1).GetChild(3).gameObject.SetActive(false);
        this.transform.GetChild(13).GetChild(1).GetChild(4).gameObject.SetActive(false);
        this.transform.GetChild(7).GetChild(5).gameObject.SetActive(false);
        this.transform.GetChild(8).GetChild(5).gameObject.SetActive(false);
        this.transform.GetChild(8).GetChild(6).gameObject.SetActive(false);
        this.transform.GetChild(7).GetChild(6).gameObject.SetActive(false);
        this.transform.GetChild(9).GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1f;
        if (!this.BattleReplay && this.AllianceStr[10] != null)
        {
          if (UIAllianceWarBattle.BattleRoyale.BattleSide > (byte) 0)
          {
            this.AllianceStr[10].ClearString();
            bool flag = UIAllianceWarBattle.BattleRoyale.BattleMatch == null || UIAllianceWarBattle.BattleRoyale.BattleMatch.Length <= 0 ? UIAllianceWarBattle.BattleRoyale.Autobots > (byte) 0 && UIAllianceWarBattle.BattleRoyale.BattleSide == (byte) 1 : (int) UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].WinnerSide == (int) UIAllianceWarBattle.BattleRoyale.BattleSide;
            if ((bool) (UnityEngine.Object) this.m_player[2, 12] && ActivityManager.Instance.AW_Round > (byte) 0)
            {
              this.transform.GetChild(10).gameObject.SetActive(true);
              if (flag)
              {
                switch (ActivityManager.Instance.AW_Round)
                {
                  case 1:
                    this.AllianceStr[10].StringToFormat(this.DM.mStringTable.GetStringByID(14637U));
                    break;
                  case 2:
                    this.AllianceStr[10].StringToFormat(this.DM.mStringTable.GetStringByID(14638U));
                    break;
                  case 3:
                    this.AllianceStr[10].StringToFormat(this.DM.mStringTable.GetStringByID(14607U));
                    break;
                  default:
                    this.AllianceStr[10].Append(this.DM.mStringTable.GetStringByID(14624U));
                    break;
                }
                if (ActivityManager.Instance.AW_Round < (byte) 4)
                  this.AllianceStr[10].AppendFormat(this.DM.mStringTable.GetStringByID(14623U));
                this.m_player[2, 12].text = this.AllianceStr[10].ToString();
                ((Graphic) this.m_player[2, 12]).SetAllDirty();
                this.m_player[2, 12].cachedTextGenerator.Invalidate();
              }
              else
                this.m_player[2, 12].text = ActivityManager.Instance.AW_Round >= (byte) 4 ? this.DM.mStringTable.GetStringByID(14634U) : this.DM.mStringTable.GetStringByID(14626U);
            }
          }
          else
          {
            this.AllianceStr[10].ClearString();
            if (UIAllianceWarBattle.BattleRoyale.BattleMatch != null && UIAllianceWarBattle.BattleRoyale.BattleMatch.Length > 0)
            {
              if (UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].WinnerSide == (byte) 1)
              {
                if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
                  this.AllianceStr[10].StringToFormat(UIAllianceWarBattle.BattleRoyale.AutobotTag);
              }
              else if (UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
                this.AllianceStr[10].StringToFormat(UIAllianceWarBattle.BattleRoyale.DecepticonTag);
            }
            else if (UIAllianceWarBattle.BattleRoyale.Autobots > (byte) 0)
            {
              if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
                this.AllianceStr[10].StringToFormat(UIAllianceWarBattle.BattleRoyale.AutobotTag);
            }
            else if (UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
              this.AllianceStr[10].StringToFormat(UIAllianceWarBattle.BattleRoyale.DecepticonTag);
            if ((bool) (UnityEngine.Object) this.m_player[2, 12] && ActivityManager.Instance.AW_Round > (byte) 0)
            {
              this.transform.GetChild(10).gameObject.SetActive(true);
              switch (ActivityManager.Instance.AW_Round)
              {
                case 1:
                  this.AllianceStr[10].StringToFormat(this.DM.mStringTable.GetStringByID(14637U));
                  break;
                case 2:
                  this.AllianceStr[10].StringToFormat(this.DM.mStringTable.GetStringByID(14638U));
                  break;
                case 3:
                  this.AllianceStr[10].StringToFormat(this.DM.mStringTable.GetStringByID(14607U));
                  break;
                default:
                  this.AllianceStr[10].AppendFormat(this.DM.mStringTable.GetStringByID(14629U));
                  break;
              }
              if (ActivityManager.Instance.AW_Round < (byte) 4)
                this.AllianceStr[10].AppendFormat(this.DM.mStringTable.GetStringByID(14628U));
              this.m_player[2, 12].text = this.AllianceStr[10].ToString();
              ((Graphic) this.m_player[2, 12]).SetAllDirty();
              this.m_player[2, 12].cachedTextGenerator.Invalidate();
            }
          }
        }
      }
      else if (arg1 == 7)
      {
        if (UIAllianceWarBattle.BattleRoyale.BattleMatch != null && UIAllianceWarBattle.BattleRoyale.BattleMatch.Length > 0)
        {
          UIAllianceWarBattle.BattleRoyale.BattleWinner = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound >= (int) UIAllianceWarBattle.BattleRoyale.BattleMatchs ? (int) UIAllianceWarBattle.BattleRoyale.BattleMatchs - 1 : (int) this.BattleRound].WinnerSide != (byte) 1 ? (byte) 2 : (byte) 1;
          if (this.BattleRound > (byte) 0 && (int) this.BattleRound <= UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
            this.LastWinner = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound - 1].WinnerSide;
          this.transform.GetChild(7).GetChild(0).GetChild(0).gameObject.SetActive(this.bEnd);
          this.transform.GetChild(8).GetChild(0).GetChild(0).gameObject.SetActive(this.bEnd);
          this.transform.GetChild(7).GetChild(1).gameObject.SetActive(this.bEnd);
          this.transform.GetChild(8).GetChild(1).gameObject.SetActive(this.bEnd);
          this.transform.GetChild(7).GetChild(2).gameObject.SetActive(!this.bEnd);
          this.transform.GetChild(8).GetChild(2).gameObject.SetActive(!this.bEnd);
          this.transform.GetChild(7).GetChild(3).gameObject.SetActive(!this.bEnd);
          this.transform.GetChild(8).GetChild(3).gameObject.SetActive(!this.bEnd);
          if (this.bEnd)
          {
            this.AllianceStr[6].ClearString();
            this.AllianceStr[6].uLongToFormat((ulong) UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].LeftSurvive, bNumber: true);
            this.AllianceStr[6].AppendFormat("{0}");
            if ((bool) (UnityEngine.Object) this.m_player[0, 10])
            {
              this.m_player[0, 10].text = this.AllianceStr[6].ToString();
              ((Graphic) this.m_player[0, 10]).SetAllDirty();
              this.m_player[0, 10].cachedTextGenerator.Invalidate();
            }
            this.AllianceStr[9].ClearString();
            this.AllianceStr[9].uLongToFormat((ulong) UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].RightSurvive, bNumber: true);
            this.AllianceStr[9].AppendFormat("{0}");
            if ((bool) (UnityEngine.Object) this.m_player[1, 10])
            {
              this.m_player[1, 10].text = this.AllianceStr[9].ToString();
              ((Graphic) this.m_player[1, 10]).SetAllDirty();
              this.m_player[1, 10].cachedTextGenerator.Invalidate();
            }
          }
        }
        else
          UIAllianceWarBattle.BattleRoyale.BattleWinner = UIAllianceWarBattle.BattleRoyale.Autobots <= (byte) 0 ? (byte) 2 : (byte) 1;
        if (this.bEnd)
        {
          if (UIAllianceWarBattle.BattleRoyale.BattleWinner > (byte) 0 && (bool) (UnityEngine.Object) this.EmblemScale[(int) UIAllianceWarBattle.BattleRoyale.BattleWinner - 1])
            this.EmblemScale[(int) UIAllianceWarBattle.BattleRoyale.BattleWinner - 1].enabled = true;
          if (UIAllianceWarBattle.BattleRoyale.BattleMatch != null && UIAllianceWarBattle.BattleRoyale.BattleMatch.Length > 0)
          {
            if (UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].WinnerSide == (byte) 1)
            {
              if (UIAllianceWarBattle.BattleRoyale.BattleSide == (byte) 2)
              {
                ((Behaviour) this.m_player[1, 12]).enabled = true;
                this.m_player[1, 12].text = this.DM.mStringTable.GetStringByID(14622U);
                this.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
              }
              else
              {
                ((Behaviour) this.m_player[0, 11]).enabled = true;
                this.transform.GetChild(6).GetChild(0).GetChild(13).gameObject.SetActive(true);
                this.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
              }
            }
            else if (UIAllianceWarBattle.BattleRoyale.BattleSide == (byte) 1)
            {
              ((Behaviour) this.m_player[0, 12]).enabled = true;
              this.m_player[0, 12].text = this.DM.mStringTable.GetStringByID(14622U);
              this.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
            }
            else
            {
              ((Behaviour) this.m_player[1, 11]).enabled = true;
              this.transform.GetChild(6).GetChild(1).GetChild(13).gameObject.SetActive(true);
              this.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
            }
          }
          else if (UIAllianceWarBattle.BattleRoyale.Autobots > (byte) 0)
          {
            if (UIAllianceWarBattle.BattleRoyale.BattleSide == (byte) 2)
            {
              ((Behaviour) this.m_player[1, 12]).enabled = true;
              this.m_player[1, 12].text = this.DM.mStringTable.GetStringByID(14622U);
              this.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
            }
            else
            {
              ((Behaviour) this.m_player[0, 11]).enabled = true;
              this.transform.GetChild(6).GetChild(0).GetChild(13).gameObject.SetActive(true);
              this.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
            }
          }
          else if (UIAllianceWarBattle.BattleRoyale.BattleSide == (byte) 1)
          {
            ((Behaviour) this.m_player[0, 12]).enabled = true;
            this.m_player[0, 12].text = this.DM.mStringTable.GetStringByID(14622U);
            this.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
          }
          else
          {
            ((Behaviour) this.m_player[1, 11]).enabled = true;
            this.transform.GetChild(6).GetChild(1).GetChild(13).gameObject.SetActive(true);
            this.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
          }
        }
      }
      if (arg1 != 10)
        return;
      GUIManager.Instance.m_Arena_Hint.ShowHint((byte) 1, this.HintButt.GetComponent<RectTransform>());
    }
  }

  public override bool OnBackButtonClick() => false;

  public void Destroy()
  {
    if ((UnityEngine.Object) this.go != (UnityEngine.Object) null)
    {
      this.go.transform.SetParent(this.Hero_Pos.parent, false);
      UnityEngine.Object.Destroy((UnityEngine.Object) this.go);
    }
    if ((UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.Hero_Model);
    this.Hero_Model = (Transform) null;
    this.go = (GameObject) null;
  }

  protected void Run(double RoundTime)
  {
    if (RoundTime >= (double) ActivityManager.Instance.AW_FightTime || (double) ActivityManager.Instance.AW_FightTime - RoundTime >= 2.0)
      return;
    for (int index = 0; index < 2; ++index)
    {
      if ((bool) (UnityEngine.Object) this.Rotation[index])
      {
        this.Rotation[index].Toggle();
        this.Rotation[index] = (uTweenRotation) null;
        this.CheckWinner();
      }
      if ((bool) (UnityEngine.Object) this.Position[index])
      {
        this.Position[index].Toggle();
        this.Position[index] = (uTweenPosition) null;
        this.CheckWinner();
      }
    }
  }

  private int GetRand() => UnityEngine.Random.Range(0, 3);

  protected void RunHeroState(
    GameObject LeftHero,
    GameObject RightHero,
    bool LeftHeroWin,
    double NowRoundTime)
  {
    if (this.MovieStage == UIAllianceWarBattle.MoveStage.MS_FINISH)
      return;
    switch (this.MovieStage)
    {
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_START:
        this.transform.GetChild(7).GetChild(2).gameObject.SetActive(true);
        this.transform.GetChild(7).GetChild(6).gameObject.SetActive(true);
        this.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
        this.transform.GetChild(8).GetChild(2).gameObject.SetActive(true);
        this.transform.GetChild(8).GetChild(6).gameObject.SetActive(true);
        this.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
        this.transform.GetChild(6).GetChild(0).GetChild(13).gameObject.SetActive(false);
        this.transform.GetChild(6).GetChild(1).GetChild(13).gameObject.SetActive(false);
        Transform transform1 = LeftHero.transform;
        Vector3 one1 = Vector3.one;
        RightHero.transform.localScale = one1;
        Vector3 vector3_1 = one1;
        transform1.localScale = vector3_1;
        Transform transform2 = LeftHero.transform;
        Vector3 zero1 = Vector3.zero;
        RightHero.transform.localPosition = zero1;
        Vector3 vector3_2 = zero1;
        transform2.localPosition = vector3_2;
        Transform transform3 = LeftHero.transform;
        Quaternion identity1 = Quaternion.identity;
        RightHero.transform.localRotation = identity1;
        Quaternion quaternion1 = identity1;
        transform3.localRotation = quaternion1;
        Transform child = LeftHero.transform.GetChild(0);
        Vector3 one2 = Vector3.one;
        RightHero.transform.GetChild(0).localScale = one2;
        Vector3 vector3_3 = one2;
        child.localScale = vector3_3;
        LeftHero.transform.gameObject.SetActive(true);
        RightHero.transform.gameObject.SetActive(true);
        RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
        for (int index = 0; index < 2; ++index)
        {
          ((Graphic) this.HeroButt[index].HeroHint.HIImage).color = Color.white;
          ((Graphic) this.HeroButt[index].HeroHint.CircleImage).color = Color.white;
          ((Graphic) this.transform.GetChild(6).GetChild(index + 4).gameObject.GetComponent<Image>()).color = Color.white;
        }
        if (NowRoundTime > 0.5)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_MOVE;
          LeftHero.transform.GetChild(0).localScale = Vector3.one;
          RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
          float num = 0.0f;
          if (NowRoundTime > 0.0)
            num = DamageValueManager.easeOutCubic(4f, 1f, (float) (NowRoundTime / 0.5));
          if (this.LastWinner == (byte) 1 || this.LastWinner == (byte) 0)
          {
            this.transform.GetChild(6).GetChild(5).gameObject.SetActive(true);
            RightHero.transform.GetChild(0).localScale = new Vector3(num * -1f, num, num);
          }
          if (this.LastWinner == (byte) 2 || this.LastWinner == (byte) 0)
          {
            this.transform.GetChild(6).GetChild(4).gameObject.SetActive(true);
            LeftHero.transform.GetChild(0).localScale = new Vector3(num, num, num);
          }
          if (NowRoundTime > 0.25)
          {
            if ((this.LastWinner == (byte) 1 || this.LastWinner == (byte) 0) && (UnityEngine.Object) this.ParticleEffect_InRight == (UnityEngine.Object) null)
            {
              if ((double) Time.timeScale > 0.0)
                AudioManager.Instance.PlayUISFX(UIKind.CutIn);
              this.ParticleEffect_InRight = ParticleManager.Instance.Spawn((ushort) 430, this.transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
              this.ParticleEffect_InRight.transform.localPosition = new Vector3(113f, -58f, -800f);
              this.ParticleEffect_InRight.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
              GUIManager.Instance.SetLayer(this.ParticleEffect_InRight, 5);
            }
            if ((this.LastWinner == (byte) 2 || this.LastWinner == (byte) 0) && (UnityEngine.Object) this.ParticleEffect_InLeft == (UnityEngine.Object) null)
            {
              if ((double) Time.timeScale > 0.0)
                AudioManager.Instance.PlayUISFX(UIKind.CutIn);
              this.ParticleEffect_InLeft = ParticleManager.Instance.Spawn((ushort) 430, this.transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
              this.ParticleEffect_InLeft.transform.localPosition = new Vector3(-113f, -58f, -800f);
              this.ParticleEffect_InLeft.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
              GUIManager.Instance.SetLayer(this.ParticleEffect_InLeft, 5);
            }
          }
          if (NowRoundTime > 0.0)
          {
            float a = DamageValueManager.easeOutCubic(0.0f, 1f, (float) (NowRoundTime / 0.5));
            if (this.LastWinner == (byte) 1 || this.LastWinner == (byte) 0)
            {
              Image component1 = RightHero.transform.GetChild(0).GetComponent<Image>();
              if ((bool) (UnityEngine.Object) component1)
                ((Graphic) component1).color = new Color(1f, 1f, 1f, a);
              Image component2 = RightHero.transform.GetChild(1).GetComponent<Image>();
              if ((bool) (UnityEngine.Object) component2)
                ((Graphic) component2).color = new Color(1f, 1f, 1f, a);
            }
            if (this.LastWinner == (byte) 2 || this.LastWinner == (byte) 0)
            {
              Image component3 = LeftHero.transform.GetChild(0).GetComponent<Image>();
              if ((bool) (UnityEngine.Object) component3)
                ((Graphic) component3).color = new Color(1f, 1f, 1f, a);
              Image component4 = LeftHero.transform.GetChild(1).GetComponent<Image>();
              if ((bool) (UnityEngine.Object) component4)
                ((Graphic) component4).color = new Color(1f, 1f, 1f, a);
            }
            ((Graphic) this.transform.GetChild(6).GetChild(4).gameObject.GetComponent<Image>()).color = new Color(1f, 1f, 1f, a);
            ((Graphic) this.transform.GetChild(6).GetChild(5).gameObject.GetComponent<Image>()).color = new Color(1f, 1f, 1f, a);
          }
        }
        if (!((UnityEngine.Object) this.ParticleEffect_Hit != (UnityEngine.Object) null) || this.ParticleEffect_Hit.gameObject.activeSelf)
          break;
        this.ParticleEffect_Hit = (GameObject) null;
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_MOVE:
        if (NowRoundTime > 1.2000000476837158)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_PULL;
          this.transform.GetChild(6).GetChild(4).gameObject.SetActive(false);
          this.transform.GetChild(6).GetChild(5).gameObject.SetActive(false);
          Transform transform4 = LeftHero.transform;
          Vector3 one3 = Vector3.one;
          RightHero.transform.localScale = one3;
          Vector3 vector3_4 = one3;
          transform4.localScale = vector3_4;
          Transform transform5 = LeftHero.transform;
          Vector3 zero2 = Vector3.zero;
          RightHero.transform.localPosition = zero2;
          Vector3 vector3_5 = zero2;
          transform5.localPosition = vector3_5;
          Transform transform6 = LeftHero.transform;
          Quaternion identity2 = Quaternion.identity;
          RightHero.transform.localRotation = identity2;
          Quaternion quaternion2 = identity2;
          transform6.localRotation = quaternion2;
          RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
          break;
        }
        float num1 = NowRoundTime <= 1.25 ? (NowRoundTime <= 1.0 ? (NowRoundTime <= 0.75 ? DamageValueManager.easeOutCubic(1f, 1.5f, (float) ((NowRoundTime - 0.5) / 0.25)) : DamageValueManager.easeOutCubic(1.5f, 1f, (float) ((NowRoundTime - 0.75) / 0.25))) : DamageValueManager.easeOutCubic(1f, 1.2f, (float) ((NowRoundTime - 1.0) / 0.25))) : DamageValueManager.easeOutCubic(1.2f, 1f, (float) ((NowRoundTime - 1.25) / 0.25));
        if (this.LastWinner == (byte) 1 || this.LastWinner == (byte) 0)
          RightHero.transform.localScale = new Vector3(num1, num1, num1);
        if (this.LastWinner != (byte) 2 && this.LastWinner != (byte) 0)
          break;
        LeftHero.transform.localScale = new Vector3(num1, num1, num1);
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_PULL:
        if (NowRoundTime >= 2.059999942779541)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_ATTACK;
          LeftHero.transform.localPosition = new Vector3(-53f, -15f, 0.0f);
          RightHero.transform.localPosition = new Vector3(53f, -15f, 0.0f);
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 15f));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -15f));
          break;
        }
        Vector2 zero3 = Vector2.zero;
        Vector2 zero4 = Vector2.zero;
        if (NowRoundTime < 1.5)
        {
          Vector2 vector2_1 = new Vector2(0.0f, 0.0f);
          Vector2 vector2_2 = new Vector2(45f, 15f);
          float t = (float) (NowRoundTime - 1.2000000476837158) / 0.3f;
          zero3.x = Mathf.Lerp(vector2_1.x, -vector2_2.x, t);
          zero3.y = Mathf.Lerp(vector2_1.y, -vector2_2.y, t);
          zero4.x = Mathf.Lerp(vector2_1.x, vector2_2.x, t);
          zero4.y = Mathf.Lerp(vector2_1.y, -vector2_2.y, t);
          float z = Mathf.Lerp(0.0f, 15f, t);
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, z));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -z));
          LeftHero.transform.localPosition = new Vector3(zero3.x, zero3.y, 0.0f);
          RightHero.transform.localPosition = new Vector3(zero4.x, zero4.y, 0.0f);
          break;
        }
        float t1 = (float) (NowRoundTime - 1.5) / 0.56f;
        Vector2 vector2_3 = new Vector2(45f, 15f);
        Vector2 vector2_4 = new Vector2(53f, 15f);
        zero3.x = Mathf.Lerp(-vector2_3.x, -vector2_4.x, t1);
        zero3.y = Mathf.Lerp(-vector2_3.y, -vector2_4.y, t1);
        zero4.x = Mathf.Lerp(vector2_3.x, vector2_4.x, t1);
        zero4.y = Mathf.Lerp(-vector2_3.y, -vector2_4.y, t1);
        float z1 = Mathf.Lerp(15f, 25f, t1);
        LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, z1));
        RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -z1));
        LeftHero.transform.localPosition = new Vector3(zero3.x, zero3.y, 0.0f);
        RightHero.transform.localPosition = new Vector3(zero4.x, zero4.y, 0.0f);
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_ATTACK:
        float num2 = 2.06f;
        float num3 = 2.19f;
        float num4 = 0.07f;
        if (NowRoundTime >= (double) num3)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_SPLIT;
          LeftHero.transform.localPosition = new Vector3(75f, 35f, 0.0f);
          RightHero.transform.localPosition = new Vector3(-75f, 35f, 0.0f);
          RightHero.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
          LeftHero.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -15f));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 15f));
          break;
        }
        Vector2 vector2_5 = new Vector2(53f, 15f);
        Vector2 vector2_6 = new Vector2(75f, 35f);
        Vector2 zero5 = Vector2.zero;
        Vector2 zero6 = Vector2.zero;
        if (NowRoundTime - (double) num2 < (double) num4)
        {
          float t2 = ((float) NowRoundTime - num2) / num4;
          zero5.x = Mathf.Lerp(-vector2_5.x, vector2_6.x, t2);
          zero5.y = Mathf.Lerp(-vector2_5.y, vector2_6.y, t2);
          zero6.x = Mathf.Lerp(vector2_5.x, -vector2_6.x, t2);
          zero6.y = Mathf.Lerp(-vector2_5.y, vector2_6.y, t2);
          float z2 = Mathf.Lerp(-15f, 15f, t2);
          LeftHero.transform.localPosition = new Vector3(zero5.x, zero5.y, 0.0f);
          RightHero.transform.localPosition = new Vector3(zero6.x, zero6.y, 0.0f);
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -z2));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, z2));
          if (!((UnityEngine.Object) this.ParticleEffect_Hit == (UnityEngine.Object) null))
            break;
          if ((double) Time.timeScale > 0.0)
            AudioManager.Instance.PlayUISFX(UIKind.Score_Hit);
          AudioManager.Instance.PlaySFX(this.LeftHurtSfx, pitchkind: PitchKind.Hit);
          AudioManager.Instance.PlaySFX(this.RightHurtSfx, pitchkind: PitchKind.Hit);
          this.ParticleEffect_Hit = ParticleManager.Instance.Spawn((ushort) 431, this.transform.GetChild(9).transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
          this.ParticleEffect_Hit.transform.localPosition = new Vector3(0.0f, 80f, -800f);
          this.ParticleEffect_Hit.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
          GUIManager.Instance.SetLayer(this.ParticleEffect_Hit, 5);
          break;
        }
        float num5 = Mathf.Lerp(1f, 1.5f, ((float) NowRoundTime - num2) / (num3 - num2 - num4));
        RightHero.transform.localScale = new Vector3(num5, num5, num5);
        LeftHero.transform.localScale = new Vector3(num5, num5, num5);
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_SPLIT:
        float num6 = 2.19f;
        float num7 = 2.32f;
        if (NowRoundTime > (double) num7)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_DAMAGE;
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 15f));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -15f));
          LeftHero.transform.localScale = Vector3.one;
          RightHero.transform.localScale = Vector3.one;
          LeftHero.transform.localPosition = new Vector3(-51f, 27f, 0.0f);
          RightHero.transform.localPosition = new Vector3(51f, 27f, 0.0f);
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 15f));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -15f));
          if ((double) Time.timeScale <= 0.0)
            break;
          AudioManager.Instance.PlaySFX((ushort) 40059, pitchkind: PitchKind.Hit);
          break;
        }
        float num8 = ((float) NowRoundTime - num6) / (num7 - num6);
        float num9 = 0.5f;
        if ((double) num8 < (double) num9)
        {
          float num10 = num8 / num9;
          LeftHero.transform.localPosition = new Vector3((float) (75.0 - 126.0 * (double) num8), (float) (35.0 - 8.0 * (double) num10), 0.0f);
          RightHero.transform.localPosition = new Vector3((float) (126.0 * (double) num8 - 75.0), (float) (35.0 - 8.0 * (double) num10), 0.0f);
          break;
        }
        LeftHero.transform.localPosition = new Vector3(-51f, 27f, 0.0f);
        RightHero.transform.localPosition = new Vector3(51f, 27f, 0.0f);
        float num11 = (num8 - num9) / num9;
        LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, (float) (30.0 * (double) num11 - 15.0)));
        RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, (float) (15.0 - 30.0 * (double) num11)));
        float num12 = (float) (1.3999999761581421 - 0.40000000596046448 * (double) num11);
        LeftHero.transform.localScale = new Vector3(num12, num12, num12);
        RightHero.transform.localScale = new Vector3(num12, num12, num12);
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_DAMAGE:
        if (NowRoundTime > 3.8900001049041748)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_BURST;
          this.burstRotationSpeed = (float) UnityEngine.Random.Range(2, 5);
          this.burstRotationSpeed *= UnityEngine.Random.Range(0, 2) != 0 ? 1f : -1f;
          this.burstScaleSpeed = (float) UnityEngine.Random.Range(2, 5);
          this.burstScaleSpeed *= UnityEngine.Random.Range(0, 2) != 0 ? 1f : -1f;
          if ((int) this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
          {
            uint rightSurvive = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightSurvive;
            uint leftSurvive = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftSurvive;
            this.AllianceStr[6].ClearString();
            this.AllianceStr[6].uLongToFormat((ulong) leftSurvive, bNumber: true);
            this.AllianceStr[6].AppendFormat("{0}");
            if ((bool) (UnityEngine.Object) this.m_player[0, 10])
            {
              this.m_player[0, 10].text = this.AllianceStr[6].ToString();
              ((Graphic) this.m_player[0, 10]).SetAllDirty();
              this.m_player[0, 10].cachedTextGenerator.Invalidate();
            }
            this.AllianceStr[9].ClearString();
            this.AllianceStr[9].uLongToFormat((ulong) rightSurvive, bNumber: true);
            this.AllianceStr[9].AppendFormat("{0}");
            if ((bool) (UnityEngine.Object) this.m_player[1, 10])
            {
              this.m_player[1, 10].text = this.AllianceStr[9].ToString();
              ((Graphic) this.m_player[1, 10]).SetAllDirty();
              this.m_player[1, 10].cachedTextGenerator.Invalidate();
            }
          }
          if ((UnityEngine.Object) this.ParticleEffect_Burst != (UnityEngine.Object) null && !this.ParticleEffect_Burst.gameObject.activeSelf)
            this.ParticleEffect_Burst = (GameObject) null;
          if (this.GM.IsArabic)
          {
            Transform transform7 = this.transform.GetChild(7).GetChild(2).GetChild(0).transform;
            Vector3 vector3_6 = new Vector3(-1f, 1f, 1f);
            this.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector3_6;
            Vector3 vector3_7 = vector3_6;
            transform7.localScale = vector3_7;
          }
          else
          {
            Transform transform8 = this.transform.GetChild(7).GetChild(2).GetChild(0).transform;
            Vector3 one4 = Vector3.one;
            this.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = one4;
            Vector3 vector3_8 = one4;
            transform8.localScale = vector3_8;
          }
          if ((int) this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
          {
            if (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftDead > 0U)
            {
              this.DeadCountsStr[0].ClearString();
              this.DeadCountsStr[0].IntToFormat((long) -UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftDead, bNumber: true);
              this.DeadCountsStr[0].AppendFormat("{0}");
              this.DeadCounts[0].text = this.DeadCountsStr[0].ToString();
              if (this.GM.IsArabic)
                ((Transform) ((Graphic) this.DeadCounts[0]).rectTransform).localScale = new Vector3(-0.7f, 0.7f, 0.7f);
              else
                ((Transform) ((Graphic) this.DeadCounts[0]).rectTransform).localScale = new Vector3(0.7f, 0.7f, 0.7f);
            }
            if (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightDead > 0U)
            {
              this.DeadCountsStr[1].ClearString();
              this.DeadCountsStr[1].IntToFormat((long) -UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightDead, bNumber: true);
              this.DeadCountsStr[1].AppendFormat("{0}");
              this.DeadCounts[1].text = this.DeadCountsStr[1].ToString();
              if (this.GM.IsArabic)
                ((Transform) ((Graphic) this.DeadCounts[1]).rectTransform).localScale = new Vector3(-0.7f, 0.7f, 0.7f);
              else
                ((Transform) ((Graphic) this.DeadCounts[1]).rectTransform).localScale = new Vector3(0.7f, 0.7f, 0.7f);
            }
          }
          if (LeftHeroWin)
          {
            AudioManager.Instance.PlaySFX(this.RightDyingSfx, pitchkind: PitchKind.Hit);
            break;
          }
          AudioManager.Instance.PlaySFX(this.LeftDyingSfx, pitchkind: PitchKind.Hit);
          break;
        }
        float num13 = 1f;
        if (NowRoundTime > 3.5899999141693115)
        {
          num13 = (float) (6.1866631507873535 - 1.3333324193954468 * NowRoundTime);
          if ((double) num13 < 1.0)
            num13 = 1f;
        }
        else if (NowRoundTime > 2.4900000095367432)
          num13 = 1.4f;
        else if (NowRoundTime > 2.19)
        {
          num13 = (float) (1.3333334922790527 * NowRoundTime - 1.9200003147125244);
          if ((double) num13 > 1.3999999761581421)
            num13 = 1.4f;
        }
        if (this.GM.IsArabic)
        {
          Transform transform9 = this.transform.GetChild(7).GetChild(2).GetChild(0).transform;
          Vector3 vector3_9 = num13 * new Vector3(-1f, 1f, 1f);
          this.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector3_9;
          Vector3 vector3_10 = vector3_9;
          transform9.localScale = vector3_10;
        }
        else
        {
          Transform transform10 = this.transform.GetChild(7).GetChild(2).GetChild(0).transform;
          Vector3 vector3_11 = num13 * Vector3.one;
          this.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector3_11;
          Vector3 vector3_12 = vector3_11;
          transform10.localScale = vector3_12;
        }
        if ((int) this.BattleRound >= UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
          break;
        float num14 = 3.89f - (float) NowRoundTime;
        if ((double) num14 < 0.0)
          num14 = 0.0f;
        float num15 = num14 / 1.57f;
        if ((double) num15 > 1.0)
          num15 = 1f;
        uint x1 = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightSurvive + (uint) ((double) num15 * (double) UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightDead);
        uint x2 = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftSurvive + (uint) ((double) num15 * (double) UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftDead);
        this.AllianceStr[6].ClearString();
        this.AllianceStr[6].uLongToFormat((ulong) x2, bNumber: true);
        this.AllianceStr[6].AppendFormat("{0}");
        if ((bool) (UnityEngine.Object) this.m_player[0, 10])
        {
          this.m_player[0, 10].text = this.AllianceStr[6].ToString();
          ((Graphic) this.m_player[0, 10]).SetAllDirty();
          this.m_player[0, 10].cachedTextGenerator.Invalidate();
        }
        this.AllianceStr[9].ClearString();
        this.AllianceStr[9].uLongToFormat((ulong) x1, bNumber: true);
        this.AllianceStr[9].AppendFormat("{0}");
        if (!(bool) (UnityEngine.Object) this.m_player[1, 10])
          break;
        this.m_player[1, 10].text = this.AllianceStr[9].ToString();
        ((Graphic) this.m_player[1, 10]).SetAllDirty();
        this.m_player[1, 10].cachedTextGenerator.Invalidate();
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_BURST:
        if (NowRoundTime > 4.96999979019165)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_END;
          this.SetterWinner(LeftHeroWin);
          this.burstScaleSpeed = this.burstRotationSpeed = 0.0f;
          GameObject gameObject1;
          GameObject gameObject2;
          if (LeftHeroWin)
          {
            gameObject1 = LeftHero;
            gameObject2 = RightHero;
          }
          else
          {
            gameObject1 = RightHero;
            gameObject2 = LeftHero;
          }
          if ((UnityEngine.Object) gameObject1 != (UnityEngine.Object) null)
          {
            if (!gameObject1.activeSelf)
              gameObject1.SetActive(true);
            Transform transform11 = gameObject1.transform;
            if ((UnityEngine.Object) transform11 != (UnityEngine.Object) null)
            {
              transform11.localPosition = new Vector3(!LeftHeroWin ? 51f : -51f, 27f, 0.0f);
              transform11.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, !LeftHeroWin ? -15f : 15f));
              transform11.localScale = Vector3.one;
              Color color = new Color(1f, 1f, 1f, 1f);
              ((Graphic) transform11.GetChild(0).GetComponent<Image>()).color = color;
              ((Graphic) transform11.GetChild(1).GetComponent<Image>()).color = color;
            }
          }
          if ((UnityEngine.Object) gameObject2 != (UnityEngine.Object) null && gameObject2.activeSelf)
          {
            gameObject2.SetActive(false);
            Color color = new Color(1f, 1f, 1f, 1f);
            ((Graphic) gameObject2.transform.GetChild(0).GetComponent<Image>()).color = color;
            ((Graphic) gameObject2.transform.GetChild(1).GetComponent<Image>()).color = color;
            this.transform.GetChild(!LeftHeroWin ? 7 : 8).GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(!LeftHeroWin ? 7 : 8).GetChild(6).gameObject.SetActive(false);
          }
          this.DeadCounts[0].text = string.Empty;
          this.DeadCounts[1].text = string.Empty;
          break;
        }
        GameObject gameObject3 = !LeftHeroWin ? LeftHero : RightHero;
        if (!((UnityEngine.Object) gameObject3 != (UnityEngine.Object) null))
          break;
        Transform transform12 = gameObject3.transform;
        if ((UnityEngine.Object) transform12 != (UnityEngine.Object) null)
        {
          transform12.localPosition = new Vector3(!LeftHeroWin ? -51f : 51f, 27f, 0.0f);
          if (NowRoundTime > 4.070000171661377)
          {
            if (NowRoundTime > 4.0900001525878906 && (UnityEngine.Object) this.ParticleEffect_Burst == (UnityEngine.Object) null)
            {
              if ((double) Time.timeScale > 0.0)
                AudioManager.Instance.PlayUISFX(UIKind.Explosion);
              this.ParticleEffect_Burst = ParticleManager.Instance.Spawn((ushort) 432, transform12, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
              this.ParticleEffect_Burst.transform.localPosition = new Vector3(0.0f, 0.0f, -800f);
              this.ParticleEffect_Burst.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
              GUIManager.Instance.SetLayer(this.ParticleEffect_Burst, 5);
            }
            Color color = new Color(1f, 1f, 1f, 0.0f);
            ((Graphic) transform12.GetChild(0).GetComponent<Image>()).color = color;
            ((Graphic) transform12.GetChild(1).GetComponent<Image>()).color = color;
          }
          else
          {
            float num16 = transform12.localScale.x + this.burstScaleSpeed * 10f * Time.deltaTime * this.FightTimeScale;
            if ((double) num16 > 1.0499999523162842)
            {
              num16 = 1.05f;
              this.burstScaleSpeed = -(float) UnityEngine.Random.Range(2, 5);
            }
            else if ((double) num16 < 1.0)
            {
              num16 = 1f;
              this.burstScaleSpeed = (float) UnityEngine.Random.Range(2, 5);
            }
            transform12.localScale = num16 * Vector3.one;
            float z3 = transform12.localEulerAngles.z + this.burstRotationSpeed * 300f * Time.deltaTime * this.FightTimeScale;
            if ((double) z3 > 180.0)
              z3 -= 360f;
            if ((double) z3 > 0.0)
            {
              if ((double) z3 > 21.0)
              {
                z3 = 21f;
                this.burstRotationSpeed = -(float) UnityEngine.Random.Range(2, 5);
              }
              else if ((double) z3 < 16.0)
              {
                z3 = 16f;
                this.burstRotationSpeed = (float) UnityEngine.Random.Range(2, 5);
              }
            }
            else if ((double) z3 < 0.0)
            {
              if ((double) z3 < -21.0)
              {
                z3 = -21f;
                this.burstRotationSpeed = (float) UnityEngine.Random.Range(2, 5);
              }
              else if ((double) z3 > -16.0)
              {
                z3 = -16f;
                this.burstRotationSpeed = -(float) UnityEngine.Random.Range(2, 5);
              }
            }
            transform12.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, z3));
          }
        }
        float num17 = NowRoundTime >= 4.070000171661377 ? (NowRoundTime >= 4.570000171661377 ? 0.7f : EasingEffect.InQuadratic((float) NowRoundTime - 4.07f, 1.2f, -0.5f, 0.5f)) : EasingEffect.Linear((float) NowRoundTime - 3.89f, 0.0f, 1.2f, 0.18f);
        if (this.GM.IsArabic)
          ((Transform) ((Graphic) this.DeadCounts[0]).rectTransform).localScale = new Vector3(-num17, num17, num17);
        else
          ((Transform) ((Graphic) this.DeadCounts[0]).rectTransform).localScale = new Vector3(num17, num17, num17);
        ((Transform) ((Graphic) this.DeadCounts[1]).rectTransform).localScale = ((Transform) ((Graphic) this.DeadCounts[0]).rectTransform).localScale;
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_END:
        if (NowRoundTime > 5.9000000953674316)
        {
          if (LeftHeroWin)
          {
            this.transform.GetChild(8).GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(8).GetChild(6).gameObject.SetActive(false);
            Transform transform13 = RightHero.transform;
            Vector3 zero7 = Vector3.zero;
            RightHero.transform.transform.GetChild(0).localScale = zero7;
            Vector3 vector3_13 = zero7;
            transform13.localScale = vector3_13;
            RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
          }
          else
          {
            this.transform.GetChild(7).GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(7).GetChild(6).gameObject.SetActive(false);
            Transform transform14 = LeftHero.transform;
            Vector3 zero8 = Vector3.zero;
            LeftHero.transform.transform.GetChild(0).localScale = zero8;
            Vector3 vector3_14 = zero8;
            transform14.localScale = vector3_14;
          }
          Transform transform15 = LeftHero.transform;
          Vector3 zero9 = Vector3.zero;
          RightHero.transform.localPosition = zero9;
          Vector3 vector3_15 = zero9;
          transform15.localPosition = vector3_15;
          Transform transform16 = LeftHero.transform;
          Quaternion identity3 = Quaternion.identity;
          RightHero.transform.localRotation = identity3;
          Quaternion quaternion3 = identity3;
          transform16.localRotation = quaternion3;
          if (this.GM.IsArabic)
          {
            Transform transform17 = ((Component) this.m_player[0, 13]).transform;
            Vector3 vector3_16 = new Vector3(-1f, 0.0f, 0.0f);
            ((Component) this.m_player[1, 13]).transform.localScale = vector3_16;
            Vector3 vector3_17 = vector3_16;
            transform17.localScale = vector3_17;
          }
          else
          {
            Transform transform18 = ((Component) this.m_player[0, 13]).transform;
            Vector3 one5 = Vector3.one;
            ((Component) this.m_player[1, 13]).transform.localScale = one5;
            Vector3 vector3_18 = one5;
            transform18.localScale = vector3_18;
          }
          this.SetStage(UIAllianceWarBattle.MoveStage.MS_FIGHTING);
          break;
        }
        float num18 = 5.066666f;
        float num19 = 5.2f;
        GameObject gameObject4 = !LeftHeroWin ? RightHero : LeftHero;
        if (!((UnityEngine.Object) gameObject4 != (UnityEngine.Object) null))
          break;
        if (!gameObject4.activeSelf)
          gameObject4.SetActive(true);
        Transform transform19 = gameObject4.transform;
        if (!((UnityEngine.Object) transform19 != (UnityEngine.Object) null))
          break;
        float z4;
        float x3;
        float y;
        if (NowRoundTime > (double) num19)
        {
          double num20;
          z4 = (float) (num20 = 0.0);
          x3 = (float) num20;
          y = (float) num20;
        }
        else if (NowRoundTime > (double) num18)
        {
          float num21 = 74.9998f;
          float num22 = -389.998962f;
          y = num21 * (float) NowRoundTime + num22;
          if (LeftHeroWin)
          {
            float num23 = 119.999687f;
            float num24 = -623.998352f;
            x3 = num23 * (float) NowRoundTime + num24;
            float num25 = 37.4999f;
            float num26 = -194.999481f;
            z4 = num25 * (float) NowRoundTime + num26;
          }
          else
          {
            x3 = 623.998352f + -119.999687f * (float) NowRoundTime;
            z4 = 194.999481f + -37.4999f * (float) NowRoundTime;
          }
        }
        else
        {
          y = 1929.31677f + -382.759918f * (float) NowRoundTime;
          if (LeftHeroWin)
          {
            float num27 = 362.0702f;
            float num28 = -1850.48889f;
            x3 = num27 * (float) NowRoundTime + num28;
            z4 = 1043.2793f + -206.897263f * (float) NowRoundTime;
          }
          else
          {
            x3 = 1850.48889f + -362.0702f * (float) NowRoundTime;
            float num29 = 206.897263f;
            float num30 = -1043.2793f;
            z4 = num29 * (float) NowRoundTime + num30;
          }
        }
        transform19.localPosition = new Vector3(x3, y, 0.0f);
        transform19.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, z4));
        float num31 = NowRoundTime <= 5.086249828338623 ? (NowRoundTime <= 5.2024998664855957 ? (float) (1290.3221435546875 * NowRoundTime - 6312.90087890625) : 100f) : (float) (6812.90087890625 - 1290.3221435546875 * NowRoundTime);
        if ((double) num31 < 100.0)
          num31 = 100f;
        if ((double) num31 > 250.0)
          num31 = 250f;
        float num32 = num31 * 0.01f;
        if (this.GM.IsArabic)
        {
          Transform transform20 = ((Component) this.m_player[0, 13]).transform;
          Vector3 vector3_19 = num32 * new Vector3(-1f, 1f, 1f);
          ((Component) this.m_player[1, 13]).transform.localScale = vector3_19;
          Vector3 vector3_20 = vector3_19;
          transform20.localScale = vector3_20;
          break;
        }
        Transform transform21 = ((Component) this.m_player[0, 13]).transform;
        Vector3 vector3_21 = num32 * Vector3.one;
        ((Component) this.m_player[1, 13]).transform.localScale = vector3_21;
        Vector3 vector3_22 = vector3_21;
        transform21.localScale = vector3_22;
        break;
    }
  }

  protected void RunHeroStateA(
    GameObject LeftHero,
    GameObject RightHero,
    bool LeftHeroWin,
    double NowRoundTime)
  {
    if (this.MovieStage == UIAllianceWarBattle.MoveStage.MS_FINISH)
      return;
    switch (this.MovieStage)
    {
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_START:
        this.transform.GetChild(7).GetChild(6).gameObject.SetActive(true);
        this.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
        this.transform.GetChild(8).GetChild(6).gameObject.SetActive(true);
        this.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
        this.transform.GetChild(6).GetChild(0).GetChild(13).gameObject.SetActive(false);
        this.transform.GetChild(6).GetChild(1).GetChild(13).gameObject.SetActive(false);
        Transform transform1 = LeftHero.transform;
        Vector3 one1 = Vector3.one;
        RightHero.transform.localScale = one1;
        Vector3 vector3_1 = one1;
        transform1.localScale = vector3_1;
        Transform transform2 = LeftHero.transform;
        Vector3 zero1 = Vector3.zero;
        RightHero.transform.localPosition = zero1;
        Vector3 vector3_2 = zero1;
        transform2.localPosition = vector3_2;
        Transform transform3 = LeftHero.transform;
        Quaternion identity1 = Quaternion.identity;
        RightHero.transform.localRotation = identity1;
        Quaternion quaternion1 = identity1;
        transform3.localRotation = quaternion1;
        Transform child = LeftHero.transform.GetChild(0);
        Vector3 one2 = Vector3.one;
        RightHero.transform.GetChild(0).localScale = one2;
        Vector3 vector3_3 = one2;
        child.localScale = vector3_3;
        LeftHero.transform.gameObject.SetActive(true);
        RightHero.transform.gameObject.SetActive(true);
        RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
        for (int index = 0; index < 2; ++index)
        {
          ((Graphic) this.HeroButt[index].HeroHint.HIImage).color = Color.white;
          ((Graphic) this.HeroButt[index].HeroHint.CircleImage).color = Color.white;
          ((Graphic) this.transform.GetChild(6).GetChild(index + 4).gameObject.GetComponent<Image>()).color = Color.white;
        }
        if (NowRoundTime > 0.33000001311302185)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_MOVE;
          LeftHero.transform.GetChild(0).localScale = Vector3.one;
          RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
          float num = 0.0f;
          if (NowRoundTime > 0.0)
            num = DamageValueManager.easeOutCubic(4f, 1f, (float) (NowRoundTime / 0.33000001311302185));
          if (this.LastWinner == (byte) 1 || this.LastWinner == (byte) 0)
          {
            this.transform.GetChild(6).GetChild(5).gameObject.SetActive(true);
            RightHero.transform.GetChild(0).localScale = new Vector3(num * -1f, num, num);
          }
          if (this.LastWinner == (byte) 2 || this.LastWinner == (byte) 0)
          {
            this.transform.GetChild(6).GetChild(4).gameObject.SetActive(true);
            LeftHero.transform.GetChild(0).localScale = new Vector3(num, num, num);
          }
          if (NowRoundTime > 0.25)
          {
            if ((this.LastWinner == (byte) 1 || this.LastWinner == (byte) 0) && (UnityEngine.Object) this.ParticleEffect_InRight == (UnityEngine.Object) null)
            {
              if ((double) Time.timeScale > 0.0)
                AudioManager.Instance.PlayUISFX(UIKind.CutIn);
              this.ParticleEffect_InRight = ParticleManager.Instance.Spawn((ushort) 430, this.transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
              this.ParticleEffect_InRight.transform.localPosition = new Vector3(113f, -58f, -800f);
              this.ParticleEffect_InRight.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
              GUIManager.Instance.SetLayer(this.ParticleEffect_InRight, 5);
            }
            if ((this.LastWinner == (byte) 2 || this.LastWinner == (byte) 0) && (UnityEngine.Object) this.ParticleEffect_InLeft == (UnityEngine.Object) null)
            {
              if ((double) Time.timeScale > 0.0)
                AudioManager.Instance.PlayUISFX(UIKind.CutIn);
              this.ParticleEffect_InLeft = ParticleManager.Instance.Spawn((ushort) 430, this.transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
              this.ParticleEffect_InLeft.transform.localPosition = new Vector3(-113f, -58f, -800f);
              this.ParticleEffect_InLeft.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
              GUIManager.Instance.SetLayer(this.ParticleEffect_InLeft, 5);
            }
          }
          if (NowRoundTime > 0.0)
          {
            float a = DamageValueManager.easeOutCubic(0.0f, 1f, (float) (NowRoundTime / 0.33000001311302185));
            if (this.LastWinner == (byte) 1 || this.LastWinner == (byte) 0)
            {
              Image component1 = RightHero.transform.GetChild(0).GetComponent<Image>();
              if ((bool) (UnityEngine.Object) component1)
                ((Graphic) component1).color = new Color(1f, 1f, 1f, a);
              Image component2 = RightHero.transform.GetChild(1).GetComponent<Image>();
              if ((bool) (UnityEngine.Object) component2)
                ((Graphic) component2).color = new Color(1f, 1f, 1f, a);
            }
            if (this.LastWinner == (byte) 2 || this.LastWinner == (byte) 0)
            {
              Image component3 = LeftHero.transform.GetChild(0).GetComponent<Image>();
              if ((bool) (UnityEngine.Object) component3)
                ((Graphic) component3).color = new Color(1f, 1f, 1f, a);
              Image component4 = LeftHero.transform.GetChild(1).GetComponent<Image>();
              if ((bool) (UnityEngine.Object) component4)
                ((Graphic) component4).color = new Color(1f, 1f, 1f, a);
            }
            ((Graphic) this.transform.GetChild(6).GetChild(4).gameObject.GetComponent<Image>()).color = new Color(1f, 1f, 1f, a);
            ((Graphic) this.transform.GetChild(6).GetChild(5).gameObject.GetComponent<Image>()).color = new Color(1f, 1f, 1f, a);
          }
        }
        if (!((UnityEngine.Object) this.ParticleEffect_Hit != (UnityEngine.Object) null) || this.ParticleEffect_Hit.gameObject.activeSelf)
          break;
        this.ParticleEffect_Hit = (GameObject) null;
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_MOVE:
        if (NowRoundTime > 1.5)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_PULL;
          this.transform.GetChild(6).GetChild(4).gameObject.SetActive(false);
          this.transform.GetChild(6).GetChild(5).gameObject.SetActive(false);
          Transform transform4 = LeftHero.transform;
          Vector3 one3 = Vector3.one;
          RightHero.transform.localScale = one3;
          Vector3 vector3_4 = one3;
          transform4.localScale = vector3_4;
          Transform transform5 = LeftHero.transform;
          Vector3 zero2 = Vector3.zero;
          RightHero.transform.localPosition = zero2;
          Vector3 vector3_5 = zero2;
          transform5.localPosition = vector3_5;
          Transform transform6 = LeftHero.transform;
          Quaternion identity2 = Quaternion.identity;
          RightHero.transform.localRotation = identity2;
          Quaternion quaternion2 = identity2;
          transform6.localRotation = quaternion2;
          RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
          break;
        }
        float num1 = NowRoundTime <= 1.1000000238418579 ? (NowRoundTime <= 0.89999997615814209 ? (NowRoundTime <= 0.62999999523162842 ? EasingEffect.Linear((float) ((NowRoundTime - 0.33000001311302185) / 0.30000001192092896), 1f, 0.2f, 1f) : EasingEffect.Linear((float) ((NowRoundTime - 0.62999999523162842) / 0.27000001072883606), 1.2f, -0.2f, 1f)) : EasingEffect.Linear((float) ((NowRoundTime - 0.89999997615814209) / 0.20000000298023224), 1f, 0.1f, 1f)) : EasingEffect.Linear((float) ((NowRoundTime - 1.1000000238418579) / 0.40000000596046448), 1.1f, -0.1f, 1f);
        if (this.LastWinner == (byte) 1 || this.LastWinner == (byte) 0)
          RightHero.transform.localScale = new Vector3(num1, num1, num1);
        if (this.LastWinner != (byte) 2 && this.LastWinner != (byte) 0)
          break;
        LeftHero.transform.localScale = new Vector3(num1, num1, num1);
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_PULL:
        if (NowRoundTime >= 2.059999942779541)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_ATTACK;
          LeftHero.transform.localPosition = new Vector3(-23f, 0.0f, 0.0f);
          RightHero.transform.localPosition = new Vector3(23f, 0.0f, 0.0f);
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 15f));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -15f));
          break;
        }
        Vector2 zero3 = Vector2.zero;
        Vector2 zero4 = Vector2.zero;
        if (NowRoundTime < 1.7899999618530273)
        {
          Vector2 vector2_1 = new Vector2(0.0f, 0.0f);
          Vector2 vector2_2 = new Vector2(27f, 0.0f);
          float t = (float) (NowRoundTime - 1.5) / 0.29f;
          zero3.x = Mathf.Lerp(vector2_1.x, -vector2_2.x, t);
          zero4.x = Mathf.Lerp(vector2_1.x, vector2_2.x, t);
          float z = Mathf.Lerp(0.0f, 10f, t);
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, z));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -z));
          LeftHero.transform.localPosition = new Vector3(zero3.x, zero3.y, 0.0f);
          RightHero.transform.localPosition = new Vector3(zero4.x, zero4.y, 0.0f);
          break;
        }
        float t1 = (float) (NowRoundTime - 1.7899999618530273) / 0.27f;
        Vector2 vector2_3 = new Vector2(27f, 0.0f);
        Vector2 vector2_4 = new Vector2(23f, 0.0f);
        zero3.x = Mathf.Lerp(-vector2_3.x, -vector2_4.x, t1);
        zero4.x = Mathf.Lerp(vector2_3.x, vector2_4.x, t1);
        float z1 = Mathf.Lerp(10f, 30f, t1);
        LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, z1));
        RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -z1));
        LeftHero.transform.localPosition = new Vector3(zero3.x, zero3.y, 0.0f);
        RightHero.transform.localPosition = new Vector3(zero4.x, zero4.y, 0.0f);
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_ATTACK:
        float num2 = 2.06f;
        float num3 = 2.3f;
        float num4 = 0.07f;
        if (NowRoundTime >= (double) num3)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_SPLIT;
          LeftHero.transform.localPosition = new Vector3(75f, 97f, 0.0f);
          RightHero.transform.localPosition = new Vector3(-75f, 97f, 0.0f);
          RightHero.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
          LeftHero.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -10f));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 10f));
          break;
        }
        Vector2 vector2_5 = new Vector2(23f, 0.0f);
        Vector2 vector2_6 = new Vector2(75f, 0.0f);
        Vector2 zero5 = Vector2.zero;
        Vector2 zero6 = Vector2.zero;
        if (NowRoundTime - (double) num2 < (double) num4)
        {
          float t2 = ((float) NowRoundTime - num2) / num4;
          zero5.x = Mathf.Lerp(-vector2_5.x, vector2_6.x, t2);
          zero6.x = Mathf.Lerp(vector2_5.x, -vector2_6.x, t2);
          float z2 = Mathf.Lerp(30f, -10f, t2);
          LeftHero.transform.localPosition = new Vector3(zero5.x, zero5.y, 0.0f);
          RightHero.transform.localPosition = new Vector3(zero6.x, zero6.y, 0.0f);
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -z2));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, z2));
          float num5 = Mathf.Lerp(1f, 1.3f, t2);
          RightHero.transform.localScale = new Vector3(num5, num5, num5);
          LeftHero.transform.localScale = new Vector3(num5, num5, num5);
          break;
        }
        float t3 = ((float) NowRoundTime - num2) / (num3 - num2 - num4);
        vector2_5.Set(75f, 0.0f);
        vector2_6.Set(75f, 97f);
        zero5.y = Mathf.Lerp(vector2_5.y, vector2_6.y, t3);
        zero6.y = Mathf.Lerp(vector2_5.y, vector2_6.y, t3);
        float z3 = Mathf.Lerp(-10f, 10f, t3);
        LeftHero.transform.localPosition = new Vector3(vector2_5.x, zero5.y, 0.0f);
        RightHero.transform.localPosition = new Vector3(-vector2_5.x, zero6.y, 0.0f);
        LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -z3));
        RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, z3));
        float num6 = Mathf.Lerp(1.3f, 1.5f, t3);
        RightHero.transform.localScale = new Vector3(num6, num6, num6);
        LeftHero.transform.localScale = new Vector3(num6, num6, num6);
        if (!((UnityEngine.Object) this.ParticleEffect_Hit == (UnityEngine.Object) null))
          break;
        if ((double) Time.timeScale > 0.0)
          AudioManager.Instance.PlayUISFX(UIKind.Score_Hit);
        AudioManager.Instance.PlaySFX(this.LeftHurtSfx, pitchkind: PitchKind.Hit);
        AudioManager.Instance.PlaySFX(this.RightHurtSfx, pitchkind: PitchKind.Hit);
        this.ParticleEffect_Hit = ParticleManager.Instance.Spawn((ushort) 431, this.transform.GetChild(9).transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
        this.ParticleEffect_Hit.transform.localPosition = new Vector3(0.0f, 80f, -800f);
        this.ParticleEffect_Hit.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        GUIManager.Instance.SetLayer(this.ParticleEffect_Hit, 5);
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_SPLIT:
        float num7 = 2.3f;
        float num8 = 3.1f;
        float num9 = 0.3f;
        if (NowRoundTime > (double) num8)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_DAMAGE;
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 20f));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -20f));
          LeftHero.transform.localScale = Vector3.one;
          RightHero.transform.localScale = Vector3.one;
          LeftHero.transform.localPosition = new Vector3(-78f, 0.0f, 0.0f);
          RightHero.transform.localPosition = new Vector3(78f, 0.0f, 0.0f);
          if ((double) Time.timeScale <= 0.0)
            break;
          AudioManager.Instance.PlaySFX((ushort) 40059, pitchkind: PitchKind.Hit);
          break;
        }
        float num10 = ((float) NowRoundTime - num7) / (num8 - num7 - num9);
        float num11 = 0.0f;
        if (NowRoundTime - (double) num7 <= (double) num9)
        {
          float t4 = ((float) NowRoundTime - num7 - num11) / num9;
          LeftHero.transform.localPosition = Vector3.Lerp(new Vector3(75f, 97f, 0.0f), new Vector3(37f, 117f, 0.0f), t4);
          RightHero.transform.localPosition = Vector3.Lerp(new Vector3(-75f, 97f, 0.0f), new Vector3(-37f, 117f, 0.0f), t4);
          LeftHero.transform.localScale = Vector3.Lerp(new Vector3(1.5f, 1.5f, 1.5f), Vector3.one, t4);
          RightHero.transform.localScale = Vector3.Lerp(new Vector3(1.5f, 1.5f, 1.5f), Vector3.one, t4);
          LeftHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, 10f), new Vector3(0.0f, 0.0f, 35f), t4));
          RightHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, -10f), new Vector3(0.0f, 0.0f, -35f), t4));
          break;
        }
        float num12;
        if (NowRoundTime - (double) num7 <= (double) (num12 = num9 + 0.1f))
        {
          float num13 = num12 - 0.1f;
          float t5 = ((float) NowRoundTime - num7 - num13) / 0.1f;
          LeftHero.transform.localPosition = Vector3.Lerp(new Vector3(37f, 117f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), t5);
          RightHero.transform.localPosition = Vector3.Lerp(new Vector3(-37f, 117f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), t5);
          LeftHero.transform.localScale = Vector3.one;
          RightHero.transform.localScale = Vector3.one;
          LeftHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, 35f), new Vector3(0.0f, 0.0f, 0.0f), t5));
          RightHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, -35f), new Vector3(0.0f, 0.0f, 0.0f), t5));
          break;
        }
        float num14;
        if (NowRoundTime - (double) num7 <= (double) (num14 = num12 + 0.3f))
        {
          float num15 = num14 - 0.3f;
          float t6 = ((float) NowRoundTime - num7 - num15) / 0.3f;
          LeftHero.transform.localPosition = Vector3.Lerp(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(-45f, 27f, 0.0f), t6);
          RightHero.transform.localPosition = Vector3.Lerp(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(45f, 27f, 0.0f), t6);
          LeftHero.transform.localScale = Vector3.one;
          RightHero.transform.localScale = Vector3.one;
          LeftHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 30f), t6));
          RightHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, -30f), t6));
          break;
        }
        float num16;
        if (NowRoundTime - (double) num7 > (double) (num16 = num14 + 0.1f))
          break;
        float num17 = num16 - 0.1f;
        float t7 = ((float) NowRoundTime - num7 - num17) / 0.1f;
        LeftHero.transform.localPosition = Vector3.Lerp(new Vector3(-45f, 27f, 0.0f), new Vector3(-78f, 0.0f, 0.0f), t7);
        RightHero.transform.localPosition = Vector3.Lerp(new Vector3(45f, 27f, 0.0f), new Vector3(78f, 0.0f, 0.0f), t7);
        LeftHero.transform.localScale = Vector3.one;
        RightHero.transform.localScale = Vector3.one;
        LeftHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, 30f), new Vector3(0.0f, 0.0f, 20f), t7));
        RightHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, -30f), new Vector3(0.0f, 0.0f, -20f), t7));
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_DAMAGE:
        if (NowRoundTime > 3.7999999523162842)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_BURST;
          this.burstRotationSpeed = (float) UnityEngine.Random.Range(2, 5);
          this.burstRotationSpeed *= UnityEngine.Random.Range(0, 2) != 0 ? 1f : -1f;
          this.burstScaleSpeed = (float) UnityEngine.Random.Range(2, 5);
          this.burstScaleSpeed *= UnityEngine.Random.Range(0, 2) != 0 ? 1f : -1f;
          if ((int) this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
          {
            uint rightSurvive = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightSurvive;
            uint leftSurvive = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftSurvive;
            this.AllianceStr[6].ClearString();
            this.AllianceStr[6].uLongToFormat((ulong) leftSurvive, bNumber: true);
            this.AllianceStr[6].AppendFormat("{0}");
            if ((bool) (UnityEngine.Object) this.m_player[0, 10])
            {
              this.m_player[0, 10].text = this.AllianceStr[6].ToString();
              ((Graphic) this.m_player[0, 10]).SetAllDirty();
              this.m_player[0, 10].cachedTextGenerator.Invalidate();
            }
            this.AllianceStr[9].ClearString();
            this.AllianceStr[9].uLongToFormat((ulong) rightSurvive, bNumber: true);
            this.AllianceStr[9].AppendFormat("{0}");
            if ((bool) (UnityEngine.Object) this.m_player[1, 10])
            {
              this.m_player[1, 10].text = this.AllianceStr[9].ToString();
              ((Graphic) this.m_player[1, 10]).SetAllDirty();
              this.m_player[1, 10].cachedTextGenerator.Invalidate();
            }
          }
          if ((UnityEngine.Object) this.ParticleEffect_Burst != (UnityEngine.Object) null && !this.ParticleEffect_Burst.gameObject.activeSelf)
            this.ParticleEffect_Burst = (GameObject) null;
          if (this.GM.IsArabic)
          {
            Transform transform7 = this.transform.GetChild(7).GetChild(2).GetChild(0).transform;
            Vector3 vector3_6 = new Vector3(-1f, 1f, 1f);
            this.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector3_6;
            Vector3 vector3_7 = vector3_6;
            transform7.localScale = vector3_7;
          }
          else
          {
            Transform transform8 = this.transform.GetChild(7).GetChild(2).GetChild(0).transform;
            Vector3 one4 = Vector3.one;
            this.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = one4;
            Vector3 vector3_8 = one4;
            transform8.localScale = vector3_8;
          }
          if ((int) this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
          {
            if (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftDead > 0U)
            {
              this.DeadCountsStr[0].ClearString();
              this.DeadCountsStr[0].IntToFormat((long) -UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftDead, bNumber: true);
              this.DeadCountsStr[0].AppendFormat("{0}");
              this.DeadCounts[0].text = this.DeadCountsStr[0].ToString();
              if (this.GM.IsArabic)
                ((Transform) ((Graphic) this.DeadCounts[0]).rectTransform).localScale = new Vector3(-0.7f, 0.7f, 0.7f);
              else
                ((Transform) ((Graphic) this.DeadCounts[0]).rectTransform).localScale = new Vector3(0.7f, 0.7f, 0.7f);
            }
            if (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightDead > 0U)
            {
              this.DeadCountsStr[1].ClearString();
              this.DeadCountsStr[1].IntToFormat((long) -UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightDead, bNumber: true);
              this.DeadCountsStr[1].AppendFormat("{0}");
              this.DeadCounts[1].text = this.DeadCountsStr[1].ToString();
              if (this.GM.IsArabic)
                ((Transform) ((Graphic) this.DeadCounts[1]).rectTransform).localScale = new Vector3(-0.7f, 0.7f, 0.7f);
              else
                ((Transform) ((Graphic) this.DeadCounts[1]).rectTransform).localScale = new Vector3(0.7f, 0.7f, 0.7f);
            }
          }
          if (LeftHeroWin)
          {
            AudioManager.Instance.PlaySFX(this.RightDyingSfx, pitchkind: PitchKind.Hit);
            break;
          }
          AudioManager.Instance.PlaySFX(this.LeftDyingSfx, pitchkind: PitchKind.Hit);
          break;
        }
        float num18 = 1f;
        if (NowRoundTime > 3.5899999141693115)
        {
          num18 = (float) (6.1866631507873535 - 1.3333324193954468 * NowRoundTime);
          if ((double) num18 < 1.0)
            num18 = 1f;
        }
        else if (NowRoundTime > 2.4900000095367432)
          num18 = 1.4f;
        else if (NowRoundTime > 2.19)
        {
          num18 = (float) (1.3333334922790527 * NowRoundTime - 1.9200003147125244);
          if ((double) num18 > 1.3999999761581421)
            num18 = 1.4f;
        }
        if (this.GM.IsArabic)
        {
          Transform transform9 = this.transform.GetChild(7).GetChild(2).GetChild(0).transform;
          Vector3 vector3_9 = num18 * new Vector3(-1f, 1f, 1f);
          this.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector3_9;
          Vector3 vector3_10 = vector3_9;
          transform9.localScale = vector3_10;
        }
        else
        {
          Transform transform10 = this.transform.GetChild(7).GetChild(2).GetChild(0).transform;
          Vector3 vector3_11 = num18 * Vector3.one;
          this.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector3_11;
          Vector3 vector3_12 = vector3_11;
          transform10.localScale = vector3_12;
        }
        if ((int) this.BattleRound >= UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
          break;
        float num19 = 3.8f - (float) NowRoundTime;
        if ((double) num19 < 0.0)
          num19 = 0.0f;
        float num20 = num19 / 1.57f;
        if ((double) num20 > 1.0)
          num20 = 1f;
        uint x1 = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightSurvive + (uint) ((double) num20 * (double) UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightDead);
        uint x2 = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftSurvive + (uint) ((double) num20 * (double) UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftDead);
        this.AllianceStr[6].ClearString();
        this.AllianceStr[6].uLongToFormat((ulong) x2, bNumber: true);
        this.AllianceStr[6].AppendFormat("{0}");
        if ((bool) (UnityEngine.Object) this.m_player[0, 10])
        {
          this.m_player[0, 10].text = this.AllianceStr[6].ToString();
          ((Graphic) this.m_player[0, 10]).SetAllDirty();
          this.m_player[0, 10].cachedTextGenerator.Invalidate();
        }
        this.AllianceStr[9].ClearString();
        this.AllianceStr[9].uLongToFormat((ulong) x1, bNumber: true);
        this.AllianceStr[9].AppendFormat("{0}");
        if (!(bool) (UnityEngine.Object) this.m_player[1, 10])
          break;
        this.m_player[1, 10].text = this.AllianceStr[9].ToString();
        ((Graphic) this.m_player[1, 10]).SetAllDirty();
        this.m_player[1, 10].cachedTextGenerator.Invalidate();
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_BURST:
        if (NowRoundTime > 5.619999885559082)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_END;
          this.SetterWinner(LeftHeroWin);
          this.burstScaleSpeed = this.burstRotationSpeed = 0.0f;
          GameObject gameObject1;
          GameObject gameObject2;
          if (LeftHeroWin)
          {
            gameObject1 = LeftHero;
            gameObject2 = RightHero;
          }
          else
          {
            gameObject1 = RightHero;
            gameObject2 = LeftHero;
          }
          if ((UnityEngine.Object) gameObject1 != (UnityEngine.Object) null)
          {
            if (!gameObject1.activeSelf)
              gameObject1.SetActive(true);
            Transform transform11 = gameObject1.transform;
            if ((UnityEngine.Object) transform11 != (UnityEngine.Object) null)
            {
              transform11.localPosition = Vector3.zero;
              transform11.localRotation = Quaternion.Euler(Vector3.zero);
              transform11.localScale = Vector3.one;
              Color color = new Color(1f, 1f, 1f, 1f);
              ((Graphic) transform11.GetChild(0).GetComponent<Image>()).color = color;
              ((Graphic) transform11.GetChild(1).GetComponent<Image>()).color = color;
            }
          }
          if ((UnityEngine.Object) gameObject2 != (UnityEngine.Object) null && gameObject2.activeSelf)
          {
            gameObject2.SetActive(false);
            Color color = new Color(1f, 1f, 1f, 1f);
            ((Graphic) gameObject2.transform.GetChild(0).GetComponent<Image>()).color = color;
            ((Graphic) gameObject2.transform.GetChild(1).GetComponent<Image>()).color = color;
            this.transform.GetChild(!LeftHeroWin ? 7 : 8).GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(!LeftHeroWin ? 7 : 8).GetChild(6).gameObject.SetActive(false);
          }
          this.DeadCounts[0].text = string.Empty;
          this.DeadCounts[1].text = string.Empty;
          break;
        }
        GameObject gameObject = !LeftHeroWin ? LeftHero : RightHero;
        if (!((UnityEngine.Object) gameObject != (UnityEngine.Object) null))
          break;
        Transform transform12 = gameObject.transform;
        if ((UnityEngine.Object) transform12 != (UnityEngine.Object) null)
        {
          if (NowRoundTime > 4.1999998092651367)
          {
            bool flag = true;
            if (NowRoundTime <= 4.3299999237060547)
            {
              flag = false;
              float t8 = (float) (NowRoundTime - 4.1999998092651367) / 0.13f;
              transform12.localScale = Vector3.Lerp(new Vector3(1f, 1f, 1f), new Vector3(1.2f, 1.2f, 1.2f), t8);
              transform12.localRotation = !LeftHeroWin ? Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 30f), t8)) : Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, -30f), t8));
            }
            else if (NowRoundTime <= 4.4600000381469727)
            {
              flag = false;
              float t9 = (float) (NowRoundTime - 4.3299999237060547) / 0.13f;
              transform12.localScale = Vector3.Lerp(new Vector3(1.2f, 1.2f, 1.2f), new Vector3(1.3f, 1.3f, 1.3f), t9);
              if (LeftHeroWin)
              {
                transform12.localPosition = Vector3.Lerp(new Vector3(78f, 0.0f, 0.0f), new Vector3(128f, 107f, 0.0f), t9);
                transform12.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, -30f), new Vector3(0.0f, 0.0f, -60f), t9));
              }
              else
              {
                transform12.localPosition = Vector3.Lerp(new Vector3(-78f, 0.0f, 0.0f), new Vector3((float) sbyte.MinValue, 107f, 0.0f), t9);
                transform12.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, 30f), new Vector3(0.0f, 0.0f, 60f), t9));
              }
            }
            else if (NowRoundTime <= 4.8600001335144043)
            {
              float t10 = (float) (NowRoundTime - 4.4600000381469727) / 0.4f;
              transform12.localScale = Vector3.Lerp(new Vector3(1.3f, 1.3f, 1.3f), new Vector3(1.1f, 1.1f, 1.1f), t10);
              transform12.localPosition = !LeftHeroWin ? Vector3.Lerp(new Vector3((float) sbyte.MinValue, 107f, 0.0f), new Vector3(-185f, 84f, 0.0f), t10) : Vector3.Lerp(new Vector3(128f, 107f, 0.0f), new Vector3(185f, 84f, 0.0f), t10);
            }
            else if (NowRoundTime <= 5.2600002288818359)
            {
              float t11 = (float) (NowRoundTime - 4.8600001335144043) / 0.4f;
              transform12.localScale = Vector3.Lerp(new Vector3(1.1f, 1.1f, 1.1f), new Vector3(1f, 1f, 1f), t11);
              transform12.localPosition = !LeftHeroWin ? Vector3.Lerp(new Vector3(-185f, 84f, 0.0f), new Vector3(-210f, -160f, 0.0f), t11) : Vector3.Lerp(new Vector3(185f, 84f, 0.0f), new Vector3(210f, -160f, 0.0f), t11);
              if (!LeftHeroWin)
              {
                RightHero.transform.localPosition = Vector3.Lerp(new Vector3(78f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), t11);
                RightHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, -20f), new Vector3(0.0f, 0.0f, 0.0f), t11));
              }
              else
              {
                LeftHero.transform.localPosition = Vector3.Lerp(new Vector3(-78f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), t11);
                LeftHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, 20f), new Vector3(0.0f, 0.0f, 0.0f), t11));
              }
            }
            if ((UnityEngine.Object) this.ParticleEffect_Burst == (UnityEngine.Object) null)
            {
              if ((double) Time.timeScale > 0.0)
                AudioManager.Instance.PlayUISFX(UIKind.Explosion);
              this.ParticleEffect_Burst = ParticleManager.Instance.Spawn((ushort) 432, transform12.parent, transform12.localPosition, 1f, true);
              this.ParticleEffect_Burst.transform.localPosition = new Vector3(transform12.localPosition.x, transform12.localPosition.y, -800f);
              this.ParticleEffect_Burst.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
              GUIManager.Instance.SetLayer(this.ParticleEffect_Burst, 5);
            }
            if (flag)
            {
              transform12.Rotate(0.0f, 0.0f, (!LeftHeroWin ? 494f : -494f) * Time.timeScale * Time.unscaledDeltaTime);
              Color color = new Color(1f, 1f, 1f, Mathf.Max(1f - (float) (NowRoundTime - 4.4600000381469727), 0.0f));
              ((Graphic) transform12.GetChild(0).GetComponent<Image>()).color = color;
              ((Graphic) transform12.GetChild(1).GetComponent<Image>()).color = color;
            }
          }
          else
          {
            float num21 = transform12.localScale.x + this.burstScaleSpeed * 10f * Time.deltaTime * this.FightTimeScale;
            if ((double) num21 > 1.2000000476837158)
            {
              num21 = 1.2f;
              this.burstScaleSpeed = -(float) UnityEngine.Random.Range(2, 5);
            }
            else if ((double) num21 < 1.0)
            {
              num21 = 1f;
              this.burstScaleSpeed = (float) UnityEngine.Random.Range(2, 5);
            }
            transform12.localScale = num21 * Vector3.one;
            float z4 = transform12.localEulerAngles.z + this.burstRotationSpeed * 300f * Time.deltaTime * this.FightTimeScale;
            if ((double) z4 > 180.0)
              z4 -= 360f;
            if ((double) z4 > 0.0)
            {
              if ((double) z4 > 21.0)
              {
                z4 = 21f;
                this.burstRotationSpeed = -(float) UnityEngine.Random.Range(2, 5);
              }
              else if ((double) z4 < 16.0)
              {
                z4 = 16f;
                this.burstRotationSpeed = (float) UnityEngine.Random.Range(2, 5);
              }
            }
            else if ((double) z4 < 0.0)
            {
              if ((double) z4 < -21.0)
              {
                z4 = -21f;
                this.burstRotationSpeed = (float) UnityEngine.Random.Range(2, 5);
              }
              else if ((double) z4 > -16.0)
              {
                z4 = -16f;
                this.burstRotationSpeed = -(float) UnityEngine.Random.Range(2, 5);
              }
            }
            transform12.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, z4));
          }
        }
        float num22 = NowRoundTime >= 4.070000171661377 ? (NowRoundTime >= 4.570000171661377 ? 0.7f : EasingEffect.InQuadratic((float) NowRoundTime - 4.07f, 1.2f, -0.5f, 0.5f)) : EasingEffect.Linear((float) NowRoundTime - 3.89f, 0.0f, 1.2f, 0.18f);
        if (this.GM.IsArabic)
          ((Transform) ((Graphic) this.DeadCounts[0]).rectTransform).localScale = new Vector3(-num22, num22, num22);
        else
          ((Transform) ((Graphic) this.DeadCounts[0]).rectTransform).localScale = new Vector3(num22, num22, num22);
        ((Transform) ((Graphic) this.DeadCounts[1]).rectTransform).localScale = ((Transform) ((Graphic) this.DeadCounts[0]).rectTransform).localScale;
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_END:
        if (NowRoundTime <= 5.9000000953674316)
          break;
        if (LeftHeroWin)
        {
          this.transform.GetChild(8).GetChild(2).gameObject.SetActive(false);
          this.transform.GetChild(8).GetChild(6).gameObject.SetActive(false);
          Transform transform13 = RightHero.transform;
          Vector3 zero7 = Vector3.zero;
          RightHero.transform.transform.GetChild(0).localScale = zero7;
          Vector3 vector3_13 = zero7;
          transform13.localScale = vector3_13;
          RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
          this.transform.GetChild(7).GetChild(2).gameObject.SetActive(false);
          this.transform.GetChild(7).GetChild(6).gameObject.SetActive(false);
          Transform transform14 = LeftHero.transform;
          Vector3 zero8 = Vector3.zero;
          LeftHero.transform.transform.GetChild(0).localScale = zero8;
          Vector3 vector3_14 = zero8;
          transform14.localScale = vector3_14;
        }
        Transform transform15 = LeftHero.transform;
        Vector3 zero9 = Vector3.zero;
        RightHero.transform.localPosition = zero9;
        Vector3 vector3_15 = zero9;
        transform15.localPosition = vector3_15;
        Transform transform16 = LeftHero.transform;
        Quaternion identity3 = Quaternion.identity;
        RightHero.transform.localRotation = identity3;
        Quaternion quaternion3 = identity3;
        transform16.localRotation = quaternion3;
        if (this.GM.IsArabic)
        {
          Transform transform17 = ((Component) this.m_player[0, 13]).transform;
          Vector3 vector3_16 = new Vector3(-1f, 0.0f, 0.0f);
          ((Component) this.m_player[1, 13]).transform.localScale = vector3_16;
          Vector3 vector3_17 = vector3_16;
          transform17.localScale = vector3_17;
        }
        else
        {
          Transform transform18 = ((Component) this.m_player[0, 13]).transform;
          Vector3 one5 = Vector3.one;
          ((Component) this.m_player[1, 13]).transform.localScale = one5;
          Vector3 vector3_18 = one5;
          transform18.localScale = vector3_18;
        }
        this.SetStage(UIAllianceWarBattle.MoveStage.MS_FIGHTING);
        break;
    }
  }

  protected void RunHeroStateB(
    GameObject LeftHero,
    GameObject RightHero,
    bool LeftHeroWin,
    double NowRoundTime)
  {
    if (this.MovieStage == UIAllianceWarBattle.MoveStage.MS_FINISH)
      return;
    switch (this.MovieStage)
    {
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_START:
        this.transform.GetChild(7).GetChild(2).gameObject.SetActive(true);
        this.transform.GetChild(7).GetChild(6).gameObject.SetActive(true);
        this.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
        this.transform.GetChild(8).GetChild(2).gameObject.SetActive(true);
        this.transform.GetChild(8).GetChild(6).gameObject.SetActive(true);
        this.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
        this.transform.GetChild(6).GetChild(0).GetChild(13).gameObject.SetActive(false);
        this.transform.GetChild(6).GetChild(1).GetChild(13).gameObject.SetActive(false);
        Transform transform1 = LeftHero.transform;
        Vector3 one1 = Vector3.one;
        RightHero.transform.localScale = one1;
        Vector3 vector3_1 = one1;
        transform1.localScale = vector3_1;
        Transform transform2 = LeftHero.transform;
        Vector3 zero1 = Vector3.zero;
        RightHero.transform.localPosition = zero1;
        Vector3 vector3_2 = zero1;
        transform2.localPosition = vector3_2;
        Transform transform3 = LeftHero.transform;
        Quaternion identity1 = Quaternion.identity;
        RightHero.transform.localRotation = identity1;
        Quaternion quaternion1 = identity1;
        transform3.localRotation = quaternion1;
        Transform child = LeftHero.transform.GetChild(0);
        Vector3 one2 = Vector3.one;
        RightHero.transform.GetChild(0).localScale = one2;
        Vector3 vector3_3 = one2;
        child.localScale = vector3_3;
        LeftHero.transform.gameObject.SetActive(true);
        RightHero.transform.gameObject.SetActive(true);
        RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
        for (int index = 0; index < 2; ++index)
        {
          ((Graphic) this.HeroButt[index].HeroHint.HIImage).color = Color.white;
          ((Graphic) this.HeroButt[index].HeroHint.CircleImage).color = Color.white;
          ((Graphic) this.transform.GetChild(6).GetChild(index + 4).gameObject.GetComponent<Image>()).color = Color.white;
        }
        if (NowRoundTime > 0.33000001311302185)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_MOVE;
          LeftHero.transform.GetChild(0).localScale = Vector3.one;
          RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
          float num = 0.0f;
          if (NowRoundTime > 0.0)
            num = DamageValueManager.easeOutCubic(4f, 1f, (float) (NowRoundTime / 0.5));
          if (this.LastWinner == (byte) 1 || this.LastWinner == (byte) 0)
          {
            this.transform.GetChild(6).GetChild(5).gameObject.SetActive(true);
            RightHero.transform.GetChild(0).localScale = new Vector3(num * -1f, num, num);
          }
          if (this.LastWinner == (byte) 2 || this.LastWinner == (byte) 0)
          {
            this.transform.GetChild(6).GetChild(4).gameObject.SetActive(true);
            LeftHero.transform.GetChild(0).localScale = new Vector3(num, num, num);
          }
          if (NowRoundTime > 0.25)
          {
            if ((this.LastWinner == (byte) 1 || this.LastWinner == (byte) 0) && (UnityEngine.Object) this.ParticleEffect_InRight == (UnityEngine.Object) null)
            {
              if ((double) Time.timeScale > 0.0)
                AudioManager.Instance.PlayUISFX(UIKind.CutIn);
              this.ParticleEffect_InRight = ParticleManager.Instance.Spawn((ushort) 430, this.transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
              this.ParticleEffect_InRight.transform.localPosition = new Vector3(113f, -58f, -800f);
              this.ParticleEffect_InRight.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
              GUIManager.Instance.SetLayer(this.ParticleEffect_InRight, 5);
            }
            if ((this.LastWinner == (byte) 2 || this.LastWinner == (byte) 0) && (UnityEngine.Object) this.ParticleEffect_InLeft == (UnityEngine.Object) null)
            {
              if ((double) Time.timeScale > 0.0)
                AudioManager.Instance.PlayUISFX(UIKind.CutIn);
              this.ParticleEffect_InLeft = ParticleManager.Instance.Spawn((ushort) 430, this.transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
              this.ParticleEffect_InLeft.transform.localPosition = new Vector3(-113f, -58f, -800f);
              this.ParticleEffect_InLeft.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
              GUIManager.Instance.SetLayer(this.ParticleEffect_InLeft, 5);
            }
          }
          if (NowRoundTime > 0.0)
          {
            float a = DamageValueManager.easeOutCubic(0.0f, 1f, (float) (NowRoundTime / 0.33000001311302185));
            if (this.LastWinner == (byte) 1 || this.LastWinner == (byte) 0)
            {
              Image component1 = RightHero.transform.GetChild(0).GetComponent<Image>();
              if ((bool) (UnityEngine.Object) component1)
                ((Graphic) component1).color = new Color(1f, 1f, 1f, a);
              Image component2 = RightHero.transform.GetChild(1).GetComponent<Image>();
              if ((bool) (UnityEngine.Object) component2)
                ((Graphic) component2).color = new Color(1f, 1f, 1f, a);
            }
            if (this.LastWinner == (byte) 2 || this.LastWinner == (byte) 0)
            {
              Image component3 = LeftHero.transform.GetChild(0).GetComponent<Image>();
              if ((bool) (UnityEngine.Object) component3)
                ((Graphic) component3).color = new Color(1f, 1f, 1f, a);
              Image component4 = LeftHero.transform.GetChild(1).GetComponent<Image>();
              if ((bool) (UnityEngine.Object) component4)
                ((Graphic) component4).color = new Color(1f, 1f, 1f, a);
            }
            ((Graphic) this.transform.GetChild(6).GetChild(4).gameObject.GetComponent<Image>()).color = new Color(1f, 1f, 1f, a);
            ((Graphic) this.transform.GetChild(6).GetChild(5).gameObject.GetComponent<Image>()).color = new Color(1f, 1f, 1f, a);
          }
        }
        if (!((UnityEngine.Object) this.ParticleEffect_Hit != (UnityEngine.Object) null) || this.ParticleEffect_Hit.gameObject.activeSelf)
          break;
        this.ParticleEffect_Hit = (GameObject) null;
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_MOVE:
        if (NowRoundTime > 0.88999998569488525)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_PULL;
          this.transform.GetChild(6).GetChild(4).gameObject.SetActive(false);
          this.transform.GetChild(6).GetChild(5).gameObject.SetActive(false);
          Transform transform4 = LeftHero.transform;
          Vector3 one3 = Vector3.one;
          RightHero.transform.localScale = one3;
          Vector3 vector3_4 = one3;
          transform4.localScale = vector3_4;
          Transform transform5 = LeftHero.transform;
          Vector3 zero2 = Vector3.zero;
          RightHero.transform.localPosition = zero2;
          Vector3 vector3_5 = zero2;
          transform5.localPosition = vector3_5;
          Transform transform6 = LeftHero.transform;
          Quaternion identity2 = Quaternion.identity;
          RightHero.transform.localRotation = identity2;
          Quaternion quaternion2 = identity2;
          transform6.localRotation = quaternion2;
          RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
          break;
        }
        float num1 = NowRoundTime <= 0.75 ? (NowRoundTime <= 0.61000001430511475 ? (NowRoundTime <= 0.4699999988079071 ? DamageValueManager.easeOutCubic(1f, 1.5f, (float) ((NowRoundTime - 0.33) / 0.14000000059604645)) : DamageValueManager.easeOutCubic(1.5f, 1f, (float) ((NowRoundTime - 0.4699999988079071) / 0.14000000059604645))) : DamageValueManager.easeOutCubic(1f, 1.2f, (float) ((NowRoundTime - 0.61000001430511475) / 0.14000000059604645))) : DamageValueManager.easeOutCubic(1.2f, 1f, (float) ((NowRoundTime - 0.75) / 0.14000000059604645));
        if (this.LastWinner == (byte) 1 || this.LastWinner == (byte) 0)
          RightHero.transform.localScale = new Vector3(num1, num1, num1);
        if (this.LastWinner != (byte) 2 && this.LastWinner != (byte) 0)
          break;
        LeftHero.transform.localScale = new Vector3(num1, num1, num1);
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_PULL:
        if (NowRoundTime >= 1.059999942779541)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_ATTACK;
          LeftHero.transform.localPosition = new Vector3(-53f, -10f, 0.0f);
          RightHero.transform.localPosition = new Vector3(53f, -10f, 0.0f);
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 15f));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -15f));
          break;
        }
        Vector2 zero3 = Vector2.zero;
        Vector2 zero4 = Vector2.zero;
        Vector2 vector2_1 = new Vector2(0.0f, 0.0f);
        Vector2 vector2_2 = new Vector2(45f, 10f);
        float t1 = (float) (NowRoundTime - 0.88999998569488525) / 0.17f;
        zero3.x = Mathf.Lerp(vector2_1.x, -vector2_2.x, t1);
        zero3.y = Mathf.Lerp(vector2_1.y, -vector2_2.y, t1);
        zero4.x = Mathf.Lerp(vector2_1.x, vector2_2.x, t1);
        zero4.y = Mathf.Lerp(vector2_1.y, -vector2_2.y, t1);
        float z1 = Mathf.Lerp(0.0f, 25f, t1);
        LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, z1));
        RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -z1));
        LeftHero.transform.localPosition = new Vector3(zero3.x, zero3.y, 0.0f);
        RightHero.transform.localPosition = new Vector3(zero4.x, zero4.y, 0.0f);
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_ATTACK:
        float num2 = 1.06f;
        float num3 = 2.16f;
        float num4 = 1.16f;
        if (NowRoundTime >= (double) num3)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_SPLIT;
          LeftHero.transform.localPosition = new Vector3(85f, 0.0f, 0.0f);
          RightHero.transform.localPosition = new Vector3(-85f, 0.0f, 0.0f);
          RightHero.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
          LeftHero.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -15f));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 15f));
          break;
        }
        Vector2 vector2_3 = new Vector2(53f, 10f);
        Vector2 vector2_4 = new Vector2(85f, 0.0f);
        Vector2 zero5 = Vector2.zero;
        Vector2 zero6 = Vector2.zero;
        if (NowRoundTime - (double) num2 < (double) num4 - (double) num2)
        {
          float t2 = ((float) NowRoundTime - num2) / (num4 - num2);
          float num5;
          float num6 = num5 = Mathf.Lerp(1f, 1.1f, t2);
          zero5.x = Mathf.Lerp(-vector2_3.x, vector2_4.x, t2);
          zero5.y = Mathf.Lerp(-vector2_3.y, vector2_4.y, t2);
          zero6.x = Mathf.Lerp(vector2_3.x, -vector2_4.x, t2);
          zero6.y = Mathf.Lerp(-vector2_3.y, vector2_4.y, t2);
          float z2 = Mathf.Lerp(-15f, 15f, t2);
          LeftHero.transform.localPosition = new Vector3(zero5.x, zero5.y, 0.0f);
          RightHero.transform.localPosition = new Vector3(zero6.x, zero6.y, 0.0f);
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -z2));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, z2));
          RightHero.transform.localScale = new Vector3(num5, num5, num5);
          LeftHero.transform.localScale = new Vector3(num6, num6, num6);
          break;
        }
        vector2_3 = new Vector2(75f, 0.0f);
        if (NowRoundTime < (double) num3)
        {
          float num7 = ((float) NowRoundTime - num4) / (num3 - num4);
          int num8 = (int) ((NowRoundTime - (double) num4) / 0.10000000149011612);
          int num9 = num8 % 2 != 0 ? -1 : 1;
          float t3 = num7 / 0.1f - (float) num8;
          float num10 = 15f;
          float num11;
          float num12;
          if (num9 == -1)
          {
            zero5.x = Mathf.Lerp(vector2_3.x + num10, vector2_3.x - num10, t3);
            zero6.x = Mathf.Lerp(-vector2_3.x + num10, -vector2_3.x - num10, t3);
            num11 = Mathf.Lerp(1f, 1.1f, t3);
            num12 = Mathf.Lerp(1.1f, 1f, t3);
          }
          else
          {
            zero5.x = Mathf.Lerp(vector2_3.x - num10, vector2_3.x + num10, t3);
            zero6.x = Mathf.Lerp(-vector2_3.x - num10, -vector2_3.x + num10, t3);
            num11 = Mathf.Lerp(1.1f, 1f, t3);
            num12 = Mathf.Lerp(1f, 1.1f, t3);
          }
          LeftHero.transform.localPosition = new Vector3(zero5.x, vector2_3.y, 0.0f);
          RightHero.transform.localPosition = new Vector3(zero6.x, vector2_3.y, 0.0f);
          RightHero.transform.localScale = new Vector3(num11, num11, num11);
          LeftHero.transform.localScale = new Vector3(num12, num12, num12);
        }
        if (NowRoundTime <= 2.059999942779541 || !((UnityEngine.Object) this.ParticleEffect_Hit == (UnityEngine.Object) null))
          break;
        if ((double) Time.timeScale > 0.0)
          AudioManager.Instance.PlaySFX((ushort) 40054, pitchkind: PitchKind.Hit);
        AudioManager.Instance.PlaySFX(this.LeftHurtSfx, pitchkind: PitchKind.Hit);
        AudioManager.Instance.PlaySFX(this.RightHurtSfx, pitchkind: PitchKind.Hit);
        this.ParticleEffect_Hit = ParticleManager.Instance.Spawn((ushort) 431, this.transform.GetChild(9).transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
        this.ParticleEffect_Hit.transform.localPosition = new Vector3(0.0f, 80f, -800f);
        this.ParticleEffect_Hit.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        GUIManager.Instance.SetLayer(this.ParticleEffect_Hit, 5);
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_SPLIT:
        float num13 = 2.19f;
        float num14 = 2.32f;
        if (NowRoundTime > (double) num14)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_DAMAGE;
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 15f));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -15f));
          LeftHero.transform.localScale = Vector3.one;
          RightHero.transform.localScale = Vector3.one;
          LeftHero.transform.localPosition = new Vector3(-51f, 0.0f, 0.0f);
          RightHero.transform.localPosition = new Vector3(51f, 0.0f, 0.0f);
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 15f));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -15f));
          if ((double) Time.timeScale <= 0.0)
            break;
          AudioManager.Instance.PlayUISFX(UIKind.Score);
          break;
        }
        float num15 = ((float) NowRoundTime - num13) / (num14 - num13);
        float num16 = 0.5f;
        if ((double) num15 < (double) num16)
        {
          float num17 = num15 / num16;
          LeftHero.transform.localPosition = new Vector3((float) (75.0 - 126.0 * (double) num15), -8f * num17, 0.0f);
          RightHero.transform.localPosition = new Vector3((float) (126.0 * (double) num15 - 75.0), -8f * num17, 0.0f);
          LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, (float) (55.0 * (double) num17 - 15.0)));
          RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, (float) (15.0 - 55.0 * (double) num17)));
          break;
        }
        LeftHero.transform.localPosition = new Vector3(-51f, 0.0f, 0.0f);
        RightHero.transform.localPosition = new Vector3(51f, 0.0f, 0.0f);
        float num18 = (num15 - num16) / num16;
        LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, (float) (40.0 - 25.0 * (double) num18)));
        RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, (float) (25.0 * (double) num18 - 40.0)));
        float num19 = (float) (1.3999999761581421 - 0.40000000596046448 * (double) num18);
        LeftHero.transform.localScale = new Vector3(num19, num19, num19);
        RightHero.transform.localScale = new Vector3(num19, num19, num19);
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_DAMAGE:
        if (NowRoundTime > 3.8900001049041748)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_BURST;
          this.burstRotationSpeed = (float) UnityEngine.Random.Range(2, 5);
          this.burstRotationSpeed *= UnityEngine.Random.Range(0, 2) != 0 ? 1f : -1f;
          this.burstScaleSpeed = (float) UnityEngine.Random.Range(2, 5);
          this.burstScaleSpeed *= UnityEngine.Random.Range(0, 2) != 0 ? 1f : -1f;
          if ((int) this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
          {
            uint rightSurvive = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightSurvive;
            uint leftSurvive = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftSurvive;
            this.AllianceStr[6].ClearString();
            this.AllianceStr[6].uLongToFormat((ulong) leftSurvive, bNumber: true);
            this.AllianceStr[6].AppendFormat("{0}");
            if ((bool) (UnityEngine.Object) this.m_player[0, 10])
            {
              this.m_player[0, 10].text = this.AllianceStr[6].ToString();
              ((Graphic) this.m_player[0, 10]).SetAllDirty();
              this.m_player[0, 10].cachedTextGenerator.Invalidate();
            }
            this.AllianceStr[9].ClearString();
            this.AllianceStr[9].uLongToFormat((ulong) rightSurvive, bNumber: true);
            this.AllianceStr[9].AppendFormat("{0}");
            if ((bool) (UnityEngine.Object) this.m_player[1, 10])
            {
              this.m_player[1, 10].text = this.AllianceStr[9].ToString();
              ((Graphic) this.m_player[1, 10]).SetAllDirty();
              this.m_player[1, 10].cachedTextGenerator.Invalidate();
            }
          }
          if ((UnityEngine.Object) this.ParticleEffect_Burst != (UnityEngine.Object) null && !this.ParticleEffect_Burst.gameObject.activeSelf)
            this.ParticleEffect_Burst = (GameObject) null;
          if (this.GM.IsArabic)
          {
            Transform transform7 = this.transform.GetChild(7).GetChild(2).GetChild(0).transform;
            Vector3 vector3_6 = new Vector3(-1f, 1f, 1f);
            this.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector3_6;
            Vector3 vector3_7 = vector3_6;
            transform7.localScale = vector3_7;
          }
          else
          {
            Transform transform8 = this.transform.GetChild(7).GetChild(2).GetChild(0).transform;
            Vector3 one4 = Vector3.one;
            this.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = one4;
            Vector3 vector3_8 = one4;
            transform8.localScale = vector3_8;
          }
          if ((int) this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
          {
            if (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftDead > 0U)
            {
              this.DeadCountsStr[0].ClearString();
              this.DeadCountsStr[0].IntToFormat((long) -UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftDead, bNumber: true);
              this.DeadCountsStr[0].AppendFormat("{0}");
              this.DeadCounts[0].text = this.DeadCountsStr[0].ToString();
              if (this.GM.IsArabic)
                ((Transform) ((Graphic) this.DeadCounts[0]).rectTransform).localScale = new Vector3(-0.7f, 0.7f, 0.7f);
              else
                ((Transform) ((Graphic) this.DeadCounts[0]).rectTransform).localScale = new Vector3(0.7f, 0.7f, 0.7f);
            }
            if (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightDead > 0U)
            {
              this.DeadCountsStr[1].ClearString();
              this.DeadCountsStr[1].IntToFormat((long) -UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightDead, bNumber: true);
              this.DeadCountsStr[1].AppendFormat("{0}");
              this.DeadCounts[1].text = this.DeadCountsStr[1].ToString();
              if (this.GM.IsArabic)
                ((Transform) ((Graphic) this.DeadCounts[1]).rectTransform).localScale = new Vector3(-0.7f, 0.7f, 0.7f);
              else
                ((Transform) ((Graphic) this.DeadCounts[1]).rectTransform).localScale = new Vector3(0.7f, 0.7f, 0.7f);
            }
          }
          if (LeftHeroWin)
          {
            AudioManager.Instance.PlaySFX(this.RightDyingSfx, pitchkind: PitchKind.Hit);
            break;
          }
          AudioManager.Instance.PlaySFX(this.LeftDyingSfx, pitchkind: PitchKind.Hit);
          break;
        }
        float num20 = 1f;
        if (NowRoundTime > 3.5899999141693115)
        {
          num20 = (float) (6.1866631507873535 - 1.3333324193954468 * NowRoundTime);
          if ((double) num20 < 1.0)
            num20 = 1f;
        }
        else if (NowRoundTime > 2.4900000095367432)
          num20 = 1.4f;
        else if (NowRoundTime > 2.19)
        {
          num20 = (float) (1.3333334922790527 * NowRoundTime - 1.9200003147125244);
          if ((double) num20 > 1.3999999761581421)
            num20 = 1.4f;
        }
        if (this.GM.IsArabic)
        {
          Transform transform9 = this.transform.GetChild(7).GetChild(2).GetChild(0).transform;
          Vector3 vector3_9 = num20 * new Vector3(-1f, 1f, 1f);
          this.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector3_9;
          Vector3 vector3_10 = vector3_9;
          transform9.localScale = vector3_10;
        }
        else
        {
          Transform transform10 = this.transform.GetChild(7).GetChild(2).GetChild(0).transform;
          Vector3 vector3_11 = num20 * Vector3.one;
          this.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector3_11;
          Vector3 vector3_12 = vector3_11;
          transform10.localScale = vector3_12;
        }
        if ((int) this.BattleRound >= UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
          break;
        float num21 = 3.89f - (float) NowRoundTime;
        if ((double) num21 < 0.0)
          num21 = 0.0f;
        float num22 = num21 / 1.57f;
        if ((double) num22 > 1.0)
          num22 = 1f;
        uint x1 = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightSurvive + (uint) ((double) num22 * (double) UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].RightDead);
        uint x2 = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftSurvive + (uint) ((double) num22 * (double) UIAllianceWarBattle.BattleRoyale.BattleMatch[(int) this.BattleRound].LeftDead);
        this.AllianceStr[6].ClearString();
        this.AllianceStr[6].uLongToFormat((ulong) x2, bNumber: true);
        this.AllianceStr[6].AppendFormat("{0}");
        if ((bool) (UnityEngine.Object) this.m_player[0, 10])
        {
          this.m_player[0, 10].text = this.AllianceStr[6].ToString();
          ((Graphic) this.m_player[0, 10]).SetAllDirty();
          this.m_player[0, 10].cachedTextGenerator.Invalidate();
        }
        this.AllianceStr[9].ClearString();
        this.AllianceStr[9].uLongToFormat((ulong) x1, bNumber: true);
        this.AllianceStr[9].AppendFormat("{0}");
        if (!(bool) (UnityEngine.Object) this.m_player[1, 10])
          break;
        this.m_player[1, 10].text = this.AllianceStr[9].ToString();
        ((Graphic) this.m_player[1, 10]).SetAllDirty();
        this.m_player[1, 10].cachedTextGenerator.Invalidate();
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_BURST:
        if (NowRoundTime > 4.96999979019165)
        {
          this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_END;
          this.SetterWinner(LeftHeroWin);
          this.burstScaleSpeed = this.burstRotationSpeed = 0.0f;
          GameObject gameObject1;
          GameObject gameObject2;
          if (LeftHeroWin)
          {
            gameObject1 = LeftHero;
            gameObject2 = RightHero;
          }
          else
          {
            gameObject1 = RightHero;
            gameObject2 = LeftHero;
          }
          if ((UnityEngine.Object) gameObject1 != (UnityEngine.Object) null)
          {
            if (!gameObject1.activeSelf)
              gameObject1.SetActive(true);
            Transform transform11 = gameObject1.transform;
            if ((UnityEngine.Object) transform11 != (UnityEngine.Object) null)
            {
              transform11.localPosition = new Vector3(!LeftHeroWin ? 51f : -51f, 27f, 0.0f);
              transform11.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, !LeftHeroWin ? -15f : 15f));
              transform11.localScale = Vector3.one;
              Color color = new Color(1f, 1f, 1f, 1f);
              ((Graphic) transform11.GetChild(0).GetComponent<Image>()).color = color;
              ((Graphic) transform11.GetChild(1).GetComponent<Image>()).color = color;
            }
          }
          if ((UnityEngine.Object) gameObject2 != (UnityEngine.Object) null && gameObject2.activeSelf)
          {
            gameObject2.SetActive(false);
            Color color = new Color(1f, 1f, 1f, 1f);
            ((Graphic) gameObject2.transform.GetChild(0).GetComponent<Image>()).color = color;
            ((Graphic) gameObject2.transform.GetChild(1).GetComponent<Image>()).color = color;
            this.transform.GetChild(!LeftHeroWin ? 7 : 8).GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(!LeftHeroWin ? 7 : 8).GetChild(6).gameObject.SetActive(false);
          }
          this.DeadCounts[0].text = string.Empty;
          this.DeadCounts[1].text = string.Empty;
          break;
        }
        GameObject gameObject3 = !LeftHeroWin ? LeftHero : RightHero;
        if (!((UnityEngine.Object) gameObject3 != (UnityEngine.Object) null))
          break;
        Transform transform12 = gameObject3.transform;
        if ((UnityEngine.Object) transform12 != (UnityEngine.Object) null)
        {
          if (NowRoundTime > 4.1999998092651367)
          {
            bool flag = true;
            if (NowRoundTime <= 4.3299999237060547)
            {
              flag = false;
              float t4 = (float) (NowRoundTime - 4.1999998092651367) / 0.13f;
              transform12.localScale = Vector3.Lerp(new Vector3(1f, 1f, 1f), new Vector3(1.2f, 1.2f, 1.2f), t4);
              transform12.localRotation = !LeftHeroWin ? Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 30f), t4)) : Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, -30f), t4));
            }
            else if (NowRoundTime <= 4.4600000381469727)
            {
              flag = false;
              float t5 = (float) (NowRoundTime - 4.3299999237060547) / 0.13f;
              transform12.localScale = Vector3.Lerp(new Vector3(1.2f, 1.2f, 1.2f), new Vector3(1.3f, 1.3f, 1.3f), t5);
              if (LeftHeroWin)
              {
                transform12.localPosition = Vector3.Lerp(new Vector3(78f, 0.0f, 0.0f), new Vector3(128f, 107f, 0.0f), t5);
                transform12.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, -30f), new Vector3(0.0f, 0.0f, -60f), t5));
              }
              else
              {
                transform12.localPosition = Vector3.Lerp(new Vector3(-78f, 0.0f, 0.0f), new Vector3((float) sbyte.MinValue, 107f, 0.0f), t5);
                transform12.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, 30f), new Vector3(0.0f, 0.0f, 60f), t5));
              }
            }
            else if (NowRoundTime <= 4.8600001335144043)
            {
              float t6 = (float) (NowRoundTime - 4.4600000381469727) / 0.4f;
              transform12.localScale = Vector3.Lerp(new Vector3(1.3f, 1.3f, 1.3f), new Vector3(1.1f, 1.1f, 1.1f), t6);
              transform12.localPosition = !LeftHeroWin ? Vector3.Lerp(new Vector3((float) sbyte.MinValue, 107f, 0.0f), new Vector3(-185f, 84f, 0.0f), t6) : Vector3.Lerp(new Vector3(128f, 107f, 0.0f), new Vector3(185f, 84f, 0.0f), t6);
            }
            else if (NowRoundTime <= 5.2600002288818359)
            {
              float t7 = (float) (NowRoundTime - 4.8600001335144043) / 0.4f;
              transform12.localScale = Vector3.Lerp(new Vector3(1.1f, 1.1f, 1.1f), new Vector3(1f, 1f, 1f), t7);
              transform12.localPosition = !LeftHeroWin ? Vector3.Lerp(new Vector3(-185f, 84f, 0.0f), new Vector3(-210f, -160f, 0.0f), t7) : Vector3.Lerp(new Vector3(185f, 84f, 0.0f), new Vector3(210f, -160f, 0.0f), t7);
              if (!LeftHeroWin)
              {
                RightHero.transform.localPosition = Vector3.Lerp(new Vector3(78f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), t7);
                RightHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, -20f), new Vector3(0.0f, 0.0f, 0.0f), t7));
              }
              else
              {
                LeftHero.transform.localPosition = Vector3.Lerp(new Vector3(-78f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), t7);
                LeftHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0.0f, 0.0f, 20f), new Vector3(0.0f, 0.0f, 0.0f), t7));
              }
            }
            if ((UnityEngine.Object) this.ParticleEffect_Burst == (UnityEngine.Object) null)
            {
              if ((double) Time.timeScale > 0.0)
                AudioManager.Instance.PlayUISFX(UIKind.Explosion);
              this.ParticleEffect_Burst = ParticleManager.Instance.Spawn((ushort) 432, transform12.parent, transform12.localPosition, 1f, true);
              this.ParticleEffect_Burst.transform.localPosition = new Vector3(transform12.localPosition.x, transform12.localPosition.y, -800f);
              this.ParticleEffect_Burst.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
              GUIManager.Instance.SetLayer(this.ParticleEffect_Burst, 5);
            }
            if (flag)
            {
              transform12.Rotate(0.0f, 0.0f, (!LeftHeroWin ? 494f : -494f) * Time.timeScale * Time.unscaledDeltaTime);
              Color color = new Color(1f, 1f, 1f, Mathf.Max(1f - (float) (NowRoundTime - 4.4600000381469727), 0.0f));
              ((Graphic) transform12.GetChild(0).GetComponent<Image>()).color = color;
              ((Graphic) transform12.GetChild(1).GetComponent<Image>()).color = color;
            }
          }
          else
          {
            float num23 = transform12.localScale.x + this.burstScaleSpeed * 10f * Time.deltaTime * this.FightTimeScale;
            if ((double) num23 > 1.0499999523162842)
            {
              num23 = 1.05f;
              this.burstScaleSpeed = -(float) UnityEngine.Random.Range(2, 5);
            }
            else if ((double) num23 < 1.0)
            {
              num23 = 1f;
              this.burstScaleSpeed = (float) UnityEngine.Random.Range(2, 5);
            }
            transform12.localScale = num23 * Vector3.one;
            float z3 = transform12.localEulerAngles.z + this.burstRotationSpeed * 300f * Time.deltaTime * this.FightTimeScale;
            if ((double) z3 > 180.0)
              z3 -= 360f;
            if ((double) z3 > 0.0)
            {
              if ((double) z3 > 21.0)
              {
                z3 = 21f;
                this.burstRotationSpeed = -(float) UnityEngine.Random.Range(2, 5);
              }
              else if ((double) z3 < 16.0)
              {
                z3 = 16f;
                this.burstRotationSpeed = (float) UnityEngine.Random.Range(2, 5);
              }
            }
            else if ((double) z3 < 0.0)
            {
              if ((double) z3 < -21.0)
              {
                z3 = -21f;
                this.burstRotationSpeed = (float) UnityEngine.Random.Range(2, 5);
              }
              else if ((double) z3 > -16.0)
              {
                z3 = -16f;
                this.burstRotationSpeed = -(float) UnityEngine.Random.Range(2, 5);
              }
            }
            transform12.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, z3));
          }
        }
        float num24 = NowRoundTime >= 4.070000171661377 ? (NowRoundTime >= 4.570000171661377 ? 0.7f : EasingEffect.InQuadratic((float) NowRoundTime - 4.07f, 1.2f, -0.5f, 0.5f)) : EasingEffect.Linear((float) NowRoundTime - 3.89f, 0.0f, 1.2f, 0.18f);
        if (this.GM.IsArabic)
          ((Transform) ((Graphic) this.DeadCounts[0]).rectTransform).localScale = new Vector3(-num24, num24, num24);
        else
          ((Transform) ((Graphic) this.DeadCounts[0]).rectTransform).localScale = new Vector3(num24, num24, num24);
        ((Transform) ((Graphic) this.DeadCounts[1]).rectTransform).localScale = ((Transform) ((Graphic) this.DeadCounts[0]).rectTransform).localScale;
        break;
      case UIAllianceWarBattle.MoveStage.MS_FIGHTING_END:
        if (NowRoundTime > 5.9000000953674316)
        {
          if (LeftHeroWin)
          {
            this.transform.GetChild(8).GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(8).GetChild(6).gameObject.SetActive(false);
            Transform transform13 = RightHero.transform;
            Vector3 zero7 = Vector3.zero;
            RightHero.transform.transform.GetChild(0).localScale = zero7;
            Vector3 vector3_13 = zero7;
            transform13.localScale = vector3_13;
            RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
          }
          else
          {
            this.transform.GetChild(7).GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(7).GetChild(6).gameObject.SetActive(false);
            Transform transform14 = LeftHero.transform;
            Vector3 zero8 = Vector3.zero;
            LeftHero.transform.transform.GetChild(0).localScale = zero8;
            Vector3 vector3_14 = zero8;
            transform14.localScale = vector3_14;
          }
          Transform transform15 = LeftHero.transform;
          Vector3 zero9 = Vector3.zero;
          RightHero.transform.localPosition = zero9;
          Vector3 vector3_15 = zero9;
          transform15.localPosition = vector3_15;
          Transform transform16 = LeftHero.transform;
          Quaternion identity3 = Quaternion.identity;
          RightHero.transform.localRotation = identity3;
          Quaternion quaternion3 = identity3;
          transform16.localRotation = quaternion3;
          if (this.GM.IsArabic)
          {
            Transform transform17 = ((Component) this.m_player[0, 13]).transform;
            Vector3 vector3_16 = new Vector3(-1f, 0.0f, 0.0f);
            ((Component) this.m_player[1, 13]).transform.localScale = vector3_16;
            Vector3 vector3_17 = vector3_16;
            transform17.localScale = vector3_17;
          }
          else
          {
            Transform transform18 = ((Component) this.m_player[0, 13]).transform;
            Vector3 one5 = Vector3.one;
            ((Component) this.m_player[1, 13]).transform.localScale = one5;
            Vector3 vector3_18 = one5;
            transform18.localScale = vector3_18;
          }
          this.SetStage(UIAllianceWarBattle.MoveStage.MS_FIGHTING);
          break;
        }
        float num25 = 5.066666f;
        float num26 = 5.2f;
        GameObject gameObject4 = !LeftHeroWin ? RightHero : LeftHero;
        if (!((UnityEngine.Object) gameObject4 != (UnityEngine.Object) null))
          break;
        if (!gameObject4.activeSelf)
          gameObject4.SetActive(true);
        Transform transform19 = gameObject4.transform;
        if (!((UnityEngine.Object) transform19 != (UnityEngine.Object) null))
          break;
        float z4;
        float x3;
        float y;
        if (NowRoundTime > (double) num26)
        {
          double num27;
          z4 = (float) (num27 = 0.0);
          x3 = (float) num27;
          y = (float) num27;
        }
        else if (NowRoundTime > (double) num25)
        {
          float num28 = 74.9998f;
          float num29 = -389.998962f;
          y = num28 * (float) NowRoundTime + num29;
          if (LeftHeroWin)
          {
            float num30 = 119.999687f;
            float num31 = -623.998352f;
            x3 = num30 * (float) NowRoundTime + num31;
            float num32 = 37.4999f;
            float num33 = -194.999481f;
            z4 = num32 * (float) NowRoundTime + num33;
          }
          else
          {
            x3 = 623.998352f + -119.999687f * (float) NowRoundTime;
            z4 = 194.999481f + -37.4999f * (float) NowRoundTime;
          }
        }
        else
        {
          y = 1929.31677f + -382.759918f * (float) NowRoundTime;
          if (LeftHeroWin)
          {
            float num34 = 362.0702f;
            float num35 = -1850.48889f;
            x3 = num34 * (float) NowRoundTime + num35;
            z4 = 1043.2793f + -206.897263f * (float) NowRoundTime;
          }
          else
          {
            x3 = 1850.48889f + -362.0702f * (float) NowRoundTime;
            float num36 = 206.897263f;
            float num37 = -1043.2793f;
            z4 = num36 * (float) NowRoundTime + num37;
          }
        }
        transform19.localPosition = new Vector3(x3, y, 0.0f);
        transform19.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, z4));
        float num38 = NowRoundTime <= 5.086249828338623 ? (NowRoundTime <= 5.2024998664855957 ? (float) (1290.3221435546875 * NowRoundTime - 6312.90087890625) : 100f) : (float) (6812.90087890625 - 1290.3221435546875 * NowRoundTime);
        if ((double) num38 < 100.0)
          num38 = 100f;
        if ((double) num38 > 250.0)
          num38 = 250f;
        float num39 = num38 * 0.01f;
        if (this.GM.IsArabic)
        {
          Transform transform20 = ((Component) this.m_player[0, 13]).transform;
          Vector3 vector3_19 = num39 * new Vector3(-1f, 1f, 1f);
          ((Component) this.m_player[1, 13]).transform.localScale = vector3_19;
          Vector3 vector3_20 = vector3_19;
          transform20.localScale = vector3_20;
          break;
        }
        Transform transform21 = ((Component) this.m_player[0, 13]).transform;
        Vector3 vector3_21 = num39 * Vector3.one;
        ((Component) this.m_player[1, 13]).transform.localScale = vector3_21;
        Vector3 vector3_22 = vector3_21;
        transform21.localScale = vector3_22;
        break;
    }
  }

  public void OnDisable()
  {
    if (this.LeftRightInit)
      LeftRightFly.Instance.SetEnable(false);
    if (!this.BattleReplay || this.bEnd)
      return;
    this.transform.GetChild(13).GetChild(1).GetChild(4).gameObject.SetActive(false);
    this.PauseTime = (double) Time.time - this.BattleTime;
    Time.timeScale = 1f;
    this.bDisabled = true;
  }

  private void OnEnable()
  {
    if (this.LeftRightInit)
    {
      LeftRightFly.Instance.SetEnable(true);
      if (!this.BattleReplay)
        LeftRightFly.Instance.UpdateCutinStat();
    }
    if (!this.BattleReplay || !this.bDisabled)
      return;
    if (this.SetGo)
      Time.timeScale = 0.0f;
    UIAllianceWarBattle.ReplayTime = 1.0;
    this.bDisabled = false;
    this.BattleTime = (double) Time.time - this.PauseTime;
  }

  protected void Update()
  {
    if (this.LeftRightInit)
      LeftRightFly.Instance.Update();
    if (this.bRequest || this.RequestData > 0L && this.DM.ServerTime > this.RequestData)
    {
      ActivityManager.Instance.AllianceWarSendReOpenMenu();
      this.bRequest = false;
      this.RequestData = 0L;
    }
    if (this.bExit)
    {
      if (!(bool) (UnityEngine.Object) this.door)
        return;
      this.door.CloseMenu();
    }
    else
    {
      if (this.bEnd || this.bReturn)
        return;
      this.PassTime = !this.BattleReplay ? (double) ActivityManager.Instance._ServerEventDeltaTime + NetworkManager.ServerTime : (double) Time.time;
      double num1 = (double) ActivityManager.Instance._ServerEventDeltaTime + NetworkManager.ServerTime - this.BattleTime - (double) this.BattlePrepare - (double) ((int) this.BattleRound * (int) ActivityManager.Instance.AW_FightTime);
      if (this.BattleReplay)
        num1 = (double) Time.time - this.BattleTime - (double) this.BattlePrepare - (double) ((int) this.BattleRound * (int) ActivityManager.Instance.AW_FightTime);
      double num2 = num1 * (double) this.FightTimeScale;
      this.Run(num2);
      if (this.MovieStage == UIAllianceWarBattle.MoveStage.MS_WAITING)
      {
        if (this.PassTime - (double) this.BattlePrepare >= this.BattleTime)
        {
          this.SetStage(UIAllianceWarBattle.MoveStage.MS_STARTING);
        }
        else
        {
          if (this.PassTime - (double) this.BattlePrepare + (double) this.ReadyGo <= this.BattleTime)
            return;
          if ((double) ActivityManager.Instance._ServerEventDeltaTime + NetworkManager.ServerTime - (double) this.BattlePrepare + 1.7999999523162842 >= this.BattleTime)
          {
            for (int index = 0; index < 2; ++index)
            {
              if ((UnityEngine.Object) this.ParticleEffect[index] != (UnityEngine.Object) null)
              {
                ParticleManager.Instance.DeSpawn(this.ParticleEffect[index]);
                this.ParticleEffect[index] = (GameObject) null;
              }
            }
          }
          if (!this.LeftRightSet)
            LeftRightFly.Instance.SetCountDown(!this.BattleReplay ? (float) ((double) ActivityManager.Instance._ServerEventDeltaTime + NetworkManager.ServerTime - this.BattleTime) - (float) this.BattlePrepare + this.ReadyGo : (float) (10.0 + UIAllianceWarBattle.ReplayTime));
          this.LeftRightSet = true;
        }
      }
      else
      {
        if (this.MovieStage <= UIAllianceWarBattle.MoveStage.MS_FIGHTING)
          return;
        switch (this.Rand)
        {
          case 0:
            this.RunHeroState(this.HeroButt[0].HeroHead, this.HeroButt[1].HeroHead, UIAllianceWarBattle.BattleRoyale.BattleWinner == (byte) 1, num2);
            break;
          case 1:
            this.RunHeroStateA(this.HeroButt[0].HeroHead, this.HeroButt[1].HeroHead, UIAllianceWarBattle.BattleRoyale.BattleWinner == (byte) 1, num2);
            break;
          case 2:
            this.RunHeroStateB(this.HeroButt[0].HeroHead, this.HeroButt[1].HeroHead, UIAllianceWarBattle.BattleRoyale.BattleWinner == (byte) 1, num2);
            break;
        }
      }
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_FontTextureRebuilt:
        if (this.LeftRightInit)
          LeftRightFly.Instance.Refresh_FontTexture();
        for (int index1 = 0; index1 < this.m_player.GetLength(0); ++index1)
        {
          for (int index2 = 0; index2 < this.m_player.GetLength(1); ++index2)
          {
            if ((UnityEngine.Object) this.m_player[index1, index2] != (UnityEngine.Object) null && ((Behaviour) this.m_player[index1, index2]).enabled)
            {
              ((Behaviour) this.m_player[index1, index2]).enabled = false;
              ((Behaviour) this.m_player[index1, index2]).enabled = true;
            }
          }
        }
        if ((bool) (UnityEngine.Object) this.m_title && ((Behaviour) this.m_title).enabled)
        {
          ((Behaviour) this.m_title).enabled = !((Behaviour) this.m_title).enabled;
          ((Behaviour) this.m_title).enabled = !((Behaviour) this.m_title).enabled;
        }
        for (int index = 0; index < 2; ++index)
        {
          if ((bool) (UnityEngine.Object) this.DeadCounts[index] && ((Behaviour) this.DeadCounts[index]).enabled)
          {
            ((Behaviour) this.DeadCounts[index]).enabled = false;
            ((Behaviour) this.DeadCounts[index]).enabled = true;
          }
        }
        break;
      case NetworkNews.Refresh_AllianceWarRound:
        if (this.bReturn)
          break;
        if (this.BattleSide > (byte) 0)
          this.bRequest = this.bReturn = true;
        else
          this.bExit = true;
        this.bEnd = true;
        break;
      case NetworkNews.Refresh_RecvAllianceInfo:
        if ((ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None || DataManager.Instance.RoleAlliance.Id == 0U) && (bool) (UnityEngine.Object) this.door)
        {
          this.door.CloseMenu();
          break;
        }
        if (!this.BattleReplay && ActivityManager.Instance.AW_State != EAllianceWarState.EAWS_Run)
        {
          this.bRequest = true;
          this.bReturn = true;
          break;
        }
        if (!this.bReturn && (this.BattleReplay || (int) ActivityManager.Instance.AW_Round == (int) UIAllianceWarBattle.BattleRoyale.GameRound && ActivityManager.Instance.AW_RoundBeginTime == UIAllianceWarBattle.BattleRoyale.BeginTime))
          break;
        if (this.bReturn)
        {
          this.bRequest = true;
          break;
        }
        if (this.bReturn)
          break;
        if (this.BattleSide > (byte) 0)
        {
          this.bRequest = this.bReturn = true;
          break;
        }
        this.bExit = true;
        break;
      default:
        switch (networkNews)
        {
          case NetworkNews.Login:
            if ((ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None || DataManager.Instance.RoleAlliance.Id == 0U) && (bool) (UnityEngine.Object) this.door)
            {
              this.door.CloseMenu();
              return;
            }
            if (this.BattleReplay)
              return;
            LeftRightFly.Instance.UpdateCutinStat();
            return;
          case NetworkNews.Fallout:
            return;
          case NetworkNews.Refresh_Asset:
            return;
          default:
            if (networkNews == NetworkNews.Refresh_Alliance)
              ;
            return;
        }
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (!(bool) (UnityEngine.Object) this.door)
      return;
    if (sender.m_BtnID1 == 1)
      ActivityManager.Instance.Send_REQUEST_ALLIANCEWAR_RANKPRIZE();
    else if (sender.m_BtnID1 == 2)
    {
      if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
        ActivityManager.Instance.AllianceWarMgr.m_CombatPlayerData[0].AllianceTag = UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString();
      if (UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
        ActivityManager.Instance.AllianceWarMgr.m_CombatPlayerData[1].AllianceTag = UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString();
      ActivityManager.Instance.AllianceWarMgr.Send_MSG_REQUEST_ALLIANCEWAR_COMBAT_REPORT((byte) ((uint) UIAllianceWarBattle.BattleRoyale.MatchID - 1U), this.BattleRound);
      this.PauseReplay = this.BattleReplay;
    }
    else if (sender.m_BtnID1 == 3)
    {
      if (UIAllianceWarBattle.BattleRoyale.AutobotTag == null || UIAllianceWarBattle.BattleRoyale.AutobotTag.Length <= 2)
        return;
      this.PauseReplay = this.BattleReplay;
      this.DM.AllianceView.Id = 0U;
      this.DM.AllianceView.Tag = UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString();
      this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5);
    }
    else if (sender.m_BtnID1 == 4)
    {
      if (UIAllianceWarBattle.BattleRoyale.DecepticonTag == null || UIAllianceWarBattle.BattleRoyale.DecepticonTag.Length <= 2)
        return;
      this.PauseReplay = this.BattleReplay;
      this.DM.AllianceView.Id = 0U;
      this.DM.AllianceView.Tag = UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString();
      this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5);
    }
    else if (sender.m_BtnID1 == 6)
    {
      this.transform.GetChild(13).GetChild(1).GetChild(3).gameObject.SetActive(true);
      this.transform.GetChild(13).GetChild(1).GetChild(4).gameObject.SetActive(true);
      this.BattleTime = (double) Time.time - (double) this.BattlePrepare;
      this.BattleRound = this.LastWinner = (byte) 0;
      this.bEnd = false;
      Time.timeScale = (float) UIAllianceWarBattle.ReplaySpeed;
      this.SetStage(UIAllianceWarBattle.MoveStage.MS_STARTING);
      AudioManager.Instance.PlayMP3SFX(BGMType.LegionWar, Vol: 0.54f);
    }
    else if (sender.m_BtnID1 == 7)
    {
      this.transform.GetChild(13).GetChild(1).GetChild(4).gameObject.SetActive(true);
      Time.timeScale = (float) UIAllianceWarBattle.ReplaySpeed;
    }
    else if (sender.m_BtnID1 == 8)
    {
      this.transform.GetChild(13).GetChild(1).GetChild(4).gameObject.SetActive(false);
      Time.timeScale = 0.0f;
    }
    else if (sender.m_BtnID1 == 9)
    {
      switch (UIAllianceWarBattle.ReplaySpeed)
      {
        case 1:
          UIAllianceWarBattle.ReplaySpeed = (byte) 2;
          this.m_player[2, 14].text = "x2";
          break;
        case 2:
          UIAllianceWarBattle.ReplaySpeed = (byte) 3;
          this.m_player[2, 14].text = "x3";
          break;
        default:
          UIAllianceWarBattle.ReplaySpeed = (byte) 1;
          this.m_player[2, 14].text = "x1";
          break;
      }
      if ((double) Time.timeScale <= 0.0 || this.bEnd)
        return;
      Time.timeScale = (float) UIAllianceWarBattle.ReplaySpeed;
    }
    else
    {
      if (sender.m_BtnID1 != 5)
        return;
      if (this.BattlePosition > (byte) 0)
      {
        int index = 0;
        int num = 1;
        if ((int) this.BattlePosition > num)
        {
          while (index < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length && ((int) UIAllianceWarBattle.BattleRoyale.BattleMatch[index].WinnerSide == (int) this.BattleSide || ++num < (int) this.BattlePosition))
            ++index;
        }
        if (num >= (int) this.BattlePosition)
        {
          this.BattleTime = (double) Time.time - (double) this.BattlePrepare - 0.125;
          if (this.BattlePosition > (byte) 1)
            this.BattleTime -= (double) ((index + 1) * (int) ActivityManager.Instance.AW_FightTime);
          this.bEnd = false;
          if ((double) Time.timeScale > 0.0)
          {
            Time.timeScale = (float) UIAllianceWarBattle.ReplaySpeed;
            this.transform.GetChild(13).GetChild(1).GetChild(4).gameObject.SetActive(true);
          }
          this.transform.GetChild(13).GetChild(1).GetChild(3).gameObject.SetActive(true);
          this.transform.GetChild(8).GetChild(5).gameObject.SetActive(false);
          this.transform.GetChild(7).GetChild(5).gameObject.SetActive(false);
          this.SetStage(UIAllianceWarBattle.MoveStage.MS_STARTING);
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14630U), (ushort) byte.MaxValue);
          AudioManager.Instance.PlayMP3SFX(BGMType.LegionWar, Vol: 0.54f);
        }
        else
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(14632U), (ushort) byte.MaxValue);
      }
      else
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14627U), (ushort) byte.MaxValue);
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      if (sender.m_BtnID2 >= UIAllianceWarBattle.BattleRoyale.Autobot.Length || UIAllianceWarBattle.BattleRoyale.Autobot[sender.m_BtnID2].Name == null)
        return;
      this.PauseReplay = this.BattleReplay;
      this.DM.ShowLordProfile(UIAllianceWarBattle.BattleRoyale.Autobot[sender.m_BtnID2].Name.ToString());
    }
    else
    {
      if (sender.m_BtnID1 != 2 || sender.m_BtnID2 >= UIAllianceWarBattle.BattleRoyale.Decepticon.Length || UIAllianceWarBattle.BattleRoyale.Decepticon[sender.m_BtnID2].Name == null)
        return;
      this.PauseReplay = this.BattleReplay;
      this.DM.ShowLordProfile(UIAllianceWarBattle.BattleRoyale.Decepticon[sender.m_BtnID2].Name.ToString());
    }
  }

  public void RequestApplyList()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_APPLYALLIANCELIST;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void RequestAllianceReplay()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_REPLAY;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnStateChange(EAllianceWarState oldState, EAllianceWarState NewState)
  {
    if (NewState >= EAllianceWarState.EAWS_Run)
      return;
    this.door.CloseMenu();
  }

  private void iniFightingBurst(
    GameObject LeftHero,
    GameObject RightHero,
    bool LeftHeroWin,
    double NowRoundTime)
  {
    GameObject gameObject1;
    GameObject gameObject2;
    if (LeftHeroWin)
    {
      gameObject1 = LeftHero;
      gameObject2 = RightHero;
    }
    else
    {
      gameObject1 = RightHero;
      gameObject2 = LeftHero;
    }
    if ((UnityEngine.Object) gameObject1 != (UnityEngine.Object) null)
    {
      if (!gameObject1.activeSelf)
        gameObject1.SetActive(true);
      Transform transform = gameObject1.transform;
      if ((UnityEngine.Object) transform != (UnityEngine.Object) null)
      {
        transform.localPosition = new Vector3(!LeftHeroWin ? -51f : 51f, 27f, 0.0f);
        transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, !LeftHeroWin ? -15f : 15f));
        transform.localScale = Vector3.one;
        Color color = new Color(1f, 1f, 1f, 1f);
        ((Graphic) transform.GetChild(0).GetComponent<Image>()).color = color;
        ((Graphic) transform.GetChild(1).GetComponent<Image>()).color = color;
      }
    }
    if (!((UnityEngine.Object) gameObject2 != (UnityEngine.Object) null))
      return;
    Transform transform1 = gameObject2.transform;
    if (!((UnityEngine.Object) transform1 != (UnityEngine.Object) null))
      return;
    transform1.localPosition = new Vector3(!LeftHeroWin ? -51f : 51f, 27f, 0.0f);
    if (NowRoundTime > 4.070000171661377)
    {
      Color color = new Color(1f, 1f, 1f, (float) (5.52222204208374 - 1.111111044883728 * NowRoundTime));
      ((Graphic) transform1.GetChild(0).GetComponent<Image>()).color = color;
      ((Graphic) transform1.GetChild(1).GetComponent<Image>()).color = color;
    }
    else
    {
      float z = (float) UnityEngine.Random.Range(16, 22) * (UnityEngine.Random.Range(0, 2) != 0 ? 1f : -1f);
      this.burstRotationSpeed = (float) UnityEngine.Random.Range(200, 500);
      this.burstRotationSpeed *= UnityEngine.Random.Range(0, 2) != 0 ? 1f : -1f;
      transform1.localRotation = new Quaternion(0.0f, 0.0f, z, 0.0f);
      float num = (float) UnityEngine.Random.Range(100, 106) / 100f;
      this.burstScaleSpeed = (float) UnityEngine.Random.Range(200, 500);
      this.burstScaleSpeed *= UnityEngine.Random.Range(0, 2) != 0 ? 1f : -1f;
      transform1.localScale = Vector3.one * num;
      Color color = new Color(1f, 1f, 1f, 1f);
      ((Graphic) transform1.GetChild(0).GetComponent<Image>()).color = color;
      ((Graphic) transform1.GetChild(1).GetComponent<Image>()).color = color;
    }
  }

  private void iniFightingEnd(
    GameObject LeftHero,
    GameObject RightHero,
    bool LeftHeroWin,
    double NowRoundTime)
  {
    GameObject gameObject1;
    GameObject gameObject2;
    if (LeftHeroWin)
    {
      gameObject1 = LeftHero;
      gameObject2 = RightHero;
    }
    else
    {
      gameObject1 = RightHero;
      gameObject2 = LeftHero;
    }
    if ((UnityEngine.Object) gameObject2 != (UnityEngine.Object) null || gameObject2.activeSelf)
    {
      gameObject2.SetActive(false);
      Color color = new Color(1f, 1f, 1f, 1f);
      ((Graphic) gameObject2.transform.GetChild(0).GetComponent<Image>()).color = color;
      ((Graphic) gameObject2.transform.GetChild(1).GetComponent<Image>()).color = color;
    }
    if (!((UnityEngine.Object) gameObject1 != (UnityEngine.Object) null))
      return;
    if (!gameObject1.activeSelf)
      gameObject1.SetActive(true);
    Transform transform = gameObject1.transform;
    if (!((UnityEngine.Object) transform != (UnityEngine.Object) null))
      return;
    float num1;
    float num2;
    float z;
    if (NowRoundTime > 5.0199999809265137)
    {
      num1 = (float) (11.363636016845703 * NowRoundTime - 67.045455932617188);
      if (LeftHeroWin)
      {
        num2 = (float) (234.65908813476563 - 39.772727966308594 * NowRoundTime);
        z = (float) (5.6818180084228516 * NowRoundTime + 33.522727966308594);
      }
      else
      {
        num2 = (float) (39.772727966308594 * NowRoundTime - 234.65908813476563);
        z = (float) (33.522727966308594 - 5.6818180084228516 * NowRoundTime);
      }
    }
    else
    {
      num1 = (float) (-3704.800048828125 - 470.0 * NowRoundTime);
      if (LeftHeroWin)
      {
        num2 = (float) (1720.0 * NowRoundTime - 8599.400390625);
        z = (float) (2003.0 - 400.0 * NowRoundTime);
      }
      else
      {
        num2 = (float) (8599.400390625 - 1720.0 * NowRoundTime);
        z = (float) (400.0 * NowRoundTime - 2003.0);
      }
    }
    transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, z));
    float num3;
    if (NowRoundTime > 5.434999942779541)
      num3 = (float) (2003.225830078125 - 322.58065795898438 * NowRoundTime);
    else
      num3 = (float) (322.58065795898438 * NowRoundTime - 1503.225830078125);
  }

  protected struct Hero
  {
    public UIHIBtn HeroHint;
    public GameObject HeroHead;
    public uTweenRotation Rotation;
    public uTweenPosition Position;
  }

  protected enum MoveStage : byte
  {
    MS_WAITING,
    MS_STARTING,
    MS_FIGHTING,
    MS_FIGHTING_START,
    MS_FIGHTING_MOVE,
    MS_FIGHTING_PULL,
    MS_FIGHTING_ATTACK,
    MS_FIGHTING_HIT,
    MS_FIGHTING_SPLIT,
    MS_FIGHTING_DAMAGE,
    MS_FIGHTING_BURST,
    MS_FIGHTING_END,
    MS_FINISH,
    MS_MAX,
  }
}
