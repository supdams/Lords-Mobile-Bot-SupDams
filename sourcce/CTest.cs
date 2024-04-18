// Decompiled with JetBrains decompiler
// Type: CTest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class CTest : UIMissionItem
{
  private UITimeBar TimerBar;

  public CTest(Transform transform)
  {
    this.transform = transform;
    this.TimerBar = transform.GetChild(1).GetComponent<UITimeBar>();
    GUIManager.Instance.CreateTimerBar(this.TimerBar, 0L, 0L, 0L, eTimeBarType.UIMission, string.Empty, string.Empty);
  }

  public override void SetMissionData(int Index)
  {
  }

  public override void Destroy() => GUIManager.Instance.RemoverTimeBaarToList(this.TimerBar);

  public override void Update()
  {
  }

  public override float GetHeight() => 106f;

  public override void SetSelect(
    bool bSelect,
    int index,
    uint[] reward = null,
    ushort[] rewardItem = null,
    ushort[] count = null)
  {
  }

  public override void OnButtonClick(UIButton sender)
  {
  }

  public override void TextRefresh()
  {
  }

  private enum UIControl
  {
    MissionPic,
    TimeBar,
    Btn,
    MissionName,
    Select,
  }
}
