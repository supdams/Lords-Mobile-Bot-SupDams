// Decompiled with JetBrains decompiler
// Type: UIMonsterInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIMonsterInfo : GUIWindow, IUIButtonClickHandler
{
  private RectTransform ContentR;
  private List<CString> InfoStr = new List<CString>();
  private UIText[] RefreshTextList = new UIText[6];
  private byte Listindex;
  private UIMapMonster.eMonsterType MonsterType;

  public override void OnOpen(int arg1, int arg2)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 3);
    if (GUIManager.Instance.bOpenOnIPhoneX)
      ((Behaviour) this.transform.GetChild(3).GetComponent<CustomImage>()).enabled = false;
    else
      this.transform.GetChild(3).GetComponent<CustomImage>().hander = (UILoadImageHander) GUIManager.Instance.m_ItemInfo;
    this.transform.GetChild(3).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) GUIManager.Instance.m_ItemInfo;
    this.transform.GetChild(3).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.MonsterType = (UIMapMonster.eMonsterType) arg2;
    MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey((ushort) arg1);
    UIText component1 = this.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.text = mStringTable.GetStringByID(8354U);
    this.RefreshTextList[(int) this.Listindex++] = component1;
    UIText component2 = this.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
    component2.font = ttfFont;
    component2.text = mStringTable.GetStringByID((uint) recordByKey.NameID);
    this.RefreshTextList[(int) this.Listindex++] = component2;
    this.ContentR = this.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>();
    Image component3 = ((Transform) this.ContentR).GetChild(0).GetChild(3).GetComponent<Image>();
    float num1 = 0.0f;
    for (int index = 0; index < 3; ++index)
    {
      CString cstring = StringManager.Instance.SpawnString(360);
      cstring.ClearString();
      component2 = ((Transform) this.ContentR).GetChild(0).GetChild(index).GetComponent<UIText>();
      component2.font = ttfFont;
      this.RefreshTextList[(int) this.Listindex++] = component2;
      cstring.StringToFormat(mStringTable.GetStringByID((uint) (8355 + index)));
      cstring.StringToFormat(mStringTable.GetStringByID((uint) recordByKey.Content[index]));
      cstring.AppendFormat("{0}{1}");
      component2.text = cstring.ToString();
      component2.SetAllDirty();
      component2.cachedTextGenerator.Invalidate();
      component2.cachedTextGeneratorForLayout.Invalidate();
      num1 += component2.preferredHeight;
      this.InfoStr.Add(cstring);
    }
    float num2 = 0.0f;
    if ((double) component2.preferredHeight + (double) ((Graphic) component2).rectTransform.anchoredPosition.y * -1.0 > (double) ((Graphic) component3).rectTransform.anchoredPosition.y * -1.0)
    {
      num2 = component2.preferredHeight - ((Graphic) component2).rectTransform.sizeDelta.y;
      ((Graphic) component3).rectTransform.anchoredPosition = new Vector2(((Graphic) component3).rectTransform.anchoredPosition.x, ((Graphic) component3).rectTransform.anchoredPosition.y - num2);
      ((Graphic) component2).rectTransform.sizeDelta = new Vector2(((Graphic) component2).rectTransform.sizeDelta.x, ((Graphic) component2).rectTransform.sizeDelta.y + num2);
    }
    CString cstring1 = StringManager.Instance.SpawnString(700);
    UIText component4 = ((Transform) this.ContentR).GetChild(0).GetChild(4).GetComponent<UIText>();
    component4.font = ttfFont;
    this.RefreshTextList[(int) this.Listindex++] = component4;
    if (this.MonsterType == UIMapMonster.eMonsterType.ResourceMonster)
    {
      cstring1.StringToFormat(mStringTable.GetStringByID(8340U));
      cstring1.StringToFormat(mStringTable.GetStringByID(8359U));
      cstring1.StringToFormat(mStringTable.GetStringByID(8360U));
      cstring1.StringToFormat(mStringTable.GetStringByID(8334U));
      cstring1.AppendFormat("{0}\n{1}\n{2}\n{3}");
    }
    else if (this.MonsterType == UIMapMonster.eMonsterType.SummonMonster)
    {
      cstring1.StringToFormat(mStringTable.GetStringByID(8340U));
      cstring1.StringToFormat(mStringTable.GetStringByID(8358U));
      cstring1.StringToFormat(mStringTable.GetStringByID(8360U));
      cstring1.StringToFormat(mStringTable.GetStringByID(8334U));
      cstring1.AppendFormat("{0}\n{1}\n{2}\n{3}");
    }
    else
    {
      cstring1.StringToFormat(mStringTable.GetStringByID(8340U));
      cstring1.StringToFormat(mStringTable.GetStringByID(8358U));
      cstring1.StringToFormat(mStringTable.GetStringByID(8359U));
      cstring1.StringToFormat(mStringTable.GetStringByID(8360U));
      cstring1.StringToFormat(mStringTable.GetStringByID(8334U));
      cstring1.AppendFormat("{0}\n{1}\n{2}\n{3}\n{4}");
    }
    component4.text = cstring1.ToString();
    component4.SetAllDirty();
    component4.cachedTextGenerator.Invalidate();
    component4.cachedTextGeneratorForLayout.Invalidate();
    this.InfoStr.Add(cstring1);
    if ((double) num2 > 0.0)
    {
      ((Graphic) component4).rectTransform.anchoredPosition = new Vector2(((Graphic) component4).rectTransform.anchoredPosition.x, ((Graphic) component4).rectTransform.anchoredPosition.y - num2);
      ((Graphic) component4).rectTransform.sizeDelta = new Vector2(((Graphic) component4).rectTransform.sizeDelta.x, ((Graphic) component4).rectTransform.sizeDelta.y - num2);
    }
    if ((double) num1 + (double) component4.preferredHeight <= 399.0)
    {
      ((Behaviour) this.transform.GetChild(2).GetComponent<CScrollRect>()).enabled = false;
      ((Behaviour) this.transform.GetChild(2).GetComponent<Mask>()).enabled = false;
      ((Behaviour) this.transform.GetChild(2).GetComponent<Image>()).enabled = false;
    }
    else
    {
      ((Graphic) component4).rectTransform.sizeDelta = new Vector2(((Graphic) component4).rectTransform.sizeDelta.x, component4.preferredHeight);
      this.ContentR.sizeDelta = new Vector2(this.ContentR.sizeDelta.x, (float) ((double) num1 + (double) component4.preferredHeight + 40.0));
      if ((double) component4.preferredHeight < 219.0)
        return;
      this.ContentR.anchoredPosition = new Vector2(this.ContentR.anchoredPosition.x, 16f);
    }
  }

  public override void OnClose()
  {
    for (int index = 0; index < this.InfoStr.Count; ++index)
      StringManager.Instance.DeSpawnString(this.InfoStr[index]);
  }

  public void OnButtonClick(UIButton sender)
  {
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
  }

  public override void UpdateNetwork(byte[] meg)
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
