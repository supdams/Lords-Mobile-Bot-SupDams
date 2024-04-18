// Decompiled with JetBrains decompiler
// Type: InputBox
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#nullable disable
public class InputBox : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
  protected Door door;
  protected UnityEngine.UI.Text[] m_InputBoxText = new UnityEngine.UI.Text[3];
  protected UnityEngine.UI.Text m_butt;
  protected UnityEngine.UI.Text m_error;
  protected UnityEngine.UI.Text m_content;
  protected UnityEngine.UI.Text m_descript;
  protected UnityEngine.UI.Text m_character;
  protected InputField s_input;
  protected UIEmojiInput m_input;
  protected UISpritesArray USArray;
  protected Transform Transformer;
  protected GameObject Tick;
  protected GameObject Invalid;
  protected float CheckTime;
  public Protocol Checking;
  public Protocol Sending;
  public bool Check;
  public byte Tagging;
  public int Typing;
  public int Length;
  public int Limits;
  public int Counts;
  public long ItemID;
  public DataManager DM = DataManager.Instance;
  public StringBuilder Hint = new StringBuilder();
  private ECaseByCaseType Type;

  private void Update()
  {
    if ((double) this.CheckTime <= 0.0 || (double) (this.CheckTime -= Time.deltaTime) > 0.0)
      return;
    this.OnCheck(this.m_input.text);
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (Object) menu)
    {
      img.sprite = menu.LoadSprite(ImageName);
      ((MaskableGraphic) img).material = menu.LoadMaterial();
    }
    img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
    ((MaskableGraphic) img).material = GUIManager.Instance.GetFrameMaterial();
  }

  private void ValueChange(string input)
  {
    if (this.Type <= ECaseByCaseType.ECBCT_ReNickName && (input != string.Empty || this.Type == ECaseByCaseType.ECBCT_ReNickName))
    {
      this.CheckTime = 1f;
      ++this.Tagging;
    }
    this.Hint.Length = 0;
    this.m_character.text = this.Hint.AppendFormat(this.DM.mStringTable.GetStringByID(4614U), (object) (this.Limits - input.Length)).ToString();
  }

  public override void OnOpen(int arg1, int arg2)
  {
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      ((RectTransform) this.transform).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.transform).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    this.Transformer = this.transform.GetChild(0);
    this.Transformer.GetChild(4).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.Transformer.GetChild(4).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.Transformer.GetChild(11).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.Transformer.GetChild(7).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
    this.m_InputBoxText[0] = this.Transformer.GetChild(7).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.Transformer.GetChild(8).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
    this.m_InputBoxText[1] = this.Transformer.GetChild(8).GetComponent<UnityEngine.UI.Text>();
    this.Transformer.GetChild(5).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
    this.m_InputBoxText[2] = this.Transformer.GetChild(5).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_character = this.Transformer.GetChild(12).GetComponent<UnityEngine.UI.Text>();
    this.m_character.font = GUIManager.Instance.GetTTFFont();
    this.m_content = this.Transformer.GetChild(5).GetChild(1).GetComponent<UnityEngine.UI.Text>();
    this.m_content.font = GUIManager.Instance.GetTTFFont();
    this.m_content.text = this.DM.mStringTable.GetStringByID(4613U);
    this.m_descript = this.Transformer.GetChild(13).GetComponent<UnityEngine.UI.Text>();
    this.m_descript.font = GUIManager.Instance.GetTTFFont();
    this.m_error = this.Transformer.GetChild(9).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_error.font = GUIManager.Instance.GetTTFFont();
    this.m_input = this.Transformer.GetChild(5).GetChild(0).GetComponent<UIEmojiInput>();
    // ISSUE: method pointer
    this.m_input.onValueChange.AddListener(new UnityAction<string>((object) this, __methodptr(\u003COnOpen\u003Em__EE)));
    this.m_input.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
    this.m_butt = this.Transformer.GetChild(4).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_butt.font = GUIManager.Instance.GetTTFFont();
    this.m_butt.text = this.DM.mStringTable.GetStringByID(4715U);
    ((Graphic) this.m_butt).color = (this.Type = (ECaseByCaseType) arg1) >= ECaseByCaseType.ECBCT_ReNickName ? Color.white : ((Graphic) this.m_error).color;
    this.Transformer.GetChild(10).gameObject.AddComponent<ArabicItemTextureRot>();
    Object.Destroy((Object) this.transform.GetChild(0).GetChild(0).GetComponent<IgnoreRaycast>());
    HelperUIButton helperUiButton = this.gameObject.AddComponent<HelperUIButton>();
    helperUiButton.m_Handler = (IUIButtonClickHandler) this;
    helperUiButton.m_BtnID1 = 22;
    ECaseByCaseType type = this.Type;
    switch (type)
    {
      case ECaseByCaseType.ECBCT_ReNickName:
        this.m_descript.text = this.DM.mStringTable.GetStringByID(9069U);
        UnityEngine.UI.Text component1 = this.Transformer.GetChild(8).GetComponent<UnityEngine.UI.Text>();
        string stringById1 = this.DM.mStringTable.GetStringByID(9099U);
        this.Transformer.GetChild(7).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = stringById1;
        string str1 = stringById1;
        component1.text = str1;
        break;
      case ECaseByCaseType.ECBCT_SaveTalent:
        this.m_descript.text = this.DM.mStringTable.GetStringByID(9069U);
        UnityEngine.UI.Text component2 = this.Transformer.GetChild(8).GetComponent<UnityEngine.UI.Text>();
        string stringById2 = this.DM.mStringTable.GetStringByID(931U);
        this.Transformer.GetChild(7).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = stringById2;
        string str2 = stringById2;
        component2.text = str2;
        break;
      case ECaseByCaseType.ECBCT_EquipMemorySetup:
        this.m_descript.text = this.DM.mStringTable.GetStringByID(9069U);
        UnityEngine.UI.Text component3 = this.Transformer.GetChild(8).GetComponent<UnityEngine.UI.Text>();
        string stringById3 = this.DM.mStringTable.GetStringByID(9704U);
        this.Transformer.GetChild(7).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = stringById3;
        string str3 = stringById3;
        component3.text = str3;
        break;
      case ECaseByCaseType.ECBCT_Preselectedteam:
        this.m_descript.text = this.DM.mStringTable.GetStringByID(9069U);
        UnityEngine.UI.Text component4 = this.Transformer.GetChild(8).GetComponent<UnityEngine.UI.Text>();
        string stringById4 = this.DM.mStringTable.GetStringByID(992U);
        this.Transformer.GetChild(7).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = stringById4;
        string str4 = stringById4;
        component4.text = str4;
        this.m_content.text = this.DM.mStringTable.GetStringByID(4617U);
        break;
      default:
        switch (type)
        {
          case ECaseByCaseType.ECBCT_AllianceRename:
            this.Checking = Protocol._MSG_REQUEST_ALLIANCE_NAMECHACK;
            this.Sending = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_NAME;
            this.m_content.text = this.DM.mStringTable.GetStringByID(4613U);
            this.m_descript.text = this.DM.mStringTable.GetStringByID(4615U);
            UnityEngine.UI.Text component5 = this.Transformer.GetChild(8).GetComponent<UnityEngine.UI.Text>();
            string stringById5 = this.DM.mStringTable.GetStringByID(4612U);
            this.Transformer.GetChild(7).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = stringById5;
            string str5 = stringById5;
            component5.text = str5;
            break;
          case ECaseByCaseType.ECBCT_AllianceTag:
            this.Checking = Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK;
            this.Sending = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_TAG;
            this.m_content.text = this.DM.mStringTable.GetStringByID(4617U);
            this.m_descript.text = this.DM.mStringTable.GetStringByID(4618U);
            UnityEngine.UI.Text component6 = this.Transformer.GetChild(8).GetComponent<UnityEngine.UI.Text>();
            string stringById6 = this.DM.mStringTable.GetStringByID(4616U);
            this.Transformer.GetChild(7).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = stringById6;
            string str6 = stringById6;
            component6.text = str6;
            break;
          default:
            this.Sending = Protocol._MSG_REQUEST_ROLE_RENAME;
            this.Checking = Protocol._MSG_REQUEST_ROLE_NAME_CHECK;
            this.m_content.text = this.DM.mStringTable.GetStringByID(4718U);
            this.m_descript.text = this.DM.mStringTable.GetStringByID(4615U);
            this.Transformer.GetChild(7).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4717U);
            this.Transformer.GetChild(8).GetComponent<UnityEngine.UI.Text>().text = this.DM.mStringTable.GetStringByID(4716U);
            break;
        }
        break;
    }
    this.Invalid = this.Transformer.GetChild(9).gameObject;
    this.Tick = this.Transformer.GetChild(10).gameObject;
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
  }

  protected void OnCheck(string name)
  {
    if (this.Type == ECaseByCaseType.ECBCT_ReNickName)
      this.SetStatus(DataManager.Instance.m_BannedWord.ChackHasBannedWord(name), string.Empty);
    else if (this.Checking != Protocol._MSG_REQUEST_ALLIANCE_NAMECHACK && name.Length >= 3 || this.Checking == Protocol._MSG_REQUEST_ALLIANCE_NAMECHACK)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = this.Checking;
      messagePacket.AddSeqId();
      messagePacket.Add(this.Tagging);
      if (this.Type != ECaseByCaseType.ECBCT_AllianceTag)
        messagePacket.Add((byte) Encoding.UTF8.GetByteCount(name));
      messagePacket.Add(name, this.Limits);
      messagePacket.Send();
    }
    else
      this.SetStatus(true, string.Empty);
    this.CheckTime = 0.0f;
  }

  protected char OnValidateInput(string text, int index, char check)
  {
    if (this.Type > ECaseByCaseType.ECBCT_EquipMemorySetup)
      return check;
    return this.Type == ECaseByCaseType.ECBCT_AllianceTag ? (check >= '!' && check <= '~' ? check : char.MinValue) : (this.Type == ECaseByCaseType.ECBCT_ReNickName || this.Type == ECaseByCaseType.ECBCT_SaveTalent || this.Type == ECaseByCaseType.ECBCT_EquipMemorySetup ? (check < '0' && check != ' ' || check > '9' && check < 'A' || check > 'Z' && check < 'a' || check > 'z' && check < '~' ? char.MinValue : check) : (check >= 'A' && check <= 'Z' || check >= 'a' && check <= 'z' || check >= '0' && check <= '9' || check == ' ' ? check : char.MinValue));
  }

  public override void OnClose()
  {
    ((UnityEventBase) this.m_input.onValueChange).RemoveAllListeners();
  }

  public void SetStatus(bool Asshole, string KissMyAss = "")
  {
    this.Invalid.SetActive(Asshole);
    this.Tick.SetActive(!Asshole);
    this.m_error.text = !KissMyAss.Equals(string.Empty) ? KissMyAss : this.DM.mStringTable.GetStringByID(this.Type == ECaseByCaseType.ECBCT_AllianceRename || this.Type == ECaseByCaseType.ECBCT_AllianceTag ? 437U : 362U);
    ((Graphic) this.m_butt).color = !Asshole ? Color.white : ((Graphic) this.m_error).color;
  }

  public void SetLimit(int limit)
  {
    if ((bool) (Object) this.m_input)
    {
      int num = limit;
      this.m_input.characterLimit = num;
      this.Counts = this.Limits = num;
    }
    this.Hint.Length = 0;
    this.m_character.text = this.Hint.AppendFormat(this.DM.mStringTable.GetStringByID(4614U), (object) this.Limits).ToString();
  }

  public void SetContent(string text)
  {
    if (!(bool) (Object) this.m_input)
      return;
    this.m_input.text = text;
  }

  public void SetDescriptive(string text)
  {
    if (!(bool) (Object) this.m_descript)
      return;
    this.m_descript.text = text;
  }

  public void Congrats(string name)
  {
    byte data = 0;
    ushort num = 0;
    if (DataManager.Instance.GetCurItemQuantity((ushort) this.ItemID, (byte) 0) == (ushort) 0)
    {
      data = (byte) 1;
      num = DataManager.Instance.TotalShopItemData.Find((ushort) this.ItemID);
    }
    if (this.Type >= ECaseByCaseType.ECBCT_ReNickName)
    {
      if (data == (byte) 0)
        DataManager.Instance.UseItem((ushort) this.ItemID, (ushort) 1, (ushort) 0, (ushort) 0, (ushort) 0, 0U, name, false);
      else
        DataManager.Instance.sendBuyItem((byte) 1, num, (ushort) this.ItemID, true, Parameter3: 0U, name: name, check: false, Qty: (ushort) 1);
      GUIManager.Instance.CloseMenu(this.m_eWindow);
    }
    else
    {
      if (!GUIManager.Instance.ShowUILock(EUILock.AllianceCreate))
        return;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = this.Sending;
      messagePacket.AddSeqId();
      messagePacket.Add(data);
      messagePacket.Add(num);
      messagePacket.Add((ushort) this.ItemID);
      if (this.Type != ECaseByCaseType.ECBCT_AllianceTag)
        messagePacket.Add((byte) Encoding.UTF8.GetByteCount(name));
      messagePacket.Add(name, this.Limits);
      messagePacket.Send();
      this.CheckTime = 0.0f;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if ((int) this.Tagging != arg1)
      return;
    if (this.Type == ECaseByCaseType.ECBCT_Rename)
      this.SetStatus(arg2 > 0, this.DM.mStringTable.GetStringByID(arg2 != 1 ? 362U : 363U));
    else
      this.SetStatus(arg2 > 0, this.DM.mStringTable.GetStringByID((uint) (arg2 + (this.Type != ECaseByCaseType.ECBCT_AllianceRename ? 435 : 433))));
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        if ((this.Type == ECaseByCaseType.ECBCT_AllianceRename || this.Type == ECaseByCaseType.ECBCT_AllianceTag) && this.DM.RoleAlliance.Rank != AllianceRank.RANK5)
        {
          GUIManager.Instance.CloseMenu(this.m_eWindow);
          break;
        }
        if (meg[0] != (byte) 0)
          break;
        this.CheckTime = 0.1f;
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Inputbox)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          this.Refresh_FontTexture();
          break;
        }
        if (meg[1] > (byte) 0)
        {
          if (this.Type == ECaseByCaseType.ECBCT_Rename)
          {
            this.SetStatus(meg[1] > (byte) 0, this.DM.mStringTable.GetStringByID(meg[1] != (byte) 3 ? 362U : 363U));
            break;
          }
          this.SetStatus(meg[1] > (byte) 0, this.DM.mStringTable.GetStringByID((uint) meg[1] + (this.Type != ECaseByCaseType.ECBCT_AllianceRename ? 433U : 431U)));
          break;
        }
        GUIManager.Instance.CloseMenu(this.m_eWindow);
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.m_butt != (Object) null && ((Behaviour) this.m_butt).enabled)
    {
      ((Behaviour) this.m_butt).enabled = false;
      ((Behaviour) this.m_butt).enabled = true;
    }
    if ((Object) this.m_error != (Object) null && ((Behaviour) this.m_error).enabled)
    {
      ((Behaviour) this.m_error).enabled = false;
      ((Behaviour) this.m_error).enabled = true;
    }
    if ((Object) this.m_content != (Object) null && ((Behaviour) this.m_content).enabled)
    {
      ((Behaviour) this.m_content).enabled = false;
      ((Behaviour) this.m_content).enabled = true;
    }
    if ((Object) this.m_descript != (Object) null && ((Behaviour) this.m_descript).enabled)
    {
      ((Behaviour) this.m_descript).enabled = false;
      ((Behaviour) this.m_descript).enabled = true;
    }
    if ((Object) this.m_character != (Object) null && ((Behaviour) this.m_character).enabled)
    {
      ((Behaviour) this.m_character).enabled = false;
      ((Behaviour) this.m_character).enabled = true;
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.m_InputBoxText[index] != (Object) null && ((Behaviour) this.m_InputBoxText[index]).enabled)
      {
        ((Behaviour) this.m_InputBoxText[index]).enabled = false;
        ((Behaviour) this.m_InputBoxText[index]).enabled = true;
      }
    }
    if (!((Object) this.m_input != (Object) null))
      return;
    if ((Object) this.m_input.textComponent != (Object) null && ((Behaviour) this.m_input.textComponent).enabled)
    {
      ((Behaviour) this.m_input.textComponent).enabled = false;
      ((Behaviour) this.m_input.textComponent).enabled = true;
    }
    if (!((Object) this.m_input.placeholder != (Object) null) || !((Behaviour) this.m_input.placeholder).enabled)
      return;
    ((Behaviour) this.m_input.placeholder).enabled = false;
    ((Behaviour) this.m_input.placeholder).enabled = true;
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 21)
    {
      if (this.Type == ECaseByCaseType.ECBCT_SaveTalent)
      {
        CString name = StringManager.Instance.StaticString1024();
        this.m_input.text.Trim();
        name.Append(this.m_input.text);
        DataManager.Instance.SaveTalentData[0].SetTagName(name);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Talent, -2);
        GUIManager.Instance.CloseMenu(this.m_eWindow);
      }
      else if (this.Type == ECaseByCaseType.ECBCT_EquipMemorySetup)
      {
        this.m_input.text.Trim();
        UILordEquipSetEdit.showingSet.Name.ClearString();
        UILordEquipSetEdit.showingSet.Name.Append(this.m_input.text);
        UILordEquipSetEdit.ThingsChanged = true;
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquipSetEdit, 1);
        GUIManager.Instance.CloseMenu(this.m_eWindow);
      }
      else if (this.Type == ECaseByCaseType.ECBCT_Preselectedteam)
      {
        this.m_input.text.Trim();
        DataManager.Instance.TeamName.ClearString();
        DataManager.Instance.TeamName.Append(this.m_input.text);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Expedition, 3);
        GUIManager.Instance.CloseMenu(this.m_eWindow);
      }
      else
      {
        if (this.Type >= ECaseByCaseType.ECBCT_ReNickName)
          this.OnCheck(this.m_input.text);
        if ((double) this.CheckTime <= 0.0 && !this.Tick.activeSelf)
          return;
        this.Congrats(this.m_input.text.Trim());
      }
    }
    else
    {
      if (this.Type == ECaseByCaseType.ECBCT_Rename)
      {
        if (this.DM.RoleAttr.Name.ToString().Substring(0, 3) == "ID." && NewbieManager.bShowRenameMessage)
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(8055U), (ushort) byte.MaxValue);
        NewbieManager.bShowRenameMessage = false;
      }
      GUIManager.Instance.CloseMenu(this.m_eWindow);
    }
  }
}
