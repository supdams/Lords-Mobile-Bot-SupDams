// Decompiled with JetBrains decompiler
// Type: UIActivity3
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIActivity3 : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
  private Transform m_transform;
  private Transform ContentT;
  private GameObject TextGO;
  private GameObject ItemGO;
  private GameObject UrlGO;
  private DataManager DM;
  private GUIManager GM;
  private StringManager SM;
  private ActivityManager AM;
  private SPActivityDataType tmpData;
  private float NormalLeft = 60f;
  private float ItemSize = 60f;
  private float ItemDelta = 10f;
  private float UrlItemSize = 50f;
  private float NowX = 60f;
  private float NowY = -5f;
  private byte DataIndex;
  private List<CString> AllObject = new List<CString>();
  private List<CString> UrlObject = new List<CString>();
  private List<UIText> RefreshTextArray = new List<UIText>();
  private List<GameObject> DestroyGO = new List<GameObject>();
  private Image TitleImg;
  private UIText TitleText;
  private UIText TimeText;
  private CString timeStr;
  private BGMType NowBGM;
  private bool bPlayMaster;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.SM = StringManager.Instance;
    this.AM = ActivityManager.Instance;
    this.m_transform = this.transform;
    Font ttfFont = this.GM.GetTTFFont();
    this.DataIndex = (byte) arg2;
    bool flag = arg1 == 254;
    this.tmpData = !flag ? this.AM.SPActivityData[(int) this.DataIndex] : this.AM.CSActivityData[(int) this.DataIndex];
    this.m_transform.GetChild(2).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(2).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(2).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(3).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(3).gameObject.SetActive(false);
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) this.m_transform.GetChild(2).GetComponent<CustomImage>()).enabled = false;
    Transform child = this.m_transform.GetChild(1);
    UIText component1 = child.GetChild(2).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.text = this.DM.mStringTable.GetStringByID((uint) this.tmpData.Name);
    this.RefreshTextArray.Add(component1);
    this.TitleText = child.GetChild(3).GetComponent<UIText>();
    this.TitleText.font = ttfFont;
    this.RefreshTextArray.Add(this.TitleText);
    this.TimeText = child.GetChild(4).GetComponent<UIText>();
    this.TimeText.font = ttfFont;
    ((Graphic) this.TimeText).color = new Color(1f, 0.9294f, 0.5451f);
    this.timeStr = this.SM.SpawnString(150);
    this.RefreshTextArray.Add(this.TimeText);
    this.TitleImg = child.GetChild(5).GetComponent<Image>();
    child.GetChild(5).gameObject.AddComponent<ArabicItemTextureRot>();
    this.SetTitleImage();
    this.ContentT = child.GetChild(6).GetChild(0);
    this.TextGO = this.ContentT.GetChild(0).gameObject;
    this.ContentT.GetChild(0).GetComponent<UIText>().font = ttfFont;
    this.ItemGO = this.ContentT.GetChild(1).gameObject;
    ((RectTransform) this.ItemGO.transform).sizeDelta = new Vector2(this.ItemSize, this.ItemSize);
    this.GM.InitianHeroItemImg(this.ContentT.GetChild(1), eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0);
    this.UrlGO = this.ContentT.GetChild(2).gameObject;
    this.ContentT.GetChild(2).GetChild(0).GetComponent<UIText>().font = ttfFont;
    child.GetChild(7).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    if (!flag && this.tmpData.GoToButton != (ushort) 0)
      child.GetChild(7).gameObject.SetActive(true);
    UIText component2 = child.GetChild(7).GetChild(1).GetComponent<UIText>();
    component2.font = ttfFont;
    component2.text = this.tmpData.GoToButton != (ushort) 5 ? this.DM.mStringTable.GetStringByID(8154U) : this.DM.mStringTable.GetStringByID(15015U);
    this.RefreshTextArray.Add(component2);
    this.SpawnContent();
    if (flag)
      this.AM.SetbOpenCSActivity(this.DataIndex, true);
    else
      this.AM.SetbOpenSPActivity(this.DataIndex, true);
    this.GM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    for (int index = 0; index < this.AllObject.Count; ++index)
      StringManager.Instance.DeSpawnString(this.AllObject[index]);
    for (int index = 0; index < this.UrlObject.Count; ++index)
      StringManager.Instance.DeSpawnString(this.UrlObject[index]);
    if (this.timeStr != null)
      StringManager.Instance.DeSpawnString(this.timeStr);
    if (!this.bPlayMaster)
      return;
    AudioManager.Instance.LoadAndPlayBGM(this.NowBGM, (byte) 1);
  }

  private void DestroyContentItem()
  {
    for (int index = 0; index < this.AllObject.Count; ++index)
      StringManager.Instance.DeSpawnString(this.AllObject[index]);
    for (int index = 0; index < this.UrlObject.Count; ++index)
      StringManager.Instance.DeSpawnString(this.UrlObject[index]);
    this.AllObject.Clear();
    this.UrlObject.Clear();
    for (int index = this.DestroyGO.Count - 1; index >= 0; --index)
    {
      this.DestroyGO[index].SetActive(false);
      Object.Destroy((Object) this.DestroyGO[index]);
    }
    this.DestroyGO.Clear();
    this.NowX = 60f;
    this.NowY = -5f;
    this.timeStr.Length = 0;
  }

  private void SetTitleImage()
  {
    if ((Object) this.TitleImg == (Object) null)
      return;
    if (this.AM.bDownLoadPic2)
    {
      if (this.AM.bUpDatePic2)
      {
        this.AM.m_ActivityAsset.UnloadAsset();
        this.AM.bUpDatePic2 = false;
      }
      if (this.AM.m_ActivityAsset.m_AssetBundleKey == 0)
        this.AM.m_ActivityAsset.InitialAsset("UIActivityBack_2");
      this.TitleImg.sprite = this.AM.LoadActivitySprite(this.tmpData.DetailPic);
      if ((Object) this.TitleImg.sprite == (Object) null)
        this.TitleImg.sprite = this.AM.LoadActivitySprite((ushort) 0);
      ((MaskableGraphic) this.TitleImg).material = this.AM.GetActivityMaterial();
      if ((Object) this.AM.m_ActivityAsset.m_Material == (Object) null || (Object) this.TitleImg.sprite == (Object) null)
        ((Behaviour) this.TitleImg).enabled = false;
      else
        ((Behaviour) this.TitleImg).enabled = true;
    }
    else
      ((Behaviour) this.TitleImg).enabled = false;
  }

  private void SpawnContent()
  {
    // ISSUE: unable to decompile the method.
  }

  private void SpawnText(CString tmpContent)
  {
    // ISSUE: unable to decompile the method.
  }

  private void SpawnItem(CString tmpNum)
  {
    ushort HIID = 0;
    int num = 1;
    for (int index = tmpNum.Length - 1; index >= 0 && tmpNum[index] >= '0' && tmpNum[index] <= '9'; --index)
    {
      HIID += (ushort) (num * ((int) tmpNum[index] - 48));
      num *= 10;
    }
    GameObject gameObject = Object.Instantiate((Object) this.ItemGO) as GameObject;
    gameObject.SetActive(true);
    gameObject.transform.SetParent(this.ContentT, false);
    this.DestroyGO.Add(gameObject);
    this.GM.ChangeHeroItemImg(gameObject.transform, eHeroOrItem.Item, HIID, (byte) 0, (byte) 0);
    ((RectTransform) gameObject.transform).anchoredPosition = new Vector2(this.NowX, this.NowY - this.ItemSize / 2f);
    this.NowX += this.ItemSize + this.ItemDelta;
  }

  private void SpawnUrlBtn(int Index)
  {
    // ISSUE: unable to decompile the method.
  }

  private bool CheckVersion(CString tmpNum)
  {
    ushort[] numArray = new ushort[3];
    int num = 1;
    int index1 = 2;
    for (int index2 = tmpNum.Length - 1; index2 >= 0; --index2)
    {
      if (tmpNum[index2] == '.')
      {
        --index1;
        num = 1;
      }
      else
      {
        if (tmpNum[index2] < '0' || tmpNum[index2] > '9' || index1 < 0)
          return false;
        numArray[index1] += (ushort) (num * ((int) tmpNum[index2] - 48));
        num *= 10;
      }
    }
    for (int index3 = 0; index3 < numArray.Length; ++index3)
    {
      if ((int) GameConstants.Version[index3] < (int) numArray[index3])
        return false;
      if ((int) GameConstants.Version[index3] > (int) numArray[index3])
        return true;
    }
    return true;
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      if (sender.m_BtnID2 == 1)
      {
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (Object) menu)
          return;
        menu.CloseMenu();
      }
      else if (sender.m_BtnID2 != 2)
        ;
    }
    else if (sender.m_BtnID1 == 2)
    {
      if (sender.m_BtnID2 != 1)
        return;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!(bool) (Object) menu)
        return;
      if (this.tmpData.GoToButton == (ushort) 1)
        menu.OpenMenu(EGUIWindow.UI_Mall, bCameraMode: true);
      else if (this.tmpData.GoToButton == (ushort) 2)
      {
        menu.OpenMenu(EGUIWindow.UI_Chat);
        GUIManager.Instance.OpenMenu(EGUIWindow.UIEmojiSelect, 2, bSecWindow: true);
        GUIManager.Instance.UpdateUI(EGUIWindow.UIEmojiSelect, 4, 1);
      }
      else if (this.tmpData.GoToButton == (ushort) 3)
      {
        if (this.GM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 9)
        {
          CString cstring = StringManager.Instance.StaticString1024();
          cstring.IntToFormat(9L);
          cstring.AppendFormat(this.DM.mStringTable.GetStringByID(9167U));
          this.GM.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
        }
        else
        {
          menu.OpenMenu(EGUIWindow.UI_CastleSkin, bCameraMode: true);
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_CastleSkin, 1);
        }
      }
      else if (this.tmpData.GoToButton == (ushort) 4)
      {
        H5SDKPlugin.StartH5ByWebView(IGGGameSDK.Instance.m_IGGID, DataManager.Instance.UserLanguage.ToString(), "1", DataManager.Instance.RoleAttr.Name.ToString());
        this.GM.StopShowLiveScale = (byte) 2;
        this.GM.UpdateUI(EGUIWindow.Door, 20);
      }
      else if (this.tmpData.GoToButton == (ushort) 5)
      {
        if (!this.DM.MySysSetting.bMusic)
        {
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(10163U), (ushort) byte.MaxValue);
        }
        else
        {
          if (!this.bPlayMaster)
          {
            this.bPlayMaster = true;
            this.NowBGM = AudioManager.Instance.GetCurMusic();
          }
          AudioManager.Instance.LoadAndPlayBGM(BGMType.Master, (byte) 1);
        }
      }
      else
        menu.CloseMenu();
    }
    else
    {
      if (sender.m_BtnID1 != 3 || sender.m_BtnID2 >= this.UrlObject.Count)
        return;
      Application.OpenURL(this.UrlObject[sender.m_BtnID2].ToString());
    }
  }

  private bool CheckActiviteTime()
  {
    if (this.tmpData == null || this.tmpData.EventBeginTime != 0L)
      return false;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (Object) menu)
      menu.CloseMenu();
    return true;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        this.CheckActiviteTime();
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        for (int index = 0; index < this.RefreshTextArray.Count; ++index)
        {
          if ((Object) this.RefreshTextArray[index] != (Object) null && ((Behaviour) this.RefreshTextArray[index]).enabled)
          {
            ((Behaviour) this.RefreshTextArray[index]).enabled = false;
            ((Behaviour) this.RefreshTextArray[index]).enabled = true;
          }
        }
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.SetTitleImage();
        break;
      case 2:
        this.DestroyContentItem();
        this.SpawnContent();
        break;
      case 3:
        if (this.CheckActiviteTime() || (arg2 != 4 || this.tmpData != this.AM.CSActivityData[(int) this.DataIndex]) && (arg2 != 5 || this.tmpData != this.AM.SPActivityData[(int) this.DataIndex]))
          break;
        this.SetTitleImage();
        this.DestroyContentItem();
        this.SpawnContent();
        break;
    }
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
