// Decompiled with JetBrains decompiler
// Type: King
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class King : _WhoReward
{
  public King()
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.TitleStr = mStringTable.GetStringByID(9709U);
    this.MainStr = mStringTable.GetStringByID(9710U);
    if (!DataManager.MapDataController.IsKing() || !DataManager.MapDataController.IsInMyAllianceKingdom())
      return;
    this.IsKing = true;
  }

  public override bool CheckReward()
  {
    return DataManager.MapDataController.CheckKingFunction(eKingFunction.eReward);
  }

  public override bool CheckAndOpenList(int ID)
  {
    if (DataManager.MapDataController.IsPeaceState(true, (byte) 0))
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_DevelopmentDetails, 7, ID);
    return false;
  }
}
