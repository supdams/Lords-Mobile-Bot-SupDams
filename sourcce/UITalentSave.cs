// Decompiled with JetBrains decompiler
// Type: UITalentSave
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class UITalentSave : UISaveList
{
  private byte[] UISaved;

  public override void OnOpen(int arg1, int arg2)
  {
    base.OnOpen(arg1, arg2);
    this.Titles[0].text = DataManager.Instance.mStringTable.GetStringByID(923U);
    this.UISaved = GUIManager.Instance.TalentSaveSaved;
    this.SaveScrollPanel.GoTo((int) this.UISaved[0], GameConstants.ConvertBytesToFloat(this.UISaved, 1));
  }

  public override void OnButtonClick(UIButton sender)
  {
    base.OnButtonClick(sender);
    switch ((UISaveList.ClickType) sender.m_BtnID1)
    {
      case UISaveList.ClickType.Apply:
        GUIManager.Instance.UseOrSpend((ushort) 1008, DataManager.Instance.mStringTable.GetStringByID(926U), (ushort) 0, (ushort) 1, (ushort) (sender.m_BtnID2 - 1), maxcount: (ushort) 0);
        break;
      case UISaveList.ClickType.Setup:
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_Talent, sender.m_BtnID2);
        break;
    }
  }

  public override short GetResearchIndex()
  {
    AttribValManager attribVal = DataManager.Instance.AttribVal;
    return attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_QUICK_TALENT_SET) == 10U ? (short) -1 : (short) attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_QUICK_TALENT_SET);
  }

  public override byte GetItemNum()
  {
    AttribValManager attribVal = DataManager.Instance.AttribVal;
    return attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_QUICK_TALENT_SET) == 10U ? (byte) 10 : (byte) (attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_QUICK_TALENT_SET) + 1U);
  }

  public override ushort GetResearchID() => 117;

  public override void SetItemData(ref UISaveList.ItemEdit Data, int dataIdx)
  {
    base.SetItemData(ref Data, ++dataIdx);
    Data.Title.text = DataManager.Instance.SaveTalentData[dataIdx].GetTagName().ToString();
    Data.Title.SetAllDirty();
    Data.Title.cachedTextGenerator.Invalidate();
    if (DataManager.Instance.SaveTalentData[dataIdx].NoUseTalent == (byte) 1)
      Data.SetaApplyEnable(false);
    else
      Data.SetaApplyEnable(true);
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
    base.OnClose();
    this.UISaved[0] = (byte) this.SaveScrollPanel.GetBeginIdx();
    GameConstants.GetBytes(this.ScrollContentRect.anchoredPosition.y, this.UISaved, 1);
  }
}
