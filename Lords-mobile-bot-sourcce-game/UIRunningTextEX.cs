// Decompiled with JetBrains decompiler
// Type: UIRunningTextEX
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIRunningTextEX : MonoBehaviour
{
  private RectTransform RC;
  public UIText m_RunningText1;
  public UIText m_RunningText2;
  public float Delta;
  public float UnitWidth;
  public int Speed = 25;
  private Vector2 Pos = new Vector2(0.0f, 0.0f);

  private RectTransform m_RC
  {
    get
    {
      if ((Object) this.RC == (Object) null)
        this.RC = this.transform.GetComponent<RectTransform>();
      return this.RC;
    }
  }

  private void Update()
  {
    // ISSUE: unable to decompile the method.
  }

  public void SetStr(byte Indedx)
  {
    UIText uiText;
    RectTransform rectTransform1;
    RectTransform rectTransform2;
    if (Indedx == (byte) 1)
    {
      uiText = this.m_RunningText1;
      rectTransform1 = ((Graphic) this.m_RunningText1).rectTransform;
      rectTransform2 = ((Graphic) this.m_RunningText2).rectTransform;
    }
    else
    {
      uiText = this.m_RunningText2;
      rectTransform1 = ((Graphic) this.m_RunningText2).rectTransform;
      rectTransform2 = ((Graphic) this.m_RunningText1).rectTransform;
    }
    GUIManager instance = GUIManager.Instance;
    if (instance.m_RunningTextList.Count > 0)
    {
      ((Behaviour) uiText).enabled = true;
      uiText.text = instance.m_RunningTextList[0].ToString();
      uiText.SetAllDirty();
      uiText.cachedTextGenerator.Invalidate();
      uiText.cachedTextGeneratorForLayout.Invalidate();
      instance.m_RunningTextList.RemoveAt(0);
      rectTransform1.sizeDelta = new Vector2(uiText.preferredWidth + 5f, rectTransform1.sizeDelta.y);
      rectTransform1.anchoredPosition = new Vector2(rectTransform2.anchoredPosition.x + rectTransform2.sizeDelta.x + this.m_RC.sizeDelta.x, rectTransform1.anchoredPosition.y);
    }
    else
      ((Behaviour) uiText).enabled = false;
  }

  public void CheckAddStr()
  {
    if (!this.gameObject.activeInHierarchy)
    {
      GUIManager instance = GUIManager.Instance;
      if (instance.m_RunningTextList.Count > 0)
      {
        this.gameObject.SetActive(true);
        ((Behaviour) this.m_RunningText1).enabled = true;
        this.m_RunningText1.text = instance.m_RunningTextList[0].ToString();
        this.m_RunningText1.SetAllDirty();
        this.m_RunningText1.cachedTextGenerator.Invalidate();
        this.m_RunningText1.cachedTextGeneratorForLayout.Invalidate();
        ((Graphic) this.m_RunningText1).rectTransform.sizeDelta = new Vector2(this.m_RunningText1.preferredWidth + 5f, ((Graphic) this.m_RunningText1).rectTransform.sizeDelta.y);
        ((Graphic) this.m_RunningText1).rectTransform.anchoredPosition = new Vector2(this.m_RC.sizeDelta.x, ((Graphic) this.m_RunningText1).rectTransform.anchoredPosition.y);
        instance.m_RunningTextList.RemoveAt(0);
      }
      if (instance.m_RunningTextList.Count > 0)
      {
        ((Behaviour) this.m_RunningText2).enabled = true;
        this.m_RunningText2.text = instance.m_RunningTextList[0].ToString();
        this.m_RunningText2.SetAllDirty();
        this.m_RunningText2.cachedTextGenerator.Invalidate();
        this.m_RunningText2.cachedTextGeneratorForLayout.Invalidate();
        instance.m_RunningTextList.RemoveAt(0);
        ((Graphic) this.m_RunningText2).rectTransform.sizeDelta = new Vector2(this.m_RunningText2.preferredWidth + 5f, ((Graphic) this.m_RunningText2).rectTransform.sizeDelta.y);
        ((Graphic) this.m_RunningText2).rectTransform.anchoredPosition = new Vector2((float) ((double) this.m_RC.sizeDelta.x + (double) this.m_RunningText1.preferredWidth + 5.0) + this.m_RC.sizeDelta.x, ((Graphic) this.m_RunningText2).rectTransform.anchoredPosition.y);
      }
      else
        ((Behaviour) this.m_RunningText2).enabled = false;
    }
    else
    {
      if (((Behaviour) this.m_RunningText1).enabled && !((Behaviour) this.m_RunningText2).enabled)
        this.SetStr((byte) 2);
      if (((Behaviour) this.m_RunningText1).enabled || !((Behaviour) this.m_RunningText2).enabled)
        return;
      this.SetStr((byte) 1);
    }
  }
}
