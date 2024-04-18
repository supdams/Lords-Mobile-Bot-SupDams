// Decompiled with JetBrains decompiler
// Type: SimulationDefObj
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine.UI;

#nullable disable
internal struct SimulationDefObj
{
  public UIText SelectArmy;
  public UIText[] BtnText;
  public UIButton[] Btn;
  public Image[] SelectImage;
  public CString CStr;

  public void Init()
  {
    this.SelectArmy = (UIText) null;
    this.BtnText = new UIText[3];
    this.Btn = new UIButton[3];
    this.SelectImage = new Image[3];
    this.CStr = StringManager.Instance.SpawnString();
  }
}
