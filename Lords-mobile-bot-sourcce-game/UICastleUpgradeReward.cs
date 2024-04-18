// Decompiled with JetBrains decompiler
// Type: UICastleUpgradeReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UICastleUpgradeReward : GUIWindow, IUIButtonClickHandler, IUIHIBtnClickHandler
{
  private const int strCount = 10;
  private Transform panel;
  private GUIManager GM = GUIManager.Instance;
  private DataManager DM = DataManager.Instance;
  private Transform truningLight;
  private CString[] str = new CString[10];
  public RectTransform ExitBtn;
  private ushort mArg1;

  private void Start()
  {
  }

  private void Update() => this.truningLight.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);

  public override void OnOpen(int arg1, int arg2)
  {
    // ISSUE: unable to decompile the method.
  }

  public override void OnClose()
  {
    for (int index = 0; index < 10; ++index)
    {
      if (this.str[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.str[index]);
        this.str[index] = (CString) null;
      }
    }
    this.GM.ReleaseLvUpLight();
  }

  public void OnButtonClick(UIButton sender)
  {
    this.GM.CloseMenu(EGUIWindow.UI_CastleUpgradeReward);
    NewbieManager.CheckTreasBoxUpgrade();
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.panel.GetChild(2).GetChild(0).GetComponent<UIText>();
    if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.panel.GetChild(2).GetChild(2).GetComponent<UIText>();
    if ((Object) component2 != (Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.panel.GetChild(3).GetChild(0).GetComponent<UIText>();
    if ((Object) component3 != (Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.panel.GetChild(3).GetChild(2).GetComponent<UIText>();
    if ((Object) component4 != (Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    UIText component5 = this.panel.GetChild(3).GetChild(4).GetComponent<UIText>();
    if ((Object) component5 != (Object) null && ((Behaviour) component5).enabled)
    {
      ((Behaviour) component5).enabled = false;
      ((Behaviour) component5).enabled = true;
    }
    UIText component6 = this.panel.GetChild(3).GetChild(6).GetComponent<UIText>();
    if ((Object) component6 != (Object) null && ((Behaviour) component6).enabled)
    {
      ((Behaviour) component6).enabled = false;
      ((Behaviour) component6).enabled = true;
    }
    UIText component7 = this.panel.GetChild(3).GetChild(8).GetComponent<UIText>();
    if ((Object) component7 != (Object) null && ((Behaviour) component7).enabled)
    {
      ((Behaviour) component7).enabled = false;
      ((Behaviour) component7).enabled = true;
    }
    UIText component8 = this.panel.GetChild(4).GetChild(0).GetComponent<UIText>();
    if ((Object) component8 != (Object) null && ((Behaviour) component8).enabled)
    {
      ((Behaviour) component8).enabled = false;
      ((Behaviour) component8).enabled = true;
    }
    UIText component9 = this.panel.GetChild(4).GetChild(8).GetComponent<UIText>();
    if ((Object) component9 != (Object) null && ((Behaviour) component9).enabled)
    {
      ((Behaviour) component9).enabled = false;
      ((Behaviour) component9).enabled = true;
    }
    UIText component10 = this.panel.GetChild(4).GetChild(9).GetComponent<UIText>();
    if ((Object) component10 != (Object) null && ((Behaviour) component10).enabled)
    {
      ((Behaviour) component10).enabled = false;
      ((Behaviour) component10).enabled = true;
    }
    UIText component11 = this.panel.GetChild(4).GetChild(10).GetComponent<UIText>();
    if ((Object) component11 != (Object) null && ((Behaviour) component11).enabled)
    {
      ((Behaviour) component11).enabled = false;
      ((Behaviour) component11).enabled = true;
    }
    UIText component12 = this.panel.GetChild(4).GetChild(11).GetComponent<UIText>();
    if ((Object) component12 != (Object) null && ((Behaviour) component12).enabled)
    {
      ((Behaviour) component12).enabled = false;
      ((Behaviour) component12).enabled = true;
    }
    UIText component13 = this.panel.GetChild(4).GetChild(12).GetComponent<UIText>();
    if ((Object) component13 != (Object) null && ((Behaviour) component13).enabled)
    {
      ((Behaviour) component13).enabled = false;
      ((Behaviour) component13).enabled = true;
    }
    UIText component14 = this.panel.GetChild(5).GetChild(3).GetComponent<UIText>();
    if ((Object) component14 != (Object) null && ((Behaviour) component14).enabled)
    {
      ((Behaviour) component14).enabled = false;
      ((Behaviour) component14).enabled = true;
    }
    UIText component15 = this.panel.GetChild(5).GetChild(4).GetComponent<UIText>();
    if ((Object) component15 != (Object) null && ((Behaviour) component15).enabled)
    {
      ((Behaviour) component15).enabled = false;
      ((Behaviour) component15).enabled = true;
    }
    UIText component16 = this.panel.GetChild(5).GetChild(5).GetComponent<UIText>();
    if ((Object) component16 != (Object) null && ((Behaviour) component16).enabled)
    {
      ((Behaviour) component16).enabled = false;
      ((Behaviour) component16).enabled = true;
    }
    for (int index = 0; index < this.panel.GetChild(3).childCount; ++index)
    {
      UIHIBtn component17 = this.panel.GetChild(3).GetChild(index).GetComponent<UIHIBtn>();
      if ((Object) component17 != (Object) null)
        component17.Refresh_FontTexture();
    }
  }
}
