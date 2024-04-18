// Decompiled with JetBrains decompiler
// Type: UIMiniMap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIMiniMap : 
  GUIWindow,
  IPointerUpHandler,
  IPointerDownHandler,
  IEventSystemHandler,
  IUIButtonClickHandler
{
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform Federal_T;
  private RectTransform CastleRT;
  private RectTransform mCanvasRT;
  private RectTransform Federal_FightRT;
  private RectTransform Federal_HomeRT;
  private RectTransform Federal_BGRT;
  private RectTransform NewCenterPosRT;
  private DataManager DM;
  private GUIManager GUIM;
  private ActivityManager ActM;
  private Font TTFont;
  private Door door;
  private Material mMaT;
  private UIButton btn_EXIT;
  private UIButton[] btn_W = new UIButton[7];
  private UIButton btn_Page;
  private UIButton btn_Castle;
  private UIButton[] btn_FederalW = new UIButton[30];
  private Image P1;
  private Image P2;
  private Image Img_Castle;
  private Image Img_NewCenterPos;
  private Image[] Img_Federal = new Image[30];
  private Image[] Img_W = new Image[7];
  private UIText text_Castle;
  private UIText text_Title;
  private UIText[] text_Lv = new UIText[5];
  private UIText[] text_WonderName = new UIText[7];
  private UIText[] text_Federal_WonderName = new UIText[30];
  private Outline[] mtextOutline = new Outline[30];
  private CString[] Cstr_Lv = new CString[5];
  private string[] mTitle = new string[2];
  private bool bResourse;
  private ushort mFederal_Fight_Idx;
  private ushort mFederal_Home;
  private Vector2 TcenterID = Vector2.zero;
  private int mWonderNum = 1;
  private int PosX;
  private int PosY;
  private bool bSetPosShow;
  private float mShowTime;
  private float mscaleValue;
  private float malphaValue;
  private ushort mGoToType;
  private float mIPhoneX_DeltaX;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.ActM = ActivityManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.mMaT = this.door.LoadMaterial();
    this.mCanvasRT = ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>();
    if (this.GUIM.bOpenOnIPhoneX)
      this.mIPhoneX_DeltaX = this.GUIM.IPhoneX_DeltaX;
    CString SpriteName = StringManager.Instance.StaticString1024();
    for (int index = 0; index < 5; ++index)
      this.Cstr_Lv[index] = StringManager.Instance.SpawnString(100);
    this.mTitle[0] = this.DM.mStringTable.GetStringByID(497U);
    this.mTitle[1] = this.DM.mStringTable.GetStringByID(495U);
    this.Tmp = this.GameT.GetChild(0);
    UIButton component1 = this.Tmp.GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 0;
    SpriteName.ClearString();
    SpriteName.AppendFormat("UI_main_black");
    component1.image.sprite = this.door.LoadSprite(SpriteName);
    ((MaskableGraphic) component1.image).material = this.mMaT;
    if (this.GUIM.bOpenOnIPhoneX)
    {
      this.Tmp.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
      this.Tmp.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
    }
    this.Tmp = this.GameT.GetChild(1);
    this.P1 = this.Tmp.GetComponent<Image>();
    ushort num = DataManager.MapDataController.FocusKingdomID == (ushort) 0 ? DataManager.MapDataController.OtherKingdomData.kingdomID : DataManager.MapDataController.FocusKingdomID;
    this.Tmp = this.GameT.GetChild(2);
    this.P2 = this.Tmp.GetComponent<Image>();
    for (int index = 0; index < 5; ++index)
    {
      this.Tmp1 = this.Tmp.GetChild(index).GetChild(0);
      this.text_Lv[index] = this.Tmp1.GetComponent<UIText>();
      this.text_Lv[index].font = this.TTFont;
      this.Cstr_Lv[index].ClearString();
      this.Cstr_Lv[index].Append(this.DM.mStringTable.GetStringByID(4549U));
      this.Cstr_Lv[index].IntToFormat((long) (index + 1));
      this.Cstr_Lv[index].AppendFormat(" {0}");
      this.text_Lv[index].text = this.Cstr_Lv[index].ToString();
    }
    this.Tmp = this.GameT.GetChild(3);
    for (int index = 0; index < 7; ++index)
    {
      this.Tmp1 = this.Tmp.GetChild(0 + index);
      Image component2 = this.Tmp1.GetComponent<Image>();
      this.Img_W[index] = this.Tmp1.GetComponent<Image>();
      this.btn_W[index] = this.Tmp1.GetChild(0).GetComponent<UIButton>();
      if ((Object) this.door.TileMapController != (Object) null && this.door.TileMapController.yolk != null && DataManager.MapDataController.CheckYolk((ushort) index, num))
      {
        component2.sprite = this.door.TileMapController.yolk.getMapTileYolkSprite((byte) index);
        ((MaskableGraphic) component2).material = this.door.TileMapController.yolk.getMapTileYolkMaterial((byte) index);
      }
      this.btn_W[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_W[index].m_BtnID1 = 3;
      this.btn_W[index].m_BtnID2 = index;
      this.text_WonderName[index] = this.Tmp1.GetChild(1).GetComponent<UIText>();
      this.text_WonderName[index].font = this.TTFont;
      this.text_WonderName[index].text = DataManager.MapDataController.GetYolkName((ushort) index, num).ToString();
      ((Graphic) this.text_WonderName[index]).rectTransform.sizeDelta = new Vector2(180f, ((Graphic) this.text_WonderName[index]).rectTransform.sizeDelta.y);
      ((Graphic) this.Img_W[index]).rectTransform.anchorMax = new Vector2(0.0f, 1f);
      ((Graphic) this.Img_W[index]).rectTransform.anchorMin = new Vector2(0.0f, 1f);
      ((Graphic) this.Img_W[index]).rectTransform.pivot = new Vector2(0.0f, 1f);
      this.SetWonderPos(num, (byte) index, ((Graphic) this.Img_W[index]).rectTransform);
      if (index == 0 && !DataManager.MapDataController.CheckYolk((ushort) index, num) || index > 0 && (DataManager.MapDataController.IsFocusWorldWar() || !DataManager.MapDataController.CheckYolk((ushort) index, num)))
        ((Component) component2).gameObject.SetActive(false);
    }
    this.Federal_T = this.Tmp.GetChild(7);
    if (DataManager.MapDataController.IsFocusWorldWar())
      this.Federal_T.gameObject.SetActive(true);
    this.Federal_FightRT = this.Federal_T.GetChild(31).GetComponent<RectTransform>();
    this.Federal_HomeRT = this.Federal_T.GetChild(32).GetComponent<RectTransform>();
    this.Federal_BGRT = this.Federal_T.GetChild(0).GetComponent<RectTransform>();
    if (this.GUIM.IsArabic)
    {
      ((Component) this.Federal_FightRT).gameObject.AddComponent<ArabicItemTextureRot>();
      ((Component) this.Federal_HomeRT).gameObject.AddComponent<ArabicItemTextureRot>();
      ((Component) this.Federal_BGRT).gameObject.AddComponent<ArabicItemTextureRot>();
    }
    for (int index = 0; index < 30; ++index)
    {
      this.Tmp1 = this.Federal_T.GetChild(1 + index);
      if (this.GUIM.IsArabic)
        this.Tmp1.gameObject.AddComponent<ArabicItemTextureRot>();
      this.Img_Federal[index] = this.Tmp1.GetComponent<Image>();
      this.btn_FederalW[index] = this.Tmp1.GetChild(0).GetComponent<UIButton>();
      this.btn_FederalW[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_FederalW[index].m_BtnID1 = 4;
      this.btn_FederalW[index].m_BtnID2 = this.mWonderNum + index;
      this.text_Federal_WonderName[index] = this.Tmp1.GetChild(1).GetComponent<UIText>();
      this.text_Federal_WonderName[index].font = this.TTFont;
      this.mtextOutline[index] = ((Component) this.text_Federal_WonderName[index]).transform.GetComponent<Outline>();
      if ((Object) this.door.TileMapController != (Object) null && this.door.TileMapController.yolk != null && DataManager.MapDataController.IsFocusWorldWar() && DataManager.MapDataController.CheckYolk((ushort) (this.mWonderNum + index), num))
      {
        ((Component) this.Img_Federal[index]).gameObject.SetActive(true);
        this.Img_Federal[index].sprite = this.door.TileMapController.yolk.getMapTileYolkSprite((byte) (this.mWonderNum + index));
        ((MaskableGraphic) this.Img_Federal[index]).material = this.door.TileMapController.yolk.getMapTileYolkMaterial((byte) (this.mWonderNum + index));
        this.text_Federal_WonderName[index].text = DataManager.MapDataController.GetYolkName((ushort) (this.mWonderNum + index), num).ToString();
        this.SetWonderPos(num, (byte) (this.mWonderNum + index), ((Graphic) this.Img_Federal[index]).rectTransform);
        ((Behaviour) this.mtextOutline[index]).enabled = false;
      }
    }
    if (DataManager.MapDataController.IsFocusWorldWar())
    {
      if (this.ActM.FederalFightingWonderID != (byte) 0)
        ((Component) this.Federal_FightRT).gameObject.SetActive(true);
      if (this.ActM.FederalHomeKingdomWonderID != (byte) 0)
      {
        ((Component) this.Federal_HomeRT).gameObject.SetActive(true);
        ((Component) this.Federal_BGRT).gameObject.SetActive(true);
      }
      this.UpdataFederalActivity();
    }
    this.Tmp1 = this.Tmp.GetChild(8);
    this.NewCenterPosRT = this.Tmp1.GetComponent<RectTransform>();
    this.Img_NewCenterPos = this.Tmp1.GetComponent<Image>();
    this.Tmp1 = this.Tmp.GetChild(9);
    this.btn_Castle = this.Tmp1.GetComponent<UIButton>();
    this.CastleRT = this.Tmp1.GetComponent<RectTransform>();
    this.btn_Castle.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Castle.m_BtnID1 = 2;
    this.Tmp1 = this.Tmp.GetChild(9).GetChild(0);
    this.Img_Castle = this.Tmp1.GetComponent<Image>();
    this.Tmp1 = this.Tmp.GetChild(9).GetChild(0).GetChild(0);
    this.text_Castle = this.Tmp1.GetComponent<UIText>();
    this.text_Castle.font = this.TTFont;
    this.text_Castle.text = this.DM.mStringTable.GetStringByID(496U);
    this.text_Castle.SetAllDirty();
    this.text_Castle.cachedTextGenerator.Invalidate();
    this.text_Castle.cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_Castle.preferredWidth > (double) ((Graphic) this.text_Castle).rectTransform.sizeDelta.x)
    {
      ((Graphic) this.text_Castle).rectTransform.sizeDelta = new Vector2(this.text_Castle.preferredWidth + 1f, ((Graphic) this.text_Castle).rectTransform.sizeDelta.y);
      ((Graphic) this.Img_Castle).rectTransform.sizeDelta = new Vector2(this.text_Castle.preferredWidth + 21f, ((Graphic) this.Img_Castle).rectTransform.sizeDelta.y);
    }
    this.Tmp1 = this.Tmp.GetChild(10);
    this.btn_Page = this.Tmp1.GetComponent<UIButton>();
    this.btn_Page.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Page.m_BtnID1 = 1;
    this.btn_Page.m_EffectType = e_EffectType.e_Scale;
    this.btn_Page.transition = (Selectable.Transition) 0;
    if (DataManager.MapDataController.IsFocusWorldWar())
      ((Component) this.btn_Page).gameObject.SetActive(false);
    this.Tmp1 = this.Tmp.GetChild(11);
    this.text_Title = this.Tmp1.GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.text_Title.text = this.mTitle[0];
    this.Tmp = this.GameT.GetChild(4);
    Image component3 = this.Tmp.GetComponent<Image>();
    SpriteName.ClearString();
    SpriteName.AppendFormat("UI_main_close_base");
    component3.sprite = this.door.LoadSprite(SpriteName);
    ((MaskableGraphic) component3).material = this.mMaT;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) component3).enabled = false;
    this.Tmp = this.GameT.GetChild(4).GetChild(0);
    this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
    SpriteName.ClearString();
    SpriteName.AppendFormat("UI_main_close");
    this.btn_EXIT.image.sprite = this.door.LoadSprite(SpriteName);
    ((MaskableGraphic) this.btn_EXIT.image).material = this.mMaT;
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.FocusKingdomID)
      ((Component) this.CastleRT).gameObject.SetActive(true);
    else
      ((Component) this.CastleRT).gameObject.SetActive(false);
    this.SetCastle();
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 1);
  }

  public override void OnClose()
  {
    for (int index = 0; index < 5; ++index)
    {
      if (this.Cstr_Lv[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Lv[index]);
    }
    for (int index = 0; index < 7; ++index)
    {
      if ((Object) this.door.TileMapController != (Object) null && this.door.TileMapController.yolk != null)
      {
        this.btn_W[index].image.sprite = (Sprite) null;
        ((MaskableGraphic) this.btn_W[index].image).material = (Material) null;
      }
    }
    for (int index = 0; index < 30; ++index)
    {
      if ((Object) this.door.TileMapController != (Object) null && this.door.TileMapController.yolk != null)
      {
        this.btn_FederalW[index].image.sprite = (Sprite) null;
        ((MaskableGraphic) this.btn_FederalW[index].image).material = (Material) null;
      }
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (this.bResourse)
        {
          this.SetPage();
          break;
        }
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 1:
        this.SetPage();
        break;
      case 2:
        this.SetNewCenterPos((ushort) 65534);
        break;
      case 3:
        this.SetNewCenterPos((ushort) sender.m_BtnID2);
        break;
      case 4:
        this.SetNewCenterPos((ushort) sender.m_BtnID2);
        break;
    }
  }

  public void SetWonderPos(ushort KID, byte mWonderID, RectTransform mRT)
  {
    this.TcenterID = DataManager.MapDataController.GetYolkPos((ushort) mWonderID, KID);
    if (this.GUIM.IsArabic)
    {
      float num1 = (float) ((double) this.TcenterID.x / 510.0 * 600.0 + ((double) this.mCanvasRT.sizeDelta.x / 2.0 - 300.0));
      float num2 = num1 - this.mCanvasRT.sizeDelta.x / 2f;
      mRT.anchoredPosition = new Vector2((float) ((double) num1 - (double) num2 * 2.0 - (double) mRT.sizeDelta.x / 2.0) - this.mIPhoneX_DeltaX, (float) (-(double) this.TcenterID.y / 1022.0 * 600.0 - ((double) this.mCanvasRT.sizeDelta.y / 2.0 - 300.0) + (double) mRT.sizeDelta.y / 2.0));
    }
    else
      mRT.anchoredPosition = new Vector2((float) ((double) this.TcenterID.x / 510.0 * 600.0 + ((double) this.mCanvasRT.sizeDelta.x / 2.0 - 300.0) - (double) mRT.sizeDelta.x / 2.0) - this.mIPhoneX_DeltaX, (float) (-(double) this.TcenterID.y / 1022.0 * 600.0 - ((double) this.mCanvasRT.sizeDelta.y / 2.0 - 300.0) + (double) mRT.sizeDelta.y / 2.0));
  }

  public void UpdataFederalActivity(bool SetAll = true)
  {
    int index1 = (int) this.ActM.FederalFightingWonderID - this.mWonderNum;
    if (index1 < 0 || index1 >= this.Img_Federal.Length)
      index1 = 0;
    this.Federal_FightRT.anchoredPosition = new Vector2(((Graphic) this.Img_Federal[index1]).rectTransform.anchoredPosition.x + (float) (((double) ((Graphic) this.Img_Federal[index1]).rectTransform.sizeDelta.x - (double) this.Federal_FightRT.sizeDelta.x) / 2.0), ((Graphic) this.Img_Federal[index1]).rectTransform.anchoredPosition.y + 40f);
    if (!SetAll)
      return;
    ((Graphic) this.text_Federal_WonderName[(int) this.mFederal_Home]).color = new Color(0.486f, 0.294f, 0.149f);
    ((Behaviour) this.mtextOutline[(int) this.mFederal_Home]).enabled = false;
    int index2 = (int) this.ActM.FederalHomeKingdomWonderID - this.mWonderNum;
    if (index2 < 0 || index2 >= this.text_Federal_WonderName.Length)
      index2 = 0;
    this.mFederal_Home = (ushort) index2;
    if (this.ActM.FederalHomeKingdomWonderID != (byte) 0)
    {
      ((Behaviour) this.mtextOutline[(int) this.mFederal_Home]).enabled = true;
      ((Graphic) this.text_Federal_WonderName[(int) this.mFederal_Home]).color = new Color(0.0f, 0.894f, 1f);
    }
    this.Federal_HomeRT.anchoredPosition = this.ActM.FederalFightingWonderID == (byte) 0 || index1 != index2 ? new Vector2(((Graphic) this.Img_Federal[index2]).rectTransform.anchoredPosition.x + (float) (((double) ((Graphic) this.Img_Federal[index2]).rectTransform.sizeDelta.x - (double) this.Federal_HomeRT.sizeDelta.x) / 2.0), ((Graphic) this.Img_Federal[index2]).rectTransform.anchoredPosition.y + 34f) : new Vector2((float) ((double) this.Federal_FightRT.anchoredPosition.x + (double) this.Federal_FightRT.sizeDelta.x - 7.0), (float) ((double) this.Federal_FightRT.anchoredPosition.y - ((double) this.Federal_FightRT.sizeDelta.y - (double) this.Federal_HomeRT.sizeDelta.y) + 3.0));
    if (!((Component) this.Img_Federal[index2]).gameObject.activeInHierarchy)
      ((Component) this.Federal_BGRT).gameObject.SetActive(false);
    this.Federal_BGRT.anchoredPosition = new Vector2(((Graphic) this.Img_Federal[index2]).rectTransform.anchoredPosition.x - (float) (((double) this.Federal_BGRT.sizeDelta.x - (double) ((Graphic) this.Img_Federal[index1]).rectTransform.sizeDelta.x) / 2.0), (float) ((double) ((Graphic) this.Img_Federal[index2]).rectTransform.anchoredPosition.y + ((double) this.Federal_BGRT.sizeDelta.y - (double) ((Graphic) this.Img_Federal[index1]).rectTransform.sizeDelta.y) / 2.0 + 2.0));
  }

  public void SetPage()
  {
    this.bResourse = !this.bResourse;
    if (this.bResourse)
    {
      for (int index = 0; index < 7; ++index)
      {
        ((Graphic) this.btn_W[index].image).color = new Color(1f, 1f, 1f, 0.3f);
        ((Component) this.text_WonderName[index]).gameObject.SetActive(false);
      }
      ((Component) this.P1).gameObject.SetActive(false);
      ((Component) this.P2).gameObject.SetActive(true);
      this.text_Title.text = this.mTitle[1];
      ((Component) this.btn_Page).gameObject.SetActive(false);
    }
    else
    {
      for (int index = 0; index < 7; ++index)
      {
        ((Graphic) this.btn_W[index].image).color = new Color(1f, 1f, 1f, 1f);
        ((Component) this.text_WonderName[index]).gameObject.SetActive(true);
      }
      ((Component) this.P1).gameObject.SetActive(true);
      ((Component) this.P2).gameObject.SetActive(false);
      this.text_Title.text = this.mTitle[0];
      ((Component) this.btn_Page).gameObject.SetActive(true);
    }
    this.text_Title.SetAllDirty();
    this.text_Title.cachedTextGenerator.Invalidate();
  }

  public void SetCastle()
  {
    this.TcenterID = GameConstants.getTileMapPosbyMapID(this.DM.RoleAttr.CapitalPoint);
    if (this.GUIM.IsArabic)
    {
      float num1 = (float) ((double) this.TcenterID.x / 512.0 * 600.0 + ((double) this.mCanvasRT.sizeDelta.x / 2.0 - 300.0));
      float num2 = num1 - this.mCanvasRT.sizeDelta.x / 2f;
      this.CastleRT.anchoredPosition = new Vector2(num1 - num2 * 2f - this.mIPhoneX_DeltaX, (float) (-(double) this.TcenterID.y / 1024.0 * 600.0 - ((double) this.mCanvasRT.sizeDelta.y / 2.0 - 300.0)));
    }
    else
      this.CastleRT.anchoredPosition = new Vector2((float) ((double) this.TcenterID.x / 512.0 * 600.0 + ((double) this.mCanvasRT.sizeDelta.x / 2.0 - 300.0)) - this.mIPhoneX_DeltaX, (float) (-(double) this.TcenterID.y / 1024.0 * 600.0 - ((double) this.mCanvasRT.sizeDelta.y / 2.0 - 300.0)));
    this.TcenterID = this.GUIM.mNewCenterPos;
    if (this.GUIM.IsArabic)
    {
      float num3 = (float) ((double) this.TcenterID.x / 512.0 * 600.0 + ((double) this.mCanvasRT.sizeDelta.x / 2.0 - 300.0));
      float num4 = num3 - this.mCanvasRT.sizeDelta.x / 2f;
      this.NewCenterPosRT.anchoredPosition = new Vector2(num3 - num4 * 2f - this.mIPhoneX_DeltaX, (float) (-(double) this.TcenterID.y / 1024.0 * 600.0 - ((double) this.mCanvasRT.sizeDelta.y / 2.0 - 300.0)));
    }
    else
      this.NewCenterPosRT.anchoredPosition = new Vector2((float) ((double) this.TcenterID.x / 512.0 * 600.0 + ((double) this.mCanvasRT.sizeDelta.x / 2.0 - 300.0)) - this.mIPhoneX_DeltaX, (float) (-(double) this.TcenterID.y / 1024.0 * 600.0 - ((double) this.mCanvasRT.sizeDelta.y / 2.0 - 300.0)));
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    this.bSetPosShow = false;
    this.PosX = this.PosY = 0;
  }

  public void OnPointerUp(PointerEventData eventData)
  {
    Vector2 vector2;
    if ((double) Mathf.Abs(eventData.pressPosition.x - eventData.position.x) >= 50.0 || (double) Mathf.Abs(eventData.pressPosition.y - eventData.position.y) >= 50.0 || !RectTransformUtility.ScreenPointToLocalPointInRectangle(((Graphic) this.P1).rectTransform, eventData.position, eventData.pressEventCamera, ref vector2))
      return;
    float num1 = !this.GUIM.IsArabic ? (float) (((double) vector2.x + 300.0) / 600.0 * 510.0) : (float) ((300.0 - (double) vector2.x) / 600.0 * 510.0);
    float num2 = (float) ((600.0 - ((double) vector2.y + 300.0)) / 600.0 * 1022.0);
    float num3 = Mathf.Clamp(num1, 0.0f, 510f);
    float num4 = Mathf.Clamp(num2, 0.0f, 1022f);
    if (!DataManager.MapDataController.CheckKingdomID(DataManager.MapDataController.FocusKingdomID) || !GameConstants.CheckTileMapPos((int) num3, (int) num4))
      return;
    this.SetNewCenterPos(ushort.MaxValue, (int) num3, (int) num4);
  }

  public void SetNewCenterPos(ushort mType = 65535, int mPosX = 0, int mPosY = 0)
  {
    this.PosX = mPosX;
    this.PosY = mPosY;
    this.bSetPosShow = true;
    this.mShowTime = 0.0f;
    this.mGoToType = mType;
    switch (mType)
    {
      case 65534:
        this.TcenterID = GameConstants.getTileMapPosbyMapID(this.DM.RoleAttr.CapitalPoint);
        break;
      case ushort.MaxValue:
        this.TcenterID.Set((float) this.PosX, (float) this.PosY);
        break;
      default:
        this.TcenterID = DataManager.MapDataController.GetYolkPos(mType, DataManager.MapDataController.FocusKingdomID);
        break;
    }
    this.PosX = (int) this.TcenterID.x;
    this.PosY = (int) this.TcenterID.y;
    if (this.GUIM.IsArabic)
    {
      float num1 = (float) ((double) this.TcenterID.x / 512.0 * 600.0 + ((double) this.mCanvasRT.sizeDelta.x / 2.0 - 300.0));
      float num2 = num1 - this.mCanvasRT.sizeDelta.x / 2f;
      this.NewCenterPosRT.anchoredPosition = new Vector2(num1 - num2 * 2f - this.mIPhoneX_DeltaX, (float) (-(double) this.TcenterID.y / 1024.0 * 600.0 - ((double) this.mCanvasRT.sizeDelta.y / 2.0 - 300.0)));
    }
    else
      this.NewCenterPosRT.anchoredPosition = new Vector2((float) ((double) this.TcenterID.x / 512.0 * 600.0 + ((double) this.mCanvasRT.sizeDelta.x / 2.0 - 300.0)) - this.mIPhoneX_DeltaX, (float) (-(double) this.TcenterID.y / 1024.0 * 600.0 - ((double) this.mCanvasRT.sizeDelta.y / 2.0 - 300.0)));
    ((Transform) this.NewCenterPosRT).localScale = new Vector3(3f, 3f, 3f);
    ((Graphic) this.Img_NewCenterPos).color = new Color(1f, 1f, 1f, 0.0f);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        ushort num = DataManager.MapDataController.FocusKingdomID == (ushort) 0 ? DataManager.MapDataController.OtherKingdomData.kingdomID : DataManager.MapDataController.FocusKingdomID;
        for (int index = 0; index < 40; ++index)
        {
          if (index == 0)
            ((Component) this.Img_W[index]).gameObject.SetActive(DataManager.MapDataController.CheckYolk((ushort) index, num));
          else if (DataManager.MapDataController.IsFocusWorldWar())
          {
            if (index < this.Img_W.Length)
              ((Component) this.Img_W[index]).gameObject.SetActive(false);
            if (index < this.Img_Federal.Length + 1)
            {
              ((Component) this.Img_Federal[index - 1]).gameObject.SetActive(DataManager.MapDataController.CheckYolk((ushort) index, num));
              if (((Component) this.Img_Federal[index - 1]).gameObject.activeSelf)
              {
                this.Img_Federal[index - 1].sprite = this.door.TileMapController.yolk.getMapTileYolkSprite((byte) index);
                ((MaskableGraphic) this.Img_Federal[index - 1]).material = this.door.TileMapController.yolk.getMapTileYolkMaterial((byte) index);
                this.text_Federal_WonderName[index - 1].text = DataManager.MapDataController.GetYolkName((ushort) index, num).ToString();
                this.SetWonderPos(num, (byte) index, ((Graphic) this.Img_Federal[index - 1]).rectTransform);
                ((Behaviour) this.mtextOutline[index - 1]).enabled = false;
              }
            }
          }
          else
          {
            if (index < this.Img_W.Length)
              ((Component) this.Img_W[index]).gameObject.SetActive(DataManager.MapDataController.CheckYolk((ushort) index, num));
            if (index < this.Img_Federal.Length + 1)
              ((Component) this.Img_Federal[index - 1]).gameObject.SetActive(false);
          }
          if (index < this.Img_W.Length && (Object) this.Img_W[index] != (Object) null && ((Component) this.Img_W[index]).gameObject.activeSelf && (Object) this.Img_W[index].sprite == (Object) null)
          {
            this.Img_W[index].sprite = this.door.TileMapController.yolk.getMapTileYolkSprite((byte) index);
            ((MaskableGraphic) this.Img_W[index]).material = this.door.TileMapController.yolk.getMapTileYolkMaterial((byte) index);
          }
        }
        if (!DataManager.MapDataController.IsFocusWorldWar())
          break;
        if (this.ActM.FederalFightingWonderID != (byte) 0)
          ((Component) this.Federal_FightRT).gameObject.SetActive(true);
        else
          ((Component) this.Federal_FightRT).gameObject.SetActive(false);
        if (this.ActM.FederalHomeKingdomWonderID != (byte) 0)
        {
          ((Component) this.Federal_HomeRT).gameObject.SetActive(true);
          ((Component) this.Federal_BGRT).gameObject.SetActive(true);
        }
        else
        {
          ((Component) this.Federal_HomeRT).gameObject.SetActive(false);
          ((Component) this.Federal_BGRT).gameObject.SetActive(false);
        }
        this.UpdataFederalActivity();
        break;
      case 1:
        if (!DataManager.MapDataController.IsFocusWorldWar())
          break;
        if (this.ActM.FederalFightingWonderID != (byte) 0)
          ((Component) this.Federal_FightRT).gameObject.SetActive(true);
        else
          ((Component) this.Federal_FightRT).gameObject.SetActive(false);
        if (this.ActM.FederalHomeKingdomWonderID != (byte) 0)
        {
          ((Component) this.Federal_HomeRT).gameObject.SetActive(true);
          ((Component) this.Federal_BGRT).gameObject.SetActive(true);
        }
        else
        {
          ((Component) this.Federal_HomeRT).gameObject.SetActive(false);
          ((Component) this.Federal_BGRT).gameObject.SetActive(false);
        }
        this.UpdataFederalActivity();
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.FocusKingdomID)
          ((Component) this.CastleRT).gameObject.SetActive(true);
        else
          ((Component) this.CastleRT).gameObject.SetActive(false);
        this.SetCastle();
        ushort num = DataManager.MapDataController.FocusKingdomID == (ushort) 0 ? DataManager.MapDataController.OtherKingdomData.kingdomID : DataManager.MapDataController.FocusKingdomID;
        for (int index = 0; index < 40; ++index)
        {
          if (index == 0)
            ((Component) this.Img_W[index]).gameObject.SetActive(DataManager.MapDataController.CheckYolk((ushort) index, num));
          else if (DataManager.MapDataController.IsFocusWorldWar())
          {
            if (index < this.Img_W.Length)
              ((Component) this.Img_W[index]).gameObject.SetActive(false);
            if (index < this.Img_Federal.Length + 1)
            {
              ((Component) this.Img_Federal[index - 1]).gameObject.SetActive(DataManager.MapDataController.CheckYolk((ushort) index, num));
              if (((Component) this.Img_Federal[index - 1]).gameObject.activeSelf)
              {
                this.Img_Federal[index - 1].sprite = this.door.TileMapController.yolk.getMapTileYolkSprite((byte) index);
                ((MaskableGraphic) this.Img_Federal[index - 1]).material = this.door.TileMapController.yolk.getMapTileYolkMaterial((byte) index);
                this.text_Federal_WonderName[index - 1].text = DataManager.MapDataController.GetYolkName((ushort) index, num).ToString();
                this.SetWonderPos(num, (byte) index, ((Graphic) this.Img_Federal[index - 1]).rectTransform);
                ((Behaviour) this.mtextOutline[index - 1]).enabled = false;
              }
            }
          }
          else
          {
            if (index < this.Img_W.Length)
              ((Component) this.Img_W[index]).gameObject.SetActive(DataManager.MapDataController.CheckYolk((ushort) index, num));
            if (index < this.Img_Federal.Length + 1)
              ((Component) this.Img_Federal[index - 1]).gameObject.SetActive(false);
          }
          if (index < this.Img_W.Length && (Object) this.Img_W[index] != (Object) null && ((Component) this.Img_W[index]).gameObject.activeSelf && (Object) this.Img_W[index].sprite == (Object) null)
          {
            this.Img_W[index].sprite = this.door.TileMapController.yolk.getMapTileYolkSprite((byte) index);
            ((MaskableGraphic) this.Img_W[index]).material = this.door.TileMapController.yolk.getMapTileYolkMaterial((byte) index);
          }
        }
        if (!DataManager.MapDataController.IsFocusWorldWar())
          break;
        if (this.ActM.FederalFightingWonderID != (byte) 0)
          ((Component) this.Federal_FightRT).gameObject.SetActive(true);
        else
          ((Component) this.Federal_FightRT).gameObject.SetActive(false);
        if (this.ActM.FederalHomeKingdomWonderID != (byte) 0)
        {
          ((Component) this.Federal_HomeRT).gameObject.SetActive(true);
          ((Component) this.Federal_BGRT).gameObject.SetActive(true);
        }
        else
        {
          ((Component) this.Federal_HomeRT).gameObject.SetActive(false);
          ((Component) this.Federal_BGRT).gameObject.SetActive(false);
        }
        this.UpdataFederalActivity();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Title != (Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((Object) this.text_Castle != (Object) null && ((Behaviour) this.text_Castle).enabled)
    {
      ((Behaviour) this.text_Castle).enabled = false;
      ((Behaviour) this.text_Castle).enabled = true;
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((Object) this.text_Lv[index] != (Object) null && ((Behaviour) this.text_Lv[index]).enabled)
      {
        ((Behaviour) this.text_Lv[index]).enabled = false;
        ((Behaviour) this.text_Lv[index]).enabled = true;
      }
    }
    for (int index = 0; index < 7; ++index)
    {
      if ((Object) this.text_WonderName[index] != (Object) null && ((Behaviour) this.text_WonderName[index]).enabled)
      {
        ((Behaviour) this.text_WonderName[index]).enabled = false;
        ((Behaviour) this.text_WonderName[index]).enabled = true;
      }
    }
    for (int index = 0; index < 30; ++index)
    {
      if ((Object) this.text_Federal_WonderName[index] != (Object) null && ((Behaviour) this.text_Federal_WonderName[index]).enabled)
      {
        ((Behaviour) this.text_Federal_WonderName[index]).enabled = false;
        ((Behaviour) this.text_Federal_WonderName[index]).enabled = true;
      }
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (bOnSecond || !this.bSetPosShow || !((Object) this.door != (Object) null))
      return;
    this.mShowTime += Time.smoothDeltaTime;
    if ((double) this.mShowTime < 0.10000000149011612)
    {
      this.mscaleValue = Mathf.Lerp(2.5f, 1f, this.mShowTime / 0.1f);
      this.malphaValue = Mathf.Lerp(0.0f, 1f, this.mShowTime / 0.1f);
    }
    else
    {
      this.mscaleValue = 1f;
      this.malphaValue = 1f;
    }
    ((Transform) this.NewCenterPosRT).localScale = new Vector3(this.mscaleValue, this.mscaleValue, this.mscaleValue);
    ((Graphic) this.Img_NewCenterPos).color = new Color(1f, 1f, 1f, this.malphaValue);
    if ((double) this.mShowTime < 0.10000000149011612)
      return;
    this.bSetPosShow = false;
    this.mShowTime = 0.0f;
    this.door.CheckFocusGroup();
    DataManager.MapDataController.FocusGroupID = (byte) 10;
    this.door.GoToMapID(DataManager.MapDataController.FocusKingdomID, GameConstants.TileMapPosToMapID(this.PosX, this.PosY), (byte) 0, (byte) 1);
  }
}
