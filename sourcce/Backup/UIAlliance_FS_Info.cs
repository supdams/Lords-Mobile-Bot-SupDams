// Decompiled with JetBrains decompiler
// Type: UIAlliance_FS_Info
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAlliance_FS_Info : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler
{
  private Transform GameT;
  private Transform Tmp;
  private ScrollPanelItem[] mSeroll_Item = new ScrollPanelItem[17];
  private RectTransform tmpRC;
  private RectTransform[] btn_IconRT_1 = new RectTransform[17];
  private RectTransform[] btn_IconRT_2 = new RectTransform[17];
  private UIButton btn_EXIT;
  private UIButton[] btn_Icon1 = new UIButton[17];
  private UIButton[] btn_Icon2 = new UIButton[17];
  private Image tmpImg;
  private Image Img_Hint;
  private Image[] Img_MainHeroShow1 = new Image[5];
  private Image[] Img_MainHeroShow_A = new Image[5];
  private Image[] Img_MainHeroShow2 = new Image[5];
  private Image[] Img_MainHeroShow_D = new Image[5];
  private UIText tmptext;
  private UIText text_Hint_1;
  private UIText text_Hint_2;
  private UIText[] text_tmpStr = new UIText[11];
  private CString[] Cstr_DS_Heros = new CString[5];
  private DataManager DM;
  private GUIManager GUIM;
  private AllianceWarManager AWM;
  private Font TTFont;
  private Door door;
  private UISpritesArray SArray;
  private Material mMaT;
  private Material IconMaterial;
  private Material FrameMaterial;
  private ScrollPanel m_ScrollPanel;
  private List<float> tmplist = new List<float>();
  private List<byte> tmplistInfo_Type = new List<byte>();
  private List<string> tmplistInfo_DataName = new List<string>();
  private List<uint> tmplistInfo_Data_L = new List<uint>();
  private List<uint> tmplistInfo_Data_H = new List<uint>();
  private List<uint> tmplistInfo_Data_D = new List<uint>();
  private List<uint> tmplistInfo_Data_ = new List<uint>();
  private List<byte> tmplistInfo_Data_Icon = new List<byte>();
  private Image[] Img_HeroBG = new Image[17];
  private Image[] Img_ItemTitleBG = new Image[17];
  private Image[] Img_ItemInfoBG = new Image[17];
  private Image[] Img_Icon_1 = new Image[17];
  private Image[] Img_Icon_2 = new Image[17];
  private Image[] Img_Name2_L = new Image[17];
  private Image[] Img_Name2_R = new Image[17];
  private Image[] Img_Data2_L = new Image[17];
  private Image[] Img_Data2_R = new Image[17];
  private Image[] Img_Hint1 = new Image[17];
  private Image[] Img_Hint2 = new Image[17];
  private UIText[] text_Top = new UIText[17];
  private UIText[] text_Title1 = new UIText[17];
  private UIText[] text_ATitleTroops = new UIText[17];
  private UIText[] text_ATitleTraps = new UIText[17];
  private UIText[] text_Title1_1 = new UIText[17];
  private UIText[] text_Title1_2 = new UIText[17];
  private UIText[] text_Title2 = new UIText[17];
  private UIText[] text_Title2_1 = new UIText[17];
  private UIText[] text_DTitleTroops = new UIText[17];
  private UIText[] text_DTitleTraps = new UIText[17];
  private UIText[] text_InfoName1 = new UIText[17];
  private UIText[] text_InfoName2 = new UIText[17];
  private UIText[] text_InfoName3 = new UIText[17];
  private UIText[] text_InfoName4 = new UIText[17];
  private UIText[] text_Troops_Name = new UIText[17];
  private UIText[] text_Item_L = new UIText[17];
  private UIText[] text_Item_H = new UIText[17];
  private UIText[] text_Item_D = new UIText[17];
  private UIText[] text_Icon_1 = new UIText[17];
  private UIText[] text_Icon_2 = new UIText[17];
  private UIText[] text_Title4_1 = new UIText[17];
  private UIText[] text_Title4_2 = new UIText[17];
  private UIText[] text_Name2_1 = new UIText[17];
  private UIText[] text_Name2_2 = new UIText[17];
  private UIText[] text_Name2_3 = new UIText[17];
  private UIText[] text_Name2_4 = new UIText[17];
  private UIText[] text_Name2_5 = new UIText[17];
  private UIText[] text_Data2_1 = new UIText[17];
  private UIText[] text_Data2_2 = new UIText[17];
  private UIText[] text_Data2_3 = new UIText[17];
  private UIText[] text_Data2_4 = new UIText[17];
  private UIText[] text_Data2_5 = new UIText[17];
  private string[] ItemInfo = new string[4];
  private CString[] Cstr_PlayName = new CString[2];
  private CString[] Cstr_Title = new CString[2];
  private CString[] Cstr_Title4 = new CString[2];
  private CString[] Cstr_tmpItem1 = new CString[17];
  private CString[] Cstr_tmpItem2 = new CString[17];
  private CString[] Cstr_tmpItem3 = new CString[17];
  private CString[] Cstr_tmpItem4 = new CString[17];
  private CString Cstr_Hint;
  private ushort[] mHeroID_A = new ushort[5];
  private byte[] mHeroRank_A = new byte[5];
  private byte[] mHeroStar_A = new byte[5];
  private ushort[] mHeroID_D = new ushort[5];
  private byte[] mHeroRank_D = new byte[5];
  private byte[] mHeroStar_D = new byte[5];
  private float tmpH;
  private float ShowMainHeroTime1;
  private float ShowMainHeroTime2;
  private bool IsAttack;
  private Hero tmpHero;
  private SoldierData tmpSD;
  private GameObject[] mHead = new GameObject[5];
  private byte tmpA;
  private UIButtonHint hint;
  private UIButtonHint[] m_ItembtnHint = new UIButtonHint[17];
  private UIButtonHint[] m_ItembtnHint2 = new UIButtonHint[17];

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.AWM = ActivityManager.Instance.AllianceWarMgr;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.mMaT = this.door.LoadMaterial();
    this.IconMaterial = this.GUIM.m_IconSpriteAsset.GetMaterial();
    this.FrameMaterial = this.GUIM.GetFrameMaterial();
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    for (int index = 0; index < 2; ++index)
      this.ItemInfo[index] = this.DM.mStringTable.GetStringByID((uint) (ushort) (5343 + index));
    for (int index = 2; index < 4; ++index)
      this.ItemInfo[index] = this.DM.mStringTable.GetStringByID((uint) (ushort) (6088 + index));
    for (int index = 0; index < 17; ++index)
    {
      this.Cstr_tmpItem1[index] = StringManager.Instance.SpawnString();
      this.Cstr_tmpItem2[index] = StringManager.Instance.SpawnString();
      this.Cstr_tmpItem3[index] = StringManager.Instance.SpawnString();
      this.Cstr_tmpItem4[index] = StringManager.Instance.SpawnString();
    }
    for (int index = 0; index < 2; ++index)
    {
      this.Cstr_PlayName[index] = StringManager.Instance.SpawnString();
      this.Cstr_Title[index] = StringManager.Instance.SpawnString();
      this.Cstr_Title4[index] = StringManager.Instance.SpawnString();
    }
    this.Cstr_Hint = StringManager.Instance.SpawnString(100);
    this.Cstr_PlayName[0].ClearString();
    this.Cstr_PlayName[0].Append(this.DM.RoleAttr.Name);
    CString SpriteName = StringManager.Instance.StaticString1024();
    for (int index = 0; index < 5; ++index)
      this.Cstr_DS_Heros[index] = StringManager.Instance.SpawnString();
    for (int index = 0; index < 5; ++index)
      this.mHead[index] = (GameObject) null;
    this.Tmp = this.GameT.GetChild(4);
    this.Img_Hint = this.Tmp.GetComponent<Image>();
    this.Tmp = this.GameT.GetChild(4).GetChild(0);
    this.text_Hint_1 = this.Tmp.GetComponent<UIText>();
    this.text_Hint_1.font = this.TTFont;
    this.Tmp = this.GameT.GetChild(4).GetChild(1);
    this.text_Hint_2 = this.Tmp.GetComponent<UIText>();
    this.text_Hint_2.font = this.TTFont;
    this.Tmp = this.GameT.GetChild(1);
    this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
    Transform child = this.GameT.GetChild(2);
    this.tmptext = child.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmpImg = child.GetChild(0).GetChild(1).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_EO_icon_01");
    ((MaskableGraphic) this.tmpImg).material = this.mMaT;
    this.hint = ((Component) this.tmpImg).gameObject.AddComponent<UIButtonHint>();
    this.hint.m_eHint = EUIButtonHint.CountDown;
    this.hint.DelayTime = 0.2f;
    this.hint.m_Handler = (MonoBehaviour) this;
    this.hint.Parm1 = (ushort) 3;
    for (int index = 0; index < 5; ++index)
    {
      this.text_tmpStr[0 + index] = child.GetChild(1).GetChild(index).GetComponent<UIText>();
      this.text_tmpStr[0 + index].font = this.TTFont;
      if (index == 1)
        this.text_tmpStr[0 + index].text = this.DM.mStringTable.GetStringByID(5339U);
      else if (index == 2)
        this.text_tmpStr[0 + index].text = this.DM.mStringTable.GetStringByID(5340U);
    }
    this.tmptext = child.GetChild(2).GetChild(0).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext = child.GetChild(2).GetChild(1).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext.text = this.DM.mStringTable.GetStringByID(12086U);
    this.tmptext = child.GetChild(2).GetChild(2).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.text_tmpStr[5] = child.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[5].font = this.TTFont;
    this.tmpImg = child.GetChild(3).GetChild(1).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_EO_icon_02");
    ((MaskableGraphic) this.tmpImg).material = this.mMaT;
    this.hint = ((Component) this.tmpImg).gameObject.AddComponent<UIButtonHint>();
    this.hint.m_eHint = EUIButtonHint.CountDown;
    this.hint.DelayTime = 0.2f;
    this.hint.m_Handler = (MonoBehaviour) this;
    this.hint.Parm1 = (ushort) 4;
    for (int index = 0; index < 5; ++index)
    {
      this.Tmp = child.GetChild(4).GetChild(index).GetChild(0);
      this.tmpImg = this.Tmp.GetComponent<Image>();
      ((MaskableGraphic) this.tmpImg).material = this.IconMaterial;
      this.tmpRC = this.Tmp.GetComponent<RectTransform>();
      this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
      this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
      this.tmpRC.offsetMin = Vector2.zero;
      this.tmpRC.offsetMax = Vector2.zero;
      this.Tmp = child.GetChild(4).GetChild(index).GetChild(1);
      this.tmpImg = this.Tmp.GetComponent<Image>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("hf000");
      this.tmpImg.sprite = this.GUIM.LoadFrameSprite(SpriteName);
      ((MaskableGraphic) this.tmpImg).material = this.FrameMaterial;
      this.tmpRC = this.Tmp.GetComponent<RectTransform>();
      this.tmpRC.anchorMin = Vector2.zero;
      this.tmpRC.anchorMax = new Vector2(1f, 1f);
      this.tmpRC.offsetMin = Vector2.zero;
      this.tmpRC.offsetMax = Vector2.zero;
      this.Tmp = child.GetChild(4).GetChild(index).GetChild(2);
      this.tmpImg = this.Tmp.GetComponent<Image>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("hf101");
      this.tmpImg.sprite = this.GUIM.LoadFrameSprite(SpriteName);
      ((MaskableGraphic) this.tmpImg).material = this.FrameMaterial;
      this.tmpImg = child.GetChild(4).GetChild(index).GetChild(3).GetComponent<Image>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_legion_icon_12");
      this.tmpImg.sprite = this.GUIM.LoadFrameSprite(SpriteName);
      ((MaskableGraphic) this.tmpImg).material = this.FrameMaterial;
      this.tmpImg = child.GetChild(4).GetChild(index).GetChild(3).GetChild(0).GetComponent<Image>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_legion_icon_13");
      this.tmpImg.sprite = this.GUIM.LoadFrameSprite(SpriteName);
      ((MaskableGraphic) this.tmpImg).material = this.FrameMaterial;
    }
    for (int index = 0; index < 4; ++index)
    {
      this.text_tmpStr[6 + index] = child.GetChild(5).GetChild(index).GetComponent<UIText>();
      this.text_tmpStr[6 + index].font = this.TTFont;
      if (index < 2)
        this.text_tmpStr[6 + index].text = this.DM.mStringTable.GetStringByID((uint) (5341 + index));
    }
    for (int index = 0; index < 4; ++index)
    {
      this.tmptext = child.GetChild(6).GetChild(index).GetComponent<UIText>();
      this.tmptext.font = this.TTFont;
    }
    UIButton component1 = child.GetChild(6).GetChild(4).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 1;
    this.hint = ((Component) component1).gameObject.AddComponent<UIButtonHint>();
    this.hint.m_eHint = EUIButtonHint.DownUpHandler;
    this.hint.m_Handler = (MonoBehaviour) this;
    this.tmptext = child.GetChild(6).GetChild(4).GetChild(1).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext = child.GetChild(7).GetChild(0).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext = child.GetChild(7).GetChild(1).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext = child.GetChild(8).GetChild(2).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext.text = this.DM.mStringTable.GetStringByID(5341U);
    this.tmptext = child.GetChild(8).GetChild(3).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext.text = this.DM.mStringTable.GetStringByID(4919U);
    this.tmptext = child.GetChild(8).GetChild(4).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext.text = this.DM.mStringTable.GetStringByID(5321U);
    this.tmptext = child.GetChild(8).GetChild(5).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext.text = this.DM.mStringTable.GetStringByID(4919U);
    this.tmptext = child.GetChild(8).GetChild(6).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext.text = this.DM.mStringTable.GetStringByID(5321U);
    this.tmptext = child.GetChild(9).GetChild(2).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext = child.GetChild(9).GetChild(3).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext = child.GetChild(9).GetChild(4).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext = child.GetChild(9).GetChild(5).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext = child.GetChild(9).GetChild(6).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    UIButton component2 = child.GetChild(9).GetChild(7).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 1;
    this.hint = ((Component) component2).gameObject.AddComponent<UIButtonHint>();
    this.hint.m_eHint = EUIButtonHint.DownUpHandler;
    this.hint.m_Handler = (MonoBehaviour) this;
    this.tmptext = child.GetChild(9).GetChild(7).GetChild(1).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmplist.Clear();
    this.SetFsData();
    this.m_ScrollPanel.IntiScrollPanel(505f, 4f, 0.0f, this.tmplist, 17, (IUpDateScrollPanel) this);
    this.text_tmpStr[10] = this.GameT.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[10].font = this.TTFont;
    this.text_tmpStr[10].text = this.DM.mStringTable.GetStringByID(5396U);
    UIButtonHint.scrollRect = this.m_ScrollPanel.transform.GetComponent<CScrollRect>();
    this.Tmp = this.GameT.GetChild(5);
    this.tmpImg = this.Tmp.GetComponent<Image>();
    SpriteName.ClearString();
    SpriteName.AppendFormat("UI_main_close_base");
    this.tmpImg.sprite = this.door.LoadSprite(SpriteName);
    ((MaskableGraphic) this.tmpImg).material = this.mMaT;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.tmpImg).enabled = false;
    this.Tmp = this.GameT.GetChild(5).GetChild(0);
    this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
    SpriteName.ClearString();
    SpriteName.AppendFormat("UI_main_close");
    this.btn_EXIT.image.sprite = this.door.LoadSprite(SpriteName);
    ((MaskableGraphic) this.btn_EXIT.image).material = this.mMaT;
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public void SetFsData(bool bopen = true)
  {
    uint num1 = 0;
    uint num2 = 0;
    for (int index = 0; index < 16; ++index)
    {
      this.DM.mFs_A_ST[index] = 0U;
      this.DM.mFs_A_SL[index] = 0U;
      this.DM.mFs_D_ST[index] = 0U;
      this.DM.mFs_D_SL[index] = 0U;
      this.DM.mFs_A_ST[index] += this.AWM.m_CombatPlayerData[0].SurviveTroop[index] + this.AWM.m_CombatPlayerData[0].DeadTroop[index];
      this.DM.mFs_A_SL[index] += this.AWM.m_CombatPlayerData[0].DeadTroop[index];
      num1 += this.DM.mFs_A_SL[index];
      this.DM.mFs_D_ST[index] += this.AWM.m_CombatPlayerData[1].SurviveTroop[index] + this.AWM.m_CombatPlayerData[1].DeadTroop[index];
      this.DM.mFs_D_SL[index] += this.AWM.m_CombatPlayerData[1].DeadTroop[index];
      num2 += this.DM.mFs_D_SL[index];
    }
    this.tmplist.Clear();
    this.tmplistInfo_Type.Clear();
    this.tmplistInfo_DataName.Clear();
    this.tmplistInfo_Data_L.Clear();
    this.tmplistInfo_Data_H.Clear();
    this.tmplistInfo_Data_D.Clear();
    this.tmplistInfo_Data_.Clear();
    this.tmplistInfo_Data_Icon.Clear();
    this.IsAttack = this.AWM.MyAllySide == (byte) 1;
    this.tmplistInfo_Type.Add((byte) 0);
    this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID(12073U));
    this.tmplistInfo_Data_L.Add(0U);
    this.tmplistInfo_Data_H.Add(0U);
    this.tmplistInfo_Data_D.Add(0U);
    this.tmplistInfo_Data_.Add(0U);
    this.tmplistInfo_Data_Icon.Add((byte) 0);
    this.tmplist.Add(44f);
    this.tmplistInfo_Type.Add((byte) 11);
    this.tmplistInfo_DataName.Add("P_Title4");
    this.Cstr_Title4[0].ClearString();
    if (this.IsAttack)
      this.Cstr_Title4[0].Append(this.DM.mStringTable.GetStringByID(11163U));
    else
      this.Cstr_Title4[0].Append(this.DM.mStringTable.GetStringByID(11164U));
    this.Cstr_Title4[1].ClearString();
    if (!this.IsAttack)
      this.Cstr_Title4[1].Append(this.DM.mStringTable.GetStringByID(11163U));
    else
      this.Cstr_Title4[1].Append(this.DM.mStringTable.GetStringByID(11164U));
    this.tmplistInfo_Data_L.Add(0U);
    this.tmplistInfo_Data_H.Add(0U);
    this.tmplistInfo_Data_D.Add(0U);
    this.tmplistInfo_Data_.Add(0U);
    this.tmplistInfo_Data_Icon.Add((byte) 0);
    this.tmplist.Add(41f);
    this.tmplistInfo_Type.Add((byte) 12);
    this.tmplistInfo_DataName.Add("P_Name2");
    this.tmplistInfo_Data_L.Add(0U);
    this.tmplistInfo_Data_H.Add(0U);
    this.tmplistInfo_Data_D.Add(0U);
    this.tmplistInfo_Data_.Add(0U);
    this.tmplistInfo_Data_Icon.Add((byte) 0);
    this.tmplist.Add(38f);
    this.tmpA = (byte) 0;
    for (int index1 = 0; index1 < 16; ++index1)
    {
      int index2 = 3 - index1 / 4 + index1 % 4 * 4;
      if (this.DM.mFs_A_ST[index2] > 0U || this.DM.mFs_D_ST[index2] > 0U)
      {
        this.tmplistInfo_Type.Add((byte) 13);
        this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index2 + 1));
        this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name));
        this.tmplistInfo_Data_L.Add(this.DM.mFs_A_ST[index2]);
        this.tmplistInfo_Data_H.Add(this.DM.mFs_A_SL[index2]);
        this.tmplistInfo_Data_D.Add(this.DM.mFs_D_ST[index2]);
        this.tmplistInfo_Data_.Add(this.DM.mFs_D_SL[index2]);
        this.tmplistInfo_Data_Icon.Add((byte) index2);
        this.tmplist.Add(35f);
        ++this.tmpA;
      }
    }
    if (this.tmpA > (byte) 0)
    {
      this.tmplist.RemoveAt(this.tmplist.Count - 1);
      this.tmplist.Add(45f);
    }
    else
    {
      this.tmplistInfo_Type.Add((byte) 9);
      this.tmplistInfo_DataName.Add("-");
      this.tmplistInfo_Data_L.Add(0U);
      this.tmplistInfo_Data_H.Add(0U);
      this.tmplistInfo_Data_D.Add(0U);
      this.tmplistInfo_Data_.Add(0U);
      this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
      this.tmplist.Add(45f);
    }
    this.tmplistInfo_Type.Add((byte) 0);
    this.Cstr_Title[0].ClearString();
    if (this.IsAttack)
      this.Cstr_Title[0].Append(this.DM.mStringTable.GetStringByID(11163U));
    else
      this.Cstr_Title[0].Append(this.DM.mStringTable.GetStringByID(11164U));
    this.tmplistInfo_DataName.Add(this.Cstr_Title[0].ToString());
    this.tmplistInfo_Data_L.Add(0U);
    this.tmplistInfo_Data_H.Add(0U);
    this.tmplistInfo_Data_D.Add(0U);
    this.tmplistInfo_Data_.Add(0U);
    this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
    this.tmplist.Add(44f);
    this.tmplistInfo_Type.Add((byte) 3);
    if (this.IsAttack)
      this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID(5338U));
    else
      this.tmplistInfo_DataName.Add(this.AWM.m_CombatPlayerData[0].Name);
    this.tmplistInfo_Data_L.Add(num2);
    this.tmplistInfo_Data_H.Add(0U);
    this.tmplistInfo_Data_D.Add(0U);
    this.tmplistInfo_Data_.Add(0U);
    this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
    this.tmplist.Add(59f);
    if (this.AWM.m_CombatPlayerData[0].HeroInfo[0].ID > (ushort) 0)
    {
      this.tmplistInfo_Type.Add((byte) 7);
      this.tmplistInfo_DataName.Add(string.Empty);
      this.tmplistInfo_Data_L.Add(0U);
      this.tmplistInfo_Data_H.Add(0U);
      this.tmplistInfo_Data_D.Add(0U);
      this.tmplistInfo_Data_.Add(0U);
      this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
      for (int index = 0; index < this.AWM.m_CombatPlayerData[0].HeroInfo.Length; ++index)
      {
        this.mHeroID_A[index] = this.AWM.m_CombatPlayerData[0].HeroInfo[index].ID;
        this.mHeroRank_A[index] = this.AWM.m_CombatPlayerData[0].HeroInfo[index].Rank;
        this.mHeroStar_A[index] = this.AWM.m_CombatPlayerData[0].HeroInfo[index].Star;
      }
      this.tmplist.Add(96f);
    }
    this.tmplistInfo_Type.Add((byte) 5);
    this.tmplistInfo_DataName.Add(string.Empty);
    this.tmplistInfo_Data_L.Add(1U);
    this.tmplistInfo_Data_H.Add(0U);
    this.tmplistInfo_Data_D.Add(0U);
    this.tmplistInfo_Data_.Add(0U);
    this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
    this.tmplist.Add(38f);
    this.tmpA = (byte) 0;
    for (int index3 = 0; index3 < 16; ++index3)
    {
      int index4 = 3 - index3 / 4 + index3 % 4 * 4;
      if (this.AWM.m_CombatPlayerData[0].SurviveTroop[index4] > 0U || this.AWM.m_CombatPlayerData[0].DeadTroop[index4] > 0U)
      {
        ++this.tmpA;
        this.tmplistInfo_Type.Add((byte) 9);
        this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index4 + 1));
        this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name));
        this.tmplistInfo_Data_L.Add(this.AWM.m_CombatPlayerData[0].SurviveTroop[index4]);
        this.tmplistInfo_Data_H.Add(0U);
        this.tmplistInfo_Data_D.Add(this.AWM.m_CombatPlayerData[0].DeadTroop[index4]);
        this.tmplistInfo_Data_.Add(0U);
        this.tmplistInfo_Data_Icon.Add((byte) index4);
        this.tmplist.Add(35f);
      }
    }
    if (this.tmpA > (byte) 0)
    {
      this.tmplist.RemoveAt(this.tmplist.Count - 1);
      this.tmplist.Add(45f);
    }
    else
    {
      this.tmplistInfo_Type.Add((byte) 9);
      this.tmplistInfo_DataName.Add("-");
      this.tmplistInfo_Data_L.Add(0U);
      this.tmplistInfo_Data_H.Add(0U);
      this.tmplistInfo_Data_D.Add(0U);
      this.tmplistInfo_Data_.Add(0U);
      this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
      this.tmplist.Add(45f);
    }
    this.tmplistInfo_Type.Add((byte) 1);
    this.Cstr_Title[1].ClearString();
    if (!this.IsAttack)
      this.Cstr_Title[1].Append(this.DM.mStringTable.GetStringByID(11163U));
    else
      this.Cstr_Title[1].Append(this.DM.mStringTable.GetStringByID(11164U));
    this.tmplistInfo_DataName.Add(this.Cstr_Title[1].ToString());
    this.tmplistInfo_Data_L.Add(0U);
    this.tmplistInfo_Data_H.Add(0U);
    this.tmplistInfo_Data_D.Add(0U);
    this.tmplistInfo_Data_.Add(0U);
    this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
    this.tmplist.Add(44f);
    this.tmplistInfo_Type.Add((byte) 3);
    if (!this.IsAttack)
      this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID(5338U));
    else
      this.tmplistInfo_DataName.Add(this.AWM.m_CombatPlayerData[1].Name);
    this.tmplistInfo_Data_L.Add(num1);
    this.tmplistInfo_Data_H.Add(0U);
    this.tmplistInfo_Data_D.Add(0U);
    this.tmplistInfo_Data_.Add(0U);
    this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
    this.tmplist.Add(59f);
    if (this.AWM.m_CombatPlayerData[1].HeroInfo[0].ID > (ushort) 0)
    {
      this.tmplistInfo_Type.Add((byte) 8);
      this.tmplistInfo_DataName.Add(string.Empty);
      this.tmplistInfo_Data_L.Add(1U);
      this.tmplistInfo_Data_H.Add(0U);
      this.tmplistInfo_Data_D.Add(0U);
      this.tmplistInfo_Data_.Add(0U);
      this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
      for (int index = 0; index < this.AWM.m_CombatPlayerData[1].HeroInfo.Length; ++index)
      {
        this.mHeroID_D[index] = this.AWM.m_CombatPlayerData[1].HeroInfo[index].ID;
        this.mHeroRank_D[index] = this.AWM.m_CombatPlayerData[1].HeroInfo[index].Rank;
        this.mHeroStar_D[index] = this.AWM.m_CombatPlayerData[1].HeroInfo[index].Star;
      }
      this.tmplist.Add(96f);
    }
    this.tmplistInfo_Type.Add((byte) 6);
    this.tmplistInfo_DataName.Add(string.Empty);
    this.tmplistInfo_Data_L.Add(1U);
    this.tmplistInfo_Data_H.Add(0U);
    this.tmplistInfo_Data_D.Add(0U);
    this.tmplistInfo_Data_.Add(0U);
    this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
    this.tmplist.Add(38f);
    this.tmpA = (byte) 0;
    for (int index5 = 0; index5 < 16; ++index5)
    {
      int index6 = 3 - index5 / 4 + index5 % 4 * 4;
      if (this.AWM.m_CombatPlayerData[1].SurviveTroop[index6] > 0U || this.AWM.m_CombatPlayerData[1].DeadTroop[index6] > 0U)
      {
        ++this.tmpA;
        this.tmplistInfo_Type.Add((byte) 10);
        this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index6 + 1));
        this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name));
        this.tmplistInfo_Data_L.Add(this.AWM.m_CombatPlayerData[1].SurviveTroop[index6]);
        this.tmplistInfo_Data_H.Add(0U);
        this.tmplistInfo_Data_D.Add(this.AWM.m_CombatPlayerData[1].DeadTroop[index6]);
        this.tmplistInfo_Data_.Add(0U);
        this.tmplistInfo_Data_Icon.Add((byte) index6);
        this.tmplist.Add(35f);
      }
    }
    if (this.tmpA > (byte) 0)
    {
      this.tmplist.RemoveAt(this.tmplist.Count - 1);
      this.tmplist.Add(45f);
    }
    else
    {
      this.tmplistInfo_Type.Add((byte) 10);
      this.tmplistInfo_DataName.Add("-");
      this.tmplistInfo_Data_L.Add(0U);
      this.tmplistInfo_Data_H.Add(0U);
      this.tmplistInfo_Data_D.Add(0U);
      this.tmplistInfo_Data_.Add(0U);
      this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
      this.tmplist.Add(45f);
    }
    if (bopen)
      return;
    this.m_ScrollPanel.AddNewDataHeight(this.tmplist);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((Object) this.mSeroll_Item[panelObjectIdx] == (Object) null)
    {
      this.mSeroll_Item[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      this.text_Top[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(0).GetChild(0).GetComponent<UIText>();
      this.Img_Hint1[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(0).GetChild(1).GetComponent<Image>();
      this.hint = ((Component) this.Img_Hint1[panelObjectIdx]).gameObject.GetComponent<UIButtonHint>();
      this.hint.m_eHint = EUIButtonHint.CountDown;
      this.hint.DelayTime = 0.2f;
      this.hint.m_Handler = (MonoBehaviour) this;
      this.hint.Parm1 = (ushort) 3;
      this.text_Title1[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(1).GetChild(0).GetComponent<UIText>();
      this.text_Title1_1[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(1).GetChild(1).GetComponent<UIText>();
      this.text_Title1_2[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(1).GetChild(2).GetComponent<UIText>();
      this.text_ATitleTroops[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(1).GetChild(3).GetComponent<UIText>();
      this.text_ATitleTraps[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(1).GetChild(4).GetComponent<UIText>();
      this.text_Title2[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(2).GetChild(0).GetComponent<UIText>();
      this.text_Title2_1[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(2).GetChild(1).GetComponent<UIText>();
      this.text_DTitleTroops[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(2).GetChild(2).GetComponent<UIText>();
      this.text_DTitleTraps[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(3).GetChild(0).GetComponent<UIText>();
      this.Img_Hint2[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(3).GetChild(1).GetComponent<Image>();
      this.hint = ((Component) this.Img_Hint2[panelObjectIdx]).gameObject.GetComponent<UIButtonHint>();
      this.hint.m_eHint = EUIButtonHint.CountDown;
      this.hint.DelayTime = 0.2f;
      this.hint.m_Handler = (MonoBehaviour) this;
      this.hint.Parm1 = (ushort) 4;
      this.Img_HeroBG[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(4).GetComponent<Image>();
      this.Img_ItemTitleBG[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(5).GetComponent<Image>();
      this.text_InfoName3[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(5).GetChild(0).GetComponent<UIText>();
      this.text_InfoName4[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(5).GetChild(1).GetComponent<UIText>();
      this.text_InfoName1[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(5).GetChild(2).GetComponent<UIText>();
      this.text_InfoName2[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(5).GetChild(3).GetComponent<UIText>();
      this.Img_ItemInfoBG[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(6).GetComponent<Image>();
      this.text_Troops_Name[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(6).GetChild(0).GetComponent<UIText>();
      this.text_Item_L[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(6).GetChild(1).GetComponent<UIText>();
      this.text_Item_H[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(6).GetChild(2).GetComponent<UIText>();
      this.text_Item_D[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(6).GetChild(3).GetComponent<UIText>();
      this.btn_Icon1[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(6).GetChild(4).GetComponent<UIButton>();
      this.btn_Icon1[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.m_ItembtnHint[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(6).GetChild(4).GetComponent<UIButtonHint>();
      this.m_ItembtnHint[panelObjectIdx].m_eHint = EUIButtonHint.CountDown;
      this.m_ItembtnHint[panelObjectIdx].DelayTime = 0.2f;
      this.m_ItembtnHint[panelObjectIdx].m_DownUpHandler = (IUIButtonDownUpHandler) this;
      this.m_ItembtnHint[panelObjectIdx].ControlFadeOut = ((Component) this.Img_Hint).gameObject;
      this.m_ItembtnHint[panelObjectIdx].Parm1 = (ushort) 1;
      this.btn_IconRT_1[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(6).GetChild(4).GetComponent<RectTransform>();
      this.Img_Icon_1[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(6).GetChild(4).GetChild(0).GetComponent<Image>();
      this.text_Icon_1[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(6).GetChild(4).GetChild(1).GetComponent<UIText>();
      this.text_Title4_1[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(7).GetChild(0).GetComponent<UIText>();
      this.text_Title4_2[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(7).GetChild(1).GetComponent<UIText>();
      this.Img_Name2_L[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(8).GetChild(0).GetComponent<Image>();
      this.Img_Name2_R[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(8).GetChild(1).GetComponent<Image>();
      this.text_Name2_1[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(8).GetChild(2).GetComponent<UIText>();
      this.text_Name2_2[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(8).GetChild(3).GetComponent<UIText>();
      this.text_Name2_3[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(8).GetChild(4).GetComponent<UIText>();
      this.text_Name2_4[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(8).GetChild(5).GetComponent<UIText>();
      this.text_Name2_5[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(8).GetChild(6).GetComponent<UIText>();
      this.Img_Data2_L[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(9).GetChild(0).GetComponent<Image>();
      this.Img_Data2_R[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(9).GetChild(1).GetComponent<Image>();
      this.text_Data2_1[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(9).GetChild(2).GetComponent<UIText>();
      this.text_Data2_2[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(9).GetChild(3).GetComponent<UIText>();
      this.text_Data2_3[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(9).GetChild(4).GetComponent<UIText>();
      this.text_Data2_4[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(9).GetChild(5).GetComponent<UIText>();
      this.text_Data2_5[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(9).GetChild(6).GetComponent<UIText>();
      this.btn_Icon2[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(9).GetChild(7).GetComponent<UIButton>();
      this.btn_Icon2[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.m_ItembtnHint2[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(9).GetChild(7).GetComponent<UIButtonHint>();
      this.m_ItembtnHint2[panelObjectIdx].m_DownUpHandler = (IUIButtonDownUpHandler) this;
      this.m_ItembtnHint2[panelObjectIdx].m_eHint = EUIButtonHint.CountDown;
      this.m_ItembtnHint2[panelObjectIdx].DelayTime = 0.2f;
      this.m_ItembtnHint2[panelObjectIdx].ControlFadeOut = ((Component) this.Img_Hint).gameObject;
      this.m_ItembtnHint2[panelObjectIdx].Parm1 = (ushort) 2;
      this.btn_IconRT_2[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(9).GetChild(7).GetComponent<RectTransform>();
      this.Img_Icon_2[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(9).GetChild(7).GetChild(0).GetComponent<Image>();
      this.text_Icon_2[panelObjectIdx] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(9).GetChild(7).GetChild(1).GetComponent<UIText>();
    }
    int num = this.mSeroll_Item[panelObjectIdx].m_BtnID2;
    if (num != 0)
      ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).gameObject.SetActive(false);
    switch (this.tmplistInfo_Type[dataIdx])
    {
      case 0:
      case 1:
        this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 1;
        num = 1;
        this.text_Top[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
        this.text_Top[panelObjectIdx].SetAllDirty();
        this.text_Top[panelObjectIdx].cachedTextGenerator.Invalidate();
        if (this.tmplistInfo_Data_Icon[dataIdx] < byte.MaxValue)
        {
          ((Component) this.Img_Hint1[panelObjectIdx]).gameObject.SetActive(true);
          break;
        }
        ((Component) this.Img_Hint1[panelObjectIdx]).gameObject.SetActive(false);
        break;
      case 2:
        this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 2;
        num = 2;
        this.text_Title1[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
        this.text_Title1[panelObjectIdx].SetAllDirty();
        this.text_Title1[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.Cstr_tmpItem1[panelObjectIdx].ClearString();
        this.Cstr_tmpItem1[panelObjectIdx].IntToFormat((long) this.tmplistInfo_Data_L[dataIdx], bNumber: true);
        this.Cstr_tmpItem1[panelObjectIdx].AppendFormat("{0}");
        this.text_ATitleTroops[panelObjectIdx].text = this.Cstr_tmpItem1[panelObjectIdx].ToString();
        this.text_ATitleTroops[panelObjectIdx].SetAllDirty();
        this.text_ATitleTroops[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.Cstr_tmpItem2[panelObjectIdx].ClearString();
        this.Cstr_tmpItem2[panelObjectIdx].IntToFormat((long) this.tmplistInfo_Data_H[dataIdx], bNumber: true);
        this.Cstr_tmpItem2[panelObjectIdx].AppendFormat("{0}");
        this.text_ATitleTraps[panelObjectIdx].text = this.Cstr_tmpItem2[panelObjectIdx].ToString();
        this.text_ATitleTraps[panelObjectIdx].SetAllDirty();
        this.text_ATitleTraps[panelObjectIdx].cachedTextGenerator.Invalidate();
        break;
      case 3:
        this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 3;
        num = 3;
        this.text_Title2[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
        this.text_Title2[panelObjectIdx].SetAllDirty();
        this.text_Title2[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.Cstr_tmpItem1[panelObjectIdx].ClearString();
        this.Cstr_tmpItem1[panelObjectIdx].IntToFormat((long) this.tmplistInfo_Data_L[dataIdx], bNumber: true);
        this.Cstr_tmpItem1[panelObjectIdx].AppendFormat("{0}");
        this.text_DTitleTroops[panelObjectIdx].text = this.Cstr_tmpItem1[panelObjectIdx].ToString();
        this.text_DTitleTroops[panelObjectIdx].SetAllDirty();
        this.text_DTitleTroops[panelObjectIdx].cachedTextGenerator.Invalidate();
        break;
      case 4:
        this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 4;
        num = 4;
        this.text_DTitleTraps[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
        this.text_DTitleTraps[panelObjectIdx].SetAllDirty();
        this.text_DTitleTraps[panelObjectIdx].cachedTextGenerator.Invalidate();
        if (this.tmplistInfo_Data_Icon[dataIdx] < byte.MaxValue)
        {
          ((Component) this.Img_Hint2[panelObjectIdx]).gameObject.SetActive(true);
          break;
        }
        ((Component) this.Img_Hint2[panelObjectIdx]).gameObject.SetActive(false);
        break;
      case 5:
        this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 6;
        num = 6;
        this.text_InfoName1[panelObjectIdx].text = this.ItemInfo[0];
        this.text_InfoName1[panelObjectIdx].SetAllDirty();
        this.text_InfoName1[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.text_InfoName2[panelObjectIdx].text = this.ItemInfo[1];
        this.text_InfoName2[panelObjectIdx].SetAllDirty();
        this.text_InfoName2[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.Img_ItemTitleBG[panelObjectIdx].sprite = !this.IsAttack ? this.SArray.m_Sprites[3] : this.SArray.m_Sprites[2];
        break;
      case 6:
        this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 6;
        num = 6;
        if (this.tmplistInfo_Data_L[dataIdx] == 1U)
        {
          this.text_InfoName1[panelObjectIdx].text = this.ItemInfo[0];
          this.text_InfoName2[panelObjectIdx].text = this.ItemInfo[1];
        }
        else
        {
          this.text_InfoName1[panelObjectIdx].text = this.ItemInfo[2];
          this.text_InfoName2[panelObjectIdx].text = this.ItemInfo[3];
        }
        this.text_InfoName1[panelObjectIdx].SetAllDirty();
        this.text_InfoName1[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.text_InfoName2[panelObjectIdx].SetAllDirty();
        this.text_InfoName2[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.Img_ItemTitleBG[panelObjectIdx].sprite = this.IsAttack ? this.SArray.m_Sprites[3] : this.SArray.m_Sprites[2];
        break;
      case 7:
        this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 5;
        num = 5;
        this.Img_HeroBG[panelObjectIdx].sprite = !this.IsAttack ? this.SArray.m_Sprites[1] : this.SArray.m_Sprites[0];
        if (this.AWM.m_CombatPlayerData[0].bMain)
        {
          this.Img_MainHeroShow1[0] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetChild(0).GetChild(3).GetComponent<Image>();
          ((Component) this.Img_MainHeroShow1[0]).gameObject.SetActive(true);
          this.Img_MainHeroShow_A[0] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetChild(0).GetChild(3).GetChild(0).GetComponent<Image>();
          this.ShowMainHeroTime1 = 0.0f;
        }
        else
        {
          for (int index = 0; index < 5; ++index)
          {
            if ((Object) this.Img_MainHeroShow1[index] != (Object) null)
              ((Component) this.Img_MainHeroShow1[index]).gameObject.SetActive(false);
          }
        }
        for (int index = 0; index < this.AWM.m_CombatPlayerData[0].HeroInfo.Length; ++index)
        {
          if (this.AWM.m_CombatPlayerData[0].HeroInfo[index].ID > (ushort) 0)
            ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetChild(index).gameObject.SetActive(true);
          else
            ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetChild(index).gameObject.SetActive(false);
          this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.mHeroID_A[index]);
          this.tmpImg = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetChild(index).GetChild(0).GetComponent<Image>();
          this.tmpImg.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
          if (((Component) this.tmpImg).transform.childCount != 0)
            ((Component) this.tmpImg).transform.GetChild(0).gameObject.SetActive(false);
          this.tmpImg = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetChild(index).GetChild(1).GetComponent<Image>();
          this.Cstr_DS_Heros[index].ClearString();
          this.Cstr_DS_Heros[index].IntToFormat((long) this.mHeroStar_A[index]);
          this.Cstr_DS_Heros[index].AppendFormat("hf00{0}");
          this.tmpImg.sprite = this.GUIM.LoadFrameSprite(this.Cstr_DS_Heros[index]);
          this.tmpImg = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetChild(index).GetChild(2).GetComponent<Image>();
          this.Cstr_DS_Heros[index].ClearString();
          this.Cstr_DS_Heros[index].IntToFormat((long) this.mHeroRank_A[index]);
          this.Cstr_DS_Heros[index].AppendFormat("hf10{0}");
          this.tmpImg.sprite = this.GUIM.LoadFrameSprite(this.Cstr_DS_Heros[index]);
        }
        break;
      case 8:
        this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 5;
        num = 5;
        this.Img_HeroBG[panelObjectIdx].sprite = this.IsAttack ? this.SArray.m_Sprites[1] : this.SArray.m_Sprites[0];
        if (this.AWM.m_CombatPlayerData[1].bMain)
        {
          this.Img_MainHeroShow2[0] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetChild(0).GetChild(3).GetComponent<Image>();
          ((Component) this.Img_MainHeroShow2[0]).gameObject.SetActive(true);
          this.Img_MainHeroShow_D[0] = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetChild(0).GetChild(3).GetChild(0).GetComponent<Image>();
          this.ShowMainHeroTime2 = 0.0f;
        }
        else
        {
          for (int index = 0; index < 5; ++index)
          {
            if ((Object) this.Img_MainHeroShow2[index] != (Object) null)
              ((Component) this.Img_MainHeroShow2[index]).gameObject.SetActive(false);
          }
        }
        for (int index = 0; index < this.AWM.m_CombatPlayerData[1].HeroInfo.Length; ++index)
        {
          if (this.AWM.m_CombatPlayerData[1].HeroInfo[index].ID > (ushort) 0)
            ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetChild(index).gameObject.SetActive(true);
          else
            ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetChild(index).gameObject.SetActive(false);
          this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.mHeroID_D[index]);
          this.tmpImg = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetChild(index).GetChild(0).GetComponent<Image>();
          ((Graphic) this.tmpImg).rectTransform.pivot = new Vector2(0.5f, 0.5f);
          if (((Component) this.tmpImg).transform.childCount != 0)
            ((Component) this.tmpImg).transform.GetChild(0).gameObject.SetActive(true);
          else if (this.tmpHero.Graph < (ushort) 50000)
          {
            this.tmpImg.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
          }
          else
          {
            this.Cstr_DS_Heros[index].ClearString();
            this.Cstr_DS_Heros[index].IntToFormat((long) this.tmpHero.Graph);
            this.Cstr_DS_Heros[index].AppendFormat("UI/MapNPCHead_{0}");
            if (AssetManager.GetAssetBundleDownload(this.Cstr_DS_Heros[index], AssetPath.UI, AssetType.NPCHead, this.tmpHero.Graph))
            {
              int Key = 0;
              AssetBundle assetBundle = AssetManager.GetAssetBundle(this.Cstr_DS_Heros[index], out Key);
              if ((Object) assetBundle != (Object) null)
                this.mHead[index] = Object.Instantiate(assetBundle.mainAsset) as GameObject;
              if ((Object) this.mHead[index] != (Object) null)
              {
                this.mHead[index].transform.SetParent(((Component) this.tmpImg).transform);
                this.mHead[index].gameObject.SetActive(true);
                this.mHead[index].transform.GetComponent<RectTransform>().sizeDelta = new Vector2(64f, 64f);
                this.mHead[index].transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                this.mHead[index].transform.localScale = new Vector3(1f, 1f, 1f);
              }
            }
          }
          this.tmpImg = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetChild(index).GetChild(1).GetComponent<Image>();
          this.Cstr_DS_Heros[index].ClearString();
          this.Cstr_DS_Heros[index].IntToFormat((long) this.mHeroStar_D[index]);
          this.Cstr_DS_Heros[index].AppendFormat("hf00{0}");
          this.tmpImg.sprite = this.GUIM.LoadFrameSprite(this.Cstr_DS_Heros[index]);
          this.tmpImg = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetChild(index).GetChild(2).GetComponent<Image>();
          this.Cstr_DS_Heros[index].ClearString();
          this.Cstr_DS_Heros[index].IntToFormat((long) this.mHeroRank_D[index]);
          this.Cstr_DS_Heros[index].AppendFormat("hf10{0}");
          this.tmpImg.sprite = this.GUIM.LoadFrameSprite(this.Cstr_DS_Heros[index]);
        }
        break;
      case 9:
        this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 7;
        num = 7;
        this.tmpH = item.GetComponent<RectTransform>().sizeDelta.y;
        this.tmpRC = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetComponent<RectTransform>();
        this.tmpRC.sizeDelta = new Vector2(this.tmpRC.sizeDelta.x, this.tmpH);
        this.text_Troops_Name[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
        this.text_Troops_Name[panelObjectIdx].SetAllDirty();
        this.text_Troops_Name[panelObjectIdx].cachedTextGenerator.Invalidate();
        if (this.tmplistInfo_Data_L[dataIdx] == 0U && this.tmplistInfo_Data_H[dataIdx] == 0U && this.tmplistInfo_Data_D[dataIdx] == 0U)
        {
          this.text_Item_L[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
          this.text_Item_H[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
          this.text_Item_D[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
        }
        else
        {
          this.Cstr_tmpItem1[panelObjectIdx].ClearString();
          this.Cstr_tmpItem1[panelObjectIdx].IntToFormat((long) this.tmplistInfo_Data_L[dataIdx], bNumber: true);
          this.Cstr_tmpItem1[panelObjectIdx].AppendFormat("{0}");
          this.text_Item_L[panelObjectIdx].text = this.Cstr_tmpItem1[panelObjectIdx].ToString();
          this.Cstr_tmpItem2[panelObjectIdx].ClearString();
          this.Cstr_tmpItem2[panelObjectIdx].IntToFormat((long) this.tmplistInfo_Data_H[dataIdx], bNumber: true);
          this.Cstr_tmpItem2[panelObjectIdx].AppendFormat("{0}");
          this.text_Item_H[panelObjectIdx].text = this.Cstr_tmpItem2[panelObjectIdx].ToString();
          this.Cstr_tmpItem3[panelObjectIdx].ClearString();
          this.Cstr_tmpItem3[panelObjectIdx].IntToFormat((long) this.tmplistInfo_Data_D[dataIdx], bNumber: true);
          this.Cstr_tmpItem3[panelObjectIdx].AppendFormat("{0}");
          this.text_Item_D[panelObjectIdx].text = this.Cstr_tmpItem3[panelObjectIdx].ToString();
        }
        this.text_Item_L[panelObjectIdx].SetAllDirty();
        this.text_Item_L[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.text_Item_H[panelObjectIdx].SetAllDirty();
        this.text_Item_H[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.text_Item_D[panelObjectIdx].SetAllDirty();
        this.text_Item_D[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.Img_ItemInfoBG[panelObjectIdx].sprite = !this.IsAttack ? this.SArray.m_Sprites[1] : this.SArray.m_Sprites[0];
        ((Component) this.btn_Icon1[panelObjectIdx]).gameObject.SetActive(false);
        if (this.tmplistInfo_Data_Icon[dataIdx] < byte.MaxValue)
        {
          this.tmpA = (double) this.text_Troops_Name[panelObjectIdx].preferredWidth <= 200.0 ? (byte) ((double) this.text_Troops_Name[panelObjectIdx].preferredWidth + 1.0) : (byte) 200;
          this.btn_IconRT_1[panelObjectIdx].sizeDelta = new Vector2((float) ((int) this.tmpA + 38), this.btn_IconRT_1[panelObjectIdx].sizeDelta.y);
          ((Component) this.btn_Icon1[panelObjectIdx]).gameObject.SetActive(true);
          this.tmpA = (byte) (8 + (int) this.tmplistInfo_Data_Icon[dataIdx] / 4);
          if ((int) this.tmpA < this.SArray.m_Sprites.Length)
            this.Img_Icon_1[panelObjectIdx].sprite = this.SArray.m_Sprites[(int) this.tmpA];
          this.text_Icon_1[panelObjectIdx].text = ((int) this.tmplistInfo_Data_Icon[dataIdx] % 4 + 1).ToString();
          this.m_ItembtnHint[panelObjectIdx].Parm2 = this.tmplistInfo_Data_Icon[dataIdx];
          break;
        }
        break;
      case 10:
        this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 7;
        num = 7;
        this.tmpH = item.GetComponent<RectTransform>().sizeDelta.y;
        this.tmpRC = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetComponent<RectTransform>();
        this.tmpRC.sizeDelta = new Vector2(this.tmpRC.sizeDelta.x, this.tmpH);
        this.text_Troops_Name[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
        this.text_Troops_Name[panelObjectIdx].SetAllDirty();
        this.text_Troops_Name[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.text_Troops_Name[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
        this.Cstr_tmpItem1[panelObjectIdx].ClearString();
        this.Cstr_tmpItem1[panelObjectIdx].IntToFormat((long) this.tmplistInfo_Data_L[dataIdx], bNumber: true);
        this.Cstr_tmpItem1[panelObjectIdx].AppendFormat("{0}");
        this.text_Item_L[panelObjectIdx].text = this.Cstr_tmpItem1[panelObjectIdx].ToString();
        this.Cstr_tmpItem2[panelObjectIdx].ClearString();
        this.Cstr_tmpItem2[panelObjectIdx].IntToFormat((long) this.tmplistInfo_Data_H[dataIdx], bNumber: true);
        this.Cstr_tmpItem2[panelObjectIdx].AppendFormat("{0}");
        this.text_Item_H[panelObjectIdx].text = this.Cstr_tmpItem2[panelObjectIdx].ToString();
        this.Cstr_tmpItem3[panelObjectIdx].ClearString();
        this.Cstr_tmpItem3[panelObjectIdx].IntToFormat((long) this.tmplistInfo_Data_D[dataIdx], bNumber: true);
        this.Cstr_tmpItem3[panelObjectIdx].AppendFormat("{0}");
        this.text_Item_D[panelObjectIdx].text = this.Cstr_tmpItem3[panelObjectIdx].ToString();
        this.text_Item_L[panelObjectIdx].SetAllDirty();
        this.text_Item_L[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.text_Item_H[panelObjectIdx].SetAllDirty();
        this.text_Item_H[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.text_Item_D[panelObjectIdx].SetAllDirty();
        this.text_Item_D[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.Img_ItemInfoBG[panelObjectIdx].sprite = this.IsAttack ? this.SArray.m_Sprites[1] : this.SArray.m_Sprites[0];
        ((Component) this.btn_Icon1[panelObjectIdx]).gameObject.SetActive(false);
        if (this.tmplistInfo_Data_Icon[dataIdx] < byte.MaxValue)
        {
          ((Component) this.btn_Icon1[panelObjectIdx]).gameObject.SetActive(true);
          this.tmpA = (double) this.text_Troops_Name[panelObjectIdx].preferredWidth <= 200.0 ? (byte) ((double) this.text_Troops_Name[panelObjectIdx].preferredWidth + 1.0) : (byte) 200;
          this.btn_IconRT_1[panelObjectIdx].sizeDelta = new Vector2((float) ((int) this.tmpA + 38), this.btn_IconRT_1[panelObjectIdx].sizeDelta.y);
          this.tmpA = this.tmplistInfo_Data_Icon[dataIdx] >= (byte) 16 ? (byte) (12 + ((int) this.tmplistInfo_Data_Icon[dataIdx] - 16) / 4) : (byte) (8 + (int) this.tmplistInfo_Data_Icon[dataIdx] / 4);
          if ((int) this.tmpA < this.SArray.m_Sprites.Length)
            this.Img_Icon_1[panelObjectIdx].sprite = this.SArray.m_Sprites[(int) this.tmpA];
          this.text_Icon_1[panelObjectIdx].text = ((int) this.tmplistInfo_Data_Icon[dataIdx] % 4 + 1).ToString();
          this.m_ItembtnHint[panelObjectIdx].Parm2 = this.tmplistInfo_Data_Icon[dataIdx];
          break;
        }
        break;
      case 11:
        this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 8;
        num = 8;
        this.text_Title4_1[panelObjectIdx].text = this.Cstr_Title4[0].ToString();
        this.text_Title4_1[panelObjectIdx].SetAllDirty();
        this.text_Title4_1[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.text_Title4_2[panelObjectIdx].text = this.Cstr_Title4[1].ToString();
        this.text_Title4_2[panelObjectIdx].SetAllDirty();
        this.text_Title4_2[panelObjectIdx].cachedTextGenerator.Invalidate();
        break;
      case 12:
        this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 9;
        num = 9;
        if (this.IsAttack)
        {
          this.Img_Name2_L[panelObjectIdx].sprite = this.SArray.m_Sprites[6];
          this.Img_Name2_R[panelObjectIdx].sprite = this.SArray.m_Sprites[7];
          break;
        }
        this.Img_Name2_L[panelObjectIdx].sprite = this.SArray.m_Sprites[7];
        this.Img_Name2_R[panelObjectIdx].sprite = this.SArray.m_Sprites[6];
        break;
      case 13:
        this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 10;
        num = 10;
        this.tmpH = item.GetComponent<RectTransform>().sizeDelta.y;
        this.tmpRC = ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).GetComponent<RectTransform>();
        this.tmpRC.sizeDelta = new Vector2(this.tmpRC.sizeDelta.x, this.tmpH);
        this.text_Data2_1[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
        this.text_Data2_1[panelObjectIdx].SetAllDirty();
        this.text_Data2_1[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.text_Data2_1[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
        this.tmpA = (double) this.text_Data2_1[panelObjectIdx].preferredWidth <= 180.0 ? (byte) ((double) this.text_Data2_1[panelObjectIdx].preferredWidth + 1.0) : (byte) 180;
        this.btn_IconRT_2[panelObjectIdx].sizeDelta = new Vector2((float) ((int) this.tmpA + 38), this.btn_IconRT_2[panelObjectIdx].sizeDelta.y);
        this.Cstr_tmpItem1[panelObjectIdx].ClearString();
        this.Cstr_tmpItem2[panelObjectIdx].ClearString();
        if (this.tmplistInfo_Data_L[dataIdx] > 0U)
        {
          this.Cstr_tmpItem1[panelObjectIdx].IntToFormat((long) this.tmplistInfo_Data_L[dataIdx], bNumber: true);
          this.Cstr_tmpItem1[panelObjectIdx].AppendFormat("{0}");
          this.Cstr_tmpItem2[panelObjectIdx].IntToFormat((long) this.tmplistInfo_Data_H[dataIdx], bNumber: true);
          this.Cstr_tmpItem2[panelObjectIdx].AppendFormat("{0}");
        }
        else
        {
          this.Cstr_tmpItem1[panelObjectIdx].Append("-");
          this.Cstr_tmpItem2[panelObjectIdx].Append("-");
        }
        this.text_Data2_2[panelObjectIdx].text = this.Cstr_tmpItem1[panelObjectIdx].ToString();
        this.text_Data2_2[panelObjectIdx].SetAllDirty();
        this.text_Data2_2[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.text_Data2_3[panelObjectIdx].text = this.Cstr_tmpItem2[panelObjectIdx].ToString();
        this.text_Data2_3[panelObjectIdx].SetAllDirty();
        this.text_Data2_3[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.Cstr_tmpItem3[panelObjectIdx].ClearString();
        this.Cstr_tmpItem4[panelObjectIdx].ClearString();
        if (this.tmplistInfo_Data_D[dataIdx] > 0U)
        {
          this.Cstr_tmpItem3[panelObjectIdx].IntToFormat((long) this.tmplistInfo_Data_D[dataIdx], bNumber: true);
          this.Cstr_tmpItem3[panelObjectIdx].AppendFormat("{0}");
          this.Cstr_tmpItem4[panelObjectIdx].IntToFormat((long) this.tmplistInfo_Data_[dataIdx], bNumber: true);
          this.Cstr_tmpItem4[panelObjectIdx].AppendFormat("{0}");
        }
        else
        {
          this.Cstr_tmpItem3[panelObjectIdx].Append("-");
          this.Cstr_tmpItem4[panelObjectIdx].Append("-");
        }
        this.text_Data2_4[panelObjectIdx].text = this.Cstr_tmpItem3[panelObjectIdx].ToString();
        this.text_Data2_4[panelObjectIdx].SetAllDirty();
        this.text_Data2_4[panelObjectIdx].cachedTextGenerator.Invalidate();
        this.text_Data2_5[panelObjectIdx].text = this.Cstr_tmpItem4[panelObjectIdx].ToString();
        this.text_Data2_5[panelObjectIdx].SetAllDirty();
        this.text_Data2_5[panelObjectIdx].cachedTextGenerator.Invalidate();
        if (this.IsAttack)
        {
          this.Img_Data2_L[panelObjectIdx].sprite = this.SArray.m_Sprites[4];
          this.Img_Data2_R[panelObjectIdx].sprite = this.SArray.m_Sprites[5];
        }
        else
        {
          this.Img_Data2_L[panelObjectIdx].sprite = this.SArray.m_Sprites[5];
          this.Img_Data2_R[panelObjectIdx].sprite = this.SArray.m_Sprites[4];
        }
        ((Graphic) this.Img_Data2_L[panelObjectIdx]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Data2_L[panelObjectIdx]).rectTransform.sizeDelta.x, this.tmpH);
        ((Graphic) this.Img_Data2_R[panelObjectIdx]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Data2_R[panelObjectIdx]).rectTransform.sizeDelta.x, this.tmpH);
        this.tmpA = this.tmplistInfo_Data_Icon[dataIdx] >= (byte) 16 ? (byte) (12 + ((int) this.tmplistInfo_Data_Icon[dataIdx] - 16) / 4) : (byte) (8 + (int) this.tmplistInfo_Data_Icon[dataIdx] / 4);
        if ((int) this.tmpA < this.SArray.m_Sprites.Length)
          this.Img_Icon_2[panelObjectIdx].sprite = this.SArray.m_Sprites[(int) this.tmpA];
        if (this.tmplistInfo_Data_Icon[dataIdx] < byte.MaxValue)
        {
          this.text_Icon_2[panelObjectIdx].text = ((int) this.tmplistInfo_Data_Icon[dataIdx] % 4 + 1).ToString();
          this.m_ItembtnHint2[panelObjectIdx].Parm2 = this.tmplistInfo_Data_Icon[dataIdx];
          break;
        }
        break;
    }
    ((Component) this.mSeroll_Item[panelObjectIdx]).transform.GetChild(num - 1).gameObject.SetActive(true);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void OnClose()
  {
    if (this.Cstr_Hint != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Hint);
    for (int index = 0; index < 5; ++index)
    {
      if (this.Cstr_DS_Heros[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_DS_Heros[index]);
    }
    for (int index = 0; index < 17; ++index)
    {
      if (this.Cstr_tmpItem1[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_tmpItem1[index]);
      if (this.Cstr_tmpItem2[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_tmpItem2[index]);
      if (this.Cstr_tmpItem3[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_tmpItem3[index]);
      if (this.Cstr_tmpItem4[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_tmpItem4[index]);
    }
    for (int index = 0; index < 2; ++index)
    {
      if (this.Cstr_PlayName[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_PlayName[index]);
      if (this.Cstr_Title[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Title[index]);
      if (this.Cstr_Title4[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Title4[index]);
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((Object) this.mHead[index] != (Object) null)
        Object.Destroy((Object) this.mHead[index]);
      this.mHead[index] = (GameObject) null;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 != 0)
      return;
    ++this.DM.mSaveInfo;
    if (!((Object) this.door != (Object) null))
      return;
    this.door.CloseMenu();
  }

  public override bool OnBackButtonClick()
  {
    ++this.DM.mSaveInfo;
    return false;
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    switch (sender.Parm1)
    {
      case 1:
      case 2:
        this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) ((uint) sender.Parm2 + 1U));
        this.text_Hint_1.text = this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name);
        this.text_Hint_1.SetAllDirty();
        this.text_Hint_1.cachedTextGenerator.Invalidate();
        this.text_Hint_1.cachedTextGeneratorForLayout.Invalidate();
        ((Graphic) this.text_Hint_1).rectTransform.sizeDelta = new Vector2(this.text_Hint_1.preferredWidth + 1f, ((Graphic) this.text_Hint_1).rectTransform.sizeDelta.y);
        if (this.GUIM.IsArabic)
          this.text_Hint_1.UpdateArabicPos();
        this.Cstr_Hint.ClearString();
        this.Cstr_Hint.IntToFormat((long) ((int) sender.Parm2 % 4 + 1));
        if (sender.Parm2 < (byte) 16)
          this.Cstr_Hint.StringToFormat(this.DM.mStringTable.GetStringByID((uint) (ushort) (3841 + (int) sender.Parm2 / 4)));
        else
          this.Cstr_Hint.StringToFormat(this.DM.mStringTable.GetStringByID((uint) (ushort) (12079 + ((int) sender.Parm2 - 16) / 4)));
        this.Cstr_Hint.AppendFormat(this.DM.mStringTable.GetStringByID(12078U));
        this.text_Hint_2.text = this.Cstr_Hint.ToString();
        this.text_Hint_2.SetAllDirty();
        this.text_Hint_2.cachedTextGenerator.Invalidate();
        this.text_Hint_2.cachedTextGeneratorForLayout.Invalidate();
        ((Graphic) this.text_Hint_2).rectTransform.sizeDelta = new Vector2(this.text_Hint_2.preferredWidth + 1f, ((Graphic) this.text_Hint_2).rectTransform.sizeDelta.y);
        if (this.GUIM.IsArabic)
          this.text_Hint_2.UpdateArabicPos();
        if ((double) this.text_Hint_1.preferredWidth > (double) this.text_Hint_2.preferredWidth)
          ((Graphic) this.Img_Hint).rectTransform.sizeDelta = new Vector2(this.text_Hint_1.preferredWidth + 21f, ((Graphic) this.Img_Hint).rectTransform.sizeDelta.y);
        else
          ((Graphic) this.Img_Hint).rectTransform.sizeDelta = new Vector2(this.text_Hint_2.preferredWidth + 21f, ((Graphic) this.Img_Hint).rectTransform.sizeDelta.y);
        sender.GetTipPosition(((Graphic) this.Img_Hint).rectTransform);
        ((Graphic) this.Img_Hint).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Img_Hint).rectTransform.anchoredPosition.x + 70f, ((Graphic) this.Img_Hint).rectTransform.anchoredPosition.y);
        ((Component) this.Img_Hint).gameObject.SetActive(true);
        break;
      case 3:
      case 4:
        GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintArmy, (byte) 0, 0.0f, 0, (int) sender.Parm1 - 3, 0, Vector2.zero);
        break;
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    ((Component) this.Img_Hint).gameObject.SetActive(false);
    GUIManager.Instance.m_Hint.Hide(true);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        break;
      case NetworkNews.Refresh:
        break;
      case NetworkNews.Refresh_Asset:
        if (meg[1] != (byte) 0 || meg[2] != (byte) 1)
          break;
        int num = 0;
        GameConstants.ConvertBytesToUShort(meg, 3);
        for (int index = 0; index < 5; ++index)
        {
          this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.mHeroID_D[index]);
          if ((int) GameConstants.ConvertBytesToUShort(meg, 3) == (int) this.tmpHero.Graph)
          {
            for (int panelObjectIdx = 0; panelObjectIdx < 17; ++panelObjectIdx)
            {
              if ((Object) this.mSeroll_Item[panelObjectIdx] != (Object) null && ((Component) this.mSeroll_Item[panelObjectIdx]).gameObject.activeSelf)
              {
                int btnId1 = this.mSeroll_Item[panelObjectIdx].m_BtnID1;
                num = this.mSeroll_Item[panelObjectIdx].m_BtnID2;
                if (btnId1 >= 0 && btnId1 < this.tmplistInfo_Type.Count && this.tmplistInfo_Type[btnId1] == (byte) 8)
                  this.UpDateRowItem(((Component) this.mSeroll_Item[panelObjectIdx]).gameObject, btnId1, panelObjectIdx, 0);
              }
            }
            break;
          }
        }
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    for (int index = 0; index < 11; ++index)
    {
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
    for (int index = 0; index < 17; ++index)
    {
      if ((Object) this.text_Top[index] != (Object) null && ((Behaviour) this.text_Top[index]).enabled)
      {
        ((Behaviour) this.text_Top[index]).enabled = false;
        ((Behaviour) this.text_Top[index]).enabled = true;
      }
      if ((Object) this.text_Title1[index] != (Object) null && ((Behaviour) this.text_Title1[index]).enabled)
      {
        ((Behaviour) this.text_Title1[index]).enabled = false;
        ((Behaviour) this.text_Title1[index]).enabled = true;
      }
      if ((Object) this.text_ATitleTroops[index] != (Object) null && ((Behaviour) this.text_ATitleTroops[index]).enabled)
      {
        ((Behaviour) this.text_ATitleTroops[index]).enabled = false;
        ((Behaviour) this.text_ATitleTroops[index]).enabled = true;
      }
      if ((Object) this.text_ATitleTraps[index] != (Object) null && ((Behaviour) this.text_ATitleTraps[index]).enabled)
      {
        ((Behaviour) this.text_ATitleTraps[index]).enabled = false;
        ((Behaviour) this.text_ATitleTraps[index]).enabled = true;
      }
      if ((Object) this.text_Title1_1[index] != (Object) null && ((Behaviour) this.text_Title1_1[index]).enabled)
      {
        ((Behaviour) this.text_Title1_1[index]).enabled = false;
        ((Behaviour) this.text_Title1_1[index]).enabled = true;
      }
      if ((Object) this.text_Title1_2[index] != (Object) null && ((Behaviour) this.text_Title1_2[index]).enabled)
      {
        ((Behaviour) this.text_Title1_2[index]).enabled = false;
        ((Behaviour) this.text_Title1_2[index]).enabled = true;
      }
      if ((Object) this.text_Title2[index] != (Object) null && ((Behaviour) this.text_Title2[index]).enabled)
      {
        ((Behaviour) this.text_Title2[index]).enabled = false;
        ((Behaviour) this.text_Title2[index]).enabled = true;
      }
      if ((Object) this.text_Title2_1[index] != (Object) null && ((Behaviour) this.text_Title2_1[index]).enabled)
      {
        ((Behaviour) this.text_Title2_1[index]).enabled = false;
        ((Behaviour) this.text_Title2_1[index]).enabled = true;
      }
      if ((Object) this.text_DTitleTroops[index] != (Object) null && ((Behaviour) this.text_DTitleTroops[index]).enabled)
      {
        ((Behaviour) this.text_DTitleTroops[index]).enabled = false;
        ((Behaviour) this.text_DTitleTroops[index]).enabled = true;
      }
      if ((Object) this.text_InfoName1[index] != (Object) null && ((Behaviour) this.text_InfoName1[index]).enabled)
      {
        ((Behaviour) this.text_InfoName1[index]).enabled = false;
        ((Behaviour) this.text_InfoName1[index]).enabled = true;
      }
      if ((Object) this.text_InfoName2[index] != (Object) null && ((Behaviour) this.text_InfoName2[index]).enabled)
      {
        ((Behaviour) this.text_InfoName2[index]).enabled = false;
        ((Behaviour) this.text_InfoName2[index]).enabled = true;
      }
      if ((Object) this.text_InfoName3[index] != (Object) null && ((Behaviour) this.text_InfoName3[index]).enabled)
      {
        ((Behaviour) this.text_InfoName3[index]).enabled = false;
        ((Behaviour) this.text_InfoName3[index]).enabled = true;
      }
      if ((Object) this.text_InfoName4[index] != (Object) null && ((Behaviour) this.text_InfoName4[index]).enabled)
      {
        ((Behaviour) this.text_InfoName4[index]).enabled = false;
        ((Behaviour) this.text_InfoName4[index]).enabled = true;
      }
      if ((Object) this.text_Troops_Name[index] != (Object) null && ((Behaviour) this.text_Troops_Name[index]).enabled)
      {
        ((Behaviour) this.text_Troops_Name[index]).enabled = false;
        ((Behaviour) this.text_Troops_Name[index]).enabled = true;
      }
      if ((Object) this.text_Item_L[index] != (Object) null && ((Behaviour) this.text_Item_L[index]).enabled)
      {
        ((Behaviour) this.text_Item_L[index]).enabled = false;
        ((Behaviour) this.text_Item_L[index]).enabled = true;
      }
      if ((Object) this.text_Item_H[index] != (Object) null && ((Behaviour) this.text_Item_H[index]).enabled)
      {
        ((Behaviour) this.text_Item_H[index]).enabled = false;
        ((Behaviour) this.text_Item_H[index]).enabled = true;
      }
      if ((Object) this.text_Item_D[index] != (Object) null && ((Behaviour) this.text_Item_D[index]).enabled)
      {
        ((Behaviour) this.text_Item_D[index]).enabled = false;
        ((Behaviour) this.text_Item_D[index]).enabled = true;
      }
      if ((Object) this.text_DTitleTraps[index] != (Object) null && ((Behaviour) this.text_DTitleTraps[index]).enabled)
      {
        ((Behaviour) this.text_DTitleTraps[index]).enabled = false;
        ((Behaviour) this.text_DTitleTraps[index]).enabled = true;
      }
      if ((Object) this.text_Icon_1[index] != (Object) null && ((Behaviour) this.text_Icon_1[index]).enabled)
      {
        ((Behaviour) this.text_Icon_1[index]).enabled = false;
        ((Behaviour) this.text_Icon_1[index]).enabled = true;
      }
      if ((Object) this.text_Icon_2[index] != (Object) null && ((Behaviour) this.text_Icon_2[index]).enabled)
      {
        ((Behaviour) this.text_Icon_2[index]).enabled = false;
        ((Behaviour) this.text_Icon_2[index]).enabled = true;
      }
      if ((Object) this.text_Title4_1[index] != (Object) null && ((Behaviour) this.text_Title4_1[index]).enabled)
      {
        ((Behaviour) this.text_Title4_1[index]).enabled = false;
        ((Behaviour) this.text_Title4_1[index]).enabled = true;
      }
      if ((Object) this.text_Title4_2[index] != (Object) null && ((Behaviour) this.text_Title4_2[index]).enabled)
      {
        ((Behaviour) this.text_Title4_2[index]).enabled = false;
        ((Behaviour) this.text_Title4_2[index]).enabled = true;
      }
      if ((Object) this.text_Name2_1[index] != (Object) null && ((Behaviour) this.text_Name2_1[index]).enabled)
      {
        ((Behaviour) this.text_Name2_1[index]).enabled = false;
        ((Behaviour) this.text_Name2_1[index]).enabled = true;
      }
      if ((Object) this.text_Name2_2[index] != (Object) null && ((Behaviour) this.text_Name2_2[index]).enabled)
      {
        ((Behaviour) this.text_Name2_2[index]).enabled = false;
        ((Behaviour) this.text_Name2_2[index]).enabled = true;
      }
      if ((Object) this.text_Name2_3[index] != (Object) null && ((Behaviour) this.text_Name2_3[index]).enabled)
      {
        ((Behaviour) this.text_Name2_3[index]).enabled = false;
        ((Behaviour) this.text_Name2_3[index]).enabled = true;
      }
      if ((Object) this.text_Name2_4[index] != (Object) null && ((Behaviour) this.text_Name2_4[index]).enabled)
      {
        ((Behaviour) this.text_Name2_4[index]).enabled = false;
        ((Behaviour) this.text_Name2_4[index]).enabled = true;
      }
      if ((Object) this.text_Name2_5[index] != (Object) null && ((Behaviour) this.text_Name2_5[index]).enabled)
      {
        ((Behaviour) this.text_Name2_5[index]).enabled = false;
        ((Behaviour) this.text_Name2_5[index]).enabled = true;
      }
      if ((Object) this.text_Data2_1[index] != (Object) null && ((Behaviour) this.text_Data2_1[index]).enabled)
      {
        ((Behaviour) this.text_Data2_1[index]).enabled = false;
        ((Behaviour) this.text_Data2_1[index]).enabled = true;
      }
      if ((Object) this.text_Data2_2[index] != (Object) null && ((Behaviour) this.text_Data2_2[index]).enabled)
      {
        ((Behaviour) this.text_Data2_2[index]).enabled = false;
        ((Behaviour) this.text_Data2_2[index]).enabled = true;
      }
      if ((Object) this.text_Data2_3[index] != (Object) null && ((Behaviour) this.text_Data2_3[index]).enabled)
      {
        ((Behaviour) this.text_Data2_3[index]).enabled = false;
        ((Behaviour) this.text_Data2_3[index]).enabled = true;
      }
      if ((Object) this.text_Data2_4[index] != (Object) null && ((Behaviour) this.text_Data2_4[index]).enabled)
      {
        ((Behaviour) this.text_Data2_4[index]).enabled = false;
        ((Behaviour) this.text_Data2_4[index]).enabled = true;
      }
      if ((Object) this.text_Data2_5[index] != (Object) null && ((Behaviour) this.text_Data2_5[index]).enabled)
      {
        ((Behaviour) this.text_Data2_5[index]).enabled = false;
        ((Behaviour) this.text_Data2_5[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if ((Object) this.Img_MainHeroShow1[0] != (Object) null && (Object) this.Img_MainHeroShow_A[0] != (Object) null && ((Component) this.Img_MainHeroShow1[0]).gameObject.activeSelf)
    {
      this.ShowMainHeroTime1 += Time.smoothDeltaTime;
      if ((double) this.ShowMainHeroTime1 >= 0.0)
      {
        if ((double) this.ShowMainHeroTime1 >= 2.0)
          this.ShowMainHeroTime1 = 0.0f;
        ((Graphic) this.Img_MainHeroShow_A[0]).color = new Color(1f, 1f, 1f, (double) this.ShowMainHeroTime1 <= 1.0 ? this.ShowMainHeroTime1 : 2f - this.ShowMainHeroTime1);
      }
    }
    if (!((Object) this.Img_MainHeroShow2[0] != (Object) null) || !((Object) this.Img_MainHeroShow_D[0] != (Object) null) || !((Component) this.Img_MainHeroShow2[0]).gameObject.activeSelf)
      return;
    this.ShowMainHeroTime2 += Time.smoothDeltaTime;
    if ((double) this.ShowMainHeroTime2 < 0.0)
      return;
    if ((double) this.ShowMainHeroTime2 >= 2.0)
      this.ShowMainHeroTime2 = 0.0f;
    ((Graphic) this.Img_MainHeroShow_D[0]).color = new Color(1f, 1f, 1f, (double) this.ShowMainHeroTime2 <= 1.0 ? this.ShowMainHeroTime2 : 2f - this.ShowMainHeroTime2);
  }
}
