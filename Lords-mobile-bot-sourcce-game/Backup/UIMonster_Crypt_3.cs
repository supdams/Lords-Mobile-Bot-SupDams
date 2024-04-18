// Decompiled with JetBrains decompiler
// Type: UIMonster_Crypt_3
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIMonster_Crypt_3 : GUIWindow, IUIButtonClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private Transform GameT;
  private Font TTFont;
  private UISpritesArray SArray;
  private RectTransform Content_RT;
  private RectTransform P1_RT;
  private RectTransform P2_RT;
  private UIButton btn_EXIT;
  private UIText text_Title;
  private UIText text_Info;
  private int tmpItemNum;
  private eMC3_OpenKind OpenKind;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    ushort ID1 = 9171;
    ushort ID2 = 9178;
    this.OpenKind = (eMC3_OpenKind) arg1;
    if (this.OpenKind == eMC3_OpenKind.ePetInfo)
    {
      ID1 = (ushort) 16071;
      ID2 = (ushort) 16070;
    }
    this.text_Title = this.GameT.GetChild(0).GetChild(2).GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.text_Title.text = this.DM.mStringTable.GetStringByID((uint) ID1);
    Transform child = this.GameT.GetChild(1).GetChild(0);
    this.Content_RT = child.GetComponent<RectTransform>();
    this.text_Info = child.GetChild(0).GetComponent<UIText>();
    this.text_Info.font = this.TTFont;
    this.text_Info.text = this.DM.mStringTable.GetStringByID((uint) ID2);
    if ((double) this.text_Info.preferredHeight > (double) ((Graphic) this.text_Info).rectTransform.sizeDelta.y)
    {
      ((Graphic) this.text_Info).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Info).rectTransform.sizeDelta.x, this.text_Info.preferredHeight);
      this.Content_RT.sizeDelta = new Vector2(this.Content_RT.sizeDelta.x, this.text_Info.preferredHeight);
    }
    this.btn_EXIT = this.GameT.GetChild(2).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    if (!this.GUIM.bOpenOnIPhoneX)
      return;
    ((Behaviour) this.GameT.GetChild(2).GetComponent<Image>()).enabled = false;
  }

  public override void OnClose()
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 != 0)
      return;
    if (this.OpenKind == eMC3_OpenKind.eNormal)
    {
      GamblingManager.Instance.CloseMenu();
    }
    else
    {
      if (this.OpenKind != eMC3_OpenKind.ePetInfo)
        return;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!(bool) (Object) menu)
        return;
      menu.CloseMenu();
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Title != (Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if (!((Object) this.text_Info != (Object) null) || !((Behaviour) this.text_Info).enabled)
      return;
    ((Behaviour) this.text_Info).enabled = false;
    ((Behaviour) this.text_Info).enabled = true;
  }
}
