// Decompiled with JetBrains decompiler
// Type: Nobility
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class Nobility : _WhoReward
{
  public Nobility()
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.TitleStr = mStringTable.GetStringByID(11084U);
    this.MainStr = mStringTable.GetStringByID(11060U);
  }

  public override bool CheckReward()
  {
    return DataManager.MapDataController.CheckNobilityFunction(eNobilityFunction.eReward, DataManager.Instance.KingGift.WonderID);
  }

  public override bool CheckAndOpenList(int ID)
  {
    if (!DataManager.MapDataController.IsPeaceState(true, DataManager.Instance.KingGift.WonderID))
      return false;
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_DevelopmentDetails, 9, ID);
    return true;
  }
}
