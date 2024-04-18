// Decompiled with JetBrains decompiler
// Type: ImmersiveModeEnabler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class ImmersiveModeEnabler : MonoBehaviour
{
  private AndroidJavaObject unityActivity;
  private AndroidJavaObject javaObj;
  private AndroidJavaClass javaClass;
  private bool paused;
  private static bool created;

  private void Awake()
  {
    if (!Application.isEditor)
      this.HideNavigationBar();
    if (!ImmersiveModeEnabler.created)
    {
      Object.DontDestroyOnLoad((Object) this.gameObject);
      ImmersiveModeEnabler.created = true;
    }
    else
      Object.Destroy((Object) this.gameObject);
  }

  private void HideNavigationBar()
  {
    lock (this)
    {
      using (this.javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        this.unityActivity = this.javaClass.GetStatic<AndroidJavaObject>("currentActivity");
      if (this.unityActivity == null)
        return;
      using (this.javaClass = new AndroidJavaClass("com.rak24.androidimmersivemode.Main"))
      {
        if (this.javaClass == null)
          return;
        this.javaObj = this.javaClass.CallStatic<AndroidJavaObject>("instance");
        if (this.javaObj == null)
          return;
        this.unityActivity.Call("runOnUiThread", (object) (AndroidJavaRunnable) (() => this.javaObj.Call("EnableImmersiveMode", (object) this.unityActivity)));
      }
    }
  }

  private void OnApplicationPause(bool pausedState) => this.paused = pausedState;

  private void OnApplicationFocus(bool hasFocus)
  {
    if (!hasFocus || this.javaObj == null || this.paused)
      return;
    this.unityActivity.Call("runOnUiThread", (object) (AndroidJavaRunnable) (() => this.javaObj.CallStatic("ImmersiveModeFromCache", (object) this.unityActivity)));
  }

  public void PinThisApp()
  {
    if (this.javaObj == null)
      return;
    this.javaObj.CallStatic("EnableAppPin", (object) this.unityActivity);
  }

  public void UnPinThisApp()
  {
    if (this.javaObj == null)
      return;
    this.javaObj.CallStatic("DisableAppPin", (object) this.unityActivity);
  }
}
