// Decompiled with JetBrains decompiler
// Type: Pet3DLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
internal class Pet3DLoader
{
  private string[] ANIM_STR = new string[7]
  {
    "idle",
    "moving",
    "attack",
    "skill_1",
    "skill_2",
    "skill_3",
    "victory"
  };
  private AssetBundle m_AssetBundle;
  private AssetBundleRequest m_ABRequest;
  private int AssetKey;
  private bool IsDone = true;
  private Transform m_PetTransform;
  private Transform m_PetModel;
  private Animation m_Animation;
  private GameObject assetObject;
  private ushort ID;
  private float m_ChangeTime;
  private CString m_Str;
  private PetTbl sPet;
  private Hero sHero;
  private PetData petData;
  private bool bMaxShow = true;

  public Pet3DLoader(Transform transform, ushort id)
  {
    this.m_PetTransform = transform;
    this.ID = id;
    this.m_Str = StringManager.Instance.SpawnString();
  }

  public void LoadPet()
  {
    this.sPet = PetManager.Instance.PetTable.GetRecordByKey(this.ID);
    this.sHero = DataManager.Instance.HeroTable.GetRecordByKey(this.sPet.HeroID);
    this.petData = PetManager.Instance.FindPetData(this.ID);
    CString Name = StringManager.Instance.StaticString1024();
    Name.IntToFormat((long) this.sHero.Modle, 5);
    Name.AppendFormat("Role/hero_{0}");
    if (!AssetManager.GetAssetBundleDownload(Name, AssetPath.Role, AssetType.Hero, this.sHero.Modle))
      return;
    this.m_AssetBundle = AssetManager.GetAssetBundle(Name, out this.AssetKey);
    if (!((Object) this.m_AssetBundle != (Object) null))
      return;
    this.m_ABRequest = this.m_AssetBundle.LoadAsync("m", typeof (GameObject));
    this.IsDone = false;
  }

  public void Update()
  {
    if (this.IsDone || this.m_ABRequest == null || !this.m_ABRequest.isDone || this.petData == null)
      return;
    this.assetObject = ModelLoader.Instance.Load(this.sHero.Modle, this.m_AssetBundle, (ushort) this.sHero.TextureNo);
    this.assetObject.transform.SetParent(this.m_PetTransform, false);
    this.assetObject.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
    {
      eulerAngles = new Vector3(0.0f, 180f, 0.0f)
    };
    this.assetObject.transform.localScale = this.bMaxShow || (int) this.petData.Enhance >= this.sPet.PetRatio.Length ? new Vector3((float) this.sPet.StartupRatio.Ratio, (float) this.sPet.StartupRatio.Ratio, (float) this.sPet.StartupRatio.Ratio) : new Vector3((float) this.sPet.PetRatio[(int) this.petData.Enhance].Ratio, (float) this.sPet.PetRatio[(int) this.petData.Enhance].Ratio, (float) this.sPet.PetRatio[(int) this.petData.Enhance].Ratio);
    this.assetObject.transform.localPosition = Vector3.zero;
    GUIManager.Instance.SetLayer(this.assetObject, 5);
    if (!this.bMaxShow && (int) this.petData.Enhance < this.sPet.PetRatio.Length)
      ((RectTransform) this.m_PetTransform).anchoredPosition = new Vector2(((RectTransform) this.m_PetTransform).anchoredPosition.x, (float) (-140 - (1000 - (int) this.sPet.PetRatio[(int) this.petData.Enhance].UpDownDist)));
    else
      ((RectTransform) this.m_PetTransform).anchoredPosition = new Vector2(((RectTransform) this.m_PetTransform).anchoredPosition.x, (float) (-140 - (1000 - (int) this.sPet.StartupRatio.UpDownDist)));
    this.m_PetModel = this.m_PetTransform.GetChild(0);
    if ((Object) this.m_PetModel != (Object) null)
    {
      if (this.m_PetTransform.gameObject.activeSelf)
      {
        SkinnedMeshRenderer componentInChildren = this.m_PetModel.GetComponentInChildren<SkinnedMeshRenderer>();
        if ((Object) componentInChildren != (Object) null)
        {
          componentInChildren.useLightProbes = false;
          componentInChildren.updateWhenOffscreen = true;
        }
      }
      this.m_Animation = this.m_PetModel.GetComponent<Animation>();
      if ((Object) this.m_Animation != (Object) null)
      {
        this.m_Animation.wrapMode = WrapMode.Loop;
        AnimationState animationState = this.m_Animation[this.ANIM_STR[6]];
        if ((TrackedReference) animationState != (TrackedReference) null)
        {
          animationState.layer = 1;
          animationState.wrapMode = WrapMode.Loop;
          this.m_Animation.CrossFade(this.ANIM_STR[6]);
          this.m_Animation.clip = this.m_Animation.GetClip(this.ANIM_STR[6]);
        }
      }
    }
    this.IsDone = true;
  }

  public void Destory()
  {
    if ((Object) this.assetObject != (Object) null)
    {
      this.assetObject.transform.SetParent(this.m_PetTransform.parent, false);
      ModelLoader.Instance.Unload((Object) this.assetObject);
      this.assetObject = (GameObject) null;
    }
    if ((Object) this.m_PetModel != (Object) null)
    {
      Object.Destroy((Object) this.m_PetModel);
      this.m_PetModel = (Transform) null;
    }
    AssetManager.UnloadAssetBundle(this.AssetKey);
  }

  private void RandAnimation()
  {
    if (!((Object) this.m_Animation != (Object) null))
      return;
    int index = Random.Range(0, this.ANIM_STR.Length);
    this.m_Animation.wrapMode = WrapMode.Loop;
    AnimationState animationState = this.m_Animation[this.ANIM_STR[index]];
    if (!((TrackedReference) animationState != (TrackedReference) null))
      return;
    animationState.layer = 1;
    animationState.wrapMode = WrapMode.Loop;
    this.m_Animation.CrossFade(this.ANIM_STR[index]);
    this.m_Animation.clip = this.m_Animation.GetClip(this.ANIM_STR[index]);
  }
}
