// Decompiled with JetBrains decompiler
// Type: UILEBtn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UILEBtn : Selectable, IPointerClickHandler, IEventSystemHandler, IUIButtonScaleHandler2
{
  public IUILEBtnClickHandler m_Handler;
  public int m_BtnID1;
  public int m_BtnID2;
  public int m_BtnID3;
  public int m_BtnID4;
  public ushort LEID;
  public Image BackPanel;
  public Image LEImage;
  public Image Gem1Panel;
  public Image Gem2Panel;
  public Image Gem3Panel;
  public Image Gem4Panel;
  public Image Gem1;
  public Image Gem2;
  public Image Gem3;
  public Image Gem4;
  public Image LevelImage;
  public Image OnEquip;
  public Image QuantityBg;
  public Image NameBg;
  public UIText Name;
  public UIText Quantity;
  public UIText Level;
  public byte SoundIndex;
  private e_EffectType m_EffectType;
  private Image TimeBg;
  private UIText TimeText;
  private Image Clock;
  private Image ClockLight;
  private bool isCounting;
  private long innerTime;
  private CString TimeString;

  public void OnPointerClick(PointerEventData eventData)
  {
    if (this.m_EffectType != e_EffectType.e_Normal)
      return;
    this.ClickFunc();
  }

  private void ClickFunc()
  {
    if (!((UIBehaviour) this).IsActive() || !this.IsInteractable() || this.m_Handler == null)
      return;
    if (((int) this.SoundIndex & 64) == 0)
      AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex) this.SoundIndex);
    else if (((int) this.SoundIndex & 64) > 0)
      AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex) ((int) this.SoundIndex & -65));
    this.m_Handler.OnLEButtonClick(this);
  }

  public void SetEffectType(e_EffectType EffectType) => this.m_EffectType = EffectType;

  public void OnFinish() => this.ClickFunc();

  public void ReLinkScale()
  {
    uButtonScale component = ((Component) this).gameObject.GetComponent<uButtonScale>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    component.m_Handler = (IUIButtonScaleHandler2) this;
    this.m_EffectType = e_EffectType.e_Scale;
  }

  public void SetTimedItem(long totalTime, eLordEquipDisplayKind DisplayKind = eLordEquipDisplayKind.OnlyItem)
  {
    if (totalTime == 0L)
    {
      this.isCounting = false;
      if ((UnityEngine.Object) this.TimeBg == (UnityEngine.Object) null)
        return;
      ((Component) this.TimeBg).gameObject.SetActive(false);
      ((Component) this.TimeText).gameObject.SetActive(false);
      ((Component) this.Clock).gameObject.SetActive(false);
      ((Component) this.ClockLight).gameObject.SetActive(false);
    }
    else
    {
      this.innerTime = totalTime;
      if ((UnityEngine.Object) this.TimeBg == (UnityEngine.Object) null)
      {
        GUIManager instance = GUIManager.Instance;
        this.TimeString = StringManager.Instance.SpawnString();
        GameObject gameObject1 = new GameObject("TimeBg");
        gameObject1.layer = 5;
        RectTransform rectTransform1 = gameObject1.AddComponent<RectTransform>();
        rectTransform1.anchorMin = new Vector2(0.0f, 0.0f);
        rectTransform1.anchorMax = new Vector2(1f, 0.23f);
        rectTransform1.offsetMin = Vector2.zero;
        rectTransform1.offsetMax = Vector2.zero;
        gameObject1.AddComponent<IgnoreRaycast>();
        this.TimeBg = gameObject1.AddComponent<Image>();
        gameObject1.transform.SetParent(((Component) this).transform, false);
        GameObject gameObject2 = new GameObject("TimeText");
        gameObject2.layer = 5;
        RectTransform rectTransform2 = gameObject2.AddComponent<RectTransform>();
        rectTransform2.anchorMin = new Vector2(0.0f, 0.0f);
        rectTransform2.anchorMax = new Vector2(1f, 0.23f);
        rectTransform2.offsetMin = Vector2.zero;
        rectTransform2.offsetMax = Vector2.zero;
        gameObject2.AddComponent<IgnoreRaycast>();
        this.TimeText = gameObject2.AddComponent<UIText>();
        this.TimeText.supportRichText = true;
        this.TimeText.resizeTextForBestFit = true;
        this.TimeText.font = GUIManager.Instance.GetTTFFont();
        this.TimeText.alignment = TextAnchor.MiddleCenter;
        ((Shadow) gameObject2.AddComponent<Outline>()).effectColor = (Color) new Color32((byte) 36, (byte) 16, (byte) 0, byte.MaxValue);
        gameObject2.AddComponent<Shadow>().effectColor = new Color(0.0f, 0.0f, 0.0f, 0.5f);
        this.TimeText.resizeTextMinSize = 2;
        this.TimeText.resizeTextMaxSize = 18;
        gameObject2.transform.SetParent(((Component) this).transform, false);
        GameObject gameObject3 = new GameObject("Clock");
        gameObject3.layer = 5;
        RectTransform rectTransform3 = gameObject3.AddComponent<RectTransform>();
        rectTransform3.anchorMin = new Vector2(-0.11f, -0.075f);
        rectTransform3.anchorMax = new Vector2(0.365f, 0.395f);
        rectTransform3.offsetMin = Vector2.zero;
        rectTransform3.offsetMax = Vector2.zero;
        gameObject3.AddComponent<IgnoreRaycast>();
        this.Clock = gameObject3.AddComponent<Image>();
        gameObject3.transform.SetParent(((Component) this).transform, false);
        GameObject gameObject4 = new GameObject("ClockLight");
        gameObject4.layer = 5;
        RectTransform rectTransform4 = gameObject4.AddComponent<RectTransform>();
        rectTransform4.anchorMin = new Vector2(-0.11f, -0.075f);
        rectTransform4.anchorMax = new Vector2(0.365f, 0.395f);
        rectTransform4.offsetMin = Vector2.zero;
        rectTransform4.offsetMax = Vector2.zero;
        gameObject4.AddComponent<IgnoreRaycast>();
        this.ClockLight = gameObject4.AddComponent<Image>();
        gameObject4.transform.SetParent(((Component) this).transform, false);
        this.TimeBg.sprite = instance.m_LeadItemIconSpriteAsset.LoadSprite((ushort) 65527);
        ((MaskableGraphic) this.TimeBg).material = instance.m_LeadItemIconSpriteAsset.GetMaterial();
        this.Clock.sprite = instance.m_LeadItemIconSpriteAsset.LoadSprite((ushort) 65525);
        ((MaskableGraphic) this.Clock).material = instance.m_LeadItemIconSpriteAsset.GetMaterial();
        this.ClockLight.sprite = instance.m_LeadItemIconSpriteAsset.LoadSprite((ushort) 65526);
        ((MaskableGraphic) this.ClockLight).material = instance.m_LeadItemIconSpriteAsset.GetMaterial();
        ((Component) this.OnEquip).transform.SetAsLastSibling();
      }
      if (DisplayKind == eLordEquipDisplayKind.Item_Gems)
      {
        RectTransform component1 = ((Component) this.TimeBg).gameObject.GetComponent<RectTransform>();
        component1.anchorMin = new Vector2(0.0f, 0.25f);
        component1.anchorMax = new Vector2(1f, 0.48f);
        RectTransform component2 = ((Component) this.TimeText).gameObject.GetComponent<RectTransform>();
        component2.anchorMin = new Vector2(0.0f, 0.25f);
        component2.anchorMax = new Vector2(1f, 0.48f);
        RectTransform component3 = ((Component) this.Clock).gameObject.GetComponent<RectTransform>();
        component3.anchorMin = new Vector2(-0.11f, 0.175f);
        component3.anchorMax = new Vector2(0.365f, 0.645f);
        RectTransform component4 = ((Component) this.ClockLight).gameObject.GetComponent<RectTransform>();
        component4.anchorMin = new Vector2(-0.11f, 0.175f);
        component4.anchorMax = new Vector2(0.365f, 0.645f);
      }
      else
      {
        RectTransform component5 = ((Component) this.TimeBg).gameObject.GetComponent<RectTransform>();
        component5.anchorMin = new Vector2(0.0f, 0.0f);
        component5.anchorMax = new Vector2(1f, 0.23f);
        RectTransform component6 = ((Component) this.TimeText).gameObject.GetComponent<RectTransform>();
        component6.anchorMin = new Vector2(0.0f, 0.0f);
        component6.anchorMax = new Vector2(1f, 0.23f);
        RectTransform component7 = ((Component) this.Clock).gameObject.GetComponent<RectTransform>();
        component7.anchorMin = new Vector2(-0.11f, -0.075f);
        component7.anchorMax = new Vector2(0.365f, 0.395f);
        RectTransform component8 = ((Component) this.ClockLight).gameObject.GetComponent<RectTransform>();
        component8.anchorMin = new Vector2(-0.11f, -0.075f);
        component8.anchorMax = new Vector2(0.365f, 0.395f);
      }
      ((Component) this.TimeBg).gameObject.SetActive(true);
      ((Component) this.TimeText).gameObject.SetActive(true);
      ((Component) this.Clock).gameObject.SetActive(true);
      this.isCounting = false;
      ((Component) this.ClockLight).gameObject.SetActive(false);
      ((Graphic) this.TimeText).color = (Color) new Color32((byte) 53, (byte) 247, (byte) 108, byte.MaxValue);
      ((Component) this.ClockLight).gameObject.SetActive(false);
      this.UpdateTimeText();
    }
  }

  public void SetCountdown(long endTime, bool hideifZero = false)
  {
    if (hideifZero && endTime == 0L)
    {
      ((Component) this.TimeBg).gameObject.SetActive(false);
      ((Component) this.TimeText).gameObject.SetActive(false);
      ((Component) this.Clock).gameObject.SetActive(false);
      ((Component) this.ClockLight).gameObject.SetActive(false);
    }
    if (endTime == 0L || (UnityEngine.Object) this.TimeBg == (UnityEngine.Object) null)
      return;
    this.isCounting = true;
    ((Graphic) this.TimeText).color = (Color) new Color32(byte.MaxValue, (byte) 101, (byte) 110, byte.MaxValue);
    this.innerTime = endTime;
    ((Component) this.TimeBg).gameObject.SetActive(true);
    ((Component) this.TimeText).gameObject.SetActive(true);
    ((Component) this.Clock).gameObject.SetActive(true);
    ((Component) this.ClockLight).gameObject.SetActive(true);
    if (!GUIManager.Instance.m_LEBTN_updateList.Contains(this))
      GUIManager.Instance.m_LEBTN_updateList.Add(this);
    this.BtnUpdateTime(true);
  }

  public void BtnUpdateTime(bool onSec)
  {
    if (!this.isCounting)
      return;
    ((Graphic) this.ClockLight).color = new Color(1f, 1f, 1f, GUIManager.Instance.m_LEBtn_SharedAlpha);
    if (!onSec)
      return;
    this.UpdateTimeText();
  }

  public void UpdateTimeText()
  {
    this.TimeString.ClearString();
    if (this.isCounting)
      GameConstants.GetTimeStringShort(this.TimeString, (uint) Math.Max(0L, this.innerTime - DataManager.Instance.ServerTime));
    else
      GameConstants.GetTimeStringShort(this.TimeString, (uint) this.innerTime);
    this.TimeText.text = this.TimeString.ToString();
    this.TimeText.cachedTextGenerator.Invalidate();
    this.TimeText.SetAllDirty();
  }

  protected virtual void OnDestroy()
  {
    GUIManager.Instance.m_LEBTN_updateList.Remove(this);
    StringManager.Instance.DeSpawnString(this.TimeString);
    ((UIBehaviour) this).OnDestroy();
  }
}
