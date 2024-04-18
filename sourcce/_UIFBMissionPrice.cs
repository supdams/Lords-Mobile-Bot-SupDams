// Decompiled with JetBrains decompiler
// Type: _UIFBMissionPrice
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public struct _UIFBMissionPrice
{
  private GameObject gameobject;
  private RectTransform recttransform;
  private UIText Title;
  private _UIFBMissionPrice._UIPrice[] Price;

  public _UIFBMissionPrice(Transform transform, Font font)
  {
    this.gameobject = transform.gameObject;
    this.recttransform = transform as RectTransform;
    this.Title = transform.GetChild(0).GetComponent<UIText>();
    this.Title.font = font;
    this.Price = new _UIFBMissionPrice._UIPrice[4];
    GUIManager instance = GUIManager.Instance;
    for (int index = 0; index < 4; ++index)
      this.Price[index] = new _UIFBMissionPrice._UIPrice(instance, transform.GetChild(index + 1), font);
  }

  public float Top
  {
    set
    {
      this.recttransform.anchoredPosition = new Vector2(this.recttransform.anchoredPosition.x, value);
    }
    get => this.recttransform.anchoredPosition.y;
  }

  public void Show(ushort ItemID)
  {
    DataManager instance = DataManager.Instance;
    Equip recordByKey1 = instance.EquipTable.GetRecordByKey(ItemID);
    ComboBox recordByKey2 = instance.ComboBoxTable.GetRecordByKey(recordByKey1.PropertiesInfo[1].Propertieskey);
    for (int index = 0; index < 4; ++index)
    {
      if (recordByKey2.ItemData[index].ItemID == (ushort) 0)
      {
        this.Price[index].gameobject.SetActive(false);
      }
      else
      {
        this.Price[index].gameobject.SetActive(true);
        this.Price[index].SetPrice(recordByKey2.ItemData[index].ItemID, recordByKey2.ItemData[index].ItemCount);
      }
    }
    this.gameobject.SetActive(true);
  }

  public void SetTitle(string title)
  {
    this.Title.text = title;
    ((Graphic) this.Title).SetLayoutDirty();
    this.Title.cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.Title.preferredWidth <= (double) ((Graphic) this.Title).rectTransform.rect.width)
      return;
    this.Title.resizeTextForBestFit = true;
    int fontSize = this.Title.fontSize;
    this.Title.resizeTextMaxSize = fontSize;
    this.Title.resizeTextMinSize = fontSize - 8;
  }

  public void Hide() => this.gameobject.SetActive(false);

  public void TextRefresh()
  {
    ((Behaviour) this.Title).enabled = false;
    ((Behaviour) this.Title).enabled = true;
    for (int index = 0; index < 4; ++index)
      this.Price[index].TextRefresh();
  }

  public void OnClose()
  {
    for (int index = 0; index < 4; ++index)
      this.Price[index].OnClose();
  }

  public struct _UIPrice
  {
    public const float Height = 97f;
    public GameObject gameobject;
    private Transform ItemTrans;
    private UIHIBtn ItemBtn;
    private UIText NumText;
    private CString NumStr;
    private GUIManager GM;

    public _UIPrice(GUIManager GM, Transform transform, Font font)
    {
      this.GM = GM;
      this.gameobject = transform.gameObject;
      this.ItemTrans = transform.GetChild(0);
      this.ItemBtn = this.ItemTrans.GetComponent<UIHIBtn>();
      this.NumText = transform.GetChild(1).GetComponent<UIText>();
      this.NumText.font = font;
      GM.InitianHeroItemImg(this.ItemTrans, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false, bClickSound: false);
      this.NumStr = StringManager.Instance.SpawnString();
    }

    public void SetPrice(ushort ItemID, ushort Num)
    {
      this.GM.ChangeHeroItemImg(this.ItemTrans, eHeroOrItem.Item, ItemID, (byte) 0, (byte) 0);
      this.NumText.text = string.Empty;
      this.NumStr.ClearString();
      this.NumStr.IntToFormat((long) Num);
      if (this.GM.IsArabic)
        this.NumStr.AppendFormat("{0}x");
      else
        this.NumStr.AppendFormat("x{0}");
      this.NumText.text = this.NumStr.ToString();
    }

    public void TextRefresh()
    {
      this.ItemBtn.Refresh_FontTexture();
      ((Behaviour) this.NumText).enabled = false;
      ((Behaviour) this.NumText).enabled = true;
    }

    public void OnClose() => StringManager.Instance.DeSpawnString(this.NumStr);
  }
}
