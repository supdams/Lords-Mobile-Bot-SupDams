// Decompiled with JetBrains decompiler
// Type: MapSprite
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class MapSprite : IMotionUpdate
{
  private const float WildChangeVal = 32f;
  public MapSpriteManager mapspriteManager;
  public ushort BuildSpritesMax;
  private SpriteBase[] Builds;
  private Build HeroBuild;
  private Build ArenaBuild;
  private Build DugoutBuild;
  private Build Fortress;
  private Build BlackMarket;
  private Build Laboratory;
  private Build Carsino;
  public GameObject[] SpriteGameObject;
  public GameObject MapSpriteRoot;
  public GameObject EffectGo;
  public byte SpriteEffectIdx;
  public GameObject[] StageLock;
  private int[] StageLockNameCode;
  private EasingEffect BuildMotion;
  private byte EasingIndex;
  private int MotionIndex = -1;
  private Transform MotionTransform;
  private Vector3 Source;
  private float Change;
  private float DeltaTime;
  private float TotalTime;
  private float WaitTime;
  private float GuildSpeed = 8f;
  private float GuildPosY = 40f;
  private byte DownUp;
  private ushort UpdateIndex;
  private ushort GuideManorID;
  private ushort GuideBuildID;
  private GameObject EffectBuildComplete;
  private GameObject MainTownLevelup;
  private GameObject MainTownLevelupRing;
  private float MainTownDelay = -1f;
  public SpriteRenderer GuildPoint;
  public SpriteRenderer DiamonAct;
  public float UpdateTime;
  private JailBuildNotice JailNoticeIcon;
  private WorldMode Type;

  public MapSprite(WorldMode Type, ushort SpriteNum = 1)
  {
    this.Type = Type;
    if (SpriteNum == (ushort) 0)
      return;
    GUIManager.Instance.InitMapSprite();
    if (this.Type == WorldMode.Wild)
    {
      this.MapSpriteRoot = new GameObject("Build");
      SpriteNum = (ushort) (byte) GUIManager.Instance.BuildingData.GetCurrentChapterBuildCount();
      this.mapspriteManager = new MapSpriteManager(this.Type, (ushort) (((int) SpriteNum + 7) * 5));
      this.GuildPoint = new GameObject("ManorGuild", new System.Type[1]
      {
        typeof (SpriteRenderer)
      }).GetComponent<SpriteRenderer>();
      this.GuildPoint.sprite = this.mapspriteManager.GetSpriteByName("arrow");
      this.GuildPoint.material = this.mapspriteManager.SpriteMaterial;
      this.GuildPoint.color = Color.black;
      this.GuildPoint.sortingOrder = -1;
      this.GuildPoint.transform.localScale *= 10f;
      this.DiamonAct = new GameObject("ManorDiamon", new System.Type[1]
      {
        typeof (SpriteRenderer)
      }).GetComponent<SpriteRenderer>();
      this.DiamonAct.sprite = this.mapspriteManager.GetSpriteByName("prompt_06");
      this.DiamonAct.material = this.mapspriteManager.SpriteMaterial;
      this.DiamonAct.color = Color.black;
      this.DiamonAct.sortingOrder = -1;
      this.DiamonAct.transform.localScale *= 10f;
      this.DiamonAct.transform.localPosition = new Vector3(-9.92f, 6.41f, 126.48f);
      Quaternion localRotation = this.GuildPoint.transform.localRotation with
      {
        eulerAngles = GUIManager.Instance.BuildingData.BuildRot
      };
      this.GuildPoint.transform.localRotation = localRotation;
      this.GuildPoint.enabled = false;
      this.DiamonAct.transform.localRotation = localRotation;
      this.DiamonAct.enabled = false;
      this.HeroBuild = new Build();
      this.ArenaBuild = new Build();
      this.DugoutBuild = new Build();
      this.Fortress = new Build();
      this.BlackMarket = new Build();
      this.Laboratory = new Build();
      this.Carsino = new Build();
      this.SpriteGameObject = new GameObject[(int) SpriteNum + 7];
      this.StageLock = new GameObject[DataManager.StageDataController.CorpsStageTable.TableCount];
      this.StageLockNameCode = new int[this.StageLock.Length];
    }
    else
    {
      this.MapSpriteRoot = new GameObject("Stage");
      this.mapspriteManager = new MapSpriteManager(this.Type, (ushort) ((uint) SpriteNum * 5U));
      this.mapspriteManager.InitTextObj(SpriteNum);
      this.SpriteGameObject = new GameObject[(int) SpriteNum];
    }
    GUIManager.Instance.BuildingData.mapspriteManager = this.mapspriteManager;
    this.BuildSpritesMax = SpriteNum;
    this.Builds = new SpriteBase[(int) this.BuildSpritesMax];
    this.Initial();
    this.BuildMotion = new EasingEffect();
    this.BuildMotion.Motion = (IMotionUpdate) this;
  }

  public void Initial()
  {
    bool flag = DataManager.StageDataController._stageMode == StageMode.Dare;
    if (flag && this.Type == WorldMode.OpenUp)
      this.mapspriteManager.LoadChallegeFrame();
    for (byte Index = 0; (int) Index < (int) this.BuildSpritesMax; ++Index)
    {
      if (this.Type == WorldMode.Wild)
      {
        if (this.Builds[(int) Index] == null)
          this.Builds[(int) Index] = (SpriteBase) new Build();
        BuildManorData recordByIndex = DataManager.Instance.BuildManorData.GetRecordByIndex((int) GUIManager.Instance.BuildingData.GetMonorIndex((int) Index));
        this.Builds[(int) Index].Index = recordByIndex.ID;
        this.SpriteGameObject[(int) Index] = this.Builds[(int) Index].InitialSprite(this.mapspriteManager);
        this.SpriteGameObject[(int) Index].transform.parent.SetParent(this.MapSpriteRoot.transform);
        if (GUIManager.Instance.BuildingData.AllBuildsData[(int) recordByIndex.ID].BuildID == (ushort) 18)
        {
          Build build = this.Builds[(int) Index] as Build;
          this.JailNoticeIcon = build.spriteRender.gameObject.GetComponent<JailBuildNotice>();
          if ((UnityEngine.Object) this.JailNoticeIcon == (UnityEngine.Object) null)
          {
            this.JailNoticeIcon = build.spriteRender.gameObject.AddComponent<JailBuildNotice>();
            this.JailNoticeIcon.Init(this.mapspriteManager);
          }
        }
      }
      else
      {
        if (this.Builds[(int) Index] == null)
          this.Builds[(int) Index] = !flag ? (SpriteBase) new Campaign() : (SpriteBase) new ChallengeCampaign();
        this.Builds[(int) Index].Index = (ushort) (byte) (((int) Index + 1) * 3);
        this.SpriteGameObject[(int) Index] = this.Builds[(int) Index].InitialSprite(this.mapspriteManager);
        this.SpriteGameObject[(int) Index].transform.SetParent(this.MapSpriteRoot.transform);
      }
    }
    if (this.Type == WorldMode.Wild)
    {
      this.HeroBuild.Index = (ushort) 100;
      this.ArenaBuild.Index = (ushort) 101;
      this.DugoutBuild.Index = (ushort) 102;
      this.Fortress.Index = (ushort) 103;
      this.BlackMarket.Index = (ushort) 104;
      this.Laboratory.Index = (ushort) 105;
      this.Carsino.Index = (ushort) 106;
      this.SpriteGameObject[this.SpriteGameObject.Length - 7] = this.Carsino.InitialSprite(this.mapspriteManager);
      this.SpriteGameObject[this.SpriteGameObject.Length - 6] = this.Laboratory.InitialSprite(this.mapspriteManager);
      this.SpriteGameObject[this.SpriteGameObject.Length - 5] = this.BlackMarket.InitialSprite(this.mapspriteManager);
      this.SpriteGameObject[this.SpriteGameObject.Length - 4] = this.Fortress.InitialSprite(this.mapspriteManager);
      this.SpriteGameObject[this.SpriteGameObject.Length - 3] = this.DugoutBuild.InitialSprite(this.mapspriteManager);
      this.SpriteGameObject[this.SpriteGameObject.Length - 2] = this.HeroBuild.InitialSprite(this.mapspriteManager);
      this.SpriteGameObject[this.SpriteGameObject.Length - 1] = this.ArenaBuild.InitialSprite(this.mapspriteManager);
      if (GUIManager.Instance.BuildingData.BuildingManorID > (ushort) 0)
        this.UpdateMapSprite(GUIManager.Instance.BuildingData.BuildingManorID, (byte) 2);
      this.InitLock();
      this.UpdateDiamon();
    }
    this.GuideManorID = (ushort) 0;
    this.GuideBuildID = (ushort) 0;
  }

  public void InitLock()
  {
    StageManager stageDataController = DataManager.StageDataController;
    CString cstring = StringManager.Instance.StaticString1024();
    Vector3 vector3_1 = Vector3.one * 12.5f;
    Vector3 vector3_2 = new Vector3(45f, 185f, 3f);
    for (int index = 0; index < this.StageLock.Length; ++index)
    {
      if (index > (int) stageDataController.StageRecord[2])
      {
        cstring.ClearString();
        cstring.IntToFormat((long) (index + 1));
        cstring.AppendFormat("Lock_{0}");
        CorpsStage recordByKey = DataManager.StageDataController.CorpsStageTable.GetRecordByKey((ushort) (1 + index));
        this.StageLock[index] = new GameObject(cstring.ToString());
        this.StageLockNameCode[index] = this.StageLock[index].name.GetHashCode();
        SpriteRenderer spriteRenderer = this.StageLock[index].AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = this.mapspriteManager.GetSpriteByName("lock");
        spriteRenderer.material = GUIManager.Instance.MapSpriteMaterial;
        spriteRenderer.sortingOrder = -1;
        Transform transform = this.StageLock[index].transform;
        transform.position = GameConstants.WordToVector3(recordByKey.StagePos.X, recordByKey.StagePos.Y, recordByKey.StagePos.Z);
        transform.localScale = vector3_1;
        spriteRenderer.color = Color.black;
        Quaternion rotation = transform.rotation with
        {
          eulerAngles = vector3_2
        };
        transform.rotation = rotation;
        transform.SetParent(this.MapSpriteRoot.transform);
      }
    }
  }

  public void SetSpritePosition(ushort id, Vector3 pos)
  {
    if ((int) id >= this.SpriteGameObject.Length)
      return;
    this.SpriteGameObject[(int) id].transform.position = pos;
  }

  public bool NotifyOpenUI(int key)
  {
    AudioManager.Instance.PlayUISFX();
    if (this.HeroBuild.HashID == key)
    {
      if (DataManager.StageDataController.CheckStageModle())
      {
        GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Hero);
        this.HeroBuild.Update((byte) 1);
        this.GuildPoint.enabled = false;
      }
      else
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8350U), (ushort) byte.MaxValue);
    }
    else if (this.ArenaBuild.HashID == key)
    {
      this.ArenaBuild.Update((byte) 1);
      this.GuildPoint.enabled = false;
    }
    else if (this.DugoutBuild.HashID == key)
    {
      this.DugoutBuild.Update((byte) 1);
      this.GuildPoint.enabled = false;
    }
    else if (this.Fortress.HashID == key)
    {
      this.Fortress.Update((byte) 1);
      this.GuildPoint.enabled = false;
    }
    else if (this.BlackMarket.HashID == key)
    {
      this.BlackMarket.Update((byte) 1);
      this.GuildPoint.enabled = false;
    }
    else if (this.Laboratory.HashID == key)
    {
      this.Laboratory.Update((byte) 1);
      this.GuildPoint.enabled = false;
    }
    else if (this.Carsino.HashID == key)
    {
      this.Carsino.Update((byte) 1);
      this.GuildPoint.enabled = false;
    }
    else
    {
      for (ushort index = 0; (int) index < this.Builds.Length; ++index)
      {
        if (this.Builds[(int) index].HashID == key)
        {
          if (this.MotionIndex != (int) index)
          {
            this.Builds[(int) index].Update((byte) 1);
            this.GuildPoint.enabled = false;
          }
          return true;
        }
      }
      if (this.StageLock != null)
      {
        for (ushort index = 0; (int) index < this.StageLock.Length; ++index)
        {
          if (this.StageLockNameCode[(int) index] == key)
          {
            if ((int) DataManager.StageDataController.StageRecord[2] < (int) index)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7374U), (ushort) byte.MaxValue);
              DataManager.StageDataController.resetStageMode(StageMode.Corps);
              DataManager.msgBuffer[0] = (byte) 7;
              GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
            }
            return true;
          }
        }
      }
    }
    return false;
  }

  public void Destroy()
  {
    for (ushort index = 0; (int) index < (int) this.BuildSpritesMax; ++index)
    {
      this.Builds[(int) index].Destroy();
      this.Builds[(int) index] = (SpriteBase) null;
    }
    if (this.mapspriteManager != null)
    {
      if ((UnityEngine.Object) this.GuildPoint != (UnityEngine.Object) null)
        this.mapspriteManager.ReleaseSpriteObj(this.GuildPoint.gameObject);
      this.mapspriteManager.Destory();
    }
    this.mapspriteManager = (MapSpriteManager) null;
    if ((UnityEngine.Object) this.EffectBuildComplete != (UnityEngine.Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.EffectBuildComplete);
      this.EffectBuildComplete = (GameObject) null;
    }
    if ((UnityEngine.Object) this.MainTownLevelup != (UnityEngine.Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.MainTownLevelup);
      this.MainTownLevelup = (GameObject) null;
    }
    if ((UnityEngine.Object) this.MainTownLevelupRing != (UnityEngine.Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.MainTownLevelupRing);
      this.MainTownLevelupRing = (GameObject) null;
    }
    this.MotionTransform = (Transform) null;
    if (this.HeroBuild != null)
      this.HeroBuild.Destroy();
    this.HeroBuild = (Build) null;
    if (this.ArenaBuild != null)
      this.ArenaBuild.Destroy();
    this.ArenaBuild = (Build) null;
    if (this.DugoutBuild != null)
      this.DugoutBuild.Destroy();
    this.DugoutBuild = (Build) null;
    if (this.Fortress != null)
      this.Fortress.Destroy();
    this.Fortress = (Build) null;
    if (this.BlackMarket != null)
      this.BlackMarket.Destroy();
    this.BlackMarket = (Build) null;
    if ((UnityEngine.Object) this.MapSpriteRoot != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.MapSpriteRoot);
    this.MapSpriteRoot = (GameObject) null;
    if (this.Laboratory != null)
      this.Laboratory.Destroy();
    this.Laboratory = (Build) null;
    if (this.Carsino != null)
      this.Carsino.Destroy();
    this.Carsino = (Build) null;
    if ((UnityEngine.Object) this.GuildPoint != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.GuildPoint.gameObject);
    this.GuildPoint = (SpriteRenderer) null;
    if ((UnityEngine.Object) this.EffectGo != (UnityEngine.Object) null)
      ParticleManager.Instance.DeSpawn(this.EffectGo);
    this.EffectGo = (GameObject) null;
    if ((UnityEngine.Object) this.DiamonAct != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.DiamonAct.gameObject);
    this.DiamonAct = (SpriteRenderer) null;
    GUIManager.Instance.BuildingData.castleSkin.Destroy();
  }

  public void Hide()
  {
    for (ushort index = 0; (int) index < (int) this.BuildSpritesMax; ++index)
      this.Builds[(int) index].Hide();
  }

  public void ShowManorGuild(ushort ManorID)
  {
    if ((int) this.GuideManorID == (int) ManorID && (int) this.GuideBuildID == (int) GUIManager.Instance.BuildingData.AllBuildsData[(int) ManorID].BuildID)
    {
      this.GuildPoint.enabled = true;
    }
    else
    {
      this.GuideManorID = ManorID;
      this.GuideBuildID = GUIManager.Instance.BuildingData.AllBuildsData[(int) ManorID].BuildID;
      BuildManorData recordByKey = DataManager.Instance.BuildManorData.GetRecordByKey(ManorID);
      float x;
      float num1;
      float z;
      if (GUIManager.Instance.BuildingData.AllBuildsData[(int) ManorID].BuildID == (ushort) 0)
      {
        x = (float) ((recordByKey.mPosionX <= (ushort) 30000 ? (double) recordByKey.mPosionX : (double) recordByKey.mPosionX - (double) ushort.MaxValue) * 0.0099999997764825821);
        num1 = (float) ((recordByKey.mPosionY <= (ushort) 32768 ? (double) recordByKey.mPosionY : (double) recordByKey.mPosionY - (double) ushort.MaxValue) * 0.0099999997764825821);
        z = (float) ((recordByKey.mPosionZ <= (ushort) 32768 ? (double) recordByKey.mPosionZ : (double) recordByKey.mPosionZ - (double) ushort.MaxValue) * 0.0099999997764825821);
      }
      else
      {
        x = (float) ((recordByKey.bPosionX <= (ushort) 30000 ? (double) recordByKey.bPosionX : (double) recordByKey.bPosionX - (double) ushort.MaxValue) * 0.0099999997764825821);
        num1 = (float) ((recordByKey.bPosionY <= (ushort) 32768 ? (double) recordByKey.bPosionY : (double) recordByKey.bPosionY - (double) ushort.MaxValue) * 0.0099999997764825821);
        z = (float) ((recordByKey.bPosionZ <= (ushort) 32768 ? (double) recordByKey.bPosionZ : (double) recordByKey.bPosionZ - (double) ushort.MaxValue) * 0.0099999997764825821);
      }
      float y;
      if (GUIManager.Instance.BuildingData.AllBuildsData[(int) ManorID].BuildID == (ushort) 8)
      {
        this.GuildPosY = 35f;
        y = 18f;
      }
      else if (GUIManager.Instance.BuildingData.AllBuildsData[(int) ManorID].BuildID == (ushort) 0)
      {
        this.GuildPosY = y = num1 + 6f;
      }
      else
      {
        double num2 = (double) num1;
        double num3 = ((double) GUIManager.Instance.BuildingData.GetBuildSprite(this.GuideBuildID, GUIManager.Instance.BuildingData.AllBuildsData[(int) ManorID].Level).rect.height - 32.0) / 8.0;
        this.GuildPosY = y = (float) (num2 + num3);
      }
      this.GuildPoint.transform.position = new Vector3(x, y, z);
      this.GuildPoint.enabled = true;
    }
  }

  public void UpdateGuildPos()
  {
    if (this.GuildPoint.enabled)
    {
      Transform transform = this.GuildPoint.transform;
      float num = Time.deltaTime * this.GuildSpeed;
      transform.position += Vector3.up * num;
      if ((double) transform.position.y > (double) this.GuildPosY + 8.0)
      {
        Vector3 position = transform.position with
        {
          y = this.GuildPosY + 8f
        };
        transform.position = position;
        this.GuildSpeed *= -1f;
      }
      if ((double) transform.position.y < (double) this.GuildPosY)
      {
        Vector3 position = transform.position with
        {
          y = this.GuildPosY
        };
        transform.position = position;
        this.GuildSpeed *= -1f;
      }
    }
    if ((double) this.MainTownDelay >= 0.0)
    {
      this.MainTownDelay -= Time.deltaTime;
      if ((double) this.MainTownDelay < 0.0)
      {
        if ((UnityEngine.Object) this.MainTownLevelupRing != (UnityEngine.Object) null)
          ParticleManager.Instance.DeSpawn(this.MainTownLevelupRing);
        this.MainTownLevelupRing = ParticleManager.Instance.Spawn((ushort) 359, (Transform) null, new Vector3(-47.6f, 45f, 2.8f), 1f, true, false);
      }
    }
    this.UpdatePrisonerTime();
  }

  public void UpdatePrisonerTime()
  {
    this.UpdateTime += Time.deltaTime;
    if (!((UnityEngine.Object) this.JailNoticeIcon != (UnityEngine.Object) null) || (double) this.UpdateTime < 1.0)
      return;
    this.UpdateTime = 0.0f;
    this.JailNoticeIcon.UpdateTime();
  }

  public void UpdateDiamon()
  {
    if (GUIManager.Instance.NPCCityBonusTime > 0L)
      this.DiamonAct.enabled = true;
    else
      this.DiamonAct.enabled = false;
  }

  public void UpdateMapSprite(ushort ID, byte State)
  {
    if (ID == (ushort) 0)
      return;
    int index1 = (int) ID;
    eBuildState eBuildState = (eBuildState) State;
    if (this.Type == WorldMode.Wild)
    {
      switch (eBuildState)
      {
        case eBuildState.Prompt:
          if (this.HeroBuild != null)
            this.HeroBuild.Update(State);
          if (this.ArenaBuild != null)
            this.ArenaBuild.Update(State);
          if (this.DugoutBuild != null)
            this.DugoutBuild.Update(State);
          if (this.Fortress != null)
            this.Fortress.Update(State);
          if (this.BlackMarket != null)
            this.BlackMarket.Update(State);
          if (this.Laboratory != null)
            this.Laboratory.Update(State);
          if (this.Carsino != null)
            this.Carsino.Update(State);
          this.UpdateDiamon();
          for (int length = this.Builds.Length; length > 0; --length)
            this.Builds[length - 1].Update(State);
          break;
        case eBuildState.Login:
          this.Initial();
          break;
        case eBuildState.TurnOffEff:
          if (!((UnityEngine.Object) this.EffectBuildComplete != (UnityEngine.Object) null))
            break;
          ParticleManager.Instance.DeSpawn(this.EffectBuildComplete);
          this.EffectBuildComplete = (GameObject) null;
          break;
        case eBuildState.CheckUpdateResource:
        case eBuildState.CheckUpdateCondition:
          for (int length = this.Builds.Length; length > 0; --length)
            this.Builds[length - 1].Update(State);
          break;
        case eBuildState.TurnOffArrow:
          if (!((UnityEngine.Object) this.GuildPoint != (UnityEngine.Object) null))
            break;
          this.GuildPoint.enabled = false;
          break;
        case eBuildState.CheckPrisoner:
          if (!((UnityEngine.Object) this.JailNoticeIcon != (UnityEngine.Object) null))
            break;
          this.JailNoticeIcon.UpdateData();
          break;
        default:
          if (GUIManager.Instance.BuildingData.AllBuildsData.Length <= (int) ID)
            break;
          for (int index2 = 0; index2 < this.Builds.Length; ++index2)
          {
            if ((int) this.Builds[index2].Index == (int) ID)
              index1 = index2;
          }
          this.UpdateIndex = (ushort) index1;
          BuildsData buildingData = GUIManager.Instance.BuildingData;
          byte level = buildingData.AllBuildsData[(int) ID].Level;
          if ((UnityEngine.Object) this.MotionTransform != (UnityEngine.Object) null)
          {
            this.MotionTransform.position = this.Source with
            {
              y = (double) this.Change >= 0.0 ? this.Source.y + this.Change : this.Source.y
            };
            this.Builds[this.MotionIndex].Update((byte) 3);
            this.MotionTransform = (Transform) null;
            this.MotionIndex = -1;
            MotionEffect.RemoveStack(this.EasingIndex);
          }
          if (buildingData.AllBuildsData[(int) ID].BuildID == (ushort) 16 && (int) buildingData.BuildingManorID != (int) this.Builds[index1].Index && eBuildState == eBuildState.Complete && (level == (byte) 1 || level == (byte) 3 || level == (byte) 6 || level == (byte) 9))
          {
            this.Builds[index1].Update((byte) 0);
            this.MotionTransform = this.SpriteGameObject[index1].transform;
            this.Source = this.MotionTransform.position;
            this.Change = -32f;
            this.DeltaTime = 0.0f;
            this.TotalTime = 2f;
            this.WaitTime = 1f;
            this.DownUp = (byte) 1;
            this.MotionIndex = index1;
            this.EasingIndex = MotionEffect.SetStack((MotionEffect) this.BuildMotion);
          }
          else if ((int) buildingData.BuildingManorID != (int) this.Builds[index1].Index && eBuildState == eBuildState.Complete && (level == (byte) 1 || level == (byte) 9 || level == (byte) 17 || level == (byte) 25))
          {
            this.Builds[index1].Update((byte) 0);
            this.MotionTransform = this.SpriteGameObject[index1].transform;
            this.Source = this.MotionTransform.position;
            this.Change = -32f;
            this.DeltaTime = 0.0f;
            this.TotalTime = 2f;
            this.WaitTime = 1f;
            this.DownUp = (byte) 1;
            this.MotionIndex = index1;
            this.EasingIndex = MotionEffect.SetStack((MotionEffect) this.BuildMotion);
          }
          else
          {
            if (eBuildState == eBuildState.Complete && (int) buildingData.BuildingManorID != (int) this.Builds[index1].Index)
              this.ShowBuildCompleteEffect();
            this.Builds[index1].Update(State);
            this.GuideManorID = (ushort) 0;
            this.GuideBuildID = (ushort) 0;
            this.UpdateMapSprite((ushort) byte.MaxValue, (byte) 9);
          }
          this.HideNoticeIcon();
          break;
      }
    }
    else
    {
      int index3 = index1 - 1;
      this.Builds[index3].Update(State);
      if (State != (byte) 1)
        return;
      this.MotionTransform = this.SpriteGameObject[index3].transform;
      this.Source.Set(1f, 1f, 1f);
      this.Change = 4.2f;
      this.DeltaTime = 0.0f;
      this.TotalTime = 0.25f;
      this.SpriteEffectIdx = (byte) 2;
    }
  }

  public void UpdateSpriteFrame(int index) => this.Builds[index].UpdateSpriteFrame();

  public void ShowChallegeEffect(Transform trans)
  {
    if ((UnityEngine.Object) this.EffectGo != (UnityEngine.Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.EffectGo);
      this.EffectGo = (GameObject) null;
    }
    this.EffectGo = ParticleManager.Instance.Spawn((ushort) 294, (Transform) null, trans.localPosition, 1f, true, false);
    this.EffectGo.transform.localRotation = this.EffectGo.transform.localRotation with
    {
      eulerAngles = new Vector3(0.0f, 180f, 0.0f)
    };
    AudioManager.Instance.PlayMP3SFX((ushort) 41036);
  }

  private void MainTownLevelEffect()
  {
    Vector3 localPosition = this.SpriteGameObject[0].transform.localPosition;
    localPosition.y += 40f;
    if ((UnityEngine.Object) this.MainTownLevelup != (UnityEngine.Object) null)
      ParticleManager.Instance.DeSpawn(this.MainTownLevelup);
    this.MainTownDelay = 10f;
    this.MainTownLevelup = ParticleManager.Instance.Spawn((ushort) 358, (Transform) null, localPosition, 2f, true, false);
    this.MainTownLevelup.transform.localRotation = this.MainTownLevelup.transform.localRotation with
    {
      eulerAngles = new Vector3(0.0f, 180f, 0.0f)
    };
  }

  private void ShowBuildCompleteEffect()
  {
    Vector3 localPosition = this.SpriteGameObject[(int) this.UpdateIndex].transform.localPosition;
    BuildsData buildingData = GUIManager.Instance.BuildingData;
    if ((UnityEngine.Object) this.EffectBuildComplete != (UnityEngine.Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.EffectBuildComplete);
      this.EffectBuildComplete = (GameObject) null;
    }
    if (buildingData.ImmEffect == (byte) 1)
    {
      buildingData.ImmEffect = (byte) 0;
      if (buildingData.AllBuildsData[(int) this.Builds[(int) this.UpdateIndex].Index].BuildID == (ushort) 8)
      {
        this.EffectBuildComplete = ParticleManager.Instance.Spawn((ushort) 347, (Transform) null, localPosition, 1f, true, false);
        this.MainTownLevelEffect();
      }
      else
        this.EffectBuildComplete = ParticleManager.Instance.Spawn((ushort) 331, (Transform) null, localPosition, 1f, true, false);
      AudioManager.Instance.PlayMP3SFX((ushort) 41036, 0.2f);
    }
    else if (buildingData.ImmEffect == (byte) 0)
    {
      if (buildingData.AllBuildsData[(int) this.Builds[(int) this.UpdateIndex].Index].BuildID == (ushort) 8)
      {
        this.EffectBuildComplete = ParticleManager.Instance.Spawn((ushort) 346, (Transform) null, localPosition, 1f, true, false);
        this.MainTownLevelEffect();
      }
      else
        this.EffectBuildComplete = ParticleManager.Instance.Spawn((ushort) 294, (Transform) null, localPosition, 1f, true, false);
      AudioManager.Instance.PlayMP3SFX((ushort) 41036);
    }
    this.ShowNoticeIcon();
    this.EffectBuildComplete.transform.localRotation = this.EffectBuildComplete.transform.localRotation with
    {
      eulerAngles = new Vector3(0.0f, 180f, 0.0f)
    };
    this.MotionIndex = -1;
  }

  private void HideNoticeIcon()
  {
    if (this.MotionIndex < 0 || GUIManager.Instance.BuildingData.AllBuildsData[(int) this.Builds[this.MotionIndex].Index].BuildID != (ushort) 18 || !((UnityEngine.Object) this.JailNoticeIcon != (UnityEngine.Object) null))
      return;
    this.JailNoticeIcon.Hide();
  }

  private void ShowNoticeIcon()
  {
    if (this.MotionIndex < 0 || GUIManager.Instance.BuildingData.AllBuildsData[(int) this.Builds[this.MotionIndex].Index].BuildID != (ushort) 18 || !((UnityEngine.Object) this.JailNoticeIcon != (UnityEngine.Object) null))
      return;
    this.JailNoticeIcon.UpdateData();
  }

  public void SetSprite(byte[] ID, byte[] HeroClass)
  {
    if (this.Builds == null)
      return;
    for (int index = 0; index < this.Builds.Length; ++index)
      this.Builds[index].SetSprite(GameConstants.ConvertBytesToUShort(ID, index << 1), HeroClass[index]);
  }

  public bool UpdateRun(float delta)
  {
    if ((UnityEngine.Object) this.MotionTransform == (UnityEngine.Object) null)
      return false;
    if (this.Type == WorldMode.Wild)
    {
      if (this.DownUp == byte.MaxValue)
      {
        this.MotionTransform.position = this.Source with
        {
          y = (double) this.Change >= 0.0 ? this.Source.y + this.Change : this.Source.y
        };
        this.Builds[(int) this.UpdateIndex].Update((byte) 3);
        this.MotionIndex = -1;
        this.DownUp = (byte) 0;
        return false;
      }
      if ((double) this.DeltaTime > (double) this.WaitTime)
        this.MotionTransform.position = this.Source with
        {
          y = EasingEffect.Linear(this.DeltaTime - this.WaitTime, this.Source.y, this.Change, this.TotalTime - this.WaitTime)
        };
    }
    else
    {
      float num = EasingEffect.Linear(this.DeltaTime, this.Source.x, this.Change, this.TotalTime);
      this.MotionTransform.GetChild((int) this.SpriteEffectIdx).localScale = Vector3.one * num;
    }
    this.DeltaTime += delta;
    if ((double) this.TotalTime >= (double) this.DeltaTime)
      return true;
    if (this.Type == WorldMode.Wild)
    {
      this.Source.y += this.Change;
      this.MotionTransform.position = this.Source;
      if (this.DownUp == (byte) 1)
      {
        this.Builds[(int) this.UpdateIndex].Update((byte) 3);
        this.Builds[(int) this.UpdateIndex].Update((byte) 0);
        this.Source = this.MotionTransform.position;
        this.Source.y -= 32f;
        this.MotionTransform.position = this.Source;
        this.Change = 32f;
        this.DeltaTime = 0.0f;
        this.TotalTime = 1f;
        this.WaitTime = 0.0f;
        this.DownUp = (byte) 0;
        return true;
      }
      this.ShowBuildCompleteEffect();
      this.Builds[(int) this.UpdateIndex].Update((byte) 3);
      this.Builds[(int) this.UpdateIndex].Update((byte) 5);
      this.UpdateMapSprite((ushort) byte.MaxValue, (byte) 9);
    }
    else
    {
      this.Source.Set(this.Change, this.Change, this.Change);
      this.MotionTransform.GetChild((int) this.SpriteEffectIdx++).localScale = this.Source;
      if (this.SpriteEffectIdx <= (byte) 4)
      {
        this.Source.Set(1f, 1f, 1f);
        this.MotionTransform.GetChild((int) this.SpriteEffectIdx).localScale = this.Source;
        this.MotionTransform.GetChild((int) this.SpriteEffectIdx).gameObject.SetActive(true);
        this.DeltaTime = 0.0f;
        this.TotalTime = 0.25f;
        return true;
      }
    }
    this.MotionTransform = (Transform) null;
    return false;
  }
}
