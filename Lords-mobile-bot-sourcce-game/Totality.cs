// Decompiled with JetBrains decompiler
// Type: Totality
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
public class Totality : 
  MonoBehaviour,
  IPointerUpHandler,
  IDragHandler,
  IPointerDownHandler,
  IEventSystemHandler
{
  public WorldMap worldMapController;
  public Transform Totality_3DTransform;
  public bool InPutLock;
  public WorldMapGraphic mapGraphicController;
  private RectTransform Canvasrectran;
  private int WorldMapBaseABKey;
  private int WorldMapGraphicABKey;
  private WorldMapYolk yolkController;
  private WorldMapName mapNameController;
  private WorldMapEffect mapEffectController;

  protected void Awake()
  {
    this.Totality_3DTransform = new GameObject("Totality3D").transform;
    this.Totality_3DTransform.localScale = Vector3.one * DataManager.MapDataController.worldZoomSize;
    this.InPutLock = false;
    GameObject gameObject = Object.Instantiate(AssetManager.GetAssetBundle("UI/WorldBase", out this.WorldMapBaseABKey).mainAsset) as GameObject;
    RectTransform component = gameObject.GetComponent<RectTransform>();
    this.Canvasrectran = GUIManager.Instance.pDVMgr.CanvasRT;
    component.sizeDelta = this.Canvasrectran.sizeDelta;
    if (GUIManager.Instance.m_UICanvas.renderMode == 1)
      DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale = ((Transform) this.Canvasrectran).localScale.x;
    this.worldMapController = gameObject.GetComponent<WorldMap>();
    if ((Object) this.worldMapController == (Object) null)
      this.worldMapController = gameObject.AddComponent<WorldMap>();
    ((Transform) component).SetParent(((Component) GUIManager.Instance.m_UICanvas).transform.GetChild(0), false);
    ((Transform) component).SetAsFirstSibling();
    this.yolkController = new WorldMapYolk(this.transform, this.worldMapController.TileSprites);
    this.mapNameController = new WorldMapName(this.transform, this.worldMapController.TileSprites);
    this.mapGraphicController = new WorldMapGraphic(this.transform, this.worldMapController.TileSprites);
    this.mapEffectController = new WorldMapEffect(this.Totality_3DTransform, this.worldMapController.TileBaseScale);
    this.worldMapController.setEffect(this.mapEffectController);
    this.worldMapController.setRealmGroup_3DTransform(this.Totality_3DTransform);
    this.worldMapController.setKingdomYolk(this.yolkController);
    this.worldMapController.setKingdomName(this.mapNameController);
    this.worldMapController.setKingdomGraphic(this.mapGraphicController);
  }

  protected void OnDestroy()
  {
    this.ClearEffect();
    if (this.mapNameController != null)
      this.mapNameController.OnDestroy();
    this.mapNameController = (WorldMapName) null;
    if (this.yolkController != null)
      this.yolkController.OnDestroy();
    this.yolkController = (WorldMapYolk) null;
    if ((Object) this.worldMapController != (Object) null)
      Object.DestroyObject((Object) this.worldMapController.gameObject);
    this.worldMapController = (WorldMap) null;
    this.Canvasrectran = (RectTransform) null;
    if ((Object) this.Totality_3DTransform != (Object) null)
      Object.DestroyObject((Object) this.Totality_3DTransform.gameObject);
    this.Totality_3DTransform = (Transform) null;
    AssetManager.UnloadAssetBundle(this.WorldMapBaseABKey);
    AssetManager.UnloadAssetBundle(this.WorldMapGraphicABKey);
  }

  protected void Update()
  {
    this.mapNameController.myPosImageRun();
    this.yolkController.updateYolkImage();
  }

  public void OnDrag(PointerEventData eventData)
  {
    if (this.InPutLock)
      return;
    this.worldMapController.OnDrag(eventData);
    this.worldMapController.Movedelta = Vector2.zero;
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    if (this.InPutLock)
      return;
    this.worldMapController.OnPointerDown(eventData);
  }

  public void OnPointerUp(PointerEventData eventData)
  {
    if (this.InPutLock)
      return;
    this.worldMapController.OnPointerUp(eventData);
  }

  public void UpdateNetwork()
  {
  }

  public void UpdateKingdom(byte kingdomtableid, byte updatekind)
  {
    this.worldMapController.UpdateKingdom(kingdomtableid, updatekind);
  }

  public void ClearEffect()
  {
  }

  public void MoveToKingdom(ushort KingdomID) => this.worldMapController.moveToKingdom(KingdomID);

  public void WorldMapNameFontTextureRebuilt()
  {
    if (this.mapNameController == null)
      return;
    this.mapNameController.WorldKingdomNameRebuilt();
  }
}
