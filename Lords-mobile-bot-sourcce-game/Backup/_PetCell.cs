// Decompiled with JetBrains decompiler
// Type: _PetCell
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public struct _PetCell
{
  public GameObject gameobject;
  public _PetItem._ItemType cellType;
  private Transform PetTrans;
  private Transform ItemTrans;
  private GameObject PetObj;
  private GameObject ItemObj;
  private GameObject DefObj;
  private GameObject NewObj;
  private GameObject[] PetNotice;
  private bool[] PetNoticeShow;
  private UIText NumText;
  private UIText ItemNameText;
  private UIText PetNameText;
  private UIText NewText;
  private UIButton ItemBtn;
  private UIButton PetBtn;
  private CString NumStr;
  private ushort PetStoneID;
  private ushort ID;
  private int sortIndex;
  private PetManager PM;

  public _PetCell(Transform transform, IUIButtonClickHandler clickHandle)
  {
    this.cellType = _PetItem._ItemType.Def;
    this.gameobject = transform.gameObject;
    this.PetTrans = transform.GetChild(0).GetChild(0);
    this.ItemTrans = transform.GetChild(1).GetChild(1);
    this.PetObj = transform.GetChild(0).gameObject;
    this.ItemObj = transform.GetChild(1).gameObject;
    if (transform.childCount > 2)
    {
      this.DefObj = transform.GetChild(2).gameObject;
      UIButton component = this.DefObj.transform.GetChild(0).GetComponent<UIButton>();
      component.m_Handler = clickHandle;
      component.m_BtnID1 = 3;
    }
    else
      this.DefObj = (GameObject) null;
    this.PetNameText = transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
    this.ItemNameText = transform.GetChild(1).GetChild(2).GetComponent<UIText>();
    this.NumText = this.ItemTrans.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.NumStr = StringManager.Instance.SpawnString();
    this.ItemTrans.GetChild(0).SetAsLastSibling();
    this.ItemBtn = transform.GetChild(1).GetComponent<UIButton>();
    this.ItemBtn.m_Handler = clickHandle;
    this.ItemBtn.m_BtnID1 = 1;
    this.PetBtn = transform.GetChild(0).GetComponent<UIButton>();
    this.PetBtn.m_Handler = clickHandle;
    this.PetBtn.m_BtnID1 = 2;
    this.PetStoneID = this.ID = (ushort) 0;
    this.sortIndex = 0;
    this.PetNotice = new GameObject[4];
    this.PetNoticeShow = new bool[4];
    for (int index = 0; index < 4; ++index)
      this.PetNotice[index] = transform.GetChild(0).GetChild(1).GetChild(index).gameObject;
    this.NewObj = transform.GetChild(0).GetChild(3).gameObject;
    this.NewText = transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<UIText>();
    this.NewText.text = DataManager.Instance.mStringTable.GetStringByID(6048U);
    this.PM = PetManager.Instance;
  }

  private UIText NameText => this.PetObj.activeSelf ? this.PetNameText : this.ItemNameText;

  public void SetData(ushort ID, int Index, _PetItem._ItemType Type)
  {
    this.ID = ID;
    this.sortIndex = Index;
    this.cellType = Type;
    if (this.cellType == _PetItem._ItemType.Item)
    {
      if ((UnityEngine.Object) this.DefObj != (UnityEngine.Object) null)
        this.DefObj.SetActive(false);
      this.PetObj.SetActive(false);
      this.ItemObj.SetActive(true);
      GUIManager.Instance.ChangeHeroItemImg(this.ItemTrans, eHeroOrItem.Item, ID, (byte) 0, (byte) 0);
      this.ItemBtn.m_BtnID2 = (int) ID;
      this.ItemBtn.m_BtnID3 = this.sortIndex;
      this.NumStr.ClearString();
      ushort x = DataManager.Instance.GetCurItemQuantity(ID, (byte) 0);
      if (x > (ushort) 999)
        x = (ushort) 999;
      this.NumStr.IntToFormat((long) x);
      this.NumStr.AppendFormat("{0}");
      this.NumText.text = this.NumStr.ToString();
      this.NumText.SetAllDirty();
      this.NumText.cachedTextGenerator.Invalidate();
      this.NameText.text = DataManager.Instance.mStringTable.GetStringByID((uint) DataManager.Instance.EquipTable.GetRecordByKey(ID).EquipName);
    }
    else if (this.cellType == _PetItem._ItemType.Pet)
    {
      if ((UnityEngine.Object) this.DefObj != (UnityEngine.Object) null)
        this.DefObj.SetActive(false);
      this.PetObj.SetActive(true);
      this.ItemObj.SetActive(false);
      this.PetBtn.m_BtnID2 = (int) ID;
      this.PetBtn.m_BtnID3 = this.sortIndex;
      PetData petData = this.PM.GetPetData((int) this.PM.sortPetData[this.sortIndex]);
      PetTbl recordByKey = this.PM.PetTable.GetRecordByKey(ID);
      GUIManager.Instance.ChangeHeroItemImg(this.PetTrans, eHeroOrItem.Pet, petData.ID, petData.Enhance, petData.Rare, (int) petData.Level);
      this.NameText.text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.Name);
      this.PetStoneID = recordByKey.SoulID;
      this.NewObj.SetActive(petData.CheckState(PetManager.EPetState.NewPet));
    }
    else
    {
      if (!((UnityEngine.Object) this.DefObj != (UnityEngine.Object) null))
        return;
      this.DefObj.SetActive(true);
      this.PetObj.SetActive(false);
      this.ItemObj.SetActive(false);
    }
  }

  public void UpdateState(byte lockStone)
  {
    if (!this.gameobject.activeSelf || this.cellType != _PetItem._ItemType.Pet)
      return;
    if (this.sortIndex >= this.PM.sortPetData.Count)
    {
      this.gameobject.SetActive(false);
    }
    else
    {
      PetData petData = this.PM.GetPetData((int) this.PM.sortPetData[this.sortIndex]);
      Array.Clear((Array) this.PetNoticeShow, 0, this.PetNoticeShow.Length);
      byte petState = this.GetPetState(lockStone);
      if (petState > (byte) 0 && petState <= (byte) 3)
        this.PetNoticeShow[(int) petState - 1] = true;
      this.PetNoticeShow[3] = petData.CheckState(PetManager.EPetState.Training);
      for (int index = 0; index < 4; ++index)
        this.PetNotice[index].SetActive(this.PetNoticeShow[index]);
    }
  }

  private byte GetPetState(byte lockStone)
  {
    PetData petData = this.PM.GetPetData((int) this.PM.sortPetData[this.sortIndex]);
    PetTbl recordByKey1 = this.PM.PetTable.GetRecordByKey(this.ID);
    bool flag1 = (int) petData.Level == (int) petData.GetMaxLevel(false);
    bool flag2;
    if (petData.Enhance == (byte) 2 || petData.CheckState(PetManager.EPetState.Evolution))
      flag1 = flag2 = false;
    else
      flag2 = (int) DataManager.Instance.GetCurItemQuantity(this.PetStoneID, (byte) 0) >= (int) this.PM.GetEvoNeed_Stone(petData.Enhance, recordByKey1.Rare);
    if (flag1 && flag2)
      return 1;
    if (!flag1 && flag2)
      return 2;
    if (lockStone == (byte) 0)
    {
      DataManager instance = DataManager.Instance;
      ushort propertiesValue = instance.EquipTable.GetRecordByKey(instance.EquipTable.GetRecordByKey(this.PetStoneID).SyntheticParts[1].SyntheticItem).PropertiesInfo[0].PropertiesValue;
      int num = 3;
      if (petData.Enhance == (byte) 0)
        num = 1;
      else if (petData.Enhance == (byte) 1)
        num = 2;
      for (int index = 0; index < num && propertiesValue != (ushort) 0; ++index)
      {
        if (recordByKey1.PetSkill[index] != (ushort) 0 && petData.SkillLv[index] != (byte) 0)
        {
          PetSkillTbl recordByKey2 = this.PM.PetSkillTable.GetRecordByKey(recordByKey1.PetSkill[index]);
          if ((int) recordByKey2.UpLevel != (int) petData.SkillLv[index] && ((int) petData.SkillLv[index] > recordByKey2.OpenLevel.Length || (int) recordByKey2.OpenLevel[(int) petData.SkillLv[index] - 1] <= (int) petData.Level || (int) petData.SkillExp[index] != (int) this.GetNeedSkillExp(recordByKey2.Experience, petData.SkillLv[index]) - 1) && (int) instance.GetCurItemQuantity(this.PetStoneID, (byte) 0) >= (int) this.PM.PetUI_UpNeedStoneCount)
            return 3;
        }
      }
    }
    return 0;
  }

  private uint GetNeedSkillExp(ushort Experience, byte Lv)
  {
    PetSkillExpTbl recordByKey = this.PM.PetSkillExpTable.GetRecordByKey(Experience);
    return Lv >= (byte) 1 && (int) Lv <= recordByKey.ExpValue.Length ? recordByKey.ExpValue[(int) Lv - 1] : 0U;
  }

  public void TextRefresh()
  {
    if ((UnityEngine.Object) this.NumText == (UnityEngine.Object) null)
      return;
    ((Behaviour) this.NameText).enabled = false;
    ((Behaviour) this.NameText).enabled = true;
    ((Behaviour) this.NumText).enabled = false;
    ((Behaviour) this.NumText).enabled = true;
    ((Behaviour) this.NewText).enabled = false;
    ((Behaviour) this.NewText).enabled = true;
    UIHIBtn component1 = this.ItemTrans.GetComponent<UIHIBtn>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
      component1.Refresh_FontTexture();
    UIHIBtn component2 = this.PetTrans.GetComponent<UIHIBtn>();
    if (!((UnityEngine.Object) component2 != (UnityEngine.Object) null))
      return;
    component2.Refresh_FontTexture();
  }

  public void OnDestroy() => StringManager.Instance.DeSpawnString(this.NumStr);
}
