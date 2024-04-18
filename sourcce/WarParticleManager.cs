// Decompiled with JetBrains decompiler
// Type: WarParticleManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

#nullable disable
public class WarParticleManager
{
  private StringBuilder sb = new StringBuilder();
  private string effName;
  private Dictionary<ushort, Stack<SEffData>> stackDic = new Dictionary<ushort, Stack<SEffData>>();
  private Dictionary<ushort, Object> resourcesDic = new Dictionary<ushort, Object>(128);
  private List<SEffData> onecEffect = new List<SEffData>(128);
  private AssetBundle ab;
  private int assetBundleKey;
  private int totalEffect;
  private int LoadABCount;
  private int OnecEffectCount;
  private GameObject AllEffectObject;
  public static bool bIsLoad;

  public void Setup()
  {
    this.AllEffectObject = new GameObject();
    this.AllEffectObject.name = "AllEffect";
    this.ab = AssetManager.GetAssetBundle("Particle/WarEffects", out this.assetBundleKey);
    WarParticleManager.bIsLoad = true;
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
    bool bAttach = true)
  {
    SEffData data;
    if (this.stackDic.ContainsKey(EffID))
    {
      data = this.Pop(EffID);
      this.SetParticle(data.gameObject, parent, position, scale, active, bAttach);
    }
    else
    {
      GameObject particle = this.CreateParticle(EffID);
      if ((Object) particle == (Object) null)
        return (GameObject) null;
      this.SetParticle(particle, parent, position, scale, active, bAttach);
      Stack<SEffData> seffDataStack = new Stack<SEffData>();
      this.stackDic.Add(EffID, seffDataStack);
      data = new SEffData();
      data.gameObject = particle;
      data.particleSystem = particle.GetComponentInChildren<ParticleSystem>();
    }
    if (this.IsOnceEffect(data))
      this.onecEffect.Add(data);
    if ((bool) (Object) data.gameObject)
      data.gameObject.transform.localScale = new Vector3(scale, scale, scale);
    return data.gameObject;
  }

  public GameObject SpawnWithoutManager(ushort EffID)
  {
    return this.LoadEffect(this.ab, EffID) as GameObject;
  }

  public bool DeSpawn(SEffData eData)
  {
    if ((Object) eData.gameObject == (Object) null)
      return false;
    ushort idByName = this.GetIDByName(eData.gameObject.name);
    float x = eData.gameObject.transform.localScale.x;
    if (!this.stackDic.ContainsKey(idByName))
      return false;
    this.SetParticle(eData.gameObject, (Transform) null, new Vector3(), x, false, false, false);
    eData.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    if ((Object) this.AllEffectObject != (Object) null)
      eData.gameObject.transform.SetParent(this.AllEffectObject.transform);
    else
      Debug.Log((object) "AllEffectObject NULL");
    this.stackDic[idByName].Push(eData);
    return true;
  }

  public bool DeSpawn(GameObject go)
  {
    if ((Object) go == (Object) null)
      return false;
    SEffData seffData = new SEffData();
    seffData.gameObject = go;
    seffData.particleSystem = go.GetComponentInChildren<ParticleSystem>();
    ushort idByName = this.GetIDByName(seffData.gameObject.name);
    float x = seffData.gameObject.transform.localScale.x;
    if (!this.stackDic.ContainsKey(idByName))
      return false;
    this.SetParticle(seffData.gameObject, (Transform) null, new Vector3(), x, false, false, false);
    seffData.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    if ((Object) this.AllEffectObject != (Object) null)
      seffData.gameObject.transform.SetParent(this.AllEffectObject.transform);
    else
      Debug.Log((object) "AllEffectObject NULL");
    this.stackDic[idByName].Push(seffData);
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
      else
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
      this.DeSpawn(this.onecEffect[index]);
    this.onecEffect.Clear();
    this.OnecEffectCount = this.onecEffect.Count;
    Debug.Log((object) nameof (ClearOnecEffect));
  }

  public GameObject GetAllEffecet() => this.AllEffectObject;

  private void CheckOnecEffect(int i)
  {
    if (this.onecEffect[i].particleSystem.IsAlive())
      return;
    this.DeSpawn(this.onecEffect[i]);
    this.onecEffect.RemoveAt(i);
    this.OnecEffectCount = this.onecEffect.Count;
  }

  private bool IsOnceEffect(GameObject go)
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

  private bool IsOnceEffect(SEffData data)
  {
    return !((Object) data.gameObject == (Object) null) && !data.particleSystem.loop;
  }

  private void UnLoadAB()
  {
    if (!(bool) (Object) this.ab)
      return;
    AssetManager.UnloadAssetBundle(this.assetBundleKey);
    WarParticleManager.bIsLoad = false;
  }

  private string GetNameByID(ushort EffID)
  {
    this.sb.Length = 0;
    this.sb.AppendFormat("{0:0000}", (object) EffID);
    return this.sb.ToString();
  }

  private ushort GetIDByName(string Name)
  {
    ushort result = 0;
    ushort.TryParse(Name, out result);
    return result;
  }

  private SEffData Pop(ushort EffID)
  {
    Stack<SEffData> seffDataStack = this.stackDic[EffID];
    if (seffDataStack.Count > 0)
      return seffDataStack.Pop();
    SEffData seffData = new SEffData()
    {
      gameObject = this.CreateParticle(EffID)
    };
    seffData.particleSystem = seffData.gameObject.GetComponentInChildren<ParticleSystem>();
    return seffData;
  }

  private GameObject CreateParticle(ushort EffID)
  {
    Object original = this.LoadEffect(this.ab, EffID);
    if (original == (Object) null)
      return (GameObject) null;
    GameObject particle = Object.Instantiate(original) as GameObject;
    particle.name = EffID.ToString();
    particle.transform.SetParent(this.AllEffectObject.transform);
    ++this.totalEffect;
    return particle;
  }

  private Object LoadEffect(AssetBundle ab, ushort EffID)
  {
    if ((Object) ab == (Object) null)
      return (Object) null;
    Object @object;
    if (this.resourcesDic.ContainsKey(EffID))
    {
      @object = this.resourcesDic[EffID];
    }
    else
    {
      this.effName = this.GetNameByID(EffID);
      @object = ab.Load(this.effName);
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
    go.SetActive(active);
  }

  private void SetParticleScale(GameObject go, float scale, bool bMultiply = true)
  {
    int childCount = go.transform.childCount;
    float num = Mathf.Abs(scale);
    ParticleSystem component = go.GetComponent<ParticleSystem>();
    if ((bool) (Object) component)
    {
      if (bMultiply)
      {
        component.startSize *= num;
        component.startSpeed *= num;
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[component.particleCount];
        component.GetParticles(particles);
        for (int index = 0; index < particles.Length; ++index)
          particles[index].velocity *= num;
        component.SetParticles(particles, particles.Length);
      }
      else
      {
        component.startSize /= num;
        component.startSpeed /= num;
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[component.particleCount];
        component.GetParticles(particles);
        for (int index = 0; index < particles.Length; ++index)
          particles[index].velocity /= num;
        component.SetParticles(particles, particles.Length);
      }
    }
    for (int index = 0; index < childCount; ++index)
      this.SetParticleScale(go.transform.GetChild(index).gameObject, scale, bMultiply);
  }
}
