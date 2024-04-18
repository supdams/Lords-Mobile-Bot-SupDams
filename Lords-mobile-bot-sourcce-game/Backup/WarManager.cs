// Decompiled with JetBrains decompiler
// Type: WarManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class WarManager : Gameplay
{
  public const int TRT_MAX = 4;
  private const int MAX_TROOPS_PERTYPE = 4;
  public const uint REPORT_VER_OVERDUE = 8241;
  public const uint REPORT_VER_OVERDUE_SIMUVERSION = 1049;
  private const float SCALE_RATE = 1f;
  private const int RATE_OF_PER_FO = 2;
  private const int MAX_SOUND_KEY = 21;
  private const uint S_MOVING_DIRTY = 1;
  private const uint S_ATTACK_DIRTY = 2;
  private const uint S_RANGE_DIRTY = 4;
  private const uint S_STONEHIT_DIRTY = 8;
  public static float[,,] InitPositionLeft = new float[4, 4, 2]
  {
    {
      {
        30f,
        18f
      },
      {
        30f,
        12f
      },
      {
        30f,
        24f
      },
      {
        30f,
        6f
      }
    },
    {
      {
        7f,
        18f
      },
      {
        7f,
        12f
      },
      {
        7f,
        24f
      },
      {
        7f,
        6f
      }
    },
    {
      {
        21f,
        25f
      },
      {
        21f,
        5f
      },
      {
        14f,
        25f
      },
      {
        14f,
        5f
      }
    },
    {
      {
        0.0f,
        18f
      },
      {
        0.0f,
        12f
      },
      {
        0.0f,
        24f
      },
      {
        0.0f,
        6f
      }
    }
  };
  public static float[,,] InitPositionLeft_SiegeMode = new float[4, 4, 2]
  {
    {
      {
        30f,
        18f
      },
      {
        30f,
        12f
      },
      {
        30f,
        24f
      },
      {
        30f,
        6f
      }
    },
    {
      {
        7f,
        18f
      },
      {
        7f,
        12f
      },
      {
        7f,
        24f
      },
      {
        7f,
        6f
      }
    },
    {
      {
        21f,
        25f
      },
      {
        21f,
        5f
      },
      {
        14f,
        25f
      },
      {
        14f,
        5f
      }
    },
    {
      {
        0.0f,
        18f
      },
      {
        0.0f,
        12f
      },
      {
        0.0f,
        24f
      },
      {
        0.0f,
        6f
      }
    }
  };
  public static float[,,] InitPositionRight = new float[4, 4, 2]
  {
    {
      {
        80f,
        18f
      },
      {
        80f,
        12f
      },
      {
        80f,
        24f
      },
      {
        80f,
        6f
      }
    },
    {
      {
        103f,
        18f
      },
      {
        103f,
        12f
      },
      {
        103f,
        24f
      },
      {
        103f,
        6f
      }
    },
    {
      {
        89f,
        25f
      },
      {
        89f,
        5f
      },
      {
        96f,
        25f
      },
      {
        96f,
        5f
      }
    },
    {
      {
        110f,
        18f
      },
      {
        110f,
        12f
      },
      {
        110f,
        24f
      },
      {
        110f,
        6f
      }
    }
  };
  public static float[,,] InitPositionRight_SiegeMode = new float[4, 4, 2]
  {
    {
      {
        60f,
        18f
      },
      {
        60f,
        12f
      },
      {
        60f,
        24f
      },
      {
        60f,
        6f
      }
    },
    {
      {
        83f,
        18f
      },
      {
        83f,
        12f
      },
      {
        83f,
        24f
      },
      {
        83f,
        6f
      }
    },
    {
      {
        69f,
        25f
      },
      {
        69f,
        5f
      },
      {
        76f,
        25f
      },
      {
        76f,
        5f
      }
    },
    {
      {
        90f,
        18f
      },
      {
        90f,
        12f
      },
      {
        90f,
        24f
      },
      {
        90f,
        6f
      }
    }
  };
  public static float[,,] ActionPositionRight = new float[3, 4, 2]
  {
    {
      {
        31f,
        18f
      },
      {
        31f,
        12f
      },
      {
        31f,
        24f
      },
      {
        31f,
        6f
      }
    },
    {
      {
        45f,
        18f
      },
      {
        45f,
        12f
      },
      {
        45f,
        24f
      },
      {
        45f,
        6f
      }
    },
    {
      {
        38f,
        25f
      },
      {
        38f,
        5f
      },
      {
        45f,
        25f
      },
      {
        45f,
        5f
      }
    }
  };
  private Vector3[] ArcherPosOnTower = new Vector3[4]
  {
    new Vector3(53.04f, 7.77f, 20.77f),
    new Vector3(53.04f, 7.77f, 9.23f),
    new Vector3(53.04f, 4.54f, 32f),
    new Vector3(53.04f, 4.54f, -2f)
  };
  private byte[] brokenFO_Index = new byte[4]
  {
    byte.MaxValue,
    (byte) 0,
    (byte) 1,
    (byte) 1
  };
  private Vector3[] nonUseHeroPos_Left = new Vector3[5]
  {
    new Vector3(-6.5f, 0.0f, 15f),
    new Vector3(-6.5f, 0.0f, 11f),
    new Vector3(-6.5f, 0.0f, 19f),
    new Vector3(-6.5f, 0.0f, 7f),
    new Vector3(-6.5f, 0.0f, 23f)
  };
  private Vector3[] nonUseHeroPos_Right = new Vector3[5]
  {
    new Vector3(116.5f, 0.0f, 15f),
    new Vector3(116.5f, 0.0f, 11f),
    new Vector3(116.5f, 0.0f, 19f),
    new Vector3(116.5f, 0.0f, 7f),
    new Vector3(116.5f, 0.0f, 23f)
  };
  private Vector3[] nonUseHeroPos_Right_SiegeMode = new Vector3[5]
  {
    new Vector3(96.5f, 0.0f, 15f),
    new Vector3(96.5f, 0.0f, 11f),
    new Vector3(96.5f, 0.0f, 19f),
    new Vector3(96.5f, 0.0f, 7f),
    new Vector3(96.5f, 0.0f, 23f)
  };
  public Vector3 CastleBloodBarOffset = new Vector3(-2f, 0.0f, 0.0f);
  public static readonly string STAGE_WAR_SAVE_KEY = "{0}_PASS_STAGE";
  public float deltaTime;
  private float fixMoveDeltaTime;
  private float canMoveDeltaTime;
  public byte attackerCount;
  public byte attackerAliveCount;
  public ArmyGroup[] attackerArmies = new ArmyGroup[16];
  public byte[,] attackerArmiesMap = new byte[4, 4];
  public ArmyGroup attackerLord;
  public Soldier attackerLordUnit;
  public byte defenserCount;
  public byte defenserAliveCount;
  public ArmyGroup[] defenserArmies = new ArmyGroup[16];
  public byte[,] defenserArmiesMap = new byte[4, 4];
  public ArmyGroup defenserLord;
  public Soldier defenserLordUnit;
  public FlyingObjectManager FOMgr;
  public Transform renderRoot;
  public int nonCatapultsCount_Left;
  public int nonCatapultsCount_Right;
  private bool bUpdateOutsideHero = true;
  private List<ushort> attackerHeroIdCache = new List<ushort>(5);
  private List<ushort> defenserHeroIdCache = new List<ushort>(5);
  private List<Lord> attackerHeroCache = new List<Lord>(5);
  private List<Lord> defenserHeroCache = new List<Lord>(5);
  public ArmyGroup[] playerSideArmies = new ArmyGroup[17];
  public ArmyGroup[] enemySideArmies = new ArmyGroup[17];
  public byte playerCount;
  public byte enemyCount;
  public byte PickListCount;
  public GameObject[] PickList = new GameObject[10];
  public Transform PickedTrans;
  public RectTransform HintTrans;
  public ushort HintStrID;
  public uint HintHeroNo;
  public float HintTimer;
  public Vector2 ScreenSize = Vector2.zero;
  private bool bFirstTimeInit = true;
  private byte NewbieWarFlag;
  public ushort attackerLordID;
  public ushort defenserLordID;
  public uint m_ui32Tcik;
  private byte[] RecvBufferLeft = new byte[1024];
  private byte[] RecvBufferRight = new byte[1024];
  private EWarResult m_WarResult;
  public WarManager.WarState m_WarState;
  public byte SubState;
  private BSInvokeUtil BSUtil;
  private ulong m_SkillWorkingList;
  private bool m_bSkillDirty;
  public WarCamera WCamera = new WarCamera();
  public byte CameraModel;
  public bool bstart;
  public Transform mainCamera = Camera.main.transform;
  private BrokenFO[][] m_BrokenFO = new BrokenFO[2][];
  private WarParticleManager particleMgr = new WarParticleManager();
  private int SiegeMode;
  private WarCastle castle;
  private byte m_GateTier;
  public uint TrapsHp;
  public uint LastTrapsHp;
  public int MoraleStep;
  public WarControlPanel controlPanel;
  private Transform LordCage;
  private int CageKey;
  private byte CageState;
  private float CageTimer;
  private Vector3 CageTargetPos = Vector3.zero;
  private AudioManager audioMgr = AudioManager.Instance;
  private uint SoundDirtyFlag;
  private float? rangeDist_Sound;
  private ArmyGroup rangeSoundParent;
  private float? stoneHitDist_Sound;
  private ArmyGroup stoneHitSoundParent;
  private float? movingDist_Sound;
  private ArmyGroup movingSoundParent;
  private float? attackDist_Sound;
  private ArmyGroup attackSoundParent;
  private byte MovingSoundKey = 21;
  private byte AttackSoundKey = 21;
  private Transform movingSoundParentTrans;
  private UILegBattle uiBattle;
  private byte[] castleWeaponInfo = new byte[6];
  private int UIUpdateFlag;
  private EPlayerActionKind actionKind = EPlayerActionKind.DEFENDER;
  public uint DramaTriggerFlag;
  public bool bDramaWorking;
  public static CombatReplayMoraleInfo MoraleInfo = new CombatReplayMoraleInfo();
  public static WarManager.EWarKind WarKind = WarManager.EWarKind.Normal;
  public static ushort CoordSimuIndex_Left = 0;
  public static ushort TroopKindSimuIndex_Right = 0;
  public static ushort WarCoordIndex_Left = 0;
  public static ushort WarCoordIndex_Right = 0;
  public static byte NpcModeEnable = 0;
  public static POINT_KIND CurrentPointKind = POINT_KIND.PK_NONE;
  public static readonly int[] CoordToSoldiers = new int[6]
  {
    0,
    1,
    2,
    0,
    1,
    2
  };

  public static bool IsActive => GameManager.ActiveGameplay is WarManager;

  public static bool IsNpcModeEnable
  {
    get
    {
      return WarManager.IsActive && WarManager.WarKind == WarManager.EWarKind.Normal && WarManager.NpcModeEnable == (byte) 1;
    }
  }

  ~WarManager()
  {
  }

  protected override void UpdateNews(byte[] meg)
  {
    if (meg[0] != (byte) 2)
      return;
    this.CloseDrama();
  }

  protected override void UpdateNext(byte[] meg)
  {
    this.ClearUpdateDelegates();
    if ((UnityEngine.Object) this.controlPanel != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) ((Component) this.controlPanel).gameObject);
      this.controlPanel = (WarControlPanel) null;
    }
    AudioManager.Instance.RetrieveSFX();
    if ((UnityEngine.Object) this.movingSoundParentTrans != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.movingSoundParentTrans.gameObject);
      this.movingSoundParentTrans = (Transform) null;
    }
    if (this.castle != null)
    {
      this.castle.Destroy();
      this.castle = (WarCastle) null;
    }
    for (int index = 0; index < (int) this.attackerCount; ++index)
    {
      this.attackerArmies[index].Destroy();
      this.attackerArmies[index] = (ArmyGroup) null;
    }
    for (int index = 0; index < (int) this.defenserCount; ++index)
    {
      this.defenserArmies[index].Destroy();
      this.defenserArmies[index] = (ArmyGroup) null;
    }
    for (int index = 0; index < this.m_BrokenFO[0].Length; ++index)
    {
      this.m_BrokenFO[0][index].Destroy();
      this.m_BrokenFO[0][index] = (BrokenFO) null;
    }
    for (int index = 0; index < this.m_BrokenFO[1].Length; ++index)
    {
      this.m_BrokenFO[1][index].Destroy();
      this.m_BrokenFO[1][index] = (BrokenFO) null;
    }
    for (int index = 0; index < this.attackerHeroCache.Count; ++index)
      this.attackerHeroCache[index].Destroy();
    this.attackerHeroCache.Clear();
    for (int index = 0; index < this.defenserHeroCache.Count; ++index)
      this.defenserHeroCache[index].Destroy();
    this.defenserHeroCache.Clear();
    if (this.FOMgr != null)
    {
      this.FOMgr.Destroy();
      this.FOMgr = (FlyingObjectManager) null;
    }
    if ((UnityEngine.Object) this.LordCage != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.LordCage.gameObject);
      this.LordCage = (Transform) null;
      AssetManager.UnloadAssetBundle(this.CageKey);
    }
    SheetAnimInfo.Instance.DestroyAllMesh();
    if (Soldier.shadowABKey != 0)
    {
      AssetManager.UnloadAssetBundle(Soldier.shadowABKey);
      Soldier.shadowABKey = 0;
    }
    this.WCamera = (WarCamera) null;
    this.bstart = false;
    this.particleMgr.Clear();
    this.particleMgr = (WarParticleManager) null;
    if ((bool) (UnityEngine.Object) this.renderRoot)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.renderRoot.gameObject);
    AudioManager.Instance.SetSFXEnvironment(SFXKind.Normal);
    GUIManager.Instance.pDVMgr.EndWarClear();
    AssetManager.UnloadBigMap();
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Battle);
  }

  protected override void UpdateLoad(byte[] meg)
  {
    GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Battle);
    GameManager.RegisterObserver((byte) 1, (byte) 0, (IObserver) this);
    this.BSUtil = BSInvokeUtil.getInstance;
    DataManager instance = DataManager.Instance;
    if (WarManager.WarKind == WarManager.EWarKind.CoordTest)
    {
      WarManager.SetCoordTestWarData();
      WarManager.WarCoordIndex_Left = WarManager.CoordSimuIndex_Left;
      WarManager.WarCoordIndex_Right = WarManager.TroopKindSimuIndex_Right;
      WarManager.SetupCoordinate((int) WarManager.CoordSimuIndex_Left, (int) WarManager.TroopKindSimuIndex_Right);
    }
    else
      WarManager.SetupCoordinate((int) WarManager.WarCoordIndex_Left, (int) WarManager.WarCoordIndex_Right);
    this.BSUtil.InitCSSimulator(instance.War_RndSeed, instance.War_RndGap);
    if (NewbieManager.IsNewbie)
      WarManager.WarKind = WarManager.EWarKind.Newbie;
    this.deltaTime = 0.0f;
    this.particleMgr.Setup();
    if (WarManager.NpcModeEnable != (byte) 0)
      instance.War_MapKind = (ushort) 3;
    this.actionKind = !instance.bWarAttacker ? EPlayerActionKind.DEFENDER : EPlayerActionKind.ATTACKER;
    this.renderRoot = new GameObject("Root").transform;
    AssetManager.LoadMap(instance.War_MapKind, instance.War_MapTheme, this.particleMgr);
    LightmapManager.Instance.UpdateSceneAmbient();
    int num1 = (int) this.loadWarInfo();
    this.DramaTriggerFlag = DataManager.Instance.DramaTriggerFlag;
    if (instance.bWarAttacker)
    {
      for (int index = 0; index < (int) this.attackerCount; ++index)
        this.playerSideArmies[index] = this.attackerArmies[index];
      for (int index = 0; index < (int) this.defenserCount; ++index)
        this.enemySideArmies[index] = this.defenserArmies[index];
      this.enemySideArmies[16] = (ArmyGroup) this.castle;
      this.playerCount = this.attackerCount;
      this.enemyCount = this.defenserCount;
    }
    else
    {
      for (int index = 0; index < (int) this.defenserCount; ++index)
        this.playerSideArmies[index] = this.defenserArmies[index];
      this.playerSideArmies[16] = (ArmyGroup) this.castle;
      for (int index = 0; index < (int) this.attackerCount; ++index)
        this.enemySideArmies[index] = this.attackerArmies[index];
      this.playerCount = this.defenserCount;
      this.enemyCount = this.attackerCount;
    }
    if (this.attackerLord != null || this.defenserLord != null || this.attackerLordUnit != null || this.defenserLordUnit != null)
    {
      AssetBundle assetBundle = AssetManager.GetAssetBundle("Role/WarObj_001", out this.CageKey);
      if ((UnityEngine.Object) assetBundle != (UnityEngine.Object) null)
      {
        GameObject gameObject = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
        MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
        component.material = SheetAnimInfo.GetMaterial(ESheetMeshTexKind.WAR_BLUE);
        int num2 = 2 + LightmapManager.Instance.SceneLightmapSize;
        component.lightmapIndex = num2;
        this.LordCage = gameObject.transform;
        gameObject.SetActive(false);
      }
    }
    GameObject gameObject1 = new GameObject("Catcher");
    gameObject1.layer = 5;
    GUIManager.Instance.StretchTransform(gameObject1.AddComponent<RectTransform>());
    gameObject1.transform.SetParent(((Component) GUIManager.Instance.m_UICanvas).transform, false);
    gameObject1.transform.SetAsFirstSibling();
    this.controlPanel = gameObject1.AddComponent<WarControlPanel>();
    this.controlPanel.sprite = (Sprite) null;
    ((MaskableGraphic) this.controlPanel).material = GUIManager.Instance.m_IconSpriteAsset.GetMaterial();
    ((Graphic) this.controlPanel).color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    this.controlPanel.warManager = this;
    this.ScreenSize = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
    this.WCamera.initCamera(this.attackerArmies, (int) this.attackerCount, this.defenserArmies, (int) this.defenserCount);
    if (WarManager.WarKind == WarManager.EWarKind.CoordTest)
      this.WCamera.CoordCamMode = true;
    this.uiBattle = (UILegBattle) GUIManager.Instance.OpenMenu(EGUIWindow.UI_LegBattle, (int) this.actionKind, WarManager.WarKind != WarManager.EWarKind.CoordTest ? 0 : 1);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 0);
    this.NewbieWarFlag = !NewbieManager.IsNewbie ? (byte) 0 : (byte) 1;
    if (this.NewbieWarFlag != (byte) 0)
    {
      this.uiBattle.gameObject.SetActive(false);
      GUIManager.Instance.HideChatBox();
    }
    FSMManager.Instance.bIsBattleOver = false;
    Resources.UnloadUnusedAssets();
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
    AssetManager.Instance.AssetManagerState = AssetState.Ready;
    this.m_WarState = WarManager.WarKind == WarManager.EWarKind.CoordTest ? WarManager.WarState.CHANGE_COORD_MODE : WarManager.WarState.WAITING_FOR_START;
    AudioManager.Instance.SetSFXEnvironment(SFXKind.Legion);
    AudioManager.Instance.LoadAndPlayBGM(BGMType.LegionWar, (byte) 1);
    this.movingSoundParentTrans = new GameObject("SoundNode").transform;
    this.movingSoundParentTrans.position = new Vector3(55f, 0.0f, 15f);
    GUIManager.Instance.pDVMgr.BeginWarInitial();
    float fillAmount = (float) instance.CurWallHp / (float) instance.MaxWallHp;
    GUIManager.Instance.pDVMgr.SetBloodBarFillAmount(this.actionKind != EPlayerActionKind.ATTACKER ? 0 : 1, 16, fillAmount);
  }

  protected override void UpdateReady(byte[] meg)
  {
  }

  protected override void UpdateRun(byte[] meg)
  {
    if (this.m_WarState == WarManager.WarState.STOP)
      return;
    float smoothDeltaTime = Time.smoothDeltaTime;
    this.deltaTime += smoothDeltaTime;
    float num1 = 0.0f;
    if ((double) this.deltaTime >= 0.10000000149011612)
    {
      if (this.m_WarState == WarManager.WarState.WAITING_FOR_START)
      {
        if ((double) this.deltaTime >= 1.1000000238418579)
        {
          if (this.SubState == (byte) 0)
          {
            ushort num2 = (ushort) (this.DramaTriggerFlag & (uint) ushort.MaxValue);
            if (num2 != (ushort) 0)
            {
              ushort num3 = DataManager.Instance.pLeftLeaderData[0].HeroID;
              if (num3 == (ushort) 0)
                num3 = DataManager.Instance.RoleAttr.Head;
              GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, (int) num2, (int) num3);
              if ((UnityEngine.Object) this.controlPanel != (UnityEngine.Object) null)
                ((Component) this.controlPanel).gameObject.SetActive(false);
              this.checkPickHero(false);
              this.DramaTriggerFlag &= 4294901760U;
              this.bDramaWorking = true;
              this.SubState = (byte) 1;
              if (NewbieManager.IsNewbie)
                NewbieLog.Log(ENewbieLogKind.FORCE_1, (byte) 2);
            }
            else
              this.SubState = (byte) 2;
          }
          else if (this.SubState == (byte) 1 && !this.bDramaWorking)
            this.SubState = (byte) 2;
        }
        if (this.SubState == (byte) 2)
        {
          if (this.SiegeMode > 2)
          {
            if (this.nonCatapultsCount_Right != 0)
            {
              int siegeMode = this.SiegeMode;
              this.SiegeMode = 2;
              this.changeSiegeMode(siegeMode);
            }
            else
              this.m_WarState = WarManager.WarState.RUNNING;
          }
          else
            this.m_WarState = WarManager.WarState.RUNNING;
          this.deltaTime = 0.0f;
        }
      }
      else if (this.m_WarState != WarManager.WarState.CHANGE_COORD_MODE)
      {
        if (this.m_WarState == WarManager.WarState.RUNNING)
        {
          this.m_WarResult = (EWarResult) this.BSUtil.updateWarData(this.m_ui32Tcik, this.RecvBufferLeft, this.RecvBufferRight);
          ++this.m_ui32Tcik;
          this.deltaTime -= 0.1f;
          num1 = Mathf.Min(0.1f, this.deltaTime);
          this.fixMoveDeltaTime = num1;
          this.canMoveDeltaTime = 0.1f;
          if (this.NewbieWarFlag == (byte) 0 || this.m_ui32Tcik <= 140U)
          {
            this.decodeSimuPackage(this.RecvBufferLeft, this.RecvBufferRight);
          }
          else
          {
            if (this.NewbieWarFlag == (byte) 1)
            {
              this.NewbieWarFlag = (byte) 2;
              this.DramaTriggerFlag = 0U;
              GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, 2, 1);
              if ((UnityEngine.Object) this.controlPanel != (UnityEngine.Object) null)
                ((Component) this.controlPanel).gameObject.SetActive(false);
              this.checkPickHero(false);
              this.bDramaWorking = true;
              NewbieLog.Log(ENewbieLogKind.FORCE_1, (byte) 3);
            }
            this.m_WarResult = EWarResult.NONE;
          }
          if (this.m_bSkillDirty)
          {
            this.UpdateSkillLightmap();
            this.m_bSkillDirty = false;
          }
          if (this.SoundDirtyFlag != 0U)
          {
            this.CheckSound();
            this.SoundDirtyFlag = 0U;
          }
          if (DataManager.Instance.bWarMoraleSpecialCale && this.m_ui32Tcik > 150U && this.m_ui32Tcik % 10U == 0U)
          {
            DataManager.Instance.WarMorale[0] -= this.MoraleStep;
            this.UIUpdateFlag |= 1;
          }
          this.checkResult(false);
          if (this.UIUpdateFlag != 0)
          {
            if ((this.UIUpdateFlag & 1) != 0)
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 1);
            if ((this.UIUpdateFlag & 2) != 0)
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 1, 1);
            if ((this.UIUpdateFlag & 4) != 0)
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 1, 2);
            this.UIUpdateFlag = 0;
          }
        }
        else if (this.m_WarState != WarManager.WarState.CHANGING_SIEGE_MODE)
        {
          if (this.m_WarState == WarManager.WarState.CASTLE_DESTROYING)
          {
            if (this.castle.State == ArmyGroup.EGROUPSTATE.DESTROYED)
            {
              this.castle.groupRoot.gameObject.SetActive(false);
              if (!this.checkResult())
                this.m_WarState = WarManager.WarState.RUNNING;
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 3);
              this.deltaTime = 0.0f;
              for (int index = 0; index < this.attackerArmies.Length; ++index)
              {
                if (this.attackerArmies[index] != null && this.attackerArmies[index].HasHeroDisplay)
                  this.attackerArmies[index].setLordAnimEnable(true);
              }
              for (int index = 0; index < this.defenserArmies.Length; ++index)
              {
                if (this.defenserArmies[index] != null && this.defenserArmies[index].HasHeroDisplay)
                  this.defenserArmies[index].setLordAnimEnable(true);
              }
              this.setOutsideHeroAnimEnable(true);
            }
          }
          else if (this.m_WarState == WarManager.WarState.FINISHING)
          {
            this.m_SkillWorkingList = 0UL;
            this.UpdateSkillLightmap();
            GUIManager.Instance.pDVMgr.NextWar();
            this.checkPickHero(false);
            if (this.AttackSoundKey != (byte) 21)
              this.audioMgr.StopSFX(this.AttackSoundKey);
            if (this.MovingSoundKey != (byte) 21)
              this.audioMgr.StopSFX(this.MovingSoundKey);
            for (int index = 0; index < this.attackerArmies.Length; ++index)
            {
              if (this.attackerArmies[index] != null && this.attackerArmies[index].HasHeroDisplay)
                this.attackerArmies[index].setLordAnimEnable(true);
            }
            for (int index = 0; index < this.defenserArmies.Length; ++index)
            {
              if (this.defenserArmies[index] != null && this.defenserArmies[index].HasHeroDisplay)
                this.defenserArmies[index].setLordAnimEnable(true);
            }
            this.setOutsideHeroAnimEnable(true);
            if (this.attackerLord != null && this.m_WarResult == EWarResult.LOSE)
            {
              if (DataManager.Instance.War_LordCapture == (byte) 0)
              {
                this.attackerLord.LordRunAway(true);
                GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 2);
              }
            }
            else if (this.defenserLord != null && this.m_WarResult == EWarResult.WIN)
            {
              if (DataManager.Instance.War_LordCapture == (byte) 0)
              {
                this.defenserLord.LordRunAway(false);
                GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 2, 1);
              }
            }
            else
            {
              for (int index = 0; index < (int) this.attackerCount; ++index)
              {
                if (this.attackerArmies[index].CurHP > 0)
                  this.attackerArmies[index].State = ArmyGroup.EGROUPSTATE.IDLE_WITHOUT_CLUMP;
              }
              for (int index = 0; index < (int) this.defenserCount; ++index)
              {
                if (this.defenserArmies[index].CurHP > 0)
                  this.defenserArmies[index].State = ArmyGroup.EGROUPSTATE.IDLE_WITHOUT_CLUMP;
              }
            }
            this.SubState = (byte) 1;
            this.deltaTime = 0.0f;
            this.m_WarState = WarManager.WarState.RETREAT;
          }
          else if (this.m_WarState == WarManager.WarState.RETREAT)
          {
            if (this.SubState == (byte) 0)
            {
              if ((double) this.deltaTime >= 2.0)
                this.SubState = (byte) 1;
            }
            else
            {
              if (this.m_WarResult == EWarResult.WIN)
              {
                if (DataManager.Instance.War_LordCapture != (byte) 0 && this.defenserLordUnit != null)
                {
                  for (int index = 0; index < this.defenserHeroCache.Count; ++index)
                  {
                    this.defenserHeroCache[index].LordAnimSetting((byte) 2);
                    if (this.defenserHeroCache[index].IsLord)
                      this.defenserHeroCache[index].PlayAnim(ESheetMeshAnim.die, SAWrapMode.Loop, true, false, false);
                    else
                      this.defenserHeroCache[index].FSMController = FSMManager.Instance.getState(EStateName.DEFENSER_RUN_AWAY);
                  }
                  int num4 = 0;
                  for (int index = 0; index < (int) this.attackerCount; ++index)
                  {
                    if (this.attackerArmies[index].GroupKind != EGroupKind.Catapults)
                    {
                      this.attackerArmies[index].SoldierTarget = this.defenserLordUnit;
                      this.attackerArmies[index].State = ArmyGroup.EGROUPSTATE.GO_CAPTIVING;
                      num4 += this.attackerArmies[index].CurrentSoldierCount;
                    }
                  }
                  this.CageState = (byte) 1;
                  FSMManager.Instance.MaxCaptiver = num4;
                  FSMManager.Instance.CaptivingCount = 0;
                  this.CageTargetPos = this.defenserLordUnit.transform.position;
                  this.WCamera.SetTargetPosition(this.CageTargetPos, fSpeed: 1f);
                  this.SubState = (byte) 3;
                }
                else
                {
                  if (this.defenserLord == null && this.defenserAliveCount > (byte) 0)
                    this.uiBattle.AddCenterMsg((ushort) 1, (byte) 0);
                  if (this.SiegeMode > 1)
                  {
                    for (int index = 0; index < (int) this.attackerCount; ++index)
                    {
                      if (this.attackerArmies[index].GroupKind != EGroupKind.Catapults)
                        this.attackerArmies[index].State = ArmyGroup.EGROUPSTATE.VICTORY;
                    }
                    for (int index = 0; index < (int) this.defenserCount; ++index)
                      this.defenserArmies[index].State = ArmyGroup.EGROUPSTATE.DEFENSER_RUN_AWAY;
                    for (int index = 0; index < this.defenserHeroCache.Count; ++index)
                    {
                      this.defenserHeroCache[index].LordAnimSetting((byte) 2);
                      this.defenserHeroCache[index].FSMController = FSMManager.Instance.getState(EStateName.DEFENSER_RUN_AWAY);
                    }
                  }
                  else
                  {
                    for (int index = 0; index < (int) this.attackerCount; ++index)
                    {
                      if (this.attackerArmies[index].GroupKind != EGroupKind.Catapults)
                        this.attackerArmies[index].State = ArmyGroup.EGROUPSTATE.ATTACKER_CHASING;
                    }
                    for (int index = 0; index < (int) this.defenserCount; ++index)
                      this.defenserArmies[index].State = ArmyGroup.EGROUPSTATE.DEFENSER_RUN_AWAY;
                    for (int index = 0; index < this.defenserHeroCache.Count; ++index)
                    {
                      this.defenserHeroCache[index].LordAnimSetting((byte) 2);
                      this.defenserHeroCache[index].FSMController = FSMManager.Instance.getState(EStateName.DEFENSER_RUN_AWAY);
                    }
                    if (this.nonCatapultsCount_Left != 0)
                      this.WCamera.SetTargetPosition(new Vector3(80f, 0.0f, 15f), fSpeed: 1.4f);
                  }
                  this.SubState = (byte) 0;
                }
              }
              else if (this.m_WarResult == EWarResult.LOSE)
              {
                if (this.attackerLordUnit != null && DataManager.Instance.War_LordCapture != (byte) 0)
                {
                  for (int index = 0; index < this.attackerHeroCache.Count; ++index)
                  {
                    this.attackerHeroCache[index].LordAnimSetting((byte) 2);
                    if (this.attackerHeroCache[index].IsLord)
                      this.attackerHeroCache[index].PlayAnim(ESheetMeshAnim.die, SAWrapMode.Loop, true, false, false);
                    else
                      this.attackerHeroCache[index].FSMController = FSMManager.Instance.getState(EStateName.ATTACKER_RUN_AWAY);
                  }
                  if (this.SiegeMode < 4 && this.SiegeMode > 1)
                  {
                    int num5 = 0;
                    for (int index = 0; index < (int) this.defenserCount; ++index)
                    {
                      if (this.defenserArmies[index].GroupKind != EGroupKind.Catapults)
                      {
                        this.defenserArmies[index].SoldierTarget = this.attackerLordUnit;
                        this.defenserArmies[index].CommonFlag |= 1U;
                        this.defenserArmies[index].State = this.defenserArmies[index].GroupKind == EGroupKind.Archer || this.SiegeMode != 3 ? (this.defenserArmies[index].GroupKind != EGroupKind.Archer ? ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN : ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL) : ArmyGroup.EGROUPSTATE.GO_CAPTIVING;
                        num5 += this.defenserArmies[index].CurrentSoldierCount;
                      }
                    }
                    FSMManager.Instance.MaxCaptiver = num5;
                    this.SubState = (byte) 1;
                  }
                  else
                  {
                    int num6 = 0;
                    for (int index = 0; index < (int) this.defenserCount; ++index)
                    {
                      if (this.defenserArmies[index].GroupKind != EGroupKind.Catapults)
                      {
                        this.defenserArmies[index].SoldierTarget = this.attackerLordUnit;
                        this.defenserArmies[index].State = ArmyGroup.EGROUPSTATE.GO_CAPTIVING;
                        num6 += this.defenserArmies[index].CurrentSoldierCount;
                      }
                    }
                    FSMManager.Instance.MaxCaptiver = num6;
                    this.SubState = (byte) 3;
                  }
                  this.CageState = (byte) 1;
                  FSMManager.Instance.CaptivingCount = 0;
                  this.CageTargetPos = this.attackerLordUnit.transform.position;
                  this.WCamera.SetTargetPosition(this.CageTargetPos, fSpeed: 1f);
                }
                else
                {
                  if (this.attackerLord == null && this.attackerAliveCount > (byte) 0)
                    this.uiBattle.AddCenterMsg((ushort) 0, (byte) 0);
                  if (this.SiegeMode > 1)
                  {
                    for (int index = 0; index < (int) this.defenserCount; ++index)
                    {
                      if (this.defenserArmies[index].GroupKind != EGroupKind.Catapults)
                        this.defenserArmies[index].State = ArmyGroup.EGROUPSTATE.VICTORY;
                    }
                    for (int index = 0; index < (int) this.attackerCount; ++index)
                      this.attackerArmies[index].State = ArmyGroup.EGROUPSTATE.ATTACKER_RUN_AWAY;
                    for (int index = 0; index < this.attackerHeroCache.Count; ++index)
                    {
                      this.attackerHeroCache[index].LordAnimSetting((byte) 2);
                      this.attackerHeroCache[index].FSMController = FSMManager.Instance.getState(EStateName.ATTACKER_RUN_AWAY);
                    }
                    if (this.SiegeMode == 2)
                    {
                      float num7 = 0.0f;
                      int num8 = 0;
                      for (int index = 0; index < (int) this.defenserCount; ++index)
                      {
                        if (this.defenserArmies[index].GroupKind != EGroupKind.Catapults)
                        {
                          num7 += this.defenserArmies[index].groupRoot.position.x;
                          ++num8;
                        }
                      }
                      if (num8 != 0)
                        this.WCamera.SetTargetPosition(new Vector3(num7 / (float) num8, 0.0f, 15f), fSpeed: 1f);
                      else
                        this.WCamera.SetTargetPosition(new Vector3(55f, 0.0f, 15f), fSpeed: 1f);
                    }
                  }
                  else
                  {
                    Vector3 zero = Vector3.zero;
                    int num9 = 0;
                    for (int index = 0; index < (int) this.defenserCount; ++index)
                    {
                      if (this.defenserArmies[index].GroupKind != EGroupKind.Catapults)
                      {
                        this.defenserArmies[index].State = ArmyGroup.EGROUPSTATE.DEFENSER_CHASING;
                        if (this.defenserArmies[index].CurHP > 0)
                        {
                          zero += this.defenserArmies[index].groupRoot.position;
                          ++num9;
                        }
                      }
                    }
                    for (int index = 0; index < (int) this.attackerCount; ++index)
                      this.attackerArmies[index].State = ArmyGroup.EGROUPSTATE.ATTACKER_RUN_AWAY;
                    for (int index = 0; index < this.attackerHeroCache.Count; ++index)
                    {
                      this.attackerHeroCache[index].LordAnimSetting((byte) 2);
                      this.attackerHeroCache[index].FSMController = FSMManager.Instance.getState(EStateName.ATTACKER_RUN_AWAY);
                    }
                    if (num9 != 0)
                      this.WCamera.SetTargetPosition(zero / (float) num9, fSpeed: 1f);
                  }
                  this.SubState = (byte) 0;
                }
              }
              this.audioMgr.PlaySFXLoop((ushort) 20012, out this.MovingSoundKey, this.movingSoundParentTrans);
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 3);
              this.deltaTime = 0.0f;
              this.m_WarState = WarManager.WarState.WAITTING_FOR_VICTORY;
            }
          }
          else if (this.m_WarState == WarManager.WarState.WAITTING_FOR_VICTORY)
          {
            if (this.SubState == (byte) 0)
            {
              if ((double) this.deltaTime >= 2.5)
              {
                this.deltaTime = 0.0f;
                this.SubState = (byte) 3;
              }
            }
            else if (this.SubState == (byte) 2)
            {
              int num10 = 0;
              for (int index = 0; index < (int) this.defenserCount; ++index)
              {
                if (this.defenserArmies[index].GroupKind != EGroupKind.Catapults && this.defenserArmies[index].State != ArmyGroup.EGROUPSTATE.GO_CAPTIVING)
                {
                  if (((int) this.defenserArmies[index].CommonFlag & 1) != 0)
                    this.defenserArmies[index].State = ArmyGroup.EGROUPSTATE.GO_CAPTIVING;
                }
                else
                  ++num10;
              }
              if (num10 >= (int) this.defenserCount)
              {
                this.deltaTime = 0.0f;
                this.SubState = (byte) 3;
              }
            }
            else if (this.SubState == (byte) 3)
            {
              ushort num11 = (ushort) (this.DramaTriggerFlag >> 16 & (uint) ushort.MaxValue);
              if (num11 != (ushort) 0)
              {
                ushort num12 = DataManager.Instance.pLeftLeaderData[0].HeroID;
                if (num12 == (ushort) 0)
                  num12 = DataManager.Instance.RoleAttr.Head;
                GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, (int) num11, (int) num12);
                if ((UnityEngine.Object) this.controlPanel != (UnityEngine.Object) null)
                  ((Component) this.controlPanel).gameObject.SetActive(false);
                this.checkPickHero(false);
                this.DramaTriggerFlag = 0U;
                this.bDramaWorking = true;
                this.SubState = (byte) 4;
              }
              else
                this.SubState = (byte) 5;
            }
            else if (this.SubState == (byte) 4)
            {
              if (!this.bDramaWorking)
                this.SubState = (byte) 5;
            }
            else if (this.SubState == (byte) 5)
            {
              if (this.CageState == (byte) 0)
              {
                int num13 = this.m_WarResult != EWarResult.WIN ? (this.actionKind != EPlayerActionKind.ATTACKER ? 0 : 2) : (this.actionKind != EPlayerActionKind.ATTACKER ? 2 : 0);
                this.PlayCheerSound();
                GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 4, num13);
              }
              this.SubState = (byte) 6;
            }
          }
        }
      }
    }
    float moveDeltaTime = smoothDeltaTime;
    if (this.m_WarState == WarManager.WarState.RUNNING)
    {
      float a;
      if ((double) this.fixMoveDeltaTime + (double) smoothDeltaTime > 1.0)
      {
        a = Mathf.Max(0.0f, 1f - this.fixMoveDeltaTime) + num1;
      }
      else
      {
        this.fixMoveDeltaTime += smoothDeltaTime;
        a = smoothDeltaTime + num1;
      }
      moveDeltaTime = Mathf.Min(a, 0.1f);
      if ((double) this.canMoveDeltaTime <= 0.0)
        moveDeltaTime = 0.0f;
      else if ((double) this.canMoveDeltaTime < (double) moveDeltaTime)
      {
        moveDeltaTime = this.canMoveDeltaTime;
        this.canMoveDeltaTime = 0.0f;
      }
      else
        this.canMoveDeltaTime -= moveDeltaTime;
    }
    if (this.castle == null || this.castle != null && this.castle.State != ArmyGroup.EGROUPSTATE.DESTROYING)
    {
      if (this.m_WarState == WarManager.WarState.CHANGING_SIEGE_MODE)
      {
        int num14 = 0;
        for (int index = 0; index < (int) this.defenserCount; ++index)
        {
          if (this.defenserArmies[index].State == ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL || this.defenserArmies[index].State == ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN)
          {
            if (((int) this.defenserArmies[index].CommonFlag & 1) != 0)
              ++num14;
            this.defenserArmies[index].Update(smoothDeltaTime, moveDeltaTime);
          }
        }
        if (num14 == 0)
        {
          for (int index = 0; index < this.attackerArmies.Length; ++index)
          {
            if (this.attackerArmies[index] != null && this.attackerArmies[index].HasHeroDisplay)
              this.attackerArmies[index].setLordAnimEnable(true);
          }
          for (int index = 0; index < this.defenserArmies.Length; ++index)
          {
            if (this.defenserArmies[index] != null && this.defenserArmies[index].HasHeroDisplay)
              this.defenserArmies[index].setLordAnimEnable(true);
          }
          this.setOutsideHeroAnimEnable(true);
          if (!this.checkResult())
            this.m_WarState = WarManager.WarState.RUNNING;
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 3);
          this.deltaTime = 0.0f;
          if (this.MovingSoundKey != (byte) 21)
          {
            this.audioMgr.StopSFX(this.MovingSoundKey);
            this.MovingSoundKey = (byte) 21;
          }
        }
      }
      else
      {
        for (int index = 0; index < (int) this.attackerCount; ++index)
          this.attackerArmies[index].Update(smoothDeltaTime, moveDeltaTime);
        for (int index = 0; index < (int) this.defenserCount; ++index)
          this.defenserArmies[index].Update(smoothDeltaTime, moveDeltaTime);
        this.FOMgr.Update(smoothDeltaTime);
        for (int index = 0; index < this.m_BrokenFO[0].Length; ++index)
          this.m_BrokenFO[0][index].Update(smoothDeltaTime);
        for (int index = 0; index < this.m_BrokenFO[1].Length; ++index)
          this.m_BrokenFO[1][index].Update(smoothDeltaTime);
        if (this.bUpdateOutsideHero)
        {
          for (int index = 0; index < this.attackerHeroCache.Count; ++index)
          {
            if (this.attackerHeroCache[index].FSMController != null)
              this.attackerHeroCache[index].FSMController.Update((Soldier) this.attackerHeroCache[index], (ArmyGroup) null, smoothDeltaTime);
          }
          for (int index = 0; index < this.defenserHeroCache.Count; ++index)
          {
            if (this.defenserHeroCache[index].FSMController != null)
              this.defenserHeroCache[index].FSMController.Update((Soldier) this.defenserHeroCache[index], (ArmyGroup) null, smoothDeltaTime);
          }
        }
      }
    }
    if (this.castle != null)
      this.castle.Update(smoothDeltaTime, moveDeltaTime);
    if (this.CageState != (byte) 0)
      this.CageUpdate(smoothDeltaTime);
    this.WCamera.updateCamera(this.attackerArmies, (int) this.attackerCount, this.defenserArmies, (int) this.defenserCount);
    if ((UnityEngine.Object) this.HintTrans != (UnityEngine.Object) null)
    {
      Vector2 vector2 = (Vector2) Camera.main.WorldToScreenPoint(this.PickedTrans.position + new Vector3(0.0f, 10f, 0.0f)) / GUIManager.Instance.m_UICanvas.scaleFactor;
      if (GUIManager.Instance.IsArabic)
      {
        RectTransform canvasRt = GUIManager.Instance.pDVMgr.CanvasRT;
        if ((UnityEngine.Object) canvasRt != (UnityEngine.Object) null)
          vector2.x += (float) (((double) canvasRt.sizeDelta.x * 0.5 - (double) vector2.x) * 2.0);
      }
      this.HintTrans.anchoredPosition = vector2;
      this.HintTimer += smoothDeltaTime;
      if ((double) this.HintTimer <= 5.0)
      {
        if (this.HintHeroNo != 0U)
        {
          ushort heroID = 0;
          bool bLord = false;
          ushort stringid = this.checkArmyGroupHintState(this.HintHeroNo, out heroID, out bLord);
          if ((int) stringid != (int) this.HintStrID)
          {
            this.uiBattle.SetHint(true, bLord, heroID, stringid);
            this.HintStrID = stringid;
          }
        }
      }
      else
        this.checkPickHero(false);
    }
    this.particleMgr.Update();
  }

  private bool checkResult(bool bToFinishing = true)
  {
    if (this.m_WarResult != EWarResult.WIN && this.m_WarResult != EWarResult.LOSE)
      return false;
    if (bToFinishing || this.m_WarState == WarManager.WarState.RUNNING)
      this.m_WarState = WarManager.WarState.FINISHING;
    FSMManager.Instance.bIsBattleOver = true;
    if (this.m_WarResult == EWarResult.LOSE)
    {
      DataManager.Instance.WarMorale[0] = 0;
      this.UIUpdateFlag |= 1;
    }
    else
    {
      DataManager.Instance.WarMorale[1] = 0;
      this.UIUpdateFlag |= 2;
    }
    return true;
  }

  private void decodeSimuPackage(byte[] RecvBufferLeft, byte[] RecvBufferRight)
  {
    this.decodeSimuPackage(RecvBufferLeft, (byte) 0);
    this.decodeSimuPackage(RecvBufferRight, (byte) 1);
  }

  private void decodeSimuPackage(byte[] RecvBuffer, byte Side)
  {
    byte num1 = RecvBuffer[0];
    if (num1 == (byte) 0)
      return;
    int startIdx1 = 1;
    for (int index1 = 0; index1 < (int) num1; ++index1)
    {
      byte index2 = RecvBuffer[startIdx1];
      int index3 = startIdx1 + 1;
      byte index4 = RecvBuffer[index3];
      int index5 = index3 + 1;
      byte num2 = RecvBuffer[index5];
      startIdx1 = index5 + 1;
      ArmyGroup armyGroup1 = this.getArmyGroup(Side, index2, index4);
      if (armyGroup1 == null)
      {
        Debug.LogError((object) "null Group");
      }
      else
      {
        switch (num2)
        {
          case 0:
            byte Kind1 = RecvBuffer[startIdx1];
            int index6 = startIdx1 + 1;
            byte Idx1 = RecvBuffer[index6];
            startIdx1 = index6 + 1;
            if (index2 == (byte) 0 || index2 == (byte) 2)
            {
              ArmyGroup armyGroup2 = this.getArmyGroup(Side != (byte) 0 ? (byte) 0 : (byte) 1, Kind1, Idx1);
              armyGroup1.Attack(armyGroup2, true, (byte) 0);
              continue;
            }
            continue;
          case 1:
            byte Kind2 = RecvBuffer[startIdx1];
            int index7 = startIdx1 + 1;
            byte Idx2 = RecvBuffer[index7];
            int startIdx2 = index7 + 1;
            float posX = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx2);
            int startIdx3 = startIdx2 + 4;
            float posY = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx3);
            startIdx1 = startIdx3 + 4;
            ArmyGroup armyGroup3 = this.getArmyGroup(Side != (byte) 0 ? (byte) 0 : (byte) 1, Kind2, Idx2);
            armyGroup1.setPosition(posX, posY);
            armyGroup1.Move(armyGroup3);
            if (index2 != (byte) 4)
              this.setSkillWorkingList(Side, index2, index4, false);
            if ((index2 == (byte) 0 || index2 == (byte) 2) && this.MovingSoundKey >= (byte) 21)
            {
              if (this.AttackSoundKey != (byte) 21)
              {
                byte num3 = 0;
                for (int Idx3 = 0; Idx3 < 4; ++Idx3)
                {
                  ArmyGroup armyGroup4 = this.getArmyGroup((byte) 0, (byte) 0, (byte) Idx3);
                  if (armyGroup4 != null && armyGroup4.CurHP > 0 && (armyGroup4.State == ArmyGroup.EGROUPSTATE.FIGHT || armyGroup4.State == ArmyGroup.EGROUPSTATE.FIGHT_IMMEDIATE))
                    ++num3;
                  ArmyGroup armyGroup5 = this.getArmyGroup((byte) 0, (byte) 2, (byte) Idx3);
                  if (armyGroup5 != null && armyGroup5.CurHP > 0 && (armyGroup5.State == ArmyGroup.EGROUPSTATE.FIGHT || armyGroup5.State == ArmyGroup.EGROUPSTATE.FIGHT_IMMEDIATE))
                    ++num3;
                  ArmyGroup armyGroup6 = this.getArmyGroup((byte) 1, (byte) 0, (byte) Idx3);
                  if (armyGroup6 != null && armyGroup6.CurHP > 0 && (armyGroup6.State == ArmyGroup.EGROUPSTATE.FIGHT || armyGroup6.State == ArmyGroup.EGROUPSTATE.FIGHT_IMMEDIATE))
                    ++num3;
                  ArmyGroup armyGroup7 = this.getArmyGroup((byte) 1, (byte) 2, (byte) Idx3);
                  if (armyGroup7 != null && armyGroup7.CurHP > 0 && (armyGroup7.State == ArmyGroup.EGROUPSTATE.FIGHT || armyGroup7.State == ArmyGroup.EGROUPSTATE.FIGHT_IMMEDIATE))
                    ++num3;
                }
                if (num3 <= (byte) 0)
                {
                  this.audioMgr.StopSFX(this.AttackSoundKey);
                  this.AttackSoundKey = (byte) 21;
                }
                else
                  continue;
              }
              float num4 = GameConstants.DistanceSquare(this.mainCamera.position, armyGroup1.groupRoot.position);
              if (!this.movingDist_Sound.HasValue || (double) num4 < (double) this.movingDist_Sound.Value)
              {
                this.movingDist_Sound = new float?(num4);
                this.movingSoundParent = armyGroup1;
                this.SoundDirtyFlag |= 1U;
                continue;
              }
              continue;
            }
            continue;
          case 2:
            byte Kind3 = RecvBuffer[startIdx1];
            int index8 = startIdx1 + 1;
            byte Idx4 = RecvBuffer[index8];
            int startIdx4 = index8 + 1;
            int skillID1 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx4);
            startIdx1 = startIdx4 + 2;
            ArmyGroup armyGroup8 = this.getArmyGroup(Side != (byte) 0 ? (byte) 0 : (byte) 1, Kind3, Idx4);
            if (index2 == (byte) 4)
            {
              armyGroup1.Attack(armyGroup8, param: index4);
              continue;
            }
            byte param = 0;
            if (skillID1 > 7)
            {
              armyGroup1.PlaySkill((ushort) skillID1, armyGroup8);
              param = (byte) 1;
            }
            else
              armyGroup1.Attack(armyGroup8, param: param);
            if (param == (byte) 1)
            {
              switch (index2)
              {
                case 3:
                  int curLightmapIdx = 1 + LightmapManager.Instance.SceneLightmapSize;
                  armyGroup1.resetLightmap(curLightmapIdx);
                  break;
                case 4:
                  break;
                default:
                  this.setSkillWorkingList(Side, index2, index4, true);
                  break;
              }
            }
            if ((index2 == (byte) 0 || index2 == (byte) 2) && this.AttackSoundKey >= (byte) 21)
            {
              if (this.MovingSoundKey < (byte) 21)
              {
                this.audioMgr.StopSFX(this.MovingSoundKey);
                this.MovingSoundKey = (byte) 21;
              }
              float num5 = GameConstants.DistanceSquare(this.mainCamera.position, armyGroup1.groupRoot.position);
              if (!this.attackDist_Sound.HasValue || (double) num5 < (double) this.attackDist_Sound.Value)
              {
                this.attackDist_Sound = new float?(num5);
                this.attackSoundParent = armyGroup1;
                this.SoundDirtyFlag |= 2U;
                continue;
              }
              continue;
            }
            continue;
          case 3:
            byte num6 = RecvBuffer[startIdx1];
            int index9 = startIdx1 + 1;
            byte num7 = RecvBuffer[index9];
            int startIdx5 = index9 + 1;
            int InKey = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx5);
            int startIdx6 = startIdx5 + 2;
            int val = GameConstants.ConvertBytesToInt(RecvBuffer, startIdx6);
            int index10 = startIdx6 + 4;
            byte num8 = RecvBuffer[index10];
            startIdx1 = index10 + 1;
            armyGroup1.GotHurt = val;
            if (index2 != (byte) 4)
              this.CaleWarMorale(Side, (uint) val);
            switch (num6)
            {
              case 1:
                ArmyGroup armyGroup9 = this.getArmyGroup(Side != (byte) 0 ? (byte) 0 : (byte) 1, num6, num7);
                int num9 = UnityEngine.Random.Range(1, armyGroup9.CurrentSoldierCount);
                int num10 = num9 <= 5 ? num9 : 5;
                ushort EffID = 2001;
                if (armyGroup9.GroupKind == EGroupKind.Catapults)
                  EffID = (ushort) 2005;
                if (armyGroup9.GroupKind == EGroupKind.Archer && armyGroup9.Tier == (byte) 4)
                  EffID = (ushort) 2006;
                if (index2 == (byte) 4)
                {
                  for (int index11 = 0; index11 < num10; ++index11)
                  {
                    if (armyGroup9.soldiers[index11].hitParticleCount > (byte) 0)
                    {
                      this.particleMgr.Spawn(EffID, (Transform) null, armyGroup9.soldiers[index11].hitParticlePos[0], 1f, true, false);
                      if (armyGroup9.soldiers[index11].hitParticleCount == (byte) 2)
                        armyGroup9.soldiers[index11].hitParticlePos[0] = armyGroup9.soldiers[index11].hitParticlePos[1];
                      --armyGroup9.soldiers[index11].hitParticleCount;
                    }
                  }
                  break;
                }
                if (armyGroup9.soldiers != null)
                {
                  for (int index12 = 0; index12 < num10; ++index12)
                  {
                    if (armyGroup9.soldiers[index12].Target != null)
                      armyGroup9.soldiers[index12].Target.ParticleFlag = (int) EffID <= (int) armyGroup9.soldiers[index12].Target.ParticleFlag ? armyGroup9.soldiers[index12].Target.ParticleFlag : EffID;
                  }
                  break;
                }
                break;
              case 3:
                ArmyGroup armyGroup10 = this.getArmyGroup(Side != (byte) 0 ? (byte) 0 : (byte) 1, num6, num7);
                byte idx = this.brokenFO_Index[(int) armyGroup10.Tier - 1];
                if (index2 == (byte) 4)
                {
                  if (armyGroup10.soldiers[0].hitParticleCount > (byte) 0)
                  {
                    this.playBrokenFO(idx, armyGroup10.soldiers[0].hitParticlePos[0], Vector3.left);
                    this.particleMgr.Spawn((ushort) 2005, (Transform) null, armyGroup10.soldiers[0].hitParticlePos[0], 1f, true, false);
                    if (armyGroup10.soldiers[0].hitParticleCount == (byte) 2)
                      armyGroup10.soldiers[0].hitParticlePos[0] = armyGroup10.soldiers[0].hitParticlePos[1];
                    --armyGroup10.soldiers[0].hitParticleCount;
                  }
                }
                else if (armyGroup1.soldiers != null)
                {
                  Vector3 hitPoint = armyGroup1.soldiers[0].hitPoint;
                  this.playBrokenFO(idx, hitPoint, armyGroup1.soldiers[0].transform.rotation);
                  this.particleMgr.Spawn((ushort) 2005, (Transform) null, hitPoint, 1f, true, false);
                }
                float num11 = GameConstants.DistanceSquare(this.mainCamera.position, armyGroup1.groupRoot.position);
                if (!this.stoneHitDist_Sound.HasValue || (double) num11 < (double) this.stoneHitDist_Sound.Value)
                {
                  this.stoneHitDist_Sound = new float?(num11);
                  this.stoneHitSoundParent = armyGroup1;
                  this.SoundDirtyFlag |= 8U;
                  break;
                }
                break;
              case 4:
                switch (num7)
                {
                  case 5:
                    this.castle.cacheTrapHitPos((byte) 0, armyGroup1);
                    break;
                  case 6:
                    this.castle.cacheTrapHitPos((byte) 1, armyGroup1);
                    break;
                  default:
                    int currentSoldierCount = armyGroup1.CurrentSoldierCount;
                    for (int index13 = 0; index13 < 5; ++index13)
                    {
                      if (index13 < armyGroup1.CurrentSoldierCount)
                        armyGroup1.soldiers[index13].ParticleFlag = (ushort) 1;
                    }
                    break;
                }
                break;
            }
            if (InKey > 7)
            {
              Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey((ushort) InKey);
              if ((int) recordByKey.SkillKey == InKey && recordByKey.HitParticle != (ushort) 0)
              {
                if (index2 != (byte) 4)
                {
                  Vector3 position = armyGroup1.soldiers == null ? armyGroup1.heroSoldier.transform.position : armyGroup1.soldiers[0].transform.position;
                  for (int index14 = 1; index14 < armyGroup1.CurrentSoldierCount; ++index14)
                    position += armyGroup1.soldiers[index14].transform.position;
                  if (armyGroup1.CurrentSoldierCount != 0)
                    position /= (float) armyGroup1.CurrentSoldierCount;
                  GameObject gameObject = this.particleMgr.Spawn(recordByKey.HitParticle, (Transform) null, position, 1f, true, false);
                  if (Side == (byte) 0 && (UnityEngine.Object) gameObject != (UnityEngine.Object) null)
                    gameObject.transform.Rotate(0.0f, 180f, 0.0f);
                }
                else
                {
                  Vector3 position = armyGroup1.groupRoot.position with
                  {
                    x = 50f
                  };
                  this.particleMgr.Spawn(recordByKey.HitParticle, (Transform) null, position, 1f, true, false);
                }
              }
              armyGroup1.OnceFlag |= 2U;
              ArmyGroup armyGroup11 = this.getArmyGroup(Side != (byte) 0 ? (byte) 0 : (byte) 1, num6, num7);
              armyGroup1.AttackBy = armyGroup11;
              if (this.actionKind == EPlayerActionKind.ATTACKER && Side == (byte) 1 || this.actionKind == EPlayerActionKind.DEFENDER && Side == (byte) 0)
                this.WCamera.Shake = true;
            }
            if (index2 != (byte) 4)
            {
              long num12 = DataManager.Instance.NowValue_War[(int) Side] - (long) val;
              DataManager.Instance.NowValue_War[(int) Side] = num12 >= 0L ? num12 : 0L;
              this.UIUpdateFlag |= Side != (byte) 0 ? 2 : 1;
              byte[,] numArray = Side != (byte) 0 ? this.defenserArmiesMap : this.attackerArmiesMap;
              byte side = 0;
              if (Side == (byte) 0 && !DataManager.Instance.bWarAttacker || Side == (byte) 1 && DataManager.Instance.bWarAttacker)
                side = (byte) 1;
              if (WarManager.WarKind == WarManager.EWarKind.Normal)
                GUIManager.Instance.pDVMgr.OpenBloodShow((int) side, (int) numArray[(int) index2, (int) index4] - 1);
            }
            else if (index4 == (byte) 0)
            {
              long num13 = DataManager.Instance.NowValue_War[2] - (long) val;
              DataManager.Instance.NowValue_War[2] = num13 >= 0L ? num13 : 0L;
              this.UIUpdateFlag |= 4;
              byte side = 0;
              if (DataManager.Instance.bWarAttacker)
                side = (byte) 1;
              if (WarManager.WarKind == WarManager.EWarKind.Normal)
                GUIManager.Instance.pDVMgr.OpenBloodShow((int) side, 16);
            }
            if (num6 != (byte) 1 && num6 != (byte) 3 && num6 != (byte) 4)
            {
              this.setSkillWorkingList((byte) (1U - (uint) Side), num6, num7, false);
              continue;
            }
            continue;
          case 4:
            armyGroup1.AllDie((int) index4);
            if (armyGroup1.GroupKind == EGroupKind.CastleGate && index4 == (byte) 0)
              this.playCollapse();
            if (index2 != (byte) 4)
            {
              this.setSkillWorkingList(Side, index2, index4, false);
              if (Side == (byte) 0)
                --this.attackerAliveCount;
              else
                --this.defenserAliveCount;
              if ((UnityEngine.Object) this.uiBattle != (UnityEngine.Object) null)
              {
                if (armyGroup1.heroSoldierID != (ushort) 0)
                {
                  this.uiBattle.AddHudMsg((int) Side, tableKey: armyGroup1.heroSoldierID);
                }
                else
                {
                  int tableKey = (int) index2 * 4 + 1 + ((int) armyGroup1.Tier - 1);
                  this.uiBattle.AddHudMsg((int) Side, 1, (ushort) tableKey);
                }
              }
            }
            else if ((UnityEngine.Object) this.uiBattle != (UnityEngine.Object) null && index4 != (byte) 0 && this.castleWeaponInfo[(int) index4 - 1] > (byte) 0)
            {
              int num14 = (int) this.castleWeaponInfo[(int) index4 - 1] - 1;
              int num15 = 21;
              int num16 = index4 != (byte) 5 ? num15 : 25;
              this.uiBattle.AddHudMsg(1, 2, (ushort) ((index4 != (byte) 6 ? num16 : 17) + num14));
            }
            if (armyGroup1.GroupKind != EGroupKind.CastleGate && armyGroup1.GroupKind != EGroupKind.Catapults)
            {
              if (Side == (byte) 0)
                --this.nonCatapultsCount_Left;
              else
                --this.nonCatapultsCount_Right;
              if (this.nonCatapultsCount_Left + this.nonCatapultsCount_Right == 0)
                this.WCamera.bIgnoreCatapults = false;
            }
            if (!armyGroup1.HasLord && armyGroup1.heroSoldier != null && (UnityEngine.Object) this.PickedTrans != (UnityEngine.Object) null && (UnityEngine.Object) armyGroup1.heroSoldier.gameObject == (UnityEngine.Object) this.PickedTrans.gameObject)
            {
              this.checkPickHero(false);
              continue;
            }
            continue;
          case 5:
            byte Kind4 = RecvBuffer[startIdx1];
            int index15 = startIdx1 + 1;
            byte Idx5 = RecvBuffer[index15];
            int startIdx7 = index15 + 1;
            int skillID2 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx7);
            int startIdx8 = startIdx7 + 2;
            int num17 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx8);
            startIdx1 = startIdx8 + 2;
            ArmyGroup armyGroup12 = this.getArmyGroup(Side != (byte) 0 ? (byte) 0 : (byte) 1, Kind4, Idx5);
            if (index2 == (byte) 4)
              armyGroup1.Target = armyGroup12;
            FOKind kind = index2 != (byte) 4 ? (index2 != (byte) 3 ? (armyGroup1.Tier != (byte) 4 ? FOKind.Arrow : FOKind.Bomb) : (armyGroup1.Tier != (byte) 1 ? (armyGroup1.Tier == (byte) 4 || armyGroup1.Tier == (byte) 3 ? FOKind.FireStone : FOKind.Stone) : FOKind.CLv1_Arrow)) : FOKind.TowerArrow;
            armyGroup1.FireRange(armyGroup12, this.FOMgr, kind, (float) num17 * (1f / 1000f), (ushort) skillID2, index4);
            if (index2 == (byte) 1)
            {
              this.setSkillWorkingList(Side, index2, index4, false);
              float num18 = GameConstants.DistanceSquare(this.mainCamera.position, armyGroup1.groupRoot.position);
              if (!this.rangeDist_Sound.HasValue || (double) num18 < (double) this.rangeDist_Sound.Value)
              {
                this.rangeDist_Sound = new float?(num18);
                this.rangeSoundParent = armyGroup1;
                this.SoundDirtyFlag |= 4U;
                continue;
              }
              continue;
            }
            continue;
          case 6:
            int newMode = (int) RecvBuffer[startIdx1];
            ++startIdx1;
            if (this.m_WarResult == EWarResult.NONE && newMode != 1)
            {
              this.changeSiegeMode(newMode);
              continue;
            }
            continue;
          case 7:
            int num19 = GameConstants.ConvertBytesToInt(RecvBuffer, startIdx1);
            startIdx1 += 4;
            this.TrapsHp += (uint) num19;
            if ((long) this.LastTrapsHp >= (long) num19)
              this.LastTrapsHp -= (uint) num19;
            else
              this.LastTrapsHp = 0U;
            DataManager.Instance.NowValue_War[1] -= (long) num19;
            DataManager.Instance.NowValue_War[1] = Math.Max(0L, DataManager.Instance.NowValue_War[1]);
            DataManager.Instance.CastleTrapsDestroyedCount -= (long) num19;
            DataManager.Instance.CastleTrapsDestroyedCount = Math.Max(0L, DataManager.Instance.CastleTrapsDestroyedCount);
            this.UIUpdateFlag |= 2;
            continue;
          default:
            continue;
        }
      }
    }
  }

  private void changeSiegeMode(int newMode)
  {
    int num = 0;
    if (newMode >= 3 && this.SiegeMode < 3)
    {
      for (int Idx = 0; Idx < 4; ++Idx)
      {
        ArmyGroup armyGroup1 = this.getArmyGroup((byte) 1, (byte) 0, (byte) Idx);
        if (armyGroup1 != null)
        {
          armyGroup1.setPosition(WarManager.ActionPositionRight[0, Idx, 0], WarManager.ActionPositionRight[0, Idx, 1]);
          armyGroup1.SoldierFlagCount = 0;
          armyGroup1.CommonFlag |= 1U;
          armyGroup1.State = ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN;
          ++num;
        }
        ArmyGroup armyGroup2 = this.getArmyGroup((byte) 1, (byte) 2, (byte) Idx);
        if (armyGroup2 != null)
        {
          armyGroup2.setPosition(WarManager.ActionPositionRight[2, Idx, 0], WarManager.ActionPositionRight[2, Idx, 1]);
          armyGroup2.SoldierFlagCount = 0;
          armyGroup2.CommonFlag |= 1U;
          armyGroup2.State = ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN;
          ++num;
        }
      }
    }
    if (newMode == 4)
    {
      for (int Idx = 0; Idx < 4; ++Idx)
      {
        ArmyGroup armyGroup = this.getArmyGroup((byte) 1, (byte) 1, (byte) Idx);
        if (armyGroup != null)
        {
          armyGroup.setPosition(WarManager.ActionPositionRight[1, Idx, 0], WarManager.ActionPositionRight[1, Idx, 1]);
          armyGroup.SoldierFlagCount = 0;
          armyGroup.CommonFlag |= 1U;
          armyGroup.State = ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL;
          ++num;
        }
      }
    }
    for (int index = 0; index < this.attackerArmies.Length; ++index)
    {
      if (this.attackerArmies[index] != null && this.attackerArmies[index].HasHeroDisplay && this.attackerArmies[index].State != ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL && this.attackerArmies[index].State != ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN)
        this.attackerArmies[index].setLordAnimEnable(false);
    }
    for (int index = 0; index < this.defenserArmies.Length; ++index)
    {
      if (this.defenserArmies[index] != null && this.defenserArmies[index].HasHeroDisplay && this.defenserArmies[index].State != ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL && this.defenserArmies[index].State != ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN)
        this.defenserArmies[index].setLordAnimEnable(false);
    }
    this.setOutsideHeroAnimEnable(false);
    if (num != 0)
    {
      switch (newMode)
      {
        case 3:
          this.uiBattle.AddCenterMsg((ushort) 500, this.actionKind != EPlayerActionKind.ATTACKER ? (byte) 0 : (byte) 1);
          break;
        case 4:
          this.uiBattle.AddCenterMsg((ushort) 501, this.actionKind != EPlayerActionKind.ATTACKER ? (byte) 0 : (byte) 1);
          break;
      }
    }
    if (this.AttackSoundKey != (byte) 21)
    {
      this.audioMgr.StopSFX(this.AttackSoundKey);
      this.AttackSoundKey = (byte) 21;
    }
    if (this.MovingSoundKey != (byte) 21)
    {
      this.audioMgr.StopSFX(this.MovingSoundKey);
      this.MovingSoundKey = (byte) 21;
    }
    if (newMode == 3)
      this.SoundDirtyFlag |= 1U;
    this.SiegeMode = newMode;
    this.m_WarState = WarManager.WarState.CHANGING_SIEGE_MODE;
  }

  private void setSkillWorkingList(byte side, byte kind, byte idx, bool bWorking)
  {
    ArmyGroup[] armyGroupArray = side != (byte) 0 ? this.defenserArmies : this.attackerArmies;
    int num1 = (int) (side != (byte) 0 ? this.defenserArmiesMap : this.attackerArmiesMap)[(int) kind, (int) idx] - 1;
    int num2 = side != (byte) 0 ? num1 + 32 : num1;
    if (!bWorking)
    {
      if (((long) (this.m_SkillWorkingList >> num2) & 1L) != 0L)
        this.m_SkillWorkingList ^= (ulong) (1L << num2);
    }
    else
      this.m_SkillWorkingList |= (ulong) (1L << num2);
    this.m_bSkillDirty = true;
  }

  private void CaleWarMorale(byte side, uint val)
  {
    DataManager instance = DataManager.Instance;
    if (instance.WarMoraleValue[(int) side] == 0UL)
      return;
    instance.WarLoseCount[(int) side] += (ulong) val;
    float num = (float) (Convert.ToDouble(instance.WarLoseCount[(int) side]) / Convert.ToDouble(instance.WarMoraleValue[(int) side]));
    instance.WarMorale[(int) side] = Mathf.Clamp(Mathf.CeilToInt((float) (100.0 - (double) num * 100.0)), 0, 100);
    if (side == (byte) 1 && this.defenserAliveCount == (byte) 0)
      instance.WarMorale[1] = 0;
    if (instance.WarMorale[(int) side] == 0 && this.m_WarResult != (side != (byte) 0 ? EWarResult.WIN : EWarResult.LOSE))
      instance.WarMorale[(int) side] = 1;
    this.UIUpdateFlag |= side != (byte) 0 ? 2 : 1;
  }

  private ArmyGroup getArmyGroup(byte Side, byte Kind, byte Idx)
  {
    if (Side == (byte) 1 && Kind == (byte) 4)
      return (ArmyGroup) this.castle;
    ArmyGroup[] armyGroupArray = Side != (byte) 0 ? this.defenserArmies : this.attackerArmies;
    byte[,] numArray = Side != (byte) 0 ? this.defenserArmiesMap : this.attackerArmiesMap;
    return numArray[(int) Kind, (int) Idx] != (byte) 0 ? armyGroupArray[(int) numArray[(int) Kind, (int) Idx] - 1] : (ArmyGroup) null;
  }

  private ushort loadWarInfo(bool bResetCoord = false)
  {
    DataManager instance = DataManager.Instance;
    UnityEngine.Random.seed = (int) instance.War_RndSeed;
    this.attackerLordID = instance.War_LeftHeroNum == (byte) 0 || instance.War_LeftLordID == (ushort) 0 ? (ushort) 0 : instance.War_LeftLordID;
    this.defenserLordID = instance.War_RightHeroNum == (byte) 0 || instance.War_RightLordID == (ushort) 0 ? (ushort) 0 : instance.War_RightLordID;
    this.BSUtil.setCombatInfo(instance.War_LeftCastleLv, instance.pLeftLeaderData, instance.War_LeftHeroNum, instance.pLeftTroopForce, instance.War_RightCastleLv, instance.pRightLeaderData, instance.War_RightHeroNum, instance.pRightTroopForce);
    this.BSUtil.setTroopAttrData(instance.War_LeftAttackAttr, instance.War_LeftDefenseAttr, instance.War_LeftHealthAttr, instance.War_RightAttackAttr, instance.War_RightDefenseAttr, instance.War_RightHealthAttr);
    if (instance.bSiege != (byte) 0)
    {
      this.m_GateTier = (byte) Mathf.Clamp(Mathf.CeilToInt((float) instance.War_WallLevel / 8f), 1, 4);
      if (this.BSUtil.setWallTrapInfo(instance.CurWallHp, instance.MaxWallHp, instance.pCastleInfo))
        FSMManager.Instance.bIsSiegeMode = true;
      DataManager.Instance.MaxValue_War[2] = (long) (instance.MaxWallHp * 100U);
      DataManager.Instance.NowValue_War[2] = (long) (instance.CurWallHp * 100U);
      this.BSUtil.setTrapAttrData(ref instance.War_WallAttr);
    }
    else
    {
      FSMManager.Instance.bIsSiegeMode = false;
      instance.MaxWallHp = 0U;
      instance.CurWallHp = 0U;
      DataManager.Instance.MaxValue_War[2] = 0L;
      DataManager.Instance.NowValue_War[2] = 0L;
    }
    if (!bResetCoord)
    {
      if (this.attackerHeroIdCache.Count <= 0 && this.defenserHeroIdCache.Count <= 0)
      {
        for (int index = 0; index < 5; ++index)
        {
          int num = 1 << index;
          if (instance.pLeftLeaderData[index].HeroID != (ushort) 0)
            this.attackerHeroIdCache.Add(instance.pLeftLeaderData[index].HeroID);
          if (instance.pRightLeaderData[index].HeroID != (ushort) 0)
            this.defenserHeroIdCache.Add(instance.pRightLeaderData[index].HeroID);
        }
      }
      this.RecvBufferLeft[0] = (byte) 0;
      this.RecvBufferRight[0] = (byte) 0;
      this.SiegeMode = this.BSUtil.setTroopOver(this.RecvBufferLeft, this.RecvBufferRight);
      this.decodeTroopOverData(this.SiegeMode, this.RecvBufferLeft, this.RecvBufferRight);
    }
    else
    {
      GUIManager.Instance.pDVMgr.EndWarClear();
      this.RecvBufferLeft[0] = (byte) 0;
      this.RecvBufferRight[0] = (byte) 0;
      this.SiegeMode = this.BSUtil.setTroopOver(this.RecvBufferLeft, this.RecvBufferRight);
      this.decodeTroopOverData(this.SiegeMode, this.RecvBufferLeft, this.RecvBufferRight, true);
      if ((int) WarManager.WarCoordIndex_Right != (int) WarManager.TroopKindSimuIndex_Right)
      {
        for (int index = 0; index < (int) this.defenserCount; ++index)
          this.enemySideArmies[index] = this.defenserArmies[index];
        this.enemySideArmies[16] = (ArmyGroup) this.castle;
      }
      GUIManager.Instance.pDVMgr.BeginWarInitial();
      GUIManager.Instance.pDVMgr.SetBloodBarFillAmount(1, 16, 0.0f);
      Resources.UnloadUnusedAssets();
    }
    Array.Clear((Array) instance.WarLoseCount, 0, 2);
    instance.WarMorale[0] = 100;
    instance.WarMorale[1] = 100;
    return 1;
  }

  private void decodeTroopOverData(
    int mode,
    byte[] RecvBufferLeft,
    byte[] RecvBufferRight,
    bool bCoordModeReset = false)
  {
    int num1 = (int) RecvBufferLeft[0] <= (int) RecvBufferRight[0] ? (int) RecvBufferRight[0] : (int) RecvBufferLeft[0];
    int index1 = 1;
    byte index2 = 0;
    int index3 = 1;
    byte index4 = 0;
    float[,,] numArray1 = this.SiegeMode > 1 ? WarManager.InitPositionLeft_SiegeMode : WarManager.InitPositionLeft;
    float[,,] numArray2 = this.SiegeMode > 1 ? WarManager.InitPositionRight_SiegeMode : WarManager.InitPositionRight;
    long num2 = 0;
    long num3 = 0;
    byte texColor = (byte) Mathf.Abs((int) ((byte) 1 - this.actionKind));
    ushort[] count = new ushort[8];
    this.TrapsHp = 0U;
    this.LastTrapsHp = 0U;
    this.MoraleStep = 0;
    bool flag = false;
    DataManager instance = DataManager.Instance;
    instance.CastleTrapsDestroyedCount = 0L;
    for (int index5 = 0; index5 < num1; ++index5)
    {
      if (index5 < (int) RecvBufferLeft[0])
      {
        byte index6 = RecvBufferLeft[index1];
        int index7 = index1 + 1;
        byte index8 = RecvBufferLeft[index7];
        int index9 = index7 + 1;
        byte tier = RecvBufferLeft[index9];
        int startIdx1 = index9 + 1;
        int num4 = GameConstants.ConvertBytesToInt(RecvBufferLeft, startIdx1);
        int startIdx2 = startIdx1 + 4;
        ushort num5 = GameConstants.ConvertBytesToUShort(RecvBufferLeft, startIdx2);
        index1 = startIdx2 + 2;
        if (this.attackerArmies[(int) index2] == null)
        {
          ushort num6 = num5;
          bool hasLord = num6 != (ushort) 0 && (int) num6 == (int) this.attackerLordID;
          this.attackerArmies[(int) index2] = new ArmyGroup((EGroupKind) ((uint) index6 + 1U), tier, this.renderRoot, (byte) 0, (byte) this.actionKind, num6, index2, hasLord);
          if (num6 != (ushort) 0)
          {
            if ((int) num6 == (int) this.attackerLordID)
            {
              this.attackerLord = this.attackerArmies[(int) index2];
              this.attackerLord.HasLord = true;
              this.attackerLordUnit = this.attackerLord.heroSoldier;
            }
            Hero recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(num6);
            if (recordByKey1.GroupSkill1 != (ushort) 0)
            {
              Skill recordByKey2 = DataManager.Instance.SkillTable.GetRecordByKey(recordByKey1.GroupSkill1);
              if (recordByKey2.FlyParticle != (ushort) 0 && index6 != (byte) 3)
              {
                count[(int) recordByKey2.FlyParticle - 1] += (ushort) 2;
                this.attackerArmies[(int) index2].heroSoldierFO = recordByKey2.FlyParticle;
              }
              if (recordByKey2.FlySound != (ushort) 0)
              {
                count[7] += (ushort) 2;
                this.attackerArmies[(int) index2].heroSoldierSkillFO = recordByKey2.FlySound;
              }
            }
            this.attackerHeroIdCache.Remove(num6);
          }
          this.attackerArmies[(int) index2].particleManager = this.particleMgr;
          this.attackerArmies[(int) index2].Index = index8;
          this.attackerArmies[(int) index2].heroSoldierID = num5;
          this.attackerArmiesMap[(int) index6, (int) index8] = (byte) ((uint) index2 + 1U);
        }
        else if (!bCoordModeReset)
          this.attackerArmies[(int) index2].Reset();
        if (!bCoordModeReset)
        {
          float x = numArray1[(int) index6, (int) index8, 0];
          float z = numArray1[(int) index6, (int) index8, 1];
          this.attackerArmies[(int) index2].setPosition(new Vector3(x, 0.0f, z), new Vector3(10000f, 0.0f, z), (byte) 0);
        }
        this.attackerArmies[(int) index2].MaxHP = num4;
        num2 += (long) num4;
        ++index2;
        switch (index6)
        {
          case 1:
            if (tier != (byte) 4)
            {
              count[1] += (ushort) 9;
              break;
            }
            count[2] += (ushort) 9;
            break;
          case 3:
            switch (tier)
            {
              case 1:
                count[6] += (ushort) 2;
                break;
              case 2:
                ++count[0];
                break;
              default:
                ++count[3];
                break;
            }
            break;
        }
        if (index6 >= (byte) 0 && index6 < (byte) 3)
          ++this.nonCatapultsCount_Left;
      }
      if (index5 < (int) RecvBufferRight[0])
      {
        byte index10 = RecvBufferRight[index3];
        int index11 = index3 + 1;
        byte index12 = RecvBufferRight[index11];
        int index13 = index11 + 1;
        byte tier = RecvBufferRight[index13];
        int startIdx3 = index13 + 1;
        int num7 = GameConstants.ConvertBytesToInt(RecvBufferRight, startIdx3);
        int startIdx4 = startIdx3 + 4;
        ushort num8 = GameConstants.ConvertBytesToUShort(RecvBufferRight, startIdx4);
        index3 = startIdx4 + 2;
        if (index10 == (byte) 4)
        {
          if (index12 > (byte) 0 && index12 <= (byte) 6)
          {
            this.castleWeaponInfo[(int) index12 - 1] = tier;
            if (index12 <= (byte) 4)
              count[5] += (ushort) 5;
            num3 += (long) num7;
            this.LastTrapsHp += (uint) num7;
            instance.CastleTrapsDestroyedCount += (long) num7;
          }
        }
        else
        {
          if (this.defenserArmies[(int) index4] == null)
          {
            ushort num9 = num8;
            bool hasLord = num9 != (ushort) 0 && (int) num9 == (int) this.defenserLordID;
            this.defenserArmies[(int) index4] = new ArmyGroup((EGroupKind) ((uint) index10 + 1U), tier, this.renderRoot, (byte) 1, texColor, num9, index4, hasLord);
            if (num9 != (ushort) 0)
            {
              if ((int) num9 == (int) this.defenserLordID)
              {
                this.defenserLord = this.defenserArmies[(int) index4];
                this.defenserLord.HasLord = true;
                this.defenserLordUnit = this.defenserLord.heroSoldier;
              }
              Hero recordByKey3 = DataManager.Instance.HeroTable.GetRecordByKey(num9);
              if (recordByKey3.GroupSkill1 != (ushort) 0)
              {
                Skill recordByKey4 = DataManager.Instance.SkillTable.GetRecordByKey(recordByKey3.GroupSkill1);
                if (recordByKey4.FlyParticle != (ushort) 0 && index10 != (byte) 3)
                {
                  count[(int) recordByKey4.FlyParticle - 1] += (ushort) 2;
                  this.defenserArmies[(int) index4].heroSoldierFO = recordByKey4.FlyParticle;
                }
                if (recordByKey4.FlySound != (ushort) 0)
                {
                  count[7] += (ushort) 2;
                  this.defenserArmies[(int) index4].heroSoldierSkillFO = recordByKey4.FlySound;
                }
              }
              this.defenserHeroIdCache.Remove(num9);
            }
            this.defenserArmies[(int) index4].particleManager = this.particleMgr;
            this.defenserArmies[(int) index4].Index = index12;
            this.defenserArmies[(int) index4].heroSoldierID = num8;
            this.defenserArmiesMap[(int) index10, (int) index12] = (byte) ((uint) index4 + 1U);
            flag = true;
          }
          else
          {
            if (!bCoordModeReset)
              this.defenserArmies[(int) index4].Reset();
            if (this.SiegeMode > 1)
              this.defenserArmies[(int) index4].bAttackMode = false;
          }
          if (!bCoordModeReset)
          {
            if (this.SiegeMode > 1 && index10 == (byte) 1)
            {
              Vector3 pos = this.ArcherPosOnTower[(int) index12];
              this.defenserArmies[(int) index4].setPosition(pos, new Vector3(-10000f, pos.y, pos.z), (byte) 1);
            }
            else
            {
              float x = numArray2[(int) index10, (int) index12, 0];
              float z = numArray2[(int) index10, (int) index12, 1];
              this.defenserArmies[(int) index4].setPosition(new Vector3(x, 0.0f, z), new Vector3(-10000f, 0.0f, z), (byte) 0);
            }
          }
          if (this.SiegeMode > 1 && this.defenserArmies[(int) index4].heroSoldier != null && (int) this.defenserArmies[(int) index4].heroSoldierID == (int) this.defenserLordID)
            this.defenserArmies[(int) index4].SiegeModeDefenserLordInit();
          this.defenserArmies[(int) index4].MaxHP = num7;
          num3 += (long) num7;
          ++index4;
          switch (index10)
          {
            case 1:
              if (tier != (byte) 4)
              {
                count[1] += (ushort) 9;
                break;
              }
              count[2] += (ushort) 9;
              break;
            case 3:
              switch (tier)
              {
                case 1:
                  count[6] += (ushort) 2;
                  break;
                case 2:
                  ++count[0];
                  break;
                default:
                  ++count[3];
                  break;
              }
              break;
          }
          if (index10 >= (byte) 0 && index10 < (byte) 3)
            ++this.nonCatapultsCount_Right;
        }
      }
    }
    this.WCamera.bIgnoreCatapults = true;
    if (this.nonCatapultsCount_Right + this.nonCatapultsCount_Left == 0)
      this.WCamera.bIgnoreCatapults = false;
    if (!bCoordModeReset)
    {
      if (index2 == (byte) 0)
      {
        for (int index14 = 0; index14 < 2; ++index14)
        {
          if (this.attackerArmies[(int) index2] == null)
          {
            this.attackerArmies[(int) index2] = new ArmyGroup(EGroupKind.Infantry, (byte) 1, this.renderRoot, (byte) 0, (byte) this.actionKind, (ushort) 0, index2, false);
            this.attackerArmies[(int) index2].particleManager = this.particleMgr;
            this.attackerArmies[(int) index2].Index = (byte) index14;
            this.attackerArmies[(int) index2].heroSoldierID = (ushort) 0;
            this.attackerArmiesMap[0, index14] = (byte) ((uint) index2 + 1U);
          }
          else
            this.attackerArmies[(int) index2].Reset();
          float x = numArray1[0, index14, 0];
          float z = numArray1[0, index14, 1];
          this.attackerArmies[(int) index2].setPosition(new Vector3(x, 0.0f, z), new Vector3(10000f, 0.0f, z), (byte) 0);
          this.attackerArmies[(int) index2].MaxHP = 100;
          ++index2;
        }
      }
      else if (this.SiegeMode == 1 && index4 == (byte) 0)
      {
        for (int index15 = 0; index15 < 2; ++index15)
        {
          if (this.defenserArmies[(int) index4] == null)
          {
            this.defenserArmies[(int) index4] = new ArmyGroup(EGroupKind.Infantry, (byte) 1, this.renderRoot, (byte) 1, texColor, (ushort) 0, index4, false);
            this.defenserArmies[(int) index4].particleManager = this.particleMgr;
            this.defenserArmies[(int) index4].Index = (byte) index15;
            this.defenserArmies[(int) index4].heroSoldierID = (ushort) 0;
            this.defenserArmiesMap[0, index15] = (byte) ((uint) index4 + 1U);
          }
          else
            this.defenserArmies[(int) index4].Reset();
          float x = numArray2[0, index15, 0];
          float z = numArray2[0, index15, 1];
          this.defenserArmies[(int) index4].setPosition(new Vector3(x, 0.0f, z), new Vector3(-10000f, 0.0f, z), (byte) 0);
          this.defenserArmies[(int) index4].MaxHP = 100;
          ++index4;
        }
      }
      this.attackerCount = index2;
      this.attackerAliveCount = index2;
      this.defenserCount = index4;
      this.defenserAliveCount = index4;
      if (this.bFirstTimeInit)
      {
        for (int index16 = 0; index16 < this.attackerHeroIdCache.Count; ++index16)
        {
          bool isLord = (int) this.attackerHeroIdCache[index16] == (int) this.attackerLordID;
          Lord lord = new Lord(this.attackerHeroIdCache[index16], (byte) 1, (byte) 1, (byte) 0, isLord, byte.MaxValue);
          lord.LordAnimSetting((byte) 0);
          lord.transform.parent = this.renderRoot;
          lord.transform.position = this.nonUseHeroPos_Left[index16];
          lord.transform.rotation = Quaternion.LookRotation(Vector3.right);
          lord.FSMController = FSMManager.Instance.getState(EStateName.OUTSIDE_HERO_DISPLAY);
          if ((int) this.attackerHeroIdCache[index16] == (int) this.attackerLordID)
          {
            this.particleMgr.Spawn(this.actionKind != EPlayerActionKind.ATTACKER ? (ushort) 2017 : (ushort) 2014, lord.transform, Vector3.zero, 1f, true);
            lord.IsLord = true;
            this.attackerLordUnit = (Soldier) lord;
          }
          this.attackerHeroCache.Add(lord);
        }
      }
      else
      {
        this.attackerHeroIdCache.Clear();
        for (int index17 = 0; index17 < this.attackerHeroCache.Count; ++index17)
        {
          this.attackerHeroCache[index17].LordAnimSetting((byte) 0);
          this.attackerHeroCache[index17].transform.position = this.nonUseHeroPos_Left[index17];
          this.attackerHeroCache[index17].transform.rotation = Quaternion.LookRotation(Vector3.right);
          this.attackerHeroCache[index17].FSMController = FSMManager.Instance.getState(EStateName.OUTSIDE_HERO_DISPLAY);
          if (!this.attackerHeroIdCache.Contains(this.attackerHeroCache[index17].lordID))
            this.attackerHeroIdCache.Add(this.attackerHeroCache[index17].lordID);
        }
      }
      if (this.bFirstTimeInit)
      {
        Vector3[] vector3Array = this.SiegeMode > 1 ? this.nonUseHeroPos_Right_SiegeMode : this.nonUseHeroPos_Right;
        for (int index18 = 0; index18 < this.defenserHeroIdCache.Count; ++index18)
        {
          bool isLord = (int) this.defenserHeroIdCache[index18] == (int) this.defenserLordID;
          Lord lord = new Lord(this.defenserHeroIdCache[index18], (byte) 1, (byte) 1, (byte) 1, isLord, byte.MaxValue);
          lord.LordAnimSetting((byte) 0);
          lord.transform.parent = this.renderRoot;
          lord.transform.position = vector3Array[index18];
          lord.transform.rotation = Quaternion.LookRotation(Vector3.left);
          lord.FSMController = FSMManager.Instance.getState(EStateName.OUTSIDE_HERO_DISPLAY);
          if ((int) this.defenserHeroIdCache[index18] == (int) this.defenserLordID)
          {
            this.particleMgr.Spawn(texColor != (byte) 0 ? (ushort) 2017 : (ushort) 2014, lord.transform, Vector3.zero, 1f, true);
            lord.IsLord = true;
            this.defenserLordUnit = (Soldier) lord;
            if (this.SiegeMode > 1)
              lord.transform.position = new Vector3(55f, 7.6f, 15f);
          }
          this.defenserHeroCache.Add(lord);
        }
      }
      else
      {
        this.defenserHeroIdCache.Clear();
        Vector3[] vector3Array = this.SiegeMode > 1 ? this.nonUseHeroPos_Right_SiegeMode : this.nonUseHeroPos_Right;
        for (int index19 = 0; index19 < this.defenserHeroCache.Count; ++index19)
        {
          this.defenserHeroCache[index19].LordAnimSetting((byte) 0);
          this.defenserHeroCache[index19].transform.position = vector3Array[index19];
          this.defenserHeroCache[index19].transform.rotation = Quaternion.LookRotation(Vector3.left);
          this.defenserHeroCache[index19].FSMController = FSMManager.Instance.getState(EStateName.OUTSIDE_HERO_DISPLAY);
          if (!this.defenserHeroIdCache.Contains(this.defenserHeroCache[index19].lordID))
            this.defenserHeroIdCache.Add(this.defenserHeroCache[index19].lordID);
          if ((int) this.defenserHeroIdCache[index19] == (int) this.defenserLordID && this.SiegeMode > 1)
            this.defenserHeroCache[index19].transform.position = new Vector3(55f, 7.6f, 15f);
        }
      }
      if (this.bFirstTimeInit)
        this.bFirstTimeInit = false;
      DataManager.Instance.MaxValue_War[0] = num2;
      DataManager.Instance.NowValue_War[0] = num2;
    }
    else if (flag)
    {
      this.defenserCount = index4;
      this.defenserAliveCount = index4;
    }
    if (!bCoordModeReset || flag)
    {
      if (instance.CurWallHp == 0U)
      {
        num3 -= (long) this.LastTrapsHp;
        if (num3 < 0L)
          num3 = 0L;
        this.LastTrapsHp = 0U;
        instance.CastleTrapsDestroyedCount = 0L;
      }
      DataManager.Instance.MaxValue_War[1] = num3;
      DataManager.Instance.NowValue_War[1] = num3;
    }
    if (DataManager.CompareStr(instance.PlayerName_War[0], instance.RoleAttr.Name) == 0)
    {
      instance.PlayerName_War[0].ClearString();
      instance.PlayerName_War[0].Append(instance.mStringTable.GetStringByID(678U));
      instance.AllianceTag_War[0].ClearString();
    }
    else if (DataManager.CompareStr(instance.PlayerName_War[1], instance.RoleAttr.Name) == 0)
    {
      instance.PlayerName_War[1].ClearString();
      instance.PlayerName_War[1].Append(instance.mStringTable.GetStringByID(678U));
      instance.AllianceTag_War[1].ClearString();
    }
    if (this.FOMgr == null)
    {
      for (int index20 = 0; index20 < 8; ++index20)
        count[index20] *= (ushort) 2;
      this.FOMgr = new FlyingObjectManager(this.renderRoot, count, this.particleMgr);
      this.m_BrokenFO[0] = new BrokenFO[(int) count[0]];
      for (int index21 = 0; index21 < this.m_BrokenFO[0].Length; ++index21)
      {
        this.m_BrokenFO[0][index21] = new BrokenFO((byte) 4, (byte) 1);
        this.m_BrokenFO[0][index21].transform.parent = this.renderRoot;
      }
      this.m_BrokenFO[1] = new BrokenFO[(int) count[3]];
      for (int index22 = 0; index22 < this.m_BrokenFO[1].Length; ++index22)
      {
        this.m_BrokenFO[1][index22] = new BrokenFO((byte) 4, (byte) 2);
        this.m_BrokenFO[1][index22].transform.parent = this.renderRoot;
      }
    }
    if (this.SiegeMode > 1)
    {
      if (this.castle == null)
      {
        this.castle = new WarCastle(this.m_GateTier, this.renderRoot, this.castleWeaponInfo);
        this.castle.particleManager = this.particleMgr;
      }
      this.castle.MaxHP = (int) instance.MaxWallHp * 100;
      this.castle.GotHurt = ((int) instance.MaxWallHp - (int) instance.CurWallHp) * 100;
    }
    this.MoraleStep = 4;
    Array.Clear((Array) this.PickList, 0, 10);
    this.PickListCount = (byte) 0;
    for (int index23 = 0; index23 < (int) this.attackerCount; ++index23)
    {
      if (this.attackerArmies[index23].heroSoldier != null)
      {
        this.PickList[(int) this.PickListCount] = this.attackerArmies[index23].heroSoldier.gameObject;
        ++this.PickListCount;
      }
    }
    for (int index24 = 0; index24 < (int) this.defenserCount; ++index24)
    {
      if (this.defenserArmies[index24].heroSoldier != null)
      {
        this.PickList[(int) this.PickListCount] = this.defenserArmies[index24].heroSoldier.gameObject;
        ++this.PickListCount;
      }
    }
    for (int index25 = 0; index25 < this.attackerHeroCache.Count; ++index25)
    {
      if (this.attackerHeroCache[index25] != null)
      {
        this.PickList[(int) this.PickListCount] = this.attackerHeroCache[index25].gameObject;
        ++this.PickListCount;
      }
    }
    for (int index26 = 0; index26 < this.defenserHeroCache.Count; ++index26)
    {
      if (this.defenserHeroCache[index26] != null)
      {
        this.PickList[(int) this.PickListCount] = this.defenserHeroCache[index26].gameObject;
        ++this.PickListCount;
      }
    }
  }

  public void checkPickHero(bool bShow)
  {
    if (bShow)
    {
      Vector2? nullable1 = new Vector2?();
      Vector2? nullable2 = new Vector2?(Input.GetTouch(0).position);
      if (!nullable2.HasValue)
        return;
      GameObject gameObject = GameConstants.GameObjectPick(nullable2.Value, this.PickList, typeof (SkinnedMeshRenderer));
      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
      {
        uint result = 0;
        if (!uint.TryParse(gameObject.name, out result))
          return;
        ushort heroID = 0;
        bool bLord = false;
        ushort stringid = this.checkArmyGroupHintState(result, out heroID, out bLord);
        if (stringid == (ushort) 0)
          return;
        this.PickedTrans = gameObject.transform;
        this.HintTrans = this.uiBattle.SetHint(true, bLord, heroID, stringid);
        this.HintHeroNo = result;
        this.HintStrID = stringid;
        this.HintTimer = 0.0f;
      }
      else
      {
        if (!((UnityEngine.Object) this.HintTrans != (UnityEngine.Object) null))
          return;
        this.checkPickHero(false);
      }
    }
    else
    {
      if (!((UnityEngine.Object) this.HintTrans != (UnityEngine.Object) null))
        return;
      this.HintTrans = (RectTransform) null;
      this.PickedTrans = (Transform) null;
      this.HintHeroNo = 0U;
      this.HintStrID = (ushort) 0;
      this.uiBattle.SetHint(false, false, (ushort) 0, (ushort) 0);
    }
  }

  private ushort checkArmyGroupHintState(uint heroNo, out ushort heroID, out bool bLord)
  {
    ushort num1 = (ushort) (heroNo >> 16 & (uint) ushort.MaxValue);
    byte num2 = (byte) (heroNo >> 8 & (uint) byte.MaxValue);
    byte index = (byte) (heroNo & (uint) byte.MaxValue);
    byte num3 = (byte) ((uint) num2 & 1U);
    ushort num4 = 0;
    if (index == byte.MaxValue)
    {
      num4 = (ushort) 833;
    }
    else
    {
      ArmyGroup armyGroup = (num3 != (byte) 0 ? this.defenserArmies : this.attackerArmies)[(int) index];
      if (armyGroup.HasLord && armyGroup.CurHP == 0)
        num4 = (ushort) 832;
      else if (armyGroup.CurHP != 0)
        num4 = armyGroup.State != ArmyGroup.EGROUPSTATE.MOVING ? (ushort) 831 : (ushort) 830;
    }
    heroID = num1;
    bLord = ((int) num2 & 2) != 0;
    return num4;
  }

  public void resetWar(eLegBattleSimulationType type = eLegBattleSimulationType.None, bool bCamCoordMode = false)
  {
    DataManager instance = DataManager.Instance;
    this.BSUtil.InitCSSimulator(instance.War_RndSeed, instance.War_RndGap);
    int num = (int) this.loadWarInfo();
    GUIManager.Instance.CloseMenu(EGUIWindow.UI_LegBattle);
    if ((UnityEngine.Object) this.LordCage != (UnityEngine.Object) null)
      this.LordCage.gameObject.SetActive(false);
    if (this.castle != null)
      this.castle.Reset();
    this.m_ui32Tcik = 0U;
    this.deltaTime = 0.0f;
    this.m_WarResult = EWarResult.NONE;
    this.SubState = (byte) 0;
    this.WCamera.SetTargetPosition(Vector3.zero, false, 1f);
    this.WCamera.initCamera(this.attackerArmies, (int) this.attackerCount, this.defenserArmies, (int) this.defenserCount);
    if (bCamCoordMode)
      this.WCamera.CoordCamMode = true;
    this.uiBattle = (UILegBattle) GUIManager.Instance.OpenMenu(EGUIWindow.UI_LegBattle, (int) this.actionKind, WarManager.WarKind != WarManager.EWarKind.CoordTest ? 0 : (int) type);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 0);
    GUIManager.Instance.pDVMgr.NextWar();
    float fillAmount = (float) instance.CurWallHp / (float) instance.MaxWallHp;
    GUIManager.Instance.pDVMgr.SetBloodBarFillAmount(this.actionKind != EPlayerActionKind.ATTACKER ? 0 : 1, 16, fillAmount);
    if (this.AttackSoundKey != (byte) 21)
      this.audioMgr.StopSFX(this.AttackSoundKey);
    if (this.MovingSoundKey != (byte) 21)
      this.audioMgr.StopSFX(this.MovingSoundKey);
    FSMManager.Instance.bIsBattleOver = false;
    AudioManager.Instance.LoadAndPlayBGM(BGMType.LegionWar, (byte) 1);
    this.m_WarState = WarManager.WarKind != WarManager.EWarKind.CoordTest ? WarManager.WarState.WAITING_FOR_START : WarManager.WarState.CHANGE_COORD_MODE;
  }

  private void UpdateSkillLightmap()
  {
    int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
    int curLightmapIdx1 = 2 + sceneLightmapSize;
    int curLightmapIdx2 = 1 + sceneLightmapSize;
    if (this.m_SkillWorkingList == 0UL)
    {
      for (int index = 0; index < (int) this.attackerCount; ++index)
        this.attackerArmies[index].resetLightmap(curLightmapIdx1);
      for (int index = 0; index < (int) this.defenserCount; ++index)
        this.defenserArmies[index].resetLightmap(curLightmapIdx1);
    }
    else
    {
      ulong skillWorkingList = this.m_SkillWorkingList;
      int index1 = 0;
      while (index1 < (int) this.attackerCount)
      {
        if ((skillWorkingList & 1UL) > 0UL)
          this.attackerArmies[index1].resetLightmap(curLightmapIdx2);
        ++index1;
        skillWorkingList >>= 1;
      }
      ulong num = this.m_SkillWorkingList >> 32;
      int index2 = 0;
      while (index2 < (int) this.defenserCount)
      {
        if ((num & 1UL) > 0UL)
          this.defenserArmies[index2].resetLightmap(curLightmapIdx2);
        ++index2;
        num >>= 1;
      }
    }
  }

  private void playBrokenFO(byte idx, Transform trans)
  {
    if ((int) idx >= this.m_BrokenFO.Length || this.m_BrokenFO[(int) idx] == null)
      return;
    for (int index = 0; index < this.m_BrokenFO[(int) idx].Length; ++index)
    {
      if (!this.m_BrokenFO[(int) idx][index].transform.gameObject.activeSelf)
      {
        this.m_BrokenFO[(int) idx][index].Play(trans);
        break;
      }
    }
  }

  private void playBrokenFO(byte idx, Vector3 pos, Vector3 dir)
  {
    if ((int) idx >= this.m_BrokenFO.Length || this.m_BrokenFO[(int) idx] == null)
      return;
    for (int index = 0; index < this.m_BrokenFO[(int) idx].Length; ++index)
    {
      if (!this.m_BrokenFO[(int) idx][index].transform.gameObject.activeSelf)
      {
        this.m_BrokenFO[(int) idx][index].Play(pos, dir);
        break;
      }
    }
  }

  private void playBrokenFO(byte idx, Vector3 pos, Quaternion qua)
  {
    if ((int) idx >= this.m_BrokenFO.Length || this.m_BrokenFO[(int) idx] == null)
      return;
    for (int index = 0; index < this.m_BrokenFO[(int) idx].Length; ++index)
    {
      if (!this.m_BrokenFO[(int) idx][index].transform.gameObject.activeSelf)
      {
        this.m_BrokenFO[(int) idx][index].Play(pos, qua);
        break;
      }
    }
  }

  private void playCollapse()
  {
    if (this.SiegeMode < 4)
    {
      for (int index = 0; index < 4; ++index)
      {
        int defenserArmies = (int) this.defenserArmiesMap[1, index];
        if (defenserArmies != 0 && this.defenserArmies[defenserArmies - 1] != null)
        {
          float x = WarManager.InitPositionRight_SiegeMode[1, index, 0];
          float z = WarManager.InitPositionRight_SiegeMode[1, index, 1];
          this.defenserArmies[defenserArmies - 1].setPosition(new Vector3(x, 0.0f, z), new Vector3(-1000f, 0.0f, z), (byte) 0);
        }
      }
    }
    for (int index = 0; index < this.attackerArmies.Length; ++index)
    {
      if (this.attackerArmies[index] != null)
      {
        this.attackerArmies[index].State = ArmyGroup.EGROUPSTATE.IDLE_WITHOUT_CLUMP;
        if (this.attackerArmies[index].heroSoldier != null)
          this.attackerArmies[index].setLordAnimEnable(false);
      }
    }
    for (int index = 0; index < this.defenserArmies.Length; ++index)
    {
      if (this.defenserArmies[index] != null)
      {
        this.defenserArmies[index].bAttackMode = true;
        if (this.defenserArmies[index].HasHeroDisplay)
        {
          this.defenserArmies[index].heroSoldier.transform.position = this.defenserArmies[index].groupRoot.TransformPoint(this.defenserArmies[index].HeroOffset);
          this.defenserArmies[index].heroSoldier.transform.rotation = this.defenserArmies[index].groupRoot.rotation;
          this.defenserArmies[index].heroSoldier.ResetAnimToIdle();
          this.defenserArmies[index].setLordAnimEnable(false);
        }
      }
    }
    for (int index = 0; index < this.defenserHeroIdCache.Count; ++index)
    {
      if ((int) this.defenserHeroIdCache[index] == (int) this.defenserLordID)
      {
        this.defenserHeroCache[index].transform.position = this.nonUseHeroPos_Right_SiegeMode[index];
        break;
      }
    }
    this.setOutsideHeroAnimEnable(false);
    if (this.AttackSoundKey != (byte) 21)
    {
      this.audioMgr.StopSFX(this.AttackSoundKey);
      this.AttackSoundKey = (byte) 21;
    }
    else if (this.MovingSoundKey != (byte) 21)
    {
      this.audioMgr.StopSFX(this.MovingSoundKey);
      this.MovingSoundKey = (byte) 21;
    }
    this.SiegeMode = 1;
    FSMManager.Instance.bIsSiegeMode = false;
    DataManager.Instance.NowValue_War[2] = 0L;
    this.UIUpdateFlag |= 4;
    if (DataManager.Instance.WarMoraleValue[1] != 0UL)
    {
      this.CaleWarMorale((byte) 1, this.TrapsHp);
    }
    else
    {
      DataManager.Instance.WarMorale[1] = 0;
      this.UIUpdateFlag |= 2;
    }
    DataManager.Instance.NowValue_War[1] -= (long) this.LastTrapsHp;
    DataManager.Instance.NowValue_War[1] = Math.Max(0L, DataManager.Instance.NowValue_War[1]);
    this.UIUpdateFlag |= 2;
    this.uiBattle.AddCenterMsg((ushort) 499, this.actionKind != EPlayerActionKind.ATTACKER ? (byte) 0 : (byte) 1);
    this.FOMgr.recoverSpecialArrow();
    this.m_WarState = WarManager.WarState.CASTLE_DESTROYING;
  }

  private void setOutsideHeroAnimEnable(bool bEnable)
  {
    float num = !bEnable ? 0.0f : 1f;
    for (int index = 0; index < this.attackerHeroCache.Count; ++index)
    {
      Animation animComponent = this.attackerHeroCache[index].getAnimComponent();
      if ((UnityEngine.Object) animComponent != (UnityEngine.Object) null)
      {
        animComponent["idle"].speed = num;
        animComponent["victory"].speed = num;
      }
    }
    for (int index = 0; index < this.defenserHeroCache.Count; ++index)
    {
      Animation animComponent = this.defenserHeroCache[index].getAnimComponent();
      if ((UnityEngine.Object) animComponent != (UnityEngine.Object) null)
      {
        animComponent["idle"].speed = num;
        animComponent["victory"].speed = num;
      }
    }
  }

  private void PlayCheerSound()
  {
    if (this.AttackSoundKey < (byte) 21)
    {
      this.audioMgr.StopSFX(this.AttackSoundKey);
      this.AttackSoundKey = (byte) 21;
    }
    if (this.MovingSoundKey != (byte) 21)
    {
      this.audioMgr.StopSFX(this.MovingSoundKey);
      this.MovingSoundKey = (byte) 21;
    }
    this.movingSoundParentTrans.position = this.CageTargetPos;
    this.audioMgr.PlaySFXLoop((ushort) 20014, out this.AttackSoundKey, this.movingSoundParentTrans);
  }

  private void CageUpdate(float deltaTime)
  {
    if (this.CageState == (byte) 1)
    {
      FSMManager instance = FSMManager.Instance;
      if (instance.CaptivingCount < instance.MaxCaptiver)
        return;
      this.LordCage.gameObject.SetActive(true);
      this.LordCage.position = this.CageTargetPos + new Vector3(0.0f, 20f, 0.0f);
      this.particleMgr.Spawn((ushort) 2015, (Transform) null, this.CageTargetPos, 1f, true, false);
      this.PlayCheerSound();
      this.audioMgr.PlaySFX((ushort) 20013, PlayObj: this.LordCage);
      this.CageTimer = 0.0f;
      this.CageState = (byte) 2;
    }
    else if (this.CageState == (byte) 2)
    {
      float num = (float) (150.0 + 2000.0 * (double) this.CageTimer * (double) this.CageTimer);
      this.CageTimer += deltaTime;
      this.LordCage.position = Vector3.MoveTowards(this.LordCage.position, this.CageTargetPos, num * deltaTime);
      if (!(this.LordCage.position == this.CageTargetPos))
        return;
      this.CageTimer = 0.0f;
      this.CageState = (byte) 3;
    }
    else
    {
      if (this.CageState != (byte) 3)
        return;
      this.LordCage.position = this.CageTargetPos + new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(0.0f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f));
      this.CageTimer += deltaTime;
      if ((double) this.CageTimer <= 0.20000000298023224)
        return;
      this.CageState = (byte) 0;
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 4, this.m_WarResult != EWarResult.WIN ? (this.actionKind != EPlayerActionKind.ATTACKER ? 1 : 3) : (this.actionKind != EPlayerActionKind.ATTACKER ? 3 : 1));
    }
  }

  public void SetWarCameraModel()
  {
    if (this.WCamera == null || this.WCamera.CoordCamMode)
      return;
    this.CameraModel = this.CameraModel != (byte) 0 ? (byte) 0 : (byte) 1;
    this.WCamera.initCamera(this.attackerArmies, (int) this.attackerCount, this.defenserArmies, (int) this.defenserCount);
  }

  public void CheckSound()
  {
    if (((int) this.SoundDirtyFlag & 4) != 0 && this.rangeSoundParent != null)
    {
      this.audioMgr.PlaySFX((ushort) 20005, PlayObj: this.rangeSoundParent.groupRoot);
      this.audioMgr.PlaySFX((ushort) 20007, UnityEngine.Random.Range(0.0f, 0.45f), PlayObj: this.rangeSoundParent.groupRoot);
      this.rangeSoundParent = (ArmyGroup) null;
      this.rangeDist_Sound = new float?();
    }
    if (((int) this.SoundDirtyFlag & 8) != 0 && this.stoneHitSoundParent != null)
    {
      this.audioMgr.PlaySFX((ushort) 20001, PlayObj: this.stoneHitSoundParent.groupRoot);
      this.audioMgr.PlaySFX((ushort) UnityEngine.Random.Range(20002, 20005), 0.25f, PlayObj: this.stoneHitSoundParent.groupRoot);
      this.stoneHitSoundParent = (ArmyGroup) null;
      this.stoneHitDist_Sound = new float?();
    }
    if (((int) this.SoundDirtyFlag & 1) != 0)
    {
      this.audioMgr.PlaySFXLoop((ushort) 20012, out this.MovingSoundKey, this.movingSoundParentTrans);
      this.movingSoundParent = (ArmyGroup) null;
      this.movingDist_Sound = new float?();
    }
    if (((int) this.SoundDirtyFlag & 2) == 0 || this.attackSoundParent == null)
      return;
    this.audioMgr.PlaySFXLoop((ushort) 20011, out this.AttackSoundKey, this.attackSoundParent.groupRoot);
    this.attackSoundParent = (ArmyGroup) null;
    this.attackDist_Sound = new float?();
  }

  public void CloseDrama()
  {
    if (!this.bDramaWorking)
      return;
    this.bDramaWorking = false;
    if ((UnityEngine.Object) this.controlPanel != (UnityEngine.Object) null)
      ((Component) this.controlPanel).gameObject.SetActive(true);
    if (this.NewbieWarFlag == (byte) 0 || this.DramaTriggerFlag != 0U)
      return;
    DataManager.Instance.battleInfo.RandomGap = (ushort) 1;
    DataManager.Instance.battleInfo.RandomSeed = (ushort) 1;
    DataManager.Instance.battleInfo.BattleType = (byte) 4;
    DataManager.Instance.battleInfo.StageKind = (byte) 0;
    DataManager.Instance.battleInfo.StageID = (ushort) 0;
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.WarToBattle);
  }

  public void SetCoordDirty()
  {
    if (WarManager.CoordSimuIndex_Left > (ushort) 5 || WarManager.TroopKindSimuIndex_Right > (ushort) 3)
      return;
    for (int index1 = 0; index1 < 4; ++index1)
    {
      for (int index2 = 0; index2 < 4; ++index2)
      {
        WarManager.InitPositionLeft[index1, index2, 0] = 0.0f;
        WarManager.InitPositionLeft[index1, index2, 1] = 0.0f;
        WarManager.InitPositionLeft_SiegeMode[index1, index2, 0] = 0.0f;
        WarManager.InitPositionLeft_SiegeMode[index1, index2, 1] = 0.0f;
        WarManager.InitPositionRight[index1, index2, 0] = 0.0f;
        WarManager.InitPositionRight[index1, index2, 1] = 0.0f;
        if (index1 == 1)
        {
          WarManager.InitPositionRight_SiegeMode[index1, index2, 0] = 0.0f;
          WarManager.InitPositionRight_SiegeMode[index1, index2, 1] = 0.0f;
        }
        else
        {
          WarManager.InitPositionRight_SiegeMode[index1, index2, 0] = 0.0f;
          WarManager.InitPositionRight_SiegeMode[index1, index2, 1] = 0.0f;
        }
        if (index1 < 3)
        {
          WarManager.ActionPositionRight[index1, index2, 0] = 0.0f;
          WarManager.ActionPositionRight[index1, index2, 1] = 0.0f;
        }
      }
    }
    DataManager instance = DataManager.Instance;
    WarManager.LoadLeftCoordDisplayData();
    WarManager.LoadRightCoordDisplayData();
    WarManager.SetupCoordinate((int) WarManager.CoordSimuIndex_Left, (int) WarManager.TroopKindSimuIndex_Right);
    this.BSUtil.InitCSSimulator(instance.War_RndSeed, instance.War_RndGap);
    int num = (int) this.loadWarInfo(true);
    if ((int) WarManager.WarCoordIndex_Left != (int) WarManager.CoordSimuIndex_Left)
    {
      for (int index3 = 0; index3 < 4; ++index3)
      {
        for (int index4 = 0; index4 < 4; ++index4)
        {
          if (this.attackerArmiesMap[index3, index4] != (byte) 0 && this.attackerArmies[(int) this.attackerArmiesMap[index3, index4] - 1] != null)
            this.attackerArmies[(int) this.attackerArmiesMap[index3, index4] - 1].setPositionAndMove(WarManager.InitPositionLeft[index3, index4, 0], WarManager.InitPositionLeft[index3, index4, 1]);
        }
      }
    }
    if ((int) WarManager.WarCoordIndex_Right != (int) WarManager.TroopKindSimuIndex_Right)
    {
      for (int index5 = 0; index5 < 4; ++index5)
      {
        for (int index6 = 0; index6 < 4; ++index6)
        {
          if (this.defenserArmiesMap[index5, index6] != (byte) 0 && this.defenserArmies[(int) this.defenserArmiesMap[index5, index6] - 1] != null)
            this.defenserArmies[(int) this.defenserArmiesMap[index5, index6] - 1].setPositionAndMove(WarManager.InitPositionRight[index5, index6, 0], WarManager.InitPositionRight[index5, index6, 1]);
        }
      }
    }
    AudioManager.Instance.PlaySFX((ushort) 40016);
    WarManager.WarCoordIndex_Left = WarManager.CoordSimuIndex_Left;
    WarManager.WarCoordIndex_Right = WarManager.TroopKindSimuIndex_Right;
    int Index = (int) WarManager.CoordSimuIndex_Left * 3 + (int) WarManager.TroopKindSimuIndex_Right;
    CoordResultData recordByIndex = instance.CoordResultTable.GetRecordByIndex(Index);
    WarManager.MoraleInfo.WinnerSide = recordByIndex.Left_TotalLose >= recordByIndex.Right_TotalLose ? (byte) 2 : (byte) 1;
    WarManager.MoraleInfo.bWallDown = (byte) 0;
    WarManager.MoraleInfo.bEliminate = (byte) 0;
    WarManager.MoraleInfo.AssaultLostForce = recordByIndex.Left_TotalLose;
    WarManager.MoraleInfo.DefenceLostForce = recordByIndex.Right_TotalLose;
    WarManager.CheckMorale();
  }

  public void StartTestCoordWar()
  {
    if (this.m_WarState != WarManager.WarState.CHANGE_COORD_MODE)
      return;
    for (int index1 = 0; index1 < 4; ++index1)
    {
      for (int index2 = 0; index2 < 4; ++index2)
      {
        if (this.attackerArmiesMap[index1, index2] != (byte) 0 && this.attackerArmies[(int) this.attackerArmiesMap[index1, index2] - 1] != null)
          this.attackerArmies[(int) this.attackerArmiesMap[index1, index2] - 1].setPositionInstantlyIgnoreHeroAndAxisY(WarManager.InitPositionLeft[index1, index2, 0], WarManager.InitPositionLeft[index1, index2, 1], Vector3.right);
      }
    }
    for (int index3 = 0; index3 < 4; ++index3)
    {
      for (int index4 = 0; index4 < 4; ++index4)
      {
        if (this.defenserArmiesMap[index3, index4] != (byte) 0 && this.defenserArmies[(int) this.defenserArmiesMap[index3, index4] - 1] != null)
          this.defenserArmies[(int) this.defenserArmiesMap[index3, index4] - 1].setPositionInstantlyIgnoreHeroAndAxisY(WarManager.InitPositionRight[index3, index4, 0], WarManager.InitPositionRight[index3, index4, 1], Vector3.left);
      }
    }
    this.m_WarState = WarManager.WarState.WAITING_FOR_START;
  }

  public static byte TerrainKind_S_To_C(byte tk)
  {
    if (tk == (byte) 2)
      return 3;
    return tk == (byte) 3 ? (byte) 2 : (byte) 1;
  }

  public static void UpdateLocalTimeToTheme(long time = 0)
  {
    DataManager instance = DataManager.Instance;
    if (time == 0L)
      time = instance.ServerTime;
    int hour = GameConstants.GetDateTime(time).Hour;
    if (hour >= 14 && hour < 20)
      instance.War_MapTheme = (byte) 2;
    else if (hour >= 20 || hour < 5)
      instance.War_MapTheme = (byte) 3;
    else
      instance.War_MapTheme = (byte) 1;
  }

  public static void SetupCoordinate(int LeftCoordIndex, int RightCoordIndex)
  {
    Debug.Log((object) ("LeftCoordIndex: " + LeftCoordIndex.ToString() + " RightCoordIndex: " + RightCoordIndex.ToString()));
    int Index1 = LeftCoordIndex * 16;
    int Index2 = RightCoordIndex * 16;
    for (int index1 = 0; index1 < 4; ++index1)
    {
      for (int index2 = 0; index2 < 4; ++index2)
      {
        CoordData recordByIndex1 = DataManager.Instance.CoordTable.GetRecordByIndex(Index1);
        WarManager.InitPositionLeft[index1, index2, 0] = (float) recordByIndex1.AtkX * 0.01f;
        WarManager.InitPositionLeft[index1, index2, 1] = (float) ((int) recordByIndex1.AtkY - 200) * 0.01f;
        WarManager.InitPositionLeft_SiegeMode[index1, index2, 0] = (float) recordByIndex1.SiegeAtkX * 0.01f;
        WarManager.InitPositionLeft_SiegeMode[index1, index2, 1] = (float) ((int) recordByIndex1.SiegeAtkY - 200) * 0.01f;
        ++Index1;
        CoordData recordByIndex2 = DataManager.Instance.CoordTable.GetRecordByIndex(Index2);
        WarManager.InitPositionRight[index1, index2, 0] = (float) recordByIndex2.DefX * 0.01f;
        WarManager.InitPositionRight[index1, index2, 1] = (float) ((int) recordByIndex2.DefY - 200) * 0.01f;
        if (index1 == 1)
        {
          WarManager.InitPositionRight_SiegeMode[index1, index2, 0] = (float) recordByIndex2.SiegeRangeNoWallDefX * 0.01f;
          WarManager.InitPositionRight_SiegeMode[index1, index2, 1] = (float) ((int) recordByIndex2.SiegeRangeNoWallDefY - 200) * 0.01f;
        }
        else
        {
          WarManager.InitPositionRight_SiegeMode[index1, index2, 0] = (float) recordByIndex2.SiegeDefX * 0.01f;
          WarManager.InitPositionRight_SiegeMode[index1, index2, 1] = (float) ((int) recordByIndex2.SiegeDefY - 200) * 0.01f;
        }
        if (index1 < 3)
        {
          WarManager.ActionPositionRight[index1, index2, 0] = (float) recordByIndex2.Siege23DefX * 0.01f;
          WarManager.ActionPositionRight[index1, index2, 1] = (float) ((int) recordByIndex2.Siege23DefY - 200) * 0.01f;
        }
        ++Index2;
      }
    }
    BSInvokeUtil.getInstance.SetCoordData((ushort) LeftCoordIndex, (ushort) RightCoordIndex);
  }

  public static void RecvFastStartNpcWar(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    WarManager.MoraleInfo.WinnerSide = MP.ReadByte();
    WarManager.MoraleInfo.bEliminate = MP.ReadByte();
    WarManager.MoraleInfo.bWallDown = MP.ReadByte();
    WarManager.MoraleInfo.AssaultLostForce = MP.ReadUInt();
    WarManager.MoraleInfo.DefenceLostForce = MP.ReadUInt();
    WarManager.RecvStartNpcWar(MP);
    WarManager.CheckMorale();
  }

  public static void RecvStartNpcWar(MessagePacket MP)
  {
    DataManager.Instance.War_MapTheme = (byte) 3;
    WarManager.RecvStartWar(MP);
    WarManager.NpcModeEnable = (byte) 1;
  }

  public static void RecvStartWar(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    WarManager.NpcModeEnable = (byte) 0;
    instance.War_RndSeed = MP.ReadUShort();
    instance.War_RndGap = (ushort) MP.ReadByte();
    instance.War_LordCapture = MP.ReadByte();
    instance.War_MapKind = (ushort) WarManager.TerrainKind_S_To_C(MP.ReadByte());
    if (WarManager.CurrentPointKind == POINT_KIND.PK_YOLK)
      instance.War_MapKind = (ushort) 4;
    WarManager.CurrentPointKind = POINT_KIND.PK_NONE;
    instance.War_LeftCastleLv = MP.ReadByte();
    instance.War_LeftHeroNum = MP.ReadByte();
    int index1 = (int) MP.ReadByte();
    for (int index2 = 0; index2 < 5; ++index2)
    {
      instance.pLeftLeaderData[index2].HeroID = MP.ReadUShort();
      instance.pLeftLeaderData[index2].Rank = MP.ReadByte();
      instance.pLeftLeaderData[index2].Star = MP.ReadByte();
    }
    for (int index3 = 0; index3 < 4; ++index3)
    {
      for (int index4 = 0; index4 < 4; ++index4)
        instance.pLeftTroopForce[index3, index4] = MP.ReadUInt();
    }
    for (int index5 = 0; index5 < 4; ++index5)
      instance.War_LeftAttackAttr[index5] = MP.ReadUInt();
    for (int index6 = 0; index6 < 4; ++index6)
      instance.War_LeftDefenseAttr[index6] = MP.ReadUInt();
    for (int index7 = 0; index7 < 4; ++index7)
      instance.War_LeftHealthAttr[index7] = MP.ReadUInt();
    instance.War_LeftLordID = index1 >= 5 ? (ushort) 0 : instance.pLeftLeaderData[index1].HeroID;
    WarManager.WarCoordIndex_Left = (ushort) MP.ReadByte();
    instance.War_RightCastleLv = MP.ReadByte();
    instance.War_RightHeroNum = MP.ReadByte();
    int index8 = (int) MP.ReadByte();
    for (int index9 = 0; index9 < 5; ++index9)
    {
      instance.pRightLeaderData[index9].HeroID = MP.ReadUShort();
      instance.pRightLeaderData[index9].Rank = MP.ReadByte();
      instance.pRightLeaderData[index9].Star = MP.ReadByte();
    }
    for (int index10 = 0; index10 < 4; ++index10)
    {
      for (int index11 = 0; index11 < 4; ++index11)
        instance.pRightTroopForce[index10, index11] = MP.ReadUInt();
    }
    for (int index12 = 0; index12 < 4; ++index12)
      instance.War_RightAttackAttr[index12] = MP.ReadUInt();
    for (int index13 = 0; index13 < 4; ++index13)
      instance.War_RightDefenseAttr[index13] = MP.ReadUInt();
    for (int index14 = 0; index14 < 4; ++index14)
      instance.War_RightHealthAttr[index14] = MP.ReadUInt();
    instance.War_RightLordID = index8 >= 5 ? (ushort) 0 : instance.pRightLeaderData[index8].HeroID;
    WarManager.WarCoordIndex_Right = (ushort) MP.ReadByte();
    instance.bSiege = MP.ReadByte();
    if (instance.bSiege != (byte) 0)
    {
      instance.CurWallHp = MP.ReadUInt();
      instance.MaxWallHp = MP.ReadUInt();
      instance.War_WallLevel = MP.ReadByte();
      for (int index15 = 0; index15 < 3; ++index15)
      {
        for (int index16 = 0; index16 < 4; ++index16)
          instance.pCastleInfo[index15, index16] = MP.ReadUInt();
      }
      instance.War_WallAttr.TrapAttack = MP.ReadUInt();
      instance.War_WallAttr.TrapDefence = MP.ReadUInt();
      instance.War_WallAttr.TrapHealth = MP.ReadUInt();
      instance.War_WallAttr.WallHealth = MP.ReadUInt();
    }
    ushort[] battleHeroID = new ushort[10];
    for (int index17 = 0; index17 < 5; ++index17)
      battleHeroID[index17] = instance.pLeftLeaderData[index17].HeroID;
    for (int index18 = 0; index18 < 5; ++index18)
      battleHeroID[index18 + 5] = instance.pRightLeaderData[index18].HeroID;
    if (!instance.CheckHeroBattleResourceReady(HeroFightType.LegionBatte, battleHeroID))
    {
      GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8350U), (ushort) byte.MaxValue);
    }
    else
    {
      instance.DramaTriggerFlag = 0U;
      instance.WarType = (byte) 0;
      GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MapToWar);
    }
  }

  public static void setupStageWar(byte Res)
  {
    DataManager instance = DataManager.Instance;
    StageManager stageDataController = DataManager.StageDataController;
    ushort num = (ushort) ((uint) DataManager.StageDataController.StageRecord[2] + 1U);
    CorpsStage recordByKey1 = DataManager.StageDataController.CorpsStageTable.GetRecordByKey(num);
    CorpsStageBattle recordByKey2 = DataManager.StageDataController.CorpsStageBattleTable.GetRecordByKey(num);
    instance.War_MapKind = recordByKey2.Terrain != (byte) 0 ? (ushort) recordByKey2.Terrain : (ushort) 1;
    instance.War_MapTheme = recordByKey2.Weather != (byte) 0 ? recordByKey2.Weather : (byte) 1;
    instance.PlayerName_War[0].ClearString();
    instance.PlayerName_War[0].Append(instance.RoleAttr.Name);
    instance.PlayerName_War[1].ClearString();
    instance.PlayerName_War[1].Append(instance.mStringTable.GetStringByID((uint) recordByKey1.LordTile));
    instance.AllianceTag_War[0].ClearString();
    if (instance.RoleAlliance.Id > 0U)
      instance.AllianceTag_War[0].Append(instance.RoleAlliance.Tag);
    instance.AllianceTag_War[1].ClearString();
    instance.KindomID_War[0] = (ushort) 0;
    instance.KindomID_War[1] = (ushort) 0;
    WarManager.WarCoordIndex_Left = (ushort) instance.RoleAttr.NowArmyCoordIndex;
    WarManager.WarCoordIndex_Right = (ushort) 0;
    Array.Clear((Array) instance.War_LeftAttackAttr, 0, instance.War_LeftAttackAttr.Length);
    Array.Clear((Array) instance.War_LeftDefenseAttr, 0, instance.War_LeftDefenseAttr.Length);
    Array.Clear((Array) instance.War_LeftHealthAttr, 0, instance.War_LeftHealthAttr.Length);
    Array.Clear((Array) instance.pRightTroopForce, 0, instance.pRightTroopForce.Length);
    Array.Clear((Array) instance.pCastleInfo, 0, instance.pCastleInfo.Length);
    Array.Clear((Array) instance.War_RightAttackAttr, 0, instance.War_RightAttackAttr.Length);
    Array.Clear((Array) instance.War_RightDefenseAttr, 0, instance.War_RightDefenseAttr.Length);
    Array.Clear((Array) instance.War_RightHealthAttr, 0, instance.War_RightHealthAttr.Length);
    for (int index = 0; index < 5; ++index)
      instance.pRightLeaderData[index] = new TroopLeaderType();
    instance.War_RightCastleLv = recordByKey2.WallLevel;
    instance.CurWallHp = stageDataController.CorpsStageWallDefence;
    instance.MaxWallHp = recordByKey2.MaxWall;
    instance.bSiege = recordByKey2.WallLevel <= (byte) 0 ? (byte) 0 : (byte) 1;
    instance.War_WallLevel = recordByKey2.WallLevel;
    instance.War_RightHeroNum = (byte) 0;
    for (int index = 0; index < 5; ++index)
    {
      instance.pRightLeaderData[index].HeroID = recordByKey1.Heros[index].HeroID;
      instance.pRightLeaderData[index].Rank = recordByKey1.Heros[index].Rank;
      instance.pRightLeaderData[index].Star = recordByKey1.Heros[index].Star;
      if (recordByKey1.Heros[index].HeroID != (ushort) 0)
        ++instance.War_RightHeroNum;
    }
    instance.War_RightLordID = instance.pRightLeaderData[0].HeroID;
    instance.War_LeftLordID = instance.RoleAttr.Head;
    for (int index = 0; index < 10; ++index)
    {
      byte soldierTableId = stageDataController.NowCombatStageInfo[index].SoldierTableID;
      uint amount = stageDataController.NowCombatStageInfo[index].Amount;
      if (soldierTableId != (byte) 0)
      {
        if (soldierTableId <= (byte) 16)
          instance.pRightTroopForce[((int) soldierTableId - 1) / 4, ((int) soldierTableId - 1) % 4] = amount;
        else if (soldierTableId <= (byte) 20)
          instance.pCastleInfo[0, (int) soldierTableId - 17] = amount;
        else if (soldierTableId <= (byte) 24)
          instance.pCastleInfo[1, (int) soldierTableId - 21] = amount;
        else if (soldierTableId <= (byte) 28)
          instance.pCastleInfo[2, (int) soldierTableId - 25] = amount;
      }
    }
    BSInvokeUtil.getInstance.getCombatStageAttr((byte) num, instance.RoleAttr.Head, instance.War_LeftHeroNum, instance.pLeftLeaderData, instance.AttribVal.BaseVal_Total, instance.AttribVal.GetLordBaseVal(), instance.War_LeftAttackAttr, instance.War_LeftDefenseAttr, instance.War_LeftHealthAttr, instance.War_RightAttackAttr, instance.War_RightDefenseAttr, instance.War_RightHealthAttr, ref instance.War_WallAttr, DataManager.Instance.bHaveWarBuff);
    instance.DramaTriggerFlag = (uint) recordByKey1.BattleEndword << 16 | (uint) recordByKey1.BattleForeword;
    if (((int) stageDataController.isNotFirstInLine[2] & 1) != 0)
      instance.DramaTriggerFlag &= 4294901760U;
    else
      stageDataController.isNotFirstInLine[2] |= (byte) 1;
    if (Res == (byte) 0)
      instance.DramaTriggerFlag &= (uint) ushort.MaxValue;
    else
      stageDataController.isNotFirstInLine[2] &= (byte) 254;
  }

  public static void RecvFastStartWar(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    WarManager.MoraleInfo.WinnerSide = MP.ReadByte();
    WarManager.MoraleInfo.bEliminate = MP.ReadByte();
    WarManager.MoraleInfo.bWallDown = MP.ReadByte();
    WarManager.MoraleInfo.AssaultLostForce = MP.ReadUInt();
    WarManager.MoraleInfo.DefenceLostForce = MP.ReadUInt();
    WarManager.RecvStartWar(MP);
    WarManager.CheckMorale();
  }

  public static void RecvStartStageWar(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Expedition);
    byte Res = MP.ReadByte();
    byte targetLv = 0;
    byte beginLv = 0;
    bool flag = false;
    if (Res < (byte) 2)
    {
      DataManager instance = DataManager.Instance;
      StageManager stageDataController = DataManager.StageDataController;
      WarManager.NpcModeEnable = (byte) 0;
      instance.War_LordCapture = (byte) 0;
      instance.bWarAttacker = true;
      instance.lastBattleResult = (short) Res;
      instance.War_RndSeed = MP.ReadUShort();
      instance.War_RndGap = (ushort) MP.ReadByte();
      WarManager.setupStageWar(Res);
      instance.SoldierTotal = 0L;
      instance.HospitalTotal = 0U;
      for (int index = 0; index < 16; ++index)
      {
        instance.RoleAttr.m_Soldier[index] = MP.ReadUInt();
        instance.SoldierTotal += (long) instance.RoleAttr.m_Soldier[index];
      }
      for (int index = 0; index < 16; ++index)
      {
        instance.mSoldier_Hospital[index] = MP.ReadUInt();
        instance.HospitalTotal += instance.mSoldier_Hospital[index];
      }
      instance.Resource[0].SetResource(MP.ReadUInt(), MP.ReadLong());
      stageDataController.UpdateCorpsStageInfo(MP);
      WarManager.MoraleInfo.WinnerSide = MP.ReadByte();
      WarManager.MoraleInfo.bEliminate = MP.ReadByte();
      WarManager.MoraleInfo.bWallDown = MP.ReadByte();
      WarManager.MoraleInfo.AssaultLostForce = MP.ReadUInt();
      WarManager.MoraleInfo.DefenceLostForce = MP.ReadUInt();
      instance.KingOldLv = instance.RoleAttr.Level;
      stageDataController.RoleAttrLevelUp(MP);
      for (int index = 0; index < 5; ++index)
      {
        ushort num = MP.ReadUShort();
        beginLv = instance.UpdateHeroAttr(num, MP);
        if (num != (ushort) 0 && instance.curHeroData.ContainsKey((uint) num))
        {
          targetLv = instance.curHeroData[(uint) num].Level;
          if ((int) targetLv > (int) beginLv)
          {
            flag = true;
            GUIManager.Instance.AddHerodLvUpData(num, beginLv, targetLv);
          }
        }
      }
      if (flag && (int) targetLv > (int) beginLv)
      {
        if (!GUIManager.Instance.bOpenHeroLvUp)
        {
          GUIManager.Instance.QueuedUI_Restricted(EGUIWindow.UI_HeroUp, openMode: (byte) 0);
          GUIManager.Instance.bOpenHeroLvUp = true;
        }
        else
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroUp, 0);
      }
      WarManager.CheckMorale();
      instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Inner, byte.MaxValue);
      instance.WarType = (byte) 1;
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Expedition, 1);
    }
    else
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7226U), (ushort) byte.MaxValue);
      GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Expedition);
    }
  }

  public static void StartWar(
    byte Result,
    bool isAttacker,
    ushort RndSeed,
    byte RndGap,
    ref CombatPlayerData attacker,
    ref CombatPlayerData defencer)
  {
    DataManager instance = DataManager.Instance;
    instance.bWarAttacker = isAttacker;
    instance.KindomID_War[0] = attacker.KingdomID;
    instance.KindomID_War[1] = defencer.KingdomID;
    instance.PlayerName_War[0].ClearString();
    instance.PlayerName_War[0].Append(attacker.Name);
    instance.PlayerName_War[1].ClearString();
    instance.PlayerName_War[1].Append(defencer.Name);
    instance.AllianceTag_War[0].ClearString();
    instance.AllianceTag_War[0].Append(attacker.AllianceTag);
    instance.AllianceTag_War[1].ClearString();
    instance.AllianceTag_War[1].Append(defencer.AllianceTag);
    WarManager.NpcModeEnable = (byte) 0;
    instance.War_RndSeed = RndSeed;
    instance.War_RndGap = (ushort) RndGap;
    instance.War_LordCapture = (byte) 0;
    instance.War_MapKind = (ushort) 1;
    instance.War_LeftCastleLv = attacker.StrongholdLevel;
    instance.War_LeftHeroNum = (byte) 0;
    int index1 = 5;
    for (int index2 = 0; index2 < 5; ++index2)
    {
      instance.pLeftLeaderData[index2].HeroID = attacker.HeroInfo[index2].ID;
      instance.pLeftLeaderData[index2].Rank = attacker.HeroInfo[index2].Rank;
      instance.pLeftLeaderData[index2].Star = attacker.HeroInfo[index2].Star;
      if (instance.pLeftLeaderData[index2].HeroID != (ushort) 0)
        ++instance.War_LeftHeroNum;
      if ((int) instance.pLeftLeaderData[index2].HeroID == (int) attacker.Head)
        index1 = index2;
    }
    for (int index3 = 0; index3 < 4; ++index3)
    {
      for (int index4 = 0; index4 < 4; ++index4)
        instance.pLeftTroopForce[index3, index4] = attacker.SurviveTroop[index3 * 4 + index4] + attacker.DeadTroop[index3 * 4 + index4];
    }
    for (int index5 = 0; index5 < 4; ++index5)
      instance.War_LeftAttackAttr[index5] = attacker.AttackAttr[index5];
    for (int index6 = 0; index6 < 4; ++index6)
      instance.War_LeftDefenseAttr[index6] = attacker.DefenceAttr[index6];
    for (int index7 = 0; index7 < 4; ++index7)
      instance.War_LeftHealthAttr[index7] = attacker.HealthAttr[index7];
    instance.War_LeftLordID = index1 >= 5 ? (ushort) 0 : instance.pLeftLeaderData[index1].HeroID;
    WarManager.WarCoordIndex_Left = (ushort) attacker.ArmyCoordIndex;
    instance.War_RightCastleLv = defencer.StrongholdLevel;
    instance.War_RightHeroNum = (byte) 0;
    int index8 = 5;
    for (int index9 = 0; index9 < 5; ++index9)
    {
      instance.pRightLeaderData[index9].HeroID = defencer.HeroInfo[index9].ID;
      instance.pRightLeaderData[index9].Rank = defencer.HeroInfo[index9].Rank;
      instance.pRightLeaderData[index9].Star = defencer.HeroInfo[index9].Star;
      if (instance.pRightLeaderData[index9].HeroID != (ushort) 0)
        ++instance.War_RightHeroNum;
      if ((int) instance.pRightLeaderData[index9].HeroID == (int) defencer.Head)
        index8 = index9;
    }
    for (int index10 = 0; index10 < 4; ++index10)
    {
      for (int index11 = 0; index11 < 4; ++index11)
        instance.pRightTroopForce[index10, index11] = defencer.SurviveTroop[index10 * 4 + index11] + defencer.DeadTroop[index10 * 4 + index11];
    }
    for (int index12 = 0; index12 < 4; ++index12)
      instance.War_RightAttackAttr[index12] = defencer.AttackAttr[index12];
    for (int index13 = 0; index13 < 4; ++index13)
      instance.War_RightDefenseAttr[index13] = defencer.DefenceAttr[index13];
    for (int index14 = 0; index14 < 4; ++index14)
      instance.War_RightHealthAttr[index14] = defencer.HealthAttr[index14];
    instance.War_RightLordID = index8 >= 5 ? (ushort) 0 : instance.pRightLeaderData[index8].HeroID;
    WarManager.WarCoordIndex_Right = (ushort) defencer.ArmyCoordIndex;
    instance.bSiege = (byte) 0;
    ushort[] battleHeroID = new ushort[10];
    for (int index15 = 0; index15 < 5; ++index15)
      battleHeroID[index15] = instance.pLeftLeaderData[index15].HeroID;
    for (int index16 = 0; index16 < 5; ++index16)
      battleHeroID[index16 + 5] = instance.pRightLeaderData[index16].HeroID;
    WarManager.CheckMorale(Result, ref attacker, ref defencer);
    if (!instance.CheckHeroBattleResourceReady(HeroFightType.LegionBatte, battleHeroID))
    {
      GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8350U), (ushort) byte.MaxValue);
    }
    else
    {
      instance.DramaTriggerFlag = 0U;
      instance.WarType = (byte) 0;
      GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MapToWar);
    }
  }

  public static void CheckMorale(CombatReport report)
  {
    DataManager instance = DataManager.Instance;
    bool flag1 = false;
    CombatSummaryContent summary = report.Combat.Summary;
    if ((instance.bWarAttacker || report.Combat.Result != CombatReportResultType.ECRR_COMBATVICTORY) && (!instance.bWarAttacker || report.Combat.Result != CombatReportResultType.ECRR_COMBATDEFEAT) && report.Combat.Result != CombatReportResultType.ECRR_DEFENDVICTORY)
    {
      ulong num1 = (ulong) (summary.DefenceTroopInjure + summary.DefenceTroopDeath);
      if (summary.WallDamage >= summary.WallDefence && num1 >= (ulong) summary.DefenceTroopForce)
        flag1 = true;
      ulong num2 = num1 + (ulong) (summary.LoseTrapNumber + summary.SaveTrapNumber);
      instance.WarMoraleValue[0] = !flag1 ? num2 : (ulong) summary.AssaultTroopForce;
      instance.WarMoraleValue[1] = num2;
      bool flag2 = summary.WallDefence > 0U && summary.WallDamage < summary.WallDefence;
      instance.bWarMoraleSpecialCale = false;
    }
    else
    {
      ulong num = (ulong) (summary.AssaultTroopInjure + summary.AssaultTroopDeath);
      if (num >= (ulong) summary.AssaultTroopForce)
        flag1 = true;
      instance.WarMoraleValue[0] = num;
      instance.WarMoraleValue[1] = !flag1 ? num : (ulong) (summary.AssaultTroopForce + summary.TrapNumber);
      bool flag3 = summary.WallDefence > 0U && summary.WallDamage < summary.WallDefence;
      instance.bWarMoraleSpecialCale = flag3 && num == 0UL;
    }
  }

  public static void CheckMorale(
    byte Result,
    ref CombatPlayerData attacker,
    ref CombatPlayerData defencer)
  {
    DataManager instance = DataManager.Instance;
    uint num1 = 0;
    uint num2 = 0;
    bool flag = true;
    for (int index = 0; index < 16; ++index)
    {
      num1 += attacker.DeadTroop[index];
      num2 += defencer.DeadTroop[index];
      if (Result == (byte) 1 && defencer.SurviveTroop[index] != 0U)
        flag = false;
      else if (Result == (byte) 2 && attacker.SurviveTroop[index] != 0U)
        flag = false;
    }
    WarManager.MoraleInfo.WinnerSide = Result;
    WarManager.MoraleInfo.bWallDown = (byte) 1;
    WarManager.MoraleInfo.bEliminate = !flag ? (byte) 0 : (byte) 1;
    WarManager.MoraleInfo.AssaultLostForce = num1;
    WarManager.MoraleInfo.DefenceLostForce = num2;
    WarManager.CheckMorale();
  }

  public static void CheckNPCMorale(CombatReport report)
  {
    DataManager instance = DataManager.Instance;
    bool flag1 = false;
    NPCCombatSummaryContent summary = report.NPCCombat.Summary;
    if ((instance.bWarAttacker || report.NPCCombat.Result != CombatReportResultType.ECRR_COMBATVICTORY) && (!instance.bWarAttacker || report.NPCCombat.Result != CombatReportResultType.ECRR_COMBATDEFEAT) && report.NPCCombat.Result != CombatReportResultType.ECRR_DEFENDVICTORY)
    {
      ulong num1 = (ulong) (report.NPCCombat.SummaryHead.DefenceTroopInjure + report.NPCCombat.SummaryHead.DefenceTroopDeath);
      if (summary.WallDamage >= summary.WallDefence && num1 >= (ulong) report.NPCCombat.SummaryHead.DefenceTroopForce)
        flag1 = true;
      ulong num2 = num1 + (ulong) (summary.LoseTrapNumber + summary.SaveTrapNumber);
      instance.WarMoraleValue[0] = !flag1 ? num2 : (ulong) report.NPCCombat.SummaryHead.AssaultTroopForce;
      instance.WarMoraleValue[1] = num2;
      bool flag2 = summary.WallDefence > 0U && summary.WallDamage < summary.WallDefence;
      instance.bWarMoraleSpecialCale = false;
    }
    else
    {
      ulong num = (ulong) (report.NPCCombat.SummaryHead.AssaultTroopInjure + report.NPCCombat.SummaryHead.AssaultTroopDeath);
      if (num >= (ulong) report.NPCCombat.SummaryHead.AssaultTroopForce)
        flag1 = true;
      instance.WarMoraleValue[0] = num;
      instance.WarMoraleValue[1] = !flag1 ? num : (ulong) (report.NPCCombat.SummaryHead.AssaultTroopForce + summary.TrapNumber);
      bool flag3 = summary.WallDefence > 0U && summary.WallDamage < summary.WallDefence;
      instance.bWarMoraleSpecialCale = flag3 && num == 0UL;
    }
  }

  public static void CheckMorale()
  {
    DataManager instance = DataManager.Instance;
    bool flag1 = false;
    if (WarManager.MoraleInfo.WinnerSide == (byte) 1)
    {
      ulong defenceLostForce = (ulong) WarManager.MoraleInfo.DefenceLostForce;
      if (WarManager.MoraleInfo.bEliminate == (byte) 1)
        flag1 = true;
      uint num = 0;
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
          num += instance.pLeftTroopForce[index1, index2];
      }
      instance.WarMoraleValue[0] = !flag1 ? defenceLostForce : (ulong) num;
      instance.WarMoraleValue[1] = defenceLostForce;
      instance.bWarMoraleSpecialCale = false;
    }
    else
    {
      if (WarManager.MoraleInfo.WinnerSide != (byte) 2)
        return;
      ulong assaultLostForce = (ulong) WarManager.MoraleInfo.AssaultLostForce;
      if (WarManager.MoraleInfo.bEliminate == (byte) 1)
        flag1 = true;
      uint num = 0;
      for (int index3 = 0; index3 < 4; ++index3)
      {
        for (int index4 = 0; index4 < 4; ++index4)
          num += instance.pRightTroopForce[index3, index4];
      }
      for (int index5 = 0; index5 < 3; ++index5)
      {
        for (int index6 = 0; index6 < 4; ++index6)
          num += instance.pCastleInfo[index5, index6];
      }
      instance.WarMoraleValue[0] = assaultLostForce;
      instance.WarMoraleValue[1] = !flag1 ? assaultLostForce : (ulong) num;
      bool flag2 = WarManager.MoraleInfo.bWallDown == (byte) 0;
      instance.bWarMoraleSpecialCale = flag2 && assaultLostForce == 0UL;
    }
  }

  public static void SetupNewbieWar()
  {
    DataManager instance = DataManager.Instance;
    WarManager.NpcModeEnable = (byte) 0;
    instance.War_LordCapture = (byte) 0;
    instance.bWarAttacker = true;
    instance.War_RndSeed = (ushort) 1;
    instance.War_RndGap = (ushort) 1;
    UnityEngine.Random.seed = (int) instance.War_RndSeed;
    instance.pLeftTroopForce[0, 0] = 0U;
    instance.pLeftTroopForce[0, 1] = 0U;
    instance.pLeftTroopForce[0, 2] = 7000U;
    instance.pLeftTroopForce[0, 3] = 0U;
    instance.pLeftTroopForce[1, 0] = 0U;
    instance.pLeftTroopForce[1, 1] = 0U;
    instance.pLeftTroopForce[1, 2] = 150U;
    instance.pLeftTroopForce[1, 3] = 0U;
    instance.pLeftTroopForce[2, 0] = 0U;
    instance.pLeftTroopForce[2, 1] = 0U;
    instance.pLeftTroopForce[2, 2] = 150U;
    instance.pLeftTroopForce[2, 3] = 0U;
    instance.pLeftTroopForce[3, 0] = 0U;
    instance.pLeftTroopForce[3, 1] = 0U;
    instance.pLeftTroopForce[3, 2] = 50U;
    instance.pLeftTroopForce[3, 3] = 0U;
    instance.pRightTroopForce[0, 0] = 0U;
    instance.pRightTroopForce[0, 1] = 0U;
    instance.pRightTroopForce[0, 2] = 0U;
    instance.pRightTroopForce[0, 3] = 150U;
    instance.pRightTroopForce[1, 0] = 0U;
    instance.pRightTroopForce[1, 1] = 0U;
    instance.pRightTroopForce[1, 2] = 0U;
    instance.pRightTroopForce[1, 3] = 350U;
    instance.pRightTroopForce[2, 0] = 0U;
    instance.pRightTroopForce[2, 1] = 0U;
    instance.pRightTroopForce[2, 2] = 0U;
    instance.pRightTroopForce[2, 3] = 350U;
    instance.pRightTroopForce[3, 0] = 0U;
    instance.pRightTroopForce[3, 1] = 0U;
    instance.pRightTroopForce[3, 2] = 0U;
    instance.pRightTroopForce[3, 3] = 350U;
    Array.Clear((Array) instance.pLeftLeaderData, 0, 5);
    instance.pLeftLeaderData[0] = new TroopLeaderType((ushort) 1445, (byte) 1, (byte) 1);
    instance.pLeftLeaderData[1] = new TroopLeaderType((ushort) 1447, (byte) 1, (byte) 1);
    instance.War_LeftHeroNum = (byte) 2;
    Array.Clear((Array) instance.pRightLeaderData, 0, 5);
    instance.pRightLeaderData[0] = new TroopLeaderType((ushort) 7, (byte) 1, (byte) 1);
    instance.War_RightHeroNum = (byte) 1;
    instance.bSiege = (byte) 1;
    instance.War_WallLevel = (byte) 18;
    instance.pCastleInfo[0, 3] = 300U;
    instance.pCastleInfo[2, 3] = 300U;
    instance.pCastleInfo[1, 0] = 0U;
    instance.pCastleInfo[1, 1] = 0U;
    instance.pCastleInfo[1, 2] = 0U;
    instance.pCastleInfo[1, 3] = 600U;
    instance.CurWallHp = 3200U;
    instance.MaxWallHp = 3200U;
    for (int index = 0; index < 4; ++index)
    {
      instance.War_LeftAttackAttr[index] = 10000U;
      instance.War_LeftDefenseAttr[index] = 10000U;
      instance.War_LeftHealthAttr[index] = 10000U;
      instance.War_RightAttackAttr[index] = 10000U;
      instance.War_RightDefenseAttr[index] = 10000U;
      instance.War_RightHealthAttr[index] = 10000U;
    }
    instance.War_WallAttr.TrapAttack = 10000U;
    instance.War_WallAttr.TrapDefence = 10000U;
    instance.War_WallAttr.TrapHealth = 10000U;
    instance.War_WallAttr.WallHealth = 10000U;
    instance.War_LeftCastleLv = (byte) 1;
    instance.War_RightCastleLv = (byte) 1;
    WarManager.MoraleInfo.WinnerSide = (byte) 1;
    WarManager.MoraleInfo.bWallDown = (byte) 1;
    WarManager.MoraleInfo.bEliminate = (byte) 0;
    WarManager.MoraleInfo.AssaultLostForce = 100U;
    WarManager.MoraleInfo.DefenceLostForce = 327U;
    WarManager.CheckMorale();
    DataManager.Instance.DramaTriggerFlag = 131073U;
    WarManager.WarCoordIndex_Left = (ushort) 0;
    WarManager.WarCoordIndex_Right = (ushort) 0;
  }

  public static void SetCoordTestWarData()
  {
    DataManager instance = DataManager.Instance;
    instance.DramaTriggerFlag = 0U;
    instance.War_LordCapture = (byte) 0;
    instance.bWarAttacker = true;
    instance.War_RndSeed = (ushort) 1;
    instance.War_RndGap = (ushort) 1;
    UnityEngine.Random.seed = (int) instance.War_RndSeed;
    WarManager.LoadLeftCoordDisplayData();
    WarManager.LoadRightCoordDisplayData();
    Array.Clear((Array) instance.pLeftLeaderData, 0, 5);
    instance.War_LeftHeroNum = (byte) 0;
    Array.Clear((Array) instance.pRightLeaderData, 0, 5);
    instance.War_RightHeroNum = (byte) 0;
    instance.bSiege = (byte) 0;
    for (int index = 0; index < 4; ++index)
    {
      instance.War_LeftAttackAttr[index] = 10000U;
      instance.War_LeftDefenseAttr[index] = 10000U;
      instance.War_LeftHealthAttr[index] = 10000U;
      instance.War_RightAttackAttr[index] = 10000U;
      instance.War_RightDefenseAttr[index] = 10000U;
      instance.War_RightHealthAttr[index] = 10000U;
    }
    instance.War_LeftCastleLv = (byte) 1;
    instance.War_RightCastleLv = (byte) 1;
    int Index = (int) WarManager.CoordSimuIndex_Left * 3 + (int) WarManager.TroopKindSimuIndex_Right;
    CoordResultData recordByIndex = instance.CoordResultTable.GetRecordByIndex(Index);
    WarManager.MoraleInfo.WinnerSide = recordByIndex.Left_TotalLose >= recordByIndex.Right_TotalLose ? (byte) 2 : (byte) 1;
    WarManager.MoraleInfo.bWallDown = (byte) 0;
    WarManager.MoraleInfo.bEliminate = (byte) 0;
    WarManager.MoraleInfo.AssaultLostForce = recordByIndex.Left_TotalLose;
    WarManager.MoraleInfo.DefenceLostForce = recordByIndex.Right_TotalLose;
    WarManager.CheckMorale();
  }

  public static void LoadLeftCoordDisplayData()
  {
    DataManager instance = DataManager.Instance;
    CoordDisplayData recordByIndex = instance.CoordDisplayTable.GetRecordByIndex(WarManager.CoordToSoldiers[(int) WarManager.CoordSimuIndex_Left]);
    instance.pLeftTroopForce[0, 0] = recordByIndex.Left_Infantry1;
    instance.pLeftTroopForce[0, 1] = recordByIndex.Left_Infantry2;
    instance.pLeftTroopForce[0, 2] = recordByIndex.Left_Infantry3;
    instance.pLeftTroopForce[0, 3] = recordByIndex.Left_Infantry4;
    instance.pLeftTroopForce[1, 0] = recordByIndex.Left_Archer1;
    instance.pLeftTroopForce[1, 1] = recordByIndex.Left_Archer2;
    instance.pLeftTroopForce[1, 2] = recordByIndex.Left_Archer3;
    instance.pLeftTroopForce[1, 3] = recordByIndex.Left_Archer4;
    instance.pLeftTroopForce[2, 0] = recordByIndex.Left_Cavalry1;
    instance.pLeftTroopForce[2, 1] = recordByIndex.Left_Cavalry2;
    instance.pLeftTroopForce[2, 2] = recordByIndex.Left_Cavalry3;
    instance.pLeftTroopForce[2, 3] = recordByIndex.Left_Cavalry4;
    instance.pLeftTroopForce[3, 0] = recordByIndex.Left_Catapults1;
    instance.pLeftTroopForce[3, 1] = recordByIndex.Left_Catapults2;
    instance.pLeftTroopForce[3, 2] = recordByIndex.Left_Catapults3;
    instance.pLeftTroopForce[3, 3] = recordByIndex.Left_Catapults4;
  }

  public static void LoadRightCoordDisplayData()
  {
    if (WarManager.TroopKindSimuIndex_Right >= (ushort) 3)
      return;
    DataManager instance = DataManager.Instance;
    CoordDisplayData recordByIndex = instance.CoordDisplayTable.GetRecordByIndex((int) WarManager.TroopKindSimuIndex_Right);
    instance.pRightTroopForce[0, 0] = recordByIndex.Right_Infantry1;
    instance.pRightTroopForce[0, 1] = recordByIndex.Right_Infantry2;
    instance.pRightTroopForce[0, 2] = recordByIndex.Right_Infantry3;
    instance.pRightTroopForce[0, 3] = recordByIndex.Right_Infantry4;
    instance.pRightTroopForce[1, 0] = recordByIndex.Right_Archer1;
    instance.pRightTroopForce[1, 1] = recordByIndex.Right_Archer2;
    instance.pRightTroopForce[1, 2] = recordByIndex.Right_Archer3;
    instance.pRightTroopForce[1, 3] = recordByIndex.Right_Archer4;
    instance.pRightTroopForce[2, 0] = recordByIndex.Right_Cavalry1;
    instance.pRightTroopForce[2, 1] = recordByIndex.Right_Cavalry2;
    instance.pRightTroopForce[2, 2] = recordByIndex.Right_Cavalry3;
    instance.pRightTroopForce[2, 3] = recordByIndex.Right_Cavalry4;
    instance.pRightTroopForce[3, 0] = recordByIndex.Right_Catapults1;
    instance.pRightTroopForce[3, 1] = recordByIndex.Right_Catapults2;
    instance.pRightTroopForce[3, 2] = recordByIndex.Right_Catapults3;
    instance.pRightTroopForce[3, 3] = recordByIndex.Right_Catapults4;
  }

  public static bool CheckVersion(uint Version, uint Patch, bool bShowHud = true)
  {
    if ((int) Patch != (int) DataManager.Instance.BattlePatchNo || (int) Patch != (int) DataManager.Instance.BattleEngine)
    {
      if (bShowHud)
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8241U), (ushort) byte.MaxValue);
      return false;
    }
    if ((int) Version != (int) DataManager.Instance.BattleSimVer)
    {
      if (bShowHud)
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8241U), (ushort) byte.MaxValue);
      return false;
    }
    if ((int) BSInvokeUtil.getInstance.GetVersion() == (int) DataManager.Instance.BattleSimVer)
      return true;
    if (bShowHud)
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1049U), (ushort) byte.MaxValue);
    return false;
  }

  public static bool CheckVersion(bool bShowHud = true)
  {
    if ((int) DataManager.Instance.BattleEngine != (int) DataManager.Instance.BattlePatchNo)
    {
      if (bShowHud)
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8241U), (ushort) byte.MaxValue);
      return false;
    }
    if ((int) BSInvokeUtil.getInstance.GetVersion() == (int) DataManager.Instance.BattleSimVer)
      return true;
    if (bShowHud)
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1049U), (ushort) byte.MaxValue);
    return false;
  }

  public enum WarState
  {
    STOP,
    WAITING_FOR_START,
    RUNNING,
    FINISHING,
    WAITTING_FOR_VICTORY,
    RETREAT,
    AUTOBATTLE_WAITING,
    CASTLE_DESTROYING,
    CHANGING_SIEGE_MODE,
    CHANGE_COORD_MODE,
    FINISHED,
  }

  public enum EWarKind
  {
    Normal,
    Newbie,
    CoordTest,
  }
}
