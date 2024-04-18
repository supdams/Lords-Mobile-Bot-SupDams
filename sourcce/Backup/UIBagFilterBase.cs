// Decompiled with JetBrains decompiler
// Type: UIBagFilterBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIBagFilterBase : IUpDateScrollPanel, IUIButtonClickHandler, IUIHIBtnClickHandler
{
  public Transform transform;
  public Transform ThisTransform;
  public ushort UseTargetID;
  public CString MessageStr;
  private List<Text> RefreshTextList = new List<Text>(16);

  public virtual void OnOpen(int arg1, int arg2)
  {
    this.MessageStr = StringManager.Instance.SpawnString(300);
  }

  public virtual void OnClose()
  {
    StringManager.Instance.DeSpawnString(this.MessageStr);
    DataManager.Instance.UpdateLoadItemNotify();
  }

  public virtual void UpdateUI(int arg1, int arg2)
  {
  }

  public virtual void Update()
  {
  }

  public virtual void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    for (int index = 0; index < this.RefreshTextList.Count; ++index)
    {
      if ((Object) this.RefreshTextList[index] != (Object) null && ((Behaviour) this.RefreshTextList[index]).enabled)
      {
        ((Behaviour) this.RefreshTextList[index]).enabled = false;
        ((Behaviour) this.RefreshTextList[index]).enabled = true;
      }
    }
  }

  public virtual void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
  }

  public virtual void OnButtonClick(UIButton sender)
  {
  }

  public virtual void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public virtual void UpdateTime(bool bOnSecond)
  {
  }

  public virtual void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
  }

  public virtual void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void CheckMessage(ushort ItemID)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    uint InKey = 0;
    uint ID = 0;
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    Equip recordByKey1 = instance1.EquipTable.GetRecordByKey(ItemID);
    ushort equipKind = (ushort) recordByKey1.EquipKind;
    ushort propertieskey = recordByKey1.PropertiesInfo[0].Propertieskey;
    ItemBuff recordByKey2;
    for (int index1 = 0; index1 < instance1.MaxBuffTableCount; ++index1)
    {
      recordByKey2 = instance1.ItemBuffTable.GetRecordByKey(instance1.m_RecvItemBuffData[index1].ID);
      Equip recordByKey3 = instance1.EquipTable.GetRecordByKey(recordByKey2.BuffItemID);
      if ((byte) ((uint) equipKind - 1U) == (byte) 13 && propertieskey == (ushort) 1)
      {
        if (DataManager.Instance.bHaveWarBuff)
        {
          GUIManager.Instance.AddHUDMessage(instance1.mStringTable.GetStringByID(9943U), (ushort) byte.MaxValue);
          return;
        }
        for (int index2 = 0; index2 < (int) instance1.MaxMarchEventNum; ++index2)
        {
          EMarchEventType type = instance1.MarchEventData[index2].Type;
          if ((instance1.MarchEventData[index2].IsAmbushCamp() || instance1.MarchEventData[index2].IsAmbushCampMarching() || instance1.MarchEventData[index2].IsAmbushCampReturn() || type == EMarchEventType.EMET_AttackMarching || type == EMarchEventType.EMET_ScoutMarching || type == EMarchEventType.EMET_InforceStanby || type == EMarchEventType.EMET_RallyStanby || type >= EMarchEventType.EMET_InforceMarching && type <= EMarchEventType.EMET_RallyAttack || type == EMarchEventType.EMET_AttackReturn || type == EMarchEventType.EMET_RallyReturn || type == EMarchEventType.EMET_ScoutReturn || type == EMarchEventType.EMET_InfroceReturn || type == EMarchEventType.EMET_AttackRetreat || type == EMarchEventType.EMET_RallyRetreat || (type == EMarchEventType.EMET_Camp || type == EMarchEventType.EMET_CampMarching || type == EMarchEventType.EMET_CampReturn) && DataManager.MapDataController.getYolkIDbyPointCode(instance1.MarchEventData[index2].Point.zoneID, instance1.MarchEventData[index2].Point.pointID, (ushort) 0) < (ushort) 40) && instance1.MarchEventData[index2].bRallyHost != (byte) 3 && instance1.MarchEventData[index2].bRallyHost != (byte) 4)
          {
            GUIManager.Instance.OpenMessageBox(instance1.mStringTable.GetStringByID(614U), instance1.mStringTable.GetStringByID(7647U));
            return;
          }
        }
        if (instance1.TotalSoldier_Embassy > 0U || instance1.PrisonerNum > (byte) 0 || AmbushManager.Instance.GetMaxTroop() > 0U)
        {
          instance2.OpenOKCancelBox(instance2.FindMenu(EGUIWindow.UI_BagFilter), instance1.mStringTable.GetStringByID(614U), instance1.mStringTable.GetStringByID(8240U), (int) ItemID, YesText: instance1.mStringTable.GetStringByID(3U), NoText: instance1.mStringTable.GetStringByID(617U));
          return;
        }
      }
      if (instance1.m_RecvItemBuffData[index1].bEnable && recordByKey2.BuffKind == (byte) 3)
        InKey = (uint) recordByKey2.BuffID;
      if (!flag2 && (int) recordByKey3.EquipKind == (int) equipKind && (int) recordByKey3.PropertiesInfo[0].Propertieskey == (int) propertieskey)
      {
        flag1 = recordByKey2.BuffKind == (byte) 3;
        switch ((byte) ((uint) equipKind - 1U))
        {
          case 9:
            switch ((ECaseByCaseType) propertieskey)
            {
              case ECaseByCaseType.ECBCT_ExpPercent:
              case ECaseByCaseType.ECBCT_Monster:
                ID = (uint) recordByKey2.BuffNameID;
                break;
            }
            break;
          case 11:
            switch ((ESpeedUpPercent) propertieskey)
            {
              case ESpeedUpPercent.EUP_MARCH_SPEED:
              case ESpeedUpPercent.EUP_BUILD_SPEED:
              case ESpeedUpPercent.EUP_RESEARCH_SPEED:
              case ESpeedUpPercent.EUP_TRAINING_SPEED:
              case ESpeedUpPercent.EUP_TRAP_SPEED:
              case ESpeedUpPercent.EUP_RESOURCE_SPEED:
              case ESpeedUpPercent.EUP_PET_FUSION_SPEED:
                ID = (uint) recordByKey2.BuffNameID;
                break;
            }
            break;
          case 13:
            EShieldType eshieldType = (EShieldType) propertieskey;
            if (eshieldType == EShieldType.EST_Shield && instance1.m_BuffListOpenIcon == (byte) 1 || eshieldType == EShieldType.EST_Investigate)
            {
              ID = (uint) recordByKey2.BuffNameID;
              break;
            }
            break;
          case 14:
            switch ((EDefenseType) propertieskey)
            {
              case EDefenseType.EDT_TroopAtk:
              case EDefenseType.EDT_TorrpDef:
              case EDefenseType.EDT_Salaries:
              case EDefenseType.EDT_TroopScale:
              case EDefenseType.EDT_Crafty:
              case EDefenseType.EDT_TroopAtk_Reduce:
              case EDefenseType.EDT_TroopDef_Reduce:
                ID = (uint) recordByKey2.BuffNameID;
                break;
            }
            break;
          case 15:
            ID = (uint) recordByKey2.BuffNameID;
            break;
        }
        flag3 = instance1.m_RecvItemBuffData[index1].bEnable;
        flag2 = true;
      }
    }
    if (ID > 0U)
    {
      this.MessageStr.ClearString();
      if (flag1 && InKey > 0U)
      {
        recordByKey2 = instance1.ItemBuffTable.GetRecordByKey((ushort) InKey);
        instance1.EquipTable.GetRecordByKey(recordByKey2.BuffItemID);
        uint buffNameId = (uint) recordByKey2.BuffNameID;
        this.MessageStr.StringToFormat(instance1.mStringTable.GetStringByID(ID));
        this.MessageStr.StringToFormat(instance1.mStringTable.GetStringByID(buffNameId));
        this.MessageStr.AppendFormat(instance1.mStringTable.GetStringByID(7247U));
      }
      else if (flag3)
      {
        this.MessageStr.StringToFormat(instance1.mStringTable.GetStringByID(ID));
        this.MessageStr.StringToFormat(instance1.mStringTable.GetStringByID(ID));
        this.MessageStr.AppendFormat(instance1.mStringTable.GetStringByID(7247U));
      }
      else
      {
        this.OnOKCancelBoxClick(true, (int) ItemID, 0);
        return;
      }
      instance2.OpenOKCancelBox(instance2.FindMenu(EGUIWindow.UI_BagFilter), instance1.mStringTable.GetStringByID(614U), this.MessageStr.ToString(), (int) ItemID, YesText: instance1.mStringTable.GetStringByID(3U), NoText: instance1.mStringTable.GetStringByID(617U));
    }
    else
      this.OnOKCancelBoxClick(true, (int) ItemID, 0);
  }

  public bool CheckItemEnergy(ushort ItemID, byte BuyAndUse)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    Equip recordByKey = instance1.EquipTable.GetRecordByKey(ItemID);
    if ((byte) ((uint) recordByKey.EquipKind - 1U) != (byte) 9 || (byte) recordByKey.PropertiesInfo[0].Propertieskey != (byte) 30 || (int) DataManager.Instance.RoleAttr.MonsterPoint == (int) DataManager.Instance.GetMaxMonsterPoint() || (long) instance1.RoleAttr.MonsterPoint + (long) ((int) recordByKey.PropertiesInfo[1].Propertieskey * (int) recordByKey.PropertiesInfo[1].PropertiesValue) < (long) instance1.GetMaxMonsterPoint())
      return false;
    instance2.OpenOKCancelBox(instance2.FindMenu(EGUIWindow.UI_BagFilter), instance1.mStringTable.GetStringByID(685U), instance1.mStringTable.GetStringByID(8479U), (int) recordByKey.EquipKey, (int) BuyAndUse, instance1.mStringTable.GetStringByID(3U), instance1.mStringTable.GetStringByID(188U));
    return true;
  }

  protected void AddRefreshText(Text text) => this.RefreshTextList.Add(text);

  public enum BagUpdateType
  {
    Item = 0,
    AutoUseRes = 1,
    Buy = 65536, // 0x00010000
    BuyConfirm = 65537, // 0x00010001
    SpeedupImmed = 65538, // 0x00010002
    BuyNumConfirm = 65539, // 0x00010003
    GiftShopErr = 65540, // 0x00010004
  }
}
