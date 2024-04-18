// Decompiled with JetBrains decompiler
// Type: UISkillInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UISkillInfo : IMotionUpdate, UILoadImageHander
{
  public RectTransform m_RectTransform;
  private RectTransform Divider1;
  private RectTransform Divider2;
  private RectTransform LegionTrans;
  private RectTransform CanvasRect;
  private RectTransform[] BadgeTransform = new RectTransform[5];
  private Image SkillIcon;
  private UIText Name;
  private UIText Kind;
  private UIText Content;
  private UIText Prop;
  private UIText RequireMsg;
  private UIText[] BadgeText = new UIText[5];
  public UIButtonHint m_ButtonHint;
  private CString[] m_tmpStr = new CString[6];
  private CString m_tmpStrlong;
  private readonly byte[] LegionRankMagnifation = new byte[5]
  {
    (byte) 1,
    (byte) 2,
    (byte) 4,
    (byte) 8,
    (byte) 20
  };
  private byte RequireIdx;
  private ushort HeroAttrValA;
  private ushort HeroAttrValB;
  private int DisplayLv;
  private EasingEffect BadgeMotion;
  private int BadgeIndex = -1;
  private CanvasGroup Canvasgroup;
  private float Timer;
  private byte HeroEnhance;
  private byte SkillIndex;
  private int ValueX;
  private int ValueY;

  public void Load()
  {
    UnityEngine.Object original = GUIManager.Instance.m_ManagerAssetBundle.Load("UI_SkillInfo");
    if (original == (UnityEngine.Object) null)
      return;
    GUIManager instance = GUIManager.Instance;
    Font ttfFont = instance.GetTTFFont();
    GameObject gameObject = (GameObject) UnityEngine.Object.Instantiate(original);
    gameObject.transform.SetParent((Transform) GUIManager.Instance.m_WindowTopLayer, false);
    gameObject.SetActive(false);
    this.m_RectTransform = gameObject.transform as RectTransform;
    this.Canvasgroup = ((Component) this.m_RectTransform).GetComponent<CanvasGroup>();
    ((Component) this.m_RectTransform).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    ((Transform) this.m_RectTransform).GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    ((Transform) this.m_RectTransform).GetChild(4).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    ((Transform) this.m_RectTransform).GetChild(5).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.LegionTrans = ((Transform) this.m_RectTransform).GetChild(7) as RectTransform;
    for (int index = 0; index < 5; ++index)
    {
      ((Transform) this.m_RectTransform).GetChild(7).GetChild(index).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
      ((Transform) this.m_RectTransform).GetChild(7).GetChild(index).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
      this.BadgeText[index] = ((Transform) this.m_RectTransform).GetChild(7).GetChild(index).GetChild(1).GetComponent<UIText>();
      this.BadgeText[index].font = ttfFont;
      this.BadgeTransform[index] = ((Transform) this.m_RectTransform).GetChild(7).GetChild(index) as RectTransform;
    }
    this.Name = ((Transform) this.m_RectTransform).GetChild(1).GetComponent<UIText>();
    this.Name.font = ttfFont;
    this.Kind = ((Transform) this.m_RectTransform).GetChild(2).GetComponent<UIText>();
    this.Kind.font = ttfFont;
    this.Content = ((Transform) this.m_RectTransform).GetChild(3).GetComponent<UIText>();
    this.Content.font = ttfFont;
    this.Prop = ((Transform) this.m_RectTransform).GetChild(6).GetComponent<UIText>();
    this.Prop.font = ttfFont;
    this.SkillIcon = ((Transform) this.m_RectTransform).GetChild(0).GetComponent<Image>();
    this.Divider1 = ((Transform) this.m_RectTransform).GetChild(4) as RectTransform;
    this.Divider2 = ((Transform) this.m_RectTransform).GetChild(5) as RectTransform;
    this.RequireMsg = ((Transform) this.m_RectTransform).GetChild(8).GetComponent<UIText>();
    this.RequireMsg.font = ttfFont;
    for (int index = 0; index < this.m_tmpStr.Length; ++index)
      this.m_tmpStr[index] = StringManager.Instance.SpawnString(400);
    this.m_tmpStrlong = StringManager.Instance.SpawnString(800);
    this.BadgeMotion = new EasingEffect();
    this.BadgeMotion.Motion = (IMotionUpdate) this;
    this.CanvasRect = ((Component) instance.m_UICanvas).GetComponent<RectTransform>();
    ((Component) this.Divider2).gameObject.SetActive(false);
  }

  public unsafe void Show(
    UIButtonHint hint,
    uint HeroID,
    byte SkillIndex,
    ushort HeroAttrValA,
    ushort HeroAttrValB,
    bool bPreview = false)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    byte index1 = SkillIndex;
    if (((Component) this.m_RectTransform).gameObject.activeSelf)
      this.Hide(this.m_ButtonHint);
    CurHeroData previewHeroData;
    if (bPreview)
    {
      previewHeroData = instance1.PreviewHeroData;
    }
    else
    {
      if (!instance1.curHeroData.ContainsKey(HeroID))
        return;
      previewHeroData = instance1.curHeroData[HeroID];
    }
    Hero recordByKey1 = instance1.HeroTable.GetRecordByKey(previewHeroData.ID);
    if (recordByKey1.AttackPower == null || previewHeroData.SkillLV == null)
      return;
    Skill recordByKey2;
    if (SkillIndex < (byte) 4)
    {
      recordByKey2 = instance1.SkillTable.GetRecordByKey(recordByKey1.AttackPower[(int) SkillIndex + 1]);
    }
    else
    {
      // ISSUE: untyped stack allocation
      ushort* numPtr = (ushort*) __untypedstackalloc((int) checked (4U * 2U));
      *numPtr = recordByKey1.GroupSkill1;
      numPtr[1] = recordByKey1.GroupSkill2;
      numPtr[2] = recordByKey1.GroupSkill3;
      numPtr[3] = recordByKey1.GroupSkill4;
      recordByKey2 = instance1.SkillTable.GetRecordByKey(numPtr[(int) SkillIndex - 4]);
      index1 -= (byte) 4;
    }
    this.HeroEnhance = previewHeroData.Star;
    this.SkillIndex = SkillIndex;
    this.HeroAttrValA = HeroAttrValA;
    this.HeroAttrValB = HeroAttrValB;
    this.m_tmpStr[5].ClearString();
    this.m_tmpStr[5].Append('s');
    this.m_tmpStr[5].IntToFormat((long) recordByKey2.SkillIcon, 5);
    this.m_tmpStr[5].AppendFormat("{0}");
    this.SkillIcon.sprite = instance2.LoadSkillSprite(this.m_tmpStr[5]);
    ((MaskableGraphic) this.SkillIcon).material = instance2.GetSkillMaterial();
    this.Name.text = instance1.mStringTable.GetStringByID((uint) recordByKey2.SkillName);
    this.m_tmpStrlong.ClearString();
    if (recordByKey2.Describe > (ushort) 0)
      this.m_tmpStrlong.Append(instance1.mStringTable.GetStringByID((uint) recordByKey2.Describe));
    if (recordByKey2.SkillType >= (byte) 10 && recordByKey2.SkillType <= (byte) 12)
      this.ShowLegionHint(ref recordByKey2);
    else if (previewHeroData.SkillLV.Length > (int) SkillIndex)
    {
      this.ShowHerohint(ref recordByKey2, previewHeroData.SkillLV[(int) SkillIndex]);
    }
    else
    {
      this.Hide(this.m_ButtonHint);
      return;
    }
    if (previewHeroData.SkillLV[(int) index1] == (byte) 0)
    {
      uint ID;
      switch (SkillIndex)
      {
        case 1:
        case 5:
          ID = 482U;
          break;
        case 2:
        case 6:
          ID = 483U;
          break;
        default:
          ID = 484U;
          break;
      }
      this.m_tmpStr[5].ClearString();
      this.m_tmpStr[5].StringToFormat(instance1.mStringTable.GetStringByID(ID));
      this.m_tmpStr[5].AppendFormat("<color=#ff846dff>{0}</color>");
      this.RequireMsg.text = this.m_tmpStr[5].ToString();
      this.RequireMsg.SetAllDirty();
      this.RequireMsg.cachedTextGenerator.Invalidate();
      this.RequireIdx = (byte) 1;
    }
    else if (SkillIndex >= (byte) 4)
    {
      this.m_tmpStr[5].ClearString();
      this.m_tmpStr[5].Append("<color=#8b765fff>");
      this.m_tmpStr[5].Append(instance1.mStringTable.GetStringByID((uint) (10134 - (int) recordByKey2.SkillType % 10)));
      this.m_tmpStr[5].Append("</color>");
      this.RequireMsg.text = this.m_tmpStr[5].ToString();
      this.RequireMsg.SetAllDirty();
      this.RequireMsg.cachedTextGenerator.Invalidate();
      this.RequireIdx = (byte) 1;
    }
    Vector2 anchoredPosition = ((Graphic) this.Content).rectTransform.anchoredPosition;
    Vector2 sizeDelta = ((Graphic) this.Content).rectTransform.sizeDelta with
    {
      y = this.Content.preferredHeight
    };
    ((Graphic) this.Content).rectTransform.sizeDelta = sizeDelta;
    anchoredPosition.x = this.Divider1.anchoredPosition.x;
    anchoredPosition.y += (float) (-(double) this.Content.preferredHeight - 12.0);
    this.Divider1.anchoredPosition = anchoredPosition;
    if (this.Prop.text != string.Empty)
    {
      sizeDelta = ((Graphic) this.Prop).rectTransform.sizeDelta with
      {
        y = this.Prop.preferredHeight
      };
      ((Graphic) this.Prop).rectTransform.sizeDelta = sizeDelta;
      anchoredPosition.y += -17f;
      anchoredPosition.x = ((Graphic) this.Prop).rectTransform.anchoredPosition.x;
      ((Graphic) this.Prop).rectTransform.anchoredPosition = anchoredPosition;
      anchoredPosition.y += (float) (-(double) this.Prop.preferredHeight - 3.0);
    }
    else
    {
      ((Component) this.Divider1).gameObject.SetActive(false);
      anchoredPosition.y += -3f;
    }
    float num = 0.0f;
    if (((Component) this.LegionTrans).gameObject.activeSelf)
    {
      num = 72f;
      bool isArabic = instance2.IsArabic;
      for (int index2 = 0; index2 < 5; ++index2)
      {
        anchoredPosition.x = this.BadgeTransform[index2].anchoredPosition.x;
        this.BadgeTransform[index2].anchoredPosition = anchoredPosition;
        this.m_tmpStr[index2].ClearString();
        if (recordByKey2.HurtKind == (byte) 1)
        {
          this.m_tmpStr[index2].FloatToFormat((float) ((int) recordByKey2.HurtIncreaseValue * (int) this.LegionRankMagnifation[index2]));
          this.m_tmpStr[index2].AppendFormat("{0}");
        }
        else
        {
          this.m_tmpStr[index2].FloatToFormat((float) recordByKey2.HurtValue + (float) recordByKey2.HurtIncreaseValue / 1000f * (float) this.LegionRankMagnifation[index2]);
          if (GUIManager.Instance.IsArabic)
            this.m_tmpStr[index2].AppendFormat("%{0}");
          else
            this.m_tmpStr[index2].AppendFormat("{0}%");
        }
        this.BadgeText[index2].text = this.m_tmpStr[index2].ToString();
        this.BadgeText[index2].SetAllDirty();
        this.BadgeText[index2].cachedTextGenerator.Invalidate();
      }
    }
    if (this.RequireIdx > (byte) 0)
    {
      ((Component) this.Divider2).gameObject.SetActive(true);
      anchoredPosition.x = this.Divider2.anchoredPosition.x;
      anchoredPosition.y += -3f - num;
      this.Divider2.anchoredPosition = anchoredPosition;
      anchoredPosition.x = ((Graphic) this.RequireMsg).rectTransform.anchoredPosition.x;
      anchoredPosition.y += -17f;
      ((Graphic) this.RequireMsg).rectTransform.anchoredPosition = anchoredPosition;
      sizeDelta = ((Graphic) this.RequireMsg).rectTransform.sizeDelta with
      {
        y = this.RequireMsg.preferredHeight
      };
      ((Graphic) this.RequireMsg).rectTransform.sizeDelta = sizeDelta;
      sizeDelta.y = (float) ((double) sizeDelta.y + (double) anchoredPosition.y * -1.0 + 23.0);
      sizeDelta.x = this.m_RectTransform.sizeDelta.x;
      this.m_RectTransform.sizeDelta = sizeDelta;
    }
    else
    {
      sizeDelta = this.m_RectTransform.sizeDelta with
      {
        y = (float) ((double) anchoredPosition.y * -1.0 + 14.0) + num
      };
      this.m_RectTransform.sizeDelta = sizeDelta;
    }
    Vector3 anchoredPosition3D = this.m_RectTransform.anchoredPosition3D;
    if ((double) this.m_RectTransform.sizeDelta.y + 75.0 < (double) this.CanvasRect.sizeDelta.y)
      anchoredPosition3D.Set(-230f, -75f, 0.0f);
    else if ((double) this.CanvasRect.sizeDelta.y >= (double) this.m_RectTransform.sizeDelta.y)
    {
      anchoredPosition3D.Set(-230f, this.m_RectTransform.sizeDelta.y - this.CanvasRect.sizeDelta.y, 0.0f);
    }
    else
    {
      --this.Prop.fontSize;
      --this.Content.fontSize;
      this.Show(hint, HeroID, SkillIndex, HeroAttrValA, HeroAttrValB, bPreview);
      return;
    }
    ((Component) this.m_RectTransform).gameObject.SetActive(true);
    this.m_RectTransform.anchoredPosition3D = anchoredPosition3D;
    this.m_ButtonHint = hint;
    this.Canvasgroup.alpha = 1f;
  }

  private void ShowLegionHint(ref Skill skill)
  {
    DataManager instance = DataManager.Instance;
    ((Component) this.LegionTrans).gameObject.SetActive(true);
    this.Kind.text = instance.mStringTable.GetStringByID((uint) (485 + (int) skill.SkillType % 10));
    this.Prop.text = instance.mStringTable.GetStringByID(488U);
    ((Transform) this.BadgeTransform[(int) this.HeroEnhance - 1]).GetChild(0).gameObject.SetActive(true);
    if (this.BadgeIndex < 0)
      this.BadgeIndex = (int) MotionEffect.SetStack((MotionEffect) this.BadgeMotion);
    this.GetLegionHintStr(this.HeroEnhance, ref skill, ref this.m_tmpStrlong, (byte) 0);
    this.Content.text = this.m_tmpStrlong.ToString();
    this.Content.SetAllDirty();
    this.Content.cachedTextGenerator.Invalidate();
    this.Content.cachedTextGeneratorForLayout.Invalidate();
  }

  public void GetLegionHintStr(
    byte heroEnhance,
    ref Skill skill,
    ref CString Content,
    byte RankStr = 0)
  {
    CString textS = StringManager.Instance.StaticString1024();
    CString cstring = StringManager.Instance.StaticString1024();
    textS.Append(Content);
    float mValue = (float) skill.HurtValue + (float) ((int) this.LegionRankMagnifation[(int) heroEnhance - 1] * (int) skill.HurtIncreaseValue) / 1000f;
    if (skill.HurtKind == (byte) 1)
    {
      GameConstants.GetEffectValue(Content, skill.HurtAddition, 0U, (byte) 7, 0.0f);
      Content.IntToFormat((long) ((int) this.LegionRankMagnifation[(int) heroEnhance - 1] * (int) skill.HurtIncreaseValue), bNumber: true);
      Content.AppendFormat("{0}");
    }
    else if (skill.SkillType == (byte) 10)
      GameConstants.GetEffectValue(Content, skill.HurtAddition, (uint) mValue, (byte) 1, 0.0f);
    else
      GameConstants.GetEffectValue(Content, skill.HurtAddition, 0U, (byte) 6, mValue * 100f);
    if (RankStr > (byte) 0)
    {
      cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(15U));
      cstring.IntToFormat((long) RankStr);
      cstring.StringToFormat(Content);
      if (skill.SkillType == (byte) 10)
        cstring.AppendFormat("<color=#ffff00ff>{0}{1} : {2}</color>");
      else
        cstring.AppendFormat("<color=#33eb67ff>{0}{1} : {2}</color>");
    }
    else
    {
      cstring.StringToFormat(Content);
      if (skill.SkillType == (byte) 10)
        cstring.AppendFormat("<color=#ffff00ff>{0}</color>");
      else
        cstring.AppendFormat("<color=#33eb67ff>{0}</color>");
    }
    cstring.Insert(0, textS);
    Content.ClearString();
    Content.Append(cstring);
  }

  private void ShowHerohint(ref Skill skill, byte SkillLv)
  {
    DataManager instance = DataManager.Instance;
    ((Component) this.LegionTrans).gameObject.SetActive(false);
    uint ID;
    switch (skill.SkillType)
    {
      case 1:
        ID = 476U;
        break;
      case 2:
        ID = 477U;
        break;
      case 3:
      case 4:
      case 5:
        ID = 478U;
        break;
      default:
        ID = 479U;
        break;
    }
    this.Kind.text = instance.mStringTable.GetStringByID(ID);
    this.DisplayLv = 0;
    this.m_tmpStr[1].ClearString();
    this.DisplayLv = this.SkillIndex == (byte) 0 || this.SkillIndex == (byte) 1 ? (int) SkillLv : (this.SkillIndex != (byte) 2 ? (int) SkillLv + 40 : (int) SkillLv + 20);
    if (this.DisplayLv == 60)
      this.m_tmpStr[1].Append(instance.mStringTable.GetStringByID(481U));
    else if (SkillLv >= (byte) 1)
      this.m_tmpStr[1].Append(instance.mStringTable.GetStringByID(480U));
    this.m_tmpStrlong.Append("\n");
    string stringById = instance.mStringTable.GetStringByID((uint) skill.ValueInfo);
    if (stringById == null)
      return;
    byte num = Math.Max((byte) 1, SkillLv);
    this.ValueX = (int) skill.HurtAddition * (int) this.HeroAttrValA / 1000 + (int) skill.HurtValue + (int) num * (int) skill.HurtIncreaseValue / 1000;
    this.ValueY = (int) skill.StateAddition * (int) this.HeroAttrValB / 1000 + (int) skill.StateValue + (int) num * (int) skill.StateIncreaseValue / 1000;
    this.m_tmpStr[0].ClearString();
    this.m_tmpStr[0].IntToFormat((long) (this.DisplayLv - 1));
    this.m_tmpStr[0].AppendFormat(instance.mStringTable.GetStringByID(489U));
    this.PraseString(this.m_tmpStrlong, stringById);
    if (SkillLv >= (byte) 1)
    {
      ++this.DisplayLv;
      ++SkillLv;
      this.m_tmpStr[1].Append("\n");
      if (this.DisplayLv <= 60)
      {
        this.m_tmpStr[0].ClearString();
        this.ValueX = (int) skill.HurtAddition * (int) this.HeroAttrValA / 1000 + (int) skill.HurtValue + (int) SkillLv * (int) skill.HurtIncreaseValue / 1000;
        this.ValueY = (int) skill.StateAddition * (int) this.HeroAttrValB / 1000 + (int) skill.StateValue + (int) SkillLv * (int) skill.StateIncreaseValue / 1000;
        this.PraseString(this.m_tmpStr[1], stringById);
      }
      this.Prop.text = this.m_tmpStr[1].ToString();
      this.Prop.SetAllDirty();
      this.Prop.cachedTextGeneratorForLayout.Invalidate();
    }
    this.Content.text = this.m_tmpStrlong.ToString();
    this.Content.SetAllDirty();
    this.Content.cachedTextGenerator.Invalidate();
    this.Content.cachedTextGeneratorForLayout.Invalidate();
  }

  public void PraseString(CString NewStr, string str)
  {
    int index = 0;
    while (index < str.Length)
    {
      char ch = str[index++];
      if (ch == '%')
      {
        switch (str[index])
        {
          case 'b':
            NewStr.Append(this.GetCharString(str[index++]));
            continue;
          case 'x':
          case 'y':
            NewStr.IntToFormat((long) this.GetCharVal(str[index++]), bNumber: true);
            NewStr.AppendFormat("{0}");
            continue;
          default:
            NewStr.Append(ch);
            continue;
        }
      }
      else
        NewStr.Append(ch);
    }
  }

  public int GetCharVal(char ch)
  {
    if (ch == 'x')
      return this.ValueX;
    return ch == 'y' ? this.ValueY : 0;
  }

  public string GetCharString(char ch)
  {
    if (ch != 'b')
      return this.m_tmpStr[0].ToString();
    int x = this.DisplayLv;
    if (this.SkillIndex == (byte) 0 || this.SkillIndex == (byte) 1)
    {
      if (x == 0)
        x = 1;
    }
    else if (this.SkillIndex == (byte) 2)
    {
      if (x == 20)
        x = 21;
    }
    else if (x == 40)
      x = 41;
    this.m_tmpStr[2].ClearString();
    this.m_tmpStr[2].IntToFormat((long) x);
    this.m_tmpStr[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(489U));
    return this.m_tmpStr[2].ToString();
  }

  public void Hide(UIButtonHint hint)
  {
    ((Component) this.m_RectTransform).gameObject.SetActive(false);
    ((Component) this.Divider1).gameObject.SetActive(true);
    ((Component) this.Divider2).gameObject.SetActive(false);
    this.RequireIdx = (byte) 0;
    this.SkillIndex = (byte) 0;
    this.m_ButtonHint = (UIButtonHint) null;
    this.Prop.text = string.Empty;
    this.RequireMsg.text = string.Empty;
    if (this.HeroEnhance > (byte) 0 && this.BadgeTransform.Length > (int) this.HeroEnhance)
    {
      ((Transform) this.BadgeTransform[(int) this.HeroEnhance - 1]).GetChild(0).gameObject.SetActive(false);
      this.HeroEnhance = (byte) 0;
    }
    this.Timer = 0.0f;
    this.Content.fontSize = 18;
    this.Prop.fontSize = 18;
  }

  public void UnLoad()
  {
    if ((UnityEngine.Object) this.m_RectTransform == (UnityEngine.Object) null)
      return;
    for (int index = 0; index < this.m_tmpStr.Length; ++index)
      StringManager.Instance.DeSpawnString(this.m_tmpStr[index]);
    StringManager.Instance.DeSpawnString(this.m_tmpStrlong);
    UnityEngine.Object.Destroy((UnityEngine.Object) ((Component) this.m_RectTransform).gameObject);
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (UnityEngine.Object) menu)
      return;
    img.sprite = menu.LoadSprite(ImageName);
    if ((bool) (UnityEngine.Object) img.sprite)
    {
      ((MaskableGraphic) img).material = menu.LoadMaterial();
    }
    else
    {
      img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
      ((MaskableGraphic) img).material = GUIManager.Instance.GetFrameMaterial();
    }
  }

  public bool UpdateRun(float delta)
  {
    if (!((Component) this.m_RectTransform).gameObject.activeSelf)
    {
      if (this.HeroEnhance > (byte) 0 && ((Transform) this.BadgeTransform[(int) this.HeroEnhance - 1]).GetChild(0).gameObject.activeSelf)
        ((Transform) this.BadgeTransform[(int) this.HeroEnhance - 1]).GetChild(0).gameObject.SetActive(false);
      this.BadgeIndex = -1;
      return false;
    }
    if (this.HeroEnhance > (byte) 0 && this.BadgeTransform.Length >= (int) this.HeroEnhance && (double) this.Timer > 0.30000001192092896)
    {
      ((Transform) this.BadgeTransform[(int) this.HeroEnhance - 1]).GetChild(0).gameObject.SetActive(!((Transform) this.BadgeTransform[(int) this.HeroEnhance - 1]).GetChild(0).gameObject.activeSelf);
      this.Timer = 0.0f;
    }
    this.Timer += delta;
    return true;
  }

  public void TextRefresh()
  {
    if ((UnityEngine.Object) this.m_RectTransform == (UnityEngine.Object) null || !((Component) this.m_RectTransform).gameObject.activeSelf)
      return;
    ((Behaviour) this.Name).enabled = false;
    ((Behaviour) this.Name).enabled = true;
    ((Behaviour) this.Kind).enabled = false;
    ((Behaviour) this.Kind).enabled = true;
    ((Behaviour) this.Content).enabled = false;
    ((Behaviour) this.Content).enabled = true;
    ((Behaviour) this.Prop).enabled = false;
    ((Behaviour) this.Prop).enabled = true;
    ((Behaviour) this.RequireMsg).enabled = false;
    ((Behaviour) this.RequireMsg).enabled = true;
    for (int index = 0; index < this.BadgeText.Length; ++index)
    {
      ((Behaviour) this.BadgeText[index]).enabled = false;
      ((Behaviour) this.BadgeText[index]).enabled = true;
    }
  }

  private enum UIControl
  {
    Icon,
    Name,
    Kind,
    Content,
    DividerImg1,
    DividerImg2,
    Prop,
    Legion,
    Require,
  }
}
