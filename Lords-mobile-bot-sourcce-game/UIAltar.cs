// Decompiled with JetBrains decompiler
// Type: UIAltar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAltar : GUIWindow, IBuildingWindowType
{
  private const int MaxTempTextNum = 2;
  private GUIManager GM;
  private DataManager DM;
  private Font TTF;
  private Color Color_Red = new Color(1f, 0.352f, 0.443f, 1f);
  private Color Color_Green = new Color(0.207f, 0.968f, 0.423f, 1f);
  private Transform[] m_AltarPanel = new Transform[2];
  private Transform m_DarkTf;
  private Transform m_LightTf;
  private Transform m_DisableTf;
  private BuildingWindow m_BaseBuild;
  private UITimeBar m_TimeBar;
  private UIText m_TimeText;
  private UIText m_TitleText;
  private ValueObj[] m_ValueText = new ValueObj[4];
  private EffectTemp[] m_EffectTemp = new EffectTemp[4];
  private Material m_Mat;
  private GameObject m_Particle;
  private Image m_BGFrame;
  private Image m_MainImage;
  private Material m_ParticleMat;
  private ushort m_ManorID;
  private string SpAssName = "BuildingWindow";
  private string SpAssName_m = "BuildingWindow_m";
  private string[] IconName = new string[7]
  {
    "UI_con_icons_01",
    "UI_con_icons_03",
    "UI_con_icons_02",
    "UI_con_icons_04",
    "UI_con_frame_13",
    "UI_con_frame_25",
    "UI_altar_box_02"
  };
  private UIText[] m_TempText = new UIText[2];
  private int m_TempTextIdx;

  public override void OnOpen(int arg1, int arg2)
  {
    this.TTF = GUIManager.Instance.GetTTFFont();
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.GM.AddSpriteAsset(this.SpAssName);
    this.m_Mat = this.GM.LoadMaterial(this.SpAssName, this.SpAssName_m);
    this.m_ManorID = (ushort) arg1;
    this.m_Particle = ParticleManager.Instance.Spawn((ushort) 8, this.transform, new Vector3(-154f, 64f, -796f), 1f, false);
    GUIManager.Instance.SetLayer(this.m_Particle, 5);
    for (int index = 0; index < 2; ++index)
      this.m_AltarPanel[index] = this.transform.GetChild(index);
    this.m_DarkTf = this.m_AltarPanel[0].GetChild(1);
    this.m_LightTf = this.m_AltarPanel[0].GetChild(2);
    this.m_TimeBar = this.m_AltarPanel[0].GetChild(3).GetComponent<UITimeBar>();
    this.m_TimeText = this.m_AltarPanel[0].GetChild(4).GetComponent<UIText>();
    this.m_TimeText.font = this.TTF;
    this.m_TimeText.text = this.DM.mStringTable.GetStringByID(5755U);
    this.m_DisableTf = this.m_AltarPanel[0].GetChild(5);
    Image component1 = this.m_AltarPanel[0].GetChild(0).GetComponent<Image>();
    component1.sprite = this.GM.LoadSprite(this.SpAssName, this.IconName[4]);
    ((MaskableGraphic) component1).material = this.m_Mat;
    this.m_TitleText = this.m_AltarPanel[0].GetChild(0).GetChild(0).GetComponent<UIText>();
    this.m_TitleText.font = this.TTF;
    this.m_TitleText.text = this.DM.mStringTable.GetStringByID(5751U);
    Image component2 = this.m_AltarPanel[0].GetChild(5).GetComponent<Image>();
    component2.sprite = this.GM.LoadSprite(this.SpAssName, this.IconName[6]);
    ((MaskableGraphic) component2).material = this.m_Mat;
    UIText component3 = this.m_AltarPanel[0].GetChild(5).GetChild(0).GetComponent<UIText>();
    component3.font = this.TTF;
    component3.text = this.DM.mStringTable.GetStringByID(5752U);
    this.m_TempText[this.m_TempTextIdx++] = component3;
    for (int index = 0; index < 4; ++index)
    {
      Image component4 = this.m_AltarPanel[1].GetChild(index).GetChild(0).GetComponent<Image>();
      component4.sprite = this.GM.LoadSprite(this.SpAssName, this.IconName[5]);
      ((MaskableGraphic) component4).material = this.m_Mat;
      this.m_ValueText[index].Icon = this.m_AltarPanel[1].GetChild(index).GetChild(1).GetComponent<Image>();
      this.m_ValueText[index].TitleText = this.m_AltarPanel[1].GetChild(index).GetChild(2).GetComponent<UIText>();
      this.m_ValueText[index].TitleText.font = this.TTF;
      this.m_ValueText[index].ValueText = this.m_AltarPanel[1].GetChild(index).GetChild(3).GetComponent<UIText>();
      this.m_ValueText[index].ValueText.font = this.TTF;
      this.m_ValueText[index].TitleStr = StringManager.Instance.SpawnString();
      this.m_ValueText[index].ValueStr = StringManager.Instance.SpawnString();
      this.m_ValueText[index].TempStr = StringManager.Instance.SpawnString();
    }
    this.GM.CreateTimerBar(this.m_TimeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
    this.SetType();
    this.m_BaseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.m_BaseBuild.m_Handler = (IBuildingWindowType) this;
    this.m_BaseBuild.InitBuildingWindow((byte) 19, this.m_ManorID, (byte) 2, (byte) 0);
    this.m_BaseBuild.baseTransform.SetAsFirstSibling();
    this.m_BGFrame = this.transform.GetChild(0).GetChild(0).GetComponent<Image>();
    this.m_MainImage = this.transform.GetChild(0).GetChild(5).GetChild(1).GetComponent<Image>();
    this.m_ParticleMat = GUIManager.Instance.LoadMaterial("BuildingWindow", "BuildingWindow_m2");
    ((MaskableGraphic) this.m_BGFrame).material = this.m_ParticleMat;
    ((MaskableGraphic) this.m_MainImage).material = this.m_ParticleMat;
    this.GM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    for (int index = 0; index < 4; ++index)
    {
      if (this.m_ValueText[index].TitleStr != null)
        StringManager.Instance.DeSpawnString(this.m_ValueText[index].TitleStr);
      if (this.m_ValueText[index].ValueStr != null)
        StringManager.Instance.DeSpawnString(this.m_ValueText[index].ValueStr);
      if (this.m_ValueText[index].TempStr != null)
        StringManager.Instance.DeSpawnString(this.m_ValueText[index].TempStr);
    }
    if ((Object) this.m_BaseBuild != (Object) null)
      this.m_BaseBuild.DestroyBuildingWindow();
    if ((bool) (Object) this.m_Particle)
      ParticleManager.Instance.DeSpawn(this.m_Particle);
    this.GM.RemoveSpriteAsset(this.SpAssName);
    this.GM.RemoverTimeBaarToList(this.m_TimeBar);
  }

  public override void UpdateUI(int arg1, int arg2) => this.SetType();

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.SetType();
        this.m_BaseBuild.MyUpdate((byte) 0);
        break;
      case NetworkNews.Refresh_BuildBase:
        this.SetType();
        this.m_BaseBuild.MyUpdate(meg[1]);
        break;
      case NetworkNews.Refresh_AttribEffectVal:
        this.SetType();
        this.m_BaseBuild.MyUpdate((byte) 0);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
    {
      for (int index = 0; index < 2; ++index)
        this.m_AltarPanel[index].gameObject.SetActive(true);
      if (!(bool) (Object) this.m_Particle)
        return;
      if (this.DM.m_AltarEffect.BeginTime > 0L)
        this.m_Particle.gameObject.SetActive(true);
      else
        this.m_Particle.gameObject.SetActive(false);
    }
    else
    {
      if ((bool) (Object) this.m_Particle)
        this.m_Particle.gameObject.SetActive(false);
      for (int index = 0; index < 2; ++index)
        this.m_AltarPanel[index].gameObject.SetActive(false);
    }
  }

  private void SetType()
  {
    if (this.DM.m_AltarEffect.BeginTime != 0L)
    {
      this.SetValue(this.Color_Green);
      this.m_DisableTf.gameObject.SetActive(false);
      GUIManager.Instance.SetTimerBar(this.m_TimeBar, this.DM.m_AltarEffect.BeginTime, this.DM.m_AltarEffect.BeginTime + (long) this.DM.m_AltarEffect.RequireTime, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
      this.m_TimeBar.gameObject.SetActive(true);
      this.m_Particle.gameObject.SetActive(true);
      ((Component) this.m_TimeText).gameObject.SetActive(true);
      this.m_DarkTf.gameObject.SetActive(false);
      this.m_LightTf.gameObject.SetActive(true);
      this.m_TitleText.text = this.DM.mStringTable.GetStringByID(5904U);
    }
    else
    {
      this.SetValue(this.Color_Red);
      this.m_TimeBar.gameObject.SetActive(false);
      this.m_DisableTf.gameObject.SetActive(true);
      this.m_Particle.gameObject.SetActive(false);
      ((Component) this.m_TimeText).gameObject.SetActive(false);
      this.m_DarkTf.gameObject.SetActive(true);
      this.m_LightTf.gameObject.SetActive(false);
      this.m_TitleText.text = this.DM.mStringTable.GetStringByID(5751U);
    }
    this.m_TimeBar.gameObject.transform.GetChild(4).gameObject.SetActive(false);
    this.m_TimeBar.gameObject.transform.GetChild(5).gameObject.SetActive(false);
  }

  private void SetValue(Color color)
  {
    byte Level = 0;
    if ((int) this.m_ManorID < this.GM.BuildingData.AllBuildsData.Length && this.m_ManorID >= (ushort) 0)
      Level = this.GM.BuildingData.AllBuildsData[(int) this.m_ManorID].Level;
    if (Level <= (byte) 0)
      Level = (byte) 1;
    BuildLevelRequest levelRequestData = this.GM.BuildingData.GetBuildLevelRequestData((ushort) 19, Level);
    this.m_EffectTemp[0].Effect = levelRequestData.Effect1;
    this.m_EffectTemp[1].Effect = levelRequestData.Effect2;
    this.m_EffectTemp[2].Effect = levelRequestData.Effect3;
    this.m_EffectTemp[3].Effect = levelRequestData.Effect4;
    this.m_EffectTemp[0].Value = (ushort) levelRequestData.Value1;
    this.m_EffectTemp[1].Value = (ushort) levelRequestData.Value2;
    this.m_EffectTemp[2].Value = levelRequestData.Value3;
    this.m_EffectTemp[3].Value = levelRequestData.Value4;
    for (int valueIdx = 0; valueIdx < this.m_EffectTemp.Length; ++valueIdx)
    {
      this.SetValueIcon(valueIdx, this.m_EffectTemp[valueIdx].Effect);
      GameConstants.GetEffectValue(this.m_ValueText[valueIdx].TitleStr, this.m_EffectTemp[valueIdx].Effect, 0U, (byte) 0, 0.0f);
      this.m_ValueText[valueIdx].TitleText.text = this.m_ValueText[valueIdx].TitleStr.ToString();
      this.m_ValueText[valueIdx].TitleText.SetAllDirty();
      this.m_ValueText[valueIdx].TitleText.cachedTextGenerator.Invalidate();
      GameConstants.GetEffectValue(this.m_ValueText[valueIdx].ValueStr, this.m_EffectTemp[valueIdx].Effect, (uint) this.m_EffectTemp[valueIdx].Value, (byte) 3, 0.0f);
      this.m_ValueText[valueIdx].TempStr.ClearString();
      if (this.GM.IsArabic)
      {
        this.m_ValueText[valueIdx].TempStr.Append(this.m_ValueText[valueIdx].ValueStr);
        this.m_ValueText[valueIdx].TempStr.Append(this.DM.mStringTable.GetStringByID(5805U));
      }
      else
      {
        this.m_ValueText[valueIdx].TempStr.Append(this.DM.mStringTable.GetStringByID(5805U));
        this.m_ValueText[valueIdx].TempStr.Append(this.m_ValueText[valueIdx].ValueStr);
      }
      this.m_ValueText[valueIdx].ValueText.text = this.m_ValueText[valueIdx].TempStr.ToString();
      ((Graphic) this.m_ValueText[valueIdx].ValueText).color = color;
      this.m_ValueText[valueIdx].ValueText.SetAllDirty();
      this.m_ValueText[valueIdx].ValueText.cachedTextGenerator.Invalidate();
    }
  }

  private void SetValueIcon(int valueIdx, ushort effect)
  {
    if (valueIdx < 0 || valueIdx >= this.m_ValueText.Length)
      return;
    switch (effect)
    {
      case 216:
        this.m_ValueText[valueIdx].Icon.sprite = this.GM.LoadSprite(this.SpAssName, this.IconName[0]);
        ((MaskableGraphic) this.m_ValueText[valueIdx].Icon).material = this.m_Mat;
        this.m_ValueText[valueIdx].Icon.SetNativeSize();
        break;
      case 217:
        this.m_ValueText[valueIdx].Icon.sprite = this.GM.LoadSprite(this.SpAssName, this.IconName[1]);
        ((MaskableGraphic) this.m_ValueText[valueIdx].Icon).material = this.m_Mat;
        this.m_ValueText[valueIdx].Icon.SetNativeSize();
        break;
      case 218:
        this.m_ValueText[valueIdx].Icon.sprite = this.GM.LoadSprite(this.SpAssName, this.IconName[2]);
        ((MaskableGraphic) this.m_ValueText[valueIdx].Icon).material = this.m_Mat;
        this.m_ValueText[valueIdx].Icon.SetNativeSize();
        break;
      case 220:
        this.m_ValueText[valueIdx].Icon.sprite = this.GM.LoadSprite(this.SpAssName, this.IconName[3]);
        ((MaskableGraphic) this.m_ValueText[valueIdx].Icon).material = this.m_Mat;
        this.m_ValueText[valueIdx].Icon.SetNativeSize();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.m_TimeText != (Object) null && ((Behaviour) this.m_TimeText).enabled)
    {
      ((Behaviour) this.m_TimeText).enabled = false;
      ((Behaviour) this.m_TimeText).enabled = true;
    }
    if ((Object) this.m_TitleText != (Object) null && ((Behaviour) this.m_TitleText).enabled)
    {
      ((Behaviour) this.m_TitleText).enabled = false;
      ((Behaviour) this.m_TitleText).enabled = true;
    }
    if (this.m_ValueText != null)
    {
      for (int index = 0; index < this.m_ValueText.Length; ++index)
      {
        if ((Object) this.m_ValueText[index].TitleText != (Object) null && ((Behaviour) this.m_ValueText[index].TitleText).enabled)
        {
          ((Behaviour) this.m_ValueText[index].TitleText).enabled = false;
          ((Behaviour) this.m_ValueText[index].TitleText).enabled = true;
        }
      }
    }
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
    if (!((Object) this.m_TimeBar != (Object) null) || !this.m_TimeBar.enabled)
      return;
    this.m_TimeBar.Refresh_FontTexture();
  }
}
