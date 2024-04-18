// Decompiled with JetBrains decompiler
// Type: UIHeroTalk
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIHeroTalk : GUIWindow, IUIButtonClickHandler
{
  private Transform AGS_Form;
  private Transform Pos3D1;
  private Transform Pos3D2;
  private Transform LightGroup;
  private Transform PosLight1;
  private Transform PosLight2;
  private Transform PosLight3;
  private Hero hero1;
  private Hero hero2;
  private int AssetKey1;
  private int AssetKey2;
  private UIHeroTalk.e_LoadingStep LoadingStep;
  private AssetBundle bundle;
  private AssetBundleRequest bundleRequest;
  private GameObject Holder1;
  private GameObject Holder2;
  private static ushort HeroID1;
  private static ushort HeroID2;
  private ushort startTalkId;
  private ushort nowTalkId;
  private HeroTalkTbl talkData;
  private CString talkString;
  private Color EvoLight;
  public static bool lockInput;

  public override void OnOpen(int arg1, int arg2)
  {
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    UIButton component1 = this.AGS_Form.GetChild(0).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    ((Component) component1).gameObject.SetActive(false);
    ((Graphic) component1.image).color = new Color(1f, 1f, 1f, 0.5f);
    component1.m_BtnID1 = 1;
    UIText component2 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
    component2.font = ttfFont;
    component2.resizeTextForBestFit = true;
    component2.resizeTextMinSize = 12;
    component2.resizeTextMaxSize = 22;
    this.AGS_Form.GetChild(1).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttfFont;
    UIButton component3 = this.AGS_Form.GetChild(7).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    ((Component) component3).gameObject.SetActive(false);
    component3.m_BtnID1 = 2;
    UIText component4 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
    component4.font = ttfFont;
    component4.text = DataManager.Instance.mStringTable.GetStringByID(1050U);
    Vector3 localPosition1 = this.AGS_Form.GetChild(1).localPosition with
    {
      z = -1000f
    };
    this.AGS_Form.GetChild(1).localPosition = localPosition1;
    this.AGS_Form.GetChild(1).gameObject.SetActive(false);
    Vector3 localPosition2 = this.AGS_Form.GetChild(5).localPosition with
    {
      z = -1000f
    };
    this.AGS_Form.GetChild(5).localPosition = localPosition2;
    uTweenPosition component5 = this.AGS_Form.GetChild(6).GetComponent<uTweenPosition>();
    component5.from.z = -1000f;
    component5.to.z = -1000f;
    this.Pos3D1 = this.AGS_Form.GetChild(2).transform;
    this.Pos3D1.localPosition = this.Pos3D1.localPosition with
    {
      z = -500f
    };
    this.Pos3D1.localEulerAngles = new Vector3(0.0f, 340f, 0.0f);
    this.Pos3D1.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, -28f);
    this.Pos3D2 = this.AGS_Form.GetChild(3).transform;
    this.Pos3D2.localPosition = this.Pos3D2.localPosition with
    {
      z = -500f
    };
    this.Pos3D2.localEulerAngles = new Vector3(0.0f, 20f, 0.0f);
    this.Pos3D2.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, -28f);
    this.AGS_Form.GetChild(0).gameObject.SetActive(true);
    this.LightGroup = this.AGS_Form.GetChild(4);
    this.PosLight1 = this.AGS_Form.GetChild(4).GetChild(0);
    this.PosLight2 = this.AGS_Form.GetChild(4).GetChild(1);
    GameObject gameObject = new GameObject("Light3");
    gameObject.transform.SetParent(this.LightGroup, false);
    this.PosLight3 = gameObject.transform;
    gameObject.AddComponent<Light>();
    Light component6 = this.PosLight1.GetComponent<Light>();
    component6.range = 15f;
    component6.spotAngle = 10f;
    component6.color = (Color) new Color32((byte) 195, (byte) 87, (byte) 54, byte.MaxValue);
    component6.type = LightType.Spot;
    component6.intensity = 8f;
    Light component7 = this.PosLight2.GetComponent<Light>();
    component7.type = LightType.Spot;
    component7.range = 24f;
    component7.spotAngle = 10f;
    component7.color = (Color) new Color32((byte) 242, (byte) 224, (byte) 205, byte.MaxValue);
    component7.intensity = 8f;
    Light component8 = this.PosLight3.GetComponent<Light>();
    component8.range = 15f;
    component8.spotAngle = 10f;
    component8.color = (Color) new Color32((byte) 148, (byte) 107, (byte) 107, byte.MaxValue);
    component8.type = LightType.Spot;
    component8.intensity = 5.5f;
    this.EvoLight = RenderSettings.ambientLight;
    RenderSettings.ambientLight = (Color) new Color32((byte) 197, (byte) 178, (byte) 178, byte.MaxValue);
    this.startTalkId = (ushort) arg1;
    if (this.startTalkId == (ushort) 13)
      ((Component) component3).gameObject.SetActive(NewbieManager.IsNewbie);
    else
      ((Component) component3).gameObject.SetActive(false);
    if (arg2 != 0)
      UIHeroTalk.HeroID1 = (ushort) arg2;
    this.talkString = StringManager.Instance.SpawnString(500);
    for (ushort Index = 0; (int) Index < DataManager.Instance.HeroTalkTable.TableCount; ++Index)
    {
      HeroTalkTbl recordByIndex = DataManager.Instance.HeroTalkTable.GetRecordByIndex((int) Index);
      if ((int) recordByIndex.TalkGroup == (int) this.startTalkId)
      {
        this.startTalkId = recordByIndex.ID;
        break;
      }
    }
    this.SetTalk(this.startTalkId);
    ((Component) GUIManager.Instance.m_WindowsTransform).gameObject.SetActive(false);
    this.Create3DObjects();
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1:
        if (UIHeroTalk.lockInput)
          break;
        if ((int) this.talkData.TalkGroup == (int) DataManager.Instance.HeroTalkTable.GetRecordByKey((ushort) ((uint) this.nowTalkId + 1U)).TalkGroup)
        {
          this.SetTalk((ushort) ((uint) this.nowTalkId + 1U));
          break;
        }
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_HeroTalk);
        DataManager.msgBuffer[0] = (byte) 2;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
      case 2:
        NewbieManager.Get().SkipForceNewbie();
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_HeroTalk);
        break;
    }
  }

  public void SetTalk(ushort talkID)
  {
    this.nowTalkId = talkID;
    this.talkData = DataManager.Instance.HeroTalkTable.GetRecordByKey(talkID);
    switch (this.talkData.ShowRole)
    {
      case 2:
        UIHeroTalk.HeroID1 = (ushort) 101;
        break;
      case 3:
        UIHeroTalk.HeroID1 = DataManager.Instance.curHeroData[DataManager.Instance.sortHeroData[new System.Random().Next((int) DataManager.Instance.CurHeroDataCount)]].ID;
        CString Name = StringManager.Instance.StaticString1024();
        Name.IntToFormat((long) UIHeroTalk.HeroID1, 5);
        Name.AppendFormat("Role/hero_{0}");
        if (!AssetManager.GetAssetBundleDownload(Name, AssetPath.Role, AssetType.Hero, UIHeroTalk.HeroID1))
        {
          UIHeroTalk.HeroID1 = (ushort) 101;
          break;
        }
        if (!this.CheckCanSelectById(UIHeroTalk.HeroID1))
        {
          UIHeroTalk.HeroID1 = (ushort) 101;
          break;
        }
        break;
    }
    UIHeroTalk.HeroID2 = this.talkData.NPCID;
    this.hero1 = DataManager.Instance.HeroTable.GetRecordByKey(UIHeroTalk.HeroID1);
    this.hero2 = DataManager.Instance.HeroTable.GetRecordByKey(UIHeroTalk.HeroID2);
    if (this.talkData.Enemytalk == (byte) 0)
    {
      this.AGS_Form.GetChild(1).localScale = new Vector3(-1f, 1f, 1f);
      this.AGS_Form.GetChild(1).GetChild(0).localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
      this.AGS_Form.GetChild(1).GetChild(1).GetChild(0).localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
      this.AGS_Form.GetChild(1).GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID((uint) this.hero1.HeroTitle);
      this.PosLight1.SetParent(this.Pos3D1);
      this.PosLight2.SetParent(this.Pos3D1);
      this.PosLight3.SetParent(this.Pos3D2);
      this.PosLight1.localPosition = new Vector3(-256.35f, -124.16f, 456.18f);
      this.PosLight2.localPosition = new Vector3(-244.53f, 1105.84f, -817.82f);
      this.PosLight3.localPosition = new Vector3(76.94f, 464.84f, 296.185f);
      this.PosLight1.LookAt(this.Pos3D1.position);
      this.PosLight2.LookAt(this.Pos3D1.position);
      this.PosLight3.LookAt(this.Pos3D2.position);
    }
    else
    {
      this.AGS_Form.GetChild(1).localScale = Vector3.one;
      this.AGS_Form.GetChild(1).GetChild(0).localEulerAngles = Vector3.zero;
      this.AGS_Form.GetChild(1).GetChild(1).GetChild(0).localEulerAngles = Vector3.zero;
      this.AGS_Form.GetChild(1).GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID((uint) this.hero2.HeroTitle);
      this.PosLight1.SetParent(this.Pos3D2);
      this.PosLight2.SetParent(this.Pos3D2);
      this.PosLight3.SetParent(this.Pos3D1);
      this.PosLight1.localPosition = new Vector3(-256.35f, -124.16f, 456.18f);
      this.PosLight2.localPosition = new Vector3(-244.53f, 1105.84f, -817.82f);
      this.PosLight3.localPosition = new Vector3(76.94f, 464.84f, 296.185f);
      this.PosLight1.LookAt(this.Pos3D2.position);
      this.PosLight2.LookAt(this.Pos3D2.position);
      this.PosLight3.LookAt(this.Pos3D1.position);
      Debug.Log((object) this.Pos3D1.position);
      Debug.Log((object) this.PosLight1.position);
    }
    UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.talkString.ClearString();
    this.talkString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) this.hero1.HeroTitle));
    this.talkString.AppendFormat(DataManager.Instance.mStringTable.GetStringByID((uint) this.talkData.StringID));
    component.text = this.talkString.ToString();
    component.SetAllDirty();
    component.cachedTextGenerator.Invalidate();
    if (this.talkData.ShowRole == (byte) 0)
      this.Pos3D1.gameObject.SetActive(false);
    else
      this.Pos3D1.gameObject.SetActive(true);
    if (this.talkData.NPCID == (ushort) 0)
      this.Pos3D2.gameObject.SetActive(false);
    else
      this.Pos3D2.gameObject.SetActive(true);
  }

  private void Create3DObjects()
  {
    if (this.LoadingStep > UIHeroTalk.e_LoadingStep.Ready)
      this.Destory3DObject();
    this.LoadingStep = UIHeroTalk.e_LoadingStep.Ready;
    if (UIHeroTalk.HeroID1 != (ushort) 0)
    {
      this.hero1 = DataManager.Instance.HeroTable.GetRecordByKey(UIHeroTalk.HeroID1);
      this.LoadModel(this.hero1, out this.AssetKey1);
      this.LoadingStep = UIHeroTalk.e_LoadingStep.WaitFirst;
    }
    else
    {
      this.hero2 = DataManager.Instance.HeroTable.GetRecordByKey(UIHeroTalk.HeroID2);
      this.LoadModel(this.hero2, out this.AssetKey2);
      this.LoadingStep = UIHeroTalk.e_LoadingStep.WaitSecend;
    }
  }

  private void LoadModel(Hero herodata, out int AssetKey)
  {
    if (herodata.HeroKey == (ushort) 101)
    {
      this.bundle = AssetManager.GetAssetBundle("Role/Priest", out AssetKey);
      this.bundleRequest = this.bundle.LoadAsync("Priest", typeof (GameObject));
    }
    else
    {
      CString Name = StringManager.Instance.StaticString1024();
      Name.IntToFormat((long) herodata.Modle, 5);
      Name.AppendFormat("Role/hero_{0}");
      this.bundle = AssetManager.GetAssetBundle(Name, out AssetKey);
      if ((UnityEngine.Object) this.bundle == (UnityEngine.Object) null)
      {
        Name.ClearString();
        Name.IntToFormat(1L, 5);
        Name.AppendFormat("Role/hero_{0}");
        this.bundle = AssetManager.GetAssetBundle(Name, out AssetKey);
      }
      this.bundleRequest = this.bundle.LoadAsync("m", typeof (GameObject));
    }
  }

  private void Destory3DObject()
  {
    if ((UnityEngine.Object) this.Holder1 != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.Holder1);
      this.Holder1 = (GameObject) null;
    }
    if ((UnityEngine.Object) this.Holder2 != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.Holder2);
      this.Holder2 = (GameObject) null;
    }
    this.bundle = (AssetBundle) null;
    if (this.AssetKey1 != 0)
      AssetManager.UnloadAssetBundle(this.AssetKey1, false);
    if (this.AssetKey2 != 0)
      AssetManager.UnloadAssetBundle(this.AssetKey2, false);
    UnityEngine.Object.Destroy((UnityEngine.Object) this.Pos3D1.gameObject);
    UnityEngine.Object.Destroy((UnityEngine.Object) this.Pos3D2.gameObject);
    if ((UnityEngine.Object) this.PosLight1 != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.PosLight1.gameObject);
    if ((UnityEngine.Object) this.PosLight2 != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.PosLight2.gameObject);
    this.LoadingStep = UIHeroTalk.e_LoadingStep.Ready;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.AGS_Form.gameObject.SetActive(true);
        this.resetModelAction();
        break;
      case NetworkNews.Fallout:
        if (NewbieManager.IsNewbie)
          break;
        this.AGS_Form.gameObject.SetActive(false);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.AGS_Form.GetChild(1).GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
    if (!((UnityEngine.Object) component3 != (UnityEngine.Object) null) || !((Behaviour) component3).enabled)
      return;
    ((Behaviour) component3).enabled = false;
    ((Behaviour) component3).enabled = true;
  }

  public void Update()
  {
    switch (this.LoadingStep)
    {
      case UIHeroTalk.e_LoadingStep.WaitFirst:
        if (this.bundleRequest == null || !this.bundleRequest.isDone)
          break;
        this.Pos3D1.gameObject.SetActive(true);
        this.Holder1 = (GameObject) UnityEngine.Object.Instantiate(this.bundleRequest.asset);
        this.Holder1.transform.SetParent(this.Pos3D1, false);
        this.Holder1.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
        {
          eulerAngles = new Vector3(0.0f, 180f, 0.0f)
        };
        this.Holder1.transform.localScale = new Vector3((float) this.hero1.CameraScaleRate, (float) this.hero1.CameraScaleRate, (float) this.hero1.CameraScaleRate);
        this.Holder1.transform.localPosition = Vector3.zero;
        GUIManager.Instance.SetLayer(this.Holder1, 5);
        Transform transform1 = this.Holder1.transform;
        if ((UnityEngine.Object) transform1 != (UnityEngine.Object) null)
        {
          Animation component = transform1.GetComponent<Animation>();
          component[AnimationUnit.ANIM_STRING[0]].layer = 0;
          component[AnimationUnit.ANIM_STRING[0]].wrapMode = WrapMode.Loop;
          component.Play(AnimationUnit.ANIM_STRING[0]);
          SkinnedMeshRenderer componentInChildren = transform1.GetComponentInChildren<SkinnedMeshRenderer>();
          if ((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null)
          {
            componentInChildren.useLightProbes = false;
            componentInChildren.updateWhenOffscreen = true;
          }
        }
        if (UIHeroTalk.HeroID2 != (ushort) 0)
        {
          this.LoadModel(this.hero2, out this.AssetKey2);
          this.LoadingStep = UIHeroTalk.e_LoadingStep.WaitSecend;
        }
        else
        {
          this.LoadingStep = UIHeroTalk.e_LoadingStep.Done;
          this.AGS_Form.GetChild(1).gameObject.SetActive(true);
        }
        if (this.talkData.ShowRole == (byte) 0)
          this.Pos3D1.gameObject.SetActive(false);
        else
          this.Pos3D1.gameObject.SetActive(true);
        if (this.talkData.NPCID == (ushort) 0)
        {
          this.Pos3D2.gameObject.SetActive(false);
          break;
        }
        this.Pos3D2.gameObject.SetActive(true);
        break;
      case UIHeroTalk.e_LoadingStep.WaitSecend:
        if (!this.bundleRequest.isDone)
          break;
        this.Holder2 = (GameObject) UnityEngine.Object.Instantiate(this.bundleRequest.asset);
        this.Holder2.transform.SetParent(this.Pos3D2, false);
        this.Holder2.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
        {
          eulerAngles = new Vector3(0.0f, 180f, 0.0f)
        };
        this.Holder2.transform.localScale = new Vector3((float) this.hero2.CameraScaleRate, (float) this.hero2.CameraScaleRate, (float) this.hero2.CameraScaleRate);
        this.Holder2.transform.localPosition = Vector3.zero;
        GUIManager.Instance.SetLayer(this.Holder2, 5);
        Transform transform2 = this.Holder2.transform;
        if ((UnityEngine.Object) transform2 != (UnityEngine.Object) null)
        {
          Animation component = transform2.GetComponent<Animation>();
          component[AnimationUnit.ANIM_STRING[0]].layer = 0;
          component[AnimationUnit.ANIM_STRING[0]].wrapMode = WrapMode.Loop;
          component.Play(AnimationUnit.ANIM_STRING[0]);
          SkinnedMeshRenderer componentInChildren = transform2.GetComponentInChildren<SkinnedMeshRenderer>();
          if ((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null)
          {
            componentInChildren.useLightProbes = false;
            componentInChildren.updateWhenOffscreen = true;
          }
        }
        this.LoadingStep = UIHeroTalk.e_LoadingStep.Done;
        this.AGS_Form.GetChild(1).gameObject.SetActive(true);
        break;
    }
  }

  public void resetModelAction()
  {
    if ((UnityEngine.Object) this.Holder1 == (UnityEngine.Object) null)
      return;
    Animation component1 = this.Holder1.GetComponent<Animation>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
    {
      component1[AnimationUnit.ANIM_STRING[0]].layer = 0;
      component1[AnimationUnit.ANIM_STRING[0]].wrapMode = WrapMode.Loop;
      component1.Play(AnimationUnit.ANIM_STRING[0]);
    }
    if (!((UnityEngine.Object) this.Holder2 != (UnityEngine.Object) null))
      return;
    Animation component2 = this.Holder2.GetComponent<Animation>();
    if (!((UnityEngine.Object) component2 != (UnityEngine.Object) null))
      return;
    component2[AnimationUnit.ANIM_STRING[0]].layer = 0;
    component2[AnimationUnit.ANIM_STRING[0]].wrapMode = WrapMode.Loop;
    component2.Play(AnimationUnit.ANIM_STRING[0]);
  }

  public override void OnClose()
  {
    UIHeroTalk.lockInput = false;
    ((Component) GUIManager.Instance.m_WindowsTransform).gameObject.SetActive(true);
    this.Destory3DObject();
    StringManager.Instance.DeSpawnString(this.talkString);
    RenderSettings.ambientLight = this.EvoLight;
  }

  private bool CheckCanSelectById(ushort id)
  {
    DataManager instance = DataManager.Instance;
    for (int index = 0; (long) index < (long) instance.FightHeroCount; ++index)
    {
      if ((int) instance.GetLeaderID() == (int) id && (instance.beCaptured.nowCaptureStat == LoadCaptureState.Captured || instance.beCaptured.nowCaptureStat == LoadCaptureState.Dead) || (int) instance.FightHeroID[index] == (int) id)
        return false;
    }
    return true;
  }

  private enum e_AGS_UI_HeroTalk_Editor
  {
    Back,
    Panel,
    T3DO1,
    T3DO2,
    Light,
    Image,
    Image2,
    skip,
  }

  private enum e_AGS_Panel
  {
    Text,
    Title,
  }

  private enum e_AGS_Title
  {
    Text,
  }

  private enum e_LoadingStep
  {
    Nothing,
    Ready,
    WaitFirst,
    WaitSecend,
    Done,
  }
}
