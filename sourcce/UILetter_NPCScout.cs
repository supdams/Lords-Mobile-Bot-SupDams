// Decompiled with JetBrains decompiler
// Type: UILetter_NPCScout
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UILetter_NPCScout : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private Font TTFont;
  private Door door;
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform Tmp2;
  private Transform PreviousT;
  private Transform NextT;
  private Transform Img_T;
  private Transform[] BG_T = new Transform[3];
  private Transform[] StatusT = new Transform[4];
  private Transform CustomPanelT;
  private RectTransform tmpRCT;
  private UIButton btn_EXIT;
  private UIButton btn_Previous;
  private UIButton btn_Next;
  private UIButton btn_Title;
  private UIButton btn_Delete;
  private UIButton btn_Collect;
  private UIButton btn_Coordinate;
  private UIButton btn_ReconCoordinate;
  private UIButton btn_Hero;
  private Image tmpImg;
  private Image ImgFrame;
  private Image ImgRecon;
  private Image ImgMainHero;
  private Image ImgMainHeroHead;
  private Image ImgMainHeroFrame;
  private Image ImgMainHeroHome;
  private Image[] ImgMainHeroshow = new Image[2];
  private Image ImgNpcItem;
  private UIText text_Coordinate;
  private UIText[] text_tmpStr = new UIText[2];
  private UIText[] text_Watch = new UIText[2];
  private UIText[] text_Time = new UIText[2];
  private UIText text_Title;
  private UIText text_Page;
  private UIText text_Top;
  private UIText text_Country;
  private UIText text_Name;
  private UIText text_H_Coordinate;
  private UIText text_LV;
  private UIText[] text_Status = new UIText[9];
  private CString Cstr_Coordinate;
  private CString[] Cstr_Watch = new CString[2];
  private CString[] Cstr_Time = new CString[2];
  private CString Cstr_Title;
  private CString Cstr_Page;
  private CString Cstr_Country;
  private CString Cstr_Name;
  private CString Cstr_H_Coordinate;
  private CString[] Cstr_Status = new CString[4];
  private Material mMaT;
  private Material FrameMaterial;
  private List<int> _DataIdx = new List<int>();
  private CustomPanel tmpPanel;
  private int mWatchLv;
  private bool bOpen = true;
  private bool bFirst = true;
  private int mStatus;
  private bool bCity = true;
  private int MaxLetterNum;
  private float tempL;
  private float MoveTime1;
  private float MoveTime2;
  private float TmpTime;
  private float ShowMainHeroTime1;
  private Vector3 Vec3Instance;
  private Vector2 tmpV;
  private MyFavorite Favor = new MyFavorite(Id: 0U);
  private CombatReport Report;
  private UISpritesArray SArray;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.mMaT = this.door.LoadMaterial();
    this.FrameMaterial = this.GUIM.GetFrameMaterial();
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    CString SpriteName = StringManager.Instance.StaticString1024();
    this.Cstr_Coordinate = StringManager.Instance.SpawnString();
    this.Cstr_Title = StringManager.Instance.SpawnString();
    this.Cstr_Page = StringManager.Instance.SpawnString();
    this.Cstr_Country = StringManager.Instance.SpawnString();
    this.Cstr_Name = StringManager.Instance.SpawnString();
    this.Cstr_H_Coordinate = StringManager.Instance.SpawnString();
    for (int index = 0; index < 2; ++index)
    {
      this.Cstr_Watch[index] = StringManager.Instance.SpawnString();
      this.Cstr_Time[index] = StringManager.Instance.SpawnString();
    }
    for (int index = 0; index < 4; ++index)
      this.Cstr_Status[index] = StringManager.Instance.SpawnString();
    this.BG_T[0] = this.GameT.GetChild(0);
    this.Tmp1 = this.BG_T[0].GetChild(2);
    this.text_Title = this.Tmp1.GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.Tmp1 = this.BG_T[0].GetChild(3);
    this.text_Page = this.Tmp1.GetComponent<UIText>();
    this.text_Page.font = this.TTFont;
    this.BG_T[1] = this.GameT.GetChild(1);
    this.Tmp1 = this.BG_T[1].GetChild(1);
    this.btn_Title = this.Tmp1.GetComponent<UIButton>();
    this.btn_Title.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Title.m_BtnID1 = 3;
    this.text_Coordinate = this.Tmp1.GetChild(1).GetComponent<UIText>();
    this.text_Coordinate.font = this.TTFont;
    this.text_Watch[0] = this.Tmp1.GetChild(2).GetComponent<UIText>();
    this.text_Watch[0].font = this.TTFont;
    this.Cstr_Watch[0].ClearString();
    this.text_Watch[1] = this.BG_T[1].GetChild(2).GetComponent<UIText>();
    this.text_Watch[1].font = this.TTFont;
    this.text_Watch[1].text = this.DM.mStringTable.GetStringByID(5350U);
    this.text_Time[0] = this.BG_T[1].GetChild(3).GetComponent<UIText>();
    this.text_Time[0].font = this.TTFont;
    this.Cstr_Time[0].ClearString();
    this.text_Time[0].text = this.Cstr_Time[0].ToString();
    this.text_Time[1] = this.BG_T[1].GetChild(4).GetComponent<UIText>();
    this.text_Time[1].font = this.TTFont;
    this.Cstr_Time[1].ClearString();
    this.text_Time[1].text = this.Cstr_Time[1].ToString();
    this.BG_T[2] = this.GameT.GetChild(2);
    this.ImgFrame = this.BG_T[2].GetChild(0).GetComponent<Image>();
    this.ImgRecon = this.BG_T[2].GetChild(1).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      this.BG_T[2].GetChild(0).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
    this.text_tmpStr[0] = this.BG_T[2].GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[0].font = this.TTFont;
    this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(6015U);
    this.ImgMainHero = this.BG_T[2].GetChild(2).GetComponent<Image>();
    this.ImgMainHero.sprite = this.GUIM.LoadFrameSprite("hf000");
    ((MaskableGraphic) this.ImgMainHero).material = this.FrameMaterial;
    this.ImgMainHeroHead = this.BG_T[2].GetChild(2).GetChild(0).GetComponent<Image>();
    ((MaskableGraphic) this.ImgMainHeroHead).material = this.GUIM.m_WonderMaterial;
    IgnoreRaycast component = ((Component) this.ImgMainHero).GetComponent<IgnoreRaycast>();
    if ((Object) component != (Object) null)
      Object.DestroyImmediate((Object) component);
    this.btn_Hero = ((Component) this.ImgMainHero).gameObject.AddComponent<UIButton>();
    this.tmpRCT = ((Component) this.ImgMainHeroHead).GetComponent<RectTransform>();
    this.tmpRCT.anchorMin = new Vector2(9f / 128f, 9f / 128f);
    this.tmpRCT.anchorMax = new Vector2(119f / 128f, 119f / 128f);
    this.tmpRCT.offsetMin = Vector2.zero;
    this.tmpRCT.offsetMax = Vector2.zero;
    this.tmpRCT.pivot = new Vector2(0.5f, 0.5f);
    this.ImgMainHeroFrame = this.BG_T[2].GetChild(2).GetChild(1).GetComponent<Image>();
    ((MaskableGraphic) this.ImgMainHeroFrame).material = this.FrameMaterial;
    this.tmpRCT = ((Component) this.ImgMainHeroFrame).GetComponent<RectTransform>();
    this.tmpRCT.anchorMin = Vector2.zero;
    this.tmpRCT.anchorMax = new Vector2(1f, 1f);
    this.tmpRCT.offsetMin = Vector2.zero;
    this.tmpRCT.offsetMax = Vector2.zero;
    this.ImgMainHeroshow[0] = this.BG_T[2].GetChild(2).GetChild(2).GetComponent<Image>();
    this.ImgMainHeroshow[1] = this.BG_T[2].GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>();
    this.ImgMainHeroHome = this.BG_T[2].GetChild(2).GetChild(3).GetComponent<Image>();
    ((Component) this.ImgMainHeroHome).gameObject.AddComponent<ArabicItemTextureRot>();
    this.Tmp1 = this.BG_T[2].GetChild(3);
    this.btn_Coordinate = this.Tmp1.GetComponent<UIButton>();
    this.btn_Coordinate.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Coordinate.m_BtnID1 = 6;
    this.Tmp2 = this.Tmp1.GetChild(1);
    this.text_H_Coordinate = this.Tmp2.GetComponent<UIText>();
    this.text_H_Coordinate.font = this.TTFont;
    this.Tmp1 = this.BG_T[2].GetChild(4);
    this.text_Top = this.Tmp1.GetComponent<UIText>();
    this.text_Top.font = this.TTFont;
    this.Tmp1 = this.BG_T[2].GetChild(5);
    this.text_Country = this.Tmp1.GetComponent<UIText>();
    this.text_Country.font = this.TTFont;
    this.Cstr_Country.ClearString();
    this.text_Country.text = this.Cstr_Country.ToString();
    this.Tmp1 = this.BG_T[2].GetChild(6);
    this.text_Name = this.Tmp1.GetComponent<UIText>();
    this.text_Name.font = this.TTFont;
    this.Cstr_Name.ClearString();
    this.text_Name.text = this.Cstr_Name.ToString();
    this.Img_T = this.GameT.GetChild(3);
    this.Tmp1 = this.Img_T.GetChild(4);
    this.text_LV = this.Tmp1.GetComponent<UIText>();
    this.text_LV.font = this.TTFont;
    this.text_LV.text = this.DM.mStringTable.GetStringByID(5354U);
    this.StatusT[0] = this.Img_T.GetChild(0);
    this.text_Status[0] = this.StatusT[0].GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_Status[0].font = this.TTFont;
    this.text_Status[0].text = this.DM.mStringTable.GetStringByID(5387U);
    this.text_Status[1] = this.StatusT[0].GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_Status[1].font = this.TTFont;
    this.StatusT[1] = this.Img_T.GetChild(1);
    this.text_Status[2] = this.StatusT[1].GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_Status[2].font = this.TTFont;
    this.StatusT[2] = this.Img_T.GetChild(2);
    this.text_Status[3] = this.StatusT[2].GetChild(2).GetComponent<UIText>();
    this.text_Status[3].font = this.TTFont;
    this.btn_ReconCoordinate = this.StatusT[2].GetChild(1).GetComponent<UIButton>();
    this.btn_ReconCoordinate.m_Handler = (IUIButtonClickHandler) this;
    this.btn_ReconCoordinate.m_BtnID1 = 7;
    this.text_Status[4] = this.StatusT[2].GetChild(1).GetChild(1).GetComponent<UIText>();
    this.text_Status[4].font = this.TTFont;
    this.text_tmpStr[1] = this.StatusT[2].GetChild(1).GetChild(2).GetComponent<UIText>();
    this.text_tmpStr[1].font = this.TTFont;
    this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(6004U);
    this.StatusT[3] = this.Img_T.GetChild(3);
    this.ImgNpcItem = this.StatusT[3].GetChild(0).GetChild(1).GetComponent<Image>();
    this.text_Status[5] = this.StatusT[3].GetChild(0).GetChild(2).GetComponent<UIText>();
    this.text_Status[5].font = this.TTFont;
    this.text_Status[5].text = this.DM.mStringTable.GetStringByID(9595U);
    this.text_Status[6] = this.StatusT[3].GetChild(0).GetChild(3).GetComponent<UIText>();
    this.text_Status[6].font = this.TTFont;
    this.text_Status[6].text = "2";
    this.text_Status[7] = this.StatusT[3].GetChild(1).GetChild(1).GetComponent<UIText>();
    this.text_Status[7].font = this.TTFont;
    this.text_Status[8] = this.StatusT[3].GetChild(1).GetChild(2).GetComponent<UIText>();
    this.text_Status[8].font = this.TTFont;
    this.CustomPanelT = this.GameT.GetChild(4);
    this.Tmp1 = this.GameT.GetChild(5);
    this.btn_Delete = this.Tmp1.GetComponent<UIButton>();
    this.btn_Delete.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Delete.m_BtnID1 = 4;
    this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
    this.btn_Delete.transition = (Selectable.Transition) 0;
    this.Tmp1 = this.GameT.GetChild(6);
    this.btn_Collect = this.Tmp1.GetComponent<UIButton>();
    this.btn_Collect.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Collect.m_BtnID1 = 5;
    this.btn_Collect.m_EffectType = e_EffectType.e_Scale;
    this.btn_Collect.transition = (Selectable.Transition) 0;
    float x = ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x;
    this.tempL = (float) (((double) ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x - 853.0) / 2.0);
    this.PreviousT = this.GameT.GetChild(7);
    this.btn_Previous = this.PreviousT.GetComponent<UIButton>();
    this.btn_Previous.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Previous.m_BtnID1 = 1;
    this.btn_Previous.m_EffectType = e_EffectType.e_Scale;
    this.btn_Previous.transition = (Selectable.Transition) 0;
    this.NextT = this.GameT.GetChild(8);
    this.btn_Next = this.NextT.GetComponent<UIButton>();
    this.btn_Next.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Next.m_BtnID1 = 2;
    this.btn_Next.m_EffectType = e_EffectType.e_Scale;
    this.btn_Next.transition = (Selectable.Transition) 0;
    if ((double) this.tempL > 0.0 && (double) this.NextT.localPosition.x + (double) this.tempL > (double) x / 2.0)
      this.tempL = x / 2f - this.NextT.localPosition.x;
    this.MoveTime1 = this.NextT.localPosition.x + this.tempL;
    this.MoveTime2 = this.PreviousT.localPosition.x - this.tempL;
    if (this.GUIM.bOpenOnIPhoneX)
    {
      this.MoveTime1 -= this.GUIM.IPhoneX_DeltaX;
      this.MoveTime2 += this.GUIM.IPhoneX_DeltaX;
    }
    this.Vec3Instance.Set(this.MoveTime1, this.NextT.localPosition.y, this.NextT.localPosition.z);
    this.NextT.localPosition = this.Vec3Instance;
    this.Vec3Instance.Set(this.MoveTime2, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
    this.PreviousT.localPosition = this.Vec3Instance;
    ((Component) this.btn_Previous).gameObject.SetActive(true);
    ((Component) this.btn_Next).gameObject.SetActive(true);
    this.Tmp = this.GameT.GetChild(9);
    this.tmpImg = this.Tmp.GetComponent<Image>();
    SpriteName.ClearString();
    SpriteName.AppendFormat("UI_main_close_base");
    this.tmpImg.sprite = this.door.LoadSprite(SpriteName);
    ((MaskableGraphic) this.tmpImg).material = this.mMaT;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.tmpImg).enabled = false;
    this.Tmp = this.GameT.GetChild(9).GetChild(0);
    this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
    SpriteName.ClearString();
    SpriteName.AppendFormat("UI_main_close");
    this.btn_EXIT.image.sprite = this.door.LoadSprite(SpriteName);
    ((MaskableGraphic) this.btn_EXIT.image).material = this.mMaT;
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.SetDataInfo();
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public void SetDataInfo()
  {
    this.Favor.Serial = this.DM.OpenMail.Serial;
    this.Favor.Type = this.DM.OpenMail.Type;
    this.Favor.Kind = this.DM.OpenMail.Kind;
    if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
    {
      this.Report = this.Favor.Combat;
      if (!this.Report.BeRead)
      {
        if (this.Favor.Kind == MailType.EMAIL_BATTLE)
          this.DM.BattleReportRead(this.Report.SerialID, false);
        else
          this.DM.FavorReportRead(this.Report.SerialID, false);
      }
      this.Cstr_Page.ClearString();
      this.MaxLetterNum = (int) this.DM.GetMailboxSize();
      switch (this.DM.OpenMail.Kind)
      {
        case MailType.EMAIL_BATTLE:
          this.Cstr_Page.IntToFormat((long) ((int) this.Report.Index + 1));
          this.Cstr_Page.IntToFormat((long) this.MaxLetterNum);
          break;
        case MailType.EMAIL_FAVORY:
          this.Cstr_Page.IntToFormat((long) ((int) this.Report.Index + 1));
          this.Cstr_Page.IntToFormat((long) this.MaxLetterNum);
          break;
      }
      if (this.GUIM.IsArabic)
        this.Cstr_Page.AppendFormat("{1}/{0}");
      else
        this.Cstr_Page.AppendFormat("{0}/{1}");
      this.text_Page.text = this.Cstr_Page.ToString();
      this.text_Page.SetAllDirty();
      this.text_Page.cachedTextGenerator.Invalidate();
      this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Times).ToString("MM/dd/yy");
      this.text_Time[0].SetAllDirty();
      this.text_Time[0].cachedTextGenerator.Invalidate();
      this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Times).ToString("HH:mm:ss");
      this.text_Time[1].SetAllDirty();
      this.text_Time[1].cachedTextGenerator.Invalidate();
      ((Component) this.btn_Previous).gameObject.SetActive(true);
      ((Component) this.btn_Next).gameObject.SetActive(true);
      if (this.MaxLetterNum > 1)
      {
        if ((int) this.Report.Index + 1 == 1)
        {
          ((Component) this.btn_Previous).gameObject.SetActive(false);
          if (!((UIBehaviour) this.btn_Next).IsActive())
            ((Component) this.btn_Next).gameObject.SetActive(true);
        }
        if ((int) this.Report.Index + 1 == this.MaxLetterNum)
        {
          ((Component) this.btn_Next).gameObject.SetActive(false);
          if (!((UIBehaviour) this.btn_Previous).IsActive())
            ((Component) this.btn_Previous).gameObject.SetActive(true);
        }
      }
      else
      {
        ((Component) this.btn_Previous).gameObject.SetActive(false);
        ((Component) this.btn_Next).gameObject.SetActive(false);
      }
      CString SpriteName = StringManager.Instance.StaticString1024();
      this.bOpen = true;
      if (this.Report.NPCScout.ScoutResult == (byte) 1)
        this.mStatus = 1;
      this.bCity = false;
      if (this.mStatus == 0 && this.Report.NPCScout.CombatPointKind == POINT_KIND.PK_CITY)
      {
        this.DM.SetScoutData(this.Report.NPCScout.ScoutLevel, this.Report.NPCScout.ScoutContent, this.Report.NPCScout.ScoutContentLen, (byte) 3);
        this.bCity = true;
      }
      this.Cstr_Title.ClearString();
      this.Cstr_Name.ClearString();
      this.Cstr_Country.ClearString();
      ((Component) this.ImgMainHeroshow[0]).gameObject.SetActive(false);
      this.mWatchLv = (int) this.Report.NPCScout.ScoutLevel;
      ((Component) this.btn_Title).gameObject.SetActive(true);
      this.Cstr_Watch[0].ClearString();
      this.Cstr_Watch[0].StringToFormat(this.GUIM.GetPointName_Letter(this.Report.NPCScout.CombatPointKind));
      this.Cstr_Watch[0].StringToFormat(this.DM.mStringTable.GetStringByID(5347U));
      this.Cstr_Watch[0].AppendFormat("{0} {1}");
      this.text_Watch[0].text = this.Cstr_Watch[0].ToString();
      this.text_Watch[0].SetAllDirty();
      this.text_Watch[0].cachedTextGenerator.Invalidate();
      ((Component) this.text_Watch[1]).gameObject.SetActive(false);
      ((Component) this.ImgRecon).gameObject.SetActive(false);
      if (this.mStatus == 0 || this.mWatchLv >= 4 && this.mStatus == 1)
      {
        ((Component) this.text_Name).gameObject.SetActive(true);
        this.Cstr_Name.ClearString();
        this.Cstr_Name.IntToFormat((long) this.Report.NPCScout.NPCLevel);
        this.Cstr_Name.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021U));
      }
      else
        ((Component) this.text_Name).gameObject.SetActive(false);
      if (this.mWatchLv >= 5)
      {
        ((Component) this.text_Top).gameObject.SetActive(false);
        ((Component) this.btn_Coordinate).gameObject.SetActive(true);
        ((Component) this.ImgMainHeroHome).gameObject.SetActive(false);
        ((Component) this.ImgMainHero).gameObject.SetActive(true);
        this.ImgMainHeroHead.sprite = this.GUIM.NpcHead;
        ((MaskableGraphic) this.ImgMainHeroHead).material = this.GUIM.m_WonderMaterial;
        SpriteName.ClearString();
        SpriteName.Append("hf011");
        this.ImgMainHeroFrame.sprite = this.GUIM.LoadFrameSprite(SpriteName);
      }
      else
      {
        ((Component) this.ImgFrame).gameObject.SetActive(true);
        ((Component) this.ImgMainHero).gameObject.SetActive(false);
        ((Component) this.btn_Coordinate).gameObject.SetActive(false);
        ((Component) this.text_Top).gameObject.SetActive(false);
        ((Component) this.ImgMainHeroHome).gameObject.SetActive(false);
      }
      if (this.Report.NPCScout.CombatPointKind != POINT_KIND.PK_YOLK)
      {
        this.Cstr_Title.Append(this.DM.mStringTable.GetStringByID(6027U));
        if (this.Report.NPCScout.ScoutResult == (byte) 0)
        {
          this.Cstr_Name.ClearString();
          this.Cstr_Name.IntToFormat((long) this.Report.NPCScout.NPCLevel);
          this.Cstr_Name.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021U));
          this.Cstr_Title.Append(this.Cstr_Name);
        }
      }
      else if (this.mStatus == 0)
        this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(7259U));
      this.text_Title.text = this.Cstr_Title.ToString();
      this.tmpRCT = this.BG_T[1].GetChild(1).GetComponent<RectTransform>();
      this.Cstr_Coordinate.ClearString();
      this.tmpV = this.Report.NPCScout.CombatPointKind != POINT_KIND.PK_CITY ? Vector2.zero : GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.NPCScout.CombatlZone, this.Report.NPCScout.CombatPoint));
      this.Cstr_Coordinate.IntToFormat((long) this.Report.NPCScout.KingdomID);
      this.Cstr_Coordinate.IntToFormat((long) (int) this.tmpV.x);
      this.Cstr_Coordinate.IntToFormat((long) (int) this.tmpV.y);
      if (this.GUIM.IsArabic)
        this.Cstr_Coordinate.AppendFormat("{2}:Y {1}:X {0}:K");
      else
        this.Cstr_Coordinate.AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
      this.text_Coordinate.text = this.Cstr_Coordinate.ToString();
      this.text_Coordinate.SetAllDirty();
      this.text_Coordinate.cachedTextGenerator.Invalidate();
      this.text_Coordinate.cachedTextGeneratorForLayout.Invalidate();
      this.tmpRCT.sizeDelta = new Vector2(this.text_Coordinate.preferredWidth, this.tmpRCT.sizeDelta.y);
      this.tmpRCT = this.BG_T[1].GetChild(1).GetChild(0).GetComponent<RectTransform>();
      this.tmpRCT.sizeDelta = new Vector2(this.text_Coordinate.preferredWidth, this.tmpRCT.sizeDelta.y);
      this.tmpRCT = this.BG_T[1].GetChild(1).GetChild(1).GetComponent<RectTransform>();
      this.tmpRCT.sizeDelta = new Vector2(this.text_Coordinate.preferredWidth, this.tmpRCT.sizeDelta.y);
      this.tmpRCT = this.BG_T[1].GetChild(1).GetChild(2).GetComponent<RectTransform>();
      this.tmpRCT.anchoredPosition = !this.GUIM.IsArabic ? new Vector2(this.text_Coordinate.preferredWidth + 10f, this.tmpRCT.anchoredPosition.y) : this.text_Watch[0].ArabicFixPos(new Vector2(this.text_Coordinate.preferredWidth + 10f, this.tmpRCT.anchoredPosition.y));
      this.tmpRCT = this.BG_T[2].GetChild(3).GetComponent<RectTransform>();
      this.Cstr_H_Coordinate.ClearString();
      this.Cstr_Coordinate.IntToFormat((long) this.Report.NPCScout.KingdomID);
      this.Cstr_Coordinate.IntToFormat((long) (int) this.tmpV.x);
      this.Cstr_Coordinate.IntToFormat((long) (int) this.tmpV.y);
      if (this.GUIM.IsArabic)
        this.Cstr_H_Coordinate.AppendFormat("{2}:Y {1}:X {0}:K");
      else
        this.Cstr_H_Coordinate.AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
      this.text_H_Coordinate.text = this.Cstr_H_Coordinate.ToString();
      ((Component) this.text_H_Coordinate).gameObject.SetActive(true);
      this.text_H_Coordinate.SetAllDirty();
      this.text_H_Coordinate.cachedTextGenerator.Invalidate();
      this.text_H_Coordinate.cachedTextGeneratorForLayout.Invalidate();
      this.tmpRCT.sizeDelta = new Vector2(this.text_H_Coordinate.preferredWidth, this.tmpRCT.sizeDelta.y);
      this.tmpRCT = this.BG_T[2].GetChild(3).GetChild(0).GetComponent<RectTransform>();
      this.tmpRCT.sizeDelta = new Vector2(this.text_H_Coordinate.preferredWidth, this.tmpRCT.sizeDelta.y);
      this.tmpRCT = this.BG_T[2].GetChild(3).GetChild(1).GetComponent<RectTransform>();
      this.tmpRCT.sizeDelta = new Vector2(this.text_H_Coordinate.preferredWidth, this.tmpRCT.sizeDelta.y);
      this.tmpRCT = this.BG_T[2].GetChild(3).GetChild(2).GetComponent<RectTransform>();
      this.tmpRCT.sizeDelta = new Vector2(this.text_H_Coordinate.preferredWidth, this.tmpRCT.sizeDelta.y);
      if ((Object) this.tmpPanel == (Object) null)
        this.tmpPanel = this.CustomPanelT.gameObject.AddComponent<CustomPanel>();
      this.CustomPanelT.gameObject.SetActive(true);
      if (this.GUIM.IsArabic)
        ((Transform) ((Graphic) this.ImgMainHeroHead).rectTransform).localScale = new Vector3(1f, 1f, 1f);
      this._DataIdx.Clear();
      if (this.mStatus == 1)
      {
        ((Component) this.text_LV).gameObject.SetActive(false);
        this.Img_T.gameObject.SetActive(true);
        this.tmpPanel.RewardID = this.Report.NPCScout.Reward;
        this.tmpPanel.UpDownHandle = (IUIButtonDownUpHandler) this;
        this._DataIdx.Add(40);
        this.text_Status[0].text = this.DM.mStringTable.GetStringByID(5387U);
        this.Cstr_Status[0].ClearString();
        switch (this.Report.NPCScout.ScoutResult)
        {
          case 1:
            this.tmpPanel.InfoID = (uint) this.Report.NPCScout.CombatPointKind;
            this._DataIdx.Add(42);
            break;
          case 2:
            this.Cstr_Status[0].Append(this.DM.mStringTable.GetStringByID(6068U));
            if (this.Report.NPCScout.CombatPointKind == POINT_KIND.PK_YOLK)
            {
              this.Cstr_Title.Append(this.DM.mStringTable.GetStringByID(6027U));
              this.text_Title.text = this.Cstr_Title.ToString();
              break;
            }
            break;
          case 3:
            this.Cstr_Status[0].Append(this.DM.mStringTable.GetStringByID(6069U));
            break;
          case 4:
            this.StatusT[0].gameObject.SetActive(false);
            this.StatusT[3].gameObject.SetActive(true);
            this.text_Status[7].text = this.DM.mStringTable.GetStringByID(5387U);
            this.Cstr_Status[0].StringToFormat(this.GUIM.GetPointName_Letter(this.Report.NPCScout.CombatPointKind));
            this.Cstr_Status[0].AppendFormat(this.DM.mStringTable.GetStringByID(5388U));
            this.text_Status[8].text = this.Cstr_Status[0].ToString();
            this.text_Status[8].SetAllDirty();
            this.text_Status[8].cachedTextGenerator.Invalidate();
            break;
        }
        this.text_Status[1].text = this.Cstr_Status[0].ToString();
        this.text_Status[1].SetAllDirty();
        this.text_Status[1].cachedTextGenerator.Invalidate();
      }
      else
      {
        this._DataIdx.Clear();
        this.Img_T.gameObject.SetActive(false);
        this.StatusT[1].gameObject.SetActive(false);
        ((Component) this.text_Name).gameObject.SetActive(true);
        this.tmpPanel.RewardID = this.Report.NPCScout.Reward;
        this.tmpPanel.UpDownHandle = (IUIButtonDownUpHandler) this;
        this._DataIdx.Add(40);
        if (this.mWatchLv >= 8)
          this._DataIdx.Add(41);
        if (this.mWatchLv >= 10 && (this.bCity || this.Report.NPCScout.CombatPointKind == POINT_KIND.PK_YOLK))
          this._DataIdx.Add(5);
        if (this.bCity || this.Report.NPCScout.CombatPointKind == POINT_KIND.PK_NPC)
        {
          if (this.mWatchLv >= 6)
            this._DataIdx.Add(6);
          if (this.mWatchLv >= 2)
            this._DataIdx.Add(7);
        }
        this._DataIdx.Add(8);
        if (this.mWatchLv < 10)
          this._DataIdx.Add(4);
      }
      this.text_Status[0].SetAllDirty();
      this.text_Status[0].cachedTextGenerator.Invalidate();
      this.text_Title.SetAllDirty();
      this.text_Title.cachedTextGenerator.Invalidate();
      this.text_Country.text = this.Cstr_Country.ToString();
      this.text_Country.SetAllDirty();
      this.text_Country.cachedTextGenerator.Invalidate();
      this.text_Name.text = this.Cstr_Name.ToString();
      this.text_Name.SetAllDirty();
      this.text_Name.cachedTextGenerator.Invalidate();
    }
    else
    {
      this.Report = (CombatReport) null;
      this.door.CloseMenu();
    }
  }

  public override void OnClose()
  {
    if (this.Cstr_Coordinate != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Coordinate);
    if (this.Cstr_Title != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Title);
    if (this.Cstr_Page != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Page);
    if (this.Cstr_Country != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Country);
    if (this.Cstr_Name != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Name);
    if (this.Cstr_H_Coordinate != null)
      StringManager.Instance.DeSpawnString(this.Cstr_H_Coordinate);
    for (int index = 0; index < 2; ++index)
    {
      if (this.Cstr_Time[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Time[index]);
      if (this.Cstr_Watch[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Watch[index]);
    }
    for (int index = 0; index < 4; ++index)
    {
      if (this.Cstr_Status[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Status[index]);
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
        this.Open_NP_Mail(false);
        break;
      case 2:
        this.Open_NP_Mail(true);
        break;
      case 3:
        this.door.GoToPointCode(this.Report.NPCScout.KingdomID, this.Report.NPCScout.CombatlZone, this.Report.NPCScout.CombatPoint, (byte) 0);
        break;
      case 4:
        if (!this.DM.BattleReportDelete(this.Report.SerialID))
          break;
        this.door.CloseMenu();
        break;
      case 5:
        if (this.Favor.Kind == MailType.EMAIL_FAVORY)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(6100U), (ushort) byte.MaxValue);
          break;
        }
        this.DM.BattleReportSave(this.Report.SerialID);
        break;
      case 6:
        if (this.mStatus < 2)
        {
          if (this.Report.NPCScout.CombatPointKind != POINT_KIND.PK_YOLK)
          {
            this.door.GoToPointCode(this.Report.NPCScout.KingdomID, this.Report.NPCScout.CombatlZone, this.Report.NPCScout.CombatPoint, (byte) 0);
            break;
          }
          this.door.GoToWonder(this.Report.NPCScout.KingdomID, this.Report.NPCScout.CombatPoint);
          break;
        }
        this.door.GoToPointCode(this.Report.NPCScout.KingdomID, this.Report.NPCScout.CombatlZone, this.Report.NPCScout.CombatPoint, (byte) 0);
        break;
      case 7:
        if (this.Report.Recon.CombatPointKind != POINT_KIND.PK_YOLK)
        {
          this.door.GoToPointCode(this.Report.Recon.KingdomID, this.Report.Recon.CombatlZone, this.Report.Recon.CombatPoint, (byte) 0);
          break;
        }
        this.door.GoToWonder(this.Report.Recon.KingdomID, this.Report.Recon.CombatPoint);
        break;
    }
  }

  public void Open_NP_Mail(bool bNext)
  {
    if (!this.DM.MailReportGet(ref this.Favor, bNext))
      return;
    switch (this.Favor.Type)
    {
      case MailType.EMAIL_SYSTEM:
        this.DM.OpenMail.Serial = this.Favor.Serial;
        this.DM.OpenMail.Type = this.Favor.Type;
        this.DM.OpenMail.Kind = this.Favor.Kind;
        this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_NPCScout);
        break;
      case MailType.EMAIL_BATTLE:
        this.DM.OpenMail.Serial = this.Favor.Serial;
        this.DM.OpenMail.Type = this.Favor.Type;
        this.DM.OpenMail.Kind = this.Favor.Kind;
        switch (this.Favor.Combat.Type)
        {
          case CombatCollectReport.CCR_BATTLE:
          case CombatCollectReport.CCR_NPCCOMBAT:
            this.door.OpenMenu(EGUIWindow.UI_FightingSummary);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_NPCScout);
            return;
          case CombatCollectReport.CCR_RESOURCE:
            this.door.OpenMenu(EGUIWindow.UI_Letter_Resources);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_NPCScout);
            return;
          case CombatCollectReport.CCR_COLLECT:
            this.door.OpenMenu(EGUIWindow.UI_Letter_Collection);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_NPCScout);
            return;
          case CombatCollectReport.CCR_SCOUT:
            this.door.CloseMenu();
            this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower);
            return;
          case CombatCollectReport.CCR_RECON:
            this.door.CloseMenu();
            this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon);
            return;
          case CombatCollectReport.CCR_MONSTER:
            if (this.Favor.Combat.Monster.Result < (byte) 2 || this.Favor.Combat.Monster.Result > (byte) 3)
              this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 1);
            else
              this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_NPCScout);
            return;
          case CombatCollectReport.CCR_NPCSCOUT:
            this.CustomPanelT.gameObject.SetActive(false);
            this.Img_T.gameObject.SetActive(false);
            if (this.mStatus >= 1)
            {
              int num = this.mStatus;
              if (this.mStatus == 4)
                num = 1;
              else if (this.mStatus == 5)
                num = 4;
              this.StatusT[num - 1].gameObject.SetActive(false);
            }
            this.mStatus = this.Favor.Combat.NPCScout.ScoutLevel == (byte) 0 ? 1 : 0;
            this.SetDataInfo();
            return;
          case CombatCollectReport.CCR_PETREPORT:
            this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_NPCScout);
            return;
          default:
            return;
        }
      case MailType.EMAIL_LETTER:
        this.DM.OpenMail.Serial = this.Favor.Serial;
        this.DM.OpenMail.Type = this.Favor.Type;
        this.DM.OpenMail.Kind = this.Favor.Kind;
        this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_NPCScout);
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 277f, 20, (int) sender.Parm1, 0, Vector2.zero);
  }

  public void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide();

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != 2 || this.DM.MailReportGet(ref this.Favor))
      return;
    this.door.CloseMenu();
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
        if (this.mStatus != 0 || !((Object) this.tmpPanel != (Object) null) || meg[1] != (byte) 0 || meg[2] != (byte) 1)
          break;
        this.tmpPanel.SetNpcImg();
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Mailing)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          if ((Object) this.tmpPanel != (Object) null)
            this.tmpPanel.Refresh_FontTexture();
          this.Refresh_FontTexture();
          break;
        }
        if (!this.DM.MailReportGet(ref this.Favor))
          this.door.CloseMenu();
        this.MaxLetterNum = (int) this.DM.GetMailboxSize();
        this.Cstr_Page.ClearString();
        switch (this.DM.OpenMail.Kind)
        {
          case MailType.EMAIL_BATTLE:
            this.Cstr_Page.IntToFormat((long) ((int) this.Report.Index + 1));
            this.Cstr_Page.IntToFormat((long) this.MaxLetterNum);
            break;
          case MailType.EMAIL_FAVORY:
            this.Cstr_Page.IntToFormat((long) ((int) this.Report.Index + 1));
            this.Cstr_Page.IntToFormat((long) this.MaxLetterNum);
            break;
        }
        if (this.GUIM.IsArabic)
          this.Cstr_Page.AppendFormat("{1}/{0}");
        else
          this.Cstr_Page.AppendFormat("{0}/{1}");
        this.text_Page.text = this.Cstr_Page.ToString();
        this.text_Page.SetAllDirty();
        this.text_Page.cachedTextGenerator.Invalidate();
        if (this.MaxLetterNum > 1)
        {
          if ((int) this.Report.Index + 1 == 1)
            ((Component) this.btn_Previous).gameObject.SetActive(false);
          else
            ((Component) this.btn_Previous).gameObject.SetActive(true);
          if ((int) this.Report.Index + 1 == this.MaxLetterNum)
          {
            ((Component) this.btn_Next).gameObject.SetActive(false);
            break;
          }
          ((Component) this.btn_Next).gameObject.SetActive(true);
          break;
        }
        ((Component) this.btn_Previous).gameObject.SetActive(false);
        ((Component) this.btn_Next).gameObject.SetActive(false);
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Coordinate != (Object) null && ((Behaviour) this.text_Coordinate).enabled)
    {
      ((Behaviour) this.text_Coordinate).enabled = false;
      ((Behaviour) this.text_Coordinate).enabled = true;
    }
    if ((Object) this.text_Title != (Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((Object) this.text_Page != (Object) null && ((Behaviour) this.text_Page).enabled)
    {
      ((Behaviour) this.text_Page).enabled = false;
      ((Behaviour) this.text_Page).enabled = true;
    }
    if ((Object) this.text_Top != (Object) null && ((Behaviour) this.text_Top).enabled)
    {
      ((Behaviour) this.text_Top).enabled = false;
      ((Behaviour) this.text_Top).enabled = true;
    }
    if ((Object) this.text_Country != (Object) null && ((Behaviour) this.text_Country).enabled)
    {
      ((Behaviour) this.text_Country).enabled = false;
      ((Behaviour) this.text_Country).enabled = true;
    }
    if ((Object) this.text_Name != (Object) null && ((Behaviour) this.text_Name).enabled)
    {
      ((Behaviour) this.text_Name).enabled = false;
      ((Behaviour) this.text_Name).enabled = true;
    }
    if ((Object) this.text_H_Coordinate != (Object) null && ((Behaviour) this.text_H_Coordinate).enabled)
    {
      ((Behaviour) this.text_H_Coordinate).enabled = false;
      ((Behaviour) this.text_H_Coordinate).enabled = true;
    }
    if ((Object) this.text_LV != (Object) null && ((Behaviour) this.text_LV).enabled)
    {
      ((Behaviour) this.text_LV).enabled = false;
      ((Behaviour) this.text_LV).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
      if ((Object) this.text_Watch[index] != (Object) null && ((Behaviour) this.text_Watch[index]).enabled)
      {
        ((Behaviour) this.text_Watch[index]).enabled = false;
        ((Behaviour) this.text_Watch[index]).enabled = true;
      }
      if ((Object) this.text_Time[index] != (Object) null && ((Behaviour) this.text_Time[index]).enabled)
      {
        ((Behaviour) this.text_Time[index]).enabled = false;
        ((Behaviour) this.text_Time[index]).enabled = true;
      }
    }
    for (int index = 0; index < 9; ++index)
    {
      if ((Object) this.text_Status[index] != (Object) null && ((Behaviour) this.text_Status[index]).enabled)
      {
        ((Behaviour) this.text_Status[index]).enabled = false;
        ((Behaviour) this.text_Status[index]).enabled = true;
      }
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
    this.TmpTime += Time.smoothDeltaTime * 40f;
    if ((double) this.TmpTime >= 40.0)
      this.TmpTime = 0.0f;
    float num = (double) this.TmpTime <= 20.0 ? this.TmpTime : 40f - this.TmpTime;
    if ((double) num < 0.0)
      num = 0.0f;
    if ((Object) this.NextT != (Object) null)
    {
      this.Vec3Instance.Set(this.MoveTime1 - num, this.NextT.localPosition.y, this.NextT.localPosition.z);
      this.NextT.localPosition = this.Vec3Instance;
    }
    if ((Object) this.PreviousT != (Object) null)
    {
      this.Vec3Instance.Set(this.MoveTime2 + num, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
      this.PreviousT.localPosition = this.Vec3Instance;
    }
    if ((Object) this.ImgMainHeroshow[0] != (Object) null && ((UIBehaviour) this.ImgMainHeroshow[0]).IsActive())
    {
      this.ShowMainHeroTime1 += Time.smoothDeltaTime;
      if ((double) this.ShowMainHeroTime1 >= 0.0)
      {
        if ((double) this.ShowMainHeroTime1 >= 2.0)
          this.ShowMainHeroTime1 = 0.0f;
        ((Graphic) this.ImgMainHeroshow[1]).color = new Color(1f, 1f, 1f, (double) this.ShowMainHeroTime1 <= 1.0 ? this.ShowMainHeroTime1 : 2f - this.ShowMainHeroTime1);
      }
    }
    if (!this.bOpen)
      return;
    if (this.mStatus <= 1 && this.Report != null)
    {
      this.tmpPanel.Report = this.Report;
      if (this.bFirst)
      {
        this.tmpPanel.SetPanelData(this._DataIdx, bOpen: this.bFirst, mLV: this.mWatchLv, mKind: 5, mHeight: 332f);
        this.bFirst = false;
      }
      else
        this.tmpPanel.SetPanelData(this._DataIdx, bOpen: this.bFirst, mLV: this.mWatchLv, mKind: 5, mHeight: 332f);
      this.tmpPanel.InitScrollPanel();
      UIButtonHint.scrollRect = this.tmpPanel.transform.GetChild(0).GetChild(0).GetComponent<CScrollRect>();
    }
    this.bOpen = false;
  }
}
