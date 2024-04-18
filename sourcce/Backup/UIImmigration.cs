// Decompiled with JetBrains decompiler
// Type: UIImmigration
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIImmigration : GUIWindow, IUIButtonClickHandler
{
  private const float ResStep = 64f;
  private const float AlphaSecPerRound = 2f;
  private Door door;
  private Transform Current;
  private UIText ResTitle;
  private UIText ResContent;
  private UIText LongTitle;
  private CString ResTitleStr;
  private CString LongTitleStr;
  private CString NeedItemCountStr;
  private CString ItemCountStr;
  private UIText NeedItemCountText;
  private UIText ItemCountText;
  private Image[] IconX = new Image[2];
  private Image[] IconV = new Image[2];
  private UIText[] MoveFilter = new UIText[2];
  private Image[] AnimIcon = new Image[2];
  private Image[] AnimIcon2 = new Image[2];
  private float WarningIconAlphaSign = 1f;
  private float WarningIconAlpha;
  private Image[] ResIcon = new Image[5];
  private Image ResIconV;
  private UIButton PlayBtn;
  private Image PlayBtnImage;
  private UIText PlayBtnText;
  private UIText[] StaticText = new UIText[5];
  private uint ResMax;
  public static int kingdomID = 0;
  public static int mapPointID = 0;
  private static readonly Color32 ResContentNormal = new Color32(byte.MaxValue, (byte) 247, (byte) 153, byte.MaxValue);
  private static readonly Color32 ResContentRed = new Color32(byte.MaxValue, (byte) 94, (byte) 112, byte.MaxValue);
  private static readonly Vector2 ResContentPos = new Vector2(79f, -210f);
  private static readonly Vector2 ResStart = new Vector2(-223f, 64f);

  public override void OnOpen(int arg1, int arg2)
  {
    this.door = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.Current = this.transform;
    Transform child = this.Current.GetChild(1);
    this.StaticText[0] = child.GetChild(2).GetComponent<UIText>();
    this.StaticText[0].font = ttfFont;
    this.StaticText[0].text = DataManager.Instance.mStringTable.GetStringByID(949U);
    this.StaticText[1] = child.GetChild(19).GetComponent<UIText>();
    this.StaticText[1].font = ttfFont;
    this.StaticText[1].text = DataManager.Instance.mStringTable.GetStringByID(10019U);
    this.StaticText[2] = child.GetChild(16).GetComponent<UIText>();
    this.StaticText[2].font = ttfFont;
    this.StaticText[2].text = DataManager.Instance.mStringTable.GetStringByID(9102U);
    this.ResTitle = child.GetChild(17).GetComponent<UIText>();
    this.ResTitle.font = ttfFont;
    this.ResTitle.text = DataManager.Instance.mStringTable.GetStringByID(10020U);
    this.ResContent = child.GetChild(20).GetComponent<UIText>();
    this.ResContent.font = ttfFont;
    this.ResContent.text = DataManager.Instance.mStringTable.GetStringByID(10021U);
    this.StaticText[3] = child.GetChild(18).GetComponent<UIText>();
    this.StaticText[3].font = ttfFont;
    this.StaticText[3].text = DataManager.Instance.mStringTable.GetStringByID(10023U);
    this.NeedItemCountText = child.GetChild(15).GetChild(0).GetComponent<UIText>();
    this.NeedItemCountText.font = ttfFont;
    ((Graphic) this.NeedItemCountText).rectTransform.sizeDelta = new Vector2(200f, 30f);
    this.ItemCountText = child.GetChild(25).GetComponent<UIText>();
    this.ItemCountText.font = ttfFont;
    this.PlayBtnText = child.GetChild(15).GetChild(1).GetComponent<UIText>();
    this.PlayBtnText.font = ttfFont;
    this.PlayBtnText.text = DataManager.Instance.mStringTable.GetStringByID(949U);
    ((Graphic) this.PlayBtnText).rectTransform.sizeDelta = new Vector2(200f, 30f);
    this.LongTitle = child.GetChild(23).GetComponent<UIText>();
    this.LongTitle.font = ttfFont;
    this.ResIcon[0] = child.GetChild(27).GetComponent<Image>();
    this.ResIcon[0].sprite = this.door.LoadSprite("UI_main_res_food");
    ((MaskableGraphic) this.ResIcon[0]).material = this.door.LoadMaterial();
    this.ResIcon[1] = child.GetChild(28).GetComponent<Image>();
    this.ResIcon[1].sprite = this.door.LoadSprite("UI_main_res_stone");
    ((MaskableGraphic) this.ResIcon[1]).material = this.door.LoadMaterial();
    this.ResIcon[2] = child.GetChild(29).GetComponent<Image>();
    this.ResIcon[2].sprite = this.door.LoadSprite("UI_main_res_wood");
    ((MaskableGraphic) this.ResIcon[2]).material = this.door.LoadMaterial();
    this.ResIcon[3] = child.GetChild(30).GetComponent<Image>();
    this.ResIcon[3].sprite = this.door.LoadSprite("UI_main_res_iron");
    ((MaskableGraphic) this.ResIcon[3]).material = this.door.LoadMaterial();
    this.ResIcon[4] = child.GetChild(31).GetComponent<Image>();
    this.ResIcon[4].sprite = this.door.LoadSprite("UI_main_money_01");
    ((MaskableGraphic) this.ResIcon[4]).material = this.door.LoadMaterial();
    GUIManager.Instance.InitianHeroItemImg(child.GetChild(26), eHeroOrItem.Item, GameConstants.WorldTeleportItemID, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(GameConstants.WorldTeleportItemID);
    this.StaticText[4] = child.GetChild(24).GetComponent<UIText>();
    this.StaticText[4].font = ttfFont;
    if ((int) recordByKey.EquipKey == (int) GameConstants.WorldTeleportItemID)
      this.StaticText[4].text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.EquipName);
    this.MoveFilter[0] = child.GetChild(21).GetComponent<UIText>();
    this.MoveFilter[0].font = ttfFont;
    this.MoveFilter[1] = child.GetChild(22).GetComponent<UIText>();
    this.MoveFilter[1].font = ttfFont;
    this.IconX[0] = child.GetChild(10).GetComponent<Image>();
    this.IconX[1] = child.GetChild(11).GetComponent<Image>();
    this.IconV[0] = child.GetChild(12).GetComponent<Image>();
    this.IconV[1] = child.GetChild(13).GetComponent<Image>();
    ((Component) this.IconX[0]).gameObject.AddComponent<ArabicItemTextureRot>();
    ((Component) this.IconX[1]).gameObject.AddComponent<ArabicItemTextureRot>();
    ((Component) this.IconV[0]).gameObject.AddComponent<ArabicItemTextureRot>();
    ((Component) this.IconV[1]).gameObject.AddComponent<ArabicItemTextureRot>();
    this.AnimIcon[0] = child.GetChild(6).GetComponent<Image>();
    this.AnimIcon[1] = child.GetChild(7).GetComponent<Image>();
    this.AnimIcon2[0] = child.GetChild(8).GetComponent<Image>();
    this.AnimIcon2[1] = child.GetChild(9).GetComponent<Image>();
    ((Component) this.AnimIcon[0]).gameObject.AddComponent<ArabicItemTextureRot>();
    ((Component) this.AnimIcon[1]).gameObject.AddComponent<ArabicItemTextureRot>();
    ((Component) this.AnimIcon2[0]).gameObject.AddComponent<ArabicItemTextureRot>();
    ((Component) this.AnimIcon2[1]).gameObject.AddComponent<ArabicItemTextureRot>();
    this.ResIconV = child.GetChild(32).GetComponent<Image>();
    ((Component) this.ResIconV).gameObject.AddComponent<ArabicItemTextureRot>();
    UIButton component1 = child.GetChild(33).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 2;
    this.PlayBtn = child.GetChild(15).GetComponent<UIButton>();
    this.PlayBtn.m_Handler = (IUIButtonClickHandler) this;
    this.PlayBtn.m_BtnID1 = 1;
    this.PlayBtnImage = child.GetChild(15).GetComponent<Image>();
    UIButton component2 = this.Current.GetChild(0).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 2;
    this.ResTitleStr = StringManager.Instance.SpawnString();
    this.LongTitleStr = StringManager.Instance.SpawnString(200);
    this.NeedItemCountStr = StringManager.Instance.SpawnString();
    this.ItemCountStr = StringManager.Instance.SpawnString();
    this.ReCheckData();
  }

  public override void OnClose()
  {
    if (this.ResTitleStr != null)
      StringManager.Instance.DeSpawnString(this.ResTitleStr);
    if (this.LongTitleStr != null)
      StringManager.Instance.DeSpawnString(this.LongTitleStr);
    if (this.NeedItemCountStr != null)
      StringManager.Instance.DeSpawnString(this.NeedItemCountStr);
    if (this.ItemCountStr == null)
      return;
    StringManager.Instance.DeSpawnString(this.ItemCountStr);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh_TroopHome:
      case NetworkNews.Refresh_BuffList:
        this.ReCheckData();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void ReCheckData()
  {
    bool bEnable = true;
    if (DataManager.Instance.WorldTeleportRank > 0)
    {
      this.LongTitleStr.ClearString();
      this.LongTitleStr.IntToFormat((long) DataManager.Instance.WorldTeleportRank);
      this.LongTitleStr.IntToFormat((long) DataManager.Instance.WorldTeleportItemCount);
      this.LongTitleStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(950U));
      ((Behaviour) this.LongTitle).enabled = true;
      this.LongTitle.text = this.LongTitleStr.ToString();
      this.LongTitle.SetAllDirty();
      this.LongTitle.cachedTextGenerator.Invalidate();
    }
    else
      ((Behaviour) this.LongTitle).enabled = false;
    this.PlayBtn.m_BtnID2 = 0;
    if (!this.CheckResource())
      this.PlayBtn.m_BtnID2 |= 1;
    if (!this.CheckMarchAndBuff())
      bEnable = false;
    int curItemQuantity = (int) DataManager.Instance.GetCurItemQuantity(GameConstants.WorldTeleportItemID, (byte) 0);
    if (curItemQuantity < (int) DataManager.Instance.WorldTeleportItemCount)
      bEnable = false;
    this.ItemCountStr.ClearString();
    this.ItemCountStr.Append(DataManager.Instance.mStringTable.GetStringByID(281U));
    this.ItemCountStr.IntToFormat((long) curItemQuantity, bNumber: true);
    this.ItemCountStr.AppendFormat("{0}");
    this.ItemCountText.text = this.ItemCountStr.ToString();
    this.ItemCountText.SetAllDirty();
    this.ItemCountText.cachedTextGenerator.Invalidate();
    this.SetPlayButtonEnable(bEnable, curItemQuantity);
  }

  private void SetPlayButtonEnable(bool bEnable, int itemCt)
  {
    if (itemCt < (int) DataManager.Instance.WorldTeleportItemCount)
    {
      this.PlayBtn.m_BtnID2 |= 2;
      ((Graphic) this.NeedItemCountText).color = new Color(0.898f, 0.0f, 0.31f);
    }
    else
      ((Graphic) this.NeedItemCountText).color = !bEnable ? Color.gray : Color.white;
    this.NeedItemCountStr.ClearString();
    this.NeedItemCountStr.Append(DataManager.Instance.mStringTable.GetStringByID(951U));
    this.NeedItemCountStr.Append(DataManager.Instance.WorldTeleportItemCount.ToString());
    this.NeedItemCountText.text = this.NeedItemCountStr.ToString();
    this.NeedItemCountText.SetAllDirty();
    this.NeedItemCountText.cachedTextGenerator.Invalidate();
    if (bEnable)
    {
      this.PlayBtn.m_BtnID3 = 1;
      ((Graphic) this.PlayBtnImage).color = Color.white;
      ((Graphic) this.PlayBtnText).color = Color.white;
    }
    else
    {
      this.PlayBtn.m_BtnID3 = 0;
      ((Graphic) this.PlayBtnImage).color = Color.gray;
      ((Graphic) this.PlayBtnText).color = Color.gray;
    }
  }

  private bool CheckResource()
  {
    bool flag = false;
    DataManager instance = DataManager.Instance;
    uint effectBaseVal = instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PROTCTION);
    uint x = GameConstants.appCeil((float) GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort) 9, GUIManager.Instance.BuildingData.GetBuildData((ushort) 9, (ushort) 0).Level).Value1 * ((float) (10000U + effectBaseVal) / 10000f));
    this.ResMax = x;
    for (int index = 0; index < 5; ++index)
      ((Behaviour) this.ResIcon[index]).enabled = false;
    int num = 0;
    for (int index = 0; index < instance.Resource.Length && index < 5; ++index)
    {
      if (instance.Resource[index].Stock > x)
      {
        ((Behaviour) this.ResIcon[index]).enabled = true;
        ((Graphic) this.ResIcon[index]).rectTransform.anchoredPosition = UIImmigration.ResStart + new Vector2(64f * (float) num, 0.0f);
        ++num;
      }
    }
    if (num == 0)
    {
      ((Graphic) this.ResContent).color = (Color) UIImmigration.ResContentNormal;
      this.ResContent.text = DataManager.Instance.mStringTable.GetStringByID(10022U);
      ((Graphic) this.ResContent).rectTransform.anchoredPosition = UIImmigration.ResContentPos;
      ((Behaviour) this.AnimIcon2[0]).enabled = false;
      ((Behaviour) this.AnimIcon2[1]).enabled = false;
      ((Behaviour) this.ResIconV).enabled = true;
      flag = true;
    }
    else
    {
      ((Graphic) this.ResContent).color = (Color) UIImmigration.ResContentRed;
      this.ResContent.text = DataManager.Instance.mStringTable.GetStringByID(10021U);
      ((Graphic) this.ResContent).rectTransform.anchoredPosition = UIImmigration.ResContentPos + new Vector2((float) (64 * num), 0.0f);
      ((Behaviour) this.AnimIcon2[0]).enabled = true;
      ((Behaviour) this.AnimIcon2[1]).enabled = true;
      ((Behaviour) this.ResIconV).enabled = false;
    }
    this.ResTitleStr.ClearString();
    this.ResTitleStr.uLongToFormat((ulong) x, bNumber: true);
    this.ResTitleStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10020U));
    this.ResTitle.text = this.ResTitleStr.ToString();
    this.ResTitle.SetAllDirty();
    this.ResTitle.cachedTextGenerator.Invalidate();
    return flag;
  }

  private bool CheckMarchAndBuff()
  {
    DataManager instance = DataManager.Instance;
    bool flag = false;
    for (int index = 0; index < (int) instance.MaxMarchEventNum; ++index)
    {
      if (instance.MarchEventData[index].Type != EMarchEventType.EMET_Standby)
        flag = true;
    }
    bool bHaveWarBuff = instance.bHaveWarBuff;
    if (!flag && !bHaveWarBuff)
    {
      this.MoveFilter[0].text = instance.mStringTable.GetStringByID(10026U);
      ((Behaviour) this.IconX[0]).enabled = false;
      ((Behaviour) this.IconV[0]).enabled = true;
      ((Behaviour) this.MoveFilter[1]).enabled = false;
      ((Behaviour) this.IconX[1]).enabled = false;
      ((Behaviour) this.IconV[1]).enabled = false;
    }
    else
    {
      int index = 0;
      if (flag)
      {
        ((Behaviour) this.MoveFilter[index]).enabled = true;
        this.MoveFilter[index].text = instance.mStringTable.GetStringByID(10024U);
        ((Behaviour) this.IconX[index]).enabled = true;
        ((Behaviour) this.IconV[index]).enabled = false;
        ++index;
      }
      if (bHaveWarBuff)
      {
        ((Behaviour) this.MoveFilter[index]).enabled = true;
        this.MoveFilter[index].text = instance.mStringTable.GetStringByID(10025U);
        ((Behaviour) this.IconX[index]).enabled = true;
        ((Behaviour) this.IconV[index]).enabled = false;
        ++index;
      }
      if (index <= 1)
      {
        ((Behaviour) this.MoveFilter[1]).enabled = false;
        ((Behaviour) this.IconX[1]).enabled = false;
        ((Behaviour) this.IconV[1]).enabled = false;
      }
    }
    return !flag && !bHaveWarBuff;
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      DataManager instance = DataManager.Instance;
      if ((sender.m_BtnID2 & 2) != 0)
        GUIManager.Instance.OpenMessageBox(instance.mStringTable.GetStringByID(3782U), instance.mStringTable.GetStringByID(955U));
      else if (sender.m_BtnID3 == 1)
      {
        if ((sender.m_BtnID2 & 1) != 0)
        {
          CString cstring = StringManager.Instance.StaticString1024();
          cstring.ClearString();
          cstring.uLongToFormat((ulong) this.ResMax);
          cstring.AppendFormat(instance.mStringTable.GetStringByID(959U));
          GUIManager.Instance.OpenOKCancelBox(13, instance.mStringTable.GetStringByID(5893U), cstring.ToString(), UIImmigration.kingdomID, UIImmigration.mapPointID, instance.mStringTable.GetStringByID(3U), instance.mStringTable.GetStringByID(4U));
        }
        else
        {
          CString cstring = StringManager.Instance.StaticString1024();
          cstring.ClearString();
          cstring.Append(instance.mStringTable.GetStringByID(958U));
          GUIManager.Instance.OpenOKCancelBox(13, instance.mStringTable.GetStringByID(5893U), cstring.ToString(), UIImmigration.kingdomID, UIImmigration.mapPointID, instance.mStringTable.GetStringByID(3U), instance.mStringTable.GetStringByID(4U));
        }
      }
      else
        GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(5771U), (ushort) byte.MaxValue);
    }
    else
    {
      if (sender.m_BtnID1 != 2)
        return;
      GUIManager.Instance.CloseMenu(EGUIWindow.UI_Immigration);
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != 0)
      return;
    this.ReCheckData();
  }

  public void Update()
  {
    this.WarningIconAlpha += (float) ((double) this.WarningIconAlphaSign * (double) Time.deltaTime * 2.0);
    if ((double) this.WarningIconAlpha >= 1.0 || (double) this.WarningIconAlpha <= 0.0)
    {
      if ((double) this.WarningIconAlpha >= 1.0)
        this.WarningIconAlpha = 1f;
      else if ((double) this.WarningIconAlpha <= 0.0)
        this.WarningIconAlpha = 0.0f;
      this.WarningIconAlphaSign *= -1f;
    }
    if (((Behaviour) this.AnimIcon[0]).enabled)
      ((Graphic) this.AnimIcon[1]).color = Color.white with
      {
        a = this.WarningIconAlpha
      };
    if (!((Behaviour) this.AnimIcon2[0]).enabled)
      return;
    ((Graphic) this.AnimIcon2[1]).color = Color.white with
    {
      a = this.WarningIconAlpha
    };
  }

  public void Refresh_FontTexture()
  {
    for (int index = 0; index < this.StaticText.Length; ++index)
    {
      if ((Object) this.StaticText[index] != (Object) null && ((Behaviour) this.StaticText[index]).enabled)
      {
        ((Behaviour) this.StaticText[index]).enabled = false;
        ((Behaviour) this.StaticText[index]).enabled = true;
      }
    }
    for (int index = 0; index < this.MoveFilter.Length; ++index)
    {
      if ((Object) this.MoveFilter[index] != (Object) null && ((Behaviour) this.MoveFilter[index]).enabled)
      {
        ((Behaviour) this.MoveFilter[index]).enabled = false;
        ((Behaviour) this.MoveFilter[index]).enabled = true;
      }
    }
    if ((Object) this.NeedItemCountText != (Object) null && ((Behaviour) this.NeedItemCountText).enabled)
    {
      ((Behaviour) this.NeedItemCountText).enabled = false;
      ((Behaviour) this.NeedItemCountText).enabled = true;
    }
    if ((Object) this.ItemCountText != (Object) null && ((Behaviour) this.ItemCountText).enabled)
    {
      ((Behaviour) this.ItemCountText).enabled = false;
      ((Behaviour) this.ItemCountText).enabled = true;
    }
    if ((Object) this.PlayBtnText != (Object) null && ((Behaviour) this.PlayBtnText).enabled)
    {
      ((Behaviour) this.PlayBtnText).enabled = false;
      ((Behaviour) this.PlayBtnText).enabled = true;
    }
    if ((Object) this.ResTitle != (Object) null && ((Behaviour) this.ResTitle).enabled)
    {
      ((Behaviour) this.ResTitle).enabled = false;
      ((Behaviour) this.ResTitle).enabled = true;
    }
    if ((Object) this.ResContent != (Object) null && ((Behaviour) this.ResContent).enabled)
    {
      ((Behaviour) this.ResContent).enabled = false;
      ((Behaviour) this.ResContent).enabled = true;
    }
    if (!((Object) this.LongTitle != (Object) null) || !((Behaviour) this.LongTitle).enabled)
      return;
    ((Behaviour) this.LongTitle).enabled = false;
    ((Behaviour) this.LongTitle).enabled = true;
  }

  private enum EUIImmigrationUnit
  {
    TitleLeft,
    TitleRight,
    Title,
    ArenaBar,
    ResBar,
    MoveBar,
    Warning1,
    Warning1_a,
    Warning2,
    Warning2_a,
    X1,
    X2,
    V1,
    V2,
    Line,
    PlayBtn,
    ArenaTitle,
    ResTitle,
    MoveTitle,
    ArenaContent,
    ResContent,
    MoveContent,
    MoveContent2,
    LongText,
    ItemName,
    ItemCount,
    ItemIcon,
    ResFood,
    ResRock,
    ResWood,
    ResIron,
    ResGold,
    V3,
    Exit,
  }

  private enum EUIImmigrationButtonID
  {
    Play = 1,
    Exit = 2,
  }
}
