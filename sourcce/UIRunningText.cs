// Decompiled with JetBrains decompiler
// Type: UIRunningText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIRunningText : MonoBehaviour
{
  public UIText m_RunningText1;
  public RectTransform m_RunRT1;
  public UIText m_RunningText2;
  public RectTransform m_RunRT2;
  public float tmpTime;
  public float tmpLength;
  private Vector2 Pos = new Vector2(0.0f, 0.0f);

  private void Start()
  {
    if ((Object) this.m_RunningText1 != (Object) null)
      this.m_RunRT1 = ((Component) this.m_RunningText1).GetComponent<RectTransform>();
    if (!((Object) this.m_RunningText2 != (Object) null))
      return;
    this.m_RunRT2 = ((Component) this.m_RunningText2).GetComponent<RectTransform>();
  }

  private void Update()
  {
    if (!((Object) this.m_RunningText1 != (Object) null) || !((Object) this.m_RunRT1 != (Object) null) || !((Object) this.m_RunningText2 != (Object) null) || !((Object) this.m_RunRT2 != (Object) null))
      return;
    this.tmpTime += (float) ((double) Time.smoothDeltaTime * (double) this.tmpLength / 10.0);
    if ((double) this.tmpTime >= (double) this.tmpLength)
      this.tmpTime = 0.0f;
    this.Pos.Set(-this.tmpTime, this.m_RunRT1.anchoredPosition.y);
    this.m_RunRT1.anchoredPosition = this.Pos;
    this.Pos.Set(this.tmpLength - this.tmpTime, this.m_RunRT2.anchoredPosition.y);
    this.m_RunRT2.anchoredPosition = this.Pos;
  }
}
