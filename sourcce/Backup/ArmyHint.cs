// Decompiled with JetBrains decompiler
// Type: ArmyHint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ArmyHint : HintStyleBase
{
  private Transform P1;
  private Transform P2;
  private UIText[] ContText = new UIText[4];

  public ArmyHint(RectTransform transform)
  {
    this.rectTrans = transform;
    this.P1 = ((Transform) this.rectTrans).GetChild(0);
    this.ContText[0] = this.P1.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.ContText[0].font = GUIManager.Instance.GetTTFFont();
    this.ContText[0].text = DataManager.Instance.mStringTable.GetStringByID(11161U);
    this.ContText[1] = this.P1.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.ContText[1].font = GUIManager.Instance.GetTTFFont();
    this.ContText[1].text = DataManager.Instance.mStringTable.GetStringByID(11166U);
    this.P2 = ((Transform) this.rectTrans).GetChild(1);
    this.ContText[2] = this.P2.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.ContText[2].font = GUIManager.Instance.GetTTFFont();
    this.ContText[2].text = DataManager.Instance.mStringTable.GetStringByID(11161U);
    this.ContText[3] = this.P2.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.ContText[3].font = GUIManager.Instance.GetTTFFont();
    this.ContText[3].text = DataManager.Instance.mStringTable.GetStringByID(11166U);
  }

  public override void SetStyle(byte style)
  {
  }

  public override Vector2 GetSize() => this.Size;

  public override void SetContent(int kind, int fontsize, float width, int Parm1, int Parm2 = 0)
  {
    if (Parm1 == 0)
    {
      this.Size = new Vector2(547f, 339f);
      this.P1.gameObject.SetActive(true);
      this.P2.gameObject.SetActive(false);
    }
    else
    {
      this.Size = new Vector2(449f, 330f);
      this.P1.gameObject.SetActive(false);
      this.P2.gameObject.SetActive(true);
    }
  }

  public override void TextRefresh()
  {
    for (int index = 0; index < 4; ++index)
    {
      if ((Object) this.ContText[index] != (Object) null && ((Behaviour) this.ContText[index]).enabled)
      {
        ((Behaviour) this.ContText[index]).enabled = false;
        ((Behaviour) this.ContText[index]).enabled = true;
      }
    }
  }
}
