// Decompiled with JetBrains decompiler
// Type: SheetAnimMesh
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class SheetAnimMesh
{
  public const float TIMESTEP = 0.025f;
  public const float INVERSE_TIMESTEP = 40f;
  public int keyframeCount;
  public MeshFilter meshShower;
  protected float animLength;
  public int stepIndex;
  public float m_DeltaTime;
  public float fixedDeltaTime;
  public Mesh[] curAnimMesh;
  protected ESheetMeshAnim curAnim;
  public ushort m_ModelID;
  public Transform transform;
  public bool IsPlaying = true;
  public SAWrapMode playMode;
  protected Renderer meshRenderer;
  private GameObject MainObj;
  protected float time;
  protected float lastTime;
  public float speed = 1f;
  public SheetAnimMesh.AnimNotify animNotify;

  protected SheetAnimMesh()
  {
  }

  public SheetAnimMesh(EWarMeshKind meshKind, byte kind, byte tier, byte texNo = 0)
  {
    switch (meshKind)
    {
      case EWarMeshKind.SOLDIER:
        this.m_ModelID = texNo != (byte) 3 ? this.createActor(kind, tier, texNo) : this.createBuild(kind, tier);
        break;
      case EWarMeshKind.FO:
        this.m_ModelID = this.createFO(kind, tier);
        break;
    }
    this.stepIndex = 1;
    this.curAnim = ESheetMeshAnim.moving;
    if (meshKind == EWarMeshKind.SOLDIER && texNo != (byte) 3)
      this.PlayAnim(ESheetMeshAnim.idle);
    else
      this.IsPlaying = false;
  }

  public GameObject gameObject
  {
    get => !(bool) (Object) this.transform ? (GameObject) null : this.transform.gameObject;
  }

  private Material TexNoToMat(int TexID)
  {
    return TexID >= 3 ? (Material) null : SheetAnimInfo.GetMaterial((ESheetMeshTexKind) TexID);
  }

  private ushort createActor(byte kind, byte tier, byte texNo)
  {
    ushort actor = (ushort) ((uint) kind * 10U + (uint) tier);
    if (!SheetAnimInfo.Instance.containMesh(actor))
      SheetAnimInfo.Instance.createMesh(actor);
    this.MainObj = new GameObject("AnimMesh");
    this.meshShower = this.MainObj.AddComponent<MeshFilter>();
    MeshRenderer meshRenderer = this.MainObj.AddComponent<MeshRenderer>();
    meshRenderer.castShadows = false;
    meshRenderer.receiveShadows = false;
    meshRenderer.sharedMaterial = this.TexNoToMat((int) texNo);
    this.meshRenderer = meshRenderer.renderer;
    this.transform = this.MainObj.transform;
    sAnimInfo animInfo = SheetAnimInfo.Instance.getAnimInfo(actor, (ushort) 0);
    if (animInfo.animMesh != null)
    {
      this.keyframeCount = animInfo.keyframeCount;
      this.curAnimMesh = animInfo.animMesh;
      this.animLength = animInfo.animLength;
    }
    return actor;
  }

  private ushort createFO(byte kind, byte tier)
  {
    ushort modelID = (ushort) ((uint) kind * 10U + (uint) tier);
    if (!SheetAnimInfo.Instance.containMesh((ushort) ((uint) modelID * 10U)))
      SheetAnimInfo.Instance.createAnimFO(modelID);
    this.MainObj = new GameObject("AnimFO");
    this.meshShower = this.MainObj.AddComponent<MeshFilter>();
    MeshRenderer meshRenderer = this.MainObj.AddComponent<MeshRenderer>();
    meshRenderer.castShadows = false;
    meshRenderer.receiveShadows = false;
    meshRenderer.sharedMaterial = SheetAnimInfo.GetMaterial(ESheetMeshTexKind.WAR_BLUE);
    this.meshRenderer = meshRenderer.renderer;
    this.transform = this.MainObj.transform;
    sAnimInfo animFoInfo = SheetAnimInfo.Instance.getAnimFOInfo(modelID);
    if (animFoInfo.animMesh != null)
    {
      this.keyframeCount = animFoInfo.keyframeCount;
      this.curAnimMesh = animFoInfo.animMesh;
      this.animLength = animFoInfo.animLength;
    }
    return modelID;
  }

  private ushort createBuild(byte kind, byte tier)
  {
    ushort modelID = (ushort) ((uint) kind * 10U + (uint) tier);
    if (!SheetAnimInfo.Instance.containMesh((ushort) ((uint) modelID * 10U)))
      SheetAnimInfo.Instance.createCastleGate(modelID);
    this.MainObj = new GameObject("Build");
    this.meshShower = this.MainObj.AddComponent<MeshFilter>();
    MeshRenderer meshRenderer = this.MainObj.AddComponent<MeshRenderer>();
    meshRenderer.castShadows = false;
    meshRenderer.receiveShadows = false;
    meshRenderer.sharedMaterial = SheetAnimInfo.GetMaterial(ESheetMeshTexKind.WAR_BLUE);
    this.meshRenderer = meshRenderer.renderer;
    this.transform = this.MainObj.transform;
    sAnimInfo buildMesh = SheetAnimInfo.Instance.getBuildMesh(modelID);
    if (buildMesh.animMesh != null)
    {
      this.keyframeCount = buildMesh.keyframeCount;
      this.curAnimMesh = buildMesh.animMesh;
      this.animLength = buildMesh.animLength;
    }
    return modelID;
  }

  public virtual bool PlayAnim(
    ESheetMeshAnim eAnim,
    SAWrapMode mode = SAWrapMode.Loop,
    bool bRandomStartPoint = true,
    bool bForceReset = false,
    bool bBrokenFO = false)
  {
    if (eAnim == this.curAnim && this.IsPlaying && this.playMode == mode)
    {
      if (!bForceReset)
        return false;
      this.m_DeltaTime = 0.0f;
      this.time = 0.0f;
      this.lastTime = 0.0f;
      this.stepIndex = 1;
      this.meshShower.mesh = this.curAnimMesh[0];
      return true;
    }
    sAnimInfo sAnimInfo = bBrokenFO ? SheetAnimInfo.Instance.getAnimFOInfo(this.m_ModelID) : SheetAnimInfo.Instance.getAnimInfo(this.m_ModelID, (ushort) eAnim);
    if (sAnimInfo.animMesh != null)
    {
      this.keyframeCount = sAnimInfo.keyframeCount;
      this.curAnimMesh = sAnimInfo.animMesh;
      this.animLength = sAnimInfo.animLength;
      this.m_DeltaTime = 0.0f;
      this.time = 0.0f;
      this.lastTime = 0.0f;
      this.stepIndex = !bRandomStartPoint ? 1 : Random.Range(1, (int) ((double) this.keyframeCount * 0.5));
      this.meshShower.mesh = this.curAnimMesh[0];
      this.curAnim = eAnim;
      this.playMode = mode;
      this.IsPlaying = true;
    }
    else
      this.IsPlaying = false;
    return true;
  }

  public virtual void Destroy()
  {
    this.transform = (Transform) null;
    this.curAnimMesh = (Mesh[]) null;
    if ((Object) this.meshShower != (Object) null)
      this.meshShower.mesh = (Mesh) null;
    if (!((Object) this.MainObj != (Object) null))
      return;
    Object.Destroy((Object) this.MainObj);
    this.MainObj = (GameObject) null;
  }

  public virtual void SampleAnimation(ESheetMeshAnim eAnim, float sampleTime)
  {
    this.PlayAnim(eAnim, bRandomStartPoint: false);
    this.IsPlaying = false;
    this.m_DeltaTime += sampleTime;
    this.lastTime = this.time;
    this.time += sampleTime;
    if ((double) this.m_DeltaTime < 0.02500000037252903)
      return;
    float num = (float) (((double) this.m_DeltaTime - 0.02500000037252903) * 40.0);
    this.stepIndex += (int) num + 1;
    if (this.stepIndex > this.keyframeCount)
    {
      this.stepIndex -= this.keyframeCount;
      if (this.stepIndex > this.keyframeCount)
      {
        this.stepIndex %= this.keyframeCount;
        this.stepIndex = Mathf.Max(this.stepIndex, 1);
      }
      this.time = 0.0f;
      this.lastTime = 0.0f;
    }
    this.fixedDeltaTime = this.m_DeltaTime - (float) (0.02500000037252903 + (double) (int) num * 0.02500000037252903);
    this.m_DeltaTime = this.fixedDeltaTime;
    this.meshShower.mesh = this.curAnimMesh[this.stepIndex - 1];
  }

  public virtual void Update(float delteTime)
  {
    if (!this.IsPlaying)
      return;
    delteTime *= this.speed;
    this.m_DeltaTime += delteTime;
    this.lastTime = this.time;
    this.time += delteTime;
    if ((double) this.m_DeltaTime < 0.02500000037252903)
      return;
    float num = (float) (((double) this.m_DeltaTime - 0.02500000037252903) * 40.0);
    this.stepIndex += (int) num + 1;
    if (this.stepIndex > this.keyframeCount)
    {
      if (this.playMode != SAWrapMode.Loop)
      {
        if (this.playMode == SAWrapMode.Once)
        {
          this.meshShower.mesh = this.curAnimMesh[this.keyframeCount - 1];
          this.IsPlaying = false;
          if (this.animNotify == null)
            return;
          this.animNotify(this.curAnim);
          return;
        }
        if (this.playMode == SAWrapMode.Default)
        {
          ESheetMeshAnim curAnim = this.curAnim;
          this.PlayAnim(ESheetMeshAnim.idle);
          if (this.animNotify != null)
            this.animNotify(curAnim);
        }
      }
      else
      {
        ESheetMeshAnim curAnim = this.curAnim;
        this.stepIndex -= this.keyframeCount;
        if (this.stepIndex > this.keyframeCount)
        {
          this.stepIndex %= this.keyframeCount;
          this.stepIndex = Mathf.Max(this.stepIndex, 1);
        }
        this.time = 0.0f;
        this.lastTime = 0.0f;
      }
    }
    this.fixedDeltaTime = this.m_DeltaTime - (float) (0.02500000037252903 + (double) (int) num * 0.02500000037252903);
    this.m_DeltaTime = this.fixedDeltaTime;
    this.meshShower.mesh = this.curAnimMesh[this.stepIndex - 1];
  }

  public delegate void AnimNotify(ESheetMeshAnim finishAnim);
}
