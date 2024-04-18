// Decompiled with JetBrains decompiler
// Type: UITechInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UITechInfo : IUIButtonClickHandler
{
  private const float MaxWidth = 173.8f;
  public int TechID;
  public Image TechImage;
  private UIText TechName;
  private UIText LevelText;
  private UIText EffectText;
  private UIText EffectNextText;
  private UIText ContText;
  private UIText[] BtnTitleText = new UIText[2];
  private Transform Lock;
  private Transform Lock1;
  private Transform LockPanel;
  private Transform FullFrame;
  private Transform Frame;
  private Transform ResearchFull;
  private Transform ConfirmTrans;
  private RectTransform DegreeRect;
  private RectTransform EffectRect;
  private CString LevelStr;
  private CString EffectStr;
  private CString EffectNextStr;
  private CString ContentStr;
  public UIButton ConfirmBtn;
  public ushort GraphicID;
  public Transform ThisTransform;

  public void OnOpen(int arg1, int arg2)
  {
    Transform child = this.ThisTransform.GetChild(1);
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.TechID = arg1;
    UIButton component1 = this.ThisTransform.GetChild(0).GetComponent<UIButton>();
    component1.m_BtnID1 = 1;
    component1.m_Handler = (IUIButtonClickHandler) this;
    UIButton component2 = child.GetChild(1).GetComponent<UIButton>();
    component2.m_BtnID1 = 0;
    component2.m_Handler = (IUIButtonClickHandler) this;
    if (GUIManager.Instance.IsArabic)
      ((Component) component2).transform.localScale = new Vector3(-1f, 1f, 1f);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      RectTransform component3 = this.ThisTransform.GetChild(0).GetComponent<RectTransform>();
      component3.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      component3.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    this.TechImage = child.GetChild(2).GetChild(0).GetComponent<Image>();
    this.Frame = child.GetChild(2).GetChild(1);
    this.Lock = child.GetChild(2).GetChild(1).GetChild(0);
    this.Lock1 = child.GetChild(2).GetChild(1).GetChild(1);
    this.LockPanel = child.GetChild(2).GetChild(0).GetChild(0);
    this.FullFrame = child.GetChild(2).GetChild(2);
    this.DegreeRect = child.GetChild(2).GetChild(3).GetComponent<RectTransform>();
    this.LevelText = child.GetChild(2).GetChild(4).GetComponent<UIText>();
    this.TechName = child.GetChild(2).GetChild(5).GetComponent<UIText>();
    this.EffectRect = child.GetChild(3).GetComponent<RectTransform>();
    this.EffectText = child.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.EffectNextText = child.GetChild(4).GetComponent<UIText>();
    this.ContText = child.GetChild(5).GetChild(0).GetComponent<UIText>();
    UIText contText = this.ContText;
    Font font1 = ttfFont;
    this.TechName.font = font1;
    Font font2 = font1;
    this.LevelText.font = font2;
    Font font3 = font2;
    this.EffectText.font = font3;
    Font font4 = font3;
    this.EffectNextText.font = font4;
    Font font5 = font4;
    contText.font = font5;
    this.LevelStr = StringManager.Instance.SpawnString();
    this.EffectStr = StringManager.Instance.SpawnString(100);
    this.EffectNextStr = StringManager.Instance.SpawnString(100);
    this.ContentStr = StringManager.Instance.SpawnString(200);
    if (GUIManager.Instance.IsArabic)
      ((Component) this.TechImage).transform.localScale = new Vector3(-1f, 1f, 1f);
    this.ConfirmTrans = child.GetChild(6);
    this.ConfirmBtn = this.ConfirmTrans.GetComponent<UIButton>();
    this.ConfirmBtn.m_BtnID1 = 2;
    this.ConfirmBtn.m_Handler = (IUIButtonClickHandler) this;
    this.ResearchFull = child.GetChild(7);
    this.BtnTitleText[0] = this.ConfirmTrans.GetChild(1).GetComponent<UIText>();
    this.BtnTitleText[0].font = ttfFont;
    this.BtnTitleText[0].text = DataManager.Instance.mStringTable.GetStringByID(5014U);
    this.BtnTitleText[1] = child.GetChild(7).GetChild(0).GetComponent<UIText>();
    this.BtnTitleText[1].font = ttfFont;
    this.BtnTitleText[1].text = DataManager.Instance.mStringTable.GetStringByID(5015U);
    this.UpdateTechInfo();
    this.SetActive(true);
  }

  public void UpdateTechInfo()
  {
    DataManager instance = DataManager.Instance;
    byte num1 = 0;
    byte num2 = 0;
    TechDataTbl recordByKey = DataManager.Instance.TechData.GetRecordByKey((ushort) this.TechID);
    byte techLevel = instance.GetTechLevel(recordByKey.TechID);
    this.TechName.text = instance.mStringTable.GetStringByID((uint) recordByKey.TechName);
    float num3 = 173.8f / (float) recordByKey.LevelMax;
    this.DegreeRect.sizeDelta = this.DegreeRect.sizeDelta with
    {
      x = num3 * (float) techLevel
    };
    this.LevelStr.ClearString();
    this.LevelStr.IntToFormat((long) techLevel);
    this.LevelStr.IntToFormat((long) recordByKey.LevelMax);
    if (GUIManager.Instance.IsArabic)
      this.LevelStr.AppendFormat("{1}/{0}");
    else
      this.LevelStr.AppendFormat("{0}/{1}");
    this.LevelText.text = this.LevelStr.ToString();
    this.LevelText.SetAllDirty();
    this.LevelText.cachedTextGenerator.Invalidate();
    this.GraphicID = recordByKey.Graphic;
    if ((UnityEngine.Object) GUIManager.Instance.TechMaterial == (UnityEngine.Object) null)
    {
      ((Behaviour) this.TechImage).enabled = false;
    }
    else
    {
      this.TechImage.sprite = GUIManager.Instance.GetTechSprite(this.GraphicID);
      ((MaskableGraphic) this.TechImage).material = GUIManager.Instance.TechMaterial;
      ((Behaviour) this.TechImage).enabled = true;
    }
    this.EffectStr.ClearString();
    this.EffectNextStr.ClearString();
    this.ContentStr.ClearString();
    uint num4 = 0;
    byte Level = Math.Max((byte) 1, techLevel);
    TechLevelTbl Data;
    if (instance.GetTechLevelupData(out Data, (ushort) this.TechID, Level))
    {
      if (techLevel > (byte) 0)
        num4 += Data.EffectVal;
      CString cstring = StringManager.Instance.StaticString1024();
      if (Data.Effect <= (ushort) 1000)
      {
        if (num4 > 0U)
          GameConstants.GetEffectValue(cstring, Data.Effect, 0U, (byte) 6, (float) num4);
      }
      else if (techLevel > (byte) 0)
        GameConstants.GetEffectValue(cstring, Data.Effect, 0U, (byte) 7, (float) num4);
      GameConstants.GetEffectValue(this.ContentStr, Data.Effect, num4, (byte) 0, 0.0f);
      num1 = (byte) cstring[0];
      this.EffectStr.StringToFormat(cstring);
      this.EffectStr.AppendFormat(instance.mStringTable.GetStringByID(5012U));
      this.EffectText.text = this.EffectStr.ToString();
      this.EffectText.SetAllDirty();
      this.EffectText.cachedTextGenerator.Invalidate();
      this.ContText.text = this.ContentStr.ToString();
      this.ContText.SetAllDirty();
      this.ContText.cachedTextGenerator.Invalidate();
    }
    byte num5;
    if ((int) techLevel < (int) recordByKey.LevelMax && instance.GetTechLevelupData(out Data, (ushort) this.TechID, num5 = (byte) ((uint) techLevel + 1U)))
    {
      uint num6 = Data.EffectVal - num4;
      CString cstring = StringManager.Instance.StaticString1024();
      if (Data.Effect <= (ushort) 1000)
        GameConstants.GetEffectValue(cstring, Data.Effect, 0U, (byte) 6, (float) num6);
      else
        GameConstants.GetEffectValue(cstring, Data.Effect, 0U, (byte) 7, (float) num6);
      GameConstants.GetEffectValue(this.ContentStr, Data.Effect, num6, (byte) 0, 0.0f);
      this.ContText.text = this.ContentStr.ToString();
      this.ContText.SetAllDirty();
      this.ContText.cachedTextGenerator.Invalidate();
      num2 = (byte) cstring[0];
      this.EffectNextStr.StringToFormat(cstring);
      this.EffectNextStr.AppendFormat(instance.mStringTable.GetStringByID(5013U));
      this.EffectNextText.text = this.EffectNextStr.ToString();
      this.EffectNextText.SetAllDirty();
      this.EffectNextText.cachedTextGenerator.Invalidate();
      this.ConfirmTrans.gameObject.SetActive(true);
      this.ResearchFull.gameObject.SetActive(false);
      ((Component) this.DegreeRect).gameObject.SetActive(true);
      this.FullFrame.gameObject.SetActive(false);
      this.Frame.gameObject.SetActive(true);
    }
    else
    {
      this.EffectNextText.text = string.Empty;
      this.ConfirmTrans.gameObject.SetActive(false);
      this.ResearchFull.gameObject.SetActive(true);
      ((Component) this.DegreeRect).gameObject.SetActive(false);
      this.FullFrame.gameObject.SetActive(true);
      this.Frame.gameObject.SetActive(false);
    }
    byte num7 = instance.CheckTechState((ushort) this.TechID);
    this.ConfirmBtn.m_BtnID2 = this.TechID;
    this.ConfirmBtn.m_BtnID3 = (int) num7;
    if (num1 == (byte) 0)
    {
      ((Component) this.EffectRect).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.EffectRect).gameObject.SetActive(true);
      this.EffectRect.anchoredPosition = this.EffectRect.anchoredPosition with
      {
        y = num2 != (byte) 0 ? -269f : -281f
      };
    }
    if (num2 == (byte) 0)
    {
      ((Component) this.EffectNextText).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.EffectNextText).gameObject.SetActive(true);
      ((Graphic) this.EffectNextText).rectTransform.anchoredPosition = ((Graphic) this.EffectNextText).rectTransform.anchoredPosition with
      {
        y = num1 != (byte) 0 ? -297f : -280f
      };
    }
    if (((int) num7 & 1) > 0)
    {
      if (((int) num7 & 2) == 0)
      {
        this.LockPanel.gameObject.SetActive(true);
        this.Lock.gameObject.SetActive(true);
        this.Lock1.gameObject.SetActive(false);
      }
      else
      {
        this.Lock.gameObject.SetActive(false);
        this.Lock1.gameObject.SetActive(true);
        this.LockPanel.gameObject.SetActive(false);
      }
    }
    else
    {
      this.Lock.gameObject.SetActive(false);
      this.LockPanel.gameObject.SetActive(false);
      this.Lock1.gameObject.SetActive(false);
    }
    if (GUIManager.Instance.GuideParm1 != (byte) 3 || this.TechID != (int) GUIManager.Instance.GuideParm2)
      return;
    GUIManager.Instance.GuideArrow_Position(new Vector3(0.0f, -132.88f, 0.0f), ArrowDirect.Ar_Up);
  }

  public void SetActive(bool bActive) => this.ThisTransform.gameObject.SetActive(bActive);

  public void TextRefresh()
  {
    ((Behaviour) this.TechName).enabled = false;
    ((Behaviour) this.LevelText).enabled = false;
    ((Behaviour) this.EffectText).enabled = false;
    ((Behaviour) this.EffectNextText).enabled = false;
    ((Behaviour) this.ContText).enabled = false;
    ((Behaviour) this.BtnTitleText[0]).enabled = false;
    ((Behaviour) this.BtnTitleText[1]).enabled = false;
    ((Behaviour) this.TechName).enabled = true;
    ((Behaviour) this.LevelText).enabled = true;
    ((Behaviour) this.EffectText).enabled = true;
    ((Behaviour) this.EffectNextText).enabled = true;
    ((Behaviour) this.ContText).enabled = true;
    ((Behaviour) this.BtnTitleText[0]).enabled = true;
    ((Behaviour) this.BtnTitleText[1]).enabled = true;
  }

  public void UpdateUI(int arge1, int arge2)
  {
    this.TechID = arge1;
    this.UpdateTechInfo();
    this.SetActive(true);
  }

  public void OnDestroy()
  {
    StringManager.Instance.DeSpawnString(this.LevelStr);
    StringManager.Instance.DeSpawnString(this.EffectStr);
    StringManager.Instance.DeSpawnString(this.EffectNextStr);
    StringManager.Instance.DeSpawnString(this.ContentStr);
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        this.SetCreatScrollDelayFlage();
        GameConstants.GetBytes((ushort) this.TechID, GUIManager.Instance.TechSaved, 6);
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_Information, -1, this.TechID);
        break;
      case 1:
        GameConstants.GetBytes((ushort) 0, GUIManager.Instance.TechSaved, 6);
        GUIManager.Instance.HideArrow();
        this.SetActive(false);
        break;
      case 2:
        if (GUIManager.Instance.GuideParm1 == (byte) 3 && this.TechID == (int) GUIManager.Instance.GuideParm2)
        {
          GUIManager.Instance.HideArrow();
          GUIManager.Instance.GuideParm1 = (byte) 3;
          GUIManager.Instance.GuideParm2 = (ushort) this.TechID;
        }
        GameConstants.GetBytes((ushort) 0, GUIManager.Instance.TechSaved, 6);
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
          menu.OpenMenu(EGUIWindow.UI_TechUpgrade, sender.m_BtnID2);
        GameConstants.GetBytes((ushort) 0, GUIManager.Instance.TechSaved, 6);
        break;
    }
  }

  public void SetCreatScrollDelayFlage()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_WindowStack.Count <= 0)
      return;
    for (int index = menu.m_WindowStack.Count - 1; index >= 0; --index)
    {
      GUIWindowStackData mWindow = menu.m_WindowStack[index];
      if (mWindow.m_eWindow == EGUIWindow.UI_TechTree)
      {
        mWindow.m_Arg1 |= 32768;
        menu.m_WindowStack[index] = mWindow;
        break;
      }
    }
  }

  private enum MainControl
  {
    Background,
    Info,
    Skill,
    Price,
    Next,
    Content,
    Button,
    ResearchFull,
  }

  private enum ClickType
  {
    Info,
    Close,
    Confirm,
  }
}
