// Decompiled with JetBrains decompiler
// Type: UIArena_Hint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIArena_Hint : IUIButtonDownUpHandler
{
  public RectTransform m_RectTransform;
  public RectTransform m_BGRectTransform;
  public RectTransform m_BGRectTransform2;
  public UIButtonHint m_ButtonHint;
  public UIHIBtn[] m_HeroBtn = new UIHIBtn[5];
  public UIHIBtn[] m_HeroBtn2 = new UIHIBtn[5];
  public Image[] m_Frame = new Image[5];
  public Image[] m_Frame2 = new Image[5];
  public Image[] m_Astrology = new Image[5];
  public Image[] m_Main = new Image[2];
  public Image[] m_data_Icon = new Image[16];
  public UIText m_TextRank;
  public UIText m_TextStrength;
  public UIText m_TextName;
  public UIText m_TextName2;
  public UIText m_Text_F;
  public UIText[] m_Text_data_Rank = new UIText[16];
  public UIText[] m_Text_data_Name = new UIText[16];
  public UIText[] m_Text_data_Num = new UIText[16];
  private CString m_StrRank;
  private CString m_StrStrength;
  private CString m_StrName;
  public CString[] m_dataNum = new CString[16];
  public Image m_Rank;
  public Image m_ST;
  public Image m_Line;
  public Image m_Line2;
  public byte Type;
  public Transform[] m_T_data = new Transform[16];
  public Sprite[] mSprite = new Sprite[4];
  public Material m_MT;

  public void Load()
  {
    GUIManager instance = GUIManager.Instance;
    Object original = instance.m_Arena_HintAssetBundle.Load(nameof (UIArena_Hint));
    if (original == (Object) null)
      return;
    this.m_StrRank = StringManager.Instance.SpawnString();
    this.m_StrStrength = StringManager.Instance.SpawnString();
    this.m_StrName = StringManager.Instance.SpawnString();
    for (int index = 0; index < 16; ++index)
      this.m_dataNum[index] = StringManager.Instance.SpawnString();
    Font ttfFont = instance.GetTTFFont();
    GameObject gameObject = (GameObject) Object.Instantiate(original);
    gameObject.transform.SetParent((Transform) instance.m_WindowTopLayer, false);
    gameObject.SetActive(false);
    this.m_RectTransform = (RectTransform) gameObject.transform;
    ((Transform) this.m_RectTransform).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    this.m_BGRectTransform = ((Transform) this.m_RectTransform).GetChild(0).GetComponent<RectTransform>();
    Transform transform1 = ((Component) this.m_BGRectTransform).transform;
    for (int index = 0; index < 5; ++index)
    {
      transform1.GetChild(index).GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
      Transform child1 = transform1.GetChild(index).GetChild(0);
      this.m_HeroBtn[index] = child1.GetComponent<UIHIBtn>();
      instance.InitianHeroItemImg(child1, eHeroOrItem.Hero, (ushort) 1, (byte) 0, (byte) 0);
      Transform child2 = transform1.GetChild(index).GetChild(1);
      this.m_Frame[index] = child2.GetComponent<Image>();
      child2.GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
      Transform child3 = transform1.GetChild(index).GetChild(2);
      this.m_Astrology[index] = child3.GetComponent<Image>();
      child3.GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    }
    Transform child4 = transform1.GetChild(5);
    this.m_Rank = child4.GetComponent<Image>();
    child4.GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    if (instance.IsArabic)
      child4.gameObject.AddComponent<ArabicItemTextureRot>();
    this.m_TextRank = transform1.GetChild(5).GetChild(0).GetComponent<UIText>();
    this.m_TextRank.font = ttfFont;
    Transform child5 = transform1.GetChild(6);
    this.m_ST = child5.GetComponent<Image>();
    child5.GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    this.m_TextStrength = transform1.GetChild(6).GetChild(0).GetComponent<UIText>();
    this.m_TextStrength.font = ttfFont;
    Transform child6 = transform1.GetChild(7);
    this.m_Line = child6.GetComponent<Image>();
    child6.GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    this.m_TextName = transform1.GetChild(8).GetComponent<UIText>();
    this.m_TextName.font = ttfFont;
    ((Transform) this.m_RectTransform).GetChild(1).GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    this.m_BGRectTransform2 = ((Transform) this.m_RectTransform).GetChild(1).GetComponent<RectTransform>();
    this.mSprite[0] = instance.LoadFrameSprite("UI_legion_icon_a");
    this.mSprite[1] = instance.LoadFrameSprite("UI_legion_icon_b");
    this.mSprite[2] = instance.LoadFrameSprite("UI_legion_icon_c");
    this.mSprite[3] = instance.LoadFrameSprite("UI_legion_icon_d");
    this.m_MT = instance.GetFrameMaterial();
    Transform transform2 = ((Component) this.m_BGRectTransform2).transform;
    for (int index = 0; index < 5; ++index)
    {
      transform2.GetChild(index).GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
      Transform child7 = transform2.GetChild(index).GetChild(0);
      this.m_HeroBtn2[index] = child7.GetComponent<UIHIBtn>();
      GUIManager.Instance.InitianHeroItemImg(child7, eHeroOrItem.Hero, (ushort) 1, (byte) 0, (byte) 0);
      Transform child8 = transform2.GetChild(index).GetChild(1);
      this.m_Frame2[index] = child8.GetComponent<Image>();
      child8.GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
      if (index == 0)
      {
        Transform child9 = transform2.GetChild(index).GetChild(2);
        this.m_Main[0] = child9.GetComponent<Image>();
        child9.GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
        Transform child10 = transform2.GetChild(index).GetChild(2).GetChild(0);
        this.m_Main[1] = child10.GetComponent<Image>();
        child10.GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
      }
    }
    Transform child11 = transform2.GetChild(5);
    this.m_Line2 = child11.GetComponent<Image>();
    child11.GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    for (int index = 0; index < 16; ++index)
    {
      this.m_T_data[index] = transform2.GetChild(5).GetChild(index);
      Transform child12 = this.m_T_data[index].GetChild(0);
      this.m_data_Icon[index] = child12.GetComponent<Image>();
      ((MaskableGraphic) this.m_data_Icon[index]).material = this.m_MT;
      Transform child13 = this.m_T_data[index].GetChild(1);
      this.m_Text_data_Rank[index] = child13.GetComponent<UIText>();
      this.m_Text_data_Rank[index].font = ttfFont;
      Transform child14 = this.m_T_data[index].GetChild(2);
      this.m_Text_data_Name[index] = child14.GetComponent<UIText>();
      this.m_Text_data_Name[index].font = ttfFont;
      Transform child15 = this.m_T_data[index].GetChild(3);
      this.m_Text_data_Num[index] = child15.GetComponent<UIText>();
      this.m_Text_data_Num[index].font = ttfFont;
    }
    this.m_TextName2 = transform2.GetChild(6).GetComponent<UIText>();
    this.m_TextName2.font = ttfFont;
    this.m_Text_F = transform2.GetChild(7).GetComponent<UIText>();
    this.m_Text_F.font = ttfFont;
  }

  public void UnLoad()
  {
    if (this.m_StrRank != null)
      StringManager.Instance.DeSpawnString(this.m_StrRank);
    if (this.m_StrStrength != null)
      StringManager.Instance.DeSpawnString(this.m_StrStrength);
    if (this.m_StrName != null)
      StringManager.Instance.DeSpawnString(this.m_StrName);
    for (int index = 0; index < 16; ++index)
    {
      if (this.m_dataNum[index] != null)
        StringManager.Instance.DeSpawnString(this.m_dataNum[index]);
    }
  }

  public void Show(UIButtonHint hint, float X = 0, float Y = 0, byte type = 0)
  {
    if (((Component) this.m_RectTransform).gameObject.activeSelf)
      this.Hide(this.m_ButtonHint);
    ((Component) this.m_RectTransform).gameObject.SetActive(true);
    ArenaManager instance = ArenaManager.Instance;
    this.m_StrRank.ClearString();
    this.m_StrStrength.ClearString();
    this.m_StrName.ClearString();
    this.Type = type;
    if (this.Type != (byte) 0)
      return;
    this.m_BGRectTransform.anchoredPosition = new Vector2(X, Y);
    ((Component) this.m_BGRectTransform).gameObject.SetActive(true);
    ((Component) this.m_BGRectTransform2).gameObject.SetActive(false);
    for (int index = 0; index < 5; ++index)
    {
      if (instance.m_ArenaTargetHint.HeroData != null && instance.m_ArenaTargetHint.HeroData[index].ID != (ushort) 0)
      {
        ((Component) this.m_HeroBtn[index]).gameObject.SetActive(true);
        ((Component) this.m_Frame[index]).gameObject.SetActive(false);
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_HeroBtn[index]).transform, eHeroOrItem.Hero, instance.m_ArenaTargetHint.HeroData[index].ID, instance.m_ArenaTargetHint.HeroData[index].Star, instance.m_ArenaTargetHint.HeroData[index].Rank, (int) instance.m_ArenaTargetHint.HeroData[index].Level);
        if (instance.CheckHeroAstrology(instance.m_ArenaTargetHint.HeroData[index].ID))
          ((Component) this.m_Astrology[index]).gameObject.SetActive(true);
        else
          ((Component) this.m_Astrology[index]).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.m_Astrology[index]).gameObject.SetActive(false);
        ((Component) this.m_HeroBtn[index]).gameObject.SetActive(false);
        ((Component) this.m_Frame[index]).gameObject.SetActive(true);
      }
    }
    this.m_StrRank.IntToFormat((long) instance.m_ArenaTargetHint.Place, bNumber: true);
    this.m_StrRank.AppendFormat("{0}");
    this.m_TextRank.text = this.m_StrRank.ToString();
    this.m_TextRank.SetAllDirty();
    this.m_TextRank.cachedTextGenerator.Invalidate();
    this.m_StrStrength.IntToFormat((long) instance.GetAllPower((byte) 0), bNumber: true);
    this.m_StrStrength.AppendFormat("{0}");
    this.m_TextStrength.text = this.m_StrStrength.ToString();
    this.m_TextStrength.SetAllDirty();
    this.m_TextStrength.cachedTextGenerator.Invalidate();
    CString Name = StringManager.Instance.StaticString1024();
    CString Tag = StringManager.Instance.StaticString1024();
    Name.ClearString();
    Tag.ClearString();
    Name.Append(instance.m_ArenaTargetHint.Name);
    if (instance.m_ArenaTargetHint.AllianceTagTag != string.Empty)
    {
      Tag.Append(instance.m_ArenaTargetHint.AllianceTagTag);
      GameConstants.FormatRoleName(this.m_StrName, Name, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    }
    else
      GameConstants.FormatRoleName(this.m_StrName, Name, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    this.m_TextName.text = this.m_StrName.ToString();
    this.m_TextName.SetAllDirty();
    this.m_TextName.cachedTextGenerator.Invalidate();
  }

  public void ShowHint(byte type = 1, RectTransform tipRect = null)
  {
    ((Component) this.m_RectTransform).gameObject.SetActive(true);
    this.Type = type;
    AllianceWarManager allianceWarMgr = ActivityManager.Instance.AllianceWarMgr;
    if (this.Type != (byte) 1)
      return;
    ((Component) this.m_BGRectTransform).gameObject.SetActive(false);
    ((Component) this.m_BGRectTransform2).gameObject.SetActive(true);
    ((Component) this.m_Main[0]).gameObject.SetActive(false);
    float num = 0.0f;
    bool flag = GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 17;
    ((Component) this.m_Text_F).gameObject.SetActive(flag);
    if (flag)
    {
      num += 22f;
      ((Graphic) this.m_Line2).rectTransform.anchoredPosition = new Vector2(((Graphic) this.m_Line2).rectTransform.anchoredPosition.x, -161f);
    }
    else
      ((Graphic) this.m_Line2).rectTransform.anchoredPosition = new Vector2(((Graphic) this.m_Line2).rectTransform.anchoredPosition.x, -139f);
    ((Component) this.m_Main[0]).gameObject.SetActive(allianceWarMgr.m_AllianceWarHintData.bMain);
    for (int index = 0; index < 5; ++index)
    {
      if (allianceWarMgr.m_AllianceWarHintData.HeroData[index].ID != (ushort) 0)
      {
        ((Component) this.m_HeroBtn2[index]).gameObject.SetActive(true);
        ((Component) this.m_Frame2[index]).gameObject.SetActive(false);
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_HeroBtn2[index]).transform, eHeroOrItem.Hero, allianceWarMgr.m_AllianceWarHintData.HeroData[index].ID, allianceWarMgr.m_AllianceWarHintData.HeroData[index].Star, allianceWarMgr.m_AllianceWarHintData.HeroData[index].Rank);
      }
      else
      {
        ((Component) this.m_HeroBtn2[index]).gameObject.SetActive(false);
        ((Component) this.m_Frame2[index]).gameObject.SetActive(true);
      }
    }
    DataManager instance = DataManager.Instance;
    this.m_StrStrength.ClearString();
    this.m_StrStrength.Append(instance.mStringTable.GetStringByID(9788U));
    this.m_StrStrength.Append(instance.mStringTable.GetStringByID((uint) (ushort) (9778U + (uint) allianceWarMgr.m_AllianceWarHintData.ArmyCoordIndex)));
    this.m_Text_F.text = this.m_StrStrength.ToString();
    this.m_Text_F.SetAllDirty();
    this.m_Text_F.cachedTextGenerator.Invalidate();
    int index1 = 0;
    for (int index2 = 0; index2 < 16; ++index2)
    {
      int index3 = 3 - index2 / 4 + index2 % 4 * 4;
      if (allianceWarMgr.m_AllianceWarHintData.TroopData[index3] > 0U)
      {
        SoldierData recordByKey = instance.SoldierDataTable.GetRecordByKey((ushort) (index3 + 1));
        this.m_dataNum[index1].ClearString();
        this.m_data_Icon[index1].sprite = (int) recordByKey.SoldierKind >= this.mSprite.Length ? this.mSprite[0] : this.mSprite[(int) recordByKey.SoldierKind];
        this.m_Text_data_Rank[index1].text = recordByKey.Tier.ToString();
        this.m_Text_data_Name[index1].text = instance.mStringTable.GetStringByID((uint) recordByKey.Name);
        this.m_Text_data_Name[index1].SetAllDirty();
        this.m_Text_data_Name[index1].cachedTextGenerator.Invalidate();
        this.m_Text_data_Name[index1].cachedTextGeneratorForLayout.Invalidate();
        this.m_dataNum[index1].ClearString();
        this.m_dataNum[index1].IntToFormat((long) allianceWarMgr.m_AllianceWarHintData.TroopData[index3], bNumber: true);
        this.m_dataNum[index1].AppendFormat("{0}");
        this.m_Text_data_Num[index1].text = this.m_dataNum[index1].ToString();
        this.m_Text_data_Num[index1].SetAllDirty();
        this.m_Text_data_Num[index1].cachedTextGenerator.Invalidate();
        this.m_Text_data_Num[index1].cachedTextGeneratorForLayout.Invalidate();
        this.m_T_data[index1].gameObject.SetActive(true);
        ++index1;
      }
    }
    for (int index4 = index1; index4 < 16; ++index4)
      this.m_T_data[index4].gameObject.SetActive(false);
    this.m_BGRectTransform2.sizeDelta = new Vector2(this.m_BGRectTransform2.sizeDelta.x, 170f + (num + (float) (index1 * 28)));
    ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>();
    this.m_BGRectTransform2.anchoredPosition = new Vector2(0.0f, 0.0f);
    CString Name = StringManager.Instance.StaticString1024();
    CString Tag = StringManager.Instance.StaticString1024();
    Name.ClearString();
    Tag.ClearString();
    Name.Append(allianceWarMgr.m_AllianceWarHintData.Name);
    if (allianceWarMgr.m_AllianceWarHintData.AllianceTagTag != string.Empty)
    {
      Tag.Append(allianceWarMgr.m_AllianceWarHintData.AllianceTagTag);
      GameConstants.FormatRoleName(this.m_StrName, Name, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    }
    else
      GameConstants.FormatRoleName(this.m_StrName, Name, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    this.m_TextName2.text = this.m_StrName.ToString();
    this.m_TextName2.SetAllDirty();
    this.m_TextName2.cachedTextGenerator.Invalidate();
    if (!((Object) tipRect != (Object) null))
      return;
    this.GetTipPosition(tipRect);
  }

  public void Hide(UIButtonHint hint)
  {
    ((Component) this.m_RectTransform).gameObject.SetActive(false);
  }

  public void Hide() => ((Component) this.m_RectTransform).gameObject.SetActive(false);

  public void OnButtonDown(UIButtonHint sender)
  {
    this.Show(sender, (float) sender.Parm2, 0.0f, (byte) 0);
  }

  public void OnButtonUp(UIButtonHint sender) => this.Hide(sender);

  public void TextRefresh()
  {
    if ((Object) this.m_TextRank != (Object) null && ((Behaviour) this.m_TextRank).enabled)
    {
      ((Behaviour) this.m_TextRank).enabled = false;
      ((Behaviour) this.m_TextRank).enabled = true;
    }
    if ((Object) this.m_TextStrength != (Object) null && ((Behaviour) this.m_TextStrength).enabled)
    {
      ((Behaviour) this.m_TextStrength).enabled = false;
      ((Behaviour) this.m_TextStrength).enabled = true;
    }
    if ((Object) this.m_TextName != (Object) null && ((Behaviour) this.m_TextName).enabled)
    {
      ((Behaviour) this.m_TextName).enabled = false;
      ((Behaviour) this.m_TextName).enabled = true;
    }
    if ((Object) this.m_TextName2 != (Object) null && ((Behaviour) this.m_TextName2).enabled)
    {
      ((Behaviour) this.m_TextName2).enabled = false;
      ((Behaviour) this.m_TextName2).enabled = true;
    }
    if ((Object) this.m_Text_F != (Object) null && ((Behaviour) this.m_Text_F).enabled)
    {
      ((Behaviour) this.m_Text_F).enabled = false;
      ((Behaviour) this.m_Text_F).enabled = true;
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((Object) this.m_HeroBtn[index] != (Object) null && ((Behaviour) this.m_HeroBtn[index]).enabled)
        this.m_HeroBtn[index].Refresh_FontTexture();
      if ((Object) this.m_HeroBtn2[index] != (Object) null && ((Behaviour) this.m_HeroBtn2[index]).enabled)
        this.m_HeroBtn2[index].Refresh_FontTexture();
    }
    for (int index = 0; index < 16; ++index)
    {
      if ((Object) this.m_Text_data_Rank[index] != (Object) null && ((Behaviour) this.m_Text_data_Rank[index]).enabled)
      {
        ((Behaviour) this.m_Text_data_Rank[index]).enabled = false;
        ((Behaviour) this.m_Text_data_Rank[index]).enabled = true;
      }
      if ((Object) this.m_Text_data_Name[index] != (Object) null && ((Behaviour) this.m_Text_data_Name[index]).enabled)
      {
        ((Behaviour) this.m_Text_data_Name[index]).enabled = false;
        ((Behaviour) this.m_Text_data_Name[index]).enabled = true;
      }
      if ((Object) this.m_Text_data_Num[index] != (Object) null && ((Behaviour) this.m_Text_data_Num[index]).enabled)
      {
        ((Behaviour) this.m_Text_data_Num[index]).enabled = false;
        ((Behaviour) this.m_Text_data_Num[index]).enabled = true;
      }
    }
  }

  public void UpdateUI()
  {
    if (this.Type != (byte) 0)
      return;
    ArenaManager instance = ArenaManager.Instance;
    this.m_StrRank.ClearString();
    this.m_StrStrength.ClearString();
    this.m_StrName.ClearString();
    for (int index = 0; index < 5; ++index)
    {
      if (instance.m_ArenaTargetHint.HeroData != null && instance.m_ArenaTargetHint.HeroData[index].ID != (ushort) 0)
      {
        ((Component) this.m_HeroBtn[index]).gameObject.SetActive(true);
        ((Component) this.m_Frame[index]).gameObject.SetActive(false);
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_HeroBtn[index]).transform, eHeroOrItem.Hero, instance.m_ArenaTargetHint.HeroData[index].ID, instance.m_ArenaTargetHint.HeroData[index].Star, instance.m_ArenaTargetHint.HeroData[index].Rank, (int) instance.m_ArenaTargetHint.HeroData[index].Level);
        if (instance.CheckHeroAstrology(instance.m_ArenaTargetHint.HeroData[index].ID))
          ((Component) this.m_Astrology[index]).gameObject.SetActive(true);
        else
          ((Component) this.m_Astrology[index]).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.m_Astrology[index]).gameObject.SetActive(false);
        ((Component) this.m_HeroBtn[index]).gameObject.SetActive(false);
        ((Component) this.m_Frame[index]).gameObject.SetActive(true);
      }
    }
    this.m_StrRank.IntToFormat((long) instance.m_ArenaTargetHint.Place, bNumber: true);
    this.m_StrRank.AppendFormat("{0}");
    this.m_TextRank.text = this.m_StrRank.ToString();
    this.m_TextRank.SetAllDirty();
    this.m_TextRank.cachedTextGenerator.Invalidate();
    this.m_StrStrength.IntToFormat((long) instance.GetAllPower((byte) 0), bNumber: true);
    this.m_StrStrength.AppendFormat("{0}");
    this.m_TextStrength.text = this.m_StrStrength.ToString();
    this.m_TextStrength.SetAllDirty();
    this.m_TextStrength.cachedTextGenerator.Invalidate();
  }

  public void GetTipPosition(RectTransform tipRect)
  {
    RectTransform rectTransform = tipRect;
    if ((Object) rectTransform == (Object) null)
      return;
    Vector2 sizeDelta = ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta;
    ((Transform) this.m_BGRectTransform2).position = ((Transform) rectTransform).position;
    Vector3 anchoredPosition3D = this.m_BGRectTransform2.anchoredPosition3D with
    {
      x = 0.0f
    };
    anchoredPosition3D.y += rectTransform.rect.y;
    anchoredPosition3D.z = 0.0f;
    if ((double) anchoredPosition3D.y + (double) rectTransform.rect.height + (double) this.m_BGRectTransform2.sizeDelta.y / 2.0 > (double) sizeDelta.y / 2.0)
      anchoredPosition3D.y = (float) ((double) sizeDelta.y / 2.0 - (double) this.m_BGRectTransform2.sizeDelta.y / 2.0);
    else if (-1.0 * (double) anchoredPosition3D.y + (double) this.m_BGRectTransform2.sizeDelta.y / 2.0 > (double) sizeDelta.y / 2.0)
      anchoredPosition3D.y = (float) (-1.0 * ((double) sizeDelta.y / 2.0 - (double) this.m_BGRectTransform2.sizeDelta.y / 2.0));
    this.m_BGRectTransform2.anchoredPosition3D = anchoredPosition3D;
  }
}
