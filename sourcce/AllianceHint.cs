// Decompiled with JetBrains decompiler
// Type: AllianceHint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#nullable disable
public class AllianceHint : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
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
  protected Image m_PageBack;
  protected UIEmojiInput s_input;
  protected UIEmojiInput m_input;
  protected ScrollPanel m_scroll;
  protected ScrollPanelItem[] m_panel;
  protected UISpritesArray USArray;
  protected Transform Transformer;
  protected Transform Tick;
  protected Transform Invalid;
  protected Transform TagTick;
  protected Transform TagInvalid;
  protected RectTransform Join;
  protected RectTransform NameTick;
  protected RectTransform NameInvalid;
  protected RectTransform SearchRT;
  protected RectTransform SearchList;
  protected RectTransform ApplyList;
  protected Vector3 SearchPosition;
  protected Vector2 SearchSize;
  protected bool Revert;
  protected UnityEngine.UI.Text Name;
  protected UnityEngine.UI.Text Tag;
  protected UnityEngine.UI.Text[][] ItemTag = new UnityEngine.UI.Text[7][];
  protected float TeaTime;
  public static float CheckTime;
  public static float Scrolling;
  public static long Proceeding;
  public static long Pending;
  public static byte Pulling;
  public static byte Tagging;
  public static byte Naming;
  public static bool Clearing;
  public static bool Shooting;
  public static int Positioning;
  public static Protocol Checking;
  public static Protocol Incoming;
  public static string Text;
  public static string pendingText;
  public static string FilterName;
  public static string ValidName;
  public static string ValidTag;
  public static string SeekName;
  public static string SearchName;
  public static string SearchLang;
  public static byte GenuineLang;
  public static byte GenuineName;
  public static byte GenuineTag;
  public static byte SetRequest;
  public static byte FilterIdx;
  public static byte SearchIdx;
  public static byte SeekKind;
  public static byte SeekLang;
  public static int SearchNum;
  public static int SearchPage;
  public static AllianceSearch[] Search;
  public DataManager DM = DataManager.Instance;
  public Font Font = GUIManager.Instance.GetTTFFont();
  public StringBuilder Path = new StringBuilder();
  private List<float> ItemsHeight = new List<float>();

  public override void OnOpen(int arg1, int arg2)
  {
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      RectTransform transform1 = (RectTransform) this.transform;
      Vector2 vector2_1 = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.transform.GetChild(2)).offsetMin = vector2_1;
      Vector2 vector2_2 = vector2_1;
      transform1.offsetMin = vector2_2;
      RectTransform transform2 = (RectTransform) this.transform;
      Vector2 vector2_3 = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.transform.GetChild(2)).offsetMax = vector2_3;
      Vector2 vector2_4 = vector2_3;
      transform2.offsetMax = vector2_4;
    }
    for (int index = 0; index < 7; ++index)
      this.ItemTag[index] = new UnityEngine.UI.Text[6];
    this.transform.GetChild(0).GetChild(6).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(0).GetChild(8).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(0).GetChild(12).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_label[0] = this.transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_label[0].text = this.DM.mStringTable.GetStringByID(4609U);
    this.m_label[0].font = this.Font;
    this.m_label[1] = this.transform.GetChild(0).GetChild(7).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_label[1].text = this.DM.mStringTable.GetStringByID(!this.DM.CheckPrizeFlag((byte) 0) ? 746U : 4602U);
    this.m_label[1].font = this.Font;
    this.m_label[2] = this.transform.GetChild(0).GetChild(8).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_label[2].text = this.DM.mStringTable.GetStringByID(4610U);
    this.m_label[2].font = this.Font;
    this.m_label[3] = this.transform.GetChild(0).GetChild(10).GetComponent<UnityEngine.UI.Text>();
    this.m_label[3].text = this.DM.mStringTable.GetStringByID(4601U);
    this.m_label[3].font = this.Font;
    this.m_label[4] = this.transform.GetChild(0).GetChild(13).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_label[4].text = this.DM.mStringTable.GetStringByID(746U);
    this.m_label[4].font = this.Font;
    this.m_label[5] = this.transform.GetChild(0).GetChild(13).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.m_label[5].text = this.DM.mStringTable.GetStringByID(4604U);
    this.m_label[5].font = this.Font;
    this.m_label[6] = this.transform.GetChild(0).GetChild(13).GetChild(2).GetComponent<UnityEngine.UI.Text>();
    this.m_label[6].text = this.DM.mStringTable.GetStringByID(4605U);
    this.m_label[6].font = this.Font;
    this.m_label[7] = this.transform.GetChild(0).GetChild(13).GetChild(3).GetComponent<UnityEngine.UI.Text>();
    this.m_label[7].text = this.DM.mStringTable.GetStringByID(4606U);
    this.m_label[7].font = this.Font;
    this.m_label[8] = this.transform.GetChild(0).GetChild(13).GetChild(4).GetComponent<UnityEngine.UI.Text>();
    this.m_label[8].text = this.DM.mStringTable.GetStringByID(4607U);
    this.m_label[8].font = this.Font;
    this.m_label[9] = this.transform.GetChild(0).GetChild(13).GetChild(5).GetComponent<UnityEngine.UI.Text>();
    this.m_label[9].text = this.DM.mStringTable.GetStringByID(4608U);
    this.m_label[9].font = this.Font;
    float num1 = 0.0f;
    for (ushort index = 4; index <= (ushort) 8; ++index)
    {
      if (this.DM.CheckPrizeFlag((byte) 0) && index == (ushort) 4)
      {
        this.transform.GetChild(0).GetChild(13).GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(0).GetChild(13).GetChild(6).gameObject.SetActive(false);
        this.transform.GetChild(0).GetChild(13).localPosition -= new Vector3(0.0f, 8f, 0.0f);
      }
      else
      {
        this.SearchPosition = new Vector3(0.0f, (double) this.m_label[(int) index].preferredHeight <= 32.0 ? 32f : (float) ((int) Math.Ceiling((double) this.m_label[(int) index].preferredHeight / 32.0) * 32), 0.0f);
        num1 += this.SearchPosition.y - 32f;
      }
      ((Component) this.m_label[(int) index + 1]).transform.localPosition = ((Component) this.m_label[(int) index]).transform.localPosition - this.SearchPosition;
      this.transform.GetChild(0).GetChild(13).GetChild((int) index + 3).localPosition = this.transform.GetChild(0).GetChild(13).GetChild((int) index + 2).localPosition - this.SearchPosition;
    }
    this.SearchPosition = new Vector3(0.0f, num1 / 2f, 0.0f);
    this.transform.GetChild(0).GetChild(6).localPosition -= this.SearchPosition;
    this.transform.GetChild(0).GetChild(8).localPosition -= this.SearchPosition;
    this.transform.GetChild(0).GetChild(12).localPosition += this.SearchPosition;
    this.Join = (RectTransform) this.transform.GetChild(0);
    this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.Join.sizeDelta.y + num1);
    this.Join = (RectTransform) this.transform.GetChild(0).GetChild(0);
    this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.Join.sizeDelta.y + num1);
    this.Join = this.transform.GetChild(1).GetChild(8).GetComponent<RectTransform>();
    this.ApplyList = this.transform.GetChild(1).GetChild(10).GetComponent<RectTransform>();
    this.SearchList = this.transform.GetChild(1).GetChild(8).GetComponent<RectTransform>();
    this.SearchSize = this.SearchList.sizeDelta;
    this.SearchPosition = ((Transform) this.SearchList).localPosition;
    this.Join.sizeDelta = this.ApplyList.sizeDelta;
    ((Transform) this.Join).localPosition = ((Transform) this.ApplyList).localPosition;
    this.USArray = this.transform.GetComponent<UISpritesArray>();
    GUIManager.Instance.InitBadgeTotem(this.transform.GetChild(1).GetChild(9).GetChild(2).GetChild(1), (ushort) 0);
    this.s_input = this.transform.GetChild(1).GetChild(3).GetChild(15).GetComponent<UIEmojiInput>();
    this.m_default[0] = this.transform.GetChild(1).GetChild(3).GetChild(17).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.m_default[0].text = this.DM.mStringTable.GetStringByID(794U);
    this.m_default[0].font = GUIManager.Instance.GetTTFFont();
    this.m_default[1] = ((Component) this.s_input.placeholder).GetComponent<UnityEngine.UI.Text>();
    this.m_default[1].text = this.DM.mStringTable.GetStringByID(793U);
    this.m_default[1].font = GUIManager.Instance.GetTTFFont();
    this.m_default[2] = this.transform.GetChild(1).GetChild(11).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_default[2].text = this.DM.mStringTable.GetStringByID(4725U);
    this.m_default[2].font = GUIManager.Instance.GetTTFFont();
    this.transform.GetChild(1).GetChild(5).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    if (this.DM.RoleAlliance.ApplyList == null)
      this.DM.RoleAlliance.ApplyList = new uint[10];
    if (AllianceHint.Search == null)
      AllianceHint.Search = new AllianceSearch[101];
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    Image component = this.transform.GetComponent<Image>();
    component.sprite = this.door.LoadSprite("UI_main_black");
    ((MaskableGraphic) component).material = this.door.LoadMaterial();
    if (this.DM.SetSelectRequest == 0)
    {
      string empty;
      AllianceHint.ValidTag = empty = string.Empty;
      AllianceHint.ValidName = empty;
      AllianceHint.FilterName = empty;
      AllianceHint.SeekName = empty;
      AllianceHint.SearchName = empty;
      AllianceHint.SearchLang = empty;
      DataManager dm1 = this.DM;
      DataManager dm2 = this.DM;
      int num2;
      AllianceHint.SetRequest = (byte) (num2 = 0);
      AllianceHint.FilterIdx = (byte) num2;
      AllianceHint.GenuineTag = (byte) num2;
      AllianceHint.GenuineName = (byte) num2;
      AllianceHint.GenuineLang = (byte) num2;
      byte num3 = (byte) num2;
      dm2.CurSelectLanguage = (byte) num2;
      int num4 = (int) num3;
      dm1.SetSelectLanguage = num4;
      this.DM.CurSelectBadge = (ushort) (UnityEngine.Random.Range(1, 64) - 1 << 6 | UnityEngine.Random.Range(0, 7) << 3 | UnityEngine.Random.Range(0, 7));
      AllianceHint.GenuineLang = AllianceHint.SeekLang = this.DM.GetUserLanguageID();
      if (arg1 == 0)
        this.RequestApplyList();
      AllianceHint.Clearing = false;
      AllianceHint.Shooting = false;
      AllianceHint.Positioning = -1;
      AllianceHint.SeekKind = byte.MaxValue;
      AllianceHint.Scrolling = AllianceHint.CheckTime = 0.0f;
      this.door.UpdateUI(1, 1);
      if (DataManager.Instance.RoleAlliance.Apply > (byte) 0)
      {
        this.door.UpdateUI(1, 2);
        this.UpdateUI(13, 0);
      }
    }
    else if (DataManager.Instance.SetSelectLanguage > 0 || DataManager.Instance.SetSelectRequest > 0 || AllianceHint.SetRequest > (byte) 0)
    {
      if (DataManager.Instance.SetSelectLanguage == 1)
      {
        if (DataManager.Instance.SetSelectRequest == 41)
          this.SetFilterName(AllianceHint.FilterIdx = DataManager.Instance.CurSelectLanguage);
        else
          AllianceHint.GenuineLang = DataManager.Instance.CurSelectLanguage;
        DataManager.Instance.SetSelectLanguage = 0;
      }
      this.door.UpdateUI(1, 2);
      this.UpdateUI((int) AllianceHint.SetRequest, 0);
    }
    this.m_search = this.transform.GetChild(1).GetChild(3).GetChild(4).GetChild(2).GetComponent<UnityEngine.UI.Text>();
    this.m_search.font = GUIManager.Instance.GetTTFFont();
    this.m_search.text = AllianceHint.SearchName;
    this.m_filter = this.transform.GetChild(1).GetChild(3).GetChild(5).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.m_filter.font = GUIManager.Instance.GetTTFFont();
    this.m_filter.text = AllianceHint.SearchLang;
    this.m_limit = this.transform.GetChild(2).GetChild(0).GetChild(12).GetComponent<UnityEngine.UI.Text>();
    this.m_limit.font = GUIManager.Instance.GetTTFFont();
    this.transform.GetChild(2).GetChild(0).GetChild(4).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4715U);
    this.transform.GetChild(2).GetChild(0).GetChild(4).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
    this.transform.GetChild(2).GetChild(0).GetChild(5).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
    this.transform.GetChild(2).GetChild(0).GetChild(7).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
    this.transform.GetChild(2).GetChild(0).GetChild(8).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
    this.transform.GetChild(1).GetChild(4).GetChild(29).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(1).GetChild(4).GetChild(30).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_label[10] = this.transform.GetChild(2).GetChild(0).GetChild(7).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_title = this.transform.GetChild(2).GetChild(0).GetChild(8).GetComponent<UnityEngine.UI.Text>();
    this.m_input = this.transform.GetChild(2).GetChild(0).GetChild(5).GetChild(0).GetComponent<UIEmojiInput>();
    // ISSUE: method pointer
    this.m_input.onValueChange.AddListener(new UnityAction<string>((object) this, __methodptr(\u003COnOpen\u003Em__EC)));
    UIEmojiInput.OnChangeEvent onValueChange = this.s_input.onValueChange;
    // ISSUE: reference to a compiler-generated field
    if (AllianceHint.\u003C\u003Ef__am\u0024cache46 == null)
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      AllianceHint.\u003C\u003Ef__am\u0024cache46 = new UnityAction<string>((object) null, __methodptr(\u003COnOpen\u003Em__ED));
    }
    // ISSUE: reference to a compiler-generated field
    UnityAction<string> fAmCache46 = AllianceHint.\u003C\u003Ef__am\u0024cache46;
    onValueChange.AddListener(fAmCache46);
    this.s_input.characterLimit = 20;
    this.m_error = this.transform.GetChild(2).GetChild(0).GetChild(9).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_error.font = GUIManager.Instance.GetTTFFont();
    this.m_button = this.transform.GetChild(2).GetChild(0).GetChild(4).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_button.font = GUIManager.Instance.GetTTFFont();
    this.m_button.text = this.DM.mStringTable.GetStringByID(4715U);
    this.m_content = this.transform.GetChild(2).GetChild(0).GetChild(5).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.m_content.font = GUIManager.Instance.GetTTFFont();
    this.m_descript = this.transform.GetChild(2).GetChild(0).GetChild(13).GetComponent<UnityEngine.UI.Text>();
    this.m_descript.font = GUIManager.Instance.GetTTFFont();
    this.Invalid = this.transform.GetChild(2).GetChild(0).GetChild(9);
    this.Tick = this.transform.GetChild(2).GetChild(0).GetChild(10);
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    for (int index = 0; index < 10; ++index)
    {
      ((Behaviour) this.m_label[index]).enabled = false;
      ((Behaviour) this.m_label[index]).enabled = true;
    }
    if (GUIManager.Instance.IsArabic)
    {
      this.Tick.gameObject.AddComponent<ArabicItemTextureRot>();
      this.transform.GetChild(1).GetChild(4).GetChild(27).gameObject.AddComponent<ArabicItemTextureRot>();
      this.transform.GetChild(1).GetChild(4).GetChild(28).gameObject.AddComponent<ArabicItemTextureRot>();
    }
    if (arg1 <= 0)
      return;
    this.UpdateUI(arg1, 0);
    this.door.UpdateUI(1, 2);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    this.ItemTag[panelObjectIdx][0] = item.transform.GetChild(2).GetChild(9).GetComponent<UnityEngine.UI.Text>();
    this.ItemTag[panelObjectIdx][0].font = this.Font;
    this.ItemTag[panelObjectIdx][0].text = "[" + AllianceHint.Search[dataIdx].Tag + "]  " + AllianceHint.Search[dataIdx].Name;
    this.ItemTag[panelObjectIdx][1] = item.transform.GetChild(2).GetChild(11).GetComponent<UnityEngine.UI.Text>();
    this.ItemTag[panelObjectIdx][1].font = this.Font;
    this.Path.Length = 0;
    this.ItemTag[panelObjectIdx][1].text = AllianceHint.Search[dataIdx].Power.ToString("N0");
    this.ItemTag[panelObjectIdx][2] = item.transform.GetChild(2).GetChild(12).GetComponent<UnityEngine.UI.Text>();
    this.ItemTag[panelObjectIdx][2].font = this.Font;
    this.Path.Length = 0;
    this.ItemTag[panelObjectIdx][2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4723U), (object) AllianceHint.Search[dataIdx].GiftLv).ToString();
    this.ItemTag[panelObjectIdx][3] = item.transform.GetChild(2).GetChild(13).GetComponent<UnityEngine.UI.Text>();
    this.ItemTag[panelObjectIdx][3].font = this.Font;
    this.Path.Length = 0;
    this.ItemTag[panelObjectIdx][3].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(795U), (object) AllianceHint.Search[dataIdx].Member).ToString();
    this.ItemTag[panelObjectIdx][4] = item.transform.GetChild(2).GetChild(14).GetComponent<UnityEngine.UI.Text>();
    this.ItemTag[panelObjectIdx][4].font = this.Font;
    this.ItemTag[panelObjectIdx][4].text = DataManager.Instance.GetLanguageStr(AllianceHint.Search[dataIdx].Language);
    this.Transformer = item.transform.GetChild(2).GetChild(1);
    ushort emblem = AllianceHint.Search[dataIdx].Emblem;
    int num = (int) emblem & 7;
    int mBadge = ((int) emblem >> 3 & 7) * 8 + num + 1;
    if (mBadge > 64)
      mBadge = 64;
    int mTotem = ((int) emblem >> 6 & 63) + 1;
    if (mTotem > 64)
      mTotem = 64;
    GUIManager.Instance.SetBadgeTotemImg(this.Transformer, mBadge, mTotem);
    UIButton component1 = item.transform.GetChild(2).GetChild(7).GetComponent<UIButton>();
    component1.m_BtnID1 = dataIdx;
    component1.m_BtnID2 = 1;
    component1.m_Handler = (IUIButtonClickHandler) this;
    UIButton component2 = item.transform.GetChild(2).GetChild(8).GetComponent<UIButton>();
    component2.m_BtnID1 = dataIdx;
    component2.m_BtnID2 = 2;
    component2.m_Handler = (IUIButtonClickHandler) this;
    this.ItemTag[panelObjectIdx][5] = ((Component) component2).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
    if (AllianceHint.SetRequest == (byte) 13)
    {
      ((Component) component2).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4724U);
      component2.image.sprite = this.USArray.GetSprite(0);
    }
    else
    {
      if (AllianceHint.Search[dataIdx].Approval > (byte) 0)
        ((Component) component2).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4707U);
      else
        ((Component) component2).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4706U);
      component2.image.sprite = this.USArray.GetSprite(AllianceHint.Search[dataIdx].Approval <= (byte) 0 ? 0 : 1);
      for (AllianceHint.Search[100].ID = 0U; AllianceHint.Search[100].ID < (uint) this.DM.RoleAlliance.Apply && this.DM.RoleAlliance.ApplyList != null; ++AllianceHint.Search[100].ID)
      {
        if ((int) this.DM.RoleAlliance.ApplyList[(IntPtr) AllianceHint.Search[100].ID] == (int) AllianceHint.Search[dataIdx].ID)
        {
          ((Component) component2).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4708U);
          component2.image.sprite = this.USArray.GetSprite(2);
        }
      }
    }
    if (!(bool) (UnityEngine.Object) this.m_panel[panelObjectIdx])
    {
      this.m_panel[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      item.transform.GetChild(3).GetChild(7).GetComponent<UnityEngine.UI.Text>().font = this.Font;
      ((Component) component2).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().font = this.Font;
    }
    item.transform.GetChild(2).gameObject.SetActive(AllianceHint.Search[dataIdx].ID > 0U);
    item.transform.GetChild(3).gameObject.SetActive(AllianceHint.Search[dataIdx].ID == 0U);
    if (AllianceHint.Proceeding != 1L || AllianceHint.Pending != 0L || AllianceHint.Search[dataIdx].ID != 0U)
      return;
    this.UpdateUI(22, 0);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || arg1 >= AllianceHint.SearchNum)
      return;
    this.RevokeApplyList(AllianceHint.Search[arg1].ID);
  }

  private void SetFilterName(byte Filter)
  {
    AllianceHint.FilterIdx = Filter;
    this.transform.GetChild(1).GetChild(3).GetChild(17).GetChild(1).gameObject.SetActive(Filter == (byte) 0);
    this.transform.GetChild(1).GetChild(3).GetChild(20).gameObject.SetActive(AllianceHint.FilterIdx > (byte) 0);
    if (AllianceHint.FilterIdx > (byte) 0)
      this.transform.GetChild(1).GetChild(3).GetChild(17).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.GetLanguageStr(Filter);
    else
      this.transform.GetChild(1).GetChild(3).GetChild(17).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = string.Empty;
  }

  private static void SearchChange(string input)
  {
    AllianceHint.FilterName = input;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceHint, 15);
  }

  private void ValueChange(string input)
  {
    if (input != string.Empty)
      AllianceHint.ValueChanged();
    this.SetLimit(input);
  }

  public void RevokeApplyList(uint revoke)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    GUIManager.Instance.ShowUILock(EUILock.AllianceCreate);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_USER_CANCELAPPLY;
    messagePacket.AddSeqId();
    messagePacket.Add(revoke);
    messagePacket.Send();
  }

  public void RequestApplyList()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_APPLYALLIANCELIST;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public override void OnClose()
  {
    ((UnityEventBase) this.m_input.onValueChange).RemoveAllListeners();
    ((UnityEventBase) this.s_input.onValueChange).RemoveAllListeners();
    if ((bool) (UnityEngine.Object) this.m_scroll)
    {
      AllianceHint.Scrolling = this.SearchRT.anchoredPosition.y;
      AllianceHint.Positioning = this.m_scroll.GetTopIdx();
    }
    this.door = (Door) null;
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (AllianceHint.Search == null)
      return;
    if (arg2 > 2)
    {
      if (arg2 > 3 && (((Component) this.NameTick).gameObject.activeInHierarchy || ((Component) this.NameInvalid).gameObject.activeInHierarchy || this.DM.SetSelectRequest > 0) || arg2 == 3)
      {
        if (AllianceHint.GenuineName > (byte) 0)
        {
          ((Component) this.NameInvalid).gameObject.SetActive(true);
          ((Component) this.NameTick).gameObject.SetActive(false);
        }
        else if (AllianceHint.ValidName != string.Empty)
          ((Component) this.NameTick).gameObject.SetActive(true);
      }
      if (arg2 > 3 && (this.TagTick.gameObject.activeInHierarchy || this.TagInvalid.gameObject.activeInHierarchy || this.DM.SetSelectRequest > 0) || arg2 == 3)
      {
        if (AllianceHint.GenuineTag > (byte) 0)
        {
          this.TagInvalid.gameObject.SetActive(true);
          this.TagTick.gameObject.SetActive(false);
        }
        else if (AllianceHint.ValidTag != string.Empty)
          this.TagTick.gameObject.SetActive(true);
      }
    }
    else if (arg2 > 1)
    {
      this.Tick.gameObject.SetActive(arg1 < 1);
      this.Invalid.gameObject.SetActive(arg1 > 0);
      this.m_error.text = this.DM.mStringTable.GetStringByID((uint) (arg1 + (this.DM.SetSelectRequest != 7 ? 435 : 433)));
      ((Graphic) this.m_button).color = arg1 <= 0 ? Color.white : ((Graphic) this.m_error).color;
      if (!this.transform.GetChild(2).gameObject.activeInHierarchy)
        this.UpdateUI(0, 3);
    }
    else if (arg2 > 0 && arg1 > 0)
    {
      if (arg1 < 6)
        this.CheckAll();
      switch (arg1)
      {
        case 5:
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(5811U), (ushort) byte.MaxValue);
          break;
        case 12:
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(9583U), (ushort) byte.MaxValue);
          break;
        default:
          if (arg1 < 9)
          {
            GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID((uint) (arg1 + 433)), (ushort) byte.MaxValue);
            break;
          }
          break;
      }
    }
    if (arg2 > 0)
      return;
    if (arg1 > 10 & arg1 < 14)
    {
      if (GUIManager.Instance.bOpenOnIPhoneX)
        ((Behaviour) this.transform.GetChild(1).GetChild(5).GetComponent<Image>()).enabled = false;
      RectTransform transform = (RectTransform) this.transform;
      Vector2 zero = Vector2.zero;
      ((RectTransform) this.transform).offsetMax = zero;
      Vector2 vector2 = zero;
      transform.offsetMin = vector2;
    }
    switch (arg1)
    {
      case 0:
      case 1:
      case 5:
      case 6:
      case 7:
      case 8:
        this.Transformer = this.transform.GetChild(1);
        this.Transformer.GetChild(4).GetChild(15).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Name = this.Transformer.GetChild(4).GetChild(15).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.Name.font = GUIManager.Instance.GetTTFFont();
        this.Name.text = !(AllianceHint.ValidName != string.Empty) ? this.DM.mStringTable.GetStringByID(4613U) : AllianceHint.ValidName;
        ((Graphic) this.Name).color = !(AllianceHint.ValidName != string.Empty) ? ((Graphic) this.Transformer.GetChild(4).GetChild(15).GetChild(1).GetComponent<UnityEngine.UI.Text>()).color : ((Graphic) this.Transformer.GetChild(4).GetChild(20).GetChild(0).GetComponent<UnityEngine.UI.Text>()).color;
        this.Transformer.GetChild(4).GetChild(17).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Tag = this.Transformer.GetChild(4).GetChild(17).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.Tag.font = GUIManager.Instance.GetTTFFont();
        this.Tag.text = !(AllianceHint.ValidTag != string.Empty) ? this.DM.mStringTable.GetStringByID(4617U) : AllianceHint.ValidTag;
        ((Graphic) this.Tag).color = !(AllianceHint.ValidTag != string.Empty) ? ((Graphic) this.Transformer.GetChild(4).GetChild(17).GetChild(1).GetComponent<UnityEngine.UI.Text>()).color : ((Graphic) this.Transformer.GetChild(4).GetChild(20).GetChild(0).GetComponent<UnityEngine.UI.Text>()).color;
        this.Transformer.GetChild(4).GetChild(4).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4612U);
        this.Transformer.GetChild(4).GetChild(5).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4616U);
        this.Transformer.GetChild(4).GetChild(22).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Transformer.GetChild(4).GetChild(20).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
        this.Transformer.GetChild(4).GetChild(21).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
        this.Transformer.GetChild(4).GetChild(20).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = DataManager.Instance.GetLanguageStr(AllianceHint.GenuineLang);
        this.Transformer.GetChild(4).GetChild(22).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
        this.Transformer.GetChild(4).GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
        this.TagInvalid = this.Transformer.GetChild(4).GetChild(26);
        this.NameInvalid = (RectTransform) this.Transformer.GetChild(4).GetChild(25);
        this.NameTick = (RectTransform) this.Transformer.GetChild(4).GetChild(27);
        this.TagTick = this.Transformer.GetChild(4).GetChild(28);
        this.Transformer = this.Transformer.GetChild(4).GetChild(18).GetChild(1);
        ushort curSelectBadge = this.DM.CurSelectBadge;
        int num = (int) curSelectBadge & 7;
        int mBadge = ((int) curSelectBadge >> 3 & 7) * 8 + num + 1;
        if (mBadge > 64)
          mBadge = 64;
        int mTotem = ((int) curSelectBadge >> 6 & 63) + 1;
        if (mTotem > 64)
          mTotem = 64;
        GUIManager.Instance.SetBadgeTotemImg(this.Transformer, mBadge, mTotem);
        this.UpdateUI(0, 4);
        break;
      case 10:
        if (AllianceHint.SearchNum > 0)
        {
          for (int index = 0; index < AllianceHint.SearchNum; ++index)
          {
            if (AllianceHint.SetRequest != (byte) 13)
              AllianceHint.Search[index].ID = 0U;
            if (this.ItemsHeight.Count < AllianceHint.SearchNum)
              this.ItemsHeight.Add(96f);
          }
          if (this.ItemsHeight.Count > AllianceHint.SearchNum)
            this.ItemsHeight.RemoveRange(AllianceHint.SearchNum - 1, this.ItemsHeight.Count - AllianceHint.SearchNum);
        }
        else
        {
          this.ItemsHeight.Clear();
          AllianceHint.SearchIdx = (byte) 0;
        }
        if ((bool) (UnityEngine.Object) this.m_scroll)
        {
          this.m_scroll.gameObject.SetActive(true);
          this.m_scroll.AddNewDataHeight(this.ItemsHeight);
        }
        ((Component) this.m_default[2]).transform.parent.gameObject.SetActive(AllianceHint.SearchNum == 0);
        break;
      case 11:
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(7).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
        ((Behaviour) this.transform.GetComponent<Image>()).enabled = false;
        this.Transformer = this.transform.GetChild(1).GetChild(3);
        this.Transformer.GetChild(3).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4701U);
        this.Transformer.GetChild(3).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = this.Font;
        this.m_label[11] = this.Transformer.GetChild(3).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.Transformer.GetChild(4).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4702U);
        this.Transformer.GetChild(4).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = this.Font;
        this.m_label[12] = this.Transformer.GetChild(4).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.Transformer.GetChild(5).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4704U);
        this.Transformer.GetChild(5).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = this.Font;
        this.m_label[13] = this.Transformer.GetChild(5).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        if ((bool) (UnityEngine.Object) this.Transformer.GetChild(15).GetChild(0).GetComponent<UnityEngine.UI.Text>())
        {
          this.Transformer.GetChild(15).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = this.Font;
          this.m_label[14] = this.Transformer.GetChild(15).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        }
        if ((bool) (UnityEngine.Object) this.Transformer.GetChild(15).GetChild(1).GetComponent<UnityEngine.UI.Text>())
        {
          this.Transformer.GetChild(15).GetChild(1).GetComponent<UnityEngine.UI.Text>().font = this.Font;
          this.m_label[15] = this.Transformer.GetChild(15).GetChild(1).GetComponent<UnityEngine.UI.Text>();
        }
        this.Transformer.GetChild(16).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Transformer.GetChild(17).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Transformer.GetChild(17).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = this.Font;
        this.m_label[16] = this.Transformer.GetChild(17).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.Transformer.GetChild(17).GetChild(1).GetComponent<UnityEngine.UI.Text>().font = this.Font;
        this.m_label[17] = this.Transformer.GetChild(17).GetChild(1).GetComponent<UnityEngine.UI.Text>();
        this.m_PageBack = this.Transformer.GetChild(8).GetChild(0).GetComponent<Image>();
        this.Transformer.GetChild(20).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Transformer.GetChild(21).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Transformer.GetChild(8).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Transformer.GetChild(9).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Transformer.GetChild(10).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.transform.GetChild(1).GetChild(8).gameObject.SetActive(true);
        if (!AllianceHint.Shooting && !AllianceHint.Clearing)
        {
          AllianceHint.Shooting = true;
          this.ItemsHeight.Clear();
          if ((bool) (UnityEngine.Object) this.m_scroll)
            this.m_scroll.AddNewDataHeight(this.ItemsHeight);
          this.s_input.text = AllianceHint.FilterName;
          this.Path.Length = 0;
          AllianceHint.Proceeding = 1L;
          ((Component) this.m_default[2]).transform.parent.gameObject.SetActive(false);
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_SEARCH;
          messagePacket.AddSeqId();
          if (AllianceHint.SeekName.Length > 0 && AllianceHint.SeekLang > (byte) 0)
          {
            messagePacket.Add(AllianceHint.SeekLang);
            messagePacket.Add((byte) AllianceHint.SeekName.Length);
            messagePacket.Add(AllianceHint.SeekName, AllianceHint.SeekName.Length);
            this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(735U), (object) AllianceHint.SeekName, (object) this.DM.GetLanguageStr(AllianceHint.SeekLang)).ToString();
          }
          else if (AllianceHint.SeekName.Length > 0)
          {
            messagePacket.Add(AllianceHint.SeekLang);
            messagePacket.Add((byte) AllianceHint.SeekName.Length);
            messagePacket.Add(AllianceHint.SeekName, AllianceHint.SeekName.Length);
            this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4709U), (object) AllianceHint.SeekName).ToString();
          }
          else if (AllianceHint.SeekKind > (byte) 20)
          {
            byte seekLang = AllianceHint.SeekLang;
            switch (seekLang)
            {
              case 21:
              case 22:
              case 23:
              case 24:
              case 27:
              case 31:
              case 33:
              case 37:
              case 39:
              case 40:
              case 41:
              case 42:
label_50:
                messagePacket.Add(AllianceHint.SeekLang);
                messagePacket.Add(AllianceHint.SeekKind);
                this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4709U), (object) this.DM.GetLanguageStr(AllianceHint.SeekLang)).ToString();
                break;
              default:
                switch (seekLang)
                {
                  case 11:
                  case 12:
                  case 15:
                    goto label_50;
                  default:
                    if (seekLang != (byte) 2 && seekLang != (byte) 7)
                    {
                      AllianceHint.SeekLang = (byte) 12;
                      goto label_50;
                    }
                    else
                      goto label_50;
                }
            }
          }
          else if (AllianceHint.SeekLang > (byte) 0)
          {
            messagePacket.Add(AllianceHint.SeekLang);
            this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4709U), (object) this.DM.GetLanguageStr(AllianceHint.SeekLang)).ToString();
          }
          else
          {
            messagePacket.Add(AllianceHint.SeekLang);
            ((Component) this.m_default[2]).transform.parent.gameObject.SetActive(false);
          }
          if ((int) AllianceHint.SeekKind == AllianceHint.SeekName.Length)
          {
            this.Path.Length = 0;
            this.m_filter.text = AllianceHint.SearchLang = AllianceHint.SeekLang <= (byte) 0 ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703U), (object) this.DM.GetLanguageStr(AllianceHint.SeekLang)).ToString();
            this.Path.Length = 0;
            this.m_search.text = AllianceHint.SearchName = AllianceHint.SeekName.Length <= 0 ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703U), (object) AllianceHint.SeekName).ToString();
          }
          messagePacket.Send();
        }
        else if (AllianceHint.SearchNum == 0)
        {
          this.Path.Length = 0;
          ((Component) this.m_default[2]).transform.parent.gameObject.SetActive(true);
          if (AllianceHint.Clearing)
            this.m_default[2].text = this.DM.mStringTable.GetStringByID(736U);
          else if (AllianceHint.SeekName.Length > 0 && AllianceHint.SeekLang > (byte) 0)
            this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(735U), (object) AllianceHint.SeekName, (object) this.DM.GetLanguageStr(AllianceHint.SeekLang)).ToString();
          else if (AllianceHint.SeekName.Length > 0)
            this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4709U), (object) AllianceHint.SeekName).ToString();
          else if (AllianceHint.SeekLang > (byte) 0)
            this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4709U), (object) this.DM.GetLanguageStr(AllianceHint.SeekLang)).ToString();
          else
            ((Component) this.m_default[2]).transform.parent.gameObject.SetActive(false);
        }
        else
          ((Component) this.m_default[2]).transform.parent.gameObject.SetActive(false);
        this.Transformer.GetChild(16).gameObject.SetActive(AllianceHint.FilterName.Length > 0);
        this.SetFilterName(AllianceHint.FilterIdx);
        if (!(bool) (UnityEngine.Object) this.m_scroll)
        {
          this.m_scroll = this.transform.GetChild(1).GetChild(8).GetComponent<ScrollPanel>();
          this.m_scroll.IntiScrollPanel(420f, 3f, 4f, this.ItemsHeight, 7, (IUpDateScrollPanel) this);
          this.SearchRT = this.m_scroll.transform.GetChild(0).GetComponent<RectTransform>();
          this.m_scroll.AddNewDataHeight(this.ItemsHeight);
          this.m_panel = new ScrollPanelItem[7];
          if (this.DM.SetSelectRequest == 11 || this.DM.SetSelectRequest == 41)
          {
            this.s_input.text = AllianceHint.FilterName;
            for (int index = 0; index < AllianceHint.SearchNum; ++index)
              this.ItemsHeight.Add(96f);
            this.m_scroll.AddNewDataHeight(this.ItemsHeight);
            this.m_scroll.GoTo(AllianceHint.Positioning, AllianceHint.Scrolling);
          }
          this.Join.sizeDelta = this.SearchSize;
          ((Transform) this.Join).localPosition = this.SearchPosition;
        }
        else
        {
          this.Join.sizeDelta = this.SearchSize;
          ((Transform) this.Join).localPosition = this.SearchPosition;
        }
        DataManager.Instance.SetSelectRequest = arg1;
        AllianceHint.SetRequest = (byte) arg1;
        AllianceHint.CheckTime = 0.0f;
        AllianceHint.Pulling = (byte) 0;
        break;
      case 12:
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(7).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(4).gameObject.SetActive(true);
        ((Behaviour) this.transform.GetComponent<Image>()).enabled = false;
        this.transform.GetChild(1).GetChild(8).gameObject.SetActive(false);
        this.Transformer = this.transform.GetChild(1);
        this.Transformer.GetChild(4).GetChild(1).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Transformer.GetChild(4).GetChild(2).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Transformer.GetChild(4).GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4620U);
        this.Transformer.GetChild(4).GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
        this.m_label[18] = this.Transformer.GetChild(4).GetChild(1).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.Transformer.GetChild(4).GetChild(2).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4611U);
        this.Transformer.GetChild(4).GetChild(2).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
        this.m_label[19] = this.Transformer.GetChild(4).GetChild(2).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.Transformer.GetChild(4).GetChild(3).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4611U);
        this.Transformer.GetChild(4).GetChild(3).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
        this.m_label[20] = this.Transformer.GetChild(4).GetChild(3).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.Transformer.GetChild(4).GetChild(4).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4612U);
        this.Transformer.GetChild(4).GetChild(4).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
        this.m_label[21] = this.Transformer.GetChild(4).GetChild(4).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.Transformer.GetChild(4).GetChild(5).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4616U);
        this.Transformer.GetChild(4).GetChild(5).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
        this.m_label[22] = this.Transformer.GetChild(4).GetChild(5).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.Transformer.GetChild(4).GetChild(6).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4619U);
        this.Transformer.GetChild(4).GetChild(6).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
        this.m_label[23] = this.Transformer.GetChild(4).GetChild(6).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.Transformer.GetChild(4).GetChild(20).GetChild(1).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4622U);
        this.Transformer.GetChild(4).GetChild(20).GetChild(1).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
        this.m_label[24] = this.Transformer.GetChild(4).GetChild(20).GetChild(1).GetComponent<UnityEngine.UI.Text>();
        this.Transformer.GetChild(4).GetChild(21).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4621U);
        this.Transformer.GetChild(4).GetChild(21).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
        this.m_label[25] = this.Transformer.GetChild(4).GetChild(21).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.Transformer.GetChild(4).GetChild(22).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4623U);
        this.Transformer.GetChild(4).GetChild(22).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
        this.m_label[26] = this.Transformer.GetChild(4).GetChild(22).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.m_PageBack = this.Transformer.GetChild(4).GetChild(10).GetChild(0).GetComponent<Image>();
        this.Transformer.GetChild(4).GetChild(8).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Transformer.GetChild(4).GetChild(9).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Transformer.GetChild(4).GetChild(10).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        DataManager.Instance.SetSelectRequest = arg1;
        AllianceHint.SetRequest = (byte) arg1;
        AllianceHint.CheckTime = 0.0f;
        this.UpdateUI(1, 0);
        break;
      case 13:
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(7).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
        ((Behaviour) this.transform.GetComponent<Image>()).enabled = false;
        this.Transformer = this.transform.GetChild(1).GetChild(7);
        this.Transformer.GetChild(3).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4722U);
        this.Transformer.GetChild(3).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = this.Font;
        this.m_PageBack = this.Transformer.GetChild(9).GetChild(0).GetComponent<Image>();
        this.m_label[27] = this.Transformer.GetChild(3).GetChild(0).GetComponent<UnityEngine.UI.Text>();
        this.Transformer.GetChild(8).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Transformer.GetChild(9).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Transformer.GetChild(10).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.transform.GetChild(1).GetChild(8).gameObject.SetActive(true);
        if (!(bool) (UnityEngine.Object) this.m_scroll)
        {
          this.m_scroll = this.transform.GetChild(1).GetChild(8).GetComponent<ScrollPanel>();
          this.m_scroll.IntiScrollPanel(420f, 3f, 4f, this.ItemsHeight, 7, (IUpDateScrollPanel) this);
          this.SearchRT = this.m_scroll.transform.GetChild(0).GetComponent<RectTransform>();
          this.m_scroll.AddNewDataHeight(this.ItemsHeight);
          this.m_panel = new ScrollPanelItem[7];
        }
        else
        {
          this.ItemsHeight.Clear();
          this.m_scroll.AddNewDataHeight(this.ItemsHeight);
          this.Join.sizeDelta = this.ApplyList.sizeDelta;
          ((Transform) this.Join).localPosition = ((Transform) this.ApplyList).localPosition;
        }
        this.RequestApplyList();
        DataManager.Instance.SetSelectRequest = arg1;
        AllianceHint.SetRequest = (byte) arg1;
        AllianceHint.CheckTime = 0.0f;
        break;
      case 15:
        this.transform.GetChild(1).GetChild(3).GetChild(16).gameObject.SetActive(AllianceHint.FilterName.Length > 0);
        break;
      case 21:
        for (AllianceHint.SearchPage = 0; AllianceHint.SearchPage < AllianceHint.SearchNum && (bool) (UnityEngine.Object) this.m_scroll && AllianceHint.SearchPage < this.m_panel.Length && (bool) (UnityEngine.Object) this.m_panel[AllianceHint.SearchPage] && this.m_panel[AllianceHint.SearchPage].m_BtnID1 >= 0; ++AllianceHint.SearchPage)
          this.UpDateRowItem(((Component) this.m_panel[AllianceHint.SearchPage]).gameObject, this.m_panel[AllianceHint.SearchPage].m_BtnID1, 0, 0);
        break;
      case 22:
        if ((AllianceHint.SearchNum / 10 > (int) AllianceHint.SearchIdx || AllianceHint.SearchNum / 10 == (int) AllianceHint.SearchIdx && AllianceHint.SearchNum % 10 != 0) && NetworkManager.Connected())
        {
          AllianceHint.Pending = (long) AllianceHint.SearchIdx++;
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_SEARCHRESULT;
          messagePacket.AddSeqId();
          messagePacket.Add(AllianceHint.SearchIdx);
          messagePacket.Send();
          break;
        }
        if (AllianceHint.SetRequest != (byte) 11)
          break;
        this.Revert = true;
        break;
      case 23:
        if (!(bool) (UnityEngine.Object) this.m_scroll)
          break;
        this.m_scroll.gameObject.SetActive(false);
        break;
      case 24:
        if (!(bool) (UnityEngine.Object) this.m_scroll || AllianceHint.SetRequest != (byte) 11)
          break;
        this.m_scroll.gameObject.SetActive(true);
        break;
      case 25:
        if (!(bool) (UnityEngine.Object) this.m_scroll)
          break;
        this.m_scroll.AddItem(96f);
        break;
      case 26:
        this.door.AllianceOnClick();
        break;
    }
  }

  public static void RecvAllianceCreate(MessagePacket MP)
  {
    GUIWindow menu1 = GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceHint);
    Protocol protocol = MP.Protocol;
    switch (protocol)
    {
      case Protocol._MSG_RESP_ALLIANCE_APPLY:
        AllianceHint.Pulling = (byte) 0;
        byte num = MP.ReadByte();
        if (num == (byte) 0)
        {
          if (DataManager.Instance.RoleAlliance.Apply < (byte) 10)
          {
            if (DataManager.Instance.RoleAlliance.ApplyList == null)
              DataManager.Instance.RoleAlliance.ApplyList = new uint[10];
            DataManager.Instance.RoleAlliance.ApplyList[(int) DataManager.Instance.RoleAlliance.Apply++] = MP.ReadUInt();
            if ((bool) (UnityEngine.Object) menu1)
              menu1.UpdateUI(21, 0);
            GUIManager.Instance.AddHUDMessage(string.Format(DataManager.Instance.mStringTable.GetStringByID(599U), (object) MP.ReadString(20)), (ushort) byte.MaxValue);
          }
          GUIManager.Instance.UpdateUI(EGUIWindow.UIAlliance_publicinfo, 2);
        }
        else if (num > (byte) 1)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID((uint) num + 414U), (ushort) byte.MaxValue);
        }
        else
        {
          DataManager.Instance.SendAskKind = 3;
          DataManager.Instance.LastTime = DataManager.Instance.ServerTime;
          DataManager.Instance.SendAskData((byte) 1, (byte) 1, DataManager.Instance.SendAskKind, 0L, DataManager.Instance.ServerTime + 60L);
        }
        if (num == (byte) 6 && (bool) (UnityEngine.Object) menu1)
        {
          AllianceHint.Shooting = false;
          menu1.UpdateUI((int) AllianceHint.SetRequest, 0);
        }
        GUIManager.Instance.HideUILock(EUILock.AllianceCreate);
        break;
      case Protocol._MSG_RESP_ALLIANCE_USER_CANCELAPPLY:
        GUIManager.Instance.HideUILock(EUILock.AllianceCreate);
        if (MP.ReadByte() == (byte) 0)
        {
          AllianceHint.Search[100].ID = MP.ReadUInt();
          if (DataManager.Instance.RoleAlliance.Apply > (byte) 0 && (bool) (UnityEngine.Object) menu1 && AllianceHint.Search != null)
          {
            for (AllianceHint.SearchPage = 0; AllianceHint.SearchPage < (int) DataManager.Instance.RoleAlliance.Apply; ++AllianceHint.SearchPage)
            {
              if ((int) DataManager.Instance.RoleAlliance.ApplyList[AllianceHint.SearchPage] == (int) AllianceHint.Search[100].ID)
              {
                if ((int) --DataManager.Instance.RoleAlliance.Apply > AllianceHint.SearchPage)
                {
                  Array.Copy((Array) DataManager.Instance.RoleAlliance.ApplyList, AllianceHint.SearchPage + 1, (Array) DataManager.Instance.RoleAlliance.ApplyList, AllianceHint.SearchPage, (int) DataManager.Instance.RoleAlliance.Apply - AllianceHint.SearchPage);
                  if (AllianceHint.SetRequest == (byte) 13)
                  {
                    Array.Copy((Array) AllianceHint.Search, AllianceHint.SearchPage + 1, (Array) AllianceHint.Search, AllianceHint.SearchPage, (int) DataManager.Instance.RoleAlliance.Apply - AllianceHint.SearchPage);
                    break;
                  }
                  break;
                }
                DataManager.Instance.RoleAlliance.ApplyList[AllianceHint.SearchPage] = 0U;
                break;
              }
            }
            if (AllianceHint.SetRequest == (byte) 13 && AllianceHint.SearchNum > 0)
            {
              --AllianceHint.SearchNum;
              menu1.UpdateUI(10, 0);
            }
          }
          DataManager.Instance.RoleAlliance.Apply = MP.ReadByte();
          break;
        }
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4725U), (ushort) byte.MaxValue);
        break;
      default:
        switch (protocol)
        {
          case Protocol._MSG_RESP_ALLIANCE_SEARCH:
            if ((DataManager.msgBuffer[1] = MP.ReadByte()) == byte.MaxValue)
            {
              GUIManager.Instance.HideUILock(EUILock.AllianceCreate);
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(796U), (ushort) byte.MaxValue);
              AllianceHint.SearchIdx = (byte) 0;
            }
            else if ((bool) (UnityEngine.Object) menu1)
            {
              AllianceHint.Pending = (long) (AllianceHint.SearchNum = Mathf.Min((int) DataManager.msgBuffer[1], 100));
              menu1.UpdateUI(10, 0);
            }
            else
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_SearchList, 0, 10);
            if (AllianceHint.SearchNum != 0)
              return;
            GUIManager.Instance.HideUILock(EUILock.AllianceCreate);
            return;
          case Protocol._MSG_RESP_ALLIANCE_SRARCHRESULT:
            GUIManager.Instance.HideUILock(EUILock.AllianceCreate);
            GUIWindow menu2 = GUIManager.Instance.FindMenu(EGUIWindow.UI_SearchList);
            if ((bool) (UnityEngine.Object) menu2)
            {
              if (MP.ReadByte() > (byte) 0 || (AllianceHint.SearchIdx = MP.ReadByte()) == (byte) 0 || AllianceHint.SearchIdx > (byte) 10 || AllianceHint.Search == null)
              {
                AllianceHint.Pending = AllianceHint.Proceeding = (long) (AllianceHint.SearchNum = 0);
                menu2.UpdateUI(1, 10);
                return;
              }
              DataManager.msgBuffer[1] = MP.ReadByte();
              AllianceHint.SearchPage = ((int) AllianceHint.SearchIdx - 1) * 10;
              for (AllianceHint.Pending = 0L; AllianceHint.Pending < (long) Mathf.Min((int) DataManager.msgBuffer[1], 10); ++AllianceHint.Pending)
              {
                AllianceHint.Search[AllianceHint.SearchPage].ID = MP.ReadUInt();
                AllianceHint.Search[AllianceHint.SearchPage].Tag = MP.ReadString(3);
                AllianceHint.Search[AllianceHint.SearchPage].Name = MP.ReadString(20);
                AllianceHint.Search[AllianceHint.SearchPage].Emblem = MP.ReadUShort();
                AllianceHint.Search[AllianceHint.SearchPage].Member = MP.ReadByte();
                AllianceHint.Search[AllianceHint.SearchPage].Language = MP.ReadByte();
                AllianceHint.Search[AllianceHint.SearchPage].GiftLv = MP.ReadByte();
                AllianceHint.Search[AllianceHint.SearchPage].Power = MP.ReadULong();
                AllianceHint.Search[AllianceHint.SearchPage].Approval = MP.ReadByte();
                ++AllianceHint.SearchPage;
              }
              AllianceHint.Pending = 0L;
              menu2.UpdateUI(2, 1);
              return;
            }
            if (!(bool) (UnityEngine.Object) menu1 || MP.ReadByte() > (byte) 0 || (AllianceHint.SearchIdx = MP.ReadByte()) == (byte) 0 || AllianceHint.SearchIdx > (byte) 10 || AllianceHint.Search == null)
            {
              AllianceHint.Pending = AllianceHint.Proceeding = 0L;
              if (!(bool) (UnityEngine.Object) menu1 || AllianceHint.SetRequest != (byte) 11)
                return;
              AllianceHint.SearchNum = 0;
              menu1.UpdateUI(10, 0);
              return;
            }
            DataManager.msgBuffer[1] = MP.ReadByte();
            AllianceHint.SearchPage = ((int) AllianceHint.SearchIdx - 1) * 10;
            for (AllianceHint.Pending = 0L; AllianceHint.Pending < (long) Mathf.Min((int) DataManager.msgBuffer[1], 10); ++AllianceHint.Pending)
            {
              AllianceHint.Search[AllianceHint.SearchPage].ID = MP.ReadUInt();
              AllianceHint.Search[AllianceHint.SearchPage].Tag = MP.ReadString(3);
              AllianceHint.Search[AllianceHint.SearchPage].Name = MP.ReadString(20);
              AllianceHint.Search[AllianceHint.SearchPage].Emblem = MP.ReadUShort();
              AllianceHint.Search[AllianceHint.SearchPage].Member = MP.ReadByte();
              AllianceHint.Search[AllianceHint.SearchPage].Language = MP.ReadByte();
              AllianceHint.Search[AllianceHint.SearchPage].GiftLv = MP.ReadByte();
              AllianceHint.Search[AllianceHint.SearchPage].Power = MP.ReadULong();
              AllianceHint.Search[AllianceHint.SearchPage].Approval = MP.ReadByte();
              ++AllianceHint.SearchPage;
            }
            AllianceHint.Pending = 0L;
            menu1.UpdateUI(21, 0);
            return;
          default:
            if (protocol != Protocol._MSG_RESP_ROLE_PRIZEFLAG)
            {
              if (protocol != Protocol._MSG_RESP_ALLIANCE_APPLYALLIANCELIST || !(bool) (UnityEngine.Object) menu1 || DataManager.Instance.RoleAlliance.ApplyList == null || AllianceHint.Search == null)
                return;
              AllianceHint.SearchNum = (int) (DataManager.Instance.RoleAlliance.Apply = (byte) Mathf.Min((int) MP.ReadByte(), 10));
              for (AllianceHint.SearchPage = 0; AllianceHint.SearchPage < (int) DataManager.Instance.RoleAlliance.Apply; ++AllianceHint.SearchPage)
              {
                DataManager.Instance.RoleAlliance.ApplyList[AllianceHint.SearchPage] = AllianceHint.Search[100].ID = MP.ReadUInt();
                AllianceHint.Search[100].Tag = MP.ReadString(3);
                AllianceHint.Search[100].Name = MP.ReadString(20);
                AllianceHint.Search[100].Emblem = MP.ReadUShort();
                AllianceHint.Search[100].Member = MP.ReadByte();
                AllianceHint.Search[100].Language = MP.ReadByte();
                AllianceHint.Search[100].GiftLv = MP.ReadByte();
                AllianceHint.Search[100].Power = MP.ReadULong();
                AllianceHint.Search[100].Approval = MP.ReadByte();
                if (AllianceHint.SetRequest == (byte) 13)
                {
                  AllianceHint.SearchNum = (int) DataManager.Instance.RoleAlliance.Apply;
                  Array.Copy((Array) AllianceHint.Search, 100, (Array) AllianceHint.Search, AllianceHint.SearchPage, 1);
                }
              }
              menu1.UpdateUI(AllianceHint.SetRequest != (byte) 13 ? 21 : 10, 0);
              return;
            }
            switch (MP.ReadByte())
            {
              case 0:
                GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_TreasureBox, 2, openMode: (byte) 0);
                DataManager.Instance.RoleAttr.PrizeFlag = MP.ReadUInt();
                DataManager.Instance.RoleAttr.Diamond = MP.ReadUInt();
                DataManager.Instance.Resource[4].Stock = MP.ReadUInt();
                DataManager.Instance.RoleAlliance.Money = MP.ReadUInt();
                GameManager.OnRefresh(NetworkNews.Refresh_Item);
                GameManager.OnRefresh(NetworkNews.Refresh_Attr);
                GameManager.OnRefresh(NetworkNews.Refresh_Alliance);
                GameManager.OnRefresh(NetworkNews.Refresh_Resource);
                GameManager.OnRefresh();
                return;
              case 1:
                DataManager instance = DataManager.Instance;
                instance.RoleAttr.PrizeFlag = MP.ReadUInt();
                DataManager.StageDataController.RoleAttrLevelUp(MP, 24);
                instance.RoleAttr.Power = MP.ReadULong();
                instance.Resource[0].Stock = MP.ReadUInt();
                instance.Resource[1].Stock = MP.ReadUInt();
                instance.Resource[2].Stock = MP.ReadUInt();
                instance.Resource[3].Stock = MP.ReadUInt();
                instance.Resource[4].Stock = MP.ReadUInt();
                instance.RoleAttr.VipPoint = MP.ReadUInt();
                instance.RoleAttr.VIPLevel = instance.GetVIPLevel(instance.RoleAttr.VipPoint);
                GameManager.OnRefresh();
                GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_VipLevelUp, (int) DataManager.Instance.RoleAttr.VIPLevel, 2, openMode: (byte) 0);
                return;
              default:
                return;
            }
        }
    }
  }

  public override bool OnBackButtonClick()
  {
    if (this.transform.GetChild(2).gameObject.activeInHierarchy)
    {
      this.transform.GetChild(2).gameObject.SetActive(false);
      if (this.DM.SetSelectRequest == 7)
        AllianceHint.ValidName = this.m_input.text;
      else
        AllianceHint.ValidTag = this.m_input.text;
      this.DM.SetSelectRequest = 0;
      if ((double) AllianceHint.CheckTime > 0.0)
        this.CheckName(this.m_input.text);
      this.UpdateUI(0, 3);
      this.UpdateUI(this.DM.SetSelectRequest, 0);
      return true;
    }
    if (this.transform.GetChild(1).gameObject.activeInHierarchy)
    {
      this.transform.GetChild(1).gameObject.SetActive(false);
      this.transform.GetChild(0).gameObject.SetActive(true);
      ((Behaviour) this.transform.GetComponent<Image>()).enabled = true;
      this.door.UpdateUI(1, 1);
    }
    else
      DataManager.Instance.SetSelectRequest = 0;
    return false;
  }

  protected void Update()
  {
    if ((double) AllianceHint.CheckTime > 0.0 && (double) (AllianceHint.CheckTime -= Time.deltaTime) <= 0.0)
      this.CheckName(this.m_input.text);
    if ((bool) (UnityEngine.Object) this.m_PageBack)
    {
      this.TeaTime += Time.smoothDeltaTime;
      if ((double) this.TeaTime >= 0.0)
      {
        if ((double) this.TeaTime >= 2.0)
          this.TeaTime = 0.0f;
        ((Graphic) this.m_PageBack).color = new Color(1f, 1f, 1f, (double) this.TeaTime <= 1.0 ? this.TeaTime : 2f - this.TeaTime);
      }
    }
    if (!this.Revert)
      return;
    AllianceHint.Shooting = this.Revert = false;
    this.UpdateUI((int) AllianceHint.SetRequest, 0);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        AllianceHint.SearchIdx = (byte) 100;
        GUIManager.Instance.CloseOKCancelBox();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.m_limit != (UnityEngine.Object) null && ((Behaviour) this.m_limit).enabled)
    {
      ((Behaviour) this.m_limit).enabled = false;
      ((Behaviour) this.m_limit).enabled = true;
    }
    if ((UnityEngine.Object) this.m_title != (UnityEngine.Object) null && ((Behaviour) this.m_title).enabled)
    {
      ((Behaviour) this.m_title).enabled = false;
      ((Behaviour) this.m_title).enabled = true;
    }
    if ((UnityEngine.Object) this.m_error != (UnityEngine.Object) null && ((Behaviour) this.m_error).enabled)
    {
      ((Behaviour) this.m_error).enabled = false;
      ((Behaviour) this.m_error).enabled = true;
    }
    if ((UnityEngine.Object) this.m_filter != (UnityEngine.Object) null && ((Behaviour) this.m_filter).enabled)
    {
      ((Behaviour) this.m_filter).enabled = false;
      ((Behaviour) this.m_filter).enabled = true;
    }
    if ((UnityEngine.Object) this.m_search != (UnityEngine.Object) null && ((Behaviour) this.m_search).enabled)
    {
      ((Behaviour) this.m_search).enabled = false;
      ((Behaviour) this.m_search).enabled = true;
    }
    if ((UnityEngine.Object) this.m_button != (UnityEngine.Object) null && ((Behaviour) this.m_button).enabled)
    {
      ((Behaviour) this.m_button).enabled = false;
      ((Behaviour) this.m_button).enabled = true;
    }
    if ((UnityEngine.Object) this.m_content != (UnityEngine.Object) null && ((Behaviour) this.m_content).enabled)
    {
      ((Behaviour) this.m_content).enabled = false;
      ((Behaviour) this.m_content).enabled = true;
    }
    if ((UnityEngine.Object) this.m_descript != (UnityEngine.Object) null && ((Behaviour) this.m_descript).enabled)
    {
      ((Behaviour) this.m_descript).enabled = false;
      ((Behaviour) this.m_descript).enabled = true;
    }
    if ((UnityEngine.Object) this.Name != (UnityEngine.Object) null && ((Behaviour) this.Name).enabled)
    {
      ((Behaviour) this.Name).enabled = false;
      ((Behaviour) this.Name).enabled = true;
    }
    if ((UnityEngine.Object) this.Tag != (UnityEngine.Object) null && ((Behaviour) this.Tag).enabled)
    {
      ((Behaviour) this.Tag).enabled = false;
      ((Behaviour) this.Tag).enabled = true;
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((UnityEngine.Object) this.m_default[index] != (UnityEngine.Object) null && ((Behaviour) this.m_default[index]).enabled)
      {
        ((Behaviour) this.m_default[index]).enabled = false;
        ((Behaviour) this.m_default[index]).enabled = true;
      }
    }
    for (int index1 = 0; index1 < 7; ++index1)
    {
      int index2 = 0;
      for (; index1 < 6; ++index1)
      {
        if ((UnityEngine.Object) this.ItemTag[index1][index2] != (UnityEngine.Object) null && ((Behaviour) this.ItemTag[index1][index2]).enabled)
        {
          ((Behaviour) this.ItemTag[index1][index2]).enabled = false;
          ((Behaviour) this.ItemTag[index1][index2]).enabled = true;
        }
      }
    }
    for (int index = 0; index < 28; ++index)
    {
      if ((UnityEngine.Object) this.m_label[index] != (UnityEngine.Object) null && ((Behaviour) this.m_label[index]).enabled)
      {
        ((Behaviour) this.m_label[index]).enabled = false;
        ((Behaviour) this.m_label[index]).enabled = true;
      }
    }
    if ((UnityEngine.Object) this.m_input != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.m_input.textComponent != (UnityEngine.Object) null && ((Behaviour) this.m_input.textComponent).enabled)
      {
        ((Behaviour) this.m_input.textComponent).enabled = false;
        ((Behaviour) this.m_input.textComponent).enabled = true;
      }
      if ((UnityEngine.Object) this.m_input.placeholder != (UnityEngine.Object) null && ((Behaviour) this.m_input.placeholder).enabled)
      {
        ((Behaviour) this.m_input.placeholder).enabled = false;
        ((Behaviour) this.m_input.placeholder).enabled = true;
      }
    }
    if (!((UnityEngine.Object) this.s_input != (UnityEngine.Object) null))
      return;
    if ((UnityEngine.Object) this.s_input.textComponent != (UnityEngine.Object) null && ((Behaviour) this.s_input.textComponent).enabled)
    {
      ((Behaviour) this.s_input.textComponent).enabled = false;
      ((Behaviour) this.s_input.textComponent).enabled = true;
    }
    if (!((UnityEngine.Object) this.s_input.placeholder != (UnityEngine.Object) null) || !((Behaviour) this.s_input.placeholder).enabled)
      return;
    ((Behaviour) this.s_input.placeholder).enabled = false;
    ((Behaviour) this.s_input.placeholder).enabled = true;
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID2 > 0)
    {
      if (AllianceHint.Pulling > (byte) 0)
        return;
      switch (sender.m_BtnID2)
      {
        case 1:
          this.DM.SetSelectRequest = 41;
          AllianceHint.Positioning = this.m_scroll.GetTopIdx();
          AllianceHint.Scrolling = this.SearchRT.anchoredPosition.y;
          this.DM.AllianceView.Id = AllianceHint.Search[sender.m_BtnID1].ID;
          this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5);
          break;
        case 2:
          if (AllianceHint.SetRequest == (byte) 13)
          {
            GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4726U), this.DM.mStringTable.GetStringByID(4727U), sender.m_BtnID1, YesText: this.DM.mStringTable.GetStringByID(4728U), NoText: this.DM.mStringTable.GetStringByID(4729U));
            break;
          }
          this.door.AllianceOnJoin(AllianceHint.Search[sender.m_BtnID1].ID, AllianceHint.Search[sender.m_BtnID1].Approval);
          AllianceHint.Pulling = (byte) sender.m_BtnID2;
          break;
      }
    }
    else if (sender.m_BtnID1 == 1)
    {
      if (this.DM.IsNewbie())
      {
        GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(438U), (ushort) byte.MaxValue);
      }
      else
      {
        this.UpdateUI(12, 0);
        this.door.UpdateUI(1, 2);
      }
    }
    else if (sender.m_BtnID1 == 2)
    {
      this.UpdateUI(11, 0);
      this.door.UpdateUI(1, 2);
    }
    else if (sender.m_BtnID1 == 3)
    {
      if (!(bool) (UnityEngine.Object) this.door || this.OnBackButtonClick())
        return;
      this.door.CloseMenu();
    }
    else if (sender.m_BtnID1 == 4)
    {
      if (this.DM.IsNewbie())
      {
        GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(438U), (ushort) byte.MaxValue);
      }
      else
      {
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_CREATE;
        messagePacket.AddSeqId();
        messagePacket.Add((byte) Encoding.UTF8.GetByteCount(AllianceHint.ValidName));
        messagePacket.Add(AllianceHint.ValidName, 20);
        messagePacket.Add(AllianceHint.ValidTag, 3);
        messagePacket.Add(this.DM.CurSelectBadge);
        messagePacket.Add(AllianceHint.GenuineLang);
        messagePacket.Send();
      }
    }
    else if (sender.m_BtnID1 == 5)
    {
      AllianceHint.Shooting = false;
      DataManager.Instance.SetSelectRequest = sender.m_BtnID1;
      this.door.OpenMenu(EGUIWindow.UIAlliance_Badge);
    }
    else if (sender.m_BtnID1 == 6)
    {
      AllianceHint.Shooting = false;
      DataManager.Instance.CurSelectLanguage = AllianceHint.GenuineLang;
      DataManager.Instance.SetSelectLanguage = 1;
      DataManager.Instance.SetSelectRequest = sender.m_BtnID1;
      this.door.OpenMenu(EGUIWindow.UI_LanguageSelect);
    }
    else if (sender.m_BtnID1 == 7)
    {
      this.transform.GetChild(2).gameObject.SetActive(true);
      this.transform.GetChild(2).GetChild(0).GetChild(4).GetComponent<UIButton>().m_BtnID1 = 3;
      this.transform.GetChild(2).GetChild(0).GetChild(4).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.transform.GetChild(2).GetChild(0).GetChild(11).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      UnityEngine.UI.Text text = this.m_label[10];
      string stringById = this.DM.mStringTable.GetStringByID(4612U);
      this.m_title.text = stringById;
      string str = stringById;
      text.text = str;
      this.m_descript.text = this.DM.mStringTable.GetStringByID(4615U);
      AllianceHint.Checking = Protocol._MSG_REQUEST_ALLIANCE_NAMECHACK;
      this.Invalid.gameObject.SetActive(false);
      this.Tick.gameObject.SetActive(false);
      this.m_input.characterLimit = 20;
      this.m_content.text = this.DM.mStringTable.GetStringByID(4613U);
      this.m_input.text = AllianceHint.ValidName;
      this.SetLimit(AllianceHint.ValidName);
      this.DM.SetSelectRequest = sender.m_BtnID1;
      ((Graphic) this.m_button).color = !((Component) this.NameTick).gameObject.activeSelf ? ((Graphic) this.m_error).color : Color.white;
      if (this.m_input.text != string.Empty)
        AllianceHint.CheckTime = 1f;
      ++AllianceHint.Naming;
    }
    else if (sender.m_BtnID1 == 8)
    {
      this.transform.GetChild(2).gameObject.SetActive(true);
      this.transform.GetChild(2).GetChild(0).GetChild(4).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.transform.GetChild(2).GetChild(0).GetChild(11).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.transform.GetChild(2).GetChild(0).GetChild(4).GetComponent<UIButton>().m_BtnID1 = 3;
      UnityEngine.UI.Text text = this.m_label[10];
      string stringById = this.DM.mStringTable.GetStringByID(4616U);
      this.m_title.text = stringById;
      string str = stringById;
      text.text = str;
      this.m_descript.text = this.DM.mStringTable.GetStringByID(4618U);
      AllianceHint.Checking = Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK;
      this.Invalid.gameObject.SetActive(false);
      this.Tick.gameObject.SetActive(false);
      this.m_input.characterLimit = 3;
      this.m_content.text = this.DM.mStringTable.GetStringByID(4617U);
      this.m_input.text = AllianceHint.ValidTag;
      this.SetLimit(AllianceHint.ValidTag);
      this.DM.SetSelectRequest = sender.m_BtnID1;
      ((Graphic) this.m_button).color = !this.TagTick.gameObject.activeSelf ? ((Graphic) this.m_error).color : Color.white;
      if (this.m_input.text != string.Empty)
        AllianceHint.CheckTime = 1f;
      ++AllianceHint.Tagging;
    }
    else if (sender.m_BtnID1 == 21)
    {
      this.transform.GetChild(2).gameObject.SetActive(false);
      AllianceHint.CheckTime = 0.0f;
      ++AllianceHint.Tagging;
    }
    else if (sender.m_BtnID1 == 22)
    {
      this.transform.GetChild(2).gameObject.SetActive(false);
      AllianceHint.CheckTime = 0.0f;
      ++AllianceHint.Naming;
    }
    else if (sender.m_BtnID1 == 11)
    {
      ((Component) this.m_default[2]).transform.parent.gameObject.SetActive(AllianceHint.Clearing);
      this.m_default[2].text = this.DM.mStringTable.GetStringByID(736U);
      this.UpdateUI(sender.m_BtnID1, 0);
    }
    else if (sender.m_BtnID1 == 12)
    {
      if (this.DM.IsNewbie())
      {
        GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(438U), (ushort) byte.MaxValue);
      }
      else
      {
        this.UpdateUI(sender.m_BtnID1, 0);
        ((Component) this.m_default[2]).transform.parent.gameObject.SetActive(false);
      }
    }
    else if (sender.m_BtnID1 == 13)
    {
      AllianceHint.Shooting = false;
      this.UpdateUI(sender.m_BtnID1, 0);
      this.m_default[2].text = this.DM.mStringTable.GetStringByID(4725U);
      ((Component) this.m_default[2]).transform.parent.gameObject.SetActive(this.DM.RoleAlliance.Apply == (byte) 0);
    }
    else if (sender.m_BtnID1 == 31)
    {
      if (AllianceHint.SearchIdx == (byte) 99 || !this.m_scroll.gameObject.activeSelf)
        return;
      if (AllianceHint.FilterIdx == (byte) 0 && AllianceHint.FilterName.Length == 0)
      {
        GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(4711U), (ushort) byte.MaxValue);
        AllianceHint.GenuineLang = AllianceHint.SeekLang = this.DM.GetUserLanguageID();
        AllianceHint.Shooting = AllianceHint.Clearing = false;
        AllianceHint.SeekName = string.Empty;
        AllianceHint.SeekKind = byte.MaxValue;
        this.UpdateUI(11, 0);
      }
      else if (AllianceHint.FilterName.Length > 0 && AllianceHint.FilterName.Length < 3)
      {
        GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(4710U), (ushort) byte.MaxValue);
      }
      else
      {
        AllianceHint.Pulling = (byte) 0;
        AllianceHint.Proceeding = 1L;
        this.Path.Length = 0;
        this.ItemsHeight.Clear();
        this.m_scroll.AddNewDataHeight(this.ItemsHeight);
        AllianceHint.SearchIdx = (byte) 99;
        GUIManager.Instance.ShowUILock(EUILock.AllianceCreate);
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_SEARCH;
        messagePacket.AddSeqId();
        messagePacket.Add(AllianceHint.FilterIdx);
        if (AllianceHint.FilterName.Length > 0)
        {
          messagePacket.Add((byte) AllianceHint.FilterName.Length);
          messagePacket.Add(AllianceHint.FilterName, AllianceHint.FilterName.Length);
        }
        if (AllianceHint.FilterName.Length > 0 && AllianceHint.FilterIdx > (byte) 0)
          this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(735U), (object) AllianceHint.FilterName, (object) this.DM.GetLanguageStr(AllianceHint.FilterIdx)).ToString();
        else if (AllianceHint.FilterName.Length > 0)
          this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4709U), (object) AllianceHint.FilterName).ToString();
        else if (AllianceHint.FilterIdx > (byte) 0)
          this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4709U), (object) this.DM.GetLanguageStr(AllianceHint.FilterIdx)).ToString();
        ((Component) this.m_default[2]).transform.parent.gameObject.SetActive(false);
        this.Path.Length = 0;
        this.m_filter.text = AllianceHint.SearchLang = AllianceHint.FilterIdx <= (byte) 0 ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703U), (object) this.DM.GetLanguageStr(AllianceHint.FilterIdx)).ToString();
        this.Path.Length = 0;
        this.m_search.text = AllianceHint.SearchName = AllianceHint.FilterName.Length <= 0 ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703U), (object) AllianceHint.FilterName).ToString();
        AllianceHint.SeekKind = (byte) AllianceHint.FilterName.Length;
        AllianceHint.SeekName = AllianceHint.FilterName;
        AllianceHint.SeekLang = AllianceHint.FilterIdx;
        AllianceHint.Clearing = false;
        messagePacket.Send();
      }
    }
    else if (sender.m_BtnID1 == 32)
    {
      this.DM.SetSelectLanguage = 1;
      this.DM.SetSelectRequest = 41;
      this.DM.CurSelectLanguage = AllianceHint.FilterIdx;
      AllianceHint.Positioning = this.m_scroll.GetTopIdx();
      AllianceHint.Scrolling = this.SearchRT.anchoredPosition.y;
      this.door.OpenMenu(EGUIWindow.UI_LanguageSelect);
    }
    else if (sender.m_BtnID1 == 33)
    {
      this.s_input.text = string.Empty;
      AllianceHint.Clearing = true;
      this.ClearName();
      AllianceHint.SearchNum = 0;
      this.UpdateUI(10, 0);
    }
    else if (sender.m_BtnID1 == 34)
    {
      this.SetFilterName((byte) 0);
      this.ClearLanguage();
      AllianceHint.Clearing = true;
      AllianceHint.SearchNum = 0;
      this.UpdateUI(10, 0);
    }
    else if (sender.m_BtnID1 == 35 || sender.m_BtnID1 != 41)
      ;
  }

  public void SetLimit(string limit)
  {
    this.Path.Length = 0;
    this.m_limit.text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4614U), (object) (this.m_input.characterLimit - Encoding.UTF8.GetByteCount(limit))).ToString();
  }

  public void ClearName()
  {
    UnityEngine.UI.Text search = this.m_search;
    string empty;
    AllianceHint.SeekName = empty = string.Empty;
    AllianceHint.SearchName = empty;
    search.text = empty;
    this.m_default[2].text = this.DM.mStringTable.GetStringByID(736U);
  }

  public void ClearLanguage()
  {
    AllianceHint.SeekKind = byte.MaxValue;
    this.m_filter.text = AllianceHint.SearchLang = string.Empty;
    this.m_default[2].text = this.DM.mStringTable.GetStringByID(736U);
    AllianceHint.GenuineLang = AllianceHint.SeekLang = this.DM.GetUserLanguageID();
  }

  public static int Sequencing(Protocol type = Protocol._MSG_INVALID)
  {
    AllianceHint.Incoming = type;
    return type > Protocol._MSG_INVALID ? (type == Protocol._MSG_RESP_ALLIANCE_TAGCHECK ? (int) AllianceHint.Tagging : (int) AllianceHint.Naming) : (AllianceHint.Checking == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK ? (int) AllianceHint.Tagging : (int) AllianceHint.Naming);
  }

  public static byte Sequencing(byte arg1)
  {
    if (AllianceHint.Incoming == Protocol._MSG_RESP_ALLIANCE_TAGCHECK || AllianceHint.Incoming == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK)
      AllianceHint.GenuineTag = arg1;
    else
      AllianceHint.GenuineName = arg1;
    return arg1;
  }

  public static void ValueChanged()
  {
    if (AllianceHint.Checking == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK)
      ++AllianceHint.Tagging;
    else
      ++AllianceHint.Naming;
    AllianceHint.CheckTime = 1f;
  }

  protected void CheckAll()
  {
    AllianceHint.Checking = Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK;
    this.CheckName(AllianceHint.ValidTag);
    AllianceHint.Checking = Protocol._MSG_REQUEST_ALLIANCE_NAMECHACK;
    this.CheckName(AllianceHint.ValidName);
  }

  protected void CheckName(string name)
  {
    AllianceHint.CheckTime = 0.0f;
    if (AllianceHint.Checking == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK && name.Length == 3 || AllianceHint.Checking != Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK && name.Length >= 3)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = AllianceHint.Checking;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) AllianceHint.Sequencing(Protocol._MSG_INVALID));
      if (AllianceHint.Checking != Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK)
        messagePacket.Add((byte) Encoding.UTF8.GetByteCount(name));
      messagePacket.Add(name, AllianceHint.Checking == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK ? 3 : 20);
      messagePacket.Send();
    }
    else
    {
      AllianceHint.Incoming = AllianceHint.Checking;
      int num = (int) AllianceHint.Sequencing((byte) 2);
      this.UpdateUI(2, 2);
    }
  }

  public static void OpenAllianceBox(ushort Type, int CharLimit, bool CheckOnly, long Para)
  {
    InputBox inputBox = GUIManager.Instance.OpenMenu(EGUIWindow.UI_AllianceInput, (int) Type, !CheckOnly ? 0 : 1, bSecWindow: true) as InputBox;
    if (!(bool) (UnityEngine.Object) inputBox)
      return;
    inputBox.SetLimit(CharLimit);
    inputBox.ItemID = Para;
  }
}
