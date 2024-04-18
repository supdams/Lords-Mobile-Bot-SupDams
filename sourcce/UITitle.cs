// Decompiled with JetBrains decompiler
// Type: UITitle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UITitle : 
  GUIWindow,
  UILoadImageHander,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIHIBtnClickHandler
{
  private const int UnitCount = 8;
  private Transform m_transform;
  private DataManager DM;
  private GUIManager GM;
  private TitleManager TM;
  private Font tmpFont;
  private ScrollPanel Scroll;
  private CScrollRect cScrollRect;
  private List<float> NowHeightList = new List<float>();
  private byte OpenKind;
  private eNowTitleKind NowTitleKind = eNowTitleKind.Max;
  private bool[] bFindScrollComp = new bool[8];
  private UnitComp_Title[] ScrollComp = new UnitComp_Title[8];
  private CString KingNameStr;
  private CString KingEff1Str;
  private CString KingEff2Str;
  private CString KingEff3Str;
  private UIText rebuild_Title;
  private UIText rebuild_Name;
  private UIText[] rebuild_Eff = new UIText[3];
  private string NameAppend = "{0} <color=#FFF373>{1}</color>";
  private Color GoogEffColor = new Color(0.2078f, 0.9686f, 0.4235f);
  private Color BadEffColor = new Color(1f, 0.3294f, 0.4157f);
  private bool bKingOpen;
  private bool bChiefOpen;
  private int tmpDadaIndex;

  public override void OnOpen(int arg1, int arg2)
  {
    // ISSUE: unable to decompile the method.
  }

  public override void OnClose()
  {
    if ((int) this.OpenKind <= this.TM.NowTitleIndex.Length)
    {
      this.TM.NowTitleIndex[(int) this.OpenKind - 1] = this.Scroll.GetTopIdx();
      this.TM.NowTitlePos[(int) this.OpenKind - 1] = this.cScrollRect.content.anchoredPosition.y;
    }
    for (int index = 7; index >= 0; --index)
    {
      if (this.bFindScrollComp[index])
      {
        if (this.ScrollComp[index].ShowNameStr != null)
        {
          StringManager.Instance.DeSpawnString(this.ScrollComp[index].ShowNameStr);
          this.ScrollComp[index].ShowNameStr = (CString) null;
        }
        if (this.ScrollComp[index].Eff1Str != null)
        {
          StringManager.Instance.DeSpawnString(this.ScrollComp[index].Eff1Str);
          this.ScrollComp[index].Eff1Str = (CString) null;
        }
        if (this.ScrollComp[index].Eff2Str != null)
        {
          StringManager.Instance.DeSpawnString(this.ScrollComp[index].Eff2Str);
          this.ScrollComp[index].Eff2Str = (CString) null;
        }
        if (this.ScrollComp[index].Eff3Str != null)
        {
          StringManager.Instance.DeSpawnString(this.ScrollComp[index].Eff3Str);
          this.ScrollComp[index].Eff3Str = (CString) null;
        }
      }
    }
    if (this.KingNameStr != null)
      StringManager.Instance.DeSpawnString(this.KingNameStr);
    if (this.KingEff1Str != null)
      StringManager.Instance.DeSpawnString(this.KingEff1Str);
    if (this.KingEff2Str != null)
      StringManager.Instance.DeSpawnString(this.KingEff2Str);
    if (this.KingEff3Str == null)
      return;
    StringManager.Instance.DeSpawnString(this.KingEff3Str);
  }

  private void RefreshList(bool GoToTop = true, bool bStopMove = true)
  {
    int num = 0;
    if (this.NowTitleKind == eNowTitleKind.eKVK)
      num = this.TM.RecvTitleIcon.Length - 1;
    else if (this.NowTitleKind == eNowTitleKind.eWorld)
      num = this.TM.RecvTitleIconW.Length - 1;
    else if (this.NowTitleKind == eNowTitleKind.eNational)
      num = this.TM.RecvTitleKingdomID.Length;
    else if (this.NowTitleKind == eNowTitleKind.eNobility)
      num = this.TM.RecvNobilityTitleIcon.Length - 1;
    this.NowHeightList.Clear();
    TitleData recordByKey = this.DM.TitleData.GetRecordByKey((ushort) 1);
    for (int index = 0; index < num; ++index)
    {
      int InKey = (int) this.DM.TitleSortData.GetRecordByIndex(index + 1).TitleID[(int) this.NowTitleKind];
      if (this.NowTitleKind == eNowTitleKind.eKVK)
        recordByKey = this.DM.TitleData.GetRecordByKey((ushort) InKey);
      else if (this.NowTitleKind == eNowTitleKind.eWorld)
        recordByKey = this.DM.TitleDataW.GetRecordByKey((ushort) InKey);
      else if (this.NowTitleKind == eNowTitleKind.eNational)
        recordByKey = this.DM.TitleDataN.GetRecordByKey((ushort) InKey);
      else if (this.NowTitleKind == eNowTitleKind.eNobility)
        recordByKey = this.DM.TitleDataF.GetRecordByKey((ushort) InKey);
      if (recordByKey.Effects[2].EffectID > (ushort) 0)
        this.NowHeightList.Add(125f);
      else
        this.NowHeightList.Add(100f);
    }
    if (this.NowHeightList.Count <= 0)
      return;
    this.Scroll.AddNewDataHeight(this.NowHeightList, GoToTop, bStopMove);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.SendNewData();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        for (int index = 0; index < 3; ++index)
        {
          if (this.rebuild_Eff != null && (Object) this.rebuild_Eff[index] != (Object) null && ((Behaviour) this.rebuild_Eff[index]).enabled)
          {
            ((Behaviour) this.rebuild_Eff[index]).enabled = false;
            ((Behaviour) this.rebuild_Eff[index]).enabled = true;
          }
        }
        if ((Object) this.rebuild_Title != (Object) null && ((Behaviour) this.rebuild_Title).enabled)
        {
          ((Behaviour) this.rebuild_Title).enabled = false;
          ((Behaviour) this.rebuild_Title).enabled = true;
        }
        if ((Object) this.rebuild_Name != (Object) null && ((Behaviour) this.rebuild_Name).enabled)
        {
          ((Behaviour) this.rebuild_Name).enabled = false;
          ((Behaviour) this.rebuild_Name).enabled = true;
        }
        for (int index = 0; index < 8; ++index)
        {
          if (this.bFindScrollComp[index])
          {
            if ((Object) this.ScrollComp[index].PlayerName != (Object) null && ((Behaviour) this.ScrollComp[index].PlayerName).enabled)
            {
              ((Behaviour) this.ScrollComp[index].PlayerName).enabled = false;
              ((Behaviour) this.ScrollComp[index].PlayerName).enabled = true;
            }
            if ((Object) this.ScrollComp[index].Eff1 != (Object) null && ((Behaviour) this.ScrollComp[index].Eff1).enabled)
            {
              ((Behaviour) this.ScrollComp[index].Eff1).enabled = false;
              ((Behaviour) this.ScrollComp[index].Eff1).enabled = true;
            }
            if ((Object) this.ScrollComp[index].Eff2 != (Object) null && ((Behaviour) this.ScrollComp[index].Eff2).enabled)
            {
              ((Behaviour) this.ScrollComp[index].Eff2).enabled = false;
              ((Behaviour) this.ScrollComp[index].Eff2).enabled = true;
            }
            if ((Object) this.ScrollComp[index].Eff3 != (Object) null && ((Behaviour) this.ScrollComp[index].Eff3).enabled)
            {
              ((Behaviour) this.ScrollComp[index].Eff3).enabled = false;
              ((Behaviour) this.ScrollComp[index].Eff3).enabled = true;
            }
            if ((Object) this.ScrollComp[index].BigText != (Object) null && ((Behaviour) this.ScrollComp[index].BigText).enabled)
            {
              ((Behaviour) this.ScrollComp[index].BigText).enabled = false;
              ((Behaviour) this.ScrollComp[index].BigText).enabled = true;
            }
          }
        }
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        this.RefreshList(false, false);
        break;
      case 1:
        if (this.OpenKind != (byte) 1 && this.OpenKind != (byte) 2)
          break;
        this.RefreshList(false, false);
        break;
      case 2:
        if (this.OpenKind != (byte) 3 && this.OpenKind != (byte) 4)
          break;
        this.RefreshList(false, false);
        break;
      case 3:
        if (this.OpenKind != (byte) 7 && this.OpenKind != (byte) 8)
          break;
        this.RefreshList(false, false);
        break;
      case 4:
        this.SendNewData();
        break;
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelObjectIdx >= 8)
      return;
    if (!this.bFindScrollComp[panelObjectIdx])
    {
      this.bFindScrollComp[panelObjectIdx] = true;
      Transform transform = item.transform;
      this.ScrollComp[panelObjectIdx].BaseRC = transform.GetComponent<RectTransform>();
      this.ScrollComp[panelObjectIdx].BackSA = transform.GetChild(0).GetComponent<UISpritesArray>();
      this.ScrollComp[panelObjectIdx].RankImage = transform.GetChild(1).GetComponent<Image>();
      ((MaskableGraphic) this.ScrollComp[panelObjectIdx].RankImage).material = this.GM.GetTitleMaterial();
      this.ScrollComp[panelObjectIdx].PlayerName = transform.GetChild(2).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].PlayerName.font = this.tmpFont;
      this.ScrollComp[panelObjectIdx].Eff1 = transform.GetChild(3).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].Eff1.font = this.tmpFont;
      this.ScrollComp[panelObjectIdx].Eff2 = transform.GetChild(4).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].Eff2.font = this.tmpFont;
      this.ScrollComp[panelObjectIdx].Eff3 = transform.GetChild(10).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].Eff3.font = this.tmpFont;
      this.ScrollComp[panelObjectIdx].PlayerPic = transform.GetChild(6).GetComponent<UIHIBtn>();
      this.ScrollComp[panelObjectIdx].PlayerBack = transform.GetChild(5).GetComponent<Image>();
      this.ScrollComp[panelObjectIdx].ShowNameStr = StringManager.Instance.SpawnString(150);
      this.ScrollComp[panelObjectIdx].Eff1Str = StringManager.Instance.SpawnString(200);
      this.ScrollComp[panelObjectIdx].Eff2Str = StringManager.Instance.SpawnString(200);
      this.ScrollComp[panelObjectIdx].Eff3Str = StringManager.Instance.SpawnString(200);
      transform.GetChild(7).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.ScrollComp[panelObjectIdx].BigText = transform.GetChild(8).GetChild(0).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].BigText.font = this.tmpFont;
      this.ScrollComp[panelObjectIdx].NoPic = transform.GetChild(9).GetComponent<Image>();
      if (this.NowTitleKind == eNowTitleKind.eNational)
        transform.GetChild(9).GetComponent<UISpritesArray>().SetSpriteIndex(1);
      if ((this.OpenKind == (byte) 1 || this.OpenKind == (byte) 3 || this.OpenKind == (byte) 5 || this.OpenKind == (byte) 7) && !this.bKingOpen && !this.bChiefOpen)
      {
        this.ScrollComp[panelObjectIdx].LastBtn = transform.GetChild(7).GetComponent<UIButton>();
        this.ScrollComp[panelObjectIdx].LastBtn.m_Handler = (IUIButtonClickHandler) this;
        ((Component) this.ScrollComp[panelObjectIdx].LastBtn).gameObject.SetActive(true);
      }
      else
      {
        this.ScrollComp[panelObjectIdx].LastBtn = transform.GetChild(8).GetComponent<UIButton>();
        this.ScrollComp[panelObjectIdx].LastBtn.m_Handler = (IUIButtonClickHandler) this;
        ((Component) this.ScrollComp[panelObjectIdx].LastBtn).gameObject.SetActive(true);
      }
      if (this.bKingOpen || this.bChiefOpen)
        this.ScrollComp[panelObjectIdx].BigText.text = this.DM.mStringTable.GetStringByID(7010U);
    }
    TitleData recordByKey = this.DM.TitleData.GetRecordByKey((ushort) 1);
    if (this.NowTitleKind == eNowTitleKind.eKVK)
    {
      dataIdx = (int) this.DM.TitleSortData.GetRecordByIndex(dataIdx + 1).TitleID[(int) this.NowTitleKind] - 1;
      if (dataIdx < 0 || dataIdx >= this.TM.RecvTitleIcon.Length)
        return;
      recordByKey = this.DM.TitleData.GetRecordByKey((ushort) (dataIdx + 1));
      if ((int) recordByKey.ID != dataIdx + 1)
        return;
      this.ScrollComp[panelObjectIdx].RankImage.sprite = this.GM.LoadTitleSprite(recordByKey.IconID);
    }
    else if (this.NowTitleKind == eNowTitleKind.eWorld)
    {
      dataIdx = (int) this.DM.TitleSortData.GetRecordByIndex(dataIdx + 1).TitleID[(int) this.NowTitleKind] - 1;
      if (dataIdx < 0 || dataIdx >= this.TM.RecvTitleIconW.Length)
        return;
      recordByKey = this.DM.TitleDataW.GetRecordByKey((ushort) (dataIdx + 1));
      if ((int) recordByKey.ID != dataIdx + 1)
        return;
      this.ScrollComp[panelObjectIdx].RankImage.sprite = this.GM.LoadTitleSprite(recordByKey.IconID, eTitleKind.WorldTitle);
    }
    else if (this.NowTitleKind == eNowTitleKind.eNational)
    {
      dataIdx = (int) this.DM.TitleSortData.GetRecordByIndex(dataIdx).TitleID[(int) this.NowTitleKind] - 1;
      if (dataIdx < 0 || dataIdx >= this.TM.RecvTitleKingdomID.Length)
        return;
      recordByKey = this.DM.TitleDataN.GetRecordByKey((ushort) (dataIdx + 1));
      if ((int) recordByKey.ID != dataIdx + 1)
        return;
      this.ScrollComp[panelObjectIdx].RankImage.sprite = this.GM.LoadTitleSprite(recordByKey.IconID, eTitleKind.KingdomTitle);
    }
    else if (this.NowTitleKind == eNowTitleKind.eNobility)
    {
      dataIdx = (int) this.DM.TitleSortData.GetRecordByIndex(dataIdx + 1).TitleID[(int) this.NowTitleKind] - 1;
      if (dataIdx < 0 || dataIdx >= this.TM.RecvNobilityTitleIcon.Length)
        return;
      recordByKey = this.DM.TitleDataF.GetRecordByKey((ushort) (dataIdx + 1));
      if ((int) recordByKey.ID != dataIdx + 1)
        return;
      this.ScrollComp[panelObjectIdx].RankImage.sprite = this.GM.LoadTitleSprite(recordByKey.IconID, eTitleKind.NobilityTitle);
    }
    this.ScrollComp[panelObjectIdx].BackSA.SetSpriteIndex((int) recordByKey.isDebuff);
    this.ScrollComp[panelObjectIdx].LastBtn.m_BtnID2 = dataIdx;
    if (this.GetIcon(dataIdx) != (ushort) 0)
    {
      this.ScrollComp[panelObjectIdx].ShowNameStr.Length = 0;
      this.ScrollComp[panelObjectIdx].ShowNameStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey.StringID));
      this.ScrollComp[panelObjectIdx].ShowNameStr.StringToFormat(this.GetTitleName(dataIdx));
      this.ScrollComp[panelObjectIdx].ShowNameStr.AppendFormat(this.NameAppend);
      ((Component) this.ScrollComp[panelObjectIdx].PlayerPic).gameObject.SetActive(true);
      ((Component) this.ScrollComp[panelObjectIdx].PlayerBack).gameObject.SetActive(true);
      ((Component) this.ScrollComp[panelObjectIdx].NoPic).gameObject.SetActive(false);
      if (this.NowTitleKind == eNowTitleKind.eNational)
        GUIManager.Instance.ChangeWonderImg(((Component) this.ScrollComp[panelObjectIdx].PlayerPic).transform, (byte) 0, this.GetIcon(dataIdx));
      else
        this.GM.ChangeHeroItemImg(((Component) this.ScrollComp[panelObjectIdx].PlayerPic).transform, eHeroOrItem.Hero, this.GetIcon(dataIdx), (byte) 5, (byte) 0);
      if (this.OpenKind == (byte) 1 || this.OpenKind == (byte) 3 || this.OpenKind == (byte) 7)
      {
        ((Component) this.ScrollComp[panelObjectIdx].LastBtn).gameObject.SetActive(true);
        if (this.bChiefOpen)
        {
          if (DataManager.CompareStr(this.DM.RoleAttr.Name, this.GetTitleNameNoTag(dataIdx)) == 0)
          {
            this.ScrollComp[panelObjectIdx].LastBtn.interactable = false;
            ((Graphic) this.ScrollComp[panelObjectIdx].BigText).color = Color.gray;
          }
          else
          {
            this.ScrollComp[panelObjectIdx].LastBtn.interactable = true;
            ((Graphic) this.ScrollComp[panelObjectIdx].BigText).color = Color.white;
          }
        }
      }
      else if (this.OpenKind == (byte) 2 || this.OpenKind == (byte) 4 || this.OpenKind == (byte) 8)
      {
        ((Component) this.ScrollComp[panelObjectIdx].LastBtn).gameObject.SetActive(true);
        this.ScrollComp[panelObjectIdx].BigText.text = this.DM.mStringTable.GetStringByID(9349U);
        if (DataManager.CompareStr(this.GetOpenTitleName(), this.GetTitleNameNoTag(dataIdx)) == 0 || this.bChiefOpen && DataManager.CompareStr(this.DM.RoleAttr.Name, this.GetTitleNameNoTag(dataIdx)) == 0)
        {
          this.ScrollComp[panelObjectIdx].LastBtn.interactable = false;
          ((Graphic) this.ScrollComp[panelObjectIdx].BigText).color = Color.gray;
        }
        else
        {
          this.ScrollComp[panelObjectIdx].LastBtn.interactable = true;
          ((Graphic) this.ScrollComp[panelObjectIdx].BigText).color = Color.white;
        }
      }
      else if (this.OpenKind == (byte) 5)
        ((Component) this.ScrollComp[panelObjectIdx].LastBtn).gameObject.SetActive(false);
      else if (this.OpenKind == (byte) 6)
        ((Component) this.ScrollComp[panelObjectIdx].LastBtn).gameObject.SetActive(false);
    }
    else
    {
      this.ScrollComp[panelObjectIdx].ShowNameStr.Length = 0;
      this.ScrollComp[panelObjectIdx].ShowNameStr.Append(this.DM.mStringTable.GetStringByID((uint) recordByKey.StringID));
      ((Component) this.ScrollComp[panelObjectIdx].PlayerPic).gameObject.SetActive(false);
      ((Component) this.ScrollComp[panelObjectIdx].PlayerBack).gameObject.SetActive(false);
      ((Component) this.ScrollComp[panelObjectIdx].NoPic).gameObject.SetActive(true);
      if (this.OpenKind == (byte) 1 || this.OpenKind == (byte) 3 || this.OpenKind == (byte) 5 || this.OpenKind == (byte) 7)
        ((Component) this.ScrollComp[panelObjectIdx].LastBtn).gameObject.SetActive(false);
      else if (this.OpenKind == (byte) 2 || this.OpenKind == (byte) 4 || this.OpenKind == (byte) 6 || this.OpenKind == (byte) 8)
      {
        ((Component) this.ScrollComp[panelObjectIdx].LastBtn).gameObject.SetActive(true);
        this.ScrollComp[panelObjectIdx].BigText.text = this.DM.mStringTable.GetStringByID(9350U);
        this.ScrollComp[panelObjectIdx].LastBtn.interactable = true;
        ((Graphic) this.ScrollComp[panelObjectIdx].BigText).color = Color.white;
      }
    }
    this.ScrollComp[panelObjectIdx].PlayerName.text = this.ScrollComp[panelObjectIdx].ShowNameStr.ToString();
    this.ScrollComp[panelObjectIdx].PlayerName.SetAllDirty();
    this.ScrollComp[panelObjectIdx].PlayerName.cachedTextGenerator.Invalidate();
    if (recordByKey.Effects[0].EffectID != (ushort) 0)
    {
      this.ScrollComp[panelObjectIdx].Eff1Str.Length = 0;
      GameConstants.GetEffectValue(this.ScrollComp[panelObjectIdx].Eff1Str, recordByKey.Effects[0].EffectID, (uint) recordByKey.Effects[0].Value, (byte) 14, 0.0f);
      this.ScrollComp[panelObjectIdx].Eff1.text = this.ScrollComp[panelObjectIdx].Eff1Str.ToString();
      this.ScrollComp[panelObjectIdx].Eff1.SetAllDirty();
      this.ScrollComp[panelObjectIdx].Eff1.cachedTextGenerator.Invalidate();
      if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey.Effects[0].EffectID).StatusIcon == (ushort) 0)
        ((Graphic) this.ScrollComp[panelObjectIdx].Eff1).color = this.GoogEffColor;
      else
        ((Graphic) this.ScrollComp[panelObjectIdx].Eff1).color = this.BadEffColor;
    }
    else
      ((Component) this.ScrollComp[panelObjectIdx].Eff1).gameObject.SetActive(false);
    if (recordByKey.Effects[1].EffectID != (ushort) 0)
    {
      ((Component) this.ScrollComp[panelObjectIdx].Eff2).gameObject.SetActive(true);
      this.ScrollComp[panelObjectIdx].Eff2Str.Length = 0;
      GameConstants.GetEffectValue(this.ScrollComp[panelObjectIdx].Eff2Str, recordByKey.Effects[1].EffectID, (uint) recordByKey.Effects[1].Value, (byte) 14, 0.0f);
      this.ScrollComp[panelObjectIdx].Eff2.text = this.ScrollComp[panelObjectIdx].Eff2Str.ToString();
      this.ScrollComp[panelObjectIdx].Eff2.SetAllDirty();
      this.ScrollComp[panelObjectIdx].Eff2.cachedTextGenerator.Invalidate();
      if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey.Effects[1].EffectID).StatusIcon == (ushort) 0)
        ((Graphic) this.ScrollComp[panelObjectIdx].Eff2).color = this.GoogEffColor;
      else
        ((Graphic) this.ScrollComp[panelObjectIdx].Eff2).color = this.BadEffColor;
    }
    else
      ((Component) this.ScrollComp[panelObjectIdx].Eff2).gameObject.SetActive(false);
    if (recordByKey.Effects[2].EffectID != (ushort) 0)
    {
      this.ScrollComp[panelObjectIdx].BaseRC.sizeDelta = new Vector2(829f, 125f);
      ((Component) this.ScrollComp[panelObjectIdx].Eff3).gameObject.SetActive(true);
      this.ScrollComp[panelObjectIdx].Eff3Str.Length = 0;
      GameConstants.GetEffectValue(this.ScrollComp[panelObjectIdx].Eff3Str, recordByKey.Effects[2].EffectID, (uint) recordByKey.Effects[2].Value, (byte) 14, 0.0f);
      this.ScrollComp[panelObjectIdx].Eff3.text = this.ScrollComp[panelObjectIdx].Eff3Str.ToString();
      this.ScrollComp[panelObjectIdx].Eff3.SetAllDirty();
      this.ScrollComp[panelObjectIdx].Eff3.cachedTextGenerator.Invalidate();
      if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey.Effects[2].EffectID).StatusIcon == (ushort) 0)
        ((Graphic) this.ScrollComp[panelObjectIdx].Eff3).color = this.GoogEffColor;
      else
        ((Graphic) this.ScrollComp[panelObjectIdx].Eff3).color = this.BadEffColor;
    }
    else
    {
      this.ScrollComp[panelObjectIdx].BaseRC.sizeDelta = new Vector2(829f, 100f);
      ((Component) this.ScrollComp[panelObjectIdx].Eff3).gameObject.SetActive(false);
    }
  }

  private void SendNewData()
  {
    if (!this.bKingOpen && !this.bChiefOpen)
      return;
    if (this.OpenKind == (byte) 1)
      this.TM.Send_KingdomTitle_List();
    else if (this.OpenKind == (byte) 2)
    {
      if ((int) DataManager.MapDataController.kingdomData.kingdomID != (int) DataManager.MapDataController.FocusKingdomID)
        this.TM.Send_KingdomTitle_List_King();
      else
        this.TM.Send_KingdomTitle_List();
    }
    else if (this.OpenKind == (byte) 3 || this.OpenKind == (byte) 4)
      this.TM.Send_WorldTitle_List();
    else if (this.OpenKind == (byte) 7)
    {
      this.TM.Send_NobilityTitle_List_King(this.TM.OpenWonderID);
    }
    else
    {
      if (this.OpenKind != (byte) 8)
        return;
      if (ActivityManager.Instance.CheckCanonizationNoility(DataManager.MapDataController.OtherKingdomData.kingdomID))
        this.TM.Send_NobilityTitle_List();
      else
        this.TM.Send_NobilityTitle_List_King((ushort) ActivityManager.Instance.FederalActKingdomWonderID);
    }
  }

  private bool CheckDataLength(int dataIdx)
  {
    if (this.NowTitleKind == eNowTitleKind.eKVK)
    {
      if (dataIdx < 0 || dataIdx >= this.TM.RecvTitleIcon.Length)
        return false;
    }
    else if (this.NowTitleKind == eNowTitleKind.eWorld)
    {
      if (dataIdx < 0 || dataIdx >= this.TM.RecvTitleIconW.Length)
        return false;
    }
    else if (this.NowTitleKind == eNowTitleKind.eNational)
    {
      if (dataIdx < 0 || dataIdx >= this.TM.RecvTitleKingdomID.Length)
        return false;
    }
    else if (this.NowTitleKind == eNowTitleKind.eNobility && (dataIdx < 0 || dataIdx >= this.TM.RecvNobilityTitleIcon.Length))
      return false;
    return true;
  }

  private ushort GetIcon(int dataIdx)
  {
    if (this.NowTitleKind == eNowTitleKind.eKVK)
    {
      if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleIcon.Length)
        return this.TM.RecvTitleIcon[dataIdx];
    }
    else if (this.NowTitleKind == eNowTitleKind.eWorld)
    {
      if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleIconW.Length)
        return this.TM.RecvTitleIconW[dataIdx];
    }
    else if (this.NowTitleKind == eNowTitleKind.eNational)
    {
      if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleKingdomID.Length)
        return this.TM.RecvTitleKingdomID[dataIdx];
    }
    else if (this.NowTitleKind == eNowTitleKind.eNobility && dataIdx >= 0 && dataIdx < this.TM.RecvNobilityTitleIcon.Length)
      return this.TM.RecvNobilityTitleIcon[dataIdx];
    return 0;
  }

  private CString GetOpenTitleName()
  {
    if (this.NowTitleKind == eNowTitleKind.eKVK)
      return this.TM.OpenTitleName;
    if (this.NowTitleKind == eNowTitleKind.eWorld)
      return this.TM.OpenTitleNameW;
    return this.NowTitleKind == eNowTitleKind.eNobility ? this.TM.OpenNobilityTitleName : (CString) null;
  }

  private CString GetTitleName(int dataIdx)
  {
    if (this.NowTitleKind == eNowTitleKind.eKVK)
    {
      if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleName.Length)
        return this.TM.RecvTitleName[dataIdx];
    }
    else if (this.NowTitleKind == eNowTitleKind.eWorld)
    {
      if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleNameW.Length)
        return this.TM.RecvTitleNameW[dataIdx];
    }
    else if (this.NowTitleKind == eNowTitleKind.eNational)
    {
      if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleNameN.Length)
        return this.TM.RecvTitleNameN[dataIdx];
    }
    else if (this.NowTitleKind == eNowTitleKind.eNobility && dataIdx >= 0 && dataIdx < this.TM.RecvNobilityTitleName.Length)
      return this.TM.RecvNobilityTitleName[dataIdx];
    return (CString) null;
  }

  private CString GetTitleNameNoTag(int dataIdx)
  {
    if (this.NowTitleKind == eNowTitleKind.eKVK)
    {
      if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleNameNoTag.Length)
        return this.TM.RecvTitleNameNoTag[dataIdx];
    }
    else if (this.NowTitleKind == eNowTitleKind.eWorld)
    {
      if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleNameNoTagW.Length)
        return this.TM.RecvTitleNameNoTagW[dataIdx];
    }
    else if (this.NowTitleKind == eNowTitleKind.eNobility && dataIdx >= 0 && dataIdx < this.TM.RecvNobilityTitleNameNoTag.Length)
      return this.TM.RecvNobilityTitleNameNoTag[dataIdx];
    return (CString) null;
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    if (this.OpenKind == (byte) 1)
    {
      dataIndex = (int) this.DM.TitleSortData.GetRecordByIndex(dataIndex + 1).TitleID[(int) this.NowTitleKind] - 1;
      if (dataIndex < 0 || dataIndex >= this.TM.RecvTitleIcon.Length || this.TM.RecvTitleIcon[dataIndex] == (ushort) 0)
        return;
      if ((bool) (Object) this.GM.FindMenu(EGUIWindow.UI_LordInfo))
        this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
      DataManager.Instance.ShowLordProfile(this.TM.RecvTitleNameNoTag[dataIndex].ToString());
    }
    else if (this.OpenKind == (byte) 3)
    {
      dataIndex = (int) this.DM.TitleSortData.GetRecordByIndex(dataIndex + 1).TitleID[(int) this.NowTitleKind] - 1;
      if (dataIndex < 0 || dataIndex >= this.TM.RecvTitleIconW.Length || this.TM.RecvTitleIconW[dataIndex] == (ushort) 0)
        return;
      if ((bool) (Object) this.GM.FindMenu(EGUIWindow.UI_LordInfo))
        this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
      DataManager.Instance.ShowLordProfile(this.TM.RecvTitleNameNoTagW[dataIndex].ToString());
    }
    else
    {
      if (this.OpenKind != (byte) 7)
        return;
      dataIndex = (int) this.DM.TitleSortData.GetRecordByIndex(dataIndex + 1).TitleID[(int) this.NowTitleKind] - 1;
      if (dataIndex < 0 || dataIndex >= this.TM.RecvNobilityTitleIcon.Length || this.TM.RecvNobilityTitleIcon[dataIndex] == (ushort) 0)
        return;
      if ((bool) (Object) this.GM.FindMenu(EGUIWindow.UI_LordInfo))
        this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
      DataManager.Instance.ShowLordProfile(this.TM.RecvNobilityTitleNameNoTag[dataIndex].ToString());
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (sender.m_BtnID1 == 1)
    {
      if (!(bool) (Object) menu)
        return;
      menu.CloseMenu();
    }
    else if (sender.m_BtnID1 == 2)
    {
      int btnId2 = sender.m_BtnID2;
      if (this.OpenKind == (byte) 1)
      {
        if (btnId2 < 0 || btnId2 >= this.TM.RecvTitleIcon.Length)
          return;
        if ((bool) (Object) this.GM.FindMenu(EGUIWindow.UI_LordInfo))
          this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
        DataManager.Instance.ShowLordProfile(this.TM.RecvTitleNameNoTag[btnId2].ToString());
      }
      else if (this.OpenKind == (byte) 3)
      {
        if (btnId2 < 0 || btnId2 >= this.TM.RecvTitleIconW.Length)
          return;
        if ((bool) (Object) this.GM.FindMenu(EGUIWindow.UI_LordInfo))
          this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
        DataManager.Instance.ShowLordProfile(this.TM.RecvTitleNameNoTagW[btnId2].ToString());
      }
      else
      {
        if (this.OpenKind != (byte) 7 || btnId2 < 0 || btnId2 >= this.TM.RecvNobilityTitleIcon.Length)
          return;
        if ((bool) (Object) this.GM.FindMenu(EGUIWindow.UI_LordInfo))
          this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
        DataManager.Instance.ShowLordProfile(this.TM.RecvNobilityTitleNameNoTag[btnId2].ToString());
      }
    }
    else if (sender.m_BtnID1 == 3)
    {
      int btnId2 = sender.m_BtnID2;
      if (!this.CheckDataLength(btnId2))
        return;
      if (this.NowTitleKind == eNowTitleKind.eKVK)
      {
        if (this.OpenKind == (byte) 1 && (this.bKingOpen || this.bChiefOpen))
          this.TM.Send_KingdomTitle_Remove((ushort) (btnId2 + 1));
        else
          this.TM.Send_KingdomTitle_Change((ushort) (btnId2 + 1));
      }
      else if (this.NowTitleKind == eNowTitleKind.eWorld)
      {
        if (this.OpenKind == (byte) 3 && (this.bKingOpen || this.bChiefOpen))
          this.TM.Send_WorldTitle_Remove((ushort) (btnId2 + 1));
        else
          this.TM.Send_WorldTitle_Change((ushort) (btnId2 + 1));
      }
      else if (this.OpenKind == (byte) 6)
      {
        this.tmpDadaIndex = btnId2;
        this.GM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(9350U), this.DM.mStringTable.GetStringByID(11009U), YesText: this.DM.mStringTable.GetStringByID(3925U), NoText: this.DM.mStringTable.GetStringByID(3926U));
      }
      else
      {
        if (this.NowTitleKind != eNowTitleKind.eNobility)
          return;
        if (this.OpenKind == (byte) 7 && (this.bKingOpen || this.bChiefOpen))
          this.TM.Send_NobilityTitle_Remove((ushort) (btnId2 + 1));
        else
          this.TM.Send_NobilityTitle_Change((ushort) (btnId2 + 1));
      }
    }
    else
    {
      if (sender.m_BtnID1 != 4)
        return;
      if (this.NowTitleKind == eNowTitleKind.eKVK)
        this.GM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(9324U), this.DM.mStringTable.GetStringByID(9367U), BackExit: true);
      else if (this.NowTitleKind == eNowTitleKind.eWorld)
        this.GM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(11028U), this.DM.mStringTable.GetStringByID(11005U), BackExit: true);
      else if (this.NowTitleKind == eNowTitleKind.eNational)
      {
        this.GM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(11027U), this.DM.mStringTable.GetStringByID(11006U), BackExit: true);
      }
      else
      {
        if (this.NowTitleKind != eNowTitleKind.eNobility)
          return;
        this.GM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(11059U), this.DM.mStringTable.GetStringByID(11076U), BackExit: true);
      }
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    this.TM.Send_NationalTitle_Change(this.TM.OpenKingdomID, (ushort) (this.tmpDadaIndex + 1));
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    if (sender.m_BtnID1 != 5)
      return;
    if ((bool) (Object) this.GM.FindMenu(EGUIWindow.UI_LordInfo))
      this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
    if (this.OpenKind == (byte) 1)
      DataManager.Instance.ShowLordProfile(this.TM.RecvTitleNameNoTag[0].ToString());
    else if (this.OpenKind == (byte) 3)
      DataManager.Instance.ShowLordProfile(this.TM.RecvTitleNameNoTagW[0].ToString());
    else if (this.OpenKind == (byte) 5)
    {
      DataManager.Instance.ShowLordProfile(this.TM.WKNameNoTag.ToString());
    }
    else
    {
      if (this.OpenKind != (byte) 7)
        return;
      DataManager.Instance.ShowLordProfile(this.TM.RecvNobilityTitleNameNoTag[0].ToString());
    }
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (Object) menu)
      return;
    img.sprite = menu.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = menu.LoadMaterial();
  }
}
