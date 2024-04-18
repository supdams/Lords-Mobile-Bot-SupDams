// Decompiled with JetBrains decompiler
// Type: UILetterEditor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#nullable disable
public class UILetterEditor : GUIWindow, IUIButtonClickHandler
{
  private Transform GameT;
  private UIButton btn_EXIT;
  private UIButton btn_BookMarks;
  private UIButton btn_btn_SendLetter;
  private Image tmpImg;
  private UIText tmptext;
  private UIText text_Name;
  private UIText text_Title;
  private UIText text_Editor;
  private UIText text_Editor2;
  private UIText[] text_tmpStr = new UIText[3];
  private UIEmojiInput mInputName;
  private UIEmojiInput mInputTitle;
  private UIEmojiInput mInputEditor;
  private DataManager DM;
  private GUIManager GUIM;
  private Font TTFont;
  private Door door;
  private Material m_Mat;
  private int mEditorKind;
  private int mEditorType;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.m_Mat = this.door.LoadMaterial();
    this.mEditorKind = arg1;
    this.mEditorType = arg2;
    this.text_tmpStr[0] = this.GameT.GetChild(0).GetChild(3).GetComponent<UIText>();
    this.text_tmpStr[0].font = this.TTFont;
    this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(5398U);
    this.mInputName = this.GameT.GetChild(1).GetChild(0).GetComponent<UIEmojiInput>();
    this.mInputName.textComponent.font = this.TTFont;
    this.tmptext = this.mInputName.placeholder as UIText;
    this.tmptext.font = this.TTFont;
    this.text_Name = this.GameT.GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>();
    this.text_Name.font = this.TTFont;
    this.mInputTitle = this.GameT.GetChild(2).GetChild(0).GetComponent<UIEmojiInput>();
    this.mInputTitle.textComponent.font = this.TTFont;
    this.tmptext = this.mInputTitle.placeholder as UIText;
    this.tmptext.font = this.TTFont;
    this.text_Title = this.GameT.GetChild(2).GetChild(0).GetChild(1).GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    // ISSUE: method pointer
    this.mInputTitle.onEndEdit.AddListener(new UnityAction<string>((object) this, __methodptr(\u003COnOpen\u003Em__F3)));
    this.mInputTitle.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
    this.mInputEditor = this.GameT.GetChild(3).GetChild(0).GetComponent<UIEmojiInput>();
    this.mInputEditor.textComponent.font = this.TTFont;
    this.tmptext = this.mInputEditor.placeholder as UIText;
    this.tmptext.font = this.TTFont;
    this.text_Editor = this.GameT.GetChild(3).GetChild(0).GetChild(1).GetComponent<UIText>();
    this.text_Editor.font = this.TTFont;
    this.text_tmpStr[1] = this.GameT.GetChild(3).GetChild(1).GetComponent<UIText>();
    this.text_tmpStr[1].font = this.TTFont;
    this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(5399U);
    this.text_Editor2 = this.GameT.GetChild(3).GetChild(2).GetComponent<UIText>();
    this.text_Editor2.font = this.TTFont;
    this.btn_BookMarks = this.GameT.GetChild(4).GetComponent<UIButton>();
    this.btn_BookMarks.m_Handler = (IUIButtonClickHandler) this;
    this.btn_BookMarks.m_BtnID1 = 1;
    this.btn_BookMarks.m_EffectType = e_EffectType.e_Scale;
    this.btn_BookMarks.transition = (Selectable.Transition) 0;
    ((Component) this.btn_BookMarks).gameObject.SetActive(false);
    this.btn_btn_SendLetter = this.GameT.GetChild(5).GetComponent<UIButton>();
    this.btn_btn_SendLetter.m_Handler = (IUIButtonClickHandler) this;
    this.btn_btn_SendLetter.m_BtnID1 = 2;
    this.btn_btn_SendLetter.m_EffectType = e_EffectType.e_Scale;
    this.btn_btn_SendLetter.transition = (Selectable.Transition) 0;
    this.text_tmpStr[2] = this.GameT.GetChild(5).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[2].font = this.TTFont;
    this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(5400U);
    if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 8)
      ((Graphic) this.btn_btn_SendLetter.image).color = Color.gray;
    this.tmpImg = this.GameT.GetChild(6).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.tmpImg).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(6).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.m_Mat;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    switch (this.mEditorKind)
    {
      case 1:
        this.mInputName.text = this.DM.Letter_ReplyName_KTN.ToString();
        this.mInputTitle.text = this.DM.Letter_ReplyTitle_Alliance.ToString();
        this.mInputName.interactable = false;
        this.mInputTitle.interactable = false;
        break;
      case 2:
      case 3:
        this.mInputName.text = this.DM.Letter_ReplyName.ToString();
        this.mInputName.interactable = false;
        break;
    }
    if (this.DM.bMailAddBookMark)
    {
      if (this.DM.Letter_ReplyName != null)
        this.mInputName.text = this.DM.Letter_ReplyName;
      if (this.DM.Letter_ReplyTitle != null)
        this.mInputTitle.text = this.DM.Letter_ReplyTitle;
      if (this.DM.Letter_ReplyEditor != null)
        this.mInputEditor.text = this.DM.Letter_ReplyEditor;
    }
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
  }

  public void ChangText(string ID)
  {
    this.text_Title.text = ID;
    this.text_Title.SetAllDirty();
    this.text_Title.cachedTextGenerator.Invalidate();
    this.mInputTitle.text = StringManager.InputTemp;
    this.mInputTitle.text = ID;
  }

  protected char OnValidateInput(string text, int index, char check)
  {
    if (Encoding.UTF8.GetByteCount(text) + Encoding.UTF8.GetByteCount(check.ToString()) > 64)
      return char.MinValue;
    this.text_Title.text = text;
    this.text_Title.SetAllDirty();
    this.text_Title.cachedTextGenerator.Invalidate();
    return check;
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (Encoding.UTF8.GetBytes(this.mInputEditor.text).Length > 0)
          this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(6034U), this.DM.mStringTable.GetStringByID(6035U), 1, YesText: this.DM.mStringTable.GetStringByID(6036U), NoText: this.DM.mStringTable.GetStringByID(6037U));
        else
          this.door.CloseMenu();
        this.DM.bMailAddBookMark = false;
        break;
      case 2:
        if (((Graphic) sender.image).color == Color.gray)
        {
          this.GUIM.MsgStr.ClearString();
          this.GUIM.MsgStr.IntToFormat(8L);
          this.GUIM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(9167U));
          this.GUIM.AddHUDMessage(this.GUIM.MsgStr.ToString(), (ushort) byte.MaxValue);
          break;
        }
        if (this.mEditorKind == 3 && this.DM.RoleAlliance.Rank < AllianceRank.RANK2)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
          break;
        }
        char[] charArray1 = this.mInputTitle.text.ToCharArray();
        char[] charArray2 = this.mInputEditor.text.ToCharArray();
        if (this.DM.Letter_ReplyTitle == null)
          this.DM.Letter_ReplyTitle = string.Empty;
        char[] charArray3 = this.DM.Letter_ReplyTitle.ToCharArray();
        if (this.DM.Letter_ReplyName == null)
          this.DM.Letter_ReplyName = string.Empty;
        char[] charArray4 = this.DM.Letter_ReplyName.ToCharArray();
        if (this.DM.m_BannedWord != null)
        {
          this.DM.m_BannedWord.CheckBannedWord(charArray1);
          this.DM.m_BannedWord.CheckBannedWord(charArray2);
          this.DM.m_BannedWord.CheckBannedWord(charArray3);
          this.DM.m_BannedWord.CheckBannedWord(charArray4);
        }
        byte[] bytes1 = Encoding.UTF8.GetBytes(charArray1);
        byte[] bytes2 = Encoding.UTF8.GetBytes(charArray2);
        byte[] bytes3 = Encoding.UTF8.GetBytes(this.mInputName.text);
        byte[] bytes4 = Encoding.UTF8.GetBytes(charArray3);
        byte[] bytes5 = Encoding.UTF8.GetBytes(charArray4);
        int num1 = 0;
        for (int index = 0; index <= 32 && index < bytes5.Length && bytes5[index] != (byte) 0; ++index)
        {
          if (bytes5[index] != (byte) 0)
            ++num1;
        }
        if (this.mEditorKind == 0)
        {
          if (bytes3.Length > 13)
          {
            this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5379U), (ushort) byte.MaxValue);
            break;
          }
        }
        else if (this.mEditorKind != 3 && num1 > 13)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5379U), (ushort) byte.MaxValue);
          break;
        }
        int data1 = 0;
        for (int index = 0; index < 10; ++index)
        {
          if (this.DM.RoleBookMark.SelectBookMarkIndex[index] != (byte) 0)
            ++data1;
        }
        this.text_Editor2.text = this.mInputEditor.text;
        if ((double) this.text_Editor2.preferredHeight > 557.0)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(6049U), (ushort) byte.MaxValue);
          break;
        }
        int num2 = 0;
        for (int index = 0; index <= 64 && index < bytes1.Length && bytes1[index] != (byte) 0; ++index)
        {
          if (bytes1[index] != (byte) 0)
            ++num2;
        }
        if ((this.mEditorKind == 0 || this.mEditorKind == 2) && num2 > 64 || this.mEditorKind == 3 && bytes4.Length > 64 || this.mEditorKind == 1 && this.mEditorType != 1 && num2 > 64)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(6018U), (ushort) byte.MaxValue);
          break;
        }
        if (bytes2.Length > 1024)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(6017U), (ushort) byte.MaxValue);
          break;
        }
        if (!GUIManager.Instance.ShowUILock(EUILock.LetterEditor))
          break;
        uint data2 = 0;
        MessagePacket messagePacket = new MessagePacket((ushort) 1124);
        messagePacket.Protocol = this.mEditorKind == 3 ? Protocol._MSG_REQUEST_SENDALLIMAIL : Protocol._MSG_REQUEST_SENDREGMAIL;
        messagePacket.AddSeqId();
        if (this.mEditorKind != 3)
        {
          if (this.mEditorKind == 1)
            data2 = this.DM.Letter_ReplyID;
          messagePacket.Add(data2);
          if (this.mEditorKind == 0)
            messagePacket.Add(this.mInputName.text, 13);
          else
            messagePacket.Add(this.DM.Letter_ReplyName, 13);
        }
        if (this.DM.ServerVersionMajor != (byte) 0)
        {
          byte data3 = !ArabicTransfer.Instance.IsArabicStr(this.mInputEditor.text) ? (byte) 1 : (byte) 2;
          messagePacket.Add(data3);
        }
        if (this.mEditorKind == 1)
        {
          messagePacket.Add((byte) bytes4.Length);
          messagePacket.Add((ushort) bytes2.Length);
          messagePacket.Add((byte) data1);
          messagePacket.Add(bytes4);
        }
        else
        {
          messagePacket.Add((byte) bytes1.Length);
          messagePacket.Add((ushort) bytes2.Length);
          messagePacket.Add((byte) data1);
          messagePacket.Add(bytes1);
        }
        messagePacket.Add(bytes2);
        messagePacket.Add(this.DM.RoleBookMark.SelectBookMarkIndex);
        messagePacket.Send();
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    this.door.CloseMenu();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if (this.DM.RoleAlliance.Id != 0U || this.mEditorKind != 2 && this.mEditorKind != 3)
          break;
        this.door.CloseMenu_Alliance(EGUIWindow.UI_LetterEditor);
        break;
      case NetworkNews.Refresh_Alliance:
        if (this.DM.RoleAlliance.Id != 0U || this.mEditorKind != 2 && this.mEditorKind != 3)
          break;
        this.door.CloseMenu_Alliance(EGUIWindow.UI_LetterEditor);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Name != (Object) null && ((Behaviour) this.text_Name).enabled)
    {
      ((Behaviour) this.text_Name).enabled = false;
      ((Behaviour) this.text_Name).enabled = true;
    }
    if ((Object) this.text_Title != (Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((Object) this.text_Editor != (Object) null && ((Behaviour) this.text_Editor).enabled)
    {
      ((Behaviour) this.text_Editor).enabled = false;
      ((Behaviour) this.text_Editor).enabled = true;
    }
    if ((Object) this.text_Editor2 != (Object) null && ((Behaviour) this.text_Editor2).enabled)
    {
      ((Behaviour) this.text_Editor2).enabled = false;
      ((Behaviour) this.text_Editor2).enabled = true;
    }
    if ((Object) this.mInputName != (Object) null && ((Behaviour) this.mInputName.textComponent).enabled)
    {
      ((Behaviour) this.mInputName.textComponent).enabled = false;
      ((Behaviour) this.mInputName.textComponent).enabled = true;
    }
    if ((Object) this.mInputName != (Object) null && ((Behaviour) this.mInputName.placeholder).enabled)
    {
      ((Behaviour) this.mInputName.placeholder).enabled = false;
      ((Behaviour) this.mInputName.placeholder).enabled = true;
    }
    if ((Object) this.mInputTitle != (Object) null && ((Behaviour) this.mInputTitle.textComponent).enabled)
    {
      ((Behaviour) this.mInputTitle.textComponent).enabled = false;
      ((Behaviour) this.mInputTitle.textComponent).enabled = true;
    }
    if ((Object) this.mInputTitle != (Object) null && ((Behaviour) this.mInputTitle.placeholder).enabled)
    {
      ((Behaviour) this.mInputTitle.placeholder).enabled = false;
      ((Behaviour) this.mInputTitle.placeholder).enabled = true;
    }
    if ((Object) this.mInputEditor != (Object) null && ((Behaviour) this.mInputEditor.textComponent).enabled)
    {
      ((Behaviour) this.mInputEditor.textComponent).enabled = false;
      ((Behaviour) this.mInputEditor.textComponent).enabled = true;
    }
    if ((Object) this.mInputEditor != (Object) null && ((Behaviour) this.mInputEditor.placeholder).enabled)
    {
      ((Behaviour) this.mInputEditor.placeholder).enabled = false;
      ((Behaviour) this.mInputEditor.placeholder).enabled = true;
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
