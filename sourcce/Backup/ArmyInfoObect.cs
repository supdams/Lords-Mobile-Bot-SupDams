// Decompiled with JetBrains decompiler
// Type: ArmyInfoObect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal class ArmyInfoObect
{
  public int m_dataIdx;
  public EMarchEventType m_Type;
  public POINT_KIND PointKind;
  public byte bHost;
  public byte m_SliderType;
  public Image m_ScrollSliderIcon;
  public UIText m_ScrollSliderText1;
  public UIText m_ScrollSliderText2;
  public Image m_ScrollSlider1Value;
  public UIText m_ScrollSlider1Title;
  public UIText m_ScrollSlider1Time;
  public Image m_ScrollSlider2Value1;
  public Image m_ScrollSlider2Value2;
  public UIText m_ScrollSlider2Title;
  public UIText m_ScrollSlider2Time;
  public Image m_ScrollSlider3Value;
  public UIText m_ScrollSlider3Title;
  public UIText m_ScrollSlider3Time;
  public UIText m_ScrollIconText;
  public Transform m_Slider1;
  public Transform m_Slider2;
  public Transform m_Slider3;
  public uint m_MaxOverload;
  public long m_ResStartTime;
  public uint m_ResTotalCount;
  public float m_ResRate;
  public CString m_Text1Str;
  public CString m_Text2Str;
  public CString m_Slider1TitleStr;
  public CString m_Slider1TimeStr;
  public CString m_TempTime;
  public CString m_IconText;

  public ArmyInfoObect()
  {
    this.m_dataIdx = -1;
    this.m_SliderType = (byte) 1;
    this.m_MaxOverload = 0U;
    this.m_MaxOverload = 0U;
    this.m_ResStartTime = 0L;
    this.m_ResTotalCount = 0U;
    this.m_ResRate = 0.0f;
    this.m_Type = EMarchEventType.EMET_Standby;
    this.bHost = (byte) 0;
    this.m_Text1Str = StringManager.Instance.SpawnString(40);
    this.m_Text2Str = StringManager.Instance.SpawnString(40);
    this.m_Slider1TitleStr = StringManager.Instance.SpawnString(40);
    this.m_Slider1TimeStr = StringManager.Instance.SpawnString(40);
    this.m_TempTime = StringManager.Instance.SpawnString(40);
    this.m_IconText = StringManager.Instance.SpawnString(40);
  }
}
