// Decompiled with JetBrains decompiler
// Type: DamageValueManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class DamageValueManager
{
  private const int DVCount_Word = 20;
  private const int DVCount_NUm = 60;
  private const float ScaleRate = 0.6f;
  private const float ShowTime = 1.5f;
  private const float FadeOutTime = 0.8f;
  private const float DecreaseTime = 0.0500000045f;
  private const float BarWidth = 45f;
  private const float BarHeight = 5f;
  private const float StateSize = 36f;
  private const int StateMax = 3;
  private const float BossFadeTime = 0.3f;
  private Color m_Color;
  private Color m_EnergyColor;
  private Color m_BlueColor;
  private Color m_RedColor;
  private Color m_GreenColor;
  private Color m_BlueColor1;
  private Color m_RedColor1;
  private Color m_GreenColor1;
  private Vector2 m_Vec2;
  private Vector3 m_Vec3;
  private BattleController bc;
  private WarManager wm;
  private StringBuilder sb = new StringBuilder();
  private int AssetKey_Font;
  private int AssetKey_Bar;
  private int AssetKey_Trans;
  private int AssetKey_Trans1;
  private float moveDelta = -1f;
  private float DVScaleN = 0.7f;
  private float DVScaleC = 0.4f;
  private float DVScale = 0.8f;
  private string GOName = "DamageValue";
  private Font m_DamageValueFont;
  private List<DamageValue> DVList = new List<DamageValue>();
  private Stack<DamageValue> EmptyDVStack_Word = new Stack<DamageValue>(20);
  private Stack<DamageValue> EmptyDVStack_Num = new Stack<DamageValue>(60);
  private string PlayerName = "PlayerBar";
  private string EnemyName = "EnemyBar";
  private int PlayerCount;
  private int EnemyCount;
  private Dictionary<ushort, Sprite> m_Dict = new Dictionary<ushort, Sprite>();
  private List<BloodBar> Player = new List<BloodBar>(20);
  private List<BloodBar> Enemy = new List<BloodBar>(20);
  private byte bTranstions;
  private GameObject TransitionsGO1;
  private GameObject TransitionsGO2;
  private GameObject TransitionsGO3;
  private GameObject TransitionsGO4;
  private GameObject TransitionsGO5;
  private GameObject BossObj;
  private RectTransform TRT1;
  private RectTransform m_CanvasRT;
  private RectTransform baseLayer;
  private RectTransform DamageValueLayer_Num;
  private RectTransform DamageValueLayer_Normal;
  private RectTransform DamageValueLayer_CRINum;
  private RectTransform DamageValueLayer_Word;
  private RectTransform TRT4;
  private RectTransform TRT5;
  public RectTransform TransitionLayer;
  public RectTransform BossTextRC;
  public RectTransform BossImgRC;
  private CanvasGroup BossCG;
  private Image TImage;
  private float fTransitionsTime;
  private float TransitionsSpeed = 100f;
  private float TransitionsDeltaX = 379f;
  private float TransitionsWidth = 853f;
  private float TransitionsZ;
  private float nowSize;
  private float DeltaSize = 0.33f;
  private float sizeMin;
  private float sizeMax = 15f;
  private Quaternion Quaternion1 = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
  private Quaternion Quaternion2 = new Quaternion(0.0f, 180f, 0.0f, 0.0f);
  private Material m_A8;
  private Material m_Axe;
  private Material m_Castle;
  private eTransFunc NowFuncKind = eTransFunc.Max;
  private eTransKind NowTransKind = eTransKind.Normal;
  public Vector3 FightBeginPos = Vector3.zero;
  private bool bAxeInNew;
  private bool bAxeOutNew;
  private bool bCastleInNew;
  private bool bCastleOutNew;
  private float dTime;
  private string TransNameStr = "Transitions1";
  private bool bBossMove;
  private bool bShowBoss;
  private bool bNeedShowBoss;
  private bool bBossTest;
  private float BossDeltaTime;
  private float BossTotalTime = 0.5f;
  private float BossMoveDelta;
  private float ShowBossTime;
  private float BossFadeDeltaTime = -1f;
  private float HalfTotalTime = 0.3f;
  private Image HalfImageTop;
  private Image HalfImageBottom;
  public UIText BossText;
  private Vector2 BossImagePos = new Vector2(0.0f, -107f);
  private Vector2 BossTextPos = new Vector2(0.0f, -84f);
  private Vector2 BossImageSize = new Vector2(1200f, 160f);
  private bool bBossMoveDown;
  private Color BossTextColor = new Color(1f, 0.859f, 0.286f);
  private Color BossTextColorOutline = new Color(0.898f, 0.635f, 0.0f, 0.5f);
  private Color BossTextColorShadow = new Color(0.855f, 0.4196f, 0.0705f, 0.5f);

  public DamageValueManager(Transform CanvasTransform)
  {
    this.m_Color = new Color(1f, 1f, 1f, 1f);
    this.m_RedColor = new Color(1f, 0.5254902f, 0.0156862754f, 1f);
    this.m_RedColor1 = new Color(1f, 0.2784314f, 0.384313732f, 1f);
    this.m_EnergyColor = new Color(1f, 0.972549f, 0.0235294122f, 1f);
    this.m_GreenColor = new Color(0.169960469f, 1f, 0.05882353f, 1f);
    this.m_GreenColor1 = new Color(0.0f, 0.6313726f, 0.1882353f, 1f);
    this.m_BlueColor = new Color(0.0f, 0.7529412f, 1f, 1f);
    this.m_BlueColor1 = new Color(0.149019614f, 0.3647059f, 1f, 1f);
    this.m_Vec2 = new Vector2(500f, 200f);
    GameObject gameObject1 = new GameObject("DamageValueBaseLayer");
    this.baseLayer = gameObject1.AddComponent<RectTransform>();
    this.SetDVTransform(this.baseLayer);
    gameObject1.layer = 5;
    ((Transform) this.baseLayer).SetParent(CanvasTransform, false);
    GameObject gameObject2 = new GameObject("BloodBarLayer");
    RectTransform rectTransform = gameObject2.AddComponent<RectTransform>();
    gameObject2.layer = 5;
    ((Transform) rectTransform).SetParent((Transform) this.baseLayer, false);
    GameObject gameObject3 = new GameObject(nameof (DamageValueLayer_Num));
    this.DamageValueLayer_Num = gameObject3.AddComponent<RectTransform>();
    gameObject3.layer = 5;
    ((Transform) this.DamageValueLayer_Num).SetParent((Transform) this.baseLayer, false);
    GameObject gameObject4 = new GameObject(nameof (DamageValueLayer_Normal));
    this.DamageValueLayer_Normal = gameObject4.AddComponent<RectTransform>();
    gameObject4.layer = 5;
    ((Transform) this.DamageValueLayer_Normal).SetParent((Transform) this.baseLayer, false);
    GameObject gameObject5 = new GameObject(nameof (DamageValueLayer_CRINum));
    this.DamageValueLayer_CRINum = gameObject5.AddComponent<RectTransform>();
    gameObject5.layer = 5;
    ((Transform) this.DamageValueLayer_CRINum).SetParent((Transform) this.baseLayer, false);
    GameObject gameObject6 = new GameObject(nameof (DamageValueLayer_Word));
    this.DamageValueLayer_Word = gameObject6.AddComponent<RectTransform>();
    gameObject6.layer = 5;
    ((Transform) this.DamageValueLayer_Word).SetParent((Transform) this.baseLayer, false);
  }

  public Font DamageValueFont
  {
    get
    {
      if ((UnityEngine.Object) this.m_DamageValueFont == (UnityEngine.Object) null)
      {
        AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/DVFont", out this.AssetKey_Font);
        if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
          return (Font) null;
        this.m_DamageValueFont = (Font) UnityEngine.Object.Instantiate(assetBundle.mainAsset);
      }
      return this.m_DamageValueFont;
    }
  }

  public RectTransform CanvasRT
  {
    get
    {
      if ((UnityEngine.Object) this.m_CanvasRT == (UnityEngine.Object) null)
        this.m_CanvasRT = ((Component) GUIManager.Instance.m_UICanvas).GetComponent<RectTransform>();
      return this.m_CanvasRT;
    }
  }

  ~DamageValueManager()
  {
  }

  public void UnLoadDamageValueAsset()
  {
    if ((UnityEngine.Object) this.TransitionsGO1 != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.TransitionsGO1);
      this.TransitionsGO1 = (GameObject) null;
      UnityEngine.Object.Destroy((UnityEngine.Object) this.TransitionsGO4);
      this.TransitionsGO4 = (GameObject) null;
      UnityEngine.Object.Destroy((UnityEngine.Object) this.TransitionsGO5);
      this.TransitionsGO5 = (GameObject) null;
      UnityEngine.Object.Destroy((UnityEngine.Object) this.BossObj);
      this.BossObj = (GameObject) null;
      GUIManager.Instance.RemoveSpriteAsset(this.TransNameStr);
      if (this.AssetKey_Trans1 != 0)
        AssetManager.UnloadAssetBundle(this.AssetKey_Trans1);
    }
    if ((UnityEngine.Object) this.TransitionsGO2 != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.TransitionsGO2);
      this.TransitionsGO2 = (GameObject) null;
    }
    if ((UnityEngine.Object) this.TransitionsGO3 != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.TransitionsGO3);
      this.TransitionsGO3 = (GameObject) null;
    }
    if (this.AssetKey_Trans != 0)
      AssetManager.UnloadAssetBundle(this.AssetKey_Trans);
    if ((UnityEngine.Object) this.m_DamageValueFont != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.m_DamageValueFont);
      if (this.AssetKey_Font != 0)
        AssetManager.UnloadAssetBundle(this.AssetKey_Font);
    }
    if (this.AssetKey_Bar == 0)
      return;
    AssetManager.UnloadAssetBundle(this.AssetKey_Bar);
  }

  public void SetDVTransform(RectTransform tran)
  {
    tran.pivot = new Vector2(0.5f, 0.5f);
    tran.anchorMin = new Vector2(0.0f, 0.0f);
    tran.anchorMax = new Vector2(0.0f, 0.0f);
  }

  public void SetTransitionLayer(Transform CanvasTransform)
  {
    this.TransitionLayer = new GameObject("TransitionLayer")
    {
      layer = 5
    }.AddComponent<RectTransform>();
    ((Transform) this.TransitionLayer).SetParent(CanvasTransform, false);
    RectTransform transitionLayer = this.TransitionLayer;
    Vector2 zero = Vector2.zero;
    this.TransitionLayer.anchorMin = zero;
    Vector2 vector2 = zero;
    transitionLayer.sizeDelta = vector2;
    this.TransitionLayer.anchorMax = Vector2.one;
  }

  public void UpdateRun()
  {
    this.UpDateDV();
    this.UpDateStateFade();
    this.UpDateBloodBarPos();
    this.UpDateBloodBarWidth();
    this.UpDateTransitions();
    this.UpDateBoss();
  }

  public void BeginFightInitial()
  {
    this.PlayerCount = 10;
    this.EnemyCount = 20;
    this.bc = GameManager.ActiveGameplay as BattleController;
    this.InitialDamageValueManager();
    this.InitialBloodBar();
    this.ResetDV();
    this.ResetBloodBar();
  }

  public void BeginWarInitial()
  {
    this.PlayerCount = 17;
    this.EnemyCount = 17;
    this.wm = GameManager.ActiveGameplay as WarManager;
    this.InitialBloodBar();
    this.ResetBloodBar();
  }

  public void NextFightStage()
  {
    this.ResetDV();
    this.ResetBloodBar(false);
    this.ResetState();
  }

  public void NextWar() => this.ResetBloodBar();

  public void EndFightClear()
  {
    this.bc = (BattleController) null;
    this.ResetDV();
    this.ResetBloodBar();
    this.DeleteDamageValue();
    this.DeleteBloodBar();
  }

  public void EndWarClear()
  {
    this.wm = (WarManager) null;
    this.ResetBloodBar();
    this.DeleteBloodBar();
  }

  public void RebuiltFont()
  {
    if (!((UnityEngine.Object) this.BossObj != (UnityEngine.Object) null) || !((UnityEngine.Object) this.BossText != (UnityEngine.Object) null) || !((Behaviour) this.BossText).enabled)
      return;
    ((Behaviour) this.BossText).enabled = false;
    ((Behaviour) this.BossText).enabled = true;
  }

  public void InitialDamageValueManager()
  {
    GameObject original1 = new GameObject(this.GOName);
    RectTransform rectTransform1 = original1.AddComponent<RectTransform>();
    UIText uiText1 = original1.AddComponent<UIText>();
    rectTransform1.sizeDelta = this.m_Vec2;
    uiText1.alignment = TextAnchor.MiddleCenter;
    uiText1.font = this.DamageValueFont;
    uiText1.fontSize = 0;
    ((MaskableGraphic) uiText1).material = this.DamageValueFont.material;
    uiText1.horizontalOverflow = (HorizontalWrapMode) 1;
    DamageValue damageValue1 = new DamageValue();
    damageValue1.m_GameObject = original1;
    damageValue1.m_transform = original1.transform;
    damageValue1.m_Text = uiText1;
    damageValue1.m_RT = rectTransform1;
    damageValue1.m_GameObject.SetActive(false);
    damageValue1.m_GameObject.transform.SetParent((Transform) this.DamageValueLayer_Num, false);
    this.EmptyDVStack_Num.Push(damageValue1);
    for (int index = 1; index < 60; ++index)
    {
      DamageValue damageValue2 = new DamageValue();
      damageValue2.m_GameObject = UnityEngine.Object.Instantiate((UnityEngine.Object) original1) as GameObject;
      damageValue2.m_GameObject.name = original1.name;
      damageValue2.m_transform = damageValue2.m_GameObject.transform;
      damageValue2.m_Text = damageValue2.m_GameObject.GetComponent<UIText>();
      damageValue2.m_RT = damageValue2.m_GameObject.GetComponent<RectTransform>();
      damageValue2.m_GameObject.transform.SetParent((Transform) this.DamageValueLayer_Num, false);
      damageValue2.m_GameObject.SetActive(false);
      this.EmptyDVStack_Num.Push(damageValue2);
    }
    GameObject original2 = new GameObject(this.GOName);
    RectTransform rectTransform2 = original2.AddComponent<RectTransform>();
    UIText uiText2 = original2.AddComponent<UIText>();
    rectTransform2.sizeDelta = this.m_Vec2;
    uiText2.alignment = TextAnchor.MiddleCenter;
    uiText2.font = GUIManager.Instance.GetTTFFont();
    uiText2.fontSize = 48;
    uiText2.horizontalOverflow = (HorizontalWrapMode) 1;
    Outline outline = original2.AddComponent<Outline>();
    ((Shadow) outline).effectColor = new Color(0.0f, 0.0f, 0.0f, 1f);
    ((Shadow) outline).effectDistance = new Vector2(2f, 2f);
    DamageValue damageValue3 = new DamageValue();
    damageValue3.m_GameObject = original2;
    damageValue3.m_transform = original2.transform;
    damageValue3.m_Text = uiText2;
    damageValue3.m_RT = rectTransform2;
    damageValue3.m_GameObject.SetActive(false);
    damageValue3.m_GameObject.transform.SetParent((Transform) this.DamageValueLayer_Word, false);
    this.EmptyDVStack_Word.Push(damageValue3);
    for (int index = 1; index < 20; ++index)
    {
      DamageValue damageValue4 = new DamageValue();
      damageValue4.m_GameObject = UnityEngine.Object.Instantiate((UnityEngine.Object) original2) as GameObject;
      damageValue4.m_GameObject.name = original2.name;
      damageValue4.m_transform = damageValue4.m_GameObject.transform;
      damageValue4.m_Text = damageValue4.m_GameObject.GetComponent<UIText>();
      damageValue4.m_RT = damageValue4.m_GameObject.GetComponent<RectTransform>();
      damageValue4.m_GameObject.transform.SetParent((Transform) this.DamageValueLayer_Word, false);
      damageValue4.m_GameObject.SetActive(false);
      this.EmptyDVStack_Word.Push(damageValue4);
    }
  }

  private void DeleteDamageValue()
  {
    DamageValue damageValue1;
    for (int index = 0; index < 20; ++index)
    {
      DamageValue damageValue2 = this.EmptyDVStack_Word.Pop();
      if (damageValue2 != null)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) damageValue2.m_GameObject);
        damageValue2.m_GameObject = (GameObject) null;
        damageValue2.m_transform = (Transform) null;
        damageValue2.m_Text = (UIText) null;
        damageValue2.m_RT = (RectTransform) null;
        damageValue1 = (DamageValue) null;
      }
    }
    for (int index = 0; index < 60; ++index)
    {
      DamageValue damageValue3 = this.EmptyDVStack_Num.Pop();
      if (damageValue3 != null)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) damageValue3.m_GameObject);
        damageValue3.m_GameObject = (GameObject) null;
        damageValue3.m_transform = (Transform) null;
        damageValue3.m_Text = (UIText) null;
        damageValue3.m_RT = (RectTransform) null;
        damageValue1 = (DamageValue) null;
      }
    }
  }

  private bool CheckisNumber(HERO_EFFECTTYPE_ENUM Type)
  {
    bool flag = true;
    switch (Type)
    {
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_DODGE:
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_IMM:
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_PHYSIMM:
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_MAGIIMM:
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_IMM_BUFF:
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_PHYSIMM_BUFF:
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_MAGIIMM_BUFF:
        flag = false;
        break;
    }
    return flag;
  }

  private bool CheckisCritical(HERO_EFFECTTYPE_ENUM Type)
  {
    bool flag = false;
    switch (Type)
    {
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_CIR:
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_RECOVER_CIR:
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_DOT_CIR:
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_HOT_CIR:
        flag = true;
        break;
    }
    return flag;
  }

  private void UpDateDV()
  {
    float deltaTime = Time.deltaTime;
    float y = deltaTime * 150f;
    for (int index = this.DVList.Count - 1; index >= 0; --index)
    {
      this.DVList[index].fTime += deltaTime;
      if ((double) this.DVList[index].fTime >= (double) this.DVList[index].fShowTime)
      {
        this.ClearDV(index);
      }
      else
      {
        bool isArabic = GUIManager.Instance.IsArabic;
        if (isArabic && (double) ((Transform) this.DVList[index].m_RT).localScale.x < 0.0)
          ((Transform) this.DVList[index].m_RT).localScale = new Vector3(-((Transform) this.DVList[index].m_RT).localScale.x, ((Transform) this.DVList[index].m_RT).localScale.y, ((Transform) this.DVList[index].m_RT).localScale.z);
        if (this.DVList[index].bNumber)
        {
          if (this.DVList[index].bCritical)
          {
            if ((double) this.DVList[index].fTime <= 0.20000000298023224)
            {
              float num = 8.5f;
              this.m_Vec3.x = ((Transform) this.DVList[index].m_RT).localScale.x + deltaTime * num;
              this.m_Vec3.y = ((Transform) this.DVList[index].m_RT).localScale.y + deltaTime * num;
              this.m_Vec3.z = ((Transform) this.DVList[index].m_RT).localScale.z + deltaTime * num;
              ((Transform) this.DVList[index].m_RT).localScale = this.m_Vec3;
            }
            else if ((double) this.DVList[index].fTime > 0.20000000298023224 && (double) this.DVList[index].fTime <= 0.40000000596046448)
            {
              float num = 8.5f;
              this.m_Vec3.x = ((Transform) this.DVList[index].m_RT).localScale.x - deltaTime * num;
              this.m_Vec3.y = ((Transform) this.DVList[index].m_RT).localScale.y - deltaTime * num;
              this.m_Vec3.z = ((Transform) this.DVList[index].m_RT).localScale.z - deltaTime * num;
              ((Transform) this.DVList[index].m_RT).localScale = this.m_Vec3;
            }
            else
            {
              ((Transform) this.DVList[index].m_RT).localScale = Vector3.one * this.DVScaleN * this.DVScale;
              this.DVList[index].m_transform.localPosition += new Vector3(0.0f, y, 0.0f);
            }
            if ((double) ((Transform) this.DVList[index].m_RT).localScale.x < 0.0)
              ((Transform) this.DVList[index].m_RT).localScale = Vector3.one * this.DVScaleN * this.DVScale;
          }
          else if (this.DVList[index].Type == HERO_EFFECTTYPE_ENUM.HERO_EFFECT_DAMAGE)
          {
            if ((double) this.moveDelta == -1.0)
              this.moveDelta = this.CanvasRT.sizeDelta.x * 1.1f;
            if ((double) this.DVList[index].fTime <= 0.059999998658895493)
            {
              this.m_Vec3.x = this.DVList[index].side != (byte) 0 ? ((Transform) this.DVList[index].m_RT).localPosition.x + deltaTime * this.moveDelta : ((Transform) this.DVList[index].m_RT).localPosition.x - deltaTime * this.moveDelta;
              this.m_Vec3.y = ((Transform) this.DVList[index].m_RT).localPosition.y;
              this.m_Vec3.z = ((Transform) this.DVList[index].m_RT).localPosition.z;
              ((Transform) this.DVList[index].m_RT).localPosition = this.m_Vec3;
            }
            else if ((double) this.DVList[index].fTime >= 0.059999998658895493 && (double) this.DVList[index].fTime <= 0.11999999731779099)
            {
              this.m_Vec3.x = this.DVList[index].side != (byte) 0 ? ((Transform) this.DVList[index].m_RT).localPosition.x - deltaTime * this.moveDelta : ((Transform) this.DVList[index].m_RT).localPosition.x + deltaTime * this.moveDelta;
              this.m_Vec3.y = ((Transform) this.DVList[index].m_RT).localPosition.y;
              this.m_Vec3.z = ((Transform) this.DVList[index].m_RT).localPosition.z;
              ((Transform) this.DVList[index].m_RT).localPosition = this.m_Vec3;
            }
            this.DVList[index].m_transform.localPosition += new Vector3(0.0f, y, 0.0f);
          }
          if (this.DVList[index].Type == HERO_EFFECTTYPE_ENUM.HERO_EFFECT_DOT || this.DVList[index].Type == HERO_EFFECTTYPE_ENUM.HERO_EFFECT_HOT)
            this.DVList[index].m_transform.localPosition += new Vector3(0.0f, y, 0.0f);
          if ((double) this.DVList[index].fTime >= (double) this.DVList[index].fShowTime * 0.30000001192092896)
          {
            Color color = ((Graphic) this.DVList[index].m_Text).color;
            color.a -= Time.deltaTime * 2f;
            ((Graphic) this.DVList[index].m_Text).color = color;
          }
        }
        else
        {
          this.DVList[index].m_transform.localPosition += new Vector3(0.0f, y, 0.0f);
          if ((double) this.DVList[index].fTime >= (double) this.DVList[index].fShowTime * 0.800000011920929)
          {
            Color color = ((Graphic) this.DVList[index].m_Text).color;
            color.a -= Time.deltaTime * 2f;
            ((Graphic) this.DVList[index].m_Text).color = color;
          }
        }
        if (isArabic && (double) ((Transform) this.DVList[index].m_RT).localScale.x < 0.0)
          ((Transform) this.DVList[index].m_RT).localScale = new Vector3(-((Transform) this.DVList[index].m_RT).localScale.x, ((Transform) this.DVList[index].m_RT).localScale.y, ((Transform) this.DVList[index].m_RT).localScale.z);
      }
    }
  }

  public void ResetDV()
  {
    for (int i = this.DVList.Count - 1; i >= 0; --i)
      this.ClearDV(i);
  }

  private void ClearDV(int i)
  {
    this.DVList[i].m_GameObject.SetActive(false);
    this.DVList[i].fTime = 0.0f;
    this.DVList[i].iOffset = 0;
    this.DVList[i].side = (byte) 0;
    this.DVList[i].fShowTime = 0.0f;
    this.DVList[i].m_transform.SetParent((Transform) this.DamageValueLayer_Num, false);
    if (this.DVList[i].bNumber)
      this.EmptyDVStack_Num.Push(this.DVList[i]);
    else
      this.EmptyDVStack_Word.Push(this.DVList[i]);
    this.DVList.RemoveAt(i);
  }

  public void AddDamageValueEffect(
    uint iValue,
    int Side,
    int iIndex,
    HERO_EFFECTTYPE_ENUM Type,
    int iOffset = 0)
  {
    // ISSUE: unable to decompile the method.
  }

  private void InitialBloodBar()
  {
    Transform child1 = ((Transform) this.baseLayer).GetChild(0);
    AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/PlayerBar", out this.AssetKey_Bar);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return;
    UnityEngine.Object[] objectArray = assetBundle.LoadAll(typeof (Sprite));
    for (int index = 0; index < objectArray.Length; ++index)
    {
      if (objectArray[index].name[0] >= '0' && objectArray[index].name[0] <= '9')
        this.m_Dict.Add(ushort.Parse(objectArray[index].name), (Sprite) objectArray[index]);
    }
    for (int index1 = 0; index1 < 2; ++index1)
    {
      List<BloodBar> bloodBarList;
      string name;
      int num;
      if (index1 == 0)
      {
        bloodBarList = this.Player;
        name = this.PlayerName;
        num = this.PlayerCount;
      }
      else
      {
        bloodBarList = this.Enemy;
        name = this.EnemyName;
        num = this.EnemyCount;
      }
      GameObject original = UnityEngine.Object.Instantiate(assetBundle.Load(name)) as GameObject;
      original.name = name;
      original.transform.SetParent(child1, false);
      BloodBar bloodBar1 = new BloodBar();
      bloodBar1.m_GameObject = original;
      bloodBar1.m_transform = original.transform;
      bloodBar1.m_RT = original.GetComponent<RectTransform>();
      bloodBar1.m_BarTransform = original.transform.GetChild(0);
      bloodBar1.m_IconTransform = original.transform.GetChild(1);
      bloodBar1.m_BarTransform.gameObject.SetActive(false);
      if (this.wm != null && index1 == 0)
        bloodBar1.m_BarTransform.GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(1);
      for (int index2 = 0; index2 < 3; ++index2)
      {
        Transform child2 = bloodBar1.m_BarTransform.GetChild(index2);
        bloodBar1.m_BarRT[index2] = child2.GetComponent<RectTransform>();
        bloodBar1.m_BarImg[index2] = child2.GetComponent<Image>();
        Transform child3 = bloodBar1.m_IconTransform.GetChild(index2);
        bloodBar1.m_IconRT[index2] = child3.GetComponent<RectTransform>();
        bloodBar1.m_IconImg[index2] = child3.GetComponent<Image>();
        child3.gameObject.SetActive(false);
      }
      if (this.wm != null)
      {
        bloodBar1.m_BarRT[0].offsetMin = new Vector2(8f, 3f);
        bloodBar1.m_BarRT[0].offsetMax = new Vector2(-8f, -3f);
        bloodBar1.m_BarRT[1].offsetMin = new Vector2(10f, 5f);
        bloodBar1.m_BarRT[1].offsetMax = new Vector2(72f, -5f);
        bloodBar1.m_BarRT[2].offsetMin = new Vector2(10f, 5f);
        bloodBar1.m_BarRT[2].offsetMax = new Vector2(72f, -5f);
      }
      this.m_Vec3.Set(0.6f, 0.6f, 0.6f);
      ((Transform) bloodBar1.m_RT).localScale = this.m_Vec3;
      bloodBarList.Add(bloodBar1);
      for (int index3 = 1; index3 < num; ++index3)
      {
        BloodBar bloodBar2 = new BloodBar();
        bloodBar2.m_GameObject = UnityEngine.Object.Instantiate((UnityEngine.Object) original) as GameObject;
        bloodBar2.m_GameObject.name = name;
        bloodBar2.m_GameObject.transform.SetParent(child1, false);
        bloodBar2.m_transform = bloodBar2.m_GameObject.transform;
        bloodBar2.m_RT = bloodBar2.m_GameObject.GetComponent<RectTransform>();
        bloodBar2.m_BarTransform = bloodBar2.m_GameObject.transform.GetChild(0);
        bloodBar2.m_IconTransform = bloodBar2.m_GameObject.transform.GetChild(1);
        bloodBar2.m_BarTransform.gameObject.SetActive(false);
        for (int index4 = 0; index4 < 3; ++index4)
        {
          Transform child4 = bloodBar2.m_BarTransform.GetChild(index4);
          bloodBar2.m_BarRT[index4] = child4.GetComponent<RectTransform>();
          bloodBar2.m_BarImg[index4] = child4.GetComponent<Image>();
          Transform child5 = bloodBar2.m_IconTransform.GetChild(index4);
          bloodBar2.m_IconRT[index4] = child5.GetComponent<RectTransform>();
          bloodBar2.m_IconImg[index4] = child5.GetComponent<Image>();
          child5.gameObject.SetActive(false);
        }
        if (this.wm != null && index3 == num - 1)
        {
          ((RectTransform) bloodBar2.m_BarTransform).sizeDelta = new Vector2(136f, 20f);
          bloodBar2.m_BarRT[0].offsetMin = new Vector2(0.0f, 0.0f);
          bloodBar2.m_BarRT[0].offsetMax = new Vector2(0.0f, 0.0f);
          bloodBar2.m_BarRT[1].offsetMin = new Vector2(4f, 3f);
          bloodBar2.m_BarRT[1].offsetMax = new Vector2(132f, -3f);
          bloodBar2.m_BarRT[2].offsetMin = new Vector2(4f, 3f);
          bloodBar2.m_BarRT[2].offsetMax = new Vector2(132f, -3f);
        }
        bloodBarList.Add(bloodBar2);
      }
    }
  }

  private void DeleteBloodBar()
  {
    for (int index1 = this.PlayerCount - 1; index1 >= 0; --index1)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.Player[index1].m_GameObject);
      this.Player[index1].m_GameObject = (GameObject) null;
      this.Player[index1].m_transform = (Transform) null;
      this.Player[index1].m_RT = (RectTransform) null;
      this.Player[index1].m_BarTransform = (Transform) null;
      this.Player[index1].m_IconTransform = (Transform) null;
      for (int index2 = 0; index2 < 3; ++index2)
      {
        this.Player[index1].m_BarRT[index2] = (RectTransform) null;
        this.Player[index1].m_BarImg[index2] = (Image) null;
        this.Player[index1].m_IconRT[index2] = (RectTransform) null;
        this.Player[index1].m_IconImg[index2] = (Image) null;
      }
      this.Player.RemoveAt(index1);
    }
    for (int index3 = this.EnemyCount - 1; index3 >= 0; --index3)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.Enemy[index3].m_GameObject);
      this.Enemy[index3].m_GameObject = (GameObject) null;
      this.Enemy[index3].m_transform = (Transform) null;
      this.Enemy[index3].m_RT = (RectTransform) null;
      this.Enemy[index3].m_BarTransform = (Transform) null;
      this.Enemy[index3].m_IconTransform = (Transform) null;
      for (int index4 = 0; index4 < 3; ++index4)
      {
        this.Enemy[index3].m_BarRT[index4] = (RectTransform) null;
        this.Enemy[index3].m_BarImg[index4] = (Image) null;
        this.Enemy[index3].m_IconRT[index4] = (RectTransform) null;
        this.Enemy[index3].m_IconImg[index4] = (Image) null;
      }
      this.Enemy.RemoveAt(index3);
    }
    this.m_Dict.Clear();
  }

  private void UpDateBloodBarPos()
  {
    float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
    if (this.bc != null)
    {
      for (int index1 = 0; index1 < 2; ++index1)
      {
        List<BloodBar> bloodBarList;
        AnimationUnit[] animationUnitArray;
        int num1;
        int num2;
        if (index1 == 0)
        {
          bloodBarList = this.Player;
          animationUnitArray = this.bc.playerUnit;
          num1 = this.bc.playerCount;
          num2 = this.PlayerCount;
        }
        else
        {
          bloodBarList = this.Enemy;
          animationUnitArray = this.bc.enemyUnit;
          num1 = this.bc.enemyCount;
          num2 = this.EnemyCount;
        }
        for (int index2 = 0; index2 < num2 && index2 < num1; ++index2)
        {
          if (!((UnityEngine.Object) animationUnitArray[index2] == (UnityEngine.Object) null) && (bloodBarList[index2].bShow || bloodBarList[index2].bShowState))
          {
            this.m_Vec3.x = 0.0f;
            this.m_Vec3.y = animationUnitArray[index2].BoundingHight;
            this.m_Vec3.z = 0.0f;
            Vector3 vector3 = Camera.main.WorldToScreenPoint(animationUnitArray[index2].Position + this.m_Vec3) / scaleFactor;
            bloodBarList[index2].m_RT.anchoredPosition = (Vector2) vector3;
          }
        }
      }
    }
    else
    {
      if (this.wm == null)
        return;
      for (int index3 = 0; index3 < 2; ++index3)
      {
        List<BloodBar> bloodBarList;
        int num3;
        int num4;
        if (index3 == 0)
        {
          bloodBarList = this.Player;
          num3 = (int) this.wm.playerCount;
          num4 = this.PlayerCount;
        }
        else
        {
          bloodBarList = this.Enemy;
          num3 = (int) this.wm.enemyCount;
          num4 = this.EnemyCount;
        }
        for (int index4 = 0; index4 < num4; ++index4)
        {
          Vector3 vector3_1;
          if (index4 < num3)
          {
            if (index3 == 0)
            {
              if (this.wm.playerSideArmies[index4] != null)
                vector3_1 = this.wm.playerSideArmies[index4].GetBloodBarPos();
              else
                continue;
            }
            else if (this.wm.enemySideArmies[index4] != null)
              vector3_1 = this.wm.enemySideArmies[index4].GetBloodBarPos();
            else
              continue;
          }
          else if (index4 == 16)
          {
            if (index3 == 0)
            {
              if (this.wm.playerSideArmies[index4] != null)
                vector3_1 = this.wm.playerSideArmies[16].groupRoot.position + this.wm.CastleBloodBarOffset;
              else
                continue;
            }
            else if (this.wm.enemySideArmies[index4] != null)
              vector3_1 = this.wm.enemySideArmies[16].groupRoot.position + this.wm.CastleBloodBarOffset;
            else
              continue;
          }
          else
            continue;
          if (bloodBarList[index4].bShow || bloodBarList[index4].bShowState)
          {
            this.m_Vec3.x = 0.0f;
            this.m_Vec3.y = 5f;
            this.m_Vec3.z = 0.0f;
            Vector3 vector3_2 = vector3_1;
            vector3_2 = Camera.main.WorldToScreenPoint(vector3_2 + this.m_Vec3);
            vector3_2 /= scaleFactor;
            bloodBarList[index4].m_RT.anchoredPosition = index4 != 16 ? (Vector2) vector3_2 : new Vector2((float) (int) vector3_2.x, (float) (int) vector3_2.y);
          }
        }
      }
    }
  }

  private void UpDateBloodBarWidth()
  {
    if (this.bc == null && this.wm == null)
      return;
    float deltaTime = Time.deltaTime;
    for (int index1 = 0; index1 < 2; ++index1)
    {
      List<BloodBar> bloodBarList;
      int num1;
      if (index1 == 0)
      {
        bloodBarList = this.Player;
        num1 = this.PlayerCount;
      }
      else
      {
        bloodBarList = this.Enemy;
        num1 = this.EnemyCount;
      }
      for (int index2 = 0; index2 < num1; ++index2)
      {
        if (bloodBarList[index2].bShow && !bloodBarList[index2].bForceShowBlood)
        {
          bloodBarList[index2].fTime -= deltaTime;
          if ((double) bloodBarList[index2].fTime <= 0.800000011920929 || (double) bloodBarList[index2].m_BarImg[1].fillAmount <= 0.0)
          {
            float num2 = deltaTime * 5f;
            Color color1 = ((Graphic) bloodBarList[index2].m_BarImg[0]).color;
            color1.a -= num2;
            if ((double) color1.a <= 0.0)
            {
              Color color2 = ((Graphic) bloodBarList[index2].m_BarImg[1]).color;
              Color color3 = ((Graphic) bloodBarList[index2].m_BarImg[2]).color;
              color1.a = 1f;
              color2.a = 1f;
              color3.a = 1f;
              ((Graphic) bloodBarList[index2].m_BarImg[0]).color = color1;
              ((Graphic) bloodBarList[index2].m_BarImg[1]).color = color2;
              ((Graphic) bloodBarList[index2].m_BarImg[2]).color = color3;
              bloodBarList[index2].m_BarImg[1].fillAmount = bloodBarList[index2].TargetWidth;
              bloodBarList[index2].m_BarTransform.gameObject.SetActive(false);
              bloodBarList[index2].bShow = false;
              continue;
            }
            Color color4 = ((Graphic) bloodBarList[index2].m_BarImg[1]).color;
            Color color5 = ((Graphic) bloodBarList[index2].m_BarImg[2]).color;
            color4.a = color1.a;
            color5.a = color1.a;
            ((Graphic) bloodBarList[index2].m_BarImg[0]).color = color1;
            ((Graphic) bloodBarList[index2].m_BarImg[1]).color = color4;
            ((Graphic) bloodBarList[index2].m_BarImg[2]).color = color5;
          }
          bloodBarList[index2].m_BarImg[1].fillAmount -= bloodBarList[index2].DeltaX;
          if ((double) bloodBarList[index2].DeltaX >= 0.0 && (double) bloodBarList[index2].m_BarImg[1].fillAmount <= (double) bloodBarList[index2].TargetWidth || (double) bloodBarList[index2].DeltaX <= 0.0 && (double) bloodBarList[index2].m_BarImg[1].fillAmount >= (double) bloodBarList[index2].TargetWidth)
            bloodBarList[index2].m_BarImg[1].fillAmount = bloodBarList[index2].TargetWidth;
        }
      }
    }
  }

  public void OpenBloodShow(int side, int iIndex)
  {
    float num1 = 0.0f;
    List<BloodBar> bloodBarList;
    float maxHp;
    float curHp;
    if (this.bc != null)
    {
      if (this.bc.BattleType == EBattleType.PLAYBACK && side == 1)
        return;
      BattleController.HeroAttr[] heroAttrArray;
      int num2;
      if (side == 0)
      {
        bloodBarList = this.Player;
        heroAttrArray = this.bc.playerAttr;
        num2 = this.PlayerCount;
      }
      else
      {
        bloodBarList = this.Enemy;
        heroAttrArray = this.bc.enemyAttr;
        num2 = this.EnemyCount;
      }
      if (iIndex < 0 || iIndex >= num2)
        return;
      maxHp = (float) heroAttrArray[iIndex].MAX_HP;
      curHp = (float) heroAttrArray[iIndex].CUR_HP;
    }
    else
    {
      if (this.wm == null)
        return;
      if (side == 0)
      {
        bloodBarList = this.Player;
        int playerCount = this.PlayerCount;
        if (iIndex < 0 || iIndex >= playerCount)
          return;
        maxHp = (float) this.wm.playerSideArmies[iIndex].MaxHP;
        curHp = (float) this.wm.playerSideArmies[iIndex].CurHP;
      }
      else
      {
        bloodBarList = this.Enemy;
        int enemyCount = this.EnemyCount;
        if (iIndex < 0 || iIndex >= enemyCount)
          return;
        maxHp = (float) this.wm.enemySideArmies[iIndex].MaxHP;
        curHp = (float) this.wm.enemySideArmies[iIndex].CurHP;
      }
      num1 = 2f;
    }
    if ((double) bloodBarList[iIndex].TargetWidth <= 0.0)
      return;
    bloodBarList[iIndex].TargetWidth = (double) maxHp <= 0.0 || (double) maxHp <= (double) curHp ? 1f : curHp / maxHp;
    bloodBarList[iIndex].DeltaX = (double) bloodBarList[iIndex].m_BarImg[1].fillAmount <= (double) bloodBarList[iIndex].TargetWidth ? 0.0f : (float) (((double) bloodBarList[iIndex].m_BarImg[1].fillAmount - (double) bloodBarList[iIndex].TargetWidth) * 0.050000004470348358);
    bloodBarList[iIndex].m_BarImg[2].fillAmount = bloodBarList[iIndex].TargetWidth;
    bloodBarList[iIndex].m_BarTransform.gameObject.SetActive(true);
    bloodBarList[iIndex].bShow = true;
    bloodBarList[iIndex].bForceShowBlood = false;
    bloodBarList[iIndex].fTime = 2.3f + num1;
    Color color1 = ((Graphic) bloodBarList[iIndex].m_BarImg[0]).color;
    Color color2 = ((Graphic) bloodBarList[iIndex].m_BarImg[1]).color;
    Color color3 = ((Graphic) bloodBarList[iIndex].m_BarImg[2]).color;
    color1.a = 1f;
    color2.a = 1f;
    color3.a = 1f;
    ((Graphic) bloodBarList[iIndex].m_BarImg[0]).color = color1;
    ((Graphic) bloodBarList[iIndex].m_BarImg[1]).color = color2;
    ((Graphic) bloodBarList[iIndex].m_BarImg[2]).color = color3;
    this.UpDateBloodBarPos();
  }

  private void ResetBloodBar(bool bResetPlayer = true)
  {
    for (int index = 0; index < this.Player.Count; ++index)
    {
      if (bResetPlayer)
      {
        this.Player[index].TargetWidth = 1f;
        this.Player[index].m_BarImg[1].fillAmount = 1f;
        this.Player[index].m_BarImg[2].fillAmount = 1f;
      }
      this.Player[index].m_BarTransform.gameObject.SetActive(false);
      this.Player[index].bShow = false;
      this.Player[index].bForceShowBlood = false;
    }
    for (int index = 0; index < this.Enemy.Count; ++index)
    {
      this.Enemy[index].TargetWidth = 1f;
      this.Enemy[index].m_BarImg[1].fillAmount = 1f;
      this.Enemy[index].m_BarImg[2].fillAmount = 1f;
      this.Enemy[index].m_BarTransform.gameObject.SetActive(false);
      this.Enemy[index].bShow = false;
      this.Enemy[index].bForceShowBlood = false;
    }
  }

  public void ShowBloodBar(int side, int iIndex)
  {
    if (this.bc == null)
      return;
    List<BloodBar> bloodBarList;
    BattleController.HeroAttr[] heroAttrArray;
    int num;
    AnimationUnit[] animationUnitArray;
    if (side == 0)
    {
      bloodBarList = this.Player;
      heroAttrArray = this.bc.playerAttr;
      num = this.PlayerCount;
      animationUnitArray = this.bc.playerUnit;
    }
    else
    {
      bloodBarList = this.Enemy;
      heroAttrArray = this.bc.enemyAttr;
      num = this.EnemyCount;
      animationUnitArray = this.bc.enemyUnit;
    }
    if (iIndex < 0 || iIndex >= num || (double) bloodBarList[iIndex].TargetWidth <= 0.0)
      return;
    float maxHp = (float) heroAttrArray[iIndex].MAX_HP;
    float curHp = (float) heroAttrArray[iIndex].CUR_HP;
    bloodBarList[iIndex].TargetWidth = (double) maxHp <= 0.0 || (double) maxHp <= (double) curHp ? 1f : curHp / maxHp;
    bloodBarList[iIndex].DeltaX = (double) bloodBarList[iIndex].m_BarImg[1].fillAmount <= (double) bloodBarList[iIndex].TargetWidth ? 0.0f : (float) (((double) bloodBarList[iIndex].m_BarImg[1].fillAmount - (double) bloodBarList[iIndex].TargetWidth) * 0.050000004470348358);
    bloodBarList[iIndex].m_BarImg[2].fillAmount = bloodBarList[iIndex].TargetWidth;
    bloodBarList[iIndex].m_BarTransform.gameObject.SetActive(true);
    bloodBarList[iIndex].bForceShowBlood = true;
    Color color1 = ((Graphic) bloodBarList[iIndex].m_BarImg[0]).color;
    Color color2 = ((Graphic) bloodBarList[iIndex].m_BarImg[1]).color;
    Color color3 = ((Graphic) bloodBarList[iIndex].m_BarImg[2]).color;
    color1.a = 1f;
    color2.a = 1f;
    color3.a = 1f;
    ((Graphic) bloodBarList[iIndex].m_BarImg[0]).color = color1;
    ((Graphic) bloodBarList[iIndex].m_BarImg[1]).color = color2;
    ((Graphic) bloodBarList[iIndex].m_BarImg[2]).color = color3;
    this.m_Vec3.x = 0.0f;
    this.m_Vec3.y = animationUnitArray[iIndex].BoundingHight;
    this.m_Vec3.z = 0.0f;
    Vector3 vector3 = Camera.main.WorldToScreenPoint(animationUnitArray[iIndex].Position + this.m_Vec3) / GUIManager.Instance.m_UICanvas.scaleFactor;
    bloodBarList[iIndex].m_RT.anchoredPosition = (Vector2) vector3;
  }

  public void HideBloodBar(int side, int iIndex)
  {
    if (side == 0)
    {
      if (iIndex < 0 || iIndex >= this.PlayerCount)
        return;
      this.Player[iIndex].m_BarTransform.gameObject.SetActive(false);
      this.Player[iIndex].bForceShowBlood = false;
    }
    else
    {
      if (iIndex < 0 || iIndex >= this.EnemyCount)
        return;
      this.Enemy[iIndex].m_BarTransform.gameObject.SetActive(false);
      this.Enemy[iIndex].bForceShowBlood = false;
    }
  }

  public void SetBloodBarFillAmount(int side, int iIndex, float fillAmount)
  {
    if (side == 0)
    {
      if (iIndex < 0 || iIndex >= this.PlayerCount)
        return;
      this.Player[iIndex].TargetWidth = fillAmount;
      this.Player[iIndex].m_BarImg[1].fillAmount = fillAmount;
      this.Player[iIndex].m_BarImg[2].fillAmount = fillAmount;
    }
    else
    {
      if (iIndex < 0 || iIndex >= this.EnemyCount)
        return;
      this.Enemy[iIndex].TargetWidth = fillAmount;
      this.Enemy[iIndex].m_BarImg[1].fillAmount = fillAmount;
      this.Enemy[iIndex].m_BarImg[2].fillAmount = fillAmount;
    }
  }

  private void UpDateStateFade()
  {
    if (this.bc == null)
      return;
    float num1 = Time.smoothDeltaTime * 4f;
    for (int index1 = 0; index1 < 2; ++index1)
    {
      List<BloodBar> bloodBarList;
      int num2;
      if (index1 == 0)
      {
        bloodBarList = this.Player;
        num2 = this.PlayerCount;
      }
      else
      {
        bloodBarList = this.Enemy;
        num2 = this.EnemyCount;
      }
      for (int index2 = 0; index2 < num2; ++index2)
      {
        for (int index3 = 0; index3 < 3; ++index3)
        {
          if (bloodBarList[index2].FadeNum[index3] != 0)
          {
            Image image = bloodBarList[index2].m_IconImg[index3];
            ((Graphic) image).color = ((Graphic) image).color + new Color(0.0f, 0.0f, 0.0f, num1 * (float) bloodBarList[index2].FadeNum[index3]);
            if (bloodBarList[index2].FadeNum[index3] == 1 && (double) ((Graphic) bloodBarList[index2].m_IconImg[index3]).color.a >= 1.0)
            {
              bloodBarList[index2].FadeNum[index3] = 0;
              ((Graphic) bloodBarList[index2].m_IconImg[index3]).color = Color.white;
            }
            if (bloodBarList[index2].FadeNum[index3] == -1 && (double) ((Graphic) bloodBarList[index2].m_IconImg[index3]).color.a <= 0.0)
            {
              bloodBarList[index2].FadeNum[index3] = 0;
              ((Graphic) bloodBarList[index2].m_IconImg[index3]).color = Color.white;
              ((Component) bloodBarList[index2].m_IconRT[index3]).gameObject.SetActive(false);
            }
          }
        }
      }
    }
  }

  public void CheckBuffIcon(byte HeroOrEnemy, byte HEIndex)
  {
    if (this.bc == null || BattleController.IsGambleMode)
      return;
    List<BloodBar> bloodBarList;
    AnimationUnit[] animationUnitArray;
    int num;
    if (HeroOrEnemy == (byte) 0)
    {
      bloodBarList = this.Player;
      animationUnitArray = this.bc.playerUnit;
      num = this.PlayerCount;
    }
    else
    {
      bloodBarList = this.Enemy;
      animationUnitArray = this.bc.enemyUnit;
      num = this.EnemyCount;
    }
    if ((int) HEIndex >= num)
      return;
    int count = animationUnitArray[(int) HEIndex].StateEffList.Count;
    for (int index1 = 0; index1 < 3; ++index1)
    {
      if (index1 < count)
      {
        Sprite sprite = (Sprite) null;
        byte stateEff = animationUnitArray[(int) HEIndex].StateEffList[index1];
        if (stateEff > (byte) 0 && stateEff <= (byte) 6)
        {
          this.m_Dict.TryGetValue((ushort) ((uint) stateEff + 300U), out sprite);
        }
        else
        {
          this.m_Dict.TryGetValue(DataManager.Instance.EffectData.GetRecordByKey((ushort) ((uint) stateEff - 6U)).StatusIcon, out sprite);
          if ((UnityEngine.Object) sprite == (UnityEngine.Object) null)
          {
            if (stateEff > (byte) 1 && stateEff <= (byte) 100)
              this.m_Dict.TryGetValue((ushort) 254, out sprite);
            else if (stateEff > (byte) 100 && stateEff <= (byte) 200)
              this.m_Dict.TryGetValue((ushort) byte.MaxValue, out sprite);
          }
        }
        ((Component) bloodBarList[(int) HEIndex].m_IconRT[index1]).gameObject.SetActive(true);
        bloodBarList[(int) HEIndex].m_IconImg[index1].sprite = sprite;
        if (bloodBarList[(int) HEIndex].StateID[index1] == (byte) 0)
        {
          ((Graphic) bloodBarList[(int) HEIndex].m_IconImg[index1]).color = new Color(1f, 1f, 1f, 0.0f);
          bloodBarList[(int) HEIndex].FadeNum[index1] = 1;
        }
        bloodBarList[(int) HEIndex].StateID[index1] = stateEff;
      }
      else
      {
        bool flag = false;
        for (int index2 = 0; index2 < index1; ++index2)
        {
          if ((int) bloodBarList[(int) HEIndex].StateID[index1] == (int) bloodBarList[(int) HEIndex].StateID[index2])
            flag = true;
        }
        if (!flag)
        {
          bloodBarList[(int) HEIndex].FadeNum[index1] = -1;
          bloodBarList[(int) HEIndex].StateID[index1] = (byte) 0;
        }
        else
          ((Component) bloodBarList[(int) HEIndex].m_IconRT[index1]).gameObject.SetActive(false);
      }
    }
    if (count > 0)
    {
      float x = 0.0f;
      for (int index = 0; index < 3; ++index)
      {
        bloodBarList[(int) HEIndex].m_IconRT[index].sizeDelta = new Vector2(36f, 36f);
        bloodBarList[(int) HEIndex].m_IconRT[index].anchoredPosition = new Vector2(x, -10f);
        x += 38f;
      }
      bloodBarList[(int) HEIndex].bShowState = true;
    }
    else
      bloodBarList[(int) HEIndex].bShowState = false;
  }

  private void ResetState()
  {
    for (int index1 = 0; index1 < 2; ++index1)
    {
      List<BloodBar> bloodBarList = index1 != 0 ? this.Enemy : this.Player;
      for (int index2 = 0; index2 < bloodBarList.Count; ++index2)
      {
        for (int index3 = 0; index3 < 3; ++index3)
        {
          ((Graphic) bloodBarList[index2].m_IconImg[index3]).color = Color.white;
          bloodBarList[index2].FadeNum[index3] = 0;
          ((Component) bloodBarList[index2].m_IconRT[index3]).gameObject.SetActive(false);
        }
      }
    }
  }

  public void NextTransitions(eTrans kind, eTransFunc FKind = eTransFunc.Max)
  {
    switch (kind)
    {
      case eTrans.BEGIN:
        if (this.NowFuncKind != eTransFunc.Max)
          break;
        if (NewbieManager.IsNewbie)
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Front, 4);
        GUIManager.Instance.ShowUILock(EUILock.Normal);
        GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Transition);
        if (FKind == eTransFunc.MapToWar)
          DataManager.Instance.WorldCameraTransitionsPos = GameConstants.GoldGuy;
        this.NowFuncKind = FKind;
        this.InitialTransition();
        this.BeginTransitions(true);
        if (!((Component) GUIManager.Instance.m_ItemInfo.m_RectTransform).gameObject.activeSelf)
          break;
        GUIManager.Instance.m_ItemInfo.Hide();
        break;
      case eTrans.END:
        if (NewbieManager.IsNewbie)
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Front, 5);
        if (this.bTranstions != (byte) 3)
          break;
        this.BeginTransitions(false);
        break;
      case eTrans.FORCEEND:
        this.EndTransitions();
        break;
    }
  }

  private void TransitionFunc()
  {
    switch (this.NowFuncKind)
    {
      case eTransFunc.Battle:
        if (this.bc != null)
        {
          this.bc.NextLevel();
          break;
        }
        break;
      case eTransFunc.MapToBattle:
      case eTransFunc.WarToBattle:
      case eTransFunc.MonsterBattle:
      case eTransFunc.GambleBattle:
        GameManager.SwitchGameplay(GameplayKind.Battle);
        GUIManager.Instance.SetBattleMessageButton(false);
        break;
      case eTransFunc.BattleToMap:
        GUIManager.Instance.OpenABColor();
        GUIManager.Instance.m_UICanvas.renderMode = (RenderMode) 0;
        GUIManager.Instance.SetCanvasChanged();
        GameManager.SwitchGameplay(DataManager.Instance.GoToBattleOrWar);
        GUIManager.Instance.SetBattleMessageButton(true);
        break;
      case eTransFunc.NextStage:
        DataManager.msgBuffer[0] = (byte) 5;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_StageSelect, 0);
        break;
      case eTransFunc.PrevStage:
        DataManager.msgBuffer[0] = (byte) 6;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_StageSelect, 0);
        break;
      case eTransFunc.ChangeStage:
        DataManager.msgBuffer[0] = (byte) 35;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_StageSelect, 0);
        break;
      case eTransFunc.ChangeToKing:
        DataManager.StageDataController.ReBackCurrentChapter();
        NewbieManager.EntryLock = true;
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 2);
        NewbieManager.EntryLock = false;
        break;
      case eTransFunc.ChangeToMap:
        DataManager.MapDataController.ClearLayoutMapInfoYolkKind();
        DataManager.StageDataController.ReBackCurrentChapter();
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 3);
        break;
      case eTransFunc.ChangeToWorld:
        DataManager.MapDataController.ClearLayoutMapInfoYolkKind();
        DataManager.StageDataController.ReBackCurrentChapter();
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 4);
        break;
      case eTransFunc.BattleReplay:
      case eTransFunc.BattleReplay_Dare:
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_Settlement);
        GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle).gameObject.SetActive(true);
        if (this.bc != null)
        {
          this.bc.ResetLevel();
          break;
        }
        break;
      case eTransFunc.BattleReplay_Force:
        if (this.bc != null)
        {
          this.bc.ResetLevel();
          break;
        }
        break;
      case eTransFunc.WarToMap:
        GUIManager.Instance.OpenABColor();
        GUIManager.Instance.m_UICanvas.renderMode = (RenderMode) 0;
        GUIManager.Instance.SetCanvasChanged();
        GameManager.SwitchGameplay(DataManager.Instance.GoToBattleOrWar);
        GUIManager.Instance.SetBattleMessageButton(true);
        break;
      case eTransFunc.MapToWar:
      case eTransFunc.MapToWar_Stage:
      case eTransFunc.MapToWar_CoordTest:
        WarManager.WarKind = this.NowFuncKind != eTransFunc.MapToWar_CoordTest ? WarManager.EWarKind.Normal : WarManager.EWarKind.CoordTest;
        GameManager.SwitchGameplay(GameplayKind.War);
        GUIManager.Instance.SetBattleMessageButton(false);
        break;
      case eTransFunc.DoorOpenUp:
        DataManager.msgBuffer[0] = (byte) 40;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
      case eTransFunc.DoorWild:
        DataManager.msgBuffer[0] = (byte) 21;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
      case eTransFunc.GambleSwitchMode:
        if (this.bc != null)
        {
          this.bc.ResetGamble();
          break;
        }
        break;
    }
    DataManager.Instance.UpdateMailData();
  }

  private void TransitionBeginFunc()
  {
    switch (this.NowFuncKind)
    {
      case eTransFunc.Battle:
        if (this.bc == null || this.bc.m_CurStageLevel != this.bc.m_MaxStageLevel - 1)
          break;
        this.bNeedShowBoss = true;
        break;
      case eTransFunc.MapToBattle:
      case eTransFunc.WarToBattle:
      case eTransFunc.MonsterBattle:
      case eTransFunc.GambleBattle:
        AudioManager.Instance.LoadAndPlayBGM(BGMType.War, (byte) 1);
        break;
      case eTransFunc.BattleToMap:
        GUIManager.Instance.BattleCloseChatBox();
        break;
      case eTransFunc.Test:
        this.bBossTest = true;
        this.bNeedShowBoss = true;
        break;
    }
  }

  private void TransitionEndFunc()
  {
    switch (this.NowFuncKind)
    {
      case eTransFunc.Battle:
        this.BeginMoveBossText();
        break;
      case eTransFunc.BattleToMap:
        DataManager.msgBuffer[0] = (byte) 22;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        if (BattleNetwork.NetworkError != (byte) 0)
        {
          BattleNetwork.NetworkError = (byte) 0;
          GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4834U), DataManager.Instance.mStringTable.GetStringByID(114U), DataManager.Instance.mStringTable.GetStringByID(4836U));
        }
        GUIManager.Instance.CheckSuggestion();
        GUIManager.Instance.RestoreQueuedUI();
        if (GamblingManager.Instance.bOpenTreasure != (byte) 1)
          break;
        GamblingManager.Instance.bOpenTreasure = (byte) 0;
        MallManager.Instance.Send_Mall_Info();
        break;
      case eTransFunc.NextStage:
        DataManager.msgBuffer[0] = (byte) 22;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
      case eTransFunc.ChangeStage:
        DataManager.msgBuffer[0] = (byte) 22;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        if (!NewbieManager.IsTeachWorking(ETeachKind.DARE_FULL))
          break;
        NewbieManager.CheckTeach(ETeachKind.DARE_FULL);
        break;
      case eTransFunc.ChangeToKing:
        Camera.main.cullingMask |= 1;
        NewbieManager.CheckWorldTeach();
        break;
      case eTransFunc.ChangeToMap:
        Indemnify.CheckShowIndemnify();
        ActivityGiftManager.Instance.CheckShowActivityGiftEffect();
        break;
      case eTransFunc.ChangeToWorld:
        Camera.main.cullingMask |= 1;
        break;
      case eTransFunc.WarToMap:
      case eTransFunc.MapToWar_Stage:
        if (DataManager.StageDataController._stageMode == StageMode.Corps)
        {
          DataManager.msgBuffer[0] = (byte) 22;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
        GUIManager.Instance.RestoreQueuedUI();
        break;
      case eTransFunc.DoorOpenUp:
        DataManager.msgBuffer[0] = (byte) 22;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        if (!NewbieManager.IsTeachWorking(ETeachKind.DARE_FULL))
          break;
        NewbieManager.CheckTeach(ETeachKind.DARE_FULL);
        break;
      case eTransFunc.DoorWild:
        NewbieManager.EntryTest();
        Indemnify.CheckShowIndemnify();
        ActivityGiftManager.Instance.CheckShowActivityGiftEffect();
        break;
      case eTransFunc.Test:
        this.BeginMoveBossText();
        break;
    }
  }

  private void UpDateTransitions()
  {
    if (this.NowFuncKind == eTransFunc.Max || (UnityEngine.Object) this.CanvasRT == (UnityEngine.Object) null || (UnityEngine.Object) this.TRT1 == (UnityEngine.Object) null)
      return;
    float unscaledDeltaTime = Time.unscaledDeltaTime;
    if (this.bTranstions != (byte) 0)
      this.fTransitionsTime += unscaledDeltaTime;
    if (this.bTranstions == (byte) 2 && (this.bAxeOutNew || this.bCastleOutNew))
      this.dTime += unscaledDeltaTime;
    if ((double) this.fTransitionsTime < 0.032999999821186066)
      return;
    this.fTransitionsTime = 0.0f;
    if (this.NowTransKind == eTransKind.WhiteScaleAxe)
    {
      if (this.bTranstions == (byte) 1)
      {
        if (this.bAxeInNew)
        {
          this.nowSize -= this.DeltaSize;
          this.setMsize();
          if ((double) this.nowSize > (double) this.sizeMin)
            return;
          this.nowSize = this.sizeMin;
          this.setMsize();
          this.bTranstions = (byte) 3;
          this.TransitionFunc();
        }
        else
        {
          float num = this.TransitionsSpeed * 6f;
          if ((double) ((Transform) this.TRT1).localScale.x <= 10.0)
            num *= 0.5f;
          this.m_Vec3.Set(num, num, num);
          RectTransform trT1 = this.TRT1;
          ((Transform) trT1).localScale = ((Transform) trT1).localScale + this.m_Vec3;
          if ((double) ((Graphic) this.TImage).color.a < 1.0)
          {
            this.m_Color = ((Graphic) this.TImage).color;
            this.m_Color.a += (float) ((double) num * 4.0 / (double) byte.MaxValue);
            if ((double) this.m_Color.a >= 1.0)
              ((Graphic) this.TImage).color = Color.white;
            else
              ((Graphic) this.TImage).color = this.m_Color;
          }
          if ((double) ((Transform) this.TRT1).localScale.x * 10.0 <= (double) this.CanvasRT.sizeDelta.x)
            return;
          this.bTranstions = (byte) 3;
          this.TransitionFunc();
        }
      }
      else
      {
        if (this.bTranstions != (byte) 2)
          return;
        if (this.bAxeOutNew)
        {
          this.nowSize = this.GetScale(this.dTime, this.sizeMin, this.sizeMax - this.sizeMin, 1f);
          this.setMsize();
          if ((double) this.nowSize < (double) this.sizeMax)
            return;
          this.EndTransitions();
        }
        else
        {
          float num = this.TransitionsSpeed * 4f;
          if ((double) ((Transform) this.TRT1).localScale.x <= 10.0)
            num *= 0.5f;
          this.m_Vec3.Set(-num, -num, -num);
          RectTransform trT1 = this.TRT1;
          ((Transform) trT1).localScale = ((Transform) trT1).localScale + this.m_Vec3;
          if ((double) ((Transform) this.TRT1).localScale.x > 0.0)
            return;
          this.EndTransitions();
        }
      }
    }
    else if (this.NowTransKind == eTransKind.WhiteScaleCastle)
    {
      if (this.bTranstions == (byte) 1)
      {
        if (this.bCastleInNew)
        {
          this.nowSize -= this.DeltaSize;
          this.setMsize();
          if ((double) this.nowSize > (double) this.sizeMin)
            return;
          this.nowSize = this.sizeMin;
          this.setMsize();
          this.bTranstions = (byte) 3;
          this.TransitionFunc();
        }
        else
        {
          float num = this.TransitionsSpeed * 8f;
          if ((double) ((Transform) this.TRT1).localScale.x <= 10.0)
            num *= 0.5f;
          this.m_Vec3.Set(num, num, num);
          RectTransform trT1 = this.TRT1;
          ((Transform) trT1).localScale = ((Transform) trT1).localScale + this.m_Vec3;
          if ((double) ((Transform) this.TRT1).localScale.x * 6.0 <= (double) this.CanvasRT.sizeDelta.y)
            return;
          this.bTranstions = (byte) 3;
          this.TransitionFunc();
        }
      }
      else
      {
        if (this.bTranstions != (byte) 2)
          return;
        if (this.bCastleOutNew)
        {
          this.nowSize = this.GetScale(this.dTime, this.sizeMin, this.sizeMax - this.sizeMin, 1f);
          this.setMsize();
          if ((double) this.nowSize < (double) this.sizeMax)
            return;
          this.EndTransitions();
        }
        else
        {
          float num = this.TransitionsSpeed * 5f;
          if ((double) ((Transform) this.TRT1).localScale.x > 5.0 && (double) ((Transform) this.TRT1).localScale.x <= 20.0)
            num *= 0.5f;
          else if ((double) ((Transform) this.TRT1).localScale.x <= 5.0)
            num *= 0.2f;
          this.m_Vec3.Set(-num, -num, -num);
          RectTransform trT1 = this.TRT1;
          ((Transform) trT1).localScale = ((Transform) trT1).localScale + this.m_Vec3;
          if ((double) ((Transform) this.TRT1).localScale.x > 0.0)
            return;
          this.EndTransitions();
        }
      }
    }
    else if (this.NowTransKind == eTransKind.HalfClose)
    {
      this.dTime += 0.033f;
      if (this.bTranstions == (byte) 1)
      {
        float z = (float) (315.0 + (double) DamageValueManager.easeOutCubic(0.0f, 1f, this.dTime / this.HalfTotalTime) * 45.0);
        ((Transform) this.TRT4).localEulerAngles = new Vector3(0.0f, 0.0f, z);
        ((Transform) this.TRT5).localEulerAngles = new Vector3(0.0f, 0.0f, z);
        if ((double) this.dTime < (double) this.HalfTotalTime)
          return;
        this.bTranstions = (byte) 3;
        this.TransitionFunc();
      }
      else
      {
        if (this.bTranstions != (byte) 2)
          return;
        float num1 = DamageValueManager.easeInCubic(0.0f, 1f, this.dTime / this.HalfTotalTime);
        float num2 = this.CanvasRT.sizeDelta.y / 2f;
        float new_y = num2 * num1;
        this.m_Vec3.Set(num2 - 1f, new_y, 0.0f);
        this.TRT4.anchoredPosition = (Vector2) this.m_Vec3;
        this.m_Vec3.Set((float) (-(double) num2 + 1.0), -new_y, 0.0f);
        this.TRT5.anchoredPosition = (Vector2) this.m_Vec3;
        float num3 = DamageValueManager.easeInExpo(0.0f, 1f, this.dTime / this.HalfTotalTime);
        Color color = ((Graphic) this.HalfImageTop).color with
        {
          a = 1f - num3
        };
        ((Graphic) this.HalfImageTop).color = color;
        ((Graphic) this.HalfImageBottom).color = color;
        if ((double) this.dTime < (double) this.HalfTotalTime)
          return;
        this.EndTransitions();
      }
    }
    else if (this.bTranstions == (byte) 1)
    {
      this.TransitionsWidth = this.CanvasRT.sizeDelta.x;
      this.m_Vec2.x = this.TRT1.sizeDelta.x + this.TransitionsSpeed;
      this.m_Vec2.y = this.TRT1.sizeDelta.y;
      this.TRT1.sizeDelta = this.m_Vec2;
      float num = this.TransitionsWidth + this.TransitionsDeltaX * 2f;
      if (this.bNeedShowBoss && (double) this.m_Vec2.x >= (double) num * 0.6600000262260437)
      {
        this.ShowBossText(this.bBossTest);
        this.bNeedShowBoss = false;
        this.bBossTest = false;
      }
      if ((double) this.m_Vec2.x < (double) num)
        return;
      this.m_Vec2.x = num;
      this.m_Vec2.y = this.TRT1.sizeDelta.y;
      this.TRT1.sizeDelta = this.m_Vec2;
      this.bTranstions = (byte) 3;
      this.TransitionFunc();
    }
    else
    {
      if (this.bTranstions != (byte) 2)
        return;
      this.m_Vec2.x = this.TRT1.sizeDelta.x - this.TransitionsSpeed;
      this.m_Vec2.y = this.TRT1.sizeDelta.y;
      this.TRT1.sizeDelta = this.m_Vec2;
      if ((double) this.m_Vec2.x > 0.0)
        return;
      this.EndTransitions();
    }
  }

  private void InitialTransition()
  {
    GUIManager instance = GUIManager.Instance;
    this.LoadTransition1();
    this.LoadTransition2();
    if ((UnityEngine.Object) this.TransitionsGO1 == (UnityEngine.Object) null || (UnityEngine.Object) this.TransitionsGO2 == (UnityEngine.Object) null)
      return;
    this.NowTransKind = this.NowFuncKind == eTransFunc.MapToBattle || this.NowFuncKind == eTransFunc.BattleReplay || this.NowFuncKind == eTransFunc.MapToWar || this.NowFuncKind == eTransFunc.DoorOpenUp || this.NowFuncKind == eTransFunc.MapToWar_Stage || this.NowFuncKind == eTransFunc.MapToWar_CoordTest || this.NowFuncKind == eTransFunc.WarToBattle || this.NowFuncKind == eTransFunc.MonsterBattle || this.NowFuncKind == eTransFunc.GambleBattle ? eTransKind.WhiteScaleAxe : (this.NowFuncKind == eTransFunc.BattleToMap || this.NowFuncKind == eTransFunc.WarToMap || this.NowFuncKind == eTransFunc.DoorWild ? eTransKind.WhiteScaleCastle : (this.NowFuncKind == eTransFunc.ChangeToMap || this.NowFuncKind == eTransFunc.ChangeToKing || this.NowFuncKind == eTransFunc.ChangeToWorld ? eTransKind.HalfClose : eTransKind.Normal));
    if (this.NowTransKind == eTransKind.WhiteScaleAxe)
    {
      this.TransitionsSpeed = 1f;
      this.TransitionsWidth = this.CanvasRT.sizeDelta.x;
      this.m_Vec2.Set(0.5f, 0.5f);
      this.TRT1.anchorMin = this.m_Vec2;
      this.TRT1.anchorMax = this.m_Vec2;
      this.TRT1.pivot = this.m_Vec2;
      this.m_Vec2.Set(128f, 128f);
      this.TRT1.sizeDelta = this.m_Vec2;
      this.m_Vec3.Set(0.0f, 0.0f, this.TransitionsZ);
      this.TRT1.anchoredPosition = (Vector2) this.m_Vec3;
      ((Transform) this.TRT1).localPosition = this.m_Vec3;
      ((Transform) this.TRT1).localScale = Vector3.one;
      this.TImage.sprite = instance.LoadSprite("Transitions1", "mark02");
      this.TImage.type = (Image.Type) 0;
    }
    else if (this.NowTransKind == eTransKind.WhiteScaleCastle)
    {
      this.TransitionsSpeed = 1f;
      this.TransitionsWidth = this.CanvasRT.sizeDelta.x;
      this.m_Vec2.Set(0.5f, 0.5f);
      this.TRT1.anchorMin = this.m_Vec2;
      this.TRT1.anchorMax = this.m_Vec2;
      this.TRT1.pivot = this.m_Vec2;
      this.m_Vec2.Set(128f, 128f);
      this.TRT1.sizeDelta = this.m_Vec2;
      this.m_Vec3.Set(0.0f, 0.0f, this.TransitionsZ);
      this.TRT1.anchoredPosition = (Vector2) this.m_Vec3;
      ((Transform) this.TRT1).localPosition = this.m_Vec3;
      ((Transform) this.TRT1).localScale = Vector3.one;
      this.TImage.sprite = instance.LoadSprite("Transitions1", "mark03");
      this.TImage.type = (Image.Type) 0;
    }
    else if (this.NowTransKind == eTransKind.HalfClose)
    {
      this.TRT4.anchorMin = Vector2.one;
      this.TRT4.anchorMax = Vector2.one;
      this.TRT4.pivot = Vector2.one;
      float new_x = this.CanvasRT.sizeDelta.y / 2f;
      this.m_Vec2.Set(this.CanvasRT.sizeDelta.x + new_x, new_x * 1.2f);
      this.TRT4.sizeDelta = this.m_Vec2;
      this.m_Vec3.Set(new_x, 0.0f, 0.0f);
      this.TRT4.anchoredPosition = (Vector2) this.m_Vec3;
      ((Transform) this.TRT4).localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
      ((Graphic) this.HalfImageTop).color = Color.white;
      this.TRT5.anchorMin = Vector2.zero;
      this.TRT5.anchorMax = Vector2.zero;
      this.TRT5.pivot = Vector2.zero;
      this.m_Vec2.Set(this.CanvasRT.sizeDelta.x + new_x, new_x * 1.2f);
      this.TRT5.sizeDelta = this.m_Vec2;
      this.m_Vec3.Set(-new_x, 0.0f, 0.0f);
      this.TRT5.anchoredPosition = (Vector2) this.m_Vec3;
      ((Transform) this.TRT5).localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
      ((Graphic) this.HalfImageBottom).color = Color.white;
    }
    else
    {
      this.TransitionsSpeed = 100f;
      this.TransitionsDeltaX = 379f;
      this.TransitionsWidth = this.CanvasRT.sizeDelta.x;
      this.m_Vec2.Set(0.0f, 0.0f);
      this.TRT1.anchorMin = this.m_Vec2;
      this.m_Vec2.Set(0.0f, 1f);
      this.TRT1.anchorMax = this.m_Vec2;
      this.m_Vec2.Set(0.0f, 0.5f);
      this.TRT1.pivot = this.m_Vec2;
      this.m_Vec2.Set(0.0f, this.TRT1.sizeDelta.y);
      this.TRT1.sizeDelta = this.m_Vec2;
      this.m_Vec3.Set(-this.TransitionsDeltaX, 0.0f, this.TransitionsZ);
      this.TRT1.anchoredPosition = (Vector2) this.m_Vec3;
      ((Transform) this.TRT1).localPosition = this.m_Vec3;
      ((Transform) this.TRT1).localScale = Vector3.one;
      this.TImage.sprite = instance.LoadSprite("Transitions1", "mark01");
      this.TImage.type = (Image.Type) 1;
      this.TImage.fillCenter = true;
    }
  }

  public void BeginTransitions(bool bBeginClose)
  {
    if ((double) ((Transform) this.TransitionLayer).localScale.x != 1.0)
      ((Transform) this.TransitionLayer).localScale = Vector3.one;
    if (bBeginClose)
    {
      this.TransitionBeginFunc();
      this.bTranstions = (byte) 1;
      if (this.NowTransKind == eTransKind.WhiteScaleCastle)
      {
        if (this.bCastleInNew)
        {
          this.nowSize = this.sizeMax;
          this.setMsize();
          this.TransitionsGO3.SetActive(true);
        }
        else
        {
          ((Transform) this.TRT1).localScale = new Vector3(0.5f, 0.5f, 0.5f);
          this.TransitionsGO1.SetActive(true);
        }
      }
      else if (this.NowTransKind == eTransKind.WhiteScaleAxe)
      {
        if (this.bAxeInNew)
        {
          this.nowSize = this.sizeMax;
          this.setMsize();
          this.TransitionsGO2.SetActive(true);
        }
        else
        {
          ((Transform) this.TRT1).localScale = Vector3.one;
          if (this.NowFuncKind == eTransFunc.MapToBattle)
            this.m_Vec3.Set(this.FightBeginPos.x, this.FightBeginPos.y, this.TransitionsZ);
          else
            this.m_Vec3.Set(0.0f, 0.0f, this.TransitionsZ);
          this.TRT1.anchoredPosition = (Vector2) this.m_Vec3;
          ((Transform) this.TRT1).localPosition = this.m_Vec3;
          this.m_Color = Color.white;
          this.m_Color.a = 0.3f;
          ((Graphic) this.TImage).color = this.m_Color;
          this.TransitionsGO1.SetActive(true);
        }
      }
      else if (this.NowTransKind == eTransKind.HalfClose)
      {
        this.dTime = 0.0f;
        float num = this.CanvasRT.sizeDelta.y / 2f;
        this.m_Vec3.Set(num - 1f, 10f, 0.0f);
        this.TRT4.anchoredPosition = (Vector2) this.m_Vec3;
        this.m_Vec3.Set((float) (-(double) num + 1.0), -10f, 0.0f);
        this.TRT5.anchoredPosition = (Vector2) this.m_Vec3;
        ((Transform) this.TRT4).localRotation = new Quaternion(0.0f, 0.0f, 315f, 0.0f);
        ((Transform) this.TRT5).localRotation = new Quaternion(0.0f, 0.0f, 315f, 0.0f);
        ((Graphic) this.HalfImageTop).color = Color.white;
        ((Graphic) this.HalfImageBottom).color = Color.white;
        this.TransitionsGO4.SetActive(true);
        this.TransitionsGO5.SetActive(true);
      }
      else
      {
        ((Transform) this.TRT1).localRotation = this.Quaternion1;
        this.m_Vec3.Set(-this.TransitionsDeltaX, 0.0f, this.TransitionsZ);
        this.TRT1.anchoredPosition = (Vector2) this.m_Vec3;
        this.m_Vec3.Set(((Transform) this.TRT1).localPosition.x, 0.0f, this.TransitionsZ);
        ((Transform) this.TRT1).localPosition = this.m_Vec3;
        this.m_Vec2.Set(0.0f, this.TRT1.sizeDelta.y);
        this.TRT1.sizeDelta = this.m_Vec2;
        this.TransitionsGO1.SetActive(true);
      }
    }
    else
    {
      this.bTranstions = (byte) 2;
      if (this.NowTransKind == eTransKind.WhiteScaleCastle)
      {
        if (this.bCastleOutNew)
        {
          this.dTime = 0.0f;
          this.nowSize = this.sizeMin;
          this.setMsize();
          this.TransitionsGO3.SetActive(true);
          if (this.bCastleInNew)
            return;
          this.TransitionsGO1.SetActive(false);
        }
        else
        {
          this.m_Vec3.Set(0.0f, 0.0f, this.TransitionsZ);
          this.TRT1.anchoredPosition = (Vector2) this.m_Vec3;
          ((Transform) this.TRT1).localPosition = this.m_Vec3;
          float num = this.CanvasRT.sizeDelta.y / 6f;
          this.m_Vec3.Set(num, num, num);
          ((Transform) this.TRT1).localScale = this.m_Vec3;
          this.TransitionsGO1.SetActive(true);
          if (!this.bCastleInNew)
            return;
          this.TransitionsGO3.SetActive(false);
        }
      }
      else if (this.NowTransKind == eTransKind.WhiteScaleAxe)
      {
        if (this.bAxeOutNew)
        {
          this.dTime = 0.0f;
          this.nowSize = this.sizeMin;
          this.setMsize();
          this.TransitionsGO2.SetActive(true);
          if (this.bAxeInNew)
            return;
          this.TransitionsGO1.SetActive(false);
        }
        else
        {
          this.m_Vec3.Set(0.0f, 0.0f, this.TransitionsZ);
          this.TRT1.anchoredPosition = (Vector2) this.m_Vec3;
          ((Transform) this.TRT1).localPosition = this.m_Vec3;
          float num = this.CanvasRT.sizeDelta.y / 10f;
          this.m_Vec3.Set(num, num, num);
          ((Transform) this.TRT1).localScale = this.m_Vec3;
          this.TransitionsGO1.SetActive(true);
          if (this.bAxeInNew)
            this.TransitionsGO2.SetActive(false);
          if (this.NowFuncKind != eTransFunc.DoorOpenUp)
            return;
          GUIManager.Instance.m_HUDMessage.MapHud.AddChapterMsg();
          GUIManager.Instance.m_HUDMessage.MapHud.ShowMsg();
          GUIManager.Instance.m_HUDMessage.MapHud.ShowTime = 1.3f;
          GUIManager.Instance.m_HUDMessage.MapHud.StartCountdown();
        }
      }
      else if (this.NowTransKind == eTransKind.HalfClose)
      {
        this.dTime = 0.0f;
        float num = this.CanvasRT.sizeDelta.y / 2f;
        this.m_Vec3.Set(num - 1f, 10f, 0.0f);
        this.TRT4.anchoredPosition = (Vector2) this.m_Vec3;
        this.m_Vec3.Set((float) (-(double) num + 1.0), -10f, 0.0f);
        this.TRT5.anchoredPosition = (Vector2) this.m_Vec3;
        ((Transform) this.TRT4).localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        ((Transform) this.TRT5).localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        ((Graphic) this.HalfImageTop).color = Color.white;
        ((Graphic) this.HalfImageBottom).color = Color.white;
        this.TransitionsGO4.SetActive(true);
        this.TransitionsGO5.SetActive(true);
        if (this.NowFuncKind == eTransFunc.Battle || this.NowFuncKind == eTransFunc.BattleReplay_Force || this.NowFuncKind == eTransFunc.BattleReplay_Dare)
          return;
        GUIManager.Instance.m_HUDMessage.MapHud.ShowMsg();
      }
      else
      {
        ((Transform) this.TRT1).localRotation = this.Quaternion2;
        this.m_Vec3.Set(this.TransitionsWidth + this.TransitionsDeltaX, 0.0f, this.TransitionsZ);
        this.TRT1.anchoredPosition = (Vector2) this.m_Vec3;
        this.m_Vec3.Set(((Transform) this.TRT1).localPosition.x, 0.0f, this.TransitionsZ);
        ((Transform) this.TRT1).localPosition = this.m_Vec3;
        this.m_Vec2.Set(this.TransitionsWidth + this.TransitionsDeltaX * 2f, this.TRT1.sizeDelta.y);
        this.TRT1.sizeDelta = this.m_Vec2;
        this.TransitionsGO1.SetActive(true);
        if (this.NowFuncKind == eTransFunc.Battle || this.NowFuncKind == eTransFunc.BattleReplay_Force || this.NowFuncKind == eTransFunc.BattleReplay_Dare)
          return;
        GUIManager.Instance.m_HUDMessage.MapHud.ShowMsg();
      }
    }
  }

  public void EndTransitions()
  {
    this.TransitionEndFunc();
    if (this.NowTransKind == eTransKind.HalfClose)
    {
      this.TransitionsGO4.SetActive(false);
      this.TransitionsGO5.SetActive(false);
    }
    else if (this.NowTransKind == eTransKind.WhiteScaleAxe)
      this.TransitionsGO2.SetActive(false);
    else if (this.NowTransKind == eTransKind.WhiteScaleCastle)
      this.TransitionsGO3.SetActive(false);
    if (this.TransitionsGO1.activeInHierarchy)
      this.TransitionsGO1.SetActive(false);
    this.bTranstions = (byte) 0;
    this.NowFuncKind = eTransFunc.Max;
    this.NowTransKind = eTransKind.Normal;
    GUIManager.Instance.m_HUDMessage.MapHud.StartCountdown();
    GUIManager.Instance.HideUILock(EUILock.Normal);
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Transition);
  }

  private void setMsize()
  {
    if (this.NowTransKind == eTransKind.WhiteScaleCastle)
    {
      float x = 1f / this.nowSize;
      float y = 1f / this.nowSize;
      this.m_Castle.mainTextureScale = new Vector2(x, y);
      this.m_Castle.mainTextureOffset = new Vector2((float) (0.5 - 0.5 * (double) x), (float) (0.550000011920929 - 0.5 * (double) y));
    }
    else
    {
      if (this.NowTransKind != eTransKind.WhiteScaleAxe)
        return;
      float x = 1f / this.nowSize;
      float y = 1f / this.nowSize;
      this.m_Axe.mainTextureScale = new Vector2(x, y);
      this.m_Axe.mainTextureOffset = new Vector2((float) (0.5 - 0.5 * (double) x), (float) (0.5 - 0.5 * (double) y));
    }
  }

  private void LoadTransition1()
  {
    if (!((UnityEngine.Object) this.TransitionsGO1 == (UnityEngine.Object) null))
      return;
    this.m_A8 = GUIManager.Instance.AddSpriteAsset(this.TransNameStr);
    this.TransitionsGO1 = new GameObject("Transitions1");
    this.TransitionsGO1.transform.SetParent((Transform) this.TransitionLayer, false);
    this.TRT1 = this.TransitionsGO1.AddComponent<RectTransform>();
    this.TImage = this.TransitionsGO1.AddComponent<Image>();
    ((MaskableGraphic) this.TImage).material = this.m_A8;
    this.TransitionsGO4 = new GameObject("Transitions4");
    this.TransitionsGO4.transform.SetParent((Transform) this.TransitionLayer, false);
    this.TRT4 = this.TransitionsGO4.AddComponent<RectTransform>();
    this.HalfImageTop = this.TransitionsGO4.AddComponent<Image>();
    ((MaskableGraphic) this.HalfImageTop).material = this.m_A8;
    this.HalfImageTop.sprite = GUIManager.Instance.LoadSprite(this.TransNameStr, "black_gogo");
    this.HalfImageTop.type = (Image.Type) 1;
    this.TransitionsGO5 = new GameObject("Transitions5");
    this.TransitionsGO5.transform.SetParent((Transform) this.TransitionLayer, false);
    this.TRT5 = this.TransitionsGO5.AddComponent<RectTransform>();
    this.HalfImageBottom = this.TransitionsGO5.AddComponent<Image>();
    ((MaskableGraphic) this.HalfImageBottom).material = this.m_A8;
    this.HalfImageBottom.sprite = GUIManager.Instance.LoadSprite(this.TransNameStr, "black_gogo_b");
    this.HalfImageBottom.type = (Image.Type) 1;
    AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/Transitions1", out this.AssetKey_Trans1);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return;
    this.BossObj = (GameObject) UnityEngine.Object.Instantiate(assetBundle.mainAsset);
    if ((UnityEngine.Object) this.BossObj != (UnityEngine.Object) null)
    {
      this.BossObj.transform.SetParent((Transform) this.TransitionLayer, false);
      this.BossCG = this.BossObj.transform.GetComponent<CanvasGroup>();
      this.BossImgRC = this.BossObj.transform.GetChild(0).GetComponent<RectTransform>();
      this.BossTextRC = this.BossObj.transform.GetChild(1).GetComponent<RectTransform>();
      this.BossImgRC.sizeDelta = new Vector2(this.CanvasRT.sizeDelta.x + 300f, this.BossImgRC.sizeDelta.y);
      UIText component = ((Component) this.BossTextRC).GetComponent<UIText>();
      component.font = GUIManager.Instance.GetTTFFont();
      component.text = DataManager.Instance.mStringTable.GetStringByID(5910U);
      this.BossObj.SetActive(false);
    }
    this.TransitionsGO1.SetActive(false);
    this.TransitionsGO4.SetActive(false);
    this.TransitionsGO5.SetActive(false);
  }

  private void LoadTransition2()
  {
    if (!((UnityEngine.Object) this.TransitionsGO2 == (UnityEngine.Object) null))
      return;
    AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/Transitions2", out this.AssetKey_Trans);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return;
    float num = this.TransitionsWidth / 256f;
    this.TransitionsGO2 = new GameObject("Transitions2");
    this.TransitionsGO2.transform.SetParent((Transform) this.TransitionLayer, false);
    RectTransform rectTransform1 = this.TransitionsGO2.AddComponent<RectTransform>();
    this.m_Vec2.Set(256f, 256f);
    rectTransform1.sizeDelta = this.m_Vec2;
    this.m_Vec3.Set(0.0f, 0.0f, this.TransitionsZ);
    rectTransform1.anchoredPosition = (Vector2) this.m_Vec3;
    ((Transform) rectTransform1).localPosition = this.m_Vec3;
    this.m_Vec3.Set(num, num, 1f);
    ((Transform) rectTransform1).localScale = this.m_Vec3;
    Image image1 = this.TransitionsGO2.AddComponent<Image>();
    ((MaskableGraphic) image1).material = assetBundle.Load("001_m") as Material;
    this.m_Axe = ((MaskableGraphic) image1).material;
    this.TransitionsGO2.SetActive(false);
    this.TransitionsGO3 = new GameObject("Transitions3");
    this.TransitionsGO3.transform.SetParent((Transform) this.TransitionLayer, false);
    RectTransform rectTransform2 = this.TransitionsGO3.AddComponent<RectTransform>();
    this.m_Vec2.Set(256f, 256f);
    rectTransform2.sizeDelta = this.m_Vec2;
    this.m_Vec3.Set(0.0f, 0.0f, this.TransitionsZ);
    rectTransform2.anchoredPosition = (Vector2) this.m_Vec3;
    ((Transform) rectTransform2).localPosition = this.m_Vec3;
    this.m_Vec3.Set(num, num, 1f);
    ((Transform) rectTransform2).localScale = this.m_Vec3;
    Image image2 = this.TransitionsGO3.AddComponent<Image>();
    ((MaskableGraphic) image2).material = assetBundle.Load("002_m") as Material;
    this.m_Castle = ((MaskableGraphic) image2).material;
    this.TransitionsGO3.SetActive(false);
  }

  public void ShowGodText(bool bTest = false)
  {
    this.LoadTransition1();
    if (!((UnityEngine.Object) this.BossObj != (UnityEngine.Object) null))
      return;
    float num = 1f / ((Transform) this.TransitionLayer).localScale.x;
    this.BossObj.transform.localScale = new Vector3(num, num, num);
    this.BossImgRC.sizeDelta = this.BossImageSize;
    this.BossImgRC.anchoredPosition = this.BossImagePos;
    if (GUIManager.Instance.IsArabic)
      ((Transform) this.BossTextRC).localScale = new Vector3(-1f, 1f, 1f);
    else
      ((Transform) this.BossTextRC).localScale = Vector3.one;
    this.BossTextRC.anchoredPosition = this.BossTextPos;
    this.BossText = ((Component) this.BossTextRC).GetComponent<UIText>();
    this.BossText.text = DataManager.Instance.mStringTable.GetStringByID(9187U);
    this.BossText.resizeTextMinSize = 60;
    ((Graphic) this.BossText).color = this.BossTextColor;
    ((Shadow) ((Component) this.BossTextRC).GetComponent<Outline>()).effectColor = this.BossTextColorOutline;
    ((Component) this.BossTextRC).GetComponent<Shadow>().effectColor = this.BossTextColorShadow;
    this.BossObj.SetActive(true);
    if (bTest)
      this.bShowBoss = true;
    this.BossCG.alpha = 0.0f;
    this.BossFadeDeltaTime = 0.3f;
    this.bBossMoveDown = false;
  }

  public void ShowBossText(bool bTest = false)
  {
    this.LoadTransition1();
    if (!((UnityEngine.Object) this.BossObj != (UnityEngine.Object) null))
      return;
    float num = 1f / ((Transform) this.TransitionLayer).localScale.x;
    this.BossObj.transform.localScale = new Vector3(num, num, num);
    this.BossImgRC.sizeDelta = this.BossImageSize;
    this.BossImgRC.anchoredPosition = this.BossImagePos;
    if (GUIManager.Instance.IsArabic)
      ((Transform) this.BossTextRC).localScale = new Vector3(-1f, 1f, 1f);
    else
      ((Transform) this.BossTextRC).localScale = Vector3.one;
    this.BossTextRC.anchoredPosition = this.BossTextPos;
    this.BossText = ((Component) this.BossTextRC).GetComponent<UIText>();
    this.BossText.text = DataManager.Instance.mStringTable.GetStringByID(5910U);
    this.BossText.resizeTextMinSize = 60;
    ((Graphic) this.BossText).color = this.BossTextColor;
    ((Shadow) ((Component) this.BossTextRC).GetComponent<Outline>()).effectColor = this.BossTextColorOutline;
    ((Component) this.BossTextRC).GetComponent<Shadow>().effectColor = this.BossTextColorShadow;
    this.BossObj.SetActive(true);
    if (bTest)
      this.bShowBoss = true;
    this.BossCG.alpha = 0.0f;
    this.BossFadeDeltaTime = 0.3f;
    this.bBossMoveDown = false;
  }

  public void ShowMallGetItemText(bool bTest = false)
  {
    this.LoadTransition1();
    if (!((UnityEngine.Object) this.BossObj != (UnityEngine.Object) null))
      return;
    float num = 1f / ((Transform) this.TransitionLayer).localScale.x;
    this.BossObj.transform.localScale = new Vector3(num, num, num);
    this.BossImgRC.sizeDelta = this.BossImageSize;
    this.BossImgRC.anchoredPosition = this.BossImagePos;
    if (GUIManager.Instance.IsArabic)
      ((Transform) this.BossTextRC).localScale = new Vector3(-1f, 1f, 1f);
    else
      ((Transform) this.BossTextRC).localScale = Vector3.one;
    this.BossTextRC.anchoredPosition = this.BossTextPos;
    this.BossText = ((Component) this.BossTextRC).GetComponent<UIText>();
    this.BossText.text = DataManager.Instance.mStringTable.GetStringByID(17515U);
    this.BossText.resizeTextMinSize = 40;
    ((Graphic) this.BossText).color = this.BossTextColor;
    ((Shadow) ((Component) this.BossTextRC).GetComponent<Outline>()).effectColor = this.BossTextColorOutline;
    ((Component) this.BossTextRC).GetComponent<Shadow>().effectColor = this.BossTextColorShadow;
    this.BossObj.SetActive(true);
    if (bTest)
      this.bShowBoss = true;
    this.BossCG.alpha = 0.0f;
    this.BossFadeDeltaTime = 0.3f;
    this.bBossMoveDown = false;
  }

  public void ShowCastleStrengthenText(ushort strId, bool bMoveDown)
  {
    this.LoadTransition1();
    if (!((UnityEngine.Object) this.BossObj != (UnityEngine.Object) null))
      return;
    float num = 1f / ((Transform) this.TransitionLayer).localScale.x;
    this.BossObj.transform.localScale = new Vector3(num, num, num);
    this.BossImgRC.sizeDelta = this.BossImageSize;
    this.BossImgRC.anchoredPosition = this.BossImagePos;
    if (GUIManager.Instance.IsArabic)
      ((Transform) this.BossTextRC).localScale = new Vector3(-1f, 1f, 1f);
    else
      ((Transform) this.BossTextRC).localScale = Vector3.one;
    this.BossTextRC.anchoredPosition = this.BossTextPos;
    this.BossText = ((Component) this.BossTextRC).GetComponent<UIText>();
    this.BossText.text = DataManager.Instance.mStringTable.GetStringByID((uint) strId);
    this.BossText.resizeTextMinSize = 60;
    ((Graphic) this.BossText).color = this.BossTextColor;
    ((Shadow) ((Component) this.BossTextRC).GetComponent<Outline>()).effectColor = this.BossTextColorOutline;
    ((Component) this.BossTextRC).GetComponent<Shadow>().effectColor = this.BossTextColorShadow;
    if (GUIManager.Instance.IsArabic)
      ((Transform) this.BossTextRC).localScale = new Vector3(-0.5f, 0.5f, 0.5f);
    else
      ((Transform) this.BossTextRC).localScale = new Vector3(0.5f, 0.5f, 0.5f);
    this.BossImgRC.sizeDelta = new Vector2(this.BossImageSize.x, 80f);
    this.BossImgRC.anchoredPosition = new Vector2(this.BossImagePos.x, -83f);
    if (bMoveDown)
    {
      ((Graphic) this.BossText).color = new Color(0.8235f, 0.8235f, 0.8235f);
      ((Shadow) ((Component) this.BossTextRC).GetComponent<Outline>()).effectColor = new Color(0.588f, 0.588f, 0.588f);
      ((Component) this.BossTextRC).GetComponent<Shadow>().effectColor = new Color(0.431f, 0.431f, 0.431f);
    }
    this.BossObj.SetActive(true);
    this.BossCG.alpha = 0.0f;
    this.BossFadeDeltaTime = 0.3f;
    this.bBossMoveDown = bMoveDown;
  }

  public void BeginMoveBossText()
  {
    if (!((UnityEngine.Object) this.BossObj != (UnityEngine.Object) null))
      return;
    this.bBossMove = true;
    this.BossDeltaTime = 0.0f;
    this.BossMoveDelta = this.CanvasRT.sizeDelta.x + 200f;
    GUIManager.Instance.ShowUILock(EUILock.Normal);
  }

  public void BeginMoveBossText(float mValue)
  {
    if (!((UnityEngine.Object) this.BossObj != (UnityEngine.Object) null))
      return;
    this.bBossMove = true;
    this.BossDeltaTime = 0.0f;
    this.BossMoveDelta = mValue;
    GUIManager.Instance.ShowUILock(EUILock.Normal);
  }

  public void EndMoveBossText()
  {
    if (!((UnityEngine.Object) this.BossObj != (UnityEngine.Object) null))
      return;
    this.BossObj.SetActive(false);
    this.bBossMove = false;
    GUIManager.Instance.HideUILock(EUILock.Normal);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 21);
  }

  private void UpDateBoss()
  {
    if (!((UnityEngine.Object) this.BossObj != (UnityEngine.Object) null))
      return;
    if ((double) this.BossFadeDeltaTime > 0.0)
    {
      this.BossFadeDeltaTime -= Time.smoothDeltaTime;
      if ((double) this.BossFadeDeltaTime <= 0.0 || this.bBossMove)
      {
        this.BossCG.alpha = 1f;
        this.BossFadeDeltaTime = -1f;
      }
      else
        this.BossCG.alpha = 1f - Mathf.Lerp(0.0f, 1f, this.BossFadeDeltaTime / 0.3f);
    }
    if (this.bBossMove)
    {
      if (this.bBossMoveDown)
      {
        this.BossTextRC.anchoredPosition = new Vector2(this.BossTextRC.anchoredPosition.x, this.BossTextPos.y - this.BossMoveDelta * DamageValueManager.easeInBack2(this.BossDeltaTime, 0.0f, 1f, this.BossTotalTime));
        this.BossCG.alpha = 1f - Mathf.Lerp(0.0f, 1f, this.BossDeltaTime / this.BossTotalTime);
      }
      else
      {
        float num = DamageValueManager.easeInBack(0.0f, 1f, this.BossDeltaTime / this.BossTotalTime);
        this.BossImgRC.anchoredPosition = new Vector2(this.BossMoveDelta * num, this.BossImgRC.anchoredPosition.y);
        this.BossTextRC.anchoredPosition = new Vector2((float) -((double) this.BossMoveDelta * (double) num), this.BossTextRC.anchoredPosition.y);
      }
      this.BossDeltaTime += Time.smoothDeltaTime;
      if ((double) this.BossDeltaTime < (double) this.BossTotalTime)
        return;
      this.EndMoveBossText();
    }
    else
    {
      if (!this.bShowBoss)
        return;
      this.ShowBossTime += Time.smoothDeltaTime;
      if ((double) this.ShowBossTime < 1.0)
        return;
      this.NextTransitions(eTrans.END, eTransFunc.Test);
      this.ShowBossTime = 0.0f;
      this.bShowBoss = false;
    }
  }

  public static float easeInExpo(float start, float end, float value)
  {
    end -= start;
    return end * Mathf.Pow(2f, (float) (10.0 * ((double) value / 1.0 - 1.0))) + start;
  }

  public static float easeInCubic(float start, float end, float value)
  {
    end -= start;
    return end * value * value * value + start;
  }

  public static float easeInQuart(float start, float end, float value)
  {
    end -= start;
    return end * value * value * value * value + start;
  }

  public static float easeOutCubic2(float start, float end, float value)
  {
    return end * (float) ((double) --value * (double) value * (double) value * (double) value + 1.0) + start;
  }

  public static float easeOutCubic(float start, float end, float value)
  {
    --value;
    end -= start;
    return end * (float) ((double) value * (double) value * (double) value + 1.0) + start;
  }

  public static float easeOutQuart(float start, float end, float value)
  {
    --value;
    end -= start;
    return end * (float) ((double) value * (double) value * (double) value * (double) value * -1.0 + 1.0) + start;
  }

  public static double easeInElastic(double t, double b, double c, double d)
  {
    double num1 = c;
    if (t == 0.0)
      return b;
    if ((t /= d) == 1.0)
      return b + c;
    double num2 = d * 0.3;
    double num3;
    if (num1 < Math.Abs(c))
    {
      num1 = c;
      num3 = num2 / 4.0;
    }
    else
      num3 = num2 / (2.0 * Math.PI) * Math.Asin(c / num1);
    return -(num1 * Math.Pow(2.0, 10.0 * --t) * Math.Sin((t * d - num3) * (2.0 * Math.PI) / num2)) + b;
  }

  public static float easeInBack(float start, float end, float value)
  {
    end -= start;
    value /= 1f;
    float num = 0.8f;
    return (float) ((double) end * (double) value * (double) value * (((double) num + 1.0) * (double) value - (double) num)) + start;
  }

  private float GetScale(float t, float b, float c, float d)
  {
    float num1 = (t /= d) * t;
    float num2 = num1 * t;
    return b + c * (num2 * num1);
  }

  public static float easeInBack2(float t, float b, float c, float d)
  {
    float num1 = (t /= d) * t;
    float num2 = num1 * t;
    return b + c * (float) (5.6 * (double) num2 * (double) num1 + -11.3 * (double) num1 * (double) num1 + 8.1 * (double) num2 + -0.2 * (double) num1 + -1.2 * (double) t);
  }
}
