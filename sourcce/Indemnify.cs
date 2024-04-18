// Decompiled with JetBrains decompiler
// Type: Indemnify
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class Indemnify
{
  private static readonly string INDEMNIFY_SAVE_NAME = "Indemnify{0}";
  private static readonly string INDEMNIFY_TIME_SAVE_NAME = "IndemnifyTime{0}";
  public long TriggerTime;
  public long[] ResourceCache = new long[4];
  public static int TriggerCount;
  public float EffectDelay;
  public int EffectIndex;
  public SpeciallyEffect_Kind[] EffectKind = new SpeciallyEffect_Kind[4]
  {
    SpeciallyEffect_Kind.Food,
    SpeciallyEffect_Kind.Wood,
    SpeciallyEffect_Kind.Iron,
    SpeciallyEffect_Kind.Stone
  };
  private INDEMNIFY_STATE bTriggered;
  public static bool IsEffectShow;
  private static Indemnify m_Self;

  public static INDEMNIFY_STATE UIStatus
  {
    set
    {
      if (Indemnify.m_Self == null)
        return;
      Indemnify.m_Self.bTriggered = value;
    }
    get => Indemnify.m_Self != null ? Indemnify.m_Self.bTriggered : INDEMNIFY_STATE.None;
  }

  public static Indemnify Instance
  {
    get
    {
      if (Indemnify.m_Self == null)
        Indemnify.m_Self = new Indemnify();
      return Indemnify.m_Self;
    }
  }

  public static void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 2 || Indemnify.m_Self == null || Indemnify.UIStatus != INDEMNIFY_STATE.ShowingTalk)
      return;
    GUIManager.Instance.mStartV2 = new Vector2(((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x / 2f, ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.y - 150f);
    Indemnify.m_Self.EffectDelay = 0.0f;
    Indemnify.m_Self.EffectIndex = 0;
    Indemnify.IsEffectShow = true;
    Indemnify.UIStatus = !Indemnify.m_Self.HasIndemnify() ? INDEMNIFY_STATE.None : INDEMNIFY_STATE.ShowButton;
    ActivityGiftManager.Instance.CheckShowActivityGiftEffect();
  }

  public static void UpdateRun()
  {
    if (Indemnify.m_Self == null || !Indemnify.IsEffectShow)
      return;
    if ((double) Indemnify.m_Self.EffectDelay <= 0.0)
    {
      GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, Indemnify.m_Self.EffectKind[Indemnify.m_Self.EffectIndex], ItemID: (ushort) 0, EndTime: 2f);
      ++Indemnify.m_Self.EffectIndex;
      Indemnify.m_Self.EffectDelay = UnityEngine.Random.Range(0.1f, 0.3f);
      if (Indemnify.m_Self.EffectIndex < Indemnify.m_Self.EffectKind.Length)
        return;
      Indemnify.IsEffectShow = false;
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 21);
    }
    else
      Indemnify.m_Self.EffectDelay -= Time.deltaTime;
  }

  private bool HasIndemnify()
  {
    for (int index = 0; index < 4; ++index)
    {
      if (this.ResourceCache[index] != 0L)
        return true;
    }
    return false;
  }

  public void CheckIndemnify(MessagePacket MP)
  {
    byte num = MP.ReadByte();
    this.TriggerTime = MP.ReadLong();
    for (int index = 0; index < 4; ++index)
    {
      this.ResourceCache[index] = MP.ReadLong();
      if (this.ResourceCache[index] != 0L && this.bTriggered == INDEMNIFY_STATE.None)
        this.bTriggered = INDEMNIFY_STATE.Triggered;
    }
    if (num != (byte) 0 && this.bTriggered == INDEMNIFY_STATE.Triggered)
    {
      if (this.CheckTriggered(this.TriggerTime))
        this.bTriggered = INDEMNIFY_STATE.ShowButton;
    }
    else
      FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.SUPPLY_CHEST, 0L, 0UL);
    this.SaveTriggerTime();
    if (!this.HasIndemnify() && this.bTriggered != INDEMNIFY_STATE.None)
    {
      this.bTriggered = INDEMNIFY_STATE.None;
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 21);
    }
    GameManager.OnRefresh(NetworkNews.Refresh_IndemnifyResources);
    Indemnify.CheckShowIndemnify();
    Debug.LogWarning((object) nameof (CheckIndemnify));
    Debug.LogWarning((object) this.ResourceCache[0].ToString());
    Debug.LogWarning((object) this.ResourceCache[1].ToString());
    Debug.LogWarning((object) this.ResourceCache[2].ToString());
    Debug.LogWarning((object) this.ResourceCache[3].ToString());
  }

  public void SaveTriggerTime()
  {
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.uLongToFormat((ulong) DataManager.Instance.RoleAttr.UserId);
    cstring.AppendFormat(Indemnify.INDEMNIFY_TIME_SAVE_NAME);
    PlayerPrefs.SetString(cstring.ToString(), this.TriggerTime.ToString());
  }

  public bool CheckTriggered(long time)
  {
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.uLongToFormat((ulong) DataManager.Instance.RoleAttr.UserId);
    cstring.AppendFormat(Indemnify.INDEMNIFY_TIME_SAVE_NAME);
    long result = 0;
    long.TryParse(PlayerPrefs.GetString(cstring.ToString(), "0"), out result);
    return result >= time;
  }

  public void CheckIndemnifyResource(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    DataManager.Instance.Resource[0].Stock = MP.ReadUInt();
    DataManager.Instance.Resource[1].Stock = MP.ReadUInt();
    DataManager.Instance.Resource[2].Stock = MP.ReadUInt();
    DataManager.Instance.Resource[3].Stock = MP.ReadUInt();
    GameManager.OnRefresh(NetworkNews.Refresh_Resource);
    Array.Clear((Array) this.ResourceCache, 0, 4);
    this.AddResourceEffect();
    GUIManager instance = GUIManager.Instance;
    instance.CloseMenu(EGUIWindow.UI_TreasureBox);
    instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
    this.bTriggered = INDEMNIFY_STATE.None;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 21);
    Debug.LogWarning((object) nameof (CheckIndemnifyResource));
    FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.COLLECT_EXTRA_SUPPLIES, 0L, 0UL);
  }

  public void AddResourceEffect()
  {
    Array.Clear((Array) GUIManager.Instance.SE_Kind, 0, GUIManager.Instance.SE_Kind.Length);
    Array.Clear((Array) GUIManager.Instance.m_SpeciallyEffect.mResValue, 0, GUIManager.Instance.m_SpeciallyEffect.mResValue.Length);
    Array.Clear((Array) GUIManager.Instance.SE_ItemID, 0, GUIManager.Instance.SE_ItemID.Length);
    GUIManager.Instance.SE_Kind[0] = SpeciallyEffect_Kind.Food;
    GUIManager.Instance.SE_Kind[1] = SpeciallyEffect_Kind.Stone;
    GUIManager.Instance.SE_Kind[2] = SpeciallyEffect_Kind.Wood;
    GUIManager.Instance.SE_Kind[3] = SpeciallyEffect_Kind.Iron;
    GUIManager.Instance.mStartV2 = new Vector2(((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x / 2f, ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.y - 150f);
    GUIManager.Instance.m_SpeciallyEffect.AddIconShow(GUIManager.Instance.mStartV2, GUIManager.Instance.SE_Kind, GUIManager.Instance.SE_ItemID);
  }

  public static void CheckShowIndemnify()
  {
    if (Indemnify.UIStatus != INDEMNIFY_STATE.Triggered)
      return;
    bool flag = true;
    if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
      flag = false;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap)
      flag = false;
    if ((UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null)
      flag = false;
    if (!MallManager.Instance.bCanOpenMain)
      flag = false;
    if (!(GameManager.ActiveGameplay is Origin))
      flag = false;
    if (NewbieManager.IsWorking() || !flag)
      return;
    int num = UnityEngine.Random.Range(22, 30);
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.uLongToFormat((ulong) DataManager.Instance.RoleAttr.UserId);
    cstring.AppendFormat(Indemnify.INDEMNIFY_SAVE_NAME);
    if (PlayerPrefs.GetInt(cstring.ToString()) == 0)
    {
      num = 22;
      PlayerPrefs.SetInt(cstring.ToString(), 1);
    }
    ++Indemnify.TriggerCount;
    GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, num);
    Indemnify.UIStatus = INDEMNIFY_STATE.ShowingTalk;
  }

  public static void SendRequestIndemnify()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_INDEMNIFY;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }
}
