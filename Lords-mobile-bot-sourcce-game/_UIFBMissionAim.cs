// Decompiled with JetBrains decompiler
// Type: _UIFBMissionAim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public struct _UIFBMissionAim
{
  private RectTransform rectTransform;
  private float _Top;
  private float _Height;
  private UIText ContText;
  private CString ContStr;
  private int oriFontSize;
  private ushort ID;
  private byte Index;

  public _UIFBMissionAim(Transform transform, Font Font)
  {
    this.rectTransform = transform as RectTransform;
    this.ContText = transform.GetChild(0).GetComponent<UIText>();
    this.ContText.font = Font;
    this.ContStr = StringManager.Instance.SpawnString(128);
    this._Top = this.rectTransform.anchoredPosition.y;
    this._Height = this.rectTransform.sizeDelta.y;
    this.oriFontSize = this.ContText.fontSize;
    this.ID = (ushort) 0;
    this.Index = (byte) 0;
  }

  public float Height
  {
    set => this._Height = value;
    get => this._Height;
  }

  public float Top
  {
    set
    {
      this._Top = value;
      this.rectTransform.anchoredPosition = new Vector2(this.rectTransform.anchoredPosition.x, this._Top);
    }
    get => this._Top;
  }

  public void UpdateData()
  {
  }

  public void TextRefresh()
  {
    ((Behaviour) this.ContText).enabled = false;
    ((Behaviour) this.ContText).enabled = true;
  }

  public void OnClose() => StringManager.Instance.DeSpawnString(this.ContStr);

  public void Set(ref FBMissionTbl Data, byte index)
  {
    if ((int) Data.ID == (int) this.ID && (int) index == (int) this.Index)
      return;
    this.ID = Data.ID;
    this.Index = index;
    this.ContText.fontSize = this.oriFontSize;
    DataManager.FBMissionDataManager.GetNarrative(this.ContStr, ref Data, this.Index, false);
    this.ContText.text = this.ContStr.ToString();
    this.ContText.SetAllDirty();
    this.ContText.cachedTextGenerator.Invalidate();
    this.ContText.cachedTextGeneratorForLayout.Invalidate();
    this.Height = this.ContStr.Length <= 0 ? 0.0f : this.ContText.preferredHeight;
    ((Graphic) this.ContText).rectTransform.sizeDelta = new Vector2(((Graphic) this.ContText).rectTransform.sizeDelta.x, this.Height);
    this.ContText.UpdateArabicPos();
    this.UpdateData();
  }
}
