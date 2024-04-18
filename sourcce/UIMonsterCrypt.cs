// Decompiled with JetBrains decompiler
// Type: UIMonsterCrypt
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIMonsterCrypt : GUIWindow, IUIButtonClickHandler, IUIHIBtnClickHandler
{
  private GameObject MonsterLayerObj;
  private UIText Title;
  private UIText CryptText;
  private UIText MessageText;
  private UIText PriceTitle;
  private CString PriceStr;
  private Transform MonsterTrans;
  private RectTransform CryptRect;
  private RectTransform PriceCont;
  private CScrollRect PriceScroll;
  private List<UIText> RefreshTextArray = new List<UIText>();
  private AssetBundle AB;
  private AssetBundleRequest AR;
  private int AssetKey;
  private bool bABInitial;
  private GameObject MonsterGo;
  private Animation MonsterAN;
  private string[] anim = new string[4]
  {
    "idle",
    "status_1",
    "status_2",
    "status_3"
  };

  void IUIHIBtnClickHandler.OnHIButtonClick(UIHIBtn sender)
  {
    if (sender.m_BtnID2 == 0)
      return;
    GamblingManager.Instance.OpenMenu(EGUIWindow.UI_OpenBox, 1, sender.m_BtnID2);
  }

  public override void OnOpen(int arg1, int arg2)
  {
    ((Component) RewardManager.getInstance.rootLayer).gameObject.SetActive(false);
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.MonsterLayerObj = this.transform.GetChild(0).gameObject;
    this.MonsterTrans = this.transform.GetChild(0).GetChild(0);
    this.Title = this.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.Title.font = ttfFont;
    this.Title.text = BattleController.GambleMode != EGambleMode.Normal ? mStringTable.GetStringByID(9176U) : mStringTable.GetStringByID(9175U);
    this.AddRefreshText(this.Title);
    this.CryptText = this.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<UIText>();
    this.CryptText.font = ttfFont;
    this.AddRefreshText(this.CryptText);
    this.CryptRect = this.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<RectTransform>();
    this.MessageText = this.transform.GetChild(2).GetComponent<UIText>();
    this.MessageText.font = ttfFont;
    this.AddRefreshText(this.MessageText);
    this.MessageText.text = mStringTable.GetStringByID(9177U);
    this.PriceTitle = this.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.PriceTitle.font = ttfFont;
    this.AddRefreshText(this.PriceTitle);
    this.PriceTitle.text = mStringTable.GetStringByID(1590U);
    this.PriceCont = this.transform.GetChild(3).GetChild(2).GetChild(0).GetComponent<RectTransform>();
    this.PriceScroll = ((Transform) this.PriceCont).parent.GetComponent<CScrollRect>();
    this.transform.GetChild(4).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    if (GUIManager.Instance.bOpenOnIPhoneX)
      ((Behaviour) this.transform.GetChild(4).GetComponent<Image>()).enabled = false;
    this.PriceStr = StringManager.Instance.SpawnString();
    this.UpdateCrypt();
    this.CheckInit();
    this.InitPrice();
    UIHintMask.bPassThrough = true;
  }

  public override void OnClose()
  {
    if (this.AssetKey != 0)
      AssetManager.UnloadAssetBundle(this.AssetKey);
    StringManager.Instance.DeSpawnString(this.PriceStr);
    Object.Destroy((Object) this.MonsterLayerObj);
    ((Component) RewardManager.getInstance.rootLayer).gameObject.SetActive(true);
    UIHintMask.bPassThrough = false;
  }

  private void OnEnable()
  {
    if (!((Object) this.MonsterLayerObj != (Object) null))
      return;
    this.MonsterLayerObj.SetActive(true);
  }

  private void OnDisable()
  {
    if (!((Object) this.MonsterLayerObj != (Object) null))
      return;
    this.MonsterLayerObj.SetActive(false);
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (this.bABInitial || this.AR == null || !this.AR.isDone)
      return;
    this.MonsterGo = (GameObject) Object.Instantiate(this.AR.asset);
    this.MonsterGo.transform.SetParent(this.MonsterTrans, false);
    this.MonsterGo.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
    {
      eulerAngles = new Vector3(26f, 180f, -4.7101f)
    };
    this.MonsterGo.transform.localScale = new Vector3(450f, 450f, 450f);
    this.MonsterGo.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    GUIManager.Instance.SetLayer(this.MonsterGo, 5);
    if ((Object) this.MonsterGo != (Object) null && this.MonsterGo.gameObject.activeSelf)
    {
      SkinnedMeshRenderer componentInChildren = this.MonsterGo.GetComponentInChildren<SkinnedMeshRenderer>();
      componentInChildren.useLightProbes = false;
      componentInChildren.updateWhenOffscreen = true;
    }
    this.bABInitial = true;
    this.PlayGambleBoxAnim();
  }

  private void PlayGambleBoxAnim()
  {
    this.MonsterAN = this.MonsterGo.GetComponent<Animation>();
    int index;
    switch (GamblingManager.Instance.m_GambleBoxAnim)
    {
      case GambleBoxAnim.status_1:
        index = 1;
        break;
      case GambleBoxAnim.status_2:
        index = 2;
        break;
      case GambleBoxAnim.status_3:
        index = 3;
        break;
      default:
        index = 0;
        break;
    }
    if (!((Object) this.MonsterAN != (Object) null))
      return;
    this.MonsterAN.wrapMode = WrapMode.Loop;
    this.MonsterAN[this.anim[index]].layer = 1;
    this.MonsterAN[this.anim[index]].wrapMode = WrapMode.Loop;
    this.MonsterAN.Play(this.anim[index]);
    this.MonsterAN.clip = this.MonsterAN.GetClip(this.anim[index]);
    if (!((Object) GUIManager.Instance.m_OtherCanvasTransform != (Object) null))
      return;
    this.MonsterLayerObj.transform.SetParent((Transform) GUIManager.Instance.m_OtherCanvasTransform);
    RectTransform transform = this.MonsterLayerObj.transform as RectTransform;
    transform.anchorMin = Vector2.zero;
    transform.anchorMax = Vector2.one;
    transform.offsetMin = Vector2.zero;
    transform.offsetMax = Vector2.zero;
    transform.anchoredPosition3D = Vector3.zero;
    ((Transform) transform).localScale = Vector3.one;
    ((Transform) transform).localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
  }

  private void Set3Denvironment()
  {
    DataManager.msgBuffer[0] = (byte) 84;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    GUIManager.Instance.m_UICanvas.renderMode = (RenderMode) 1;
    GUIManager.Instance.SetCanvasChanged();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    for (int index = 0; index < this.RefreshTextArray.Count; ++index)
    {
      ((Behaviour) this.RefreshTextArray[index]).enabled = false;
      ((Behaviour) this.RefreshTextArray[index]).enabled = true;
    }
  }

  public override void UpdateUI(int arg1, int arg2) => this.UpdateCrypt();

  private void UpdateCrypt()
  {
    this.PriceStr.ClearString();
    if (BattleController.GambleMode == EGambleMode.Turbo)
      this.PriceStr.IntToFormat((long) GamblingManager.Instance.m_GambleGameInfo.Prize, bNumber: true);
    else
      this.PriceStr.IntToFormat((long) ((double) GamblingManager.Instance.m_GambleGameInfo.Prize * (double) ((float) GamblingManager.Instance.m_GambleGameInfo.SmallCost / (float) GamblingManager.Instance.m_GambleGameInfo.BigCost)), bNumber: true);
    this.PriceStr.AppendFormat("{0}");
    this.CryptText.text = this.PriceStr.ToString();
    this.CryptText.SetAllDirty();
    this.CryptText.cachedTextGenerator.Invalidate();
    this.CryptText.cachedTextGeneratorForLayout.Invalidate();
    this.CryptRect.anchoredPosition = new Vector2((float) ((double) this.CryptText.preferredWidth * -0.5 - 24.5), this.CryptRect.anchoredPosition.y);
  }

  private void InitPrice()
  {
    DataManager instance = DataManager.Instance;
    byte index1 = 0;
    DataIndexTbl Data = new DataIndexTbl();
    int gambleMode = (int) BattleController.GambleMode;
    CExternalTableWithWordKey<MonsterPriceTbl>[] monsterPriceTable = DataManager.Instance.GambleMonsterPriceTable;
    if (!GamblingManager.Instance.GetMonsterPriceGroupIndex(GamblingManager.Instance.m_GambleEventSave.GroupID, ref Data) || gambleMode >= monsterPriceTable.Length)
      return;
    for (int index2 = 0; index2 < (int) Data.Num; ++index2)
    {
      MonsterPriceTbl recordByIndex = monsterPriceTable[gambleMode].GetRecordByIndex((int) Data.BeginIdx - 1 + index2);
      Equip recordByKey = instance.EquipTable.GetRecordByKey(recordByIndex.Item);
      if (!GUIManager.Instance.IsLeadItem(recordByKey.EquipKind))
      {
        UIHIBtn component1;
        if ((int) index1 < ((Transform) this.PriceCont).GetChild(0).GetChild(0).childCount)
        {
          GUIManager.Instance.ChangeHeroItemImg(((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild((int) index1), eHeroOrItem.Item, recordByKey.EquipKey, (byte) 0, (byte) 0);
          ((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild((int) index1).gameObject.SetActive(true);
          component1 = ((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild((int) index1).GetComponent<UIHIBtn>();
        }
        else
        {
          RectTransform BtnT = Object.Instantiate((Object) ((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild(0)) as RectTransform;
          ((Transform) BtnT).SetParent(((Transform) this.PriceCont).GetChild(0).GetChild(0));
          BtnT.anchoredPosition3D = new Vector3(BtnT.anchoredPosition.x, BtnT.anchoredPosition.y, 0.0f);
          Quaternion localRotation = ((Transform) BtnT).localRotation with
          {
            eulerAngles = Vector3.zero
          };
          ((Transform) BtnT).localRotation = localRotation;
          ((Transform) BtnT).localScale = Vector3.one;
          BtnT.anchoredPosition = new Vector2((float) (36 + 74 * index2), -37f);
          ((Component) BtnT).gameObject.SetActive(true);
          GUIManager.Instance.ChangeHeroItemImg((Transform) BtnT, eHeroOrItem.Item, recordByKey.EquipKey, (byte) 0, (byte) 0);
          this.AddRefreshText(((Transform) BtnT).GetChild(4).GetComponent<UIText>());
          component1 = ((Component) BtnT).GetComponent<UIHIBtn>();
          ((Component) component1).GetComponent<UIButtonHint>().enabled = true;
          GUIManager.Instance.SetItemScaleClickSound(component1, false, true);
        }
        EItemType eitemType = (EItemType) ((uint) recordByKey.EquipKind - 1U);
        if (eitemType == EItemType.EIT_ComboTreasureBox || eitemType == EItemType.EIT_MaterialTreasureBox && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 4 || eitemType == EItemType.EIT_MaterialTreasureBox && (recordByKey.PropertiesInfo[2].Propertieskey < (ushort) 1 || recordByKey.PropertiesInfo[2].Propertieskey > (ushort) 3))
        {
          component1.m_BtnID2 = (int) recordByKey.EquipKey;
          component1.m_Handler = (IUIHIBtnClickHandler) this;
          ((Component) component1).GetComponent<UIButtonHint>().enabled = false;
          EventPatchery component2 = ((Component) component1).gameObject.GetComponent<EventPatchery>();
          if ((Object) component2 == (Object) null)
            ((Component) component1).gameObject.AddComponent<EventPatchery>().SetEvnetObj(this.PriceScroll);
          else
            component2.SetEvnetObj(this.PriceScroll);
          GUIManager.Instance.SetItemScaleClickSound(component1, true, true);
        }
      }
      else if ((int) index1 < ((Transform) this.PriceCont).GetChild(0).GetChild(1).childCount)
      {
        GUIManager.Instance.ChangeLordEquipImg(((Transform) this.PriceCont).GetChild(0).GetChild(1).GetChild((int) index1), recordByKey.EquipKey, recordByIndex.Rank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        ((Transform) this.PriceCont).GetChild(0).GetChild(1).GetChild((int) index1).gameObject.SetActive(true);
      }
      else
      {
        RectTransform BtnT = Object.Instantiate((Object) ((Transform) this.PriceCont).GetChild(0).GetChild(1).GetChild(0)) as RectTransform;
        ((Transform) BtnT).SetParent(((Transform) this.PriceCont).GetChild(0).GetChild(1));
        BtnT.anchoredPosition3D = new Vector3(BtnT.anchoredPosition.x, BtnT.anchoredPosition.y, 0.0f);
        Quaternion localRotation = ((Transform) BtnT).localRotation with
        {
          eulerAngles = Vector3.zero
        };
        ((Transform) BtnT).localRotation = localRotation;
        ((Transform) BtnT).localScale = Vector3.one;
        BtnT.anchoredPosition = new Vector2((float) (36 + 74 * index2), -37f);
        ((Component) BtnT).gameObject.SetActive(true);
        GUIManager.Instance.ChangeLordEquipImg((Transform) BtnT, recordByKey.EquipKey, recordByIndex.Rank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      }
      ++index1;
    }
    float num = (float) (4.0 + 74.0 * (double) index1);
    if ((double) this.PriceCont.sizeDelta.x < (double) num)
      this.PriceCont.sizeDelta = this.PriceCont.sizeDelta with
      {
        x = num + 4f
      };
    else
      ((Behaviour) this.PriceScroll).enabled = false;
  }

  private void CheckInit()
  {
    GUIManager instance = GUIManager.Instance;
    UIButtonHint.scrollRect = this.PriceScroll;
    for (byte index = 0; index < (byte) 8; ++index)
    {
      instance.InitianHeroItemImg(((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild((int) index), eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0);
      this.AddRefreshText(((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild((int) index).GetChild(4).GetComponent<UIText>());
    }
    for (byte index = 0; index < (byte) 8; ++index)
    {
      instance.InitLordEquipImg(((Transform) this.PriceCont).GetChild(0).GetChild(1).GetChild((int) index), (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      ((Transform) this.PriceCont).GetChild(0).GetChild(1).GetChild((int) index).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
    }
    this.AB = AssetManager.GetAssetBundle("Role/gamblebox", out this.AssetKey);
    if (!((Object) this.AB != (Object) null))
      return;
    this.AR = this.AB.LoadAsync("m", typeof (GameObject));
  }

  public void AddRefreshText(UIText text) => this.RefreshTextArray.Add(text);

  public void OnButtonClick(UIButton sender) => GamblingManager.Instance.CloseMenu();

  private enum UIControl
  {
    MonsterCrpt,
    Info,
    DownMessage,
    Price,
    Close,
  }

  private enum EInfo
  {
    Background,
    Title,
    Reward,
  }
}
