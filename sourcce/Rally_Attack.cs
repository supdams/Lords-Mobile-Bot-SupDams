// Decompiled with JetBrains decompiler
// Type: Rally_Attack
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class Rally_Attack : Rally
{
  private bool bShowAttackbtn;

  public Rally_Attack(Transform transform, int DataIndex)
    : base(transform, DataIndex)
  {
  }

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager instance = DataManager.Instance;
    base.OnOpen(arg1, arg2);
    this.bShowAttackbtn = (arg2 & 32768) > 0;
    ((Graphic) this.TitleText).color = new Color(1f, 0.631f, 0.671f);
    this.TitleText.text = instance.mStringTable.GetStringByID(4873U);
    this.LeftText.text = instance.mStringTable.GetStringByID(4880U);
    this.LeftCancelText.text = instance.mStringTable.GetStringByID(4882U);
    this.LeftCancelImg.sprite = this.SPriteArray.GetSprite(5);
    this.TopBar.gameObject.SetActive(false);
    this.LeftBar.gameObject.SetActive(false);
    this.TopAttackIcon.SetActive(false);
    this.LeftTargetIcon.SetActive(false);
    ((Behaviour) this.RightFlagDefense).enabled = false;
    this.RallyTitleStr = instance.mStringTable.GetStringByID(4883U);
  }

  public override void Init() => base.Init();

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
    WarlobbyData warlobbyDetail = DataManager.Instance.WarlobbyDetail;
    if (warlobbyDetail == null)
      return;
    if (warlobbyDetail.WonderID != byte.MaxValue)
      this.UpdateRallyWonderAttack(ref warlobbyDetail);
    else if (warlobbyDetail.EnemyHead != (ushort) byte.MaxValue)
      this.UpdateRallyAttack(ref warlobbyDetail);
    else
      this.UpdateNPCRallyAttack(ref warlobbyDetail);
  }

  private void UpdateRallyAttack(ref WarlobbyData Data)
  {
    DataManager instance = DataManager.Instance;
    this.TopText.text = instance.mStringTable.GetStringByID(4879U);
    Data.AttackOrDefense = (byte) 0;
    GUIManager.Instance.ChangeHeroItemImg(this.TopHero, eHeroOrItem.Hero, Data.EnemyHead, (byte) 11, (byte) 0);
    if (Data.EnemyHead > (ushort) 0)
      this.TopHero.gameObject.SetActive(true);
    if (Data.EnemyHomeKingdom == (ushort) 0 || (int) DataManager.MapDataController.kingdomData.kingdomID == (int) Data.EnemyHomeKingdom)
    {
      this.TopCountry.SetActive(false);
    }
    else
    {
      this.TopCountry.SetActive(true);
      this.SetText(Rally.TextType.TopCountry, (int) Data.EnemyHomeKingdom, KingdomCompare: (ushort) 0);
    }
    this.SetText(Rally.TextType.TopName, Parm2: Data.EnemyName, Parm4: Data.EnemyAllianceTag, KingdomCompare: Data.EnemyHomeKingdom);
    if (Data.AllyNameID != 0)
    {
      this.LeftBar.gameObject.SetActive(true);
      this.LeftBar.SetTimebar(this.GetTroopKind(), Data.EventTime.BeginTime, Data.EventTime.BeginTime + (long) Data.EventTime.RequireTime, 0L);
    }
    GUIManager.Instance.ChangeHeroItemImg(this.LeftHero, eHeroOrItem.Hero, Data.AllyHead, (byte) 11, (byte) 0);
    if (Data.AllyHead > (ushort) 0)
      this.LeftHero.gameObject.SetActive(true);
    this.SetText(Rally.TextType.LeftName, Parm2: Data.AllyName, KingdomCompare: (ushort) 0);
    this.TopHeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(Data.EnemyCapitalPoint.zoneID, Data.EnemyCapitalPoint.pointID);
    this.TopHeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.LeftHeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(Data.AllyCapitalPoint.zoneID, Data.AllyCapitalPoint.pointID);
    this.LeftHeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.TopUnderLineBtn.m_BtnID2 = GameConstants.PointCodeToMapID(Data.EnemyCapitalPoint.zoneID, Data.EnemyCapitalPoint.pointID);
    this.TopUnderLineBtn.m_BtnID3 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.LeftUnderLineBtn.m_BtnID2 = GameConstants.PointCodeToMapID(Data.AllyCapitalPoint.zoneID, Data.AllyCapitalPoint.pointID);
    this.LeftUnderLineBtn.m_BtnID3 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    Vector2 sizeDelta = this.TopUnderLine.sizeDelta with
    {
      x = Math.Min(this.TopNameText.preferredWidth, 362f)
    };
    this.TopUnderLine.sizeDelta = sizeDelta;
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform transform = ((Component) this.TopUnderLine).transform as RectTransform;
      transform.anchoredPosition = new Vector2(((Graphic) this.TopNameText).rectTransform.sizeDelta.x - this.TopNameText.preferredWidth, transform.anchoredPosition.y);
    }
    ((Component) this.TopUnderLine).gameObject.SetActive(true);
    sizeDelta = this.LeftUnderLine.sizeDelta;
    if ((double) this.LeftNameText.preferredWidth > 245.0)
    {
      this.LeftNameText.fontSize = 19;
      this.LeftNameText.SetAllDirty();
      this.LeftNameText.cachedTextGeneratorForLayout.Invalidate();
    }
    sizeDelta.x = Math.Min(this.LeftNameText.preferredWidth, 245f);
    this.LeftUnderLine.sizeDelta = sizeDelta;
    ((Component) this.LeftUnderLine).gameObject.SetActive(true);
    int num = this.ItemsHeight.Count - instance.WarTroop.Count;
    if (num < 0)
    {
      for (short index = 0; (int) index > num; --index)
      {
        this.ItemsHeight.Add(80f);
        this.ItemsExtend.Add((byte) 0);
      }
    }
    else if (num > 0)
    {
      if (WarlobbyTroop.DelIndex != byte.MaxValue && (int) WarlobbyTroop.DelIndex < this.ItemsExtend.Count)
      {
        this.ItemsHeight.RemoveAt((int) WarlobbyTroop.DelIndex);
        this.ItemsExtend.RemoveAt((int) WarlobbyTroop.DelIndex);
        WarlobbyTroop.DelIndex = byte.MaxValue;
        --num;
      }
      for (byte index = 0; (int) index < num; ++index)
      {
        this.ItemsHeight.RemoveAt(0);
        this.ItemsExtend.RemoveAt(0);
      }
    }
    bool flag1 = false;
    if (Data.EventTime.BeginTime + (long) Data.EventTime.RequireTime < instance.ServerTime)
      flag1 = true;
    if (Data.Kind == (byte) 1)
    {
      this.LeftBar.transform.anchoredPosition = new Vector2(-6.6f, this.LeftBar.transform.anchoredPosition.y);
      ((Component) this.RallySpeedupBtn).gameObject.SetActive(true);
    }
    else
    {
      this.LeftBar.transform.anchoredPosition = new Vector2(17.2f, this.LeftBar.transform.anchoredPosition.y);
      ((Component) this.RallySpeedupBtn).gameObject.SetActive(false);
    }
    int hashCode = instance.RoleAttr.Name.GetHashCode(false);
    if (Data.AllyNameID == 0)
    {
      ((Component) this.LeftCancelImg).gameObject.SetActive(false);
      ((Component) this.LeftJoinImg).gameObject.SetActive(false);
    }
    else if (hashCode == Data.AllyNameID || this.bShowAttackbtn)
    {
      ((Component) this.LeftCancelImg).gameObject.SetActive(true);
      ((Component) this.FilterBtn).gameObject.SetActive(true);
      ((Component) this.LeftJoinImg).gameObject.SetActive(false);
      ((Graphic) this.LeftCancelImg).rectTransform.anchoredPosition = new Vector2(131.5f, -319.5f);
    }
    else
    {
      ((Component) this.LeftCancelImg).gameObject.SetActive(false);
      ((Component) this.FilterBtn).gameObject.SetActive(false);
      if (!flag1 && Data.Kind == (byte) 0)
      {
        CString cstring = StringManager.Instance.StaticString1024();
        bool flag2 = false;
        for (byte index = 0; (int) index < (int) instance.MaxMarchEventNum; ++index)
        {
          if (instance.MarchEventData[(int) index].Type == EMarchEventType.EMET_RallyMarching || instance.MarchEventData[(int) index].Type == EMarchEventType.EMET_RallyStanby)
          {
            cstring.ClearString();
            cstring.Append(instance.MarchEventData[(int) index].DesPlayerName);
            if (cstring.GetHashCode(false) == Data.AllyNameID)
            {
              flag2 = true;
              break;
            }
          }
        }
        if (!flag2)
        {
          this.LeftJoinText.text = instance.mStringTable.GetStringByID(4884U);
          ((Graphic) this.LeftJoinText).color = Color.white;
          ((Behaviour) this.JoinBtn).enabled = true;
        }
        else
        {
          this.LeftJoinText.text = instance.mStringTable.GetStringByID(4913U);
          ((Graphic) this.LeftJoinText).color = Color.red;
          ((Behaviour) this.JoinBtn).enabled = false;
        }
        ((Component) this.LeftJoinImg).gameObject.SetActive(true);
      }
      else
        ((Component) this.LeftJoinImg).gameObject.SetActive(false);
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
    Data.AllyCurrTroop = 0U;
    for (int index = 0; index < instance.WarTroop.Count; ++index)
    {
      if (instance.WarTroop[index] != null)
        Data.AllyCurrTroop += instance.WarTroop[index].TotalTroopNum;
    }
    CString Parm2 = StringManager.Instance.StaticString1024();
    Parm2.StringToFormat(instance.mStringTable.GetStringByID(4889U));
    Parm2.AppendFormat("{0} : ");
    this.SetText(Rally.TextType.RightTitle, (int) Data.AllyCurrTroop, Parm2, (int) Data.AllyMAXTroop, KingdomCompare: (ushort) 0);
    this.ArmyStatisticHint.Show((UIButtonHint) null);
  }

  private void UpdateRallyWonderAttack(ref WarlobbyData Data)
  {
    DataManager instance = DataManager.Instance;
    this.TopTextStr.ClearString();
    if (Data.WonderID > (byte) 0 && (int) DataManager.MapDataController.OtherKingdomData.kingdomID != (int) ActivityManager.Instance.KOWKingdomID)
      this.TopTextStr.StringToFormat(instance.mStringTable.GetStringByID(9309U));
    else
      this.TopTextStr.StringToFormat(instance.mStringTable.GetStringByID(9308U));
    this.TopTextStr.AppendFormat(instance.mStringTable.GetStringByID(8555U));
    this.TopText.text = this.TopTextStr.ToString();
    this.TopText.SetAllDirty();
    this.TopText.cachedTextGenerator.Invalidate();
    Data.AttackOrDefense = (byte) 0;
    if (ActivityManager.Instance.IsInKvK((ushort) 0) && Data.EnemyHomeKingdom == (ushort) 0)
      Data.EnemyHomeKingdom = DataManager.MapDataController.OtherKingdomData.kingdomID;
    if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) ActivityManager.Instance.KOWKingdomID)
      GUIManager.Instance.ChangeWonderImg(this.TopHero, Data.WonderID, DataManager.MapDataController.OtherKingdomData.kingdomID);
    else
      GUIManager.Instance.ChangeWonderImg(this.TopHero, Data.WonderID, Data.EnemyHomeKingdom);
    this.TopHero.gameObject.SetActive(true);
    this.SetText(Rally.TextType.TopName, Parm2: Data.EnemyName, Parm4: Data.EnemyAllianceTag, KingdomCompare: Data.EnemyHomeKingdom);
    if (Data.AllyNameID != 0)
    {
      this.LeftBar.gameObject.SetActive(true);
      this.LeftBar.SetTimebar(this.GetTroopKind(), Data.EventTime.BeginTime, Data.EventTime.BeginTime + (long) Data.EventTime.RequireTime, 0L);
    }
    GUIManager.Instance.ChangeHeroItemImg(this.LeftHero, eHeroOrItem.Hero, Data.AllyHead, (byte) 11, (byte) 0);
    if (Data.AllyHead > (ushort) 0)
      this.LeftHero.gameObject.SetActive(true);
    this.SetText(Rally.TextType.LeftName, Parm2: Data.AllyName, KingdomCompare: (ushort) 0);
    this.TopHeroBtn.m_BtnID1 = (int) DataManager.MapDataController.GetYolkMapID((ushort) Data.WonderID, (ushort) 0);
    this.TopHeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.LeftHeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(Data.AllyCapitalPoint.zoneID, Data.AllyCapitalPoint.pointID);
    this.LeftHeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.TopUnderLineBtn.m_BtnID2 = (int) DataManager.MapDataController.GetYolkMapID((ushort) Data.WonderID, (ushort) 0);
    this.TopUnderLineBtn.m_BtnID3 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.LeftUnderLineBtn.m_BtnID2 = GameConstants.PointCodeToMapID(Data.AllyCapitalPoint.zoneID, Data.AllyCapitalPoint.pointID);
    this.LeftUnderLineBtn.m_BtnID3 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.TopUnderLine.sizeDelta = this.TopUnderLine.sizeDelta with
    {
      x = Math.Min(this.TopNameText.preferredWidth, 362f)
    };
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform transform = ((Component) this.TopUnderLine).transform as RectTransform;
      transform.anchoredPosition = new Vector2(((Graphic) this.TopNameText).rectTransform.sizeDelta.x - this.TopNameText.preferredWidth, transform.anchoredPosition.y);
    }
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
    ((Component) this.LeftUnderLine).gameObject.SetActive(true);
    if (Data.Kind == (byte) 1)
    {
      this.LeftBar.transform.anchoredPosition = new Vector2(-6.6f, this.LeftBar.transform.anchoredPosition.y);
      ((Component) this.RallySpeedupBtn).gameObject.SetActive(true);
    }
    else
    {
      this.LeftBar.transform.anchoredPosition = new Vector2(17.2f, this.LeftBar.transform.anchoredPosition.y);
      ((Component) this.RallySpeedupBtn).gameObject.SetActive(false);
    }
    this.TopCountry.SetActive(true);
    this.SetText(Rally.TextType.TopWonders, (int) Data.EnemyHomeKingdom, Parm3: (int) Data.WonderID, KingdomCompare: (ushort) 0);
    int num = this.ItemsHeight.Count - instance.WarTroop.Count;
    if (num < 0)
    {
      for (short index = 0; (int) index > num; --index)
      {
        this.ItemsHeight.Add(80f);
        this.ItemsExtend.Add((byte) 0);
      }
    }
    else if (num > 0)
    {
      if (WarlobbyTroop.DelIndex != byte.MaxValue && (int) WarlobbyTroop.DelIndex < this.ItemsExtend.Count)
      {
        this.ItemsHeight.RemoveAt((int) WarlobbyTroop.DelIndex);
        this.ItemsExtend.RemoveAt((int) WarlobbyTroop.DelIndex);
        WarlobbyTroop.DelIndex = byte.MaxValue;
        --num;
      }
      for (byte index = 0; (int) index < num; ++index)
      {
        this.ItemsHeight.RemoveAt(0);
        this.ItemsExtend.RemoveAt(0);
      }
    }
    if (Data.AllyNameID == 0)
    {
      ((Component) this.LeftCancelImg).gameObject.SetActive(false);
      ((Component) this.LeftJoinImg).gameObject.SetActive(false);
    }
    else if ((int) instance.MaxMarchEventNum > (int) Data.SelfParticipateTroopIndex)
    {
      if (instance.MarchEventData[(int) Data.SelfParticipateTroopIndex].bRallyHost == (byte) 1)
      {
        ((Component) this.LeftJoinImg).gameObject.SetActive(false);
        ((Component) this.LeftCancelImg).gameObject.SetActive(true);
        ((Component) this.FilterBtn).gameObject.SetActive(true);
        ((Component) this.LeftJoinImg).gameObject.SetActive(false);
        ((Graphic) this.LeftCancelImg).rectTransform.anchoredPosition = new Vector2(131.5f, -319.5f);
      }
      else
      {
        ((Component) this.LeftJoinImg).gameObject.SetActive(true);
        this.LeftJoinText.text = instance.mStringTable.GetStringByID(4913U);
        ((Graphic) this.LeftJoinText).color = Color.red;
        ((Behaviour) this.JoinBtn).enabled = false;
      }
    }
    else if (Data.Kind == (byte) 0)
    {
      ((Component) this.LeftJoinImg).gameObject.SetActive(true);
      this.LeftJoinText.text = instance.mStringTable.GetStringByID(4884U);
      ((Graphic) this.LeftJoinText).color = Color.white;
      ((Behaviour) this.JoinBtn).enabled = true;
    }
    else
      ((Component) this.LeftJoinImg).gameObject.SetActive(false);
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
    Data.AllyCurrTroop = 0U;
    for (int index = 0; index < instance.WarTroop.Count; ++index)
    {
      if (instance.WarTroop[index] != null)
        Data.AllyCurrTroop += instance.WarTroop[index].TotalTroopNum;
    }
    CString Parm2 = StringManager.Instance.StaticString1024();
    Parm2.StringToFormat(instance.mStringTable.GetStringByID(4889U));
    Parm2.AppendFormat("{0} : ");
    this.SetText(Rally.TextType.RightTitle, (int) Data.AllyCurrTroop, Parm2, (int) Data.AllyMAXTroop, KingdomCompare: (ushort) 0);
    this.ArmyStatisticHint.Show((UIButtonHint) null);
  }

  private void UpdateNPCRallyAttack(ref WarlobbyData Data)
  {
    ((Component) this.LeftJoinImg).gameObject.SetActive(false);
    ((Component) this.LeftCancelImg).gameObject.SetActive(false);
    ((Component) this.FilterBtn).gameObject.SetActive(false);
    DataManager instance = DataManager.Instance;
    this.JoinBtn.m_BtnID1 = 14;
    this.TopText.text = instance.mStringTable.GetStringByID(4879U);
    Data.AttackOrDefense = (byte) 0;
    GUIManager.Instance.ChangeNPCImg(this.TopHero);
    this.TopHero.gameObject.SetActive(true);
    this.TopCountry.SetActive(false);
    this.SetText(Rally.TextType.TopName, Parm2: Data.EnemyName, Parm4: Data.EnemyAllianceTag, KingdomCompare: Data.EnemyHomeKingdom);
    if (Data.AllyNameID != 0)
    {
      this.LeftBar.gameObject.SetActive(true);
      this.LeftBar.SetTimebar(this.GetTroopKind(), Data.EventTime.BeginTime, Data.EventTime.BeginTime + (long) Data.EventTime.RequireTime, 0L);
    }
    GUIManager.Instance.ChangeHeroItemImg(this.LeftHero, eHeroOrItem.Hero, Data.AllyHead, (byte) 11, (byte) 0);
    if (Data.AllyHead > (ushort) 0)
      this.LeftHero.gameObject.SetActive(true);
    this.SetText(Rally.TextType.LeftName, Parm2: Data.AllyName, KingdomCompare: (ushort) 0);
    this.TopHeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(Data.EnemyCapitalPoint.zoneID, Data.EnemyCapitalPoint.pointID);
    this.TopHeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.LeftHeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(Data.AllyCapitalPoint.zoneID, Data.AllyCapitalPoint.pointID);
    this.LeftHeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.TopUnderLineBtn.m_BtnID2 = GameConstants.PointCodeToMapID(Data.EnemyCapitalPoint.zoneID, Data.EnemyCapitalPoint.pointID);
    this.TopUnderLineBtn.m_BtnID3 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.LeftUnderLineBtn.m_BtnID2 = GameConstants.PointCodeToMapID(Data.AllyCapitalPoint.zoneID, Data.AllyCapitalPoint.pointID);
    this.LeftUnderLineBtn.m_BtnID3 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.TopUnderLine.sizeDelta = this.TopUnderLine.sizeDelta with
    {
      x = Math.Min(this.TopNameText.preferredWidth, 362f)
    };
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform transform = ((Component) this.TopUnderLine).transform as RectTransform;
      transform.anchoredPosition = new Vector2(((Graphic) this.TopNameText).rectTransform.sizeDelta.x - this.TopNameText.preferredWidth, transform.anchoredPosition.y);
    }
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
    ((Component) this.LeftUnderLine).gameObject.SetActive(true);
    int num = this.ItemsHeight.Count - instance.WarTroop.Count;
    if (num < 0)
    {
      for (short index = 0; (int) index > num; --index)
      {
        this.ItemsHeight.Add(80f);
        this.ItemsExtend.Add((byte) 0);
      }
    }
    else if (num > 0)
    {
      if (WarlobbyTroop.DelIndex != byte.MaxValue && (int) WarlobbyTroop.DelIndex < this.ItemsExtend.Count)
      {
        this.ItemsHeight.RemoveAt((int) WarlobbyTroop.DelIndex);
        this.ItemsExtend.RemoveAt((int) WarlobbyTroop.DelIndex);
        WarlobbyTroop.DelIndex = byte.MaxValue;
        --num;
      }
      for (byte index = 0; (int) index < num; ++index)
      {
        this.ItemsHeight.RemoveAt(0);
        this.ItemsExtend.RemoveAt(0);
      }
    }
    if (Data.Kind == (byte) 1)
    {
      this.LeftBar.transform.anchoredPosition = new Vector2(-6.6f, this.LeftBar.transform.anchoredPosition.y);
      ((Component) this.RallySpeedupBtn).gameObject.SetActive(true);
    }
    else
    {
      this.LeftBar.transform.anchoredPosition = new Vector2(17.2f, this.LeftBar.transform.anchoredPosition.y);
      ((Component) this.RallySpeedupBtn).gameObject.SetActive(false);
    }
    if (Data.AllyNameID == 0)
    {
      ((Component) this.LeftCancelImg).gameObject.SetActive(false);
      ((Component) this.LeftJoinImg).gameObject.SetActive(false);
    }
    else if ((int) instance.MaxMarchEventNum > (int) Data.SelfParticipateTroopIndex)
    {
      if (instance.MarchEventData[(int) Data.SelfParticipateTroopIndex].bRallyHost == (byte) 1 || instance.MarchEventData[(int) Data.SelfParticipateTroopIndex].bRallyHost == (byte) 4)
      {
        ((Component) this.LeftCancelImg).gameObject.SetActive(true);
        ((Component) this.FilterBtn).gameObject.SetActive(true);
        ((Component) this.LeftJoinImg).gameObject.SetActive(false);
        ((Graphic) this.LeftCancelImg).rectTransform.anchoredPosition = new Vector2(131.5f, -319.5f);
      }
      else if (instance.MarchEventData[(int) Data.SelfParticipateTroopIndex].Type == EMarchEventType.EMET_RallyReturn)
      {
        ((Component) this.LeftJoinImg).gameObject.SetActive(true);
        this.LeftJoinText.text = instance.mStringTable.GetStringByID(4884U);
        ((Graphic) this.LeftJoinText).color = Color.white;
        ((Behaviour) this.JoinBtn).enabled = true;
      }
      else
      {
        ((Component) this.LeftJoinImg).gameObject.SetActive(true);
        this.LeftJoinText.text = instance.mStringTable.GetStringByID(4913U);
        ((Graphic) this.LeftJoinText).color = Color.red;
        ((Behaviour) this.JoinBtn).enabled = false;
      }
    }
    else if (Data.Kind == (byte) 0)
    {
      if (Data.EventTime.BeginTime + (long) Data.EventTime.RequireTime > instance.ServerTime)
        ((Component) this.LeftJoinImg).gameObject.SetActive(true);
      this.LeftJoinText.text = instance.mStringTable.GetStringByID(4884U);
      ((Graphic) this.LeftJoinText).color = Color.white;
      ((Behaviour) this.JoinBtn).enabled = true;
    }
    else
      ((Component) this.LeftJoinImg).gameObject.SetActive(false);
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
    Data.AllyCurrTroop = 0U;
    for (int index = 0; index < instance.WarTroop.Count; ++index)
    {
      if (instance.WarTroop[index] != null)
        Data.AllyCurrTroop += instance.WarTroop[index].TotalTroopNum;
    }
    CString Parm2 = StringManager.Instance.StaticString1024();
    Parm2.StringToFormat(instance.mStringTable.GetStringByID(4889U));
    Parm2.AppendFormat("{0} : ");
    this.SetText(Rally.TextType.RightTitle, (int) Data.AllyCurrTroop, Parm2, (int) Data.AllyMAXTroop, KingdomCompare: (ushort) 0);
    this.ArmyStatisticHint.Show((UIButtonHint) null);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    if (arg1 == 3)
    {
      DataManager.Instance.sendCancelRally();
    }
    else
    {
      if (arg1 != 13)
        return;
      this.KickMember((ushort) (arg2 >> 16), (byte) (arg2 & (int) ushort.MaxValue));
    }
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
      case Rally.ClickType.Filter:
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BuffList, 1);
        break;
      case Rally.ClickType.Join:
        List<WarlobbyTroop> warTroop = DataManager.Instance.WarTroop;
        string stringById1 = mStringTable.GetStringByID(5748U);
        string stringById2 = mStringTable.GetStringByID(5750U);
        byte num1 = 0;
        if (ActivityManager.Instance.IsInKvK((ushort) 0) && (int) DataManager.MapDataController.kingdomData.kingdomID != (int) warlobbyDetail.AllyHomeKingdom)
        {
          instance.OpenMessageBox(stringById1, mStringTable.GetStringByID(982U), stringById2);
          break;
        }
        if (warTroop.Count > 30)
        {
          num1 = (byte) 1;
          instance.OpenMessageBox(stringById1, mStringTable.GetStringByID(5749U), stringById2);
        }
        else if ((int) warlobbyDetail.AllyCurrTroop == (int) warlobbyDetail.AllyMAXTroop)
        {
          num1 = (byte) 1;
          instance.OpenMessageBox(stringById1, mStringTable.GetStringByID(5813U), stringById2);
        }
        else if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyPointCode(warlobbyDetail.AllyCapitalPoint.zoneID, warlobbyDetail.AllyCapitalPoint.pointID)) == 0.0)
        {
          num1 = (byte) 1;
          string stringById3 = mStringTable.GetStringByID(4030U);
          string stringById4 = mStringTable.GetStringByID(4031U);
          instance.OpenMessageBox(stringById3, mStringTable.GetStringByID(119U), stringById4);
        }
        else
        {
          string stringById5 = mStringTable.GetStringByID(3967U);
          string stringById6 = mStringTable.GetStringByID(4034U);
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
                instance.OpenMessageBox(stringById5, mStringTable.GetStringByID(3959U), stringById6);
                break;
              }
            }
          }
        }
        if (num1 != (byte) 0)
          break;
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (UnityEngine.Object) menu)
          break;
        if (sender.m_BtnID1 == 2)
        {
          menu.OpenMenu(EGUIWindow.UI_Expedition, 1, 3, true);
          break;
        }
        menu.OpenMenu(EGUIWindow.UI_Expedition, 1, 9, true);
        break;
      case Rally.ClickType.Cancel:
        GUIManager.Instance.OpenOKCancelBox(instance.FindMenu(EGUIWindow.UI_Rally), mStringTable.GetStringByID(4975U), mStringTable.GetStringByID(4976U), 3, YesText: mStringTable.GetStringByID(4977U), NoText: mStringTable.GetStringByID(4978U));
        break;
      default:
        if (btnId1 != Rally.ClickType.RallySpeed)
        {
          if (btnId1 != Rally.ClickType.JoinNPC)
          {
            base.OnButtonClick(sender);
            break;
          }
          goto case Rally.ClickType.Join;
        }
        else
        {
          (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BagFilter, 2, 200);
          break;
        }
    }
  }

  public override void OnTimer(UITimeBar sender)
  {
    if (sender.m_TimeBarID == 1 || !((Behaviour) this.JoinBtn).enabled)
      return;
    ((Component) this.LeftJoinImg).gameObject.SetActive(false);
  }

  public override void KickMember(ushort Index, byte WonderID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_KICK_RALLYMEMBER;
    messagePacket.Add(Index);
    messagePacket.Send();
  }
}
