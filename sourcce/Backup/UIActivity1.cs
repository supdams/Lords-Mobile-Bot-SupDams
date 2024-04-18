// Decompiled with JetBrains decompiler
// Type: UIActivity1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIActivity1 : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
  private const float Delta = 17f;
  private const float unitWidth = 199f;
  private Transform m_transform;
  private Transform ScrollT;
  private Transform ContentT;
  private RectTransform ContentRC;
  private GameObject UnitObject;
  private DataManager DM;
  private GUIManager GM;
  private ActivityManager AM;
  private Font tmpFont;
  private UIText BgText;
  private float NowLeft;
  private UnitComp3 NewsObj;
  private UnitComp3[] CSObj = new UnitComp3[5];
  private UnitComp3[] SPObj = new UnitComp3[5];
  private UnitComp3[] KVKObj = new UnitComp3[5];
  private UnitComp3 AMObj;
  private UnitComp3 KOWObj;
  private UnitComp3 SumObj;
  private UnitComp3 NWObj;
  private UnitComp3 AWObj;
  private List<UnitComp3> AllObject = new List<UnitComp3>();

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.AM = ActivityManager.Instance;
    this.m_transform = this.transform;
    this.tmpFont = this.GM.GetTTFFont();
    this.m_transform.GetChild(2).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(2).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(2).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(3).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(3).gameObject.AddComponent<ArabicItemTextureRot>();
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) this.m_transform.GetChild(2).GetComponent<CustomImage>()).enabled = false;
    Transform child = this.m_transform.GetChild(1);
    this.BgText = child.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.BgText.font = this.tmpFont;
    this.BgText.text = this.DM.mStringTable.GetStringByID(8108U);
    this.ScrollT = child.GetChild(0);
    this.ContentT = this.ScrollT.GetChild(0);
    this.ContentRC = this.ContentT.GetComponent<RectTransform>();
    this.UnitObject = this.ContentT.GetChild(0).gameObject;
    this.SetAllObject();
    if ((Object) this.ContentT != (Object) null)
    {
      if (this.AM.Act1arg1 == arg1)
        this.ContentT.GetComponent<RectTransform>().anchoredPosition = this.AM.Act1Pos;
      else
        this.AM.Act1arg1 = arg1;
    }
    this.UnitObject.SetActive(false);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
    if (this.AM.bAskSecondData || this.AM.bReOpen || this.AM.AW_bWaitOpenNext)
      return;
    ActivityManager.Instance.Send_ACTIVITY_EVENT_LIST();
  }

  public override void OnClose()
  {
    this.ReleaseStr();
    if (this.NewsObj != null)
    {
      if (this.NewsObj.RewardStr != null)
      {
        StringManager.Instance.DeSpawnString(this.NewsObj.RewardStr);
        this.NewsObj.RewardStr = (CString) null;
      }
      if (this.NewsObj.InfoStr != null)
      {
        StringManager.Instance.DeSpawnString(this.NewsObj.InfoStr);
        this.NewsObj.InfoStr = (CString) null;
      }
      if (this.NewsObj.BtnStr != null)
      {
        StringManager.Instance.DeSpawnString(this.NewsObj.BtnStr);
        this.NewsObj.BtnStr = (CString) null;
      }
      if (this.NewsObj.FlashStr != null)
      {
        StringManager.Instance.DeSpawnString(this.NewsObj.FlashStr);
        this.NewsObj.FlashStr = (CString) null;
      }
    }
    if (!((Object) this.ContentT != (Object) null))
      return;
    this.AM.Act1Pos = this.ContentT.GetComponent<RectTransform>().anchoredPosition;
  }

  private void SetAllObject()
  {
    // ISSUE: unable to decompile the method.
  }

  private void ReleaseStr()
  {
    for (int index = 0; index < this.AllObject.Count; ++index)
    {
      if (this.AllObject[index].RewardStr != null)
      {
        StringManager.Instance.DeSpawnString(this.AllObject[index].RewardStr);
        this.AllObject[index].RewardStr = (CString) null;
      }
      if (this.AllObject[index].InfoStr != null)
      {
        StringManager.Instance.DeSpawnString(this.AllObject[index].InfoStr);
        this.AllObject[index].InfoStr = (CString) null;
      }
      if (this.AllObject[index].BtnStr != null)
      {
        StringManager.Instance.DeSpawnString(this.AllObject[index].BtnStr);
        this.AllObject[index].BtnStr = (CString) null;
      }
      if (this.AllObject[index].FlashStr != null)
      {
        StringManager.Instance.DeSpawnString(this.AllObject[index].FlashStr);
        this.AllObject[index].FlashStr = (CString) null;
      }
    }
    for (int index = 0; index < this.KVKObj.Length; ++index)
    {
      if (this.KVKObj[index] != null)
      {
        if (this.KVKObj[index].RewardStr != null)
        {
          StringManager.Instance.DeSpawnString(this.KVKObj[index].RewardStr);
          this.KVKObj[index].RewardStr = (CString) null;
        }
        if (this.KVKObj[index].InfoStr != null)
        {
          StringManager.Instance.DeSpawnString(this.KVKObj[index].InfoStr);
          this.KVKObj[index].InfoStr = (CString) null;
        }
        if (this.KVKObj[index].BtnStr != null)
        {
          StringManager.Instance.DeSpawnString(this.KVKObj[index].BtnStr);
          this.KVKObj[index].BtnStr = (CString) null;
        }
        if (this.KVKObj[index].FlashStr != null)
        {
          StringManager.Instance.DeSpawnString(this.KVKObj[index].FlashStr);
          this.KVKObj[index].FlashStr = (CString) null;
        }
      }
    }
    for (int index = 0; index < this.CSObj.Length; ++index)
    {
      if (this.CSObj[index] != null)
      {
        if (this.CSObj[index].RewardStr != null)
        {
          StringManager.Instance.DeSpawnString(this.CSObj[index].RewardStr);
          this.CSObj[index].RewardStr = (CString) null;
        }
        if (this.CSObj[index].InfoStr != null)
        {
          StringManager.Instance.DeSpawnString(this.CSObj[index].InfoStr);
          this.CSObj[index].InfoStr = (CString) null;
        }
        if (this.CSObj[index].BtnStr != null)
        {
          StringManager.Instance.DeSpawnString(this.CSObj[index].BtnStr);
          this.CSObj[index].BtnStr = (CString) null;
        }
        if (this.CSObj[index].FlashStr != null)
        {
          StringManager.Instance.DeSpawnString(this.CSObj[index].FlashStr);
          this.CSObj[index].FlashStr = (CString) null;
        }
      }
    }
    for (int index = 0; index < this.SPObj.Length; ++index)
    {
      if (this.SPObj[index] != null)
      {
        if (this.SPObj[index].RewardStr != null)
        {
          StringManager.Instance.DeSpawnString(this.SPObj[index].RewardStr);
          this.SPObj[index].RewardStr = (CString) null;
        }
        if (this.SPObj[index].InfoStr != null)
        {
          StringManager.Instance.DeSpawnString(this.SPObj[index].InfoStr);
          this.SPObj[index].InfoStr = (CString) null;
        }
        if (this.SPObj[index].BtnStr != null)
        {
          StringManager.Instance.DeSpawnString(this.SPObj[index].BtnStr);
          this.SPObj[index].BtnStr = (CString) null;
        }
        if (this.SPObj[index].FlashStr != null)
        {
          StringManager.Instance.DeSpawnString(this.SPObj[index].FlashStr);
          this.SPObj[index].FlashStr = (CString) null;
        }
      }
    }
    if (this.AMObj != null)
    {
      if (this.AMObj.RewardStr != null)
      {
        StringManager.Instance.DeSpawnString(this.AMObj.RewardStr);
        this.AMObj.RewardStr = (CString) null;
      }
      if (this.AMObj.InfoStr != null)
      {
        StringManager.Instance.DeSpawnString(this.AMObj.InfoStr);
        this.AMObj.InfoStr = (CString) null;
      }
      if (this.AMObj.BtnStr != null)
      {
        StringManager.Instance.DeSpawnString(this.AMObj.BtnStr);
        this.AMObj.BtnStr = (CString) null;
      }
      if (this.AMObj.FlashStr != null)
      {
        StringManager.Instance.DeSpawnString(this.AMObj.FlashStr);
        this.AMObj.FlashStr = (CString) null;
      }
      if (this.AMObj.AllyRankTextStr != null)
      {
        StringManager.Instance.DeSpawnString(this.AMObj.AllyRankTextStr);
        this.AMObj.AllyRankTextStr = (CString) null;
      }
    }
    if (this.KOWObj != null)
    {
      if (this.KOWObj.RewardStr != null)
      {
        StringManager.Instance.DeSpawnString(this.KOWObj.RewardStr);
        this.KOWObj.RewardStr = (CString) null;
      }
      if (this.KOWObj.InfoStr != null)
      {
        StringManager.Instance.DeSpawnString(this.KOWObj.InfoStr);
        this.KOWObj.InfoStr = (CString) null;
      }
      if (this.KOWObj.BtnStr != null)
      {
        StringManager.Instance.DeSpawnString(this.KOWObj.BtnStr);
        this.KOWObj.BtnStr = (CString) null;
      }
      if (this.KOWObj.FlashStr != null)
      {
        StringManager.Instance.DeSpawnString(this.KOWObj.FlashStr);
        this.KOWObj.FlashStr = (CString) null;
      }
      if (this.KOWObj.AllyRankTextStr != null)
      {
        StringManager.Instance.DeSpawnString(this.KOWObj.AllyRankTextStr);
        this.KOWObj.AllyRankTextStr = (CString) null;
      }
    }
    if (this.SumObj != null)
    {
      if (this.SumObj.RewardStr != null)
      {
        StringManager.Instance.DeSpawnString(this.SumObj.RewardStr);
        this.SumObj.RewardStr = (CString) null;
      }
      if (this.SumObj.InfoStr != null)
      {
        StringManager.Instance.DeSpawnString(this.SumObj.InfoStr);
        this.SumObj.InfoStr = (CString) null;
      }
      if (this.SumObj.BtnStr != null)
      {
        StringManager.Instance.DeSpawnString(this.SumObj.BtnStr);
        this.SumObj.BtnStr = (CString) null;
      }
      if (this.SumObj.FlashStr != null)
      {
        StringManager.Instance.DeSpawnString(this.SumObj.FlashStr);
        this.SumObj.FlashStr = (CString) null;
      }
      if (this.SumObj.AllyRankTextStr != null)
      {
        StringManager.Instance.DeSpawnString(this.SumObj.AllyRankTextStr);
        this.SumObj.AllyRankTextStr = (CString) null;
      }
    }
    if (this.NWObj != null)
    {
      if (this.NWObj.RewardStr != null)
      {
        StringManager.Instance.DeSpawnString(this.NWObj.RewardStr);
        this.NWObj.RewardStr = (CString) null;
      }
      if (this.NWObj.InfoStr != null)
      {
        StringManager.Instance.DeSpawnString(this.NWObj.InfoStr);
        this.NWObj.InfoStr = (CString) null;
      }
      if (this.NWObj.BtnStr != null)
      {
        StringManager.Instance.DeSpawnString(this.NWObj.BtnStr);
        this.NWObj.BtnStr = (CString) null;
      }
      if (this.NWObj.FlashStr != null)
      {
        StringManager.Instance.DeSpawnString(this.NWObj.FlashStr);
        this.NWObj.FlashStr = (CString) null;
      }
      if (this.NWObj.AllyRankTextStr != null)
      {
        StringManager.Instance.DeSpawnString(this.NWObj.AllyRankTextStr);
        this.NWObj.AllyRankTextStr = (CString) null;
      }
    }
    if (this.AWObj == null)
      return;
    if (this.AWObj.RewardStr != null)
    {
      StringManager.Instance.DeSpawnString(this.AWObj.RewardStr);
      this.AWObj.RewardStr = (CString) null;
    }
    if (this.AWObj.InfoStr != null)
    {
      StringManager.Instance.DeSpawnString(this.AWObj.InfoStr);
      this.AWObj.InfoStr = (CString) null;
    }
    if (this.AWObj.BtnStr != null)
    {
      StringManager.Instance.DeSpawnString(this.AWObj.BtnStr);
      this.AWObj.BtnStr = (CString) null;
    }
    if (this.AWObj.FlashStr != null)
    {
      StringManager.Instance.DeSpawnString(this.AWObj.FlashStr);
      this.AWObj.FlashStr = (CString) null;
    }
    if (this.AWObj.AllyRankTextStr == null)
      return;
    StringManager.Instance.DeSpawnString(this.AWObj.AllyRankTextStr);
    this.AWObj.AllyRankTextStr = (CString) null;
  }

  private void ResetAll()
  {
    if ((Object) this.ScrollT != (Object) null)
    {
      this.ScrollT.GetComponent<CScrollRect>().StopMovement();
      ((Behaviour) this.ScrollT.GetComponent<CScrollRect>()).enabled = false;
    }
    for (int index = 0; index < this.AllObject.Count; ++index)
    {
      ((Component) this.AllObject[index].mRC).gameObject.SetActive(false);
      Object.Destroy((Object) ((Component) this.AllObject[index].mRC).gameObject);
    }
    for (int index = 0; index < this.CSObj.Length; ++index)
    {
      if (this.CSObj[index] != null)
      {
        ((Component) this.CSObj[index].mRC).gameObject.SetActive(false);
        Object.Destroy((Object) ((Component) this.CSObj[index].mRC).gameObject);
      }
    }
    for (int index = 0; index < this.SPObj.Length; ++index)
    {
      if (this.SPObj[index] != null)
      {
        ((Component) this.SPObj[index].mRC).gameObject.SetActive(false);
        Object.Destroy((Object) ((Component) this.SPObj[index].mRC).gameObject);
      }
    }
    for (int index = 0; index < this.KVKObj.Length; ++index)
    {
      if (this.KVKObj[index] != null)
      {
        ((Component) this.KVKObj[index].mRC).gameObject.SetActive(false);
        Object.Destroy((Object) ((Component) this.KVKObj[index].mRC).gameObject);
      }
    }
    if (this.AMObj != null)
    {
      ((Component) this.AMObj.mRC).gameObject.SetActive(false);
      Object.Destroy((Object) ((Component) this.AMObj.mRC).gameObject);
    }
    if (this.KOWObj != null)
    {
      ((Component) this.KOWObj.mRC).gameObject.SetActive(false);
      Object.Destroy((Object) ((Component) this.KOWObj.mRC).gameObject);
    }
    if (this.SumObj != null)
    {
      ((Component) this.SumObj.mRC).gameObject.SetActive(false);
      Object.Destroy((Object) ((Component) this.SumObj.mRC).gameObject);
    }
    if (this.NWObj != null)
    {
      ((Component) this.NWObj.mRC).gameObject.SetActive(false);
      Object.Destroy((Object) ((Component) this.NWObj.mRC).gameObject);
    }
    if (this.AWObj != null)
    {
      ((Component) this.AWObj.mRC).gameObject.SetActive(false);
      Object.Destroy((Object) ((Component) this.AWObj.mRC).gameObject);
    }
    this.ReleaseStr();
    for (int index = 0; index < this.CSObj.Length; ++index)
      this.CSObj[index] = (UnitComp3) null;
    for (int index = 0; index < this.SPObj.Length; ++index)
      this.SPObj[index] = (UnitComp3) null;
    this.AllObject.Clear();
    for (int index = 0; index < this.KVKObj.Length; ++index)
      this.KVKObj[index] = (UnitComp3) null;
    this.AMObj = (UnitComp3) null;
    this.KOWObj = (UnitComp3) null;
    this.SumObj = (UnitComp3) null;
    this.NWObj = (UnitComp3) null;
    this.AWObj = (UnitComp3) null;
    this.SetAllObject();
  }

  private void SpawnUnitObject(int index, int index2 = -1)
  {
    // ISSUE: unable to decompile the method.
  }

  private void SetMainImg(int index, int index2 = -1)
  {
    if (index == 254 || index == (int) byte.MaxValue)
    {
      bool flag = index == 254;
      SPActivityDataType activityDataType = !flag ? this.AM.SPActivityData[index2] : this.AM.CSActivityData[index2];
      UnitComp3 unitComp3 = !flag ? this.SPObj[index2] : this.CSObj[index2];
      if (unitComp3 == null)
        return;
      if (this.AM.bDownLoadPic1)
      {
        if (this.AM.bUpDatePic1)
        {
          this.AM.m_ActivityListAsset.UnloadAsset();
          this.AM.bUpDatePic1 = false;
        }
        if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
          this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
        unitComp3.MainImg.sprite = this.AM.LoadActivityListSprite(activityDataType.DetailPic);
        if ((Object) unitComp3.MainImg.sprite == (Object) null)
          unitComp3.MainImg.sprite = this.AM.LoadActivityListSprite((ushort) 0);
        ((MaskableGraphic) unitComp3.MainImg).material = this.AM.GetActivityListMaterial();
        if ((Object) this.AM.m_ActivityListAsset.m_Material == (Object) null || (Object) unitComp3.MainImg.sprite == (Object) null)
          ((Behaviour) unitComp3.MainImg).enabled = false;
        else
          ((Behaviour) unitComp3.MainImg).enabled = true;
      }
      else
        ((Behaviour) unitComp3.MainImg).enabled = false;
    }
    else if (index >= 201 && index <= 205)
    {
      index -= 201;
      UnitComp3 unitComp3 = this.KVKObj[index];
      if (unitComp3 == null)
        return;
      ActivityDataType activityDataType = this.AM.KvKActivityData[index];
      if (this.AM.bDownLoadPic1)
      {
        if (this.AM.bUpDatePic1)
        {
          this.AM.m_ActivityListAsset.UnloadAsset();
          this.AM.bUpDatePic1 = false;
        }
        if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
          this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
        unitComp3.MainImg.sprite = this.AM.LoadActivityListSprite(activityDataType.Pic);
        if ((Object) unitComp3.MainImg.sprite == (Object) null)
          unitComp3.MainImg.sprite = this.AM.LoadActivityListSprite((ushort) 0);
        ((MaskableGraphic) unitComp3.MainImg).material = this.AM.GetActivityListMaterial();
        if ((Object) this.AM.m_ActivityListAsset.m_Material == (Object) null || (Object) unitComp3.MainImg.sprite == (Object) null)
          ((Behaviour) unitComp3.MainImg).enabled = false;
        else
          ((Behaviour) unitComp3.MainImg).enabled = true;
      }
      else
        ((Behaviour) unitComp3.MainImg).enabled = false;
    }
    else
    {
      switch (index)
      {
        case 206:
          UnitComp3 amObj = this.AMObj;
          if (amObj == null)
            break;
          ActivityDataType mobilizationData = this.AM.AllyMobilizationData;
          if (this.AM.bDownLoadPic1)
          {
            if (this.AM.bUpDatePic1)
            {
              this.AM.m_ActivityListAsset.UnloadAsset();
              this.AM.bUpDatePic1 = false;
            }
            if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
              this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
            amObj.MainImg.sprite = this.AM.LoadActivityListSprite(mobilizationData.Pic);
            if ((Object) amObj.MainImg.sprite == (Object) null)
              amObj.MainImg.sprite = this.AM.LoadActivityListSprite((ushort) 0);
            ((MaskableGraphic) amObj.MainImg).material = this.AM.GetActivityListMaterial();
            if ((Object) this.AM.m_ActivityListAsset.m_Material == (Object) null || (Object) amObj.MainImg.sprite == (Object) null)
            {
              ((Behaviour) amObj.MainImg).enabled = false;
              break;
            }
            ((Behaviour) amObj.MainImg).enabled = true;
            break;
          }
          ((Behaviour) amObj.MainImg).enabled = false;
          break;
        case 207:
          UnitComp3 kowObj = this.KOWObj;
          if (kowObj == null)
            break;
          ActivityDataType kowData = this.AM.KOWData;
          if (this.AM.bDownLoadPic1)
          {
            if (this.AM.bUpDatePic1)
            {
              this.AM.m_ActivityListAsset.UnloadAsset();
              this.AM.bUpDatePic1 = false;
            }
            if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
              this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
            kowObj.MainImg.sprite = this.AM.LoadActivityListSprite(kowData.Pic);
            if ((Object) kowObj.MainImg.sprite == (Object) null)
              kowObj.MainImg.sprite = this.AM.LoadActivityListSprite((ushort) 0);
            ((MaskableGraphic) kowObj.MainImg).material = this.AM.GetActivityListMaterial();
            if ((Object) this.AM.m_ActivityListAsset.m_Material == (Object) null || (Object) kowObj.MainImg.sprite == (Object) null)
            {
              ((Behaviour) kowObj.MainImg).enabled = false;
              break;
            }
            ((Behaviour) kowObj.MainImg).enabled = true;
            break;
          }
          ((Behaviour) kowObj.MainImg).enabled = false;
          break;
        case 208:
          UnitComp3 sumObj = this.SumObj;
          if (sumObj == null)
            break;
          ActivityDataType allianceSummonData = this.AM.AllianceSummonData;
          if (this.AM.bDownLoadPic1)
          {
            if (this.AM.bUpDatePic1)
            {
              this.AM.m_ActivityListAsset.UnloadAsset();
              this.AM.bUpDatePic1 = false;
            }
            if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
              this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
            sumObj.MainImg.sprite = this.AM.LoadActivityListSprite(allianceSummonData.Pic);
            if ((Object) sumObj.MainImg.sprite == (Object) null)
              sumObj.MainImg.sprite = this.AM.LoadActivityListSprite((ushort) 0);
            ((MaskableGraphic) sumObj.MainImg).material = this.AM.GetActivityListMaterial();
            if ((Object) this.AM.m_ActivityListAsset.m_Material == (Object) null || (Object) sumObj.MainImg.sprite == (Object) null)
            {
              ((Behaviour) sumObj.MainImg).enabled = false;
              break;
            }
            ((Behaviour) sumObj.MainImg).enabled = true;
            break;
          }
          ((Behaviour) sumObj.MainImg).enabled = false;
          break;
        case 209:
          UnitComp3 nwObj = this.NWObj;
          if (nwObj == null)
            break;
          ActivityDataType nobilityActivityData = this.AM.NobilityActivityData;
          if (this.AM.bDownLoadPic1)
          {
            if (this.AM.bUpDatePic1)
            {
              this.AM.m_ActivityListAsset.UnloadAsset();
              this.AM.bUpDatePic1 = false;
            }
            if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
              this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
            nwObj.MainImg.sprite = this.AM.LoadActivityListSprite(nobilityActivityData.Pic);
            if ((Object) nwObj.MainImg.sprite == (Object) null)
              nwObj.MainImg.sprite = this.AM.LoadActivityListSprite((ushort) 0);
            ((MaskableGraphic) nwObj.MainImg).material = this.AM.GetActivityListMaterial();
            if ((Object) this.AM.m_ActivityListAsset.m_Material == (Object) null || (Object) nwObj.MainImg.sprite == (Object) null)
            {
              ((Behaviour) nwObj.MainImg).enabled = false;
              break;
            }
            ((Behaviour) nwObj.MainImg).enabled = true;
            break;
          }
          ((Behaviour) nwObj.MainImg).enabled = false;
          break;
        case 210:
          UnitComp3 awObj = this.AWObj;
          if (awObj == null)
            break;
          ActivityDataType allianceWarData = this.AM.AllianceWarData;
          if (this.AM.bDownLoadPic1)
          {
            if (this.AM.bUpDatePic1)
            {
              this.AM.m_ActivityListAsset.UnloadAsset();
              this.AM.bUpDatePic1 = false;
            }
            if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
              this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
            awObj.MainImg.sprite = this.AM.LoadActivityListSprite(allianceWarData.Pic);
            if ((Object) awObj.MainImg.sprite == (Object) null)
              awObj.MainImg.sprite = this.AM.LoadActivityListSprite((ushort) 0);
            ((MaskableGraphic) awObj.MainImg).material = this.AM.GetActivityListMaterial();
            if ((Object) this.AM.m_ActivityListAsset.m_Material == (Object) null || (Object) awObj.MainImg.sprite == (Object) null)
            {
              ((Behaviour) awObj.MainImg).enabled = false;
              break;
            }
            ((Behaviour) awObj.MainImg).enabled = true;
            break;
          }
          ((Behaviour) awObj.MainImg).enabled = false;
          break;
        default:
          if (index < 0 || index >= this.AllObject.Count)
            break;
          ActivityDataType activityDataType1 = this.AM.ActivityData[index];
          UnitComp3 unitComp3_1 = this.AllObject[index];
          if (this.AM.bDownLoadPic1)
          {
            if (this.AM.bUpDatePic1)
            {
              this.AM.m_ActivityListAsset.UnloadAsset();
              this.AM.bUpDatePic1 = false;
            }
            if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
              this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
            unitComp3_1.MainImg.sprite = this.AM.LoadActivityListSprite(activityDataType1.Pic);
            if ((Object) unitComp3_1.MainImg.sprite == (Object) null)
              unitComp3_1.MainImg.sprite = this.AM.LoadActivityListSprite((ushort) 0);
            ((MaskableGraphic) unitComp3_1.MainImg).material = this.AM.GetActivityListMaterial();
            if ((Object) this.AM.m_ActivityListAsset.m_Material == (Object) null || (Object) unitComp3_1.MainImg.sprite == (Object) null)
            {
              ((Behaviour) unitComp3_1.MainImg).enabled = false;
              break;
            }
            ((Behaviour) unitComp3_1.MainImg).enabled = true;
            break;
          }
          ((Behaviour) unitComp3_1.MainImg).enabled = false;
          break;
      }
    }
  }

  private void SetBackImg(int index, int index2 = -1)
  {
    if (index == 254 || index == (int) byte.MaxValue)
    {
      bool flag = index == 254;
      UnitComp3 unitComp3 = !flag ? this.SPObj[index2] : this.CSObj[index2];
      if (unitComp3 == null)
        return;
      if (flag)
      {
        unitComp3.BtnText1.text = this.DM.mStringTable.GetStringByID(8109U);
        unitComp3.SA.SetSpriteIndex(0);
        unitComp3.FlashGO.SetActive(this.AM.bShowNewCSActivity[index2]);
      }
      else
      {
        unitComp3.BtnText1.text = this.DM.mStringTable.GetStringByID(8110U);
        unitComp3.SA.SetSpriteIndex(1);
        unitComp3.FlashGO.SetActive(this.AM.bShowNewSPActivity[index2]);
      }
    }
    else if (index >= 201 && index <= 205)
    {
      index -= 201;
      UnitComp3 unitComp3 = this.KVKObj[index];
      if (unitComp3 == null)
        return;
      ActivityDataType activityDataType = this.AM.KvKActivityData[index];
      if (activityDataType.EventState == EActivityState.EAS_Run)
      {
        unitComp3.BtnText1.text = this.DM.mStringTable.GetStringByID(8110U);
        unitComp3.SA.SetSpriteIndex(1);
      }
      else if (activityDataType.EventState == EActivityState.EAS_Prepare)
      {
        unitComp3.BtnText1.text = this.DM.mStringTable.GetStringByID(8111U);
        unitComp3.SA.SetSpriteIndex(2);
      }
      else if (activityDataType.EventState == EActivityState.EAS_HomeEnd || activityDataType.EventState == EActivityState.EAS_HomeStart || activityDataType.EventState == EActivityState.EAS_StartRanking)
      {
        unitComp3.BtnText1.text = this.DM.mStringTable.GetStringByID(9810U);
        unitComp3.SA.SetSpriteIndex(2);
      }
      else if (activityDataType.EventState == EActivityState.EAS_ReplayRanking)
      {
        unitComp3.BtnText1.text = this.DM.mStringTable.GetStringByID(9819U);
        unitComp3.SA.SetSpriteIndex(2);
      }
      else
      {
        unitComp3.BtnText1.text = this.DM.mStringTable.GetStringByID(8111U);
        unitComp3.SA.SetSpriteIndex(3);
      }
      if (activityDataType.EventState == EActivityState.EAS_ReplayRanking)
        ((Graphic) unitComp3.BtnText1).rectTransform.sizeDelta = new Vector2(((Graphic) unitComp3.BtnText1).rectTransform.sizeDelta.x, 55f);
      else
        ((Graphic) unitComp3.BtnText1).rectTransform.sizeDelta = new Vector2(((Graphic) unitComp3.BtnText1).rectTransform.sizeDelta.x, 31.5f);
    }
    else
    {
      switch (index)
      {
        case 206:
          UnitComp3 amObj = this.AMObj;
          if (amObj == null)
            break;
          ActivityDataType mobilizationData = this.AM.AllyMobilizationData;
          if (mobilizationData.EventState == EActivityState.EAS_Run)
          {
            amObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8110U);
            amObj.SA.SetSpriteIndex(1);
          }
          else if (mobilizationData.EventState == EActivityState.EAS_Prepare)
          {
            amObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111U);
            amObj.SA.SetSpriteIndex(2);
          }
          else if (mobilizationData.EventState == EActivityState.EAS_ReplayRanking)
          {
            amObj.BtnText1.text = this.DM.mStringTable.GetStringByID(747U);
            amObj.SA.SetSpriteIndex(2);
          }
          else
          {
            amObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111U);
            amObj.SA.SetSpriteIndex(3);
          }
          if (mobilizationData.EventState == EActivityState.EAS_ReplayRanking)
          {
            ((Graphic) amObj.BtnText1).rectTransform.sizeDelta = new Vector2(((Graphic) amObj.BtnText1).rectTransform.sizeDelta.x, 55f);
            break;
          }
          ((Graphic) amObj.BtnText1).rectTransform.sizeDelta = new Vector2(((Graphic) amObj.BtnText1).rectTransform.sizeDelta.x, 31.5f);
          break;
        case 207:
          UnitComp3 kowObj = this.KOWObj;
          if (kowObj == null)
            break;
          ActivityDataType kowData = this.AM.KOWData;
          if (kowData.EventState == EActivityState.EAS_Run)
          {
            kowObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8110U);
            kowObj.SA.SetSpriteIndex(1);
          }
          else if (kowData.EventState == EActivityState.EAS_Prepare)
          {
            kowObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111U);
            kowObj.SA.SetSpriteIndex(2);
          }
          else if (kowData.EventState == EActivityState.EAS_ReplayRanking)
          {
            kowObj.BtnText1.text = this.DM.mStringTable.GetStringByID(10010U);
            kowObj.SA.SetSpriteIndex(2);
          }
          else
          {
            kowObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111U);
            kowObj.SA.SetSpriteIndex(3);
          }
          if (kowData.EventState == EActivityState.EAS_ReplayRanking)
          {
            ((Graphic) kowObj.BtnText1).rectTransform.sizeDelta = new Vector2(((Graphic) kowObj.BtnText1).rectTransform.sizeDelta.x, 55f);
            break;
          }
          ((Graphic) kowObj.BtnText1).rectTransform.sizeDelta = new Vector2(((Graphic) kowObj.BtnText1).rectTransform.sizeDelta.x, 31.5f);
          break;
        case 208:
          UnitComp3 sumObj = this.SumObj;
          if (sumObj == null)
            break;
          ActivityDataType allianceSummonData = this.AM.AllianceSummonData;
          if (allianceSummonData.EventState == EActivityState.EAS_Run)
          {
            sumObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8110U);
            sumObj.SA.SetSpriteIndex(1);
          }
          else if (allianceSummonData.EventState == EActivityState.EAS_Prepare)
          {
            sumObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111U);
            sumObj.SA.SetSpriteIndex(2);
          }
          else if (allianceSummonData.EventState == EActivityState.EAS_ReplayRanking)
          {
            sumObj.BtnText1.text = this.DM.mStringTable.GetStringByID(14520U);
            sumObj.SA.SetSpriteIndex(2);
          }
          else
          {
            sumObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111U);
            sumObj.SA.SetSpriteIndex(3);
          }
          if (allianceSummonData.EventState == EActivityState.EAS_ReplayRanking)
            ((Graphic) sumObj.BtnText1).rectTransform.sizeDelta = new Vector2(((Graphic) sumObj.BtnText1).rectTransform.sizeDelta.x, 55f);
          else
            ((Graphic) sumObj.BtnText1).rectTransform.sizeDelta = new Vector2(((Graphic) sumObj.BtnText1).rectTransform.sizeDelta.x, 31.5f);
          bool flag1 = this.AM.AllianceSummon_SummonData.MonsterEndTime > 0L;
          if (this.AM.AllianceSummon_SummonData.MonsterID > (ushort) 0 && (flag1 || this.AM.AllianceSummon_SummonData.CostPoint > (byte) 0 && (int) this.AM.AllianceSummon_SummonData.SummonPoint / (int) this.AM.AllianceSummon_SummonData.CostPoint >= 1))
          {
            sumObj.FlashGO.SetActive(true);
            break;
          }
          sumObj.FlashGO.SetActive(false);
          break;
        case 209:
          UnitComp3 nwObj = this.NWObj;
          if (nwObj == null)
            break;
          ActivityDataType nobilityActivityData = this.AM.NobilityActivityData;
          if (nobilityActivityData.EventState == EActivityState.EAS_Run)
          {
            nwObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8110U);
            nwObj.SA.SetSpriteIndex(1);
          }
          else if (nobilityActivityData.EventState == EActivityState.EAS_Prepare)
          {
            nwObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111U);
            nwObj.SA.SetSpriteIndex(2);
          }
          else if (nobilityActivityData.EventState == EActivityState.EAS_ReplayRanking)
          {
            nwObj.BtnText1.text = this.DM.mStringTable.GetStringByID(5042U);
            nwObj.SA.SetSpriteIndex(2);
          }
          else
          {
            nwObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111U);
            nwObj.SA.SetSpriteIndex(3);
          }
          if (nobilityActivityData.EventState == EActivityState.EAS_ReplayRanking)
          {
            ((Graphic) nwObj.BtnText1).rectTransform.sizeDelta = new Vector2(((Graphic) nwObj.BtnText1).rectTransform.sizeDelta.x, 55f);
            break;
          }
          ((Graphic) nwObj.BtnText1).rectTransform.sizeDelta = new Vector2(((Graphic) nwObj.BtnText1).rectTransform.sizeDelta.x, 31.5f);
          break;
        case 210:
          UnitComp3 awObj = this.AWObj;
          if (awObj == null)
            break;
          switch (this.AM.AW_State)
          {
            case EAllianceWarState.EAWS_SignUp:
              awObj.BtnText1.text = this.DM.mStringTable.GetStringByID(17001U);
              awObj.SA.SetSpriteIndex(1);
              return;
            case EAllianceWarState.EAWS_Prepare:
              awObj.BtnText1.text = this.DM.mStringTable.GetStringByID(17030U);
              awObj.SA.SetSpriteIndex(1);
              return;
            case EAllianceWarState.EAWS_Run:
              awObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8110U);
              awObj.SA.SetSpriteIndex(1);
              return;
            case EAllianceWarState.EAWS_Replay:
              awObj.BtnText1.text = this.DM.RoleAlliance.Id == 0U || (int) this.DM.RoleAlliance.Id != (int) this.AM.AW_SignUpAllianceID || this.AM.AW_NowAllianceEnterWar == (byte) 0 || this.AM.AW_GetGift != (byte) 0 ? this.DM.mStringTable.GetStringByID(14608U) : this.DM.mStringTable.GetStringByID(747U);
              awObj.SA.SetSpriteIndex(2);
              ((Graphic) awObj.BtnText1).rectTransform.sizeDelta = new Vector2(((Graphic) awObj.BtnText1).rectTransform.sizeDelta.x, 55f);
              return;
            default:
              awObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111U);
              awObj.SA.SetSpriteIndex(3);
              return;
          }
        default:
          if (index < 0 || index >= this.AllObject.Count)
            break;
          ActivityDataType activityDataType1 = this.AM.ActivityData[index];
          if (activityDataType1.EventState == EActivityState.EAS_Run)
          {
            this.AllObject[index].BtnText1.text = this.DM.mStringTable.GetStringByID(8110U);
            this.AllObject[index].SA.SetSpriteIndex(1);
            break;
          }
          if (activityDataType1.EventState == EActivityState.EAS_Prepare)
          {
            this.AllObject[index].BtnText1.text = this.DM.mStringTable.GetStringByID(8111U);
            this.AllObject[index].SA.SetSpriteIndex(2);
            break;
          }
          this.AllObject[index].BtnText1.text = this.DM.mStringTable.GetStringByID(8111U);
          this.AllObject[index].SA.SetSpriteIndex(3);
          break;
      }
    }
  }

  private void SetText(int index, int index2 = -1)
  {
    this.SetName(index, index2);
    this.SetScoreText(index);
    this.SetTimeText(index, index2);
  }

  private void SetName(int index, int index2 = -1)
  {
    if (index == 254 || index == (int) byte.MaxValue)
    {
      bool flag = index == 254;
      UnitComp3 unitComp3 = !flag ? this.SPObj[index2] : this.CSObj[index2];
      if (unitComp3 == null)
        return;
      SPActivityDataType activityDataType = !flag ? this.AM.SPActivityData[index2] : this.AM.CSActivityData[index2];
      unitComp3.NameText.text = this.DM.mStringTable.GetStringByID((uint) activityDataType.Name);
    }
    else if (index >= 201 && index <= 205)
    {
      index -= 201;
      UnitComp3 unitComp3 = this.KVKObj[index];
      if (unitComp3 == null)
        return;
      unitComp3.NameText.text = this.DM.mStringTable.GetStringByID((uint) this.AM.KvKActivityData[index].Name);
    }
    else
    {
      switch (index)
      {
        case 206:
          UnitComp3 amObj = this.AMObj;
          if (amObj == null)
            break;
          amObj.NameText.text = this.DM.mStringTable.GetStringByID((uint) this.AM.AllyMobilizationData.Name);
          break;
        case 207:
          UnitComp3 kowObj = this.KOWObj;
          if (kowObj == null)
            break;
          kowObj.NameText.text = this.DM.mStringTable.GetStringByID((uint) this.AM.KOWData.Name);
          break;
        case 208:
          UnitComp3 sumObj = this.SumObj;
          if (sumObj == null)
            break;
          sumObj.NameText.text = this.DM.mStringTable.GetStringByID((uint) this.AM.AllianceSummonData.Name);
          break;
        case 209:
          UnitComp3 nwObj = this.NWObj;
          if (nwObj == null)
            break;
          nwObj.NameText.text = this.DM.mStringTable.GetStringByID((uint) this.AM.NobilityActivityData.Name);
          break;
        case 210:
          UnitComp3 awObj = this.AWObj;
          if (awObj == null)
            break;
          awObj.NameText.text = this.DM.mStringTable.GetStringByID((uint) this.AM.AllianceWarData.Name);
          break;
        default:
          if (index < 0 || index >= this.AllObject.Count)
            break;
          this.AllObject[index].NameText.text = this.DM.mStringTable.GetStringByID((uint) this.AM.ActivityData[index].Name);
          break;
      }
    }
  }

  private void SetScoreText(int index)
  {
    if (index >= 201 && index <= 204)
    {
      index -= 201;
      UnitComp3 unitComp3 = this.KVKObj[index];
      if (unitComp3 == null)
        return;
      ActivityDataType activityDataType = this.AM.KvKActivityData[index];
      if (activityDataType.EventState == EActivityState.EAS_None)
      {
        unitComp3.InfoText.text = this.DM.mStringTable.GetStringByID(8112U);
        ((Behaviour) unitComp3.RewardText).enabled = false;
        if (!unitComp3.ScoreGO.activeInHierarchy)
          return;
        unitComp3.ScoreGO.SetActive(false);
      }
      else
      {
        ((Behaviour) unitComp3.RewardText).enabled = true;
        if (!unitComp3.ScoreGO.activeInHierarchy)
          unitComp3.ScoreGO.SetActive(true);
        unitComp3.RewardStr.Length = 0;
        if (activityDataType.KVKActiveType != EKVKActivityType.EKAT_KvKAllianceEvent)
        {
          unitComp3.RewardStr.IntToFormat((long) activityDataType.EventAllDegreePrizeWorthData.CrystalPrice, bNumber: true);
          unitComp3.RewardStr.AppendFormat(this.DM.mStringTable.GetStringByID(8113U));
        }
        unitComp3.RewardText.text = unitComp3.RewardStr.ToString();
        unitComp3.RewardText.SetAllDirty();
        unitComp3.RewardText.cachedTextGenerator.Invalidate();
        for (int index1 = 0; index1 < 3; ++index1)
        {
          unitComp3.SliderNormal[index1].fillAmount = 0.0f;
          ((Component) unitComp3.SliderFlash[index1]).gameObject.SetActive(false);
        }
        int index2 = 0;
        for (int index3 = 0; index3 < 3; ++index3)
        {
          if (activityDataType.EventScore >= (ulong) activityDataType.RequireScore[index3])
            ++index2;
        }
        if (index2 < 3)
        {
          if (index2 == 0)
          {
            double num = (double) activityDataType.RequireScore[index2];
            unitComp3.SliderNormal[index2].fillAmount = num <= 0.0 ? 0.0f : (float) activityDataType.EventScore / (float) num;
          }
          else
          {
            double num = (double) (activityDataType.RequireScore[index2] - activityDataType.RequireScore[index2 - 1]);
            unitComp3.SliderNormal[index2].fillAmount = num <= 0.0 ? 0.0f : (float) (activityDataType.EventScore - (ulong) activityDataType.RequireScore[index2 - 1]) / (float) num;
          }
        }
        for (int index4 = 0; index4 < index2; ++index4)
        {
          unitComp3.SliderNormal[index4].fillAmount = 1f;
          ((Component) unitComp3.SliderFlash[index4]).gameObject.SetActive(true);
        }
        unitComp3.InfoStr.Length = 0;
        if (index2 == 3)
        {
          unitComp3.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8114U));
        }
        else
        {
          unitComp3.InfoStr.uLongToFormat((ulong) activityDataType.RequireScore[index2] - activityDataType.EventScore, bNumber: true);
          unitComp3.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8115U));
        }
        unitComp3.InfoText.text = unitComp3.InfoStr.ToString();
        unitComp3.InfoText.SetAllDirty();
        unitComp3.InfoText.cachedTextGenerator.Invalidate();
      }
    }
    else
    {
      if (index == 205 || index == 207 || index == 209 || index == 210)
        return;
      switch (index)
      {
        case 206:
          UnitComp3 amObj = this.AMObj;
          if (amObj == null)
            break;
          ActivityDataType mobilizationData = this.AM.AllyMobilizationData;
          MobilizationManager instance = MobilizationManager.Instance;
          amObj.RewardStr.Length = 0;
          amObj.InfoStr.Length = 0;
          if (this.DM.RoleAlliance.Id <= 0U)
          {
            ((Component) amObj.RankSlider2).gameObject.SetActive(false);
            amObj.RankSlider.fillAmount = 0.0f;
            StringManager.ulongToStr(amObj.RewardStr, 0UL);
            amObj.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(689U));
          }
          else if (mobilizationData.EventState == EActivityState.EAS_ReplayRanking)
          {
            if ((int) instance.AMCompleteDegree == (int) this.DM.RoleAlliance.AMMaxDegree)
            {
              amObj.RankSlider.fillAmount = 1f;
              ((Component) amObj.RankSlider2).gameObject.SetActive(true);
              StringManager.ulongToStr(amObj.RewardStr, (ulong) instance.AMCompleteDegree);
            }
            else
            {
              ((Component) amObj.RankSlider2).gameObject.SetActive(false);
              amObj.RankSlider.fillAmount = this.GetFillAmount();
              StringManager.ulongToStr(amObj.RewardStr, (ulong) instance.AMCompleteDegree);
            }
          }
          else if ((int) instance.AMCompleteDegree == (int) this.DM.RoleAlliance.AMMaxDegree)
          {
            amObj.RankSlider.fillAmount = 1f;
            ((Component) amObj.RankSlider2).gameObject.SetActive(true);
            StringManager.ulongToStr(amObj.RewardStr, (ulong) instance.AMCompleteDegree);
            amObj.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8114U));
          }
          else
          {
            ((Component) amObj.RankSlider2).gameObject.SetActive(false);
            amObj.RankSlider.fillAmount = this.GetFillAmount();
            StringManager.ulongToStr(amObj.RewardStr, (ulong) instance.AMCompleteDegree);
            amObj.InfoStr.uLongToFormat((ulong) (instance.CompleteScore - instance.AMScore), bNumber: true);
            amObj.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8115U));
          }
          amObj.RankText.text = amObj.RewardStr.ToString();
          amObj.RankText.SetAllDirty();
          amObj.RankText.cachedTextGenerator.Invalidate();
          amObj.InfoText.text = amObj.InfoStr.ToString();
          amObj.InfoText.SetAllDirty();
          amObj.InfoText.cachedTextGenerator.Invalidate();
          break;
        case 208:
          UnitComp3 sumObj = this.SumObj;
          if (sumObj == null)
            break;
          ActivityDataType allianceSummonData = this.AM.AllianceSummonData;
          if (allianceSummonData.EventState == EActivityState.EAS_None)
          {
            sumObj.InfoText.text = this.DM.mStringTable.GetStringByID(8112U);
            if (!sumObj.ScoreGO.activeInHierarchy)
              break;
            sumObj.ScoreGO.SetActive(false);
            break;
          }
          if (!sumObj.ScoreGO.activeInHierarchy)
            sumObj.ScoreGO.SetActive(true);
          for (int index5 = 0; index5 < 3; ++index5)
          {
            sumObj.SliderNormal[index5].fillAmount = 0.0f;
            ((Component) sumObj.SliderFlash[index5]).gameObject.SetActive(false);
          }
          int index6 = 0;
          for (int index7 = 0; index7 < 3; ++index7)
          {
            if (allianceSummonData.EventScore >= (ulong) allianceSummonData.RequireScore[index7])
              ++index6;
          }
          if (index6 < 3)
          {
            if (index6 == 0)
            {
              double num = (double) allianceSummonData.RequireScore[index6];
              sumObj.SliderNormal[index6].fillAmount = num <= 0.0 ? 0.0f : (float) allianceSummonData.EventScore / (float) num;
            }
            else
            {
              double num = (double) (allianceSummonData.RequireScore[index6] - allianceSummonData.RequireScore[index6 - 1]);
              sumObj.SliderNormal[index6].fillAmount = num <= 0.0 ? 0.0f : (float) (allianceSummonData.EventScore - (ulong) allianceSummonData.RequireScore[index6 - 1]) / (float) num;
            }
          }
          for (int index8 = 0; index8 < index6; ++index8)
          {
            sumObj.SliderNormal[index8].fillAmount = 1f;
            ((Component) sumObj.SliderFlash[index8]).gameObject.SetActive(true);
          }
          sumObj.InfoStr.Length = 0;
          if (this.DM.RoleAlliance.Id <= 0U)
            sumObj.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(689U));
          else if (allianceSummonData.EventState != EActivityState.EAS_ReplayRanking)
          {
            if (index6 == 3)
            {
              sumObj.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8114U));
            }
            else
            {
              sumObj.InfoStr.uLongToFormat((ulong) allianceSummonData.RequireScore[index6] - allianceSummonData.EventScore, bNumber: true);
              sumObj.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8115U));
            }
          }
          sumObj.InfoText.text = sumObj.InfoStr.ToString();
          sumObj.InfoText.SetAllDirty();
          sumObj.InfoText.cachedTextGenerator.Invalidate();
          break;
        default:
          if (index < 0 || index >= this.AllObject.Count)
            break;
          ActivityDataType activityDataType = this.AM.ActivityData[index];
          if (activityDataType.EventState == EActivityState.EAS_None)
          {
            this.AllObject[index].InfoText.text = this.DM.mStringTable.GetStringByID(8112U);
            ((Behaviour) this.AllObject[index].RewardText).enabled = false;
            if (!this.AllObject[index].ScoreGO.activeInHierarchy)
              break;
            this.AllObject[index].ScoreGO.SetActive(false);
            break;
          }
          ((Behaviour) this.AllObject[index].RewardText).enabled = true;
          if (!this.AllObject[index].ScoreGO.activeInHierarchy)
            this.AllObject[index].ScoreGO.SetActive(true);
          this.AllObject[index].RewardStr.Length = 0;
          this.AllObject[index].RewardStr.IntToFormat((long) activityDataType.EventAllDegreePrizeWorthData.CrystalPrice, bNumber: true);
          this.AllObject[index].RewardStr.AppendFormat(this.DM.mStringTable.GetStringByID(8113U));
          this.AllObject[index].RewardText.text = this.AllObject[index].RewardStr.ToString();
          this.AllObject[index].RewardText.SetAllDirty();
          this.AllObject[index].RewardText.cachedTextGenerator.Invalidate();
          for (int index9 = 0; index9 < 3; ++index9)
          {
            this.AllObject[index].SliderNormal[index9].fillAmount = 0.0f;
            ((Component) this.AllObject[index].SliderFlash[index9]).gameObject.SetActive(false);
          }
          int index10 = 0;
          for (int index11 = 0; index11 < 3; ++index11)
          {
            if (activityDataType.EventScore >= (ulong) activityDataType.RequireScore[index11])
              ++index10;
          }
          if (index10 < 3)
          {
            if (index10 == 0)
            {
              double num = (double) activityDataType.RequireScore[index10];
              this.AllObject[index].SliderNormal[index10].fillAmount = num <= 0.0 ? 0.0f : (float) activityDataType.EventScore / (float) num;
            }
            else
            {
              double num = (double) (activityDataType.RequireScore[index10] - activityDataType.RequireScore[index10 - 1]);
              this.AllObject[index].SliderNormal[index10].fillAmount = num <= 0.0 ? 0.0f : (float) (activityDataType.EventScore - (ulong) activityDataType.RequireScore[index10 - 1]) / (float) num;
            }
          }
          for (int index12 = 0; index12 < index10; ++index12)
          {
            this.AllObject[index].SliderNormal[index12].fillAmount = 1f;
            ((Component) this.AllObject[index].SliderFlash[index12]).gameObject.SetActive(true);
          }
          this.AllObject[index].InfoStr.Length = 0;
          if (index10 == 3)
          {
            this.AllObject[index].InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8114U));
          }
          else
          {
            this.AllObject[index].InfoStr.uLongToFormat((ulong) activityDataType.RequireScore[index10] - activityDataType.EventScore, bNumber: true);
            this.AllObject[index].InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8115U));
          }
          this.AllObject[index].InfoText.text = this.AllObject[index].InfoStr.ToString();
          this.AllObject[index].InfoText.SetAllDirty();
          this.AllObject[index].InfoText.cachedTextGenerator.Invalidate();
          break;
      }
    }
  }

  private void SetTimeText(int index, int index2 = -1)
  {
    if (index == 254 || index == (int) byte.MaxValue)
    {
      bool flag = index == 254;
      SPActivityDataType activityDataType = !flag ? this.AM.SPActivityData[index2] : this.AM.CSActivityData[index2];
      UnitComp3 unitComp3 = !flag ? this.SPObj[index2] : this.CSObj[index2];
      if (unitComp3 == null)
        return;
      long sec = !flag ? activityDataType.EventEndTime - this.DM.ServerTime : activityDataType.EventBeginTime - this.DM.ServerTime;
      if (sec < 0L)
        sec = 0L;
      unitComp3.BtnStr.Length = 0;
      GameConstants.GetTimeString(unitComp3.BtnStr, (uint) sec, hideTimeIfDays: true, showZeroHour: false);
      unitComp3.BtnText2.text = unitComp3.BtnStr.ToString();
      unitComp3.BtnText2.SetAllDirty();
      unitComp3.BtnText2.cachedTextGenerator.Invalidate();
    }
    else if (index >= 201 && index <= 205)
    {
      index -= 201;
      UnitComp3 unitComp3 = this.KVKObj[index];
      if (unitComp3 == null)
        return;
      ActivityDataType activityDataType = this.AM.KvKActivityData[index];
      unitComp3.BtnStr.Length = 0;
      if (activityDataType.EventState != EActivityState.EAS_ReplayRanking)
        GameConstants.GetTimeString(unitComp3.BtnStr, (uint) activityDataType.EventCountTime, hideTimeIfDays: true, showZeroHour: false);
      unitComp3.BtnText2.text = unitComp3.BtnStr.ToString();
      unitComp3.BtnText2.SetAllDirty();
      unitComp3.BtnText2.cachedTextGenerator.Invalidate();
    }
    else
    {
      switch (index)
      {
        case 206:
          UnitComp3 amObj = this.AMObj;
          if (amObj == null)
            break;
          ActivityDataType mobilizationData = this.AM.AllyMobilizationData;
          amObj.BtnStr.Length = 0;
          if (mobilizationData.EventState != EActivityState.EAS_ReplayRanking)
            GameConstants.GetTimeString(amObj.BtnStr, (uint) mobilizationData.EventCountTime, hideTimeIfDays: true, showZeroHour: false);
          amObj.BtnText2.text = amObj.BtnStr.ToString();
          amObj.BtnText2.SetAllDirty();
          amObj.BtnText2.cachedTextGenerator.Invalidate();
          break;
        case 207:
          UnitComp3 kowObj = this.KOWObj;
          if (kowObj == null)
            break;
          ActivityDataType kowData = this.AM.KOWData;
          kowObj.BtnStr.Length = 0;
          if (kowData.EventState != EActivityState.EAS_ReplayRanking)
            GameConstants.GetTimeString(kowObj.BtnStr, (uint) kowData.EventCountTime, hideTimeIfDays: true, showZeroHour: false);
          kowObj.BtnText2.text = kowObj.BtnStr.ToString();
          kowObj.BtnText2.SetAllDirty();
          kowObj.BtnText2.cachedTextGenerator.Invalidate();
          break;
        case 208:
          UnitComp3 sumObj = this.SumObj;
          if (sumObj == null)
            break;
          ActivityDataType allianceSummonData = this.AM.AllianceSummonData;
          sumObj.BtnStr.Length = 0;
          if (allianceSummonData.EventState != EActivityState.EAS_ReplayRanking)
            GameConstants.GetTimeString(sumObj.BtnStr, (uint) allianceSummonData.EventCountTime, hideTimeIfDays: true, showZeroHour: false);
          sumObj.BtnText2.text = sumObj.BtnStr.ToString();
          sumObj.BtnText2.SetAllDirty();
          sumObj.BtnText2.cachedTextGenerator.Invalidate();
          break;
        case 209:
          UnitComp3 nwObj = this.NWObj;
          if (nwObj == null)
            break;
          ActivityDataType nobilityActivityData = this.AM.NobilityActivityData;
          nwObj.BtnStr.Length = 0;
          if (nobilityActivityData.EventState != EActivityState.EAS_ReplayRanking)
            GameConstants.GetTimeString(nwObj.BtnStr, (uint) nobilityActivityData.EventCountTime, hideTimeIfDays: true, showZeroHour: false);
          nwObj.BtnText2.text = nwObj.BtnStr.ToString();
          nwObj.BtnText2.SetAllDirty();
          nwObj.BtnText2.cachedTextGenerator.Invalidate();
          break;
        case 210:
          UnitComp3 awObj = this.AWObj;
          if (awObj == null)
            break;
          ActivityDataType allianceWarData = this.AM.AllianceWarData;
          awObj.BtnStr.Length = 0;
          if (this.AM.AW_State != EAllianceWarState.EAWS_Replay)
            GameConstants.GetTimeString(awObj.BtnStr, (uint) allianceWarData.EventCountTime, hideTimeIfDays: true, showZeroHour: false);
          awObj.BtnText2.text = awObj.BtnStr.ToString();
          awObj.BtnText2.SetAllDirty();
          awObj.BtnText2.cachedTextGenerator.Invalidate();
          break;
        default:
          if (index < 0 || index >= this.AllObject.Count)
            break;
          ActivityDataType activityDataType1 = this.AM.ActivityData[index];
          this.AllObject[index].BtnStr.Length = 0;
          GameConstants.GetTimeString(this.AllObject[index].BtnStr, (uint) activityDataType1.EventCountTime, hideTimeIfDays: true, showZeroHour: false);
          this.AllObject[index].BtnText2.text = this.AllObject[index].BtnStr.ToString();
          this.AllObject[index].BtnText2.SetAllDirty();
          this.AllObject[index].BtnText2.cachedTextGenerator.Invalidate();
          break;
      }
    }
  }

  private void SetMiddleText(int index, int index2 = -1)
  {
    switch (index)
    {
      case 205:
        if (this.KVKObj[4] == null)
          break;
        this.KVKObj[4].InfoText.text = this.DM.mStringTable.GetStringByID(9847U);
        break;
      case 207:
        if (this.KOWObj == null)
          break;
        this.KOWObj.InfoText.text = this.DM.mStringTable.GetStringByID(10017U);
        break;
      case 208:
        if (this.SumObj == null)
          break;
        this.SumObj.InfoText.text = this.DM.mStringTable.GetStringByID(10017U);
        break;
      case 209:
        if (this.NWObj == null)
          break;
        this.NWObj.InfoText.text = this.DM.mStringTable.GetStringByID(5041U);
        break;
      case 210:
        if (this.AWObj == null)
          break;
        if (this.DM.RoleAlliance.Id == 0U)
        {
          this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(689U);
          break;
        }
        switch (this.AM.AW_State)
        {
          case EAllianceWarState.EAWS_SignUp:
            this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(14602U);
            return;
          case EAllianceWarState.EAWS_Prepare:
            this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(14603U);
            return;
          case EAllianceWarState.EAWS_Run:
            if (this.AM.AW_Round == (byte) 1)
            {
              this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(14604U);
              return;
            }
            if (this.AM.AW_Round == (byte) 2)
            {
              this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(14605U);
              return;
            }
            if (this.AM.AW_Round == (byte) 3)
            {
              this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(14606U);
              return;
            }
            if (this.AM.AW_Round == (byte) 4)
            {
              this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(14607U);
              return;
            }
            this.AWObj.InfoText.text = string.Empty;
            return;
          case EAllianceWarState.EAWS_Replay:
            this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(5042U);
            return;
          default:
            this.AWObj.InfoText.text = string.Empty;
            return;
        }
      case 254:
      case (int) byte.MaxValue:
        bool flag = index == 254;
        SPActivityDataType activityDataType = !flag ? this.AM.SPActivityData[index2] : this.AM.CSActivityData[index2];
        UnitComp3 unitComp3 = !flag ? this.SPObj[index2] : this.CSObj[index2];
        if (unitComp3 == null)
          break;
        if (activityDataType.bDownLoadStr)
        {
          if (activityDataType.bUpDateStr)
          {
            if ((int) this.AM.CSActivityData[index2].DetailStr == (int) activityDataType.DetailStr)
              this.AM.CSActivityData[index2].UnloadStrAB();
            if ((int) this.AM.SPActivityData[index2].DetailStr == (int) activityDataType.DetailStr)
              this.AM.SPActivityData[index2].UnloadStrAB();
            activityDataType.bUpDateStr = false;
          }
          if (activityDataType.m_StrAssetBundleKey == 0)
            activityDataType.InitialABString();
          if (!((Object) activityDataType.DownLoadStr != (Object) null))
            break;
          byte index1 = (byte) ((uint) (this.DM.UserLanguage - (byte) 1) * (uint) activityDataType.DownLoadStr.Count);
          if ((int) index1 >= activityDataType.DownLoadStr.Content.Length || activityDataType.DownLoadStr.Content[(int) index1] == string.Empty)
            index1 = (byte) 0;
          unitComp3.InfoText.text = activityDataType.DownLoadStr.Content[(int) index1];
          break;
        }
        unitComp3.InfoText.text = string.Empty;
        break;
    }
  }

  private void CheckNews()
  {
    if (this.NewsObj == null)
      return;
    long showNewsNo = (long) this.AM.ShowNewsNo;
    if (showNewsNo <= 0L)
    {
      ((Component) this.NewsObj.FlashRC).gameObject.SetActive(false);
    }
    else
    {
      this.NewsObj.FlashStr.ClearString();
      this.NewsObj.FlashStr.IntToFormat(showNewsNo);
      this.NewsObj.FlashStr.AppendFormat("{0}");
      this.NewsObj.FlashText.text = this.NewsObj.FlashStr.ToString();
      this.NewsObj.FlashText.SetAllDirty();
      this.NewsObj.FlashText.cachedTextGenerator.Invalidate();
      this.NewsObj.FlashText.cachedTextGeneratorForLayout.Invalidate();
      this.NewsObj.FlashRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.NewsObj.FlashText.preferredWidth), 51f);
      ((Component) this.NewsObj.FlashRC).gameObject.SetActive(true);
    }
  }

  private void CheckAMShowHint()
  {
    if (this.AMObj == null)
      return;
    this.AMObj.FlashGO.SetActive(this.AM.bShowAMHint);
  }

  private void CheckNWShowHint()
  {
    if (this.NWObj == null)
      return;
    this.NWObj.FlashGO.SetActive(this.AM.bForceNWActivity);
  }

  private void CheckAWShowHint()
  {
    if (this.AWObj == null)
      return;
    this.AWObj.FlashGO.SetActive(this.AM.bShowAWHint);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        for (int index = 0; index < this.AM.ActivityData.Length; ++index)
          this.SetTimeText(index);
        for (int index = 201; index <= 205; ++index)
          this.SetTimeText(index);
        for (int index2 = 0; index2 < 5; ++index2)
          this.SetTimeText(254, index2);
        for (int index2 = 0; index2 < 5; ++index2)
          this.SetTimeText((int) byte.MaxValue, index2);
        this.SetTimeText(206);
        this.SetTimeText(207);
        this.SetTimeText(208);
        this.SetTimeText(209);
        this.SetTimeText(210);
        break;
      case 2:
        this.SetScoreText(arg2);
        break;
      case 3:
        if (arg2 >= 201 && arg2 <= 205)
        {
          if (this.AM.KvKActivityData[arg2 - 201].EventState == EActivityState.EAS_Prepare)
          {
            ActivityManager.Instance.Send_ACTIVITY_KEVENT_LIST_SINGLE((byte) arg2);
            break;
          }
          this.SetText(arg2);
          this.SetBackImg(arg2);
          this.SetMainImg(arg2);
          break;
        }
        switch (arg2)
        {
          case 206:
            if (this.AM.AllyMobilizationData.EventState == EActivityState.EAS_Prepare)
            {
              ActivityManager.Instance.Send_ACTIVITY_EVENT_LIST_SINGLE((byte) 6);
              return;
            }
            this.SetText(arg2);
            this.SetBackImg(arg2);
            this.SetMainImg(arg2);
            return;
          case 207:
            if (this.AM.KOWData.EventState == EActivityState.EAS_Prepare)
            {
              ActivityManager.Instance.Send_ACTIVITY_EVENT_LIST_SINGLE((byte) 7);
              return;
            }
            this.SetText(arg2);
            this.SetBackImg(arg2);
            this.SetMainImg(arg2);
            return;
          case 208:
            if (this.AM.AllianceSummonData.EventState == EActivityState.EAS_Prepare)
            {
              ActivityManager.Instance.Send_ACTIVITY_EVENT_LIST_SINGLE((byte) 11);
              return;
            }
            this.SetText(arg2);
            this.SetBackImg(arg2);
            this.SetMainImg(arg2);
            return;
          case 209:
            if (this.AM.NobilityActivityData.EventState == EActivityState.EAS_Prepare)
            {
              ActivityManager.Instance.Send_ACTIVITY_EVENT_LIST_SINGLE((byte) 12);
              return;
            }
            this.SetText(arg2);
            this.SetBackImg(arg2);
            this.SetMainImg(arg2);
            return;
          case 210:
            if (this.AM.AllianceWarData.EventState == EActivityState.EAS_Prepare)
            {
              ActivityManager.Instance.Send_ACTIVITY_EVENT_LIST_SINGLE((byte) 13);
              return;
            }
            this.SetText(arg2);
            this.SetBackImg(arg2);
            this.SetMainImg(arg2);
            return;
          default:
            if (arg2 < 0 || arg2 >= this.AllObject.Count)
              return;
            if (this.AM.ActivityData[arg2].EventState == EActivityState.EAS_Prepare)
            {
              ActivityManager.Instance.Send_ACTIVITY_EVENT_LIST_SINGLE((byte) arg2);
              return;
            }
            this.SetText(arg2);
            this.SetBackImg(arg2);
            this.SetMainImg(arg2);
            return;
        }
      case 4:
        this.SetText(arg2);
        this.SetBackImg(arg2);
        this.SetMainImg(arg2);
        break;
      case 5:
        this.ResetAll();
        break;
      case 6:
        for (int index2 = 0; index2 < this.AM.CSActivityData.Length; ++index2)
        {
          if (this.AM.CSActivityData[index2].EventBeginTime > 0L)
            this.SetMainImg(254, index2);
        }
        for (int index2 = 0; index2 < this.AM.SPActivityData.Length; ++index2)
        {
          if (this.AM.SPActivityData[index2].EventBeginTime > 0L)
            this.SetMainImg((int) byte.MaxValue, index2);
        }
        for (int index = 201; index <= 205; ++index)
          this.SetMainImg(index);
        this.SetMainImg(206);
        this.SetMainImg(207);
        this.SetMainImg(208);
        this.SetMainImg(209);
        this.SetMainImg(210);
        break;
      case 7:
        for (int index2 = 0; index2 < this.AM.CSActivityData.Length; ++index2)
        {
          if (this.AM.CSActivityData[index2].EventBeginTime > 0L)
            this.SetMiddleText(254, index2);
        }
        for (int index2 = 0; index2 < this.AM.SPActivityData.Length; ++index2)
        {
          if (this.AM.SPActivityData[index2].EventBeginTime > 0L)
            this.SetMiddleText((int) byte.MaxValue, index2);
        }
        this.SetMiddleText(205);
        this.SetMiddleText(206);
        this.SetMiddleText(207);
        this.SetMiddleText(208);
        this.SetMiddleText(209);
        this.SetMiddleText(210);
        break;
      case 8:
        this.CheckNews();
        break;
      case 9:
        this.SetText(254, arg2);
        this.SetBackImg(254, arg2);
        this.SetMainImg(254, arg2);
        break;
      case 10:
        this.SetText((int) byte.MaxValue, arg2);
        this.SetBackImg((int) byte.MaxValue, arg2);
        this.SetMainImg((int) byte.MaxValue, arg2);
        break;
      case 11:
        this.CheckAMShowHint();
        break;
      case 12:
        if (this.AMObj == null)
          break;
        this.GM.SetAllyRankImage(this.AMObj.AllyRankImg, this.DM.RoleAlliance.AMRank);
        break;
      case 13:
        this.SetBackImg(arg2);
        break;
      case 14:
        this.CheckNWShowHint();
        break;
      case 15:
        if (this.AWObj == null)
          break;
        this.GM.SetAllyWarRankImage(this.AWObj.AllyRankImg, this.AM.AW_Rank);
        break;
      case 16:
        this.CheckAWShowHint();
        break;
      case 17:
        this.SetText(210);
        this.SetMiddleText(210);
        this.SetBackImg(210);
        this.SetMainImg(210);
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        ActivityManager.Instance.Send_ACTIVITY_EVENT_LIST();
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        if ((Object) this.BgText != (Object) null && ((Behaviour) this.BgText).enabled)
        {
          ((Behaviour) this.BgText).enabled = false;
          ((Behaviour) this.BgText).enabled = true;
        }
        for (int index = 0; index < this.AllObject.Count; ++index)
        {
          if (this.AllObject[index] != null)
          {
            if ((Object) this.AllObject[index].NameText != (Object) null && ((Behaviour) this.AllObject[index].NameText).enabled)
            {
              ((Behaviour) this.AllObject[index].NameText).enabled = false;
              ((Behaviour) this.AllObject[index].NameText).enabled = true;
            }
            if ((Object) this.AllObject[index].RewardText != (Object) null && ((Behaviour) this.AllObject[index].RewardText).enabled)
            {
              ((Behaviour) this.AllObject[index].RewardText).enabled = false;
              ((Behaviour) this.AllObject[index].RewardText).enabled = true;
            }
            if ((Object) this.AllObject[index].InfoText != (Object) null && ((Behaviour) this.AllObject[index].InfoText).enabled)
            {
              ((Behaviour) this.AllObject[index].InfoText).enabled = false;
              ((Behaviour) this.AllObject[index].InfoText).enabled = true;
            }
            if ((Object) this.AllObject[index].BtnText1 != (Object) null && ((Behaviour) this.AllObject[index].BtnText1).enabled)
            {
              ((Behaviour) this.AllObject[index].BtnText1).enabled = false;
              ((Behaviour) this.AllObject[index].BtnText1).enabled = true;
            }
            if ((Object) this.AllObject[index].BtnText2 != (Object) null && ((Behaviour) this.AllObject[index].BtnText2).enabled)
            {
              ((Behaviour) this.AllObject[index].BtnText2).enabled = false;
              ((Behaviour) this.AllObject[index].BtnText2).enabled = true;
            }
          }
        }
        for (int index = 0; index < this.CSObj.Length; ++index)
        {
          if (this.CSObj[index] != null)
          {
            if ((Object) this.CSObj[index].NameText != (Object) null && ((Behaviour) this.CSObj[index].NameText).enabled)
            {
              ((Behaviour) this.CSObj[index].NameText).enabled = false;
              ((Behaviour) this.CSObj[index].NameText).enabled = true;
            }
            if ((Object) this.CSObj[index].RewardText != (Object) null && ((Behaviour) this.CSObj[index].RewardText).enabled)
            {
              ((Behaviour) this.CSObj[index].RewardText).enabled = false;
              ((Behaviour) this.CSObj[index].RewardText).enabled = true;
            }
            if ((Object) this.CSObj[index].InfoText != (Object) null && ((Behaviour) this.CSObj[index].InfoText).enabled)
            {
              ((Behaviour) this.CSObj[index].InfoText).enabled = false;
              ((Behaviour) this.CSObj[index].InfoText).enabled = true;
            }
            if ((Object) this.CSObj[index].BtnText1 != (Object) null && ((Behaviour) this.CSObj[index].BtnText1).enabled)
            {
              ((Behaviour) this.CSObj[index].BtnText1).enabled = false;
              ((Behaviour) this.CSObj[index].BtnText1).enabled = true;
            }
            if ((Object) this.CSObj[index].BtnText2 != (Object) null && ((Behaviour) this.CSObj[index].BtnText2).enabled)
            {
              ((Behaviour) this.CSObj[index].BtnText2).enabled = false;
              ((Behaviour) this.CSObj[index].BtnText2).enabled = true;
            }
          }
        }
        for (int index = 0; index < this.SPObj.Length; ++index)
        {
          if (this.SPObj[index] != null)
          {
            if ((Object) this.SPObj[index].NameText != (Object) null && ((Behaviour) this.SPObj[index].NameText).enabled)
            {
              ((Behaviour) this.SPObj[index].NameText).enabled = false;
              ((Behaviour) this.SPObj[index].NameText).enabled = true;
            }
            if ((Object) this.SPObj[index].RewardText != (Object) null && ((Behaviour) this.SPObj[index].RewardText).enabled)
            {
              ((Behaviour) this.SPObj[index].RewardText).enabled = false;
              ((Behaviour) this.SPObj[index].RewardText).enabled = true;
            }
            if ((Object) this.SPObj[index].InfoText != (Object) null && ((Behaviour) this.SPObj[index].InfoText).enabled)
            {
              ((Behaviour) this.SPObj[index].InfoText).enabled = false;
              ((Behaviour) this.SPObj[index].InfoText).enabled = true;
            }
            if ((Object) this.SPObj[index].BtnText1 != (Object) null && ((Behaviour) this.SPObj[index].BtnText1).enabled)
            {
              ((Behaviour) this.SPObj[index].BtnText1).enabled = false;
              ((Behaviour) this.SPObj[index].BtnText1).enabled = true;
            }
            if ((Object) this.SPObj[index].BtnText2 != (Object) null && ((Behaviour) this.SPObj[index].BtnText2).enabled)
            {
              ((Behaviour) this.SPObj[index].BtnText2).enabled = false;
              ((Behaviour) this.SPObj[index].BtnText2).enabled = true;
            }
          }
        }
        if (this.NewsObj != null && (Object) this.NewsObj.NameText != (Object) null && ((Behaviour) this.NewsObj.NameText).enabled)
        {
          ((Behaviour) this.NewsObj.NameText).enabled = false;
          ((Behaviour) this.NewsObj.NameText).enabled = true;
        }
        if (this.AMObj != null)
        {
          if ((Object) this.AMObj.NameText != (Object) null && ((Behaviour) this.AMObj.NameText).enabled)
          {
            ((Behaviour) this.AMObj.NameText).enabled = false;
            ((Behaviour) this.AMObj.NameText).enabled = true;
          }
          if ((Object) this.AMObj.RewardText != (Object) null && ((Behaviour) this.AMObj.RewardText).enabled)
          {
            ((Behaviour) this.AMObj.RewardText).enabled = false;
            ((Behaviour) this.AMObj.RewardText).enabled = true;
          }
          if ((Object) this.AMObj.InfoText != (Object) null && ((Behaviour) this.AMObj.InfoText).enabled)
          {
            ((Behaviour) this.AMObj.InfoText).enabled = false;
            ((Behaviour) this.AMObj.InfoText).enabled = true;
          }
          if ((Object) this.AMObj.BtnText1 != (Object) null && ((Behaviour) this.AMObj.BtnText1).enabled)
          {
            ((Behaviour) this.AMObj.BtnText1).enabled = false;
            ((Behaviour) this.AMObj.BtnText1).enabled = true;
          }
          if ((Object) this.AMObj.BtnText2 != (Object) null && ((Behaviour) this.AMObj.BtnText2).enabled)
          {
            ((Behaviour) this.AMObj.BtnText2).enabled = false;
            ((Behaviour) this.AMObj.BtnText2).enabled = true;
          }
          if ((Object) this.AMObj.RankText != (Object) null && ((Behaviour) this.AMObj.RankText).enabled)
          {
            ((Behaviour) this.AMObj.RankText).enabled = false;
            ((Behaviour) this.AMObj.RankText).enabled = true;
          }
          if ((Object) this.AMObj.AllyRankText != (Object) null && ((Behaviour) this.AMObj.AllyRankText).enabled)
          {
            ((Behaviour) this.AMObj.AllyRankText).enabled = false;
            ((Behaviour) this.AMObj.AllyRankText).enabled = true;
          }
        }
        if (this.KOWObj != null)
        {
          if ((Object) this.KOWObj.NameText != (Object) null && ((Behaviour) this.KOWObj.NameText).enabled)
          {
            ((Behaviour) this.KOWObj.NameText).enabled = false;
            ((Behaviour) this.KOWObj.NameText).enabled = true;
          }
          if ((Object) this.KOWObj.RewardText != (Object) null && ((Behaviour) this.KOWObj.RewardText).enabled)
          {
            ((Behaviour) this.KOWObj.RewardText).enabled = false;
            ((Behaviour) this.KOWObj.RewardText).enabled = true;
          }
          if ((Object) this.KOWObj.InfoText != (Object) null && ((Behaviour) this.KOWObj.InfoText).enabled)
          {
            ((Behaviour) this.KOWObj.InfoText).enabled = false;
            ((Behaviour) this.KOWObj.InfoText).enabled = true;
          }
          if ((Object) this.KOWObj.BtnText1 != (Object) null && ((Behaviour) this.KOWObj.BtnText1).enabled)
          {
            ((Behaviour) this.KOWObj.BtnText1).enabled = false;
            ((Behaviour) this.KOWObj.BtnText1).enabled = true;
          }
          if ((Object) this.KOWObj.BtnText2 != (Object) null && ((Behaviour) this.KOWObj.BtnText2).enabled)
          {
            ((Behaviour) this.KOWObj.BtnText2).enabled = false;
            ((Behaviour) this.KOWObj.BtnText2).enabled = true;
          }
          if ((Object) this.KOWObj.RankText != (Object) null && ((Behaviour) this.KOWObj.RankText).enabled)
          {
            ((Behaviour) this.KOWObj.RankText).enabled = false;
            ((Behaviour) this.KOWObj.RankText).enabled = true;
          }
          if ((Object) this.KOWObj.AllyRankText != (Object) null && ((Behaviour) this.KOWObj.AllyRankText).enabled)
          {
            ((Behaviour) this.KOWObj.AllyRankText).enabled = false;
            ((Behaviour) this.KOWObj.AllyRankText).enabled = true;
          }
        }
        if (this.SumObj != null)
        {
          if ((Object) this.SumObj.NameText != (Object) null && ((Behaviour) this.SumObj.NameText).enabled)
          {
            ((Behaviour) this.SumObj.NameText).enabled = false;
            ((Behaviour) this.SumObj.NameText).enabled = true;
          }
          if ((Object) this.SumObj.RewardText != (Object) null && ((Behaviour) this.SumObj.RewardText).enabled)
          {
            ((Behaviour) this.SumObj.RewardText).enabled = false;
            ((Behaviour) this.SumObj.RewardText).enabled = true;
          }
          if ((Object) this.SumObj.InfoText != (Object) null && ((Behaviour) this.SumObj.InfoText).enabled)
          {
            ((Behaviour) this.SumObj.InfoText).enabled = false;
            ((Behaviour) this.SumObj.InfoText).enabled = true;
          }
          if ((Object) this.SumObj.BtnText1 != (Object) null && ((Behaviour) this.SumObj.BtnText1).enabled)
          {
            ((Behaviour) this.SumObj.BtnText1).enabled = false;
            ((Behaviour) this.SumObj.BtnText1).enabled = true;
          }
          if ((Object) this.SumObj.BtnText2 != (Object) null && ((Behaviour) this.SumObj.BtnText2).enabled)
          {
            ((Behaviour) this.SumObj.BtnText2).enabled = false;
            ((Behaviour) this.SumObj.BtnText2).enabled = true;
          }
          if ((Object) this.SumObj.RankText != (Object) null && ((Behaviour) this.SumObj.RankText).enabled)
          {
            ((Behaviour) this.SumObj.RankText).enabled = false;
            ((Behaviour) this.SumObj.RankText).enabled = true;
          }
          if ((Object) this.SumObj.AllyRankText != (Object) null && ((Behaviour) this.SumObj.AllyRankText).enabled)
          {
            ((Behaviour) this.SumObj.AllyRankText).enabled = false;
            ((Behaviour) this.SumObj.AllyRankText).enabled = true;
          }
        }
        if (this.NWObj != null)
        {
          if ((Object) this.NWObj.NameText != (Object) null && ((Behaviour) this.NWObj.NameText).enabled)
          {
            ((Behaviour) this.NWObj.NameText).enabled = false;
            ((Behaviour) this.NWObj.NameText).enabled = true;
          }
          if ((Object) this.NWObj.RewardText != (Object) null && ((Behaviour) this.NWObj.RewardText).enabled)
          {
            ((Behaviour) this.NWObj.RewardText).enabled = false;
            ((Behaviour) this.NWObj.RewardText).enabled = true;
          }
          if ((Object) this.NWObj.InfoText != (Object) null && ((Behaviour) this.NWObj.InfoText).enabled)
          {
            ((Behaviour) this.NWObj.InfoText).enabled = false;
            ((Behaviour) this.NWObj.InfoText).enabled = true;
          }
          if ((Object) this.NWObj.BtnText1 != (Object) null && ((Behaviour) this.NWObj.BtnText1).enabled)
          {
            ((Behaviour) this.NWObj.BtnText1).enabled = false;
            ((Behaviour) this.NWObj.BtnText1).enabled = true;
          }
          if ((Object) this.NWObj.BtnText2 != (Object) null && ((Behaviour) this.NWObj.BtnText2).enabled)
          {
            ((Behaviour) this.NWObj.BtnText2).enabled = false;
            ((Behaviour) this.NWObj.BtnText2).enabled = true;
          }
          if ((Object) this.NWObj.RankText != (Object) null && ((Behaviour) this.NWObj.RankText).enabled)
          {
            ((Behaviour) this.NWObj.RankText).enabled = false;
            ((Behaviour) this.NWObj.RankText).enabled = true;
          }
          if ((Object) this.NWObj.FlashText != (Object) null && ((Behaviour) this.NWObj.FlashText).enabled)
          {
            ((Behaviour) this.NWObj.FlashText).enabled = false;
            ((Behaviour) this.NWObj.FlashText).enabled = true;
          }
          if ((Object) this.NWObj.AllyRankText != (Object) null && ((Behaviour) this.NWObj.AllyRankText).enabled)
          {
            ((Behaviour) this.NWObj.AllyRankText).enabled = false;
            ((Behaviour) this.NWObj.AllyRankText).enabled = true;
          }
        }
        if (this.AWObj == null)
          break;
        if ((Object) this.AWObj.NameText != (Object) null && ((Behaviour) this.AWObj.NameText).enabled)
        {
          ((Behaviour) this.AWObj.NameText).enabled = false;
          ((Behaviour) this.AWObj.NameText).enabled = true;
        }
        if ((Object) this.AWObj.RewardText != (Object) null && ((Behaviour) this.AWObj.RewardText).enabled)
        {
          ((Behaviour) this.AWObj.RewardText).enabled = false;
          ((Behaviour) this.AWObj.RewardText).enabled = true;
        }
        if ((Object) this.AWObj.InfoText != (Object) null && ((Behaviour) this.AWObj.InfoText).enabled)
        {
          ((Behaviour) this.AWObj.InfoText).enabled = false;
          ((Behaviour) this.AWObj.InfoText).enabled = true;
        }
        if ((Object) this.AWObj.BtnText1 != (Object) null && ((Behaviour) this.AWObj.BtnText1).enabled)
        {
          ((Behaviour) this.AWObj.BtnText1).enabled = false;
          ((Behaviour) this.AWObj.BtnText1).enabled = true;
        }
        if ((Object) this.AWObj.BtnText2 != (Object) null && ((Behaviour) this.AWObj.BtnText2).enabled)
        {
          ((Behaviour) this.AWObj.BtnText2).enabled = false;
          ((Behaviour) this.AWObj.BtnText2).enabled = true;
        }
        if ((Object) this.AWObj.RankText != (Object) null && ((Behaviour) this.AWObj.RankText).enabled)
        {
          ((Behaviour) this.AWObj.RankText).enabled = false;
          ((Behaviour) this.AWObj.RankText).enabled = true;
        }
        if ((Object) this.AWObj.FlashText != (Object) null && ((Behaviour) this.AWObj.FlashText).enabled)
        {
          ((Behaviour) this.AWObj.FlashText).enabled = false;
          ((Behaviour) this.AWObj.FlashText).enabled = true;
        }
        if (!((Object) this.AWObj.AllyRankText != (Object) null) || !((Behaviour) this.AWObj.AllyRankText).enabled)
          break;
        ((Behaviour) this.AWObj.AllyRankText).enabled = false;
        ((Behaviour) this.AWObj.AllyRankText).enabled = true;
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (sender.m_BtnID2 == 1)
      {
        if (!(bool) (Object) menu)
          return;
        menu.CloseMenu();
      }
      else
      {
        if (sender.m_BtnID2 != 2 || !(bool) (Object) menu)
          return;
        menu.OpenMenu(EGUIWindow.UI_Activity4, 1, 100);
      }
    }
    else
    {
      if (sender.m_BtnID1 != 2)
        return;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (sender.m_BtnID2 == 1)
        this.AM.Send_ACTIVITY_EVENT_DETAIL((byte) sender.m_BtnID3);
      else if (sender.m_BtnID2 == 2)
      {
        if (!(bool) (Object) menu)
          return;
        menu.OpenMenu(EGUIWindow.UI_Activity3, (int) byte.MaxValue, sender.m_BtnID3);
        this.AM.SaveActivity(1, sender.m_BtnID3, false);
      }
      else if (sender.m_BtnID2 == 3)
      {
        if (!(bool) (Object) menu)
          return;
        menu.OpenMenu(EGUIWindow.UI_Activity3, 254, sender.m_BtnID3);
        this.AM.SaveActivity(0, sender.m_BtnID3, false);
      }
      else if (sender.m_BtnID2 == -1)
      {
        this.AM.ClearNewsNo();
        IGGSDKPlugin.GoToNews(GameConstants.GlobalEditionTWNewsUrl, GameConstants.GlobalEditionNewsUrlKey);
      }
      else if (sender.m_BtnID2 == 11)
        this.AM.Send_ACTIVITY_KEVENT_DETAIL((byte) sender.m_BtnID3);
      else if (sender.m_BtnID2 == 12)
      {
        if (this.AM.bForceAMActivity)
        {
          this.AM.SavebForceAMActivity(false);
          this.AM.CheckAMShowHint();
        }
        menu.OpenMenu(EGUIWindow.UI_Alliance_Mobilization);
      }
      else if (sender.m_BtnID2 == 13)
      {
        if (this.AM.KOWData.EventState == EActivityState.EAS_ReplayRanking && !this.AM.KOWData.bAskDetailData)
          this.AM.Send_KINGOFTHEWORLD_KINGINFO();
        else
          menu.OpenMenu(EGUIWindow.UI_Activity2, 207, bCameraMode: true);
      }
      else if (sender.m_BtnID2 == 14)
      {
        if (!(bool) (Object) menu)
          return;
        menu.OpenMenu(EGUIWindow.UI_Activity2, 208);
      }
      else if (sender.m_BtnID2 == 15)
      {
        if (this.AM.bForceNWActivity)
        {
          this.AM.SavebForceNWActivity(false);
          this.AM.CheckNWShowHint();
        }
        this.AM.Send_FEDERAL_ORDERLIST();
      }
      else
      {
        if (sender.m_BtnID2 != 16)
          return;
        this.AM.CheckAWActivityFlash();
        this.AM.OpenAllianceWarDetail();
      }
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

  public float GetFillAmount()
  {
    MobilizationManager instance = MobilizationManager.Instance;
    if (instance.CompleteScore == 0U)
      return 0.0f;
    if (instance.AMCompleteDegree == (byte) 0)
      return (float) instance.AMScore / (float) instance.CompleteScore;
    MobilizationDegreeData recordByIndex = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex((int) instance.AMCompleteDegree - 1);
    return (int) instance.AMScore == (int) recordByIndex.MissionDegreeScore ? 0.0f : (float) (instance.AMScore - recordByIndex.MissionDegreeScore) / (float) (instance.CompleteScore - recordByIndex.MissionDegreeScore);
  }
}
