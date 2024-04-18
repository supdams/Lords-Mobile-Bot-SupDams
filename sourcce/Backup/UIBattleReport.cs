// Decompiled with JetBrains decompiler
// Type: UIBattleReport
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIBattleReport : 
  GUIWindow,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private const float BtnDleta = 88f;
  private const float BlockDleta = 10f;
  private Transform m_transform;
  private DataManager DM;
  private GUIManager GM;
  private Font tmpFont;
  public Transform ContentT;
  private RectTransform ContentRC;
  private RectTransform ScrollRC;
  private GameObject tmpBlock;
  private GameObject ExpBlock;
  private float BlockTop;
  private float tmpHeight;
  private int bonusCount;
  private bool bHasBonus;
  private int NowIndex;
  private int NowRWIndex;
  private bool bMove = true;
  private float TickTimes = 0.6f;
  private float TickCount = 1.5f;
  private float moveDelta;
  private RectTransform[][] HintRC = new RectTransform[10][];
  private Image m_HintBox;
  private UIText m_HintText;
  private byte bHintOpen;
  private float HintTime;
  private UIText[] RBText = new UIText[2];
  private UIText[][] RBBlockText = new UIText[10][];
  private UIText BonusText;
  private CString[][] BlockTextStr = new CString[10][];

  public override void OnOpen(int arg1, int arg2)
  {
    this.m_transform = this.transform;
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.tmpFont = this.GM.GetTTFFont();
    this.m_transform.GetChild(1).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.ScrollRC = this.m_transform.GetChild(0).GetComponent<RectTransform>();
    this.ContentT = this.m_transform.GetChild(0).GetChild(0);
    this.ContentRC = this.ContentT.GetComponent<RectTransform>();
    this.tmpBlock = this.ContentT.GetChild(1).gameObject;
    this.ExpBlock = this.ContentT.GetChild(2).gameObject;
    this.RBText[0] = this.m_transform.GetChild(3).GetComponent<UIText>();
    this.RBText[0].text = this.DM.mStringTable.GetStringByID(151U);
    this.RBText[0].font = this.tmpFont;
    this.ExpBlock.transform.GetChild(1).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.RBText[1] = this.ExpBlock.transform.GetChild(1).GetChild(2).GetComponent<UIText>();
    this.RBText[1].text = this.DM.mStringTable.GetStringByID(739U);
    this.RBText[1].font = this.tmpFont;
    this.m_HintBox = this.m_transform.GetChild(4).GetComponent<Image>();
    ((Graphic) this.m_HintBox).rectTransform.sizeDelta = new Vector2(350f, 60f);
    this.m_HintText = this.m_transform.GetChild(4).GetChild(0).GetComponent<UIText>();
    this.m_HintText.font = this.tmpFont;
    this.m_HintText.horizontalOverflow = (HorizontalWrapMode) 0;
    float num = 0.0f;
    for (int index = 0; index < (int) this.DM.QBTimes; ++index)
      num += this.GetBlockHeight((int) this.DM.QBRewardLen[index]) + 10f;
    if (this.DM.ExpItemCount > (byte) 0)
    {
      this.bHasBonus = true;
      this.bonusCount = (int) this.DM.ExpItemCount;
    }
    if (this.bHasBonus)
      num += this.GetBlockHeight(this.bonusCount, true);
    else
      Object.Destroy((Object) this.ContentT.GetChild(0).gameObject);
    this.ContentRC.sizeDelta = new Vector2(this.ContentRC.sizeDelta.x, num + 102f);
    ((Behaviour) this.m_transform.GetChild(0).GetComponent<ScrollRect>()).enabled = false;
    this.GM.UpdateUI(EGUIWindow.Door, 1, 1);
  }

  public override void OnClose()
  {
    for (int index1 = 0; index1 < this.BlockTextStr.Length; ++index1)
    {
      if (this.BlockTextStr[index1] != null)
      {
        for (int index2 = 0; index2 < this.BlockTextStr[index1].Length; ++index2)
        {
          if (this.BlockTextStr[index1][index2] != null)
            StringManager.Instance.DeSpawnString(this.BlockTextStr[index1][index2]);
        }
      }
    }
  }

  private void Update()
  {
    float smoothDeltaTime = Time.smoothDeltaTime;
    if ((double) this.TickCount != -1.0)
      this.TickCount += smoothDeltaTime;
    if ((double) this.TickCount >= (double) this.TickTimes)
    {
      this.TickCount = 0.0f;
      if (this.NowIndex < (int) this.DM.QBTimes)
      {
        this.RBBlockText[this.NowIndex] = new UIText[4];
        this.BlockTextStr[this.NowIndex] = new CString[3];
        int index1 = !this.bHasBonus ? this.NowIndex + 2 : this.NowIndex + 3;
        GameObject gameObject1 = Object.Instantiate((Object) this.tmpBlock) as GameObject;
        gameObject1.SetActive(true);
        gameObject1.transform.SetParent(this.ContentT, false);
        RectTransform component1 = gameObject1.GetComponent<RectTransform>();
        ((Transform) component1).localPosition = new Vector3(((Transform) component1).localPosition.x, -this.BlockTop, 0.0f);
        this.tmpHeight = this.GetBlockHeight((int) this.DM.QBRewardLen[this.NowIndex]);
        component1.sizeDelta = new Vector2(component1.sizeDelta.x, this.tmpHeight);
        this.BlockTop += this.tmpHeight + 10f;
        Transform child = this.ContentT.GetChild(index1);
        this.BlockTextStr[this.NowIndex][0] = StringManager.Instance.SpawnString();
        this.BlockTextStr[this.NowIndex][0].IntToFormat((long) (this.NowIndex + 1));
        this.BlockTextStr[this.NowIndex][0].AppendFormat("{0}");
        this.RBBlockText[this.NowIndex][0] = child.GetChild(6).GetComponent<UIText>();
        this.RBBlockText[this.NowIndex][0].text = this.BlockTextStr[this.NowIndex][0].ToString();
        this.RBBlockText[this.NowIndex][0].font = this.tmpFont;
        LevelUp recordByKey = this.DM.LevelUpTable.GetRecordByKey(DataManager.StageDataController.GetLevelBycurrentPointID((ushort) 0).LeadLV);
        this.BlockTextStr[this.NowIndex][1] = StringManager.Instance.SpawnString();
        this.BlockTextStr[this.NowIndex][1].IntToFormat((long) DataManager.Instance.GetExpAddition((uint) recordByKey.BattleHeroLeadExp * (DataManager.StageDataController._stageMode != StageMode.Lean ? 1U : 2U)), bNumber: true);
        this.BlockTextStr[this.NowIndex][1].AppendFormat("{0}");
        this.RBBlockText[this.NowIndex][1] = child.GetChild(4).GetComponent<UIText>();
        this.RBBlockText[this.NowIndex][1].text = this.BlockTextStr[this.NowIndex][1].ToString();
        this.RBBlockText[this.NowIndex][1].font = this.tmpFont;
        this.BlockTextStr[this.NowIndex][2] = StringManager.Instance.SpawnString();
        this.BlockTextStr[this.NowIndex][2].IntToFormat((long) this.DM.QBMoney, bNumber: true);
        this.BlockTextStr[this.NowIndex][2].AppendFormat("{0}");
        this.RBBlockText[this.NowIndex][2] = child.GetChild(5).GetComponent<UIText>();
        this.RBBlockText[this.NowIndex][2].text = this.BlockTextStr[this.NowIndex][2].ToString();
        this.RBBlockText[this.NowIndex][2].font = this.tmpFont;
        if (this.DM.QBRewardLen[this.NowIndex] > (byte) 0)
        {
          GameObject gameObject2 = child.GetChild(8).gameObject;
          for (int index2 = 0; index2 < (int) this.DM.QBRewardLen[this.NowIndex]; ++index2)
          {
            GameObject gameObject3 = Object.Instantiate((Object) gameObject2) as GameObject;
            gameObject3.SetActive(true);
            gameObject3.transform.SetParent(child, false);
            RectTransform component2 = gameObject3.GetComponent<RectTransform>();
            ((Transform) component2).localPosition = ((Transform) component2).localPosition + new Vector3(88f * (float) (index2 % 6), -88f * (float) (index2 / 6), 0.0f);
            ushort HIID = this.DM.QBRewardData[this.NowRWIndex];
            ++this.NowRWIndex;
            UIHIBtn component3 = gameObject3.transform.GetComponent<UIHIBtn>();
            component3.m_BtnID1 = (int) HIID;
            component3.m_BtnID2 = 0;
            component3.m_Handler = (IUIHIBtnClickHandler) this;
            this.GM.InitianHeroItemImg(gameObject3.transform, eHeroOrItem.Item, HIID, (byte) 0, (byte) 0, bShowText: false);
            gameObject3.SetActive(true);
          }
          Object.Destroy((Object) gameObject2);
        }
        else
        {
          child.GetChild(8).gameObject.SetActive(false);
          child.GetChild(7).gameObject.SetActive(true);
          this.RBBlockText[this.NowIndex][3] = child.GetChild(7).GetComponent<UIText>();
          this.RBBlockText[this.NowIndex][3].text = this.DM.mStringTable.GetStringByID(1597U);
          this.RBBlockText[this.NowIndex][3].font = this.tmpFont;
        }
        this.HintRC[this.NowIndex] = new RectTransform[2];
        UIButton component4 = gameObject1.transform.GetChild(9).GetComponent<UIButton>();
        this.HintRC[this.NowIndex][0] = gameObject1.transform.GetChild(9).GetComponent<RectTransform>();
        UIButtonHint uiButtonHint1 = ((Component) component4).gameObject.AddComponent<UIButtonHint>();
        uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
        uiButtonHint1.m_Handler = (MonoBehaviour) this;
        uiButtonHint1.ControlFadeOut = ((Component) this.m_HintBox).gameObject;
        component4.m_BtnID1 = this.NowIndex;
        component4.m_BtnID2 = 1;
        UIButton component5 = gameObject1.transform.GetChild(10).GetComponent<UIButton>();
        this.HintRC[this.NowIndex][1] = gameObject1.transform.GetChild(10).GetComponent<RectTransform>();
        UIButtonHint uiButtonHint2 = ((Component) component5).gameObject.AddComponent<UIButtonHint>();
        uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
        uiButtonHint2.m_Handler = (MonoBehaviour) this;
        uiButtonHint2.ControlFadeOut = ((Component) this.m_HintBox).gameObject;
        component5.m_BtnID1 = this.NowIndex;
        component5.m_BtnID2 = 2;
        if (this.DM.UserLanguage == GameLanguage.GL_Chs)
          gameObject1.transform.GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(0);
        if (this.GM.IsArabic)
          gameObject1.transform.GetChild(2).localScale = new Vector3(-1f, 1f, 1f);
        AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
      }
      else
      {
        if (this.bHasBonus)
        {
          Transform child = this.ContentT.GetChild(0);
          child.gameObject.SetActive(true);
          RectTransform component6 = child.GetComponent<RectTransform>();
          ((Transform) component6).localPosition = new Vector3(((Transform) component6).localPosition.x, -this.BlockTop, 0.0f);
          this.tmpHeight = this.GetBlockHeight(this.bonusCount, true);
          component6.sizeDelta = new Vector2(component6.sizeDelta.x, this.tmpHeight);
          this.BlockTop += this.tmpHeight + 10f;
          this.BonusText = child.GetChild(3).GetComponent<UIText>();
          this.BonusText.text = this.DM.mStringTable.GetStringByID(152U);
          this.BonusText.font = this.tmpFont;
          GameObject gameObject4 = child.GetChild(1).gameObject;
          this.GM.InitianHeroItemImg(gameObject4.transform, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0);
          for (int index = 0; index < this.bonusCount; ++index)
          {
            GameObject gameObject5 = Object.Instantiate((Object) gameObject4) as GameObject;
            gameObject5.transform.SetParent(child, false);
            RectTransform component7 = gameObject5.GetComponent<RectTransform>();
            ((Transform) component7).localPosition = ((Transform) component7).localPosition + new Vector3(88f * (float) (index % 7), -88f * (float) (index / 7), 0.0f);
            UIHIBtn component8 = gameObject5.transform.GetComponent<UIHIBtn>();
            component8.m_BtnID1 = (int) this.DM.QBExpItem[index].ItemID;
            component8.m_BtnID2 = 0;
            component8.m_Handler = (IUIHIBtnClickHandler) this;
            this.GM.ChangeHeroItemImg(gameObject5.transform, eHeroOrItem.Item, this.DM.QBExpItem[index].ItemID, (byte) 0, (byte) 0, (int) this.DM.QBExpItem[index].Quantity);
            gameObject5.SetActive(true);
          }
          Object.Destroy((Object) gameObject4);
          AudioManager.Instance.PlayUISFX(UIKind.MissionReward);
        }
        else
          Object.Destroy((Object) this.tmpBlock);
        this.ExpBlock.gameObject.SetActive(true);
        RectTransform component = this.ExpBlock.GetComponent<RectTransform>();
        ((Transform) component).localPosition = new Vector3(((Transform) component).localPosition.x, -this.BlockTop, 0.0f);
        component.sizeDelta = new Vector2(component.sizeDelta.x, 92f);
        this.TickCount = -1f;
      }
      ++this.NowIndex;
      this.moveDelta = this.tmpHeight / this.TickTimes;
    }
    if (this.bMove)
    {
      if ((double) this.ContentRC.sizeDelta.y - (double) this.ContentRC.anchoredPosition.y <= (double) this.ScrollRC.sizeDelta.y)
      {
        this.bMove = false;
        ((Behaviour) this.m_transform.GetChild(0).GetComponent<ScrollRect>()).enabled = true;
        this.GM.UIQueueLockRelease(EGUIQueueLock.UIQL_BattleReport);
        NewbieManager.CheckTeach(ETeachKind.WIPE_OUT, (object) this);
        return;
      }
      if (this.NowIndex > 2)
      {
        RectTransform contentRc = this.ContentRC;
        ((Transform) contentRc).localPosition = ((Transform) contentRc).localPosition + new Vector3(0.0f, this.moveDelta * smoothDeltaTime, 0.0f);
      }
    }
    if (this.bHintOpen <= (byte) 0)
      return;
    this.SetHint();
  }

  private float GetBlockHeight(int ItemCount, bool bBonus = false)
  {
    return bBonus ? (float) (183.0 + (double) ((ItemCount - 1) / 7) * 88.0) : (float) (160.0 + (double) ((ItemCount - 1) / 6) * 88.0);
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
      this.GM.UIQueueLockRelease(EGUIQueueLock.UIQL_BattleReport);
    }
    else
    {
      if (sender.m_BtnID1 != 2)
        return;
      GUIManager.Instance.m_WindowStack.RemoveAt(GUIManager.Instance.m_WindowStack.Count - 1);
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BagFilter, 4);
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    // ISSUE: unable to decompile the method.
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    ((Component) this.m_HintBox).gameObject.SetActive(false);
    this.bHintOpen = (byte) 0;
  }

  private void SetHint()
  {
    this.HintTime += Time.deltaTime;
    if ((double) this.HintTime < 1.0)
      return;
    this.HintTime = 0.0f;
    if (this.bHintOpen == (byte) 0)
      this.m_HintText.text = this.DM.mStringTable.GetStringByID(1518U);
    else if (this.bHintOpen == (byte) 1)
      this.m_HintText.text = this.DM.mStringTable.GetStringByID(1580U);
    ((Graphic) this.m_HintBox).rectTransform.sizeDelta = new Vector2(350f, this.m_HintText.preferredHeight + 31f);
    if ((double) ((Graphic) this.m_HintBox).rectTransform.sizeDelta.y - (double) ((Graphic) this.m_HintBox).rectTransform.anchoredPosition.y <= 609.0)
      return;
    ((Graphic) this.m_HintBox).rectTransform.anchoredPosition = new Vector2(((Graphic) this.m_HintBox).rectTransform.anchoredPosition.x, ((Graphic) this.m_HintBox).rectTransform.sizeDelta.y - 609f);
  }

  public override bool OnBackButtonClick()
  {
    this.GM.UIQueueLockRelease(EGUIQueueLock.UIQL_BattleReport);
    return false;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    for (int index = 0; index < this.RBText.Length; ++index)
    {
      if ((Object) this.RBText[index] != (Object) null && ((Behaviour) this.RBText[index]).enabled)
      {
        ((Behaviour) this.RBText[index]).enabled = false;
        ((Behaviour) this.RBText[index]).enabled = true;
      }
    }
    for (int index1 = 0; index1 < 10; ++index1)
    {
      for (int index2 = 0; index2 < 4; ++index2)
      {
        if (this.RBBlockText[index1] != null && (Object) this.RBBlockText[index1][index2] != (Object) null && ((Behaviour) this.RBBlockText[index1][index2]).enabled)
        {
          ((Behaviour) this.RBBlockText[index1][index2]).enabled = false;
          ((Behaviour) this.RBBlockText[index1][index2]).enabled = true;
        }
      }
    }
  }
}
