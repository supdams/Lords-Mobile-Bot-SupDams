// Decompiled with JetBrains decompiler
// Type: DemandResources
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class DemandResources : MonoBehaviour, IUIButtonClickHandler
{
  public ushort DRID;
  public int OutputValue;
  public Image[] BtnResources;
  public Image[] ImgResources;
  public UIText[] TextResources;
  public uint[] tmpValue = new uint[5];
  private StringBuilder tmpString = new StringBuilder();

  public void OnButtonClick(UIButton sender)
  {
    int num = sender.m_BtnID1 - 999;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (Object) menu)
      return;
    DataManager.Instance.bSoldierSave = true;
    DataManager.Instance.bSetExpediton = true;
    menu.OpenMenu(EGUIWindow.UI_BagFilter, 1 + (4 + num << 16), (int) this.tmpValue[num - 1]);
  }

  public void Refresh_FontTexture()
  {
    for (int index = 0; index < 5; ++index)
    {
      if ((Object) this.TextResources[index] != (Object) null && ((Behaviour) this.TextResources[index]).enabled)
      {
        ((Behaviour) this.TextResources[index]).enabled = false;
        ((Behaviour) this.TextResources[index]).enabled = true;
      }
    }
  }
}
