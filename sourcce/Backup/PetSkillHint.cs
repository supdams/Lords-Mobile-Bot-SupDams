// Decompiled with JetBrains decompiler
// Type: PetSkillHint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class PetSkillHint : HintStyleBase
{
  private float HintWidth;
  private ushort SkillID;
  private ushort PetID;
  private byte Level;
  private UIText NameText;
  private UIText KindText;
  private UIText CrystalText;
  private UIText StateText;
  private UIText StateContText;
  private GameObject CrystalObj;
  private GameObject LineObj;
  private GameObject StateObj;
  private GameObject OthersObj;
  private RectTransform LineRect;
  private RectTransform CanvasRect;
  private RectTransform MaxBackRect;
  private PetSkillHint._Content[] Contents;
  private PetSkillHint._Note Note;
  private Image SkillImg;
  private float DefHeight;
  private PetSkillHint.eKind Kind;
  private Sprite[] BackSprite = new Sprite[4];
  private float[] DefHeights = new float[3]
  {
    69f,
    96.7f,
    127.27f
  };

  public PetSkillHint(RectTransform transform)
  {
    GUIManager instance = GUIManager.Instance;
    this.rectTrans = transform;
    Font ttfFont = instance.GetTTFFont();
    UILoadImageHander itemInfo = (UILoadImageHander) instance.m_ItemInfo;
    this.StateObj = ((Transform) this.rectTrans).GetChild(0).gameObject;
    this.StateText = ((Transform) this.rectTrans).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.StateText.font = ttfFont;
    this.StateContText = ((Transform) this.rectTrans).GetChild(0).GetChild(1).GetComponent<UIText>();
    this.StateContText.font = ttfFont;
    this.OthersObj = ((Transform) this.rectTrans).GetChild(1).gameObject;
    this.SkillImg = ((Transform) this.rectTrans).GetChild(1).GetChild(0).GetComponent<Image>();
    ((Transform) this.rectTrans).GetChild(1).GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = itemInfo;
    this.NameText = ((Transform) this.rectTrans).GetChild(1).GetChild(1).GetComponent<UIText>();
    this.NameText.font = ttfFont;
    this.KindText = ((Transform) this.rectTrans).GetChild(1).GetChild(2).GetComponent<UIText>();
    this.KindText.font = ttfFont;
    ((Transform) this.rectTrans).GetChild(1).GetChild(3).GetChild(0).GetComponent<CustomImage>().hander = itemInfo;
    this.CrystalText = ((Transform) this.rectTrans).GetChild(1).GetChild(3).GetChild(1).GetComponent<UIText>();
    this.CrystalText.font = ttfFont;
    this.CrystalText.text = DataManager.Instance.mStringTable.GetStringByID(10081U);
    this.CrystalObj = ((Transform) this.rectTrans).GetChild(1).GetChild(3).gameObject;
    this.Contents = new PetSkillHint._Content[2];
    this.Contents[0] = new PetSkillHint._Content(((Transform) this.rectTrans).GetChild(1).GetChild(4), ttfFont);
    this.Contents[1] = new PetSkillHint._Content(((Transform) this.rectTrans).GetChild(1).GetChild(7), ttfFont);
    ((Transform) this.rectTrans).GetChild(1).GetChild(5).GetComponent<CustomImage>().hander = itemInfo;
    this.LineRect = ((Transform) this.rectTrans).GetChild(1).GetChild(5).GetComponent<RectTransform>();
    this.LineObj = ((Component) this.LineRect).gameObject;
    ((Transform) this.rectTrans).GetChild(1).GetChild(6).GetComponent<CustomImage>().hander = itemInfo;
    this.MaxBackRect = ((Transform) this.rectTrans).GetChild(1).GetChild(6).GetComponent<RectTransform>();
    this.BackSprite[0] = instance.LoadFrameSprite("UI_main_hero_box_01");
    this.BackSprite[1] = instance.LoadFrameSprite("UI_main_hero_box_01_b");
    this.BackSprite[2] = instance.LoadFrameSprite("UI_main_hero_box_01_c");
    this.BackSprite[3] = instance.LoadFrameSprite("UI_main_box_012");
    this.HintFrameSprite = this.BackSprite[0];
    this.HintFrameMat = instance.GetFrameMaterial();
    this.CanvasRect = ((Component) instance.m_UICanvas).GetComponent<RectTransform>();
    this.HintWidth = this.rectTrans.sizeDelta.x;
    this.Note = new PetSkillHint._Note(((Transform) this.rectTrans).GetChild(1).GetChild(8), ttfFont, itemInfo);
  }

  public override void SetStyle(byte style)
  {
  }

  public override Vector2 GetSize()
  {
    if (this.Kind == PetSkillHint.eKind.State)
    {
      float x = this.HintWidth;
      if (this.StateContText.cachedTextGeneratorForLayout.lineCount <= 1)
        x = (double) this.StateText.preferredWidth <= (double) this.StateContText.preferredWidth ? this.StateContText.preferredWidth + 16f : this.StateText.preferredWidth + 16f;
      return new Vector2(x, (float) ((double) ((Graphic) this.StateText).rectTransform.sizeDelta.y + (double) this.StateContText.preferredHeight + 16.0));
    }
    return this.Contents[1].activeSelf ? new Vector2(this.HintWidth, (float) (-(double) this.Contents[1].rectTransfrom.anchoredPosition.y + (double) this.Contents[1].Height + 25.0) + this.Note.Height) : new Vector2(this.HintWidth, (float) (-(double) this.Contents[0].rectTransfrom.anchoredPosition.y + (double) this.Contents[0].Height + 25.0) + this.Note.Height);
  }

  public override void SetContent(int kind, int fontsize, float width, int Parm1, int Parm2 = 0)
  {
    PetManager instance1 = PetManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.Kind = (PetSkillHint.eKind) kind;
    this.SkillID = (ushort) (Parm1 & (int) byte.MaxValue);
    this.PetID = (ushort) (Parm1 >> 16);
    this.Level = (byte) Parm2;
    byte index1 = 0;
    float num1 = 0.0f;
    PetData petData = instance1.FindPetData(this.PetID);
    PetSkillTbl recordByKey = instance1.PetSkillTable.GetRecordByKey(this.SkillID);
    if (this.Level == (byte) 0)
      this.Level = (byte) 1;
    if ((int) recordByKey.UpLevel < (int) this.Level)
      this.Level = recordByKey.UpLevel;
    if (this.Kind == PetSkillHint.eKind.State)
    {
      this.SetStateContent(mStringTable.GetStringByID((uint) recordByKey.Name), this.SkillID, this.Level);
      this.HintFrameSprite = this.BackSprite[3];
      this.StateObj.SetActive(true);
      this.OthersObj.SetActive(false);
    }
    else
    {
      this.StateObj.SetActive(false);
      this.OthersObj.SetActive(true);
      CString SpriteName = StringManager.Instance.StaticString1024();
      SpriteName.Append('s');
      SpriteName.IntToFormat((long) recordByKey.Icon, 5);
      SpriteName.AppendFormat("{0}");
      this.SkillImg.sprite = instance2.LoadSkillSprite(SpriteName);
      ((MaskableGraphic) this.SkillImg).material = instance2.GetSkillMaterial();
      this.NameText.text = mStringTable.GetStringByID((uint) recordByKey.Name);
      if (recordByKey.Diamond > (ushort) 0)
      {
        this.CrystalObj.SetActive(true);
        ++index1;
      }
      else
        this.CrystalObj.SetActive(false);
      switch (recordByKey.Type)
      {
        case 1:
          this.KindText.text = recordByKey.Subject != (byte) 1 ? (recordByKey.Subject != (byte) 2 ? (recordByKey.Subject != (byte) 3 ? string.Empty : mStringTable.GetStringByID(10085U)) : mStringTable.GetStringByID(10084U)) : mStringTable.GetStringByID(10083U);
          break;
        case 2:
          this.KindText.text = mStringTable.GetStringByID(10091U);
          break;
        default:
          this.KindText.text = string.Empty;
          break;
      }
      switch (this.Kind)
      {
        case PetSkillHint.eKind.Normal:
          byte needEnhance = this.GetNeedEnhance(petData);
          this.LineObj.SetActive(true);
          this.Contents[0].SetActive(true);
          this.Contents[0].SetData(ref recordByKey, this.Level, PetSkillHint._Content._ShowType.ShowNone, needEnhance, (sbyte) 0);
          if (petData != null && (int) petData.Enhance < (int) needEnhance)
          {
            this.Note.activeSelf = false;
            this.Contents[1].SetActive(true);
            num1 = 25f;
            this.Contents[1].SetData(ref recordByKey, recordByKey.UpLevel, PetSkillHint._Content._ShowType.ShowMax, needEnhance, this.GetNeedLv(recordByKey.UpLevel, recordByKey.OpenLevel, petData));
            break;
          }
          this.Note.activeSelf = recordByKey.Type == (byte) 2;
          if ((int) this.Level < (int) recordByKey.UpLevel)
          {
            this.Contents[1].SetActive(true);
            this.Contents[1].SetData(ref recordByKey, ++this.Level, PetSkillHint._Content._ShowType.ShowNext, needEnhance, this.GetNeedLv(this.Level, recordByKey.OpenLevel, petData));
            break;
          }
          this.Contents[1].SetActive(false);
          this.LineObj.SetActive(false);
          break;
        case PetSkillHint.eKind.MaxLv:
          this.Note.activeSelf = false;
          this.LineObj.SetActive(true);
          this.Contents[0].SetActive(true);
          this.Contents[0].SetData(ref recordByKey, this.Level, PetSkillHint._Content._ShowType.ShowNone, (byte) 0, (sbyte) 0);
          this.Contents[1].SetActive(true);
          this.Contents[1].SetData(ref recordByKey, recordByKey.UpLevel, PetSkillHint._Content._ShowType.ShowMax, this.GetNeedEnhance(petData), this.GetNeedLv(recordByKey.UpLevel, recordByKey.OpenLevel, petData));
          break;
        case PetSkillHint.eKind.Lv1AndMax:
          this.Note.activeSelf = false;
          this.LineObj.SetActive(true);
          this.Contents[0].SetActive(true);
          this.Contents[0].SetData(ref recordByKey, (byte) 1, PetSkillHint._Content._ShowType.ShowNone, (byte) 0, (sbyte) 0, PetSkillHint._Content.eFlag.ShowLvOne);
          this.Contents[1].SetActive(true);
          this.Contents[1].SetData(ref recordByKey, recordByKey.UpLevel, PetSkillHint._Content._ShowType.ShowMax, this.GetNeedEnhance(petData), this.GetNeedLv(recordByKey.UpLevel, recordByKey.OpenLevel, petData), PetSkillHint._Content.eFlag.SkipLvCheck);
          break;
        case PetSkillHint.eKind.CurentLv:
          this.LineObj.SetActive(false);
          this.Contents[0].SetActive(true);
          this.Contents[0].SetData(ref recordByKey, this.Level, PetSkillHint._Content._ShowType.ShowNone, (byte) 0, (sbyte) 0);
          this.Contents[1].SetActive(false);
          break;
        case PetSkillHint.eKind.Mail:
          this.Note.activeSelf = false;
          this.LineObj.SetActive(false);
          this.Contents[0].SetActive(true);
          this.Contents[0].SetData(ref recordByKey, this.Level, PetSkillHint._Content._ShowType.ShowNone, (byte) 0, (sbyte) 0, PetSkillHint._Content.eFlag.Mail);
          this.Contents[1].SetActive(false);
          break;
        default:
          this.Note.activeSelf = false;
          this.LineObj.SetActive(false);
          this.Contents[0].SetActive(false);
          this.Contents[1].SetActive(false);
          break;
      }
      if (this.Contents[0].CoolTime())
        ++index1;
      this.HintFrameSprite = this.BackSprite[(int) index1];
      this.DefHeight = this.DefHeights[(int) index1];
      this.Contents[0].rectTransfrom.anchoredPosition = new Vector2(this.Contents[0].rectTransfrom.anchoredPosition.x, -this.DefHeight);
      if (this.LineObj.activeSelf)
        this.LineRect.anchoredPosition = new Vector2(this.LineRect.anchoredPosition.x, (float) ((double) this.Contents[0].rectTransfrom.anchoredPosition.y - (double) this.Contents[0].Height - 25.0) + num1);
      if (this.Contents[1].activeSelf)
        this.Contents[1].rectTransfrom.anchoredPosition = new Vector2(this.Contents[1].rectTransfrom.anchoredPosition.x, (float) ((double) this.LineRect.anchoredPosition.y - (double) this.LineRect.sizeDelta.y - 13.0));
      if (this.Note.activeSelf)
        this.Note.rectTransform.anchoredPosition = !this.Contents[1].activeSelf ? new Vector2(this.Note.rectTransform.anchoredPosition.x, this.Contents[0].rectTransfrom.anchoredPosition.y - this.Contents[0].Height) : new Vector2(this.Note.rectTransform.anchoredPosition.x, this.Contents[1].rectTransfrom.anchoredPosition.y - this.Contents[1].Height);
      if ((double) this.CanvasRect.sizeDelta.y < (double) this.GetSize().y)
      {
        int num2 = 0;
        while ((double) this.CanvasRect.sizeDelta.y < (double) this.GetSize().y)
        {
          for (int index2 = 0; index2 < this.Contents.Length; ++index2)
          {
            if (this.Contents[index2].activeSelf)
              num2 = this.Contents[index2].FontShrink();
          }
          if (this.LineObj.activeSelf)
            this.LineRect.anchoredPosition = new Vector2(this.LineRect.anchoredPosition.x, (float) ((double) this.Contents[0].rectTransfrom.anchoredPosition.y - (double) this.Contents[0].Height - 25.0));
          if (this.Contents[1].activeSelf)
            this.Contents[1].rectTransfrom.anchoredPosition = new Vector2(this.Contents[1].rectTransfrom.anchoredPosition.x, (float) ((double) this.LineRect.anchoredPosition.y - (double) this.LineRect.sizeDelta.y - 13.0));
          if (num2 == 8)
            break;
        }
      }
      if (this.Contents[1].activeSelf && ((double) num1 > 0.0 || this.Kind == PetSkillHint.eKind.MaxLv || this.Kind == PetSkillHint.eKind.Lv1AndMax))
      {
        ((Component) this.MaxBackRect).gameObject.SetActive(true);
        this.MaxBackRect.anchoredPosition = new Vector2(this.MaxBackRect.anchoredPosition.x, this.LineRect.anchoredPosition.y - 5f);
        this.MaxBackRect.sizeDelta = new Vector2(this.MaxBackRect.sizeDelta.x, this.Contents[1].Height + 24f);
      }
      else
        ((Component) this.MaxBackRect).gameObject.SetActive(false);
    }
  }

  public void SetStateContent(string Name, ushort SkillID, byte Level)
  {
    ((Graphic) this.StateContText).rectTransform.sizeDelta = new Vector2(this.HintWidth - 16f, ((Graphic) this.StateContText).rectTransform.sizeDelta.y);
    PetManager.Instance.FormatSkillContent(SkillID, Level, this.Contents[0].ContStr, (byte) 1);
    this.StateText.text = Name;
    this.StateContText.text = this.Contents[0].ContStr.ToString();
    this.StateContText.SetAllDirty();
    this.StateContText.cachedTextGenerator.Invalidate();
    this.StateContText.cachedTextGeneratorForLayout.Invalidate();
    ((Graphic) this.StateContText).rectTransform.sizeDelta = new Vector2(((Graphic) this.StateContText).rectTransform.sizeDelta.x, this.StateContText.preferredHeight);
  }

  private sbyte GetNeedLv(byte Level, byte[] OpenLevel, PetData curPet)
  {
    sbyte needLv = 0;
    if (Level > (byte) 1 && (int) Level <= OpenLevel.Length + 1)
      needLv = (sbyte) OpenLevel[(int) Level - 2];
    if (curPet != null)
    {
      if (needLv > (sbyte) 0 && (int) curPet.Level < (int) needLv)
        needLv *= (sbyte) -1;
    }
    else
      needLv *= (sbyte) -1;
    return needLv;
  }

  private byte GetNeedEnhance(PetData curPet)
  {
    byte needEnhance = 0;
    if (this.PetID > (ushort) 0)
    {
      PetTbl recordByKey = PetManager.Instance.PetTable.GetRecordByKey(this.PetID);
      for (int index = 0; index < recordByKey.PetSkill.Length; ++index)
      {
        if ((int) recordByKey.PetSkill[index] == (int) this.SkillID)
        {
          if (curPet != null && (int) curPet.Enhance < index)
          {
            needEnhance = (byte) index;
            break;
          }
          break;
        }
      }
    }
    return needEnhance;
  }

  public override void TextRefresh()
  {
    ((Behaviour) this.NameText).enabled = false;
    ((Behaviour) this.NameText).enabled = true;
    ((Behaviour) this.KindText).enabled = false;
    ((Behaviour) this.KindText).enabled = true;
    ((Behaviour) this.CrystalText).enabled = false;
    ((Behaviour) this.CrystalText).enabled = true;
    ((Behaviour) this.StateText).enabled = false;
    ((Behaviour) this.StateText).enabled = true;
    ((Behaviour) this.StateContText).enabled = false;
    ((Behaviour) this.StateContText).enabled = true;
    this.Contents[0].TextRefresh();
    this.Contents[1].TextRefresh();
    this.Note.TextRefresh();
  }

  private enum UIHitTypeControl
  {
    State,
    Others,
  }

  private enum UIControl
  {
    Icon,
    Name,
    King,
    UseCrystal,
    Content1,
    LineImg,
    MaxBack,
    Content2,
    Note,
  }

  public enum eKind
  {
    Normal,
    MaxLv,
    Lv1AndMax,
    CurentLv,
    Mail,
    State,
  }

  public enum eBackImage
  {
    Type1,
    Type2,
    Type3,
    Type4,
    Max,
  }

  private struct _Content
  {
    private GameObject gameobject;
    public RectTransform rectTransfrom;
    private UIText ContText;
    private UIText TitleText;
    private UIText CooldownText;
    public CString ContStr;
    private CString CooldownStr;
    private CString TitleStr;
    private float DefHeight;
    private float OriContTop;
    private bool IsCoolTime;
    private int DefFontSize;

    public _Content(Transform transform, Font font)
    {
      this.gameobject = transform.gameObject;
      this.rectTransfrom = transform as RectTransform;
      this.ContText = transform.GetChild(0).GetComponent<UIText>();
      this.ContText.font = font;
      this.DefFontSize = this.ContText.fontSize;
      this.OriContTop = ((Graphic) this.ContText).rectTransform.anchoredPosition.y;
      this.CooldownText = transform.GetChild(1).GetComponent<UIText>();
      this.CooldownText.font = font;
      this.CooldownText.AdjuestUI();
      this.DefHeight = 0.0f;
      this.TitleText = transform.GetChild(2).GetComponent<UIText>();
      this.TitleText.font = font;
      this.ContStr = new CString(512);
      this.CooldownStr = new CString(64);
      this.TitleStr = new CString(32);
      this.IsCoolTime = false;
    }

    public void SetData(
      ref PetSkillTbl skillData,
      byte level,
      PetSkillHint._Content._ShowType type,
      byte needEnhance,
      sbyte NeedLv,
      PetSkillHint._Content.eFlag Flag = PetSkillHint._Content.eFlag.None)
    {
      this.ContStr.ClearString();
      this.CooldownStr.ClearString();
      this.ContText.fontSize = this.DefFontSize;
      StringTable mStringTable = DataManager.Instance.mStringTable;
      ((Graphic) this.TitleText).color = (Color) new Color32(byte.MaxValue, (byte) 201, (byte) 97, byte.MaxValue);
      switch (type)
      {
        case PetSkillHint._Content._ShowType.ShowNone:
          if (Flag == PetSkillHint._Content.eFlag.ShowLvOne)
          {
            ((Component) this.TitleText).gameObject.SetActive(true);
            this.TitleStr.ClearString();
            this.TitleStr.IntToFormat(1L);
            this.TitleStr.AppendFormat(mStringTable.GetStringByID(10136U));
            this.TitleText.text = this.TitleStr.ToString();
            this.TitleText.SetAllDirty();
            this.TitleText.cachedTextGenerator.Invalidate();
            break;
          }
          ((Component) this.TitleText).gameObject.SetActive(false);
          break;
        case PetSkillHint._Content._ShowType.ShowNext:
          if (needEnhance > (byte) 0)
          {
            this.DefHeight = 0.0f;
            ((Graphic) this.TitleText).color = (Color) new Color32(byte.MaxValue, (byte) 132, (byte) 109, byte.MaxValue);
            this.TitleText.text = mStringTable.GetStringByID(10085U + (uint) needEnhance);
            this.ContText.text = string.Empty;
            this.ContText.SetAllDirty();
            this.ContText.cachedTextGenerator.Invalidate();
            this.ContText.cachedTextGeneratorForLayout.Invalidate();
            ((Graphic) this.ContText).rectTransform.sizeDelta = new Vector2(((Graphic) this.ContText).rectTransform.sizeDelta.x, this.ContText.preferredHeight);
            return;
          }
          this.TitleText.text = mStringTable.GetStringByID(480U);
          this.CooldownText.alignment = TextAnchor.LowerRight;
          break;
        case PetSkillHint._Content._ShowType.ShowMax:
          this.TitleStr.ClearString();
          this.TitleStr.IntToFormat((long) skillData.UpLevel);
          this.TitleStr.AppendFormat(mStringTable.GetStringByID(10137U));
          ((Graphic) this.TitleText).color = (Color) new Color32((byte) 0, byte.MaxValue, byte.MaxValue, byte.MaxValue);
          this.TitleText.text = this.TitleStr.ToString();
          this.TitleText.SetAllDirty();
          this.TitleText.cachedTextGenerator.Invalidate();
          this.CooldownText.alignment = TextAnchor.LowerRight;
          if (NeedLv < (sbyte) 0 && Flag == PetSkillHint._Content.eFlag.SkipLvCheck)
          {
            NeedLv *= (sbyte) -1;
            break;
          }
          break;
        default:
          this.TitleText.text = string.Empty;
          this.CooldownText.alignment = TextAnchor.UpperRight;
          break;
      }
      this.CooldownStr.Append(mStringTable.GetStringByID(10082U));
      this.CooldownStr.Append(" ");
      ushort time = 0;
      if (skillData.CoolDown > (ushort) 0)
        time = PetManager.Instance.PetSkillCoolTable.GetRecordByKey(skillData.CoolDown).CoolBySkillLv[(int) level - 1];
      Vector2 vector2 = new Vector2(((Graphic) this.ContText).rectTransform.anchoredPosition.x, this.OriContTop);
      if (time == (ushort) 0 || Flag == PetSkillHint._Content.eFlag.Mail)
      {
        this.IsCoolTime = false;
        this.CooldownText.text = string.Empty;
        if (type != PetSkillHint._Content._ShowType.ShowNone && ((Component) this.TitleText).gameObject.activeSelf)
          vector2 = new Vector2(((Graphic) this.ContText).rectTransform.anchoredPosition.x, ((Graphic) this.CooldownText).rectTransform.anchoredPosition.y);
      }
      else
      {
        this.IsCoolTime = true;
        PetManager.Instance.FormatCoolTime(time, this.CooldownStr, !GUIManager.Instance.IsArabic ? (byte) 0 : (byte) 1);
        this.CooldownText.text = this.CooldownStr.ToString();
        this.CooldownText.SetAllDirty();
        this.CooldownText.cachedTextGenerator.Invalidate();
        vector2 = new Vector2(((Graphic) this.ContText).rectTransform.anchoredPosition.x, this.OriContTop);
      }
      if (Flag == PetSkillHint._Content.eFlag.ShowLvOne)
        vector2.y -= 30f;
      ((Graphic) this.ContText).rectTransform.anchoredPosition = vector2;
      PetManager.Instance.FormatSkillContent(skillData.ID, level, this.ContStr, Flag != PetSkillHint._Content.eFlag.State ? (byte) 0 : (byte) 1);
      if (type != PetSkillHint._Content._ShowType.ShowNone && NeedLv != (sbyte) 0)
      {
        this.ContStr.Append('\n');
        if (NeedLv < (sbyte) 0)
        {
          this.ContStr.Append("<color=#ff6278ff>");
          this.ContStr.IntToFormat((long) -NeedLv);
        }
        else
          this.ContStr.IntToFormat((long) NeedLv);
        this.ContStr.AppendFormat(mStringTable.GetStringByID(10089U));
        if (NeedLv < (sbyte) 0)
          this.ContStr.Append("</color>");
      }
      if (type == PetSkillHint._Content._ShowType.ShowNone)
      {
        if (needEnhance > (byte) 0)
        {
          this.ContStr.Append('\n');
          this.ContStr.Append('\n');
          this.ContStr.Append("<color=#ff6278ff>");
          this.ContStr.Append(mStringTable.GetStringByID(10085U + (uint) needEnhance));
          this.ContStr.Append("</color>");
        }
        if ((int) level == (int) skillData.UpLevel)
        {
          this.ContStr.Append('\n');
          this.ContStr.Append("<color=#ffc961ff>");
          this.ContStr.Append(mStringTable.GetStringByID(481U));
          this.ContStr.Append("</color>");
        }
      }
      this.ContText.text = this.ContStr.ToString();
      this.ContText.SetAllDirty();
      this.ContText.cachedTextGenerator.Invalidate();
      this.ContText.cachedTextGeneratorForLayout.Invalidate();
      ((Graphic) this.ContText).rectTransform.sizeDelta = new Vector2(((Graphic) this.ContText).rectTransform.sizeDelta.x, this.ContText.preferredHeight);
      if (this.IsCoolTime)
      {
        if (((Component) this.TitleText).gameObject.activeSelf)
          this.DefHeight = ((Graphic) this.CooldownText).rectTransform.sizeDelta.y + ((Graphic) this.TitleText).rectTransform.sizeDelta.y;
        else
          this.DefHeight = ((Graphic) this.CooldownText).rectTransform.sizeDelta.y;
      }
      else if (Flag == PetSkillHint._Content.eFlag.ShowLvOne)
        this.DefHeight = ((Graphic) this.CooldownText).rectTransform.sizeDelta.y + 30f;
      else
        this.DefHeight = ((Graphic) this.CooldownText).rectTransform.sizeDelta.y;
    }

    public bool CoolTime() => this.IsCoolTime;

    public void SetActive(bool Active) => this.gameobject.SetActive(Active);

    public int FontShrink()
    {
      --this.ContText.fontSize;
      ((Graphic) this.ContText).SetLayoutDirty();
      this.ContText.cachedTextGeneratorForLayout.Invalidate();
      return this.ContText.fontSize;
    }

    public bool activeSelf => this.gameobject.activeSelf;

    public float Height
    {
      get => this.gameobject.activeSelf ? this.DefHeight + this.ContText.preferredHeight : 0.0f;
    }

    public void TextRefresh()
    {
      ((Behaviour) this.ContText).enabled = false;
      ((Behaviour) this.ContText).enabled = true;
      ((Behaviour) this.CooldownText).enabled = false;
      ((Behaviour) this.CooldownText).enabled = true;
      ((Behaviour) this.TitleText).enabled = false;
      ((Behaviour) this.TitleText).enabled = true;
    }

    public enum _ShowType
    {
      ShowNone,
      ShowNext,
      ShowMax,
    }

    public enum eFlag
    {
      None,
      Mail,
      State,
      SkipLvCheck,
      ShowLvOne,
    }
  }

  private struct _Note
  {
    private GameObject gameobject;
    public RectTransform rectTransform;
    private UIText NoteText;

    public _Note(Transform transform, Font font, UILoadImageHander hander)
    {
      this.gameobject = transform.gameObject;
      this.rectTransform = transform as RectTransform;
      transform.GetChild(0).GetComponent<CustomImage>().hander = hander;
      this.NoteText = transform.GetChild(1).GetComponent<UIText>();
      this.NoteText.font = font;
      this.NoteText.text = DataManager.Instance.mStringTable.GetStringByID(10135U);
    }

    public bool activeSelf
    {
      get => this.gameobject.activeSelf;
      set => this.gameobject.SetActive(value);
    }

    public float Height
    {
      get
      {
        if (!this.activeSelf)
          return 0.0f;
        RectTransform rectTransform = ((Graphic) this.NoteText).rectTransform;
        return -rectTransform.anchoredPosition.y + rectTransform.sizeDelta.y;
      }
    }

    public void TextRefresh()
    {
      ((Behaviour) this.NoteText).enabled = false;
      ((Behaviour) this.NoteText).enabled = true;
    }
  }
}
