// Decompiled with JetBrains decompiler
// Type: UISimpleItemInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UISimpleItemInfo : IUIHIBtnClickHandler
{
  public RectTransform m_RectTransform;
  public RectTransform m_BackRect;
  public RectTransform m_ItemRect;
  public RectTransform ItemPanel;
  public RectTransform HeroPanel;
  public RectTransform rectProperties;
  public UIHIBtn m_ItemBtn;
  public UIHIBtn m_HeroBtn;
  public UIText m_Name;
  public UIText m_ItemLvText;
  public UIText m_ItemKindText;
  public UIText m_OwnedText;
  public UIText m_Properties;
  public UIText m_Price;
  public UIText m_HeroName;
  public UIText m_HeroLV;
  public Image m_Coin;
  public UIButtonHint m_ButtonHint;
  public CustomImage BossIcon;
  public CustomImage InfoIcon;
  public CanvasGroup Canvasgroup;
  public CanvasGroup ItemBtnRayCast;
  private float OriHeight;
  private float OriTextHeight;
  private CString NameStr;
  private CString PropertiesStr;
  private CString HeroNameStr;
  private CString OwnedStr;
  private CString PriceStr;
  private CString AddionalStr;
  private GameObject CNBossIconObj;
  private GameObject ItemGo;
  private Vector2 ItemPosUpset = new Vector2(61f, -59f);
  private ushort HeroID;

  public void Load()
  {
    UnityEngine.Object original = GUIManager.Instance.m_ManagerAssetBundle.Load(nameof (UISimpleItemInfo));
    if (original == (UnityEngine.Object) null)
      return;
    GUIManager instance = GUIManager.Instance;
    Font ttfFont = instance.GetTTFFont();
    GameObject gameObject = (GameObject) UnityEngine.Object.Instantiate(original);
    gameObject.transform.SetParent((Transform) GUIManager.Instance.m_ItemInfoLayer, false);
    gameObject.SetActive(false);
    this.m_RectTransform = (RectTransform) gameObject.transform;
    this.m_BackRect = ((Transform) this.m_RectTransform).GetChild(0).GetComponent<RectTransform>();
    ((Component) this.m_BackRect).GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    this.Canvasgroup = ((Component) this.m_RectTransform).GetComponent<CanvasGroup>();
    Transform child = ((Transform) this.m_RectTransform).GetChild(1);
    child.GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    this.InfoIcon = child.GetChild(0).GetComponent<CustomImage>();
    this.InfoIcon.hander = (UILoadImageHander) instance.m_ItemInfo;
    this.m_ItemBtn = child.GetComponent<UIHIBtn>();
    this.m_ItemBtn.m_Handler = (IUIHIBtnClickHandler) this;
    instance.InitianHeroItemImg(child, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false, bScaleBtn: true);
    this.ItemBtnRayCast = child.GetComponent<CanvasGroup>();
    this.ItemGo = child.gameObject;
    this.m_ItemRect = child.GetComponent<RectTransform>();
    ((Component) this.InfoIcon).transform.SetAsLastSibling();
    this.m_HeroBtn = ((Transform) this.m_BackRect).GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
    instance.InitianHeroItemImg(((Component) this.m_HeroBtn).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
    ((Component) this.m_HeroBtn).transform.GetChild(0).gameObject.SetActive(true);
    this.CNBossIconObj = ((Transform) this.m_BackRect).GetChild(1).GetChild(2).gameObject;
    this.m_Name = ((Transform) this.m_BackRect).GetChild(2).GetComponent<UIText>();
    this.m_Name.font = ttfFont;
    this.m_OwnedText = ((Transform) this.m_BackRect).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.m_OwnedText.font = ttfFont;
    this.m_Properties = ((Transform) this.m_BackRect).GetChild(3).GetComponent<UIText>();
    this.m_Properties.font = ttfFont;
    ((Transform) this.m_BackRect).GetChild(0).GetChild(1).GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    this.BossIcon = ((Transform) this.m_BackRect).GetChild(1).GetChild(1).GetComponent<CustomImage>();
    this.BossIcon.hander = (UILoadImageHander) instance.m_ItemInfo;
    ((Transform) this.m_BackRect).GetChild(1).GetChild(2).GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    if (instance.IsArabic)
      ((Transform) ((Graphic) this.BossIcon).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
    this.m_Price = ((Transform) this.m_BackRect).GetChild(0).GetChild(2).GetComponent<UIText>();
    this.m_Price.font = ttfFont;
    this.m_HeroLV = ((Transform) this.m_BackRect).GetChild(1).GetChild(3).GetComponent<UIText>();
    this.m_HeroLV.font = ttfFont;
    this.ItemPanel = ((Transform) this.m_BackRect).GetChild(0) as RectTransform;
    this.HeroPanel = ((Transform) this.m_BackRect).GetChild(1) as RectTransform;
    this.m_ItemLvText = ((Transform) this.ItemPanel).GetChild(3).GetComponent<UIText>();
    this.m_ItemLvText.font = ttfFont;
    this.m_ItemKindText = ((Transform) this.ItemPanel).GetChild(4).GetComponent<UIText>();
    this.m_ItemKindText.font = ttfFont;
    this.m_HeroName = ((Transform) this.HeroPanel).GetChild(4).GetComponent<UIText>();
    this.m_HeroName.font = ttfFont;
    ((Graphic) this.m_HeroName).color = new Color(0.624f, 0.91f, 0.922f);
    this.m_Coin = ((Transform) this.m_BackRect).GetChild(0).GetChild(1).GetComponent<Image>();
    this.OriHeight = this.m_BackRect.sizeDelta.y;
    this.rectProperties = ((Graphic) this.m_Properties).rectTransform;
    this.OriTextHeight = this.rectProperties.sizeDelta.y;
    this.NameStr = StringManager.Instance.SpawnString(100);
    this.PropertiesStr = new CString(500);
    this.HeroNameStr = StringManager.Instance.SpawnString();
    this.OwnedStr = StringManager.Instance.SpawnString();
    this.PriceStr = StringManager.Instance.SpawnString();
    this.AddionalStr = new CString(500);
  }

  public void Unload()
  {
    if ((UnityEngine.Object) this.m_RectTransform == (UnityEngine.Object) null)
      return;
    UnityEngine.Object.Destroy((UnityEngine.Object) ((Component) this.m_RectTransform).gameObject);
    this.m_RectTransform = (RectTransform) null;
    this.m_ItemBtn = (UIHIBtn) null;
    this.m_Name = (UIText) null;
    this.m_OwnedText = (UIText) null;
    this.m_Properties = (UIText) null;
    this.m_Price = (UIText) null;
    this.m_ButtonHint = (UIButtonHint) null;
    StringManager.Instance.DeSpawnString(this.NameStr);
    StringManager.Instance.DeSpawnString(this.HeroNameStr);
    StringManager.Instance.DeSpawnString(this.OwnedStr);
    StringManager.Instance.DeSpawnString(this.PriceStr);
  }

  public void Show(
    UIButtonHint hint,
    ushort ItemID,
    int Num = -1,
    UIButtonHint.ePosition position = UIButtonHint.ePosition.Original,
    Vector3? upsetPoint = null)
  {
    if ((UnityEngine.Object) hint == (UnityEngine.Object) null)
      return;
    if ((UnityEngine.Object) GUIManager.Instance.m_LordInfo.m_ButtonHint != (UnityEngine.Object) null)
      GUIManager.Instance.m_LordInfo.Hide(GUIManager.Instance.m_LordInfo.m_ButtonHint);
    DataManager instance = DataManager.Instance;
    RectTransform transform = hint.transform as RectTransform;
    Equip recordByKey = instance.EquipTable.GetRecordByKey(ItemID);
    if ((UnityEngine.Object) transform == (UnityEngine.Object) null || (int) recordByKey.EquipKey != (int) ItemID)
      return;
    if ((byte) ((uint) recordByKey.EquipKind - 1U) == (byte) 4 && (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.Door) != (UnityEngine.Object) null)
    {
      this.HeroID = recordByKey.SyntheticParts[0].SyntheticItem;
      this.ItemBtnRayCast.blocksRaycasts = true;
      ((Component) this.InfoIcon).gameObject.SetActive(true);
    }
    else
    {
      this.ItemBtnRayCast.blocksRaycasts = false;
      ((Component) this.InfoIcon).gameObject.SetActive(false);
    }
    if (((Component) this.m_HeroBtn).gameObject.activeSelf)
    {
      this.ItemGo.SetActive(true);
      ((Component) this.ItemPanel).gameObject.SetActive(true);
      ((Component) this.HeroPanel).gameObject.SetActive(false);
    }
    ushort x = Num != -1 ? (ushort) Num : instance.GetCurItemQuantity(ItemID, (byte) 0);
    ((Component) this.m_RectTransform).gameObject.SetActive(true);
    ((Transform) this.m_RectTransform).SetAsLastSibling();
    GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_ItemBtn).transform, eHeroOrItem.Item, ItemID, (byte) 0, (byte) 0);
    UIItemInfo.SetNameProperties(this.m_Name, this.m_Properties, this.NameStr, this.PropertiesStr, ref recordByKey, this.AddionalStr);
    if (this.AddionalStr.Length > 0)
    {
      this.PropertiesStr.Append(this.AddionalStr);
      this.m_Properties.text = this.PropertiesStr.ToString();
      this.m_Properties.SetAllDirty();
      this.m_Properties.cachedTextGenerator.Invalidate();
    }
    Vector2 sizeDelta = this.rectProperties.sizeDelta;
    float num1 = this.m_Properties.preferredHeight - this.OriTextHeight;
    sizeDelta.y = this.m_Properties.preferredHeight;
    this.rectProperties.sizeDelta = sizeDelta;
    this.m_BackRect.sizeDelta = this.m_BackRect.sizeDelta with
    {
      y = Mathf.Max(this.OriHeight, this.OriHeight + num1)
    };
    this.HeroNameStr.ClearString();
    EItemType eitemType = (EItemType) ((uint) recordByKey.EquipKind - 1U);
    switch (eitemType)
    {
      case EItemType.EIT_SingleNumSynEquip:
      case EItemType.EIT_MultiNumSynEquip:
        this.HeroNameStr.IntToFormat((long) recordByKey.NeedLv);
        this.HeroNameStr.AppendFormat(instance.mStringTable.GetStringByID(148U));
        this.m_ItemLvText.text = this.HeroNameStr.ToString();
        this.m_ItemLvText.SetAllDirty();
        this.m_ItemLvText.cachedTextGenerator.Invalidate();
        ((Graphic) this.m_ItemLvText).color = new Color(0.46f, 1f, 1f);
        this.m_ItemKindText.text = instance.mStringTable.GetStringByID(886U);
        break;
      case EItemType.EIT_SynBook:
        this.m_ItemKindText.text = instance.mStringTable.GetStringByID((uint) byte.MaxValue);
        break;
      case EItemType.EIT_SynBaseEquip:
        this.m_ItemKindText.text = instance.mStringTable.GetStringByID(254U);
        break;
      case EItemType.EIT_HeroStone:
        this.m_ItemKindText.text = instance.mStringTable.GetStringByID(256U);
        break;
      case EItemType.EIT_Consumables:
        this.m_ItemKindText.text = instance.mStringTable.GetStringByID(253U);
        break;
      case EItemType.EIT_CaseByCase:
        switch ((ECaseByCaseType) recordByKey.PropertiesInfo[0].Propertieskey)
        {
          case ECaseByCaseType.ECBCT_PetCore:
            this.m_ItemKindText.text = instance.mStringTable.GetStringByID(14654U);
            break;
          case ECaseByCaseType.ECBCT_PetMaterial:
            this.m_ItemKindText.text = instance.mStringTable.GetStringByID(879U);
            break;
          default:
            this.m_ItemKindText.text = string.Empty;
            break;
        }
        break;
      default:
        this.m_ItemKindText.text = eitemType == EItemType.EIT_EnhanceStone ? instance.mStringTable.GetStringByID(16050U) : string.Empty;
        break;
    }
    if ((recordByKey.EquipKind != (byte) 18 || recordByKey.PropertiesInfo[2].Propertieskey < (ushort) 1 || recordByKey.PropertiesInfo[2].Propertieskey > (ushort) 2) && (recordByKey.EquipKind != (byte) 11 || recordByKey.PropertiesInfo[0].Propertieskey < (ushort) 6 || recordByKey.PropertiesInfo[0].Propertieskey > (ushort) 7))
    {
      if (recordByKey.EquipKind == (byte) 19 && recordByKey.PropertiesInfo[3].Propertieskey == (ushort) 1)
      {
        this.m_OwnedText.text = string.Empty;
      }
      else
      {
        this.OwnedStr.ClearString();
        this.OwnedStr.Append("(");
        this.OwnedStr.IntToFormat((long) x, bNumber: true);
        this.OwnedStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(79U));
        this.OwnedStr.Append(")");
        ((Graphic) this.m_OwnedText).color = Color.white;
        this.m_OwnedText.text = this.OwnedStr.ToString();
        this.m_OwnedText.SetAllDirty();
        this.m_OwnedText.cachedTextGenerator.Invalidate();
      }
    }
    else
      this.m_OwnedText.text = string.Empty;
    if (recordByKey.RecoverPrice > 0U)
    {
      this.PriceStr.ClearString();
      this.PriceStr.IntToFormat((long) recordByKey.RecoverPrice, bNumber: true);
      this.PriceStr.AppendFormat("{0}");
      this.m_Price.text = this.PriceStr.ToString();
      this.m_Price.SetAllDirty();
      this.m_Price.cachedTextGenerator.Invalidate();
      ((Behaviour) this.m_Coin).enabled = true;
    }
    else
    {
      ((Behaviour) this.m_Coin).enabled = false;
      this.m_Price.text = string.Empty;
    }
    hint.GetTipPosition(this.m_BackRect, position, upsetPoint);
    this.m_ItemRect.anchoredPosition = this.m_BackRect.anchoredPosition + this.ItemPosUpset;
    float num2 = -this.m_BackRect.anchoredPosition3D.y + this.m_BackRect.sizeDelta.y;
    if ((double) num2 > (double) GUIManager.Instance.m_MessageBoxLayer.rect.size.y)
    {
      this.m_Properties.fontSize = 18 - Convert.ToInt32((float) (((double) num2 - (double) GUIManager.Instance.m_MessageBoxLayer.rect.size.y) * 0.037999998778104782));
      ((Graphic) this.m_Properties).rectTransform.sizeDelta = ((Graphic) this.m_Properties).rectTransform.sizeDelta with
      {
        y = Mathf.Max(66f, this.m_Properties.preferredHeight)
      };
      this.m_BackRect.sizeDelta = this.m_BackRect.sizeDelta with
      {
        y = Mathf.Max(186f, (float) (123.59999847412109 + (double) this.m_Properties.preferredHeight + 14.399999618530273))
      };
    }
    this.m_ButtonHint = hint;
    this.Canvasgroup.alpha = 1f;
  }

  public void ShowHero(UIButtonHint hint, ushort HeroID, ushort TeamIndex, ushort ArrayIndex)
  {
    if ((UnityEngine.Object) hint == (UnityEngine.Object) null)
      return;
    RectTransform transform = hint.transform as RectTransform;
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    ((Component) this.m_RectTransform).gameObject.SetActive(true);
    ((Transform) this.m_RectTransform).SetAsLastSibling();
    if (((Component) this.m_ItemBtn).gameObject.activeSelf)
    {
      this.ItemGo.SetActive(false);
      ((Component) this.ItemPanel).gameObject.SetActive(false);
      ((Component) this.HeroPanel).gameObject.SetActive(true);
    }
    HeroTeam recordByKey1 = instance1.TeamTable.GetRecordByKey(TeamIndex);
    Hero recordByKey2 = instance1.HeroTable.GetRecordByKey(recordByKey1.Arrays[(int) ArrayIndex].Hero);
    if (recordByKey2.HeroTitle > (ushort) 0)
      this.m_Name.text = instance1.mStringTable.GetStringByID((uint) recordByKey2.HeroTitle);
    if (recordByKey1.Arrays[(int) ArrayIndex].Type == (byte) 3)
    {
      ((Component) this.BossIcon).gameObject.SetActive(true);
      instance2.ChangeHeroItemImg(((Component) this.m_HeroBtn).transform, eHeroOrItem.Hero, recordByKey2.HeroKey, recordByKey1.HeroStar, (byte) 0);
    }
    else
    {
      ((Component) this.BossIcon).gameObject.SetActive(false);
      GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_HeroBtn).transform, eHeroOrItem.Hero, recordByKey2.HeroKey, (byte) 1, (byte) 0);
    }
    if (instance1.UserLanguage == GameLanguage.GL_Chs)
    {
      this.CNBossIconObj.SetActive(((Component) this.BossIcon).gameObject.activeSelf);
      ((Component) this.BossIcon).gameObject.SetActive(false);
    }
    instance2.tmpString.Remove(0, instance2.tmpString.Length);
    this.m_HeroLV.text = instance2.tmpString.AppendFormat(instance1.mStringTable.GetStringByID(52U), (object) recordByKey1.HeroLevel).ToString();
    this.m_HeroName.text = instance1.mStringTable.GetStringByID((uint) recordByKey2.HeroName);
    this.m_Properties.text = instance1.mStringTable.GetStringByID((uint) recordByKey2.Summary);
    ((Graphic) this.m_Properties).rectTransform.sizeDelta = ((Graphic) this.m_Properties).rectTransform.sizeDelta with
    {
      y = Mathf.Max(66f, this.m_Properties.preferredHeight)
    };
    this.m_BackRect.sizeDelta = this.m_BackRect.sizeDelta with
    {
      y = Mathf.Max(180f, (float) (117.59999847412109 + (double) this.m_Properties.preferredHeight + 14.399999618530273))
    };
    hint.GetTipPosition(this.m_BackRect);
    float num = -this.m_BackRect.anchoredPosition3D.y + this.m_BackRect.sizeDelta.y;
    if ((double) num > (double) GUIManager.Instance.m_MessageBoxLayer.rect.size.y)
    {
      this.m_Properties.fontSize = 18 - Convert.ToInt32((float) (((double) num - (double) GUIManager.Instance.m_MessageBoxLayer.rect.size.y) * 0.037999998778104782));
      ((Graphic) this.m_Properties).rectTransform.sizeDelta = ((Graphic) this.m_Properties).rectTransform.sizeDelta with
      {
        y = Mathf.Max(66f, this.m_Properties.preferredHeight)
      };
      this.m_BackRect.sizeDelta = this.m_BackRect.sizeDelta with
      {
        y = Mathf.Max(180f, (float) (117.59999847412109 + (double) this.m_Properties.preferredHeight + 14.399999618530273))
      };
    }
    this.m_ButtonHint = hint;
    this.Canvasgroup.alpha = 1f;
  }

  public void Hide(UIButtonHint hint)
  {
    if ((UnityEngine.Object) this.m_ButtonHint != (UnityEngine.Object) hint || (UnityEngine.Object) this.m_RectTransform == (UnityEngine.Object) null)
      return;
    ((Component) this.m_RectTransform).gameObject.SetActive(false);
    GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_ItemBtn).transform, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0);
    ((Component) this.m_ItemBtn).transform.gameObject.SetActive(true);
    UIText name = this.m_Name;
    string empty = string.Empty;
    this.m_Properties.text = empty;
    string str = empty;
    name.text = str;
    this.m_ButtonHint = (UIButtonHint) null;
    ((Graphic) this.m_Properties).rectTransform.sizeDelta = ((Graphic) this.m_Properties).rectTransform.sizeDelta with
    {
      y = this.OriTextHeight
    };
    this.m_BackRect.sizeDelta = this.m_BackRect.sizeDelta with
    {
      y = this.OriHeight
    };
    this.m_Properties.fontSize = 18;
    this.m_HeroName.fontSize = 22;
    this.m_HeroName.resizeTextMaxSize = 22;
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    if (this.HeroID == (ushort) 0)
      return;
    if ((UnityEngine.Object) this.m_ButtonHint != (UnityEngine.Object) null)
      this.m_ButtonHint.OnCloseHint();
    GUIManager.Instance.OpenPreviewHeroInfo(this.HeroID, Lv: (byte) 60, Enhance: (byte) 8, Star: (byte) 5, Equip: (byte) 63);
    this.HeroID = (ushort) 0;
  }

  public void TextRefresh()
  {
    if ((UnityEngine.Object) this.m_RectTransform == (UnityEngine.Object) null || !((Component) this.m_RectTransform).gameObject.activeSelf)
      return;
    ((Behaviour) this.m_Name).enabled = false;
    ((Behaviour) this.m_Name).enabled = true;
    ((Behaviour) this.m_ItemLvText).enabled = false;
    ((Behaviour) this.m_ItemLvText).enabled = true;
    ((Behaviour) this.m_ItemKindText).enabled = false;
    ((Behaviour) this.m_ItemKindText).enabled = true;
    ((Behaviour) this.m_OwnedText).enabled = false;
    ((Behaviour) this.m_OwnedText).enabled = true;
    ((Behaviour) this.m_Properties).enabled = false;
    ((Behaviour) this.m_Properties).enabled = true;
    ((Behaviour) this.m_Price).enabled = false;
    ((Behaviour) this.m_Price).enabled = true;
    ((Behaviour) this.m_HeroName).enabled = false;
    ((Behaviour) this.m_HeroName).enabled = true;
    ((Behaviour) this.m_HeroLV).enabled = false;
    ((Behaviour) this.m_HeroLV).enabled = true;
  }

  private enum IgnoreControl
  {
    Ignore,
    ItemBtn,
  }

  private enum UIControl
  {
    ItemPanel,
    HeroPanel,
    Name,
    Properties,
  }

  private enum ItemControl
  {
    Own,
    CoinIcon,
    Price,
    ItemLv,
    ItemKind,
  }

  private enum HeroControl
  {
    HeroObj,
    BossIcon,
    BossIconCN,
    LV,
    HeroName,
  }
}
