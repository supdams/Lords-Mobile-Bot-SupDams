// Decompiled with JetBrains decompiler
// Type: ForwardEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class ForwardEffect : MotionEffect
{
  public GameObject gameobject;
  public Vector3[] offsetCenter;
  public SpriteRenderer[] spriteRender;
  public Vector3[] oriScale;
  public float TotalTime = 3f;
  private float CurTime;

  public void SetGameObject(GameObject go)
  {
    this.gameobject = go;
    Vector3 zero = Vector3.zero;
    this.offsetCenter = new Vector3[this.gameobject.transform.childCount];
    this.spriteRender = new SpriteRenderer[this.gameobject.transform.childCount];
    this.oriScale = new Vector3[this.gameobject.transform.childCount];
    ushort index1;
    for (index1 = (ushort) 0; (int) index1 < this.gameobject.transform.childCount; ++index1)
    {
      this.offsetCenter[(int) index1] = this.gameobject.transform.GetChild((int) index1).position;
      this.spriteRender[(int) index1] = this.gameobject.transform.GetChild((int) index1).gameObject.GetComponent<SpriteRenderer>();
      this.spriteRender[(int) index1].sortingOrder = -1;
      this.oriScale[(int) index1] = this.gameobject.transform.GetChild((int) index1).localScale;
      zero += this.offsetCenter[(int) index1];
    }
    Vector3 vector3 = zero / (float) index1;
    for (int index2 = 0; index2 < this.offsetCenter.Length; ++index2)
    {
      this.offsetCenter[index2] = vector3 - this.offsetCenter[index2];
      this.offsetCenter[index2].Normalize();
    }
    this.bMove = true;
    this.CurTime = 0.0f;
  }

  public override bool UpdateRun(float delta)
  {
    for (int index = 0; index < this.gameobject.transform.childCount; ++index)
    {
      this.gameobject.transform.GetChild(index).Translate(this.offsetCenter[index].normalized * delta * 7.5f);
      this.gameobject.transform.GetChild(index).localScale += this.oriScale[index] * (float) (0.00089999998454004526 * ((double) this.CurTime / (double) this.TotalTime));
      Color color = this.spriteRender[index].color with
      {
        a = (float) (1.0 - 1.0 * ((double) this.CurTime / (double) this.TotalTime))
      };
      this.spriteRender[index].color = color;
    }
    this.CurTime += delta;
    if ((double) this.CurTime > (double) this.TotalTime)
    {
      this.CurTime = 0.0f;
      this.bMove = false;
    }
    return true;
  }
}
