// Decompiled with JetBrains decompiler
// Type: UIPetBuff
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIPetBuff : 
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
  private Transform Hero_3D;
  private Transform Hero_Pos;
  private Transform HintButt;
  private ScrollPanel m_scroll;
  private PetBuff.SkillPanelItem[] m_panel = new PetBuff.SkillPanelItem[8];
  private Animation tmpAN;
  protected bool bRequest;
  protected bool bReturn;
  protected bool bExit;
  protected bool bEnd;
  protected Door door;
  protected UnityEngine.UI.Text[] m_label = new UnityEngine.UI.Text[28];
  protected UnityEngine.UI.Text m_fatigue;
  protected UnityEngine.UI.Text m_limit;
  protected UnityEngine.UI.Text m_title;
  protected UnityEngine.UI.Text m_error;
  protected UnityEngine.UI.Text m_filter;
  protected UnityEngine.UI.Text m_search;
  protected UnityEngine.UI.Text m_button;
  protected UnityEngine.UI.Text m_content;
  protected UnityEngine.UI.Text[] m_default = new UnityEngine.UI.Text[3];
  protected UnityEngine.UI.Text[][] m_itemrow = new UnityEngine.UI.Text[10][];
  protected UnityEngine.UI.Text m_descript;
  protected Image m_Dukedom;
  protected Image m_Backdoor;
  protected Image m_Defeater;
  protected Image m_MyEmperor;
  protected Image m_CrownBack;
  protected Image m_WorldWarZ;
  protected Image m_WorldPiss;
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
  private string[] mHeroAct = new string[7];
  private CString[] m_Couting = new CString[10];
  private CString[] m_Cooling = new CString[10];
  private CString[] m_Buffer = new CString[10];
  private CString[] m_Str = new CString[10];
  private CString m_KingStr;
  private Effect effect;
  private ushort head;
  private uint time;
  private int type;

  public override void OnOpen(int arg1, int arg2)
  {
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (UnityEngine.Object) this.door)
      this.door.UpdateUI(1, 4);
    if (arg1 > 0)
    {
      this.transform.GetChild(1).gameObject.SetActive(false);
      this.transform.GetChild(4).gameObject.SetActive(false);
      this.transform.GetChild(2).gameObject.SetActive(true);
      this.m_Backdoor = this.transform.GetChild(2).GetChild(2).GetComponent<Image>();
      this.m_label[0] = this.transform.GetChild(2).GetChild(3).GetChild(0).GetComponent<UnityEngine.UI.Text>();
      this.m_label[0].text = this.DM.mStringTable.GetStringByID(arg1 <= 1 ? 10118U : 12552U);
      this.m_label[0].font = this.Font;
      this.m_label[1] = this.transform.GetChild(2).GetChild(5).GetChild(2).GetChild(0).GetComponent<UnityEngine.UI.Text>();
      this.m_label[1].font = this.Font;
      this.m_label[2] = this.transform.GetChild(2).GetChild(5).GetChild(2).GetChild(1).GetComponent<UnityEngine.UI.Text>();
      this.m_label[2].font = this.Font;
      this.transform.GetChild(2).GetChild(2).GetChild(0).gameObject.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.transform.GetChild(2).GetChild(2).GetChild(0).gameObject.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      if (arg1 > 1)
      {
        this.m_label[2].text = this.DM.mStringTable.GetStringByID(12588U);
        this.ItemsHeight.Add(this.m_label[2].preferredHeight + 20f);
        this.m_label[2].text = this.DM.mStringTable.GetStringByID(12589U);
        this.ItemsHeight.Add(this.m_label[2].preferredHeight);
        this.m_label[2].text = this.DM.mStringTable.GetStringByID(12590U);
        this.ItemsHeight.Add(this.m_label[2].preferredHeight);
        this.m_label[2].text = this.DM.mStringTable.GetStringByID(12591U);
        this.ItemsHeight.Add(this.m_label[2].preferredHeight);
      }
      else
      {
        for (int index = 0; index <= 12; ++index)
        {
          if (index == 0 || index == 5 || index == 8)
          {
            this.m_label[1].text = this.DM.mStringTable.GetStringByID((uint) (index + 12579));
            this.ItemsHeight.Add(this.m_label[1].preferredHeight);
          }
          else
          {
            this.m_label[2].text = this.DM.mStringTable.GetStringByID((uint) (index + 12579));
            this.ItemsHeight.Add(this.m_label[2].preferredHeight + (index == 4 || index == 7 || index == 9 ? 20f : 0.0f));
          }
        }
      }
      this.m_label[1].text = string.Empty;
      this.m_label[2].text = string.Empty;
      this.type = arg1;
      this.m_scroll = this.transform.GetChild(2).GetChild(4).GetComponent<ScrollPanel>();
      this.m_scroll.IntiScrollPanel(298f, 3f, 0.0f, this.ItemsHeight, this.ItemsHeight.Count, (IUpDateScrollPanel) this);
      this.m_scroll.gameObject.SetActive(true);
    }
    if (!(bool) (UnityEngine.Object) this.m_Backdoor)
      this.m_Backdoor = this.transform.GetChild(1).GetChild(6).GetComponent<Image>();
    ((Component) this.m_Backdoor).transform.GetChild(0).gameObject.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_Backdoor.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.m_Backdoor).material = this.door.LoadMaterial();
    if (GUIManager.Instance.bOpenOnIPhoneX)
      ((Behaviour) this.m_Backdoor).enabled = false;
    this.m_Backdoor = ((Component) this.m_Backdoor).transform.GetChild(0).GetComponent<Image>();
    this.m_Backdoor.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.m_Backdoor).material = this.door.LoadMaterial();
    if ((bool) (UnityEngine.Object) this.m_scroll)
      return;
    this.m_label[20] = this.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_label[20].text = this.DM.mStringTable.GetStringByID(12551U);
    this.m_label[20].font = this.Font;
    this.m_label[21] = this.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_label[21].text = this.DM.mStringTable.GetStringByID(12550U);
    this.m_label[21].font = this.Font;
    this.m_label[10] = this.transform.GetChild(4).GetChild(2).GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_label[10].text = this.DM.mStringTable.GetStringByID(12552U);
    this.m_label[10].font = this.Font;
    this.m_label[11] = this.transform.GetChild(4).GetChild(2).GetChild(2).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_label[11].text = this.DM.mStringTable.GetStringByID(12557U);
    this.m_label[11].font = this.Font;
    this.m_label[1] = this.transform.GetChild(4).GetChild(2).GetChild(3).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.m_label[1].text = this.DM.mStringTable.GetStringByID(12558U);
    this.m_label[1].font = this.Font;
    this.m_label[2] = this.transform.GetChild(4).GetChild(2).GetChild(2).GetChild(2).GetComponent<UnityEngine.UI.Text>();
    this.m_label[2].font = this.Font;
    this.m_label[2] = this.transform.GetChild(4).GetChild(2).GetChild(3).GetChild(2).GetComponent<UnityEngine.UI.Text>();
    this.m_label[2].font = this.Font;
    this.m_label[2].text = this.DM.mStringTable.GetStringByID(6097U);
    this.m_label[2] = this.transform.GetChild(4).GetChild(2).GetChild(3).GetChild(3).GetComponent<UnityEngine.UI.Text>();
    this.m_label[2].font = this.Font;
    this.m_label[3] = this.transform.GetChild(4).GetChild(3).GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_label[3].text = this.DM.mStringTable.GetStringByID(12553U);
    this.m_label[3].font = this.Font;
    this.m_label[3] = this.transform.GetChild(4).GetChild(3).GetChild(2).GetComponent<UnityEngine.UI.Text>();
    this.m_label[3].font = this.Font;
    this.m_label[3] = this.transform.GetChild(4).GetChild(3).GetChild(3).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.m_label[3].font = this.Font;
    this.m_label[3] = this.transform.GetChild(4).GetChild(3).GetChild(3).GetChild(2).GetComponent<UnityEngine.UI.Text>();
    this.m_label[3].font = this.Font;
    this.m_label[4] = this.transform.GetChild(4).GetChild(4).GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_label[4].text = this.DM.mStringTable.GetStringByID(12554U);
    this.m_label[4].font = this.Font;
    this.m_label[5] = this.transform.GetChild(4).GetChild(4).GetChild(2).GetComponent<UnityEngine.UI.Text>();
    this.m_label[5].font = this.Font;
    this.m_label[6] = this.transform.GetChild(4).GetChild(4).GetChild(3).GetComponent<UnityEngine.UI.Text>();
    this.m_label[6].font = this.Font;
    this.m_label[6] = this.transform.GetChild(4).GetChild(4).GetChild(4).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.m_label[6].text = this.DM.mStringTable.GetStringByID(6097U);
    this.m_label[6].font = this.Font;
    this.m_label[6] = this.transform.GetChild(4).GetChild(4).GetChild(4).GetChild(2).GetComponent<UnityEngine.UI.Text>();
    this.m_label[6].font = this.Font;
    this.m_label[6] = this.transform.GetChild(4).GetChild(4).GetChild(4).GetChild(4).GetComponent<UnityEngine.UI.Text>();
    this.m_label[6].font = this.Font;
    this.m_label[7] = this.transform.GetChild(4).GetChild(4).GetChild(6).GetComponent<UnityEngine.UI.Text>();
    this.m_label[7].font = this.Font;
    this.m_label[8] = this.transform.GetChild(4).GetChild(4).GetChild(7).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_label[8].text = this.DM.mStringTable.GetStringByID(94U);
    this.m_label[8].font = this.Font;
    this.m_label[8] = this.transform.GetChild(4).GetChild(4).GetChild(7).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.m_label[8].text = this.DM.mStringTable.GetStringByID(94U);
    this.m_label[8].font = this.Font;
    this.m_label[9] = this.transform.GetChild(4).GetChild(4).GetChild(7).GetChild(2).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.m_label[9].text = this.DM.mStringTable.GetStringByID(94U);
    this.m_label[9].font = this.Font;
    this.m_label[9] = this.transform.GetChild(4).GetChild(4).GetChild(7).GetChild(2).GetChild(2).GetComponent<UnityEngine.UI.Text>();
    this.m_label[9].text = !GUIManager.Instance.IsArabic ? "x1" : "1x";
    this.m_label[9].font = this.Font;
    this.m_label[9] = this.transform.GetChild(4).GetChild(4).GetChild(7).GetChild(2).GetChild(3).GetComponent<UnityEngine.UI.Text>();
    this.m_label[9].text = this.DM.mStringTable.GetStringByID(94U);
    this.m_label[9].font = this.Font;
    this.m_label[9] = this.transform.GetChild(4).GetChild(4).GetChild(7).GetChild(2).GetChild(4).GetComponent<UnityEngine.UI.Text>();
    this.m_label[9].text = !GUIManager.Instance.IsArabic ? "x1" : "1x";
    this.m_label[9].font = this.Font;
    this.m_label[11] = this.transform.GetChild(4).GetChild(4).GetChild(9).GetComponent<UnityEngine.UI.Text>();
    this.m_label[11].text = !GUIManager.Instance.IsArabic ? "x1" : "1x";
    this.m_label[11].font = this.Font;
    this.m_label[11] = this.transform.GetChild(4).GetChild(4).GetChild(10).GetComponent<UnityEngine.UI.Text>();
    this.m_label[11].font = this.Font;
    this.m_Dukedom = this.transform.GetChild(1).GetChild(19).GetComponent<Image>();
    if (GUIManager.Instance.IsArabic)
      this.transform.GetChild(1).GetChild(16).gameObject.AddComponent<ArabicItemTextureRot>();
    this.GM.InitianHeroItemImg(this.transform.GetChild(4).GetChild(4).GetChild(7).GetChild(2).GetChild(0).GetChild(0).transform, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.transform.GetChild(1).GetChild(6).GetChild(0).gameObject.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(1).GetChild(16).gameObject.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_UIHint = this.transform.GetChild(4).GetChild(4).GetChild(5).gameObject.AddComponent<UIButtonHint>();
    this.m_UIHint.m_eHint = EUIButtonHint.CountDown;
    this.m_UIHint.DelayTime = 0.3f;
    this.m_UIHint = this.transform.GetChild(4).GetChild(3).GetChild(4).gameObject.AddComponent<UIButtonHint>();
    this.m_UIHint.m_eHint = EUIButtonHint.CountDown;
    this.m_UIHint.DelayTime = 0.3f;
    this.m_UIHint.Parm2 = (byte) 1;
    this.m_UIHint = this.transform.GetChild(4).GetChild(4).GetChild(8).gameObject.AddComponent<UIButtonHint>();
    this.m_UIHint.m_eHint = EUIButtonHint.CountDown;
    this.m_UIHint.DelayTime = 0.3f;
    this.m_UIHint.Parm2 = (byte) 2;
    for (int index = 0; index < 10; ++index)
    {
      this.m_itemrow[index] = new UnityEngine.UI.Text[10];
      this.m_Str[index] = StringManager.Instance.SpawnString(300);
      this.m_Buffer[index] = StringManager.Instance.SpawnString(300);
      this.m_Cooling[index] = StringManager.Instance.SpawnString(300);
      this.m_Couting[index] = StringManager.Instance.SpawnString(300);
    }
    this.m_KingStr = StringManager.Instance.SpawnString(300);
    this.m_scroll = this.transform.GetChild(1).GetChild(9).GetComponent<ScrollPanel>();
    this.m_scroll.IntiScrollPanel(298f, 0.0f, 0.0f, this.ItemsHeight, 8, (IUpDateScrollPanel) this);
    this.m_scroll.gameObject.SetActive(true);
    this.SkillRect = this.m_scroll.transform.GetChild(0).GetComponent<RectTransform>();
    UIButtonHint.scrollRect = this.m_scroll.GetComponent<CScrollRect>();
    this.RequestFatigue();
    this.Refresh();
    NewbieManager.CheckPetSkillFromUI();
  }

  public void RequestFatigue()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PETSKILL_FATIGUE;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void RequestSkillUse(ushort pet, ushort skill, ushort zone = 0, byte point = 0)
  {
    PetSkillTbl recordByKey = PetManager.Instance.PetSkillTable.GetRecordByKey(skill);
    if (!this.PM.UseSkill(skill, pet) || recordByKey.Type != (byte) 1 || recordByKey.Class < (byte) 1 || (int) recordByKey.Class > PetBuff.PetSkillList.Length || this.PM.CoolDownData == null || this.PM.BuffInfoData == null)
      return;
    if (this.PM.CDFinder != null && this.PM.CDFinder.ContainsKey(skill))
      this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12575U), (ushort) byte.MaxValue);
    else if (recordByKey.Diamond > (ushort) 0 && this.DM.GetCurItemQuantity(recordByKey.Diamond, (byte) 0) == (ushort) 0)
    {
      this.GM.MsgStr.ClearString();
      this.GM.MsgStr.StringToFormat(this.DM.mStringTable.GetStringByID(14654U));
      this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(1545U));
      this.GM.OpenMessageBox(this.GM.MsgStr.ToString(), this.DM.mStringTable.GetStringByID(12571U), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, (int) recordByKey.Diamond, (int) skill, true);
    }
    else
    {
      if (recordByKey.Subject == (byte) 1)
        GameConstants.MapIDToPointCode(this.DM.RoleAttr.CapitalPoint, out zone, out point);
      GUIManager.Instance.ShowUILock(EUILock.PetSkill);
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_PETSKILL_USE;
      messagePacket.AddSeqId();
      messagePacket.Add(zone);
      messagePacket.Add(point);
      messagePacket.Add(pet);
      messagePacket.Add(skill);
      messagePacket.Send();
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (UnityEngine.Object) menu)
    {
      img.sprite = menu.LoadSprite(ImageName);
      ((MaskableGraphic) img).material = menu.LoadMaterial();
    }
    img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
    ((MaskableGraphic) img).material = GUIManager.Instance.GetFrameMaterial();
  }

  private void Refresh(int arg1 = 0)
  {
    this.ItemsHeight.Clear();
    this.ItemsHeight.Add(124f);
    PetBuff.PetSkills.Clear();
    PetBuff.PetSkills.Add(new PetBuff.PetSkill(0U, 0, (byte) 0, (byte) 0, (ushort) 0));
    int num1 = 0;
    int num2 = 1;
    for (; num1 < this.PM.BuffInfo.Count; ++num1)
    {
      if (this.PM.NegBuff.ContainsKey(this.PM.BuffInfo[num1].SkillID))
      {
        this.ItemsHeight.Add(num2 <= 1 ? 135f : 100f);
        PetBuff.PetSkills.Add(new PetBuff.PetSkill(0U, num2++, (byte) 0, (byte) 0, (ushort) num1));
      }
    }
    this.SetSkill(false);
    for (int cls = 0; cls < PetBuff.PetSkillList.Length; ++cls)
    {
      int index = 0;
      int num3 = 0;
      for (; index < PetBuff.PetSkillList[cls].Count; ++index)
      {
        if (PetBuff.PetSkillList[cls][index].Subject == (byte) 1)
        {
          this.ItemsHeight.Add(num3 <= 0 ? 135f : 100f);
          PetBuff.PetSkills.Add(new PetBuff.PetSkill(PetBuff.PetSkillList[cls][index].Id, num3++, (byte) cls, PetBuff.PetSkillList[cls][index].Slot, PetBuff.PetSkillList[cls][index].Pet));
        }
      }
    }
    this.m_scroll.AddNewDataHeight(this.ItemsHeight);
    this.m_scroll.GoTo(UIPetBuff.Positioning, UIPetBuff.Scrolling);
  }

  protected void SetPanelItem()
  {
    if (this.m_panel == null)
      return;
    for (int index = 0; index < this.m_panel.Length; ++index)
    {
      if (this.m_panel[index].Init && (bool) (UnityEngine.Object) this.m_panel[index].Item && this.m_panel[index].ID >= 0 && this.m_panel[index].ID < PetBuff.PetSkills.Count)
      {
        PetSkillTbl recordByKey = PetManager.Instance.PetSkillTable.GetRecordByKey((ushort) PetBuff.PetSkills[this.m_panel[index].ID].ID);
        if (recordByKey.Diamond > (ushort) 0)
        {
          ushort curItemQuantity = this.DM.GetCurItemQuantity(recordByKey.Diamond, (byte) 0);
          this.m_panel[index].Item.transform.GetChild(4).GetChild(6).GetComponent<UnityEngine.UI.Text>().text = string.Format(this.DM.mStringTable.GetStringByID(12559U), (object) curItemQuantity);
          this.m_panel[index].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(4).gameObject.SetActive(curItemQuantity == (ushort) 0);
          this.m_panel[index].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(2).gameObject.SetActive(curItemQuantity > (ushort) 0);
        }
      }
    }
  }

  protected void SetPanelItem(int idx, bool force = false)
  {
    if (this.m_panel == null || !this.m_panel[idx].Init || !(bool) (UnityEngine.Object) this.m_panel[idx].Item || this.PM.CoolDownData == null || this.PM.BuffInfoData == null || !this.m_panel[idx].Item.activeInHierarchy && !force || this.m_panel[idx].ID < 0 || this.m_panel[idx].ID >= PetBuff.PetSkills.Count)
      return;
    this.m_Buffer[idx].ClearString();
    if (PetBuff.PetSkills[this.m_panel[idx].ID].ID > 0U)
    {
      CString CStr = this.m_Buffer[idx];
      PetBuff.PetSkill petSkill = PetBuff.PetSkills[this.m_panel[idx].ID];
      uint Require;
      long num1;
      int sec1 = (int) (uint) (num1 = PetBuff.CheckSkillBuff((ushort) petSkill.ID, out Require));
      GameConstants.GetTimeString(CStr, (uint) sec1);
      this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(2).GetComponent<UnityEngine.UI.Text>().text = this.m_Buffer[idx].ToString();
      this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(2).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
      ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(2).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
      if (Require > 0U && num1 > 0L)
        ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(0).GetChild(0).GetComponent<Image>()).rectTransform.sizeDelta = new Vector2((float) Math.Min((uint) ((ulong) Require - (ulong) num1), Require) * 341f / (float) Require, 19f);
      this.m_panel[idx].Item.transform.GetChild(4).GetChild(2).gameObject.SetActive(num1 == 0L);
      this.m_panel[idx].Item.transform.GetChild(4).GetChild(3).gameObject.SetActive(num1 == 0L);
      byte index;
      if (num1 > 0L && !this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).gameObject.activeSelf && this.PM.PosBuff.TryGetValue((ushort) PetBuff.PetSkills[this.m_panel[idx].ID].ID, out index))
      {
        PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.PM.BuffInfo[(int) index].SkillID);
        this.PM.FormatSkillContent(this.PM.BuffInfo[(int) index].SkillID, this.PM.BuffInfo[(int) index].Level, this.m_Str[idx], recordByKey.Status <= (ushort) 0 ? (byte) 0 : (byte) 1);
        this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(4).GetComponent<UnityEngine.UI.Text>().text = this.m_Str[idx].ToString();
        this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(4).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
        ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(4).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
      }
      this.m_panel[idx].Item.transform.GetChild(4).GetChild(5).gameObject.GetComponent<UIButtonHint>().Parm2 = num1 <= 0L ? (byte) 0 : (byte) 1;
      this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).gameObject.SetActive(num1 > 0L);
      long sec2 = PetBuff.CheckSkillCD((ushort) PetBuff.PetSkills[this.m_panel[idx].ID].ID);
      if (sec2 == 0L)
      {
        PetSkillCoolTbl recordByKey = this.PM.PetSkillCoolTable.GetRecordByKey(this.m_panel[idx].CoolDown);
        PetData petData = PetManager.Instance.FindPetData(PetBuff.PetSkills[this.m_panel[idx].ID].Pet);
        if (petData != null && petData.SkillLv != null && (force || !this.m_panel[idx].Item.transform.GetChild(4).GetChild(8).GetChild(1).gameObject.activeSelf))
        {
          this.m_Couting[idx].ClearString();
          byte num2 = petData.SkillLv[(int) PetBuff.PetSkills[this.m_panel[idx].ID].Slot];
          if (num2 > (byte) 0 && (int) num2 <= recordByKey.CoolBySkillLv.Length)
          {
            this.PM.FormatCoolTime(recordByKey.CoolBySkillLv[(int) num2 - 1], this.m_Couting[idx], (byte) 0);
            this.m_panel[idx].Item.transform.GetChild(4).GetChild(10).GetComponent<UnityEngine.UI.Text>().text = this.m_Couting[idx].ToString();
            this.m_panel[idx].Item.transform.GetChild(4).GetChild(10).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
            ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(10).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
          }
        }
      }
      else
      {
        this.m_Couting[idx].ClearString();
        GameConstants.GetTimeString(this.m_Couting[idx], (uint) sec2, hideTimeIfDays: true, showZeroHour: false);
        this.m_panel[idx].Item.transform.GetChild(4).GetChild(9).GetComponent<UnityEngine.UI.Text>().text = this.m_Couting[idx].ToString();
        this.m_panel[idx].Item.transform.GetChild(4).GetChild(9).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
        ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(9).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
      }
      if (this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).gameObject.activeSelf)
      {
        if (sec2 > 0L || this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(4).gameObject.activeSelf)
        {
          this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(1).gameObject.SetActive(false);
          this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(3).gameObject.SetActive(true);
        }
        else
        {
          this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(3).gameObject.SetActive(false);
          this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(1).gameObject.SetActive(true);
        }
      }
      else if (sec2 > 0L)
      {
        this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(0).gameObject.SetActive(false);
        this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(1).gameObject.SetActive(true);
      }
      else
      {
        this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(1).gameObject.SetActive(false);
        this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(0).gameObject.SetActive(true);
      }
      this.m_panel[idx].Item.transform.GetChild(4).GetChild(8).gameObject.GetComponent<UIButtonHint>().Parm1 = sec2 <= 0L ? (ushort) 0 : (ushort) 1;
      if (this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(0).GetChild(0).childCount > 1)
      {
        ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>()).color = sec2 <= 0L ? Color.white : Color.gray;
        ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>()).color = sec2 <= 0L ? Color.white : Color.gray;
      }
      ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetComponent<Image>()).color = sec2 <= 0L ? Color.white : Color.gray;
      ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(0).GetComponent<UnityEngine.UI.Text>()).color = ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(0).GetChild(sec2 <= 0L ? 0 : 1).GetComponent<UnityEngine.UI.Text>()).color;
      ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(1).GetComponent<UnityEngine.UI.Text>()).color = ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(1).GetChild(sec2 <= 0L ? 0 : 1).GetComponent<UnityEngine.UI.Text>()).color;
      ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(1).GetComponent<UnityEngine.UI.Text>()).color = ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(1).GetChild(sec2 <= 0L ? 0 : 1).GetComponent<UnityEngine.UI.Text>()).color;
      ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(2).GetComponent<UnityEngine.UI.Text>()).color = ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(2).GetChild(sec2 <= 0L ? 0 : 1).GetComponent<UnityEngine.UI.Text>()).color;
      ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(3).GetComponent<UnityEngine.UI.Text>()).color = ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(3).GetChild(sec2 <= 0L ? 0 : 1).GetComponent<UnityEngine.UI.Text>()).color;
      ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(4).GetComponent<UnityEngine.UI.Text>()).color = ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(4).GetChild(sec2 <= 0L ? 0 : 1).GetComponent<UnityEngine.UI.Text>()).color;
      this.m_panel[idx].Item.transform.GetChild(4).GetChild(8).GetChild(1).gameObject.SetActive(sec2 == 0L);
      this.m_panel[idx].Item.transform.GetChild(4).GetChild(8).GetChild(0).gameObject.SetActive(sec2 > 0L);
      this.m_panel[idx].Item.transform.GetChild(4).GetChild(10).gameObject.SetActive(sec2 == 0L);
      this.m_panel[idx].Item.transform.GetChild(4).GetChild(9).gameObject.SetActive(sec2 > 0L);
    }
    else if (PetBuff.PetSkills[this.m_panel[idx].ID].Idx > 0)
    {
      CString CStr = this.m_Buffer[idx];
      PetBuff.PetSkill petSkill = PetBuff.PetSkills[this.m_panel[idx].ID];
      long num;
      int sec = (int) (uint) (num = this.CheckSkillBuff((byte) petSkill.Pet));
      GameConstants.GetTimeString(CStr, (uint) sec);
      this.m_panel[idx].Item.transform.GetChild(3).GetChild(3).GetChild(2).GetComponent<UnityEngine.UI.Text>().text = this.m_Buffer[idx].ToString();
      this.m_panel[idx].Item.transform.GetChild(3).GetChild(3).GetChild(2).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
      ((Graphic) this.m_panel[idx].Item.transform.GetChild(3).GetChild(3).GetChild(2).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
      if ((int) PetBuff.PetSkills[this.m_panel[idx].ID].Pet >= this.PM.BuffInfo.Count || this.PM.BuffInfo[(int) PetBuff.PetSkills[this.m_panel[idx].ID].Pet].RequireTime <= 0U)
        return;
      ((Graphic) this.m_panel[idx].Item.transform.GetChild(3).GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>()).rectTransform.sizeDelta = new Vector2((float) Math.Min((uint) ((ulong) this.PM.BuffInfo[(int) PetBuff.PetSkills[this.m_panel[idx].ID].Pet].RequireTime - (ulong) num), this.PM.BuffInfo[(int) PetBuff.PetSkills[this.m_panel[idx].ID].Pet].RequireTime) * 341f / (float) this.PM.BuffInfo[(int) PetBuff.PetSkills[this.m_panel[idx].ID].Pet].RequireTime, 19f);
    }
    else
    {
      if (this.PM.BuffImmune.BeginTime > 0L && this.PM.BuffImmune.RequireTime > 0U)
      {
        long num;
        GameConstants.GetTimeString(this.m_Buffer[idx], (uint) (int) (num = PetBuff.CheckSkillBuff((ushort) 0)));
        this.m_panel[idx].Item.transform.GetChild(2).GetChild(3).GetChild(3).GetComponent<UnityEngine.UI.Text>().text = this.m_Buffer[idx].ToString();
        this.m_panel[idx].Item.transform.GetChild(2).GetChild(3).GetChild(3).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
        ((Graphic) this.m_panel[idx].Item.transform.GetChild(2).GetChild(3).GetChild(3).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
        ((Graphic) this.m_panel[idx].Item.transform.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>()).rectTransform.sizeDelta = new Vector2((float) Math.Min((uint) ((ulong) this.PM.BuffImmune.RequireTime - (ulong) num), this.PM.BuffImmune.RequireTime) * 341f / (float) this.PM.BuffImmune.RequireTime, 19f);
      }
      else
      {
        ((Graphic) this.m_panel[idx].Item.transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<Image>()).rectTransform.sizeDelta = new Vector2((float) ((double) Math.Min((int) DataManager.Instance.RoleAttr.PetSkillFatigue, 480) / 480.0 * 341.0), 19f);
        this.m_Buffer[idx].IntToFormat((long) DataManager.Instance.RoleAttr.PetSkillFatigue);
        this.m_Buffer[idx].IntToFormat(480L);
        this.m_Buffer[idx].AppendFormat(!GUIManager.Instance.IsArabic ? "{0} / {1}" : "{1} / {0}");
        this.m_panel[idx].Item.transform.GetChild(2).GetChild(2).GetChild(2).GetComponent<UnityEngine.UI.Text>().text = this.m_Buffer[idx].ToString();
        this.m_panel[idx].Item.transform.GetChild(2).GetChild(2).GetChild(2).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
        ((Graphic) this.m_panel[idx].Item.transform.GetChild(2).GetChild(2).GetChild(2).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
      }
      this.m_panel[idx].Item.transform.GetChild(2).GetChild(2).gameObject.SetActive(this.PM.BuffImmune.BeginTime <= 0L);
      this.m_panel[idx].Item.transform.GetChild(2).GetChild(3).gameObject.SetActive(this.PM.BuffImmune.BeginTime > 0L);
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelId > 0)
    {
      this.m_label[panelObjectIdx + 1] = item.transform.GetChild(2).GetChild(dataIdx != 0 && dataIdx != 5 && dataIdx != 8 || this.type != 1 ? 1 : 0).GetComponent<UnityEngine.UI.Text>();
      this.m_label[panelObjectIdx + 1].text = this.DM.mStringTable.GetStringByID((uint) ((this.type <= 1 ? 12579 : 12588) + dataIdx));
    }
    else
    {
      if (dataIdx < 0 || dataIdx >= PetBuff.PetSkills.Count || panelObjectIdx >= this.m_panel.Length)
        return;
      if (!this.m_panel[panelObjectIdx].Init)
      {
        item.transform.GetChild(4).GetChild(8).gameObject.GetComponent<UIButtonHint>().m_Handler = (MonoBehaviour) this;
        item.transform.GetChild(4).GetChild(5).gameObject.GetComponent<UIButtonHint>().m_Handler = (MonoBehaviour) this;
        item.transform.GetChild(3).GetChild(4).gameObject.GetComponent<UIButtonHint>().m_Handler = (MonoBehaviour) this;
        item.transform.GetChild(4).GetChild(7).gameObject.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        item.transform.GetChild(2).gameObject.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.m_panel[panelObjectIdx].Text = new UnityEngine.UI.Text[25];
        this.m_panel[panelObjectIdx].Text[0] = (UnityEngine.UI.Text) item.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[1] = (UnityEngine.UI.Text) item.transform.GetChild(2).GetChild(2).GetChild(0).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[2] = (UnityEngine.UI.Text) item.transform.GetChild(2).GetChild(2).GetChild(2).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[3] = (UnityEngine.UI.Text) item.transform.GetChild(2).GetChild(3).GetChild(1).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[4] = (UnityEngine.UI.Text) item.transform.GetChild(2).GetChild(3).GetChild(2).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[5] = (UnityEngine.UI.Text) item.transform.GetChild(2).GetChild(3).GetChild(3).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[6] = (UnityEngine.UI.Text) item.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[7] = (UnityEngine.UI.Text) item.transform.GetChild(3).GetChild(2).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[8] = (UnityEngine.UI.Text) item.transform.GetChild(3).GetChild(3).GetChild(1).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[9] = (UnityEngine.UI.Text) item.transform.GetChild(3).GetChild(3).GetChild(2).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[10] = (UnityEngine.UI.Text) item.transform.GetChild(4).GetChild(0).GetChild(0).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[11] = (UnityEngine.UI.Text) item.transform.GetChild(4).GetChild(2).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[12] = (UnityEngine.UI.Text) item.transform.GetChild(4).GetChild(3).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[13] = (UnityEngine.UI.Text) item.transform.GetChild(4).GetChild(4).GetChild(1).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[14] = (UnityEngine.UI.Text) item.transform.GetChild(4).GetChild(4).GetChild(2).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[15] = (UnityEngine.UI.Text) item.transform.GetChild(4).GetChild(4).GetChild(4).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[16] = (UnityEngine.UI.Text) item.transform.GetChild(4).GetChild(6).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[17] = (UnityEngine.UI.Text) item.transform.GetChild(4).GetChild(7).GetChild(0).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[18] = (UnityEngine.UI.Text) item.transform.GetChild(4).GetChild(7).GetChild(1).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[19] = (UnityEngine.UI.Text) item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(1).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[20] = (UnityEngine.UI.Text) item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(2).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[21] = (UnityEngine.UI.Text) item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(3).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[22] = (UnityEngine.UI.Text) item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(4).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[23] = (UnityEngine.UI.Text) item.transform.GetChild(4).GetChild(9).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Text[24] = (UnityEngine.UI.Text) item.transform.GetChild(4).GetChild(10).gameObject.GetComponent<UIText>();
        this.m_panel[panelObjectIdx].Item = item;
        this.m_panel[panelObjectIdx].Init = true;
      }
      CString SpriteName = StringManager.Instance.StaticString1024();
      item.transform.GetChild(2).gameObject.SetActive(PetBuff.PetSkills[dataIdx].ID == 0U && PetBuff.PetSkills[dataIdx].Idx == 0);
      item.transform.GetChild(3).gameObject.SetActive(PetBuff.PetSkills[dataIdx].ID == 0U && PetBuff.PetSkills[dataIdx].Idx > 0);
      item.transform.GetChild(4).gameObject.SetActive(PetBuff.PetSkills[dataIdx].ID > 0U);
      this.m_panel[panelObjectIdx].ID = dataIdx;
      if (PetBuff.PetSkills[dataIdx].ID > 0U)
      {
        PetData petData = PetManager.Instance.FindPetData(PetBuff.PetSkills[dataIdx].Pet);
        PetSkillTbl recordByKey = PetManager.Instance.PetSkillTable.GetRecordByKey((ushort) PetBuff.PetSkills[dataIdx].ID);
        this.GM.ChangeHeroItemImg(item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(0).GetChild(0).transform, eHeroOrItem.Item, recordByKey.Diamond, (byte) 0, (byte) 0);
        if (petData != null && petData.SkillLv != null)
        {
          this.m_Cooling[panelObjectIdx].ClearString();
          this.m_Cooling[panelObjectIdx].IntToFormat((long) petData.SkillLv[(int) PetBuff.PetSkills[dataIdx].Slot]);
          this.m_Cooling[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
          this.m_Cooling[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(268U));
          item.transform.GetChild(4).GetChild(2).GetComponent<UnityEngine.UI.Text>().text = this.m_Cooling[panelObjectIdx].ToString();
          ((Graphic) item.transform.GetChild(4).GetChild(2).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
          item.transform.GetChild(4).GetChild(2).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
          this.PM.FormatSkillContent((ushort) PetBuff.PetSkills[dataIdx].ID, petData.SkillLv[(int) PetBuff.PetSkills[dataIdx].Slot], this.m_Str[panelObjectIdx], (byte) 0);
        }
        else
          item.transform.GetChild(4).GetChild(2).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID((uint) recordByKey.Name);
        if (PetBuff.PetSkills[dataIdx].Idx == 0 && PetBuff.PetSkills[dataIdx].Class > (byte) 0)
        {
          if (PetBuff.PetSkills[dataIdx].Class == (byte) 1)
            item.transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(12578U);
          else if ((int) PetBuff.PetSkills[dataIdx].Class < PetBuff.PetSkillList.Length)
            item.transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID((uint) PetBuff.PetSkills[dataIdx].Class + 12552U);
        }
        if (recordByKey.Diamond > (ushort) 0)
        {
          ushort curItemQuantity = this.DM.GetCurItemQuantity(recordByKey.Diamond, (byte) 0);
          item.transform.GetChild(4).GetChild(6).GetComponent<UnityEngine.UI.Text>().text = string.Format(this.DM.mStringTable.GetStringByID(12559U), (object) curItemQuantity);
          item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(4).gameObject.SetActive(curItemQuantity == (ushort) 0);
          item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(2).gameObject.SetActive(curItemQuantity > (ushort) 0);
        }
        item.transform.GetChild(4).localPosition = PetBuff.PetSkills[dataIdx].Idx <= 0 ? Vector3.zero : new Vector3(0.0f, 35f, 0.0f);
        item.transform.GetChild(4).GetChild(13).gameObject.SetActive(dataIdx + 1 < PetBuff.PetSkills.Count && PetBuff.PetSkills[dataIdx + 1].Idx > 0);
        item.transform.GetChild(4).GetChild(0).gameObject.SetActive(PetBuff.PetSkills[dataIdx].Idx == 0);
        item.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
        item.transform.GetChild(4).GetChild(3).GetComponent<UnityEngine.UI.Text>().text = this.m_Str[panelObjectIdx].ToString();
        ((Graphic) item.transform.GetChild(4).GetChild(3).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
        item.transform.GetChild(4).GetChild(3).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
        item.transform.GetChild(4).GetChild(6).gameObject.SetActive(recordByKey.Diamond > (ushort) 0);
        item.transform.GetChild(4).GetChild(7).GetChild(0).gameObject.SetActive(recordByKey.Diamond == (ushort) 0);
        item.transform.GetChild(4).GetChild(7).GetChild(1).gameObject.SetActive(recordByKey.Diamond == (ushort) 0);
        item.transform.GetChild(4).GetChild(7).GetChild(2).gameObject.SetActive(recordByKey.Diamond > (ushort) 0);
        item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(1).gameObject.SetActive(false);
        item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(3).gameObject.SetActive(false);
        byte index;
        if (this.PM.PosBuff.TryGetValue((ushort) PetBuff.PetSkills[dataIdx].ID, out index))
        {
          item.transform.GetChild(4).GetChild(5).gameObject.GetComponent<UIButtonHint>().Parm2 = (byte) 1;
          this.PM.FormatSkillContent((ushort) PetBuff.PetSkills[dataIdx].ID, this.PM.BuffInfo[(int) index].Level, this.m_Str[panelObjectIdx], recordByKey.Status <= (ushort) 0 ? (byte) 0 : (byte) 1);
          item.transform.GetChild(4).GetChild(4).GetChild(4).GetComponent<UnityEngine.UI.Text>().text = this.m_Str[panelObjectIdx].ToString();
          item.transform.GetChild(4).GetChild(4).GetChild(4).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
          ((Graphic) item.transform.GetChild(4).GetChild(4).GetChild(4).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
        }
        else
          item.transform.GetChild(4).GetChild(5).gameObject.GetComponent<UIButtonHint>().Parm2 = (byte) 0;
        item.transform.GetChild(4).GetChild(5).gameObject.GetComponent<UIButtonHint>().Parm1 = (ushort) dataIdx;
        item.transform.GetChild(4).GetChild(7).gameObject.GetComponent<UIButton>().m_BtnID2 = dataIdx + 1;
        this.m_CrownBack = item.transform.GetChild(4).GetChild(5).gameObject.GetComponent<Image>();
        SpriteName.IntToFormat((long) recordByKey.Icon, 5);
        SpriteName.AppendFormat("s{0}");
        this.m_panel[panelObjectIdx].CoolDown = recordByKey.CoolDown;
      }
      else if (PetBuff.PetSkills[dataIdx].Idx > 0 && (int) PetBuff.PetSkills[dataIdx].Pet < this.PM.BuffInfo.Count)
      {
        item.transform.GetChild(3).GetChild(0).gameObject.SetActive(PetBuff.PetSkills[dataIdx].Idx == 1);
        item.transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition = PetBuff.PetSkills[dataIdx].Idx <= 1 ? Vector2.zero : new Vector2(0.0f, 35f);
        PetSkillTbl recordByKey = PetManager.Instance.PetSkillTable.GetRecordByKey(this.PM.BuffInfo[(int) PetBuff.PetSkills[dataIdx].Pet].SkillID);
        this.PM.FormatSkillContent(this.PM.BuffInfo[(int) PetBuff.PetSkills[dataIdx].Pet].SkillID, this.PM.BuffInfo[(int) PetBuff.PetSkills[dataIdx].Pet].Level, this.m_Str[panelObjectIdx], recordByKey.Status <= (ushort) 0 ? (byte) 0 : (byte) 1);
        item.transform.GetChild(3).GetChild(2).GetComponent<UnityEngine.UI.Text>().text = this.m_Str[panelObjectIdx].ToString();
        ((Graphic) item.transform.GetChild(3).GetChild(2).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
        item.transform.GetChild(3).GetChild(2).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
        item.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(6097U);
        item.transform.GetChild(3).GetChild(4).gameObject.GetComponent<UIButtonHint>().Parm1 = (ushort) dataIdx;
        item.transform.GetChild(3).GetChild(2).GetComponent<UnityEngine.UI.Text>().supportRichText = true;
        this.m_CrownBack = item.transform.GetChild(3).GetChild(4).gameObject.GetComponent<Image>();
        SpriteName.IntToFormat((long) recordByKey.Icon, 5);
        SpriteName.AppendFormat("s{0}");
      }
      this.SetPanelItem(panelObjectIdx, true);
      if (SpriteName.Length <= 0)
        return;
      this.m_Defeater = ((Component) this.m_CrownBack).transform.GetChild(0).GetComponent<Image>();
      this.m_Defeater.sprite = this.GM.LoadFrameSprite("sk");
      ((MaskableGraphic) this.m_Defeater).material = this.GM.GetFrameMaterial();
      this.m_CrownBack.sprite = this.GM.LoadSkillSprite(SpriteName);
      ((MaskableGraphic) this.m_CrownBack).material = this.GM.GetSkillMaterial();
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!bOnSecond || this.m_panel == null)
      return;
    for (int idx = 0; idx < this.m_panel.Length; ++idx)
      this.SetPanelItem(idx);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || !(bool) (UnityEngine.Object) this.door)
      return;
    if (GUIManager.Instance.BuildingData.GetBuildNumByID((ushort) 22) == (byte) 0)
    {
      this.door.CloseMenu();
      GUIManager.Instance.BuildingData.ManorGuild((ushort) 22);
    }
    else
      this.door.OpenMenu(EGUIWindow.UI_PetFusion, 1, arg1);
  }

  public void onFinish()
  {
  }

  private static void SearchChange(string input)
  {
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if ((bool) (UnityEngine.Object) this.m_WorldWarZ)
      sender.ControlFadeOut.SetActive(false);
    if (GUIManager.Instance.m_Hint == null)
      return;
    GUIManager.Instance.m_Hint.Hide(true);
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    this.HintButt = sender.transform;
    if (sender.Parm1 < (ushort) 0 || (int) sender.Parm1 >= PetBuff.PetSkills.Count || this.PM.CoolDownData == null || this.PM.BuffInfoData == null)
      return;
    if (sender.Parm2 > (byte) 1)
    {
      this.m_KingStr.ClearString();
      this.m_KingStr.Append(this.DM.mStringTable.GetStringByID(sender.Parm1 <= (ushort) 0 ? 12561U : 12560U));
      GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 250f, 16, this.m_KingStr, Vector2.zero);
    }
    else if (sender.Parm2 > (byte) 0)
    {
      byte index;
      if (PetBuff.PetSkills[(int) sender.Parm1].ID > 0U && (this.PM.PosBuff.TryGetValue((ushort) PetBuff.PetSkills[(int) sender.Parm1].ID, out index) || this.PM.NegBuff.TryGetValue((ushort) PetBuff.PetSkills[(int) sender.Parm1].ID, out index)))
      {
        GUIManager.Instance.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.State, PetBuff.PetSkills[(int) sender.Parm1].Pet, this.PM.BuffInfo[(int) index].SkillID, this.PM.BuffInfo[(int) index].Level, Vector2.zero);
      }
      else
      {
        if ((int) PetBuff.PetSkills[(int) sender.Parm1].Pet >= this.PM.BuffInfo.Count)
          return;
        GUIManager.Instance.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.State, PetBuff.PetSkills[(int) sender.Parm1].Pet, this.PM.BuffInfo[(int) PetBuff.PetSkills[(int) sender.Parm1].Pet].SkillID, this.PM.BuffInfo[(int) PetBuff.PetSkills[(int) sender.Parm1].Pet].Level, Vector2.zero);
      }
    }
    else
    {
      PetData petData = PetManager.Instance.FindPetData(PetBuff.PetSkills[(int) sender.Parm1].Pet);
      PetTbl recordByKey = PetManager.Instance.PetTable.GetRecordByKey(PetBuff.PetSkills[(int) sender.Parm1].Pet);
      for (int index = 0; index < 4 && index < recordByKey.PetSkill.Length; ++index)
      {
        if ((int) recordByKey.PetSkill[index] == (int) PetBuff.PetSkills[(int) sender.Parm1].ID && petData != null)
        {
          GUIManager.Instance.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.CurentLv, PetBuff.PetSkills[(int) sender.Parm1].Pet, (ushort) PetBuff.PetSkills[(int) sender.Parm1].ID, petData.SkillLv[index], Vector2.zero);
          break;
        }
      }
    }
  }

  public override void OnClose()
  {
    this.bEnd = true;
    if (this.type != 0)
      return;
    PetBuff.Refreshed = true;
    UIPetBuff.Scrolling = this.SkillRect.anchoredPosition.y;
    UIPetBuff.Positioning = this.m_scroll.GetTopIdx();
    PetBuff.UpdateSkill();
    UnityEngine.Object.Destroy((UnityEngine.Object) this.Duke);
    for (int index = 0; index < 10; ++index)
    {
      if (this.m_Str[index] != null)
        StringManager.Instance.DeSpawnString(this.m_Str[index]);
      if (this.m_Buffer[index] != null)
        StringManager.Instance.DeSpawnString(this.m_Buffer[index]);
      if (this.m_Cooling[index] != null)
        StringManager.Instance.DeSpawnString(this.m_Cooling[index]);
      if (this.m_Couting[index] != null)
        StringManager.Instance.DeSpawnString(this.m_Couting[index]);
    }
    StringManager.Instance.DeSpawnString(this.m_KingStr);
    Time.timeScale = 1f;
    this.Destroy();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (!(bool) (UnityEngine.Object) this.m_scroll || this.m_scroll.m_ScrollPanelID > 0)
      return;
    if (arg1 == 2)
      this.SetPanelItem(0);
    if (arg1 == 5)
      this.SetPanelItem();
    else if (arg1 == 6)
    {
      UIPetBuff.Scrolling = this.SkillRect.anchoredPosition.y;
      UIPetBuff.Positioning = this.m_scroll.GetTopIdx();
      this.Refresh();
    }
    if (arg1 != 10)
      return;
    GUIManager.Instance.m_Arena_Hint.ShowHint((byte) 1, this.HintButt.GetComponent<RectTransform>());
  }

  protected void UpdateItem(int idx, bool force = false)
  {
    if (this.m_panel == null || !this.m_panel[idx].Init || !(bool) (UnityEngine.Object) this.m_panel[idx].Item || this.PM.CoolDownData == null || this.PM.BuffInfoData == null || !this.m_panel[idx].Item.activeInHierarchy && !force || this.m_panel[idx].ID < 0 || this.m_panel[idx].ID >= PetBuff.PetSkills.Count)
      return;
    if (PetBuff.PetSkills[this.m_panel[idx].ID].ID > 0U)
    {
      if (!this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).gameObject.activeSelf)
        return;
      ((Graphic) this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(0).GetComponent<Image>()).color = ((Graphic) this.m_Dukedom).color;
    }
    else if (PetBuff.PetSkills[this.m_panel[idx].ID].Idx > 0)
    {
      ((Graphic) this.m_panel[idx].Item.transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<Image>()).color = ((Graphic) this.m_Dukedom).color;
    }
    else
    {
      if (this.PM.BuffImmune.BeginTime <= 0L || this.PM.BuffImmune.RequireTime <= 0U)
        return;
      ((Graphic) this.m_panel[idx].Item.transform.GetChild(2).GetChild(3).GetChild(0).GetComponent<Image>()).color = ((Graphic) this.m_Dukedom).color;
    }
  }

  public override bool OnBackButtonClick() => false;

  public void Destroy()
  {
    if ((UnityEngine.Object) this.go != (UnityEngine.Object) null)
    {
      this.go.transform.SetParent(this.Hero_Pos.parent, false);
      UnityEngine.Object.Destroy((UnityEngine.Object) this.go);
    }
    if ((UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.Hero_Model);
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
      if (!(bool) (UnityEngine.Object) this.door)
        return;
      this.door.CloseMenu();
    }
    else
    {
      if (this.bEnd || this.bReturn || this.m_panel == null)
        return;
      for (int idx = 0; idx < this.m_panel.Length; ++idx)
        this.UpdateItem(idx);
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        break;
      case NetworkNews.Fallout:
        break;
      case NetworkNews.Refresh_Asset:
        break;
      case NetworkNews.Refresh_Item:
        this.UpdateUI(5, 0);
        break;
      case NetworkNews.Refresh_Alliance:
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
        {
          if (networkNews == NetworkNews.Refresh_RecvAllianceInfo)
            break;
          break;
        }
        if (this.bEnd)
          break;
        if ((bool) (UnityEngine.Object) this.m_title && ((Behaviour) this.m_title).enabled)
        {
          ((Behaviour) this.m_title).enabled = !((Behaviour) this.m_title).enabled;
          ((Behaviour) this.m_title).enabled = !((Behaviour) this.m_title).enabled;
        }
        if (this.m_panel != null)
        {
          for (int index = 0; index < this.m_panel.Length; ++index)
            this.m_panel[index].Rebuilt();
        }
        for (int index = 0; index < 28; ++index)
        {
          if ((UnityEngine.Object) this.m_label[index] != (UnityEngine.Object) null && ((Behaviour) this.m_label[index]).enabled)
          {
            ((Behaviour) this.m_label[index]).enabled = false;
            ((Behaviour) this.m_label[index]).enabled = true;
          }
        }
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (!(bool) (UnityEngine.Object) this.door)
      return;
    if (sender.m_BtnID2 > 0)
    {
      if (sender.m_BtnID2 > PetBuff.PetSkills.Count)
        return;
      this.RequestSkillUse(PetBuff.PetSkills[sender.m_BtnID2 - 1].Pet, (ushort) PetBuff.PetSkills[sender.m_BtnID2 - 1].ID, (ushort) 0, (byte) 0);
    }
    else if (sender.m_BtnID3 > 0)
      this.door.OpenMenu(EGUIWindow.UI_PetShield, sender.m_BtnID3);
    else
      this.door.CloseMenu();
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  protected enum SkillKind : byte
  {
  }
}
