// Decompiled with JetBrains decompiler
// Type: EmojiUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class EmojiUnit
{
  public byte EmojiType;
  public byte SheetID;
  public byte defaultSheetID;
  public ushort IconID;
  public int poolID;
  public float AnimationSpeed;
  private float AnimationTimer;
  public Sprite[] SpriteMove;
  public Transform EmojiTransform;
  public Image EmojiImage;
  public List<Vector2> EmojiPivots;
  public SpriteRenderer EmojiSpriteRenderer;

  public EmojiUnit()
  {
    this.EmojiUnitIni((byte) 0);
    this.EmojiPivots = new List<Vector2>(4);
  }

  public void EmojiUnitIni(byte defaultsprite = 0)
  {
    this.SheetID = (byte) 0;
    this.defaultSheetID = defaultsprite;
    this.AnimationTimer = 1f;
    this.Start();
  }

  public void setImagePivot()
  {
    Vector2 vector2 = Vector2.zero;
    for (int index = 0; index < this.SpriteMove.Length; ++index)
    {
      if (this.EmojiPivots.Count <= index)
        this.EmojiPivots.Add(Vector2.zero);
      else
        vector2 = this.EmojiPivots[index];
      if ((Object) this.SpriteMove[index] != (Object) null)
      {
        vector2.x = (float) (0.5 + -(double) this.SpriteMove[index].bounds.center.x / (double) this.SpriteMove[index].bounds.extents.x / 2.0);
        vector2.y = (float) (0.5 + -(double) this.SpriteMove[index].bounds.center.y / (double) this.SpriteMove[index].bounds.extents.y / 2.0);
      }
      this.EmojiPivots[index] = vector2;
    }
    if (this.SpriteMove.Length > 1)
      return;
    this.EmojiImage.sprite = this.SpriteMove[0];
    ((Graphic) this.EmojiImage).rectTransform.pivot = this.EmojiPivots[0];
    this.EmojiImage.SetNativeSize();
  }

  public void DefaultSprite()
  {
    this.SheetID = this.defaultSheetID;
    this.setSprite();
    this.Stop();
  }

  public void Start() => this.AnimationSpeed = 15f;

  public void Stop() => this.AnimationSpeed = 0.0f;

  public void Run()
  {
    if (this.SpriteMove.Length <= 1)
      return;
    this.AnimationTimer -= Time.deltaTime * this.AnimationSpeed;
    if ((double) this.AnimationTimer >= 0.0)
      return;
    this.AnimationTimer = 1f;
    this.setSprite();
    if ((int) ++this.SheetID < this.SpriteMove.Length)
      return;
    this.SheetID = (byte) 0;
  }

  private void setSprite()
  {
    if ((Object) this.EmojiImage == (Object) null)
    {
      this.EmojiSpriteRenderer.sprite = this.SpriteMove[(int) this.SheetID];
    }
    else
    {
      this.EmojiImage.sprite = this.SpriteMove[(int) this.SheetID];
      ((Graphic) this.EmojiImage).rectTransform.pivot = this.EmojiPivots[(int) this.SheetID];
      this.EmojiImage.SetNativeSize();
    }
  }
}
