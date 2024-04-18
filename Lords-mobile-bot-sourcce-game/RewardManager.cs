// Decompiled with JetBrains decompiler
// Type: RewardManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class RewardManager
{
  private AssetBundle rewardBundle;
  private List<RewardNode> rewardWorkingList = new List<RewardNode>(64);
  private List<RewardNode> rewardFreeList = new List<RewardNode>(64);
  public RectTransform rootLayer;
  public Vector2 bezierEnd = Vector2.zero;
  public Vector2 ScreenSize = Vector2.zero;
  public ERewardEndPoint EndPointMode;
  private static RewardManager m_Self;

  private RewardManager()
  {
  }

  public bool IsWorking => this.rewardWorkingList.Count > 0;

  public static RewardManager getInstance
  {
    get
    {
      if (RewardManager.m_Self == null)
        RewardManager.m_Self = new RewardManager();
      return RewardManager.m_Self;
    }
  }

  public void Init(ERewardEndPoint mode = ERewardEndPoint.GambleMode)
  {
    this.ScreenSize = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
    this.EndPointMode = ERewardEndPoint.Default;
    if (mode == ERewardEndPoint.GambleMode)
    {
      this.bezierEnd = GamblingManager.Instance.m_ItemPos;
      this.bezierEnd.y = this.ScreenSize.y + this.bezierEnd.y;
      this.EndPointMode = ERewardEndPoint.GambleMode;
    }
    else
      this.bezierEnd = new Vector2(42f, this.ScreenSize.y - 79f);
    this.rewardBundle = AssetManager.GetAssetBundle("Role/chest", 0L);
    this.rootLayer = new GameObject(nameof (RewardManager)).AddComponent<RectTransform>();
    this.rootLayer.pivot = new Vector2(0.5f, 0.5f);
    this.rootLayer.anchorMin = new Vector2(0.0f, 0.0f);
    this.rootLayer.anchorMax = new Vector2(0.0f, 0.0f);
    ((Transform) this.rootLayer).SetParent((Transform) GUIManager.Instance.m_WindowsTransform, false);
    ((Transform) this.rootLayer).SetAsFirstSibling();
  }

  public void Free()
  {
    for (int index = 0; index < this.rewardWorkingList.Count; ++index)
    {
      if (this.rewardWorkingList[index] != null)
        this.rewardWorkingList[index].Destroy();
    }
    this.rewardWorkingList.Clear();
    for (int index = 0; index < this.rewardFreeList.Count; ++index)
    {
      if (this.rewardFreeList[index] != null)
        this.rewardFreeList[index].Destroy();
    }
    this.rewardFreeList.Clear();
    if ((Object) this.rootLayer != (Object) null)
    {
      Object.Destroy((Object) ((Component) this.rootLayer).gameObject);
      this.rootLayer = (RectTransform) null;
    }
    if (!((Object) this.rewardBundle != (Object) null))
      return;
    this.rewardBundle.Unload(true);
    this.rewardBundle = (AssetBundle) null;
  }

  public void Update(float deltaTime)
  {
    for (int index = this.rewardWorkingList.Count - 1; index >= 0; --index)
    {
      if (!this.rewardWorkingList[index].Update(deltaTime))
      {
        RewardNode rewardWorking = this.rewardWorkingList[index];
        this.rewardWorkingList.RemoveAt(index);
        rewardWorking.SetActive(false);
        this.rewardFreeList.Add(rewardWorking);
      }
    }
  }

  public void Clear()
  {
    for (int index = this.rewardWorkingList.Count - 1; index >= 0; --index)
    {
      RewardNode rewardWorking = this.rewardWorkingList[index];
      this.rewardWorkingList.RemoveAt(index);
      rewardWorking.SetActive(false, true);
      this.rewardFreeList.Add(rewardWorking);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 1);
    }
  }

  public void FontRefresh()
  {
    for (int index = this.rewardWorkingList.Count - 1; index >= 0; --index)
      this.rewardWorkingList[index]?.FontRefresh();
  }

  public void addReward(ushort itemID, Vector3 startPos, Vector3 endPos, byte itemRank = 0)
  {
    RewardNode rewardNode;
    if (this.rewardFreeList.Count > 0)
    {
      int index = this.rewardFreeList.Count - 1;
      rewardNode = this.rewardFreeList[index];
      this.rewardFreeList.RemoveAt(index);
    }
    else
      rewardNode = new RewardNode(this.rewardBundle, this.rootLayer);
    rewardNode.InitNode(itemID, startPos, endPos, itemRank);
    this.rewardWorkingList.Add(rewardNode);
  }
}
