// Decompiled with JetBrains decompiler
// Type: UIMarket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIMarket : GUIWindow, IBuildingWindowType, IUIButtonClickHandler
{
  private Transform m_transform;
  private Transform NormalPanel;
  private BuildingWindow baseBuild;
  private UIText MiddleText1;
  private UIText MiddleText2;
  private CString MiddleStr1;
  private CString MiddleStr2;
  private GameObject[] NoAllyGO = new GameObject[2];
  private GameObject[] HasAllyGO = new GameObject[3];
  private int BuildIndex;
  private UIText[] RBText = new UIText[2];

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    StringManager instance3 = StringManager.Instance;
    Font ttfFont = instance2.GetTTFFont();
    this.m_transform = this.transform;
    this.MiddleStr1 = instance3.SpawnString();
    this.MiddleStr2 = instance3.SpawnString();
    this.NormalPanel = this.m_transform.GetChild(0);
    this.NormalPanel.GetChild(2).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.RBText[0] = this.NormalPanel.GetChild(2).GetChild(1).GetComponent<UIText>();
    this.RBText[0].font = ttfFont;
    this.RBText[0].text = instance1.mStringTable.GetStringByID(3948U);
    this.BuildIndex = arg1;
    byte level = instance2.BuildingData.AllBuildsData[this.BuildIndex].Level;
    this.MiddleText1 = this.NormalPanel.GetChild(3).GetComponent<UIText>();
    this.MiddleText1.font = ttfFont;
    this.MiddleText2 = this.NormalPanel.GetChild(4).GetComponent<UIText>();
    this.MiddleText2.font = ttfFont;
    this.OpenRefresh();
    this.RBText[1] = this.NormalPanel.GetChild(5).GetComponent<UIText>();
    this.RBText[1].font = ttfFont;
    this.RBText[1].text = instance1.mStringTable.GetStringByID(5784U);
    this.HasAllyGO[0] = this.NormalPanel.GetChild(2).gameObject;
    this.HasAllyGO[1] = this.NormalPanel.GetChild(2).GetChild(0).gameObject;
    this.HasAllyGO[2] = this.NormalPanel.GetChild(2).GetChild(1).gameObject;
    this.NoAllyGO[0] = this.NormalPanel.GetChild(1).gameObject;
    this.NoAllyGO[1] = this.NormalPanel.GetChild(5).gameObject;
    this.baseBuild = this.m_transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    this.baseBuild.InitBuildingWindow((byte) 17, (ushort) arg1, (byte) 1, level);
    this.baseBuild.baseTransform.SetAsFirstSibling();
    instance2.UpdateUI(EGUIWindow.Door, 1, 2);
    this.CheckHasAlly();
  }

  public void OpenRefresh()
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    byte level = instance2.BuildingData.AllBuildsData[this.BuildIndex].Level;
    BuildLevelRequest levelRequestData = instance2.BuildingData.GetBuildLevelRequestData((ushort) 17, level);
    this.MiddleStr1.Length = 0;
    float f = 0.0f;
    uint effectBaseVal1 = instance1.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_TRADE_TAX_REDUCTION);
    if (levelRequestData.Value2 >= effectBaseVal1)
      f = (float) (levelRequestData.Value2 - effectBaseVal1) / 100f;
    this.MiddleStr1.FloatToFormat(f, 1, false);
    this.MiddleStr1.AppendFormat(instance1.mStringTable.GetStringByID(3949U));
    this.MiddleText1.text = this.MiddleStr1.ToString();
    this.MiddleText1.SetAllDirty();
    this.MiddleText1.cachedTextGenerator.Invalidate();
    uint effectBaseVal2 = instance1.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_TRADE_CAPACITY);
    uint effectBaseVal3 = instance1.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_TRADE_CAPACITY_PERCENT);
    this.MiddleStr2.Length = 0;
    this.MiddleStr2.IntToFormat((long) ((double) effectBaseVal2 * ((double) (10000U + effectBaseVal3) / 10000.0)), bNumber: true);
    this.MiddleStr2.AppendFormat(instance1.mStringTable.GetStringByID(3950U));
    this.MiddleText2.text = this.MiddleStr2.ToString();
    this.MiddleText2.SetAllDirty();
    this.MiddleText2.cachedTextGenerator.Invalidate();
  }

  public override void OnClose()
  {
    if ((Object) this.baseBuild != (Object) null)
      this.baseBuild.DestroyBuildingWindow();
    if (this.MiddleStr1 != null)
      StringManager.Instance.DeSpawnString(this.MiddleStr1);
    if (this.MiddleStr2 == null)
      return;
    StringManager.Instance.DeSpawnString(this.MiddleStr2);
  }

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing)
      this.NormalPanel.gameObject.SetActive(true);
    else
      this.NormalPanel.gameObject.SetActive(false);
  }

  public void CheckHasAlly()
  {
    bool flag = DataManager.Instance.RoleAlliance.Id != 0U;
    for (int index = 0; index < this.HasAllyGO.Length; ++index)
      this.HasAllyGO[index].SetActive(flag);
    for (int index = 0; index < this.NoAllyGO.Length; ++index)
      this.NoAllyGO[index].SetActive(!flag);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_BuildBase:
      case NetworkNews.Refresh_Technology:
        this.baseBuild.MyUpdate(meg[1]);
        this.OpenRefresh();
        break;
      default:
        switch (networkNews)
        {
          case NetworkNews.Login:
            this.baseBuild.MyUpdate((byte) 0);
            this.OpenRefresh();
            return;
          case NetworkNews.Refresh_FontTextureRebuilt:
            this.baseBuild.Refresh_FontTexture();
            if ((Object) this.MiddleText1 != (Object) null && ((Behaviour) this.MiddleText1).enabled)
            {
              ((Behaviour) this.MiddleText1).enabled = false;
              ((Behaviour) this.MiddleText1).enabled = true;
            }
            if ((Object) this.MiddleText2 != (Object) null && ((Behaviour) this.MiddleText2).enabled)
            {
              ((Behaviour) this.MiddleText2).enabled = false;
              ((Behaviour) this.MiddleText2).enabled = true;
            }
            for (int index = 0; index < this.RBText.Length; ++index)
            {
              if ((Object) this.RBText[index] != (Object) null && ((Behaviour) this.RBText[index]).enabled)
              {
                ((Behaviour) this.RBText[index]).enabled = false;
                ((Behaviour) this.RBText[index]).enabled = true;
              }
            }
            return;
          default:
            return;
        }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != 1)
      return;
    this.OpenRefresh();
  }

  public void OnButtonClick(UIButton sender)
  {
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_Alliance_List, 4);
  }
}
