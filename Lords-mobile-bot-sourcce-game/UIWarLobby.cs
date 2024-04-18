// Decompiled with JetBrains decompiler
// Type: UIWarLobby
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIWarLobby : GUIWindow, IBuildingWindowType, IUIButtonClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private BuildingWindow baseBuild;
  private Transform ThisTransform;
  private Transform MessageTrans;
  private RectTransform AttackTrans;
  private RectTransform DefenceTrans;
  private RectTransform TeamTrans;
  private UIText RecruitText;
  private UIText AttackText;
  private UIText DefenceText;
  private UIText[] TextReflash = new UIText[4];
  private CString RecruitStr;
  private CString AttackStr;
  private CString DefenceStr;
  private RectTransform IconRect;
  private int ManorID;

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
    }
  }

  private void Start()
  {
    this.baseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    RoleBuildingData roleBuildingData = this.GUIM.BuildingData.AllBuildsData[this.ManorID];
    this.baseBuild.InitBuildingWindow((byte) roleBuildingData.BuildID, (ushort) this.ManorID, (byte) 2, roleBuildingData.Level);
    this.baseBuild.baseTransform.SetAsFirstSibling();
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.ThisTransform = this.transform.GetChild(0);
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.ManorID = arg1;
    Font ttfFont = this.GUIM.GetTTFFont();
    this.RecruitStr = StringManager.Instance.SpawnString(100);
    this.AttackStr = StringManager.Instance.SpawnString();
    this.DefenceStr = StringManager.Instance.SpawnString();
    this.RecruitText = this.ThisTransform.GetChild(1).GetComponent<UIText>();
    this.RecruitText.font = ttfFont;
    this.AttackTrans = this.ThisTransform.GetChild(3).GetComponent<RectTransform>();
    this.AttackText = this.ThisTransform.GetChild(3).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.AttackText.font = ttfFont;
    UIText component1 = this.ThisTransform.GetChild(3).GetChild(2).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.text = this.DM.mStringTable.GetStringByID(4862U);
    this.TextReflash[0] = component1;
    UIButton component2 = this.ThisTransform.GetChild(3).GetChild(1).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 0;
    this.DefenceTrans = this.ThisTransform.GetChild(4).GetComponent<RectTransform>();
    this.DefenceText = this.ThisTransform.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.DefenceText.font = ttfFont;
    UIText component3 = this.ThisTransform.GetChild(4).GetChild(2).GetComponent<UIText>();
    component3.font = ttfFont;
    component3.text = this.DM.mStringTable.GetStringByID(4863U);
    this.TextReflash[1] = component3;
    UIButton component4 = this.ThisTransform.GetChild(4).GetChild(1).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_BtnID1 = 1;
    this.TeamTrans = this.ThisTransform.GetChild(5).GetComponent<RectTransform>();
    UIText component5 = this.ThisTransform.GetChild(5).GetChild(2).GetComponent<UIText>();
    component5.font = ttfFont;
    component5.text = this.DM.mStringTable.GetStringByID(990U);
    this.TextReflash[2] = component5;
    UIButton component6 = this.ThisTransform.GetChild(5).GetChild(1).GetComponent<UIButton>();
    component6.m_Handler = (IUIButtonClickHandler) this;
    component6.m_BtnID1 = 2;
    this.IconRect = this.ThisTransform.GetChild(2).GetComponent<RectTransform>();
    this.MessageTrans = this.ThisTransform.GetChild(6);
    UIText component7 = this.MessageTrans.GetChild(0).GetComponent<UIText>();
    component7.font = ttfFont;
    component7.text = this.DM.mStringTable.GetStringByID(5781U);
    this.TextReflash[3] = component7;
    this.UpdateFunctionState();
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    this.DM.CheckWalHall_List();
    this.UpdateRecruitNum();
  }

  public void UpdateFunctionState()
  {
    if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 20)
    {
      this.AttackTrans.anchoredPosition = Vector2.zero;
      this.DefenceTrans.anchoredPosition = Vector2.zero;
      ((Component) this.TeamTrans).gameObject.SetActive(false);
    }
    else
    {
      this.AttackTrans.anchoredPosition = new Vector2(-82f, 0.0f);
      this.DefenceTrans.anchoredPosition = new Vector2(-174f, 0.0f);
      ((Component) this.TeamTrans).gameObject.SetActive(true);
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    switch (sender.m_BtnID1)
    {
      case 0:
        if (DataManager.Instance.RoleAlliance.Id == 0U)
        {
          this.GUIM.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5781U), (ushort) byte.MaxValue);
          break;
        }
        this.GUIM.MarshalSaved = (byte) 1;
        menu.OpenMenu(EGUIWindow.UI_Alliance_Info, 1);
        break;
      case 1:
        if (DataManager.Instance.RoleAlliance.Id == 0U)
        {
          this.GUIM.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5781U), (ushort) byte.MaxValue);
          break;
        }
        this.GUIM.MarshalSaved = (byte) 2;
        menu.OpenMenu(EGUIWindow.UI_Alliance_Info, 1);
        break;
      case 2:
        menu.OpenMenu(EGUIWindow.UI_TeamSave);
        break;
    }
  }

  public override void OnClose()
  {
    if ((Object) this.baseBuild != (Object) null)
      this.baseBuild.DestroyBuildingWindow();
    StringManager.Instance.DeSpawnString(this.RecruitStr);
    StringManager.Instance.DeSpawnString(this.AttackStr);
    StringManager.Instance.DeSpawnString(this.DefenceStr);
  }

  public void UpdateRecruitNum()
  {
    uint x = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RALLY_CAPACITY) + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_PETSKILL_RALLY_CAPACITY);
    this.RecruitStr.ClearString();
    if (this.DM.Sponsor > (ushort) 0 && this.DM.WarHall[0] != null && this.DM.WarHall[0].Count >= (int) this.DM.Sponsor)
    {
      WarlobbyData warlobbyData = this.DM.WarHall[0][(int) this.DM.Sponsor - 1];
      this.RecruitStr.StringToFormat(this.DM.mStringTable.GetStringByID(4861U));
      this.RecruitStr.IntToFormat((long) warlobbyData.AllyCurrTroop, bNumber: true);
      this.RecruitStr.IntToFormat((long) warlobbyData.AllyMAXTroop, bNumber: true);
      this.RecruitStr.AppendFormat("{0} {1} / {2}");
    }
    else
    {
      this.RecruitStr.StringToFormat(this.DM.mStringTable.GetStringByID(4860U));
      this.RecruitStr.IntToFormat((long) x, bNumber: true);
      this.RecruitStr.AppendFormat("{0}{1}");
    }
    this.RecruitText.text = this.RecruitStr.ToString();
    this.RecruitText.SetAllDirty();
    this.RecruitText.cachedTextGenerator.Invalidate();
    this.RecruitText.cachedTextGeneratorForLayout.Invalidate();
    this.IconRect.anchoredPosition = this.IconRect.anchoredPosition with
    {
      x = (float) (-(double) this.RecruitText.preferredWidth * 0.5 - 26.0)
    };
    if (DataManager.Instance.RoleAlliance.Id == 0U && GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 20)
    {
      ((Component) this.AttackTrans).gameObject.SetActive(false);
      ((Component) this.DefenceTrans).gameObject.SetActive(false);
      this.MessageTrans.gameObject.SetActive(true);
    }
    else
    {
      this.AttackStr.ClearString();
      if (this.DM.ActiveRallyRecNum == 0U)
      {
        this.AttackStr.Append(this.DM.mStringTable.GetStringByID(4865U));
      }
      else
      {
        this.AttackStr.StringToFormat(this.DM.mStringTable.GetStringByID(4864U));
        this.AttackStr.IntToFormat((long) this.DM.ActiveRallyRecNum);
        this.AttackStr.AppendFormat("{0} : {1}");
      }
      this.AttackText.text = this.AttackStr.ToString();
      this.AttackText.SetAllDirty();
      this.AttackText.cachedTextGenerator.Invalidate();
      this.DefenceStr.ClearString();
      if (this.DM.BeingRallyRecNum == 0U)
      {
        this.DefenceStr.Append(this.DM.mStringTable.GetStringByID(4867U));
      }
      else
      {
        this.DefenceStr.StringToFormat(this.DM.mStringTable.GetStringByID(4866U));
        this.DefenceStr.IntToFormat((long) this.DM.BeingRallyRecNum);
        this.DefenceStr.AppendFormat("{0} : {1}");
      }
      this.DefenceText.text = this.DefenceStr.ToString();
      this.DefenceText.SetAllDirty();
      this.DefenceText.cachedTextGenerator.Invalidate();
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        DataManager.Instance.CheckWalHall_List();
        break;
      case NetworkNews.Refresh_BuildBase:
        this.UpdateFunctionState();
        if (!((Object) this.baseBuild != (Object) null))
          break;
        this.baseBuild.MyUpdate(meg[1]);
        break;
      case NetworkNews.Refresh_AttribEffectVal:
        if ((Object) this.baseBuild != (Object) null)
          this.baseBuild.MyUpdate((byte) 0);
        this.UpdateRecruitNum();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        if ((Object) this.baseBuild != (Object) null)
          this.baseBuild.Refresh_FontTexture();
        ((Behaviour) this.RecruitText).enabled = false;
        ((Behaviour) this.RecruitText).enabled = true;
        ((Behaviour) this.AttackText).enabled = false;
        ((Behaviour) this.AttackText).enabled = true;
        ((Behaviour) this.DefenceText).enabled = false;
        ((Behaviour) this.DefenceText).enabled = true;
        for (int index = 0; index < this.TextReflash.Length; ++index)
        {
          ((Behaviour) this.TextReflash[index]).enabled = false;
          ((Behaviour) this.TextReflash[index]).enabled = true;
        }
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2) => this.UpdateRecruitNum();

  private enum UIControl
  {
    Image,
    RecruitText,
    Icon,
    Attack,
    Defence,
    Team,
    Message,
  }

  private enum ClickType
  {
    Attack,
    Defence,
    Team,
  }
}
