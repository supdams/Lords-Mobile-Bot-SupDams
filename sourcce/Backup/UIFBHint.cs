// Decompiled with JetBrains decompiler
// Type: UIFBHint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class UIFBHint
{
  private int BundleKey;
  public GameObject gameobject;
  private GameObject blockGameObj;
  private RectTransform recttransform;
  private FBMissionHint MissionHint;
  private FBFriendHint FriendHint;
  private UISpritesArray FrameArray;
  private CanvasGroup canvasGroup;
  private Transform HintTrans;

  public UIFBHint()
  {
    AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UIFBMission", out this.BundleKey);
    if ((Object) assetBundle == (Object) null)
      return;
    Object original = assetBundle.Load("Hint");
    if (original == (Object) null)
      return;
    GUIManager instance = GUIManager.Instance;
    Font ttfFont = instance.GetTTFFont();
    this.gameobject = (GameObject) Object.Instantiate(original);
    this.recttransform = this.gameobject.transform as RectTransform;
    this.FrameArray = ((Transform) this.recttransform).GetChild(0).GetComponent<UISpritesArray>();
    this.canvasGroup = ((Component) this.recttransform).GetComponent<CanvasGroup>();
    this.MissionHint = new FBMissionHint(((Transform) this.recttransform).GetChild(0).GetChild(0), ttfFont);
    this.FriendHint = new FBFriendHint(((Transform) this.recttransform).GetChild(0).GetChild(1), ttfFont, ((Transform) this.recttransform).GetChild(1));
    ((Transform) this.recttransform).SetParent(instance.FindMenu(EGUIWindow.UI_MissionFB).transform, false);
    ((Transform) this.recttransform).SetAsLastSibling();
    this.blockGameObj = ((Transform) this.recttransform).GetChild(1).gameObject;
    this.Hide();
  }

  public void UpdateData()
  {
    this.MissionHint.UpdateData();
    this.FriendHint.UpdateData();
    if (!this.FriendHint.gameobject.activeSelf)
      return;
    this.recttransform.sizeDelta = new Vector2(this.FriendHint.Width, this.FriendHint.Height);
    if ((Object) this.HintTrans != (Object) null)
      this.GetTipPosition(this.HintTrans, UIButtonHint.ePosition.LeftSide, new Vector3?(new Vector3(-30f, 0.0f, 0.0f)));
    if (this.FriendHint.FriendCount > (byte) 0)
    {
      this.blockGameObj.SetActive(true);
      this.canvasGroup.blocksRaycasts = true;
    }
    else
    {
      this.blockGameObj.SetActive(false);
      this.canvasGroup.blocksRaycasts = false;
    }
  }

  public void UpdateTime() => this.FriendHint.UpdateTime();

  public void TextRefresh()
  {
    this.MissionHint.TextRefresh();
    this.FriendHint.TextRefresh();
  }

  public void Destroy()
  {
    this.MissionHint.Destroy();
    this.FriendHint.Destroy();
    if (this.BundleKey == 0)
      return;
    AssetManager.UnloadAssetBundle(this.BundleKey);
    this.BundleKey = 0;
    Object.Destroy((Object) this.gameobject);
    this.gameobject = (GameObject) null;
  }

  public void Show(ushort ID, Transform sender)
  {
    this.gameobject.SetActive(true);
    this.blockGameObj.SetActive(false);
    this.FriendHint.Hide();
    this.canvasGroup.blocksRaycasts = false;
    this.FrameArray.SetSpriteIndex(0);
    this.MissionHint.Show(ID);
    this.recttransform.sizeDelta = new Vector2(this.MissionHint.Width, this.MissionHint.Height);
    if ((Object) sender != (Object) null)
      this.GetTipPosition(sender, UIButtonHint.ePosition.LeftSide, new Vector3?(new Vector3(-30f, 0.0f, 0.0f)));
    this.HintTrans = sender;
  }

  public void ShowFriend(ushort ID, Transform sender)
  {
    CanvasGroup component = sender.GetComponent<CanvasGroup>();
    if ((Object) component != (Object) null && (double) component.alpha < 0.10000000149011612)
      return;
    this.gameobject.SetActive(true);
    this.MissionHint.Hide();
    this.FrameArray.SetSpriteIndex(1);
    this.FriendHint.Show(ID);
    if (this.FriendHint.FriendCount > (byte) 0)
    {
      this.blockGameObj.SetActive(true);
      this.canvasGroup.blocksRaycasts = true;
    }
    else
    {
      this.blockGameObj.SetActive(false);
      this.canvasGroup.blocksRaycasts = false;
    }
    this.HintTrans = sender;
    float height = this.FriendHint.Height;
    if ((double) height > 0.0)
    {
      this.recttransform.sizeDelta = new Vector2(this.FriendHint.Width, height);
      if (!((Object) sender != (Object) null))
        return;
      this.GetTipPosition(sender, UIButtonHint.ePosition.LeftSide, new Vector3?(new Vector3(-30f, 0.0f, 0.0f)));
    }
    else
      this.Hide();
  }

  public void GetTipPosition(
    Transform HintTransform,
    UIButtonHint.ePosition position = UIButtonHint.ePosition.Original,
    Vector3? upsetPoint = null)
  {
    RectTransform rectTransform = HintTransform as RectTransform;
    RectTransform recttransform = this.recttransform;
    if ((Object) rectTransform == (Object) null)
      return;
    Vector2 size = GUIManager.Instance.m_MessageBoxLayer.rect.size;
    ((Transform) recttransform).position = ((Transform) rectTransform).position;
    Vector3 anchoredPosition3D = recttransform.anchoredPosition3D;
    if (GUIManager.Instance.bOpenOnIPhoneX)
      size.x -= GUIManager.Instance.IPhoneX_DeltaX * 2f;
    if (position == UIButtonHint.ePosition.Original)
    {
      anchoredPosition3D.x += rectTransform.rect.x;
      anchoredPosition3D.y += rectTransform.rect.y;
    }
    else
    {
      anchoredPosition3D.x -= recttransform.rect.width;
      anchoredPosition3D.y += rectTransform.rect.y - rectTransform.rect.height;
    }
    if (upsetPoint.HasValue)
      anchoredPosition3D += upsetPoint.Value;
    anchoredPosition3D.z = 0.0f;
    if ((double) anchoredPosition3D.x + (double) recttransform.sizeDelta.x > (double) size.x)
      anchoredPosition3D.x = size.x - recttransform.sizeDelta.x;
    else if ((double) anchoredPosition3D.x < 0.0)
      anchoredPosition3D.x = 0.0f;
    if ((double) anchoredPosition3D.y + (double) rectTransform.rect.height + (double) recttransform.sizeDelta.y <= 0.0)
      anchoredPosition3D.y += rectTransform.rect.height + recttransform.sizeDelta.y;
    else if (-1.0 * (double) anchoredPosition3D.y + (double) recttransform.sizeDelta.y > (double) size.y)
      anchoredPosition3D.y = (float) (-1.0 * ((double) size.y - (double) recttransform.sizeDelta.y));
    if ((double) anchoredPosition3D.y > -60.0)
      anchoredPosition3D.y = -60f;
    recttransform.anchoredPosition3D = anchoredPosition3D;
  }

  public void Hide(Transform sender = null)
  {
    if (!((Object) this.gameobject != (Object) null) || !((Object) sender == (Object) null) && !((Object) this.HintTrans == (Object) sender))
      return;
    this.gameobject.SetActive(false);
    this.HintTrans = (Transform) null;
  }
}
