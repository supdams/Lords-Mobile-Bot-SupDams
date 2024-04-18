// Decompiled with JetBrains decompiler
// Type: GooglePlayDownloader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.IO;
using UnityEngine;

#nullable disable
public class GooglePlayDownloader
{
  private const string Environment_MEDIA_MOUNTED = "mounted";
  private static AndroidJavaClass detectAndroidJNI;
  private static AndroidJavaClass Environment;
  private static string obb_package;
  private static int obb_version;

  static GooglePlayDownloader()
  {
    if (!GooglePlayDownloader.RunningOnAndroid())
      return;
    GooglePlayDownloader.Environment = new AndroidJavaClass("android.os.Environment");
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.plugin.downloader.UnityDownloaderService"))
    {
      androidJavaClass.SetStatic<string>("BASE64_PUBLIC_KEY", GameConstants.GlobalEditionPaymentKey);
      androidJavaClass.SetStatic<byte[]>("SALT", new byte[20]
      {
        (byte) 1,
        (byte) 43,
        (byte) 244,
        byte.MaxValue,
        (byte) 54,
        (byte) 98,
        (byte) 156,
        (byte) 244,
        (byte) 43,
        (byte) 2,
        (byte) 248,
        (byte) 252,
        (byte) 9,
        (byte) 5,
        (byte) 150,
        (byte) 148,
        (byte) 223,
        (byte) 45,
        byte.MaxValue,
        (byte) 84
      });
    }
  }

  public static bool RunningOnAndroid()
  {
    if (GooglePlayDownloader.detectAndroidJNI == null)
      GooglePlayDownloader.detectAndroidJNI = new AndroidJavaClass("android.os.Build");
    return GooglePlayDownloader.detectAndroidJNI.GetRawClass() != IntPtr.Zero;
  }

  public static string GetExpansionFilePath()
  {
    GooglePlayDownloader.populateOBBData();
    if (GooglePlayDownloader.Environment.CallStatic<string>("getExternalStorageState") != "mounted")
      return (string) null;
    using (AndroidJavaObject androidJavaObject = GooglePlayDownloader.Environment.CallStatic<AndroidJavaObject>("getExternalStorageDirectory"))
      return string.Format("{0}/{1}/{2}", (object) androidJavaObject.Call<string>("getPath"), (object) "Android/obb", (object) GooglePlayDownloader.obb_package);
  }

  public static string GetMainOBBPath(string expansionFilePath)
  {
    GooglePlayDownloader.populateOBBData();
    if (expansionFilePath == null)
      return (string) null;
    string path = string.Format("{0}/main.{1}.{2}.obb", (object) expansionFilePath, (object) GooglePlayDownloader.obb_version, (object) GooglePlayDownloader.obb_package);
    return !File.Exists(path) ? (string) null : path;
  }

  public static string GetPatchOBBPath(string expansionFilePath)
  {
    GooglePlayDownloader.populateOBBData();
    if (expansionFilePath == null)
      return (string) null;
    string path = string.Format("{0}/patch.{1}.{2}.obb", (object) expansionFilePath, (object) GooglePlayDownloader.obb_version, (object) GooglePlayDownloader.obb_package);
    return !File.Exists(path) ? (string) null : path;
  }

  public static void FetchOBB()
  {
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
    {
      AndroidJavaObject androidJavaObject1 = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
      AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("android.content.Intent", new object[2]
      {
        (object) androidJavaObject1,
        (object) new AndroidJavaClass("com.unity3d.plugin.downloader.UnityDownloaderActivity")
      });
      int num = 65536;
      androidJavaObject2.Call<AndroidJavaObject>("addFlags", (object) num);
      androidJavaObject2.Call<AndroidJavaObject>("putExtra", (object) "unityplayer.Activity", (object) androidJavaObject1.Call<AndroidJavaObject>("getClass").Call<string>("getName"));
      androidJavaObject1.Call("startActivity", (object) androidJavaObject2);
      if (!(AndroidJNI.ExceptionOccurred() != IntPtr.Zero))
        return;
      Debug.LogError((object) "Exception occurred while attempting to start DownloaderActivity - is the AndroidManifest.xml incorrect?");
      AndroidJNI.ExceptionDescribe();
      AndroidJNI.ExceptionClear();
    }
  }

  private static void populateOBBData()
  {
    if (GooglePlayDownloader.obb_version != 0)
      return;
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
    {
      AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
      GooglePlayDownloader.obb_package = androidJavaObject.Call<string>("getPackageName");
      GooglePlayDownloader.obb_version = androidJavaObject.Call<AndroidJavaObject>("getPackageManager").Call<AndroidJavaObject>("getPackageInfo", (object) GooglePlayDownloader.obb_package, (object) 0).Get<int>("versionCode");
    }
  }
}
