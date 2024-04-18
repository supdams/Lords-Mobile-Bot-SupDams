// Decompiled with JetBrains decompiler
// Type: UISettlement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UISettlement : 
  GUIWindow,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private const byte RewardNum = 10;
  private Transform m_transform;
  private GUIManager GM = GUIManager.Instance;
  private DataManager DM = DataManager.Instance;
  private ArenaManager AM = ArenaManager.Instance;
  private StageManager DS = DataManager.StageDataController;
  private AssetBundle[] AB = new AssetBundle[5];
  private AssetBundleRequest[] AR = new AssetBundleRequest[5];
  private bool[] bABInitial = new bool[5];
  private int[] AssetKey = new int[5];
  private GameObject[] PlayerGO = new GameObject[5];
  private Transform[] RewardBtnT = new Transform[7];
  private Transform LightT;
  private byte LoadHeroCount;
  private byte RewardCount;
  private sRewardData[] RewardArray = new sRewardData[10];
  private int OpenKind;
  private byte ActorNum;
  private bool bHideItem;
  private byte HeroCount;
  private UISpritesArray SArray;
  private byte NowStep;
  private float LVUPFadeTime = 1.6f;
  private float LVUPMoveTime = 1.2f;
  private float LvUPPos = 138f;
  private float LvUPMoveDelta = 280f;
  private byte[] LvUPMove = new byte[5];
  private float[] LvUPMoveSpeed = new float[5];
  private float[] LvUPMoveSpeed2 = new float[5];
  private float[] LvUPPlayTime = new float[5]
  {
    -1f,
    -1f,
    -1f,
    -1f,
    -1f
  };
  private float[] LvUPPlayPos = new float[5]
  {
    -1f,
    -1f,
    -1f,
    -1f,
    -1f
  };
  private float[] EndY = new float[5]
  {
    -1f,
    -1f,
    -1f,
    -1f,
    -1f
  };
  private Image[] MoveImage = new Image[5];
  private Image[] FadeImage = new Image[5];
  private Transform[] LVUPT = new Transform[5];
  private UIText[] LVUPText2 = new UIText[5];
  private Outline[] LVUPOutline = new Outline[5];
  private Shadow[] LVUPShadow = new Shadow[5];
  public float PageMoveSpeed;
  public float colorA;
  private int TipCount = 2;
  private int TipTotalCount = 9;
  private ushort[] TipTitleID = new ushort[9]
  {
    (ushort) 1545,
    (ushort) 1547,
    (ushort) 1549,
    (ushort) 1551,
    (ushort) 1553,
    (ushort) 1585,
    (ushort) 1587,
    (ushort) 3647,
    (ushort) 3645
  };
  private ushort[] TipID = new ushort[9]
  {
    (ushort) 1546,
    (ushort) 1548,
    (ushort) 1550,
    (ushort) 1552,
    (ushort) 1554,
    (ushort) 1586,
    (ushort) 1588,
    (ushort) 3648,
    (ushort) 3646
  };
  private int[] RandomList = new int[9]
  {
    0,
    1,
    -1,
    -1,
    -1,
    -1,
    -1,
    -1,
    -1
  };
  private int RandomIndex = -1;
  private int PlayIndex = -1;
  private float PlayTime;
  private float PlayWaitTime;
  private RectTransform[] HintRC = new RectTransform[3];
  private Image m_HintBox;
  private UIText m_HintText;
  private byte bHintOpen;
  private float HintTime;
  private UIText[] RBText = new UIText[7];
  private UIText[] RBLvText = new UIText[5];
  private UIHIBtn[] RBRewardBtn;
  private UIText RankText;
  private CString RankStr;
  private CString GetEXPStr;
  private CString GetMoneyStr;
  private CString ConditionStr;
  private CString[] LVStr = new CString[5];
  private CString[] ExpStr = new CString[5];
  private bool bArena;
  private bool bChallenge;
  private bool bSendServer;
  private ushort ConditionKey;
  private float MoveBeginPos = -29f;
  private float MoveEndPos = -129f;
  private int ConditionCount;
  private int NowMoveIndex = -1;
  private float PlayTotalTime = 0.3f;
  private RectTransform[] ConditionRC = new RectTransform[8];
  private UIButton[] ConditionBtn = new UIButton[8];
  private Image[] ConditionBackImg = new Image[8];
  private Image[] ConditionImg = new Image[8];
  private Image[] ConditionCheckImg = new Image[8];
  private CString HinString;

  public override void OnOpen(int arg1, int arg2)
  {
    // ISSUE: unable to decompile the method.
  }

  public override void OnClose()
  {
    Camera.main.cullingMask |= 1;
    Camera.main.orthographic = false;
    this.GM.SetCanvasChanged();
    if (this.RankStr != null)
      StringManager.Instance.DeSpawnString(this.RankStr);
    if (this.GetEXPStr != null)
      StringManager.Instance.DeSpawnString(this.GetEXPStr);
    if (this.GetMoneyStr != null)
      StringManager.Instance.DeSpawnString(this.GetMoneyStr);
    for (int index = 0; index < this.LVStr.Length; ++index)
    {
      if (this.LVStr[index] != null)
        StringManager.Instance.DeSpawnString(this.LVStr[index]);
    }
    for (int index = 0; index < this.ExpStr.Length; ++index)
    {
      if (this.ExpStr[index] != null)
        StringManager.Instance.DeSpawnString(this.ExpStr[index]);
    }
    if (this.ConditionStr != null)
      StringManager.Instance.DeSpawnString(this.ConditionStr);
    if (DataManager.StageDataController._stageMode == StageMode.Dare)
      GUIManager.Instance.CloseMenu(EGUIWindow.UI_ChallegeTreasure);
    if (this.HinString == null)
      return;
    StringManager.Instance.DeSpawnString(this.HinString);
    this.HinString = (CString) null;
  }

  public void onFinisf1() => AudioManager.Instance.PlayUISFX(UIKind.StartThree_One);

  public void onFinisf2() => AudioManager.Instance.PlayUISFX(UIKind.StartThree_Two);

  public void onFinisf3() => AudioManager.Instance.PlayUISFX(UIKind.StartThree_Three);

  private void PlayStar(int tmpIndex)
  {
    this.m_transform.GetChild(tmpIndex).gameObject.SetActive(true);
    uTweenScale uTweenScale = uTweenScale.Begin(this.m_transform.GetChild(tmpIndex).gameObject, new Vector3(2.7f, 2.7f, 2.7f), Vector3.one, 0.3f);
    if (!(bool) (UnityEngine.Object) uTweenScale)
      return;
    uTweenScale.easeType = EaseType.easeInQuart;
    switch (tmpIndex)
    {
      case 12:
        uTweenScale.onFinished = new UnityEvent();
        // ISSUE: method pointer
        uTweenScale.onFinished.AddListener(new UnityAction((object) this, __methodptr(\u003CPlayStar\u003Em__E9)));
        break;
      case 13:
        uTweenScale.onFinished = new UnityEvent();
        // ISSUE: method pointer
        uTweenScale.onFinished.AddListener(new UnityAction((object) this, __methodptr(\u003CPlayStar\u003Em__EA)));
        break;
      case 14:
        uTweenScale.onFinished = new UnityEvent();
        // ISSUE: method pointer
        uTweenScale.onFinished.AddListener(new UnityAction((object) this, __methodptr(\u003CPlayStar\u003Em__EB)));
        break;
    }
  }

  private void Update()
  {
    if ((UnityEngine.Object) this.LightT != (UnityEngine.Object) null)
      this.LightT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    if (this.bChallenge)
    {
      if (this.OpenKind != 0)
      {
        if (this.PlayIndex != -1)
        {
          if (this.PlayIndex == 0)
          {
            this.PlayTime += Time.smoothDeltaTime;
            if ((double) this.PlayTime < 0.20000000298023224)
              return;
            this.PlayTime = 0.0f;
            ++this.PlayIndex;
            return;
          }
          if (this.PlayIndex == 1)
          {
            if (this.NowMoveIndex >= 8)
            {
              this.PlayTime = 0.0f;
              ++this.PlayIndex;
              return;
            }
            if ((UnityEngine.Object) this.ConditionRC[0] == (UnityEngine.Object) null)
              return;
            float t = this.PlayTime / this.PlayTotalTime;
            this.ConditionRC[this.NowMoveIndex].anchoredPosition = new Vector2(this.ConditionRC[this.NowMoveIndex].anchoredPosition.x, Mathf.Lerp(this.MoveBeginPos, this.MoveEndPos, t));
            Color color = new Color(1f, 1f, 1f, Mathf.Lerp(0.0f, 1f, t));
            ((Graphic) this.ConditionBackImg[this.NowMoveIndex]).color = color;
            ((Graphic) this.ConditionImg[this.NowMoveIndex]).color = color;
            this.PlayTime += Time.smoothDeltaTime;
            if ((double) this.PlayTime < (double) this.PlayTotalTime)
              return;
            AudioManager.Instance.PlayUISFX(UIKind.UIPrompt);
            this.ConditionRC[this.NowMoveIndex].anchoredPosition = new Vector2(this.ConditionRC[this.NowMoveIndex].anchoredPosition.x, this.MoveEndPos);
            ((Graphic) this.ConditionBackImg[this.NowMoveIndex]).color = Color.white;
            ((Graphic) this.ConditionImg[this.NowMoveIndex]).color = Color.white;
            ((Behaviour) this.ConditionCheckImg[this.NowMoveIndex]).enabled = true;
            ++this.NowMoveIndex;
            if (this.NowMoveIndex >= this.ConditionCount)
            {
              this.PlayTime = 0.0f;
              ++this.PlayIndex;
              return;
            }
            this.PlayTime = 0.0f;
            return;
          }
          if (this.PlayIndex == 2)
          {
            for (byte index = 0; (int) index < (int) this.HeroCount; ++index)
            {
              ushort heroId = this.DM.heroBattleData[(int) index].HeroID;
              if (this.DM.curHeroData.ContainsKey((uint) heroId))
              {
                Hero recordByKey = this.DM.HeroTable.GetRecordByKey(heroId);
                CString Name = StringManager.Instance.StaticString1024();
                Name.ClearString();
                Name.IntToFormat((long) recordByKey.Modle, 5);
                Name.AppendFormat("Role/hero_{0}");
                this.AB[(int) index] = AssetManager.GetAssetBundle(Name, out this.AssetKey[(int) index]);
                this.AR[(int) index] = this.AB[(int) index].LoadAsync("m", typeof (GameObject));
                this.bABInitial[(int) index] = false;
              }
            }
            ++this.PlayIndex;
            return;
          }
          if (this.PlayIndex == 3)
          {
            if ((int) this.LoadHeroCount < (int) this.HeroCount)
            {
              int num1 = 59;
              for (byte index = 0; (int) index < (int) this.HeroCount; ++index)
              {
                if (!this.bABInitial[(int) index] && this.AR[(int) index] != null && this.AR[(int) index].isDone)
                {
                  Hero recordByKey = this.DM.HeroTable.GetRecordByKey(this.DM.heroBattleData[(int) index].HeroID);
                  GameObject go = (GameObject) UnityEngine.Object.Instantiate(this.AR[(int) index].asset);
                  go.transform.SetParent(this.m_transform.GetChild(num1 + (int) index), false);
                  go.transform.localPosition = Vector3.zero;
                  go.transform.localRotation = new Quaternion(0.0f, -180f, 0.0f, 0.0f);
                  float num2 = (float) (125.0 * (double) recordByKey.Scale * 0.0099999997764825821);
                  go.transform.localScale = new Vector3(num2, num2, num2);
                  this.GM.SetLayer(go, 5);
                  if ((UnityEngine.Object) go != (UnityEngine.Object) null)
                  {
                    Animation component = go.GetComponent<Animation>();
                    component.wrapMode = WrapMode.Loop;
                    component.Play("victory");
                    go.GetComponentInChildren<SkinnedMeshRenderer>().useLightProbes = false;
                    this.PlayerGO[(int) index] = go;
                  }
                  this.bABInitial[(int) index] = true;
                  ++this.LoadHeroCount;
                }
              }
              return;
            }
            ++this.PlayIndex;
            return;
          }
          if (this.PlayIndex == 4)
          {
            this.PlayTime += Time.smoothDeltaTime;
            if ((double) this.PlayTime < 1.0)
              return;
            this.PlayTime = 0.0f;
            ++this.PlayIndex;
            return;
          }
          this.PlayIndex = -1;
          return;
        }
        if (this.NowStep == (byte) 0)
        {
          this.NowStep = (byte) 1;
          this.m_transform.GetChild(30).gameObject.SetActive(true);
          this.GM.OpenChallegeRewardUI();
        }
      }
    }
    else
    {
      if (this.OpenKind != 0 && this.PlayIndex != -1)
      {
        this.PlayTime += Time.smoothDeltaTime;
        if ((double) this.PlayTime < (double) this.PlayWaitTime)
          return;
        this.PlayTime = 0.0f;
        if (this.PlayIndex == 0)
        {
          this.PlayWaitTime = 0.1f;
          this.m_transform.GetChild(37).gameObject.SetActive(true);
          ++this.PlayIndex;
          return;
        }
        if (this.PlayIndex == 1)
        {
          this.PlayWaitTime = 0.2f;
          ++this.PlayIndex;
          return;
        }
        if (this.PlayIndex == 3 || this.PlayIndex == 5)
        {
          this.PlayWaitTime = 0.05f;
          ++this.PlayIndex;
          return;
        }
        if (this.PlayIndex == 2)
        {
          if (this.OpenKind == 1)
          {
            this.PlayIndex = 7;
            this.PlayWaitTime = 0.35f;
          }
          else
          {
            ++this.PlayIndex;
            this.PlayWaitTime = 0.3f;
          }
          this.PlayStar(12);
          return;
        }
        if (this.PlayIndex == 4)
        {
          if (this.OpenKind == 2)
          {
            this.PlayIndex = 7;
            this.PlayWaitTime = 0.35f;
          }
          else
          {
            ++this.PlayIndex;
            this.PlayWaitTime = 0.3f;
          }
          this.PlayStar(13);
          return;
        }
        if (this.PlayIndex == 6)
        {
          this.PlayIndex = 7;
          this.PlayWaitTime = 0.35f;
          this.PlayStar(14);
          return;
        }
        if (this.PlayIndex == 7)
        {
          AudioManager.Instance.LoadAndPlayBGM(BGMType.WarVictory, (byte) 0);
          this.PlayWaitTime = 0.2f;
          ++this.PlayIndex;
          return;
        }
        Font ttfFont = this.GM.GetTTFFont();
        if (!this.bHideItem)
        {
          for (int index = 15; index <= 21; ++index)
            this.m_transform.GetChild(index).gameObject.SetActive(true);
          this.m_transform.GetChild(38).gameObject.SetActive(true);
          this.m_transform.GetChild(40).gameObject.SetActive(true);
          this.m_transform.GetChild(41).gameObject.SetActive(true);
          this.m_transform.GetChild(42).gameObject.SetActive(true);
          this.m_transform.GetChild(30).gameObject.SetActive(true);
          if ((int) BattleNetwork.battlePointID % (int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode] == 0)
            this.m_transform.GetChild(29).gameObject.SetActive(true);
          int num = 22;
          for (int index = 0; index < 6; ++index)
          {
            this.RewardBtnT[index] = this.m_transform.GetChild(num + index);
            this.RewardBtnT[index].GetComponent<UIHIBtn>().m_Handler = (IUIHIBtnClickHandler) this;
          }
          this.SetReward();
          this.RBRewardBtn = new UIHIBtn[(int) this.RewardCount];
          if (this.RewardCount > (byte) 6)
          {
            Transform child1 = this.m_transform.GetChild(36);
            UIButtonHint.m_scrollRect = child1.GetComponent<ScrollRect>();
            child1.gameObject.SetActive(true);
            Transform child2 = child1.GetChild(0);
            RectTransform component = child2.GetComponent<RectTransform>();
            component.sizeDelta = new Vector2((float) (93 * (int) this.RewardCount - 13), component.sizeDelta.y);
            for (ushort index = 0; (int) index < (int) this.RewardCount; ++index)
            {
              this.GM.InitianHeroItemImg(child2.GetChild((int) index), eHeroOrItem.Item, this.RewardArray[(int) index].ID, (byte) 0, (byte) 0, (int) this.RewardArray[(int) index].count);
              this.RBRewardBtn[(int) index] = child2.GetChild((int) index).GetComponent<UIHIBtn>();
              child2.GetChild((int) index).GetComponent<UIHIBtn>().m_Handler = (IUIHIBtnClickHandler) this;
            }
            for (int rewardCount = (int) this.RewardCount; rewardCount < 10; ++rewardCount)
              child2.GetChild(rewardCount).gameObject.SetActive(false);
          }
          else
          {
            for (ushort index = 0; (int) index < (int) this.RewardCount; ++index)
            {
              Transform child = this.m_transform.GetChild(22 + (int) index);
              this.GM.InitianHeroItemImg(child, eHeroOrItem.Item, this.RewardArray[(int) index].ID, (byte) 0, (byte) 0, (int) this.RewardArray[(int) index].count);
              this.RBRewardBtn[(int) index] = child.GetComponent<UIHIBtn>();
              child.GetComponent<UIHIBtn>().m_Handler = (IUIHIBtnClickHandler) this;
              child.gameObject.SetActive(true);
            }
          }
          if (this.RewardCount == (byte) 0)
          {
            this.RBText[5] = this.m_transform.GetChild(39).GetComponent<UIText>();
            this.RBText[5].text = this.DM.mStringTable.GetStringByID(1598U);
            this.RBText[5].font = ttfFont;
            ((Component) this.RBText[5]).gameObject.SetActive(true);
          }
        }
        else
        {
          this.m_transform.GetChild(19).gameObject.SetActive(true);
          this.m_transform.GetChild(20).gameObject.SetActive(true);
          this.m_transform.GetChild(40).gameObject.SetActive(true);
          this.m_transform.GetChild(41).gameObject.SetActive(true);
          this.m_transform.GetChild(30).gameObject.SetActive(true);
          this.RankStr = StringManager.Instance.SpawnString();
          StringManager.IntToStr(this.RankStr, (long) this.AM.ArenaPlayingData.ChangePlace);
          this.RankText = this.m_transform.GetChild(69).GetChild(0).GetComponent<UIText>();
          this.RankText.font = ttfFont;
          this.RankText.text = this.RankStr.ToString();
          this.m_transform.GetChild(69).gameObject.SetActive(true);
        }
        for (byte index = 0; (int) index < (int) this.HeroCount; ++index)
        {
          ushort num = !this.bHideItem ? this.DM.heroBattleData[(int) index].HeroID : this.AM.ArenaPlayingData.MyHeroData[(int) index].ID;
          if (this.DM.curHeroData.ContainsKey((uint) num))
          {
            Hero recordByKey = this.DM.HeroTable.GetRecordByKey(num);
            CString Name = StringManager.Instance.StaticString1024();
            Name.ClearString();
            Name.IntToFormat((long) recordByKey.Modle, 5);
            Name.AppendFormat("Role/hero_{0}");
            this.AB[(int) index] = AssetManager.GetAssetBundle(Name, out this.AssetKey[(int) index]);
            this.AR[(int) index] = this.AB[(int) index].LoadAsync("m", typeof (GameObject));
            this.bABInitial[(int) index] = false;
            this.LVStr[(int) index] = StringManager.Instance.SpawnString();
            this.LVStr[(int) index].Length = 0;
            this.LVStr[(int) index].IntToFormat((long) this.DM.curHeroData[(uint) num].Level);
            this.LVStr[(int) index].AppendFormat(this.DM.mStringTable.GetStringByID(53U));
            Transform child3 = this.m_transform.GetChild(48 + (int) index);
            this.RBLvText[(int) index] = child3.GetComponent<UIText>();
            this.RBLvText[(int) index].text = this.LVStr[(int) index].ToString();
            this.RBLvText[(int) index].font = ttfFont;
            child3.gameObject.SetActive(true);
            if ((int) this.DM.heroLv[(int) index] < (int) this.DM.curHeroData[(uint) num].Level)
            {
              this.LVUPT[(int) index] = this.m_transform.GetChild(53 + (int) index);
              this.LVUPT[(int) index].gameObject.SetActive(true);
              this.LVUPShadow[(int) index] = this.LVUPT[(int) index].GetComponent<Shadow>();
              this.LVUPShadow[(int) index].effectColor = new Color(this.LVUPShadow[(int) index].effectColor.r, this.LVUPShadow[(int) index].effectColor.g, this.LVUPShadow[(int) index].effectColor.b, 0.0f);
              this.LVUPOutline[(int) index] = this.LVUPT[(int) index].GetComponent<Outline>();
              ((Shadow) this.LVUPOutline[(int) index]).effectColor = new Color(((Shadow) this.LVUPOutline[(int) index]).effectColor.r, ((Shadow) this.LVUPOutline[(int) index]).effectColor.g, ((Shadow) this.LVUPOutline[(int) index]).effectColor.b, 0.0f);
              this.LVUPText2[(int) index] = this.LVUPT[(int) index].GetComponent<UIText>();
              ((Graphic) this.LVUPText2[(int) index]).color = new Color(((Graphic) this.LVUPText2[(int) index]).color.r, ((Graphic) this.LVUPText2[(int) index]).color.g, ((Graphic) this.LVUPText2[(int) index]).color.b, 0.0f);
              this.LVUPText2[(int) index].text = this.DM.mStringTable.GetStringByID(1555U);
              this.LVUPText2[(int) index].font = ttfFont;
              this.EndY[(int) index] = this.LVUPT[(int) index].localPosition.y - 10f;
              this.LvUPMove[(int) index] = (byte) 1;
              this.LvUPPlayTime[(int) index] = this.LVUPFadeTime;
              this.LVUPT[(int) index].localPosition = new Vector3(this.LVUPT[(int) index].localPosition.x, this.LVUPT[(int) index].localPosition.y + 200f, this.LVUPT[(int) index].localPosition.z - 252f);
            }
            uint exp = this.GetExp(true, this.DM.curHeroData[(uint) num].Level, this.DM.curHeroData[(uint) num].Exp, this.DM.heroLv[(int) index], this.DM.heroExp[(int) index]);
            this.ExpStr[(int) index] = StringManager.Instance.SpawnString();
            this.ExpStr[(int) index].Length = 0;
            this.ExpStr[(int) index].IntToFormat((long) exp, bNumber: true);
            this.ExpStr[(int) index].AppendFormat(this.DM.mStringTable.GetStringByID(55U));
            Transform child4 = this.m_transform.GetChild(43 + (int) index);
            child4.GetComponent<UIText>().text = this.ExpStr[(int) index].ToString();
            this.RBText[6] = child4.GetComponent<UIText>();
            this.RBText[6].text = this.ExpStr[(int) index].ToString();
            this.RBText[6].font = ttfFont;
            this.RBText[6].resizeTextForBestFit = true;
            this.RBText[6].resizeTextMaxSize = 24;
            child4.gameObject.SetActive(true);
            Transform child5 = this.m_transform.GetChild(31 + (int) index);
            child5.GetComponent<Slider>().value = (float) this.DM.curHeroData[(uint) num].Exp / (float) this.DM.LevelUpTable.GetRecordByKey((ushort) this.DM.curHeroData[(uint) num].Level).HeroExp;
            child5.gameObject.SetActive(true);
            this.FadeImage[(int) index] = child5.GetChild(1).GetComponent<Image>();
            this.MoveImage[(int) index] = child5.GetChild(2).GetComponent<Image>();
            ((Transform) ((Graphic) this.MoveImage[(int) index]).rectTransform).localScale = new Vector3(1f, 1.5f, 1f);
            this.LvUPPos = ((Transform) ((Graphic) this.MoveImage[(int) index]).rectTransform).localPosition.y + 75f;
            ++this.ActorNum;
          }
        }
        this.PlayIndex = -1;
        return;
      }
      if (this.OpenKind != 0 && (int) this.LoadHeroCount < (int) this.HeroCount)
      {
        int num3 = 59;
        for (byte index = 0; (int) index < (int) this.HeroCount; ++index)
        {
          if (!this.bABInitial[(int) index] && this.AR[(int) index] != null && this.AR[(int) index].isDone)
          {
            Hero recordByKey = this.DM.HeroTable.GetRecordByKey(!this.bHideItem ? this.DM.heroBattleData[(int) index].HeroID : this.AM.ArenaPlayingData.MyHeroData[(int) index].ID);
            GameObject go = (GameObject) UnityEngine.Object.Instantiate(this.AR[(int) index].asset);
            go.transform.SetParent(this.m_transform.GetChild(num3 + (int) index), false);
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = new Quaternion(0.0f, -180f, 0.0f, 0.0f);
            float num4 = (float) (125.0 * (double) recordByKey.Scale * 0.0099999997764825821);
            go.transform.localScale = new Vector3(num4, num4, num4);
            this.GM.SetLayer(go, 5);
            if ((UnityEngine.Object) go != (UnityEngine.Object) null)
            {
              Animation component = go.GetComponent<Animation>();
              component.wrapMode = WrapMode.Loop;
              component.Play("victory");
              go.GetComponentInChildren<SkinnedMeshRenderer>().useLightProbes = false;
              this.PlayerGO[(int) index] = go;
            }
            this.bABInitial[(int) index] = true;
            ++this.LoadHeroCount;
            if ((double) this.EndY[(int) index] != -1.0)
              AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
          }
        }
      }
      bool flag = false;
      float smoothDeltaTime = Time.smoothDeltaTime;
      for (int i = 0; i < (int) this.HeroCount; ++i)
      {
        if (this.bABInitial[i])
        {
          if ((double) this.EndY[i] != -1.0)
          {
            flag = true;
            if ((double) Math.Abs(this.LVUPT[i].localPosition.y - this.EndY[i]) < 1.0)
            {
              this.EndY[i] = -1f;
            }
            else
            {
              Vector3 localPosition = this.LVUPT[i].localPosition;
              localPosition[1] = Mathf.SmoothDamp(localPosition.y, this.EndY[i], ref this.PageMoveSpeed, 0.135f, float.PositiveInfinity, smoothDeltaTime);
              this.LVUPT[i].localPosition = localPosition;
              if ((double) Mathf.Abs(Mathf.Abs(localPosition[0]) - Mathf.Abs(this.EndY[i])) <= 1.0)
                this.EndY[i] = -1f;
            }
            this.colorA += smoothDeltaTime;
            if ((double) this.colorA >= 1.0 || (double) this.EndY[i] == -1.0)
              this.colorA = 1f;
            this.LVUPShadow[i].effectColor = new Color(this.LVUPShadow[i].effectColor.r, this.LVUPShadow[i].effectColor.g, this.LVUPShadow[i].effectColor.b, this.colorA);
            ((Shadow) this.LVUPOutline[i]).effectColor = new Color(((Shadow) this.LVUPOutline[i]).effectColor.r, ((Shadow) this.LVUPOutline[i]).effectColor.g, ((Shadow) this.LVUPOutline[i]).effectColor.b, this.colorA);
            ((Graphic) this.LVUPText2[i]).color = new Color(((Graphic) this.LVUPText2[i]).color.r, ((Graphic) this.LVUPText2[i]).color.g, ((Graphic) this.LVUPText2[i]).color.b, this.colorA);
          }
          if (this.LvUPMove[i] == (byte) 1)
          {
            flag = true;
            if (!((Component) this.FadeImage[i]).gameObject.activeInHierarchy)
              ((Component) this.FadeImage[i]).gameObject.SetActive(true);
            if (!((Component) this.MoveImage[i]).gameObject.activeInHierarchy)
              ((Component) this.MoveImage[i]).gameObject.SetActive(true);
            this.LvUPPlayTime[i] -= smoothDeltaTime;
            float num5 = this.LVUPFadeTime * 0.5f;
            float num6 = (float) (1.0 / (double) this.LVUPFadeTime * 2.0);
            if ((double) this.LvUPPlayTime[i] >= (double) num5)
            {
              this.LvUPMoveSpeed[i] += smoothDeltaTime;
              Color color = ((Graphic) this.FadeImage[i]).color with
              {
                a = Mathf.Lerp(0.0f, 1f, this.LvUPMoveSpeed[i] * num6)
              };
              ((Graphic) this.FadeImage[i]).color = color;
            }
            else if ((double) this.LvUPPlayTime[i] < (double) num5 && (double) this.LvUPPlayTime[i] >= 0.0)
            {
              this.LvUPMoveSpeed[i] += smoothDeltaTime;
              Color color = ((Graphic) this.FadeImage[i]).color with
              {
                a = 1f - Mathf.Lerp(0.0f, 1f, (float) ((double) this.LvUPMoveSpeed[i] * (double) num6 - 1.0))
              };
              ((Graphic) this.FadeImage[i]).color = color;
            }
            this.LvUPMoveSpeed2[i] += smoothDeltaTime;
            float num7 = this.LVUPMoveTime * 0.5f;
            float num8 = 1f / this.LVUPMoveTime;
            if ((double) this.LvUPPlayTime[i] >= (double) this.LVUPFadeTime - (double) num7)
            {
              Color color = ((Graphic) this.MoveImage[i]).color with
              {
                a = Mathf.Lerp(0.0f, 1f, (float) ((double) this.LvUPMoveSpeed2[i] * (double) num8 * 2.0))
              };
              ((Graphic) this.MoveImage[i]).color = color;
            }
            else if ((double) this.LvUPPlayTime[i] < (double) this.LVUPFadeTime - (double) num7 && (double) this.LvUPPlayTime[i] >= (double) this.LVUPFadeTime - (double) this.LVUPMoveTime)
            {
              Color color = ((Graphic) this.MoveImage[i]).color with
              {
                a = 1f - Mathf.Lerp(0.0f, 1f, (float) ((double) this.LvUPMoveSpeed2[i] * (double) num8 * 2.0 - 1.0))
              };
              ((Graphic) this.MoveImage[i]).color = color;
            }
            if ((double) this.LvUPPlayTime[i] >= (double) this.LVUPFadeTime - (double) this.LVUPMoveTime)
            {
              Vector3 localPosition = ((Transform) ((Graphic) this.MoveImage[i]).rectTransform).localPosition with
              {
                y = this.LvUPPos + Mathf.Lerp(0.0f, 1f, this.LvUPMoveSpeed2[i] * num8) * this.LvUPMoveDelta
              };
              ((Transform) ((Graphic) this.MoveImage[i]).rectTransform).localPosition = localPosition;
            }
            if ((double) this.LvUPPlayTime[i] <= 0.0)
              this.LVUPIniTial(i);
          }
        }
      }
      if (this.OpenKind != 0 && this.NowStep == (byte) 0 && !flag && (int) this.LoadHeroCount == (int) this.HeroCount && (int) this.DM.RoleAttr.Level >= (int) this.DM.KingOldLv + 1)
        this.NowStep = (byte) 1;
    }
    if (this.bHintOpen <= (byte) 0)
      return;
    this.SetHint();
  }

  private void LVUPIniTial(int i)
  {
    this.LvUPMove[i] = (byte) 0;
    this.LvUPPlayTime[i] = -1f;
    Color color1 = ((Graphic) this.FadeImage[i]).color with
    {
      a = 0.0f
    };
    ((Graphic) this.FadeImage[i]).color = color1;
    ((Component) this.FadeImage[i]).gameObject.SetActive(false);
    Color color2 = ((Graphic) this.MoveImage[i]).color with
    {
      a = 0.0f
    };
    ((Graphic) this.MoveImage[i]).color = color2;
    ((Component) this.MoveImage[i]).gameObject.SetActive(false);
    Vector3 localPosition = ((Transform) ((Graphic) this.MoveImage[i]).rectTransform).localPosition with
    {
      y = this.LvUPPos
    };
    ((Transform) ((Graphic) this.MoveImage[i]).rectTransform).localPosition = localPosition;
    this.LvUPMoveSpeed[i] = 0.0f;
    this.LvUPMoveSpeed2[i] = 0.0f;
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    if (sender.m_BtnID1 == 2 || sender.m_BtnID1 != 3)
      ;
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 != 1 || sender.m_BtnID2 == 1)
      return;
    if (sender.m_BtnID2 == 2)
    {
      if (DataManager.StageDataController._stageMode != StageMode.Dare)
      {
        DataManager instance = DataManager.Instance;
        if (DataManager.StageDataController._stageMode == StageMode.Lean)
        {
          VIP_DataTbl recordByKey = DataManager.Instance.VIPLevelTable.GetRecordByKey((ushort) DataManager.Instance.RoleAttr.VIPLevel);
          int num = (int) DataManager.StageDataController.StageInfo[1][(int) BattleNetwork.battlePointID - 1] >> 2 & 63;
          if (recordByKey.DailyResetElite != byte.MaxValue && num >= (int) recordByKey.DailyResetElite)
          {
            this.GM.AddHUDMessage(instance.mStringTable.GetStringByID(1599U), (ushort) byte.MaxValue);
            return;
          }
        }
        int num1 = (int) DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort) DataManager.StageDataController.currentChapterID).Power * (DataManager.StageDataController._stageMode != StageMode.Lean ? 1 : 2);
        if ((int) instance.RoleAttr.Morale < num1)
        {
          this.GM.UseOrSpend((ushort) 1115, instance.mStringTable.GetStringByID(1505U), (ushort) 0, (ushort) 0, (ushort) 0, maxcount: (ushort) 0);
          return;
        }
      }
      if (this.bSendServer)
      {
        BattleNetwork.bReplay = true;
        BattleNetwork.sendInitBattle();
      }
      else
      {
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleReplay_Dare);
        AudioManager.Instance.LoadAndPlayBGM(BGMType.War, (byte) 1);
      }
      this.GM.ShowChatBox();
    }
    else if (sender.m_BtnID2 == 3)
    {
      this.CloseFunc();
    }
    else
    {
      if (sender.m_BtnID2 != 4 || this.RandomIndex >= 5)
        return;
      this.GM.RandomIndex = this.RandomIndex;
      this.CloseFunc();
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    if ((UnityEngine.Object) button == (UnityEngine.Object) null)
      return;
    if (button.m_BtnID1 == 10)
    {
      if (this.NowStep != (byte) 1)
        return;
      this.DS.GetStageConditionString(this.HinString, (byte) button.m_BtnID2, (ushort) button.m_BtnID3, (ushort) button.m_BtnID4, this.ConditionKey);
      this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 280f, 20, this.HinString, Vector2.zero);
    }
    else
    {
      if (button.m_BtnID1 < 0 || button.m_BtnID1 > 3)
        return;
      this.bHintOpen = (byte) button.m_BtnID1;
      Vector2 anchoredPosition = this.HintRC[(int) this.bHintOpen - 1].anchoredPosition;
      anchoredPosition.y += 50f;
      ((Graphic) this.m_HintBox).rectTransform.anchoredPosition = anchoredPosition;
      ((Component) this.m_HintBox).gameObject.SetActive(true);
      this.HintTime = 2f;
      this.SetHint();
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    if ((UnityEngine.Object) button == (UnityEngine.Object) null)
      return;
    if (button.m_BtnID1 == 10)
    {
      this.GM.m_Hint.Hide();
    }
    else
    {
      ((Component) this.m_HintBox).gameObject.SetActive(false);
      this.bHintOpen = (byte) 0;
    }
  }

  private void SetHint()
  {
    this.HintTime += Time.deltaTime;
    if ((double) this.HintTime < 1.0)
      return;
    this.HintTime = 0.0f;
    if (this.bHintOpen == (byte) 1)
      this.m_HintText.text = this.DM.mStringTable.GetStringByID(1517U);
    else if (this.bHintOpen == (byte) 2)
      this.m_HintText.text = this.DM.mStringTable.GetStringByID(1518U);
    else if (this.bHintOpen == (byte) 3)
      this.m_HintText.text = this.DM.mStringTable.GetStringByID(1580U);
    ((Graphic) this.m_HintBox).rectTransform.sizeDelta = new Vector2(350f, this.m_HintText.preferredHeight + 31f);
    if ((double) ((Graphic) this.m_HintBox).rectTransform.sizeDelta.y <= 150.0)
      return;
    Vector2 anchoredPosition = this.HintRC[(int) this.bHintOpen - 1].anchoredPosition;
    anchoredPosition.y += (float) (50.0 + ((double) ((Graphic) this.m_HintBox).rectTransform.sizeDelta.y - 140.0));
    ((Graphic) this.m_HintBox).rectTransform.anchoredPosition = anchoredPosition;
  }

  private uint GetExp(bool bHero, byte NowLv, uint NowExp, byte OldLv, uint OldExp)
  {
    uint exp;
    if ((int) NowLv == (int) OldLv)
      exp = NowExp - OldExp;
    else if (bHero)
    {
      exp = this.DM.LevelUpTable.GetRecordByKey((ushort) OldLv).HeroExp - OldExp + NowExp;
      for (int InKey = (int) OldLv + 1; InKey < (int) NowLv; ++InKey)
        exp += this.DM.LevelUpTable.GetRecordByKey((ushort) InKey).HeroExp;
    }
    else
    {
      exp = this.DM.LevelUpTable.GetRecordByKey((ushort) OldLv).KingdomExp - OldExp + NowExp;
      for (int InKey = (int) OldLv + 1; InKey < (int) NowLv; ++InKey)
        exp += this.DM.LevelUpTable.GetRecordByKey((ushort) InKey).KingdomExp;
    }
    return exp;
  }

  private void SetReward()
  {
    Array.Clear((Array) this.RewardArray, 0, this.RewardArray.Length);
    int num = (int) this.DM.RewardLen[0] + (int) this.DM.RewardLen[1] + (int) this.DM.RewardLen[2] + (int) this.DM.RewardLen[3];
    for (int index1 = 0; index1 < num && index1 < 128; ++index1)
    {
      for (int index2 = 0; index2 < 10; ++index2)
      {
        if (this.RewardArray[index2].ID == (ushort) 0)
        {
          this.RewardArray[index2].ID = this.DM.RewardData[index1];
          this.RewardArray[index2].count = (byte) 1;
          ++this.RewardCount;
          break;
        }
        if ((int) this.RewardArray[index2].ID == (int) this.DM.RewardData[index1])
        {
          ++this.RewardArray[index2].count;
          break;
        }
      }
    }
    if (this.RewardCount <= (byte) 10)
      return;
    this.RewardCount = (byte) 10;
  }

  private void CloseFunc()
  {
    if (this.bChallenge && this.OpenKind != 0 && this.PlayIndex != -1)
      return;
    this.GM.CheckSynIsOpned();
    if (this.OpenKind == 0)
    {
      for (int index = 0; index < (int) this.ActorNum; ++index)
        AssetManager.UnloadAssetBundle(this.AssetKey[index]);
      DataManager.Instance.SendExitBattle();
    }
    else
      this.GM.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
  }

  public override bool OnBackButtonClick()
  {
    this.CloseFunc();
    return true;
  }

  private float easeOutQuad(float start, float end, float value)
  {
    end -= start;
    return (float) (-(double) end * (double) value * ((double) value - 2.0)) + start;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    for (int index = 0; index < this.RBText.Length; ++index)
    {
      if ((UnityEngine.Object) this.RBText[index] != (UnityEngine.Object) null && ((Behaviour) this.RBText[index]).enabled)
      {
        ((Behaviour) this.RBText[index]).enabled = false;
        ((Behaviour) this.RBText[index]).enabled = true;
      }
    }
    for (int index = 0; index < this.RBLvText.Length; ++index)
    {
      if ((UnityEngine.Object) this.RBLvText[index] != (UnityEngine.Object) null && ((Behaviour) this.RBLvText[index]).enabled)
      {
        ((Behaviour) this.RBLvText[index]).enabled = false;
        ((Behaviour) this.RBLvText[index]).enabled = true;
      }
    }
    if (this.RBRewardBtn != null)
    {
      for (int index = 0; index < this.RBRewardBtn.Length; ++index)
        this.RBRewardBtn[index].Refresh_FontTexture();
    }
    if (!((UnityEngine.Object) this.RankText != (UnityEngine.Object) null) || !((Behaviour) this.RankText).enabled)
      return;
    ((Behaviour) this.RankText).enabled = false;
    ((Behaviour) this.RankText).enabled = true;
  }
}
