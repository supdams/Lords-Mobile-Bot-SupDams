// Decompiled with JetBrains decompiler
// Type: SpriteAsset
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public struct SpriteAsset
{
  public int m_RefCount;
  public Dictionary<int, Sprite> m_Dict;
  public AssetBundle m_AssetBundle;
  public int m_AssetBundleKey;
  public Material m_Material;

  public void InitialAsset(string AssetName)
  {
    CString Name = StringManager.Instance.StaticString1024();
    Name.StringToFormat(AssetName);
    Name.AppendFormat("UI/{0}");
    this.m_AssetBundle = AssetManager.GetAssetBundle(Name, out this.m_AssetBundleKey);
    if ((Object) this.m_AssetBundle == (Object) null)
      return;
    Object[] objectArray = this.m_AssetBundle.LoadAll(typeof (Sprite));
    Name.ClearString();
    Name.StringToFormat(AssetName);
    Name.AppendFormat("{0}_m");
    this.m_Material = this.m_AssetBundle.Load(Name.ToString(), typeof (Material)) as Material;
    this.m_RefCount = 1;
    this.m_Dict = new Dictionary<int, Sprite>();
    for (int index = 0; index < objectArray.Length; ++index)
      this.m_Dict.Add(objectArray[index].name.GetHashCode(), (Sprite) objectArray[index]);
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
}
