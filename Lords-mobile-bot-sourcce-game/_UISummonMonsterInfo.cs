// Decompiled with JetBrains decompiler
// Type: _UISummonMonsterInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class _UISummonMonsterInfo
{
  private Transform transform;
  private RectTransform ContentR;
  private RectTransform ScrollR;
  private UIText[] RefreshTextList = new UIText[6];
  private byte Listindex;
  private GameObject GO;
  private UISummonMonster MainRef;

  public _UISummonMonsterInfo(UISummonMonster mainRef, GameObject go)
  {
    this.MainRef = mainRef;
    this.transform = go.transform;
    this.GO = go;
  }

  public void OnOpen(int arg1, int arg2)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 3);
    if (GUIManager.Instance.bOpenOnIPhoneX)
      ((Behaviour) this.transform.GetChild(3).GetComponent<CustomImage>()).enabled = false;
    else
      this.transform.GetChild(3).GetComponent<CustomImage>().hander = (UILoadImageHander) GUIManager.Instance.m_ItemInfo;
    this.transform.GetChild(3).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) GUIManager.Instance.m_ItemInfo;
    UIButton component1 = this.transform.GetChild(3).GetChild(0).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this.MainRef;
    component1.m_BtnID1 = 4;
    UIText component2 = this.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    component2.font = ttfFont;
    component2.text = mStringTable.GetStringByID(14527U);
    this.RefreshTextList[(int) this.Listindex++] = component2;
    this.transform.GetChild(1).gameObject.SetActive(false);
    this.ScrollR = this.transform.GetChild(2).GetComponent<RectTransform>();
    this.ScrollR.anchoredPosition = new Vector2(this.ScrollR.anchoredPosition.x, -54.5f);
    this.ScrollR.sizeDelta = new Vector2(this.ScrollR.sizeDelta.x, 487f);
    this.ContentR = this.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>();
    this.ContentR.sizeDelta = new Vector2(this.ContentR.sizeDelta.x, 487f);
    ((Transform) this.ContentR).GetChild(0).gameObject.SetActive(false);
    ((Transform) this.ContentR).GetChild(1).gameObject.SetActive(true);
    float num1 = 0.0f;
    float num2 = 0.0f;
    float y = 0.0f;
    for (int index = 0; index < 5; ++index)
    {
      UIText component3 = ((Transform) this.ContentR).GetChild(1).GetChild(index).GetComponent<UIText>();
      RectTransform rectTransform = ((Graphic) component3).rectTransform;
      component3.font = ttfFont;
      this.RefreshTextList[(int) this.Listindex++] = component3;
      component3.text = index > 3 ? mStringTable.GetStringByID(14532U) : mStringTable.GetStringByID((uint) (14528 + index));
      rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, (float) ((double) num2 - (double) y - 10.0));
      num2 = rectTransform.anchoredPosition.y;
      y = component3.preferredHeight + 4f;
      rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, y);
      num1 += y + 20f;
    }
    if ((double) num1 <= 447.0)
    {
      ((Behaviour) ((Component) this.ScrollR).GetComponent<CScrollRect>()).enabled = false;
      ((Behaviour) ((Component) this.ScrollR).GetComponent<Mask>()).enabled = false;
      ((Behaviour) ((Component) this.ScrollR).GetComponent<Image>()).enabled = false;
    }
    else
      this.ContentR.sizeDelta = new Vector2(this.ContentR.sizeDelta.x, num1 + 40f);
  }

  public void OnClose()
  {
  }

  public void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    for (int index = 0; index < this.RefreshTextList.Length; ++index)
    {
      ((Behaviour) this.RefreshTextList[index]).enabled = false;
      ((Behaviour) this.RefreshTextList[index]).enabled = true;
    }
  }

  private enum UIControl
  {
    Background,
    Title,
    Scroll,
    Close,
  }
}
