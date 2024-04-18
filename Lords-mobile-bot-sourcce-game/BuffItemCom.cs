// Decompiled with JetBrains decompiler
// Type: BuffItemCom
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal struct BuffItemCom
{
  public GameObject[] m_Colum;
  public RectTransform[] m_ColumRect;
  public UIText[] m_Text;
  public Image[] m_Image;
  public Outline[] m_Outline;
  public Shadow[] m_Shadow;

  public void Init()
  {
    this.m_Outline = new Outline[2];
    this.m_Shadow = new Shadow[2];
    this.m_Colum = new GameObject[2];
    this.m_ColumRect = new RectTransform[2];
    this.m_Text = new UIText[2];
    this.m_Image = new Image[2];
  }
}
