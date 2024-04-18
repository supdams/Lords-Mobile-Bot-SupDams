// Decompiled with JetBrains decompiler
// Type: InputBox2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class InputBox2 : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (Object) menu)
    {
      img.sprite = menu.LoadSprite(ImageName);
      ((MaskableGraphic) img).material = menu.LoadMaterial();
    }
    img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
    ((MaskableGraphic) img).material = GUIManager.Instance.GetFrameMaterial();
  }

  public void OnButtonClick(UIButton sender)
  {
  }

  public void Refresh_FontTexture()
  {
  }
}
