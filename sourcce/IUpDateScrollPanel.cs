// Decompiled with JetBrains decompiler
// Type: IUpDateScrollPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public interface IUpDateScrollPanel
{
  void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId);

  void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId);
}
