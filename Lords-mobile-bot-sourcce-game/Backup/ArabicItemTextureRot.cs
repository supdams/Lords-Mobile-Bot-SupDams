// Decompiled with JetBrains decompiler
// Type: ArabicItemTextureRot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ArabicItemTextureRot : BaseVertexEffect
{
  public virtual void ModifyVertices(List<UIVertex> verts)
  {
    if (!GUIManager.Instance.IsArabic)
      return;
    int num = verts.Count >> 2;
    for (int index1 = 0; index1 < num; ++index1)
    {
      int index2 = index1 << 2;
      UIVertex vert1 = verts[index2];
      UIVertex vert2 = verts[index2 + 3];
      Vector2 uv0_1 = vert1.uv0;
      vert1.uv0 = vert2.uv0;
      vert2.uv0 = uv0_1;
      verts[index2] = vert1;
      verts[index2 + 3] = vert2;
      UIVertex vert3 = verts[index2 + 1];
      UIVertex vert4 = verts[index2 + 2];
      Vector2 uv0_2 = vert3.uv0;
      vert3.uv0 = vert4.uv0;
      vert4.uv0 = uv0_2;
      verts[index2 + 1] = vert3;
      verts[index2 + 2] = vert4;
    }
  }
}
