// Decompiled with JetBrains decompiler
// Type: MapTileEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class MapTileEffect
{
  private const ushort EffectWinID = 60102;
  private const ushort EffectLoseID = 60101;
  private const ushort EffectShieldID = 60103;
  private const ushort EffectConveyID = 60111;
  private const ushort EffectEnemyLoseID = 60110;
  private const ushort EffectYolkWinID = 60104;
  private const ushort EffectYolkLoseID = 60105;
  private const ushort EffectYolkShieldID = 60106;
  private const ushort EffectBigYolkWinID = 60107;
  private const ushort EffectBigYolkLoseID = 60108;
  private const ushort EffectBigYolkShieldID = 60109;
  private const ushort EffectWinID_Back = 198;
  private const ushort EffectLoseID_Back = 197;
  private const ushort EffectShieldID_Back = 199;
  private const ushort EffectConveyID_Back = 332;
  private const ushort EffectEnemyLoseID_Back = 387;
  private const ushort EffectYolkWinID_Back = 379;
  private const ushort EffectYolkLoseID_Back = 380;
  private const ushort EffectYolkShieldID_Back = 381;
  private const ushort EffectBigYolkWinID_Back = 383;
  private const ushort EffectBigYolkLoseID_Back = 384;
  private const ushort EffectBigYolkShieldID_Back = 385;
  private const ushort EffectNPCCityConveyID = 60112;
  private const ushort EffectNPCCityConveyID_Back = 390;
  private Transform RealmGroup;
  private Transform EffectLayoutTransform;
  private Transform WinLayoutTransform;
  private Transform LoseLayoutTransform;
  private Transform ShieldLayoutTransform;
  private Transform ConveyLayoutTransform;
  private Transform YolkLayoutTransform;
  private Transform EnemyLoseLayoutTransform;
  private Transform NPCCityConveyLayoutTransform;
  private GameObject[][] EffectWinGameObject;
  private GameObject[][] EffectLoseGameObject;
  private GameObject[][] EffectShieldGameObject;
  private GameObject[][] EffectConveyGameObject;
  private GameObject[][] EffectEnemyLoseGameObject;
  private GameObject[][] EffectNPCCityConveyGameObject;
  private GameObject EffectYolkWinGameObject;
  private GameObject EffectYolkLoseGameObject;
  private GameObject EffectYolkShieldGameObject;
  private GameObject EffectBigYolkWinGameObject;
  private GameObject EffectBigYolkLoseGameObject;
  private GameObject EffectBigYolkShieldGameObject;
  private Transform[][] EffectWinTransform;
  private Transform[][] EffectLoseTransform;
  private Transform[][] EffectShieldTransform;
  private Transform[][] EffectConveyTransform;
  private Transform[][] EffectEnemyLoseTransform;
  private Transform[][] EffectNPCCityConveyTransform;
  private Transform EffectYolkWinTransform;
  private Transform EffectYolkLoseTransform;
  private Transform EffectYolkShieldTransform;
  private Transform EffectBigYolkWinTransform;
  private Transform EffectBigYolkLoseTransform;
  private Transform EffectBigYolkShieldTransform;
  private ParticleSystem[][] EffectWinParticle;
  private ParticleSystem[][] EffectLoseParticle;
  private ParticleSystem[][] EffectShieldParticle;
  private ParticleSystem[][] EffectShieldParticle_one;
  private ParticleSystem[][] EffectConveyParticle;
  private ParticleSystem[][] EffectConveyParticle_one;
  private ParticleSystem[][] EffectConveyParticle_two;
  private ParticleSystem[][] EffectConveyParticle_thr;
  private ParticleSystem[][] EffectEnemyLoseParticle;
  private ParticleSystem[][] EffectNPCCityConveyParticle;
  private ParticleSystem[][] EffectNPCCityConveyParticle_one;
  private ParticleSystem[][] EffectNPCCityConveyParticle_two;
  private ParticleSystem[][] EffectNPCCityConveyParticle_thr;
  private ParticleSystem EffectYolkWinParticle;
  private ParticleSystem EffectYolkWinParticle_one;
  private ParticleSystem EffectYolkWinParticle_two;
  private ParticleSystem EffectYolkWinParticle_thr;
  private ParticleSystem EffectYolkWinParticle_tho;
  private ParticleSystem EffectYolkLoseParticle;
  private ParticleSystem EffectYolkLoseParticle_one;
  private ParticleSystem EffectYolkShieldParticle;
  private ParticleSystem EffectYolkShieldParticle_one;
  private ParticleSystem EffectYolkShieldParticle_two;
  private ParticleSystem EffectYolkShieldParticle_thr;
  private ParticleSystem EffectBigYolkWinParticle;
  private ParticleSystem EffectBigYolkWinParticle_one;
  private ParticleSystem EffectBigYolkWinParticle_two;
  private ParticleSystem EffectBigYolkWinParticle_thr;
  private ParticleSystem EffectBigYolkWinParticle_for;
  private ParticleSystem EffectBigYolkLoseParticle;
  private ParticleSystem EffectBigYolkLoseParticle_one;
  private ParticleSystem EffectBigYolkLoseParticle_two;
  private ParticleSystem EffectBigYolkShieldParticle;
  private ParticleSystem EffectBigYolkShieldParticle_one;
  private ParticleSystem EffectBigYolkShieldParticle_two;
  private ParticleSystem EffectBigYolkShieldParticle_thr;
  private GameObject[][] EffectWinGameObjectPools;
  private GameObject[][] EffectLoseGameObjectPools;
  private GameObject[][] EffectShieldGameObjectPools;
  private GameObject[][] EffectConveyGameObjectPools;
  private GameObject[][] EffectEnemyLoseGameObjectPools;
  private GameObject[][] EffectNPCCityConveyGameObjectPools;
  private Transform[][] EffectWinTransformPools;
  private Transform[][] EffectLoseTransformPools;
  private Transform[][] EffectShieldTransformPools;
  private Transform[][] EffectConveyTransformPools;
  private Transform[][] EffectEnemyLoseTransformPools;
  private Transform[][] EffectNPCCityConveyTransformPools;
  private ParticleSystem[][] EffectWinParticlePools;
  private ParticleSystem[][] EffectLoseParticlePools;
  private ParticleSystem[][] EffectShieldParticlePools;
  private ParticleSystem[][] EffectShieldParticlePools_one;
  private ParticleSystem[][] EffectConveyParticlePools;
  private ParticleSystem[][] EffectConveyParticlePools_one;
  private ParticleSystem[][] EffectConveyParticlePools_two;
  private ParticleSystem[][] EffectConveyParticlePools_thr;
  private ParticleSystem[][] EffectEnemyLoseParticlePools;
  private ParticleSystem[][] EffectNPCCityConveyParticlePools;
  private ParticleSystem[][] EffectNPCCityConveyParticlePools_one;
  private ParticleSystem[][] EffectNPCCityConveyParticlePools_two;
  private ParticleSystem[][] EffectNPCCityConveyParticlePools_thr;
  private int[] WinpoolCounter;
  private int WinpoolsCounter;
  private int[] LosepoolCounter;
  private int LosepoolsCounter;
  private int[] ShieldpoolCounter;
  private int ShieldpoolsCounter;
  private int[] ConveypoolCounter;
  private int ConveypoolsCounter;
  private int[] EnemyLosepoolCounter;
  private int EnemyLosepoolsCounter;
  private int[] NPCCityConveypoolCounter;
  private int NPCCityConveypoolsCounter;
  private Vector3 inipos = new Vector3(0.0f, 1024f, 0.0f);
  private float WinstartSize;
  private float Winlifetime;
  private float LosestartSize;
  private float Loselifetime;
  private float ShieldstartSize;
  private float Conveylifetime;
  private float Conveylifetime_one;
  private float Conveylifetime_two;
  private float Conveylifetime_thr;
  private float ConveystartSize;
  private float ConveystartSize_one;
  private float ConveystartSize_two;
  private float ConveystartSize_thr;
  private float EnemyLosestartSize;
  private float EnemyLoselifetime;
  private float NPCCityConveylifetime;
  private float NPCCityConveylifetime_one;
  private float NPCCityConveylifetime_two;
  private float NPCCityConveylifetime_thr;
  private float NPCCityConveystartSize;
  private float NPCCityConveystartSize_one;
  private float NPCCityConveystartSize_two;
  private float NPCCityConveystartSize_thr;
  private float YolkWinstartSize;
  private float YolkWinstartSize_one;
  private float YolkWinstartSize_two;
  private float YolkWinstartSize_thr;
  private float YolkWinstartSize_tho;
  private float YolkWinlifetime;
  private float YolkWinlifetime_one;
  private float YolkWinlifetime_two;
  private float YolkWinlifetime_thr;
  private float YolkWinlifetime_tho;
  private float YolkLosestartSize;
  private float YolkLosestartSize_one;
  private float YolkLoselifetime;
  private float YolkLoselifetime_one;
  private float YolkShieldstartSize;
  private float YolkShieldstartSize_one;
  private float YolkShieldstartSize_two;
  private float YolkShieldstartSize_thr;
  private float YolkShieldlifetime;
  private float YolkShieldlifetime_one;
  private float YolkShieldlifetime_two;
  private float YolkShieldlifetime_thr;
  private float BigYolkWinstartSize;
  private float BigYolkWinstartSize_one;
  private float BigYolkWinstartSize_two;
  private float BigYolkWinstartSize_thr;
  private float BigYolkWinstartSize_for;
  private float BigYolkWinlifetime;
  private float BigYolkWinlifetime_one;
  private float BigYolkWinlifetime_two;
  private float BigYolkWinlifetime_thr;
  private float BigYolkWinlifetime_for;
  private float BigYolkLosestartSize;
  private float BigYolkLosestartSize_one;
  private float BigYolkLosestartSize_two;
  private float BigYolkLoselifetime;
  private float BigYolkLoselifetime_one;
  private float BigYolkLoselifetime_two;
  private float BigYolkShieldstartSize;
  private float BigYolkShieldstartSize_one;
  private float BigYolkShieldstartSize_two;
  private float BigYolkShieldstartSize_thr;
  private float BigYolkShieldlifetime;
  private float BigYolkShieldlifetime_one;
  private float BigYolkShieldlifetime_two;
  private float BigYolkShieldlifetime_thr;
  private float YolkShieldScale = 1.33333337f;
  private int Yolkrow = -1;
  private int Yolkcol = -1;
  private ParticleSystem.Particle[] particles = new ParticleSystem.Particle[64];
  private byte bBack = 1;
  private bool bFront;

  public MapTileEffect(Transform realmGroup, float tileBaseScale)
  {
    this.EffectLayoutTransform = new GameObject(nameof (MapTileEffect)).transform;
    this.RealmGroup = realmGroup;
    this.EffectLayoutTransform.localScale = Vector3.one * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
    this.EffectLayoutTransform.position = Vector3.forward * 2950f * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
    this.EffectLayoutTransform.SetParent(realmGroup, false);
    this.WinLayoutTransform = new GameObject("MapTileEffectWin").transform;
    this.WinLayoutTransform.SetParent(this.EffectLayoutTransform, false);
    this.LoseLayoutTransform = new GameObject("MapTileEffectLose").transform;
    this.LoseLayoutTransform.SetParent(this.EffectLayoutTransform, false);
    this.ShieldLayoutTransform = new GameObject("MapTileEffectShield").transform;
    this.ShieldLayoutTransform.SetParent(this.EffectLayoutTransform, false);
    this.ConveyLayoutTransform = new GameObject("MapTileEffectConvey").transform;
    this.ConveyLayoutTransform.SetParent(this.EffectLayoutTransform, false);
    this.YolkLayoutTransform = new GameObject("MapTileEffectYolk").transform;
    this.YolkLayoutTransform.SetParent(this.EffectLayoutTransform, false);
    this.EnemyLoseLayoutTransform = new GameObject("MapTileEffectEnemyLose").transform;
    this.EnemyLoseLayoutTransform.SetParent(this.EffectLayoutTransform, false);
    this.NPCCityConveyLayoutTransform = new GameObject("MapTileEffectNPCCityConvey").transform;
    this.NPCCityConveyLayoutTransform.SetParent(this.EffectLayoutTransform, false);
    this.WinpoolsCounter = this.LosepoolsCounter = this.ShieldpoolsCounter = this.ConveypoolsCounter = this.EnemyLosepoolsCounter = this.NPCCityConveypoolsCounter = 0;
  }

  public void OnDestroy()
  {
    if (this.EffectWinGameObject != null)
    {
      for (int index1 = 0; index1 < this.EffectWinGameObject.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.EffectWinGameObject[index1].Length; ++index2)
        {
          if ((UnityEngine.Object) this.EffectWinGameObject[index1][index2] != (UnityEngine.Object) null)
          {
            ParticleManager.Instance.DeSpawn(this.EffectWinGameObject[index1][index2]);
            this.EffectWinGameObject[index1][index2] = (GameObject) null;
            this.EffectWinTransform[index1][index2] = (Transform) null;
            this.EffectWinParticle[index1][index2] = (ParticleSystem) null;
          }
        }
        this.EffectWinGameObject[index1] = (GameObject[]) null;
        this.EffectWinTransform[index1] = (Transform[]) null;
        this.EffectWinParticle[index1] = (ParticleSystem[]) null;
      }
    }
    this.EffectWinGameObject = (GameObject[][]) null;
    this.EffectWinTransform = (Transform[][]) null;
    this.EffectWinParticle = (ParticleSystem[][]) null;
    if (this.EffectLoseGameObject != null)
    {
      for (int index3 = 0; index3 < this.EffectLoseGameObject.Length; ++index3)
      {
        for (int index4 = 0; index4 < this.EffectLoseGameObject[index3].Length; ++index4)
        {
          if ((UnityEngine.Object) this.EffectLoseGameObject[index3][index4] != (UnityEngine.Object) null)
          {
            ParticleManager.Instance.DeSpawn(this.EffectLoseGameObject[index3][index4]);
            this.EffectLoseGameObject[index3][index4] = (GameObject) null;
            this.EffectLoseTransform[index3][index4] = (Transform) null;
            this.EffectLoseParticle[index3][index4] = (ParticleSystem) null;
          }
        }
        this.EffectLoseGameObject[index3] = (GameObject[]) null;
        this.EffectLoseTransform[index3] = (Transform[]) null;
        this.EffectLoseParticle[index3] = (ParticleSystem[]) null;
      }
    }
    this.EffectLoseGameObject = (GameObject[][]) null;
    this.EffectLoseTransform = (Transform[][]) null;
    this.EffectLoseParticle = (ParticleSystem[][]) null;
    if (this.EffectEnemyLoseGameObject != null)
    {
      for (int index5 = 0; index5 < this.EffectEnemyLoseGameObject.Length; ++index5)
      {
        for (int index6 = 0; index6 < this.EffectEnemyLoseGameObject[index5].Length; ++index6)
        {
          if ((UnityEngine.Object) this.EffectEnemyLoseGameObject[index5][index6] != (UnityEngine.Object) null)
          {
            ParticleManager.Instance.DeSpawn(this.EffectEnemyLoseGameObject[index5][index6]);
            this.EffectEnemyLoseGameObject[index5][index6] = (GameObject) null;
            this.EffectEnemyLoseTransform[index5][index6] = (Transform) null;
            this.EffectEnemyLoseParticle[index5][index6] = (ParticleSystem) null;
          }
        }
        this.EffectEnemyLoseGameObject[index5] = (GameObject[]) null;
        this.EffectEnemyLoseTransform[index5] = (Transform[]) null;
        this.EffectEnemyLoseParticle[index5] = (ParticleSystem[]) null;
      }
    }
    this.EffectEnemyLoseGameObject = (GameObject[][]) null;
    this.EffectEnemyLoseTransform = (Transform[][]) null;
    this.EffectEnemyLoseParticle = (ParticleSystem[][]) null;
    if (this.EffectShieldGameObject != null)
    {
      for (int index7 = 0; index7 < this.EffectShieldGameObject.Length; ++index7)
      {
        for (int index8 = 0; index8 < this.EffectShieldGameObject[index7].Length; ++index8)
        {
          if ((UnityEngine.Object) this.EffectShieldGameObject[index7][index8] != (UnityEngine.Object) null)
          {
            ParticleManager.Instance.DeSpawn(this.EffectShieldGameObject[index7][index8]);
            this.EffectShieldGameObject[index7][index8] = (GameObject) null;
            this.EffectShieldTransform[index7][index8] = (Transform) null;
            this.EffectShieldParticle[index7][index8] = (ParticleSystem) null;
            this.EffectShieldParticle_one[index7][index8] = (ParticleSystem) null;
          }
        }
        this.EffectShieldGameObject[index7] = (GameObject[]) null;
        this.EffectShieldTransform[index7] = (Transform[]) null;
        this.EffectShieldParticle[index7] = (ParticleSystem[]) null;
        this.EffectShieldParticle_one[index7] = (ParticleSystem[]) null;
      }
    }
    this.EffectShieldGameObject = (GameObject[][]) null;
    this.EffectShieldTransform = (Transform[][]) null;
    this.EffectShieldParticle = (ParticleSystem[][]) null;
    this.EffectShieldParticle_one = (ParticleSystem[][]) null;
    if (this.EffectConveyGameObject != null)
    {
      for (int index9 = 0; index9 < this.EffectConveyGameObject.Length; ++index9)
      {
        for (int index10 = 0; index10 < this.EffectConveyGameObject[index9].Length; ++index10)
        {
          if ((UnityEngine.Object) this.EffectConveyGameObject[index9][index10] != (UnityEngine.Object) null)
          {
            ParticleManager.Instance.DeSpawn(this.EffectConveyGameObject[index9][index10]);
            this.EffectConveyGameObject[index9][index10] = (GameObject) null;
            this.EffectConveyTransform[index9][index10] = (Transform) null;
            this.EffectConveyParticle[index9][index10] = (ParticleSystem) null;
            this.EffectConveyParticle_one[index9][index10] = (ParticleSystem) null;
            this.EffectConveyParticle_two[index9][index10] = (ParticleSystem) null;
            this.EffectConveyParticle_thr[index9][index10] = (ParticleSystem) null;
          }
        }
        this.EffectConveyGameObject[index9] = (GameObject[]) null;
        this.EffectConveyTransform[index9] = (Transform[]) null;
        this.EffectConveyParticle[index9] = (ParticleSystem[]) null;
        this.EffectConveyParticle_one[index9] = (ParticleSystem[]) null;
        this.EffectConveyParticle_two[index9] = (ParticleSystem[]) null;
        this.EffectConveyParticle_thr[index9] = (ParticleSystem[]) null;
      }
    }
    this.EffectConveyGameObject = (GameObject[][]) null;
    this.EffectConveyTransform = (Transform[][]) null;
    this.EffectConveyParticle = (ParticleSystem[][]) null;
    this.EffectConveyParticle_one = (ParticleSystem[][]) null;
    this.EffectConveyParticle_two = (ParticleSystem[][]) null;
    this.EffectConveyParticle_thr = (ParticleSystem[][]) null;
    if (this.EffectNPCCityConveyGameObject != null)
    {
      for (int index11 = 0; index11 < this.EffectNPCCityConveyGameObject.Length; ++index11)
      {
        for (int index12 = 0; index12 < this.EffectNPCCityConveyGameObject[index11].Length; ++index12)
        {
          if ((UnityEngine.Object) this.EffectNPCCityConveyGameObject[index11][index12] != (UnityEngine.Object) null)
          {
            ParticleManager.Instance.DeSpawn(this.EffectNPCCityConveyGameObject[index11][index12]);
            this.EffectNPCCityConveyGameObject[index11][index12] = (GameObject) null;
            this.EffectNPCCityConveyTransform[index11][index12] = (Transform) null;
            this.EffectNPCCityConveyParticle[index11][index12] = (ParticleSystem) null;
            this.EffectNPCCityConveyParticle_one[index11][index12] = (ParticleSystem) null;
            this.EffectNPCCityConveyParticle_two[index11][index12] = (ParticleSystem) null;
            this.EffectNPCCityConveyParticle_thr[index11][index12] = (ParticleSystem) null;
          }
        }
        this.EffectNPCCityConveyGameObject[index11] = (GameObject[]) null;
        this.EffectNPCCityConveyTransform[index11] = (Transform[]) null;
        this.EffectNPCCityConveyParticle[index11] = (ParticleSystem[]) null;
        this.EffectNPCCityConveyParticle_one[index11] = (ParticleSystem[]) null;
        this.EffectNPCCityConveyParticle_two[index11] = (ParticleSystem[]) null;
        this.EffectNPCCityConveyParticle_thr[index11] = (ParticleSystem[]) null;
      }
    }
    this.EffectNPCCityConveyGameObject = (GameObject[][]) null;
    this.EffectNPCCityConveyTransform = (Transform[][]) null;
    this.EffectNPCCityConveyParticle = (ParticleSystem[][]) null;
    this.EffectNPCCityConveyParticle_one = (ParticleSystem[][]) null;
    this.EffectNPCCityConveyParticle_two = (ParticleSystem[][]) null;
    this.EffectNPCCityConveyParticle_thr = (ParticleSystem[][]) null;
    if (this.EffectWinGameObjectPools != null)
    {
      for (int index13 = 0; index13 < this.EffectWinGameObjectPools.Length; ++index13)
      {
        if (this.EffectWinGameObjectPools[index13] != null)
        {
          for (int index14 = 0; index14 < this.EffectWinGameObjectPools[index13].Length; ++index14)
          {
            if ((UnityEngine.Object) this.EffectWinGameObjectPools[index13][index14] != (UnityEngine.Object) null)
            {
              ParticleManager.Instance.DeSpawn(this.EffectWinGameObjectPools[index13][index14]);
              this.EffectWinGameObjectPools[index13][index14] = (GameObject) null;
              this.EffectWinTransformPools[index13][index14] = (Transform) null;
              this.EffectWinParticlePools[index13][index14] = (ParticleSystem) null;
            }
          }
          this.EffectWinGameObjectPools[index13] = (GameObject[]) null;
          this.EffectWinTransformPools[index13] = (Transform[]) null;
          this.EffectWinParticlePools[index13] = (ParticleSystem[]) null;
        }
      }
    }
    this.EffectWinGameObjectPools = (GameObject[][]) null;
    this.EffectWinTransformPools = (Transform[][]) null;
    this.EffectWinParticlePools = (ParticleSystem[][]) null;
    if (this.EffectLoseGameObjectPools != null)
    {
      for (int index15 = 0; index15 < this.EffectLoseGameObjectPools.Length; ++index15)
      {
        if (this.EffectLoseGameObjectPools[index15] != null)
        {
          for (int index16 = 0; index16 < this.EffectLoseGameObjectPools[index15].Length; ++index16)
          {
            if ((UnityEngine.Object) this.EffectLoseGameObjectPools[index15][index16] != (UnityEngine.Object) null)
            {
              ParticleManager.Instance.DeSpawn(this.EffectLoseGameObjectPools[index15][index16]);
              this.EffectLoseGameObjectPools[index15][index16] = (GameObject) null;
              this.EffectLoseTransformPools[index15][index16] = (Transform) null;
              this.EffectLoseParticlePools[index15][index16] = (ParticleSystem) null;
            }
          }
          this.EffectLoseGameObjectPools[index15] = (GameObject[]) null;
          this.EffectLoseTransformPools[index15] = (Transform[]) null;
          this.EffectLoseParticlePools[index15] = (ParticleSystem[]) null;
        }
      }
    }
    this.EffectLoseGameObjectPools = (GameObject[][]) null;
    this.EffectLoseTransformPools = (Transform[][]) null;
    this.EffectLoseParticlePools = (ParticleSystem[][]) null;
    if (this.EffectShieldGameObjectPools != null)
    {
      for (int index17 = 0; index17 < this.EffectShieldGameObjectPools.Length; ++index17)
      {
        if (this.EffectShieldTransformPools[index17] != null)
        {
          for (int index18 = 0; index18 < this.EffectShieldGameObjectPools[index17].Length; ++index18)
          {
            if ((UnityEngine.Object) this.EffectShieldGameObjectPools[index17][index18] != (UnityEngine.Object) null)
            {
              ParticleManager.Instance.DeSpawn(this.EffectShieldGameObjectPools[index17][index18]);
              this.EffectShieldGameObjectPools[index17][index18] = (GameObject) null;
              this.EffectShieldTransformPools[index17][index18] = (Transform) null;
              this.EffectShieldParticlePools[index17][index18] = (ParticleSystem) null;
              this.EffectShieldParticlePools_one[index17][index18] = (ParticleSystem) null;
            }
          }
          this.EffectShieldGameObjectPools[index17] = (GameObject[]) null;
          this.EffectShieldTransformPools[index17] = (Transform[]) null;
          this.EffectShieldParticlePools[index17] = (ParticleSystem[]) null;
          this.EffectShieldParticlePools_one[index17] = (ParticleSystem[]) null;
        }
      }
    }
    this.EffectShieldGameObjectPools = (GameObject[][]) null;
    this.EffectShieldTransformPools = (Transform[][]) null;
    this.EffectShieldParticlePools = (ParticleSystem[][]) null;
    this.EffectShieldParticlePools_one = (ParticleSystem[][]) null;
    if (this.EffectConveyGameObjectPools != null)
    {
      for (int index19 = 0; index19 < this.EffectConveyGameObjectPools.Length; ++index19)
      {
        if (this.EffectConveyGameObjectPools[index19] != null)
        {
          for (int index20 = 0; index20 < this.EffectConveyGameObjectPools[index19].Length; ++index20)
          {
            if ((UnityEngine.Object) this.EffectConveyGameObjectPools[index19][index20] != (UnityEngine.Object) null)
            {
              ParticleManager.Instance.DeSpawn(this.EffectConveyGameObjectPools[index19][index20]);
              this.EffectConveyGameObjectPools[index19][index20] = (GameObject) null;
              this.EffectConveyTransformPools[index19][index20] = (Transform) null;
              this.EffectConveyParticlePools[index19][index20] = (ParticleSystem) null;
              this.EffectConveyParticlePools_one[index19][index20] = (ParticleSystem) null;
              this.EffectConveyParticlePools_two[index19][index20] = (ParticleSystem) null;
              this.EffectConveyParticlePools_thr[index19][index20] = (ParticleSystem) null;
            }
          }
          this.EffectConveyGameObjectPools[index19] = (GameObject[]) null;
          this.EffectConveyTransformPools[index19] = (Transform[]) null;
          this.EffectConveyParticlePools[index19] = (ParticleSystem[]) null;
          this.EffectConveyParticlePools_one[index19] = (ParticleSystem[]) null;
          this.EffectConveyParticlePools_two[index19] = (ParticleSystem[]) null;
          this.EffectConveyParticlePools_thr[index19] = (ParticleSystem[]) null;
        }
      }
    }
    this.EffectConveyGameObjectPools = (GameObject[][]) null;
    this.EffectConveyTransformPools = (Transform[][]) null;
    this.EffectConveyParticlePools = (ParticleSystem[][]) null;
    this.EffectConveyParticlePools_one = (ParticleSystem[][]) null;
    this.EffectConveyParticlePools_two = (ParticleSystem[][]) null;
    this.EffectConveyParticlePools_thr = (ParticleSystem[][]) null;
    if (this.EffectNPCCityConveyGameObjectPools != null)
    {
      for (int index21 = 0; index21 < this.EffectNPCCityConveyGameObjectPools.Length; ++index21)
      {
        if (this.EffectNPCCityConveyGameObjectPools[index21] != null)
        {
          for (int index22 = 0; index22 < this.EffectNPCCityConveyGameObjectPools[index21].Length; ++index22)
          {
            if ((UnityEngine.Object) this.EffectNPCCityConveyGameObjectPools[index21][index22] != (UnityEngine.Object) null)
            {
              ParticleManager.Instance.DeSpawn(this.EffectNPCCityConveyGameObjectPools[index21][index22]);
              this.EffectNPCCityConveyGameObjectPools[index21][index22] = (GameObject) null;
              this.EffectNPCCityConveyTransformPools[index21][index22] = (Transform) null;
              this.EffectNPCCityConveyParticlePools[index21][index22] = (ParticleSystem) null;
              this.EffectNPCCityConveyParticlePools_one[index21][index22] = (ParticleSystem) null;
              this.EffectNPCCityConveyParticlePools_two[index21][index22] = (ParticleSystem) null;
              this.EffectNPCCityConveyParticlePools_thr[index21][index22] = (ParticleSystem) null;
            }
          }
          this.EffectNPCCityConveyGameObjectPools[index21] = (GameObject[]) null;
          this.EffectNPCCityConveyTransformPools[index21] = (Transform[]) null;
          this.EffectNPCCityConveyParticlePools[index21] = (ParticleSystem[]) null;
          this.EffectNPCCityConveyParticlePools_one[index21] = (ParticleSystem[]) null;
          this.EffectNPCCityConveyParticlePools_two[index21] = (ParticleSystem[]) null;
          this.EffectNPCCityConveyParticlePools_thr[index21] = (ParticleSystem[]) null;
        }
      }
    }
    this.EffectNPCCityConveyGameObjectPools = (GameObject[][]) null;
    this.EffectNPCCityConveyTransformPools = (Transform[][]) null;
    this.EffectNPCCityConveyParticlePools = (ParticleSystem[][]) null;
    this.EffectNPCCityConveyParticlePools_one = (ParticleSystem[][]) null;
    this.EffectNPCCityConveyParticlePools_two = (ParticleSystem[][]) null;
    this.EffectNPCCityConveyParticlePools_thr = (ParticleSystem[][]) null;
    this.EffectYolkWinGameObject = (GameObject) null;
    this.EffectYolkLoseGameObject = (GameObject) null;
    this.EffectYolkShieldGameObject = (GameObject) null;
    this.EffectBigYolkWinGameObject = (GameObject) null;
    this.EffectBigYolkLoseGameObject = (GameObject) null;
    this.EffectBigYolkShieldGameObject = (GameObject) null;
    this.EffectYolkWinTransform = (Transform) null;
    this.EffectYolkLoseTransform = (Transform) null;
    this.EffectYolkShieldTransform = (Transform) null;
    this.EffectBigYolkWinTransform = (Transform) null;
    this.EffectBigYolkLoseTransform = (Transform) null;
    this.EffectBigYolkShieldTransform = (Transform) null;
    this.EffectYolkWinParticle = (ParticleSystem) null;
    this.EffectYolkWinParticle_one = (ParticleSystem) null;
    this.EffectYolkWinParticle_two = (ParticleSystem) null;
    this.EffectYolkWinParticle_thr = (ParticleSystem) null;
    this.EffectYolkWinParticle_tho = (ParticleSystem) null;
    this.EffectYolkLoseParticle = (ParticleSystem) null;
    this.EffectYolkLoseParticle_one = (ParticleSystem) null;
    this.EffectYolkShieldParticle = (ParticleSystem) null;
    this.EffectYolkShieldParticle_one = (ParticleSystem) null;
    this.EffectYolkShieldParticle_two = (ParticleSystem) null;
    this.EffectYolkShieldParticle_thr = (ParticleSystem) null;
    this.EffectBigYolkWinParticle = (ParticleSystem) null;
    this.EffectBigYolkWinParticle_one = (ParticleSystem) null;
    this.EffectBigYolkWinParticle_two = (ParticleSystem) null;
    this.EffectBigYolkWinParticle_thr = (ParticleSystem) null;
    this.EffectBigYolkWinParticle_for = (ParticleSystem) null;
    this.EffectBigYolkLoseParticle = (ParticleSystem) null;
    this.EffectBigYolkLoseParticle_one = (ParticleSystem) null;
    this.EffectBigYolkLoseParticle_two = (ParticleSystem) null;
    this.EffectBigYolkShieldParticle = (ParticleSystem) null;
    this.EffectBigYolkShieldParticle_one = (ParticleSystem) null;
    this.EffectBigYolkShieldParticle_two = (ParticleSystem) null;
    this.EffectBigYolkShieldParticle_thr = (ParticleSystem) null;
    if (this.WinpoolCounter != null)
      Array.Clear((Array) this.WinpoolCounter, 0, this.WinpoolCounter.Length);
    if (this.LosepoolCounter != null)
      Array.Clear((Array) this.LosepoolCounter, 0, this.LosepoolCounter.Length);
    if (this.ShieldpoolCounter != null)
      Array.Clear((Array) this.ShieldpoolCounter, 0, this.ShieldpoolCounter.Length);
    if (this.ConveypoolCounter != null)
      Array.Clear((Array) this.ConveypoolCounter, 0, this.ConveypoolCounter.Length);
    if (this.EnemyLosepoolCounter != null)
      Array.Clear((Array) this.EnemyLosepoolCounter, 0, this.EnemyLosepoolCounter.Length);
    if (this.NPCCityConveypoolCounter == null)
      return;
    Array.Clear((Array) this.NPCCityConveypoolCounter, 0, this.NPCCityConveypoolCounter.Length);
  }

  public void IniEffect(int rowNum, int colNum, float tileBaseScale, bool bfront = false)
  {
    this.bFront = bfront;
    this.bBack = !this.bFront ? ((ActivityManager.Instance.bSpecialMonsterTreasureEvent & 2UL) <= 0UL ? (byte) 1 : (byte) 0) : (byte) 1;
    this.EffectWinGameObject = new GameObject[colNum][];
    this.EffectLoseGameObject = new GameObject[colNum][];
    this.EffectShieldGameObject = new GameObject[colNum][];
    this.EffectConveyGameObject = new GameObject[colNum][];
    this.EffectEnemyLoseGameObject = new GameObject[colNum][];
    this.EffectNPCCityConveyGameObject = new GameObject[colNum][];
    this.EffectWinTransform = new Transform[colNum][];
    this.EffectLoseTransform = new Transform[colNum][];
    this.EffectShieldTransform = new Transform[colNum][];
    this.EffectConveyTransform = new Transform[colNum][];
    this.EffectEnemyLoseTransform = new Transform[colNum][];
    this.EffectNPCCityConveyTransform = new Transform[colNum][];
    this.EffectWinParticle = new ParticleSystem[colNum][];
    this.EffectLoseParticle = new ParticleSystem[colNum][];
    this.EffectShieldParticle = new ParticleSystem[colNum][];
    this.EffectShieldParticle_one = new ParticleSystem[colNum][];
    this.EffectConveyParticle = new ParticleSystem[colNum][];
    this.EffectConveyParticle_one = new ParticleSystem[colNum][];
    this.EffectConveyParticle_two = new ParticleSystem[colNum][];
    this.EffectConveyParticle_thr = new ParticleSystem[colNum][];
    this.EffectEnemyLoseParticle = new ParticleSystem[colNum][];
    this.EffectNPCCityConveyParticle = new ParticleSystem[colNum][];
    this.EffectNPCCityConveyParticle_one = new ParticleSystem[colNum][];
    this.EffectNPCCityConveyParticle_two = new ParticleSystem[colNum][];
    this.EffectNPCCityConveyParticle_thr = new ParticleSystem[colNum][];
    for (int index = 0; index < colNum; ++index)
    {
      this.EffectWinGameObject[index] = new GameObject[rowNum];
      this.EffectLoseGameObject[index] = new GameObject[rowNum];
      this.EffectShieldGameObject[index] = new GameObject[rowNum];
      this.EffectConveyGameObject[index] = new GameObject[rowNum];
      this.EffectEnemyLoseGameObject[index] = new GameObject[rowNum];
      this.EffectNPCCityConveyGameObject[index] = new GameObject[rowNum];
      this.EffectWinTransform[index] = new Transform[rowNum];
      this.EffectLoseTransform[index] = new Transform[rowNum];
      this.EffectShieldTransform[index] = new Transform[rowNum];
      this.EffectConveyTransform[index] = new Transform[rowNum];
      this.EffectEnemyLoseTransform[index] = new Transform[rowNum];
      this.EffectNPCCityConveyTransform[index] = new Transform[rowNum];
      this.EffectWinParticle[index] = new ParticleSystem[rowNum];
      this.EffectLoseParticle[index] = new ParticleSystem[rowNum];
      this.EffectShieldParticle[index] = new ParticleSystem[rowNum];
      this.EffectShieldParticle_one[index] = new ParticleSystem[rowNum];
      this.EffectConveyParticle[index] = new ParticleSystem[rowNum];
      this.EffectConveyParticle_one[index] = new ParticleSystem[rowNum];
      this.EffectConveyParticle_two[index] = new ParticleSystem[rowNum];
      this.EffectConveyParticle_thr[index] = new ParticleSystem[rowNum];
      this.EffectEnemyLoseParticle[index] = new ParticleSystem[rowNum];
      this.EffectNPCCityConveyParticle[index] = new ParticleSystem[rowNum];
      this.EffectNPCCityConveyParticle_one[index] = new ParticleSystem[rowNum];
      this.EffectNPCCityConveyParticle_two[index] = new ParticleSystem[rowNum];
      this.EffectNPCCityConveyParticle_thr[index] = new ParticleSystem[rowNum];
      Array.Clear((Array) this.EffectWinGameObject[index], 0, this.EffectWinGameObject[index].Length);
      Array.Clear((Array) this.EffectLoseGameObject[index], 0, this.EffectLoseGameObject[index].Length);
      Array.Clear((Array) this.EffectShieldGameObject[index], 0, this.EffectShieldGameObject[index].Length);
      Array.Clear((Array) this.EffectConveyGameObject[index], 0, this.EffectConveyGameObject[index].Length);
      Array.Clear((Array) this.EffectEnemyLoseGameObject[index], 0, this.EffectLoseGameObject[index].Length);
      Array.Clear((Array) this.EffectNPCCityConveyGameObject[index], 0, this.EffectConveyGameObject[index].Length);
      Array.Clear((Array) this.EffectWinTransform[index], 0, this.EffectWinTransform[index].Length);
      Array.Clear((Array) this.EffectLoseTransform[index], 0, this.EffectLoseTransform[index].Length);
      Array.Clear((Array) this.EffectShieldTransform[index], 0, this.EffectShieldTransform[index].Length);
      Array.Clear((Array) this.EffectConveyTransform[index], 0, this.EffectConveyTransform[index].Length);
      Array.Clear((Array) this.EffectEnemyLoseTransform[index], 0, this.EffectLoseTransform[index].Length);
      Array.Clear((Array) this.EffectNPCCityConveyTransform[index], 0, this.EffectNPCCityConveyTransform[index].Length);
      Array.Clear((Array) this.EffectWinParticle[index], 0, this.EffectWinParticle[index].Length);
      Array.Clear((Array) this.EffectLoseParticle[index], 0, this.EffectLoseParticle[index].Length);
      Array.Clear((Array) this.EffectShieldParticle[index], 0, this.EffectShieldParticle[index].Length);
      Array.Clear((Array) this.EffectShieldParticle_one[index], 0, this.EffectShieldParticle_one[index].Length);
      Array.Clear((Array) this.EffectConveyParticle[index], 0, this.EffectConveyParticle[index].Length);
      Array.Clear((Array) this.EffectConveyParticle_one[index], 0, this.EffectConveyParticle_one[index].Length);
      Array.Clear((Array) this.EffectConveyParticle_two[index], 0, this.EffectConveyParticle_two[index].Length);
      Array.Clear((Array) this.EffectConveyParticle_thr[index], 0, this.EffectConveyParticle_thr[index].Length);
      Array.Clear((Array) this.EffectEnemyLoseParticle[index], 0, this.EffectLoseParticle[index].Length);
      Array.Clear((Array) this.EffectNPCCityConveyParticle[index], 0, this.EffectNPCCityConveyParticle[index].Length);
      Array.Clear((Array) this.EffectNPCCityConveyParticle_one[index], 0, this.EffectNPCCityConveyParticle_one[index].Length);
      Array.Clear((Array) this.EffectNPCCityConveyParticle_two[index], 0, this.EffectNPCCityConveyParticle_two[index].Length);
      Array.Clear((Array) this.EffectNPCCityConveyParticle_thr[index], 0, this.EffectNPCCityConveyParticle_thr[index].Length);
    }
    this.EffectWinGameObjectPools = new GameObject[rowNum << 1][];
    this.EffectWinTransformPools = new Transform[rowNum << 1][];
    this.EffectWinParticlePools = new ParticleSystem[rowNum << 1][];
    this.WinpoolCounter = new int[rowNum << 1];
    Array.Clear((Array) this.EffectWinGameObjectPools, 0, this.EffectWinGameObjectPools.Length);
    Array.Clear((Array) this.EffectWinTransformPools, 0, this.EffectWinTransformPools.Length);
    Array.Clear((Array) this.EffectWinParticlePools, 0, this.EffectWinParticlePools.Length);
    this.EffectLoseGameObjectPools = new GameObject[rowNum << 1][];
    this.EffectLoseTransformPools = new Transform[rowNum << 1][];
    this.EffectLoseParticlePools = new ParticleSystem[rowNum << 1][];
    this.LosepoolCounter = new int[rowNum << 1];
    Array.Clear((Array) this.EffectLoseGameObjectPools, 0, this.EffectLoseGameObjectPools.Length);
    Array.Clear((Array) this.EffectLoseTransformPools, 0, this.EffectLoseTransformPools.Length);
    Array.Clear((Array) this.EffectLoseParticlePools, 0, this.EffectLoseParticlePools.Length);
    this.EffectEnemyLoseGameObjectPools = new GameObject[rowNum << 1][];
    this.EffectEnemyLoseTransformPools = new Transform[rowNum << 1][];
    this.EffectEnemyLoseParticlePools = new ParticleSystem[rowNum << 1][];
    this.EnemyLosepoolCounter = new int[rowNum << 1];
    Array.Clear((Array) this.EffectEnemyLoseGameObjectPools, 0, this.EffectEnemyLoseGameObjectPools.Length);
    Array.Clear((Array) this.EffectEnemyLoseTransformPools, 0, this.EffectEnemyLoseTransformPools.Length);
    Array.Clear((Array) this.EffectEnemyLoseParticlePools, 0, this.EffectEnemyLoseParticlePools.Length);
    this.EffectShieldGameObjectPools = new GameObject[rowNum << 1][];
    this.EffectShieldTransformPools = new Transform[rowNum << 1][];
    this.EffectShieldParticlePools = new ParticleSystem[rowNum << 1][];
    this.EffectShieldParticlePools_one = new ParticleSystem[rowNum << 1][];
    this.ShieldpoolCounter = new int[rowNum << 1];
    Array.Clear((Array) this.EffectShieldGameObjectPools, 0, this.EffectShieldGameObjectPools.Length);
    Array.Clear((Array) this.EffectShieldTransformPools, 0, this.EffectShieldTransformPools.Length);
    Array.Clear((Array) this.EffectShieldParticlePools, 0, this.EffectShieldParticlePools.Length);
    Array.Clear((Array) this.EffectShieldParticlePools_one, 0, this.EffectShieldParticlePools_one.Length);
    this.EffectConveyGameObjectPools = new GameObject[rowNum << 1][];
    this.EffectConveyTransformPools = new Transform[rowNum << 1][];
    this.EffectConveyParticlePools = new ParticleSystem[rowNum << 1][];
    this.EffectConveyParticlePools_one = new ParticleSystem[rowNum << 1][];
    this.EffectConveyParticlePools_two = new ParticleSystem[rowNum << 1][];
    this.EffectConveyParticlePools_thr = new ParticleSystem[rowNum << 1][];
    this.ConveypoolCounter = new int[rowNum << 1];
    Array.Clear((Array) this.EffectConveyGameObjectPools, 0, this.EffectConveyGameObjectPools.Length);
    Array.Clear((Array) this.EffectConveyTransformPools, 0, this.EffectConveyTransformPools.Length);
    Array.Clear((Array) this.EffectConveyParticlePools, 0, this.EffectConveyParticlePools.Length);
    Array.Clear((Array) this.EffectConveyParticlePools_one, 0, this.EffectConveyParticlePools_one.Length);
    Array.Clear((Array) this.EffectConveyParticlePools_two, 0, this.EffectConveyParticlePools_two.Length);
    Array.Clear((Array) this.EffectConveyParticlePools_thr, 0, this.EffectConveyParticlePools_thr.Length);
    this.EffectNPCCityConveyGameObjectPools = new GameObject[rowNum << 1][];
    this.EffectNPCCityConveyTransformPools = new Transform[rowNum << 1][];
    this.EffectNPCCityConveyParticlePools = new ParticleSystem[rowNum << 1][];
    this.EffectNPCCityConveyParticlePools_one = new ParticleSystem[rowNum << 1][];
    this.EffectNPCCityConveyParticlePools_two = new ParticleSystem[rowNum << 1][];
    this.EffectNPCCityConveyParticlePools_thr = new ParticleSystem[rowNum << 1][];
    this.NPCCityConveypoolCounter = new int[rowNum << 1];
    Array.Clear((Array) this.EffectNPCCityConveyGameObjectPools, 0, this.EffectNPCCityConveyGameObjectPools.Length);
    Array.Clear((Array) this.EffectNPCCityConveyTransformPools, 0, this.EffectNPCCityConveyTransformPools.Length);
    Array.Clear((Array) this.EffectNPCCityConveyParticlePools, 0, this.EffectNPCCityConveyParticlePools.Length);
    Array.Clear((Array) this.EffectNPCCityConveyParticlePools_one, 0, this.EffectNPCCityConveyParticlePools_one.Length);
    Array.Clear((Array) this.EffectNPCCityConveyParticlePools_two, 0, this.EffectNPCCityConveyParticlePools_two.Length);
    Array.Clear((Array) this.EffectNPCCityConveyParticlePools_thr, 0, this.EffectNPCCityConveyParticlePools_thr.Length);
    for (int index = 0; index < this.WinpoolCounter.Length; ++index)
    {
      this.WinpoolCounter[index] = -1;
      this.LosepoolCounter[index] = -1;
      this.ShieldpoolCounter[index] = -1;
      this.ConveypoolCounter[index] = -1;
      this.EnemyLosepoolCounter[index] = -1;
      this.NPCCityConveypoolCounter[index] = -1;
    }
    this.EffectWinGameObjectPools[0] = new GameObject[colNum >> 1];
    this.EffectWinTransformPools[0] = new Transform[colNum >> 1];
    this.EffectWinParticlePools[0] = new ParticleSystem[colNum >> 1];
    this.EffectLoseGameObjectPools[0] = new GameObject[colNum >> 1];
    this.EffectLoseTransformPools[0] = new Transform[colNum >> 1];
    this.EffectLoseParticlePools[0] = new ParticleSystem[colNum >> 1];
    this.EffectEnemyLoseGameObjectPools[0] = new GameObject[colNum >> 1];
    this.EffectEnemyLoseTransformPools[0] = new Transform[colNum >> 1];
    this.EffectEnemyLoseParticlePools[0] = new ParticleSystem[colNum >> 1];
    this.EffectShieldGameObjectPools[0] = new GameObject[colNum >> 1];
    this.EffectShieldTransformPools[0] = new Transform[colNum >> 1];
    this.EffectShieldParticlePools[0] = new ParticleSystem[colNum >> 1];
    this.EffectShieldParticlePools_one[0] = new ParticleSystem[colNum >> 1];
    this.EffectConveyGameObjectPools[0] = new GameObject[colNum >> 1];
    this.EffectConveyTransformPools[0] = new Transform[colNum >> 1];
    this.EffectConveyParticlePools[0] = new ParticleSystem[colNum >> 1];
    this.EffectConveyParticlePools_one[0] = new ParticleSystem[colNum >> 1];
    this.EffectConveyParticlePools_two[0] = new ParticleSystem[colNum >> 1];
    this.EffectConveyParticlePools_thr[0] = new ParticleSystem[colNum >> 1];
    this.EffectNPCCityConveyGameObjectPools[0] = new GameObject[colNum >> 1];
    this.EffectNPCCityConveyTransformPools[0] = new Transform[colNum >> 1];
    this.EffectNPCCityConveyParticlePools[0] = new ParticleSystem[colNum >> 1];
    this.EffectNPCCityConveyParticlePools_one[0] = new ParticleSystem[colNum >> 1];
    this.EffectNPCCityConveyParticlePools_two[0] = new ParticleSystem[colNum >> 1];
    this.EffectNPCCityConveyParticlePools_thr[0] = new ParticleSystem[colNum >> 1];
    if (this.bBack == (byte) 1)
    {
      this.EffectYolkWinGameObject = ParticleManager.Instance.Spawn((ushort) 379, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectYolkLoseGameObject = ParticleManager.Instance.Spawn((ushort) 380, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectYolkShieldGameObject = ParticleManager.Instance.Spawn((ushort) 381, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectBigYolkWinGameObject = ParticleManager.Instance.Spawn((ushort) 383, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectBigYolkLoseGameObject = ParticleManager.Instance.Spawn((ushort) 384, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectBigYolkShieldGameObject = ParticleManager.Instance.Spawn((ushort) 385, (Transform) null, Vector3.zero, 1f, false, false);
    }
    else
    {
      this.EffectYolkWinGameObject = ParticleManager.Instance.Spawn((ushort) 60104, (Transform) null, Vector3.zero, 1f, false, false);
      if ((UnityEngine.Object) this.EffectYolkWinGameObject == (UnityEngine.Object) null)
        this.EffectYolkWinGameObject = ParticleManager.Instance.Spawn((ushort) 379, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectYolkLoseGameObject = ParticleManager.Instance.Spawn((ushort) 60105, (Transform) null, Vector3.zero, 1f, false, false);
      if ((UnityEngine.Object) this.EffectYolkLoseGameObject == (UnityEngine.Object) null)
        this.EffectYolkLoseGameObject = ParticleManager.Instance.Spawn((ushort) 380, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectYolkShieldGameObject = ParticleManager.Instance.Spawn((ushort) 60106, (Transform) null, Vector3.zero, 1f, false, false);
      if ((UnityEngine.Object) this.EffectYolkShieldGameObject == (UnityEngine.Object) null)
        this.EffectYolkShieldGameObject = ParticleManager.Instance.Spawn((ushort) 381, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectBigYolkWinGameObject = ParticleManager.Instance.Spawn((ushort) 60107, (Transform) null, Vector3.zero, 1f, false, false);
      if ((UnityEngine.Object) this.EffectBigYolkWinGameObject == (UnityEngine.Object) null)
        this.EffectBigYolkWinGameObject = ParticleManager.Instance.Spawn((ushort) 383, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectBigYolkLoseGameObject = ParticleManager.Instance.Spawn((ushort) 60108, (Transform) null, Vector3.zero, 1f, false, false);
      if ((UnityEngine.Object) this.EffectBigYolkLoseGameObject == (UnityEngine.Object) null)
        this.EffectBigYolkLoseGameObject = ParticleManager.Instance.Spawn((ushort) 384, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectBigYolkShieldGameObject = ParticleManager.Instance.Spawn((ushort) 60109, (Transform) null, Vector3.zero, 1f, false, false);
      if ((UnityEngine.Object) this.EffectBigYolkShieldGameObject == (UnityEngine.Object) null)
        this.EffectBigYolkShieldGameObject = ParticleManager.Instance.Spawn((ushort) 385, (Transform) null, Vector3.zero, 1f, false, false);
    }
    this.EffectYolkWinTransform = this.EffectYolkWinGameObject.transform;
    this.EffectYolkLoseTransform = this.EffectYolkLoseGameObject.transform;
    this.EffectYolkShieldTransform = this.EffectYolkShieldGameObject.transform;
    this.EffectBigYolkWinTransform = this.EffectBigYolkWinGameObject.transform;
    this.EffectBigYolkLoseTransform = this.EffectBigYolkLoseGameObject.transform;
    this.EffectBigYolkShieldTransform = this.EffectBigYolkShieldGameObject.transform;
    this.EffectYolkWinTransform.SetParent(this.YolkLayoutTransform);
    this.EffectYolkLoseTransform.SetParent(this.YolkLayoutTransform);
    this.EffectYolkShieldTransform.SetParent(this.YolkLayoutTransform);
    this.EffectBigYolkWinTransform.SetParent(this.YolkLayoutTransform);
    this.EffectBigYolkLoseTransform.SetParent(this.YolkLayoutTransform);
    this.EffectBigYolkShieldTransform.SetParent(this.YolkLayoutTransform);
    this.EffectYolkWinTransform.localPosition = this.inipos;
    this.EffectYolkLoseTransform.localPosition = this.inipos;
    this.EffectYolkShieldTransform.localPosition = this.inipos;
    this.EffectBigYolkWinTransform.localPosition = this.inipos;
    this.EffectBigYolkLoseTransform.localPosition = this.inipos;
    this.EffectBigYolkShieldTransform.localPosition = this.inipos;
    this.EffectYolkWinParticle = this.EffectYolkWinTransform.GetChild(0).GetComponent<ParticleSystem>();
    this.EffectYolkWinParticle_one = this.EffectYolkWinTransform.GetChild(1).GetComponent<ParticleSystem>();
    this.EffectYolkWinParticle_two = this.EffectYolkWinTransform.GetChild(2).GetComponent<ParticleSystem>();
    this.EffectYolkWinParticle_thr = this.EffectYolkWinTransform.GetChild(3).GetComponent<ParticleSystem>();
    this.EffectYolkWinParticle_tho = this.EffectYolkWinTransform.GetChild(4).GetComponent<ParticleSystem>();
    this.EffectYolkLoseParticle = this.EffectYolkLoseTransform.GetChild(0).GetComponent<ParticleSystem>();
    this.EffectYolkLoseParticle_one = this.EffectYolkLoseTransform.GetChild(1).GetComponent<ParticleSystem>();
    this.EffectYolkShieldParticle = this.EffectYolkShieldTransform.GetChild(0).GetComponent<ParticleSystem>();
    this.EffectYolkShieldParticle_one = this.EffectYolkShieldTransform.GetChild(1).GetComponent<ParticleSystem>();
    this.EffectYolkShieldParticle_two = this.EffectYolkShieldTransform.GetChild(2).GetComponent<ParticleSystem>();
    this.EffectYolkShieldParticle_thr = this.EffectYolkShieldTransform.GetChild(3).GetComponent<ParticleSystem>();
    this.EffectBigYolkWinParticle = this.EffectBigYolkWinTransform.GetChild(0).GetComponent<ParticleSystem>();
    this.EffectBigYolkWinParticle_one = this.EffectBigYolkWinTransform.GetChild(1).GetComponent<ParticleSystem>();
    this.EffectBigYolkWinParticle_two = this.EffectBigYolkWinTransform.GetChild(2).GetComponent<ParticleSystem>();
    this.EffectBigYolkWinParticle_thr = this.EffectBigYolkWinTransform.GetChild(3).GetComponent<ParticleSystem>();
    this.EffectBigYolkWinParticle_for = this.EffectBigYolkWinTransform.GetChild(4).GetComponent<ParticleSystem>();
    this.EffectBigYolkLoseParticle = this.EffectBigYolkLoseTransform.GetChild(0).GetComponent<ParticleSystem>();
    this.EffectBigYolkLoseParticle_one = this.EffectBigYolkLoseTransform.GetChild(1).GetComponent<ParticleSystem>();
    this.EffectBigYolkLoseParticle_two = this.EffectBigYolkLoseTransform.GetChild(2).GetComponent<ParticleSystem>();
    this.EffectBigYolkShieldParticle = this.EffectBigYolkShieldTransform.GetChild(0).GetComponent<ParticleSystem>();
    this.EffectBigYolkShieldParticle_one = this.EffectBigYolkShieldTransform.GetChild(1).GetComponent<ParticleSystem>();
    this.EffectBigYolkShieldParticle_two = this.EffectBigYolkShieldTransform.GetChild(2).GetComponent<ParticleSystem>();
    this.EffectBigYolkShieldParticle_thr = this.EffectBigYolkShieldTransform.GetChild(3).GetComponent<ParticleSystem>();
    this.YolkWinstartSize = this.EffectYolkWinParticle.startSize;
    this.YolkWinstartSize_one = this.EffectYolkWinParticle_one.startSize;
    this.YolkWinstartSize_two = this.EffectYolkWinParticle_two.startSize;
    this.YolkWinstartSize_thr = this.EffectYolkWinParticle_thr.startSize;
    this.YolkWinstartSize_tho = this.EffectYolkWinParticle_tho.startSize;
    this.YolkWinlifetime = this.EffectYolkWinParticle.startLifetime;
    this.YolkWinlifetime_one = this.EffectYolkWinParticle_one.startLifetime;
    this.YolkWinlifetime_two = this.EffectYolkWinParticle_two.startLifetime;
    this.YolkWinlifetime_thr = this.EffectYolkWinParticle_thr.startLifetime;
    this.YolkWinlifetime_tho = this.EffectYolkWinParticle_tho.startLifetime;
    this.YolkLosestartSize = this.EffectYolkLoseParticle.startSize;
    this.YolkLosestartSize_one = this.EffectYolkLoseParticle_one.startSize;
    this.YolkLoselifetime = this.EffectYolkLoseParticle.startLifetime;
    this.YolkLoselifetime_one = this.EffectYolkLoseParticle_one.startLifetime;
    this.YolkShieldstartSize = this.EffectYolkShieldParticle.startSize;
    this.YolkShieldstartSize_one = this.EffectYolkShieldParticle_one.startSize;
    this.YolkShieldstartSize_two = this.EffectYolkShieldParticle_two.startSize;
    this.YolkShieldstartSize_thr = this.EffectYolkShieldParticle_thr.startSize;
    this.YolkShieldlifetime = this.EffectYolkShieldParticle.startLifetime;
    this.YolkShieldlifetime_one = this.EffectYolkShieldParticle_one.startLifetime;
    this.YolkShieldlifetime_two = this.EffectYolkShieldParticle_two.startLifetime;
    this.YolkShieldlifetime_thr = this.EffectYolkShieldParticle_thr.startLifetime;
    this.BigYolkWinstartSize = this.EffectBigYolkWinParticle.startSize;
    this.BigYolkWinstartSize_one = this.EffectBigYolkWinParticle_one.startSize;
    this.BigYolkWinstartSize_two = this.EffectBigYolkWinParticle_two.startSize;
    this.BigYolkWinstartSize_thr = this.EffectBigYolkWinParticle_thr.startSize;
    this.BigYolkWinstartSize_for = this.EffectBigYolkWinParticle_for.startSize;
    this.BigYolkWinlifetime = this.EffectBigYolkWinParticle.startLifetime;
    this.BigYolkWinlifetime_one = this.EffectBigYolkWinParticle_one.startLifetime;
    this.BigYolkWinlifetime_two = this.EffectBigYolkWinParticle_two.startLifetime;
    this.BigYolkWinlifetime_thr = this.EffectBigYolkWinParticle_thr.startLifetime;
    this.BigYolkWinlifetime_for = this.EffectBigYolkWinParticle_for.startLifetime;
    this.BigYolkLosestartSize = this.EffectBigYolkLoseParticle.startSize;
    this.BigYolkLosestartSize_one = this.EffectBigYolkLoseParticle_one.startSize;
    this.BigYolkLosestartSize_two = this.EffectBigYolkLoseParticle_two.startSize;
    this.BigYolkLoselifetime = this.EffectBigYolkLoseParticle.startLifetime;
    this.BigYolkLoselifetime_one = this.EffectBigYolkLoseParticle_one.startLifetime;
    this.BigYolkLoselifetime_two = this.EffectBigYolkLoseParticle_two.startLifetime;
    this.BigYolkShieldstartSize = this.EffectBigYolkShieldParticle.startSize;
    this.BigYolkShieldstartSize_one = this.EffectBigYolkShieldParticle_one.startSize;
    this.BigYolkShieldstartSize_two = this.EffectBigYolkShieldParticle_two.startSize;
    this.BigYolkShieldstartSize_thr = this.EffectBigYolkShieldParticle_thr.startSize;
    this.BigYolkShieldlifetime = this.EffectBigYolkShieldParticle.startLifetime;
    this.BigYolkShieldlifetime_one = this.EffectBigYolkShieldParticle_one.startLifetime;
    this.BigYolkShieldlifetime_two = this.EffectBigYolkShieldParticle_two.startLifetime;
    this.BigYolkShieldlifetime_thr = this.EffectBigYolkShieldParticle_thr.startLifetime;
    if (this.bBack == (byte) 1)
    {
      for (int index = 0; index < this.EffectWinGameObjectPools[0].Length; ++index)
      {
        this.EffectWinGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 198, (Transform) null, Vector3.zero, 1f, false, false);
        this.EffectWinTransformPools[0][index] = this.EffectWinGameObjectPools[0][index].transform;
        this.EffectWinTransformPools[0][index].SetParent(this.WinLayoutTransform);
        this.EffectWinTransformPools[0][index].localPosition = this.inipos;
        this.EffectWinParticlePools[0][index] = this.EffectWinTransformPools[0][index].GetChild(0).GetComponent<ParticleSystem>();
        this.EffectLoseGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 197, (Transform) null, Vector3.zero, 1f, false, false);
        this.EffectLoseTransformPools[0][index] = this.EffectLoseGameObjectPools[0][index].transform;
        this.EffectLoseTransformPools[0][index].SetParent(this.LoseLayoutTransform);
        this.EffectLoseTransformPools[0][index].localPosition = this.inipos;
        this.EffectLoseParticlePools[0][index] = this.EffectLoseTransformPools[0][index].GetChild(0).GetComponent<ParticleSystem>();
        this.EffectEnemyLoseGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 387, (Transform) null, Vector3.zero, 1f, false, false);
        this.EffectEnemyLoseTransformPools[0][index] = this.EffectEnemyLoseGameObjectPools[0][index].transform;
        this.EffectEnemyLoseTransformPools[0][index].SetParent(this.EnemyLoseLayoutTransform);
        this.EffectEnemyLoseTransformPools[0][index].localPosition = this.inipos;
        this.EffectEnemyLoseParticlePools[0][index] = this.EffectEnemyLoseTransformPools[0][index].GetChild(0).GetComponent<ParticleSystem>();
        this.EffectShieldGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 199, (Transform) null, Vector3.zero, 1f, false, false);
        this.EffectShieldTransformPools[0][index] = this.EffectShieldGameObjectPools[0][index].transform;
        this.EffectShieldTransformPools[0][index].SetParent(this.ShieldLayoutTransform);
        this.EffectShieldTransformPools[0][index].localPosition = this.inipos;
        this.EffectShieldParticlePools[0][index] = this.EffectShieldTransformPools[0][index].GetChild(0).GetComponent<ParticleSystem>();
        this.EffectShieldParticlePools_one[0][index] = this.EffectShieldTransformPools[0][index].GetChild(1).GetComponent<ParticleSystem>();
        this.EffectConveyGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 332, (Transform) null, Vector3.zero, 1f, false, false, false);
        this.EffectConveyTransformPools[0][index] = this.EffectConveyGameObjectPools[0][index].transform;
        this.EffectConveyTransformPools[0][index].SetParent(this.ConveyLayoutTransform);
        this.EffectConveyTransformPools[0][index].localPosition = this.inipos;
        this.EffectConveyParticlePools[0][index] = this.EffectConveyTransformPools[0][index].GetChild(0).GetComponent<ParticleSystem>();
        this.EffectConveyParticlePools_one[0][index] = this.EffectConveyTransformPools[0][index].GetChild(1).GetComponent<ParticleSystem>();
        this.EffectConveyParticlePools_two[0][index] = this.EffectConveyTransformPools[0][index].GetChild(2).GetComponent<ParticleSystem>();
        this.EffectConveyParticlePools_thr[0][index] = this.EffectConveyTransformPools[0][index].GetChild(3).GetComponent<ParticleSystem>();
        this.EffectNPCCityConveyGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 390, (Transform) null, Vector3.zero, 1f, false, false, false);
        this.EffectNPCCityConveyTransformPools[0][index] = this.EffectNPCCityConveyGameObjectPools[0][index].transform;
        this.EffectNPCCityConveyTransformPools[0][index].SetParent(this.NPCCityConveyLayoutTransform);
        this.EffectNPCCityConveyTransformPools[0][index].localPosition = this.inipos;
        this.EffectNPCCityConveyParticlePools[0][index] = this.EffectNPCCityConveyTransformPools[0][index].GetChild(0).GetComponent<ParticleSystem>();
        this.EffectNPCCityConveyParticlePools_one[0][index] = this.EffectNPCCityConveyTransformPools[0][index].GetChild(1).GetComponent<ParticleSystem>();
        this.EffectNPCCityConveyParticlePools_two[0][index] = this.EffectNPCCityConveyTransformPools[0][index].GetChild(2).GetComponent<ParticleSystem>();
        this.EffectNPCCityConveyParticlePools_thr[0][index] = this.EffectNPCCityConveyTransformPools[0][index].GetChild(3).GetComponent<ParticleSystem>();
      }
    }
    else
    {
      for (int index = 0; index < this.EffectWinGameObjectPools[0].Length; ++index)
      {
        this.EffectWinGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 60102, (Transform) null, Vector3.zero, 1f, false, false);
        if ((UnityEngine.Object) this.EffectWinGameObjectPools[0][index] == (UnityEngine.Object) null)
          this.EffectWinGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 198, (Transform) null, Vector3.zero, 1f, false, false);
        this.EffectWinTransformPools[0][index] = this.EffectWinGameObjectPools[0][index].transform;
        this.EffectWinTransformPools[0][index].SetParent(this.WinLayoutTransform);
        this.EffectWinTransformPools[0][index].localPosition = this.inipos;
        this.EffectWinParticlePools[0][index] = this.EffectWinTransformPools[0][index].GetChild(0).GetComponent<ParticleSystem>();
        this.EffectLoseGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 60101, (Transform) null, Vector3.zero, 1f, false, false);
        if ((UnityEngine.Object) this.EffectLoseGameObjectPools[0][index] == (UnityEngine.Object) null)
          this.EffectLoseGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 197, (Transform) null, Vector3.zero, 1f, false, false);
        this.EffectLoseTransformPools[0][index] = this.EffectLoseGameObjectPools[0][index].transform;
        this.EffectLoseTransformPools[0][index].SetParent(this.LoseLayoutTransform);
        this.EffectLoseTransformPools[0][index].localPosition = this.inipos;
        this.EffectLoseParticlePools[0][index] = this.EffectLoseTransformPools[0][index].GetChild(0).GetComponent<ParticleSystem>();
        this.EffectEnemyLoseGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 60110, (Transform) null, Vector3.zero, 1f, false, false);
        if ((UnityEngine.Object) this.EffectEnemyLoseGameObjectPools[0][index] == (UnityEngine.Object) null)
          this.EffectEnemyLoseGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 387, (Transform) null, Vector3.zero, 1f, false, false);
        this.EffectEnemyLoseTransformPools[0][index] = this.EffectEnemyLoseGameObjectPools[0][index].transform;
        this.EffectEnemyLoseTransformPools[0][index].SetParent(this.EnemyLoseLayoutTransform);
        this.EffectEnemyLoseTransformPools[0][index].localPosition = this.inipos;
        this.EffectEnemyLoseParticlePools[0][index] = this.EffectEnemyLoseTransformPools[0][index].GetChild(0).GetComponent<ParticleSystem>();
        this.EffectShieldGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 60103, (Transform) null, Vector3.zero, 1f, false, false);
        if ((UnityEngine.Object) this.EffectShieldGameObjectPools[0][index] == (UnityEngine.Object) null)
          this.EffectShieldGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 199, (Transform) null, Vector3.zero, 1f, false, false);
        this.EffectShieldTransformPools[0][index] = this.EffectShieldGameObjectPools[0][index].transform;
        this.EffectShieldTransformPools[0][index].SetParent(this.ShieldLayoutTransform);
        this.EffectShieldTransformPools[0][index].localPosition = this.inipos;
        this.EffectShieldParticlePools[0][index] = this.EffectShieldTransformPools[0][index].GetChild(0).GetComponent<ParticleSystem>();
        this.EffectShieldParticlePools_one[0][index] = this.EffectShieldTransformPools[0][index].GetChild(1).GetComponent<ParticleSystem>();
        this.EffectConveyGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 60111, (Transform) null, Vector3.zero, 1f, false, false, false);
        if ((UnityEngine.Object) this.EffectConveyGameObjectPools[0][index] == (UnityEngine.Object) null)
          this.EffectConveyGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 332, (Transform) null, Vector3.zero, 1f, false, false, false);
        this.EffectConveyTransformPools[0][index] = this.EffectConveyGameObjectPools[0][index].transform;
        this.EffectConveyTransformPools[0][index].SetParent(this.ConveyLayoutTransform);
        this.EffectConveyTransformPools[0][index].localPosition = this.inipos;
        this.EffectConveyParticlePools[0][index] = this.EffectConveyTransformPools[0][index].GetChild(0).GetComponent<ParticleSystem>();
        this.EffectConveyParticlePools_one[0][index] = this.EffectConveyTransformPools[0][index].GetChild(1).GetComponent<ParticleSystem>();
        this.EffectConveyParticlePools_two[0][index] = this.EffectConveyTransformPools[0][index].GetChild(2).GetComponent<ParticleSystem>();
        this.EffectConveyParticlePools_thr[0][index] = this.EffectConveyTransformPools[0][index].GetChild(3).GetComponent<ParticleSystem>();
        this.EffectNPCCityConveyGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 60112, (Transform) null, Vector3.zero, 1f, false, false, false);
        if ((UnityEngine.Object) this.EffectNPCCityConveyGameObjectPools[0][index] == (UnityEngine.Object) null)
          this.EffectNPCCityConveyGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 390, (Transform) null, Vector3.zero, 1f, false, false, false);
        this.EffectNPCCityConveyTransformPools[0][index] = this.EffectNPCCityConveyGameObjectPools[0][index].transform;
        this.EffectNPCCityConveyTransformPools[0][index].SetParent(this.NPCCityConveyLayoutTransform);
        this.EffectNPCCityConveyTransformPools[0][index].localPosition = this.inipos;
        this.EffectNPCCityConveyParticlePools[0][index] = this.EffectNPCCityConveyTransformPools[0][index].GetChild(0).GetComponent<ParticleSystem>();
        this.EffectNPCCityConveyParticlePools_one[0][index] = this.EffectNPCCityConveyTransformPools[0][index].GetChild(1).GetComponent<ParticleSystem>();
        this.EffectNPCCityConveyParticlePools_two[0][index] = this.EffectNPCCityConveyTransformPools[0][index].GetChild(2).GetComponent<ParticleSystem>();
        this.EffectNPCCityConveyParticlePools_thr[0][index] = this.EffectNPCCityConveyTransformPools[0][index].GetChild(3).GetComponent<ParticleSystem>();
      }
    }
    this.WinstartSize = this.EffectWinParticlePools[0][0].startSize;
    this.Winlifetime = this.EffectWinParticlePools[0][0].startLifetime;
    this.LosestartSize = this.EffectLoseParticlePools[0][0].startSize;
    this.Loselifetime = this.EffectLoseParticlePools[0][0].startLifetime;
    this.EnemyLosestartSize = this.EffectEnemyLoseParticlePools[0][0].startSize;
    this.EnemyLoselifetime = this.EffectEnemyLoseParticlePools[0][0].startLifetime;
    this.ShieldstartSize = this.EffectShieldParticlePools[0][0].startSize;
    this.ConveystartSize = this.EffectConveyParticlePools[0][0].startSize;
    this.Conveylifetime = this.EffectConveyParticlePools[0][0].startLifetime;
    this.ConveystartSize_one = this.EffectConveyParticlePools_one[0][0].startSize;
    this.Conveylifetime_one = this.EffectConveyParticlePools_one[0][0].startLifetime;
    this.ConveystartSize_two = this.EffectConveyParticlePools_two[0][0].startSize;
    this.Conveylifetime_two = this.EffectConveyParticlePools_two[0][0].startLifetime;
    this.ConveystartSize_thr = this.EffectConveyParticlePools_thr[0][0].startSize;
    this.Conveylifetime_thr = this.EffectConveyParticlePools_thr[0][0].startLifetime;
    this.NPCCityConveystartSize = this.EffectNPCCityConveyParticlePools[0][0].startSize;
    this.NPCCityConveylifetime = this.EffectNPCCityConveyParticlePools[0][0].startLifetime;
    this.NPCCityConveystartSize_one = this.EffectNPCCityConveyParticlePools_one[0][0].startSize;
    this.NPCCityConveylifetime_one = this.EffectNPCCityConveyParticlePools_one[0][0].startLifetime;
    this.NPCCityConveystartSize_two = this.EffectNPCCityConveyParticlePools_two[0][0].startSize;
    this.NPCCityConveylifetime_two = this.EffectNPCCityConveyParticlePools_two[0][0].startLifetime;
    this.NPCCityConveystartSize_thr = this.EffectNPCCityConveyParticlePools_thr[0][0].startSize;
    this.NPCCityConveylifetime_thr = this.EffectNPCCityConveyParticlePools_thr[0][0].startLifetime;
    this.WinpoolCounter[0] = colNum >> 1;
    this.WinpoolsCounter = 1;
    this.LosepoolCounter[0] = colNum >> 1;
    this.LosepoolsCounter = 1;
    this.EnemyLosepoolCounter[0] = colNum >> 1;
    this.EnemyLosepoolsCounter = 1;
    this.ShieldpoolCounter[0] = colNum >> 1;
    this.ShieldpoolsCounter = 1;
    this.ConveypoolCounter[0] = colNum >> 1;
    this.ConveypoolsCounter = 1;
    this.NPCCityConveypoolCounter[0] = colNum >> 1;
    this.NPCCityConveypoolsCounter = 1;
  }

  public void setEffect(byte effectflag, int row, int col, Vector2 pos, byte effecttype = 0)
  {
    float x = this.RealmGroup.localScale.x;
    if (effecttype > (byte) 0 && effecttype < (byte) 3)
    {
      if (effectflag == (byte) 0)
      {
        this.Yolkrow = this.Yolkcol = -1;
        if (this.EffectYolkWinGameObject.activeSelf)
          this.EffectYolkWinGameObject.SetActive(false);
        if (this.EffectYolkLoseGameObject.activeSelf)
          this.EffectYolkLoseGameObject.SetActive(false);
        if (this.EffectYolkShieldGameObject.activeSelf)
          this.EffectYolkShieldGameObject.SetActive(false);
        if (this.EffectBigYolkWinGameObject.activeSelf)
          this.EffectBigYolkWinGameObject.SetActive(false);
        if (this.EffectBigYolkLoseGameObject.activeSelf)
          this.EffectBigYolkLoseGameObject.SetActive(false);
        if (this.EffectBigYolkShieldGameObject.activeSelf)
          this.EffectBigYolkShieldGameObject.SetActive(false);
      }
      else
      {
        bool flag = false;
        this.Yolkrow = row;
        this.Yolkcol = col;
        if (((int) effectflag & 2) == 0)
        {
          if (this.EffectYolkWinGameObject.activeSelf)
            this.EffectYolkWinGameObject.SetActive(false);
          if (this.EffectBigYolkWinGameObject.activeSelf)
            this.EffectBigYolkWinGameObject.SetActive(false);
        }
        else if (effecttype == (byte) 1)
        {
          if (this.EffectBigYolkWinGameObject.activeSelf)
            this.EffectBigYolkWinGameObject.SetActive(false);
          if (!this.EffectYolkWinGameObject.activeSelf)
          {
            this.EffectYolkWinParticle.startSize = this.YolkWinstartSize * x;
            this.EffectYolkWinParticle_one.startSize = this.YolkWinstartSize_one * x;
            this.EffectYolkWinParticle_two.startSize = this.YolkWinstartSize_two * x;
            this.EffectYolkWinParticle_thr.startSize = this.YolkWinstartSize_thr * x;
            this.EffectYolkWinParticle_tho.startSize = this.YolkWinstartSize_tho * x;
            this.EffectYolkWinParticle.startLifetime = this.YolkWinlifetime * x;
            this.EffectYolkWinParticle_one.startLifetime = this.YolkWinlifetime_one * x;
            this.EffectYolkWinParticle_two.startLifetime = this.YolkWinlifetime_two * x;
            this.EffectYolkWinParticle_thr.startLifetime = this.YolkWinstartSize_thr * x;
            this.EffectYolkWinParticle_tho.startLifetime = this.YolkWinstartSize_tho * x;
            this.EffectYolkWinGameObject.SetActive(true);
            flag = true;
          }
          this.EffectYolkWinTransform.localPosition = (Vector3) pos;
        }
        else
        {
          if (this.EffectYolkWinGameObject.activeSelf)
            this.EffectYolkWinGameObject.SetActive(false);
          if (!this.EffectBigYolkWinGameObject.activeSelf)
          {
            this.EffectBigYolkWinParticle.startSize = this.BigYolkWinstartSize * x;
            this.EffectBigYolkWinParticle_one.startSize = this.BigYolkWinstartSize_one * x;
            this.EffectBigYolkWinParticle_two.startSize = this.BigYolkWinstartSize_two * x;
            this.EffectBigYolkWinParticle_thr.startSize = this.BigYolkWinstartSize_thr * x;
            this.EffectBigYolkWinParticle_for.startSize = this.BigYolkWinstartSize_for * x;
            this.EffectBigYolkWinParticle.startLifetime = this.BigYolkWinlifetime * x;
            this.EffectBigYolkWinParticle_one.startLifetime = this.BigYolkWinlifetime_one * x;
            this.EffectBigYolkWinParticle_two.startLifetime = this.BigYolkWinlifetime_two * x;
            this.EffectBigYolkWinParticle_thr.startLifetime = this.BigYolkWinlifetime_thr * x;
            this.EffectBigYolkWinParticle_for.startLifetime = this.BigYolkWinlifetime_for * x;
            this.EffectBigYolkWinGameObject.SetActive(true);
            flag = true;
          }
          this.EffectBigYolkWinTransform.localPosition = (Vector3) pos;
        }
        if (((int) effectflag & 1) == 0)
        {
          if (this.EffectYolkLoseGameObject.activeSelf)
            this.EffectYolkLoseGameObject.SetActive(false);
          if (this.EffectBigYolkLoseGameObject.activeSelf)
            this.EffectBigYolkLoseGameObject.SetActive(false);
        }
        else if (effecttype == (byte) 1)
        {
          if (this.EffectBigYolkLoseGameObject.activeSelf)
            this.EffectBigYolkLoseGameObject.SetActive(false);
          if (!this.EffectYolkLoseGameObject.activeSelf)
          {
            this.EffectYolkLoseParticle.startSize = this.YolkLosestartSize * x;
            this.EffectYolkLoseParticle_one.startSize = this.YolkLosestartSize_one * x;
            this.EffectYolkLoseParticle.startLifetime = this.YolkLoselifetime * x;
            this.EffectYolkLoseParticle_one.startLifetime = this.YolkLoselifetime_one * x;
            this.EffectYolkLoseGameObject.SetActive(true);
            flag = true;
          }
          this.EffectYolkLoseTransform.localPosition = (Vector3) pos;
        }
        else
        {
          if (this.EffectYolkLoseGameObject.activeSelf)
            this.EffectYolkLoseGameObject.SetActive(false);
          if (!this.EffectBigYolkLoseGameObject.activeSelf)
          {
            this.EffectBigYolkLoseParticle.startSize = this.BigYolkLosestartSize * x;
            this.EffectBigYolkLoseParticle_one.startSize = this.BigYolkLosestartSize_one * x;
            this.EffectBigYolkLoseParticle_two.startSize = this.BigYolkLosestartSize_two * x;
            this.EffectBigYolkLoseParticle.startLifetime = this.BigYolkLoselifetime * x;
            this.EffectBigYolkLoseParticle_one.startLifetime = this.BigYolkLoselifetime_one * x;
            this.EffectBigYolkLoseParticle_two.startLifetime = this.BigYolkLoselifetime_two * x;
            this.EffectBigYolkLoseGameObject.SetActive(true);
            flag = true;
          }
          this.EffectBigYolkLoseTransform.localPosition = (Vector3) pos;
        }
        if (((int) effectflag & 4) == 0)
        {
          if (this.EffectYolkShieldGameObject.activeSelf)
            this.EffectYolkShieldGameObject.SetActive(false);
          if (this.EffectBigYolkShieldGameObject.activeSelf)
            this.EffectBigYolkShieldGameObject.SetActive(false);
        }
        else if (effecttype == (byte) 1)
        {
          if (this.EffectBigYolkShieldGameObject.activeSelf)
            this.EffectBigYolkShieldGameObject.SetActive(false);
          if (!this.EffectYolkShieldGameObject.activeSelf)
          {
            this.EffectYolkShieldParticle.startSize = this.YolkShieldstartSize * x;
            this.EffectYolkShieldParticle_one.startSize = this.YolkShieldstartSize_one * x;
            this.EffectYolkShieldParticle_two.startSize = this.YolkShieldstartSize_two * x * this.YolkShieldScale;
            this.EffectYolkShieldParticle_thr.startSize = this.YolkShieldstartSize_thr * x * this.YolkShieldScale;
            this.EffectYolkShieldParticle.startLifetime = this.YolkShieldlifetime * x;
            this.EffectYolkShieldParticle_one.startLifetime = this.YolkShieldlifetime_one * x;
            this.EffectYolkShieldGameObject.SetActive(true);
            flag = true;
          }
          this.EffectYolkShieldTransform.localPosition = (Vector3) pos;
        }
        else
        {
          if (this.EffectYolkShieldGameObject.activeSelf)
            this.EffectYolkShieldGameObject.SetActive(false);
          if (!this.EffectBigYolkShieldGameObject.activeSelf)
          {
            this.EffectBigYolkShieldParticle.startSize = this.BigYolkShieldstartSize * x;
            this.EffectBigYolkShieldParticle_one.startSize = this.BigYolkShieldstartSize_one * x;
            this.EffectBigYolkShieldParticle_two.startSize = this.BigYolkShieldstartSize_two * x * this.YolkShieldScale;
            this.EffectBigYolkShieldParticle_thr.startSize = this.BigYolkShieldstartSize_thr * x * this.YolkShieldScale;
            this.EffectBigYolkShieldParticle.startLifetime = this.BigYolkShieldlifetime * x;
            this.EffectBigYolkShieldParticle_one.startLifetime = this.BigYolkShieldlifetime_one * x;
            this.EffectBigYolkShieldGameObject.SetActive(true);
            flag = true;
          }
          this.EffectBigYolkShieldTransform.localPosition = (Vector3) pos;
        }
        if (flag)
          this.setEffect(row, col, DataManager.MapDataController.zoomSize);
      }
      effectflag = (byte) 0;
    }
    else if (row == this.Yolkrow && col == this.Yolkcol)
    {
      this.Yolkrow = this.Yolkcol = -1;
      if (this.EffectYolkWinGameObject.activeSelf)
        this.EffectYolkWinGameObject.SetActive(false);
      if (this.EffectYolkLoseGameObject.activeSelf)
        this.EffectYolkLoseGameObject.SetActive(false);
      if (this.EffectYolkShieldGameObject.activeSelf)
        this.EffectYolkShieldGameObject.SetActive(false);
      if (this.EffectBigYolkWinGameObject.activeSelf)
        this.EffectBigYolkWinGameObject.SetActive(false);
      if (this.EffectBigYolkLoseGameObject.activeSelf)
        this.EffectBigYolkLoseGameObject.SetActive(false);
      if (this.EffectBigYolkShieldGameObject.activeSelf)
        this.EffectBigYolkShieldGameObject.SetActive(false);
    }
    if (((int) effectflag & 1) == 0)
    {
      if ((UnityEngine.Object) this.EffectWinGameObject[col][row] != (UnityEngine.Object) null)
      {
        this.EffectWinGameObject[col][row].SetActive(false);
        for (int index = 0; index < this.WinpoolsCounter; ++index)
        {
          if (this.WinpoolCounter[index] < this.EffectWinGameObjectPools[index].Length)
          {
            this.EffectWinGameObjectPools[index][this.WinpoolCounter[index]] = this.EffectWinGameObject[col][row];
            this.EffectWinTransformPools[index][this.WinpoolCounter[index]] = this.EffectWinTransform[col][row];
            this.EffectWinParticlePools[index][this.WinpoolCounter[index]] = this.EffectWinParticle[col][row];
            this.EffectWinGameObject[col][row] = (GameObject) null;
            this.EffectWinTransform[col][row] = (Transform) null;
            this.EffectWinParticle[col][row] = (ParticleSystem) null;
            ++this.WinpoolCounter[index];
            break;
          }
        }
      }
    }
    else
    {
      if ((UnityEngine.Object) this.EffectWinGameObject[col][row] == (UnityEngine.Object) null)
      {
        int index1;
        for (index1 = 0; index1 < this.WinpoolsCounter; ++index1)
        {
          if (this.WinpoolCounter[index1] > 0)
          {
            --this.WinpoolCounter[index1];
            this.EffectWinGameObject[col][row] = this.EffectWinGameObjectPools[index1][this.WinpoolCounter[index1]];
            this.EffectWinTransform[col][row] = this.EffectWinTransformPools[index1][this.WinpoolCounter[index1]];
            this.EffectWinParticle[col][row] = this.EffectWinParticlePools[index1][this.WinpoolCounter[index1]];
            this.EffectWinGameObjectPools[index1][this.WinpoolCounter[index1]] = (GameObject) null;
            this.EffectWinTransformPools[index1][this.WinpoolCounter[index1]] = (Transform) null;
            this.EffectWinParticlePools[index1][this.WinpoolCounter[index1]] = (ParticleSystem) null;
            this.setEffect(row, col, DataManager.MapDataController.zoomSize);
            break;
          }
        }
        if (index1 == this.WinpoolsCounter)
        {
          this.EffectWinGameObjectPools[index1] = new GameObject[this.EffectWinGameObjectPools[0].Length];
          this.EffectWinTransformPools[index1] = new Transform[this.EffectWinTransformPools[0].Length];
          this.EffectWinParticlePools[index1] = new ParticleSystem[this.EffectWinParticlePools[0].Length];
          if (this.bBack == (byte) 1)
          {
            for (int index2 = 0; index2 < this.EffectWinGameObjectPools[index1].Length; ++index2)
            {
              this.EffectWinGameObjectPools[index1][index2] = ParticleManager.Instance.Spawn((ushort) 198, (Transform) null, Vector3.zero, 1f, false, false);
              this.EffectWinTransformPools[index1][index2] = this.EffectWinGameObjectPools[index1][index2].transform;
              this.EffectWinTransformPools[index1][index2].SetParent(this.WinLayoutTransform, false);
              this.EffectWinTransformPools[index1][index2].localPosition = this.inipos;
              this.EffectWinParticlePools[index1][index2] = this.EffectWinTransformPools[index1][index2].GetChild(0).GetComponent<ParticleSystem>();
            }
          }
          else
          {
            for (int index3 = 0; index3 < this.EffectWinGameObjectPools[index1].Length; ++index3)
            {
              this.EffectWinGameObjectPools[index1][index3] = ParticleManager.Instance.Spawn((ushort) 60102, (Transform) null, Vector3.zero, 1f, false, false);
              if ((UnityEngine.Object) this.EffectWinGameObjectPools[index1][index3] == (UnityEngine.Object) null)
                this.EffectWinGameObjectPools[index1][index3] = ParticleManager.Instance.Spawn((ushort) 198, (Transform) null, Vector3.zero, 1f, false, false);
              this.EffectWinTransformPools[index1][index3] = this.EffectWinGameObjectPools[index1][index3].transform;
              this.EffectWinTransformPools[index1][index3].SetParent(this.WinLayoutTransform, false);
              this.EffectWinTransformPools[index1][index3].localPosition = this.inipos;
              this.EffectWinParticlePools[index1][index3] = this.EffectWinTransformPools[index1][index3].GetChild(0).GetComponent<ParticleSystem>();
            }
          }
          ++this.WinpoolsCounter;
          this.WinpoolCounter[index1] = this.EffectWinGameObjectPools[index1].Length;
          --this.WinpoolCounter[index1];
          this.EffectWinGameObject[col][row] = this.EffectWinGameObjectPools[index1][this.WinpoolCounter[index1]];
          this.EffectWinTransform[col][row] = this.EffectWinTransformPools[index1][this.WinpoolCounter[index1]];
          this.EffectWinParticle[col][row] = this.EffectWinParticlePools[index1][this.WinpoolCounter[index1]];
          this.EffectWinParticle[col][row].startSize = this.WinstartSize * x;
          this.EffectWinParticle[col][row].startLifetime = this.Winlifetime * x;
          this.EffectWinGameObjectPools[index1][this.WinpoolCounter[index1]] = (GameObject) null;
          this.EffectWinTransformPools[index1][this.WinpoolCounter[index1]] = (Transform) null;
          this.EffectWinParticlePools[index1][this.WinpoolCounter[index1]] = (ParticleSystem) null;
        }
        this.EffectWinGameObject[col][row].SetActive(true);
      }
      this.EffectWinTransform[col][row].localPosition = (Vector3) pos;
    }
    if (((int) effectflag & 2) == 0)
    {
      if ((UnityEngine.Object) this.EffectLoseGameObject[col][row] != (UnityEngine.Object) null)
      {
        this.EffectLoseGameObject[col][row].SetActive(false);
        for (int index = 0; index < this.LosepoolsCounter; ++index)
        {
          if (this.LosepoolCounter[index] < this.EffectLoseGameObjectPools[index].Length)
          {
            this.EffectLoseGameObjectPools[index][this.LosepoolCounter[index]] = this.EffectLoseGameObject[col][row];
            this.EffectLoseTransformPools[index][this.LosepoolCounter[index]] = this.EffectLoseTransform[col][row];
            this.EffectLoseParticlePools[index][this.LosepoolCounter[index]] = this.EffectLoseParticle[col][row];
            this.EffectLoseGameObject[col][row] = (GameObject) null;
            this.EffectLoseTransform[col][row] = (Transform) null;
            this.EffectLoseParticle[col][row] = (ParticleSystem) null;
            ++this.LosepoolCounter[index];
            break;
          }
        }
      }
      if ((UnityEngine.Object) this.EffectEnemyLoseGameObject[col][row] != (UnityEngine.Object) null)
      {
        this.EffectEnemyLoseGameObject[col][row].SetActive(false);
        for (int index = 0; index < this.EnemyLosepoolsCounter; ++index)
        {
          if (this.EnemyLosepoolCounter[index] < this.EffectEnemyLoseGameObjectPools[index].Length)
          {
            this.EffectEnemyLoseGameObjectPools[index][this.EnemyLosepoolCounter[index]] = this.EffectEnemyLoseGameObject[col][row];
            this.EffectEnemyLoseTransformPools[index][this.EnemyLosepoolCounter[index]] = this.EffectEnemyLoseTransform[col][row];
            this.EffectEnemyLoseParticlePools[index][this.EnemyLosepoolCounter[index]] = this.EffectEnemyLoseParticle[col][row];
            this.EffectEnemyLoseGameObject[col][row] = (GameObject) null;
            this.EffectEnemyLoseTransform[col][row] = (Transform) null;
            this.EffectEnemyLoseParticle[col][row] = (ParticleSystem) null;
            ++this.EnemyLosepoolCounter[index];
            break;
          }
        }
      }
    }
    else if (((int) effectflag & 64) == 0)
    {
      if ((UnityEngine.Object) this.EffectEnemyLoseGameObject[col][row] != (UnityEngine.Object) null)
      {
        this.EffectEnemyLoseGameObject[col][row].SetActive(false);
        for (int index = 0; index < this.EnemyLosepoolsCounter; ++index)
        {
          if (this.EnemyLosepoolCounter[index] < this.EffectEnemyLoseGameObjectPools[index].Length)
          {
            this.EffectEnemyLoseGameObjectPools[index][this.EnemyLosepoolCounter[index]] = this.EffectEnemyLoseGameObject[col][row];
            this.EffectEnemyLoseTransformPools[index][this.EnemyLosepoolCounter[index]] = this.EffectEnemyLoseTransform[col][row];
            this.EffectEnemyLoseParticlePools[index][this.EnemyLosepoolCounter[index]] = this.EffectEnemyLoseParticle[col][row];
            this.EffectEnemyLoseGameObject[col][row] = (GameObject) null;
            this.EffectEnemyLoseTransform[col][row] = (Transform) null;
            this.EffectEnemyLoseParticle[col][row] = (ParticleSystem) null;
            ++this.EnemyLosepoolCounter[index];
            break;
          }
        }
      }
      if ((UnityEngine.Object) this.EffectLoseGameObject[col][row] == (UnityEngine.Object) null)
      {
        int index4;
        for (index4 = 0; index4 < this.LosepoolsCounter; ++index4)
        {
          if (this.LosepoolCounter[index4] > 0)
          {
            --this.LosepoolCounter[index4];
            this.EffectLoseGameObject[col][row] = this.EffectLoseGameObjectPools[index4][this.LosepoolCounter[index4]];
            this.EffectLoseTransform[col][row] = this.EffectLoseTransformPools[index4][this.LosepoolCounter[index4]];
            this.EffectLoseParticle[col][row] = this.EffectLoseParticlePools[index4][this.LosepoolCounter[index4]];
            this.EffectLoseGameObjectPools[index4][this.LosepoolCounter[index4]] = (GameObject) null;
            this.EffectLoseTransformPools[index4][this.LosepoolCounter[index4]] = (Transform) null;
            this.EffectLoseParticlePools[index4][this.LosepoolCounter[index4]] = (ParticleSystem) null;
            this.setEffect(row, col, DataManager.MapDataController.zoomSize);
            break;
          }
        }
        if (index4 == this.LosepoolsCounter)
        {
          this.EffectLoseGameObjectPools[index4] = new GameObject[this.EffectLoseGameObjectPools[0].Length];
          this.EffectLoseTransformPools[index4] = new Transform[this.EffectLoseTransformPools[0].Length];
          this.EffectLoseParticlePools[index4] = new ParticleSystem[this.EffectLoseParticlePools[0].Length];
          if (this.bBack == (byte) 1)
          {
            for (int index5 = 0; index5 < this.EffectLoseGameObjectPools[index4].Length; ++index5)
            {
              this.EffectLoseGameObjectPools[index4][index5] = ParticleManager.Instance.Spawn((ushort) 197, (Transform) null, Vector3.zero, 1f, false, false);
              this.EffectLoseTransformPools[index4][index5] = this.EffectLoseGameObjectPools[index4][index5].transform;
              this.EffectLoseTransformPools[index4][index5].SetParent(this.LoseLayoutTransform, false);
              this.EffectLoseTransformPools[index4][index5].localPosition = this.inipos;
              this.EffectLoseParticlePools[index4][index5] = this.EffectLoseTransformPools[index4][index5].GetChild(0).GetComponent<ParticleSystem>();
            }
          }
          else
          {
            for (int index6 = 0; index6 < this.EffectLoseGameObjectPools[index4].Length; ++index6)
            {
              this.EffectLoseGameObjectPools[index4][index6] = ParticleManager.Instance.Spawn((ushort) 60101, (Transform) null, Vector3.zero, 1f, false, false);
              if ((UnityEngine.Object) this.EffectLoseGameObjectPools[index4][index6] == (UnityEngine.Object) null)
                this.EffectLoseGameObjectPools[index4][index6] = ParticleManager.Instance.Spawn((ushort) 197, (Transform) null, Vector3.zero, 1f, false, false);
              this.EffectLoseTransformPools[index4][index6] = this.EffectLoseGameObjectPools[index4][index6].transform;
              this.EffectLoseTransformPools[index4][index6].SetParent(this.LoseLayoutTransform, false);
              this.EffectLoseTransformPools[index4][index6].localPosition = this.inipos;
              this.EffectLoseParticlePools[index4][index6] = this.EffectLoseTransformPools[index4][index6].GetChild(0).GetComponent<ParticleSystem>();
            }
          }
          ++this.LosepoolsCounter;
          this.LosepoolCounter[index4] = this.EffectLoseGameObjectPools[index4].Length;
          --this.LosepoolCounter[index4];
          this.EffectLoseGameObject[col][row] = this.EffectLoseGameObjectPools[index4][this.LosepoolCounter[index4]];
          this.EffectLoseTransform[col][row] = this.EffectLoseTransformPools[index4][this.LosepoolCounter[index4]];
          this.EffectLoseParticle[col][row] = this.EffectLoseParticlePools[index4][this.LosepoolCounter[index4]];
          this.EffectLoseParticle[col][row].startSize = this.LosestartSize * x;
          this.EffectLoseParticle[col][row].startLifetime = this.Loselifetime * x;
          this.EffectLoseGameObjectPools[index4][this.LosepoolCounter[index4]] = (GameObject) null;
          this.EffectLoseTransformPools[index4][this.LosepoolCounter[index4]] = (Transform) null;
          this.EffectLoseParticlePools[index4][this.LosepoolCounter[index4]] = (ParticleSystem) null;
        }
        this.EffectLoseGameObject[col][row].SetActive(true);
      }
      this.EffectLoseTransform[col][row].localPosition = (Vector3) pos;
    }
    else
    {
      if ((UnityEngine.Object) this.EffectLoseGameObject[col][row] != (UnityEngine.Object) null)
      {
        this.EffectLoseGameObject[col][row].SetActive(false);
        for (int index = 0; index < this.LosepoolsCounter; ++index)
        {
          if (this.LosepoolCounter[index] < this.EffectLoseGameObjectPools[index].Length)
          {
            this.EffectLoseGameObjectPools[index][this.LosepoolCounter[index]] = this.EffectLoseGameObject[col][row];
            this.EffectLoseTransformPools[index][this.LosepoolCounter[index]] = this.EffectLoseTransform[col][row];
            this.EffectLoseParticlePools[index][this.LosepoolCounter[index]] = this.EffectLoseParticle[col][row];
            this.EffectLoseGameObject[col][row] = (GameObject) null;
            this.EffectLoseTransform[col][row] = (Transform) null;
            this.EffectLoseParticle[col][row] = (ParticleSystem) null;
            ++this.LosepoolCounter[index];
            break;
          }
        }
      }
      if ((UnityEngine.Object) this.EffectEnemyLoseGameObject[col][row] == (UnityEngine.Object) null)
      {
        int index7;
        for (index7 = 0; index7 < this.EnemyLosepoolsCounter; ++index7)
        {
          if (this.EnemyLosepoolCounter[index7] > 0)
          {
            --this.EnemyLosepoolCounter[index7];
            this.EffectEnemyLoseGameObject[col][row] = this.EffectEnemyLoseGameObjectPools[index7][this.EnemyLosepoolCounter[index7]];
            this.EffectEnemyLoseTransform[col][row] = this.EffectEnemyLoseTransformPools[index7][this.EnemyLosepoolCounter[index7]];
            this.EffectEnemyLoseParticle[col][row] = this.EffectEnemyLoseParticlePools[index7][this.EnemyLosepoolCounter[index7]];
            this.EffectEnemyLoseGameObjectPools[index7][this.EnemyLosepoolCounter[index7]] = (GameObject) null;
            this.EffectEnemyLoseTransformPools[index7][this.EnemyLosepoolCounter[index7]] = (Transform) null;
            this.EffectEnemyLoseParticlePools[index7][this.EnemyLosepoolCounter[index7]] = (ParticleSystem) null;
            this.setEffect(row, col, DataManager.MapDataController.zoomSize);
            break;
          }
        }
        if (index7 == this.EnemyLosepoolsCounter)
        {
          this.EffectEnemyLoseGameObjectPools[index7] = new GameObject[this.EffectEnemyLoseGameObjectPools[0].Length];
          this.EffectEnemyLoseTransformPools[index7] = new Transform[this.EffectEnemyLoseTransformPools[0].Length];
          this.EffectEnemyLoseParticlePools[index7] = new ParticleSystem[this.EffectEnemyLoseParticlePools[0].Length];
          if (this.bBack == (byte) 1)
          {
            for (int index8 = 0; index8 < this.EffectEnemyLoseGameObjectPools[index7].Length; ++index8)
            {
              this.EffectEnemyLoseGameObjectPools[index7][index8] = ParticleManager.Instance.Spawn((ushort) 387, (Transform) null, Vector3.zero, 1f, false, false);
              this.EffectEnemyLoseTransformPools[index7][index8] = this.EffectEnemyLoseGameObjectPools[index7][index8].transform;
              this.EffectEnemyLoseTransformPools[index7][index8].SetParent(this.EnemyLoseLayoutTransform, false);
              this.EffectEnemyLoseTransformPools[index7][index8].localPosition = this.inipos;
              this.EffectEnemyLoseParticlePools[index7][index8] = this.EffectEnemyLoseTransformPools[index7][index8].GetChild(0).GetComponent<ParticleSystem>();
            }
          }
          else
          {
            for (int index9 = 0; index9 < this.EffectEnemyLoseGameObjectPools[index7].Length; ++index9)
            {
              this.EffectEnemyLoseGameObjectPools[index7][index9] = ParticleManager.Instance.Spawn((ushort) 60110, (Transform) null, Vector3.zero, 1f, false, false);
              if ((UnityEngine.Object) this.EffectEnemyLoseGameObjectPools[index7][index9] == (UnityEngine.Object) null)
                this.EffectEnemyLoseGameObjectPools[index7][index9] = ParticleManager.Instance.Spawn((ushort) 387, (Transform) null, Vector3.zero, 1f, false, false);
              this.EffectEnemyLoseTransformPools[index7][index9] = this.EffectEnemyLoseGameObjectPools[index7][index9].transform;
              this.EffectEnemyLoseTransformPools[index7][index9].SetParent(this.EnemyLoseLayoutTransform, false);
              this.EffectEnemyLoseTransformPools[index7][index9].localPosition = this.inipos;
              this.EffectEnemyLoseParticlePools[index7][index9] = this.EffectEnemyLoseTransformPools[index7][index9].GetChild(0).GetComponent<ParticleSystem>();
            }
          }
          ++this.EnemyLosepoolsCounter;
          this.EnemyLosepoolCounter[index7] = this.EffectEnemyLoseGameObjectPools[index7].Length;
          --this.EnemyLosepoolCounter[index7];
          this.EffectEnemyLoseGameObject[col][row] = this.EffectEnemyLoseGameObjectPools[index7][this.EnemyLosepoolCounter[index7]];
          this.EffectEnemyLoseTransform[col][row] = this.EffectEnemyLoseTransformPools[index7][this.EnemyLosepoolCounter[index7]];
          this.EffectEnemyLoseParticle[col][row] = this.EffectEnemyLoseParticlePools[index7][this.EnemyLosepoolCounter[index7]];
          this.EffectEnemyLoseParticle[col][row].startSize = this.EnemyLosestartSize * x;
          this.EffectEnemyLoseParticle[col][row].startLifetime = this.EnemyLoselifetime * x;
          this.EffectEnemyLoseGameObjectPools[index7][this.EnemyLosepoolCounter[index7]] = (GameObject) null;
          this.EffectEnemyLoseTransformPools[index7][this.EnemyLosepoolCounter[index7]] = (Transform) null;
          this.EffectEnemyLoseParticlePools[index7][this.EnemyLosepoolCounter[index7]] = (ParticleSystem) null;
        }
        this.EffectEnemyLoseGameObject[col][row].SetActive(true);
      }
      this.EffectEnemyLoseTransform[col][row].localPosition = (Vector3) pos;
    }
    if (((int) effectflag & 4) == 0)
    {
      if ((UnityEngine.Object) this.EffectShieldGameObject[col][row] != (UnityEngine.Object) null)
      {
        this.EffectShieldGameObject[col][row].SetActive(false);
        for (int index = 0; index < this.ShieldpoolsCounter; ++index)
        {
          if (this.ShieldpoolCounter[index] < this.EffectShieldGameObjectPools[index].Length)
          {
            this.EffectShieldGameObjectPools[index][this.ShieldpoolCounter[index]] = this.EffectShieldGameObject[col][row];
            this.EffectShieldTransformPools[index][this.ShieldpoolCounter[index]] = this.EffectShieldTransform[col][row];
            this.EffectShieldParticlePools[index][this.ShieldpoolCounter[index]] = this.EffectShieldParticle[col][row];
            this.EffectShieldParticlePools_one[index][this.ShieldpoolCounter[index]] = this.EffectShieldParticle_one[col][row];
            this.EffectShieldGameObject[col][row] = (GameObject) null;
            this.EffectShieldTransform[col][row] = (Transform) null;
            this.EffectShieldParticle[col][row] = (ParticleSystem) null;
            this.EffectShieldParticle_one[col][row] = (ParticleSystem) null;
            ++this.ShieldpoolCounter[index];
            break;
          }
        }
      }
    }
    else
    {
      if ((UnityEngine.Object) this.EffectShieldGameObject[col][row] == (UnityEngine.Object) null)
      {
        int index10;
        for (index10 = 0; index10 < this.ShieldpoolsCounter; ++index10)
        {
          if (this.ShieldpoolCounter[index10] > 0)
          {
            --this.ShieldpoolCounter[index10];
            this.EffectShieldGameObject[col][row] = this.EffectShieldGameObjectPools[index10][this.ShieldpoolCounter[index10]];
            this.EffectShieldTransform[col][row] = this.EffectShieldTransformPools[index10][this.ShieldpoolCounter[index10]];
            this.EffectShieldParticle[col][row] = this.EffectShieldParticlePools[index10][this.ShieldpoolCounter[index10]];
            this.EffectShieldParticle_one[col][row] = this.EffectShieldParticlePools_one[index10][this.ShieldpoolCounter[index10]];
            this.EffectShieldGameObjectPools[index10][this.ShieldpoolCounter[index10]] = (GameObject) null;
            this.EffectShieldTransformPools[index10][this.ShieldpoolCounter[index10]] = (Transform) null;
            this.EffectShieldParticlePools[index10][this.ShieldpoolCounter[index10]] = (ParticleSystem) null;
            this.EffectShieldParticlePools_one[index10][this.ShieldpoolCounter[index10]] = (ParticleSystem) null;
            this.setEffect(row, col, DataManager.MapDataController.zoomSize);
            break;
          }
        }
        if (index10 == this.ShieldpoolsCounter)
        {
          this.EffectShieldGameObjectPools[index10] = new GameObject[this.EffectShieldGameObjectPools[0].Length];
          this.EffectShieldTransformPools[index10] = new Transform[this.EffectShieldTransformPools[0].Length];
          this.EffectShieldParticlePools[index10] = new ParticleSystem[this.EffectShieldParticlePools[0].Length];
          this.EffectShieldParticlePools_one[index10] = new ParticleSystem[this.EffectShieldParticlePools_one[0].Length];
          if (this.bBack == (byte) 1)
          {
            for (int index11 = 0; index11 < this.EffectShieldGameObjectPools[index10].Length; ++index11)
            {
              this.EffectShieldGameObjectPools[index10][index11] = ParticleManager.Instance.Spawn((ushort) 199, (Transform) null, Vector3.zero, 1f, false, false);
              this.EffectShieldTransformPools[index10][index11] = this.EffectShieldGameObjectPools[index10][index11].transform;
              this.EffectShieldTransformPools[index10][index11].SetParent(this.ShieldLayoutTransform, false);
              this.EffectShieldTransformPools[index10][index11].localPosition = this.inipos;
              this.EffectShieldParticlePools[index10][index11] = this.EffectShieldTransformPools[index10][index11].GetChild(0).GetComponent<ParticleSystem>();
              this.EffectShieldParticlePools_one[index10][index11] = this.EffectShieldTransformPools[index10][index11].GetChild(1).GetComponent<ParticleSystem>();
            }
          }
          else
          {
            for (int index12 = 0; index12 < this.EffectShieldGameObjectPools[index10].Length; ++index12)
            {
              this.EffectShieldGameObjectPools[index10][index12] = ParticleManager.Instance.Spawn((ushort) 60103, (Transform) null, Vector3.zero, 1f, false, false);
              if ((UnityEngine.Object) this.EffectShieldGameObjectPools[index10][index12] == (UnityEngine.Object) null)
                this.EffectShieldGameObjectPools[index10][index12] = ParticleManager.Instance.Spawn((ushort) 199, (Transform) null, Vector3.zero, 1f, false, false);
              this.EffectShieldTransformPools[index10][index12] = this.EffectShieldGameObjectPools[index10][index12].transform;
              this.EffectShieldTransformPools[index10][index12].SetParent(this.ShieldLayoutTransform, false);
              this.EffectShieldTransformPools[index10][index12].localPosition = this.inipos;
              this.EffectShieldParticlePools[index10][index12] = this.EffectShieldTransformPools[index10][index12].GetChild(0).GetComponent<ParticleSystem>();
              this.EffectShieldParticlePools_one[index10][index12] = this.EffectShieldTransformPools[index10][index12].GetChild(1).GetComponent<ParticleSystem>();
            }
          }
          ++this.ShieldpoolsCounter;
          this.ShieldpoolCounter[index10] = this.EffectShieldGameObjectPools[index10].Length;
          --this.ShieldpoolCounter[index10];
          this.EffectShieldGameObject[col][row] = this.EffectShieldGameObjectPools[index10][this.ShieldpoolCounter[index10]];
          this.EffectShieldTransform[col][row] = this.EffectShieldTransformPools[index10][this.ShieldpoolCounter[index10]];
          this.EffectShieldParticle[col][row] = this.EffectShieldParticlePools[index10][this.ShieldpoolCounter[index10]];
          this.EffectShieldParticle_one[col][row] = this.EffectShieldParticlePools_one[index10][this.ShieldpoolCounter[index10]];
          ParticleSystem particleSystem = this.EffectShieldParticle[col][row];
          float num1 = this.ShieldstartSize * x;
          this.EffectShieldParticle_one[col][row].startSize = num1;
          double num2 = (double) num1;
          particleSystem.startSize = (float) num2;
          this.EffectShieldGameObjectPools[index10][this.ShieldpoolCounter[index10]] = (GameObject) null;
          this.EffectShieldTransformPools[index10][this.ShieldpoolCounter[index10]] = (Transform) null;
          this.EffectShieldParticlePools[index10][this.ShieldpoolCounter[index10]] = (ParticleSystem) null;
          this.EffectShieldParticlePools_one[index10][this.ShieldpoolCounter[index10]] = (ParticleSystem) null;
        }
        this.EffectShieldGameObject[col][row].SetActive(true);
      }
      this.EffectShieldTransform[col][row].localPosition = (Vector3) pos;
    }
    if (((int) effectflag & 16) == 0 || effecttype != (byte) 3 && effecttype != (byte) 4)
    {
      if ((UnityEngine.Object) this.EffectConveyGameObject[col][row] != (UnityEngine.Object) null)
      {
        this.EffectConveyGameObject[col][row].SetActive(false);
        for (int index = 0; index < this.ConveypoolsCounter; ++index)
        {
          if (this.ConveypoolCounter[index] < this.EffectConveyGameObjectPools[index].Length)
          {
            this.EffectConveyGameObjectPools[index][this.ConveypoolCounter[index]] = this.EffectConveyGameObject[col][row];
            this.EffectConveyTransformPools[index][this.ConveypoolCounter[index]] = this.EffectConveyTransform[col][row];
            this.EffectConveyParticlePools[index][this.ConveypoolCounter[index]] = this.EffectConveyParticle[col][row];
            this.EffectConveyParticlePools_one[index][this.ConveypoolCounter[index]] = this.EffectConveyParticle_one[col][row];
            this.EffectConveyParticlePools_two[index][this.ConveypoolCounter[index]] = this.EffectConveyParticle_two[col][row];
            this.EffectConveyParticlePools_thr[index][this.ConveypoolCounter[index]] = this.EffectConveyParticle_thr[col][row];
            this.EffectConveyGameObject[col][row] = (GameObject) null;
            this.EffectConveyTransform[col][row] = (Transform) null;
            this.EffectConveyParticle[col][row] = (ParticleSystem) null;
            this.EffectConveyParticle_one[col][row] = (ParticleSystem) null;
            this.EffectConveyParticle_two[col][row] = (ParticleSystem) null;
            this.EffectConveyParticle_thr[col][row] = (ParticleSystem) null;
            ++this.ConveypoolCounter[index];
            break;
          }
        }
      }
      if (!((UnityEngine.Object) this.EffectNPCCityConveyGameObject[col][row] != (UnityEngine.Object) null))
        return;
      this.EffectNPCCityConveyGameObject[col][row].SetActive(false);
      for (int index = 0; index < this.NPCCityConveypoolsCounter; ++index)
      {
        if (this.NPCCityConveypoolCounter[index] < this.EffectNPCCityConveyGameObjectPools[index].Length)
        {
          this.EffectNPCCityConveyGameObjectPools[index][this.NPCCityConveypoolCounter[index]] = this.EffectNPCCityConveyGameObject[col][row];
          this.EffectNPCCityConveyTransformPools[index][this.NPCCityConveypoolCounter[index]] = this.EffectNPCCityConveyTransform[col][row];
          this.EffectNPCCityConveyParticlePools[index][this.NPCCityConveypoolCounter[index]] = this.EffectNPCCityConveyParticle[col][row];
          this.EffectNPCCityConveyParticlePools_one[index][this.NPCCityConveypoolCounter[index]] = this.EffectNPCCityConveyParticle_one[col][row];
          this.EffectNPCCityConveyParticlePools_two[index][this.NPCCityConveypoolCounter[index]] = this.EffectNPCCityConveyParticle_two[col][row];
          this.EffectNPCCityConveyParticlePools_thr[index][this.NPCCityConveypoolCounter[index]] = this.EffectNPCCityConveyParticle_thr[col][row];
          this.EffectNPCCityConveyGameObject[col][row] = (GameObject) null;
          this.EffectNPCCityConveyTransform[col][row] = (Transform) null;
          this.EffectNPCCityConveyParticle[col][row] = (ParticleSystem) null;
          this.EffectNPCCityConveyParticle_one[col][row] = (ParticleSystem) null;
          this.EffectNPCCityConveyParticle_two[col][row] = (ParticleSystem) null;
          this.EffectNPCCityConveyParticle_thr[col][row] = (ParticleSystem) null;
          ++this.NPCCityConveypoolCounter[index];
          break;
        }
      }
    }
    else if (effecttype == (byte) 3)
    {
      if ((UnityEngine.Object) this.EffectNPCCityConveyGameObject[col][row] != (UnityEngine.Object) null)
      {
        this.EffectNPCCityConveyGameObject[col][row].SetActive(false);
        for (int index = 0; index < this.NPCCityConveypoolsCounter; ++index)
        {
          if (this.NPCCityConveypoolCounter[index] < this.EffectNPCCityConveyGameObjectPools[index].Length)
          {
            this.EffectNPCCityConveyGameObjectPools[index][this.NPCCityConveypoolCounter[index]] = this.EffectNPCCityConveyGameObject[col][row];
            this.EffectNPCCityConveyTransformPools[index][this.NPCCityConveypoolCounter[index]] = this.EffectNPCCityConveyTransform[col][row];
            this.EffectNPCCityConveyParticlePools[index][this.NPCCityConveypoolCounter[index]] = this.EffectNPCCityConveyParticle[col][row];
            this.EffectNPCCityConveyParticlePools_one[index][this.NPCCityConveypoolCounter[index]] = this.EffectNPCCityConveyParticle_one[col][row];
            this.EffectNPCCityConveyParticlePools_two[index][this.NPCCityConveypoolCounter[index]] = this.EffectNPCCityConveyParticle_two[col][row];
            this.EffectNPCCityConveyParticlePools_thr[index][this.NPCCityConveypoolCounter[index]] = this.EffectNPCCityConveyParticle_thr[col][row];
            this.EffectNPCCityConveyGameObject[col][row] = (GameObject) null;
            this.EffectNPCCityConveyTransform[col][row] = (Transform) null;
            this.EffectNPCCityConveyParticle[col][row] = (ParticleSystem) null;
            this.EffectNPCCityConveyParticle_one[col][row] = (ParticleSystem) null;
            this.EffectNPCCityConveyParticle_two[col][row] = (ParticleSystem) null;
            this.EffectNPCCityConveyParticle_thr[col][row] = (ParticleSystem) null;
            ++this.NPCCityConveypoolCounter[index];
            break;
          }
        }
      }
      if ((UnityEngine.Object) this.EffectConveyGameObject[col][row] == (UnityEngine.Object) null)
      {
        int index13;
        for (index13 = 0; index13 < this.ConveypoolsCounter; ++index13)
        {
          if (this.ConveypoolCounter[index13] > 0)
          {
            --this.ConveypoolCounter[index13];
            this.EffectConveyGameObject[col][row] = this.EffectConveyGameObjectPools[index13][this.ConveypoolCounter[index13]];
            this.EffectConveyTransform[col][row] = this.EffectConveyTransformPools[index13][this.ConveypoolCounter[index13]];
            this.EffectConveyParticle[col][row] = this.EffectConveyParticlePools[index13][this.ConveypoolCounter[index13]];
            this.EffectConveyParticle_one[col][row] = this.EffectConveyParticlePools_one[index13][this.ConveypoolCounter[index13]];
            this.EffectConveyParticle_two[col][row] = this.EffectConveyParticlePools_two[index13][this.ConveypoolCounter[index13]];
            this.EffectConveyParticle_thr[col][row] = this.EffectConveyParticlePools_thr[index13][this.ConveypoolCounter[index13]];
            this.EffectConveyGameObjectPools[index13][this.ConveypoolCounter[index13]] = (GameObject) null;
            this.EffectConveyTransformPools[index13][this.ConveypoolCounter[index13]] = (Transform) null;
            this.EffectConveyParticlePools[index13][this.ConveypoolCounter[index13]] = (ParticleSystem) null;
            this.EffectConveyParticlePools_one[index13][this.ConveypoolCounter[index13]] = (ParticleSystem) null;
            this.EffectConveyParticlePools_two[index13][this.ConveypoolCounter[index13]] = (ParticleSystem) null;
            this.EffectConveyParticlePools_thr[index13][this.ConveypoolCounter[index13]] = (ParticleSystem) null;
            this.setEffect(row, col, DataManager.MapDataController.zoomSize);
            break;
          }
        }
        if (index13 == this.ConveypoolsCounter)
        {
          this.EffectConveyGameObjectPools[index13] = new GameObject[this.EffectConveyGameObjectPools[0].Length];
          this.EffectConveyTransformPools[index13] = new Transform[this.EffectConveyTransformPools[0].Length];
          this.EffectConveyParticlePools[index13] = new ParticleSystem[this.EffectConveyParticlePools[0].Length];
          this.EffectConveyParticlePools_one[index13] = new ParticleSystem[this.EffectConveyParticlePools_one[0].Length];
          this.EffectConveyParticlePools_two[index13] = new ParticleSystem[this.EffectConveyParticlePools_two[0].Length];
          this.EffectConveyParticlePools_thr[index13] = new ParticleSystem[this.EffectConveyParticlePools_thr[0].Length];
          if (this.bBack == (byte) 1)
          {
            for (int index14 = 0; index14 < this.EffectConveyGameObjectPools[index13].Length; ++index14)
            {
              this.EffectConveyGameObjectPools[index13][index14] = ParticleManager.Instance.Spawn((ushort) 332, (Transform) null, Vector3.zero, 1f, false, false, false);
              this.EffectConveyTransformPools[index13][index14] = this.EffectConveyGameObjectPools[index13][index14].transform;
              this.EffectConveyTransformPools[index13][index14].SetParent(this.ConveyLayoutTransform, false);
              this.EffectConveyTransformPools[index13][index14].localPosition = this.inipos;
              this.EffectConveyParticlePools[index13][index14] = this.EffectConveyTransformPools[index13][index14].GetChild(0).GetComponent<ParticleSystem>();
              this.EffectConveyParticlePools_one[index13][index14] = this.EffectConveyTransformPools[index13][index14].GetChild(1).GetComponent<ParticleSystem>();
              this.EffectConveyParticlePools_two[index13][index14] = this.EffectConveyTransformPools[index13][index14].GetChild(2).GetComponent<ParticleSystem>();
              this.EffectConveyParticlePools_thr[index13][index14] = this.EffectConveyTransformPools[index13][index14].GetChild(3).GetComponent<ParticleSystem>();
            }
          }
          else
          {
            for (int index15 = 0; index15 < this.EffectConveyGameObjectPools[index13].Length; ++index15)
            {
              this.EffectConveyGameObjectPools[index13][index15] = ParticleManager.Instance.Spawn((ushort) 60111, (Transform) null, Vector3.zero, 1f, false, false, false);
              if ((UnityEngine.Object) this.EffectConveyGameObjectPools[index13][index15] == (UnityEngine.Object) null)
                ParticleManager.Instance.Spawn((ushort) 332, (Transform) null, Vector3.zero, 1f, false, false, false);
              this.EffectConveyTransformPools[index13][index15] = this.EffectConveyGameObjectPools[index13][index15].transform;
              this.EffectConveyTransformPools[index13][index15].SetParent(this.ConveyLayoutTransform, false);
              this.EffectConveyTransformPools[index13][index15].localPosition = this.inipos;
              this.EffectConveyParticlePools[index13][index15] = this.EffectConveyTransformPools[index13][index15].GetChild(0).GetComponent<ParticleSystem>();
              this.EffectConveyParticlePools_one[index13][index15] = this.EffectConveyTransformPools[index13][index15].GetChild(1).GetComponent<ParticleSystem>();
              this.EffectConveyParticlePools_two[index13][index15] = this.EffectConveyTransformPools[index13][index15].GetChild(2).GetComponent<ParticleSystem>();
              this.EffectConveyParticlePools_thr[index13][index15] = this.EffectConveyTransformPools[index13][index15].GetChild(3).GetComponent<ParticleSystem>();
            }
          }
          ++this.ConveypoolsCounter;
          this.ConveypoolCounter[index13] = this.EffectConveyGameObjectPools[index13].Length;
          --this.ConveypoolCounter[index13];
          this.EffectConveyGameObject[col][row] = this.EffectConveyGameObjectPools[index13][this.ConveypoolCounter[index13]];
          this.EffectConveyTransform[col][row] = this.EffectConveyTransformPools[index13][this.ConveypoolCounter[index13]];
          this.EffectConveyParticle[col][row] = this.EffectConveyParticlePools[index13][this.ConveypoolCounter[index13]];
          this.EffectConveyParticle_one[col][row] = this.EffectConveyParticlePools_one[index13][this.ConveypoolCounter[index13]];
          this.EffectConveyParticle_two[col][row] = this.EffectConveyParticlePools_two[index13][this.ConveypoolCounter[index13]];
          this.EffectConveyParticle_thr[col][row] = this.EffectConveyParticlePools_thr[index13][this.ConveypoolCounter[index13]];
          this.EffectConveyParticle[col][row].startSize = this.ConveystartSize * x;
          this.EffectConveyParticle_one[col][row].startSize = this.ConveystartSize_one * x;
          this.EffectConveyParticle_two[col][row].startSize = this.ConveystartSize_two * x;
          this.EffectConveyParticle_thr[col][row].startSize = this.ConveystartSize_thr * x;
          this.EffectConveyParticle[col][row].startLifetime = this.Conveylifetime * x;
          this.EffectConveyParticle_one[col][row].startLifetime = this.Conveylifetime_one * x;
          this.EffectConveyParticle_two[col][row].startLifetime = this.Conveylifetime_two * x;
          this.EffectConveyParticle_thr[col][row].startLifetime = this.Conveylifetime_thr * x;
          this.EffectConveyGameObjectPools[index13][this.ConveypoolCounter[index13]] = (GameObject) null;
          this.EffectConveyTransformPools[index13][this.ConveypoolCounter[index13]] = (Transform) null;
          this.EffectConveyParticlePools[index13][this.ConveypoolCounter[index13]] = (ParticleSystem) null;
          this.EffectConveyParticlePools_one[index13][this.ConveypoolCounter[index13]] = (ParticleSystem) null;
          this.EffectConveyParticlePools_two[index13][this.ConveypoolCounter[index13]] = (ParticleSystem) null;
          this.EffectConveyParticlePools_thr[index13][this.ConveypoolCounter[index13]] = (ParticleSystem) null;
        }
        this.EffectConveyGameObject[col][row].SetActive(true);
      }
      this.EffectConveyTransform[col][row].localPosition = (Vector3) pos;
    }
    else
    {
      if ((UnityEngine.Object) this.EffectConveyGameObject[col][row] != (UnityEngine.Object) null)
      {
        this.EffectConveyGameObject[col][row].SetActive(false);
        for (int index = 0; index < this.ConveypoolsCounter; ++index)
        {
          if (this.ConveypoolCounter[index] < this.EffectConveyGameObjectPools[index].Length)
          {
            this.EffectConveyGameObjectPools[index][this.ConveypoolCounter[index]] = this.EffectConveyGameObject[col][row];
            this.EffectConveyTransformPools[index][this.ConveypoolCounter[index]] = this.EffectConveyTransform[col][row];
            this.EffectConveyParticlePools[index][this.ConveypoolCounter[index]] = this.EffectConveyParticle[col][row];
            this.EffectConveyParticlePools_one[index][this.ConveypoolCounter[index]] = this.EffectConveyParticle_one[col][row];
            this.EffectConveyParticlePools_two[index][this.ConveypoolCounter[index]] = this.EffectConveyParticle_two[col][row];
            this.EffectConveyParticlePools_thr[index][this.ConveypoolCounter[index]] = this.EffectConveyParticle_thr[col][row];
            this.EffectConveyGameObject[col][row] = (GameObject) null;
            this.EffectConveyTransform[col][row] = (Transform) null;
            this.EffectConveyParticle[col][row] = (ParticleSystem) null;
            this.EffectConveyParticle_one[col][row] = (ParticleSystem) null;
            this.EffectConveyParticle_two[col][row] = (ParticleSystem) null;
            this.EffectConveyParticle_thr[col][row] = (ParticleSystem) null;
            ++this.ConveypoolCounter[index];
            break;
          }
        }
      }
      if ((UnityEngine.Object) this.EffectNPCCityConveyGameObject[col][row] == (UnityEngine.Object) null)
      {
        int index16;
        for (index16 = 0; index16 < this.NPCCityConveypoolsCounter; ++index16)
        {
          if (this.NPCCityConveypoolCounter[index16] > 0)
          {
            --this.NPCCityConveypoolCounter[index16];
            this.EffectNPCCityConveyGameObject[col][row] = this.EffectNPCCityConveyGameObjectPools[index16][this.NPCCityConveypoolCounter[index16]];
            this.EffectNPCCityConveyTransform[col][row] = this.EffectNPCCityConveyTransformPools[index16][this.NPCCityConveypoolCounter[index16]];
            this.EffectNPCCityConveyParticle[col][row] = this.EffectNPCCityConveyParticlePools[index16][this.NPCCityConveypoolCounter[index16]];
            this.EffectNPCCityConveyParticle_one[col][row] = this.EffectNPCCityConveyParticlePools_one[index16][this.NPCCityConveypoolCounter[index16]];
            this.EffectNPCCityConveyParticle_two[col][row] = this.EffectNPCCityConveyParticlePools_two[index16][this.NPCCityConveypoolCounter[index16]];
            this.EffectNPCCityConveyParticle_thr[col][row] = this.EffectNPCCityConveyParticlePools_thr[index16][this.NPCCityConveypoolCounter[index16]];
            this.EffectNPCCityConveyGameObjectPools[index16][this.NPCCityConveypoolCounter[index16]] = (GameObject) null;
            this.EffectNPCCityConveyTransformPools[index16][this.NPCCityConveypoolCounter[index16]] = (Transform) null;
            this.EffectNPCCityConveyParticlePools[index16][this.NPCCityConveypoolCounter[index16]] = (ParticleSystem) null;
            this.EffectNPCCityConveyParticlePools_one[index16][this.NPCCityConveypoolCounter[index16]] = (ParticleSystem) null;
            this.EffectNPCCityConveyParticlePools_two[index16][this.NPCCityConveypoolCounter[index16]] = (ParticleSystem) null;
            this.EffectNPCCityConveyParticlePools_thr[index16][this.NPCCityConveypoolCounter[index16]] = (ParticleSystem) null;
            this.setEffect(row, col, DataManager.MapDataController.zoomSize);
            break;
          }
        }
        if (index16 == this.NPCCityConveypoolsCounter)
        {
          this.EffectNPCCityConveyGameObjectPools[index16] = new GameObject[this.EffectNPCCityConveyGameObjectPools[0].Length];
          this.EffectNPCCityConveyTransformPools[index16] = new Transform[this.EffectNPCCityConveyTransformPools[0].Length];
          this.EffectNPCCityConveyParticlePools[index16] = new ParticleSystem[this.EffectConveyParticlePools[0].Length];
          this.EffectNPCCityConveyParticlePools_one[index16] = new ParticleSystem[this.EffectNPCCityConveyParticlePools_one[0].Length];
          this.EffectNPCCityConveyParticlePools_two[index16] = new ParticleSystem[this.EffectNPCCityConveyParticlePools_two[0].Length];
          this.EffectNPCCityConveyParticlePools_thr[index16] = new ParticleSystem[this.EffectNPCCityConveyParticlePools_thr[0].Length];
          if (this.bBack == (byte) 1)
          {
            for (int index17 = 0; index17 < this.EffectNPCCityConveyGameObjectPools[index16].Length; ++index17)
            {
              this.EffectNPCCityConveyGameObjectPools[index16][index17] = ParticleManager.Instance.Spawn((ushort) 390, (Transform) null, Vector3.zero, 1f, false, false, false);
              this.EffectNPCCityConveyTransformPools[index16][index17] = this.EffectNPCCityConveyGameObjectPools[index16][index17].transform;
              this.EffectNPCCityConveyTransformPools[index16][index17].SetParent(this.NPCCityConveyLayoutTransform, false);
              this.EffectNPCCityConveyTransformPools[index16][index17].localPosition = this.inipos;
              this.EffectNPCCityConveyParticlePools[index16][index17] = this.EffectNPCCityConveyTransformPools[index16][index17].GetChild(0).GetComponent<ParticleSystem>();
              this.EffectNPCCityConveyParticlePools_one[index16][index17] = this.EffectNPCCityConveyTransformPools[index16][index17].GetChild(1).GetComponent<ParticleSystem>();
              this.EffectNPCCityConveyParticlePools_two[index16][index17] = this.EffectNPCCityConveyTransformPools[index16][index17].GetChild(2).GetComponent<ParticleSystem>();
              this.EffectNPCCityConveyParticlePools_thr[index16][index17] = this.EffectNPCCityConveyTransformPools[index16][index17].GetChild(3).GetComponent<ParticleSystem>();
            }
          }
          else
          {
            for (int index18 = 0; index18 < this.EffectNPCCityConveyGameObjectPools[index16].Length; ++index18)
            {
              this.EffectNPCCityConveyGameObjectPools[index16][index18] = ParticleManager.Instance.Spawn((ushort) 60112, (Transform) null, Vector3.zero, 1f, false, false, false);
              if ((UnityEngine.Object) this.EffectNPCCityConveyGameObjectPools[index16][index18] == (UnityEngine.Object) null)
                ParticleManager.Instance.Spawn((ushort) 390, (Transform) null, Vector3.zero, 1f, false, false, false);
              this.EffectNPCCityConveyTransformPools[index16][index18] = this.EffectNPCCityConveyGameObjectPools[index16][index18].transform;
              this.EffectNPCCityConveyTransformPools[index16][index18].SetParent(this.NPCCityConveyLayoutTransform, false);
              this.EffectNPCCityConveyTransformPools[index16][index18].localPosition = this.inipos;
              this.EffectNPCCityConveyParticlePools[index16][index18] = this.EffectNPCCityConveyTransformPools[index16][index18].GetChild(0).GetComponent<ParticleSystem>();
              this.EffectNPCCityConveyParticlePools_one[index16][index18] = this.EffectNPCCityConveyTransformPools[index16][index18].GetChild(1).GetComponent<ParticleSystem>();
              this.EffectNPCCityConveyParticlePools_two[index16][index18] = this.EffectNPCCityConveyTransformPools[index16][index18].GetChild(2).GetComponent<ParticleSystem>();
              this.EffectNPCCityConveyParticlePools_thr[index16][index18] = this.EffectNPCCityConveyTransformPools[index16][index18].GetChild(3).GetComponent<ParticleSystem>();
            }
          }
          ++this.NPCCityConveypoolsCounter;
          this.NPCCityConveypoolCounter[index16] = this.EffectNPCCityConveyGameObjectPools[index16].Length;
          --this.NPCCityConveypoolCounter[index16];
          this.EffectNPCCityConveyGameObject[col][row] = this.EffectNPCCityConveyGameObjectPools[index16][this.NPCCityConveypoolCounter[index16]];
          this.EffectNPCCityConveyTransform[col][row] = this.EffectNPCCityConveyTransformPools[index16][this.NPCCityConveypoolCounter[index16]];
          this.EffectNPCCityConveyParticle[col][row] = this.EffectNPCCityConveyParticlePools[index16][this.NPCCityConveypoolCounter[index16]];
          this.EffectNPCCityConveyParticle_one[col][row] = this.EffectNPCCityConveyParticlePools_one[index16][this.NPCCityConveypoolCounter[index16]];
          this.EffectNPCCityConveyParticle_two[col][row] = this.EffectNPCCityConveyParticlePools_two[index16][this.NPCCityConveypoolCounter[index16]];
          this.EffectNPCCityConveyParticle_thr[col][row] = this.EffectNPCCityConveyParticlePools_thr[index16][this.NPCCityConveypoolCounter[index16]];
          this.EffectNPCCityConveyParticle[col][row].startSize = this.NPCCityConveystartSize * x;
          this.EffectNPCCityConveyParticle_one[col][row].startSize = this.NPCCityConveystartSize_one * x;
          this.EffectNPCCityConveyParticle_two[col][row].startSize = this.NPCCityConveystartSize_two * x;
          this.EffectNPCCityConveyParticle_thr[col][row].startSize = this.NPCCityConveystartSize_thr * x;
          this.EffectNPCCityConveyParticle[col][row].startLifetime = this.NPCCityConveylifetime * x;
          this.EffectNPCCityConveyParticle_one[col][row].startLifetime = this.NPCCityConveylifetime_one * x;
          this.EffectNPCCityConveyParticle_two[col][row].startLifetime = this.NPCCityConveylifetime_two * x;
          this.EffectNPCCityConveyParticle_thr[col][row].startLifetime = this.NPCCityConveylifetime_thr * x;
          this.EffectNPCCityConveyGameObjectPools[index16][this.NPCCityConveypoolCounter[index16]] = (GameObject) null;
          this.EffectNPCCityConveyTransformPools[index16][this.NPCCityConveypoolCounter[index16]] = (Transform) null;
          this.EffectNPCCityConveyParticlePools[index16][this.NPCCityConveypoolCounter[index16]] = (ParticleSystem) null;
          this.EffectNPCCityConveyParticlePools_one[index16][this.NPCCityConveypoolCounter[index16]] = (ParticleSystem) null;
          this.EffectNPCCityConveyParticlePools_two[index16][this.NPCCityConveypoolCounter[index16]] = (ParticleSystem) null;
          this.EffectNPCCityConveyParticlePools_thr[index16][this.NPCCityConveypoolCounter[index16]] = (ParticleSystem) null;
        }
        this.EffectNPCCityConveyGameObject[col][row].SetActive(true);
      }
      this.EffectNPCCityConveyTransform[col][row].localPosition = (Vector3) pos;
    }
  }

  public void setEffect(int row, int col, Vector2 pos)
  {
    Vector3 vector3 = new Vector3(pos.x, pos.y, 0.0f);
    if ((UnityEngine.Object) this.EffectWinGameObject[col][row] != (UnityEngine.Object) null)
      this.EffectWinTransform[col][row].localPosition = vector3;
    if ((UnityEngine.Object) this.EffectLoseGameObject[col][row] != (UnityEngine.Object) null)
      this.EffectLoseTransform[col][row].localPosition = vector3;
    if ((UnityEngine.Object) this.EffectEnemyLoseGameObject[col][row] != (UnityEngine.Object) null)
      this.EffectEnemyLoseTransform[col][row].localPosition = vector3;
    if ((UnityEngine.Object) this.EffectShieldGameObject[col][row] != (UnityEngine.Object) null)
      this.EffectShieldTransform[col][row].localPosition = vector3;
    if ((UnityEngine.Object) this.EffectConveyGameObject[col][row] != (UnityEngine.Object) null)
      this.EffectConveyTransform[col][row].localPosition = vector3;
    if ((UnityEngine.Object) this.EffectNPCCityConveyGameObject[col][row] != (UnityEngine.Object) null)
      this.EffectNPCCityConveyTransform[col][row].localPosition = vector3;
    if (this.Yolkrow != row || this.Yolkcol != col)
      return;
    if (this.EffectYolkWinGameObject.activeSelf)
      this.EffectYolkWinTransform.localPosition = vector3;
    if (this.EffectYolkLoseGameObject.activeSelf)
      this.EffectYolkLoseTransform.localPosition = vector3;
    if (this.EffectYolkShieldGameObject.activeSelf)
      this.EffectYolkShieldTransform.localPosition = vector3;
    if (this.EffectBigYolkWinGameObject.activeSelf)
      this.EffectBigYolkWinTransform.localPosition = vector3;
    if (this.EffectBigYolkLoseGameObject.activeSelf)
      this.EffectBigYolkLoseTransform.localPosition = vector3;
    if (!this.EffectBigYolkShieldGameObject.activeSelf)
      return;
    this.EffectBigYolkShieldTransform.localPosition = vector3;
  }

  public void setEffect(int row, int col, float scale)
  {
    float num1 = 0.0f;
    if ((UnityEngine.Object) this.EffectWinGameObject[col][row] != (UnityEngine.Object) null)
    {
      float startSize = this.EffectWinParticle[col][row].startSize;
      float startLifetime = this.EffectWinParticle[col][row].startLifetime;
      this.EffectWinParticle[col][row].startSize = this.WinstartSize * scale;
      this.EffectWinParticle[col][row].startLifetime = this.Winlifetime * scale;
      float num2 = this.EffectWinParticle[col][row].startSize / startSize;
      num1 = this.EffectWinParticle[col][row].startLifetime / startLifetime;
      int particles = this.EffectWinParticle[col][row].GetParticles(this.particles);
      for (int index = 0; index < particles; ++index)
      {
        this.particles[index].size *= num2;
        this.particles[index].lifetime *= num1;
      }
      this.EffectWinParticle[col][row].SetParticles(this.particles, particles);
    }
    if ((UnityEngine.Object) this.EffectLoseGameObject[col][row] != (UnityEngine.Object) null)
    {
      float startSize = this.EffectLoseParticle[col][row].startSize;
      float startLifetime = this.EffectLoseParticle[col][row].startLifetime;
      this.EffectLoseParticle[col][row].startSize = this.LosestartSize * scale;
      this.EffectLoseParticle[col][row].startLifetime = this.Loselifetime * scale;
      float num3 = this.EffectLoseParticle[col][row].startSize / startSize;
      num1 = this.EffectLoseParticle[col][row].startLifetime / startLifetime;
      int particles = this.EffectLoseParticle[col][row].GetParticles(this.particles);
      for (int index = 0; index < particles; ++index)
      {
        this.particles[index].size *= num3;
        this.particles[index].lifetime *= num1;
      }
      this.EffectLoseParticle[col][row].SetParticles(this.particles, particles);
    }
    if ((UnityEngine.Object) this.EffectEnemyLoseGameObject[col][row] != (UnityEngine.Object) null)
    {
      float startSize = this.EffectEnemyLoseParticle[col][row].startSize;
      float startLifetime = this.EffectEnemyLoseParticle[col][row].startLifetime;
      this.EffectEnemyLoseParticle[col][row].startSize = this.EnemyLosestartSize * scale;
      this.EffectEnemyLoseParticle[col][row].startLifetime = this.EnemyLoselifetime * scale;
      float num4 = this.EffectEnemyLoseParticle[col][row].startSize / startSize;
      num1 = this.EffectEnemyLoseParticle[col][row].startLifetime / startLifetime;
      int particles = this.EffectEnemyLoseParticle[col][row].GetParticles(this.particles);
      for (int index = 0; index < particles; ++index)
      {
        this.particles[index].size *= num4;
        this.particles[index].lifetime *= num1;
      }
      this.EffectEnemyLoseParticle[col][row].SetParticles(this.particles, particles);
    }
    if ((UnityEngine.Object) this.EffectShieldGameObject[col][row] != (UnityEngine.Object) null)
    {
      float startSize1 = this.EffectShieldParticle[col][row].startSize;
      this.EffectShieldParticle[col][row].startSize = this.ShieldstartSize * scale;
      float num5 = this.EffectShieldParticle[col][row].startSize / startSize1;
      float num6 = this.EffectShieldParticle[col][row].startLifetime / num1;
      int particles1 = this.EffectShieldParticle[col][row].GetParticles(this.particles);
      for (int index = 0; index < particles1; ++index)
        this.particles[index].size *= num5;
      this.EffectShieldParticle[col][row].SetParticles(this.particles, particles1);
      float startSize2 = this.EffectShieldParticle_one[col][row].startSize;
      this.EffectShieldParticle_one[col][row].startSize = this.ShieldstartSize * scale;
      float num7 = this.EffectShieldParticle_one[col][row].startSize / startSize2;
      float num8 = this.EffectShieldParticle_one[col][row].startLifetime / num6;
      int particles2 = this.EffectShieldParticle_one[col][row].GetParticles(this.particles);
      for (int index = 0; index < particles2; ++index)
        this.particles[index].size *= num7;
      this.EffectShieldParticle_one[col][row].SetParticles(this.particles, particles2);
    }
    if ((UnityEngine.Object) this.EffectConveyGameObject[col][row] != (UnityEngine.Object) null)
    {
      float startSize3 = this.EffectConveyParticle[col][row].startSize;
      float startLifetime = this.EffectConveyParticle[col][row].startLifetime;
      this.EffectConveyParticle[col][row].startSize = this.ConveystartSize * scale;
      this.EffectConveyParticle[col][row].startLifetime = this.Conveylifetime * scale;
      float num9 = this.EffectConveyParticle[col][row].startSize / startSize3;
      float num10 = this.EffectConveyParticle[col][row].startLifetime / startLifetime;
      int particles3 = this.EffectConveyParticle[col][row].GetParticles(this.particles);
      for (int index = 0; index < particles3; ++index)
      {
        this.particles[index].size *= num9;
        this.particles[index].lifetime *= num10;
      }
      this.EffectConveyParticle[col][row].SetParticles(this.particles, particles3);
      float startSize4 = this.EffectConveyParticle_one[col][row].startSize;
      this.EffectConveyParticle_one[col][row].startSize = this.ConveystartSize_one * scale;
      this.EffectConveyParticle_one[col][row].startLifetime = this.Conveylifetime_one * scale;
      float num11 = this.EffectConveyParticle_one[col][row].startSize / startSize4;
      float num12 = this.EffectConveyParticle_one[col][row].startLifetime / num10;
      int particles4 = this.EffectConveyParticle_one[col][row].GetParticles(this.particles);
      for (int index = 0; index < particles4; ++index)
      {
        this.particles[index].size *= num11;
        this.particles[index].lifetime *= num12;
      }
      this.EffectConveyParticle_one[col][row].SetParticles(this.particles, particles4);
      float startSize5 = this.EffectConveyParticle_two[col][row].startSize;
      this.EffectConveyParticle_two[col][row].startSize = this.ConveystartSize_two * scale;
      this.EffectConveyParticle_two[col][row].startLifetime = this.Conveylifetime_two * scale;
      float num13 = this.EffectConveyParticle_two[col][row].startSize / startSize5;
      float num14 = this.EffectConveyParticle_two[col][row].startLifetime / num12;
      int particles5 = this.EffectConveyParticle_two[col][row].GetParticles(this.particles);
      for (int index = 0; index < particles5; ++index)
      {
        this.particles[index].size *= num13;
        this.particles[index].lifetime *= num14;
      }
      this.EffectConveyParticle_two[col][row].SetParticles(this.particles, particles5);
      float startSize6 = this.EffectConveyParticle_thr[col][row].startSize;
      this.EffectConveyParticle_thr[col][row].startSize = this.ConveystartSize_thr * scale;
      this.EffectConveyParticle_thr[col][row].startLifetime = this.Conveylifetime_thr * scale;
      float num15 = this.EffectConveyParticle_thr[col][row].startSize / startSize6;
      float num16 = this.EffectConveyParticle_thr[col][row].startLifetime / num14;
      int particles6 = this.EffectConveyParticle_thr[col][row].GetParticles(this.particles);
      for (int index = 0; index < particles6; ++index)
      {
        this.particles[index].size *= num15;
        this.particles[index].lifetime *= num16;
      }
      this.EffectConveyParticle_thr[col][row].SetParticles(this.particles, particles6);
    }
    if ((UnityEngine.Object) this.EffectNPCCityConveyGameObject[col][row] != (UnityEngine.Object) null)
    {
      float startSize7 = this.EffectNPCCityConveyParticle[col][row].startSize;
      float startLifetime = this.EffectNPCCityConveyParticle[col][row].startLifetime;
      this.EffectNPCCityConveyParticle[col][row].startSize = this.NPCCityConveystartSize * scale;
      this.EffectNPCCityConveyParticle[col][row].startLifetime = this.NPCCityConveylifetime * scale;
      float num17 = this.EffectNPCCityConveyParticle[col][row].startSize / startSize7;
      float num18 = this.EffectNPCCityConveyParticle[col][row].startLifetime / startLifetime;
      int particles7 = this.EffectNPCCityConveyParticle[col][row].GetParticles(this.particles);
      for (int index = 0; index < particles7; ++index)
      {
        this.particles[index].size *= num17;
        this.particles[index].lifetime *= num18;
      }
      this.EffectNPCCityConveyParticle[col][row].SetParticles(this.particles, particles7);
      float startSize8 = this.EffectNPCCityConveyParticle_one[col][row].startSize;
      this.EffectNPCCityConveyParticle_one[col][row].startSize = this.NPCCityConveystartSize_one * scale;
      this.EffectNPCCityConveyParticle_one[col][row].startLifetime = this.NPCCityConveylifetime_one * scale;
      float num19 = this.EffectNPCCityConveyParticle_one[col][row].startSize / startSize8;
      float num20 = this.EffectNPCCityConveyParticle_one[col][row].startLifetime / num18;
      int particles8 = this.EffectNPCCityConveyParticle_one[col][row].GetParticles(this.particles);
      for (int index = 0; index < particles8; ++index)
      {
        this.particles[index].size *= num19;
        this.particles[index].lifetime *= num20;
      }
      this.EffectNPCCityConveyParticle_one[col][row].SetParticles(this.particles, particles8);
      float startSize9 = this.EffectNPCCityConveyParticle_two[col][row].startSize;
      this.EffectNPCCityConveyParticle_two[col][row].startSize = this.NPCCityConveystartSize_two * scale;
      this.EffectNPCCityConveyParticle_two[col][row].startLifetime = this.NPCCityConveylifetime_two * scale;
      float num21 = this.EffectNPCCityConveyParticle_two[col][row].startSize / startSize9;
      float num22 = this.EffectNPCCityConveyParticle_two[col][row].startLifetime / num20;
      int particles9 = this.EffectNPCCityConveyParticle_two[col][row].GetParticles(this.particles);
      for (int index = 0; index < particles9; ++index)
      {
        this.particles[index].size *= num21;
        this.particles[index].lifetime *= num22;
      }
      this.EffectNPCCityConveyParticle_two[col][row].SetParticles(this.particles, particles9);
      float startSize10 = this.EffectNPCCityConveyParticle_thr[col][row].startSize;
      this.EffectNPCCityConveyParticle_thr[col][row].startSize = this.NPCCityConveystartSize_thr * scale;
      this.EffectNPCCityConveyParticle_thr[col][row].startLifetime = this.NPCCityConveylifetime_thr * scale;
      float num23 = this.EffectNPCCityConveyParticle_thr[col][row].startSize / startSize10;
      float num24 = this.EffectNPCCityConveyParticle_thr[col][row].startLifetime / num22;
      int particles10 = this.EffectNPCCityConveyParticle_thr[col][row].GetParticles(this.particles);
      for (int index = 0; index < particles10; ++index)
      {
        this.particles[index].size *= num23;
        this.particles[index].lifetime *= num24;
      }
      this.EffectNPCCityConveyParticle_thr[col][row].SetParticles(this.particles, particles10);
    }
    if (row != this.Yolkrow || col != this.Yolkcol)
      return;
    if (this.EffectYolkWinGameObject.activeSelf)
    {
      float startSize11 = this.EffectYolkWinParticle.startSize;
      float startLifetime1 = this.EffectYolkWinParticle.startLifetime;
      this.EffectYolkWinParticle.startSize = this.YolkWinstartSize * scale;
      this.EffectYolkWinParticle.startLifetime = this.YolkWinlifetime * scale;
      float num25 = this.EffectYolkWinParticle.startSize / startSize11;
      float num26 = this.EffectYolkWinParticle.startLifetime / startLifetime1;
      int particles11 = this.EffectYolkWinParticle.GetParticles(this.particles);
      for (int index = 0; index < particles11; ++index)
      {
        this.particles[index].size *= num25;
        this.particles[index].lifetime *= num26;
      }
      this.EffectYolkWinParticle.SetParticles(this.particles, particles11);
      float startSize12 = this.EffectYolkWinParticle_one.startSize;
      float startLifetime2 = this.EffectYolkWinParticle_one.startLifetime;
      this.EffectYolkWinParticle_one.startSize = this.YolkWinstartSize_one * scale;
      this.EffectYolkWinParticle_one.startLifetime = this.YolkWinlifetime_one * scale;
      float num27 = this.EffectYolkWinParticle_one.startSize / startSize12;
      float num28 = this.EffectYolkWinParticle_one.startLifetime / startLifetime2;
      int particles12 = this.EffectYolkWinParticle_one.GetParticles(this.particles);
      for (int index = 0; index < particles12; ++index)
      {
        this.particles[index].size *= num27;
        this.particles[index].lifetime *= num28;
      }
      this.EffectYolkWinParticle_one.SetParticles(this.particles, particles12);
      float startSize13 = this.EffectYolkWinParticle_two.startSize;
      float startLifetime3 = this.EffectYolkWinParticle_two.startLifetime;
      this.EffectYolkWinParticle_two.startSize = this.YolkWinstartSize_two * scale;
      this.EffectYolkWinParticle_two.startLifetime = this.YolkWinlifetime_two * scale;
      float num29 = this.EffectYolkWinParticle_two.startSize / startSize13;
      float num30 = this.EffectYolkWinParticle_two.startLifetime / startLifetime3;
      int particles13 = this.EffectYolkWinParticle_two.GetParticles(this.particles);
      for (int index = 0; index < particles13; ++index)
      {
        this.particles[index].size *= num29;
        this.particles[index].lifetime *= num30;
      }
      this.EffectYolkWinParticle_two.SetParticles(this.particles, particles13);
      float startSize14 = this.EffectYolkWinParticle_thr.startSize;
      float startLifetime4 = this.EffectYolkWinParticle_thr.startLifetime;
      this.EffectYolkWinParticle_thr.startSize = this.YolkWinstartSize_thr * scale;
      this.EffectYolkWinParticle_thr.startLifetime = this.YolkWinlifetime_thr * scale;
      float num31 = this.EffectYolkWinParticle_thr.startSize / startSize14;
      float num32 = this.EffectYolkWinParticle_thr.startLifetime / startLifetime4;
      int particles14 = this.EffectYolkWinParticle_thr.GetParticles(this.particles);
      for (int index = 0; index < particles14; ++index)
      {
        this.particles[index].size *= num31;
        this.particles[index].lifetime *= num32;
      }
      this.EffectYolkWinParticle_thr.SetParticles(this.particles, particles14);
      float startSize15 = this.EffectYolkWinParticle_tho.startSize;
      float startLifetime5 = this.EffectYolkWinParticle_tho.startLifetime;
      this.EffectYolkWinParticle_tho.startSize = this.YolkWinstartSize_tho * scale;
      this.EffectYolkWinParticle_tho.startLifetime = this.YolkWinlifetime_tho * scale;
      float num33 = this.EffectYolkWinParticle_tho.startSize / startSize15;
      float num34 = this.EffectYolkWinParticle_tho.startLifetime / startLifetime5;
      int particles15 = this.EffectYolkWinParticle_tho.GetParticles(this.particles);
      for (int index = 0; index < particles15; ++index)
      {
        this.particles[index].size *= num33;
        this.particles[index].lifetime *= num34;
      }
      this.EffectYolkWinParticle_tho.SetParticles(this.particles, particles15);
    }
    if (this.EffectYolkLoseGameObject.activeSelf)
    {
      float startSize16 = this.EffectYolkLoseParticle.startSize;
      float startLifetime6 = this.EffectYolkLoseParticle.startLifetime;
      this.EffectYolkLoseParticle.startSize = this.YolkLosestartSize * scale;
      this.EffectYolkLoseParticle.startLifetime = this.YolkLoselifetime * scale;
      float num35 = this.EffectYolkLoseParticle.startSize / startSize16;
      float num36 = this.EffectYolkLoseParticle.startLifetime / startLifetime6;
      int particles16 = this.EffectYolkLoseParticle.GetParticles(this.particles);
      for (int index = 0; index < particles16; ++index)
      {
        this.particles[index].size *= num35;
        this.particles[index].lifetime *= num36;
      }
      this.EffectYolkLoseParticle.SetParticles(this.particles, particles16);
      float startSize17 = this.EffectYolkLoseParticle_one.startSize;
      float startLifetime7 = this.EffectYolkLoseParticle_one.startLifetime;
      this.EffectYolkLoseParticle_one.startSize = this.YolkLosestartSize_one * scale;
      this.EffectYolkLoseParticle_one.startLifetime = this.YolkLoselifetime_one * scale;
      float num37 = this.EffectYolkLoseParticle_one.startSize / startSize17;
      float num38 = this.EffectYolkLoseParticle_one.startLifetime / startLifetime7;
      int particles17 = this.EffectYolkLoseParticle_one.GetParticles(this.particles);
      for (int index = 0; index < particles17; ++index)
      {
        this.particles[index].size *= num37;
        this.particles[index].lifetime *= num38;
      }
      this.EffectYolkLoseParticle_one.SetParticles(this.particles, particles17);
    }
    if (this.EffectYolkShieldGameObject.activeSelf)
    {
      float startSize18 = this.EffectYolkShieldParticle.startSize;
      float startLifetime8 = this.EffectYolkShieldParticle.startLifetime;
      this.EffectYolkShieldParticle.startSize = this.YolkShieldstartSize * scale;
      this.EffectYolkShieldParticle.startLifetime = this.YolkShieldlifetime * scale;
      float num39 = this.EffectYolkShieldParticle.startSize / startSize18;
      float num40 = this.EffectYolkShieldParticle.startLifetime / startLifetime8;
      int particles18 = this.EffectYolkShieldParticle.GetParticles(this.particles);
      for (int index = 0; index < particles18; ++index)
      {
        this.particles[index].size *= num39;
        this.particles[index].lifetime *= num40;
      }
      this.EffectYolkShieldParticle.SetParticles(this.particles, particles18);
      float startSize19 = this.EffectYolkShieldParticle_one.startSize;
      float startLifetime9 = this.EffectYolkShieldParticle_one.startLifetime;
      this.EffectYolkShieldParticle_one.startSize = this.YolkShieldstartSize_one * scale;
      this.EffectYolkShieldParticle_one.startLifetime = this.YolkShieldlifetime_one * scale;
      float num41 = this.EffectYolkShieldParticle_one.startSize / startSize19;
      float num42 = this.EffectYolkShieldParticle_one.startLifetime / startLifetime9;
      int particles19 = this.EffectYolkShieldParticle_one.GetParticles(this.particles);
      for (int index = 0; index < particles19; ++index)
      {
        this.particles[index].size *= num41;
        this.particles[index].lifetime *= num42;
      }
      this.EffectYolkShieldParticle_one.SetParticles(this.particles, particles19);
      scale *= this.YolkShieldScale;
      float startSize20 = this.EffectYolkShieldParticle_two.startSize;
      this.EffectYolkShieldParticle_two.startSize = this.YolkShieldstartSize_two * scale;
      float num43 = this.EffectYolkShieldParticle_two.startSize / startSize20;
      int particles20 = this.EffectYolkShieldParticle_two.GetParticles(this.particles);
      for (int index = 0; index < particles20; ++index)
        this.particles[index].size *= num43;
      this.EffectYolkShieldParticle_two.SetParticles(this.particles, particles20);
      float startSize21 = this.EffectYolkShieldParticle_thr.startSize;
      this.EffectYolkShieldParticle_thr.startSize = this.YolkShieldstartSize_thr * scale;
      float num44 = this.EffectYolkShieldParticle_thr.startSize / startSize21;
      int particles21 = this.EffectYolkShieldParticle_thr.GetParticles(this.particles);
      for (int index = 0; index < particles21; ++index)
        this.particles[index].size *= num44;
      this.EffectYolkShieldParticle_thr.SetParticles(this.particles, particles21);
    }
    if (this.EffectBigYolkWinGameObject.activeSelf)
    {
      float startSize22 = this.EffectBigYolkWinParticle.startSize;
      float startLifetime10 = this.EffectBigYolkWinParticle.startLifetime;
      this.EffectBigYolkWinParticle.startSize = this.BigYolkWinstartSize * scale;
      this.EffectBigYolkWinParticle.startLifetime = this.BigYolkWinlifetime * scale;
      float num45 = this.EffectBigYolkWinParticle.startSize / startSize22;
      float num46 = this.EffectBigYolkWinParticle.startLifetime / startLifetime10;
      int particles22 = this.EffectBigYolkWinParticle.GetParticles(this.particles);
      for (int index = 0; index < particles22; ++index)
      {
        this.particles[index].size *= num45;
        this.particles[index].lifetime *= num46;
      }
      this.EffectBigYolkWinParticle.SetParticles(this.particles, particles22);
      float startSize23 = this.EffectBigYolkWinParticle_one.startSize;
      float startLifetime11 = this.EffectBigYolkWinParticle_one.startLifetime;
      this.EffectBigYolkWinParticle_one.startSize = this.BigYolkWinstartSize_one * scale;
      this.EffectBigYolkWinParticle_one.startLifetime = this.BigYolkWinlifetime_one * scale;
      float num47 = this.EffectBigYolkWinParticle_one.startSize / startSize23;
      float num48 = this.EffectBigYolkWinParticle_one.startLifetime / startLifetime11;
      int particles23 = this.EffectBigYolkWinParticle_one.GetParticles(this.particles);
      for (int index = 0; index < particles23; ++index)
      {
        this.particles[index].size *= num47;
        this.particles[index].lifetime *= num48;
      }
      this.EffectBigYolkWinParticle_one.SetParticles(this.particles, particles23);
      float startSize24 = this.EffectBigYolkWinParticle_two.startSize;
      float startLifetime12 = this.EffectBigYolkWinParticle_two.startLifetime;
      this.EffectBigYolkWinParticle_two.startSize = this.BigYolkWinstartSize_two * scale;
      this.EffectBigYolkWinParticle_two.startLifetime = this.BigYolkWinlifetime_two * scale;
      float num49 = this.EffectBigYolkWinParticle_two.startSize / startSize24;
      float num50 = this.EffectBigYolkWinParticle_two.startLifetime / startLifetime12;
      int particles24 = this.EffectBigYolkWinParticle_two.GetParticles(this.particles);
      for (int index = 0; index < particles24; ++index)
      {
        this.particles[index].size *= num49;
        this.particles[index].lifetime *= num50;
      }
      this.EffectBigYolkWinParticle_two.SetParticles(this.particles, particles24);
      float startSize25 = this.EffectBigYolkWinParticle_thr.startSize;
      float startLifetime13 = this.EffectBigYolkWinParticle_thr.startLifetime;
      this.EffectBigYolkWinParticle_thr.startSize = this.BigYolkWinstartSize_thr * scale;
      this.EffectBigYolkWinParticle_thr.startLifetime = this.BigYolkWinlifetime_thr * scale;
      float num51 = this.EffectBigYolkWinParticle_thr.startSize / startSize25;
      float num52 = this.EffectBigYolkWinParticle_thr.startLifetime / startLifetime13;
      int particles25 = this.EffectBigYolkWinParticle_thr.GetParticles(this.particles);
      for (int index = 0; index < particles25; ++index)
      {
        this.particles[index].size *= num51;
        this.particles[index].lifetime *= num52;
      }
      this.EffectBigYolkWinParticle_thr.SetParticles(this.particles, particles25);
      float startSize26 = this.EffectBigYolkWinParticle_for.startSize;
      float startLifetime14 = this.EffectBigYolkWinParticle_for.startLifetime;
      this.EffectBigYolkWinParticle_for.startSize = this.BigYolkWinstartSize_for * scale;
      this.EffectBigYolkWinParticle_for.startLifetime = this.BigYolkWinlifetime_for * scale;
      float num53 = this.EffectBigYolkWinParticle_for.startSize / startSize26;
      float num54 = this.EffectBigYolkWinParticle_for.startLifetime / startLifetime14;
      int particles26 = this.EffectBigYolkWinParticle_for.GetParticles(this.particles);
      for (int index = 0; index < particles26; ++index)
      {
        this.particles[index].size *= num53;
        this.particles[index].lifetime *= num54;
      }
      this.EffectBigYolkWinParticle_for.SetParticles(this.particles, particles26);
    }
    if (this.EffectBigYolkLoseGameObject.activeSelf)
    {
      float startSize27 = this.EffectBigYolkLoseParticle.startSize;
      float startLifetime15 = this.EffectBigYolkLoseParticle.startLifetime;
      this.EffectBigYolkLoseParticle.startSize = this.BigYolkLosestartSize * scale;
      this.EffectBigYolkLoseParticle.startLifetime = this.BigYolkLoselifetime * scale;
      float num55 = this.EffectBigYolkLoseParticle.startSize / startSize27;
      float num56 = this.EffectBigYolkLoseParticle.startLifetime / startLifetime15;
      int particles27 = this.EffectBigYolkLoseParticle.GetParticles(this.particles);
      for (int index = 0; index < particles27; ++index)
      {
        this.particles[index].size *= num55;
        this.particles[index].lifetime *= num56;
      }
      this.EffectBigYolkLoseParticle.SetParticles(this.particles, particles27);
      float startSize28 = this.EffectBigYolkLoseParticle_one.startSize;
      float startLifetime16 = this.EffectBigYolkLoseParticle_one.startLifetime;
      this.EffectBigYolkLoseParticle_one.startSize = this.BigYolkLosestartSize_one * scale;
      this.EffectBigYolkLoseParticle_one.startLifetime = this.BigYolkLoselifetime_one * scale;
      float num57 = this.EffectBigYolkLoseParticle_one.startSize / startSize28;
      float num58 = this.EffectBigYolkLoseParticle_one.startLifetime / startLifetime16;
      int particles28 = this.EffectBigYolkLoseParticle_one.GetParticles(this.particles);
      for (int index = 0; index < particles28; ++index)
      {
        this.particles[index].size *= num57;
        this.particles[index].lifetime *= num58;
      }
      this.EffectBigYolkLoseParticle_one.SetParticles(this.particles, particles28);
      float startSize29 = this.EffectBigYolkLoseParticle_one.startSize;
      float startLifetime17 = this.EffectBigYolkLoseParticle_one.startLifetime;
      this.EffectBigYolkLoseParticle_one.startSize = this.BigYolkLosestartSize_one * scale;
      this.EffectBigYolkLoseParticle_one.startLifetime = this.BigYolkLoselifetime_one * scale;
      float num59 = this.EffectBigYolkLoseParticle_one.startSize / startSize29;
      float num60 = this.EffectBigYolkLoseParticle_one.startLifetime / startLifetime17;
      int particles29 = this.EffectBigYolkLoseParticle_one.GetParticles(this.particles);
      for (int index = 0; index < particles29; ++index)
      {
        this.particles[index].size *= num59;
        this.particles[index].lifetime *= num60;
      }
      this.EffectBigYolkLoseParticle_one.SetParticles(this.particles, particles29);
      float startSize30 = this.EffectBigYolkLoseParticle_two.startSize;
      float startLifetime18 = this.EffectBigYolkLoseParticle_two.startLifetime;
      this.EffectBigYolkLoseParticle_two.startSize = this.BigYolkLosestartSize_two * scale;
      this.EffectBigYolkLoseParticle_two.startLifetime = this.BigYolkLoselifetime_two * scale;
      float num61 = this.EffectBigYolkLoseParticle_two.startSize / startSize30;
      float num62 = this.EffectBigYolkLoseParticle_two.startLifetime / startLifetime18;
      int particles30 = this.EffectBigYolkLoseParticle_two.GetParticles(this.particles);
      for (int index = 0; index < particles30; ++index)
      {
        this.particles[index].size *= num61;
        this.particles[index].lifetime *= num62;
      }
      this.EffectBigYolkLoseParticle_two.SetParticles(this.particles, particles30);
    }
    if (!this.EffectBigYolkShieldGameObject.activeSelf)
      return;
    float startSize31 = this.EffectBigYolkShieldParticle.startSize;
    float startLifetime19 = this.EffectBigYolkShieldParticle.startLifetime;
    this.EffectBigYolkShieldParticle.startSize = this.BigYolkShieldstartSize * scale;
    this.EffectBigYolkShieldParticle.startLifetime = this.BigYolkShieldlifetime * scale;
    float num63 = this.EffectBigYolkShieldParticle.startSize / startSize31;
    float num64 = this.EffectBigYolkShieldParticle.startLifetime / startLifetime19;
    int particles31 = this.EffectBigYolkShieldParticle.GetParticles(this.particles);
    for (int index = 0; index < particles31; ++index)
    {
      this.particles[index].size *= num63;
      this.particles[index].lifetime *= num64;
    }
    this.EffectBigYolkShieldParticle.SetParticles(this.particles, particles31);
    float startSize32 = this.EffectBigYolkShieldParticle_one.startSize;
    float startLifetime20 = this.EffectBigYolkShieldParticle_one.startLifetime;
    this.EffectBigYolkShieldParticle_one.startSize = this.BigYolkShieldstartSize_one * scale;
    this.EffectBigYolkShieldParticle_one.startLifetime = this.BigYolkShieldlifetime_one * scale;
    float num65 = this.EffectBigYolkShieldParticle_one.startSize / startSize32;
    float num66 = this.EffectBigYolkShieldParticle_one.startLifetime / startLifetime20;
    int particles32 = this.EffectBigYolkShieldParticle_one.GetParticles(this.particles);
    for (int index = 0; index < particles32; ++index)
    {
      this.particles[index].size *= num65;
      this.particles[index].lifetime *= num66;
    }
    this.EffectBigYolkShieldParticle_one.SetParticles(this.particles, particles32);
    scale *= this.YolkShieldScale;
    float startSize33 = this.EffectBigYolkShieldParticle_two.startSize;
    this.EffectBigYolkShieldParticle_two.startSize = this.BigYolkShieldstartSize_two * scale;
    float num67 = this.EffectBigYolkShieldParticle_two.startSize / startSize33;
    int particles33 = this.EffectBigYolkShieldParticle_two.GetParticles(this.particles);
    for (int index = 0; index < particles33; ++index)
      this.particles[index].size *= num67;
    this.EffectBigYolkShieldParticle_two.SetParticles(this.particles, particles33);
    float startSize34 = this.EffectBigYolkShieldParticle_thr.startSize;
    this.EffectBigYolkShieldParticle_thr.startSize = this.BigYolkShieldstartSize_thr * scale;
    float num68 = this.EffectBigYolkShieldParticle_thr.startSize / startSize34;
    int particles34 = this.EffectBigYolkShieldParticle_thr.GetParticles(this.particles);
    for (int index = 0; index < particles34; ++index)
      this.particles[index].size *= num68;
    this.EffectBigYolkShieldParticle_thr.SetParticles(this.particles, particles34);
  }

  public void setActive(byte effectflag)
  {
    this.WinLayoutTransform.gameObject.SetActive(((int) effectflag & 1) != 0);
    bool flag1 = ((int) effectflag & 2) != 0;
    this.LoseLayoutTransform.gameObject.SetActive(flag1);
    this.EnemyLoseLayoutTransform.gameObject.SetActive(flag1);
    this.ShieldLayoutTransform.gameObject.SetActive(((int) effectflag & 4) != 0);
    bool flag2 = ((int) effectflag & 16) != 0;
    this.ConveyLayoutTransform.gameObject.SetActive(flag2);
    this.NPCCityConveyLayoutTransform.gameObject.SetActive(flag2);
    this.YolkLayoutTransform.gameObject.SetActive(effectflag != (byte) 0);
  }

  public void EffectCheck()
  {
    for (int index1 = 0; index1 < this.EffectConveyParticle.Length; ++index1)
    {
      for (int index2 = 0; index2 < this.EffectConveyParticle[index1].Length; ++index2)
      {
        if ((UnityEngine.Object) this.EffectConveyParticle_two[index1][index2] != (UnityEngine.Object) null && !this.EffectConveyParticle_two[index1][index2].IsAlive())
        {
          this.EffectConveyGameObject[index1][index2].SetActive(false);
          for (int index3 = 0; index3 < this.ConveypoolsCounter; ++index3)
          {
            if (this.ConveypoolCounter[index3] < this.EffectConveyGameObjectPools[index3].Length)
            {
              this.EffectConveyGameObjectPools[index3][this.ConveypoolCounter[index3]] = this.EffectConveyGameObject[index1][index2];
              this.EffectConveyTransformPools[index3][this.ConveypoolCounter[index3]] = this.EffectConveyTransform[index1][index2];
              this.EffectConveyParticlePools[index3][this.ConveypoolCounter[index3]] = this.EffectConveyParticle[index1][index2];
              this.EffectConveyParticlePools_one[index3][this.ConveypoolCounter[index3]] = this.EffectConveyParticle_one[index1][index2];
              this.EffectConveyParticlePools_two[index3][this.ConveypoolCounter[index3]] = this.EffectConveyParticle_two[index1][index2];
              this.EffectConveyParticlePools_thr[index3][this.ConveypoolCounter[index3]] = this.EffectConveyParticle_thr[index1][index2];
              this.EffectConveyGameObject[index1][index2] = (GameObject) null;
              this.EffectConveyTransform[index1][index2] = (Transform) null;
              this.EffectConveyParticle[index1][index2] = (ParticleSystem) null;
              this.EffectConveyParticle_one[index1][index2] = (ParticleSystem) null;
              this.EffectConveyParticle_two[index1][index2] = (ParticleSystem) null;
              this.EffectConveyParticle_thr[index1][index2] = (ParticleSystem) null;
              ++this.ConveypoolCounter[index3];
              break;
            }
          }
        }
        if ((UnityEngine.Object) this.EffectNPCCityConveyParticle_two[index1][index2] != (UnityEngine.Object) null && !this.EffectNPCCityConveyParticle_two[index1][index2].IsAlive())
        {
          this.EffectNPCCityConveyGameObject[index1][index2].SetActive(false);
          for (int index4 = 0; index4 < this.NPCCityConveypoolsCounter; ++index4)
          {
            if (this.NPCCityConveypoolCounter[index4] < this.EffectNPCCityConveyGameObjectPools[index4].Length)
            {
              this.EffectNPCCityConveyGameObjectPools[index4][this.NPCCityConveypoolCounter[index4]] = this.EffectNPCCityConveyGameObject[index1][index2];
              this.EffectNPCCityConveyTransformPools[index4][this.NPCCityConveypoolCounter[index4]] = this.EffectNPCCityConveyTransform[index1][index2];
              this.EffectNPCCityConveyParticlePools[index4][this.NPCCityConveypoolCounter[index4]] = this.EffectNPCCityConveyParticle[index1][index2];
              this.EffectNPCCityConveyParticlePools_one[index4][this.NPCCityConveypoolCounter[index4]] = this.EffectNPCCityConveyParticle_one[index1][index2];
              this.EffectNPCCityConveyParticlePools_two[index4][this.NPCCityConveypoolCounter[index4]] = this.EffectNPCCityConveyParticle_two[index1][index2];
              this.EffectNPCCityConveyParticlePools_thr[index4][this.NPCCityConveypoolCounter[index4]] = this.EffectNPCCityConveyParticle_thr[index1][index2];
              this.EffectNPCCityConveyGameObject[index1][index2] = (GameObject) null;
              this.EffectNPCCityConveyTransform[index1][index2] = (Transform) null;
              this.EffectNPCCityConveyParticle[index1][index2] = (ParticleSystem) null;
              this.EffectNPCCityConveyParticle_one[index1][index2] = (ParticleSystem) null;
              this.EffectNPCCityConveyParticle_two[index1][index2] = (ParticleSystem) null;
              this.EffectNPCCityConveyParticle_thr[index1][index2] = (ParticleSystem) null;
              ++this.NPCCityConveypoolCounter[index4];
              break;
            }
          }
        }
      }
    }
  }

  public void ReflashEffect()
  {
    byte bBack = this.bBack;
    this.bBack = !this.bFront ? ((ActivityManager.Instance.bSpecialMonsterTreasureEvent & 2UL) <= 0UL ? (byte) 1 : (byte) 0) : (byte) 1;
    if ((int) bBack == (int) this.bBack)
      return;
    ushort EffID1 = 60102;
    ushort EffID2 = 60101;
    ushort EffID3 = 60103;
    ushort EffID4 = 60111;
    ushort EffID5 = 60110;
    ushort EffID6 = 60112;
    ushort EffID7 = 60104;
    ushort EffID8 = 60105;
    ushort EffID9 = 60106;
    ushort EffID10 = 60107;
    ushort EffID11 = 60108;
    ushort EffID12 = 60109;
    if (this.bBack == (byte) 1)
    {
      EffID1 = (ushort) 198;
      EffID2 = (ushort) 197;
      EffID3 = (ushort) 199;
      EffID4 = (ushort) 332;
      EffID5 = (ushort) 387;
      EffID6 = (ushort) 390;
      EffID7 = (ushort) 379;
      EffID8 = (ushort) 380;
      EffID9 = (ushort) 381;
      EffID10 = (ushort) 383;
      EffID11 = (ushort) 384;
      EffID12 = (ushort) 385;
    }
    for (int index1 = 0; index1 < this.WinpoolsCounter; ++index1)
    {
      for (int index2 = 0; index2 < this.WinpoolCounter[index1] && index2 < this.EffectWinGameObjectPools[index1].Length; ++index2)
      {
        if ((UnityEngine.Object) this.EffectWinGameObjectPools[index1][index2] != (UnityEngine.Object) null)
        {
          UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectWinGameObjectPools[index1][index2]);
          this.EffectWinGameObjectPools[index1][index2] = ParticleManager.Instance.Spawn(EffID1, (Transform) null, Vector3.zero, 1f, false, false);
          this.EffectWinGameObjectPools[index1][index2].SetActive(false);
          this.EffectWinTransformPools[index1][index2] = this.EffectWinGameObjectPools[index1][index2].transform;
          this.EffectWinTransformPools[index1][index2].SetParent(this.WinLayoutTransform);
          this.EffectWinTransformPools[index1][index2].localPosition = this.inipos;
          this.EffectWinParticlePools[index1][index2] = this.EffectWinTransformPools[index1][index2].GetChild(0).GetComponent<ParticleSystem>();
        }
      }
    }
    for (int index3 = 0; index3 < this.LosepoolsCounter; ++index3)
    {
      for (int index4 = 0; index4 < this.LosepoolCounter[index3] && index4 < this.EffectLoseGameObjectPools[index3].Length; ++index4)
      {
        if ((UnityEngine.Object) this.EffectLoseGameObjectPools[index3][index4] != (UnityEngine.Object) null)
        {
          UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectLoseGameObjectPools[index3][index4]);
          this.EffectLoseGameObjectPools[index3][index4] = ParticleManager.Instance.Spawn(EffID2, (Transform) null, Vector3.zero, 1f, false, false);
          this.EffectLoseGameObjectPools[index3][index4].SetActive(false);
          this.EffectLoseTransformPools[index3][index4] = this.EffectLoseGameObjectPools[index3][index4].transform;
          this.EffectLoseTransformPools[index3][index4].SetParent(this.LoseLayoutTransform);
          this.EffectLoseTransformPools[index3][index4].localPosition = this.inipos;
          this.EffectLoseParticlePools[index3][index4] = this.EffectLoseTransformPools[index3][index4].GetChild(0).GetComponent<ParticleSystem>();
        }
      }
    }
    for (int index5 = 0; index5 < this.ShieldpoolsCounter; ++index5)
    {
      for (int index6 = 0; index6 < this.ShieldpoolCounter[index5] && index6 < this.EffectShieldGameObjectPools[index5].Length; ++index6)
      {
        if ((UnityEngine.Object) this.EffectShieldGameObjectPools[index5][index6] != (UnityEngine.Object) null)
        {
          UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectShieldGameObjectPools[index5][index6]);
          this.EffectShieldGameObjectPools[index5][index6] = ParticleManager.Instance.Spawn(EffID3, (Transform) null, Vector3.zero, 1f, false, false);
          this.EffectShieldGameObjectPools[index5][index6].SetActive(false);
          this.EffectShieldTransformPools[index5][index6] = this.EffectShieldGameObjectPools[index5][index6].transform;
          this.EffectShieldTransformPools[index5][index6].SetParent(this.ShieldLayoutTransform);
          this.EffectShieldTransformPools[index5][index6].localPosition = this.inipos;
          this.EffectShieldParticlePools[index5][index6] = this.EffectShieldTransformPools[index5][index6].GetChild(0).GetComponent<ParticleSystem>();
          this.EffectShieldParticlePools_one[index5][index6] = this.EffectShieldTransformPools[index5][index6].GetChild(1).GetComponent<ParticleSystem>();
        }
      }
    }
    for (int index7 = 0; index7 < this.ConveypoolsCounter; ++index7)
    {
      for (int index8 = 0; index8 < this.ConveypoolCounter[index7] && index8 < this.EffectConveyGameObjectPools[index7].Length; ++index8)
      {
        if ((UnityEngine.Object) this.EffectConveyGameObjectPools[index7][index8] != (UnityEngine.Object) null)
        {
          UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectConveyGameObjectPools[index7][index8]);
          this.EffectConveyGameObjectPools[index7][index8] = ParticleManager.Instance.Spawn(EffID4, (Transform) null, Vector3.zero, 1f, false, false);
          this.EffectConveyGameObjectPools[index7][index8].SetActive(false);
          this.EffectConveyTransformPools[index7][index8] = this.EffectConveyGameObjectPools[index7][index8].transform;
          this.EffectConveyTransformPools[index7][index8].SetParent(this.ConveyLayoutTransform);
          this.EffectConveyTransformPools[index7][index8].localPosition = this.inipos;
          this.EffectConveyParticlePools[index7][index8] = this.EffectConveyTransformPools[index7][index8].GetChild(0).GetComponent<ParticleSystem>();
          this.EffectConveyParticlePools_one[index7][index8] = this.EffectConveyTransformPools[index7][index8].GetChild(1).GetComponent<ParticleSystem>();
          this.EffectConveyParticlePools_two[index7][index8] = this.EffectConveyTransformPools[index7][index8].GetChild(2).GetComponent<ParticleSystem>();
          this.EffectConveyParticlePools_thr[index7][index8] = this.EffectConveyTransformPools[index7][index8].GetChild(3).GetComponent<ParticleSystem>();
        }
      }
    }
    for (int index9 = 0; index9 < this.NPCCityConveypoolsCounter; ++index9)
    {
      for (int index10 = 0; index10 < this.NPCCityConveypoolCounter[index9] && index10 < this.EffectNPCCityConveyGameObjectPools[index9].Length; ++index10)
      {
        if ((UnityEngine.Object) this.EffectNPCCityConveyGameObjectPools[index9][index10] != (UnityEngine.Object) null)
        {
          UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectNPCCityConveyGameObjectPools[index9][index10]);
          this.EffectNPCCityConveyGameObjectPools[index9][index10] = ParticleManager.Instance.Spawn(EffID6, (Transform) null, Vector3.zero, 1f, false, false);
          this.EffectNPCCityConveyGameObjectPools[index9][index10].SetActive(false);
          this.EffectNPCCityConveyTransformPools[index9][index10] = this.EffectNPCCityConveyGameObjectPools[index9][index10].transform;
          this.EffectNPCCityConveyTransformPools[index9][index10].SetParent(this.NPCCityConveyLayoutTransform);
          this.EffectNPCCityConveyTransformPools[index9][index10].localPosition = this.inipos;
          this.EffectNPCCityConveyParticlePools[index9][index10] = this.EffectNPCCityConveyTransformPools[index9][index10].GetChild(0).GetComponent<ParticleSystem>();
          this.EffectNPCCityConveyParticlePools_one[index9][index10] = this.EffectNPCCityConveyTransformPools[index9][index10].GetChild(1).GetComponent<ParticleSystem>();
          this.EffectNPCCityConveyParticlePools_two[index9][index10] = this.EffectNPCCityConveyTransformPools[index9][index10].GetChild(2).GetComponent<ParticleSystem>();
          this.EffectNPCCityConveyParticlePools_thr[index9][index10] = this.EffectNPCCityConveyTransformPools[index9][index10].GetChild(3).GetComponent<ParticleSystem>();
        }
      }
    }
    for (int index11 = 0; index11 < this.EnemyLosepoolsCounter; ++index11)
    {
      for (int index12 = 0; index12 < this.EnemyLosepoolCounter[index11] && index12 < this.EffectEnemyLoseGameObjectPools[index11].Length; ++index12)
      {
        if ((UnityEngine.Object) this.EffectEnemyLoseGameObjectPools[index11][index12] != (UnityEngine.Object) null)
        {
          UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectEnemyLoseGameObjectPools[index11][index12]);
          this.EffectEnemyLoseGameObjectPools[index11][index12] = ParticleManager.Instance.Spawn(EffID5, (Transform) null, Vector3.zero, 1f, false, false);
          this.EffectEnemyLoseGameObjectPools[index11][index12].SetActive(false);
          this.EffectEnemyLoseTransformPools[index11][index12] = this.EffectEnemyLoseGameObjectPools[index11][index12].transform;
          this.EffectEnemyLoseTransformPools[index11][index12].SetParent(this.EnemyLoseLayoutTransform);
          this.EffectEnemyLoseTransformPools[index11][index12].localPosition = this.inipos;
          this.EffectEnemyLoseParticlePools[index11][index12] = this.EffectEnemyLoseTransformPools[index11][index12].GetChild(0).GetComponent<ParticleSystem>();
        }
      }
    }
    bool flag1 = true;
    if ((UnityEngine.Object) this.EffectWinParticlePools[0][0] != (UnityEngine.Object) null)
    {
      this.WinstartSize = this.EffectWinParticlePools[0][0].startSize;
      this.Winlifetime = this.EffectWinParticlePools[0][0].startLifetime;
    }
    else
      flag1 = false;
    bool flag2 = true;
    if ((UnityEngine.Object) this.EffectLoseParticlePools[0][0] != (UnityEngine.Object) null)
    {
      this.LosestartSize = this.EffectLoseParticlePools[0][0].startSize;
      this.Loselifetime = this.EffectLoseParticlePools[0][0].startLifetime;
    }
    else
      flag2 = false;
    bool flag3 = true;
    if ((UnityEngine.Object) this.EffectEnemyLoseParticlePools[0][0] != (UnityEngine.Object) null)
    {
      this.EnemyLosestartSize = this.EffectEnemyLoseParticlePools[0][0].startSize;
      this.EnemyLoselifetime = this.EffectEnemyLoseParticlePools[0][0].startLifetime;
    }
    else
      flag3 = false;
    bool flag4 = true;
    if ((UnityEngine.Object) this.EffectShieldParticlePools[0][0] != (UnityEngine.Object) null)
      this.ShieldstartSize = this.EffectShieldParticlePools[0][0].startSize;
    else
      flag4 = false;
    bool flag5 = true;
    if ((UnityEngine.Object) this.EffectConveyParticlePools[0][0] != (UnityEngine.Object) null)
    {
      this.ConveystartSize = this.EffectConveyParticlePools[0][0].startSize;
      this.Conveylifetime = this.EffectConveyParticlePools[0][0].startLifetime;
    }
    else
      flag5 = false;
    if ((UnityEngine.Object) this.EffectConveyParticlePools_one[0][0] != (UnityEngine.Object) null)
    {
      this.ConveystartSize_one = this.EffectConveyParticlePools_one[0][0].startSize;
      this.Conveylifetime_one = this.EffectConveyParticlePools_one[0][0].startLifetime;
    }
    if ((UnityEngine.Object) this.EffectConveyParticlePools_two[0][0] != (UnityEngine.Object) null)
    {
      this.ConveystartSize_two = this.EffectConveyParticlePools_two[0][0].startSize;
      this.Conveylifetime_two = this.EffectConveyParticlePools_two[0][0].startLifetime;
    }
    if ((UnityEngine.Object) this.EffectConveyParticlePools_thr[0][0] != (UnityEngine.Object) null)
    {
      this.ConveystartSize_thr = this.EffectConveyParticlePools_thr[0][0].startSize;
      this.Conveylifetime_thr = this.EffectConveyParticlePools_thr[0][0].startLifetime;
    }
    bool flag6 = true;
    if ((UnityEngine.Object) this.EffectNPCCityConveyParticlePools[0][0] != (UnityEngine.Object) null)
    {
      this.NPCCityConveystartSize = this.EffectNPCCityConveyParticlePools[0][0].startSize;
      this.NPCCityConveylifetime = this.EffectNPCCityConveyParticlePools[0][0].startLifetime;
    }
    else
      flag6 = false;
    if ((UnityEngine.Object) this.EffectNPCCityConveyParticlePools_one[0][0] != (UnityEngine.Object) null)
    {
      this.NPCCityConveystartSize_one = this.EffectNPCCityConveyParticlePools_one[0][0].startSize;
      this.NPCCityConveylifetime_one = this.EffectNPCCityConveyParticlePools_one[0][0].startLifetime;
    }
    if ((UnityEngine.Object) this.EffectNPCCityConveyParticlePools_two[0][0] != (UnityEngine.Object) null)
    {
      this.NPCCityConveystartSize_two = this.EffectNPCCityConveyParticlePools_two[0][0].startSize;
      this.NPCCityConveylifetime_two = this.EffectNPCCityConveyParticlePools_two[0][0].startLifetime;
    }
    if ((UnityEngine.Object) this.EffectNPCCityConveyParticlePools_thr[0][0] != (UnityEngine.Object) null)
    {
      this.NPCCityConveystartSize_thr = this.EffectNPCCityConveyParticlePools_thr[0][0].startSize;
      this.NPCCityConveylifetime_thr = this.EffectNPCCityConveyParticlePools_thr[0][0].startLifetime;
    }
    Vector3 zero = Vector3.zero;
    float x = this.RealmGroup.localScale.x;
    bool flag7 = false;
    if ((UnityEngine.Object) this.EffectYolkWinGameObject != (UnityEngine.Object) null)
    {
      bool activeSelf = this.EffectYolkWinGameObject.activeSelf;
      Vector3 localPosition = this.EffectYolkWinTransform.localPosition;
      UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectYolkWinGameObject);
      this.EffectYolkWinGameObject = ParticleManager.Instance.Spawn(EffID7, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectYolkWinTransform = this.EffectYolkWinGameObject.transform;
      this.EffectYolkWinTransform.SetParent(this.YolkLayoutTransform);
      this.EffectYolkWinTransform.localPosition = localPosition;
      this.EffectYolkWinParticle = this.EffectYolkWinTransform.GetChild(0).GetComponent<ParticleSystem>();
      this.EffectYolkWinParticle_one = this.EffectYolkWinTransform.GetChild(1).GetComponent<ParticleSystem>();
      this.EffectYolkWinParticle_two = this.EffectYolkWinTransform.GetChild(2).GetComponent<ParticleSystem>();
      this.EffectYolkWinParticle_thr = this.EffectYolkWinTransform.GetChild(3).GetComponent<ParticleSystem>();
      this.EffectYolkWinParticle_tho = this.EffectYolkWinTransform.GetChild(4).GetComponent<ParticleSystem>();
      this.YolkWinstartSize = this.EffectYolkWinParticle.startSize;
      this.YolkWinstartSize_one = this.EffectYolkWinParticle_one.startSize;
      this.YolkWinstartSize_two = this.EffectYolkWinParticle_two.startSize;
      this.YolkWinstartSize_thr = this.EffectYolkWinParticle_thr.startSize;
      this.YolkWinstartSize_tho = this.EffectYolkWinParticle_tho.startSize;
      this.YolkWinlifetime = this.EffectYolkWinParticle.startLifetime;
      this.YolkWinlifetime_one = this.EffectYolkWinParticle_one.startLifetime;
      this.YolkWinlifetime_two = this.EffectYolkWinParticle_two.startLifetime;
      this.YolkWinlifetime_thr = this.EffectYolkWinParticle_thr.startLifetime;
      this.YolkWinlifetime_tho = this.EffectYolkWinParticle_tho.startLifetime;
      if (activeSelf)
      {
        this.EffectYolkWinParticle.startSize = this.YolkWinstartSize * x;
        this.EffectYolkWinParticle_one.startSize = this.YolkWinstartSize_one * x;
        this.EffectYolkWinParticle_two.startSize = this.YolkWinstartSize_two * x;
        this.EffectYolkWinParticle_thr.startSize = this.YolkWinstartSize_thr * x;
        this.EffectYolkWinParticle_tho.startSize = this.YolkWinstartSize_tho * x;
        this.EffectYolkWinParticle.startLifetime = this.YolkWinlifetime * x;
        this.EffectYolkWinParticle_one.startLifetime = this.YolkWinlifetime_one * x;
        this.EffectYolkWinParticle_two.startLifetime = this.YolkWinlifetime_two * x;
        this.EffectYolkWinParticle_thr.startLifetime = this.YolkWinstartSize_thr * x;
        this.EffectYolkWinParticle_tho.startLifetime = this.YolkWinstartSize_tho * x;
        flag7 = activeSelf;
      }
      this.EffectYolkWinGameObject.SetActive(activeSelf);
    }
    if ((UnityEngine.Object) this.EffectYolkLoseGameObject != (UnityEngine.Object) null)
    {
      bool activeSelf = this.EffectYolkLoseGameObject.activeSelf;
      Vector3 localPosition = this.EffectYolkLoseTransform.localPosition;
      UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectYolkLoseGameObject);
      this.EffectYolkLoseGameObject = ParticleManager.Instance.Spawn(EffID8, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectYolkLoseTransform = this.EffectYolkLoseGameObject.transform;
      this.EffectYolkLoseTransform.SetParent(this.YolkLayoutTransform);
      this.EffectYolkLoseTransform.localPosition = localPosition;
      this.EffectYolkLoseParticle = this.EffectYolkLoseTransform.GetChild(0).GetComponent<ParticleSystem>();
      this.EffectYolkLoseParticle_one = this.EffectYolkLoseTransform.GetChild(1).GetComponent<ParticleSystem>();
      this.YolkLosestartSize = this.EffectYolkLoseParticle.startSize;
      this.YolkLosestartSize_one = this.EffectYolkLoseParticle_one.startSize;
      this.YolkLoselifetime = this.EffectYolkLoseParticle.startLifetime;
      this.YolkLoselifetime_one = this.EffectYolkLoseParticle_one.startLifetime;
      if (activeSelf)
      {
        this.EffectYolkLoseParticle.startSize = this.YolkLosestartSize * x;
        this.EffectYolkLoseParticle_one.startSize = this.YolkLosestartSize_one * x;
        this.EffectYolkLoseParticle.startLifetime = this.YolkLoselifetime * x;
        this.EffectYolkLoseParticle_one.startLifetime = this.YolkLoselifetime_one * x;
        flag7 = activeSelf;
      }
      this.EffectYolkLoseGameObject.SetActive(activeSelf);
    }
    if ((UnityEngine.Object) this.EffectYolkShieldGameObject != (UnityEngine.Object) null)
    {
      bool activeSelf = this.EffectYolkShieldGameObject.activeSelf;
      Vector3 localPosition = this.EffectYolkShieldTransform.localPosition;
      UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectYolkShieldGameObject);
      this.EffectYolkShieldGameObject = ParticleManager.Instance.Spawn(EffID9, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectYolkShieldTransform = this.EffectYolkShieldGameObject.transform;
      this.EffectYolkShieldTransform.SetParent(this.YolkLayoutTransform);
      this.EffectYolkShieldTransform.localPosition = localPosition;
      this.EffectYolkShieldParticle = this.EffectYolkShieldTransform.GetChild(0).GetComponent<ParticleSystem>();
      this.EffectYolkShieldParticle_one = this.EffectYolkShieldTransform.GetChild(1).GetComponent<ParticleSystem>();
      this.EffectYolkShieldParticle_two = this.EffectYolkShieldTransform.GetChild(2).GetComponent<ParticleSystem>();
      this.EffectYolkShieldParticle_thr = this.EffectYolkShieldTransform.GetChild(3).GetComponent<ParticleSystem>();
      this.YolkShieldstartSize = this.EffectYolkShieldParticle.startSize;
      this.YolkShieldstartSize_one = this.EffectYolkShieldParticle_one.startSize;
      this.YolkShieldstartSize_two = this.EffectYolkShieldParticle_two.startSize;
      this.YolkShieldstartSize_thr = this.EffectYolkShieldParticle_thr.startSize;
      this.YolkShieldlifetime = this.EffectYolkShieldParticle.startLifetime;
      this.YolkShieldlifetime_one = this.EffectYolkShieldParticle_one.startLifetime;
      this.YolkShieldlifetime_two = this.EffectYolkShieldParticle_two.startLifetime;
      this.YolkShieldlifetime_thr = this.EffectYolkShieldParticle_thr.startLifetime;
      if (activeSelf)
      {
        this.EffectYolkShieldParticle.startSize = this.YolkShieldstartSize * x;
        this.EffectYolkShieldParticle_one.startSize = this.YolkShieldstartSize_one * x;
        this.EffectYolkShieldParticle_two.startSize = this.YolkShieldstartSize_two * x * this.YolkShieldScale;
        this.EffectYolkShieldParticle_thr.startSize = this.YolkShieldstartSize_thr * x * this.YolkShieldScale;
        this.EffectYolkShieldParticle.startLifetime = this.YolkShieldlifetime * x;
        this.EffectYolkShieldParticle_one.startLifetime = this.YolkShieldlifetime_one * x;
        flag7 = activeSelf;
      }
      this.EffectYolkShieldGameObject.SetActive(activeSelf);
    }
    if ((UnityEngine.Object) this.EffectBigYolkWinGameObject != (UnityEngine.Object) null)
    {
      bool activeSelf = this.EffectBigYolkWinGameObject.activeSelf;
      Vector3 localPosition = this.EffectBigYolkWinTransform.localPosition;
      UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectBigYolkWinGameObject);
      this.EffectBigYolkWinGameObject = ParticleManager.Instance.Spawn(EffID10, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectBigYolkWinTransform = this.EffectBigYolkWinGameObject.transform;
      this.EffectBigYolkWinTransform.SetParent(this.YolkLayoutTransform);
      this.EffectBigYolkWinTransform.localPosition = localPosition;
      this.EffectBigYolkWinParticle = this.EffectBigYolkWinTransform.GetChild(0).GetComponent<ParticleSystem>();
      this.EffectBigYolkWinParticle_one = this.EffectBigYolkWinTransform.GetChild(1).GetComponent<ParticleSystem>();
      this.EffectBigYolkWinParticle_two = this.EffectBigYolkWinTransform.GetChild(2).GetComponent<ParticleSystem>();
      this.EffectBigYolkWinParticle_thr = this.EffectBigYolkWinTransform.GetChild(3).GetComponent<ParticleSystem>();
      this.EffectBigYolkWinParticle_for = this.EffectBigYolkWinTransform.GetChild(4).GetComponent<ParticleSystem>();
      this.BigYolkWinstartSize = this.EffectBigYolkWinParticle.startSize;
      this.BigYolkWinstartSize_one = this.EffectBigYolkWinParticle_one.startSize;
      this.BigYolkWinstartSize_two = this.EffectBigYolkWinParticle_two.startSize;
      this.BigYolkWinstartSize_thr = this.EffectBigYolkWinParticle_thr.startSize;
      this.BigYolkWinstartSize_for = this.EffectBigYolkWinParticle_for.startSize;
      this.BigYolkWinlifetime = this.EffectBigYolkWinParticle.startLifetime;
      this.BigYolkWinlifetime_one = this.EffectBigYolkWinParticle_one.startLifetime;
      this.BigYolkWinlifetime_two = this.EffectBigYolkWinParticle_two.startLifetime;
      this.BigYolkWinlifetime_thr = this.EffectBigYolkWinParticle_thr.startLifetime;
      this.BigYolkWinlifetime_for = this.EffectBigYolkWinParticle_for.startLifetime;
      if (activeSelf)
      {
        this.EffectBigYolkWinParticle.startSize = this.BigYolkWinstartSize * x;
        this.EffectBigYolkWinParticle_one.startSize = this.BigYolkWinstartSize_one * x;
        this.EffectBigYolkWinParticle_two.startSize = this.BigYolkWinstartSize_two * x;
        this.EffectBigYolkWinParticle_thr.startSize = this.BigYolkWinstartSize_thr * x;
        this.EffectBigYolkWinParticle_for.startSize = this.BigYolkWinstartSize_for * x;
        this.EffectBigYolkWinParticle.startLifetime = this.BigYolkWinlifetime * x;
        this.EffectBigYolkWinParticle_one.startLifetime = this.BigYolkWinlifetime_one * x;
        this.EffectBigYolkWinParticle_two.startLifetime = this.BigYolkWinlifetime_two * x;
        this.EffectBigYolkWinParticle_thr.startLifetime = this.BigYolkWinlifetime_thr * x;
        this.EffectBigYolkWinParticle_for.startLifetime = this.BigYolkWinlifetime_for * x;
        flag7 = activeSelf;
      }
      this.EffectBigYolkWinGameObject.SetActive(activeSelf);
    }
    if ((UnityEngine.Object) this.EffectBigYolkLoseGameObject != (UnityEngine.Object) null)
    {
      bool activeSelf = this.EffectBigYolkLoseGameObject.activeSelf;
      Vector3 localPosition = this.EffectBigYolkLoseTransform.localPosition;
      UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectBigYolkLoseGameObject);
      this.EffectBigYolkLoseGameObject = ParticleManager.Instance.Spawn(EffID11, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectBigYolkLoseTransform = this.EffectBigYolkLoseGameObject.transform;
      this.EffectBigYolkLoseTransform.SetParent(this.YolkLayoutTransform);
      this.EffectBigYolkLoseTransform.localPosition = localPosition;
      this.EffectBigYolkLoseParticle = this.EffectBigYolkLoseTransform.GetChild(0).GetComponent<ParticleSystem>();
      this.EffectBigYolkLoseParticle_one = this.EffectBigYolkLoseTransform.GetChild(1).GetComponent<ParticleSystem>();
      this.EffectBigYolkLoseParticle_two = this.EffectBigYolkLoseTransform.GetChild(2).GetComponent<ParticleSystem>();
      this.BigYolkLosestartSize = this.EffectBigYolkLoseParticle.startSize;
      this.BigYolkLosestartSize_one = this.EffectBigYolkLoseParticle_one.startSize;
      this.BigYolkLosestartSize_two = this.EffectBigYolkLoseParticle_two.startSize;
      this.BigYolkLoselifetime = this.EffectBigYolkLoseParticle.startLifetime;
      this.BigYolkLosestartSize_one = this.EffectBigYolkLoseParticle_one.startSize;
      this.BigYolkLosestartSize_two = this.EffectBigYolkLoseParticle_two.startSize;
      if (activeSelf)
      {
        this.EffectBigYolkLoseParticle.startSize = this.BigYolkLosestartSize * x;
        this.EffectBigYolkLoseParticle_one.startSize = this.BigYolkLosestartSize_one * x;
        this.EffectBigYolkLoseParticle_two.startSize = this.BigYolkLosestartSize_two * x;
        this.EffectBigYolkLoseParticle.startLifetime = this.BigYolkLoselifetime * x;
        this.EffectBigYolkLoseParticle_one.startLifetime = this.BigYolkLoselifetime_one * x;
        this.EffectBigYolkLoseParticle_two.startLifetime = this.BigYolkLoselifetime_two * x;
        flag7 = activeSelf;
      }
      this.EffectBigYolkLoseGameObject.SetActive(activeSelf);
    }
    if ((UnityEngine.Object) this.EffectBigYolkShieldGameObject != (UnityEngine.Object) null)
    {
      bool activeSelf = this.EffectBigYolkShieldGameObject.activeSelf;
      Vector3 localPosition = this.EffectBigYolkShieldTransform.localPosition;
      UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectBigYolkShieldGameObject);
      this.EffectBigYolkShieldGameObject = ParticleManager.Instance.Spawn(EffID12, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectBigYolkShieldTransform = this.EffectBigYolkShieldGameObject.transform;
      this.EffectBigYolkShieldTransform.SetParent(this.YolkLayoutTransform);
      this.EffectBigYolkShieldTransform.localPosition = localPosition;
      this.EffectBigYolkShieldParticle = this.EffectBigYolkShieldTransform.GetChild(0).GetComponent<ParticleSystem>();
      this.EffectBigYolkShieldParticle_one = this.EffectBigYolkShieldTransform.GetChild(1).GetComponent<ParticleSystem>();
      this.EffectBigYolkShieldParticle_two = this.EffectBigYolkShieldTransform.GetChild(2).GetComponent<ParticleSystem>();
      this.EffectBigYolkShieldParticle_thr = this.EffectBigYolkShieldTransform.GetChild(3).GetComponent<ParticleSystem>();
      this.BigYolkShieldstartSize = this.EffectBigYolkShieldParticle.startSize;
      this.BigYolkShieldstartSize_one = this.EffectBigYolkShieldParticle_one.startSize;
      this.BigYolkShieldstartSize_two = this.EffectBigYolkShieldParticle_two.startSize;
      this.BigYolkShieldstartSize_thr = this.EffectBigYolkShieldParticle_thr.startSize;
      this.BigYolkShieldlifetime = this.EffectBigYolkShieldParticle.startLifetime;
      this.BigYolkShieldlifetime_one = this.EffectBigYolkShieldParticle_one.startLifetime;
      this.BigYolkShieldlifetime_two = this.EffectBigYolkShieldParticle_two.startLifetime;
      this.BigYolkShieldlifetime_thr = this.EffectBigYolkShieldParticle_thr.startLifetime;
      if (activeSelf)
      {
        this.EffectBigYolkShieldParticle.startSize = this.BigYolkShieldstartSize * x;
        this.EffectBigYolkShieldParticle_one.startSize = this.BigYolkShieldstartSize_one * x;
        this.EffectBigYolkShieldParticle_two.startSize = this.BigYolkShieldstartSize_two * x * this.YolkShieldScale;
        this.EffectBigYolkShieldParticle_thr.startSize = this.BigYolkShieldstartSize_thr * x * this.YolkShieldScale;
        this.EffectBigYolkShieldParticle.startLifetime = this.BigYolkShieldlifetime * x;
        this.EffectBigYolkShieldParticle_one.startLifetime = this.BigYolkShieldlifetime_one * x;
        flag7 = activeSelf;
      }
      this.EffectBigYolkShieldGameObject.SetActive(activeSelf);
    }
    if (flag7)
      this.setEffect(this.Yolkrow, this.Yolkcol, DataManager.MapDataController.zoomSize);
    for (int col = 0; col < this.EffectWinGameObject.Length; ++col)
    {
      for (int row = 0; row < this.EffectWinGameObject[col].Length; ++row)
      {
        bool flag8 = false;
        if ((UnityEngine.Object) this.EffectWinGameObject[col][row] != (UnityEngine.Object) null)
        {
          Vector3 localPosition = this.EffectWinTransform[col][row].localPosition;
          UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectWinGameObject[col][row]);
          this.EffectWinGameObject[col][row] = ParticleManager.Instance.Spawn(EffID1, (Transform) null, Vector3.zero, 1f, false, false);
          this.EffectWinTransform[col][row] = this.EffectWinGameObject[col][row].transform;
          this.EffectWinTransform[col][row].SetParent(this.WinLayoutTransform);
          this.EffectWinTransform[col][row].localPosition = localPosition;
          this.EffectWinParticle[col][row] = this.EffectWinTransform[col][row].GetChild(0).GetComponent<ParticleSystem>();
          if (!flag1)
          {
            this.WinstartSize = this.EffectWinParticle[col][row].startSize;
            this.Winlifetime = this.EffectWinParticle[col][row].startLifetime;
            flag1 = true;
          }
          this.EffectWinParticle[col][row].startSize = this.WinstartSize * x;
          this.EffectWinParticle[col][row].startLifetime = this.Winlifetime * x;
          this.EffectWinGameObject[col][row].SetActive(true);
          flag8 = true;
        }
        if ((UnityEngine.Object) this.EffectLoseGameObject[col][row] != (UnityEngine.Object) null)
        {
          Vector3 localPosition = this.EffectLoseTransform[col][row].localPosition;
          UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectLoseGameObject[col][row]);
          this.EffectLoseGameObject[col][row] = ParticleManager.Instance.Spawn(EffID2, (Transform) null, Vector3.zero, 1f, false, false);
          this.EffectLoseTransform[col][row] = this.EffectLoseGameObject[col][row].transform;
          this.EffectLoseTransform[col][row].SetParent(this.LoseLayoutTransform);
          this.EffectLoseTransform[col][row].localPosition = localPosition;
          this.EffectLoseParticle[col][row] = this.EffectLoseTransform[col][row].GetChild(0).GetComponent<ParticleSystem>();
          if (!flag2)
          {
            this.LosestartSize = this.EffectLoseParticle[col][row].startSize;
            this.Loselifetime = this.EffectLoseParticle[col][row].startLifetime;
            flag2 = true;
          }
          this.EffectLoseParticle[col][row].startSize = this.LosestartSize * x;
          this.EffectLoseParticle[col][row].startLifetime = this.Loselifetime * x;
          this.EffectLoseGameObject[col][row].SetActive(true);
          flag8 = true;
        }
        if ((UnityEngine.Object) this.EffectShieldGameObject[col][row] != (UnityEngine.Object) null)
        {
          Vector3 localPosition = this.EffectShieldTransform[col][row].localPosition;
          UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectShieldGameObject[col][row]);
          this.EffectShieldGameObject[col][row] = ParticleManager.Instance.Spawn(EffID3, (Transform) null, Vector3.zero, 1f, false, false);
          this.EffectShieldTransform[col][row] = this.EffectShieldGameObject[col][row].transform;
          this.EffectShieldTransform[col][row].SetParent(this.ShieldLayoutTransform);
          this.EffectShieldTransform[col][row].localPosition = localPosition;
          this.EffectShieldParticle[col][row] = this.EffectShieldTransform[col][row].GetChild(0).GetComponent<ParticleSystem>();
          this.EffectShieldParticle_one[col][row] = this.EffectShieldTransform[col][row].GetChild(1).GetComponent<ParticleSystem>();
          if (!flag4)
          {
            this.ShieldstartSize = this.EffectShieldParticle[col][row].startSize;
            flag4 = true;
          }
          this.EffectShieldParticle[col][row].startSize = this.ShieldstartSize * x;
          this.EffectShieldParticle_one[col][row].startSize = this.ShieldstartSize * x;
          this.EffectShieldGameObject[col][row].SetActive(true);
          flag8 = true;
        }
        if ((UnityEngine.Object) this.EffectConveyGameObject[col][row] != (UnityEngine.Object) null)
        {
          Vector3 localPosition = this.EffectConveyTransform[col][row].localPosition;
          UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectConveyGameObject[col][row]);
          this.EffectConveyGameObject[col][row] = ParticleManager.Instance.Spawn(EffID4, (Transform) null, Vector3.zero, 1f, false, false);
          this.EffectConveyTransform[col][row] = this.EffectConveyGameObject[col][row].transform;
          this.EffectConveyTransform[col][row].SetParent(this.ConveyLayoutTransform);
          this.EffectConveyTransform[col][row].localPosition = localPosition;
          this.EffectConveyParticle[col][row] = this.EffectConveyTransform[col][row].GetChild(0).GetComponent<ParticleSystem>();
          this.EffectConveyParticle_one[col][row] = this.EffectConveyTransform[col][row].GetChild(1).GetComponent<ParticleSystem>();
          this.EffectConveyParticle_two[col][row] = this.EffectConveyTransform[col][row].GetChild(2).GetComponent<ParticleSystem>();
          this.EffectConveyParticle_thr[col][row] = this.EffectConveyTransform[col][row].GetChild(3).GetComponent<ParticleSystem>();
          if (!flag5)
          {
            this.ConveystartSize = this.EffectConveyParticle[col][row].startSize;
            this.Conveylifetime = this.EffectConveyParticle[col][row].startLifetime;
            this.ConveystartSize_one = this.EffectConveyParticle_one[col][row].startSize;
            this.Conveylifetime_one = this.EffectConveyParticle_one[col][row].startLifetime;
            this.ConveystartSize_two = this.EffectConveyParticle_two[col][row].startSize;
            this.Conveylifetime_two = this.EffectConveyParticle_two[col][row].startLifetime;
            this.ConveystartSize_thr = this.EffectConveyParticle_thr[col][row].startSize;
            this.Conveylifetime_thr = this.EffectConveyParticle_thr[col][row].startLifetime;
            flag5 = true;
          }
          this.EffectConveyParticle[col][row].startSize = this.ConveystartSize * x;
          this.EffectConveyParticle[col][row].startLifetime = this.Conveylifetime * x;
          this.EffectConveyParticle_one[col][row].startSize = this.ConveystartSize_one * x;
          this.EffectConveyParticle_one[col][row].startLifetime = this.Conveylifetime_one * x;
          this.EffectConveyParticle_two[col][row].startSize = this.ConveystartSize_two * x;
          this.EffectConveyParticle_two[col][row].startLifetime = this.Conveylifetime_two * x;
          this.EffectConveyParticle_thr[col][row].startSize = this.ConveystartSize_thr * x;
          this.EffectConveyParticle_thr[col][row].startLifetime = this.Conveylifetime_thr * x;
          this.EffectConveyGameObject[col][row].SetActive(true);
          flag8 = true;
        }
        if ((UnityEngine.Object) this.EffectNPCCityConveyGameObject[col][row] != (UnityEngine.Object) null)
        {
          Vector3 localPosition = this.EffectNPCCityConveyTransform[col][row].localPosition;
          UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectNPCCityConveyGameObject[col][row]);
          this.EffectNPCCityConveyGameObject[col][row] = ParticleManager.Instance.Spawn(EffID6, (Transform) null, Vector3.zero, 1f, false, false);
          this.EffectNPCCityConveyTransform[col][row] = this.EffectNPCCityConveyGameObject[col][row].transform;
          this.EffectNPCCityConveyTransform[col][row].SetParent(this.NPCCityConveyLayoutTransform);
          this.EffectNPCCityConveyTransform[col][row].localPosition = localPosition;
          this.EffectNPCCityConveyParticle[col][row] = this.EffectNPCCityConveyTransform[col][row].GetChild(0).GetComponent<ParticleSystem>();
          this.EffectNPCCityConveyParticle_one[col][row] = this.EffectNPCCityConveyTransform[col][row].GetChild(1).GetComponent<ParticleSystem>();
          this.EffectNPCCityConveyParticle_two[col][row] = this.EffectNPCCityConveyTransform[col][row].GetChild(2).GetComponent<ParticleSystem>();
          this.EffectNPCCityConveyParticle_thr[col][row] = this.EffectNPCCityConveyTransform[col][row].GetChild(3).GetComponent<ParticleSystem>();
          if (!flag6)
          {
            this.NPCCityConveystartSize = this.EffectNPCCityConveyParticle[col][row].startSize;
            this.NPCCityConveylifetime = this.EffectNPCCityConveyParticle[col][row].startLifetime;
            this.NPCCityConveystartSize_one = this.EffectNPCCityConveyParticle_one[col][row].startSize;
            this.NPCCityConveylifetime_one = this.EffectNPCCityConveyParticle_one[col][row].startLifetime;
            this.NPCCityConveystartSize_two = this.EffectNPCCityConveyParticle_two[col][row].startSize;
            this.NPCCityConveylifetime_two = this.EffectNPCCityConveyParticle_two[col][row].startLifetime;
            this.NPCCityConveystartSize_thr = this.EffectNPCCityConveyParticle_thr[col][row].startSize;
            this.NPCCityConveylifetime_thr = this.EffectNPCCityConveyParticle_thr[col][row].startLifetime;
            flag6 = true;
          }
          this.EffectNPCCityConveyParticle[col][row].startSize = this.NPCCityConveystartSize * x;
          this.EffectNPCCityConveyParticle[col][row].startLifetime = this.NPCCityConveylifetime * x;
          this.EffectNPCCityConveyParticle_one[col][row].startSize = this.NPCCityConveystartSize_one * x;
          this.EffectNPCCityConveyParticle_one[col][row].startLifetime = this.NPCCityConveylifetime_one * x;
          this.EffectNPCCityConveyParticle_two[col][row].startSize = this.NPCCityConveystartSize_two * x;
          this.EffectNPCCityConveyParticle_two[col][row].startLifetime = this.NPCCityConveylifetime_two * x;
          this.EffectNPCCityConveyParticle_thr[col][row].startSize = this.NPCCityConveystartSize_thr * x;
          this.EffectNPCCityConveyParticle_thr[col][row].startLifetime = this.NPCCityConveylifetime_thr * x;
          this.EffectNPCCityConveyGameObject[col][row].SetActive(true);
          flag8 = true;
        }
        if ((UnityEngine.Object) this.EffectEnemyLoseGameObject[col][row] != (UnityEngine.Object) null)
        {
          Vector3 localPosition = this.EffectEnemyLoseTransform[col][row].localPosition;
          UnityEngine.Object.DestroyObject((UnityEngine.Object) this.EffectEnemyLoseGameObject[col][row]);
          this.EffectEnemyLoseGameObject[col][row] = ParticleManager.Instance.Spawn(EffID5, (Transform) null, Vector3.zero, 1f, false, false);
          this.EffectEnemyLoseTransform[col][row] = this.EffectEnemyLoseGameObject[col][row].transform;
          this.EffectEnemyLoseTransform[col][row].SetParent(this.EnemyLoseLayoutTransform);
          this.EffectEnemyLoseTransform[col][row].localPosition = localPosition;
          this.EffectEnemyLoseParticle[col][row] = this.EffectEnemyLoseTransform[col][row].GetChild(0).GetComponent<ParticleSystem>();
          if (!flag3)
          {
            this.EnemyLosestartSize = this.EffectEnemyLoseParticle[col][row].startSize;
            this.EnemyLoselifetime = this.EffectEnemyLoseParticle[col][row].startLifetime;
            flag3 = true;
          }
          this.EffectEnemyLoseParticle[col][row].startSize = this.EnemyLosestartSize * x;
          this.EffectEnemyLoseParticle[col][row].startLifetime = this.EnemyLoselifetime * x;
          this.EffectEnemyLoseGameObject[col][row].SetActive(true);
          flag8 = true;
        }
        if (flag8)
          this.setEffect(row, col, DataManager.MapDataController.zoomSize);
      }
    }
    GC.Collect();
  }
}
