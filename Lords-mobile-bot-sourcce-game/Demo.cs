// Decompiled with JetBrains decompiler
// Type: Demo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class Demo : MonoBehaviour
{
  private void Awake() => Screen.SetResolution(480, 854, true);

  private void Update() => this.transform.Rotate(new Vector3(0.0f, 0.0f, Time.deltaTime * 90f));

  private void OnGUI()
  {
    GUI.Label(new Rect(5f, 5f, 300f, 50f), "UnityVersion:" + Application.unityVersion);
  }
}
