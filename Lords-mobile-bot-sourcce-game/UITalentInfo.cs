// Decompiled with JetBrains decompiler
// Type: UITalentInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UITalentInfo : IUIButtonClickHandler
{
  private const float MaxWidth = 163f;
  public int TalentID;
  private Image TalentIcon;
  private Image PointIcon;
  private Image LockIcon;
  private UIText TalentName;
  private UIText LevelText;
  private UIText EffectText;
  private UIText EffectNextText;
  private UIText ContText;
  private UIText NeedPointText;
  private UIText TalentPointText;
  private UIText LearnText;
  private UIText LevelMaxText;
  private UIText MaxNeedPointText;
  private UIText MaxLearnText;
  private Transform Lock;
  private Transform Black;
  private Transform FullFrame;
  private Transform Frame;
  private Transform ResearchFull;
  private Transform LearnTrans;
  private RectTransform DegreeRect;
  private RectTransform LvEffectRect;
  private RectTransform ConfirmRect;
  private CString LevelStr;
  private CString EffectStr;
  private CString EffectNextStr;
  private CString ContentStr;
  private CString NeedPointStr;
  private CString TalentPointStr;
  private CString MaxNeedPointStr;
  private UIButton ConfirmBtn;
  private UIButton ConfirmMaxBtn;
  private CanvasGroup LvLight;
  private CanvasGroup LvEffect;
  private bool bLevelup;
  private float StartTime;
  private float TotalTime = 0.6f;
  private float EffLightTime = 1f;
  private ushort GraphicID;
  private byte SaveSlot;
  public RectTransform ThisTransform;

  public UITalentInfo(RectTransform transform, byte SaveSlot)
  {
    this.ThisTransform = transform;
    this.SaveSlot = SaveSlot;
  }

  public void OnOpen(int arg1, int arg2)
  {
    Transform thisTransform = (Transform) this.ThisTransform;
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    DataManager instance = DataManager.Instance;
    this.TalentID = arg1;
    UIButton component1 = ((Transform) this.ThisTransform).GetChild(0).GetComponent<UIButton>();
    component1.m_BtnID1 = 1;
    component1.m_Handler = (IUIButtonClickHandler) this;
    UIButton component2 = thisTransform.GetChild(7).GetComponent<UIButton>();
    component2.m_BtnID1 = 0;
    component2.m_Handler = (IUIButtonClickHandler) this;
    if (GUIManager.Instance.IsArabic)
      ((Component) component2).transform.localScale = new Vector3(-1f, 1f, 1f);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      RectTransform component3 = ((Transform) this.ThisTransform).GetChild(0).GetComponent<RectTransform>();
      component3.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      component3.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    this.TalentIcon = thisTransform.GetChild(3).GetChild(1).GetComponent<Image>();
    this.Frame = thisTransform.GetChild(3).GetChild(3);
    this.Lock = thisTransform.GetChild(3).GetChild(3).GetChild(0);
    this.Black = thisTransform.GetChild(3).GetChild(2);
    this.DegreeRect = thisTransform.GetChild(3).GetChild(3).GetChild(1).GetComponent<RectTransform>();
    this.FullFrame = thisTransform.GetChild(3).GetChild(4);
    this.LevelText = thisTransform.GetChild(3).GetChild(6).GetComponent<UIText>();
    this.TalentName = thisTransform.GetChild(3).GetChild(5).GetComponent<UIText>();
    this.TalentPointText = thisTransform.GetChild(2).GetChild(0).GetComponent<UIText>();
    this.TalentPointText.font = ttfFont;
    UIButtonHint uiButtonHint = thisTransform.GetChild(2).GetChild(1).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint.m_Handler = (MonoBehaviour) GUIManager.Instance.FindMenu(EGUIWindow.UI_Talent);
    if (GUIManager.Instance.IsArabic)
      ((Component) this.TalentIcon).transform.localScale = new Vector3(-1f, 1f, 1f);
    this.EffectText = thisTransform.GetChild(5).GetComponent<UIText>();
    this.EffectNextText = thisTransform.GetChild(6).GetComponent<UIText>();
    this.ContText = thisTransform.GetChild(8).GetChild(0).GetComponent<UIText>();
    UIText contText = this.ContText;
    Font font1 = ttfFont;
    this.TalentName.font = font1;
    Font font2 = font1;
    this.LevelText.font = font2;
    Font font3 = font2;
    this.EffectText.font = font3;
    Font font4 = font3;
    this.EffectNextText.font = font4;
    Font font5 = font4;
    contText.font = font5;
    this.ContText.fontStyle = FontStyle.Normal;
    this.LevelStr = StringManager.Instance.SpawnString();
    this.EffectStr = StringManager.Instance.SpawnString(100);
    this.EffectNextStr = StringManager.Instance.SpawnString(100);
    this.ContentStr = StringManager.Instance.SpawnString(150);
    this.NeedPointStr = StringManager.Instance.SpawnString();
    this.TalentPointStr = StringManager.Instance.SpawnString();
    this.MaxNeedPointStr = StringManager.Instance.SpawnString();
    this.LearnTrans = thisTransform.GetChild(9);
    this.ConfirmRect = this.LearnTrans.GetChild(0).GetComponent<RectTransform>();
    this.PointIcon = ((Transform) this.ConfirmRect).GetChild(0).GetComponent<Image>();
    this.LockIcon = ((Transform) this.ConfirmRect).GetChild(1).GetComponent<Image>();
    this.ConfirmBtn = ((Component) this.ConfirmRect).GetComponent<UIButton>();
    this.ConfirmBtn.m_BtnID1 = 2;
    this.ConfirmBtn.m_Handler = (IUIButtonClickHandler) this;
    this.NeedPointText = ((Transform) this.ConfirmRect).GetChild(2).GetComponent<UIText>();
    this.NeedPointText.font = ttfFont;
    this.LearnText = ((Transform) this.ConfirmRect).GetChild(3).GetComponent<UIText>();
    this.LearnText.font = ttfFont;
    this.LearnText.text = instance.mStringTable.GetStringByID(1506U);
    this.ConfirmMaxBtn = this.LearnTrans.GetChild(1).GetComponent<UIButton>();
    this.ConfirmMaxBtn.m_BtnID1 = 3;
    this.ConfirmMaxBtn.m_Handler = (IUIButtonClickHandler) this;
    this.MaxNeedPointText = this.LearnTrans.GetChild(1).GetChild(1).GetComponent<UIText>();
    this.MaxNeedPointText.font = ttfFont;
    this.MaxLearnText = this.LearnTrans.GetChild(1).GetChild(2).GetComponent<UIText>();
    this.MaxLearnText.font = ttfFont;
    this.MaxLearnText.text = instance.mStringTable.GetStringByID(10031U);
    this.ResearchFull = thisTransform.GetChild(10);
    this.LevelMaxText = this.ResearchFull.GetChild(0).GetComponent<UIText>();
    this.LevelMaxText.font = ttfFont;
    this.LevelMaxText.text = instance.mStringTable.GetStringByID(1507U);
    this.LvLight = thisTransform.GetChild(11).GetComponent<CanvasGroup>();
    this.LvEffectRect = thisTransform.GetChild(12).GetComponent<RectTransform>();
    this.LvEffect = ((Component) this.LvEffectRect).GetComponent<CanvasGroup>();
    this.UpdateTalentInfo();
    this.UpdateRoleTalentPoint();
    this.SetActive(true);
  }

  public void UpdateTalentInfo()
  {
    DataManager instance = DataManager.Instance;
    TalentTbl recordByKey = instance.TalentData.GetRecordByKey((ushort) this.TalentID);
    byte talentLevel = instance.GetTalentLevel(recordByKey.TalentID, this.SaveSlot);
    this.TalentName.text = instance.mStringTable.GetStringByID((uint) recordByKey.NameID);
    float num1 = 163f / (float) recordByKey.LevelMax;
    this.DegreeRect.sizeDelta = this.DegreeRect.sizeDelta with
    {
      x = num1 * (float) talentLevel
    };
    this.LevelStr.ClearString();
    this.LevelStr.IntToFormat((long) talentLevel);
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
      ((Behaviour) this.TalentIcon).enabled = false;
    }
    else
    {
      this.TalentIcon.sprite = GUIManager.Instance.GetTechSprite(this.GraphicID);
      ((MaskableGraphic) this.TalentIcon).material = GUIManager.Instance.TechMaterial;
      ((Behaviour) this.TalentIcon).enabled = true;
    }
    this.NeedPointStr.ClearString();
    this.EffectStr.ClearString();
    this.EffectNextStr.ClearString();
    this.ContentStr.ClearString();
    uint num2 = 0;
    byte Level = Math.Max((byte) 1, talentLevel);
    TalentLevelTbl Data;
    if (instance.GetTalentLevelupData(out Data, (ushort) this.TalentID, Level))
    {
      if (talentLevel > (byte) 0)
        num2 += (uint) Data.EffectVal;
      CString cstring = StringManager.Instance.StaticString1024();
      if (talentLevel == (byte) 0 && recordByKey.NeedTalentID > (ushort) 0)
      {
        this.EffectStr.IntToFormat((long) recordByKey.NeedTalentLv);
        this.EffectStr.StringToFormat(instance.mStringTable.GetStringByID((uint) instance.TalentData.GetRecordByKey(recordByKey.NeedTalentID).NameID));
        this.EffectStr.AppendFormat(instance.mStringTable.GetStringByID(1510U));
      }
      else if (Data.Effect <= (ushort) 1000)
      {
        if (num2 > 0U)
        {
          GameConstants.GetEffectValue(cstring, Data.Effect, 0U, (byte) 6, (float) num2);
          this.EffectStr.StringToFormat(cstring);
          this.EffectStr.AppendFormat(instance.mStringTable.GetStringByID(5012U));
        }
      }
      else
      {
        GameConstants.GetEffectValue(cstring, Data.Effect, 0U, (byte) 7, (float) num2);
        this.EffectStr.StringToFormat(cstring);
        this.EffectStr.AppendFormat(instance.mStringTable.GetStringByID(5012U));
      }
      this.EffectText.text = this.EffectStr.ToString();
      this.EffectText.SetAllDirty();
      this.EffectText.cachedTextGenerator.Invalidate();
      GameConstants.GetEffectValue(this.ContentStr, Data.Effect, num2, (byte) 0, 0.0f);
      this.ContText.text = this.ContentStr.ToString();
      this.ContText.SetAllDirty();
      this.ContText.cachedTextGenerator.Invalidate();
    }
    byte num3;
    if ((int) talentLevel < (int) recordByKey.LevelMax && instance.GetTalentLevelupData(out Data, (ushort) this.TalentID, num3 = (byte) ((uint) talentLevel + 1U)))
    {
      uint num4 = (uint) (ushort) ((uint) Data.EffectVal - num2);
      CString cstring = StringManager.Instance.StaticString1024();
      if (Data.Effect <= (ushort) 1000)
        GameConstants.GetEffectValue(cstring, Data.Effect, 0U, (byte) 6, (float) num4);
      else
        GameConstants.GetEffectValue(cstring, Data.Effect, 0U, (byte) 7, (float) num4);
      GameConstants.GetEffectValue(this.ContentStr, Data.Effect, num4, (byte) 0, 0.0f);
      this.ContText.text = this.ContentStr.ToString();
      this.ContText.SetAllDirty();
      this.ContText.cachedTextGenerator.Invalidate();
      this.EffectNextStr.StringToFormat(cstring);
      this.EffectNextStr.AppendFormat(instance.mStringTable.GetStringByID(5013U));
      this.EffectNextText.text = this.EffectNextStr.ToString();
      this.EffectNextText.SetAllDirty();
      this.EffectNextText.cachedTextGenerator.Invalidate();
      this.NeedPointStr.IntToFormat((long) Data.NeedPoint);
      this.NeedPointStr.AppendFormat("{0}");
      this.NeedPointText.text = this.NeedPointStr.ToString();
      this.NeedPointText.SetAllDirty();
      this.NeedPointText.cachedTextGenerator.Invalidate();
      this.LearnTrans.gameObject.SetActive(true);
      this.ResearchFull.gameObject.SetActive(false);
      this.FullFrame.gameObject.SetActive(false);
      this.Frame.gameObject.SetActive(true);
    }
    else
    {
      this.EffectNextText.text = string.Empty;
      this.LearnTrans.gameObject.SetActive(false);
      this.ResearchFull.gameObject.SetActive(true);
      this.FullFrame.gameObject.SetActive(true);
      this.Frame.gameObject.SetActive(false);
    }
    this.SetBtnStyle(instance.CheckTalentState((ushort) this.TalentID, this.SaveSlot, (byte) 1), recordByKey.LevelMax);
  }

  public void UpdateBtnStyle()
  {
    this.SetBtnStyle((byte) this.ConfirmBtn.m_BtnID3, DataManager.Instance.TalentData.GetRecordByKey((ushort) this.TalentID).LevelMax);
  }

  private void SetBtnStyle(byte state, byte MaxLevel)
  {
    byte level = GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level;
    DataManager instance = DataManager.Instance;
    if (((int) state & 1) > 0)
    {
      TalentTbl recordByKey = instance.TalentData.GetRecordByKey((ushort) this.TalentID);
      this.ConfirmBtn.m_BtnID1 = 4;
      this.ConfirmBtn.m_BtnID2 = (int) recordByKey.NeedTalentID;
      this.ConfirmBtn.m_BtnID4 = (int) recordByKey.NeedTalentLv - (int) instance.GetTalentLevel(recordByKey.NeedTalentID, this.SaveSlot);
      this.ConfirmBtn.m_BtnID3 = (int) instance.CheckTalentState(recordByKey.NeedTalentID, this.SaveSlot, (byte) this.ConfirmBtn.m_BtnID4);
      ((Component) this.ConfirmMaxBtn).gameObject.SetActive(false);
      this.ConfirmRect.anchoredPosition = new Vector2(4f, this.ConfirmRect.anchoredPosition.y);
      this.ConfirmRect.sizeDelta = new Vector2(232f, this.ConfirmRect.sizeDelta.y);
      ((Component) this.PointIcon).gameObject.SetActive(false);
      ((Component) this.LockIcon).gameObject.SetActive(true);
      this.LearnText.text = instance.mStringTable.GetStringByID(10030U);
      this.NeedPointText.text = string.Empty;
    }
    else if (level < (byte) 16)
    {
      this.ConfirmBtn.m_BtnID1 = 2;
      this.ConfirmBtn.m_BtnID2 = this.TalentID;
      this.ConfirmBtn.m_BtnID3 = (int) state;
      this.ConfirmBtn.m_BtnID4 = 1;
      ((Component) this.ConfirmMaxBtn).gameObject.SetActive(false);
      this.ConfirmRect.anchoredPosition = new Vector2(4f, this.ConfirmRect.anchoredPosition.y);
      this.ConfirmRect.sizeDelta = new Vector2(232f, this.ConfirmRect.sizeDelta.y);
      ((Component) this.PointIcon).gameObject.SetActive(true);
      ((Component) this.LockIcon).gameObject.SetActive(false);
      this.LearnText.text = instance.mStringTable.GetStringByID(1506U);
    }
    else
    {
      this.ConfirmBtn.m_BtnID1 = 2;
      this.ConfirmBtn.m_BtnID2 = this.TalentID;
      this.ConfirmBtn.m_BtnID3 = (int) state;
      this.ConfirmBtn.m_BtnID4 = 1;
      ((Component) this.ConfirmMaxBtn).gameObject.SetActive(true);
      this.ConfirmMaxBtn.m_BtnID2 = this.TalentID;
      int needTalentPoint = (int) instance.GetNeedTalentPoint((ushort) this.TalentID, ref MaxLevel, this.SaveSlot);
      this.ConfirmMaxBtn.m_BtnID4 = (int) MaxLevel - (int) instance.GetTalentLevel((ushort) this.TalentID, this.SaveSlot);
      byte addLevel = (byte) Mathf.Clamp(this.ConfirmMaxBtn.m_BtnID4, 1, (int) MaxLevel);
      this.ConfirmMaxBtn.m_BtnID3 = (int) instance.CheckTalentState((ushort) this.TalentID, this.SaveSlot, addLevel);
      this.MaxNeedPointStr.ClearString();
      this.MaxNeedPointStr.IntToFormat((long) this.ConfirmMaxBtn.m_BtnID4);
      this.MaxNeedPointStr.AppendFormat("{0}");
      this.MaxNeedPointText.text = this.MaxNeedPointStr.ToString();
      this.MaxNeedPointText.SetAllDirty();
      this.MaxNeedPointText.cachedTextGenerator.Invalidate();
      this.ConfirmRect.anchoredPosition = new Vector2(-105f, this.ConfirmRect.anchoredPosition.y);
      this.ConfirmRect.sizeDelta = new Vector2(180f, this.ConfirmRect.sizeDelta.y);
      ((Component) this.PointIcon).gameObject.SetActive(true);
      ((Component) this.LockIcon).gameObject.SetActive(false);
      this.LearnText.text = instance.mStringTable.GetStringByID(1506U);
    }
    ColorBlock colors = this.ConfirmBtn.colors;
    if (((int) state & 1) > 0)
    {
      this.Black.gameObject.SetActive(true);
      this.Lock.gameObject.SetActive(true);
    }
    else
    {
      this.Black.gameObject.SetActive(false);
      this.Lock.gameObject.SetActive(false);
    }
    ((ColorBlock) ref colors).highlightedColor = ((ColorBlock) ref colors).normalColor;
    this.ConfirmBtn.colors = colors;
  }

  public void UpdateRoleTalentPoint()
  {
    this.TalentPointStr.ClearString();
    if (this.SaveSlot == (byte) 0)
      this.TalentPointStr.IntToFormat((long) DataManager.Instance.RoleTalentPoint);
    else
      this.TalentPointStr.IntToFormat((long) DataManager.Instance.SaveTalentData[0].RoleTalentPoint);
    this.TalentPointStr.AppendFormat("{0}");
    this.TalentPointText.text = this.TalentPointStr.ToString();
    this.TalentPointText.SetAllDirty();
    this.TalentPointText.cachedTextGenerator.Invalidate();
  }

  public void SetActive(bool bActive)
  {
    ((Component) this.ThisTransform).gameObject.SetActive(bActive);
  }

  public void UpdateUI(int arge1, int arge2)
  {
    if (arge1 == -1)
    {
      this.TalentIcon.sprite = GUIManager.Instance.GetTechSprite(this.GraphicID);
      ((MaskableGraphic) this.TalentIcon).material = GUIManager.Instance.TechMaterial;
      ((Behaviour) this.TalentIcon).enabled = true;
    }
    else
    {
      this.TalentID = arge1;
      this.UpdateTalentInfo();
      this.SetActive(true);
    }
  }

  private void ShowLevelupEffect()
  {
    this.StartTime = 0.0f;
    this.bLevelup = true;
    this.LvEffectRect.anchoredPosition = this.LvEffectRect.anchoredPosition with
    {
      y = 21f
    };
    AudioManager.Instance.PlayUISFX(UIKind.SkillLvelup);
  }

  public void Update()
  {
    if (!this.bLevelup)
      return;
    float num1 = Mathf.Clamp(this.StartTime / this.TotalTime, 0.0f, 1f);
    float num2 = 260f * num1;
    this.LvEffectRect.anchoredPosition = this.LvEffectRect.anchoredPosition with
    {
      y = 21f + num2
    };
    this.LvEffect.alpha = (double) num1 >= 0.5 ? (float) (1.0 - ((double) num1 - 0.5) / 0.5) : (float) (1.0 * (double) num1 / 0.5);
    float num3 = Mathf.Clamp(this.StartTime / this.EffLightTime, 0.0f, 1f);
    this.LvLight.alpha = (double) num3 >= 0.5 ? (float) (1.0 - ((double) num3 - 0.5) / 0.5) : (float) (1.0 * (double) num3 / 0.5);
    if ((double) this.StartTime > (double) this.TotalTime && (double) this.StartTime > (double) this.EffLightTime)
      this.bLevelup = false;
    this.StartTime += Time.smoothDeltaTime;
  }

  public void TextRefresh()
  {
    ((Behaviour) this.TalentName).enabled = false;
    ((Behaviour) this.LevelText).enabled = false;
    ((Behaviour) this.EffectText).enabled = false;
    ((Behaviour) this.EffectNextText).enabled = false;
    ((Behaviour) this.ContText).enabled = false;
    ((Behaviour) this.NeedPointText).enabled = false;
    ((Behaviour) this.TalentPointText).enabled = false;
    ((Behaviour) this.LearnText).enabled = false;
    ((Behaviour) this.LevelMaxText).enabled = false;
    ((Behaviour) this.TalentName).enabled = true;
    ((Behaviour) this.LevelText).enabled = true;
    ((Behaviour) this.EffectText).enabled = true;
    ((Behaviour) this.EffectNextText).enabled = true;
    ((Behaviour) this.ContText).enabled = true;
    ((Behaviour) this.NeedPointText).enabled = true;
    ((Behaviour) this.TalentPointText).enabled = true;
    ((Behaviour) this.LearnText).enabled = true;
    ((Behaviour) this.LevelMaxText).enabled = true;
    ((Behaviour) this.MaxLearnText).enabled = false;
    ((Behaviour) this.MaxLearnText).enabled = true;
    ((Behaviour) this.MaxNeedPointText).enabled = false;
    ((Behaviour) this.MaxNeedPointText).enabled = true;
  }

  public void OnDestroy()
  {
    StringManager.Instance.DeSpawnString(this.LevelStr);
    StringManager.Instance.DeSpawnString(this.EffectStr);
    StringManager.Instance.DeSpawnString(this.EffectNextStr);
    StringManager.Instance.DeSpawnString(this.ContentStr);
    StringManager.Instance.DeSpawnString(this.NeedPointStr);
    StringManager.Instance.DeSpawnString(this.TalentPointStr);
    StringManager.Instance.DeSpawnString(this.MaxNeedPointStr);
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        this.SetTalentSaveFlag();
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_Information, -2, this.TalentID << 16 | (int) this.SaveSlot);
        GameConstants.GetBytes((ushort) this.TalentID, GUIManager.Instance.TalentSaved, 5);
        break;
      case 1:
        DataManager.Instance.CheckTalentSend();
        GameConstants.GetBytes((ushort) 0, GUIManager.Instance.TalentSaved, 5);
        this.SetActive(false);
        break;
      case 2:
      case 4:
        GameConstants.GetBytes((ushort) 0, GUIManager.Instance.TalentSaved, 5);
        ushort btnId2_1 = (ushort) sender.m_BtnID2;
        if ((sender.m_BtnID3 & 1) == 0)
        {
          if ((sender.m_BtnID3 & 8) > 0)
          {
            if (sender.m_BtnID1 == 2)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1504U), (ushort) byte.MaxValue);
              break;
            }
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14709U), (ushort) byte.MaxValue);
            break;
          }
          if (this.SaveSlot == (byte) 0)
            DataManager.Instance.sendAddTalentLevelQueue(btnId2_1, (byte) sender.m_BtnID4, (byte) sender.m_BtnID1);
          else
            DataManager.Instance.sendTalentSaveQueue(btnId2_1, this.SaveSlot, (byte) sender.m_BtnID4, (byte) sender.m_BtnID1);
          this.ShowLevelupEffect();
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Talent, 0);
          break;
        }
        if (sender.m_BtnID1 == 2)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1512U), (ushort) byte.MaxValue);
          break;
        }
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(10028U), (ushort) byte.MaxValue);
        break;
      case 3:
        GameConstants.GetBytes((ushort) 0, GUIManager.Instance.TalentSaved, 5);
        ushort btnId2_2 = (ushort) sender.m_BtnID2;
        if ((sender.m_BtnID3 & 8) > 0)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1504U), (ushort) byte.MaxValue);
          break;
        }
        if (this.SaveSlot == (byte) 0)
          DataManager.Instance.sendAddTalentLevelQueue(btnId2_2, (byte) sender.m_BtnID4, (byte) sender.m_BtnID1);
        else
          DataManager.Instance.sendTalentSaveQueue(btnId2_2, this.SaveSlot, (byte) sender.m_BtnID4, (byte) 0);
        this.ShowLevelupEffect();
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Talent, 0);
        break;
    }
  }

  public void SetTalentSaveFlag()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_WindowStack.Count <= 0)
      return;
    for (int index = menu.m_WindowStack.Count - 1; index >= 0; --index)
    {
      GUIWindowStackData mWindow = menu.m_WindowStack[index];
      if (mWindow.m_eWindow == EGUIWindow.UI_Talent)
      {
        mWindow.m_Arg1 |= 32768;
        mWindow.m_Arg2 = 1;
        menu.m_WindowStack[index] = mWindow;
        break;
      }
    }
  }

  private enum MainControl
  {
    BackgroundBtn,
    Background,
    Point,
    TalentItem,
    Image,
    TotalEffect,
    NextEffect,
    Info,
    Content,
    Learn,
    LvMax,
    LvupLight,
    LvupEff,
  }

  private enum LeaveControl
  {
    Direction,
    SkillPic,
    Black,
    Frame,
    FrameFull,
    Name,
    LvText,
  }

  public enum ClickType
  {
    Info,
    Close,
    Confirm,
    ConfirmMax,
    ConfirmUnlock,
  }

  public enum LevelupStyle : byte
  {
    eNone,
    eLevelup,
    eLevelupMax,
    eUnLock,
  }
}
