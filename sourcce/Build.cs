// Decompiled with JetBrains decompiler
// Type: Build
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class Build : SpriteBase, IMotionUpdate
{
  private EasingEffect OpenUIMotion;
  private GameObject RootObj;
  private GameObject EffectBuilding;
  public SpriteRenderer spriteRender;
  public SpriteRenderer markspriteRender;
  public SpriteRenderer LevelRender;
  public SpriteRenderer PromptRender;
  public SpriteRenderer UpgradeRender;
  private float UpdateTime;
  private byte CheckUpdateRes;

  public Build() => this.RootObj = new GameObject("MapSprite");

  public override GameObject InitialSprite(MapSpriteManager mapspriteManager)
  {
    this.mapspriteManager = mapspriteManager;
    this.RootObj.transform.position = Vector3.zero;
    this.spriteRender = mapspriteManager.GetSpriteObj().GetComponent<SpriteRenderer>();
    this.markspriteRender = mapspriteManager.GetSpriteObj().GetComponent<SpriteRenderer>();
    this.LevelRender = mapspriteManager.GetSpriteObj().GetComponent<SpriteRenderer>();
    this.PromptRender = mapspriteManager.GetSpriteObj().GetComponent<SpriteRenderer>();
    this.UpgradeRender = mapspriteManager.GetSpriteObj().GetComponent<SpriteRenderer>();
    this.spriteRender.transform.SetParent(this.RootObj.transform);
    this.markspriteRender.transform.SetParent(this.spriteRender.transform);
    this.markspriteRender.renderer.sortingOrder = -32;
    this.LevelRender.transform.SetParent(this.RootObj.transform);
    this.LevelRender.renderer.sortingOrder = -32;
    this.PromptRender.transform.SetParent(this.spriteRender.transform);
    this.PromptRender.renderer.sortingOrder = -31;
    this.PromptRender.enabled = false;
    this.UpgradeRender.transform.SetParent(this.LevelRender.transform);
    this.UpgradeRender.renderer.sortingOrder = -32;
    this.UpgradeRender.enabled = false;
    this.spriteRender.gameObject.SetActive(true);
    this.markspriteRender.gameObject.SetActive(true);
    this.markspriteRender.sprite = mapspriteManager.GetSpriteByName("build_99");
    this.markspriteRender.transform.localPosition = Vector3.zero;
    this.markspriteRender.enabled = false;
    this.UpgradeRender.sprite = mapspriteManager.GetSpriteByName("upgrade");
    this.UpgradeRender.transform.localPosition = new Vector3(0.6f, 0.27f, 0.0f);
    this.spriteRender.transform.localRotation = this.spriteRender.transform.localRotation with
    {
      eulerAngles = Vector3.zero
    };
    this.OpenUIMotion = new EasingEffect();
    this.OpenUIMotion.Motion = (IMotionUpdate) this;
    this.SetSprite(this.Index, (byte) 0);
    return this.spriteRender.gameObject;
  }

  public override void Destroy()
  {
    if ((bool) (Object) this.RootObj)
    {
      if ((Object) this.spriteRender != (Object) null)
        this.mapspriteManager.ReleaseSpriteObj(this.spriteRender.gameObject);
      if ((Object) this.markspriteRender != (Object) null)
        this.mapspriteManager.ReleaseSpriteObj(this.markspriteRender.gameObject);
      if ((Object) this.UpgradeRender != (Object) null)
        this.mapspriteManager.ReleaseSpriteObj(this.UpgradeRender.gameObject);
      if ((Object) this.LevelRender != (Object) null)
        this.mapspriteManager.ReleaseSpriteObj(this.LevelRender.gameObject);
      if ((Object) this.PromptRender != (Object) null)
        this.mapspriteManager.ReleaseSpriteObj(this.PromptRender.gameObject);
      Object.Destroy((Object) this.RootObj);
    }
    if (!(bool) (Object) this.EffectBuilding)
      return;
    ParticleManager.Instance.DeSpawn(this.EffectBuilding);
    this.EffectBuilding = (GameObject) null;
  }

  public override void SetSprite(ushort ID, byte Class)
  {
    BuildsData buildingData = GUIManager.Instance.BuildingData;
    if (ID >= (ushort) 100)
    {
      buildingData.GetBuildSprite(ID, this.spriteRender, this.LevelRender);
      this.HashID = this.spriteRender.name.GetHashCode();
      switch ((byte) ID)
      {
        case 100:
          buildingData.ManorGride[2] = this.spriteRender.transform;
          break;
        case 101:
          buildingData.ManorGride[3] = this.spriteRender.transform;
          break;
        case 102:
          buildingData.ManorGride[4] = this.spriteRender.transform;
          break;
        case 104:
          buildingData.ManorGride[5] = this.spriteRender.transform;
          break;
        case 105:
          buildingData.ManorGride[8] = this.spriteRender.transform;
          break;
        case 106:
          buildingData.ManorGride[7] = this.spriteRender.transform;
          break;
      }
      this.Update((byte) 5);
    }
    else
    {
      buildingData.GetBuildSprite(ID, this.spriteRender, this.LevelRender);
      if (buildingData.AllBuildsData[(int) ID].BuildID == (ushort) 12)
        this.UpgradeRender.transform.localPosition = this.UpgradeRender.transform.localPosition with
        {
          z = -0.26f
        };
      if (buildingData.AllBuildsData[(int) ID].BuildID != (ushort) 8)
        this.markspriteRender.transform.localScale = Vector3.one * 0.5f;
      else
        this.LevelRender.transform.localPosition = this.LevelRender.transform.localPosition with
        {
          y = 9.24f
        };
      if (buildingData.AllBuildsData[(int) ID].BuildID == (ushort) 11)
      {
        buildingData.ManorGride[6] = this.spriteRender.transform;
        buildingData.GuideParm = ID;
      }
      else
      {
        switch (ID)
        {
          case 1:
            buildingData.ManorGride[0] = this.spriteRender.transform;
            break;
          case 5:
            buildingData.ManorGride[1] = this.spriteRender.transform;
            break;
          default:
            if (buildingData.AllBuildsData[(int) ID].BuildID == (ushort) 20)
            {
              buildingData.ManorGride[9] = this.spriteRender.transform;
              break;
            }
            break;
        }
      }
      this.HashID = this.spriteRender.name.GetHashCode();
      if ((Object) this.spriteRender.sprite == (Object) null)
        this.spriteRender.gameObject.SetActive(false);
      else
        this.spriteRender.gameObject.SetActive(true);
      this.Update((byte) 5);
      this.Update((byte) 8);
      this.Update((byte) 9);
    }
  }

  private void SetHeroEntrence()
  {
    GUIManager.Instance.BuildingData.GetBuildSprite((ushort) 13, this.spriteRender, this.LevelRender);
    this.spriteRender.transform.localPosition = new Vector3(-5.17f, 5.7f, 62f);
  }

  public override void Update(byte meg)
  {
    DataManager instance = DataManager.Instance;
    BuildsData buildingData = GUIManager.Instance.BuildingData;
    switch (meg)
    {
      case 0:
        this.PromptRender.enabled = false;
        this.LevelRender.enabled = false;
        this.UpgradeRender.gameObject.SetActive(false);
        return;
      case 1:
        this.UpdateTime = 0.0f;
        int num1 = (int) MotionEffect.SetStack((MotionEffect) this.OpenUIMotion);
        GUIManager.Instance.ShowUILock(EUILock.Normal);
        break;
      case 2:
        if ((Object) this.EffectBuilding == (Object) null)
        {
          Vector3 localPosition = this.spriteRender.transform.localPosition;
          if (buildingData.AllBuildsData[(int) this.Index].BuildID == (ushort) 8)
          {
            localPosition.y = 20.5f;
            this.EffectBuilding = ParticleManager.Instance.Spawn((ushort) 345, (Transform) null, localPosition, 0.8f, true, false);
          }
          else
          {
            localPosition.y += 8.9f;
            this.EffectBuilding = ParticleManager.Instance.Spawn((ushort) 293, (Transform) null, localPosition, 0.8f, true, false);
          }
          this.EffectBuilding.transform.localRotation = this.EffectBuilding.transform.localRotation with
          {
            eulerAngles = new Vector3(0.0f, 180f, 0.0f)
          };
        }
        this.markspriteRender.enabled = false;
        buildingData.GetBuildSprite(this.Index, this.spriteRender, this.LevelRender);
        this.Update((byte) 5);
        this.markspriteRender.enabled = true;
        buildingData.GetBuildSprite(this.Index, this.spriteRender, this.LevelRender);
        break;
      case 3:
      case 4:
        if ((Object) this.EffectBuilding != (Object) null)
        {
          ParticleManager.Instance.DeSpawn(this.EffectBuilding);
          this.EffectBuilding = (GameObject) null;
        }
        this.markspriteRender.enabled = false;
        buildingData.GetBuildSprite(this.Index, this.spriteRender, this.LevelRender);
        if (buildingData.AllBuildsData[(int) this.Index].BuildID == (ushort) 11)
        {
          buildingData.ManorGride[6] = this.spriteRender.transform;
          buildingData.GuideParm = this.Index;
          NewbieManager.CheckTroopMemory();
        }
        this.Update((byte) 5);
        this.Update((byte) 9);
        if (!this.UpgradeRender.gameObject.activeSelf)
        {
          this.UpgradeRender.gameObject.gameObject.SetActive(true);
          break;
        }
        break;
      case 5:
        this.PromptRender.transform.localScale = Vector3.one;
        this.PromptRender.sprite = (Sprite) null;
        Vector3 position = new Vector3(0.0f, this.spriteRender.renderer.bounds.size.y * (9f / 128f), 0.0f);
        if (buildingData.AllBuildsData.Length > (int) this.Index)
        {
          if (!instance.MySysSetting.bShowTrainingIdle)
          {
            ushort buildId = buildingData.AllBuildsData[(int) this.Index].BuildID;
            switch (buildId)
            {
              case 12:
                this.PromptRender.transform.localScale *= 0.8f;
                if (instance.TrapHospitalTotal > 0U)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_01");
                  break;
                }
                break;
              case 14:
                if (instance.TotalSoldier_Embassy > 0U)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_11");
                  break;
                }
                break;
              case 16:
                if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 17)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_07");
                  break;
                }
                if (instance.m_CryptData.money > (ushort) 0 && instance.m_CryptData.startTime + (long) GameConstants.CryptSecends[(int) instance.m_CryptData.kind] - instance.ServerTime <= 0L)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_06");
                  break;
                }
                break;
              case 18:
                if (instance.PrisonerNum > (byte) 0)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("imprisoned_lords");
                  position.Set(-0.33f, 1.38f, 0.0f);
                  break;
                }
                break;
              case 20:
                if (PetManager.Instance.CheckPetListBuildMark())
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
                  break;
                }
                break;
              case 23:
                if (PetManager.Instance.m_AllPetTrainState == PetManager.EPetTrainDataState.CanReceive)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
                  break;
                }
                break;
              default:
                if (buildId == (ushort) 7 && instance.HospitalTotal > 0U)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_01");
                  break;
                }
                break;
            }
          }
          else
          {
            switch (buildingData.AllBuildsData[(int) this.Index].BuildID)
            {
              case 6:
                if (!instance.queueBarData[10].bActive && buildingData.AllBuildsData[(int) this.Index].Level > (byte) 0)
                {
                  uint num2 = instance.AttribVal.TotalOuterSoldier + (uint) instance.SoldierTotal;
                  for (int index = 0; index < 16; ++index)
                    num2 += instance.mSoldier_Hospital[index];
                  if (num2 < 4200000000U)
                  {
                    this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_02");
                    break;
                  }
                  break;
                }
                break;
              case 7:
                if (instance.HospitalTotal > 0U)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_01");
                  break;
                }
                break;
              case 10:
                if (!instance.queueBarData[1].bActive && buildingData.AllBuildsData[(int) this.Index].Level > (byte) 0)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_04");
                  break;
                }
                break;
              case 12:
                this.PromptRender.transform.localScale *= 0.8f;
                if (instance.TrapHospitalTotal > 0U)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_01");
                  break;
                }
                if (!instance.queueBarData[14].bActive && (instance.GetTechLevel((ushort) 11) > (byte) 0 || instance.GetTechLevel((ushort) 12) > (byte) 0 || instance.GetTechLevel((ushort) 13) > (byte) 0) && instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAP_CAPACITY) > instance.TrapTotal)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_03");
                  break;
                }
                break;
              case 14:
                if (instance.TotalSoldier_Embassy > 0U)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_11");
                  break;
                }
                break;
              case 16:
                if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 17)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_07");
                  break;
                }
                if (instance.m_CryptData.money == (ushort) 0)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_05");
                  break;
                }
                if (instance.m_CryptData.startTime + (long) GameConstants.CryptSecends[(int) instance.m_CryptData.kind] - instance.ServerTime <= 0L)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_06");
                  break;
                }
                break;
              case 18:
                if (instance.PrisonerNum > (byte) 0)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("imprisoned_lords");
                  position.Set(-0.33f, 1.38f, 0.0f);
                  break;
                }
                break;
              case 20:
                if (PetManager.Instance.CheckPetListBuildMark())
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
                  break;
                }
                break;
              case 22:
                if (!instance.queueBarData[34].bActive && buildingData.AllBuildsData[(int) this.Index].Level > (byte) 0)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_10");
                  break;
                }
                break;
              case 23:
                if (PetManager.Instance.m_AllPetTrainState == PetManager.EPetTrainDataState.CanReceive)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
                  break;
                }
                if (PetManager.Instance.m_AllPetTrainState == PetManager.EPetTrainDataState.Empty && buildingData.AllBuildsData[(int) this.Index].Level > (byte) 0)
                {
                  this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_10");
                  break;
                }
                break;
            }
          }
          if (instance.MySysSetting.bShowEquipUp && !instance.queueBarData[18].bActive && buildingData.AllBuildsData[(int) this.Index].BuildID == (ushort) 15)
          {
            if (LordEquipData.Instance().isEquipEvoReady)
              this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
          }
          else if (buildingData.AllBuildsData[(int) this.Index].BuildID == (ushort) 8 && buildingData.castleSkin.CheckShowCastleSkin() && buildingData.castleSkin.CheckShowExclamation(true))
          {
            this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
            position.Set(0.64f, 2.51f, 0.0f);
          }
        }
        else
          this.UpdateExtendBuildPrompt(this.Index, ref position);
        if ((Object) this.PromptRender.sprite != (Object) null)
        {
          this.PromptRender.transform.localPosition = position;
          this.PromptRender.enabled = this.spriteRender.enabled;
          break;
        }
        this.PromptRender.enabled = false;
        break;
      case 8:
        if (instance.MySysSetting.bShowBuildUp && this.CheckUpdateRes <= (byte) 1 && buildingData.BuildingManorID == (ushort) 0 && (int) this.Index < buildingData.AllBuildsData.Length && buildingData.AllBuildsData[(int) this.Index].BuildID > (ushort) 0 && (int) buildingData.AllBuildsData[(int) this.Index].Level < (int) buildingData.BuildlevelupCheck[(int) buildingData.AllBuildsData[(int) this.Index].BuildID])
        {
          this.UpgradeRender.enabled = true;
          break;
        }
        this.UpgradeRender.enabled = false;
        break;
      case 9:
        if (!instance.MySysSetting.bShowBuildUp || buildingData.AllBuildsData[(int) this.Index].BuildID == (ushort) 0 || buildingData.BuildingManorID > (ushort) 0 || (int) this.Index < buildingData.AllBuildsData.Length && buildingData.AllBuildsData[(int) this.Index].BuildID == (ushort) 16 && buildingData.AllBuildsData[(int) this.Index].Level == (byte) 9)
        {
          this.UpgradeRender.enabled = false;
          break;
        }
        this.CheckUpdateRes = buildingData.AllBuildsData[(int) this.Index].Level >= (byte) 25 ? (byte) 2 : buildingData.CheckLevelupRule(buildingData.AllBuildsData[(int) this.Index].BuildID, (byte) ((uint) buildingData.AllBuildsData[(int) this.Index].Level + 1U));
        if (this.CheckUpdateRes == (byte) 0)
        {
          this.UpgradeRender.enabled = true;
          break;
        }
        this.UpgradeRender.enabled = false;
        break;
      case 12:
        this.SetSprite(this.Index, (byte) 0);
        break;
    }
    if ((int) this.Index >= buildingData.AllBuildsData.Length || buildingData.AllBuildsData[(int) this.Index].BuildID <= (ushort) 0)
      return;
    this.LevelRender.enabled = !this.markspriteRender.enabled;
  }

  private void UpdateExtendBuildPrompt(ushort Index, ref Vector3 position)
  {
    DataManager instance1 = DataManager.Instance;
    switch ((byte) Index)
    {
      case 100:
        if (DataManager.StageDataController.StageRecord[2] <= (ushort) 1)
          this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_07");
        else if (instance1.MySysSetting.bShowTrainingIdle && (int) instance1.RoleAttr.Morale >= (int) instance1.HeroMaxMorale)
          this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_08");
        position.Set(0.0f, 2.34f, 0.0f);
        break;
      case 101:
        position.x = 0.89f;
        position.y = 2.11f;
        if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 10)
        {
          this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_07");
          break;
        }
        ActivityManager instance2 = ActivityManager.Instance;
        ArenaManager instance3 = ArenaManager.Instance;
        if (instance2.IsInKvK((ushort) 0) || instance3.CheckArenaClose() != (ushort) 0)
        {
          if (!instance1.MySysSetting.bShowArena)
            break;
          if (instance1.CheckPrizeFlag((byte) 20))
          {
            this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_12");
            break;
          }
          if (instance3.m_ArenaNewReportNum <= (byte) 0 && instance3.m_ArenaCrystalPrize <= 0U)
            break;
          this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
          break;
        }
        if (!instance1.MySysSetting.bShowArena)
          break;
        if (instance1.CheckPrizeFlag((byte) 20))
        {
          this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_12");
          break;
        }
        if (instance3.m_ArenaTodayChallenge >= (byte) 5 && instance3.m_ArenaNewReportNum <= (byte) 0 && instance3.m_ArenaCrystalPrize <= 0U)
          break;
        this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
        break;
      case 102:
        if (DataManager.StageDataController.StageRecord[2] < (ushort) 3)
        {
          this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_07");
          break;
        }
        if (!instance1.MySysSetting.bShowTrainingIdle || DataManager.Instance.AttribVal.TotalDugoutSoldier != 0U)
          break;
        this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_10");
        break;
      case 103:
        if (AmbushManager.Instance.GetMaxTroop() > 0U)
        {
          this.spriteRender.enabled = true;
          break;
        }
        this.spriteRender.enabled = false;
        break;
      case 104:
        if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 13)
        {
          this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_07");
          break;
        }
        if (!instance1.MySysSetting.bShowTrainingIdle || MerchantmanManager.Instance.TradeStatus >= (byte) 15)
          break;
        this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
        break;
      case 105:
        GUIManager instance4 = GUIManager.Instance;
        if (instance4.BuildingData.bHideLaboryPromptLock == (byte) 0 && ((long) DataManager.Instance.RoleAttr.Guide & 16777216L) == 0L && instance4.BoxID[0] == (ushort) 0)
        {
          this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_07");
          break;
        }
        if (!instance1.MySysSetting.bShowTrainingIdle)
          break;
        bool flag = true;
        for (int index = 0; index < instance4.BoxID.Length; ++index)
        {
          if (instance4.BoxTime[index] > 0L & instance4.BoxID[index] > (ushort) 0)
          {
            flag = false;
            if (instance4.BoxTime[index] < instance1.ServerTime)
            {
              this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
              break;
            }
          }
        }
        if (!flag)
          break;
        this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_10");
        break;
      case 106:
        position.x = 0.47f;
        position.y = 1.35f;
        if (!GamblingManager.Instance.IsDailyFreeScardStar(UIBattle_Gambling.eMode.Normal) && !GamblingManager.Instance.IsDailyFreeScardStar(UIBattle_Gambling.eMode.Turbo))
          break;
        this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
        break;
    }
  }

  public bool UpdateRun(float delta)
  {
    if ((double) this.UpdateTime > 0.30000001192092896)
    {
      GUIManager.Instance.BuildingData.NotifyOpenUI(this.Index);
      this.spriteRender.color = Color.black;
      GUIManager.Instance.BuildingData.UpdateBuildState((byte) 7, (ushort) 1);
      GUIManager.Instance.HideUILock(EUILock.Normal);
      return false;
    }
    if ((double) this.UpdateTime > 0.5)
      return false;
    float num = HUDMessageMgr.Quintic(this.UpdateTime, 0.1f, 0.2f, 0.3f);
    this.spriteRender.color = new Color(num, num, num);
    this.UpdateTime += Time.deltaTime;
    return true;
  }
}
