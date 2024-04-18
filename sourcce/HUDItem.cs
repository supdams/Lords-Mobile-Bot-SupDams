// Decompiled with JetBrains decompiler
// Type: HUDItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class HUDItem
{
  public Transform ThisTransform;
  public ArabicItemTextureRot TextureRot;
  public RectTransform IconTransform;
  public CanvasGroup Alpha;
  public Image Icon;
  public UIText MsgText;
  public float DelayTime;
  public float FadeTime;
  public float ShowIconTime;
  private int Index;
  public Hudhandle Handle;
  public UIKind SFXKind;
  public CString MsgStr;
  public CString IconStr;
  public bool bColseItem;
  public byte MP3Sound;

  public void Init(int index, Transform transform)
  {
    this.Index = index;
    this.ThisTransform = transform;
    this.Alpha = this.ThisTransform.GetComponent<CanvasGroup>();
    this.IconTransform = this.ThisTransform.GetChild(0).GetComponent<RectTransform>();
    this.Icon = this.ThisTransform.GetChild(0).GetComponent<Image>();
    this.TextureRot = ((Component) this.IconTransform).GetComponent<ArabicItemTextureRot>();
    this.MsgText = this.ThisTransform.GetChild(1).GetComponent<UIText>();
    this.MsgText.font = GUIManager.Instance.GetTTFFont();
    this.MsgStr = StringManager.Instance.SpawnString(160);
    this.IconStr = StringManager.Instance.SpawnString();
    this.bColseItem = false;
  }

  public void CloneText(string text)
  {
    this.MsgStr.ClearString();
    this.MsgStr.Append(text);
    this.MsgText.text = this.MsgStr.ToString();
    this.MsgText.SetAllDirty();
    this.MsgText.cachedTextGenerator.Invalidate();
  }

  public void AddMessage(string Msg, ushort ID)
  {
    HUDTypeTbl recordByKey = DataManager.Instance.HUDTypeData.GetRecordByKey(ID);
    this.ThisTransform.gameObject.SetActive(true);
    this.Alpha.alpha = 0.0f;
    this.FadeTime = -0.5f;
    this.ShowIconTime = 0.0f;
    this.MsgStr.ClearString();
    this.MsgStr.Append(Msg);
    this.MsgText.text = this.MsgStr.ToString();
    this.MsgText.SetAllDirty();
    this.MsgText.cachedTextGenerator.Invalidate();
    if (recordByKey.TextColor > (byte) 0 && HUDMessageMgr.HUDColor.Length >= (int) recordByKey.TextColor)
      ((Graphic) this.MsgText).color = HUDMessageMgr.HUDColor[(int) recordByKey.TextColor - 1];
    else
      ((Graphic) this.MsgText).color = Color.white;
    this.IconStr.ClearString();
    this.IconStr.IntToFormat((long) recordByKey.Graphic, 3);
    this.IconStr.AppendFormat("icon{0}");
    if (recordByKey.Graphic == (byte) 33 || recordByKey.Graphic == (byte) 55)
    {
      if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
        this.IconStr.Append("_cn");
      else if (GUIManager.Instance.IsArabic)
        ((Behaviour) this.TextureRot).enabled = true;
    }
    else if (recordByKey.Graphic == (byte) 39)
    {
      if (GUIManager.Instance.IsArabic)
        ((Behaviour) this.TextureRot).enabled = true;
    }
    else
      ((Behaviour) this.TextureRot).enabled = false;
    this.Icon.sprite = GUIManager.Instance.LoadFrameSprite(this.IconStr);
    ((MaskableGraphic) this.Icon).material = GUIManager.Instance.GetFrameMaterial();
    if ((Object) this.Icon.sprite == (Object) null)
      this.Icon.sprite = GUIManager.Instance.LoadFrameSprite("icon021");
    this.DelayTime = (float) ((int) recordByKey.DelayTime / 10);
    this.SFXKind = recordByKey.Sound != 0U ? (UIKind) recordByKey.Sound : UIKind.None;
    this.MP3Sound = recordByKey.Mp3Sound;
    this.bColseItem = true;
  }

  public void Destroy()
  {
    StringManager.Instance.DeSpawnString(this.MsgStr);
    StringManager.Instance.DeSpawnString(this.IconStr);
  }

  public void Update()
  {
    if (!this.bColseItem)
      return;
    float unscaledDeltaTime = Time.unscaledDeltaTime;
    if (this.SFXKind != UIKind.None)
    {
      if (this.MP3Sound == (byte) 1)
        AudioManager.Instance.PlayMP3SFX((ushort) this.SFXKind);
      else
        AudioManager.Instance.PlayUISFX(this.SFXKind);
      this.SFXKind = UIKind.None;
    }
    if ((double) this.ShowIconTime < 0.25)
    {
      Vector3 localScale = ((Transform) this.IconTransform).localScale;
      ((Transform) this.IconTransform).localScale = Vector3.one * HUDMessageMgr.Quintic(this.ShowIconTime, 0.0f, 1f, 0.25f);
      this.ShowIconTime += unscaledDeltaTime;
    }
    else
      ((Transform) this.IconTransform).localScale = Vector3.one;
    if ((double) this.DelayTime >= 0.0)
    {
      this.Alpha.alpha = 1f;
    }
    else
    {
      this.Alpha.alpha = (float) (1.0 - (double) this.DelayTime / (double) this.FadeTime);
      if ((double) this.Alpha.alpha <= 0.0099999997764825821)
      {
        this.ThisTransform.gameObject.SetActive(false);
        if (this.Handle != null)
        {
          this.Handle.OnDestroyMessage(this.Index);
          this.bColseItem = false;
        }
      }
    }
    this.DelayTime -= unscaledDeltaTime;
  }
}
