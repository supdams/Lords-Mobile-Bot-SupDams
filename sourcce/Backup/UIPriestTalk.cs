// Decompiled with JetBrains decompiler
// Type: UIPriestTalk
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIPriestTalk : GUIWindow, IUIButtonClickHandler
{
  private Transform AGS_Form;
  private Hero hero;
  private Transform Pos3D1;
  private GameObject Holder;
  private bool wait3DModel;
  private int AssetKey;
  private AssetBundle bundle;
  private AssetBundleRequest bundleRequest;
  private bool isOverLay;
  private bool bClickClose = true;
  public static bool Block1s;
  private float limitTime;

  public override void OnOpen(int arg1, int arg2)
  {
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    UIButton component1 = this.AGS_Form.GetChild(0).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 1;
    UIText component2 = this.AGS_Form.GetChild(0).GetChild(0).GetComponent<UIText>();
    component2.font = ttfFont;
    component2.text = DataManager.Instance.mStringTable.GetStringByID((uint) (ushort) arg1);
    component2.resizeTextForBestFit = true;
    component2.resizeTextMinSize = 12;
    component2.resizeTextMaxSize = 22;
    UIButton component3 = this.AGS_Form.GetChild(2).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 1;
    UIButton component4 = this.AGS_Form.GetChild(4).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_BtnID1 = 2;
    ((Component) component4).gameObject.SetActive(NewbieManager.IsNewbie);
    UIText component5 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIText>();
    component5.font = ttfFont;
    component5.text = DataManager.Instance.mStringTable.GetStringByID(1050U);
    this.Pos3D1 = this.AGS_Form.GetChild(1);
    this.hero = DataManager.Instance.HeroTable.GetRecordByKey((ushort) 101);
    this.bundle = AssetManager.GetAssetBundle("Role/Priest", out this.AssetKey);
    this.bundleRequest = this.bundle.LoadAsync("Priest", typeof (GameObject));
    this.wait3DModel = true;
    if (GUIManager.Instance.m_UICanvas.renderMode == null)
    {
      this.isOverLay = true;
      GUIManager.Instance.m_UICanvas.renderMode = (RenderMode) 1;
      GUIManager.Instance.SetCanvasChanged();
    }
    this.bClickClose = arg2 == 0;
    if (UIPriestTalk.Block1s)
      this.limitTime = Time.time + 1f;
    Light component6 = this.AGS_Form.GetChild(1).GetChild(0).GetChild(0).GetComponent<Light>();
    component6.gameObject.transform.localPosition = new Vector3(-1576f, -267f, 583f);
    component6.range = 70f;
    component6.color = (Color) new Color32((byte) 68, (byte) 99, (byte) 171, byte.MaxValue);
    component6.intensity = 6.5f;
    Light component7 = this.AGS_Form.GetChild(1).GetChild(0).GetChild(1).GetComponent<Light>();
    component7.gameObject.transform.localPosition = new Vector3(807f, 1263f, -2327f);
    component7.range = 70f;
    component7.color = (Color) new Color32((byte) 253, (byte) 239, (byte) 190, byte.MaxValue);
    component7.intensity = 5.3f;
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1:
        if ((double) Time.time < (double) this.limitTime)
          break;
        UIPriestTalk.Block1s = false;
        NewbieManager.Get().UIController.TriggerButtonEvent();
        if (!this.bClickClose)
          break;
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_PriestTalk);
        break;
      case 2:
        NewbieManager.Get().SkipForceNewbie();
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_PriestTalk);
        break;
    }
  }

  public override void OnClose()
  {
    UIPriestTalk.Block1s = false;
    if (this.isOverLay)
    {
      GUIManager.Instance.m_UICanvas.renderMode = (RenderMode) 0;
      GUIManager.Instance.SetCanvasChanged();
    }
    if ((Object) this.Holder != (Object) null)
    {
      Object.Destroy((Object) this.Holder);
      this.Holder = (GameObject) null;
    }
    AssetManager.UnloadAssetBundle(this.AssetKey, false);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    this.AGS_Form.GetChild(0).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID((uint) (ushort) arg1);
    if ((Object) this.Holder != (Object) null)
    {
      Animation component = this.Holder.GetComponent<Animation>();
      if ((Object) component != (Object) null)
        component.CrossFade("talk");
    }
    this.bClickClose = arg2 == 0;
    if (!UIPriestTalk.Block1s)
      return;
    this.limitTime = Time.time + 1f;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.AGS_Form.gameObject.SetActive(true);
        if (!((Object) this.Holder != (Object) null))
          break;
        Animation component = this.Holder.GetComponent<Animation>();
        if (!((Object) component != (Object) null))
          break;
        component[AnimationUnit.ANIM_STRING[0]].layer = 0;
        component[AnimationUnit.ANIM_STRING[0]].wrapMode = WrapMode.Loop;
        component.Play(AnimationUnit.ANIM_STRING[0]);
        component["talk"].layer = 1;
        component["talk"].wrapMode = WrapMode.Once;
        component.CrossFade("talk");
        break;
      case NetworkNews.Fallout:
        this.AGS_Form.gameObject.SetActive(false);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIText>();
    if (!((Object) component2 != (Object) null) || !((Behaviour) component2).enabled)
      return;
    ((Behaviour) component2).enabled = false;
    ((Behaviour) component2).enabled = true;
  }

  public void Update()
  {
    if (!this.wait3DModel || !this.bundleRequest.isDone)
      return;
    this.Pos3D1.gameObject.SetActive(true);
    this.Holder = (GameObject) Object.Instantiate(this.bundleRequest.asset);
    this.Holder.transform.SetParent(this.Pos3D1, false);
    this.Holder.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
    {
      eulerAngles = new Vector3(0.0f, (float) this.hero.Camera_Horizontal, 0.0f)
    };
    this.Holder.transform.localScale = new Vector3((float) this.hero.CameraScaleRate, (float) this.hero.CameraScaleRate, (float) this.hero.CameraScaleRate) * 1.3f;
    this.Holder.transform.localPosition = new Vector3(0.0f, -120f, 0.0f);
    GUIManager.Instance.SetLayer(this.Holder, 5);
    Transform transform = this.Holder.transform;
    if ((Object) transform != (Object) null)
    {
      Animation component = transform.GetComponent<Animation>();
      component[AnimationUnit.ANIM_STRING[0]].layer = 0;
      component[AnimationUnit.ANIM_STRING[0]].wrapMode = WrapMode.Loop;
      component.Play(AnimationUnit.ANIM_STRING[0]);
      transform.GetComponentInChildren<SkinnedMeshRenderer>().useLightProbes = false;
      transform.GetComponentInChildren<SkinnedMeshRenderer>().updateWhenOffscreen = true;
      component["talk"].layer = 1;
      component["talk"].wrapMode = WrapMode.Once;
      component.CrossFade("talk");
    }
    this.wait3DModel = false;
  }

  private enum e_AGS_UI_PriestTalk_Editor
  {
    TalkPanel,
    T3DO1,
    UIButton,
    GameObject,
    skip,
  }

  private enum e_AGS_Light
  {
    Light1,
    Light2,
  }
}
