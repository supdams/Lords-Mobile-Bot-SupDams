// Decompiled with JetBrains decompiler
// Type: CastleSkinHint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class CastleSkinHint : SimpleHintKind
{
  private CString[] EffectStr = new CString[2];

  public CastleSkinHint()
  {
    for (int index = 0; index < this.EffectStr.Length; ++index)
      this.EffectStr[index] = new CString(128);
  }

  string SimpleHintKind.SetContent(CString Content, int Parm1, int Parm2)
  {
    Content.ClearString();
    CastleSkin castleSkin = GUIManager.Instance.BuildingData.castleSkin;
    DataManager instance = DataManager.Instance;
    CastleEnhanceTbl castleEnhanceData = castleSkin.GetCastleEnhanceData((byte) Parm1, (byte) 0);
    CastleSkinTbl recordByKey1 = castleSkin.CastleSkinTable.GetRecordByKey((ushort) (byte) Parm1);
    bool flag = false;
    for (int index = 0; index < 2; ++index)
    {
      Effect recordByKey2 = instance.EffectData.GetRecordByKey(recordByKey1.Effect[index]);
      if (recordByKey2.ValueID == (ushort) 4378)
        flag = true;
      this.EffectStr[index].ClearString();
      this.EffectStr[index].StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey2.String_infoID));
      if (flag)
      {
        this.EffectStr[index].DoubleToFormat((double) castleEnhanceData.Value[index] / 100.0, 2, false);
        this.EffectStr[index].AppendFormat("{0}{1}%");
      }
      else
      {
        this.EffectStr[index].IntToFormat((long) castleEnhanceData.Value[index]);
        this.EffectStr[index].AppendFormat("{0}{1}");
      }
    }
    if (castleSkin.CheckUnlock((byte) Parm1))
      Content.StringToFormat(instance.mStringTable.GetStringByID(9688U));
    else
      Content.StringToFormat(instance.mStringTable.GetStringByID(9687U));
    Content.StringToFormat(this.EffectStr[0]);
    Content.StringToFormat(this.EffectStr[1]);
    Content.StringToFormat(instance.mStringTable.GetStringByID(9689U));
    Content.AppendFormat("{0}\n{1}\n{2}\n{3}");
    return Content.ToString();
  }
}
