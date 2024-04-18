// Decompiled with JetBrains decompiler
// Type: UISuicideBox
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UISuicideBox : GUIWindow, IUIButtonClickHandler
{
  public const ushort SuicideItemID = 1317;
  public Transform TransCache;
  public UIText TitleText;
  public UIText Text1Text;
  public UIText Text2Text;
  private CString Text1Str;
  public UIText ItemNameText;
  public UIText ItemCountText;
  private CString ItemCountStr;
  public UIButton SendBtn;
  public CustomImage SendBtnBackImg;
  private CString NeedCtStr;
  public UIText NeedText;
  public UIText UseText;
  private ushort NeedItemCt;
  public UIButton CloseBtn;
  public static ushort ItemRequire;

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        UISuicideBox.SendRefresh();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.TransCache = this.transform;
    GUIManager instance1 = GUIManager.Instance;
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    DataManager instance2 = DataManager.Instance;
    this.TransCache.transform.GetComponent<CustomImage>().hander = (UILoadImageHander) instance1;
    Transform child1 = this.TransCache.transform.GetChild(0);
    child1.GetComponent<CustomImage>().hander = (UILoadImageHander) instance1;
    child1.GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) instance1;
    child1.GetChild(1).GetComponent<CustomImage>().hander = (UILoadImageHander) instance1;
    this.TitleText = child1.GetChild(2).GetComponent<UIText>();
    this.TitleText.font = ttfFont;
    this.TitleText.text = instance2.mStringTable.GetStringByID(15006U);
    this.Text1Text = child1.GetChild(3).GetComponent<UIText>();
    this.Text1Text.font = ttfFont;
    this.Text1Str = StringManager.Instance.SpawnString(200);
    this.Text2Text = child1.GetChild(4).GetComponent<UIText>();
    this.Text2Text.font = ttfFont;
    this.Text2Text.text = instance2.mStringTable.GetStringByID(15004U);
    this.SendBtnBackImg = child1.GetChild(5).GetComponent<CustomImage>();
    this.SendBtnBackImg.hander = (UILoadImageHander) instance1;
    this.SendBtn = child1.GetChild(5).GetComponent<UIButton>();
    this.SendBtn.m_Handler = (IUIButtonClickHandler) this;
    this.SendBtn.m_BtnID1 = 1;
    this.NeedText = child1.GetChild(5).GetChild(1).GetComponent<UIText>();
    this.NeedText.font = ttfFont;
    this.UseText = child1.GetChild(5).GetChild(0).GetComponent<UIText>();
    this.UseText.font = ttfFont;
    this.UseText.text = instance2.mStringTable.GetStringByID(15006U);
    this.NeedCtStr = StringManager.Instance.SpawnString();
    Transform child2 = child1.GetChild(6);
    child2.GetChild(1).GetComponent<CustomImage>().hander = (UILoadImageHander) instance1;
    this.ItemNameText = child2.GetChild(0).GetComponent<UIText>();
    this.ItemNameText.font = ttfFont;
    this.ItemNameText.text = instance2.mStringTable.GetStringByID(11577U);
    this.ItemCountText = child2.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.ItemCountText.font = ttfFont;
    this.ItemCountStr = StringManager.Instance.SpawnString();
    GUIManager.Instance.InitianHeroItemImg(child2.GetChild(2), eHeroOrItem.Item, (ushort) 1317, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.CheckSuicideItem();
    child1.GetChild(7).GetComponent<CustomImage>().hander = (UILoadImageHander) instance1;
    this.CloseBtn = child1.GetChild(7).GetComponent<UIButton>();
    this.CloseBtn.m_Handler = (IUIButtonClickHandler) this;
    this.CloseBtn.m_BtnID1 = 2;
  }

  public override void OnClose()
  {
    if (this.Text1Str != null)
      StringManager.Instance.DeSpawnString(this.Text1Str);
    if (this.ItemCountStr != null)
      StringManager.Instance.DeSpawnString(this.ItemCountStr);
    if (this.NeedCtStr == null)
      return;
    StringManager.Instance.DeSpawnString(this.NeedCtStr);
  }

  public static bool OpenSelf(bool bCameraMode = false)
  {
    return (bool) (Object) GUIManager.Instance.OpenMenu(EGUIWindow.UI_SuicideBox, bCameraMode: bCameraMode, bSecWindow: true);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      if (sender.m_BtnID2 == 1)
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(15007U), (ushort) byte.MaxValue);
      else
        DataManager.Instance.UseItem((ushort) 1317, this.NeedItemCt, (ushort) 0, (ushort) 0, (ushort) 0, 0U, string.Empty);
    }
    else
    {
      if (sender.m_BtnID1 != 2)
        return;
      GUIManager.Instance.CloseMenu(EGUIWindow.UI_SuicideBox);
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != 0)
      return;
    this.CheckSuicideItem();
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.TitleText != (Object) null && ((Behaviour) this.TitleText).enabled)
    {
      ((Behaviour) this.TitleText).enabled = false;
      ((Behaviour) this.TitleText).enabled = true;
    }
    if ((Object) this.Text2Text != (Object) null && ((Behaviour) this.Text2Text).enabled)
    {
      ((Behaviour) this.Text2Text).enabled = false;
      ((Behaviour) this.Text2Text).enabled = true;
    }
    if ((Object) this.ItemNameText != (Object) null && ((Behaviour) this.ItemNameText).enabled)
    {
      ((Behaviour) this.ItemNameText).enabled = false;
      ((Behaviour) this.ItemNameText).enabled = true;
    }
    if ((Object) this.ItemCountText != (Object) null && ((Behaviour) this.ItemCountText).enabled)
    {
      ((Behaviour) this.ItemCountText).enabled = false;
      ((Behaviour) this.ItemCountText).enabled = true;
    }
    if ((Object) this.Text1Text != (Object) null && ((Behaviour) this.Text1Text).enabled)
    {
      ((Behaviour) this.Text1Text).enabled = false;
      ((Behaviour) this.Text1Text).enabled = true;
    }
    if ((Object) this.NeedText != (Object) null && ((Behaviour) this.NeedText).enabled)
    {
      ((Behaviour) this.NeedText).enabled = false;
      ((Behaviour) this.NeedText).enabled = true;
    }
    if (!((Object) this.UseText != (Object) null) || !((Behaviour) this.UseText).enabled)
      return;
    ((Behaviour) this.UseText).enabled = false;
    ((Behaviour) this.UseText).enabled = true;
  }

  public void CheckSuicideItem()
  {
    int curItemQuantity = (int) DataManager.Instance.GetCurItemQuantity((ushort) 1317, (byte) 0);
    this.ItemCountStr.ClearString();
    this.ItemCountStr.Append(DataManager.Instance.mStringTable.GetStringByID(281U));
    this.ItemCountStr.IntToFormat((long) curItemQuantity, bNumber: true);
    this.ItemCountStr.AppendFormat("{0}");
    this.ItemCountText.text = this.ItemCountStr.ToString();
    this.ItemCountText.SetAllDirty();
    this.ItemCountText.cachedTextGenerator.Invalidate();
    int x = 24;
    this.Text1Str.ClearString();
    this.Text1Str.IntToFormat((long) x, bNumber: true);
    this.Text1Str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(15003U));
    this.Text1Text.text = this.Text1Str.ToString();
    this.Text1Text.SetAllDirty();
    this.Text1Text.cachedTextGenerator.Invalidate();
    this.NeedItemCt = UISuicideBox.ItemRequire;
    this.NeedCtStr.ClearString();
    this.NeedCtStr.IntToFormat((long) this.NeedItemCt, bNumber: true);
    this.NeedCtStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(15005U));
    this.NeedText.text = this.NeedCtStr.ToString();
    this.NeedText.SetAllDirty();
    this.NeedText.cachedTextGenerator.Invalidate();
    this.SetSendButtonColor(curItemQuantity);
  }

  private void SetSendButtonColor(int itemCt)
  {
    if (itemCt < (int) this.NeedItemCt)
    {
      this.SendBtn.m_BtnID2 = 1;
      ((Graphic) this.NeedText).color = new Color(0.898f, 0.0f, 0.31f);
      UIText needText = this.NeedText;
      ((Graphic) needText).color = ((Graphic) needText).color * Color.gray;
      ((Graphic) this.UseText).color = Color.gray;
      ((Graphic) this.SendBtnBackImg).color = Color.gray;
    }
    else
    {
      this.SendBtn.m_BtnID2 = 0;
      ((Graphic) this.NeedText).color = Color.white;
      ((Graphic) this.UseText).color = Color.white;
      ((Graphic) this.SendBtnBackImg).color = Color.white;
    }
  }

  public static void RespSuicideNumByPowerBoard(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.LordInfo);
    MP.ReadInt();
    UISuicideBox.ItemRequire = MP.ReadUShort();
    if ((Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_SuicideBox) != (Object) null)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuicideBox, 0);
    else
      UISuicideBox.OpenSelf();
  }

  public static void SendRefresh()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.LordInfo))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_SUICIDENUM_BY_POWER_BOARD;
    messagePacket.AddSeqId();
    messagePacket.Add(DataManager.Instance.RoleAttr.Power);
    messagePacket.Send();
  }
}
