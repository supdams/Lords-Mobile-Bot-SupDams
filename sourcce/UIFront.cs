// Decompiled with JetBrains decompiler
// Type: UIFront
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIFront : GUIWindow, IUIButtonClickHandler
{
  private Transform BackTrans;
  private Transform EffectTrans;
  private CanvasGroup[] SceneBackImage = new CanvasGroup[3];
  private RectTransform SkipBtnTrans;
  private UIText SkipText;
  private GameObject EffectObj;
  private GameObject FireEffect;
  private UIButton SkipBtn;
  private byte CurScen;
  private byte HideSkipBtn;
  private float DeltaTime;
  private float CanvasWidth;

  public override void OnOpen(int arg1, int arg2)
  {
    this.transform.SetParent((Transform) GUIManager.Instance.m_NewbieLayer);
    for (int index = 0; index < this.SceneBackImage.Length; ++index)
      this.SceneBackImage[index] = this.transform.GetChild(0 + index).GetComponent<CanvasGroup>();
    this.BackTrans = this.transform.GetChild(0);
    this.EffectTrans = this.transform.GetChild(3);
    this.SkipBtnTrans = this.transform.GetChild(5).GetComponent<RectTransform>();
    this.SkipBtn = ((Component) this.SkipBtnTrans).GetComponent<UIButton>();
    this.SkipBtn.m_Handler = (IUIButtonClickHandler) this;
    this.SkipText = this.transform.GetChild(5).GetChild(0).GetComponent<UIText>();
    this.SkipText.font = GUIManager.Instance.GetTTFFont();
    this.SkipText.text = DataManager.Instance.mStringTable.GetStringByID(1050U);
    this.EffectObj = ParticleManager.Instance.Spawn((ushort) 378, (Transform) null, Vector3.zero, 1f, true);
    GUIManager.Instance.SetLayer(this.EffectObj, 5);
    this.EffectObj.transform.SetParent(this.EffectTrans);
    this.EffectObj.transform.localPosition = new Vector3(0.0f, 0.0f, 444f);
    this.EffectObj.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    this.CanvasWidth = (((Component) GUIManager.Instance.m_UICanvas).transform as RectTransform).sizeDelta.x;
    ((Component) GUIManager.Instance.m_MessageBoxLayer).gameObject.SetActive(false);
    ((Component) GUIManager.Instance.m_LockPanelLayer).gameObject.SetActive(false);
    ((Component) GUIManager.Instance.m_HUDsTransform).gameObject.SetActive(false);
    if (!byte.TryParse(PlayerPrefs.GetString("Front_Guide"), out this.HideSkipBtn))
      PlayerPrefs.SetString("Front_Guide", "0");
    if (this.HideSkipBtn == (byte) 1)
      ((Component) this.SkipBtn).gameObject.SetActive(true);
    else
      ((Component) this.SkipBtn).gameObject.SetActive(false);
    if (!GUIManager.Instance.bOpenOnIPhoneX)
      return;
    RectTransform transform = this.transform as RectTransform;
    transform.offsetMin = new Vector2(0.0f, 0.0f);
    transform.offsetMax = new Vector2(0.0f, 0.0f);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    ((Behaviour) this.SkipText).enabled = false;
    ((Behaviour) this.SkipText).enabled = true;
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (this.CurScen == (byte) 0 || (double) this.SceneBackImage[(int) this.CurScen - 1].alpha < 0.10000000149011612)
      return;
    float num = Mathf.Clamp(this.DeltaTime / 1f, 0.0f, 1f);
    this.SceneBackImage[(int) this.CurScen - 1].alpha = 1f - num;
    this.SceneBackImage[(int) this.CurScen].alpha = num;
    if ((double) this.SceneBackImage[(int) this.CurScen - 1].alpha < 0.10000000149011612)
    {
      ((Component) this.SceneBackImage[(int) this.CurScen - 1]).gameObject.SetActive(false);
      this.SceneBackImage[(int) this.CurScen].alpha = 1f;
      this.BackTrans = ((Component) this.SceneBackImage[(int) this.CurScen]).transform;
      this.DeltaTime = 0.0f;
    }
    else
      this.DeltaTime += Time.deltaTime;
  }

  public void OnButtonClick(UIButton sender)
  {
    DataManager.StageDataController.currentWorldMode = WorldMode.Wild;
    DataManager.StageDataController._stageMode = StageMode.Count;
    DataManager.Instance.GoToBattleOrWar = GameplayKind.Origin;
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
    NewbieManager.Get().LockControl();
    NewbieManager.CheckNewbie();
    GUIManager.Instance.ShowChatBox();
    GUIManager.Instance.CloseMenu(EGUIWindow.UI_Front);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        this.transform.gameObject.SetActive(true);
        break;
      case 1:
        this.BackTrans.gameObject.SetActive(false);
        this.EffectTrans.gameObject.SetActive(false);
        break;
      case 2:
        if (!((Object) GUIManager.Instance.m_OtherCanvasLayer != (Object) null))
          break;
        ((Transform) this.SkipBtnTrans).SetParent((Transform) GUIManager.Instance.m_OtherCanvasLayer);
        if (GUIManager.Instance.IsArabic)
        {
          this.SkipBtnTrans.anchoredPosition = new Vector2((float) (-(double) this.CanvasWidth + 85.0), -40f);
          ((Transform) this.SkipBtnTrans).rotation = new Quaternion(0.0f, 180f, 0.0f, 0.0f);
        }
        else
        {
          this.SkipBtnTrans.anchoredPosition = new Vector2(-85f, -40f);
          ((Transform) this.SkipBtnTrans).rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
        ((Transform) this.SkipBtnTrans).localScale = Vector3.one;
        break;
      case 3:
        ((Transform) this.SkipBtnTrans).SetParent(this.transform);
        this.SkipBtnTrans.anchoredPosition = new Vector2(-85f, -40f);
        ((Transform) this.SkipBtnTrans).rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        ((Transform) this.SkipBtnTrans).localScale = Vector3.one;
        break;
      case 4:
        ((Behaviour) this.SkipBtn).enabled = false;
        break;
      case 5:
        ((Behaviour) this.SkipBtn).enabled = true;
        break;
      case 6:
        if ((int) this.CurScen + 1 >= this.SceneBackImage.Length || (int) this.SceneBackImage[(int) this.CurScen].alpha != 1)
          break;
        ((Component) this.SceneBackImage[(int) ++this.CurScen]).gameObject.SetActive(true);
        break;
      case 7:
        if (this.CurScen < (byte) 2 || (Object) this.FireEffect != (Object) null)
          break;
        this.FireEffect = ParticleManager.Instance.Spawn((ushort) 386, (Transform) null, Vector3.zero, 1f, true);
        GUIManager.Instance.SetLayer(this.FireEffect, 5);
        this.FireEffect.transform.SetParent(this.EffectTrans);
        this.FireEffect.transform.localPosition = new Vector3(0.0f, -222f, 0.0f);
        this.FireEffect.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        break;
    }
  }

  public override void OnClose()
  {
    ((Component) GUIManager.Instance.m_MessageBoxLayer).gameObject.SetActive(true);
    ((Component) GUIManager.Instance.m_LockPanelLayer).gameObject.SetActive(true);
    ((Transform) this.SkipBtnTrans).SetParent(this.transform);
    ParticleManager.Instance.DeSpawn(this.EffectObj);
    if (!((Object) this.FireEffect != (Object) null) || !this.FireEffect.activeSelf)
      return;
    this.FireEffect.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
    this.FireEffect.transform.localPosition = new Vector3(0.0f, 0.0f, -50f);
  }

  public enum UIControl
  {
    BackImage1,
    BackImage2,
    BackImage3,
    Effect,
    Fences,
    SkipBtn,
  }
}
