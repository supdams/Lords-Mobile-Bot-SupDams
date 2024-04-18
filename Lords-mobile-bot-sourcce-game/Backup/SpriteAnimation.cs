// Decompiled with JetBrains decompiler
// Type: SpriteAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class SpriteAnimation : MonoBehaviour
{
  public Sprite[] m_Sprites;
  public Vector2[] m_Pivot;
  public Image m_Image;
  private int m_SpriteIndex;
  private float m_TickTime;
  private float m_ChangeTime = 0.0667f;
  private int m_FPS = 15;

  public int FPS
  {
    get => this.m_FPS;
    set
    {
      this.m_FPS = value;
      this.m_SpriteIndex = 0;
      this.m_TickTime = 0.0f;
      this.m_ChangeTime = 1f / (float) this.m_FPS;
    }
  }

  private void Update()
  {
    this.m_TickTime += Time.smoothDeltaTime;
    if ((double) this.m_TickTime < (double) this.m_ChangeTime)
      return;
    this.m_TickTime = 0.0f;
    if (this.m_Sprites == null || !((Object) this.m_Image != (Object) null))
      return;
    if (this.m_Pivot == null || this.m_Pivot.Length != this.m_Sprites.Length)
      this.CalculatePivot();
    ++this.m_SpriteIndex;
    if (this.m_SpriteIndex >= this.m_Sprites.Length)
      this.m_SpriteIndex = 0;
    this.m_Image.sprite = this.m_Sprites[this.m_SpriteIndex];
    ((Graphic) this.m_Image).rectTransform.pivot = this.m_Pivot[this.m_SpriteIndex];
    this.m_Image.SetNativeSize();
  }

  private void CalculatePivot()
  {
    if (this.m_Sprites == null)
      return;
    ((Transform) ((Graphic) this.m_Image).rectTransform).localScale = new Vector3(0.53f, 0.53f, 0.53f);
    this.m_Pivot = new Vector2[this.m_Sprites.Length];
    for (int index = 0; index < this.m_Sprites.Length; ++index)
    {
      if (!((Object) this.m_Sprites[index] == (Object) null))
      {
        this.m_Pivot[index].x = (float) (0.5 + -(double) this.m_Sprites[index].bounds.center.x / (double) this.m_Sprites[index].bounds.extents.x / 2.0);
        this.m_Pivot[index].y = (float) (0.5 + -(double) this.m_Sprites[index].bounds.center.y / (double) this.m_Sprites[index].bounds.extents.y / 2.0);
      }
    }
  }
}
