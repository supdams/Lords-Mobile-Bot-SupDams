// Decompiled with JetBrains decompiler
// Type: UILordItemInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UILordItemInfo : IUIButtonDownUpHandler
{
  public CanvasGroup Canvasgroup;
  public RectTransform m_RectTransform;
  private Transform ItemTrans;
  private Transform TimeTrans;
  private RectTransform EffectTrans;
  private RectTransform ContTextRect;
  private Transform[] LinTrans = new Transform[3];
  private UIText NameText;
  private UIText LevelText;
  private UIText KindText;
  private UIText ContText;
  private UIText TimeText;
  private UIText OwnText;
  private UIText[] EffTitleText;
  private UIText[] EffNumText;
  private CString LevelStr;
  private CString NameStr;
  private CString TimeStr;
  private CString OwnStr;
  private CString[] EffNumStr;
  private Vector3 OriKindPos;
  private Vector3 OriEffPos;
  private byte EffSize;
  private Vector2 OriTextSize;
  private Vector2 OriRectSize;
  private float[] Heights = new float[4]
  {
    194f,
    218f,
    241f,
    266f
  };
  private float ExtendHeight;
  public UIButtonHint m_ButtonHint;
  private bool _HideEquipVal;

  public bool HideEquipVal
  {
    get => this._HideEquipVal;
    set => this._HideEquipVal = value;
  }

  public void Load()
  {
    Object original = GUIManager.Instance.m_ManagerAssetBundle.Load(nameof (UILordItemInfo));
    if (original == (Object) null)
      return;
    this.EffTitleText = new UIText[6];
    this.EffNumText = new UIText[6];
    this.EffNumStr = new CString[6];
    GUIManager instance = GUIManager.Instance;
    Font ttfFont = instance.GetTTFFont();
    GameObject gameObject = (GameObject) Object.Instantiate(original);
    gameObject.transform.SetParent((Transform) instance.m_WindowTopLayer, false);
    gameObject.SetActive(false);
    this.m_RectTransform = (RectTransform) gameObject.transform;
    this.OriRectSize = this.m_RectTransform.sizeDelta;
    this.Canvasgroup = ((Component) this.m_RectTransform).GetComponent<CanvasGroup>();
    this.ItemTrans = ((Transform) this.m_RectTransform).GetChild(1);
    for (int index = 0; index < this.LinTrans.Length; ++index)
    {
      this.LinTrans[index] = ((Transform) this.m_RectTransform).GetChild(8).GetChild(index);
      this.LinTrans[index].GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    }
    ((Component) this.m_RectTransform).GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    ((Transform) this.m_RectTransform).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    ((Transform) this.m_RectTransform).GetChild(6).GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    this.NameText = ((Transform) this.m_RectTransform).GetChild(2).GetComponent<UIText>();
    this.NameText.font = ttfFont;
    this.LevelText = ((Transform) this.m_RectTransform).GetChild(3).GetComponent<UIText>();
    this.LevelText.font = ttfFont;
    this.KindText = ((Transform) this.m_RectTransform).GetChild(4).GetComponent<UIText>();
    this.KindText.font = ttfFont;
    this.OwnText = ((Transform) this.m_RectTransform).GetChild(5).GetComponent<UIText>();
    this.OwnText.font = ttfFont;
    this.TimeTrans = ((Transform) this.m_RectTransform).GetChild(6);
    this.TimeText = this.TimeTrans.GetChild(0).GetComponent<UIText>();
    this.TimeText.font = ttfFont;
    this.ContTextRect = ((Transform) this.m_RectTransform).GetChild(7).GetComponent<RectTransform>();
    this.ContText = ((Component) this.ContTextRect).GetComponent<UIText>();
    this.ContText.font = ttfFont;
    this.OriTextSize = ((Graphic) this.ContText).rectTransform.sizeDelta;
    this.EffectTrans = ((Transform) this.m_RectTransform).GetChild(8).GetComponent<RectTransform>();
    this.OriEffPos = (Vector3) this.EffectTrans.anchoredPosition;
    int childCount = ((Transform) this.EffectTrans).childCount;
    for (int index1 = 0; index1 < this.EffTitleText.Length; ++index1)
    {
      int index2 = (index1 + 1) * 2 + 1;
      this.EffTitleText[index1] = ((Transform) this.m_RectTransform).GetChild(8).GetChild(index2).GetComponent<UIText>();
      this.EffTitleText[index1].font = ttfFont;
      this.EffNumText[index1] = ((Transform) this.m_RectTransform).GetChild(8).GetChild(index2 + 1).GetComponent<UIText>();
      this.EffNumText[index1].font = ttfFont;
    }
    for (int index = 0; index < this.EffNumStr.Length; ++index)
      this.EffNumStr[index] = StringManager.Instance.SpawnString();
    instance.InitLordEquipImg(this.ItemTrans, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    this.LevelStr = StringManager.Instance.SpawnString();
    this.NameStr = StringManager.Instance.SpawnString(100);
    this.TimeStr = StringManager.Instance.SpawnString();
    this.OwnStr = StringManager.Instance.SpawnString();
    this.OriKindPos = ((Component) this.KindText).transform.localPosition;
  }

  public void UnLoad()
  {
    StringManager.Instance.DeSpawnString(this.LevelStr);
    StringManager.Instance.DeSpawnString(this.NameStr);
    StringManager.Instance.DeSpawnString(this.TimeStr);
    StringManager.Instance.DeSpawnString(this.OwnStr);
    for (int index = 0; index < this.EffNumStr.Length; ++index)
      StringManager.Instance.DeSpawnString(this.EffNumStr[index]);
  }

  public void Show(UIButtonHint hint, ushort ItemID, byte Rank, int Num = -1)
  {
    if ((Object) GUIManager.Instance.m_SimpleItemInfo.m_ButtonHint != (Object) null)
      GUIManager.Instance.m_SimpleItemInfo.Hide(GUIManager.Instance.m_SimpleItemInfo.m_ButtonHint);
    if (Rank == (byte) 0)
      return;
    if (((Component) this.m_RectTransform).gameObject.activeSelf)
      this.Hide(this.m_ButtonHint);
    DataManager instance = DataManager.Instance;
    bool flag1 = false;
    bool flag2 = false;
    Equip recordByKey1 = instance.EquipTable.GetRecordByKey(ItemID);
    if (!GUIManager.Instance.IsLeadItem(recordByKey1.EquipKind))
      return;
    GUIManager.Instance.ChangeLordEquipImg(this.ItemTrans, ItemID, Rank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    if (recordByKey1.EquipKind >= (byte) 21 && recordByKey1.EquipKind <= (byte) 26)
    {
      flag2 = true;
      this.LevelStr.ClearString();
      if ((int) recordByKey1.NeedLv <= (int) instance.RoleAttr.Level)
      {
        this.LevelStr.IntToFormat((long) recordByKey1.NeedLv);
      }
      else
      {
        CString tmpS = StringManager.Instance.StaticString1024();
        tmpS.IntToFormat((long) recordByKey1.NeedLv);
        tmpS.AppendFormat("<color=#FF5581FF>{0}</color>");
        this.LevelStr.StringToFormat(tmpS);
      }
      this.LevelStr.AppendFormat(instance.mStringTable.GetStringByID(885U));
      this.LevelText.text = this.LevelStr.ToString();
      this.LevelText.SetAllDirty();
      this.LevelText.cachedTextGenerator.Invalidate();
      flag1 = true;
      this.KindText.text = instance.mStringTable.GetStringByID((uint) (7431 + (int) recordByKey1.EquipKind - 21));
      if (!this._HideEquipVal && recordByKey1.TimedType > (byte) 0)
      {
        this.TimeTrans.gameObject.SetActive(true);
        this.TimeStr.ClearString();
        if (recordByKey1.TimedTime >= 86400U)
          GameConstants.GetTimeString(this.TimeStr, recordByKey1.TimedTime);
        else
          this.TimeStr.Append(DataManager.MissionDataManager.FormatMissionTime(recordByKey1.TimedTime));
        this.TimeText.text = this.TimeStr.ToString();
        this.TimeText.SetAllDirty();
        this.TimeText.cachedTextGenerator.Invalidate();
        this.ExtendHeight = 25f;
      }
    }
    else if (recordByKey1.EquipKind == (byte) 27)
    {
      ((Component) this.KindText).transform.localPosition = ((Component) this.LevelText).transform.localPosition;
      flag1 = true;
      this.KindText.text = instance.mStringTable.GetStringByID(878U);
      this.OwnStr.ClearString();
      this.OwnStr.Append("(");
      if (Num == -1)
        this.OwnStr.IntToFormat((long) instance.GetCurItemQuantity(ItemID, Rank), bNumber: true);
      else
        this.OwnStr.IntToFormat((long) Num, bNumber: true);
      this.OwnStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(79U));
      this.OwnStr.Append(")");
      this.OwnText.text = this.OwnStr.ToString();
      this.OwnText.SetAllDirty();
      this.OwnText.cachedTextGenerator.Invalidate();
    }
    else if (recordByKey1.EquipKind == (byte) 20)
    {
      ((Component) this.KindText).transform.localPosition = ((Component) this.LevelText).transform.localPosition;
      ((Component) this.ContText).gameObject.SetActive(true);
      this.ContText.text = instance.mStringTable.GetStringByID((uint) recordByKey1.EquipInfo);
      if ((double) this.ContText.preferredHeight > (double) ((Graphic) this.ContText).rectTransform.sizeDelta.y)
      {
        this.m_RectTransform.sizeDelta = new Vector2(this.m_RectTransform.sizeDelta.x, this.ContText.preferredHeight + 131.7f);
        ((Graphic) this.ContText).rectTransform.sizeDelta = new Vector2(((Graphic) this.ContText).rectTransform.sizeDelta.x, this.ContText.preferredHeight);
      }
      this.KindText.text = instance.mStringTable.GetStringByID(879U);
      this.OwnStr.ClearString();
      this.OwnStr.Append("(");
      if (Num == -1)
        this.OwnStr.IntToFormat((long) instance.GetCurItemQuantity(ItemID, Rank), bNumber: true);
      else
        this.OwnStr.IntToFormat((long) Num, bNumber: true);
      this.OwnStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(79U));
      this.OwnStr.Append(")");
      this.OwnText.text = this.OwnStr.ToString();
      this.OwnText.SetAllDirty();
      this.OwnText.cachedTextGenerator.Invalidate();
    }
    this.NameStr.ClearString();
    this.NameStr.StringToFormat(GameConstants.SItemRareHeader[(int) Rank]);
    this.NameStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey1.EquipName));
    this.NameStr.StringToFormat("</color>");
    this.NameStr.AppendFormat("{0}{1}{2}");
    this.NameText.text = this.NameStr.ToString();
    this.NameText.SetAllDirty();
    this.NameText.cachedTextGenerator.Invalidate();
    this.EffSize = (byte) 0;
    if (flag1)
    {
      if (flag2 && this._HideEquipVal)
      {
        ((Component) this.ContText).gameObject.SetActive(true);
        this.ContText.text = instance.mStringTable.GetStringByID((uint) recordByKey1.EquipInfo);
      }
      else
      {
        ((Component) this.EffectTrans).gameObject.SetActive(true);
        for (int index = 0; index < recordByKey1.PropertiesInfo.Length && recordByKey1.PropertiesInfo[index].Propertieskey != (ushort) 0; ++index)
        {
          LordEquipEffectData recordByKey2 = instance.LordEquipEffectTable.GetRecordByKey(recordByKey1.PropertiesInfo[index].Propertieskey);
          Effect recordByKey3 = instance.EffectData.GetRecordByKey(recordByKey2.EffectID);
          this.EffTitleText[index].text = instance.mStringTable.GetStringByID((uint) recordByKey3.InfoID);
          this.EffNumStr[index].ClearString();
          if (recordByKey3.ValueID == (ushort) 0)
          {
            this.EffNumStr[index].IntToFormat((long) recordByKey2.RarePercent[(int) Rank - 1]);
            this.EffNumStr[index].AppendFormat("{0}");
          }
          else
          {
            this.EffNumStr[index].FloatToFormat((float) recordByKey2.RarePercent[(int) Rank - 1] / 100f, 2, false);
            if (GUIManager.Instance.IsArabic)
              this.EffNumStr[index].AppendFormat("%{0}");
            else
              this.EffNumStr[index].AppendFormat("{0}%");
          }
          this.EffNumText[index].text = this.EffNumStr[index].ToString();
          this.EffNumText[index].SetAllDirty();
          this.EffNumText[index].cachedTextGenerator.Invalidate();
          ++this.EffSize;
          if (this.EffSize >= (byte) 3)
          {
            ((Component) this.EffTitleText[index]).gameObject.SetActive(true);
            ((Component) this.EffNumText[index]).gameObject.SetActive(true);
          }
          if (this.EffSize == (byte) 4)
            this.LinTrans[1].gameObject.SetActive(true);
          else if (this.EffSize == (byte) 6)
            this.LinTrans[2].gameObject.SetActive(true);
        }
      }
    }
    if (this.EffSize == (byte) 1)
      this.LinTrans[0].gameObject.SetActive(false);
    if (this.EffSize > (byte) 3)
      this.m_RectTransform.sizeDelta = new Vector2(this.m_RectTransform.sizeDelta.x, this.Heights[(int) this.EffSize - 3]);
    this.m_ButtonHint = hint;
    this.m_ButtonHint.GetTipPosition(this.m_RectTransform);
    ((Component) this.m_RectTransform).gameObject.SetActive(true);
    if ((double) this.ExtendHeight > 0.0)
    {
      this.m_RectTransform.sizeDelta = new Vector2(this.m_RectTransform.sizeDelta.x, this.m_RectTransform.sizeDelta.y + this.ExtendHeight);
      this.ContTextRect.anchoredPosition = new Vector2(this.ContTextRect.anchoredPosition.x, this.ContTextRect.anchoredPosition.y + this.ExtendHeight);
      this.EffectTrans.anchoredPosition = new Vector2(this.EffectTrans.anchoredPosition.x, this.EffectTrans.anchoredPosition.y - this.ExtendHeight);
    }
    this.Canvasgroup.alpha = 1f;
    UILEBtn component = hint.transform.GetComponent<UILEBtn>();
    if (!((Object) component != (Object) null) || component.m_Handler != null)
      return;
    int soundIndex = (int) component.SoundIndex;
    if ((soundIndex & 64) == 0)
    {
      AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex) soundIndex);
    }
    else
    {
      if ((soundIndex & 64) <= 0)
        return;
      AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex) (soundIndex & -65));
    }
  }

  public void Hide(UIButtonHint hint)
  {
    if ((Object) this.m_ButtonHint != (Object) hint)
      return;
    this.m_ButtonHint = (UIButtonHint) null;
    ((Component) this.m_RectTransform).gameObject.SetActive(false);
    ((Component) this.ContText).transform.gameObject.SetActive(false);
    ((Component) this.EffectTrans).transform.gameObject.SetActive(false);
    this.TimeTrans.transform.gameObject.SetActive(false);
    UIText nameText = this.NameText;
    string empty1 = string.Empty;
    this.KindText.text = empty1;
    string str1 = empty1;
    this.LevelText.text = str1;
    string str2 = str1;
    nameText.text = str2;
    for (int index = 0; index < this.EffTitleText.Length; ++index)
    {
      UIText uiText = this.EffTitleText[index];
      string empty2 = string.Empty;
      this.EffNumText[index].text = empty2;
      string str3 = empty2;
      uiText.text = str3;
    }
    ((Component) this.KindText).transform.localPosition = this.OriKindPos;
    this.OwnText.text = string.Empty;
    if (this.EffSize >= (byte) 3)
    {
      for (int index = 3; index < (int) this.EffSize; ++index)
      {
        ((Component) this.EffTitleText[index]).gameObject.SetActive(false);
        ((Component) this.EffNumText[index]).gameObject.SetActive(false);
      }
      this.m_RectTransform.sizeDelta = new Vector2(this.m_RectTransform.sizeDelta.x, this.Heights[0]);
      this.LinTrans[1].gameObject.SetActive(false);
      this.LinTrans[2].gameObject.SetActive(false);
    }
    else if (((Component) this.ContText).gameObject.activeSelf)
    {
      ((Component) this.ContText).gameObject.SetActive(false);
      this.m_RectTransform.sizeDelta = new Vector2(this.m_RectTransform.sizeDelta.x, this.Heights[0]);
    }
    if ((double) this.ExtendHeight > 0.0)
    {
      this.ContTextRect.anchoredPosition = new Vector2(this.ContTextRect.anchoredPosition.x, this.ContTextRect.anchoredPosition.y - this.ExtendHeight);
      this.EffectTrans.anchoredPosition = (Vector2) this.OriEffPos;
    }
    this.ExtendHeight = 0.0f;
    this.EffSize = (byte) 0;
    this.LinTrans[0].gameObject.SetActive(true);
    ((Graphic) this.ContText).rectTransform.sizeDelta = this.OriTextSize;
    this.m_RectTransform.sizeDelta = this.OriRectSize;
  }

  public void OnButtonDown(UIButtonHint sender) => this.Show(sender, sender.Parm1, sender.Parm2);

  public void OnButtonUp(UIButtonHint sender) => this.Hide(sender);

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (Object) menu)
      return;
    img.sprite = menu.LoadSprite(ImageName);
    if ((bool) (Object) img.sprite)
    {
      ((MaskableGraphic) img).material = menu.LoadMaterial();
    }
    else
    {
      img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
      ((MaskableGraphic) img).material = GUIManager.Instance.GetFrameMaterial();
    }
  }

  public void TextRefresh()
  {
    if ((Object) this.m_RectTransform == (Object) null || !((Component) this.m_RectTransform).gameObject.activeSelf)
      return;
    ((Behaviour) this.NameText).enabled = false;
    ((Behaviour) this.NameText).enabled = true;
    ((Behaviour) this.LevelText).enabled = false;
    ((Behaviour) this.LevelText).enabled = true;
    ((Behaviour) this.KindText).enabled = false;
    ((Behaviour) this.KindText).enabled = true;
    ((Behaviour) this.ContText).enabled = false;
    ((Behaviour) this.ContText).enabled = true;
    ((Behaviour) this.TimeText).enabled = false;
    ((Behaviour) this.TimeText).enabled = true;
    ((Behaviour) this.OwnText).enabled = false;
    ((Behaviour) this.OwnText).enabled = true;
    for (int index = 0; index < this.EffTitleText.Length; ++index)
    {
      ((Behaviour) this.EffTitleText[index]).enabled = false;
      ((Behaviour) this.EffTitleText[index]).enabled = true;
      ((Behaviour) this.EffNumText[index]).enabled = false;
      ((Behaviour) this.EffNumText[index]).enabled = true;
    }
  }

  private enum UIControl
  {
    Shadow,
    ItemRect,
    Name,
    Level,
    Kind,
    Own,
    Time,
    Cont,
    Effect,
  }
}
