// Decompiled with JetBrains decompiler
// Type: UITeamSave
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class UITeamSave : UISaveList
{
  private CString[] DefaultTeamName;

  public override void OnOpen(int arg1, int arg2)
  {
    RectTransform component1 = this.transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<RectTransform>();
    RectTransform component2 = this.transform.GetChild(2).GetChild(0).GetChild(2).GetComponent<RectTransform>();
    ((Component) component1).gameObject.SetActive(false);
    component2.anchoredPosition = new Vector2(640f, component1.anchoredPosition.y);
    component2.sizeDelta = component1.sizeDelta;
    this.DefaultTeamName = new CString[DataManager.Instance.mTroopMemoryData.Length];
    for (int index = 0; index < this.DefaultTeamName.Length; ++index)
      this.DefaultTeamName[index] = StringManager.Instance.SpawnString();
    base.OnOpen(arg1, arg2);
    this.Titles[0].text = DataManager.Instance.mStringTable.GetStringByID(990U);
  }

  public override void OnButtonClick(UIButton sender)
  {
    base.OnButtonClick(sender);
    if (sender.m_BtnID1 != 3)
      return;
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_Expedition, sender.m_BtnID2, 6);
  }

  public override short GetResearchIndex()
  {
    byte techLevel = DataManager.Instance.GetTechLevel(this.GetResearchID());
    return techLevel == (byte) 5 ? (short) -1 : (short) techLevel;
  }

  public override byte GetItemNum()
  {
    byte techLevel = DataManager.Instance.GetTechLevel(this.GetResearchID());
    return techLevel == (byte) 5 ? (byte) 5 : (byte) ((uint) techLevel + 1U);
  }

  public override ushort GetResearchID() => 120;

  public override void SetItemData(ref UISaveList.ItemEdit Data, int dataIdx)
  {
    base.SetItemData(ref Data, dataIdx);
    DataManager instance = DataManager.Instance;
    if (instance.mTroopMemoryData[dataIdx].Label == null || instance.mTroopMemoryData[dataIdx].Label == string.Empty)
    {
      this.DefaultTeamName[dataIdx].ClearString();
      this.DefaultTeamName[dataIdx].IntToFormat((long) (dataIdx + 1));
      this.DefaultTeamName[dataIdx].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(993U));
      Data.Title.text = this.DefaultTeamName[dataIdx].ToString();
      Data.Title.SetAllDirty();
      Data.Title.cachedTextGenerator.Invalidate();
    }
    else
      Data.Title.text = DataManager.Instance.mTroopMemoryData[dataIdx].Label;
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 == 1)
    {
      this.UpdateSaveList();
    }
    else
    {
      if (arg1 != -1)
        return;
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
    }
  }

  public override void OnClose()
  {
    for (int index = 0; index < this.DefaultTeamName.Length; ++index)
      StringManager.Instance.DeSpawnString(this.DefaultTeamName[index]);
    base.OnClose();
  }
}
