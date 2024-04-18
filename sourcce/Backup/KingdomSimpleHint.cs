// Decompiled with JetBrains decompiler
// Type: KingdomSimpleHint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class KingdomSimpleHint : SimpleHintKind
{
  string SimpleHintKind.SetContent(CString Content, int Parm1, int Parm2)
  {
    Content.ClearString();
    TitleData recordByKey = DataManager.Instance.TitleDataN.GetRecordByKey((ushort) Parm2);
    Content.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.StringID));
    Content.AppendFormat(DataManager.Instance.mStringTable.GetStringByID((uint) Parm1));
    return Content.ToString();
  }
}
