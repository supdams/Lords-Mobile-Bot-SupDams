// Decompiled with JetBrains decompiler
// Type: UnityEngine.UI.UIText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine.EventSystems;

#nullable disable
namespace UnityEngine.UI
{
  [AddComponentMenu("UI/UIText", 35)]
  public class UIText : Text
  {
    private bool _bEmoji;
    private UIEmoji m_Emoji;
    private byte bArabicStr;
    private eTextCheck CheckText;
    private CString tmpArabicStr;
    private Vector2 OriPosition;
    private string CheckStr = string.Empty;
    private string CheckColorStr = "color=#";

    public bool bEmoji
    {
      get => this._bEmoji;
      set
      {
        this._bEmoji = value;
        if (!this._bEmoji || this.m_Emoji != null)
          return;
        this.m_Emoji = new UIEmoji();
      }
    }

    public UIEmoji GetEmoji() => this.m_Emoji;

    protected virtual void Start() => this.AdjuestUI();

    protected virtual void UpdateGeometry()
    {
      if (!((Object) this.font != (Object) null))
        return;
      base.UpdateGeometry();
      if (!this.bEmoji || this.m_Emoji == null)
        return;
      this.m_Emoji.ShowEmojiImage();
    }

    protected virtual void OnFillVBO(List<UIVertex> vbo)
    {
      base.OnFillVBO(vbo);
      if (!GUIManager.Instance.IsArabic && this.bArabicStr != (byte) 1)
        return;
      if (this.CheckText == eTextCheck.Text_None)
        this.CheckText = !ArabicTransfer.Instance.IsArabicStr(this.m_Text) ? eTextCheck.Text_NonArabic : eTextCheck.Text_Arabic;
      if ((this.CheckText & eTextCheck.Text_Arabic) <= eTextCheck.Text_None)
        return;
      this.AdjuestArabicVBOHeight(vbo);
    }

    private void AdjuestArabicVBOHeight(List<UIVertex> vbo)
    {
      IList<UILineInfo> lines = this.cachedTextGenerator.lines;
      if (lines.Count <= 1)
        return;
      IList<UICharInfo> characters = this.cachedTextGenerator.characters;
      int index1 = lines.Count - 1;
      int index2 = 0;
      float num1 = 1f / this.pixelsPerUnit;
      for (; index1 > -1 && index2 < lines.Count; ++index2)
      {
        UILineInfo uiLineInfo = lines[index1];
        int startCharIdx1 = lines[index2].startCharIdx;
        int num2 = index2 < lines.Count - 1 ? lines[index2 + 1].startCharIdx : characters.Count;
        int startCharIdx2 = uiLineInfo.startCharIdx;
        int num3 = index1 < lines.Count - 1 ? lines[index1 + 1].startCharIdx : characters.Count;
        if (startCharIdx1 < this.m_Text.Length && this.m_Text[startCharIdx1] == '<')
        {
          if (startCharIdx1 + 14 < num2 && this.m_Text[startCharIdx1 + 14] == '>')
          {
            int index3 = 0;
            while (index3 < this.CheckColorStr.Length && (int) this.CheckColorStr[index3] == (int) this.m_Text[startCharIdx1 + index3 + 1])
              ++index3;
            if (index3 == this.CheckColorStr.Length && startCharIdx1 + 14 + 1 < num2)
              startCharIdx1 += 15;
          }
          else if (startCharIdx1 + 16 < num2 && this.m_Text[startCharIdx1 + 16] == '>')
          {
            int index4 = 0;
            while (index4 < this.CheckColorStr.Length && (int) this.CheckColorStr[index4] == (int) this.m_Text[startCharIdx1 + index4 + 1])
              ++index4;
            if (index4 == this.CheckColorStr.Length && startCharIdx1 + 16 + 1 < num2)
              startCharIdx1 += 17;
          }
        }
        if (startCharIdx2 < this.m_Text.Length && this.m_Text[startCharIdx2] == '<')
        {
          if (startCharIdx2 + 14 < num3 && this.m_Text[startCharIdx2 + 14] == '>')
          {
            int index5 = 0;
            while (index5 < this.CheckColorStr.Length && (int) this.CheckColorStr[index5] == (int) this.m_Text[startCharIdx2 + index5 + 1])
              ++index5;
            if (index5 == this.CheckColorStr.Length && startCharIdx2 + 14 + 1 < num3)
              startCharIdx2 += 15;
          }
          else if (startCharIdx2 + 16 < num3 && this.m_Text[startCharIdx2 + 16] == '>')
          {
            int index6 = 0;
            while (index6 < this.CheckColorStr.Length && (int) this.CheckColorStr[index6] == (int) this.m_Text[startCharIdx2 + index6 + 1])
              ++index6;
            if (index6 == this.CheckColorStr.Length && startCharIdx2 + 16 + 1 < num3)
              startCharIdx2 += 17;
          }
        }
        float num4 = (characters[startCharIdx1].cursorPos.y - characters[startCharIdx2].cursorPos.y) * num1;
        for (int index7 = index1 < lines.Count - 1 ? lines[index1 + 1].startCharIdx - 1 : (vbo.Count >> 2) - 1; index7 >= uiLineInfo.startCharIdx; --index7)
        {
          for (int index8 = 0; index8 < 4; ++index8)
          {
            UIVertex uiVertex = vbo[(index7 << 2) + index8];
            uiVertex.position += Vector3.up * num4;
            vbo[(index7 << 2) + index8] = uiVertex;
          }
        }
        --index1;
      }
    }

    public virtual string text
    {
      get => this.m_Text;
      set
      {
        bool isArabic = GUIManager.Instance.IsArabic;
        this.CheckText = eTextCheck.Text_None;
        if (string.IsNullOrEmpty(value))
        {
          if (string.IsNullOrEmpty(this.m_Text))
            return;
          this.m_Text = string.Empty;
          this.CheckStr = string.Empty;
          ((Graphic) this).SetVerticesDirty();
        }
        else
        {
          if (isArabic || this.bArabicStr == (byte) 1)
          {
            if (this.CheckStr != value)
            {
              this.InitArabicCString(value);
              this.m_Text = ArabicTransfer.Instance.Transfer(value, this.tmpArabicStr);
              this.CheckStr = value;
              ((Graphic) this).SetVerticesDirty();
              ((Graphic) this).SetLayoutDirty();
              this.cachedTextGenerator.Invalidate();
              this.cachedTextGeneratorForLayout.Invalidate();
              this.CheckText = ArabicTransfer.Instance.TextState;
            }
          }
          else if (this.m_Text != value)
          {
            this.m_Text = value;
            ((Graphic) this).SetVerticesDirty();
            ((Graphic) this).SetLayoutDirty();
          }
          if (!this.bEmoji || this.m_Emoji == null)
            return;
          this.m_Emoji.CheckEmojiText();
        }
      }
    }

    public void SetCheckArabic(bool check)
    {
      if (check)
        this.bArabicStr = (byte) 1;
      else
        this.bArabicStr = (byte) 0;
    }

    private void InitArabicCString(string str)
    {
      int length = str.Length;
      if (this.tmpArabicStr == null)
      {
        this.tmpArabicStr = StringManager.Instance.SpawnString(length);
      }
      else
      {
        if (this.tmpArabicStr.MaxLength >= length)
          return;
        StringManager.Instance.DeSpawnString(this.tmpArabicStr);
        this.tmpArabicStr = StringManager.Instance.SpawnString(length);
      }
    }

    public void AdjuestUI()
    {
      if (!GUIManager.Instance.IsArabic || (double) ((Component) this).transform.localScale.x < 0.0)
        return;
      this.OriPosition = ((Graphic) this).rectTransform.anchoredPosition;
      float x = ((Component) this).transform.localScale.x;
      ((Component) this).transform.localScale = new Vector3(((Component) this).transform.localScale.x * -1f, ((Component) this).transform.localScale.y, ((Component) this).transform.localScale.z);
      TextAnchor textAnchor = this.alignment;
      switch (textAnchor)
      {
        case TextAnchor.UpperLeft:
          textAnchor = TextAnchor.UpperRight;
          break;
        case TextAnchor.UpperRight:
          textAnchor = TextAnchor.UpperLeft;
          break;
        case TextAnchor.MiddleLeft:
          textAnchor = TextAnchor.MiddleRight;
          break;
        case TextAnchor.MiddleRight:
          textAnchor = TextAnchor.MiddleLeft;
          break;
        case TextAnchor.LowerLeft:
          textAnchor = TextAnchor.LowerRight;
          break;
        case TextAnchor.LowerRight:
          textAnchor = TextAnchor.LowerLeft;
          break;
      }
      this.alignment = textAnchor;
      Vector2 anchoredPosition = ((Graphic) this).rectTransform.anchoredPosition;
      float width = ((Graphic) this).rectTransform.rect.width;
      if ((double) ((Graphic) this).rectTransform.pivot.x == 0.5)
        return;
      if ((double) ((Graphic) this).rectTransform.anchorMax.x == 1.0 && (double) ((Graphic) this).rectTransform.anchorMin.x == 0.0)
      {
        float num = width * (float) (2.0 * (double) ((Graphic) this).rectTransform.pivot.x - 1.0) * x;
        ((Graphic) this).rectTransform.offsetMax = new Vector2(((Graphic) this).rectTransform.offsetMax.x - num, ((Graphic) this).rectTransform.offsetMax.y);
        ((Graphic) this).rectTransform.offsetMin = new Vector2(((Graphic) this).rectTransform.offsetMin.x - num, ((Graphic) this).rectTransform.offsetMin.y);
      }
      else
      {
        anchoredPosition.x = (anchoredPosition.x - 2f * ((Graphic) this).rectTransform.pivot.x * width + width) * x;
        ((Graphic) this).rectTransform.anchoredPosition = anchoredPosition;
      }
    }

    public Vector2 ArabicFixPos(Vector2 pos)
    {
      if (!GUIManager.Instance.IsArabic || (double) ((Transform) ((Graphic) this).rectTransform).localScale.x >= 0.0)
        return pos;
      float num = ((Transform) ((Graphic) this).rectTransform).localScale.x * -1f;
      float width = ((Graphic) this).rectTransform.rect.width;
      pos.x = (pos.x - 2f * ((Graphic) this).rectTransform.pivot.x * width + width) * num;
      return pos;
    }

    public void UpdateArabicPos()
    {
      if ((double) ((Transform) ((Graphic) this).rectTransform).localScale.x >= 0.0)
        return;
      ((Graphic) this).rectTransform.anchoredPosition = this.ArabicFixPos(this.OriPosition);
    }

    public virtual void SetAllDirty()
    {
      if (this.tmpArabicStr != null && (GUIManager.Instance.IsArabic || this.bArabicStr == (byte) 1))
      {
        this.InitArabicCString(this.CheckStr);
        this.m_Text = ArabicTransfer.Instance.Transfer(this.CheckStr, this.tmpArabicStr);
        this.CheckText = ArabicTransfer.Instance.TextState;
      }
      ((Graphic) this).SetAllDirty();
    }

    public void SetText(string str, eTextCheck check = eTextCheck.Text_None)
    {
      if (str == null)
        return;
      if (check == eTextCheck.Text_None || (check & eTextCheck.Text_Arabic) > eTextCheck.Text_None)
        this.text = str;
      else if (GUIManager.Instance.IsArabic || this.bArabicStr == (byte) 1)
      {
        if (!(this.CheckStr != str))
          return;
        this.m_Text = str;
        this.CheckStr = str;
        this.CheckText = check;
        ((Graphic) this).SetVerticesDirty();
        ((Graphic) this).SetLayoutDirty();
      }
      else
      {
        if (!(this.m_Text != str))
          return;
        this.m_Text = str;
        this.CheckText = check;
        ((Graphic) this).SetVerticesDirty();
        ((Graphic) this).SetLayoutDirty();
      }
    }

    public eTextCheck GetTextState()
    {
      if (this.bArabicStr == (byte) 1 && this.CheckText == eTextCheck.Text_None)
        this.SetAllDirty();
      return this.CheckText;
    }

    protected virtual void OnDestroy()
    {
      if (this.tmpArabicStr != null)
        StringManager.Instance.DeSpawnString(this.tmpArabicStr);
      ((UIBehaviour) this).OnDestroy();
    }
  }
}
