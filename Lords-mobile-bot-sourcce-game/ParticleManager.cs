// Decompiled with JetBrains decompiler
// Type: ParticleManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

#nullable disable
public class ParticleManager
{
  private const ushort MaxAbEffectNum = 400;
  private static ParticleManager instance;
  private StringBuilder sb = new StringBuilder();
  private string effName;
  private string abName;
  private Dictionary<ushort, Stack<GameObject>> stackDic = new Dictionary<ushort, Stack<GameObject>>();
  private Dictionary<ushort, Object> resourcesDic = new Dictionary<ushort, Object>();
  private List<GameObject> onecEffect = new List<GameObject>();
  private Dictionary<ushort, AssetBundle> abDic = new Dictionary<ushort, AssetBundle>();
  private List<int> bundleKeyList = new List<int>();
  private int assetBundleKey;
  private int totalEffect;
  private int LoadABCount;
  private int OnecEffectCount;
  public GameObject AllEffectObject;
  public static bool bIsLoad;

  public void PreLoadHeroEffect()
  {
    if (!(GameManager.ActiveGameplay is BattleController activeGameplay))
      return;
    int playerCount = activeGameplay.playerCount;
    for (int index1 = 0; index1 < playerCount; ++index1)
    {
      ushort[] preLoadParticleId = this.GetPreLoadParticleID(activeGameplay.playerUnit[index1].NpcID);
      for (int index2 = 0; index2 < preLoadParticleId.Length; ++index2)
      {
        if (!this.stackDic.ContainsKey(preLoadParticleId[index2]))
        {
          GameObject go = this.Spawn(preLoadParticleId[index2], (Transform) null, new Vector3(), 1f, false);
          if (!this.IsOnceEffect(go))
            this.DeSpawn(go);
        }
      }
    }
    this.ClearOnecEffect();
  }

  public void PreLoadEnemyEffect(int level)
  {
    if (!(GameManager.ActiveGameplay is BattleController activeGameplay) || level >= activeGameplay.m_MaxStageLevel || level < 0)
      return;
    int length = activeGameplay.teamTable[level].Arrays.Length;
    for (int index1 = 0; index1 < length; ++index1)
    {
      ushort[] preLoadParticleId = this.GetPreLoadParticleID(activeGameplay.teamTable[level].Arrays[index1].Hero);
      for (int index2 = 0; index2 < preLoadParticleId.Length; ++index2)
      {
        if (!this.stackDic.ContainsKey(preLoadParticleId[index2]))
        {
          GameObject go = this.Spawn(preLoadParticleId[index2], (Transform) null, new Vector3(), 1f, false);
          if (!this.IsOnceEffect(go))
            this.DeSpawn(go);
        }
      }
    }
    this.ClearOnecEffect();
  }

  private ushort[] GetPreLoadParticleID(ushort heroID)
  {
    ushort[] preLoadParticleId = new ushort[20];
    if (DataManager.Instance.HeroTable == null)
      return preLoadParticleId;
    Hero recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(heroID);
    int length = recordByKey1.AttackPower.Length;
    int num1 = 0;
    for (ushort index1 = 0; (int) index1 < length; ++index1)
    {
      Skill recordByKey2 = DataManager.Instance.SkillTable.GetRecordByKey(recordByKey1.AttackPower[(int) index1]);
      ushort[] numArray1 = preLoadParticleId;
      int index2 = num1;
      int num2 = index2 + 1;
      int hitParticle = (int) recordByKey2.HitParticle;
      numArray1[index2] = (ushort) hitParticle;
      ushort[] numArray2 = preLoadParticleId;
      int index3 = num2;
      int num3 = index3 + 1;
      int fireParticle = (int) recordByKey2.FireParticle;
      numArray2[index3] = (ushort) fireParticle;
      ushort[] numArray3 = preLoadParticleId;
      int index4 = num3;
      int num4 = index4 + 1;
      int rangeHitParticle = (int) recordByKey2.RangeHitParticle;
      numArray3[index4] = (ushort) rangeHitParticle;
      ushort[] numArray4 = preLoadParticleId;
      int index5 = num4;
      num1 = index5 + 1;
      int flyParticle = (int) recordByKey2.FlyParticle;
      numArray4[index5] = (ushort) flyParticle;
    }
    return preLoadParticleId;
  }

  public static ParticleManager Instance
  {
    get
    {
      if (ParticleManager.instance == null)
        ParticleManager.instance = new ParticleManager();
      return ParticleManager.instance;
    }
  }

  public void Setup()
  {
    this.AllEffectObject = new GameObject();
    this.AllEffectObject.name = "AllEffect";
    this.GetAssetBundleByEffID((ushort) 1);
    ParticleManager.bIsLoad = true;
  }

  public void ShowDebug()
  {
    IDictionaryEnumerator enumerator = (IDictionaryEnumerator) this.stackDic.GetEnumerator();
    Debug.Log((object) "-----------------Particle ShowDebug-----------------");
    while (enumerator.MoveNext())
    {
      this.sb.Length = 0;
      this.sb.AppendFormat("StackName = {0}/Count = {1}", enumerator.Key, (object) ((Stack<GameObject>) enumerator.Value).Count);
      Debug.Log((object) this.sb.ToString());
    }
    this.sb.Length = 0;
    this.sb.AppendFormat("TotalEffect = {0} / LoadCount = {1} / OnecEffectCount = {2}", (object) this.totalEffect, (object) this.LoadABCount, (object) this.OnecEffectCount);
    Debug.Log((object) this.sb.ToString());
  }

  public GameObject Spawn(
    ushort EffID,
    Transform parent,
    Vector3 position,
    float scale,
    bool active,
    bool bAttach = true,
    bool bCheckOnecEffect = true)
  {
    if (EffID == (ushort) 0)
      return (GameObject) null;
    GameObject go;
    if (this.stackDic.ContainsKey(EffID))
    {
      go = this.Pop(EffID);
      this.SetParticle(go, parent, position, scale, active, bAttach);
    }
    else
    {
      go = this.CreateParticle(EffID);
      if ((bool) (Object) go)
      {
        this.SetParticle(go, parent, position, scale, active, bAttach);
        Stack<GameObject> gameObjectStack = new Stack<GameObject>();
        this.stackDic.Add(EffID, gameObjectStack);
      }
    }
    if (bCheckOnecEffect && this.IsOnceEffect(go))
      this.onecEffect.Add(go);
    if ((bool) (Object) go)
      go.transform.localScale = new Vector3(scale, scale, scale);
    return go;
  }

  public bool DeSpawn(GameObject go)
  {
    if ((Object) go == (Object) null)
      return false;
    ushort idByName = this.GetIDByName(go.name);
    float x = go.transform.localScale.x;
    if (!this.stackDic.ContainsKey(idByName))
      return false;
    this.SetParticle(go, (Transform) null, new Vector3(), x, false, false, false);
    if ((Object) this.AllEffectObject != (Object) null)
      go.transform.SetParent(this.AllEffectObject.transform);
    else
      Debug.Log((object) "AllEffectObject NULL");
    this.stackDic[idByName].Push(go);
    return true;
  }

  public void Play(GameObject go, Transform parent, Vector3 position)
  {
    go.SetActive(true);
    go.transform.parent = parent;
    go.transform.localPosition = position;
    ParticleSystem component = go.transform.GetComponent<ParticleSystem>();
    if (!(bool) (Object) component)
      return;
    component.Play();
  }

  public void Stop(GameObject go)
  {
    go.SetActive(false);
    ParticleSystem component = go.transform.GetComponent<ParticleSystem>();
    if (!(bool) (Object) component)
      return;
    component.Stop();
  }

  public void Pause(GameObject go, bool pause)
  {
    if ((Object) go == (Object) null)
      return;
    int childCount = go.transform.childCount;
    ParticleSystem component = go.transform.GetComponent<ParticleSystem>();
    if ((bool) (Object) component)
    {
      if (pause)
        component.Pause();
      else if (component.isPaused)
        component.Play();
    }
    for (int index = 0; index < childCount; ++index)
      this.Pause(go.transform.GetChild(index).gameObject, pause);
  }

  public void Clear()
  {
    Object.Destroy((Object) this.AllEffectObject);
    this.AllEffectObject = (GameObject) null;
    this.onecEffect.Clear();
    this.stackDic.Clear();
    this.resourcesDic.Clear();
    this.abDic.Clear();
    this.bundleKeyList.Clear();
    this.UnLoadAB();
  }

  public void Update()
  {
    for (int i = this.onecEffect.Count - 1; i >= 0; --i)
      this.CheckOnecEffect(i);
  }

  public void ClearOnecEffect()
  {
    for (int index = this.onecEffect.Count - 1; index >= 0; --index)
    {
      this.DeSpawn(this.onecEffect[index]);
      this.onecEffect.RemoveAt(index);
    }
    this.OnecEffectCount = this.onecEffect.Count;
    Debug.Log((object) nameof (ClearOnecEffect));
  }

  public GameObject GetAllEffecet() => this.AllEffectObject;

  private void CheckOnecEffect(int i)
  {
    bool flag1 = false;
    ParticleSystem component1 = this.onecEffect[i].GetComponent<ParticleSystem>();
    if ((bool) (Object) component1)
      flag1 = component1.IsAlive();
    int childCount = this.onecEffect[i].transform.childCount;
    for (int index = 0; index < childCount; ++index)
    {
      Transform child = this.onecEffect[i].transform.GetChild(index);
      if ((bool) (Object) child)
      {
        ParticleSystem component2 = child.GetComponent<ParticleSystem>();
        bool flag2 = component2.IsAlive();
        if ((bool) (Object) component2 && flag2)
          flag1 = flag2;
      }
    }
    if (flag1)
      return;
    this.DeSpawn(this.onecEffect[i]);
    this.onecEffect.RemoveAt(i);
    this.OnecEffectCount = this.onecEffect.Count;
  }

  private void CheckNeedAddToList(GameObject go)
  {
    if ((Object) go == (Object) null)
      return;
    ParticleSystem component1 = go.transform.GetComponent<ParticleSystem>();
    if ((bool) (Object) component1)
    {
      if (component1.loop)
        return;
      this.onecEffect.Add(go);
    }
    else
    {
      ParticleSystem component2 = go.transform.GetChild(0).GetComponent<ParticleSystem>();
      if (!(bool) (Object) component2 || component2.loop)
        return;
      this.onecEffect.Add(go);
    }
  }

  public bool IsOnceEffect(GameObject go)
  {
    if ((Object) go == (Object) null)
      return false;
    bool flag = false;
    ParticleSystem component1 = go.transform.GetComponent<ParticleSystem>();
    if ((bool) (Object) component1)
    {
      if (!component1.loop)
        flag = true;
    }
    else
    {
      ParticleSystem component2 = go.transform.GetChild(0).GetComponent<ParticleSystem>();
      if ((bool) (Object) component2 && !component2.loop)
        flag = true;
    }
    return flag;
  }

  private void UnLoadAB()
  {
    for (int index = 0; index < this.bundleKeyList.Count; ++index)
      AssetManager.UnloadAssetBundle(this.bundleKeyList[index]);
    ParticleManager.bIsLoad = false;
  }

  private string GetNameByID(ushort EffID)
  {
    this.sb.Length = 0;
    this.sb.AppendFormat("Effect_{0:00000}", (object) EffID);
    return this.sb.ToString();
  }

  private ushort GetIDByName(string Name)
  {
    ushort result = 0;
    ushort.TryParse(Name.Substring(7), out result);
    return result;
  }

  private string GetAbNamebyID(ushort EffID)
  {
    this.sb.Length = 0;
    ushort abNumByEffId = this.GetAbNumByEffID(EffID);
    if (EffID >= (ushort) 10000)
      this.sb.AppendFormat("Particle/Monster_Effects_{0:000}", (object) abNumByEffId);
    else
      this.sb.AppendFormat("Particle/Effects_{0:000}", (object) abNumByEffId);
    return this.sb.ToString();
  }

  private ushort GetAbNumByEffID(ushort EffID)
  {
    return EffID >= (ushort) 10000 ? (ushort) ((uint) EffID / 100U) : ((int) EffID % 400 != 0 ? (ushort) ((int) EffID / 400 + 1) : (ushort) ((uint) EffID / 400U));
  }

  private AssetBundle GetAssetBundleByEffID(ushort EffID)
  {
    if (EffID == (ushort) 0)
      return (AssetBundle) null;
    ushort abNumByEffId = this.GetAbNumByEffID(EffID);
    AssetBundle assetBundle;
    if (this.abDic.ContainsKey(abNumByEffId))
    {
      assetBundle = this.abDic[abNumByEffId];
    }
    else
    {
      int Key;
      assetBundle = AssetManager.GetAssetBundle(this.GetAbNamebyID(EffID), out Key);
      if ((bool) (Object) assetBundle)
      {
        this.abDic.Add(abNumByEffId, assetBundle);
        this.bundleKeyList.Add(Key);
      }
    }
    return assetBundle;
  }

  private GameObject Pop(ushort EffID)
  {
    Stack<GameObject> gameObjectStack = this.stackDic[EffID];
    return gameObjectStack.Count > 0 ? gameObjectStack.Pop() : this.CreateParticle(EffID);
  }

  private void Push(ushort EffID, GameObject go)
  {
    this.effName = this.GetNameByID(EffID);
    this.stackDic[EffID].Push(go);
  }

  private GameObject CreateParticle(ushort EffID)
  {
    Object original = this.LoadEffect(EffID);
    if (original == (Object) null)
      return (GameObject) null;
    GameObject go = Object.Instantiate(original) as GameObject;
    float x = go.transform.localScale.x;
    this.SetParticleScale(go, x, false);
    go.transform.localScale = new Vector3(1f, 1f, 1f);
    go.name = this.GetNameByID(EffID);
    go.transform.SetParent(this.AllEffectObject.transform);
    ++this.totalEffect;
    return go;
  }

  private Object LoadEffect(ushort EffID)
  {
    AssetBundle assetBundleByEffId = this.GetAssetBundleByEffID(EffID);
    if ((Object) assetBundleByEffId == (Object) null)
      return (Object) null;
    this.effName = this.GetNameByID(EffID);
    if ((Object) assetBundleByEffId == (Object) null)
      return (Object) null;
    Object @object;
    if (this.resourcesDic.ContainsKey(EffID))
    {
      @object = this.resourcesDic[EffID];
    }
    else
    {
      @object = assetBundleByEffId.Load(this.effName);
      this.resourcesDic.Add(EffID, @object);
      ++this.LoadABCount;
    }
    return @object;
  }

  private void SetParticle(
    GameObject go,
    Transform parent,
    Vector3 position,
    float scale,
    bool active,
    bool bAttach = true,
    bool bMultiply = true)
  {
    if (!(bool) (Object) go)
      return;
    if (!bAttach)
    {
      if ((bool) (Object) parent)
        go.transform.rotation = parent.rotation;
      go.transform.position = position;
    }
    else
    {
      go.transform.parent = parent;
      go.transform.localPosition = position;
    }
    this.SetParticleScale(go, scale, bMultiply);
    go.transform.localScale = !bMultiply ? new Vector3(1f, 1f, 1f) : new Vector3(scale, scale, scale);
    go.SetActive(active);
  }

  private void SetParticleScale(GameObject go, float scale, bool bMultiply = true)
  {
    if (!(bool) (Object) go)
      return;
    int childCount = go.transform.childCount;
    ParticleSystem component = go.GetComponent<ParticleSystem>();
    if ((bool) (Object) component)
    {
      if (bMultiply)
      {
        component.startSize *= scale;
        component.startSpeed *= scale;
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[component.particleCount];
        component.GetParticles(particles);
        for (int index = 0; index < particles.Length; ++index)
          particles[index].velocity *= scale;
        component.SetParticles(particles, particles.Length);
      }
      else
      {
        component.startSize /= scale;
        component.startSpeed /= scale;
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[component.particleCount];
        component.GetParticles(particles);
        for (int index = 0; index < particles.Length; ++index)
          particles[index].velocity /= scale;
        component.SetParticles(particles, particles.Length);
      }
    }
    for (int index = 0; index < childCount; ++index)
      this.SetParticleScale(go.transform.GetChild(index).gameObject, scale, bMultiply);
  }
}
