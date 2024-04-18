// Decompiled with JetBrains decompiler
// Type: UIVIP
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIVIP : GUIWindow, IUIButtonClickHandler
{
  private Transform AGS_Form;
  private Door door;
  private CString[] tmpString = new CString[8];
  private ushort targetLevel;
  private CString Ltext;
  private CString Rtext;
  private Transform LBtn;
  private Transform RBtn;
  private float TmpTime;
  private Vector3 Vec3Instance;
  private float MoveTime1;
  private float MoveTime2;
  private float GetPointTime;
  private Image Img_GetPoint;
  private ushort lastVipLevel;

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager instance = DataManager.Instance;
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    for (int index = 0; index < 6; ++index)
      this.tmpString[index] = StringManager.Instance.SpawnString();
    UIButton component1 = this.AGS_Form.GetChild(0).GetChild(0).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_EffectType = e_EffectType.e_Scale;
    component1.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component1.image).material = this.door.LoadMaterial();
    Image component2 = this.AGS_Form.GetChild(0).GetComponent<Image>();
    component2.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component2).material = this.door.LoadMaterial();
    ((Behaviour) component2).enabled = !GUIManager.Instance.bOpenOnIPhoneX;
    UIText component3 = this.AGS_Form.GetChild(2).GetComponent<UIText>();
    component3.text = DataManager.Instance.mStringTable.GetStringByID(7701U);
    component3.font = ttfFont;
    UIText component4 = this.AGS_Form.GetChild(3).GetComponent<UIText>();
    component4.text = DataManager.Instance.mStringTable.GetStringByID(7702U);
    component4.font = ttfFont;
    this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIText>().font = ttfFont;
    UIButton component5 = this.AGS_Form.GetChild(5).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    component5.m_EffectType = e_EffectType.e_Scale;
    this.Img_GetPoint = this.AGS_Form.GetChild(5).GetChild(0).GetComponent<Image>();
    UIText component6 = this.AGS_Form.GetChild(5).GetChild(1).GetComponent<UIText>();
    component6.text = DataManager.Instance.mStringTable.GetStringByID(7704U);
    component6.font = ttfFont;
    this.AGS_Form.GetChild(7).GetComponent<UIText>().font = ttfFont;
    UIButton component7 = this.AGS_Form.GetChild(8).GetComponent<UIButton>();
    component7.m_Handler = (IUIButtonClickHandler) this;
    component7.m_EffectType = e_EffectType.e_Scale;
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform component8 = ((Component) component7).gameObject.GetComponent<RectTransform>();
      ((Transform) component8).localScale = new Vector3(-1f, 1f, 1f);
      component8.anchoredPosition = new Vector2(component8.anchoredPosition.x + 44f, component8.anchoredPosition.y);
    }
    UIText component9 = this.AGS_Form.GetChild(11).GetComponent<UIText>();
    component9.text = DataManager.Instance.mStringTable.GetStringByID(7705U);
    component9.font = ttfFont;
    UIText component10 = this.AGS_Form.GetChild(14).GetChild(2).GetComponent<UIText>();
    component10.text = string.Empty;
    component10.font = ttfFont;
    UIText component11 = this.AGS_Form.GetChild(14).GetChild(3).GetComponent<UIText>();
    component11.text = DataManager.Instance.mStringTable.GetStringByID(7706U);
    component11.font = ttfFont;
    UIText component12 = this.AGS_Form.GetChild(16).GetChild(0).GetChild(0).GetComponent<UIText>();
    component12.text = string.Empty;
    component12.font = ttfFont;
    UIText component13 = this.AGS_Form.GetChild(15).GetChild(2).GetComponent<UIText>();
    component13.text = string.Empty;
    component13.font = ttfFont;
    UIText component14 = this.AGS_Form.GetChild(15).GetChild(3).GetComponent<UIText>();
    component14.text = DataManager.Instance.mStringTable.GetStringByID(7707U);
    component14.font = ttfFont;
    UIText component15 = this.AGS_Form.GetChild(16).GetChild(0).GetChild(1).GetComponent<UIText>();
    component15.text = string.Empty;
    component15.font = ttfFont;
    UIButton component16 = this.AGS_Form.GetChild(17).GetComponent<UIButton>();
    component16.m_Handler = (IUIButtonClickHandler) this;
    this.LBtn = ((Component) component16).transform;
    this.MoveTime1 = this.LBtn.localPosition.x;
    UIButton component17 = this.AGS_Form.GetChild(18).GetComponent<UIButton>();
    component17.m_Handler = (IUIButtonClickHandler) this;
    this.RBtn = ((Component) component17).transform;
    this.MoveTime2 = this.RBtn.localPosition.x;
    if (GUIManager.Instance.IsArabic)
      ((Transform) this.AGS_Form.GetChild(6).gameObject.GetComponent<RectTransform>()).localScale = new Vector3(-1f, 1f, 1f);
    this.lastVipLevel = (ushort) (instance.VIPLevelTable.TableCount - 1);
    this.UpdateInfo();
    this.Ltext = StringManager.Instance.SpawnString(1200);
    this.Rtext = StringManager.Instance.SpawnString(1200);
    this.SetShowVip((ushort) 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 8);
  }

  private void UpdateInfo()
  {
    VIP_DataTbl recordByKey = DataManager.Instance.VIPLevelTable.GetRecordByKey((ushort) DataManager.Instance.RoleAttr.VIPLevel);
    UIText component1 = this.AGS_Form.GetChild(2).GetComponent<UIText>();
    this.tmpString[0].ClearString();
    this.tmpString[0].Append(DataManager.Instance.mStringTable.GetStringByID(7701U));
    int x = (int) recordByKey.loginPoint + (int) recordByKey.dailyAdd * ((int) DataManager.Instance.RoleAttr.SuccessiveLoginDays + 1);
    if (x > 600)
      x = 600;
    this.tmpString[0].IntToFormat((long) x);
    this.tmpString[0].AppendFormat("{0}");
    component1.text = this.tmpString[0].ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    UIText component2 = this.AGS_Form.GetChild(3).GetComponent<UIText>();
    this.tmpString[1].ClearString();
    this.tmpString[1].Append(DataManager.Instance.mStringTable.GetStringByID(7702U));
    this.tmpString[1].IntToFormat((long) ((int) DataManager.Instance.RoleAttr.SuccessiveLoginDays + 1), bNumber: true);
    this.tmpString[1].AppendFormat("{0}");
    component2.text = this.tmpString[1].ToString();
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
    UIText component3 = this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIText>();
    this.tmpString[2].ClearString();
    if ((int) recordByKey.VIPLevel > (int) this.lastVipLevel)
    {
      this.tmpString[2].Append(DataManager.Instance.mStringTable.GetStringByID(7725U));
    }
    else
    {
      this.tmpString[2].Append(DataManager.Instance.mStringTable.GetStringByID(7703U));
      this.tmpString[2].IntToFormat((long) DataManager.Instance.RoleAttr.VipPoint, bNumber: true);
      this.tmpString[2].IntToFormat((long) recordByKey.VIPPoint, bNumber: true);
      this.tmpString[2].AppendFormat("{0} / {1}");
    }
    component3.text = this.tmpString[2].ToString();
    component3.SetAllDirty();
    component3.cachedTextGenerator.Invalidate();
    this.AGS_Form.GetChild(4).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, Mathf.Min((float) DataManager.Instance.RoleAttr.VipPoint / (float) recordByKey.VIPPoint, 1f) * 422f);
    UIText component4 = this.AGS_Form.GetChild(7).GetComponent<UIText>();
    this.tmpString[3].ClearString();
    this.tmpString[3].IntToFormat((long) recordByKey.VIPLevel);
    this.tmpString[3].AppendFormat("{0}");
    component4.text = this.tmpString[3].ToString();
    component4.SetAllDirty();
    component4.cachedTextGenerator.Invalidate();
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(2).GetComponent<UIText>();
    if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.AGS_Form.GetChild(3).GetComponent<UIText>();
    if ((Object) component2 != (Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIText>();
    if ((Object) component3 != (Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.AGS_Form.GetChild(5).GetChild(1).GetComponent<UIText>();
    if ((Object) component4 != (Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    UIText component5 = this.AGS_Form.GetChild(7).GetComponent<UIText>();
    if ((Object) component5 != (Object) null && ((Behaviour) component5).enabled)
    {
      ((Behaviour) component5).enabled = false;
      ((Behaviour) component5).enabled = true;
    }
    UIText component6 = this.AGS_Form.GetChild(11).GetComponent<UIText>();
    if ((Object) component6 != (Object) null && ((Behaviour) component6).enabled)
    {
      ((Behaviour) component6).enabled = false;
      ((Behaviour) component6).enabled = true;
    }
    UIText component7 = this.AGS_Form.GetChild(14).GetChild(2).GetComponent<UIText>();
    if ((Object) component7 != (Object) null && ((Behaviour) component7).enabled)
    {
      ((Behaviour) component7).enabled = false;
      ((Behaviour) component7).enabled = true;
    }
    UIText component8 = this.AGS_Form.GetChild(14).GetChild(3).GetComponent<UIText>();
    if ((Object) component8 != (Object) null && ((Behaviour) component8).enabled)
    {
      ((Behaviour) component8).enabled = false;
      ((Behaviour) component8).enabled = true;
    }
    UIText component9 = this.AGS_Form.GetChild(15).GetChild(2).GetComponent<UIText>();
    if ((Object) component9 != (Object) null && ((Behaviour) component9).enabled)
    {
      ((Behaviour) component9).enabled = false;
      ((Behaviour) component9).enabled = true;
    }
    UIText component10 = this.AGS_Form.GetChild(15).GetChild(3).GetComponent<UIText>();
    if ((Object) component10 != (Object) null && ((Behaviour) component10).enabled)
    {
      ((Behaviour) component10).enabled = false;
      ((Behaviour) component10).enabled = true;
    }
    UIText component11 = this.AGS_Form.GetChild(16).GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((Object) component11 != (Object) null && ((Behaviour) component11).enabled)
    {
      ((Behaviour) component11).enabled = false;
      ((Behaviour) component11).enabled = true;
    }
    UIText component12 = this.AGS_Form.GetChild(16).GetChild(0).GetChild(1).GetComponent<UIText>();
    if (!((Object) component12 != (Object) null) || !((Behaviour) component12).enabled)
      return;
    ((Behaviour) component12).enabled = false;
    ((Behaviour) component12).enabled = true;
  }

  public override void OnClose()
  {
    for (int index = 0; index < this.tmpString.Length; ++index)
      StringManager.Instance.DeSpawnString(this.tmpString[index]);
    StringManager.Instance.DeSpawnString(this.Ltext);
    StringManager.Instance.DeSpawnString(this.Rtext);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 7);
  }

  private void SetShowVip(ushort _targetLevel)
  {
    ushort vipLevel = (ushort) DataManager.Instance.RoleAttr.VIPLevel;
    if (_targetLevel == (ushort) 0)
      _targetLevel = vipLevel;
    if ((int) _targetLevel > (int) this.lastVipLevel)
      _targetLevel = this.lastVipLevel;
    if ((int) this.targetLevel == (int) _targetLevel)
      return;
    this.targetLevel = _targetLevel;
    this.AGS_Form.GetChild(17).gameObject.SetActive(this.targetLevel != (ushort) 1);
    this.AGS_Form.GetChild(18).gameObject.SetActive((int) this.targetLevel != (int) this.lastVipLevel);
    DataManager instance = DataManager.Instance;
    VIP_DataTbl recordByKey1 = instance.VIPLevelTable.GetRecordByKey(this.targetLevel);
    VIP_DataTbl recordByKey2 = instance.VIPLevelTable.GetRecordByKey((ushort) ((uint) this.targetLevel + 1U));
    UIText component1 = this.AGS_Form.GetChild(14).GetChild(2).GetComponent<UIText>();
    this.tmpString[4].ClearString();
    this.tmpString[4].Append(DataManager.Instance.mStringTable.GetStringByID(7705U));
    this.tmpString[4].IntToFormat((long) recordByKey1.VIPLevel);
    this.tmpString[4].AppendFormat(" {0}");
    component1.text = this.tmpString[4].ToString();
    if ((int) recordByKey1.VIPLevel > (int) vipLevel)
      ((Graphic) component1).color = new Color(0.6f, 0.58f, 0.38f);
    else
      ((Graphic) component1).color = new Color(1f, 0.97f, 0.63f);
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    UIText component2 = this.AGS_Form.GetChild(15).GetChild(2).GetComponent<UIText>();
    this.tmpString[5].ClearString();
    this.tmpString[5].Append(DataManager.Instance.mStringTable.GetStringByID(7705U));
    this.tmpString[5].IntToFormat((long) recordByKey2.VIPLevel);
    this.tmpString[5].AppendFormat(" {0}");
    component2.text = this.tmpString[5].ToString();
    if ((int) recordByKey2.VIPLevel > (int) vipLevel)
      ((Graphic) component2).color = new Color(0.6f, 0.58f, 0.38f);
    else
      ((Graphic) component2).color = new Color(1f, 0.97f, 0.63f);
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
    UIText component3 = this.AGS_Form.GetChild(14).GetChild(3).GetComponent<UIText>();
    if ((int) recordByKey1.VIPLevel > (int) vipLevel)
      ((Graphic) component3).color = new Color(0.6f, 0.58f, 0.38f);
    else
      ((Graphic) component3).color = new Color(1f, 0.97f, 0.63f);
    UIText component4 = this.AGS_Form.GetChild(15).GetChild(3).GetComponent<UIText>();
    if ((int) recordByKey2.VIPLevel > (int) vipLevel)
      ((Graphic) component4).color = new Color(0.6f, 0.58f, 0.38f);
    else
      ((Graphic) component4).color = new Color(1f, 0.97f, 0.63f);
    Image component5 = this.AGS_Form.GetChild(14).GetChild(1).GetComponent<Image>();
    if ((int) recordByKey1.VIPLevel > (int) vipLevel)
      ((Graphic) component5).color = new Color(0.5f, 0.5f, 0.5f);
    else
      ((Graphic) component5).color = new Color(1f, 1f, 1f);
    Image component6 = this.AGS_Form.GetChild(15).GetChild(1).GetComponent<Image>();
    if ((int) recordByKey2.VIPLevel > (int) vipLevel)
      ((Graphic) component6).color = new Color(0.5f, 0.5f, 0.5f);
    else
      ((Graphic) component6).color = new Color(1f, 1f, 1f);
    Image component7 = this.AGS_Form.GetChild(14).GetChild(4).GetComponent<Image>();
    if ((int) recordByKey1.VIPLevel > (int) vipLevel)
      ((Graphic) component7).color = new Color(0.5f, 0.5f, 0.5f);
    else
      ((Graphic) component7).color = new Color(1f, 1f, 1f);
    Image component8 = this.AGS_Form.GetChild(15).GetChild(4).GetComponent<Image>();
    if ((int) recordByKey2.VIPLevel > (int) vipLevel)
      ((Graphic) component8).color = new Color(0.5f, 0.5f, 0.5f);
    else
      ((Graphic) component8).color = new Color(1f, 1f, 1f);
    UIText component9 = this.AGS_Form.GetChild(16).GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((int) recordByKey1.VIPLevel > (int) vipLevel)
      ((Graphic) component9).color = new Color(0.7f, 0.7f, 0.7f);
    else
      ((Graphic) component9).color = new Color(1f, 1f, 1f);
    this.CreateVipText(recordByKey1.VIPLevel, this.Ltext);
    component9.text = this.Ltext.ToString();
    component9.SetAllDirty();
    component9.cachedTextGenerator.Invalidate();
    component9.cachedTextGeneratorForLayout.Invalidate();
    float preferredHeight1 = component9.preferredHeight;
    this.AGS_Form.GetChild(16).GetChild(0).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, preferredHeight1);
    UIText component10 = this.AGS_Form.GetChild(16).GetChild(0).GetChild(1).GetComponent<UIText>();
    if ((int) recordByKey2.VIPLevel > (int) vipLevel)
      ((Graphic) component10).color = new Color(0.7f, 0.7f, 0.7f);
    else
      ((Graphic) component10).color = new Color(1f, 1f, 1f);
    this.CreateVipText(recordByKey2.VIPLevel, this.Rtext);
    component10.text = this.Rtext.ToString();
    component10.SetAllDirty();
    component10.cachedTextGenerator.Invalidate();
    component10.cachedTextGeneratorForLayout.Invalidate();
    float preferredHeight2 = component10.preferredHeight;
    this.AGS_Form.GetChild(16).GetChild(0).GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, preferredHeight2);
    this.AGS_Form.GetChild(16).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, preferredHeight2);
    UIText component11 = this.AGS_Form.GetChild(14).GetChild(3).GetComponent<UIText>();
    if ((int) recordByKey1.VIPLevel > (int) vipLevel)
    {
      component11.text = DataManager.Instance.mStringTable.GetStringByID(7707U);
      ((Component) component11).gameObject.SetActive(true);
    }
    else if ((int) recordByKey1.VIPLevel == (int) vipLevel)
    {
      component11.text = DataManager.Instance.mStringTable.GetStringByID(7706U);
      ((Component) component11).gameObject.SetActive(true);
    }
    else
      ((Component) component11).gameObject.SetActive(false);
    UIText component12 = this.AGS_Form.GetChild(15).GetChild(3).GetComponent<UIText>();
    if ((int) recordByKey2.VIPLevel > (int) vipLevel)
    {
      component12.text = DataManager.Instance.mStringTable.GetStringByID(7707U);
      ((Component) component12).gameObject.SetActive(true);
    }
    else if ((int) recordByKey2.VIPLevel == (int) vipLevel)
    {
      component12.text = DataManager.Instance.mStringTable.GetStringByID(7706U);
      ((Component) component12).gameObject.SetActive(true);
    }
    else
      ((Component) component12).gameObject.SetActive(false);
  }

  private int CreateVipText(ushort targetLevel, CString str)
  {
    DataManager instance = DataManager.Instance;
    int x = 0;
    VIP_DataTbl recordByKey1 = instance.VIPLevelTable.GetRecordByKey((ushort) instance.RoleAttr.VIPLevel);
    VIP_DataTbl recordByKey2 = instance.VIPLevelTable.GetRecordByKey(targetLevel);
    CString cstring1 = StringManager.Instance.SpawnString(300);
    CString cstring2 = StringManager.Instance.SpawnString(300);
    string format1 = !GUIManager.Instance.IsArabic ? "{0}. {1}\n" : "{0} . {1}\n";
    string format2 = "<color=#00FFFF>{0}</color>";
    str.ClearString();
    if (recordByKey2.QuickCompleteMin > (byte) 0)
    {
      cstring1.ClearString();
      ++x;
      if (recordByKey1.QuickCompleteMin == (byte) 0)
      {
        cstring2.ClearString();
        cstring2.IntToFormat((long) recordByKey2.QuickCompleteMin);
        cstring2.AppendFormat(instance.mStringTable.GetStringByID(7710U));
        cstring1.StringToFormat(cstring2);
        cstring1.AppendFormat(format2);
      }
      else if ((int) recordByKey2.QuickCompleteMin > (int) recordByKey1.QuickCompleteMin)
      {
        cstring2.ClearString();
        cstring2.IntToFormat((long) recordByKey2.QuickCompleteMin);
        cstring2.AppendFormat(format2);
        cstring1.StringToFormat(cstring2);
        cstring1.AppendFormat(instance.mStringTable.GetStringByID(7710U));
      }
      else
      {
        cstring1.IntToFormat((long) recordByKey2.QuickCompleteMin);
        cstring1.AppendFormat(instance.mStringTable.GetStringByID(7710U));
      }
      str.IntToFormat((long) x);
      str.StringToFormat(cstring1);
      str.AppendFormat(format1);
    }
    if (recordByKey2.moraleBanner > (byte) 0)
    {
      cstring1.ClearString();
      ++x;
      if (recordByKey1.moraleBanner == (byte) 0)
      {
        if (recordByKey2.moraleBanner == byte.MaxValue)
        {
          cstring2.ClearString();
          cstring2.AppendFormat(instance.mStringTable.GetStringByID(7721U));
          cstring1.StringToFormat(cstring2);
          cstring1.AppendFormat(format2);
        }
        else
        {
          cstring2.ClearString();
          cstring2.IntToFormat((long) recordByKey2.moraleBanner);
          cstring2.AppendFormat(instance.mStringTable.GetStringByID(7711U));
          cstring1.StringToFormat(cstring2);
          cstring1.AppendFormat(format2);
        }
      }
      else if (recordByKey2.moraleBanner == byte.MaxValue)
      {
        if (recordByKey1.moraleBanner != byte.MaxValue)
        {
          cstring1.StringToFormat(instance.mStringTable.GetStringByID(7721U));
          cstring1.AppendFormat(format2);
        }
        else
          cstring1.AppendFormat(instance.mStringTable.GetStringByID(7721U));
      }
      else if ((int) recordByKey2.moraleBanner > (int) recordByKey1.moraleBanner)
      {
        cstring2.ClearString();
        cstring2.IntToFormat((long) recordByKey2.moraleBanner);
        cstring2.AppendFormat(format2);
        cstring1.StringToFormat(cstring2);
        cstring1.AppendFormat(instance.mStringTable.GetStringByID(7711U));
      }
      else
      {
        cstring1.IntToFormat((long) recordByKey2.moraleBanner);
        cstring1.AppendFormat(instance.mStringTable.GetStringByID(7711U));
      }
      str.IntToFormat((long) x);
      str.StringToFormat(cstring1);
      str.AppendFormat(format1);
    }
    if (recordByKey2.DailyResetElite > (byte) 0)
    {
      cstring1.ClearString();
      ++x;
      if (recordByKey1.DailyResetElite == (byte) 0)
      {
        if (recordByKey2.DailyResetElite == byte.MaxValue)
        {
          cstring2.ClearString();
          cstring2.AppendFormat(instance.mStringTable.GetStringByID(7722U));
          cstring1.StringToFormat(cstring2);
          cstring1.AppendFormat(format2);
        }
        else
        {
          cstring2.ClearString();
          cstring2.IntToFormat((long) recordByKey2.moraleBanner);
          cstring2.AppendFormat(instance.mStringTable.GetStringByID(7712U));
          cstring1.StringToFormat(cstring2);
          cstring1.AppendFormat(format2);
        }
      }
      else if (recordByKey2.DailyResetElite == byte.MaxValue)
      {
        if (recordByKey1.moraleBanner != byte.MaxValue)
        {
          cstring1.StringToFormat(instance.mStringTable.GetStringByID(7722U));
          cstring1.AppendFormat(format2);
        }
        else
          cstring1.AppendFormat(instance.mStringTable.GetStringByID(7722U));
      }
      else if ((int) recordByKey2.DailyResetElite > (int) recordByKey1.DailyResetElite)
      {
        cstring2.ClearString();
        cstring2.IntToFormat((long) recordByKey2.DailyResetElite);
        cstring2.AppendFormat(format2);
        cstring1.StringToFormat(cstring2);
        cstring1.AppendFormat(instance.mStringTable.GetStringByID(7712U));
      }
      else
      {
        cstring1.IntToFormat((long) recordByKey2.DailyResetElite);
        cstring1.AppendFormat(instance.mStringTable.GetStringByID(7712U));
      }
      str.IntToFormat((long) x);
      str.StringToFormat(cstring1);
      str.AppendFormat(format1);
    }
    if (recordByKey2.AutoDailyMission > (byte) 0)
    {
      cstring1.ClearString();
      ++x;
      if (recordByKey1.AutoDailyMission == (byte) 0)
      {
        cstring1.StringToFormat(instance.mStringTable.GetStringByID(7715U));
        cstring1.AppendFormat(format2);
        str.IntToFormat((long) x);
        str.StringToFormat(cstring1);
        str.AppendFormat(format1);
      }
      else
      {
        str.IntToFormat((long) x);
        str.StringToFormat(instance.mStringTable.GetStringByID(7715U));
        str.AppendFormat(format1);
      }
    }
    if (recordByKey2.AutoDailyAlliMission > (byte) 0)
    {
      cstring1.ClearString();
      ++x;
      if (recordByKey1.AutoDailyAlliMission == (byte) 0)
      {
        cstring1.StringToFormat(instance.mStringTable.GetStringByID(7716U));
        cstring1.AppendFormat(format2);
        str.IntToFormat((long) x);
        str.StringToFormat(cstring1);
        str.AppendFormat(format1);
      }
      else
      {
        str.IntToFormat((long) x);
        str.StringToFormat(instance.mStringTable.GetStringByID(7716U));
        str.AppendFormat(format1);
      }
    }
    if (((int) recordByKey2.UnlockBuySkill & 1) == 1)
    {
      cstring1.ClearString();
      ++x;
      if (((int) recordByKey1.UnlockBuySkill & 1) != 1)
      {
        cstring1.StringToFormat(instance.mStringTable.GetStringByID(7714U));
        cstring1.AppendFormat(format2);
        str.IntToFormat((long) x);
        str.StringToFormat(cstring1);
        str.AppendFormat(format1);
      }
      else
      {
        str.IntToFormat((long) x);
        str.StringToFormat(instance.mStringTable.GetStringByID(7714U));
        str.AppendFormat(format1);
      }
    }
    if (recordByKey2.AutoFightMission > (byte) 0)
    {
      cstring1.ClearString();
      ++x;
      if (recordByKey1.AutoFightMission == (byte) 0)
      {
        cstring1.StringToFormat(instance.mStringTable.GetStringByID(7717U));
        cstring1.AppendFormat(format2);
      }
      else if ((int) recordByKey2.AutoFightMission > (int) recordByKey1.AutoFightMission)
      {
        cstring2.ClearString();
        cstring2.IntToFormat((long) recordByKey2.AutoFightMission);
        cstring2.AppendFormat(format2);
        cstring1.StringToFormat(cstring2);
        cstring1.AppendFormat(instance.mStringTable.GetStringByID(7717U));
      }
      else
      {
        cstring1.IntToFormat((long) recordByKey2.AutoFightMission);
        cstring1.AppendFormat(instance.mStringTable.GetStringByID(7717U));
      }
      str.IntToFormat((long) x);
      str.StringToFormat(cstring1);
      str.AppendFormat(format1);
    }
    if (recordByKey2.VipMission > (byte) 0)
    {
      cstring1.ClearString();
      ++x;
      if (recordByKey1.VipMission == (byte) 0)
      {
        cstring2.ClearString();
        cstring2.IntToFormat((long) recordByKey2.VipMission);
        cstring2.AppendFormat(instance.mStringTable.GetStringByID(7718U));
        cstring1.StringToFormat(cstring2);
        cstring1.AppendFormat(format2);
      }
      else if ((int) recordByKey2.VipMission > (int) recordByKey1.VipMission)
      {
        cstring2.ClearString();
        cstring2.IntToFormat((long) recordByKey2.VipMission);
        cstring2.AppendFormat(format2);
        cstring1.StringToFormat(cstring2);
        cstring1.AppendFormat(instance.mStringTable.GetStringByID(7718U));
      }
      else
      {
        cstring1.IntToFormat((long) recordByKey2.VipMission);
        cstring1.AppendFormat(instance.mStringTable.GetStringByID(7718U));
      }
      str.IntToFormat((long) x);
      str.StringToFormat(cstring1);
      str.AppendFormat(format1);
    }
    if (recordByKey2.DailyMission > (byte) 0)
    {
      cstring1.ClearString();
      ++x;
      if (recordByKey1.DailyMission == (byte) 0)
      {
        cstring2.ClearString();
        cstring2.IntToFormat((long) recordByKey2.DailyMission);
        cstring2.AppendFormat(instance.mStringTable.GetStringByID(7719U));
        cstring1.StringToFormat(cstring2);
        cstring1.AppendFormat(format2);
      }
      else if ((int) recordByKey2.DailyMission > (int) recordByKey1.DailyMission)
      {
        cstring2.ClearString();
        cstring2.IntToFormat((long) recordByKey2.DailyMission);
        cstring2.AppendFormat(format2);
        cstring1.StringToFormat(cstring2);
        cstring1.AppendFormat(instance.mStringTable.GetStringByID(7719U));
      }
      else
      {
        cstring1.IntToFormat((long) recordByKey2.DailyMission);
        cstring1.AppendFormat(instance.mStringTable.GetStringByID(7719U));
      }
      str.IntToFormat((long) x);
      str.StringToFormat(cstring1);
      str.AppendFormat(format1);
    }
    if (recordByKey2.AlliMission > (byte) 0)
    {
      cstring1.ClearString();
      ++x;
      if (recordByKey1.AlliMission == (byte) 0)
      {
        cstring2.ClearString();
        cstring2.IntToFormat((long) recordByKey2.AlliMission);
        cstring2.AppendFormat(instance.mStringTable.GetStringByID(7719U));
        cstring1.StringToFormat(cstring2);
        cstring1.AppendFormat(format2);
      }
      else if ((int) recordByKey2.AlliMission > (int) recordByKey1.AlliMission)
      {
        cstring2.ClearString();
        cstring2.IntToFormat((long) recordByKey2.AlliMission);
        cstring2.AppendFormat(format2);
        cstring1.StringToFormat(cstring2);
        cstring1.AppendFormat(instance.mStringTable.GetStringByID(7720U));
      }
      else
      {
        cstring1.IntToFormat((long) recordByKey2.AlliMission);
        cstring1.AppendFormat(instance.mStringTable.GetStringByID(7720U));
      }
      str.IntToFormat((long) x);
      str.StringToFormat(cstring1);
      str.AppendFormat(format1);
    }
    for (int index1 = 0; index1 < 15; ++index1)
    {
      int index2 = index1 * 2;
      if (recordByKey2.Effects[index2] > (ushort) 0)
      {
        Effect recordByKey3 = DataManager.Instance.EffectData.GetRecordByKey(recordByKey2.Effects[index2]);
        cstring1.ClearString();
        ++x;
        int effect = (int) recordByKey2.Effects[index2 + 1];
        if (recordByKey3.ValueID == (ushort) 4378)
          effect /= 100;
        if (recordByKey1.Effects[index2 + 1] == (ushort) 0)
        {
          cstring2.ClearString();
          cstring2.Append(instance.mStringTable.GetStringByID((uint) recordByKey3.String_infoID));
          cstring2.IntToFormat((long) effect);
          cstring2.AppendFormat("{0}");
          cstring2.Append(instance.mStringTable.GetStringByID((uint) recordByKey3.ValueID));
          cstring1.StringToFormat(cstring2);
          cstring1.AppendFormat(format2);
        }
        else if ((int) recordByKey2.Effects[index2 + 1] > (int) recordByKey1.Effects[index2 + 1])
        {
          cstring2.ClearString();
          cstring2.IntToFormat((long) effect);
          cstring2.AppendFormat(format2);
          cstring1.Append(instance.mStringTable.GetStringByID((uint) recordByKey3.String_infoID));
          cstring1.Append(cstring2);
          cstring1.Append(instance.mStringTable.GetStringByID((uint) recordByKey3.ValueID));
        }
        else
        {
          cstring1.Append(instance.mStringTable.GetStringByID((uint) recordByKey3.String_infoID));
          cstring1.IntToFormat((long) effect);
          cstring1.AppendFormat("{0}");
          cstring1.Append(instance.mStringTable.GetStringByID((uint) recordByKey3.ValueID));
        }
        str.IntToFormat((long) x);
        str.StringToFormat(cstring1);
        str.AppendFormat(format1);
      }
    }
    StringManager.Instance.DeSpawnString(cstring2);
    StringManager.Instance.DeSpawnString(cstring1);
    return x;
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        this.door.CloseMenu();
        break;
      case 1:
        switch (sender.m_BtnID2)
        {
          case 0:
            GUIManager.Instance.OpenItemKindFilterUI((ushort) 13, (byte) 1, (byte) 0);
            return;
          case 1:
            GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7705U), DataManager.Instance.mStringTable.GetStringByID(7708U), bInfo: true, BackExit: true);
            return;
          default:
            return;
        }
      case 2:
        switch (sender.m_BtnID2)
        {
          case 0:
            if (this.targetLevel <= (ushort) 1)
              return;
            this.SetShowVip((ushort) ((uint) this.targetLevel - 1U));
            return;
          case 1:
            this.SetShowVip((ushort) ((uint) this.targetLevel + 1U));
            return;
          default:
            return;
        }
    }
  }

  public void Update()
  {
    this.TmpTime += Time.smoothDeltaTime * 40f;
    if ((double) this.TmpTime >= 40.0)
      this.TmpTime = 0.0f;
    float num = (double) this.TmpTime <= 20.0 ? this.TmpTime : 40f - this.TmpTime;
    if ((double) num < 0.0)
      num = 0.0f;
    this.Vec3Instance.Set(this.MoveTime1 - num, this.LBtn.localPosition.y, this.LBtn.localPosition.z);
    this.LBtn.localPosition = this.Vec3Instance;
    this.Vec3Instance.Set(this.MoveTime2 + num, this.RBtn.localPosition.y, this.RBtn.localPosition.z);
    this.RBtn.localPosition = this.Vec3Instance;
    this.GetPointTime += Time.smoothDeltaTime;
    if ((double) this.GetPointTime >= 2.0)
      this.GetPointTime = 0.0f;
    ((Graphic) this.Img_GetPoint).color = new Color(1f, 1f, 1f, (double) this.GetPointTime <= 1.0 ? this.GetPointTime : 2f - this.GetPointTime);
  }

  public override void UpdateUI(int arg1, int arg2) => this.UpdateInfo();

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.UpdateInfo();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  private enum e_AGS_UI_VIP_Editor
  {
    CloseDeco,
    bgPanel,
    label1,
    label2,
    BarBG,
    GetPoint,
    VipStar,
    VIPLevel,
    VipInfo,
    title,
    TitleStar,
    TitleText,
    flag1,
    flag2,
    LeftPanel,
    RightPanel,
    ScrollPanel,
    LBtn,
    RBtn,
  }

  private enum e_AGS_BarBG
  {
    Bar,
    BarText,
  }

  private enum e_AGS_GetPoint
  {
    OverImage,
    Text,
  }

  private enum e_AGS_LeftPanel
  {
    bgLight,
    flagTitle,
    flagLevel,
    flagText,
    flagbar,
  }

  private enum e_AGS_RightPanel
  {
    bgLight,
    flagTitle,
    flagLevel,
    flagText,
    flagbar,
  }

  private enum e_AGS_ScrollPanel
  {
    Panel,
  }

  private enum e_AGS_Panel
  {
    LText,
    RText,
  }
}
