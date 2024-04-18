// Decompiled with JetBrains decompiler
// Type: _MissionSlot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class _MissionSlot
{
  public Transform transform;
  public Transform SelectTrans;
  public UIText NameText;
  public UIButton Reward;
  public UIButton ItemBtn;
  public CString NameStr;
  private CanvasGroup RewardAlpha;
  public iMissionTimeDelta TimdHandle;

  public void Init(Transform transform, UIMissionItem win)
  {
    this.transform = transform;
    this.NameStr = StringManager.Instance.SpawnString(100);
    this.NameText = transform.GetChild(0).GetComponent<UIText>();
    transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
    this.Reward = transform.GetChild(1).GetComponent<UIButton>();
    this.Reward.m_Handler = (IUIButtonClickHandler) win;
    this.Reward.m_BtnID1 = 7;
    this.ItemBtn = transform.GetComponent<UIButton>();
    this.ItemBtn.m_BtnID1 = 11;
    this.RewardAlpha = transform.GetChild(1).GetChild(0).GetComponent<CanvasGroup>();
    transform.GetChild(1).GetChild(1).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(1542U);
    this.SelectTrans = transform.GetChild(2);
  }

  public void SetText(CString Text)
  {
    this.NameStr.ClearString();
    this.NameStr.Append(Text);
    this.NameText.text = this.NameStr.ToString();
    this.NameText.SetAllDirty();
    this.NameText.cachedTextGenerator.Invalidate();
  }

  public void Destroy() => StringManager.Instance.DeSpawnString(this.NameStr);

  public void Update()
  {
    if (!((Component) this.Reward).gameObject.activeSelf || this.TimdHandle == null)
      return;
    float deltaTime = this.TimdHandle.GetDeltaTime();
    this.RewardAlpha.alpha = (double) deltaTime <= 1.0 ? deltaTime : 2f - deltaTime;
  }

  public enum UIControl
  {
    Text,
    RewardBtn,
    Select,
  }
}
