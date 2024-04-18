// Decompiled with JetBrains decompiler
// Type: Front
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class Front : Gameplay
{
  private int controlMapLineTableID;
  private int checkMapLineTableID = 1;
  private int checkMapLineTableID_EX = 3;
  private int checkMapLineTableID_PLUS;
  private float frontWaitTime;
  private float frontFadeSpeed = 1.5f;
  private float frontZoomSpeed = 4f;
  private ushort oldKingdomID;
  private ushort oldKVKKingdomID;
  private KINGDOM_PERIOD oldKingdomPeriod;
  private ushort readySFXID = 41025;
  private ushort goSFXID = 40016;
  private ushort controlMapPlayerTableID;
  private Vector2 frontMove = Vector2.zero;
  private Vector2 viewStartPoint = new Vector2(218f, 108f);
  private Vector2 startPoint = new Vector2(204f, 88f);
  private Vector2 endPoint = new Vector2(206f, 86f);
  private Vector2 dis = Vector2.zero;
  private Realm directController;
  private Transform FrontGroupTransform;
  private RectTransform Canvasrectran;
  private Image cloth;
  private LineNode lineNode;
  private LineNode checklineNode;
  private LineNode checklineNode_EX;
  private LineNode checklineNode_PLUS;
  private UIText WordTextFirst;
  private UIText WordTextSec;
  private float wordFadInSpeed = 0.5f;
  private float wordFadOutSpeed = 1f;
  private byte nowFirstWordID;
  private byte nowSecWordID;
  private float FirstWordStayTimeMax = 2.725f;
  private float FirstWordStayTime = 2.725f;
  private float SecWordStayTimeMax = 1.9f;
  private float SecWordStayTime = 1.9f;
  private int frontFlag;
  private float delay = 1f;
  private Front.FrontFlag FstWordState = Front.FrontFlag.Delay;
  private Front.FrontFlag SecWordState = Front.FrontFlag.Zoom;
  private Front.FrontFlag ClothState = Front.FrontFlag.Out;
  private Front.FrontState frontState;
  private Vector2[] CityPos = new Vector2[23]
  {
    new Vector2(214f, 106f),
    new Vector2(211f, 99f),
    new Vector2(210f, 96f),
    new Vector2(210f, 102f),
    new Vector2(207f, 101f),
    new Vector2(218f, 100f),
    new Vector2(218f, 108f),
    new Vector2(215f, 101f),
    new Vector2(212f, 98f),
    new Vector2(210f, 100f),
    new Vector2(203f, 93f),
    new Vector2(209f, 95f),
    new Vector2(216f, 100f),
    new Vector2(214f, 104f),
    new Vector2(213f, 101f),
    new Vector2(211f, 103f),
    new Vector2(209f, 103f),
    new Vector2(215f, 99f),
    new Vector2(212f, 100f),
    new Vector2(209f, 97f),
    new Vector2(201f, 85f),
    new Vector2(216f, 102f),
    new Vector2(212f, 94f)
  };
  private byte[] CityLevel = new byte[23]
  {
    (byte) 10,
    (byte) 18,
    (byte) 1,
    (byte) 10,
    (byte) 18,
    (byte) 1,
    (byte) 10,
    (byte) 10,
    (byte) 1,
    (byte) 10,
    (byte) 1,
    (byte) 10,
    (byte) 10,
    (byte) 25,
    (byte) 18,
    (byte) 25,
    (byte) 10,
    (byte) 18,
    (byte) 25,
    (byte) 25,
    (byte) 1,
    (byte) 18,
    (byte) 18
  };
  private byte[] Cityflag = new byte[23]
  {
    (byte) 2,
    (byte) 2,
    (byte) 2,
    (byte) 2,
    (byte) 2,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 0,
    (byte) 4,
    (byte) 4
  };
  private Vector2[] OtherPos = new Vector2[4]
  {
    new Vector2(215f, 105f),
    new Vector2(211f, 107f),
    new Vector2(205f, 85f),
    new Vector2(207f, 89f)
  };
  private POINT_KIND[] OtherKind = new POINT_KIND[4]
  {
    POINT_KIND.PK_CAMP,
    POINT_KIND.PK_STONE,
    POINT_KIND.PK_WOOD,
    POINT_KIND.PK_GOLD
  };
  private Vector2[] LineStartPoint = new Vector2[9]
  {
    new Vector2(211f, 103f),
    new Vector2(209f, 95f),
    new Vector2(210f, 102f),
    new Vector2(218f, 108f),
    new Vector2(213f, 101f),
    new Vector2(209f, 103f),
    new Vector2(212f, 100f),
    new Vector2(209f, 97f),
    new Vector2(212f, 94f)
  };
  private Vector2[] LineEndPoint = new Vector2[9]
  {
    new Vector2(211f, 99f),
    new Vector2(210f, 96f),
    new Vector2(210f, 96f),
    new Vector2(213f, 101f),
    new Vector2(211f, 103f),
    new Vector2(211f, 107f),
    new Vector2(216f, 100f),
    new Vector2(207f, 101f),
    new Vector2(212f, 98f)
  };
  private uint[] LineDuring = new uint[9]
  {
    18U,
    43U,
    40U,
    10U,
    24U,
    18U,
    18U,
    18U,
    18U
  };
  private float[] LineDuringEx = new float[9]
  {
    14f,
    38f,
    0.0f,
    2f,
    7f,
    7f,
    7f,
    2f,
    3f
  };
  private EMarchEventType[] LineFlag = new EMarchEventType[9]
  {
    EMarchEventType.EMET_AttackMarching,
    EMarchEventType.EMET_AttackMarching,
    EMarchEventType.EMET_AttackRetreat,
    EMarchEventType.EMET_ScoutMarching,
    EMarchEventType.EMET_AttackMarching,
    EMarchEventType.EMET_GatherMarching,
    EMarchEventType.EMET_AttackMarching,
    EMarchEventType.EMET_LordReturn,
    EMarchEventType.EMET_HitMonsterMarching
  };
  private ushort[] KID = new ushort[9]
  {
    (ushort) 2,
    (ushort) 2,
    (ushort) 2,
    (ushort) 2,
    (ushort) 1,
    (ushort) 1,
    (ushort) 2,
    (ushort) 1,
    (ushort) 1
  };
  private uint[] FstWordID = new uint[3]
  {
    7971U,
    7973U,
    7975U
  };
  private uint[] SecWordID = new uint[3]
  {
    7972U,
    7974U,
    7976U
  };

  ~Front()
  {
  }

  private void iniMapData()
  {
    for (; (int) this.controlMapPlayerTableID < this.CityPos.Length; ++this.controlMapPlayerTableID)
    {
      int mapId = GameConstants.TileMapPosToMapID((int) this.CityPos[(int) this.controlMapPlayerTableID].x, (int) this.CityPos[(int) this.controlMapPlayerTableID].y);
      DataManager.MapDataController.LayoutMapInfo[mapId].pointKind = (byte) 8;
      DataManager.MapDataController.LayoutMapInfo[mapId].tableID = this.controlMapPlayerTableID;
      DataManager.MapDataController.PlayerPointTable[(int) this.controlMapPlayerTableID].level = this.CityLevel[(int) this.controlMapPlayerTableID];
      DataManager.MapDataController.PlayerPointTable[(int) this.controlMapPlayerTableID].capitalFlag = this.Cityflag[(int) this.controlMapPlayerTableID];
      this.directController.UpdatePoint((uint) mapId);
    }
    for (int index = 0; index < this.OtherPos.Length; ++index)
    {
      int mapId = GameConstants.TileMapPosToMapID((int) this.OtherPos[index].x, (int) this.OtherPos[index].y);
      DataManager.MapDataController.LayoutMapInfo[mapId].pointKind = (byte) this.OtherKind[index];
      this.directController.UpdatePoint((uint) mapId);
    }
    DataManager.Instance.RoleAlliance.Tag.IntToFormat(1L);
    DataManager.Instance.RoleAlliance.Tag.IntToFormat(1L);
    DataManager.Instance.RoleAlliance.Tag.IntToFormat(1L);
    DataManager.Instance.RoleAlliance.Tag.AppendFormat("{0}{1}{2}");
    for (; this.controlMapLineTableID < this.LineStartPoint.Length; ++this.controlMapLineTableID)
    {
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].lineID = 0U;
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].playerName.ClearString();
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].playerName.IntToFormat((long) this.controlMapLineTableID);
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].playerName.AppendFormat("{0}");
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].kingdomID = this.KID[this.controlMapLineTableID];
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].allianceTag.ClearString();
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].allianceTag.IntToFormat((long) this.controlMapLineTableID);
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].allianceTag.IntToFormat((long) this.controlMapLineTableID);
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].allianceTag.IntToFormat((long) this.controlMapLineTableID);
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].allianceTag.AppendFormat("{0}{1}{2}");
      GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int) this.LineStartPoint[this.controlMapLineTableID].x, (int) this.LineStartPoint[this.controlMapLineTableID].y), out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].start.zoneID, out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].start.pointID);
      GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int) this.LineEndPoint[this.controlMapLineTableID].x, (int) this.LineEndPoint[this.controlMapLineTableID].y), out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].end.zoneID, out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].end.pointID);
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].during = this.LineDuring[this.controlMapLineTableID];
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].begin = (ulong) (NetworkManager.ServerTime - (double) this.LineDuringEx[this.controlMapLineTableID]);
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].EXbegin = DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].EXduring = 0U;
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].lineFlag = (byte) this.LineFlag[this.controlMapLineTableID];
      if (this.LineFlag[this.controlMapLineTableID] == EMarchEventType.EMET_AttackRetreat)
        DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].EXduring += 5U;
      this.directController.AddLine(this.controlMapLineTableID, false);
    }
    this.directController.mapTileController.SetFocusGroup(this.checkMapLineTableID, ref this.checklineNode);
    this.directController.mapTileController.SetFocusGroup(this.checkMapLineTableID_EX, ref this.checklineNode_EX);
    this.directController.mapTileController.SetFocusGroup(this.checkMapLineTableID_PLUS, ref this.checklineNode_PLUS);
    int mapId1 = GameConstants.TileMapPosToMapID((int) this.startPoint.x, (int) this.startPoint.y);
    DataManager.MapDataController.LayoutMapInfo[mapId1].pointKind = (byte) 9;
    DataManager.MapDataController.LayoutMapInfo[mapId1].tableID = this.controlMapPlayerTableID++;
    int mapId2 = GameConstants.TileMapPosToMapID((int) this.endPoint.x, (int) this.endPoint.y);
    DataManager.MapDataController.LayoutMapInfo[mapId2].pointKind = (byte) 8;
    DataManager.MapDataController.LayoutMapInfo[mapId2].tableID = this.controlMapPlayerTableID;
    DataManager.MapDataController.PlayerPointTable[(int) this.controlMapPlayerTableID].level = (byte) 25;
    DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].lineID = 0U;
    DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].playerName.AppendFormat(DataManager.Instance.RoleAttr.Name);
    GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int) this.startPoint.x, (int) this.startPoint.y), out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].start.zoneID, out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].start.pointID);
    GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int) this.endPoint.x, (int) this.endPoint.y), out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].end.zoneID, out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].end.pointID);
    this.frontState = Front.FrontState.Around;
    this.frontFlag |= 1;
    this.frontMove = this.viewStartPoint - this.startPoint;
    this.frontMove.x *= 256f;
    this.frontMove.y *= (float) sbyte.MinValue;
    this.frontMove /= 28f;
    this.frontFlag |= 4;
  }

  protected override void UpdateNews(byte[] meg)
  {
    if (meg[0] == (byte) 2)
    {
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].during = 3U;
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].begin = (ulong) NetworkManager.ServerTime;
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].EXbegin = DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].EXduring = 0U;
      DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].lineFlag = (byte) 5;
      this.directController.AddLine(this.controlMapLineTableID);
      this.directController.mapTileController.SetFocusGroup(this.controlMapLineTableID, ref this.lineNode);
      this.directController.mapTileController.Movedelta = this.frontMove = Vector2.zero;
      this.frontFlag |= 16;
      AudioManager.Instance.PlaySFX(this.goSFXID);
      this.frontState = Front.FrontState.Go;
    }
    else
    {
      if (meg[0] != (byte) 0 || meg[1] != (byte) 35)
        return;
      if ((Object) this.WordTextFirst != (Object) null && ((Behaviour) this.WordTextFirst).enabled)
      {
        ((Behaviour) this.WordTextFirst).enabled = false;
        ((Behaviour) this.WordTextFirst).enabled = true;
      }
      if (!((Object) this.WordTextSec != (Object) null) || !((Behaviour) this.WordTextSec).enabled)
        return;
      ((Behaviour) this.WordTextSec).enabled = false;
      ((Behaviour) this.WordTextSec).enabled = true;
    }
  }

  protected override void UpdateNext(byte[] meg)
  {
    DataManager.MapDataController.zoomSize = 0.75f;
    DataManager.MapDataController.FocusKingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID = DataManager.MapDataController.kingdomData.kingdomID = this.oldKingdomID;
    DataManager.MapDataController.kingdomData.kingdomPeriod = this.oldKingdomPeriod;
    DataManager.MapDataController.KVKKingdomID = this.oldKVKKingdomID;
    DataManager.Instance.RoleAlliance.Tag.ClearString();
    if ((Object) this.WordTextFirst != (Object) null)
      Object.DestroyObject((Object) ((Component) this.WordTextFirst).gameObject);
    this.WordTextFirst = (UIText) null;
    if ((Object) this.WordTextSec != (Object) null)
      Object.DestroyObject((Object) ((Component) this.WordTextSec).gameObject);
    this.WordTextSec = (UIText) null;
    if ((Object) this.cloth != (Object) null)
      Object.DestroyObject((Object) ((Component) this.cloth).gameObject);
    this.cloth = (Image) null;
    if ((Object) this.directController != (Object) null)
    {
      this.directController.ClearEffect();
      Object.DestroyObject((Object) this.directController.gameObject);
    }
    this.directController = (Realm) null;
    this.FrontGroupTransform = (Transform) null;
    GUIManager.Instance.ClearMapSprite();
    GUIManager.Instance.DestroyTechIconSprite();
    GUIManager.Instance.EmojiManager.Clear();
    ParticleManager.Instance.Clear();
    GUIManager.Instance.m_UICanvas.renderMode = (RenderMode) 0;
    GUIManager.Instance.SetCameraorthOgraphic(false);
  }

  protected override void UpdateLoad(byte[] meg)
  {
    GameManager.RegisterObserver((byte) 1, (byte) 0, (IObserver) this);
    RenderSettings.ambientLight = (Color) GameConstants.DefaultAmbientLight;
    DataManager.Instance.GoToBattleOrWar = GameplayKind.Front;
    this.oldKingdomID = DataManager.MapDataController.kingdomData.kingdomID;
    this.oldKVKKingdomID = DataManager.MapDataController.KVKKingdomID;
    this.oldKingdomPeriod = DataManager.MapDataController.kingdomData.kingdomPeriod;
    DataManager.MapDataController.FocusKingdomID = DataManager.MapDataController.kingdomData.kingdomID = (ushort) 1;
    DataManager.MapDataController.OtherKingdomData.kingdomID = DataManager.MapDataController.KVKKingdomID = (ushort) 2;
    DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_KVK;
    DataManager.MapDataController.FocusMapID = GameConstants.TileMapPosToMapID((int) this.viewStartPoint.x, (int) this.viewStartPoint.y);
    ParticleManager.Instance.Setup();
    if ((double) Camera.main.fieldOfView != 25.0)
      Camera.main.fieldOfView = 25f;
    Camera.main.transform.position = new Vector3(0.0f, 0.0f, -16f);
    Camera.main.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    Camera.main.cullingMask |= 1;
    GUIManager.Instance.m_UICanvas.renderMode = (RenderMode) 1;
    GUIManager.Instance.SetCameraorthOgraphic(true);
    AudioManager.Instance.LoadAndPlayBGM(BGMType.Newie, (byte) 1);
    GUIManager.Instance.OpenMenu(EGUIWindow.UI_Front);
    AssetManager.Instance.AssetManagerState = AssetState.Ready;
    NewbieLog.Log(ENewbieLogKind.FORCE_1, (byte) 0);
  }

  protected override void UpdateReady(byte[] meg)
  {
    GameObject gameObject1 = new GameObject("cloth");
    this.cloth = gameObject1.AddComponent<Image>();
    for (int index = 0; index < AssetManager.Instance.Shaders.Length; ++index)
    {
      if (AssetManager.Instance.Shaders[index].name == "zTWRD2 Shaders/UI/Sprites")
      {
        ((MaskableGraphic) this.cloth).material = new Material((Shader) AssetManager.Instance.Shaders[index]);
        ((MaskableGraphic) this.cloth).material.renderQueue = 3100;
        break;
      }
    }
    ((Graphic) this.cloth).color = new Color(0.0f, 0.0f, 0.0f, 1f);
    RectTransform component = gameObject1.GetComponent<RectTransform>();
    ((Transform) component).SetParent((Transform) GUIManager.Instance.m_FourthWindowLayer, false);
    this.Canvasrectran = ((Component) GUIManager.Instance.m_UICanvas).transform as RectTransform;
    component.sizeDelta = this.Canvasrectran.sizeDelta * 1.5f;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Front, 0);
    GameObject gameObject2 = new GameObject("FrontGroup");
    gameObject2.AddComponent<IgnoreRaycast>();
    this.FrontGroupTransform = gameObject2.transform;
    this.FrontGroupTransform.SetParent(((Component) GUIManager.Instance.m_UICanvas).transform, false);
    this.FrontGroupTransform.SetAsFirstSibling();
    this.directController = gameObject2.GetComponent<Realm>();
    if ((Object) this.directController == (Object) null)
      this.directController = gameObject2.AddComponent<Realm>();
    this.directController.notSend();
    Transform group3Dtransform = this.directController.RealmGroup_3DTransform;
    Vector3 vector3_1 = Vector3.one * DataManager.MapDataController.zoomSize;
    this.FrontGroupTransform.localScale = vector3_1;
    Vector3 vector3_2 = vector3_1;
    group3Dtransform.localScale = vector3_2;
    if (NetworkManager.Connected())
      GUIManager.Instance.HideUILock(EUILock.Network);
    int num = !GameConstants.IsBigStyle() ? 48 : 64;
    this.FrontGroupTransform.gameObject.SetActive(false);
    GameObject gameObject3 = new GameObject("wordsfst");
    gameObject3.AddComponent<IgnoreRaycast>();
    this.WordTextFirst = gameObject3.AddComponent<UIText>();
    ((Shadow) gameObject3.AddComponent<Outline>()).effectColor = new Color(0.275f, 0.063f, 0.0f);
    gameObject3.AddComponent<Shadow>().effectDistance = new Vector2(2f, -2f);
    this.WordTextFirst.font = GUIManager.Instance.GetTTFFont();
    this.WordTextFirst.fontSize = num;
    this.WordTextFirst.alignment = TextAnchor.LowerCenter;
    this.WordTextFirst.resizeTextForBestFit = false;
    ((Graphic) this.WordTextFirst).color = new Color(1f, 1f, 1f, 0.0f);
    this.WordTextFirst.text = DataManager.Instance.mStringTable.GetStringByID(this.FstWordID[(int) this.nowFirstWordID]);
    this.WordTextFirst.SetAllDirty();
    RectTransform transform1 = gameObject3.transform as RectTransform;
    transform1.sizeDelta = new Vector2(this.Canvasrectran.sizeDelta.x, this.Canvasrectran.sizeDelta.y * 0.5f);
    transform1.anchoredPosition = new Vector2(0.0f, transform1.sizeDelta.y * 0.5f);
    ((Transform) transform1).SetParent((Transform) GUIManager.Instance.m_NewbieLayer, false);
    GameObject gameObject4 = new GameObject("wordssec");
    this.WordTextSec = gameObject4.AddComponent<UIText>();
    ((Shadow) gameObject4.AddComponent<Outline>()).effectColor = new Color(0.275f, 0.063f, 0.0f);
    gameObject4.AddComponent<Shadow>().effectDistance = new Vector2(2f, -2f);
    this.WordTextSec.font = GUIManager.Instance.GetTTFFont();
    this.WordTextSec.fontSize = num;
    this.WordTextSec.alignment = TextAnchor.UpperCenter;
    this.WordTextSec.resizeTextForBestFit = false;
    ((Graphic) this.WordTextSec).color = new Color(1f, 1f, 1f, 0.0f);
    this.WordTextSec.text = DataManager.Instance.mStringTable.GetStringByID(this.SecWordID[(int) this.nowSecWordID]);
    this.WordTextSec.SetAllDirty();
    RectTransform transform2 = gameObject4.transform as RectTransform;
    transform2.sizeDelta = new Vector2(this.Canvasrectran.sizeDelta.x, this.Canvasrectran.sizeDelta.y * 0.5f);
    transform2.anchoredPosition = new Vector2(0.0f, transform2.sizeDelta.y * -0.5f);
    ((Transform) transform2).SetParent((Transform) GUIManager.Instance.m_NewbieLayer, false);
  }

  protected override void UpdateRun(byte[] meg)
  {
    if ((int) this.nowFirstWordID < this.FstWordID.Length)
    {
      Color color = ((Graphic) this.WordTextFirst).color;
      switch (this.FstWordState)
      {
        case Front.FrontFlag.In:
          color.a += Time.deltaTime * this.wordFadInSpeed;
          if ((double) color.a > 0.550000011920929)
            this.SecWordState = Front.FrontFlag.In;
          if ((double) color.a >= 1.0)
          {
            color.a = 1f;
            this.FstWordState = Front.FrontFlag.Wait;
          }
          ((Graphic) this.WordTextFirst).color = color;
          break;
        case Front.FrontFlag.Out:
          color.a -= Time.deltaTime * this.wordFadOutSpeed;
          if ((double) color.a <= 0.0)
          {
            color.a = 0.0f;
            this.FstWordState = Front.FrontFlag.Zoom;
            ++this.nowFirstWordID;
            if ((int) this.nowFirstWordID < this.FstWordID.Length)
            {
              this.WordTextFirst.text = DataManager.Instance.mStringTable.GetStringByID(this.FstWordID[(int) this.nowFirstWordID]);
              this.WordTextFirst.SetAllDirty();
            }
          }
          ((Graphic) this.WordTextFirst).color = color;
          break;
        case Front.FrontFlag.Wait:
          this.FirstWordStayTime -= Time.deltaTime;
          if ((double) this.FirstWordStayTime <= 0.0)
          {
            this.FirstWordStayTime = this.FirstWordStayTimeMax;
            this.FstWordState = Front.FrontFlag.Out;
            break;
          }
          break;
        case Front.FrontFlag.Delay:
          if ((double) ((Graphic) this.cloth).color.a <= 0.6)
          {
            this.FstWordState = Front.FrontFlag.In;
            break;
          }
          break;
      }
    }
    if ((int) this.nowSecWordID < this.SecWordID.Length)
    {
      Color color = ((Graphic) this.WordTextSec).color;
      switch (this.SecWordState)
      {
        case Front.FrontFlag.In:
          color.a += Time.deltaTime * this.wordFadInSpeed;
          if ((double) color.a >= 1.0)
          {
            color.a = 1f;
            this.SecWordState = Front.FrontFlag.Wait;
          }
          ((Graphic) this.WordTextSec).color = color;
          break;
        case Front.FrontFlag.Out:
          color.a -= Time.deltaTime * this.wordFadOutSpeed;
          if ((double) color.a <= 0.10000000149011612)
          {
            this.FstWordState = Front.FrontFlag.In;
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_Front, 6);
          }
          else
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_Front, 7);
          if ((double) color.a <= 0.0)
          {
            color.a = 0.0f;
            this.SecWordState = Front.FrontFlag.Zoom;
            ++this.nowSecWordID;
            if ((int) this.nowSecWordID < this.SecWordID.Length)
            {
              this.WordTextSec.text = DataManager.Instance.mStringTable.GetStringByID(this.SecWordID[(int) this.nowSecWordID]);
              this.WordTextSec.SetAllDirty();
            }
            else
              this.ClothState = Front.FrontFlag.In;
          }
          ((Graphic) this.WordTextSec).color = color;
          break;
        case Front.FrontFlag.Wait:
          this.SecWordStayTime -= Time.deltaTime;
          if ((double) this.SecWordStayTime <= 0.0)
          {
            this.SecWordStayTime = this.SecWordStayTimeMax;
            this.SecWordState = Front.FrontFlag.Out;
            break;
          }
          break;
      }
    }
    Color color1 = ((Graphic) this.cloth).color;
    switch (this.ClothState)
    {
      case Front.FrontFlag.In:
        if ((double) this.delay > 0.0)
        {
          this.delay -= Time.deltaTime;
          break;
        }
        color1.a += (float) ((double) Time.deltaTime * (double) this.wordFadOutSpeed * 1.2000000476837158);
        if ((double) color1.a >= 1.0)
        {
          color1.a = 1f;
          this.ClothState = Front.FrontFlag.Move;
          this.FrontGroupTransform.gameObject.SetActive(true);
          this.iniMapData();
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Front, 1);
          break;
        }
        break;
      case Front.FrontFlag.Out:
        color1.a -= (float) ((double) Time.deltaTime * (double) this.wordFadOutSpeed * 0.40000000596046448);
        if ((double) color1.a <= 0.0)
        {
          color1.a = 0.0f;
          color1.r = 1f;
          color1.g = 0.914f;
          color1.b = 0.408f;
          this.ClothState = Front.FrontFlag.Wait;
          break;
        }
        break;
      case Front.FrontFlag.Move:
        color1.a -= (float) ((double) Time.deltaTime * (double) this.wordFadOutSpeed * 2.0);
        if ((double) color1.a <= 0.0)
        {
          color1.a = 0.0f;
          this.ClothState = Front.FrontFlag.Wait;
          break;
        }
        break;
    }
    ((Graphic) this.cloth).color = color1;
    if ((this.frontFlag & 32) != 0)
    {
      this.FrontGroupTransform.localScale += Vector3.one * Time.deltaTime * this.frontZoomSpeed;
      this.directController.RealmGroup_3DTransform.localScale = this.FrontGroupTransform.localScale;
      DataManager.MapDataController.zoomSize = this.FrontGroupTransform.localScale.x;
      this.directController.mapTileController.Check3DPos();
    }
    if ((this.frontFlag & 4) != 0)
      this.directController.mapTileController.Movedelta = this.frontMove * Time.deltaTime * DataManager.MapDataController.zoomSize;
    if ((this.frontFlag & 1) != 0)
    {
      this.frontFlag &= -2;
      if (this.frontState == Front.FrontState.Around)
      {
        this.frontWaitTime = 8f;
        this.frontFlag |= 8;
      }
    }
    if ((this.frontFlag & 2) != 0 && (double) ((Graphic) this.cloth).color.a < 1.0)
    {
      Color color2 = ((Graphic) this.cloth).color;
      color2.a += Time.deltaTime * this.frontFadeSpeed;
      if ((double) color2.a >= 1.0)
      {
        color2.a = 1f;
        this.frontFlag &= -3;
        if (this.frontState == Front.FrontState.Around)
        {
          this.directController.mapTileController.MovebyTileMapPos((int) this.startPoint.x, (int) this.startPoint.y, false);
          this.directController.mapTileController.Movedelta = this.frontMove = Vector2.zero;
          this.frontFlag &= -5;
          this.frontFlag |= 1;
          this.frontZoomSpeed = 0.25f;
          this.frontFlag |= 32;
          this.frontState = Front.FrontState.Speak;
        }
      }
      ((Graphic) this.cloth).color = color2;
    }
    if ((this.frontFlag & 8) != 0 && (double) this.frontWaitTime > 0.0)
    {
      this.frontWaitTime -= Time.deltaTime;
      if ((double) this.frontWaitTime <= 0.0)
      {
        this.frontWaitTime = 0.0f;
        this.frontFlag &= -9;
        switch (this.frontState)
        {
          case Front.FrontState.Around:
            if ((this.frontFlag & 32) != 0)
            {
              this.frontWaitTime = 0.1f;
              this.frontFlag |= 8;
              this.directController.mapTileController.MovebyTileMapPos((int) this.startPoint.x, (int) this.startPoint.y, false);
              this.directController.mapTileController.Movedelta = this.frontMove = Vector2.zero;
              this.frontFlag &= -5;
              DataManager.MapDataController.zoomSize = 0.9503304f;
              this.frontZoomSpeed = 0.0f;
              this.frontFlag &= -33;
              this.frontState = Front.FrontState.Speak;
              break;
            }
            this.frontMove *= 3.35f;
            this.frontWaitTime = 1.6f;
            this.frontFlag |= 8;
            this.frontZoomSpeed = 0.125f;
            this.frontFlag |= 32;
            break;
          case Front.FrontState.Go:
            this.frontState = Front.FrontState.Ready;
            this.frontZoomSpeed = 3.25f;
            this.frontFlag |= 32;
            this.frontWaitTime = 1E-05f;
            this.frontFlag |= 8;
            break;
          case Front.FrontState.Speak:
            GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, 12, 1);
            NewbieLog.Log(ENewbieLogKind.FORCE_1, (byte) 1);
            break;
          case Front.FrontState.Ready:
            AudioManager.Instance.PlayMP3SFX(this.readySFXID);
            WarManager.SetupNewbieWar();
            GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MapToWar);
            break;
        }
      }
    }
    if ((this.frontFlag & 16) != 0)
    {
      if ((double) this.lineNode.timeOffset * (double) this.lineNode.inverseMaxTime > 1.0)
      {
        this.directController.mapTileController.MovebyTileMapPos((int) this.endPoint.x, (int) this.endPoint.y, false);
        this.directController.mapTileController.Movedelta = this.frontMove = Vector2.zero;
        this.frontFlag &= -17;
        this.frontWaitTime = 1.5f;
        this.frontFlag |= 8;
        this.directController.DelLine(this.controlMapLineTableID, (byte) 1);
        DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].MapLineInit();
        DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].lineID = 0U;
        DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].playerName.AppendFormat(DataManager.Instance.RoleAttr.Name);
        DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].lineFlag = (byte) 23;
        GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int) this.endPoint.x, (int) this.endPoint.y), out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].start.zoneID, out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].start.pointID);
        GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int) this.startPoint.x, (int) this.startPoint.y), out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].end.zoneID, out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].end.pointID);
        DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].during = 5U;
        DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].begin = (ulong) NetworkManager.ServerTime;
        DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].EXbegin = DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].EXduring = 0U;
        DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].lineFlag = (byte) 23;
        this.directController.AddLine(this.controlMapLineTableID);
        DataManager.MapDataController.PlayerPointTable[(int) this.controlMapPlayerTableID].capitalFlag |= (byte) 2;
        this.directController.UpdatePoint((uint) GameConstants.TileMapPosToMapID((int) this.endPoint.x, (int) this.endPoint.y));
      }
      else
      {
        this.directController.mapTileController.Movedelta = new Vector2(this.lineNode.movingNode.position.x, this.lineNode.movingNode.position.y);
        this.directController.mapTileController.Movedelta /= -((Transform) this.Canvasrectran).localScale.x;
      }
    }
    if (this.checklineNode != null && (double) this.checklineNode.timeOffset * (double) this.checklineNode.inverseMaxTime > 1.0)
    {
      this.directController.DelLine(this.checkMapLineTableID, (byte) 1);
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].MapLineInit();
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].lineID = 0U;
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].playerName.ClearString();
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].playerName.IntToFormat((long) this.checkMapLineTableID);
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].playerName.AppendFormat("{0}");
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].kingdomID = this.KID[this.checkMapLineTableID];
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].allianceTag.ClearString();
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].allianceTag.IntToFormat((long) this.checkMapLineTableID);
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].allianceTag.IntToFormat((long) this.checkMapLineTableID);
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].allianceTag.IntToFormat((long) this.checkMapLineTableID);
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].allianceTag.AppendFormat("{0}{1}{2}");
      GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int) this.LineEndPoint[this.checkMapLineTableID].x, (int) this.LineEndPoint[this.checkMapLineTableID].y), out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].start.zoneID, out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].start.pointID);
      GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int) this.LineStartPoint[this.checkMapLineTableID].x, (int) this.LineStartPoint[this.checkMapLineTableID].y), out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].end.zoneID, out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].end.pointID);
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].during = this.LineDuring[this.checkMapLineTableID];
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].begin = (ulong) NetworkManager.ServerTime;
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].EXbegin = DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].EXduring = 0U;
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].lineFlag = (byte) 23;
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].EXduring += 5U;
      this.directController.AddLine(this.checkMapLineTableID, false);
      this.checklineNode = (LineNode) null;
    }
    if (this.checklineNode_EX != null && (double) this.checklineNode_EX.timeOffset * (double) this.checklineNode_EX.inverseMaxTime > 1.0)
    {
      this.directController.DelLine(this.checkMapLineTableID_EX, (byte) 1);
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].MapLineInit();
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].lineID = 0U;
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].playerName.ClearString();
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].playerName.IntToFormat((long) this.checkMapLineTableID_EX);
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].playerName.AppendFormat("{0}");
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].kingdomID = this.KID[this.checkMapLineTableID_EX];
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].allianceTag.ClearString();
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].allianceTag.IntToFormat((long) this.checkMapLineTableID_EX);
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].allianceTag.IntToFormat((long) this.checkMapLineTableID_EX);
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].allianceTag.IntToFormat((long) this.checkMapLineTableID_EX);
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].allianceTag.AppendFormat("{0}{1}{2}");
      GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int) this.LineEndPoint[this.checkMapLineTableID_EX].x, (int) this.LineEndPoint[this.checkMapLineTableID_EX].y), out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].start.zoneID, out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].start.pointID);
      GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int) this.LineStartPoint[this.checkMapLineTableID_EX].x, (int) this.LineStartPoint[this.checkMapLineTableID_EX].y), out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].end.zoneID, out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].end.pointID);
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].during = this.LineDuring[this.checkMapLineTableID_EX];
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].begin = (ulong) NetworkManager.ServerTime;
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].EXbegin = DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].EXduring = 0U;
      DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].lineFlag = (byte) 18;
      this.directController.AddLine(this.checkMapLineTableID_EX, false);
      this.checklineNode_EX = (LineNode) null;
    }
    if (this.checklineNode_PLUS == null || (double) this.checklineNode_PLUS.timeOffset * (double) this.checklineNode_PLUS.inverseMaxTime <= 1.0)
      return;
    this.directController.DelLine(this.checkMapLineTableID_PLUS, (byte) 1);
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].MapLineInit();
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].lineID = 0U;
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].playerName.ClearString();
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].playerName.IntToFormat((long) this.checkMapLineTableID_PLUS);
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].playerName.AppendFormat("{0}");
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].kingdomID = this.KID[this.checkMapLineTableID_PLUS];
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].allianceTag.ClearString();
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].allianceTag.IntToFormat((long) this.checkMapLineTableID_PLUS);
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].allianceTag.IntToFormat((long) this.checkMapLineTableID_PLUS);
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].allianceTag.IntToFormat((long) this.checkMapLineTableID_PLUS);
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].allianceTag.AppendFormat("{0}{1}{2}");
    GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int) this.LineEndPoint[this.checkMapLineTableID_PLUS].x, (int) this.LineEndPoint[this.checkMapLineTableID_PLUS].y), out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].start.zoneID, out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].start.pointID);
    GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int) this.LineStartPoint[this.checkMapLineTableID_PLUS].x, (int) this.LineStartPoint[this.checkMapLineTableID_PLUS].y), out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].end.zoneID, out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].end.pointID);
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].during = this.LineDuring[this.checkMapLineTableID_PLUS];
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].begin = (ulong) NetworkManager.ServerTime;
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].EXbegin = DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].EXduring = 0U;
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].lineFlag = (byte) 23;
    DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].EXduring += 5U;
    this.directController.AddLine(this.checkMapLineTableID_PLUS, false);
    this.checklineNode_PLUS = (LineNode) null;
  }

  private enum FrontFlag : byte
  {
    In,
    Out,
    Move,
    Wait,
    Follow,
    Zoom,
    Delay,
  }

  private enum FrontState : byte
  {
    Word,
    Around,
    Go,
    Speak,
    Ready,
    Count,
  }
}
