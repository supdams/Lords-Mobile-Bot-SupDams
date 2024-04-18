// Decompiled with JetBrains decompiler
// Type: IgnoreRaycast
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class IgnoreRaycast : MonoBehaviour, ICanvasRaycastFilter
{
  public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera) => false;
}
