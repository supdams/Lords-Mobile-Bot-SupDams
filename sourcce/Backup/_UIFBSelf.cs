// Decompiled with JetBrains decompiler
// Type: _UIFBSelf
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public struct _UIFBSelf
{
  private GameObject gameobject;
  private RectTransform recttransform;
  private RectTransform SelfRect;
  private Transform LordsTrans;
  private UIText Title;
  private byte bInitSize;
  private _UIFBSelf._Style Style;

  public _UIFBSelf(Transform transform, Font font)
  {
    this.recttransform = transform.GetComponent<RectTransform>();
    this.gameobject = transform.gameObject;
    this.Title = ((Transform) this.recttransform).GetChild(0).GetChild(1).GetComponent<UIText>();
    this.Title.font = font;
    this.Title.text = DataManager.Instance.mStringTable.GetStringByID(12165U);
    this.LordsTrans = transform.GetChild(0).GetChild(0);
    GUIManager.Instance.InitianHeroItemImg(this.LordsTrans, eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.SelfRect = transform.GetChild(0).GetComponent<RectTransform>();
    this.bInitSize = (byte) 0;
    this.Style = _UIFBSelf._Style.Narrow;
  }

  public float Top
  {
    set
    {
      this.recttransform.anchoredPosition = new Vector2(this.recttransform.anchoredPosition.x, value);
    }
  }

  public float Width => this.recttransform.sizeDelta.x;

  public float Height
  {
    get => this.recttransform.sizeDelta.y;
    set => this.recttransform.sizeDelta = new Vector2(this.recttransform.sizeDelta.x, value);
  }

  public void Show(_UIFBSelf._Style style)
  {
    this.gameobject.SetActive(true);
    if (this.Style != style)
    {
      this.Style = style;
      this.bInitSize = (byte) 0;
      this.recttransform.sizeDelta = this.Style != _UIFBSelf._Style.Narrow ? new Vector2(624f, this.recttransform.sizeDelta.y) : new Vector2(330f, this.recttransform.sizeDelta.y);
    }
    if (this.bInitSize != (byte) 0)
      return;
    this.bInitSize = (byte) 1;
    float x1 = this.Title.preferredWidth;
    float num = this.recttransform.sizeDelta.x - 110f;
    if ((double) x1 > (double) num)
    {
      this.Title.resizeTextForBestFit = true;
      x1 = num;
    }
    ((Graphic) this.Title).rectTransform.sizeDelta = new Vector2(x1, ((Graphic) this.Title).rectTransform.sizeDelta.y);
    float x2 = (float) (((double) this.recttransform.sizeDelta.x - (double) ((Graphic) this.Title).rectTransform.anchoredPosition.x - (double) x1) * 0.5);
    ((Component) this.SelfRect).GetComponent<RectTransform>().anchoredPosition = new Vector2(x2, this.recttransform.anchoredPosition.y);
  }

  public void Hide() => this.gameobject.SetActive(false);

  public void TextRefresh()
  {
    ((Behaviour) this.Title).enabled = false;
    ((Behaviour) this.Title).enabled = true;
  }

  public enum _Style
  {
    Narrow,
    Wide,
  }
}
