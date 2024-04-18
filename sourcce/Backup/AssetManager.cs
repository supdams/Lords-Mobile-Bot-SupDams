// Decompiled with JetBrains decompiler
// Type: AssetManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

#nullable disable
public class AssetManager
{
  public static string[] PriorityAsset = new string[24]
  {
    "UI",
    "TTFFont",
    "UI",
    "UI_frame",
    "UI",
    "ManagerAsset2",
    "UI",
    "UILoadingTalk",
    "UI",
    "UILight",
    "UI",
    "UITreasureBox",
    "UI",
    "AudioAsset",
    "Role",
    "hero_00001",
    "Role",
    "hero_00007",
    "Role",
    "hero_00009",
    "Role",
    "400",
    "Role",
    "410"
  };
  public static string[] StringAsset = new string[18]
  {
    "StringEng",
    "StringCht",
    "StringFre",
    "StringGem",
    "StringSpa",
    "StringRus",
    "StringChs",
    "StringIdn",
    "StringVet",
    "StringTur",
    "StringTha",
    "StringIta",
    "StringPot",
    "StringKor",
    "StringJap",
    "StringUkr",
    "StringMys",
    "StringArb"
  };
  private static AssetManager instance = (AssetManager) null;
  private AssetState assetState;
  public static List<int>[,] UpdatePackage;
  public static List<int>[,] AssetPackages;
  public static List<AssetUpdate>[] AssetPackage;
  private static Dictionary<int, AssetManager.AssRef> AssetMap;
  private static StringBuilder SOB = new StringBuilder();
  private static AssetManager.AssAsset SAss;
  private static AssetManager.AssAsset SMood;
  private static SceneData SData;
  public static Stage SceneStage;
  public static byte SceneTheme;
  public static byte SceneSide;
  public static byte SceneID;
  public AssetBundle Shader;
  public UnityEngine.Object[] Shaders;
  public static bool Reload;
  public static bool Download;
  public static byte BuildLv;
  public static byte BuildState;
  public static AssetManager.AssAsset BigMac;
  public static AssetManager.AssAsset BigData;
  public static AssetManager.AssAsset BigWall;
  public static AssetManager.AssAsset BigCity;
  public static Transform[] BigMap = new Transform[11];
  public static Vector3 Bearing = new Vector3(0.0f, 0.1f, 0.0f);
  public static string persistentDataPath = Application.persistentDataPath;

  private AssetManager()
  {
    this.AssetManagerState = AssetState.Preload;
    AssetManager.persistentDataPath = IGGSDKPlugin.GetExternalFilesDir();
    AssetManager.Reload = true;
  }

  public AssetState AssetManagerState
  {
    get => this.assetState;
    set => this.assetState = value;
  }

  public static AssetManager Instance
  {
    get
    {
      if (AssetManager.instance == null)
        AssetManager.instance = new AssetManager();
      return AssetManager.instance;
    }
  }

  public static void SetDownload(bool active) => AssetManager.Download = active;

  public static bool GetAssetBundleDownload(
    CString Name,
    AssetPath Path,
    AssetType Type,
    ushort Id,
    bool DontUpdate = false)
  {
    bool assetBundleDownload = false;
    int hashCode = Name.GetHashCode(true);
    AssetManager.AssRef assRef;
    if (!AssetManager.AssetMap.TryGetValue(hashCode, out assRef))
    {
      AssetManager.SetAssetBundle(hashCode, 0L);
      assRef.Internal = true;
    }
    else if ((bool) (UnityEngine.Object) assRef.Asset)
      assetBundleDownload = true;
    if (!assetBundleDownload)
    {
      CString cstring = StringManager.Instance.StaticString1024();
      if (!assRef.Internal)
      {
        cstring.StringToFormat(Application.dataPath);
        cstring.StringToFormat(Name);
        cstring.AppendFormat("{0}!assets/{1}.unity3d");
      }
      else
      {
        cstring.StringToFormat(AssetManager.persistentDataPath);
        cstring.StringToFormat(Name);
        cstring.AppendFormat("{0}/{1}.unity3d");
      }
      if ((bool) (UnityEngine.Object) (assRef.Asset = AssetBundle.CreateFromFile(cstring.ToString())))
      {
        assRef.Asset.Unload(true);
        assetBundleDownload = true;
      }
    }
    if (DontUpdate && assetBundleDownload)
      return true;
    switch (Path)
    {
      case AssetPath.Store:
        switch (Type)
        {
          case AssetType.MallBack:
            AssetManager.RequestMallBundle(Id);
            break;
          case AssetType.MallPackage:
            AssetManager.RequestMallPackage(Id);
            break;
        }
        break;
      case AssetPath.Activity:
        switch (Type)
        {
          case AssetType.ActivityBack:
            AssetManager.RequestActivityBundle(Id);
            break;
          case AssetType.ActivityPackage:
            AssetManager.RequestActivityPackage(Id);
            break;
        }
        break;
      default:
        AssetManager.DownloadAssetBundle(Name, Path, Type, Id);
        break;
    }
    return assetBundleDownload;
  }

  public static void DownloadAssetBundle(
    CString Name,
    AssetPath Path,
    AssetType Type,
    ushort Id,
    bool bFail = false)
  {
    if (bFail)
      return;
    AssetManager.AssetPackage[0].Add(new AssetUpdate(Name.ToString(), (byte) Path, (byte) Type, (int) Id));
    DownloadController.Refresh();
  }

  public static void RequestDownload(
    CString Name,
    AssetPath Path,
    AssetType Type,
    ushort Id,
    bool bFail = false)
  {
    DataManager.msgBuffer[0] = (byte) Path;
    DataManager.msgBuffer[1] = (byte) Type;
    GameConstants.GetBytes(Id, DataManager.msgBuffer, 2);
    GameManager.OnRefresh(NetworkNews.Refresh_Asset, DataManager.msgBuffer);
  }

  public static void RequestActivityBundle(ushort id, bool bFail = false)
  {
    if (bFail && !AssetManager.AssetPackages[0, 1].Contains((int) id))
      AssetManager.AssetPackages[0, 1].Add((int) id);
    else if (!bFail && !AssetManager.AssetPackages[0, 0].Contains((int) id))
      AssetManager.AssetPackages[0, 0].Add((int) id);
    DownloadController.Refresh();
  }

  public static void RequestActivityPackage(ushort id, bool bFail = false)
  {
    if (bFail && !AssetManager.AssetPackages[1, 1].Contains((int) id))
      AssetManager.AssetPackages[1, 1].Add((int) id);
    else if (!bFail && !AssetManager.AssetPackages[1, 0].Contains((int) id))
      AssetManager.AssetPackages[1, 0].Add((int) id);
    DownloadController.Refresh();
  }

  public static void RequestMallBundle(ushort id, bool bFail = false)
  {
    if (bFail && !AssetManager.UpdatePackage[0, 1].Contains((int) id))
      AssetManager.UpdatePackage[0, 1].Add((int) id);
    else if (!bFail && !AssetManager.UpdatePackage[0, 0].Contains((int) id))
      AssetManager.UpdatePackage[0, 0].Add((int) id);
    DownloadController.Refresh();
  }

  public static void RequestMallPackage(ushort id, bool bFail = false)
  {
    if (bFail && !AssetManager.UpdatePackage[1, 1].Contains((int) id))
      AssetManager.UpdatePackage[1, 1].Add((int) id);
    else if (!bFail && !AssetManager.UpdatePackage[1, 0].Contains((int) id))
      AssetManager.UpdatePackage[1, 0].Add((int) id);
    DownloadController.Refresh();
  }

  public static AssetBundle GetAssetBundle(string Name, out int Key, bool Inside = false)
  {
    Key = Name.ToUpperInvariant().GetHashCode();
    AssetManager.AssRef assRef;
    if (!AssetManager.AssetMap.TryGetValue(Key, out assRef) || !(bool) (UnityEngine.Object) assRef.Asset || assRef.RefCount == 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (assRef.Internal || Inside)
        stringBuilder.AppendFormat("{0}/{1}.unity3d", (object) AssetManager.persistentDataPath, (object) Name);
      else
        stringBuilder.AppendFormat("{0}!assets/{1}.unity3d", (object) Application.dataPath, (object) Name);
      assRef.Set(AssetBundle.CreateFromFile(stringBuilder.ToString()));
    }
    ++assRef.RefCount;
    AssetManager.AssetMap[Key] = assRef;
    return assRef.Asset;
  }

  public static AssetBundle GetAssetBundle(CString Name, out int Key)
  {
    Key = Name.GetHashCode(true);
    AssetManager.AssRef assRef;
    if (!AssetManager.AssetMap.TryGetValue(Key, out assRef) || !(bool) (UnityEngine.Object) assRef.Asset || assRef.RefCount == 0)
    {
      CString cstring = StringManager.Instance.StaticString1024();
      if (!assRef.Internal)
      {
        cstring.StringToFormat(Application.dataPath);
        cstring.StringToFormat(Name);
        cstring.AppendFormat("{0}!assets/{1}.unity3d");
      }
      else
      {
        cstring.StringToFormat(AssetManager.persistentDataPath);
        cstring.StringToFormat(Name);
        cstring.AppendFormat("{0}/{1}.unity3d");
      }
      assRef.Set(AssetBundle.CreateFromFile(cstring.ToString()));
    }
    ++assRef.RefCount;
    AssetManager.AssetMap[Key] = assRef;
    return assRef.Asset;
  }

  [Obsolete]
  public static AssetBundle GetAssetBundle(string name, long stamper = 0)
  {
    AssetManager.SOB.Length = 0;
    AssetManager.AssRef assRef;
    if (stamper > 0L && !AssetManager.AssetMap.TryGetValue(name.ToUpperInvariant().GetHashCode(), out assRef))
    {
      using (FileStream fileStream = new FileStream(AssetManager.SOB.AppendFormat("{0}/{1}", (object) AssetManager.persistentDataPath, (object) name).ToString(), FileMode.OpenOrCreate))
      {
        using (StreamReader streamReader = new StreamReader((Stream) fileStream))
        {
          long result;
          if (long.TryParse(streamReader.ReadLine(), out result) && stamper <= result)
            AssetManager.SetAssetBundle(name.ToUpperInvariant().GetHashCode(), result);
          else
            AssetManager.SetAssetBundle(name.ToUpperInvariant().GetHashCode(), stamper, false);
        }
      }
    }
    StringBuilder stringBuilder = new StringBuilder();
    if (!AssetManager.AssetMap.TryGetValue(name.ToUpperInvariant().GetHashCode(), out assRef) || !assRef.Internal)
      stringBuilder.AppendFormat("{0}!assets/{1}.unity3d", (object) Application.dataPath, (object) name);
    else
      stringBuilder.AppendFormat("{0}/{1}.unity3d", (object) AssetManager.persistentDataPath, (object) name);
    return AssetBundle.CreateFromFile(stringBuilder.ToString());
  }

  public static void UnloadAssetBundle(int Key, bool UnloadAll = true)
  {
    AssetManager.AssRef assRef;
    if (!AssetManager.AssetMap.TryGetValue(Key, out assRef) || assRef.RefCount <= 0)
      return;
    --assRef.RefCount;
    if (assRef.RefCount == 0 && (bool) (UnityEngine.Object) assRef.Asset)
      assRef.Asset.Unload(UnloadAll);
    AssetManager.AssetMap[Key] = assRef;
  }

  public static void SetAssetBundle(int Key, long Stamp, bool Insideout = true)
  {
    AssetManager.AssRef assRef;
    AssetManager.AssetMap.TryGetValue(Key, out assRef);
    assRef.Internal = Insideout;
    assRef.Stamping = Stamp;
    AssetManager.AssetMap[Key] = assRef;
  }

  public static long GetAssetStamp(int Key)
  {
    AssetManager.AssRef assRef;
    AssetManager.AssetMap.TryGetValue(Key, out assRef);
    return assRef.Stamping;
  }

  public static void RefreshAssetBundle(int Key, bool UnloadAll = false)
  {
    AssetManager.AssRef assRef;
    if (!AssetManager.AssetMap.TryGetValue(Key, out assRef) || !(bool) (UnityEngine.Object) assRef.Asset)
      return;
    assRef.Asset.Unload(UnloadAll);
  }

  public static void FreeAss()
  {
    if (AssetManager.AssetMap == null)
      return;
    foreach (AssetManager.AssRef assRef in AssetManager.AssetMap.Values)
    {
      if ((bool) (UnityEngine.Object) assRef.Asset)
        assRef.Asset.Unload(true);
    }
    AssetManager.AssetMap.Clear();
    if ((bool) (UnityEngine.Object) AssetManager.Instance.Shader)
      AssetManager.Instance.Shader.Unload(true);
    AssetManager.BigData.Unload();
    AssetManager.BigMac.Unload();
  }

  public static void SetAssetMap(int amount)
  {
    if (AssetManager.AssetMap != null)
      return;
    AssetManager.AssetPackages = new List<int>[2, 2];
    AssetManager.UpdatePackage = new List<int>[2, 2];
    for (int index1 = 0; index1 < 2; ++index1)
    {
      for (int index2 = 0; index2 < 2; ++index2)
      {
        AssetManager.AssetPackages[index1, index2] = new List<int>();
        AssetManager.UpdatePackage[index1, index2] = new List<int>();
      }
    }
    AssetManager.AssetPackage = new List<AssetUpdate>[2];
    for (int index = 0; index < 2; ++index)
      AssetManager.AssetPackage[index] = new List<AssetUpdate>();
    AssetManager.AssetMap = new Dictionary<int, AssetManager.AssRef>(amount);
  }

  public static void UnloadAsses()
  {
    DataManager instance = DataManager.Instance;
    if (AssetManager.AssetMap != null && instance.bLoadingTableSuccess)
    {
      AssetManager.BigMac.Unload();
      AssetManager.BigData.Unload();
      DataManager.MissionDataManager.Reset();
    }
    DownloadController.Reset();
    DataManager.Instance.Init();
    GUIManager.Instance.pDVMgr.UnLoadDamageValueAsset();
    AudioManager.Instance.UnLoadBGM();
    GUIManager.Instance.UnloadAssets();
    MallManager.Instance.UnloadAsset();
    ActivityManager.Instance.ResetPara();
    PetManager.Instance.UnloadAsset();
    if (instance.m_BannedWord != null)
    {
      instance.m_BannedWord.UnLoadBannedWordTable();
      instance.m_BannedWord.UnLoadBannedWordTable2();
    }
    Array.Clear((Array) instance.TempFightHeroID, 0, instance.TempFightHeroID.Length);
    Array.Clear((Array) instance.FightHeroID, 0, instance.FightHeroID.Length);
    Array.Clear((Array) instance.NonFightHeroID, 0, instance.NonFightHeroID.Length);
    Array.Clear((Array) instance.SortNonFightHeroID, 0, instance.SortNonFightHeroID.Length);
    Array.Clear((Array) instance.SelectHeroID, 0, instance.SelectHeroID.Length);
    instance.LegionBattleHero.Clear();
    instance.FightHeroCount = 0U;
    instance.NonFightHeroCount = 0U;
    BattleNetwork.NetworkError = (byte) 0;
    instance.InitMarchData();
    instance.curHeroData.Clear();
    Array.Clear((Array) instance.sortHeroData, 0, instance.sortHeroData.Length);
    instance.ResetBuffData();
    instance.InitAltarTime();
    NewbieManager.Free();
    PushManage.PushStart = false;
  }

  public void LoadShader(string name)
  {
    if (!AssetManager.Reload)
      return;
    AssetManager.Reload = false;
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendFormat("{0}!assets/Loading/{1}.unity3d", (object) Application.dataPath, (object) name);
    if ((bool) (UnityEngine.Object) this.Shader)
    {
      this.Shader.Unload(true);
      Handheld.ClearShaderCache();
    }
    if (!(bool) (UnityEngine.Object) (this.Shader = AssetBundle.CreateFromFile(stringBuilder.ToString())))
      return;
    this.Shaders = this.Shader.LoadAll();
  }

  public static void LoadMap(ushort Scene, byte Theme = 1, WarParticleManager WarP = null)
  {
    AssetManager.UnloadBigMap();
    AssetManager.SOB.Length = 0;
    AssetManager.SOB.AppendFormat("Scene/TMAP_{0}", (object) Scene.ToString("d3"));
    if (!(bool) (UnityEngine.Object) (AssetManager.BigMac.Ass = AssetManager.GetAssetBundle(AssetManager.SOB.ToString(), out AssetManager.BigMac.AssKey)) || !(bool) (AssetManager.BigMac.Asset = UnityEngine.Object.Instantiate(AssetManager.BigMac.Ass.Load(AssetManager.SOB.Remove(0, 6).ToString(), typeof (GameObject)))))
      return;
    AssetManager.SOB.Length = 0;
    AssetManager.SOB.AppendFormat("Scene/TMAP_{0}_M{1}", (object) Scene.ToString("d3"), (object) 1);
    if ((bool) (UnityEngine.Object) (AssetManager.BigMap[0] = ((GameObject) AssetManager.BigMac.Asset).transform.Find(AssetManager.SOB.ToString())))
    {
      AssetManager.BigMap[0].position -= AssetManager.Bearing;
      AssetManager.BigMap[0].gameObject.AddComponent("ShadowReceiver");
      StringBuilder sob = AssetManager.SOB;
      int num1 = 0;
      AssetManager.BigMap[0].renderer.lightmapIndex = num1;
      int num2 = num1;
      sob.Length = num2;
      AssetManager.SOB.AppendFormat("Scene/TMAP_{0}_{1}", (object) Scene.ToString("d3"), (object) Theme);
      if ((bool) (UnityEngine.Object) (AssetManager.BigData.Ass = AssetManager.GetAssetBundle(AssetManager.SOB.ToString(), out AssetManager.BigData.AssKey)))
      {
        if (!(bool) (UnityEngine.Object) (AssetManager.SData = AssetManager.BigData.Ass.mainAsset as SceneData))
        {
          AssetManager.SOB.Length = 0;
          AssetManager.SOB.AppendFormat("SceneData0{0}", (object) Theme);
          AssetManager.SData = AssetManager.BigData.Ass.Load(AssetManager.SOB.ToString()) as SceneData;
        }
        RenderSettings.fog = AssetManager.SData.mfog;
        RenderSettings.fogColor = AssetManager.SData.mfogcolor;
        RenderSettings.fogDensity = AssetManager.SData.mfogDensity;
        RenderSettings.fogStartDistance = AssetManager.SData.mfogStartDistance;
        RenderSettings.fogEndDistance = AssetManager.SData.mfogEndDistance;
        RenderSettings.ambientLight = AssetManager.SData.mambientLight;
        RenderSettings.fogMode = (FogMode) AssetManager.SData.mfogMode;
        int length = AssetManager.SData.Lightmap.Length;
        LightmapData[] lightmapData = new LightmapData[length + (int) LightmapManager.Instance.GetCustomLightmapNum()];
        for (byte index = 0; (int) index < length; ++index)
          lightmapData[(int) index] = new LightmapData()
          {
            lightmapFar = AssetManager.SData.Lightmap[(int) index]
          };
        LightmapManager.Instance.UpdateCurLightmap(lightmapData);
        LightmapSettings.lightmaps = lightmapData;
        LightmapSettings.lightmapsMode = LightmapsMode.Single;
        LightmapSettings.lightProbes = AssetManager.SData.Lightprobe;
        Camera.main.backgroundColor = AssetManager.SData.cameraBackgroundColor;
      }
    }
    Transform child1;
    if (!(bool) (UnityEngine.Object) (child1 = ((GameObject) AssetManager.BigMac.Asset).transform.FindChild(nameof (Theme))))
      return;
    for (ushort index1 = 0; (int) index1 < child1.childCount; ++index1)
    {
      Transform child2;
      if ((child2 = child1.GetChild((int) index1)).name.Contains(Theme.ToString()))
      {
        ushort index2 = 0;
        ushort result = 0;
        for (; (int) index2 < child2.childCount; ++index2)
        {
          GameObject gameObject;
          if (ushort.TryParse(child2.GetChild((int) index2).name, out result) && (bool) (UnityEngine.Object) (gameObject = WarP.Spawn(result, (Transform) null, child2.GetChild((int) index2).position, 1f, true, false)))
            gameObject.transform.SetParent(((GameObject) AssetManager.BigMac.Asset).transform, false);
        }
      }
    }
  }

  public static void LoadScene(ushort name)
  {
    AssetManager.SceneStage = DataManager.StageDataController.StageTable.GetRecordByKey(name);
  }

  public static void QuitScene()
  {
    AssetManager.SceneID = (byte) 0;
    AssetManager.SAss.Unload();
    AssetManager.SMood.Unload();
    LightmapSettings.lightmaps = (LightmapData[]) null;
    LightmapSettings.lightProbes = (LightProbes) null;
    Camera.main.backgroundColor = Color.clear;
  }

  public static void LoadStage(
    byte level,
    ref Transform out_mapObject1,
    ref Transform out_mapObject2)
  {
    if (level < (byte) 1 || level > (byte) 3)
      return;
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendFormat("Scene/map_{0}", (object) AssetManager.SceneStage.Arrays[(int) level - 1].Scene.ToString("d3"));
    if ((int) AssetManager.SceneID != (int) AssetManager.SceneStage.Arrays[(int) level - 1].Scene)
    {
      AssetManager.QuitScene();
      GC.Collect();
      AssetManager.SceneTheme = AssetManager.SceneSide = (byte) 0;
      if ((bool) (UnityEngine.Object) (AssetManager.SAss.Ass = AssetManager.GetAssetBundle(stringBuilder.ToString(), out AssetManager.SAss.AssKey)) && (bool) (AssetManager.SAss.Asset = UnityEngine.Object.Instantiate(AssetManager.SAss.Ass.Load(stringBuilder.Remove(0, 6).ToString()))) && (bool) (UnityEngine.Object) (AssetManager.BigMap[0] = ((GameObject) AssetManager.SAss.Asset).transform))
      {
        Transform child = AssetManager.BigMap[0].FindChild("Scene");
        int num = !(bool) (UnityEngine.Object) child ? 2 : Mathf.Min(child.childCount, 10);
        for (int index = 1; index <= num; ++index)
        {
          stringBuilder.Length = 0;
          stringBuilder.AppendFormat("{0}_m{1}", (object) AssetManager.SceneStage.Arrays[(int) level - 1].Scene.ToString("d3"), (object) index);
          AssetManager.BigMap[index] = !(bool) (UnityEngine.Object) child ? AssetManager.BigMap[0].FindChild(stringBuilder.ToString()) : child.FindChild(stringBuilder.ToString());
        }
        AssetManager.BigMap[0].position -= AssetManager.Bearing;
        if ((bool) (UnityEngine.Object) AssetManager.BigMap[1])
        {
          AssetManager.BigMap[1].gameObject.AddComponent("ShadowReceiver");
          out_mapObject1 = AssetManager.BigMap[1];
        }
        if ((bool) (UnityEngine.Object) AssetManager.BigMap[2])
          out_mapObject2 = AssetManager.BigMap[2];
      }
      AssetManager.SceneID = AssetManager.SceneStage.Arrays[(int) level - 1].Scene;
    }
    if (!(bool) AssetManager.SAss.Asset)
      return;
    if ((int) AssetManager.SceneStage.Arrays[(int) level - 1].Theme != (int) AssetManager.SceneTheme)
    {
      AssetManager.SceneTheme = AssetManager.SceneStage.Arrays[(int) level - 1].Theme;
      stringBuilder.Length = 0;
      stringBuilder.AppendFormat("Scene/map_{0}_{1}", (object) AssetManager.SceneID.ToString("d3"), (object) AssetManager.SceneTheme);
      LightmapSettings.lightmaps = (LightmapData[]) null;
      LightmapSettings.lightProbes = (LightProbes) null;
      if (AssetManager.SMood.Unload())
        GC.Collect();
      AssetManager.SMood.Ass = AssetManager.GetAssetBundle(stringBuilder.ToString(), out AssetManager.SMood.AssKey);
      if ((bool) (UnityEngine.Object) AssetManager.SMood.Ass)
      {
        Transform child1;
        if ((bool) (UnityEngine.Object) (child1 = AssetManager.BigMap[0].FindChild("Theme")))
        {
          for (int index = 0; index < child1.childCount; ++index)
          {
            Transform child2 = child1.GetChild(index);
            child2.gameObject.SetActive(child2.name.Contains(AssetManager.SceneTheme.ToString()));
          }
        }
        if (!(bool) (UnityEngine.Object) (AssetManager.SData = AssetManager.SMood.Ass.mainAsset as SceneData))
        {
          stringBuilder.Length = 0;
          stringBuilder.AppendFormat("SceneData0{0}", (object) AssetManager.SceneTheme);
          AssetManager.SData = AssetManager.SMood.Ass.Load(stringBuilder.ToString()) as SceneData;
        }
        RenderSettings.fog = AssetManager.SData.mfog;
        RenderSettings.fogColor = AssetManager.SData.mfogcolor;
        RenderSettings.fogDensity = AssetManager.SData.mfogDensity;
        RenderSettings.fogStartDistance = AssetManager.SData.mfogStartDistance;
        RenderSettings.fogEndDistance = AssetManager.SData.mfogEndDistance;
        RenderSettings.ambientLight = AssetManager.SData.mambientLight;
        RenderSettings.fogMode = (FogMode) AssetManager.SData.mfogMode;
        int length = AssetManager.SData.Lightmap.Length;
        LightmapData[] lightmapData = new LightmapData[length + (int) LightmapManager.Instance.GetCustomLightmapNum()];
        for (byte index = 0; (int) index < length; ++index)
        {
          lightmapData[(int) index] = new LightmapData()
          {
            lightmapFar = AssetManager.SData.Lightmap[(int) index]
          };
          if ((bool) (UnityEngine.Object) AssetManager.BigMap[(int) index + 1])
            AssetManager.BigMap[(int) index + 1].renderer.lightmapIndex = (int) index;
        }
        LightmapManager.Instance.UpdateCurLightmap(lightmapData);
        LightmapSettings.lightmaps = lightmapData;
        LightmapSettings.lightmapsMode = LightmapsMode.Single;
        LightmapSettings.lightProbes = AssetManager.SData.Lightprobe;
        Camera.main.backgroundColor = AssetManager.SData.cameraBackgroundColor;
      }
      else
      {
        RenderSettingsData renderSettingsData = AssetManager.SAss.Ass.Load("RData") as RenderSettingsData;
        if ((bool) (UnityEngine.Object) renderSettingsData)
        {
          RenderSettings.fog = renderSettingsData.mfog;
          RenderSettings.fogColor = renderSettingsData.mfogcolor;
          RenderSettings.fogDensity = renderSettingsData.mfogDensity;
          RenderSettings.fogStartDistance = renderSettingsData.mfogStartDistance;
          RenderSettings.fogEndDistance = renderSettingsData.mfogEndDistance;
          RenderSettings.ambientLight = renderSettingsData.mambientLight;
          RenderSettings.fogMode = (FogMode) renderSettingsData.mfogMode;
          LightmapData[] lightmapData = new LightmapData[1 + (int) LightmapManager.Instance.GetCustomLightmapNum()];
          lightmapData[0] = new LightmapData()
          {
            lightmapFar = (Texture2D) AssetManager.SAss.Ass.Load("LightmapFar-0")
          };
          LightmapManager.Instance.UpdateCurLightmap(lightmapData);
          LightmapSettings.lightmaps = lightmapData;
          LightmapSettings.lightmapsMode = LightmapsMode.Single;
          LightmapSettings.lightProbes = (LightProbes) AssetManager.SAss.Ass.Load("LightProbes");
          Camera.main.backgroundColor = AssetManager.SData.cameraBackgroundColor;
        }
      }
    }
    else
      GC.Collect();
    if ((int) AssetManager.SceneStage.Arrays[(int) level - 1].Face == (int) AssetManager.SceneSide)
      return;
    AssetManager.SceneSide = AssetManager.SceneStage.Arrays[(int) level - 1].Face;
    ((GameObject) AssetManager.SAss.Asset).transform.RotateAround(new Vector3(11.9f, 0.0f, 5.55f), Vector3.up, 180f);
  }

  public static void LoadBigMap()
  {
    AssetManager.UnloadBigMap();
    AssetManager.SOB.Length = 0;
    AssetManager.SOB.AppendFormat("Scene/wmap");
    AssetManager.BigMac.Ass = AssetManager.GetAssetBundle(AssetManager.SOB.ToString(), out AssetManager.BigMac.AssKey);
    AssetManager.BigMac.Asset = UnityEngine.Object.Instantiate(AssetManager.BigMac.Ass.Load(AssetManager.SOB.Remove(0, 6).ToString()));
    if (!(bool) AssetManager.BigMac.Asset)
      return;
    for (byte index = 0; (int) index < AssetManager.BigMap.Length; ++index)
    {
      AssetManager.SOB.Length = 0;
      AssetManager.SOB.AppendFormat("wmap_m{0:D2}", (object) index);
      AssetManager.BigMap[(int) index] = ((GameObject) AssetManager.BigMac.Asset).transform.FindChild(AssetManager.SOB.ToString());
      if ((bool) (UnityEngine.Object) AssetManager.BigMap[(int) index])
        AssetManager.BigMap[(int) index].renderer.lightmapIndex = index != (byte) 0 ? (int) index - 1 : 14;
    }
    if (GUIManager.Instance.BuildingData.AllBuildsData != null)
      AssetManager.SetCastleLevel(GUIManager.Instance.BuildingData.GetBuildData((ushort) 12, (ushort) 0).Level, (byte) 0);
    AssetManager.SOB.Length = 0;
    AssetManager.SOB.AppendFormat("Scene/wmap_{0}", (object) 1);
    AssetManager.BigData.Ass = AssetManager.GetAssetBundle(AssetManager.SOB.ToString(), out AssetManager.BigData.AssKey);
    if (!(bool) (UnityEngine.Object) AssetManager.BigData.Ass)
      return;
    AssetManager.SOB.Length = 0;
    AssetManager.SOB.AppendFormat("SceneData0{0}", (object) 1);
    SceneData sceneData = AssetManager.BigData.Ass.Load(AssetManager.SOB.ToString()) as SceneData;
    RenderSettings.fog = sceneData.mfog;
    RenderSettings.fogColor = sceneData.mfogcolor;
    RenderSettings.fogDensity = sceneData.mfogDensity;
    RenderSettings.fogStartDistance = sceneData.mfogStartDistance;
    RenderSettings.fogEndDistance = sceneData.mfogEndDistance;
    RenderSettings.ambientLight = sceneData.mambientLight;
    RenderSettings.fogMode = (FogMode) sceneData.mfogMode;
    int length = sceneData.Lightmap.Length;
    LightmapData[] lightmapData = new LightmapData[length + (int) LightmapManager.Instance.GetCustomLightmapNum()];
    for (byte index = 0; (int) index < length; ++index)
      lightmapData[(int) index] = new LightmapData()
      {
        lightmapFar = sceneData.Lightmap[(int) index]
      };
    LightmapManager.Instance.UpdateCurLightmap(lightmapData);
    LightmapSettings.lightmaps = lightmapData;
    LightmapSettings.lightmapsMode = LightmapsMode.Single;
    LightmapSettings.lightProbes = sceneData.Lightprobe;
    Camera.main.backgroundColor = sceneData.cameraBackgroundColor;
  }

  public static void SetCastleLevel(byte Level, byte Status)
  {
    DataManager.msgBuffer[0] = (byte) 41;
    DataManager.msgBuffer[1] = Level;
    DataManager.msgBuffer[2] = Status;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public static void OriginSetCastleLevel(byte Level, byte Status)
  {
    Status = DataManager.Instance.m_WallRepairNowValue >= DataManager.Instance.m_WallRepairMaxValue ? (byte) 0 : (byte) 1;
    if (!(bool) AssetManager.BigMac.Asset || (bool) (UnityEngine.Object) AssetManager.BigCity.Ass && (int) AssetManager.BuildLv == (int) Level && (int) AssetManager.BuildState == (int) Status)
      return;
    AssetManager.BuildLv = Level;
    AssetManager.BuildState = Status;
    AssetManager.BigCity.Unload();
    Level = Level >= (byte) 9 ? (Level >= (byte) 17 ? (Level >= (byte) 25 ? (byte) 4 : (byte) 3) : (byte) 2) : (byte) 1;
    AssetManager.SOB.Length = 0;
    AssetManager.SOB.AppendFormat("Scene/wall");
    if (!(bool) (UnityEngine.Object) (AssetManager.BigCity.Ass = AssetManager.GetAssetBundle(AssetManager.SOB.ToString(), out AssetManager.BigCity.AssKey)) || !(bool) (AssetManager.BigCity.Asset = AssetManager.BigCity.Ass.Load(AssetManager.SOB.Remove(0, 6).Append(Level).Append(Status).ToString())))
      return;
    for (int length = AssetManager.BigMap.Length; length > 0; --length)
    {
      if ((bool) (UnityEngine.Object) AssetManager.BigMap[length - 1])
      {
        ((GameObject) (AssetManager.BigCity.Asset = UnityEngine.Object.Instantiate(AssetManager.BigCity.Asset))).transform.SetParent(((GameObject) AssetManager.BigMac.Asset).transform);
        ((GameObject) AssetManager.BigCity.Asset).renderer.lightmapIndex = AssetManager.BigMap[length - 1].renderer.lightmapIndex + (int) Level;
        break;
      }
    }
  }

  public static void UnloadBigMap()
  {
    AssetManager.BigMac.Unload();
    AssetManager.BigData.Unload();
    AssetManager.BigCity.Unload();
    AssetManager.BigWall.Unload();
    LightmapSettings.lightmaps = (LightmapData[]) null;
    LightmapSettings.lightProbes = (LightProbes) null;
    LightmapManager.Instance.SceneLightmapSize = 0;
  }

  public struct AssRef
  {
    public int RefCount;
    public bool Internal;
    public long Stamping;
    public AssetBundle Asset;

    public bool Set(AssetBundle Ass)
    {
      if (!(bool) (UnityEngine.Object) (this.Asset = Ass))
        return NetworkManager.Miss();
      this.RefCount = 0;
      return false;
    }
  }

  public struct AssAsset
  {
    public int AssKey;
    public UnityEngine.Object Asset;
    public AssetBundle Ass;

    public bool Unload()
    {
      UnityEngine.Object.DestroyImmediate(this.Asset);
      this.Asset = (UnityEngine.Object) null;
      if (!(bool) (UnityEngine.Object) this.Ass)
        return false;
      AssetManager.UnloadAssetBundle(this.AssKey);
      return true;
    }
  }
}
