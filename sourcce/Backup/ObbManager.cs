// Decompiled with JetBrains decompiler
// Type: ObbManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class ObbManager : Gameplay
{
  private string expPath;
  private bool bSendDownload;

  protected override void UpdateNext(byte[] meg)
  {
  }

  protected override void UpdateLoad(byte[] meg)
  {
    this.expPath = GooglePlayDownloader.GetExpansionFilePath();
    AssetManager.Instance.AssetManagerState = AssetState.Ready;
  }

  protected override void UpdateReady(byte[] meg)
  {
  }

  protected override void UpdateRun(byte[] meg)
  {
    if (this.expPath == null)
      return;
    string mainObbPath = GooglePlayDownloader.GetMainOBBPath(this.expPath);
    if (mainObbPath == null && !this.bSendDownload)
    {
      this.bSendDownload = true;
      GooglePlayDownloader.FetchOBB();
    }
    else
    {
      if (mainObbPath == null)
        return;
      GameManager.SwitchGameplay(GameplayKind.Update);
    }
  }
}
