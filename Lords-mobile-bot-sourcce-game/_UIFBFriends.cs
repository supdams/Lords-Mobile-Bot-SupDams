// Decompiled with JetBrains decompiler
// Type: _UIFBFriends
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public struct _UIFBFriends : _CheckTextHandle
{
  private UIText Title;
  private UIText TipText;
  private GameObject gameobject;
  private RectTransform recttransform;
  private _UIFBFriends._Friend[] Friends;

  public _UIFBFriends(
    Transform transform,
    Font font,
    IUIButtonClickHandler handle,
    Transform blockTrans)
  {
    this.recttransform = transform as RectTransform;
    this.gameobject = transform.gameObject;
    this.Title = ((Transform) this.recttransform).GetChild(1).GetComponent<UIText>();
    this.Title.font = font;
    this.Title.text = DataManager.Instance.mStringTable.GetStringByID(12159U);
    this.Friends = new _UIFBFriends._Friend[10];
    int index;
    for (index = 0; index < 10; ++index)
      this.Friends[index] = new _UIFBFriends._Friend(((Transform) this.recttransform).GetChild(2 + index), font, handle, blockTrans);
    this.TipText = ((Transform) this.recttransform).GetChild(index + 2).GetComponent<UIText>();
    this.TipText.font = font;
    this.TipText.text = DataManager.Instance.mStringTable.GetStringByID(12166U);
  }

  float _CheckTextHandle.TextLenCheck(UIText mText, CString Str)
  {
    int fontSize = mText.fontSize;
    float preferredWidth = mText.preferredWidth;
    float x = ((Graphic) mText).rectTransform.sizeDelta.x;
    if ((double) preferredWidth > (double) x)
    {
      for (int index = 1; index <= 2; ++index)
      {
        mText.fontSize = fontSize - index;
        ((Graphic) mText).SetLayoutDirty();
        mText.cachedTextGeneratorForLayout.Invalidate();
        preferredWidth = mText.preferredWidth;
        if ((double) preferredWidth <= (double) x)
          break;
      }
      if ((double) preferredWidth > (double) x)
      {
        for (; (double) preferredWidth > (double) x; preferredWidth = mText.preferredWidth)
        {
          Str.Substring(Str.ToString(), 0, Str.Length - 2);
          mText.text = Str.ToString();
          mText.SetAllDirty();
          mText.cachedTextGenerator.Invalidate();
          mText.cachedTextGeneratorForLayout.Invalidate();
        }
        Str.Append("...");
        mText.text = Str.ToString();
        mText.SetAllDirty();
        mText.cachedTextGenerator.Invalidate();
        mText.cachedTextGeneratorForLayout.Invalidate();
        preferredWidth = mText.preferredWidth;
        while ((double) preferredWidth > (double) x && mText.fontSize > 4)
        {
          --mText.fontSize;
          ((Graphic) mText).SetLayoutDirty();
          mText.cachedTextGeneratorForLayout.Invalidate();
          preferredWidth = mText.preferredWidth;
          if ((double) preferredWidth <= (double) x)
            break;
        }
      }
    }
    return preferredWidth;
  }

  public float Top
  {
    set
    {
      this.recttransform.anchoredPosition = new Vector2(this.recttransform.anchoredPosition.x, value);
      for (byte index = 0; index < (byte) 10; ++index)
        this.Friends[(int) index].NameText.Top = value;
    }
  }

  public float Width => this.recttransform.sizeDelta.x;

  public float Height
  {
    get => this.recttransform.sizeDelta.y;
    set => this.recttransform.sizeDelta = new Vector2(this.recttransform.sizeDelta.x, value);
  }

  public void Show(byte ID, byte count)
  {
    this.gameobject.SetActive(true);
    for (byte index = 0; index < (byte) 10; ++index)
    {
      if ((int) index < (int) count)
      {
        this.Friends[(int) index].TextHandle = (_CheckTextHandle) this;
        this.Friends[(int) index].Show(ID, index);
      }
      else
        this.Friends[(int) index].Hide();
    }
    this.Height = (float) (507.0 - (double) (4 - ((int) count / 3 + Mathf.Clamp((int) count % 3, 0, 1))) * 88.0);
  }

  public void Hide() => this.gameobject.SetActive(false);

  public void UpdateData()
  {
    if (!this.gameobject.activeSelf)
      return;
    for (byte index = 0; index < (byte) 10; ++index)
      this.Friends[(int) index].UpdateData();
  }

  public void UpdateTime()
  {
    if (!this.gameobject.activeSelf)
      return;
    for (byte index = 0; index < (byte) 10; ++index)
      this.Friends[(int) index].UpdateTime();
  }

  public void TextRefresh()
  {
    ((Behaviour) this.Title).enabled = false;
    ((Behaviour) this.Title).enabled = true;
    for (byte index = 0; index < (byte) 10; ++index)
      this.Friends[(int) index].TextRefresh();
  }

  public void Destroy()
  {
    for (byte index = 0; index < (byte) 10; ++index)
      this.Friends[(int) index].Destroy();
  }

  private struct _Friend
  {
    private GameObject gameobject;
    private UIText LinkNameText;
    private UIText TimeText;
    private CString NameStr;
    private CString LinkStr;
    private CString TimeStr;
    public _TextUnderLine NameText;
    private int OriLinkFontSize;
    public _CheckTextHandle TextHandle;
    private long BeiginTime;
    private uint RequireTime;
    private Transform IconTrans;
    private SocialFriend friend;
    private EmojiUnit Icon;
    private byte ID;
    private byte Index;
    private Vector2 TimeTextDefSize;

    public _Friend(
      Transform transform,
      Font font,
      IUIButtonClickHandler handle,
      Transform blockTrans)
    {
      this.gameobject = transform.gameObject;
      this.IconTrans = transform.GetChild(0);
      this.LinkNameText = transform.GetChild(1).GetComponent<UIText>();
      this.LinkNameText.font = font;
      this.OriLinkFontSize = this.LinkNameText.fontSize;
      this.NameStr = StringManager.Instance.SpawnString(64);
      this.LinkStr = StringManager.Instance.SpawnString(128);
      this.TimeStr = StringManager.Instance.SpawnString();
      this.NameText = new _TextUnderLine();
      this.NameText.Init(transform.GetChild(2).GetComponent<RectTransform>(), font);
      this.NameText.Button.m_Handler = handle;
      this.TextHandle = (_CheckTextHandle) null;
      this.TimeText = transform.GetChild(3).GetComponent<UIText>();
      this.TimeText.font = font;
      transform.GetChild(2).SetParent(blockTrans);
      this.BeiginTime = 0L;
      this.RequireTime = 0U;
      this.friend = (SocialFriend) null;
      this.Icon = (EmojiUnit) null;
      this.ID = this.Index = (byte) 0;
      this.TimeTextDefSize = ((Graphic) this.TimeText).rectTransform.sizeDelta;
      this.TimeText.AdjuestUI();
    }

    public void TextRefresh()
    {
      ((Behaviour) this.LinkNameText).enabled = false;
      ((Behaviour) this.LinkNameText).enabled = true;
      ((Behaviour) this.TimeText).enabled = false;
      ((Behaviour) this.TimeText).enabled = true;
      this.NameText.TextRefresh();
    }

    public void Show(byte id, byte index)
    {
      this.gameobject.SetActive(true);
      this.ID = id;
      this.Index = index;
      DataManager.FBMissionDataManager.GetFriendSocialInfo(this.ID, (int) this.Index, out this.friend);
      if (this.friend != null)
      {
        if (this.Icon != null)
          GUIManager.Instance.pushEmojiIcon(this.Icon);
        this.Icon = DataManager.FBMissionDataManager.GetFriendEmoji((ushort) this.friend.IconNo);
        if (this.Icon != null)
        {
          this.Icon.EmojiTransform.SetParent(this.IconTrans, false);
          float iconScale = this.GetIconScale(this.Icon);
          this.Icon.EmojiTransform.localPosition = Vector3.zero;
          this.Icon.EmojiTransform.localScale = new Vector3(iconScale, iconScale, iconScale);
        }
        this.NameText.gameobject.SetActive(true);
        GameConstants.FormatRoleName(this.NameStr, this.friend.Name, this.friend.AllianceTag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
        this.LinkNameText.fontSize = this.OriLinkFontSize;
        this.LinkNameText.text = this.friend.SocialName.ToString();
        this.LinkNameText.SetAllDirty();
        this.LinkNameText.cachedTextGenerator.Invalidate();
        this.LinkNameText.cachedTextGeneratorForLayout.Invalidate();
        if (this.TextHandle != null)
        {
          this.NameText.TextHandle = this.TextHandle;
          this.NameText.SetText(this.NameStr.ToString());
          this.NameText.Button.m_BtnID1 = (int) id;
          this.NameText.Button.m_BtnID2 = (int) index;
          this.LinkStr.ClearString();
          this.LinkStr.Append(this.friend.SocialName);
          double num = (double) this.TextHandle.TextLenCheck(this.LinkNameText, this.LinkStr);
        }
        this.BeiginTime = this.friend.MissionTime.BeginTime;
        this.RequireTime = this.friend.MissionTime.RequireTime;
        this.UpdateTime();
      }
      else
      {
        this.LinkNameText.text = string.Empty;
        this.NameText.SetText(string.Empty);
        this.TimeText.text = string.Empty;
      }
    }

    private float GetIconScale(EmojiUnit icon)
    {
      float iconScale = 0.0f;
      if (icon != null)
      {
        Rect rect = ((Graphic) icon.EmojiImage).rectTransform.rect;
        iconScale = 46f / ((double) rect.width >= (double) rect.height ? rect.width : rect.height);
      }
      return iconScale;
    }

    public void UpdateData()
    {
      if (!this.gameobject.activeSelf || this.friend == null || (int) DataManager.FBMissionDataManager.UpdateFriendSerialNo != (int) this.friend.UserSerialNo)
        return;
      this.Show(this.ID, this.Index);
    }

    public void UpdateTime()
    {
      if (!this.gameobject.activeSelf)
        return;
      long num1 = this.BeiginTime + (long) this.RequireTime - DataManager.Instance.ServerTime;
      long x = 0;
      byte num2 = 0;
      this.TimeStr.ClearString();
      if (this.BeiginTime == 0L)
      {
        this.TimeStr.Append(DataManager.Instance.mStringTable.GetStringByID(12192U));
        num2 = (byte) 1;
      }
      else if (num1 < 0L)
      {
        this.TimeStr.Append("00:00");
      }
      else
      {
        x = num1 / 86400L;
        if (num1 > 86400L)
        {
          this.TimeStr.IntToFormat(x);
          this.TimeStr.AppendFormat("{0}d");
        }
        else if (num1 > 3600L)
        {
          this.TimeStr.IntToFormat(num1 / 3600L);
          this.TimeStr.AppendFormat("{0}h");
        }
        else
        {
          this.TimeStr.IntToFormat(num1 / 60L, 2);
          this.TimeStr.IntToFormat(num1 % 60L, 2);
          this.TimeStr.AppendFormat("{0}:{1}");
        }
      }
      if (this.BeiginTime == 0L)
        ((Graphic) this.TimeText).color = Color.gray;
      else if (x < 3L)
        ((Graphic) this.TimeText).color = (Color) new Color32((byte) 239, (byte) 58, (byte) 84, byte.MaxValue);
      else
        ((Graphic) this.TimeText).color = Color.white;
      if (num2 == (byte) 1)
      {
        ((Graphic) this.TimeText).rectTransform.sizeDelta = new Vector2(this.TimeTextDefSize.x * 3f, this.TimeTextDefSize.y);
        if (GUIManager.Instance.IsArabic)
          this.TimeText.alignment = TextAnchor.MiddleRight;
        else
          this.TimeText.alignment = TextAnchor.MiddleLeft;
      }
      else
      {
        ((Graphic) this.TimeText).rectTransform.sizeDelta = this.TimeTextDefSize;
        this.TimeText.alignment = TextAnchor.MiddleCenter;
      }
      this.TimeText.UpdateArabicPos();
      this.TimeText.text = this.TimeStr.ToString();
      this.TimeText.SetAllDirty();
      this.TimeText.cachedTextGenerator.Invalidate();
    }

    public void Hide()
    {
      this.gameobject.SetActive(false);
      this.NameText.gameobject.SetActive(false);
    }

    public void Destroy()
    {
      this.NameText.OnClose();
      StringManager.Instance.DeSpawnString(this.LinkStr);
      StringManager.Instance.DeSpawnString(this.NameStr);
      StringManager.Instance.DeSpawnString(this.TimeStr);
      if (this.Icon == null)
        return;
      GUIManager.Instance.pushEmojiIcon(this.Icon);
    }
  }
}
