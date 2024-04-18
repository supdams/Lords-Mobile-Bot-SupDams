// Decompiled with JetBrains decompiler
// Type: GlobalProjectorManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class GlobalProjectorManager : MonoBehaviour
{
  private static string _GlobalProjectorShader = "Shader \"GlobalProjector/Multiply\" {\nProperties {\n_ShadowTex (\"Projector Texture\", 2D) = \"gray\" { TexGen ObjectLinear }\n}\nSubshader {\nTags { \"RenderType\"=\"Transparent\" \"Queue\"=\"Geometry+1\" }\nPass {\nZWrite Off\nZTest LEqual\nFog { Color (0, 0, 0) }\nAlphaTest Greater 0\nColorMask RGB\nBlend One One\nOffset -1, -1\nSetTexture [_ShadowTex] {\nMatrix [_GlobalProjector]\n}\n}\n}\n}\n";
  private ProjectorEyeTexture _Tex;
  public Material _ProjectorMaterial;
  private Matrix4x4 _ProjectorMatrix;
  private Matrix4x4 _BiasMatrix;
  private Matrix4x4 _ViewMatrix;
  private Matrix4x4 _BPV;
  private Matrix4x4 _ModelMatrix;
  private Matrix4x4 _FinalMatrix;
  private MaterialPropertyBlock _MBP;
  private int[] _ShadowResolutions = new int[5]
  {
    128,
    256,
    512,
    1024,
    2048
  };
  public static readonly string GlobalProjectorLayer = nameof (GlobalProjectorLayer);
  private static GlobalProjectorManager _Instance;
  private Vector3 _GlobalProjectionDir = new Vector3(0.0f, -1f, 0.0f);
  private int _GlobalShadowResolution = 3;
  private GlobalProjectorManager.ProjectionCulling _GlobalShadowCullingMode;
  private Camera _ProjectorCamera;
  private List<ShadowProjector> _ShadowProjectors;
  private List<ShadowReceiver> _ShadowReceivers;

  public static Vector3 GlobalProjectionDir
  {
    set
    {
      if (!(GlobalProjectorManager._Instance._GlobalProjectionDir != value))
        return;
      GlobalProjectorManager._Instance._GlobalProjectionDir = value;
      GlobalProjectorManager._Instance.OnProjectionDirChange();
    }
    get => GlobalProjectorManager._Instance._GlobalProjectionDir;
  }

  public static int GlobalShadowResolution
  {
    set
    {
      if (GlobalProjectorManager._Instance._GlobalShadowResolution == value)
        return;
      GlobalProjectorManager._Instance._GlobalShadowResolution = value;
      GlobalProjectorManager._Instance.OnShadowResolutionChange();
    }
    get => GlobalProjectorManager._Instance._GlobalShadowResolution;
  }

  public static GlobalProjectorManager.ProjectionCulling GlobalShadowCullingMode
  {
    set => GlobalProjectorManager._Instance._GlobalShadowCullingMode = value;
    get => GlobalProjectorManager._Instance._GlobalShadowCullingMode;
  }

  public static GlobalProjectorManager Get()
  {
    if ((Object) GlobalProjectorManager._Instance == (Object) null)
    {
      GlobalProjectorManager._Instance = new GameObject("_GlobalProjectorManager").AddComponent<GlobalProjectorManager>();
      GlobalProjectorManager._Instance.Initialize();
    }
    return GlobalProjectorManager._Instance;
  }

  private void Initialize()
  {
    this.gameObject.layer = LayerMask.NameToLayer(GlobalProjectorManager.GlobalProjectorLayer);
    this._ProjectorMaterial = new Material(GlobalProjectorManager._GlobalProjectorShader);
    this._ProjectorCamera = this.gameObject.AddComponent<Camera>();
    this._ProjectorCamera.clearFlags = CameraClearFlags.Color;
    this._ProjectorCamera.backgroundColor = (Color) new Color32((byte) 0, (byte) 0, (byte) 0, (byte) 0);
    this._ProjectorCamera.cullingMask = 1 << LayerMask.NameToLayer(GlobalProjectorManager.GlobalProjectorLayer);
    this._ProjectorCamera.orthographic = true;
    this._ProjectorCamera.nearClipPlane = -10000f;
    this._ProjectorCamera.farClipPlane = 10000f;
    this._ProjectorCamera.aspect = 1f;
    this._ProjectorCamera.depth = float.MinValue;
    this.CreateProjectorEyeTexture();
    this._BiasMatrix = new Matrix4x4();
    this._BiasMatrix.SetRow(0, new Vector4(0.5f, 0.0f, 0.0f, 0.5f));
    this._BiasMatrix.SetRow(1, new Vector4(0.0f, 0.5f, 0.0f, 0.5f));
    this._BiasMatrix.SetRow(2, new Vector4(0.0f, 0.0f, 0.5f, 0.5f));
    this._BiasMatrix.SetRow(3, new Vector4(0.0f, 0.0f, 0.0f, 1f));
    this._ProjectorMatrix = new Matrix4x4();
    this._MBP = new MaterialPropertyBlock();
    this._ShadowProjectors = new List<ShadowProjector>();
    this._ShadowReceivers = new List<ShadowReceiver>();
  }

  private void Awake() => this.OnProjectionDirChange();

  private void Start() => this.OnProjectionDirChange();

  private void OnDestroy() => GlobalProjectorManager._Instance = (GlobalProjectorManager) null;

  public static bool Exists() => (Object) GlobalProjectorManager._Instance != (Object) null;

  public void AddProjector(ShadowProjector projector)
  {
    if (this._ShadowProjectors.Contains(projector))
      return;
    this._ShadowProjectors.Add(projector);
    if (!(projector.GlobalProjectionDir != this._GlobalProjectionDir))
      return;
    GlobalProjectorManager.GlobalProjectionDir = projector.GlobalProjectionDir;
  }

  public void RemoveProjector(ShadowProjector projector)
  {
    if (!this._ShadowProjectors.Contains(projector))
      return;
    this._ShadowProjectors.Remove(projector);
  }

  public void AddReceiver(ShadowReceiver receiver)
  {
    if (this._ShadowReceivers.Contains(receiver))
      return;
    this._ShadowReceivers.Add(receiver);
  }

  public void RemoveReceiver(ShadowReceiver receiver)
  {
    if (!this._ShadowReceivers.Contains(receiver))
      return;
    this._ShadowReceivers.Remove(receiver);
  }

  private void OnProjectionDirChange()
  {
    if (!((Object) this.camera != (Object) null))
      return;
    this.camera.transform.rotation = Quaternion.LookRotation(this._GlobalProjectionDir);
  }

  private void OnShadowResolutionChange() => this.CreateProjectorEyeTexture();

  private void CreateProjectorEyeTexture()
  {
    this._Tex = new ProjectorEyeTexture(this._ProjectorCamera, this._ShadowResolutions[this._GlobalShadowResolution]);
    this._ProjectorMaterial.SetTexture("_ShadowTex", this._Tex.GetTexture());
  }

  private void CalculateShadowBounds()
  {
    Plane[] frustumPlanes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
    Vector2 vector2_1 = new Vector2(float.MaxValue, float.MinValue);
    Vector2 vector2_2 = new Vector2(float.MaxValue, float.MinValue);
    float num1 = 10f;
    bool flag = true;
    int num2 = 0;
    int num3 = 0;
    Bounds bounds = new Bounds();
    for (int index = 0; index < this._ShadowProjectors.Count; ++index)
    {
      ShadowProjector shadowProjector = this._ShadowProjectors[index];
      switch (this._GlobalShadowCullingMode)
      {
        case GlobalProjectorManager.ProjectionCulling.ProjectorBounds:
          if (!GeometryUtility.TestPlanesAABB(frustumPlanes, shadowProjector.GetBounds()))
          {
            ++num3;
            shadowProjector.SetVisible(false);
            break;
          }
          goto default;
        case GlobalProjectorManager.ProjectionCulling.ProjectionVolumeBounds:
          if (!this.IsProjectionVolumeVisible(frustumPlanes, shadowProjector))
          {
            ++num3;
            shadowProjector.SetVisible(false);
            break;
          }
          goto default;
        default:
          flag = false;
          shadowProjector.SetVisible(true);
          Vector2 viewportPoint = (Vector2) this.camera.WorldToViewportPoint(shadowProjector.GetShadowPos());
          if (num2 == 0)
            bounds = new Bounds(shadowProjector.GetShadowPos(), Vector3.zero);
          else
            bounds.Encapsulate(shadowProjector.GetShadowPos());
          if ((double) viewportPoint.x < (double) vector2_1.x)
            vector2_1.x = viewportPoint.x;
          if ((double) viewportPoint.x > (double) vector2_1.y)
            vector2_1.y = viewportPoint.x;
          if ((double) viewportPoint.y < (double) vector2_2.x)
            vector2_2.x = viewportPoint.y;
          if ((double) viewportPoint.y > (double) vector2_2.y)
            vector2_2.y = viewportPoint.y;
          float shadowWorldSize = shadowProjector.GetShadowWorldSize();
          if ((double) shadowWorldSize > (double) num1)
            num1 = shadowWorldSize;
          ++num2;
          break;
      }
    }
    if (flag)
      return;
    float num4 = this.camera.orthographicSize * 2f;
    float num5 = num1 / num4;
    this.camera.transform.position = bounds.center;
    this.camera.orthographicSize *= Mathf.Max((float) ((double) vector2_1[1] - (double) vector2_1[0] + (double) num5 * 2.0), (float) ((double) vector2_2[1] - (double) vector2_2[0] + (double) num5 * 2.0));
  }

  private bool IsProjectionVolumeVisible(Plane[] planes, ShadowProjector projector)
  {
    float num = 1000000f;
    Bounds bounds = new Bounds(projector.GetShadowPos() + GlobalProjectorManager.GlobalProjectionDir.normalized * (num * 0.5f), new Vector3(Mathf.Abs(GlobalProjectorManager.GlobalProjectionDir.normalized.x), Mathf.Abs(GlobalProjectorManager.GlobalProjectionDir.normalized.y), Mathf.Abs(GlobalProjectorManager.GlobalProjectionDir.normalized.z)) * num);
    float shadowWorldSize = projector.GetShadowWorldSize();
    bounds.Encapsulate(new Bounds(projector.GetShadowPos(), new Vector3(shadowWorldSize, shadowWorldSize, shadowWorldSize)));
    return GeometryUtility.TestPlanesAABB(planes, bounds);
  }

  private void LateUpdate()
  {
    if (this._ShadowProjectors.Count <= 0 || this._ShadowReceivers.Count <= 0)
      return;
    this.CalculateShadowBounds();
    float nearClipPlane = this.camera.nearClipPlane;
    float farClipPlane = this.camera.farClipPlane;
    float orthographicSize1 = this.camera.orthographicSize;
    float orthographicSize2 = this.camera.orthographicSize;
    this._ProjectorMatrix.SetRow(0, new Vector4(1f / orthographicSize1, 0.0f, 0.0f, 0.0f));
    this._ProjectorMatrix.SetRow(1, new Vector4(0.0f, 1f / orthographicSize2, 0.0f, 0.0f));
    this._ProjectorMatrix.SetRow(2, new Vector4(0.0f, 0.0f, (float) (-2.0 / ((double) farClipPlane - (double) nearClipPlane)), 0.0f));
    this._ProjectorMatrix.SetRow(3, new Vector4(0.0f, 0.0f, 0.0f, 1f));
    this._ViewMatrix = this.camera.transform.localToWorldMatrix.inverse;
    this._BPV = this._BiasMatrix * this._ProjectorMatrix * this._ViewMatrix;
    this.RenderShadows();
  }

  private void RenderShadows()
  {
    this._MBP.Clear();
    for (int index = 0; index < this._ShadowReceivers.Count; ++index)
    {
      this._ModelMatrix = this._ShadowReceivers[index].transform.localToWorldMatrix;
      this._FinalMatrix = this._BPV * this._ModelMatrix;
      this._MBP.AddMatrix("_GlobalProjector", this._FinalMatrix);
      Graphics.DrawMesh(this._ShadowReceivers[index].GetMesh(), this._ModelMatrix, this._ProjectorMaterial, LayerMask.NameToLayer("Default"), (Camera) null, 0, this._MBP);
    }
  }

  private void OnPreCull()
  {
    for (int index = 0; index < this._ShadowProjectors.Count; ++index)
    {
      this._ShadowProjectors[index].SetVisible(true);
      this._ShadowProjectors[index].OnPreRender();
    }
  }

  private void OnPostRender()
  {
    this._Tex.GrabScreenIfNeeded();
    for (int index = 0; index < this._ShadowProjectors.Count; ++index)
      this._ShadowProjectors[index].SetVisible(false);
  }

  public enum ProjectionCulling
  {
    None,
    ProjectorBounds,
    ProjectionVolumeBounds,
  }
}
