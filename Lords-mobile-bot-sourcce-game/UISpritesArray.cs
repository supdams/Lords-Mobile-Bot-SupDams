// Decompiled with JetBrains decompiler
// Type: UISpritesArray
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UISpritesArray : MonoBehaviour
{
  public Sprite[] m_Sprites;
  public UISpritesArray m_SourceSpritesArray;
  public Image m_Image;
  public int m_SpriteIndex;

  public Sprite GetSprite(int index)
  {
    Sprite[] spriteArray = !((Object) this.m_SourceSpritesArray != (Object) null) ? this.m_Sprites : this.m_SourceSpritesArray.m_Sprites;
    return spriteArray == null || index >= spriteArray.Length ? (Sprite) null : spriteArray[index];
  }

  public void SetSpriteIndex(int index)
  {
    Sprite sprite = this.GetSprite(index);
    if ((Object) sprite == (Object) null)
      return;
    this.m_Image.sprite = sprite;
    this.m_SpriteIndex = index;
  }
}
