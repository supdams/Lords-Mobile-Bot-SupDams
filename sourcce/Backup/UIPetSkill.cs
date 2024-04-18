// Decompiled with JetBrains decompiler
// Type: UIPetSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIPetSkill : 
  PetBuff,
  UILoadImageHander,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private GameObject go;
  private GameObject Duke;
  private RectTransform Hero_PosRT;
  private Transform Tmp;
  private Transform Hero_Model;
  private Transform Hero_Pos;
  private Transform HintButt;
  private ScrollPanel_Horizontal m_scroll;
  private PetBuff.SkillPanelItem[] m_panel = new PetBuff.SkillPanelItem[10];
  private Animation tmpAN;
  private double PauseTime;
  private bool bDisabled;
  protected bool bRequest;
  protected bool bReturn;
  protected bool bExit;
  protected bool bEnd;
  protected Door door;
  protected UnityEngine.UI.Text[] m_label = new UnityEngine.UI.Text[28];
  protected UnityEngine.UI.Text m_limit;
  protected UnityEngine.UI.Text m_title;
  protected UnityEngine.UI.Text m_error;
  protected UnityEngine.UI.Text m_filter;
  protected UnityEngine.UI.Text m_search;
  protected UnityEngine.UI.Text m_button;
  protected UnityEngine.UI.Text m_content;
  protected UnityEngine.UI.Text[] m_default = new UnityEngine.UI.Text[3];
  protected UnityEngine.UI.Text m_descript;
  protected Image m_Dukedom;
  protected Image m_Defeater;
  protected Image m_MyEmperor;
  protected Image m_CrownBack;
  protected Image m_WorldWarZ;
  protected Image m_WorldPiss;
  protected UIButton m_Active;
  protected UISpritesArray USArray;
  protected UIButtonHint m_UIHint;
  protected Transform Transformer;
  protected static int Positioning;
  protected static float Scrolling;
  protected RectTransform SkillRect;
  public GUIManager GM = GUIManager.Instance;
  public PetManager PM = PetManager.Instance;
  public DataManager DM = DataManager.Instance;
  public NetworkManager NM = NetworkManager.Instance;
  public Font Font = GUIManager.Instance.GetTTFFont();
  public StringBuilder Path = new StringBuilder();
  private List<float> ItemsHeight = new List<float>();
  private CString[] m_Str = new CString[10];
  private CString[] m_Buffer = new CString[10];
  public static POINT_KIND nowKind;
  public static int nowMapPoint;
  private static ushort nowSkillId;
  private static ushort nowPetId;
  private CString SkillInfo;
  private int currentBtnID;
  private int nowCasting;
  private Effect effect;
  private ushort head;
  private uint time;

  public override void OnOpen(int arg1, int arg2)
  {
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      ((RectTransform) this.transform).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.transform).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
    DataManager.msgBuffer[0] = (byte) 96;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    UIPetSkill.nowKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) arg1);
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.transform.GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.transform.GetChild(4).GetChild(9).GetChild(2).GetChild(1).GetComponent<UnityEngine.UI.Text>().font = this.Font;
    this.transform.GetChild(1).GetChild(7).GetChild(1).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(1).GetChild(7).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(1).GetChild(7).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.transform.GetChild(4).GetChild(8).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = this.Font;
    this.transform.GetChild(4).GetChild(9).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = this.Font;
    this.transform.GetChild(4).GetChild(9).GetChild(1).GetComponent<UnityEngine.UI.Text>().font = this.Font;
    this.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = this.Font;
    this.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = this.Font;
    this.m_UIHint = this.transform.GetChild(1).GetChild(26).GetChild(6).gameObject.AddComponent<UIButtonHint>();
    this.m_UIHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.m_UIHint.m_Handler = (MonoBehaviour) this;
    this.transform.GetChild(1).GetChild(26).GetChild(5).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(1).GetChild(26).GetChild(5).GetComponent<UIButton>().m_BtnID1 = 1;
    this.m_label[1] = this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_label[1].font = this.Font;
    this.m_label[1].text = this.DM.mStringTable.GetStringByID(94U);
    this.m_label[2] = this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.m_label[2].font = this.Font;
    this.m_label[2].text = this.DM.mStringTable.GetStringByID(94U);
    this.m_label[3] = this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(2).GetComponent<UnityEngine.UI.Text>();
    this.m_label[3].text = !GUIManager.Instance.IsArabic ? "x1" : "1x";
    this.m_label[3].font = this.Font;
    this.m_label[4] = this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(3).GetComponent<UnityEngine.UI.Text>();
    this.m_label[4].font = this.Font;
    this.m_label[4].text = this.DM.mStringTable.GetStringByID(94U);
    this.m_label[5] = this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(4).GetComponent<UnityEngine.UI.Text>();
    this.m_label[5].text = !GUIManager.Instance.IsArabic ? "x1" : "1x";
    this.m_label[5].font = this.Font;
    this.m_Active = this.transform.GetChild(4).GetChild(9).GetChild(2).GetComponent<UIButton>();
    this.m_Active.m_Handler = (IUIButtonClickHandler) this;
    this.m_label[0] = this.transform.GetChild(1).GetChild(8).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.m_label[0].font = this.Font;
    this.m_label[10] = this.transform.GetChild(1).GetChild(26).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_label[10].font = this.Font;
    this.m_label[11] = this.transform.GetChild(1).GetChild(26).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.m_label[11].font = this.Font;
    this.m_label[12] = this.transform.GetChild(1).GetChild(26).GetChild(4).GetComponent<UnityEngine.UI.Text>();
    this.m_label[12].font = this.Font;
    this.m_Dukedom = this.transform.GetChild(1).GetChild(8).GetChild(0).gameObject.GetComponent<Image>();
    this.GM.InitianHeroItemImg(this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(0).GetChild(0).transform, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    for (int index = 0; index < this.m_Str.Length; ++index)
    {
      this.m_Str[index] = StringManager.Instance.SpawnString(300);
      this.m_Buffer[index] = StringManager.Instance.SpawnString(300);
    }
    this.SkillInfo = StringManager.Instance.SpawnString(1024);
    if (GUIManager.Instance.IsArabic)
      this.transform.GetChild(1).GetChild(7).GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
    this.m_scroll = this.transform.GetChild(1).GetChild(9).GetComponent<ScrollPanel_Horizontal>();
    this.m_scroll.IntiScrollPanel(298f, 6f, 0.0f, this.ItemsHeight, 10, (IUpDateScrollPanel) this);
    this.m_scroll.gameObject.SetActive(true);
    this.SkillRect = this.m_scroll.transform.GetChild(0).GetComponent<RectTransform>();
    UIPetSkill.nowMapPoint = arg1;
    this.nowCasting = arg2;
    this.Refresh();
  }

  private void RequestFatigue()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PETSKILL_FATIGUE;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (Object) menu)
    {
      img.sprite = menu.LoadSprite(ImageName);
      ((MaskableGraphic) img).material = menu.LoadMaterial();
    }
    img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
    ((MaskableGraphic) img).material = GUIManager.Instance.GetFrameMaterial();
  }

  private void RefreshSkill()
  {
    PetBuff.PetSkills.Clear();
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
          if (recordByKey1.PetSkill[(int) slot] > (ushort) 0 && petData.SkillLv != null && (int) slot < petData.SkillLv.Length && petData.SkillLv[(int) slot] > (byte) 0)
          {
            PetSkillTbl recordByKey2 = PetManager.Instance.PetSkillTable.GetRecordByKey(recordByKey1.PetSkill[(int) slot]);
            if (recordByKey2.Type > (byte) 0 && recordByKey2.Subject == (byte) 1 && recordByKey2.Class >= (byte) 1 && (int) recordByKey2.Class <= PetBuff.PetSkillList.Length)
              PetBuff.PetSkillList[(int) recordByKey2.Class - 1].Add(new PetBuff.PetSkillData((uint) recordByKey1.PetSkill[(int) slot], slot, recordByKey2.Subject, petData.ID));
          }
        }
      }
    }
  }

  private void Refresh(int arg1 = 0)
  {
    if ((bool) (Object) this.door && !(bool) (Object) this.m_Dukedom.sprite && UIPetSkill.nowMapPoint < DataManager.MapDataController.LayoutMapInfo.Length)
    {
      MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[UIPetSkill.nowMapPoint];
      if ((int) mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
      {
        bool flag = DataManager.MapDataController.IsEnemy(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kingdomID);
        this.door.TileMapController.getTileMapSprite(ref this.m_Dukedom, DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) UIPetSkill.nowMapPoint), (int) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].level, DataManager.MapDataController.OtherKingdomData.kingdomPeriod != KINGDOM_PERIOD.KP_KVK || !flag ? DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].cityOutward : CITY_OUTWARD.CO_EMEMY);
        ((MaskableGraphic) this.m_Dukedom).material = Object.Instantiate((Object) ((MaskableGraphic) this.door.TileMapController.TileSprites.m_Image).material) as Material;
        ((MaskableGraphic) this.m_Dukedom).material.renderQueue = 3000;
        if (flag)
        {
          if (DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag != null && DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag.Length > 0)
            GameConstants.FormatRoleName(this.m_Str[0], DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName, DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag, bCheckedNickname: (byte) 0, KingdomID: DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kingdomID);
          else
            GameConstants.FormatRoleName(this.m_Str[0], DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName, bCheckedNickname: (byte) 0, KingdomID: DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kingdomID);
        }
        else if (DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag != null && DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag.Length > 0)
        {
          GameConstants.FormatRoleName(this.m_Str[0], DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName, DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
        }
        else
        {
          StringManager.Instance.StringToFormat(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName);
          this.m_Str[0].AppendFormat("{0}");
        }
        this.m_label[0].text = this.m_Str[0].ToString();
        ((Graphic) this.m_label[0]).SetAllDirty();
        this.m_label[0].cachedTextGenerator.Invalidate();
        this.m_Dukedom.SetNativeSize();
        ((Behaviour) this.m_Dukedom).enabled = true;
      }
    }
    this.m_Active.m_BtnID2 = 1;
    this.ItemsHeight.Clear();
    PetBuff.PetSkills.Clear();
    this.SetSkill();
    int cls = 0;
    int num = 0;
    for (; cls < PetBuff.PetSkillList.Length; ++cls)
    {
      for (int index = 0; index < PetBuff.PetSkillList[cls].Count; ++index)
      {
        if ((int) PetBuff.PetSkillList[cls][index].Subject == this.nowCasting)
        {
          PetBuff.PetSkills.Add(new PetBuff.PetSkill(PetBuff.PetSkillList[cls][index].Id, num++, (byte) cls, PetBuff.PetSkillList[cls][index].Slot, PetBuff.PetSkillList[cls][index].Pet));
          if ((int) PetBuff.PetSkillList[cls][index].Id == (int) UIPetSkill.nowSkillId)
            this.m_Active.m_BtnID2 = num;
          this.ItemsHeight.Add(90f);
        }
      }
    }
    this.m_scroll.AddNewDataHeight(this.ItemsHeight);
    if (this.m_Active.m_BtnID2 > 1)
      this.m_scroll.GoTo(UIPetSkill.Positioning, UIPetSkill.Scrolling);
    this.OnButtonClick(this.m_Active);
  }

  protected void SetStage()
  {
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (dataIdx < 0 || dataIdx >= PetBuff.PetSkills.Count || panelObjectIdx >= this.m_panel.Length)
      return;
    if (!this.m_panel[panelObjectIdx].Init)
    {
      this.m_panel[panelObjectIdx].Init = true;
      this.m_panel[panelObjectIdx].Item = item;
      item.transform.GetChild(9).GetChild(2).gameObject.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      if (UIPetSkill.nowSkillId != (ushort) 0)
        ;
    }
    this.m_panel[panelObjectIdx].ID = dataIdx;
    item.transform.GetChild(8).gameObject.SetActive(false);
    item.transform.GetChild(9).gameObject.SetActive(true);
    item.transform.GetChild(9).GetChild(2).gameObject.GetComponent<UIButton>().m_BtnID2 = dataIdx + 1;
    item.transform.GetChild(9).GetChild(2).GetChild(2).gameObject.SetActive(this.currentBtnID > 0 && this.currentBtnID <= PetBuff.PetSkills.Count && this.currentBtnID == dataIdx);
    this.SetPanelItem(panelObjectIdx, true);
    this.m_CrownBack = item.transform.GetChild(9).GetChild(2).gameObject.GetComponent<Image>();
    PetSkillTbl recordByKey = PetManager.Instance.PetSkillTable.GetRecordByKey((ushort) PetBuff.PetSkills[dataIdx].ID);
    CString SpriteName = StringManager.Instance.StaticString1024();
    SpriteName.IntToFormat((long) recordByKey.Icon, 5);
    SpriteName.AppendFormat("s{0}");
    this.m_Defeater = ((Component) this.m_CrownBack).transform.GetChild(0).GetComponent<Image>();
    this.m_Defeater.sprite = this.GM.LoadFrameSprite("sk");
    ((MaskableGraphic) this.m_Defeater).material = this.GM.GetFrameMaterial();
    this.m_CrownBack.sprite = this.GM.LoadSkillSprite(SpriteName);
    ((MaskableGraphic) this.m_CrownBack).material = this.GM.GetSkillMaterial();
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || !(bool) (Object) this.door)
      return;
    if (arg2 > 0)
    {
      this.UpdateUI(0, 0);
      if (GUIManager.Instance.BuildingData.GetBuildNumByID((ushort) 22) == (byte) 0)
        GUIManager.Instance.BuildingData.ManorGuild((ushort) 22);
      else
        this.door.OpenMenu(EGUIWindow.UI_PetFusion, 1, arg1);
    }
    else
      this.UpdateUI(11, 0);
  }

  private void Check()
  {
  }

  public void onUse(ushort PetId, ushort SkillId)
  {
    DataManager.MapDataController.UseMapWeapon(PetManager.Instance.PetTable.GetRecordByKey(PetId).HeroID, SkillId);
  }

  public void onSelect(ushort DamageId)
  {
    ushort zoneID;
    byte pointID;
    GameConstants.MapIDToPointCode(UIPetSkill.nowMapPoint, out zoneID, out pointID);
    DataManager.MapDataController.ShowDamageRange(zoneID, pointID, DamageId);
  }

  public static void onFinish()
  {
    if (UIPetSkill.nowPetId <= (ushort) 0 || UIPetSkill.nowSkillId <= (ushort) 0)
      return;
    ushort zoneID;
    byte pointID;
    GameConstants.MapIDToPointCode(UIPetSkill.nowMapPoint, out zoneID, out pointID);
    GUIManager.Instance.ShowUILock(EUILock.PetSkill);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PETSKILL_USE;
    messagePacket.AddSeqId();
    messagePacket.Add(zoneID);
    messagePacket.Add(pointID);
    messagePacket.Add(UIPetSkill.nowPetId);
    messagePacket.Add(UIPetSkill.nowSkillId);
    messagePacket.Send();
    UIPetSkill.nowMapPoint = (int) (UIPetSkill.nowPetId = (ushort) 0);
  }

  private static void SearchChange(string input)
  {
  }

  public static void RecvPetSkill(MessagePacket MP)
  {
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if ((bool) (Object) this.m_WorldWarZ)
      sender.ControlFadeOut.SetActive(false);
    if (GUIManager.Instance.m_Hint == null)
      return;
    GUIManager.Instance.m_Hint.Hide(true);
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    this.SkillInfo.ClearString();
    this.SkillInfo.Append(this.DM.mStringTable.GetStringByID(sender.Parm1 <= (ushort) 0 ? 12561U : 12560U));
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 250f, 16, this.SkillInfo, Vector2.zero);
  }

  public static void ResetID()
  {
  }

  public override void OnClose()
  {
    this.bEnd = true;
    DataManager.MapDataController.HideDamageRange();
    DataManager.msgBuffer[0] = (byte) 97;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    UIPetSkill.Scrolling = this.SkillRect.anchoredPosition.x;
    UIPetSkill.Positioning = this.m_scroll.GetTopIdx();
    Object.Destroy((Object) this.Duke);
    for (int index = 0; index < 10; ++index)
    {
      if (this.m_Str[index] != null)
        StringManager.Instance.DeSpawnString(this.m_Str[index]);
      if (this.m_Buffer[index] != null)
        StringManager.Instance.DeSpawnString(this.m_Buffer[index]);
    }
    if (this.SkillInfo != null)
      StringManager.Instance.DeSpawnString(this.SkillInfo);
    this.Destroy();
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!bOnSecond)
      return;
    this.UpdateUI(10, 0);
    if (this.m_panel == null)
      return;
    for (int idx = 0; idx < this.m_panel.Length; ++idx)
      this.SetPanelItem(idx);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 5:
        if (this.currentBtnID <= 0 || this.currentBtnID > PetBuff.PetSkills.Count)
          return;
        PetData petData1 = PetManager.Instance.FindPetData(PetBuff.PetSkills[this.currentBtnID - 1].Pet);
        PetSkillTbl recordByKey1 = PetManager.Instance.PetSkillTable.GetRecordByKey((ushort) PetBuff.PetSkills[this.currentBtnID - 1].ID);
        if (this.m_panel != null)
        {
          for (int index = 0; index < this.m_panel.Length; ++index)
          {
            if (this.m_panel[index].Init && (bool) (Object) this.m_panel[index].Item && this.m_panel[index].ID >= 0 && this.m_panel[index].ID < PetBuff.PetSkills.Count)
              this.m_panel[index].Item.transform.GetChild(9).GetChild(2).GetChild(2).gameObject.SetActive((int) PetBuff.PetSkills[this.currentBtnID - 1].ID == (int) PetBuff.PetSkills[this.m_panel[index].ID].ID);
          }
        }
        this.GM.ChangeHeroItemImg(this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(0).GetChild(0).transform, eHeroOrItem.Item, recordByKey1.Diamond, (byte) 0, (byte) 0);
        if (petData1 != null && petData1.SkillLv != null)
        {
          this.m_Str[1].ClearString();
          this.m_Str[1].IntToFormat((long) petData1.SkillLv[(int) PetBuff.PetSkills[this.currentBtnID - 1].Slot]);
          this.m_Str[1].StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey1.Name));
          this.m_Str[1].AppendFormat(this.DM.mStringTable.GetStringByID(268U));
          this.transform.GetChild(1).GetChild(26).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.m_Str[1].ToString();
          this.PM.FormatSkillContent(UIPetSkill.nowSkillId, petData1.SkillLv[(int) PetBuff.PetSkills[this.currentBtnID - 1].Slot], this.m_Str[2], (byte) 0);
        }
        else
          this.transform.GetChild(1).GetChild(26).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID((uint) recordByKey1.Name);
        ((Graphic) this.transform.GetChild(1).GetChild(26).GetChild(0).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
        this.transform.GetChild(1).GetChild(26).GetChild(0).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
        this.transform.GetChild(1).GetChild(26).GetChild(1).GetComponent<UnityEngine.UI.Text>().text = this.m_Str[2].ToString();
        ((Graphic) this.transform.GetChild(1).GetChild(26).GetChild(1).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
        this.transform.GetChild(1).GetChild(26).GetChild(1).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
        ushort curItemQuantity = this.DM.GetCurItemQuantity(recordByKey1.Diamond, (byte) 0);
        this.transform.GetChild(1).GetChild(26).GetChild(4).GetComponent<UnityEngine.UI.Text>().text = string.Format(this.DM.mStringTable.GetStringByID(12559U), (object) curItemQuantity);
        this.transform.GetChild(1).GetChild(26).GetChild(4).gameObject.SetActive(recordByKey1.Diamond > (ushort) 0);
        this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(0).gameObject.SetActive(recordByKey1.Diamond == (ushort) 0);
        this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).gameObject.SetActive(recordByKey1.Diamond > (ushort) 0);
        this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(2).gameObject.SetActive(curItemQuantity > (ushort) 0);
        this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(4).gameObject.SetActive(curItemQuantity == (ushort) 0);
        this.UpdateUI(10, 1);
        return;
      case 6:
        UIPetSkill.Scrolling = this.SkillRect.anchoredPosition.x;
        UIPetSkill.Positioning = this.m_scroll.GetTopIdx();
        this.Refresh();
        return;
      case 10:
        long sec = PetBuff.CheckSkillCD(UIPetSkill.nowSkillId);
        if (this.currentBtnID > 0 && this.currentBtnID <= PetBuff.PetSkills.Count && sec == 0L)
        {
          if (arg2 > 0 || !this.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(1).gameObject.activeSelf)
          {
            PetSkillCoolTbl recordByKey2 = this.PM.PetSkillCoolTable.GetRecordByKey(PetManager.Instance.PetSkillTable.GetRecordByKey(UIPetSkill.nowSkillId).CoolDown);
            PetData petData2 = PetManager.Instance.FindPetData(UIPetSkill.nowPetId);
            if (petData2 != null && petData2.SkillLv != null)
            {
              byte num = petData2.SkillLv[(int) PetBuff.PetSkills[this.currentBtnID - 1].Slot];
              if (num > (byte) 0 && (int) num <= recordByKey2.CoolBySkillLv.Length)
              {
                this.m_Str[3].ClearString();
                this.PM.FormatCoolTime(recordByKey2.CoolBySkillLv[(int) num - 1], this.m_Str[3], (byte) 0);
                this.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.m_Str[3].ToString();
                this.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
                ((Graphic) this.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
              }
            }
          }
        }
        else
        {
          this.m_Str[3].ClearString();
          GameConstants.GetTimeString(this.m_Str[3], (uint) sec, hideTimeIfDays: true, showZeroHour: false);
          this.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.m_Str[3].ToString();
          this.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
          ((Graphic) this.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
        }
        if (sec > 0L || this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(4).gameObject.activeSelf)
        {
          this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(1).gameObject.SetActive(false);
          this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(3).gameObject.SetActive(true);
        }
        else
        {
          this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(3).gameObject.SetActive(false);
          this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(1).gameObject.SetActive(true);
        }
        if (this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(0).GetChild(0).childCount > 1)
        {
          ((Graphic) this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>()).color = sec <= 0L ? Color.white : Color.gray;
          ((Graphic) this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>()).color = sec <= 0L ? Color.white : Color.gray;
        }
        ((Graphic) this.transform.GetChild(1).GetChild(26).GetChild(5).GetComponent<Image>()).color = sec <= 0L ? Color.white : Color.gray;
        ((Graphic) this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(1).GetComponent<UnityEngine.UI.Text>()).color = ((Graphic) this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(1).GetChild(sec <= 0L ? 0 : 1).GetComponent<UnityEngine.UI.Text>()).color;
        ((Graphic) this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(2).GetComponent<UnityEngine.UI.Text>()).color = ((Graphic) this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(2).GetChild(sec <= 0L ? 0 : 1).GetComponent<UnityEngine.UI.Text>()).color;
        ((Graphic) this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(3).GetComponent<UnityEngine.UI.Text>()).color = ((Graphic) this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(3).GetChild(sec <= 0L ? 0 : 1).GetComponent<UnityEngine.UI.Text>()).color;
        ((Graphic) this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(4).GetComponent<UnityEngine.UI.Text>()).color = ((Graphic) this.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(4).GetChild(sec <= 0L ? 0 : 1).GetComponent<UnityEngine.UI.Text>()).color;
        this.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(1).gameObject.SetActive(sec == 0L);
        this.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(0).gameObject.SetActive(sec > 0L);
        if (!(bool) (Object) this.m_UIHint)
          return;
        this.m_UIHint.Parm1 = sec <= 0L ? (ushort) 0 : (ushort) 1;
        return;
      case 11:
        if (UIPetSkill.nowSkillId <= (ushort) 0)
          return;
        PetSkillTbl recordByKey3 = PetManager.Instance.PetSkillTable.GetRecordByKey(UIPetSkill.nowSkillId);
        if (recordByKey3.Type != (byte) 1 || recordByKey3.Class < (byte) 1 || (int) recordByKey3.Class > PetBuff.PetSkillList.Length || this.PM.CoolDownData == null || this.PM.BuffInfoData == null)
          return;
        if (this.PM.CDFinder != null && this.PM.CDFinder.ContainsKey(UIPetSkill.nowSkillId))
        {
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12575U), (ushort) byte.MaxValue);
          return;
        }
        if (this.PM.m_PetMarchEventData.PetID > (ushort) 0 && (long) this.PM.m_PetMarchEventData.MarchEventTime.RequireTime + this.PM.m_PetMarchEventData.MarchEventTime.BeginTime >= this.DM.ServerTime)
        {
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12576U), (ushort) byte.MaxValue);
          return;
        }
        if (recordByKey3.Diamond > (ushort) 0 && this.DM.GetCurItemQuantity(recordByKey3.Diamond, (byte) 0) == (ushort) 0)
        {
          this.GM.MsgStr.ClearString();
          this.GM.MsgStr.StringToFormat(this.DM.mStringTable.GetStringByID(14654U));
          this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(1545U));
          this.GM.OpenMessageBox(this.GM.MsgStr.ToString(), this.DM.mStringTable.GetStringByID(12571U), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, (int) recordByKey3.Diamond, (int) UIPetSkill.nowSkillId, true);
          return;
        }
        if (this.PM.BuffImmune.BeginTime > 0L && arg2 > 0)
        {
          this.GM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4840U), this.DM.mStringTable.GetStringByID(12573U));
          return;
        }
        this.onUse(UIPetSkill.nowPetId, UIPetSkill.nowSkillId);
        this.UpdateUI(0, 0);
        return;
      case 12:
        if (arg2 != UIPetSkill.nowMapPoint)
          return;
        break;
    }
    GUIManager.Instance.CloseMenu(this.m_eWindow);
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
  }

  public override bool OnBackButtonClick() => false;

  public void Destroy()
  {
    if ((Object) this.go != (Object) null)
    {
      this.go.transform.SetParent(this.Hero_Pos.parent, false);
      Object.Destroy((Object) this.go);
    }
    if ((Object) this.Hero_Model != (Object) null)
      Object.Destroy((Object) this.Hero_Model);
    this.Hero_Model = (Transform) null;
    this.go = (GameObject) null;
  }

  public void OnDisable()
  {
  }

  private void OnEnable()
  {
  }

  protected void Update()
  {
    if (this.bExit)
    {
      if (!(bool) (Object) this.door)
        return;
      this.door.CloseMenu();
      GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
    }
    else if (this.bEnd || !this.bReturn)
      ;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh_Item:
        this.UpdateUI(5, 0);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        for (int index = 0; index < this.m_label.Length; ++index)
        {
          if ((Object) this.m_label[index] != (Object) null && ((Behaviour) this.m_label[index]).enabled)
          {
            ((Behaviour) this.m_label[index]).enabled = false;
            ((Behaviour) this.m_label[index]).enabled = true;
          }
        }
        break;
    }
  }

  protected void SetPanelItem(int idx, bool force = false)
  {
    if (this.m_panel == null || !this.m_panel[idx].Init || !(bool) (Object) this.m_panel[idx].Item || this.PM.CoolDownData == null || this.PM.BuffInfoData == null || !this.m_panel[idx].Item.activeInHierarchy && !force || this.m_panel[idx].ID < 0 || this.m_panel[idx].ID >= PetBuff.PetSkills.Count)
      return;
    this.m_Buffer[idx].ClearString();
    long sec = PetBuff.CheckSkillCD((ushort) PetBuff.PetSkills[this.m_panel[idx].ID].ID);
    GameConstants.GetTimeStringShort(this.m_Buffer[idx], (uint) sec);
    ((Graphic) this.m_panel[idx].Item.transform.GetChild(9).GetChild(2).GetComponent<Image>()).color = sec <= 0L ? Color.white : Color.gray;
    this.m_panel[idx].Item.transform.GetChild(9).GetChild(2).GetChild(1).GetComponent<UnityEngine.UI.Text>().text = sec <= 0L ? string.Empty : this.m_Buffer[idx].ToString();
    this.m_panel[idx].Item.transform.GetChild(9).GetChild(2).GetChild(1).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
    ((Graphic) this.m_panel[idx].Item.transform.GetChild(9).GetChild(2).GetChild(1).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 > 0)
      this.UpdateUI(11, 1);
    else if (sender.m_BtnID2 > 0 && sender.m_BtnID2 <= PetBuff.PetSkills.Count)
    {
      this.currentBtnID = sender.m_BtnID2;
      UIPetSkill.nowPetId = PetBuff.PetSkills[sender.m_BtnID2 - 1].Pet;
      UIPetSkill.nowSkillId = (ushort) PetBuff.PetSkills[sender.m_BtnID2 - 1].ID;
      PetSkillTbl recordByKey = PetManager.Instance.PetSkillTable.GetRecordByKey((ushort) PetBuff.PetSkills[sender.m_BtnID2 - 1].ID);
      this.onSelect(PetManager.Instance.MapDamageEffTable.GetRecordByKey(recordByKey.DamageRange).RangeTbID);
      this.m_CrownBack = this.transform.GetChild(1).GetChild(26).GetChild(3).gameObject.GetComponent<Image>();
      CString SpriteName = StringManager.Instance.StaticString1024();
      SpriteName.IntToFormat((long) recordByKey.Icon, 5);
      SpriteName.AppendFormat("s{0}");
      this.m_Defeater = ((Component) this.m_CrownBack).transform.GetChild(0).GetComponent<Image>();
      this.m_Defeater.sprite = this.GM.LoadFrameSprite("sk");
      ((MaskableGraphic) this.m_Defeater).material = this.GM.GetFrameMaterial();
      this.m_CrownBack.sprite = this.GM.LoadSkillSprite(SpriteName);
      ((MaskableGraphic) this.m_CrownBack).material = this.GM.GetSkillMaterial();
      this.UpdateUI(5, 0);
    }
    else if (sender.m_BtnID3 > 0)
    {
      this.SkillInfo.ClearString();
      this.SkillInfo.Append(this.DM.mStringTable.GetStringByID(12585U));
      this.SkillInfo.Append("\n");
      this.SkillInfo.Append(this.DM.mStringTable.GetStringByID(12586U));
      this.SkillInfo.Append("\n");
      this.SkillInfo.Append(this.DM.mStringTable.GetStringByID(12591U));
      this.SkillInfo.Append("\n");
      this.SkillInfo.Append(this.DM.mStringTable.GetStringByID(12583U));
      this.GM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(12562U), this.SkillInfo.ToString(), bInfo: true, BackExit: true);
    }
    else
      this.UpdateUI(0, 0);
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    if (sender.m_BtnID1 == 1 || sender.m_BtnID1 != 2)
      ;
  }

  public void RequestApplyList()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PETSKILL_FATIGUE;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  protected enum SkillType : byte
  {
  }
}
