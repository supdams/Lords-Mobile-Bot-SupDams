// Decompiled with JetBrains decompiler
// Type: UIVIPLevelUP
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIVIPLevelUP : GUIWindow, IUIButtonClickHandler
{
  private Transform AGS_Form;
  private CString LevelText;
  private CString LevelUpText;
  private CString PointText;
  private CString PointText2;
  private Image Light;
  public UIButton CloseBtn;
  public RectTransform BG_Rt;

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
    byte x1 = (byte) arg1;
    this.LevelText = StringManager.Instance.SpawnString(50);
    this.LevelText.ClearString();
    this.LevelText.IntToFormat((long) x1);
    this.LevelText.AppendFormat("{0}");
    this.LevelUpText = StringManager.Instance.SpawnString(50);
    this.PointText = StringManager.Instance.SpawnString(50);
    this.PointText2 = StringManager.Instance.SpawnString(50);
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    this.Light = this.AGS_Form.GetChild(0).GetComponent<Image>();
    ((Graphic) this.Light).color = (Color) new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, (byte) 176);
    this.BG_Rt = this.AGS_Form.GetChild(1) as RectTransform;
    UIButton component1 = this.AGS_Form.GetChild(2).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_EffectType = e_EffectType.e_Scale;
    this.CloseBtn = component1;
    UIText component2 = this.AGS_Form.GetChild(3).GetComponent<UIText>();
    component2.font = ttfFont;
    component2.text = DataManager.Instance.mStringTable.GetStringByID(5797U);
    this.Light = this.AGS_Form.GetChild(4).GetComponent<Image>();
    UIText component3 = this.AGS_Form.GetChild(5).GetChild(0).GetComponent<UIText>();
    component3.font = ttfFont;
    component3.text = this.LevelText.ToString();
    component3.SetAllDirty();
    component3.cachedTextGenerator.Invalidate();
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform component4 = this.AGS_Form.GetChild(5).GetComponent<RectTransform>();
      ((Transform) component4).localScale = new Vector3(-1f, 1f, 1f);
      component4.anchoredPosition = new Vector2(component4.anchoredPosition.x + 142f, component4.anchoredPosition.y);
      ((Transform) this.AGS_Form.GetChild(5).GetChild(0).GetComponent<RectTransform>()).localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
    }
    switch (arg2)
    {
      case 0:
        this.AGS_Form.GetChild(6).gameObject.SetActive(true);
        this.AGS_Form.GetChild(7).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).gameObject.SetActive(false);
        int x2 = arg1 >> 16;
        byte x3 = (byte) (arg1 & (int) ushort.MaxValue);
        this.LevelUpText.ClearString();
        this.LevelUpText.IntToFormat((long) x2);
        this.LevelUpText.IntToFormat((long) x3);
        if (GUIManager.Instance.IsArabic)
          this.LevelUpText.AppendFormat("<color=#35F76CFF>{1} VIP ←</color>{0} VIP ");
        else
          this.LevelUpText.AppendFormat("VIP {0} <color=#35F76CFF>→ VIP {1}</color>");
        UIText component5 = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UIText>();
        component5.font = ttfFont;
        component5.text = this.LevelUpText.ToString();
        component5.SetAllDirty();
        component5.cachedTextGenerator.Invalidate();
        UIButton component6 = this.AGS_Form.GetChild(6).GetChild(2).GetComponent<UIButton>();
        component6.m_Handler = (IUIButtonClickHandler) this;
        component6.m_EffectType = e_EffectType.e_Scale;
        component6.m_BtnID1 = 1;
        UIText component7 = this.AGS_Form.GetChild(6).GetChild(2).GetChild(0).GetComponent<UIText>();
        component7.font = ttfFont;
        component7.text = DataManager.Instance.mStringTable.GetStringByID(7706U);
        if (GUIManager.Instance.IsArabic)
        {
          RectTransform component8 = this.AGS_Form.GetChild(6).GetChild(0).GetComponent<RectTransform>();
          ((Transform) component8).localScale = new Vector3(-1f, 1f, 1f);
          component8.anchoredPosition = new Vector2(component8.anchoredPosition.x + 52f, component8.anchoredPosition.y);
          break;
        }
        break;
      case 1:
        this.AGS_Form.GetChild(3).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7705U);
        this.AGS_Form.GetChild(6).gameObject.SetActive(false);
        this.AGS_Form.GetChild(7).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).gameObject.SetActive(false);
        VIP_DataTbl recordByKey1 = DataManager.Instance.VIPLevelTable.GetRecordByKey((ushort) DataManager.Instance.RoleAttr.VIPLevel);
        int x4 = (int) recordByKey1.loginPoint + (int) recordByKey1.dailyAdd * (int) DataManager.Instance.RoleAttr.SuccessiveLoginDays;
        if (x4 > 600)
          x4 = 600;
        this.PointText.ClearString();
        this.PointText.IntToFormat((long) x4);
        this.PointText.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7742U));
        int x5 = x4 + (int) recordByKey1.dailyAdd;
        if (x5 > 600)
          x5 = 600;
        this.PointText2.ClearString();
        this.PointText2.IntToFormat((long) x5);
        this.PointText2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7740U));
        this.LevelUpText.ClearString();
        this.LevelUpText.IntToFormat((long) ((int) DataManager.Instance.RoleAttr.SuccessiveLoginDays + 1));
        this.LevelUpText.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7741U));
        UIText component9 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
        component9.font = ttfFont;
        component9.text = this.PointText.ToString();
        component9.SetAllDirty();
        component9.cachedTextGenerator.Invalidate();
        UIText component10 = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<UIText>();
        component10.font = ttfFont;
        component10.text = this.LevelUpText.ToString();
        component10.SetAllDirty();
        component10.cachedTextGenerator.Invalidate();
        UIText component11 = this.AGS_Form.GetChild(7).GetChild(2).GetComponent<UIText>();
        component11.font = ttfFont;
        component11.text = this.PointText2.ToString();
        component11.SetAllDirty();
        component11.cachedTextGenerator.Invalidate();
        UIText component12 = this.AGS_Form.GetChild(7).GetChild(3).GetComponent<UIText>();
        component12.font = ttfFont;
        component12.text = DataManager.Instance.mStringTable.GetStringByID(7743U);
        break;
      case 2:
        this.AGS_Form.GetChild(6).gameObject.SetActive(false);
        this.AGS_Form.GetChild(7).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).gameObject.SetActive(true);
        this.LevelUpText.ClearString();
        this.LevelUpText.IntToFormat((long) ((int) x1 - 1));
        this.LevelUpText.IntToFormat((long) x1);
        if (GUIManager.Instance.IsArabic)
          this.LevelUpText.AppendFormat("<color=#35F76CFF>{1} VIP ←</color>{0} VIP ");
        else
          this.LevelUpText.AppendFormat("VIP {0} <color=#35F76CFF>→ VIP {1}</color>");
        VIP_DataTbl recordByKey2 = DataManager.Instance.VIPLevelTable.GetRecordByKey((ushort) ((uint) DataManager.Instance.RoleAttr.VIPLevel - 1U));
        int x6 = (int) recordByKey2.loginPoint + (int) recordByKey2.dailyAdd * (int) DataManager.Instance.RoleAttr.SuccessiveLoginDays;
        if (x6 > 600)
          x6 = 600;
        this.PointText.ClearString();
        this.PointText.IntToFormat((long) x6);
        this.PointText.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7742U));
        UIText component13 = this.AGS_Form.GetChild(8).GetChild(1).GetComponent<UIText>();
        component13.font = ttfFont;
        component13.text = this.LevelUpText.ToString();
        component13.SetAllDirty();
        component13.cachedTextGenerator.Invalidate();
        UIText component14 = this.AGS_Form.GetChild(8).GetChild(2).GetComponent<UIText>();
        component14.font = ttfFont;
        component14.text = this.PointText.ToString();
        component14.SetAllDirty();
        component14.cachedTextGenerator.Invalidate();
        UIText component15 = this.AGS_Form.GetChild(8).GetChild(3).GetComponent<UIText>();
        component15.font = ttfFont;
        component15.text = DataManager.Instance.mStringTable.GetStringByID(7743U);
        if (GUIManager.Instance.IsArabic)
        {
          RectTransform component16 = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<RectTransform>();
          ((Transform) component16).localScale = new Vector3(-1f, 1f, 1f);
          component16.anchoredPosition = new Vector2(component16.anchoredPosition.x + 52f, component16.anchoredPosition.y);
          break;
        }
        break;
    }
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      RectTransform component17 = this.AGS_Form.GetChild(0).GetComponent<RectTransform>();
      component17.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      component17.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    AudioManager.Instance.PlayUISFX(UIKind.DominanceLevelup);
    GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
    GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, SpeciallyEffect_Kind.AddVIP_Point, ItemID: (ushort) 0, EndTime: 2f);
    GUIManager.Instance.LoadLvUpLight(this.transform.GetChild(0));
  }

  public override void OnClose()
  {
    StringManager.Instance.DeSpawnString(this.LevelText);
    StringManager.Instance.DeSpawnString(this.LevelUpText);
    StringManager.Instance.DeSpawnString(this.PointText);
    StringManager.Instance.DeSpawnString(this.PointText2);
    GUIManager.Instance.ReleaseLvUpLight();
  }

  private void Update()
  {
    ((Component) this.Light).transform.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public void OnButtonClick(UIButton sender)
  {
    GUIManager.Instance.CloseMenu(EGUIWindow.UI_VipLevelUp);
    if (sender.m_BtnID1 == 1)
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      menu.ClearWindowStack();
      menu.OpenMenu(EGUIWindow.UI_VIP);
    }
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(3).GetComponent<UIText>();
    if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.AGS_Form.GetChild(5).GetChild(0).GetComponent<UIText>();
    if ((Object) component2 != (Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UIText>();
    if ((Object) component3 != (Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.AGS_Form.GetChild(6).GetChild(2).GetChild(0).GetComponent<UIText>();
    if ((Object) component4 != (Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    UIText component5 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
    if ((Object) component5 != (Object) null && ((Behaviour) component5).enabled)
    {
      ((Behaviour) component5).enabled = false;
      ((Behaviour) component5).enabled = true;
    }
    UIText component6 = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<UIText>();
    if ((Object) component6 != (Object) null && ((Behaviour) component6).enabled)
    {
      ((Behaviour) component6).enabled = false;
      ((Behaviour) component6).enabled = true;
    }
    UIText component7 = this.AGS_Form.GetChild(7).GetChild(2).GetComponent<UIText>();
    if ((Object) component7 != (Object) null && ((Behaviour) component7).enabled)
    {
      ((Behaviour) component7).enabled = false;
      ((Behaviour) component7).enabled = true;
    }
    UIText component8 = this.AGS_Form.GetChild(7).GetChild(3).GetComponent<UIText>();
    if ((Object) component8 != (Object) null && ((Behaviour) component8).enabled)
    {
      ((Behaviour) component8).enabled = false;
      ((Behaviour) component8).enabled = true;
    }
    UIText component9 = this.AGS_Form.GetChild(8).GetChild(1).GetComponent<UIText>();
    if ((Object) component9 != (Object) null && ((Behaviour) component9).enabled)
    {
      ((Behaviour) component9).enabled = false;
      ((Behaviour) component9).enabled = true;
    }
    UIText component10 = this.AGS_Form.GetChild(8).GetChild(2).GetComponent<UIText>();
    if ((Object) component10 != (Object) null && ((Behaviour) component10).enabled)
    {
      ((Behaviour) component10).enabled = false;
      ((Behaviour) component10).enabled = true;
    }
    UIText component11 = this.AGS_Form.GetChild(8).GetChild(3).GetComponent<UIText>();
    if (!((Object) component11 != (Object) null) || !((Behaviour) component11).enabled)
      return;
    ((Behaviour) component11).enabled = false;
    ((Behaviour) component11).enabled = true;
  }

  private enum e_AGS_UI_VIPLevelUP_Editor
  {
    BackCover,
    BG,
    CloseBtn,
    Title,
    Light,
    VIPICON,
    LVUPGroup,
    EXPGroup,
    DailyGroup,
  }

  private enum e_AGS_LVUPGroup
  {
    SmallVip,
    LevelText,
    UIButton,
  }

  private enum e_AGS_EXPGroup
  {
    AcqurePoint,
    Contiune,
    Tomorrow,
    Tips,
  }

  private enum e_AGS_DailyGroup
  {
    SmallVip,
    LevelText,
    AcqurePoint,
    Tips,
  }
}
