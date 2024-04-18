// Decompiled with JetBrains decompiler
// Type: UISummonMonster
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UISummonMonster : 
  GUIWindow,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private Transform MonstIconTrans;
  private Transform MonsterPriceTrans;
  private Transform MonsterEffTran;
  private UIHIBtn MonsterPriceBtn;
  private GameObject CostIntoObj;
  private GameObject NoticeObj;
  private GameObject MonsterObj;
  private GameObject MainObj;
  private GameObject InfoObj;
  private GameObject LeftTimeObj;
  private GameObject[] MonsterEffect = new GameObject[4];
  private RectTransform CaptionRect;
  private RectTransform MonsterTrans;
  private UIText SummonMonsterTimesText;
  private UIText TitleText;
  private UIText MonsterNameText;
  private UIText SummonCostText;
  private UIText CaptionText;
  private UIText LeftTimeTitleText;
  private UIText LeftTimeText;
  private UISummonMonster._TextUnderLine MonsterPositionText;
  private UISummonMonster._TextUnderLine PriceTitleText;
  private UIButton SummonOrMove;
  private CString MonsterNameStr;
  private CString ArrChatStr;
  private CString PositionStr;
  private CString SummonCostStr;
  private CString SummonMonsterTimesStr;
  private CString LeftTimeStr;
  private AssetBundle AB;
  private AssetBundleRequest AR;
  private GameObject MonsterGo;
  private SkinnedMeshRenderer MonsterSkin;
  private ushort HeroID;
  private ushort Modle;
  private ushort HeroHead;
  private ushort MonsterID;
  private int AssetKey;
  private int MonsterMapID;
  private int MonsterKingdomID;
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
  private Vector3 OriMonsterPos;
  private float DelayTime = -1f;
  private float ShowScaleTime = 0.4f;
  private UISummonMonster.eDelayParm DelayParm;
  private UISummonMonster.eDelayParm DelayParm2;
  private UISummonMonster.BtnStyle Style;
  private long SummonLeftTime;
  private byte NeedPoint;
  private ushort PriceID;
  private _UISummonMonsterInfo Info;
  private byte bCloseUI;

  void IUIHIBtnClickHandler.OnHIButtonClick(UIHIBtn sender)
  {
    if (sender.m_BtnID2 == 0)
      return;
    MallManager.Instance.OpenDetail(sender.HIID);
  }

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 1);
    this.MainObj = this.transform.GetChild(0).gameObject;
    this.InfoObj = this.transform.GetChild(1).gameObject;
    Transform child = this.transform.GetChild(0);
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    UIButtonHint uiButtonHint1 = child.GetChild(0).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint1.Parm1 = (ushort) 14507;
    uiButtonHint1.Parm2 = (byte) 66;
    this.SummonMonsterTimesText = child.GetChild(0).GetChild(1).GetComponent<UIText>();
    this.SummonMonsterTimesText.font = ttfFont;
    this.TitleText = child.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.TitleText.font = ttfFont;
    this.TitleText.text = DataManager.Instance.mStringTable.GetStringByID(14503U);
    this.MonsterNameText = child.GetChild(2).GetChild(0).GetComponent<UIText>();
    this.MonsterNameText.font = ttfFont;
    this.MonsterEffTran = child.GetChild(3);
    this.MonsterObj = child.GetChild(4).gameObject;
    this.MonsterTrans = child.GetChild(4).GetChild(0).GetComponent<RectTransform>();
    this.OriMonsterPos = this.MonsterTrans.anchoredPosition3D;
    this.MonsterPositionText.Init(child.GetChild(4).GetChild(1).GetChild(1).GetComponent<RectTransform>(), child.GetChild(4).GetChild(1).GetChild(0), 241f, ttfFont);
    this.MonsterPositionText.Button.m_Handler = (IUIButtonClickHandler) this;
    this.MonsterPositionText.Button.m_BtnID1 = 1;
    UIButton component1 = child.GetChild(4).GetChild(2).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 2;
    UIButtonHint uiButtonHint2 = child.GetChild(4).GetChild(3).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint2.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint2.Parm1 = (ushort) 14508;
    this.LeftTimeTitleText = child.GetChild(4).GetChild(3).GetChild(0).GetComponent<UIText>();
    this.LeftTimeTitleText.font = ttfFont;
    this.LeftTimeTitleText.text = DataManager.Instance.mStringTable.GetStringByID(8110U);
    this.LeftTimeText = child.GetChild(4).GetChild(3).GetChild(1).GetComponent<UIText>();
    this.LeftTimeText.font = ttfFont;
    this.LeftTimeObj = ((Component) this.LeftTimeText).gameObject;
    this.MonstIconTrans = child.GetChild(5);
    GUIManager.Instance.InitianHeroItemImg(this.MonstIconTrans, eHeroOrItem.Hero, (ushort) 0, (byte) 1, (byte) 0, bShowText: false, bAutoShowHint: false, bClickSound: false);
    UIButton component2 = child.GetChild(6).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 3;
    if (GUIManager.Instance.IsArabic)
      ((Component) component2).transform.localScale = new Vector3(-1f, 1f, 1f);
    this.SummonOrMove = child.GetChild(7).GetComponent<UIButton>();
    this.SummonOrMove.m_Handler = (IUIButtonClickHandler) this;
    this.CostIntoObj = child.GetChild(7).GetChild(0).gameObject;
    this.SummonCostText = child.GetChild(7).GetChild(0).GetChild(1).GetComponent<UIText>();
    this.SummonCostText.font = ttfFont;
    this.CaptionRect = child.GetChild(7).GetChild(1).GetComponent<RectTransform>();
    this.CaptionText = ((Component) this.CaptionRect).GetComponent<UIText>();
    this.CaptionText.font = ttfFont;
    UILoadImageHander itemInfo = (UILoadImageHander) GUIManager.Instance.m_ItemInfo;
    child.GetChild(8).GetComponent<CustomImage>().hander = itemInfo;
    child.GetChild(8).GetChild(0).GetComponent<CustomImage>().hander = itemInfo;
    child.GetChild(8).GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = itemInfo;
    this.NoticeObj = child.GetChild(8).gameObject;
    this.PriceTitleText.Init(child.GetChild(9).GetChild(4).GetChild(1).GetComponent<RectTransform>(), child.GetChild(9).GetChild(4).GetChild(0), 372.5f, ttfFont);
    this.PriceTitleText.SetText(DataManager.Instance.mStringTable.GetStringByID(14505U));
    UIButtonHint uiButtonHint3 = ((Component) this.PriceTitleText.Button).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint3.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint3.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint3.Parm1 = (ushort) 14509;
    this.MonsterPriceTrans = child.GetChild(9).GetChild(3);
    GUIManager.Instance.InitianHeroItemImg(this.MonsterPriceTrans, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.MonsterPriceBtn = this.MonsterPriceTrans.GetComponent<UIHIBtn>();
    this.MonsterPriceBtn.m_Handler = (IUIHIBtnClickHandler) this;
    if (GUIManager.Instance.bOpenOnIPhoneX)
      ((Behaviour) child.GetChild(10).GetComponent<CustomImage>()).enabled = false;
    else
      child.GetChild(10).GetComponent<CustomImage>().hander = (UILoadImageHander) GUIManager.Instance.m_ItemInfo;
    child.GetChild(10).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) GUIManager.Instance.m_ItemInfo;
    UIButton component3 = child.GetChild(10).GetChild(0).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 5;
    this.ArrChatStr = StringManager.Instance.SpawnString();
    this.MonsterNameStr = StringManager.Instance.SpawnString();
    this.PositionStr = StringManager.Instance.SpawnString();
    this.SummonCostStr = StringManager.Instance.SpawnString();
    this.SummonMonsterTimesStr = StringManager.Instance.SpawnString();
    this.LeftTimeStr = StringManager.Instance.SpawnString();
    this.AnList = new AnimationUnit.AnimName[this.ANIndex.Length];
    this.MonsterAct = StringManager.Instance.SpawnString();
    this.MonsterAct.Append(AnimationUnit.ANIM_STRING[0]);
    this.IdleHash = this.MonsterAct.GetHashCode(false);
    int index = 0;
    this.MonsterEffect[index] = ParticleManager.Instance.Spawn((ushort) 419, this.MonstIconTrans, new Vector3(0.0f, 0.0f, -800f), 1.6f, true);
    this.MonsterEffect[index].transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    GUIManager.Instance.SetLayer(this.MonsterEffect[index], 5);
    this.UpdateStyle();
  }

  private void UpdateStyle()
  {
    ActivityManager instance = ActivityManager.Instance;
    this.SummonLeftTime = instance.AllianceSummon_SummonData.MonsterEndTime;
    if (this.SummonLeftTime < DataManager.Instance.ServerTime)
      this.SummonLeftTime = 0L;
    this.MonsterKingdomID = (int) instance.AllianceSummon_SummonData.MonsterPos.KingdomID;
    this.MonsterMapID = GameConstants.PointCodeToMapID(instance.AllianceSummon_SummonData.MonsterPos.CombatPoint.zoneID, instance.AllianceSummon_SummonData.MonsterPos.CombatPoint.pointID);
    if (this.DelayParm == UISummonMonster.eDelayParm.SummonWait || this.DelayParm == UISummonMonster.eDelayParm.MonsterScaleIn || this.DelayParm == UISummonMonster.eDelayParm.MonsterScaleInSound)
      return;
    ushort monsterId = instance.AllianceSummon_SummonData.MonsterID;
    this.NeedPoint = instance.AllianceSummon_SummonData.CostPoint;
    this.PriceID = instance.AllianceSummon_SummonData.GiftID;
    if (DataManager.Instance.RoleAlliance.Id == 0U)
      this.bCloseUI = (byte) 1;
    else if (this.SummonLeftTime == 0L)
    {
      if ((int) monsterId != (int) this.MonsterID || this.Style != UISummonMonster.BtnStyle.Summon)
      {
        this.DestroyAB();
        this.MonsterID = monsterId;
        this.SetStyle(UISummonMonster.BtnStyle.Summon);
      }
      else
      {
        int index = 0;
        if (!this.MonsterEffect[index].activeSelf)
          this.MonsterEffect[index].SetActive(true);
      }
    }
    else if ((int) monsterId != (int) this.MonsterID || this.Style != UISummonMonster.BtnStyle.Move)
    {
      this.DestroyAB();
      this.MonsterID = monsterId;
      this.SetStyle(UISummonMonster.BtnStyle.Move);
    }
    else
    {
      this.UpdateMonsterPosition();
      int index = 3;
      if ((Object) this.MonsterEffect[index] != (Object) null && !this.MonsterEffect[index].activeSelf)
        this.MonsterEffect[index].SetActive(true);
    }
    this.UpdateSummonMonsterTimes();
  }

  private void SetStyle(UISummonMonster.BtnStyle Style)
  {
    this.Style = Style;
    if (Style == UISummonMonster.BtnStyle.Move)
    {
      this.CostIntoObj.SetActive(false);
      this.CaptionRect.anchoredPosition = Vector2.zero;
      this.CaptionRect.sizeDelta = new Vector2(197f, 90.1f);
      this.MonsterObj.SetActive(true);
      this.MonstIconTrans.gameObject.SetActive(false);
      if (this.MainObj.activeSelf)
        this.UpdateMonster();
      else
        this.SetDelay(0.0f, UISummonMonster.eDelayParm.WaitChangeMove);
      this.CaptionText.text = DataManager.Instance.mStringTable.GetStringByID(834U);
      this.SummonOrMove.m_BtnID1 = 1;
      this.UpdateSummonLeftTime();
    }
    else
    {
      this.CostIntoObj.SetActive(true);
      this.CaptionRect.anchoredPosition = new Vector2(0.0f, -26f);
      this.CaptionRect.sizeDelta = new Vector2(197f, 35f);
      this.MonsterObj.SetActive(false);
      this.MonstIconTrans.gameObject.SetActive(true);
      if (this.MainObj.activeSelf)
        this.UpdateMonsterIcon();
      else
        this.SetDelay(0.0f, UISummonMonster.eDelayParm.WaitChangeSummon);
      this.CaptionText.text = DataManager.Instance.mStringTable.GetStringByID(14504U);
      this.SummonOrMove.m_BtnID1 = 0;
      int index1 = 3;
      if ((Object) this.MonsterEffect[index1] != (Object) null)
        this.MonsterEffect[index1].SetActive(false);
      int index2 = 1;
      if ((Object) this.MonsterEffect[index2] != (Object) null)
        this.MonsterEffect[index2].SetActive(false);
      int index3 = 0;
      if (!this.MonsterEffect[index3].activeSelf)
        this.MonsterEffect[index3].SetActive(true);
    }
    this.UpdateSummonMonsterTimes();
    this.InitPrice();
  }

  public override void ReOnOpen()
  {
    this.transform.gameObject.SetActive(true);
    this.CheckMonsterSkin();
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2) => this.UpdateStyle();

  private void CheckMonsterSkin()
  {
    if (this.Style == UISummonMonster.BtnStyle.Summon)
      return;
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

  public override void OnClose()
  {
    if (this.Info != null)
      this.Info.OnClose();
    StringManager.Instance.DeSpawnString(this.ArrChatStr);
    StringManager.Instance.DeSpawnString(this.MonsterNameStr);
    StringManager.Instance.DeSpawnString(this.PositionStr);
    StringManager.Instance.DeSpawnString(this.SummonCostStr);
    StringManager.Instance.DeSpawnString(this.SummonMonsterTimesStr);
    StringManager.Instance.DeSpawnString(this.LeftTimeStr);
    int index1 = 0;
    ParticleManager.Instance.DeSpawn(this.MonsterEffect[index1]);
    this.MonsterEffect[index1] = (GameObject) null;
    int index2 = 3;
    ParticleManager.Instance.DeSpawn(this.MonsterEffect[index2]);
    this.MonsterEffect[index2] = (GameObject) null;
    int index3 = 1;
    ParticleManager.Instance.DeSpawn(this.MonsterEffect[index3]);
    this.MonsterEffect[index3] = (GameObject) null;
    int index4 = 2;
    if ((Object) this.MonsterEffect[index4] != (Object) null && this.MonsterEffect[index4].activeSelf)
    {
      this.MonsterEffect[index4].transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
      this.MonsterEffect[index4].transform.localPosition = new Vector3(0.0f, 0.0f, -50f);
    }
    if (!this.MainObj.activeSelf)
      this.MainObj.SetActive(true);
    this.DestroyAB();
  }

  private void DestroyAB()
  {
    if ((Object) this.MonsterGo != (Object) null)
    {
      if (!this.MainObj.activeSelf)
      {
        bool activeSelf = this.transform.gameObject.activeSelf;
        if (!activeSelf)
          this.transform.gameObject.SetActive(!activeSelf);
        this.MainObj.SetActive(true);
        ModelLoader.Instance.Unload((Object) this.MonsterGo);
        this.MainObj.SetActive(false);
        if (!activeSelf)
          this.transform.gameObject.SetActive(activeSelf);
      }
      else
        ModelLoader.Instance.Unload((Object) this.MonsterGo);
    }
    if (this.AssetKey != 0)
      AssetManager.UnloadAssetBundle(this.AssetKey);
    this.MonsterGo = (GameObject) null;
    this.AssetKey = 0;
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (this.bCloseUI == (byte) 1)
    {
      this.bCloseUI = (byte) 0;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((Object) menu != (Object) null))
        return;
      menu.CloseMenu_Alliance(this.m_eWindow);
    }
    else
    {
      if (!this.isActiveAndEnabled || !this.MainObj.activeSelf)
        return;
      this.UpdateDelayTime();
      if (bOnSecond)
        this.UpdateSummonLeftTime();
      if (this.Style != UISummonMonster.BtnStyle.Move)
        return;
      if ((Object) this.MonsterGo == (Object) null && this.AR != null && this.AR.isDone)
      {
        Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.HeroID);
        this.MonsterGo = ModelLoader.Instance.Load(recordByKey.Modle, this.AB, (ushort) recordByKey.TextureNo);
        if ((Object) this.MonsterGo == (Object) null)
          return;
        this.MonsterGo.transform.SetParent((Transform) this.MonsterTrans, false);
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
        if ((Object) this.MonsterEffect[3] == (Object) null)
        {
          this.MonsterEffect[3] = ParticleManager.Instance.Spawn((ushort) 422, (Transform) this.MonsterTrans, new Vector3(0.0f, 240f, -85.9f), 1f, true);
          this.MonsterEffect[3].transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
          GUIManager.Instance.SetLayer(this.MonsterEffect[3], 5);
        }
        else
          this.MonsterEffect[3].SetActive(true);
      }
      if (!((Object) this.MonsterAN != (Object) null) || !((Object) this.MonsterGo != (Object) null))
        return;
      if ((!this.MonsterAN.IsPlaying(this.MonsterAct.ToString()) || this.MonsterAct.GetHashCode(false) == this.IdleHash) && (double) this.ActionTimeRandom < 9.9999997473787516E-05)
      {
        this.ActionTimeRandom = (float) Random.Range(3, 7);
        this.ActionTime = 0.0f;
      }
      if ((double) this.ActionTimeRandom <= 9.9999997473787516E-05)
        return;
      this.ActionTime += Time.smoothDeltaTime;
      if ((double) this.ActionTime < (double) this.ActionTimeRandom)
        return;
      this.MonsterActionChang();
    }
  }

  private void UpdateDelayTime()
  {
    if ((double) this.DelayTime >= 0.0)
    {
      this.DelayTime -= Time.deltaTime;
      if ((double) this.DelayTime < 0.0)
      {
        switch (this.DelayParm)
        {
          case UISummonMonster.eDelayParm.MonsterScaleIn:
            this.DestroyAB();
            this.SetStyle(UISummonMonster.BtnStyle.Move);
            if (this.AssetKey == 0)
            {
              this.DelayParm = UISummonMonster.eDelayParm.SummonSuccessWait;
              break;
            }
            AudioManager.Instance.PlayUISFX(UIKind.SummonSuccess);
            int index1 = 1;
            if ((Object) this.MonsterEffect[index1] != (Object) null)
              this.MonsterEffect[index1].SetActive(false);
            int index2 = 2;
            this.MonsterEffect[index2] = ParticleManager.Instance.Spawn((ushort) 421, this.MonsterEffTran, new Vector3(0.0f, 0.0f, -850f), 1.6f, true);
            GUIManager.Instance.SetLayer(this.MonsterEffect[index2], 5);
            ((Transform) this.MonsterTrans).localScale = Vector3.zero;
            break;
          case UISummonMonster.eDelayParm.WaitChangeSummon:
            this.DestroyAB();
            this.SetStyle(UISummonMonster.BtnStyle.Summon);
            break;
          case UISummonMonster.eDelayParm.WaitChangeMove:
            this.DestroyAB();
            this.SetStyle(UISummonMonster.BtnStyle.Move);
            break;
          case UISummonMonster.eDelayParm.SendSummon:
            int index3 = 1;
            if ((Object) this.MonsterEffect[index3] == (Object) null)
            {
              this.MonsterEffect[index3] = ParticleManager.Instance.Spawn((ushort) 420, this.MonstIconTrans, Vector3.zero, 1.6f, true);
              GUIManager.Instance.SetLayer(this.MonsterEffect[index3], 5);
            }
            else
              this.MonsterEffect[index3].SetActive(true);
            AudioManager.Instance.PlayUISFX(UIKind.Summoning);
            this.SetDelay(0.7f, UISummonMonster.eDelayParm.SummonWait);
            MessagePacket messagePacket = new MessagePacket((ushort) 1024);
            messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AS_SUMMON;
            messagePacket.AddSeqId();
            messagePacket.Send();
            break;
          case UISummonMonster.eDelayParm.MonsterScaleInSound:
            this.SetDelay(0.2f, UISummonMonster.eDelayParm.MonsterScaleIn);
            break;
        }
      }
    }
    if (this.DelayParm != UISummonMonster.eDelayParm.MonsterScaleIn || (double) this.DelayTime >= 0.0)
      return;
    this.DelayTime -= Time.deltaTime;
    float num = (float) -((double) this.DelayTime / (double) this.ShowScaleTime);
    if ((double) num < 1.0)
    {
      ((Transform) this.MonsterTrans).localScale = Vector3.one * num;
      this.MonsterTrans.anchoredPosition3D = new Vector3(this.OriMonsterPos.x, this.OriMonsterPos.y * num, this.OriMonsterPos.z);
    }
    else
    {
      this.DelayParm = UISummonMonster.eDelayParm.None;
      ((Transform) this.MonsterTrans).localScale = Vector3.one;
      this.MonsterTrans.anchoredPosition3D = this.OriMonsterPos;
      this.UpdateStyle();
      if (this.SummonLeftTime <= 0L)
        return;
      this.UpdateSummonLeftTime();
      if (this.DelayParm2 != UISummonMonster.eDelayParm.WaitSummonTime || this.SummonLeftTime <= 0L)
        return;
      this.DelayParm2 = UISummonMonster.eDelayParm.None;
      this.LeftTimeObj.SetActive(true);
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

  private void UpdateMonster()
  {
    if (this.MonsterID == (ushort) 0)
      return;
    DataManager instance = DataManager.Instance;
    MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.MonsterID);
    CString Name = StringManager.Instance.StaticString1024();
    ((Transform) this.MonsterTrans).localScale = Vector3.one;
    this.MonsterTrans.anchoredPosition3D = this.OriMonsterPos;
    this.HeroID = recordByKey.ModelID;
    this.Modle = instance.HeroTable.GetRecordByKey(this.HeroID).Modle;
    Name.IntToFormat((long) this.Modle, 5);
    Name.AppendFormat("Role/hero_{0}");
    this.MonsterGo = (GameObject) null;
    this.AR = (AssetBundleRequest) null;
    if (AssetManager.GetAssetBundleDownload(Name, AssetPath.Role, AssetType.Hero, this.Modle, true))
    {
      this.AB = AssetManager.GetAssetBundle(Name, out this.AssetKey);
      if ((Object) this.AB != (Object) null)
        this.AR = this.AB.LoadAsync("m", typeof (GameObject));
    }
    this.MonsterNameStr.ClearString();
    this.MonsterNameStr.Append(instance.mStringTable.GetStringByID((uint) recordByKey.NameID));
    this.MonsterNameText.text = this.MonsterNameStr.ToString();
    this.MonsterNameText.SetAllDirty();
    this.MonsterNameText.cachedTextGenerator.Invalidate();
    this.UpdateMonsterPosition();
    this.MonsterAct.ClearString();
    this.MonsterAct.Append(AnimationUnit.ANIM_STRING[0]);
  }

  private void UpdateMonsterPosition()
  {
    DataManager instance = DataManager.Instance;
    Vector2 mapPosbySpriteId = GameConstants.getTileMapPosbySpriteID(this.MonsterMapID);
    this.PositionStr.ClearString();
    this.PositionStr.StringToFormat(instance.mStringTable.GetStringByID(4504U));
    this.PositionStr.IntToFormat((long) this.MonsterKingdomID);
    this.PositionStr.StringToFormat(instance.mStringTable.GetStringByID(4505U));
    this.PositionStr.IntToFormat((long) (int) mapPosbySpriteId.x);
    this.PositionStr.StringToFormat(instance.mStringTable.GetStringByID(4506U));
    this.PositionStr.IntToFormat((long) (int) mapPosbySpriteId.y);
    if (GUIManager.Instance.IsArabic)
      this.PositionStr.AppendFormat("{5}{4} {3}{2} {1}{0}");
    else
      this.PositionStr.AppendFormat("{0}{1} {2}{3} {4}{5}");
    this.MonsterPositionText.SetText(this.PositionStr.ToString());
    this.MonsterPositionText.Button.m_BtnID3 = this.MonsterKingdomID;
    this.MonsterPositionText.Button.m_BtnID2 = this.MonsterMapID;
    this.SummonOrMove.m_BtnID3 = this.MonsterPositionText.Button.m_BtnID3;
    this.SummonOrMove.m_BtnID2 = this.MonsterPositionText.Button.m_BtnID2;
    CString tmpS = StringManager.Instance.StaticString1024();
    tmpS.StringToFormat(instance.RoleAlliance.Tag);
    tmpS.StringToFormat(this.MonsterNameStr);
    tmpS.AppendFormat("[{0}]{1}");
    this.ArrChatStr.ClearString();
    this.ArrChatStr.StringToFormat(tmpS);
    this.ArrChatStr.StringToFormat(instance.mStringTable.GetStringByID(4504U));
    this.ArrChatStr.IntToFormat((long) this.MonsterKingdomID);
    this.ArrChatStr.StringToFormat(instance.mStringTable.GetStringByID(4505U));
    this.ArrChatStr.IntToFormat((long) (int) mapPosbySpriteId.x);
    this.ArrChatStr.StringToFormat(instance.mStringTable.GetStringByID(4506U));
    this.ArrChatStr.IntToFormat((long) (int) mapPosbySpriteId.y);
    if (GUIManager.Instance.IsArabic)
      this.ArrChatStr.AppendFormat("{0} {2}{1} {4}{3} {6}{5}");
    else
      this.ArrChatStr.AppendFormat("{0} {1}{2} {3}{4} {5}{6}");
  }

  private void UpdateMonsterIcon()
  {
    if (this.MonsterID == (ushort) 0)
      return;
    MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.MonsterID);
    this.HeroID = recordByKey.ModelID;
    CString Name = StringManager.Instance.StaticString1024();
    this.HeroHead = DataManager.Instance.HeroTable.GetRecordByKey(this.HeroID).Graph;
    Name.ClearString();
    Name.IntToFormat((long) this.HeroHead);
    Name.AppendFormat("UI/MapNPCHead_{0}");
    this.MonstIconTrans.GetChild(0).gameObject.SetActive(false);
    if (AssetManager.GetAssetBundleDownload(Name, AssetPath.UI, AssetType.NPCHead, this.HeroHead))
    {
      this.AB = AssetManager.GetAssetBundle(Name, out this.AssetKey);
      if ((Object) this.AB != (Object) null)
      {
        GameObject gameObject = Object.Instantiate(this.AB.mainAsset) as GameObject;
        gameObject.SetActive(true);
        Transform transform = gameObject.transform;
        transform.SetParent(this.MonstIconTrans);
        transform.SetAsFirstSibling();
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one;
        transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
      }
    }
    this.MonsterNameStr.ClearString();
    this.MonsterNameStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.NameID));
    this.MonsterNameText.text = this.MonsterNameStr.ToString();
    this.MonsterNameText.SetAllDirty();
    this.MonsterNameText.cachedTextGenerator.Invalidate();
  }

  public void UpdateSummonMonsterTimes()
  {
    ushort summonPoint = (ushort) ActivityManager.Instance.AllianceSummon_SummonData.SummonPoint;
    if (this.Style == UISummonMonster.BtnStyle.Summon)
    {
      if ((int) summonPoint >= (int) this.NeedPoint)
      {
        ((Graphic) this.SummonCostText).color = Color.white;
        this.NoticeObj.SetActive(true);
      }
      else
      {
        ((Graphic) this.SummonCostText).color = Color.red;
        this.NoticeObj.SetActive(false);
      }
      this.SummonCostStr.ClearString();
      this.SummonCostStr.IntToFormat((long) this.NeedPoint);
      this.SummonCostStr.AppendFormat("{0}");
      this.SummonCostText.text = this.SummonCostStr.ToString();
      this.SummonCostText.SetAllDirty();
      this.SummonCostText.cachedTextGenerator.Invalidate();
    }
    else
      this.NoticeObj.SetActive(true);
    this.SummonMonsterTimesStr.ClearString();
    this.SummonMonsterTimesStr.IntToFormat((long) summonPoint);
    this.SummonMonsterTimesStr.AppendFormat("{0}");
    this.SummonMonsterTimesText.text = this.SummonMonsterTimesStr.ToString();
    this.SummonMonsterTimesText.SetAllDirty();
    this.SummonMonsterTimesText.cachedTextGenerator.Invalidate();
  }

  public void InitPrice()
  {
    GUIManager.Instance.ChangeHeroItemImg(this.MonsterPriceTrans, eHeroOrItem.Item, this.PriceID, (byte) 0, (byte) 0);
    this.MonsterPriceBtn.m_BtnID2 = (int) this.PriceID;
  }

  public void UpdateSummonLeftTime()
  {
    if (this.Style != UISummonMonster.BtnStyle.Move)
      return;
    long serverTime = DataManager.Instance.ServerTime;
    if (this.SummonLeftTime >= serverTime)
    {
      this.LeftTimeStr.ClearString();
      this.LeftTimeStr.Append(DataManager.MissionDataManager.FormatMissionTime((uint) (this.SummonLeftTime - serverTime)));
      this.LeftTimeText.text = this.LeftTimeStr.ToString();
      this.LeftTimeText.SetAllDirty();
      this.LeftTimeText.cachedTextGenerator.Invalidate();
    }
    else
    {
      this.LeftTimeStr.ClearString();
      this.LeftTimeStr.Append("0:00");
      this.LeftTimeText.text = this.LeftTimeStr.ToString();
      this.LeftTimeText.SetAllDirty();
      this.LeftTimeText.cachedTextGenerator.Invalidate();
    }
  }

  private bool CheckAlliance()
  {
    if (DataManager.Instance.RoleAlliance.Id != 0U)
      return true;
    this.bCloseUI = (byte) 1;
    return false;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (this.Info != null)
      this.Info.UpdateNetwork(meg);
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        if (!this.CheckAlliance() || this.Style != UISummonMonster.BtnStyle.Summon || !((Object) this.MonsterEffect[1] != (Object) null))
          break;
        this.MonsterEffect[1].SetActive(false);
        break;
      case NetworkNews.Fallout:
        this.MonsterEffect[0].SetActive(false);
        int index = 3;
        if (!((Object) this.MonsterEffect[index] != (Object) null))
          break;
        this.MonsterEffect[index].SetActive(false);
        break;
      case NetworkNews.Refresh_Asset:
        if (this.Style == UISummonMonster.BtnStyle.Move && meg[1] == (byte) 1 && meg[2] == (byte) 2 && (int) GameConstants.ConvertBytesToUShort(meg, 3) == (int) this.Modle)
        {
          this.MonsterAct.ClearString();
          this.MonsterAct.Append(AnimationUnit.ANIM_STRING[0]);
          this.DestroyAB();
          this.UpdateMonster();
          if (this.DelayParm != UISummonMonster.eDelayParm.SummonSuccessWait)
            break;
          this.SetDelay(0.0f, UISummonMonster.eDelayParm.MonsterScaleIn);
          break;
        }
        if (this.Style != UISummonMonster.BtnStyle.Summon || meg[1] != (byte) 0 || meg[2] != (byte) 1 || (int) GameConstants.ConvertBytesToUShort(meg, 3) != (int) this.HeroHead)
          break;
        this.DestroyAB();
        this.UpdateMonsterIcon();
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Alliance)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          ((Behaviour) this.SummonMonsterTimesText).enabled = false;
          ((Behaviour) this.TitleText).enabled = false;
          ((Behaviour) this.MonsterNameText).enabled = false;
          ((Behaviour) this.SummonCostText).enabled = false;
          ((Behaviour) this.CaptionText).enabled = false;
          ((Behaviour) this.LeftTimeTitleText).enabled = false;
          ((Behaviour) this.LeftTimeText).enabled = false;
          ((Behaviour) this.SummonMonsterTimesText).enabled = true;
          ((Behaviour) this.TitleText).enabled = true;
          ((Behaviour) this.MonsterNameText).enabled = true;
          ((Behaviour) this.SummonCostText).enabled = true;
          ((Behaviour) this.CaptionText).enabled = true;
          ((Behaviour) this.LeftTimeTitleText).enabled = true;
          ((Behaviour) this.LeftTimeText).enabled = true;
          this.MonsterPositionText.TextRefresh();
          this.PriceTitleText.TextRefresh();
          break;
        }
        if (meg[1] >= (byte) 36 && meg[1] <= (byte) 39)
          this.UpdateStyle();
        if (meg[1] != (byte) 39)
          break;
        this.UpdateMonsterPosition();
        this.UpdateSummonLeftTime();
        if (this.DelayParm2 != UISummonMonster.eDelayParm.WaitSummonTime || this.SummonLeftTime <= 0L)
          break;
        this.DelayParm2 = UISummonMonster.eDelayParm.None;
        this.LeftTimeObj.SetActive(true);
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        if (this.Style != UISummonMonster.BtnStyle.Summon)
          break;
        if (this.MainObj.activeSelf)
        {
          if ((double) this.DelayTime > 0.0 && this.DelayParm == UISummonMonster.eDelayParm.SummonWait)
            this.SetDelay(this.DelayTime, UISummonMonster.eDelayParm.MonsterScaleInSound);
          else
            this.SetDelay(0.0f, UISummonMonster.eDelayParm.MonsterScaleInSound);
        }
        else
          this.SetDelay(0.0f, UISummonMonster.eDelayParm.WaitChangeMove);
        if (this.SummonLeftTime != 0L)
          break;
        this.LeftTimeObj.SetActive(false);
        this.DelayParm2 = UISummonMonster.eDelayParm.WaitSummonTime;
        break;
      case 1:
        this.UpdateStyle();
        break;
      case 2:
        this.UpdateStyle();
        this.MonsterEffect[0].SetActive(false);
        int index1 = 3;
        if (!((Object) this.MonsterEffect[index1] != (Object) null))
          break;
        this.MonsterEffect[index1].SetActive(false);
        break;
      case 3:
        this.CheckAlliance();
        break;
      default:
        if (arg1 >= 0)
          break;
        int index2 = 1;
        if (!((Object) this.MonsterEffect[index2] != (Object) null))
          break;
        this.MonsterEffect[index2].SetActive(false);
        break;
    }
  }

  private void SetDelay(float delayTime, UISummonMonster.eDelayParm Parm)
  {
    this.DelayTime = delayTime;
    this.DelayParm = Parm;
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (this.DelayParm == UISummonMonster.eDelayParm.SummonWait || this.DelayParm == UISummonMonster.eDelayParm.MonsterScaleIn || this.DelayParm == UISummonMonster.eDelayParm.MonsterScaleInSound)
          break;
        if (DataManager.Instance.RoleAlliance.Rank < AllianceRank.RANK4)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
          break;
        }
        if ((int) ActivityManager.Instance.AllianceSummon_SummonData.SummonPoint < (int) this.NeedPoint)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14511U), (ushort) byte.MaxValue);
          break;
        }
        GUIManager.Instance.ShowUILock(EUILock.Battle);
        AudioManager.Instance.PlayUISFX(UIKind.Summoning);
        this.SetDelay(0.2f, UISummonMonster.eDelayParm.SendSummon);
        break;
      case 1:
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).GoToMapID((ushort) sender.m_BtnID3, sender.m_BtnID2, (byte) 0, (byte) 1);
        break;
      case 2:
        Door menu1 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        this.transform.gameObject.SetActive(false);
        menu1.OpenMenu(EGUIWindow.UI_Chat, (int) GUIManager.Instance.ChannelIndex + 1);
        ((UIChat) GUIManager.Instance.FindMenu(EGUIWindow.UI_Chat)).SetInputText(this.ArrChatStr.ToString());
        break;
      case 3:
        if (this.Info == null)
        {
          GameObject go = Object.Instantiate(this.m_AssetBundle.Load("UIMonsterInfo")) as GameObject;
          this.Info = new _UISummonMonsterInfo(this, go);
          this.Info.OnOpen(0, 0);
          go.transform.SetParent(this.InfoObj.transform, false);
        }
        this.SetInfoVisible(true);
        break;
      case 4:
        this.SetInfoVisible(false);
        break;
      case 5:
        Door menu2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!((Object) menu2 != (Object) null))
          break;
        menu2.CloseMenu();
        break;
    }
  }

  private void SetInfoVisible(bool visible)
  {
    this.InfoObj.SetActive(visible);
    this.MainObj.SetActive(!visible);
    if (this.MainObj.activeSelf)
    {
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 1);
      this.CheckMonsterSkin();
    }
    else
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 3);
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, (int) sender.Parm1, 0, new Vector2((float) sender.Parm2, 0.0f));
  }

  public void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide(true);

  private enum UIControl
  {
    TotalTimes,
    Title,
    Name,
    Effect,
    Monster,
    MonsterIcon,
    Info,
    SummonMove,
    Notice,
    Price,
    Close,
  }

  public enum ClickType
  {
    Summon,
    Move,
    AddChat,
    Info,
    CloseInfo,
    Close,
  }

  private enum BtnStyle
  {
    Summon,
    Move,
  }

  private enum Effectenum
  {
    Icon,
    Summoning,
    SummonSuccess,
    Monster,
  }

  private enum eDelayParm
  {
    None,
    SummonWait,
    MonsterScaleIn,
    SummonSuccessWait,
    WaitChangeSummon,
    WaitChangeMove,
    WaitSummonTime,
    SendSummon,
    MonsterScaleInSound,
  }

  public struct _TextUnderLine
  {
    private RectTransform LineRect;
    private RectTransform ButtonRect;
    private float TextWidth;
    private UIText mText;
    public UIButton Button;

    public void Init(RectTransform TextRect, Transform buttonTrans, float TextWidth, Font font)
    {
      this.TextWidth = TextWidth;
      this.LineRect = ((Transform) TextRect).GetChild(0).GetComponent<RectTransform>();
      this.mText = ((Component) TextRect).GetComponent<UIText>();
      this.mText.font = font;
      this.ButtonRect = buttonTrans.GetComponent<RectTransform>();
      this.Button = ((Component) this.ButtonRect).GetComponent<UIButton>();
      this.Button.SoundIndex = byte.MaxValue;
    }

    public void SetText(string str)
    {
      this.mText.text = str;
      this.mText.SetAllDirty();
      this.mText.cachedTextGenerator.Invalidate();
      this.mText.cachedTextGeneratorForLayout.Invalidate();
      this.LineRect.sizeDelta = new Vector2(this.mText.preferredWidth, this.LineRect.sizeDelta.y);
      this.LineRect.anchoredPosition = new Vector2(this.TextWidth - this.LineRect.sizeDelta.x, this.LineRect.anchoredPosition.y);
      this.ButtonRect.sizeDelta = new Vector2(this.LineRect.sizeDelta.x, this.ButtonRect.sizeDelta.y);
      this.ButtonRect.anchoredPosition = new Vector2(this.LineRect.anchoredPosition.x, this.ButtonRect.anchoredPosition.y);
      if (!GUIManager.Instance.IsArabic)
        return;
      this.LineRect.anchoredPosition = new Vector2(((Graphic) this.mText).rectTransform.offsetMin.x, this.LineRect.anchoredPosition.y);
    }

    public void TextRefresh()
    {
      ((Behaviour) this.mText).enabled = false;
      ((Behaviour) this.mText).enabled = true;
    }
  }
}
