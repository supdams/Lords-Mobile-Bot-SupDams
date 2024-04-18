// Decompiled with JetBrains decompiler
// Type: UIAlliance_Badge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIAlliance_Badge : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform Img_BadgeT;
  private Transform Img_BadgeFrameT;
  private Transform Img_ColorFrameT;
  private Transform Img_TotemFrameT;
  private Transform[] btn_BadgeT = new Transform[8];
  private Transform[] btn_ColorT = new Transform[8];
  private RectTransform Img_BadgeFrameRT;
  private RectTransform Img_ColorFrameRT;
  private RectTransform Img_TotemFrameRT;
  private UIButton btn_EXIT;
  private UIButton[] btn_Badge = new UIButton[8];
  private UIButton[] btn_Color = new UIButton[8];
  private UIButton btn_Random;
  private UIButton btn_Accept;
  private UIButton btn_Accept_y;
  private UIButton tmpbtn;
  private Image Img_BadgeFrame;
  private Image Img_ColorFrame;
  private Image Img_TotemFrame;
  private Image tmpImg;
  private Image[] Img_Totem = new Image[32];
  private Sprite[] m_TotemSprite = new Sprite[64];
  private UIText text_AcceptValue;
  private UIText[] tmptext_Str = new UIText[6];
  private ScrollPanel m_ScrollPanel;
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[4];
  private StringBuilder tmpString = new StringBuilder();
  private DataManager DM;
  private GUIManager GUIM;
  private Font TTFont;
  private Door door;
  private Material BadgeMaterial;
  private Material TotemMaterial;
  private int mTotem;
  private int mTotemIndex;
  private int mBadge;
  private int mColor;
  private bool bNeed;
  private uint NeedValue;
  private int tmpBadge;
  private int tmpTotem;
  private ushort tmpEmblem;
  private float[] tmpShow = new float[3];

  public override void OnOpen(int arg1, int arg2)
  {
    this.NeedValue = (uint) arg1;
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.BadgeMaterial = this.GUIM.GetBadgeMaterial(true);
    this.TotemMaterial = this.GUIM.GetBadgeMaterial(false);
    this.Tmp = this.GameT.GetChild(0);
    this.Tmp1 = this.Tmp.GetChild(0).GetChild(0).GetChild(0);
    this.tmptext_Str[0] = this.Tmp1.GetComponent<UIText>();
    this.tmptext_Str[0].font = this.TTFont;
    this.tmptext_Str[0].text = this.DM.mStringTable.GetStringByID(4732U);
    this.Tmp = this.GameT.GetChild(1);
    this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
    this.tmptext_Str[1] = this.Tmp1.GetComponent<UIText>();
    this.tmptext_Str[1].font = this.TTFont;
    this.tmptext_Str[1].text = this.DM.mStringTable.GetStringByID(4733U);
    for (int index = 0; index < 8; ++index)
    {
      this.btn_BadgeT[index] = this.Tmp.GetChild(1 + index);
      this.btn_BadgeT[index] = this.Tmp.GetChild(1 + index).GetChild(0);
      this.btn_Badge[index] = this.btn_BadgeT[index].GetComponent<UIButton>();
      this.btn_Badge[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Badge[index].m_BtnID1 = 1 + index;
      this.btn_Badge[index].m_EffectType = e_EffectType.e_Scale;
      this.btn_Badge[index].transition = (Selectable.Transition) 0;
      this.tmpImg = this.btn_BadgeT[index].GetComponent<Image>();
      this.tmpString.Length = 0;
      this.tmpString.AppendFormat("UI_league_badge_{0:00}", (object) (1 + index * 8));
      this.tmpImg.sprite = this.GUIM.LoadBadgeSprite(true, this.tmpString.ToString());
      ((MaskableGraphic) this.tmpImg).material = this.BadgeMaterial;
    }
    this.Img_BadgeFrameT = this.Tmp.GetChild(9);
    this.Img_BadgeFrame = this.Img_BadgeFrameT.GetComponent<Image>();
    this.Img_BadgeFrameRT = this.Img_BadgeFrameT.GetComponent<RectTransform>();
    this.Img_BadgeFrameRT.anchoredPosition = new Vector2(0.0f, 0.0f);
    this.Tmp = this.GameT.GetChild(2);
    for (int index = 0; index < 8; ++index)
    {
      this.btn_ColorT[index] = this.Tmp.GetChild(index);
      this.btn_Color[index] = this.btn_ColorT[index].GetComponent<UIButton>();
      this.btn_Color[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Color[index].m_BtnID1 = 9 + index;
      this.btn_Color[index].m_EffectType = e_EffectType.e_Scale;
      this.btn_Color[index].transition = (Selectable.Transition) 0;
    }
    this.Img_ColorFrameT = this.Tmp.GetChild(8);
    this.Img_ColorFrame = this.Img_ColorFrameT.GetComponent<Image>();
    this.Img_ColorFrameRT = this.Img_ColorFrameT.GetComponent<RectTransform>();
    this.Img_ColorFrameRT.anchoredPosition = new Vector2(1f, 1.5f);
    this.Tmp = this.GameT.GetChild(3);
    this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
    this.tmptext_Str[2] = this.Tmp1.GetComponent<UIText>();
    this.tmptext_Str[2].font = this.TTFont;
    this.tmptext_Str[2].text = this.DM.mStringTable.GetStringByID(4734U);
    this.Tmp1 = this.Tmp.GetChild(1);
    this.m_ScrollPanel = this.Tmp1.GetComponent<ScrollPanel>();
    List<float> _DataHeight = new List<float>();
    for (int index1 = 0; index1 < 8; ++index1)
    {
      this.Tmp1 = this.Tmp.GetChild(2).GetChild(index1);
      this.tmpbtn = this.Tmp1.GetComponent<UIButton>();
      this.tmpbtn.m_Handler = (IUIButtonClickHandler) this;
      this.tmpbtn.m_BtnID1 = 17 + index1;
      this.tmpbtn.m_EffectType = e_EffectType.e_Scale;
      this.tmpbtn.transition = (Selectable.Transition) 0;
      _DataHeight.Add(92f);
      for (int index2 = 0; index2 < 8; ++index2)
      {
        this.tmpString.Length = 0;
        this.tmpString.AppendFormat("UI_league_totem_{0:00}", (object) (1 + index1 * 8 + index2));
        this.m_TotemSprite[index1 * 8 + index2] = this.GUIM.LoadBadgeSprite(false, this.tmpString.ToString());
      }
    }
    this.Img_TotemFrameT = this.Tmp.GetChild(3);
    this.Img_TotemFrame = this.Img_TotemFrameT.GetComponent<Image>();
    this.Img_TotemFrameRT = this.Img_TotemFrameT.GetComponent<RectTransform>();
    this.Img_TotemFrameRT.anchoredPosition = new Vector2(0.0f, 0.0f);
    this.m_ScrollPanel.IntiScrollPanel(239f, 0.0f, 0.0f, _DataHeight, 4, (IUpDateScrollPanel) this);
    this.Tmp = this.GameT.GetChild(4);
    this.Img_BadgeT = this.Tmp.GetChild(0).GetChild(1);
    this.tmpEmblem = this.DM.CurSelectBadge;
    this.GUIM.InitBadgeTotem(this.Img_BadgeT, this.tmpEmblem);
    if (!this.Img_BadgeT.gameObject.activeSelf)
    {
      this.tmpBadge = Random.Range(1, 64);
      this.tmpTotem = Random.Range(1, 64);
      this.GUIM.SetBadgeTotemImg(this.Img_BadgeT, this.tmpBadge, this.tmpTotem);
    }
    else
    {
      this.tmpBadge = ((int) this.tmpEmblem >> 3 & 7) * 8 + ((int) this.tmpEmblem & 7) + 1;
      if (this.tmpBadge > 64)
        this.tmpBadge = 64;
      this.tmpTotem = ((int) this.tmpEmblem >> 6 & 63) + 1;
      if (this.tmpTotem > 64)
        this.tmpTotem = 64;
    }
    this.SetRandomBadgeTotem(this.tmpBadge, this.tmpTotem);
    this.Tmp1 = this.Tmp.GetChild(1);
    this.btn_Random = this.Tmp1.GetComponent<UIButton>();
    this.btn_Random.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Random.m_BtnID1 = 25;
    this.btn_Random.m_EffectType = e_EffectType.e_Scale;
    this.btn_Random.transition = (Selectable.Transition) 0;
    this.Tmp1 = this.Tmp.GetChild(2);
    this.btn_Accept = this.Tmp1.GetComponent<UIButton>();
    this.btn_Accept.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Accept.m_BtnID1 = 26;
    this.btn_Accept.m_EffectType = e_EffectType.e_Scale;
    this.btn_Accept.transition = (Selectable.Transition) 0;
    this.Tmp1 = this.Tmp.GetChild(2).GetChild(0).GetChild(0);
    this.text_AcceptValue = this.Tmp1.GetComponent<UIText>();
    this.text_AcceptValue.font = this.TTFont;
    this.Tmp1 = this.Tmp.GetChild(2).GetChild(1);
    this.tmptext_Str[3] = this.Tmp1.GetComponent<UIText>();
    this.tmptext_Str[3].font = this.TTFont;
    this.tmptext_Str[3].text = this.DM.mStringTable.GetStringByID(4736U);
    this.Tmp1 = this.Tmp.GetChild(3);
    this.btn_Accept_y = this.Tmp1.GetComponent<UIButton>();
    this.btn_Accept_y.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Accept_y.m_BtnID1 = 27;
    this.btn_Accept_y.m_EffectType = e_EffectType.e_Scale;
    this.btn_Accept_y.transition = (Selectable.Transition) 0;
    this.Tmp1 = this.Tmp.GetChild(3).GetChild(0);
    this.tmptext_Str[4] = this.Tmp1.GetComponent<UIText>();
    this.tmptext_Str[4].font = this.TTFont;
    this.tmptext_Str[4].text = this.DM.mStringTable.GetStringByID(4736U);
    if (this.NeedValue != 0U)
      this.bNeed = true;
    if (this.bNeed)
    {
      ((Component) this.btn_Accept).gameObject.SetActive(true);
      this.tmpString.Length = 0;
      GameConstants.FormatValue(this.tmpString, this.NeedValue);
      this.text_AcceptValue.text = this.tmpString.ToString();
    }
    else
      ((Component) this.btn_Accept_y).gameObject.SetActive(true);
    this.Tmp1 = this.Tmp.GetChild(4);
    this.tmptext_Str[5] = this.Tmp1.GetComponent<UIText>();
    this.tmptext_Str[5].font = this.TTFont;
    this.tmptext_Str[5].text = this.DM.mStringTable.GetStringByID(4735U);
    this.tmpImg = this.GameT.GetChild(6).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.tmpImg).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(6).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.door.LoadMaterial();
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((Object) this.tmpItem[panelObjectIdx] == (Object) null)
    {
      this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
      for (int index = 0; index < 8; ++index)
      {
        this.Tmp = item.transform.GetChild(index);
        this.tmpbtn = this.Tmp.GetComponent<UIButton>();
        this.tmpbtn.m_Handler = (IUIButtonClickHandler) this;
        this.tmpbtn.m_BtnID2 = panelObjectIdx;
        this.Img_Totem[panelObjectIdx * 8 + index] = this.Tmp.GetComponent<Image>();
        this.Img_Totem[panelObjectIdx * 8 + index].sprite = this.m_TotemSprite[dataIdx * 8 + index];
        ((MaskableGraphic) this.Img_Totem[panelObjectIdx * 8 + index]).material = this.TotemMaterial;
      }
    }
    else
    {
      if (panelObjectIdx == this.mTotemIndex)
        this.Img_TotemFrameT.gameObject.SetActive(false);
      for (int index = 0; index < 8; ++index)
      {
        this.Img_Totem[panelObjectIdx * 8 + index].sprite = this.m_TotemSprite[dataIdx * 8 + index];
        if (this.mTotem == dataIdx * 8 + index)
        {
          this.Img_TotemFrameT.SetParent(((Component) this.Img_Totem[panelObjectIdx * 8 + index]).GetComponent<Transform>(), false);
          this.mTotemIndex = panelObjectIdx;
          this.Img_TotemFrameT.gameObject.SetActive(true);
          this.tmpShow[2] = 0.0f;
        }
      }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void OnClose()
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 7:
      case 8:
        this.mBadge = sender.m_BtnID1 - 1;
        this.Img_BadgeFrameT.SetParent(this.btn_BadgeT[this.mBadge], false);
        this.tmpShow[0] = 0.0f;
        this.tmpBadge = this.mBadge * 8 + this.mColor + 1;
        this.GUIM.SetBadgeTotemImg(this.Img_BadgeT, this.tmpBadge, this.tmpTotem);
        break;
      case 9:
      case 10:
      case 11:
      case 12:
      case 13:
      case 14:
      case 15:
      case 16:
        this.mColor = sender.m_BtnID1 - 9;
        this.Img_ColorFrameT.SetParent(this.btn_ColorT[this.mColor], false);
        this.tmpShow[1] = 0.0f;
        this.tmpBadge = this.mBadge * 8 + this.mColor + 1;
        for (int index = 0; index < 8; ++index)
        {
          this.tmpImg = this.btn_BadgeT[index].GetComponent<Image>();
          this.tmpString.Length = 0;
          this.tmpString.AppendFormat("UI_league_badge_{0:00}", (object) (1 + index * 8 + this.mColor));
          this.tmpImg.sprite = this.GUIM.LoadBadgeSprite(true, this.tmpString.ToString());
        }
        this.GUIM.SetBadgeTotemImg(this.Img_BadgeT, this.tmpBadge, this.tmpTotem);
        break;
      case 17:
      case 18:
      case 19:
      case 20:
      case 21:
      case 22:
      case 23:
      case 24:
        Transform parent = ((Component) sender).gameObject.transform.parent;
        this.Img_TotemFrameT.SetParent(((Component) sender).GetComponent<Transform>(), false);
        this.mTotem = parent.GetComponent<ScrollPanelItem>().m_BtnID1 * 8 + sender.m_BtnID1 - 17;
        this.mTotemIndex = parent.GetComponent<ScrollPanelItem>().m_BtnID2;
        this.tmpTotem = this.mTotem + 1;
        if (!this.Img_TotemFrameT.gameObject.activeSelf)
          this.Img_TotemFrameT.gameObject.SetActive(true);
        this.tmpShow[2] = 0.0f;
        this.GUIM.SetBadgeTotemImg(this.Img_BadgeT, this.tmpBadge, this.tmpTotem);
        break;
      case 25:
        this.tmpBadge = Random.Range(1, 64);
        this.tmpTotem = Random.Range(1, 64);
        this.SetRandomBadgeTotem(this.tmpBadge, this.tmpTotem);
        this.GUIM.SetBadgeTotemImg(this.Img_BadgeT, this.tmpBadge, this.tmpTotem);
        break;
      case 26:
        if (this.DM.RoleAttr.Diamond < this.NeedValue)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(3966U), (ushort) byte.MaxValue);
          break;
        }
        ushort num = (ushort) (this.tmpTotem - 1 << 6 | this.tmpBadge - 1);
        if ((int) this.tmpEmblem == (int) num)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4749U), (ushort) byte.MaxValue);
          break;
        }
        if (this.GUIM.OpenCheckCrystal(this.NeedValue, (byte) 5, (int) this.m_eWindow << 16 | 100, (int) num))
          break;
        this.SendModifyEmblem(num);
        break;
      case 27:
        this.DM.CurSelectBadge = (ushort) (this.tmpTotem - 1 << 6 | this.tmpBadge - 1);
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
    }
  }

  private void SendModifyEmblem(ushort tmpValue)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Alliance_Manage))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_EMBLEM;
    messagePacket.AddSeqId();
    messagePacket.Add(tmpValue);
    messagePacket.Send();
  }

  public void SetRandomBadgeTotem(int tmpBadge, int tmpTotem)
  {
    this.mBadge = (tmpBadge - 1) / 8;
    this.mColor = (tmpBadge - 1) % 8;
    this.Img_BadgeFrameT.SetParent(this.btn_BadgeT[this.mBadge], false);
    if (!this.Img_BadgeFrameT.gameObject.activeSelf)
      this.Img_BadgeFrameT.gameObject.SetActive(true);
    this.tmpShow[0] = 0.0f;
    this.Img_ColorFrameT.SetParent(this.btn_ColorT[this.mColor], false);
    if (!this.Img_ColorFrameT.gameObject.activeSelf)
      this.Img_ColorFrameT.gameObject.SetActive(true);
    this.tmpShow[1] = 0.0f;
    for (int index = 0; index < 8; ++index)
    {
      this.tmpImg = this.btn_BadgeT[index].GetComponent<Image>();
      this.tmpString.Length = 0;
      this.tmpString.AppendFormat("UI_league_badge_{0:00}", (object) (1 + index * 8 + this.mColor));
      this.tmpImg.sprite = this.GUIM.LoadBadgeSprite(true, this.tmpString.ToString());
    }
    this.mTotem = tmpTotem - 1;
    bool flag = false;
    for (int index1 = 0; index1 < 4; ++index1)
    {
      for (int index2 = 0; index2 < 8; ++index2)
      {
        if (this.mTotem == this.tmpItem[index1].m_BtnID1 * 8 + index2)
        {
          this.Img_TotemFrameT.SetParent(((Component) this.Img_Totem[this.tmpItem[index1].m_BtnID2 * 8 + index2]).GetComponent<Transform>(), false);
          this.mTotemIndex = this.tmpItem[index1].m_BtnID2;
          flag = true;
        }
      }
    }
    if (flag && !this.Img_TotemFrameT.gameObject.activeSelf)
      this.Img_TotemFrameT.gameObject.SetActive(true);
    else if (!flag)
    {
      this.Img_TotemFrameT.gameObject.SetActive(false);
      this.mTotemIndex = -1;
    }
    this.tmpShow[2] = 0.0f;
    if (this.Img_BadgeT.gameObject.activeSelf)
      return;
    this.Img_BadgeT.gameObject.SetActive(true);
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
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_AcceptValue != (Object) null && ((Behaviour) this.text_AcceptValue).enabled)
    {
      ((Behaviour) this.text_AcceptValue).enabled = false;
      ((Behaviour) this.text_AcceptValue).enabled = true;
    }
    for (int index = 0; index < 6; ++index)
    {
      if ((Object) this.tmptext_Str[index] != (Object) null && ((Behaviour) this.tmptext_Str[index]).enabled)
      {
        ((Behaviour) this.tmptext_Str[index]).enabled = false;
        ((Behaviour) this.tmptext_Str[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 100:
        this.SendModifyEmblem((ushort) arg2);
        break;
    }
  }

  private void Update()
  {
    if (((UIBehaviour) this.Img_BadgeFrame).IsActive())
    {
      this.tmpShow[0] += Time.smoothDeltaTime;
      if ((double) this.tmpShow[0] >= 2.0)
        this.tmpShow[0] = 0.0f;
      ((Graphic) this.Img_BadgeFrame).color = new Color(1f, 1f, 1f, (double) this.tmpShow[0] <= 1.0 ? this.tmpShow[0] : 2f - this.tmpShow[0]);
    }
    if (((UIBehaviour) this.Img_ColorFrame).IsActive())
    {
      this.tmpShow[1] += Time.smoothDeltaTime;
      if ((double) this.tmpShow[1] >= 2.0)
        this.tmpShow[1] = 0.0f;
      ((Graphic) this.Img_ColorFrame).color = new Color(1f, 1f, 1f, (double) this.tmpShow[1] <= 1.0 ? this.tmpShow[1] : 2f - this.tmpShow[1]);
    }
    if (!((UIBehaviour) this.Img_TotemFrame).IsActive())
      return;
    this.tmpShow[2] += Time.smoothDeltaTime;
    if ((double) this.tmpShow[2] >= 2.0)
      this.tmpShow[2] = 0.0f;
    ((Graphic) this.Img_TotemFrame).color = new Color(1f, 1f, 1f, (double) this.tmpShow[2] <= 1.0 ? this.tmpShow[2] : 2f - this.tmpShow[2]);
  }
}
