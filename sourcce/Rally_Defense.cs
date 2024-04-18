// Decompiled with JetBrains decompiler
// Type: Rally_Defense
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class Rally_Defense : Rally
{
  private bool bCloseDefensebtn;
  private Sprite AttackBtnSprite;
  private Sprite AttackOnSprite;

  public Rally_Defense(Transform transform, int dataindex)
    : base(transform, dataindex)
  {
  }

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager instance = DataManager.Instance;
    base.OnOpen(arg1, arg2);
    this.bCloseDefensebtn = (arg2 & 32768) > 0;
    ((Graphic) this.TitleText).color = new Color(0.345f, 0.945f, 1f);
    this.TitleText.text = instance.mStringTable.GetStringByID(4874U);
    this.TopText.text = instance.mStringTable.GetStringByID(4885U);
    this.TopBar.gameObject.SetActive(false);
    this.LeftBar.gameObject.SetActive(false);
    this.TopTargetIcon.SetActive(false);
    this.LeftAttackIcon.SetActive(false);
    ((Behaviour) this.RightFlagAttack).enabled = false;
    this.RallyTitleStr = instance.mStringTable.GetStringByID(4891U);
    this.AttackBtnSprite = this.LeftFilterImg.sprite;
    this.AttackOnSprite = this.LeftFilterOnImg.sprite;
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
    WarlobbyData warlobbyDetail = DataManager.Instance.WarlobbyDetail;
    if (warlobbyDetail == null)
      return;
    if (warlobbyDetail.WonderID != byte.MaxValue)
      this.UpdateRallyWonderDefense(ref warlobbyDetail);
    else
      this.UpdateRallyDefense(ref warlobbyDetail);
  }

  private void UpdateRallyDefense(ref WarlobbyData Data)
  {
    DataManager instance = DataManager.Instance;
    this.LeftText.text = instance.mStringTable.GetStringByID(4886U);
    this.JoinBtn.m_BtnID1 = 2;
    this.LeftFilterImg.sprite = this.SPriteArray.GetSprite(0);
    this.LeftFilterOnImg.sprite = this.SPriteArray.GetSprite(1);
    Data.AttackOrDefense = (byte) 1;
    GUIManager.Instance.ChangeHeroItemImg(this.TopHero, eHeroOrItem.Hero, Data.EnemyHead, (byte) 11, (byte) 0);
    if (Data.EnemyHead > (ushort) 0)
      this.TopHero.gameObject.SetActive(true);
    if ((int) DataManager.MapDataController.kingdomData.kingdomID == (int) Data.EnemyHomeKingdom)
    {
      this.TopCountry.SetActive(false);
    }
    else
    {
      this.TopCountry.SetActive(true);
      this.SetText(Rally.TextType.TopCountry, (int) Data.EnemyHomeKingdom, KingdomCompare: (ushort) 0);
    }
    this.SetText(Rally.TextType.TopName, Parm2: Data.EnemyName, Parm4: Data.EnemyAllianceTag, KingdomCompare: Data.EnemyHomeKingdom);
    GUIManager.Instance.ChangeHeroItemImg(this.LeftHero, eHeroOrItem.Hero, Data.AllyHead, (byte) 11, (byte) 0);
    if (Data.AllyHead > (ushort) 0)
      this.LeftHero.gameObject.SetActive(true);
    this.SetText(Rally.TextType.LeftName, Parm2: Data.AllyName, KingdomCompare: (ushort) 0);
    if (Data.AllyNameID != 0)
    {
      this.TopBar.gameObject.SetActive(true);
      this.TopBar.SetTimebar(this.GetTroopKind(), Data.EventTime.BeginTime, Data.EventTime.BeginTime + (long) Data.EventTime.RequireTime, 0L);
    }
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
    if ((int) DataManager.MapDataController.kingdomData.kingdomID == (int) Data.EnemyHomeKingdom)
      this.TopCountry.SetActive(false);
    else
      this.TopCountry.SetActive(true);
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
    int hashCode = instance.RoleAttr.Name.GetHashCode(false);
    if (hashCode == Data.AllyNameID)
      ((Component) this.FilterBtn).gameObject.SetActive(true);
    else
      ((Component) this.FilterBtn).gameObject.SetActive(false);
    if (Data.AllyNameID != 0 && Data.AllyNameID != hashCode && !this.bCloseDefensebtn)
    {
      ((Component) this.LeftJoinImg).gameObject.SetActive(true);
      CString cstring = StringManager.Instance.StaticString1024();
      bool flag = false;
      for (byte index = 0; (int) index < (int) instance.MaxMarchEventNum; ++index)
      {
        if ((instance.MarchEventData[(int) index].Type == EMarchEventType.EMET_InforceMarching || instance.MarchEventData[(int) index].Type == EMarchEventType.EMET_InforceStanby) && DataManager.MapDataController.getYolkIDbyPointCode(instance.MarchEventData[(int) index].Point.zoneID, instance.MarchEventData[(int) index].Point.pointID, (ushort) 0) == (ushort) 40)
        {
          cstring.ClearString();
          cstring.Append(instance.MarchEventData[(int) index].DesPlayerName);
          if (cstring.GetHashCode(false) == Data.AllyNameID)
          {
            flag = true;
            break;
          }
        }
      }
      if (!flag)
      {
        ((Behaviour) this.JoinBtn).enabled = true;
        ((Graphic) this.LeftJoinText).color = Color.white;
        UIText leftJoinText = this.LeftJoinText;
        string stringById = instance.mStringTable.GetStringByID(4887U);
        this.LeftJoinText.text = stringById;
        string str = stringById;
        leftJoinText.text = str;
      }
      else
      {
        ((Graphic) this.LeftJoinText).color = Color.red;
        UIText leftJoinText = this.LeftJoinText;
        string stringById = instance.mStringTable.GetStringByID(5891U);
        this.LeftJoinText.text = stringById;
        string str = stringById;
        leftJoinText.text = str;
        ((Behaviour) this.JoinBtn).enabled = false;
      }
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
    Parm2.StringToFormat(instance.mStringTable.GetStringByID(4890U));
    Parm2.AppendFormat("{0} : ");
    this.SetText(Rally.TextType.RightTitle, (int) Data.AllyCurrTroop, Parm2, (int) Data.AllyMAXTroop, KingdomCompare: (ushort) 0);
    this.ArmyStatisticHint.Show((UIButtonHint) null);
  }

  private void UpdateRallyWonderDefense(ref WarlobbyData Data)
  {
    DataManager instance = DataManager.Instance;
    this.LeftFilterImg.sprite = this.AttackBtnSprite;
    this.LeftFilterOnImg.sprite = this.AttackOnSprite;
    this.LeftTextStr.ClearString();
    if (Data.WonderID > (byte) 0 && (int) DataManager.MapDataController.OtherKingdomData.kingdomID != (int) ActivityManager.Instance.KOWKingdomID)
      this.LeftTextStr.StringToFormat(instance.mStringTable.GetStringByID(9309U));
    else
      this.LeftTextStr.StringToFormat(instance.mStringTable.GetStringByID(9308U));
    this.LeftTextStr.AppendFormat(instance.mStringTable.GetStringByID(8555U));
    this.LeftText.text = this.LeftTextStr.ToString();
    this.LeftText.SetAllDirty();
    this.LeftText.cachedTextGenerator.Invalidate();
    this.JoinBtn.m_BtnID1 = 6;
    this.FilterBtn.m_BtnID1 = 9;
    Data.AttackOrDefense = (byte) 1;
    GUIManager.Instance.ChangeHeroItemImg(this.TopHero, eHeroOrItem.Hero, Data.EnemyHead, (byte) 11, (byte) 0);
    if (Data.EnemyHead > (ushort) 0)
      this.TopHero.gameObject.SetActive(true);
    if ((int) DataManager.MapDataController.kingdomData.kingdomID == (int) Data.EnemyHomeKingdom)
    {
      this.TopCountry.SetActive(false);
    }
    else
    {
      this.TopCountry.SetActive(true);
      this.SetText(Rally.TextType.TopCountry, (int) Data.EnemyHomeKingdom, KingdomCompare: (ushort) 0);
    }
    this.SetText(Rally.TextType.TopName, Parm2: Data.EnemyName, Parm4: Data.EnemyAllianceTag, KingdomCompare: Data.EnemyHomeKingdom);
    if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) ActivityManager.Instance.KOWKingdomID)
      GUIManager.Instance.ChangeWonderImg(this.LeftHero, Data.WonderID, DataManager.MapDataController.OtherKingdomData.kingdomID);
    else
      GUIManager.Instance.ChangeWonderImg(this.LeftHero, Data.WonderID, Data.AllyHomeKingdom);
    this.LeftHero.gameObject.SetActive(true);
    Data.AllyName.ClearString();
    Data.AllyName.Append(DataManager.MapDataController.GetYolkName((ushort) Data.WonderID, (ushort) 0));
    this.SetText(Rally.TextType.LeftName, Parm2: Data.AllyName, KingdomCompare: (ushort) 0);
    this.TopBar.gameObject.SetActive(true);
    this.TopBar.SetTimebar(this.GetTroopKind(), Data.EventTime.BeginTime, Data.EventTime.BeginTime + (long) Data.EventTime.RequireTime, 0L);
    this.TopHeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(Data.EnemyCapitalPoint.zoneID, Data.EnemyCapitalPoint.pointID);
    this.TopHeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    Vector2 yolkPointCode = DataManager.MapDataController.GetYolkPointCode((ushort) Data.WonderID, (ushort) 0);
    Data.AllyCapitalPoint.zoneID = (ushort) yolkPointCode.x;
    Data.AllyCapitalPoint.pointID = (byte) yolkPointCode.y;
    this.LeftHeroBtn.m_BtnID1 = (int) DataManager.MapDataController.GetYolkMapID((ushort) Data.WonderID, (ushort) 0);
    this.LeftHeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.TopUnderLineBtn.m_BtnID2 = GameConstants.PointCodeToMapID(Data.EnemyCapitalPoint.zoneID, Data.EnemyCapitalPoint.pointID);
    this.TopUnderLineBtn.m_BtnID3 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.LeftUnderLineBtn.m_BtnID2 = (int) DataManager.MapDataController.GetYolkMapID((ushort) Data.WonderID, (ushort) 0);
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
    if ((int) DataManager.MapDataController.kingdomData.kingdomID == (int) Data.EnemyHomeKingdom)
      this.TopCountry.SetActive(false);
    else
      this.TopCountry.SetActive(true);
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
    bool flag = false;
    if ((int) instance.MaxMarchEventNum > (int) Data.SelfParticipateTroopIndex)
    {
      flag = true;
      if (instance.WarTroop.Count > 0)
      {
        if (instance.WarTroop[0].AllyNameID == instance.RoleAttr.Name.GetHashCode(false))
        {
          ((Component) this.FilterBtn).gameObject.SetActive(true);
          ((Component) this.LeftJoinImg).gameObject.SetActive(false);
        }
        else
        {
          ((Component) this.FilterBtn).gameObject.SetActive(false);
          ((Component) this.LeftJoinImg).gameObject.SetActive(true);
        }
      }
    }
    else
      ((Component) this.LeftJoinImg).gameObject.SetActive(true);
    if (((Component) this.LeftJoinImg).gameObject.activeSelf)
    {
      if (!flag)
      {
        ((Behaviour) this.JoinBtn).enabled = true;
        ((Graphic) this.LeftJoinText).color = Color.white;
        UIText leftJoinText = this.LeftJoinText;
        string stringById = instance.mStringTable.GetStringByID(4887U);
        this.LeftJoinText.text = stringById;
        string str = stringById;
        leftJoinText.text = str;
      }
      else
      {
        ((Graphic) this.LeftJoinText).color = Color.red;
        UIText leftJoinText = this.LeftJoinText;
        string stringById = instance.mStringTable.GetStringByID(5891U);
        this.LeftJoinText.text = stringById;
        string str = stringById;
        leftJoinText.text = str;
        ((Behaviour) this.JoinBtn).enabled = false;
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
    Data.AllyCurrTroop = 0U;
    for (int index = 0; index < instance.WarTroop.Count; ++index)
    {
      if (instance.WarTroop[index] != null)
        Data.AllyCurrTroop += instance.WarTroop[index].TotalTroopNum;
    }
    CString Parm2 = StringManager.Instance.StaticString1024();
    Parm2.StringToFormat(instance.mStringTable.GetStringByID(8560U));
    Parm2.AppendFormat("{0} : ");
    this.SetText(Rally.TextType.RightTitle, (int) Data.AllyCurrTroop, Parm2, (int) Data.AllyMAXTroop, KingdomCompare: (ushort) 0);
    this.ArmyStatisticHint.Show((UIButtonHint) null);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || arg1 != 13)
      return;
    this.KickMember((ushort) (arg2 >> 16), (byte) (arg2 & (int) ushort.MaxValue));
  }

  public override void OnButtonClick(UIButton sender)
  {
    if (this.DelayInit > (byte) 0)
    {
      this.Init();
      this.DelayInit = (byte) 0;
    }
    if (sender.m_BtnID1 == 2)
    {
      StringTable mStringTable = DataManager.Instance.mStringTable;
      List<WarlobbyTroop> warTroop = DataManager.Instance.WarTroop;
      WarlobbyData warlobbyDetail = DataManager.Instance.WarlobbyDetail;
      GUIManager instance = GUIManager.Instance;
      byte num1 = 0;
      string stringById1 = mStringTable.GetStringByID(5745U);
      string stringById2 = mStringTable.GetStringByID(5747U);
      if (ActivityManager.Instance.IsInKvK((ushort) 0) && (int) DataManager.MapDataController.kingdomData.kingdomID != (int) warlobbyDetail.AllyHomeKingdom)
      {
        instance.OpenMessageBox(stringById1, mStringTable.GetStringByID(4827U), stringById2);
      }
      else
      {
        if (warTroop.Count >= 30)
        {
          num1 = (byte) 1;
          instance.OpenMessageBox(stringById1, mStringTable.GetStringByID(5746U), stringById2);
        }
        else if ((int) warlobbyDetail.AllyCurrTroop == (int) warlobbyDetail.AllyMAXTroop)
        {
          num1 = (byte) 1;
          if (warlobbyDetail.AllyMAXTroop > 0U)
          {
            string stringById3 = mStringTable.GetStringByID(5812U);
            string stringById4 = mStringTable.GetStringByID(5814U);
            instance.OpenMessageBox(stringById3, mStringTable.GetStringByID(5813U), stringById4);
          }
          else
          {
            string stringById5 = mStringTable.GetStringByID(4834U);
            string stringById6 = mStringTable.GetStringByID(4836U);
            instance.OpenMessageBox(stringById5, mStringTable.GetStringByID(4835U), stringById6);
          }
        }
        else if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyPointCode(warlobbyDetail.AllyCapitalPoint.zoneID, warlobbyDetail.AllyCapitalPoint.pointID)) == 0.0)
        {
          num1 = (byte) 1;
          string stringById7 = mStringTable.GetStringByID(4030U);
          string stringById8 = mStringTable.GetStringByID(4031U);
          instance.OpenMessageBox(stringById7, mStringTable.GetStringByID(119U), stringById8);
        }
        else
        {
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
                instance.OpenMessageBox(stringById1, mStringTable.GetStringByID(3959U), stringById2);
                break;
              }
            }
          }
        }
        if (num1 != (byte) 0)
          return;
        DataManager.Instance.ReinforceCheckType = eReinforceCheck.OpenUIExpedition_Marshal;
        DataManager.Instance.SendAllyInforceInfo(warlobbyDetail.AllyName.ToString());
      }
    }
    else if (sender.m_BtnID1 == 6)
    {
      StringTable mStringTable = DataManager.Instance.mStringTable;
      List<WarlobbyTroop> warTroop = DataManager.Instance.WarTroop;
      WarlobbyData warlobbyDetail = DataManager.Instance.WarlobbyDetail;
      GUIManager instance = GUIManager.Instance;
      Door menu = instance.FindMenu(EGUIWindow.Door) as Door;
      byte num3 = 0;
      string stringById9 = mStringTable.GetStringByID(8563U);
      string stringById10 = mStringTable.GetStringByID(8565U);
      if (ActivityManager.Instance.IsInKvK((ushort) 0))
      {
        if (warlobbyDetail.AllyCurrTroop == 0U)
        {
          instance.OpenMessageBox(stringById9, mStringTable.GetStringByID(9916U), stringById10);
          return;
        }
        if ((int) DataManager.MapDataController.kingdomData.kingdomID != (int) warlobbyDetail.AllyHomeKingdom)
        {
          instance.OpenMessageBox(stringById9, mStringTable.GetStringByID(4827U), stringById10);
          return;
        }
      }
      if (warTroop.Count > 30)
      {
        num3 = (byte) 1;
        this.MessageStr.ClearString();
        this.MessageStr.StringToFormat(this.LeftNameText.text);
        this.MessageStr.AppendFormat(mStringTable.GetStringByID(8568U));
        instance.OpenMessageBox(stringById9, this.MessageStr.ToString(), stringById10);
      }
      else if (warlobbyDetail.AllyCurrTroop == 0U)
      {
        num3 = (byte) 1;
        instance.OpenMessageBox(stringById9, mStringTable.GetStringByID(9916U), stringById10);
      }
      else if ((int) warlobbyDetail.AllyCurrTroop == (int) warlobbyDetail.AllyMAXTroop)
      {
        num3 = (byte) 1;
        if (warTroop.Count > 1)
        {
          string stringById11 = mStringTable.GetStringByID(8563U);
          string stringById12 = mStringTable.GetStringByID(8565U);
          this.MessageStr.ClearString();
          this.MessageStr.StringToFormat(this.LeftNameText.text);
          this.MessageStr.AppendFormat(mStringTable.GetStringByID(8567U));
          instance.OpenMessageBox(stringById11, this.MessageStr.ToString(), stringById12);
        }
        else
        {
          string stringById13 = mStringTable.GetStringByID(8563U);
          string stringById14 = mStringTable.GetStringByID(8565U);
          this.MessageStr.ClearString();
          this.MessageStr.StringToFormat(this.LeftNameText.text);
          this.MessageStr.AppendFormat(mStringTable.GetStringByID(8566U));
          instance.OpenMessageBox(stringById13, this.MessageStr.ToString(), stringById14);
        }
      }
      else if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyPointCode(warlobbyDetail.AllyCapitalPoint.zoneID, warlobbyDetail.AllyCapitalPoint.pointID)) == 0.0)
      {
        num3 = (byte) 1;
        string stringById15 = mStringTable.GetStringByID(4030U);
        string stringById16 = mStringTable.GetStringByID(4031U);
        instance.OpenMessageBox(stringById15, mStringTable.GetStringByID(119U), stringById16);
      }
      else
      {
        int num4 = 0;
        if (DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
          ++num4;
        uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
        for (int index = 0; index < 8; ++index)
        {
          if (DataManager.Instance.MarchEventData[index].Type != EMarchEventType.EMET_Standby)
          {
            ++num4;
            if ((long) num4 == (long) effectBaseVal)
            {
              num3 = (byte) 1;
              instance.OpenMessageBox(stringById9, mStringTable.GetStringByID(3959U), stringById10);
              break;
            }
          }
        }
      }
      if (!(bool) (UnityEngine.Object) menu || num3 != (byte) 0)
        return;
      menu.OpenMenu(EGUIWindow.UI_Expedition, 3, 2, true);
    }
    else if (sender.m_BtnID1 == 0)
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BuffList, 2);
    else if (sender.m_BtnID1 == 9)
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BuffList, 1);
    else
      base.OnButtonClick(sender);
  }

  public override void OnTimer(UITimeBar sender)
  {
  }

  public override void KickMember(ushort Index, byte WonderID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    if (WonderID == byte.MaxValue)
    {
      messagePacket.Protocol = Protocol._MSG_REQUEST_KICK_INFORCEMEMBER;
      messagePacket.Add(Index);
    }
    else
    {
      messagePacket.Protocol = Protocol._MSG_REQUEST_KICK_WONDERMEMBER;
      messagePacket.Add(WonderID);
      messagePacket.Add(Index);
    }
    messagePacket.Send();
  }

  private enum FilterKind
  {
    Defence,
    Wonders,
  }
}
