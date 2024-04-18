// Decompiled with JetBrains decompiler
// Type: Damage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class Damage
{
  private Damage.DamageState damageState;
  private GameObject DamageGameObject;
  private Transform DamageTransform;
  private TextMesh DamageText;
  private CString DamageString;
  private NPC DamageNPC;
  private float DamageScale;
  private float DamageAlpha;
  private float DamageYoffset;

  public Damage(Transform parentTransform, Font TextFront)
  {
    this.DamageString = new CString(10);
    this.DamageGameObject = new GameObject("damage");
    this.DamageText = this.DamageGameObject.AddComponent<TextMesh>();
    this.DamageText.font = TextFront;
    this.DamageText.color = Color.red;
    this.DamageGameObject.GetComponent<MeshRenderer>().material = TextFront.material;
    this.DamageTransform = this.DamageGameObject.transform;
    this.DamageTransform.SetParent(parentTransform, false);
    this.SetActive(false);
  }

  public void Tick(float deltaTime)
  {
    if (this.DamageNPC == null)
      return;
    switch (this.damageState)
    {
      case Damage.DamageState.Scale:
        this.DamageScale += deltaTime * 25f;
        if ((double) this.DamageScale >= 10.0)
        {
          this.DamageScale = 10f;
          this.damageState = Damage.DamageState.Fadeout;
        }
        this.DamageTransform.localScale = new Vector3(this.DamageScale, this.DamageScale, this.DamageScale);
        break;
      case Damage.DamageState.Fadeout:
        this.DamageAlpha -= deltaTime * 0.8333333f;
        if ((double) this.DamageAlpha < 0.0)
        {
          this.DamageAlpha = 0.0f;
          this.DamageNPC.DelDamage(this);
          return;
        }
        this.DamageYoffset += deltaTime * 0.25f;
        this.DamageText.color = this.DamageText.color with
        {
          a = this.DamageAlpha
        };
        break;
    }
    this.DamageTransform.position = new Vector3(this.DamageNPC.NPCPos.x + 1f, this.DamageNPC.NPCPos.y + this.DamageYoffset, 37f);
  }

  public void Release()
  {
    this.DamageGameObject = (GameObject) null;
    this.DamageTransform = (Transform) null;
    this.DamageText = (TextMesh) null;
    this.DamageNPC = (NPC) null;
  }

  public void updateDamage(NPC npc) => this.DamageNPC = npc;

  public void updateDamage(float DamageValue)
  {
    this.DamageString.ClearString();
    this.DamageString.FloatToFormat(DamageValue, 2);
    if (GUIManager.Instance.IsArabic)
      this.DamageString.AppendFormat("%{0}-");
    else
      this.DamageString.AppendFormat("-{0}%");
    this.DamageText.text = this.DamageString.ToString();
    this.DamageScale = 0.0f;
    this.DamageTransform.localScale = new Vector3(this.DamageScale, this.DamageScale, this.DamageScale);
    this.damageState = Damage.DamageState.Scale;
    this.DamageAlpha = 1f;
    this.DamageText.color = this.DamageText.color with
    {
      a = this.DamageAlpha
    };
    this.DamageYoffset = 0.0f;
  }

  public void SetActive(bool active)
  {
    if (!active)
    {
      this.DamageNPC = (NPC) null;
      this.damageState = Damage.DamageState.None;
    }
    this.DamageGameObject.SetActive(active);
  }

  private enum DamageState : byte
  {
    None,
    Scale,
    Fadeout,
  }
}
