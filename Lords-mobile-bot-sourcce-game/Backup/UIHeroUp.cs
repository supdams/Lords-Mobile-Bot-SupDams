// Decompiled with JetBrains decompiler
// Type: UIHeroUp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal class UIHeroUp : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const float ItemHeight = 96f;
  private const float PanelHight = 330f;
  private const int PanelObjCount = 7;
  private const int MaxTempTextNum = 7;
  private GUIManager GM;
  private DataManager DM;
  private Door m_Door;
  private Font TTF;
  private Image m_Light;
  private Transform m_LightTf;
  private ScrollPanel m_ScrollPanel;
  private UIHeroUp.sScrollItem[] m_ScrollItem = new UIHeroUp.sScrollItem[7];
  private UIText[] m_TempText = new UIText[7];
  private int m_TempTextIdx;

  public void UpdateScrollPanel(bool bMoveToTop = true)
  {
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.GM.m_HerodLvUpData.Count; ++index)
      _DataHeight.Add(96f);
    this.m_ScrollPanel.AddNewDataHeight(_DataHeight, bMoveToTop);
  }

  public void InitUI()
  {
    for (int index = 0; index < 7; ++index)
    {
      if (this.m_ScrollItem[index].Str == null)
        this.m_ScrollItem[index].Str = StringManager.Instance.SpawnString(80);
    }
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      Transform child = this.transform.GetChild(0);
      if ((Object) child != (Object) null)
      {
        ((RectTransform) child).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
        ((RectTransform) child).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      }
    }
    this.m_Light = this.transform.GetChild(0).GetChild(4).GetComponent<Image>();
    this.m_LightTf = this.transform.GetChild(0).GetChild(4);
    UIText component1 = this.transform.GetChild(3).GetChild(0).GetComponent<UIText>();
    component1.font = this.TTF;
    component1.text = this.DM.mStringTable.GetStringByID(5911U);
    UIText component2 = this.transform.GetChild(3).GetChild(1).GetComponent<UIText>();
    component2.font = this.TTF;
    component2.text = this.DM.mStringTable.GetStringByID(5912U);
    if (GUIManager.Instance.IsArabic)
      ((Graphic) component2).rectTransform.anchoredPosition = component2.ArabicFixPos(new Vector2(64f, 210f));
    this.transform.GetChild(4).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    GUIManager.Instance.InitianHeroItemImg(((Component) this.transform.GetChild(2).GetChild(1).GetComponent<UIHIBtn>()).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 1, 1, false, false);
    this.m_ScrollPanel = this.transform.GetChild(1).GetComponent<ScrollPanel>();
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.GM.m_HerodLvUpData.Count; ++index)
      _DataHeight.Add(96f);
    this.m_ScrollPanel.IntiScrollPanel(330f, 1f, 0.0f, _DataHeight, 7, (IUpDateScrollPanel) this);
  }

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
    this.GM = GUIManager.Instance;
    this.DM = DataManager.Instance;
    this.m_Door = this.GM.FindMenu(EGUIWindow.Door) as Door;
    this.TTF = this.GM.GetTTFFont();
    this.GM.bOpenHeroLvUp = true;
    this.InitUI();
    this.GM.LoadLvUpLight(this.transform.GetChild(0).GetChild(0));
    AudioManager.Instance.PlayUISFX(UIKind.DominanceLevelup);
  }

  public override void OnClose()
  {
    this.GM.bOpenHeroLvUp = false;
    this.GM.m_HerodLvUpData.Clear();
    for (int index = 0; index < 7; ++index)
    {
      if (this.m_ScrollItem[index].Str != null)
      {
        StringManager.Instance.DeSpawnString(this.m_ScrollItem[index].Str);
        this.m_ScrollItem[index].Str = (CString) null;
      }
    }
    this.GM.ReleaseLvUpLight();
  }

  public override void UpdateUI(int arg1, int arg2) => this.UpdateScrollPanel(false);

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 != 0)
      return;
    GUIManager.Instance.CloseMenu(EGUIWindow.UI_HeroUp);
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (dataIdx >= this.GM.m_HerodLvUpData.Count)
      return;
    ushort heroId = this.GM.m_HerodLvUpData[dataIdx].HeroID;
    byte beginLv = this.GM.m_HerodLvUpData[dataIdx].BeginLv;
    byte targetLv = this.GM.m_HerodLvUpData[dataIdx].TargetLv;
    byte Circle = 0;
    if (this.DM.curHeroData.ContainsKey((uint) heroId))
      Circle = this.DM.curHeroData[(uint) heroId].Star;
    if ((Object) this.m_ScrollItem[panelObjectIdx].HeroBtn == (Object) null)
    {
      this.m_ScrollItem[panelObjectIdx].HeroBtn = item.transform.GetChild(1).GetComponent<UIHIBtn>();
      this.m_ScrollItem[panelObjectIdx].LvText = item.transform.GetChild(2).GetComponent<UIText>();
      this.m_ScrollItem[panelObjectIdx].LvText.font = this.TTF;
      this.m_TempText[panelObjectIdx] = this.m_ScrollItem[panelObjectIdx].LvText;
    }
    GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_ScrollItem[panelObjectIdx].HeroBtn).transform, eHeroOrItem.Hero, heroId, Circle, (byte) 0);
    this.m_ScrollItem[panelObjectIdx].Str.ClearString();
    this.m_ScrollItem[panelObjectIdx].Str.IntToFormat((long) beginLv);
    this.m_ScrollItem[panelObjectIdx].Str.IntToFormat((long) targetLv);
    this.m_ScrollItem[panelObjectIdx].Str.AppendFormat(this.DM.mStringTable.GetStringByID(5913U));
    this.m_ScrollItem[panelObjectIdx].LvText.text = this.m_ScrollItem[panelObjectIdx].Str.ToString();
    this.m_ScrollItem[panelObjectIdx].LvText.SetAllDirty();
    this.m_ScrollItem[panelObjectIdx].LvText.cachedTextGenerator.Invalidate();
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  private void Update()
  {
    if (!((Component) this.m_Light).gameObject.activeSelf)
      return;
    this.m_LightTf.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
  }

  private void Refresh_FontTexture()
  {
    if (this.m_TempText != null)
    {
      for (int index = 0; index < this.m_TempText.Length; ++index)
      {
        if ((Object) this.m_TempText[index] != (Object) null && ((Behaviour) this.m_TempText[index]).enabled)
        {
          ((Behaviour) this.m_TempText[index]).enabled = false;
          ((Behaviour) this.m_TempText[index]).enabled = true;
        }
      }
    }
    if (this.m_ScrollItem == null)
      return;
    for (int index = 0; index < this.m_ScrollItem.Length; ++index)
    {
      if (this.m_ScrollItem != null)
      {
        if ((Object) this.m_ScrollItem[index].LvText != (Object) null && ((Behaviour) this.m_ScrollItem[index].LvText).enabled)
        {
          ((Behaviour) this.m_ScrollItem[index].LvText).enabled = false;
          ((Behaviour) this.m_ScrollItem[index].LvText).enabled = true;
        }
        if ((Object) this.m_ScrollItem[index].HeroBtn != (Object) null && ((Behaviour) this.m_ScrollItem[index].HeroBtn).enabled)
          this.m_ScrollItem[index].HeroBtn.Refresh_FontTexture();
      }
    }
  }

  private struct sScrollItem
  {
    public UIHIBtn HeroBtn;
    public UIText LvText;
    public CString Str;
  }
}
