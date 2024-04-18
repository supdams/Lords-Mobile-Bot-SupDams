// Decompiled with JetBrains decompiler
// Type: ShadowProjector
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("Fast Shadow Projector/Shadow Projector")]
public class ShadowProjector : MonoBehaviour
{
  [SerializeField]
  protected Vector3 _GlobalProjectionDir = new Vector3(0.0f, -1f, 0.0f);
  [SerializeField]
  protected int _GlobalShadowResolution = 1;
  [SerializeField]
  protected GlobalProjectorManager.ProjectionCulling _GlobalShadowCullingMode;
  [SerializeField]
  private float _ShadowSize = 1f;
  [SerializeField]
  private Color _ShadowColor = new Color(1f, 1f, 1f);
  [SerializeField]
  private float _ShadowOpacity = 1f;
  public Material _Material;
  [SerializeField]
  private Vector3 _ShadowLocalOffset;
  [SerializeField]
  private float _RotationAngleOffset;
  [SerializeField]
  private Rect _UVRect = new Rect(0.0f, 0.0f, 1f, 1f);
  private MeshRenderer _Renderer;
  private MeshFilter _MeshFilter;
  private Mesh _ShadowDummyMesh;
  private ProjectorShadowDummy _ShadowDummy;

  public Vector3 GlobalProjectionDir
  {
    set
    {
      this._GlobalProjectionDir = value;
      if (!GlobalProjectorManager.Exists())
        return;
      GlobalProjectorManager.GlobalProjectionDir = this._GlobalProjectionDir;
    }
    get => this._GlobalProjectionDir;
  }

  public int GlobalShadowResolution
  {
    set
    {
      this._GlobalShadowResolution = value;
      if (!GlobalProjectorManager.Exists())
        return;
      GlobalProjectorManager.GlobalShadowResolution = this._GlobalShadowResolution;
    }
    get => this._GlobalShadowResolution;
  }

  public GlobalProjectorManager.ProjectionCulling GlobalShadowCullingMode
  {
    set
    {
      this._GlobalShadowCullingMode = value;
      if (!GlobalProjectorManager.Exists())
        return;
      GlobalProjectorManager.GlobalShadowCullingMode = this._GlobalShadowCullingMode;
    }
    get => this._GlobalShadowCullingMode;
  }

  public float ShadowSize
  {
    set
    {
      if ((double) this._ShadowSize == (double) value)
        return;
      this._ShadowSize = value;
      if (!((Object) this._ShadowDummyMesh != (Object) null))
        return;
      this.OnShadowSizeChanged();
    }
    get => this._ShadowSize;
  }

  public Color ShadowColor
  {
    set
    {
      if (!(this._ShadowColor != value))
        return;
      this._ShadowColor = value;
      if (!((Object) this._ShadowDummyMesh != (Object) null))
        return;
      this.OnShadowColorChanged();
    }
    get => this._ShadowColor;
  }

  public float ShadowOpacity
  {
    set
    {
      if ((double) this._ShadowOpacity == (double) value)
        return;
      this._ShadowOpacity = value;
      if (!((Object) this._ShadowDummyMesh != (Object) null))
        return;
      this.OnShadowColorChanged();
    }
    get => this._ShadowOpacity;
  }

  public Vector3 ShadowLocalOffset
  {
    set
    {
      this._ShadowLocalOffset = value;
      if (!((Object) this._ShadowDummy != (Object) null))
        return;
      this._ShadowDummy._ShadowLocalOffset = this._ShadowLocalOffset;
    }
    get => this._ShadowLocalOffset;
  }

  public float RotationAngleOffset
  {
    set
    {
      this._RotationAngleOffset = value;
      if (!((Object) this._ShadowDummy != (Object) null))
        return;
      this._ShadowDummy._RotationAngleOffset = this._RotationAngleOffset;
    }
    get => this._RotationAngleOffset;
  }

  public Rect UVRect
  {
    set
    {
      this._UVRect = value;
      if (!((Object) this._ShadowDummy != (Object) null))
        return;
      this.OnUVRectChanged();
    }
    get => this._UVRect;
  }

  private void Awake()
  {
    this._ShadowDummyMesh = ShadowProjector.MeshGen.CreatePlane(new Vector3(0.0f, 20f, 0.0f), new Vector3(20f, 0.0f, 0.0f), this._UVRect, new Color(this._ShadowColor.r, this._ShadowColor.g, this._ShadowColor.b, this._ShadowOpacity));
    Transform transform = this.transform;
    this._ShadowDummy = new GameObject("shadowDummy").AddComponent<ProjectorShadowDummy>();
    this._ShadowDummy.transform.parent = transform;
    this._ShadowDummy.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    this._ShadowDummy.gameObject.layer = LayerMask.NameToLayer(GlobalProjectorManager.GlobalProjectorLayer);
    this._ShadowDummy._ShadowLocalOffset = this._ShadowLocalOffset;
    this._ShadowDummy._RotationAngleOffset = this._RotationAngleOffset;
    this.OnShadowSizeChanged();
    this._Renderer = this._ShadowDummy.gameObject.AddComponent<MeshRenderer>();
    this._Renderer.receiveShadows = false;
    this._Renderer.castShadows = false;
    this._Renderer.material = this._Material;
    this._MeshFilter = this._ShadowDummy.gameObject.AddComponent<MeshFilter>();
    this._MeshFilter.mesh = this._ShadowDummyMesh;
  }

  private void Start() => GlobalProjectorManager.Get().AddProjector(this);

  private void OnEnable() => GlobalProjectorManager.Get().AddProjector(this);

  private void OnDisable()
  {
    if (!GlobalProjectorManager.Exists())
      return;
    GlobalProjectorManager.Get().RemoveProjector(this);
  }

  private void OnDestroy()
  {
    if (!GlobalProjectorManager.Exists())
      return;
    GlobalProjectorManager.Get().RemoveProjector(this);
  }

  public Bounds GetBounds() => this._Renderer.bounds;

  public bool IsVisible() => this._Renderer.isVisible;

  public void SetVisible(bool visible) => this._Renderer.enabled = visible;

  public void OnPreRender()
  {
    if (!((Object) this._ShadowDummy != (Object) null))
      return;
    this._ShadowDummy.OnPreRender();
  }

  public Matrix4x4 ShadowDummyLocalToWorldMatrix()
  {
    return this._ShadowDummy.transform.localToWorldMatrix;
  }

  public float GetShadowWorldSize()
  {
    return this.ShadowSize * (this.ShadowDummyLocalToWorldMatrix() * (Vector4) new Vector3(20f, 0.0f, 0.0f)).magnitude;
  }

  public Vector3 GetShadowPos() => this._ShadowDummy.transform.position;

  private void OnShadowSizeChanged()
  {
    this._ShadowDummy.transform.localScale = new Vector3(this._ShadowSize, this._ShadowSize, this._ShadowSize);
  }

  private void OnUVRectChanged() => this.RebuildMesh();

  public void OnShadowColorChanged()
  {
    Color color = new Color(this._ShadowColor.r, this._ShadowColor.g, this._ShadowColor.b, this._ShadowOpacity);
    this._ShadowDummyMesh.colors = new Color[4]
    {
      color,
      color,
      color,
      color
    };
  }

  private void RebuildMesh()
  {
    this._ShadowDummyMesh = ShadowProjector.MeshGen.CreatePlane(new Vector3(0.0f, 20f, 0.0f), new Vector3(20f, 0.0f, 0.0f), this._UVRect, new Color(this._ShadowColor.r, this._ShadowColor.g, this._ShadowColor.b, this._ShadowOpacity));
    this._MeshFilter.mesh = this._ShadowDummyMesh;
  }

  public void SetShadowProjectorMaterial(Material in_Material)
  {
    this._Material = in_Material;
    if (!((Object) this._Renderer != (Object) null))
      return;
    this._Renderer.material = this._Material;
  }

  private static class MeshGen
  {
    public static Mesh CreatePlane(Vector3 up, Vector3 right, Rect uvRect, Color color)
    {
      Mesh plane = new Mesh();
      Vector3[] vector3Array = new Vector3[4]
      {
        up * 0.5f - right * 0.5f,
        up * 0.5f + right * 0.5f,
        -up * 0.5f - right * 0.5f,
        -up * 0.5f + right * 0.5f
      };
      Vector2[] vector2Array = new Vector2[4]
      {
        new Vector2(uvRect.x, uvRect.y + uvRect.height),
        new Vector2(uvRect.x + uvRect.width, uvRect.y + uvRect.height),
        new Vector2(uvRect.x, uvRect.y),
        new Vector2(uvRect.x + uvRect.width, uvRect.y)
      };
      Color[] colorArray = new Color[4]
      {
        color,
        color,
        color,
        color
      };
      int[] triangles = new int[6]{ 0, 1, 3, 0, 3, 2 };
      plane.vertices = vector3Array;
      plane.uv = vector2Array;
      plane.colors = colorArray;
      plane.SetTriangles(triangles, 0);
      return plane;
    }
  }
}
