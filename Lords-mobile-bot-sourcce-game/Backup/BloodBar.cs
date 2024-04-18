// Decompiled with JetBrains decompiler
// Type: BloodBar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class BloodBar
{
  public bool bShow;
  public bool bForceShowBlood;
  public float fTime;
  public float DeltaX;
  public float TargetWidth;
  public bool bShowState;
  public GameObject m_GameObject;
  public Transform m_transform;
  public RectTransform m_RT;
  public Transform m_BarTransform;
  public RectTransform[] m_BarRT = new RectTransform[3];
  public Image[] m_BarImg = new Image[3];
  public Transform m_IconTransform;
  public RectTransform[] m_IconRT = new RectTransform[3];
  public Image[] m_IconImg = new Image[3];
  public int[] FadeNum = new int[3];
  public byte[] StateID = new byte[3];
}
