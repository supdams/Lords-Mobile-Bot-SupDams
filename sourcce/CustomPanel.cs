// Decompiled with JetBrains decompiler
// Type: CustomPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class CustomPanel : 
  MonoBehaviour,
  IUpDateScrollPanel,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private Transform baseTransform;
  private Transform TmpT;
  private Transform Tmp_PT;
  private RectTransform tmpRC;
  private DataManager DM;
  private GUIManager GUIM;
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private UIText tmpText;
  public UIText tmpText_Info;
  public UIText[][] Text_Title = new UIText[16][];
  public UIText[][] Text_TextStr = new UIText[16][];
  public UIText[][] Text_LeftAlign = new UIText[16][];
  public UIText[][] Text_Resources = new UIText[16][];
  public UIText[] Text_Info = new UIText[16];
  public UIText[] Text_End = new UIText[16];
  public UIText[] Text_Rank = new UIText[16];
  public UIText Text_NpcItem;
  public UIText Text_PetName;
  public UIText Text_PetSkill;
  public UIText Text_PetSkillEffect;
  private Image tmpImg;
  private Image ImgShowMain;
  private Image ImgShowMain_C;
  private Image ImgHero;
  private Image ImgHeroF;
  private Image ImgNpcItem;
  private Image[] Img_Icon = new Image[16];
  private Image[] Img_BG = new Image[16];
  private Image[] Img_TitleBG = new Image[16];
  private Image[] Img_TitleBG2 = new Image[16];
  private Sprite[] mSprite = new Sprite[9];
  private UIButtonHint[] m_ItemHint = new UIButtonHint[16];
  private ScrollPanel mScrollPanel;
  private string abName = "UI/CustomPanel";
  private int abKey;
  private Door door;
  private List<float> tmplist = new List<float>();
  private List<CustomPanel_Ptype> tmplistIdx = new List<CustomPanel_Ptype>();
  private List<string> mListItemStr1 = new List<string>();
  private List<string> mListItemStr2 = new List<string>();
  private List<byte> mListItemHint = new List<byte>();
  private int mKindCustomPanel;
  private ushort mCustomPanel_LV;
  private Hero tmpHero;
  private StringBuilder tmpString = new StringBuilder();
  private StringBuilder tmpString2 = new StringBuilder();
  private ushort[] mHeroID = new ushort[5];
  private byte[] mHeroRank = new byte[5];
  private byte[] mHeroStar = new byte[5];
  private uint[] mRes = new uint[5];
  private CurHeroData mHeroData;
  private StageManager SDM;
  private CorpsStage mCS;
  private CorpsStageBattle mCSB;
  private int HEROCount = 5;
  private bool bLeaderHero;
  private float ShowTime;
  private float ShowTime_C;
  public ushort MainHeroID;
  public int DataIdx;
  public CombatReport Report;
  public int mWT_StrengthenCount;
  public ushort[] mEffectID = new ushort[5];
  public uint InfoID;
  public byte[] mWT_Troops = new byte[16];
  public byte[] mWT_Traps = new byte[12];
  private GameObject[] mHead = new GameObject[5];
  private int[] mAssetKey = new int[5];
  private int ScrollPanelCount;
  public ushort RewardID;
  public IUIButtonDownUpHandler UpDownHandle;
  private UIButtonHint tmpbtnHint;
  private UIHIBtn Hbtn_Pet;
  private CString Cstr_SkillEffect;
  public float CurrentPanelHeight;
  private bool mCustomH;
  private bool mOpen;
  private float mHeight;

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    this.TmpT = item.GetComponent<Transform>().parent.GetChild(panelObjectIdx);
    if (this.tmplistIdx.Count <= 0 || this.tmplistIdx.Count < dataIdx)
      return;
    if (this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 != 0)
      this.TmpT.GetChild(this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 - 1).gameObject.SetActive(false);
    switch (this.tmplistIdx[dataIdx])
    {
      case CustomPanel_Ptype.P1_Title:
        this.Tmp_PT = this.TmpT.GetChild(0);
        this.Tmp_PT.gameObject.SetActive(true);
        this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 1;
        this.Text_Title[panelObjectIdx][0] = this.Tmp_PT.GetChild(1).GetComponent<UIText>();
        this.Text_Title[panelObjectIdx][0].text = this.mListItemStr1[dataIdx];
        this.Text_Title[panelObjectIdx][1] = this.Tmp_PT.GetChild(2).GetComponent<UIText>();
        this.Text_Title[panelObjectIdx][1].text = this.mListItemStr2[dataIdx];
        this.Img_TitleBG[panelObjectIdx] = this.Tmp_PT.GetChild(3).GetComponent<Image>();
        this.Img_TitleBG2[panelObjectIdx] = this.Tmp_PT.GetChild(4).GetComponent<Image>();
        this.tmpbtnHint = this.Tmp_PT.GetChild(3).GetComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
        this.tmpbtnHint.DelayTime = 0.2f;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 2;
        if (this.mListItemHint[dataIdx] >= (byte) 254)
        {
          ((Component) this.Img_TitleBG[panelObjectIdx]).gameObject.SetActive(true);
          ((Component) this.Img_TitleBG2[panelObjectIdx]).gameObject.SetActive(true);
          if (this.mListItemHint[dataIdx] == byte.MaxValue)
          {
            this.tmpbtnHint.Parm2 = (byte) 0;
            this.Img_TitleBG[panelObjectIdx].sprite = this.mSprite[7];
            this.Img_TitleBG2[panelObjectIdx].sprite = this.mSprite[7];
          }
          else
          {
            this.tmpbtnHint.Parm2 = (byte) 1;
            this.Img_TitleBG[panelObjectIdx].sprite = this.mSprite[8];
            this.Img_TitleBG2[panelObjectIdx].sprite = this.mSprite[8];
          }
          if ((double) this.Text_Title[panelObjectIdx][0].preferredWidth + 1.0 > 225.0)
          {
            ((Graphic) this.Img_TitleBG[panelObjectIdx]).rectTransform.sizeDelta = new Vector2(260f, ((Graphic) this.Img_TitleBG[panelObjectIdx]).rectTransform.sizeDelta.y);
            ((Graphic) this.Img_TitleBG2[panelObjectIdx]).rectTransform.anchoredPosition = new Vector2(234f, ((Graphic) this.Img_TitleBG2[panelObjectIdx]).rectTransform.anchoredPosition.y);
            break;
          }
          ((Graphic) this.Img_TitleBG[panelObjectIdx]).rectTransform.sizeDelta = new Vector2(36f + this.Text_Title[panelObjectIdx][0].preferredWidth, ((Graphic) this.Img_TitleBG[panelObjectIdx]).rectTransform.sizeDelta.y);
          ((Graphic) this.Img_TitleBG2[panelObjectIdx]).rectTransform.anchoredPosition = new Vector2(10f + this.Text_Title[panelObjectIdx][0].preferredWidth, ((Graphic) this.Img_TitleBG2[panelObjectIdx]).rectTransform.anchoredPosition.y);
          break;
        }
        ((Component) this.Img_TitleBG[panelObjectIdx]).gameObject.SetActive(false);
        ((Component) this.Img_TitleBG2[panelObjectIdx]).gameObject.SetActive(false);
        break;
      case CustomPanel_Ptype.P2_Text:
        this.Tmp_PT = this.TmpT.GetChild(1);
        this.Tmp_PT.gameObject.SetActive(true);
        this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 2;
        this.Text_TextStr[panelObjectIdx][0] = this.Tmp_PT.GetChild(0).GetComponent<UIText>();
        this.Text_TextStr[panelObjectIdx][0].text = this.mListItemStr1[dataIdx];
        this.Text_TextStr[panelObjectIdx][0].SetAllDirty();
        this.Text_TextStr[panelObjectIdx][0].cachedTextGeneratorForLayout.Invalidate();
        this.Text_TextStr[panelObjectIdx][1] = this.Tmp_PT.GetChild(1).GetComponent<UIText>();
        this.Text_TextStr[panelObjectIdx][1].text = this.mListItemStr2[dataIdx];
        this.Img_BG[panelObjectIdx] = this.Tmp_PT.GetChild(2).GetComponent<Image>();
        this.tmpbtnHint = this.Tmp_PT.GetChild(2).GetComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
        this.tmpbtnHint.DelayTime = 0.2f;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 1;
        this.tmpbtnHint.Parm2 = (byte) ((uint) this.mListItemHint[dataIdx] - 1U);
        this.Img_Icon[panelObjectIdx] = this.Tmp_PT.GetChild(2).GetChild(0).GetComponent<Image>();
        this.Text_Rank[panelObjectIdx] = this.Tmp_PT.GetChild(2).GetChild(1).GetComponent<UIText>();
        if (this.mListItemHint[dataIdx] > (byte) 0)
        {
          byte index = (byte) (((int) this.mListItemHint[dataIdx] - 1) / 4);
          ((Component) this.Img_BG[panelObjectIdx]).gameObject.SetActive(true);
          if ((int) index < this.mSprite.Length)
          {
            this.Img_Icon[panelObjectIdx].sprite = this.mSprite[(int) index];
            this.Text_Rank[panelObjectIdx].text = (((int) this.mListItemHint[dataIdx] - 1) % 4 + 1).ToString();
          }
          else
            this.Text_Rank[panelObjectIdx].text = string.Empty;
          if ((double) this.Text_TextStr[panelObjectIdx][0].preferredWidth < 217.0)
          {
            ((Graphic) this.Img_BG[panelObjectIdx]).rectTransform.sizeDelta = new Vector2(this.Text_TextStr[panelObjectIdx][0].preferredWidth + 35f, ((Graphic) this.Img_BG[panelObjectIdx]).rectTransform.sizeDelta.y);
            break;
          }
          ((Graphic) this.Img_BG[panelObjectIdx]).rectTransform.sizeDelta = new Vector2(250f, ((Graphic) this.Img_BG[panelObjectIdx]).rectTransform.sizeDelta.y);
          break;
        }
        ((Component) this.Img_BG[panelObjectIdx]).gameObject.SetActive(false);
        break;
      case CustomPanel_Ptype.P3_Hero:
        this.Tmp_PT = this.TmpT.GetChild(2);
        this.Tmp_PT.gameObject.SetActive(true);
        this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 3;
        if (this.mKindCustomPanel != 10)
        {
          if (this.mKindCustomPanel == 5)
            this.MainHeroID = this.DM.MainHero;
          else if (this.mKindCustomPanel == 0)
            this.MainHeroID = this.DM.GetLeaderID();
          else if (this.DM.m_WT_WithSupremeLeader != (byte) 0)
            this.MainHeroID = this.mHeroID[0];
        }
        else
          this.MainHeroID = this.mHeroID[0];
        for (int index = 0; index < this.HEROCount; ++index)
        {
          this.Tmp_PT.GetChild(index).gameObject.SetActive(true);
          this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.mHeroID[index]);
          this.tmpImg = this.Tmp_PT.GetChild(index).GetChild(0).GetComponent<Image>();
          this.tmpImg.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
          this.ImgHero = this.Tmp_PT.GetChild(index).GetChild(1).GetComponent<Image>();
          this.ImgHeroF = this.Tmp_PT.GetChild(index).GetChild(2).GetComponent<Image>();
          this.tmpString.Length = 0;
          this.tmpString2.Length = 0;
          if (this.mCustomPanel_LV < (ushort) 23 && this.mKindCustomPanel != 5 || this.mKindCustomPanel == 5 && this.mCustomPanel_LV < (ushort) 8)
          {
            this.tmpString.AppendFormat("hf00{0}", (object) 1);
          }
          else
          {
            switch (this.mKindCustomPanel)
            {
              case 1:
              case 2:
              case 3:
              case 5:
              case 10:
              case 11:
              case 12:
                this.tmpString.AppendFormat("hf00{0}", (object) this.mHeroStar[index]);
                this.tmpString2.AppendFormat("hf10{0}", (object) this.mHeroRank[index]);
                break;
              default:
                this.mHeroData = this.DM.curHeroData[(uint) this.mHeroID[index]];
                this.tmpString.AppendFormat("hf00{0}", (object) this.mHeroData.Star);
                this.tmpString2.AppendFormat("hf10{0}", (object) this.mHeroData.Enhance);
                break;
            }
          }
          this.ImgHero.sprite = this.GUIM.LoadFrameSprite(this.tmpString.ToString());
          this.ImgHeroF.sprite = this.GUIM.LoadFrameSprite(this.tmpString2.ToString());
          if (this.mCustomPanel_LV >= (ushort) 23 && this.mKindCustomPanel != 5 || this.mKindCustomPanel == 5 && this.mCustomPanel_LV >= (ushort) 8)
            ((Component) this.ImgHeroF).gameObject.SetActive(true);
          if (index == 0)
          {
            if ((int) this.MainHeroID == (int) this.mHeroID[index])
            {
              this.tmpImg = this.Tmp_PT.GetChild(index).GetChild(3).GetComponent<Image>();
              ((Component) this.tmpImg).gameObject.SetActive(true);
              this.tmpImg = this.Tmp_PT.GetChild(index).GetChild(4).GetComponent<Image>();
              ((Component) this.tmpImg).gameObject.SetActive(true);
              this.ImgShowMain = this.tmpImg;
              this.bLeaderHero = true;
            }
            else
            {
              this.tmpImg = this.Tmp_PT.GetChild(index).GetChild(3).GetComponent<Image>();
              ((Component) this.tmpImg).gameObject.SetActive(false);
              this.tmpImg = this.Tmp_PT.GetChild(index).GetChild(4).GetComponent<Image>();
              ((Component) this.tmpImg).gameObject.SetActive(false);
              this.bLeaderHero = false;
            }
          }
        }
        if (this.HEROCount >= 5)
          break;
        for (int heroCount = this.HEROCount; heroCount < 5; ++heroCount)
        {
          this.TmpT = this.Tmp_PT.GetChild(heroCount);
          this.TmpT.gameObject.SetActive(false);
        }
        break;
      case CustomPanel_Ptype.P4_Resources:
        this.Tmp_PT = this.TmpT.GetChild(3);
        this.Tmp_PT.gameObject.SetActive(true);
        this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 4;
        for (int index = 0; index < 5; ++index)
        {
          this.Text_Resources[panelObjectIdx][index] = this.Tmp_PT.GetChild(5 + index).GetComponent<UIText>();
          this.tmpString.Length = 0;
          if (this.mRes[index] != 0U)
          {
            GameConstants.FormatResourceValue(this.tmpString, this.mRes[index]);
            this.Text_Resources[panelObjectIdx][index].text = this.tmpString.ToString();
          }
          else
            this.Text_Resources[panelObjectIdx][index].text = "-";
        }
        if (this.mKindCustomPanel == 5 && this.mCustomPanel_LV < (ushort) 2)
        {
          this.Tmp_PT.GetChild(4).gameObject.SetActive(false);
          this.Tmp_PT.GetChild(9).gameObject.SetActive(false);
          break;
        }
        this.Tmp_PT.GetChild(4).gameObject.SetActive(true);
        this.Tmp_PT.GetChild(9).gameObject.SetActive(true);
        break;
      case CustomPanel_Ptype.P5_Text_Info:
        this.Tmp_PT = this.TmpT.GetChild(4);
        this.Tmp_PT.gameObject.SetActive(true);
        this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 5;
        this.Text_Info[panelObjectIdx] = this.Tmp_PT.GetChild(0).GetComponent<UIText>();
        this.Text_Info[panelObjectIdx].text = this.mListItemStr1[dataIdx];
        this.tmpRC = this.TmpT.GetComponent<RectTransform>();
        float y = this.tmpRC.sizeDelta.y - 10f;
        this.tmpRC = this.Tmp_PT.GetChild(0).GetComponent<RectTransform>();
        this.tmpRC.sizeDelta = new Vector2(this.tmpRC.sizeDelta.x, y);
        break;
      case CustomPanel_Ptype.P_End:
        this.Tmp_PT = this.TmpT.GetChild(5);
        this.Tmp_PT.gameObject.SetActive(true);
        this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 6;
        this.Text_End[panelObjectIdx] = this.Tmp_PT.GetChild(1).GetComponent<UIText>();
        this.Text_End[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(7641U);
        break;
      case CustomPanel_Ptype.P2_Text_LeftAlign:
        this.Tmp_PT = this.TmpT.GetChild(1);
        this.Tmp_PT.gameObject.SetActive(true);
        this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 2;
        this.Text_LeftAlign[panelObjectIdx][0] = this.Tmp_PT.GetChild(0).GetComponent<UIText>();
        this.Text_LeftAlign[panelObjectIdx][0].text = this.mListItemStr1[dataIdx];
        this.Text_LeftAlign[panelObjectIdx][0].alignment = TextAnchor.MiddleLeft;
        this.Text_LeftAlign[panelObjectIdx][1] = this.Tmp_PT.GetChild(1).GetComponent<UIText>();
        this.Text_LeftAlign[panelObjectIdx][1].text = this.mListItemStr2[dataIdx];
        break;
      case CustomPanel_Ptype.P3_Hero_C:
        this.Tmp_PT = this.TmpT.GetChild(2);
        this.Tmp_PT.gameObject.SetActive(true);
        this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 3;
        this.HEROCount = (int) this.DM.CantonmentHeroCount;
        for (int index = 0; index < this.HEROCount; ++index)
        {
          this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.DM.CantonmentHero[index].HeroID);
          this.tmpImg = this.Tmp_PT.GetChild(index).GetChild(0).GetComponent<Image>();
          this.tmpImg.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
          this.ImgHero = this.Tmp_PT.GetChild(index).GetChild(1).GetComponent<Image>();
          this.ImgHeroF = this.Tmp_PT.GetChild(index).GetChild(2).GetComponent<Image>();
          this.tmpString.Length = 0;
          this.tmpString2.Length = 0;
          if (this.mCustomPanel_LV < (ushort) 23 && this.mKindCustomPanel != 5 || this.mKindCustomPanel == 5 && this.mCustomPanel_LV < (ushort) 8)
          {
            this.tmpString.AppendFormat("hf00{0}", (object) 1);
          }
          else
          {
            this.tmpString.AppendFormat("hf00{0}", (object) this.DM.CantonmentHero[index].Star);
            this.tmpString2.AppendFormat("hf10{0}", (object) this.DM.CantonmentHero[index].Rank);
          }
          this.ImgHero.sprite = this.GUIM.LoadFrameSprite(this.tmpString.ToString());
          this.ImgHeroF.sprite = this.GUIM.LoadFrameSprite(this.tmpString2.ToString());
          if (this.mCustomPanel_LV >= (ushort) 23 && this.mKindCustomPanel != 5 || this.mKindCustomPanel == 5 && this.mCustomPanel_LV >= (ushort) 8)
            ((Component) this.ImgHeroF).gameObject.SetActive(true);
          if (index == 0 && (int) this.DM.CantonmentMainHero == (int) this.DM.CantonmentHero[index].HeroID)
          {
            this.tmpImg = this.Tmp_PT.GetChild(index).GetChild(3).GetComponent<Image>();
            ((Component) this.tmpImg).gameObject.SetActive(true);
            this.tmpImg = this.Tmp_PT.GetChild(index).GetChild(4).GetComponent<Image>();
            ((Component) this.tmpImg).gameObject.SetActive(true);
            this.ImgShowMain_C = this.tmpImg;
          }
          else if ((UnityEngine.Object) this.ImgShowMain_C != (UnityEngine.Object) null)
            ((Component) this.ImgShowMain_C).gameObject.SetActive(false);
        }
        if (this.HEROCount >= 5)
          break;
        for (int heroCount = this.HEROCount; heroCount < 5; ++heroCount)
        {
          this.TmpT = this.Tmp_PT.GetChild(heroCount);
          this.TmpT.gameObject.SetActive(false);
        }
        break;
      case CustomPanel_Ptype.P6_Item:
        this.Tmp_PT = this.TmpT.GetChild(6);
        this.Tmp_PT.gameObject.SetActive(true);
        this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 7;
        DataManager.Instance.NPCPrize.GetRecordByKey(this.RewardID);
        this.ImgNpcItem = this.Tmp_PT.GetChild(0).GetComponent<Image>();
        UnityEngine.Object.Destroy((UnityEngine.Object) ((Component) this.ImgNpcItem).GetComponent<IgnoreRaycast>());
        UIButton component1 = this.Tmp_PT.GetChild(0).GetChild(0).GetComponent<UIButton>();
        UIButtonHint uiButtonHint = ((Component) component1).gameObject.AddComponent<UIButtonHint>();
        uiButtonHint.m_eHint = EUIButtonHint.CountDown;
        uiButtonHint.Parm1 = (ushort) 12030;
        uiButtonHint.DelayTime = 0.2f;
        uiButtonHint.m_DownUpHandler = this.UpDownHandle;
        NPCPrizeData recordByKey1 = this.DM.NPCPrize.GetRecordByKey(this.RewardID);
        this.ImgNpcItem.sprite = this.GUIM.m_LeadItemIconSpriteAsset.LoadSprite(recordByKey1.PicNo);
        ((MaskableGraphic) this.ImgNpcItem).material = this.GUIM.m_LeadItemIconSpriteAsset.GetMaterial();
        component1.image.sprite = this.GUIM.m_LeadItemIconSpriteAsset.LoadSprite(recordByKey1.PicNo);
        ((MaskableGraphic) component1.image).material = this.GUIM.m_LeadItemIconSpriteAsset.GetMaterial();
        this.Text_NpcItem = this.Tmp_PT.GetChild(1).GetComponent<UIText>();
        this.Text_NpcItem.text = this.DM.mStringTable.GetStringByID((uint) recordByKey1.Element);
        RectTransform component2 = ((Component) component1).transform.GetComponent<RectTransform>();
        component2.sizeDelta = new Vector2(100f + this.Text_NpcItem.preferredWidth, component2.sizeDelta.y);
        break;
      case CustomPanel_Ptype.P3_Hero_Npc:
        this.Tmp_PT = this.TmpT.GetChild(2);
        this.Tmp_PT.gameObject.SetActive(true);
        this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 3;
        for (int index = 0; index < 5; ++index)
        {
          if ((UnityEngine.Object) this.mHead[index] != (UnityEngine.Object) null)
          {
            UnityEngine.Object.Destroy((UnityEngine.Object) this.mHead[index]);
            this.mHead[index] = (GameObject) null;
          }
        }
        for (int index = 0; index < this.HEROCount; ++index)
        {
          this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.mHeroID[index]);
          this.tmpImg = this.Tmp_PT.GetChild(index).GetChild(0).GetComponent<Image>();
          ((Graphic) this.tmpImg).rectTransform.pivot = new Vector2(0.5f, 0.5f);
          if (this.tmpHero.Graph < (ushort) 50000)
          {
            this.tmpImg.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
          }
          else
          {
            CString Name = StringManager.Instance.StaticString1024();
            Name.ClearString();
            Name.IntToFormat((long) this.tmpHero.Graph);
            Name.AppendFormat("UI/MapNPCHead_{0}");
            if (AssetManager.GetAssetBundleDownload(Name, AssetPath.UI, AssetType.NPCHead, this.tmpHero.Graph))
            {
              AssetBundle assetBundle = AssetManager.GetAssetBundle(Name, out this.mAssetKey[index]);
              if ((UnityEngine.Object) assetBundle != (UnityEngine.Object) null && (UnityEngine.Object) this.mHead[index] == (UnityEngine.Object) null)
                this.mHead[index] = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
              if ((UnityEngine.Object) this.mHead[index] != (UnityEngine.Object) null)
              {
                this.mHead[index].transform.SetParent(((Component) this.tmpImg).transform);
                this.mHead[index].gameObject.SetActive(true);
                this.mHead[index].transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, 0.0f);
                this.mHead[index].transform.GetComponent<RectTransform>().anchorMax = new Vector2(1f, 1f);
                this.mHead[index].transform.GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, 0.0f);
                this.mHead[index].transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                this.mHead[index].transform.localScale = new Vector3(1f, 1f, 1f);
              }
            }
          }
          this.ImgHero = this.Tmp_PT.GetChild(index).GetChild(1).GetComponent<Image>();
          this.ImgHeroF = this.Tmp_PT.GetChild(index).GetChild(2).GetComponent<Image>();
          this.tmpString.Length = 0;
          this.tmpString2.Length = 0;
          if (this.mCustomPanel_LV < (ushort) 23 && this.mKindCustomPanel != 5 || this.mKindCustomPanel == 5 && this.mCustomPanel_LV < (ushort) 8)
          {
            this.tmpString.AppendFormat("hf00{0}", (object) 1);
          }
          else
          {
            this.tmpString.AppendFormat("hf00{0}", (object) this.mHeroStar[index]);
            this.tmpString2.AppendFormat("hf10{0}", (object) this.mHeroRank[index]);
          }
          this.ImgHero.sprite = this.GUIM.LoadFrameSprite(this.tmpString.ToString());
          this.ImgHeroF.sprite = this.GUIM.LoadFrameSprite(this.tmpString2.ToString());
          if (this.mCustomPanel_LV >= (ushort) 23 && this.mKindCustomPanel != 5 || this.mKindCustomPanel == 5 && this.mCustomPanel_LV >= (ushort) 8)
            ((Component) this.ImgHeroF).gameObject.SetActive(true);
          if (index == 0 && (int) this.DM.CantonmentMainHero == (int) this.DM.CantonmentHero[index].HeroID)
          {
            this.tmpImg = this.Tmp_PT.GetChild(index).GetChild(3).GetComponent<Image>();
            ((Component) this.tmpImg).gameObject.SetActive(true);
            this.tmpImg = this.Tmp_PT.GetChild(index).GetChild(4).GetComponent<Image>();
            ((Component) this.tmpImg).gameObject.SetActive(true);
            this.ImgShowMain_C = this.tmpImg;
          }
          else if ((UnityEngine.Object) this.ImgShowMain_C != (UnityEngine.Object) null)
            ((Component) this.ImgShowMain_C).gameObject.SetActive(false);
        }
        if (this.HEROCount >= 5)
          break;
        for (int heroCount = this.HEROCount; heroCount < 5; ++heroCount)
        {
          this.TmpT = this.Tmp_PT.GetChild(heroCount);
          this.TmpT.gameObject.SetActive(false);
        }
        break;
      case CustomPanel_Ptype.P_PetSkill:
        this.Tmp_PT = this.TmpT.GetChild(7);
        this.Tmp_PT.gameObject.SetActive(true);
        this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 7;
        this.Hbtn_Pet = this.Tmp_PT.GetChild(0).GetComponent<UIHIBtn>();
        this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_Pet).transform, eHeroOrItem.Pet, this.DM.m_WT_PetID, this.DM.m_WT_PetEnhance, (byte) 0);
        PetManager instance = PetManager.Instance;
        PetTbl recordByKey2 = instance.PetTable.GetRecordByKey(this.DM.m_WT_PetID);
        PetSkillTbl recordByKey3 = instance.PetSkillTable.GetRecordByKey(this.DM.m_WT_PetSkillID);
        this.Text_PetName = this.Tmp_PT.GetChild(1).GetComponent<UIText>();
        this.Text_PetName.text = this.DM.mStringTable.GetStringByID((uint) recordByKey2.Name);
        this.Text_PetSkill = this.Tmp_PT.GetChild(2).GetComponent<UIText>();
        this.tmpString.Length = 0;
        this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(268U), (object) this.DM.m_WT_PetSkillLv, (object) this.DM.mStringTable.GetStringByID((uint) recordByKey3.Name));
        this.Text_PetSkill.text = this.tmpString.ToString();
        this.Text_PetSkillEffect = this.Tmp_PT.GetChild(3).GetComponent<UIText>();
        this.Cstr_SkillEffect.ClearString();
        instance.FormatSkillContent(this.DM.m_WT_PetSkillID, this.DM.m_WT_PetSkillLv, this.Cstr_SkillEffect, (byte) 0);
        this.Text_PetSkillEffect.text = this.Cstr_SkillEffect.ToString();
        break;
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (sender.Parm1 == (ushort) 1)
    {
      GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 3, 277f, 20, (int) sender.Parm2, 0, new Vector2(70f, 0.0f));
    }
    else
    {
      if (sender.Parm1 != (ushort) 2)
        return;
      GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintArmy, (byte) 0, 0.0f, 0, (int) sender.Parm2, 0, Vector2.zero);
    }
  }

  public void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide(true);

  public ScrollPanel getScrollPanel() => this.mScrollPanel;

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  private void Awake()
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    Material material1 = this.door.LoadMaterial();
    AssetBundle assetBundle = AssetManager.GetAssetBundle(this.abName, out this.abKey);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return;
    GameObject gameObject = (GameObject) UnityEngine.Object.Instantiate(assetBundle.mainAsset);
    if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
    {
      AssetManager.UnloadAssetBundle(this.abKey);
    }
    else
    {
      this.SDM = DataManager.StageDataController;
      gameObject.transform.SetParent(this.transform, false);
      this.baseTransform = gameObject.transform;
      this.mSprite[0] = this.door.LoadSprite("UI_legion_icon_a");
      this.mSprite[1] = this.door.LoadSprite("UI_legion_icon_b");
      this.mSprite[2] = this.door.LoadSprite("UI_legion_icon_c");
      this.mSprite[3] = this.door.LoadSprite("UI_legion_icon_d");
      this.mSprite[4] = this.door.LoadSprite("UI_legion_icon_e");
      this.mSprite[5] = this.door.LoadSprite("UI_legion_icon_f");
      this.mSprite[6] = this.door.LoadSprite("UI_legion_icon_g");
      this.mSprite[7] = this.door.LoadSprite("UI_EO_icon_01");
      this.mSprite[8] = this.door.LoadSprite("UI_EO_icon_02");
      Material frameMaterial = this.GUIM.GetFrameMaterial();
      Material material2 = this.GUIM.m_IconSpriteAsset.GetMaterial();
      for (int index = 0; index < 16; ++index)
      {
        this.Text_Title[index] = new UIText[2];
        this.Text_TextStr[index] = new UIText[2];
        this.Text_LeftAlign[index] = new UIText[2];
        this.Text_Resources[index] = new UIText[5];
      }
      Transform child1 = this.baseTransform.GetChild(0);
      this.mScrollPanel = child1.GetComponent<ScrollPanel>();
      this.tmpImg = child1.GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_box_011");
      ((MaskableGraphic) this.tmpImg).material = material1;
      this.tmpImg = this.baseTransform.GetChild(1).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_box_011");
      ((MaskableGraphic) this.tmpImg).material = material1;
      Transform child2 = this.baseTransform.GetChild(1).GetChild(0);
      this.tmpImg = child2.GetChild(0).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_box_011");
      ((MaskableGraphic) this.tmpImg).material = material1;
      this.tmpText = child2.GetChild(1).GetComponent<UIText>();
      this.tmpText.font = this.TTFont;
      this.tmpText = child2.GetChild(2).GetComponent<UIText>();
      this.tmpText.font = this.TTFont;
      this.tmpImg = child2.GetChild(3).GetComponent<Image>();
      this.tmpImg.sprite = this.mSprite[7];
      ((MaskableGraphic) this.tmpImg).material = material1;
      this.tmpbtnHint = ((Component) this.tmpImg).gameObject.AddComponent<UIButtonHint>();
      this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
      this.tmpbtnHint.DelayTime = 0.2f;
      this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
      this.tmpbtnHint.Parm1 = (ushort) 2;
      this.tmpImg = child2.GetChild(4).GetComponent<Image>();
      this.tmpImg.sprite = this.mSprite[7];
      ((MaskableGraphic) this.tmpImg).material = material1;
      Transform child3 = this.baseTransform.GetChild(1).GetChild(1);
      this.tmpText = child3.GetChild(0).GetComponent<UIText>();
      this.tmpText.font = this.TTFont;
      this.tmpText = child3.GetChild(1).GetComponent<UIText>();
      this.tmpText.font = this.TTFont;
      this.tmpImg = child3.GetChild(2).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_box_011");
      ((MaskableGraphic) this.tmpImg).material = material1;
      this.tmpbtnHint = ((Component) this.tmpImg).gameObject.AddComponent<UIButtonHint>();
      this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
      this.tmpbtnHint.DelayTime = 0.2f;
      this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
      this.tmpbtnHint.Parm1 = (ushort) 1;
      this.tmpImg = child3.GetChild(2).GetChild(0).GetComponent<Image>();
      this.tmpImg.sprite = this.mSprite[0];
      ((MaskableGraphic) this.tmpImg).material = material1;
      this.tmpText = child3.GetChild(2).GetChild(1).GetComponent<UIText>();
      this.tmpText.font = this.TTFont;
      Transform child4 = this.baseTransform.GetChild(1).GetChild(2);
      this.tmpImg = child4.GetChild(0).GetChild(0).GetComponent<Image>();
      ((MaskableGraphic) this.tmpImg).material = material2;
      this.tmpRC = ((Component) this.tmpImg).GetComponent<RectTransform>();
      this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
      this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
      this.tmpRC.offsetMin = Vector2.zero;
      this.tmpRC.offsetMax = Vector2.zero;
      this.tmpImg = child4.GetChild(0).GetChild(1).GetComponent<Image>();
      this.tmpImg.sprite = this.GUIM.LoadFrameSprite("hf001");
      ((MaskableGraphic) this.tmpImg).material = frameMaterial;
      this.tmpRC = ((Component) this.tmpImg).GetComponent<RectTransform>();
      this.tmpRC.anchorMin = Vector2.zero;
      this.tmpRC.anchorMax = new Vector2(1f, 1f);
      this.tmpRC.offsetMin = Vector2.zero;
      this.tmpRC.offsetMax = Vector2.zero;
      this.tmpImg = child4.GetChild(0).GetChild(2).GetComponent<Image>();
      this.tmpImg.sprite = this.GUIM.LoadFrameSprite("hf001");
      ((MaskableGraphic) this.tmpImg).material = frameMaterial;
      this.tmpImg = child4.GetChild(0).GetChild(3).GetComponent<Image>();
      this.tmpImg.sprite = this.GUIM.LoadFrameSprite("UI_legion_icon_12");
      ((MaskableGraphic) this.tmpImg).material = frameMaterial;
      this.tmpImg = child4.GetChild(0).GetChild(4).GetComponent<Image>();
      this.tmpImg.sprite = this.GUIM.LoadFrameSprite("UI_legion_icon_13");
      ((MaskableGraphic) this.tmpImg).material = frameMaterial;
      for (int index = 1; index < 5; ++index)
      {
        this.tmpImg = child4.GetChild(index).GetChild(0).GetComponent<Image>();
        this.tmpRC = ((Component) this.tmpImg).GetComponent<RectTransform>();
        this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
        this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
        this.tmpRC.offsetMin = Vector2.zero;
        this.tmpRC.offsetMax = Vector2.zero;
        ((MaskableGraphic) this.tmpImg).material = material2;
        this.tmpImg = child4.GetChild(index).GetChild(1).GetComponent<Image>();
        this.tmpImg.sprite = this.GUIM.LoadFrameSprite("hf001");
        ((MaskableGraphic) this.tmpImg).material = frameMaterial;
        this.tmpRC = ((Component) this.tmpImg).GetComponent<RectTransform>();
        this.tmpRC.anchorMin = Vector2.zero;
        this.tmpRC.anchorMax = new Vector2(1f, 1f);
        this.tmpRC.offsetMin = Vector2.zero;
        this.tmpRC.offsetMax = Vector2.zero;
        this.tmpImg = child4.GetChild(index).GetChild(2).GetComponent<Image>();
        this.tmpImg.sprite = this.GUIM.LoadFrameSprite("hf001");
        ((MaskableGraphic) this.tmpImg).material = frameMaterial;
      }
      Transform child5 = this.baseTransform.GetChild(1).GetChild(3);
      this.tmpImg = child5.GetChild(0).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_res_food");
      ((MaskableGraphic) this.tmpImg).material = material1;
      this.tmpImg = child5.GetChild(1).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_res_stone");
      ((MaskableGraphic) this.tmpImg).material = material1;
      this.tmpImg = child5.GetChild(2).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_res_wood");
      ((MaskableGraphic) this.tmpImg).material = material1;
      this.tmpImg = child5.GetChild(3).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_res_iron");
      ((MaskableGraphic) this.tmpImg).material = material1;
      this.tmpImg = child5.GetChild(4).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_money_01");
      ((MaskableGraphic) this.tmpImg).material = material1;
      for (int index = 0; index < 5; ++index)
      {
        this.tmpText = child5.GetChild(5 + index).GetComponent<UIText>();
        this.tmpText.font = this.TTFont;
      }
      this.tmpText_Info = this.baseTransform.GetChild(1).GetChild(4).GetChild(0).GetComponent<UIText>();
      this.tmpText_Info.font = this.TTFont;
      Transform child6 = this.baseTransform.GetChild(1).GetChild(5);
      this.tmpImg = child6.GetChild(0).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_box_011");
      ((MaskableGraphic) this.tmpImg).material = material1;
      this.tmpText = child6.GetChild(1).GetComponent<UIText>();
      this.tmpText.font = this.TTFont;
      Transform child7 = this.baseTransform.GetChild(1).GetChild(6);
      this.tmpImg = child7.GetChild(0).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_box_011");
      ((MaskableGraphic) this.tmpImg).material = material1;
      this.tmpText = child7.GetChild(1).GetComponent<UIText>();
      this.tmpText.font = this.TTFont;
      Transform child8 = this.baseTransform.GetChild(1).GetChild(7);
      UIHIBtn component = child8.GetChild(0).GetComponent<UIHIBtn>();
      component.m_Handler = (IUIHIBtnClickHandler) this;
      this.GUIM.InitianHeroItemImg(((Component) component).transform, eHeroOrItem.Pet, (ushort) 0, (byte) 0, (byte) 0);
      this.tmpText = child8.GetChild(1).GetComponent<UIText>();
      this.tmpText.font = this.TTFont;
      this.tmpText = child8.GetChild(2).GetComponent<UIText>();
      this.tmpText.font = this.TTFont;
      this.tmpText = child8.GetChild(3).GetComponent<UIText>();
      this.tmpText.font = this.TTFont;
      this.Cstr_SkillEffect = StringManager.Instance.SpawnString(200);
    }
  }

  public void SetPVE_Data(ushort mIdx)
  {
    this.mCS = this.SDM.CorpsStageTable.GetRecordByKey(mIdx);
    this.mCSB = this.SDM.CorpsStageBattleTable.GetRecordByKey(mIdx);
    this.HEROCount = 0;
    this.mWT_StrengthenCount = 0;
    for (int index = 0; index < 5; ++index)
    {
      if (this.mCS.Heros[index].HeroID != (ushort) 0)
        ++this.HEROCount;
      if (this.mCSB.PropertiesInfo[index].Propertieskey != (ushort) 0)
      {
        this.mEffectID[index] = this.mCSB.PropertiesInfo[index].Propertieskey;
        ++this.mWT_StrengthenCount;
      }
    }
    this.InfoID = (uint) this.mCS.Info;
  }

  public void SetPanelData(
    List<int> _DataIdx,
    bool bCustomH = false,
    bool bOpen = true,
    int mLV = 0,
    int mKind = 0,
    float mHeight = 0)
  {
    if (mKind != 0)
      this.mKindCustomPanel = mKind;
    if (mLV != 0)
      this.mCustomPanel_LV = (ushort) mLV;
    this.CurrentPanelHeight = 0.0f;
    this.tmplist.Clear();
    this.tmplistIdx.Clear();
    this.mListItemStr1.Clear();
    this.mListItemStr2.Clear();
    this.mListItemHint.Clear();
    for (int index1 = 0; index1 < _DataIdx.Count; ++index1)
    {
      if (_DataIdx[index1] != 4)
      {
        this.tmplistIdx.Add(CustomPanel_Ptype.P1_Title);
        if (_DataIdx[index1] == 8 || _DataIdx[index1] == 26)
          this.mListItemHint.Add(byte.MaxValue);
        else if (_DataIdx[index1] == 7 || _DataIdx[index1] == 28)
          this.mListItemHint.Add((byte) 254);
        else
          this.mListItemHint.Add((byte) 0);
      }
      else
      {
        this.tmplistIdx.Add(CustomPanel_Ptype.P_End);
        this.tmplist.Add(38f);
        this.CurrentPanelHeight += 38f;
        this.mListItemHint.Add((byte) 0);
      }
      SoldierData recordByKey;
      switch (_DataIdx[index1])
      {
        case 1:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          if (this.mKindCustomPanel == 1 || this.mKindCustomPanel == 2 || this.mKindCustomPanel == 3)
            this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4018U));
          else if (this.mKindCustomPanel == 7 || this.mKindCustomPanel == 8)
            this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(3882U));
          else if (this.mKindCustomPanel == 11)
            this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9728U));
          else if (this.mKindCustomPanel == 12)
            this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9919U));
          this.tmpString.Length = 0;
          if (this.mCustomPanel_LV < (ushort) 13)
          {
            this.tmpString.Append(this.DM.mStringTable.GetStringByID(4010U));
            this.tmpString.Append(this.DM.mStringTable.GetStringByID(3931U));
          }
          else if (this.mCustomPanel_LV >= (ushort) 13 && this.mCustomPanel_LV < (ushort) 21)
          {
            this.tmpString.Append(this.DM.mStringTable.GetStringByID(4010U));
            GameConstants.FormatEstimateValue(this.tmpString, this.DM.m_WT_TotalForce);
          }
          else
          {
            this.tmpString.Append(this.DM.mStringTable.GetStringByID(4010U));
            this.tmpString.AppendFormat("{0:N0}", (object) this.DM.m_WT_TroopTotal);
          }
          this.mListItemStr2.Add(this.tmpString.ToString());
          int num1 = 0;
          uint num2 = 0;
          if (this.mCustomPanel_LV < (ushort) 15)
          {
            this.mListItemStr1.Add("-");
            this.mListItemStr2.Add("-");
            this.tmplist.Add(40f);
            this.CurrentPanelHeight += 40f;
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
            this.mListItemHint.Add((byte) 0);
            break;
          }
          if (this.mCustomPanel_LV >= (ushort) 15 && this.mCustomPanel_LV < (ushort) 17)
          {
            uint[] numArray = new uint[4];
            Array.Clear((Array) numArray, 0, numArray.Length);
            for (int index2 = 0; index2 < 16; ++index2)
            {
              if (((int) this.DM.m_WT_TrooFlag >> index2 & 1) == 1)
              {
                int index3 = index2 / 4;
                ++numArray[index3];
                if ((long) num2 < (long) index3)
                  num2 = (uint) index3;
              }
            }
            for (int index4 = 0; index4 < 4; ++index4)
            {
              if (numArray[index4] > 0U)
              {
                ++num1;
                this.tmpString.Length = 0;
                if (this.mCustomPanel_LV < (ushort) 15)
                  this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(3931U));
                else if (this.mCustomPanel_LV >= (ushort) 15)
                {
                  recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index4 * 4 + 1));
                  this.tmpString.Append(this.DM.mStringTable.GetStringByID((uint) (ushort) (3841U + (uint) recordByKey.SoldierKind)));
                  this.mListItemStr1.Add(this.tmpString.ToString());
                }
                if (this.mCustomPanel_LV < (ushort) 17)
                  this.mListItemStr2.Add(this.DM.mStringTable.GetStringByID(3931U));
                if ((long) num2 == (long) index4)
                {
                  this.tmplist.Add(40f);
                  this.CurrentPanelHeight += 40f;
                }
                else
                {
                  this.tmplist.Add(32f);
                  this.CurrentPanelHeight += 32f;
                }
                this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
                this.mListItemHint.Add((byte) 0);
              }
            }
            break;
          }
          for (int index5 = 0; index5 < 16; ++index5)
          {
            int index6 = 3 - index5 / 4 + index5 % 4 * 4;
            int InKey = 4 - index5 / 4 + index5 % 4 * 4;
            if (this.DM.m_WT_TroopData[index6] > 0U)
            {
              ++num1;
              num2 += this.DM.m_WT_TroopData[index6];
              this.tmpString.Length = 0;
              recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) InKey);
              this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
              if (this.mCustomPanel_LV >= (ushort) 17 && this.mCustomPanel_LV <= (ushort) 20)
              {
                this.tmpString.Length = 0;
                GameConstants.FormatEstimateValue(this.tmpString, this.DM.m_WT_TroopData[index6]);
                this.mListItemStr2.Add(this.tmpString.ToString());
              }
              else if (this.mCustomPanel_LV > (ushort) 20)
              {
                this.tmpString.Length = 0;
                this.tmpString.AppendFormat("{0:N0}", (object) this.DM.m_WT_TroopData[index6]);
                this.mListItemStr2.Add(this.tmpString.ToString());
              }
              if ((int) num2 == (int) this.DM.m_WT_TroopTotal)
              {
                this.tmplist.Add(40f);
                this.CurrentPanelHeight += 40f;
              }
              else
              {
                this.tmplist.Add(32f);
                this.CurrentPanelHeight += 32f;
              }
              this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
              this.mListItemHint.Add((byte) InKey);
            }
          }
          break;
        case 2:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          if (this.mKindCustomPanel == 5)
            this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5358U));
          else
            this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4019U));
          this.tmpString.Length = 0;
          if (this.mCustomPanel_LV < (ushort) 13 && this.mKindCustomPanel != 5)
          {
            this.tmpString.Append(this.DM.mStringTable.GetStringByID(4011U));
            this.tmpString.Append(this.DM.mStringTable.GetStringByID(3931U));
          }
          else
          {
            this.HEROCount = this.mKindCustomPanel != 5 ? (this.mKindCustomPanel == 1 || this.mKindCustomPanel == 2 || this.mKindCustomPanel == 3 || this.mKindCustomPanel == 12 || this.mKindCustomPanel == 11 ? (int) this.DM.m_WT_HeroNum : 0) : (int) this.DM.DefenseHeroCount;
            this.tmpString.Append(this.DM.mStringTable.GetStringByID(4011U));
            this.tmpString.Append(this.HEROCount);
          }
          this.mListItemStr2.Add(this.tmpString.ToString());
          if (this.mCustomPanel_LV >= (ushort) 19 || this.mKindCustomPanel == 5)
          {
            bool flag = true;
            if (this.mKindCustomPanel == 5)
            {
              if (this.mCustomPanel_LV < (ushort) 8)
              {
                flag = false;
              }
              else
              {
                for (int index7 = 0; index7 < this.HEROCount; ++index7)
                {
                  this.mHeroID[index7] = this.DM.DefenseHero[index7].HeroID;
                  this.mHeroRank[index7] = this.DM.DefenseHero[index7].Rank;
                  this.mHeroStar[index7] = this.DM.DefenseHero[index7].Star;
                }
              }
            }
            else
            {
              this.HEROCount = (int) this.DM.m_WT_HeroNum;
              for (int index8 = 0; index8 < (int) this.DM.m_WT_HeroNum; ++index8)
              {
                this.mHeroID[index8] = this.DM.m_WT_HeroID[index8];
                if (this.mCustomPanel_LV >= (ushort) 23)
                {
                  this.mHeroRank[index8] = this.DM.m_WT_HeroRank[index8].Rank;
                  this.mHeroStar[index8] = this.DM.m_WT_HeroRank[index8].Medal;
                }
                else
                {
                  this.mHeroRank[index8] = (byte) 1;
                  this.mHeroStar[index8] = (byte) 1;
                }
              }
            }
            if (this.HEROCount > 0 && flag)
            {
              this.mListItemStr1.Add("1");
              this.mListItemStr2.Add("1");
              this.tmplist.Add((float) sbyte.MaxValue);
              this.CurrentPanelHeight += (float) sbyte.MaxValue;
              this.tmplistIdx.Add(CustomPanel_Ptype.P3_Hero);
              this.mListItemHint.Add((byte) 0);
              break;
            }
            this.tmplist.Add(40f);
            this.CurrentPanelHeight += 40f;
            this.mListItemStr1.Add("-");
            this.mListItemStr2.Add("-");
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
            this.mListItemHint.Add((byte) 0);
            break;
          }
          break;
        case 3:
          this.tmplist.Add(38f);
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5357U));
          this.mListItemStr2.Add(string.Empty);
          this.CurrentPanelHeight += 38f;
          for (int index9 = 0; index9 < 5; ++index9)
            this.mRes[index9] = this.DM.ScoutResource[index9];
          this.tmplist.Add(93f);
          this.CurrentPanelHeight += 93f;
          this.mListItemStr1.Add(string.Empty);
          this.mListItemStr2.Add(string.Empty);
          this.tmplistIdx.Add(CustomPanel_Ptype.P4_Resources);
          this.mListItemHint.Add((byte) 0);
          break;
        case 5:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5359U));
          this.mListItemStr2.Add(string.Empty);
          int num3 = 0;
          if (this.mCustomPanel_LV >= (ushort) 10)
          {
            for (int index10 = 0; index10 < (int) this.DM.StrengthenCount && index10 < 14; ++index10)
            {
              ++num3;
              this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
              this.mListItemHint.Add((byte) 0);
              this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(this.DM.Strengthen_Info[index10].ItemID).EquipName));
              this.tmpString.Length = 0;
              if (this.DM.Strengthen_Info[index10].Time >= 86400U)
              {
                if (this.GUIM.IsArabic)
                  this.tmpString.AppendFormat("{0:00}:{1:00}:{2:00} {3}d", (object) (this.DM.Strengthen_Info[index10].Time % 86400U / 3600U), (object) (this.DM.Strengthen_Info[index10].Time % 3600U / 60U), (object) (this.DM.Strengthen_Info[index10].Time % 60U), (object) (this.DM.Strengthen_Info[index10].Time / 86400U));
                else
                  this.tmpString.AppendFormat("{0}d {1:00}:{2:00}:{3:00}", (object) (this.DM.Strengthen_Info[index10].Time / 86400U), (object) (this.DM.Strengthen_Info[index10].Time % 86400U / 3600U), (object) (this.DM.Strengthen_Info[index10].Time % 3600U / 60U), (object) (this.DM.Strengthen_Info[index10].Time % 60U));
              }
              else
                this.tmpString.AppendFormat("{0:00}:{1:00}:{2:00}", (object) (this.DM.Strengthen_Info[index10].Time / 3600U), (object) (this.DM.Strengthen_Info[index10].Time % 3600U / 60U), (object) (this.DM.Strengthen_Info[index10].Time % 60U));
              this.mListItemStr2.Add(this.tmpString.ToString());
              this.tmplist.Add(32f);
              this.CurrentPanelHeight += 32f;
            }
          }
          if (num3 != 0)
          {
            this.tmplist.RemoveAt(this.tmplist.Count - 1);
            this.tmplist.Add(40f);
            this.CurrentPanelHeight += 40f;
            break;
          }
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          this.mListItemStr1.Add("-");
          this.mListItemStr2.Add("-");
          this.tmplist.Add(32f);
          this.CurrentPanelHeight += 32f;
          break;
        case 6:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5361U));
          this.mListItemStr2.Add(string.Empty);
          this.tmpString.Length = 0;
          if (this.mCustomPanel_LV >= (ushort) 6 && this.mCustomPanel_LV < (ushort) 10)
          {
            this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5363U));
            this.tmpString.Length = 0;
            if (this.GUIM.IsArabic)
              this.tmpString.AppendFormat("%{0}", (object) this.DM.WallStatus);
            else
              this.tmpString.AppendFormat("{0}%", (object) this.DM.WallStatus);
            this.mListItemStr2.Add(this.tmpString.ToString());
          }
          else if (this.mCustomPanel_LV >= (ushort) 10)
          {
            this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5363U));
            this.tmpString.Length = 0;
            if (this.GUIM.IsArabic)
            {
              this.tmpString.AppendFormat("{0:N0}/", (object) this.DM.WallMaxValue);
              this.tmpString.AppendFormat("{0:N0}", (object) this.DM.WallValue);
            }
            else
            {
              this.tmpString.AppendFormat("{0:N0}/", (object) this.DM.WallValue);
              this.tmpString.AppendFormat("{0:N0}", (object) this.DM.WallMaxValue);
            }
            this.mListItemStr2.Add(this.tmpString.ToString());
          }
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 40f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          break;
        case 7:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5364U));
          this.tmpString.Length = 0;
          this.tmpString.Append(this.DM.mStringTable.GetStringByID(5365U));
          if (this.mCustomPanel_LV >= (ushort) 9)
          {
            this.tmpString.AppendFormat("{0:N0}", (object) this.DM.TrapsNum);
            this.mListItemStr2.Add(this.tmpString.ToString());
          }
          else if (this.mCustomPanel_LV >= (ushort) 2)
          {
            GameConstants.FormatEstimateValue(this.tmpString, this.DM.TrapsNum);
            this.mListItemStr2.Add(this.tmpString.ToString());
          }
          else
            this.mListItemStr2.Add(this.DM.mStringTable.GetStringByID(3931U));
          int num4 = 0;
          for (int index11 = 0; index11 < 12; ++index11)
          {
            int index12 = 3 - index11 / 3 + index11 % 3 * 4;
            if (((int) this.DM.TrapsFlag >> index12 & 1) == 1)
            {
              ++num4;
              recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index12 + 17));
              this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
              this.tmpString.Length = 0;
              if (this.mCustomPanel_LV >= (ushort) 9)
              {
                this.tmpString.Length = 0;
                this.tmpString.AppendFormat("{0:N0}", (object) this.DM.TrapsInfo[index12]);
                this.mListItemStr2.Add(this.tmpString.ToString());
              }
              else
              {
                this.tmpString.Length = 0;
                GameConstants.FormatEstimateValue(this.tmpString, this.DM.TrapsInfo[index12]);
                this.mListItemStr2.Add(this.tmpString.ToString());
              }
              this.tmplist.Add(32f);
              this.CurrentPanelHeight += 32f;
              this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
              this.mListItemHint.Add((byte) (index12 + 17));
            }
          }
          if (num4 != 0)
          {
            this.tmplist.RemoveAt(this.tmplist.Count - 1);
            this.tmplist.Add(40f);
            this.CurrentPanelHeight += 40f;
            break;
          }
          this.mListItemStr1.Add("-");
          this.mListItemStr2.Add("-");
          this.tmplist.Add(32f);
          this.CurrentPanelHeight += 32f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          break;
        case 8:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5366U));
          this.tmpString.Length = 0;
          this.tmpString.Append(this.DM.mStringTable.GetStringByID(5368U));
          if (this.mCustomPanel_LV >= (ushort) 1 && this.mCustomPanel_LV < (ushort) 9)
            GameConstants.FormatEstimateValue(this.tmpString, this.DM.DefenseNum);
          else if (this.mCustomPanel_LV >= (ushort) 9)
            this.tmpString.AppendFormat("{0:N0}", (object) this.DM.DefenseNum);
          this.mListItemStr2.Add(this.tmpString.ToString());
          int troopsFlag = (int) this.DM.TroopsFlag;
          int num5 = 0;
          if (this.mCustomPanel_LV >= (ushort) 2 && this.mCustomPanel_LV < (ushort) 4)
          {
            byte[] numArray = new byte[4];
            for (int index13 = 0; index13 < 4; ++index13)
            {
              numArray[index13] = (byte) (troopsFlag & 7);
              troopsFlag >>= 4;
              for (int index14 = 0; index14 < (int) numArray[index13]; ++index14)
              {
                ++num5;
                this.tmpString.Length = 0;
                recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index14 + 1 + index13 * 4));
                this.tmpString.Append(this.DM.mStringTable.GetStringByID((uint) (ushort) (3841U + (uint) recordByKey.SoldierKind)));
                this.mListItemStr1.Add(this.tmpString.ToString());
                this.mListItemStr2.Add("-");
                this.tmplist.Add(32f);
                this.CurrentPanelHeight += 32f;
                this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
                this.mListItemHint.Add((byte) 0);
              }
            }
            if (num5 != 0)
            {
              this.tmplist.RemoveAt(this.tmplist.Count - 1);
              this.tmplist.Add(40f);
              this.CurrentPanelHeight += 40f;
              break;
            }
            this.mListItemStr1.Add("-");
            this.mListItemStr2.Add("-");
            this.tmplist.Add(32f);
            this.CurrentPanelHeight += 32f;
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
            this.mListItemHint.Add((byte) 0);
            break;
          }
          if (this.mCustomPanel_LV >= (ushort) 4)
          {
            for (int index15 = 0; index15 < 16; ++index15)
            {
              int index16 = 3 - index15 / 4 + index15 % 4 * 4;
              if ((troopsFlag >> index16 & 1) == 1)
              {
                ++num5;
                this.tmpString.Length = 0;
                recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index16 + 1));
                this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
                if (this.mCustomPanel_LV >= (ushort) 9)
                {
                  this.tmpString.Length = 0;
                  this.tmpString.AppendFormat("{0:N0}", (object) this.DM.TroopsInfo[index16]);
                  this.mListItemStr2.Add(this.tmpString.ToString());
                }
                else if (this.mCustomPanel_LV >= (ushort) 5)
                {
                  this.tmpString.Length = 0;
                  GameConstants.FormatEstimateValue(this.tmpString, this.DM.TroopsInfo[index16]);
                  this.mListItemStr2.Add(this.tmpString.ToString());
                }
                else
                  this.mListItemStr2.Add("-");
                this.tmplist.Add(32f);
                this.CurrentPanelHeight += 32f;
                this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
                this.mListItemHint.Add((byte) (index16 + 1));
              }
            }
            if (num5 != 0)
            {
              this.tmplist.RemoveAt(this.tmplist.Count - 1);
              this.tmplist.Add(40f);
              this.CurrentPanelHeight += 40f;
              break;
            }
            this.mListItemStr1.Add("-");
            this.mListItemStr2.Add("-");
            this.tmplist.Add(32f);
            this.CurrentPanelHeight += 32f;
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
            this.mListItemHint.Add((byte) 0);
            break;
          }
          break;
        case 9:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5367U));
          this.tmpString.Length = 0;
          this.tmpString.Append(this.DM.mStringTable.GetStringByID(5368U));
          if (this.mCustomPanel_LV >= (ushort) 10)
            this.tmpString.AppendFormat("{0:N0}", (object) this.DM.ReinforceNum);
          else if (this.mCustomPanel_LV >= (ushort) 3)
            GameConstants.FormatEstimateValue(this.tmpString, this.DM.ReinforceNum);
          this.mListItemStr2.Add(this.tmpString.ToString());
          int reinforceFlag = (int) this.DM.ReinforceFlag;
          int num6 = 0;
          for (int index17 = 0; index17 < 16; ++index17)
          {
            int index18 = 3 - index17 / 4 + index17 % 4 * 4;
            if ((reinforceFlag >> index18 & 1) == 1)
            {
              ++num6;
              this.tmpString.Length = 0;
              recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index18 + 1));
              this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
              if (this.mCustomPanel_LV >= (ushort) 10)
              {
                this.tmpString.Length = 0;
                this.tmpString.AppendFormat("{0:N0}", (object) this.DM.ReinforceInfo[index18]);
                this.mListItemStr2.Add(this.tmpString.ToString());
              }
              else if (this.mCustomPanel_LV >= (ushort) 6)
              {
                this.tmpString.Length = 0;
                GameConstants.FormatEstimateValue(this.tmpString, this.DM.ReinforceInfo[index18]);
                this.mListItemStr2.Add(this.tmpString.ToString());
              }
              else
                this.mListItemStr2.Add("-");
              this.tmplist.Add(32f);
              this.CurrentPanelHeight += 32f;
              this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
              this.mListItemHint.Add((byte) (index18 + 1));
            }
          }
          if (num6 != 0)
          {
            this.tmplist.RemoveAt(this.tmplist.Count - 1);
            this.tmplist.Add(40f);
            this.CurrentPanelHeight += 40f;
            break;
          }
          this.mListItemStr1.Add("-");
          this.mListItemStr2.Add("-");
          this.tmplist.Add(32f);
          this.CurrentPanelHeight += 32f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          break;
        case 10:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5369U));
          this.mListItemStr2.Add(string.Empty);
          int num7 = 0;
          if (this.DM.ReinforcePlayerCount != (byte) 0)
          {
            for (int index19 = 0; index19 < (int) this.DM.ReinforcePlayerCount; ++index19)
            {
              ++num7;
              this.mListItemStr1.Add(this.DM.ReinforcePlayerName[index19].ToString());
              this.mListItemStr2.Add(string.Empty);
              this.tmplist.Add(32f);
              this.CurrentPanelHeight += 32f;
              this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
              this.mListItemHint.Add((byte) 0);
            }
            this.tmplist.RemoveAt(this.tmplist.Count - 1);
            this.tmplist.Add(40f);
            this.CurrentPanelHeight += 40f;
            break;
          }
          this.mListItemStr1.Add("-");
          this.mListItemStr2.Add("-");
          this.tmplist.Add(32f);
          this.CurrentPanelHeight += 32f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          break;
        case 11:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5370U));
          this.tmpString.Length = 0;
          this.tmpString.Append(this.DM.mStringTable.GetStringByID(5365U));
          this.tmpString.AppendFormat("{0:N0}", (object) this.DM.H_TrapsNum);
          this.mListItemStr2.Add(this.tmpString.ToString());
          int hTrapsFlag = (int) this.DM.H_TrapsFlag;
          int num8 = 0;
          for (int index20 = 0; index20 < 12; ++index20)
          {
            int index21 = 3 - index20 / 3 + index20 % 3 * 4;
            if ((hTrapsFlag >> index21 & 1) == 1)
            {
              ++num8;
              this.tmpString.Length = 0;
              recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index21 + 17));
              this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
              if (this.mCustomPanel_LV >= (ushort) 10)
              {
                this.tmpString.Length = 0;
                this.tmpString.AppendFormat("{0:N0}", (object) this.DM.H_TrapsInfo[index21]);
                this.mListItemStr2.Add(this.tmpString.ToString());
              }
              else if (this.mCustomPanel_LV >= (ushort) 5)
              {
                this.tmpString.Length = 0;
                GameConstants.FormatEstimateValue(this.tmpString, this.DM.H_TrapsInfo[index21]);
                this.mListItemStr2.Add(this.tmpString.ToString());
              }
              else
                this.mListItemStr2.Add("-");
              this.tmplist.Add(32f);
              this.CurrentPanelHeight += 32f;
              this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
              this.mListItemHint.Add((byte) (index21 + 17));
            }
          }
          if (num8 != 0)
          {
            this.tmplist.RemoveAt(this.tmplist.Count - 1);
            this.tmplist.Add(40f);
            this.CurrentPanelHeight += 40f;
            break;
          }
          this.mListItemStr1.Add("-");
          this.mListItemStr2.Add("-");
          this.tmplist.Add(32f);
          this.CurrentPanelHeight += 32f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          break;
        case 12:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5372U));
          this.tmpString.Length = 0;
          this.tmpString.Append(this.DM.mStringTable.GetStringByID(5373U));
          this.tmpString.AppendFormat("{0:N0}", (object) this.DM.H_TroopsNum);
          this.mListItemStr2.Add(this.tmpString.ToString());
          int hTroopsFlag = (int) this.DM.H_TroopsFlag;
          int num9 = 0;
          for (int index22 = 0; index22 < 16; ++index22)
          {
            int index23 = 3 - index22 / 4 + index22 % 4 * 4;
            if ((hTroopsFlag >> index23 & 1) == 1)
            {
              ++num9;
              this.tmpString.Length = 0;
              recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index23 + 1));
              this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
              if (this.mCustomPanel_LV >= (ushort) 10)
              {
                this.tmpString.Length = 0;
                this.tmpString.AppendFormat("{0:N0}", (object) this.DM.H_TroopsInfo[index23]);
                this.mListItemStr2.Add(this.tmpString.ToString());
              }
              else if (this.mCustomPanel_LV >= (ushort) 5)
              {
                this.tmpString.Length = 0;
                GameConstants.FormatEstimateValue(this.tmpString, this.DM.H_TroopsInfo[index23]);
                this.mListItemStr2.Add(this.tmpString.ToString());
              }
              else
                this.mListItemStr2.Add("-");
              this.tmplist.Add(32f);
              this.CurrentPanelHeight += 32f;
              this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
              this.mListItemHint.Add((byte) (index23 + 1));
            }
          }
          if (num9 != 0)
          {
            this.tmplist.RemoveAt(this.tmplist.Count - 1);
            this.tmplist.Add(40f);
            this.CurrentPanelHeight += 40f;
            break;
          }
          this.mListItemStr1.Add("-");
          this.mListItemStr2.Add("-");
          this.tmplist.Add(32f);
          this.CurrentPanelHeight += 32f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          break;
        case 13:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5374U));
          this.tmpString.Length = 0;
          this.tmpString.Append(this.DM.mStringTable.GetStringByID(5368U));
          if (this.mCustomPanel_LV >= (ushort) 2 && this.mCustomPanel_LV < (ushort) 9)
            GameConstants.FormatEstimateValue(this.tmpString, this.DM.MusterNum);
          else if (this.mCustomPanel_LV >= (ushort) 9)
            this.tmpString.AppendFormat("{0:N0}", (object) this.DM.MusterNum);
          this.mListItemStr2.Add(this.tmpString.ToString());
          int musterFlag = (int) this.DM.MusterFlag;
          int num10 = 0;
          for (int index24 = 0; index24 < 16; ++index24)
          {
            int index25 = 3 - index24 / 4 + index24 % 4 * 4;
            if ((musterFlag >> index25 & 1) == 1)
            {
              ++num10;
              this.tmpString.Length = 0;
              recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index25 + 1));
              this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
              if (this.mCustomPanel_LV >= (ushort) 10)
              {
                this.tmpString.Length = 0;
                this.tmpString.AppendFormat("{0:N0}", (object) this.DM.MusterInfo[index25]);
                this.mListItemStr2.Add(this.tmpString.ToString());
              }
              else if (this.mCustomPanel_LV >= (ushort) 5)
              {
                this.tmpString.Length = 0;
                GameConstants.FormatEstimateValue(this.tmpString, this.DM.MusterInfo[index25]);
                this.mListItemStr2.Add(this.tmpString.ToString());
              }
              else
                this.mListItemStr2.Add("-");
              this.tmplist.Add(32f);
              this.CurrentPanelHeight += 32f;
              this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
              this.mListItemHint.Add((byte) (index25 + 1));
            }
          }
          if (num10 != 0)
          {
            this.tmplist.RemoveAt(this.tmplist.Count - 1);
            this.tmplist.Add(40f);
            this.CurrentPanelHeight += 40f;
            break;
          }
          this.mListItemStr1.Add("-");
          this.mListItemStr2.Add("-");
          this.tmplist.Add(32f);
          this.CurrentPanelHeight += 32f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          break;
        case 14:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5376U));
          this.mListItemStr2.Add(string.Empty);
          for (int index26 = 0; index26 < (int) this.DM.BuildingCount && index26 < this.DM.BuildInfo.Length; ++index26)
          {
            this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) this.DM.BuildsTypeData.GetRecordByKey(this.DM.BuildInfo[index26].BuildID).NameID));
            this.tmpString.Length = 0;
            this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(7003U), (object) this.DM.BuildInfo[index26].Lv);
            this.mListItemStr2.Add(this.tmpString.ToString());
            this.tmplist.Add(32f);
            this.CurrentPanelHeight += 32f;
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
            this.mListItemHint.Add((byte) 0);
          }
          if (this.DM.BuildingCount != (byte) 0)
          {
            this.tmplist.RemoveAt(this.tmplist.Count - 1);
            this.tmplist.Add(40f);
            this.CurrentPanelHeight += 40f;
            break;
          }
          break;
        case 15:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add("123");
          this.mListItemStr2.Add(string.Empty);
          int num11 = 13;
          for (int index27 = 0; index27 < num11; ++index27)
          {
            this.mListItemStr1.Add("789");
            this.mListItemStr2.Add("147");
            if (num11 < 2 || index27 == num11 - 1)
            {
              this.tmplist.Add(40f);
              this.CurrentPanelHeight += 40f;
            }
            else
            {
              this.tmplist.Add(32f);
              this.CurrentPanelHeight += 32f;
            }
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
            this.mListItemHint.Add((byte) 0);
          }
          break;
        case 16:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(812U));
          this.mListItemStr2.Add(string.Empty);
          int num12 = 0;
          for (int index28 = 3; index28 >= 0; --index28)
          {
            for (int index29 = 0; index29 < 4; ++index29)
            {
              if (this.DM.MarchEventData[this.DataIdx].TroopData[index29][index28] != 0U)
              {
                ++num12;
                int num13 = index29 * 4 + index28;
                recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) (num13 + 1));
                this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
                this.tmpString.Length = 0;
                this.tmpString.AppendFormat("{0:N0}", (object) this.DM.MarchEventData[this.DataIdx].TroopData[index29][index28]);
                this.mListItemStr2.Add(this.tmpString.ToString());
                this.mListItemHint.Add((byte) (num13 + 1));
              }
            }
          }
          for (int index30 = 0; index30 < num12; ++index30)
          {
            if (num12 < 2 || index30 == num12 - 1)
            {
              this.tmplist.Add(40f);
              this.CurrentPanelHeight += 40f;
            }
            else
            {
              this.tmplist.Add(32f);
              this.CurrentPanelHeight += 32f;
            }
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          }
          break;
        case 17:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(572U));
          this.mListItemStr2.Add(string.Empty);
          this.HEROCount = 0;
          for (int index31 = 0; index31 < 5; ++index31)
          {
            if (this.DM.MarchEventData[this.DataIdx].HeroID[index31] != (ushort) 0)
            {
              this.mHeroID[index31] = this.DM.MarchEventData[this.DataIdx].HeroID[index31];
              ++this.HEROCount;
            }
          }
          this.mListItemStr1.Add(string.Empty);
          this.mListItemStr2.Add(string.Empty);
          this.tmplist.Add((float) sbyte.MaxValue);
          this.CurrentPanelHeight += (float) sbyte.MaxValue;
          this.tmplistIdx.Add(CustomPanel_Ptype.P3_Hero);
          this.mListItemHint.Add((byte) 0);
          break;
        case 18:
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4927U));
          this.mListItemStr2.Add(string.Empty);
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5798U));
          this.tmpString.Length = 0;
          if (!GUIManager.Instance.IsArabic)
            this.tmpString.AppendFormat("{0:N0} / {1:N0}", (object) this.DM.m_WallRepairNowValue, (object) this.DM.m_WallRepairMaxValue);
          else
            this.tmpString.AppendFormat("{1:N0} / {0:N0}", (object) this.DM.m_WallRepairNowValue, (object) this.DM.m_WallRepairMaxValue);
          this.mListItemStr2.Add(this.tmpString.ToString());
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 40f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5799U));
          uint num14 = 0;
          RoleBuildingData buildData = this.GUIM.BuildingData.GetBuildData((ushort) 12, (ushort) 0);
          if (this.GUIM.BuildingData.GetBuildNumByID((ushort) 12) > (byte) 0)
            num14 = this.GUIM.BuildingData.GetBuildLevelRequestData(buildData.BuildID, buildData.Level).Value1;
          this.tmpString.Length = 0;
          if (!GUIManager.Instance.IsArabic)
            this.tmpString.AppendFormat("{0:N0} / {1:N0}", (object) this.DM.TrapTotal, (object) num14);
          else
            this.tmpString.AppendFormat("{1:N0} / {0:N0}", (object) this.DM.TrapTotal, (object) num14);
          this.mListItemStr2.Add(this.tmpString.ToString());
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 40f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5800U));
          int maxDefenders = this.DM.GetMaxDefenders();
          int num15 = 0;
          for (int index32 = 0; index32 < this.DM.GetMaxDefenders(); ++index32)
          {
            if (this.DM.m_DefendersID[index32] > (ushort) 0)
              ++num15;
          }
          this.tmpString.Length = 0;
          if (!GUIManager.Instance.IsArabic)
            this.tmpString.AppendFormat("{0:N0} / {1:N0}", (object) num15, (object) maxDefenders);
          else
            this.tmpString.AppendFormat("{1:N0} / {0:N0}", (object) num15, (object) maxDefenders);
          this.mListItemStr2.Add(this.tmpString.ToString());
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 40f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5801U));
          this.tmpString.Length = 0;
          if (!GUIManager.Instance.IsArabic)
            this.tmpString.AppendFormat("{0:N0} / {1:N0}", (object) this.DM.TrapHospitalTotal, (object) num14);
          else
            this.tmpString.AppendFormat("{1:N0} / {0:N0}", (object) this.DM.TrapHospitalTotal, (object) num14);
          this.mListItemStr2.Add(this.tmpString.ToString());
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 40f;
          break;
        case 19:
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4932U));
          this.mListItemStr2.Add(string.Empty);
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          float effectBaseVal1 = (float) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAP_TRAINING_SPEED);
          float f1 = (float) ((double) effectBaseVal1 / (10000.0 + (double) effectBaseVal1) * 100.0);
          float num16 = effectBaseVal1 / 100f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4933U));
          this.tmpString.Length = 0;
          if (!GUIManager.Instance.IsArabic)
            this.tmpString.AppendFormat("{0}%", (object) num16);
          else
            this.tmpString.AppendFormat("%{0}", (object) num16);
          this.mListItemStr2.Add(this.tmpString.ToString());
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 40f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4934U));
          this.tmpString.Length = 0;
          CString cstring1 = new CString(10);
          cstring1.FloatToFormat(f1, 1, false);
          if (!GUIManager.Instance.IsArabic)
            cstring1.AppendFormat("-{0}%");
          else
            cstring1.AppendFormat("%{0}-");
          this.tmpString.Append(cstring1.ToString());
          this.mListItemStr2.Add(this.tmpString.ToString());
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 40f;
          break;
        case 20:
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4935U));
          this.mListItemStr2.Add(string.Empty);
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          if (this.DM.TrapTotal == 0U)
          {
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
            this.mListItemHint.Add((byte) 0);
            this.mListItemStr1.Add("-");
            this.mListItemStr2.Add("-");
            this.tmplist.Add(40f);
            this.CurrentPanelHeight += 40f;
            break;
          }
          for (int index33 = 0; index33 < this.DM.mTrapQty.Length; ++index33)
          {
            if (this.DM.mTrapQty[(int) GameConstants.trapSortByTeir[index33]] != 0U)
            {
              this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
              this.mListItemHint.Add((byte) ((uint) GameConstants.trapSortByTeir[index33] + 17U));
              recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) ((uint) GameConstants.trapSortByTeir[index33] + 17U));
              this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
              this.tmpString.Length = 0;
              this.tmpString.AppendFormat("{0:N0}", (object) this.DM.mTrapQty[(int) GameConstants.trapSortByTeir[index33]]);
              this.mListItemStr2.Add(this.tmpString.ToString());
              this.tmplist.Add(40f);
              this.CurrentPanelHeight += 40f;
            }
          }
          break;
        case 21:
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4936U));
          this.mListItemStr2.Add(string.Empty);
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          if (this.DM.TrapHospitalTotal == 0U)
          {
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
            this.mListItemHint.Add((byte) 0);
            this.mListItemStr1.Add("-");
            this.mListItemStr2.Add("-");
            this.tmplist.Add(40f);
            this.CurrentPanelHeight += 40f;
            break;
          }
          for (int index34 = 0; index34 < this.DM.mTrap_Hospital.Length; ++index34)
          {
            if (this.DM.mTrap_Hospital[(int) GameConstants.trapSortByTeir[index34]] != 0U)
            {
              this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
              this.mListItemHint.Add((byte) ((uint) GameConstants.trapSortByTeir[index34] + 17U));
              recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) ((uint) GameConstants.trapSortByTeir[index34] + 17U));
              this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
              this.tmpString.Length = 0;
              this.tmpString.AppendFormat("{0:N0}", (object) this.DM.mTrap_Hospital[(int) GameConstants.trapSortByTeir[index34]]);
              this.mListItemStr2.Add(this.tmpString.ToString());
              this.tmplist.Add(40f);
              this.CurrentPanelHeight += 40f;
            }
          }
          break;
        case 22:
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4918U));
          this.mListItemStr2.Add(string.Empty);
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          long soldierTotal1 = this.DM.SoldierTotal;
          for (int index35 = 0; index35 < this.DM.MarchEventData.Length; ++index35)
          {
            for (int index36 = 0; index36 < this.DM.MarchEventData[index35].TroopData.Length; ++index36)
            {
              if (this.DM.MarchEventData[index35].Type != EMarchEventType.EMET_Standby)
              {
                for (int index37 = 0; index37 < this.DM.MarchEventData[index35].TroopData[index36].Length; ++index37)
                  soldierTotal1 += (long) this.DM.MarchEventData[index35].TroopData[index36][index37];
              }
            }
          }
          foreach (long num17 in HideArmyManager.Instance.GetHideTroopData())
            soldierTotal1 += num17;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4919U));
          this.tmpString.Length = 0;
          this.tmpString.AppendFormat("{0:N0}", (object) soldierTotal1);
          this.mListItemStr2.Add(this.tmpString.ToString());
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 40f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4920U));
          this.tmpString.Length = 0;
          if (this.DM.AttribVal.TotalSoldierConsume == 0UL)
            this.tmpString.AppendFormat("<color=#ffffffff>{0:N0}</color>", (object) this.DM.AttribVal.TotalSoldierConsume);
          else if (!GUIManager.Instance.IsArabic)
            this.tmpString.AppendFormat("<color=#ff6e7eff>-{0:N0}</color>", (object) this.DM.AttribVal.TotalSoldierConsume);
          else
            this.tmpString.AppendFormat("<color=#ff6e7eff>{0:N0}-</color>", (object) this.DM.AttribVal.TotalSoldierConsume);
          this.mListItemStr2.Add(this.tmpString.ToString());
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 40f;
          break;
        case 23:
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4921U));
          this.mListItemStr2.Add(string.Empty);
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          float effectBaseVal2 = (float) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED);
          uint f2 = (uint) ((double) effectBaseVal2 / (10000.0 + (double) effectBaseVal2) * 100.0);
          float num18 = effectBaseVal2 / 100f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4922U));
          this.tmpString.Length = 0;
          if (!GUIManager.Instance.IsArabic)
            this.tmpString.AppendFormat("{0}%", (object) num18);
          else
            this.tmpString.AppendFormat("%{0}", (object) num18);
          this.mListItemStr2.Add(this.tmpString.ToString());
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 40f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4923U));
          this.tmpString.Length = 0;
          CString cstring2 = new CString(10);
          cstring2.FloatToFormat((float) f2, 1, false);
          if (!GUIManager.Instance.IsArabic)
            cstring2.AppendFormat("-{0}%");
          else
            cstring2.AppendFormat("%{0}-");
          this.tmpString.Append(cstring2.ToString());
          this.mListItemStr2.Add(this.tmpString.ToString());
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 40f;
          uint num19 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY) * (10000U + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY_PERCENT)) / 10000U;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4924U));
          this.tmpString.Length = 0;
          this.tmpString.AppendFormat("{0:N0}", (object) num19);
          this.mListItemStr2.Add(this.tmpString.ToString());
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 40f;
          break;
        case 24:
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4925U));
          this.mListItemStr2.Add(string.Empty);
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          long soldierTotal2 = this.DM.SoldierTotal;
          uint[] numArray1 = new uint[16];
          for (int index38 = 0; index38 < this.DM.RoleAttr.m_Soldier.Length; ++index38)
            numArray1[index38] = this.DM.RoleAttr.m_Soldier[index38];
          for (int index39 = 0; index39 < this.DM.MarchEventData.Length; ++index39)
          {
            if (this.DM.MarchEventData[index39].Type != EMarchEventType.EMET_Standby)
            {
              int num20 = 0;
              for (int index40 = 0; index40 < this.DM.MarchEventData[index39].TroopData.Length; ++index40)
              {
                for (int index41 = 0; index41 < this.DM.MarchEventData[index39].TroopData[index40].Length; ++index41)
                {
                  numArray1[num20++] += this.DM.MarchEventData[index39].TroopData[index40][index41];
                  soldierTotal2 += (long) this.DM.MarchEventData[index39].TroopData[index40][index41];
                }
              }
            }
          }
          uint[] hideTroopData1 = HideArmyManager.Instance.GetHideTroopData();
          for (int index42 = 0; index42 < hideTroopData1.Length; ++index42)
          {
            numArray1[index42] += hideTroopData1[index42];
            soldierTotal2 += (long) hideTroopData1[index42];
          }
          if (soldierTotal2 == 0L)
          {
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
            this.mListItemHint.Add((byte) 0);
            this.mListItemStr1.Add("-");
            this.mListItemStr2.Add("-");
            this.tmplist.Add(40f);
            this.CurrentPanelHeight += 40f;
            break;
          }
          for (int index43 = 0; index43 < this.DM.RoleAttr.m_Soldier.Length; ++index43)
          {
            if (numArray1[(int) GameConstants.troopSortByTeir[index43]] != 0U)
            {
              this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
              this.mListItemHint.Add((byte) ((uint) GameConstants.troopSortByTeir[index43] + 1U));
              recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) ((uint) GameConstants.troopSortByTeir[index43] + 1U));
              this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
              this.tmpString.Length = 0;
              this.tmpString.AppendFormat("{0:N0}", (object) numArray1[(int) GameConstants.troopSortByTeir[index43]]);
              this.mListItemStr2.Add(this.tmpString.ToString());
              this.tmplist.Add(40f);
              this.CurrentPanelHeight += 40f;
            }
          }
          break;
        case 25:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4019U));
          this.tmpString.Length = 0;
          this.tmpString.Append(this.DM.mStringTable.GetStringByID(4011U));
          this.tmpString.Append(this.HEROCount);
          this.mListItemStr2.Add(this.tmpString.ToString());
          for (int index44 = 0; index44 < this.HEROCount; ++index44)
          {
            this.mHeroID[index44] = this.mCS.Heros[index44].HeroID;
            this.mHeroRank[index44] = this.mCS.Heros[index44].Rank;
            this.mHeroStar[index44] = this.mCS.Heros[index44].Star;
          }
          this.mListItemStr1.Add("1");
          this.mListItemStr2.Add("1");
          this.tmplist.Add((float) sbyte.MaxValue);
          this.CurrentPanelHeight += (float) sbyte.MaxValue;
          this.tmplistIdx.Add(CustomPanel_Ptype.P3_Hero);
          this.mListItemHint.Add((byte) 0);
          break;
        case 26:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5324U));
          this.tmpString.Length = 0;
          this.tmpString.Append(this.DM.mStringTable.GetStringByID(4010U));
          this.tmpString.AppendFormat("{0:N0}", (object) this.SDM.mStageTroopsAmount);
          this.mListItemStr2.Add(this.tmpString.ToString());
          int num21 = 0;
          Array.Clear((Array) this.mWT_Troops, 0, this.mWT_Troops.Length);
          for (int index45 = 0; index45 < (int) this.SDM.mStageTroopsCount; ++index45)
          {
            if (this.SDM.NowCombatStageInfo[index45].Amount > 0U)
              this.mWT_Troops[(int) this.SDM.NowCombatStageInfo[index45].SoldierTableID - 1] = (byte) (index45 + 1);
          }
          for (int index46 = 0; index46 < 16; ++index46)
          {
            int index47 = 3 - index46 / 4 + index46 % 4 * 4;
            if (this.mWT_Troops[index47] > (byte) 0)
            {
              recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) this.SDM.NowCombatStageInfo[(int) this.mWT_Troops[index47] - 1].SoldierTableID);
              this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
              this.tmpString.Length = 0;
              this.tmpString.AppendFormat("{0:N0}", (object) this.SDM.NowCombatStageInfo[(int) this.mWT_Troops[index47] - 1].Amount);
              this.mListItemStr2.Add(this.tmpString.ToString());
              ++num21;
              this.tmplist.Add(32f);
              this.CurrentPanelHeight += 32f;
              this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
              this.mListItemHint.Add(this.SDM.NowCombatStageInfo[(int) this.mWT_Troops[index47] - 1].SoldierTableID);
            }
          }
          if (num21 == 0)
          {
            this.tmplistIdx.RemoveAt(this.tmplistIdx.Count - 1);
            this.tmplist.RemoveAt(this.tmplist.Count - 1);
            this.CurrentPanelHeight -= 38f;
            this.mListItemStr1.RemoveAt(this.mListItemStr1.Count - 1);
            this.mListItemStr2.RemoveAt(this.mListItemStr2.Count - 1);
            this.mListItemHint.RemoveAt(this.mListItemHint.Count - 1);
            break;
          }
          this.tmplist.RemoveAt(this.tmplist.Count - 1);
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 8f;
          break;
        case 27:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5361U));
          this.mListItemStr2.Add(string.Empty);
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5363U));
          this.tmpString.Length = 0;
          if (this.GUIM.IsArabic)
          {
            this.tmpString.AppendFormat("{0:N0}/", (object) this.mCSB.MaxWall);
            this.tmpString.AppendFormat("{0:N0}", (object) this.SDM.CorpsStageWallDefence);
          }
          else
          {
            this.tmpString.AppendFormat("{0:N0}/", (object) this.SDM.CorpsStageWallDefence);
            this.tmpString.AppendFormat("{0:N0}", (object) this.mCSB.MaxWall);
          }
          this.mListItemStr2.Add(this.tmpString.ToString());
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 40f;
          break;
        case 28:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5364U));
          this.tmpString.Length = 0;
          this.tmpString.Length = 0;
          this.tmpString.Append(this.DM.mStringTable.GetStringByID(5365U));
          this.tmpString.AppendFormat(" {0:N0}", (object) this.SDM.mStageTrapsAmount);
          this.mListItemStr2.Add(this.tmpString.ToString());
          Array.Clear((Array) this.mWT_Traps, 0, this.mWT_Traps.Length);
          int num22 = 0;
          for (int stageTroopsCount = (int) this.SDM.mStageTroopsCount; stageTroopsCount < (int) this.SDM.mStageTroopsCount + (int) this.SDM.mStageTrapsCount; ++stageTroopsCount)
          {
            if (this.SDM.NowCombatStageInfo[stageTroopsCount].Amount > 0U)
              this.mWT_Traps[(int) this.SDM.NowCombatStageInfo[stageTroopsCount].SoldierTableID - 17] = (byte) (stageTroopsCount + 1);
          }
          for (int index48 = 0; index48 < 12; ++index48)
          {
            int index49 = 3 - index48 / 3 + index48 % 3 * 4;
            if (this.mWT_Traps[index49] > (byte) 0)
            {
              recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) this.SDM.NowCombatStageInfo[(int) this.mWT_Traps[index49] - 1].SoldierTableID);
              this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
              this.tmpString.Length = 0;
              this.tmpString.AppendFormat("{0:N0}", (object) this.SDM.NowCombatStageInfo[(int) this.mWT_Traps[index49] - 1].Amount);
              this.mListItemStr2.Add(this.tmpString.ToString());
              ++num22;
              this.tmplist.Add(32f);
              this.CurrentPanelHeight += 32f;
              this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
              this.mListItemHint.Add(this.SDM.NowCombatStageInfo[(int) this.mWT_Traps[index49] - 1].SoldierTableID);
            }
          }
          if (num22 == 0)
          {
            this.tmplistIdx.RemoveAt(this.tmplistIdx.Count - 1);
            this.tmplist.RemoveAt(this.tmplist.Count - 1);
            this.CurrentPanelHeight -= 38f;
            this.mListItemStr1.RemoveAt(this.mListItemStr1.Count - 1);
            this.mListItemStr2.RemoveAt(this.mListItemStr2.Count - 1);
            this.mListItemHint.RemoveAt(this.mListItemHint.Count - 1);
            break;
          }
          this.tmplist.RemoveAt(this.tmplist.Count - 1);
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 8f;
          break;
        case 29:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5359U));
          this.tmpString.Length = 0;
          this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(5360U), (object) this.mWT_StrengthenCount);
          this.mListItemStr2.Add(this.tmpString.ToString());
          for (int index50 = 0; index50 < this.mWT_StrengthenCount; ++index50)
          {
            this.tmpString.Length = 0;
            GameConstants.GetEffectValue(this.tmpString, this.mEffectID[index50], 0U, (byte) 0, 0.0f, 0L);
            this.mListItemStr1.Add(this.tmpString.ToString());
            this.mListItemStr2.Add(string.Empty);
            this.tmplist.Add(32f);
            this.CurrentPanelHeight += 32f;
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
            this.mListItemHint.Add((byte) 0);
          }
          if (this.mWT_StrengthenCount == 0)
          {
            this.tmplistIdx.RemoveAt(this.tmplistIdx.Count - 1);
            this.tmplist.RemoveAt(this.tmplist.Count - 1);
            this.CurrentPanelHeight -= 38f;
            this.mListItemStr1.RemoveAt(this.mListItemStr1.Count - 1);
            this.mListItemStr2.RemoveAt(this.mListItemStr2.Count - 1);
            this.mListItemHint.RemoveAt(this.mListItemHint.Count - 1);
            break;
          }
          this.tmplist.RemoveAt(this.tmplist.Count - 1);
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 8f;
          break;
        case 30:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(7358U));
          this.mListItemStr2.Add(string.Empty);
          this.tmpString.Length = 0;
          this.tmpText_Info.text = this.DM.mStringTable.GetStringByID(this.InfoID);
          float num23 = this.tmpText_Info.preferredHeight + 10f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(this.InfoID));
          this.mListItemStr2.Add(string.Empty);
          this.tmplist.Add(num23);
          this.CurrentPanelHeight += num23;
          this.tmplistIdx.Add(CustomPanel_Ptype.P5_Text_Info);
          this.mListItemHint.Add((byte) 0);
          break;
        case 31:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(7791U));
          this.mListItemStr2.Add(this.DM.mStringTable.GetStringByID(7790U));
          for (int index51 = 0; index51 < this.DM.MapPrisoners.Count; ++index51)
          {
            this.mListItemStr1.Add(this.DM.MapPrisoners[index51].TagName.ToString());
            this.tmpString.Length = 0;
            this.tmpString.AppendFormat("{0:N0}", (object) this.DM.MapPrisoners[index51].Bounty);
            this.mListItemStr2.Add(this.tmpString.ToString());
            this.tmplist.Add(32f);
            this.CurrentPanelHeight += 32f;
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text_LeftAlign);
            this.mListItemHint.Add((byte) 0);
          }
          break;
        case 32:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9046U));
          this.tmpString.Length = 0;
          this.tmpString.Append(this.DM.mStringTable.GetStringByID(5368U));
          if (this.mCustomPanel_LV >= (ushort) 2 && this.mCustomPanel_LV < (ushort) 9)
            GameConstants.FormatEstimateValue(this.tmpString, this.DM.CaveNum);
          else if (this.mCustomPanel_LV >= (ushort) 9)
            this.tmpString.AppendFormat("{0:N0}", (object) this.DM.CaveNum);
          this.mListItemStr2.Add(this.tmpString.ToString());
          int num24 = 0;
          if (this.DM.bCaveMainHero)
          {
            this.tmplist.Add(32f);
            this.CurrentPanelHeight += 32f;
            this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(351U));
            this.mListItemStr2.Add(string.Empty);
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
            this.mListItemHint.Add((byte) 0);
            ++num24;
          }
          int caveFlag = (int) this.DM.CaveFlag;
          if (this.mCustomPanel_LV >= (ushort) 2 && this.mCustomPanel_LV < (ushort) 4)
          {
            byte[] numArray2 = new byte[4];
            for (int index52 = 0; index52 < 4; ++index52)
            {
              numArray2[index52] = (byte) (caveFlag & 7);
              caveFlag >>= 4;
              for (int index53 = 0; index53 < (int) numArray2[index52]; ++index53)
              {
                ++num24;
                this.tmpString.Length = 0;
                recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index53 + 1 + index52 * 4));
                this.tmpString.Append(this.DM.mStringTable.GetStringByID((uint) (ushort) (3841U + (uint) recordByKey.SoldierKind)));
                this.mListItemStr1.Add(this.tmpString.ToString());
                this.mListItemStr2.Add("-");
                this.tmplist.Add(32f);
                this.CurrentPanelHeight += 32f;
                this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
                this.mListItemHint.Add((byte) 0);
              }
            }
            if (num24 != 0)
            {
              this.tmplist.RemoveAt(this.tmplist.Count - 1);
              this.tmplist.Add(40f);
              this.CurrentPanelHeight += 40f;
              break;
            }
            this.mListItemStr1.Add("-");
            this.mListItemStr2.Add("-");
            this.tmplist.Add(32f);
            this.CurrentPanelHeight += 32f;
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
            this.mListItemHint.Add((byte) 0);
            break;
          }
          if (this.mCustomPanel_LV >= (ushort) 4)
          {
            for (int index54 = 0; index54 < 16; ++index54)
            {
              int index55 = 3 - index54 / 4 + index54 % 4 * 4;
              if ((caveFlag >> index55 & 1) == 1)
              {
                ++num24;
                this.tmpString.Length = 0;
                recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index55 + 1));
                this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
                if (this.mCustomPanel_LV >= (ushort) 9)
                {
                  this.tmpString.Length = 0;
                  this.tmpString.AppendFormat("{0:N0}", (object) this.DM.CaveInfo[index55]);
                  this.mListItemStr2.Add(this.tmpString.ToString());
                }
                else if (this.mCustomPanel_LV >= (ushort) 5)
                {
                  this.tmpString.Length = 0;
                  GameConstants.FormatEstimateValue(this.tmpString, this.DM.CaveInfo[index55]);
                  this.mListItemStr2.Add(this.tmpString.ToString());
                }
                else
                  this.mListItemStr2.Add("-");
                this.tmplist.Add(32f);
                this.CurrentPanelHeight += 32f;
                this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
                this.mListItemHint.Add((byte) (index55 + 1));
              }
            }
            if (num24 != 0)
            {
              this.tmplist.RemoveAt(this.tmplist.Count - 1);
              this.tmplist.Add(40f);
              this.CurrentPanelHeight += 40f;
              break;
            }
            this.mListItemStr1.Add("-");
            this.mListItemStr2.Add("-");
            this.tmplist.Add(32f);
            this.CurrentPanelHeight += 32f;
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
            this.mListItemHint.Add((byte) 0);
            break;
          }
          break;
        case 33:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(812U));
          this.mListItemStr2.Add(string.Empty);
          int num25 = 0;
          uint[] numArray3 = new uint[16];
          uint[] hideTroopData2 = HideArmyManager.Instance.GetHideTroopData();
          for (int index56 = 0; index56 < 16; ++index56)
          {
            int index57 = 3 - index56 / 4 + index56 % 4 * 4;
            if (hideTroopData2[index57] != 0U)
            {
              ++num25;
              recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index57 + 1));
              this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
              this.tmpString.Length = 0;
              this.tmpString.AppendFormat("{0:N0}", (object) hideTroopData2[index57]);
              this.mListItemStr2.Add(this.tmpString.ToString());
              this.mListItemHint.Add((byte) (index57 + 1));
            }
          }
          for (int index58 = 0; index58 < num25; ++index58)
          {
            if (num25 < 2 || index58 == num25 - 1)
            {
              this.tmplist.Add(40f);
              this.CurrentPanelHeight += 40f;
            }
            else
            {
              this.tmplist.Add(32f);
              this.CurrentPanelHeight += 32f;
            }
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          }
          break;
        case 34:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(8587U));
          this.mListItemStr2.Add(string.Empty);
          this.HEROCount = 1;
          this.mHeroID[0] = this.DM.GetLeaderID();
          this.mListItemStr1.Add(string.Empty);
          this.mListItemStr2.Add(string.Empty);
          this.tmplist.Add((float) sbyte.MaxValue);
          this.CurrentPanelHeight += (float) sbyte.MaxValue;
          this.tmplistIdx.Add(CustomPanel_Ptype.P3_Hero);
          this.mListItemHint.Add((byte) 0);
          break;
        case 35:
          List<KingGiftInfo> giftList1 = DataManager.Instance.KingGift.GetGiftList();
          if (giftList1.Count > this.DataIdx)
          {
            this.tmplist.Add(38f);
            this.CurrentPanelHeight += 38f;
            this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9711U));
            this.mListItemStr2.Add(string.Empty);
            KingGiftInfo kingGiftInfo = giftList1[this.DataIdx];
            KingGiftInfo.GiftList[] list = kingGiftInfo.List;
            int listCount = (int) kingGiftInfo.ListCount;
            MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[0];
            for (int index59 = 0; index59 < listCount; ++index59)
            {
              list[index59].TageName.ClearString();
              list[index59].TageName.StringToFormat(mapYolk.WonderAllianceTag);
              list[index59].TageName.StringToFormat(list[index59].Name);
              if (this.GUIM.IsArabic)
                list[index59].TageName.AppendFormat("{1}[{0}]");
              else
                list[index59].TageName.AppendFormat("[{0}]{1}");
              this.mListItemStr1.Add(list[index59].TageName.ToString());
              this.mListItemStr2.Add(string.Empty);
              this.tmplist.Add(32f);
              this.CurrentPanelHeight += 32f;
              this.tmplistIdx.Add(CustomPanel_Ptype.P5_Text_Info);
              this.mListItemHint.Add((byte) 0);
            }
            break;
          }
          break;
        case 36:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9734U));
          this.tmpString.Length = 0;
          this.tmpString.Append(this.DM.mStringTable.GetStringByID(5368U));
          if (this.mCustomPanel_LV >= (ushort) 3 && this.mCustomPanel_LV < (ushort) 10)
            GameConstants.FormatEstimateValue(this.tmpString, this.DM.CantonmentNum);
          else if (this.mCustomPanel_LV >= (ushort) 10)
            this.tmpString.AppendFormat("{0:N0}", (object) this.DM.CantonmentNum);
          this.mListItemStr2.Add(this.tmpString.ToString());
          int cantonmentFlag = (int) this.DM.CantonmentFlag;
          int num26 = 0;
          if (this.mCustomPanel_LV >= (ushort) 4)
          {
            for (int index60 = 0; index60 < 16; ++index60)
            {
              int index61 = 3 - index60 / 4 + index60 % 4 * 4;
              if ((cantonmentFlag >> index61 & 1) == 1)
              {
                ++num26;
                this.tmpString.Length = 0;
                recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index61 + 1));
                this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
                if (this.mCustomPanel_LV >= (ushort) 10)
                {
                  this.tmpString.Length = 0;
                  this.tmpString.AppendFormat("{0:N0}", (object) this.DM.CantonmentInfo[index61]);
                  this.mListItemStr2.Add(this.tmpString.ToString());
                }
                else if (this.mCustomPanel_LV >= (ushort) 6)
                {
                  this.tmpString.Length = 0;
                  GameConstants.FormatEstimateValue(this.tmpString, this.DM.CantonmentInfo[index61]);
                  this.mListItemStr2.Add(this.tmpString.ToString());
                }
                else
                  this.mListItemStr2.Add("-");
                this.tmplist.Add(32f);
                this.CurrentPanelHeight += 32f;
                this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
                this.mListItemHint.Add((byte) (index61 + 1));
              }
            }
          }
          if (num26 != 0)
          {
            this.tmplist.RemoveAt(this.tmplist.Count - 1);
            this.tmplist.Add(40f);
            this.CurrentPanelHeight += 40f;
            break;
          }
          this.mListItemStr1.Add("-");
          this.mListItemStr2.Add("-");
          this.tmplist.Add(32f);
          this.CurrentPanelHeight += 32f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          break;
        case 37:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9747U));
          this.tmpString.Length = 0;
          int cantonmentHeroCount = (int) this.DM.CantonmentHeroCount;
          this.tmpString.Append(this.DM.mStringTable.GetStringByID(4011U));
          this.tmpString.Append(cantonmentHeroCount);
          this.mListItemStr2.Add(this.tmpString.ToString());
          bool flag1 = true;
          if (this.mCustomPanel_LV < (ushort) 8)
            flag1 = false;
          if (cantonmentHeroCount > 0 && flag1)
          {
            this.mListItemStr1.Add("1");
            this.mListItemStr2.Add("1");
            this.tmplist.Add((float) sbyte.MaxValue);
            this.CurrentPanelHeight += (float) sbyte.MaxValue;
            this.tmplistIdx.Add(CustomPanel_Ptype.P3_Hero_C);
            this.mListItemHint.Add((byte) 0);
            break;
          }
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 40f;
          this.mListItemStr1.Add("-");
          this.mListItemStr2.Add("-");
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          break;
        case 38:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9746U));
          this.mListItemStr2.Add(string.Empty);
          if (this.DM.CantonmentPlayerName != null && this.DM.CantonmentPlayerName.Length != 0)
          {
            this.mListItemStr1.Add(this.DM.CantonmentPlayerName.ToString());
            this.mListItemStr2.Add(string.Empty);
            this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
            this.mListItemHint.Add((byte) 0);
            this.tmplist.Add(40f);
            this.CurrentPanelHeight += 40f;
            break;
          }
          this.mListItemStr1.Add("-");
          this.mListItemStr2.Add("-");
          this.tmplist.Add(32f);
          this.CurrentPanelHeight += 32f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          break;
        case 39:
          List<KingGiftInfo> giftList2 = DataManager.Instance.KingGift.GetGiftList();
          if (giftList2.Count > this.DataIdx)
          {
            this.tmplist.Add(38f);
            this.CurrentPanelHeight += 38f;
            this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9711U));
            this.mListItemStr2.Add(string.Empty);
            KingGiftInfo kingGiftInfo = giftList2[this.DataIdx];
            KingGiftInfo.GiftList[] list = kingGiftInfo.List;
            int listCount = (int) kingGiftInfo.ListCount;
            for (int index62 = 0; index62 < listCount; ++index62)
            {
              list[index62].TageName.ClearString();
              list[index62].TageName.StringToFormat(list[index62].Tag);
              list[index62].TageName.StringToFormat(list[index62].Name);
              if (this.GUIM.IsArabic)
                list[index62].TageName.AppendFormat("{1}[{0}]");
              else
                list[index62].TageName.AppendFormat("[{0}]{1}");
              this.mListItemStr1.Add(list[index62].TageName.ToString());
              this.mListItemStr2.Add(string.Empty);
              this.tmplist.Add(32f);
              this.CurrentPanelHeight += 32f;
              this.tmplistIdx.Add(CustomPanel_Ptype.P5_Text_Info);
              this.mListItemHint.Add((byte) 0);
            }
            break;
          }
          break;
        case 40:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9595U));
          this.mListItemStr2.Add(string.Empty);
          this.mListItemStr1.Add("1");
          this.mListItemStr2.Add("1");
          this.tmplist.Add(102f);
          this.CurrentPanelHeight += 102f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P6_Item);
          this.mListItemHint.Add((byte) 0);
          break;
        case 41:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4019U));
          this.HEROCount = 5;
          this.tmpString.Length = 0;
          this.tmpString.Append(this.DM.mStringTable.GetStringByID(4011U));
          this.tmpString.Append(this.HEROCount);
          this.mListItemStr2.Add(this.tmpString.ToString());
          bool flag2 = true;
          if (this.mCustomPanel_LV >= (ushort) 19 || this.mKindCustomPanel == 5)
          {
            if (this.mCustomPanel_LV < (ushort) 8)
            {
              flag2 = false;
            }
            else
            {
              for (int index63 = 0; index63 < this.HEROCount; ++index63)
              {
                this.mHeroID[index63] = this.DM.DefenseHero[index63].HeroID;
                this.mHeroRank[index63] = this.DM.DefenseHero[index63].Rank;
                this.mHeroStar[index63] = (byte) Mathf.Clamp((int) this.DM.DefenseHero[index63].Star, 1, 5);
              }
            }
          }
          if (this.HEROCount > 0 && flag2)
          {
            this.mListItemStr1.Add("1");
            this.mListItemStr2.Add("1");
            this.tmplist.Add((float) sbyte.MaxValue);
            this.CurrentPanelHeight += (float) sbyte.MaxValue;
            this.tmplistIdx.Add(CustomPanel_Ptype.P3_Hero_Npc);
            this.mListItemHint.Add((byte) 0);
            break;
          }
          this.tmplist.Add(40f);
          this.CurrentPanelHeight += 40f;
          this.mListItemStr1.Add("-");
          this.mListItemStr2.Add("-");
          this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
          this.mListItemHint.Add((byte) 0);
          break;
        case 42:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5387U));
          this.tmpString.Length = 0;
          this.mListItemStr2.Add(string.Empty);
          this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(5388U), (object) this.GUIM.GetPointName_Letter((POINT_KIND) this.InfoID));
          this.mListItemStr1.Add(this.tmpString.ToString());
          this.mListItemStr2.Add(string.Empty);
          this.tmplist.Add(102f);
          this.CurrentPanelHeight += 102f;
          this.tmplistIdx.Add(CustomPanel_Ptype.P5_Text_Info);
          this.mListItemHint.Add((byte) 0);
          break;
        case 43:
          this.tmplist.Add(38f);
          this.CurrentPanelHeight += 38f;
          this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(12102U));
          this.tmpString.Length = 0;
          this.tmpString.Append(string.Empty);
          this.tmplistIdx.Add(CustomPanel_Ptype.P_PetSkill);
          this.mListItemHint.Add((byte) 0);
          this.mListItemStr1.Add(string.Empty);
          this.mListItemStr2.Add(string.Empty);
          this.tmplist.Add(180f);
          this.CurrentPanelHeight += 180f;
          break;
      }
    }
    this.mCustomH = bCustomH;
    this.mOpen = bOpen;
    this.mHeight = mHeight;
  }

  public void InitScrollPanel()
  {
    int _PanelObjectsCount = 0;
    RectTransform component = this.mScrollPanel.transform.GetComponent<RectTransform>();
    if (this.mCustomH)
    {
      component.sizeDelta = new Vector2(component.sizeDelta.x, this.CurrentPanelHeight);
      _PanelObjectsCount = this.tmplist.Count < 14 ? this.tmplist.Count + 2 : 16;
      if (this.mOpen)
      {
        this.mScrollPanel.IntiScrollPanel(this.CurrentPanelHeight, 0.0f, 0.0f, this.tmplist, _PanelObjectsCount, (IUpDateScrollPanel) this);
        UIButtonHint.scrollRect = this.mScrollPanel.transform.GetComponent<CScrollRect>();
      }
      else
        this.mScrollPanel.AddNewDataHeight(this.tmplist);
      this.mScrollPanel.gameObject.SetActive(true);
    }
    else
    {
      if (this.mOpen)
      {
        _PanelObjectsCount = this.mKindCustomPanel != 5 ? (this.tmplist.Count < 14 ? this.tmplist.Count + 2 : 16) : 16;
        if ((double) this.mHeight != 0.0 && (double) this.mHeight > 160.0)
        {
          component.sizeDelta = new Vector2(component.sizeDelta.x, this.mHeight - 10f);
          this.mScrollPanel.IntiScrollPanel(this.mHeight, 0.0f, 0.0f, this.tmplist, _PanelObjectsCount, (IUpDateScrollPanel) this);
        }
        else
          this.mScrollPanel.IntiScrollPanel(396f, 0.0f, 0.0f, this.tmplist, _PanelObjectsCount, (IUpDateScrollPanel) this);
        UIButtonHint.scrollRect = this.mScrollPanel.transform.GetComponent<CScrollRect>();
      }
      else if (this.mKindCustomPanel == 5)
        this.mScrollPanel.AddNewDataHeight(this.tmplist);
      else
        this.mScrollPanel.AddNewDataHeight(this.tmplist, false);
      this.mScrollPanel.gameObject.SetActive(true);
    }
    this.ScrollPanelCount = _PanelObjectsCount;
  }

  public void Destroy()
  {
    AssetManager.UnloadAssetBundle(this.abKey);
    this.tmplist = (List<float>) null;
    this.tmplistIdx = (List<CustomPanel_Ptype>) null;
    this.mListItemStr1 = (List<string>) null;
    this.mListItemStr2 = (List<string>) null;
    for (int index = 0; index < 5; ++index)
    {
      if ((UnityEngine.Object) this.mHead[index] != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) this.mHead[index]);
      this.mHead[index] = (GameObject) null;
    }
    if (this.Cstr_SkillEffect == null)
      return;
    StringManager.Instance.DeSpawnString(this.Cstr_SkillEffect);
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.tmpText_Info != (UnityEngine.Object) null && ((Behaviour) this.tmpText_Info).enabled)
    {
      ((Behaviour) this.tmpText_Info).enabled = false;
      ((Behaviour) this.tmpText_Info).enabled = true;
    }
    if ((UnityEngine.Object) this.Text_NpcItem != (UnityEngine.Object) null && ((Behaviour) this.Text_NpcItem).enabled)
    {
      ((Behaviour) this.Text_NpcItem).enabled = false;
      ((Behaviour) this.Text_NpcItem).enabled = true;
    }
    if ((UnityEngine.Object) this.Text_PetName != (UnityEngine.Object) null && ((Behaviour) this.Text_PetName).enabled)
    {
      ((Behaviour) this.Text_PetName).enabled = false;
      ((Behaviour) this.Text_PetName).enabled = true;
    }
    if ((UnityEngine.Object) this.Text_PetSkill != (UnityEngine.Object) null && ((Behaviour) this.Text_PetSkill).enabled)
    {
      ((Behaviour) this.Text_PetSkill).enabled = false;
      ((Behaviour) this.Text_PetSkill).enabled = true;
    }
    if ((UnityEngine.Object) this.Text_PetSkillEffect != (UnityEngine.Object) null && ((Behaviour) this.Text_PetSkillEffect).enabled)
    {
      ((Behaviour) this.Text_PetSkillEffect).enabled = false;
      ((Behaviour) this.Text_PetSkillEffect).enabled = true;
    }
    for (int index1 = 0; index1 < 16; ++index1)
    {
      if ((UnityEngine.Object) this.Text_Info[index1] != (UnityEngine.Object) null && ((Behaviour) this.Text_Info[index1]).enabled)
      {
        ((Behaviour) this.Text_Info[index1]).enabled = false;
        ((Behaviour) this.Text_Info[index1]).enabled = true;
      }
      if ((UnityEngine.Object) this.Text_End[index1] != (UnityEngine.Object) null && ((Behaviour) this.Text_End[index1]).enabled)
      {
        ((Behaviour) this.Text_End[index1]).enabled = false;
        ((Behaviour) this.Text_End[index1]).enabled = true;
      }
      for (int index2 = 0; index2 < 2; ++index2)
      {
        if ((UnityEngine.Object) this.Text_Title[index1][index2] != (UnityEngine.Object) null && ((Behaviour) this.Text_Title[index1][index2]).enabled)
        {
          ((Behaviour) this.Text_Title[index1][index2]).enabled = false;
          ((Behaviour) this.Text_Title[index1][index2]).enabled = true;
        }
        if ((UnityEngine.Object) this.Text_TextStr[index1][index2] != (UnityEngine.Object) null && ((Behaviour) this.Text_TextStr[index1][index2]).enabled)
        {
          ((Behaviour) this.Text_TextStr[index1][index2]).enabled = false;
          ((Behaviour) this.Text_TextStr[index1][index2]).enabled = true;
        }
        if ((UnityEngine.Object) this.Text_LeftAlign[index1][index2] != (UnityEngine.Object) null && ((Behaviour) this.Text_LeftAlign[index1][index2]).enabled)
        {
          ((Behaviour) this.Text_LeftAlign[index1][index2]).enabled = false;
          ((Behaviour) this.Text_LeftAlign[index1][index2]).enabled = true;
        }
      }
      for (int index3 = 0; index3 < 5; ++index3)
      {
        if ((UnityEngine.Object) this.Text_Resources[index1][index3] != (UnityEngine.Object) null && ((Behaviour) this.Text_Resources[index1][index3]).enabled)
        {
          ((Behaviour) this.Text_Resources[index1][index3]).enabled = false;
          ((Behaviour) this.Text_Resources[index1][index3]).enabled = true;
        }
      }
    }
  }

  public void SetNpcImg()
  {
    if (!((UnityEngine.Object) this.TmpT != (UnityEngine.Object) null) || !((UnityEngine.Object) this.TmpT.parent != (UnityEngine.Object) null))
      return;
    for (int index = 0; index < this.TmpT.parent.childCount; ++index)
    {
      int btnId1 = this.TmpT.parent.GetChild(index).GetComponent<ScrollPanelItem>().m_BtnID1;
      int btnId2 = this.TmpT.parent.GetChild(index).GetComponent<ScrollPanelItem>().m_BtnID2;
      if (this.TmpT.parent.GetChild(index).gameObject.activeSelf && btnId2 == 3)
        this.UpDateRowItem(this.TmpT.transform.gameObject, btnId1, index, 0);
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
    if (this.bLeaderHero)
    {
      this.ShowTime += Time.smoothDeltaTime;
      if ((double) this.ShowTime >= 0.0)
      {
        if ((double) this.ShowTime >= 2.0)
          this.ShowTime = 0.0f;
        ((Graphic) this.ImgShowMain).color = new Color(1f, 1f, 1f, (double) this.ShowTime <= 1.0 ? this.ShowTime : 2f - this.ShowTime);
      }
    }
    if (!((UnityEngine.Object) this.ImgShowMain_C != (UnityEngine.Object) null) || !((Component) this.ImgShowMain_C).gameObject.activeSelf)
      return;
    this.ShowTime_C += Time.smoothDeltaTime;
    if ((double) this.ShowTime_C < 0.0)
      return;
    if ((double) this.ShowTime_C >= 2.0)
      this.ShowTime_C = 0.0f;
    ((Graphic) this.ImgShowMain_C).color = new Color(1f, 1f, 1f, (double) this.ShowTime_C <= 1.0 ? this.ShowTime_C : 2f - this.ShowTime_C);
  }
}
