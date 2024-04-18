// Decompiled with JetBrains decompiler
// Type: UIJailRoom
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIJailRoom : GUIWindow, IUIButtonClickHandler
{
  private Transform AGS_Form;
  private DataManager DM;
  private Door door;
  private CString[] tmpString = new CString[5];
  private byte nowSortedIdx;
  public byte DMIdx;
  private ushort NowHeroID;
  private ushort LastHeroID;
  private Transform Pos3D1;
  private Transform Pos3D2;
  private Hero heroData;
  private int AssetKey1;
  private int AssetKey2;
  private AssetBundle bundle;
  private AssetBundleRequest bundleRequest;
  private GameObject Holder1;
  private GameObject Holder2;
  private UIJailRoom.eModelLoadingStep LoadingStep;
  private Transform LBtn;
  private Transform RBtn;
  private float TmpTime;
  private Vector3 Vec3Instance;
  private float MoveTime1;
  private float MoveTime2;
  private float GetPointTime;
  private bool openOkBox;
  private bool PrisonStateChanged;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    for (int index = 0; index < this.tmpString.Length; ++index)
      this.tmpString[index] = StringManager.Instance.SpawnString();
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    Image component1 = this.AGS_Form.GetChild(1).GetComponent<Image>();
    component1.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component1).material = this.door.LoadMaterial();
    ((Behaviour) component1).enabled = !GUIManager.Instance.bOpenOnIPhoneX;
    UIButton component2 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component2.image).material = this.door.LoadMaterial();
    component2.m_EffectType = e_EffectType.e_Scale;
    UIText component3 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIText>();
    component3.font = ttfFont;
    component3.text = this.DM.mStringTable.GetStringByID(4056U);
    this.AGS_Form.GetChild(12).GetComponent<UIText>().font = ttfFont;
    this.AGS_Form.GetChild(13).GetComponent<UIText>().font = ttfFont;
    this.AGS_Form.GetChild(14).GetComponent<UIText>().font = ttfFont;
    this.AGS_Form.GetChild(15).GetComponent<UIText>().font = ttfFont;
    UIText component4 = this.AGS_Form.GetChild(17).GetComponent<UIText>();
    component4.font = ttfFont;
    component4.text = this.DM.mStringTable.GetStringByID(7764U);
    this.AGS_Form.GetChild(18).GetComponent<UIText>().font = ttfFont;
    UIButton component5 = this.AGS_Form.GetChild(19).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    component5.m_EffectType = e_EffectType.e_Scale;
    UIText component6 = this.AGS_Form.GetChild(19).GetChild(0).GetComponent<UIText>();
    component6.font = ttfFont;
    component6.text = this.DM.mStringTable.GetStringByID(7765U);
    UIButton component7 = this.AGS_Form.GetChild(20).GetComponent<UIButton>();
    component7.m_Handler = (IUIButtonClickHandler) this;
    component7.m_EffectType = e_EffectType.e_Scale;
    UIText component8 = this.AGS_Form.GetChild(20).GetChild(0).GetComponent<UIText>();
    component8.font = ttfFont;
    component8.text = this.DM.mStringTable.GetStringByID(7763U);
    UIButton component9 = this.AGS_Form.GetChild(21).GetComponent<UIButton>();
    component9.m_Handler = (IUIButtonClickHandler) this;
    component9.m_EffectType = e_EffectType.e_Scale;
    UIText component10 = this.AGS_Form.GetChild(21).GetChild(0).GetComponent<UIText>();
    component10.font = ttfFont;
    component10.text = this.DM.mStringTable.GetStringByID(7762U);
    this.AGS_Form.GetChild(22).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    if (GUIManager.Instance.IsArabic)
      ((Transform) this.AGS_Form.GetChild(22).gameObject.GetComponent<RectTransform>()).localScale = new Vector3(-1f, 1f, 1f);
    UIButton component11 = this.AGS_Form.GetChild(23).GetComponent<UIButton>();
    component11.m_Handler = (IUIButtonClickHandler) this;
    component11.m_EffectType = e_EffectType.e_Scale;
    UIText component12 = this.AGS_Form.GetChild(23).GetChild(0).GetComponent<UIText>();
    component12.font = ttfFont;
    component12.text = this.DM.mStringTable.GetStringByID(4535U);
    UIButton component13 = this.AGS_Form.GetChild(24).GetComponent<UIButton>();
    component13.m_Handler = (IUIButtonClickHandler) this;
    component13.m_EffectType = e_EffectType.e_Scale;
    float x = ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x;
    float num = (float) (((double) ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x - 853.0) / 2.0);
    UIButton component14 = this.AGS_Form.GetChild(27).GetComponent<UIButton>();
    component14.m_Handler = (IUIButtonClickHandler) this;
    this.LBtn = ((Component) component14).transform;
    if ((double) num > 0.0 && (double) this.LBtn.localPosition.x + (double) num > (double) x / 2.0)
      num = x / 2f - this.LBtn.localPosition.x;
    this.MoveTime1 = this.LBtn.localPosition.x - num;
    UIButton component15 = this.AGS_Form.GetChild(28).GetComponent<UIButton>();
    component15.m_Handler = (IUIButtonClickHandler) this;
    this.RBtn = ((Component) component15).transform;
    this.MoveTime2 = this.RBtn.localPosition.x + num;
    this.Pos3D1 = this.AGS_Form.GetChild(5);
    this.Pos3D2 = this.AGS_Form.GetChild(6);
    Vector3 localPosition = this.Pos3D1.localPosition with
    {
      z = -500f
    };
    this.Pos3D1.localPosition = localPosition;
    localPosition = this.Pos3D2.localPosition with
    {
      z = -500f
    };
    this.Pos3D2.localPosition = localPosition;
    for (int index = 7; index < this.AGS_Form.childCount; ++index)
    {
      Transform child = this.AGS_Form.GetChild(index);
      localPosition = child.localPosition with
      {
        z = -1000f
      };
      child.localPosition = localPosition;
    }
    this.PrisonStateChanged = false;
    this.LoadingStep = UIJailRoom.eModelLoadingStep.Start;
    this.SetPrisoner((byte) arg1);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    this.Destory3DObject();
    for (int index = 0; index < this.tmpString.Length; ++index)
      StringManager.Instance.DeSpawnString(this.tmpString[index]);
    if ((Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_JailMoney) != (Object) null)
      GUIManager.Instance.CloseMenu(EGUIWindow.UI_JailMoney);
    if (!this.openOkBox)
      return;
    GUIManager.Instance.CloseOKCancelBox();
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    this.openOkBox = false;
    if (!bOK)
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_RELEASE_PRISONER;
    messagePacket.AddSeqId();
    messagePacket.Add(this.DMIdx);
    messagePacket.Send();
    this.door.CloseMenu();
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!bOnSecond)
      return;
    RectTransform component1 = this.AGS_Form.GetChild(11).GetComponent<RectTransform>();
    long sec = this.DM.PrisonerList[(int) this.DMIdx].StartActionTime + (long) this.DM.PrisonerList[(int) this.DMIdx].TotalTime - this.DM.ServerTime;
    if (sec < 0L)
      sec = 0L;
    switch (this.DM.PrisonerList[(int) this.DMIdx].nowStat)
    {
      case PrisonerState.WaitForRelease:
      case PrisonerState.Poisoned:
        float num1 = Mathf.Clamp01(1f - (float) sec / (float) this.DM.PrisonerList[(int) this.DMIdx].TotalTime);
        component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num1 * 305f);
        break;
      case PrisonerState.WaitForExecute:
        this.tmpString[0].ClearString();
        if (sec > 21600L)
        {
          this.tmpString[0].Append(this.DM.mStringTable.GetStringByID(7759U));
          sec -= 21600L;
          float num2 = Mathf.Clamp01(1f - (float) sec / (float) (this.DM.PrisonerList[(int) this.DMIdx].TotalTime - 21600U));
          component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num2 * 305f);
        }
        else
        {
          this.tmpString[0].Append(this.DM.mStringTable.GetStringByID(7758U));
          float num3 = Mathf.Clamp01(1f - (float) sec / 21600f);
          component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num3 * 305f);
          this.AGS_Form.GetChild(10).gameObject.SetActive(true);
          this.AGS_Form.GetChild(21).gameObject.SetActive(true);
          this.AGS_Form.GetChild(22).gameObject.SetActive(false);
          if (!this.PrisonStateChanged)
          {
            this.PrisonStateChanged = true;
            if (this.openOkBox)
              GUIManager.Instance.CloseOKCancelBox();
          }
        }
        UIText component2 = this.AGS_Form.GetChild(12).GetComponent<UIText>();
        component2.text = this.tmpString[0].ToString();
        component2.SetAllDirty();
        component2.cachedTextGenerator.Invalidate();
        break;
    }
    UIText component3 = this.AGS_Form.GetChild(13).GetComponent<UIText>();
    this.tmpString[1].ClearString();
    GameConstants.GetTimeString(this.tmpString[1], (uint) sec, true, true);
    component3.text = this.tmpString[1].ToString();
    component3.SetAllDirty();
    component3.cachedTextGenerator.Invalidate();
    float preferredWidth = component3.preferredWidth;
    ((Graphic) this.AGS_Form.GetChild(12).GetComponent<UIText>()).rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 300f - preferredWidth);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    this.nowSortedIdx = JailManage.FindPrisonerSortIndex(this.DMIdx);
    this.SetPrisoner(this.nowSortedIdx);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        GUIManager.Instance.CloseOKCancelBox();
        this.door.CloseMenu();
        break;
      case NetworkNews.Fallout:
        this.openOkBox = false;
        break;
      case NetworkNews.Refresh_Asset:
        if (meg[2] != (byte) 2 || (int) GameConstants.ConvertBytesToUInt(meg, 3) != (int) this.NowHeroID)
          break;
        this.Destory3DObject();
        this.Create3DObjects();
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        this.Refresh_FontTexture();
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        switch (sender.m_BtnID2)
        {
          case 0:
            this.door.CloseMenu();
            return;
          case 1:
            this.SetNext(true);
            return;
          case 2:
            this.SetNext();
            return;
          default:
            return;
        }
      case 1:
        UIJailMoney uiJailMoney = (UIJailMoney) GUIManager.Instance.OpenMenu(EGUIWindow.UI_JailMoney, arg2: (int) this.DMIdx, bSecWindow: true);
        if (this.DM.PrisonerList[(int) this.DMIdx].Ransom <= 0U)
          break;
        uiJailMoney.SetMoney(this.DM.PrisonerList[(int) this.DMIdx].Ransom);
        break;
      case 2:
        this.openOkBox = true;
        GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(3971U), this.DM.mStringTable.GetStringByID(7793U));
        break;
      case 3:
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_EXECUTE_PRISONER;
        messagePacket.AddSeqId();
        messagePacket.Add(this.DMIdx);
        messagePacket.Send();
        this.door.CloseMenu();
        break;
      case 4:
        this.DM.ShowLordProfile(this.DM.PrisonerList[(int) this.DMIdx].name.ToString());
        break;
      case 5:
        DataManager.Instance.Letter_ReplyName = this.DM.PrisonerList[(int) this.DMIdx].name.ToString();
        this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 2);
        break;
      case 6:
        GUIManager.Instance.OpenSpendWindow_ItemID(3, this.DM.mStringTable.GetStringByID(4957U), (ushort) 1314, (int) this.DMIdx);
        this.openOkBox = true;
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIText>();
    if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.AGS_Form.GetChild(12).GetComponent<UIText>();
    if ((Object) component2 != (Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.AGS_Form.GetChild(13).GetComponent<UIText>();
    if ((Object) component3 != (Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.AGS_Form.GetChild(14).GetComponent<UIText>();
    if ((Object) component4 != (Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    UIText component5 = this.AGS_Form.GetChild(15).GetComponent<UIText>();
    if ((Object) component5 != (Object) null && ((Behaviour) component5).enabled)
    {
      ((Behaviour) component5).enabled = false;
      ((Behaviour) component5).enabled = true;
    }
    UIText component6 = this.AGS_Form.GetChild(17).GetComponent<UIText>();
    if ((Object) component6 != (Object) null && ((Behaviour) component6).enabled)
    {
      ((Behaviour) component6).enabled = false;
      ((Behaviour) component6).enabled = true;
    }
    UIText component7 = this.AGS_Form.GetChild(18).GetComponent<UIText>();
    if ((Object) component7 != (Object) null && ((Behaviour) component7).enabled)
    {
      ((Behaviour) component7).enabled = false;
      ((Behaviour) component7).enabled = true;
    }
    UIText component8 = this.AGS_Form.GetChild(19).GetChild(0).GetComponent<UIText>();
    if ((Object) component8 != (Object) null && ((Behaviour) component8).enabled)
    {
      ((Behaviour) component8).enabled = false;
      ((Behaviour) component8).enabled = true;
    }
    UIText component9 = this.AGS_Form.GetChild(20).GetChild(0).GetComponent<UIText>();
    if ((Object) component9 != (Object) null && ((Behaviour) component9).enabled)
    {
      ((Behaviour) component9).enabled = false;
      ((Behaviour) component9).enabled = true;
    }
    UIText component10 = this.AGS_Form.GetChild(21).GetChild(0).GetComponent<UIText>();
    if ((Object) component10 != (Object) null && ((Behaviour) component10).enabled)
    {
      ((Behaviour) component10).enabled = false;
      ((Behaviour) component10).enabled = true;
    }
    UIText component11 = this.AGS_Form.GetChild(23).GetChild(0).GetComponent<UIText>();
    if (!((Object) component11 != (Object) null) || !((Behaviour) component11).enabled)
      return;
    ((Behaviour) component11).enabled = false;
    ((Behaviour) component11).enabled = true;
  }

  private void SetPrisoner(byte idx)
  {
    this.nowSortedIdx = idx;
    this.DMIdx = this.DM.sortedPrisonerList[(int) this.nowSortedIdx];
    this.LBtn.gameObject.SetActive(true);
    this.RBtn.gameObject.SetActive(true);
    if (this.nowSortedIdx == (byte) 0)
      this.LBtn.gameObject.SetActive(false);
    if ((int) this.nowSortedIdx + 1 == this.DM.PrisonerList.Length || this.DM.PrisonerList[(int) this.DM.sortedPrisonerList[(int) this.nowSortedIdx + 1]].nowStat == PrisonerState.None)
      this.RBtn.gameObject.SetActive(false);
    UIText component1 = this.AGS_Form.GetChild(12).GetComponent<UIText>();
    UISpritesArray component2 = this.AGS_Form.GetChild(11).GetComponent<UISpritesArray>();
    this.tmpString[0].ClearString();
    long sec = this.DM.PrisonerList[(int) this.DMIdx].StartActionTime + (long) this.DM.PrisonerList[(int) this.DMIdx].TotalTime - this.DM.ServerTime;
    if (sec < 0L)
      sec = 0L;
    RectTransform component3 = this.AGS_Form.GetChild(11).GetComponent<RectTransform>();
    switch (this.DM.PrisonerList[(int) this.DMIdx].nowStat)
    {
      case PrisonerState.WaitForRelease:
        this.tmpString[0].Append(this.DM.mStringTable.GetStringByID(7768U));
        component2.SetSpriteIndex(2);
        this.AGS_Form.GetChild(10).gameObject.SetActive(false);
        this.AGS_Form.GetChild(21).gameObject.SetActive(false);
        this.AGS_Form.GetChild(22).gameObject.SetActive(false);
        this.AGS_Form.GetChild(19).gameObject.SetActive(true);
        float num1 = Mathf.Clamp01(1f - (float) sec / (float) this.DM.PrisonerList[(int) this.DMIdx].TotalTime);
        component3.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num1 * 305f);
        break;
      case PrisonerState.WaitForExecute:
        if (sec > 21600L)
        {
          sec -= 21600L;
          this.tmpString[0].Append(this.DM.mStringTable.GetStringByID(7759U));
          component2.SetSpriteIndex(1);
          this.AGS_Form.GetChild(10).gameObject.SetActive(false);
          this.AGS_Form.GetChild(21).gameObject.SetActive(false);
          this.AGS_Form.GetChild(22).gameObject.SetActive(true);
          this.AGS_Form.GetChild(19).gameObject.SetActive(true);
          float num2 = Mathf.Clamp01(1f - (float) sec / (float) (this.DM.PrisonerList[(int) this.DMIdx].TotalTime - 21600U));
          component3.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num2 * 305f);
          break;
        }
        this.tmpString[0].Append(this.DM.mStringTable.GetStringByID(7758U));
        component2.SetSpriteIndex(0);
        this.AGS_Form.GetChild(10).gameObject.SetActive(true);
        this.AGS_Form.GetChild(21).gameObject.SetActive(true);
        this.AGS_Form.GetChild(22).gameObject.SetActive(false);
        this.AGS_Form.GetChild(19).gameObject.SetActive(true);
        this.AGS_Form.GetChild(10).GetComponent<UISpritesArray>().SetSpriteIndex(0);
        float num3 = Mathf.Clamp01(1f - (float) sec / 21600f);
        component3.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num3 * 305f);
        break;
      case PrisonerState.Poisoned:
        this.tmpString[0].Append(this.DM.mStringTable.GetStringByID(15008U));
        component2.SetSpriteIndex(3);
        this.AGS_Form.GetChild(10).gameObject.SetActive(true);
        this.AGS_Form.GetChild(21).gameObject.SetActive(false);
        this.AGS_Form.GetChild(22).gameObject.SetActive(true);
        this.AGS_Form.GetChild(19).gameObject.SetActive(true);
        this.AGS_Form.GetChild(10).GetComponent<UISpritesArray>().SetSpriteIndex(1);
        float num4 = Mathf.Clamp01(1f - (float) sec / (float) this.DM.PrisonerList[(int) this.DMIdx].TotalTime);
        component3.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num4 * 305f);
        break;
    }
    component1.text = this.tmpString[0].ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    UIText component4 = this.AGS_Form.GetChild(13).GetComponent<UIText>();
    this.tmpString[1].ClearString();
    GameConstants.GetTimeString(this.tmpString[1], (uint) sec, true, true);
    component4.text = this.tmpString[1].ToString();
    component4.SetAllDirty();
    component4.cachedTextGenerator.Invalidate();
    UIText component5 = this.AGS_Form.GetChild(14).GetComponent<UIText>();
    this.tmpString[2].ClearString();
    this.tmpString[2].IntToFormat((long) this.DM.PrisonerList[(int) this.DMIdx].LordLevel);
    this.tmpString[2].AppendFormat(this.DM.mStringTable.GetStringByID(7757U));
    component5.text = this.tmpString[2].ToString();
    component5.SetAllDirty();
    component5.cachedTextGenerator.Invalidate();
    UIText component6 = this.AGS_Form.GetChild(15).GetComponent<UIText>();
    this.tmpString[3].ClearString();
    GameConstants.GetNameString(this.tmpString[3], this.DM.PrisonerList[(int) this.DMIdx].KingdomID, this.DM.PrisonerList[(int) this.DMIdx].name, this.DM.PrisonerList[(int) this.DMIdx].AlliTag);
    component6.text = this.tmpString[3].ToString();
    component6.SetAllDirty();
    component6.cachedTextGenerator.Invalidate();
    UIText component7 = this.AGS_Form.GetChild(18).GetComponent<UIText>();
    ((Component) component7).gameObject.SetActive(true);
    this.AGS_Form.GetChild(16).gameObject.SetActive(true);
    this.AGS_Form.GetChild(17).gameObject.SetActive(true);
    this.tmpString[4].ClearString();
    if (this.DM.PrisonerList[(int) this.DMIdx].Ransom > 0U)
    {
      this.tmpString[4].IntToFormat((long) this.DM.PrisonerList[(int) this.DMIdx].Ransom, bNumber: true);
      this.tmpString[4].AppendFormat("{0:N}");
    }
    else
      this.tmpString[4].Append(this.DM.mStringTable.GetStringByID(7786U));
    component7.text = this.tmpString[4].ToString();
    component7.SetAllDirty();
    component7.cachedTextGenerator.Invalidate();
    this.AGS_Form.GetChild(19).GetChild(0).GetComponent<UIText>().text = this.DM.PrisonerList[(int) this.DMIdx].Ransom <= 0U ? this.DM.mStringTable.GetStringByID(7765U) : this.DM.mStringTable.GetStringByID(7767U);
    this.NowHeroID = this.DM.PrisonerList[(int) this.DMIdx].head;
    this.Create3DObjects();
  }

  private void Create3DObjects()
  {
    if ((int) this.NowHeroID == (int) this.LastHeroID)
      return;
    if (this.LoadingStep > UIJailRoom.eModelLoadingStep.WaitforHero)
      this.Destory3DObject(false);
    if (this.LoadingStep == UIJailRoom.eModelLoadingStep.Start)
    {
      CString Name = StringManager.Instance.StaticString1024();
      Name.Append("Role/cage");
      this.bundle = AssetManager.GetAssetBundle(Name, out this.AssetKey1);
      this.bundleRequest = this.bundle.LoadAsync("m", typeof (GameObject));
      this.LoadingStep = UIJailRoom.eModelLoadingStep.WaitforCage;
    }
    else
    {
      this.LastHeroID = this.NowHeroID;
      this.heroData = DataManager.Instance.HeroTable.GetRecordByKey(this.NowHeroID);
      CString Name = StringManager.Instance.StaticString1024();
      Name.IntToFormat((long) this.heroData.Modle, 5);
      Name.AppendFormat("Role/hero_{0}");
      this.bundle = AssetManager.GetAssetBundle(Name, out this.AssetKey2);
      if ((Object) this.bundle == (Object) null)
      {
        this.LoadingStep = UIJailRoom.eModelLoadingStep.Done;
      }
      else
      {
        this.bundleRequest = this.bundle.LoadAsync("m", typeof (GameObject));
        this.LoadingStep = UIJailRoom.eModelLoadingStep.WaitforHero;
      }
    }
  }

  private void Destory3DObject(bool ReleaseAll = true)
  {
    if ((Object) this.Holder1 != (Object) null)
    {
      Object.Destroy((Object) this.Holder1);
      this.Holder1 = (GameObject) null;
    }
    this.bundle = (AssetBundle) null;
    if (this.AssetKey1 != 0)
      AssetManager.UnloadAssetBundle(this.AssetKey1, false);
    this.LoadingStep = UIJailRoom.eModelLoadingStep.ReadyToLoadHero;
    if (!ReleaseAll)
      return;
    if (this.AssetKey2 != 0)
      AssetManager.UnloadAssetBundle(this.AssetKey2, false);
    if ((Object) this.Holder2 != (Object) null)
    {
      Object.Destroy((Object) this.Holder2);
      this.Holder2 = (GameObject) null;
    }
    this.LoadingStep = UIJailRoom.eModelLoadingStep.Start;
  }

  public void Update()
  {
    this.TmpTime += Time.smoothDeltaTime * 40f;
    if ((double) this.TmpTime >= 40.0)
      this.TmpTime = 0.0f;
    float num = (double) this.TmpTime <= 20.0 ? this.TmpTime : 40f - this.TmpTime;
    if ((double) num < 0.0)
      num = 0.0f;
    this.Vec3Instance.Set(this.MoveTime1 - num, this.LBtn.localPosition.y, this.LBtn.localPosition.z);
    this.LBtn.localPosition = this.Vec3Instance;
    this.Vec3Instance.Set(this.MoveTime2 + num, this.RBtn.localPosition.y, this.RBtn.localPosition.z);
    this.RBtn.localPosition = this.Vec3Instance;
    this.GetPointTime += Time.smoothDeltaTime;
    if ((double) this.GetPointTime >= 2.0)
      this.GetPointTime = 0.0f;
    float a = (double) this.GetPointTime <= 1.0 ? this.GetPointTime : 2f - this.GetPointTime;
    Image component1 = this.AGS_Form.GetChild(10).GetComponent<Image>();
    if (((Component) component1).gameObject.activeInHierarchy)
      ((Graphic) component1).color = new Color(1f, 1f, 1f, a);
    switch (this.LoadingStep)
    {
      case UIJailRoom.eModelLoadingStep.WaitforCage:
        if (!this.bundleRequest.isDone)
          break;
        this.Pos3D2.gameObject.SetActive(true);
        this.Holder2 = (GameObject) Object.Instantiate(this.bundleRequest.asset);
        this.Holder2.transform.SetParent(this.Pos3D2, false);
        this.Holder2.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
        {
          eulerAngles = new Vector3(0.0f, 6f, 0.0f)
        };
        this.Holder2.transform.localScale = new Vector3(55f, 50f, 55f);
        this.Holder2.transform.localPosition = Vector3.zero;
        GUIManager.Instance.SetLayer(this.Holder2, 5);
        this.Holder2.GetComponentInChildren<MeshRenderer>().useLightProbes = false;
        this.LastHeroID = this.NowHeroID;
        this.heroData = DataManager.Instance.HeroTable.GetRecordByKey(this.NowHeroID);
        CString Name1 = StringManager.Instance.StaticString1024();
        Name1.ClearString();
        Name1.IntToFormat((long) this.heroData.DyingSound, 3);
        Name1.AppendFormat("Role/{0}");
        AssetManager.GetAssetBundleDownload(Name1, AssetPath.Role, AssetType.HeroSFX, this.heroData.DyingSound);
        CString Name2 = StringManager.Instance.StaticString1024();
        Name2.IntToFormat((long) this.heroData.Modle, 5);
        Name2.AppendFormat("Role/hero_{0}");
        if (!AssetManager.GetAssetBundleDownload(Name2, AssetPath.Role, AssetType.Hero, this.heroData.Modle))
        {
          this.LoadingStep = UIJailRoom.eModelLoadingStep.Done;
          break;
        }
        this.bundle = AssetManager.GetAssetBundle(Name2, out this.AssetKey2);
        if ((Object) this.bundle == (Object) null)
        {
          this.LoadingStep = UIJailRoom.eModelLoadingStep.Done;
          break;
        }
        this.bundleRequest = this.bundle.LoadAsync("m", typeof (GameObject));
        this.LoadingStep = UIJailRoom.eModelLoadingStep.WaitforHero;
        break;
      case UIJailRoom.eModelLoadingStep.WaitforHero:
        if (!this.bundleRequest.isDone)
          break;
        this.Pos3D1.gameObject.SetActive(true);
        this.Holder1 = (GameObject) Object.Instantiate(this.bundleRequest.asset);
        this.Holder1.transform.SetParent(this.Pos3D1, false);
        this.Holder1.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
        {
          eulerAngles = new Vector3(0.0f, (float) this.heroData.Camera_Horizontal, 0.0f)
        };
        this.Holder1.transform.localScale = new Vector3((float) this.heroData.CameraScaleRate, (float) this.heroData.CameraScaleRate, (float) this.heroData.CameraScaleRate) * 0.9f;
        this.Holder1.transform.localPosition = Vector3.zero;
        GUIManager.Instance.SetLayer(this.Holder1, 5);
        Transform transform = this.Holder1.transform;
        if ((Object) transform != (Object) null)
        {
          transform.GetComponentInChildren<SkinnedMeshRenderer>().useLightProbes = false;
          transform.GetComponentInChildren<SkinnedMeshRenderer>().updateWhenOffscreen = true;
          Animation component2 = transform.GetComponent<Animation>();
          component2.cullingType = AnimationCullingType.AlwaysAnimate;
          component2.clip = component2.GetClip(AnimationUnit.ANIM_STRING[9]);
          component2[AnimationUnit.ANIM_STRING[9]].layer = 0;
          component2[AnimationUnit.ANIM_STRING[9]].wrapMode = WrapMode.Loop;
          component2.Play(AnimationUnit.ANIM_STRING[9], PlayMode.StopAll);
        }
        this.LoadingStep = UIJailRoom.eModelLoadingStep.Done;
        break;
    }
  }

  private void SetNext(bool revert = false)
  {
    this.PrisonStateChanged = false;
    if (revert)
      this.SetPrisoner((byte) ((uint) this.nowSortedIdx - 1U));
    else
      this.SetPrisoner((byte) ((uint) this.nowSortedIdx + 1U));
  }

  private enum e_AGS_UI_JailRoom_Editor
  {
    bgPanel,
    CloseDeco,
    BGL,
    BGR,
    BGFrameTitle,
    T3DObj1,
    T3DObj2,
    Shadow,
    TitleBox,
    BarBg,
    BarLight,
    Bar,
    BarStat,
    BarTime,
    BarLevel,
    BarName,
    Banner,
    BannerTitle,
    BannerMoney,
    SetMoney,
    Release,
    Execute,
    SpeedExecute,
    Profile,
    Mail,
    SideBar,
    SideBar2,
    LBtn,
    RBtn,
  }

  private enum eModelLoadingStep
  {
    Start,
    WaitforCage,
    ReadyToLoadHero,
    WaitforHero,
    Done,
  }
}
