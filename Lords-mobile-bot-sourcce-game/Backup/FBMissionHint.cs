// Decompiled with JetBrains decompiler
// Type: FBMissionHint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class FBMissionHint
{
  public GameObject gameobject;
  private GameObject DeliverObj;
  private RectTransform DeliverRect;
  private _UIFBMissionAim[] MissionItem = new _UIFBMissionAim[2];
  private _UIFBMissionPrice[] MissionPrice = new _UIFBMissionPrice[2];
  private UIText TitleText;
  private UIText NameText;
  public float Height;
  public float Width = 437f;
  private ushort OwnPriceID;
  private ushort FriendPriceID;

  public FBMissionHint(Transform transform, Font font)
  {
    this.gameobject = transform.gameObject;
    this.NameText = transform.GetChild(0).GetComponent<UIText>();
    this.NameText.font = font;
    this.TitleText = transform.GetChild(1).GetComponent<UIText>();
    this.TitleText.font = font;
    this.TitleText.text = DataManager.Instance.mStringTable.GetStringByID(12157U);
    this.MissionItem[0] = new _UIFBMissionAim(transform.GetChild(2), font);
    this.MissionItem[1] = new _UIFBMissionAim(transform.GetChild(3), font);
    this.DeliverRect = transform.GetChild(4) as RectTransform;
    this.DeliverObj = ((Component) this.DeliverRect).gameObject;
    this.MissionPrice[0] = new _UIFBMissionPrice(transform.GetChild(5), font);
    this.MissionPrice[1] = new _UIFBMissionPrice(transform.GetChild(6), font);
    this.MissionPrice[0].SetTitle(DataManager.Instance.mStringTable.GetStringByID(12164U));
    this.MissionPrice[1].SetTitle(DataManager.Instance.mStringTable.GetStringByID(12158U));
  }

  public void Show(ushort ID)
  {
    this.gameobject.SetActive(true);
    FBMissionTbl recordByKey = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(ID);
    this.NameText.text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.Name);
    this.MissionItem[0].Set(ref recordByKey, (byte) 0);
    this.MissionItem[1].Set(ref recordByKey, (byte) 1);
    this.MissionItem[1].Top = (float) -(-(double) this.MissionItem[0].Top + (double) this.MissionItem[0].Height + 5.0);
    this.OwnPriceID = recordByKey.OwnPrice;
    this.FriendPriceID = recordByKey.FriendPrice;
    this.MissionPrice[0].Show(this.OwnPriceID);
    this.MissionPrice[1].Show(this.FriendPriceID);
    if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 7)
      this.SetStyle(FBMissionHint._Style.OwnPrice, this.MissionItem[1].Top - this.MissionItem[1].Height);
    else if (!DataManager.FBMissionDataManager.IsInTime() || DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex == (byte) 12)
      this.SetStyle(FBMissionHint._Style.FriendPrice, this.MissionItem[1].Top - this.MissionItem[1].Height);
    else
      this.SetStyle(FBMissionHint._Style.Both, this.MissionItem[1].Top - this.MissionItem[1].Height);
  }

  private void SetStyle(FBMissionHint._Style style, float beginTop)
  {
    switch (style)
    {
      case FBMissionHint._Style.OwnPrice:
        beginTop -= 28f;
        this.DeliverObj.SetActive(false);
        this.MissionPrice[0].Show(this.OwnPriceID);
        this.MissionPrice[0].Top = beginTop;
        this.MissionPrice[1].Hide();
        this.Height = (float) (-(double) beginTop + 97.0 + 30.0);
        break;
      case FBMissionHint._Style.FriendPrice:
        beginTop -= 26f;
        this.DeliverObj.SetActive(true);
        this.DeliverRect.anchoredPosition = new Vector2(this.DeliverRect.anchoredPosition.x, beginTop);
        this.MissionPrice[0].Hide();
        this.MissionPrice[1].Show(this.FriendPriceID);
        this.MissionPrice[1].Top = (float) ((double) beginTop - (double) this.DeliverRect.sizeDelta.y - 18.0);
        this.Height = (float) (-(double) this.MissionPrice[1].Top + 97.0 + 30.0);
        break;
      case FBMissionHint._Style.Both:
        beginTop -= 28f;
        this.MissionPrice[0].Show(this.OwnPriceID);
        this.MissionPrice[0].Top = beginTop;
        this.DeliverObj.SetActive(true);
        this.DeliverRect.anchoredPosition = new Vector2(this.DeliverRect.anchoredPosition.x, (float) ((double) this.MissionPrice[0].Top - 97.0 - 18.0));
        this.MissionPrice[1].Show(this.FriendPriceID);
        this.MissionPrice[1].Top = (float) ((double) this.DeliverRect.anchoredPosition.y - (double) this.DeliverRect.sizeDelta.y - 18.0);
        this.Height = (float) (-(double) this.MissionPrice[1].Top + 97.0 + 30.0);
        break;
    }
  }

  public void Hide() => this.gameobject.SetActive(false);

  public void TextRefresh()
  {
    ((Behaviour) this.NameText).enabled = false;
    ((Behaviour) this.NameText).enabled = true;
    ((Behaviour) this.TitleText).enabled = false;
    ((Behaviour) this.TitleText).enabled = true;
    this.MissionItem[0].TextRefresh();
    this.MissionItem[1].TextRefresh();
    this.MissionPrice[0].TextRefresh();
    this.MissionPrice[1].TextRefresh();
  }

  public void Destroy()
  {
    this.MissionItem[0].OnClose();
    this.MissionItem[1].OnClose();
    this.MissionPrice[0].OnClose();
    this.MissionPrice[1].OnClose();
  }

  public void UpdateData()
  {
    if (!this.gameobject.activeSelf)
      return;
    this.MissionItem[0].UpdateData();
    this.MissionItem[1].UpdateData();
  }

  private enum UIControl
  {
    Name,
    Title,
    Item1,
    Item2,
    Deliver,
    OwnPrice,
    FriendPrice,
  }

  private enum _Style
  {
    OwnPrice,
    FriendPrice,
    Both,
  }
}
