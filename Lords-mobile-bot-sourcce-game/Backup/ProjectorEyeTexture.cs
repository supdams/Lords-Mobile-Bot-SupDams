// Decompiled with JetBrains decompiler
// Type: ProjectorEyeTexture
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class ProjectorEyeTexture
{
  private RenderTexture _RenderTexture;
  private Texture2D _RenderTextureDummy;
  private Camera _Camera;

  public ProjectorEyeTexture(Camera camera, int size)
  {
    this._Camera = camera;
    this._RenderTexture = (RenderTexture) null;
    this._RenderTextureDummy = (Texture2D) null;
    if (this.RenderTextureSupported())
    {
      if ((Object) this._RenderTexture != (Object) null)
      {
        this._RenderTexture.Release();
        this._RenderTexture = (RenderTexture) null;
      }
      this._RenderTexture = new RenderTexture(size, size, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
      this._RenderTexture.Create();
      this._RenderTexture.anisoLevel = 0;
      this._RenderTexture.filterMode = FilterMode.Bilinear;
      this._RenderTexture.useMipMap = false;
      camera.targetTexture = this._RenderTexture;
    }
    else
    {
      if ((Object) this._RenderTextureDummy != (Object) null)
        this._RenderTextureDummy = (Texture2D) null;
      this._RenderTextureDummy = new Texture2D((int) this._Camera.pixelWidth, (int) this._Camera.pixelHeight, TextureFormat.ARGB32, false, true);
      this._RenderTextureDummy.filterMode = FilterMode.Bilinear;
      this._RenderTextureDummy.wrapMode = TextureWrapMode.Clamp;
    }
  }

  public Texture GetTexture()
  {
    return this.RenderTextureSupported() ? (Texture) this._RenderTexture : (Texture) this._RenderTextureDummy;
  }

  public RenderTexture GetRenderTexture() => this._RenderTexture;

  public void GrabScreenIfNeeded()
  {
    if (this.RenderTextureSupported())
      return;
    this._RenderTextureDummy.ReadPixels(new Rect(0.0f, 0.0f, (float) (int) this._Camera.pixelWidth, (float) (int) this._Camera.pixelHeight), 0, 0, false);
    this._RenderTextureDummy.Apply();
  }

  private bool RenderTextureSupported() => SystemInfo.supportsRenderTextures;
}
