// Decompiled with JetBrains decompiler
// Type: SheetAnimationUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class SheetAnimationUnit
{
  private const float SPF = 0.066f;
  private const float cameraScale = 1.4545f;
  public GameObject gameObject;
  public Transform transform;
  public SpriteRenderer kdmr;
  private Sprite[] AnimArray;
  private float sheetTimer;
  private int sheetLen;
  private int sheetIdx = 1;
  private float speedRate = 1f;
  private float CurSPF = 0.066f;
  private float FixedSPF;
  private int StopPoint = -1;

  public SheetAnimationUnit(
    uint actionID,
    Dictionary<uint, Sprite[]> animMap,
    Material sharedMat,
    bool bMirror = false,
    float speed = 1f,
    bool AttackerDirection = false)
  {
    this.gameObject = new GameObject("AnimUnit");
    this.transform = this.gameObject.transform;
    this.kdmr = this.gameObject.AddComponent<SpriteRenderer>();
    this.kdmr.material = sharedMat;
    this.gameObject.transform.localScale = new Vector3(1.4545f, 1.4545f, 1.4545f);
    this.ResetUnit(actionID, animMap, bMirror, speed, AttackerDirection);
  }

  public void ResetUnit(
    uint actionID,
    Dictionary<uint, Sprite[]> animMap,
    bool bMirror = false,
    float speed = 1f,
    bool AttackerDirection = false)
  {
    if (!this.gameObject.activeSelf)
      this.gameObject.SetActive(true);
    if (!animMap.ContainsKey(actionID))
      Debug.Log((object) ("found " + (object) actionID));
    this.AnimArray = animMap[actionID];
    this.sheetIdx = Random.Range(1, this.AnimArray.Length);
    this.kdmr.sprite = this.AnimArray[this.sheetIdx - 1];
    this.sheetLen = this.AnimArray.Length;
    this.speedRate = speed;
    this.CurSPF = (float) (1.0 / (double) this.speedRate * 0.065999999642372131);
    this.FixedSPF = this.CurSPF;
    this.gameObject.transform.rotation = Quaternion.identity;
    this.gameObject.transform.localRotation = !bMirror ? (!AttackerDirection ? Quaternion.identity : Quaternion.Euler(0.0f, 0.0f, 315f)) : (!AttackerDirection ? Quaternion.Euler(0.0f, 180f, 0.0f) : Quaternion.Euler(0.0f, 180f, 315f));
    this.StopPoint = -1;
    if ((int) (actionID / 10U) % 1000 == 9)
    {
      this.StopPoint = (int) DataManager.MapDataController.MapMonsterTable.GetRecordByKey((ushort) 1).HitFrame;
      this.sheetIdx = 1;
      this.kdmr.sprite = this.AnimArray[0];
    }
    else
    {
      if (this.sheetIdx < this.sheetLen)
        return;
      this.sheetIdx = this.sheetLen - 1;
    }
  }

  public int Update(float deltaTime)
  {
    if (this.sheetLen <= 1)
      return 0;
    this.sheetTimer += deltaTime;
    int num = 0;
    if ((double) this.sheetTimer >= (double) this.FixedSPF)
    {
      this.sheetTimer = 0.0f;
      this.kdmr.sprite = this.AnimArray[this.sheetIdx];
      if (this.StopPoint == this.sheetIdx)
      {
        this.FixedSPF = this.CurSPF * 3f;
        num = 1;
      }
      else
        this.FixedSPF = this.CurSPF;
      ++this.sheetIdx;
      if (this.sheetIdx >= this.sheetLen)
        this.sheetIdx = 0;
    }
    return num;
  }
}
