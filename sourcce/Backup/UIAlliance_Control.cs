// Decompiled with JetBrains decompiler
// Type: UIAlliance_Control
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAlliance_Control
{
  public Image animImg;
  private UIAllianceRankAnime spriteAnim;
  private Vector3 Source;
  private Vector3 Destination;
  private float DeltaTime;
  private float SpeedTime;
  private byte State;
  private float Angle;
  private RectTransform ImgRect;

  public RectTransform rectTransform
  {
    get
    {
      if ((Object) this.ImgRect == (Object) null)
        this.ImgRect = ((Graphic) this.animImg).rectTransform;
      return this.ImgRect;
    }
  }

  public void Initial(Image animImg)
  {
    this.animImg = animImg;
    SheetAnimationUnitGroup.sharedMat.renderQueue = 3000;
    ((MaskableGraphic) this.animImg).material = SheetAnimationUnitGroup.sharedMat;
    this.spriteAnim = new UIAllianceRankAnime();
    this.spriteAnim.m_Image = animImg;
  }

  public void SetAnimState(UIAlliance_Control.eRankState state)
  {
    this.State = state == UIAlliance_Control.eRankState.RankUp || state == UIAlliance_Control.eRankState.RankEqual ? (byte) 9 : (byte) 22;
    this.Angle = 270f;
    this.spriteAnim.m_Sprites = SheetAnimationUnitGroup.GetActionSpriteArray((byte) 0, this.State, this.Angle);
    this.spriteAnim.SetSpriteIndex(0);
  }

  public void MoveTo(Transform DestTran, float Z, float angle, float speed = 1f)
  {
    this.Source = ((Component) this.animImg).transform.localPosition;
    this.Destination = DestTran.localPosition;
    this.DeltaTime = 0.0f;
    this.Source.z = this.Destination.z = Z;
    if ((double) angle > 180.0)
      ((Transform) this.rectTransform).localRotation = new Quaternion(0.0f, 180f, 0.0f, 0.0f);
    this.spriteAnim.m_Sprites = SheetAnimationUnitGroup.GetActionSpriteArray((byte) 0, this.State, angle);
    this.spriteAnim.SetSpriteIndex(0);
    this.SpeedTime = speed;
  }

  public void Destroy() => SheetAnimationUnitGroup.sharedMat.renderQueue = 2660;

  public void Update()
  {
    if (!((Component) this.ImgRect).gameObject.activeSelf || !((Object) this.animImg != (Object) null))
      return;
    if (this.spriteAnim != null)
      this.spriteAnim.Update();
    if ((double) this.SpeedTime <= 0.0)
      return;
    if ((double) this.SpeedTime <= (double) this.DeltaTime)
    {
      this.SpeedTime = 0.0f;
      ((Component) this.animImg).transform.localPosition = this.Destination;
      ((Transform) this.rectTransform).localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
      this.spriteAnim.m_Sprites = SheetAnimationUnitGroup.GetActionSpriteArray((byte) 0, this.State, this.Angle);
    }
    else
    {
      ((Component) this.animImg).transform.localPosition = this.Source + (this.Destination - this.Source) * (this.DeltaTime / this.SpeedTime);
      this.DeltaTime += Time.deltaTime;
    }
  }

  public enum eRankState
  {
    RankUp,
    RankDown,
    RankEqual,
  }
}
