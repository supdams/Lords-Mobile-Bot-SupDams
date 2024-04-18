// Decompiled with JetBrains decompiler
// Type: NormalSimpleHint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class NormalSimpleHint : SimpleHintKind
{
  string SimpleHintKind.SetContent(CString Content, int Parm1, int Parm2)
  {
    return DataManager.Instance.mStringTable.GetStringByID((uint) Parm1);
  }
}
