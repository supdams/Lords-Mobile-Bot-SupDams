// Decompiled with JetBrains decompiler
// Type: UIEmoji
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIEmoji
{
  public string mString = string.Empty;
  public string mString2 = string.Empty;
  private List<UIEmoji.PosStringTuple> emojiReplacements = new List<UIEmoji.PosStringTuple>();
  private static char emSpace = ' ';
  private float TextWidth;
  public float TextWidthMax;
  public bool bOneLine;
  private StringBuilder tmpSb = new StringBuilder();
  private Transform mEmojiT;
  private byte tmpType;
  private int bHasCut = -1;
  public UIText m_UIText;
  private string m_Text;

  public void InitSetting(bool mbOneLine, float mTextWidthMax)
  {
    this.bOneLine = mbOneLine;
    this.TextWidthMax = mTextWidthMax;
  }

  public int GetEmojiCount() => this.emojiReplacements.Count;

  private int GetSurrogateMaxSize(string str, int beginID)
  {
    int surrogateMaxSize = 0;
    for (; surrogateMaxSize < 4; ++surrogateMaxSize)
    {
      int index = beginID + surrogateMaxSize;
      if (index >= str.Length || !char.IsSurrogate(str[index]))
        break;
    }
    return surrogateMaxSize;
  }

  public void CheckEmojiText()
  {
    this.mString = this.m_Text;
    DataManager instance1 = DataManager.Instance;
    this.emojiReplacements.Clear();
    int num1 = 0;
    GUIManager instance2 = GUIManager.Instance;
    this.tmpType = (byte) 0;
    this.bHasCut = -1;
    this.TextWidth = 0.0f;
    this.tmpSb.Length = 0;
    instance2.MsgStr.ClearString();
    while (num1 < this.mString.Length)
    {
      if (this.mString[num1] == char.MinValue || this.bOneLine && this.mString[num1] == '\n')
      {
        int num2 = num1 + this.mString.Length;
        break;
      }
      int num3 = this.GetSurrogateMaxSize(this.mString, num1);
      bool flag1;
      bool flag2;
      if (num3 == 4)
      {
        flag1 = char.IsSurrogatePair(this.mString[num1], this.mString[num1 + 1]);
        flag2 = char.IsSurrogatePair(this.mString[num1 + 2], this.mString[num1 + 3]);
      }
      else if (num3 >= 2)
      {
        flag1 = char.IsSurrogatePair(this.mString[num1], this.mString[num1 + 1]);
        flag2 = false;
      }
      else
        flag1 = flag2 = false;
      if (flag1 && flag2)
      {
        string s = Convert.ToString(char.ConvertToUtf32(this.mString[num1], this.mString[num1 + 1]), 16) + "-" + Convert.ToString(char.ConvertToUtf32(this.mString[num1 + 2], this.mString[num1 + 3]), 16);
        if (instance2.m_EmojiSpriteAsset.m_Dict.ContainsKey(s.GetHashCode()))
        {
          this.tmpSb.Append(UIEmoji.emSpace);
          this.emojiReplacements.Add(new UIEmoji.PosStringTuple(this.tmpSb.Length - 1, s));
          num1 += 4;
          continue;
        }
      }
      if (flag1)
      {
        string s = Convert.ToString(char.ConvertToUtf32(this.mString, num1), 16);
        if (instance2.m_EmojiSpriteAsset.m_Dict.ContainsKey(s.GetHashCode()))
        {
          this.tmpSb.Append(UIEmoji.emSpace);
          this.emojiReplacements.Add(new UIEmoji.PosStringTuple(this.tmpSb.Length - 1, s));
          num1 += 2;
          continue;
        }
        num3 = 1;
      }
      if (num3 == 1)
      {
        int num4 = (int) this.mString[num1] - 55296;
        if (num4 < 0 || num4 > 2047)
        {
          string s = Convert.ToString((int) this.mString[num1], 16);
          this.tmpSb.Append(UIEmoji.emSpace);
          this.emojiReplacements.Add(new UIEmoji.PosStringTuple(this.tmpSb.Length - 1, s));
          ++num1;
          continue;
        }
      }
      if (this.mString[num1] == '<' && (this.mString[num1 + 1] == 'c' || this.mString[num1 + 1] == '/'))
      {
        if (this.mString[num1 + 1] == 'c')
          this.tmpType = (byte) 1;
        else if (this.tmpType == (byte) 1)
          this.tmpType = (byte) 0;
        this.tmpSb.Append(this.mString[num1]);
        this.tmpSb.Append(this.mString[num1 + 1]);
        int num5;
        for (num5 = 2; this.mString[num1 + num5] != '>' && num1 + num5 < this.mString.Length; ++num5)
          this.tmpSb.Append(this.mString[num1 + num5]);
        num1 += num5;
      }
      else
      {
        if (!instance1.isNotEmojiCharacter(this.mString[num1]))
          this.tmpSb.Append(" ");
        else
          this.tmpSb.Append(this.mString[num1]);
        ++num1;
        if (this.bHasCut != -1 && this.tmpType == (byte) 1)
          this.tmpSb.Append("</color>");
      }
    }
    this.m_Text = this.tmpSb.ToString();
    if (this.bOneLine)
      this.CheckTextWidth();
    this.m_UIText.SetAllDirty();
    this.m_UIText.cachedTextGenerator.Invalidate();
    Vector2 vector2_1 = new Vector2(0.0f, 0.0f);
    Vector2 vector2_2 = new Vector2(1f, 1f);
    Quaternion quaternion = new Quaternion();
    if ((UnityEngine.Object) this.mEmojiT == (UnityEngine.Object) null)
    {
      GameObject gameObject = new GameObject("Emoji");
      gameObject.layer = 5;
      RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
      this.mEmojiT = gameObject.transform;
      gameObject.transform.SetParent(((Component) this.m_UIText).transform, false);
      rectTransform.sizeDelta = new Vector2(this.TextWidthMax, 30f);
      rectTransform.anchorMin = new Vector2(0.0f, 1f);
      rectTransform.anchorMax = new Vector2(0.0f, 1f);
      rectTransform.pivot = new Vector2(0.0f, 1f);
    }
    else if (this.mEmojiT.childCount != 0)
    {
      for (int index = 0; index < this.mEmojiT.childCount; ++index)
        ((Behaviour) this.mEmojiT.GetChild(index).GetComponent<Image>()).enabled = false;
    }
    for (int index = 0; index < this.emojiReplacements.Count; ++index)
    {
      int pos = this.emojiReplacements[index].pos;
      if (this.mEmojiT.childCount <= index)
      {
        GameObject gameObject = new GameObject("Img");
        gameObject.layer = 5;
        gameObject.transform.SetParent(this.mEmojiT);
        RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0.0f, 1f);
        rectTransform.anchorMax = new Vector2(0.0f, 1f);
        rectTransform.pivot = new Vector2(0.0f, 1f);
        rectTransform.sizeDelta = new Vector2(36f, 36f);
        Image image = gameObject.AddComponent<Image>();
        image.sprite = instance2.LoadEmojiSprite(this.emojiReplacements[index].emoji);
        ((MaskableGraphic) image).material = instance2.GetEmojiMaterial();
        quaternion.eulerAngles = Vector3.zero;
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localRotation = quaternion;
      }
      else
      {
        Image component = this.mEmojiT.GetChild(index).GetComponent<Image>();
        component.sprite = instance2.LoadEmojiSprite(this.emojiReplacements[index].emoji);
        ((Behaviour) component).enabled = true;
      }
    }
  }

  public void CheckTextWidth()
  {
    this.m_UIText.font.RequestCharactersInTexture(this.m_Text, this.m_UIText.fontSize);
    CharacterInfo info = new CharacterInfo();
    this.mString = this.m_Text;
    int index1 = 0;
    int num1 = 0;
    int length = this.tmpSb.Length;
    this.tmpSb.Length = 0;
    while (index1 < this.mString.Length)
    {
      if (this.mString[index1] == '<' && (this.mString[index1 + 1] == 'c' || this.mString[index1 + 1] == '/'))
      {
        if (this.mString[index1 + 1] == 'c')
          this.tmpType = (byte) 1;
        else if (this.tmpType == (byte) 1)
          this.tmpType = (byte) 0;
        this.tmpSb.Append(this.mString[index1]);
        this.tmpSb.Append(this.mString[index1 + 1]);
        int num2;
        for (num2 = 2; this.mString[index1 + num2] != '>' && index1 + num2 < this.mString.Length; ++num2)
          this.tmpSb.Append(this.mString[index1 + num2]);
        if (index1 + num2 < this.mString.Length)
        {
          this.tmpSb.Append(this.mString[index1 + num2]);
          ++num2;
        }
        index1 += num2;
      }
      else
      {
        if (this.m_UIText.font.GetCharacterInfo(this.mString[index1], out info, this.m_UIText.fontSize))
        {
          if ((double) this.TextWidth + (double) info.width < (double) this.TextWidthMax)
          {
            if ((int) this.mString[index1] == (int) UIEmoji.emSpace)
              ++num1;
            this.tmpSb.Append(this.mString[index1]);
            this.TextWidth += info.width;
            ++index1;
          }
          else
          {
            this.bHasCut = index1;
            this.tmpSb.Append("...");
            index1 += this.mString.Length;
          }
        }
        else
        {
          this.tmpSb.Append(this.mString[index1]);
          this.TextWidth += (float) this.m_UIText.fontSize;
          ++index1;
        }
        if (this.bHasCut != -1)
        {
          if (this.tmpType == (byte) 1)
            this.tmpSb.Append("</color>");
          else if (this.tmpType == (byte) 2)
            this.tmpSb.Append(">");
        }
      }
    }
    this.m_Text = this.tmpSb.ToString();
    if (this.emojiReplacements.Count == 0)
      return;
    for (int index2 = this.emojiReplacements.Count - 1; index2 >= num1; --index2)
      this.emojiReplacements.RemoveAt(index2);
  }

  public void ShowEmojiImage()
  {
    this.m_UIText.font.RequestCharactersInTexture(this.m_Text, this.m_UIText.fontSize);
    CharacterInfo info = new CharacterInfo();
    GUIManager instance = GUIManager.Instance;
    TextGenerator cachedTextGenerator = this.m_UIText.cachedTextGenerator;
    Vector3 vector3 = new Vector3();
    Quaternion quaternion = new Quaternion();
    float num1 = 0.0f;
    this.mString = this.m_Text;
    TextGenerationSettings generationSettings = this.m_UIText.GetGenerationSettings(Vector2.zero);
    float num2 = 36f;
    if (this.m_UIText.font.GetCharacterInfo(UIEmoji.emSpace, out info, this.m_UIText.fontSize))
      num2 = info.width / 36f;
    for (int index1 = 0; index1 < this.emojiReplacements.Count; ++index1)
    {
      int pos = this.emojiReplacements[index1].pos;
      num1 = 0.0f;
      float y = 0.0f;
      int startIndex = 0;
      Image component = this.mEmojiT.GetChild(index1).GetComponent<Image>();
      component.sprite = instance.LoadEmojiSprite(this.emojiReplacements[index1].emoji);
      if (pos >= cachedTextGenerator.characterCount)
      {
        vector3 = Vector3.zero;
      }
      else
      {
        if (!this.bOneLine)
        {
          for (int index2 = cachedTextGenerator.lines.Count - 1; index2 > 0; --index2)
          {
            if (pos > cachedTextGenerator.lines[index2].startCharIdx)
            {
              startIndex = cachedTextGenerator.lines[index2].startCharIdx;
              break;
            }
          }
        }
        this.mString = this.m_Text.Substring(startIndex, pos - startIndex);
        float x = this.m_UIText.cachedTextGeneratorForLayout.GetPreferredWidth(this.mString, generationSettings) / this.m_UIText.pixelsPerUnit;
        if (!this.bOneLine)
        {
          for (int index3 = 0; index3 < cachedTextGenerator.lines.Count; ++index3)
          {
            if (pos == cachedTextGenerator.lines[index3].startCharIdx)
            {
              x = 0.0f;
              break;
            }
          }
          y = cachedTextGenerator.characters[pos].cursorPos.y - cachedTextGenerator.characters[0].cursorPos.y;
        }
        vector3 = new Vector3(x, y, 0.0f);
      }
      ((Component) component).transform.localPosition = vector3;
      quaternion.eulerAngles = Vector3.zero;
      ((Component) component).transform.localRotation = quaternion;
      ((Component) component).transform.localScale = new Vector3(num2, num2, num2);
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
  }

  private struct PosStringTuple
  {
    public int pos;
    public string emoji;

    public PosStringTuple(int p, string s)
    {
      this.pos = p;
      this.emoji = s;
    }
  }
}
