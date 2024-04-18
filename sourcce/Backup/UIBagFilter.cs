// Decompiled with JetBrains decompiler
// Type: UIBagFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class UIBagFilter : GUIWindow
{
  private UIBagFilterBase[] UIWindow = new UIBagFilterBase[3];
  public UIBagFilterBase ActivateWindow;
  public int Type;

  public override void OnOpen(int arg1, int arg2)
  {
    int num = arg1 >> 16;
    arg1 &= (int) ushort.MaxValue;
    this.Type = arg1;
    switch (this.Type)
    {
      case 0:
        this.UIWindow[0] = (UIBagFilterBase) new UIBag();
        this.UIWindow[0].transform = this.transform;
        this.UIWindow[0].OnOpen(num, arg2);
        this.ActivateWindow = this.UIWindow[0];
        break;
      case 1:
        this.UIWindow[0] = (UIBagFilterBase) new UIResourceFilter();
        this.UIWindow[0].transform = this.transform;
        this.UIWindow[0].OnOpen(num, arg2);
        this.ActivateWindow = this.UIWindow[0];
        break;
      case 2:
        this.UIWindow[0] = (UIBagFilterBase) new UISpeedup();
        this.UIWindow[0].transform = this.transform;
        this.UIWindow[0].OnOpen(num, arg2);
        this.ActivateWindow = this.UIWindow[0];
        NewbieManager.CheckTeach(ETeachKind.TURBO);
        break;
      case 3:
        this.UIWindow[0] = (UIBagFilterBase) new NumberConfirm();
        this.UIWindow[0].transform = this.transform;
        this.UIWindow[0].OnOpen(num, arg2);
        this.ActivateWindow = this.UIWindow[0];
        this.transform.GetChild(this.transform.childCount - 1).gameObject.SetActive(true);
        break;
      case 4:
        this.UIWindow[0] = (UIBagFilterBase) new UIItemFilter();
        this.UIWindow[0].transform = this.transform;
        this.UIWindow[0].OnOpen(num, arg2);
        this.ActivateWindow = this.UIWindow[0];
        break;
      case 5:
        DataManager instance = DataManager.Instance;
        ItemBuff recordByIndex = instance.ItemBuffTable.GetRecordByIndex(arg2);
        Equip recordByKey = instance.EquipTable.GetRecordByKey(recordByIndex.BuffItemID);
        this.UIWindow[0] = (byte) ((uint) recordByKey.EquipKind - 1U) != (byte) 11 || recordByKey.PropertiesInfo[0].Propertieskey < (ushort) 13 || recordByKey.PropertiesInfo[0].Propertieskey > (ushort) 15 ? (UIBagFilterBase) new UIBuffItemFilter() : (UIBagFilterBase) new UIKingBufferFilter();
        this.UIWindow[0].transform = this.transform;
        this.UIWindow[0].OnOpen(num, arg2);
        this.ActivateWindow = this.UIWindow[0];
        break;
      case 6:
        this.UIWindow[0] = (UIBagFilterBase) new UIItemKindFilter();
        this.UIWindow[0].transform = this.transform;
        this.UIWindow[0].OnOpen(num, arg2);
        this.ActivateWindow = this.UIWindow[0];
        break;
      case 7:
        this.UIWindow[0] = (UIBagFilterBase) new UIGemRemoveFilter();
        this.UIWindow[0].transform = this.transform;
        this.UIWindow[0].OnOpen(num, arg2);
        this.ActivateWindow = this.UIWindow[0];
        break;
      case 8:
        this.UIWindow[0] = (UIBagFilterBase) new UIGiftStore();
        this.UIWindow[0].transform = this.transform;
        this.UIWindow[0].OnOpen(num, arg2);
        this.ActivateWindow = this.UIWindow[0];
        break;
      case 9:
        this.UIWindow[0] = (UIBagFilterBase) new UIKingReward();
        this.UIWindow[0].transform = this.transform;
        this.UIWindow[0].OnOpen(num, arg2);
        this.ActivateWindow = this.UIWindow[0];
        break;
    }
  }

  public override void OnClose()
  {
    if (this.ActivateWindow != null)
      this.ActivateWindow.OnClose();
    for (int index = 1; index < this.UIWindow.Length; ++index)
    {
      if (this.UIWindow[index] != null)
      {
        this.UIWindow[index].OnClose();
        Object.Destroy((Object) this.UIWindow[index].ThisTransform.gameObject);
      }
    }
  }

  public void Update()
  {
    if (this.ActivateWindow == null)
      return;
    this.ActivateWindow.Update();
  }

  public override void UpdateUI(int arge1, int arge2)
  {
    OpenBagFilterType openBagFilterType = (OpenBagFilterType) arge1;
    switch (openBagFilterType)
    {
      case OpenBagFilterType.Bag:
        switch (arge2)
        {
          case -1:
            if (this.UIWindow[2] == null)
            {
              GUIManager.Instance.CloseMenu(EGUIWindow.UI_BagFilter);
              return;
            }
            this.UIWindow[2].ThisTransform.gameObject.SetActive(false);
            this.ActivateWindow = this.UIWindow[0];
            return;
          case 0:
            if (this.UIWindow[1] == null)
            {
              GUIManager.Instance.CloseMenu(EGUIWindow.UI_BagFilter);
              return;
            }
            this.UIWindow[1].ThisTransform.gameObject.SetActive(false);
            this.ActivateWindow = this.UIWindow[0];
            return;
          default:
            return;
        }
      case OpenBagFilterType.NumConfirm:
        if (this.UIWindow[1] == null)
        {
          this.UIWindow[1] = (UIBagFilterBase) new NumberConfirm();
          this.UIWindow[1].transform = this.transform;
          this.UIWindow[1].OnOpen(arge2, (int) this.UIWindow[0].UseTargetID);
          this.UIWindow[1].ThisTransform.SetParent((Transform) GUIManager.Instance.m_SecWindowLayer);
        }
        else
          this.UIWindow[1].UpdateUI(arge2, (int) this.UIWindow[0].UseTargetID);
        this.UIWindow[1].ThisTransform.gameObject.SetActive(true);
        this.ActivateWindow = this.UIWindow[1];
        break;
      default:
        if (openBagFilterType == OpenBagFilterType.BuyNumConfirm)
        {
          if (this.UIWindow[2] == null)
          {
            this.UIWindow[2] = (UIBagFilterBase) new BuyNumConfirm();
            this.UIWindow[2].transform = this.transform;
            this.UIWindow[2].OnOpen(arge2, (int) this.UIWindow[0].UseTargetID);
            this.UIWindow[2].ThisTransform.SetParent((Transform) GUIManager.Instance.m_SecWindowLayer);
          }
          else if (!this.UIWindow[2].ThisTransform.gameObject.activeSelf)
            (this.UIWindow[2] as BuyNumConfirm).UpdateData(arge2);
          else
            this.UIWindow[2].UpdateUI(arge2, (int) this.UIWindow[0].UseTargetID);
          this.UIWindow[2].ThisTransform.gameObject.SetActive(true);
          this.ActivateWindow = this.UIWindow[2];
          break;
        }
        if (this.ActivateWindow is NumberConfirm)
        {
          this.UIWindow[0].UpdateUI(arge1, arge2);
          break;
        }
        this.ActivateWindow.UpdateUI(arge1, arge2);
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (this.UIWindow[0] != null)
      this.UIWindow[0].UpdateNetwork(meg);
    if (this.UIWindow[1] != null)
      this.UIWindow[1].UpdateNetwork(meg);
    if (this.UIWindow[2] == null)
      return;
    this.UIWindow[2].UpdateNetwork(meg);
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (this.UIWindow[0] != null)
      this.UIWindow[0].UpdateTime(bOnSecond);
    if (this.UIWindow[1] == null)
      return;
    this.UIWindow[1].UpdateTime(bOnSecond);
  }

  public override bool OnBackButtonClick()
  {
    if (this.UIWindow[1] == null || !this.UIWindow[1].ThisTransform.gameObject.activeSelf)
      return false;
    this.UIWindow[1].ThisTransform.gameObject.SetActive(false);
    this.ActivateWindow = this.UIWindow[0];
    return true;
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    this.ActivateWindow.OnOKCancelBoxClick(bOK, arg1, arg2);
  }
}
