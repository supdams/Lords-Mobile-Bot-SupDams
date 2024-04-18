// Decompiled with JetBrains decompiler
// Type: GUIWindow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class GUIWindow : MonoBehaviour
{
  public EGUIWindow m_eWindow;
  public AssetBundle m_AssetBundle;
  public int m_AssetBundleKey;
  public bool m_bDontDestroyOnSwitch;

  public virtual void OnOpen(int arg1, int arg2)
  {
  }

  public virtual void OnClose()
  {
  }

  public virtual void UpdateUI(int arg1, int arg2)
  {
  }

  public virtual void UpdateNetwork(byte[] meg)
  {
  }

  public virtual void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
  }

  public virtual bool OnBackButtonClick() => false;

  public virtual void ReOnOpen()
  {
  }

  public virtual void UpdateTime(bool bOnSecond)
  {
  }
}
