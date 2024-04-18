// Decompiled with JetBrains decompiler
// Type: UITechUpgrade
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UITechUpgrade : GUIWindow
{
  private byte TechID;
  public BuildingWindow buildWin;
  private UIText LvText;
  private CString LvStr;
  private RectTransform DegreeRect;
  private Image TechIcon;
  private ushort GraphicID;

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    this.TechID = (byte) arg1;
    GUIManager.Instance.SetTalentIconSprite("UITechIcon", this.m_eWindow);
    TechDataTbl recordByKey = instance1.TechData.GetRecordByKey((ushort) this.TechID);
    Font ttfFont = instance2.GetTTFFont();
    byte techLevel = instance1.GetTechLevel((ushort) this.TechID);
    if (DataManager.StageDataController.StageRecord[2] < (ushort) 8)
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
    else
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
    this.LvStr = StringManager.Instance.SpawnString();
    this.TechIcon = this.transform.GetChild(0).GetChild(0).GetComponent<Image>();
    ((Behaviour) this.TechIcon).enabled = false;
    this.GraphicID = recordByKey.Graphic;
    this.DegreeRect = this.transform.GetChild(0).GetChild(3).GetComponent<RectTransform>();
    float num = 173.8f / (float) recordByKey.LevelMax;
    this.DegreeRect.sizeDelta = this.DegreeRect.sizeDelta with
    {
      x = (float) techLevel * num
    };
    this.LvStr.ClearString();
    this.LvStr.IntToFormat((long) techLevel);
    this.LvStr.IntToFormat((long) recordByKey.LevelMax);
    if (GUIManager.Instance.IsArabic)
      this.LvStr.AppendFormat("{1}/{0}");
    else
      this.LvStr.AppendFormat("{0}/{1}");
    this.LvText = this.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
    this.LvText.font = ttfFont;
    this.LvText.text = this.LvStr.ToString();
    this.buildWin = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.buildWin.InitTechWindow(this.TechID, techLevel);
    this.transform.GetChild(0).SetAsLastSibling();
    if (GUIManager.Instance.IsArabic)
      ((Component) this.TechIcon).transform.localScale = new Vector3(-1f, 1f, 1f);
    if (instance2.GuideParm1 == (byte) 3 && (int) this.TechID == (int) instance2.GuideParm2)
      instance2.GuideArrow((RectTransform) ((Component) this.buildWin.upgradeBtn).transform, ArrowDirect.Ar_Up);
    this.TechIcon.sprite = GUIManager.Instance.GetTechSprite(this.GraphicID);
    ((MaskableGraphic) this.TechIcon).material = GUIManager.Instance.TechMaterial;
    if ((Object) this.TechIcon.sprite != (Object) null)
      ((Behaviour) this.TechIcon).enabled = true;
    NewbieManager.CheckTeach(ETeachKind.COLLEGE, (object) this);
  }

  public override void OnClose()
  {
    if ((Object) this.buildWin != (Object) null)
      this.buildWin.DestroyBuildingWindow();
    this.buildWin = (BuildingWindow) null;
    StringManager.Instance.DeSpawnString(this.LvStr);
    NewbieManager.CheckTeach(ETeachKind.COLLEGE, (object) this);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_QBarTime:
      case NetworkNews.Refresh_AttribEffectVal:
        if (!(bool) (Object) this.buildWin)
          break;
        this.buildWin.MyUpdate((byte) 0);
        break;
      case NetworkNews.Refresh_Technology:
        this.UpdateTechInfo();
        if (!(bool) (Object) this.buildWin)
          break;
        this.buildWin.MyUpdate(meg[1]);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        this.buildWin.Refresh_FontTexture();
        ((Behaviour) this.LvText).enabled = false;
        ((Behaviour) this.LvText).enabled = true;
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != -1)
      return;
    this.TechIcon.sprite = GUIManager.Instance.GetTechSprite(this.GraphicID);
    ((MaskableGraphic) this.TechIcon).material = GUIManager.Instance.TechMaterial;
    ((Behaviour) this.TechIcon).enabled = true;
  }

  private void UpdateTechInfo()
  {
    DataManager instance = DataManager.Instance;
    TechDataTbl recordByKey = instance.TechData.GetRecordByKey((ushort) this.TechID);
    byte techLevel = instance.GetTechLevel((ushort) this.TechID);
    this.LvStr.ClearString();
    this.LvStr.IntToFormat((long) techLevel);
    this.LvStr.IntToFormat((long) recordByKey.LevelMax);
    this.LvStr.AppendFormat("{0}/{1}");
    this.LvText.text = this.LvStr.ToString();
    this.LvText.SetAllDirty();
    this.LvText.cachedTextGenerator.Invalidate();
    if ((int) techLevel == (int) recordByKey.LevelMax)
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((Object) menu != (Object) null))
        return;
      menu.CloseMenu();
    }
    else
    {
      float num = 173.8f / (float) recordByKey.LevelMax;
      this.DegreeRect.sizeDelta = this.DegreeRect.sizeDelta with
      {
        x = (float) techLevel * num
      };
    }
  }

  private enum SkillControl
  {
    SkillIcon,
    Frame,
    FullFrame,
    Degree,
    LvText,
  }
}
