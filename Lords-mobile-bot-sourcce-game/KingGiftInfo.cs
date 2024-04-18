// Decompiled with JetBrains decompiler
// Type: KingGiftInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class KingGiftInfo
{
  private int _DataIdx;
  public ushort ItemID;
  public byte GiftCount;
  public byte ListCount;
  public KingGiftInfo.GiftList[] List = new KingGiftInfo.GiftList[30];

  public KingGiftInfo(int index) => this._DataIdx = index;

  public int DataIdx => this._DataIdx;

  public byte GetRemainCount()
  {
    return (int) this.GiftCount > (int) this.ListCount ? (byte) ((uint) this.GiftCount - (uint) this.ListCount) : (byte) 0;
  }

  public struct GiftList
  {
    public CString Tag;
    public CString TageName;
    public CString Name;
    public long UserID;

    public void Set(CString tagName, CString name, long userID)
    {
      if (this.Name == null)
      {
        this.Name = new CString(13);
        this.Tag = new CString(4);
        this.TageName = new CString(50);
      }
      this.Tag.ClearString();
      this.Tag.Append(tagName);
      this.Name.ClearString();
      this.Name.Append(name);
      this.UserID = userID;
    }
  }
}
