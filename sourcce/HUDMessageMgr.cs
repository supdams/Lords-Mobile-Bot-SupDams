// Decompiled with JetBrains decompiler
// Type: HUDMessageMgr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class HUDMessageMgr : Hudhandle
{
  public const byte MAX = 3;
  private bool bInit;
  public static readonly Color[] HUDColor = new Color[2]
  {
    Color.yellow,
    Color.red
  };
  public CanvasGroup BackCanvasGroup;
  public RectTransform BackRect;
  private HUDItem[] HudMessage = new HUDItem[3];
  private bool bFirstShow;
  private byte UseCount;
  private int MinBackHeight;
  private int DesirePos;
  public float FirstShowTime;
  public float MaxFirstShowTime = 0.1f;
  public float FadeoutTime;
  public float BackMaxWidth;
  private Vector2 BackOriPos;
  private string LatestStr;
  private CString LatestCstr;
  private CString LatestQueueCstr;
  private ushort LatestType;
  public _MapHud MapHud;
  public HUDQueueItem HUDQueue;
  private float QueueTime;
  private float ShowQueueTime = 2.5f;
  private HUDMessageMgr.eMessageSource MessageSource;

  private void CloneValue(HUDItem Src, HUDItem Target)
  {
    Target.ThisTransform.gameObject.SetActive(Src.ThisTransform.gameObject.activeSelf);
    Target.Alpha.alpha = Src.Alpha.alpha;
    Target.DelayTime = Src.DelayTime;
    Target.FadeTime = Src.FadeTime;
    Target.Icon.sprite = Src.Icon.sprite;
    ((MaskableGraphic) Target.Icon).material = ((MaskableGraphic) Src.Icon).material;
    Target.CloneText(Src.MsgStr.ToString());
    ((Graphic) Target.MsgText).color = ((Graphic) Src.MsgText).color;
    Target.ShowIconTime = Src.ShowIconTime;
    Target.bColseItem = Src.bColseItem;
    Target.MP3Sound = Src.MP3Sound;
    Target.SFXKind = Src.SFXKind;
  }

  public void AddMessageQueqe(string Msg, ushort Type, bool bCheckSame = true)
  {
    if (this.HUDQueue.Count == (byte) 0)
      this.LatestQueueCstr.ClearString();
    if (bCheckSame && this.CheckLaseSame(Msg, this.LatestQueueCstr.ToString()))
      return;
    if (this.UseCount == (byte) 0 && this.HUDQueue.Count == (byte) 0)
      this.AddMessage(Msg, Type, bCheckSame);
    else if (!this.HUDQueue.Push(Msg, Type))
    {
      string Msg1;
      ushort Type1;
      this.HUDQueue.Pop(out Msg1, out Type1);
      this.AddMessageDirect(Msg1, Type1);
      this.HUDQueue.Push(Msg, Type);
    }
    else
    {
      this.LatestQueueCstr.ClearString();
      this.LatestQueueCstr.Append(Msg);
      this.CheckQueue();
    }
  }

  public void AddMessage(string Msg, ushort Type, bool bCheckSame = true)
  {
    if (!this.bInit)
    {
      this.Init();
      this.bInit = true;
    }
    if (this.HUDQueue.Count > (byte) 0)
      this.AddMessageQueqe(Msg, Type, bCheckSame);
    else
      this.AddMessageDirect(Msg, Type, bCheckSame);
  }

  private void AddMessageDirect(string Msg, ushort Type, bool bCheckSame = true)
  {
    if (!this.bInit)
    {
      this.Init();
      this.bInit = true;
    }
    this.QueueTime = 0.0f;
    if (bCheckSame && this.HudMessage[0].ThisTransform.gameObject.activeSelf && (int) this.LatestType == (int) Type)
    {
      if (Msg == this.LatestStr)
      {
        this.HudMessage[0].AddMessage(Msg, Type);
        return;
      }
      if (this.CheckLaseSame(Msg, this.LatestCstr.ToString()))
      {
        this.HudMessage[0].AddMessage(Msg, Type);
        return;
      }
    }
    if (this.UseCount < (byte) 3)
    {
      for (byte useCount = this.UseCount; useCount > (byte) 0; --useCount)
        this.CloneValue(this.HudMessage[(int) useCount - 1], this.HudMessage[(int) useCount]);
      this.HudMessage[0].AddMessage(Msg, Type);
    }
    else
    {
      this.UseCount = (byte) 2;
      for (byte useCount = this.UseCount; useCount > (byte) 0; --useCount)
        this.CloneValue(this.HudMessage[(int) useCount - 1], this.HudMessage[(int) useCount]);
      this.HudMessage[0].AddMessage(Msg, Type);
    }
    this.LatestStr = Msg;
    this.LatestCstr.ClearString();
    this.LatestCstr.StringToFormat(Msg);
    this.LatestCstr.AppendFormat("{0}");
    this.LatestType = Type;
    ++this.UseCount;
    if (this.UseCount == (byte) 1 && !((Component) this.BackRect).gameObject.activeSelf)
    {
      ((Component) this.BackRect).gameObject.SetActive(true);
      this.bFirstShow = true;
      this.FirstShowTime = 0.0f;
    }
    this.BackCanvasGroup.alpha = 1f;
    this.UpdateBackSize();
  }

  private unsafe bool CheckLaseSame(string Msg, string CompareStr)
  {
    if (Msg == null || CompareStr == null)
      return false;
    string str1 = CompareStr;
    string str2 = Msg;
    char* chPtr1 = (char*) ((IntPtr) str2 + RuntimeHelpers.OffsetToStringData);
    string str3 = str1;
    char* chPtr2 = (char*) ((IntPtr) str3 + RuntimeHelpers.OffsetToStringData);
    for (int index = 0; index < str1.Length; ++index)
    {
      if (chPtr2[index] == char.MinValue)
        return chPtr1[index] == char.MinValue;
      if (Msg.Length <= index || (int) chPtr1[index] != (int) chPtr2[index])
        return false;
    }
    str2 = (string) null;
    str3 = (string) null;
    return true;
  }

  public void Init()
  {
    if (this.bInit)
      return;
    this.MessageSource = HUDMessageMgr.eMessageSource.Direct;
    GameObject gameObject = UnityEngine.Object.Instantiate(GUIManager.Instance.m_ManagerAssetBundle.Load("UIHUD")) as GameObject;
    gameObject.transform.SetParent((Transform) GUIManager.Instance.m_HUDsTransform, false);
    Transform transform = gameObject.transform;
    this.BackCanvasGroup = transform.GetChild(0).GetComponent<CanvasGroup>();
    this.BackRect = transform.GetChild(0).GetComponent<RectTransform>();
    CustomImage component = transform.GetChild(0).GetComponent<CustomImage>();
    GUIManager.Instance.m_ItemInfo.LoadCustomImage((Image) component, component.ImageName, component.TextureName);
    if (this.MapHud == null)
      this.MapHud = new _MapHud();
    this.MapHud.Init(transform.GetChild(1));
    if (this.HUDQueue == null)
      this.HUDQueue = new HUDQueueItem();
    this.UseCount = (byte) 0;
    this.bFirstShow = false;
    for (int index = 0; index < 3; ++index)
    {
      if (this.HudMessage[index] == null)
        this.HudMessage[index] = new HUDItem();
      this.HudMessage[index].Init(index, transform.GetChild(transform.childCount - index - 1));
      this.HudMessage[index].Handle = (Hudhandle) this;
    }
    this.BackMaxWidth = 713f;
    this.BackOriPos = this.BackRect.anchoredPosition;
    if (this.LatestCstr == null)
      this.LatestCstr = StringManager.Instance.SpawnString(200);
    if (this.LatestQueueCstr == null)
      this.LatestQueueCstr = StringManager.Instance.SpawnString(200);
    this.bInit = true;
  }

  public void UpdateBackSize()
  {
    if (this.UseCount == (byte) 2 && !this.HudMessage[1].ThisTransform.gameObject.activeSelf)
    {
      this.MinBackHeight = 120;
    }
    else
    {
      this.MinBackHeight = Mathf.Max(40, (int) this.UseCount * 40);
      if (this.MinBackHeight == 80)
      {
        if (!this.HudMessage[2].ThisTransform.gameObject.activeSelf)
        {
          this.DesirePos = (int) this.BackOriPos.y;
        }
        else
        {
          if (this.HudMessage[0].ThisTransform.gameObject.activeSelf)
            return;
          this.DesirePos = (int) this.BackOriPos.y + 40;
        }
      }
      else if (this.MinBackHeight == 40)
      {
        if (this.HudMessage[0].ThisTransform.gameObject.activeSelf)
          this.DesirePos = (int) this.BackOriPos.y;
        else if (this.HudMessage[1].ThisTransform.gameObject.activeSelf)
        {
          this.DesirePos = (int) this.BackOriPos.y + 40;
        }
        else
        {
          if (!this.HudMessage[2].ThisTransform.gameObject.activeSelf)
            return;
          this.DesirePos = (int) this.BackOriPos.y + 80;
        }
      }
      else
      {
        if (this.MinBackHeight != 120)
          return;
        this.DesirePos = (int) this.BackOriPos.y;
      }
    }
  }

  public void Update()
  {
    if ((UnityEngine.Object) this.BackRect == (UnityEngine.Object) null)
      return;
    if (this.MapHud != null)
      this.MapHud.Update();
    this.CheckQueue();
    float num1 = 0.5f;
    if ((UnityEngine.Object) this.BackRect == (UnityEngine.Object) null || !((Component) this.BackRect).gameObject.activeSelf)
      return;
    Vector2 sizeDelta = this.BackRect.sizeDelta;
    Vector2 anchoredPosition = this.BackRect.anchoredPosition;
    float unscaledDeltaTime = Time.unscaledDeltaTime;
    if (this.bFirstShow)
    {
      sizeDelta.y = 40f;
      sizeDelta.x = EasingEffect.Linear(this.FirstShowTime, 0.0f, this.BackMaxWidth, this.MaxFirstShowTime);
      this.FirstShowTime += unscaledDeltaTime;
      if ((double) this.FirstShowTime > (double) this.MaxFirstShowTime)
      {
        this.bFirstShow = false;
        this.FadeoutTime = 0.0f;
        sizeDelta.x = this.BackMaxWidth;
      }
      this.BackRect.sizeDelta = sizeDelta;
    }
    else
    {
      int num2 = (int) ((double) this.MinBackHeight - (double) sizeDelta.y);
      int num3 = (int) ((double) this.DesirePos - (double) anchoredPosition.y);
      if (num2 > 0)
      {
        sizeDelta.y += (float) ((double) this.MinBackHeight * (double) unscaledDeltaTime * 5.0);
        if ((double) sizeDelta.y > (double) this.MinBackHeight)
          sizeDelta.y = (float) this.MinBackHeight;
        this.BackRect.sizeDelta = sizeDelta;
      }
      if (num3 > 0)
      {
        anchoredPosition.y += (float) ((double) this.MinBackHeight * (double) unscaledDeltaTime * 5.0);
        if ((double) anchoredPosition.y > (double) this.DesirePos)
          anchoredPosition.y = (float) this.DesirePos;
        this.BackRect.anchoredPosition = anchoredPosition;
      }
      for (int index = 0; index < 3; ++index)
        this.HudMessage[index].Update();
      int num4 = (int) ((double) this.MinBackHeight - (double) sizeDelta.y);
      if (num4 < 0)
      {
        sizeDelta.y -= (float) ((double) this.MinBackHeight * (double) unscaledDeltaTime * 5.0);
        if ((double) sizeDelta.y < (double) this.MinBackHeight)
          sizeDelta.y = (float) this.MinBackHeight;
        this.BackRect.sizeDelta = sizeDelta;
      }
      if (num3 < 0)
      {
        anchoredPosition.y -= (float) ((double) this.MinBackHeight * (double) unscaledDeltaTime * 5.0);
        if ((double) anchoredPosition.y < (double) this.DesirePos)
          anchoredPosition.y = (float) this.DesirePos;
        this.BackRect.anchoredPosition = anchoredPosition;
      }
      if (this.UseCount != (byte) 0 || num4 != 0)
        return;
      this.BackCanvasGroup.alpha = (float) (1.0 - (double) this.FadeoutTime / (double) num1);
      this.FadeoutTime += unscaledDeltaTime;
      if ((double) this.FadeoutTime <= (double) num1)
        return;
      sizeDelta.Set(0.0f, this.BackRect.sizeDelta.y);
      this.BackRect.sizeDelta = sizeDelta;
      anchoredPosition.y = this.BackOriPos.y;
      this.BackRect.anchoredPosition = anchoredPosition;
      ((Component) this.BackRect).gameObject.SetActive(false);
    }
  }

  public void TextRefresh()
  {
    if (this.MapHud != null)
    {
      ((Behaviour) this.MapHud.MsgText).enabled = false;
      ((Behaviour) this.MapHud.MsgText).enabled = true;
    }
    for (int index = 0; index < this.HudMessage.Length; ++index)
    {
      if (this.HudMessage[index] != null)
      {
        ((Behaviour) this.HudMessage[index].MsgText).enabled = false;
        ((Behaviour) this.HudMessage[index].MsgText).enabled = true;
      }
    }
  }

  private void CheckQueue()
  {
    if (this.HUDQueue == null)
      return;
    if (this.HUDQueue.Count > (byte) 0)
    {
      this.MessageSource = HUDMessageMgr.eMessageSource.Queue;
      this.QueueTime += Time.deltaTime;
    }
    else
      this.MessageSource = HUDMessageMgr.eMessageSource.Direct;
    if ((double) this.QueueTime < (double) this.ShowQueueTime || this.MessageSource != HUDMessageMgr.eMessageSource.Queue || this.UseCount >= (byte) 3)
      return;
    string Msg;
    ushort Type;
    this.HUDQueue.Pop(out Msg, out Type);
    if (Msg == null)
      return;
    this.AddMessageDirect(Msg, Type);
    this.QueueTime = 0.0f;
  }

  public static float Quintic(float t, float b, float c, float d)
  {
    float num1 = (t /= d) * t;
    float num2 = num1 * t;
    return b + c * ((float) (-22.597499847412109 * (double) num2 * (double) num1 + 22.597499847412109 * (double) num1 * (double) num1) + t);
  }

  public void Destroy()
  {
    if ((UnityEngine.Object) this.BackRect == (UnityEngine.Object) null)
      return;
    this.MapHud.Destroy();
    this.HUDQueue.Destroy();
    for (int index = 0; index < this.HudMessage.Length; ++index)
      this.HudMessage[index].Destroy();
    UnityEngine.Object.Destroy((UnityEngine.Object) ((Transform) this.BackRect).parent.gameObject);
    this.BackRect = (RectTransform) null;
    this.bInit = false;
    this.FadeoutTime = 0.0f;
    StringManager.Instance.DeSpawnString(this.LatestQueueCstr);
    StringManager.Instance.DeSpawnString(this.LatestCstr);
    this.LatestQueueCstr = (CString) null;
    this.LatestCstr = (CString) null;
  }

  public void OnDestroyMessage(int Index)
  {
    --this.UseCount;
    this.UpdateBackSize();
  }

  private enum eMessageSource
  {
    Direct,
    Queue,
  }
}
