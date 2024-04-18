// Decompiled with JetBrains decompiler
// Type: MallDataType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class MallDataType
{
  public bool bAskListData;
  public bool bAskDetailData;
  public ushort SN;
  public ushort GroupID;
  public uint TreasureID;
  public ushort PicPackageID1;
  public ushort PicPackageID2;
  public ushort StrPackageID;
  public ETreasureType Type;
  public byte PosType;
  public byte BonusRate;
  public byte bBuyOnce;
  public uint TotalCrystal;
  public uint BonusCrystal;
  public long EndTime;
  public Color FrameColor;
  public Color LineColor;
  public ushort RenderWeight;
  public ushort ComboBoxID;
  public ComboBoxTBItemDataType[] BriefItem = new ComboBoxTBItemDataType[3];
  public ushort StampPic;
  public ushort StampHint;
  public byte Discount;
  public byte ExtraByte;
  public ushort[] ExtraData = new ushort[3];
  public ushort SetNo;
  public TreasureAllianceGiftDataType[] AllianceGift = new TreasureAllianceGiftDataType[5];
  public byte DataLen;
  public ComboBoxTBItemDataType[] Item = new ComboBoxTBItemDataType[200];
  public byte AllianceGiftShowTop;
  public uint uTime;
  public AssetBundle m_AssetBundle;
  public int m_AssetBundleKey;
  public Sprite m_BackImage1;
  public Sprite m_BackImage2;
  public Material m_Material;
  public AssetBundle m_StrAssetBundle;
  public int m_StrAssetBundleKey;
  public Download DownLoadStr;
  public bool bDownLoadPic;
  public bool bDownLoadStr;
  public bool bUpDatePic;
  public bool bUpDateStr;
  public bool bABUseInUI;
  public byte BuyOncePic;

  public MallDataType() => this.Initial();

  public void SetBuyOnce()
  {
    this.BuyOncePic = (byte) ((uint) this.PicPackageID1 / 10000U);
    this.PicPackageID1 %= (ushort) 10000;
  }

  public void SendAskDownLoad()
  {
    if (this.Type == ETreasureType.ETST_Crystal)
      return;
    if (this.m_AssetBundleKey == 0 && this.PicPackageID1 != (ushort) 0)
    {
      CString Name = StringManager.Instance.StaticString1024();
      Name.IntToFormat((long) this.PicPackageID1);
      Name.AppendFormat("Store/Mallback_{0}");
      if (AssetManager.GetAssetBundleDownload(Name, AssetPath.Store, AssetType.MallBack, this.PicPackageID1))
        this.bDownLoadPic = true;
    }
    if (this.PicPackageID2 != (ushort) 0)
    {
      MallManager instance = MallManager.Instance;
      ushort num = (ushort) ((uint) this.PicPackageID2 + 1000U);
      CString Name = StringManager.Instance.StaticString1024();
      Name.IntToFormat((long) num);
      Name.AppendFormat("Store/Mallback_{0}");
      if (AssetManager.GetAssetBundleDownload(Name, AssetPath.Store, AssetType.MallBack, num) && instance.MainData != null && (int) instance.MainData.PicPackageID2 == (int) this.PicPackageID2)
      {
        instance.LoadMainPackege(num);
        instance.SetMainPackage();
      }
    }
    if (this.m_StrAssetBundleKey == 0 && this.StrPackageID != (ushort) 0)
    {
      CString Name = StringManager.Instance.StaticString1024();
      Name.IntToFormat((long) this.StrPackageID);
      Name.AppendFormat("Store/Package_{0}");
      if (AssetManager.GetAssetBundleDownload(Name, AssetPath.Store, AssetType.MallPackage, this.StrPackageID))
        this.bDownLoadStr = true;
    }
    MallManager.Instance.CheckOpenMain();
  }

  public void Initial()
  {
    this.bAskListData = false;
    this.bAskDetailData = false;
    this.SN = (ushort) 0;
    this.GroupID = (ushort) 0;
    this.TreasureID = 0U;
    this.PicPackageID1 = (ushort) 0;
    this.PicPackageID2 = (ushort) 0;
    this.StrPackageID = (ushort) 0;
    this.Type = ETreasureType.ETST_NULL;
    this.PosType = (byte) 0;
    this.BonusRate = (byte) 0;
    this.TotalCrystal = 0U;
    this.BonusCrystal = 0U;
    this.EndTime = 0L;
    this.FrameColor = Color.white;
    this.LineColor = Color.white;
    this.RenderWeight = (ushort) 0;
    this.ComboBoxID = (ushort) 0;
    this.StampPic = (ushort) 0;
    this.Discount = (byte) 0;
    this.ExtraByte = (byte) 0;
    Array.Clear((Array) this.ExtraData, 0, this.ExtraData.Length);
    this.SetNo = (ushort) 0;
    Array.Clear((Array) this.AllianceGift, 0, this.AllianceGift.Length);
    this.DataLen = (byte) 0;
    Array.Clear((Array) this.Item, 0, this.Item.Length);
    this.AllianceGiftShowTop = (byte) 0;
    this.uTime = 0U;
    this.m_AssetBundle = (AssetBundle) null;
    this.m_AssetBundleKey = 0;
    this.m_BackImage1 = (Sprite) null;
    this.m_BackImage2 = (Sprite) null;
    this.m_Material = (Material) null;
    this.DownLoadStr = (Download) null;
    this.m_StrAssetBundle = (AssetBundle) null;
    this.m_StrAssetBundleKey = 0;
    this.bDownLoadPic = false;
    this.bDownLoadStr = false;
    this.bUpDatePic = false;
    this.bUpDateStr = false;
    this.bABUseInUI = false;
    this.BuyOncePic = (byte) 0;
  }

  public void InitialAB()
  {
    CString Name = StringManager.Instance.StaticString1024();
    if (this.PicPackageID1 != (ushort) 0)
    {
      Name.IntToFormat((long) this.PicPackageID1);
      Name.AppendFormat("Store/Mallback_{0}");
    }
    else
      Name.Append("UI/Mall_0");
    this.m_AssetBundle = AssetManager.GetAssetBundle(Name, out this.m_AssetBundleKey);
    if (!((UnityEngine.Object) this.m_AssetBundle != (UnityEngine.Object) null))
      return;
    this.m_Material = this.m_AssetBundle.Load("Mall_m", typeof (Material)) as Material;
    UnityEngine.Object[] objectArray = this.m_AssetBundle.LoadAll(typeof (Sprite));
    for (int index = 0; index < objectArray.Length; ++index)
    {
      switch (ushort.Parse(objectArray[index].name))
      {
        case 100:
          this.m_BackImage1 = (Sprite) objectArray[index];
          break;
        case 200:
          this.m_BackImage2 = (Sprite) objectArray[index];
          break;
      }
    }
  }

  public void UnloadBackAB(bool UnloadAll = true)
  {
    if (this.m_AssetBundleKey == 0)
      return;
    this.m_Material = (Material) null;
    this.m_BackImage1 = (Sprite) null;
    this.m_BackImage2 = (Sprite) null;
    AssetManager.UnloadAssetBundle(this.m_AssetBundleKey, UnloadAll);
    this.m_AssetBundle = (AssetBundle) null;
    this.m_AssetBundleKey = 0;
  }

  public void InitialABString()
  {
    if (this.StrPackageID == (ushort) 0)
      return;
    CString Name = StringManager.Instance.StaticString1024();
    Name.IntToFormat((long) this.StrPackageID);
    Name.AppendFormat("Store/Package_{0}");
    this.m_StrAssetBundle = AssetManager.GetAssetBundle(Name, out this.m_StrAssetBundleKey);
    if (!((UnityEngine.Object) this.m_StrAssetBundle != (UnityEngine.Object) null))
      return;
    this.DownLoadStr = this.m_StrAssetBundle.Load("Package", typeof (Download)) as Download;
  }

  public void UnloadStrAB()
  {
    if (this.m_StrAssetBundleKey == 0)
      return;
    AssetManager.UnloadAssetBundle(this.m_StrAssetBundleKey);
    this.m_StrAssetBundle = (AssetBundle) null;
    this.m_StrAssetBundleKey = 0;
  }

  public void UnloadAB(bool UnloadAll = true)
  {
    this.UnloadBackAB(UnloadAll);
    this.UnloadStrAB();
  }
}
