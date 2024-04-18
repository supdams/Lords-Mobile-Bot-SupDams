// Decompiled with JetBrains decompiler
// Type: UIChallegeTreasure
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIChallegeTreasure : GUIWindow, IUIButtonClickHandler
{
  private UIText TitleText;
  private UIText ConfirmText;
  private UIText DiamonCount;
  private UIText ConText;
  private UIText ItemTitleText;
  private UIText LitTitleText;
  private CString DiamonStr;
  private CString ContStr;
  private CString ItemTitleStr;
  private RectTransform LightT;
  private RectTransform Light1T;
  private RectTransform ItemRect;
  private Image UnlockImg;
  private float FrameWidth;
  private ushort Diamon;

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager instance = GUIManager.Instance;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    Font ttfFont = instance.GetTTFFont();
    this.FrameWidth = this.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
    this.TitleText = this.transform.GetChild(1).GetChild(1).GetComponent<UIText>();
    this.TitleText.font = ttfFont;
    this.TitleText.text = mStringTable.GetStringByID(12052U);
    this.ConfirmText = this.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<UIText>();
    this.ConfirmText.font = ttfFont;
    this.ConfirmText.text = mStringTable.GetStringByID(189U);
    this.ConText = this.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
    this.ConText.font = ttfFont;
    this.ConText.resizeTextForBestFit = false;
    ((Graphic) this.ConText).rectTransform.sizeDelta = new Vector2(367.1f, 35f);
    this.LitTitleText = this.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
    this.LitTitleText.font = ttfFont;
    this.LitTitleText.text = mStringTable.GetStringByID(12057U);
    this.DiamonStr = StringManager.Instance.SpawnString();
    this.LightT = this.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
    this.Light1T = this.transform.GetChild(0).GetChild(1).GetComponent<RectTransform>();
    this.ItemRect = this.transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
    instance.InitianHeroItemImg((Transform) this.ItemRect, eHeroOrItem.Item, (ushort) 1224, (byte) 0, (byte) 0, arg1, bAutoShowHint: false);
    this.DiamonCount = this.transform.GetChild(0).GetChild(2).GetChild(4).GetComponent<UIText>();
    this.Diamon = (ushort) arg1;
    this.DiamonStr.IntToFormat((long) this.Diamon, bNumber: true);
    this.DiamonStr.AppendFormat("{0}");
    this.DiamonCount.text = this.DiamonStr.ToString();
    this.ItemTitleStr = StringManager.Instance.SpawnString();
    this.ItemTitleText = this.transform.GetChild(0).GetChild(7).GetComponent<UIText>();
    this.ItemTitleText.font = ttfFont;
    this.ItemTitleStr.IntToFormat((long) this.Diamon, bNumber: true);
    this.ItemTitleStr.AppendFormat(mStringTable.GetStringByID(8473U));
    this.ItemTitleText.text = this.ItemTitleStr.ToString();
    this.transform.GetChild(0).GetChild(3).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(1).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.UnlockImg = this.transform.GetChild(0).GetChild(6).GetComponent<Image>();
    this.ContStr = StringManager.Instance.SpawnString();
    int num1 = arg2 >> 8;
    int num2 = arg2 & (int) byte.MaxValue;
    if (num2 >= 3)
    {
      ((Component) this.LitTitleText).gameObject.SetActive(false);
      ((Component) this.UnlockImg).gameObject.SetActive(false);
      this.SetSmallSize();
    }
    else if (num2 > 0)
    {
      if (num2 == 1)
        this.ContStr.IntToFormat(2L);
      else
        this.ContStr.IntToFormat(3L);
      this.ContStr.AppendFormat(mStringTable.GetStringByID(12058U));
      this.ConText.text = this.ContStr.ToString();
      this.UpdateLockPos();
    }
    else
    {
      ((Component) this.LitTitleText).gameObject.SetActive(false);
      ((Component) this.UnlockImg).gameObject.SetActive(false);
      this.SetSmallSize();
    }
  }

  private void UpdateLockPos()
  {
    if ((double) this.ConText.preferredWidth > 328.0)
    {
      while (this.ConText.fontSize > 10 && (double) this.ConText.preferredWidth > 328.0)
      {
        --this.ConText.fontSize;
        ((Graphic) this.ConText).SetLayoutDirty();
        this.ConText.cachedTextGeneratorForLayout.Invalidate();
      }
    }
    Vector2 vector2 = ((Graphic) this.UnlockImg).rectTransform.anchoredPosition with
    {
      x = (float) ((double) this.ConText.preferredWidth * -0.5 - 33.0 + 28.5)
    };
    ((Graphic) this.UnlockImg).rectTransform.anchoredPosition = vector2;
    vector2 = ((Graphic) this.LitTitleText).rectTransform.anchoredPosition with
    {
      x = (float) ((double) this.FrameWidth * 0.5 - (double) this.ConText.preferredWidth * 0.5 + 33.0 - 3.2999999523162842)
    };
    ((Graphic) this.LitTitleText).rectTransform.anchoredPosition = vector2;
    vector2 = ((Graphic) this.LitTitleText).rectTransform.sizeDelta with
    {
      x = (float) ((double) this.FrameWidth - (double) ((Graphic) this.LitTitleText).rectTransform.anchoredPosition.x - 55.0)
    };
    ((Graphic) this.LitTitleText).rectTransform.sizeDelta = vector2;
    vector2 = ((Graphic) this.ConText).rectTransform.anchoredPosition;
    vector2.x += 28.5f;
    ((Graphic) this.ConText).rectTransform.anchoredPosition = vector2;
  }

  private void SetSmallSize()
  {
    Vector2 anchoredPosition1 = this.LightT.anchoredPosition;
    anchoredPosition1.y -= 30.5f;
    this.LightT.anchoredPosition = anchoredPosition1;
    this.Light1T.anchoredPosition = anchoredPosition1;
    RectTransform rectTransform = ((Graphic) this.ItemTitleText).rectTransform;
    Vector2 anchoredPosition2 = rectTransform.anchoredPosition;
    anchoredPosition2.y -= 30.5f;
    rectTransform.anchoredPosition = anchoredPosition2;
    RectTransform component = this.transform.GetChild(0).GetChild(3).GetComponent<RectTransform>();
    Vector2 anchoredPosition3 = component.anchoredPosition;
    anchoredPosition3.y += 30.5f;
    component.anchoredPosition = anchoredPosition3;
    this.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(481f, 493f);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != 1000)
      return;
    GUIManager instance = GUIManager.Instance;
    this.transform.gameObject.SetActive(true);
    Array.Clear((Array) instance.SE_Kind, 0, instance.SE_Kind.Length);
    Array.Clear((Array) instance.SE_ItemID, 0, instance.SE_ItemID.Length);
    instance.m_SpeciallyEffect.mDiamondValue = (uint) this.Diamon;
    instance.SE_Kind[0] = SpeciallyEffect_Kind.TreasureBoxEX;
    instance.SE_ItemID[1] = (ushort) 0;
    Vector2 sizeDelta = ((Component) instance.m_UICanvas).GetComponent<RectTransform>().sizeDelta;
    instance.m_SpeciallyEffect.AddIconShow(new Vector2(sizeDelta.x * 0.5f, (float) ((double) sizeDelta.y * 0.5 - 32.0)), instance.SE_Kind, instance.SE_ItemID, false);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    ((Behaviour) this.TitleText).enabled = false;
    ((Behaviour) this.TitleText).enabled = true;
    ((Behaviour) this.ConfirmText).enabled = false;
    ((Behaviour) this.ConfirmText).enabled = true;
    ((Behaviour) this.DiamonCount).enabled = false;
    ((Behaviour) this.DiamonCount).enabled = true;
    ((Behaviour) this.ItemTitleText).enabled = false;
    ((Behaviour) this.ItemTitleText).enabled = true;
    ((Behaviour) this.LitTitleText).enabled = false;
    ((Behaviour) this.LitTitleText).enabled = true;
    ((Behaviour) this.ConText).enabled = false;
    ((Behaviour) this.ConText).enabled = true;
  }

  public override void UpdateTime(bool bOnSecond)
  {
    ((Transform) this.LightT).Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    ((Transform) this.Light1T).Rotate(Vector3.forward * Time.smoothDeltaTime * 50f);
  }

  public void OnButtonClick(UIButton sender) => GUIManager.Instance.CloseMenu(this.m_eWindow);

  public override void OnClose()
  {
    StringManager.Instance.DeSpawnString(this.DiamonStr);
    StringManager.Instance.DeSpawnString(this.ContStr);
    StringManager.Instance.DeSpawnString(this.ItemTitleStr);
  }

  private enum UIControl
  {
    Frame,
    Title,
  }

  private enum TitleControl
  {
    Close,
    Title,
  }

  private enum FrameControl
  {
    Light,
    Light1,
    Item,
    Confirm,
    LitTitle,
    Cont,
    Unlock,
    ItemTitle,
  }
}
