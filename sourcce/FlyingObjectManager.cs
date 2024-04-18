// Decompiled with JetBrains decompiler
// Type: FlyingObjectManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;

#nullable disable
public class FlyingObjectManager
{
  public string[] BUNDLE_NAME = new string[8]
  {
    "FO_Stone",
    "FO_Arrow",
    "FO_Bomb",
    "FO_FireStone",
    string.Empty,
    "FO_TArrow",
    "FO_CLV1_Arrow",
    string.Empty
  };
  public ushort[] FO_OBJKIND = new ushort[8]
  {
    (ushort) 0,
    (ushort) 0,
    (ushort) 0,
    (ushort) 0,
    (ushort) 2016,
    (ushort) 0,
    (ushort) 0,
    (ushort) 0
  };
  public Transform renderRoot;
  public int[] MaxCount = new int[8];
  private List<FlyingObject>[] freeList = new List<FlyingObject>[8];
  private AssetBundle[] bundleList = new AssetBundle[8];
  public List<FlyingObject> workingList;
  public StringBuilder StringInstance = new StringBuilder(128);
  public WarParticleManager particleMgr;

  private FlyingObjectManager()
  {
  }

  public FlyingObjectManager(Transform root, ushort[] count, WarParticleManager _particleMgr)
  {
    int ambient = 2 + LightmapManager.Instance.SceneLightmapSize;
    this.renderRoot = root;
    this.particleMgr = _particleMgr;
    int capacity = 0;
    for (int index = 0; index < 8; ++index)
    {
      this.MaxCount[index] = (int) count[index];
      this.freeList[index] = new List<FlyingObject>(this.MaxCount[index]);
      this.initFlyingObject((FOKind) index, this.FO_OBJKIND[index], this.BUNDLE_NAME[index], this.MaxCount[index], ambient);
      capacity += this.MaxCount[index];
    }
    this.workingList = new List<FlyingObject>(capacity);
  }

  private void initFlyingObject(
    FOKind foKind,
    ushort objKind,
    string filename,
    int count,
    int ambient)
  {
    if (count <= 0)
      return;
    GameObject original = (GameObject) null;
    AssetBundle assetBundle = (AssetBundle) null;
    if (objKind == (ushort) 0)
    {
      if (filename != string.Empty)
      {
        this.StringInstance.Length = 0;
        this.StringInstance.AppendFormat("Role/{0}", (object) filename);
        assetBundle = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
        original = assetBundle.mainAsset as GameObject;
        MeshRenderer component = original.GetComponent<MeshRenderer>();
        component.material = SheetAnimInfo.GetMaterial(ESheetMeshTexKind.WAR_BLUE);
        component.renderer.lightmapIndex = ambient;
        original.GetComponent<MeshFilter>();
      }
    }
    else
      original = this.particleMgr.SpawnWithoutManager(objKind);
    List<FlyingObject> free = this.freeList[(int) foKind];
    for (int index = 0; index < count; ++index)
    {
      GameObject gameObject = (GameObject) null;
      if ((Object) original != (Object) null)
      {
        gameObject = Object.Instantiate((Object) original) as GameObject;
        gameObject.transform.position = Vector3.zero;
        gameObject.transform.parent = this.renderRoot;
        gameObject.SetActive(false);
      }
      free.Add(new FlyingObject()
      {
        SourceObj = gameObject,
        foKind = foKind
      });
    }
    this.bundleList[(int) foKind] = assetBundle;
  }

  public void Destroy()
  {
    for (int index = 0; index < this.workingList.Count; ++index)
      this.workingList[index].Destroy();
    this.workingList.Clear();
    for (int index1 = 0; index1 < 8; ++index1)
    {
      List<FlyingObject> free = this.freeList[index1];
      for (int index2 = 0; index2 < free.Count; ++index2)
        free[index2].Destroy();
      free.Clear();
      if ((Object) this.bundleList[index1] != (Object) null)
      {
        this.bundleList[index1].Unload(true);
        this.bundleList[index1] = (AssetBundle) null;
      }
    }
  }

  public FlyingObject addFlyingObject(
    FOKind kind,
    Vector3 begin,
    Transform end,
    float ms,
    Vector3 offset,
    Transform scaleRoot = null,
    ChaseType CurveType = ChaseType.CurveA,
    GameObject particle = null)
  {
    FlyingObject flyingObject = (FlyingObject) null;
    List<FlyingObject> free = this.freeList[(int) kind];
    if (free.Count > 0)
    {
      flyingObject = free[free.Count - 1];
      free.RemoveAt(free.Count - 1);
    }
    if (kind == FOKind.LightBall)
      scaleRoot = (Transform) null;
    if (flyingObject != null)
    {
      if ((Object) flyingObject.SourceObj != (Object) null)
        flyingObject.SourceObj.SetActive(true);
      else if ((Object) particle != (Object) null)
      {
        particle.transform.position = Vector3.zero;
        particle.transform.parent = this.renderRoot;
        flyingObject.SourceObj = particle;
      }
      flyingObject.AddFlyingObject(begin, end, ms, offset, scaleRoot, CurveType);
      this.workingList.Add(flyingObject);
    }
    return flyingObject;
  }

  public void recoverSpecialArrow()
  {
    for (int index = this.workingList.Count - 1; index >= 0; --index)
    {
      FlyingObject working = this.workingList[index];
      if (!working.bMove && working.foKind == FOKind.CLv1_Arrow)
      {
        working.SourceObj.SetActive(false);
        this.freeList[(int) working.foKind].Add(working);
        this.workingList.RemoveAt(index);
      }
    }
  }

  public void Update(float deltaTime)
  {
    for (int index = this.workingList.Count - 1; index >= 0; --index)
    {
      FlyingObject working = this.workingList[index];
      if (working.bMove)
        working.Update(deltaTime);
      else if (working.foKind != FOKind.CLv1_Arrow)
      {
        if (working.foKind == FOKind.FreeParticle)
        {
          this.particleMgr.DeSpawn(working.SourceObj);
          working.SourceObj = (GameObject) null;
        }
        else
          working.SourceObj.SetActive(false);
        this.freeList[(int) working.foKind].Add(working);
        this.workingList.RemoveAt(index);
      }
      else
      {
        working.specialDelay += deltaTime;
        if ((double) working.specialDelay >= 1.5)
        {
          working.SourceObj.SetActive(false);
          this.freeList[(int) working.foKind].Add(working);
          this.workingList.RemoveAt(index);
        }
      }
    }
  }
}
