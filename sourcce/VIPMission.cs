// Decompiled with JetBrains decompiler
// Type: VIPMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class VIPMission : iMissionAnimNotify, IUIButtonClickHandler
{
  private Transform transform;
  private Transform CompleteBarTrans;
  private Transform PrictTrans;
  private Transform ResetTitleTrans;
  private _MissionTimeBar TimeBar;
  private GameObject Treasure;
  private GameObject SpeedupBtnObj;
  private GameObject BoxEffect;
  private GameObject TitleObject;
  private int TreasureassetKey;
  private List<UIText> TitleText = new List<UIText>();
  private UIButton[] RewardBtn = new UIButton[7];
  private VIPMission._TreasureBox[] TreasureBox = new VIPMission._TreasureBox[7];
  private Transform[] Restrict = new Transform[7];
  private CString ResetTimeStr;
  private CString[] RestrictStr = new CString[7];
  private byte OpenBoxIdx = byte.MaxValue;
  private CScrollRect PriceScroll;
  private RectTransform PriceCont;
  private Vector3 RewardEffPos = new Vector3();
  private Vector2 ScreenSize;
  private Vector2 ScrollPricePos;
  private int ThrowEffectCount;
  private int ThrowEffectIdx;
  private int BoxEffectID;
  private float EffectTime;
  private float MaxEffectTime = 1.5f;
  private float ScrollContWidth;
  public iMissionTimeDelta TimdHandle;

  public VIPMission(Transform transform, _MissionTimeBar timebar)
  {
    this.transform = transform;
    this.TimeBar = timebar;
    ((Transform) this.TimeBar.transform).SetParent(transform.GetChild(1));
  }

  public void Init()
  {
    DataManager instance1 = DataManager.Instance;
    this.ResetTimeStr = StringManager.Instance.SpawnString(100);
    this.TitleObject = this.transform.GetChild(0).gameObject;
    UIText component1 = this.transform.GetChild(0).GetChild(1).GetComponent<UIText>();
    component1.text = instance1.mStringTable.GetStringByID(1530U);
    this.AddRefreshText(component1);
    UIText component2 = this.transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
    component2.text = instance1.mStringTable.GetStringByID(323U);
    this.AddRefreshText(component2);
    UIText component3 = this.transform.GetChild(10).GetChild(0).GetComponent<UIText>();
    this.ResetTimeStr.ClearString();
    DateTime dateTime = GameConstants.GetDateTime(DataManager.Instance.RoleAttr.FirstTimer);
    this.ResetTimeStr.IntToFormat((long) dateTime.Hour, 2);
    this.ResetTimeStr.IntToFormat((long) dateTime.Minute, 2);
    this.ResetTimeStr.AppendFormat(instance1.mStringTable.GetStringByID(753U));
    component3.text = this.ResetTimeStr.ToString();
    component3.SetAllDirty();
    component3.cachedTextGenerator.Invalidate();
    this.AddRefreshText(component3);
    this.CompleteBarTrans = ((Transform) this.TimeBar.transform).GetChild(0).GetChild(0).GetChild(0);
    UIText component4 = this.CompleteBarTrans.GetChild(0).GetComponent<UIText>();
    component4.text = instance1.mStringTable.GetStringByID(7949U);
    this.AddRefreshText(component4);
    if (GUIManager.Instance.IsArabic)
      this.transform.GetChild(1).GetChild(0).GetChild(1).localScale = new Vector3(-1f, 1f, 1f);
    this.SpeedupBtnObj = this.transform.GetChild(1).GetChild(0).GetChild(1).gameObject;
    CString Name = StringManager.Instance.StaticString1024();
    Name.ClearString();
    Name.AppendFormat("Role/RewardBtn");
    this.Treasure = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle(Name, out this.TreasureassetKey).Load("m")) as GameObject;
    GUIManager.Instance.SetLayer(this.Treasure, 5);
    Vector3 vector3 = new Vector3(23.5f, 152.5f, 350.6f);
    this.TreasureBox[0] = new VIPMission._TreasureBox(this.Treasure.transform);
    this.TreasureBox[0].transform.SetParent(this.transform.GetChild(3));
    this.TreasureBox[0].transform.localScale = Vector3.one * 300f;
    this.TreasureBox[0].NotifyHandle = (iMissionAnimNotify) this;
    this.TreasureBox[0].transform.localRotation = this.TreasureBox[0].transform.localRotation with
    {
      eulerAngles = vector3
    };
    this.TreasureBox[0].transform.localPosition = Vector3.zero;
    this.RewardBtn[0] = this.transform.GetChild(3).GetChild(0).GetComponent<UIButton>();
    this.RewardBtn[0].m_Handler = (IUIButtonClickHandler) this;
    this.RestrictStr[0] = StringManager.Instance.SpawnString();
    this.RestrictStr[0].IntToFormat((long) DataManager.MissionDataManager.VipLvRestrict[0]);
    this.RestrictStr[0].AppendFormat(instance1.mStringTable.GetStringByID(7951U));
    this.Restrict[0] = this.transform.GetChild(3).GetChild(1);
    UIText component5 = this.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<UIText>();
    component5.text = this.RestrictStr[0].ToString();
    component5.SetAllDirty();
    component5.cachedTextGenerator.Invalidate();
    this.AddRefreshText(component5);
    for (int index = 1; index < this.TreasureBox.Length; ++index)
    {
      this.TreasureBox[index] = new VIPMission._TreasureBox((UnityEngine.Object.Instantiate((UnityEngine.Object) this.Treasure) as GameObject).transform);
      this.TreasureBox[index].transform.SetParent(this.transform.GetChild(3 + index));
      this.TreasureBox[index].transform.localScale = this.TreasureBox[0].transform.localScale;
      this.TreasureBox[index].transform.localPosition = this.TreasureBox[0].transform.localPosition;
      this.TreasureBox[index].transform.localRotation = this.TreasureBox[0].transform.localRotation;
      this.TreasureBox[index].NotifyHandle = (iMissionAnimNotify) this;
      this.RestrictStr[index] = StringManager.Instance.SpawnString();
      this.RestrictStr[index].IntToFormat((long) DataManager.MissionDataManager.VipLvRestrict[index]);
      this.RestrictStr[index].AppendFormat(instance1.mStringTable.GetStringByID(7951U));
      this.Restrict[index] = this.transform.GetChild(3 + index).GetChild(1);
      this.RewardBtn[index] = this.transform.GetChild(3 + index).GetChild(0).GetComponent<UIButton>();
      this.RewardBtn[index].m_Handler = (IUIButtonClickHandler) this;
      this.RewardBtn[index].m_BtnID1 = index;
      UIText component6 = this.transform.GetChild(3 + index).GetChild(1).GetChild(0).GetComponent<UIText>();
      component6.text = this.RestrictStr[index].ToString();
      component6.SetAllDirty();
      component6.cachedTextGenerator.Invalidate();
      this.AddRefreshText(component6);
    }
    DataManager.MissionDataManager.UpdateUIBox = (byte) 0;
    this.TreasureBox[6].transform.parent.gameObject.SetActive(false);
    this.PrictTrans = this.transform.GetChild(2);
    this.PriceCont = this.transform.GetChild(2).GetChild(2).GetChild(0).GetComponent<RectTransform>();
    this.PriceScroll = this.transform.GetChild(2).GetChild(2).GetComponent<CScrollRect>();
    UIButtonHint.scrollRect = this.PriceScroll;
    GUIManager instance2 = GUIManager.Instance;
    for (byte index = 0; index < (byte) 8; ++index)
    {
      instance2.InitianHeroItemImg(((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild((int) index), eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0);
      this.AddRefreshText(((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild((int) index).GetChild(4).GetComponent<UIText>());
    }
    this.ScreenSize = ((Component) instance2.m_UICanvas).GetComponent<RectTransform>().sizeDelta;
    this.ScrollContWidth = this.PriceCont.sizeDelta.x;
    this.ScrollPricePos = this.PriceCont.anchoredPosition;
    this.ResetTitleTrans = this.transform.GetChild(10);
    Camera.main.cullingMask |= 1 << LayerMask.NameToLayer(GlobalProjectorManager.GlobalProjectorLayer);
    this.UpdateUI();
    if (!GUIManager.Instance.IsArabic)
      return;
    Transform child = this.transform.GetChild(11);
    Quaternion localRotation = child.localRotation with
    {
      eulerAngles = new Vector3(9.501f, 20.636f, 142.35f)
    };
    child.localRotation = localRotation;
  }

  public void InitPrice()
  {
    DataManager instance = DataManager.Instance;
    byte num1 = 0;
    ushort[] vipRewardItem = DataManager.MissionDataManager.VipRewardItem;
    for (int index = 0; index < vipRewardItem.Length && vipRewardItem[index] != (ushort) 0; ++index)
    {
      Equip recordByKey = instance.EquipTable.GetRecordByKey(vipRewardItem[index]);
      ++num1;
      if (!GUIManager.Instance.IsLeadItem(recordByKey.EquipKind))
      {
        if (index < ((Transform) this.PriceCont).GetChild(0).GetChild(0).childCount)
        {
          GUIManager.Instance.ChangeHeroItemImg(((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild(index), eHeroOrItem.Item, vipRewardItem[index], (byte) 0, (byte) 0);
          ((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild(index).gameObject.SetActive(true);
        }
        else
        {
          RectTransform BtnT = UnityEngine.Object.Instantiate((UnityEngine.Object) ((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild(0)) as RectTransform;
          ((Transform) BtnT).SetParent(((Transform) this.PriceCont).GetChild(0).GetChild(0));
          BtnT.anchoredPosition3D = new Vector3(BtnT.anchoredPosition.x, BtnT.anchoredPosition.y, 0.0f);
          Quaternion localRotation = ((Transform) BtnT).localRotation with
          {
            eulerAngles = Vector3.zero
          };
          ((Transform) BtnT).localRotation = localRotation;
          ((Transform) BtnT).localScale = Vector3.one;
          BtnT.anchoredPosition = new Vector2((float) (7 + 93 * index), 0.0f);
          ((Component) BtnT).gameObject.SetActive(true);
          GUIManager.Instance.ChangeHeroItemImg((Transform) BtnT, eHeroOrItem.Item, vipRewardItem[index], (byte) 0, (byte) 0);
          this.AddRefreshText(((Transform) BtnT).GetChild(4).GetComponent<UIText>());
        }
      }
    }
    if (((Transform) this.PriceCont).GetChild(0).GetChild(0).childCount > (int) num1)
    {
      for (int index = (int) num1; index < ((Transform) this.PriceCont).GetChild(0).GetChild(0).childCount; ++index)
        ((Transform) this.PriceCont).GetChild(0).GetChild(0).GetChild(index).gameObject.SetActive(false);
    }
    float num2 = (float) (7.0 + 93.0 * (double) num1);
    this.PriceCont.anchoredPosition = this.ScrollPricePos;
    if ((double) this.ScrollContWidth < (double) num2)
    {
      this.PriceCont.sizeDelta = this.PriceCont.sizeDelta with
      {
        x = num2 + 4f
      };
      ((Behaviour) this.PriceScroll).enabled = true;
    }
    else
      ((Behaviour) this.PriceScroll).enabled = false;
  }

  public void SetAchieve(bool active)
  {
    if (active)
    {
      DataManager.msgBuffer[0] = (byte) 84;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      GUIManager.Instance.m_UICanvas.renderMode = (RenderMode) 1;
      GUIManager.Instance.SetCanvasChanged();
      if ((UnityEngine.Object) this.Treasure != (UnityEngine.Object) null)
      {
        for (int index = 0; index < this.TreasureBox.Length; ++index)
          this.TreasureBox[index].PlayAnimation();
        this.UpdateUI();
      }
    }
    else
    {
      ushort[] vipRewardItem = DataManager.MissionDataManager.VipRewardItem;
      Array.Clear((Array) vipRewardItem, 0, vipRewardItem.Length);
      SpeciallyEffect_Kind[] vipRewardKind = DataManager.MissionDataManager.VipRewardKind;
      Array.Clear((Array) vipRewardKind, 0, vipRewardKind.Length);
      GUIManager.Instance.m_SpeciallyEffect.ClearAllEffect();
      DataManager.msgBuffer[0] = (byte) 84;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      GUIManager.Instance.m_UICanvas.renderMode = (RenderMode) 0;
      GUIManager.Instance.SetCanvasChanged();
      for (int index = 0; index < this.TreasureBox.Length; ++index)
        this.TreasureBox[index].StopAnimation();
      this.ThrowEffectCount = 0;
    }
    if ((UnityEngine.Object) this.Treasure == (UnityEngine.Object) null)
    {
      this.Init();
      this.UpdateUI();
    }
    this.transform.gameObject.SetActive(active);
  }

  public void UpdateUI()
  {
    MissionManager missionDataManager = DataManager.MissionDataManager;
    DataManager instance = DataManager.Instance;
    _ROLEINFO roleAttr = DataManager.Instance.RoleAttr;
    bool flag = true;
    if (((int) missionDataManager.MissionNotice >> 3 & 1) == 0)
      flag = false;
    if (missionDataManager.HaveEmptyBox())
    {
      this.TitleObject.SetActive(true);
      ((Component) this.TimeBar.transform).gameObject.SetActive(true);
      GUIManager.Instance.SetTimerBar(this.TimeBar.TimeBar, missionDataManager.VipRewardStartTime, missionDataManager.VipRewardStartTime + 3600L, 0L, eTimeBarType.UIMission, this.TimeBar.TimeBar.m_Titles[0], this.TimeBar.TimeBar.m_Titles[1]);
    }
    else
    {
      this.TitleObject.SetActive(false);
      ((Component) this.TimeBar.transform).gameObject.SetActive(false);
    }
    this.CompleteBarTrans.gameObject.SetActive(flag);
    if (missionDataManager.VipRewardStartTime + 3600L <= instance.ServerTime)
      this.SpeedupBtnObj.SetActive(false);
    else
      this.SpeedupBtnObj.SetActive(true);
    ((Component) this.TimeBar.TimeBar.m_TimeText).gameObject.SetActive(!flag);
    byte updateUiBox = missionDataManager.UpdateUIBox;
    this.OpenBoxIdx = byte.MaxValue;
    for (; updateUiBox > (byte) 0; updateUiBox >>= 1)
      ++this.OpenBoxIdx;
    this.PrictTrans.gameObject.SetActive(false);
    this.ResetTitleTrans.gameObject.SetActive(true);
    for (byte index = 0; (int) index < this.TreasureBox.Length - 1 && this.TreasureBox[(int) index] != null; ++index)
    {
      if (this.TreasureBox[(int) index].transform.gameObject.activeSelf)
      {
        if ((int) roleAttr.VIPLevel < (int) missionDataManager.VipLvRestrict[(int) index])
        {
          this.TreasureBox[(int) index].Light = false;
          ((Behaviour) this.RewardBtn[(int) index]).enabled = false;
          this.Restrict[(int) index].gameObject.SetActive(true);
        }
        else
        {
          this.TreasureBox[(int) index].Light = true;
          ((Behaviour) this.RewardBtn[(int) index]).enabled = true;
          this.Restrict[(int) index].gameObject.SetActive(false);
          this.TreasureBox[(int) index].StopAnimation();
          if ((int) this.OpenBoxIdx == (int) index)
          {
            this.PrictTrans.gameObject.SetActive(true);
            this.ResetTitleTrans.gameObject.SetActive(false);
            this.InitPrice();
            AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
            this.TreasureBox[(int) index].PlayAnimation("open", Mode: WrapMode.Once);
            this.TreasureBox[(int) index].SetNotifyTime(0.15f);
          }
          else if (missionDataManager.GetVipBoxState(index) == 1)
          {
            this.TreasureBox[(int) index].PlayAnimation("open", Mode: WrapMode.Once);
            this.TreasureBox[(int) index].GotoAnimLast();
          }
          else if (flag && this.CompleteBarTrans.gameObject.activeSelf)
            this.TreasureBox[(int) index].PlayAnimation("idle_02", UnityEngine.Random.value * 0.025f);
        }
      }
    }
    this.BoxEffectID = (int) DataManager.MissionDataManager.BoxEffectID - 1;
  }

  public void AnimNotify()
  {
    if (this.OpenBoxIdx == byte.MaxValue)
      return;
    if ((UnityEngine.Object) this.BoxEffect != (UnityEngine.Object) null && this.BoxEffect.activeSelf)
      this.BoxEffect.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
    if (this.BoxEffectID >= 0 && this.BoxEffectID <= 4)
    {
      this.BoxEffect = ParticleManager.Instance.Spawn((ushort) (373 + this.BoxEffectID), this.TreasureBox[(int) this.OpenBoxIdx].transform, new Vector3(1.1f, 1.35f, 2.28f), 0.5f, true);
      GUIManager.Instance.SetLayer(this.BoxEffect, 5);
    }
    this.RewardEffPos.Set((float) ((double) this.ScreenSize.x * 0.5 + 8.5) + this.TreasureBox[(int) this.OpenBoxIdx].transform.parent.localPosition.x, (float) (319.0 + 130.0 * (double) ((int) this.OpenBoxIdx / 3)), -80f);
    this.OpenBoxIdx = byte.MaxValue;
    AudioManager.Instance.PlayMP3SFX((ushort) 41011);
  }

  public void AnimnotifyEnd()
  {
    ushort[] vipRewardItem = DataManager.MissionDataManager.VipRewardItem;
    this.ThrowEffectCount = vipRewardItem.Length / 3 + Mathf.Clamp(vipRewardItem.Length % 3, 0, 1);
    if (this.ThrowEffectCount <= 0)
      return;
    this.ThrowEffectIdx = 0;
    this.ThrowRewardEffect(this.ThrowEffectIdx++);
    this.EffectTime = 0.0f;
  }

  private void ThrowRewardEffect(int index)
  {
    GUIManager instance = GUIManager.Instance;
    ushort[] vipRewardItem = DataManager.MissionDataManager.VipRewardItem;
    SpeciallyEffect_Kind[] vipRewardKind = DataManager.MissionDataManager.VipRewardKind;
    Array.Clear((Array) instance.SE_Kind, 0, instance.SE_Kind.Length);
    Array.Clear((Array) instance.SE_ItemID, 0, instance.SE_ItemID.Length);
    instance.m_SpeciallyEffect.mDiamondValue = 0U;
    for (int index1 = 0; index1 < instance.SE_ItemID.Length; ++index1)
    {
      int index2 = index * 3 + index1;
      if (index2 < vipRewardItem.Length)
      {
        if (vipRewardKind[index2] == SpeciallyEffect_Kind.Diamond)
        {
          instance.SE_ItemID[index1] = (ushort) 0;
          instance.m_SpeciallyEffect.mDiamondValue = DataManager.MissionDataManager.RewardVipDiamond;
        }
        else
          instance.SE_ItemID[index1] = vipRewardKind[index2] != SpeciallyEffect_Kind.AllianceMoney ? vipRewardItem[index2] : (ushort) 0;
        instance.SE_Kind[index1] = vipRewardKind[index2];
      }
      else
        break;
    }
    instance.m_SpeciallyEffect.AddIconShow((Vector2) this.RewardEffPos, instance.SE_Kind, instance.SE_ItemID, false);
  }

  public void Update()
  {
    for (int index = 0; index < this.TreasureBox.Length; ++index)
    {
      if (this.TreasureBox[index] != null)
        this.TreasureBox[index].Update();
    }
    if (this.ThrowEffectIdx >= this.ThrowEffectCount)
      return;
    if ((double) this.EffectTime >= (double) this.MaxEffectTime)
    {
      this.ThrowRewardEffect(this.ThrowEffectIdx++);
      this.EffectTime = 0.0f;
    }
    else
      this.EffectTime += this.TimdHandle.GetSmoothDeltaTime();
  }

  public void AddRefreshText(UIText text) => this.TitleText.Add(text);

  public void Destroy()
  {
    if (this.TreasureassetKey != 0)
      AssetManager.UnloadAssetBundle(this.TreasureassetKey);
    StringManager.Instance.DeSpawnString(this.ResetTimeStr);
    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer(GlobalProjectorManager.GlobalProjectorLayer));
    for (int index = 0; index < this.RestrictStr.Length; ++index)
      StringManager.Instance.DeSpawnString(this.RestrictStr[index]);
    if (!((UnityEngine.Object) this.BoxEffect != (UnityEngine.Object) null) || !this.BoxEffect.activeSelf)
      return;
    this.BoxEffect.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
    this.BoxEffect.transform.localPosition = new Vector3(0.0f, 0.0f, -50f);
  }

  public void TextRefresh()
  {
    for (int index = 0; index < this.TitleText.Count; ++index)
    {
      if (!((UnityEngine.Object) this.TitleText[index] == (UnityEngine.Object) null))
      {
        ((Behaviour) this.TitleText[index]).enabled = false;
        ((Behaviour) this.TitleText[index]).enabled = true;
      }
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (DataManager.MissionDataManager.GetVipBoxState((byte) sender.m_BtnID1) != 0 || ((int) DataManager.MissionDataManager.MissionNotice >> 3 & 1) <= 0)
      return;
    DataManager.MissionDataManager.sendReceiveVipBox((byte) sender.m_BtnID1);
  }

  public enum UIControl
  {
    Title,
    Timebar,
    Price,
    Box1,
    Box2,
    Box3,
    Box4,
    Box5,
    Box6,
    Box7,
    ResetTitle,
    Light,
  }

  private class _TreasureBox
  {
    public Transform transform;
    private SkinnedMeshRenderer Render;
    private Animation _Animation;
    private float DelayTime;
    private float DeltaTime;
    private float NormalizedTime;
    private string AnimationName;
    public iMissionAnimNotify NotifyHandle;
    private VIPMission._TreasureBox.eNotyfy NotifyFlag = VIPMission._TreasureBox.eNotyfy.All;
    private byte bStop;

    public _TreasureBox(Transform transform)
    {
      this.transform = transform;
      this._Animation = transform.GetComponent<Animation>();
      this._Animation.wrapMode = WrapMode.Loop;
      this._Animation.playAutomatically = false;
      this.Render = transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
      this.Render.useLightProbes = false;
    }

    public bool Light
    {
      set
      {
        if (!value)
        {
          if (this.transform.gameObject.layer == LayerMask.NameToLayer(GlobalProjectorManager.GlobalProjectorLayer))
            return;
          GUIManager.Instance.SetLayer(this.transform.gameObject, LayerMask.NameToLayer(GlobalProjectorManager.GlobalProjectorLayer));
        }
        else
        {
          if (this.transform.gameObject.layer == 5)
            return;
          GUIManager.Instance.SetLayer(this.transform.gameObject, 5);
        }
      }
    }

    public void PlayAnimation(string animation, float delay = 0.0f, WrapMode Mode = WrapMode.Loop)
    {
      this.AnimationName = animation;
      if ((double) delay == 0.0)
        this._Animation.Play(this.AnimationName);
      else
        this.DelayTime = delay;
      this.bStop = (byte) 0;
      this._Animation.wrapMode = Mode;
    }

    public void SetNotifyTime(float NormalizedTime)
    {
      this.NormalizedTime = NormalizedTime;
      this.NotifyFlag = VIPMission._TreasureBox.eNotyfy.None;
    }

    public void PlayAnimation()
    {
      this.bStop = (byte) 0;
      this.DeltaTime = 0.0f;
    }

    public bool IsPlaying()
    {
      return this.AnimationName != null && this._Animation.IsPlaying(this.AnimationName);
    }

    public void StopAnimation()
    {
      if (this.AnimationName == null)
        return;
      if (this._Animation.IsPlaying(this.AnimationName))
      {
        this._Animation[this.AnimationName].normalizedTime = 0.0f;
        this._Animation.Sample();
        this._Animation.Stop();
      }
      this.bStop = (byte) 1;
    }

    public void GotoAnimLast()
    {
      if (this.AnimationName == null || !this._Animation.IsPlaying(this.AnimationName))
        return;
      this._Animation[this.AnimationName].normalizedTime = this._Animation[this.AnimationName].length;
      this._Animation.Sample();
      this._Animation.Stop();
    }

    public void Update()
    {
      if (!this.transform.gameObject.activeSelf || this.bStop == (byte) 1 || this.AnimationName == null)
        return;
      if ((double) this.DelayTime > (double) this.DeltaTime)
        this.DeltaTime += Time.deltaTime;
      else if (this._Animation.wrapMode == WrapMode.Loop && !this._Animation.IsPlaying(this.AnimationName))
      {
        this._Animation.clip = this._Animation.GetClip(this.AnimationName);
        this._Animation.Play(this.AnimationName);
      }
      if (this.NotifyHandle == null || this.NotifyFlag == VIPMission._TreasureBox.eNotyfy.All)
        return;
      if ((this.NotifyFlag & VIPMission._TreasureBox.eNotyfy.AnimNotyfy) == VIPMission._TreasureBox.eNotyfy.None && (double) this._Animation[this.AnimationName].normalizedTime >= (double) this.NormalizedTime)
      {
        this.NotifyHandle.AnimNotify();
        this.NotifyFlag |= VIPMission._TreasureBox.eNotyfy.AnimNotyfy;
      }
      if ((this.NotifyFlag & VIPMission._TreasureBox.eNotyfy.AnimEnd) != VIPMission._TreasureBox.eNotyfy.None || this._Animation.IsPlaying(this.AnimationName))
        return;
      this.NotifyHandle.AnimnotifyEnd();
      this.NotifyFlag |= VIPMission._TreasureBox.eNotyfy.AnimEnd;
    }

    private enum eNotyfy : byte
    {
      None,
      AnimNotyfy,
      AnimEnd,
      All,
    }
  }
}
