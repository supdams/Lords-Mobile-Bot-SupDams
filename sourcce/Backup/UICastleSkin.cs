// Decompiled with JetBrains decompiler
// Type: UICastleSkin
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UICastleSkin : UICastleSkinWindow, IUIButtonDownUpHandler
{
  private BuildsData buildsData = GUIManager.Instance.BuildingData;
  private DataManager DM = DataManager.Instance;
  private RectTransform InfoRect;
  private RectTransform CastleRect;
  private byte Rank;
  private byte CurUseCastleID = byte.MaxValue;
  private UIText Name;
  private UIText BuyText;
  private UIText UseText;
  private Text PriceText;
  private GameObject UseObj;
  private GameObject BuyObj;
  private GameObject EnhanceObj;
  private GameObject EnhanceBtnObj;
  private GameObject EnhanceNoticeObj;
  private GameObject InfoObj;
  private GameObject NextObj;
  private Image CastleImg;
  private Image UseBtnImg;
  private Image InUseImg;
  private Image[] EnhanceImg = new Image[5];
  private CanvasGroup InfoAlpha;
  private UIButton UseBtn;
  private UIButton NextBtn;
  private byte DelayUpdateText;
  private byte UnlockPercentage;
  private byte PreViewPercentage;
  private byte updateNextBtn;
  private byte ExclamationCount;
  private float pixelsPerUnit;
  private float updateBtnNextStateTime;
  private UIButtonHint InfoHint;
  private CString PriceStr;
  private bool NeedUpDate;
  private ushort ItemID;
  private GameObject EffectObj;
  private byte ShowEffect;
  private float ShowTotalTime;
  private float ShowTime;
  private float DestScale;
  private Vector2 OriCastlePos;

  public override void OnOpen(int arg1, int arg2)
  {
    base.OnOpen(arg1, arg2);
    GUIManager instance = GUIManager.Instance;
    Font ttfFont = instance.GetTTFFont();
    this.MainTitle.text = this.DM.mStringTable.GetStringByID(9682U);
    this.EnhanceObj = this.transform.GetChild(0).gameObject;
    for (int index = 0; index < this.EnhanceImg.Length; ++index)
      this.EnhanceImg[index] = this.transform.GetChild(0).GetChild(0).GetChild(index).GetComponent<Image>();
    this.InfoHint = this.transform.GetChild(0).GetChild(2).gameObject.AddComponent<UIButtonHint>();
    this.InfoHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.InfoHint.m_Handler = (MonoBehaviour) this;
    this.InfoHint.m_ForcePos = true;
    this.InfoHint.m_HIBtnOffset = new Vector2(142f, -134f);
    this.InfoHint.ControlFadeOut = ((Component) this.Hint.ThisTransform).gameObject;
    this.InfoHint.Parm1 = (ushort) 1;
    UIButton component1 = this.transform.GetChild(0).GetChild(1).GetComponent<UIButton>();
    component1.m_BtnID1 = 0;
    component1.m_Handler = (IUIButtonClickHandler) this;
    this.EnhanceBtnObj = ((Component) component1).gameObject;
    this.EnhanceNoticeObj = this.transform.GetChild(0).GetChild(1).GetChild(0).gameObject;
    this.Name = this.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.Name.font = ttfFont;
    this.pixelsPerUnit = this.Name.pixelsPerUnit;
    this.InfoRect = this.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<RectTransform>();
    this.InfoObj = ((Component) this.InfoRect).gameObject;
    this.InfoHint = this.transform.GetChild(1).gameObject.AddComponent<UIButtonHint>();
    this.InfoHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.InfoHint.m_Handler = (MonoBehaviour) this;
    this.InfoHint.m_ForcePos = true;
    this.InfoHint.m_HIBtnOffset = new Vector2(142f, -134f);
    this.InfoHint.ControlFadeOut = ((Component) this.Hint.ThisTransform).gameObject;
    if (instance.IsArabic)
      this.transform.GetChild(1).GetChild(0).GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
    this.InfoAlpha = this.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<CanvasGroup>();
    this.CastleImg = this.transform.GetChild(2).GetComponent<Image>();
    this.CastleRect = ((Graphic) this.CastleImg).rectTransform;
    this.InUseImg = this.transform.GetChild(3).GetComponent<Image>();
    if (instance.IsArabic)
      ((Transform) ((Graphic) this.CastleImg).rectTransform).localRotation = new Quaternion(0.0f, 180f, 0.0f, 0.0f);
    this.NextObj = this.transform.GetChild(4).gameObject;
    this.NextBtn = this.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
    this.NextBtn.m_Handler = (IUIButtonClickHandler) this;
    this.NextBtn.m_BtnID1 = 3;
    bool flag = false;
    this.PriceStr = StringManager.Instance.SpawnString();
    Transform child = this.transform.GetChild(6);
    UIButton component2 = child.GetComponent<UIButton>();
    component2.m_BtnID1 = 2;
    component2.m_Handler = (IUIButtonClickHandler) this;
    this.BuyObj = child.gameObject;
    if (flag)
    {
      child.GetChild(0).gameObject.SetActive(false);
      child.GetChild(2).gameObject.SetActive(true);
      child.GetChild(3).gameObject.SetActive(true);
      this.PriceText = child.GetChild(3).GetComponent<Text>();
      this.PriceText.font = ttfFont;
    }
    else
    {
      this.PriceText = child.GetChild(0).GetComponent<Text>();
      this.PriceText.font = ttfFont;
    }
    if (instance.IsArabic)
      ((Transform) ((Graphic) this.PriceText).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
    this.BuyText = child.GetChild(1).GetComponent<UIText>();
    this.BuyText.font = ttfFont;
    this.BuyText.text = this.DM.mStringTable.GetStringByID(284U);
    if (instance.IsArabic)
      ((Transform) ((Graphic) this.BuyText).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
    this.UseObj = this.transform.GetChild(5).gameObject;
    this.UseBtnImg = this.transform.GetChild(5).GetComponent<Image>();
    this.UseBtn = this.transform.GetChild(5).GetComponent<UIButton>();
    this.UseBtn.m_BtnID1 = 1;
    this.UseBtn.m_Handler = (IUIButtonClickHandler) this;
    this.UseText = this.transform.GetChild(5).GetChild(0).GetComponent<UIText>();
    this.UseText.font = ttfFont;
    this.ExclamationCount = this.buildsData.castleSkin.GetExclamationCount();
    this.UpdateViewData();
    if (this.CastleLv < (byte) 9 || this.buildsData.castleSkin.UnlockCastleSkinNotice != (byte) 0)
      return;
    this.buildsData.castleSkin.UnlockCastleSkinNotice = (byte) 1;
    this.buildsData.castleSkin.SaveCastleSkinSave();
    this.buildsData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  protected override void SetLargeSize(int screenWidth)
  {
    base.SetLargeSize(screenWidth);
    RectTransform component1 = this.transform.GetChild(5).GetComponent<RectTransform>();
    float x = 5f / 16f * (float) screenWidth;
    if ((double) x * 2.0 + (double) component1.sizeDelta.x < (double) screenWidth)
      component1.anchoredPosition = new Vector2(x, component1.anchoredPosition.y);
    RectTransform component2 = this.transform.GetChild(6).GetComponent<RectTransform>();
    if ((double) x * 2.0 + (double) component2.sizeDelta.x >= (double) screenWidth)
      return;
    component2.anchoredPosition = new Vector2(x, component2.anchoredPosition.y);
  }

  public override void Initial()
  {
    base.Initial();
    this.buildsData.castleSkin.SaveCastleSkinSave();
    if (this.AllCastleID.Length <= 6)
      return;
    this.updateNextBtn = (byte) 1;
  }

  private void UpdateNextBtnState()
  {
    if (!this.buildsData.castleSkin.CheckShowExclamation())
    {
      this.updateNextBtn = (byte) 0;
      this.NextObj.SetActive(false);
    }
    else
    {
      int num = Mathf.Clamp(this.CastleView.GetBeginIdx(), 0, this.AllCastleID.Length - 1);
      this.NextBtn.m_BtnID2 = 0;
      for (int itemidx = num + 5; itemidx < this.AllCastleID.Length; ++itemidx)
      {
        if (!this.CastleView.CheckInPanel(itemidx) && !this.buildsData.castleSkin.CheckSelect((byte) this.AllCastleID[itemidx]))
        {
          this.NextBtn.m_BtnID2 = itemidx;
          break;
        }
      }
      if (this.NextBtn.m_BtnID2 > 0)
        this.NextObj.SetActive(true);
      else
        this.NextObj.SetActive(false);
    }
  }

  private void UpdateEnhance(bool bReset = false)
  {
    byte castleEnhance = this.buildsData.castleSkin.GetCastleEnhance((byte) this.SelectedCastleID);
    if (!this.buildsData.castleSkin.CheckUnlock((byte) this.SelectedCastleID))
    {
      this.EnhanceObj.SetActive(false);
    }
    else
    {
      if (!this.DM.CheckPrizeFlag((byte) 21))
        this.EnhanceNoticeObj.SetActive(true);
      this.EnhanceObj.SetActive(true);
      if ((int) this.Rank == (int) castleEnhance)
        return;
      this.Rank = castleEnhance;
      if (!bReset)
      {
        int rank = (int) this.Rank;
        while ((int) this.Rank < (int) castleEnhance)
        {
          this.EnhanceImg[rank].sprite = this.StarArray.GetSprite(1);
          ++rank;
        }
      }
      else
      {
        for (byte index = 0; (int) index < this.EnhanceImg.Length; ++index)
          this.EnhanceImg[(int) index].sprite = (int) this.Rank <= (int) index ? this.StarArray.GetSprite(0) : this.StarArray.GetSprite(1);
      }
    }
  }

  private void UpdateViewData(bool bForce = false)
  {
    if (bForce)
      this.CurUseCastleID = (byte) 0;
    else if ((int) this.CurUseCastleID != (int) this.SelectedCastleID)
    {
      this.ResetEffect();
      this.RetrieveEffect();
    }
    if ((int) this.CurUseCastleID == (int) this.SelectedCastleID)
      return;
    this.CurUseCastleID = (byte) this.SelectedCastleID;
    CastleSkinTbl recordByKey = this.buildsData.castleSkin.CastleSkinTable.GetRecordByKey((ushort) this.CurUseCastleID);
    this.Name.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.Name);
    this.CastleImg.sprite = this.buildsData.castleSkin.GetUISprite(recordByKey.Graphic, this.CastleLv);
    ((MaskableGraphic) this.CastleImg).material = this.buildsData.castleSkin.GetUIMaterial(recordByKey.Graphic, this.CastleLv);
    this.CastleImg.SetNativeSize();
    this.UpdateEnhance(true);
    this.ItemID = (ushort) recordByKey.ItemID;
    this.UnlockPercentage = recordByKey.UnlockPercentage;
    this.PreViewPercentage = recordByKey.PreViewPercentage;
    this.UpdateUseBtnState();
    this.UpdateEnhanceBtnState();
    this.DelayUpdateText = (byte) 2;
    if ((int) this.CurUseCastleID == (int) this.buildsData.CastleID)
      ((Behaviour) this.InUseImg).enabled = true;
    else
      ((Behaviour) this.InUseImg).enabled = false;
  }

  private void UpdateUseBtnState()
  {
    if (this.buildsData.castleSkin.CheckUnlock(this.CurUseCastleID))
    {
      this.UseObj.SetActive(true);
      this.BuyObj.SetActive(false);
      if ((int) this.CurUseCastleID == (int) this.buildsData.CastleID)
      {
        this.UseText.text = this.DM.mStringTable.GetStringByID(7444U);
        this.UseBtn.interactable = false;
        ((Graphic) this.UseBtnImg).color = Color.gray;
        ((Graphic) this.UseText).color = new Color(0.898f, 0.0f, 0.31f);
      }
      else
      {
        this.UseText.text = this.DM.mStringTable.GetStringByID(924U);
        this.UseBtn.interactable = true;
        ((Graphic) this.UseBtnImg).color = Color.white;
        ((Graphic) this.UseText).color = Color.white;
      }
    }
    else
    {
      this.UseObj.SetActive(false);
      this.BuyObj.SetActive(true);
      this.SetPrice((uint) this.ItemID);
    }
  }

  private void UpdateEnhanceBtnState()
  {
    this.buildsData.castleSkin.GetCastleEnhance(this.CurUseCastleID);
    if (this.CastleLv >= (byte) 25 && this.buildsData.castleSkin.CheckUnlock(this.CurUseCastleID))
      this.EnhanceObj.SetActive(true);
    else
      this.EnhanceObj.SetActive(false);
    float num;
    if (this.EnhanceObj.activeSelf)
    {
      this.InfoHint.Parm1 = (ushort) 1;
      num = (float) this.UnlockPercentage * 0.01f;
    }
    else
    {
      this.InfoHint.Parm1 = (ushort) 0;
      num = (float) this.PreViewPercentage * 0.01f;
    }
    ((Component) this.CastleImg).transform.localScale = new Vector3(num, num, num);
  }

  public void SetPrice(uint TreasureID)
  {
    TreasureID = MallManager.Instance.TreasureIDTransToNew(TreasureID);
    this.PriceStr.Length = 0;
    string paltformPriceById = MallManager.Instance.GetProductPaltformPriceByID((int) TreasureID);
    string productPriceById = MallManager.Instance.GetProductPriceByID((int) TreasureID);
    if (paltformPriceById != null && paltformPriceById != string.Empty)
    {
      this.PriceStr.Append(paltformPriceById);
    }
    else
    {
      if (productPriceById == null)
      {
        double f = 0.0;
        this.NeedUpDate = true;
        this.PriceStr.DoubleToFormat(f, 2);
      }
      else
        this.PriceStr.StringToFormat(productPriceById);
      string currency = MallManager.Instance.GetCurrency((int) TreasureID);
      if (currency != null)
      {
        this.PriceStr.StringToFormat(currency);
        if (MallManager.Instance.bChangePosCurrency(currency))
          this.PriceStr.AppendFormat("{0} {1}");
        else
          this.PriceStr.AppendFormat("{1} {0}");
      }
      else
        this.PriceStr.AppendFormat("${0}");
    }
    this.PriceText.text = this.PriceStr.ToString();
    ((Graphic) this.PriceText).SetAllDirty();
    this.PriceText.cachedTextGenerator.Invalidate();
  }

  public override void OnButtonClick(UIButton sender)
  {
    base.OnButtonClick(sender);
    switch ((UICastleSkin.ClickType) sender.m_BtnID1)
    {
      case UICastleSkin.ClickType.Enhance:
        if (!this.DM.CheckPrizeFlag((byte) 21))
        {
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
          messagePacket.AddSeqId();
          messagePacket.Add((byte) 21);
          messagePacket.Send();
          this.DM.RoleAttr.PrizeFlag |= 2097152U;
          this.buildsData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
        }
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (Object) menu)
          break;
        menu.OpenMenu(EGUIWindow.UI_CastleStrengthen, bCameraMode: true);
        break;
      case UICastleSkin.ClickType.Use:
        GUIManager.Instance.ShowUILock(EUILock.CastleSkin);
        MessagePacket messagePacket1 = new MessagePacket((ushort) 1024);
        messagePacket1.Protocol = Protocol._MSG_REQUEST_CASTLE_SKIN_CHANGE;
        messagePacket1.AddSeqId();
        messagePacket1.Add((byte) ((uint) this.CurUseCastleID - 1U));
        messagePacket1.Send();
        break;
      case UICastleSkin.ClickType.Buy:
        if (this.ItemID == (ushort) 0 || MallManager.Instance.CheckbWaitBuy_Castle(true))
          break;
        MallManager.Instance.SendCheckCastleID = (ushort) this.CurUseCastleID;
        MallManager.Instance.Send_SPTREASURE_PREBUY_CHECK(ESpcialTreasureType.ESTST_CastleSkin, (uint) this.ItemID);
        break;
      case UICastleSkin.ClickType.Next:
        this.GoToScroll(this.NextBtn.m_BtnID2, (ushort) this.CurUseCastleID);
        this.UpdateViewData();
        this.UpdateNextBtnState();
        break;
    }
  }

  public override void OnInfoClick(UIButton sender)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    GUIManager.Instance.OpenMessageBoxEX(mStringTable.GetStringByID(9691U), mStringTable.GetStringByID(9683U), bInfo: true, BackExit: true);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    base.UpdateUI(arg1, arg2);
    switch (arg1)
    {
      case 1:
        if (this.AllCastleID == null)
        {
          this.SelectedCastleID = this.buildsData.castleSkin.ActiveCastleID;
        }
        else
        {
          for (int index = 0; index < this.AllCastleID.Length; ++index)
          {
            if ((int) this.AllCastleID[index] == (int) this.buildsData.castleSkin.ActiveCastleID)
            {
              this.GoToScroll(index, (ushort) 0);
              break;
            }
          }
        }
        this.UpdateViewData();
        this.ScrollToPosition = (byte) 1;
        break;
      case 2:
      case 3:
        if ((int) this.CurUseCastleID != arg2)
          break;
        this.UpdateViewData(true);
        if (arg1 == 2)
        {
          this.SetEffect((byte) 1);
          break;
        }
        this.SetEffect((byte) 2);
        break;
      default:
        this.UpdateViewData(true);
        break;
    }
  }

  private void SetEffect(byte id)
  {
    if (this.ShowEffect > (byte) 0)
      this.ResetEffect();
    this.ShowEffect = id;
    this.DestScale = ((Transform) this.CastleRect).localScale.x;
    this.OriCastlePos = this.CastleRect.anchoredPosition;
    ((Transform) this.CastleRect).localScale = Vector3.zero;
    this.CastleRect.pivot = new Vector2(0.5f, 0.5f);
    this.CastleRect.anchoredPosition = new Vector2(this.CastleRect.anchoredPosition.x, this.CastleRect.anchoredPosition.y + (float) ((double) this.CastleRect.sizeDelta.y * (double) this.DestScale * 0.5));
    this.ShowTime = 0.0f;
    if (this.ShowEffect == (byte) 1)
    {
      this.ShowTotalTime = 0.4f;
    }
    else
    {
      this.RetrieveEffect();
      this.EffectObj = ParticleManager.Instance.Spawn((ushort) 429, (Transform) this.CastleRect, new Vector3(0.0f, 0.0f, -850f), 1f, true);
      GUIManager.Instance.SetLayer(this.EffectObj, 5);
      this.ShowTotalTime = 0.2f;
    }
  }

  private void ResetEffect()
  {
    if (this.ShowEffect == (byte) 0)
      return;
    ((Transform) this.CastleRect).localScale = new Vector3(this.DestScale, this.DestScale, this.DestScale);
    this.CastleRect.anchoredPosition = this.OriCastlePos;
    this.CastleRect.pivot = new Vector2(0.5f, 0.0f);
    if (this.ShowEffect == (byte) 1)
    {
      this.RetrieveEffect();
      this.EffectObj = ParticleManager.Instance.Spawn((ushort) 428, (Transform) this.CastleRect, new Vector3(0.0f, (float) ((double) this.CastleRect.sizeDelta.y * (double) this.DestScale * 0.5), -850f), 1f, true);
      GUIManager.Instance.SetLayer(this.EffectObj, 5);
    }
    else if ((Object) this.EffectObj != (Object) null && this.EffectObj.activeSelf)
      this.EffectObj.transform.localPosition = new Vector3(0.0f, (float) ((double) this.CastleRect.sizeDelta.y * (double) this.DestScale * 0.5), -850f);
    this.ShowEffect = (byte) 0;
  }

  private void RetrieveEffect()
  {
    if (!((Object) this.EffectObj != (Object) null) || !this.EffectObj.activeSelf)
      return;
    this.EffectObj.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
    this.EffectObj.transform.localPosition = new Vector3(0.0f, 0.0f, -50f);
  }

  private void UpdateEffect()
  {
    if (this.ShowEffect == (byte) 1)
    {
      this.ShowTime += Time.deltaTime;
      float num1 = this.ShowTime / this.ShowTotalTime;
      if ((double) num1 < 1.0)
      {
        float num2 = num1 * this.DestScale;
        ((Transform) this.CastleRect).localScale = new Vector3(num2, num2, num2);
      }
      else
        this.ResetEffect();
    }
    else
    {
      if (this.ShowEffect != (byte) 2)
        return;
      float num3 = 0.2f * this.DestScale;
      this.ShowTime += Time.deltaTime;
      float num4 = this.ShowTime / this.ShowTotalTime;
      float num5 = 0.65f;
      if ((double) num4 <= (double) num5)
      {
        float num6 = this.DestScale + num3 * num4;
        ((Transform) this.CastleRect).localScale = new Vector3(num6, num6, num6);
      }
      else if ((double) num4 < 1.0)
      {
        float num7 = (float) ((double) this.DestScale + (double) num3 * (double) num5 - (double) this.DestScale * (double) num3 * ((double) num4 - (double) num5));
        ((Transform) this.CastleRect).localScale = new Vector3(num7, num7, num7);
      }
      else
        this.ResetEffect();
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh_BuildBase:
        this.UpdateEnhanceBtnState();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        ((Behaviour) this.Name).enabled = false;
        ((Behaviour) this.BuyText).enabled = false;
        ((Behaviour) this.UseText).enabled = false;
        ((Behaviour) this.PriceText).enabled = false;
        ((Behaviour) this.Name).enabled = true;
        ((Behaviour) this.BuyText).enabled = true;
        ((Behaviour) this.UseText).enabled = true;
        ((Behaviour) this.PriceText).enabled = true;
        break;
    }
  }

  public override void ClassticalCastleChanged()
  {
    this.CastleImg.sprite = this.buildsData.castleSkin.GetUISprite((byte) 0, this.CastleLv);
    ((MaskableGraphic) this.CastleImg).material = this.buildsData.castleSkin.GetUIMaterial((byte) 0, this.CastleLv);
  }

  public override void UpdateTime(bool bOnSecond)
  {
    base.UpdateTime(bOnSecond);
    if (this.NeedUpDate && bOnSecond && IGGGameSDK.Instance.bPaymentReady)
    {
      this.NeedUpDate = false;
      this.SetPrice((uint) this.ItemID);
    }
    if (this.DelayUpdateText > (byte) 0)
    {
      --this.DelayUpdateText;
      if (this.DelayUpdateText == (byte) 0)
      {
        UICharInfo[] charactersArray = this.Name.cachedTextGenerator.GetCharactersArray();
        IList<UILineInfo> lines = this.Name.cachedTextGenerator.lines;
        if (charactersArray.Length > 0)
        {
          float num = float.MaxValue;
          for (int index = 0; index < lines.Count; ++index)
          {
            if ((double) num > (double) charactersArray[lines[index].startCharIdx].cursorPos.x)
              num = charactersArray[lines[index].startCharIdx].cursorPos.x;
          }
          this.InfoRect.anchoredPosition = !GUIManager.Instance.IsArabic ? new Vector2((float) ((double) num / (double) this.pixelsPerUnit - (double) ((Graphic) this.Name).rectTransform.sizeDelta.x * 0.5 - 25.0), this.InfoRect.anchoredPosition.y) : new Vector2((float) -((double) num / (double) this.pixelsPerUnit - (double) ((Graphic) this.Name).rectTransform.sizeDelta.x * 0.5 - 25.0), this.InfoRect.anchoredPosition.y);
          if (!this.InfoObj.activeSelf)
            this.InfoObj.SetActive(true);
        }
      }
    }
    if (this.updateNextBtn == (byte) 1 && (double) this.updateBtnNextStateTime >= 0.0)
    {
      this.updateBtnNextStateTime -= Time.deltaTime;
      if ((double) this.updateBtnNextStateTime <= 0.0)
      {
        this.UpdateNextBtnState();
        this.updateBtnNextStateTime = 0.5f;
      }
    }
    this.UpdateEffect();
    this.InfoAlpha.alpha = (double) this.DeltaTime <= 1.0 ? this.DeltaTime : 2f - this.DeltaTime;
  }

  public override void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    base.ButtonOnClick(gameObject, dataIndex, panelId);
    this.NeedUpDate = false;
    this.UpdateViewData();
  }

  public override void OnClose()
  {
    base.OnClose();
    this.RetrieveEffect();
    StringManager.Instance.DeSpawnString(this.PriceStr);
    if ((int) this.ExclamationCount == (int) this.buildsData.castleSkin.GetExclamationCount())
      return;
    this.buildsData.castleSkin.SortDirty();
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (sender.Parm1 == (ushort) 0)
    {
      GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 2, 240f, 20, (int) this.CurUseCastleID, 0, Vector2.zero);
    }
    else
    {
      sender.GetTipPosition(this.Hint.ThisTransform);
      this.Hint.Show((ushort) this.CurUseCastleID);
    }
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Hide(true);
    this.Hint.Hide();
  }

  private new enum UIControl
  {
    Enhance,
    Name,
    CastleImg,
    InUse,
    Last,
    Use,
    Buy,
  }

  private new enum ClickType
  {
    Enhance,
    Use,
    Buy,
    Next,
  }
}
