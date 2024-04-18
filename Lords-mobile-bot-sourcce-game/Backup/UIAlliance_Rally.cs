// Decompiled with JetBrains decompiler
// Type: UIAlliance_Rally
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class UIAlliance_Rally : GUIWindow
{
  private Rally RallyInst;

  public override void OnOpen(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
      case 100:
      case 102:
        this.RallyInst = (Rally) new Rally_Attack(this.transform, arg2);
        break;
      case 101:
        this.RallyInst = (Rally) new Rally_WondersInfo(this.transform, arg2);
        break;
      default:
        this.RallyInst = (Rally) new Rally_Defense(this.transform, arg2);
        break;
    }
    this.RallyInst.OnOpen(arg1, arg2);
  }

  public override void OnClose() => this.RallyInst.OnClose();

  public override void UpdateUI(int arg1, int arg2) => this.RallyInst.UpdateUI(arg1, arg2);

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu_Alliance(this.m_eWindow);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.RallyInst.TextRefresh();
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (this.RallyInst == null)
      return;
    this.RallyInst.OnOKCancelBoxClick(bOK, arg1, arg2);
  }

  public override void UpdateTime(bool bOnSecond) => this.RallyInst.UpdateTime(bOnSecond);
}
