// Decompiled with JetBrains decompiler
// Type: UIAlliance_Rank
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAlliance_Rank : IUIButtonDownUpHandler
{
  private const float ZVal = 0.0f;
  private Transform transform;
  private Transform[] RankPoint = new Transform[5];
  private float[] Widths = new float[5];
  private UIAlliance_Control RankAnime = new UIAlliance_Control();
  private RectTransform ImgUpRect;
  private RectTransform ImgDownRect;
  private Image ImgDown;
  private Image ImgUp;
  private byte SavedData;
  private byte AMRank;
  private byte mMobilizationFutureRank;

  public void OnOpen(Transform transform)
  {
    this.transform = transform;
    for (byte index = 0; (int) index < this.RankPoint.Length; ++index)
    {
      GUIManager.Instance.SetAllyRankImage(transform.GetChild(0).GetChild((int) index).GetChild(0).GetComponent<Image>(), index);
      this.Widths[(int) index] = transform.GetChild(0).GetChild((int) index).GetComponent<RectTransform>().sizeDelta.x;
      UIButtonHint uiButtonHint = transform.GetChild(0).GetChild((int) index).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint.m_DownUpHandler = (IUIButtonDownUpHandler) this;
      uiButtonHint.Parm1 = (ushort) (1028U - (uint) index);
      this.RankPoint[(int) index] = transform.GetChild(1).GetChild((int) index);
      RectTransform component = transform.GetChild(0).GetChild((int) index).GetComponent<RectTransform>();
      component.anchoredPosition = new Vector2(component.anchoredPosition.x, component.anchoredPosition.y + 33f);
      this.RankPoint[(int) index].localPosition = new Vector3(this.RankPoint[(int) index].localPosition.x, this.RankPoint[(int) index].localPosition.y + 33f, this.RankPoint[(int) index].localPosition.z);
      if (index == (byte) 4)
        ((Component) component).gameObject.SetActive(false);
    }
    this.ImgUpRect = transform.GetChild(0).GetChild(5).GetComponent<RectTransform>();
    this.ImgUp = ((Component) this.ImgUpRect).GetComponent<Image>();
    this.ImgDownRect = transform.GetChild(0).GetChild(6).GetComponent<RectTransform>();
    this.ImgDown = ((Component) this.ImgDownRect).GetComponent<Image>();
    this.RankAnime.Initial(transform.GetChild(1).GetChild(5).GetComponent<Image>());
  }

  public void UpdateRank()
  {
    if ((int) this.AMRank == (int) DataManager.Instance.RoleAlliance.AMRank && (int) this.mMobilizationFutureRank == (int) MobilizationManager.Instance.mMobilizationFutureRank && (Object) this.RankAnime.animImg.sprite != (Object) null)
      return;
    this.AMRank = DataManager.Instance.RoleAlliance.AMRank;
    this.mMobilizationFutureRank = MobilizationManager.Instance.mMobilizationFutureRank;
    byte index1 = (byte) Mathf.Clamp((int) this.mMobilizationFutureRank, 0, 5);
    byte index2 = (byte) Mathf.Clamp((int) this.AMRank, 0, 5);
    ((Component) this.ImgUpRect).gameObject.SetActive(false);
    ((Component) this.ImgDownRect).gameObject.SetActive(false);
    UIAlliance_Control.eRankState state = (int) index1 == (int) index2 ? UIAlliance_Control.eRankState.RankEqual : ((int) index1 <= (int) index2 ? ((int) index1 >= (int) index2 ? UIAlliance_Control.eRankState.RankEqual : UIAlliance_Control.eRankState.RankDown) : UIAlliance_Control.eRankState.RankUp);
    bool flag = false;
    if ((int) index1 != (int) index2)
    {
      if (!byte.TryParse(PlayerPrefs.GetString("Alliance_RankAM"), out this.SavedData))
      {
        if (state != UIAlliance_Control.eRankState.RankEqual)
          flag = true;
      }
      else if ((int) this.SavedData / 10 != (int) index1 || (int) this.SavedData % 10 != (int) index2)
        flag = true;
    }
    this.SavedData = (byte) ((uint) index1 * 10U + (uint) index2);
    PlayerPrefs.SetString("Alliance_RankAM", this.SavedData.ToString());
    this.RankAnime.SetAnimState(state);
    if (flag)
    {
      if (state == UIAlliance_Control.eRankState.RankUp)
      {
        ((Transform) this.RankAnime.rectTransform).localPosition = new Vector3(this.RankPoint[(int) index2].localPosition.x, this.RankPoint[(int) index2].localPosition.y, 0.0f);
        float angle = 135f;
        ((Component) this.ImgUpRect).gameObject.SetActive(true);
        this.ImgUpRect.anchoredPosition = new Vector2(this.ImgUpRect.anchoredPosition.x, (float) (55.0 + 66.0 * (double) index2 - -2.0));
        this.RankAnime.MoveTo(this.RankPoint[(int) index1], 0.0f, angle);
      }
      else
      {
        if (state != UIAlliance_Control.eRankState.RankDown)
          return;
        ((Transform) this.RankAnime.rectTransform).localPosition = new Vector3(this.RankPoint[(int) index2].localPosition.x, this.RankPoint[(int) index2].localPosition.y, 0.0f);
        float angle = 315f;
        ((Component) this.ImgDownRect).gameObject.SetActive(true);
        this.ImgDownRect.anchoredPosition = new Vector2(this.ImgDownRect.anchoredPosition.x, (float) (66.0 * (double) index2 - 43.0 - -2.0));
        this.RankAnime.MoveTo(this.RankPoint[(int) index1], 0.0f, angle);
      }
    }
    else
    {
      switch (state)
      {
        case UIAlliance_Control.eRankState.RankUp:
          ((Component) this.ImgUpRect).gameObject.SetActive(true);
          this.ImgUpRect.anchoredPosition = new Vector2(this.ImgUpRect.anchoredPosition.x, (float) (55.0 + 66.0 * (double) index2 - -2.0));
          break;
        case UIAlliance_Control.eRankState.RankDown:
          ((Component) this.ImgDownRect).gameObject.SetActive(true);
          this.ImgDownRect.anchoredPosition = new Vector2(this.ImgDownRect.anchoredPosition.x, (float) (66.0 * (double) index2 - 43.0 - -2.0));
          break;
      }
      ((Transform) this.RankAnime.rectTransform).localPosition = new Vector3(this.RankPoint[(int) index1].localPosition.x, this.RankPoint[(int) index1].localPosition.y, 0.0f);
    }
  }

  public void OnClose() => this.RankAnime.Destroy();

  public void SetActive(bool bActive)
  {
    this.transform.gameObject.SetActive(bActive);
    if (!bActive)
      return;
    this.UpdateRank();
    this.SetAnimVisible = true;
  }

  public bool SetAnimVisible
  {
    set
    {
      ((Component) this.RankAnime.rectTransform).gameObject.SetActive(value);
      ((Behaviour) this.ImgDown).enabled = value;
      ((Behaviour) this.ImgUp).enabled = value;
    }
  }

  public void UpdateUI(int arg1, int arg2) => this.UpdateRank();

  public void UpdateTime(bool bOnSecond)
  {
    if (!this.transform.gameObject.activeSelf)
      return;
    this.RankAnime.Update();
  }

  public void UpdateNetwork(byte[] meg)
  {
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 277f, 20, (int) sender.Parm1, 0, new Vector2(this.Widths[4 - ((int) sender.Parm1 - 1024)] * 0.5f, 0.0f));
  }

  public void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide();

  private enum UIControl
  {
    Rank,
    AnimPoint,
  }
}
