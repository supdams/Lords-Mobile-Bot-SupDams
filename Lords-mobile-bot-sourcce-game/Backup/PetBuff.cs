// Decompiled with JetBrains decompiler
// Type: PetBuff
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class PetBuff : GUIWindow
{
  public static bool bCasting;
  public static bool Refreshed;
  public static bool SkillInit;
  public static int[] ActiveSkill = new int[2];
  public static List<PetBuff.PetSkillData>[] PetSkillList = new List<PetBuff.PetSkillData>[5];
  public static List<PetBuff.PetSkill> PetSkills = new List<PetBuff.PetSkill>();
  public static PetBuff.PetSkillComparer PSC = new PetBuff.PetSkillComparer();

  protected void SetSkill(bool Casting = true)
  {
    if (!Casting)
      PetBuff.Refreshed = true;
    if (!PetBuff.SkillInit)
      PetBuff.UpdateSkill();
    PetBuff.bCasting = Casting;
    for (int index = 0; index < PetBuff.PetSkillList.Length; ++index)
    {
      if (PetBuff.PetSkillList[index] != null)
        PetBuff.PetSkillList[index].Sort((IComparer<PetBuff.PetSkillData>) PetBuff.PSC);
    }
  }

  public static void Clear() => PetBuff.SkillInit = false;

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!bOK || !(bool) (Object) menu)
      return;
    menu.OpenMenu(EGUIWindow.UI_PetFusion, 1, arg1);
  }

  public static void Update(int arg1, int arg2 = 0, bool bCast = false)
  {
    if (bCast)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetSkill, arg1);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetBuff, arg1);
  }

  public static bool ShowActive(byte Type = 1)
  {
    return PetBuff.ActiveSkill[(int) Type >= PetBuff.ActiveSkill.Length ? 0 : (int) Type] > 0;
  }

  public static bool CheckActive(int PointID, byte Type = 1)
  {
    return PetBuff.ShowActive(Type) && (Object) GUIManager.Instance.OpenMenu(EGUIWindow.UI_PetSkill, PointID, (int) Type + 1, bSecWindow: true) != (Object) null;
  }

  public static bool CheckNegative() => !PetBuff.Refreshed;

  public static bool UpdateSkill(int arg = 0)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (Object) menu)
    {
      menu.m_PetSkillBtnFlashGO.GetComponent<uTweener>().enabled = !PetBuff.Refreshed;
      ((Graphic) menu.m_PetSkillBtnFlashGO.GetComponent<Image>()).color = Color.white;
    }
    if (arg > 0 || !PetBuff.SkillInit)
    {
      PetBuff.SkillInit = true;
      for (int index = 0; index < PetBuff.ActiveSkill.Length; ++index)
        PetBuff.ActiveSkill[index] = 0;
      for (int index = 0; index < PetBuff.PetSkillList.Length; ++index)
      {
        if (PetBuff.PetSkillList[index] == null)
          PetBuff.PetSkillList[index] = new List<PetBuff.PetSkillData>();
        else
          PetBuff.PetSkillList[index].Clear();
      }
      for (int Index = 0; Index < (int) PetManager.Instance.PetDataCount; ++Index)
      {
        PetData petData = PetManager.Instance.GetPetData((int) (byte) Index);
        if (petData != null)
        {
          PetTbl recordByKey1 = PetManager.Instance.PetTable.GetRecordByKey(petData.ID);
          for (byte slot = 0; recordByKey1.PetSkill != null && (int) slot < recordByKey1.PetSkill.Length; ++slot)
          {
            if (recordByKey1.PetSkill[(int) slot] > (ushort) 0 && petData.SkillLv != null && (int) slot < petData.SkillLv.Length && (int) petData.Enhance >= (int) slot)
            {
              PetSkillTbl recordByKey2 = PetManager.Instance.PetSkillTable.GetRecordByKey(recordByKey1.PetSkill[(int) slot]);
              if (recordByKey2.Subject > (byte) 0 && recordByKey2.Type == (byte) 1 && recordByKey2.Class >= (byte) 1 && (int) recordByKey2.Class <= PetBuff.PetSkillList.Length && (int) recordByKey2.Subject <= PetBuff.ActiveSkill.Length)
                PetBuff.PetSkillList[(int) recordByKey2.Class - 1].Add(new PetBuff.PetSkillData((uint) recordByKey1.PetSkill[(int) slot], slot, recordByKey2.Subject, petData.ID));
            }
          }
        }
      }
      if (arg > 0)
        PetBuff.Update(6, bCast: true);
    }
    for (int index = 0; index < PetBuff.ActiveSkill.Length; ++index)
    {
      if (PetBuff.ActiveSkill[index] > 0)
        return true;
    }
    return false;
  }

  public static void UpdateFatigue()
  {
    long num = DataManager.Instance.ServerTime - DataManager.Instance.RoleAttr.LastPetSkillFatigueTime;
    if (DataManager.Instance.RoleAttr.PetSkillFatigue <= (ushort) 0 || DataManager.Instance.RoleAttr.FatigueRestoreSpeed <= (ushort) 0 || num <= (long) DataManager.Instance.RoleAttr.FatigueRestoreSpeed)
      return;
    if ((long) DataManager.Instance.RoleAttr.PetSkillFatigue < num / (long) DataManager.Instance.RoleAttr.FatigueRestoreSpeed)
      PetManager.Instance.SetSkillFatigue((ushort) 0, (ushort) 0, 0L);
    else
      PetManager.Instance.SetSkillFatigue((ushort) ((ulong) DataManager.Instance.RoleAttr.PetSkillFatigue - (ulong) num / (ulong) DataManager.Instance.RoleAttr.FatigueRestoreSpeed), DataManager.Instance.RoleAttr.FatigueRestoreSpeed, DataManager.Instance.ServerTime - (long) ((int) num % (int) DataManager.Instance.RoleAttr.FatigueRestoreSpeed));
  }

  public static void Update()
  {
    PetBuff.UpdateSkill(1);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 26);
  }

  public static bool ShowButt(int arg)
  {
    return PetBuff.UpdateSkill(arg) && PetBuff.ShowActive((byte) 0) || PetManager.Instance.BuffImmune.BeginTime > 0L || PetManager.Instance.NegBuff.Count > 0 || DataManager.Instance.RoleAttr.PetSkillFatigue > (ushort) 0;
  }

  public static ushort CheckCount()
  {
    return (ushort) (PetManager.Instance.PosBuff.Count + PetManager.Instance.NegBuff.Count + (PetManager.Instance.BuffImmune.BeginTime <= 0L ? 0 : 1));
  }

  public static bool CheckFlash() => PetManager.Instance.NegBuff.Count > 0;

  public static long CheckSkillBuff(ushort Id, out uint Require)
  {
    Require = 480U;
    if (Id == (ushort) 0)
      return DataManager.Instance.ServerTime < PetManager.Instance.BuffImmune.BeginTime + (long) PetManager.Instance.BuffImmune.RequireTime ? PetManager.Instance.BuffImmune.BeginTime + (long) PetManager.Instance.BuffImmune.RequireTime - DataManager.Instance.ServerTime : 0L;
    byte index;
    if (!PetManager.Instance.PosBuff.TryGetValue(Id, out index) && !PetManager.Instance.NegBuff.TryGetValue(Id, out index))
      return 0;
    Require = PetManager.Instance.BuffInfo[(int) index].RequireTime;
    return DataManager.Instance.ServerTime < PetManager.Instance.BuffInfo[(int) index].BeginTime + (long) PetManager.Instance.BuffInfo[(int) index].RequireTime ? PetManager.Instance.BuffInfo[(int) index].BeginTime + (long) PetManager.Instance.BuffInfo[(int) index].RequireTime - DataManager.Instance.ServerTime : 0L;
  }

  public static long CheckSkillBuff(ushort Id = 0)
  {
    byte index;
    return Id == (ushort) 0 ? (DataManager.Instance.ServerTime < PetManager.Instance.BuffImmune.BeginTime + (long) PetManager.Instance.BuffImmune.RequireTime ? PetManager.Instance.BuffImmune.BeginTime + (long) PetManager.Instance.BuffImmune.RequireTime - DataManager.Instance.ServerTime : 0L) : ((PetManager.Instance.PosBuff.TryGetValue(Id, out index) || PetManager.Instance.NegBuff.TryGetValue(Id, out index)) && DataManager.Instance.ServerTime < PetManager.Instance.BuffInfo[(int) index].BeginTime + (long) PetManager.Instance.BuffInfo[(int) index].RequireTime ? PetManager.Instance.BuffInfo[(int) index].BeginTime + (long) PetManager.Instance.BuffInfo[(int) index].RequireTime - DataManager.Instance.ServerTime : 0L);
  }

  public long CheckSkillBuff(byte idx)
  {
    return (int) idx < PetManager.Instance.BuffInfo.Count && DataManager.Instance.ServerTime < PetManager.Instance.BuffInfo[(int) idx].BeginTime + (long) PetManager.Instance.BuffInfo[(int) idx].RequireTime ? PetManager.Instance.BuffInfo[(int) idx].BeginTime + (long) PetManager.Instance.BuffInfo[(int) idx].RequireTime - DataManager.Instance.ServerTime : 0L;
  }

  public static long CheckSkillCD(ushort id)
  {
    long num = 0;
    if (id > (ushort) 0 && PetManager.Instance.CDFinder != null && PetManager.Instance.CDFinder.TryGetValue(id, out num))
    {
      if (DataManager.Instance.ServerTime < num)
        return num - DataManager.Instance.ServerTime;
      num = 0L;
      PetManager.Instance.CDFinder.Remove(id);
      for (int index = 0; index < PetManager.Instance.CoolDown.Count; ++index)
      {
        if ((int) PetManager.Instance.CoolDown[index].SkillID == (int) id)
        {
          PetManager.Instance.CoolDown[index].Clear();
          return num;
        }
      }
    }
    return num;
  }

  public struct SkillPanelItem
  {
    public int ID;
    public bool Init;
    public ushort CoolDown;
    public GameObject Item;
    public Text[] Text;

    public void Rebuilt()
    {
      if (this.Text == null)
        return;
      for (int index = 0; index < this.Text.Length; ++index)
      {
        if ((bool) (Object) this.Text[index])
        {
          ((Behaviour) this.Text[index]).enabled = false;
          ((Behaviour) this.Text[index]).enabled = true;
        }
      }
    }
  }

  public struct PetSkillData
  {
    public uint Id;
    public byte Slot;
    public ushort Pet;
    public byte Subject;

    public PetSkillData(uint id, byte slot, byte sub, ushort pet)
    {
      this.Id = id;
      this.Pet = pet;
      this.Slot = slot;
      this.Subject = sub;
      ++PetBuff.ActiveSkill[(int) sub - 1];
    }
  }

  public struct PetSkill
  {
    public uint ID;
    public int Idx;
    public byte Slot;
    public byte Class;
    public ushort Pet;
    public ulong Power;

    public PetSkill(uint id, int idx, byte cls, byte slot, ushort pet)
    {
      this.ID = id;
      this.Idx = idx;
      this.Class = cls;
      this.Slot = slot;
      this.Pet = pet;
      this.Power = 0UL;
    }
  }

  public class PetSkillComparer : IComparer<PetBuff.PetSkillData>
  {
    public int Compare(PetBuff.PetSkillData x, PetBuff.PetSkillData y)
    {
      if (x.Id > y.Id)
        return 1;
      return x.Id < y.Id ? -1 : 0;
    }
  }
}
