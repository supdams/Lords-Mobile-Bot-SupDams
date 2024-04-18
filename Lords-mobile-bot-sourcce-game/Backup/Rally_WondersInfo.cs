// Decompiled with JetBrains decompiler
// Type: Rally_WondersInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class Rally_WondersInfo : Rally
{
  private int WonderMapID;
  private string WonderStr;
  private CString LeftCancelTextStr;
  private bool HideChangeDefence;

  public Rally_WondersInfo(Transform transform, int DataIndex)
    : base(transform, DataIndex)
  {
  }

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager instance = DataManager.Instance;
    base.OnOpen(arg1, arg2);
    ((Graphic) this.TitleText).color = Color.white;
    this.TitleText.text = instance.mStringTable.GetStringByID(8556U);
    this.TopText.text = instance.mStringTable.GetStringByID(8561U);
    this.TopBar.gameObject.SetActive(false);
    this.LeftBar.gameObject.SetActive(false);
    this.TopTargetIcon.SetActive(false);
    this.LeftTargetIcon.SetActive(false);
    ((Behaviour) this.RightFlagDefense).enabled = false;
    this.TopLayerBlue.SetActive(true);
    this.RallyTitleStr = instance.mStringTable.GetStringByID(4891U);
    this.LeftCancelTextStr = StringManager.Instance.SpawnString();
    ((Component) this.InfoBtn).gameObject.SetActive(true);
    if (!GUIManager.Instance.IsArabic)
      return;
    ((Component) this.InfoBtn).transform.localScale = new Vector3(-1f, 1f, 1f);
  }

  private void OnOurWondersOpen() => this.LeftCancelImg.sprite = this.SPriteArray.GetSprite(5);

  private void OnOtherWondersOpen()
  {
    DataManager instance = DataManager.Instance;
    ((Component) this.FilterBtn).gameObject.SetActive(false);
    this.LeftJoinText.text = instance.mStringTable.GetStringByID(4882U);
    this.LeftCancelImg.sprite = this.SPriteArray.GetSprite(5);
    if (this.HideChangeDefence)
      return;
    RectTransform rectTransform1 = ((Graphic) this.LeftJoinImg).rectTransform;
    rectTransform1.anchoredPosition = new Vector2(131.5f, -366.76f);
    rectTransform1.sizeDelta = new Vector2(206f, 82f);
    RectTransform rectTransform2 = ((Graphic) this.LeftCancelImg).rectTransform;
    rectTransform2.anchoredPosition = new Vector2(131.5f, -289.3f);
    rectTransform2.sizeDelta = new Vector2(206f, 82f);
    this.LeftCancelText.text = instance.mStringTable.GetStringByID(9907U);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch ((Rally.ClickType) arg1)
    {
      case Rally.ClickType.CancelWonders:
      case Rally.ClickType.CancelJoin:
        GUIManager.Instance.ShowUILock(EUILock.Expedition);
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_TROOPRETURN;
        messagePacket.AddSeqId();
        messagePacket.Add((byte) arg2);
        messagePacket.Send();
        break;
      case Rally.ClickType.Kick:
        this.KickMember((ushort) (arg2 >> 16), (byte) (arg2 & (int) ushort.MaxValue));
        break;
    }
  }

  public override void KickMember(ushort Index, byte WonderID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_KICK_WONDERMEMBER;
    messagePacket.Add(WonderID);
    messagePacket.Add(Index);
    messagePacket.Send();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    base.UpdateUI(arg1, arg2);
    if (arg1 == 1)
      this.CloseMenuCheck();
    else
      this.UpdateRallyData();
  }

  public override void UpdateRallyData()
  {
    DataManager instance = DataManager.Instance;
    WarlobbyData warlobbyDetail = instance.WarlobbyDetail;
    if (warlobbyDetail == null || warlobbyDetail.WonderID == byte.MaxValue)
      return;
    warlobbyDetail.AttackOrDefense = (byte) 2;
    if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) ActivityManager.Instance.KOWKingdomID)
      this.HideChangeDefence = true;
    if (warlobbyDetail.AllyNameID == instance.RoleAttr.Name.GetHashCode(false))
      this.OnOurWondersOpen();
    else
      this.OnOtherWondersOpen();
    if (!((Component) this.FilterBtn).gameObject.activeSelf)
    {
      GUIManager.Instance.ChangeHeroItemImg(this.TopHero, eHeroOrItem.Hero, warlobbyDetail.AllyHead, (byte) 11, (byte) 0);
      if (warlobbyDetail.AllyHead > (ushort) 0)
        this.TopHero.gameObject.SetActive(true);
      this.SetText(Rally.TextType.TopName, Parm2: warlobbyDetail.AllyName, Parm4: instance.RoleAlliance.Tag, KingdomCompare: warlobbyDetail.AllyHomeKingdom);
    }
    this.WonderStr = warlobbyDetail.WonderID <= (byte) 0 || (int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) ActivityManager.Instance.KOWKingdomID ? instance.mStringTable.GetStringByID(9308U) : instance.mStringTable.GetStringByID(9309U);
    this.LeftTextStr.ClearString();
    this.LeftTextStr.StringToFormat(this.WonderStr);
    this.LeftTextStr.AppendFormat(instance.mStringTable.GetStringByID(8558U));
    this.LeftText.text = this.LeftTextStr.ToString();
    this.LeftText.SetAllDirty();
    this.LeftText.cachedTextGenerator.Invalidate();
    if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) ActivityManager.Instance.KOWKingdomID)
      GUIManager.Instance.ChangeWonderImg(this.LeftHero, warlobbyDetail.WonderID, DataManager.MapDataController.OtherKingdomData.kingdomID);
    else
      GUIManager.Instance.ChangeWonderImg(this.LeftHero, warlobbyDetail.WonderID, DataManager.MapDataController.OtherKingdomData.kingdomID);
    if (warlobbyDetail.WonderID != byte.MaxValue)
      this.LeftHero.gameObject.SetActive(true);
    warlobbyDetail.EnemyName.ClearString();
    warlobbyDetail.EnemyName.Append(DataManager.MapDataController.GetYolkName((ushort) warlobbyDetail.WonderID, (ushort) 0));
    this.SetText(Rally.TextType.LeftName, Parm2: warlobbyDetail.EnemyName, KingdomCompare: (ushort) 0);
    this.TopHeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(warlobbyDetail.AllyCapitalPoint.zoneID, warlobbyDetail.AllyCapitalPoint.pointID);
    this.TopHeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.WonderMapID = (int) DataManager.MapDataController.GetYolkMapID((ushort) warlobbyDetail.WonderID, (ushort) 0);
    Vector2 yolkPointCode = DataManager.MapDataController.GetYolkPointCode((ushort) warlobbyDetail.WonderID, (ushort) 0);
    warlobbyDetail.EnemyCapitalPoint.zoneID = (ushort) yolkPointCode.x;
    warlobbyDetail.EnemyCapitalPoint.pointID = (byte) yolkPointCode.y;
    this.LeftHeroBtn.m_BtnID1 = this.WonderMapID;
    this.LeftHeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.TopUnderLineBtn.m_BtnID2 = GameConstants.PointCodeToMapID(warlobbyDetail.AllyCapitalPoint.zoneID, warlobbyDetail.AllyCapitalPoint.pointID);
    this.TopUnderLineBtn.m_BtnID3 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.LeftUnderLineBtn.m_BtnID2 = this.WonderMapID;
    this.LeftUnderLineBtn.m_BtnID3 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.TopUnderLine.sizeDelta = this.TopUnderLine.sizeDelta with
    {
      x = Math.Min(this.TopNameText.preferredWidth, 362f)
    };
    ((Component) this.TopUnderLine).gameObject.SetActive(true);
    Vector2 sizeDelta = this.LeftUnderLine.sizeDelta;
    if ((double) this.LeftNameText.preferredWidth > 245.0)
    {
      this.LeftNameText.fontSize = 19;
      this.LeftNameText.SetAllDirty();
      this.LeftNameText.cachedTextGeneratorForLayout.Invalidate();
    }
    sizeDelta.x = Math.Min(this.LeftNameText.preferredWidth, 245f);
    this.LeftUnderLine.sizeDelta = sizeDelta;
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform transform = ((Component) this.TopUnderLine).transform as RectTransform;
      transform.anchoredPosition = new Vector2(((Graphic) this.TopNameText).rectTransform.sizeDelta.x - this.TopNameText.preferredWidth, transform.anchoredPosition.y);
    }
    ((Component) this.LeftUnderLine).gameObject.SetActive(true);
    if (warlobbyDetail.AllyHomeKingdom == (ushort) 0 || (int) DataManager.MapDataController.kingdomData.kingdomID == (int) warlobbyDetail.AllyHomeKingdom)
    {
      this.TopCountry.SetActive(false);
    }
    else
    {
      this.TopCountry.SetActive(true);
      this.SetText(Rally.TextType.TopCountry, (int) warlobbyDetail.AllyHomeKingdom, KingdomCompare: (ushort) 0);
    }
    int num1 = this.ItemsHeight.Count - instance.WarTroop.Count;
    if (num1 < 0)
    {
      for (short index = 0; (int) index > num1; --index)
      {
        this.ItemsHeight.Add(80f);
        this.ItemsExtend.Add((byte) 0);
      }
    }
    else if (num1 > 0)
    {
      if (WarlobbyTroop.DelIndex != byte.MaxValue && (int) WarlobbyTroop.DelIndex < this.ItemsExtend.Count)
      {
        this.ItemsHeight.RemoveAt((int) WarlobbyTroop.DelIndex);
        this.ItemsExtend.RemoveAt((int) WarlobbyTroop.DelIndex);
        WarlobbyTroop.DelIndex = byte.MaxValue;
        --num1;
      }
      for (byte index = 0; (int) index < num1; ++index)
      {
        this.ItemsHeight.RemoveAt(0);
        this.ItemsExtend.RemoveAt(0);
      }
    }
    if (warlobbyDetail.AllyNameID == 0 || instance.WarTroop.Count == 0)
    {
      ((Component) this.LeftCancelImg).gameObject.SetActive(false);
      ((Component) this.LeftJoinImg).gameObject.SetActive(false);
    }
    else
    {
      byte num2 = 0;
      this.CancelBtn.m_BtnID1 = 12;
      for (byte index = 0; (int) index < (int) instance.MaxMarchEventNum; ++index)
      {
        if (instance.MarchEventData[(int) index].Type == EMarchEventType.EMET_Camp && GameConstants.PointCodeToMapID(instance.MarchEventData[(int) index].Point.zoneID, instance.MarchEventData[(int) index].Point.pointID) == this.WonderMapID)
        {
          ((Component) this.LeftCancelImg).gameObject.SetActive(true);
          ((Component) this.FilterBtn).gameObject.SetActive(true);
          ((Component) this.LeftJoinImg).gameObject.SetActive(false);
          ((Graphic) this.LeftCancelImg).rectTransform.anchoredPosition = new Vector2(131.5f, -319.5f);
          this.LeftCancelText.text = instance.mStringTable.GetStringByID(8559U);
          this.CancelBtn.m_BtnID1 = 7;
          this.CancelBtn.m_BtnID2 = (int) index;
          num2 = (byte) 1;
          break;
        }
        if (instance.MarchEventData[(int) index].Type == EMarchEventType.EMET_InforceMarching && this.WonderMapID == GameConstants.PointCodeToMapID(instance.MarchEventData[(int) index].Point.zoneID, instance.MarchEventData[(int) index].Point.pointID))
        {
          this.LeftJoinText.text = instance.mStringTable.GetStringByID(8574U);
          ((Graphic) this.LeftJoinText).color = Color.red;
          ((Behaviour) this.JoinBtn).enabled = false;
          num2 = (byte) 2;
          break;
        }
        if (instance.MarchEventData[(int) index].Type == EMarchEventType.EMET_InforceStanby && this.WonderMapID == GameConstants.PointCodeToMapID(instance.MarchEventData[(int) index].Point.zoneID, instance.MarchEventData[(int) index].Point.pointID))
        {
          this.LeftJoinText.text = instance.mStringTable.GetStringByID(8562U);
          ((Graphic) this.LeftJoinText).color = Color.white;
          ((Behaviour) this.JoinBtn).enabled = true;
          this.JoinBtn.m_BtnID1 = 8;
          this.JoinBtn.m_BtnID2 = (int) index;
          num2 = (byte) 3;
          break;
        }
      }
      switch (num2)
      {
        case 0:
          ((Component) this.LeftCancelImg).gameObject.SetActive(!this.HideChangeDefence);
          this.LeftJoinText.text = instance.mStringTable.GetStringByID(4887U);
          ((Graphic) this.LeftJoinText).color = Color.white;
          ((Behaviour) this.JoinBtn).enabled = true;
          this.JoinBtn.m_BtnID1 = 2;
          ((Component) this.LeftJoinImg).gameObject.SetActive(true);
          break;
        case 2:
        case 3:
          ((Component) this.LeftCancelImg).gameObject.SetActive(!this.HideChangeDefence);
          ((Component) this.FilterBtn).gameObject.SetActive(false);
          ((Component) this.LeftJoinImg).gameObject.SetActive(true);
          break;
      }
    }
    if (this.ItemsHeight.Count > 0)
    {
      ((Component) this.RightMessage).gameObject.SetActive(false);
      this.RallyScroll.gameObject.SetActive(true);
      this.RallyScroll.AddNewDataHeight(this.ItemsHeight);
      this.RallyScroll.GoTo(this.LoadBeginIndex, this.LoadContY);
    }
    else
    {
      ((Component) this.RightMessage).gameObject.SetActive(true);
      this.RallyScroll.gameObject.SetActive(false);
    }
    warlobbyDetail.AllyCurrTroop = 0U;
    for (int index = 0; index < instance.WarTroop.Count; ++index)
      warlobbyDetail.AllyCurrTroop += instance.WarTroop[index].TotalTroopNum;
    CString Parm2 = StringManager.Instance.StaticString1024();
    Parm2.StringToFormat(instance.mStringTable.GetStringByID(8560U));
    Parm2.AppendFormat("{0} : ");
    this.SetText(Rally.TextType.RightTitle, (int) warlobbyDetail.AllyCurrTroop, Parm2, (int) warlobbyDetail.AllyMAXTroop, KingdomCompare: (ushort) 0);
    this.ArmyStatisticHint.Show((UIButtonHint) null);
  }

  public override void OnButtonClick(UIButton sender)
  {
    if (this.DelayInit > (byte) 0)
    {
      this.Init();
      this.DelayInit = (byte) 0;
    }
    StringTable mStringTable = DataManager.Instance.mStringTable;
    GUIManager instance = GUIManager.Instance;
    WarlobbyData warlobbyDetail = DataManager.Instance.WarlobbyDetail;
    Rally.ClickType btnId1 = (Rally.ClickType) sender.m_BtnID1;
    switch (btnId1)
    {
      case Rally.ClickType.CancelWonders:
        GUIManager.Instance.OpenOKCancelBox(instance.FindMenu(EGUIWindow.UI_Rally), mStringTable.GetStringByID(8571U), mStringTable.GetStringByID(8572U), 7, sender.m_BtnID2, mStringTable.GetStringByID(4846U), mStringTable.GetStringByID(4847U));
        break;
      case Rally.ClickType.CancelJoin:
        this.MessageStr.ClearString();
        this.MessageStr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) warlobbyDetail.WonderID, (ushort) 0));
        this.MessageStr.AppendFormat(mStringTable.GetStringByID(8576U));
        GUIManager.Instance.OpenOKCancelBox(instance.FindMenu(EGUIWindow.UI_Rally), mStringTable.GetStringByID(4844U), this.MessageStr.ToString(), 8, sender.m_BtnID2, mStringTable.GetStringByID(4846U), mStringTable.GetStringByID(4847U));
        break;
      case Rally.ClickType.Info:
        this.MessageStr.ClearString();
        this.MessageStr.Append('\n');
        this.MessageStr.Append(mStringTable.GetStringByID(9921U));
        GUIManager.Instance.OpenMessageBoxEX(mStringTable.GetStringByID(8556U), this.MessageStr.ToString());
        break;
      case Rally.ClickType.ChangeLeader:
        Door menu1 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (UnityEngine.Object) menu1)
          break;
        menu1.OpenMenu(EGUIWindow.UI_Expedition, (int) warlobbyDetail.WonderID, 8, true);
        break;
      default:
        switch (btnId1)
        {
          case Rally.ClickType.Filter:
            (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BuffList, 1);
            return;
          case Rally.ClickType.Join:
            List<WarlobbyTroop> warTroop = DataManager.Instance.WarTroop;
            string stringById1 = mStringTable.GetStringByID(5748U);
            string stringById2 = mStringTable.GetStringByID(5750U);
            byte num1 = 0;
            if (ActivityManager.Instance.IsInKvK((ushort) 0) && (int) DataManager.MapDataController.kingdomData.kingdomID != (int) warlobbyDetail.AllyHomeKingdom)
            {
              instance.OpenMessageBox(stringById1, mStringTable.GetStringByID(4827U), stringById2);
              return;
            }
            if (warTroop.Count == 1 && (int) warlobbyDetail.AllyCurrTroop == (int) warlobbyDetail.AllyMAXTroop)
            {
              num1 = (byte) 1;
              string stringById3 = mStringTable.GetStringByID(8563U);
              this.MessageStr.ClearString();
              this.MessageStr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) warlobbyDetail.WonderID, (ushort) 0));
              this.MessageStr.AppendFormat(mStringTable.GetStringByID(8566U));
              string stringById4 = mStringTable.GetStringByID(8565U);
              instance.OpenMessageBox(stringById3, this.MessageStr.ToString(), stringById4);
            }
            else if (warTroop.Count > 30)
            {
              num1 = (byte) 1;
              string stringById5 = mStringTable.GetStringByID(8563U);
              this.MessageStr.ClearString();
              this.MessageStr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) warlobbyDetail.WonderID, (ushort) 0));
              this.MessageStr.AppendFormat(mStringTable.GetStringByID(8568U));
              instance.OpenMessageBox(stringById5, this.MessageStr.ToString(), stringById2);
            }
            else if (warlobbyDetail.AllyCurrTroop >= warlobbyDetail.AllyMAXTroop)
            {
              num1 = (byte) 1;
              string stringById6 = mStringTable.GetStringByID(8563U);
              this.MessageStr.ClearString();
              this.MessageStr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) warlobbyDetail.WonderID, (ushort) 0));
              this.MessageStr.AppendFormat(mStringTable.GetStringByID(8567U));
              instance.OpenMessageBox(stringById6, this.MessageStr.ToString(), stringById2);
            }
            else if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyPointCode(warlobbyDetail.EnemyCapitalPoint.zoneID, warlobbyDetail.EnemyCapitalPoint.pointID)) == 0.0)
            {
              num1 = (byte) 1;
              string stringById7 = mStringTable.GetStringByID(4030U);
              string stringById8 = mStringTable.GetStringByID(4031U);
              instance.OpenMessageBox(stringById7, mStringTable.GetStringByID(119U), stringById8);
            }
            else
            {
              string stringById9 = mStringTable.GetStringByID(3967U);
              string stringById10 = mStringTable.GetStringByID(4034U);
              int num2 = 0;
              if (DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
                ++num2;
              uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
              for (int index = 0; index < 8; ++index)
              {
                if (DataManager.Instance.MarchEventData[index].Type != EMarchEventType.EMET_Standby)
                {
                  ++num2;
                  if ((long) num2 == (long) effectBaseVal)
                  {
                    num1 = (byte) 1;
                    instance.OpenMessageBox(stringById9, mStringTable.GetStringByID(3959U), stringById10);
                    break;
                  }
                }
              }
            }
            if (num1 != (byte) 0)
              return;
            Door menu2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
            if (!(bool) (UnityEngine.Object) menu2)
              return;
            menu2.OpenMenu(EGUIWindow.UI_Expedition, 4, 2, true);
            return;
          default:
            base.OnButtonClick(sender);
            return;
        }
    }
  }

  public override void OnClose()
  {
    base.OnClose();
    StringManager.Instance.DeSpawnString(this.LeftCancelTextStr);
  }

  public override void OnTimer(UITimeBar sender)
  {
  }
}
