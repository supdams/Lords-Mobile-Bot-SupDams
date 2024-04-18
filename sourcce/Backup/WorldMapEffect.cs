// Decompiled with JetBrains decompiler
// Type: WorldMapEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class WorldMapEffect
{
  private const ushort EffectActID = 60201;
  private Transform TotalityGroup;
  private Transform EffectLayoutTransform;
  private Transform ActLayoutTransform;
  private GameObject[][] EffectActGameObject;
  private Transform[][] EffectActTransform;
  private ParticleSystem[][] EffectActParticle;
  private ParticleSystem[][] EffectActParticle_one;
  private ParticleSystem[][] EffectActParticle_two;
  private ParticleSystem[][] EffectActParticle_three;
  private GameObject[][] EffectActGameObjectPools;
  private Transform[][] EffectActTransformPools;
  private ParticleSystem[][] EffectActParticlePools;
  private ParticleSystem[][] EffectActParticlePools_one;
  private ParticleSystem[][] EffectActParticlePools_two;
  private ParticleSystem[][] EffectActParticlePools_three;
  private int[] ActpoolCounter;
  private int ActpoolsCounter;
  private Vector3 inipos = new Vector3(0.0f, 1024f, 0.0f);
  private float ActstartSize;
  private float Actlifetime;
  private float ActstartSize_one;
  private float Actlifetime_one;
  private float ActstartSize_two;
  private float Actlifetime_two;
  private float ActstartSize_three;
  private float Actlifetime_three;
  private ParticleSystem.Particle[] particles = new ParticleSystem.Particle[64];

  public WorldMapEffect(Transform totalityGroup, float tileBaseScale)
  {
    this.EffectLayoutTransform = new GameObject("WorldMapTileEffect").transform;
    this.TotalityGroup = totalityGroup;
    this.EffectLayoutTransform.localScale = Vector3.one * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
    this.EffectLayoutTransform.position = Vector3.forward * 1024f * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
    this.EffectLayoutTransform.SetParent(totalityGroup, false);
    this.ActLayoutTransform = new GameObject("MapTileEffectWin").transform;
    this.ActLayoutTransform.SetParent(this.EffectLayoutTransform, false);
    this.ActpoolsCounter = 0;
  }

  public void OnDestroy()
  {
    if (this.EffectActGameObject != null)
    {
      for (int index1 = 0; index1 < this.EffectActGameObject.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.EffectActGameObject[index1].Length; ++index2)
        {
          if ((UnityEngine.Object) this.EffectActGameObject[index1][index2] != (UnityEngine.Object) null)
          {
            ParticleManager.Instance.DeSpawn(this.EffectActGameObject[index1][index2]);
            this.EffectActGameObject[index1][index2] = (GameObject) null;
            this.EffectActTransform[index1][index2] = (Transform) null;
            this.EffectActParticle[index1][index2] = (ParticleSystem) null;
            this.EffectActParticle_one[index1][index2] = (ParticleSystem) null;
            this.EffectActParticle_two[index1][index2] = (ParticleSystem) null;
            this.EffectActParticle_three[index1][index2] = (ParticleSystem) null;
          }
        }
        this.EffectActGameObject[index1] = (GameObject[]) null;
        this.EffectActTransform[index1] = (Transform[]) null;
        this.EffectActParticle[index1] = (ParticleSystem[]) null;
        this.EffectActParticle_one[index1] = (ParticleSystem[]) null;
        this.EffectActParticle_two[index1] = (ParticleSystem[]) null;
        this.EffectActParticle_three[index1] = (ParticleSystem[]) null;
      }
    }
    this.EffectActGameObject = (GameObject[][]) null;
    this.EffectActTransform = (Transform[][]) null;
    this.EffectActParticle = (ParticleSystem[][]) null;
    this.EffectActParticle_one = (ParticleSystem[][]) null;
    this.EffectActParticle_two = (ParticleSystem[][]) null;
    this.EffectActParticle_three = (ParticleSystem[][]) null;
    if (this.EffectActGameObjectPools != null)
    {
      for (int index3 = 0; index3 < this.EffectActGameObjectPools.Length; ++index3)
      {
        if (this.EffectActGameObjectPools[index3] != null)
        {
          for (int index4 = 0; index4 < this.EffectActGameObjectPools[index3].Length; ++index4)
          {
            if ((UnityEngine.Object) this.EffectActGameObjectPools[index3][index4] != (UnityEngine.Object) null)
            {
              ParticleManager.Instance.DeSpawn(this.EffectActGameObjectPools[index3][index4]);
              this.EffectActGameObjectPools[index3][index4] = (GameObject) null;
              this.EffectActTransformPools[index3][index4] = (Transform) null;
              this.EffectActParticlePools[index3][index4] = (ParticleSystem) null;
              this.EffectActParticlePools_one[index3][index4] = (ParticleSystem) null;
              this.EffectActParticlePools_two[index3][index4] = (ParticleSystem) null;
              this.EffectActParticlePools_three[index3][index4] = (ParticleSystem) null;
            }
          }
          this.EffectActGameObjectPools[index3] = (GameObject[]) null;
          this.EffectActTransformPools[index3] = (Transform[]) null;
          this.EffectActParticlePools[index3] = (ParticleSystem[]) null;
          this.EffectActParticlePools_one[index3] = (ParticleSystem[]) null;
          this.EffectActParticlePools_two[index3] = (ParticleSystem[]) null;
          this.EffectActParticlePools_three[index3] = (ParticleSystem[]) null;
        }
      }
    }
    this.EffectActGameObjectPools = (GameObject[][]) null;
    this.EffectActTransformPools = (Transform[][]) null;
    this.EffectActParticlePools = (ParticleSystem[][]) null;
    this.EffectActParticlePools_one = (ParticleSystem[][]) null;
    this.EffectActParticlePools_two = (ParticleSystem[][]) null;
    this.EffectActParticlePools_three = (ParticleSystem[][]) null;
    if (this.ActpoolCounter == null)
      return;
    Array.Clear((Array) this.ActpoolCounter, 0, this.ActpoolCounter.Length);
  }

  public void IniEffect(int rowNum, int colNum, float tileBaseScale)
  {
    this.EffectActGameObject = new GameObject[colNum][];
    this.EffectActTransform = new Transform[colNum][];
    this.EffectActParticle = new ParticleSystem[colNum][];
    this.EffectActParticle_one = new ParticleSystem[colNum][];
    this.EffectActParticle_two = new ParticleSystem[colNum][];
    this.EffectActParticle_three = new ParticleSystem[colNum][];
    for (int index = 0; index < colNum; ++index)
    {
      this.EffectActGameObject[index] = new GameObject[rowNum];
      this.EffectActTransform[index] = new Transform[rowNum];
      this.EffectActParticle[index] = new ParticleSystem[rowNum];
      this.EffectActParticle_one[index] = new ParticleSystem[rowNum];
      this.EffectActParticle_two[index] = new ParticleSystem[rowNum];
      this.EffectActParticle_three[index] = new ParticleSystem[rowNum];
      Array.Clear((Array) this.EffectActGameObject[index], 0, this.EffectActGameObject[index].Length);
      Array.Clear((Array) this.EffectActTransform[index], 0, this.EffectActTransform[index].Length);
      Array.Clear((Array) this.EffectActParticle[index], 0, this.EffectActParticle[index].Length);
      Array.Clear((Array) this.EffectActParticle_one[index], 0, this.EffectActParticle_one[index].Length);
      Array.Clear((Array) this.EffectActParticle_two[index], 0, this.EffectActParticle_two[index].Length);
      Array.Clear((Array) this.EffectActParticle_three[index], 0, this.EffectActParticle_three[index].Length);
    }
    this.EffectActGameObjectPools = new GameObject[rowNum << 1][];
    this.EffectActTransformPools = new Transform[rowNum << 1][];
    this.EffectActParticlePools = new ParticleSystem[rowNum << 1][];
    this.EffectActParticlePools_one = new ParticleSystem[rowNum << 1][];
    this.EffectActParticlePools_two = new ParticleSystem[rowNum << 1][];
    this.EffectActParticlePools_three = new ParticleSystem[rowNum << 1][];
    this.ActpoolCounter = new int[rowNum << 1];
    Array.Clear((Array) this.EffectActGameObjectPools, 0, this.EffectActGameObjectPools.Length);
    Array.Clear((Array) this.EffectActTransformPools, 0, this.EffectActTransformPools.Length);
    Array.Clear((Array) this.EffectActParticlePools, 0, this.EffectActParticlePools.Length);
    Array.Clear((Array) this.EffectActParticlePools_one, 0, this.EffectActParticlePools_one.Length);
    Array.Clear((Array) this.EffectActParticlePools_two, 0, this.EffectActParticlePools_two.Length);
    Array.Clear((Array) this.EffectActParticlePools_three, 0, this.EffectActParticlePools_three.Length);
    for (int index = 0; index < this.ActpoolCounter.Length; ++index)
      this.ActpoolCounter[index] = -1;
    this.EffectActGameObjectPools[0] = new GameObject[colNum >> 1];
    this.EffectActTransformPools[0] = new Transform[colNum >> 1];
    this.EffectActParticlePools[0] = new ParticleSystem[colNum >> 1];
    this.EffectActParticlePools_one[0] = new ParticleSystem[colNum >> 1];
    this.EffectActParticlePools_two[0] = new ParticleSystem[colNum >> 1];
    this.EffectActParticlePools_three[0] = new ParticleSystem[colNum >> 1];
    for (int index = 0; index < this.EffectActGameObjectPools[0].Length; ++index)
    {
      this.EffectActGameObjectPools[0][index] = ParticleManager.Instance.Spawn((ushort) 60201, (Transform) null, Vector3.zero, 1f, false, false);
      this.EffectActTransformPools[0][index] = this.EffectActGameObjectPools[0][index].transform;
      this.EffectActTransformPools[0][index].SetParent(this.ActLayoutTransform);
      this.EffectActTransformPools[0][index].localPosition = this.inipos;
      this.EffectActParticlePools[0][index] = this.EffectActTransformPools[0][index].GetChild(0).GetComponent<ParticleSystem>();
      this.EffectActParticlePools_one[0][index] = this.EffectActTransformPools[0][index].GetChild(1).GetComponent<ParticleSystem>();
      this.EffectActParticlePools_two[0][index] = this.EffectActTransformPools[0][index].GetChild(2).GetComponent<ParticleSystem>();
      this.EffectActParticlePools_three[0][index] = this.EffectActTransformPools[0][index].GetChild(3).GetComponent<ParticleSystem>();
    }
    this.ActstartSize = this.EffectActParticlePools[0][0].startSize;
    this.Actlifetime = this.EffectActParticlePools[0][0].startLifetime;
    this.ActstartSize_one = this.EffectActParticlePools_one[0][0].startSize;
    this.Actlifetime_one = this.EffectActParticlePools_one[0][0].startLifetime;
    this.ActstartSize_two = this.EffectActParticlePools_two[0][0].startSize;
    this.Actlifetime_two = this.EffectActParticlePools_two[0][0].startLifetime;
    this.ActstartSize_three = this.EffectActParticlePools_three[0][0].startSize;
    this.Actlifetime_three = this.EffectActParticlePools_three[0][0].startLifetime;
    this.ActpoolCounter[0] = colNum >> 1;
    this.ActpoolsCounter = 1;
  }

  public void setEffect(byte effectflag, int row, int col, Vector2 pos, byte effecttype = 0)
  {
    float x = this.TotalityGroup.localScale.x;
    if (((int) effectflag & 1) == 0)
    {
      if (!((UnityEngine.Object) this.EffectActGameObject[col][row] != (UnityEngine.Object) null))
        return;
      this.EffectActGameObject[col][row].SetActive(false);
      for (int index = 0; index < this.ActpoolsCounter; ++index)
      {
        if (this.ActpoolCounter[index] < this.EffectActGameObjectPools[index].Length)
        {
          this.EffectActGameObjectPools[index][this.ActpoolCounter[index]] = this.EffectActGameObject[col][row];
          this.EffectActTransformPools[index][this.ActpoolCounter[index]] = this.EffectActTransform[col][row];
          this.EffectActParticlePools[index][this.ActpoolCounter[index]] = this.EffectActParticle[col][row];
          this.EffectActParticlePools_one[index][this.ActpoolCounter[index]] = this.EffectActParticle_one[col][row];
          this.EffectActParticlePools_two[index][this.ActpoolCounter[index]] = this.EffectActParticle_two[col][row];
          this.EffectActParticlePools_three[index][this.ActpoolCounter[index]] = this.EffectActParticle_three[col][row];
          this.EffectActGameObject[col][row] = (GameObject) null;
          this.EffectActTransform[col][row] = (Transform) null;
          this.EffectActParticle[col][row] = (ParticleSystem) null;
          this.EffectActParticle_one[col][row] = (ParticleSystem) null;
          this.EffectActParticle_two[col][row] = (ParticleSystem) null;
          this.EffectActParticle_three[col][row] = (ParticleSystem) null;
          ++this.ActpoolCounter[index];
          break;
        }
      }
    }
    else
    {
      if ((UnityEngine.Object) this.EffectActGameObject[col][row] == (UnityEngine.Object) null)
      {
        int index1;
        for (index1 = 0; index1 < this.ActpoolsCounter; ++index1)
        {
          if (this.ActpoolCounter[index1] > 0)
          {
            --this.ActpoolCounter[index1];
            this.EffectActGameObject[col][row] = this.EffectActGameObjectPools[index1][this.ActpoolCounter[index1]];
            this.EffectActTransform[col][row] = this.EffectActTransformPools[index1][this.ActpoolCounter[index1]];
            this.EffectActParticle[col][row] = this.EffectActParticlePools[index1][this.ActpoolCounter[index1]];
            this.EffectActParticle_one[col][row] = this.EffectActParticlePools_one[index1][this.ActpoolCounter[index1]];
            this.EffectActParticle_two[col][row] = this.EffectActParticlePools_two[index1][this.ActpoolCounter[index1]];
            this.EffectActParticle_three[col][row] = this.EffectActParticlePools_three[index1][this.ActpoolCounter[index1]];
            this.EffectActGameObjectPools[index1][this.ActpoolCounter[index1]] = (GameObject) null;
            this.EffectActTransformPools[index1][this.ActpoolCounter[index1]] = (Transform) null;
            this.EffectActParticlePools[index1][this.ActpoolCounter[index1]] = (ParticleSystem) null;
            this.EffectActParticlePools_one[index1][this.ActpoolCounter[index1]] = (ParticleSystem) null;
            this.EffectActParticlePools_two[index1][this.ActpoolCounter[index1]] = (ParticleSystem) null;
            this.EffectActParticlePools_three[index1][this.ActpoolCounter[index1]] = (ParticleSystem) null;
            this.setEffect(row, col, DataManager.MapDataController.zoomSize);
            break;
          }
        }
        if (index1 == this.ActpoolsCounter)
        {
          this.EffectActGameObjectPools[index1] = new GameObject[this.EffectActGameObjectPools[0].Length];
          this.EffectActTransformPools[index1] = new Transform[this.EffectActTransformPools[0].Length];
          this.EffectActParticlePools[index1] = new ParticleSystem[this.EffectActParticlePools[0].Length];
          this.EffectActParticlePools_one[index1] = new ParticleSystem[this.EffectActParticlePools_one[0].Length];
          this.EffectActParticlePools_two[index1] = new ParticleSystem[this.EffectActParticlePools_two[0].Length];
          this.EffectActParticlePools_three[index1] = new ParticleSystem[this.EffectActParticlePools_three[0].Length];
          for (int index2 = 0; index2 < this.EffectActGameObjectPools[index1].Length; ++index2)
          {
            this.EffectActGameObjectPools[index1][index2] = ParticleManager.Instance.Spawn((ushort) 60201, (Transform) null, Vector3.zero, 1f, false, false);
            this.EffectActTransformPools[index1][index2] = this.EffectActGameObjectPools[index1][index2].transform;
            this.EffectActTransformPools[index1][index2].SetParent(this.ActLayoutTransform, false);
            this.EffectActTransformPools[index1][index2].localPosition = this.inipos;
            this.EffectActParticlePools[index1][index2] = this.EffectActTransformPools[index1][index2].GetChild(0).GetComponent<ParticleSystem>();
            this.EffectActParticlePools_one[index1][index2] = this.EffectActTransformPools[index1][index2].GetChild(1).GetComponent<ParticleSystem>();
            this.EffectActParticlePools_two[index1][index2] = this.EffectActTransformPools[index1][index2].GetChild(2).GetComponent<ParticleSystem>();
            this.EffectActParticlePools_three[index1][index2] = this.EffectActTransformPools[index1][index2].GetChild(3).GetComponent<ParticleSystem>();
          }
          ++this.ActpoolsCounter;
          this.ActpoolCounter[index1] = this.EffectActGameObjectPools[index1].Length;
          --this.ActpoolCounter[index1];
          this.EffectActGameObject[col][row] = this.EffectActGameObjectPools[index1][this.ActpoolCounter[index1]];
          this.EffectActTransform[col][row] = this.EffectActTransformPools[index1][this.ActpoolCounter[index1]];
          this.EffectActParticle[col][row] = this.EffectActParticlePools[index1][this.ActpoolCounter[index1]];
          this.EffectActParticle_one[col][row] = this.EffectActParticlePools_one[index1][this.ActpoolCounter[index1]];
          this.EffectActParticle_two[col][row] = this.EffectActParticlePools_two[index1][this.ActpoolCounter[index1]];
          this.EffectActParticle_three[col][row] = this.EffectActParticlePools_three[index1][this.ActpoolCounter[index1]];
          this.EffectActParticle[col][row].startSize = this.ActstartSize * x;
          this.EffectActParticle[col][row].startLifetime = this.Actlifetime * x;
          this.EffectActParticle_one[col][row].startSize = this.ActstartSize_one * x;
          this.EffectActParticle_one[col][row].startLifetime = this.Actlifetime_one * x;
          this.EffectActParticle_two[col][row].startSize = this.ActstartSize_two * x;
          this.EffectActParticle_two[col][row].startLifetime = this.Actlifetime_two * x;
          this.EffectActParticle_three[col][row].startSize = this.ActstartSize_three * x;
          this.EffectActParticle_three[col][row].startLifetime = this.Actlifetime_three * x;
          this.EffectActGameObjectPools[index1][this.ActpoolCounter[index1]] = (GameObject) null;
          this.EffectActTransformPools[index1][this.ActpoolCounter[index1]] = (Transform) null;
          this.EffectActParticlePools[index1][this.ActpoolCounter[index1]] = (ParticleSystem) null;
          this.EffectActParticlePools_one[index1][this.ActpoolCounter[index1]] = (ParticleSystem) null;
          this.EffectActParticlePools_two[index1][this.ActpoolCounter[index1]] = (ParticleSystem) null;
          this.EffectActParticlePools_three[index1][this.ActpoolCounter[index1]] = (ParticleSystem) null;
        }
        this.EffectActGameObject[col][row].SetActive(true);
      }
      this.EffectActTransform[col][row].localPosition = (Vector3) pos;
    }
  }

  public void setEffect(int row, int col, Vector2 pos)
  {
    Vector3 vector3 = new Vector3(pos.x, pos.y, 0.0f);
    if (!((UnityEngine.Object) this.EffectActGameObject[col][row] != (UnityEngine.Object) null))
      return;
    this.EffectActTransform[col][row].localPosition = vector3;
  }

  public void setEffect(int row, int col, float scale)
  {
    if (!((UnityEngine.Object) this.EffectActGameObject[col][row] != (UnityEngine.Object) null))
      return;
    float startSize1 = this.EffectActParticle[col][row].startSize;
    float startLifetime1 = this.EffectActParticle[col][row].startLifetime;
    this.EffectActParticle[col][row].startSize = this.ActstartSize * scale;
    this.EffectActParticle[col][row].startLifetime = this.Actlifetime * scale;
    float num1 = this.EffectActParticle[col][row].startSize / startSize1;
    float num2 = this.EffectActParticle[col][row].startLifetime / startLifetime1;
    int particles1 = this.EffectActParticle[col][row].GetParticles(this.particles);
    for (int index = 0; index < particles1; ++index)
    {
      this.particles[index].size *= num1;
      this.particles[index].lifetime *= num2;
    }
    this.EffectActParticle[col][row].SetParticles(this.particles, particles1);
    float startSize2 = this.EffectActParticle_one[col][row].startSize;
    float startLifetime2 = this.EffectActParticle_one[col][row].startLifetime;
    this.EffectActParticle_one[col][row].startSize = this.ActstartSize_one * scale;
    this.EffectActParticle_one[col][row].startLifetime = this.Actlifetime_one * scale;
    float num3 = this.EffectActParticle_one[col][row].startSize / startSize2;
    float num4 = this.EffectActParticle_one[col][row].startLifetime / startLifetime2;
    int particles2 = this.EffectActParticle_one[col][row].GetParticles(this.particles);
    for (int index = 0; index < particles2; ++index)
    {
      this.particles[index].size *= num3;
      this.particles[index].lifetime *= num4;
    }
    this.EffectActParticle_one[col][row].SetParticles(this.particles, particles2);
    float startSize3 = this.EffectActParticle_two[col][row].startSize;
    float startLifetime3 = this.EffectActParticle_two[col][row].startLifetime;
    this.EffectActParticle_two[col][row].startSize = this.ActstartSize_two * scale;
    this.EffectActParticle_two[col][row].startLifetime = this.Actlifetime_two * scale;
    float num5 = this.EffectActParticle_two[col][row].startSize / startSize3;
    float num6 = this.EffectActParticle_two[col][row].startLifetime / startLifetime3;
    int particles3 = this.EffectActParticle_two[col][row].GetParticles(this.particles);
    for (int index = 0; index < particles3; ++index)
    {
      this.particles[index].size *= num5;
      this.particles[index].lifetime *= num6;
    }
    this.EffectActParticle_two[col][row].SetParticles(this.particles, particles3);
    float startSize4 = this.EffectActParticle_three[col][row].startSize;
    float startLifetime4 = this.EffectActParticle_three[col][row].startLifetime;
    this.EffectActParticle_three[col][row].startSize = this.ActstartSize_three * scale;
    this.EffectActParticle_three[col][row].startLifetime = this.Actlifetime_three * scale;
    float num7 = this.EffectActParticle_three[col][row].startSize / startSize4;
    float num8 = this.EffectActParticle_three[col][row].startLifetime / startLifetime4;
    int particles4 = this.EffectActParticle_three[col][row].GetParticles(this.particles);
    for (int index = 0; index < particles4; ++index)
    {
      this.particles[index].size *= num7;
      this.particles[index].lifetime *= num8;
    }
    this.EffectActParticle_three[col][row].SetParticles(this.particles, particles4);
  }
}
