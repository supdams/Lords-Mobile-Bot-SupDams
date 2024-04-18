// Decompiled with JetBrains decompiler
// Type: UIPetList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIPetList : GUIWindow, IBuildingWindowType, IUpDateScrollPanel, IUIButtonClickHandler
{
  private BuildingWindow baseBuild;
  private GameObject MsgObj;
  private UIText MsgText;
  public Transform ThisTransform;
  private RectTransform PetScrollRect;
  private ScrollPanel Scroll;
  private List<float> Height = new List<float>();
  private int ItemCount;
  private int ItemStart;
  private byte LockCheckState;
  private byte SkipUpdate;
  private byte bInit = 2;
  private _PetItem[] PetScrollItem;

  void IUIButtonClickHandler.OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_PetBag);
        break;
      case 1:
        GUIManager.Instance.OpenContinuousUI((ushort) sender.m_BtnID2);
        break;
      case 2:
        PetManager.Instance.OpenPetUI(sender.m_BtnID3, (int) (ushort) sender.m_BtnID2);
        break;
      case 3:
        StringTable mStringTable = DataManager.Instance.mStringTable;
        GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(16037U), mStringTable.GetStringByID(16036U), mStringTable.GetStringByID(4507U), (GUIWindow) this, 22, bCloseIDSet: true, BackExit: true);
        break;
    }
  }

  void IUpDateScrollPanel.UpDateRowItem(
    GameObject item,
    int dataIdx,
    int panelObjectIdx,
    int panelId)
  {
    if (this.PetScrollItem[panelObjectIdx].bInit == (byte) 0)
      this.PetScrollItem[panelObjectIdx] = new _PetItem(item.transform, (IUIButtonClickHandler) this);
    this.PetScrollItem[panelObjectIdx].SetData(dataIdx, this.ItemStart, this.ItemCount, this.LockCheckState);
  }

  void IUpDateScrollPanel.ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  void IBuildingWindowType.OnTypeChange(e_BuildType buildType)
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
    }
  }

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager instance = GUIManager.Instance;
    this.ThisTransform = this.transform.GetChild(0);
    Font ttfFont = instance.GetTTFFont();
    for (int index = 0; index < 4; ++index)
    {
      this.ThisTransform.GetChild(1).GetChild(index).GetChild(0).GetChild(3).GetChild(0).GetComponent<UIText>().font = ttfFont;
      this.ThisTransform.GetChild(1).GetChild(index).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>().font = ttfFont;
      this.ThisTransform.GetChild(1).GetChild(index).GetChild(1).GetChild(2).GetComponent<UIText>().font = ttfFont;
      instance.InitianHeroItemImg(this.ThisTransform.GetChild(1).GetChild(index).GetChild(0).GetChild(0), eHeroOrItem.Pet, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
      instance.InitianHeroItemImg(this.ThisTransform.GetChild(1).GetChild(index).GetChild(1).GetChild(1), eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
      this.ThisTransform.GetChild(1).GetChild(index).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>().font = ttfFont;
      ((Behaviour) this.ThisTransform.GetChild(1).GetChild(index).GetChild(0).GetChild(0).GetComponent<UIHIBtn>()).enabled = false;
      ((Behaviour) this.ThisTransform.GetChild(1).GetChild(index).GetChild(0).GetChild(0).GetComponent<Image>()).enabled = false;
      ((Behaviour) this.ThisTransform.GetChild(1).GetChild(index).GetChild(1).GetChild(1).GetComponent<UIHIBtn>()).enabled = false;
      ((Behaviour) this.ThisTransform.GetChild(1).GetChild(index).GetChild(1).GetChild(1).GetComponent<Image>()).enabled = false;
    }
    UIButton component = this.ThisTransform.GetChild(2).GetComponent<UIButton>();
    component.m_Handler = (IUIButtonClickHandler) this;
    component.m_BtnID1 = 0;
    this.MsgObj = this.ThisTransform.GetChild(3).gameObject;
    this.MsgText = this.ThisTransform.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.MsgText.font = ttfFont;
    this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID(16093U);
    instance.UpdateUI(EGUIWindow.Door, 1, 4);
    this.baseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    this.baseBuild.InitBuildingWindow((byte) 20, (ushort) arg1, (byte) 2, GUIManager.Instance.BuildingData.AllBuildsData[arg1].Level);
    this.baseBuild.baseTransform.SetAsFirstSibling();
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (this.bInit <= (byte) 0)
      return;
    --this.bInit;
    if (this.bInit != (byte) 0)
      return;
    this.Scroll = this.ThisTransform.GetChild(0).GetComponent<ScrollPanel>();
    this.PetScrollItem = new _PetItem[4];
    this.Scroll.IntiScrollPanel(354f, 0.0f, 0.0f, this.Height, 4, (IUpDateScrollPanel) this);
    this.PetScrollRect = this.Scroll.transform.GetChild(0).GetComponent<RectTransform>();
    this.Scroll.gameObject.SetActive(true);
    this.UpdatePetList();
    NewbieManager.CheckSpawnPetFromUI();
    if (NewbieManager.IsTeachWorking(ETeachKind.SPAWN_PET))
      this.Scroll.GoTo(0, 0.0f);
    else
      this.Scroll.GoTo((int) PetManager.Instance.UISave[6], GameConstants.ConvertBytesToFloat(PetManager.Instance.UISave, 7));
    this.baseBuild.MyUpdate((byte) 0);
    ((Behaviour) this.MsgText).enabled = false;
    ((Behaviour) this.MsgText).enabled = true;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (this.bInit > (byte) 0)
      return;
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh_AttribEffectVal:
        if (networkNews == NetworkNews.Login)
        {
          this.SkipUpdate = (byte) 0;
          this.UpdatePetList();
        }
        this.baseBuild.MyUpdate((byte) 0);
        break;
      case NetworkNews.Refresh_Item:
      case NetworkNews.Refresh_Pet:
        this.UpdatePetList();
        break;
      case NetworkNews.Refresh_BuildBase:
        if (meg[1] == (byte) 1)
        {
          (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu(true);
          break;
        }
        this.baseBuild.MyUpdate(meg[1]);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        ((Behaviour) this.MsgText).enabled = false;
        ((Behaviour) this.MsgText).enabled = true;
        for (int index = 0; index < this.PetScrollItem.Length; ++index)
          this.PetScrollItem[index].TextRefresh();
        this.baseBuild.Refresh_FontTexture();
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (this.bInit > (byte) 0)
      return;
    for (int index1 = 0; index1 < 32; ++index1)
    {
      int num1 = arg1 >> index1;
      if (num1 == 0)
        break;
      int num2 = num1 & 1;
      if (num2 != 0)
      {
        int num3 = num2 << index1;
        UIPetList.eUpdateUI eUpdateUi = (UIPetList.eUpdateUI) num3;
        switch (eUpdateUi)
        {
          case UIPetList.eUpdateUI.updateList:
            this.UpdatePetList();
            continue;
          case UIPetList.eUpdateUI.updateState:
          case UIPetList.eUpdateUI.updateStone:
            if (num3 == 4)
              this.LockCheckState = (byte) 0;
            for (int index2 = 0; index2 < this.PetScrollItem.Length; ++index2)
              this.PetScrollItem[index2].UpdatePetState(this.LockCheckState);
            continue;
          case UIPetList.eUpdateUI.updateNewBook:
            if ((arg1 & 1) == 0)
              this.UpdatePetList();
            this.Scroll.GoTo(0, 0.0f);
            continue;
          default:
            if (eUpdateUi != UIPetList.eUpdateUI.updateSkipUpdate)
            {
              if (eUpdateUi == UIPetList.eUpdateUI.Max)
                return;
              continue;
            }
            this.SkipUpdate = (byte) 1;
            continue;
        }
      }
    }
  }

  public override void OnClose()
  {
    if ((Object) this.baseBuild != (Object) null)
      this.baseBuild.DestroyBuildingWindow();
    if (this.PetScrollItem == null)
      return;
    for (int index = 0; index < this.PetScrollItem.Length; ++index)
      this.PetScrollItem[index].OnDestroy();
    PetManager instance = PetManager.Instance;
    instance.UISave[6] = (byte) this.Scroll.GetBeginIdx();
    GameConstants.GetBytes(this.PetScrollRect.anchoredPosition.y, instance.UISave, 7);
  }

  private void UpdatePetList()
  {
    if (this.SkipUpdate == (byte) 1)
      return;
    PetManager.Instance.SortPetItemData();
    PetManager.Instance.SortPetData();
    this.ItemStart = (int) DataManager.Instance.sortItemDataStart[17];
    int num1 = (int) DataManager.Instance.sortItemDataCount[17];
    this.ItemCount = num1;
    if (this.ItemCount == 0)
    {
      this.ItemStart = 0;
      num1 = 1;
    }
    int num2 = num1 + (int) PetManager.Instance.PetDataCount;
    int num3 = (num2 >> 2) + Mathf.Clamp(num2 & 3, 0, 1);
    if (this.ItemCount == 0 && PetManager.Instance.PetDataCount == (ushort) 0)
      this.MsgObj.SetActive(true);
    else
      this.MsgObj.SetActive(false);
    if (num3 > this.Height.Count)
    {
      int num4 = num3 - this.Height.Count;
      for (int index = 0; index < num4; ++index)
        this.Height.Add(194f);
    }
    else if (num3 < this.Height.Count)
    {
      int count = this.Height.Count - num3;
      this.Height.RemoveRange(this.Height.Count - count, count);
    }
    int beginIdx = this.Scroll.GetBeginIdx();
    Vector2 anchoredPosition = this.PetScrollRect.anchoredPosition;
    this.Scroll.AddNewDataHeight(this.Height);
    this.Scroll.GoTo(beginIdx, anchoredPosition.y);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    GUIManager.Instance.BuildingData.ManorGuild((ushort) arg1);
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
  }

  private enum UIControl
  {
    Scroll,
    Item,
    BageBtn,
    Messsage,
  }

  public enum ClickType
  {
    Bage,
    CellItem,
    CellPet,
    CellDef,
  }

  public enum eUpdateUI
  {
    updateList = 1,
    updateState = 2,
    updateStone = 4,
    updateNewBook = 8,
    updateSkipUpdate = 16, // 0x00000010
    Max = 32, // 0x00000020
  }
}
