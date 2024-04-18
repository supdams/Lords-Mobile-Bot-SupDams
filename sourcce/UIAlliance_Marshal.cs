// Decompiled with JetBrains decompiler
// Type: UIAlliance_Marshal
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIAlliance_Marshal : IUpDateScrollPanel, IUIButtonClickHandler
{
  private List<float> ItemsHeight = new List<float>();
  private List<WarlobbyData> SortData = new List<WarlobbyData>();
  private GameObject ScrollContent;
  private GameObject GuideObject;
  private ScrollPanel WarScrollView;
  private ushort ItemCount;
  private RectTransform Content;
  private Transform RotationImg;
  private Transform MessageRect;
  private UIText MessageText;
  private byte ShowGuide;
  private UIText[] TagText = new UIText[2];
  private Color[] TagTextColor = new Color[2];
  private CanvasGroup[] TagAlpha = new CanvasGroup[2];
  private Image[] CampsBkImg = new Image[2];
  private Sprite[] TitleSprite = new Sprite[2];
  private UIText[] CampsTitle = new UIText[2];
  private CanvasGroup ActiveTagAlpha;
  private float TagTimer;
  private UIAlliance_Marshal.WarhallComp WarComparer = new UIAlliance_Marshal.WarhallComp();
  private Transform ThisTransform;
  private byte DelayInit = 1;
  private UIAlliance_Marshal.MarshalList[] ItemEdit;
  private UIAlliance_Marshal.ClickType CurrentTag;
  private UIAlliance_Marshal._TagControl[] TagInfo = new UIAlliance_Marshal._TagControl[2];
  private float RotTime;
  private float MaxRotTime = 4f;

  public void OnOpen(Transform transform)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    Font ttfFont = instance2.GetTTFFont();
    this.ThisTransform = transform;
    instance2.UpdateUI(EGUIWindow.Door, 1, 2);
    this.CampsTitle[0] = this.ThisTransform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.CampsTitle[0].font = ttfFont;
    this.CampsTitle[1] = this.ThisTransform.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
    this.CampsTitle[1].font = ttfFont;
    UIButton component1 = this.ThisTransform.GetChild(1).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 0;
    UIButton component2 = this.ThisTransform.GetChild(2).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 1;
    this.TagText[0] = this.ThisTransform.GetChild(1).GetChild(1).GetComponent<UIText>();
    this.TagText[0].font = ttfFont;
    this.TagText[0].text = instance1.mStringTable.GetStringByID(4868U);
    this.TagTextColor[0] = ((Graphic) this.TagText[0]).color;
    this.TagText[1] = this.ThisTransform.GetChild(2).GetChild(1).GetComponent<UIText>();
    this.TagText[1].font = ttfFont;
    this.TagText[1].text = instance1.mStringTable.GetStringByID(4869U);
    this.TagTextColor[1] = ((Graphic) this.TagText[1]).color;
    this.MessageRect = (Transform) this.ThisTransform.GetChild(3).GetComponent<RectTransform>();
    this.MessageText = this.ThisTransform.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.MessageText.font = ttfFont;
    this.CampsBkImg[0] = this.ThisTransform.GetChild(0).GetChild(1).GetComponent<Image>();
    this.CampsBkImg[1] = this.ThisTransform.GetChild(0).GetChild(2).GetComponent<Image>();
    this.TitleSprite[0] = this.CampsBkImg[0].sprite;
    this.TitleSprite[1] = this.CampsBkImg[1].sprite;
    this.TagAlpha[0] = this.ThisTransform.GetChild(1).GetChild(0).GetComponent<CanvasGroup>();
    this.TagAlpha[1] = this.ThisTransform.GetChild(2).GetChild(0).GetComponent<CanvasGroup>();
    this.RotationImg = this.ThisTransform.GetChild(7);
    Transform child = this.ThisTransform.GetChild(5);
    child.GetChild(0).GetChild(2).GetComponent<UIText>().font = ttfFont;
    child.GetChild(1).GetChild(2).GetComponent<UIText>().font = ttfFont;
    child.GetChild(0).GetChild(3).GetComponent<UIText>().font = ttfFont;
    child.GetChild(1).GetChild(3).GetComponent<UIText>().font = ttfFont;
    UIText component3 = child.GetChild(0).GetChild(5).GetComponent<UIText>();
    component3.font = ttfFont;
    component3.resizeTextForBestFit = true;
    component3.resizeTextMaxSize = 18;
    ((Graphic) component3).rectTransform.sizeDelta = new Vector2(210f, 32f);
    UIText component4 = child.GetChild(1).GetChild(5).GetComponent<UIText>();
    component4.font = ttfFont;
    component4.resizeTextForBestFit = true;
    component4.resizeTextMaxSize = 18;
    child.GetChild(2).GetChild(3).GetComponent<UIText>().font = ttfFont;
    child.GetChild(2).GetChild(4).GetComponent<UIText>().font = ttfFont;
    this.TagInfo[0].Tip = this.ThisTransform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
    this.TagInfo[0].TagImage = this.ThisTransform.GetChild(1).GetChild(2).GetComponent<Image>();
    this.TagInfo[0].NumText = ((Transform) this.TagInfo[0].Tip).GetChild(0).GetComponent<UIText>();
    this.TagInfo[0].NumText.font = ttfFont;
    this.TagInfo[0].Init();
    this.TagInfo[1].Tip = this.ThisTransform.GetChild(2).GetChild(2).GetComponent<RectTransform>();
    this.TagInfo[1].TagImage = this.ThisTransform.GetChild(2).GetChild(2).GetComponent<Image>();
    this.TagInfo[1].NumText = ((Transform) this.TagInfo[1].Tip).GetChild(0).GetComponent<UIText>();
    this.TagInfo[1].NumText.font = ttfFont;
    this.TagInfo[1].Init();
    this.ScrollContent = this.ThisTransform.GetChild(4).gameObject;
    if (instance1.UserLanguage == GameLanguage.GL_Chs)
      this.ThisTransform.GetChild(8).GetComponent<UISpritesArray>().SetSpriteIndex(0);
    if (instance2.IsArabic)
      this.ThisTransform.GetChild(8).localScale = new Vector3(-1f, 1f, 1f);
    this.GuideObject = this.ThisTransform.GetChild(6).gameObject;
    if (byte.TryParse(PlayerPrefs.GetString("Marshal_Guide"), out this.ShowGuide))
      return;
    this.ShowGuide = (byte) 1;
    PlayerPrefs.SetString("Marshal_Guide", this.ShowGuide.ToString());
  }

  public void Init()
  {
    GUIManager instance = GUIManager.Instance;
    uTweenScale uTweenScale = this.GuideObject.transform.GetChild(0).gameObject.AddComponent<uTweenScale>();
    uTweenScale.easeType = EaseType.linear;
    uTweenScale.loopStyle = LoopStyle.Loop;
    uTweenScale.delay = 0.2f;
    uTweenScale.from = Vector3.one;
    uTweenScale.to = new Vector3(3f, 3f, 3f);
    uTweenAlpha uTweenAlpha = this.GuideObject.transform.GetChild(0).gameObject.AddComponent<uTweenAlpha>();
    uTweenAlpha.easeType = EaseType.linear;
    uTweenAlpha.loopStyle = LoopStyle.Loop;
    uTweenAlpha.delay = 0.2f;
    uTweenAlpha.from = 1f;
    uTweenAlpha.to = 0.0f;
    uTweenAlpha.mMaskableGraphic = (MaskableGraphic) this.GuideObject.transform.GetChild(0).GetComponent<Image>();
    uTweenPosition uTweenPosition = this.GuideObject.transform.GetChild(1).gameObject.AddComponent<uTweenPosition>();
    uTweenPosition.easeType = EaseType.easeOutQuad;
    uTweenPosition.loopStyle = LoopStyle.PingPong;
    uTweenPosition.duration = 0.5f;
    uTweenPosition.from = new Vector3(224f, 17.8f, 0.0f);
    uTweenPosition.to = new Vector3(241f, 0.8f, 0.0f);
    Transform child = this.ThisTransform.GetChild(5);
    instance.InitianHeroItemImg(child.GetChild(0).GetChild(1).GetChild(0), eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false, bClickSound: false);
    instance.InitianHeroItemImg(child.GetChild(1).GetChild(1).GetChild(0), eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false, bClickSound: false);
    this.ItemCount = (ushort) 5;
    this.ItemEdit = new UIAlliance_Marshal.MarshalList[(int) this.ItemCount];
    this.WarScrollView = this.ThisTransform.GetChild(4).GetChild(0).GetComponent<ScrollPanel>();
    for (byte index = 0; (int) index < (int) this.ItemCount; ++index)
      this.ItemsHeight.Add(128f);
    this.WarScrollView.IntiScrollPanel(435f, 0.0f, 3f, this.ItemsHeight, (int) this.ItemCount, (IUpDateScrollPanel) this);
    this.Content = this.ThisTransform.GetChild(4).GetChild(0).GetChild(0).GetComponent<RectTransform>();
    DataManager.Instance.CheckWalHall_List();
    if (instance.MarshalSaved == (byte) 0)
      this.ChangeTag(this.CurrentTag, true);
    else
      this.ChangeTag((UIAlliance_Marshal.ClickType) ((int) instance.MarshalSaved - 1), true);
  }

  private void ChangeTag(UIAlliance_Marshal.ClickType tag, bool bForceUpdate = false)
  {
    if (!bForceUpdate && tag == this.CurrentTag)
      return;
    DataManager instance = DataManager.Instance;
    int currentTag = (int) this.CurrentTag;
    this.CurrentTag = tag;
    ((Graphic) this.TagText[currentTag]).color = this.TagTextColor[currentTag];
    this.TagAlpha[currentTag].alpha = 0.0f;
    this.ActiveTagAlpha = this.TagAlpha[(int) this.CurrentTag];
    ((Graphic) this.TagText[(int) this.CurrentTag]).color = Color.white;
    List<WarlobbyData> warlobbyDataList = instance.WarHall[(int) (byte) this.CurrentTag];
    if (warlobbyDataList != null)
    {
      this.ItemCount = (ushort) warlobbyDataList.Count;
      if (this.ShowGuide == (byte) 1 && this.ItemCount > (ushort) 0)
        this.GuideObject.SetActive(true);
      else
        this.GuideObject.SetActive(false);
    }
    else
    {
      this.ItemCount = (ushort) 0;
      if (this.ShowGuide == (byte) 1)
        this.GuideObject.SetActive(false);
    }
    if (this.CurrentTag == UIAlliance_Marshal.ClickType.AttackTag)
    {
      this.CampsTitle[0].text = instance.mStringTable.GetStringByID(4870U);
      this.CampsTitle[1].text = instance.mStringTable.GetStringByID(4871U);
      this.MessageText.text = instance.mStringTable.GetStringByID(5782U);
      this.CampsBkImg[0].sprite = this.TitleSprite[1];
      this.CampsBkImg[1].sprite = this.TitleSprite[0];
    }
    else
    {
      this.CampsTitle[0].text = instance.mStringTable.GetStringByID(5760U);
      this.CampsTitle[1].text = instance.mStringTable.GetStringByID(5761U);
      this.MessageText.text = instance.mStringTable.GetStringByID(5783U);
      this.CampsBkImg[0].sprite = this.TitleSprite[0];
      this.CampsBkImg[1].sprite = this.TitleSprite[1];
    }
    for (int index = 0; index < this.ItemEdit.Length; ++index)
      this.ItemEdit[index].SetType(this.CurrentTag);
    if (this.ItemCount > (ushort) 0)
    {
      this.ScrollContent.SetActive(true);
      this.MessageRect.gameObject.SetActive(false);
    }
    else
    {
      this.ScrollContent.SetActive(false);
      this.MessageRect.gameObject.SetActive(true);
    }
    int num = this.ItemsHeight.Count - (int) this.ItemCount;
    if (num < 0)
    {
      for (short index = 0; (int) index > num; --index)
        this.ItemsHeight.Add(128f);
    }
    else if (num > 0)
    {
      for (byte index = 0; (int) index < num; ++index)
        this.ItemsHeight.RemoveAt(0);
    }
    if (this.ItemsHeight.Count > 0)
    {
      this.SortItemData();
      this.WarScrollView.AddNewDataHeight(this.ItemsHeight);
      this.MessageRect.gameObject.SetActive(false);
      this.ScrollContent.SetActive(true);
    }
    else
    {
      this.MessageRect.gameObject.SetActive(true);
      this.ScrollContent.SetActive(false);
    }
    this.TagInfo[0].SetNum((byte) instance.ActiveRallyRecNum);
    this.TagInfo[1].SetNum((byte) instance.BeingRallyRecNum);
  }

  public void SortItemData()
  {
    List<WarlobbyData> collection = DataManager.Instance.WarHall[(int) (byte) this.CurrentTag];
    if (collection == null)
      return;
    for (int index = 0; index < collection.Count; ++index)
      collection[index].DataIndex = index;
    this.SortData.Clear();
    this.SortData.AddRange((IEnumerable<WarlobbyData>) collection);
    this.SortData.Sort((IComparer<WarlobbyData>) this.WarComparer);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (this.DelayInit > (byte) 0)
      return;
    this.ChangeTag((UIAlliance_Marshal.ClickType) sender.m_BtnID1);
  }

  public void OnClose()
  {
    if (this.DelayInit == (byte) 0)
      GUIManager.Instance.MarshalSaved = (byte) (this.CurrentTag + 1);
    if (this.ItemEdit != null)
    {
      for (int index = 0; index < this.ItemEdit.Length; ++index)
        this.ItemEdit[index].OnClose();
    }
    for (int index = 0; index < this.TagInfo.Length; ++index)
      this.TagInfo[index].Destroy();
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((Object) menu != (Object) null) || menu.m_WindowStack.Count <= 0)
      return;
    GUIWindowStackData mWindow = menu.m_WindowStack[menu.m_WindowStack.Count - 1] with
    {
      m_Arg1 = 0
    };
    menu.m_WindowStack[menu.m_WindowStack.Count - 1] = mWindow;
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (this.ItemEdit[panelObjectIdx] == null)
      this.ItemEdit[panelObjectIdx] = new UIAlliance_Marshal.MarshalList(item.transform, this.SortData);
    else
      this.ItemEdit[panelObjectIdx].SetData(dataIdx, this.CurrentTag);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    int num1 = 0;
    if (this.ShowGuide == (byte) 1)
      PlayerPrefs.SetString("Marshal_Guide", "0");
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
    if (this.SortData[dataIndex].AllyNameID == DataManager.Instance.RoleAttr.Name.GetHashCode(false))
      num1 |= 32768;
    int num2 = num1 | this.SortData[dataIndex].DataIndex;
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_Rally, (int) this.CurrentTag, num2);
  }

  public void Update()
  {
    if (this.DelayInit > (byte) 0)
    {
      --this.DelayInit;
      if (this.DelayInit != (byte) 0)
        return;
      this.Init();
    }
    else
    {
      for (int index = 0; index < this.ItemEdit.Length; ++index)
        this.ItemEdit[index].Update();
      Quaternion rotation = this.RotationImg.rotation;
      Vector3 eulerAngles = this.RotationImg.rotation.eulerAngles;
      float num = this.RotTime / this.MaxRotTime;
      eulerAngles.z = (double) num > 1.0 ? (this.RotTime = 0.0f) : 360f * num;
      this.RotTime += Time.deltaTime;
      rotation.eulerAngles = eulerAngles;
      this.RotationImg.rotation = rotation;
      if (!((Object) this.ActiveTagAlpha != (Object) null))
        return;
      this.TagTimer += Time.smoothDeltaTime;
      if ((double) this.TagTimer >= 2.0)
        this.TagTimer = 0.0f;
      this.ActiveTagAlpha.alpha = (double) this.TagTimer <= 1.0 ? this.TagTimer : 2f - this.TagTimer;
    }
  }

  public void UpdateNetwork(byte[] meg)
  {
    if (meg[0] == (byte) 0)
    {
      DataManager.Instance.CheckWalHall_List();
    }
    else
    {
      if (meg[0] != (byte) 35)
        return;
      if ((Object) this.MessageText != (Object) null)
      {
        ((Behaviour) this.MessageText).enabled = false;
        ((Behaviour) this.MessageText).enabled = true;
      }
      for (int index = 0; index < this.TagText.Length; ++index)
      {
        if ((Object) this.TagText[index] != (Object) null)
        {
          ((Behaviour) this.TagText[index]).enabled = false;
          ((Behaviour) this.TagText[index]).enabled = true;
        }
        if ((Object) this.CampsTitle[index] != (Object) null)
        {
          ((Behaviour) this.CampsTitle[index]).enabled = false;
          ((Behaviour) this.CampsTitle[index]).enabled = true;
        }
        if ((Object) this.TagInfo[index].NumText != (Object) null)
        {
          ((Behaviour) this.TagInfo[index].NumText).enabled = false;
          ((Behaviour) this.TagInfo[index].NumText).enabled = true;
        }
      }
      if (this.ItemEdit == null)
        return;
      for (int index = 0; index < this.ItemEdit.Length && this.ItemEdit[index] != null; ++index)
        this.ItemEdit[index].TextRefresh();
    }
  }

  public void UpdateUI(int arg1, int arg2)
  {
    if (this.DelayInit > (byte) 0)
    {
      this.Init();
      this.DelayInit = (byte) 0;
    }
    int beginIdx = this.WarScrollView.GetBeginIdx();
    float y = this.Content.anchoredPosition.y;
    this.ChangeTag(this.CurrentTag, true);
    if (!this.WarScrollView.gameObject.activeSelf)
      return;
    this.WarScrollView.GoTo(beginIdx, y);
  }

  private enum UIControl
  {
    Background,
    Tab1,
    Tab2,
    Message,
    ScrollCont,
    Item,
    Guide,
    RingImage,
    Image,
  }

  private enum ItemControl
  {
    Alli1,
    Alli2,
    Bar,
    RallySpeedup,
  }

  private enum AlliControl
  {
    BackImage,
    Hero,
    Country,
    Message,
    Flag,
    Total,
  }

  public enum ClickType
  {
    AttackTag,
    DefenceTag,
  }

  private struct _TagControl
  {
    public Image TagImage;
    public CString NumStr;
    public UIText NumText;
    public RectTransform Tip;

    public void Init() => this.NumStr = StringManager.Instance.SpawnString();

    public void SetNum(byte Num)
    {
      if (Num == (byte) 0)
      {
        ((Component) this.Tip).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.Tip).gameObject.SetActive(true);
        this.NumStr.ClearString();
        this.NumStr.IntToFormat((long) Num);
        this.NumStr.AppendFormat("{0}");
        this.NumText.text = this.NumStr.ToString();
        this.NumText.SetAllDirty();
        this.NumText.cachedTextGenerator.Invalidate();
        this.Tip.sizeDelta = this.Tip.sizeDelta with
        {
          x = this.NumText.preferredWidth + 47f
        };
      }
    }

    public void Destroy() => StringManager.Instance.DeSpawnString(this.NumStr);
  }

  private class WarhallComp : IComparer<WarlobbyData>
  {
    public int Compare(WarlobbyData a, WarlobbyData b)
    {
      long num1 = a.EventTime.BeginTime + (long) a.EventTime.RequireTime;
      long num2 = b.EventTime.BeginTime + (long) b.EventTime.RequireTime;
      if (num1 < num2)
        return -1;
      return num1 > num2 ? 1 : 0;
    }
  }

  private class MarshalList : IUIStateTransition, IUIButtonClickHandler, IUIHIBtnClickHandler
  {
    private const float BarMaxWidth = 21f;
    private Sprite[] BsckSprite = new Sprite[2];
    private ScrollPanelItem scrollItem;
    public UIAlliance_Marshal.MarshalList.Camps[] CampsData = new UIAlliance_Marshal.MarshalList.Camps[2];
    private UIAlliance_Marshal.ClickType CurrentType;
    private RallyTimeBar TimeBar;
    private UIButton SpeedupBtn;
    private List<WarlobbyData> SortData;
    private int DataIndex;

    public MarshalList(Transform Item, List<WarlobbyData> SortData)
    {
      this.SortData = SortData;
      this.CampsData[0].Init(Item.GetChild(0));
      this.CampsData[1].Init(Item.GetChild(1));
      this.CampsData[0].HeroBtn.m_Handler = (IUIHIBtnClickHandler) this;
      this.CampsData[1].HeroBtn.m_Handler = (IUIHIBtnClickHandler) this;
      this.BsckSprite[0] = this.CampsData[0].BackImg.sprite;
      this.BsckSprite[1] = this.CampsData[1].BackImg.sprite;
      this.scrollItem = Item.GetComponent<ScrollPanelItem>();
      this.scrollItem.m_StateTransitionHandler = (IUIStateTransition) this;
      this.TimeBar = new RallyTimeBar(Item.GetChild(2).GetComponent<UITimeBar>());
      this.SpeedupBtn = Item.GetChild(3).GetComponent<UIButton>();
      this.SpeedupBtn.m_Handler = (IUIButtonClickHandler) this;
      if (!GUIManager.Instance.IsArabic)
        return;
      ((Component) this.SpeedupBtn).transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    void IUIButtonClickHandler.OnButtonClick(UIButton sender)
    {
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BagFilter, 2, 201 + this.DataIndex);
    }

    public void SetData(int DataIndex, UIAlliance_Marshal.ClickType type)
    {
      DataManager instance = DataManager.Instance;
      ushort kingdomId = DataManager.MapDataController.kingdomData.kingdomID;
      WarlobbyData warlobbyData;
      if (type == UIAlliance_Marshal.ClickType.AttackTag)
      {
        if (instance.WarHall[0] == null || instance.WarHall[0].Count <= DataIndex)
          return;
        warlobbyData = this.SortData[DataIndex];
        this.DataIndex = warlobbyData.DataIndex;
        GUIManager.Instance.ChangeHeroItemImg(this.CampsData[0].HeroIcon, eHeroOrItem.Hero, warlobbyData.AllyHead, (byte) 11, (byte) 0);
        this.CampsData[0].CampsText.text = warlobbyData.AllyName.ToString();
        this.CampsData[0].CampsText.SetAllDirty();
        this.CampsData[0].CampsText.cachedTextGenerator.Invalidate();
        this.CampsData[0].SetForce(warlobbyData.AllyCurrTroop, warlobbyData.AllyMAXTroop);
        if (warlobbyData.WonderID != byte.MaxValue)
        {
          if (ActivityManager.Instance.IsInKvK((ushort) 0) && warlobbyData.EnemyHomeKingdom == (ushort) 0)
            warlobbyData.EnemyHomeKingdom = DataManager.MapDataController.OtherKingdomData.kingdomID;
          if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) ActivityManager.Instance.KOWKingdomID)
            GUIManager.Instance.ChangeWonderImg(this.CampsData[1].HeroIcon, warlobbyData.WonderID, DataManager.MapDataController.OtherKingdomData.kingdomID);
          else
            GUIManager.Instance.ChangeWonderImg(this.CampsData[1].HeroIcon, warlobbyData.WonderID, warlobbyData.EnemyHomeKingdom);
          this.CampsData[1].Country.SetActive(true);
          if (ActivityManager.Instance.IsInKvK((ushort) 0) && warlobbyData.EnemyHomeKingdom == (ushort) 0)
            warlobbyData.EnemyHomeKingdom = DataManager.MapDataController.OtherKingdomData.kingdomID;
          this.CampsData[1].SetWonderName((ushort) warlobbyData.WonderID, warlobbyData.EnemyHomeKingdom);
          this.CampsData[1].SetName(warlobbyData.EnemyName, warlobbyData.EnemyAllianceTag, warlobbyData.EnemyHomeKingdom);
          this.CampsData[1].HeroBtn.m_BtnID1 = (int) DataManager.MapDataController.GetYolkMapID((ushort) warlobbyData.WonderID, (ushort) 0);
          this.CampsData[1].HeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
        }
        else
        {
          if (warlobbyData.EnemyHead != (ushort) byte.MaxValue)
          {
            GUIManager.Instance.ChangeHeroItemImg(this.CampsData[1].HeroIcon, eHeroOrItem.Hero, warlobbyData.EnemyHead, (byte) 11, (byte) 0);
            this.CampsData[1].SetName(warlobbyData.EnemyName, warlobbyData.EnemyAllianceTag, warlobbyData.EnemyHomeKingdom);
          }
          else
          {
            GUIManager.Instance.ChangeNPCImg(this.CampsData[1].HeroIcon);
            this.CampsData[1].SetNpcName(warlobbyData.EnemyName);
          }
          if (warlobbyData.EnemyHomeKingdom == (ushort) 0 || (int) kingdomId == (int) warlobbyData.EnemyHomeKingdom)
          {
            this.CampsData[1].Country.SetActive(false);
          }
          else
          {
            this.CampsData[1].Country.SetActive(true);
            this.CampsData[1].SetKingdom(warlobbyData.EnemyHomeKingdom);
          }
          this.CampsData[1].HeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(warlobbyData.EnemyCapitalPoint.zoneID, warlobbyData.EnemyCapitalPoint.pointID);
          this.CampsData[1].HeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
        }
        this.CampsData[0].HeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(warlobbyData.AllyCapitalPoint.zoneID, warlobbyData.AllyCapitalPoint.pointID);
        this.CampsData[0].HeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
        this.CampsData[0].BackImg.sprite = this.BsckSprite[1];
        this.CampsData[1].BackImg.sprite = this.BsckSprite[0];
      }
      else
      {
        if (instance.WarHall[1] == null || instance.WarHall[1].Count <= DataIndex)
          return;
        warlobbyData = this.SortData[DataIndex];
        if (warlobbyData.WonderID != byte.MaxValue)
        {
          if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) ActivityManager.Instance.KOWKingdomID)
            GUIManager.Instance.ChangeWonderImg(this.CampsData[1].HeroIcon, warlobbyData.WonderID, DataManager.MapDataController.OtherKingdomData.kingdomID);
          else
            GUIManager.Instance.ChangeWonderImg(this.CampsData[1].HeroIcon, warlobbyData.WonderID, warlobbyData.AllyHomeKingdom);
          this.CampsData[1].Country.SetActive(true);
          if (ActivityManager.Instance.IsInKvK((ushort) 0) && warlobbyData.EnemyHomeKingdom == (ushort) 0)
            warlobbyData.EnemyHomeKingdom = DataManager.MapDataController.OtherKingdomData.kingdomID;
          this.CampsData[1].SetWonderName((ushort) warlobbyData.WonderID, (ushort) 0);
          this.CampsData[1].SetName(instance.RoleAlliance.Name, instance.RoleAlliance.Tag, (ushort) 0);
          this.CampsData[1].SetForce(warlobbyData.AllyCurrTroop, warlobbyData.AllyMAXTroop);
          this.CampsData[1].HeroBtn.m_BtnID1 = (int) DataManager.MapDataController.GetYolkMapID((ushort) warlobbyData.WonderID, (ushort) 0);
          this.CampsData[1].HeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
        }
        else
        {
          GUIManager.Instance.ChangeHeroItemImg(this.CampsData[1].HeroIcon, eHeroOrItem.Hero, warlobbyData.AllyHead, (byte) 11, (byte) 0);
          this.CampsData[1].CampsText.text = warlobbyData.AllyName.ToString();
          this.CampsData[1].CampsText.SetAllDirty();
          this.CampsData[1].CampsText.cachedTextGenerator.Invalidate();
          this.CampsData[1].SetForce(warlobbyData.AllyCurrTroop, warlobbyData.AllyMAXTroop);
          this.CampsData[1].HeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(warlobbyData.AllyCapitalPoint.zoneID, warlobbyData.AllyCapitalPoint.pointID);
          this.CampsData[1].HeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
        }
        GUIManager.Instance.ChangeHeroItemImg(this.CampsData[0].HeroIcon, eHeroOrItem.Hero, warlobbyData.EnemyHead, (byte) 11, (byte) 0);
        this.CampsData[0].CampsText.text = warlobbyData.EnemyName.ToString();
        this.CampsData[0].CampsText.SetAllDirty();
        this.CampsData[0].CampsText.cachedTextGenerator.Invalidate();
        this.CampsData[0].SetName(warlobbyData.EnemyName, warlobbyData.EnemyAllianceTag, warlobbyData.EnemyHomeKingdom);
        if (warlobbyData.EnemyHomeKingdom == (ushort) 0 || (int) kingdomId == (int) warlobbyData.EnemyHomeKingdom)
        {
          this.CampsData[0].Country.SetActive(false);
        }
        else
        {
          this.CampsData[0].Country.SetActive(true);
          this.CampsData[0].SetKingdom(warlobbyData.EnemyHomeKingdom);
        }
        this.CampsData[0].HeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(warlobbyData.EnemyCapitalPoint.zoneID, warlobbyData.EnemyCapitalPoint.pointID);
        this.CampsData[0].HeroBtn.m_BtnID2 = (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
        this.CampsData[0].BackImg.sprite = this.BsckSprite[0];
        this.CampsData[1].BackImg.sprite = this.BsckSprite[1];
      }
      this.CampsData[1].Flag.anchoredPosition = this.CampsData[1].Flag.anchoredPosition with
      {
        x = (float) (410.70001220703125 - (double) this.CampsData[1].Total.preferredWidth - 25.0)
      };
      if (warlobbyData == null)
        return;
      if (warlobbyData.EventTime.BeginTime == 0L)
      {
        this.TimeBar.gameObject.SetActive(false);
      }
      else
      {
        this.TimeBar.gameObject.SetActive(true);
        this.TimeBar.SetTimebar(warlobbyData.Kind, warlobbyData.EventTime.BeginTime, warlobbyData.EventTime.BeginTime + (long) warlobbyData.EventTime.RequireTime, 0L);
        if (type == UIAlliance_Marshal.ClickType.AttackTag && warlobbyData.Kind == (byte) 1)
          ((Component) this.SpeedupBtn).gameObject.SetActive(true);
        else
          ((Component) this.SpeedupBtn).gameObject.SetActive(false);
      }
    }

    public void SetType(UIAlliance_Marshal.ClickType Type)
    {
      this.CurrentType = Type;
      if (this.CurrentType == UIAlliance_Marshal.ClickType.AttackTag)
      {
        this.CampsData[0].Country.SetActive(false);
        ((Behaviour) this.CampsData[0].AttackFlag).enabled = true;
        ((Behaviour) this.CampsData[0].DefenseFlag).enabled = false;
        ((Behaviour) this.CampsData[1].AttackFlag).enabled = false;
        ((Behaviour) this.CampsData[1].DefenseFlag).enabled = false;
        this.CampsData[1].Country.SetActive(true);
        this.CampsData[1].Total.text = string.Empty;
      }
      else
      {
        ((Behaviour) this.CampsData[1].AttackFlag).enabled = false;
        ((Behaviour) this.CampsData[1].DefenseFlag).enabled = true;
        this.CampsData[1].Country.SetActive(false);
        ((Behaviour) this.CampsData[0].AttackFlag).enabled = false;
        ((Behaviour) this.CampsData[0].DefenseFlag).enabled = false;
        this.CampsData[0].Country.SetActive(true);
        this.CampsData[0].Total.text = string.Empty;
      }
    }

    public void OnClose()
    {
      this.TimeBar.Destroy();
      for (int index = 0; index < this.CampsData.Length; ++index)
        this.CampsData[index].Destroy();
    }

    public void OnHIButtonClick(UIHIBtn sender)
    {
      AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).GoToMapID((ushort) sender.m_BtnID2, sender.m_BtnID1, (byte) 0, (byte) 1);
    }

    public void OnStateTransition(byte state, bool instant)
    {
      switch (state)
      {
        case 0:
          Image backImg1 = this.CampsData[0].BackImg;
          ColorBlock colors1 = this.scrollItem.colors;
          Color normalColor = ((ColorBlock) ref colors1).normalColor;
          ((Graphic) this.CampsData[1].BackImg).color = normalColor;
          Color color1 = normalColor;
          ((Graphic) backImg1).color = color1;
          break;
        case 1:
          Image backImg2 = this.CampsData[0].BackImg;
          ColorBlock colors2 = this.scrollItem.colors;
          Color highlightedColor = ((ColorBlock) ref colors2).highlightedColor;
          ((Graphic) this.CampsData[1].BackImg).color = highlightedColor;
          Color color2 = highlightedColor;
          ((Graphic) backImg2).color = color2;
          break;
        case 2:
          Image backImg3 = this.CampsData[0].BackImg;
          ColorBlock colors3 = this.scrollItem.colors;
          Color pressedColor = ((ColorBlock) ref colors3).pressedColor;
          ((Graphic) this.CampsData[1].BackImg).color = pressedColor;
          Color color3 = pressedColor;
          ((Graphic) backImg3).color = color3;
          break;
        case 3:
          Image backImg4 = this.CampsData[0].BackImg;
          ColorBlock colors4 = this.scrollItem.colors;
          Color disabledColor = ((ColorBlock) ref colors4).disabledColor;
          ((Graphic) this.CampsData[1].BackImg).color = disabledColor;
          Color color4 = disabledColor;
          ((Graphic) backImg4).color = color4;
          break;
      }
    }

    public void Update() => this.TimeBar.Update();

    public void TextRefresh()
    {
      for (int index = 0; index < this.CampsData.Length; ++index)
        this.CampsData[index].TextRefresh();
      if (this.TimeBar == null)
        return;
      this.TimeBar.TextRefresh();
    }

    public struct Camps
    {
      public RectTransform Flag;
      public Transform HeroIcon;
      public UIHIBtn HeroBtn;
      public Image AttackFlag;
      public Image DefenseFlag;
      public Image BackImg;
      public GameObject Country;
      public UIText CountryText;
      public UIText CampsText;
      public UIText Total;
      public CString TotalStr;
      public CString NameStr;
      public CString CountryStr;
      private Color CountryColor;

      public void Init(Transform CampsTrans)
      {
        this.HeroIcon = CampsTrans.GetChild(1).GetChild(0);
        this.HeroBtn = this.HeroIcon.GetComponent<UIHIBtn>();
        this.Country = CampsTrans.GetChild(2).gameObject;
        this.CountryText = CampsTrans.GetChild(2).GetComponent<UIText>();
        this.CampsText = CampsTrans.GetChild(3).GetComponent<UIText>();
        this.AttackFlag = CampsTrans.GetChild(4).GetComponent<Image>();
        this.DefenseFlag = CampsTrans.GetChild(4).GetChild(0).GetComponent<Image>();
        this.Flag = CampsTrans.GetChild(4).GetComponent<RectTransform>();
        this.Total = CampsTrans.GetChild(5).GetComponent<UIText>();
        this.TotalStr = StringManager.Instance.SpawnString();
        this.NameStr = StringManager.Instance.SpawnString(100);
        this.CountryStr = StringManager.Instance.SpawnString();
        GUIManager.Instance.InitianHeroItemImg(this.HeroIcon, eHeroOrItem.Hero, (ushort) 0, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
        this.BackImg = CampsTrans.GetChild(0).GetComponent<Image>();
        this.CountryColor = ((Graphic) this.CountryText).color;
      }

      public void SetForce(uint CurTroop, uint MaxTroop)
      {
        this.TotalStr.ClearString();
        this.TotalStr.IntToFormat((long) CurTroop, bNumber: true);
        this.TotalStr.IntToFormat((long) MaxTroop, bNumber: true);
        if (GUIManager.Instance.IsArabic)
          this.TotalStr.AppendFormat("{1} / {0}");
        else
          this.TotalStr.AppendFormat("{0} / {1}");
        this.Total.text = this.TotalStr.ToString();
        this.Total.SetAllDirty();
        this.Total.cachedTextGenerator.Invalidate();
        this.Total.cachedTextGeneratorForLayout.Invalidate();
      }

      public void SetName(CString Name, CString Tag, ushort homeKindom)
      {
        bool flag = false;
        if (ActivityManager.Instance.IsInKvK((ushort) 0) && homeKindom > (ushort) 0 && (int) homeKindom != (int) DataManager.MapDataController.kingdomData.kingdomID)
          flag = true;
        this.NameStr.ClearString();
        if (flag)
          GameConstants.FormatRoleName(this.NameStr, Name, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0, NameColor: "<color=#FF878E>", TagColor: "<color=#FF878E>");
        else
          GameConstants.FormatRoleName(this.NameStr, Name, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0, NameColor: "<color=#FFCC00>");
        this.CampsText.text = this.NameStr.ToString();
        this.CampsText.SetAllDirty();
        this.CampsText.cachedTextGenerator.Invalidate();
      }

      public void SetNpcName(CString Name)
      {
        this.NameStr.ClearString();
        this.NameStr.StringToFormat("<color=#FFCC00>");
        this.NameStr.StringToFormat(Name);
        this.NameStr.StringToFormat("</color>");
        this.NameStr.AppendFormat("{0}{1}{2}");
        this.CampsText.text = this.NameStr.ToString();
        this.CampsText.SetAllDirty();
        this.CampsText.cachedTextGenerator.Invalidate();
      }

      public void SetKingdom(ushort kingdomID)
      {
        this.CountryStr.ClearString();
        this.CountryStr.IntToFormat((long) kingdomID);
        if (GUIManager.Instance.IsArabic)
          this.CountryStr.AppendFormat("{0}#");
        else
          this.CountryStr.AppendFormat("#{0}");
        this.CountryText.text = this.CountryStr.ToString();
        this.CountryText.SetAllDirty();
        this.CountryText.cachedTextGenerator.Invalidate();
        ((Graphic) this.CountryText).color = this.CountryColor;
      }

      public void SetWonderName(ushort wonderID, ushort homeKindom)
      {
        bool flag = false;
        if (ActivityManager.Instance.IsInKvK((ushort) 0) && homeKindom > (ushort) 0 && (int) homeKindom != (int) DataManager.MapDataController.kingdomData.kingdomID)
          flag = true;
        this.CountryStr.ClearString();
        this.CountryStr.StringToFormat(DataManager.MapDataController.GetYolkName(wonderID, (ushort) 0));
        if (flag)
          this.CountryStr.AppendFormat("<color=#FF878E>{0}</color>");
        else
          this.CountryStr.AppendFormat("{0}");
        this.CountryText.text = this.CountryStr.ToString();
        this.CountryText.SetAllDirty();
        this.CountryText.cachedTextGenerator.Invalidate();
        ((Graphic) this.CountryText).color = Color.white;
      }

      public void Destroy()
      {
        StringManager.Instance.DeSpawnString(this.TotalStr);
        StringManager.Instance.DeSpawnString(this.NameStr);
        StringManager.Instance.DeSpawnString(this.CountryStr);
      }

      public void TextRefresh()
      {
        if ((Object) this.CountryText != (Object) null)
        {
          ((Behaviour) this.CountryText).enabled = false;
          ((Behaviour) this.CountryText).enabled = true;
        }
        if ((Object) this.CampsText != (Object) null)
        {
          ((Behaviour) this.CampsText).enabled = false;
          ((Behaviour) this.CampsText).enabled = true;
        }
        if (!((Object) this.Total != (Object) null))
          return;
        ((Behaviour) this.Total).enabled = false;
        ((Behaviour) this.Total).enabled = true;
      }
    }
  }
}
