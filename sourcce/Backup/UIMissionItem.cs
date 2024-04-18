// Decompiled with JetBrains decompiler
// Type: UIMissionItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public abstract class UIMissionItem : IUIButtonClickHandler
{
  public Transform transform;
  public UIButton[] ItemBtn;
  public int DataIndex;
  public iMissionTimeDelta TimeHandle;

  public abstract void SetMissionData(int Index);

  public abstract void Destroy();

  public abstract void Update();

  public abstract float GetHeight();

  public abstract void SetSelect(
    bool bSelect,
    int index = 0,
    uint[] reward = null,
    ushort[] rewardItem = null,
    ushort[] count = null);

  public abstract void OnButtonClick(UIButton sender);

  public abstract void TextRefresh();
}
