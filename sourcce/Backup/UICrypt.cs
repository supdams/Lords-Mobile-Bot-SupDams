// Decompiled with JetBrains decompiler
// Type: UICrypt
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UICrypt : GUIWindow, IBuildingWindowType, IUIButtonClickHandler
{
  private Transform AGS_Form;
  private BuildingWindow baseBuild;
  private ushort B_ID;
  private Door door;
  private DataManager DM;
  private Image light1;
  private Image light2;
  private Image light3;
  private CString barText;
  private bool ReflashFont;
  private bool NoReflashFont;
  private float HintTime;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.door = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
    this.B_ID = (ushort) arg1;
    this.barText = StringManager.Instance.SpawnString(100);
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    UIButton component1 = this.AGS_Form.GetChild(1).GetChild(1).GetChild(1).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 1;
    component1.m_EffectType = e_EffectType.e_Scale;
    UIText component2 = this.AGS_Form.GetChild(1).GetChild(1).GetChild(5).GetComponent<UIText>();
    component2.font = ttfFont;
    component2.text = this.DM.mStringTable.GetStringByID(3986U);
    UIButton component3 = this.AGS_Form.GetChild(1).GetChild(2).GetChild(1).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 2;
    component3.m_EffectType = e_EffectType.e_Scale;
    UIText component4 = this.AGS_Form.GetChild(1).GetChild(2).GetChild(5).GetComponent<UIText>();
    component4.font = ttfFont;
    component4.text = this.DM.mStringTable.GetStringByID(3987U);
    UIButton component5 = this.AGS_Form.GetChild(1).GetChild(3).GetChild(1).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    component5.m_BtnID1 = 3;
    component5.m_EffectType = e_EffectType.e_Scale;
    UIText component6 = this.AGS_Form.GetChild(1).GetChild(3).GetChild(5).GetComponent<UIText>();
    component6.font = ttfFont;
    component6.text = this.DM.mStringTable.GetStringByID(3988U);
    UIText component7 = this.AGS_Form.GetChild(1).GetChild(4).GetChild(1).GetComponent<UIText>();
    component7.font = ttfFont;
    component7.text = string.Empty;
    this.light1 = this.AGS_Form.GetChild(1).GetChild(1).GetChild(3).GetComponent<Image>();
    this.light2 = this.AGS_Form.GetChild(1).GetChild(2).GetChild(3).GetComponent<Image>();
    this.light3 = this.AGS_Form.GetChild(1).GetChild(3).GetChild(3).GetComponent<Image>();
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform component8 = this.AGS_Form.GetChild(1).GetChild(1).GetChild(2).GetComponent<RectTransform>();
      ((Transform) component8).localScale = new Vector3(-1f, 1f, 1f);
      component8.anchoredPosition = new Vector2(component8.anchoredPosition.x + 70f, component8.anchoredPosition.y);
      RectTransform component9 = this.AGS_Form.GetChild(1).GetChild(2).GetChild(2).GetComponent<RectTransform>();
      ((Transform) component9).localScale = new Vector3(-1f, 1f, 1f);
      component9.anchoredPosition = new Vector2(component9.anchoredPosition.x + 70f, component9.anchoredPosition.y);
      RectTransform component10 = this.AGS_Form.GetChild(1).GetChild(3).GetChild(2).GetComponent<RectTransform>();
      ((Transform) component10).localScale = new Vector3(-1f, 1f, 1f);
      component10.anchoredPosition = new Vector2(component10.anchoredPosition.x + 70f, component10.anchoredPosition.y);
    }
    this.updataTimeBar();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    if ((Object) this.baseBuild != (Object) null)
      this.baseBuild.DestroyBuildingWindow();
    StringManager.Instance.DeSpawnString(this.barText);
  }

  private void Start()
  {
    Object.Destroy((Object) this.AGS_Form.GetChild(0).gameObject);
    this.baseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    this.baseBuild.InitBuildingWindow((byte) 16, this.B_ID, (byte) 2, GUIManager.Instance.BuildingData.AllBuildsData[(int) this.B_ID].Level);
    this.baseBuild.baseTransform.SetAsFirstSibling();
    this.NoReflashFont = true;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
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
        this.baseBuild.MyUpdate((byte) 0);
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
    this.updataTimeBar();
  }

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
      this.AGS_Form.GetChild(1).gameObject.SetActive(true);
    else
      this.AGS_Form.GetChild(1).gameObject.SetActive(false);
  }

  public void OnButtonClick(UIButton sender)
  {
    this.door.OpenMenu(EGUIWindow.UI_CryptDig, sender.m_BtnID1);
  }

  public void updataTimeBar()
  {
    RectTransform component1 = this.AGS_Form.GetChild(1).GetChild(4).GetComponent<RectTransform>();
    this.AGS_Form.GetChild(1).GetChild(1).GetChild(2).gameObject.SetActive(false);
    this.AGS_Form.GetChild(1).GetChild(2).GetChild(2).gameObject.SetActive(false);
    this.AGS_Form.GetChild(1).GetChild(3).GetChild(2).gameObject.SetActive(false);
    if (this.DM.m_CryptData.money == (ushort) 0)
    {
      ((Component) this.light1).gameObject.SetActive(false);
      ((Component) this.light2).gameObject.SetActive(false);
      ((Component) this.light3).gameObject.SetActive(false);
      ((Component) component1).gameObject.SetActive(false);
    }
    else
    {
      ((Component) component1).gameObject.SetActive(true);
      component1.anchoredPosition = new Vector2((float) (((int) this.DM.m_CryptData.kind - 1) * 249 - 342), -79f);
      long sec = this.DM.m_CryptData.startTime + (long) GameConstants.CryptSecends[(int) this.DM.m_CryptData.kind] - this.DM.ServerTime;
      if (sec < 0L)
        sec = 0L;
      UIText component2 = ((Transform) component1).GetChild(1).GetComponent<UIText>();
      this.barText.ClearString();
      if (sec != 0L)
      {
        this.barText.Append(this.DM.mStringTable.GetStringByID(3989U));
        this.barText.Append(" ");
        GameConstants.GetTimeString(this.barText, (uint) sec, hideTimeIfDays: true);
        component2.text = this.barText.ToString();
        component2.SetAllDirty();
        component2.cachedTextGenerator.Invalidate();
        ((Transform) component1).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, Mathf.Clamp01(1f - (float) sec / (float) GameConstants.CryptSecends[(int) this.DM.m_CryptData.kind]) * 164f);
      }
      else
      {
        this.AGS_Form.GetChild(1).GetChild(0 + (int) this.DM.m_CryptData.kind).GetChild(2).gameObject.SetActive(true);
        this.barText.Append(this.DM.mStringTable.GetStringByID(5881U));
        ((Component) this.light1).gameObject.SetActive(false);
        ((Component) this.light2).gameObject.SetActive(false);
        ((Component) this.light3).gameObject.SetActive(false);
        ((Component) component1).gameObject.SetActive(false);
        switch (this.DM.m_CryptData.kind)
        {
          case 1:
            ((Component) this.light1).gameObject.SetActive(true);
            break;
          case 2:
            ((Component) this.light2).gameObject.SetActive(true);
            break;
          case 3:
            ((Component) this.light3).gameObject.SetActive(true);
            break;
        }
      }
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
      UIText component1 = this.AGS_Form.GetChild(1).GetChild(1).GetChild(5).GetComponent<UIText>();
      if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
      {
        ((Behaviour) component1).enabled = false;
        ((Behaviour) component1).enabled = true;
      }
      UIText component2 = this.AGS_Form.GetChild(1).GetChild(2).GetChild(5).GetComponent<UIText>();
      if ((Object) component2 != (Object) null && ((Behaviour) component2).enabled)
      {
        ((Behaviour) component2).enabled = false;
        ((Behaviour) component2).enabled = true;
      }
      UIText component3 = this.AGS_Form.GetChild(1).GetChild(3).GetChild(5).GetComponent<UIText>();
      if ((Object) component3 != (Object) null && ((Behaviour) component3).enabled)
      {
        ((Behaviour) component3).enabled = false;
        ((Behaviour) component3).enabled = true;
      }
      UIText component4 = this.AGS_Form.GetChild(1).GetChild(4).GetChild(1).GetComponent<UIText>();
      if (!((Object) component4 != (Object) null) || !((Behaviour) component4).enabled)
        return;
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
  }

  public void Update()
  {
    this.NoReflashFont = false;
    if (this.ReflashFont)
      this.Refresh_FontTexture();
    this.HintTime += Time.smoothDeltaTime / 2f;
    if ((double) this.HintTime >= 2.0)
      this.HintTime = 0.0f;
    Color color = new Color(1f, 1f, 1f, (double) this.HintTime <= 1.0 ? this.HintTime : 2f - this.HintTime);
    ((Graphic) this.light1).color = color;
    ((Graphic) this.light2).color = color;
    ((Graphic) this.light3).color = color;
  }

  private enum e_AGS_UI_Crypt_Editor
  {
    BuildingWindow,
    MyWindow,
  }

  private enum e_AGS_MyWindow
  {
    BGImage,
    Group1,
    Group2,
    Group3,
    Bar,
  }

  private enum e_AGS_Group
  {
    frame,
    Btn,
    Check,
    Light,
    TextBg,
    Text,
  }

  private enum e_AGS_Bar
  {
    Bar,
    Text,
  }
}
