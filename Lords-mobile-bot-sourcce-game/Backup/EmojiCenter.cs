// Decompiled with JetBrains decompiler
// Type: EmojiCenter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class EmojiCenter
{
  public AssetBundle EmojiAB;
  public float basesize;
  public float basebacksize;
  public float basebackoffset;
  private int EmojiABKey;
  private int EmojiUnitPoolCount;
  private Transform EmojiCenterLayout;
  private Transform EmojiSpriteLayout;
  private Transform ImagePoolLayout;
  private Transform SpriteRendererPoolLayout;
  private Material EmojiImageMaterial;
  private Material EmojiSpriteRendererMaterial;
  private List<EmojiUnit> EmojiUnitPool;
  private Dictionary<ushort, EmojiCenter.EmojiSprite> IconIdMapEmojiSprites;

  public EmojiCenter()
  {
    this.EmojiUnitPoolCount = 0;
    this.EmojiUnitPool = new List<EmojiUnit>(128);
    this.IconIdMapEmojiSprites = new Dictionary<ushort, EmojiCenter.EmojiSprite>();
  }

  public void EmojiCenterIni()
  {
    if ((Object) this.EmojiAB == (Object) null)
    {
      this.EmojiCenterLayout = new GameObject(nameof (EmojiCenter)).transform;
      this.EmojiSpriteLayout = new GameObject("EmojiSprites").transform;
      this.EmojiSpriteLayout.SetParent(this.EmojiCenterLayout, false);
      this.ImagePoolLayout = new GameObject("ImagePool").transform;
      this.ImagePoolLayout.SetParent(this.EmojiCenterLayout, false);
      this.SpriteRendererPoolLayout = new GameObject("SpriteRendererPool").transform;
      this.SpriteRendererPoolLayout.SetParent(this.EmojiCenterLayout, false);
      CString Name = StringManager.Instance.SpawnString();
      Name.ClearString();
      Name.Append("UI/Map_NPC_Blood");
      this.EmojiAB = AssetManager.GetAssetBundle(Name, out this.EmojiABKey);
      for (ushort Iconid = 0; Iconid < (ushort) 8; ++Iconid)
        this.AddEmojiSprite(Iconid);
      this.AddEmojiSprite(ushort.MaxValue);
      Image component = this.EmojiSpriteLayout.GetChild(0).GetComponent<Image>();
      this.basesize = (float) DataManager.MapDataController.EmojiDataTable.GetRecordByKey((ushort) 1).sizeX;
      if ((double) this.basesize == 0.0)
        this.basesize = 60f;
      this.EmojiImageMaterial = ((MaskableGraphic) component).material;
      this.EmojiSpriteRendererMaterial = new Material(this.EmojiImageMaterial);
      this.EmojiSpriteRendererMaterial.renderQueue = 2665;
      RectTransform child = this.EmojiSpriteLayout.GetChild(this.EmojiSpriteLayout.childCount - 1) as RectTransform;
      this.basebacksize = child.sizeDelta.x;
      if ((double) this.basebacksize < (double) child.sizeDelta.y)
        this.basebacksize = child.sizeDelta.y;
      if ((double) this.basebacksize == 0.0)
        this.basebacksize = 73f;
      this.basebackoffset = this.basebacksize - this.basesize * 0.9f;
    }
    if ((Object) this.ImagePoolLayout == (Object) null)
    {
      this.ImagePoolLayout = new GameObject("ImagePool").transform;
      this.ImagePoolLayout.SetParent(this.EmojiCenterLayout, false);
    }
    if (!((Object) this.SpriteRendererPoolLayout == (Object) null))
      return;
    this.SpriteRendererPoolLayout = new GameObject("SpriteRendererPool").transform;
    this.SpriteRendererPoolLayout.SetParent(this.EmojiCenterLayout, false);
  }

  public void OnDestroy()
  {
  }

  public EmojiUnit pullIcon(ushort iconid, byte defaultSpriteID = 0, bool isSpriteRenderer = false)
  {
    this.EmojiCenterIni();
    if (!this.IconIdMapEmojiSprites.ContainsKey(iconid) && !this.AddEmojiSprite(iconid))
      iconid = (ushort) 0;
    EmojiCenter.EmojiSprite idMapEmojiSprite = this.IconIdMapEmojiSprites[iconid];
    EmojiUnit emojiUnit;
    if (this.EmojiUnitPoolCount == 0)
    {
      emojiUnit = new EmojiUnit();
      emojiUnit.poolID = this.EmojiUnitPool.Count;
      this.EmojiUnitPool.Add(emojiUnit);
    }
    else
    {
      emojiUnit = this.EmojiUnitPool[--this.EmojiUnitPoolCount];
      emojiUnit.poolID = this.EmojiUnitPoolCount;
    }
    emojiUnit.EmojiUnitIni(defaultSpriteID);
    emojiUnit.IconID = iconid;
    emojiUnit.SpriteMove = this.EmojiSpriteLayout.GetChild(idMapEmojiSprite.LayoutID).GetComponent<UISpritesArray>().m_Sprites;
    GameObject gameObject;
    if (isSpriteRenderer)
    {
      if (this.SpriteRendererPoolLayout.childCount == 0)
      {
        gameObject = new GameObject("eicon_sr");
        gameObject.AddComponent<SpriteRenderer>().material = this.EmojiSpriteRendererMaterial;
      }
      else
      {
        gameObject = this.SpriteRendererPoolLayout.GetChild(this.SpriteRendererPoolLayout.childCount - 1).gameObject;
        gameObject.transform.SetParent((Transform) null, false);
      }
      emojiUnit.EmojiImage = (Image) null;
      emojiUnit.EmojiSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
      if (emojiUnit.SpriteMove.Length <= 1)
        emojiUnit.EmojiSpriteRenderer.sprite = emojiUnit.SpriteMove[0];
    }
    else
    {
      if (this.ImagePoolLayout.childCount == 0)
      {
        gameObject = new GameObject("eicon_ig");
        ((MaskableGraphic) gameObject.AddComponent<Image>()).material = this.EmojiImageMaterial;
      }
      else
      {
        gameObject = this.ImagePoolLayout.GetChild(this.ImagePoolLayout.childCount - 1).gameObject;
        gameObject.transform.SetParent((Transform) null, false);
      }
      emojiUnit.EmojiSpriteRenderer = (SpriteRenderer) null;
      emojiUnit.EmojiImage = gameObject.GetComponent<Image>();
      emojiUnit.setImagePivot();
    }
    emojiUnit.EmojiTransform = gameObject.transform;
    gameObject.SetActive(true);
    return emojiUnit;
  }

  public void pushIcon(EmojiUnit inIcon)
  {
    inIcon.EmojiTransform.gameObject.SetActive(false);
    if ((Object) inIcon.EmojiSpriteRenderer == (Object) null)
    {
      inIcon.EmojiImage.type = (Image.Type) 0;
      ((MaskableGraphic) inIcon.EmojiImage).material = this.EmojiImageMaterial;
      inIcon.EmojiTransform.localPosition = Vector3.zero;
      inIcon.EmojiTransform.localScale = Vector3.one;
      inIcon.EmojiTransform.SetParent(this.ImagePoolLayout, false);
      inIcon.EmojiImage.SetNativeSize();
      inIcon.EmojiImage = (Image) null;
    }
    else
    {
      inIcon.EmojiSpriteRenderer.material = this.EmojiSpriteRendererMaterial;
      inIcon.EmojiTransform.localPosition = Vector3.zero;
      inIcon.EmojiTransform.localScale = Vector3.one;
      inIcon.EmojiTransform.SetParent(this.SpriteRendererPoolLayout, false);
      inIcon.EmojiSpriteRenderer = (SpriteRenderer) null;
    }
    inIcon.EmojiTransform = (Transform) null;
    inIcon.SpriteMove = (Sprite[]) null;
    if (inIcon.poolID != this.EmojiUnitPoolCount)
    {
      EmojiUnit emojiUnit = this.EmojiUnitPool[this.EmojiUnitPoolCount];
      this.EmojiUnitPool[this.EmojiUnitPoolCount] = inIcon;
      this.EmojiUnitPool[inIcon.poolID] = emojiUnit;
      emojiUnit.poolID = inIcon.poolID;
      inIcon.poolID = this.EmojiUnitPoolCount;
    }
    ++this.EmojiUnitPoolCount;
  }

  public void Clear()
  {
    if ((Object) this.SpriteRendererPoolLayout != (Object) null)
    {
      Object.Destroy((Object) this.SpriteRendererPoolLayout.gameObject);
      this.SpriteRendererPoolLayout = (Transform) null;
    }
    if ((Object) this.ImagePoolLayout != (Object) null)
    {
      Object.Destroy((Object) this.ImagePoolLayout.gameObject);
      this.ImagePoolLayout = (Transform) null;
    }
    if (this.EmojiUnitPool == null || this.EmojiUnitPoolCount == 0)
      return;
    this.EmojiUnitPool.RemoveRange(0, this.EmojiUnitPoolCount);
    this.EmojiUnitPoolCount = 0;
    for (int index = 0; index < this.EmojiUnitPool.Count; ++index)
      this.EmojiUnitPool[index].poolID = index;
  }

  public void Run()
  {
    for (int index = this.EmojiUnitPool.Count - 1; index >= this.EmojiUnitPoolCount; --index)
      this.EmojiUnitPool[index].Run();
  }

  private bool AddEmojiSprite(ushort Iconid)
  {
    EmojiCenter.EmojiSprite emojiSprite = new EmojiCenter.EmojiSprite();
    emojiSprite.LayoutID = this.EmojiSpriteLayout.childCount;
    CString cstring = StringManager.Instance.SpawnString();
    cstring.ClearString();
    cstring.IntToFormat((long) Iconid, 5);
    cstring.AppendFormat("UI/Emoji_icon_{0}");
    AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out emojiSprite.IconABKey);
    StringManager.Instance.DeSpawnString(cstring);
    if ((Object) assetBundle == (Object) null)
      return false;
    GameObject gameObject = Object.Instantiate(assetBundle.mainAsset) as GameObject;
    gameObject.SetActive(false);
    gameObject.transform.SetParent(this.EmojiSpriteLayout, false);
    this.IconIdMapEmojiSprites.Add(Iconid, emojiSprite);
    return true;
  }

  private struct EmojiSprite
  {
    public int LayoutID;
    public int IconABKey;
  }
}
