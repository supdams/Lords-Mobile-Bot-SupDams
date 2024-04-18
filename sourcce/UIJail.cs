// Decompiled with JetBrains decompiler
// Type: UIJail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIJail : 
  GUIWindow,
  IBuildingWindowType,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIHIBtnClickHandler
{
  private const float ScrollPanelHeight = 260f;
  private const float ScrollPanelUnitHeight = 86f;
  private Transform AGS_Form;
  private ScrollPanel AGS_ScrollPanel;
  private BuildingWindow baseBuild;
  private ushort B_ID;
  private Door door;
  private DataManager DM;
  private CString[] tmpString = new CString[4];
  private bool scrollPanelInit;
  private List<float> SPHeights;
  private List<byte> SPdispIdx;
  private CString[] SPName = new CString[4];
  private CString[] SPLv = new CString[4];
  private CString[] SPTime = new CString[4];
  private CString[] SPStat = new CString[4];
  private byte[] SPnowIdx = new byte[4];
  private Transform[] SPItem = new Transform[4];
  private bool ReflashFont;
  private bool NoReflashFont;
  private float GetPointTime;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.door = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
    this.B_ID = (ushort) arg1;
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    this.AGS_Form.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>().font = ttfFont;
    UIText component1 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.text = this.DM.mStringTable.GetStringByID(7752U);
    this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetComponent<UIText>().font = ttfFont;
    UIText component2 = this.AGS_Form.GetChild(2).GetChild(4).GetChild(0).GetComponent<UIText>();
    component2.text = this.DM.mStringTable.GetStringByID(7753U);
    component2.font = ttfFont;
    this.AGS_Form.GetChild(2).GetChild(4).GetChild(1).GetComponent<UIText>().font = ttfFont;
    this.AGS_Form.GetChild(2).GetChild(4).GetChild(3).GetComponent<UIText>().font = ttfFont;
    this.AGS_ScrollPanel = this.AGS_Form.GetChild(3).GetComponent<ScrollPanel>();
    UIText component3 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIText>();
    component3.text = this.DM.mStringTable.GetStringByID(7755U);
    component3.font = ttfFont;
    UIText component4 = this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIText>();
    component4.text = this.DM.mStringTable.GetStringByID(7756U);
    component4.font = ttfFont;
    this.AGS_Form.GetChild(5).gameObject.SetActive(false);
    this.AGS_Form.GetChild(5).GetChild(2).GetComponent<UIText>().font = ttfFont;
    this.AGS_Form.GetChild(5).GetChild(3).GetComponent<UIText>().font = ttfFont;
    this.AGS_Form.GetChild(5).GetChild(8).GetComponent<UIText>().font = ttfFont;
    this.AGS_Form.GetChild(5).GetChild(9).GetComponent<UIText>().font = ttfFont;
    this.AGS_Form.GetChild(5).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    for (int index = 0; index < 4; ++index)
      this.tmpString[index] = StringManager.Instance.SpawnString();
    for (int index = 0; index < 4; ++index)
    {
      this.SPName[index] = StringManager.Instance.SpawnString();
      this.SPLv[index] = StringManager.Instance.SpawnString();
      this.SPTime[index] = StringManager.Instance.SpawnString();
      this.SPStat[index] = StringManager.Instance.SpawnString();
    }
    this.updatePrisonerAmount();
    this.updateEff();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
    if (!this.DM.Prisoner_Requested)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_PRISONER_LIST;
      messagePacket.AddSeqId();
      messagePacket.Send();
    }
    else
    {
      this.UpdateScrollPanel();
      this.updateScrollPanelTimeBar();
    }
  }

  public override void OnClose()
  {
    if ((Object) this.baseBuild != (Object) null)
      this.baseBuild.DestroyBuildingWindow();
    for (int index = 0; index < 4; ++index)
      StringManager.Instance.DeSpawnString(this.tmpString[index]);
    for (int index = 0; index < 4; ++index)
    {
      StringManager.Instance.DeSpawnString(this.SPName[index]);
      StringManager.Instance.DeSpawnString(this.SPLv[index]);
      StringManager.Instance.DeSpawnString(this.SPTime[index]);
      StringManager.Instance.DeSpawnString(this.SPStat[index]);
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    this.updatePrisonerAmount();
    this.updateEff();
    this.UpdateScrollPanel();
    this.updateScrollPanelTimeBar();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_PRISONER_LIST;
        messagePacket.AddSeqId();
        messagePacket.Send();
        break;
      case NetworkNews.Refresh_BuildBase:
        if (meg[1] == (byte) 1)
        {
          this.door.CloseMenu(true);
          break;
        }
        if (!((Object) this.baseBuild != (Object) null))
          break;
        this.baseBuild.MyUpdate(meg[1]);
        break;
      case NetworkNews.Refresh_AttribEffectVal:
        if ((Object) this.baseBuild != (Object) null)
          this.baseBuild.MyUpdate((byte) 0);
        this.updateEff();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        if ((Object) this.baseBuild != (Object) null)
          this.baseBuild.Refresh_FontTexture();
        this.Refresh_FontTexture();
        break;
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!bOnSecond)
      return;
    this.updateScrollPanelTimeBar();
  }

  private void Start()
  {
    this.baseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    this.baseBuild.InitBuildingWindow((byte) 18, this.B_ID, (byte) 2, GUIManager.Instance.BuildingData.AllBuildsData[(int) this.B_ID].Level);
    Object.Destroy((Object) this.AGS_Form.GetChild(0).gameObject);
    this.baseBuild.baseTransform.SetAsFirstSibling();
    this.NoReflashFont = true;
  }

  public void Update()
  {
    this.NoReflashFont = false;
    if (this.ReflashFont)
      this.Refresh_FontTexture();
    this.updateScrollPanelLight();
  }

  public void OnButtonClick(UIButton sender)
  {
    this.door.OpenMenu(EGUIWindow.UI_JailRoom, sender.m_BtnID1, bCameraMode: true);
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    byte sortedPrisoner = this.DM.sortedPrisonerList[(int) this.SPdispIdx[dataIdx]];
    this.SPnowIdx[panelObjectIdx] = sortedPrisoner;
    this.SPItem[panelObjectIdx] = item.transform;
    GUIManager.Instance.InitianHeroItemImg(((Component) item.transform.GetChild(1).GetComponent<UIHIBtn>()).transform, eHeroOrItem.Hero, this.DM.PrisonerList[(int) sortedPrisoner].head, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
    UIText component1 = item.transform.GetChild(2).GetComponent<UIText>();
    this.SPLv[panelObjectIdx].ClearString();
    this.SPLv[panelObjectIdx].IntToFormat((long) this.DM.PrisonerList[(int) sortedPrisoner].LordLevel);
    this.SPLv[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7757U));
    component1.text = this.SPLv[panelObjectIdx].ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    UIText component2 = item.transform.GetChild(3).GetComponent<UIText>();
    this.SPName[panelObjectIdx].ClearString();
    GameConstants.GetNameString(this.SPName[panelObjectIdx], this.DM.PrisonerList[(int) sortedPrisoner].KingdomID, this.DM.PrisonerList[(int) sortedPrisoner].name, this.DM.PrisonerList[(int) sortedPrisoner].AlliTag);
    component2.text = this.SPName[panelObjectIdx].ToString();
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
    UIText component3 = item.transform.GetChild(8).GetComponent<UIText>();
    UISpritesArray component4 = item.transform.GetChild(6).GetComponent<UISpritesArray>();
    long sec = this.DM.PrisonerList[(int) sortedPrisoner].StartActionTime + (long) this.DM.PrisonerList[(int) sortedPrisoner].TotalTime - this.DM.ServerTime;
    if (sec < 0L)
      sec = 0L;
    RectTransform component5 = item.transform.GetChild(6).GetComponent<RectTransform>();
    this.SPStat[panelObjectIdx].ClearString();
    switch (this.DM.PrisonerList[(int) sortedPrisoner].nowStat)
    {
      case PrisonerState.WaitForRelease:
        this.SPStat[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(7768U));
        component4.SetSpriteIndex(2);
        item.transform.GetChild(4).gameObject.SetActive(false);
        float num1 = Mathf.Clamp01(1f - (float) sec / (float) this.DM.PrisonerList[(int) sortedPrisoner].TotalTime);
        component5.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num1 * (float) byte.MaxValue);
        break;
      case PrisonerState.WaitForExecute:
        if (sec > 21600L)
        {
          sec -= 21600L;
          this.SPStat[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(7759U));
          component4.SetSpriteIndex(1);
          item.transform.GetChild(4).gameObject.SetActive(false);
          float num2 = Mathf.Clamp01(1f - (float) sec / (float) (this.DM.PrisonerList[(int) sortedPrisoner].TotalTime - 21600U));
          component5.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num2 * (float) byte.MaxValue);
          break;
        }
        this.SPStat[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(7758U));
        component4.SetSpriteIndex(0);
        item.transform.GetChild(4).gameObject.SetActive(true);
        item.transform.GetChild(4).GetComponent<UISpritesArray>().SetSpriteIndex(0);
        float num3 = Mathf.Clamp01(1f - (float) sec / 21600f);
        component5.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num3 * (float) byte.MaxValue);
        break;
      case PrisonerState.Poisoned:
        this.SPStat[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(15008U));
        component4.SetSpriteIndex(3);
        item.transform.GetChild(4).gameObject.SetActive(true);
        item.transform.GetChild(4).GetComponent<UISpritesArray>().SetSpriteIndex(1);
        float num4 = Mathf.Clamp01(1f - (float) sec / (float) this.DM.PrisonerList[(int) sortedPrisoner].TotalTime);
        component5.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num4 * (float) byte.MaxValue);
        break;
    }
    component3.text = this.SPStat[panelObjectIdx].ToString();
    component3.SetAllDirty();
    component3.cachedTextGenerator.Invalidate();
    UIText component6 = item.transform.GetChild(9).GetComponent<UIText>();
    this.SPTime[panelObjectIdx].ClearString();
    GameConstants.GetTimeString(this.SPTime[panelObjectIdx], (uint) sec, true, true);
    component6.text = this.SPTime[panelObjectIdx].ToString();
    component6.SetAllDirty();
    component6.cachedTextGenerator.Invalidate();
    UIButton component7 = item.transform.GetChild(0).GetComponent<UIButton>();
    component7.m_BtnID1 = (int) this.SPdispIdx[dataIdx];
    component7.m_Handler = (IUIButtonClickHandler) this;
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
    {
      this.AGS_Form.GetChild(1).gameObject.SetActive(true);
      this.AGS_Form.GetChild(2).gameObject.SetActive(true);
      this.AGS_Form.GetChild(3).gameObject.SetActive(true);
      this.updatePrisonerAmount();
    }
    else
    {
      this.AGS_Form.GetChild(1).gameObject.SetActive(false);
      this.AGS_Form.GetChild(2).gameObject.SetActive(false);
      this.AGS_Form.GetChild(3).gameObject.SetActive(false);
      this.AGS_Form.GetChild(4).gameObject.SetActive(false);
    }
  }

  public void Refresh_FontTexture()
  {
    if (this.NoReflashFont)
    {
      this.ReflashFont = true;
    }
    else
    {
      UIText component1 = this.AGS_Form.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
      if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
      {
        ((Behaviour) component1).enabled = false;
        ((Behaviour) component1).enabled = true;
      }
      UIText component2 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetComponent<UIText>();
      if ((Object) component2 != (Object) null && ((Behaviour) component2).enabled)
      {
        ((Behaviour) component2).enabled = false;
        ((Behaviour) component2).enabled = true;
      }
      UIText component3 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetComponent<UIText>();
      if ((Object) component3 != (Object) null && ((Behaviour) component3).enabled)
      {
        ((Behaviour) component3).enabled = false;
        ((Behaviour) component3).enabled = true;
      }
      UIText component4 = this.AGS_Form.GetChild(2).GetChild(4).GetChild(0).GetComponent<UIText>();
      if ((Object) component4 != (Object) null && ((Behaviour) component4).enabled)
      {
        ((Behaviour) component4).enabled = false;
        ((Behaviour) component4).enabled = true;
      }
      UIText component5 = this.AGS_Form.GetChild(2).GetChild(4).GetChild(1).GetComponent<UIText>();
      if ((Object) component5 != (Object) null && ((Behaviour) component5).enabled)
      {
        ((Behaviour) component5).enabled = false;
        ((Behaviour) component5).enabled = true;
      }
      UIText component6 = this.AGS_Form.GetChild(2).GetChild(4).GetChild(3).GetComponent<UIText>();
      if ((Object) component6 != (Object) null && ((Behaviour) component6).enabled)
      {
        ((Behaviour) component6).enabled = false;
        ((Behaviour) component6).enabled = true;
      }
      UIText component7 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIText>();
      if ((Object) component7 != (Object) null && ((Behaviour) component7).enabled)
      {
        ((Behaviour) component7).enabled = false;
        ((Behaviour) component7).enabled = true;
      }
      UIText component8 = this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIText>();
      if ((Object) component8 != (Object) null && ((Behaviour) component8).enabled)
      {
        ((Behaviour) component8).enabled = false;
        ((Behaviour) component8).enabled = true;
      }
      if (!((Object) this.AGS_ScrollPanel != (Object) null) || !this.AGS_ScrollPanel.gameObject.activeInHierarchy || this.AGS_ScrollPanel.transform.childCount <= 1)
        return;
      Transform child1 = this.AGS_ScrollPanel.transform.GetChild(0);
      for (int index = 0; index < child1.childCount; ++index)
      {
        Transform child2 = child1.GetChild(index);
        if (child2.gameObject.activeInHierarchy)
        {
          UIText component9 = child2.GetChild(2).GetComponent<UIText>();
          if ((Object) component9 != (Object) null && ((Behaviour) component9).enabled)
          {
            ((Behaviour) component9).enabled = false;
            ((Behaviour) component9).enabled = true;
          }
          UIText component10 = child2.GetChild(3).GetComponent<UIText>();
          if ((Object) component10 != (Object) null && ((Behaviour) component10).enabled)
          {
            ((Behaviour) component10).enabled = false;
            ((Behaviour) component10).enabled = true;
          }
          UIText component11 = child2.GetChild(8).GetComponent<UIText>();
          if ((Object) component11 != (Object) null && ((Behaviour) component11).enabled)
          {
            ((Behaviour) component11).enabled = false;
            ((Behaviour) component11).enabled = true;
          }
          UIText component12 = child2.GetChild(9).GetComponent<UIText>();
          if ((Object) component12 != (Object) null && ((Behaviour) component12).enabled)
          {
            ((Behaviour) component12).enabled = false;
            ((Behaviour) component12).enabled = true;
          }
        }
      }
    }
  }

  public void UpdateScrollPanel(bool newList = false)
  {
    if (!this.scrollPanelInit)
    {
      this.scrollPanelInit = true;
      this.SPHeights = new List<float>();
      this.SPdispIdx = new List<byte>();
      this.AGS_ScrollPanel.IntiScrollPanel(260f, 0.0f, 0.0f, this.SPHeights, 4, (IUpDateScrollPanel) this);
    }
    this.SPHeights.Clear();
    this.SPdispIdx.Clear();
    for (byte index = 0; (int) index < this.DM.PrisonerList.Length && this.DM.PrisonerList[(int) this.DM.sortedPrisonerList[(int) index]].nowStat != PrisonerState.None; ++index)
    {
      if (this.DM.PrisonerList[(int) this.DM.sortedPrisonerList[(int) index]].nowStat > PrisonerState.None)
      {
        this.SPHeights.Add(86f);
        this.SPdispIdx.Add(index);
      }
    }
    this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeights, 260f, newList);
  }

  private void updateScrollPanelTimeBar()
  {
    for (int index = 0; index < 4; ++index)
    {
      if ((Object) this.SPItem[index] != (Object) null)
      {
        RectTransform component1 = this.SPItem[index].GetChild(6).GetComponent<RectTransform>();
        long sec = this.DM.PrisonerList[(int) this.SPnowIdx[index]].StartActionTime + (long) this.DM.PrisonerList[(int) this.SPnowIdx[index]].TotalTime - this.DM.ServerTime;
        if (sec < 0L)
          sec = 0L;
        switch (this.DM.PrisonerList[(int) this.SPnowIdx[index]].nowStat)
        {
          case PrisonerState.WaitForRelease:
            float num1 = Mathf.Clamp01(1f - (float) sec / (float) this.DM.PrisonerList[(int) this.SPnowIdx[index]].TotalTime);
            component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num1 * (float) byte.MaxValue);
            break;
          case PrisonerState.WaitForExecute:
            if (sec > 21600L)
            {
              sec -= 21600L;
              float num2 = Mathf.Clamp01(1f - (float) sec / (float) (this.DM.PrisonerList[(int) this.SPnowIdx[index]].TotalTime - 21600U));
              component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num2 * (float) byte.MaxValue);
              UIText component2 = this.SPItem[index].GetChild(8).GetComponent<UIText>();
              this.SPStat[index].ClearString();
              this.SPStat[index].Append(this.DM.mStringTable.GetStringByID(7759U));
              component2.text = this.SPStat[index].ToString();
              component2.SetAllDirty();
              component2.cachedTextGenerator.Invalidate();
              this.SPItem[index].GetChild(6).GetComponent<UISpritesArray>().SetSpriteIndex(1);
              this.SPItem[index].GetChild(4).gameObject.SetActive(false);
              break;
            }
            float num3 = Mathf.Clamp01(1f - (float) sec / 21600f);
            component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num3 * (float) byte.MaxValue);
            UIText component3 = this.SPItem[index].GetChild(8).GetComponent<UIText>();
            this.SPStat[index].ClearString();
            this.SPStat[index].Append(this.DM.mStringTable.GetStringByID(7758U));
            component3.text = this.SPStat[index].ToString();
            component3.SetAllDirty();
            component3.cachedTextGenerator.Invalidate();
            this.SPItem[index].GetChild(6).GetComponent<UISpritesArray>().SetSpriteIndex(0);
            this.SPItem[index].GetChild(4).gameObject.SetActive(true);
            break;
          case PrisonerState.Poisoned:
            float num4 = Mathf.Clamp01(1f - (float) sec / (float) this.DM.PrisonerList[(int) this.SPnowIdx[index]].TotalTime);
            component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num4 * (float) byte.MaxValue);
            break;
        }
        UIText component4 = this.SPItem[index].GetChild(9).GetComponent<UIText>();
        this.SPTime[index].ClearString();
        GameConstants.GetTimeString(this.SPTime[index], (uint) sec, true, true);
        component4.text = this.SPTime[index].ToString();
        component4.SetAllDirty();
        component4.cachedTextGenerator.Invalidate();
        float preferredWidth = component4.preferredWidth;
        ((Graphic) this.SPItem[index].GetChild(8).GetComponent<UIText>()).rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 235f - preferredWidth);
      }
    }
  }

  private void updateScrollPanelLight()
  {
    if ((Object) this.SPItem[0] == (Object) null)
      return;
    this.GetPointTime += Time.smoothDeltaTime;
    if ((double) this.GetPointTime >= 2.0)
      this.GetPointTime = 0.0f;
    float a = (double) this.GetPointTime <= 1.0 ? this.GetPointTime : 2f - this.GetPointTime;
    for (int index = 0; index < 4; ++index)
    {
      if ((Object) this.SPItem[index] != (Object) null && this.SPItem[index].GetChild(4).gameObject.activeInHierarchy)
        ((Graphic) this.SPItem[index].GetChild(4).GetComponent<Image>()).color = new Color(1f, 1f, 1f, a);
    }
  }

  private void updatePrisonerAmount()
  {
    if (!this.DM.Prisoner_Requested)
    {
      this.AGS_Form.GetChild(4).gameObject.SetActive(false);
      this.AGS_Form.GetChild(4).gameObject.SetActive(false);
    }
    else if ((Object) this.baseBuild != (Object) null && (this.baseBuild.buildType == e_BuildType.Normal || this.baseBuild.buildType == e_BuildType.SelfUpgradeing || this.baseBuild.buildType == e_BuildType.SelfBackOuting))
    {
      if (this.DM.PrisonerNum == (byte) 0)
      {
        this.AGS_Form.GetChild(4).gameObject.SetActive(true);
        this.AGS_Form.GetChild(3).gameObject.SetActive(false);
      }
      else
      {
        this.AGS_Form.GetChild(4).gameObject.SetActive(false);
        this.AGS_Form.GetChild(3).gameObject.SetActive(true);
      }
    }
    UIText component1 = this.AGS_Form.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.tmpString[1].ClearString();
    this.tmpString[1].IntToFormat((long) this.DM.PrisonerNum);
    this.tmpString[1].IntToFormat(30L);
    this.tmpString[1].StringToFormat(this.DM.mStringTable.GetStringByID(7751U));
    this.tmpString[1].AppendFormat("{2}\n{0} / {1}");
    component1.text = this.tmpString[1].ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    DataManager.Instance.LevelUpTable.GetRecordByKey((ushort) this.DM.PrisonerHighestLevel);
    UIText component2 = this.AGS_Form.GetChild(2).GetChild(4).GetChild(1).GetComponent<UIText>();
    this.tmpString[2].ClearString();
    if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 18, (ushort) 0).Level == (byte) 25)
    {
      if (this.DM.PrisonerHighestLevel != (byte) 0)
        this.tmpString[2].FloatToFormat((float) this.DM.LevelUpTable.GetRecordByKey((ushort) this.DM.PrisonerHighestLevel).PrisonEffect / 100f, 2, false);
      else
        this.tmpString[2].IntToFormat(0L);
      if (!GUIManager.Instance.IsArabic)
        this.tmpString[2].AppendFormat("{0}%");
      else
        this.tmpString[2].AppendFormat("%{0}");
      component2.text = this.tmpString[2].ToString();
    }
    else
      component2.text = DataManager.Instance.mStringTable.GetStringByID(7797U);
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
    UIText component3 = this.AGS_Form.GetChild(2).GetChild(4).GetChild(3).GetComponent<UIText>();
    this.tmpString[3].ClearString();
    this.tmpString[3].IntToFormat((long) this.DM.PrisonerHighestLevel);
    this.tmpString[3].AppendFormat(this.DM.mStringTable.GetStringByID(7754U));
    component3.text = this.tmpString[3].ToString();
    component3.SetAllDirty();
    component3.cachedTextGenerator.Invalidate();
  }

  private void updateEff()
  {
    UIText component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetComponent<UIText>();
    this.tmpString[0].ClearString();
    GameConstants.GetTimeInfoString(this.tmpString[0], DataManager.Instance.AttribVal.GetEffectBaseValByEffectID((ushort) 305));
    component.text = this.tmpString[0].ToString();
    component.SetAllDirty();
    component.cachedTextGenerator.Invalidate();
  }

  private enum e_AGS_UI_Jail_Editor
  {
    BuildingWindow,
    back,
    header,
    scrollview,
    NoItem,
    Scrollitem,
  }

  private enum e_AGS_header
  {
    IronBox,
    Chain1,
    Chain2,
    block1,
    block2,
    scrollbg,
  }

  private enum e_AGS_IronBox
  {
    Text,
  }

  private enum e_AGS_block1
  {
    desc,
    Time,
    icon,
  }

  private enum e_AGS_block2
  {
    desc,
    content,
    icon,
    desc2,
  }

  private enum e_AGS_NoItem
  {
    noOne,
    desc,
  }

  private enum e_AGS_Scrollitem
  {
    BG,
    UIHIBtn,
    Level,
    Name,
    BarBackLight,
    Barbg,
    Bar,
    UIButton,
    FuncName,
    Time,
  }
}
