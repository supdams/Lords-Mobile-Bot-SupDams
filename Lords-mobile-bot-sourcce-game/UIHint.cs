// Decompiled with JetBrains decompiler
// Type: UIHint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIHint : IUIButtonClickHandler
{
  private RectTransform Recttrans;
  private Image HintFrame;
  private HintStyleBase[] HintStyle;
  private HintStyleBase Style;
  private bool bFadeOut;
  private float FadeTime;
  private float MaxFadeTime = 0.2f;
  private CanvasGroup FadeOutCanvas;
  private byte SkipClick;
  private UIButtonHint ButtonHint;
  public AssetBundle m_ArmyHint;
  public int m_ArmyHintAssetBundleKey;

  public UIHint() => this.HintStyle = new HintStyleBase[3];

  void IUIButtonClickHandler.OnButtonClick(UIButton sender) => this.Hide(true);

  public void Load()
  {
    Object original1 = GUIManager.Instance.m_ManagerAssetBundle.Load("UI_Hint");
    if (original1 == (Object) null)
      return;
    GUIManager instance = GUIManager.Instance;
    instance.GetTTFFont();
    GameObject gameObject1 = (GameObject) Object.Instantiate(original1);
    gameObject1.transform.SetParent((Transform) GUIManager.Instance.m_ItemInfoLayer, false);
    this.Recttrans = gameObject1.GetComponent<RectTransform>();
    this.FadeOutCanvas = ((Component) this.Recttrans).GetComponent<CanvasGroup>();
    this.HintFrame = ((Component) this.Recttrans).GetComponent<Image>();
    ((MaskableGraphic) this.HintFrame).material = instance.GetFrameMaterial();
    this.m_ArmyHint = AssetManager.GetAssetBundle("UI/UIArmyHint", out this.m_ArmyHintAssetBundleKey);
    Object original2 = this.m_ArmyHint.Load("UIArmyHint");
    if (original2 == (Object) null)
      return;
    GameObject gameObject2 = (GameObject) Object.Instantiate(original2);
    gameObject2.transform.SetParent((Transform) this.Recttrans, false);
    gameObject2.SetActive(false);
    Object original3 = GUIManager.Instance.m_ManagerAssetBundle.Load("UI_PetSkillInfo");
    if (!(original3 != (Object) null))
      return;
    GameObject gameObject3 = (GameObject) Object.Instantiate(original3);
    gameObject3.transform.SetParent((Transform) this.Recttrans, false);
    gameObject3.SetActive(false);
  }

  public void UnLoad()
  {
    if (this.m_ArmyHintAssetBundleKey != 0)
      AssetManager.UnloadAssetBundle(this.m_ArmyHintAssetBundleKey);
    this.m_ArmyHintAssetBundleKey = 0;
    Object.Destroy((Object) ((Component) this.Recttrans).gameObject);
  }

  public void Show(
    UIButtonHint hint,
    UIHintStyle eStyle,
    byte kind,
    float width,
    int fontsize,
    CString Content,
    Vector2 upsetPos)
  {
    if (this.HintStyle[(int) eStyle] == null)
      this.HintStyle[(int) eStyle] = this.CreateHintStyle(eStyle);
    if (this.Style != null)
      this.Style.SetActive(false);
    this.Style = this.HintStyle[(int) eStyle];
    if (this.Style == null)
      return;
    this.ResetVal();
    this.Recttrans.sizeDelta = this.Recttrans.sizeDelta with
    {
      x = width
    };
    this.Style.SetContent((int) kind, fontsize, width, Content);
    this.Recttrans.sizeDelta = this.Style.GetSize();
    this.HintFrame.sprite = this.Style.HintFrameSprite;
    ((MaskableGraphic) this.HintFrame).material = this.Style.HintFrameMat;
    if ((Object) this.HintFrame.sprite == (Object) null)
      ((Behaviour) this.HintFrame).enabled = false;
    else
      ((Behaviour) this.HintFrame).enabled = true;
    hint.GetTipPosition(this.Recttrans, upsetPoint: new Vector3?((Vector3) upsetPos));
    ((Component) this.Recttrans).gameObject.SetActive(true);
    this.Style.SetActive(true);
    this.ButtonHint = hint;
  }

  public void Show(
    UIButtonHint hint,
    UIHintStyle eStyle,
    byte kind,
    float width,
    int fontsize,
    int Parm1,
    int Parm2,
    Vector2 upsetPos,
    UIButtonHint.ePosition position = UIButtonHint.ePosition.Original)
  {
    if (this.HintStyle[(int) eStyle] == null)
      this.HintStyle[(int) eStyle] = this.CreateHintStyle(eStyle);
    if (this.Style != null)
      this.Style.SetActive(false);
    this.Style = this.HintStyle[(int) eStyle];
    if (this.Style == null)
      return;
    this.ResetVal();
    this.Recttrans.sizeDelta = this.Recttrans.sizeDelta with
    {
      x = width
    };
    this.Style.SetContent((int) kind, fontsize, width, Parm1, Parm2);
    this.Recttrans.sizeDelta = this.Style.GetSize();
    this.HintFrame.sprite = this.Style.HintFrameSprite;
    ((MaskableGraphic) this.HintFrame).material = this.Style.HintFrameMat;
    if ((Object) this.HintFrame.sprite == (Object) null)
      ((Behaviour) this.HintFrame).enabled = false;
    else
      ((Behaviour) this.HintFrame).enabled = true;
    hint.GetTipPosition(this.Recttrans, position, new Vector3?((Vector3) upsetPos));
    ((Component) this.Recttrans).gameObject.SetActive(true);
    this.Style.SetActive(true);
    this.ButtonHint = hint;
  }

  public void Show(
    Vector2 Position,
    UIHintStyle eStyle,
    byte kind,
    float width,
    int fontsize,
    int Parm1,
    int Parm2)
  {
    if (this.HintStyle[(int) eStyle] == null)
      this.HintStyle[(int) eStyle] = this.CreateHintStyle(eStyle);
    if (this.Style != null)
      this.Style.SetActive(false);
    this.Style = this.HintStyle[(int) eStyle];
    if (this.Style == null)
      return;
    this.ResetVal();
    this.Recttrans.sizeDelta = this.Recttrans.sizeDelta with
    {
      x = width
    };
    this.Style.SetContent((int) kind, fontsize, width, Parm1, Parm2);
    this.Recttrans.sizeDelta = this.Style.GetSize();
    this.HintFrame.sprite = this.Style.HintFrameSprite;
    ((MaskableGraphic) this.HintFrame).material = this.Style.HintFrameMat;
    if ((Object) this.HintFrame.sprite == (Object) null)
      ((Behaviour) this.HintFrame).enabled = false;
    else
      ((Behaviour) this.HintFrame).enabled = true;
    this.GetTipPosition(ref Position);
    ((Component) this.Recttrans).gameObject.SetActive(true);
    this.Style.SetActive(true);
    GUIManager.Instance.HintMaskObj.Show((IUIButtonClickHandler) this);
    this.SkipClick = (byte) 1;
  }

  public void ShowPetHint(
    UIButtonHint hint,
    PetSkillHint.eKind kind,
    ushort PetID,
    ushort SkillID,
    byte Level,
    Vector2 upsetPos,
    UIButtonHint.ePosition position = UIButtonHint.ePosition.Original)
  {
    int Parm1 = (int) PetID << 16 | (int) SkillID;
    this.Show(hint, UIHintStyle.eHintPet, (byte) kind, 0.0f, 0, Parm1, (int) Level, upsetPos, position);
  }

  private void ResetVal()
  {
    this.FadeOutCanvas.alpha = 1f;
    this.FadeTime = 0.0f;
    this.bFadeOut = false;
  }

  public void GetTipPosition(ref Vector2 Position)
  {
    this.Recttrans.anchoredPosition = Position;
    Vector2 size = GUIManager.Instance.m_MessageBoxLayer.rect.size;
    ((Transform) this.Recttrans).position = ((Transform) this.Recttrans).position;
    Vector3 anchoredPosition3D = this.Recttrans.anchoredPosition3D;
    anchoredPosition3D.x += this.Recttrans.rect.x;
    anchoredPosition3D.y += this.Recttrans.rect.y;
    anchoredPosition3D.z = 0.0f;
    if (GUIManager.Instance.IsArabic)
      anchoredPosition3D.x = size.x - anchoredPosition3D.x;
    if ((double) anchoredPosition3D.x + (double) this.Recttrans.sizeDelta.x > (double) size.x)
      anchoredPosition3D.x = size.x - this.Recttrans.sizeDelta.x;
    if ((double) anchoredPosition3D.y + (double) this.Recttrans.rect.height + (double) this.Recttrans.sizeDelta.y <= 0.0)
      anchoredPosition3D.y += this.Recttrans.rect.height + this.Recttrans.sizeDelta.y;
    else if (-1.0 * (double) anchoredPosition3D.y + (double) this.Recttrans.sizeDelta.y > (double) size.y)
      anchoredPosition3D.y = (float) (-1.0 * ((double) size.y - (double) this.Recttrans.sizeDelta.y));
    this.Recttrans.anchoredPosition3D = anchoredPosition3D;
  }

  public void Hide(bool bFadeOut = false)
  {
    if (this.SkipClick > (byte) 0)
    {
      this.SkipClick = (byte) 0;
    }
    else
    {
      if (!((Component) this.Recttrans).gameObject.activeSelf)
        return;
      this.bFadeOut = bFadeOut;
      if (bFadeOut)
        return;
      ((Component) this.Recttrans).gameObject.SetActive(false);
      if (this.Style != null)
        this.Style.SetActive(false);
      this.Style = (HintStyleBase) null;
      this.ButtonHint = (UIButtonHint) null;
    }
  }

  private HintStyleBase CreateHintStyle(UIHintStyle Style)
  {
    HintStyleBase hintStyle = (HintStyleBase) null;
    switch (Style)
    {
      case UIHintStyle.eHintSimple:
        hintStyle = (HintStyleBase) new SimpleHint(((Transform) this.Recttrans).GetChild(0) as RectTransform);
        break;
      case UIHintStyle.eHintArmy:
        hintStyle = (HintStyleBase) new ArmyHint(((Transform) this.Recttrans).GetChild(1) as RectTransform);
        break;
      case UIHintStyle.eHintPet:
        hintStyle = (HintStyleBase) new PetSkillHint(((Transform) this.Recttrans).GetChild(2) as RectTransform);
        break;
    }
    return hintStyle;
  }

  public void Update()
  {
    if (!this.bFadeOut)
      return;
    if ((double) this.FadeTime < (double) this.MaxFadeTime)
    {
      this.FadeOutCanvas.alpha = Mathf.Clamp((float) (1.0 - (double) this.FadeTime / (double) this.MaxFadeTime), 0.0f, 1f);
      this.FadeTime += Time.deltaTime;
    }
    else
    {
      this.FadeOutCanvas.alpha = 1f;
      this.FadeTime = 0.0f;
      if ((Object) this.ButtonHint == (Object) null)
        GUIManager.Instance.HintMaskObj.Hide((IUIButtonClickHandler) this);
      else
        GUIManager.Instance.HintMaskObj.Hide(this.ButtonHint);
      this.Hide();
    }
  }

  public void TextRefresh()
  {
    if (this.Style == null)
      return;
    this.Style.TextRefresh();
  }
}
