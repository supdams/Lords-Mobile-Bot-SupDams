// Decompiled with JetBrains decompiler
// Type: SpriteBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public abstract class SpriteBase
{
  public ushort Index;
  public int HashID;
  public MapSpriteManager mapspriteManager;

  public virtual GameObject InitialSprite(MapSpriteManager mapspriteManager) => (GameObject) null;

  public abstract void SetSprite(ushort ID, byte Class);

  public abstract void Destroy();

  public virtual void Update(byte meg)
  {
  }

  public virtual void Hide()
  {
  }

  public virtual void UpdateSpriteFrame()
  {
  }
}
