// Decompiled with JetBrains decompiler
// Type: MapSpriteManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class MapSpriteManager
{
  private ushort GameObjectCount;
  private GameObject[] GameObjectPool;
  private ushort PoolIndex;
  private ushort TextObjCount;
  private GameObject[] TextObjPool;
  private ushort TextIndex;
  private WorldMode worldmode;
  private MeshRenderer[] TextmeshArray;
  private Material _ChallegeMaterial;
  private Sprite[] ChallegeFrame = new Sprite[4];
  private int ChallegeAssKey;

  public MapSpriteManager(WorldMode worldmode, ushort Count)
  {
    if (Count == (ushort) 0)
      return;
    this.worldmode = worldmode;
    this.GameObjectCount = Count;
    this.GameObjectPool = new GameObject[(int) this.GameObjectCount];
    this.Initial();
  }

  public Material SpriteMaterial => GUIManager.Instance.MapSpriteMaterial;

  public Material SpriteUIMaterial => GUIManager.Instance.MapSpriteUIMaterial;

  private void Initial()
  {
    if (this.worldmode == WorldMode.Wild)
      this.InitialWide();
    else
      this.InitialDoor();
  }

  private void InitialWide()
  {
    GameObject original = new GameObject("MapSprite");
    SpriteRenderer spriteRenderer = original.AddComponent<SpriteRenderer>();
    spriteRenderer.color = Color.black;
    spriteRenderer.material = this.SpriteMaterial;
    this.GameObjectPool[0] = original;
    this.GameObjectPool[0].SetActive(false);
    for (int index = 1; index < (int) this.GameObjectCount; ++index)
    {
      this.GameObjectPool[index] = UnityEngine.Object.Instantiate((UnityEngine.Object) original) as GameObject;
      this.GameObjectPool[index].SetActive(false);
    }
  }

  private void InitialDoor()
  {
    GUIManager instance = GUIManager.Instance;
    GameObject original = new GameObject("MapSprite");
    SpriteRenderer spriteRenderer = original.AddComponent<SpriteRenderer>();
    spriteRenderer.color = Color.black;
    spriteRenderer.material = instance.m_IconSpriteAsset.GetMaterial();
    this.GameObjectPool[0] = original;
    this.GameObjectPool[0].SetActive(false);
    for (byte index = 1; (int) index < (int) this.GameObjectCount; ++index)
    {
      this.GameObjectPool[(int) index] = UnityEngine.Object.Instantiate((UnityEngine.Object) original) as GameObject;
      this.GameObjectPool[(int) index].SetActive(false);
    }
  }

  public void InitTextObj(ushort Count)
  {
    GUIManager instance = GUIManager.Instance;
    this.TextObjCount = Count;
    Font ttfFont = instance.GetTTFFont();
    this.TextmeshArray = new MeshRenderer[(int) Count * 5];
    this.TextObjPool = new GameObject[(int) this.TextObjCount];
    this.TextObjPool[0] = new GameObject("Stage");
    this.TextObjPool[0].AddComponent<SpriteRenderer>();
    GameObject gameObject1 = new GameObject("Text");
    TextMesh textMesh = gameObject1.AddComponent<TextMesh>();
    MeshRenderer component1 = gameObject1.GetComponent<MeshRenderer>();
    component1.castShadows = false;
    component1.receiveShadows = false;
    this.TextmeshArray[0] = component1;
    textMesh.font = ttfFont;
    textMesh.fontSize = 18;
    textMesh.richText = false;
    Material material = new Material(ttfFont.material);
    material.shader = Shader.Find("UI/Default Font");
    textMesh.renderer.material = material;
    component1.renderer.sortingOrder = -20;
    gameObject1.transform.SetParent(this.TextObjPool[0].transform);
    this.TextObjPool[0].SetActive(false);
    for (byte index = 0; index < (byte) 4; ++index)
    {
      GameObject gameObject2 = new GameObject("outline", new System.Type[1]
      {
        typeof (TextMesh)
      });
      TextMesh component2 = gameObject2.GetComponent<TextMesh>();
      this.TextmeshArray[1 + (int) index] = gameObject2.GetComponent<MeshRenderer>();
      component2.fontSize = 18;
      MeshRenderer component3 = gameObject2.GetComponent<MeshRenderer>();
      component3.renderer.sortingOrder = -30;
      component3.castShadows = false;
      component3.receiveShadows = false;
      component3.material = material;
      component2.font = ttfFont;
      component2.richText = false;
      gameObject2.transform.SetParent(gameObject1.transform);
      component2.color = Color.black;
    }
    for (byte index1 = 1; (int) index1 < (int) this.TextObjCount; ++index1)
    {
      this.TextObjPool[(int) index1] = UnityEngine.Object.Instantiate((UnityEngine.Object) this.TextObjPool[0]) as GameObject;
      this.TextObjPool[(int) index1].SetActive(false);
      this.TextmeshArray[5 * (int) index1] = this.TextObjPool[(int) index1].transform.GetChild(0).GetComponent<MeshRenderer>();
      for (byte index2 = 0; index2 < (byte) 4; ++index2)
        this.TextmeshArray[5 * (int) index1 + 1 + (int) index2] = this.TextObjPool[(int) index1].transform.GetChild(0).GetChild((int) index2).GetComponent<MeshRenderer>();
    }
  }

  public void TextRefresh()
  {
    if (this.TextmeshArray == null)
      return;
    for (int index = 0; index < this.TextmeshArray.Length; ++index)
    {
      if (!((UnityEngine.Object) this.TextmeshArray[index] == (UnityEngine.Object) null))
      {
        this.TextmeshArray[index].enabled = false;
        this.TextmeshArray[index].enabled = true;
      }
    }
  }

  private Vector3 GetOffset(int i)
  {
    switch (i % 4)
    {
      case 0:
        return new Vector3(0.0f, 1f, 0.0f);
      case 1:
        return new Vector3(1f, 0.0f, 0.0f);
      case 2:
        return new Vector3(-1f, 0.0f, 0.0f);
      case 3:
        return new Vector3(0.0f, -1f, 0.0f);
      default:
        return Vector3.zero;
    }
  }

  public void SetOutlinePosition(Transform TextTransform, string Text)
  {
    Vector3 screenPoint = Camera.main.WorldToScreenPoint(TextTransform.position);
    bool flag1 = false;
    int num1 = 1024;
    float num2 = 1f;
    bool flag2 = flag1 && (Screen.width > num1 || Screen.height > num1);
    for (int index = 0; index < TextTransform.childCount; ++index)
    {
      TextTransform.GetChild(index).GetComponent<TextMesh>().text = Text;
      Transform child = TextTransform.GetChild(index);
      Vector3 vector3 = this.GetOffset(index) * (!flag2 ? num2 : 2f * num2);
      Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint + vector3);
      child.transform.position = worldPoint;
    }
  }

  public GameObject GetSpriteObj()
  {
    GameObject spriteObj = this.GameObjectPool[(int) this.PoolIndex];
    spriteObj.SetActive(true);
    ++this.PoolIndex;
    if ((int) this.PoolIndex >= (int) this.GameObjectCount)
      this.PoolIndex = (ushort) 0;
    return spriteObj;
  }

  public void ReleaseSpriteObj(GameObject go)
  {
    if (!(bool) (UnityEngine.Object) go)
      return;
    go.SetActive(false);
  }

  public GameObject GetTextObj()
  {
    GameObject textObj = this.TextObjPool[(int) this.TextIndex];
    textObj.SetActive(true);
    ++this.TextIndex;
    if ((int) this.TextIndex >= (int) this.TextObjCount)
      this.TextIndex = (ushort) 0;
    return textObj;
  }

  public void ReleaseTextObj(GameObject go)
  {
    if (!(bool) (UnityEngine.Object) go)
      return;
    go.SetActive(false);
  }

  public Sprite GetSpriteByID(ushort ID) => GUIManager.Instance.m_IconSpriteAsset.LoadSprite(ID);

  public Sprite GetSpriteByName(string Name)
  {
    if (Name == null)
      return (Sprite) null;
    Sprite sprite;
    return GUIManager.Instance.MapIconDict.TryGetValue(Name.GetHashCode(), out sprite) ? sprite : (Sprite) null;
  }

  public void Destory()
  {
    for (int index = 0; index < (int) this.GameObjectCount; ++index)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.GameObjectPool[index]);
      this.GameObjectPool[index] = (GameObject) null;
    }
    for (byte index = 0; (int) index < (int) this.TextObjCount; ++index)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.TextObjPool[(int) index]);
      this.TextObjPool[(int) index] = (GameObject) null;
    }
    this.DestroyChallegeFrame();
  }

  public Material ChallegeMaterial => this._ChallegeMaterial;

  public void LoadChallegeFrame()
  {
    if (DataManager.StageDataController._stageMode != StageMode.Dare)
      return;
    CString Name = StringManager.Instance.StaticString1024();
    Name.StringToFormat("ChallegeFrame");
    Name.AppendFormat("UI/{0}");
    AssetBundle assetBundle = AssetManager.GetAssetBundle(Name, out this.ChallegeAssKey);
    assetBundle.LoadAll();
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return;
    UnityEngine.Object[] objectArray = assetBundle.LoadAll(typeof (Sprite));
    Name.ClearString();
    Name.StringToFormat("ChallegeFrame");
    Name.AppendFormat("{0}_m");
    this._ChallegeMaterial = assetBundle.Load(Name.ToString(), typeof (Material)) as Material;
    for (int index = 0; index < objectArray.Length; ++index)
    {
      Sprite sprite = objectArray[index] as Sprite;
      if (!((UnityEngine.Object) sprite == (UnityEngine.Object) null))
      {
        Name.ClearString();
        int startIndex = sprite.name.Length - 3;
        Debug.Log((object) sprite.name.Substring(startIndex));
        int result;
        if (int.TryParse(sprite.name.Substring(startIndex), out result) && result < this.ChallegeFrame.Length)
          this.ChallegeFrame[result] = sprite;
      }
    }
  }

  public Sprite GetChalleteSprite(byte difficult)
  {
    return this.ChallegeFrame[(int) difficult < this.ChallegeFrame.Length ? (int) difficult : 0];
  }

  private void DestroyChallegeFrame()
  {
    if (this.ChallegeAssKey != 0)
      AssetManager.UnloadAssetBundle(this.ChallegeAssKey);
    this.ChallegeAssKey = 0;
  }
}
