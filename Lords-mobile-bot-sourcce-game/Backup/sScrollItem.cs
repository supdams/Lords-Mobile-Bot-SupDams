// Decompiled with JetBrains decompiler
// Type: sScrollItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
internal struct sScrollItem
{
  public bool bInit;
  public eItem Type;
  public sTitleType TitleType;
  public sTextType TextType;
  public sHeroType HeroType;
  public CString CStr;
  public CString ArmyIconStr;

  public void Init()
  {
    this.bInit = false;
    this.Type = eItem.TitleType;
    this.TitleType = new sTitleType();
    this.TitleType.Init();
    this.TextType = new sTextType();
    this.TextType.Init();
    this.HeroType = new sHeroType();
    this.HeroType.Init();
    this.CStr = StringManager.Instance.SpawnString(100);
    this.ArmyIconStr = StringManager.Instance.SpawnString();
  }
}
