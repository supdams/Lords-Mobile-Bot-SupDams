// Decompiled with JetBrains decompiler
// Type: SPActivityDataType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class SPActivityDataType
{
  public const byte MAX_ACTIVITY_SPECIAL_CONTENT_DATE = 4;
  public bool bAskDetailData;
  public long EventBeginTime;
  public long EventEndTime;
  public ushort Name;
  public ushort Pic;
  public ushort PicStr;
  public ushort HeadStr;
  public ushort DetailPic;
  public ushort DetailStr;
  public ushort GoToButton;
  public ushort Marquee;
  public SPContentTimeDataType[] ContentTimeData = new SPContentTimeDataType[4];
  public bool bDownLoadStr;
  public bool bUpDateStr;
  public AssetBundle m_StrAssetBundle;
  public int m_StrAssetBundleKey;
  public ActivityData DownLoadStr;

  public void Initial()
  {
    this.bAskDetailData = false;
    this.EventBeginTime = 0L;
    this.EventEndTime = 0L;
    this.Name = (ushort) 0;
    this.Pic = (ushort) 0;
    this.PicStr = (ushort) 0;
    this.HeadStr = (ushort) 0;
    this.DetailPic = (ushort) 0;
    this.GoToButton = (ushort) 0;
    this.Marquee = (ushort) 0;
    for (int index = 0; index < this.ContentTimeData.Length; ++index)
    {
      this.ContentTimeData[index].BeginTime = 0L;
      this.ContentTimeData[index].RequireTime = 0U;
    }
    this.DownLoadStr = (ActivityData) null;
    this.bDownLoadStr = false;
    this.bUpDateStr = false;
    this.UnloadStrAB();
  }

  public void InitialABString()
  {
    if (this.DetailStr == (ushort) 0)
      return;
    CString Name = StringManager.Instance.StaticString1024();
    Name.IntToFormat((long) this.DetailStr);
    Name.AppendFormat("UI/UIActivityPackage_{0}");
    this.m_StrAssetBundle = AssetManager.GetAssetBundle(Name, out this.m_StrAssetBundleKey);
    if (!((Object) this.m_StrAssetBundle != (Object) null))
      return;
    this.DownLoadStr = this.m_StrAssetBundle.Load("Package", typeof (ActivityData)) as ActivityData;
  }

  public void UnloadStrAB()
  {
    if (this.m_StrAssetBundleKey == 0)
      return;
    AssetManager.UnloadAssetBundle(this.m_StrAssetBundleKey);
    this.m_StrAssetBundle = (AssetBundle) null;
    this.m_StrAssetBundleKey = 0;
  }
}
