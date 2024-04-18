// Decompiled with JetBrains decompiler
// Type: UILoadingTalk
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UILoadingTalk : GUIWindow, IUIButtonClickHandler
{
  private const float SelectWaveTime = 3.5f;
  private const int MaxActorCount = 3;
  private DataManager DM = DataManager.Instance;
  private GUIManager GM = GUIManager.Instance;
  private Transform m_transform;
  private Transform BackT;
  private UIText TalkTextL;
  private UIText TalkTextR;
  private UIText SelectText1;
  private UIText SelectText2;
  private UIText NowText;
  private RectTransform QuestionRC;
  private RectTransform TalkTextLRC;
  private RectTransform TalkTextRRC;
  private RectTransform NowTextRC;
  private GameObject[] LightGO = new GameObject[3];
  private RectTransform QuestBtnRC1;
  private RectTransform QuestBtnRC2;
  private GameObject QuestBtn1;
  private GameObject QuestBtn2;
  private LoadingTalk NowData;
  private eLoadingTalkType NowType;
  private ushort NowKey;
  private bool bCheckWaitTime;
  private float WaitTime;
  private bool bWaitSelect;
  private float WaitSelectTime;
  private float SelectCountTime = -1f;
  private float SelectCountTime2 = -1f;
  private bool bSelectCount;
  private byte LoadActorIndex;
  private int[] AssetKey = new int[3];
  private AssetBundle[] AB = new AssetBundle[3];
  private AssetBundleRequest[] AR = new AssetBundleRequest[3];
  private GameObject[] ActorGO = new GameObject[3];
  private Animation[] ActorAnimation = new Animation[3];
  private Transform[] ActorT = new Transform[3];
  private bool bLoadAllActor;

  public override void OnOpen(int arg1, int arg2)
  {
    this.m_transform = this.transform;
    Font ttfFont = this.GM.GetTTFFont();
    AudioManager.Instance.LoadSFXObj();
    this.BackT = this.m_transform.GetChild(0);
    this.TalkTextLRC = this.m_transform.GetChild(1).GetComponent<RectTransform>();
    this.TalkTextL = ((Transform) this.TalkTextLRC).GetChild(1).GetComponent<UIText>();
    this.TalkTextL.font = ttfFont;
    this.TalkTextRRC = this.m_transform.GetChild(2).GetComponent<RectTransform>();
    this.TalkTextR = ((Transform) this.TalkTextRRC).GetChild(1).GetComponent<UIText>();
    this.TalkTextR.font = ttfFont;
    this.NowText = this.TalkTextL;
    this.NowTextRC = this.TalkTextLRC;
    this.QuestionRC = this.m_transform.GetChild(3).GetComponent<RectTransform>();
    UIButton component1 = ((Transform) this.QuestionRC).GetChild(0).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 1;
    component1.SoundIndex = byte.MaxValue;
    UIButton component2 = ((Transform) this.QuestionRC).GetChild(1).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 2;
    component2.SoundIndex = byte.MaxValue;
    this.SelectText1 = ((Transform) this.QuestionRC).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.SelectText1.font = ttfFont;
    this.SelectText2 = ((Transform) this.QuestionRC).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.SelectText2.font = ttfFont;
    ((Component) this.QuestionRC).gameObject.SetActive(true);
    this.QuestBtn1 = ((Transform) this.QuestionRC).GetChild(0).gameObject;
    this.QuestBtn2 = ((Transform) this.QuestionRC).GetChild(1).gameObject;
    this.QuestBtnRC1 = ((Transform) this.QuestionRC).GetChild(0).GetComponent<RectTransform>();
    this.QuestBtnRC2 = ((Transform) this.QuestionRC).GetChild(1).GetComponent<RectTransform>();
    this.QuestBtn1.SetActive(false);
    this.QuestBtn2.SetActive(false);
    this.ActorT[0] = this.m_transform.GetChild(4);
    this.ActorT[1] = this.m_transform.GetChild(5);
    this.ActorT[2] = this.m_transform.GetChild(6);
    this.LightGO[0] = this.m_transform.GetChild(7).gameObject;
    this.LightGO[1] = this.m_transform.GetChild(8).gameObject;
    this.LightGO[2] = this.m_transform.GetChild(9).gameObject;
    this.LoadActor();
  }

  public override void OnClose()
  {
    for (int index = 0; index < 3; ++index)
    {
      if (this.AssetKey[index] != 0)
        AssetManager.UnloadAssetBundle(this.AssetKey[index]);
    }
    this.GM.CloseLoadingTalk_TBox();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 == 10)
    {
      if ((Object) this.TalkTextL != (Object) null && ((Behaviour) this.TalkTextL).enabled)
      {
        ((Behaviour) this.TalkTextL).enabled = false;
        ((Behaviour) this.TalkTextL).enabled = true;
      }
      if ((Object) this.TalkTextR != (Object) null && ((Behaviour) this.TalkTextR).enabled)
      {
        ((Behaviour) this.TalkTextR).enabled = false;
        ((Behaviour) this.TalkTextR).enabled = true;
      }
      if ((Object) this.SelectText1 != (Object) null && ((Behaviour) this.SelectText1).enabled)
      {
        ((Behaviour) this.SelectText1).enabled = false;
        ((Behaviour) this.SelectText1).enabled = true;
      }
      if (!((Object) this.SelectText2 != (Object) null) || !((Behaviour) this.SelectText2).enabled)
        return;
      ((Behaviour) this.SelectText2).enabled = false;
      ((Behaviour) this.SelectText2).enabled = true;
    }
    else
    {
      ++this.NowKey;
      for (LoadingTalk recordByKey = this.GM.LoadingTalkTable.GetRecordByKey(this.NowKey); recordByKey.ID != (ushort) 0 && recordByKey.Kind >= (byte) 3; recordByKey = this.GM.LoadingTalkTable.GetRecordByKey(this.NowKey))
        ++this.NowKey;
      this.LoadByKey(this.NowKey);
    }
  }

  private void Update()
  {
    if (!this.bLoadAllActor)
      this.SetActor();
    if (!this.bCheckWaitTime)
      return;
    if (this.bWaitSelect)
    {
      this.WaitSelectTime -= Time.deltaTime;
      if ((double) this.WaitSelectTime > 0.0)
        return;
      this.QuestBtn2.SetActive(true);
      uTweenScale uTweenScale = uTweenScale.Begin(this.QuestBtn2, Vector3.zero, Vector3.one, 1.3f);
      if ((bool) (Object) uTweenScale)
        uTweenScale.easeType = EaseType.easeOutBounce;
      AudioManager.Instance.PlayUISFX(UIKind.BuildUp);
      this.bWaitSelect = false;
      this.SelectCountTime = 3.5f;
      this.bSelectCount = false;
    }
    else
    {
      if (this.NowData.Kind == (byte) 2 && (double) this.SelectCountTime >= 0.0)
      {
        if (this.bSelectCount)
        {
          this.SelectCountTime2 -= Time.deltaTime;
          if ((double) this.SelectCountTime2 <= 0.0)
          {
            uTweenScale.Begin(this.QuestBtn2, new Vector3(1.1f, 1.1f, 1.1f), Vector3.one, 0.5f);
            this.bSelectCount = false;
            AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
          }
        }
        this.SelectCountTime -= Time.deltaTime;
        if ((double) this.SelectCountTime <= 0.0)
        {
          this.SelectCountTime = 3.5f;
          this.bSelectCount = true;
          this.SelectCountTime2 = 0.1f;
          uTweenScale.Begin(this.QuestBtn1, new Vector3(1.1f, 1.1f, 1.1f), Vector3.one, 0.5f);
          AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
        }
      }
      this.WaitTime -= Time.deltaTime;
      if ((double) this.WaitTime > 0.0)
        return;
      if (this.NowData.Kind == (byte) 2)
      {
        this.NowKey = this.NowData.TimeUpGotoID;
        AudioManager.Instance.PlayUISFX(UIKind.HeroEnhance);
      }
      else
      {
        ++this.NowKey;
        for (LoadingTalk recordByKey = this.GM.LoadingTalkTable.GetRecordByKey(this.NowKey); recordByKey.ID != (ushort) 0 && recordByKey.Kind >= (byte) 3; recordByKey = this.GM.LoadingTalkTable.GetRecordByKey(this.NowKey))
          ++this.NowKey;
      }
      this.LoadByKey(this.NowKey);
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    AudioManager.Instance.PlayUISFX(UIKind.HUDMsg);
    this.NowKey = (ushort) this.NowData.Select[sender.m_BtnID1 != 1 ? 1 : 0].GotoID;
    this.LoadByKey(this.NowKey);
  }

  private void LoadActor()
  {
    if (this.LoadActorIndex < (byte) 3)
    {
      if (this.LoadActorIndex == (byte) 0)
        this.AB[(int) this.LoadActorIndex] = AssetManager.GetAssetBundle("Role/hero_00001", out this.AssetKey[(int) this.LoadActorIndex]);
      else if (this.LoadActorIndex == (byte) 1)
        this.AB[(int) this.LoadActorIndex] = AssetManager.GetAssetBundle("Role/hero_00007", out this.AssetKey[(int) this.LoadActorIndex]);
      else if (this.LoadActorIndex == (byte) 2)
        this.AB[(int) this.LoadActorIndex] = AssetManager.GetAssetBundle("Role/hero_00009", out this.AssetKey[(int) this.LoadActorIndex]);
      this.AR[(int) this.LoadActorIndex] = this.AB[(int) this.LoadActorIndex].LoadAsync("m", typeof (GameObject));
    }
    else
    {
      this.bLoadAllActor = true;
      this.LoadByKey(this.NowKey);
    }
  }

  private void SetActor()
  {
    if (this.LoadActorIndex >= (byte) 3 || !this.AR[(int) this.LoadActorIndex].isDone)
      return;
    this.ActorGO[(int) this.LoadActorIndex] = (GameObject) Object.Instantiate(this.AR[(int) this.LoadActorIndex].asset);
    this.ActorGO[(int) this.LoadActorIndex].transform.SetParent(this.ActorT[(int) this.LoadActorIndex], false);
    this.ActorGO[(int) this.LoadActorIndex].transform.localPosition = Vector3.zero;
    this.ActorGO[(int) this.LoadActorIndex].transform.localRotation = new Quaternion(0.0f, -180f, 0.0f, 0.0f);
    this.ActorGO[(int) this.LoadActorIndex].transform.localScale = new Vector3(180f, 180f, 180f);
    GUIManager.Instance.SetLayer(this.ActorGO[(int) this.LoadActorIndex], 5);
    if ((Object) this.ActorGO[(int) this.LoadActorIndex] != (Object) null)
    {
      this.ActorAnimation[(int) this.LoadActorIndex] = this.ActorGO[(int) this.LoadActorIndex].GetComponent<Animation>();
      this.ActorAnimation[(int) this.LoadActorIndex].wrapMode = WrapMode.Loop;
      this.ActorAnimation[(int) this.LoadActorIndex].clip = this.ActorAnimation[(int) this.LoadActorIndex].GetClip("idle");
      this.ActorAnimation[(int) this.LoadActorIndex].Play("idle");
    }
    ++this.LoadActorIndex;
    this.LoadActor();
  }

  private void HideQuestBtn()
  {
    ((Transform) this.QuestBtnRC1).localScale = Vector3.zero;
    ((Transform) this.QuestBtnRC2).localScale = Vector3.zero;
    this.QuestBtn1.SetActive(false);
    this.QuestBtn2.SetActive(false);
    this.SelectCountTime = -1f;
  }

  private void LoadByKey(ushort Key)
  {
    this.NowData = this.GM.LoadingTalkTable.GetRecordByKey(Key);
    if (this.NowData.ID != (ushort) 0)
    {
      if (this.NowType != (eLoadingTalkType) this.NowData.TalkType)
      {
        switch (this.NowType)
        {
          case eLoadingTalkType.Knight3DL:
            this.BackT.gameObject.SetActive(false);
            this.ActorT[0].gameObject.SetActive(false);
            break;
          case eLoadingTalkType.Knight3DR:
            this.BackT.gameObject.SetActive(false);
            this.ActorT[1].gameObject.SetActive(false);
            break;
          case eLoadingTalkType.Knight3Dl2DR:
            this.BackT.gameObject.SetActive(false);
            this.ActorT[0].gameObject.SetActive(false);
            break;
          case eLoadingTalkType.Priest3D:
            this.BackT.gameObject.SetActive(false);
            this.ActorT[2].gameObject.SetActive(false);
            break;
          case eLoadingTalkType.GetKnight:
          case eLoadingTalkType.GetSecond:
          case eLoadingTalkType.GetCrystal:
            this.GM.CloseLoadingTalk_TBox();
            break;
        }
        this.NowType = (eLoadingTalkType) this.NowData.TalkType;
        switch (this.NowType)
        {
          case eLoadingTalkType.Knight3DL:
            this.BackT.gameObject.SetActive(true);
            this.ActorT[0].gameObject.SetActive(true);
            break;
          case eLoadingTalkType.Knight3DR:
            this.BackT.gameObject.SetActive(true);
            this.ActorT[1].gameObject.SetActive(true);
            break;
          case eLoadingTalkType.Knight3Dl2DR:
            this.BackT.gameObject.SetActive(true);
            this.ActorT[0].gameObject.SetActive(true);
            break;
          case eLoadingTalkType.Priest3D:
            this.BackT.gameObject.SetActive(true);
            this.ActorT[2].gameObject.SetActive(true);
            break;
          case eLoadingTalkType.GetKnight:
          case eLoadingTalkType.GetSecond:
          case eLoadingTalkType.GetCrystal:
            this.GM.OpenLoadingTalk_TBox((int) (byte) this.NowType - 1, 0);
            AudioManager.Instance.PlayUISFX(UIKind.DominanceLevelup);
            break;
        }
      }
      if (this.NowType == eLoadingTalkType.GetKnight || this.NowType == eLoadingTalkType.GetSecond || this.NowType == eLoadingTalkType.GetCrystal)
      {
        ((Component) this.NowTextRC).gameObject.SetActive(false);
        this.HideQuestBtn();
      }
      else
      {
        ((Component) this.NowTextRC).gameObject.SetActive(false);
        switch (this.NowData.TalkType)
        {
          case 1:
          case 3:
          case 6:
            this.NowText = this.TalkTextL;
            this.NowTextRC = this.TalkTextLRC;
            break;
          case 2:
          case 4:
          case 5:
            this.NowText = this.TalkTextR;
            this.NowTextRC = this.TalkTextRRC;
            break;
        }
        this.NowType = (eLoadingTalkType) this.NowData.TalkType;
        ((Component) this.NowTextRC).gameObject.SetActive(true);
        if (this.NowData.Kind == (byte) 2)
        {
          AudioManager.Instance.PlayUISFX(UIKind.BuildUp);
          this.QuestBtn1.SetActive(true);
          uTweenScale uTweenScale = uTweenScale.Begin(this.QuestBtn1, Vector3.zero, Vector3.one, 1.3f);
          if ((bool) (Object) uTweenScale)
            uTweenScale.easeType = EaseType.easeOutBounce;
          this.bWaitSelect = true;
          this.WaitSelectTime = 0.8f;
          this.NowText.text = this.DM.mStringTable.GetStringByID((uint) this.NowData.StringID);
          this.SelectText1.text = this.DM.mStringTable.GetStringByID((uint) this.NowData.Select[0].StringID);
          this.SelectText2.text = this.DM.mStringTable.GetStringByID((uint) this.NowData.Select[1].StringID);
          switch (this.NowData.TalkType)
          {
            case 1:
              this.NowTextRC.anchoredPosition = new Vector2(138.5f, 57.5f);
              this.QuestionRC.anchoredPosition = new Vector2(157.5f, -124.5f);
              break;
            case 3:
            case 6:
              this.NowTextRC.anchoredPosition = new Vector2(118.5f, 87.5f);
              this.QuestionRC.anchoredPosition = new Vector2(137.5f, -94.5f);
              break;
            case 4:
              this.NowTextRC.anchoredPosition = new Vector2(-116.5f, 87.5f);
              this.QuestionRC.anchoredPosition = new Vector2(-133.5f, -94.5f);
              break;
          }
        }
        else
        {
          this.HideQuestBtn();
          this.NowText.text = this.DM.mStringTable.GetStringByID((uint) this.NowData.StringID);
          switch (this.NowData.TalkType)
          {
            case 1:
              this.NowTextRC.anchoredPosition = new Vector2(143.5f, -19.5f);
              break;
            case 2:
            case 5:
              this.NowTextRC.anchoredPosition = new Vector2(-69.5f, 184.5f);
              break;
            case 3:
            case 6:
              this.NowTextRC.anchoredPosition = new Vector2(118.5f, 87.5f);
              break;
            case 4:
              this.NowTextRC.anchoredPosition = new Vector2(-116.5f, 87.5f);
              break;
          }
        }
      }
      this.WaitTime = (float) this.NowData.WaitTime;
      if ((int) Key == this.GM.LoadingTalkTable.TableCount)
        this.bCheckWaitTime = false;
      else
        this.bCheckWaitTime = true;
    }
    else
      this.bCheckWaitTime = false;
  }
}
