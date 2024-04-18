// Decompiled with JetBrains decompiler
// Type: UIStageStory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIStageStory : GUIWindow, IUIButtonClickHandler
{
  private Transform m_transform;
  private Transform ActorPosT;
  private Transform CloseBtnT;
  private UIButton CloseBtn;
  private UIText Text1;
  private UIText Text2;
  private UIText Text3;
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

  public override void OnOpen(int arg1, int arg2)
  {
    this.m_transform = this.transform;
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    if (instance2.bOpenOnIPhoneX)
    {
      ((RectTransform) this.m_transform).offsetMin = new Vector2(-instance2.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.m_transform).offsetMax = new Vector2(instance2.IPhoneX_DeltaX, 0.0f);
    }
    Transform child = this.m_transform.GetChild(0);
    child.GetComponent<uTweenScale>().duration = 0.5f;
    this.CloseBtnT = child.GetChild(7);
    this.CloseBtn = this.CloseBtnT.GetComponent<UIButton>();
    this.CloseBtn.m_Handler = (IUIButtonClickHandler) this;
    this.Text3 = this.CloseBtnT.GetChild(0).GetComponent<UIText>();
    this.Text3.font = ttfFont;
    this.Text3.text = instance1.mStringTable.GetStringByID(189U);
    this.Text1 = child.GetChild(8).GetComponent<UIText>();
    this.Text1.font = ttfFont;
    this.Text2 = child.GetChild(9).GetComponent<UIText>();
    this.Text2.font = ttfFont;
    if (DataManager.StageDataController._stageMode == StageMode.Corps)
    {
      CorpsStage recordByKey = DataManager.StageDataController.CorpsStageTable.GetRecordByKey((ushort) arg1);
      this.Text1.text = string.Empty;
      this.Text2.text = arg2 != 0 ? instance1.mStringTable.GetStringByID((uint) recordByKey.StageEndword) : instance1.mStringTable.GetStringByID((uint) recordByKey.StageForeword);
    }
    else
    {
      Chapter recordByKey = DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort) arg1);
      this.Text1.text = string.Empty;
      this.Text2.text = instance1.mStringTable.GetStringByID((uint) recordByKey.OpenTipsID);
    }
    this.ActorPosT = child.GetChild(10);
    this.AB = AssetManager.GetAssetBundle("Role/Priest", out this.AssetKey);
    this.AR = this.AB.LoadAsync("Priest", typeof (GameObject));
    this.bABInitial = false;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((Object) menu != (Object) null)
      menu.HideFightButton();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 1);
  }

  public override void OnClose() => AssetManager.UnloadAssetBundle(this.AssetKey);

  private void Update()
  {
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
    if (!this.bABInitial)
      return;
    this.ReRandomTime -= Time.smoothDeltaTime;
    if ((double) this.ReRandomTime > 0.0)
      return;
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

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    if ((Object) this.Text3 != (Object) null && ((Behaviour) this.Text3).enabled)
    {
      ((Behaviour) this.Text3).enabled = false;
      ((Behaviour) this.Text3).enabled = true;
    }
    if ((Object) this.Text2 != (Object) null && ((Behaviour) this.Text2).enabled)
    {
      ((Behaviour) this.Text2).enabled = false;
      ((Behaviour) this.Text2).enabled = true;
    }
    if (!((Object) this.Text1 != (Object) null) || !((Behaviour) this.Text1).enabled)
      return;
    ((Behaviour) this.Text1).enabled = false;
    ((Behaviour) this.Text1).enabled = true;
  }

  private void CloseSelf()
  {
    this.Text2.text = string.Empty;
    DataManager.msgBuffer[0] = (byte) 16;
    if (DataManager.StageDataController.isNotFirstInChapter[(int) DataManager.StageDataController._stageMode] == (byte) 0)
    {
      DataManager.StageDataController.isNotFirstInChapter[(int) DataManager.StageDataController._stageMode] = (byte) 1;
      DataManager.StageDataController.SaveisNotFirstInChapter();
    }
    else if ((int) DataManager.StageDataController.limitRecord[(int) DataManager.StageDataController._stageMode] > (int) DataManager.StageDataController.StageRecord[(int) DataManager.StageDataController._stageMode])
    {
      DataManager.StageDataController.isNotFirstInChapter[(int) DataManager.StageDataController._stageMode] = (byte) 0;
      DataManager.StageDataController.SaveisNotFirstInChapter();
    }
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 != 1)
      return;
    this.CloseSelf();
  }

  public override bool OnBackButtonClick()
  {
    this.CloseSelf();
    return true;
  }
}
