// Decompiled with JetBrains decompiler
// Type: UITechInstitute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UITechInstitute : 
  GUIWindow,
  IBuildingWindowType,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUTimeBarOnTimer
{
  private DataManager DM;
  private GUIManager GUIM;
  private ScrollPanel m_itemView;
  private BuildingWindow baseBuild;
  private UITimeBar timeBar;
  private Transform ThisTransform;
  private RectTransform ScroContent;
  private UISpritesArray SpriteArray;
  private byte ResearchTechKind;
  private List<float> tmplist = new List<float>();
  private int MaxScrollItemCount;
  private ushort KindDataCount;
  private float RotTime;
  private UIText TitleText;
  public UITechInstitute._TechItem[] TechItem;
  private int B_ID;
  private byte PassInit = 2;

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Upgrade)
    {
      this.ThisTransform.gameObject.SetActive(false);
    }
    else
    {
      if (buildType != e_BuildType.Normal)
        return;
      this.ThisTransform.gameObject.SetActive(true);
      this.UpdateTimeBarState();
    }
  }

  private void Start()
  {
    this.baseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    this.baseBuild.InitBuildingWindow((byte) 10, (ushort) this.B_ID, (byte) 2, this.GUIM.BuildingData.AllBuildsData[this.B_ID].Level);
    this.baseBuild.baseTransform.SetAsFirstSibling();
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.ThisTransform = this.transform.GetChild(0);
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.B_ID = arg1;
    Font ttfFont = this.GUIM.GetTTFFont();
    this.TitleText = this.ThisTransform.GetChild(0).GetChild(1).GetComponent<UIText>();
    this.TitleText.font = ttfFont;
    this.TitleText.text = this.DM.mStringTable.GetStringByID(5001U);
    this.timeBar = this.ThisTransform.GetChild(0).GetChild(0).GetComponent<UITimeBar>();
    this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
    this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
    this.timeBar.m_Handler = (IUTimeBarOnTimer) this;
    this.UpdateTimeBarState();
    this.m_itemView = this.ThisTransform.GetChild(2).GetComponent<ScrollPanel>();
    this.SpriteArray = this.ThisTransform.GetChild(2).GetComponent<UISpritesArray>();
    if (this.DM.ResearchTech > (ushort) 0)
      this.ResearchTechKind = this.DM.TechData.GetRecordByKey(this.DM.ResearchTech).Kind;
    this.KindDataCount = (ushort) this.DM.TechKindData.TableCount;
    this.MaxScrollItemCount = (int) this.KindDataCount / 4 + Mathf.Clamp((int) this.KindDataCount & 3, 0, 1);
    for (int index = 0; index < 4; ++index)
    {
      Transform child = this.ThisTransform.GetChild(3).GetChild(index);
      child.GetChild(0).GetComponent<UIText>().font = ttfFont;
      child.GetChild(2).GetChild(1).GetComponent<UIText>().font = ttfFont;
    }
    if (DataManager.StageDataController.StageRecord[2] < (ushort) 8)
      this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    else
      this.GUIM.UpdateUI(EGUIWindow.Door, 1, 4);
    GameConstants.GetBytes((ushort) 0, GUIManager.Instance.TechSaved, 6);
    if (this.DM.GetTechLevel((ushort) 42) != (byte) 0 || GUIManager.Instance.BuildingData.BuildIDCount[10] == (byte) 0 || arg2 == 0)
      return;
    NewbieManager.CheckTeach(ETeachKind.COLLEGE, (object) this, true);
  }

  public void Update()
  {
    if (this.PassInit > (byte) 0)
    {
      --this.PassInit;
      if (this.PassInit != (byte) 0)
        return;
      int _PanelObjectsCount = Mathf.Clamp(this.MaxScrollItemCount, 0, 3);
      this.TechItem = new UITechInstitute._TechItem[_PanelObjectsCount];
      this.m_itemView.IntiScrollPanel(285f, 0.0f, 0.0f, this.tmplist, _PanelObjectsCount, (IUpDateScrollPanel) this);
      for (int index = 0; index < this.MaxScrollItemCount; ++index)
        this.tmplist.Add(227f);
      this.m_itemView.AddNewDataHeight(this.tmplist);
      this.m_itemView.gameObject.SetActive(true);
      this.ScroContent = this.m_itemView.transform.GetChild(0).GetComponent<RectTransform>();
      float num = this.ScroContent.sizeDelta.y - 285f;
      float height = GameConstants.ConvertBytesToFloat(this.GUIM.TechKindSaved, 1);
      if ((double) num < (double) height && this.GUIM.TechKindSaved[0] > (byte) 0)
      {
        --this.GUIM.TechKindSaved[0];
        height = num;
      }
      this.m_itemView.GoTo((int) this.GUIM.TechKindSaved[0], height);
      this.TextRefresh();
    }
    else
    {
      for (int index1 = 0; index1 < this.TechItem.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.TechItem[index1].Research.Length; ++index2)
        {
          if (((Component) this.TechItem[index1].Research[index2]).gameObject.activeSelf)
          {
            if ((double) this.RotTime <= 1.2999999523162842)
            {
              Quaternion localRotation = ((Transform) this.TechItem[index1].Research[index2]).localRotation;
              Vector3 eulerAngles = localRotation.eulerAngles with
              {
                z = (double) this.RotTime > 0.5 ? 180f : EasingEffect.Linear(this.RotTime, 0.0f, 180f, 0.5f)
              };
              localRotation.eulerAngles = eulerAngles;
              ((Transform) this.TechItem[index1].Research[index2]).localRotation = localRotation;
            }
            else if ((double) this.RotTime <= 2.5999999046325684)
            {
              float t = this.RotTime - 1.3f;
              Quaternion localRotation = ((Transform) this.TechItem[index1].Research[index2]).localRotation;
              Vector3 eulerAngles = localRotation.eulerAngles with
              {
                z = (double) t > 0.5 ? 360f : EasingEffect.Linear(t, 180f, 180f, 0.5f)
              };
              localRotation.eulerAngles = eulerAngles;
              ((Transform) this.TechItem[index1].Research[index2]).localRotation = localRotation;
            }
            else
              this.RotTime = 0.0f;
            this.RotTime += Time.smoothDeltaTime;
            return;
          }
        }
      }
    }
  }

  public void UpdateTimeBarState()
  {
    if (this.DM.queueBarData[1].bActive)
    {
      long startTime = this.DM.queueBarData[1].StartTime;
      long target = startTime + (long) this.DM.queueBarData[1].TotalTime;
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      DataManager.Instance.GetQueueBarTitle(EQueueBarIndex.Researching, this.GUIM.tmpString, ref empty1, ref empty2);
      QueueBarData queueBarData = this.DM.queueBarData[1];
      long notifyTime = queueBarData.StartTime + (long) queueBarData.TotalTime - (long) this.DM.GetFreeCompleteTime();
      if (this.DM.RoleAlliance.Id != 0U && this.DM.mPlayHelpDataType[0].Kind == (byte) 0)
        this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Help);
      this.GUIM.SetTimerBar(this.timeBar, startTime, target, notifyTime, eTimeBarType.CancelType, empty1, empty2);
      this.timeBar.gameObject.SetActive(true);
    }
    else
      this.timeBar.gameObject.SetActive(false);
  }

  public void OnButtonClick(UIButton sender)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((Object) menu != (Object) null))
      return;
    menu.OpenMenu(EGUIWindow.UI_TechTree, sender.m_BtnID1, sender.m_BtnID2);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    Transform transform = item.transform;
    if (this.TechItem[panelObjectIdx].TechImg == null)
      this.TechItem[panelObjectIdx].Init();
    this.TechItem[panelObjectIdx].dataIndex = dataIdx;
    this.TechItem[panelObjectIdx].transform = transform;
    for (byte index1 = 0; (int) index1 < this.TechItem[panelObjectIdx].KindName.Length; ++index1)
    {
      uint index2 = (uint) (dataIdx * 4) + (uint) index1;
      if ((Object) this.TechItem[panelObjectIdx].TechImg[(int) index1] == (Object) null)
      {
        transform.GetChild((int) index1).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.TechItem[panelObjectIdx].TechImg[(int) index1] = transform.GetChild((int) index1).GetComponent<Image>();
        this.TechItem[panelObjectIdx].Button[(int) index1] = transform.GetChild((int) index1).GetComponent<UIButton>();
        this.TechItem[panelObjectIdx].Research[(int) index1] = transform.GetChild((int) index1).GetChild(1).GetComponent<RectTransform>();
        this.TechItem[panelObjectIdx].Lock[(int) index1] = transform.GetChild((int) index1).GetChild(2);
        this.TechItem[panelObjectIdx].NeedLvText[(int) index1] = transform.GetChild((int) index1).GetChild(2).GetChild(1).GetComponent<UIText>();
        this.TechItem[panelObjectIdx].KindName[(int) index1] = transform.GetChild((int) index1).GetChild(0).GetComponent<UIText>();
      }
      if (index2 >= (uint) this.KindDataCount)
      {
        transform.GetChild((int) index1).gameObject.SetActive(false);
      }
      else
      {
        transform.GetChild((int) index1).gameObject.SetActive(true);
        DataManager instance = DataManager.Instance;
        TechKindTbl recordByIndex = instance.TechKindData.GetRecordByIndex((int) instance.sortTechKindIndex[(int) (ushort) index2]);
        this.TechItem[panelObjectIdx].TechImg[(int) index1].sprite = this.SpriteArray.GetSprite((int) recordByIndex.Graphic - 1);
        if ((Object) this.TechItem[panelObjectIdx].TechImg[(int) index1].sprite == (Object) null)
          this.TechItem[panelObjectIdx].TechImg[(int) index1].sprite = this.SpriteArray.GetSprite(0);
        this.TechItem[panelObjectIdx].TechImg[(int) index1].SetNativeSize();
        this.TechItem[panelObjectIdx].Button[(int) index1].m_BtnID1 = (int) recordByIndex.TechKind;
        this.TechItem[panelObjectIdx].KindName[(int) index1].text = instance.mStringTable.GetStringByID((uint) recordByIndex.KindName);
        this.TechItem[panelObjectIdx].Button[(int) index1].m_BtnID2 = (int) recordByIndex.KindName;
        if (this.ResearchTechKind > (byte) 0 && this.TechItem[panelObjectIdx].Button[(int) index1].m_BtnID1 == (int) this.ResearchTechKind)
          ((Component) this.TechItem[panelObjectIdx].Research[(int) index1]).gameObject.SetActive(true);
        else
          ((Component) this.TechItem[panelObjectIdx].Research[(int) index1]).gameObject.SetActive(false);
        if ((int) recordByIndex.ResearchLevel > (int) this.GUIM.BuildingData.GetBuildData((ushort) 10, (ushort) 0).Level)
        {
          this.TechItem[panelObjectIdx].Lock[(int) index1].gameObject.SetActive(true);
          this.TechItem[panelObjectIdx].NeedLvStr[(int) index1].ClearString();
          this.TechItem[panelObjectIdx].NeedLvStr[(int) index1].IntToFormat((long) recordByIndex.ResearchLevel);
          this.TechItem[panelObjectIdx].NeedLvStr[(int) index1].AppendFormat(instance.mStringTable.GetStringByID(5008U));
          this.TechItem[panelObjectIdx].NeedLvText[(int) index1].text = this.TechItem[panelObjectIdx].NeedLvStr[(int) index1].ToString();
          this.TechItem[panelObjectIdx].NeedLvText[(int) index1].SetAllDirty();
          this.TechItem[panelObjectIdx].NeedLvText[(int) index1].cachedTextGenerator.Invalidate();
        }
        else if (!DataManager.Instance.CheckTechKind(ref recordByIndex, this.TechItem[panelObjectIdx].NeedLvStr[(int) index1]))
        {
          this.TechItem[panelObjectIdx].Lock[(int) index1].gameObject.SetActive(true);
          this.TechItem[panelObjectIdx].NeedLvText[(int) index1].text = this.TechItem[panelObjectIdx].NeedLvStr[(int) index1].ToString();
          this.TechItem[panelObjectIdx].NeedLvText[(int) index1].SetAllDirty();
          this.TechItem[panelObjectIdx].NeedLvText[(int) index1].cachedTextGenerator.Invalidate();
        }
        else
          this.TechItem[panelObjectIdx].Lock[(int) index1].gameObject.SetActive(false);
      }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void OnClose()
  {
    if ((Object) this.baseBuild != (Object) null)
      this.baseBuild.DestroyBuildingWindow();
    if ((Object) this.timeBar != (Object) null)
      this.GUIM.RemoverTimeBaarToList(this.timeBar);
    if (this.TechItem != null)
    {
      for (int index = 0; index < this.TechItem.Length; ++index)
        this.TechItem[index].Destory();
    }
    if (!((Object) this.ScroContent != (Object) null))
      return;
    byte[] techKindSaved = this.GUIM.TechKindSaved;
    techKindSaved[0] = (byte) this.m_itemView.GetBeginIdx();
    GameConstants.GetBytes(this.ScroContent.anchoredPosition.y, techKindSaved, 1);
  }

  public void OnTimer(UITimeBar sender)
  {
  }

  public void OnNotify(UITimeBar sender)
  {
    this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Free);
  }

  public void Onfunc(UITimeBar sender)
  {
    if (sender.m_TimerSpriteType == eTimerSpriteType.Speed)
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BagFilter, 2, 1);
    else if (sender.m_TimerSpriteType == eTimerSpriteType.Free)
    {
      DataManager.Instance.sendTechnologyCompleteFree();
    }
    else
    {
      if (sender.m_TimerSpriteType != eTimerSpriteType.Help)
        return;
      DataManager.Instance.SendAllianceHelp((byte) 0);
    }
  }

  public void OnCancel(UITimeBar sender)
  {
    if (DataManager.Instance.ResearchTech <= (ushort) 0)
      return;
    GUIManager.Instance.OpenOKCancelBox((GUIWindow) this.baseBuild, DataManager.Instance.mStringTable.GetStringByID(5023U), DataManager.Instance.mStringTable.GetStringByID(5024U), 14, YesText: DataManager.Instance.mStringTable.GetStringByID(5026U), NoText: DataManager.Instance.mStringTable.GetStringByID(5025U));
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (this.PassInit > (byte) 0)
      return;
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_BuildBase:
        this.baseBuild.MyUpdate(meg[1]);
        for (int panelObjectIdx = 0; panelObjectIdx < this.TechItem.Length; ++panelObjectIdx)
        {
          if (this.TechItem[panelObjectIdx].transform.gameObject.activeSelf)
            this.UpDateRowItem(this.TechItem[panelObjectIdx].transform.gameObject, this.TechItem[panelObjectIdx].dataIndex, panelObjectIdx, 0);
        }
        break;
      case NetworkNews.Refresh_Technology:
        this.UpdateTimeBarState();
        TechDataTbl recordByKey = DataManager.Instance.TechData.GetRecordByKey(GameConstants.ConvertBytesToUShort(meg, 2));
        for (int index1 = 0; index1 < this.TechItem.Length; ++index1)
        {
          for (int index2 = 0; index2 < this.TechItem[index1].Button.Length; ++index2)
          {
            if (this.TechItem[index1].Button[index2].m_BtnID1 == (int) recordByKey.Kind)
            {
              ((Component) this.TechItem[index1].Research[index2]).gameObject.SetActive(false);
              this.ResearchTechKind = (byte) 0;
              return;
            }
          }
        }
        break;
      case NetworkNews.Refresh_AttribEffectVal:
        this.baseBuild.MyUpdate((byte) 0);
        break;
      default:
        if (networkNews != NetworkNews.Login)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          this.baseBuild.Refresh_FontTexture();
          this.TextRefresh();
          break;
        }
        goto case NetworkNews.Refresh_AttribEffectVal;
    }
  }

  private void TextRefresh()
  {
    ((Behaviour) this.TitleText).enabled = false;
    ((Behaviour) this.TitleText).enabled = true;
    if (this.timeBar.gameObject.activeSelf)
      this.timeBar.Refresh_FontTexture();
    for (int index1 = 0; index1 < this.TechItem.Length; ++index1)
    {
      if (this.TechItem[index1].KindName != null && this.TechItem[index1].NeedLvText != null)
      {
        for (int index2 = 0; index2 < this.TechItem[index1].KindName.Length && !((Object) this.TechItem[index1].KindName[index2] == (Object) null); ++index2)
        {
          ((Behaviour) this.TechItem[index1].KindName[index2]).enabled = false;
          ((Behaviour) this.TechItem[index1].NeedLvText[index2]).enabled = false;
          ((Behaviour) this.TechItem[index1].KindName[index2]).enabled = true;
          ((Behaviour) this.TechItem[index1].NeedLvText[index2]).enabled = true;
        }
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
        break;
      case 2:
        this.UpdateTimeBarState();
        break;
    }
  }

  public struct _TechItem
  {
    public Transform transform;
    public int dataIndex;
    public Image[] TechImg;
    public UIText[] KindName;
    public RectTransform[] Research;
    public Transform[] Lock;
    public UIButton[] Button;
    public UIText[] NeedLvText;
    public CString[] NeedLvStr;

    public void Init()
    {
      this.TechImg = new Image[4];
      this.KindName = new UIText[4];
      this.Research = new RectTransform[4];
      this.Lock = new Transform[4];
      this.Button = new UIButton[4];
      this.NeedLvText = new UIText[4];
      this.NeedLvStr = new CString[4];
      for (int index = 0; index < this.NeedLvStr.Length; ++index)
        this.NeedLvStr[index] = StringManager.Instance.SpawnString();
    }

    public void Destory()
    {
      for (int index = 0; index < this.NeedLvStr.Length; ++index)
        StringManager.Instance.DeSpawnString(this.NeedLvStr[index]);
    }
  }

  private enum UIControl
  {
    Image1,
    Image2,
    ScrollView,
    Item,
  }
}
