// Decompiled with JetBrains decompiler
// Type: sHeroType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal struct sHeroType
{
  public Transform[] Tf;
  public Image[] FrameImage;
  public Image[] HeroImage;
  public Image[] RankImage;
  public Image LordsIcon1;
  public Image LordsIcon2;

  public void Init()
  {
    this.Tf = new Transform[5];
    this.FrameImage = new Image[5];
    this.HeroImage = new Image[5];
    this.RankImage = new Image[5];
    this.LordsIcon1 = (Image) null;
    this.LordsIcon2 = (Image) null;
  }
}
