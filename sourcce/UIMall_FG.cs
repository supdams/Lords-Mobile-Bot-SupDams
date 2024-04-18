// Decompiled with JetBrains decompiler
// Type: UIMall_FG
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIMall_FG : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
  private Transform m_transform;
  private Transform ActorPosT;
  private Transform LightT;
  private DataManager DM;
  private GUIManager GM;
  private MallManager MM;
  private Font tmpFont;
  private Door m_door;
  private int AssetKey;
  private AssetBundle AB;
  private AssetBundleRequest AR;
  private bool bABInitial;
  private GameObject PriestGO;
  private Animation PriestAnimation;
  private float CrossFadeTime = 0.4f;
  private float ReRandomTime;
  private float RandomTime;
  private float[] PlayTime1 = new float[2];
  private float[] PlayTime2 = new float[3];
  private string[] AnName1 = new string[2]
  {
    "idle",
    "idle04"
  };
  private string[] AnName2 = new string[3]
  {
    "idle02",
    "idle03",
    "talk"
  };
  private int lastIdx;
  private UIText RatioText;
  private UIText NeedCrystalText;
  private UIText MessageText;
  private UIText TitleText;
  private UIText TimeText;
  private CString RatioStr;
  private CString NeedCrystalStr;
  private CString MessageStr;
  private CString TimeStr;
  private Image RatioImage;
  private bool bResourceRed;
  private float ResourceRedTime;
  private bool bClose;

  public Door door
  {
    get
    {
      if ((Object) this.m_door == (Object) null)
        this.m_door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      return this.m_door;
    }
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.MM = MallManager.Instance;
    this.m_transform = this.transform;
    this.tmpFont = this.GM.GetTTFFont();
    this.LightT = this.m_transform.GetChild(0);
    this.m_transform.GetChild(1).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.RatioImage = this.m_transform.GetChild(1).GetChild(0).GetComponent<Image>();
    this.RatioText = this.m_transform.GetChild(1).GetChild(1).GetComponent<UIText>();
    this.RatioText.font = this.tmpFont;
    this.RatioStr = StringManager.Instance.SpawnString();
    this.NeedCrystalText = this.m_transform.GetChild(2).GetChild(1).GetComponent<UIText>();
    this.NeedCrystalText.font = this.tmpFont;
    this.NeedCrystalStr = StringManager.Instance.SpawnString(50);
    this.MessageText = this.m_transform.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.MessageText.font = this.tmpFont;
    this.MessageStr = StringManager.Instance.SpawnString(500);
    this.TitleText = this.m_transform.GetChild(4).GetChild(0).GetComponent<UIText>();
    this.TitleText.font = this.tmpFont;
    this.TitleText.text = this.DM.mStringTable.GetStringByID(17514U);
    this.TimeText = this.m_transform.GetChild(5).GetChild(0).GetComponent<UIText>();
    this.TimeText.font = this.tmpFont;
    this.TimeStr = StringManager.Instance.SpawnString();
    this.m_transform.GetChild(6).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(7).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(7).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(7).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) this.m_transform.GetChild(7).GetComponent<CustomImage>()).enabled = false;
    this.ActorPosT = this.m_transform.GetChild(8);
    ((RectTransform) this.ActorPosT).anchoredPosition = new Vector2(-300f, -470f);
    this.AB = AssetManager.GetAssetBundle("Role/Priest", out this.AssetKey);
    this.AR = this.AB.LoadAsync("Priest", typeof (GameObject));
    this.bABInitial = false;
    this.UpdateAll();
    if (this.MM.FullGift_Deadline != 0L)
      return;
    this.bClose = true;
  }

  public override void OnClose()
  {
    StringManager.Instance.DeSpawnString(this.RatioStr);
    StringManager.Instance.DeSpawnString(this.NeedCrystalStr);
    StringManager.Instance.DeSpawnString(this.MessageStr);
    StringManager.Instance.DeSpawnString(this.TimeStr);
    AssetManager.UnloadAssetBundle(this.AssetKey);
  }

  private void Update()
  {
    if (this.bClose)
    {
      this.bClose = false;
      if (!(bool) (Object) this.door)
        return;
      this.door.CloseMenu();
    }
    else
    {
      if ((Object) this.LightT != (Object) null)
        this.LightT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
      if (!this.bABInitial && this.AR.isDone)
      {
        this.bABInitial = true;
        this.PriestGO = (GameObject) Object.Instantiate(this.AR.asset);
        if ((Object) this.PriestGO != (Object) null)
        {
          this.PriestGO.transform.SetParent(this.ActorPosT, false);
          this.PriestGO.transform.localPosition = Vector3.zero;
          this.PriestGO.transform.localRotation = new Quaternion(0.0f, -180f, 0.0f, 0.0f);
          this.PriestGO.transform.localScale = new Vector3(360f, 360f, 360f);
          GUIManager.Instance.SetLayer(this.PriestGO, 5);
          this.PriestAnimation = this.PriestGO.GetComponent<Animation>();
          this.PriestAnimation.wrapMode = WrapMode.Default;
          this.PriestAnimation["idle"].wrapMode = WrapMode.Loop;
          for (int index = 0; index < 2; ++index)
          {
            this.PriestAnimation[this.AnName1[index]].layer = 1;
            this.PlayTime1[index] = this.PriestAnimation[this.AnName1[index]].length;
          }
          for (int index = 0; index < 3; ++index)
          {
            this.PriestAnimation[this.AnName2[index]].layer = 1;
            this.PlayTime2[index] = this.PriestAnimation[this.AnName2[index]].length;
          }
          this.PriestAnimation["idle"].layer = 0;
          this.PriestAnimation.Play("idle");
          this.PriestAnimation.CrossFade("talk");
          this.ReRandomTime = this.PriestAnimation["talk"].length;
          this.lastIdx = 4;
          this.PriestGO.GetComponentInChildren<SkinnedMeshRenderer>().useLightProbes = false;
        }
      }
      if (this.bABInitial)
      {
        this.ReRandomTime -= Time.smoothDeltaTime;
        if ((double) this.ReRandomTime <= 0.0)
        {
          this.ReRandomTime = this.RandomTime;
          int num = Random.Range(1, 101);
          if (num > 40)
          {
            int index = this.lastIdx != 0 ? (this.lastIdx != 1 ? num % this.PlayTime1.Length : 0) : 1;
            this.PriestAnimation.CrossFade(this.AnName1[index], this.CrossFadeTime);
            this.ReRandomTime += this.PlayTime1[index];
            this.lastIdx = index;
          }
          else
          {
            int index = 0;
            if (this.lastIdx >= this.PlayTime1.Length)
            {
              this.lastIdx -= this.PlayTime1.Length;
              if (this.lastIdx >= 0 && this.lastIdx < this.PlayTime2.Length)
              {
                do
                {
                  index = Random.Range(0, this.PlayTime2.Length);
                }
                while (index == this.lastIdx);
              }
            }
            else
              index = num % this.PlayTime2.Length;
            this.PriestAnimation.CrossFade(this.AnName2[index], this.CrossFadeTime);
            this.ReRandomTime += this.PlayTime2[index];
            this.lastIdx = index + this.PlayTime1.Length;
          }
        }
      }
      if (!((Object) this.TimeText != (Object) null))
        return;
      this.ResourceRedTime += Time.deltaTime;
      if ((double) this.ResourceRedTime < 0.5)
        return;
      this.ResourceRedTime = 0.0f;
      this.bResourceRed = !this.bResourceRed;
      if (this.bResourceRed)
        ((Graphic) this.TimeText).color = Color.red;
      else
        ((Graphic) this.TimeText).color = Color.white;
    }
  }

  private void UpdateTime()
  {
    if ((Object) this.TimeText == (Object) null)
      return;
    this.TimeStr.Length = 0;
    GameConstants.GetTimeString(this.TimeStr, this.MM.FullGift_Deadline > this.DM.ServerTime ? (uint) (this.MM.FullGift_Deadline - this.DM.ServerTime) : 0U);
    this.TimeText.text = this.TimeStr.ToString();
    this.TimeText.SetAllDirty();
    this.TimeText.cachedTextGenerator.Invalidate();
  }

  private void UpdateAll()
  {
    if ((Object) this.MessageText == (Object) null || this.MM.FullGift_Deadline == 0L)
      return;
    this.UpdateTime();
    uint x = this.MM.FullGift_MaxCrystal - this.MM.FullGift_NowCrystal;
    float num = this.MM.FullGift_MaxCrystal != 0U ? (float) this.MM.FullGift_NowCrystal / (float) this.MM.FullGift_MaxCrystal : 0.0f;
    this.NeedCrystalStr.Length = 0;
    this.NeedCrystalStr.IntToFormat((long) x, bNumber: true);
    this.NeedCrystalStr.AppendFormat(this.DM.mStringTable.GetStringByID(17513U));
    this.NeedCrystalText.text = this.NeedCrystalStr.ToString();
    this.NeedCrystalText.SetAllDirty();
    this.NeedCrystalText.cachedTextGenerator.Invalidate();
    this.MessageStr.Length = 0;
    this.MessageStr.IntToFormat((long) x, bNumber: true);
    this.MessageStr.AppendFormat(this.DM.mStringTable.GetStringByID(17512U));
    this.MessageText.text = this.MessageStr.ToString();
    this.MessageText.SetAllDirty();
    this.MessageText.cachedTextGenerator.Invalidate();
    this.RatioStr.Length = 0;
    this.RatioStr.IntToFormat((long) (int) ((double) num * 100.0));
    this.RatioStr.AppendFormat("{0}%");
    this.RatioText.text = this.RatioStr.ToString();
    this.RatioText.SetAllDirty();
    this.RatioText.cachedTextGenerator.Invalidate();
    this.RatioImage.fillAmount = num;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        break;
      case NetworkNews.Refresh:
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        if ((Object) this.RatioText != (Object) null && ((Behaviour) this.RatioText).enabled)
        {
          ((Behaviour) this.RatioText).enabled = false;
          ((Behaviour) this.RatioText).enabled = true;
        }
        if ((Object) this.NeedCrystalText != (Object) null && ((Behaviour) this.NeedCrystalText).enabled)
        {
          ((Behaviour) this.NeedCrystalText).enabled = false;
          ((Behaviour) this.NeedCrystalText).enabled = true;
        }
        if ((Object) this.MessageText != (Object) null && ((Behaviour) this.MessageText).enabled)
        {
          ((Behaviour) this.MessageText).enabled = false;
          ((Behaviour) this.MessageText).enabled = true;
        }
        if ((Object) this.TitleText != (Object) null && ((Behaviour) this.TitleText).enabled)
        {
          ((Behaviour) this.TitleText).enabled = false;
          ((Behaviour) this.TitleText).enabled = true;
        }
        if (!((Object) this.TimeText != (Object) null) || !((Behaviour) this.TimeText).enabled)
          break;
        ((Behaviour) this.TimeText).enabled = false;
        ((Behaviour) this.TimeText).enabled = true;
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        this.UpdateTime();
        break;
      case 1:
      case 2:
        if (this.MM.FullGift_Deadline == 0L && (bool) (Object) this.door)
          this.door.CloseMenu();
        this.UpdateAll();
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      if (!(bool) (Object) this.door)
        return;
      this.door.CloseMenu();
    }
    else
    {
      if (sender.m_BtnID1 != 2)
        return;
      this.MM.Send_TREASUREBACK_PRIZEINFO();
    }
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    if (!(bool) (Object) this.door)
      return;
    img.sprite = this.door.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = this.door.LoadMaterial();
  }
}
