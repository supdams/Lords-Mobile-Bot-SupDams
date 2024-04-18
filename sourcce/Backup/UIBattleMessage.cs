// Decompiled with JetBrains decompiler
// Type: UIBattleMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class UIBattleMessage : MonoBehaviour
{
  private Transform m_Transform;
  private RectTransform ButtonRC;
  private float Duration = 1.7f;
  private float halfTime = 0.15f;
  private float deltatime1;
  private float deltatime2;
  private bool bMove;
  private bool bMoveDown;
  private Vector2 to;
  private Vector2 OriginalPos;

  private void Start()
  {
    this.m_Transform = this.transform;
    this.ButtonRC = (RectTransform) this.m_Transform.GetChild(3);
    this.OriginalPos = this.ButtonRC.anchoredPosition;
    this.to = this.OriginalPos - new Vector2(0.0f, 2f);
  }

  private void Update()
  {
    if (this.bMove)
    {
      this.deltatime1 -= Time.deltaTime;
      if ((double) this.deltatime1 <= 0.0)
      {
        this.bMove = false;
        this.deltatime1 = this.Duration;
        this.ButtonRC.anchoredPosition = this.OriginalPos;
      }
      else
      {
        this.deltatime2 -= Time.deltaTime;
        if ((double) this.deltatime2 < 0.0)
        {
          this.deltatime2 = this.halfTime;
          this.bMoveDown = !this.bMoveDown;
        }
        if (this.bMoveDown)
          this.ButtonRC.anchoredPosition = Vector2.Lerp(this.ButtonRC.anchoredPosition, this.to, this.deltatime2);
        else
          this.ButtonRC.anchoredPosition = Vector2.Lerp(this.ButtonRC.anchoredPosition, this.OriginalPos, this.deltatime2);
      }
    }
    else
    {
      this.deltatime1 -= Time.deltaTime;
      if ((double) this.deltatime1 > 0.0)
        return;
      this.bMove = true;
      this.bMoveDown = true;
      this.deltatime1 = this.halfTime * 2f;
      this.deltatime2 = this.halfTime;
    }
  }
}
