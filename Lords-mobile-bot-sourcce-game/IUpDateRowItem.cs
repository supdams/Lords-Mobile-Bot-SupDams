// Decompiled with JetBrains decompiler
// Type: IUpDateRowItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public interface IUpDateRowItem
{
  void UpDateRowItem(GameObject[] gameObjs, int[] btnIndexs);

  void ButtonOnClick(GameObject gameObject, int dataIndex);

  void OnScroll(RectTransform rt);

  void Initialized();
}
