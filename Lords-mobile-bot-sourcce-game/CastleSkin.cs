// Decompiled with JetBrains decompiler
// Type: CastleSkin
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

#nullable disable
public class CastleSkin
{
  public const byte MaxRank = 5;
  public const byte EnhanceRequireCastleLv = 25;
  private int AssetID;
  private byte CastleID;
  private byte Level;
  private byte UILevel;
  private Material material;
  private Material defaultMaterial;
  private Material defaultMaterialUI;
  private Sprite sprite;
  private Sprite defaultSprite;
  private CString tmpAssetName;
  private byte bUILoaded;
  private int[] AllAssetID;
  private Sprite[] AllSprite;
  private Material[] AllMaterial;
  private ushort[] SortCastleID;
  private ushort[] GraphicNameIndex;
  private byte SortCount;
  private CastleSort SortComparer = new CastleSort();
  private CastleSkin._SortType SortType;
  private byte[] SaveExclamationData;
  private string ExclamationSaveName = "ExclamationSave";
  private byte ExclamationCount;
  public byte UnlockCastleSkinNotice;
  private byte[] CastleSwitch;
  private byte[] CastleEnhance;
  public CExternalTableWithWordKey<CastleSkinTbl> CastleSkinTable;
  public CExternalTableWithWordKey<CastleEnhanceTbl> CastleEnhanceTable;
  private ushort[] CastleEnhanceIndexTable;
  public ushort ActiveCastleID;
  private byte[] DefaultExclamation;
  private bool bCheckCastleStrengthen = true;

  public CastleSkin() => this.tmpAssetName = new CString(256);

  public void SortDirty() => this.SortType = CastleSkin._SortType.None;

  public CastleSkin._SortType curSortType => this.SortType;

  public byte[] SkinUnlock => this.CastleSwitch;

  public byte[] SkinLevel => this.CastleEnhance;

  public void LoadTable()
  {
    this.CastleSkinTable = new CExternalTableWithWordKey<CastleSkinTbl>();
    this.CastleEnhanceTable = new CExternalTableWithWordKey<CastleEnhanceTbl>();
    this.CastleSkinTable.LoadTable("Castleunlock");
    byte length = 0;
    for (int Index = 0; Index < this.CastleSkinTable.TableCount; ++Index)
    {
      byte graphic = this.CastleSkinTable.GetRecordByIndex(Index).Graphic;
      if ((int) length < (int) graphic)
        length = graphic;
    }
    this.CastleEnhanceIndexTable = new ushort[(int) this.CastleSkinTable.MapCount];
    int tableCount = this.CastleSkinTable.TableCount;
    this.AllAssetID = new int[(int) length];
    this.AllSprite = new Sprite[(int) length];
    this.AllMaterial = new Material[(int) length];
    this.GraphicNameIndex = new ushort[(int) length];
    this.DefaultExclamation = new byte[(this.CastleSkinTable.TableCount >> 3) + ((this.CastleSkinTable.TableCount & 7) <= 0 ? 0 : 1)];
    this.SortCastleID = new ushort[tableCount];
    this.ActiveCastleID = (ushort) 0;
    byte num1 = 0;
    for (int Index = 0; Index < this.CastleSkinTable.TableCount; ++Index)
    {
      CastleSkinTbl recordByIndex = this.CastleSkinTable.GetRecordByIndex(Index);
      byte num2 = recordByIndex.Graphic;
      switch (num2)
      {
        case 1:
        case 2:
          num2 = (byte) 0;
          break;
      }
      int index = 0;
      if (num2 > (byte) 0)
        index = (int) num2 - 2;
      if (recordByIndex.DefaultExclamation == (byte) 0)
        this.SetBitField((byte) recordByIndex.ID, this.DefaultExclamation);
      this.GraphicNameIndex[index] = recordByIndex.Name;
      if (recordByIndex.Priority != byte.MaxValue && (int) recordByIndex.Priority > (int) num1)
      {
        num1 = recordByIndex.Priority;
        this.ActiveCastleID = recordByIndex.ID;
      }
    }
    this.CastleEnhanceTable.LoadTable("CastleEnhance");
    ushort num3 = (ushort) byte.MaxValue;
    for (int Index = 0; Index < this.CastleEnhanceTable.TableCount; ++Index)
    {
      CastleEnhanceTbl recordByIndex = this.CastleEnhanceTable.GetRecordByIndex(Index);
      if ((int) num3 != (int) recordByIndex.CastleID)
      {
        num3 = recordByIndex.CastleID;
        if ((int) num3 <= this.CastleEnhanceIndexTable.Length)
          this.CastleEnhanceIndexTable[(int) num3 - 1] = recordByIndex.ID;
      }
    }
  }

  public CastleEnhanceTbl GetCastleEnhanceData(byte CastleID, byte Rank)
  {
    return CastleID == (byte) 0 || Rank > (byte) 5 ? new CastleEnhanceTbl() : this.CastleEnhanceTable.GetRecordByKey((ushort) ((uint) this.CastleEnhanceIndexTable[(int) CastleID - 1] + (uint) Rank));
  }

  private void LoadCastleSkinSave()
  {
    if (this.SaveExclamationData == null)
    {
      byte count = 5;
      try
      {
        this.tmpAssetName.ClearString();
        this.tmpAssetName.StringToFormat(AssetManager.persistentDataPath);
        this.tmpAssetName.IntToFormat(DataManager.Instance.RoleAttr.UserId);
        this.tmpAssetName.StringToFormat(this.ExclamationSaveName);
        this.tmpAssetName.AppendFormat("{0}/Data/{1}{2}");
        this.tmpAssetName.SetLength(this.tmpAssetName.Length);
        using (FileStream input = new FileStream(this.tmpAssetName.ToString(), FileMode.OpenOrCreate, FileAccess.Read))
        {
          if (input.Length > 0L)
          {
            using (BinaryReader binaryReader = new BinaryReader((Stream) input))
            {
              count = binaryReader.ReadByte();
              this.SaveExclamationData = binaryReader.ReadBytes((int) count);
              this.UnlockCastleSkinNotice = binaryReader.ReadByte();
            }
          }
          else
          {
            this.SaveExclamationData = new byte[(int) count];
            Array.Copy((Array) this.DefaultExclamation, (Array) this.SaveExclamationData, Math.Min(this.DefaultExclamation.Length, this.SaveExclamationData.Length));
          }
        }
        this.tmpAssetName.SetLength(this.tmpAssetName.MaxLength);
      }
      catch (Exception ex)
      {
        this.SaveExclamationData = new byte[(int) count];
        Array.Copy((Array) this.DefaultExclamation, (Array) this.SaveExclamationData, Math.Min(this.DefaultExclamation.Length, this.SaveExclamationData.Length));
      }
    }
    if (this.CastleSwitch.Length == this.SaveExclamationData.Length)
      return;
    byte[] destinationArray = new byte[this.CastleSwitch.Length];
    Array.Copy((Array) this.SaveExclamationData, (Array) destinationArray, this.SaveExclamationData.Length);
    this.SaveExclamationData = destinationArray;
  }

  private void UpdateExclamationCount()
  {
    this.ExclamationCount = (byte) this.CastleSkinTable.TableCount;
    for (int index1 = 0; index1 < this.SaveExclamationData.Length; ++index1)
    {
      for (int index2 = 0; index2 < 8; ++index2)
      {
        if (((int) this.SaveExclamationData[index1] & 1 << index2) > 0 && this.ExclamationCount > (byte) 0)
          --this.ExclamationCount;
      }
    }
    if (this.UnlockCastleSkinNotice != (byte) 0 || this.ExclamationCount != (byte) 0)
      return;
    this.UnlockCastleSkinNotice = (byte) 1;
  }

  public byte GetExclamationCount() => this.ExclamationCount;

  public void SaveCastleSkinSave()
  {
    try
    {
      this.tmpAssetName.ClearString();
      this.tmpAssetName.StringToFormat(AssetManager.persistentDataPath);
      this.tmpAssetName.IntToFormat(DataManager.Instance.RoleAttr.UserId);
      this.tmpAssetName.StringToFormat(this.ExclamationSaveName);
      this.tmpAssetName.AppendFormat("{0}/Data/{1}{2}");
      this.tmpAssetName.SetLength(this.tmpAssetName.Length);
      using (FileStream output = new FileStream(this.tmpAssetName.ToString(), FileMode.OpenOrCreate))
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) output))
        {
          binaryWriter.Write((byte) this.SaveExclamationData.Length);
          binaryWriter.Write(this.SaveExclamationData, 0, this.SaveExclamationData.Length);
          binaryWriter.Write(this.UnlockCastleSkinNotice);
        }
      }
      this.tmpAssetName.SetLength(this.tmpAssetName.MaxLength);
    }
    catch (Exception ex)
    {
    }
  }

  public bool CheckShowCastleSkin()
  {
    return GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 9;
  }

  public bool CheckShowExclamation(bool bCheckNewbie = false)
  {
    byte level = GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level;
    bool flag = false;
    if (this.ExclamationCount > (byte) 0)
      flag = true;
    else if (bCheckNewbie && (level >= (byte) 9 && this.UnlockCastleSkinNotice == (byte) 0 || level >= (byte) 25 && !DataManager.Instance.CheckPrizeFlag((byte) 21)))
      flag = true;
    return flag;
  }

  public bool CheckSelect(byte ID) => this.CheckBitField(ID, this.SaveExclamationData);

  public void SetSelect(byte ID)
  {
    bool flag = this.CheckSelect(ID);
    this.SetBitField(ID, this.SaveExclamationData);
    if (flag == this.CheckSelect(ID) || this.ExclamationCount <= (byte) 0)
      return;
    --this.ExclamationCount;
    if (this.ExclamationCount != (byte) 0)
      return;
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public bool CheckUnlock(byte ID) => this.CheckBitField(ID, this.CastleSwitch);

  public void SetUnlock(byte ID) => this.SetBitField(ID, this.CastleSwitch);

  private bool CheckBitField(byte ID, byte[] Array)
  {
    if (ID == (byte) 0)
      return false;
    int index = (int) --ID >> 3;
    int num = (int) ID & 7;
    return index < Array.Length && ((int) Array[index] & 1 << num) > 0;
  }

  private void SetBitField(byte ID, byte[] Array)
  {
    if (ID == (byte) 0)
      return;
    int index = (int) --ID >> 3;
    int num = (int) ID & 7;
    if (index >= Array.Length)
      return;
    Array[index] |= (byte) (1 << num);
  }

  public byte GetCastleEnhance(byte ID)
  {
    return ID == (byte) 0 ? (byte) 0 : this.CastleEnhance[(int) ID - 1];
  }

  private void Load(byte ID, byte Level)
  {
    if (this.AssetID != 0)
      AssetManager.UnloadAssetBundle(this.AssetID);
    this.tmpAssetName.ClearString();
    byte graphic = this.CastleSkinTable.GetRecordByKey((ushort) ID).Graphic;
    if (graphic > (byte) 0)
    {
      this.tmpAssetName.IntToFormat((long) graphic, 3);
      this.tmpAssetName.AppendFormat("UI/castle_{0}");
    }
    else
    {
      this.tmpAssetName.IntToFormat((long) graphic, 3);
      byte x = 1;
      if (Level >= (byte) 9 && Level < (byte) 17)
        x = (byte) 2;
      else if (Level >= (byte) 17 && Level < (byte) 25)
        x = (byte) 3;
      else if (Level >= (byte) 25)
        x = (byte) 4;
      this.tmpAssetName.IntToFormat((long) x);
      this.tmpAssetName.AppendFormat("UI/castle_{0}-{1}");
    }
    AssetBundle assetBundle = AssetManager.GetAssetBundle(this.tmpAssetName, out this.AssetID);
    this.CastleID = ID;
    this.Level = Level;
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
    {
      if (this.AssetID != 0)
        AssetManager.UnloadAssetBundle(this.AssetID);
      this.AssetID = 0;
      this.LoadDefault(Level);
      this.sprite = this.defaultSprite;
      this.material = this.defaultMaterial;
    }
    else
    {
      UnityEngine.Object[] objectArray = assetBundle.LoadAll();
      this.sprite = objectArray[1] as Sprite;
      this.material = objectArray[3] as Material;
    }
  }

  private void LoadDefault(byte Level)
  {
    if ((UnityEngine.Object) this.defaultSprite != (UnityEngine.Object) null)
      return;
    byte x1 = 0;
    this.tmpAssetName.ClearString();
    this.tmpAssetName.IntToFormat((long) x1, 3);
    byte x2 = 1;
    if (Level >= (byte) 9 && Level < (byte) 17)
      x2 = (byte) 2;
    else if (Level >= (byte) 17 && Level < (byte) 25)
      x2 = (byte) 3;
    else if (Level >= (byte) 25)
      x2 = (byte) 4;
    this.tmpAssetName.IntToFormat((long) x2);
    this.tmpAssetName.AppendFormat("UI/castle_{0}-{1}");
    AssetBundle assetBundle = AssetManager.GetAssetBundle(this.tmpAssetName, out this.AssetID);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
    {
      if (this.AssetID != 0)
        AssetManager.UnloadAssetBundle(this.AssetID);
      this.AssetID = 0;
      this.defaultSprite = GUIManager.Instance.BuildingData.GetBuildSprite((ushort) 13, (byte) 0);
      this.defaultMaterial = GUIManager.Instance.MapSpriteMaterial;
      this.defaultMaterialUI = GUIManager.Instance.MapSpriteUIMaterial;
    }
    else
    {
      UnityEngine.Object[] objectArray = assetBundle.LoadAll();
      this.defaultSprite = objectArray[1] as Sprite;
      this.defaultMaterial = objectArray[3] as Material;
      this.defaultMaterialUI = objectArray[4] as Material;
    }
  }

  public Material GetMaterial(byte ID, byte Level = 0)
  {
    if ((UnityEngine.Object) this.material == (UnityEngine.Object) null || ID > (byte) 1 && (int) this.CastleID != (int) ID || ID == (byte) 1 && ((int) this.CastleID != (int) ID || (int) this.Level != (int) Level))
      this.Load(ID, Level);
    return this.material;
  }

  public Sprite GetSprite(byte ID, byte Level = 0)
  {
    if ((UnityEngine.Object) this.sprite == (UnityEngine.Object) null || ID > (byte) 1 && (int) this.CastleID != (int) ID || ID == (byte) 1 && ((int) this.CastleID != (int) ID || (int) this.Level != (int) Level))
      this.Load(ID, Level);
    return this.sprite;
  }

  public void Destroy()
  {
    if (this.AssetID != 0)
      AssetManager.UnloadAssetBundle(this.AssetID);
    this.AssetID = (int) (this.CastleID = (byte) 0);
  }

  public void KeepCastleSkinUI() => this.bUILoaded = (byte) 2;

  public void ClearCastleSkinUI(bool CleanImmediate = false)
  {
    if (this.bUILoaded == (byte) 0)
      return;
    if (this.bUILoaded > (byte) 1 && !CleanImmediate)
    {
      this.bUILoaded = (byte) 1;
    }
    else
    {
      for (int index = 0; index < this.AllAssetID.Length; ++index)
      {
        AssetManager.UnloadAssetBundle(this.AllAssetID[index]);
        this.AllAssetID[index] = 0;
      }
      this.bUILoaded = (byte) 0;
    }
  }

  private void LoadUISprite(byte ID, byte Level = 0)
  {
    if (ID == (byte) 1 || ID == (byte) 2)
      return;
    int index = 0;
    if (ID > (byte) 0)
      index = (int) ID - 2;
    if (this.AllAssetID[index] != 0)
      return;
    this.tmpAssetName.ClearString();
    if (ID > (byte) 0)
    {
      this.tmpAssetName.IntToFormat((long) ID, 3);
      this.tmpAssetName.AppendFormat("UI/castle_{0}");
    }
    else
    {
      this.UILevel = Level;
      this.tmpAssetName.IntToFormat((long) ID, 3);
      byte x = 1;
      if (Level >= (byte) 9 && Level < (byte) 17)
        x = (byte) 2;
      else if (Level >= (byte) 17 && Level < (byte) 25)
        x = (byte) 3;
      else if (Level >= (byte) 25)
        x = (byte) 4;
      this.tmpAssetName.IntToFormat((long) x);
      this.tmpAssetName.AppendFormat("UI/castle_{0}-{1}");
    }
    AssetBundle assetBundle = AssetManager.GetAssetBundle(this.tmpAssetName, out this.AllAssetID[index]);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
    {
      if (this.AllAssetID[index] != 0)
        AssetManager.UnloadAssetBundle(this.AllAssetID[index]);
      this.AllAssetID[index] = 0;
      this.LoadDefault((byte) 0);
      this.AllSprite[index] = this.defaultSprite;
      this.AllMaterial[index] = this.defaultMaterialUI;
    }
    else
    {
      UnityEngine.Object[] objectArray = assetBundle.LoadAll();
      this.AllSprite[index] = objectArray[1] as Sprite;
      this.AllMaterial[index] = objectArray[4] as Material;
      this.bUILoaded = (byte) 1;
    }
  }

  public Sprite GetUISprite(byte ID, byte Level = 0)
  {
    if (ID == (byte) 1 || ID == (byte) 2)
      ID = (byte) 0;
    int index = 0;
    if (ID > (byte) 0)
      index = (int) ID - 2;
    if (index >= this.AllAssetID.Length)
    {
      this.LoadDefault((byte) 0);
      return this.defaultSprite;
    }
    if (this.AllAssetID[index] == 0)
      this.LoadUISprite(ID, Level);
    else if (ID == (byte) 0 && (int) this.UILevel != (int) Level)
    {
      AssetManager.UnloadAssetBundle(this.AllAssetID[index]);
      this.AllAssetID[index] = 0;
      this.LoadUISprite(ID, Level);
    }
    if (!((UnityEngine.Object) this.AllSprite[index] == (UnityEngine.Object) null))
      return this.AllSprite[index];
    this.LoadDefault((byte) 0);
    return this.defaultSprite;
  }

  public Material GetUIMaterial(byte ID, byte Level = 0)
  {
    if (ID == (byte) 1 || ID == (byte) 2)
      ID = (byte) 0;
    int index = 0;
    if (ID > (byte) 0)
      index = (int) ID - 2;
    if (index >= this.AllAssetID.Length)
    {
      this.LoadDefault((byte) 0);
      return this.defaultMaterialUI;
    }
    if (this.AllAssetID[index] == 0)
      this.LoadUISprite(ID, Level);
    else if (ID == (byte) 0 && (int) this.UILevel != (int) Level)
    {
      AssetManager.UnloadAssetBundle(this.AllAssetID[index]);
      this.AllAssetID[index] = 0;
      this.LoadUISprite(ID, Level);
    }
    if (!((UnityEngine.Object) this.AllMaterial[index] == (UnityEngine.Object) null))
      return this.AllMaterial[index];
    this.LoadDefault((byte) 0);
    return this.defaultMaterialUI;
  }

  public string GetCastleSkinName(byte graphicID)
  {
    if (graphicID == (byte) 1 || graphicID == (byte) 2)
      graphicID = (byte) 0;
    int index = 0;
    if (graphicID > (byte) 0)
      index = (int) graphicID - 2;
    return index >= this.GraphicNameIndex.Length || this.GraphicNameIndex[index] == (ushort) 0 ? string.Empty : DataManager.Instance.mStringTable.GetStringByID((uint) this.GraphicNameIndex[index]);
  }

  private void UnlockMall()
  {
    if (!MallManager.Instance.bLockBuyCastleID || MallManager.Instance.SendCheckCastleID == (ushort) 0 || !this.CheckUnlock((byte) MallManager.Instance.SendCheckCastleID))
      return;
    MallManager.Instance.ClearSendCheckBuySN();
  }

  public void RecvCastleUnlockdata(MessagePacket Mp)
  {
    GUIManager.Instance.BuildingData.CastleID = Mp.ReadByte();
    byte size = Mp.ReadByte();
    if (this.CastleSwitch == null || this.CastleSwitch.Length < (int) size)
      this.CastleSwitch = new byte[(int) size];
    byte num1 = Mp.ReadByte();
    if (this.CastleEnhance == null || this.CastleEnhance.Length < (int) size * 8)
      this.CastleEnhance = new byte[(int) size * 8];
    this.LoadCastleSkinSave();
    Mp.ReadBlock(this.CastleSwitch, 0, (int) size);
    int num2 = 0;
    if (num1 > (byte) 0)
    {
      for (int index1 = 0; index1 < this.CastleSwitch.Length; ++index1)
      {
        for (int index2 = 0; index2 < 8; ++index2)
        {
          if (((int) this.CastleSwitch[index1] & 1 << index2) > 0)
          {
            int index3 = index1 * 8 + index2;
            this.CastleEnhance[index3] = Mp.ReadByte();
            if (this.CastleEnhance[index3] > (byte) 5)
              this.CastleEnhance[index3] = (byte) 5;
            this.SetSelect((byte) (index3 + 1));
            ++num2;
            if (num2 == (int) num1)
              break;
          }
        }
        if (num2 == (int) num1)
          break;
      }
    }
    this.UpdateExclamationCount();
    this.SortDirty();
    this.SetUnlock((byte) 1);
    this.UnlockMall();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_CastleSkin, 0);
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.CastleSkin);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_CastleStrengthen, 4);
  }

  public void RecvCastleSkinUpdate(MessagePacket Mp)
  {
    byte num1 = Mp.ReadByte();
    byte num2 = Mp.ReadByte();
    byte index = Mp.ReadByte();
    switch (num2)
    {
      case 0:
        if (num1 == (byte) 0)
        {
          this.SortDirty();
          this.SetUnlock((byte) ((uint) index + 1U));
          this.UnlockMall();
          AudioManager.Instance.PlayMP3SFX((ushort) 41011);
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(867U), (ushort) 254);
          GUIManager.Instance.HideUILock(EUILock.Mall);
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_CastleSkin, 2, (int) index + 1);
        }
        else
        {
          if (this.CastleEnhance.Length > (int) index)
          {
            this.CastleEnhance[(int) index] = Mp.ReadByte();
            if (this.CastleEnhance[(int) index] > (byte) 5)
              this.CastleEnhance[(int) index] = (byte) 5;
            if (this.CastleEnhance[(int) index] >= (byte) 2)
              AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.CASTLESKIN_LV2);
          }
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_CastleStrengthen, 1);
        }
        DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.CastleSkin);
        break;
      case 1:
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_CastleStrengthen, 3);
        break;
    }
  }

  public void RecvCastleSkinChange(MessagePacket Mp)
  {
    if (Mp.ReadByte() != (byte) 0)
      return;
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    instance2.BuildingData.CastleID = Mp.ReadByte();
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.StringToFormat(instance1.mStringTable.GetStringByID((uint) instance2.BuildingData.castleSkin.CastleSkinTable.GetRecordByKey((ushort) instance2.BuildingData.CastleID).Name));
    cstring.AppendFormat(instance1.mStringTable.GetStringByID(9686U));
    instance2.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
    instance2.UpdateUI(EGUIWindow.UI_CastleSkin, 3, (int) instance2.BuildingData.CastleID);
    instance2.HideUILock(EUILock.CastleSkin);
    instance1.AttribVal.UpdateAttrVal(UpdateAttrKind.CastleSkin);
    AudioManager.Instance.PlayUISFX(UIKind.ItemUse);
  }

  public ushort[] GetAllCastleID(CastleSkin._SortType type, out byte count)
  {
    if (type == this.SortType)
    {
      count = this.SortCount;
      return this.SortCastleID;
    }
    this.SortType = type;
    this.SortCount = (byte) 0;
    for (int index = 0; index < this.CastleSkinTable.TableCount; ++index)
    {
      if (this.SortType == CastleSkin._SortType.Own)
      {
        if (this.CheckUnlock((byte) (index + 1)))
          this.SortCastleID[(int) this.SortCount++] = (ushort) (index + 1);
      }
      else
        this.SortCastleID[(int) this.SortCount++] = (ushort) (index + 1);
    }
    this.SortComparer.type = this.SortType;
    Array.Sort<ushort>(this.SortCastleID, 0, (int) this.SortCount, (IComparer<ushort>) this.SortComparer);
    if (this.SortCastleID.Length - 1 > (int) this.SortCount)
      this.SortCastleID[(int) this.SortCount] = (ushort) 0;
    count = this.SortCount;
    return this.SortCastleID;
  }

  public void SetCheckStrengthen(bool bSet) => this.bCheckCastleStrengthen = bSet;

  public bool GetCheckStrengthen() => this.bCheckCastleStrengthen;

  public enum _SortType
  {
    None,
    All,
    Own,
  }
}
