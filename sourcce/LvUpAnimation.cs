// Decompiled with JetBrains decompiler
// Type: LvUpAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal class LvUpAnimation
{
  private const int MAX_STEP = 3;
  private KeyValuePair<float, float>[] ICON_IMG_ROTATION = new KeyValuePair<float, float>[3];
  private KeyValuePair<float, float>[] ICON_IMG_ROTATION2 = new KeyValuePair<float, float>[3];
  private KeyValuePair<float, Vector2>[] EXP_IMG_POS = new KeyValuePair<float, Vector2>[3];
  private KeyValuePair<float, float>[] EXP_IMG_ALPHA = new KeyValuePair<float, float>[3];
  private KeyValuePair<float, Vector2>[] TEXT_IMG_POS = new KeyValuePair<float, Vector2>[3];
  private KeyValuePair<float, float>[] TEXT_IMG_ALPHA = new KeyValuePair<float, float>[4];
  private float m_AnimationTime;
  private float m_TotalTime = 3f;
  private float[] m_ChangeTime = new float[3];
  private bool[] m_SetChage = new bool[3];
  private Image m_ExpImg;
  private UIText m_ExpText;
  private Image m_Icon;
  private LvUpAnimation.EAnimState m_State;
  private ushort m_SkillID;

  public void Init(Image expImg, UIText expText)
  {
    this.EXP_IMG_POS[0] = new KeyValuePair<float, Vector2>(0.0f, new Vector2(0.0f, -30f));
    this.EXP_IMG_POS[1] = new KeyValuePair<float, Vector2>(0.5f, new Vector2(0.0f, 0.0f));
    this.EXP_IMG_POS[2] = new KeyValuePair<float, Vector2>(1f, new Vector2(0.0f, 30f));
    this.EXP_IMG_ALPHA[0] = new KeyValuePair<float, float>(0.0f, 0.0f);
    this.EXP_IMG_ALPHA[1] = new KeyValuePair<float, float>(0.5f, 1f);
    this.EXP_IMG_ALPHA[2] = new KeyValuePair<float, float>(1f, 0.0f);
    this.TEXT_IMG_POS[0] = new KeyValuePair<float, Vector2>(0.0f, new Vector2(0.0f, -30f));
    this.TEXT_IMG_POS[1] = new KeyValuePair<float, Vector2>(1f, new Vector2(0.0f, 30f));
    this.TEXT_IMG_ALPHA[0] = new KeyValuePair<float, float>(0.0f, 1f);
    this.TEXT_IMG_ALPHA[1] = new KeyValuePair<float, float>(1f, 1f);
    this.m_ChangeTime[0] = 0.0f;
    this.m_ChangeTime[1] = 0.0f;
    this.m_ChangeTime[1] = 0.0f;
    this.m_SetChage[0] = false;
    this.m_SetChage[1] = false;
    this.m_SetChage[2] = true;
    this.Set(expImg, expText);
  }

  public void Init(Image expImg, UIText expText, Image icon)
  {
    this.ICON_IMG_ROTATION[0] = new KeyValuePair<float, float>(0.0f, 0.0f);
    this.ICON_IMG_ROTATION[1] = new KeyValuePair<float, float>(0.5f, 180f);
    this.EXP_IMG_POS[0] = new KeyValuePair<float, Vector2>(0.5f, new Vector2(0.0f, -30f));
    this.EXP_IMG_POS[1] = new KeyValuePair<float, Vector2>(0.75f, new Vector2(0.0f, 0.0f));
    this.EXP_IMG_POS[2] = new KeyValuePair<float, Vector2>(1.5f, new Vector2(0.0f, 30f));
    this.EXP_IMG_ALPHA[0] = new KeyValuePair<float, float>(0.5f, 0.0f);
    this.EXP_IMG_ALPHA[1] = new KeyValuePair<float, float>(0.75f, 1f);
    this.EXP_IMG_ALPHA[2] = new KeyValuePair<float, float>(1.5f, 0.0f);
    this.TEXT_IMG_POS[0] = new KeyValuePair<float, Vector2>(0.5f, new Vector2(0.0f, -30f));
    this.TEXT_IMG_POS[1] = new KeyValuePair<float, Vector2>(1.5f, new Vector2(0.0f, 30f));
    this.TEXT_IMG_ALPHA[0] = new KeyValuePair<float, float>(0.5f, 1f);
    this.TEXT_IMG_ALPHA[1] = new KeyValuePair<float, float>(1f, 1f);
    this.ICON_IMG_ROTATION2[0] = new KeyValuePair<float, float>(1.5f, 180f);
    this.ICON_IMG_ROTATION2[1] = new KeyValuePair<float, float>(2.5f, 0.0f);
    Image component = ((Component) icon).transform.GetChild(0).gameObject.GetComponent<Image>();
    component.sprite = GUIManager.Instance.LoadFrameSprite("sk");
    ((MaskableGraphic) component).material = GUIManager.Instance.GetFrameMaterial();
    this.m_ChangeTime[0] = 0.25f;
    this.m_ChangeTime[1] = 1.75f;
    this.m_ChangeTime[2] = 0.5f;
    this.m_SetChage[0] = true;
    this.m_SetChage[1] = true;
    this.m_SetChage[1] = true;
    this.m_SkillID = (ushort) 1;
    this.Set(expImg, expText, icon);
  }

  private void Set(Image expImg, UIText expText, Image icon = null)
  {
    this.m_ExpImg = expImg;
    this.m_ExpText = expText;
    this.m_Icon = icon;
    this.End();
  }

  public void Run()
  {
    if (this.m_State != LvUpAnimation.EAnimState.eStart)
      return;
    this.m_AnimationTime += Time.deltaTime;
    this.RunLvImg(this.m_AnimationTime);
    this.RunExpText(this.m_AnimationTime);
    this.RunRotation1(this.m_AnimationTime);
    this.RunRotation2(this.m_AnimationTime);
    if ((double) this.m_AnimationTime > (double) this.m_TotalTime)
      this.End();
    if (this.m_SetChage[0] && (double) this.m_AnimationTime >= (double) this.m_ChangeTime[0])
    {
      this.Change(this.m_SkillID);
      this.m_SetChage[0] = false;
    }
    if (this.m_SetChage[1] && (double) this.m_AnimationTime >= (double) this.m_ChangeTime[1])
    {
      this.Change((ushort) 0);
      this.m_SetChage[1] = false;
    }
    if (!this.m_SetChage[2] || (double) this.m_AnimationTime < (double) this.m_ChangeTime[2])
      return;
    if ((Object) this.m_ExpText != (Object) null)
      ((Behaviour) this.m_ExpText).enabled = true;
    this.m_SetChage[2] = false;
  }

  public void RunLvImg(float animationTime)
  {
    if (!((Object) this.m_ExpImg != (Object) null))
      return;
    for (int index = 0; index < this.EXP_IMG_POS.Length - 1; ++index)
    {
      float num = this.EXP_IMG_POS[index + 1].Key - this.EXP_IMG_POS[index].Key;
      if ((double) num > 0.0)
      {
        float t = (animationTime - this.EXP_IMG_POS[index].Key) / num;
        if ((double) this.m_AnimationTime > (double) this.EXP_IMG_POS[index].Key && (double) this.m_AnimationTime <= (double) this.EXP_IMG_POS[index + 1].Key)
          ((Graphic) this.m_ExpImg).rectTransform.anchoredPosition = Vector2.Lerp(this.EXP_IMG_POS[index].Value, this.EXP_IMG_POS[index + 1].Value, t);
      }
    }
    for (int index = 0; index < this.EXP_IMG_ALPHA.Length - 1; ++index)
    {
      float num = this.EXP_IMG_POS[index + 1].Key - this.EXP_IMG_POS[index].Key;
      if ((double) num > 0.0)
      {
        float t = (animationTime - this.EXP_IMG_ALPHA[index].Key) / num;
        if ((double) this.m_AnimationTime > (double) this.EXP_IMG_ALPHA[index].Key && (double) this.m_AnimationTime <= (double) this.EXP_IMG_ALPHA[index + 1].Key)
          ((Graphic) this.m_ExpImg).color = ((Graphic) this.m_ExpImg).color with
          {
            a = Mathf.Lerp(this.EXP_IMG_ALPHA[index].Value, this.EXP_IMG_ALPHA[index + 1].Value, t)
          };
      }
    }
  }

  public void RunExpText(float animationTime)
  {
    if (!((Object) this.m_ExpText != (Object) null))
      return;
    Color color = ((Graphic) this.m_ExpText).color;
    for (int index = 0; index < this.TEXT_IMG_POS.Length - 1; ++index)
    {
      float num = this.TEXT_IMG_POS[index + 1].Key - this.TEXT_IMG_POS[index].Key;
      if ((double) num > 0.0)
      {
        float t = (animationTime - this.TEXT_IMG_POS[index].Key) / num;
        if ((double) this.m_AnimationTime > (double) this.TEXT_IMG_POS[index].Key && (double) this.m_AnimationTime <= (double) this.TEXT_IMG_POS[index + 1].Key)
          ((Graphic) this.m_ExpText).rectTransform.anchoredPosition = Vector2.Lerp(this.TEXT_IMG_POS[index].Value, this.TEXT_IMG_POS[index + 1].Value, t);
      }
    }
    for (int index = 0; index < this.TEXT_IMG_ALPHA.Length - 1; ++index)
    {
      float num = this.TEXT_IMG_ALPHA[index + 1].Key - this.TEXT_IMG_ALPHA[index].Key;
      if ((double) num > 0.0)
      {
        float t = (animationTime - this.TEXT_IMG_POS[index].Key) / num;
        if ((double) this.m_AnimationTime > (double) this.TEXT_IMG_POS[index].Key && (double) this.m_AnimationTime <= (double) this.TEXT_IMG_ALPHA[index + 1].Key)
          ((Graphic) this.m_ExpText).color = ((Graphic) this.m_ExpText).color with
          {
            a = Mathf.Lerp(this.TEXT_IMG_ALPHA[index].Value, this.TEXT_IMG_ALPHA[index + 1].Value, t)
          };
      }
    }
  }

  private void RunRotation1(float animationTime)
  {
    if (!((Object) this.m_Icon != (Object) null))
      return;
    for (int index = 0; index < this.ICON_IMG_ROTATION.Length - 1; ++index)
    {
      float num = this.ICON_IMG_ROTATION[index + 1].Key - this.ICON_IMG_ROTATION[index].Key;
      if ((double) num > 0.0)
      {
        float t = (animationTime - this.ICON_IMG_ROTATION[index].Key) / num;
        if ((double) this.m_AnimationTime > (double) this.ICON_IMG_ROTATION[index].Key && (double) this.m_AnimationTime <= (double) this.ICON_IMG_ROTATION[index + 1].Key)
          ((Component) this.m_Icon).transform.localRotation = Quaternion.Euler(new Vector3(0.0f, Mathf.Lerp(this.ICON_IMG_ROTATION[index].Value, this.ICON_IMG_ROTATION[index + 1].Value, t), 0.0f));
      }
    }
  }

  private void RunRotation2(float animationTime)
  {
    if (!((Object) this.m_Icon != (Object) null))
      return;
    for (int index = 0; index < this.ICON_IMG_ROTATION2.Length - 1; ++index)
    {
      float num = this.ICON_IMG_ROTATION2[index + 1].Key - this.ICON_IMG_ROTATION2[index].Key;
      if ((double) num > 0.0)
      {
        float t = (animationTime - this.ICON_IMG_ROTATION2[index].Key) / num;
        if ((double) animationTime > (double) this.ICON_IMG_ROTATION2[index].Key && (double) animationTime <= (double) this.ICON_IMG_ROTATION2[index + 1].Key)
          ((Component) this.m_Icon).transform.localRotation = Quaternion.Euler(new Vector3(0.0f, Mathf.Lerp(this.ICON_IMG_ROTATION2[index].Value, this.ICON_IMG_ROTATION2[index + 1].Value, t), 0.0f));
      }
    }
  }

  private void Change(ushort skillID)
  {
    if (!((Object) this.m_Icon != (Object) null))
      return;
    this.m_Icon.sprite = PetManager.Instance.LoadPetSkillIcon(skillID);
    ((MaskableGraphic) this.m_Icon).material = GUIManager.Instance.GetSkillMaterial();
  }

  public void Start(CString str, uint exp, ushort skillID)
  {
    this.m_State = LvUpAnimation.EAnimState.eStart;
    this.m_AnimationTime = 0.0f;
    this.m_SetChage[0] = true;
    this.m_SetChage[1] = true;
    this.m_SetChage[2] = true;
    if ((Object) this.m_ExpImg != (Object) null && !((Component) this.m_ExpImg).gameObject.activeInHierarchy)
    {
      ((Component) this.m_ExpImg).gameObject.SetActive(true);
      ((Behaviour) this.m_ExpText).enabled = false;
    }
    if ((Object) this.m_ExpText != (Object) null && !((Component) this.m_ExpText).gameObject.activeInHierarchy)
      ((Component) this.m_ExpText).gameObject.SetActive(true);
    if ((Object) this.m_ExpText != (Object) null && (Object) this.m_ExpText != (Object) null)
    {
      str.ClearString();
      str.IntToFormat((long) exp, bNumber: true);
      str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(55U));
      this.m_ExpText.text = str.ToString();
    }
    this.m_SkillID = skillID;
    AudioManager.Instance.PlayUISFX(UIKind.PetAddExp);
  }

  public void End()
  {
    this.m_State = LvUpAnimation.EAnimState.eEnd;
    this.m_AnimationTime = this.m_TotalTime;
    if ((Object) this.m_Icon != (Object) null)
      ((Component) this.m_Icon).transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
    this.Change((ushort) 0);
    if ((Object) this.m_ExpImg != (Object) null && ((Component) this.m_ExpImg).gameObject.activeSelf)
      ((Component) this.m_ExpImg).gameObject.SetActive(false);
    if (!((Object) this.m_ExpText != (Object) null) || !((Component) this.m_ExpText).gameObject.activeSelf)
      return;
    ((Component) this.m_ExpText).gameObject.SetActive(false);
  }

  private enum EAnimState
  {
    eStart,
    eChange1,
    eChange2,
    eEnd,
  }
}
