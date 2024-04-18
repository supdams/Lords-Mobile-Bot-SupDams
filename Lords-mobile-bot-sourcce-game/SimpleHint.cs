// Decompiled with JetBrains decompiler
// Type: SimpleHint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class SimpleHint : HintStyleBase
{
  private CString Content;
  private UIText ContText;
  private SimpleHintKind[] KindArray = new SimpleHintKind[4];

  public SimpleHint(RectTransform transform)
  {
    this.rectTrans = transform;
    this.ContText = ((Transform) this.rectTrans).GetChild(0).GetComponent<UIText>();
    this.ContText.font = GUIManager.Instance.GetTTFFont();
    this.Content = new CString(512);
    this.HintFrameSprite = GUIManager.Instance.LoadFrameSprite("UI_main_box_012");
    this.HintFrameMat = GUIManager.Instance.GetFrameMaterial();
  }

  public override void SetStyle(byte style)
  {
  }

  public override Vector2 GetSize() => this.Size;

  public override void SetContent(int kind, int fontsize, float width, int Parm1, int Parm2 = 0)
  {
    this.ContText.fontSize = fontsize;
    this.Size.x = width;
    if (this.KindArray[kind] == null)
      this.CreateStyle(kind);
    this.ContText.text = this.KindArray[kind].SetContent(this.Content, Parm1, Parm2);
    if (this.Content.Length > 0)
    {
      this.ContText.SetAllDirty();
      this.ContText.cachedTextGenerator.Invalidate();
      this.ContText.cachedTextGeneratorForLayout.Invalidate();
    }
    this.Size.y = this.ContText.preferredHeight + 16f;
    if (this.ContText.cachedTextGeneratorForLayout.lineCount == 1)
    {
      this.Size.x = this.ContText.preferredWidth + 16f;
    }
    else
    {
      if ((byte) kind != (byte) 3 || (double) this.ContText.preferredWidth + 16.0 >= (double) width)
        return;
      this.Size.x = this.ContText.preferredWidth + 16f;
    }
  }

  public override void SetContent(int kind, int fontsize, float width, CString cont)
  {
    this.ContText.fontSize = fontsize;
    this.Size.x = width;
    this.Content.ClearString();
    this.Content.Append(cont);
    this.ContText.text = this.Content.ToString();
    this.ContText.SetAllDirty();
    this.ContText.cachedTextGenerator.Invalidate();
    this.ContText.cachedTextGeneratorForLayout.Invalidate();
    this.Size.y = this.ContText.preferredHeight + 16f;
    if (this.ContText.cachedTextGeneratorForLayout.lineCount == 1)
    {
      this.Size.x = this.ContText.preferredWidth + 16f;
    }
    else
    {
      if ((byte) kind != (byte) 3 || (double) this.ContText.preferredWidth + 16.0 >= (double) width)
        return;
      this.Size.x = this.ContText.preferredWidth + 16f;
    }
  }

  private void CreateStyle(int kind)
  {
    switch ((byte) kind)
    {
      case 0:
        this.KindArray[kind] = (SimpleHintKind) new NormalSimpleHint();
        break;
      case 1:
        this.KindArray[kind] = (SimpleHintKind) new KingdomSimpleHint();
        break;
      case 2:
        this.KindArray[kind] = (SimpleHintKind) new CastleSkinHint();
        break;
      case 3:
        this.KindArray[kind] = (SimpleHintKind) new ArmyKindHint();
        break;
    }
  }

  public override void TextRefresh()
  {
    ((Behaviour) this.ContText).enabled = false;
    ((Behaviour) this.ContText).enabled = true;
  }

  public enum eKind : byte
  {
    eNormal,
    eKingdomMap,
    eCastleSkin,
    eArmy,
    Max,
  }
}
