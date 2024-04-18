// Decompiled with JetBrains decompiler
// Type: UITimeBar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UITimeBar : MonoBehaviour, IUIButtonClickHandler
{
  public float TimeBarSizeX = 300f;
  public float TimeBarSizeY = 40f;
  private long m_TargetValue;
  private long m_BeginValue;
  private string m_Title = "Upgrading";
  public string[] m_Titles = new string[2]
  {
    string.Empty,
    string.Empty
  };
  private int m_TextIdx;
  private float m_TickTime = 1f;
  private string tempString = new string(char.MinValue, 15);
  private char[] numChar = new char[11]
  {
    '0',
    '1',
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9',
    'd'
  };
  private int tempStringCount;
  private float m_BeginChangeTime = 3f;
  private float m_ChangeTime;
  private float m_FlashCount;
  public Image m_FlashImage;
  public IUTimeBarOnTimer m_Handler;
  public int m_TimeBarID;
  public int m_ListID;
  public RectTransform m_SliderRectTransform;
  public Image m_BackgroundImage;
  public Image m_SliderImage;
  public UIText m_TitleText;
  public UIText m_TimeText;
  public int m_Tag;
  public long m_NotifyTime;
  public UIButton m_CancelBtn;
  public UIButton m_FuntionBtn;
  public float valueSize;
  public eTimeBarType m_Type;
  public eTimerSpriteType m_TimerSpriteType;
  private CanvasGroup m_CanvasGroup;

  public void InitTimeBar()
  {
    this.m_TimerSpriteType = eTimerSpriteType.Speed;
    this.m_Type = eTimeBarType.NormalType;
    if ((UnityEngine.Object) this.m_CancelBtn != (UnityEngine.Object) null)
    {
      this.m_CancelBtn.m_BtnID1 = 1;
      this.m_CancelBtn.m_Handler = (IUIButtonClickHandler) this;
    }
    if ((UnityEngine.Object) this.m_FuntionBtn != (UnityEngine.Object) null)
    {
      this.m_FuntionBtn.m_BtnID1 = 2;
      this.m_FuntionBtn.m_Handler = (IUIButtonClickHandler) this;
    }
    if (!(bool) (UnityEngine.Object) this.m_TitleText || !((UnityEngine.Object) this.m_CanvasGroup == (UnityEngine.Object) null))
      return;
    this.m_CanvasGroup = ((Component) this.m_TitleText).gameObject.AddComponent<CanvasGroup>();
  }

  public unsafe void SetChar(string s, int index, char ch)
  {
    if (index < 0 || index >= s.Length)
      return;
    string str = s;
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    chPtr[index] = ch;
    str = (string) null;
  }

  public void SetValue(long begin, long target)
  {
    this.SetTargetTime(target);
    this.SetBeginTime(begin);
  }

  private void SetTargetTime(long target) => this.m_TargetValue = target;

  private void SetBeginTime(long begin) => this.m_BeginValue = begin;

  public void SetFunctionBtn()
  {
    if ((UnityEngine.Object) this.m_CancelBtn != (UnityEngine.Object) null)
      this.m_CancelBtn.m_BtnID1 = 1;
    if (!((UnityEngine.Object) this.m_FuntionBtn != (UnityEngine.Object) null))
      return;
    this.m_FuntionBtn.m_BtnID1 = 2;
  }

  public void SetTime(int dd, int hh, int mm, int ss)
  {
    if ((UnityEngine.Object) this.m_TimeText != (UnityEngine.Object) null && dd >= 0 && hh >= 0 && mm >= 0 && ss >= 0)
    {
      this.tempStringCount = 0;
      if (dd > 0)
      {
        if (dd < 10)
          this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd]);
        else if (dd < 100)
        {
          this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd / 10]);
          this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd % 10]);
        }
        else if (dd < 1000)
        {
          this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd / 100]);
          this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd % 100 / 10]);
          this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd % 10]);
        }
        else if (dd < 10000)
        {
          this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd / 1000]);
          this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd / 100 % 10]);
          this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd / 10 % 10]);
          this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd % 10]);
        }
        this.SetChar(this.tempString, this.tempStringCount++, this.numChar[10]);
        if (this.m_Type == eTimeBarType.SpeedupType)
        {
          if (dd > 0)
          {
            this.SetChar(this.tempString, this.tempStringCount++, ' ');
            if (hh > 0)
              this.SetChar(this.tempString, this.tempStringCount++, this.numChar[hh / 10]);
          }
          if (hh > 0)
          {
            if (dd <= 0)
              this.SetChar(this.tempString, this.tempStringCount++, this.numChar[hh / 10]);
            this.SetChar(this.tempString, this.tempStringCount++, this.numChar[hh % 10]);
            this.SetChar(this.tempString, this.tempStringCount++, ':');
          }
          if (hh > 0 || mm >= 10)
            this.SetChar(this.tempString, this.tempStringCount++, this.numChar[mm / 10]);
          this.SetChar(this.tempString, this.tempStringCount++, this.numChar[mm % 10]);
          this.SetChar(this.tempString, this.tempStringCount++, ':');
          this.SetChar(this.tempString, this.tempStringCount++, this.numChar[ss / 10]);
          this.SetChar(this.tempString, this.tempStringCount++, this.numChar[ss % 10]);
        }
      }
      else
      {
        if (hh > 0)
        {
          if (hh >= 10)
            this.SetChar(this.tempString, this.tempStringCount++, this.numChar[hh / 10]);
          this.SetChar(this.tempString, this.tempStringCount++, this.numChar[hh % 10]);
          this.SetChar(this.tempString, this.tempStringCount++, ':');
        }
        this.SetChar(this.tempString, this.tempStringCount++, this.numChar[mm / 10]);
        this.SetChar(this.tempString, this.tempStringCount++, this.numChar[mm % 10]);
        this.SetChar(this.tempString, this.tempStringCount++, ':');
        this.SetChar(this.tempString, this.tempStringCount++, this.numChar[ss / 10]);
        this.SetChar(this.tempString, this.tempStringCount++, this.numChar[ss % 10]);
      }
      this.SetChar(this.tempString, this.tempStringCount++, char.MinValue);
    }
    this.m_TimeText.text = this.tempString;
    if (this.m_Type == eTimeBarType.IconType && this.m_TimerSpriteType != eTimerSpriteType.Idle)
    {
      float num = 0.0f;
      int length = this.tempString.Length;
      CharacterInfo info = new CharacterInfo();
      GUIManager.Instance.GetTTFFont().RequestCharactersInTexture(this.tempString, 18);
      for (int index = 0; index < this.tempStringCount && this.tempStringCount < length; ++index)
      {
        if (GUIManager.Instance.GetTTFFont().GetCharacterInfo(this.tempString[index], out info, 18))
          num += info.width;
        else
          num += 16f;
      }
      ((Graphic) this.m_TimeText).rectTransform.sizeDelta = ((Graphic) this.m_TimeText).rectTransform.sizeDelta with
      {
        x = num
      };
      Vector2 sizeDelta = ((RectTransform) this.transform).sizeDelta;
      sizeDelta.x = (float) ((double) sizeDelta.x - 40.0 - 20.0) - num;
      ((Graphic) this.m_TitleText).rectTransform.sizeDelta = sizeDelta;
      this.m_TitleText.SetAllDirty();
      this.m_TitleText.cachedTextGeneratorForLayout.Invalidate();
      this.m_TitleText.cachedTextGenerator.Invalidate();
    }
    if (this.m_Type == eTimeBarType.CancelType)
    {
      float preferredWidth = this.m_TimeText.preferredWidth;
      ((Graphic) this.m_TimeText).rectTransform.sizeDelta = ((Graphic) this.m_TimeText).rectTransform.sizeDelta with
      {
        x = preferredWidth
      };
      ((Graphic) this.m_TitleText).rectTransform.sizeDelta = ((RectTransform) this.transform).sizeDelta with
      {
        x = 200f - preferredWidth
      };
      this.m_TitleText.SetAllDirty();
      this.m_TitleText.cachedTextGeneratorForLayout.Invalidate();
      this.m_TitleText.cachedTextGenerator.Invalidate();
    }
    if (this.m_Type == eTimeBarType.NormalType)
    {
      float preferredWidth = this.m_TimeText.preferredWidth;
      ((Graphic) this.m_TimeText).rectTransform.sizeDelta = ((Graphic) this.m_TimeText).rectTransform.sizeDelta with
      {
        x = preferredWidth
      };
      ((Graphic) this.m_TitleText).rectTransform.sizeDelta = ((RectTransform) this.transform).sizeDelta with
      {
        x = 240f - preferredWidth
      };
      this.m_TitleText.SetAllDirty();
      this.m_TitleText.cachedTextGeneratorForLayout.Invalidate();
      this.m_TitleText.cachedTextGenerator.Invalidate();
    }
    if ((UnityEngine.Object) this.m_TitleText != (UnityEngine.Object) null)
      this.m_TitleText.UpdateArabicPos();
    if ((UnityEngine.Object) this.m_TimeText != (UnityEngine.Object) null)
      this.m_TimeText.UpdateArabicPos();
    this.m_TimeText.SetAllDirty();
    this.m_TimeText.cachedTextGeneratorForLayout.Invalidate();
    this.m_TimeText.cachedTextGenerator.Invalidate();
  }

  public bool UpdateTime(double nowTime)
  {
    if (this.m_NotifyTime != 0L && DataManager.Instance.ServerTime >= this.m_NotifyTime)
    {
      this.m_NotifyTime = 0L;
      if (this.m_Handler != null)
        this.m_Handler.OnNotify(this);
    }
    if (this.m_TargetValue == 0L)
    {
      if (this.m_Type == eTimeBarType.IconType)
        this.m_SliderImage.fillAmount = 0.0f;
      else
        this.m_SliderRectTransform.sizeDelta = new Vector2(0.0f, this.TimeBarSizeY);
    }
    else
    {
      this.valueSize = (nowTime - (double) this.m_BeginValue <= (double) (this.m_TargetValue - this.m_BeginValue) ? (nowTime - (double) this.m_BeginValue >= 0.0 ? (float) nowTime - (float) this.m_BeginValue : 0.0f) : (float) (this.m_TargetValue - this.m_BeginValue)) / (float) (this.m_TargetValue - this.m_BeginValue);
      if (this.m_Type == eTimeBarType.IconType)
      {
        if ((UnityEngine.Object) this.m_SliderRectTransform != (UnityEngine.Object) null)
        {
          this.m_SliderRectTransform.sizeDelta = new Vector2(this.TimeBarSizeX, this.TimeBarSizeY);
          if ((UnityEngine.Object) this.m_SliderImage != (UnityEngine.Object) null)
            this.m_SliderImage.fillAmount = this.valueSize;
        }
      }
      else if ((UnityEngine.Object) this.m_SliderRectTransform != (UnityEngine.Object) null)
        this.m_SliderRectTransform.sizeDelta = new Vector2(this.valueSize * this.TimeBarSizeX, this.TimeBarSizeY);
    }
    if (((double) this.m_TargetValue - nowTime <= (double) (this.m_TargetValue - this.m_BeginValue) ? ((double) this.m_TargetValue - nowTime >= 0.0 ? (double) this.m_TargetValue - nowTime : 0.0) : (double) (this.m_TargetValue - this.m_BeginValue)) < 0.0 || nowTime <= (double) this.m_BeginValue || nowTime < (double) this.m_TargetValue)
      return false;
    if (this.m_Handler != null)
      this.m_Handler.OnTimer(this);
    this.SetTime(0, 0, 0, 0);
    return true;
  }

  public void UpdateTimeText(long nowTime)
  {
    double num = this.m_TargetValue - nowTime <= this.m_TargetValue - this.m_BeginValue ? (this.m_TargetValue - nowTime >= 0L ? (double) (this.m_TargetValue - nowTime) : 0.0) : (double) (this.m_TargetValue - this.m_BeginValue);
    if (num < 0.0)
      return;
    int ss = (int) num % 60;
    int mm = (int) (num / 60.0) % 60;
    int hh = (int) (num % 86400.0) / 3600;
    this.SetTime((int) num / 86400, hh, mm, ss);
  }

  private void Update()
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    switch (sender.m_BtnID1)
    {
      case 1:
        if (this.m_Handler == null)
          break;
        this.m_Handler.OnCancel(this);
        break;
      case 2:
        if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || this.m_Handler == null)
          break;
        this.m_Handler.Onfunc(this);
        break;
    }
  }

  public int GetTextIndex() => this.m_TextIdx;

  public void SetFlashCount(float count, int TextIdx)
  {
  }

  public void ResetTickTime()
  {
  }

  public void SetTitleText()
  {
    int textIdx = GUIManager.Instance.m_TextIdx;
    if (textIdx < 0 || textIdx >= this.m_Titles.Length)
      return;
    this.m_Title = this.m_Titles[textIdx];
    this.m_TitleText.text = this.m_Title;
    this.m_TitleText.SetAllDirty();
    this.m_TitleText.cachedTextGenerator.Invalidate();
  }

  public void SetTitleTextColor()
  {
    if (!((UnityEngine.Object) this.m_CanvasGroup != (UnityEngine.Object) null))
      return;
    this.m_CanvasGroup.alpha = GUIManager.Instance.m_FlashCount;
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.m_TitleText != (UnityEngine.Object) null && ((Behaviour) this.m_TitleText).enabled)
    {
      ((Behaviour) this.m_TitleText).enabled = false;
      ((Behaviour) this.m_TitleText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_TimeText != (UnityEngine.Object) null && ((Behaviour) this.m_TimeText).enabled)
    {
      ((Behaviour) this.m_TimeText).enabled = false;
      ((Behaviour) this.m_TimeText).enabled = true;
    }
    if (!((UnityEngine.Object) this.m_FuntionBtn != (UnityEngine.Object) null) || ((Component) this.m_FuntionBtn).transform.childCount <= 0)
      return;
    UIText component = ((Component) this.m_FuntionBtn).transform.GetChild(0).GetComponent<UIText>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null) || !((Behaviour) component).enabled)
      return;
    ((Behaviour) component).enabled = false;
    ((Behaviour) component).enabled = true;
  }
}
