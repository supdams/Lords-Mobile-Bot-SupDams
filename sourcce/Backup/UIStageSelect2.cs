// Decompiled with JetBrains decompiler
// Type: UIStageSelect2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIStageSelect2 : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
  private Transform m_transform;
  private UIText StageName;
  private DataManager DM;
  private GUIManager GM;
  private UIButton m_HelpAlert;
  private RectTransform m_HelpAlertRC;
  private UIText m_HelpAlertext;
  private CString m_HelpAlertStr;
  private GameObject m_HelpAlertImageGO;
  private UIText m_HelpAlertext2;
  private CString m_HelpAlertStr2;
  private CustomImage m_HelpAlertL;
  private CustomImage m_HelpAlertR;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.m_transform = this.transform;
    Font ttfFont = this.GM.GetTTFFont();
    this.m_transform.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(4).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) this.m_transform.GetChild(4).GetComponent<Image>()).enabled = false;
    this.StageName = this.m_transform.GetChild(5).GetComponent<UIText>();
    this.StageName.font = ttfFont;
    Transform child1 = this.m_transform.GetChild(6);
    this.m_HelpAlert = child1.GetComponent<UIButton>();
    this.m_HelpAlert.m_Handler = (IUIButtonClickHandler) this;
    this.m_HelpAlertImageGO = child1.GetChild(0).gameObject;
    this.m_HelpAlertext2 = child1.GetChild(1).GetComponent<UIText>();
    this.m_HelpAlertext2.font = this.GM.GetTTFFont();
    this.m_HelpAlertStr2 = StringManager.Instance.SpawnString();
    Transform child2 = child1.GetChild(2);
    this.m_HelpAlertRC = child2.GetComponent<RectTransform>();
    this.m_HelpAlertext = child2.GetChild(0).GetComponent<UIText>();
    this.m_HelpAlertext.font = this.GM.GetTTFFont();
    this.m_HelpAlertStr = StringManager.Instance.SpawnString();
    this.m_HelpAlertL = this.m_transform.GetChild(6).GetChild(3).GetComponent<CustomImage>();
    this.m_HelpAlertR = this.m_transform.GetChild(6).GetChild(4).GetComponent<CustomImage>();
    this.m_transform.GetChild(6).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(6).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(6).GetChild(2).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(6).GetChild(3).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(6).GetChild(4).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    if (this.GM.IsArabic)
    {
      ((Component) this.m_HelpAlertL).gameObject.AddComponent<ArabicItemTextureRot>();
      ((Component) this.m_HelpAlertR).gameObject.AddComponent<ArabicItemTextureRot>();
    }
    this.StageName.text = this.DM.mStringTable.GetStringByID((uint) DataManager.StageDataController.CorpsStageTable.GetRecordByKey((ushort) arg1).StageName);
    this.GM.UpdateUI(EGUIWindow.Door, 1, 5);
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (Object) menu && menu.m_GroundInfo.bOpenPvePanel)
      menu.m_GroundInfo.OpenPvePanel(true, (ushort) arg1);
    this.CheckHelpAlertState();
  }

  public override void OnClose()
  {
    if (this.m_HelpAlertStr != null)
    {
      StringManager.Instance.DeSpawnString(this.m_HelpAlertStr);
      this.m_HelpAlertStr = (CString) null;
    }
    if (this.m_HelpAlertStr2 == null)
      return;
    StringManager.Instance.DeSpawnString(this.m_HelpAlertStr2);
    this.m_HelpAlertStr2 = (CString) null;
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != 1)
      return;
    this.CheckHelpAlertState();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    if ((Object) this.StageName != (Object) null && ((Behaviour) this.StageName).enabled)
    {
      ((Behaviour) this.StageName).enabled = false;
      ((Behaviour) this.StageName).enabled = true;
    }
    if ((Object) this.m_HelpAlertext != (Object) null && ((Behaviour) this.m_HelpAlertext).enabled)
    {
      ((Behaviour) this.m_HelpAlertext).enabled = false;
      ((Behaviour) this.m_HelpAlertext).enabled = true;
    }
    if (!((Object) this.m_HelpAlertext2 != (Object) null) || !((Behaviour) this.m_HelpAlertext2).enabled)
      return;
    ((Behaviour) this.m_HelpAlertext2).enabled = false;
    ((Behaviour) this.m_HelpAlertext2).enabled = true;
  }

  public void CloseFunction()
  {
    DataManager.msgBuffer[0] = (byte) 4;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
      this.CloseFunction();
    else if (sender.m_BtnID1 == 2)
    {
      DataManager.msgBuffer[0] = (byte) 18;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
    else
    {
      if (sender.m_BtnID1 != 23)
        return;
      Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
      if (!((Object) menu != (Object) null))
        return;
      menu.OpenMenu(EGUIWindow.UI_Alliance_HelpSpeedup);
    }
  }

  public override bool OnBackButtonClick()
  {
    this.CloseFunction();
    return true;
  }

  public void CheckHelpAlertState()
  {
    if (DataManager.Instance.mHelpDataList.Count > 0)
    {
      this.m_HelpAlertStr.Length = 0;
      this.m_HelpAlertStr.IntToFormat((long) DataManager.Instance.mHelpDataList.Count);
      this.m_HelpAlertStr.AppendFormat("{0}");
      this.m_HelpAlertext.text = this.m_HelpAlertStr.ToString();
      this.m_HelpAlertext.SetAllDirty();
      this.m_HelpAlertext.cachedTextGenerator.Invalidate();
      this.m_HelpAlertext.cachedTextGeneratorForLayout.Invalidate();
      this.m_HelpAlertRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_HelpAlertext.preferredWidth), 51f);
      ((Component) this.m_HelpAlertRC).gameObject.SetActive(true);
      ((Component) this.m_HelpAlert).gameObject.SetActive(true);
      if (DataManager.Instance.AllianceMoneyBonusRate > (ushort) 100)
      {
        Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
        if ((Object) menu != (Object) null)
        {
          int index = (int) DataManager.Instance.AllianceMoneyBonusRate / 100 - 2;
          if (index >= 0 && index < menu.m_HelpAlertSA.m_Sprites.Length)
            this.m_HelpAlertL.sprite = menu.m_HelpAlertSA.GetSprite(index);
          else
            this.m_HelpAlertL.sprite = menu.m_HelpAlertSA.GetSprite(0);
          ((Component) this.m_HelpAlertL).gameObject.SetActive(true);
          ((Component) this.m_HelpAlertR).gameObject.SetActive(true);
        }
        else
        {
          ((Component) this.m_HelpAlertL).gameObject.SetActive(false);
          ((Component) this.m_HelpAlertR).gameObject.SetActive(false);
        }
        this.m_HelpAlertImageGO.SetActive(true);
      }
      else
      {
        this.m_HelpAlertImageGO.SetActive(false);
        ((Component) this.m_HelpAlertL).gameObject.SetActive(false);
        ((Component) this.m_HelpAlertR).gameObject.SetActive(false);
      }
    }
    else
      ((Component) this.m_HelpAlert).gameObject.SetActive(false);
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (Object) menu)
      return;
    img.sprite = menu.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = menu.LoadMaterial();
  }
}
