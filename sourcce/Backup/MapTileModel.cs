// Decompiled with JetBrains decompiler
// Type: MapTileModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class MapTileModel
{
  private Transform RealmGroup;
  private Transform ModelLayoutTransform;
  private ushort DebutID = 1;
  private ushort ShowID = 1;
  private ushort ExitID = 1;
  private Transform WeaponTransform;
  private Transform hitParticleRoot;
  private Transform flyRoot;
  private int WeaponAssetKey;
  private ushort WeaponModelID = 1;
  private float WeaponScaleFrom = 1f;
  private float WeaponScaleTo = 1f;
  private float WeaponScaleTime;
  private float WeaponScaleTimeTarget;
  private ushort WeaponScaleKeyFrameID;
  private float WeaponRotationXFrom;
  private float WeaponRotationYFrom;
  private float WeaponRotationZFrom;
  private float WeaponRotationXTo;
  private float WeaponRotationYTo;
  private float WeaponRotationZTo;
  private float WeaponRotationTime;
  private float WeaponRotationTimeTarget;
  private ushort WeaponRotationKeyFrameID;
  private float WeaponRotationOffSetX;
  private float WeaponRotationOffSetY;
  private float WeaponRotationOffSetZ;
  private float WeaponRotationOffSetTime;
  private float WeaponRotationOffSetTimeTarget;
  private ushort WeaponRotationOffSetKeyFrameID;
  private float WeaponPositionXFrom;
  private float WeaponPositionYFrom;
  private float WeaponPositionZFrom;
  private float WeaponPositionXTo;
  private float WeaponPositionYTo;
  private float WeaponPositionZTo;
  private float WeaponPositionTime;
  private float WeaponPositionTimeTarget;
  private ushort WeaponPositionKeyFrameID;
  private Animation WeaponAnimation;
  private AnimationUnit.AnimName WeaponAnimationName;
  private float WeaponAnimationSpeed = 1f;
  private float WeaponAnimationTime;
  private float WeaponAnimationSpeedTime;
  private float WeaponAnimationSpeedTimeTarget;
  private ushort WeaponAnimationKeyFrameID;
  private Light WeaponLight;
  private Transform WeaponLightTransform;
  private ushort WeaponLightKeyFrameID;
  private float WeaponLightColorRFrom = 1f;
  private float WeaponLightColorGFrom = 1f;
  private float WeaponLightColorBFrom = 1f;
  private float WeaponLightColorRTo = 1f;
  private float WeaponLightColorGTo = 1f;
  private float WeaponLightColorBTo = 1f;
  private float WeaponLightColorTime;
  private float WeaponLightColorTimeTarget;
  private ushort WeaponLightColorKeyFrameID;
  private float WeaponLightRotationXFrom;
  private float WeaponLightRotationYFrom;
  private float WeaponLightRotationZFrom;
  private float WeaponLightRotationXTo;
  private float WeaponLightRotationYTo;
  private float WeaponLightRotationZTo;
  private float WeaponLightRotationTime;
  private float WeaponLightRotationTimeTarget;
  private ushort WeaponLightRotationKeyFrameID;
  private float WeaponLightPositionXFrom;
  private float WeaponLightPositionYFrom;
  private float WeaponLightPositionXTo;
  private float WeaponLightPositionYTo;
  private float WeaponLightPositionTime;
  private float WeaponLightPositionTimeTarget;
  private ushort WeaponLightPositionKeyFrameID;
  private Image UpImage;
  private Image DownImage;
  private RectTransform UpImageRectTransform;
  private RectTransform DownImageRectTransform;
  private float UpDownImagePositionYFrom;
  private float UpDownImagePositionYTo;
  private float UpDownImagePositionTime;
  private float UpDownImagePositionTimeTarget;
  private ushort UpDownImagePositionKeyFrameID;
  private float UpDownImageColorRFrom = 1f;
  private float UpDownImageColorGFrom = 1f;
  private float UpDownImageColorBFrom = 1f;
  private float UpDownImageColorAFrom = 1f;
  private float UpDownImageColorRTo = 1f;
  private float UpDownImageColorGTo = 1f;
  private float UpDownImageColorBTo = 1f;
  private float UpDownImageColorATo = 1f;
  private float UpDownImageColorTime;
  private float UpDownImageColorTimeTarget;
  private ushort UpDownImageColorKeyFrameID;
  private AssetBundle EffectAssetBundle;
  private ParticleSystem WeaponParticle;
  private GameObject WeaponParticleGameObject;
  private Transform AllEffectTransform;
  private int EffectAssetKey;
  private uint WeaponParticleID;
  private float WeaponParticleTime;
  private ushort WeaponParticleKeyFrameID;
  private float WeaponSoundTime;
  private ushort WeaponSoundKeyFrameID;
  private MapTileModel.MapWeaponState mapWeaponState;
  private MapTileModel.MapTileModelUpdateDelegate[] mapTileModelUpdateDelegate;
  private CExternalTableWithWordKey<ShowKindToShowMap> ShowKindToShowMapTable;
  private CExternalTableWithWordKey<ShowMap> ShowMapTable;
  private CExternalTableWithWordKey<ShowAnimation> ShowAnimationTable;
  private CExternalTableWithWordKey<ShowVector3> ShowVector3Table;
  private CExternalTableWithWordKey<ShowLight> ShowLightTable;
  private CExternalTableWithWordKey<ShowColor> ShowColorTable;
  private CExternalTableWithWordKey<ShowEffectSound> ShowEffectSoundTable;
  private List<Transform> Effects = new List<Transform>();
  private List<float> EffectTimes = new List<float>();
  private List<int> EffectsIDs = new List<int>();
  private ParticleSystem.Particle[] particles = new ParticleSystem.Particle[64];
  private StringBuilder sb = new StringBuilder();

  public MapTileModel(Transform realmGroup, float tileBaseScale)
  {
    this.mapTileModelUpdateDelegate = new MapTileModel.MapTileModelUpdateDelegate[4];
    this.mapTileModelUpdateDelegate[0] = new MapTileModel.MapTileModelUpdateDelegate(this.NoneState);
    this.mapTileModelUpdateDelegate[1] = new MapTileModel.MapTileModelUpdateDelegate(this.Debut);
    this.mapTileModelUpdateDelegate[2] = new MapTileModel.MapTileModelUpdateDelegate(this.Show);
    this.mapTileModelUpdateDelegate[3] = new MapTileModel.MapTileModelUpdateDelegate(this.Exit);
    this.ModelLayoutTransform = new GameObject(nameof (MapTileModel)).transform;
    this.RealmGroup = realmGroup;
    this.ModelLayoutTransform.localScale = Vector3.one * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
    this.ModelLayoutTransform.position = Vector3.forward * 33f;
    this.ModelLayoutTransform.SetParent(realmGroup, false);
    this.AllEffectTransform = new GameObject("MapTileModelEffect").transform;
    this.AllEffectTransform.SetParent(this.ModelLayoutTransform, false);
  }

  public void OnDestroy()
  {
    this.Effects.Clear();
    this.EffectTimes.Clear();
    this.EffectsIDs.Clear();
    if (this.EffectAssetKey != 0)
    {
      AssetManager.UnloadAssetBundle(this.EffectAssetKey);
      this.EffectAssetKey = 0;
    }
    if ((Object) this.WeaponParticleGameObject != (Object) null)
    {
      Object.Destroy((Object) this.WeaponParticleGameObject);
      this.WeaponParticleGameObject = (GameObject) null;
      this.WeaponParticle = (ParticleSystem) null;
      this.WeaponParticleID = 0U;
    }
    if ((Object) this.AllEffectTransform != (Object) null)
    {
      Object.Destroy((Object) this.AllEffectTransform.gameObject);
      this.AllEffectTransform = (Transform) null;
    }
    if (this.WeaponAssetKey != 0)
    {
      AssetManager.UnloadAssetBundle(this.WeaponAssetKey);
      this.WeaponAssetKey = 0;
    }
    if ((Object) this.WeaponTransform != (Object) null)
    {
      ModelLoader.Instance.Unload((Object) this.WeaponTransform.gameObject);
      this.hitParticleRoot = (Transform) null;
      this.flyRoot = (Transform) null;
      this.WeaponTransform = (Transform) null;
    }
    if ((Object) this.WeaponLightTransform != (Object) null)
    {
      Object.Destroy((Object) this.WeaponLightTransform.gameObject);
      this.WeaponLightTransform = (Transform) null;
    }
    if ((Object) this.UpImageRectTransform != (Object) null)
    {
      Object.Destroy((Object) ((Component) this.UpImageRectTransform).gameObject);
      this.UpImageRectTransform = (RectTransform) null;
    }
    if (!((Object) this.DownImageRectTransform != (Object) null))
      return;
    Object.Destroy((Object) ((Component) this.DownImageRectTransform).gameObject);
    this.DownImageRectTransform = (RectTransform) null;
  }

  public void MapTileModelUpdate()
  {
    this.mapTileModelUpdateDelegate[(int) this.mapWeaponState]();
    this.MapWeaponEffectParticleUpdate();
  }

  public bool SetWeaponResources(ushort MapWeaponID, ushort MapSkillID)
  {
    if (MapWeaponID < (ushort) 1)
      MapWeaponID = (ushort) 1;
    if ((int) this.WeaponModelID != (int) MapWeaponID)
    {
      if (this.WeaponAssetKey != 0)
      {
        AssetManager.UnloadAssetBundle(this.WeaponAssetKey);
        this.WeaponAssetKey = 0;
      }
      if ((Object) this.WeaponTransform != (Object) null)
      {
        ModelLoader.Instance.Unload((Object) this.WeaponTransform.gameObject);
        this.WeaponTransform = (Transform) null;
      }
      this.WeaponModelID = MapWeaponID;
    }
    MapDamageEffTb recordByKey1 = PetManager.Instance.MapDamageEffTable.GetRecordByKey(PetManager.Instance.PetSkillTable.GetRecordByKey(MapSkillID).DamageRange);
    this.DebutID = recordByKey1.BeginID;
    this.ShowID = recordByKey1.AttackID;
    this.ExitID = recordByKey1.EndID;
    this.LoadShowData();
    CString cstring = StringManager.Instance.SpawnString();
    if ((Object) this.WeaponTransform == (Object) null)
    {
      Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(this.WeaponModelID);
      cstring.ClearString();
      cstring.StringToFormat("Role/hero_");
      cstring.IntToFormat((long) recordByKey2.Modle, 5);
      cstring.AppendFormat("{0}{1}");
      if (!AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, recordByKey2.Modle, true))
        return false;
      AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.WeaponAssetKey);
      if ((Object) assetBundle == (Object) null)
        return false;
      GameObject gameObject = ModelLoader.Instance.Load(recordByKey2.Modle, assetBundle, (ushort) recordByKey2.TextureNo);
      if ((Object) gameObject == (Object) null)
        return false;
      this.WeaponTransform = gameObject.transform;
      this.WeaponTransform.SetParent(this.ModelLayoutTransform, true);
      this.WeaponTransform.localPosition = Vector3.zero;
      this.WeaponTransform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
      this.WeaponAnimation = gameObject.GetComponent<Animation>();
      this.WeaponAnimation.wrapMode = WrapMode.Loop;
      this.WeaponAnimation.Stop();
      Transform child = this.WeaponTransform.GetChild(0);
      Transform[] componentsInChildren = this.WeaponTransform.gameObject.GetComponentsInChildren<Transform>();
      for (int index = 0; index < componentsInChildren.Length; ++index)
      {
        if (componentsInChildren[index].name == AnimationUnit.HIT_POINT_ROOTBONE)
        {
          this.hitParticleRoot = componentsInChildren[index];
          if (!((Object) this.flyRoot == (Object) null))
            break;
        }
        else if (componentsInChildren[index].name == AnimationUnit.FLY_WEAPON_ROOTBONE)
        {
          this.flyRoot = componentsInChildren[index];
          if (!((Object) this.hitParticleRoot == (Object) null))
            break;
        }
      }
      if ((Object) this.hitParticleRoot == (Object) null)
        this.hitParticleRoot = child;
      if ((Object) this.flyRoot == (Object) null)
        this.flyRoot = child;
      gameObject.SetActive(false);
    }
    if ((Object) this.WeaponLightTransform == (Object) null)
    {
      GameObject gameObject = new GameObject("WeaponLight");
      this.WeaponLight = gameObject.AddComponent<Light>();
      this.WeaponLight.type = LightType.Directional;
      this.WeaponLightTransform = gameObject.transform;
      this.WeaponLightTransform.SetParent(this.ModelLayoutTransform, true);
      this.WeaponLightTransform.localPosition = Vector3.zero;
      this.WeaponLightTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
      gameObject.SetActive(false);
    }
    if ((Object) this.UpImageRectTransform == (Object) null)
    {
      GameObject gameObject1 = new GameObject("upImage");
      this.UpImage = gameObject1.AddComponent<Image>();
      int index;
      for (index = 0; index < AssetManager.Instance.Shaders.Length; ++index)
      {
        if (AssetManager.Instance.Shaders[index].name == "zTWRD2 Shaders/UI/Sprites")
        {
          ((MaskableGraphic) this.UpImage).material = new Material((Shader) AssetManager.Instance.Shaders[index]);
          ((MaskableGraphic) this.UpImage).material.renderQueue = 3100;
          break;
        }
      }
      ((Graphic) this.UpImage).color = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.UpImageRectTransform = gameObject1.GetComponent<RectTransform>();
      Vector2 sizeDelta = (((Component) GUIManager.Instance.m_UICanvas).transform as RectTransform).sizeDelta;
      sizeDelta.y *= 0.5f;
      this.UpImageRectTransform.sizeDelta = sizeDelta;
      ((Transform) this.UpImageRectTransform).SetParent((Transform) GUIManager.Instance.m_FourthWindowLayer, false);
      Vector2 zero = Vector2.zero;
      zero.y += sizeDelta.y * 1.5f;
      this.UpImageRectTransform.anchoredPosition = zero;
      gameObject1.SetActive(false);
      GameObject gameObject2 = new GameObject("downImage");
      this.DownImage = gameObject2.AddComponent<Image>();
      ((MaskableGraphic) this.DownImage).material = new Material((Shader) AssetManager.Instance.Shaders[index]);
      ((MaskableGraphic) this.DownImage).material.renderQueue = 3100;
      ((Graphic) this.DownImage).color = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.DownImageRectTransform = gameObject2.GetComponent<RectTransform>();
      this.DownImageRectTransform.sizeDelta = sizeDelta;
      ((Transform) this.DownImageRectTransform).SetParent((Transform) GUIManager.Instance.m_FourthWindowLayer, false);
      zero.y -= sizeDelta.y * 3f;
      this.DownImageRectTransform.anchoredPosition = zero;
      gameObject2.SetActive(false);
    }
    if ((Object) this.EffectAssetBundle == (Object) null)
      this.EffectAssetBundle = AssetManager.GetAssetBundle("Particle/Monster_Effects_604", out this.EffectAssetKey);
    StringManager.Instance.DeSpawnString(cstring);
    return true;
  }

  public void startDebut(float RotationY = 0.0f)
  {
    this.WeaponTransform.gameObject.SetActive(true);
    this.WeaponLightTransform.gameObject.SetActive(true);
    ((Component) this.UpImageRectTransform).gameObject.SetActive(true);
    ((Component) this.DownImageRectTransform).gameObject.SetActive(true);
    ShowKindToShowMap recordByKey1 = this.ShowKindToShowMapTable.GetRecordByKey(this.DebutID);
    if ((double) RotationY > 360.0)
      RotationY -= 360f;
    else if ((double) RotationY < 0.0)
      RotationY += 360f;
    this.WeaponRotationOffSetY = RotationY;
    this.WeaponRotationOffSetX = this.WeaponRotationOffSetZ = 0.0f;
    this.WeaponRotationOffSetKeyFrameID = recordByKey1.ShowKind12ID;
    ShowMap recordByKey2;
    ShowVector3 recordByKey3;
    Vector3 vector3_1;
    if (this.WeaponRotationOffSetKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponRotationOffSetKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if ((double) vector3_1.x > 360.0)
        vector3_1.x -= 360f;
      else if ((double) vector3_1.x < 0.0)
        vector3_1.x += 360f;
      float num1 = this.WeaponRotationOffSetY + 180f;
      if ((double) num1 > 360.0)
        num1 -= 360f;
      else if ((double) num1 < 0.0)
        num1 += 360f;
      if ((double) num1 > 180.0)
        num1 = 360f - num1;
      this.WeaponRotationOffSetX = (float) ((double) num1 * (double) vector3_1.x * 0.011111111380159855) - vector3_1.x;
      if ((double) Mathf.Abs(this.WeaponRotationOffSetX) < 0.0099999997764825821)
        this.WeaponRotationOffSetX = 0.0f;
      float num2 = this.WeaponRotationOffSetY + 90f;
      if ((double) num2 > 360.0)
        num2 -= 360f;
      else if ((double) num2 < 0.0)
        num2 += 360f;
      if ((double) num2 > 180.0)
        num2 = 360f - num2;
      this.WeaponRotationOffSetZ = (float) ((double) num2 * (double) vector3_1.x * 0.011111111380159855) - vector3_1.x;
      if ((double) Mathf.Abs(this.WeaponRotationOffSetZ) < 0.0099999997764825821)
        this.WeaponRotationOffSetZ = 0.0f;
      this.WeaponRotationOffSetTime = 0.0f;
      this.WeaponRotationOffSetTimeTarget = (float) recordByKey2.ShowTime * 0.0001f;
    }
    this.WeaponAnimationKeyFrameID = recordByKey1.ShowKind0ID;
    if (this.WeaponAnimationKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponAnimationKeyFrameID);
      ShowAnimation recordByKey4 = this.ShowAnimationTable.GetRecordByKey(recordByKey2.ListID);
      this.SetWeaponAnimation((AnimationUnit.AnimName) recordByKey4.AnimationNameID, (WrapMode) recordByKey4.WrapModeID, (float) recordByKey2.ShowTime * 0.0001f, (float) recordByKey4.AnimationSpeed * 0.0001f, (float) recordByKey4.AnimationTime * 0.0001f);
    }
    this.WeaponScaleKeyFrameID = recordByKey1.ShowKind1ID;
    Vector3 vector3_2;
    if (this.WeaponScaleKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponScaleKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponScale(vector3_1.x, vector3_1.x, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponScale(vector3_1.x, vector3_2.x, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponRotationKeyFrameID = recordByKey1.ShowKind2ID;
    if (this.WeaponRotationKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponRotationKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_1.x, vector3_1.y, vector3_1.z, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_2.x, vector3_2.y, vector3_2.z, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponPositionKeyFrameID = recordByKey1.ShowKind3ID;
    if (this.WeaponPositionKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponPositionKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponPosition(vector3_1.x, vector3_1.y, vector3_1.z, vector3_1.x, vector3_1.y, vector3_1.z, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponPosition(vector3_1.x, vector3_1.y, vector3_1.z, vector3_2.x, vector3_2.y, vector3_2.z, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponLightKeyFrameID = recordByKey1.ShowKind4ID;
    this.WeaponLightColorKeyFrameID = recordByKey1.ShowKind7ID;
    ShowColor recordByKey5;
    ShowColor recordByKey6;
    if (this.WeaponLightColorKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightKeyFrameID);
      ShowLight recordByKey7 = this.ShowLightTable.GetRecordByKey(recordByKey2.ListID);
      LightType showLightType = (LightType) recordByKey7.ShowLightType;
      float weaponLightIntensity = (float) recordByKey7.ShowLightIntensity * 0.0001f;
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightColorKeyFrameID);
      recordByKey5 = this.ShowColorTable.GetRecordByKey(recordByKey2.ListID);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey5.ColorR, recordByKey5.ColorG, recordByKey5.ColorB, recordByKey5.ColorR, recordByKey5.ColorG, recordByKey5.ColorB, 0.0f);
      }
      else
      {
        recordByKey6 = this.ShowColorTable.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey5.ColorR, recordByKey5.ColorG, recordByKey5.ColorB, recordByKey6.ColorR, recordByKey6.ColorG, recordByKey6.ColorB, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponLightRotationKeyFrameID = recordByKey1.ShowKind5ID;
    if (this.WeaponLightRotationKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightRotationKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponLightRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_1.x, vector3_1.y, vector3_1.z, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponLightRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_2.x, vector3_2.y, vector3_2.z, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponLightPositionKeyFrameID = recordByKey1.ShowKind6ID;
    if (this.WeaponLightPositionKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightPositionKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponLightPosition(vector3_1.x, vector3_1.y, vector3_1.x, vector3_1.y, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponLightPosition(vector3_1.x, vector3_1.y, vector3_2.x, vector3_2.y, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.UpDownImagePositionKeyFrameID = recordByKey1.ShowKind8ID;
    if (this.UpDownImagePositionKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.UpDownImagePositionKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetScreenEffectPosition(vector3_1.y, vector3_1.y, (double) vector3_1.z <= 0.0, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetScreenEffectPosition(vector3_1.y, vector3_2.y, (double) vector3_2.z <= 0.0, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.UpDownImageColorKeyFrameID = recordByKey1.ShowKind9ID;
    if (this.UpDownImageColorKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.UpDownImageColorKeyFrameID);
      recordByKey5 = this.ShowColorTable.GetRecordByKey(recordByKey2.ListID);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetScreenEffectColor(recordByKey5.ColorR, recordByKey5.ColorG, recordByKey5.ColorB, (byte) recordByKey5.ColorA, recordByKey5.ColorR, recordByKey5.ColorG, recordByKey5.ColorB, (byte) recordByKey5.ColorA, 0.0f);
      }
      else
      {
        recordByKey6 = this.ShowColorTable.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        this.SetScreenEffectColor(recordByKey5.ColorR, recordByKey5.ColorG, recordByKey5.ColorB, (byte) recordByKey5.ColorA, recordByKey6.ColorR, recordByKey6.ColorG, recordByKey6.ColorB, (byte) recordByKey6.ColorA, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponParticleKeyFrameID = recordByKey1.ShowKind10ID;
    if (this.WeaponParticleKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponParticleKeyFrameID);
      ShowEffectSound recordByKey8 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey2.ListID);
      this.SetWeaponParticle(recordByKey8.EffectSoundID, (int) recordByKey8.AttackMode, (float) recordByKey2.ShowTime * 0.0001f);
    }
    this.WeaponSoundKeyFrameID = recordByKey1.ShowKind11ID;
    if (this.WeaponSoundKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponSoundKeyFrameID);
      ShowEffectSound recordByKey9 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey2.ListID);
      this.SetWeaponSound(recordByKey9.EffectSoundID, (int) recordByKey9.AttackMode, (float) recordByKey2.ShowTime * 0.0001f);
    }
    this.mapWeaponState = MapTileModel.MapWeaponState.Debut;
    this.CheckNextState();
  }

  public void startShow(ushort showID)
  {
    ShowKindToShowMap recordByKey1 = this.ShowKindToShowMapTable.GetRecordByKey(showID);
    this.WeaponRotationOffSetX = this.WeaponRotationOffSetZ = 0.0f;
    this.WeaponRotationOffSetKeyFrameID = recordByKey1.ShowKind12ID;
    ShowMap recordByKey2;
    ShowVector3 recordByKey3;
    Vector3 vector3_1;
    if (this.WeaponRotationOffSetKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponRotationOffSetKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if ((double) vector3_1.x > 360.0)
        vector3_1.x -= 360f;
      else if ((double) vector3_1.x < 0.0)
        vector3_1.x += 360f;
      float num1 = this.WeaponRotationOffSetY + 180f;
      if ((double) num1 > 360.0)
        num1 -= 360f;
      else if ((double) num1 < 0.0)
        num1 += 360f;
      if ((double) num1 > 180.0)
        num1 = 360f - num1;
      this.WeaponRotationOffSetX = (float) ((double) num1 * (double) vector3_1.x * 0.011111111380159855) - vector3_1.x;
      if ((double) Mathf.Abs(this.WeaponRotationOffSetX) < 0.0099999997764825821)
        this.WeaponRotationOffSetX = 0.0f;
      float num2 = this.WeaponRotationOffSetY + 90f;
      if ((double) num2 > 360.0)
        num2 -= 360f;
      else if ((double) num2 < 0.0)
        num2 += 360f;
      if ((double) num2 > 180.0)
        num2 = 360f - num2;
      this.WeaponRotationOffSetZ = (float) ((double) num2 * (double) vector3_1.x * 0.011111111380159855) - vector3_1.x;
      if ((double) Mathf.Abs(this.WeaponRotationOffSetZ) < 0.0099999997764825821)
        this.WeaponRotationOffSetZ = 0.0f;
      this.WeaponRotationOffSetTime = 0.0f;
      this.WeaponRotationOffSetTimeTarget = (float) recordByKey2.ShowTime * 0.0001f;
    }
    this.WeaponAnimationKeyFrameID = recordByKey1.ShowKind0ID;
    if (this.WeaponAnimationKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponAnimationKeyFrameID);
      ShowAnimation recordByKey4 = this.ShowAnimationTable.GetRecordByKey(recordByKey2.ListID);
      this.SetWeaponAnimation((AnimationUnit.AnimName) recordByKey4.AnimationNameID, (WrapMode) recordByKey4.WrapModeID, (float) recordByKey2.ShowTime * 0.0001f, (float) recordByKey4.AnimationSpeed * 0.0001f, (float) recordByKey4.AnimationTime * 0.0001f);
    }
    this.WeaponScaleKeyFrameID = recordByKey1.ShowKind1ID;
    if (this.WeaponScaleKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponScaleKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponScale(vector3_1.x, vector3_1.x, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        Vector3 vector3_2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponScale(vector3_1.x, vector3_2.x, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponRotationKeyFrameID = recordByKey1.ShowKind2ID;
    Vector3 vector3_3;
    if (this.WeaponRotationKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponRotationKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_1.x, vector3_1.y, vector3_1.z, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_3 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_3.x, vector3_3.y, vector3_3.z, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponPositionKeyFrameID = recordByKey1.ShowKind3ID;
    if (this.WeaponPositionKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponPositionKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponPosition(vector3_1.x, vector3_1.y, vector3_1.z, vector3_1.x, vector3_1.y, vector3_1.z, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_3 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponPosition(vector3_1.x, vector3_1.y, vector3_1.z, vector3_3.x, vector3_3.y, vector3_3.z, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponLightKeyFrameID = recordByKey1.ShowKind4ID;
    this.WeaponLightColorKeyFrameID = recordByKey1.ShowKind7ID;
    if (this.WeaponLightColorKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightKeyFrameID);
      ShowLight recordByKey5 = this.ShowLightTable.GetRecordByKey(recordByKey2.ListID);
      LightType showLightType = (LightType) recordByKey5.ShowLightType;
      float weaponLightIntensity = (float) recordByKey5.ShowLightIntensity * 0.0001f;
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightColorKeyFrameID);
      ShowColor recordByKey6 = this.ShowColorTable.GetRecordByKey(recordByKey2.ListID);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey6.ColorR, recordByKey6.ColorG, recordByKey6.ColorB, recordByKey6.ColorR, recordByKey6.ColorG, recordByKey6.ColorB, 0.0f);
      }
      else
      {
        ShowColor recordByKey7 = this.ShowColorTable.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey6.ColorR, recordByKey6.ColorG, recordByKey6.ColorB, recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponLightRotationKeyFrameID = recordByKey1.ShowKind5ID;
    if (this.WeaponLightRotationKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightRotationKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponLightRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_1.x, vector3_1.y, vector3_1.z, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_3 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponLightRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_3.x, vector3_3.y, vector3_3.z, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponLightPositionKeyFrameID = recordByKey1.ShowKind6ID;
    if (this.WeaponLightPositionKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightPositionKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponLightPosition(vector3_1.x, vector3_1.y, vector3_1.x, vector3_1.y, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_3 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponLightPosition(vector3_1.x, vector3_1.y, vector3_3.x, vector3_3.y, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.UpDownImagePositionKeyFrameID = recordByKey1.ShowKind8ID;
    if (this.UpDownImagePositionKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.UpDownImagePositionKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetScreenEffectPosition(vector3_1.y, vector3_1.y, (double) vector3_1.z <= 0.0, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_3 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetScreenEffectPosition(vector3_1.y, vector3_3.y, (double) vector3_3.z <= 0.0, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.UpDownImageColorKeyFrameID = recordByKey1.ShowKind9ID;
    if (this.UpDownImageColorKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.UpDownImageColorKeyFrameID);
      ShowColor recordByKey8 = this.ShowColorTable.GetRecordByKey(recordByKey2.ListID);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetScreenEffectColor(recordByKey8.ColorR, recordByKey8.ColorG, recordByKey8.ColorB, (byte) recordByKey8.ColorA, recordByKey8.ColorR, recordByKey8.ColorG, recordByKey8.ColorB, (byte) recordByKey8.ColorA, 0.0f);
      }
      else
      {
        ShowColor recordByKey9 = this.ShowColorTable.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        this.SetScreenEffectColor(recordByKey8.ColorR, recordByKey8.ColorG, recordByKey8.ColorB, (byte) recordByKey8.ColorA, recordByKey9.ColorR, recordByKey9.ColorG, recordByKey9.ColorB, (byte) recordByKey9.ColorA, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponParticleKeyFrameID = recordByKey1.ShowKind10ID;
    if (this.WeaponParticleKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponParticleKeyFrameID);
      ShowEffectSound recordByKey10 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey2.ListID);
      this.SetWeaponParticle(recordByKey10.EffectSoundID, (int) recordByKey10.AttackMode, (float) recordByKey2.ShowTime * 0.0001f);
    }
    this.WeaponSoundKeyFrameID = recordByKey1.ShowKind11ID;
    if (this.WeaponSoundKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponSoundKeyFrameID);
      ShowEffectSound recordByKey11 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey2.ListID);
      this.SetWeaponParticle(recordByKey11.EffectSoundID, (int) recordByKey11.AttackMode, (float) recordByKey2.ShowTime * 0.0001f);
    }
    this.mapWeaponState = MapTileModel.MapWeaponState.Show;
    this.CheckNextState();
  }

  public void startExit(ushort exitID)
  {
    ShowKindToShowMap recordByKey1 = this.ShowKindToShowMapTable.GetRecordByKey(exitID);
    this.WeaponRotationOffSetX = this.WeaponRotationOffSetZ = 0.0f;
    this.WeaponRotationOffSetKeyFrameID = recordByKey1.ShowKind12ID;
    ShowMap recordByKey2;
    ShowVector3 recordByKey3;
    Vector3 vector3_1;
    if (this.WeaponRotationOffSetKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponRotationOffSetKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if ((double) vector3_1.x > 360.0)
        vector3_1.x -= 360f;
      else if ((double) vector3_1.x < 0.0)
        vector3_1.x += 360f;
      float num1 = this.WeaponRotationOffSetY + 180f;
      if ((double) num1 > 360.0)
        num1 -= 360f;
      else if ((double) num1 < 0.0)
        num1 += 360f;
      if ((double) num1 > 180.0)
        num1 = 360f - num1;
      this.WeaponRotationOffSetX = (float) ((double) num1 * (double) vector3_1.x * 0.011111111380159855) - vector3_1.x;
      if ((double) Mathf.Abs(this.WeaponRotationOffSetX) < 0.0099999997764825821)
        this.WeaponRotationOffSetX = 0.0f;
      float num2 = this.WeaponRotationOffSetY + 90f;
      if ((double) num2 > 360.0)
        num2 -= 360f;
      else if ((double) num2 < 0.0)
        num2 += 360f;
      if ((double) num2 > 180.0)
        num2 = 360f - num2;
      this.WeaponRotationOffSetZ = (float) ((double) num2 * (double) vector3_1.x * 0.011111111380159855) - vector3_1.x;
      if ((double) Mathf.Abs(this.WeaponRotationOffSetZ) < 0.0099999997764825821)
        this.WeaponRotationOffSetZ = 0.0f;
      this.WeaponRotationOffSetTime = 0.0f;
      this.WeaponRotationOffSetTimeTarget = (float) recordByKey2.ShowTime * 0.0001f;
    }
    this.WeaponAnimationKeyFrameID = recordByKey1.ShowKind0ID;
    if (this.WeaponAnimationKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponAnimationKeyFrameID);
      ShowAnimation recordByKey4 = this.ShowAnimationTable.GetRecordByKey(recordByKey2.ListID);
      this.SetWeaponAnimation((AnimationUnit.AnimName) recordByKey4.AnimationNameID, (WrapMode) recordByKey4.WrapModeID, (float) recordByKey2.ShowTime * 0.0001f, (float) recordByKey4.AnimationSpeed * 0.0001f, (float) recordByKey4.AnimationTime * 0.0001f);
    }
    this.WeaponScaleKeyFrameID = recordByKey1.ShowKind1ID;
    if (this.WeaponScaleKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponScaleKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponScale(vector3_1.x, vector3_1.x, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        Vector3 vector3_2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponScale(vector3_1.x, vector3_2.x, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponRotationKeyFrameID = recordByKey1.ShowKind2ID;
    Vector3 vector3_3;
    if (this.WeaponRotationKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponRotationKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_1.x, vector3_1.y, vector3_1.z, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_3 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_3.x, vector3_3.y, vector3_3.z, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponPositionKeyFrameID = recordByKey1.ShowKind3ID;
    if (this.WeaponPositionKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponPositionKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponPosition(vector3_1.x, vector3_1.y, vector3_1.z, vector3_1.x, vector3_1.y, vector3_1.z, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_3 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponPosition(vector3_1.x, vector3_1.y, vector3_1.z, vector3_3.x, vector3_3.y, vector3_3.z, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponLightKeyFrameID = recordByKey1.ShowKind4ID;
    this.WeaponLightColorKeyFrameID = recordByKey1.ShowKind7ID;
    if (this.WeaponLightColorKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightKeyFrameID);
      ShowLight recordByKey5 = this.ShowLightTable.GetRecordByKey(recordByKey2.ListID);
      LightType showLightType = (LightType) recordByKey5.ShowLightType;
      float weaponLightIntensity = (float) recordByKey5.ShowLightIntensity * 0.0001f;
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightColorKeyFrameID);
      ShowColor recordByKey6 = this.ShowColorTable.GetRecordByKey(recordByKey2.ListID);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey6.ColorR, recordByKey6.ColorG, recordByKey6.ColorB, recordByKey6.ColorR, recordByKey6.ColorG, recordByKey6.ColorB, 0.0f);
      }
      else
      {
        ShowColor recordByKey7 = this.ShowColorTable.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey6.ColorR, recordByKey6.ColorG, recordByKey6.ColorB, recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponLightRotationKeyFrameID = recordByKey1.ShowKind5ID;
    if (this.WeaponLightRotationKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightRotationKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponLightRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_1.x, vector3_1.y, vector3_1.z, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_3 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponLightRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_3.x, vector3_3.y, vector3_3.z, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponLightPositionKeyFrameID = recordByKey1.ShowKind6ID;
    if (this.WeaponLightPositionKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightPositionKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponLightPosition(vector3_1.x, vector3_1.y, vector3_1.x, vector3_1.y, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_3 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponLightPosition(vector3_1.x, vector3_1.y, vector3_3.x, vector3_3.y, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.UpDownImagePositionKeyFrameID = recordByKey1.ShowKind8ID;
    if (this.UpDownImagePositionKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.UpDownImagePositionKeyFrameID);
      recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
      vector3_1 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetScreenEffectPosition(vector3_1.y, vector3_1.y, (double) vector3_1.z <= 0.0, 0.0f);
      }
      else
      {
        recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        vector3_3 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetScreenEffectPosition(vector3_1.y, vector3_3.y, (double) vector3_3.z <= 0.0, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.UpDownImageColorKeyFrameID = recordByKey1.ShowKind9ID;
    if (this.UpDownImageColorKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.UpDownImageColorKeyFrameID);
      ShowColor recordByKey8 = this.ShowColorTable.GetRecordByKey(recordByKey2.ListID);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetScreenEffectColor(recordByKey8.ColorR, recordByKey8.ColorG, recordByKey8.ColorB, (byte) recordByKey8.ColorA, recordByKey8.ColorR, recordByKey8.ColorG, recordByKey8.ColorB, (byte) recordByKey8.ColorA, 0.0f);
      }
      else
      {
        ShowColor recordByKey9 = this.ShowColorTable.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        this.SetScreenEffectColor(recordByKey8.ColorR, recordByKey8.ColorG, recordByKey8.ColorB, (byte) recordByKey8.ColorA, recordByKey9.ColorR, recordByKey9.ColorG, recordByKey9.ColorB, (byte) recordByKey9.ColorA, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.WeaponParticleKeyFrameID = recordByKey1.ShowKind10ID;
    if (this.WeaponParticleKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponParticleKeyFrameID);
      ShowEffectSound recordByKey10 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey2.ListID);
      this.SetWeaponParticle(recordByKey10.EffectSoundID, (int) recordByKey10.AttackMode, (float) recordByKey2.ShowTime * 0.0001f);
    }
    this.WeaponSoundKeyFrameID = recordByKey1.ShowKind11ID;
    if (this.WeaponSoundKeyFrameID > (ushort) 0)
    {
      recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponSoundKeyFrameID);
      ShowEffectSound recordByKey11 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey2.ListID);
      this.SetWeaponParticle(recordByKey11.EffectSoundID, (int) recordByKey11.AttackMode, (float) recordByKey2.ShowTime * 0.0001f);
    }
    this.mapWeaponState = MapTileModel.MapWeaponState.Exit;
    this.CheckNextState();
  }

  public void Stop()
  {
    if ((Object) this.WeaponTransform != (Object) null)
      this.WeaponTransform.gameObject.SetActive(false);
    if ((Object) this.WeaponLightTransform != (Object) null)
      this.WeaponLightTransform.gameObject.SetActive(false);
    if ((Object) this.UpImageRectTransform != (Object) null)
      ((Component) this.UpImageRectTransform).gameObject.SetActive(false);
    if ((Object) this.DownImageRectTransform != (Object) null)
      ((Component) this.DownImageRectTransform).gameObject.SetActive(false);
    if ((Object) this.WeaponParticleGameObject != (Object) null)
      this.WeaponParticleGameObject.SetActive(false);
    this.mapWeaponState = MapTileModel.MapWeaponState.None;
  }

  public void LoadShowData()
  {
    if (this.ShowKindToShowMapTable == null)
    {
      this.ShowKindToShowMapTable = new CExternalTableWithWordKey<ShowKindToShowMap>();
      this.ShowKindToShowMapTable.LoadTable("ShowKindToShowMap");
    }
    if (this.ShowMapTable == null)
    {
      this.ShowMapTable = new CExternalTableWithWordKey<ShowMap>();
      this.ShowMapTable.LoadTable("ShowMap");
    }
    if (this.ShowAnimationTable == null)
    {
      this.ShowAnimationTable = new CExternalTableWithWordKey<ShowAnimation>();
      this.ShowAnimationTable.LoadTable("ShowAnimation");
    }
    if (this.ShowVector3Table == null)
    {
      this.ShowVector3Table = new CExternalTableWithWordKey<ShowVector3>();
      this.ShowVector3Table.LoadTable("ShowVector3");
    }
    if (this.ShowLightTable == null)
    {
      this.ShowLightTable = new CExternalTableWithWordKey<ShowLight>();
      this.ShowLightTable.LoadTable("ShowLight");
    }
    if (this.ShowColorTable == null)
    {
      this.ShowColorTable = new CExternalTableWithWordKey<ShowColor>();
      this.ShowColorTable.LoadTable("ShowColor");
    }
    if (this.ShowEffectSoundTable != null)
      return;
    this.ShowEffectSoundTable = new CExternalTableWithWordKey<ShowEffectSound>();
    this.ShowEffectSoundTable.LoadTable("ShowEffectSound");
  }

  public bool MapWeaponEffect(ushort EffectID, Vector3 pos, float EffectTime)
  {
    bool flag = false;
    if ((Object) this.EffectAssetBundle == (Object) null)
      this.EffectAssetBundle = AssetManager.GetAssetBundle("Particle/Monster_Effects_604", out this.EffectAssetKey);
    this.sb.Length = 0;
    this.sb.AppendFormat("Effect_{0:00000}", (object) EffectID);
    Object original = this.EffectAssetBundle.Load(this.sb.ToString());
    if (original != (Object) null)
    {
      GameObject gameObject = Object.Instantiate(original) as GameObject;
      if ((Object) gameObject != (Object) null)
      {
        Transform transform = gameObject.transform;
        transform.SetParent(this.AllEffectTransform, false);
        transform.localPosition = pos;
        float zoomSize = DataManager.MapDataController.zoomSize;
        for (int index1 = 0; index1 < transform.childCount; ++index1)
        {
          ParticleSystem component = transform.GetChild(index1).GetComponent<ParticleSystem>();
          if ((Object) component != (Object) null)
          {
            float startSize = component.startSize;
            float startLifetime = component.startLifetime;
            component.startSize = startSize * zoomSize;
            component.startLifetime = startLifetime * zoomSize;
            float num1 = component.startSize / startSize;
            float num2 = component.startLifetime / startLifetime;
            int particles = component.GetParticles(this.particles);
            for (int index2 = 0; index2 < particles; ++index2)
            {
              this.particles[index1].size *= num1;
              this.particles[index1].lifetime *= num2;
            }
            component.SetParticles(this.particles, particles);
          }
        }
        this.Effects.Add(gameObject.transform);
        this.EffectTimes.Add(EffectTime * zoomSize);
        flag = true;
      }
    }
    return flag;
  }

  public void MapWeaponEffectMove(Vector2 moveDelta)
  {
    if (this.Effects.Count <= 0)
      return;
    moveDelta *= DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
    for (int index = 0; index < this.Effects.Count; ++index)
    {
      Transform effect = this.Effects[index];
      effect.position = new Vector3(effect.position.x + moveDelta.x, effect.position.y + moveDelta.y, effect.position.z);
    }
  }

  public void MapWeaponEffectScale(float scale)
  {
  }

  private void NoneState()
  {
  }

  private void Debut() => this.UpdateSet();

  private void Show() => this.UpdateSet();

  private void Exit() => this.UpdateSet();

  private void WeaponAnimationUpdate()
  {
    this.WeaponAnimationSpeedTime += Time.deltaTime;
    if ((double) this.WeaponAnimationSpeedTime < (double) this.WeaponAnimationSpeedTimeTarget)
      return;
    this.WeaponAnimationTime += this.WeaponAnimationSpeedTimeTarget * this.WeaponAnimationSpeed;
    this.WeaponAnimation[AnimationUnit.ANIM_STRING[(int) this.WeaponAnimationName]].speed = this.WeaponAnimationSpeed;
    this.WeaponAnimation[AnimationUnit.ANIM_STRING[(int) this.WeaponAnimationName]].time = this.WeaponAnimationTime;
    this.NextWeaponAnimation();
  }

  private void WeaponScaleUpdate()
  {
    this.WeaponScaleTime += Time.deltaTime;
    if ((double) this.WeaponScaleTime >= (double) this.WeaponScaleTimeTarget)
    {
      this.WeaponTransform.localScale = Vector3.one * this.WeaponScaleTo;
      this.NextWeaponScale();
    }
    else
      this.WeaponTransform.localScale = Vector3.one * Mathf.Lerp(this.WeaponScaleFrom, this.WeaponScaleTo, this.WeaponScaleTime / this.WeaponScaleTimeTarget);
  }

  private void WeaponRotationUpdate()
  {
    this.WeaponRotationTime += Time.deltaTime;
    if ((double) this.WeaponRotationTime >= (double) this.WeaponRotationTimeTarget)
    {
      if ((double) this.WeaponRotationXTo < 0.0)
        this.WeaponRotationXTo += 360f;
      else if ((double) this.WeaponRotationXTo > 360.0)
        this.WeaponRotationXTo -= 360f;
      if ((double) this.WeaponRotationYTo < 0.0)
        this.WeaponRotationYTo += 360f;
      else if ((double) this.WeaponRotationYTo > 360.0)
        this.WeaponRotationYTo -= 360f;
      if ((double) this.WeaponRotationZTo < 0.0)
        this.WeaponRotationZTo += 360f;
      else if ((double) this.WeaponRotationZTo > 360.0)
        this.WeaponRotationZTo -= 360f;
      this.WeaponTransform.localRotation = Quaternion.Euler(this.WeaponRotationXTo, this.WeaponRotationYTo, this.WeaponRotationZTo);
      this.NextWeaponRotation();
    }
    else
    {
      float t = this.WeaponRotationTime / this.WeaponRotationTimeTarget;
      this.WeaponTransform.localRotation = Quaternion.Euler(Mathf.Lerp(this.WeaponRotationXFrom, this.WeaponRotationXTo, t), Mathf.Lerp(this.WeaponRotationYFrom, this.WeaponRotationYTo, t), Mathf.Lerp(this.WeaponRotationZFrom, this.WeaponRotationZTo, t));
    }
  }

  private void WeaponRotationOffSetUpdate()
  {
    this.WeaponRotationOffSetTime += Time.deltaTime;
    if ((double) this.WeaponRotationOffSetTime < (double) this.WeaponRotationOffSetTimeTarget)
      return;
    this.NextWeaponRotationOffSet();
  }

  private void WeaponPositionUpdate()
  {
    this.WeaponPositionTime += Time.deltaTime;
    if ((double) this.WeaponPositionTime >= (double) this.WeaponPositionTimeTarget)
    {
      this.WeaponTransform.localPosition = new Vector3(this.WeaponPositionXTo, this.WeaponPositionYTo, this.WeaponPositionZTo);
      this.NextWeaponPosition();
    }
    else
    {
      float t = this.WeaponPositionTime / this.WeaponPositionTimeTarget;
      this.WeaponTransform.localPosition = new Vector3(Mathf.Lerp(this.WeaponPositionXFrom, this.WeaponPositionXTo, t), Mathf.Lerp(this.WeaponPositionYFrom, this.WeaponPositionYTo, t), Mathf.Lerp(this.WeaponPositionZFrom, this.WeaponPositionZTo, t));
    }
  }

  private void WeaponLightRotationUpdate()
  {
    this.WeaponLightRotationTime += Time.deltaTime;
    if ((double) this.WeaponLightRotationTime >= (double) this.WeaponLightRotationTimeTarget)
    {
      if ((double) this.WeaponLightRotationXTo < 0.0)
        this.WeaponLightRotationXTo += 360f;
      else if ((double) this.WeaponLightRotationXTo > 360.0)
        this.WeaponLightRotationXTo -= 360f;
      if ((double) this.WeaponLightRotationYTo < 0.0)
        this.WeaponLightRotationYTo += 360f;
      else if ((double) this.WeaponLightRotationYTo > 360.0)
        this.WeaponLightRotationYTo -= 360f;
      if ((double) this.WeaponLightRotationZTo < 0.0)
        this.WeaponLightRotationZTo += 360f;
      else if ((double) this.WeaponLightRotationZTo > 360.0)
        this.WeaponLightRotationZTo -= 360f;
      this.WeaponLightTransform.localRotation = Quaternion.Euler(this.WeaponLightRotationXTo, this.WeaponLightRotationYTo, this.WeaponLightRotationZTo);
      this.NextWeaponLightRotation();
    }
    else
    {
      float t = this.WeaponLightRotationTime / this.WeaponLightRotationTimeTarget;
      this.WeaponLightTransform.localRotation = Quaternion.Euler(Mathf.Lerp(this.WeaponLightRotationXFrom, this.WeaponLightRotationXTo, t), Mathf.Lerp(this.WeaponLightRotationYFrom, this.WeaponLightRotationYTo, t), Mathf.Lerp(this.WeaponLightRotationZFrom, this.WeaponLightRotationZTo, t));
    }
  }

  private void WeaponLightPositionUpdate()
  {
    this.WeaponLightPositionTime += Time.deltaTime;
    if ((double) this.WeaponLightPositionTime >= (double) this.WeaponLightPositionTimeTarget)
    {
      this.WeaponLightTransform.localPosition = new Vector3(this.WeaponLightPositionXTo, this.WeaponLightPositionYTo, this.WeaponLightTransform.localPosition.z);
      this.NextWeaponLightPosition();
    }
    else
    {
      float t = this.WeaponLightPositionTime / this.WeaponLightPositionTimeTarget;
      this.WeaponLightTransform.localPosition = new Vector3(Mathf.Lerp(this.WeaponLightPositionXFrom, this.WeaponLightPositionXTo, t), Mathf.Lerp(this.WeaponLightPositionYFrom, this.WeaponLightPositionYTo, t), this.WeaponLightTransform.localPosition.z);
    }
  }

  private void WeaponLightColorUpdate()
  {
    this.WeaponLightColorTime += Time.deltaTime;
    if ((double) this.WeaponLightColorTime >= (double) this.WeaponLightColorTimeTarget)
    {
      this.WeaponLight.color = new Color(this.WeaponLightColorRTo, this.WeaponLightColorGTo, this.WeaponLightColorBTo);
      this.NextWeaponLightColor();
    }
    else
    {
      float t = this.WeaponLightColorTime / this.WeaponLightColorTimeTarget;
      this.WeaponLight.color = new Color(Mathf.Lerp(this.WeaponLightColorRFrom, this.WeaponLightColorRTo, t), Mathf.Lerp(this.WeaponLightColorGFrom, this.WeaponLightColorGTo, t), Mathf.Lerp(this.WeaponLightColorBFrom, this.WeaponLightColorBTo, t));
    }
  }

  private void ScreenEffectPositionUpdate()
  {
    this.UpDownImagePositionTime += Time.deltaTime;
    if ((double) this.UpDownImagePositionTime >= (double) this.UpDownImagePositionTimeTarget)
    {
      this.UpImageRectTransform.anchoredPosition = new Vector2(this.UpImageRectTransform.anchoredPosition.x, this.UpDownImagePositionYTo);
      this.DownImageRectTransform.anchoredPosition = new Vector2(this.DownImageRectTransform.anchoredPosition.x, -this.UpDownImagePositionYTo);
      this.NextScreenEffectPosition();
    }
    else
    {
      float t = this.UpDownImagePositionTime / this.UpDownImagePositionTimeTarget;
      this.UpImageRectTransform.anchoredPosition = new Vector2(this.UpImageRectTransform.anchoredPosition.x, Mathf.Lerp(this.UpDownImagePositionYFrom, this.UpDownImagePositionYTo, t));
      this.DownImageRectTransform.anchoredPosition = new Vector2(this.DownImageRectTransform.anchoredPosition.x, Mathf.Lerp(-this.UpDownImagePositionYFrom, -this.UpDownImagePositionYTo, t));
    }
  }

  private void ScreenEffectColorUpdate()
  {
    this.UpDownImageColorTime += Time.deltaTime;
    if ((double) this.UpDownImageColorTime >= (double) this.UpDownImageColorTimeTarget)
    {
      Image upImage = this.UpImage;
      Color color1 = new Color(this.UpDownImageColorRTo, this.UpDownImageColorGTo, this.UpDownImageColorBTo, this.UpDownImageColorATo);
      ((Graphic) this.DownImage).color = color1;
      Color color2 = color1;
      ((Graphic) upImage).color = color2;
      this.NextScreenEffectColor();
    }
    else
    {
      float t = this.UpDownImageColorTime / this.UpDownImageColorTimeTarget;
      Image upImage = this.UpImage;
      Color color3 = new Color(Mathf.Lerp(this.UpDownImageColorRFrom, this.UpDownImageColorRTo, t), Mathf.Lerp(this.UpDownImageColorGFrom, this.UpDownImageColorGTo, t), Mathf.Lerp(this.UpDownImageColorBFrom, this.UpDownImageColorBTo, t), Mathf.Lerp(this.UpDownImageColorBFrom, this.UpDownImageColorBTo, t));
      ((Graphic) this.DownImage).color = color3;
      Color color4 = color3;
      ((Graphic) upImage).color = color4;
    }
  }

  private void WeaponParticleUpdate()
  {
    this.WeaponParticleTime -= Time.deltaTime;
    if ((double) this.WeaponParticleTime > 0.0)
      return;
    this.WeaponParticleTime = 0.0f;
    this.NextWeaponParticle();
  }

  private void WeaponSoundUpdate()
  {
    this.WeaponSoundTime -= Time.deltaTime;
    if ((double) this.WeaponSoundTime > 0.0)
      return;
    this.WeaponSoundTime = 0.0f;
    this.NextWeaponSound();
  }

  private void MapWeaponEffectParticleUpdate()
  {
    for (int index1 = 0; index1 < this.EffectTimes.Count; ++index1)
    {
      List<float> effectTimes;
      int index2;
      (effectTimes = this.EffectTimes)[index2 = index1] = effectTimes[index2] - Time.deltaTime;
      if ((double) this.EffectTimes[index1] <= 0.0)
        this.EffectsIDs.Add(index1);
    }
    for (int index = this.EffectsIDs.Count - 1; index >= 0; --index)
    {
      Object.Destroy((Object) this.Effects[this.EffectsIDs[index]].gameObject);
      this.Effects.RemoveAt(this.EffectsIDs[index]);
      this.EffectTimes.RemoveAt(this.EffectsIDs[index]);
    }
    this.EffectsIDs.Clear();
  }

  private void UpdateSet()
  {
    this.WeaponAnimationUpdate();
    this.WeaponScaleUpdate();
    this.WeaponRotationUpdate();
    this.WeaponRotationOffSetUpdate();
    this.WeaponPositionUpdate();
    this.WeaponLightColorUpdate();
    this.WeaponLightRotationUpdate();
    this.WeaponLightPositionUpdate();
    this.ScreenEffectColorUpdate();
    this.ScreenEffectPositionUpdate();
    this.WeaponParticleUpdate();
    this.WeaponSoundUpdate();
  }

  private void NextWeaponAnimation()
  {
    if (this.WeaponAnimationKeyFrameID == (ushort) 0)
      return;
    this.WeaponAnimationKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponAnimationKeyFrameID).NextListID;
    if (this.WeaponAnimationKeyFrameID > (ushort) 0)
    {
      ShowMap recordByKey1 = this.ShowMapTable.GetRecordByKey(this.WeaponAnimationKeyFrameID);
      ShowAnimation recordByKey2 = this.ShowAnimationTable.GetRecordByKey(recordByKey1.ListID);
      this.SetWeaponAnimation((AnimationUnit.AnimName) recordByKey2.AnimationNameID, (WrapMode) recordByKey2.WrapModeID, (float) recordByKey1.ShowTime * 0.0001f, (float) recordByKey2.AnimationSpeed * 0.0001f, (float) recordByKey2.AnimationTime * 0.0001f);
    }
    this.CheckNextState();
  }

  private void NextWeaponScale()
  {
    if (this.WeaponScaleKeyFrameID == (ushort) 0)
      return;
    this.WeaponScaleKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponScaleKeyFrameID).NextListID;
    if (this.WeaponScaleKeyFrameID > (ushort) 0)
    {
      ShowMap recordByKey1 = this.ShowMapTable.GetRecordByKey(this.WeaponScaleKeyFrameID);
      ShowVector3 recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey1.ListID);
      Vector3 vector3_1 = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
      if (recordByKey1.NextListID == (ushort) 0)
      {
        this.SetWeaponScale(vector3_1.x, vector3_1.x, 0.0f);
      }
      else
      {
        ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey1.NextListID).ListID);
        Vector3 vector3_2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponScale(vector3_1.x, vector3_2.x, (float) recordByKey1.ShowTime * 0.0001f);
      }
    }
    this.CheckNextState();
  }

  private void NextWeaponRotation()
  {
    if (this.WeaponRotationKeyFrameID == (ushort) 0)
      return;
    this.WeaponRotationKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponRotationKeyFrameID).NextListID;
    if (this.WeaponRotationKeyFrameID > (ushort) 0)
    {
      ShowMap recordByKey1 = this.ShowMapTable.GetRecordByKey(this.WeaponRotationKeyFrameID);
      ShowVector3 recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey1.ListID);
      Vector3 vector3_1 = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
      if (recordByKey1.NextListID == (ushort) 0)
      {
        this.SetWeaponRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_1.x, vector3_1.y, vector3_1.z, 0.0f);
      }
      else
      {
        ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey1.NextListID).ListID);
        Vector3 vector3_2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_2.x, vector3_2.y, vector3_2.z, (float) recordByKey1.ShowTime * 0.0001f);
      }
    }
    this.CheckNextState();
  }

  private void NextWeaponRotationOffSet()
  {
    if (this.WeaponRotationOffSetKeyFrameID == (ushort) 0)
      return;
    this.WeaponRotationOffSetKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponRotationOffSetKeyFrameID).NextListID;
    if (this.WeaponRotationOffSetKeyFrameID > (ushort) 0)
    {
      this.WeaponRotationOffSetX = this.WeaponRotationOffSetZ = 0.0f;
      ShowMap recordByKey1 = this.ShowMapTable.GetRecordByKey(this.WeaponRotationOffSetKeyFrameID);
      ShowVector3 recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey1.ListID);
      Vector3 vector3 = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
      float weaponRotationOffSetY = this.WeaponRotationOffSetY;
      if ((double) weaponRotationOffSetY > 180.0)
        weaponRotationOffSetY -= 180f;
      this.WeaponRotationOffSetX = vector3.x - (float) ((double) weaponRotationOffSetY * (double) vector3.x * 0.011111111380159855);
      float num = this.WeaponRotationOffSetY - 90f;
      if ((double) num > 180.0)
        num -= 180f;
      else if ((double) num < 0.0)
        num += 180f;
      this.WeaponRotationOffSetZ = vector3.x - (float) ((double) num * (double) vector3.x * 0.011111111380159855);
      this.WeaponRotationOffSetTime = 0.0f;
      this.WeaponRotationOffSetTimeTarget = (float) recordByKey1.ShowTime * 0.0001f;
    }
    this.CheckNextState();
  }

  private void NextWeaponPosition()
  {
    if (this.WeaponPositionKeyFrameID == (ushort) 0)
      return;
    this.WeaponPositionKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponPositionKeyFrameID).NextListID;
    if (this.WeaponPositionKeyFrameID > (ushort) 0)
    {
      ShowMap recordByKey1 = this.ShowMapTable.GetRecordByKey(this.WeaponPositionKeyFrameID);
      ShowVector3 recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey1.ListID);
      Vector3 vector3_1 = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
      if (recordByKey1.NextListID == (ushort) 0)
      {
        this.SetWeaponPosition(vector3_1.x, vector3_1.y, vector3_1.z, vector3_1.x, vector3_1.y, vector3_1.z, 0.0f);
      }
      else
      {
        ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey1.NextListID).ListID);
        Vector3 vector3_2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponPosition(vector3_1.x, vector3_1.y, vector3_1.z, vector3_2.x, vector3_2.y, vector3_2.z, (float) recordByKey1.ShowTime * 0.0001f);
      }
    }
    this.CheckNextState();
  }

  private void NextWeaponLightRotation()
  {
    if (this.WeaponLightRotationKeyFrameID == (ushort) 0)
      return;
    this.WeaponLightRotationKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponLightRotationKeyFrameID).NextListID;
    if (this.WeaponLightRotationKeyFrameID > (ushort) 0)
    {
      ShowMap recordByKey1 = this.ShowMapTable.GetRecordByKey(this.WeaponLightRotationKeyFrameID);
      ShowVector3 recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey1.ListID);
      Vector3 vector3_1 = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
      if (recordByKey1.NextListID == (ushort) 0)
      {
        this.SetWeaponLightRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_1.x, vector3_1.y, vector3_1.z, 0.0f);
      }
      else
      {
        ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey1.NextListID).ListID);
        Vector3 vector3_2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponLightRotation(vector3_1.x, vector3_1.y, vector3_1.z, vector3_2.x, vector3_2.y, vector3_2.z, (float) recordByKey1.ShowTime * 0.0001f);
      }
    }
    this.CheckNextState();
  }

  private void NextWeaponLightPosition()
  {
    if (this.WeaponLightPositionKeyFrameID == (ushort) 0)
      return;
    this.WeaponLightPositionKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponLightPositionKeyFrameID).NextListID;
    if (this.WeaponLightPositionKeyFrameID > (ushort) 0)
    {
      ShowMap recordByKey1 = this.ShowMapTable.GetRecordByKey(this.WeaponLightPositionKeyFrameID);
      ShowVector3 recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey1.ListID);
      Vector3 vector3_1 = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
      if (recordByKey1.NextListID == (ushort) 0)
      {
        this.SetWeaponLightPosition(vector3_1.x, vector3_1.y, vector3_1.x, vector3_1.y, 0.0f);
      }
      else
      {
        ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey1.NextListID).ListID);
        Vector3 vector3_2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetWeaponLightPosition(vector3_1.x, vector3_1.y, vector3_2.x, vector3_2.y, (float) recordByKey1.ShowTime * 0.0001f);
      }
    }
    this.CheckNextState();
  }

  private void NextWeaponLightColor()
  {
    if (this.WeaponLightColorKeyFrameID == (ushort) 0)
      return;
    this.WeaponLightKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponLightKeyFrameID).NextListID;
    this.WeaponLightColorKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponLightColorKeyFrameID).NextListID;
    if (this.WeaponLightColorKeyFrameID > (ushort) 0)
    {
      ShowLight recordByKey1 = this.ShowLightTable.GetRecordByKey(this.ShowMapTable.GetRecordByKey(this.WeaponLightKeyFrameID).ListID);
      LightType showLightType = (LightType) recordByKey1.ShowLightType;
      float weaponLightIntensity = (float) recordByKey1.ShowLightIntensity * 0.0001f;
      ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightColorKeyFrameID);
      ShowColor recordByKey3 = this.ShowColorTable.GetRecordByKey(recordByKey2.ListID);
      if (recordByKey2.NextListID == (ushort) 0)
      {
        this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey3.ColorR, recordByKey3.ColorG, recordByKey3.ColorB, recordByKey3.ColorR, recordByKey3.ColorG, recordByKey3.ColorB, 0.0f);
      }
      else
      {
        ShowColor recordByKey4 = this.ShowColorTable.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID).ListID);
        this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey3.ColorR, recordByKey3.ColorG, recordByKey3.ColorB, recordByKey4.ColorR, recordByKey4.ColorG, recordByKey4.ColorB, (float) recordByKey2.ShowTime * 0.0001f);
      }
    }
    this.CheckNextState();
  }

  private void NextScreenEffectPosition()
  {
    if (this.UpDownImagePositionKeyFrameID == (ushort) 0)
      return;
    this.UpDownImagePositionKeyFrameID = this.ShowMapTable.GetRecordByKey(this.UpDownImagePositionKeyFrameID).NextListID;
    if (this.UpDownImagePositionKeyFrameID > (ushort) 0)
    {
      ShowMap recordByKey1 = this.ShowMapTable.GetRecordByKey(this.UpDownImagePositionKeyFrameID);
      ShowVector3 recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey1.ListID);
      Vector3 vector3_1 = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
      if (recordByKey1.NextListID == (ushort) 0)
      {
        this.SetScreenEffectPosition(vector3_1.y, vector3_1.y, (double) vector3_1.z <= 0.0, 0.0f);
      }
      else
      {
        ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey1.NextListID).ListID);
        Vector3 vector3_2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
        this.SetScreenEffectPosition(vector3_1.y, vector3_2.y, (double) vector3_2.z <= 0.0, (float) recordByKey1.ShowTime * 0.0001f);
      }
    }
    this.CheckNextState();
  }

  private void NextScreenEffectColor()
  {
    if (this.UpDownImageColorKeyFrameID == (ushort) 0)
      return;
    this.UpDownImageColorKeyFrameID = this.ShowMapTable.GetRecordByKey(this.UpDownImageColorKeyFrameID).NextListID;
    if (this.UpDownImageColorKeyFrameID > (ushort) 0)
    {
      ShowMap recordByKey1 = this.ShowMapTable.GetRecordByKey(this.UpDownImageColorKeyFrameID);
      ShowColor recordByKey2 = this.ShowColorTable.GetRecordByKey(recordByKey1.ListID);
      if (recordByKey1.NextListID == (ushort) 0)
      {
        this.SetScreenEffectColor(recordByKey2.ColorR, recordByKey2.ColorG, recordByKey2.ColorB, (byte) recordByKey2.ColorA, recordByKey2.ColorR, recordByKey2.ColorG, recordByKey2.ColorB, (byte) recordByKey2.ColorA, 0.0f);
      }
      else
      {
        ShowColor recordByKey3 = this.ShowColorTable.GetRecordByKey(this.ShowMapTable.GetRecordByKey(recordByKey1.NextListID).ListID);
        this.SetScreenEffectColor(recordByKey2.ColorR, recordByKey2.ColorG, recordByKey2.ColorB, (byte) recordByKey2.ColorA, recordByKey3.ColorR, recordByKey3.ColorG, recordByKey3.ColorB, (byte) recordByKey3.ColorA, (float) recordByKey1.ShowTime * 0.0001f);
      }
    }
    this.CheckNextState();
  }

  private void NextWeaponParticle()
  {
    if (this.WeaponParticleKeyFrameID == (ushort) 0)
      return;
    if ((Object) this.WeaponParticle != (Object) null && (Object) this.WeaponParticleGameObject != (Object) null)
    {
      if (this.WeaponParticleID == 0U)
      {
        this.WeaponParticleGameObject.SetActive(false);
        Object.Destroy((Object) this.WeaponParticleGameObject);
        this.WeaponParticleGameObject = (GameObject) null;
        this.WeaponParticle = (ParticleSystem) null;
      }
      else
        this.WeaponParticleGameObject.SetActive(true);
    }
    this.WeaponParticleKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponParticleKeyFrameID).NextListID;
    if (this.WeaponParticleKeyFrameID > (ushort) 0)
    {
      ShowMap recordByKey1 = this.ShowMapTable.GetRecordByKey(this.WeaponParticleKeyFrameID);
      ShowEffectSound recordByKey2 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey1.ListID);
      this.SetWeaponParticle(recordByKey2.EffectSoundID, (int) recordByKey2.AttackMode, (float) recordByKey1.ShowTime * 0.0001f);
    }
    this.CheckNextState();
  }

  private void NextWeaponSound()
  {
    if (this.WeaponSoundKeyFrameID == (ushort) 0)
      return;
    this.WeaponSoundKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponSoundKeyFrameID).NextListID;
    if (this.WeaponSoundKeyFrameID > (ushort) 0)
    {
      ShowMap recordByKey1 = this.ShowMapTable.GetRecordByKey(this.WeaponSoundKeyFrameID);
      ShowEffectSound recordByKey2 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey1.ListID);
      this.SetWeaponParticle(recordByKey2.EffectSoundID, (int) recordByKey2.AttackMode, (float) recordByKey1.ShowTime * 0.0001f);
    }
    this.CheckNextState();
  }

  private void endState()
  {
    DataManager.msgBuffer[0] = (byte) 81;
    GameConstants.GetBytes((ushort) 9, DataManager.msgBuffer, 1);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    DataManager.MapDataController.StopMapWeapon();
  }

  private void CheckNextState()
  {
    if ((int) this.WeaponScaleKeyFrameID + (int) this.WeaponRotationKeyFrameID + (int) this.WeaponPositionKeyFrameID + (int) this.WeaponAnimationKeyFrameID + (int) this.WeaponLightColorKeyFrameID + (int) this.WeaponLightRotationKeyFrameID + (int) this.WeaponLightPositionKeyFrameID + (int) this.UpDownImagePositionKeyFrameID + (int) this.UpDownImageColorKeyFrameID + (int) this.WeaponParticleKeyFrameID + (int) this.WeaponSoundKeyFrameID + (int) this.WeaponRotationOffSetKeyFrameID != 0)
      return;
    switch (this.mapWeaponState)
    {
      case MapTileModel.MapWeaponState.Debut:
        this.startShow(this.ShowID);
        break;
      case MapTileModel.MapWeaponState.Show:
        this.startExit(this.ExitID);
        break;
      case MapTileModel.MapWeaponState.Exit:
        this.endState();
        break;
    }
  }

  private void SetWeaponAnimation(
    AnimationUnit.AnimName animName,
    WrapMode animWrapMode,
    float timeTarget,
    float animSpeed = 1f,
    float animTime = 0.0f)
  {
    this.WeaponAnimationName = animName;
    this.WeaponAnimation.wrapMode = animWrapMode;
    this.WeaponAnimation.CrossFade(AnimationUnit.ANIM_STRING[(int) this.WeaponAnimationName]);
    this.WeaponAnimationSpeed = animSpeed;
    this.WeaponAnimationTime = animTime;
    this.WeaponAnimationSpeedTime = 0.0f;
    this.WeaponAnimationSpeedTimeTarget = timeTarget;
    this.WeaponAnimation[AnimationUnit.ANIM_STRING[(int) this.WeaponAnimationName]].speed = this.WeaponAnimationSpeed;
    this.WeaponAnimation[AnimationUnit.ANIM_STRING[(int) this.WeaponAnimationName]].time = this.WeaponAnimationTime;
  }

  private void SetWeaponScale(
    float weaponScaleFrom,
    float weaponScaleTo,
    float weaponScaleTimeTarget)
  {
    this.WeaponScaleFrom = weaponScaleFrom;
    this.WeaponScaleTo = weaponScaleTo;
    this.WeaponScaleTime = 0.0f;
    this.WeaponScaleTimeTarget = weaponScaleTimeTarget;
    this.WeaponTransform.localScale = Vector3.one * this.WeaponScaleFrom;
  }

  private void SetWeaponRotation(
    float weaponRotationXFrom,
    float weaponRotationYFrom,
    float weaponRotationZFrom,
    float weaponRotationXTo,
    float weaponRotationYTo,
    float weaponRotationZTo,
    float weaponRotationTimeTarget)
  {
    this.WeaponRotationXFrom = weaponRotationXFrom + this.WeaponRotationOffSetX;
    this.WeaponRotationYFrom = weaponRotationYFrom + this.WeaponRotationOffSetY;
    this.WeaponRotationZFrom = weaponRotationZFrom + this.WeaponRotationOffSetZ;
    this.WeaponRotationXTo = weaponRotationXTo + this.WeaponRotationOffSetX;
    this.WeaponRotationYTo = weaponRotationYTo + this.WeaponRotationOffSetY;
    this.WeaponRotationZTo = weaponRotationZTo + this.WeaponRotationOffSetZ;
    this.WeaponRotationTime = 0.0f;
    this.WeaponRotationTimeTarget = weaponRotationTimeTarget;
    this.WeaponTransform.localRotation = Quaternion.Euler(this.WeaponRotationXFrom, this.WeaponRotationYFrom, this.WeaponRotationZFrom);
  }

  private void SetWeaponPosition(
    float weaponPositionXFrom,
    float weaponPositionYFrom,
    float weaponPositionZFrom,
    float weaponPositionXTo,
    float weaponPositionYTo,
    float weaponPositionZTo,
    float weaponPositionTimeTarget)
  {
    this.WeaponPositionXFrom = weaponPositionXFrom;
    this.WeaponPositionYFrom = weaponPositionYFrom;
    this.WeaponPositionZFrom = weaponPositionZFrom;
    this.WeaponPositionXTo = weaponPositionXTo;
    this.WeaponPositionYTo = weaponPositionYTo;
    this.WeaponPositionZTo = weaponPositionZTo;
    this.WeaponPositionTime = 0.0f;
    this.WeaponPositionTimeTarget = weaponPositionTimeTarget;
    this.WeaponTransform.localPosition = new Vector3(this.WeaponPositionXFrom, this.WeaponPositionYFrom, this.WeaponPositionZFrom);
  }

  private void SetWeaponLight(
    LightType weaponLightType,
    float weaponLightIntensity,
    byte weaponLightColorRFrom,
    byte weaponLightColorGFrom,
    byte weaponLightColorBFrom,
    byte weaponLightColorRTo,
    byte weaponLightColorGTo,
    byte weaponLightColorBTo,
    float weaponLightColorTimeTarget)
  {
    this.WeaponLight.type = weaponLightType;
    this.WeaponLight.intensity = weaponLightIntensity;
    this.WeaponLightColorRFrom = (float) weaponLightColorRFrom * 0.003921569f;
    this.WeaponLightColorGFrom = (float) weaponLightColorGFrom * 0.003921569f;
    this.WeaponLightColorBFrom = (float) weaponLightColorBFrom * 0.003921569f;
    this.WeaponLightColorRTo = (float) weaponLightColorRTo * 0.003921569f;
    this.WeaponLightColorGTo = (float) weaponLightColorGTo * 0.003921569f;
    this.WeaponLightColorBTo = (float) weaponLightColorBTo * 0.003921569f;
    this.WeaponLightColorTime = 0.0f;
    this.WeaponLightColorTimeTarget = weaponLightColorTimeTarget;
    this.WeaponLight.color = new Color(this.WeaponLightColorRFrom, this.WeaponLightColorGFrom, this.WeaponLightColorBFrom);
  }

  private void SetWeaponLightRotation(
    float weaponLightRotationXFrom,
    float weaponLightRotationYFrom,
    float weaponLightRotationZFrom,
    float weaponLightRotationXTo,
    float weaponLightRotationYTo,
    float weaponLightRotationZTo,
    float weaponLightRotationTimeTarget)
  {
    this.WeaponLightRotationXFrom = weaponLightRotationXFrom;
    this.WeaponLightRotationYFrom = weaponLightRotationYFrom;
    this.WeaponLightRotationZFrom = weaponLightRotationZFrom;
    this.WeaponLightRotationXTo = weaponLightRotationXTo;
    this.WeaponLightRotationYTo = weaponLightRotationYTo;
    this.WeaponLightRotationZTo = weaponLightRotationZTo;
    this.WeaponLightRotationTime = 0.0f;
    this.WeaponLightRotationTimeTarget = weaponLightRotationTimeTarget;
    this.WeaponTransform.localRotation = Quaternion.Euler(this.WeaponLightRotationXFrom, this.WeaponLightRotationYFrom, this.WeaponLightRotationZFrom);
  }

  private void SetWeaponLightPosition(
    float weaponLightPositionXFrom,
    float weaponLightPositionYFrom,
    float weaponLightPositionXTo,
    float weaponLightPositionYTo,
    float weaponLightPositionTimeTarget)
  {
    this.WeaponLightPositionXFrom = weaponLightPositionXFrom;
    this.WeaponLightPositionYFrom = weaponLightPositionYFrom;
    this.WeaponLightPositionXTo = weaponLightPositionXTo;
    this.WeaponLightPositionYTo = weaponLightPositionYTo;
    this.WeaponLightPositionTime = 0.0f;
    this.WeaponLightPositionTimeTarget = weaponLightPositionTimeTarget;
    this.WeaponLightTransform.localPosition = new Vector3(this.WeaponLightPositionXFrom, this.WeaponLightPositionYFrom, this.WeaponLightTransform.localPosition.z);
  }

  private void SetScreenEffectPosition(
    float upDownImagePositionYFrom,
    float upDownImagePositionYTo,
    bool bFront,
    float upDownImagePositionTimeTarget)
  {
    this.UpDownImagePositionYFrom = upDownImagePositionYFrom;
    this.UpDownImagePositionYTo = upDownImagePositionYTo;
    this.UpDownImagePositionTime = 0.0f;
    this.UpDownImagePositionTimeTarget = upDownImagePositionTimeTarget;
    if (bFront)
    {
      if ((Object) this.DownImage != (Object) null && (Object) ((MaskableGraphic) this.DownImage).material != (Object) null && ((MaskableGraphic) this.DownImage).material.renderQueue != 3100)
        ((MaskableGraphic) this.DownImage).material.renderQueue = 3100;
      if ((Object) this.UpImage != (Object) null && (Object) ((MaskableGraphic) this.UpImage).material != (Object) null && ((MaskableGraphic) this.UpImage).material.renderQueue != 3100)
        ((MaskableGraphic) this.UpImage).material.renderQueue = 3100;
    }
    else
    {
      if ((Object) this.DownImage != (Object) null && (Object) ((MaskableGraphic) this.DownImage).material != (Object) null && ((MaskableGraphic) this.DownImage).material.renderQueue != 2890)
        ((MaskableGraphic) this.DownImage).material.renderQueue = 2890;
      if ((Object) this.UpImage != (Object) null && (Object) ((MaskableGraphic) this.UpImage).material != (Object) null && ((MaskableGraphic) this.UpImage).material.renderQueue != 2890)
        ((MaskableGraphic) this.UpImage).material.renderQueue = 2890;
    }
    this.UpImageRectTransform.anchoredPosition = new Vector2(this.UpImageRectTransform.anchoredPosition.x, this.UpDownImagePositionYFrom);
    this.DownImageRectTransform.anchoredPosition = new Vector2(this.DownImageRectTransform.anchoredPosition.x, -this.UpDownImagePositionYFrom);
  }

  private void SetScreenEffectColor(
    byte screenEffectColorRFrom,
    byte screenEffectColorGFrom,
    byte screenEffectColorBFrom,
    byte screenEffectColorAFrom,
    byte screenEffectColorRTo,
    byte screenEffectColorGTo,
    byte screenEffectColorBTo,
    byte screenEffectColorATo,
    float screenEffectColorTimeTarget)
  {
    this.UpDownImageColorRFrom = (float) screenEffectColorRFrom * 0.003921569f;
    this.UpDownImageColorGFrom = (float) screenEffectColorGFrom * 0.003921569f;
    this.UpDownImageColorBFrom = (float) screenEffectColorBFrom * 0.003921569f;
    this.UpDownImageColorAFrom = (float) screenEffectColorAFrom * 0.003921569f;
    this.UpDownImageColorRTo = (float) screenEffectColorRTo * 0.003921569f;
    this.UpDownImageColorGTo = (float) screenEffectColorGTo * 0.003921569f;
    this.UpDownImageColorBTo = (float) screenEffectColorBTo * 0.003921569f;
    this.UpDownImageColorATo = (float) screenEffectColorATo * 0.003921569f;
    this.UpDownImageColorTime = 0.0f;
    this.UpDownImageColorTimeTarget = screenEffectColorTimeTarget;
    Image upImage = this.UpImage;
    Color color1 = new Color(this.UpDownImageColorRFrom, this.UpDownImageColorGFrom, this.UpDownImageColorBFrom, this.UpDownImageColorAFrom);
    ((Graphic) this.DownImage).color = color1;
    Color color2 = color1;
    ((Graphic) upImage).color = color2;
  }

  private void SetWeaponParticle(uint effectID, int attackMode, float startEffectTime)
  {
    if (effectID == 0U && (Object) this.WeaponParticleGameObject != (Object) null && this.WeaponParticleGameObject.activeSelf)
    {
      this.WeaponParticleID = effectID;
    }
    else
    {
      this.sb.Length = 0;
      this.sb.AppendFormat("Effect_{0:00000}", (object) effectID);
      if ((Object) this.WeaponParticle != (Object) null && (int) this.WeaponParticleID != (int) effectID)
      {
        Object.Destroy((Object) this.WeaponParticleGameObject);
        this.WeaponParticleGameObject = (GameObject) null;
        this.WeaponParticle = (ParticleSystem) null;
      }
      this.WeaponParticleID = effectID;
      if ((Object) this.WeaponParticle == (Object) null)
      {
        Object original = this.EffectAssetBundle.Load(this.sb.ToString());
        if (original != (Object) null)
          this.WeaponParticleGameObject = Object.Instantiate(original) as GameObject;
        this.WeaponParticle = !((Object) this.WeaponParticleGameObject != (Object) null) ? (ParticleSystem) null : this.WeaponParticleGameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
      }
      if ((Object) this.WeaponParticle != (Object) null && (Object) this.WeaponParticleGameObject != (Object) null)
      {
        Transform transform1 = this.WeaponParticleGameObject.transform;
        if ((Object) this.WeaponTransform == (Object) null)
        {
          transform1.SetParent(this.AllEffectTransform, false);
        }
        else
        {
          Transform transform2;
          switch (attackMode)
          {
            case 1:
              transform2 = this.hitParticleRoot;
              break;
            case 2:
              transform2 = this.flyRoot;
              break;
            default:
              transform2 = this.AllEffectTransform;
              break;
          }
          transform1.SetParent(transform2, false);
          float zoomSize = DataManager.MapDataController.zoomSize;
          for (int index1 = 0; index1 < transform1.childCount; ++index1)
          {
            ParticleSystem component = transform1.GetChild(index1).GetComponent<ParticleSystem>();
            if ((Object) component != (Object) null)
            {
              float startSize = component.startSize;
              float startLifetime = component.startLifetime;
              component.startSize = startSize * zoomSize;
              component.startLifetime = startLifetime * zoomSize;
              float num1 = component.startSize / startSize;
              float num2 = component.startLifetime / startLifetime;
              int particles = component.GetParticles(this.particles);
              for (int index2 = 0; index2 < particles; ++index2)
              {
                this.particles[index1].size *= num1;
                this.particles[index1].lifetime *= num2;
              }
              component.SetParticles(this.particles, particles);
            }
          }
        }
        this.WeaponParticleGameObject.SetActive(false);
      }
    }
    this.WeaponParticleTime = this.WeaponParticleID != 0U ? startEffectTime : startEffectTime * DataManager.MapDataController.zoomSize;
  }

  private void SetWeaponSound(uint soundID, int attackMode, float startSoundTime)
  {
    Transform PlayObj;
    switch (attackMode)
    {
      case 1:
        PlayObj = this.hitParticleRoot;
        break;
      case 2:
        PlayObj = this.flyRoot;
        break;
      default:
        PlayObj = this.AllEffectTransform;
        break;
    }
    this.WeaponSoundTime = startSoundTime;
    AudioManager.Instance.PlaySFX((ushort) soundID, startSoundTime, PlayObj: PlayObj);
  }

  private enum MapWeaponState : byte
  {
    None,
    Debut,
    Show,
    Exit,
    Count,
  }

  private delegate void MapTileModelUpdateDelegate();
}
