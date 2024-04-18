// Decompiled with JetBrains decompiler
// Type: UIBlackList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIBlackList : GUIWindow, UILoadImageHander, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const int UnitCount2 = 8;
  private Transform m_transform;
  private DataManager DM = DataManager.Instance;
  private GUIManager GM = GUIManager.Instance;
  private ScrollPanel ScrollBL;
  private CScrollRect ScrollRectBL;
  private Font m_Font;
  private List<float> NowHeightList2 = new List<float>();
  private bool[] bFindScrollComp2 = new bool[8];
  private UnitComp2N[] Scroll_2_Comp = new UnitComp2N[8];
  private int ScrollIndex;
  private float ScrollPos;
  private byte DataCount;
  private byte[] IndexArray = new byte[100];
  private GameObject NoMessageGO;

  public override void OnOpen(int arg1, int arg2)
  {
    this.m_transform = this.transform;
    this.m_Font = this.GM.GetTTFFont();
    GUIManager.Instance.InitianHeroItemImg(this.m_transform.GetChild(5).GetChild(0), eHeroOrItem.Hero, (ushort) 1, (byte) 2, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.m_transform.GetChild(6).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(6).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(6).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) this.m_transform.GetChild(6).GetComponent<CustomImage>()).enabled = false;
    this.ScrollBL = this.m_transform.GetChild(4).GetComponent<ScrollPanel>();
    UIText component1 = this.m_transform.GetChild(2).GetComponent<UIText>();
    component1.font = this.m_Font;
    component1.text = this.DM.mStringTable.GetStringByID(6040U);
    this.NoMessageGO = this.m_transform.GetChild(3).gameObject;
    UIText component2 = this.m_transform.GetChild(3).GetChild(0).GetComponent<UIText>();
    component2.font = this.m_Font;
    component2.text = this.DM.mStringTable.GetStringByID(8243U);
    for (int index = 0; index < 8; ++index)
      this.bFindScrollComp2[index] = false;
    this.UpDateList(true);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  private void SetIndexArray()
  {
    this.DataCount = (byte) this.DM.TalkData_BlackList.Count;
    if (this.DataCount <= (byte) 0)
      return;
    int index1 = 0;
    for (byte index2 = 0; (int) index2 < this.DM.TalkData_BlackList.Length && index1 < this.IndexArray.Length; ++index2)
    {
      if (this.DM.TalkData_BlackList.Values[(int) index2] != null)
      {
        this.IndexArray[index1] = index2;
        ++index1;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2) => this.UpDateList();

  public void UpDateList(bool bFirst = false)
  {
    this.SetIndexArray();
    this.NowHeightList2.Clear();
    for (int index = 0; index < (int) this.DataCount; ++index)
      this.NowHeightList2.Add(85f);
    if (this.DataCount > (byte) 0)
      this.NoMessageGO.SetActive(false);
    else
      this.NoMessageGO.SetActive(true);
    if (bFirst)
    {
      this.ScrollBL.IntiScrollPanel(525f, 0.0f, 0.0f, this.NowHeightList2, 8, (IUpDateScrollPanel) this);
      this.ScrollRectBL = this.ScrollBL.GetComponent<CScrollRect>();
    }
    else
    {
      this.ScrollIndex = this.ScrollBL.GetTopIdx();
      this.ScrollPos = this.ScrollRectBL.content.anchoredPosition.y;
      this.ScrollBL.AddNewDataHeight(this.NowHeightList2);
      this.ScrollBL.GoTo(this.ScrollIndex, this.ScrollPos);
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelObjectIdx >= 8)
      return;
    if (!this.bFindScrollComp2[panelObjectIdx])
    {
      this.bFindScrollComp2[panelObjectIdx] = true;
      Transform transform = item.transform;
      Transform child = transform.GetChild(2);
      this.Scroll_2_Comp[panelObjectIdx].unLockBtn = child.GetComponent<UIButton>();
      this.Scroll_2_Comp[panelObjectIdx].unLockBtn.m_Handler = (IUIButtonClickHandler) this;
      UIText component = child.GetChild(0).GetComponent<UIText>();
      component.font = this.m_Font;
      component.text = this.DM.mStringTable.GetStringByID(8213U);
      this.Scroll_2_Comp[panelObjectIdx].PlayerT = transform.GetChild(0);
      this.Scroll_2_Comp[panelObjectIdx].PlayerText = transform.GetChild(1).GetComponent<UIText>();
      this.Scroll_2_Comp[panelObjectIdx].PlayerText.font = this.m_Font;
    }
    if (dataIdx >= (int) this.DataCount)
      return;
    byte index = this.IndexArray[dataIdx];
    this.Scroll_2_Comp[panelObjectIdx].unLockBtn.m_BtnID2 = (int) index;
    this.Scroll_2_Comp[panelObjectIdx].PlayerText.text = this.DM.TalkData_BlackList.Values[(int) index].PlayerName.ToString();
    GUIManager.Instance.ChangeHeroItemImg(this.Scroll_2_Comp[panelObjectIdx].PlayerT, eHeroOrItem.Hero, this.DM.TalkData_BlackList.Values[(int) index].PlayerPicID, (byte) 11, (byte) 0);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      (this.GM.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
    }
    else
    {
      if (sender.m_BtnID1 != 2)
        return;
      this.DM.RemoveBlackList(this.DM.TalkData_BlackList.Values[sender.m_BtnID2].PlayerName.GetHashCode(false), sender.m_BtnID2);
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (Object) menu)
      return;
    img.sprite = menu.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = menu.LoadMaterial();
  }
}
