// Decompiled with JetBrains decompiler
// Type: BrokenFO
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class BrokenFO : SheetAnimMesh
{
  public BrokenFO(byte kind, byte tier)
    : base(EWarMeshKind.FO, kind, tier, (byte) 0)
  {
    this.transform.gameObject.SetActive(false);
    this.animNotify = new SheetAnimMesh.AnimNotify(this.AnimOnceNotify);
  }

  public bool Play(Transform trans)
  {
    this.transform.gameObject.SetActive(true);
    this.transform.position = trans.position;
    this.transform.rotation = trans.rotation;
    this.IsPlaying = true;
    return this.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Once, false, true, true);
  }

  public bool Play(Vector3 pos, Vector3 dir)
  {
    this.transform.gameObject.SetActive(true);
    this.transform.position = pos;
    this.transform.rotation = Quaternion.LookRotation(dir);
    this.IsPlaying = true;
    return this.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Once, false, true, true);
  }

  public bool Play(Vector3 pos, Quaternion qua)
  {
    this.transform.gameObject.SetActive(true);
    this.transform.position = pos;
    this.transform.rotation = qua;
    this.IsPlaying = true;
    return this.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Once, false, true, true);
  }

  public void AnimOnceNotify(ESheetMeshAnim finishAnim)
  {
    this.transform.gameObject.SetActive(false);
  }
}
