// Decompiled with JetBrains decompiler
// Type: IconSpriteAsset
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;

#nullable disable
public struct IconSpriteAsset
{
  private AssetBundle m_AssetBundle;
  private int m_AssetBundleKey;
  private Dictionary<ushort, Sprite> m_Dict;
  private Material m_Material;

  public void InitialAsset(string AssetName)
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendFormat("UI/{0}", (object) AssetName);
    this.m_AssetBundle = AssetManager.GetAssetBundle(stringBuilder.ToString(), out this.m_AssetBundleKey);
    this.m_Dict = new Dictionary<ushort, Sprite>();
    if (!((Object) this.m_AssetBundle != (Object) null))
      return;
    Object[] objectArray = this.m_AssetBundle.LoadAll(typeof (Sprite));
    stringBuilder.Length = 0;
    stringBuilder.AppendFormat("{0}_m", (object) AssetName);
    this.m_Material = this.m_AssetBundle.Load(stringBuilder.ToString(), typeof (Material)) as Material;
    for (int index = 0; index < objectArray.Length; ++index)
      this.m_Dict.Add(ushort.Parse(objectArray[index].name.Substring(1)), (Sprite) objectArray[index]);
  }

  public void UnloadAsset()
  {
    if (this.m_AssetBundleKey == 0)
      return;
    AssetManager.UnloadAssetBundle(this.m_AssetBundleKey);
    this.m_Dict.Clear();
    this.m_Material = (Material) null;
    this.m_AssetBundle = (AssetBundle) null;
    this.m_AssetBundleKey = 0;
  }

  public Sprite LoadSprite(ushort id)
  {
    Sprite sprite;
    this.m_Dict.TryGetValue(id, out sprite);
    return sprite;
  }

  public Material GetMaterial() => this.m_Material;
}
