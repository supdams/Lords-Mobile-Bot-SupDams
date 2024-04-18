// Decompiled with JetBrains decompiler
// Type: MallManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class MallManager
{
  public const uint IOS_MONTH_ID = 12379;
  public const uint ANDROID_MONTH_ID = 12378;
  public const uint IOS_SMALL_ID = 13097;
  private const uint ANDROID_SMALL_ID = 13093;
  private static MallManager instance;
  private Door m_door;
  public List<MallDataType> MallDataList = new List<MallDataType>();
  private Dictionary<ushort, int> MallMap_SN = new Dictionary<ushort, int>();
  private Dictionary<ushort, int> MallMap_GID = new Dictionary<ushort, int>();
  public MallDataType MainData;
  public bool bNeedUpDateItemPtice;
  public Dictionary<int, MallItemPrice> m_MallItemPrice = new Dictionary<int, MallItemPrice>();
  public uint _SmallID = 13093;
  public MallDataComparer DataComparer = new MallDataComparer();
  private long LastServerTime;
  public bool bAskListData;
  public bool bRcvMainData;
  public bool bCanOpenMain;
  public bool bLoginFinish;
  public bool AutoMall;
  public ushort AutoDetailSN;
  public bool bAutoOpenMain;
  public bool bSendMallInfo;
  public bool bNewbie;
  private AssetBundle Default_AssetBundle;
  private int Default_AssetBundleKey;
  private Sprite[] Default_MainMenuSprite;
  private Material Default_Material;
  private AssetBundle Main_AssetBundle;
  private int Main_AssetBundleKey;
  private Sprite[] Main_Sprite;
  private Material Main_Material;
  public int MallUIIndex = -1;
  public float MallUIPos = -1f;
  public int ForgeIndex = -1;
  public int AskForgeCount;
  public int NeedFindFrogeIndex = -1;
  public bool bFirstArrow = true;
  private ushort SendBuySN;
  public ushort SendCheckCastleID;
  public bool bLockBuyCastleID;
  public ushort SendCheckEmojiID;
  public bool bLockBuyEmojiID;
  public ushort SendCheckRedPocketID;
  public bool bLockBuyRedPocket;
  public uint SendCheckBuySN;
  public bool bLockBuy;
  private int ChangePos = -1;
  private ushort MainPackageSN;
  public long BuyMonthTreasureTime;
  public long LastGetMonthTreasurePrizeTime;
  public uint mMonthTreasureCrystal;
  public ComboBoxTBItemDataType[] mMonthTreasureItem = new ComboBoxTBItemDataType[200];
  public float mMonthTreasure_CDTime;
  public byte mShowSec;
  public bool bLevelUpPack;
  public uint FullGift_NowCrystal;
  public uint FullGift_MaxCrystal;
  public long FullGift_Deadline;
  public bool FullGift_bShowEffect;
  public byte FullGift_TreasureItemCount;
  public ComboBoxTBItemDataType[] FullGift_TreasureItem = new ComboBoxTBItemDataType[200];
  public ushort BackRewardOpenID;
  public ushort BackRewardComboBoxID;
  public byte BackRewardItemDataCount;
  public byte[] BackRewardItemData = new byte[40];
  public bool bFindCulture;
  public CultureInfo culture;
  public CultureInfo NormalCulture1 = CultureInfo.CreateSpecificCulture("en-US");
  public CultureInfo NormalCulture2 = CultureInfo.CreateSpecificCulture("ar-SA");
  public string[][] CurrencyToCulture = new string[79][]
  {
    new string[2]{ "US", "en-US" },
    new string[2]{ "BH", "en-US" },
    new string[2]{ "KH", "en-US" },
    new string[2]{ "KW", "en-US" },
    new string[2]{ "OM", "en-US" },
    new string[2]{ "CN", "zh-CN" },
    new string[2]{ "AT", "fr-FR" },
    new string[2]{ "GR", "fr-FR" },
    new string[2]{ "DE", "fr-FR" },
    new string[2]{ "EE", "fr-FR" },
    new string[2]{ "IE", "fr-FR" },
    new string[2]{ "LV", "fr-FR" },
    new string[2]{ "SK", "fr-FR" },
    new string[2]{ "SI", "fr-FR" },
    new string[2]{ "BE", "fr-FR" },
    new string[2]{ "FR", "fr-FR" },
    new string[2]{ "LU", "fr-FR" },
    new string[2]{ "LT", "fr-FR" },
    new string[2]{ "IT", "fr-FR" },
    new string[2]{ "FI", "fr-FR" },
    new string[2]{ "NL", "fr-FR" },
    new string[2]{ "PT", "fr-FR" },
    new string[2]{ "ES", "fr-FR" },
    new string[2]{ "CY", "fr-FR" },
    new string[2]{ "TW", "zh-TW" },
    new string[2]{ "BR", "pt-BR" },
    new string[2]{ "MX", "es-MX" },
    new string[2]{ "TH", "th-TH" },
    new string[2]{ "RU", "fr-FR" },
    new string[2]{ "JP", "ja-JP" },
    new string[2]{ "KR", "ko-KR" },
    new string[2]{ "ID", "id-ID" },
    new string[2]{ "VN", "vi-VN" },
    new string[2]{ "IN", "gu-IN" },
    new string[2]{ "SG", "zh-SG" },
    new string[2]{ "CA", "en-CA" },
    new string[2]{ "GB", "en-GB" },
    new string[2]{ "AU", "zh-CN" },
    new string[2]{ "MO", "zh-MO" },
    new string[2]{ "PH", "en-PH" },
    new string[2]{ "CO", "es-CO" },
    new string[2]{ "MY", "zh-CN" },
    new string[2]{ "TR", "tr-TR" },
    new string[2]{ "HK", "zh-HK" },
    new string[2]{ "DK", "da-DK" },
    new string[2]{ "IL", "he-IL" },
    new string[2]{ "BG", "bg-BG" },
    new string[2]{ "HR", "hr-HR" },
    new string[2]{ "LI", "de-CH" },
    new string[2]{ "CH", "de-CH" },
    new string[2]{ "HU", "hu-HU" },
    new string[2]{ "ZA", "fr-FR" },
    new string[2]{ "KZ", "fr-FR" },
    new string[2]{ "CR", "es-CR" },
    new string[2]{ "PK", "zh-CN" },
    new string[2]{ "NO", "nn-NO" },
    new string[2]{ "CZ", "cs-CZ" },
    new string[2]{ "CL", "es-CL" },
    new string[2]{ "PL", "pl-PL" },
    new string[2]{ "UA", "uk-UA" },
    new string[2]{ "BO", "es-BO" },
    new string[2]{ "SE", "sv-SE" },
    new string[2]{ "PE", "es-PE" },
    new string[2]{ "NZ", "zh-CN" },
    new string[2]{ "RO", "ro-RO" },
    new string[2]{ "KE", "sw-KE" },
    new string[2]{ "LK", "zh-CN" },
    new string[2]{ "NG", "zh-CN" },
    new string[2]{ "GH", "en-US" },
    new string[2]{ "TZ", "sw-KE" },
    new string[2]{ "BD", "gu-IN" },
    new string[2]{ "BY", "be-BY" },
    new string[2]{ "UA", "ar-SA" },
    new string[2]{ "QA", "ar-QA" },
    new string[2]{ "EG", "ar-EG" },
    new string[2]{ "LB", "ar-SA" },
    new string[2]{ "DZ", "ar-DZ" },
    new string[2]{ "SA", "ar-SA" },
    new string[2]{ "MA", "ar-MA" }
  };

  private MallManager()
  {
    this._SmallID = this.TreasureIDTransToNew(this._SmallID);
    this.LoadShowEffect();
  }

  public static MallManager Instance
  {
    get
    {
      if (MallManager.instance == null)
        MallManager.instance = new MallManager();
      return MallManager.instance;
    }
  }

  public Door door
  {
    get
    {
      if ((UnityEngine.Object) this.m_door == (UnityEngine.Object) null)
        this.m_door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      return this.m_door;
    }
    set => this.m_door = value;
  }

  public uint SmallID
  {
    get
    {
      return MerchantmanManager.Instance.ExtraTreasureID != 0U ? MerchantmanManager.Instance.ExtraTreasureID : this._SmallID;
    }
  }

  ~MallManager()
  {
  }

  public void UnloadAsset()
  {
    for (int index = 0; index < this.MallDataList.Count; ++index)
      this.MallDataList[index].UnloadAB();
    this.MallDataList.Clear();
    this.MainData = (MallDataType) null;
    this.bNeedUpDateItemPtice = false;
    this.m_MallItemPrice.Clear();
    if (this.Default_AssetBundleKey != 0)
    {
      this.Default_Material = (Material) null;
      this.Default_MainMenuSprite = (Sprite[]) null;
      AssetManager.UnloadAssetBundle(this.Default_AssetBundleKey);
      this.Default_AssetBundle = (AssetBundle) null;
      this.Default_AssetBundleKey = 0;
    }
    this.UnLoadMainPackage();
    this.LastServerTime = 0L;
    this.bAskListData = false;
    this.bRcvMainData = false;
    this.bCanOpenMain = false;
    this.bLoginFinish = false;
    this.AutoMall = false;
    this.AutoDetailSN = (ushort) 0;
    this.bAutoOpenMain = false;
    this.bSendMallInfo = false;
    this.bNewbie = false;
    this.MallUIIndex = -1;
    this.MallUIPos = -1f;
    this.ForgeIndex = -1;
    this.bFirstArrow = true;
    this.SendBuySN = (ushort) 0;
    this.SendCheckBuySN = 0U;
    this.bLockBuy = false;
    this.AskForgeCount = 0;
    this.NeedFindFrogeIndex = -1;
    this.ClearFullGift();
  }

  public MallDataType FindDataBySN(ushort SN)
  {
    int index = 0;
    return this.MallMap_SN.TryGetValue(SN, out index) && index < this.MallDataList.Count ? this.MallDataList[index] : (MallDataType) null;
  }

  public int FindIndexBySN(ushort SN)
  {
    int num = -1;
    return this.MallMap_SN.TryGetValue(SN, out num) && num < this.MallDataList.Count ? num : -1;
  }

  public MallDataType FindDataByGID(ushort GroupID)
  {
    int index = 0;
    return this.MallMap_GID.TryGetValue(GroupID, out index) && index < this.MallDataList.Count ? this.MallDataList[index] : (MallDataType) null;
  }

  public int FindIndexByGID(ushort GroupID)
  {
    int num = -1;
    return this.MallMap_GID.TryGetValue(GroupID, out num) && num < this.MallDataList.Count ? num : -1;
  }

  public int RemoveDataByGID(ushort GroupID)
  {
    int index = 0;
    if (!this.MallMap_GID.TryGetValue(GroupID, out index) || index >= this.MallDataList.Count)
      return -1;
    if (this.MainData != null && (UnityEngine.Object) this.door != (UnityEngine.Object) null && (int) this.MallDataList[index].SN == (int) this.MainData.SN)
      this.SetDefaultPackage();
    this.MallDataList[index].UnloadAB(false);
    this.MallDataList.RemoveAt(index);
    return index;
  }

  public void SortMallData()
  {
    this.CheckNewBie();
    this.MallDataList.Sort((IComparer<MallDataType>) this.DataComparer);
    for (int index = 0; index < this.MallDataList.Count; ++index)
    {
      if (this.MallDataList[index].Type == ETreasureType.ETST_Month)
      {
        if (index != 1 && (index + 1 >= this.MallDataList.Count || this.MallDataList[index + 1].Type != ETreasureType.ETST_Crystal))
        {
          MallDataType mallData = this.MallDataList[index];
          this.MallDataList.RemoveAt(index);
          this.MallDataList.Insert(1, mallData);
          break;
        }
        break;
      }
    }
    this.MallMap_SN.Clear();
    this.MallMap_GID.Clear();
    for (ushort index = 0; (int) index < this.MallDataList.Count; ++index)
    {
      if (!this.MallMap_SN.ContainsKey(this.MallDataList[(int) index].SN))
        this.MallMap_SN.Add(this.MallDataList[(int) index].SN, (int) index);
      if (!this.MallMap_GID.ContainsKey(this.MallDataList[(int) index].GroupID))
        this.MallMap_GID.Add(this.MallDataList[(int) index].GroupID, (int) index);
    }
  }

  private void CheckNewBie()
  {
    this.bNewbie = DataManager.Instance.ServerTime - DataManager.Instance.RoleAttr.FirstTimer <= 432000L;
  }

  public void ChaekMainPackage()
  {
    int index = 0;
    this.SetDefaultPackage();
    if (this.MallDataList.Count > 0)
    {
      this.MainData = this.MallDataList[index];
      if (this.MainData.Type == ETreasureType.ETST_Crystal)
      {
        this.bCanOpenMain = true;
      }
      else
      {
        this.MainData.SendAskDownLoad();
        this.bRcvMainData = false;
      }
    }
    else
      this.MainData = (MallDataType) null;
    this.CheckHaveLevelUpPack();
    this.SetMainTime(true);
  }

  public void CalculateTime(int Index)
  {
    if (Index < 0 || Index >= this.MallDataList.Count)
      return;
    if (this.MallDataList[Index].EndTime == 0L)
    {
      this.MallDataList[Index].uTime = 0U;
    }
    else
    {
      uint num;
      if (this.MallDataList[Index].EndTime <= DataManager.Instance.ServerTime)
      {
        num = 0U;
      }
      else
      {
        num = (uint) (this.MallDataList[Index].EndTime - DataManager.Instance.ServerTime);
        if (this.MallDataList[Index].Type != ETreasureType.ETST_SHLevelUp && num > 3300U)
          num = (num + 300U) % 3600U;
      }
      this.MallDataList[Index].uTime = num;
      if (this.MallDataList[Index].Type != ETreasureType.ETST_SHLevelUp)
        return;
      this.SetMainTime();
    }
  }

  public void Update()
  {
    if (DataManager.Instance.ServerTime != this.LastServerTime)
    {
      this.LastServerTime = DataManager.Instance.ServerTime;
      this.UpdateMall();
    }
    if ((double) this.mMonthTreasure_CDTime > 0.0)
    {
      this.mMonthTreasure_CDTime -= Time.unscaledDeltaTime;
      if (this.mShowSec == (byte) 1 && (double) this.mMonthTreasure_CDTime <= 1.5)
      {
        this.mShowSec = (byte) 2;
        GUIManager instance = GUIManager.Instance;
        Array.Clear((Array) instance.SE_Kind, 0, instance.SE_Kind.Length);
        Array.Clear((Array) instance.m_SpeciallyEffect.mResValue, 0, instance.m_SpeciallyEffect.mResValue.Length);
        Array.Clear((Array) instance.SE_ItemID, 0, instance.SE_ItemID.Length);
        for (int index = 0; index < 3; ++index)
          instance.SE_ItemID[index] = this.mMonthTreasureItem[3 + index].ItemID;
        instance.mStartV2 = new Vector2(instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
        instance.m_SpeciallyEffect.AddIconShow(instance.mStartV2, instance.SE_Kind, instance.SE_ItemID);
      }
      else if (this.mShowSec == (byte) 2 && (double) this.mMonthTreasure_CDTime <= 0.0 && this.mMonthTreasureItem[6].ItemID != (ushort) 0)
      {
        this.mShowSec = (byte) 0;
        GUIManager instance = GUIManager.Instance;
        Array.Clear((Array) instance.SE_Kind, 0, instance.SE_Kind.Length);
        Array.Clear((Array) instance.m_SpeciallyEffect.mResValue, 0, instance.m_SpeciallyEffect.mResValue.Length);
        Array.Clear((Array) instance.SE_ItemID, 0, instance.SE_ItemID.Length);
        instance.SE_ItemID[0] = this.mMonthTreasureItem[6].ItemID;
        instance.mStartV2 = new Vector2(instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
        instance.m_SpeciallyEffect.AddIconShow(instance.mStartV2, instance.SE_Kind, instance.SE_ItemID);
      }
    }
    if (this.bLoginFinish)
    {
      if (this.bSendMallInfo)
      {
        this.bSendMallInfo = false;
        this.Send_Mall_Info();
      }
      if (this.AutoMall)
      {
        this.AutoMall = false;
        this.Send_Mall_Info();
      }
    }
    if (!this.bLoginFinish || !(bool) (UnityEngine.Object) this.door)
      return;
    this.CheckOpenPUSHBACK_PRIZE();
    if (this.bCanOpenMain)
      return;
    bool flag1 = true;
    if (IGGGameSDK.Instance.IGGIdIsReady)
      flag1 = IGGGameSDK.Instance.bPaymentReady;
    bool flag2 = this.MainData != null && this.MainData.bDownLoadPic && this.MainData.bDownLoadStr;
    if (!flag1 || !this.bRcvMainData || !flag2)
      return;
    this.bCanOpenMain = true;
    if (NewbieManager.IsWorking())
      return;
    GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_Mall, 1, bCameraMode: true, openMode: (byte) 2);
  }

  public void UpdateMall()
  {
    if (this.MallDataList.Count > 0)
    {
      for (int Index = 0; Index < this.MallDataList.Count; ++Index)
        this.CalculateTime(Index);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 0);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_Detail, 0);
    }
    if (this.FullGift_Deadline <= 0L)
      return;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_FG, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_FG_Detail, 0);
  }

  public void UpDateDownLoad(byte[] meg)
  {
    if (meg[1] != (byte) 2)
      return;
    byte num1 = meg[2];
    ushort num2 = GameConstants.ConvertBytesToUShort(meg, 3);
    if (meg[5] == (byte) 1)
    {
      if (num1 == (byte) 0)
        AssetManager.RequestMallBundle(num2, true);
      else
        AssetManager.RequestMallPackage(num2, true);
    }
    else
    {
      if (meg[5] == (byte) 2)
        return;
      if (num1 == (byte) 0)
      {
        if (num2 >= (ushort) 1 && num2 <= (ushort) 1000)
        {
          for (int index = 0; index < this.MallDataList.Count; ++index)
          {
            if ((int) this.MallDataList[index].PicPackageID1 == (int) num2)
            {
              if (this.MallDataList[index].bDownLoadPic)
                this.MallDataList[index].bUpDatePic = true;
              else
                this.MallDataList[index].bDownLoadPic = true;
            }
          }
        }
        else if (num2 >= (ushort) 1001 && num2 <= (ushort) 2000 && this.MainData != null && (int) this.MainData.PicPackageID2 + 1000 == (int) num2)
        {
          this.LoadMainPackege(num2);
          this.SetMainPackage();
        }
      }
      else
      {
        for (int index = 0; index < this.MallDataList.Count; ++index)
        {
          if ((int) this.MallDataList[index].StrPackageID == (int) num2)
          {
            if (this.MallDataList[index].bDownLoadStr)
              this.MallDataList[index].bUpDateStr = true;
            else
              this.MallDataList[index].bDownLoadStr = true;
          }
        }
      }
      this.CheckOpenMain();
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 5);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_Detail, 5);
    }
  }

  public void CheckOpenMain()
  {
    if (this.MainData == null || this.bRcvMainData || !this.MainData.bDownLoadPic || !this.MainData.bDownLoadStr)
      return;
    this.bRcvMainData = true;
  }

  public string GetItemRankName(byte ItemRank)
  {
    switch (ItemRank)
    {
      case 1:
        return DataManager.Instance.mStringTable.GetStringByID(7733U);
      case 2:
        return DataManager.Instance.mStringTable.GetStringByID(7734U);
      case 3:
        return DataManager.Instance.mStringTable.GetStringByID(7735U);
      case 4:
        return DataManager.Instance.mStringTable.GetStringByID(7736U);
      case 5:
        return DataManager.Instance.mStringTable.GetStringByID(7737U);
      default:
        return DataManager.Instance.mStringTable.GetStringByID(7733U);
    }
  }

  public Color GetItemRankColor(byte ItemRank)
  {
    switch (ItemRank)
    {
      case 1:
        return Color.white;
      case 2:
        return new Color(0.2078f, 0.9686f, 0.4235f);
      case 3:
        return new Color(0.0f, 1f, 1f);
      case 4:
        return new Color(0.7098f, 0.5569f, 1f);
      case 5:
        return new Color(1f, 0.9686f, 0.4235f);
      default:
        return Color.white;
    }
  }

  public bool CheckCanOpenDetail(ushort HIID)
  {
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(HIID);
    return recordByKey.EquipKind == (byte) 18 && recordByKey.PropertiesInfo[2].Propertieskey == (ushort) 3 && recordByKey.PropertiesInfo[2].PropertiesValue == (ushort) 1 || recordByKey.EquipKind == (byte) 18 && recordByKey.PropertiesInfo[2].Propertieskey == (ushort) 0 || recordByKey.EquipKind == (byte) 18 && recordByKey.PropertiesInfo[2].Propertieskey == (ushort) 1 && recordByKey.PropertiesInfo[4].PropertiesValue == (ushort) 1 || recordByKey.EquipKind == (byte) 18 && recordByKey.PropertiesInfo[2].Propertieskey == (ushort) 2 && recordByKey.PropertiesInfo[4].PropertiesValue == (ushort) 1 || recordByKey.EquipKind == (byte) 19;
  }

  public bool OpenDetail(ushort HIID)
  {
    if ((UnityEngine.Object) this.door == (UnityEngine.Object) null || !this.CheckCanOpenDetail(HIID))
      return false;
    this.door.OpenMenu(EGUIWindow.UI_OpenBox, 1, (int) HIID);
    return true;
  }

  public void LoadDefaultMainPackage()
  {
    CString Name = StringManager.Instance.StaticString1024();
    Name.Append("UI/Mall_0");
    this.Default_AssetBundle = AssetManager.GetAssetBundle(Name, out this.Default_AssetBundleKey);
    if (!((UnityEngine.Object) this.Default_AssetBundle != (UnityEngine.Object) null))
      return;
    this.Default_Material = this.Default_AssetBundle.Load("Mall_m", typeof (Material)) as Material;
    UnityEngine.Object[] objectArray = this.Default_AssetBundle.LoadAll(typeof (Sprite));
    this.Default_MainMenuSprite = new Sprite[objectArray.Length];
    for (int index = 0; index < objectArray.Length; ++index)
    {
      ushort num = ushort.Parse(objectArray[index].name);
      if (num >= (ushort) 1 && (int) num <= this.Default_MainMenuSprite.Length)
        this.Default_MainMenuSprite[(int) num - 1] = (Sprite) objectArray[index];
    }
  }

  public void SetDefaultPackage()
  {
    if ((UnityEngine.Object) this.door == (UnityEngine.Object) null)
      return;
    if (this.Default_AssetBundleKey == 0)
      this.LoadDefaultMainPackage();
    this.door.SpriteA.m_Sprites = this.Default_MainMenuSprite;
    this.door.SpriteA.m_Pivot = (Vector2[]) null;
    this.door.SpriteA.m_Image.sprite = this.Default_MainMenuSprite[0];
    ((MaskableGraphic) this.door.SpriteA.m_Image).material = this.Default_Material;
    ((MaskableGraphic) this.door.SpriteA.m_Image).material.renderQueue = 3000;
    ((Behaviour) this.door.SpriteA.m_Image).enabled = true;
    this.UnLoadMainPackage();
  }

  public void LoadMainPackege(ushort PackageID)
  {
    CString Name = StringManager.Instance.StaticString1024();
    Name.IntToFormat((long) PackageID);
    Name.AppendFormat("Store/Mallback_{0}");
    if (this.Main_AssetBundleKey != 0)
      this.UnLoadMainPackage();
    this.Main_AssetBundle = AssetManager.GetAssetBundle(Name, out this.Main_AssetBundleKey);
    if (!((UnityEngine.Object) this.Main_AssetBundle != (UnityEngine.Object) null))
      return;
    this.Main_Material = this.Main_AssetBundle.Load("Mall_m", typeof (Material)) as Material;
    UnityEngine.Object[] objectArray = this.Main_AssetBundle.LoadAll(typeof (Sprite));
    this.Main_Sprite = new Sprite[objectArray.Length];
    for (int index = 0; index < objectArray.Length; ++index)
    {
      ushort num = ushort.Parse(objectArray[index].name);
      if (num >= (ushort) 1 && (int) num <= this.Main_Sprite.Length)
        this.Main_Sprite[(int) num - 1] = (Sprite) objectArray[index];
    }
  }

  public void SetMainPackage()
  {
    if ((UnityEngine.Object) this.door == (UnityEngine.Object) null)
      return;
    if (this.Main_Sprite == null || (UnityEngine.Object) this.Main_Material == (UnityEngine.Object) null)
    {
      this.SetDefaultPackage();
    }
    else
    {
      this.door.SpriteA.m_Sprites = this.Main_Sprite;
      this.door.SpriteA.m_Pivot = (Vector2[]) null;
      this.door.SpriteA.m_Image.sprite = this.Main_Sprite[0];
      ((MaskableGraphic) this.door.SpriteA.m_Image).material = this.Main_Material;
      ((MaskableGraphic) this.door.SpriteA.m_Image).material.renderQueue = 3000;
      ((Behaviour) this.door.SpriteA.m_Image).enabled = true;
    }
  }

  public void CheckHaveLevelUpPack()
  {
    if (this.MainData != null && this.MainData.Type == ETreasureType.ETST_SHLevelUp)
      this.bLevelUpPack = true;
    else
      this.bLevelUpPack = false;
  }

  public void SetMainTime(bool bCheckTime = false)
  {
    if ((UnityEngine.Object) this.door == (UnityEngine.Object) null)
      return;
    if (this.MainData != null && this.MainData.Type == ETreasureType.ETST_SHLevelUp)
    {
      this.door.m_MallStr.Length = 0;
      if (bCheckTime && this.MainData.uTime == 0U && this.MainData.EndTime > DataManager.Instance.ServerTime)
        this.MainData.uTime = (uint) (this.MainData.EndTime - DataManager.Instance.ServerTime);
      GameConstants.GetTimeString(this.door.m_MallStr, this.MainData.uTime, bShowDay: false);
      this.door.m_MallText.text = this.door.m_MallStr.ToString();
      this.door.m_MallText.SetAllDirty();
      this.door.m_MallText.cachedTextGenerator.Invalidate();
      if (this.door.m_MallImageGO.activeInHierarchy)
        return;
      this.door.m_MallImageGO.SetActive(true);
    }
    else
      this.door.m_MallImageGO.SetActive(false);
  }

  public void UnLoadMainPackage()
  {
    if (this.Main_AssetBundleKey == 0)
      return;
    this.Main_Material = (Material) null;
    this.Main_Sprite = (Sprite[]) null;
    AssetManager.UnloadAssetBundle(this.Main_AssetBundleKey);
    this.Main_AssetBundle = (AssetBundle) null;
    this.Main_AssetBundleKey = 0;
  }

  public double Getprice(uint PackageID)
  {
    uint num = PackageID;
    switch (num)
    {
      case 11570:
        return 65.0;
      case 11571:
      case 11596:
      case 11600:
      case 11601:
      case 11610:
      case 11611:
      case 11612:
      case 11613:
      case 11614:
      case 11615:
      case 11616:
      case 11617:
      case 11618:
      case 11619:
      case 11660:
label_6:
        return 165.0;
      case 11572:
label_7:
        return 330.0;
      case 11573:
      case 11597:
      case 11604:
      case 11605:
      case 11630:
      case 11631:
      case 11632:
      case 11633:
      case 11634:
      case 11635:
      case 11636:
      case 11637:
      case 11638:
      case 11639:
      case 11661:
label_8:
        return 660.0;
      case 11574:
      case 11598:
      case 11606:
      case 11607:
      case 11640:
      case 11641:
      case 11642:
      case 11643:
      case 11644:
      case 11645:
      case 11646:
      case 11647:
      case 11648:
      case 11649:
      case 11662:
label_10:
        return 1650.0;
      case 11575:
      case 11595:
      case 11599:
      case 11608:
      case 11609:
      case 11650:
      case 11651:
      case 11652:
      case 11653:
      case 11654:
      case 11655:
      case 11656:
      case 11657:
      case 11658:
      case 11659:
      case 11663:
label_11:
        return 3300.0;
      case 11589:
label_4:
        return 33.0;
      default:
        switch (num)
        {
          case 14238:
          case 14239:
          case 14240:
          case 14263:
          case 14264:
            goto label_6;
          case 14241:
          case 14242:
          case 14243:
            goto label_8;
          case 14244:
          case 14245:
          case 14246:
            goto label_10;
          case 14247:
          case 14248:
          case 14249:
            goto label_11;
          default:
            switch (num)
            {
              case 12378:
                goto label_7;
              case 13090:
              case 13091:
              case 13092:
              case 13093:
                goto label_4;
              case 13881:
              case 13882:
              case 14140:
              case 14141:
              case 14142:
              case 14388:
                goto label_6;
              case 13883:
              case 13884:
              case 14037:
              case 14038:
              case 14039:
              case 14040:
              case 14041:
              case 14042:
              case 14043:
              case 14044:
              case 14045:
              case 14046:
              case 14143:
              case 14144:
              case 14145:
              case 14389:
                goto label_8;
              case 13885:
              case 13886:
              case 14146:
              case 14147:
              case 14148:
              case 14391:
                goto label_10;
              case 14047:
              case 14048:
              case 14049:
              case 14050:
              case 14051:
              case 14052:
              case 14053:
              case 14054:
              case 14055:
              case 14056:
              case 14390:
                return 990.0;
              case 14057:
              case 14058:
              case 14059:
              case 14060:
              case 14061:
              case 14149:
              case 14150:
              case 14151:
              case 14392:
                goto label_11;
              default:
                if (num != 14216U && num != 14269U)
                  return 0.0;
                goto label_6;
            }
        }
    }
  }

  public int GetPoint(uint PackageID)
  {
    uint num = PackageID;
    switch (num)
    {
      case 11570:
        return 280;
      case 11571:
      case 11596:
      case 11600:
      case 11601:
      case 11610:
      case 11611:
      case 11612:
      case 11613:
      case 11614:
      case 11615:
      case 11616:
      case 11617:
      case 11618:
      case 11619:
      case 11660:
label_6:
        return 800;
      case 11572:
        return 1700;
      case 11573:
      case 11597:
      case 11604:
      case 11605:
      case 11630:
      case 11631:
      case 11632:
      case 11633:
      case 11634:
      case 11635:
      case 11636:
      case 11637:
      case 11638:
      case 11639:
      case 11661:
label_8:
        return 3600;
      case 11574:
      case 11598:
      case 11606:
      case 11607:
      case 11640:
      case 11641:
      case 11642:
      case 11643:
      case 11644:
      case 11645:
      case 11646:
      case 11647:
      case 11648:
      case 11649:
      case 11662:
label_9:
        return 9500;
      case 11575:
      case 11595:
      case 11599:
      case 11608:
      case 11609:
      case 11650:
      case 11651:
      case 11652:
      case 11653:
      case 11654:
      case 11655:
      case 11656:
      case 11657:
      case 11658:
      case 11659:
      case 11663:
label_10:
        return 22000;
      case 11589:
label_4:
        return 140;
      default:
        switch (num)
        {
          case 14238:
          case 14239:
          case 14240:
            goto label_6;
          case 14241:
          case 14242:
          case 14243:
            goto label_8;
          case 14244:
          case 14245:
          case 14246:
            goto label_9;
          case 14247:
          case 14248:
          case 14249:
            goto label_10;
          case 14263:
          case 14264:
label_11:
            return 0;
          default:
            switch (num)
            {
              case 13090:
              case 13091:
              case 13092:
                goto label_4;
              case 13093:
              case 13881:
              case 13882:
              case 13883:
              case 13884:
              case 13885:
              case 13886:
              case 14037:
              case 14038:
              case 14039:
              case 14040:
              case 14041:
              case 14042:
              case 14043:
              case 14044:
              case 14045:
              case 14046:
              case 14047:
              case 14048:
              case 14049:
              case 14050:
              case 14051:
              case 14052:
              case 14053:
              case 14054:
              case 14055:
              case 14056:
              case 14057:
              case 14058:
              case 14059:
              case 14060:
              case 14061:
              case 14388:
              case 14389:
              case 14390:
              case 14391:
              case 14392:
                goto label_11;
              case 14140:
              case 14141:
              case 14142:
                goto label_6;
              case 14143:
              case 14144:
              case 14145:
                goto label_8;
              case 14146:
              case 14147:
              case 14148:
                goto label_9;
              case 14149:
              case 14150:
              case 14151:
                goto label_10;
              default:
                if (num != 12378U && num != 14216U && num != 14269U)
                  return 0;
                goto label_11;
            }
        }
    }
  }

  public string GetProductPriceByID(int id)
  {
    return this.m_MallItemPrice.ContainsKey(id) ? this.m_MallItemPrice[id].Price : (string) null;
  }

  public string GetProductPaltformPriceByID(int id)
  {
    return this.m_MallItemPrice.ContainsKey(id) ? this.m_MallItemPrice[id].PaltformPrice : (string) null;
  }

  public bool GetProductPointByID(int id, out int point)
  {
    bool productPointById = false;
    point = 0;
    if (this.m_MallItemPrice.ContainsKey(id))
    {
      point = this.m_MallItemPrice[id].Point;
      productPointById = true;
    }
    return productPointById;
  }

  public string GetCurrency(int id)
  {
    return this.m_MallItemPrice.ContainsKey(id) ? this.m_MallItemPrice[id].Currency : (string) null;
  }

  public void SetCulture()
  {
    string countryCode = IGGSDKPlugin.GetCountryCode();
    for (int index = 0; index < this.CurrencyToCulture.Length; ++index)
    {
      if (this.CurrencyToCulture[index][0] == countryCode)
      {
        this.culture = CultureInfo.CreateSpecificCulture(this.CurrencyToCulture[index][1]);
        this.bFindCulture = true;
        return;
      }
    }
    this.culture = CultureInfo.CreateSpecificCulture("en-US");
  }

  public bool IsArabicNum(char tmp)
  {
    return tmp == '٠' || tmp == '١' || tmp == '٢' || tmp == '٣' || tmp == '٤' || tmp == '٥' || tmp == '٦' || tmp == '٧' || tmp == '٨' || tmp == '٩' || tmp == '۰' || tmp == '۱' || tmp == '۲' || tmp == '۳' || tmp == '۴' || tmp == '۵' || tmp == '۶' || tmp == '۷' || tmp == '۸' || tmp == '۹';
  }

  public string RePlaceArbForPrice(string Price)
  {
    if (Price == null)
      return (string) null;
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < Price.Length; ++index)
    {
      if (Price[index] == '٠')
        stringBuilder.Append('0');
      else if (Price[index] == '١')
        stringBuilder.Append('1');
      else if (Price[index] == '٢')
        stringBuilder.Append('2');
      else if (Price[index] == '٣')
        stringBuilder.Append('3');
      else if (Price[index] == '٤')
        stringBuilder.Append('4');
      else if (Price[index] == '٥')
        stringBuilder.Append('5');
      else if (Price[index] == '٦')
        stringBuilder.Append('6');
      else if (Price[index] == '٧')
        stringBuilder.Append('7');
      else if (Price[index] == '٨')
        stringBuilder.Append('8');
      else if (Price[index] == '٩')
        stringBuilder.Append('9');
      else if (Price[index] == '٬')
        stringBuilder.Append(',');
      else if (Price[index] == ',')
        stringBuilder.Append('.');
      else if (Price[index] == '۰')
        stringBuilder.Append('0');
      else if (Price[index] == '۱')
        stringBuilder.Append('1');
      else if (Price[index] == '۲')
        stringBuilder.Append('2');
      else if (Price[index] == '۳')
        stringBuilder.Append('3');
      else if (Price[index] == '۴')
        stringBuilder.Append('4');
      else if (Price[index] == '۵')
        stringBuilder.Append('5');
      else if (Price[index] == '۶')
        stringBuilder.Append('6');
      else if (Price[index] == '۷')
        stringBuilder.Append('7');
      else if (Price[index] == '۸')
        stringBuilder.Append('8');
      else if (Price[index] == '۹')
        stringBuilder.Append('9');
      else
        stringBuilder.Append(Price[index]);
    }
    return stringBuilder.ToString();
  }

  public string RevArbForPrice(string Price)
  {
    if (Price == null)
      return (string) null;
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < Price.Length; ++index)
    {
      if (Price[index] == '0')
        stringBuilder.Append('٠');
      else if (Price[index] == '1')
        stringBuilder.Append('١');
      else if (Price[index] == '2')
        stringBuilder.Append('٢');
      else if (Price[index] == '3')
        stringBuilder.Append('٣');
      else if (Price[index] == '4')
        stringBuilder.Append('٤');
      else if (Price[index] == '5')
        stringBuilder.Append('٥');
      else if (Price[index] == '6')
        stringBuilder.Append('٦');
      else if (Price[index] == '7')
        stringBuilder.Append('٧');
      else if (Price[index] == '8')
        stringBuilder.Append('٨');
      else if (Price[index] == '9')
        stringBuilder.Append('٩');
      else if (Price[index] == ',')
        stringBuilder.Append('٬');
      else if (Price[index] == '.')
        stringBuilder.Append(',');
      else if (Price[index] == '0')
        stringBuilder.Append('۰');
      else if (Price[index] == '1')
        stringBuilder.Append('۱');
      else if (Price[index] == '2')
        stringBuilder.Append('۲');
      else if (Price[index] == '3')
        stringBuilder.Append('۳');
      else if (Price[index] == '4')
        stringBuilder.Append('۴');
      else if (Price[index] == '5')
        stringBuilder.Append('۵');
      else if (Price[index] == '6')
        stringBuilder.Append('۶');
      else if (Price[index] == '7')
        stringBuilder.Append('۷');
      else if (Price[index] == '8')
        stringBuilder.Append('۸');
      else if (Price[index] == '9')
        stringBuilder.Append('۹');
      else
        stringBuilder.Append(Price[index]);
    }
    return stringBuilder.ToString();
  }

  public double GetOriginalPrice(double Price, byte Discount)
  {
    return Discount >= (byte) 100 ? 0.0 : Price * 100.0 / (double) (100 - (int) Discount);
  }

  public bool SetPriceStr(CString tmpPriceStr, int TreasureID, bool bDisCount = false, byte Discount = 0)
  {
    if (tmpPriceStr == null)
      return false;
    bool flag1 = false;
    tmpPriceStr.Length = 0;
    string paltformPriceById = this.GetProductPaltformPriceByID(TreasureID);
    string productPriceById = this.GetProductPriceByID(TreasureID);
    if (paltformPriceById != null && paltformPriceById != string.Empty)
    {
      if (bDisCount)
      {
        bool flag2 = false;
        bool flag3 = true;
        bool flag4 = false;
        double result = 0.0;
        string str1 = (string) null;
        string tmpS = (string) null;
        CString str2 = StringManager.Instance.SpawnString();
        bool flag5 = this.IsArabicNum(paltformPriceById[0]);
        if (paltformPriceById[0] >= '0' && paltformPriceById[0] <= '9' || flag5)
        {
          flag4 = true;
          int length = -1;
          for (int index = paltformPriceById.Length - 1; index >= 0; --index)
          {
            if (paltformPriceById[index] >= '0' && paltformPriceById[index] <= '9' || this.IsArabicNum(paltformPriceById[index]))
            {
              length = index + 1;
              break;
            }
          }
          if (length == -1)
          {
            flag3 = false;
          }
          else
          {
            str1 = paltformPriceById.Substring(0, length);
            for (int index = length; index < paltformPriceById.Length; ++index)
              str2.Append(paltformPriceById[index]);
          }
        }
        else
        {
          for (int index = 0; index < paltformPriceById.Length; ++index)
          {
            flag5 = this.IsArabicNum(paltformPriceById[index]);
            if (paltformPriceById[index] >= '0' && paltformPriceById[index] <= '9' || flag5)
            {
              str1 = paltformPriceById.Substring(index, paltformPriceById.Length - index);
              if (flag5)
              {
                str1 = this.RePlaceArbForPrice(str1);
                break;
              }
              break;
            }
            tmpPriceStr.Append(paltformPriceById[index]);
          }
        }
        if (flag3)
        {
          NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
          if (flag5)
          {
            if (str1 != null && double.TryParse(str1, style, (IFormatProvider) this.NormalCulture1, out result))
            {
              flag2 = true;
              result = this.GetOriginalPrice(result, Discount);
              tmpS = this.RevArbForPrice(result.ToString("N2", (IFormatProvider) this.NormalCulture1));
            }
            if (str1 != null && !flag2 && double.TryParse(str1, style, (IFormatProvider) this.NormalCulture2, out result))
            {
              flag2 = true;
              result = this.GetOriginalPrice(result, Discount);
              tmpS = this.RevArbForPrice(result.ToString("N2", (IFormatProvider) this.NormalCulture2));
            }
          }
          else
          {
            if (this.culture == null)
              this.SetCulture();
            if (this.bFindCulture && str1 != null && double.TryParse(str1, style, (IFormatProvider) this.culture, out result))
            {
              flag2 = true;
              tmpS = this.GetOriginalPrice(result, Discount).ToString("N2", (IFormatProvider) this.culture);
            }
          }
        }
        if (flag2)
        {
          tmpPriceStr.StringToFormat(tmpS);
          tmpPriceStr.AppendFormat("{0}");
          if (flag4)
            tmpPriceStr.Append(str2);
        }
        else
        {
          tmpPriceStr.Length = 0;
          tmpPriceStr.Append(paltformPriceById);
        }
        StringManager.Instance.DeSpawnString(str2);
      }
      else
        tmpPriceStr.Append(paltformPriceById);
    }
    else
    {
      if (productPriceById == null)
      {
        double f = 0.0;
        flag1 = true;
        if (bDisCount)
          tmpPriceStr.DoubleToFormat(Discount < (byte) 100 ? f * 100.0 / (double) (100 - (int) Discount) : 0.0, 2);
        else
          tmpPriceStr.DoubleToFormat(f, 2);
      }
      else if (bDisCount)
      {
        bool flag6 = false;
        NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
        if (this.IsArabicNum(productPriceById[0]))
        {
          double result = 0.0;
          string s = this.RePlaceArbForPrice(productPriceById);
          if (double.TryParse(s, style, (IFormatProvider) this.NormalCulture1, out result))
          {
            flag6 = true;
            result = this.GetOriginalPrice(result, Discount);
            string tmpS = this.RevArbForPrice(result.ToString("N2", (IFormatProvider) this.NormalCulture1));
            tmpPriceStr.StringToFormat(tmpS);
          }
          if (!flag6 && double.TryParse(s, style, (IFormatProvider) this.NormalCulture2, out result))
          {
            flag6 = true;
            result = this.GetOriginalPrice(result, Discount);
            string tmpS = this.RevArbForPrice(result.ToString("N2", (IFormatProvider) this.NormalCulture2));
            tmpPriceStr.StringToFormat(tmpS);
          }
        }
        else
        {
          if (this.culture == null)
            this.SetCulture();
          double result = 0.0;
          if (this.bFindCulture && double.TryParse(productPriceById, style, (IFormatProvider) this.culture, out result))
          {
            flag6 = true;
            string tmpS = this.GetOriginalPrice(result, Discount).ToString("N2", (IFormatProvider) this.culture);
            tmpPriceStr.StringToFormat(tmpS);
          }
        }
        if (!flag6)
          tmpPriceStr.StringToFormat(productPriceById);
      }
      else
        tmpPriceStr.StringToFormat(productPriceById);
      string currency = this.GetCurrency(TreasureID);
      if (currency != null)
      {
        tmpPriceStr.StringToFormat(currency);
        if (this.bChangePosCurrency(currency))
          tmpPriceStr.AppendFormat("{0} {1}");
        else
          tmpPriceStr.AppendFormat("{1} {0}");
      }
      else
        tmpPriceStr.AppendFormat("${0}");
    }
    return flag1;
  }

  public uint TreasureIDTransToNew(uint TreasureID) => TreasureID;

  public bool bChangePosCurrency(string Currency)
  {
    if (this.ChangePos == -1)
      this.ChangePos = string.Compare("EUR", Currency) == 0 || string.Compare("RUB", Currency) == 0 || string.Compare("р.", Currency) == 0 ? 1 : 0;
    return this.ChangePos == 1;
  }

  public bool FindAndOpenMall(int tmpForgeIndex)
  {
    for (int index = 0; index < this.MallDataList.Count; ++index)
    {
      if (this.MallDataList[index].Type != ETreasureType.ETST_Crystal && (int) this.MallDataList[index].SetNo == tmpForgeIndex)
      {
        this.ForgeIndex = index;
        this.Send_Mall_Info();
        return true;
      }
    }
    bool flag = false;
    List<ushort> ushortList = new List<ushort>();
    for (int index = 0; index < this.MallDataList.Count; ++index)
    {
      if (this.MallDataList[index].Type != ETreasureType.ETST_Crystal && this.MallDataList[index].SetNo == ushort.MaxValue)
      {
        flag = true;
        if (!this.MallDataList[index].bAskDetailData)
          ushortList.Add(this.MallDataList[index].SN);
      }
    }
    if (!flag)
      return false;
    if (ushortList.Count > 0)
    {
      GUIManager.Instance.ShowUILock(EUILock.Mall);
      this.AskForgeCount = ushortList.Count;
      this.NeedFindFrogeIndex = tmpForgeIndex;
      for (int index = 0; index < ushortList.Count; ++index)
        this.Send_Mall_Combobox(ushortList[index]);
    }
    else
      this.FindDetailAndOpenMall(tmpForgeIndex);
    return true;
  }

  public void FindDetailAndOpenMall(int tmpForgeIndex)
  {
    for (int index1 = 0; index1 < this.MallDataList.Count; ++index1)
    {
      if (this.MallDataList[index1].Type != ETreasureType.ETST_Crystal && this.MallDataList[index1].SetNo == ushort.MaxValue)
      {
        for (int index2 = 0; index2 < 200; ++index2)
        {
          if ((int) DataManager.Instance.EquipTable.GetRecordByKey(this.MallDataList[index1].Item[index2].ItemID).ActivitySuitIndex == tmpForgeIndex)
          {
            this.ForgeIndex = index1;
            this.Send_Mall_Info();
            return;
          }
        }
      }
    }
    GUIManager.Instance.OpenItemKindFilterUI((ushort) 18, (byte) 1, (byte) tmpForgeIndex);
  }

  public void ClearSendCheckBuySN()
  {
    this.SendCheckBuySN = 0U;
    this.SendCheckEmojiID = (ushort) 0;
    this.SendCheckCastleID = (ushort) 0;
    this.SendCheckRedPocketID = (ushort) 0;
    this.bLockBuy = false;
    this.bLockBuyEmojiID = false;
    this.bLockBuyCastleID = false;
    this.bLockBuyRedPocket = false;
    MerchantmanManager.Instance.ClearSendCheckBuy();
  }

  public bool CheckbWaitBuy(bool bShowMessage = false)
  {
    if (!this.bLockBuy)
      return false;
    if (bShowMessage)
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(656U), (ushort) byte.MaxValue);
    return true;
  }

  public bool CheckbWaitBuy_Emoji(bool bShowMessage = false)
  {
    if (!this.bLockBuyEmojiID)
      return false;
    if (bShowMessage)
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(656U), (ushort) byte.MaxValue);
    return true;
  }

  public bool CheckbWaitBuy_Castle(bool bShowMessage = false)
  {
    if (!this.bLockBuyCastleID)
      return false;
    if (bShowMessage)
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(656U), (ushort) byte.MaxValue);
    return true;
  }

  public bool CheckbWaitBuy_RedPocket(bool bShowMessage = false)
  {
    if (!this.bLockBuyRedPocket)
      return false;
    if (bShowMessage)
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(656U), (ushort) byte.MaxValue);
    return true;
  }

  public void ClearFullGift()
  {
    this.FullGift_NowCrystal = 0U;
    this.FullGift_MaxCrystal = 0U;
    this.FullGift_Deadline = 0L;
    this.FullGift_TreasureItemCount = (byte) 0;
  }

  public void LoadShowEffect()
  {
    bool.TryParse(PlayerPrefs.GetString("FullGift_bShowEffect"), out this.FullGift_bShowEffect);
  }

  public void SetShowEffect(bool Set)
  {
    this.FullGift_bShowEffect = Set;
    PlayerPrefs.SetString("FullGift_bShowEffect", this.FullGift_bShowEffect.ToString());
  }

  public void CheckShowEffect()
  {
    if (!this.FullGift_bShowEffect || this.FullGift_Deadline != 0L)
      return;
    this.SetShowEffect(false);
  }

  public void Send_Mall_Info()
  {
    if (this.bAskListData)
    {
      List<ushort> ushortList = new List<ushort>();
      for (int index = 0; index < this.MallDataList.Count; ++index)
      {
        if (!this.MallDataList[index].bAskListData)
          ushortList.Add(this.MallDataList[index].SN);
      }
      if (ushortList.Count > 0)
      {
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_TREASURE_INFO;
        messagePacket.AddSeqId();
        messagePacket.Add((byte) ushortList.Count);
        for (int index = 0; index < ushortList.Count; ++index)
          messagePacket.Add(ushortList[index]);
        messagePacket.Send();
        GUIManager.Instance.ShowUILock(EUILock.Mall);
      }
      else
      {
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 1);
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          return;
        this.door.OpenMenu(EGUIWindow.UI_Mall, bCameraMode: true);
      }
    }
    else
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_TREASURE_INFO;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) 0);
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.Mall);
      AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.ENTER_MALL);
    }
  }

  public void Send_Mall_Combobox(ushort SN)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_TREASURE_COMBOBOX;
    messagePacket.AddSeqId();
    messagePacket.Add(SN);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Mall);
  }

  public void Send_Mall_Check(ushort SN, bool checkPay = true)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_TREASURE_PREBUY_CHECK;
    messagePacket.AddSeqId();
    messagePacket.Add(SN);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Mall);
  }

  public void Send_Mall_TestBuy(uint TreasureID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_TREASURE_DEBUGBUY;
    messagePacket.AddSeqId();
    messagePacket.Add(TreasureID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Mall);
  }

  public void RecvMall_List(MessagePacket MP)
  {
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 4);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_Detail, 4);
    this.SetDefaultPackage();
    for (int index = 0; index < this.MallDataList.Count; ++index)
      this.MallDataList[index].UnloadAB(false);
    this.MallDataList.Clear();
    ushort num1 = MP.ReadUShort();
    MallDataType mallDataType1 = new MallDataType();
    mallDataType1.SN = num1;
    mallDataType1.bAskListData = true;
    mallDataType1.TreasureID = this.TreasureIDTransToNew(MP.ReadUInt());
    mallDataType1.PosType = MP.ReadByte();
    mallDataType1.BonusRate = MP.ReadByte();
    mallDataType1.BonusCrystal = MP.ReadUInt();
    mallDataType1.EndTime = MP.ReadLong();
    mallDataType1.FrameColor.r = (float) MP.ReadByte() / (float) byte.MaxValue;
    mallDataType1.FrameColor.g = (float) MP.ReadByte() / (float) byte.MaxValue;
    mallDataType1.FrameColor.b = (float) MP.ReadByte() / (float) byte.MaxValue;
    mallDataType1.LineColor.r = (float) MP.ReadByte() / (float) byte.MaxValue;
    mallDataType1.LineColor.g = (float) MP.ReadByte() / (float) byte.MaxValue;
    mallDataType1.LineColor.b = (float) MP.ReadByte() / (float) byte.MaxValue;
    mallDataType1.ComboBoxID = MP.ReadUShort();
    for (int index = 0; index < 3; ++index)
    {
      mallDataType1.BriefItem[index].ItemID = MP.ReadUShort();
      mallDataType1.BriefItem[index].Num = MP.ReadUShort();
      mallDataType1.BriefItem[index].ItemRank = MP.ReadByte();
    }
    mallDataType1.bBuyOnce = MP.ReadByte();
    if (DataManager.Instance.ServerVersionMajor != (byte) 0)
    {
      mallDataType1.StampPic = MP.ReadUShort();
      mallDataType1.StampHint = MP.ReadUShort();
      mallDataType1.Discount = MP.ReadByte();
      mallDataType1.ExtraByte = MP.ReadByte();
      for (int index = 0; index < 3; ++index)
        mallDataType1.ExtraData[index] = MP.ReadUShort();
    }
    if (num1 != (ushort) 0)
    {
      this.MallDataList.Add(mallDataType1);
      this.MainData = mallDataType1;
    }
    byte num2 = MP.ReadByte();
    for (int index = 0; index < (int) num2; ++index)
    {
      ushort num3 = MP.ReadUShort();
      if (this.MainData != null && (int) this.MainData.SN == (int) num3)
      {
        this.MainData.GroupID = MP.ReadUShort();
        this.MainData.TreasureID = this.TreasureIDTransToNew(MP.ReadUInt());
        this.MainData.PicPackageID1 = MP.ReadUShort();
        this.MainData.SetBuyOnce();
        this.MainData.PicPackageID2 = MP.ReadUShort();
        this.MainData.StrPackageID = MP.ReadUShort();
        this.MainData.Type = (ETreasureType) MP.ReadByte();
        this.MainData.RenderWeight = MP.ReadUShort();
        this.MainData.SetNo = MP.ReadUShort();
        if (this.MainData.Type == ETreasureType.ETST_Crystal)
          this.bCanOpenMain = true;
        else
          this.MainData.SendAskDownLoad();
      }
      else
      {
        MallDataType mallDataType2 = new MallDataType();
        this.MallDataList.Add(mallDataType2);
        mallDataType2.SN = num3;
        mallDataType2.GroupID = MP.ReadUShort();
        mallDataType2.TreasureID = this.TreasureIDTransToNew(MP.ReadUInt());
        mallDataType2.PicPackageID1 = MP.ReadUShort();
        mallDataType2.SetBuyOnce();
        mallDataType2.PicPackageID2 = MP.ReadUShort();
        mallDataType2.StrPackageID = MP.ReadUShort();
        mallDataType2.Type = (ETreasureType) MP.ReadByte();
        mallDataType2.RenderWeight = MP.ReadUShort();
        mallDataType2.SetNo = MP.ReadUShort();
      }
    }
    this.bAskListData = false;
    this.SortMallData();
    for (int index = 0; index < this.MallDataList.Count; ++index)
    {
      if ((int) this.MallDataList[index].SN != (int) num1 && this.MallDataList[index].Type != ETreasureType.ETST_Crystal)
        this.MallDataList[index].SendAskDownLoad();
    }
    if (this.AutoDetailSN != (ushort) 0)
    {
      if (this.FindIndexBySN(this.AutoDetailSN) != -1)
      {
        this.bSendMallInfo = true;
      }
      else
      {
        this.AutoDetailSN = (ushort) 0;
        if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
          this.door.CloseMenu();
      }
    }
    if (this.bLockBuy && this.FindIndexBySN((ushort) this.SendCheckBuySN) == -1)
      this.ClearSendCheckBuySN();
    if (this.AutoDetailSN != (ushort) 0 || this.AutoMall)
      GUIManager.Instance.ShowUILock(EUILock.Mall);
    if (this.MainPackageSN != (ushort) 0 && this.MainData != null && (int) this.MainPackageSN != (int) this.MainData.SN && this.MainData.Type != ETreasureType.ETST_Crystal && !(bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Mall) && !(bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Mall_Detail) && !GUIManager.Instance.CheckInQueue(EGUIWindow.UI_Mall))
      this.bCanOpenMain = false;
    if (this.MainData != null)
      this.MainPackageSN = this.MainData.SN;
    this.CheckHaveLevelUpPack();
    this.SetMainTime(true);
  }

  public void RecvMall_Info(MessagePacket MP)
  {
    byte num1 = MP.ReadByte();
    byte num2 = MP.ReadByte();
    for (int index1 = 0; index1 < (int) num2; ++index1)
    {
      ushort SN = MP.ReadUShort();
      MallDataType mallDataType = this.FindDataBySN(SN);
      if (mallDataType == null)
      {
        mallDataType = new MallDataType();
        mallDataType.SN = SN;
        this.MallDataList.Add(mallDataType);
      }
      mallDataType.bAskListData = true;
      mallDataType.TreasureID = this.TreasureIDTransToNew(MP.ReadUInt());
      mallDataType.PosType = MP.ReadByte();
      mallDataType.BonusRate = MP.ReadByte();
      mallDataType.BonusCrystal = MP.ReadUInt();
      mallDataType.EndTime = MP.ReadLong();
      mallDataType.FrameColor.r = (float) MP.ReadByte() / (float) byte.MaxValue;
      mallDataType.FrameColor.g = (float) MP.ReadByte() / (float) byte.MaxValue;
      mallDataType.FrameColor.b = (float) MP.ReadByte() / (float) byte.MaxValue;
      mallDataType.LineColor.r = (float) MP.ReadByte() / (float) byte.MaxValue;
      mallDataType.LineColor.g = (float) MP.ReadByte() / (float) byte.MaxValue;
      mallDataType.LineColor.b = (float) MP.ReadByte() / (float) byte.MaxValue;
      mallDataType.ComboBoxID = MP.ReadUShort();
      for (int index2 = 0; index2 < 3; ++index2)
      {
        mallDataType.BriefItem[index2].ItemID = MP.ReadUShort();
        mallDataType.BriefItem[index2].Num = MP.ReadUShort();
        mallDataType.BriefItem[index2].ItemRank = MP.ReadByte();
      }
      mallDataType.bBuyOnce = MP.ReadByte();
      if (DataManager.Instance.ServerVersionMajor != (byte) 0)
      {
        mallDataType.StampPic = MP.ReadUShort();
        mallDataType.StampHint = MP.ReadUShort();
        mallDataType.Discount = MP.ReadByte();
        mallDataType.ExtraByte = MP.ReadByte();
        for (int index3 = 0; index3 < 3; ++index3)
          mallDataType.ExtraData[index3] = MP.ReadUShort();
      }
    }
    if (num1 != (byte) 1)
      return;
    this.SortMallData();
    if (this.AutoDetailSN != (ushort) 0)
    {
      this.Send_Mall_Combobox(this.AutoDetailSN);
      this.AutoDetailSN = (ushort) 0;
    }
    else if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Mall))
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 1);
    else if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
      this.door.OpenMenu(EGUIWindow.UI_Mall, bCameraMode: true);
    GUIManager.Instance.HideUILock(EUILock.Mall);
    this.bAskListData = true;
  }

  public void RecvMall_Combobox(MessagePacket MP)
  {
    int indexBySn = this.FindIndexBySN(MP.ReadUShort());
    if (indexBySn == -1)
      return;
    MallDataType mallData = this.MallDataList[indexBySn];
    for (int index = 0; index < 5; ++index)
    {
      mallData.AllianceGift[index].ItemID = MP.ReadUShort();
      mallData.AllianceGift[index].Num = MP.ReadUShort();
    }
    mallData.DataLen = MP.ReadByte();
    for (int index = 0; index < (int) mallData.DataLen; ++index)
    {
      mallData.Item[index].ItemID = MP.ReadUShort();
      mallData.Item[index].Num = MP.ReadUShort();
      mallData.Item[index].ItemRank = MP.ReadByte();
    }
    mallData.AllianceGiftShowTop = MP.ReadByte();
    mallData.bAskDetailData = true;
    if (this.AskForgeCount > 0)
    {
      --this.AskForgeCount;
      if (this.AskForgeCount != 0)
        return;
      GUIManager.Instance.HideUILock(EUILock.Mall);
      this.FindDetailAndOpenMall(this.NeedFindFrogeIndex);
      this.NeedFindFrogeIndex = -1;
    }
    else
    {
      GUIManager.Instance.HideUILock(EUILock.Mall);
      if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Mall_Detail))
      {
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_Detail, 6);
      }
      else
      {
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          return;
        this.door.OpenMenu(EGUIWindow.UI_Mall_Detail, indexBySn);
      }
    }
  }

  public void RecvMall_UpdateList(MessagePacket MP)
  {
    switch (MP.ReadByte())
    {
      case 0:
        ushort SN = MP.ReadUShort();
        MallDataType mallDataType = this.FindDataBySN(SN);
        if (mallDataType == null)
        {
          mallDataType = new MallDataType();
          mallDataType.SN = SN;
          this.MallDataList.Add(mallDataType);
        }
        mallDataType.SN = SN;
        mallDataType.GroupID = MP.ReadUShort();
        mallDataType.TreasureID = this.TreasureIDTransToNew(MP.ReadUInt());
        mallDataType.PicPackageID1 = MP.ReadUShort();
        mallDataType.SetBuyOnce();
        mallDataType.PicPackageID2 = MP.ReadUShort();
        mallDataType.StrPackageID = MP.ReadUShort();
        mallDataType.Type = (ETreasureType) MP.ReadByte();
        mallDataType.RenderWeight = MP.ReadUShort();
        mallDataType.SetNo = MP.ReadUShort();
        mallDataType.SendAskDownLoad();
        if (mallDataType.Type == ETreasureType.ETST_SHLevelUp)
          mallDataType.EndTime = MP.ReadLong();
        this.SortMallData();
        if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Mall))
        {
          this.Send_Mall_Info();
        }
        else
        {
          this.MallUIIndex = 0;
          this.MallUIPos = 0.0f;
        }
        this.ChaekMainPackage();
        break;
      case 1:
        int num = this.RemoveDataByGID(MP.ReadUShort());
        this.SortMallData();
        this.ChaekMainPackage();
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_Detail, 1, num);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 1);
        break;
      case 2:
        int indexByGid = this.FindIndexByGID(MP.ReadUShort());
        if (indexByGid == -1)
          break;
        this.MallDataList[indexByGid].EndTime = MP.ReadLong();
        this.CalculateTime(indexByGid);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 0);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_Detail, 0);
        break;
    }
  }

  public void RecvMall_Check(MessagePacket MP)
  {
    if (MP.ReadByte() == (byte) 0)
    {
      ushort SN = MP.ReadUShort();
      this.SendBuySN = SN;
      MallDataType dataBySn = this.FindDataBySN(SN);
      if (dataBySn == null)
        return;
      if (dataBySn.bBuyOnce == (byte) 1)
        this.SendCheckBuySN = (uint) SN;
      IGGSDKPlugin.BuyProduct(dataBySn.TreasureID.ToString(), (int) DataManager.MapDataController.kingdomData.kingdomID);
    }
    else
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(868U), (ushort) byte.MaxValue);
    GUIManager.Instance.HideUILock(EUILock.Mall);
  }

  public void RecvMall_GetItem(MessagePacket MP)
  {
    string Price = (string) null;
    string str1 = string.Empty;
    string empty = string.Empty;
    string str2 = string.Empty;
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    ushort GroupID = MP.ReadUShort();
    ushort num1 = MP.ReadUShort();
    if (GroupID != (ushort) 0)
    {
      int indexByGid = this.FindIndexByGID(GroupID);
      if (num1 != (ushort) 0)
      {
        MallDataType mallDataType = new MallDataType();
        mallDataType.SN = num1;
        this.MallDataList.Add(mallDataType);
        mallDataType.GroupID = MP.ReadUShort();
        mallDataType.TreasureID = this.TreasureIDTransToNew(MP.ReadUInt());
        mallDataType.PicPackageID1 = MP.ReadUShort();
        mallDataType.SetBuyOnce();
        mallDataType.PicPackageID2 = MP.ReadUShort();
        mallDataType.StrPackageID = MP.ReadUShort();
        mallDataType.Type = (ETreasureType) MP.ReadByte();
        mallDataType.RenderWeight = MP.ReadUShort();
        mallDataType.SetNo = MP.ReadUShort();
        mallDataType.SendAskDownLoad();
      }
      MallDataType dataByGid = this.FindDataByGID(GroupID);
      if (dataByGid != null)
      {
        Price = IGGGameSDK.Instance.GetProductPriceByID((int) dataByGid.TreasureID);
        empty = dataByGid.TreasureID.ToString();
        if (dataByGid.Type == ETreasureType.ETST_Crystal)
        {
          str1 = instance1.mStringTable.GetStringByID((uint) dataByGid.StrPackageID);
        }
        else
        {
          byte index = (byte) (instance1.UserLanguage - (byte) 1);
          if ((UnityEngine.Object) dataByGid.DownLoadStr != (UnityEngine.Object) null)
          {
            if ((int) index >= dataByGid.DownLoadStr.Header.Length || dataByGid.DownLoadStr.Header[(int) index] == string.Empty)
              index = (byte) 0;
            str1 = dataByGid.DownLoadStr.Header[(int) index];
          }
        }
        str2 = IGGGameSDK.Instance.GetCurrency((int) dataByGid.TreasureID);
      }
      this.RemoveDataByGID(GroupID);
      this.SortMallData();
      this.ChaekMainPackage();
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_Detail, 1, indexByGid);
    }
    if (num1 == (ushort) 0)
    {
      int num2 = (int) MP.ReadUShort();
      int num3 = (int) MP.ReadUInt();
      int num4 = (int) MP.ReadUShort();
      int num5 = (int) MP.ReadUShort();
      int num6 = (int) MP.ReadUShort();
      int num7 = (int) MP.ReadByte();
      int num8 = (int) MP.ReadUShort();
      int num9 = (int) MP.ReadUShort();
    }
    uint id = this.TreasureIDTransToNew(MP.ReadUInt());
    if (GroupID == (ushort) 0 && id != 0U)
    {
      MallDataType dataBySn = this.FindDataBySN(this.SendBuySN);
      if (dataBySn != null && (int) dataBySn.TreasureID == (int) id)
      {
        Price = IGGGameSDK.Instance.GetProductPriceByID((int) dataBySn.TreasureID);
        empty = dataBySn.TreasureID.ToString();
        if (dataBySn.Type == ETreasureType.ETST_Crystal)
        {
          str1 = instance1.mStringTable.GetStringByID((uint) dataBySn.StrPackageID);
        }
        else
        {
          byte index = (byte) (instance1.UserLanguage - (byte) 1);
          if ((UnityEngine.Object) dataBySn.DownLoadStr != (UnityEngine.Object) null)
          {
            if ((int) index >= dataBySn.DownLoadStr.Header.Length || dataBySn.DownLoadStr.Header[(int) index] == string.Empty)
              index = (byte) 0;
            str1 = dataBySn.DownLoadStr.Header[(int) index];
          }
        }
        str2 = IGGGameSDK.Instance.GetCurrency((int) dataBySn.TreasureID);
      }
    }
    bool flag = false;
    if (id == 13093U || (int) id == (int) MerchantmanManager.Instance.ExtraTreasureID)
      flag = true;
    if (flag)
    {
      Price = IGGGameSDK.Instance.GetProductPriceByID((int) id);
      empty = id.ToString();
      str1 = instance1.mStringTable.GetStringByID(8874U);
      str2 = IGGGameSDK.Instance.GetCurrency((int) id);
    }
    this.SendBuySN = (ushort) 0;
    if (GroupID != (ushort) 0)
      this.ClearSendCheckBuySN();
    int num10 = (int) MP.ReadUShort();
    instance2.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0);
    byte num11 = MP.ReadByte();
    for (int index = 0; index < (int) num11; ++index)
    {
      ushort ItemID = MP.ReadUShort();
      ushort Quantity = MP.ReadUShort();
      byte Rare = MP.ReadByte();
      instance1.SetCurItemQuantity(ItemID, Quantity, Rare, 0L);
    }
    GameManager.OnRefresh();
    GameManager.OnRefresh(NetworkNews.Refresh_Attr);
    GameManager.OnRefresh(NetworkNews.Refresh_Item);
    instance2.UpdateUI(EGUIWindow.UI_Mall_Detail, 2);
    instance2.UpdateUI(EGUIWindow.UI_Mall, 2);
    instance2.AddHUDMessage(instance1.mStringTable.GetStringByID(867U), (ushort) 254);
    LordEquipData.Instance().Scan_MaterialOrEquipIncreace();
    instance2.HideUILock(EUILock.Mall);
    string s = this.RePlaceArb(Price);
    IGGSDKPlugin.SetFacebookEventPurchases(s != null ? double.Parse(s) : 0.0, "1", str1, empty, str2);
  }

  private unsafe string RePlaceArb(string Price)
  {
    if (Price == null)
      return Price;
    string str = Price;
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    for (int index = 0; index < Price.Length; ++index)
    {
      if (chPtr[index] == '٠')
        chPtr[index] = '0';
      else if (chPtr[index] == '١')
        chPtr[index] = '1';
      else if (chPtr[index] == '٢')
        chPtr[index] = '2';
      else if (chPtr[index] == '٣')
        chPtr[index] = '3';
      else if (chPtr[index] == '٤')
        chPtr[index] = '4';
      else if (chPtr[index] == '٥')
        chPtr[index] = '5';
      else if (chPtr[index] == '٦')
        chPtr[index] = '6';
      else if (chPtr[index] == '٧')
        chPtr[index] = '7';
      else if (chPtr[index] == '٨')
        chPtr[index] = '8';
      else if (chPtr[index] == '٩')
        chPtr[index] = '9';
      else if (chPtr[index] == '٬')
        chPtr[index] = ',';
    }
    str = (string) null;
    return Price;
  }

  public void RecvTreasure_Monthprize_Info(MessagePacket MP)
  {
    this.mMonthTreasureCrystal = MP.ReadUInt();
    byte num = MP.ReadByte();
    for (int index = 0; index < (int) num && index < 200; ++index)
    {
      this.mMonthTreasureItem[index].ItemID = MP.ReadUShort();
      this.mMonthTreasureItem[index].Num = MP.ReadUShort();
      this.mMonthTreasureItem[index].ItemRank = MP.ReadByte();
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_TreasureBox, 7);
  }

  public void RecvTreasure_Get_Monthprize(MessagePacket MP)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    if (MP.ReadByte() == (byte) 0)
    {
      this.BuyMonthTreasureTime = MP.ReadLong();
      this.LastGetMonthTreasurePrizeTime = MP.ReadLong();
      uint diamond = MP.ReadUInt();
      instance2.SetRoleAttrDiamond(diamond, (ushort) 0);
      byte num = MP.ReadByte();
      for (int index = 0; index < (int) num && index < 200; ++index)
      {
        this.mMonthTreasureItem[index].ItemID = MP.ReadUShort();
        this.mMonthTreasureItem[index].Num = MP.ReadUShort();
        this.mMonthTreasureItem[index].ItemRank = MP.ReadByte();
        instance1.SetCurItemQuantity(this.mMonthTreasureItem[index].ItemID, this.mMonthTreasureItem[index].Num, this.mMonthTreasureItem[index].ItemRank, 0L);
      }
      GameManager.OnRefresh();
      Array.Clear((Array) instance2.SE_Kind, 0, instance2.SE_Kind.Length);
      Array.Clear((Array) instance2.m_SpeciallyEffect.mResValue, 0, instance2.m_SpeciallyEffect.mResValue.Length);
      Array.Clear((Array) instance2.SE_ItemID, 0, instance2.SE_ItemID.Length);
      instance2.SE_Kind[0] = SpeciallyEffect_Kind.Diamond;
      for (int index = 0; index < 3; ++index)
        instance2.SE_ItemID[index] = this.mMonthTreasureItem[index].ItemID;
      instance2.mStartV2 = new Vector2(instance2.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, instance2.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
      instance2.m_SpeciallyEffect.AddIconShow(instance2.mStartV2, instance2.SE_Kind, instance2.SE_ItemID);
      AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
      this.mMonthTreasure_CDTime = 3.2f;
      this.mShowSec = (byte) 1;
      instance2.UpdateUI(EGUIWindow.UI_TreasureBox, 6);
      instance2.UpdateUI(EGUIWindow.Door, 23);
    }
    instance2.HideUILock(EUILock.Mall);
  }

  public void Send_Treasure_Get_Monthprize()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_TREASURE_GET_MONTHPRIZE;
    messagePacket.AddSeqId();
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Mall);
  }

  public bool CheckBtnShow()
  {
    bool flag = false;
    if (this.BuyMonthTreasureTime != 0L && this.LastGetMonthTreasurePrizeTime == 0L)
      flag = true;
    else if (this.LastGetMonthTreasurePrizeTime != 0L && DataManager.Instance.ServerTime - MallManager.Instance.LastGetMonthTreasurePrizeTime >= 86400L)
      flag = true;
    return flag;
  }

  public void Send_SPTREASURE_PREBUY_CHECK(
    ESpcialTreasureType SpTreasureType,
    uint TreasureID,
    bool checkPay = true)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_SPTREASURE_PREBUY_CHECK;
    messagePacket.AddSeqId();
    messagePacket.Add((byte) SpTreasureType);
    messagePacket.Add(TreasureID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Mall);
  }

  public void Recv_SPTREASURE_PREBUY_CHECK(MessagePacket MP)
  {
    byte num = MP.ReadByte();
    ESpcialTreasureType espcialTreasureType = (ESpcialTreasureType) MP.ReadByte();
    uint TreasureID = MP.ReadUInt();
    if (num == (byte) 0)
    {
      IGGSDKPlugin.BuyProduct(this.TreasureIDTransToNew(TreasureID).ToString(), (int) DataManager.MapDataController.kingdomData.kingdomID);
    }
    else
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(868U), (ushort) byte.MaxValue);
      switch (espcialTreasureType)
      {
        case ESpcialTreasureType.ESTST_Emote:
          this.SendCheckEmojiID = (ushort) 0;
          break;
        case ESpcialTreasureType.ESTST_CastleSkin:
          this.SendCheckCastleID = (ushort) 0;
          break;
        case ESpcialTreasureType.ESTST_RedPocket:
          this.SendCheckRedPocketID = (ushort) 0;
          break;
      }
    }
    GUIManager.Instance.HideUILock(EUILock.Mall);
  }

  public void Send_TREASUREBACK_PRIZEINFO()
  {
    if (this.FullGift_TreasureItemCount != (byte) 0)
    {
      if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Mall_FG_Detail))
      {
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_FG_Detail, 3);
      }
      else
      {
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          return;
        this.door.OpenMenu(EGUIWindow.UI_Mall_FG_Detail);
      }
    }
    else
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_TREASUREBACK_PRIZEINFO;
      messagePacket.AddSeqId();
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.Mall);
    }
  }

  public void Recv_TREASUREBACK_PRIZEINFO(MessagePacket MP)
  {
    switch (MP.ReadByte())
    {
      case 0:
        this.FullGift_TreasureItemCount = MP.ReadByte();
        for (int index = 0; index < (int) this.FullGift_TreasureItemCount && index < 200; ++index)
        {
          this.FullGift_TreasureItem[index].ItemID = MP.ReadUShort();
          this.FullGift_TreasureItem[index].Num = MP.ReadUShort();
          this.FullGift_TreasureItem[index].ItemRank = MP.ReadByte();
        }
        if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Mall_FG_Detail))
        {
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_FG_Detail, 3);
          break;
        }
        if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
        {
          this.door.OpenMenu(EGUIWindow.UI_Mall_FG_Detail);
          break;
        }
        break;
      case 1:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7343U), (ushort) byte.MaxValue);
        break;
      case 2:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7343U), (ushort) byte.MaxValue);
        break;
    }
    GUIManager.Instance.HideUILock(EUILock.Mall);
  }

  public void Recv_TREASUREBACK_RCVPRIZE(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0);
    byte num = MP.ReadByte();
    for (int index = 0; index < (int) num; ++index)
    {
      ushort ItemID = MP.ReadUShort();
      ushort Quantity = MP.ReadUShort();
      byte Rare = MP.ReadByte();
      instance.SetCurItemQuantity(ItemID, Quantity, Rare, 0L);
    }
    GameManager.OnRefresh();
    GameManager.OnRefresh(NetworkNews.Refresh_Attr);
    GameManager.OnRefresh(NetworkNews.Refresh_Item);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 11);
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17510U), (ushort) 28);
    GUIManager.Instance.HideUILock(EUILock.Mall);
  }

  public void CheckOpenPUSHBACK_PRIZE()
  {
    if (this.BackRewardComboBoxID == (ushort) 0 || this.BackRewardOpenID != (ushort) 0 || !((UnityEngine.Object) this.door != (UnityEngine.Object) null))
      return;
    GUIManager instance = GUIManager.Instance;
    if ((bool) (UnityEngine.Object) instance.FindMenu(EGUIWindow.UIBackReward_Detail) || (bool) (UnityEngine.Object) instance.FindMenu(EGUIWindow.UIBackReward))
      return;
    this.bCanOpenMain = true;
    if (NewbieManager.IsWorking() || instance.CheckInQueue(EGUIWindow.UIBackReward))
      return;
    this.BackRewardOpenID = this.BackRewardComboBoxID;
    instance.OpenUI_Queued_Restricted(EGUIWindow.UIBackReward, openMode: (byte) 2);
  }

  public void Send_PUSHBACK_PRIZE()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PUSHBACK_PRIZE;
    messagePacket.AddSeqId();
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Mall);
  }

  public void Recv_PUSHBACK_PRIZE(MessagePacket MP)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    if (MP.ReadByte() == (byte) 0)
    {
      instance2.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0);
      instance1.RoleAlliance.Money = MP.ReadUInt();
      byte num = MP.ReadByte();
      for (int index = 0; index < (int) num; ++index)
      {
        ushort ItemID = MP.ReadUShort();
        ushort Quantity = MP.ReadUShort();
        byte Rare = MP.ReadByte();
        instance1.SetCurItemQuantity(ItemID, Quantity, Rare, 0L);
      }
      GameManager.OnRefresh();
      GameManager.OnRefresh(NetworkNews.Refresh_Attr);
      GameManager.OnRefresh(NetworkNews.Refresh_Item);
      instance2.AddHUDMessage(instance1.mStringTable.GetStringByID(10170U), (ushort) 254);
      LordEquipData.Instance().Scan_MaterialOrEquipIncreace();
    }
    this.BackRewardComboBoxID = (ushort) 0;
    if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
    {
      if ((bool) (UnityEngine.Object) instance2.FindMenu(EGUIWindow.UIBackReward_Detail))
      {
        if (this.door.m_WindowStack.Count >= 2)
          this.door.m_WindowStack.RemoveAt(this.door.m_WindowStack.Count - 2);
        this.door.CloseMenu();
      }
      else if ((bool) (UnityEngine.Object) instance2.FindMenu(EGUIWindow.UIBackReward))
        this.door.CloseMenu();
    }
    instance2.HideUILock(EUILock.Mall);
    instance2.UIQueueLockRelease(EGUIQueueLock.UIQL_Mall);
  }
}
