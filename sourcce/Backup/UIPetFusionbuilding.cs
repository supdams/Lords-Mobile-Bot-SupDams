// Decompiled with JetBrains decompiler
// Type: UIPetFusionbuilding
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIPetFusionbuilding : 
  GUIWindow,
  IBuildingWindowType,
  IUIButtonClickHandler,
  IUTimeBarOnTimer
{
  private DataManager DM;
  private GUIManager GUIM;
  private PetManager PM;
  private Transform GameT;
  private Transform mFusionbuildingT;
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  public BuildingWindow baseBuild;
  public UITimeBar timeBar;
  private Door door;
  private UIButton btn_PetContract;
  private UIButton btn_Petskill;
  private Image Img_Lock;
  private Image Img_Line;
  private UIText text_Info;
  private UIText text_PetContract;
  private UIText text_Petskill;
  private CString Cstr;
  private int B_ID;
  private bool bFusion;
  private FusionData tmpFD;
  private Equip tmpEquip;
  private PetTbl tmpPetD;
  private string AssetName;

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
    {
      this.mFusionbuildingT.gameObject.SetActive(true);
      ((Component) this.Img_Line).gameObject.SetActive(true);
    }
    else
    {
      this.mFusionbuildingT.gameObject.SetActive(false);
      ((Component) this.Img_Line).gameObject.SetActive(false);
    }
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.PM = PetManager.Instance;
    this.GameT = this.gameObject.transform;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.AssetName = "BuildingWindow";
    Material material = this.GUIM.AddSpriteAsset(this.AssetName);
    this.Cstr = StringManager.Instance.SpawnString();
    this.B_ID = arg1;
    if (this.PM.bCheckLockFusionSkill)
    {
      for (int index1 = 0; index1 < this.PM.sortPetData.Count; ++index1)
      {
        this.tmpPetD = this.PM.PetTable.GetRecordByKey(this.PM.GetPetData((int) this.PM.sortPetData[index1]).ID);
        ushort num = 0;
        for (int index2 = 0; index2 < 4; ++index2)
        {
          if (this.tmpPetD.PetSkill[index2] > (ushort) 0)
            num = this.PM.PetSkillTable.GetRecordByKey(this.tmpPetD.PetSkill[index2]).Diamond;
          if (num > (ushort) 0)
          {
            this.PM.bCheckLockFusionSkill = false;
            break;
          }
        }
        if (!this.PM.bCheckLockFusionSkill)
          break;
      }
    }
    this.mFusionbuildingT = this.GameT.GetChild(0);
    this.timeBar = this.mFusionbuildingT.GetChild(0).GetComponent<UITimeBar>();
    RectTransform component = this.mFusionbuildingT.GetChild(0).GetComponent<RectTransform>();
    component.anchoredPosition = new Vector2(-40f, component.anchoredPosition.y);
    long num1 = this.DM.SoldierBeginTime + (long) this.DM.SoldierNeedTime - this.DM.ServerTime;
    this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
    this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
    this.timeBar.m_Handler = (IUTimeBarOnTimer) this;
    this.timeBar.m_TimeBarID = 1;
    this.timeBar.gameObject.SetActive(false);
    this.text_Info = this.mFusionbuildingT.GetChild(1).GetComponent<UIText>();
    this.text_Info.font = this.TTFont;
    this.text_Info.text = this.DM.mStringTable.GetStringByID(14652U);
    if (this.DM.queueBarData[34].bActive)
    {
      long startTime = this.DM.queueBarData[34].StartTime;
      long target = startTime + (long) this.DM.queueBarData[34].TotalTime;
      this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(PetManager.Instance.ItemCraftID);
      this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
      CString cstring = StringManager.Instance.StaticString1024();
      StringManager.IntToStr(cstring, (long) PetManager.Instance.ItemCraftCount, bNumber: true);
      this.Cstr.ClearString();
      if (this.tmpFD.Fusion_Kind < (byte) 1)
      {
        this.Cstr.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID).EquipName));
      }
      else
      {
        CString tmpS = StringManager.Instance.StaticString1024();
        tmpS.ClearString();
        tmpS.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID).EquipName));
        tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(14669U));
        tmpS.AppendFormat("{0}{1}");
        this.Cstr.StringToFormat(tmpS);
      }
      this.Cstr.StringToFormat(cstring);
      this.Cstr.AppendFormat(this.DM.mStringTable.GetStringByID(4048U));
      this.GUIM.SetTimerBar(this.timeBar, startTime, target, 0L, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(14660U), this.Cstr.ToString());
      this.timeBar.gameObject.SetActive(true);
      ((Component) this.text_Info).gameObject.SetActive(false);
      this.bFusion = true;
    }
    Transform child1 = this.GameT.GetChild(1);
    this.Img_Line = child1.GetComponent<Image>();
    this.Img_Line.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_divider_02");
    ((MaskableGraphic) this.Img_Line).material = material;
    Transform child2 = child1.GetChild(0);
    this.btn_PetContract = child2.GetComponent<UIButton>();
    this.btn_PetContract.m_Handler = (IUIButtonClickHandler) this;
    this.btn_PetContract.m_BtnID1 = 0;
    this.btn_PetContract.m_EffectType = e_EffectType.e_Scale;
    this.btn_PetContract.transition = (Selectable.Transition) 0;
    this.text_PetContract = child2.GetChild(0).GetComponent<UIText>();
    this.text_PetContract.font = this.TTFont;
    this.text_PetContract.text = this.DM.mStringTable.GetStringByID(14653U);
    Transform child3 = child1.GetChild(1);
    this.btn_Petskill = child3.GetComponent<UIButton>();
    this.btn_Petskill.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Petskill.m_BtnID1 = 1;
    this.btn_Petskill.m_EffectType = e_EffectType.e_Scale;
    this.btn_Petskill.transition = (Selectable.Transition) 0;
    this.Img_Lock = child3.GetChild(0).GetComponent<Image>();
    this.Img_Lock.sprite = this.door.LoadSprite("UI_main_lock");
    ((MaskableGraphic) this.Img_Lock).material = this.door.LoadMaterial();
    this.Img_Lock.SetNativeSize();
    if (this.PM.bCheckLockFusionSkill)
    {
      ((Component) this.Img_Lock).gameObject.SetActive(true);
      ((Graphic) this.btn_Petskill.image).color = Color.gray;
    }
    this.text_Petskill = child3.GetChild(1).GetComponent<UIText>();
    this.text_Petskill.font = this.TTFont;
    this.text_Petskill.text = this.DM.mStringTable.GetStringByID(14654U);
    this.baseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    this.baseBuild.InitBuildingWindow((byte) 22, (ushort) this.B_ID, (byte) 2, this.GUIM.BuildingData.AllBuildsData[this.B_ID].Level);
    this.baseBuild.baseTransform.SetAsFirstSibling();
    if (!NewbieManager.CheckNewbie((object) this))
      NewbieManager.CheckTeach(ETeachKind.SPAWN_SOLDIERS, (object) this);
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 4);
    NewbieManager.CheckPetFusionBuilding();
  }

  public void OnButtonClick(UIButton sender)
  {
    switch ((GUIPetFusionbuilding) sender.m_BtnID1)
    {
      case GUIPetFusionbuilding.btn_PetContract:
        this.door.OpenMenu(EGUIWindow.UI_PetFusion);
        break;
      case GUIPetFusionbuilding.btn_Petskill:
        if (this.PM.bCheckLockFusionSkill)
        {
          this.GUIM.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14655U), (ushort) byte.MaxValue);
          break;
        }
        this.door.OpenMenu(EGUIWindow.UI_PetFusion, 1);
        break;
    }
  }

  public override void OnClose()
  {
    if (this.AssetName != null)
      this.GUIM.RemoveSpriteAsset(this.AssetName);
    if ((Object) this.baseBuild != (Object) null)
      this.baseBuild.DestroyBuildingWindow();
    if ((Object) this.timeBar != (Object) null)
      this.GUIM.RemoverTimeBaarToList(this.timeBar);
    if (this.Cstr == null)
      return;
    StringManager.Instance.DeSpawnString(this.Cstr);
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Info != (Object) null && ((Behaviour) this.text_Info).enabled)
    {
      ((Behaviour) this.text_Info).enabled = false;
      ((Behaviour) this.text_Info).enabled = true;
    }
    if ((Object) this.text_PetContract != (Object) null && ((Behaviour) this.text_PetContract).enabled)
    {
      ((Behaviour) this.text_PetContract).enabled = false;
      ((Behaviour) this.text_PetContract).enabled = true;
    }
    if (!((Object) this.text_Petskill != (Object) null) || !((Behaviour) this.text_Petskill).enabled)
      return;
    ((Behaviour) this.text_Petskill).enabled = false;
    ((Behaviour) this.text_Petskill).enabled = true;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if (this.DM.queueBarData[34].bActive)
        {
          long startTime = this.DM.queueBarData[34].StartTime;
          long target = startTime + (long) this.DM.queueBarData[34].TotalTime;
          long notifyTime = 0;
          this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(PetManager.Instance.ItemCraftID);
          this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
          CString cstring = StringManager.Instance.StaticString1024();
          StringManager.IntToStr(cstring, (long) PetManager.Instance.ItemCraftCount, bNumber: true);
          this.Cstr.ClearString();
          if (this.tmpFD.Fusion_Kind < (byte) 1)
          {
            this.Cstr.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID).EquipName));
          }
          else
          {
            CString tmpS = StringManager.Instance.StaticString1024();
            tmpS.ClearString();
            tmpS.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID).EquipName));
            tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(14669U));
            tmpS.AppendFormat("{0}{1}");
            this.Cstr.StringToFormat(tmpS);
          }
          this.Cstr.StringToFormat(cstring);
          this.Cstr.AppendFormat(this.DM.mStringTable.GetStringByID(4048U));
          this.GUIM.SetTimerBar(this.timeBar, startTime, target, notifyTime, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(14660U), this.Cstr.ToString());
          this.timeBar.gameObject.SetActive(true);
          ((Component) this.text_Info).gameObject.SetActive(false);
          this.bFusion = true;
          break;
        }
        this.GUIM.RemoverTimeBaarToList(this.timeBar);
        this.timeBar.gameObject.SetActive(false);
        ((Component) this.text_Info).gameObject.SetActive(true);
        this.bFusion = false;
        break;
      case NetworkNews.Refresh_BuildBase:
        if (meg[1] == (byte) 1)
        {
          this.door.CloseMenu(true);
          break;
        }
        if (!((Object) this.baseBuild != (Object) null))
          break;
        this.baseBuild.MyUpdate(meg[1]);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        if ((Object) this.baseBuild != (Object) null)
          this.baseBuild.Refresh_FontTexture();
        if (!((Object) this.timeBar != (Object) null) || !this.timeBar.enabled)
          break;
        this.timeBar.Refresh_FontTexture();
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if ((Object) this.baseBuild == (Object) null || arg1 != 1)
      return;
    if (this.DM.queueBarData[34].bActive)
    {
      long startTime = this.DM.queueBarData[34].StartTime;
      long target = startTime + (long) this.DM.queueBarData[34].TotalTime;
      long notifyTime = 0;
      this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(PetManager.Instance.ItemCraftID);
      this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
      CString cstring = StringManager.Instance.StaticString1024();
      StringManager.IntToStr(cstring, (long) PetManager.Instance.ItemCraftCount, bNumber: true);
      this.Cstr.ClearString();
      if (this.tmpFD.Fusion_Kind < (byte) 1)
      {
        this.Cstr.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID).EquipName));
      }
      else
      {
        CString tmpS = StringManager.Instance.StaticString1024();
        tmpS.ClearString();
        tmpS.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID).EquipName));
        tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(14669U));
        tmpS.AppendFormat("{0}{1}");
        this.Cstr.StringToFormat(tmpS);
      }
      this.Cstr.StringToFormat(cstring);
      this.Cstr.AppendFormat(this.DM.mStringTable.GetStringByID(4048U));
      this.GUIM.SetTimerBar(this.timeBar, startTime, target, notifyTime, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(14660U), this.Cstr.ToString());
      this.timeBar.gameObject.SetActive(true);
      ((Component) this.text_Info).gameObject.SetActive(false);
      this.bFusion = true;
    }
    else
    {
      this.GUIM.RemoverTimeBaarToList(this.timeBar);
      this.timeBar.gameObject.SetActive(false);
      ((Component) this.text_Info).gameObject.SetActive(true);
      this.bFusion = false;
    }
  }

  public void OnTimer(UITimeBar sender)
  {
    this.timeBar.gameObject.SetActive(false);
    ((Component) this.text_Info).gameObject.SetActive(true);
    this.bFusion = false;
  }

  public void OnNotify(UITimeBar sender)
  {
  }

  public void Onfunc(UITimeBar sender)
  {
    if (sender.m_TimerSpriteType != eTimerSpriteType.Speed)
      return;
    this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 34);
  }

  public void OnCancel(UITimeBar sender)
  {
    this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(14662U), this.DM.mStringTable.GetStringByID(14663U), 1, YesText: this.DM.mStringTable.GetStringByID(3925U), NoText: this.DM.mStringTable.GetStringByID(3926U));
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || arg1 != 1 || !GUIManager.Instance.ShowUILock(EUILock.PetFusion))
      return;
    PetManager.Instance.SendItemCraft_Cancel();
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
