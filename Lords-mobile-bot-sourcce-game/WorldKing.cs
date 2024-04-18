// Decompiled with JetBrains decompiler
// Type: WorldKing
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class WorldKing : _WhoReward
{
  public WorldKing()
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.TitleStr = mStringTable.GetStringByID(9798U);
    this.MainStr = mStringTable.GetStringByID(9797U);
    if (!DataManager.MapDataController.IsWorldKing())
      return;
    this.IsKing = true;
  }

  public override bool CheckReward()
  {
    return DataManager.MapDataController.CheckWorldKingFunction(eWorldKingFunction.eReward);
  }

  public override bool CheckAndOpenList(int ID)
  {
    if (!DataManager.MapDataController.IsPeaceState(true, (byte) 0))
      return false;
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_DevelopmentDetails, 8, ID);
    return true;
  }
}
