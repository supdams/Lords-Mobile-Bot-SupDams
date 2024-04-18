// Decompiled with JetBrains decompiler
// Type: UIGiftStore
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIGiftStore : UIBag
{
  private UIText TitleText;
  private CString ReceiveName;
  private CString SendName;

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager instance = GUIManager.Instance;
    if (((int) instance.BagTagSaved[0] & 3) != 1)
      instance.BagTagSaved[0] = (byte) 1;
    base.OnOpen(arg1, arg2);
    this.MainTitle.text = DataManager.Instance.mStringTable.GetStringByID(9092U);
    this.ThisTransform.GetChild(2).gameObject.SetActive(false);
    RectTransform component1 = this.ThisTransform.GetChild(3).GetComponent<RectTransform>();
    for (int index = 0; index < ((Transform) component1).childCount; ++index)
      ((Transform) component1).GetChild(index).GetComponent<RectTransform>().anchoredPosition = new Vector2((float) (149 * index) - 329f, 146.5f);
    this.ThisTransform.GetChild(4).GetComponent<RectTransform>().anchoredPosition = new Vector2(-31f, 116.5f);
    this.ThisTransform.GetChild(5).GetComponent<RectTransform>().anchoredPosition = new Vector2(-31f, -97f);
    RectTransform component2 = this.ThisTransform.GetChild(6).GetChild(0).GetComponent<RectTransform>();
    component2.sizeDelta = new Vector2(776f, 426f);
    component2.anchoredPosition = new Vector2(-30.78f, -98.3f);
    this.TitleText = this.ThisTransform.GetChild(6).GetChild(1).GetComponent<UIText>();
    this.TitleText.font = instance.GetTTFFont();
    ((Component) this.TitleText).gameObject.SetActive(true);
    this.AddRefreshText((Text) this.TitleText);
    this.ThisTransform.GetChild(8).GetChild(1).gameObject.SetActive(false);
    this.ReceiveName = StringManager.Instance.SpawnString(100);
    this.SendName = StringManager.Instance.SpawnString();
    this.SetReceiveName(instance.SendTag, instance.SendName);
  }

  public void SetReceiveName(CString Tag, CString Name)
  {
    this.SendName.ClearString();
    this.SendName.Append(Name);
    this.ReceiveName.ClearString();
    this.ReceiveName.StringToFormat(Tag);
    this.ReceiveName.StringToFormat(Name);
    this.ReceiveName.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9094U));
    this.TitleText.text = this.ReceiveName.ToString();
    this.TitleText.SetAllDirty();
    this.TitleText.cachedTextGenerator.Invalidate();
  }

  protected override void ChangeBagTag(UIBag.ClickType Tag)
  {
    base.ChangeBagTag(Tag);
    this.MainTitle.text = DataManager.Instance.mStringTable.GetStringByID(9092U);
    for (byte index = 0; (int) index < this.ScrollItem.Length; ++index)
      this.ScrollItem[(int) index].BuyUseBtn.m_BtnID1 = 14;
  }

  public override void OnButtonClick(UIButton sender)
  {
    base.OnButtonClick(sender);
    if (sender.m_BtnID1 != 14)
      return;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    if (this.ShopType == (byte) 1 && this.ScrollItem[sender.m_BtnID2].ItemPrice > DataManager.Instance.RoleAttr.Diamond)
    {
      GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(3966U), mStringTable.GetStringByID(646U), 4, mStringTable.GetStringByID(4507U), bCloseIDSet: true);
    }
    else
    {
      this.SelBuyIndex = (byte) sender.m_BtnID2;
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 10, (int) this.ScrollItem[sender.m_BtnID2].ItemSN << 16 | 16 | (int) this.ShopType);
    }
  }

  public override void OnClose()
  {
    base.OnClose();
    StringManager.Instance.DeSpawnString(this.ReceiveName);
    StringManager.Instance.DeSpawnString(this.SendName);
  }

  public override void UpdateUI(int arge1, int arge2)
  {
    if (arge1 >> 16 != 1)
      return;
    switch (arge1)
    {
      case 65537:
        ushort b = (ushort) (arge2 >> 16);
        ushort num = (ushort) (arge2 & (int) ushort.MaxValue);
        if ((int) this.ScrollItem[(int) this.SelBuyIndex].ItemID != (int) num)
        {
          for (byte index = 0; (int) index < this.ScrollItem.Length; ++index)
          {
            if ((int) this.ScrollItem[(int) index].ItemID == (int) num)
            {
              this.SelBuyIndex = index;
              break;
            }
          }
        }
        DataManager.Instance.sendBuySendItem(this.ShopType, this.ScrollItem[(int) this.SelBuyIndex].ItemSN, this.ScrollItem[(int) this.SelBuyIndex].ItemID, this.SendName, (ushort) Mathf.Max(1, (int) b));
        break;
      case 65540:
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) DataManager.Instance.EquipTable.GetRecordByKey(this.ScrollItem[(int) this.SelBuyIndex].ItemID).EquipName));
        cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9697U));
        GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
        break;
      default:
        base.UpdateUI(arge1, arge2);
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh:
        this.ChangeObjTag(this.CurrentObjTag, true, false);
        break;
      case NetworkNews.Refresh_Alliance:
        if (DataManager.Instance.RoleAlliance.Id != 0U)
          break;
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!((Object) menu != (Object) null))
          break;
        menu.CloseMenu_Alliance(EGUIWindow.UI_BagFilter);
        break;
    }
  }
}
