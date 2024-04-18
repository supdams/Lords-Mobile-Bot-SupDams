// Decompiled with JetBrains decompiler
// Type: DukeNukem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public static class DukeNukem
{
  public static byte Result;
  public static byte Wonder;
  public static byte Dukedom;
  public static ushort[] Kid;

  public static void FederalOrderKingdom(MessagePacket MP)
  {
    DukeNukem.Result = MP.ReadByte();
    DukeNukem.Wonder = MP.ReadByte();
    DukeNukem.Dukedom = MP.ReadByte();
    DukeNukem.Kid = new ushort[(int) DukeNukem.Dukedom];
    for (int index = 0; index < (int) DukeNukem.Dukedom; ++index)
      DukeNukem.Kid[index] = MP.ReadUShort();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, 0);
  }
}
