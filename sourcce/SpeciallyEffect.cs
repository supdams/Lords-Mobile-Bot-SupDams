// Decompiled with JetBrains decompiler
// Type: SpeciallyEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class SpeciallyEffect
{
  private DataManager DM;
  private GUIManager GUIM;
  private Door door;
  public RectTransform m_RectTransform;
  public RectTransform mCanvasRT;
  public Transform[] m_ItmeTransform = new Transform[7];
  public Transform[][] m_Itme2T = new Transform[5][];
  public RectTransform[][] m_IconRT = new RectTransform[5][];
  public Image[][] EffectIcon = new Image[5][];
  public float[][] Timer = new float[5][];
  private Vector2[][] bezierStart = new Vector2[5][];
  private Vector2[][] bezierCenter = new Vector2[5][];
  private Vector2[][] bezierCenter2 = new Vector2[5][];
  private Vector2[][] bezierEnd = new Vector2[5][];
  public int mNum;
  public int[] mCount = new int[5];
  public int mIteCount;
  public UIHIBtn[][] m_Item = new UIHIBtn[5][];
  public UILEBtn[][] m_Item_L = new UILEBtn[5][];
  public RectTransform[][] m_ItemRT = new RectTransform[5][];
  public RectTransform[][] m_Item_LRT = new RectTransform[5][];
  public byte[][] mMoveKind = new byte[5][];
  public RectTransform m_BGRectTransform;
  public Image m_ImgBG;
  public float mBGTimer;
  public Vector2 UI_bezieEnd;
  public RectTransform[][] m_IconRT1 = new RectTransform[5][];
  public RectTransform[][] m_IconRT2 = new RectTransform[5][];
  public RectTransform[][] m_IconRT3 = new RectTransform[5][];
  public RectTransform[][] m_IconRT4 = new RectTransform[5][];
  public Image[][] EffectIcon1 = new Image[5][];
  public Image[][] EffectIcon2 = new Image[5][];
  public Image[][] EffectIcon3 = new Image[5][];
  public Image[][] EffectIcon4 = new Image[5][];
  private Equip tmpEQ;
  public Vector2[][] mV2Start = new Vector2[5][];
  private Material m_Mat;
  public int tmpCountKind;
  public float[][] mCDTimer = new float[5][];
  public float mRes_Time = 0.1f;
  public byte[][] tmpKindNum = new byte[5][];
  public int[] tmpKindLineNum = new int[5];
  public float TimeParameters1 = 0.5f;
  public bool[][] m_Icon = new bool[5][];
  public byte[][] mKindEnd = new byte[5][];
  public Transform[] m_ResourceIconT = new Transform[5];
  public Transform[] m_FuncButtonT = new Transform[6];
  public Transform m_HeadImageT;
  public Transform m_PowerImageT;
  public Transform m_DiamondIconT;
  public Transform m_MoraleIconT;
  public Transform m_VipIconT;
  public Transform m_IconT;
  public byte[][] tmpResQty = new byte[5][];
  public float ScaleParameters = 2f;
  public byte[][] tmpKindEndNum = new byte[5][];
  public uint[] mResValue = new uint[5];
  public uint tmpResValue;
  public uint mDiamondValue;
  public Transform mUITransform;
  public Transform mUIGiftform;
  public Transform mUIGiftKeyValueform;
  public bool mAddVIP;
  public bool mAddGiftExp;
  public bool mAddGiftPoint;
  public Vector2 ItemV2;
  public bool bShowImgBG = true;
  public float[][] mEndTime = new float[5][];
  private GameObject[] mParticleEffect = new GameObject[5];
  public List<PlayerProfileEquip> mItemlist = new List<PlayerProfileEquip>();
  public float m_ItemNextTime = 1f;

  public void Load()
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    Object original = this.GUIM.m_EffectAssetBundle.Load(nameof (SpeciallyEffect));
    if (original == (Object) null)
      return;
    GameObject gameObject = (GameObject) Object.Instantiate(original);
    gameObject.transform.SetParent((Transform) this.GUIM.m_WindowTopLayer, false);
    gameObject.SetActive(false);
    this.m_RectTransform = gameObject.transform as RectTransform;
    for (int index1 = 0; index1 < 5; ++index1)
    {
      this.m_ItmeTransform[index1] = ((Transform) this.m_RectTransform).GetChild(index1);
      this.m_IconRT[index1] = new RectTransform[7];
      this.m_IconRT1[index1] = new RectTransform[7];
      this.m_IconRT2[index1] = new RectTransform[7];
      this.m_IconRT3[index1] = new RectTransform[7];
      this.m_IconRT4[index1] = new RectTransform[7];
      this.EffectIcon[index1] = new Image[7];
      this.EffectIcon1[index1] = new Image[7];
      this.EffectIcon2[index1] = new Image[7];
      this.EffectIcon3[index1] = new Image[7];
      this.EffectIcon4[index1] = new Image[7];
      this.m_Item[index1] = new UIHIBtn[3];
      this.m_Item_L[index1] = new UILEBtn[3];
      this.m_ItemRT[index1] = new RectTransform[3];
      this.m_Item_LRT[index1] = new RectTransform[3];
      this.Timer[index1] = new float[10];
      this.mMoveKind[index1] = new byte[10];
      this.bezierStart[index1] = new Vector2[10];
      this.bezierCenter[index1] = new Vector2[10];
      this.bezierCenter2[index1] = new Vector2[10];
      this.bezierEnd[index1] = new Vector2[10];
      this.mKindEnd[index1] = new byte[10];
      this.m_Icon[index1] = new bool[10];
      this.m_Itme2T[index1] = new Transform[7];
      this.mV2Start[index1] = new Vector2[7];
      this.mCDTimer[index1] = new float[7];
      this.tmpKindNum[index1] = new byte[7];
      this.tmpResQty[index1] = new byte[7];
      this.tmpKindEndNum[index1] = new byte[10];
      this.mEndTime[index1] = new float[10];
      for (int index2 = 0; index2 < 7; ++index2)
      {
        this.EffectIcon[index1][index2] = this.m_ItmeTransform[index1].GetChild(index2).GetComponent<Image>();
        ((Component) this.EffectIcon[index1][index2]).gameObject.SetActive(false);
        this.m_IconRT[index1][index2] = this.m_ItmeTransform[index1].GetChild(index2).GetComponent<RectTransform>();
        this.m_Itme2T[index1][index2] = this.m_ItmeTransform[index1].GetChild(13 + index2);
        this.m_Itme2T[index1][index2].gameObject.SetActive(false);
        this.EffectIcon1[index1][index2] = this.m_Itme2T[index1][index2].GetChild(0).GetComponent<Image>();
        this.EffectIcon2[index1][index2] = this.m_Itme2T[index1][index2].GetChild(1).GetComponent<Image>();
        this.EffectIcon3[index1][index2] = this.m_Itme2T[index1][index2].GetChild(2).GetComponent<Image>();
        this.EffectIcon4[index1][index2] = this.m_Itme2T[index1][index2].GetChild(3).GetComponent<Image>();
        ((Component) this.EffectIcon1[index1][index2]).gameObject.SetActive(false);
        ((Component) this.EffectIcon2[index1][index2]).gameObject.SetActive(false);
        ((Component) this.EffectIcon3[index1][index2]).gameObject.SetActive(false);
        ((Component) this.EffectIcon4[index1][index2]).gameObject.SetActive(false);
        this.m_IconRT1[index1][index2] = this.m_Itme2T[index1][index2].GetChild(0).GetComponent<RectTransform>();
        this.m_IconRT2[index1][index2] = this.m_Itme2T[index1][index2].GetChild(1).GetComponent<RectTransform>();
        this.m_IconRT3[index1][index2] = this.m_Itme2T[index1][index2].GetChild(2).GetComponent<RectTransform>();
        this.m_IconRT4[index1][index2] = this.m_Itme2T[index1][index2].GetChild(3).GetComponent<RectTransform>();
      }
      for (int index3 = 0; index3 < 3; ++index3)
      {
        this.m_Item[index1][index3] = this.m_ItmeTransform[index1].GetChild(7 + index3).GetComponent<UIHIBtn>();
        this.m_ItemRT[index1][index3] = this.m_ItmeTransform[index1].GetChild(7 + index3).GetComponent<RectTransform>();
        this.GUIM.InitianHeroItemImg(((Component) this.m_Item[index1][index3]).transform, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0);
        ((Component) this.m_Item[index1][index3]).gameObject.SetActive(false);
        this.m_Item_L[index1][index3] = this.m_ItmeTransform[index1].GetChild(10 + index3).GetComponent<UILEBtn>();
        this.m_Item_LRT[index1][index3] = this.m_ItmeTransform[index1].GetChild(10 + index3).GetComponent<RectTransform>();
        this.GUIM.InitLordEquipImg(((Component) this.m_Item_L[index1][index3]).transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        ((Component) this.m_Item_L[index1][index3]).gameObject.SetActive(false);
      }
    }
    this.m_ImgBG = ((Transform) this.m_RectTransform).GetChild(5).GetComponent<Image>();
    this.m_BGRectTransform = ((Transform) this.m_RectTransform).GetChild(5).GetComponent<RectTransform>();
    this.mCanvasRT = ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>();
  }

  public void InitSE_Mat()
  {
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.m_Mat = this.door.LoadMaterial();
    this.m_ImgBG.sprite = this.door.LoadSprite("UI_m_light_001");
    ((MaskableGraphic) this.m_ImgBG).material = this.m_Mat;
    this.m_ImgBG.SetNativeSize();
    this.mCanvasRT = ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>();
    for (int index = 0; index < 5; ++index)
      this.m_ResourceIconT[index] = ((Component) this.door.m_ResourceIcon[index]).transform;
    for (int index = 0; index < 6; ++index)
      this.m_FuncButtonT[index] = ((Component) this.door.m_FuncRC[index]).transform;
    this.ItemV2 = this.m_FuncButtonT[0].GetComponent<RectTransform>().anchoredPosition;
    this.m_HeadImageT = ((Component) this.door.m_HeadImage).transform;
    this.m_PowerImageT = ((Component) this.door.m_PowerBtn).transform;
    this.m_DiamondIconT = ((Component) this.door.m_DiamondIcon).transform;
    this.m_MoraleIconT = ((Component) this.door.m_MoraleIcon).transform;
    this.m_VipIconT = ((Component) this.door.m_VIPIcon).transform;
    for (int index1 = 0; index1 < 5; ++index1)
    {
      for (int index2 = 0; index2 < 7; ++index2)
      {
        this.EffectIcon[index1][index2].sprite = this.door.LoadSprite("UI_m_light_001");
        ((MaskableGraphic) this.EffectIcon[index1][index2]).material = this.m_Mat;
        this.EffectIcon1[index1][index2].sprite = this.door.LoadSprite("UI_m_light_001");
        ((MaskableGraphic) this.EffectIcon1[index1][index2]).material = this.m_Mat;
        this.EffectIcon2[index1][index2].sprite = this.door.LoadSprite("UI_m_light_001");
        ((MaskableGraphic) this.EffectIcon2[index1][index2]).material = this.m_Mat;
        this.EffectIcon3[index1][index2].sprite = this.door.LoadSprite("UI_m_light_001");
        ((MaskableGraphic) this.EffectIcon3[index1][index2]).material = this.m_Mat;
        this.EffectIcon4[index1][index2].sprite = this.door.LoadSprite("UI_m_light_001");
        ((MaskableGraphic) this.EffectIcon4[index1][index2]).material = this.m_Mat;
      }
    }
  }

  public void UnLoad()
  {
    if ((Object) this.m_RectTransform == (Object) null)
      return;
    Object.Destroy((Object) ((Component) this.m_RectTransform).gameObject);
  }

  public void AddIconShow(
    Vector2 mV2,
    SpeciallyEffect_Kind[] Kind,
    ushort[] ItemID,
    bool bShowImg = true)
  {
    if (bShowImg && (Object) this.door == (Object) null)
      return;
    this.tmpKindLineNum[this.mNum] = 0;
    this.mCount[this.mNum] = 0;
    this.bShowImgBG = bShowImg;
    for (int Idx = 0; Idx < Kind.Length; ++Idx)
    {
      this.m_Itme2T[this.mNum][Idx].gameObject.SetActive(false);
      ((Component) this.EffectIcon[this.mNum][Idx]).gameObject.SetActive(false);
      ((Component) this.EffectIcon1[this.mNum][Idx]).gameObject.SetActive(false);
      ((Component) this.EffectIcon2[this.mNum][Idx]).gameObject.SetActive(false);
      ((Component) this.EffectIcon3[this.mNum][Idx]).gameObject.SetActive(false);
      ((Component) this.EffectIcon4[this.mNum][Idx]).gameObject.SetActive(false);
      if (Kind[Idx] != SpeciallyEffect_Kind.Kind)
      {
        this.AddIconShow(true, mV2, Kind[Idx], Idx, (ushort) 0, bShowImg, 2f);
        ++this.tmpKindLineNum[this.mNum];
      }
      else
      {
        this.mKindEnd[this.mNum][Idx] = (byte) 0;
        this.tmpKindEndNum[this.mNum][Idx] = (byte) 0;
      }
    }
    for (int index = 0; index < ItemID.Length; ++index)
    {
      ((Component) this.m_Item[this.mNum][index]).gameObject.SetActive(false);
      ((Component) this.m_Item_L[this.mNum][index]).gameObject.SetActive(false);
      if (ItemID[index] != (ushort) 0)
      {
        this.tmpEQ = this.DM.EquipTable.GetRecordByKey(ItemID[index]);
        if (this.tmpEQ.EquipKind == (byte) 20 || this.tmpEQ.EquipKind == (byte) 27)
          this.AddIconShow(true, mV2, SpeciallyEffect_Kind.Item_Material, index + 7, ItemID[index], bShowImg, 2f);
        else if (this.tmpEQ.EquipKind == (byte) 6 && this.tmpEQ.PropertiesInfo[0].Propertieskey == (ushort) 5)
          this.AddIconShow(true, mV2, SpeciallyEffect_Kind.PetSkill_PetItem, index + 7, ItemID[index], bShowImg, 2f);
        else
          this.AddIconShow(true, mV2, SpeciallyEffect_Kind.Item, index + 7, ItemID[index], bShowImg, 2f);
      }
      else
      {
        this.mKindEnd[this.mNum][index + 7] = (byte) 0;
        this.tmpKindEndNum[this.mNum][index + 7] = (byte) 0;
      }
    }
    if (this.mNum < 4)
      ++this.mNum;
    else
      this.mNum = 0;
    if (this.mIteCount >= 5)
      return;
    ++this.mIteCount;
  }

  public void AddIconShow(
    bool bMission,
    Vector2 mV2,
    SpeciallyEffect_Kind Kind,
    int Idx = 0,
    ushort ItemID = 0,
    bool bShowImg = true,
    float EndTime = 2)
  {
    if (Kind != SpeciallyEffect_Kind.TreasureBoxEX && (Object) this.door == (Object) null || bShowImg && (Object) this.door == (Object) null)
      return;
    if (!bShowImg)
      ((Component) this.m_ImgBG).gameObject.SetActive(false);
    this.bShowImgBG = bShowImg;
    float num = 0.0f;
    if (this.GUIM.bOpenOnIPhoneX)
      num = this.GUIM.IPhoneX_DeltaX;
    Vector2 vector2_1 = new Vector2(mV2.x - num, -mV2.y);
    if (Idx == 0)
    {
      this.tmpCountKind = 0;
      ((Component) this.m_RectTransform).gameObject.SetActive(true);
      ((Transform) this.m_RectTransform).SetAsLastSibling();
      this.m_ItmeTransform[this.mNum].gameObject.SetActive(true);
      if (!bMission && (Kind == SpeciallyEffect_Kind.Item || Kind == SpeciallyEffect_Kind.Item_Material || Kind == SpeciallyEffect_Kind.AddVIP || Kind == SpeciallyEffect_Kind.TreasureBox2 || Kind == SpeciallyEffect_Kind.Donation_Item || Kind == SpeciallyEffect_Kind.Donation_Item_Material || Kind == SpeciallyEffect_Kind.PetSkill_PetItem))
        Idx += 7;
      this.m_BGRectTransform.anchoredPosition = vector2_1;
      if (this.bShowImgBG)
      {
        ((Component) this.m_ImgBG).gameObject.SetActive(true);
        ((Graphic) this.m_ImgBG).color = new Color(1f, 1f, 1f, 1f);
      }
      this.mBGTimer = 0.0f;
    }
    if (this.tmpKindLineNum[this.mNum] == 0)
    {
      this.tmpCountKind = 0;
      ((Component) this.m_RectTransform).gameObject.SetActive(true);
      ((Transform) this.m_RectTransform).SetAsLastSibling();
      this.m_ItmeTransform[this.mNum].gameObject.SetActive(true);
      this.m_BGRectTransform.anchoredPosition = vector2_1;
      if (this.bShowImgBG)
      {
        ((Component) this.m_ImgBG).gameObject.SetActive(true);
        ((Graphic) this.m_ImgBG).color = new Color(1f, 1f, 1f, 1f);
      }
      this.mBGTimer = 0.0f;
    }
    this.Timer[this.mNum][Idx] = 0.0f;
    this.bezierStart[this.mNum][Idx] = vector2_1;
    this.mMoveKind[this.mNum][Idx] = (byte) 2;
    this.tmpKindEndNum[this.mNum][Idx] = (byte) 0;
    this.mEndTime[this.mNum][Idx] = EndTime;
    switch (Kind)
    {
      case SpeciallyEffect_Kind.Power:
        if (this.door.m_eMode == EUIOriginMode.Show)
        {
          this.bezierEnd[this.mNum][Idx] = new Vector2(20f + num, -26f);
          this.mKindEnd[this.mNum][Idx] = (byte) 1;
        }
        else
        {
          this.bezierEnd[this.mNum][Idx] = new Vector2(0.0f + num, 0.0f);
          this.mKindEnd[this.mNum][Idx] = (byte) 0;
        }
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_strength");
        break;
      case SpeciallyEffect_Kind.Diamond:
        this.bezierEnd[this.mNum][Idx] = this.door.m_eMode != EUIOriginMode.Show ? new Vector2(60f + num, -20f) : new Vector2(126f + num, -56f);
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_money_02");
        this.mKindEnd[this.mNum][Idx] = (byte) 2;
        break;
      case SpeciallyEffect_Kind.Morale:
        this.bezierEnd[this.mNum][Idx] = this.door.m_eMode != EUIOriginMode.Show ? new Vector2(60f + num, -50f) : new Vector2(126f + num, -90f);
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_money_03");
        this.mKindEnd[this.mNum][Idx] = (byte) 3;
        break;
      case SpeciallyEffect_Kind.LeadExp:
        this.bezierEnd[this.mNum][Idx] = this.door.m_eMode != EUIOriginMode.Show ? new Vector2(0.0f + num, 0.0f) : new Vector2(58f + num, -78f);
        this.EffectIcon[this.mNum][Idx].sprite = DataManager.Instance.UserLanguage != GameLanguage.GL_Chs ? this.door.LoadSprite("UI_main_res_exp") : this.door.LoadSprite("UI_main_res_exp_cn");
        this.mKindEnd[this.mNum][Idx] = (byte) 4;
        break;
      case SpeciallyEffect_Kind.LeadCoin:
        this.bezierEnd[this.mNum][Idx] = this.door.m_eMode != EUIOriginMode.Show ? new Vector2(0.0f + num, 0.0f) : new Vector2(58f + num, -78f);
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_end_icon_003");
        this.mKindEnd[this.mNum][Idx] = (byte) 5;
        break;
      case SpeciallyEffect_Kind.Item:
        this.bezierEnd[this.mNum][Idx] = this.door.m_eMode != EUIOriginMode.Show || this.door.m_bShowFuncButton == (byte) 0 ? new Vector2(this.mCanvasRT.sizeDelta.x - 23f - num - num, (float) (-(double) this.mCanvasRT.sizeDelta.y + 44.0)) : new Vector2((float) ((double) this.mCanvasRT.sizeDelta.x + (double) this.ItemV2.x - 78.0) - num - num, (float) -((double) this.mCanvasRT.sizeDelta.y - (double) this.ItemV2.y - 10.0));
        this.GUIM.ChangeHeroItemImg(((Component) this.m_Item[this.mNum][Idx - 7]).transform, eHeroOrItem.Item, ItemID, (byte) 0, (byte) 0);
        this.mKindEnd[this.mNum][Idx] = (byte) 6;
        break;
      case SpeciallyEffect_Kind.Item_Material:
        this.bezierEnd[this.mNum][Idx] = new Vector2(num - 60f, 60f);
        this.GUIM.ChangeLordEquipImg(((Component) this.m_Item_L[this.mNum][Idx - 7]).transform, ItemID, this.GUIM.SE_Item_L_Color[Idx - 7], gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        this.mKindEnd[this.mNum][Idx] = (byte) 7;
        break;
      case SpeciallyEffect_Kind.HeroExp:
        this.bezierEnd[this.mNum][Idx] = this.door.m_eMode != EUIOriginMode.Show || this.door.m_bShowFuncButton == (byte) 0 ? new Vector2(this.mCanvasRT.sizeDelta.x - 23f - num - num, (float) (-(double) this.mCanvasRT.sizeDelta.y + 44.0)) : new Vector2(this.mCanvasRT.sizeDelta.x - 123f - num - num, (float) (-(double) this.mCanvasRT.sizeDelta.y + 44.0));
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("icon010");
        this.mKindEnd[this.mNum][Idx] = (byte) 8;
        break;
      case SpeciallyEffect_Kind.Other:
        this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 23f - num - num, (float) (-(double) this.mCanvasRT.sizeDelta.y + 44.0));
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("icon001");
        this.mKindEnd[this.mNum][Idx] = (byte) 0;
        break;
      case SpeciallyEffect_Kind.AllianceMoney:
        this.bezierEnd[this.mNum][Idx] = this.door.m_eMode != EUIOriginMode.Show || this.door.m_bShowFuncButton == (byte) 0 ? new Vector2(this.mCanvasRT.sizeDelta.x - 23f - num - num, (float) (-(double) this.mCanvasRT.sizeDelta.y + 44.0)) : new Vector2(this.mCanvasRT.sizeDelta.x - 600f - num - num, (float) (-(double) this.mCanvasRT.sizeDelta.y + 44.0));
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_league");
        this.mKindEnd[this.mNum][Idx] = (byte) 10;
        break;
      case SpeciallyEffect_Kind.Alliance_Speed_Money:
      case SpeciallyEffect_Kind.Alliance_Speed_Money2:
        this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_league");
        this.mKindEnd[this.mNum][Idx] = (byte) 11;
        break;
      case SpeciallyEffect_Kind.Alliance_Gift_Key:
        this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_league_key_01");
        this.mKindEnd[this.mNum][Idx] = (byte) 12;
        break;
      case SpeciallyEffect_Kind.Alliance_Gift:
        this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_league_icon_02");
        this.mKindEnd[this.mNum][Idx] = (byte) 13;
        break;
      case SpeciallyEffect_Kind.AddVIP:
        this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
        this.GUIM.ChangeHeroItemImg(((Component) this.m_Item[this.mNum][Idx - 7]).transform, eHeroOrItem.Item, ItemID, (byte) 0, (byte) 0);
        this.mKindEnd[this.mNum][Idx] = (byte) 14;
        break;
      case SpeciallyEffect_Kind.AddVIP_Point:
        this.bezierEnd[this.mNum][Idx] = this.door.m_eMode != EUIOriginMode.Show ? new Vector2(0.0f + num, 0.0f) : new Vector2(125f + num, -120f);
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("icon039");
        this.mKindEnd[this.mNum][Idx] = (byte) 15;
        break;
      case SpeciallyEffect_Kind.Food:
        this.bezierEnd[this.mNum][Idx] = !Indemnify.IsEffectShow ? (this.door.m_eMode != EUIOriginMode.Show ? new Vector2(this.mCanvasRT.sizeDelta.x - 30f - num - num, -30f) : new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -20f)) : new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -370f);
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_food");
        this.mKindEnd[this.mNum][Idx] = !Indemnify.IsEffectShow ? (byte) 16 : (byte) 0;
        break;
      case SpeciallyEffect_Kind.Stone:
        this.bezierEnd[this.mNum][Idx] = !Indemnify.IsEffectShow ? (this.door.m_eMode != EUIOriginMode.Show || this.door.m_bShowFuncButton == (byte) 0 ? new Vector2(this.mCanvasRT.sizeDelta.x - 30f - num - num, -30f) : new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -56f)) : new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -370f);
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_stone");
        this.mKindEnd[this.mNum][Idx] = !Indemnify.IsEffectShow ? (byte) 17 : (byte) 0;
        break;
      case SpeciallyEffect_Kind.Wood:
        this.bezierEnd[this.mNum][Idx] = !Indemnify.IsEffectShow ? (this.door.m_eMode != EUIOriginMode.Show || this.door.m_bShowFuncButton == (byte) 0 ? new Vector2(this.mCanvasRT.sizeDelta.x - 30f - num - num, -30f) : new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -90f)) : new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -370f);
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_wood");
        this.mKindEnd[this.mNum][Idx] = !Indemnify.IsEffectShow ? (byte) 18 : (byte) 0;
        break;
      case SpeciallyEffect_Kind.Iron:
        this.bezierEnd[this.mNum][Idx] = !Indemnify.IsEffectShow ? (this.door.m_eMode != EUIOriginMode.Show || this.door.m_bShowFuncButton == (byte) 0 ? new Vector2(this.mCanvasRT.sizeDelta.x - 30f - num - num, -30f) : new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -124f)) : new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -370f);
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_iron");
        this.mKindEnd[this.mNum][Idx] = !Indemnify.IsEffectShow ? (byte) 19 : (byte) 0;
        break;
      case SpeciallyEffect_Kind.Money:
        this.bezierEnd[this.mNum][Idx] = this.door.m_eMode != EUIOriginMode.Show ? new Vector2(this.mCanvasRT.sizeDelta.x - 30f - num - num, -30f) : new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -160f);
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_money_01");
        this.mKindEnd[this.mNum][Idx] = (byte) 20;
        break;
      case SpeciallyEffect_Kind.MobilizationMission:
        this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_mall_box_a_02");
        this.mKindEnd[this.mNum][Idx] = (byte) 21;
        break;
      case SpeciallyEffect_Kind.TreasureBox2:
        this.bezierEnd[this.mNum][Idx] = this.door.m_eMode != EUIOriginMode.Show ? new Vector2(60f + num, -50f) : new Vector2(126f + num, -90f);
        this.GUIM.ChangeHeroItemImg(((Component) this.m_Item[this.mNum][Idx - 7]).transform, eHeroOrItem.Item, ItemID, (byte) 0, (byte) 0);
        this.mKindEnd[this.mNum][Idx] = (byte) 23;
        break;
      case SpeciallyEffect_Kind.TreasureBoxEX:
        this.EffectIcon[this.mNum][Idx].sprite = this.GUIM.LoadFrameSprite("UI_main_money_02");
        ((MaskableGraphic) this.EffectIcon[this.mNum][Idx]).material = this.GUIM.GetFrameMaterial();
        this.bezierEnd[this.mNum][Idx] = new Vector2(60f + num, -20f);
        break;
      case SpeciallyEffect_Kind.Donation_Item:
        this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
        this.GUIM.ChangeHeroItemImg(((Component) this.m_Item[this.mNum][Idx - 7]).transform, eHeroOrItem.Item, ItemID, (byte) 0, (byte) 0);
        this.mKindEnd[this.mNum][Idx] = (byte) 25;
        break;
      case SpeciallyEffect_Kind.Donation_Item_Material:
        this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
        this.GUIM.ChangeLordEquipImg(((Component) this.m_Item_L[this.mNum][Idx - 7]).transform, ItemID, this.GUIM.SE_Item_L_Color[Idx - 7], gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        this.mKindEnd[this.mNum][Idx] = (byte) 26;
        break;
      case SpeciallyEffect_Kind.CastleStrengrten:
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_c_star_01");
        this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
        this.mKindEnd[this.mNum][Idx] = (byte) 27;
        break;
      case SpeciallyEffect_Kind.PetSkill_Morale:
        this.bezierEnd[this.mNum][Idx] = this.door.m_eMode != EUIOriginMode.Show ? new Vector2(0.0f + num, 0.0f) : new Vector2(126f + num, -90f);
        this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_money_03");
        this.mKindEnd[this.mNum][Idx] = (byte) 28;
        break;
      case SpeciallyEffect_Kind.PetSkill_PetItem:
        this.bezierEnd[this.mNum][Idx] = new Vector2(num - 60f, 60f);
        this.GUIM.ChangeHeroItemImg(((Component) this.m_Item[this.mNum][Idx - 7]).transform, eHeroOrItem.Item, ItemID, (byte) 0, (byte) 0);
        this.mKindEnd[this.mNum][Idx] = (byte) 29;
        break;
    }
    if (Kind == SpeciallyEffect_Kind.Item || Kind == SpeciallyEffect_Kind.AddVIP || Kind == SpeciallyEffect_Kind.TreasureBox2 || Kind == SpeciallyEffect_Kind.Donation_Item || Kind == SpeciallyEffect_Kind.PetSkill_PetItem)
    {
      ((Component) this.m_Item[this.mNum][Idx - 7]).gameObject.SetActive(false);
      this.m_ItemRT[this.mNum][Idx - 7].anchoredPosition = this.bezierStart[this.mNum][Idx];
      ((Component) this.m_Item_L[this.mNum][Idx - 7]).gameObject.SetActive(false);
      this.m_Item_LRT[this.mNum][Idx - 7].anchoredPosition = this.bezierStart[this.mNum][Idx];
    }
    else if (Kind == SpeciallyEffect_Kind.Item_Material || Kind == SpeciallyEffect_Kind.Donation_Item_Material)
    {
      ((Component) this.m_Item[this.mNum][Idx - 7]).gameObject.SetActive(false);
      this.m_ItemRT[this.mNum][Idx - 7].anchoredPosition = this.bezierStart[this.mNum][Idx];
      ((Component) this.m_Item_L[this.mNum][Idx - 7]).gameObject.SetActive(false);
      this.m_Item_LRT[this.mNum][Idx - 7].anchoredPosition = this.bezierStart[this.mNum][Idx];
    }
    else
    {
      if (Kind != SpeciallyEffect_Kind.TreasureBoxEX && (Object) this.door != (Object) null)
        ((MaskableGraphic) this.EffectIcon[this.mNum][Idx]).material = this.m_Mat;
      ((Component) this.EffectIcon[this.mNum][Idx]).gameObject.SetActive(false);
      this.EffectIcon[this.mNum][Idx].SetNativeSize();
      ((Graphic) this.EffectIcon[this.mNum][Idx]).color = new Color(1f, 1f, 1f, 1f);
      this.m_IconRT[this.mNum][Idx].anchoredPosition = this.bezierStart[this.mNum][Idx];
      this.tmpKindNum[this.mNum][Idx] = (byte) 0;
      if (this.GUIM.IsArabic && (Kind == SpeciallyEffect_Kind.AddVIP_Point || Kind == SpeciallyEffect_Kind.HeroExp || Kind == SpeciallyEffect_Kind.LeadExp || Kind == SpeciallyEffect_Kind.Alliance_Gift))
        ((Transform) this.m_IconRT[this.mNum][Idx]).localScale = new Vector3(-1.3f, 1.3f, 1.3f);
      else if (Kind == SpeciallyEffect_Kind.CastleStrengrten)
        ((Transform) this.m_IconRT[this.mNum][Idx]).localScale = new Vector3(1f, 1f, 1f);
      else
        ((Transform) this.m_IconRT[this.mNum][Idx]).localScale = new Vector3(1.3f, 1.3f, 1.3f);
      if (Kind == SpeciallyEffect_Kind.CastleStrengrten)
      {
        if ((Object) this.mParticleEffect[this.mNum] != (Object) null)
        {
          ParticleManager.Instance.DeSpawn(this.mParticleEffect[this.mNum]);
          this.mParticleEffect[this.mNum] = (GameObject) null;
        }
        this.mParticleEffect[this.mNum] = ParticleManager.Instance.Spawn((ushort) 426, ((Component) this.m_IconRT[this.mNum][Idx]).transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
        this.GUIM.SetLayer(this.mParticleEffect[this.mNum], 5);
        this.mParticleEffect[this.mNum].transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
      }
      this.mCDTimer[this.mNum][Idx] = 0.0f;
      if (Kind == SpeciallyEffect_Kind.Diamond || Kind == SpeciallyEffect_Kind.Food || Kind == SpeciallyEffect_Kind.Stone || Kind == SpeciallyEffect_Kind.Wood || Kind == SpeciallyEffect_Kind.Iron || Kind == SpeciallyEffect_Kind.Money || Kind == SpeciallyEffect_Kind.Alliance_Speed_Money2)
      {
        this.tmpResQty[this.mNum][Idx] = (byte) 0;
        switch (Kind)
        {
          case SpeciallyEffect_Kind.Diamond:
            this.tmpResValue = this.mDiamondValue;
            break;
          case SpeciallyEffect_Kind.Alliance_Speed_Money2:
            if ((int) this.DM.AllianceMoneyBonusRate / 100 < 3)
            {
              this.tmpResValue = (uint) (1000 * ((int) this.DM.AllianceMoneyBonusRate / 100));
              break;
            }
            if ((int) this.DM.AllianceMoneyBonusRate / 100 == 3)
            {
              this.tmpResValue = 10000U;
              break;
            }
            if ((int) this.DM.AllianceMoneyBonusRate / 100 >= 4)
            {
              this.tmpResValue = 100000U;
              break;
            }
            break;
          default:
            this.tmpResValue = this.mResValue[(int) (Kind - 16)];
            break;
        }
        this.tmpResQty[this.mNum][Idx] = this.tmpResValue < 1000U || this.tmpResValue >= 3000U ? (this.tmpResValue < 3000U || this.tmpResValue >= 10000U ? (this.tmpResValue < 10000U || this.tmpResValue >= 100000U ? (this.tmpResValue < 100000U ? (byte) 0 : (byte) 4) : (byte) 3) : (byte) 2) : (byte) 1;
        if (this.tmpResQty[this.mNum][Idx] > (byte) 0)
        {
          this.m_Itme2T[this.mNum][Idx].gameObject.SetActive(true);
          this.mCDTimer[this.mNum][Idx] = 0.0f;
          this.EffectIcon1[this.mNum][Idx].sprite = this.EffectIcon[this.mNum][Idx].sprite;
          ((MaskableGraphic) this.EffectIcon1[this.mNum][Idx]).material = this.m_Mat;
          this.EffectIcon1[this.mNum][Idx].SetNativeSize();
          this.EffectIcon2[this.mNum][Idx].sprite = this.EffectIcon[this.mNum][Idx].sprite;
          ((MaskableGraphic) this.EffectIcon2[this.mNum][Idx]).material = this.m_Mat;
          this.EffectIcon2[this.mNum][Idx].SetNativeSize();
          this.EffectIcon3[this.mNum][Idx].sprite = this.EffectIcon[this.mNum][Idx].sprite;
          ((MaskableGraphic) this.EffectIcon3[this.mNum][Idx]).material = this.m_Mat;
          this.EffectIcon3[this.mNum][Idx].SetNativeSize();
          this.EffectIcon4[this.mNum][Idx].sprite = this.EffectIcon[this.mNum][Idx].sprite;
          ((MaskableGraphic) this.EffectIcon4[this.mNum][Idx]).material = this.m_Mat;
          this.EffectIcon4[this.mNum][Idx].SetNativeSize();
          ((Component) this.EffectIcon1[this.mNum][Idx]).gameObject.SetActive(false);
          ((Component) this.EffectIcon2[this.mNum][Idx]).gameObject.SetActive(false);
          ((Component) this.EffectIcon3[this.mNum][Idx]).gameObject.SetActive(false);
          ((Component) this.EffectIcon4[this.mNum][Idx]).gameObject.SetActive(false);
        }
        else
          this.m_Itme2T[this.mNum][Idx].gameObject.SetActive(false);
        this.m_IconRT1[this.mNum][Idx].anchoredPosition = this.bezierStart[this.mNum][Idx];
        ((Transform) this.m_IconRT1[this.mNum][Idx]).localScale = new Vector3(1.3f, 1.3f, 1.3f);
        this.m_IconRT2[this.mNum][Idx].anchoredPosition = this.bezierStart[this.mNum][Idx];
        ((Transform) this.m_IconRT2[this.mNum][Idx]).localScale = new Vector3(1.3f, 1.3f, 1.3f);
        this.m_IconRT3[this.mNum][Idx].anchoredPosition = this.bezierStart[this.mNum][Idx];
        ((Transform) this.m_IconRT3[this.mNum][Idx]).localScale = new Vector3(1.3f, 1.3f, 1.3f);
        this.m_IconRT4[this.mNum][Idx].anchoredPosition = this.bezierStart[this.mNum][Idx];
        ((Transform) this.m_IconRT4[this.mNum][Idx]).localScale = new Vector3(1.3f, 1.3f, 1.3f);
      }
    }
    if (Kind == SpeciallyEffect_Kind.Donation_Item || Kind == SpeciallyEffect_Kind.Donation_Item_Material)
    {
      this.bezierCenter[this.mNum][Idx] = vector2_1;
      this.bezierCenter2[this.mNum][Idx] = vector2_1 + new Vector2(0.0f, 100f);
    }
    else
    {
      Vector2 vector2_2 = this.bezierStart[this.mNum][Idx] - this.bezierEnd[this.mNum][Idx];
      if ((double) vector2_2.x > 0.0 && (double) vector2_2.y < 0.0)
      {
        this.bezierCenter[this.mNum][Idx] = vector2_1;
        this.bezierCenter2[this.mNum][Idx] = vector2_1 + new Vector2(-100f, -100f);
      }
      else if ((double) vector2_2.x > 0.0 && (double) vector2_2.y > 0.0)
      {
        this.bezierCenter[this.mNum][Idx] = vector2_1;
        this.bezierCenter2[this.mNum][Idx] = vector2_1 + new Vector2(-100f, 100f);
      }
      else if ((double) vector2_2.x < 0.0 && (double) vector2_2.y > 0.0)
      {
        this.bezierCenter[this.mNum][Idx] = vector2_1;
        this.bezierCenter2[this.mNum][Idx] = vector2_1 + new Vector2(100f, 100f);
      }
      else if ((double) vector2_2.x < 0.0 && (double) vector2_2.y < 0.0)
      {
        this.bezierCenter[this.mNum][Idx] = vector2_1;
        this.bezierCenter2[this.mNum][Idx] = vector2_1 + new Vector2(100f, -100f);
        if (-(double) this.bezierStart[this.mNum][Idx].y + 100.0 > (double) this.mCanvasRT.sizeDelta.y)
          this.bezierCenter2[this.mNum][Idx] = vector2_1 + new Vector2(100f, 100f);
      }
    }
    ++this.tmpCountKind;
    ++this.mCount[this.mNum];
    if (bMission)
      return;
    this.tmpKindLineNum[this.mNum] = 0;
    if (this.mNum < 4)
      ++this.mNum;
    else
      this.mNum = 0;
    if (this.mIteCount >= 5)
      return;
    ++this.mIteCount;
  }

  public void ClearAllEffect()
  {
    this.mItemlist.Clear();
    for (int index1 = 0; index1 < 5; ++index1)
    {
      this.tmpKindLineNum[index1] = 0;
      for (int index2 = 0; index2 < 10; ++index2)
      {
        this.m_Icon[index1][index2] = false;
        this.tmpKindEndNum[index1][index2] = (byte) 0;
        this.mKindEnd[index1][index2] = (byte) 0;
        this.Timer[index1][index2] = 0.0f;
        this.mMoveKind[index1][index2] = (byte) 0;
        if (index2 < 7)
        {
          this.tmpResQty[index1][index2] = (byte) 0;
          ((Component) this.EffectIcon[index1][index2]).gameObject.SetActive(false);
          ((Component) this.EffectIcon1[index1][index2]).gameObject.SetActive(false);
          ((Component) this.EffectIcon2[index1][index2]).gameObject.SetActive(false);
          ((Component) this.EffectIcon3[index1][index2]).gameObject.SetActive(false);
          ((Component) this.EffectIcon4[index1][index2]).gameObject.SetActive(false);
        }
        else
        {
          ((Component) this.m_Item[index1][index2 - 7]).gameObject.SetActive(false);
          ((Component) this.m_Item_L[index1][index2 - 7]).gameObject.SetActive(false);
        }
      }
      this.mCount[index1] = 0;
      this.m_ItmeTransform[index1].gameObject.SetActive(false);
      if ((Object) this.mParticleEffect[index1] != (Object) null)
      {
        ParticleManager.Instance.DeSpawn(this.mParticleEffect[index1]);
        this.mParticleEffect[index1] = (GameObject) null;
      }
    }
    this.mNum = 0;
    this.mIteCount = 0;
    ((Component) this.m_RectTransform).gameObject.SetActive(false);
    MallManager.Instance.mMonthTreasure_CDTime = 0.0f;
  }

  public void HideIcon(int Idx, int mItemIdx, bool bItem = false, bool bLItem = false)
  {
    if ((Object) this.mParticleEffect[Idx] != (Object) null && this.mKindEnd[Idx][mItemIdx] == (byte) 0)
    {
      ParticleManager.Instance.DeSpawn(this.mParticleEffect[Idx]);
      this.mParticleEffect[Idx] = (GameObject) null;
    }
    if (!bItem)
    {
      ((Component) this.EffectIcon[Idx][mItemIdx]).gameObject.SetActive(false);
      this.tmpKindEndNum[Idx][mItemIdx] = (byte) 2;
      this.m_Icon[Idx][mItemIdx] = true;
    }
    else
    {
      ((Component) this.m_Item_L[Idx][mItemIdx]).gameObject.SetActive(false);
      ((Component) this.m_Item[Idx][mItemIdx]).gameObject.SetActive(false);
      this.tmpKindEndNum[Idx][mItemIdx + 7] = (byte) 2;
      this.m_Icon[Idx][mItemIdx + 7] = true;
    }
    this.Timer[Idx][mItemIdx] = 0.0f;
  }

  public void UpdateRun()
  {
    if ((Object) this.m_RectTransform == (Object) null || !((Component) this.m_RectTransform).gameObject.activeSelf)
      return;
    if ((Object) this.door != (Object) null && ((Component) this.m_ImgBG).gameObject.activeSelf)
    {
      ((Graphic) this.m_ImgBG).color = new Color(1f, 1f, 1f, 1f - this.mBGTimer);
      this.mBGTimer += Time.smoothDeltaTime;
      if ((double) this.mBGTimer > 1.0)
      {
        this.mBGTimer = 0.0f;
        ((Component) this.m_ImgBG).gameObject.SetActive(false);
      }
    }
    for (int index1 = 0; index1 < 5; ++index1)
    {
      for (int index2 = 0; index2 < 10; ++index2)
      {
        this.Timer[index1][index2] += Time.smoothDeltaTime;
        if (index2 < 7)
        {
          if (this.m_Itme2T[index1][index2].gameObject.activeSelf)
          {
            this.mCDTimer[index1][index2] += Time.smoothDeltaTime;
            if ((double) this.mCDTimer[index1][index2] > (double) this.TimeParameters1 * (double) index2 + (double) this.mRes_Time && this.tmpResQty[index1][index2] > (byte) 0)
            {
              if (((Component) this.EffectIcon1[index1][index2]).gameObject.activeSelf)
              {
                if ((double) this.mCDTimer[index1][index2] < (double) this.mEndTime[index1][index2] + (double) this.TimeParameters1 * (double) index2 + (double) this.mRes_Time)
                  this.m_IconRT1[index1][index2].anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart[index1][index2], this.bezierCenter[index1][index2], this.bezierCenter2[index1][index2], this.bezierEnd[index1][index2], 1f / this.mEndTime[index1][index2], this.mCDTimer[index1][index2] - (this.TimeParameters1 * (float) index2 + this.mRes_Time));
                else
                  ((Component) this.m_IconRT1[index1][index2]).gameObject.SetActive(false);
              }
              else
                ((Component) this.EffectIcon1[index1][index2]).gameObject.SetActive(true);
            }
            if ((double) this.mCDTimer[index1][index2] > (double) this.TimeParameters1 * (double) index2 + (double) this.mRes_Time * 2.0 && this.tmpResQty[index1][index2] > (byte) 1)
            {
              if (((Component) this.EffectIcon2[index1][index2]).gameObject.activeSelf)
              {
                if ((double) this.mCDTimer[index1][index2] < (double) this.mEndTime[index1][index2] + (double) this.TimeParameters1 * (double) index2 + (double) this.mRes_Time * 2.0)
                  this.m_IconRT2[index1][index2].anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart[index1][index2], this.bezierCenter[index1][index2], this.bezierCenter2[index1][index2], this.bezierEnd[index1][index2], 1f / this.mEndTime[index1][index2], this.mCDTimer[index1][index2] - (float) ((double) this.TimeParameters1 * (double) index2 + (double) this.mRes_Time * 2.0));
                else
                  ((Component) this.m_IconRT2[index1][index2]).gameObject.SetActive(false);
              }
              else
                ((Component) this.EffectIcon2[index1][index2]).gameObject.SetActive(true);
            }
            if ((double) this.mCDTimer[index1][index2] > (double) this.TimeParameters1 * (double) index2 + (double) this.mRes_Time * 3.0 && this.tmpResQty[index1][index2] > (byte) 2)
            {
              if (((Component) this.EffectIcon3[index1][index2]).gameObject.activeSelf)
              {
                if ((double) this.mCDTimer[index1][index2] < (double) this.mEndTime[index1][index2] + (double) this.TimeParameters1 * (double) index2 + (double) this.mRes_Time * 3.0)
                  this.m_IconRT3[index1][index2].anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart[index1][index2], this.bezierCenter[index1][index2], this.bezierCenter2[index1][index2], this.bezierEnd[index1][index2], 1f / this.mEndTime[index1][index2], this.mCDTimer[index1][index2] - (float) ((double) this.TimeParameters1 * (double) index2 + (double) this.mRes_Time * 3.0));
                else
                  ((Component) this.m_IconRT3[index1][index2]).gameObject.SetActive(false);
              }
              else
                ((Component) this.EffectIcon3[index1][index2]).gameObject.SetActive(true);
            }
            if ((double) this.mCDTimer[index1][index2] > (double) this.TimeParameters1 * (double) index2 + (double) this.mRes_Time * 4.0 && this.tmpResQty[index1][index2] > (byte) 3)
            {
              if (((Component) this.EffectIcon4[index1][index2]).gameObject.activeSelf)
              {
                if ((double) this.mCDTimer[index1][index2] < (double) this.mEndTime[index1][index2] + (double) this.TimeParameters1 * (double) index2 + (double) this.mRes_Time * 4.0)
                  this.m_IconRT4[index1][index2].anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart[index1][index2], this.bezierCenter[index1][index2], this.bezierCenter2[index1][index2], this.bezierEnd[index1][index2], 1f / this.mEndTime[index1][index2], this.mCDTimer[index1][index2] - (float) ((double) this.TimeParameters1 * (double) index2 + (double) this.mRes_Time * 4.0));
                else
                  ((Component) this.m_IconRT4[index1][index2]).gameObject.SetActive(false);
              }
              else
                ((Component) this.EffectIcon4[index1][index2]).gameObject.SetActive(true);
            }
            if ((double) this.mCDTimer[index1][index2] >= (double) this.TimeParameters1 * (double) index2 + (double) this.mEndTime[index1][index2] + (double) this.mRes_Time * (double) ((int) this.tmpResQty[index1][index2] + 1))
              this.m_Itme2T[index1][index2].gameObject.SetActive(false);
          }
          if (((Component) this.EffectIcon[index1][index2]).gameObject.activeSelf)
          {
            if (this.mMoveKind[index1][index2] == (byte) 2)
            {
              this.m_IconRT[index1][index2].anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart[index1][index2], this.bezierCenter[index1][index2], this.bezierCenter2[index1][index2], this.bezierEnd[index1][index2], 1f / this.mEndTime[index1][index2], this.Timer[index1][index2] - this.TimeParameters1 * (float) index2);
              if ((double) this.Timer[index1][index2] > (double) this.mEndTime[index1][index2] + (double) this.TimeParameters1 * (double) index2)
              {
                this.mMoveKind[index1][index2] = (byte) 0;
                this.HideIcon(index1, index2);
              }
            }
          }
          else if (this.mMoveKind[index1][index2] != (byte) 0 && (double) this.Timer[index1][index2] > (double) this.TimeParameters1 * (double) index2)
            ((Component) this.EffectIcon[index1][index2]).gameObject.SetActive(true);
        }
        else if (this.mKindEnd[index1][index2] == (byte) 6 || this.mKindEnd[index1][index2] == (byte) 23 || this.mKindEnd[index1][index2] == (byte) 25 || this.mKindEnd[index1][index2] == (byte) 29)
        {
          if (((Component) this.m_Item[index1][index2 - 7]).gameObject.activeSelf)
          {
            if (this.mMoveKind[index1][index2] == (byte) 2)
            {
              this.m_ItemRT[index1][index2 - 7].anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart[index1][index2], this.bezierCenter[index1][index2], this.bezierCenter2[index1][index2], this.bezierEnd[index1][index2], 1f / this.mEndTime[index1][index2], this.Timer[index1][index2] - this.TimeParameters1 * (float) (this.tmpKindLineNum[index1] + (index2 - 7)));
              if ((double) this.Timer[index1][index2] > (double) this.mEndTime[index1][index2] + (double) this.TimeParameters1 * (double) (this.tmpKindLineNum[index1] + (index2 - 7)))
              {
                this.mMoveKind[index1][index2] = (byte) 0;
                this.HideIcon(index1, index2 - 7, true);
              }
            }
          }
          else if (this.mMoveKind[index1][index2] != (byte) 0 && (double) this.Timer[index1][index2] > (double) this.TimeParameters1 * (double) (this.tmpKindLineNum[index1] + (index2 - 7)))
            ((Component) this.m_Item[index1][index2 - 7]).gameObject.SetActive(true);
        }
        else if (this.mKindEnd[index1][index2] == (byte) 7 || this.mKindEnd[index1][index2] == (byte) 26)
        {
          if (((Component) this.m_Item_L[index1][index2 - 7]).gameObject.activeSelf)
          {
            if (this.mMoveKind[index1][index2] == (byte) 2)
            {
              this.m_Item_LRT[index1][index2 - 7].anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart[index1][index2], this.bezierCenter[index1][index2], this.bezierCenter2[index1][index2], this.bezierEnd[index1][index2], 1f / this.mEndTime[index1][index2], this.Timer[index1][index2] - this.TimeParameters1 * (float) (this.tmpKindLineNum[index1] + (index2 - 7)));
              if ((double) this.Timer[index1][index2] > (double) this.mEndTime[index1][index2] + (double) this.TimeParameters1 * (double) (this.tmpKindLineNum[index1] + (index2 - 7)))
              {
                this.mMoveKind[index1][index2] = (byte) 0;
                this.HideIcon(index1, index2 - 7, true, true);
              }
            }
          }
          else if (this.mMoveKind[index1][index2] != (byte) 0 && (double) this.Timer[index1][index2] > (double) this.TimeParameters1 * (double) (this.tmpKindLineNum[index1] + (index2 - 7)))
            ((Component) this.m_Item_L[index1][index2 - 7]).gameObject.SetActive(true);
        }
        if (this.m_Icon[index1][index2])
          this.UpdateRunIcon(index1, index2);
      }
    }
  }

  public void UpdateRunIcon(int i, int j)
  {
    this.ScaleParameters = 2f;
    switch (this.mKindEnd[i][j])
    {
      case 1:
        this.m_IconT = this.m_PowerImageT;
        break;
      case 2:
        this.m_IconT = this.m_DiamondIconT;
        break;
      case 3:
      case 23:
        this.m_IconT = this.m_MoraleIconT;
        break;
      case 4:
        this.m_IconT = this.m_HeadImageT;
        this.ScaleParameters = 1f;
        break;
      case 5:
        this.m_IconT = this.m_HeadImageT;
        this.ScaleParameters = 1f;
        break;
      case 6:
        this.m_IconT = this.m_FuncButtonT[1];
        break;
      case 8:
        this.m_IconT = this.m_FuncButtonT[0];
        break;
      case 10:
        this.m_IconT = this.m_FuncButtonT[5];
        break;
      case 11:
      case 22:
        this.m_IconT = this.mUITransform;
        break;
      case 12:
        this.m_IconT = this.mUIGiftKeyValueform;
        break;
      case 13:
        this.m_IconT = this.mUIGiftform;
        break;
      case 15:
        this.m_IconT = this.m_VipIconT;
        break;
      case 16:
      case 17:
      case 18:
      case 19:
      case 20:
        this.m_IconT = this.m_ResourceIconT[(int) this.mKindEnd[i][j] - 16];
        break;
      case 27:
        if ((Object) this.mParticleEffect[i] != (Object) null)
        {
          ParticleManager.Instance.DeSpawn(this.mParticleEffect[i]);
          this.mParticleEffect[i] = (GameObject) null;
        }
        this.tmpKindEndNum[i][j] = (byte) 0;
        this.m_Icon[i][j] = false;
        this.mKindEnd[i][j] = (byte) 0;
        --this.mCount[i];
        if (this.mCount[i] == 0)
        {
          this.m_ItmeTransform[i].gameObject.SetActive(false);
          --this.mIteCount;
          if (this.mIteCount == 0)
            ((Component) this.m_RectTransform).gameObject.SetActive(false);
        }
        this.GUIM.UpdateUI(EGUIWindow.UI_CastleStrengthen, 2);
        break;
      default:
        this.tmpKindEndNum[i][j] = (byte) 0;
        this.m_Icon[i][j] = false;
        this.mKindEnd[i][j] = (byte) 0;
        --this.mCount[i];
        if (this.mCount[i] == 0)
        {
          this.m_ItmeTransform[i].gameObject.SetActive(false);
          --this.mIteCount;
          if (this.mIteCount == 0)
          {
            ((Component) this.m_RectTransform).gameObject.SetActive(false);
            break;
          }
          break;
        }
        break;
    }
    if ((Object) this.m_IconT != (Object) null && !this.m_IconT.gameObject.activeSelf)
    {
      this.tmpKindEndNum[i][j] = (byte) 0;
      this.m_Icon[i][j] = false;
      this.mKindEnd[i][j] = (byte) 0;
      --this.mCount[i];
      if (this.mCount[i] == 0)
      {
        this.m_ItmeTransform[i].gameObject.SetActive(false);
        --this.mIteCount;
        if (this.mIteCount == 0)
          ((Component) this.m_RectTransform).gameObject.SetActive(false);
      }
    }
    if (!((Object) this.m_IconT != (Object) null) || this.tmpKindEndNum[i][j] <= (byte) 0)
      return;
    if ((double) this.Timer[i][j] < 0.075000002980232239)
    {
      if (GUIManager.Instance.IsArabic && (Object) this.m_IconT == (Object) this.mUIGiftKeyValueform)
        this.m_IconT.localScale = new Vector3((float) -(1.0 + (double) this.Timer[i][j] * (double) this.ScaleParameters), (float) (1.0 + (double) this.Timer[i][j] * (double) this.ScaleParameters), (float) (1.0 + (double) this.Timer[i][j] * (double) this.ScaleParameters));
      else
        this.m_IconT.localScale = new Vector3((float) (1.0 + (double) this.Timer[i][j] * (double) this.ScaleParameters), (float) (1.0 + (double) this.Timer[i][j] * (double) this.ScaleParameters), (float) (1.0 + (double) this.Timer[i][j] * (double) this.ScaleParameters));
    }
    else if ((double) this.Timer[i][j] < 0.15000000596046448)
    {
      if (GUIManager.Instance.IsArabic && (Object) this.m_IconT == (Object) this.mUIGiftKeyValueform)
        this.m_IconT.localScale = new Vector3((float) -(1.1499999761581421 - (double) this.Timer[i][j] * (double) this.ScaleParameters), (float) (1.1499999761581421 - (double) this.Timer[i][j] * (double) this.ScaleParameters), (float) (1.1499999761581421 - (double) this.Timer[i][j] * (double) this.ScaleParameters));
      else
        this.m_IconT.localScale = new Vector3((float) (1.1499999761581421 - (double) this.Timer[i][j] * (double) this.ScaleParameters), (float) (1.1499999761581421 - (double) this.Timer[i][j] * (double) this.ScaleParameters), (float) (1.1499999761581421 - (double) this.Timer[i][j] * (double) this.ScaleParameters));
    }
    else
    {
      this.m_IconT.localScale = !((Object) this.m_IconT == (Object) this.mUIGiftKeyValueform) || !GUIManager.Instance.IsArabic ? new Vector3(1f, 1f, 1f) : new Vector3(-1f, 1f, 1f);
      this.Timer[i][j] = 0.0f;
      --this.tmpKindEndNum[i][j];
      if (this.tmpKindEndNum[i][j] != (byte) 0)
        return;
      this.m_Icon[i][j] = false;
      this.mKindEnd[i][j] = (byte) 0;
      --this.mCount[i];
      if (this.mCount[i] != 0)
        return;
      this.m_ItmeTransform[i].gameObject.SetActive(false);
      --this.mIteCount;
      if (this.mIteCount != 0)
        return;
      ((Component) this.m_RectTransform).gameObject.SetActive(false);
    }
  }

  public void Refresh_FontTexture()
  {
    for (int index1 = 0; index1 < 5; ++index1)
    {
      for (int index2 = 0; index2 < 3; ++index2)
      {
        if (this.m_Item[index1] != null && (Object) this.m_Item[index1][index2] != (Object) null && ((Behaviour) this.m_Item[index1][index2]).enabled)
          this.m_Item[index1][index2].Refresh_FontTexture();
      }
    }
  }
}
