// Decompiled with JetBrains decompiler
// Type: ActivityData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class ActivityData : ScriptableObject
{
  public int Count;
  public string[] Content;

  public ActivityData init(string[] content, int count)
  {
    this.Content = content;
    this.Count = count;
    return this;
  }
}
