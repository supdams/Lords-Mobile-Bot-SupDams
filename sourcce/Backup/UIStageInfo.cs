// Decompiled with JetBrains decompiler
// Type: UIStageInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIStageInfo : 
  GUIWindow,
  UILoadImageHander,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private Transform m_transform;
  public Transform Play10T;
  public Transform Play1T;
  public Transform Play10TextT;
  public Transform Play1TextT;
  public Transform TicketImgT;
  public Transform TicketNumT;
  public Transform TicketImgT2;
  public Transform ScrollT;
  private Transform[] RewardBtnT = new Transform[7];
  private Transform[] EnemyBtnT = new Transform[5];
  private Transform BossImg1;
  private Transform BossImg2;
  private Transform[] StarT = new Transform[3];
  private UIText TicketNum;
  private UIText StageName;
  private UIText StageName2;
  private UIText Power;
  private UIText Times;
  private UIText Story;
  private UIText Rewards;
  private UIText Enemy;
  private UIText NPCName;
  private UIText Play10Text;
  private UIText Play1Text;
  private GameObject NormalObj;
  private GameObject EliteObj1;
  private GameObject EliteObj2;
  private GameObject DareObj1;
  private GameObject DareObj2;
  private CString tmpString;
  private CString tmpString2;
  private CString StageNameStr;
  private CString tmpString3;
  private int AssetKey;
  private byte RewardOrEnemy;
  private byte EnemyCount;
  private byte RewardCount;
  private Vector2 tmpVec2 = Vector2.zero;
  private Vector3 tmpVec3 = Vector3.zero;
  private bool bHaveTargetItem;
  private UISpritesArray SArray1;
  private UISpritesArray SArray2;
  private float IconSize = 80f;
  private float IconDelta = 87f;
  private int NeedMorale;
  private int StageTimes;
  private int MaxStageTimes;
  private int CanFightStageTimes;
  private GameObject BossGO;
  private AssetBundle AB;
  private AssetBundleRequest AR;
  private bool bABInitial;
  private Vector3 ActorPos;
  private Hero sHero;
  private Animation tmpAN;
  private string HeroAct;
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
  private List<AnimationUnit.AnimName> ANList = new List<AnimationUnit.AnimName>();
  private ushort MoraleItemID = 1115;
  private UIHIBtn[] RBRewardBtn = new UIHIBtn[7];
  private DataManager DM;
  private StageManager DS;
  private GUIManager GM;
  private StringManager SM;
  private ushort ConditionKey;
  private UIButton[] NodusBtn = new UIButton[3];
  private GameObject[] NodusBtnLight = new GameObject[3];
  private GameObject[] NodusBtnLock = new GameObject[3];
  private UIButton[] ConditionBtn = new UIButton[8];
  private GameObject[] ConditionGO = new GameObject[8];
  private Text NodusTitle;
  private Text NodusTitle2;
  private CString HinString;

  public override void OnOpen(int arg1, int arg2)
  {
    // ISSUE: unable to decompile the method.
  }

  public override void OnClose()
  {
    if (this.tmpString != null)
    {
      this.SM.DeSpawnString(this.tmpString);
      this.tmpString = (CString) null;
    }
    if (this.tmpString2 != null)
    {
      this.SM.DeSpawnString(this.tmpString2);
      this.tmpString2 = (CString) null;
    }
    if (this.tmpString3 != null)
    {
      this.SM.DeSpawnString(this.tmpString3);
      this.tmpString3 = (CString) null;
    }
    if (this.StageNameStr != null)
    {
      this.SM.DeSpawnString(this.StageNameStr);
      this.StageNameStr = (CString) null;
    }
    if (this.HinString != null)
    {
      this.SM.DeSpawnString(this.HinString);
      this.HinString = (CString) null;
    }
    if ((Object) this.BossGO != (Object) null)
    {
      ModelLoader.Instance.Unload((Object) this.BossGO);
      this.BossGO = (GameObject) null;
    }
    if (this.AssetKey == 0)
      return;
    AssetManager.UnloadAssetBundle(this.AssetKey);
  }

  public override bool OnBackButtonClick()
  {
    this.DS.ReBackCurrentChapter();
    return false;
  }

  private void Update()
  {
    if (!this.bABInitial && this.AR != null && this.AR.isDone)
    {
      this.bABInitial = true;
      this.BossGO = ModelLoader.Instance.Load(this.sHero.Modle, this.AB, (ushort) this.sHero.TextureNo);
      this.BossGO.transform.SetParent(this.m_transform, false);
      this.BossGO.transform.localPosition = this.ActorPos;
      if (this.sHero.Camera_Horizontal == (ushort) 0)
        this.BossGO.transform.localRotation = new Quaternion(0.0f, -180f, 0.0f, 0.0f);
      else
        this.BossGO.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
        {
          eulerAngles = new Vector3(0.0f, (float) this.sHero.Camera_Horizontal, 0.0f)
        };
      this.BossGO.transform.localScale = new Vector3((float) this.sHero.CameraScaleRate, (float) this.sHero.CameraScaleRate, (float) this.sHero.CameraScaleRate);
      this.GM.SetLayer(this.BossGO, 5);
      if ((Object) this.BossGO != (Object) null)
      {
        this.tmpAN = this.BossGO.GetComponent<Animation>();
        this.tmpAN.wrapMode = WrapMode.Loop;
        this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
        for (int index1 = 0; index1 < this.ANIndex.Length; ++index1)
        {
          byte index2 = (byte) this.ANIndex[index1];
          if ((Object) this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[(int) index2]) != (Object) null)
          {
            this.tmpAN[AnimationUnit.ANIM_STRING[(int) index2]].layer = 1;
            this.tmpAN[AnimationUnit.ANIM_STRING[(int) index2]].wrapMode = WrapMode.Once;
            this.ANList.Add(this.ANIndex[index1]);
          }
        }
        this.tmpAN.clip = this.tmpAN.GetClip("idle");
        this.tmpAN.Play("idle");
        SkinnedMeshRenderer componentInChildren = this.BossGO.GetComponentInChildren<SkinnedMeshRenderer>();
        if ((Object) componentInChildren != (Object) null)
        {
          componentInChildren.useLightProbes = false;
          componentInChildren.updateWhenOffscreen = true;
        }
      }
    }
    if (!this.bABInitial || !((Object) this.BossGO != (Object) null))
      return;
    if ((!this.tmpAN.IsPlaying(this.HeroAct) || this.HeroAct == "idle") && (double) this.ActionTimeRandom < 0.0001)
    {
      this.ActionTimeRandom = (float) Random.Range(3, 7);
      this.ActionTime = 0.0f;
    }
    if ((double) this.ActionTimeRandom <= 0.0001)
      return;
    this.ActionTime += Time.smoothDeltaTime;
    if ((double) this.ActionTime < (double) this.ActionTimeRandom)
      return;
    this.HeroActionChang();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
label_3:
        this.OpenRefresh();
        this.SetNodusBtnState();
        break;
      case NetworkNews.Refresh_Asset:
        if (meg[1] != (byte) 1 || meg[2] != (byte) 2 || (int) GameConstants.ConvertBytesToUShort(meg, 3) != (int) this.sHero.Modle)
          break;
        this.LoadAB(true);
        break;
      default:
        switch (networkNews - (byte) 32)
        {
          case NetworkNews.Login:
          case NetworkNews.Fallout:
            goto label_3;
          case NetworkNews.Refresh:
            return;
          case NetworkNews.Refresh_Asset:
            if ((Object) this.TicketNum != (Object) null && ((Behaviour) this.TicketNum).enabled)
            {
              ((Behaviour) this.TicketNum).enabled = false;
              ((Behaviour) this.TicketNum).enabled = true;
            }
            if ((Object) this.StageName != (Object) null && ((Behaviour) this.StageName).enabled)
            {
              ((Behaviour) this.StageName).enabled = false;
              ((Behaviour) this.StageName).enabled = true;
            }
            if ((Object) this.StageName2 != (Object) null && ((Behaviour) this.StageName2).enabled)
            {
              ((Behaviour) this.StageName2).enabled = false;
              ((Behaviour) this.StageName2).enabled = true;
            }
            if ((Object) this.Power != (Object) null && ((Behaviour) this.Power).enabled)
            {
              ((Behaviour) this.Power).enabled = false;
              ((Behaviour) this.Power).enabled = true;
            }
            if ((Object) this.Times != (Object) null && ((Behaviour) this.Times).enabled)
            {
              ((Behaviour) this.Times).enabled = false;
              ((Behaviour) this.Times).enabled = true;
            }
            if ((Object) this.Story != (Object) null && ((Behaviour) this.Story).enabled)
            {
              ((Behaviour) this.Story).enabled = false;
              ((Behaviour) this.Story).enabled = true;
            }
            if ((Object) this.Rewards != (Object) null && ((Behaviour) this.Rewards).enabled)
            {
              ((Behaviour) this.Rewards).enabled = false;
              ((Behaviour) this.Rewards).enabled = true;
            }
            if ((Object) this.Enemy != (Object) null && ((Behaviour) this.Enemy).enabled)
            {
              ((Behaviour) this.Enemy).enabled = false;
              ((Behaviour) this.Enemy).enabled = true;
            }
            if ((Object) this.NPCName != (Object) null && ((Behaviour) this.NPCName).enabled)
            {
              ((Behaviour) this.NPCName).enabled = false;
              ((Behaviour) this.NPCName).enabled = true;
            }
            if ((Object) this.Play10Text != (Object) null && ((Behaviour) this.Play10Text).enabled)
            {
              ((Behaviour) this.Play10Text).enabled = false;
              ((Behaviour) this.Play10Text).enabled = true;
            }
            if ((Object) this.Play1Text != (Object) null && ((Behaviour) this.Play1Text).enabled)
            {
              ((Behaviour) this.Play1Text).enabled = false;
              ((Behaviour) this.Play1Text).enabled = true;
            }
            if (this.RBRewardBtn != null)
            {
              for (int index = 0; index < this.RBRewardBtn.Length; ++index)
              {
                if ((Object) this.RBRewardBtn[index] != (Object) null)
                  this.RBRewardBtn[index].Refresh_FontTexture();
              }
            }
            if ((Object) this.NodusTitle != (Object) null && ((Behaviour) this.NodusTitle).enabled)
            {
              ((Behaviour) this.NodusTitle).enabled = false;
              ((Behaviour) this.NodusTitle).enabled = true;
            }
            if (!((Object) this.NodusTitle2 != (Object) null) || !((Behaviour) this.NodusTitle2).enabled)
              return;
            ((Behaviour) this.NodusTitle2).enabled = false;
            ((Behaviour) this.NodusTitle2).enabled = true;
            return;
          default:
            return;
        }
    }
  }

  public void HeroActionChang()
  {
    if ((Object) this.BossGO == (Object) null)
      return;
    int index = Random.Range(0, this.ANList.Count);
    byte an = (byte) this.ANList[index];
    AnimationClip animationClip = this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[(int) an]);
    this.HeroAct = AnimationUnit.ANIM_STRING[(int) an];
    if (this.ANList[index] == AnimationUnit.AnimName.SKILL1 && (Object) this.tmpAN.GetClip(this.HeroAct + "_ch") != (Object) null)
      animationClip = (AnimationClip) null;
    if ((Object) animationClip != (Object) null)
      this.tmpAN.CrossFade(animationClip.name);
    this.ActionTimeRandom = 0.0f;
    this.ActionTime = 0.0f;
  }

  private void SetRewardOrEnemy()
  {
    if (this.RewardOrEnemy == (byte) 0)
    {
      this.RewardOrEnemy = (byte) 1;
      ((Component) this.Rewards).gameObject.SetActive(false);
      ((Component) this.Enemy).gameObject.SetActive(true);
      this.BossImg2.gameObject.SetActive(true);
      this.SArray1.SetSpriteIndex(0);
      this.SArray2.SetSpriteIndex(0);
      for (int index = 0; index < 7; ++index)
      {
        if ((Object) this.RewardBtnT[index] != (Object) null)
          this.RewardBtnT[index].gameObject.SetActive(false);
      }
      if ((Object) this.ScrollT != (Object) null)
        this.ScrollT.gameObject.SetActive(false);
      for (int index = 0; index < (int) this.EnemyCount; ++index)
        this.EnemyBtnT[index].gameObject.SetActive(true);
    }
    else
    {
      if (this.RewardOrEnemy != (byte) 1)
        return;
      this.RewardOrEnemy = (byte) 0;
      ((Component) this.Rewards).gameObject.SetActive(true);
      ((Component) this.Enemy).gameObject.SetActive(false);
      this.BossImg2.gameObject.SetActive(false);
      this.SArray1.SetSpriteIndex(1);
      this.SArray2.SetSpriteIndex(1);
      for (int index = 0; index < (int) this.EnemyCount; ++index)
        this.EnemyBtnT[index].gameObject.SetActive(false);
      int num = 0;
      int rewardCount = (int) this.RewardCount;
      if (this.bHaveTargetItem)
      {
        this.RewardBtnT[0].gameObject.SetActive(true);
        num = 1;
        ++rewardCount;
      }
      if ((Object) this.ScrollT != (Object) null)
        this.ScrollT.gameObject.SetActive(true);
      for (int index = num; index < rewardCount; ++index)
      {
        if ((Object) this.RewardBtnT[index] != (Object) null)
          this.RewardBtnT[index].gameObject.SetActive(true);
      }
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    if (sender.m_BtnID1 == 2 || sender.m_BtnID1 != 3)
      ;
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      bool flag = this.DS._stageMode == StageMode.Lean;
      if (flag && this.MaxStageTimes != (int) byte.MaxValue && this.StageTimes >= this.MaxStageTimes)
      {
        this.GM.MsgStr.Length = 0;
        this.GM.MsgStr.IntToFormat((long) this.MaxStageTimes);
        this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(811U));
        this.GM.OpenOKCancelBox(8, this.DM.mStringTable.GetStringByID(5811U), this.GM.MsgStr.ToString(), YesText: this.DM.mStringTable.GetStringByID(4507U), NoText: this.DM.mStringTable.GetStringByID(617U));
      }
      else if (sender.m_BtnID2 == 1)
      {
        if (this.DS._stageMode == StageMode.Dare || (int) this.DM.RoleAttr.Morale >= this.NeedMorale)
        {
          Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
          if (!((Object) menu != (Object) null))
            return;
          AssetManager.UnloadAssetBundle(this.AssetKey);
          this.AssetKey = 0;
          if (this.GM.bBackInPreviewModel)
          {
            this.GM.bBackInPreviewModel = !this.GM.bBackInPreviewModel;
            this.GM.BackInPreviewHight = 0.0f;
          }
          menu.OpenMenu(EGUIWindow.UI_BattleHeroSelect, bCameraMode: true);
        }
        else
          this.GM.UseOrSpend(this.MoraleItemID, this.DM.mStringTable.GetStringByID(1505U), (ushort) 0, (ushort) 0, (ushort) 0, maxcount: (ushort) 0);
      }
      else if (sender.m_BtnID2 == 2)
      {
        if ((int) this.DM.RoleAttr.Morale >= this.NeedMorale)
        {
          this.GM.SendQuickBattle(GUIManager.EQuickFightKind.EQFK_Normal, !flag ? GUIManager.EStageKind.ESK_Normal : GUIManager.EStageKind.ESK_Advance, this.DS.currentPointID);
          this.DM.QBMorale = (ushort) this.NeedMorale;
        }
        else
          this.GM.UseOrSpend(this.MoraleItemID, this.DM.mStringTable.GetStringByID(1505U), (ushort) 0, (ushort) 0, (ushort) 0, maxcount: (ushort) 0);
      }
      else
      {
        if (sender.m_BtnID2 != 3)
          return;
        if ((int) this.DM.RoleAttr.Morale >= this.NeedMorale)
        {
          this.GM.SendQuickBattle(GUIManager.EQuickFightKind.EQFK_VIP, !flag ? GUIManager.EStageKind.ESK_Normal : GUIManager.EStageKind.ESK_Advance, this.DS.currentPointID);
          this.DM.QBMorale = (ushort) this.NeedMorale;
        }
        else
          this.GM.UseOrSpend(this.MoraleItemID, this.DM.mStringTable.GetStringByID(1505U), (ushort) 0, (ushort) 0, (ushort) 0, maxcount: (ushort) 0);
      }
    }
    else if (sender.m_BtnID1 == 4)
    {
      if (sender.m_BtnID2 == 1)
        this.SetRewardOrEnemy();
      else if (sender.m_BtnID2 != 2)
        ;
    }
    else if (sender.m_BtnID1 == 5)
    {
      this.DS.ReBackCurrentChapter();
      AssetManager.UnloadAssetBundle(this.AssetKey);
      this.AssetKey = 0;
      (this.GM.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
    }
    else
    {
      if (sender.m_BtnID1 != 11)
        return;
      this.SetNodus(sender.m_BtnID2);
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    if (!((Object) button != (Object) null))
      return;
    this.DS.GetStageConditionString(this.HinString, (byte) button.m_BtnID2, (ushort) button.m_BtnID3, (ushort) button.m_BtnID4, this.ConditionKey);
    this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 280f, 20, this.HinString, Vector2.zero);
  }

  public void OnButtonUp(UIButtonHint sender) => this.GM.m_Hint.Hide();

  public void OpenRefresh()
  {
    if (this.DS._stageMode == StageMode.Dare)
      return;
    Chapter recordByKey = this.DS.ChapterTable.GetRecordByKey((ushort) this.DS.currentChapterID);
    if (this.DS._stageMode == StageMode.Lean)
    {
      this.MaxStageTimes = (int) this.DM.VIPLevelTable.GetRecordByKey((ushort) this.DM.RoleAttr.VIPLevel).DailyResetElite;
      this.StageTimes = (int) this.DS.StageInfo[1][(int) this.DS.currentPointID - 1] >> 2 & 63;
      this.tmpString.Length = 0;
      if (this.MaxStageTimes == (int) byte.MaxValue)
      {
        this.tmpString.Append(this.DM.mStringTable.GetStringByID(5810U));
      }
      else
      {
        this.CanFightStageTimes = this.MaxStageTimes - this.StageTimes;
        if (this.CanFightStageTimes <= 0)
        {
          this.CanFightStageTimes = 0;
          this.tmpString.StringToFormat("<color=#ff0000>0</color>");
        }
        else
          this.tmpString.IntToFormat((long) this.CanFightStageTimes);
        this.tmpString.IntToFormat((long) this.MaxStageTimes);
        this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(47U));
      }
      this.Times.text = this.tmpString.ToString();
      this.Times.SetAllDirty();
      this.Times.cachedTextGenerator.Invalidate();
    }
    this.NeedMorale = (int) recordByKey.Power * (this.DS._stageMode != StageMode.Lean ? 1 : 2);
    int num = (int) this.DM.RoleAttr.Morale / this.NeedMorale;
    if (this.DS._stageMode == StageMode.Lean)
    {
      if (this.MaxStageTimes == (int) byte.MaxValue)
      {
        if (num > 10)
          num = 10;
      }
      else if (num > this.CanFightStageTimes)
        num = this.CanFightStageTimes;
    }
    StringManager.IntToStr(this.tmpString3, num <= 10 ? (long) num : 10L);
    this.Play10Text.text = this.tmpString3.ToString();
    this.Play10Text.SetAllDirty();
    this.Play10Text.cachedTextGenerator.Invalidate();
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (Object) menu)
      return;
    img.sprite = menu.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = menu.LoadMaterial();
  }

  public override void ReOnOpen()
  {
  }

  public void SetNodus(int Nodus)
  {
    int index1 = 0;
    LevelEX bycurrentPointId = this.DS.GetLevelEXBycurrentPointID((ushort) 0);
    if (this.DS.StageDareMode(this.DS.currentPointID) == StageMode.Lean)
    {
      int stagePoint = this.DS.GetStagePoint((ushort) 0, (byte) 0);
      if (Nodus == -1)
      {
        if ((int) this.GM.UIPointID == (int) this.DS.currentPointID && this.GM.UINodus != (byte) 0)
        {
          Nodus = (int) this.DS.currentNodus;
          if (Nodus > this.DS.GetStagePoint((ushort) 0, (byte) 0) + 1)
            Nodus = stagePoint + 1;
        }
        else
          Nodus = stagePoint + 1;
      }
      if (Nodus > 3)
        Nodus = 3;
      if (Nodus > this.DS.GetStagePoint((ushort) 0, (byte) 0) + 1)
      {
        this.GM.MsgStr.Length = 0;
        this.GM.MsgStr.IntToFormat((long) (this.DS.GetStagePoint((ushort) 0, (byte) 0) + 1));
        this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(1034U));
        this.GM.AddHUDMessage(this.GM.MsgStr.ToString(), (ushort) byte.MaxValue);
        return;
      }
      this.DS.currentNodus = (byte) Nodus;
      this.GM.UIPointID = this.DS.currentPointID;
      this.GM.UINodus = (byte) Nodus;
      switch (Nodus)
      {
        case 1:
          this.ConditionKey = bycurrentPointId.NodusOneID;
          break;
        case 2:
          this.ConditionKey = bycurrentPointId.NodusTwoID;
          break;
        case 3:
          this.ConditionKey = bycurrentPointId.NodusThrID;
          break;
      }
      this.SetNodusBtnState();
    }
    else
    {
      this.ConditionKey = bycurrentPointId.NodusTwoID;
      this.DS.currentNodus = (byte) 0;
    }
    StageConditionData recordByKey = this.DS.StageConditionDataTable.GetRecordByKey(this.ConditionKey);
    for (int index2 = 0; index2 < 7; ++index2)
    {
      if (recordByKey.ConditionArray[index2].ConditionID > (byte) 0)
      {
        this.ConditionBtn[index2].image.sprite = this.DS.GetStageConditionSprite(recordByKey.ConditionArray[index2].ConditionID, recordByKey.ConditionArray[index2].FactorA, recordByKey.ConditionArray[index2].FactorB);
        ((MaskableGraphic) this.ConditionBtn[index2].image).material = this.DS.GetStageConditionMaterial(recordByKey.ConditionArray[index2].ConditionID);
        this.ConditionBtn[index2].m_BtnID2 = (int) recordByKey.ConditionArray[index2].ConditionID;
        this.ConditionBtn[index2].m_BtnID3 = (int) recordByKey.ConditionArray[index2].FactorA;
        this.ConditionBtn[index2].m_BtnID4 = (int) recordByKey.ConditionArray[index2].FactorB;
        ((Component) this.ConditionBtn[index2]).gameObject.SetActive(true);
        this.ConditionGO[index2].gameObject.SetActive(true);
        ++index1;
      }
      else
        this.ConditionGO[index2].gameObject.SetActive(false);
    }
    if (index1 >= 8)
      return;
    this.ConditionBtn[index1].image.sprite = this.DS.GetStageConditionSprite(byte.MaxValue, (ushort) 0, (ushort) 0);
    ((MaskableGraphic) this.ConditionBtn[index1].image).material = this.DS.GetStageConditionMaterial(byte.MaxValue);
    this.ConditionBtn[index1].m_BtnID2 = (int) byte.MaxValue;
    ((Component) this.ConditionBtn[index1]).gameObject.SetActive(true);
    this.ConditionGO[index1].gameObject.SetActive(true);
  }

  private void SetNodusBtnState()
  {
    if (!((Object) this.NodusBtn[0] != (Object) null))
      return;
    int stagePoint = this.DS.GetStagePoint((ushort) 0, (byte) 0);
    for (int index = 0; index < this.NodusBtn.Length; ++index)
    {
      if (index + 1 == (int) this.DS.currentNodus)
        this.NodusBtnLight[index].SetActive(true);
      else
        this.NodusBtnLight[index].SetActive(false);
      if (index > stagePoint)
        this.NodusBtnLock[index].SetActive(true);
      else
        this.NodusBtnLock[index].SetActive(false);
    }
  }

  public void LoadAB(bool ReLoad = false)
  {
    if (ReLoad && (Object) this.AB != (Object) null)
    {
      if (this.AssetKey != 0)
        AssetManager.UnloadAssetBundle(this.AssetKey);
      if ((Object) this.BossGO != (Object) null)
        ModelLoader.Instance.Unload((Object) this.BossGO);
      this.AssetKey = 0;
      this.BossGO = (GameObject) null;
      this.AB = (AssetBundle) null;
      this.bABInitial = false;
    }
    CString Name = this.SM.StaticString1024();
    Name.IntToFormat((long) this.sHero.Modle, 5);
    Name.AppendFormat("Role/hero_{0}");
    this.AB = AssetManager.GetAssetBundle(Name, out this.AssetKey);
    if (!((Object) this.AB != (Object) null))
      return;
    this.AR = this.AB.LoadAsync("m", typeof (GameObject));
    this.bABInitial = false;
  }
}
