// Decompiled with JetBrains decompiler
// Type: UIEmbassy
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIEmbassy : 
  GUIWindow,
  IBuildingWindowType,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler
{
  private const int UnitCount = 10;
  private Transform m_transform;
  private Transform NormalPanel;
  private BuildingWindow baseBuild;
  private GameObject NoAllyGO;
  private GameObject HasAllyGO;
  private GameObject[] NoArmyGO = new GameObject[2];
  private GameObject[] HasArmyGO = new GameObject[2];
  private ScrollPanel Scroll;
  private Font m_Font;
  private DataManager DM;
  private StringManager SM;
  private byte BuildID = 14;
  private UIText TitleText;
  private UISpritesArray SA;
  private List<float> NowHeightList = new List<float>();
  private bool[] bFindScrollComp = new bool[10];
  private ItemComp[] Scroll_Comp = new ItemComp[10];
  private CString[] ItemStrL = new CString[10];
  private CString[] ItemStrR = new CString[10];
  private CString[] TierStr = new CString[10];
  private CString MaxStr;
  private SoldierData tmpSD;
  private byte[] mTroopsIdx = new byte[16];
  private long TroopsTotal;
  private UIText[] RBText = new UIText[5];

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager instance = GUIManager.Instance;
    this.DM = DataManager.Instance;
    this.SM = StringManager.Instance;
    this.m_Font = instance.GetTTFFont();
    this.m_transform = this.transform;
    this.SA = this.m_transform.GetComponent<UISpritesArray>();
    byte level = instance.BuildingData.AllBuildsData[arg1].Level;
    this.NormalPanel = this.m_transform.GetChild(0);
    this.NormalPanel.GetChild(1).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.NormalPanel.GetChild(2).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.RBText[0] = this.NormalPanel.GetChild(1).GetChild(1).GetComponent<UIText>();
    this.RBText[0].font = this.m_Font;
    this.RBText[0].text = this.DM.mStringTable.GetStringByID(4820U);
    this.RBText[1] = this.NormalPanel.GetChild(5).GetComponent<UIText>();
    this.RBText[1].font = this.m_Font;
    this.RBText[1].text = this.DM.mStringTable.GetStringByID(4821U);
    this.NormalPanel.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector2((float) (-176.0 - (double) this.RBText[1].preferredWidth * 0.5), ((Graphic) this.RBText[1]).rectTransform.anchoredPosition.y);
    this.RBText[2] = this.NormalPanel.GetChild(2).GetChild(0).GetComponent<UIText>();
    this.RBText[2].font = this.m_Font;
    this.RBText[2].text = this.DM.mStringTable.GetStringByID(4825U);
    this.TitleText = this.NormalPanel.GetChild(6).GetComponent<UIText>();
    this.TitleText.font = this.m_Font;
    this.MaxStr = this.SM.SpawnString(100);
    this.RBText[3] = this.NormalPanel.GetChild(7).GetComponent<UIText>();
    this.RBText[3].font = this.m_Font;
    this.RBText[3].text = this.DM.mStringTable.GetStringByID(4824U);
    this.RBText[4] = this.NormalPanel.GetChild(8).GetComponent<UIText>();
    this.RBText[4].font = this.m_Font;
    this.RBText[4].text = this.DM.mStringTable.GetStringByID(5785U);
    this.Scroll = this.NormalPanel.GetChild(9).GetComponent<ScrollPanel>();
    for (int index = 0; index < 30; ++index)
      this.NowHeightList.Add(39f);
    this.Scroll.IntiScrollPanel(289f, 0.0f, 0.0f, this.NowHeightList, 10, (IUpDateScrollPanel) this);
    UIButtonHint.scrollRect = this.NormalPanel.GetChild(9).GetComponent<CScrollRect>();
    this.HasArmyGO[0] = this.NormalPanel.GetChild(2).gameObject;
    this.HasArmyGO[1] = this.NormalPanel.GetChild(9).gameObject;
    this.NoArmyGO[0] = this.NormalPanel.GetChild(4).gameObject;
    this.NoArmyGO[1] = this.NormalPanel.GetChild(7).gameObject;
    this.HasAllyGO = this.NormalPanel.GetChild(1).gameObject;
    this.NoAllyGO = this.NormalPanel.GetChild(8).gameObject;
    for (int index = 0; index < 10; ++index)
      this.bFindScrollComp[index] = false;
    this.baseBuild = this.m_transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    this.baseBuild.InitBuildingWindow(this.BuildID, (ushort) arg1, (byte) 1, level);
    this.baseBuild.baseTransform.SetAsFirstSibling();
    instance.UpdateUI(EGUIWindow.Door, 1, 2);
    this.CheckHasArmy();
    this.CheckHasAlly();
  }

  public override void OnClose()
  {
    if ((Object) this.baseBuild != (Object) null)
      this.baseBuild.DestroyBuildingWindow();
    for (int index = 9; index >= 0; --index)
    {
      if (this.ItemStrL[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.ItemStrL[index]);
        this.ItemStrL[index] = (CString) null;
      }
      if (this.ItemStrR[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.ItemStrR[index]);
        this.ItemStrR[index] = (CString) null;
      }
      if (this.TierStr[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.TierStr[index]);
        this.TierStr[index] = (CString) null;
      }
    }
    if (this.MaxStr == null)
      return;
    this.SM.DeSpawnString(this.MaxStr);
    this.MaxStr = (CString) null;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.baseBuild.MyUpdate((byte) 0);
        break;
      case NetworkNews.Refresh_Alliance:
        this.CheckHasAlly();
        break;
      case NetworkNews.Refresh_BuildBase:
        this.baseBuild.MyUpdate(meg[1]);
        break;
      case NetworkNews.Refresh_AttribEffectVal:
        this.CheckHasArmy();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.baseBuild.Refresh_FontTexture();
        if ((Object) this.TitleText != (Object) null && ((Behaviour) this.TitleText).enabled)
        {
          ((Behaviour) this.TitleText).enabled = false;
          ((Behaviour) this.TitleText).enabled = true;
        }
        for (int index = 0; index < this.RBText.Length; ++index)
        {
          if ((Object) this.RBText[index] != (Object) null && ((Behaviour) this.RBText[index]).enabled)
          {
            ((Behaviour) this.RBText[index]).enabled = false;
            ((Behaviour) this.RBText[index]).enabled = true;
          }
        }
        for (int index = 0; index < 10; ++index)
        {
          if (this.bFindScrollComp[index])
          {
            if ((Object) this.Scroll_Comp[index].TextL != (Object) null && ((Behaviour) this.Scroll_Comp[index].TextL).enabled)
            {
              ((Behaviour) this.Scroll_Comp[index].TextL).enabled = false;
              ((Behaviour) this.Scroll_Comp[index].TextL).enabled = true;
            }
            if ((Object) this.Scroll_Comp[index].TextR != (Object) null && ((Behaviour) this.Scroll_Comp[index].TextR).enabled)
            {
              ((Behaviour) this.Scroll_Comp[index].TextR).enabled = false;
              ((Behaviour) this.Scroll_Comp[index].TextR).enabled = true;
            }
            if ((Object) this.Scroll_Comp[index].TierText != (Object) null && ((Behaviour) this.Scroll_Comp[index].TierText).enabled)
            {
              ((Behaviour) this.Scroll_Comp[index].TierText).enabled = false;
              ((Behaviour) this.Scroll_Comp[index].TierText).enabled = true;
            }
          }
        }
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        this.CheckHasArmy();
        break;
      case 1:
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
        break;
    }
  }

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
      this.NormalPanel.gameObject.SetActive(true);
    else
      this.NormalPanel.gameObject.SetActive(false);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_Alliance_List, 5);
    }
    else
    {
      if (sender.m_BtnID1 != 2)
        return;
      GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4850U), this.DM.mStringTable.GetStringByID(4851U), 1, YesText: this.DM.mStringTable.GetStringByID(4852U), NoText: this.DM.mStringTable.GetStringByID(4853U));
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || arg1 != 1)
      return;
    this.DM.Send_DissMiss_Inforce();
  }

  public void CheckHasArmy()
  {
    int index1 = 0;
    this.TroopsTotal = 0L;
    this.NowHeightList.Clear();
    for (int index2 = 0; index2 < 16; ++index2)
    {
      int index3 = 3 - index2 / 4 + index2 % 4 * 4;
      if (this.DM.mSoldier_Embassy[index3] > 0U)
      {
        this.mTroopsIdx[index1] = (byte) index3;
        ++index1;
        this.NowHeightList.Add(39f);
        this.TroopsTotal += (long) this.DM.mSoldier_Embassy[index3];
      }
    }
    for (int index4 = 0; index4 < this.HasArmyGO.Length; ++index4)
      this.HasArmyGO[index4].SetActive(this.TroopsTotal > 0L);
    for (int index5 = 0; index5 < this.NoArmyGO.Length; ++index5)
      this.NoArmyGO[index5].SetActive(this.TroopsTotal <= 0L);
    if (this.TroopsTotal > 0L)
    {
      this.Scroll.AddNewDataHeight(this.NowHeightList);
      this.MaxStr.Length = 0;
      this.MaxStr.StringToFormat(this.DM.mStringTable.GetStringByID(4823U));
      this.MaxStr.IntToFormat(this.TroopsTotal, bNumber: true);
      this.MaxStr.IntToFormat((long) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_REINFORCE_CAPACITY), bNumber: true);
      this.MaxStr.AppendFormat("{0} {1} / {2}");
    }
    else
    {
      this.MaxStr.Length = 0;
      this.MaxStr.StringToFormat(this.DM.mStringTable.GetStringByID(4822U));
      this.MaxStr.IntToFormat((long) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_REINFORCE_CAPACITY), bNumber: true);
      this.MaxStr.AppendFormat("{0}{1}");
    }
    this.TitleText.text = this.MaxStr.ToString();
    this.TitleText.SetAllDirty();
    this.TitleText.cachedTextGenerator.Invalidate();
  }

  public void CheckHasAlly()
  {
    bool flag = this.DM.RoleAlliance.Id != 0U;
    this.NoAllyGO.SetActive(!flag);
    this.HasAllyGO.SetActive(flag);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelObjectIdx >= 10)
      return;
    if (!this.bFindScrollComp[panelObjectIdx])
    {
      this.bFindScrollComp[panelObjectIdx] = true;
      Transform transform = item.transform;
      this.Scroll_Comp[panelObjectIdx].TextL = transform.GetChild(0).GetComponent<UIText>();
      this.Scroll_Comp[panelObjectIdx].TextL.font = this.m_Font;
      this.Scroll_Comp[panelObjectIdx].TextR = transform.GetChild(1).GetComponent<UIText>();
      this.Scroll_Comp[panelObjectIdx].TextR.font = this.m_Font;
      this.Scroll_Comp[panelObjectIdx].KindImg = transform.GetChild(2).GetComponent<Image>();
      this.Scroll_Comp[panelObjectIdx].TierText = transform.GetChild(2).GetChild(0).GetComponent<UIText>();
      this.Scroll_Comp[panelObjectIdx].TierText.font = this.m_Font;
      this.Scroll_Comp[panelObjectIdx].TierText.resizeTextForBestFit = true;
      this.Scroll_Comp[panelObjectIdx].TierText.resizeTextMaxSize = 16;
      this.Scroll_Comp[panelObjectIdx].TierText.resizeTextMinSize = 10;
      this.Scroll_Comp[panelObjectIdx].HintRC = transform.GetChild(3).GetComponent<RectTransform>();
      this.Scroll_Comp[panelObjectIdx].Hint = transform.GetChild(3).gameObject.AddComponent<UIButtonHint>();
      this.Scroll_Comp[panelObjectIdx].Hint.m_eHint = EUIButtonHint.CountDown;
      this.Scroll_Comp[panelObjectIdx].Hint.DelayTime = 0.2f;
      this.Scroll_Comp[panelObjectIdx].Hint.m_Handler = (MonoBehaviour) this;
      this.Scroll_Comp[panelObjectIdx].Hint.Parm1 = (ushort) 0;
      this.ItemStrL[panelObjectIdx] = StringManager.Instance.SpawnString();
      this.ItemStrR[panelObjectIdx] = StringManager.Instance.SpawnString();
      this.TierStr[panelObjectIdx] = StringManager.Instance.SpawnString();
    }
    if (dataIdx < 0 || dataIdx >= this.mTroopsIdx.Length)
      return;
    this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) ((uint) this.mTroopsIdx[dataIdx] + 1U));
    this.Scroll_Comp[panelObjectIdx].Hint.Parm1 = (ushort) this.mTroopsIdx[dataIdx];
    this.Scroll_Comp[panelObjectIdx].KindImg.sprite = this.SA.GetSprite((int) this.tmpSD.SoldierKind);
    this.TierStr[panelObjectIdx].Length = 0;
    if ((int) this.tmpSD.Tier < GameConstants.numChar.Length)
      this.TierStr[panelObjectIdx].Append(GameConstants.numChar[(int) this.tmpSD.Tier]);
    this.Scroll_Comp[panelObjectIdx].TierText.text = this.TierStr[panelObjectIdx].ToString();
    this.Scroll_Comp[panelObjectIdx].TierText.SetAllDirty();
    this.Scroll_Comp[panelObjectIdx].TierText.cachedTextGenerator.Invalidate();
    this.ItemStrL[panelObjectIdx].Length = 0;
    this.ItemStrL[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name));
    this.Scroll_Comp[panelObjectIdx].TextL.text = this.ItemStrL[panelObjectIdx].ToString();
    this.Scroll_Comp[panelObjectIdx].TextL.SetAllDirty();
    this.Scroll_Comp[panelObjectIdx].TextL.cachedTextGenerator.Invalidate();
    this.Scroll_Comp[panelObjectIdx].TextL.cachedTextGeneratorForLayout.Invalidate();
    this.ItemStrR[panelObjectIdx].Length = 0;
    StringManager.IntToStr(this.ItemStrR[panelObjectIdx], (long) this.DM.mSoldier_Embassy[(int) this.mTroopsIdx[dataIdx]], bNumber: true);
    this.Scroll_Comp[panelObjectIdx].TextR.text = this.ItemStrR[panelObjectIdx].ToString();
    this.Scroll_Comp[panelObjectIdx].TextR.SetAllDirty();
    this.Scroll_Comp[panelObjectIdx].TextR.cachedTextGenerator.Invalidate();
    this.Scroll_Comp[panelObjectIdx].HintRC.sizeDelta = new Vector2(this.Scroll_Comp[panelObjectIdx].TextL.preferredWidth + 32f, 38.5f);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 3, 277f, 20, (int) sender.Parm1, 0, new Vector2(70f, 0.0f));
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Hide((bool) (Object) sender);
  }
}
