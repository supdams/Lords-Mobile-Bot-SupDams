// Decompiled with JetBrains decompiler
// Type: UIWonderInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIWonderInfo : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  protected Door door;
  protected UnityEngine.UI.Text m_limit;
  protected UnityEngine.UI.Text m_title;
  protected UnityEngine.UI.Text m_error;
  protected UnityEngine.UI.Text m_filter;
  protected UnityEngine.UI.Text m_search;
  protected UnityEngine.UI.Text m_button;
  protected UnityEngine.UI.Text m_content;
  protected UnityEngine.UI.Text m_descript;
  protected Image m_PageBack;
  protected InputField s_input;
  protected InputField m_input;
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
  protected UnityEngine.UI.Text Name;
  protected UnityEngine.UI.Text Tag;
  protected UnityEngine.UI.Text[][] ItemTag = new UnityEngine.UI.Text[20][];
  protected UnityEngine.UI.Text[][] ItemRow = new UnityEngine.UI.Text[20][];
  protected UnityEngine.UI.Text[][] ItemNum = new UnityEngine.UI.Text[20][];
  protected CString[] m_Str = new CString[20];
  protected WondersInfoTbl WonderBra;
  protected Effect Effects;
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
  private MapPoint nowMapPoint;
  private MapYolk mapYolk;

  public override void OnOpen(int arg1, int arg2)
  {
    this.nowMapPoint = DataManager.MapDataController.LayoutMapInfo[arg1];
    if ((int) this.nowMapPoint.tableID < DataManager.MapDataController.YolkPointTable.Length)
      this.mapYolk = DataManager.MapDataController.YolkPointTable[(int) this.nowMapPoint.tableID];
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.door.UpdateUI(1, 2);
    Image component1 = this.transform.GetChild(0).GetChild(6).GetComponent<Image>();
    component1.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component1).material = this.door.LoadMaterial();
    if (GUIManager.Instance.bOpenOnIPhoneX)
      ((Behaviour) component1).enabled = false;
    Image component2 = this.transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<Image>();
    component2.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component2).material = this.door.LoadMaterial();
    this.transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_descript = this.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_descript.text = this.DM.mStringTable.GetStringByID(this.mapYolk.WonderID != (byte) 0 ? (!DataManager.MapDataController.IsFocusWorldWar() ? 7251U : 11063U) : (!DataManager.MapDataController.IsFocusWorldWar() ? 9354U : 9994U));
    this.m_descript.font = GUIManager.Instance.GetTTFFont();
    for (int index = 0; index < 20; ++index)
    {
      this.ItemTag[index] = new UnityEngine.UI.Text[9];
      this.ItemRow[index] = new UnityEngine.UI.Text[9];
      this.ItemNum[index] = new UnityEngine.UI.Text[9];
      this.m_Str[index] = StringManager.Instance.SpawnString(300);
    }
    this.ItemsHeight.Capacity = 9;
    if (this.mapYolk.WonderID > (byte) 0)
      this.ItemsHeight.Add(84f);
    else
      this.ItemsHeight.Add(70f);
    this.ItemsHeight.Add(41f);
    this.ItemsHeight.Add(46f);
    this.ItemTag[0][0] = this.transform.GetChild(0).GetChild(10).GetChild(3).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.ItemTag[0][0].text = this.DM.mStringTable.GetStringByID(DataManager.MapDataController.IsFocusWorldWar() ? (this.mapYolk.WonderID <= (byte) 0 ? 9995U : 11064U) : (this.mapYolk.WonderID != (byte) 0 ? 7253U : 9355U));
    this.ItemTag[0][0].font = this.Font;
    ((Graphic) this.ItemTag[0][0]).rectTransform.sizeDelta = ((Graphic) this.ItemTag[0][0]).rectTransform.sizeDelta with
    {
      y = this.ItemTag[0][0].preferredHeight
    };
    List<float> itemsHeight1;
    int index1;
    (itemsHeight1 = this.ItemsHeight)[index1 = 0] = itemsHeight1[index1] + (this.ItemTag[0][0].preferredHeight + 10f);
    this.ItemTag[0][1] = this.transform.GetChild(0).GetChild(10).GetChild(3).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.ItemTag[0][1].text = this.DM.mStringTable.GetStringByID(DataManager.MapDataController.IsFocusWorldWar() ? (this.mapYolk.WonderID <= (byte) 0 ? 9996U : 11065U) : (this.mapYolk.WonderID != (byte) 0 ? 7254U : 9356U));
    this.ItemTag[0][1].font = this.Font;
    ((Component) this.ItemTag[0][1]).transform.localPosition = ((Component) this.ItemTag[0][0]).transform.localPosition - new Vector3(0.0f, this.ItemTag[0][0].preferredHeight + 25f, 0.0f);
    ((Graphic) this.ItemTag[0][1]).rectTransform.sizeDelta = ((Graphic) this.ItemTag[0][1]).rectTransform.sizeDelta with
    {
      y = this.ItemTag[0][1].preferredHeight
    };
    List<float> itemsHeight2;
    int index2;
    (itemsHeight2 = this.ItemsHeight)[index2 = 0] = itemsHeight2[index2] + this.ItemTag[0][1].preferredHeight;
    this.ItemTag[0][2] = this.transform.GetChild(0).GetChild(10).GetChild(3).GetChild(2).GetComponent<UnityEngine.UI.Text>();
    this.ItemTag[0][2].text = this.DM.mStringTable.GetStringByID(DataManager.MapDataController.IsFocusWorldWar() ? (this.mapYolk.WonderID <= (byte) 0 ? 9997U : 11066U) : (this.mapYolk.WonderID != (byte) 0 ? 7255U : 9357U));
    this.ItemTag[0][2].font = this.Font;
    ((Component) this.ItemTag[0][2]).transform.localPosition = ((Component) this.ItemTag[0][1]).transform.localPosition - new Vector3(0.0f, this.ItemTag[0][1].preferredHeight + 20f, 0.0f);
    ((Graphic) this.ItemTag[0][2]).rectTransform.sizeDelta = ((Graphic) this.ItemTag[0][2]).rectTransform.sizeDelta with
    {
      y = this.ItemTag[0][2].preferredHeight
    };
    List<float> itemsHeight3;
    int index3;
    (itemsHeight3 = this.ItemsHeight)[index3 = 0] = itemsHeight3[index3] + this.ItemTag[0][2].preferredHeight;
    this.ItemTag[0][3] = this.transform.GetChild(0).GetChild(10).GetChild(3).GetChild(3).GetComponent<UnityEngine.UI.Text>();
    this.ItemTag[0][4] = this.transform.GetChild(0).GetChild(10).GetChild(3).GetChild(4).GetComponent<UnityEngine.UI.Text>();
    if (DataManager.MapDataController.IsFocusWorldWar())
    {
      for (int index4 = 1; index4 < 7; ++index4)
      {
        this.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(2).GetComponent<UnityEngine.UI.Text>().font = this.Font;
        this.ItemNum[0][index4 - 1] = this.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(3).GetComponent<UnityEngine.UI.Text>();
        this.ItemNum[0][index4 - 1].text = this.DM.mStringTable.GetStringByID(this.mapYolk.WonderID <= (byte) 0 ? (index4 < 6 ? (index4 <= 1 ? 10000U : (uint) (index4 + 10999)) : 11082U) : (uint) (index4 + 11068));
        this.ItemNum[0][index4 - 1].font = this.Font;
        this.ItemsHeight.Add((double) this.ItemNum[0][index4 - 1].preferredHeight <= 32.0 ? 46f : (float) (Math.Ceiling((double) this.ItemNum[0][index4 - 1].preferredHeight / 32.0) * 32.0));
      }
    }
    else if (this.mapYolk.WonderID > (byte) 0)
    {
      this.ItemTag[0][3].text = this.DM.mStringTable.GetStringByID(7256U);
      this.ItemTag[0][3].font = this.Font;
      ((Component) this.ItemTag[0][3]).transform.localPosition = ((Component) this.ItemTag[0][2]).transform.localPosition - new Vector3(0.0f, this.ItemTag[0][2].preferredHeight + 20f, 0.0f);
      Vector2 sizeDelta = ((Graphic) this.ItemTag[0][3]).rectTransform.sizeDelta with
      {
        y = this.ItemTag[0][3].preferredHeight
      };
      ((Graphic) this.ItemTag[0][3]).rectTransform.sizeDelta = sizeDelta;
      List<float> itemsHeight4;
      int index5;
      (itemsHeight4 = this.ItemsHeight)[index5 = 0] = itemsHeight4[index5] + this.ItemTag[0][3].preferredHeight;
      this.ItemTag[0][4].text = this.DM.mStringTable.GetStringByID(9374U);
      this.ItemTag[0][4].font = this.Font;
      ((Component) this.ItemTag[0][4]).transform.localPosition = ((Component) this.ItemTag[0][3]).transform.localPosition - new Vector3(0.0f, this.ItemTag[0][3].preferredHeight + 20f, 0.0f);
      sizeDelta = ((Graphic) this.ItemTag[0][4]).rectTransform.sizeDelta with
      {
        y = this.ItemTag[0][4].preferredHeight
      };
      ((Graphic) this.ItemTag[0][4]).rectTransform.sizeDelta = sizeDelta;
      List<float> itemsHeight5;
      int index6;
      (itemsHeight5 = this.ItemsHeight)[index6 = 0] = itemsHeight5[index6] + (this.ItemTag[0][4].preferredHeight + 10f);
      for (int index7 = 1; index7 < 6; ++index7)
      {
        this.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(2).GetComponent<UnityEngine.UI.Text>().font = this.Font;
        this.ItemNum[0][index7 - 1] = this.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(3).GetComponent<UnityEngine.UI.Text>();
        this.ItemNum[0][index7 - 1].text = this.DM.mStringTable.GetStringByID((uint) (index7 + 9384 - 1));
        this.ItemNum[0][index7 - 1].font = this.Font;
        this.ItemsHeight.Add((double) this.ItemNum[0][index7 - 1].preferredHeight <= 32.0 ? 46f : (float) (Math.Ceiling((double) this.ItemNum[0][index7 - 1].preferredHeight / 32.0) * 32.0));
      }
      this.ItemsHeight.Add(38f);
      this.ItemsHeight.Add(46f);
      for (int Index = 1; Index < 7; ++Index)
      {
        this.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(2).GetComponent<UnityEngine.UI.Text>().font = this.Font;
        this.ItemNum[0][Index - 1] = this.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(3).GetComponent<UnityEngine.UI.Text>();
        this.ItemNum[0][Index - 1].text = this.DM.mStringTable.GetStringByID(7257U);
        this.ItemNum[0][Index - 1].font = this.Font;
        this.m_Str[Index + 2].ClearString();
        this.WonderBra = DataManager.MapDataController.MapWondersInfoTable.GetRecordByIndex((int) (ushort) Index);
        if (this.WonderBra.Effect != null)
        {
          for (int index8 = 0; index8 < 3; ++index8)
          {
            this.m_Str[index8].ClearString();
            if (this.WonderBra.Effect[index8].Effect > (ushort) 0)
            {
              this.Effects = this.DM.EffectData.GetRecordByKey(this.WonderBra.Effect[index8].Effect);
              this.m_Str[index8].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.Effects.StringID));
              this.m_Str[index8].IntToFormat((long) this.WonderBra.Effect[index8].Value);
              if (index8 > 0)
                this.m_Str[index8].AppendFormat(this.DM.mStringTable.GetStringByID(9317U));
              else
                this.m_Str[index8].AppendFormat(this.DM.mStringTable.GetStringByID(9316U));
              this.m_Str[Index + 2].Append(this.m_Str[index8]);
            }
          }
        }
        this.ItemNum[0][Index - 1].text = this.m_Str[Index + 2].ToString();
        ((Graphic) this.ItemNum[0][Index - 1]).SetAllDirty();
        this.ItemNum[0][Index - 1].cachedTextGenerator.Invalidate();
        this.ItemsHeight.Add((double) this.ItemNum[0][Index - 1].preferredHeight <= 32.0 ? 46f : (float) (Math.Ceiling((double) this.ItemNum[0][Index - 1].preferredHeight / 32.0) * 32.0));
      }
    }
    else
    {
      this.ItemTag[0][3].text = this.DM.mStringTable.GetStringByID(9374U);
      this.ItemTag[0][3].font = this.Font;
      ((Component) this.ItemTag[0][3]).transform.localPosition = ((Component) this.ItemTag[0][2]).transform.localPosition - new Vector3(0.0f, this.ItemTag[0][2].preferredHeight + 20f, 0.0f);
      ((Graphic) this.ItemTag[0][3]).rectTransform.sizeDelta = ((Graphic) this.ItemTag[0][3]).rectTransform.sizeDelta with
      {
        y = this.ItemTag[0][3].preferredHeight
      };
      List<float> itemsHeight6;
      int index9;
      (itemsHeight6 = this.ItemsHeight)[index9 = 0] = itemsHeight6[index9] + (this.ItemTag[0][3].preferredHeight + 10f);
      for (int index10 = 1; index10 < 6; ++index10)
      {
        this.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(2).GetComponent<UnityEngine.UI.Text>().font = this.Font;
        this.ItemNum[0][index10 - 1] = this.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(3).GetComponent<UnityEngine.UI.Text>();
        this.ItemNum[0][index10 - 1].text = this.DM.mStringTable.GetStringByID((uint) (index10 + 9384 - 1));
        this.ItemNum[0][index10 - 1].font = this.Font;
        this.ItemsHeight.Add((double) this.ItemNum[0][index10 - 1].preferredHeight <= 32.0 ? 46f : (float) (Math.Ceiling((double) this.ItemNum[0][index10 - 1].preferredHeight / 32.0) * 32.0));
      }
      this.ItemsHeight.Add(38f);
      this.ItemsHeight.Add(46f);
      for (int index11 = 1; index11 < 6; ++index11)
      {
        this.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(2).GetComponent<UnityEngine.UI.Text>().font = this.Font;
        this.ItemNum[0][index11 - 1] = this.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(3).GetComponent<UnityEngine.UI.Text>();
        this.ItemNum[0][index11 - 1].text = this.DM.mStringTable.GetStringByID((uint) (index11 + 9360));
        this.ItemNum[0][index11 - 1].font = this.Font;
        ((Graphic) this.ItemNum[0][index11 - 1]).SetAllDirty();
        this.ItemNum[0][index11 - 1].cachedTextGenerator.Invalidate();
        this.ItemsHeight.Add((double) this.ItemNum[0][index11 - 1].preferredHeight <= 32.0 ? 46f : (float) (Math.Ceiling((double) this.ItemNum[0][index11 - 1].preferredHeight / 32.0) * 32.0));
      }
    }
    this.m_scroll = this.transform.GetChild(0).GetChild(9).GetComponent<ScrollPanel>();
    this.m_scroll.IntiScrollPanel(512f, 0.0f, 0.0f, this.ItemsHeight, 12, (IUpDateScrollPanel) this);
    this.m_panel = new ScrollPanelItem[10];
    this.m_scroll.gameObject.SetActive(true);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (DataManager.MapDataController.IsFocusWorldWar())
    {
      item.transform.GetChild(3).gameObject.SetActive(dataIdx == 0);
      item.transform.GetChild(4).gameObject.SetActive(dataIdx == 1 || dataIdx == 9);
      item.transform.GetChild(5).gameObject.SetActive(dataIdx == 2 || dataIdx == 10);
      item.transform.GetChild(6).gameObject.SetActive(dataIdx >= 3 && dataIdx <= 8 || dataIdx > 10);
    }
    else
    {
      item.transform.GetChild(3).gameObject.SetActive(dataIdx == 0);
      item.transform.GetChild(4).gameObject.SetActive(dataIdx == 1 || dataIdx == 8);
      item.transform.GetChild(5).gameObject.SetActive(dataIdx == 2 || dataIdx == 9);
      item.transform.GetChild(6).gameObject.SetActive(dataIdx >= 3 && dataIdx <= 7 || dataIdx >= 10);
    }
    switch (dataIdx)
    {
      case 0:
        if (DataManager.MapDataController.IsFocusWorldWar())
        {
          for (int index = 0; index < 3; ++index)
          {
            this.ItemTag[panelObjectIdx][index] = item.transform.GetChild(3).GetChild(index).GetComponent<UnityEngine.UI.Text>();
            this.ItemTag[panelObjectIdx][index].text = this.DM.mStringTable.GetStringByID((uint) (index + (this.mapYolk.WonderID <= (byte) 0 ? 9995 : 11064)));
          }
          break;
        }
        if (this.mapYolk.WonderID > (byte) 0)
        {
          for (int index = 0; index < 4; ++index)
          {
            this.ItemTag[panelObjectIdx][index] = item.transform.GetChild(3).GetChild(index).GetComponent<UnityEngine.UI.Text>();
            this.ItemTag[panelObjectIdx][index].text = this.DM.mStringTable.GetStringByID((uint) (index + 7253));
          }
          this.ItemTag[panelObjectIdx][4] = item.transform.GetChild(3).GetChild(4).GetComponent<UnityEngine.UI.Text>();
          this.ItemTag[panelObjectIdx][4].text = this.DM.mStringTable.GetStringByID(9374U);
          break;
        }
        for (int index = 0; index < 3; ++index)
        {
          this.ItemTag[panelObjectIdx][index] = item.transform.GetChild(3).GetChild(index).GetComponent<UnityEngine.UI.Text>();
          this.ItemTag[panelObjectIdx][index].text = this.DM.mStringTable.GetStringByID((uint) (index + 9355));
        }
        this.ItemTag[panelObjectIdx][3] = item.transform.GetChild(3).GetChild(3).GetComponent<UnityEngine.UI.Text>();
        this.ItemTag[panelObjectIdx][3].text = this.DM.mStringTable.GetStringByID(9374U);
        break;
      case 1:
        this.ItemTag[panelObjectIdx][5] = item.transform.GetChild(4).GetChild(1).GetComponent<UnityEngine.UI.Text>();
        this.ItemTag[panelObjectIdx][5].text = this.DM.mStringTable.GetStringByID(!DataManager.MapDataController.IsFocusWorldWar() ? 9381U : (this.mapYolk.WonderID <= (byte) 0 ? 9998U : 11067U));
        this.ItemTag[panelObjectIdx][5].font = this.Font;
        break;
      default:
        if (dataIdx >= 3 && dataIdx <= 8 && this.mapYolk.WonderID > (byte) 0 && DataManager.MapDataController.IsFocusWorldWar())
        {
          item.transform.GetChild(6).GetChild(0).gameObject.SetActive(dataIdx % 2 != 0);
          item.transform.GetChild(6).GetChild(1).gameObject.SetActive(dataIdx % 2 == 0);
          this.ItemRow[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(2).GetComponent<UnityEngine.UI.Text>();
          this.ItemRow[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(dataIdx >= 8 ? 11068U : (uint) (dataIdx + 11055));
          this.ItemNum[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(3).GetComponent<UnityEngine.UI.Text>();
          this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID((uint) (dataIdx + 11066));
          this.Join = (RectTransform) item.transform.GetChild(6).transform;
          this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
          this.Join = (RectTransform) item.transform.GetChild(6).GetChild(0).GetChild(0).transform;
          this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
          ((RectTransform) item.transform.GetChild(6).GetChild(1).GetChild(0).transform).sizeDelta = this.Join.sizeDelta;
          this.Join = (RectTransform) item.transform.GetChild(6).GetChild(0).GetChild(1).transform;
          this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
          ((RectTransform) item.transform.GetChild(6).GetChild(1).GetChild(1).transform).sizeDelta = this.Join.sizeDelta;
          break;
        }
        switch (dataIdx)
        {
          case 2:
            this.ItemTag[panelObjectIdx][6] = item.transform.GetChild(5).GetChild(0).GetComponent<UnityEngine.UI.Text>();
            this.ItemTag[panelObjectIdx][6].text = this.DM.mStringTable.GetStringByID(!DataManager.MapDataController.IsFocusWorldWar() ? 9382U : 9999U);
            this.ItemTag[panelObjectIdx][6].font = this.Font;
            this.ItemTag[panelObjectIdx][7] = item.transform.GetChild(5).GetChild(1).GetComponent<UnityEngine.UI.Text>();
            this.ItemTag[panelObjectIdx][7].text = this.DM.mStringTable.GetStringByID(!DataManager.MapDataController.IsFocusWorldWar() ? 9381U : 9360U);
            this.ItemTag[panelObjectIdx][7].font = this.Font;
            return;
          case 8:
            if (DataManager.MapDataController.IsFocusWorldWar())
            {
              item.transform.GetChild(6).GetChild(0).gameObject.SetActive(dataIdx % 2 != 0);
              item.transform.GetChild(6).GetChild(1).gameObject.SetActive(dataIdx % 2 == 0);
              if (DataManager.MapDataController.IsFocusWorldWar())
              {
                this.ItemRow[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(2).GetComponent<UnityEngine.UI.Text>();
                this.ItemRow[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(11081U);
                this.ItemNum[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(3).GetComponent<UnityEngine.UI.Text>();
                this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(11082U);
              }
              this.Join = (RectTransform) item.transform.GetChild(6).transform;
              this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
              this.Join = (RectTransform) item.transform.GetChild(6).GetChild(0).GetChild(0).transform;
              this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
              ((RectTransform) item.transform.GetChild(6).GetChild(1).GetChild(0).transform).sizeDelta = this.Join.sizeDelta;
              this.Join = (RectTransform) item.transform.GetChild(6).GetChild(0).GetChild(1).transform;
              this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
              ((RectTransform) item.transform.GetChild(6).GetChild(1).GetChild(1).transform).sizeDelta = this.Join.sizeDelta;
              return;
            }
            this.ItemTag[panelObjectIdx][5] = item.transform.GetChild(4).GetChild(1).GetComponent<UnityEngine.UI.Text>();
            this.ItemTag[panelObjectIdx][5].text = this.DM.mStringTable.GetStringByID(this.mapYolk.WonderID != (byte) 0 ? 7249U : 9358U);
            this.ItemTag[panelObjectIdx][5].font = this.Font;
            return;
          case 9:
            this.ItemTag[panelObjectIdx][6] = item.transform.GetChild(5).GetChild(0).GetComponent<UnityEngine.UI.Text>();
            this.ItemTag[panelObjectIdx][6].text = this.DM.mStringTable.GetStringByID(this.mapYolk.WonderID != (byte) 0 ? 7257U : 9359U);
            this.ItemTag[panelObjectIdx][6].font = this.Font;
            this.ItemTag[panelObjectIdx][7] = item.transform.GetChild(5).GetChild(1).GetComponent<UnityEngine.UI.Text>();
            this.ItemTag[panelObjectIdx][7].text = this.DM.mStringTable.GetStringByID(this.mapYolk.WonderID != (byte) 0 ? 7258U : 9360U);
            this.ItemTag[panelObjectIdx][7].font = this.Font;
            return;
          default:
            if (dataIdx >= 3 && dataIdx <= 7)
            {
              item.transform.GetChild(6).GetChild(0).gameObject.SetActive(dataIdx % 2 != 0);
              item.transform.GetChild(6).GetChild(1).gameObject.SetActive(dataIdx % 2 == 0);
              if (DataManager.MapDataController.IsFocusWorldWar())
              {
                this.ItemRow[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(2).GetComponent<UnityEngine.UI.Text>();
                this.ItemRow[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID((uint) (dataIdx + 11023));
                this.ItemNum[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(3).GetComponent<UnityEngine.UI.Text>();
                this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(dataIdx <= 3 ? 10000U : (uint) (dataIdx + 10997));
              }
              else if (this.mapYolk.WonderID > (byte) 0)
              {
                this.ItemRow[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(2).GetComponent<UnityEngine.UI.Text>();
                this.ItemRow[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID((uint) (dataIdx + 9381));
                this.ItemNum[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(3).GetComponent<UnityEngine.UI.Text>();
                switch (dataIdx)
                {
                  case 3:
                    this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(9391U);
                    break;
                  case 4:
                    this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(9394U);
                    break;
                  case 5:
                    this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(9395U);
                    break;
                  case 6:
                    this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(9396U);
                    break;
                  default:
                    this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(9393U);
                    break;
                }
                this.ItemNum[panelObjectIdx][dataIdx - 3].font = this.Font;
              }
              else
              {
                this.ItemRow[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(2).GetComponent<UnityEngine.UI.Text>();
                this.ItemRow[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID((uint) (dataIdx + 9381));
                this.ItemNum[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(3).GetComponent<UnityEngine.UI.Text>();
                this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID((uint) (dataIdx + 9386));
              }
              this.Join = (RectTransform) item.transform.GetChild(6).transform;
              this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
              this.Join = (RectTransform) item.transform.GetChild(6).GetChild(0).GetChild(0).transform;
              this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
              ((RectTransform) item.transform.GetChild(6).GetChild(1).GetChild(0).transform).sizeDelta = this.Join.sizeDelta;
              this.Join = (RectTransform) item.transform.GetChild(6).GetChild(0).GetChild(1).transform;
              this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
              ((RectTransform) item.transform.GetChild(6).GetChild(1).GetChild(1).transform).sizeDelta = this.Join.sizeDelta;
              return;
            }
            if (dataIdx < 10)
              return;
            item.transform.GetChild(6).GetChild(0).gameObject.SetActive(dataIdx % 2 != 0);
            item.transform.GetChild(6).GetChild(1).gameObject.SetActive(dataIdx % 2 == 0);
            if (this.mapYolk.WonderID > (byte) 0)
            {
              this.ItemRow[panelObjectIdx][dataIdx - 10] = item.transform.GetChild(6).GetChild(2).GetComponent<UnityEngine.UI.Text>();
              this.ItemRow[panelObjectIdx][dataIdx - 10].text = this.DM.mStringTable.GetStringByID((uint) (dataIdx + 7225));
              this.ItemNum[panelObjectIdx][dataIdx - 10] = item.transform.GetChild(6).GetChild(3).GetComponent<UnityEngine.UI.Text>();
              this.ItemNum[panelObjectIdx][dataIdx - 10].text = this.DM.mStringTable.GetStringByID(7257U);
              this.ItemNum[panelObjectIdx][dataIdx - 10].font = this.Font;
              this.m_Str[dataIdx].ClearString();
              this.WonderBra = DataManager.MapDataController.MapWondersInfoTable.GetRecordByIndex((int) (ushort) (dataIdx - 9));
              if (this.WonderBra.Effect != null)
              {
                for (int index = 0; index < 3; ++index)
                {
                  this.m_Str[index].ClearString();
                  if (this.WonderBra.Effect[index].Effect > (ushort) 0)
                  {
                    this.Effects = this.DM.EffectData.GetRecordByKey(this.WonderBra.Effect[index].Effect);
                    this.m_Str[index].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.Effects.StringID));
                    this.m_Str[index].FloatToFormat((float) this.WonderBra.Effect[index].Value / 100f);
                    if (index > 0)
                      this.m_Str[index].AppendFormat(this.DM.mStringTable.GetStringByID(9317U));
                    else
                      this.m_Str[index].AppendFormat(this.DM.mStringTable.GetStringByID(9316U));
                    this.m_Str[dataIdx].Append(this.m_Str[index]);
                  }
                }
              }
              this.ItemNum[panelObjectIdx][dataIdx - 10].text = this.m_Str[dataIdx].ToString();
              ((Graphic) this.ItemNum[panelObjectIdx][dataIdx - 10]).SetAllDirty();
              this.ItemNum[panelObjectIdx][dataIdx - 10].cachedTextGenerator.Invalidate();
            }
            else
            {
              this.ItemRow[panelObjectIdx][dataIdx - 10] = item.transform.GetChild(6).GetChild(2).GetComponent<UnityEngine.UI.Text>();
              this.ItemRow[panelObjectIdx][dataIdx - 10].text = this.DM.mStringTable.GetStringByID((uint) (dataIdx + 9314));
              this.ItemNum[panelObjectIdx][dataIdx - 10] = item.transform.GetChild(6).GetChild(3).GetComponent<UnityEngine.UI.Text>();
              this.ItemNum[panelObjectIdx][dataIdx - 10].text = this.DM.mStringTable.GetStringByID((uint) (dataIdx + 9351));
            }
            this.Join = (RectTransform) item.transform.GetChild(6).transform;
            this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
            this.Join = (RectTransform) item.transform.GetChild(6).GetChild(0).GetChild(0).transform;
            this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
            ((RectTransform) item.transform.GetChild(6).GetChild(1).GetChild(0).transform).sizeDelta = this.Join.sizeDelta;
            this.Join = (RectTransform) item.transform.GetChild(6).GetChild(0).GetChild(1).transform;
            this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
            ((RectTransform) item.transform.GetChild(6).GetChild(1).GetChild(1).transform).sizeDelta = this.Join.sizeDelta;
            return;
        }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
  }

  public override void OnClose()
  {
    for (int index = 0; index < 20; ++index)
    {
      if (this.m_Str[index] != null)
        StringManager.Instance.DeSpawnString(this.m_Str[index]);
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
  }

  public override bool OnBackButtonClick() => false;

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh_FontTextureRebuilt:
        if ((UnityEngine.Object) this.m_descript != (UnityEngine.Object) null && ((Behaviour) this.m_descript).enabled)
        {
          ((Behaviour) this.m_descript).enabled = false;
          ((Behaviour) this.m_descript).enabled = true;
        }
        for (int index1 = 0; index1 < 20; ++index1)
        {
          int index2 = 0;
          for (; index1 < 9; ++index1)
          {
            if ((UnityEngine.Object) this.ItemTag[index1][index2] != (UnityEngine.Object) null && ((Behaviour) this.ItemTag[index1][index2]).enabled)
            {
              ((Behaviour) this.ItemTag[index1][index2]).enabled = false;
              ((Behaviour) this.ItemTag[index1][index2]).enabled = true;
            }
            if ((UnityEngine.Object) this.ItemRow[index1][index2] != (UnityEngine.Object) null && ((Behaviour) this.ItemRow[index1][index2]).enabled)
            {
              ((Behaviour) this.ItemRow[index1][index2]).enabled = false;
              ((Behaviour) this.ItemRow[index1][index2]).enabled = true;
            }
            if ((UnityEngine.Object) this.ItemNum[index1][index2] != (UnityEngine.Object) null && ((Behaviour) this.ItemNum[index1][index2]).enabled)
            {
              ((Behaviour) this.ItemNum[index1][index2]).enabled = false;
              ((Behaviour) this.ItemNum[index1][index2]).enabled = true;
            }
          }
        }
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (!(bool) (UnityEngine.Object) this.door)
      return;
    this.door.CloseMenu();
  }
}
