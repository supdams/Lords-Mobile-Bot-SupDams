// Decompiled with JetBrains decompiler
// Type: NewbieController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class NewbieController : 
  MonoBehaviour,
  IUIHIBtnClickHandler,
  IUIHIBtnUpDownHandler,
  IUIHIBtnDrag
{
  private const float N_ARROW_MOVE_RANGE = 40f;
  private const float N_ARROW_MOVE_SPEED = 40f;
  public NewbieManager pManager;
  protected Material ShareMat;
  protected Texture2D Black;
  public Image BlackPanel;
  public Image HoleMaskPanel;
  public Image HolePanel;
  public UIHIBtn HoleBtn;
  private RectTransform HoleMaskTrans;
  private RectTransform HoleTrans;
  private NewbieBtnData[] OtherHoles = new NewbieBtnData[5];
  public Image Arrow;
  private RectTransform ArrowTrans;
  private Vector2 ArrowPos = Vector2.zero;
  private Vector2 ArrowPosOffset = Vector2.zero;
  private bool bArrowShow;
  private int ArrowMoveSign = 1;
  private EArrowDir ArrowDir = EArrowDir.RIGHT;
  private Vector2 StageArrowPos = Vector2.zero;
  private bool bStageArrowShow;
  private Vector2 StageArrowPosOffset = Vector2.zero;
  private int StageArrowMoveSign = 1;
  private RectTransform StageArrowTrans;
  public Image TextBox;
  private RectTransform TextBoxTrans;
  private RectTransform TextTrans;
  private UIText m_Text;
  public Text[] m_TextEx = new Text[3];
  public RectTransform[] m_TextExTrans = new RectTransform[3];
  public Image[] m_ImageEx = new Image[3];
  public RectTransform[] m_ImageExTrans = new RectTransform[3];
  public Image[] m_Pointer = new Image[5];
  public RectTransform[] m_PointerTrans = new RectTransform[5];
  public bool bPointerShow;
  public Vector2 StartPoint = Vector2.zero;
  public Vector2 EndPoint = Vector2.zero;
  public Vector2 CenterPoint = Vector2.zero;
  public float PointerTimer;
  public float PointerTimer2;
  public byte PointerState;
  public Color[] PointerColor = new Color[5];
  public int PointerFlag;
  public FlowLineFactoryNewbie m_FlowLineFactoryNewbie;
  public float[] textPosX = new float[3]{ 90f, 250f, 410f };
  public ushort[,] textKey = new ushort[2, 3]
  {
    {
      (ushort) 8072,
      (ushort) 8073,
      (ushort) 8074
    },
    {
      (ushort) 8075,
      (ushort) 8076,
      (ushort) 8077
    }
  };
  private int AssetKey;
  public GameObject Npc_Parent;
  public NPC Npc_Node;
  public int Npc_ABKey;
  public int PreClickFlag;
  public RectTransform CoordTester;

  public void Awake()
  {
    AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UINewbie", out this.AssetKey);
    this.ShareMat = assetBundle.Load("UI_new_m") as Material;
    this.Black = new Texture2D(1, 1);
    this.Black.SetPixel(1, 1, (Color) new Color32((byte) 0, (byte) 0, (byte) 0, byte.MaxValue));
    this.Black.Apply();
    Shader shader1 = (Shader) null;
    Shader shader2 = (Shader) null;
    AssetManager instance = AssetManager.Instance;
    int length = instance.Shaders.Length;
    for (int index = 0; index < length; ++index)
    {
      if (instance.Shaders[index].name == "zTWRD2 Shaders/UI/Mask")
        shader2 = (Shader) instance.Shaders[index];
      else if (instance.Shaders[index].name == "zTWRD2 Shaders/UI/Masked")
        shader1 = (Shader) instance.Shaders[index];
    }
    GameObject original1 = new GameObject("HoleMaskPanel");
    this.HoleMaskTrans = original1.AddComponent<RectTransform>();
    this.HoleMaskTrans.anchorMin = Vector2.zero;
    this.HoleMaskTrans.anchorMax = Vector2.zero;
    this.HoleMaskTrans.pivot = new Vector2(0.5f, 0.5f);
    this.HoleMaskPanel = original1.AddComponent<Image>();
    Object[] objectArray = assetBundle.LoadAll(typeof (Sprite));
    for (int index = 0; index < objectArray.Length; ++index)
    {
      if (objectArray[index].name == "UI_new_mask_01")
        this.HoleMaskPanel.sprite = objectArray[index] as Sprite;
    }
    Material material = new Material(shader2);
    material.renderQueue = 3000;
    material.mainTexture = (Texture) this.HoleMaskPanel.sprite.texture;
    this.HoleMaskPanel.type = (Image.Type) 1;
    ((MaskableGraphic) this.HoleMaskPanel).material = material;
    original1.transform.SetParent(this.transform);
    original1.transform.localScale = Vector3.one;
    original1.transform.localPosition = Vector3.zero;
    original1.SetActive(false);
    for (int index = 0; index < 5; ++index)
    {
      GameObject gameObject = Object.Instantiate((Object) original1) as GameObject;
      gameObject.transform.SetParent(this.transform);
      gameObject.transform.localScale = Vector3.one;
      gameObject.transform.localPosition = Vector3.zero;
      this.OtherHoles[index].HoleMaskRectTransform = gameObject.transform as RectTransform;
    }
    GameObject gameObject1 = new GameObject("BlackPanel");
    RectTransform rectTransform = gameObject1.AddComponent<RectTransform>();
    rectTransform.anchorMin = Vector2.zero;
    rectTransform.anchorMax = Vector2.zero;
    rectTransform.pivot = new Vector2(0.25f, 0.25f);
    Vector2 vector2 = ((Component) GUIManager.Instance.m_UICanvas).gameObject.GetComponent<RectTransform>().sizeDelta * 2f;
    rectTransform.sizeDelta = new Vector2(vector2.x, vector2.y);
    this.BlackPanel = gameObject1.AddComponent<Image>();
    this.BlackPanel.sprite = Sprite.Create(this.Black, new Rect(0.0f, 0.0f, 1f, 1f), new Vector2(0.0f, 0.0f));
    ((MaskableGraphic) this.BlackPanel).material = new Material(shader1)
    {
      renderQueue = 3000,
      mainTexture = (Texture) this.Black
    };
    gameObject1.transform.SetParent(this.transform);
    gameObject1.transform.localScale = Vector3.one;
    gameObject1.transform.localPosition = Vector3.zero;
    gameObject1.SetActive(false);
    GameObject original2 = new GameObject("HolePanel");
    this.HoleTrans = original2.AddComponent<RectTransform>();
    this.HoleTrans.anchorMin = Vector2.zero;
    this.HoleTrans.anchorMax = Vector2.zero;
    this.HoleTrans.pivot = new Vector2(0.5f, 0.5f);
    this.HoleBtn = original2.AddComponent<UIHIBtn>();
    this.HoleBtn.m_BtnID1 = 0;
    this.HoleBtn.m_Handler = (IUIHIBtnClickHandler) this;
    this.HoleBtn.m_UpDownHandler = (IUIHIBtnUpDownHandler) this;
    this.HoleBtn.m_DHandler = (IUIHIBtnDrag) this;
    this.HolePanel = original2.AddComponent<Image>();
    for (int index = 0; index < objectArray.Length; ++index)
    {
      if (objectArray[index].name == "UI_new_frame_01")
        this.HolePanel.sprite = objectArray[index] as Sprite;
    }
    this.HolePanel.type = (Image.Type) 1;
    ((MaskableGraphic) this.HolePanel).material = this.ShareMat;
    original2.transform.SetParent(this.transform);
    original2.transform.localScale = Vector3.one;
    original2.transform.localPosition = Vector3.zero;
    original2.SetActive(false);
    for (int index = 0; index < 5; ++index)
    {
      GameObject gameObject2 = Object.Instantiate((Object) original2) as GameObject;
      gameObject2.GetComponent<UIHIBtn>().m_Handler = (IUIHIBtnClickHandler) this;
      gameObject2.transform.SetParent(this.transform);
      gameObject2.transform.localScale = Vector3.one;
      gameObject2.transform.localPosition = Vector3.zero;
      this.OtherHoles[index].rectTransform = gameObject2.transform as RectTransform;
      this.OtherHoles[index].button = gameObject2.GetComponent<UIHIBtn>();
      this.OtherHoles[index].button.m_BtnID1 = index + 1;
      this.OtherHoles[index].image = gameObject2.GetComponent<Image>();
    }
    GameObject gameObject3 = new GameObject("Dir");
    this.ArrowTrans = gameObject3.AddComponent<RectTransform>();
    this.ArrowTrans.anchorMin = Vector2.zero;
    this.ArrowTrans.anchorMax = Vector2.zero;
    this.ArrowTrans.pivot = new Vector2(0.5f, 0.5f);
    this.ArrowTrans.sizeDelta = new Vector2(98f, 71f);
    this.Arrow = gameObject3.AddComponent<Image>();
    for (int index = 0; index < objectArray.Length; ++index)
    {
      if (objectArray[index].name == "UI_new_arrow_01")
        this.Arrow.sprite = objectArray[index] as Sprite;
    }
    ((MaskableGraphic) this.Arrow).material = this.ShareMat;
    gameObject3.transform.SetParent(this.transform);
    gameObject3.transform.localScale = Vector3.one;
    gameObject3.transform.localPosition = Vector3.zero;
    gameObject3.SetActive(false);
    GameObject gameObject4 = new GameObject("TextBox");
    this.TextBoxTrans = gameObject4.AddComponent<RectTransform>();
    this.TextBoxTrans.anchorMin = Vector2.zero;
    this.TextBoxTrans.anchorMax = Vector2.zero;
    this.TextBoxTrans.pivot = new Vector2(0.5f, 0.5f);
    this.TextBox = gameObject4.AddComponent<Image>();
    for (int index = 0; index < objectArray.Length; ++index)
    {
      if (objectArray[index].name == "UI_new_box_02")
        this.TextBox.sprite = objectArray[index] as Sprite;
    }
    ((MaskableGraphic) this.TextBox).material = this.ShareMat;
    this.TextBox.type = (Image.Type) 1;
    gameObject4.AddComponent<IgnoreRaycast>();
    gameObject4.transform.SetParent(this.transform);
    gameObject4.transform.localScale = Vector3.one;
    gameObject4.transform.localPosition = Vector3.zero;
    gameObject4.SetActive(false);
    GameObject gameObject5 = new GameObject("Text");
    this.TextTrans = gameObject5.AddComponent<RectTransform>();
    this.TextTrans.anchorMin = new Vector2(0.5f, 0.0f);
    this.TextTrans.anchorMax = new Vector2(0.5f, 0.0f);
    this.TextTrans.pivot = new Vector2(0.5f, 0.0f);
    this.m_Text = gameObject5.AddComponent<UIText>();
    this.m_Text.font = GUIManager.Instance.GetTTFFont();
    ((Graphic) this.m_Text).color = Color.black;
    this.m_Text.fontSize = 24;
    this.m_Text.alignment = TextAnchor.MiddleLeft;
    this.m_Text.supportRichText = true;
    gameObject5.AddComponent<IgnoreRaycast>();
    gameObject5.transform.SetParent((Transform) this.TextBoxTrans);
    gameObject5.transform.localScale = Vector3.one;
    gameObject5.transform.localPosition = Vector3.zero;
    this.TextTrans.anchoredPosition = new Vector2(0.0f, 0.0f);
    for (int index = 0; index < 3; ++index)
    {
      GameObject gameObject6 = new GameObject("TextEx");
      this.m_TextExTrans[index] = gameObject6.AddComponent<RectTransform>();
      this.m_TextExTrans[index].anchorMin = Vector2.zero;
      this.m_TextExTrans[index].anchorMax = Vector2.zero;
      this.m_TextExTrans[index].pivot = new Vector2(0.5f, 0.5f);
      this.m_TextEx[index] = (Text) gameObject6.AddComponent<UIText>();
      this.m_TextEx[index].font = GUIManager.Instance.GetTTFFont();
      ((Graphic) this.m_TextEx[index]).color = Color.black;
      this.m_TextEx[index].fontSize = 17;
      this.m_TextEx[index].alignment = TextAnchor.MiddleCenter;
      gameObject6.AddComponent<IgnoreRaycast>();
      gameObject6.transform.SetParent((Transform) this.TextBoxTrans);
      gameObject6.transform.localScale = Vector3.one;
      gameObject6.transform.localPosition = Vector3.zero;
      this.m_TextExTrans[index].anchoredPosition = new Vector2(this.textPosX[index], 30f);
      gameObject6.SetActive(false);
    }
    for (int index = 0; index < 3; ++index)
    {
      GameObject gameObject7 = new GameObject("ImageEx");
      this.m_ImageExTrans[index] = gameObject7.AddComponent<RectTransform>();
      this.m_ImageExTrans[index].anchorMin = Vector2.zero;
      this.m_ImageExTrans[index].anchorMax = Vector2.zero;
      this.m_ImageExTrans[index].pivot = new Vector2(0.5f, 0.5f);
      this.m_ImageEx[index] = gameObject7.AddComponent<Image>();
      gameObject7.AddComponent<IgnoreRaycast>();
      gameObject7.transform.SetParent((Transform) this.TextBoxTrans);
      gameObject7.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
      gameObject7.transform.localPosition = Vector3.zero;
      gameObject7.SetActive(false);
    }
    Sprite sprite = (Sprite) null;
    for (int index = 0; index < objectArray.Length; ++index)
    {
      if (objectArray[index].name == "UI_slide")
      {
        sprite = objectArray[index] as Sprite;
        break;
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      GameObject gameObject8 = new GameObject("Pointer");
      this.m_PointerTrans[index] = gameObject8.AddComponent<RectTransform>();
      this.m_PointerTrans[index].anchorMin = new Vector2(0.5f, 0.0f);
      this.m_PointerTrans[index].anchorMax = new Vector2(0.5f, 0.0f);
      this.m_PointerTrans[index].pivot = new Vector2(0.5f, 0.5f);
      this.m_Pointer[index] = gameObject8.AddComponent<Image>();
      ((MaskableGraphic) this.m_Pointer[index]).material = this.ShareMat;
      this.m_Pointer[index].sprite = sprite;
      this.m_Pointer[index].SetNativeSize();
      if (index > 0)
        ((Graphic) this.m_Pointer[index]).color = (Color) new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, (byte) 0);
      gameObject8.AddComponent<IgnoreRaycast>();
      gameObject8.transform.SetParent(this.transform);
      gameObject8.transform.localScale = Vector3.one;
      gameObject8.transform.localPosition = Vector3.zero;
      gameObject8.SetActive(false);
    }
    GameObject gameObject9 = new GameObject("StageDir");
    this.StageArrowTrans = gameObject9.AddComponent<RectTransform>();
    this.StageArrowTrans.anchorMin = Vector2.zero;
    this.StageArrowTrans.anchorMax = Vector2.zero;
    this.StageArrowTrans.pivot = new Vector2(0.5f, 0.5f);
    this.StageArrowTrans.sizeDelta = new Vector2(98f, 71f);
    Image image = gameObject9.AddComponent<Image>();
    image.sprite = this.Arrow.sprite;
    ((MaskableGraphic) image).material = new Material(this.ShareMat)
    {
      renderQueue = 2500
    };
    gameObject9.transform.SetParent((Transform) GUIManager.Instance.m_BottomLayer);
    gameObject9.transform.localScale = Vector3.one;
    gameObject9.transform.localPosition = Vector3.zero;
    gameObject9.SetActive(false);
    this.CoordTester = new GameObject("CoordTester").AddComponent<RectTransform>();
    ((Transform) this.CoordTester).SetParent(this.transform, true);
    this.CoordTester.anchorMax = Vector2.zero;
    this.CoordTester.anchorMin = Vector2.zero;
    this.CoordTester.pivot = Vector2.one * 0.5f;
  }

  public void RebuildText()
  {
    if (!((Object) this.TextBoxTrans != (Object) null) || !((Component) this.TextBoxTrans).gameObject.activeSelf)
      return;
    ((Behaviour) this.m_Text).enabled = false;
    ((Behaviour) this.m_Text).enabled = true;
  }

  public Vector2 ScreenPointTest(RectTransform rt)
  {
    ((Transform) this.CoordTester).SetParent((Transform) rt);
    ((Transform) this.CoordTester).localPosition = Vector3.zero;
    ((Transform) this.CoordTester).SetParent(this.transform, true);
    return this.CoordTester.anchoredPosition + new Vector2(rt.sizeDelta.x * (0.5f - rt.pivot.x), rt.sizeDelta.y * (0.5f - rt.pivot.y));
  }

  public void Update()
  {
    if (this.pManager != null)
      this.pManager.Update();
    if (this.bArrowShow)
    {
      if (this.ArrowDir == EArrowDir.RIGHT)
      {
        this.ArrowPosOffset.x += Time.deltaTime * 40f * (float) this.ArrowMoveSign;
        if ((double) this.ArrowPosOffset.x >= 40.0)
        {
          this.ArrowPosOffset.x = 40f;
          this.ArrowMoveSign *= -1;
        }
        else if ((double) this.ArrowPosOffset.x <= 0.0)
        {
          this.ArrowPosOffset.x = 0.0f;
          this.ArrowMoveSign *= -1;
        }
      }
      else if (this.ArrowDir == EArrowDir.UP)
      {
        this.ArrowPosOffset.y -= Time.deltaTime * 40f * (float) this.ArrowMoveSign;
        if ((double) this.ArrowPosOffset.y <= -40.0)
        {
          this.ArrowPosOffset.y = -40f;
          this.ArrowMoveSign *= -1;
        }
        else if ((double) this.ArrowPosOffset.y >= 0.0)
        {
          this.ArrowPosOffset.y = 0.0f;
          this.ArrowMoveSign *= -1;
        }
      }
      else if (this.ArrowDir == EArrowDir.DOWN)
      {
        this.ArrowPosOffset.y += Time.deltaTime * 40f * (float) this.ArrowMoveSign;
        if ((double) this.ArrowPosOffset.y >= 40.0)
        {
          this.ArrowPosOffset.y = 40f;
          this.ArrowMoveSign *= -1;
        }
        else if ((double) this.ArrowPosOffset.y <= 0.0)
        {
          this.ArrowPosOffset.y = 0.0f;
          this.ArrowMoveSign *= -1;
        }
      }
      else if (this.ArrowDir == EArrowDir.LEFT)
      {
        this.ArrowPosOffset.x -= Time.deltaTime * 40f * (float) this.ArrowMoveSign;
        if ((double) this.ArrowPosOffset.x <= -40.0)
        {
          this.ArrowPosOffset.x = -40f;
          this.ArrowMoveSign *= -1;
        }
        else if ((double) this.ArrowPosOffset.x >= 0.0)
        {
          this.ArrowPosOffset.x = 0.0f;
          this.ArrowMoveSign *= -1;
        }
      }
      this.ArrowTrans.anchoredPosition = this.ArrowPos + this.ArrowPosOffset;
    }
    if (this.bStageArrowShow)
    {
      this.StageArrowPosOffset.y += Time.deltaTime * 40f * (float) this.StageArrowMoveSign;
      if ((double) this.StageArrowPosOffset.y >= 40.0)
      {
        this.StageArrowPosOffset.y = 40f;
        this.StageArrowMoveSign *= -1;
      }
      else if ((double) this.StageArrowPosOffset.y <= 0.0)
      {
        this.StageArrowPosOffset.y = 0.0f;
        this.StageArrowMoveSign *= -1;
      }
      this.StageArrowTrans.anchoredPosition = this.StageArrowPos + this.StageArrowPosOffset;
    }
    if (this.m_FlowLineFactoryNewbie != null)
      this.m_FlowLineFactoryNewbie.Update(Time.deltaTime);
    if (this.Npc_Node != null)
      this.Npc_Node.Run();
    this.UpdatePointer();
  }

  public void UpdatePointer()
  {
    if (!this.bPointerShow)
      return;
    if (this.PointerState == (byte) 0)
    {
      Vector2 vector2 = GameConstants.QuadraticBezierCurves(this.StartPoint, this.CenterPoint, this.EndPoint, 1f, this.PointerTimer);
      this.m_PointerTrans[0].anchoredPosition = vector2;
      this.PointerTimer += Time.smoothDeltaTime;
      this.PointerTimer2 += Time.smoothDeltaTime;
      if ((double) this.PointerTimer2 > 0.20000000298023224)
      {
        this.PointerTimer2 = 0.0f;
        this.PointerColor[this.PointerFlag].a = 0.5f;
        this.m_PointerTrans[this.PointerFlag].anchoredPosition = vector2;
        ((Graphic) this.m_Pointer[this.PointerFlag]).color = this.PointerColor[this.PointerFlag];
        ++this.PointerFlag;
        if (this.PointerFlag > 4)
          this.PointerFlag = 1;
      }
      if ((double) this.PointerTimer > 1.0)
      {
        this.PointerState = (byte) 1;
        this.PointerTimer = 0.0f;
      }
    }
    else if (this.PointerState == (byte) 1)
    {
      this.PointerTimer += Time.smoothDeltaTime;
      if ((double) this.PointerTimer > 0.5)
      {
        this.PointerState = (byte) 0;
        this.PointerTimer = 0.0f;
      }
    }
    for (int index = 1; index < 5; ++index)
    {
      if ((double) this.PointerColor[index].a > 1.0 / 1000.0)
      {
        this.PointerColor[index].a -= Time.smoothDeltaTime * 0.5f;
        this.PointerColor[index].a = Mathf.Max(this.PointerColor[index].a, 0.0f);
        ((Graphic) this.m_Pointer[index]).color = this.PointerColor[index];
      }
    }
  }

  public void ShowPointer(bool bShow, Vector2? start = null, Vector2? end = null)
  {
    if (bShow)
    {
      if (start.HasValue)
        this.StartPoint = start.Value;
      if (end.HasValue)
        this.EndPoint = end.Value;
      this.CenterPoint = new Vector2(this.StartPoint.x, this.EndPoint.y);
      this.PointerState = (byte) 0;
      this.PointerTimer = 0.0f;
      this.PointerTimer2 = 0.0f;
      this.PointerFlag = 1;
    }
    this.bPointerShow = bShow;
    ((Component) this.m_Pointer[0]).gameObject.SetActive(bShow);
    for (int index = 1; index < 5; ++index)
    {
      ((Component) this.m_Pointer[index]).gameObject.SetActive(bShow);
      this.PointerColor[index] = new Color(1f, 1f, 1f, 0.0f);
    }
  }

  public void ToEnemyPointer(Vector2 start, int enemyIdx, int param = 0)
  {
    if (!(GameManager.ActiveGameplay is BattleController activeGameplay))
      return;
    Vector2 vector2 = (Vector2) Camera.main.WorldToScreenPoint(activeGameplay.enemyUnit[enemyIdx].Position) / GUIManager.Instance.m_UICanvas.scaleFactor;
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform canvasRt = GUIManager.Instance.pDVMgr.CanvasRT;
      vector2.x += (float) (((double) canvasRt.sizeDelta.x * 0.5 - (double) vector2.x) * 2.0);
    }
    this.ShowPointer(true, new Vector2?(start), new Vector2?(vector2));
  }

  public void SetArrow(bool bShow, EArrowDir dir = EArrowDir.RIGHT)
  {
    if (bShow)
    {
      ((Component) this.ArrowTrans).gameObject.SetActive(true);
      ((Transform) this.ArrowTrans).localRotation = Quaternion.identity;
      switch (dir)
      {
        case EArrowDir.UP:
          ((Transform) this.ArrowTrans).Rotate(new Vector3(0.0f, 0.0f, 90f));
          this.ArrowTrans.anchoredPosition = this.HoleTrans.anchoredPosition + new Vector2(0.0f, (float) -((double) this.HoleTrans.sizeDelta.y * 0.5 + 50.0));
          break;
        case EArrowDir.DOWN:
          ((Transform) this.ArrowTrans).Rotate(new Vector3(0.0f, 0.0f, 270f));
          this.ArrowTrans.anchoredPosition = this.HoleTrans.anchoredPosition + new Vector2(0.0f, (float) ((double) this.HoleTrans.sizeDelta.y * 0.5 + 50.0));
          break;
        case EArrowDir.LEFT:
          ((Transform) this.ArrowTrans).Rotate(new Vector3(0.0f, 0.0f, 180f));
          this.ArrowTrans.anchoredPosition = this.HoleTrans.anchoredPosition + new Vector2((float) ((double) this.HoleTrans.sizeDelta.x * 0.5 + 50.0), 0.0f);
          break;
        default:
          this.ArrowTrans.anchoredPosition = this.HoleTrans.anchoredPosition + new Vector2((float) -((double) this.HoleTrans.sizeDelta.x * 0.5 + 50.0), 0.0f);
          break;
      }
      this.ArrowTrans.anchoredPosition3D = new Vector3(this.ArrowTrans.anchoredPosition.x, this.ArrowTrans.anchoredPosition.y, 0.0f);
      this.ArrowPos = this.ArrowTrans.anchoredPosition;
      this.ArrowPosOffset = Vector2.zero;
      this.ArrowDir = dir;
      this.ArrowMoveSign = 1;
      this.bArrowShow = true;
    }
    else
    {
      ((Component) this.ArrowTrans).gameObject.SetActive(false);
      this.bArrowShow = false;
    }
  }

  public void SetStageArrow(bool bShow, Vector2? pos = null)
  {
    if (bShow)
    {
      ((Component) this.StageArrowTrans).gameObject.SetActive(true);
      ((Transform) this.StageArrowTrans).localRotation = Quaternion.identity;
      ((Transform) this.StageArrowTrans).Rotate(new Vector3(0.0f, 0.0f, 270f));
      this.StageArrowTrans.anchoredPosition = pos.HasValue ? pos.Value : Vector2.zero;
      this.StageArrowTrans.anchoredPosition3D = new Vector3(this.StageArrowTrans.anchoredPosition.x, this.StageArrowTrans.anchoredPosition.y, 0.0f);
      this.StageArrowPos = this.StageArrowTrans.anchoredPosition;
      this.StageArrowPosOffset = Vector2.zero;
      this.StageArrowMoveSign = 1;
      this.bStageArrowShow = true;
    }
    else
    {
      ((Component) this.StageArrowTrans).gameObject.SetActive(false);
      this.bStageArrowShow = false;
    }
  }

  public void SetText(ushort Key, Vector2 offset)
  {
    ((Component) this.TextBoxTrans).gameObject.SetActive(true);
    ((Transform) this.TextBoxTrans).localRotation = Quaternion.identity;
    this.TextBoxTrans.anchoredPosition = this.HoleTrans.anchoredPosition + offset;
    this.m_Text.text = DataManager.Instance.mStringTable.GetStringByID((uint) Key);
    this.TextTrans.sizeDelta = new Vector2(1920f, 1920f);
    this.TextTrans.sizeDelta = new Vector2(this.m_Text.preferredWidth, this.m_Text.preferredHeight + 26f);
    this.TextBoxTrans.sizeDelta = new Vector2(this.TextTrans.sizeDelta.x + 26f, this.m_Text.preferredHeight + 26f);
    this.TextTrans.anchoredPosition = new Vector2(0.0f, 0.0f);
    Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
    float num1 = this.TextBoxTrans.anchoredPosition.x - this.TextBoxTrans.sizeDelta.x * 0.5f;
    float num2 = this.TextBoxTrans.anchoredPosition.x + this.TextBoxTrans.sizeDelta.x * 0.5f;
    Vector2 anchoredPosition = this.TextBoxTrans.anchoredPosition;
    if ((double) num1 < 0.0)
    {
      anchoredPosition.x -= num1;
      this.TextBoxTrans.anchoredPosition = anchoredPosition;
    }
    else
    {
      if ((double) num2 <= (double) sizeDelta.x)
        return;
      anchoredPosition.x -= num2 - sizeDelta.x;
      this.TextBoxTrans.anchoredPosition = anchoredPosition;
    }
  }

  public void SetBlackVisible(bool bShow)
  {
    ((Graphic) this.BlackPanel).color = (Color) new Color32((byte) 0, (byte) 0, (byte) 0, !bShow ? (byte) 0 : (byte) 130);
    RectTransform transform = ((Component) this.BlackPanel).transform as RectTransform;
    ((Transform) transform).localRotation = Quaternion.identity;
    transform.anchoredPosition = Vector2.zero;
  }

  public void SetHoleVisible(bool bShow, Rect? _r = null, HolePivot pivot = HolePivot.CENTER, bool setAP = false)
  {
    ((Component) this.HoleMaskPanel).gameObject.SetActive(bShow);
    ((Component) this.HolePanel).gameObject.SetActive(bShow);
    if (!bShow)
      return;
    if (!_r.HasValue)
    {
      Rect rect = new Rect();
      Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
      rect.position = sizeDelta * 0.5f;
      rect.size = sizeDelta * 1.3f;
      _r = new Rect?(rect);
    }
    ((Transform) this.HoleMaskTrans).localRotation = Quaternion.identity;
    ((Transform) this.HoleTrans).localRotation = Quaternion.identity;
    Vector2 vector2 = new Vector2(0.5f, 0.5f);
    switch (pivot)
    {
      case HolePivot.BOTTOM_LEFT:
        vector2 = new Vector2(0.0f, 0.0f);
        break;
      case HolePivot.BOTTOM_RIGHT:
        vector2 = new Vector2(1f, 0.0f);
        break;
      case HolePivot.TOP_LEFT:
        vector2 = new Vector2(0.0f, 1f);
        break;
      case HolePivot.TOP_RIGHT:
        vector2 = new Vector2(1f, 1f);
        break;
    }
    this.HoleMaskTrans.pivot = vector2;
    this.HoleTrans.pivot = vector2;
    Rect rect1 = _r.Value;
    this.HoleMaskTrans.sizeDelta = new Vector2(rect1.width, rect1.height);
    if (setAP)
      this.HoleMaskTrans.anchoredPosition = (Vector2) new Vector3(rect1.position.x, rect1.position.y, 0.0f);
    else
      ((Transform) this.HoleMaskTrans).localPosition = new Vector3(rect1.position.x, rect1.position.y, 0.0f);
    this.HoleTrans.sizeDelta = new Vector2(rect1.width, rect1.height);
    ((Transform) this.HoleTrans).localPosition = new Vector3(rect1.position.x, rect1.position.y, 0.0f);
  }

  public void SetOtherHoleVisible(int idx, bool bShow, Vector2 pos)
  {
    if (idx >= 5)
      return;
    ((Component) this.OtherHoles[idx].HoleMaskRectTransform).gameObject.SetActive(bShow);
    ((Component) this.OtherHoles[idx].rectTransform).gameObject.SetActive(bShow);
    if (!bShow)
      return;
    ((Transform) this.OtherHoles[idx].HoleMaskRectTransform).localRotation = Quaternion.identity;
    ((Transform) this.OtherHoles[idx].rectTransform).localRotation = Quaternion.identity;
    this.OtherHoles[idx].HoleMaskRectTransform.pivot = this.HoleMaskTrans.pivot;
    this.OtherHoles[idx].rectTransform.pivot = this.HoleMaskTrans.pivot;
    this.OtherHoles[idx].HoleMaskRectTransform.sizeDelta = this.HoleMaskTrans.sizeDelta;
    ((Transform) this.OtherHoles[idx].HoleMaskRectTransform).localPosition = new Vector3(pos.x, pos.y, 0.0f);
    this.OtherHoles[idx].rectTransform.sizeDelta = this.HoleMaskTrans.sizeDelta;
    ((Transform) this.OtherHoles[idx].rectTransform).localPosition = new Vector3(pos.x, pos.y, 0.0f);
  }

  public void SetSpecialBox(bool bShow, byte type = 0)
  {
    if (bShow)
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if ((Object) menu == (Object) null)
        return;
      if ((Object) menu.m_GroundInfo.TileMapMat == (Object) null)
      {
        menu.m_GroundInfo.TileMapMat = Object.Instantiate((Object) ((MaskableGraphic) menu.TileMapController.TileSprites.m_Image).material) as Material;
        menu.m_GroundInfo.TileMapMat.renderQueue = 3000;
      }
      ((Component) this.TextBoxTrans).gameObject.SetActive(true);
      this.TextBoxTrans.sizeDelta = new Vector2(500f, 150f);
      this.TextBoxTrans.anchoredPosition = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta * 0.5f + new Vector2(0.0f, 60f);
      for (int index = 0; index < 3; ++index)
      {
        ((Component) this.m_ImageEx[index]).gameObject.SetActive(true);
        ((MaskableGraphic) this.m_ImageEx[index]).material = menu.m_GroundInfo.TileMapMat;
      }
      switch (type)
      {
        case 0:
          menu.TileMapController.getTileMapSprite(ref this.m_ImageEx[0], POINT_KIND.PK_CITY, 25);
          this.m_ImageEx[0].SetNativeSize();
          this.m_ImageExTrans[0].anchoredPosition = new Vector2(95f, 70f);
          menu.TileMapController.getTileMapSprite(ref this.m_ImageEx[2], POINT_KIND.PK_FOOD);
          this.m_ImageEx[2].SetNativeSize();
          this.m_ImageExTrans[2].anchoredPosition = new Vector2(396.5f, 70f);
          this.m_ImageExTrans[1].anchoredPosition = new Vector2(95f, 60f);
          Vector3 position1 = ((Transform) this.m_ImageExTrans[1]).position;
          this.m_ImageExTrans[1].anchoredPosition = new Vector2(396.5f, 60f);
          Vector3 position2 = ((Transform) this.m_ImageExTrans[1]).position;
          ((Component) this.m_ImageEx[1]).gameObject.SetActive(false);
          if (!(GameManager.ActiveGameplay is CHAOS activeGameplay1) || !((Object) activeGameplay1.realmController != (Object) null))
            break;
          if (this.m_FlowLineFactoryNewbie == null)
            this.m_FlowLineFactoryNewbie = new FlowLineFactoryNewbie(activeGameplay1.realmController.RealmGroup_3DTransform, activeGameplay1.realmController.mapTileController.TileBaseScale);
          this.m_FlowLineFactoryNewbie.createLine(new MapLine()
          {
            lineID = uint.MaxValue,
            begin = (ulong) DataManager.Instance.ServerTime,
            during = 5U,
            lineFlag = (byte) 0
          }, position1, position2, ELineColor.DEEPBLUE, EUnitSide.BLUE, false, bLoop: (byte) 1);
          break;
        case 1:
          menu.TileMapController.getTileMapSprite(ref this.m_ImageEx[0], POINT_KIND.PK_CITY, 25);
          this.m_ImageEx[0].SetNativeSize();
          this.m_ImageExTrans[0].anchoredPosition = new Vector2(95f, 70f);
          menu.TileMapController.getTileMapSprite(ref this.m_ImageEx[2], POINT_KIND.PK_CITY, 24);
          this.m_ImageEx[2].SetNativeSize();
          this.m_ImageExTrans[2].anchoredPosition = new Vector2(412.4f, 70f);
          this.m_ImageExTrans[1].anchoredPosition = new Vector2(95f, 60f);
          Vector3 position3 = ((Transform) this.m_ImageExTrans[1]).position;
          this.m_ImageExTrans[1].anchoredPosition = new Vector2(412.4f, 60f);
          Vector3 position4 = ((Transform) this.m_ImageExTrans[1]).position;
          ((Component) this.m_ImageEx[1]).gameObject.SetActive(false);
          if (!(GameManager.ActiveGameplay is CHAOS activeGameplay2) || !((Object) activeGameplay2.realmController != (Object) null))
            break;
          if (this.m_FlowLineFactoryNewbie == null)
            this.m_FlowLineFactoryNewbie = new FlowLineFactoryNewbie(activeGameplay2.realmController.RealmGroup_3DTransform, activeGameplay2.realmController.mapTileController.TileBaseScale);
          this.m_FlowLineFactoryNewbie.createLine(new MapLine()
          {
            lineID = uint.MaxValue,
            begin = (ulong) DataManager.Instance.ServerTime,
            during = 2U,
            lineFlag = (byte) 5
          }, position3, position4, ELineColor.DEEPBLUE, EUnitSide.BLUE, false, bLoop: (byte) 1);
          this.m_FlowLineFactoryNewbie.MoveUnitToEndPoint(EMarchEventType.EMET_AttackRetreat);
          break;
        case 2:
          menu.TileMapController.getTileMapSprite(ref this.m_ImageEx[0], POINT_KIND.PK_CITY, 25);
          this.m_ImageEx[0].SetNativeSize();
          this.m_ImageExTrans[0].anchoredPosition = new Vector2(95f, 70f);
          ((Component) this.m_ImageEx[1]).gameObject.SetActive(false);
          this.m_ImageExTrans[2].anchoredPosition = new Vector2(412.4f, 70f);
          Vector2 position5 = (Vector2) ((Component) this.m_ImageExTrans[2]).transform.position;
          float iniscale = 1f / ((Transform) GUIManager.Instance.pDVMgr.CanvasRT).localScale.x;
          this.Npc_Parent = new GameObject("NPC");
          Transform transform = this.Npc_Parent.transform;
          transform.parent = ((Transform) this.m_ImageExTrans[2]).parent;
          transform.position = Vector3.zero;
          transform.localScale = Vector3.one;
          this.Npc_Node = new NPC(position5, iniscale, (sbyte) 1, (byte) 2, NPCState.NPC_Idle, transform, ref this.Npc_ABKey);
          this.Npc_Node.SetActive(true);
          this.m_ImageExTrans[2].anchoredPosition = new Vector2(95f, 60f);
          Vector3 position6 = ((Component) this.m_ImageEx[2]).transform.position;
          this.m_ImageExTrans[2].anchoredPosition = new Vector2(395f, 60f);
          Vector3 position7 = ((Component) this.m_ImageEx[2]).transform.position;
          ((Component) this.m_ImageEx[2]).gameObject.SetActive(false);
          LineNode lineNode = (LineNode) null;
          if (!(GameManager.ActiveGameplay is CHAOS activeGameplay3) || !((Object) activeGameplay3.realmController != (Object) null))
            break;
          if (this.m_FlowLineFactoryNewbie == null)
            this.m_FlowLineFactoryNewbie = new FlowLineFactoryNewbie(activeGameplay3.realmController.RealmGroup_3DTransform, activeGameplay3.realmController.mapTileController.TileBaseScale);
          lineNode = this.m_FlowLineFactoryNewbie.createLine(new MapLine()
          {
            lineID = uint.MaxValue,
            begin = (ulong) DataManager.Instance.ServerTime,
            during = 2U,
            lineFlag = (byte) 9
          }, position6, position7, ELineColor.DEEPBLUE, EUnitSide.BLUE, false, bLoop: (byte) 1);
          this.m_FlowLineFactoryNewbie.MoveUnitToEndPoint(EMarchEventType.EMET_HitMonsterRetreat);
          break;
      }
    }
    else
    {
      for (int index = 0; index < 3; ++index)
        ((Component) this.m_ImageEx[index]).gameObject.SetActive(false);
      if (this.m_FlowLineFactoryNewbie != null)
        this.m_FlowLineFactoryNewbie.ClearLine();
      if (this.Npc_Node != null)
      {
        this.Npc_Node.Release();
        this.Npc_Node = (NPC) null;
        AssetManager.UnloadAssetBundle(this.Npc_ABKey);
      }
      if (!((Object) this.Npc_Parent != (Object) null))
        return;
      Object.Destroy((Object) this.Npc_Parent);
      this.Npc_Parent = (GameObject) null;
    }
  }

  public void HideUI(bool force = false)
  {
    this.SetBlackVisible(false);
    this.SetHoleVisible(false);
    this.SetArrow(false);
    this.ShowPointer(false);
    if (this.PreClickFlag != 1 || force)
    {
      this.SetSpecialBox(false, (byte) 0);
      this.m_Text.text = string.Empty;
      ((Component) this.TextBoxTrans).gameObject.SetActive(false);
    }
    for (int index = 0; index < 5; ++index)
    {
      ((Component) this.OtherHoles[index].rectTransform).gameObject.SetActive(false);
      ((Component) this.OtherHoles[index].HoleMaskRectTransform).gameObject.SetActive(false);
    }
  }

  public void TriggerButtonEvent(int btnid = 0)
  {
    int workingKey = this.pManager.WorkingKey;
    ++this.pManager.SubStep;
    this.HideUI();
    NewbieManager.ClickBtnID = btnid;
    this.pManager.ExeClickAction(workingKey);
    if (this.pManager.NextUI == EGUIWindow.MAX || this.pManager.UIOperator != 0)
      return;
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(this.pManager.NextUI, this.pManager.NextUIArg1);
  }

  public bool CheckOutsideHole()
  {
    Rect rect = new Rect(this.HoleTrans.anchoredPosition.x - this.HoleTrans.sizeDelta.x * 0.5f, this.HoleTrans.anchoredPosition.y - this.HoleTrans.sizeDelta.y * 0.5f, this.HoleTrans.sizeDelta.x, this.HoleTrans.sizeDelta.y);
    return Input.touchCount <= 0 || !rect.Contains(Input.GetTouch(0).position);
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    if (this.pManager.IsSpecialKey())
      return;
    this.TriggerButtonEvent(sender.m_BtnID1);
  }

  public void OnHIButtonUp(UIHIBtn sender)
  {
    if (!this.pManager.IsSpecialKey() || !this.pManager.PreTriggerCheck())
      return;
    this.TriggerButtonEvent();
  }

  public void OnHIButtonDown(UIHIBtn sender)
  {
    if (this.pManager.WorkingKey == 8010)
    {
      this.pManager.Battle_SecondUltra_BtnDown();
    }
    else
    {
      if (this.pManager.WorkingKey != 8011)
        return;
      this.pManager.Battle_ThirdUltra_BtnDown();
    }
  }

  public void OnHIButtonDrag(UIHIBtn sender)
  {
    if (this.pManager.WorkingKey == 8010)
    {
      this.pManager.Battle_SecondUltra_BtnDrag();
    }
    else
    {
      if (this.pManager.WorkingKey != 8011)
        return;
      this.pManager.Battle_ThirdUltra_BtnDrag();
    }
  }

  public void OnHIButtonDragEnd(UIHIBtn sender)
  {
  }

  public void OnHIButtonDragExit(UIHIBtn sender)
  {
  }

  public void FreeResource() => AssetManager.UnloadAssetBundle(this.AssetKey);
}
