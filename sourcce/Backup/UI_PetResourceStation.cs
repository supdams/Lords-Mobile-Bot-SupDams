// Decompiled with JetBrains decompiler
// Type: UI_PetResourceStation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UI_PetResourceStation : GUIWindow, IBuildingWindowType
{
  private Transform AGS_Form;
  private BuildingWindow baseBuild;
  private ushort Manor_ID;
  private UIText ResourceAmount;
  private CString[] values;
  private bool ReflashFont;
  private bool NoReflashFont;

  public override void OnOpen(int arg1, int arg2)
  {
    this.Manor_ID = (ushort) arg1;
    DataManager instance = DataManager.Instance;
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    UIText component1 = this.AGS_Form.GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.text = instance.mStringTable.GetStringByID(12106U);
    UIText component2 = this.AGS_Form.GetChild(1).GetChild(0).GetChild(2).GetComponent<UIText>();
    component2.font = ttfFont;
    component2.text = string.Empty;
    this.ResourceAmount = component2;
    UIText component3 = this.AGS_Form.GetChild(1).GetChild(1).GetChild(1).GetComponent<UIText>();
    component3.font = ttfFont;
    component3.text = instance.mStringTable.GetStringByID(12107U);
    UIText component4 = this.AGS_Form.GetChild(1).GetChild(1).GetChild(2).GetComponent<UIText>();
    component4.font = ttfFont;
    component4.text = string.Empty;
    UIText component5 = this.AGS_Form.GetChild(1).GetChild(2).GetChild(1).GetComponent<UIText>();
    component5.font = ttfFont;
    component5.text = instance.mStringTable.GetStringByID(12108U);
    UIText component6 = this.AGS_Form.GetChild(1).GetChild(2).GetChild(2).GetComponent<UIText>();
    component6.font = ttfFont;
    component6.text = string.Empty;
    UIText component7 = this.AGS_Form.GetChild(1).GetChild(3).GetChild(1).GetComponent<UIText>();
    component7.font = ttfFont;
    component7.text = instance.mStringTable.GetStringByID(12109U);
    UIText component8 = this.AGS_Form.GetChild(1).GetChild(3).GetChild(2).GetComponent<UIText>();
    component8.font = ttfFont;
    component8.text = string.Empty;
    this.SetOnOpen();
  }

  public void Refresh_FontTexture()
  {
    if (this.NoReflashFont)
    {
      this.ReflashFont = true;
    }
    else
    {
      UIText component1 = this.AGS_Form.GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>();
      if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
      {
        ((Behaviour) component1).enabled = false;
        ((Behaviour) component1).enabled = true;
      }
      UIText component2 = this.AGS_Form.GetChild(1).GetChild(0).GetChild(2).GetComponent<UIText>();
      if ((Object) component2 != (Object) null && ((Behaviour) component2).enabled)
      {
        ((Behaviour) component2).enabled = false;
        ((Behaviour) component2).enabled = true;
      }
      UIText component3 = this.AGS_Form.GetChild(1).GetChild(1).GetChild(1).GetComponent<UIText>();
      if ((Object) component3 != (Object) null && ((Behaviour) component3).enabled)
      {
        ((Behaviour) component3).enabled = false;
        ((Behaviour) component3).enabled = true;
      }
      UIText component4 = this.AGS_Form.GetChild(1).GetChild(1).GetChild(2).GetComponent<UIText>();
      if ((Object) component4 != (Object) null && ((Behaviour) component4).enabled)
      {
        ((Behaviour) component4).enabled = false;
        ((Behaviour) component4).enabled = true;
      }
      UIText component5 = this.AGS_Form.GetChild(1).GetChild(2).GetChild(1).GetComponent<UIText>();
      if ((Object) component5 != (Object) null && ((Behaviour) component5).enabled)
      {
        ((Behaviour) component5).enabled = false;
        ((Behaviour) component5).enabled = true;
      }
      UIText component6 = this.AGS_Form.GetChild(1).GetChild(2).GetChild(2).GetComponent<UIText>();
      if ((Object) component6 != (Object) null && ((Behaviour) component6).enabled)
      {
        ((Behaviour) component6).enabled = false;
        ((Behaviour) component6).enabled = true;
      }
      UIText component7 = this.AGS_Form.GetChild(1).GetChild(3).GetChild(1).GetComponent<UIText>();
      if ((Object) component7 != (Object) null && ((Behaviour) component7).enabled)
      {
        ((Behaviour) component7).enabled = false;
        ((Behaviour) component7).enabled = true;
      }
      UIText component8 = this.AGS_Form.GetChild(1).GetChild(3).GetChild(2).GetComponent<UIText>();
      if (!((Object) component8 != (Object) null) || !((Behaviour) component8).enabled)
        return;
      ((Behaviour) component8).enabled = false;
      ((Behaviour) component8).enabled = true;
    }
  }

  public override void OnClose()
  {
    if ((Object) this.baseBuild != (Object) null)
      this.baseBuild.DestroyBuildingWindow();
    for (int index = 0; index < this.values.Length; ++index)
      StringManager.Instance.DeSpawnString(this.values[index]);
  }

  private void Start()
  {
    this.baseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    this.baseBuild.InitBuildingWindow((byte) 21, this.Manor_ID, (byte) 2, GUIManager.Instance.BuildingData.AllBuildsData[(int) this.Manor_ID].Level);
    Object.Destroy((Object) this.AGS_Form.GetChild(0).gameObject);
    this.baseBuild.baseTransform.SetAsFirstSibling();
    this.NoReflashFont = true;
  }

  public void Update()
  {
    this.NoReflashFont = false;
    if (!this.ReflashFont)
      return;
    this.Refresh_FontTexture();
  }

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
      this.AGS_Form.GetChild(1).gameObject.SetActive(true);
    else
      this.AGS_Form.GetChild(1).gameObject.SetActive(false);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh_BuildBase:
        if (meg[1] == (byte) 1)
          (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu(true);
        else if ((Object) this.baseBuild != (Object) null)
          this.baseBuild.MyUpdate(meg[1]);
        this.UpdateInfo();
        break;
      case NetworkNews.Refresh_AttribEffectVal:
        if ((Object) this.baseBuild != (Object) null)
          this.baseBuild.MyUpdate((byte) 0);
        this.UpdateInfo();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        if ((Object) this.baseBuild != (Object) null)
          this.baseBuild.Refresh_FontTexture();
        this.Refresh_FontTexture();
        break;
      case NetworkNews.Refresh_PetResource:
        this.UpdateResource();
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!((Object) menu != (Object) null))
          break;
        menu.CloseMenu();
        break;
      case 1:
        this.UpdateInfo();
        break;
    }
  }

  private void SetOnOpen()
  {
    this.values = new CString[4];
    for (int index = 0; index < this.values.Length; ++index)
      this.values[index] = StringManager.Instance.SpawnString();
    this.UpdateResource();
    this.UpdateInfo();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
  }

  private void UpdateResource()
  {
    this.values[0].ClearString();
    this.values[0].IntToFormat((long) DataManager.Instance.PetResource.Stock, bNumber: true);
    this.values[0].AppendFormat("{0}");
    this.ResourceAmount.text = this.values[0].ToString();
    this.ResourceAmount.cachedTextGenerator.Invalidate();
    this.ResourceAmount.SetAllDirty();
  }

  private void UpdateInfo()
  {
    BuildLevelRequest levelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort) 21, GUIManager.Instance.BuildingData.AllBuildsData[(int) this.Manor_ID].Level);
    long num = 0;
    if (levelRequestData.Effect1 == (ushort) 358)
      num = (long) levelRequestData.Value1;
    else if (levelRequestData.Effect2 == (ushort) 358)
      num = (long) levelRequestData.Value2;
    else if (levelRequestData.Effect3 == (ushort) 358)
      num = (long) levelRequestData.Value3;
    long x = num * ((long) DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETRSS_PRODUCTION_PERCENT) + 10000L) / 10000L;
    this.values[1].ClearString();
    this.values[1].IntToFormat(x, bNumber: true);
    this.values[1].AppendFormat("{0}");
    UIText component1 = this.AGS_Form.GetChild(1).GetChild(1).GetChild(2).GetComponent<UIText>();
    component1.text = this.values[1].ToString();
    component1.cachedTextGenerator.Invalidate();
    component1.SetAllDirty();
    this.values[2].ClearString();
    this.values[2].IntToFormat((long) DataManager.Instance.PetResource.Capacity, bNumber: true);
    this.values[2].AppendFormat("{0}");
    UIText component2 = this.AGS_Form.GetChild(1).GetChild(2).GetChild(2).GetComponent<UIText>();
    component2.text = this.values[2].ToString();
    component2.cachedTextGenerator.Invalidate();
    component2.SetAllDirty();
    this.values[3].ClearString();
    this.values[3].IntToFormat(DataManager.Instance.PetResource.GetSpeed(), bNumber: true);
    this.values[3].AppendFormat("{0}");
    UIText component3 = this.AGS_Form.GetChild(1).GetChild(3).GetChild(2).GetComponent<UIText>();
    component3.text = this.values[3].ToString();
    component3.cachedTextGenerator.Invalidate();
    component3.SetAllDirty();
  }

  private enum e_AGS_UI_PetResourceStation_Editor
  {
    builidingWindows,
    MyFormItems,
  }

  private enum e_AGS_MyFormItems
  {
    TitlePanel,
    HavePanel,
    CapPanel,
    totalIncome,
  }

  private enum e_AGS_TitlePanel
  {
    Image,
    UIText,
    UIText2,
  }
}
