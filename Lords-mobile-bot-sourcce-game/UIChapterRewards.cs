// Decompiled with JetBrains decompiler
// Type: UIChapterRewards
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIChapterRewards : GUIWindow, IUIButtonClickHandler, IUIHIBtnClickHandler
{
  private Transform GameT;
  private Transform Tmp;
  private Transform Hero_Model;
  private Transform Hero_Pos;
  private Transform LightT1;
  private RectTransform Hero_PosRT;
  private RectTransform ContentRT;
  private RectTransform tmpRC;
  private UIButton btn_EXIT;
  private UIButton btn_Back;
  private UIHIBtn[] Hbtn_Itme = new UIHIBtn[5];
  private UIHIBtn Hbtn_go;
  private UIHIBtn Hbtn_Hero;
  private Image Img_Mask;
  private Image Img_Rewards;
  private Image Img_Chapter;
  private Image Img_Exit;
  private UIText text_Item;
  private UIText[] text_tmpStr = new UIText[4];
  private DataManager DM;
  private GUIManager GUIM;
  private Font TTFont;
  private Door door;
  private Material mMaT;
  private Hero sHero;
  private AssetBundle AB;
  private AssetBundleRequest AR;
  private bool ABIsDone;
  private GameObject go2;
  private int AssetKey;
  private Animation tmpAN;
  private GameObject tmpGo;
  private string HeroAct;
  private float MovingTimer;
  private float ActionTime;
  private float ActionTimeRandom;
  public ushort ShowHeroID;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.mMaT = this.door.LoadMaterial();
    Chapter recordByKey = DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort) arg1);
    this.sHero = this.DM.HeroTable.GetRecordByKey(recordByKey.HeroID);
    this.ShowHeroID = this.sHero.Modle;
    int num = 0;
    for (int index = 0; index < 5; ++index)
    {
      if (recordByKey.Items[index].ItemID != (ushort) 0)
        ++num;
    }
    this.Hero_Pos = this.GameT.GetChild(0);
    this.Hero_PosRT = this.Hero_Pos.GetComponent<RectTransform>();
    this.text_tmpStr[0] = this.GameT.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[0].font = this.TTFont;
    this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID((uint) this.sHero.HeroTitle);
    this.text_tmpStr[1] = this.GameT.GetChild(1).GetChild(1).GetComponent<UIText>();
    this.text_tmpStr[1].font = this.TTFont;
    this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID((uint) this.sHero.HeroName);
    this.Hbtn_Hero = this.GameT.GetChild(3).GetChild(2).GetComponent<UIHIBtn>();
    this.Hbtn_Hero.m_Handler = (IUIHIBtnClickHandler) this;
    this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Hero).transform, eHeroOrItem.Item, recordByKey.Hero_ItemID, (byte) 0, (byte) 0, (int) recordByKey.Hero_ItemNum);
    this.text_Item = this.GameT.GetChild(3).GetChild(4).GetComponent<UIText>();
    this.text_Item.font = this.TTFont;
    this.Hbtn_go = this.GameT.GetChild(4).GetComponent<UIHIBtn>();
    this.Hbtn_go.m_Handler = (IUIHIBtnClickHandler) this;
    this.Hbtn_go.SoundIndex = (byte) 64;
    this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_go).transform, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0);
    this.Img_Mask = this.GameT.GetChild(5).GetComponent<Image>();
    UIButtonHint.m_scrollRect = ((Component) this.Img_Mask).transform.GetComponent<ScrollRect>();
    this.ContentRT = this.GameT.GetChild(5).GetChild(0).GetComponent<RectTransform>();
    float x = 10f;
    for (int index = 0; index < num; ++index)
    {
      this.tmpGo = (GameObject) Object.Instantiate((Object) ((Component) this.Hbtn_go).gameObject);
      this.tmpGo.transform.SetParent(((Component) this.ContentRT).transform, false);
      this.tmpRC = this.tmpGo.GetComponent<RectTransform>();
      this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x + (float) (93 * index), this.tmpRC.anchoredPosition.y);
      this.tmpGo.SetActive(true);
      x += 93f;
      this.GUIM.ChangeHeroItemImg(this.tmpGo.transform, eHeroOrItem.Item, recordByKey.Items[index].ItemID, (byte) 0, (byte) 0, (int) recordByKey.Items[index].ItemNum);
      this.Hbtn_Itme[index] = this.tmpGo.GetComponent<UIHIBtn>();
    }
    this.ContentRT.sizeDelta = new Vector2(x, this.ContentRT.sizeDelta.y);
    this.Tmp = this.GameT.GetChild(7);
    this.Img_Chapter = this.Tmp.GetComponent<Image>();
    this.text_tmpStr[2] = this.Tmp.GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[2].font = this.TTFont;
    this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(1589U);
    this.Tmp = this.GameT.GetChild(8);
    this.Img_Rewards = this.Tmp.GetComponent<Image>();
    this.LightT1 = this.Tmp.GetChild(2);
    this.text_tmpStr[3] = this.Tmp.GetChild(3).GetComponent<UIText>();
    this.text_tmpStr[3].font = this.TTFont;
    this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(1591U);
    this.btn_Back = this.GameT.GetChild(10).GetComponent<UIButton>();
    this.btn_Back.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Back.m_BtnID1 = 1;
    this.btn_Back.m_EffectType = e_EffectType.e_Scale;
    this.btn_Back.transition = (Selectable.Transition) 0;
    this.Img_Exit = this.GameT.GetChild(11).GetComponent<Image>();
    this.Img_Exit.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.Img_Exit).material = this.mMaT;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.Img_Exit).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(11).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.mMaT;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    if (arg2 == 0)
    {
      ((Component) this.Img_Chapter).gameObject.SetActive(true);
      ((Component) this.Img_Exit).gameObject.SetActive(true);
      ((Component) this.btn_EXIT).gameObject.SetActive(true);
      this.text_Item.text = this.DM.mStringTable.GetStringByID(1590U);
    }
    else
    {
      ((Component) this.Img_Rewards).gameObject.SetActive(true);
      ((Component) this.btn_Back).gameObject.SetActive(true);
      this.text_Item.text = this.DM.mStringTable.GetStringByID(323U);
      AudioManager.Instance.PlayMP3SFX((ushort) 41011);
    }
    this.Hero3D_Destroy();
    this.LoadHero3D();
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 1);
  }

  public void Hero3D_Destroy()
  {
    if ((Object) this.go2 != (Object) null)
    {
      this.go2.transform.SetParent(this.Hero_Pos.parent, false);
      Object.Destroy((Object) this.go2);
    }
    if ((Object) this.Hero_Model != (Object) null)
      Object.Destroy((Object) this.Hero_Model);
    this.Hero_Model = (Transform) null;
    this.go2 = (GameObject) null;
    AssetManager.UnloadAssetBundle(this.AssetKey, false);
  }

  public void LoadHero3D()
  {
    this.ActionTime = 0.0f;
    this.ActionTimeRandom = 2f;
    CString Name = StringManager.Instance.StaticString1024();
    Name.IntToFormat((long) this.sHero.Modle, 5);
    Name.AppendFormat("Role/hero_{0}");
    if (AssetManager.GetAssetBundleDownload(Name, AssetPath.Role, AssetType.Hero, this.sHero.Modle))
    {
      this.AB = AssetManager.GetAssetBundle(Name, out this.AssetKey);
      if (!((Object) this.AB != (Object) null))
        return;
      this.AR = this.AB.LoadAsync("m", typeof (GameObject));
      this.ABIsDone = false;
    }
    else
      this.AR = (AssetBundleRequest) null;
  }

  public void HeroActionChang()
  {
    if (!this.ABIsDone || !((Object) this.Hero_Model != (Object) null))
      return;
    this.tmpAN = this.Hero_Model.GetComponent<Animation>();
    this.tmpAN.wrapMode = WrapMode.Loop;
    if ((Object) this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[2]) != (Object) null)
    {
      this.HeroAct = AnimationUnit.ANIM_STRING[2];
      this.tmpAN[AnimationUnit.ANIM_STRING[2]].layer = 1;
      this.tmpAN[AnimationUnit.ANIM_STRING[2]].wrapMode = WrapMode.Once;
    }
    if ((Object) this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[3]) != (Object) null)
    {
      this.HeroAct = AnimationUnit.ANIM_STRING[3];
      this.tmpAN[AnimationUnit.ANIM_STRING[3]].layer = 1;
      this.tmpAN[AnimationUnit.ANIM_STRING[3]].wrapMode = WrapMode.Once;
    }
    if ((Object) this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[4]) != (Object) null)
    {
      this.HeroAct = AnimationUnit.ANIM_STRING[4];
      this.tmpAN[AnimationUnit.ANIM_STRING[4]].layer = 1;
      this.tmpAN[AnimationUnit.ANIM_STRING[4]].wrapMode = WrapMode.Once;
    }
    if ((Object) this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[5]) != (Object) null)
    {
      this.HeroAct = AnimationUnit.ANIM_STRING[5];
      this.tmpAN[AnimationUnit.ANIM_STRING[5]].layer = 1;
      this.tmpAN[AnimationUnit.ANIM_STRING[5]].wrapMode = WrapMode.Once;
    }
    int index = Random.Range(1, 6);
    AnimationClip animationClip = this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[(int) (byte) index]);
    this.HeroAct = AnimationUnit.ANIM_STRING[(int) (byte) index];
    if (index == 3 && (Object) this.tmpAN.GetClip(this.HeroAct + "_ch") != (Object) null)
      animationClip = (AnimationClip) null;
    if ((Object) animationClip != (Object) null)
    {
      this.tmpAN.CrossFade(animationClip.name);
      this.MovingTimer = 0.0f;
      if (index == 1)
        this.MovingTimer = 2f;
    }
    this.ActionTimeRandom = 0.0f;
    this.ActionTime = 0.0f;
  }

  public override void OnClose()
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    switch ((ChapterRewards_btn) sender.m_BtnID1)
    {
      case ChapterRewards_btn.btn_EXIT:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case ChapterRewards_btn.btn_Back:
        if ((int) DataManager.StageDataController.limitRecord[(int) DataManager.StageDataController._stageMode] > (int) DataManager.StageDataController.StageRecord[(int) DataManager.StageDataController._stageMode])
        {
          DataManager.StageDataController.isNotFirstInChapter[(int) DataManager.StageDataController._stageMode] = (byte) 0;
          DataManager.StageDataController.SaveisNotFirstInChapter();
        }
        DataManager.msgBuffer[0] = (byte) 39;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
    }
  }

  public override bool OnBackButtonClick()
  {
    if (!((UIBehaviour) this.btn_Back).IsActive())
      return false;
    if ((int) DataManager.StageDataController.limitRecord[(int) DataManager.StageDataController._stageMode] > (int) DataManager.StageDataController.StageRecord[(int) DataManager.StageDataController._stageMode])
    {
      DataManager.StageDataController.isNotFirstInChapter[(int) DataManager.StageDataController._stageMode] = (byte) 0;
      DataManager.StageDataController.SaveisNotFirstInChapter();
    }
    DataManager.msgBuffer[0] = (byte) 39;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    return true;
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        break;
      case NetworkNews.Refresh:
        break;
      case NetworkNews.Refresh_Asset:
        if (meg[1] != (byte) 1 || meg[2] != (byte) 2 || (int) GameConstants.ConvertBytesToUShort(meg, 3) != (int) this.ShowHeroID)
          break;
        this.Hero3D_Destroy();
        this.LoadHero3D();
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Item != (Object) null && ((Behaviour) this.text_Item).enabled)
    {
      ((Behaviour) this.text_Item).enabled = false;
      ((Behaviour) this.text_Item).enabled = true;
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
    if ((Object) this.Hbtn_Hero != (Object) null && ((Behaviour) this.Hbtn_Hero).enabled)
      this.Hbtn_Hero.Refresh_FontTexture();
    if ((Object) this.Hbtn_go != (Object) null && ((Behaviour) this.Hbtn_go).enabled)
      this.Hbtn_go.Refresh_FontTexture();
    for (int index = 0; index < 5; ++index)
    {
      if ((Object) this.Hbtn_Itme[index] != (Object) null && ((Behaviour) this.Hbtn_Itme[index]).enabled)
        this.Hbtn_Itme[index].Refresh_FontTexture();
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
    if ((Object) this.LightT1 != (Object) null)
      this.LightT1.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    if (!this.ABIsDone && this.AR != null && this.AR.isDone)
    {
      this.go2 = (GameObject) Object.Instantiate(this.AR.asset);
      this.go2.transform.SetParent(this.Hero_Pos, false);
      this.go2.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
      {
        eulerAngles = new Vector3(0.0f, (float) this.sHero.Camera_Horizontal, 0.0f)
      };
      this.go2.transform.localScale = new Vector3((float) this.sHero.CameraScaleRate, (float) this.sHero.CameraScaleRate, (float) this.sHero.CameraScaleRate);
      this.go2.transform.localPosition = Vector3.zero;
      this.GUIM.SetLayer(this.go2, 5);
      this.Hero_PosRT.anchoredPosition = new Vector2(this.Hero_PosRT.anchoredPosition.x, (float) (-180 - (1000 - (int) this.sHero.CameraDistance)));
      this.Tmp = this.Hero_Pos.GetChild(0);
      this.Hero_Model = this.Tmp.GetComponent<Transform>();
      if ((Object) this.Hero_Model != (Object) null)
      {
        this.tmpAN = this.Hero_Model.GetComponent<Animation>();
        this.tmpAN.wrapMode = WrapMode.Loop;
        this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
        this.tmpAN.Play(AnimationUnit.ANIM_STRING[0]);
        this.tmpAN.clip = this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[0]);
        if (this.Hero_Pos.gameObject.activeSelf)
        {
          SkinnedMeshRenderer componentInChildren = this.Hero_Model.GetComponentInChildren<SkinnedMeshRenderer>();
          componentInChildren.useLightProbes = false;
          componentInChildren.updateWhenOffscreen = true;
        }
      }
      this.ABIsDone = true;
    }
    if (this.ABIsDone && (Object) this.Hero_Model != (Object) null && (!this.tmpAN.IsPlaying(this.HeroAct) || this.HeroAct == "idle") && (double) this.ActionTimeRandom < 0.0001)
    {
      this.ActionTimeRandom = (float) Random.Range(3, 7);
      this.ActionTime = 0.0f;
    }
    if ((double) this.ActionTimeRandom > 0.0001)
    {
      this.ActionTime += Time.smoothDeltaTime;
      if ((double) this.ActionTime >= (double) this.ActionTimeRandom)
        this.HeroActionChang();
    }
    if (!this.ABIsDone || !((Object) this.Hero_Model != (Object) null) || (double) this.MovingTimer <= 0.0)
      return;
    this.MovingTimer -= Time.deltaTime;
    if ((double) this.MovingTimer > 0.0)
      return;
    this.tmpAN.CrossFade("idle");
    this.HeroAct = "idle";
  }
}
