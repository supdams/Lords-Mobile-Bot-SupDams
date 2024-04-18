// Decompiled with JetBrains decompiler
// Type: UIOther_Set
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIOther_Set : GUIWindow, IUIButtonClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private Door door;
  private Transform GameT;
  private UIButton btn_EXIT;
  private UIButton btn_Music;
  private UIButton btn_Sound;
  private UIButton btn_AutoTranslate;
  private UIButton[] btn_UR = new UIButton[3];
  private UIButton btn_Music_Old;
  private UIButton btn_Music_New;
  private Image tmpImg;
  private Image Img_Music;
  private Image Img_Sound;
  private Image Img_AutoTranslate;
  private Image[] Img_UR = new Image[3];
  private Image Img_Music_Old;
  private Image Img_Music_New;
  private UIText[] text_UR = new UIText[3];
  private UIText[] text_tmpStr = new UIText[6];
  private UIText[] text_MusicSelect = new UIText[3];
  private Material m_Mat;
  private CScrollRect m_Mask;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.text_tmpStr[0] = this.GameT.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[0].font = this.TTFont;
    this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7024U);
    this.m_Mask = this.GameT.GetChild(1).GetComponent<CScrollRect>();
    Transform child1 = this.GameT.GetChild(1).GetChild(0);
    Transform child2 = child1.GetChild(0).GetChild(0);
    this.btn_Music = child2.GetComponent<UIButton>();
    this.btn_Music.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Music.m_BtnID1 = 1;
    this.Img_Music = child2.GetChild(1).GetComponent<Image>();
    if (this.GUIM.IsArabic)
    {
      ((Component) this.Img_Music).transform.localScale = new Vector3(-1f, ((Component) this.Img_Music).transform.localScale.y, ((Component) this.Img_Music).transform.localScale.z);
      child2.GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
    }
    Transform child3 = child1.GetChild(0).GetChild(1);
    this.btn_Sound = child3.GetComponent<UIButton>();
    this.btn_Sound.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Sound.m_BtnID1 = 2;
    this.Img_Sound = child3.GetChild(1).GetComponent<Image>();
    if (this.GUIM.IsArabic)
    {
      ((Component) this.Img_Sound).transform.localScale = new Vector3(-1f, ((Component) this.Img_Sound).transform.localScale.y, ((Component) this.Img_Sound).transform.localScale.z);
      child3.GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
    }
    this.text_tmpStr[1] = child1.GetChild(0).GetChild(2).GetComponent<UIText>();
    this.text_tmpStr[1].font = this.TTFont;
    this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(7032U);
    Transform child4 = child1.GetChild(1);
    this.btn_Music_Old = child4.GetChild(0).GetComponent<UIButton>();
    this.btn_Music_Old.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Music_Old.m_BtnID1 = 8;
    this.Img_Music_Old = child4.GetChild(0).GetChild(0).GetComponent<Image>();
    this.btn_Music_New = child4.GetChild(1).GetComponent<UIButton>();
    this.btn_Music_New.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Music_New.m_BtnID1 = 9;
    this.Img_Music_New = child4.GetChild(1).GetChild(0).GetComponent<Image>();
    if (this.GUIM.IsArabic)
    {
      ((Component) this.Img_Music_Old).gameObject.AddComponent<ArabicItemTextureRot>();
      ((Component) this.Img_Music_New).gameObject.AddComponent<ArabicItemTextureRot>();
    }
    for (int index = 0; index < 3; ++index)
    {
      this.text_MusicSelect[index] = child4.GetChild(2 + index).GetComponent<UIText>();
      this.text_MusicSelect[index].font = this.TTFont;
      this.text_MusicSelect[index].text = this.DM.mStringTable.GetStringByID((uint) (ushort) (16104 + index));
    }
    this.text_tmpStr[2] = child1.GetChild(2).GetChild(3).GetComponent<UIText>();
    this.text_tmpStr[2].font = this.TTFont;
    this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(7034U);
    Transform child5 = child1.GetChild(2);
    for (int index = 0; index < 3; ++index)
    {
      this.btn_UR[index] = child5.GetChild(index).GetComponent<UIButton>();
      this.btn_UR[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_UR[index].m_BtnID1 = 3 + index;
      this.Img_UR[index] = child5.GetChild(index).GetChild(0).GetComponent<Image>();
      if (this.GUIM.IsArabic)
        ((Component) this.Img_UR[index]).transform.localScale = new Vector3(-1f, ((Component) this.Img_UR[index]).transform.localScale.y, ((Component) this.Img_UR[index]).transform.localScale.z);
      this.text_UR[index] = child5.GetChild(index).GetChild(1).GetComponent<UIText>();
      this.text_UR[index].font = this.TTFont;
      this.text_UR[index].text = this.DM.mStringTable.GetStringByID((uint) (ushort) (7036 + index));
    }
    Transform child6 = child1.GetChild(3);
    this.btn_AutoTranslate = child6.GetChild(0).GetComponent<UIButton>();
    this.btn_AutoTranslate.m_Handler = (IUIButtonClickHandler) this;
    this.btn_AutoTranslate.m_BtnID1 = 7;
    this.Img_AutoTranslate = child6.GetChild(0).GetChild(0).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.Img_AutoTranslate).transform.localScale = new Vector3(-1f, ((Component) this.Img_AutoTranslate).transform.localScale.y, ((Component) this.Img_AutoTranslate).transform.localScale.z);
    this.text_tmpStr[4] = child6.GetChild(1).GetComponent<UIText>();
    this.text_tmpStr[4].font = this.TTFont;
    this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(9062U);
    this.text_tmpStr[5] = child6.GetChild(2).GetComponent<UIText>();
    this.text_tmpStr[5].font = this.TTFont;
    this.text_tmpStr[5].text = this.DM.mStringTable.GetStringByID(9078U);
    this.text_tmpStr[3] = child1.GetChild(2).GetChild(4).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[3].font = this.TTFont;
    this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(7035U);
    this.m_Mat = this.door.LoadMaterial();
    this.tmpImg = this.GameT.GetChild(2).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.tmpImg).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(2).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.m_Mat;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.CheckSet();
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public void CheckSet()
  {
    ((Component) this.Img_Music).gameObject.SetActive(this.DM.MySysSetting.bMusic);
    ((Component) this.Img_Sound).gameObject.SetActive(this.DM.MySysSetting.bSound);
    ((Component) this.Img_AutoTranslate).gameObject.SetActive(this.DM.MySysSetting.bAutoTranslate);
    ((Component) this.Img_UR[(int) this.DM.MySysSetting.mUpDateRate]).gameObject.SetActive(true);
    if (this.DM.MySysSetting.mMusicSelect == (byte) 0)
    {
      ((Component) this.Img_Music_Old).gameObject.SetActive(true);
      ((Component) this.Img_Music_New).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.Img_Music_Old).gameObject.SetActive(false);
      ((Component) this.Img_Music_New).gameObject.SetActive(true);
    }
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
        this.DM.MySysSetting.bMusic = !this.DM.MySysSetting.bMusic;
        ((Component) this.Img_Music).gameObject.SetActive(this.DM.MySysSetting.bMusic);
        AudioManager.Instance.SwitchMusic(this.DM.MySysSetting.bMusic);
        break;
      case 2:
        this.DM.MySysSetting.bSound = !this.DM.MySysSetting.bSound;
        ((Component) this.Img_Sound).gameObject.SetActive(this.DM.MySysSetting.bSound);
        AudioManager.Instance.MuteSFXVol = !this.DM.MySysSetting.bSound;
        break;
      case 3:
      case 4:
      case 5:
        byte num1 = (byte) (sender.m_BtnID1 - 3);
        ((Component) this.Img_UR[(int) this.DM.MySysSetting.mUpDateRate]).gameObject.SetActive(false);
        switch (num1)
        {
          case 0:
            Application.targetFrameRate = 15;
            break;
          case 1:
            Application.targetFrameRate = 30;
            break;
          case 2:
            Application.targetFrameRate = -1;
            break;
        }
        this.DM.MySysSetting.mUpDateRate = num1;
        ((Component) this.Img_UR[(int) this.DM.MySysSetting.mUpDateRate]).gameObject.SetActive(true);
        break;
      case 7:
        this.DM.MySysSetting.bAutoTranslate = !this.DM.MySysSetting.bAutoTranslate;
        ((Component) this.Img_AutoTranslate).gameObject.SetActive(this.DM.MySysSetting.bAutoTranslate);
        this.DM.ClearAllHeight();
        break;
      case 8:
      case 9:
        byte num2 = (byte) (sender.m_BtnID1 - 8);
        if (num2 == (byte) 0)
        {
          ((Component) this.Img_Music_Old).gameObject.SetActive(true);
          ((Component) this.Img_Music_New).gameObject.SetActive(false);
        }
        else
        {
          ((Component) this.Img_Music_Old).gameObject.SetActive(false);
          ((Component) this.Img_Music_New).gameObject.SetActive(true);
        }
        this.DM.MySysSetting.mMusicSelect = num2;
        if (this.door.m_eMapMode != EUIOriginMapMode.KingdomMap && this.door.m_eMapMode != EUIOriginMapMode.WorldMap)
          break;
        AudioManager.Instance.LoadAndPlayBGM(BGMType.Legion, (byte) 1);
        break;
    }
  }

  public override void OnClose() => this.DM.SetSysSettingSave();

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
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.text_UR[index] != (Object) null && ((Behaviour) this.text_UR[index]).enabled)
      {
        ((Behaviour) this.text_UR[index]).enabled = false;
        ((Behaviour) this.text_UR[index]).enabled = true;
      }
      if ((Object) this.text_MusicSelect[index] != (Object) null && ((Behaviour) this.text_MusicSelect[index]).enabled)
      {
        ((Behaviour) this.text_MusicSelect[index]).enabled = false;
        ((Behaviour) this.text_MusicSelect[index]).enabled = true;
      }
    }
    for (int index = 0; index < 6; ++index)
    {
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 == 1)
      ;
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
