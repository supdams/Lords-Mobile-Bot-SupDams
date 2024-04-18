// Decompiled with JetBrains decompiler
// Type: LineContainer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class LineContainer
{
  private const int MAX_LINESIZE = 512;
  private List<Dictionary<int, LineNode>> m_List = new List<Dictionary<int, LineNode>>();

  public LineContainer()
  {
    this.m_List.Clear();
    this.m_List.Add(new Dictionary<int, LineNode>(512));
  }

  public void Insert(int key, LineNode line)
  {
    for (int index = 0; index < this.m_List.Count; ++index)
    {
      if (this.m_List[index].Count != 512)
      {
        this.m_List[index][key] = line;
        return;
      }
    }
    this.m_List.Add(new Dictionary<int, LineNode>(512)
    {
      [key] = line
    });
    Debug.Log((object) ("New Line Container : " + this.m_List.Count.ToString()));
  }

  public bool TryGetValue(int key, out LineNode line)
  {
    line = (LineNode) null;
    LineNode lineNode = (LineNode) null;
    for (int index = 0; index < this.m_List.Count; ++index)
    {
      if (this.m_List[index].TryGetValue(key, out lineNode))
      {
        line = lineNode;
        return true;
      }
    }
    return false;
  }

  public void Clear()
  {
    for (int index = 0; index < this.m_List.Count; ++index)
      this.m_List[index].Clear();
    this.m_List.Clear();
  }
}
