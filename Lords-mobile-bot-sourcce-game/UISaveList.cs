// Decompiled with JetBrains decompiler
// Type: UISaveList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UISaveList : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  protected UIText[] Titles = new UIText[3];
  private RectTransform ResearchRect;
  protected ScrollPanel SaveScrollPanel;
  protected RectTransform ScrollContentRect;
  private List<float> ItemsHeight = new List<float>();
  protected byte SlotNum;
  protected int ResearchIndex = -1;
  private UISaveList.ItemEdit[] PanelItem;
  private CString NeedResearchStr;

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager instance1 = GUIManager.Instance;
    DataManager instance2 = DataManager.Instance;
    instance1.UpdateUI(EGUIWindow.Door, 1, 2);
    Font ttfFont = instance1.GetTTFFont();
    this.Titles[0] = this.transform.GetChild(0).GetChild(2).GetComponent<UIText>();
    this.Titles[0].font = ttfFont;
    this.Titles[1] = this.transform.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.Titles[1].font = ttfFont;
    this.Titles[2] = this.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.Titles[2].font = ttfFont;
    this.Titles[2].text = instance2.mStringTable.GetStringByID(3849U);
    this.ResearchRect = this.transform.GetChild(3).GetComponent<RectTransform>();
    Door menu = instance1.FindMenu(EGUIWindow.Door) as Door;
    Image component1 = this.transform.GetChild(4).GetComponent<Image>();
    component1.sprite = menu.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component1).material = menu.LoadMaterial();
    Image component2 = this.transform.GetChild(4).GetChild(0).GetComponent<Image>();
    component2.sprite = menu.LoadSprite("UI_main_close");
    ((MaskableGraphic) component2).material = menu.LoadMaterial();
    if (instance1.bOpenOnIPhoneX)
      ((Behaviour) this.transform.GetChild(4).GetComponent<Image>()).enabled = false;
    UIButton component3 = this.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
    component3.m_BtnID1 = 1;
    component3.m_Handler = (IUIButtonClickHandler) this;
    UIButton component4 = this.transform.GetChild(3).GetChild(1).GetComponent<UIButton>();
    component4.m_BtnID1 = 0;
    component4.m_Handler = (IUIButtonClickHandler) this;
    UIText component5 = this.transform.GetChild(2).GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    component5.font = ttfFont;
    component5.text = instance2.mStringTable.GetStringByID(924U);
    UIText component6 = this.transform.GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
    component6.font = ttfFont;
    component6.text = instance2.mStringTable.GetStringByID(925U);
    this.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.NeedResearchStr = StringManager.Instance.SpawnString(50);
    this.SaveScrollPanel = this.transform.GetChild(1).GetComponent<ScrollPanel>();
    for (int index = 0; index < 7; ++index)
      this.ItemsHeight.Add(94f);
    this.PanelItem = new UISaveList.ItemEdit[7];
    this.SaveScrollPanel.IntiScrollPanel(515f, 0.0f, 0.0f, this.ItemsHeight, 7, (IUpDateScrollPanel) this);
    this.ScrollContentRect = this.SaveScrollPanel.transform.GetChild(1).GetComponent<RectTransform>();
    this.UpdateSaveList();
    this.SaveScrollPanel.gameObject.SetActive(true);
  }

  public void UpdateSaveList()
  {
    this.SlotNum = this.GetItemNum();
    this.ResearchIndex = (int) this.GetResearchIndex();
    this.ItemsHeight.Clear();
    for (int index = 0; index < (int) this.SlotNum; ++index)
      this.ItemsHeight.Add(94f);
    this.SaveScrollPanel.AddNewDataHeight(this.ItemsHeight);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    for (int index = 0; index < this.Titles.Length; ++index)
    {
      ((Behaviour) this.Titles[index]).enabled = false;
      ((Behaviour) this.Titles[index]).enabled = true;
    }
    for (int index = 0; index < this.PanelItem.Length; ++index)
      this.PanelItem[index].TextRefresh();
  }

  public override void UpdateTime(bool bOnSecond)
  {
  }

  public override void OnClose() => StringManager.Instance.DeSpawnString(this.NeedResearchStr);

  public virtual void OnButtonClick(UIButton sender)
  {
    switch ((UISaveList.ClickType) sender.m_BtnID1)
    {
      case UISaveList.ClickType.GotoInstitute:
        GUIManager.Instance.OpenTechTree(this.GetResearchID(), true);
        break;
      case UISaveList.ClickType.Close:
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!((Object) menu != (Object) null))
          break;
        menu.CloseMenu();
        break;
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((Object) this.PanelItem[panelObjectIdx].transform == (Object) null)
      this.PanelItem[panelObjectIdx].Init(item.transform, (IUIButtonClickHandler) this);
    else if (dataIdx == this.ResearchIndex)
    {
      DataManager instance = DataManager.Instance;
      this.PanelItem[panelObjectIdx].YesObj.SetActive(false);
      ((Component) this.ResearchRect).gameObject.SetActive(true);
      ((Transform) this.ResearchRect).SetParent(this.PanelItem[panelObjectIdx].transform);
      this.ResearchRect.anchoredPosition = Vector2.zero;
      this.NeedResearchStr.ClearString();
      this.NeedResearchStr.StringToFormat(instance.mStringTable.GetStringByID((uint) instance.TechData.GetRecordByKey(this.GetResearchID()).TechName));
      this.NeedResearchStr.AppendFormat(instance.mStringTable.GetStringByID(3775U));
      this.Titles[1].text = this.NeedResearchStr.ToString();
      this.Titles[1].SetAllDirty();
      this.Titles[1].cachedTextGenerator.Invalidate();
    }
    else
      this.SetItemData(ref this.PanelItem[panelObjectIdx], dataIdx);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public virtual void SetItemData(ref UISaveList.ItemEdit Data, int dataIdx)
  {
    if (!Data.YesObj.activeSelf)
    {
      Data.YesObj.SetActive(true);
      ((Transform) this.ResearchRect).SetParent(this.transform);
      ((Component) this.ResearchRect).gameObject.SetActive(false);
    }
    Data.Applybtn.m_BtnID2 = dataIdx;
    Data.Setupbtn.m_BtnID2 = dataIdx;
  }

  public virtual short GetResearchIndex() => -1;

  public virtual byte GetItemNum() => 0;

  public virtual ushort GetResearchID() => 117;

  protected enum UIControl
  {
    Background,
    Scroll,
    Item,
    Restrict,
    Close,
  }

  protected enum ClickType
  {
    GotoInstitute,
    Close,
    Apply,
    Setup,
  }

  public struct ItemEdit
  {
    public Transform transform;
    public GameObject YesObj;
    public GameObject TransObj;
    public UIText Title;
    public UIText ApplyText;
    public UIText SetupText;
    public UIButton Applybtn;
    public UIButton Setupbtn;
    private Image ApplyImg;

    public void Init(Transform transform, IUIButtonClickHandler handle)
    {
      this.transform = transform;
      this.TransObj = transform.gameObject;
      this.YesObj = transform.GetChild(0).gameObject;
      this.Applybtn = transform.GetChild(0).GetChild(1).GetComponent<UIButton>();
      this.Applybtn.m_Handler = handle;
      this.Applybtn.m_BtnID1 = 2;
      this.Setupbtn = transform.GetChild(0).GetChild(2).GetComponent<UIButton>();
      this.Setupbtn.m_Handler = handle;
      this.Setupbtn.m_BtnID1 = 3;
      this.Title = transform.GetChild(0).GetChild(0).GetComponent<UIText>();
      this.ApplyText = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
      this.SetupText = transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
      this.ApplyImg = transform.GetChild(0).GetChild(1).GetComponent<Image>();
    }

    public void SetData(int Index)
    {
      this.Title.text = DataManager.Instance.SaveTalentData[Index].GetTagName().ToString();
      this.Title.SetAllDirty();
      this.Title.cachedTextGenerator.Invalidate();
      this.Applybtn.m_BtnID2 = Index;
      this.Setupbtn.m_BtnID2 = Index;
    }

    public void SetaApplyEnable(bool Enable)
    {
      ((Behaviour) this.Applybtn).enabled = Enable;
      if (Enable)
      {
        ((Graphic) this.ApplyImg).color = Color.white;
        ((Graphic) this.ApplyText).color = Color.white;
      }
      else
      {
        ((Graphic) this.ApplyImg).color = Color.gray;
        ((Graphic) this.ApplyText).color = new Color(0.898f, 0.0f, 0.31f);
      }
    }

    public void TextRefresh()
    {
      if ((Object) this.Title == (Object) null)
        return;
      ((Behaviour) this.Title).enabled = false;
      ((Behaviour) this.Title).enabled = true;
      ((Behaviour) this.ApplyText).enabled = false;
      ((Behaviour) this.ApplyText).enabled = true;
      ((Behaviour) this.SetupText).enabled = false;
      ((Behaviour) this.SetupText).enabled = true;
    }

    public enum UIYesControl
    {
      Title,
      ApplyBtn,
      SetupBtn,
    }
  }
}
