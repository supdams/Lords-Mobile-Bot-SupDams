// Decompiled with JetBrains decompiler
// Type: UIAlchemy
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAlchemy : GUIWindow, UILoadImageHander, IUIButtonClickHandler, IUIButtonDownUpHandler
{
  private const byte ActorMax = 3;
  public Transform m_transform;
  public Transform tFront1;
  public Transform tFront2;
  public Transform tTimeObj;
  private Transform[] ActorT = new Transform[3];
  public Transform[] WPT = new Transform[3];
  private GameObject[] EffectObj = new GameObject[3];
  private GameObject EffectObj1;
  private GameObject EffectObj2;
  private GameObject EffectObj3;
  private DataManager DM;
  private GUIManager GM;
  private Font tmpFont;
  private Door m_door;
  private int IngEffectIndex = -1;
  private byte tFState;
  private byte NowIndex;
  private float CheckTime;
  private int ScaleRate = 800;
  private int AssetKey;
  private GameObject[] BoxGO = new GameObject[3];
  private AssetBundle AB;
  private AssetBundleRequest AR;
  private bool bABInitial;
  private Animation[] tmpAN = new Animation[3];
  private BoxUnitComp[] Box = new BoxUnitComp[3];
  private List<UIText> AllText = new List<UIText>();
  private UIText DontHaveText;
  private UIText Front_TitleText;
  private UIText Front_CheckText;
  private UIText Front_TotalTimeText;
  private UIText Front_OpenTimeText;
  private UIText Front_MessageText;
  private UIText Front_ItemNameText;
  private UIText Front_ItemCountText;
  private UIText CountTimeText;
  private UIButton Front_HINTBtn;
  private CString Front_ItemCountStr;
  private CString CountTimeStr;
  private byte Open_Close;
  private int WaitIndex = -1;
  private float CloseTime;
  private float WaitTime;
  private float WaitPlaySFX = -1f;
  private float ClosePreTime = 0.55f;

  private Door door
  {
    get
    {
      if ((Object) this.m_door == (Object) null)
        this.m_door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      return this.m_door;
    }
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.m_transform = this.transform;
    this.tmpFont = this.GM.GetTTFFont();
    UIText component1 = this.m_transform.GetChild(5).GetComponent<UIText>();
    component1.font = this.tmpFont;
    component1.text = this.DM.mStringTable.GetStringByID(12027U);
    this.AllText.Add(component1);
    this.DontHaveText = this.m_transform.GetChild(6).GetComponent<UIText>();
    this.DontHaveText.font = this.tmpFont;
    this.DontHaveText.text = this.DM.mStringTable.GetStringByID(12030U);
    this.AllText.Add(this.DontHaveText);
    this.m_transform.GetChild(7).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(7).gameObject.AddComponent<ArabicItemTextureRot>();
    this.m_transform.GetChild(8).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(8).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(8).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) this.m_transform.GetChild(8).GetComponent<CustomImage>()).enabled = false;
    this.tFront1 = this.m_transform.GetChild(9);
    for (int index = 0; index < 3; ++index)
    {
      this.Box[index].PressImage = this.tFront1.GetChild(index).GetComponent<Image>();
      this.Box[index].PressImageSA = this.tFront1.GetChild(index).GetComponent<UISpritesArray>();
      this.Box[index].ClockImage = this.tFront1.GetChild(index + 3).GetComponent<Image>();
      this.Box[index].Clock2Image = this.tFront1.GetChild(index + 6).GetComponent<Image>();
      this.Box[index].BtnTopText = this.tFront1.GetChild(index + 9).GetComponent<UIText>();
      this.Box[index].BtnTopText.font = this.tmpFont;
      this.AllText.Add(this.Box[index].BtnTopText);
      this.Box[index].TotalTimeText = this.tFront1.GetChild(index + 12).GetComponent<UIText>();
      this.Box[index].TotalTimeText.font = this.tmpFont;
      this.AllText.Add(this.Box[index].TotalTimeText);
      this.Box[index].OpenTimeText = this.tFront1.GetChild(index + 15).GetComponent<UIText>();
      this.Box[index].OpenTimeText.font = this.tmpFont;
      this.AllText.Add(this.Box[index].OpenTimeText);
      this.Box[index].TimeStr = StringManager.Instance.SpawnString(15);
    }
    this.tFront1.GetChild(18).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.tFront1.GetChild(19).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.tFront1.GetChild(20).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.tFront1.GetChild(21).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.tFront1.GetChild(22).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.tFront1.GetChild(23).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    for (int index = 0; index < 3; ++index)
    {
      this.Box[index].HintButton = this.tFront1.GetChild(24 + index).GetComponent<UIButton>();
      this.Box[index].HintButton.m_Handler = (IUIButtonClickHandler) this;
      UIButtonHint uiButtonHint = ((Component) this.Box[index].HintButton).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint.Parm1 = (ushort) 12026;
      uiButtonHint.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    }
    this.tFront2 = this.m_transform.GetChild(10);
    HelperUIButton helperUiButton = this.tFront2.gameObject.AddComponent<HelperUIButton>();
    helperUiButton.m_Handler = (IUIButtonClickHandler) this;
    helperUiButton.m_BtnID1 = 2;
    helperUiButton.m_BtnID2 = 1;
    this.Front_TitleText = this.tFront2.GetChild(4).GetComponent<UIText>();
    this.Front_TitleText.font = this.tmpFont;
    this.AllText.Add(this.Front_TitleText);
    this.Front_CheckText = this.tFront2.GetChild(8).GetChild(0).GetComponent<UIText>();
    this.Front_CheckText.font = this.tmpFont;
    this.AllText.Add(component1);
    this.Front_TotalTimeText = this.tFront2.GetChild(10).GetComponent<UIText>();
    this.Front_TotalTimeText.font = this.tmpFont;
    this.Front_TotalTimeText.alignment = TextAnchor.MiddleCenter;
    this.AllText.Add(this.Front_TotalTimeText);
    this.Front_OpenTimeText = this.tFront2.GetChild(12).GetComponent<UIText>();
    this.Front_OpenTimeText.font = this.tmpFont;
    this.AllText.Add(this.Front_OpenTimeText);
    this.Front_MessageText = this.tFront2.GetChild(13).GetComponent<UIText>();
    this.Front_MessageText.font = this.tmpFont;
    this.Front_MessageText.text = this.DM.mStringTable.GetStringByID(12032U);
    this.AllText.Add(this.Front_MessageText);
    this.Front_ItemNameText = this.tFront2.GetChild(17).GetComponent<UIText>();
    this.Front_ItemNameText.font = this.tmpFont;
    this.AllText.Add(this.Front_ItemNameText);
    this.Front_ItemCountText = this.tFront2.GetChild(18).GetComponent<UIText>();
    this.Front_ItemCountText.font = this.tmpFont;
    this.AllText.Add(this.Front_ItemCountText);
    this.tFront2.GetChild(5).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.tFront2.GetChild(5).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.tFront2.GetChild(7).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.tFront2.GetChild(8).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.GM.InitianHeroItemImg(this.tFront2.GetChild(16), eHeroOrItem.Item, (ushort) 10, (byte) 0, (byte) 0);
    this.Front_ItemCountStr = StringManager.Instance.SpawnString(150);
    this.Front_HINTBtn = this.tFront2.GetChild(19).GetComponent<UIButton>();
    this.Front_HINTBtn.m_Handler = (IUIButtonClickHandler) this;
    this.Front_HINTBtn.m_BtnID2 = 2;
    UIButtonHint uiButtonHint1 = ((Component) this.Front_HINTBtn).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.Parm1 = (ushort) 12026;
    uiButtonHint1.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    this.tTimeObj = this.m_transform.GetChild(11);
    this.tTimeObj.GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.tTimeObj.GetChild(0).GetComponent<UIButton>().transition = (Selectable.Transition) 0;
    UIButtonHint uiButtonHint2 = this.tTimeObj.GetChild(0).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint2.Parm1 = (ushort) 12048;
    uiButtonHint2.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    UIText component2 = this.tTimeObj.GetChild(2).GetComponent<UIText>();
    component2.font = this.tmpFont;
    component2.text = this.DM.mStringTable.GetStringByID(8110U);
    this.AllText.Add(component2);
    this.CountTimeText = this.tTimeObj.GetChild(3).GetComponent<UIText>();
    this.CountTimeText.font = this.tmpFont;
    this.AllText.Add(this.CountTimeText);
    this.CountTimeStr = StringManager.Instance.SpawnString();
    this.ActorT[0] = this.m_transform.GetChild(15);
    this.ActorT[1] = this.m_transform.GetChild(16);
    this.ActorT[2] = this.m_transform.GetChild(17);
    this.AB = AssetManager.GetAssetBundle("Role/darkbox", out this.AssetKey);
    if ((Object) this.AB != (Object) null)
      this.AR = this.AB.LoadAsync("m", typeof (GameObject));
    if (this.GM.bOpenOnIPhoneX)
    {
      ((RectTransform) this.tFront2).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.tFront2).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0.0f);
    }
    ((Transform) this.tFront2.GetComponent<RectTransform>()).localPosition = Vector3.zero;
    this.tFront2.SetParent((Transform) this.GM.m_SecWindowLayer, false);
    this.CheckHaveText();
    this.SetTimeText();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    this.tFront2.SetParent(this.m_transform);
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.EffectObj[index] != (Object) null)
      {
        ParticleManager.Instance.DeSpawn(this.EffectObj[index]);
        this.EffectObj[index] = (GameObject) null;
      }
      if (this.Box[index].TimeStr != null)
        StringManager.Instance.DeSpawnString(this.Box[index].TimeStr);
      if ((Object) this.BoxGO[index] == (Object) null)
      {
        Object.Destroy((Object) this.BoxGO[index]);
        this.BoxGO[index] = (GameObject) null;
      }
    }
    if ((Object) this.EffectObj3 != (Object) null && this.EffectObj3.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
      this.EffectObj3.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
    if ((Object) this.EffectObj2 != (Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.EffectObj2);
      this.EffectObj2 = (GameObject) null;
    }
    if ((Object) this.EffectObj1 != (Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.EffectObj1);
      this.EffectObj1 = (GameObject) null;
    }
    if (this.Front_ItemCountStr != null)
      StringManager.Instance.DeSpawnString(this.Front_ItemCountStr);
    if (this.CountTimeStr != null)
      StringManager.Instance.DeSpawnString(this.CountTimeStr);
    if (this.AssetKey == 0)
      return;
    AssetManager.UnloadAssetBundle(this.AssetKey);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.tFront2.GetChild(6).gameObject.SetActive(true);
        if (this.tFront2.gameObject.activeInHierarchy && !NewbieManager.IsWorking())
        {
          this.NowIndex = (byte) 0;
          this.tFState = (byte) 0;
          this.tFront2.gameObject.SetActive(false);
        }
        this.SetTimeText();
        break;
      case NetworkNews.Fallout:
        this.tFront2.GetChild(6).gameObject.SetActive(false);
        break;
      case NetworkNews.Refresh_AttribEffectVal:
        this.ReSetTotalTime();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        if (this.AllText == null)
          break;
        for (int index = 0; index < this.AllText.Count; ++index)
        {
          if ((Object) this.AllText[index] != (Object) null && ((Behaviour) this.AllText[index]).enabled)
          {
            ((Behaviour) this.AllText[index]).enabled = false;
            ((Behaviour) this.AllText[index]).enabled = true;
          }
        }
        break;
    }
  }

  private void Update()
  {
    if (!this.bABInitial && this.AR != null && this.AR.isDone)
    {
      for (int Index = 0; Index < 3; ++Index)
      {
        if ((Object) this.BoxGO[Index] == (Object) null)
        {
          if (Index == 2)
            this.bABInitial = true;
          this.BoxGO[Index] = (GameObject) Object.Instantiate(this.AR.asset);
          this.BoxGO[Index].transform.SetParent(this.ActorT[Index], false);
          this.BoxGO[Index].transform.localPosition = Vector3.zero;
          this.BoxGO[Index].transform.localRotation = new Quaternion(0.0f, -180f, 0.0f, 0.0f);
          this.BoxGO[Index].transform.localScale = new Vector3((float) this.ScaleRate, (float) this.ScaleRate, (float) this.ScaleRate);
          GUIManager.Instance.SetLayer(this.BoxGO[Index], 5);
          this.WPT[Index] = this.BoxGO[Index].transform.GetChild(0).GetChild(1);
          if ((Object) this.BoxGO[Index] != (Object) null)
          {
            this.tmpAN[Index] = this.BoxGO[Index].GetComponent<Animation>();
            this.tmpAN[Index].wrapMode = WrapMode.Loop;
            this.tmpAN[Index].cullingType = AnimationCullingType.AlwaysAnimate;
            this.tmpAN[Index]["idle"].layer = 0;
            this.tmpAN[Index]["close_idle"].layer = 0;
            this.tmpAN[Index]["close_open"].layer = 0;
            this.tmpAN[Index]["close"].layer = 1;
            this.tmpAN[Index]["close"].wrapMode = WrapMode.Default;
            this.tmpAN[Index].Stop();
            this.tmpAN[Index]["idle"].time = Random.Range(0.0f, this.tmpAN[Index]["idle"].length);
            this.tmpAN[Index].clip = this.tmpAN[Index].GetClip("idle");
            if (this.GM.BoxID[Index] > (ushort) 0 && this.GM.BoxTime[Index] > 0L)
            {
              if (this.GM.BoxTime[Index] > this.DM.ServerTime)
                this.tmpAN[Index].Play("close_open");
              else
                this.tmpAN[Index].Play("close_idle");
            }
            else
              this.tmpAN[Index].Play("idle");
            SkinnedMeshRenderer componentInChildren = this.BoxGO[Index].GetComponentInChildren<SkinnedMeshRenderer>();
            if ((Object) componentInChildren != (Object) null)
            {
              componentInChildren.useLightProbes = false;
              componentInChildren.updateWhenOffscreen = true;
            }
            this.CloseTime = this.tmpAN[Index]["close"].length;
          }
          this.ReSetState(Index);
          return;
        }
      }
    }
    if (!this.bABInitial)
      return;
    this.CheckTime -= Time.unscaledDeltaTime;
    if ((double) this.CheckTime <= 0.0)
    {
      this.CheckTime = 1f;
      for (int Index = 0; Index < 3; ++Index)
      {
        if ((Object) this.BoxGO[Index] != (Object) null && this.GM.BoxID[Index] != (ushort) 0 && this.GM.BoxTime[Index] > this.DM.ServerTime)
        {
          this.Box[Index].TimeStr.Length = 0;
          GameConstants.GetTimeString(this.Box[Index].TimeStr, (uint) (this.GM.BoxTime[Index] - this.DM.ServerTime), hideTimeIfDays: true, showZeroHour: false);
          this.Box[Index].OpenTimeText.text = this.Box[Index].TimeStr.ToString();
          this.Box[Index].OpenTimeText.SetAllDirty();
          this.Box[Index].OpenTimeText.cachedTextGenerator.Invalidate();
          if ((int) this.NowIndex == Index + 1)
          {
            this.Front_OpenTimeText.text = this.Box[Index].TimeStr.ToString();
            this.Front_OpenTimeText.SetAllDirty();
            this.Front_OpenTimeText.cachedTextGenerator.Invalidate();
          }
        }
        if ((Object) this.BoxGO[Index] != (Object) null && this.GM.BoxID[Index] != (ushort) 0 && this.GM.BoxTime[Index] > 0L && this.GM.BoxTime[Index] < this.DM.ServerTime && ((Component) this.Box[Index].OpenTimeText).gameObject.activeInHierarchy)
          this.ReSetState(Index);
      }
    }
    if (this.Open_Close == (byte) 0)
      return;
    this.WaitTime -= Time.unscaledDeltaTime;
    if ((double) this.WaitTime < 0.0)
    {
      if (this.Open_Close == (byte) 1)
      {
        Vector2 vector2 = ((Component) this.GM.m_UICanvas).gameObject.GetComponent<RectTransform>().sizeDelta;
        vector2 = new Vector2(vector2.x / 2f, (float) ((double) vector2.y / 2.0 + 50.0));
        Vector2 mV2 = Vector2.zero;
        if (this.WaitIndex == 0)
          mV2 = new Vector2(vector2.x - 265f, vector2.y);
        else if (this.WaitIndex == 1)
          mV2 = new Vector2(vector2.x, vector2.y);
        else if (this.WaitIndex == 2)
          mV2 = new Vector2(vector2.x + 265f, vector2.y);
        if (this.GM.BoxRewardCrystal > 0U)
        {
          this.GM.m_SpeciallyEffect.mDiamondValue = this.GM.BoxRewardCrystal;
          this.GM.m_SpeciallyEffect.AddIconShow(false, mV2, SpeciallyEffect_Kind.Diamond, ItemID: (ushort) 0, EndTime: 2f);
        }
        else if (this.GM.BoxRewardAlliance > 0U)
          this.GM.m_SpeciallyEffect.AddIconShow(false, mV2, SpeciallyEffect_Kind.AllianceMoney, ItemID: (ushort) 0, EndTime: 2f);
        else
          GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, mV2, SpeciallyEffect_Kind.Item, ItemID: this.GM.BoxRewardItemID, EndTime: 2f);
        this.ReSerAll(this.WaitIndex);
        this.WaitIndex = -1;
        this.Open_Close = (byte) 3;
        this.WaitTime = 1f;
      }
      else if (this.Open_Close == (byte) 3)
      {
        this.Open_Close = (byte) 0;
        this.OpenFront2_Get();
      }
      else if (this.Open_Close == (byte) 2)
      {
        AudioManager.Instance.PlayUISFX(UIKind.Laboratory_Start);
        this.WaitTime = this.CloseTime - this.ClosePreTime;
        this.Open_Close = (byte) 4;
      }
      else if (this.Open_Close == (byte) 4)
      {
        this.ReSerAll(this.WaitIndex);
        this.WaitIndex = -1;
        this.Open_Close = (byte) 0;
      }
    }
    if ((double) this.WaitPlaySFX <= 0.0)
      return;
    this.WaitPlaySFX -= Time.unscaledDeltaTime;
    if ((double) this.WaitPlaySFX > 0.0)
      return;
    this.WaitPlaySFX = -1f;
    AudioManager.Instance.PlaySFX((ushort) 903);
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!bOnSecond)
      return;
    this.SetTimeText();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.ReSetAll();
        break;
      case 2:
        this.Open_Close = (byte) 2;
        this.WaitIndex = arg2;
        this.WaitTime = this.ClosePreTime;
        this.tmpAN[arg2]["close"].time = 0.0f;
        this.tmpAN[arg2]["close"].speed = 1f;
        this.tmpAN[arg2].CrossFade("close");
        this.tmpAN[arg2].CrossFade("close_idle");
        break;
      case 3:
        this.Open_Close = (byte) 1;
        this.WaitIndex = arg2;
        this.WaitTime = this.CloseTime;
        this.LoadEffect(arg2, this.GM.BoxRewardID);
        this.LoadGetEffect(arg2);
        AudioManager.Instance.PlayUISFX(UIKind.Laboratory_Open);
        this.WaitPlaySFX = 0.358f;
        this.tmpAN[arg2]["close"].time = this.tmpAN[arg2]["close"].length;
        this.tmpAN[arg2]["close"].speed = -1f;
        this.tmpAN[arg2].CrossFade("close");
        this.tmpAN[arg2].CrossFade("idle");
        break;
      case 4:
        this.ReSetState(arg2);
        break;
      case 5:
        this.ReSetState(arg2);
        break;
      case 6:
        if (!this.tFront2.gameObject.activeInHierarchy || (int) this.NowIndex - 1 != arg2)
          break;
        this.tFState = (byte) 0;
        this.NowIndex = (byte) 0;
        this.tFront2.gameObject.SetActive(false);
        break;
      case 7:
        this.SetTimeText();
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      if (sender.m_BtnID2 == 1)
      {
        if (!(bool) (Object) this.door)
          return;
        this.door.CloseMenu();
      }
      else
      {
        if (sender.m_BtnID2 != 2)
          return;
        this.GM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(12044U), this.DM.mStringTable.GetStringByID(12039U), bInfo: true, BackExit: true);
      }
    }
    else if (sender.m_BtnID1 == 2)
    {
      if (sender.m_BtnID2 == 1)
      {
        this.tFState = (byte) 0;
        this.tFront2.gameObject.SetActive(false);
      }
      else if (sender.m_BtnID2 == 2)
      {
        if ((int) this.NowIndex - 1 < 3)
        {
          this.GM.MsgStr.Length = 0;
          this.GM.MsgStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[(int) this.NowIndex - 1]).Element));
          this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(12037U));
          this.GM.OpenSpendWindow_Normal((GUIWindow) this, this.DM.mStringTable.GetStringByID(12036U), this.GM.MsgStr.ToString(), (int) this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[(int) this.NowIndex - 1]).Coin, arg2: (int) this.NowIndex, Buttontext: this.DM.mStringTable.GetStringByID(12040U), bGold: true);
          this.NowIndex = (byte) 0;
        }
        this.tFront2.gameObject.SetActive(false);
      }
      else
      {
        if (sender.m_BtnID2 != 3)
          return;
        if (this.tFState == (byte) 1)
        {
          this.tFState = (byte) 0;
          this.GM.Send_NPC_START_REWARD(this.NowIndex);
          this.NowIndex = (byte) 0;
        }
        this.tFront2.gameObject.SetActive(false);
      }
    }
    else
    {
      if (sender.m_BtnID1 != 3 || this.Open_Close != (byte) 0)
        return;
      this.OpenFront2(sender.m_BtnID2 - 1);
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 0:
        if (this.DM.Resource[4].Stock >= (uint) this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[arg2 - 1]).Coin)
        {
          this.GM.Send_NPC_DELETE_REWARD((byte) arg2);
          break;
        }
        this.GM.MsgStr.Length = 0;
        this.GM.MsgStr.StringToFormat(this.DM.mStringTable.GetStringByID(6012U));
        this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(1546U));
        this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(5721U), this.GM.MsgStr.ToString(), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 1, bCloseIDSet: true);
        break;
      case 1:
        int num = 1;
        if (!((Object) this.door != (Object) null))
          break;
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, num + 262144);
        break;
    }
  }

  private int bTransIng()
  {
    for (int index = 0; index < 3; ++index)
    {
      if (this.GM.BoxTime[index] != 0L)
        return index;
    }
    return -1;
  }

  private void CheckHaveText()
  {
    bool flag = false;
    for (int index = 0; index < 3; ++index)
    {
      if (this.GM.BoxID[index] != (ushort) 0)
      {
        flag = true;
        break;
      }
    }
    ((Component) this.DontHaveText).gameObject.SetActive(!flag);
  }

  private void LoadEffect(int Index, ushort BoxID = 0)
  {
    if (Index < 0 || Index >= 3)
      return;
    if ((Object) this.EffectObj[Index] != (Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.EffectObj[Index]);
      this.EffectObj[Index] = (GameObject) null;
    }
    this.EffectObj[Index] = BoxID == (ushort) 0 ? ParticleManager.Instance.Spawn((ushort) (400 + (int) this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[Index]).PicNo - 60000), this.WPT[Index], Vector3.zero, 1.4f, true) : ParticleManager.Instance.Spawn((ushort) (400 + (int) this.DM.NPCPrize.GetRecordByKey(BoxID).PicNo - 60000), this.WPT[Index], Vector3.zero, 1.4f, true);
    if (!((Object) this.EffectObj[Index] != (Object) null))
      return;
    this.GM.SetLayer(this.EffectObj[Index], 5);
    this.EffectObj[Index].transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    this.EffectObj[Index].transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
  }

  private void LoadFrontEffect(int Index)
  {
    if (Index < 0 || Index >= 3)
      return;
    if ((Object) this.EffectObj2 != (Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.EffectObj2);
      this.EffectObj2 = (GameObject) null;
    }
    this.EffectObj2 = ParticleManager.Instance.Spawn((ushort) (400 + (int) this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[Index]).PicNo - 60000), this.tFront2.GetChild(6), Vector3.zero, 1.4f, true);
    if (!((Object) this.EffectObj2 != (Object) null))
      return;
    this.GM.SetLayer(this.EffectObj2, 5);
    this.EffectObj2.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    this.EffectObj2.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
  }

  private void LoadGetEffect(int Index)
  {
    if (Index < 0 || Index >= 3)
      return;
    this.EffectObj3 = ParticleManager.Instance.Spawn((ushort) 406, this.ActorT[Index], Vector3.zero, 1f, true);
    if (!((Object) this.EffectObj3 != (Object) null))
      return;
    this.GM.SetLayer(this.EffectObj3, 5);
    this.EffectObj3.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    this.EffectObj3.transform.localPosition = new Vector3(0.0f, 185f, -170f);
  }

  private void LoadIngEffect(int Index)
  {
    if (Index < 0 || Index >= 3)
      return;
    this.IngEffectIndex = Index;
    this.EffectObj1 = ParticleManager.Instance.Spawn((ushort) 6, this.ActorT[Index], Vector3.zero, 0.4f, true);
    if (!((Object) this.EffectObj1 != (Object) null))
      return;
    this.GM.SetLayer(this.EffectObj1, 5);
    this.EffectObj1.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    this.EffectObj1.transform.localPosition = new Vector3(-1f, 148f, -96f);
  }

  private void DeSpawnIngEffect(int Index)
  {
    if (Index != this.IngEffectIndex || !((Object) this.EffectObj1 != (Object) null))
      return;
    this.IngEffectIndex = -1;
    ParticleManager.Instance.DeSpawn(this.EffectObj1);
    this.EffectObj1 = (GameObject) null;
  }

  private void OpenFront2_Get()
  {
    for (int index = 6; index <= 18; ++index)
      this.tFront2.GetChild(index).gameObject.SetActive(false);
    this.Front_TitleText.text = this.DM.mStringTable.GetStringByID((uint) this.DM.NPCPrize.GetRecordByKey(this.GM.BoxRewardID).Element);
    this.Front_CheckText.text = this.DM.mStringTable.GetStringByID(3U);
    Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.GM.BoxRewardItemID);
    if ((int) recordByKey.EquipKey == (int) this.GM.BoxRewardItemID)
    {
      this.GM.ChangeHeroItemImg(this.tFront2.GetChild(16), eHeroOrItem.Item, this.GM.BoxRewardItemID, this.GM.BoxRewardItemRank, (byte) 0);
      this.Front_ItemNameText.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.EquipName);
      this.tFront2.GetChild(16).gameObject.SetActive(true);
      this.tFront2.GetChild(17).gameObject.SetActive(true);
    }
    this.Front_ItemCountStr.Length = 0;
    this.Front_ItemCountStr.IntToFormat((long) this.GM.BoxRewardNum);
    this.Front_ItemCountStr.AppendFormat(this.DM.mStringTable.GetStringByID(7676U));
    this.Front_ItemCountText.text = this.Front_ItemCountStr.ToString();
    this.Front_ItemCountText.SetAllDirty();
    this.Front_ItemCountText.cachedTextGenerator.Invalidate();
    this.tFront2.GetChild(8).gameObject.SetActive(true);
    this.tFront2.GetChild(14).gameObject.SetActive(true);
    this.tFront2.GetChild(15).gameObject.SetActive(true);
    this.tFront2.GetChild(18).gameObject.SetActive(true);
    this.tFront2.gameObject.SetActive(true);
  }

  public void OpenFront2(int Index)
  {
    if (Index >= 3 || !((Object) this.BoxGO[Index] != (Object) null))
      return;
    if (this.GM.BoxID[Index] != (ushort) 0)
    {
      this.NowIndex = (byte) (Index + 1);
      for (int index = 6; index <= 18; ++index)
        this.tFront2.GetChild(index).gameObject.SetActive(false);
      if (this.GM.BoxTime[Index] != 0L)
      {
        if (this.GM.BoxTime[Index] > this.DM.ServerTime)
        {
          this.tFront2.GetChild(6).gameObject.SetActive(true);
          this.tFront2.GetChild(7).gameObject.SetActive(true);
          this.tFront2.GetChild(8).gameObject.SetActive(true);
          this.tFront2.GetChild(11).gameObject.SetActive(true);
          this.tFront2.GetChild(12).gameObject.SetActive(true);
          this.tFront2.GetChild(19).gameObject.SetActive(true);
          this.tFront2.GetChild(19).gameObject.GetComponent<UIButtonHint>().Parm1 = (ushort) 12028;
          this.Front_TitleText.text = this.DM.mStringTable.GetStringByID((uint) this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[Index]).Element);
          this.Front_CheckText.text = this.DM.mStringTable.GetStringByID(3U);
          this.Front_OpenTimeText.text = this.Box[Index].TimeStr.ToString();
          this.Front_OpenTimeText.SetAllDirty();
          this.Front_OpenTimeText.cachedTextGenerator.Invalidate();
          this.LoadFrontEffect(Index);
        }
        else
        {
          this.GM.Send_NPC_GET_REWARD(this.NowIndex);
          this.NowIndex = (byte) 0;
          return;
        }
      }
      else
      {
        int index = this.bTransIng();
        if (index == -1)
        {
          this.tFront2.GetChild(6).gameObject.SetActive(true);
          this.tFront2.GetChild(7).gameObject.SetActive(true);
          this.tFront2.GetChild(8).gameObject.SetActive(true);
          this.tFront2.GetChild(9).gameObject.SetActive(true);
          this.tFront2.GetChild(10).gameObject.SetActive(true);
          this.tFront2.GetChild(19).gameObject.SetActive(true);
          this.tFront2.GetChild(19).gameObject.GetComponent<UIButtonHint>().Parm1 = (ushort) 12026;
          this.Front_TitleText.text = this.DM.mStringTable.GetStringByID((uint) this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[Index]).Element);
          this.Front_CheckText.text = this.DM.mStringTable.GetStringByID(12031U);
          this.Front_TotalTimeText.text = this.Box[Index].TimeStr.ToString();
          this.Front_TotalTimeText.SetAllDirty();
          this.Front_TotalTimeText.cachedTextGenerator.Invalidate();
          Image component = this.tFront2.GetChild(9).GetComponent<Image>();
          ((Graphic) component).rectTransform.anchoredPosition = new Vector2((float) ((double) ((Graphic) this.Front_TotalTimeText).rectTransform.anchoredPosition.x - (double) this.Front_TotalTimeText.preferredWidth / 2.0 - 18.0), ((Graphic) component).rectTransform.anchoredPosition.y);
          this.tFState = (byte) 1;
          this.LoadFrontEffect(Index);
        }
        else
        {
          this.Front_TitleText.text = this.DM.mStringTable.GetStringByID((uint) this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[Index]).Element);
          this.tFront2.GetChild(6).gameObject.SetActive(true);
          this.tFront2.GetChild(7).gameObject.SetActive(true);
          this.tFront2.GetChild(8).gameObject.SetActive(true);
          this.tFront2.GetChild(13).gameObject.SetActive(true);
          this.Front_MessageText.text = this.GM.BoxTime[index] > this.DM.ServerTime ? this.DM.mStringTable.GetStringByID(12032U) : this.DM.mStringTable.GetStringByID(12038U);
          this.Front_CheckText.text = this.DM.mStringTable.GetStringByID(3U);
          this.LoadFrontEffect(Index);
        }
      }
      this.tFront2.gameObject.SetActive(true);
    }
    else
      this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12030U), (ushort) byte.MaxValue);
  }

  private void ReSetState(int Index, bool bUpDateEffect = true)
  {
    if (Index >= 3 || !((Object) this.BoxGO[Index] != (Object) null))
      return;
    ((Component) this.Box[Index].PressImage).gameObject.SetActive(false);
    ((Component) this.Box[Index].ClockImage).gameObject.SetActive(false);
    ((Component) this.Box[Index].Clock2Image).gameObject.SetActive(false);
    ((Component) this.Box[Index].BtnTopText).gameObject.SetActive(false);
    ((Component) this.Box[Index].TotalTimeText).gameObject.SetActive(false);
    ((Component) this.Box[Index].OpenTimeText).gameObject.SetActive(false);
    ((Component) this.Box[Index].HintButton).gameObject.SetActive(false);
    if (this.GM.BoxID[Index] != (ushort) 0 && this.GM.BoxTime[Index] != 0L)
    {
      if (this.GM.BoxTime[Index] > this.DM.ServerTime)
      {
        this.tmpAN[Index].clip = this.tmpAN[Index].GetClip("close_idle");
        this.tmpAN[Index].CrossFade("close_idle");
        ((Component) this.Box[Index].Clock2Image).gameObject.SetActive(true);
        ((Component) this.Box[Index].OpenTimeText).gameObject.SetActive(true);
        ((Component) this.Box[Index].HintButton).gameObject.SetActive(true);
        ((Component) this.Box[Index].HintButton).gameObject.GetComponent<UIButtonHint>().Parm1 = (ushort) 12028;
        this.Box[Index].TimeStr.Length = 0;
        GameConstants.GetTimeString(this.Box[Index].TimeStr, (uint) (this.GM.BoxTime[Index] - this.DM.ServerTime), hideTimeIfDays: true, showZeroHour: false);
        this.Box[Index].OpenTimeText.text = this.Box[Index].TimeStr.ToString();
        this.Box[Index].OpenTimeText.SetAllDirty();
        this.Box[Index].OpenTimeText.cachedTextGenerator.Invalidate();
        this.LoadIngEffect(Index);
      }
      else
      {
        this.DeSpawnIngEffect(Index);
        this.tmpAN[Index].clip = this.tmpAN[Index].GetClip("close_idle");
        this.tmpAN[Index].CrossFade("close_open");
        this.Box[Index].PressImageSA.SetSpriteIndex(1);
        ((Component) this.Box[Index].PressImage).gameObject.SetActive(true);
        this.Box[Index].BtnTopText.text = this.DM.mStringTable.GetStringByID(1520U);
        ((Component) this.Box[Index].BtnTopText).gameObject.SetActive(true);
      }
    }
    else
    {
      this.DeSpawnIngEffect(Index);
      this.tmpAN[Index].clip = this.tmpAN[Index].GetClip("idle");
      this.tmpAN[Index].CrossFade("idle");
      if (this.GM.BoxID[Index] != (ushort) 0)
      {
        if (this.bTransIng() == -1)
        {
          this.Box[Index].PressImageSA.SetSpriteIndex(0);
          ((Component) this.Box[Index].PressImage).gameObject.SetActive(true);
          this.Box[Index].BtnTopText.text = this.DM.mStringTable.GetStringByID(12029U);
          ((Component) this.Box[Index].BtnTopText).gameObject.SetActive(true);
        }
        ((Component) this.Box[Index].ClockImage).gameObject.SetActive(true);
        ((Component) this.Box[Index].TotalTimeText).gameObject.SetActive(true);
        ((Component) this.Box[Index].HintButton).gameObject.SetActive(true);
        ((Component) this.Box[Index].HintButton).gameObject.GetComponent<UIButtonHint>().Parm1 = (ushort) 12026;
        this.Box[Index].TimeStr.Length = 0;
        GameConstants.GetTimeInfoString(this.Box[Index].TimeStr, this.GM.GetRequireTime(this.GM.BoxRequire[Index]));
        this.Box[Index].TotalTimeText.text = this.Box[Index].TimeStr.ToString();
        this.Box[Index].TotalTimeText.SetAllDirty();
        this.Box[Index].TotalTimeText.cachedTextGenerator.Invalidate();
        ((Graphic) this.Box[Index].ClockImage).rectTransform.anchoredPosition = new Vector2((float) ((double) ((Graphic) this.Box[Index].TotalTimeText).rectTransform.anchoredPosition.x - (double) this.Box[Index].TotalTimeText.preferredWidth / 2.0 - 18.0), ((Graphic) this.Box[Index].ClockImage).rectTransform.anchoredPosition.y);
        if (bUpDateEffect)
          this.LoadEffect(Index, (ushort) 0);
      }
      else if ((Object) this.EffectObj[Index] != (Object) null)
      {
        ParticleManager.Instance.DeSpawn(this.EffectObj[Index]);
        this.EffectObj[Index] = (GameObject) null;
      }
    }
    this.CheckHaveText();
  }

  private void ReSetTotalTime()
  {
    if (!this.bABInitial)
      return;
    for (int index = 0; index < 3; ++index)
    {
      if (this.GM.BoxID[index] != (ushort) 0 && this.GM.BoxTime[index] == 0L)
      {
        this.Box[index].TimeStr.Length = 0;
        GameConstants.GetTimeInfoString(this.Box[index].TimeStr, this.GM.GetRequireTime(this.GM.BoxRequire[index]));
        this.Box[index].TotalTimeText.text = this.Box[index].TimeStr.ToString();
        this.Box[index].TotalTimeText.SetAllDirty();
        this.Box[index].TotalTimeText.cachedTextGenerator.Invalidate();
        ((Graphic) this.Box[index].ClockImage).rectTransform.anchoredPosition = new Vector2((float) ((double) ((Graphic) this.Box[index].TotalTimeText).rectTransform.anchoredPosition.x - (double) this.Box[index].TotalTimeText.preferredWidth / 2.0 - 18.0), ((Graphic) this.Box[index].ClockImage).rectTransform.anchoredPosition.y);
      }
    }
    if (this.NowIndex == (byte) 0)
      return;
    this.Front_TotalTimeText.text = this.Box[(int) this.NowIndex - 1].TimeStr.ToString();
    this.Front_TotalTimeText.SetAllDirty();
    this.Front_TotalTimeText.cachedTextGenerator.Invalidate();
    Image component = this.tFront2.GetChild(9).GetComponent<Image>();
    ((Graphic) component).rectTransform.anchoredPosition = new Vector2((float) ((double) ((Graphic) this.Front_TotalTimeText).rectTransform.anchoredPosition.x - (double) this.Front_TotalTimeText.preferredWidth / 2.0 - 18.0), ((Graphic) component).rectTransform.anchoredPosition.y);
  }

  private void ReSetAll()
  {
    for (int Index = 0; Index < 3; ++Index)
      this.ReSetState(Index);
  }

  private void ReSerAll(int Index)
  {
    this.ReSetState(Index);
    for (int Index1 = 0; Index1 < 3; ++Index1)
    {
      if (Index1 != Index && this.GM.BoxID[Index1] != (ushort) 0)
        this.ReSetState(Index1, false);
    }
  }

  private void SetTimeText()
  {
    if ((Object) this.tTimeObj == (Object) null)
      return;
    if (this.GM.NPCCityBonusTime > 0L)
    {
      if (!this.tTimeObj.gameObject.activeInHierarchy)
        this.tTimeObj.gameObject.SetActive(true);
      long sec = this.GM.NPCCityBonusTime - this.DM.ServerTime;
      if (sec < 0L)
        sec = 0L;
      this.CountTimeStr.Length = 0;
      GameConstants.GetTimeString(this.CountTimeStr, (uint) sec, hideTimeIfDays: true, showZeroHour: false);
      this.CountTimeText.text = this.CountTimeStr.ToString();
      this.CountTimeText.SetAllDirty();
      this.CountTimeText.cachedTextGenerator.Invalidate();
    }
    else
    {
      if (!this.tTimeObj.gameObject.activeInHierarchy)
        return;
      this.tTimeObj.gameObject.SetActive(false);
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    if ((Object) button != (Object) null)
    {
      if (button.m_BtnID1 == 4 && button.m_BtnID2 == 2)
        this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 277f, 20, (int) sender.Parm1, 0, new Vector2(130f, 0.0f));
      else if (button.m_BtnID1 == 5 && button.m_BtnID2 == 1)
        this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 277f, 20, (int) sender.Parm1, 0, new Vector2(180f, 60f));
      else
        this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 277f, 20, (int) sender.Parm1, 0, Vector2.zero);
    }
    else
      this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 277f, 20, (int) sender.Parm1, 0, Vector2.zero);
  }

  public void OnButtonUp(UIButtonHint sender) => this.GM.m_Hint.Hide();

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (Object) menu)
      return;
    img.sprite = menu.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = menu.LoadMaterial();
  }
}
