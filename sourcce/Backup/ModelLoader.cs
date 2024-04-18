// Decompiled with JetBrains decompiler
// Type: ModelLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;

#nullable disable
public class ModelLoader
{
  private const ushort MAX_MODEL_MAT = 200;
  private Dictionary<ushort, ModelLoader.ModelNode> m_MatList = new Dictionary<ushort, ModelLoader.ModelNode>(200);
  private Dictionary<int, uint> m_MatMap = new Dictionary<int, uint>(200);
  private StringBuilder sb = new StringBuilder(64);
  private Shader modelDefuse;
  private static ModelLoader m_Self;

  public ModelLoader()
  {
    AssetManager instance = AssetManager.Instance;
    int length = instance.Shaders.Length;
    for (int index = 0; index < length; ++index)
    {
      if (instance.Shaders[index].name == "zTWRD2 Shaders/Model/Diffuse")
      {
        this.modelDefuse = (Shader) instance.Shaders[index];
        break;
      }
    }
  }

  public static ModelLoader Instance
  {
    get
    {
      if (ModelLoader.m_Self == null)
        ModelLoader.m_Self = new ModelLoader();
      return ModelLoader.m_Self;
    }
  }

  public void Clear()
  {
    Debug.Log((object) ("Clean all: " + this.m_MatMap.Count.ToString()));
    this.m_MatMap.Clear();
    this.m_MatList.Clear();
  }

  public GameObject Load(ushort modelID, AssetBundle ab, ushort texID = 0)
  {
    if (modelID <= (ushort) 0 || (Object) ab == (Object) null || (Object) this.modelDefuse == (Object) null)
      return (GameObject) null;
    GameObject gameObject = Object.Instantiate(ab.Load("mwm")) as GameObject;
    if ((Object) gameObject == (Object) null)
      return (GameObject) null;
    SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
    if ((Object) componentInChildren == (Object) null)
      return (GameObject) null;
    ModelLoader.MatNode matNode = (ModelLoader.MatNode) null;
    ModelLoader.ModelNode modelNode = (ModelLoader.ModelNode) null;
    bool flag = this.m_MatList.TryGetValue(modelID, out modelNode);
    if (!flag || flag && modelNode.matNode[(int) texID] == null)
    {
      this.sb.Length = 0;
      this.sb.AppendFormat("m{0:00}", (object) texID);
      if (!ab.Contains(this.sb.ToString()))
      {
        this.sb.Length = 0;
        this.sb.Append("m00");
      }
      Texture2D texture2D = ab.Load(this.sb.ToString(), typeof (Texture2D)) as Texture2D;
      if ((Object) texture2D != (Object) null)
      {
        Material material = new Material(this.modelDefuse);
        material.mainTexture = (Texture) texture2D;
        uint num = (uint) modelID << 16 | (uint) texID;
        this.m_MatMap.Add(material.GetInstanceID(), num);
        matNode = new ModelLoader.MatNode();
        matNode.material = material;
        if (!flag)
        {
          modelNode = new ModelLoader.ModelNode();
          this.m_MatList.Add(modelID, modelNode);
        }
        modelNode.matNode[(int) texID] = matNode;
      }
    }
    else
      matNode = modelNode.matNode[(int) texID];
    if (matNode == null || matNode != null && (Object) matNode.material == (Object) null)
      return (GameObject) null;
    componentInChildren.material = matNode.material;
    ++matNode.refCount;
    ++modelNode.refCount;
    return gameObject;
  }

  public Material LoadMaterial(ushort modelID, AssetBundle ab, ushort texID = 0)
  {
    if (modelID <= (ushort) 0 || (Object) ab == (Object) null || (Object) this.modelDefuse == (Object) null)
      return (Material) null;
    ModelLoader.MatNode matNode = (ModelLoader.MatNode) null;
    ModelLoader.ModelNode modelNode = (ModelLoader.ModelNode) null;
    bool flag = this.m_MatList.TryGetValue(modelID, out modelNode);
    if (!flag || flag && modelNode.matNode[(int) texID] == null)
    {
      this.sb.Length = 0;
      this.sb.AppendFormat("m{0:00}", (object) texID);
      if (!ab.Contains(this.sb.ToString()))
      {
        this.sb.Length = 0;
        this.sb.Append("m00");
      }
      Texture2D texture2D = ab.Load(this.sb.ToString(), typeof (Texture2D)) as Texture2D;
      if ((Object) texture2D != (Object) null)
      {
        Material material = new Material(this.modelDefuse);
        material.mainTexture = (Texture) texture2D;
        uint num = (uint) modelID << 16 | (uint) texID;
        this.m_MatMap.Add(material.GetInstanceID(), num);
        matNode = new ModelLoader.MatNode();
        matNode.material = material;
        if (!flag)
        {
          modelNode = new ModelLoader.ModelNode();
          this.m_MatList.Add(modelID, modelNode);
        }
        modelNode.matNode[(int) texID] = matNode;
      }
    }
    else
      matNode = modelNode.matNode[(int) texID];
    if (matNode == null || matNode != null && (Object) matNode.material == (Object) null)
      return (Material) null;
    ++matNode.refCount;
    ++modelNode.refCount;
    Debug.Log((object) (modelID.ToString() + ": modelCt: " + modelNode.refCount.ToString() + " ,matCt: " + matNode.refCount.ToString()));
    return matNode.material;
  }

  public void UnloadMaterial(Material material)
  {
    int instanceId = material.GetInstanceID();
    if (!this.m_MatMap.ContainsKey(instanceId))
    {
      Debug.LogError((object) "Material memory leak appear");
    }
    else
    {
      uint mat1 = this.m_MatMap[instanceId];
      ushort key = (ushort) (mat1 >> 16);
      ushort index = (ushort) (mat1 & (uint) ushort.MaxValue);
      ModelLoader.ModelNode mat2 = this.m_MatList[key];
      if (mat2 == null)
        return;
      ModelLoader.MatNode matNode = mat2.matNode[(int) index];
      --matNode.refCount;
      if (matNode.refCount == (ushort) 0)
      {
        Object.DestroyImmediate((Object) mat2.matNode[(int) index].material, true);
        mat2.matNode[(int) index] = (ModelLoader.MatNode) null;
        this.m_MatMap.Remove(instanceId);
      }
      --mat2.refCount;
      if (mat2.refCount == (ushort) 0)
        this.m_MatList.Remove(key);
      Debug.Log((object) ("modelCt: " + mat2.refCount.ToString() + " ,matCt: " + matNode.refCount.ToString()));
    }
  }

  public void Unload(Object obj)
  {
    GameObject gameObject = obj as GameObject;
    if ((Object) gameObject == (Object) null)
      return;
    if (!gameObject.activeSelf)
      gameObject.SetActive(true);
    SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
    if ((Object) componentInChildren != (Object) null)
    {
      int instanceId = componentInChildren.sharedMaterial.GetInstanceID();
      if (!this.m_MatMap.ContainsKey(instanceId))
      {
        Debug.LogError((object) "Material memory leak appear");
        return;
      }
      uint mat1 = this.m_MatMap[instanceId];
      ushort key = (ushort) (mat1 >> 16);
      ushort index = (ushort) (mat1 & (uint) ushort.MaxValue);
      ModelLoader.ModelNode mat2 = this.m_MatList[key];
      if (mat2 != null)
      {
        ModelLoader.MatNode matNode = mat2.matNode[(int) index];
        --matNode.refCount;
        if (matNode.refCount == (ushort) 0)
        {
          Object.DestroyImmediate((Object) mat2.matNode[(int) index].material, true);
          mat2.matNode[(int) index] = (ModelLoader.MatNode) null;
          this.m_MatMap.Remove(instanceId);
        }
        --mat2.refCount;
        if (mat2.refCount == (ushort) 0)
          this.m_MatList.Remove(key);
      }
    }
    Object.Destroy((Object) gameObject);
  }

  public class MatNode
  {
    public Material material;
    public ushort refCount;
  }

  public class ModelNode
  {
    public ushort refCount;
    public ModelLoader.MatNode[] matNode = new ModelLoader.MatNode[10];
  }
}
