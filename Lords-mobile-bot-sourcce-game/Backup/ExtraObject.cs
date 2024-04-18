// Decompiled with JetBrains decompiler
// Type: ExtraObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
internal class ExtraObject
{
  private const string AdvanceEventContinuousDataTag = "AdvanceEventContinuousDataTag_";
  private const string AdvanceEventContinuousCountTag = "AdvanceEventContinuousCountTag_";
  public DateTime TriggerDate;
  public byte UnbrokenDay;
  public int DataIdx;

  public ExtraObject(int eAppsFlayerEvent)
  {
    this.DataIdx = eAppsFlayerEvent;
    this.InitData(this.DataIdx);
  }

  public int GetDifference()
  {
    try
    {
      if (this.TriggerDate.Year == 2000)
        return 0;
      TimeSpan timeSpan = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) - this.TriggerDate;
      return timeSpan.Days > 0 ? timeSpan.Days : 0;
    }
    catch (SystemException ex)
    {
      return 0;
    }
  }

  public bool SetUnbrokenDay()
  {
    bool flag = false;
    this.GetData();
    int difference = this.GetDifference();
    this.TriggerDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
    if (difference == 1)
    {
      ++this.UnbrokenDay;
      flag = true;
      this.SaveData();
    }
    else if (difference > 1)
    {
      this.UnbrokenDay = (byte) 1;
      flag = false;
      this.SaveData();
    }
    return flag;
  }

  private void SaveData()
  {
    try
    {
      PlayerPrefs.SetString("AdvanceEventContinuousDataTag_" + (object) this.DataIdx, this.TriggerDate.ToString());
      PlayerPrefs.SetString("AdvanceEventContinuousCountTag_" + (object) this.DataIdx, this.UnbrokenDay.ToString());
    }
    catch (SystemException ex)
    {
      Debug.Log((object) ex.ToString());
    }
  }

  public void InitData(int DataIdx)
  {
    try
    {
      this.TriggerDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
      this.UnbrokenDay = (byte) 0;
    }
    catch (SystemException ex)
    {
      Debug.Log((object) ex.ToString());
    }
  }

  private void GetData()
  {
    try
    {
      string str = PlayerPrefs.GetString("AdvanceEventContinuousDataTag_" + (object) this.DataIdx);
      if (str != null && str != string.Empty)
      {
        this.TriggerDate = Convert.ToDateTime(str);
        byte.TryParse(PlayerPrefs.GetString("AdvanceEventContinuousCountTag_" + (object) this.DataIdx), out this.UnbrokenDay);
      }
      else
      {
        this.TriggerDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        this.UnbrokenDay = (byte) 1;
        this.SaveData();
      }
    }
    catch (SystemException ex)
    {
      Debug.Log((object) ex.ToString());
    }
  }
}
