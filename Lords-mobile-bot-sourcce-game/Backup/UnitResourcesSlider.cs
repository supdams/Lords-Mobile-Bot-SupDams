// Decompiled with JetBrains decompiler
// Type: UnitResourcesSlider
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#nullable disable
public class UnitResourcesSlider : MonoBehaviour, IUISliderBehavior
{
  public UIButton BtnIncrease;
  public UIButton BtnLessen;
  public UIButton BtnInputText;
  public CSlider m_slider;
  public InputField m_inputfield;
  public UIText m_inputText;
  public UIText m_TotalText;
  public bool bBtnDown;
  public bool bBtnIncrease;
  public float tmpTime;
  public float tmpTime2;
  public float tmpTime3 = 0.1f;
  public long Value;
  public long MaxValue;
  public uint Speed = 3;
  public byte Type;
  public long Input = -1;
  public IUIUnitRSliderHandler m_Handler;
  public int m_ID;
  public bool bRefrash = true;
  public bool bNumber = true;
  public long BigMaxValue;
  private long MinValue;
  private long mAddValueTotal = 2;
  private long mAddValueCount;

  public void SetMinValue(long mValue) => this.MinValue = mValue;

  private void Start()
  {
    if (!((Object) this.m_slider != (Object) null))
      return;
    // ISSUE: method pointer
    this.m_slider.onValueChanged.AddListener(new UnityAction<double>((object) this, __methodptr(\u003CStart\u003Em__F9)));
    this.m_slider.wholeNumbers = this.bNumber;
  }

  public void OnButtonDown(UIButton sender)
  {
    if ((Object) sender == (Object) this.BtnIncrease && !this.bBtnDown)
    {
      this.bBtnDown = true;
      this.bBtnIncrease = true;
    }
    else
    {
      if (!((Object) sender == (Object) this.BtnLessen) || this.bBtnDown)
        return;
      this.bBtnDown = true;
      this.bBtnIncrease = false;
    }
  }

  public void OnButtonUp(UIButton sender)
  {
    if ((Object) sender == (Object) this.BtnIncrease && this.bBtnIncrease && this.bBtnDown)
    {
      if ((double) this.tmpTime < 0.5 && this.Value < this.MaxValue)
      {
        this.bRefrash = false;
        ++this.Value;
        this.m_slider.value = (double) this.Value;
      }
      this.tmpTime = 0.0f;
      this.tmpTime2 = 0.0f;
      this.tmpTime3 = 0.1f;
      this.bBtnDown = false;
      this.mAddValueTotal = 2L;
      this.mAddValueCount = 0L;
    }
    else
    {
      if (!((Object) sender == (Object) this.BtnLessen) || this.bBtnIncrease || !this.bBtnDown)
        return;
      if ((double) this.tmpTime < 0.5 && this.Value <= this.MaxValue && this.Value > this.MinValue)
      {
        this.bRefrash = false;
        --this.Value;
        this.m_slider.value = (double) this.Value;
      }
      this.bBtnDown = false;
      this.tmpTime = 0.0f;
      this.tmpTime2 = 0.0f;
      this.tmpTime3 = 0.1f;
      this.mAddValueTotal = 2L;
      this.mAddValueCount = 0L;
    }
  }

  private void InputFieldChange(string tmpStr)
  {
  }

  public void SliderValueChange()
  {
    if (this.bRefrash)
    {
      this.Value = (long) this.m_slider.value;
      this.Input = this.Value;
    }
    else
      this.bRefrash = true;
    this.m_Handler.OnVauleChang(this);
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.m_inputText != (Object) null && ((Behaviour) this.m_inputText).enabled)
    {
      ((Behaviour) this.m_inputText).enabled = false;
      ((Behaviour) this.m_inputText).enabled = true;
    }
    if (!((Object) this.m_TotalText != (Object) null) || !((Behaviour) this.m_TotalText).enabled)
      return;
    ((Behaviour) this.m_TotalText).enabled = false;
    ((Behaviour) this.m_TotalText).enabled = true;
  }

  private void Update()
  {
    if (!this.bBtnDown)
      return;
    this.tmpTime += Time.smoothDeltaTime;
    if (this.bBtnIncrease && this.Value < this.MaxValue)
    {
      if ((double) this.tmpTime < 0.5)
        return;
      this.bRefrash = false;
      if ((double) this.tmpTime < 2.0)
        ++this.Value;
      else if ((double) this.tmpTime > 4.0)
      {
        if (0.00079999997979030013 * (double) this.tmpTime * (double) this.MaxValue > (double) this.mAddValueTotal)
          this.Value += (long) (0.00079999997979030013 * (double) this.tmpTime * (double) this.MaxValue);
        else
          this.Value += this.mAddValueTotal;
      }
      else
      {
        ++this.mAddValueCount;
        if (this.mAddValueCount > 2L)
        {
          this.mAddValueCount = 0L;
          ++this.mAddValueTotal;
        }
        this.Value += this.mAddValueTotal;
      }
      if (this.Value > this.MaxValue)
      {
        this.Value = this.MaxValue;
        this.m_slider.value = (double) this.Value;
      }
      else
        this.m_slider.value = (double) this.Value;
    }
    else
    {
      if (this.bBtnIncrease || this.Value <= this.MinValue || (double) this.tmpTime < 0.5)
        return;
      this.bRefrash = false;
      if ((double) this.tmpTime < 2.0)
        --this.Value;
      else if ((double) this.tmpTime > 4.0)
      {
        if (0.00079999997979030013 * (double) this.tmpTime * (double) this.MaxValue > (double) this.mAddValueTotal)
          this.Value -= (long) (0.00079999997979030013 * (double) this.tmpTime * (double) this.MaxValue);
        else
          this.Value -= this.mAddValueTotal;
      }
      else
      {
        ++this.mAddValueCount;
        if (this.mAddValueCount > 2L)
        {
          this.mAddValueCount = 0L;
          ++this.mAddValueTotal;
        }
        this.Value -= this.mAddValueTotal;
      }
      if (this.Value < this.MinValue)
        this.Value = this.MinValue;
      this.m_slider.value = (double) this.Value;
    }
  }
}
