// Decompiled with JetBrains decompiler
// Type: UIHintMask
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class UIHintMask : IUIButtonClickHandler
{
  public RectTransform m_RectTransform;
  public UIButton HideBtn;
  public UIButtonHint m_ButtonHint;
  public static bool bPassThrough = true;

  public void Load()
  {
    Object original = GUIManager.Instance.m_ManagerAssetBundle.Load(nameof (UIHintMask));
    if (original == (Object) null)
      return;
    GameObject gameObject = (GameObject) Object.Instantiate(original);
    gameObject.transform.SetParent((Transform) GUIManager.Instance.m_WindowTopLayer, false);
    gameObject.SetActive(false);
    this.m_RectTransform = (RectTransform) gameObject.transform;
    ((Transform) this.m_RectTransform).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) GUIManager.Instance.m_ItemInfo;
    this.HideBtn = ((Transform) this.m_RectTransform).GetChild(0).GetComponent<UIButton>();
    this.HideBtn.SoundIndex = byte.MaxValue;
    ((Component) this.HideBtn).gameObject.name = "*";
  }

  public void UnLoad() => Object.Destroy((Object) ((Component) this.m_RectTransform).gameObject);

  public void Show(IUIButtonClickHandler hint)
  {
    this.HideBtn.m_Handler = hint;
    ((Component) this.m_RectTransform).gameObject.SetActive(true);
  }

  public void Show(UIButtonHint hint)
  {
    this.m_ButtonHint = hint;
    ((Component) this.m_RectTransform).gameObject.SetActive(true);
  }

  public void Hide(IUIButtonClickHandler hint)
  {
    if (this.HideBtn.m_Handler != hint)
      return;
    ((Component) this.m_RectTransform).gameObject.SetActive(false);
    this.HideBtn.m_Handler = (IUIButtonClickHandler) null;
    this.m_ButtonHint = (UIButtonHint) null;
  }

  public void Hide(UIButtonHint hint)
  {
    if ((Object) this.m_ButtonHint != (Object) hint)
      return;
    ((Component) this.m_RectTransform).gameObject.SetActive(false);
    this.HideBtn.m_Handler = (IUIButtonClickHandler) null;
    this.m_ButtonHint = (UIButtonHint) null;
  }

  public void OnButtonClick(UIButton sender)
  {
  }
}
