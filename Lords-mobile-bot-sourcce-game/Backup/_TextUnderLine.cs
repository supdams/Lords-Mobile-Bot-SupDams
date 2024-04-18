// Decompiled with JetBrains decompiler
// Type: _TextUnderLine
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public struct _TextUnderLine
{
  public GameObject gameobject;
  private RectTransform LineRect;
  private RectTransform BtnRect;
  private RectTransform recttransform;
  private CString Str;
  private UIText mText;
  public UIButton Button;
  private int OriFontSize;
  public _CheckTextHandle TextHandle;
  private float oriTop;

  public float Top
  {
    set
    {
      if ((double) this.oriTop > 10000.0)
        this.oriTop = this.recttransform.anchoredPosition.y;
      this.recttransform.anchoredPosition = new Vector2(this.recttransform.anchoredPosition.x, this.oriTop + value);
    }
    get => this.recttransform.anchoredPosition.y;
  }

  public void Init(RectTransform TextRect, Font font)
  {
    this.gameobject = ((Component) TextRect).gameObject;
    this.LineRect = ((Transform) TextRect).GetChild(0).GetComponent<RectTransform>();
    this.mText = ((Component) TextRect).GetComponent<UIText>();
    this.mText.font = font;
    this.OriFontSize = this.mText.fontSize;
    this.Button = ((Transform) TextRect).GetChild(1).GetComponent<UIButton>();
    this.BtnRect = ((Transform) TextRect).GetChild(1).GetComponent<RectTransform>();
    this.Button.SoundIndex = byte.MaxValue;
    this.Str = StringManager.Instance.SpawnString(64);
    this.recttransform = TextRect;
    this.oriTop = 100001f;
    this.BtnRect.sizeDelta = new Vector2(185f, 38f);
    this.BtnRect.anchoredPosition = new Vector2(-50f, 15f);
  }

  public void SetText(string str)
  {
    this.mText.fontSize = this.OriFontSize;
    this.mText.text = str;
    this.mText.SetAllDirty();
    this.mText.cachedTextGenerator.Invalidate();
    this.mText.cachedTextGeneratorForLayout.Invalidate();
    float x = 0.0f;
    if (this.TextHandle != null)
    {
      this.Str.ClearString();
      this.Str.Append(str);
      x = this.TextHandle.TextLenCheck(this.mText, this.Str);
    }
    this.LineRect.sizeDelta = new Vector2(x, this.LineRect.sizeDelta.y);
    ((Component) this.BtnRect).gameObject.SetActive((double) x > 0.0);
    if (!GUIManager.Instance.IsArabic)
      return;
    this.LineRect.anchoredPosition = new Vector2(((Graphic) this.mText).rectTransform.sizeDelta.x - x, this.LineRect.anchoredPosition.y);
  }

  public void TextRefresh()
  {
    ((Behaviour) this.mText).enabled = false;
    ((Behaviour) this.mText).enabled = true;
  }

  public void OnClose() => StringManager.Instance.DeSpawnString(this.Str);
}
