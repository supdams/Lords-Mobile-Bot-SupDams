// Decompiled with JetBrains decompiler
// Type: _MapHud
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class _MapHud
{
  public Transform ThisTransform;
  public CanvasGroup Alpha;
  public RectTransform RectTextBack;
  public UIText MsgText;
  private CString MsgStr;
  public float ShowTime;
  private bool bStartCountdown;
  private byte SkipMessage;

  public void Init(Transform transform)
  {
    GUIManager instance = GUIManager.Instance;
    this.ThisTransform = transform;
    CustomImage component1 = this.ThisTransform.GetComponent<CustomImage>();
    instance.m_ItemInfo.LoadCustomImage((Image) component1, component1.ImageName, component1.TextureName);
    CustomImage component2 = this.ThisTransform.GetChild(0).GetComponent<CustomImage>();
    instance.m_ItemInfo.LoadCustomImage((Image) component2, component2.ImageName, component2.TextureName);
    CustomImage component3 = this.ThisTransform.GetChild(1).GetComponent<CustomImage>();
    instance.m_ItemInfo.LoadCustomImage((Image) component3, component3.ImageName, component3.TextureName);
    this.MsgStr = StringManager.Instance.SpawnString(150);
    this.Alpha = this.ThisTransform.GetComponent<CanvasGroup>();
    this.RectTextBack = this.ThisTransform.GetChild(0).GetComponent<RectTransform>();
    this.MsgText = ((Transform) this.RectTextBack).GetChild(0).GetComponent<UIText>();
    this.MsgText.font = GUIManager.Instance.GetTTFFont();
    this.MsgText.text = string.Empty;
    this.SkipMessage = (byte) 0;
  }

  public void AddChangeKindomMapMsg()
  {
    if (this.SkipMessage > (byte) 0)
      return;
    CString str = StringManager.Instance.StaticString1024();
    this.MsgStr.ClearString();
    DataManager.MapDataController.GetKingdomName(DataManager.MapDataController.FocusKingdomID, ref str);
    this.MsgStr.StringToFormat(str);
    this.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(802U));
    this.MsgText.text = this.MsgStr.ToString();
    this.MsgText.SetAllDirty();
    this.MsgText.cachedTextGenerator.Invalidate();
  }

  public void AddManorMsg()
  {
    this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID(716U);
  }

  public void AddWorldMsg()
  {
    this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID(803U);
  }

  public void AddChapterMsg()
  {
    switch (DataManager.StageDataController._stageMode)
    {
      case StageMode.Full:
        this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID(716U + (uint) DataManager.StageDataController.currentChapterID);
        break;
      case StageMode.Lean:
        this.MsgStr.ClearString();
        this.MsgStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(60U));
        this.MsgStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(716U + (uint) DataManager.StageDataController.currentChapterID));
        this.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(59U));
        this.MsgText.text = this.MsgStr.ToString();
        this.MsgText.SetAllDirty();
        this.MsgText.cachedTextGenerator.Invalidate();
        break;
      case StageMode.Corps:
        if ((int) DataManager.StageDataController.StageRecord[2] == (int) DataManager.StageDataController.limitRecord[2])
          break;
        this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID((uint) (716 + (int) DataManager.StageDataController.StageRecord[2] + 1));
        break;
      case StageMode.Dare:
        this.MsgStr.ClearString();
        this.MsgStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(10042U));
        this.MsgStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(716U + (uint) DataManager.StageDataController.currentChapterID));
        this.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(59U));
        this.MsgText.text = this.MsgStr.ToString();
        this.MsgText.SetAllDirty();
        this.MsgText.cachedTextGenerator.Invalidate();
        break;
    }
  }

  public void AddGambleMsg()
  {
    if (this.ThisTransform.gameObject.activeSelf)
      this.ThisTransform.gameObject.SetActive(false);
    if (BattleController.GambleMode == EGambleMode.Normal)
      this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID(9171U);
    else
      this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID(9179U);
  }

  public void SkipMsg() => this.SkipMessage = (byte) 1;

  public void ShowMsg()
  {
    if (this.SkipMessage > (byte) 0)
    {
      this.SkipMessage = (byte) 0;
    }
    else
    {
      if (this.MsgText.text == string.Empty || this.ThisTransform.gameObject.activeSelf)
        return;
      this.ThisTransform.gameObject.SetActive(true);
      this.Alpha.alpha = 1f;
      this.ShowTime = 0.5f;
      this.bStartCountdown = false;
      if ((double) this.MsgText.preferredWidth <= (double) this.RectTextBack.sizeDelta.x)
        return;
      this.RectTextBack.sizeDelta = this.RectTextBack.sizeDelta with
      {
        x = this.MsgText.preferredWidth
      };
    }
  }

  public void StartCountdown() => this.bStartCountdown = true;

  public void Update()
  {
    if (!this.bStartCountdown || (Object) this.ThisTransform == (Object) null || !this.ThisTransform.gameObject.activeSelf)
      return;
    float num = -0.2f;
    if ((double) this.ShowTime < 0.0)
    {
      this.Alpha.alpha = (float) (1.0 - (double) this.ShowTime / (double) num);
      if ((double) this.ShowTime < (double) num)
      {
        this.MsgText.text = string.Empty;
        this.ThisTransform.gameObject.SetActive(false);
      }
    }
    this.ShowTime -= Time.unscaledDeltaTime;
  }

  public void Destroy() => StringManager.Instance.DeSpawnString(this.MsgStr);
}
