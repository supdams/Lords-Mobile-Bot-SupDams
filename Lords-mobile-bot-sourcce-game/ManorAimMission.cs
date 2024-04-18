// Decompiled with JetBrains decompiler
// Type: ManorAimMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ManorAimMission : UIMissionItem
{
  protected Transform SelectTrans;
  protected UIText TitleText;
  public static readonly int MaxSlot = 5;
  public int SlotCount;

  public ManorAimMission(Transform transform)
  {
    this.transform = transform;
    this.ItemBtn = new UIButton[ManorAimMission.MaxSlot];
  }

  public override void SetMissionData(int Index)
  {
  }

  public override void Destroy()
  {
  }

  public override void Update()
  {
  }

  public override float GetHeight() => 106f;

  public override void SetSelect(
    bool bSelect,
    int index = 0,
    uint[] reward = null,
    ushort[] rewardItem = null,
    ushort[] count = null)
  {
    if (reward == null || !bSelect)
      return;
    Array.Clear((Array) reward, 0, reward.Length);
    Array.Clear((Array) rewardItem, 0, rewardItem.Length);
    Array.Clear((Array) count, 0, count.Length);
    uint baseValByEffectId = DataManager.Instance.AttribVal.GetEffectBaseValByEffectID((ushort) 304);
    if (!this.transform.gameObject.activeSelf)
      return;
    ManorAimTbl recordByKey = DataManager.MissionDataManager.ManorAimTable.GetRecordByKey((ushort) this.ItemBtn[index].m_BtnID3);
    for (int index1 = 0; index1 < recordByKey.RewardResource.Length; ++index1)
      reward[3 + index1] = recordByKey.RewardResource[index1];
    for (int index2 = 0; index2 < recordByKey.RewardItems.Length; ++index2)
    {
      rewardItem[index2] = recordByKey.RewardItems[index2].ItemID;
      count[index2] = (ushort) recordByKey.RewardItems[index2].Quantity;
    }
    reward[1] = recordByKey.Force;
    reward[0] = recordByKey.Exp;
    reward[0] = reward[0] * (10000U + baseValByEffectId) / 10000U;
    reward[2] = (uint) recordByKey.RewardMorale;
  }

  public override void OnButtonClick(UIButton sender)
  {
  }

  public override void TextRefresh()
  {
    ((Behaviour) this.TitleText).enabled = false;
    ((Behaviour) this.TitleText).enabled = true;
  }
}
