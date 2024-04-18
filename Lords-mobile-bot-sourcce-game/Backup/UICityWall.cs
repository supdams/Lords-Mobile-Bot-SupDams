// Decompiled with JetBrains decompiler
// Type: UICityWall
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UICityWall : 
  GUIWindow,
  IBuildingWindowType,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler
{
  private const float MaxSliderValue = 154f;
  private const float MaxWallRePaireSliderValue = 145f;
  private const int TextMax = 5;
  private BuildingWindow baseBuild;
  private Transform m_Panel;
  private Image[] m_SliderValues = new Image[4];
  private UIText[] m_SliderTexts = new UIText[4];
  private CString[] m_Str = new CString[5];
  private Image[] m_TypeImage = new Image[3];
  private UISpritesArray m_SprryArray;
  private Image m_WallImageIcon;
  private int B_ID;
  private DataManager DM;
  private float m_SliderTimeTick;
  private int m_SelectDefender;
  private Image m_ArrowRepair;
  private Image m_Image;
  private int mTextCount;
  private UIText[] m_tmptext = new UIText[5];

  public override void OnOpen(int arg1, int arg2)
  {
    this.B_ID = arg1;
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.DM = DataManager.Instance;
    this.m_SliderTimeTick = 1f;
    this.m_Panel = this.transform.GetChild(0);
    for (int index = 0; index < this.m_Str.Length; ++index)
      this.m_Str[index] = StringManager.Instance.SpawnString();
    uint[] numArray = new uint[4]
    {
      3744U,
      3746U,
      3748U,
      3750U
    };
    for (int index = 0; index < 4; ++index)
    {
      Transform child = this.m_Panel.GetChild(index);
      UIButton component = child.GetComponent<UIButton>();
      component.m_Handler = (IUIButtonClickHandler) this;
      component.m_BtnID1 = index;
      this.m_tmptext[this.mTextCount] = child.GetChild(1).GetChild(0).GetComponent<UIText>();
      this.m_tmptext[this.mTextCount].text = DataManager.Instance.mStringTable.GetStringByID(numArray[index]);
      this.m_tmptext[this.mTextCount].font = ttfFont;
      ++this.mTextCount;
      this.m_SliderValues[index] = child.GetChild(2).GetChild(0).GetComponent<Image>();
      this.m_SliderTexts[index] = child.GetChild(2).GetChild(1).GetComponent<UIText>();
      this.m_SliderTexts[index].font = ttfFont;
    }
    this.m_WallImageIcon = this.m_Panel.GetChild(1).GetChild(4).GetComponent<Image>();
    UIButtonHint uiButtonHint = ((Component) this.m_WallImageIcon).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint.m_Handler = (MonoBehaviour) this;
    ((Component) this.m_WallImageIcon).gameObject.SetActive(true);
    this.m_TypeImage[0] = this.m_Panel.GetChild(0).GetChild(3).GetComponent<Image>();
    this.m_TypeImage[1] = this.m_Panel.GetChild(1).GetChild(3).GetComponent<Image>();
    this.m_TypeImage[2] = this.m_Panel.GetChild(3).GetChild(3).GetComponent<Image>();
    for (int index = 0; index < this.m_TypeImage.Length; ++index)
      ((Behaviour) this.m_TypeImage[index]).enabled = false;
    this.m_ArrowRepair = this.m_Panel.GetChild(0).GetChild(4).GetComponent<Image>();
    this.m_Image = this.m_Panel.GetChild(2).GetChild(3).GetComponent<Image>();
    if (GUIManager.Instance.BuildingData.GuideSoldierID >= (ushort) 17 && GUIManager.Instance.BuildingData.GuideSoldierID <= (ushort) 28)
      ((Component) this.m_Image).gameObject.SetActive(true);
    if (GUIManager.Instance.BuildingData.GuideSoldierID == (ushort) 30)
      ((Component) this.m_ArrowRepair).gameObject.SetActive(true);
    this.m_tmptext[this.mTextCount] = this.m_Panel.GetChild(4).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    ++this.mTextCount;
    this.m_SprryArray = this.transform.GetComponent<UISpritesArray>();
    this.baseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.InitBuildingWindow((byte) 12, (ushort) arg1, (byte) 2, (byte) 0);
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    this.baseBuild.baseTransform.SetAsFirstSibling();
    this.OnTypeChange(this.baseBuild.buildType);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
    this.SetTrapSlider(this.DM.TrapTotal, this.DM.GetMaxTrapValue());
    this.SeteTrapRepair(this.DM.TrapHospitalTotal, this.DM.GetMaxTrapValue());
    this.m_SelectDefender = 0;
    for (int index = 0; index < this.DM.m_DefendersID.Length; ++index)
    {
      if (this.DM.m_DefendersID[index] != (ushort) 0)
        ++this.m_SelectDefender;
    }
    this.SetDefenderSlider(this.m_SelectDefender, this.DM.GetMaxDefenders());
  }

  private void Update()
  {
    this.SetWallRePaireSlider(this.DM.m_WallRepairNowValue, this.DM.m_WallRepairMaxValue, Time.deltaTime);
  }

  private void GetWallRepairMaxValue()
  {
    this.DM.m_WallRepairMaxValue = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_WALL_HEALTH);
  }

  private void SetWallRePaireSlider(uint value, uint max, float deltaTime)
  {
    ((Graphic) this.m_SliderValues[1]).rectTransform.sizeDelta = new Vector2(Mathf.Clamp((float) value / (float) max, 0.0f, 1f) * 145f, ((Graphic) this.m_SliderValues[1]).rectTransform.sizeDelta.y);
    this.m_SliderTimeTick += Time.deltaTime;
    if ((double) this.m_SliderTimeTick >= 1.0)
    {
      this.m_Str[1].ClearString();
      StringManager.Instance.IntToFormat((long) value, bNumber: true);
      StringManager.Instance.IntToFormat((long) max, bNumber: true);
      if (GUIManager.Instance.IsArabic)
        this.m_Str[1].AppendFormat("{1} / {0}");
      else
        this.m_Str[1].AppendFormat("{0} / {1}");
      this.m_SliderTexts[1].text = this.m_Str[1].ToString();
      this.m_SliderTimeTick = 0.0f;
      this.m_SliderTexts[1].SetAllDirty();
      this.m_SliderTexts[1].cachedTextGenerator.Invalidate();
    }
    if (value < max)
      ((Behaviour) this.m_TypeImage[1]).enabled = true;
    else
      ((Behaviour) this.m_TypeImage[1]).enabled = false;
  }

  private void SetTrapSlider(uint value, uint max)
  {
    ((Graphic) this.m_SliderValues[2]).rectTransform.sizeDelta = new Vector2(Mathf.Clamp((float) value / (float) max, 0.0f, 1f) * 154f, ((Graphic) this.m_SliderValues[2]).rectTransform.sizeDelta.y);
    this.m_Str[2].ClearString();
    StringManager.Instance.IntToFormat((long) value, bNumber: true);
    StringManager.Instance.IntToFormat((long) max, bNumber: true);
    if (GUIManager.Instance.IsArabic)
      this.m_Str[2].AppendFormat("{1} / {0}");
    else
      this.m_Str[2].AppendFormat("{0} / {1}");
    this.m_SliderTexts[2].text = this.m_Str[2].ToString();
    this.m_SliderTexts[2].SetAllDirty();
    this.m_SliderTexts[2].cachedTextGenerator.Invalidate();
  }

  private void SetDefenderSlider(int value, int max)
  {
    ((Graphic) this.m_SliderValues[0]).rectTransform.sizeDelta = new Vector2(Mathf.Clamp((float) value / (float) max, 0.0f, 1f) * 154f, ((Graphic) this.m_SliderValues[0]).rectTransform.sizeDelta.y);
    this.m_Str[0].ClearString();
    StringManager.Instance.IntToFormat((long) value, bNumber: true);
    StringManager.Instance.IntToFormat((long) max, bNumber: true);
    if (GUIManager.Instance.IsArabic)
      this.m_Str[0].AppendFormat("{1} / {0}");
    else
      this.m_Str[0].AppendFormat("{0} / {1}");
    this.m_SliderTexts[0].text = this.m_Str[0].ToString();
    this.m_SliderTexts[0].SetAllDirty();
    this.m_SliderTexts[0].cachedTextGenerator.Invalidate();
    bool flag = false;
    for (int index = 0; index < this.DM.FightHeroID.Length; ++index)
    {
      if ((int) this.DM.FightHeroID[index] == (int) this.DM.GetLeaderID())
      {
        flag = true;
        break;
      }
    }
    if (value < max)
    {
      this.m_TypeImage[0].sprite = this.m_SprryArray.GetSprite(0);
      ((Behaviour) this.m_TypeImage[0]).enabled = true;
    }
    else if (flag)
    {
      this.m_TypeImage[0].sprite = this.m_SprryArray.GetSprite(1);
      ((Behaviour) this.m_TypeImage[0]).enabled = true;
    }
    else
      ((Behaviour) this.m_TypeImage[0]).enabled = false;
  }

  private void SeteTrapRepair(uint value, uint max)
  {
    ((Graphic) this.m_SliderValues[3]).rectTransform.sizeDelta = new Vector2(Mathf.Clamp((float) value / (float) max, 0.0f, 1f) * 154f, ((Graphic) this.m_SliderValues[3]).rectTransform.sizeDelta.y);
    this.m_Str[3].ClearString();
    StringManager.Instance.IntToFormat((long) value, bNumber: true);
    StringManager.Instance.IntToFormat((long) max, bNumber: true);
    if (GUIManager.Instance.IsArabic)
      this.m_Str[3].AppendFormat("{1} / {0}");
    else
      this.m_Str[3].AppendFormat("{0} / {1}");
    this.m_SliderTexts[3].text = this.m_Str[3].ToString();
    this.m_SliderTexts[3].SetAllDirty();
    this.m_SliderTexts[3].cachedTextGenerator.Invalidate();
    if (value > 0U && value < max)
      ((Behaviour) this.m_TypeImage[2]).enabled = true;
    else
      ((Behaviour) this.m_TypeImage[2]).enabled = false;
  }

  public override void OnClose()
  {
    for (int index = 0; index < this.m_Str.Length; ++index)
      StringManager.Instance.DeSpawnString(this.m_Str[index]);
    this.baseBuild.DestroyBuildingWindow();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != 1)
      return;
    this.SetWallRePaireSlider(this.DM.m_WallRepairNowValue, this.DM.m_WallRepairMaxValue, Time.deltaTime);
    this.SetTrapSlider(this.DM.TrapTotal, this.DM.GetMaxTrapValue());
    this.SeteTrapRepair(this.DM.TrapHospitalTotal, this.DM.GetMaxTrapValue());
    this.m_SelectDefender = 0;
    for (int index = 0; index < this.DM.m_DefendersID.Length; ++index)
    {
      if (this.DM.m_DefendersID[index] != (ushort) 0)
        ++this.m_SelectDefender;
    }
    this.SetDefenderSlider(this.m_SelectDefender, this.DM.GetMaxDefenders());
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.baseBuild.MyUpdate((byte) 0);
        this.UpdateUI(1, 0);
        break;
      case NetworkNews.Refresh_BuildBase:
        this.baseBuild.MyUpdate(meg[1]);
        this.UpdateUI(1, 0);
        break;
      case NetworkNews.Refresh_AttribEffectVal:
        this.baseBuild.MyUpdate((byte) 0);
        this.UpdateUI(1, 0);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        if (!((Object) this.baseBuild != (Object) null))
          break;
        this.baseBuild.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    for (int index = 0; index < 4; ++index)
    {
      if ((Object) this.m_SliderTexts[index] != (Object) null && ((Behaviour) this.m_SliderTexts[index]).enabled)
      {
        ((Behaviour) this.m_SliderTexts[index]).enabled = false;
        ((Behaviour) this.m_SliderTexts[index]).enabled = true;
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((Object) this.m_tmptext[index] != (Object) null && ((Behaviour) this.m_tmptext[index]).enabled)
      {
        ((Behaviour) this.m_tmptext[index]).enabled = false;
        ((Behaviour) this.m_tmptext[index]).enabled = true;
      }
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
  }

  public override bool OnBackButtonClick() => false;

  public void OnButtonClick(UIButton sender)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((Object) menu == (Object) null)
      return;
    switch (sender.m_BtnID1)
    {
      case 0:
        menu.OpenMenu(EGUIWindow.UI_Defenders);
        GUIManager.Instance.BuildingData.GuideSoldierID = (ushort) 0;
        break;
      case 1:
        menu.OpenMenu(EGUIWindow.UI_WallRepair);
        GUIManager.Instance.BuildingData.GuideSoldierID = (ushort) 0;
        break;
      case 2:
        if (GUIManager.Instance.BuildingData.GuideSoldierID == (ushort) 30)
          GUIManager.Instance.BuildingData.GuideSoldierID = (ushort) 0;
        menu.OpenMenu(EGUIWindow.UI_Trap);
        break;
      case 3:
        menu.OpenMenu(EGUIWindow.UI_Hospital, this.B_ID);
        GUIManager.Instance.BuildingData.GuideSoldierID = (ushort) 0;
        break;
    }
  }

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing)
    {
      this.m_Panel.gameObject.SetActive(true);
      if (GUIManager.Instance.BuildingData.GuideSoldierID >= (ushort) 17 && GUIManager.Instance.BuildingData.GuideSoldierID <= (ushort) 28)
        ((Component) this.m_Image).gameObject.SetActive(true);
      else
        ((Component) this.m_Image).gameObject.SetActive(false);
      if (GUIManager.Instance.BuildingData.GuideSoldierID == (ushort) 30)
        ((Component) this.m_ArrowRepair).gameObject.SetActive(true);
      else
        ((Component) this.m_ArrowRepair).gameObject.SetActive(false);
    }
    else
      this.m_Panel.gameObject.SetActive(false);
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, 11167, 0, Vector2.zero);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Hide((bool) (Object) sender);
  }
}
