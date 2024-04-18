// Decompiled with JetBrains decompiler
// Type: UIItemCraftShow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIItemCraftShow : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private PetManager PM;
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform Tmp2;
  private Transform[][] PetItem_T = new Transform[5][];
  private Transform[][] Item_T = new Transform[5][];
  private Transform mBookPosT;
  private Transform mParticlePosT;
  private Transform PetModel;
  private Transform BookModel;
  private RectTransform mContentRT;
  private RectTransform mPetRT;
  private RectTransform mPetPosRT;
  private RectTransform mParticle_MoveRT;
  private RectTransform mItemParticleRT;
  private RectTransform mItemParticle_MoveRT;
  private RectTransform[][] mLightRT = new RectTransform[5][];
  private RectTransform[][] mItemRT = new RectTransform[5][];
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private Door door;
  private UISpritesArray spArray;
  private UIButton btn_EXIT;
  private UIButton btn_ChangeStatus;
  private UIButton[][] btn_PetInfo = new UIButton[5][];
  private Image Img_EXIT;
  private Image Img_Hand;
  private Image Img_BG;
  private Image Img_ChangeStatus;
  private Image Img_PetStone;
  private Image Img_Light;
  private Image Img_Light_2;
  private Image Img_Rare;
  private Image Img_wave;
  private Image Img_hand;
  private Image[][] Img_ItemBG1 = new Image[5][];
  private Image[][] Img_ItemBG2 = new Image[5][];
  private Image Img_ItemHint;
  private Image Img_ItemRare;
  private UIText TitleNameText;
  private UIText GetAllText;
  private UIText PetTitleText;
  private UIText PetNameText;
  private UIText text_Rare;
  private UIText[][] text_ItemName = new UIText[5][];
  private UIText[][] text_ItemCount = new UIText[5][];
  private UIText[][] text_ItemCount1 = new UIText[5][];
  private UIText[][] text_ItemCount2 = new UIText[5][];
  private UIText[][] text_ItemCount3 = new UIText[5][];
  private UIText text_HintName;
  private UIText text_HintRare;
  private UIText text_HintRare2;
  private UIText text_HintInfo;
  private UIHIBtn Hbtm_ItemCraft;
  private UIHIBtn Hbtm_Pet;
  private UIHIBtn[][] Hbtn_PetItems = new UIHIBtn[5][];
  private UIHIBtn[][] Hbtn_Items = new UIHIBtn[5][];
  private ScrollPanel m_ScrollPanel;
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[5];
  private List<float> tmplist = new List<float>();
  private bool[] IsShowItem = new bool[200];
  private byte mShowItemNum;
  private float mShowItemTime;
  private bool bStarShow;
  private byte mStatus;
  private bool bShowNewPet;
  private CString Cstr_TitleName;
  private CString Cstr_PetName;
  private CString[][] Cstr_ItemCount = new CString[5][];
  private CString[][] Cstr_ItemCount1 = new CString[5][];
  private CString[][] Cstr_ItemCount2 = new CString[5][];
  private CString[][] Cstr_ItemCount3 = new CString[5][];
  private int AssetKey;
  private AssetBundle AB;
  private AssetBundleRequest AR;
  private bool bABInitial;
  private int AssetKeyPet;
  private AssetBundle AB_Pet;
  private AssetBundleRequest AR_Pet;
  private bool bAB_PetInitial = true;
  private GameObject PetGO;
  private Animation tmpAN;
  private Animation tmpAN_Pet;
  private float mScrollTime;
  private bool bStarMove;
  private float mScrollY;
  private float mScrollDis = 140f;
  private float mTotalTime = 0.4f;
  private float CheckTimer;
  private bool bShowArrow;
  private float mArrowY;
  private float scaleCount;
  private float mPetscaleCount;
  private int tmpCount;
  private Equip tmpEQ;
  private PetTbl tmpPT;
  private ItemCraftDataType tmpItemCraftD;
  private GameObject mItemMove_1;
  private GameObject mItemMove_2;
  private Vector2 tmpParticle;
  private Hero sHero;
  public bool bPet3DClose;
  public bool bPet3DShow;
  public bool bPetNextOne;
  public bool bBookOpenEnd;
  public bool bLoadPet3D;
  public bool bOPenEnd;
  public bool bPlayJizz;
  private GameObject EffectParticle;
  private GameObject Pet_Move_1;
  private GameObject Pet_Move_2;
  private GameObject Pet_Move_3;
  private GameObject PetBackEffect;
  private Vector2 bezierEnd;
  private Vector2 tmpPetLocal;
  private Vector2 mStone_Start;
  private Vector2 mStone_Move;
  private Vector2 mStone_End;
  private Equip tmpEquip;
  private AudioSourceController controller;
  private UIButtonHint hint;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.PM = PetManager.Instance;
    this.GameT = this.gameObject.transform;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.spArray = this.GameT.GetComponent<UISpritesArray>();
    this.door.LoadMaterial();
    if (this.PM.IsShowOpen)
    {
      for (int mShowItemNum = (int) this.mShowItemNum; mShowItemNum < this.PM.mItemCraftList.Count; ++mShowItemNum)
        this.IsShowItem[mShowItemNum] = true;
      this.mShowItemNum = (byte) this.PM.mItemCraftList.Count;
    }
    this.Cstr_TitleName = StringManager.Instance.SpawnString(200);
    this.Cstr_PetName = StringManager.Instance.SpawnString(100);
    for (int index1 = 0; index1 < 5; ++index1)
    {
      this.Cstr_ItemCount[index1] = new CString[4];
      this.Cstr_ItemCount1[index1] = new CString[4];
      this.Cstr_ItemCount2[index1] = new CString[4];
      this.Cstr_ItemCount3[index1] = new CString[4];
      for (int index2 = 0; index2 < 4; ++index2)
      {
        this.Cstr_ItemCount[index1][index2] = StringManager.Instance.SpawnString();
        this.Cstr_ItemCount1[index1][index2] = StringManager.Instance.SpawnString();
        this.Cstr_ItemCount2[index1][index2] = StringManager.Instance.SpawnString();
        this.Cstr_ItemCount3[index1][index2] = StringManager.Instance.SpawnString();
      }
      this.mLightRT[index1] = new RectTransform[4];
      this.mItemRT[index1] = new RectTransform[4];
      this.PetItem_T[index1] = new Transform[4];
      this.Item_T[index1] = new Transform[4];
      this.btn_PetInfo[index1] = new UIButton[4];
      this.Hbtn_PetItems[index1] = new UIHIBtn[4];
      this.Hbtn_Items[index1] = new UIHIBtn[4];
      this.Img_ItemBG1[index1] = new Image[4];
      this.Img_ItemBG2[index1] = new Image[4];
      this.text_ItemName[index1] = new UIText[4];
      this.text_ItemCount[index1] = new UIText[4];
      this.text_ItemCount1[index1] = new UIText[4];
      this.text_ItemCount2[index1] = new UIText[4];
      this.text_ItemCount3[index1] = new UIText[4];
    }
    this.Tmp = this.GameT.GetChild(0);
    this.Hbtm_ItemCraft = this.Tmp.GetChild(4).GetComponent<UIHIBtn>();
    this.GUIM.InitianHeroItemImg(((Component) this.Hbtm_ItemCraft).transform, eHeroOrItem.Item, (ushort) arg1, (byte) 0, (byte) 0);
    this.TitleNameText = this.Tmp.GetChild(5).GetComponent<UIText>();
    this.TitleNameText.font = this.TTFont;
    this.Cstr_TitleName.ClearString();
    this.tmpEquip = this.DM.EquipTable.GetRecordByKey((ushort) arg1);
    this.Cstr_TitleName.Append(this.DM.mStringTable.GetStringByID((uint) this.tmpEquip.EquipName));
    this.Cstr_TitleName.Append(' ');
    this.Cstr_TitleName.IntToFormat((long) arg2);
    if (this.GUIM.IsArabic)
      this.Cstr_TitleName.AppendFormat("{0}x");
    else
      this.Cstr_TitleName.AppendFormat("x{0}");
    this.TitleNameText.text = this.Cstr_TitleName.ToString();
    this.GetAllText = this.Tmp.GetChild(6).GetComponent<UIText>();
    this.GetAllText.font = this.TTFont;
    this.GetAllText.text = this.DM.mStringTable.GetStringByID(10102U);
    this.Tmp = this.GameT.GetChild(1);
    this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
    this.Tmp = this.GameT.GetChild(2);
    for (int index = 0; index < 4; ++index)
    {
      this.Tmp1 = this.Tmp.GetChild(index);
      this.GUIM.InitianHeroItemImg(((Component) this.Tmp1.GetChild(0).GetChild(2).GetComponent<UIHIBtn>()).transform, eHeroOrItem.Pet, (ushort) 1, (byte) 0, (byte) 0);
      this.Tmp2 = this.Tmp1.GetChild(0).GetChild(4);
      UIButton component = this.Tmp2.GetComponent<UIButton>();
      component.m_BtnID1 = 2;
      this.hint = ((Component) component).gameObject.AddComponent<UIButtonHint>();
      this.hint.m_eHint = EUIButtonHint.DownUpHandler;
      this.hint.m_Handler = (MonoBehaviour) this;
      this.Tmp2 = this.Tmp1.GetChild(0).GetChild(5);
      this.Tmp2.GetComponent<UIText>().font = this.TTFont;
      this.GUIM.InitianHeroItemImg(((Component) this.Tmp1.GetChild(1).GetChild(0).GetComponent<UIHIBtn>()).transform, eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0);
      this.Tmp2 = this.Tmp1.GetChild(1).GetChild(1).GetChild(0);
      this.Tmp2.GetComponent<UIText>().font = this.TTFont;
      this.Tmp2 = this.Tmp1.GetChild(1).GetChild(1).GetChild(1);
      this.Tmp2.GetComponent<UIText>().font = this.TTFont;
      this.Tmp2 = this.Tmp1.GetChild(1).GetChild(2).GetChild(1);
      this.Tmp2.GetComponent<UIText>().font = this.TTFont;
      this.Tmp2 = this.Tmp1.GetChild(1).GetChild(3);
      this.Tmp2.GetComponent<UIText>().font = this.TTFont;
    }
    this.tmplist.Clear();
    this.tmpCount = this.PM.mItemCraftList.Count / 4;
    if (this.PM.mItemCraftList.Count % 4 > 0)
      ++this.tmpCount;
    ++this.tmpCount;
    for (int index = 0; index < this.tmpCount; ++index)
      this.tmplist.Add(140f);
    this.m_ScrollPanel.IntiScrollPanel(478f, 0.0f, 0.0f, this.tmplist, 5, (IUpDateScrollPanel) this);
    this.mContentRT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
    UIButtonHint.scrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
    this.Tmp = this.GameT.GetChild(3);
    this.Tmp.gameObject.SetActive(true);
    this.mParticlePosT = this.Tmp;
    this.Tmp = this.GameT.GetChild(3).GetChild(0);
    this.Img_BG = this.Tmp.GetComponent<Image>();
    if (this.GUIM.bOpenOnIPhoneX)
    {
      ((Graphic) this.Img_BG).rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
      ((Graphic) this.Img_BG).rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
    }
    this.mBookPosT = this.GameT.GetChild(3).GetChild(1);
    this.Tmp = this.GameT.GetChild(3).GetChild(2);
    this.Img_Hand = this.Tmp.GetComponent<Image>();
    ((Component) this.Img_Hand).gameObject.SetActive(false);
    this.Tmp = this.GameT.GetChild(3).GetChild(3);
    this.mPetRT = this.Tmp.GetComponent<RectTransform>();
    this.Img_Light = this.Tmp.GetChild(0).GetComponent<Image>();
    this.Img_Light_2 = this.Tmp.GetChild(1).GetComponent<Image>();
    this.mPetPosRT = this.Tmp.GetChild(2).GetComponent<RectTransform>();
    this.tmpPetLocal = this.mPetPosRT.anchoredPosition;
    this.Hbtm_Pet = this.Tmp.GetChild(3).GetComponent<UIHIBtn>();
    this.GUIM.InitianHeroItemImg(((Component) this.Hbtm_Pet).transform, eHeroOrItem.Pet, (ushort) 1, (byte) 0, (byte) 0);
    this.Img_Rare = this.Tmp.GetChild(4).GetComponent<Image>();
    this.text_Rare = this.Tmp.GetChild(4).GetChild(0).GetComponent<UIText>();
    this.text_Rare.font = this.TTFont;
    this.Img_wave = this.Tmp.GetChild(5).GetComponent<Image>();
    this.Img_hand = this.Tmp.GetChild(6).GetComponent<Image>();
    this.PetTitleText = this.Tmp.GetChild(7).GetComponent<UIText>();
    this.PetTitleText.font = this.TTFont;
    this.PetTitleText.text = this.DM.mStringTable.GetStringByID(10103U);
    this.PetNameText = this.Tmp.GetChild(8).GetComponent<UIText>();
    this.PetNameText.font = this.TTFont;
    this.Tmp = this.GameT.GetChild(3).GetChild(4);
    this.mParticle_MoveRT = this.Tmp.GetComponent<RectTransform>();
    ((Component) this.mParticle_MoveRT).gameObject.SetActive(true);
    this.mParticle_MoveRT.anchoredPosition = this.tmpPetLocal;
    this.Tmp = this.GameT.GetChild(3).GetChild(5);
    this.mItemParticleRT = this.Tmp.GetComponent<RectTransform>();
    ((Component) this.mItemParticleRT).gameObject.SetActive(true);
    this.Tmp = this.GameT.GetChild(3).GetChild(6);
    this.mItemParticle_MoveRT = this.Tmp.GetComponent<RectTransform>();
    this.tmpParticle = this.mItemParticle_MoveRT.anchoredPosition;
    ((Component) this.mItemParticle_MoveRT).gameObject.SetActive(true);
    this.Tmp = this.GameT.GetChild(3).GetChild(7);
    this.Img_PetStone = this.Tmp.GetComponent<Image>();
    this.mStone_Start = ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition;
    this.Tmp = this.GameT.GetChild(4);
    this.Img_EXIT = this.Tmp.GetComponent<Image>();
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.Img_EXIT).enabled = false;
    this.Tmp = this.GameT.GetChild(4).GetChild(0);
    this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.SetButtonEffectType(e_EffectType.e_Scale);
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.Tmp = this.GameT.GetChild(5);
    this.Img_ChangeStatus = this.Tmp.GetComponent<Image>();
    this.Tmp = this.GameT.GetChild(5).GetChild(0);
    this.btn_ChangeStatus = this.Tmp.GetComponent<UIButton>();
    this.btn_ChangeStatus.m_Handler = (IUIButtonClickHandler) this;
    this.btn_ChangeStatus.m_BtnID1 = 1;
    ((Graphic) this.btn_ChangeStatus.image).color = new Color(1f, 1f, 1f, 0.0f);
    this.Tmp = this.GameT.GetChild(6);
    this.Img_ItemHint = this.Tmp.GetComponent<Image>();
    this.Tmp = this.GameT.GetChild(6).GetChild(0);
    this.Img_ItemRare = this.Tmp.GetComponent<Image>();
    this.Tmp = this.GameT.GetChild(6).GetChild(0).GetChild(0);
    this.text_HintRare2 = this.Tmp.GetComponent<UIText>();
    this.text_HintRare2.font = this.TTFont;
    this.Tmp = this.GameT.GetChild(6).GetChild(1);
    this.text_HintName = this.Tmp.GetComponent<UIText>();
    this.text_HintName.font = this.TTFont;
    this.Tmp = this.GameT.GetChild(6).GetChild(2);
    this.text_HintRare = this.Tmp.GetComponent<UIText>();
    this.text_HintRare.font = this.TTFont;
    this.text_HintRare.text = this.DM.mStringTable.GetStringByID(10129U);
    this.text_HintRare.SetAllDirty();
    this.text_HintRare.cachedTextGenerator.Invalidate();
    this.text_HintRare.cachedTextGeneratorForLayout.Invalidate();
    this.Tmp = this.GameT.GetChild(6).GetChild(3);
    this.text_HintInfo = this.Tmp.GetComponent<UIText>();
    this.text_HintInfo.font = this.TTFont;
    this.text_HintInfo.text = this.DM.mStringTable.GetStringByID(10128U);
    this.text_HintInfo.SetAllDirty();
    this.text_HintInfo.cachedTextGenerator.Invalidate();
    this.text_HintInfo.cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_HintInfo.preferredWidth > (double) this.text_HintRare.preferredWidth + 36.0)
    {
      if ((double) this.text_HintInfo.preferredWidth > 210.0)
      {
        if ((double) this.text_HintInfo.preferredWidth > 316.0)
        {
          if ((double) this.text_HintInfo.preferredHeight > 25.0)
          {
            ((Graphic) this.text_HintInfo).rectTransform.sizeDelta = new Vector2(316f, this.text_HintInfo.preferredHeight + 1f);
            ((Graphic) this.Img_ItemHint).rectTransform.sizeDelta = new Vector2(350f, (float) (118.0 + ((double) this.text_HintInfo.preferredHeight - 24.0)));
          }
          else
          {
            ((Graphic) this.text_HintInfo).rectTransform.sizeDelta = new Vector2(316f, ((Graphic) this.text_HintInfo).rectTransform.sizeDelta.y);
            ((Graphic) this.Img_ItemHint).rectTransform.sizeDelta = new Vector2(350f, ((Graphic) this.Img_ItemHint).rectTransform.sizeDelta.y);
          }
        }
        else
        {
          ((Graphic) this.text_HintInfo).rectTransform.sizeDelta = new Vector2(this.text_HintInfo.preferredWidth, ((Graphic) this.text_HintInfo).rectTransform.sizeDelta.y);
          ((Graphic) this.Img_ItemHint).rectTransform.sizeDelta = new Vector2(this.text_HintInfo.preferredWidth + 34f, ((Graphic) this.Img_ItemHint).rectTransform.sizeDelta.y);
        }
      }
    }
    else if ((double) this.text_HintRare.preferredWidth + 36.0 > 210.0)
    {
      ((Graphic) this.text_HintRare).rectTransform.sizeDelta = new Vector2(this.text_HintRare.preferredWidth + 37f, ((Graphic) this.text_HintRare).rectTransform.sizeDelta.y);
      ((Graphic) this.Img_ItemHint).rectTransform.sizeDelta = new Vector2(this.text_HintRare.preferredWidth + 71f, ((Graphic) this.Img_ItemHint).rectTransform.sizeDelta.y);
    }
    ((Graphic) this.Img_ItemRare).rectTransform.anchoredPosition = new Vector2(this.text_HintRare.preferredWidth + 20f, ((Graphic) this.Img_ItemRare).rectTransform.anchoredPosition.y);
    if (!this.PM.IsShowOpen)
    {
      this.AB = AssetManager.GetAssetBundle("Role/pet_contract", out this.AssetKey);
      if ((Object) this.AB != (Object) null)
        this.AR = this.AB.LoadAsync("m", typeof (GameObject));
      GameObject go = (GameObject) Object.Instantiate(this.AR.asset);
      go.transform.SetParent(this.mBookPosT, false);
      go.transform.localPosition = new Vector3(0.0f, 0.0f, -700f);
      go.transform.localRotation = new Quaternion(0.0f, -180f, 0.0f, 0.0f);
      go.transform.localScale = new Vector3(1000f, 1000f, 1000f);
      GUIManager.Instance.SetLayer(go, 5);
      if (this.PM.mPetItemNum > (byte) 0)
      {
        this.mStatus = (byte) 1;
        ((Component) this.mPetRT).gameObject.SetActive(true);
        ((Component) this.Img_BG).gameObject.SetActive(true);
      }
      else
      {
        this.mStatus = (byte) 0;
        this.bStarShow = true;
      }
      ((Component) this.Img_ChangeStatus).gameObject.SetActive(true);
      this.mBookPosT.gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.Img_EXIT).gameObject.SetActive(true);
      this.bShowArrow = true;
      this.mArrowY = this.mContentRT.anchoredPosition.y;
    }
    this.bOPenEnd = true;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 1);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((Object) this.tmpItem[panelObjectIdx] == (Object) null)
    {
      this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
      for (int index = 0; index < 4; ++index)
      {
        this.mItemRT[panelObjectIdx][index] = item.transform.GetChild(index).GetComponent<RectTransform>();
        this.PetItem_T[panelObjectIdx][index] = item.transform.GetChild(index).GetChild(0);
        this.mLightRT[panelObjectIdx][index] = this.PetItem_T[panelObjectIdx][index].GetChild(0).GetComponent<RectTransform>();
        this.Hbtn_PetItems[panelObjectIdx][index] = this.PetItem_T[panelObjectIdx][index].GetChild(2).GetComponent<UIHIBtn>();
        this.Hbtn_PetItems[panelObjectIdx][index].m_Handler = (IUIHIBtnClickHandler) this;
        this.btn_PetInfo[panelObjectIdx][index] = this.PetItem_T[panelObjectIdx][index].GetChild(4).GetComponent<UIButton>();
        this.btn_PetInfo[panelObjectIdx][index].m_Handler = (IUIButtonClickHandler) this;
        this.btn_PetInfo[panelObjectIdx][index].m_BtnID2 = dataIdx * 4 + index;
        this.btn_PetInfo[panelObjectIdx][index].m_BtnID3 = panelObjectIdx;
        this.hint = ((Component) this.btn_PetInfo[panelObjectIdx][index]).gameObject.GetComponent<UIButtonHint>();
        this.hint.m_eHint = EUIButtonHint.DownUpHandler;
        this.hint.m_Handler = (MonoBehaviour) this;
        this.hint.Parm1 = (ushort) 2;
        this.text_ItemName[panelObjectIdx][index] = this.PetItem_T[panelObjectIdx][index].GetChild(5).GetComponent<UIText>();
        this.Item_T[panelObjectIdx][index] = item.transform.GetChild(index).GetChild(1);
        this.Hbtn_Items[panelObjectIdx][index] = this.Item_T[panelObjectIdx][index].GetChild(0).GetComponent<UIHIBtn>();
        this.Hbtn_Items[panelObjectIdx][index].m_Handler = (IUIHIBtnClickHandler) this;
        this.Img_ItemBG1[panelObjectIdx][index] = this.Item_T[panelObjectIdx][index].GetChild(1).GetComponent<Image>();
        this.Img_ItemBG2[panelObjectIdx][index] = this.Item_T[panelObjectIdx][index].GetChild(2).GetComponent<Image>();
        this.text_ItemCount[panelObjectIdx][index] = this.Item_T[panelObjectIdx][index].GetChild(2).GetChild(1).GetComponent<UIText>();
        this.text_ItemCount1[panelObjectIdx][index] = this.Item_T[panelObjectIdx][index].GetChild(1).GetChild(0).GetComponent<UIText>();
        this.text_ItemCount1[panelObjectIdx][index].AdjuestUI();
        this.text_ItemCount2[panelObjectIdx][index] = this.Item_T[panelObjectIdx][index].GetChild(1).GetChild(1).GetComponent<UIText>();
        this.text_ItemCount2[panelObjectIdx][index].AdjuestUI();
        this.text_ItemCount3[panelObjectIdx][index] = this.Item_T[panelObjectIdx][index].GetChild(3).GetComponent<UIText>();
        this.text_ItemCount3[panelObjectIdx][index].AdjuestUI();
      }
    }
    if (panelObjectIdx < dataIdx)
    {
      for (int index = 0; index < 4; ++index)
      {
        this.PetItem_T[panelObjectIdx][index].gameObject.SetActive(false);
        this.Item_T[panelObjectIdx][index].gameObject.SetActive(false);
        ((Graphic) this.text_ItemCount1[panelObjectIdx][index]).color = Color.white;
      }
    }
    if (dataIdx * 4 >= (int) this.mShowItemNum)
      return;
    for (int index = 0; index < 4; ++index)
    {
      this.PetItem_T[panelObjectIdx][index].gameObject.SetActive(false);
      this.Item_T[panelObjectIdx][index].gameObject.SetActive(false);
      ((Component) this.text_ItemCount[panelObjectIdx][index]).gameObject.SetActive(false);
      ((Component) this.text_ItemCount1[panelObjectIdx][index]).gameObject.SetActive(false);
      ((Component) this.text_ItemCount2[panelObjectIdx][index]).gameObject.SetActive(false);
      ((Component) this.text_ItemCount3[panelObjectIdx][index]).gameObject.SetActive(false);
      ((Component) this.Img_ItemBG1[panelObjectIdx][index]).gameObject.SetActive(false);
      ((Component) this.Img_ItemBG2[panelObjectIdx][index]).gameObject.SetActive(false);
      this.scaleCount = 1f;
      if (dataIdx * 4 + index < (int) this.mShowItemNum)
      {
        item.transform.GetChild(index).gameObject.SetActive(true);
        if (dataIdx * 4 + index < this.PM.mItemCraftList.Count)
          this.tmpItemCraftD = this.PM.mItemCraftList[dataIdx * 4 + index];
        this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.tmpItemCraftD.ItemID);
        this.tmpPT = this.PM.PetTable.GetRecordByKey(this.tmpEQ.SyntheticParts[0].SyntheticItem);
        if (dataIdx * 4 + index < (int) this.PM.mPetItemNum)
        {
          this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_PetItems[panelObjectIdx][index]).transform, eHeroOrItem.Pet, this.tmpItemCraftD.mPetID, this.tmpItemCraftD.ItemRank, this.tmpPT.Rare);
          this.PetItem_T[panelObjectIdx][index].gameObject.SetActive(true);
          this.text_ItemName[panelObjectIdx][index].text = this.DM.mStringTable.GetStringByID((uint) this.tmpItemCraftD.mPetName);
          this.text_ItemName[panelObjectIdx][index].SetAllDirty();
          this.text_ItemName[panelObjectIdx][index].cachedTextGenerator.Invalidate();
          ((Component) this.text_ItemName[panelObjectIdx][index]).gameObject.SetActive(true);
        }
        else
        {
          this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_Items[panelObjectIdx][index]).transform, eHeroOrItem.Item, this.tmpItemCraftD.ItemID, this.tmpItemCraftD.ItemRank, this.tmpPT.Rare);
          this.Item_T[panelObjectIdx][index].gameObject.SetActive(true);
          this.tmpCount = 0;
          if (this.tmpItemCraftD.mItemKind == (byte) 29)
          {
            if (this.tmpItemCraftD.mPetEnhance == (byte) 2)
            {
              this.Cstr_ItemCount[panelObjectIdx][index].ClearString();
              this.tmpCount = (int) this.DM.GetCurItemQuantity(this.tmpItemCraftD.ItemID, this.tmpItemCraftD.ItemRank);
              this.Cstr_ItemCount[panelObjectIdx][index].IntToFormat((long) this.tmpCount);
              this.Cstr_ItemCount[panelObjectIdx][index].AppendFormat("{0}");
              this.text_ItemCount[panelObjectIdx][index].text = this.Cstr_ItemCount[panelObjectIdx][index].ToString();
              this.text_ItemCount[panelObjectIdx][index].SetAllDirty();
              this.text_ItemCount[panelObjectIdx][index].cachedTextGenerator.Invalidate();
              ((Component) this.Img_ItemBG2[panelObjectIdx][index]).gameObject.SetActive(true);
              ((Component) this.text_ItemCount[panelObjectIdx][index]).gameObject.SetActive(true);
              if (this.GUIM.IsArabic)
                ((Transform) ((Graphic) this.text_ItemCount[panelObjectIdx][index]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
              else
                ((Transform) ((Graphic) this.text_ItemCount[panelObjectIdx][index]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
            }
            else
            {
              ((Component) this.Img_ItemBG1[panelObjectIdx][index]).gameObject.SetActive(true);
              this.Cstr_ItemCount1[panelObjectIdx][index].ClearString();
              this.tmpCount = (int) this.DM.GetCurItemQuantity(this.tmpItemCraftD.ItemID, this.tmpItemCraftD.ItemRank);
              this.Cstr_ItemCount[panelObjectIdx][index].IntToFormat((long) this.tmpCount);
              this.Cstr_ItemCount1[panelObjectIdx][index].AppendFormat("{0}");
              this.text_ItemCount1[panelObjectIdx][index].text = this.Cstr_ItemCount1[panelObjectIdx][index].ToString();
              this.text_ItemCount1[panelObjectIdx][index].SetAllDirty();
              this.text_ItemCount1[panelObjectIdx][index].cachedTextGenerator.Invalidate();
              this.Cstr_ItemCount2[panelObjectIdx][index].ClearString();
              this.Cstr_ItemCount2[panelObjectIdx][index].IntToFormat((long) this.PM.GetEvoNeed_Stone(this.tmpItemCraftD.mPetEnhance, this.tmpPT.Rare));
              if (this.GUIM.IsArabic)
                this.Cstr_ItemCount2[panelObjectIdx][index].AppendFormat("{0}/");
              else
                this.Cstr_ItemCount2[panelObjectIdx][index].AppendFormat("/{0}");
              this.text_ItemCount2[panelObjectIdx][index].text = this.Cstr_ItemCount2[panelObjectIdx][index].ToString();
              this.text_ItemCount2[panelObjectIdx][index].SetAllDirty();
              this.text_ItemCount2[panelObjectIdx][index].cachedTextGenerator.Invalidate();
              ((Component) this.text_ItemCount1[panelObjectIdx][index]).gameObject.SetActive(true);
              ((Component) this.text_ItemCount2[panelObjectIdx][index]).gameObject.SetActive(true);
              if (this.tmpCount >= (int) this.PM.GetEvoNeed_Stone(this.tmpItemCraftD.mPetEnhance, this.tmpPT.Rare))
                ((Graphic) this.text_ItemCount1[panelObjectIdx][index]).color = Color.green;
              if (this.GUIM.IsArabic)
              {
                ((Transform) ((Graphic) this.text_ItemCount1[panelObjectIdx][index]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
                ((Transform) ((Graphic) this.text_ItemCount2[panelObjectIdx][index]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
                ((Transform) ((Graphic) this.text_ItemCount3[panelObjectIdx][index]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
              }
              else
              {
                ((Transform) ((Graphic) this.text_ItemCount1[panelObjectIdx][index]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
                ((Transform) ((Graphic) this.text_ItemCount2[panelObjectIdx][index]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
                ((Transform) ((Graphic) this.text_ItemCount3[panelObjectIdx][index]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
              }
            }
          }
          ((Component) this.text_ItemCount3[panelObjectIdx][index]).gameObject.SetActive(true);
          this.Cstr_ItemCount3[panelObjectIdx][index].ClearString();
          this.Cstr_ItemCount3[panelObjectIdx][index].IntToFormat((long) this.tmpItemCraftD.Num);
          if (this.GUIM.IsArabic)
            this.Cstr_ItemCount3[panelObjectIdx][index].AppendFormat("{0}x");
          else
            this.Cstr_ItemCount3[panelObjectIdx][index].AppendFormat("x{0}");
          this.text_ItemCount3[panelObjectIdx][index].text = this.Cstr_ItemCount3[panelObjectIdx][index].ToString();
          this.text_ItemCount3[panelObjectIdx][index].SetAllDirty();
          this.text_ItemCount3[panelObjectIdx][index].cachedTextGenerator.Invalidate();
        }
      }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    switch ((GUIItemCraftShow) sender.m_BtnID1)
    {
      case GUIItemCraftShow.btn_EXIT:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case GUIItemCraftShow.btn_ChangeStatus:
        if (!this.bOPenEnd || !this.bBookOpenEnd)
          break;
        if (this.mStatus == (byte) 1)
        {
          if (!this.bPet3DShow)
          {
            if ((Object) this.EffectParticle != (Object) null)
            {
              if (this.EffectParticle.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
              {
                this.EffectParticle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
                this.EffectParticle.SetActive(false);
                this.EffectParticle.SetActive(true);
              }
              this.EffectParticle = (GameObject) null;
            }
            if ((Object) this.Pet_Move_3 != (Object) null)
            {
              if (this.Pet_Move_3.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
              {
                this.Pet_Move_3.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
                this.Pet_Move_3.SetActive(false);
                this.Pet_Move_3.SetActive(true);
              }
              this.Pet_Move_3 = (GameObject) null;
            }
            if (this.controller != null)
              this.controller.Stop();
            this.mShowItemTime = 0.0f;
            ((Component) this.mPetRT).gameObject.SetActive(true);
            if (!this.bLoadPet3D)
              this.LoadPet3D();
            this.bPet3DShow = true;
            if ((Object) this.AB_Pet == (Object) null)
              ((Component) this.Hbtm_Pet).gameObject.SetActive(true);
            ((Component) this.Img_Light).gameObject.SetActive(true);
            ((Component) this.Img_Light_2).gameObject.SetActive(true);
            ((Component) this.Img_Rare).gameObject.SetActive(true);
            ((Component) this.PetTitleText).gameObject.SetActive(true);
            ((Component) this.PetNameText).gameObject.SetActive(true);
            this.scaleCount = 1f;
            ((Transform) this.mPetPosRT).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
            this.mPetPosRT.anchoredPosition = new Vector2(this.mPetPosRT.anchoredPosition.x, (float) -(1000 - (int) this.tmpPT.StartupRatio.UpDownDist));
            ((Graphic) this.Img_PetStone).color = new Color(1f, 1f, 1f, 0.0f);
            AudioManager.Instance.PlayUISFX(UIKind.GainPetRookie);
            break;
          }
          if (!this.bPet3DClose)
          {
            this.bPet3DClose = true;
            this.mShowItemTime = 0.0f;
            if ((Object) this.Pet_Move_1 != (Object) null)
            {
              if (this.Pet_Move_1.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
              {
                this.Pet_Move_1.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
                this.Pet_Move_1.SetActive(false);
                this.Pet_Move_1.SetActive(true);
              }
              this.Pet_Move_1 = (GameObject) null;
            }
            if ((Object) this.Pet_Move_2 != (Object) null)
            {
              if (this.Pet_Move_2.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
              {
                this.Pet_Move_2.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
                this.Pet_Move_2.SetActive(false);
                this.Pet_Move_2.SetActive(true);
              }
              this.Pet_Move_2 = (GameObject) null;
            }
            ((Component) this.Img_wave).gameObject.SetActive(false);
            ((Component) this.Img_hand).gameObject.SetActive(false);
            break;
          }
          this.mShowItemTime = 0.0f;
          this.mScrollTime = 0.0f;
          this.IsShowItem[(int) this.mShowItemNum] = true;
          ++this.mShowItemNum;
          this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
          if (this.mShowItemNum > (byte) 4 && (int) this.mShowItemNum % 4 == 0)
            this.bStarMove = true;
          this.bPet3DClose = false;
          this.bPet3DShow = false;
          this.bPetNextOne = false;
          this.DestroyPet3D();
          ((Component) this.Img_Light).gameObject.SetActive(false);
          ((Component) this.Img_Light_2).gameObject.SetActive(false);
          ((Component) this.Img_Rare).gameObject.SetActive(false);
          ((Component) this.PetTitleText).gameObject.SetActive(false);
          ((Component) this.PetNameText).gameObject.SetActive(false);
          ((Component) this.mPetRT).gameObject.SetActive(false);
          if ((int) this.PM.mPetItemNum < (int) this.mShowItemNum + 1)
          {
            this.mStatus = (byte) 0;
            this.bStarShow = true;
            ((Component) this.Img_BG).gameObject.SetActive(false);
          }
          else
            this.mStatus = (byte) 1;
          this.mParticle_MoveRT.anchoredPosition = this.tmpPetLocal;
          if ((Object) this.EffectParticle != (Object) null)
          {
            if (this.EffectParticle.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
            {
              this.EffectParticle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
              this.EffectParticle.SetActive(false);
              this.EffectParticle.SetActive(true);
            }
            this.EffectParticle = (GameObject) null;
          }
          if ((Object) this.Pet_Move_1 != (Object) null)
          {
            if (this.Pet_Move_1.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
            {
              this.Pet_Move_1.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
              this.Pet_Move_1.SetActive(false);
              this.Pet_Move_1.SetActive(true);
            }
            this.Pet_Move_1 = (GameObject) null;
          }
          if (!((Object) this.Pet_Move_2 != (Object) null))
            break;
          if (this.Pet_Move_2.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
          {
            this.Pet_Move_2.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
            this.Pet_Move_2.SetActive(false);
            this.Pet_Move_2.SetActive(true);
          }
          this.Pet_Move_2 = (GameObject) null;
          break;
        }
        if (this.mStatus != (byte) 0 && this.mStatus != (byte) 4 && this.mStatus != (byte) 3 || this.mShowItemNum <= (byte) 0)
          break;
        byte index1 = (byte) (((int) this.mShowItemNum - 1) / 4 % 5);
        byte index2 = (byte) (((int) this.mShowItemNum - 1) % 4);
        this.scaleCount = 1f;
        ((Transform) this.mItemRT[(int) index1][(int) index2]).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
        if (((Component) this.text_ItemCount1[(int) index1][(int) index2]).gameObject.activeSelf)
        {
          if (this.GUIM.IsArabic)
            ((Transform) ((Graphic) this.text_ItemCount1[(int) index1][(int) index2]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
          else
            ((Transform) ((Graphic) this.text_ItemCount1[(int) index1][(int) index2]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
          ((Graphic) this.text_ItemCount1[(int) index1][(int) index2]).rectTransform.anchoredPosition = new Vector2((float) (-23.0 - ((double) this.scaleCount - 1.0) * 20.0), ((Graphic) this.text_ItemCount1[(int) index1][(int) index2]).rectTransform.anchoredPosition.y);
        }
        if (((Component) this.text_ItemCount[(int) index1][(int) index2]).gameObject.activeSelf)
        {
          if (this.GUIM.IsArabic)
            ((Transform) ((Graphic) this.text_ItemCount[(int) index1][(int) index2]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
          else
            ((Transform) ((Graphic) this.text_ItemCount[(int) index1][(int) index2]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
        }
        if ((Object) this.mItemMove_1 != (Object) null)
        {
          if (this.mItemMove_1.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
          {
            this.mItemMove_1.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
            this.mItemMove_1.gameObject.SetActive(false);
            this.mItemMove_1.gameObject.SetActive(true);
          }
          this.mItemMove_1 = (GameObject) null;
        }
        if ((Object) this.mItemMove_2 != (Object) null)
        {
          if (this.mItemMove_2.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
          {
            this.mItemMove_2.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
            this.mItemMove_2.gameObject.SetActive(false);
            this.mItemMove_2.gameObject.SetActive(true);
          }
          this.mItemMove_2 = (GameObject) null;
        }
        this.mItemParticle_MoveRT.anchoredPosition = this.tmpParticle;
        this.mShowItemTime = 0.0f;
        byte num = (int) this.mShowItemNum >= (int) this.PM.mPetItemNum + (int) this.PM.mPetStoneNum ? (byte) this.PM.mItemCraftList.Count : (byte) ((uint) this.PM.mPetItemNum + (uint) this.PM.mPetStoneNum);
        for (int mShowItemNum = (int) this.mShowItemNum; mShowItemNum < (int) num; ++mShowItemNum)
          this.IsShowItem[mShowItemNum] = true;
        this.mShowItemNum = num;
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        float y = 0.0f;
        if (this.mShowItemNum >= (byte) 8)
          y = (int) this.mShowItemNum % 4 <= 0 ? (float) (140 * (((int) this.mShowItemNum - 8) / 4)) : (float) (140 * (((int) this.mShowItemNum - 8) / 4 + 1));
        if ((double) y + 478.0 > (double) this.mContentRT.sizeDelta.y)
          y = this.mContentRT.sizeDelta.y - 478f;
        if ((double) y < 0.0)
          y = 0.0f;
        this.mContentRT.anchoredPosition = new Vector2(this.mContentRT.anchoredPosition.x, y);
        this.mScrollY = y;
        this.bStarMove = false;
        break;
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    if (sender.Parm1 != (ushort) 2)
      return;
    if (button.m_BtnID2 >= 0 && button.m_BtnID2 < this.PM.mItemCraftList.Count)
      this.tmpItemCraftD = this.PM.mItemCraftList[button.m_BtnID2];
    this.text_HintName.text = this.DM.mStringTable.GetStringByID((uint) this.tmpItemCraftD.mPetName);
    this.text_HintName.SetAllDirty();
    this.text_HintName.cachedTextGenerator.Invalidate();
    this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.tmpItemCraftD.ItemID);
    this.tmpPT = this.PM.PetTable.GetRecordByKey(this.tmpEQ.SyntheticParts[0].SyntheticItem);
    this.text_HintRare2.text = this.tmpPT.Rare.ToString();
    this.text_HintRare2.SetAllDirty();
    this.text_HintRare2.cachedTextGenerator.Invalidate();
    sender.GetTipPosition(((Graphic) this.Img_ItemHint).rectTransform);
    ((Component) this.Img_ItemHint).gameObject.SetActive(true);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    ((Component) this.Img_ItemHint).gameObject.SetActive(false);
  }

  public override bool OnBackButtonClick()
  {
    if (((Component) this.Img_EXIT).gameObject.activeSelf)
      return false;
    this.OnButtonClick(this.btn_ChangeStatus);
    return true;
  }

  public override void OnClose()
  {
    this.DestroyPet3D();
    if ((Object) this.EffectParticle != (Object) null)
    {
      if (this.EffectParticle.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
      {
        this.EffectParticle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
        this.EffectParticle.SetActive(false);
        this.EffectParticle.SetActive(true);
      }
      this.EffectParticle = (GameObject) null;
    }
    if ((Object) this.Pet_Move_1 != (Object) null)
    {
      if (this.Pet_Move_1.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
      {
        this.Pet_Move_1.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
        this.Pet_Move_1.SetActive(false);
        this.Pet_Move_1.SetActive(true);
      }
      this.Pet_Move_1 = (GameObject) null;
    }
    if ((Object) this.Pet_Move_2 != (Object) null)
    {
      if (this.Pet_Move_2.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
      {
        this.Pet_Move_2.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
        this.Pet_Move_2.SetActive(false);
        this.Pet_Move_2.SetActive(true);
      }
      this.Pet_Move_2 = (GameObject) null;
    }
    if ((Object) this.Pet_Move_3 != (Object) null)
    {
      if (this.Pet_Move_3.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
      {
        this.Pet_Move_3.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
        this.Pet_Move_3.SetActive(false);
        this.Pet_Move_3.SetActive(true);
      }
      this.Pet_Move_3 = (GameObject) null;
    }
    if ((Object) this.mItemMove_1 != (Object) null)
    {
      if (this.mItemMove_1.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
      {
        this.mItemMove_1.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
        this.mItemMove_1.SetActive(false);
        this.mItemMove_1.SetActive(true);
      }
      this.mItemMove_1 = (GameObject) null;
    }
    if ((Object) this.mItemMove_2 != (Object) null)
    {
      if (this.mItemMove_2.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
      {
        this.mItemMove_2.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
        this.mItemMove_2.SetActive(false);
        this.mItemMove_2.SetActive(true);
      }
      this.mItemMove_2 = (GameObject) null;
    }
    if ((Object) this.PetBackEffect != (Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.PetBackEffect);
      this.PetBackEffect = (GameObject) null;
    }
    if (!this.PM.IsShowOpen)
      this.PM.IsShowOpen = true;
    if (this.AssetKey != 0)
      AssetManager.UnloadAssetBundle(this.AssetKey);
    if (this.Cstr_TitleName != null)
      StringManager.Instance.DeSpawnString(this.Cstr_TitleName);
    if (this.Cstr_PetName != null)
      StringManager.Instance.DeSpawnString(this.Cstr_PetName);
    for (int index1 = 0; index1 < 5; ++index1)
    {
      for (int index2 = 0; index2 < 4; ++index2)
      {
        if (this.Cstr_ItemCount[index1][index2] != null)
          StringManager.Instance.DeSpawnString(this.Cstr_ItemCount[index1][index2]);
        if (this.Cstr_ItemCount1[index1][index2] != null)
          StringManager.Instance.DeSpawnString(this.Cstr_ItemCount1[index1][index2]);
        if (this.Cstr_ItemCount2[index1][index2] != null)
          StringManager.Instance.DeSpawnString(this.Cstr_ItemCount2[index1][index2]);
        if (this.Cstr_ItemCount3[index1][index2] != null)
          StringManager.Instance.DeSpawnString(this.Cstr_ItemCount3[index1][index2]);
      }
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (this.bShowArrow)
    {
      this.CheckTimer -= Time.deltaTime;
      if ((double) this.CheckTimer <= 0.0)
        this.CheckTimer = 0.5f;
      if ((double) Mathf.Abs(this.mArrowY - this.mContentRT.anchoredPosition.y) > 10.0)
      {
        this.bShowArrow = false;
        ((Component) this.Img_Hand).gameObject.SetActive(false);
      }
    }
    for (int index1 = 0; index1 < 5; ++index1)
    {
      for (int index2 = 0; index2 < 4; ++index2)
      {
        if ((Object) this.PetItem_T[index1][index2] != (Object) null && this.PetItem_T[index1][index2].gameObject.activeSelf && (Object) this.mLightRT[index1][index2] != (Object) null)
          ((Transform) this.mLightRT[index1][index2]).Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
      }
    }
    if (!this.bABInitial && this.AR != null && this.AR.isDone)
    {
      this.BookModel = this.mBookPosT.GetChild(0).GetComponent<Transform>();
      if ((Object) this.BookModel != (Object) null)
      {
        this.tmpAN = this.BookModel.GetComponent<Animation>();
        this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
        this.tmpAN.wrapMode = WrapMode.Loop;
        this.tmpAN["open"].layer = 1;
        this.tmpAN["open"].wrapMode = WrapMode.Default;
        this.tmpAN["idle"].layer = 0;
        this.tmpAN["idle"].wrapMode = WrapMode.Loop;
        this.tmpAN["jizz"].layer = 1;
        this.tmpAN["jizz"].wrapMode = WrapMode.Default;
        this.tmpAN.clip = this.tmpAN.GetClip("idle");
        this.tmpAN.Play("idle");
        this.tmpAN.CrossFade("open");
        if (this.BookModel.gameObject.activeSelf)
        {
          SkinnedMeshRenderer componentInChildren = this.BookModel.GetComponentInChildren<SkinnedMeshRenderer>();
          componentInChildren.useLightProbes = false;
          componentInChildren.updateWhenOffscreen = true;
        }
      }
      this.bABInitial = true;
    }
    if (!this.bBookOpenEnd && this.bABInitial && (Object) this.BookModel != (Object) null && (Object) this.tmpAN != (Object) null && !this.tmpAN.IsPlaying("open"))
      this.bBookOpenEnd = true;
    if (!this.bOPenEnd || !this.bBookOpenEnd)
      return;
    if (this.mStatus == (byte) 0)
    {
      if (this.bStarShow)
      {
        if ((int) this.mShowItemNum < this.PM.mItemCraftList.Count)
        {
          this.mShowItemTime += Time.smoothDeltaTime;
          if (!this.bPlayJizz && (Object) this.tmpAN != (Object) null)
          {
            this.tmpAN.CrossFade("jizz", 0.2f);
            this.bPlayJizz = true;
          }
          if ((double) this.mShowItemTime < (double) this.mTotalTime / 2.0)
          {
            if (this.mShowItemNum < (byte) 8)
            {
              this.bezierEnd = new Vector2((float) (180 * ((int) this.mShowItemNum % 4) - 277), (float) (115.0 - (double) this.mScrollDis * (double) ((int) this.mShowItemNum / 4)));
            }
            else
            {
              int num = this.PM.mItemCraftList.Count % 4;
              this.bezierEnd = num == 0 && this.PM.mItemCraftList.Count - 4 <= (int) this.mShowItemNum || num > 0 && this.PM.mItemCraftList.Count - num <= (int) this.mShowItemNum ? new Vector2((float) (180 * ((int) this.mShowItemNum % 4) - 277), -83f) : new Vector2((float) (180 * ((int) this.mShowItemNum % 4) - 277), -25f);
            }
            if ((Object) this.mItemMove_1 == (Object) null)
            {
              this.mItemMove_1 = ParticleManager.Instance.Spawn((ushort) 437, ((Component) this.mItemParticleRT).transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
              this.mItemMove_1.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
              this.mItemMove_1.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
              this.GUIM.SetLayer(this.mItemMove_1, 5);
            }
            if ((Object) this.mItemMove_2 == (Object) null)
            {
              this.mItemMove_2 = ParticleManager.Instance.Spawn((ushort) 438, ((Component) this.mItemParticle_MoveRT).transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
              this.mItemMove_2.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
              this.mItemMove_2.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
              this.GUIM.SetLayer(this.mItemMove_2, 5);
            }
            this.mItemParticle_MoveRT.anchoredPosition = Vector2.Lerp(this.tmpParticle, this.bezierEnd, this.mShowItemTime / (this.mTotalTime / 2f));
          }
          else
          {
            this.mItemParticle_MoveRT.anchoredPosition = this.bezierEnd;
            this.mShowItemTime = 0.0f;
            this.IsShowItem[(int) this.mShowItemNum] = true;
            ++this.mShowItemNum;
            this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
            this.mScrollTime = 0.0f;
            this.mStatus = (byte) 4;
            AudioManager.Instance.PlayUISFX(UIKind.PetFly);
          }
        }
        else
        {
          this.bStarShow = false;
          ((Component) this.Img_EXIT).gameObject.SetActive(true);
          this.bShowArrow = true;
          this.mArrowY = this.mContentRT.anchoredPosition.y;
          ((Component) this.Img_ChangeStatus).gameObject.SetActive(false);
          this.mBookPosT.gameObject.SetActive(false);
        }
      }
    }
    else if (this.mStatus == (byte) 1)
    {
      this.mShowItemTime += Time.smoothDeltaTime;
      if (!this.bPet3DClose && !this.bPet3DShow && !this.bPetNextOne && (Object) this.EffectParticle == (Object) null)
      {
        this.EffectParticle = ParticleManager.Instance.Spawn((ushort) 439, ((Component) this.mItemParticleRT).transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
        this.EffectParticle.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        this.EffectParticle.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        GUIManager.Instance.SetLayer(this.EffectParticle, 5);
        this.mPetPosRT.anchoredPosition = new Vector2(0.0f, 100f);
        ((Transform) this.mPetPosRT).localScale = Vector3.zero;
        if (!this.bPlayJizz && (Object) this.tmpAN != (Object) null)
        {
          this.tmpAN.CrossFade("jizz", 0.2f);
          this.bPlayJizz = true;
        }
        if (!this.bLoadPet3D)
        {
          if (!((Component) this.mPetRT).gameObject.activeSelf)
            ((Component) this.mPetRT).gameObject.SetActive(true);
          this.LoadPet3D();
        }
        AudioManager.Instance.PlayUISFX(ref this.controller, UIKind.DrawLotStart);
      }
      if (!((Component) this.Img_PetStone).gameObject.activeSelf && (double) this.mShowItemTime >= 0.36000001430511475)
        ((Component) this.Img_PetStone).gameObject.SetActive(true);
      if (!this.bPet3DShow)
      {
        if ((double) this.mShowItemTime < 1.1000000238418579)
        {
          this.mStone_Move = this.mStone_Start;
          this.mStone_End = this.mStone_Start;
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = this.mStone_Start;
        }
        else if ((double) this.mShowItemTime < 1.2000000476837158)
        {
          this.mStone_Move = this.mStone_Start;
          this.mStone_End = this.mStone_Start + new Vector2(-20f, -20f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.1000000238418579) / 0.10000000149011612));
        }
        else if ((double) this.mShowItemTime < 1.2999999523162842)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(-20f, -20f);
          this.mStone_End = this.mStone_Start + new Vector2(20f, -13f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.2000000476837158) / 0.10000000149011612));
        }
        else if ((double) this.mShowItemTime < 1.3999999761581421)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(20f, -13f);
          this.mStone_End = this.mStone_Start + new Vector2(-5f, 30f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.2999999523162842) / 0.10000000149011612));
        }
        else if ((double) this.mShowItemTime < 1.5)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(-5f, 30f);
          this.mStone_End = this.mStone_Start + new Vector2(-16f, -40f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.3999999761581421) / 0.10000000149011612));
        }
        else if ((double) this.mShowItemTime < 1.5700000524520874)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(-16f, -40f);
          this.mStone_End = this.mStone_Start + new Vector2(-15f, 10f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.5) / 0.070000000298023224));
        }
        else if ((double) this.mShowItemTime < 1.6299999952316284)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(-15f, 10f);
          this.mStone_End = this.mStone_Start + new Vector2(0.0f, 10f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.5700000524520874) / 0.059999998658895493));
        }
        else if ((double) this.mShowItemTime < 1.6699999570846558)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(0.0f, 10f);
          this.mStone_End = this.mStone_Start + new Vector2(10f, 0.0f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.6299999952316284) / 0.029999999329447746));
        }
        else if ((double) this.mShowItemTime < 1.7000000476837158)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(10f, 0.0f);
          this.mStone_End = this.mStone_Start + new Vector2(0.0f, 10f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.6699999570846558) / 0.029999999329447746));
        }
        else if ((double) this.mShowItemTime < 1.7300000190734863)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(0.0f, 10f);
          this.mStone_End = this.mStone_Start + new Vector2(10f, 0.0f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.7000000476837158) / 0.029999999329447746));
        }
        else if ((double) this.mShowItemTime < 1.7599999904632568)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(10f, 0.0f);
          this.mStone_End = this.mStone_Start + new Vector2(0.0f, 10f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.7300000190734863) / 0.029999999329447746));
        }
        else if ((double) this.mShowItemTime < 1.8300000429153442)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(0.0f, 10f);
          this.mStone_End = this.mStone_Start + new Vector2(-10f, 10f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.7599999904632568) / 0.029999999329447746));
        }
        else if ((double) this.mShowItemTime < 1.8700000047683716)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(-10f, 10f);
          this.mStone_End = this.mStone_Start + new Vector2(0.0f, 0.0f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.8300000429153442) / 0.039999999105930328));
        }
        else if ((double) this.mShowItemTime < 1.8999999761581421)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(0.0f, 0.0f);
          this.mStone_End = this.mStone_Start + new Vector2(-10f, 10f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.8700000047683716) / 0.029999999329447746));
        }
        else if ((double) this.mShowItemTime < 1.9299999475479126)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(-10f, 10f);
          this.mStone_End = this.mStone_Start + new Vector2(0.0f, 0.0f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.8999999761581421) / 0.029999999329447746));
        }
        else if ((double) this.mShowItemTime < 1.9600000381469727)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(0.0f, 0.0f);
          this.mStone_End = this.mStone_Start + new Vector2(-10f, 0.0f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.9299999475479126) / 0.029999999329447746));
        }
        else if ((double) this.mShowItemTime < 2.0299999713897705)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(-10f, 0.0f);
          this.mStone_End = this.mStone_Start + new Vector2(0.0f, 10f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 1.9600000381469727) / 0.070000000298023224));
        }
        else if ((double) this.mShowItemTime < 2.059999942779541)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(0.0f, 10f);
          this.mStone_End = this.mStone_Start + new Vector2(-10f, 0.0f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 2.0299999713897705) / 0.029999999329447746));
        }
        else if ((double) this.mShowItemTime < 2.0999999046325684)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(-10f, 0.0f);
          this.mStone_End = this.mStone_Start + new Vector2(10f, 10f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 2.059999942779541) / 0.039999999105930328));
        }
        else if ((double) this.mShowItemTime < 2.1600000858306885)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(10f, 10f);
          this.mStone_End = this.mStone_Start + new Vector2(10f, 0.0f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 2.0999999046325684) / 0.05000000074505806));
        }
        else if ((double) this.mShowItemTime < 2.2000000476837158)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(10f, 0.0f);
          this.mStone_End = this.mStone_Start + new Vector2(-10f, 0.0f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 2.1600000858306885) / 0.039999999105930328));
        }
        else if ((double) this.mShowItemTime < 2.2300000190734863)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(-10f, 0.0f);
          this.mStone_End = this.mStone_Start + new Vector2(0.0f, 10f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 2.2000000476837158) / 0.029999999329447746));
        }
        else if ((double) this.mShowItemTime < 2.2599999904632568)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(0.0f, 10f);
          this.mStone_End = this.mStone_Start + new Vector2(-10f, 0.0f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 2.2300000190734863) / 0.029999999329447746));
        }
        else if ((double) this.mShowItemTime < 2.2999999523162842)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(-10f, 0.0f);
          this.mStone_End = this.mStone_Start + new Vector2(0.0f, 10f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 2.2599999904632568) / 0.039999999105930328));
        }
        else if ((double) this.mShowItemTime < 2.3599998950958252)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(0.0f, 10f);
          this.mStone_End = this.mStone_Start + new Vector2(-20f, 0.0f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 2.2999999523162842) / 0.059999998658895493));
        }
        else if ((double) this.mShowItemTime < 2.4000000953674316)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(-20f, 0.0f);
          this.mStone_End = this.mStone_Start + new Vector2(0.0f, 10f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 2.3599998950958252) / 0.039999999105930328));
        }
        else if ((double) this.mShowItemTime < 2.4600000381469727)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(0.0f, 10f);
          this.mStone_End = this.mStone_Start + new Vector2(-10f, 10f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 2.4000000953674316) / 0.059999998658895493));
        }
        else if ((double) this.mShowItemTime < 2.559999942779541)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(-10f, 10f);
          this.mStone_End = this.mStone_Start + new Vector2(-20f, 30f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 2.4600000381469727) / 0.10000000149011612));
        }
        else if ((double) this.mShowItemTime < 2.6700000762939453)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(-20f, 30f);
          this.mStone_End = this.mStone_Start + new Vector2(-60f, 10f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 2.559999942779541) / 0.10999999940395355));
        }
        else if ((double) this.mShowItemTime < 2.9000000953674316)
        {
          this.mStone_Move = this.mStone_Start + new Vector2(-60f, 10f);
          this.mStone_End = this.mStone_Start + new Vector2(-23f, 46f);
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (float) (((double) this.mShowItemTime - 2.6700000762939453) / 0.23000000417232513));
        }
        else
          ((Graphic) this.Img_PetStone).rectTransform.anchoredPosition = this.mStone_Start;
        this.scaleCount = (double) this.mShowItemTime >= 0.5 ? ((double) this.mShowItemTime >= 0.800000011920929 ? ((double) this.mShowItemTime >= 1.1000000238418579 ? ((double) this.mShowItemTime >= 1.2999999523162842 ? ((double) this.mShowItemTime >= 2.4000000953674316 ? ((double) this.mShowItemTime >= 2.5299999713897705 ? ((double) this.mShowItemTime >= 3.2300000190734863 ? 10f : Mathf.Lerp(3f, 10f, (float) (((double) this.mShowItemTime - 2.5299999713897705) / 0.60000002384185791))) : Mathf.Lerp(0.5f, 3f, (float) (((double) this.mShowItemTime - 2.5299999713897705) / 0.12999999523162842))) : 0.5f) : Mathf.Lerp(0.4f, 0.5f, (float) (((double) this.mShowItemTime - 1.1000000238418579) / 0.20000000298023224))) : Mathf.Lerp(0.8f, 0.4f, (float) (((double) this.mShowItemTime - 0.800000011920929) / 0.30000001192092896))) : Mathf.Lerp(0.0f, 0.8f, (float) (((double) this.mShowItemTime - 0.5) / 0.30000001192092896))) : 0.0f;
        ((Transform) ((Graphic) this.Img_PetStone).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
        this.scaleCount = (double) this.mShowItemTime >= 0.5 ? ((double) this.mShowItemTime >= 0.67000001668930054 ? ((double) this.mShowItemTime >= 1.1000000238418579 ? ((double) this.mShowItemTime >= 2.4000000953674316 ? ((double) this.mShowItemTime >= 2.7699999809265137 ? 0.0f : Mathf.Lerp(1f, 0.0f, (float) (((double) this.mShowItemTime - 2.4000000953674316) / 0.37000000476837158))) : Mathf.Lerp(0.8f, 1f, (float) (((double) this.mShowItemTime - 1.1000000238418579) / 1.2999999523162842))) : Mathf.Lerp(0.5f, 0.8f, (float) (((double) this.mShowItemTime - 0.67000001668930054) / 0.43000000715255737))) : Mathf.Lerp(0.0f, 0.5f, (float) (((double) this.mShowItemTime - 0.5) / 0.17000000178813934))) : 0.0f;
        ((Graphic) this.Img_PetStone).color = new Color(1f, 1f, 1f, this.scaleCount);
        if ((double) this.mShowItemTime >= 2.5)
        {
          if ((double) this.mShowItemTime < 2.7000000476837158)
          {
            this.scaleCount = Mathf.Lerp(0.0f, 1f, (float) (((double) this.mShowItemTime - 2.5) / 0.20000000298023224));
            ((Transform) this.mPetPosRT).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
            this.mPetPosRT.anchoredPosition = Vector2.Lerp(new Vector2(0.0f, 100f), this.tmpPetLocal, (float) (((double) this.mShowItemTime - 2.5) / 0.20000000298023224));
          }
          else
          {
            ((Component) this.Img_Light).gameObject.SetActive(true);
            ((Component) this.Img_Light_2).gameObject.SetActive(true);
            ((Component) this.Img_Rare).gameObject.SetActive(true);
            ((Component) this.PetTitleText).gameObject.SetActive(true);
            ((Component) this.PetNameText).gameObject.SetActive(true);
            if ((Object) this.AB_Pet == (Object) null)
              ((Component) this.Hbtm_Pet).gameObject.SetActive(true);
            this.bPet3DShow = true;
            this.scaleCount = 1f;
            ((Transform) this.mPetPosRT).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
            this.mPetPosRT.anchoredPosition = this.tmpPetLocal;
            ((Graphic) this.Img_PetStone).color = new Color(1f, 1f, 1f, 0.0f);
          }
        }
        if ((double) this.mShowItemTime >= 2.4000000953674316 && (Object) this.Pet_Move_2 == (Object) null)
        {
          this.Pet_Move_2 = ParticleManager.Instance.Spawn((ushort) 434, ((Component) this.mItemParticleRT).transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
          this.Pet_Move_2.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
          this.Pet_Move_2.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
          this.GUIM.SetLayer(this.Pet_Move_2, 5);
          AudioManager.Instance.PlayUISFX(UIKind.GainPetRookie);
        }
      }
      if (this.bPet3DShow && !this.bPet3DClose && (double) this.mShowItemTime > 10.0 && (Object) this.Img_wave != (Object) null && (Object) this.Img_hand != (Object) null && !((Component) this.Img_wave).gameObject.activeSelf)
      {
        ((Component) this.Img_wave).gameObject.SetActive(true);
        ((Component) this.Img_hand).gameObject.SetActive(true);
      }
      if (this.bPet3DShow && this.bPet3DClose && !this.bPetNextOne)
      {
        ((Graphic) this.Img_PetStone).color = new Color(1f, 1f, 1f, 0.0f);
        if ((Object) this.Pet_Move_1 == (Object) null)
        {
          this.mParticle_MoveRT.anchoredPosition = Vector2.zero;
          this.Pet_Move_1 = ParticleManager.Instance.Spawn((ushort) 435, ((Component) this.mParticle_MoveRT).transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
          this.Pet_Move_1.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
          this.Pet_Move_1.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
          this.GUIM.SetLayer(this.Pet_Move_1, 5);
          AudioManager.Instance.PlayUISFX(UIKind.PetAppear);
        }
        if ((double) this.mShowItemTime < 0.699999988079071)
        {
          this.scaleCount = Mathf.Lerp(1f, 1.2f, this.mShowItemTime / 0.7f);
          ((Transform) this.mPetPosRT).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
        }
        else if ((double) this.mShowItemTime < 0.89999997615814209)
        {
          if (((Component) this.Hbtm_Pet).gameObject.activeSelf)
            ((Component) this.Hbtm_Pet).gameObject.SetActive(false);
          this.scaleCount = Mathf.Lerp(1.2f, 0.3f, (float) (((double) this.mShowItemTime - 0.699999988079071) / 0.20000000298023224));
          ((Transform) this.mPetPosRT).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
          this.mPetPosRT.anchoredPosition = Vector2.Lerp(this.tmpPetLocal, new Vector2(this.tmpPetLocal.x, this.tmpPetLocal.y + 100f), (float) (((double) this.mShowItemTime - 0.699999988079071) / 0.20000000298023224));
        }
        else if ((double) this.mShowItemTime < 1.0)
        {
          this.scaleCount = Mathf.Lerp(0.3f, 0.0f, (float) (((double) this.mShowItemTime - 0.89999997615814209) / 0.10000000149011612));
          ((Transform) this.mPetPosRT).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
          this.mPetPosRT.anchoredPosition = new Vector2(this.tmpPetLocal.x, this.tmpPetLocal.y + 100f);
        }
        else if ((double) this.mShowItemTime < 1.3999999761581421)
        {
          this.scaleCount = 0.0f;
          ((Transform) this.mPetPosRT).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
          this.mPetPosRT.anchoredPosition = new Vector2(this.tmpPetLocal.x, this.tmpPetLocal.y + 100f);
          ((Component) this.Img_Light).gameObject.SetActive(false);
          ((Component) this.Img_Light_2).gameObject.SetActive(false);
          ((Component) this.Img_Rare).gameObject.SetActive(false);
          ((Component) this.PetTitleText).gameObject.SetActive(false);
          ((Component) this.PetNameText).gameObject.SetActive(false);
          if (this.mShowItemNum < (byte) 8)
          {
            this.bezierEnd = new Vector2((float) (180 * ((int) this.mShowItemNum % 4) - 272), (float) (117 - 140 * ((int) this.mShowItemNum / 4)));
          }
          else
          {
            this.tmpCount = this.PM.mItemCraftList.Count % 4;
            if (this.tmpCount == 0)
              this.tmpCount = 4;
            this.bezierEnd = (int) this.mShowItemNum >= this.PM.mItemCraftList.Count - this.tmpCount ? new Vector2((float) (183 * ((int) this.mShowItemNum % 4) - 272), -231f) : new Vector2((float) (183 * ((int) this.mShowItemNum % 4) - 272), -101f);
          }
          this.mPetRT.anchoredPosition = Vector2.Lerp(new Vector2(0.0f, -100f), this.bezierEnd, (float) (((double) this.mShowItemTime - 1.0) / 0.40000000596046448));
          this.mParticle_MoveRT.anchoredPosition = Vector2.Lerp(this.tmpPetLocal, this.bezierEnd, (float) (((double) this.mShowItemTime - 1.0) / 0.40000000596046448));
          if ((Object) this.Pet_Move_3 == (Object) null)
          {
            this.Pet_Move_3 = ParticleManager.Instance.Spawn((ushort) 436, ((Component) this.mParticle_MoveRT).transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
            this.Pet_Move_3.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            this.Pet_Move_3.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            this.GUIM.SetLayer(this.Pet_Move_3, 5);
          }
        }
        else if ((double) this.mShowItemTime >= 1.3999999761581421)
          this.bPetNextOne = true;
      }
      if (this.bPet3DClose && this.bPet3DShow && this.bPetNextOne)
      {
        this.mShowItemTime = 0.0f;
        this.mScrollTime = 0.0f;
        this.IsShowItem[(int) this.mShowItemNum] = true;
        ++this.mShowItemNum;
        this.mStatus = (byte) 2;
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        if (this.mShowItemNum > (byte) 4 && (int) this.mShowItemNum % 4 == 0)
          this.bStarMove = true;
        this.bPet3DClose = false;
        this.bPet3DShow = false;
        this.bPetNextOne = false;
        this.DestroyPet3D();
        ((Component) this.mPetRT).gameObject.SetActive(false);
        AudioManager.Instance.PlayUISFX(UIKind.PetFly);
      }
    }
    else if (this.mStatus == (byte) 2 || this.mStatus == (byte) 4)
    {
      if (this.mShowItemNum <= (byte) 0)
        return;
      this.mScrollTime += Time.smoothDeltaTime;
      byte index3 = (byte) (((int) this.mShowItemNum - 1) / 4 % 5);
      byte index4 = (byte) (((int) this.mShowItemNum - 1) % 4);
      if (this.bPlayJizz)
        this.bPlayJizz = false;
      if ((double) this.mScrollTime < 0.029999999329447746)
      {
        this.scaleCount = Mathf.Lerp(1f, 1.2f, this.mScrollTime / 0.03f);
        ((Transform) this.mItemRT[(int) index3][(int) index4]).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
      }
      else if ((double) this.mScrollTime < 0.12999999523162842)
      {
        this.scaleCount = Mathf.Lerp(1.2f, 1f, (float) (((double) this.mScrollTime - 0.029999999329447746) / 0.10000000149011612));
        ((Transform) this.mItemRT[(int) index3][(int) index4]).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
      }
      else if ((double) this.mScrollTime < 0.25999999046325684)
      {
        this.scaleCount = Mathf.Lerp(1f, 1.5f, (float) (((double) this.mScrollTime - 0.12999999523162842) / 0.12999999523162842));
        ((Transform) this.mItemRT[(int) index3][(int) index4]).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
      }
      else if ((double) this.mScrollTime < 0.46000000834465027)
      {
        this.scaleCount = Mathf.Lerp(1.5f, 1f, (float) (((double) this.mScrollTime - 0.25999999046325684) / 0.20000000298023224));
        ((Transform) this.mItemRT[(int) index3][(int) index4]).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
      }
      else
      {
        if (this.mStatus == (byte) 2)
        {
          if ((int) this.PM.mPetItemNum < (int) this.mShowItemNum + 1)
          {
            this.mStatus = (byte) 0;
            this.bStarShow = true;
            ((Component) this.mPetRT).gameObject.SetActive(false);
            ((Component) this.Img_BG).gameObject.SetActive(false);
          }
          else
            this.mStatus = (byte) 1;
          this.mPetPosRT.anchoredPosition = this.tmpPetLocal;
          this.mParticle_MoveRT.anchoredPosition = this.tmpPetLocal;
          if ((Object) this.EffectParticle != (Object) null)
          {
            if (this.EffectParticle.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
            {
              this.EffectParticle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
              this.EffectParticle.SetActive(false);
              this.EffectParticle.SetActive(true);
            }
            this.EffectParticle = (GameObject) null;
          }
          if ((Object) this.Pet_Move_1 != (Object) null)
          {
            if (this.Pet_Move_1.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
            {
              this.Pet_Move_1.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
              this.Pet_Move_1.SetActive(false);
              this.Pet_Move_1.SetActive(true);
            }
            this.Pet_Move_1 = (GameObject) null;
          }
          if ((Object) this.Pet_Move_3 != (Object) null)
          {
            if (this.Pet_Move_3.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
            {
              this.Pet_Move_3.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
              this.Pet_Move_3.SetActive(false);
              this.Pet_Move_3.SetActive(true);
            }
            this.Pet_Move_3 = (GameObject) null;
          }
        }
        else
          this.mStatus = (byte) 3;
        this.mScrollTime = 0.0f;
        this.mShowItemTime = 0.0f;
        this.scaleCount = 1f;
        ((Transform) this.mItemRT[(int) index3][(int) index4]).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
      }
    }
    else if (this.mStatus == (byte) 3)
    {
      if (this.mShowItemNum <= (byte) 0)
        return;
      this.mScrollTime += Time.smoothDeltaTime;
      byte index5 = (byte) (((int) this.mShowItemNum - 1) / 4 % 5);
      byte index6 = (byte) (((int) this.mShowItemNum - 1) % 4);
      if ((double) this.mScrollTime < (double) this.mTotalTime / 4.0)
      {
        this.scaleCount = Mathf.Lerp(1f, 1.75f, this.mScrollTime / (this.mTotalTime / 4f));
        if (this.GUIM.IsArabic)
          ((Transform) ((Graphic) this.text_ItemCount3[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
        else
          ((Transform) ((Graphic) this.text_ItemCount3[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
        if (!((Component) this.text_ItemCount3[(int) index5][(int) index6]).gameObject.activeSelf)
          ((Component) this.text_ItemCount3[(int) index5][(int) index6]).gameObject.SetActive(true);
        this.tmpItemCraftD = this.PM.mItemCraftList[(int) this.mShowItemNum - 1];
        if (this.tmpItemCraftD.mItemKind == (byte) 29)
        {
          if (this.tmpItemCraftD.mPetEnhance == (byte) 2 && !((Component) this.text_ItemCount[(int) index5][(int) index6]).gameObject.activeSelf)
          {
            this.scaleCount = 1f;
            if (this.GUIM.IsArabic)
              ((Transform) ((Graphic) this.text_ItemCount[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
            else
              ((Transform) ((Graphic) this.text_ItemCount[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
            ((Component) this.text_ItemCount[(int) index5][(int) index6]).gameObject.SetActive(true);
          }
          else if (this.tmpItemCraftD.mPetEnhance < (byte) 2 && !((Component) this.text_ItemCount1[(int) index5][(int) index6]).gameObject.activeSelf)
          {
            this.scaleCount = 1f;
            if (this.GUIM.IsArabic)
              ((Transform) ((Graphic) this.text_ItemCount1[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
            else
              ((Transform) ((Graphic) this.text_ItemCount1[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
            ((Component) this.text_ItemCount1[(int) index5][(int) index6]).gameObject.SetActive(true);
            ((Component) this.text_ItemCount2[(int) index5][(int) index6]).gameObject.SetActive(true);
          }
        }
        this.scaleCount = Mathf.Lerp(1f, 2f, this.mScrollTime / (this.mTotalTime / 4f));
        if (((Component) this.text_ItemCount1[(int) index5][(int) index6]).gameObject.activeSelf)
        {
          if (this.GUIM.IsArabic)
            ((Transform) ((Graphic) this.text_ItemCount1[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
          else
            ((Transform) ((Graphic) this.text_ItemCount1[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
          ((Graphic) this.text_ItemCount1[(int) index5][(int) index6]).rectTransform.anchoredPosition = new Vector2((float) (-23.0 - ((double) this.scaleCount - 1.0) * 20.0), ((Graphic) this.text_ItemCount1[(int) index5][(int) index6]).rectTransform.anchoredPosition.y);
        }
        if (((Component) this.text_ItemCount[(int) index5][(int) index6]).gameObject.activeSelf)
        {
          if (this.GUIM.IsArabic)
            ((Transform) ((Graphic) this.text_ItemCount[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
          else
            ((Transform) ((Graphic) this.text_ItemCount[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
        }
      }
      else if ((double) this.mScrollTime < (double) this.mTotalTime / 2.0)
      {
        this.scaleCount = Mathf.Lerp(1.75f, 1f, (float) (((double) this.mScrollTime - (double) this.mTotalTime / 4.0) / ((double) this.mTotalTime / 4.0)));
        if (this.GUIM.IsArabic)
          ((Transform) ((Graphic) this.text_ItemCount3[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
        else
          ((Transform) ((Graphic) this.text_ItemCount3[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
        this.scaleCount = Mathf.Lerp(2f, 1f, (float) (((double) this.mScrollTime - (double) this.mTotalTime / 4.0) / ((double) this.mTotalTime / 4.0)));
        if (((Component) this.text_ItemCount1[(int) index5][(int) index6]).gameObject.activeSelf)
        {
          this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.tmpItemCraftD.ItemID);
          this.tmpPT = this.PM.PetTable.GetRecordByKey(this.tmpEQ.SyntheticParts[0].SyntheticItem);
          if ((int) this.tmpItemCraftD.Num >= (int) this.PM.GetEvoNeed_Stone(this.tmpItemCraftD.mPetEnhance, this.tmpPT.Rare))
            ((Graphic) this.text_ItemCount1[(int) index5][(int) index6]).color = Color.green;
          if (this.GUIM.IsArabic)
            ((Transform) ((Graphic) this.text_ItemCount1[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
          else
            ((Transform) ((Graphic) this.text_ItemCount1[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
          ((Graphic) this.text_ItemCount1[(int) index5][(int) index6]).rectTransform.anchoredPosition = new Vector2((float) (-23.0 - ((double) this.scaleCount - 1.0) * 20.0), ((Graphic) this.text_ItemCount1[(int) index5][(int) index6]).rectTransform.anchoredPosition.y);
        }
        if (((Component) this.text_ItemCount[(int) index5][(int) index6]).gameObject.activeSelf)
        {
          if (this.GUIM.IsArabic)
            ((Transform) ((Graphic) this.text_ItemCount[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
          else
            ((Transform) ((Graphic) this.text_ItemCount[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
        }
      }
      else
      {
        this.scaleCount = 1f;
        if (this.GUIM.IsArabic)
          ((Transform) ((Graphic) this.text_ItemCount3[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
        else
          ((Transform) ((Graphic) this.text_ItemCount3[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
        this.scaleCount = 1f;
        if (((Component) this.text_ItemCount1[(int) index5][(int) index6]).gameObject.activeSelf)
        {
          if (this.GUIM.IsArabic)
            ((Transform) ((Graphic) this.text_ItemCount1[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
          else
            ((Transform) ((Graphic) this.text_ItemCount1[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
          ((Graphic) this.text_ItemCount1[(int) index5][(int) index6]).rectTransform.anchoredPosition = new Vector2((float) (-23.0 - ((double) this.scaleCount - 1.0) * 20.0), ((Graphic) this.text_ItemCount1[(int) index5][(int) index6]).rectTransform.anchoredPosition.y);
        }
        if (((Component) this.text_ItemCount[(int) index5][(int) index6]).gameObject.activeSelf)
        {
          if (this.GUIM.IsArabic)
            ((Transform) ((Graphic) this.text_ItemCount[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
          else
            ((Transform) ((Graphic) this.text_ItemCount[(int) index5][(int) index6]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
        }
        if (this.mShowItemNum > (byte) 4 && (int) this.mShowItemNum % 4 == 0)
          this.bStarMove = true;
        this.mStatus = (byte) 0;
        this.mScrollTime = 0.0f;
        if ((Object) this.mItemMove_1 != (Object) null)
        {
          if (this.mItemMove_1.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
          {
            this.mItemMove_1.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
            this.mItemMove_1.gameObject.SetActive(false);
            this.mItemMove_1.gameObject.SetActive(true);
          }
          this.mItemMove_1 = (GameObject) null;
        }
        if ((Object) this.mItemMove_2 != (Object) null)
        {
          if (this.mItemMove_2.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
          {
            this.mItemMove_2.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
            this.mItemMove_2.gameObject.SetActive(false);
            this.mItemMove_2.gameObject.SetActive(true);
          }
          this.mItemMove_2 = (GameObject) null;
        }
        this.mItemParticle_MoveRT.anchoredPosition = this.tmpParticle;
      }
    }
    if (this.bStarMove && (Object) this.mContentRT != (Object) null)
    {
      if ((double) this.mScrollY + (double) this.mScrollDis + 478.0 >= (double) this.mContentRT.sizeDelta.y)
        this.mScrollDis = this.mContentRT.sizeDelta.y - (this.mScrollY + 478f);
      if ((double) this.mScrollDis < 0.0)
        this.mScrollDis = 0.0f;
      this.mScrollTime += Time.smoothDeltaTime;
      if ((double) this.mScrollTime < (double) this.mTotalTime / 2.0)
      {
        this.mContentRT.anchoredPosition = new Vector2(this.mContentRT.anchoredPosition.x, this.mScrollY + this.mScrollDis * (this.mScrollTime / this.mTotalTime));
      }
      else
      {
        this.mContentRT.anchoredPosition = new Vector2(this.mContentRT.anchoredPosition.x, this.mScrollY + this.mScrollDis);
        this.bStarMove = false;
        this.mScrollTime = 0.0f;
        this.mScrollY += this.mScrollDis;
      }
    }
    if (this.bAB_PetInitial || !((Object) this.AB_Pet != (Object) null) || this.AR_Pet == null || !this.AR_Pet.isDone)
      return;
    this.PetGO = ModelLoader.Instance.Load(this.sHero.Modle, this.AB_Pet, (ushort) this.sHero.TextureNo);
    this.PetGO.transform.SetParent((Transform) this.mPetPosRT, false);
    this.PetGO.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
    {
      eulerAngles = new Vector3(0.0f, (float) this.sHero.Camera_Horizontal, 0.0f)
    };
    if ((int) this.mShowItemNum < this.PM.mItemCraftList.Count)
      this.tmpItemCraftD = this.PM.mItemCraftList[(int) this.mShowItemNum];
    this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.tmpItemCraftD.ItemID);
    this.tmpPT = this.PM.PetTable.GetRecordByKey(this.tmpEQ.SyntheticParts[0].SyntheticItem);
    this.mPetscaleCount = (float) this.tmpPT.StartupRatio.Ratio;
    this.PetGO.transform.localScale = new Vector3(this.mPetscaleCount, this.mPetscaleCount, this.mPetscaleCount);
    this.GUIM.SetLayer(this.PetGO, 5);
    this.PetModel = ((Transform) this.mPetPosRT).GetChild(0).GetComponent<Transform>();
    if ((Object) this.PetModel != (Object) null)
    {
      this.tmpAN_Pet = this.PetModel.GetComponent<Animation>();
      this.tmpAN_Pet.wrapMode = WrapMode.Loop;
      this.tmpAN_Pet.cullingType = AnimationCullingType.AlwaysAnimate;
      this.tmpAN_Pet.Play("idle");
      this.tmpAN_Pet.clip = this.tmpAN_Pet.GetClip("idle");
      if (this.PetModel.gameObject.activeSelf)
      {
        SkinnedMeshRenderer componentInChildren = this.PetModel.GetComponentInChildren<SkinnedMeshRenderer>();
        componentInChildren.useLightProbes = false;
        componentInChildren.updateWhenOffscreen = true;
      }
    }
    this.bAB_PetInitial = true;
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.TitleNameText != (Object) null && ((Behaviour) this.TitleNameText).enabled)
    {
      ((Behaviour) this.TitleNameText).enabled = false;
      ((Behaviour) this.TitleNameText).enabled = true;
    }
    if ((Object) this.GetAllText != (Object) null && ((Behaviour) this.GetAllText).enabled)
    {
      ((Behaviour) this.GetAllText).enabled = false;
      ((Behaviour) this.GetAllText).enabled = true;
    }
    if ((Object) this.PetTitleText != (Object) null && ((Behaviour) this.PetTitleText).enabled)
    {
      ((Behaviour) this.PetTitleText).enabled = false;
      ((Behaviour) this.PetTitleText).enabled = true;
    }
    if ((Object) this.PetNameText != (Object) null && ((Behaviour) this.PetNameText).enabled)
    {
      ((Behaviour) this.PetNameText).enabled = false;
      ((Behaviour) this.PetNameText).enabled = true;
    }
    if ((Object) this.text_Rare != (Object) null && ((Behaviour) this.text_Rare).enabled)
    {
      ((Behaviour) this.text_Rare).enabled = false;
      ((Behaviour) this.text_Rare).enabled = true;
    }
    if ((Object) this.text_HintName != (Object) null && ((Behaviour) this.text_HintName).enabled)
    {
      ((Behaviour) this.text_HintName).enabled = false;
      ((Behaviour) this.text_HintName).enabled = true;
    }
    if ((Object) this.text_HintRare != (Object) null && ((Behaviour) this.text_HintRare).enabled)
    {
      ((Behaviour) this.text_HintRare).enabled = false;
      ((Behaviour) this.text_HintRare).enabled = true;
    }
    if ((Object) this.text_HintRare2 != (Object) null && ((Behaviour) this.text_HintRare2).enabled)
    {
      ((Behaviour) this.text_HintRare2).enabled = false;
      ((Behaviour) this.text_HintRare2).enabled = true;
    }
    if ((Object) this.text_HintInfo != (Object) null && ((Behaviour) this.text_HintInfo).enabled)
    {
      ((Behaviour) this.text_HintInfo).enabled = false;
      ((Behaviour) this.text_HintInfo).enabled = true;
    }
    for (int index1 = 0; index1 < 5; ++index1)
    {
      for (int index2 = 0; index2 < 4; ++index2)
      {
        if ((Object) this.text_ItemName[index1][index2] != (Object) null && ((Behaviour) this.text_ItemName[index1][index2]).enabled)
        {
          ((Behaviour) this.text_ItemName[index1][index2]).enabled = false;
          ((Behaviour) this.text_ItemName[index1][index2]).enabled = true;
        }
        if ((Object) this.text_ItemCount[index1][index2] != (Object) null && ((Behaviour) this.text_ItemCount[index1][index2]).enabled)
        {
          ((Behaviour) this.text_ItemCount[index1][index2]).enabled = false;
          ((Behaviour) this.text_ItemCount[index1][index2]).enabled = true;
        }
        if ((Object) this.text_ItemCount1[index1][index2] != (Object) null && ((Behaviour) this.text_ItemCount1[index1][index2]).enabled)
        {
          ((Behaviour) this.text_ItemCount1[index1][index2]).enabled = false;
          ((Behaviour) this.text_ItemCount1[index1][index2]).enabled = true;
        }
        if ((Object) this.text_ItemCount2[index1][index2] != (Object) null && ((Behaviour) this.text_ItemCount2[index1][index2]).enabled)
        {
          ((Behaviour) this.text_ItemCount2[index1][index2]).enabled = false;
          ((Behaviour) this.text_ItemCount2[index1][index2]).enabled = true;
        }
        if ((Object) this.text_ItemCount3[index1][index2] != (Object) null && ((Behaviour) this.text_ItemCount3[index1][index2]).enabled)
        {
          ((Behaviour) this.text_ItemCount3[index1][index2]).enabled = false;
          ((Behaviour) this.text_ItemCount3[index1][index2]).enabled = true;
        }
        if ((Object) this.Hbtn_PetItems[index1][index2] != (Object) null && ((Behaviour) this.Hbtn_PetItems[index1][index2]).enabled)
          this.Hbtn_PetItems[index1][index2].Refresh_FontTexture();
        if ((Object) this.Hbtn_Items[index1][index2] != (Object) null && ((Behaviour) this.Hbtn_Items[index1][index2]).enabled)
          this.Hbtn_Items[index1][index2].Refresh_FontTexture();
      }
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh_Item:
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void LoadPet3D()
  {
    this.bLoadPet3D = true;
    this.mPetRT.anchoredPosition = new Vector2(0.0f, -100f);
    ((Transform) this.mPetRT).localScale = Vector3.one;
    ((Component) this.Hbtm_Pet).gameObject.SetActive(false);
    CString Name = StringManager.Instance.StaticString1024();
    if ((int) this.mShowItemNum < this.PM.mItemCraftList.Count)
      this.tmpItemCraftD = this.PM.mItemCraftList[(int) this.mShowItemNum];
    this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.tmpItemCraftD.ItemID);
    this.tmpPT = this.PM.PetTable.GetRecordByKey(this.tmpEQ.SyntheticParts[0].SyntheticItem);
    this.sHero = this.DM.HeroTable.GetRecordByKey(this.tmpPT.HeroID);
    Name.ClearString();
    Name.IntToFormat((long) this.sHero.Modle, 5);
    Name.AppendFormat("Role/hero_{0}");
    if (this.sHero.Modle > (ushort) 0 && AssetManager.GetAssetBundleDownload(Name, AssetPath.Role, AssetType.Hero, this.sHero.Modle))
    {
      this.AB_Pet = AssetManager.GetAssetBundle(Name, out this.AssetKeyPet);
      if ((Object) this.AB_Pet != (Object) null)
      {
        this.AR_Pet = this.AB_Pet.LoadAsync("m", typeof (GameObject));
        this.bAB_PetInitial = false;
      }
    }
    else
      this.AB_Pet = (AssetBundle) null;
    this.Cstr_PetName.ClearString();
    this.Cstr_PetName.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpPT.Name));
    this.Cstr_PetName.AppendFormat(this.DM.mStringTable.GetStringByID(10104U));
    this.PetNameText.text = this.Cstr_PetName.ToString();
    this.PetNameText.SetAllDirty();
    this.PetNameText.cachedTextGenerator.Invalidate();
    this.PetNameText.cachedTextGeneratorForLayout.Invalidate();
    ((Graphic) this.Img_Rare).rectTransform.anchoredPosition = new Vector2((float) (-((double) this.PetNameText.preferredWidth / 2.0) - 30.0), ((Graphic) this.Img_Rare).rectTransform.anchoredPosition.y);
    this.text_Rare.text = this.tmpPT.Rare.ToString();
    this.text_Rare.SetAllDirty();
    this.text_Rare.cachedTextGenerator.Invalidate();
    this.tmpPetLocal = new Vector2(this.mPetPosRT.anchoredPosition.x, (float) -(1000 - (int) this.tmpPT.StartupRatio.UpDownDist));
    this.GUIM.ChangeHeroItemImg(((Component) this.Hbtm_Pet).transform, eHeroOrItem.Pet, this.tmpItemCraftD.mPetID, this.tmpItemCraftD.ItemRank, (byte) 0);
  }

  public void DestroyPet3D()
  {
    this.bLoadPet3D = false;
    if ((Object) this.PetGO != (Object) null)
    {
      ModelLoader.Instance.Unload((Object) this.PetGO);
      this.PetGO = (GameObject) null;
    }
    if ((Object) this.PetModel != (Object) null)
    {
      Object.Destroy((Object) this.PetModel);
      this.PetModel = (Transform) null;
    }
    if (this.AssetKeyPet == 0)
      return;
    AssetManager.UnloadAssetBundle(this.AssetKeyPet, false);
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
