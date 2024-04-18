// Decompiled with JetBrains decompiler
// Type: UILordEquipSetEdit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UILordEquipSetEdit : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUILEBtnClickHandler
{
  private Transform AGS_Form;
  private ScrollPanel AGS_ScrollPanel;
  private UISpritesArray AGS_Forging;
  private Door door;
  private DataManager DM;
  private bool isLoading;
  private List<float> SPHeight;
  private RectTransform[] Equips;
  private List<LordEquipEffectCompareSet> effectCompareList;
  public static LordEquipSet showingSet;
  public static int[] SetDataIndex;
  public static int SetIdx;
  public static int ChangingIdx;
  public static CString SetName;
  public static bool ThingsChanged;
  private int usedsolt;
  private CString[] EffDescText = new CString[18];
  private float GetPointTime;
  private Image[] LEquipLight = new Image[8];
  private float AnimeTime;
  private bool openUseSpand;
  private RectTransform ForgingIcon;

  public override void OnOpen(int arg1, int arg2)
  {
    this.door = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
    this.DM = DataManager.Instance;
    if (this.DM.mLordEquip == null)
      this.DM.mLordEquip = LordEquipData.Instance();
    this.SPHeight = new List<float>();
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    UIText component1 = this.AGS_Form.GetChild(0).GetChild(1).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.text = string.Empty;
    component1.SetCheckArabic(true);
    Image component2 = this.AGS_Form.GetChild(1).GetComponent<Image>();
    component2.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component2).material = this.door.LoadMaterial();
    ((Behaviour) component2).enabled = !GUIManager.Instance.bOpenOnIPhoneX;
    Image component3 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<Image>();
    component3.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component3).material = this.door.LoadMaterial();
    UIButton component4 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_BtnID1 = 99;
    component4.m_EffectType = e_EffectType.e_Scale;
    component4.transition = (Selectable.Transition) 0;
    UIButton component5 = this.AGS_Form.GetChild(2).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    component5.m_BtnID1 = 4;
    component5.m_EffectType = e_EffectType.e_Scale;
    UIButton component6 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIButton>();
    component6.m_Handler = (IUIButtonClickHandler) this;
    component6.m_BtnID1 = 2;
    component6.m_EffectType = e_EffectType.e_Scale;
    UIText component7 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
    component7.font = ttfFont;
    component7.text = this.DM.mStringTable.GetStringByID(9702U);
    UIButton component8 = this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIButton>();
    component8.m_Handler = (IUIButtonClickHandler) this;
    component8.m_BtnID1 = 1;
    component8.m_EffectType = e_EffectType.e_Scale;
    UIText component9 = this.AGS_Form.GetChild(4).GetChild(1).GetChild(0).GetComponent<UIText>();
    component9.font = ttfFont;
    component9.text = this.DM.mStringTable.GetStringByID(929U);
    UIButton component10 = this.AGS_Form.GetChild(5).GetChild(8).GetComponent<UIButton>();
    component10.m_Handler = (IUIButtonClickHandler) this;
    component10.transition = (Selectable.Transition) 0;
    component10.m_EffectType = e_EffectType.e_Scale;
    GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(8).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
    UIButton component11 = this.AGS_Form.GetChild(5).GetChild(9).GetComponent<UIButton>();
    component11.m_Handler = (IUIButtonClickHandler) this;
    component11.transition = (Selectable.Transition) 0;
    component11.m_EffectType = e_EffectType.e_Scale;
    GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(9).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
    UIButton component12 = this.AGS_Form.GetChild(5).GetChild(10).GetComponent<UIButton>();
    component12.m_Handler = (IUIButtonClickHandler) this;
    component12.transition = (Selectable.Transition) 0;
    component12.m_EffectType = e_EffectType.e_Scale;
    GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(10).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
    UIButton component13 = this.AGS_Form.GetChild(5).GetChild(11).GetComponent<UIButton>();
    component13.m_Handler = (IUIButtonClickHandler) this;
    component13.transition = (Selectable.Transition) 0;
    component13.m_EffectType = e_EffectType.e_Scale;
    GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(11).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
    UIButton component14 = this.AGS_Form.GetChild(5).GetChild(12).GetComponent<UIButton>();
    component14.m_Handler = (IUIButtonClickHandler) this;
    component14.transition = (Selectable.Transition) 0;
    component14.m_EffectType = e_EffectType.e_Scale;
    GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(12).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
    UIButton component15 = this.AGS_Form.GetChild(5).GetChild(13).GetComponent<UIButton>();
    component15.m_Handler = (IUIButtonClickHandler) this;
    component15.transition = (Selectable.Transition) 0;
    component15.m_EffectType = e_EffectType.e_Scale;
    GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(13).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
    UIButton component16 = this.AGS_Form.GetChild(5).GetChild(14).GetComponent<UIButton>();
    component16.m_Handler = (IUIButtonClickHandler) this;
    component16.transition = (Selectable.Transition) 0;
    component16.m_EffectType = e_EffectType.e_Scale;
    GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(14).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
    UIButton component17 = this.AGS_Form.GetChild(5).GetChild(15).GetComponent<UIButton>();
    component17.m_Handler = (IUIButtonClickHandler) this;
    component17.transition = (Selectable.Transition) 0;
    component17.m_EffectType = e_EffectType.e_Scale;
    GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(15).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
    for (int index = 0; index < 8; ++index)
    {
      UILEBtn component18 = this.AGS_Form.GetChild(5).GetChild(16 + index).GetComponent<UILEBtn>();
      component18.m_Handler = (IUILEBtnClickHandler) this;
      ((Component) component18).gameObject.SetActive(false);
      this.LEquipLight[index] = this.AGS_Form.GetChild(5).GetChild(index + 8).GetChild(0).GetComponent<Image>();
    }
    UIText component19 = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UIText>();
    component19.font = ttfFont;
    component19.text = this.DM.mStringTable.GetStringByID(1048U);
    this.AGS_ScrollPanel = this.AGS_Form.GetChild(6).GetChild(2).GetComponent<ScrollPanel>();
    UIText component20 = this.AGS_Form.GetChild(6).GetChild(3).GetChild(0).GetComponent<UIText>();
    component20.font = ttfFont;
    component20.text = string.Empty;
    UIText component21 = this.AGS_Form.GetChild(6).GetChild(3).GetChild(1).GetComponent<UIText>();
    component21.font = ttfFont;
    component21.text = string.Empty;
    this.AGS_Forging = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UISpritesArray>();
    this.ForgingIcon = this.AGS_Form.GetChild(7).GetComponent<RectTransform>();
    ((Graphic) ((Component) this.ForgingIcon).GetComponent<Image>()).color = (Color) new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, (byte) 120);
    if (UILordEquipSetEdit.showingSet == null)
      UILordEquipSetEdit.showingSet = new LordEquipSet();
    if (UILordEquipSetEdit.SetDataIndex == null)
      UILordEquipSetEdit.SetDataIndex = new int[8];
    this.isLoading = true;
    LordEquipData.CheckEquipExpired();
  }

  public override void OnClose()
  {
    for (int index = 0; index < this.EffDescText.Length; ++index)
      StringManager.Instance.DeSpawnString(this.EffDescText[index]);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.reflashItem();
        break;
      case 2:
        this.door.CloseMenu();
        break;
      case 3:
        this.ReCheckItem();
        this.reflashItem();
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.reflashItem();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  private bool saveCheck(int skip = 0)
  {
    if (!UILordEquipSetEdit.ThingsChanged)
      return false;
    if ((skip & 1) != 1 && UILordEquipSetEdit.showingSet.Name.Length == 0)
    {
      GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5893U), this.DM.mStringTable.GetStringByID(9705U), 1, skip | 1);
      return false;
    }
    if ((skip & 2) != 2)
    {
      for (int index = 0; index < this.usedsolt; ++index)
      {
        if (UILordEquipSetEdit.showingSet.SerialNO[index] == 0U)
        {
          GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5893U), this.DM.mStringTable.GetStringByID(9706U), 1, skip | 2);
          return false;
        }
      }
    }
    return true;
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1:
        if (!this.saveCheck())
          break;
        GUIManager.Instance.UseOrSpend(GameConstants.LESaveItemID, this.DM.mStringTable.GetStringByID(9703U), (ushort) 0, (ushort) UILordEquipSetEdit.SetIdx, (ushort) 0, maxcount: (ushort) 0);
        break;
      case 2:
        for (int index = 0; index < UILordEquipSetEdit.showingSet.SerialNO.Length; ++index)
          UILordEquipSetEdit.showingSet.SerialNO[index] = 0U;
        this.reflashItem();
        break;
      case 3:
        UILordEquipSetEdit.ChangingIdx = sender.m_BtnID2 - 1;
        UILordEquip.waitForReturn = eUI_LordEquipReturnKind.None;
        this.door.OpenMenu(EGUIWindow.UI_LordEquip, 3, sender.m_BtnID2);
        break;
      case 4:
        DataManager.Instance.OpenAllianceBox((ushort) 37, 10, Para: 0L);
        break;
      case 99:
        if (UILordEquipSetEdit.ThingsChanged)
        {
          if (UILordEquipSetEdit.showingSet.isSetEmpty())
          {
            this.door.CloseMenu();
            break;
          }
          GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5893U), this.DM.mStringTable.GetStringByID(9707U), 2);
          break;
        }
        this.door.CloseMenu();
        break;
    }
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
    if (sender.m_BtnID1 != 3)
      return;
    UILordEquipSetEdit.ChangingIdx = sender.m_BtnID2 - 1;
    UILordEquip.waitForReturn = eUI_LordEquipReturnKind.None;
    this.door.OpenMenu(EGUIWindow.UI_LordEquip, 3, sender.m_BtnID2);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 1:
        if (!this.saveCheck(arg2))
          break;
        this.openUseSpand = true;
        break;
      case 2:
        this.door.CloseMenu();
        break;
    }
  }

  public void ButtonOnClick(GameObject sender, int parm1, int parm2)
  {
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    Effect recordByKey = this.DM.EffectData.GetRecordByKey(this.effectCompareList[dataIdx].EffectID);
    if (this.effectCompareList[dataIdx].isTitel)
    {
      UIText component = item.transform.GetChild(0).GetComponent<UIText>();
      item.transform.GetChild(0).gameObject.SetActive(true);
      item.transform.GetChild(1).gameObject.SetActive(false);
      component.text = this.DM.mStringTable.GetStringByID((uint) (ushort) (8484U + (uint) this.effectCompareList[dataIdx].group));
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
    }
    else
    {
      UIText component = item.transform.GetChild(1).GetComponent<UIText>();
      item.transform.GetChild(0).gameObject.SetActive(false);
      item.transform.GetChild(1).gameObject.SetActive(true);
      this.EffDescText[panelObjectIdx].ClearString();
      this.EffDescText[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey.InfoID));
      if (this.effectCompareList[dataIdx].isEven)
        this.EffDescText[panelObjectIdx].StringToFormat("<color=#FFFFFF>");
      else if (this.effectCompareList[dataIdx].EffectValue < 0)
        this.EffDescText[panelObjectIdx].StringToFormat("<color=#FF656EFF>");
      else
        this.EffDescText[panelObjectIdx].StringToFormat("<color=#35F76CFF>+");
      if (recordByKey.ValueID == (ushort) 0)
      {
        this.EffDescText[panelObjectIdx].IntToFormat((long) this.effectCompareList[dataIdx].EffectValue);
        this.EffDescText[panelObjectIdx].AppendFormat("<color=#FFEC87FF>{0}</color> {1}{2}</color>");
      }
      else
      {
        float f = (float) this.effectCompareList[dataIdx].EffectValue / 100f;
        this.EffDescText[panelObjectIdx].FloatToFormat(f, 2, false);
        this.EffDescText[panelObjectIdx].AppendFormat("<color=#FFEC87FF>{0}</color> {1}{2}%</color>");
      }
      component.text = this.EffDescText[panelObjectIdx].ToString();
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
      if (GameConstants.IsBigStyle())
        return;
      component.resizeTextMaxSize = 16;
    }
  }

  public static void loadSet(int index)
  {
    UILordEquipSetEdit.SetIdx = index;
    if (UILordEquipSetEdit.showingSet == null)
      UILordEquipSetEdit.showingSet = new LordEquipSet();
    if (UILordEquipSetEdit.SetDataIndex == null)
      UILordEquipSetEdit.SetDataIndex = new int[8];
    for (int index1 = 0; index1 < UILordEquipSetEdit.showingSet.SerialNO.Length; ++index1)
      UILordEquipSetEdit.showingSet.SerialNO[index1] = LordEquipData.Instance().LordEquipSets[index].SerialNO[index1];
    for (int index2 = 0; index2 < UILordEquipSetEdit.showingSet.SerialNO.Length; ++index2)
    {
      if (UILordEquipSetEdit.showingSet.SerialNO[index2] != 0U)
      {
        bool flag = false;
        for (int index3 = 0; index3 < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index3)
        {
          if ((int) LordEquipData.Instance().LordEquip[index3].SerialNO == (int) UILordEquipSetEdit.showingSet.SerialNO[index2])
          {
            UILordEquipSetEdit.SetDataIndex[index2] = index3;
            flag = true;
          }
        }
        if (!flag)
        {
          UILordEquipSetEdit.showingSet.SerialNO[index2] = 0U;
          LordEquipData.Instance().LordEquipSets[index].SerialNO[index2] = 0U;
        }
      }
    }
    if (UILordEquipSetEdit.showingSet.Name == null)
      UILordEquipSetEdit.showingSet.Name = StringManager.Instance.SpawnString();
    UILordEquipSetEdit.showingSet.Name.ClearString();
    UILordEquipSetEdit.showingSet.Name.Append(LordEquipData.Instance().LordEquipSets[index].Name);
    UILordEquipSetEdit.ThingsChanged = false;
  }

  public void ReCheckItem()
  {
    for (int index1 = 0; index1 < UILordEquipSetEdit.showingSet.SerialNO.Length; ++index1)
    {
      if (UILordEquipSetEdit.showingSet.SerialNO[index1] != 0U)
      {
        bool flag = false;
        for (int index2 = 0; index2 < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index2)
        {
          if ((int) LordEquipData.Instance().LordEquip[index2].SerialNO == (int) UILordEquipSetEdit.showingSet.SerialNO[index1])
          {
            UILordEquipSetEdit.SetDataIndex[index1] = index2;
            flag = true;
          }
        }
        if (!flag)
          UILordEquipSetEdit.showingSet.SerialNO[index1] = 0U;
      }
    }
  }

  public void AfterLoader()
  {
    if (this.Equips == null)
      this.Equips = new RectTransform[8];
    for (int index = 0; index < 8; ++index)
    {
      UILEBtn component = this.AGS_Form.GetChild(5).GetChild(16 + index).GetComponent<UILEBtn>();
      GUIManager.Instance.InitLordEquipImg(((Component) component).transform, (ushort) 0, (byte) 0, setScale: true, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      this.Equips[index] = ((Component) component).transform.GetComponent<RectTransform>();
    }
    this.effectCompareList = new List<LordEquipEffectCompareSet>();
    for (int index = 0; index < this.EffDescText.Length; ++index)
      this.EffDescText[index] = StringManager.Instance.SpawnString(100);
    this.AGS_ScrollPanel.IntiScrollPanel(445f, 0.0f, 0.0f, this.SPHeight, 18, (IUpDateScrollPanel) this);
    this.reflashItem();
    this.isLoading = false;
  }

  public void reflashItem()
  {
    if (UILordEquipSetEdit.SetName == null)
      UILordEquipSetEdit.SetName = StringManager.Instance.SpawnString();
    UILordEquipSetEdit.SetName.ClearString();
    if (UILordEquipSetEdit.showingSet.Name.Length == 0)
    {
      UILordEquipSetEdit.SetName.IntToFormat((long) (UILordEquipSetEdit.SetIdx + 1));
      UILordEquipSetEdit.SetName.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(928U));
    }
    else
      UILordEquipSetEdit.SetName.Append(UILordEquipSetEdit.showingSet.Name);
    UIText component1 = this.AGS_Form.GetChild(0).GetChild(1).GetComponent<UIText>();
    component1.text = UILordEquipSetEdit.SetName.ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    component1.cachedTextGeneratorForLayout.Invalidate();
    int x = (int) component1.preferredWidth / 2 + 30;
    RectTransform component2 = this.AGS_Form.GetChild(2).GetComponent<RectTransform>();
    component2.anchoredPosition = new Vector2((float) x, component2.anchoredPosition.y);
    this.effectCompareList.Clear();
    List<LordEquipEffectSet> effList = new List<LordEquipEffectSet>();
    for (int index1 = 0; index1 < 8; ++index1)
    {
      if (UILordEquipSetEdit.showingSet.SerialNO[index1] != 0U)
      {
        for (int index2 = 0; index2 < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index2)
        {
          if ((int) LordEquipData.Instance().LordEquip[index2].SerialNO == (int) UILordEquipSetEdit.showingSet.SerialNO[index1])
            UILordEquipSetEdit.SetDataIndex[index1] = index2;
        }
        LordEquipData.GetEffectList(LordEquipData.Instance().LordEquip[UILordEquipSetEdit.SetDataIndex[index1]], effList, (byte) 0);
      }
    }
    LordEquipData.effectListAddToEffectCompareList(effList, this.effectCompareList);
    LordEquipData.EffectTitleListCreater(this.effectCompareList);
    ((Component) this.ForgingIcon).gameObject.SetActive(false);
    if (this.DM.RoleAttr.LordEquipEventData.SerialNO != 0U)
    {
      for (int index = 0; index < 8; ++index)
      {
        if ((int) this.DM.RoleAttr.LordEquipEventData.SerialNO == (int) UILordEquipSetEdit.showingSet.SerialNO[index])
        {
          ((Transform) this.ForgingIcon).SetParent(this.AGS_Form.GetChild(5).GetChild(index + 16));
          this.ForgingIcon.anchoredPosition = new Vector2(52f, -52f);
          ((Component) this.ForgingIcon).gameObject.SetActive(true);
          break;
        }
      }
    }
    for (int index = 0; index < 8; ++index)
    {
      if (UILordEquipSetEdit.showingSet.SerialNO[index] != 0U)
      {
        this.AGS_Form.GetChild(5).GetChild(index + 8).gameObject.SetActive(false);
        ((Component) this.Equips[index]).gameObject.SetActive(true);
        GUIManager.Instance.ChangeLordEquipImg(((Component) this.Equips[index]).transform, LordEquipData.Instance().LordEquip[UILordEquipSetEdit.SetDataIndex[index]]);
        ((Component) this.Equips[index]).GetComponent<UILEBtn>().SetCountdown(LordEquipData.Instance().LordEquip[UILordEquipSetEdit.SetDataIndex[index]].ExpireTime);
      }
      else
      {
        this.AGS_Form.GetChild(5).GetChild(index + 8).gameObject.SetActive(true);
        ((Component) this.Equips[index]).gameObject.SetActive(false);
        int num = UILordEquipSetEdit.CheckHaveEquipKind((byte) (index + 21), false);
        if (num > 0)
        {
          this.AGS_Form.GetChild(5).GetChild(index + 8).GetChild(0).gameObject.SetActive(num == 1);
          this.AGS_Form.GetChild(5).GetChild(index + 8).GetChild(1).gameObject.SetActive(true);
          this.AGS_Form.GetChild(5).GetChild(index + 8).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(2 - num);
        }
        else
        {
          this.AGS_Form.GetChild(5).GetChild(index + 8).GetChild(0).gameObject.SetActive(false);
          this.AGS_Form.GetChild(5).GetChild(index + 8).GetChild(1).gameObject.SetActive(false);
        }
      }
    }
    int num1 = UILordEquipSetEdit.CheckHaveEquipKind((byte) 26, true);
    RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData((ushort) 15, (ushort) 0);
    this.usedsolt = buildData.Level < (byte) 25 ? (buildData.Level < (byte) 17 ? 6 : 7) : 8;
    if (buildData.Level >= (byte) 17 && UILordEquipSetEdit.showingSet.SerialNO[6] == 0U)
    {
      this.AGS_Form.GetChild(5).GetChild(24).gameObject.SetActive(buildData.Level < (byte) 17);
      this.AGS_Form.GetChild(5).GetChild(14).GetChild(0).gameObject.SetActive(num1 == 1);
      this.AGS_Form.GetChild(5).GetChild(14).GetChild(1).gameObject.SetActive(num1 > 0);
      this.AGS_Form.GetChild(5).GetChild(14).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(2 - num1);
      this.AGS_Form.GetChild(5).GetChild(14).GetComponent<UIButton>().m_BtnID1 = 3;
    }
    else
    {
      this.AGS_Form.GetChild(5).GetChild(24).gameObject.SetActive(buildData.Level < (byte) 17);
      this.AGS_Form.GetChild(5).GetChild(14).GetChild(0).gameObject.SetActive(false);
      this.AGS_Form.GetChild(5).GetChild(14).GetChild(1).gameObject.SetActive(false);
      this.AGS_Form.GetChild(5).GetChild(14).GetComponent<UIButton>().m_BtnID1 = 0;
    }
    if (buildData.Level >= (byte) 25 && UILordEquipSetEdit.showingSet.SerialNO[7] == 0U)
    {
      this.AGS_Form.GetChild(5).GetChild(25).gameObject.SetActive(buildData.Level < (byte) 25);
      this.AGS_Form.GetChild(5).GetChild(15).GetChild(0).gameObject.SetActive(num1 == 1);
      this.AGS_Form.GetChild(5).GetChild(15).GetChild(1).gameObject.SetActive(num1 > 0);
      this.AGS_Form.GetChild(5).GetChild(15).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(2 - num1);
      this.AGS_Form.GetChild(5).GetChild(15).GetComponent<UIButton>().m_BtnID1 = 3;
    }
    else
    {
      this.AGS_Form.GetChild(5).GetChild(25).gameObject.SetActive(buildData.Level < (byte) 25);
      this.AGS_Form.GetChild(5).GetChild(15).GetChild(0).gameObject.SetActive(false);
      this.AGS_Form.GetChild(5).GetChild(15).GetChild(1).gameObject.SetActive(false);
      this.AGS_Form.GetChild(5).GetChild(15).GetComponent<UIButton>().m_BtnID1 = 0;
    }
    this.SPHeight.Clear();
    for (int index = 0; index < this.effectCompareList.Count; ++index)
    {
      if (this.effectCompareList[index].isTitel)
        this.SPHeight.Add(35f);
      else
        this.SPHeight.Add(32f);
    }
    if (this.SPHeight.Count > 1)
    {
      this.SPHeight.RemoveAt(this.SPHeight.Count - 1);
      this.SPHeight.Add(38f);
    }
    this.AGS_Form.GetChild(6).gameObject.SetActive(true);
    this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeight);
    if (!UILordEquipSetEdit.ThingsChanged)
    {
      for (int index = 0; index < UILordEquipSetEdit.showingSet.SerialNO.Length; ++index)
      {
        if ((int) UILordEquipSetEdit.showingSet.SerialNO[index] != (int) LordEquipData.Instance().LordEquipSets[UILordEquipSetEdit.SetIdx].SerialNO[index])
        {
          UILordEquipSetEdit.ThingsChanged = true;
          break;
        }
      }
    }
    UIButton component3 = this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIButton>();
    UIText component4 = ((Component) component3).transform.GetChild(0).GetComponent<UIText>();
    if (UILordEquipSetEdit.ThingsChanged && !UILordEquipSetEdit.showingSet.isSetEmpty())
    {
      ((Graphic) component3.image).color = Color.white;
      component3.m_BtnID1 = 1;
      ((Graphic) component4).color = Color.white;
    }
    else
    {
      ((Graphic) component3.image).color = Color.gray;
      component3.m_BtnID1 = 0;
      ((Graphic) component4).color = new Color(0.898f, 0.0f, 0.31f);
    }
    UIButton component5 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIButton>();
    UIText component6 = ((Component) component5).transform.GetChild(0).GetComponent<UIText>();
    if (!UILordEquipSetEdit.showingSet.isSetEmpty())
    {
      ((Graphic) component5.image).color = Color.white;
      component5.m_BtnID1 = 2;
      ((Graphic) component6).color = Color.white;
    }
    else
    {
      ((Graphic) component5.image).color = Color.gray;
      component5.m_BtnID1 = 0;
      ((Graphic) component6).color = new Color(0.898f, 0.0f, 0.31f);
    }
  }

  public static int CheckHaveEquipKind(byte Kind, bool CheckRole)
  {
    bool flag = false;
    for (int index = 0; index < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index)
    {
      if (LordEquipData.Instance().LordEquip[index].ItemID != (ushort) 0)
      {
        Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(LordEquipData.Instance().LordEquip[index].ItemID);
        if ((int) recordByKey.EquipKind == (int) Kind && (!CheckRole || !UILordEquipSetEdit.showingSet.isInSet(LordEquipData.Instance().LordEquip[index].SerialNO)))
        {
          flag = true;
          if ((int) LordEquipData.Instance().LordEquip[index].SerialNO != (int) DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO && (int) DataManager.Instance.RoleAttr.Level >= (int) recordByKey.NeedLv)
            return 1;
        }
      }
    }
    return flag ? 2 : 0;
  }

  public void Update()
  {
    if (this.isLoading)
    {
      this.isLoading = false;
      this.AfterLoader();
    }
    if (this.openUseSpand)
    {
      this.openUseSpand = false;
      GUIManager.Instance.UseOrSpend(GameConstants.LESaveItemID, this.DM.mStringTable.GetStringByID(9703U), (ushort) 0, (ushort) UILordEquipSetEdit.SetIdx, (ushort) 0, maxcount: (ushort) 0);
    }
    this.GetPointTime += Time.smoothDeltaTime;
    if ((double) this.GetPointTime >= 2.0)
      this.GetPointTime = 0.0f;
    Color color = new Color(1f, 1f, 1f, (double) this.GetPointTime <= 1.0 ? this.GetPointTime : 2f - this.GetPointTime);
    for (int index = 0; index < this.LEquipLight.Length; ++index)
    {
      if (((Component) this.LEquipLight[index]).gameObject.activeInHierarchy)
        ((Graphic) this.LEquipLight[index]).color = color;
    }
    if (!this.AGS_Forging.gameObject.activeInHierarchy)
      return;
    this.AnimeTime += Time.smoothDeltaTime;
    if ((double) this.AnimeTime < 0.30000001192092896)
      this.AGS_Forging.SetSpriteIndex(0);
    else if ((double) this.AnimeTime < 0.40000000596046448)
      this.AGS_Forging.SetSpriteIndex(1);
    else if ((double) this.AnimeTime < 0.800000011920929)
      this.AGS_Forging.SetSpriteIndex(2);
    else
      this.AnimeTime = 0.0f;
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(0).GetChild(1).GetComponent<UIText>();
    if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((Object) component2 != (Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.AGS_Form.GetChild(4).GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((Object) component3 != (Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UIText>();
    if ((Object) component4 != (Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    if (!((Object) this.AGS_ScrollPanel != (Object) null) || !this.AGS_ScrollPanel.gameObject.activeInHierarchy)
      return;
    Transform child1 = this.AGS_ScrollPanel.transform.GetChild(0);
    for (int index = 0; index < child1.childCount; ++index)
    {
      Transform child2 = child1.GetChild(index);
      if (child2.gameObject.activeInHierarchy)
      {
        UIText component5 = child2.GetChild(0).GetComponent<UIText>();
        if ((Object) component5 != (Object) null && ((Behaviour) component5).enabled)
        {
          ((Behaviour) component5).enabled = false;
          ((Behaviour) component5).enabled = true;
        }
      }
    }
  }

  private enum e_AGS_UI_LordEquipSetEdit_Editor
  {
    BGFrame,
    exitImage,
    Renamebtn,
    Image,
    ItemCombinePanel,
    ItemLayer,
    ItemInfo,
    Forging,
  }

  private enum e_AGS_BGFrame
  {
    BGHighLight,
    Title,
  }

  private enum e_AGS_exitImage
  {
    exitUIButton,
  }

  private enum e_AGS_ItemCombinePanel
  {
    ClearBtn,
    SaveBtn,
  }

  private enum e_AGS_ClearBtn
  {
    Name,
  }

  private enum e_AGS_SaveBtn
  {
    Name,
  }

  private enum e_AGS_ItemLayer
  {
    Shadow1,
    Shadow2,
    Shadow3,
    Shadow4,
    Shadow5,
    Shadow6,
    Shadow7,
    Shadow8,
    Pos1,
    Pos2,
    Pos3,
    Pos4,
    Pos5,
    Pos6,
    Pos7,
    Pos8,
    UILEBtn1,
    UILEBtn2,
    UILEBtn3,
    UILEBtn4,
    UILEBtn5,
    UILEBtn6,
    UILEBtn7,
    UILEBtn8,
    Lock7,
    Lock8,
  }

  private enum e_AGS_ItemInfo
  {
    NameBg,
    NameText,
    ScrollPanel,
    ScrollItem,
  }

  private enum e_AGS_ScrollItem
  {
    Text,
  }
}
