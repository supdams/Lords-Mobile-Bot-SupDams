// Decompiled with JetBrains decompiler
// Type: CustomImage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class CustomImage : Image
{
  public string ImageName;
  public string TextureName;
  public UILoadImageHander hander;

  protected virtual void Start()
  {
    ((UIBehaviour) this).Start();
    if (this.hander == null || this.ImageName == null || this.TextureName == null)
      return;
    this.hander.LoadCustomImage((Image) this, this.ImageName, this.TextureName);
  }

  protected virtual void OnEnable()
  {
    ((MaskableGraphic) this).OnEnable();
    if (this.hander == null || this.ImageName == null || this.TextureName == null || !((Object) this.sprite == (Object) null))
      return;
    this.hander.LoadCustomImage((Image) this, this.ImageName, this.TextureName);
  }
}
