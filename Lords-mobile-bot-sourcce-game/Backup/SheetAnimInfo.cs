// Decompiled with JetBrains decompiler
// Type: SheetAnimInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;

#nullable disable
public class SheetAnimInfo
{
  public const float SAMPLE_RATE = 0.025f;
  public const int MAX_ANIM = 64;
  public const int MAX_MESH = 16;
  public const int MAX_ANIMFO = 4;
  public const int MAX_CASTLEGATE = 4;
  private const int SHARE_TEX_COUNT = 3;
  public static SheetAnimInfo m_Self = (SheetAnimInfo) null;
  public Dictionary<uint, sAnimInfo> m_AnimList = new Dictionary<uint, sAnimInfo>(64);
  public Dictionary<uint, sAnimInfo> m_AnimFOList = new Dictionary<uint, sAnimInfo>(4);
  public Dictionary<uint, sAnimInfo> m_CastleGateList = new Dictionary<uint, sAnimInfo>(4);
  public Dictionary<ushort, ushort> m_MeshList = new Dictionary<ushort, ushort>(24);
  public StringBuilder StringInstance = new StringBuilder(256);
  public Material nonBatching_sharedMat;
  private Material[] sharedMat = new Material[3];
  private AssetBundle[] m_TexBundle = new AssetBundle[3];
  private static readonly string[] TexBundleName = new string[3]
  {
    "Role/soldiers_tex",
    "Role/soldiers_tex_2",
    "Role/soldiers_tex_3"
  };

  private SheetAnimInfo()
  {
  }

  public static SheetAnimInfo Instance
  {
    get
    {
      if (SheetAnimInfo.m_Self == null)
        SheetAnimInfo.m_Self = new SheetAnimInfo();
      return SheetAnimInfo.m_Self;
    }
  }

  public void DestroyAllMesh()
  {
    this.m_AnimList.Clear();
    this.m_AnimFOList.Clear();
    this.m_MeshList.Clear();
    if ((bool) (Object) this.nonBatching_sharedMat)
    {
      Object.Destroy((Object) this.nonBatching_sharedMat);
      this.nonBatching_sharedMat = (Material) null;
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.sharedMat[index] != (Object) null)
      {
        if ((Object) this.sharedMat[index].mainTexture != (Object) null)
        {
          Object.DestroyImmediate((Object) this.sharedMat[index].mainTexture, true);
          this.sharedMat[index].mainTexture = (Texture) null;
        }
        Object.Destroy((Object) this.sharedMat[index]);
        this.sharedMat[index] = (Material) null;
      }
      if ((bool) (Object) this.m_TexBundle[index])
      {
        this.m_TexBundle[index].Unload(true);
        this.m_TexBundle[index] = (AssetBundle) null;
      }
    }
    Resources.UnloadUnusedAssets();
  }

  public void createMesh(ushort heroID)
  {
    if (this.m_MeshList.ContainsKey(heroID))
      return;
    this.StringInstance.Length = 0;
    this.StringInstance.AppendFormat("Role/soldier_{0:000}", (object) heroID);
    AssetBundle assetBundle = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
    GameObject SkeletalGO = Object.Instantiate(assetBundle.mainAsset) as GameObject;
    SkinnedMeshRenderer componentInChildren = SkeletalGO.GetComponentInChildren<SkinnedMeshRenderer>();
    Animation component = SkeletalGO.GetComponent<Animation>();
    if ((Object) this.sharedMat[0] == (Object) null)
    {
      Shader shader = (Shader) null;
      AssetManager instance = AssetManager.Instance;
      int length = instance.Shaders.Length;
      for (int index = 0; index < length; ++index)
      {
        if (instance.Shaders[index].name == "zTWRD2 Shaders/Model/Unlit (Supports Lightmap)")
        {
          shader = (Shader) instance.Shaders[index];
          break;
        }
      }
      for (int index = 0; index < 3; ++index)
      {
        this.sharedMat[index] = new Material(shader);
        this.m_TexBundle[index] = AssetManager.GetAssetBundle(SheetAnimInfo.TexBundleName[index], 0L);
        Texture mainAsset = this.m_TexBundle[index].mainAsset as Texture;
        this.sharedMat[index].mainTexture = mainAsset;
      }
      this.nonBatching_sharedMat = new Material(shader);
      this.nonBatching_sharedMat.mainTexture = this.sharedMat[0].mainTexture;
    }
    int num = 0;
    for (int index = 0; index < 5; ++index)
    {
      AnimationClip clip = component.GetClip(((ESheetMeshAnim) index).ToString());
      if ((bool) (Object) clip)
      {
        uint key = (uint) (index << 16) | (uint) heroID;
        num = this.SampleStaticMeshToList(SkeletalGO, componentInChildren, clip, this.m_AnimList, key);
      }
    }
    Debug.Log((object) (heroID.ToString() + " = " + num.ToString()));
    this.m_MeshList.Add(heroID, (ushort) 1);
    Object.Destroy((Object) SkeletalGO);
    assetBundle.Unload(true);
  }

  public static Material GetMaterial(ESheetMeshTexKind kind)
  {
    return kind < ESheetMeshTexKind.MAX ? SheetAnimInfo.Instance.sharedMat[(int) kind] : (Material) null;
  }

  public void createAnimFO(ushort modelID)
  {
    if (this.m_MeshList.ContainsKey((ushort) ((uint) modelID * 10U)))
      return;
    this.StringInstance.Length = 0;
    this.StringInstance.AppendFormat("Role/BrokenFO_{0:000}", (object) modelID);
    AssetBundle assetBundle = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
    GameObject SkeletalGO = Object.Instantiate(assetBundle.mainAsset) as GameObject;
    SkinnedMeshRenderer componentInChildren = SkeletalGO.GetComponentInChildren<SkinnedMeshRenderer>();
    Animation component = SkeletalGO.GetComponent<Animation>();
    int num = 0;
    AnimationClip clip = component.GetClip("attack");
    if ((bool) (Object) clip)
      num = this.SampleStaticMeshToList(SkeletalGO, componentInChildren, clip, this.m_AnimFOList, (uint) modelID);
    Debug.Log((object) (modelID.ToString() + " = " + num.ToString()));
    this.m_MeshList.Add((ushort) ((uint) modelID * 10U), (ushort) 1);
    Object.Destroy((Object) SkeletalGO);
    assetBundle.Unload(true);
  }

  private int SampleStaticMeshToList(
    GameObject SkeletalGO,
    SkinnedMeshRenderer smr,
    AnimationClip ac,
    Dictionary<uint, sAnimInfo> list,
    uint key)
  {
    float length1 = ac.length;
    float num1 = 40f;
    int length2 = (int) ((double) ((float) ((int) ((double) length1 * 30.0 + 1.0) - 1) * 0.1f) * (double) num1 + 1.0);
    float num2 = length1 / (float) length2;
    Mesh[] meshArray = new Mesh[length2];
    for (int index = 0; index < length2; ++index)
    {
      SkeletalGO.SampleAnimation(ac, (float) index * num2);
      Mesh mesh = new Mesh();
      smr.BakeMesh(mesh);
      mesh.Optimize();
      meshArray[index] = mesh;
    }
    list.Add(key, new sAnimInfo()
    {
      animLength = (float) (length2 - 1) * 0.025f,
      keyframeCount = length2,
      animMesh = meshArray
    });
    return length2 > 0 && (Object) meshArray[0] != (Object) null ? meshArray[0].vertexCount : 0;
  }

  public void createCastleGate(ushort modelID)
  {
    if (this.m_MeshList.ContainsKey((ushort) ((uint) modelID * 100U)))
      return;
    this.StringInstance.Length = 0;
    this.StringInstance.AppendFormat("Role/CastleGate_{0:00}", (object) modelID);
    AssetBundle assetBundle = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
    GameObject gameObject = Object.Instantiate(assetBundle.mainAsset) as GameObject;
    Mesh[] meshArray = new Mesh[1]
    {
      gameObject.GetComponent<MeshFilter>().mesh
    };
    this.m_CastleGateList.Add((uint) modelID, new sAnimInfo()
    {
      animLength = 0.0f,
      keyframeCount = 1,
      animMesh = meshArray
    });
    this.m_MeshList.Add((ushort) ((uint) modelID * 100U), (ushort) 1);
    Object.Destroy((Object) gameObject);
    assetBundle.Unload(true);
  }

  public sAnimInfo getAnimInfo(ushort heroID, ushort animIdx)
  {
    return this.m_AnimList[(uint) animIdx << 16 | (uint) heroID];
  }

  public sAnimInfo getAnimFOInfo(ushort modelID) => this.m_AnimFOList[(uint) modelID];

  public sAnimInfo getBuildMesh(ushort modelID) => this.m_CastleGateList[(uint) modelID];

  public ushort getMeshInfo(ushort heroID) => this.m_MeshList[heroID];

  public bool containMesh(ushort modelID) => this.m_MeshList.ContainsKey(modelID);
}
