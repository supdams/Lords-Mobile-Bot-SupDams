// Decompiled with JetBrains decompiler
// Type: UIResourceBuilding
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class UIResourceBuilding : GUIWindow
{
  private BuildingWindow baseBuild;

  private void Start()
  {
  }

  public override void OnOpen(int arg1, int arg2)
  {
    int length = GUIManager.Instance.BuildingData.AllBuildsData.Length;
    if (arg1 < length && arg1 >= 0)
    {
      ushort _buildID = (ushort) arg2;
      byte level = GUIManager.Instance.BuildingData.AllBuildsData[arg1].Level;
      this.baseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
      this.baseBuild.InitBuildingWindow((byte) _buildID, (ushort) arg1, (byte) 1, level);
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    if (!((Object) this.baseBuild != (Object) null))
      return;
    this.baseBuild.DestroyBuildingWindow();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.baseBuild.MyUpdate((byte) 0);
        break;
      case NetworkNews.Refresh_BuildBase:
        this.baseBuild.MyUpdate(meg[1]);
        break;
      case NetworkNews.Refresh_AttribEffectVal:
        this.baseBuild.MyUpdate((byte) 0);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.baseBuild.Refresh_FontTexture();
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
  }
}
