// Decompiled with JetBrains decompiler
// Type: UI_NewTerritory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UI_NewTerritory : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler
{
  private const byte MaxBuildCount = 10;
  private Transform m_transform;
  private Transform Back01T;
  private Transform TitleImgT;
  private Transform Back02T;
  private Transform Back03T;
  private Transform Back04T;
  private Transform TitleText01T;
  private Transform TitleText02T;
  private Transform TitleText03T;
  private Transform CloseBtnT;
  private Transform[] BuildingT = new Transform[10];
  private Image[] BuildingImage = new Image[10];
  private UIText[] BuildingText = new UIText[10];
  private GUIManager GM = GUIManager.Instance;
  private DataManager DM = DataManager.Instance;
  private ushort[] ShowKind = new ushort[2];
  private ushort[][] BuildID = new ushort[6][]
  {
    new ushort[4]
    {
      (ushort) 1,
      (ushort) 2,
      (ushort) 3,
      (ushort) 4
    },
    new ushort[3]{ (ushort) 5, (ushort) 6, (ushort) 7 },
    new ushort[9]
    {
      (ushort) 9,
      (ushort) 10,
      (ushort) 11,
      (ushort) 13,
      (ushort) 14,
      (ushort) 15,
      (ushort) 17,
      (ushort) 18,
      (ushort) 19
    },
    new ushort[1]{ (ushort) 8 },
    new ushort[2]{ (ushort) 12, (ushort) 16 },
    new ushort[4]
    {
      (ushort) 20,
      (ushort) 21,
      (ushort) 22,
      (ushort) 23
    }
  };
  private UIText[] RBText = new UIText[3];

  public override void OnOpen(int arg1, int arg2)
  {
    // ISSUE: unable to decompile the method.
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    for (int index = 0; index < this.BuildingText.Length; ++index)
    {
      if ((Object) this.BuildingText[index] != (Object) null && ((Behaviour) this.BuildingText[index]).enabled)
      {
        ((Behaviour) this.BuildingText[index]).enabled = false;
        ((Behaviour) this.BuildingText[index]).enabled = true;
      }
    }
    for (int index = 0; index < this.RBText.Length; ++index)
    {
      if ((Object) this.RBText[index] != (Object) null && ((Behaviour) this.RBText[index]).enabled)
      {
        ((Behaviour) this.RBText[index]).enabled = false;
        ((Behaviour) this.RBText[index]).enabled = true;
      }
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    DataManager.msgBuffer[0] = (byte) 20;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, (int) sender.Parm1, 0, Vector2.zero);
  }

  public void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide();
}
