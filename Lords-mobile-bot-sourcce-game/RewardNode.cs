// Decompiled with JetBrains decompiler
// Type: RewardNode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class RewardNode
{
  private const float CAP_OPEN_SPEED = 180f;
  private const float CHEST_DEEP_SPEED = 2f;
  private const float BOX_IDLE_TIME = 1f;
  private const float ICON_START_SCALE = 0.6f;
  private const float ICON_START_SCALE_2 = 0.900000036f;
  private static readonly Vector2 IconOffsetOnScaling = new Vector2(0.0f, 200f);
  private ushort ItemID;
  private byte ItemRank;
  private GameObject LEObj;
  private GameObject HIObj;
  private float timeStep;
  private float CurveHeight;
  private Vector3 SamplePoint1;
  private Vector3 SamplePoint2;
  private Vector3 SampleControl1;
  private Vector3 SampleControl2;
  private byte sampleStep;
  private float SampleTimeEnd = 0.5f;
  private Transform rewardRoot;
  private Transform cap;
  private float capAngle;
  private RectTransform uiRoot;
  private RectTransform iconRt;
  private Vector3 iconWorldPos = Vector3.zero;
  private byte uiStep;
  private float uiTimeStep;
  private float uiGlobalScale;
  private float uiScaleStep;
  private Vector2 iconOffsetTmp = Vector2.zero;
  private Vector2 bezierStart = Vector2.zero;
  private Vector2 bezierCenter = Vector2.zero;
  private Vector2 bezierCenter2 = Vector2.zero;
  private static readonly Vector2[,] bezierCenterOffset = new Vector2[4, 2]
  {
    {
      new Vector2(0.0f, 0.0f),
      new Vector2(-50f, -100f)
    },
    {
      new Vector2(0.0f, 0.0f),
      new Vector2(-50f, -100f)
    },
    {
      new Vector2(200f, -200f),
      new Vector2(-100f, -200f)
    },
    {
      new Vector2(200f, 200f),
      new Vector2(-100f, 200f)
    }
  };

  protected RewardNode()
  {
  }

  public RewardNode(AssetBundle ab, RectTransform rt)
  {
    if ((Object) ab == (Object) null)
      return;
    this.rewardRoot = (Object.Instantiate(ab.mainAsset) as GameObject).transform;
    this.cap = this.rewardRoot.GetChild(0);
    this.uiRoot = rt;
    this.uiGlobalScale = GUIManager.Instance.m_UICanvas.scaleFactor;
  }

  public bool Update(float deltaTime)
  {
    if (this.sampleStep == (byte) 0 && this.uiStep == (byte) 0)
      return false;
    if (this.sampleStep == (byte) 1)
    {
      this.UpdateSampleControl();
      this.rewardRoot.position = this.Evaluate(deltaTime);
      this.timeStep += deltaTime;
      if ((double) this.timeStep >= (double) this.SampleTimeEnd)
      {
        this.rewardRoot.position = this.SamplePoint2;
        this.timeStep = 0.0f;
        this.sampleStep = (byte) 2;
      }
    }
    else if (this.sampleStep == (byte) 2)
    {
      this.timeStep += deltaTime;
      if ((double) this.timeStep > 1.0)
      {
        this.timeStep = 0.0f;
        this.sampleStep = (byte) 3;
      }
    }
    else if (this.sampleStep == (byte) 3)
    {
      float num = deltaTime * 180f;
      this.capAngle += num;
      this.cap.Rotate(-num, 0.0f, 0.0f);
      if ((double) this.capAngle > 90.0)
      {
        this.timeStep = 0.0f;
        this.sampleStep = (byte) 4;
      }
      if ((double) this.capAngle > 45.0 && this.uiStep == (byte) 1)
      {
        this.iconWorldPos = this.cap.position;
        AudioManager.Instance.PlaySFX((ushort) 11001, PlayObj: this.rewardRoot);
        this.createItemIcon();
        this.uiStep = (byte) 2;
      }
    }
    else if (this.sampleStep == (byte) 4)
    {
      this.timeStep += deltaTime;
      if ((double) this.timeStep > 1.0)
      {
        Vector3 position = this.rewardRoot.position;
        position.y -= deltaTime * 2f;
        this.rewardRoot.position = position;
        if ((double) position.y < -1.5)
        {
          this.sampleStep = (byte) 0;
          this.rewardRoot.gameObject.SetActive(false);
        }
      }
    }
    if (this.uiStep == (byte) 2)
    {
      this.uiTimeStep += deltaTime;
      Vector2 screenPoint = (Vector2) Camera.main.WorldToScreenPoint(this.iconWorldPos);
      this.iconOffsetTmp = RewardNode.IconOffsetOnScaling * this.uiTimeStep;
      Vector2 vector2 = (screenPoint + this.iconOffsetTmp) / this.uiGlobalScale;
      if (GUIManager.Instance.bOpenOnIPhoneX)
        vector2 += new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      if (GUIManager.Instance.IsArabic)
      {
        RectTransform canvasRt = GUIManager.Instance.pDVMgr.CanvasRT;
        vector2.x -= (float) (((double) vector2.x - (double) canvasRt.sizeDelta.x * 0.5) * 2.0);
      }
      this.iconRt.anchoredPosition = vector2;
      if ((double) this.uiScaleStep < 0.90000003576278687)
      {
        this.uiScaleStep += deltaTime * 4f;
        if ((double) this.uiScaleStep >= 0.90000003576278687)
        {
          this.uiScaleStep = 0.900000036f;
          this.uiStep = (byte) 3;
          this.uiTimeStep = 0.0f;
        }
        ((Transform) this.iconRt).localScale = new Vector3(this.uiScaleStep, this.uiScaleStep, this.uiScaleStep);
      }
    }
    else if (this.uiStep == (byte) 3)
    {
      Vector2 vector2 = ((Vector2) Camera.main.WorldToScreenPoint(this.iconWorldPos) + this.iconOffsetTmp) / this.uiGlobalScale;
      if (GUIManager.Instance.bOpenOnIPhoneX)
        vector2 += new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      if (GUIManager.Instance.IsArabic)
      {
        RectTransform canvasRt = GUIManager.Instance.pDVMgr.CanvasRT;
        vector2.x -= (float) (((double) vector2.x - (double) canvasRt.sizeDelta.x * 0.5) * 2.0);
      }
      this.iconRt.anchoredPosition = vector2;
      if ((double) this.uiScaleStep > 0.60000002384185791)
      {
        this.uiScaleStep -= deltaTime * 3f;
        this.uiScaleStep = (double) this.uiScaleStep > 0.60000002384185791 ? this.uiScaleStep : 0.6f;
        ((Transform) this.iconRt).localScale = new Vector3(this.uiScaleStep, this.uiScaleStep, this.uiScaleStep);
      }
      this.uiTimeStep += deltaTime;
      if ((double) this.uiTimeStep > 1.0)
      {
        this.bezierStart = vector2;
        int index = RewardManager.getInstance.EndPointMode != ERewardEndPoint.Default ? Random.Range(2, 4) : Random.Range(0, 2);
        this.bezierCenter = vector2 + RewardNode.bezierCenterOffset[index, 0];
        this.bezierCenter2 = vector2 + RewardNode.bezierCenterOffset[index, 1];
        this.uiTimeStep = 0.0f;
        this.uiScaleStep = 1f;
        this.uiStep = (byte) 4;
      }
    }
    else if (this.uiStep == (byte) 4)
    {
      this.iconRt.anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart, this.bezierCenter, this.bezierCenter2, RewardManager.getInstance.bezierEnd, 1.428f, this.uiTimeStep);
      float num = this.uiScaleStep * 0.6f;
      ((Transform) this.iconRt).localScale = new Vector3(num, num, num);
      this.uiTimeStep += deltaTime;
      this.uiScaleStep -= deltaTime * 0.5f;
      if ((double) this.uiTimeStep > 0.699999988079071)
      {
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 7);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 1);
        ((Component) this.iconRt).gameObject.SetActive(false);
        this.uiStep = (byte) 0;
      }
    }
    return true;
  }

  private void createItemIcon()
  {
    if ((Object) this.iconRt == (Object) null)
    {
      GameObject gameObject = new GameObject("IconNode");
      if (this.ItemRank == (byte) 0)
      {
        this.HIObj = new GameObject("HIObj");
        this.HIObj.transform.SetParent(gameObject.transform, false);
        this.HIObj.AddComponent<UIHIBtn>();
        this.HIObj.AddComponent<Image>();
        GUIManager.Instance.InitianHeroItemImg(this.HIObj.transform, eHeroOrItem.Item, this.ItemID, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
      }
      else
      {
        this.LEObj = new GameObject("LEObj");
        this.LEObj.transform.SetParent(gameObject.transform, false);
        this.LEObj.AddComponent<UILEBtn>();
        this.LEObj.AddComponent<Image>();
        GUIManager.Instance.InitLordEquipImg(this.LEObj.transform, this.ItemID, this.ItemRank, setSound: false, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      }
      gameObject.transform.SetParent((Transform) this.uiRoot, false);
      this.iconRt = gameObject.AddComponent<RectTransform>();
    }
    else
    {
      if (this.ItemRank == (byte) 0)
      {
        if ((Object) this.LEObj != (Object) null)
          this.LEObj.SetActive(false);
        if ((Object) this.HIObj == (Object) null)
        {
          this.HIObj = new GameObject("HIObj");
          this.HIObj.transform.SetParent(((Component) this.iconRt).gameObject.transform, false);
          this.HIObj.AddComponent<UIHIBtn>();
          this.HIObj.AddComponent<Image>();
          GUIManager.Instance.InitianHeroItemImg(this.HIObj.transform, eHeroOrItem.Item, this.ItemID, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
        }
        else
        {
          GUIManager.Instance.ChangeHeroItemImg(this.HIObj.transform, eHeroOrItem.Item, this.ItemID, (byte) 0, (byte) 0);
          this.HIObj.SetActive(true);
        }
      }
      else
      {
        if ((Object) this.HIObj != (Object) null)
          this.HIObj.SetActive(false);
        if ((Object) this.LEObj == (Object) null)
        {
          this.LEObj = new GameObject("LEObj");
          this.LEObj.transform.SetParent(((Component) this.iconRt).gameObject.transform, false);
          this.LEObj.AddComponent<UILEBtn>();
          this.LEObj.AddComponent<Image>();
          GUIManager.Instance.InitLordEquipImg(this.LEObj.transform, this.ItemID, this.ItemRank, setSound: false, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        }
        else
        {
          GUIManager.Instance.ChangeLordEquipImg(this.LEObj.transform, this.ItemID, this.ItemRank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
          this.LEObj.SetActive(true);
        }
      }
      ((Component) this.iconRt).gameObject.SetActive(true);
    }
    Vector2 vector2 = (Vector2) Camera.main.WorldToScreenPoint(this.iconWorldPos) / this.uiGlobalScale;
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform canvasRt = GUIManager.Instance.pDVMgr.CanvasRT;
      vector2.x -= (float) (((double) vector2.x - (double) canvasRt.sizeDelta.x * 0.5) * 2.0);
    }
    this.iconRt.anchoredPosition = vector2;
    ((Transform) this.iconRt).localScale = new Vector3(0.0f, 0.0f, 0.0f);
    this.uiScaleStep = 0.0f;
    this.iconOffsetTmp = Vector2.zero;
  }

  public void FontRefresh()
  {
    if (!((Object) this.iconRt != (Object) null) || !((Component) this.iconRt).gameObject.activeSelf || !((Object) this.HIObj != (Object) null) || !this.HIObj.activeSelf)
      return;
    UIHIBtn component = this.HIObj.GetComponent<UIHIBtn>();
    if (!((Object) component != (Object) null))
      return;
    component.Refresh_FontTexture();
  }

  public void SetActive(bool value, bool bSetIcon = false)
  {
    this.rewardRoot.gameObject.SetActive(value);
    if (!bSetIcon || !((Object) this.iconRt != (Object) null))
      return;
    ((Component) this.iconRt).gameObject.SetActive(value);
  }

  public void Destroy()
  {
    if ((Object) this.rewardRoot != (Object) null)
    {
      Object.Destroy((Object) this.rewardRoot.gameObject);
      this.cap = (Transform) null;
      this.rewardRoot = (Transform) null;
    }
    if (!((Object) this.iconRt != (Object) null))
      return;
    Object.Destroy((Object) ((Component) this.iconRt).gameObject);
    this.uiRoot = (RectTransform) null;
    this.iconRt = (RectTransform) null;
    this.LEObj = (GameObject) null;
    this.HIObj = (GameObject) null;
  }

  public void InitNode(ushort itemID, Vector3 start, Vector3 end, byte itemRank = 0)
  {
    this.timeStep = 0.0f;
    this.sampleStep = (byte) 1;
    this.SamplePoint1 = start;
    this.SamplePoint2 = end;
    this.CurveHeight = Vector3.Distance(this.SamplePoint1, this.SamplePoint2) * 0.4f;
    this.rewardRoot.gameObject.SetActive(true);
    this.rewardRoot.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1f);
    this.cap.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1f);
    this.rewardRoot.rotation = Quaternion.LookRotation(new Vector3(Camera.main.transform.position.x, 0.0f, Camera.main.transform.position.z) - start);
    this.capAngle = 0.0f;
    this.uiStep = (byte) 1;
    this.uiTimeStep = 0.0f;
    this.ItemID = itemID;
    this.ItemRank = itemRank;
    this.rewardRoot.localScale = Vector3.one;
    if (!BattleController.IsGambleMode || BattleController.GambleMode != EGambleMode.Turbo)
      return;
    this.rewardRoot.localScale = new Vector3(2f, 2f, 2f);
  }

  private void UpdateSampleControl()
  {
    Vector3 vector3 = this.SamplePoint2 - this.SamplePoint1;
    this.SampleControl1 = this.SamplePoint1 + vector3 * 0.25f;
    this.SampleControl2 = this.SamplePoint1 + vector3 * 0.6f;
    this.SampleControl1.y += this.CurveHeight;
    this.SampleControl2.y += this.CurveHeight;
  }

  private Vector3 Evaluate(float deltaTime)
  {
    float num1 = 0.0f;
    float sampleTimeEnd = this.SampleTimeEnd;
    float num2 = (float) (((double) this.timeStep - (double) num1) / ((double) sampleTimeEnd - (double) num1));
    Vector3 vector3_1 = this.SamplePoint2 - (this.SampleControl2 - this.SampleControl1) * 3f - this.SamplePoint1;
    Vector3 vector3_2 = 3f * (this.SampleControl2 + this.SamplePoint1) - 6f * this.SampleControl1;
    Vector3 vector3_3 = (this.SampleControl1 - this.SamplePoint1) * 3f;
    return this.SamplePoint1 + num2 * (vector3_3 + num2 * (vector3_2 + num2 * vector3_1));
  }
}
