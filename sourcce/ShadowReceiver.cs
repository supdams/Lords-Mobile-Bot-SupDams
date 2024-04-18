// Decompiled with JetBrains decompiler
// Type: ShadowReceiver
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("Fast Shadow Projector/Shadow Receiver")]
public class ShadowReceiver : MonoBehaviour
{
  private MeshFilter _meshFilter;
  private Mesh _mesh;
  private Mesh _meshCopy;
  private MeshRenderer _meshRenderer;

  private void Awake()
  {
    this._meshFilter = this.GetComponent<MeshFilter>();
    this._meshRenderer = this.GetComponent<MeshRenderer>();
    this._meshCopy = (Mesh) null;
    if (!((Object) this._meshFilter != (Object) null))
      return;
    this._mesh = this._meshFilter.mesh;
  }

  private void Start()
  {
    this.AddReceiver();
    if (!((Object) this._meshRenderer != (Object) null) || !this._meshRenderer.isPartOfStaticBatch || !((Object) this._mesh != (Object) null))
      return;
    this.CopyMesh();
  }

  private void CopyMesh()
  {
    this._meshCopy = new Mesh();
    this._meshCopy.vertices = this._mesh.vertices;
    this._meshCopy.normals = this._mesh.normals;
    this._meshCopy.uv = this._mesh.uv;
    this._meshCopy.triangles = this._mesh.triangles;
    this._meshCopy.tangents = this._mesh.tangents;
    this._meshCopy.colors = this._mesh.colors;
    this._meshCopy.colors32 = this._mesh.colors32;
    this._meshCopy.uv1 = this._mesh.uv1;
    this._meshCopy.uv2 = this._mesh.uv2;
  }

  public Mesh GetMesh() => (Object) this._meshCopy != (Object) null ? this._meshCopy : this._mesh;

  private void OnEnable() => this.AddReceiver();

  private void OnDisable() => this.RemoveReceiver();

  private void OnDestroy() => this.RemoveReceiver();

  private void AddReceiver()
  {
    if (!((Object) this._meshFilter != (Object) null))
      return;
    GlobalProjectorManager.Get().AddReceiver(this);
  }

  private void RemoveReceiver()
  {
    if (!GlobalProjectorManager.Exists() || !((Object) this._meshFilter != (Object) null))
      return;
    GlobalProjectorManager.Get().RemoveReceiver(this);
  }
}
