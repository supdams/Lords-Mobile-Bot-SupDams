// Decompiled with JetBrains decompiler
// Type: DownloadController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

#nullable disable
public class DownloadController
{
  private static SevenZip.Compression.LZMA.Decoder coder = new SevenZip.Compression.LZMA.Decoder();
  private static StringBuilder Path = new StringBuilder();
  private static string OSPath = string.Empty;
  private static string Prefix = string.Empty;
  private static string CDNRoot;
  private static string[] DownloadUpdates;
  private static string[] AssetUpdates;
  private static WWW bundle;
  private static WWW doodle;
  private static bool found;
  private static bool check;
  private static byte queue;
  private static float timer;
  private static float ticker;
  private static long insider;
  private static long stamper;
  private static long monster;
  private static bool refresh;
  private static bool HappyGo;
  private static uint Extraction;
  private static GameManager Gamer;
  private static float Buffer;
  private static float Terminator;
  private static byte[] Properties = new byte[8];
  private static string[][] DownloadUpdate = new string[3][];
  private static List<AssetDownload> AssDownload = new List<AssetDownload>();
  private static List<string> Pokedex;
  private static List<int> AssList;
  private static AssetDownload AssetDownloads;

  public static void Refresh() => DownloadController.check = true;

  public static void Reset(bool Clear = true)
  {
    if (DownloadController.bundle != null)
    {
      DownloadController.bundle.Dispose();
      DownloadController.bundle = (WWW) null;
    }
    if ((bool) (Object) DownloadController.Gamer)
    {
      DownloadController.Extraction = 5000U;
      DownloadController.AssetUpdates = (string[]) null;
      DownloadController.DownloadUpdates = (string[]) null;
      DownloadController.refresh = DownloadController.check = false;
      DownloadController.Gamer.StopAllCoroutines();
      NetworkManager.Instance.RequestTime = (float) (DownloadController.monster = 0L);
    }
    DownloadController.check = !Clear;
  }

  public static void Init(GameManager Gm)
  {
    DownloadController.Prefix = "file://";
    DownloadController.Gamer = Gm;
    DownloadController.CDNRoot = "http://static-lo.igg.com/Global/android";
    DownloadController.Prefix = "http://download-lo-snd.igg.com/android";
  }

  [DebuggerHidden]
  private static IEnumerator DownloadCheck()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    DownloadController.\u003CDownloadCheck\u003Ec__Iterator9 downloadCheckCIterator9 = new DownloadController.\u003CDownloadCheck\u003Ec__Iterator9();
    return (IEnumerator) downloadCheckCIterator9;
  }

  [DebuggerHidden]
  private static IEnumerator LoadStreamAssToPersistent(
    string data,
    string path,
    string file,
    string type,
    string number,
    string revision)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DownloadController.\u003CLoadStreamAssToPersistent\u003Ec__IteratorA()
    {
      path = path,
      file = file,
      data = data,
      revision = revision,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003Efile = file,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003Erevision = revision
    };
  }

  [DebuggerHidden]
  private static IEnumerator StartDownload()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    DownloadController.\u003CStartDownload\u003Ec__IteratorB downloadCIteratorB = new DownloadController.\u003CStartDownload\u003Ec__IteratorB();
    return (IEnumerator) downloadCIteratorB;
  }

  [DebuggerHidden]
  private static IEnumerator ProceedDownload()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    DownloadController.\u003CProceedDownload\u003Ec__IteratorC downloadCIteratorC = new DownloadController.\u003CProceedDownload\u003Ec__IteratorC();
    return (IEnumerator) downloadCIteratorC;
  }

  public static void ReloadAssetBundle(string Name)
  {
    AssetManager.RefreshAssetBundle(Name.ToUpperInvariant().GetHashCode());
    GameManager.OnRefresh(NetworkNews.Refresh_Asset);
  }

  public static void Fallback() => DownloadController.bundle = (WWW) null;

  public static void Check()
  {
    if (!DownloadController.check || DownloadController.refresh || GameManager.ActiveGameplay == null || GameManager.ActiveGameplay is UpdateController)
      return;
    DownloadController.Gamer.StartCoroutine(DownloadController.DownloadCheck());
  }
}
