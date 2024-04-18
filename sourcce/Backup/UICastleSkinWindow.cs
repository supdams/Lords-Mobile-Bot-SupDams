// Decompiled with JetBrains decompiler
// Type: UICastleSkinWindow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UICastleSkinWindow : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  protected UIText MainTitle;
  protected Transform ScrollLayerTrans;
  private Transform DiverseTrans;
  private RectTransform ThisTransform;
  private RectTransform ScrollRect;
  protected UICastleSkinWindow._CastleHint Hint;
  protected ScrollPanel_Horizontal CastleView;
  private List<float> ItemsHeight = new List<float>();
  private float ScrollViewWidth = 744f;
  protected ushort[] AllCastleID;
  private UICastleSkinWindow._CastleItem[] ViewItem;
  protected CastleSkin._SortType ListSortType = CastleSkin._SortType.All;
  protected UISpritesArray StarArray;
  protected ushort SelectedCastleID;
  protected float DeltaTime;
  private UICastleSkinWindow._CastleItem LastSelect;
  private byte Delay = 2;
  private byte bDeActive;
  protected byte CastleLv;
  protected byte ScrollToPosition;

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager instance = GUIManager.Instance;
    Font ttfFont = instance.GetTTFFont();
    instance.UpdateUI(EGUIWindow.Door, 1, 2);
    this.ThisTransform = (Object.Instantiate(this.m_AssetBundle.Load("UICastleSkin")) as GameObject).transform as RectTransform;
    ((Transform) this.ThisTransform).SetParent((Transform) instance.m_WindowsTransform, false);
    this.MainTitle = ((Transform) this.ThisTransform).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.MainTitle.font = ttfFont;
    this.DiverseTrans = ((Transform) this.ThisTransform).GetChild(2);
    this.transform.SetParent(this.DiverseTrans, false);
    UIButton component1 = ((Transform) this.ThisTransform).GetChild(1).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 100;
    if (instance.IsArabic)
    {
      ((Component) component1).transform.localScale = new Vector3(-1f, 1f, 1f);
      ((Transform) this.ThisTransform).GetChild(3).GetChild(1).GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
    }
    if (instance.bOpenOnIPhoneX)
      ((Behaviour) ((Transform) this.ThisTransform).GetChild(4).GetComponent<CustomImage>()).enabled = false;
    else
      ((Transform) this.ThisTransform).GetChild(4).GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    ((Transform) this.ThisTransform).GetChild(4).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) instance.m_ItemInfo;
    UIButton component2 = ((Transform) this.ThisTransform).GetChild(4).GetChild(0).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 101;
    this.StarArray = ((Transform) this.ThisTransform).GetChild(3).GetChild(0).GetComponent<UISpritesArray>();
    this.ScrollLayerTrans = ((Transform) this.ThisTransform).GetChild(3);
    this.CastleView = ((Transform) this.ThisTransform).GetChild(3).GetChild(0).GetChild(0).GetComponent<ScrollPanel_Horizontal>();
    this.Hint = new UICastleSkinWindow._CastleHint(((Transform) this.ThisTransform).GetChild(5), ttfFont);
    this.CastleLv = instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level;
    this.SelectedCastleID = (ushort) instance.CastleSkinSaved[0];
    if (this.CastleLv >= (byte) 25 && !DataManager.Instance.CheckPrizeFlag((byte) 21))
    {
      this.ScrollToPosition = (byte) 1;
      this.SelectedCastleID = (ushort) 1;
    }
    else if (this.SelectedCastleID == (ushort) 0)
      this.SelectedCastleID = (ushort) 1;
    int x = (int) ((Component) instance.m_UICanvas).GetComponent<RectTransform>().sizeDelta.x;
    if (x < 1024)
      return;
    this.SetLargeSize(x);
  }

  public override void ReOnOpen() => ((Component) this.ThisTransform).gameObject.SetActive(true);

  public void OnDisable() => this.bDeActive = (byte) 1;

  protected virtual void SetLargeSize(int screenWidth)
  {
    this.ScrollViewWidth = 789f;
    RectTransform component = this.CastleView.GetComponent<RectTransform>();
    component.sizeDelta = new Vector2(this.ScrollViewWidth, component.sizeDelta.y);
  }

  public virtual void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 101)
    {
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
    }
    else
    {
      if (sender.m_BtnID1 != 100)
        return;
      this.OnInfoClick(sender);
    }
  }

  public virtual void Initial()
  {
    byte count;
    this.AllCastleID = GUIManager.Instance.BuildingData.castleSkin.GetAllCastleID(this.ListSortType, out count);
    this.ViewItem = new UICastleSkinWindow._CastleItem[Mathf.Min((int) count, 7)];
    for (byte index = 0; (int) index < (int) count; ++index)
      this.ItemsHeight.Add(120f);
    this.ScrollLayerTrans.gameObject.SetActive(true);
    this.CastleView.IntiScrollPanel(this.ScrollViewWidth, 12f, 16f, this.ItemsHeight, 7, (IUpDateScrollPanel) this);
    this.ScrollRect = ((Transform) this.ThisTransform).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetComponent<RectTransform>();
    float width = GameConstants.ConvertBytesToFloat(GUIManager.Instance.CastleSkinSaved, 1);
    for (int index = 0; index < this.AllCastleID.Length; ++index)
    {
      if ((int) this.AllCastleID[index] == (int) this.SelectedCastleID)
      {
        UICastleSkinWindow._CastleItem lastSelect = this.LastSelect;
        if (this.LastSelect != null)
          this.LastSelect.SetSelect(false);
        this.LastSelect = (UICastleSkinWindow._CastleItem) null;
        if (this.ScrollToPosition == (byte) 1)
        {
          this.GoToScroll(index, (ushort) 0);
          break;
        }
        this.CastleView.GoTo((int) GUIManager.Instance.CastleSkinSaved[5], width);
        break;
      }
    }
  }

  protected void GoToScroll(int index, ushort selectCastleID = 0)
  {
    this.SelectedCastleID = selectCastleID != (ushort) 0 ? selectCastleID : (index >= this.AllCastleID.Length ? (ushort) 1 : this.AllCastleID[index]);
    if (index > 0)
      --index;
    float num = 120f * (float) index + (float) (16 * index);
    if ((double) num + (double) this.ScrollViewWidth > (double) this.ScrollRect.sizeDelta.x)
      num = this.ScrollRect.sizeDelta.x - this.ScrollViewWidth;
    this.CastleView.GoTo(index, -num);
    for (int index1 = 0; index1 < this.ViewItem.Length; ++index1)
    {
      if (this.ViewItem[index1].gameobject.activeSelf && (int) this.ViewItem[index1].CastleID == (int) this.SelectedCastleID)
      {
        if (this.LastSelect != null)
          this.LastSelect.SetSelect(false);
        this.LastSelect = this.ViewItem[index1];
        this.ViewItem[index1].SetSelect(true);
        break;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (this.Delay > (byte) 0)
      return;
    if (GUIManager.Instance.BuildingData.castleSkin.curSortType != this.ListSortType)
    {
      this.LastSelect = (UICastleSkinWindow._CastleItem) null;
      byte count;
      this.AllCastleID = GUIManager.Instance.BuildingData.castleSkin.GetAllCastleID(this.ListSortType, out count);
      int num = this.ItemsHeight.Count - (int) count;
      if (num < 0)
      {
        for (short index = 0; (int) index > num; --index)
          this.ItemsHeight.Insert(this.ItemsHeight.Count - 1, 120f);
      }
      else if (num > 0)
      {
        for (byte index = 0; (int) index < num; ++index)
          this.ItemsHeight.RemoveAt(this.ItemsHeight.Count - 1);
      }
      this.CastleLv = GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level;
      Vector2 anchoredPosition = this.ScrollRect.anchoredPosition;
      int beginIdx = this.CastleView.GetBeginIdx();
      this.CastleView.AddNewDataHeight(this.ItemsHeight);
      this.CastleView.GoTo(beginIdx, anchoredPosition.x);
    }
    else
    {
      for (int index = 0; index < this.ViewItem.Length; ++index)
      {
        this.ViewItem[index].UpdateSelf();
        if ((int) this.ViewItem[index].CastleID == (int) this.SelectedCastleID)
        {
          this.ViewItem[index].SetSelect(true);
          this.LastSelect = this.ViewItem[index];
        }
      }
    }
    this.Hint.Update();
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (this.ViewItem[panelObjectIdx] == null)
      this.ViewItem[panelObjectIdx] = new UICastleSkinWindow._CastleItem(item.transform, this.StarArray);
    if (this.AllCastleID.Length > dataIdx)
      this.ViewItem[panelObjectIdx].SetData((byte) this.AllCastleID[dataIdx]);
    else
      this.ViewItem[panelObjectIdx].SetData((byte) this.AllCastleID[0]);
    if ((int) this.ViewItem[panelObjectIdx].CastleID != (int) this.SelectedCastleID)
      return;
    this.ViewItem[panelObjectIdx].SetSelect(true);
    if (this.LastSelect != null && (int) this.ViewItem[panelObjectIdx].CastleID == (int) this.LastSelect.CastleID)
      return;
    this.LastSelect = this.ViewItem[panelObjectIdx];
  }

  public virtual void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
    this.SelectedCastleID = this.AllCastleID.Length <= dataIndex ? (ushort) 1 : this.AllCastleID[dataIndex];
    if (this.LastSelect != null)
      this.LastSelect.SetSelect(false);
    for (int index = 0; index < this.ViewItem.Length; ++index)
    {
      if (this.ViewItem[index].gameobject.activeSelf && (int) this.ViewItem[index].CastleID == (int) this.SelectedCastleID)
      {
        this.ViewItem[index].SetSelect(true);
        this.LastSelect = this.ViewItem[index];
        break;
      }
    }
    GUIManager.Instance.BuildingData.castleSkin.SaveCastleSkinSave();
  }

  public override void OnClose()
  {
    if (this.Delay == (byte) 0)
    {
      GUIManager.Instance.CastleSkinSaved[0] = (byte) this.SelectedCastleID;
      GameConstants.GetBytes(this.ScrollRect.anchoredPosition.x, GUIManager.Instance.CastleSkinSaved, 1);
      GUIManager.Instance.CastleSkinSaved[5] = (byte) this.CastleView.GetBeginIdx();
    }
    this.Hint.Destroy();
    Object.Destroy((Object) ((Component) this.ThisTransform).gameObject);
    GUIManager.Instance.BuildingData.castleSkin.ClearCastleSkinUI();
  }

  public virtual void OnInfoClick(UIButton sender)
  {
  }

  public virtual void ClassticalCastleChanged()
  {
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh_BuildBase:
        byte level = GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level;
        if ((int) level == (int) this.CastleLv)
          break;
        this.CastleLv = level;
        for (int index = 0; index < this.ViewItem.Length; ++index)
        {
          if (this.ViewItem[index].CastleID == (byte) 1)
          {
            this.ViewItem[index].UpdateSelf();
            break;
          }
        }
        if (this.SelectedCastleID != (ushort) 1)
          break;
        this.Hint.Update();
        this.ClassticalCastleChanged();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Hint.TextRefresh();
        ((Behaviour) this.MainTitle).enabled = false;
        ((Behaviour) this.MainTitle).enabled = true;
        break;
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    this.DeltaTime += Time.deltaTime;
    if ((double) this.DeltaTime >= 2.0)
      this.DeltaTime = 0.0f;
    if (this.Delay > (byte) 0)
    {
      --this.Delay;
      if (this.Delay == (byte) 0)
        this.Initial();
    }
    if (this.bDeActive <= (byte) 0)
      return;
    --this.bDeActive;
    if (this.bDeActive != (byte) 0)
      return;
    ((Component) this.ThisTransform).gameObject.SetActive(false);
  }

  private enum UIControl
  {
    Title,
    Info,
    Diverse,
    CastleList,
    Close,
    Hint,
  }

  private enum ClickType
  {
    Info = 100, // 0x00000064
    Close = 101, // 0x00000065
  }

  protected enum SpriteIndex
  {
    StarOff,
    StarOn,
    Add,
    Use,
  }

  protected struct _CastleHint
  {
    public RectTransform ThisTransform;
    private GameObject ThisTransObj;
    private Image CastleImg;
    private UIText NameText;
    private UIText TitleText;
    private UIText NoteText;
    private UIText[] AttribText;
    private CString[][] EnhanceStr;
    private UIText[][] EnhanceText;
    private Image[][] EnhanceImg;
    private UISpritesArray StarArray;
    private ushort CastleID;
    private CString[] EffectStr;

    public _CastleHint(Transform transform, Font font)
    {
      this.ThisTransform = transform as RectTransform;
      this.ThisTransObj = ((Component) this.ThisTransform).gameObject;
      this.CastleImg = ((Transform) this.ThisTransform).GetChild(0).GetComponent<Image>();
      if (GUIManager.Instance.IsArabic)
        ((Component) this.CastleImg).gameObject.AddComponent<ArabicItemTextureRot>();
      this.NameText = ((Transform) this.ThisTransform).GetChild(1).GetComponent<UIText>();
      this.NameText.font = font;
      this.TitleText = ((Transform) this.ThisTransform).GetChild(2).GetComponent<UIText>();
      this.TitleText.font = font;
      this.AttribText = new UIText[2];
      this.EffectStr = new CString[2];
      this.EffectStr[0] = StringManager.Instance.SpawnString();
      this.AttribText[0] = ((Transform) this.ThisTransform).GetChild(3).GetComponent<UIText>();
      this.AttribText[0].font = font;
      this.EffectStr[1] = StringManager.Instance.SpawnString();
      this.AttribText[1] = ((Transform) this.ThisTransform).GetChild(6).GetComponent<UIText>();
      this.AttribText[1].font = font;
      this.EnhanceText = new UIText[2][];
      this.EnhanceImg = new Image[2][];
      this.EnhanceStr = new CString[2][];
      for (int index = 0; index < this.EnhanceText.Length; ++index)
      {
        this.EnhanceText[index] = new UIText[5];
        this.EnhanceImg[index] = new Image[5];
        this.EnhanceStr[index] = new CString[5];
      }
      for (byte index = 0; index < (byte) 5; ++index)
      {
        this.EnhanceText[0][(int) index] = ((Transform) this.ThisTransform).GetChild(4).GetChild((int) index).GetChild(0).GetComponent<UIText>();
        this.EnhanceText[0][(int) index].font = font;
        this.EnhanceText[1][(int) index] = ((Transform) this.ThisTransform).GetChild(7).GetChild((int) index).GetChild(0).GetComponent<UIText>();
        this.EnhanceText[1][(int) index].font = font;
        this.EnhanceImg[0][(int) index] = ((Transform) this.ThisTransform).GetChild(4).GetChild((int) index).GetComponent<Image>();
        this.EnhanceImg[1][(int) index] = ((Transform) this.ThisTransform).GetChild(7).GetChild((int) index).GetComponent<Image>();
        this.EnhanceStr[0][(int) index] = StringManager.Instance.SpawnString();
        this.EnhanceStr[1][(int) index] = StringManager.Instance.SpawnString();
      }
      this.NoteText = ((Transform) this.ThisTransform).GetChild(9).GetComponent<UIText>();
      this.NoteText.font = font;
      this.NoteText.text = DataManager.Instance.mStringTable.GetStringByID(14576U);
      this.StarArray = ((Transform) this.ThisTransform).GetChild(4).GetChild(0).GetComponent<UISpritesArray>();
      this.CastleID = (ushort) 0;
    }

    public void Show(ushort CastleID)
    {
      this.ThisTransObj.SetActive(true);
      if ((int) this.CastleID == (int) CastleID)
        return;
      CastleSkin castleSkin = GUIManager.Instance.BuildingData.castleSkin;
      DataManager instance = DataManager.Instance;
      this.CastleID = CastleID;
      CastleSkinTbl recordByKey1 = castleSkin.CastleSkinTable.GetRecordByKey(CastleID);
      byte level = GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level;
      this.CastleImg.sprite = castleSkin.GetUISprite(recordByKey1.Graphic, level);
      ((MaskableGraphic) this.CastleImg).material = castleSkin.GetUIMaterial(recordByKey1.Graphic, level);
      this.CastleImg.SetNativeSize();
      float num = (float) recordByKey1.PreViewPercentage * (1f / 500f);
      ((Transform) ((Graphic) this.CastleImg).rectTransform).localScale = new Vector3(num, num, num);
      this.NameText.text = instance.mStringTable.GetStringByID((uint) recordByKey1.Name);
      this.TitleText.text = instance.mStringTable.GetStringByID(14562U);
      byte castleEnhance = castleSkin.GetCastleEnhance((byte) CastleID);
      CastleEnhanceTbl castleEnhanceData1 = castleSkin.GetCastleEnhanceData((byte) CastleID, castleEnhance);
      bool flag = false;
      for (int index = 0; index < 2; ++index)
      {
        Effect recordByKey2 = instance.EffectData.GetRecordByKey(recordByKey1.Effect[index]);
        if (recordByKey2.ValueID == (ushort) 4378)
          flag = true;
        this.EffectStr[index].ClearString();
        this.EffectStr[index].StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey2.String_infoID));
        if (flag)
        {
          this.EffectStr[index].DoubleToFormat((double) castleEnhanceData1.Value[index] / 100.0, 2, false);
          this.EffectStr[index].AppendFormat("{0}{1}%");
        }
        else
        {
          this.EffectStr[index].IntToFormat((long) castleEnhanceData1.Value[index]);
          this.EffectStr[index].AppendFormat("{0}{1}");
        }
        this.AttribText[index].text = this.EffectStr[index].ToString();
        this.AttribText[index].SetAllDirty();
        this.AttribText[index].cachedTextGenerator.Invalidate();
      }
      for (byte index = 0; index < (byte) 5; ++index)
      {
        CastleEnhanceTbl castleEnhanceData2 = castleSkin.GetCastleEnhanceData((byte) CastleID, (byte) ((uint) index + 1U));
        this.EnhanceStr[0][(int) index].ClearString();
        if (flag)
        {
          this.EnhanceStr[0][(int) index].FloatToFormat((float) castleEnhanceData2.Value[0] / 100f, 2, false);
          if (GUIManager.Instance.IsArabic)
            this.EnhanceStr[0][(int) index].AppendFormat("%{0}");
          else
            this.EnhanceStr[0][(int) index].AppendFormat("{0}%");
        }
        else
        {
          this.EnhanceStr[0][(int) index].IntToFormat((long) castleEnhanceData2.Value[0]);
          this.EnhanceStr[0][(int) index].AppendFormat("{0}");
        }
        this.EnhanceText[0][(int) index].text = this.EnhanceStr[0][(int) index].ToString();
        this.EnhanceText[0][(int) index].SetAllDirty();
        this.EnhanceText[0][(int) index].cachedTextGenerator.Invalidate();
        this.EnhanceStr[1][(int) index].ClearString();
        if (flag)
        {
          this.EnhanceStr[1][(int) index].FloatToFormat((float) castleEnhanceData2.Value[1] / 100f, 2, false);
          if (GUIManager.Instance.IsArabic)
            this.EnhanceStr[1][(int) index].AppendFormat("%{0}");
          else
            this.EnhanceStr[1][(int) index].AppendFormat("{0}%");
        }
        else
        {
          this.EnhanceStr[1][(int) index].IntToFormat((long) castleEnhanceData2.Value[1]);
          this.EnhanceStr[1][(int) index].AppendFormat("{0}");
        }
        this.EnhanceText[1][(int) index].text = this.EnhanceStr[1][(int) index].ToString();
        this.EnhanceText[1][(int) index].SetAllDirty();
        this.EnhanceText[1][(int) index].cachedTextGenerator.Invalidate();
        if ((int) index < (int) castleEnhance)
        {
          this.EnhanceImg[0][(int) index].sprite = this.StarArray.GetSprite(1);
          this.EnhanceImg[1][(int) index].sprite = this.StarArray.GetSprite(1);
          ((Graphic) this.EnhanceText[0][(int) index]).color = Color.white;
          ((Graphic) this.EnhanceText[1][(int) index]).color = Color.white;
        }
        else
        {
          this.EnhanceImg[0][(int) index].sprite = this.StarArray.GetSprite(0);
          this.EnhanceImg[1][(int) index].sprite = this.StarArray.GetSprite(0);
          ((Graphic) this.EnhanceText[0][(int) index]).color = new Color(0.6275f, 0.6275f, 0.6275f);
          ((Graphic) this.EnhanceText[1][(int) index]).color = new Color(0.6275f, 0.6275f, 0.6275f);
        }
      }
    }

    public void Hide() => this.ThisTransObj.SetActive(false);

    public void TextRefresh()
    {
      ((Behaviour) this.NameText).enabled = false;
      ((Behaviour) this.NameText).enabled = true;
      ((Behaviour) this.TitleText).enabled = false;
      ((Behaviour) this.TitleText).enabled = true;
      ((Behaviour) this.NoteText).enabled = false;
      ((Behaviour) this.NoteText).enabled = true;
      for (int index = 0; index < this.AttribText.Length; ++index)
      {
        ((Behaviour) this.AttribText[index]).enabled = false;
        ((Behaviour) this.AttribText[index]).enabled = true;
      }
      for (byte index = 0; index < (byte) 5; ++index)
      {
        ((Behaviour) this.EnhanceText[0][(int) index]).enabled = false;
        ((Behaviour) this.EnhanceText[0][(int) index]).enabled = true;
        ((Behaviour) this.EnhanceText[1][(int) index]).enabled = false;
        ((Behaviour) this.EnhanceText[1][(int) index]).enabled = true;
      }
    }

    public void Destroy()
    {
      for (byte index = 0; index < (byte) 5; ++index)
      {
        StringManager.Instance.DeSpawnString(this.EnhanceStr[0][(int) index]);
        StringManager.Instance.DeSpawnString(this.EnhanceStr[1][(int) index]);
      }
    }

    public void Update() => this.CastleID = (ushort) 0;

    private enum UIControl
    {
      CastleImg,
      Name,
      Title,
      Effect1,
      Enhance1,
      Line,
      Effect2,
      Enhance2,
      Line2,
      Note,
    }
  }

  private class _CastleItem
  {
    private RectTransform[] StarRect;
    private Image[] StarImg;
    private Image MainImg;
    private Image AddImg;
    private Image SelectImg;
    private GameObject NoticeObj;
    private GameObject StarLayerObj;
    public GameObject gameobject;
    private UISpritesArray StarArray;
    public byte CastleID;

    public _CastleItem(Transform transform, UISpritesArray starArray)
    {
      this.gameobject = transform.gameObject;
      this.StarArray = starArray;
      this.StarRect = new RectTransform[5];
      this.StarImg = new Image[5];
      this.SelectImg = transform.GetChild(0).GetComponent<Image>();
      this.StarLayerObj = transform.GetChild(2).gameObject;
      for (byte index = 0; index < (byte) 5; ++index)
      {
        this.StarRect[(int) index] = transform.GetChild(2).GetChild((int) index).GetComponent<RectTransform>();
        this.StarImg[(int) index] = ((Component) this.StarRect[(int) index]).GetComponent<Image>();
      }
      this.MainImg = transform.GetChild(1).GetComponent<Image>();
      this.AddImg = transform.GetChild(3).GetComponent<Image>();
      this.NoticeObj = transform.GetChild(4).gameObject;
    }

    public void SetData(byte CastleID)
    {
      this.CastleID = CastleID;
      CastleSkin castleSkin = GUIManager.Instance.BuildingData.castleSkin;
      CastleSkinTbl recordByKey = castleSkin.CastleSkinTable.GetRecordByKey((ushort) CastleID);
      byte level = GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level;
      this.MainImg.sprite = castleSkin.GetUISprite(recordByKey.Graphic, level);
      ((MaskableGraphic) this.MainImg).material = castleSkin.GetUIMaterial(recordByKey.Graphic, level);
      this.MainImg.SetNativeSize();
      float num = (float) ((double) recordByKey.UnlockPercentage * 0.0099999997764825821 * 0.30000001192092896);
      ((Transform) ((Graphic) this.MainImg).rectTransform).localScale = new Vector3(num, num, num);
      this.SetStar(castleSkin.GetCastleEnhance(CastleID));
      if ((int) GUIManager.Instance.BuildingData.CastleID == (int) CastleID)
      {
        this.AddImg.sprite = this.StarArray.GetSprite(3);
        ((Behaviour) this.AddImg).enabled = true;
      }
      else if (!castleSkin.CheckUnlock(CastleID))
      {
        this.AddImg.sprite = this.StarArray.GetSprite(2);
        ((Behaviour) this.AddImg).enabled = true;
      }
      else
        ((Behaviour) this.AddImg).enabled = false;
      this.NoticeObj.SetActive(!castleSkin.CheckSelect(CastleID));
      ((Graphic) this.SelectImg).color = new Color(1f, 1f, 1f, 0.0f);
    }

    public void SetSelect(bool select)
    {
      if (select)
      {
        ((Graphic) this.SelectImg).color = Color.white;
        GUIManager.Instance.BuildingData.castleSkin.SetSelect(this.CastleID);
        this.NoticeObj.SetActive(false);
      }
      else
        ((Graphic) this.SelectImg).color = new Color(1f, 1f, 1f, 0.0f);
    }

    public void UpdateSelf() => this.SetData(this.CastleID);

    private void SetStar(byte rank)
    {
      if (rank == (byte) 0)
      {
        this.StarLayerObj.SetActive(false);
      }
      else
      {
        for (int index = (int) rank; index < 5; ++index)
          ((Behaviour) this.StarImg[index]).enabled = false;
        switch (rank)
        {
          case 1:
            ((Behaviour) this.StarImg[0]).enabled = true;
            this.StarRect[0].anchoredPosition = new Vector2(0.0f, this.StarRect[0].anchoredPosition.y);
            break;
          case 2:
            ((Behaviour) this.StarImg[0]).enabled = true;
            this.StarRect[0].anchoredPosition = new Vector2(-12f, this.StarRect[0].anchoredPosition.y);
            ((Behaviour) this.StarImg[1]).enabled = true;
            this.StarRect[1].anchoredPosition = new Vector2(12f, this.StarRect[0].anchoredPosition.y);
            break;
          case 3:
            ((Behaviour) this.StarImg[0]).enabled = true;
            this.StarRect[0].anchoredPosition = new Vector2(-24f, this.StarRect[0].anchoredPosition.y);
            ((Behaviour) this.StarImg[1]).enabled = true;
            this.StarRect[1].anchoredPosition = new Vector2(0.0f, this.StarRect[0].anchoredPosition.y);
            ((Behaviour) this.StarImg[2]).enabled = true;
            this.StarRect[2].anchoredPosition = new Vector2(24f, this.StarRect[0].anchoredPosition.y);
            break;
          case 4:
            ((Behaviour) this.StarImg[0]).enabled = true;
            this.StarRect[0].anchoredPosition = new Vector2(-36f, this.StarRect[0].anchoredPosition.y);
            ((Behaviour) this.StarImg[1]).enabled = true;
            this.StarRect[1].anchoredPosition = new Vector2(-12f, this.StarRect[0].anchoredPosition.y);
            ((Behaviour) this.StarImg[2]).enabled = true;
            this.StarRect[2].anchoredPosition = new Vector2(12f, this.StarRect[0].anchoredPosition.y);
            ((Behaviour) this.StarImg[3]).enabled = true;
            this.StarRect[3].anchoredPosition = new Vector2(36f, this.StarRect[0].anchoredPosition.y);
            break;
          case 5:
            ((Behaviour) this.StarImg[0]).enabled = true;
            this.StarRect[0].anchoredPosition = new Vector2(-48f, this.StarRect[0].anchoredPosition.y);
            ((Behaviour) this.StarImg[1]).enabled = true;
            this.StarRect[1].anchoredPosition = new Vector2(-24f, this.StarRect[0].anchoredPosition.y);
            ((Behaviour) this.StarImg[2]).enabled = true;
            this.StarRect[2].anchoredPosition = new Vector2(0.0f, this.StarRect[0].anchoredPosition.y);
            ((Behaviour) this.StarImg[3]).enabled = true;
            this.StarRect[3].anchoredPosition = new Vector2(24f, this.StarRect[0].anchoredPosition.y);
            ((Behaviour) this.StarImg[4]).enabled = true;
            this.StarRect[4].anchoredPosition = new Vector2(48f, this.StarRect[0].anchoredPosition.y);
            break;
        }
        this.StarLayerObj.SetActive(true);
      }
    }
  }
}
