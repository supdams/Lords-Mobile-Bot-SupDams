// Decompiled with JetBrains decompiler
// Type: ManorMissionKind
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ManorMissionKind : ManorAimMission
{
  private eUIMissionKind Kind;
  private _UIClassificationTbl MissionData;
  private _MissionSlot[] MissionSlot;
  private ushort[] MissionIDs;

  public ManorMissionKind(Transform transform, eUIMissionKind Kind, UISpritesArray SpriteArray)
    : base(transform)
  {
    this.Kind = Kind;
    this.transform = transform;
    this.TitleText = transform.GetChild(0).GetComponent<UIText>();
    this.TitleText.text = DataManager.Instance.mStringTable.GetStringByID((uint) (1533 + Kind));
    this.MissionSlot = new _MissionSlot[ManorAimMission.MaxSlot];
    transform.GetComponent<Image>().sprite = SpriteArray.GetSprite(1);
    for (int index = 0; index < ManorAimMission.MaxSlot; ++index)
    {
      this.MissionSlot[index] = new _MissionSlot();
      this.MissionSlot[index].Init(transform.GetChild(1 + index), (UIMissionItem) this);
      ((Component) this.MissionSlot[index].Reward).gameObject.SetActive(false);
      this.ItemBtn[index] = this.MissionSlot[index].ItemBtn;
      this.ItemBtn[index].m_BtnID4 = index;
      this.MissionSlot[index].transform.GetComponent<Image>().sprite = SpriteArray.GetSprite(3);
    }
    this.MissionData = DataManager.MissionDataManager.UIManorAimKind[(int) (byte) Kind];
    this.MissionIDs = new ushort[ManorAimMission.MaxSlot];
  }

  public override void SetMissionData(int Index)
  {
    if (!this.transform.gameObject.activeSelf)
      return;
    this.DataIndex = Index;
    MissionManager missionDataManager = DataManager.MissionDataManager;
    CString cstring = StringManager.Instance.StaticString1024();
    for (ushort index = 0; (int) index < this.MissionSlot.Length; ++index)
    {
      if (this.SlotCount > (int) index)
      {
        ManorAimTbl recordByKey = missionDataManager.ManorAimTable.GetRecordByKey(this.MissionIDs[(int) index]);
        this.ItemBtn[(int) index].m_BtnID2 = this.DataIndex;
        missionDataManager.GetNarrative(cstring, ref recordByKey);
        this.MissionSlot[(int) index].SetText(cstring);
        this.MissionSlot[(int) index].Reward.m_BtnID3 = (int) this.MissionIDs[(int) index];
        this.ItemBtn[(int) index].m_BtnID3 = (int) this.MissionIDs[(int) index];
      }
      else
        this.MissionSlot[(int) index].transform.gameObject.SetActive(false);
    }
  }

  public override void Destroy()
  {
    for (int index = 0; index < ManorAimMission.MaxSlot; ++index)
      this.MissionSlot[index].Destroy();
  }

  public override float GetHeight()
  {
    this.SlotCount = 0;
    MissionManager missionDataManager = DataManager.MissionDataManager;
    int saveIndex = (int) this.MissionData.SaveIndex;
    for (ushort index = 0; (int) index < this.MissionSlot.Length; ++index)
    {
      if ((this.MissionIDs[this.SlotCount] = missionDataManager.GetUIMissionItemKind(this.Kind, ref saveIndex)) != ushort.MaxValue)
      {
        if (index == (ushort) 0)
          this.MissionData.SaveIndex = (ushort) (saveIndex - 1);
        ++this.SlotCount;
      }
    }
    if (this.SlotCount == 0)
    {
      this.transform.gameObject.SetActive(false);
      return 0.0f;
    }
    this.transform.gameObject.SetActive(true);
    return (float) (39.0 + 64.0 * (double) this.SlotCount);
  }

  public override void SetSelect(
    bool bSelect,
    int index,
    uint[] reward = null,
    ushort[] rewardItem = null,
    ushort[] count = null)
  {
    this.SelectTrans = this.MissionSlot[index].SelectTrans;
    this.SelectTrans.gameObject.SetActive(bSelect);
    base.SetSelect(bSelect, index, reward, rewardItem, count);
  }

  public override void TextRefresh()
  {
    base.TextRefresh();
    for (int index = 0; index < this.MissionSlot.Length; ++index)
    {
      ((Behaviour) this.MissionSlot[index].NameText).enabled = false;
      ((Behaviour) this.MissionSlot[index].NameText).enabled = true;
    }
  }

  private enum UIControl
  {
    Title,
    Mission1,
    Mission2,
    Mission3,
    Mission4,
    Mission5,
    Select,
  }
}
