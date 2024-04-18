// Decompiled with JetBrains decompiler
// Type: LogTool
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

#nullable disable
public class LogTool : MonoBehaviour
{
  private static List<string> mLines = new List<string>();
  private static List<string> mWriteTxt = new List<string>();
  public static bool bIgnore;
  private string outpath;

  private void Start()
  {
    this.outpath = Application.persistentDataPath + "/outLog.txt";
    if (File.Exists(this.outpath))
      File.Delete(this.outpath);
    Application.RegisterLogCallback(new Application.LogCallback(this.HandleLog));
  }

  private void Update()
  {
    if (LogTool.mWriteTxt.Count <= 0)
      return;
    foreach (string str in LogTool.mWriteTxt.ToArray())
    {
      using (StreamWriter streamWriter = new StreamWriter(this.outpath, true, Encoding.UTF8))
        streamWriter.WriteLine(str);
      LogTool.mWriteTxt.Remove(str);
    }
  }

  private void HandleLog(string logString, string stackTrace, LogType type)
  {
    if (type == LogType.Log || LogTool.bIgnore)
      return;
    LogTool.mWriteTxt.Add(logString);
    if (type != LogType.Error && type != LogType.Exception)
      return;
    LogTool.mWriteTxt.Add(stackTrace);
    LogTool.Log((object) logString);
    if (!(logString.Substring(0, 1) != "@"))
      return;
    LogTool.Log((object) stackTrace);
  }

  public static void Log(params object[] objs)
  {
    string str = string.Empty;
    for (int index = 0; index < objs.Length; ++index)
      str = index != 0 ? str + ", " + objs[index].ToString() : str + objs[index].ToString();
    if (!Application.isPlaying)
      return;
    if (LogTool.mLines.Count > 20)
      LogTool.mLines.RemoveAt(0);
    LogTool.mLines.Add(str);
  }

  private void OnGUI()
  {
    GUI.color = Color.red;
    int index = 0;
    for (int count = LogTool.mLines.Count; index < count; ++index)
      GUILayout.Label(LogTool.mLines[index]);
  }

  public static void Clear()
  {
    if (LogTool.mLines == null || LogTool.mLines.Count <= 0)
      return;
    LogTool.mLines.Clear();
  }
}
