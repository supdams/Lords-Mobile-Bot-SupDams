// Decompiled with JetBrains decompiler
// Type: ChatChannel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ChatChannel
{
  public RectTransform MainRC;
  public UIButton m_Button;
  public UIText[] m_ChatText = new UIText[2];
  public RectTransform[] m_ChatTextRC = new RectTransform[2];
  public RectTransform[] m_ChatEmojiRC = new RectTransform[2];
  public EmojiUnit[] EUnit = new EmojiUnit[2];
}
