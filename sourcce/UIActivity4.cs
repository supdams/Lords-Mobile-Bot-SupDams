// Decompiled with JetBrains decompiler
// Type: UIActivity4
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIActivity4 : 
  GUIWindow,
  UILoadImageHander,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler,
  IUILEBtnClickHandler
{
  private const float ItemDeltaY = -62f;
  private const float ObjectY = 181f;
  private Transform m_transform;
  private Transform ContentT;
  private DataManager DM;
  private GUIManager GM;
  private StringManager SM;
  private ActivityManager AM;
  private CString[] TitleText;
  private CString[] GemCountText;
  private CString[] TotalpriceText;
  private CString[] NoPriceText;
  private int PrizeCount = 7;
  private int[] ItemCount;
  private CString[][] ItemCountText;
  private bool bPrize;
  private byte ActivityIndex;
  private ActivityDataType tmpData;
  private UIText[] OutText = new UIText[4];
  private UIText[] STitleText;
  private UIText[] SGemCountText;
  private UIText[] STotalpriceText;
  private UIText[] SNoPriceText;
  private UIText[][] SItemCountText;
  private List<UIHIBtn> ItemHIBtn = new List<UIHIBtn>();
  private CString InfoStr;

  public override void OnOpen(int arg1, int arg2)
  {
    // ISSUE: unable to decompile the method.
  }

  public override void OnClose()
  {
    if (this.bPrize)
    {
      for (int index1 = 0; index1 < this.PrizeCount; ++index1)
      {
        this.SM.DeSpawnString(this.TitleText[index1]);
        this.SM.DeSpawnString(this.GemCountText[index1]);
        this.SM.DeSpawnString(this.TotalpriceText[index1]);
        this.SM.DeSpawnString(this.NoPriceText[index1]);
        for (int index2 = 0; index2 < this.ItemCount[index1]; ++index2)
          this.SM.DeSpawnString(this.ItemCountText[index1][index2]);
      }
      if (!((Object) this.ContentT != (Object) null))
        return;
      this.AM.Act4Pos = this.ContentT.GetComponent<RectTransform>().anchoredPosition;
    }
    else
      this.SM.DeSpawnString(this.InfoStr);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        if (!this.bPrize)
          break;
        if (this.tmpData.EventState == EActivityState.EAS_None)
        {
          Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
          if (!(bool) (Object) menu)
            break;
          menu.CloseMenu();
          break;
        }
        ActivityManager.Instance.ChangeStateReOpenPrize(this.ActivityIndex);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        for (int index = 0; index < this.OutText.Length; ++index)
        {
          if (this.OutText != null && (Object) this.OutText[index] != (Object) null && ((Behaviour) this.OutText[index]).enabled)
          {
            ((Behaviour) this.OutText[index]).enabled = false;
            ((Behaviour) this.OutText[index]).enabled = true;
          }
        }
        if (!this.bPrize)
          break;
        for (int index = 0; index < this.ItemHIBtn.Count; ++index)
          this.ItemHIBtn[index].Refresh_FontTexture();
        for (int index1 = 0; index1 < this.PrizeCount; ++index1)
        {
          if (this.STitleText != null && (Object) this.STitleText[index1] != (Object) null && ((Behaviour) this.STitleText[index1]).enabled)
          {
            ((Behaviour) this.STitleText[index1]).enabled = false;
            ((Behaviour) this.STitleText[index1]).enabled = true;
          }
          if (this.SGemCountText != null && (Object) this.SGemCountText[index1] != (Object) null && ((Behaviour) this.SGemCountText[index1]).enabled)
          {
            ((Behaviour) this.SGemCountText[index1]).enabled = false;
            ((Behaviour) this.SGemCountText[index1]).enabled = true;
          }
          if (this.STotalpriceText != null && (Object) this.STotalpriceText[index1] != (Object) null && ((Behaviour) this.STotalpriceText[index1]).enabled)
          {
            ((Behaviour) this.STotalpriceText[index1]).enabled = false;
            ((Behaviour) this.STotalpriceText[index1]).enabled = true;
          }
          if (this.SNoPriceText != null && (Object) this.SNoPriceText[index1] != (Object) null && ((Behaviour) this.SNoPriceText[index1]).enabled)
          {
            ((Behaviour) this.SNoPriceText[index1]).enabled = false;
            ((Behaviour) this.SNoPriceText[index1]).enabled = true;
          }
          if (this.ItemCount != null && this.SItemCountText != null)
          {
            for (int index2 = 0; index2 < this.ItemCount[index1]; ++index2)
            {
              if (this.SItemCountText[index1] != null && (Object) this.SItemCountText[index1][index2] != (Object) null && ((Behaviour) this.SItemCountText[index1][index2]).enabled)
              {
                ((Behaviour) this.SItemCountText[index1][index2]).enabled = false;
                ((Behaviour) this.SItemCountText[index1][index2]).enabled = true;
              }
            }
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
        if (!this.bPrize || (int) this.ActivityIndex != arg2 || this.tmpData.EventState != EActivityState.EAS_Prepare)
          break;
        ActivityManager.Instance.ChangeStateReOpenPrize(this.ActivityIndex);
        break;
      case 2:
        if (!this.bPrize || (int) this.ActivityIndex != arg2)
          break;
        ActivityManager.Instance.ChangeStateReOpenPrize(this.ActivityIndex);
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 != 1)
      return;
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

  public void OnLEButtonClick(UILEBtn sender)
  {
  }

  public void OnHIButtonClick(UIHIBtn sender) => MallManager.Instance.OpenDetail(sender.HIID);

  public void OnButtonDown(UIButtonHint sender)
  {
    if (this.ActivityIndex != (byte) 210 || this.AM.AW_PrizeGroupID <= (byte) 0)
      return;
    CString Content = StringManager.Instance.SpawnString(300);
    Content.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(17029U));
    Content.AppendFormat(this.DM.mStringTable.GetStringByID(1003U));
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, Content, Vector2.zero);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Hide((bool) (Object) sender);
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
