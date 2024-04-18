// Decompiled with JetBrains decompiler
// Type: ReCommandMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ReCommandMission : ManorAimMission
{
  private Image MissionPic;
  private UIText MissionName;
  private CString NarrativeStr;
  private UISpritesArray SpriteArray;

  public ReCommandMission(Transform transform, UISpritesArray SpriteArray)
    : base(transform)
  {
    this.transform = transform;
    this.SpriteArray = SpriteArray;
    this.TitleText = transform.GetChild(0).GetComponent<UIText>();
    this.TitleText.text = DataManager.Instance.mStringTable.GetStringByID(1531U);
    this.MissionPic = transform.GetChild(2).GetComponent<Image>();
    this.MissionName = transform.GetChild(3).GetComponent<UIText>();
    this.NarrativeStr = StringManager.Instance.SpawnString(100);
    this.SelectTrans = transform.GetChild(4);
    this.ItemBtn[0] = transform.GetChild(1).GetComponent<UIButton>();
    this.ItemBtn[0].m_BtnID1 = 11;
  }

  public override void SetMissionData(int Index)
  {
    if (!this.transform.gameObject.activeSelf)
      return;
    MissionManager missionDataManager = DataManager.MissionDataManager;
    ushort commandMissionId = missionDataManager.GetReCommandMissionID();
    this.ItemBtn[0].m_BtnID3 = (int) commandMissionId;
    ManorAimTbl recordByKey = missionDataManager.ManorAimTable.GetRecordByKey(commandMissionId);
    missionDataManager.GetNarrative(this.NarrativeStr, ref recordByKey);
    this.MissionName.text = this.NarrativeStr.ToString();
    this.MissionName.SetAllDirty();
    this.MissionName.cachedTextGenerator.Invalidate();
    this.MissionPic.sprite = this.SpriteArray.GetSprite(6 + (int) recordByKey.UIKind);
  }

  public override void Destroy() => StringManager.Instance.DeSpawnString(this.NarrativeStr);

  public override float GetHeight()
  {
    if (DataManager.MissionDataManager.GetReCommandMissionID() == ushort.MaxValue)
    {
      this.transform.gameObject.SetActive(false);
      return 0.0f;
    }
    this.transform.gameObject.SetActive(true);
    return 136f;
  }

  public override void SetSelect(
    bool bSelect,
    int index = 0,
    uint[] reward = null,
    ushort[] rewardItem = null,
    ushort[] count = null)
  {
    this.SelectTrans.gameObject.SetActive(bSelect);
    base.SetSelect(bSelect, index, reward, rewardItem, count);
  }

  public override void TextRefresh()
  {
    base.TextRefresh();
    ((Behaviour) this.MissionName).enabled = false;
    ((Behaviour) this.MissionName).enabled = true;
  }

  public enum UIControl
  {
    Title,
    Background,
    MissionPic,
    MissionName,
    Select,
  }
}
