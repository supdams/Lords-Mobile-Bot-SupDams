// Decompiled with JetBrains decompiler
// Type: ArmyKindHint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class ArmyKindHint : SimpleHintKind
{
  string SimpleHintKind.SetContent(CString Content, int Parm1, int Parm2)
  {
    Content.ClearString();
    DataManager instance = DataManager.Instance;
    Content.Append("<color=#FFF799FF>");
    Content.Append(instance.mStringTable.GetStringByID((uint) instance.SoldierDataTable.GetRecordByKey((ushort) (Parm1 + 1)).Name));
    Content.Append("</color>");
    Content.Append('\n');
    Content.IntToFormat((long) ((Parm1 & 3) + 1));
    if (Parm1 < 16)
      Content.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) (3841 + (Parm1 >> 2))));
    else
      Content.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) (12079 + (Parm1 - 16 >> 2))));
    Content.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12078U));
    return Content.ToString();
  }
}
