// Decompiled with JetBrains decompiler
// Type: RallyTimeBar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class RallyTimeBar : IUTimeBarOnTimer
{
  public UITimeBar TimeBar;
  public GameObject gameObject;
  public UIText Title;
  private CString TitleStr;
  public RectTransform transform;
  private CanvasGroup RedShellAlpha;
  private Image BlueImg;
  private Image RedImg;
  private float GleamTime;
  private float MaxGleamTime = 1f;
  public IUTimeBarOnTimer Hander;

  public RallyTimeBar(UITimeBar timebar, int TimeBarID = 0)
  {
    this.TimeBar = timebar;
    this.TimeBar.m_Handler = (IUTimeBarOnTimer) this;
    this.TimeBar.m_TimeBarID = TimeBarID;
    this.transform = this.TimeBar.transform as RectTransform;
    this.gameObject = ((Component) this.transform).gameObject;
    this.RedShellAlpha = ((Transform) this.transform).GetChild(0).GetComponent<CanvasGroup>();
    ((Component) this.RedShellAlpha).gameObject.SetActive(false);
    this.TitleStr = StringManager.Instance.SpawnString();
    GUIManager.Instance.CreateTimerBar(this.TimeBar, 0L, 0L, 0L, eTimeBarType.Marshal, string.Empty, string.Empty);
    this.BlueImg = ((Transform) this.transform).GetChild(2).GetComponent<Image>();
    this.RedImg = ((Transform) this.transform).GetChild(1).GetComponent<Image>();
    this.Title = ((Transform) this.transform).GetChild(3).GetComponent<UIText>();
  }

  public void SetTimebar(byte kind, long Begin, long Target, long NotifyTime)
  {
    DataManager instance = DataManager.Instance;
    string stringById;
    Image image;
    RectTransform rectTransform;
    if (kind == (byte) 0)
    {
      if (instance.ServerTime < Target)
      {
        ((Component) this.RedShellAlpha).gameObject.SetActive(false);
        this.RedShellAlpha.alpha = 0.0f;
        stringById = instance.mStringTable.GetStringByID(4875U);
      }
      else
      {
        ((Component) this.RedShellAlpha).gameObject.SetActive(true);
        this.RedShellAlpha.alpha = 1f;
        stringById = instance.mStringTable.GetStringByID(4876U);
      }
      ((Component) this.BlueImg).gameObject.SetActive(true);
      ((Component) this.RedImg).gameObject.SetActive(false);
      image = this.BlueImg;
      rectTransform = ((Graphic) this.BlueImg).rectTransform;
    }
    else
    {
      ((Component) this.RedShellAlpha).gameObject.SetActive(true);
      this.RedShellAlpha.alpha = 1f;
      stringById = instance.mStringTable.GetStringByID(4877U);
      ((Component) this.BlueImg).gameObject.SetActive(false);
      ((Component) this.RedImg).gameObject.SetActive(true);
      image = this.RedImg;
      rectTransform = ((Graphic) this.RedImg).rectTransform;
    }
    this.Title.text = stringById;
    GUIManager.Instance.SetTimerBar(this.TimeBar, Begin, Target, NotifyTime, eTimeBarType.SpeedupType, string.Empty, string.Empty);
    this.TimeBar.m_SliderImage = image;
    this.TimeBar.m_SliderRectTransform = rectTransform;
    if (((Component) this.transform).gameObject.activeSelf)
      return;
    ((Component) this.transform).gameObject.SetActive(true);
  }

  public void Update()
  {
    if (!((Component) this.RedShellAlpha).gameObject.activeSelf)
      return;
    float num = this.GleamTime / this.MaxGleamTime;
    if ((double) num <= 1.0)
      this.RedShellAlpha.alpha = 1f - num;
    else if ((double) num <= 2.0)
      this.RedShellAlpha.alpha = num - 1f;
    else
      this.GleamTime = 0.0f;
    this.GleamTime += Time.deltaTime;
  }

  public void TextRefresh()
  {
    if (this.TimeBar.gameObject.activeSelf)
      this.TimeBar.Refresh_FontTexture();
    ((Behaviour) this.Title).enabled = false;
    ((Behaviour) this.Title).enabled = true;
  }

  public void Destroy()
  {
    GUIManager.Instance.RemoverTimeBaarToList(this.TimeBar);
    StringManager.Instance.DeSpawnString(this.TitleStr);
  }

  public void OnTimer(UITimeBar sender)
  {
    this.Title.text = DataManager.Instance.mStringTable.GetStringByID(4876U);
    ((Component) this.RedShellAlpha).gameObject.SetActive(true);
    this.RedShellAlpha.alpha = 1f;
    if (this.Hander == null)
      return;
    this.Hander.OnTimer(sender);
  }

  public void OnNotify(UITimeBar sender)
  {
  }

  public void Onfunc(UITimeBar sender)
  {
  }

  public void OnCancel(UITimeBar sender)
  {
  }
}
