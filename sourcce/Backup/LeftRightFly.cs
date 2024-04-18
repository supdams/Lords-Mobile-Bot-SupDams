// Decompiled with JetBrains decompiler
// Type: LeftRightFly
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class LeftRightFly
{
  private const int countDown = 10;
  private const float FlyInTime = 0.3f;
  private const float StayTime = 1f;
  private const float FlyOutTime = 0.5f;
  private const float FallOutTime = 0.4f;
  private const float WinFlyTime = 1.8f;
  private const float LoseFlyTime = 1.69999993f;
  public const float skipBegin = 10f;
  private float FlyInTextStartRight = -1000f;
  private float FlyInTextStartLeft = 1000f;
  private float FallOutDist = 330f;
  private float CountingSize = 4f;
  private bool initialed;
  private bool FromRight;
  private bool isWinning;
  private bool BattleStart;
  private LeftRightFly.FlyStage mFlyStage;
  private float currentTime;
  private int counting;
  private double CutInStartTime;
  private Material m_bg;
  private string BGNameStr = "Transitions1";
  private GameObject Base;
  private Image BGImage;
  private RectTransform BGUnit;
  private RectTransform TextBaseUnit;
  private UIText Text1;
  private UIText Text2;
  private UIText Text3;
  private UIText Text4;
  private Shadow sha1;
  private Shadow sha2;
  private Outline ol1;
  private Outline ol2;
  private string TextStr1;
  private string TextStr2;
  private Color32[] winingColorSet = new Color32[3]
  {
    new Color32((byte) 253, (byte) 228, (byte) 111, byte.MaxValue),
    new Color32(byte.MaxValue, (byte) 114, (byte) 0, byte.MaxValue),
    new Color32((byte) 146, (byte) 0, (byte) 0, byte.MaxValue)
  };
  private Color32[] losingColorSet = new Color32[3]
  {
    new Color32((byte) 0, (byte) 221, (byte) 151, byte.MaxValue),
    new Color32((byte) 0, (byte) 139, (byte) 179, byte.MaxValue),
    new Color32((byte) 0, (byte) 86, (byte) 135, byte.MaxValue)
  };
  public static LeftRightFly _instance;

  private LeftRightFly() => this.mFlyStage = LeftRightFly.FlyStage.Idle;

  public static LeftRightFly Instance
  {
    get
    {
      if (LeftRightFly._instance == null)
        LeftRightFly._instance = new LeftRightFly();
      return LeftRightFly._instance;
    }
  }

  public void init()
  {
    if (this.initialed)
      return;
    this.Base = new GameObject(nameof (LeftRightFly));
    this.Base.layer = 5;
    RectTransform rectTransform1 = this.Base.AddComponent<RectTransform>();
    ((Transform) rectTransform1).SetParent((Transform) GUIManager.Instance.m_TopLayer, false);
    RectTransform rectTransform2 = rectTransform1;
    Vector2 zero = Vector2.zero;
    rectTransform1.anchorMin = zero;
    Vector2 vector2 = zero;
    rectTransform2.sizeDelta = vector2;
    rectTransform1.anchorMax = Vector2.one;
    this.m_bg = GUIManager.Instance.AddSpriteAsset(this.BGNameStr);
    GameObject gameObject1 = new GameObject("TransBg");
    gameObject1.transform.SetParent(this.Base.transform, false);
    RectTransform rectTransform3 = gameObject1.AddComponent<RectTransform>();
    this.BGImage = gameObject1.AddComponent<Image>();
    ((MaskableGraphic) this.BGImage).material = this.m_bg;
    this.BGImage.sprite = GUIManager.Instance.LoadSprite(this.BGNameStr, "black_gogo_b");
    this.BGImage.type = (Image.Type) 1;
    ((Graphic) this.BGImage).color = (Color) new Color32(byte.MaxValue, byte.MaxValue, (byte) 225, (byte) 182);
    ((Transform) rectTransform3).localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    rectTransform3.anchoredPosition = new Vector2(0.0f, -46f);
    rectTransform3.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 0.0f);
    rectTransform3.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 210f);
    rectTransform3.anchorMin = new Vector2(1f, 0.5f);
    rectTransform3.anchorMax = new Vector2(1f, 0.5f);
    this.BGUnit = rectTransform3;
    GameObject gameObject2 = new GameObject("TextBase");
    gameObject2.transform.SetParent(this.Base.transform, false);
    this.TextBaseUnit = gameObject2.AddComponent<RectTransform>();
    this.TextBaseUnit.anchoredPosition = new Vector2(this.FlyInTextStartRight, -46f);
    GameObject gameObject3 = new GameObject("Text1");
    gameObject3.transform.SetParent(((Component) this.TextBaseUnit).transform, false);
    RectTransform rectTransform4 = gameObject3.AddComponent<RectTransform>();
    rectTransform4.anchoredPosition = new Vector2(0.0f, 65f);
    rectTransform4.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 500f);
    rectTransform4.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 120f);
    UIText uiText1 = gameObject3.AddComponent<UIText>();
    uiText1.font = GUIManager.Instance.GetTTFFont();
    uiText1.resizeTextForBestFit = true;
    uiText1.resizeTextMinSize = 24;
    uiText1.resizeTextMaxSize = 55;
    uiText1.alignment = TextAnchor.LowerCenter;
    uiText1.text = string.Empty;
    this.Text1 = uiText1;
    this.ol1 = gameObject3.AddComponent<Outline>();
    this.sha1 = gameObject3.AddComponent<Shadow>();
    GameObject gameObject4 = new GameObject("Text2");
    gameObject4.transform.SetParent(((Component) this.TextBaseUnit).transform, false);
    RectTransform rectTransform5 = gameObject4.AddComponent<RectTransform>();
    rectTransform5.anchoredPosition = new Vector2(0.0f, -65f);
    rectTransform5.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 500f);
    rectTransform5.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 120f);
    UIText uiText2 = gameObject4.AddComponent<UIText>();
    uiText2.font = GUIManager.Instance.GetTTFFont();
    uiText2.resizeTextForBestFit = true;
    uiText2.resizeTextMinSize = 24;
    uiText2.resizeTextMaxSize = 60;
    uiText2.alignment = TextAnchor.UpperCenter;
    uiText2.text = string.Empty;
    this.Text2 = uiText2;
    this.ol2 = gameObject4.AddComponent<Outline>();
    this.sha2 = gameObject4.AddComponent<Shadow>();
    GameObject gameObject5 = new GameObject("Text3");
    gameObject5.transform.SetParent(((Component) this.TextBaseUnit).transform, false);
    RectTransform rectTransform6 = gameObject5.AddComponent<RectTransform>();
    rectTransform6.anchoredPosition = new Vector2(0.0f, 0.0f);
    rectTransform6.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 800f);
    rectTransform6.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 200f);
    UIText uiText3 = gameObject5.AddComponent<UIText>();
    uiText3.font = GUIManager.Instance.GetTTFFont();
    uiText3.resizeTextForBestFit = true;
    uiText3.resizeTextMinSize = 24;
    uiText3.resizeTextMaxSize = 120;
    uiText3.alignment = TextAnchor.MiddleCenter;
    uiText3.text = DataManager.Instance.mStringTable.GetStringByID(17508U);
    this.Text3 = uiText3;
    Outline outline1 = gameObject5.AddComponent<Outline>();
    Shadow shadow1 = gameObject5.AddComponent<Shadow>();
    ((Graphic) uiText3).color = (Color) this.winingColorSet[0];
    ((Shadow) outline1).effectColor = (Color) this.winingColorSet[1];
    shadow1.effectColor = (Color) this.winingColorSet[2];
    GameObject gameObject6 = new GameObject("Text4");
    gameObject6.transform.SetParent(this.Base.transform, false);
    RectTransform rectTransform7 = gameObject6.AddComponent<RectTransform>();
    rectTransform7.anchoredPosition = new Vector2(0.0f, -155f);
    rectTransform7.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 800f);
    rectTransform7.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 240f);
    UIText uiText4 = gameObject6.AddComponent<UIText>();
    uiText4.font = GUIManager.Instance.GetTTFFont();
    uiText4.resizeTextForBestFit = true;
    uiText4.resizeTextMinSize = 24;
    uiText4.resizeTextMaxSize = 120;
    uiText4.alignment = TextAnchor.MiddleCenter;
    gameObject6.SetActive(false);
    uiText4.text = string.Empty;
    this.Text4 = uiText4;
    Outline outline2 = gameObject6.AddComponent<Outline>();
    Shadow shadow2 = gameObject6.AddComponent<Shadow>();
    ((Graphic) uiText4).color = (Color) this.winingColorSet[0];
    ((Shadow) outline2).effectColor = (Color) this.winingColorSet[1];
    shadow2.effectColor = (Color) this.winingColorSet[2];
    this.initialed = true;
  }

  public void Update(bool addtime = true)
  {
    if (!this.initialed)
      return;
    float deltaTime = Time.deltaTime;
    if (addtime)
      this.currentTime += deltaTime;
    switch (this.mFlyStage)
    {
      case LeftRightFly.FlyStage.Flyin:
        float num1 = Mathf.Clamp01(this.currentTime / 0.3f);
        if (this.FromRight)
        {
          this.BGUnit.anchorMin = new Vector2(DamageValueManager.easeInCubic(1f, 0.0f, num1), 0.5f);
          this.TextBaseUnit.anchoredPosition = new Vector2(DamageValueManager.easeInCubic(this.FlyInTextStartRight, 0.0f, num1), -46f);
        }
        else
        {
          this.BGUnit.anchorMax = new Vector2(DamageValueManager.easeInCubic(0.0f, 1f, num1), 0.5f);
          this.TextBaseUnit.anchoredPosition = new Vector2(DamageValueManager.easeInCubic(this.FlyInTextStartLeft, 0.0f, num1), -46f);
        }
        if ((double) this.currentTime <= 0.30000001192092896)
          break;
        this.mFlyStage = LeftRightFly.FlyStage.Waiting;
        this.currentTime = 0.0f;
        break;
      case LeftRightFly.FlyStage.Waiting:
        if ((double) this.currentTime <= 1.0)
          break;
        this.mFlyStage = !this.isWinning ? LeftRightFly.FlyStage.FallOut : LeftRightFly.FlyStage.Flyout;
        this.currentTime = 0.0f;
        break;
      case LeftRightFly.FlyStage.Flyout:
        float num2 = Mathf.Clamp01(this.currentTime / 0.5f);
        if (this.FromRight)
        {
          this.BGUnit.anchorMin = new Vector2(DamageValueManager.easeInCubic(0.0f, 1f, num2), 0.5f);
          this.TextBaseUnit.anchoredPosition = new Vector2(DamageValueManager.easeInCubic(0.0f, this.FlyInTextStartRight, num2), -46f);
        }
        else
        {
          this.BGUnit.anchorMax = new Vector2(DamageValueManager.easeInCubic(1f, 0.0f, num2), 0.5f);
          this.TextBaseUnit.anchoredPosition = new Vector2(DamageValueManager.easeInExpo(0.0f, this.FlyInTextStartLeft, num2), -46f);
        }
        if ((double) this.currentTime <= 0.5)
          break;
        this.mFlyStage = LeftRightFly.FlyStage.End;
        this.currentTime = 0.0f;
        break;
      case LeftRightFly.FlyStage.FallOut:
        float a = (float) ((1.0 - (double) Mathf.Clamp01(this.currentTime / 0.4f)) * (double) byte.MaxValue);
        this.TextBaseUnit.anchoredPosition = new Vector2(0.0f, (float) (-46.0 - (double) this.FallOutDist * (double) DamageValueManager.easeInBack2(this.currentTime, 0.0f, 1f, 0.4f)));
        Color32 color32 = new Color32(this.losingColorSet[0].r, this.losingColorSet[0].g, this.losingColorSet[0].b, (byte) a);
        ((Graphic) this.Text1).color = (Color) color32;
        ((Graphic) this.Text2).color = (Color) color32;
        color32 = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, (byte) ((double) a * 0.699999988079071));
        ((Graphic) this.BGImage).color = (Color) color32;
        if ((double) this.currentTime <= 0.40000000596046448)
          break;
        this.mFlyStage = LeftRightFly.FlyStage.End;
        this.currentTime = 0.0f;
        break;
      case LeftRightFly.FlyStage.CountDown:
        this.Text4.text = this.counting.ToString();
        float num3 = (double) this.currentTime >= 0.5 ? 1f : DamageValueManager.easeOutQuart(this.CountingSize, 1f, this.currentTime * 2f);
        if (GUIManager.Instance.IsArabic)
          ((Transform) ((Graphic) this.Text4).rectTransform).localScale = new Vector3(-1f, 1f, 1f) * num3;
        else
          ((Transform) ((Graphic) this.Text4).rectTransform).localScale = Vector3.one * num3;
        if ((double) this.currentTime < 1.0)
          break;
        --this.counting;
        this.currentTime = 0.0f;
        if (this.counting <= 0)
        {
          ((Component) this.Text4).gameObject.SetActive(false);
          this.mFlyStage = LeftRightFly.FlyStage.Flyin;
          AudioManager.Instance.PlaySFX((ushort) 40058);
          break;
        }
        if (this.counting > 3)
          break;
        AudioManager.Instance.PlaySFX((ushort) 40055);
        break;
      case LeftRightFly.FlyStage.End:
        this.mFlyStage = LeftRightFly.FlyStage.Idle;
        this.setStartValue(true, LeftRightFly.TransferType.Win);
        this.OnAnimaFinish();
        break;
      case LeftRightFly.FlyStage.WaitCount:
        if ((double) this.currentTime <= 1.0)
          break;
        this.currentTime = 0.0f;
        ((Component) this.Text4).gameObject.SetActive(true);
        this.mFlyStage = LeftRightFly.FlyStage.CountDown;
        break;
    }
  }

  public static void Release()
  {
    if (LeftRightFly._instance == null)
      return;
    LeftRightFly._instance.mFlyStage = LeftRightFly.FlyStage.Idle;
    Object.Destroy((Object) LeftRightFly._instance.Base);
    LeftRightFly._instance.Base = (GameObject) null;
    LeftRightFly._instance = (LeftRightFly) null;
  }

  public void SetMove(
    string Title,
    ushort SecendLine,
    bool fromRight,
    bool isWinning,
    float time = 0.0f,
    bool playSound = true)
  {
    if (!this.initialed)
      return;
    this.CutInStartTime = NetworkManager.ServerTime - (double) time;
    if (isWinning)
    {
      if (playSound)
        AudioManager.Instance.PlayMP3SFX(BGMType.LegionVictory, false);
      if ((double) time > 1.7999999523162842)
      {
        this.mFlyStage = LeftRightFly.FlyStage.Idle;
        this.setStartValue(fromRight, LeftRightFly.TransferType.Win);
        return;
      }
    }
    else
    {
      if (playSound)
        AudioManager.Instance.PlayMP3SFX(BGMType.LegionDefeat, false);
      if ((double) time > 1.6999999284744263)
      {
        this.mFlyStage = LeftRightFly.FlyStage.Idle;
        this.setStartValue(fromRight, LeftRightFly.TransferType.Win);
        return;
      }
    }
    this.currentTime = 0.0f;
    this.mFlyStage = LeftRightFly.FlyStage.Flyin;
    this.FromRight = fromRight;
    this.BattleStart = false;
    this.isWinning = isWinning;
    this.TextStr1 = Title;
    this.TextStr1 = string.Format(DataManager.Instance.mStringTable.GetStringByID(14620U), (object) Title);
    this.Text1.text = this.TextStr1;
    if (isWinning)
    {
      this.Text2.text = DataManager.Instance.mStringTable.GetStringByID(14621U);
      this.setStartValue(fromRight, LeftRightFly.TransferType.Win);
    }
    else
    {
      this.Text2.text = DataManager.Instance.mStringTable.GetStringByID(14622U);
      this.setStartValue(fromRight, LeftRightFly.TransferType.Lose);
    }
    this.currentTime = time;
    this.Update(false);
    if ((double) time > 0.30000001192092896)
    {
      this.currentTime = time - 0.3f;
      this.Update(false);
    }
    if ((double) time <= 1.2999999523162842)
      return;
    this.currentTime = (float) ((double) time - 0.30000001192092896 - 1.0);
    this.Update(false);
  }

  public void SetCountDown(float time = 0.0f)
  {
    if (!this.initialed)
      return;
    if ((double) time >= 11.800000190734863)
    {
      this.mFlyStage = LeftRightFly.FlyStage.Idle;
      this.setStartValue(this.FromRight, LeftRightFly.TransferType.BattleStart);
    }
    else
    {
      this.counting = 10;
      this.currentTime = 0.0f;
      this.mFlyStage = LeftRightFly.FlyStage.CountDown;
      this.FromRight = true;
      this.isWinning = true;
      this.BattleStart = true;
      this.setStartValue(this.FromRight, LeftRightFly.TransferType.BattleStart);
      ((Component) this.Text3).gameObject.SetActive(true);
      ((Component) this.Text4).gameObject.SetActive(true);
      this.Text3.text = DataManager.Instance.mStringTable.GetStringByID(17508U);
      if (GUIManager.Instance.IsArabic)
        ((Transform) ((Graphic) this.Text4).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
      else
        ((Transform) ((Graphic) this.Text4).rectTransform).localScale = Vector3.one;
      ActivityManager.Instance.SetActivityWindowTimeVisible(false);
      this.CutInStartTime = NetworkManager.ServerTime - (double) time;
      if ((double) time == 0.0)
        return;
      if ((double) time < 10.0)
      {
        this.mFlyStage = LeftRightFly.FlyStage.CountDown;
        this.counting = Mathf.CeilToInt(10f - time);
        this.currentTime = time % 1f;
        ((Component) this.Text4).gameObject.SetActive(true);
        this.Update(false);
      }
      else if ((double) time < 11.800000190734863)
      {
        float num = time - 10f;
        ((Component) this.Text4).gameObject.SetActive(false);
        this.mFlyStage = LeftRightFly.FlyStage.Flyin;
        this.currentTime = num;
        this.Update(false);
        if ((double) num > 0.30000001192092896)
        {
          this.currentTime = num - 0.3f;
          this.Update(false);
        }
        if ((double) num > 1.2999999523162842)
        {
          this.currentTime = (float) ((double) num - 0.30000001192092896 - 1.0);
          this.Update(false);
        }
      }
      if ((double) time != 10.0)
        return;
      AudioManager.Instance.PlaySFX((ushort) 40058);
    }
  }

  public void setStartValue(bool fromRight, LeftRightFly.TransferType type)
  {
    if (!this.initialed)
      return;
    if (fromRight)
    {
      this.BGUnit.anchorMin = new Vector2(1f, 0.5f);
      this.BGUnit.anchorMax = new Vector2(1f, 0.5f);
      this.TextBaseUnit.anchoredPosition = new Vector2(this.FlyInTextStartRight, -46f);
    }
    else
    {
      this.BGUnit.anchorMin = new Vector2(0.0f, 0.5f);
      this.BGUnit.anchorMax = new Vector2(0.0f, 0.5f);
      this.TextBaseUnit.anchoredPosition = new Vector2(this.FlyInTextStartLeft, -46f);
    }
    if (type == LeftRightFly.TransferType.BattleStart)
    {
      ((Component) this.Text1).gameObject.SetActive(false);
      ((Component) this.Text2).gameObject.SetActive(false);
      ((Component) this.Text3).gameObject.SetActive(true);
      ((Component) this.Text4).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.Text1).gameObject.SetActive(true);
      ((Component) this.Text2).gameObject.SetActive(true);
      ((Component) this.Text3).gameObject.SetActive(false);
      ((Component) this.Text4).gameObject.SetActive(false);
    }
    if (type != LeftRightFly.TransferType.Lose)
    {
      ((Graphic) this.Text1).color = (Color) this.winingColorSet[0];
      ((Graphic) this.Text2).color = (Color) this.winingColorSet[0];
      ((Shadow) this.ol1).effectColor = (Color) this.winingColorSet[1];
      ((Shadow) this.ol2).effectColor = (Color) this.winingColorSet[1];
      this.sha1.effectColor = (Color) this.winingColorSet[2];
      this.sha2.effectColor = (Color) this.winingColorSet[2];
    }
    else
    {
      ((Graphic) this.Text1).color = (Color) this.losingColorSet[0];
      ((Graphic) this.Text2).color = (Color) this.losingColorSet[0];
      ((Shadow) this.ol1).effectColor = (Color) this.losingColorSet[1];
      ((Shadow) this.ol2).effectColor = (Color) this.losingColorSet[1];
      this.sha1.effectColor = (Color) this.losingColorSet[2];
      this.sha2.effectColor = (Color) this.losingColorSet[2];
    }
    ((Graphic) this.BGImage).color = (Color) new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, (byte) 182);
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.Text1 != (Object) null && ((Behaviour) this.Text1).enabled)
    {
      ((Behaviour) this.Text1).enabled = false;
      ((Behaviour) this.Text1).enabled = true;
    }
    if ((Object) this.Text2 != (Object) null && ((Behaviour) this.Text2).enabled)
    {
      ((Behaviour) this.Text2).enabled = false;
      ((Behaviour) this.Text2).enabled = true;
    }
    if ((Object) this.Text3 != (Object) null && ((Behaviour) this.Text3).enabled)
    {
      ((Behaviour) this.Text3).enabled = false;
      ((Behaviour) this.Text3).enabled = true;
    }
    if (!((Object) this.Text4 != (Object) null) || !((Behaviour) this.Text4).enabled)
      return;
    ((Behaviour) this.Text4).enabled = false;
    ((Behaviour) this.Text4).enabled = true;
  }

  private void OnAnimaFinish() => ActivityManager.Instance.SetActivityWindowTimeVisible(true);

  public void SetEnable(bool enable)
  {
    if (!((Object) this.Base != (Object) null))
      return;
    this.Base.SetActive(enable);
  }

  public void UpdateCutinStat()
  {
    if (this.mFlyStage == LeftRightFly.FlyStage.Idle)
      return;
    if (this.BattleStart)
      this.SetCountDown((float) (NetworkManager.ServerTime - this.CutInStartTime));
    else
      this.SetMove(this.TextStr1, (ushort) 0, this.FromRight, this.isWinning, (float) (NetworkManager.ServerTime - this.CutInStartTime), false);
  }

  public enum TransferType
  {
    Win,
    Lose,
    BattleStart,
  }

  public enum FlyStage
  {
    Idle,
    Flyin,
    Waiting,
    Flyout,
    FallOut,
    CountDown,
    End,
    WaitCount,
  }
}
