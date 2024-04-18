// Decompiled with JetBrains decompiler
// Type: JailBuildNotice
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class JailBuildNotice : MonoBehaviour
{
  private SpriteRenderer JailNotice;
  private MapSpriteManager mapspriteManager;
  private byte PrisonerIndex = byte.MaxValue;
  private long TotalTime;
  private DataManager DM = DataManager.Instance;

  public void Init(MapSpriteManager mapspriteManager)
  {
    this.mapspriteManager = mapspriteManager;
    this.JailNotice = new GameObject("ManorJailIcon", new System.Type[1]
    {
      typeof (SpriteRenderer)
    }).GetComponent<SpriteRenderer>();
    this.JailNotice.sprite = mapspriteManager.GetSpriteByName("prompt_09");
    this.JailNotice.material = mapspriteManager.SpriteMaterial;
    this.JailNotice.color = Color.black;
    this.JailNotice.sortingOrder = -1;
    this.JailNotice.transform.SetParent(this.transform);
    this.JailNotice.transform.localScale = Vector3.one;
    this.JailNotice.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    this.JailNotice.transform.localPosition = new Vector3(0.31f, 1.49f, 0.27f);
    this.Hide();
    this.UpdateData();
  }

  public void Hide() => this.JailNotice.enabled = false;

  private void Show() => this.JailNotice.enabled = true;

  public void UpdateData()
  {
    if (this.DM.Prisoner_Requested && this.DM.PrisonerNum > (byte) 0)
    {
      this.PrisonerIndex = this.DM.sortedPrisonerList[0];
      if (!this.DM.MySysSetting.bShowPrison || this.DM.PrisonerList[(int) this.PrisonerIndex].nowStat != PrisonerState.WaitForExecute)
        this.PrisonerIndex = byte.MaxValue;
    }
    else
      this.PrisonerIndex = byte.MaxValue;
    if (this.PrisonerIndex != byte.MaxValue)
      return;
    this.Hide();
  }

  public void UpdateTime()
  {
    if (this.PrisonerIndex == byte.MaxValue)
      return;
    this.TotalTime = this.DM.PrisonerList[(int) this.PrisonerIndex].StartActionTime + (long) this.DM.PrisonerList[(int) this.PrisonerIndex].TotalTime - this.DM.ServerTime;
    if (this.TotalTime < 0L)
      this.TotalTime = 0L;
    if (this.TotalTime <= 21600L)
      this.Show();
    else
      this.Hide();
  }
}
