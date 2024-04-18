// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.OurUtils.Logger
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
namespace GooglePlayGames.OurUtils
{
  public class Logger
  {
    private static bool debugLogEnabled;
    private static bool warningLogEnabled = true;

    public static bool DebugLogEnabled
    {
      get => Logger.debugLogEnabled;
      set => Logger.debugLogEnabled = value;
    }

    public static bool WarningLogEnabled
    {
      get => Logger.warningLogEnabled;
      set => Logger.warningLogEnabled = value;
    }

    public static void d(string msg)
    {
      if (!Logger.debugLogEnabled)
        return;
      Debug.Log((object) Logger.ToLogMessage(string.Empty, "DEBUG", msg));
    }

    public static void w(string msg)
    {
      if (!Logger.warningLogEnabled)
        return;
      Debug.LogWarning((object) Logger.ToLogMessage("!!!", "WARNING", msg));
    }

    public static void e(string msg)
    {
      if (!Logger.warningLogEnabled)
        return;
      Debug.LogWarning((object) Logger.ToLogMessage("***", "ERROR", msg));
    }

    public static string describe(byte[] b)
    {
      return b == null ? "(null)" : "byte[" + (object) b.Length + "]";
    }

    private static string ToLogMessage(string prefix, string logType, string msg)
    {
      return string.Format("{0} [Play Games Plugin DLL] {1} {2}: {3}", (object) prefix, (object) DateTime.Now.ToString("MM/dd/yy H:mm:ss zzz"), (object) logType, (object) msg);
    }
  }
}
