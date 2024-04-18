// Decompiled with JetBrains decompiler
// Type: UITextBoundCheck
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UITextBoundCheck : BaseVertexEffect
{
  private Text textComponent;

  protected virtual void Start()
  {
    this.textComponent = ((Component) this).transform.GetComponent<Text>();
  }

  public virtual void ModifyVertices(List<UIVertex> verts)
  {
    if (!((UIBehaviour) this).IsActive() || (Object) this.textComponent == (Object) null || this.textComponent.alignment == TextAnchor.LowerLeft || this.textComponent.alignment == TextAnchor.MiddleLeft || this.textComponent.alignment == TextAnchor.UpperLeft)
      return;
    Rect rect = ((Graphic) this.textComponent).rectTransform.rect;
    IList<UILineInfo> lines = this.textComponent.cachedTextGenerator.lines;
    for (int index1 = 0; index1 < lines.Count; ++index1)
    {
      int index2 = lines[index1].startCharIdx * 4;
      if (verts.Count <= index2)
        break;
      if (!rect.Contains(verts[index2].position))
      {
        int num1;
        if (index1 + 1 < lines.Count)
        {
          num1 = lines[index1 + 1].startCharIdx - 1;
          if (num1 * 4 >= verts.Count)
            num1 = (verts.Count >> 2) - 1;
        }
        else
          num1 = (verts.Count >> 2) - 1;
        if (num1 != lines[index1].startCharIdx)
        {
          float num2 = rect.xMin - verts[index2].position.x + (this.textComponent.alignment == TextAnchor.LowerCenter || this.textComponent.alignment == TextAnchor.MiddleCenter || this.textComponent.alignment == TextAnchor.UpperCenter ? (float) (((double) rect.width - ((double) verts[num1 * 4 + 1].position.x - (double) verts[index2].position.x)) * 0.5) : rect.width - (verts[num1 * 4 + 1].position.x - verts[index2].position.x));
          for (int startCharIdx = lines[index1].startCharIdx; startCharIdx < num1; ++startCharIdx)
          {
            int num3 = startCharIdx * 4;
            if (num3 < verts.Count)
            {
              for (int index3 = 0; index3 < 4; ++index3)
              {
                UIVertex vert = verts[num3 + index3];
                vert.position.Set(vert.position.x + num2, vert.position.y, vert.position.z);
                verts[num3 + index3] = vert;
              }
            }
            else
              break;
          }
          Debug.Log((object) "OutSide..");
        }
      }
    }
  }
}
