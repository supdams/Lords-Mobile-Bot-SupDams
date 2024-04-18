// Decompiled with JetBrains decompiler
// Type: UIWonderLand
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIWonderLand : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler
{
  private int AssetKey;
  private AssetBundle AB;
  private AssetBundleRequest AR;
  private float ActionTime;
  private float ActionTimeRandom;
  private float MovingTimer;
  private bool ABIsDone;
  private Hero sHero;
  private string HeroAct;
  private GameObject go;
  private GameObject Duke;
  private RectTransform Hero_PosRT;
  private Transform Tmp;
  private Transform Hero_Model;
  private Transform Hero_3D;
  private Transform Hero_Pos;
  private Animation tmpAN;
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
  protected InputField s_input;
  protected InputField m_input;
  protected ScrollPanel m_scroll;
  protected ScrollPanelItem[] m_panel;
  protected UISpritesArray USArray;
  protected UIButtonHint m_UIHint;
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
  public static int MapPointID;
  public static AllianceSearch[] Search;
  public DataManager DM = DataManager.Instance;
  public Font Font = GUIManager.Instance.GetTTFFont();
  public StringBuilder Path = new StringBuilder();
  private List<float> ItemsHeight = new List<float>();
  private string[] mHeroAct = new string[7];
  private CString[] m_Str = new CString[10];
  private CString m_KingStr;
  private WondersInfoTbl WonderBra;
  private MapPoint nowMapPoint;
  private MapYolk mapYolk;
  private Effect effect;
  private ushort head;
  private uint time;

  public override void OnOpen(int arg1, int arg2)
  {
    // ISSUE: unable to decompile the method.
  }

  private void Refresh(int arg1 = 0)
  {
    this.m_UIHint.ControlFadeOut = ((Component) this.m_WorldWarZ).gameObject;
    if ((int) this.nowMapPoint.tableID < DataManager.MapDataController.YolkPointTable.Length)
      this.mapYolk = DataManager.MapDataController.YolkPointTable[(int) this.nowMapPoint.tableID];
    if (DataManager.MapDataController.IsFocusWorldWar())
    {
      if (this.mapYolk.WonderID > (byte) 0)
      {
        this.m_label[15].text = DataManager.MapDataController.GetYolkName((ushort) this.mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID).ToString();
        for (int index = 0; index <= 4; ++index)
          this.m_label[index + 20].text = this.DM.mStringTable.GetStringByID((uint) (index + 11058));
      }
      else
      {
        this.m_label[15].text = this.DM.mStringTable.GetStringByID(9990U);
        for (int index = 0; index <= 4; ++index)
          this.m_label[index + 20].text = this.DM.mStringTable.GetStringByID((uint) (index + 11026));
      }
      this.transform.GetChild(1).GetChild(19).GetChild(1).gameObject.SetActive(false);
      this.transform.GetChild(1).GetChild(19).GetChild(2).gameObject.SetActive(false);
      this.transform.GetChild(1).GetChild(19).GetChild(3).gameObject.SetActive(true);
      ((Behaviour) this.transform.GetChild(1).GetChild(19).GetChild(3).GetComponent<Image>()).enabled = this.mapYolk.WonderID == (byte) 0;
      this.transform.GetChild(1).GetChild(19).GetChild(3).GetChild(0).gameObject.SetActive(this.mapYolk.WonderID > (byte) 0);
      this.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(1).gameObject.SetActive(true);
      ((Behaviour) this.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(1).GetComponent<Image>()).enabled = this.mapYolk.WonderID == (byte) 0;
      this.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(1).GetChild(0).gameObject.SetActive(this.mapYolk.WonderID > (byte) 0);
      this.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(2).gameObject.SetActive(false);
      for (int index = 0; index <= 4; ++index)
      {
        ((Behaviour) this.transform.GetChild(1).GetChild(20).GetChild(index).GetChild(0).GetComponent<Image>()).enabled = false;
        this.transform.GetChild(1).GetChild(20).GetChild(index).GetChild(0).GetChild(0).gameObject.SetActive(true);
        ((Behaviour) this.transform.GetChild(1).GetChild(20).GetChild(index).GetChild(0).GetChild(0).GetComponent<Image>()).enabled = this.mapYolk.WonderID == (byte) 0;
        this.transform.GetChild(1).GetChild(20).GetChild(index).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(this.mapYolk.WonderID > (byte) 0);
      }
    }
    else
    {
      if ((int) this.mapYolk.WonderID < DataManager.MapDataController.MapWondersInfoTable.TableCount)
        this.m_label[15].text = DataManager.MapDataController.GetYolkName((ushort) this.mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID).ToString();
      for (int index = 0; index <= 4; ++index)
      {
        this.m_label[index + 20].text = this.DM.mStringTable.GetStringByID((uint) (index + 9324));
        ((Behaviour) this.transform.GetChild(1).GetChild(20).GetChild(index).GetChild(0).GetComponent<Image>()).enabled = true;
        this.transform.GetChild(1).GetChild(20).GetChild(index).GetChild(0).GetChild(0).gameObject.SetActive(false);
      }
      this.transform.GetChild(1).GetChild(19).GetChild(1).gameObject.SetActive(true);
      this.transform.GetChild(1).GetChild(19).GetChild(2).gameObject.SetActive(true);
      this.transform.GetChild(1).GetChild(19).GetChild(3).gameObject.SetActive(false);
      this.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(2).gameObject.SetActive(true);
      this.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(1).gameObject.SetActive(false);
    }
    if (this.mapYolk.WonderState > (byte) 0)
    {
      if (ActivityManager.Instance.IsInKvK((ushort) 0, true) && !DataManager.MapDataController.IsFocusWorldWar())
      {
        this.transform.GetChild(1).GetChild(15).GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(15).GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(15).GetChild(4).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(19).GetChild(6).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(19).GetChild(7).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(19).GetChild(11).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(19).GetChild(13).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(19).GetChild(14).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(15).gameObject.SetActive(true);
        this.m_label[26].text = this.DM.mStringTable.GetStringByID(9902U);
        this.m_label[3].text = this.DM.mStringTable.GetStringByID(9901U);
        ((Graphic) this.m_label[2]).color = ((Graphic) this.m_label[27]).color;
      }
      else
      {
        this.transform.GetChild(1).GetChild(15).GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(15).GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(15).GetChild(4).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(19).GetChild(6).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(19).GetChild(7).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(19).GetChild(11).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(19).GetChild(13).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(19).GetChild(14).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(15).gameObject.SetActive(true);
        this.m_label[26].text = this.DM.mStringTable.GetStringByID(!DataManager.MapDataController.IsFocusWorldWar() ? 9397U : 11033U);
        this.m_label[3].text = this.DM.mStringTable.GetStringByID(9901U);
        ((Graphic) this.m_label[2]).color = ((Graphic) this.m_label[1]).color;
      }
      ((Component) this.m_WorldPiss).gameObject.SetActive(false);
    }
    else
    {
      if (DataManager.MapDataController.IsFocusWorldWar())
      {
        this.transform.GetChild(1).GetChild(19).GetChild(7).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(19).GetChild(6).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(19).GetChild(11).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(19).GetChild(13).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(19).GetChild(14).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(15).gameObject.SetActive(false);
        this.m_UIHint.ControlFadeOut = ((Component) this.m_WorldPiss).gameObject;
        ((Component) this.m_WorldWarZ).gameObject.SetActive(false);
      }
      else
      {
        this.transform.GetChild(1).GetChild(15).GetChild(0).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(15).GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(15).GetChild(4).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(19).GetChild(7).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(19).GetChild(6).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(19).GetChild(11).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(19).GetChild(13).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(19).GetChild(14).gameObject.SetActive(false);
        this.transform.GetChild(1).GetChild(15).gameObject.SetActive(true);
        ((Component) this.m_WorldPiss).gameObject.SetActive(false);
      }
      UnityEngine.UI.Text text = this.m_label[25];
      string stringById = this.DM.mStringTable.GetStringByID(9399U);
      this.m_label[26].text = stringById;
      string str = stringById;
      text.text = str;
      this.m_label[3].text = this.DM.mStringTable.GetStringByID(7248U);
      ((Graphic) this.m_label[2]).color = ((Graphic) this.m_label[0]).color;
      if ((double) this.m_label[25].preferredWidth > (double) ((Graphic) this.m_label[25]).rectTransform.sizeDelta.x)
      {
        ((Graphic) this.m_label[25]).rectTransform.sizeDelta = new Vector2(this.m_label[25].preferredWidth, ((Graphic) this.m_label[25]).rectTransform.sizeDelta.y);
        ((Graphic) this.m_WorldPiss).rectTransform.sizeDelta = new Vector2(this.m_label[25].preferredWidth + 14f, ((Graphic) this.m_label[25]).rectTransform.sizeDelta.y + 10f);
      }
      if ((double) this.m_label[25].preferredHeight > (double) ((Graphic) this.m_label[25]).rectTransform.sizeDelta.y)
      {
        ((Graphic) this.m_label[25]).rectTransform.sizeDelta = new Vector2(((Graphic) this.m_label[25]).rectTransform.sizeDelta.x, this.m_label[25].preferredHeight);
        ((Graphic) this.m_WorldPiss).rectTransform.sizeDelta = new Vector2(((Graphic) this.m_label[25]).rectTransform.sizeDelta.x + 14f, this.m_label[25].preferredHeight + 10f);
      }
    }
    for (int index = 0; index < 10; ++index)
      this.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(2 + index).gameObject.SetActive(this.mapYolk.WonderID > (byte) 0 && !DataManager.MapDataController.IsFocusWorldWar());
    this.transform.GetChild(1).GetChild(20).gameObject.SetActive(DataManager.MapDataController.IsFocusWorldWar() || this.mapYolk.WonderID == (byte) 0);
    this.transform.GetChild(1).GetChild(13).gameObject.SetActive(this.mapYolk.WonderID > (byte) 0 && !DataManager.MapDataController.IsFocusWorldWar());
    this.transform.GetChild(1).GetChild(19).GetChild(15).gameObject.SetActive(false);
    this.transform.GetChild(1).GetChild(19).GetChild(12).gameObject.SetActive(false);
    this.transform.GetChild(1).GetChild(19).GetChild(10).gameObject.SetActive(false);
    this.transform.GetChild(1).GetChild(19).GetChild(9).gameObject.SetActive(false);
    this.m_label[8].text = this.DM.mStringTable.GetStringByID(7249U);
    if ((double) this.m_label[26].preferredWidth > (double) ((Graphic) this.m_label[26]).rectTransform.sizeDelta.x)
    {
      ((Graphic) this.m_label[26]).rectTransform.sizeDelta = new Vector2(this.m_label[26].preferredWidth, ((Graphic) this.m_label[26]).rectTransform.sizeDelta.y);
      ((Graphic) this.m_WorldWarZ).rectTransform.sizeDelta = new Vector2(this.m_label[26].preferredWidth + 14f, ((Graphic) this.m_label[26]).rectTransform.sizeDelta.y + 10f);
    }
    if ((double) this.m_label[26].preferredHeight > (double) ((Graphic) this.m_label[26]).rectTransform.sizeDelta.y)
    {
      ((Graphic) this.m_label[26]).rectTransform.sizeDelta = new Vector2(((Graphic) this.m_label[26]).rectTransform.sizeDelta.x, this.m_label[26].preferredHeight);
      ((Graphic) this.m_WorldWarZ).rectTransform.sizeDelta = new Vector2(((Graphic) this.m_label[26]).rectTransform.sizeDelta.x + 14f, this.m_label[26].preferredHeight + 10f);
    }
    if (this.mapYolk.WonderAllianceTag == null || this.mapYolk.WonderAllianceTag.Length == 0)
    {
      this.m_Str[4].ClearString();
      this.m_Str[4].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(245U));
      this.m_Str[4].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4600U));
      this.m_label[6].text = this.m_Str[4].ToString();
      ((Graphic) this.m_label[6]).SetAllDirty();
      this.m_label[6].cachedTextGenerator.Invalidate();
      ((Behaviour) this.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(0).GetComponent<Image>()).enabled = false;
      ((Behaviour) this.transform.GetChild(1).GetChild(14).GetComponent<Image>()).enabled = false;
      this.Transformer.gameObject.SetActive(false);
    }
    else if (DataManager.Instance.RoleAlliance.KingdomID > (ushort) 0 || DataManager.Instance.RoleAlliance.Id == 0U)
    {
      this.m_Str[1].ClearString();
      if ((int) DataManager.Instance.RoleAlliance.KingdomID == (int) this.mapYolk.AllianceKingdomID)
      {
        this.m_Str[1].StringToFormat(this.mapYolk.WonderAllianceTag);
        this.m_Str[1].StringToFormat(this.mapYolk.OwnerAllianceName);
        if (GUIManager.Instance.IsArabic)
          this.m_Str[1].AppendFormat("{1} [{0}]");
        else
          this.m_Str[1].AppendFormat("[{0}] {1}");
      }
      else
      {
        CString FromattedName = StringManager.Instance.StaticString1024();
        CString Name = StringManager.Instance.StaticString1024();
        CString Tag = StringManager.Instance.StaticString1024();
        Name.Append(this.mapYolk.OwnerAllianceName);
        Tag.Append(this.mapYolk.WonderAllianceTag);
        GUIManager.Instance.FormatRoleNameForChat(FromattedName, Name, Tag, this.mapYolk.AllianceKingdomID, GUIManager.Instance.IsArabic);
        this.m_Str[1].Append(FromattedName);
      }
      this.m_Str[4].ClearString();
      this.m_Str[4].StringToFormat(this.m_Str[1]);
      this.m_Str[4].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4600U));
      this.m_label[6].text = this.m_Str[4].ToString();
      ((Graphic) this.m_label[6]).SetAllDirty();
      this.m_label[6].cachedTextGenerator.Invalidate();
      ((Behaviour) this.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(0).GetComponent<Image>()).enabled = true;
      ((Behaviour) this.transform.GetChild(1).GetChild(14).GetComponent<Image>()).enabled = true;
      this.Transformer.gameObject.SetActive(true);
      int mBadge = ((int) this.mapYolk.OwnerEmblem >> 3 & 7) * 8 + ((int) this.mapYolk.OwnerEmblem & 7) + 1;
      if (mBadge > 64)
        mBadge = 64;
      int mTotem = ((int) this.mapYolk.OwnerEmblem >> 6 & 63) + 1;
      if (mTotem > 64)
        mTotem = 64;
      GUIManager.Instance.SetBadgeTotemImg(this.Transformer, mBadge, mTotem);
    }
    else
      this.Transformer.gameObject.SetActive(false);
    this.m_Str[0].ClearString();
    this.m_Str[2].ClearString();
    CString str1 = StringManager.Instance.StaticString1024();
    DataManager.MapDataController.GetKingdomName(DataManager.MapDataController.FocusKingdomID, ref str1);
    if ((int) DataManager.MapDataController.kingdomData.kingdomID != (int) DataManager.MapDataController.FocusKingdomID)
      this.m_Str[0].IntToFormat((long) DataManager.MapDataController.FocusKingdomID);
    this.m_Str[0].StringToFormat(str1);
    if ((int) DataManager.MapDataController.kingdomData.kingdomID != (int) DataManager.MapDataController.FocusKingdomID)
      this.m_Str[0].AppendFormat("#{0} {1}");
    else
      this.m_Str[0].AppendFormat("{0}");
    this.m_Str[2].StringToFormat(this.m_Str[0]);
    this.m_Str[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4509U));
    this.m_label[7].text = this.m_Str[2].ToString();
    ((Graphic) this.m_label[7]).SetAllDirty();
    this.m_label[7].cachedTextGenerator.Invalidate();
    RectTransform rectTransform = ((Graphic) this.m_label[7]).rectTransform;
    Vector2 vector2_1 = new Vector2(320f, 30f);
    ((Graphic) this.m_label[6]).rectTransform.sizeDelta = vector2_1;
    Vector2 vector2_2 = vector2_1;
    rectTransform.sizeDelta = vector2_2;
    ((Graphic) this.m_label[7]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.m_label[7]).rectTransform.anchoredPosition.x, -65f);
    ((Graphic) this.m_label[6]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.m_label[6]).rectTransform.anchoredPosition.x, -20f);
    if (this.mapYolk.OwnerName == null || this.mapYolk.OwnerName.Length == 0 && this.mapYolk.WonderLeader == null || this.mapYolk.WonderLeader.Length == 0)
    {
      this.transform.GetChild(1).GetChild(19).GetChild(5).GetChild(0).GetChild(0).gameObject.SetActive(false);
      this.m_label[5].text = DataManager.Instance.mStringTable.GetStringByID(!DataManager.MapDataController.IsFocusWorldWar() ? 7250U : 11019U);
      this.Destroy();
    }
    else
    {
      if ((UnityEngine.Object) this.AB == (UnityEngine.Object) null || arg1 > 0 || (int) this.head != (int) this.mapYolk.LeaderHead)
      {
        this.Destroy();
        this.ActionTime = 0.0f;
        this.ActionTimeRandom = 2f;
        this.head = this.mapYolk.LeaderHead;
        this.sHero = this.DM.HeroTable.GetRecordByKey(this.mapYolk.LeaderHead);
        if (this.DM.CheckHero3DMesh(this.head))
        {
          this.ABIsDone = false;
          str1.ClearString();
          str1.IntToFormat((long) this.sHero.Modle, 5);
          str1.AppendFormat("Role/hero_{0}");
          this.AB = AssetManager.GetAssetBundle(str1, out this.AssetKey);
          if ((UnityEngine.Object) this.AB != (UnityEngine.Object) null)
            this.AR = this.AB.LoadAsync("m", typeof (GameObject));
        }
      }
      this.transform.GetChild(1).GetChild(19).GetChild(5).GetChild(0).GetChild(0).gameObject.SetActive(true);
      this.m_label[5].text = this.mapYolk.WonderLeader == null || this.mapYolk.WonderLeader.Length <= 0 ? this.mapYolk.OwnerName.ToString() : this.mapYolk.WonderLeader.ToString();
      if (this.mapYolk.WonderID == (byte) 0 || DataManager.MapDataController.IsFocusWorldWar())
      {
        this.m_KingStr.ClearString();
        if (DataManager.MapDataController.IsFocusWorldWar())
        {
          if (this.mapYolk.WonderState > (byte) 0)
          {
            this.m_KingStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(11031U));
            this.transform.GetChild(1).GetChild(19).GetChild(9).gameObject.SetActive(false);
            this.transform.GetChild(1).GetChild(19).GetChild(10).gameObject.SetActive(false);
            this.transform.GetChild(1).GetChild(19).GetChild(12).gameObject.SetActive(false);
          }
          else
          {
            this.m_KingStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(this.mapYolk.WonderID <= (byte) 0 ? 9967U : 11057U));
            this.transform.GetChild(1).GetChild(19).GetChild(9).gameObject.SetActive(false);
            this.transform.GetChild(1).GetChild(19).GetChild(10).gameObject.SetActive(false);
            this.transform.GetChild(1).GetChild(19).GetChild(12).gameObject.SetActive(this.mapYolk.WonderID == (byte) 0);
            this.transform.GetChild(1).GetChild(19).GetChild(15).gameObject.SetActive(this.mapYolk.WonderID != (byte) 0);
          }
        }
        else if (DataManager.MapDataController.IsFocusKing(DataManager.MapDataController.YolkPointTable[0].LeaderHomeKingdomID))
        {
          this.m_KingStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9322U));
          this.transform.GetChild(1).GetChild(19).GetChild(9).gameObject.SetActive(true);
          this.transform.GetChild(1).GetChild(19).GetChild(10).gameObject.SetActive(false);
          this.transform.GetChild(1).GetChild(19).GetChild(12).gameObject.SetActive(false);
        }
        else
        {
          this.m_KingStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9323U));
          this.transform.GetChild(1).GetChild(19).GetChild(9).gameObject.SetActive(false);
          this.transform.GetChild(1).GetChild(19).GetChild(10).gameObject.SetActive(true);
          this.transform.GetChild(1).GetChild(19).GetChild(12).gameObject.SetActive(false);
        }
        if ((int) DataManager.MapDataController.kingdomData.kingdomID != (int) this.mapYolk.LeaderHomeKingdomID && this.mapYolk.LeaderHomeKingdomID > (ushort) 0)
          this.m_KingStr.IntToFormat((long) this.mapYolk.LeaderHomeKingdomID);
        this.m_KingStr.StringToFormat(this.m_label[5].text);
        if ((int) DataManager.MapDataController.kingdomData.kingdomID != (int) this.mapYolk.LeaderHomeKingdomID && this.mapYolk.LeaderHomeKingdomID > (ushort) 0)
          this.m_KingStr.AppendFormat("<color=white>{0}</color> #{1} {2}");
        else
          this.m_KingStr.AppendFormat("<color=white>{0}</color> {1}");
        this.m_label[5].text = this.m_KingStr.ToString();
      }
    }
    ((Graphic) this.m_label[5]).SetAllDirty();
    this.m_label[5].cachedTextGenerator.Invalidate();
    if (this.mapYolk.OwnerName == null || this.mapYolk.OwnerName.Length == 0 && this.mapYolk.WonderLeader == null || this.mapYolk.WonderLeader.Length == 0)
    {
      this.transform.GetChild(1).GetChild(19).GetChild(0).gameObject.SetActive(false);
      ((Behaviour) this.transform.GetChild(1).GetChild(19).GetChild(4).GetComponent<Image>()).enabled = false;
      this.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(0).gameObject.SetActive(false);
    }
    else
    {
      this.m_Str[3].ClearString();
      this.m_Str[3].IntToFormat((long) this.mapYolk.LeaderKingdomID);
      Vector2 tileMapPosbyMapId = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.mapYolk.LeaderPos.zoneID, this.mapYolk.LeaderPos.pointID));
      this.m_Str[3].IntToFormat((long) (int) tileMapPosbyMapId.x);
      this.m_Str[3].IntToFormat((long) (int) tileMapPosbyMapId.y);
      this.m_Str[3].AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
      this.m_label[4].text = this.m_Str[3].ToString();
      ((Graphic) this.m_label[4]).SetAllDirty();
      this.m_label[4].cachedTextGenerator.Invalidate();
      this.transform.GetChild(1).GetChild(19).GetChild(0).gameObject.SetActive(true);
      ((Behaviour) this.transform.GetChild(1).GetChild(19).GetChild(4).GetComponent<Image>()).enabled = true;
      this.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(0).gameObject.SetActive(true);
    }
    for (int index = 4; index < 6; ++index)
      ((RectTransform) this.transform.GetChild(1).GetChild(19).GetChild(index).GetChild(0).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_label[index].preferredWidth, ((Graphic) this.m_label[5]).rectTransform.sizeDelta.x), 3f);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    int index1 = 0;
    int index2 = dataIdx * 5;
    while (index1 < 5)
    {
      item.transform.GetChild(0).GetChild(index1 * 3).gameObject.SetActive(false);
      item.transform.GetChild(0).GetChild(index1 * 3 + 1).gameObject.SetActive(false);
      item.transform.GetChild(0).GetChild(index1 * 3 + 2).gameObject.SetActive(false);
      this.ItemTag[panelObjectIdx][index1] = item.transform.GetChild(0).GetChild(index1 * 3 + 2).GetComponent<UnityEngine.UI.Text>();
      this.ItemTag[panelObjectIdx][index1].font = this.Font;
      if (index2 < (int) DukeNukem.Dukedom)
      {
        this.ItemTag[panelObjectIdx][index1].text = !GUIManager.Instance.IsArabic ? "#" + (object) DukeNukem.Kid[index2] : DukeNukem.Kid[index2].ToString() + "#";
        if ((int) DukeNukem.Kid[index2] == (int) DataManager.MapDataController.kingdomData.kingdomID)
          item.transform.GetChild(0).GetChild(index1 * 3 + 1).gameObject.SetActive(true);
        item.transform.GetChild(0).GetChild(index1 * 3 + 2).gameObject.SetActive(true);
        item.transform.GetChild(0).GetChild(index1 * 3).gameObject.SetActive(true);
      }
      ++index1;
      ++index2;
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (arg1 != 5 || !bOK || !DataManager.MapDataController.CheckKingFunction(eKingFunction.eAmnesty))
      return;
    if (((int) DataManager.MapDataController.YolkPointTable[0].WonderFlag & 32) == 0)
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1464U), (ushort) byte.MaxValue);
    else
      DataManager.Instance.SendAmnesty();
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (bOnSecond)
    {
      this.m_Str[0].ClearString();
      if (this.mapYolk.StateBegin > 0UL && (ulong) DataManager.Instance.ServerTime - (ulong) this.mapYolk.StateDuring <= this.mapYolk.StateBegin)
      {
        GameConstants.GetTimeString(this.m_Str[0], (uint) ((long) this.mapYolk.StateBegin + (long) this.mapYolk.StateDuring - DataManager.Instance.ServerTime));
        this.m_label[2].text = this.m_Str[0].ToString();
      }
      else
        this.m_label[2].text = DataManager.Instance.mStringTable.GetStringByID(9321U);
      ((Graphic) this.m_label[2]).SetAllDirty();
      this.m_label[2].cachedTextGenerator.Invalidate();
    }
    if (!(bool) (UnityEngine.Object) this.m_CrownBack)
      return;
    if ((double) (this.TeaTime += Time.smoothDeltaTime) > 1.8)
      this.TeaTime = 0.2f;
    Image myEmperor = this.m_MyEmperor;
    Color color1 = new Color(1f, 1f, 1f, (double) this.TeaTime <= 1.0 ? this.TeaTime : 2f - this.TeaTime);
    ((Graphic) this.m_Defeater).color = color1;
    Color color2 = color1;
    ((Graphic) this.m_Dukedom).color = color2;
    Color color3 = color2;
    ((Graphic) this.m_CrownBack).color = color3;
    Color color4 = color3;
    ((Graphic) myEmperor).color = color4;
  }

  private void SetFilterName(byte Filter)
  {
    UIWonderLand.FilterIdx = Filter;
    this.transform.GetChild(1).GetChild(3).GetChild(17).GetChild(1).gameObject.SetActive(Filter == (byte) 0);
    this.transform.GetChild(1).GetChild(3).GetChild(20).gameObject.SetActive(UIWonderLand.FilterIdx > (byte) 0);
    if (UIWonderLand.FilterIdx > (byte) 0)
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
      UIWonderLand.ValueChanged();
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

  public void RequestFederalOrder()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_FEDERAL_ORDERKINGDOMS;
    messagePacket.AddSeqId();
    messagePacket.Add(this.mapYolk.WonderID);
    if (!messagePacket.Send())
      return;
    GUIManager.Instance.ShowUILock(EUILock.AllianceCreate);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if (!(bool) (UnityEngine.Object) this.m_WorldWarZ)
      return;
    sender.ControlFadeOut.SetActive(false);
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (!(bool) (UnityEngine.Object) this.m_WorldWarZ)
      return;
    sender.ControlFadeOut.SetActive(true);
  }

  public override void OnClose()
  {
    UnityEngine.Object.Destroy((UnityEngine.Object) this.Duke);
    DukeNukem.Kid = (ushort[]) null;
    for (int index = 0; index < 10; ++index)
    {
      if (this.m_Str[index] != null)
        StringManager.Instance.DeSpawnString(this.m_Str[index]);
    }
    StringManager.Instance.DeSpawnString(this.m_KingStr);
    this.m_WorldPiss = this.m_WorldWarZ = (Image) null;
    this.Destroy();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (GUIManager.Instance.HideUILock(EUILock.AllianceCreate))
    {
      this.ItemsHeight.Clear();
      this.Duke.SetActive(true);
      this.Duke.transform.GetChild(0).GetChild(0).gameObject.SetActive(DukeNukem.Result == (byte) 0);
      this.Duke.transform.GetChild(0).GetChild(2).gameObject.SetActive(DukeNukem.Result != (byte) 0);
      switch (DukeNukem.Result)
      {
        case 0:
          for (int index = 0; index < (int) DukeNukem.Dukedom; index += 5)
            this.ItemsHeight.Add(66f);
          for (int index = 0; index < (int) DukeNukem.Dukedom; ++index)
          {
            if ((int) DukeNukem.Kid[index] == (int) DataManager.MapDataController.kingdomData.kingdomID)
            {
              DukeNukem.Kid[index] = DukeNukem.Kid[0];
              DukeNukem.Kid[0] = DataManager.MapDataController.kingdomData.kingdomID;
              Array.Sort<ushort>(DukeNukem.Kid, 1, (int) DukeNukem.Dukedom - 1);
              this.m_scroll.AddNewDataHeight(this.ItemsHeight);
              return;
            }
          }
          Array.Sort<ushort>(DukeNukem.Kid);
          this.m_scroll.AddNewDataHeight(this.ItemsHeight);
          break;
        case 1:
          this.m_label[17].text = DataManager.Instance.mStringTable.GetStringByID(11155U);
          break;
        case 2:
          this.m_label[17].text = DataManager.Instance.mStringTable.GetStringByID((int) ActivityManager.Instance.FederalActKingdomWonderID != (int) this.mapYolk.WonderID ? 11079U : 11075U);
          break;
        default:
          this.m_label[17].text = DataManager.Instance.mStringTable.GetStringByID(1049U);
          break;
      }
    }
    else
      this.Refresh(arg1);
  }

  public override bool OnBackButtonClick()
  {
    if (!this.Duke.activeInHierarchy)
      return false;
    this.Duke.SetActive(false);
    return true;
  }

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
    this.AR = (AssetBundleRequest) null;
    AssetManager.UnloadAssetBundle(this.AssetKey);
  }

  protected void Update()
  {
    if (this.AR != null && !this.ABIsDone && this.AR.isDone)
    {
      this.ABIsDone = true;
      this.go = (GameObject) UnityEngine.Object.Instantiate(this.AR.asset);
      this.go.transform.SetParent(this.Hero_Pos, false);
      this.go.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
      {
        eulerAngles = new Vector3(0.0f, (float) this.sHero.Camera_Horizontal, 0.0f)
      };
      this.go.transform.localScale = new Vector3((float) this.sHero.CameraScaleRate, (float) this.sHero.CameraScaleRate, (float) this.sHero.CameraScaleRate);
      this.go.transform.localPosition = Vector3.zero;
      GUIManager.Instance.SetLayer(this.go, 5);
      this.Hero_PosRT.anchoredPosition = new Vector2(this.Hero_PosRT.anchoredPosition.x, (float) (-180 - (1000 - (int) this.sHero.CameraDistance)));
      this.Tmp = this.Hero_Pos.GetChild(this.Hero_Pos.childCount - 1);
      this.Hero_Model = this.Tmp.GetComponent<Transform>();
      if ((UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null)
      {
        this.tmpAN = this.Hero_Model.GetComponent<Animation>();
        this.tmpAN.wrapMode = WrapMode.Loop;
        this.tmpAN.Play(this.mHeroAct[0]);
        this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
        this.tmpAN.clip = this.tmpAN.GetClip(this.mHeroAct[0]);
        if (this.Hero_Pos.gameObject.activeSelf)
        {
          SkinnedMeshRenderer componentInChildren = this.Hero_Model.GetComponentInChildren<SkinnedMeshRenderer>();
          componentInChildren.updateWhenOffscreen = true;
          componentInChildren.useLightProbes = false;
        }
      }
    }
    if (this.ABIsDone && (UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null && (!this.tmpAN.IsPlaying(this.HeroAct) || this.HeroAct == "idle") && (double) this.ActionTimeRandom < 0.0001)
    {
      this.ActionTimeRandom = (float) UnityEngine.Random.Range(3, 7);
      this.ActionTime = 0.0f;
    }
    if ((double) this.ActionTimeRandom > 0.0001)
    {
      this.ActionTime += Time.smoothDeltaTime;
      if ((double) this.ActionTime >= (double) this.ActionTimeRandom)
        this.HeroActionChang();
    }
    if (this.ABIsDone && (UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null && (double) this.MovingTimer > 0.0)
    {
      this.MovingTimer -= Time.deltaTime;
      if ((double) this.MovingTimer <= 0.0)
      {
        this.tmpAN.CrossFade("idle");
        this.HeroAct = "idle";
      }
    }
    if (!(bool) (UnityEngine.Object) this.door || this.mapYolk.WonderState != (byte) 2)
      return;
    this.door.CloseMenu();
  }

  public void HeroActionChang(bool bAddShowEffect = false)
  {
    if (!this.ABIsDone || !((UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null))
      return;
    this.tmpAN = this.Hero_Model.GetComponent<Animation>();
    this.tmpAN.wrapMode = WrapMode.Loop;
    if (this.HeroAct == this.mHeroAct[1])
      this.tmpAN.CrossFade("idle");
    if ((UnityEngine.Object) this.tmpAN.GetClip(this.mHeroAct[2]) != (UnityEngine.Object) null)
    {
      this.HeroAct = this.mHeroAct[2];
      this.tmpAN[this.mHeroAct[2]].layer = 1;
      this.tmpAN[this.mHeroAct[2]].wrapMode = WrapMode.Once;
    }
    if ((UnityEngine.Object) this.tmpAN.GetClip(this.mHeroAct[3]) != (UnityEngine.Object) null)
    {
      this.HeroAct = this.mHeroAct[3];
      this.tmpAN[this.mHeroAct[3]].layer = 1;
      this.tmpAN[this.mHeroAct[3]].wrapMode = WrapMode.Once;
    }
    if ((UnityEngine.Object) this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[4]) != (UnityEngine.Object) null)
    {
      this.HeroAct = this.mHeroAct[4];
      this.tmpAN[this.mHeroAct[4]].layer = 1;
      this.tmpAN[this.mHeroAct[4]].wrapMode = WrapMode.Once;
    }
    if ((UnityEngine.Object) this.tmpAN.GetClip(this.mHeroAct[5]) != (UnityEngine.Object) null)
    {
      this.HeroAct = this.mHeroAct[5];
      this.tmpAN[this.mHeroAct[5]].layer = 1;
      this.tmpAN[this.mHeroAct[5]].wrapMode = WrapMode.Once;
    }
    if ((UnityEngine.Object) this.tmpAN.GetClip(this.mHeroAct[6]) != (UnityEngine.Object) null)
    {
      this.HeroAct = this.mHeroAct[6];
      this.tmpAN[this.mHeroAct[6]].layer = 1;
      this.tmpAN[this.mHeroAct[6]].wrapMode = WrapMode.Once;
    }
    int index = bAddShowEffect ? 6 : UnityEngine.Random.Range(1, 7);
    AnimationClip animationClip = this.tmpAN.GetClip(this.mHeroAct[(int) (byte) index]);
    this.HeroAct = this.mHeroAct[(int) (byte) index];
    if (index == 3 && (UnityEngine.Object) this.tmpAN.GetClip(this.HeroAct + "_ch") != (UnityEngine.Object) null)
      animationClip = (AnimationClip) null;
    if ((UnityEngine.Object) animationClip != (UnityEngine.Object) null)
    {
      this.tmpAN.CrossFade(animationClip.name);
      this.MovingTimer = 0.0f;
      if (index == 1)
        this.MovingTimer = 2f;
    }
    this.ActionTimeRandom = 0.0f;
    this.ActionTime = 0.0f;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Fallout:
        if (!this.Duke.activeInHierarchy)
          break;
        this.Duke.SetActive(false);
        break;
      case NetworkNews.Refresh_Asset:
        if (meg[1] != (byte) 1 || meg[2] != (byte) 2 || (int) GameConstants.ConvertBytesToUShort(meg, 3) != (int) this.head)
          break;
        this.Refresh((int) this.head);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Alliance)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          for (int index = 0; index < 28; ++index)
          {
            if ((UnityEngine.Object) this.m_label[index] != (UnityEngine.Object) null && ((Behaviour) this.m_label[index]).enabled)
            {
              ((Behaviour) this.m_label[index]).enabled = false;
              ((Behaviour) this.m_label[index]).enabled = true;
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
          break;
        }
        this.Refresh();
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (!(bool) (UnityEngine.Object) this.door)
      return;
    if (DataManager.MapDataController.IsFocusWorldWar())
    {
      if (this.mapYolk.WonderID > (byte) 0)
      {
        switch (sender.m_BtnID2)
        {
          case 1:
            ActivityManager.Instance.Send_ACTIVITY_REQUEST_FEDERAL_PRIZE(this.mapYolk.WonderID);
            return;
          case 2:
            TitleManager.Instance.OpenNobilityTitleList((ushort) this.mapYolk.WonderID);
            return;
          case 3:
            if (!DataManager.MapDataController.IsPeaceState(true, this.mapYolk.WonderID))
              return;
            this.door.OpenMenu(EGUIWindow.UI_BagFilter, 9 | (int) this.mapYolk.WonderID << 16, DataManager.CompareStr(this.mapYolk.WonderLeader, this.DM.RoleAttr.Name) == 0 || DataManager.CompareStr(this.mapYolk.OwnerName, this.DM.RoleAttr.Name) == 0 ? 1 : 0);
            return;
          case 4:
            this.door.OpenMenu(EGUIWindow.UI_NobilityBoard, arg2: (int) this.mapYolk.WonderID);
            return;
          case 5:
            this.RequestFederalOrder();
            return;
        }
      }
      switch (sender.m_BtnID2)
      {
        case 1:
          this.door.OpenMenu(EGUIWindow.UI_WonderReward);
          return;
        case 2:
          TitleManager.Instance.OpenTitleListN((ushort) 0);
          return;
        case 3:
          TitleManager.Instance.OpenTitleListW();
          return;
        case 4:
          if (!DataManager.MapDataController.IsPeaceState(true, (byte) 0))
            return;
          this.door.OpenMenu(EGUIWindow.UI_BagFilter, 9);
          return;
        case 5:
          this.door.OpenMenu(EGUIWindow.UI_LeaderBoard, 6);
          return;
      }
    }
    if (sender.m_BtnID2 == 1)
      TitleManager.Instance.OpenTitleList();
    else if (sender.m_BtnID2 == 2)
      DataManager.Instance.SendKingdomBullitin_Info();
    else if (sender.m_BtnID2 == 3)
    {
      if (!DataManager.MapDataController.IsInMyKingdom(true))
        return;
      this.door.OpenMenu(EGUIWindow.UI_BuffList, 3);
    }
    else if (sender.m_BtnID2 == 4)
    {
      if (!DataManager.MapDataController.IsPeaceState(true, (byte) 0))
        return;
      this.door.OpenMenu(EGUIWindow.UI_BagFilter, 9);
    }
    else if (sender.m_BtnID2 == 5)
    {
      if (!DataManager.MapDataController.CheckKingFunction(eKingFunction.eAmnesty))
        return;
      if (((int) DataManager.MapDataController.YolkPointTable[0].WonderFlag & 32) == 0)
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1464U), (ushort) byte.MaxValue);
      else
        GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(1458U), DataManager.Instance.mStringTable.GetStringByID(1459U), sender.m_BtnID2, YesText: DataManager.Instance.mStringTable.GetStringByID(3737U), NoText: DataManager.Instance.mStringTable.GetStringByID(3736U));
    }
    else if (sender.m_BtnID1 == 4)
    {
      if (this.mapYolk.WonderAllianceTag == null || this.mapYolk.WonderAllianceTag.Length <= 0)
        return;
      this.door.AllianceInfo(this.mapYolk.WonderAllianceTag.ToString());
    }
    else if (sender.m_BtnID1 == 5)
    {
      if (this.mapYolk.WonderLeader != null && this.mapYolk.WonderLeader.Length > 0)
      {
        this.DM.ShowLordProfile(this.mapYolk.WonderLeader.ToString());
      }
      else
      {
        if (this.mapYolk.OwnerName == null || this.mapYolk.OwnerName.Length <= 0)
          return;
        this.DM.ShowLordProfile(this.mapYolk.OwnerName.ToString());
      }
    }
    else if (sender.m_BtnID1 == 3)
      this.door.CloseMenu();
    else if (sender.m_BtnID1 == 2)
      this.door.GoToPointCode(this.mapYolk.LeaderKingdomID, this.mapYolk.LeaderPos.zoneID, this.mapYolk.LeaderPos.pointID, (byte) 0);
    else if (sender.m_BtnID1 == 1)
    {
      this.door.OpenMenu(EGUIWindow.UI_WonderInfo, UIWonderLand.MapPointID);
    }
    else
    {
      this.Duke.SetActive(false);
      this.Refresh();
    }
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
    UIWonderLand.SeekName = empty = string.Empty;
    UIWonderLand.SearchName = empty;
    search.text = empty;
    this.m_default[2].text = this.DM.mStringTable.GetStringByID(736U);
  }

  public void ClearLanguage()
  {
    UIWonderLand.SeekKind = byte.MaxValue;
    this.m_filter.text = UIWonderLand.SearchLang = string.Empty;
    this.m_default[2].text = this.DM.mStringTable.GetStringByID(736U);
    UIWonderLand.GenuineLang = UIWonderLand.SeekLang = this.DM.GetUserLanguageID();
  }

  public static int Sequencing(Protocol type = Protocol._MSG_INVALID)
  {
    UIWonderLand.Incoming = type;
    return type > Protocol._MSG_INVALID ? (type == Protocol._MSG_RESP_ALLIANCE_TAGCHECK ? (int) UIWonderLand.Tagging : (int) UIWonderLand.Naming) : (UIWonderLand.Checking == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK ? (int) UIWonderLand.Tagging : (int) UIWonderLand.Naming);
  }

  public static byte Sequencing(byte arg1)
  {
    if (UIWonderLand.Incoming == Protocol._MSG_RESP_ALLIANCE_TAGCHECK || UIWonderLand.Incoming == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK)
      UIWonderLand.GenuineTag = arg1;
    else
      UIWonderLand.GenuineName = arg1;
    return arg1;
  }

  public static void ValueChanged()
  {
    if (UIWonderLand.Checking == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK)
      ++UIWonderLand.Tagging;
    else
      ++UIWonderLand.Naming;
    UIWonderLand.CheckTime = 1f;
  }

  protected void CheckAll()
  {
    UIWonderLand.Checking = Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK;
    this.CheckName(UIWonderLand.ValidTag);
    UIWonderLand.Checking = Protocol._MSG_REQUEST_ALLIANCE_NAMECHACK;
    this.CheckName(UIWonderLand.ValidName);
  }

  protected void CheckName(string name)
  {
    UIWonderLand.CheckTime = 0.0f;
    if (UIWonderLand.Checking == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK && name.Length == 3 || UIWonderLand.Checking != Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK && name.Length >= 3)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = UIWonderLand.Checking;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) UIWonderLand.Sequencing(Protocol._MSG_INVALID));
      if (UIWonderLand.Checking != Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK)
        messagePacket.Add((byte) Encoding.UTF8.GetByteCount(name));
      messagePacket.Add(name, UIWonderLand.Checking == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK ? 3 : 20);
      messagePacket.Send();
    }
    else
    {
      UIWonderLand.Incoming = UIWonderLand.Checking;
      int num = (int) UIWonderLand.Sequencing((byte) 2);
      this.UpdateUI(2, 2);
    }
  }

  public static void OpenAllianceBox(byte Type, int CharLimit, bool CheckOnly, long Para)
  {
    InputBox inputBox = GUIManager.Instance.OpenMenu(EGUIWindow.UI_AllianceInput, (int) Type, !CheckOnly ? 0 : 1, bSecWindow: true) as InputBox;
    if (!(bool) (UnityEngine.Object) inputBox)
      return;
    inputBox.SetLimit(CharLimit);
    inputBox.ItemID = Para;
  }
}
