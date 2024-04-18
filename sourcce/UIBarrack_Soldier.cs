// Decompiled with JetBrains decompiler
// Type: UIBarrack_Soldier
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIBarrack_Soldier : 
  GUIWindow,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUICalculatorHandler,
  IUIUnitRSliderHandler
{
  private Transform GameT;
  private Transform Tf1;
  private Transform Tf2;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform Tmp2;
  private Transform Tmp3;
  private Transform LockPanel;
  private RectTransform DisbandSliderRT;
  private UIButton btn_EXIT;
  private UIButton btn_Disband;
  public UIButton btn_Training;
  private UIButton btn_TrainingCompleted;
  private UIButton btn_RD;
  private UIButton btn_Soldier_Exit;
  private UIButton btn_Soldier_Disband;
  private UIButton[] btn_Hint = new UIButton[4];
  private UIButtonHint tmpbtnHint;
  private UIButton btn_Lock;
  private UIButton btn_Hint_Info;
  private DemandResources m_DResources;
  public UnitResourcesSlider m_UnitRS;
  private UnitResourcesSlider m_DisbandSlider;
  private Image Bg1;
  private Image[] Bg_T = new Image[5];
  private Image Bg2;
  private Image Training_BG;
  private Image Img_EXIT;
  private Image Img_SoldierArrow;
  private Image Img_Lock;
  private Image Img_LockBG;
  private Image[] Img_Soldier = new Image[7];
  private Image[] Property = new Image[5];
  private Image[] Property1 = new Image[5];
  private Image[] Property2 = new Image[5];
  private Image[] Property3 = new Image[5];
  private Image[] Img_TrainingCompleted = new Image[3];
  private Image[] Img_Training = new Image[2];
  private Image Img_Resources;
  private Image Img_RDLock;
  private Image ImgDisbandblack;
  private Image ImgDisband_Soldier;
  private Image[] Img_Hint = new Image[4];
  private Image Img_Icon1;
  private Image[] Img_Icon2 = new Image[4];
  private Image[] Img_Icon3 = new Image[3];
  private Image Img_Hint_Info;
  private Image Img_ArmyHint;
  private UIText[] text_Arms = new UIText[7];
  private UIText[] text_Disband = new UIText[4];
  private UIText text_SoldierNum;
  private UIText text_Title;
  private UIText text_Training;
  private UIText text_TrainingCompleted;
  private UIText text_Gemstone;
  private UIText text_Time;
  private UIText text_RD;
  private UIText text_RDbtn;
  private UIText text_Disband_Name;
  private UIText text_Disband_Num;
  private UIText text_Disband_Title;
  private UIText[] text_Hint = new UIText[4];
  private UIText text_tmpStr;
  private UIText text_Hint_Info;
  private UISpritesArray spArray;
  private DataManager DM;
  private GUIManager GUIM;
  private Font TTFont;
  private StringBuilder tmpString = new StringBuilder();
  private byte RD_ID;
  private byte RD_Kind;
  private byte RD_Rank;
  private uint UnitMax;
  private uint BarrackMax;
  private uint TrainingMax;
  private bool bRDOutput = true;
  private ushort[] Resources = new ushort[6];
  private uint[] UnitSoldier = new uint[3];
  private uint[] mSoldierArms = new uint[3];
  private byte[][] mSoldierProperty = new byte[16][];
  private float[] Pos = new float[5];
  private float[] Width = new float[5];
  private ushort[] StrId = new ushort[4];
  private string AssetName;
  private string AssetName1;
  private Door door;
  private SoldierData tmpSD;
  private CString Cstr;
  private CString Cstr_D;
  private CString Cstr_D2;
  private CString Cstr_UnitRS;
  private CString Cstr_Gemstone;
  private CString Cstr_Hint_Info;
  private RoleBuildingData mBD;
  private BuildLevelRequest mBR;
  private int mType;
  private int tmpHintIdx = -1;
  private uint tmpValue;
  private float tmpEGA;
  private float tmpEGA_Cost = 1f;
  private uint needDiamond;
  private long[] Rvalue = new long[5];

  public void OnVauleChang(UnitResourcesSlider sender)
  {
    if (((UIBehaviour) this.Img_SoldierArrow).IsActive())
      ((Component) this.Img_SoldierArrow).gameObject.SetActive(false);
    this.Cstr.ClearString();
    StringManager.IntToStr(this.Cstr, sender.Value, bNumber: true);
    sender.m_inputText.text = this.Cstr.ToString();
    sender.m_inputText.SetAllDirty();
    sender.m_inputText.cachedTextGenerator.Invalidate();
    if (sender.m_ID == 1)
      this.SetDRformURS(sender.GetComponent<Transform>(), (double) sender.Value);
    else if (sender.Value == 0L)
      this.btn_Soldier_Disband.ForTextChange(e_BtnType.e_ChangeText);
    else if (this.btn_Soldier_Disband.m_BtnType == e_BtnType.e_ChangeText)
      this.btn_Soldier_Disband.ForTextChange(e_BtnType.e_Normal);
    if (this.mType != 0)
      return;
    this.GUIM.Barrack_Soldier_SliderValue = sender.Value;
  }

  public void OnTextChang(UnitResourcesSlider sender)
  {
    if (((UIBehaviour) this.Img_SoldierArrow).IsActive())
      ((Component) this.Img_SoldierArrow).gameObject.SetActive(false);
    this.Cstr.ClearString();
    StringManager.IntToStr(this.Cstr, sender.Value, bNumber: true);
    if (sender.m_ID == 1)
      this.SetDRformURS(sender.GetComponent<Transform>(), (double) sender.Value);
    else if (sender.Value == 0L)
      this.btn_Soldier_Disband.ForTextChange(e_BtnType.e_ChangeText);
    else if (this.btn_Soldier_Disband.m_BtnType == e_BtnType.e_ChangeText)
      this.btn_Soldier_Disband.ForTextChange(e_BtnType.e_Normal);
    if (this.mType != 0)
      return;
    this.GUIM.Barrack_Soldier_SliderValue = sender.Value;
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.Pos[0] = -42f;
    this.Pos[1] = -61f;
    this.Pos[2] = -70f;
    this.Pos[3] = -80f;
    this.Pos[4] = -87f;
    this.Width[0] = 66f;
    this.Width[1] = 90f;
    this.Width[2] = 114f;
    this.Width[3] = 134f;
    this.Width[4] = 150f;
    this.RD_ID = (byte) arg1;
    if (this.RD_ID > (byte) 16)
      this.mType = 1;
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.TTFont = this.GUIM.GetTTFFont();
    BuildTypeData recordByKey = this.DM.BuildsTypeData.GetRecordByKey((ushort) 6);
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.AssetName = "BuildingWindow";
    Material mmaterial = this.GUIM.AddSpriteAsset(this.AssetName);
    Material material1 = this.door.LoadMaterial();
    Material material2;
    if (this.mType == 0)
    {
      this.AssetName1 = "UI_arms";
      material2 = this.GUIM.AddSpriteAsset(this.AssetName1);
    }
    else
    {
      this.AssetName1 = "UI_trap";
      material2 = this.GUIM.AddSpriteAsset(this.AssetName1);
    }
    CString SpriteName = StringManager.Instance.StaticString1024();
    this.Cstr = StringManager.Instance.SpawnString();
    this.Cstr_D = StringManager.Instance.SpawnString();
    this.Cstr_D2 = StringManager.Instance.SpawnString();
    this.Cstr_UnitRS = StringManager.Instance.SpawnString();
    this.Cstr_Gemstone = StringManager.Instance.SpawnString();
    this.Cstr_Hint_Info = StringManager.Instance.SpawnString(200);
    this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) this.RD_ID);
    this.RD_Kind = this.tmpSD.SoldierKind;
    this.RD_Rank = this.tmpSD.Tier;
    this.Resources[0] = this.tmpSD.FoodRequire;
    this.Resources[1] = this.tmpSD.StoneRequire;
    this.Resources[2] = this.tmpSD.WoodRequire;
    this.Resources[3] = this.tmpSD.IronRequire;
    this.Resources[4] = this.tmpSD.MoneyRequire;
    this.Resources[5] = this.tmpSD.TimeRequire;
    this.UnitSoldier[0] = (uint) this.tmpSD.Strength;
    this.UnitSoldier[1] = (uint) this.tmpSD.Salaries;
    this.UnitSoldier[2] = (uint) this.tmpSD.Traffic;
    if (this.mType == 0)
    {
      this.mSoldierArms[0] = 3841U + (uint) this.RD_Kind;
      this.mSoldierArms[2] = 3866U + (uint) this.RD_Kind;
    }
    else
    {
      this.mSoldierArms[0] = 11154U + (uint) this.RD_Kind;
      this.mSoldierArms[2] = 4933U + (uint) this.RD_Kind;
    }
    this.mSoldierArms[1] = 3859U + (uint) this.RD_Kind;
    for (int index = 0; index < 16; ++index)
      this.mSoldierProperty[index] = new byte[4];
    if (this.mType == 0)
    {
      this.mSoldierProperty[0][0] = (byte) 1;
      this.mSoldierProperty[0][1] = (byte) 1;
      this.mSoldierProperty[0][2] = (byte) 1;
      this.mSoldierProperty[0][3] = (byte) 4;
      this.mSoldierProperty[1][0] = (byte) 2;
      this.mSoldierProperty[1][1] = (byte) 2;
      this.mSoldierProperty[1][2] = (byte) 2;
      this.mSoldierProperty[1][3] = (byte) 3;
      this.mSoldierProperty[2][0] = (byte) 3;
      this.mSoldierProperty[2][1] = (byte) 3;
      this.mSoldierProperty[2][2] = (byte) 3;
      this.mSoldierProperty[2][3] = (byte) 2;
      this.mSoldierProperty[3][0] = (byte) 4;
      this.mSoldierProperty[3][1] = (byte) 4;
      this.mSoldierProperty[3][2] = (byte) 4;
      this.mSoldierProperty[3][3] = (byte) 0;
      this.mSoldierProperty[4][0] = (byte) 1;
      this.mSoldierProperty[4][1] = (byte) 1;
      this.mSoldierProperty[4][2] = (byte) 1;
      this.mSoldierProperty[4][3] = (byte) 4;
      this.mSoldierProperty[5][0] = (byte) 2;
      this.mSoldierProperty[5][1] = (byte) 2;
      this.mSoldierProperty[5][2] = (byte) 2;
      this.mSoldierProperty[5][3] = (byte) 3;
      this.mSoldierProperty[6][0] = (byte) 3;
      this.mSoldierProperty[6][1] = (byte) 3;
      this.mSoldierProperty[6][2] = (byte) 3;
      this.mSoldierProperty[6][3] = (byte) 2;
      this.mSoldierProperty[7][0] = (byte) 4;
      this.mSoldierProperty[7][1] = (byte) 4;
      this.mSoldierProperty[7][2] = (byte) 4;
      this.mSoldierProperty[7][3] = (byte) 1;
      this.mSoldierProperty[8][0] = (byte) 1;
      this.mSoldierProperty[8][1] = (byte) 1;
      this.mSoldierProperty[8][2] = (byte) 1;
      this.mSoldierProperty[8][3] = (byte) 4;
      this.mSoldierProperty[9][0] = (byte) 2;
      this.mSoldierProperty[9][1] = (byte) 2;
      this.mSoldierProperty[9][2] = (byte) 2;
      this.mSoldierProperty[9][3] = (byte) 4;
      this.mSoldierProperty[10][0] = (byte) 3;
      this.mSoldierProperty[10][1] = (byte) 3;
      this.mSoldierProperty[10][2] = (byte) 3;
      this.mSoldierProperty[10][3] = (byte) 3;
      this.mSoldierProperty[11][0] = (byte) 4;
      this.mSoldierProperty[11][1] = (byte) 4;
      this.mSoldierProperty[11][2] = (byte) 4;
      this.mSoldierProperty[11][3] = (byte) 2;
      this.mSoldierProperty[12][0] = (byte) 1;
      this.mSoldierProperty[12][1] = (byte) 1;
      this.mSoldierProperty[12][2] = (byte) 1;
      this.mSoldierProperty[12][3] = (byte) 3;
      this.mSoldierProperty[13][0] = (byte) 2;
      this.mSoldierProperty[13][1] = (byte) 2;
      this.mSoldierProperty[13][2] = (byte) 2;
      this.mSoldierProperty[13][3] = (byte) 3;
      this.mSoldierProperty[14][0] = (byte) 3;
      this.mSoldierProperty[14][1] = (byte) 3;
      this.mSoldierProperty[14][2] = (byte) 3;
      this.mSoldierProperty[14][3] = (byte) 1;
      this.mSoldierProperty[15][0] = (byte) 4;
      this.mSoldierProperty[15][1] = (byte) 4;
      this.mSoldierProperty[15][2] = (byte) 4;
      this.mSoldierProperty[15][3] = (byte) 0;
    }
    else
    {
      this.mSoldierProperty[0][0] = (byte) 1;
      this.mSoldierProperty[0][1] = (byte) 1;
      this.mSoldierProperty[0][2] = (byte) 1;
      this.mSoldierProperty[0][3] = (byte) 0;
      this.mSoldierProperty[1][0] = (byte) 2;
      this.mSoldierProperty[1][1] = (byte) 2;
      this.mSoldierProperty[1][2] = (byte) 2;
      this.mSoldierProperty[1][3] = (byte) 0;
      this.mSoldierProperty[2][0] = (byte) 3;
      this.mSoldierProperty[2][1] = (byte) 3;
      this.mSoldierProperty[2][2] = (byte) 3;
      this.mSoldierProperty[2][3] = (byte) 0;
      this.mSoldierProperty[3][0] = (byte) 4;
      this.mSoldierProperty[3][1] = (byte) 4;
      this.mSoldierProperty[3][2] = (byte) 4;
      this.mSoldierProperty[3][3] = (byte) 0;
      this.mSoldierProperty[4][0] = (byte) 1;
      this.mSoldierProperty[4][1] = (byte) 1;
      this.mSoldierProperty[4][2] = (byte) 1;
      this.mSoldierProperty[4][3] = (byte) 0;
      this.mSoldierProperty[5][0] = (byte) 2;
      this.mSoldierProperty[5][1] = (byte) 2;
      this.mSoldierProperty[5][2] = (byte) 2;
      this.mSoldierProperty[5][3] = (byte) 0;
      this.mSoldierProperty[6][0] = (byte) 3;
      this.mSoldierProperty[6][1] = (byte) 3;
      this.mSoldierProperty[6][2] = (byte) 3;
      this.mSoldierProperty[6][3] = (byte) 0;
      this.mSoldierProperty[7][0] = (byte) 4;
      this.mSoldierProperty[7][1] = (byte) 4;
      this.mSoldierProperty[7][2] = (byte) 4;
      this.mSoldierProperty[7][3] = (byte) 0;
      this.mSoldierProperty[8][0] = (byte) 1;
      this.mSoldierProperty[8][1] = (byte) 1;
      this.mSoldierProperty[8][2] = (byte) 1;
      this.mSoldierProperty[8][3] = (byte) 0;
      this.mSoldierProperty[9][0] = (byte) 2;
      this.mSoldierProperty[9][1] = (byte) 2;
      this.mSoldierProperty[9][2] = (byte) 2;
      this.mSoldierProperty[9][3] = (byte) 0;
      this.mSoldierProperty[10][0] = (byte) 3;
      this.mSoldierProperty[10][1] = (byte) 3;
      this.mSoldierProperty[10][2] = (byte) 3;
      this.mSoldierProperty[10][3] = (byte) 0;
      this.mSoldierProperty[11][0] = (byte) 4;
      this.mSoldierProperty[11][1] = (byte) 4;
      this.mSoldierProperty[11][2] = (byte) 4;
      this.mSoldierProperty[11][3] = (byte) 0;
    }
    this.StrId[0] = (ushort) 3845;
    this.StrId[1] = this.mType != 0 || this.RD_Kind == (byte) 3 ? (ushort) 8531 : (ushort) 3847;
    this.StrId[2] = (ushort) 3846;
    this.StrId[3] = (ushort) 3848;
    this.GUIM.BuildingData.GetBuildNumByID((ushort) 6);
    this.BarrackMax = 0U;
    int num1 = 0;
    uint effectBaseVal1;
    if (this.mType == 0)
    {
      this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY);
      this.BarrackMax = this.BarrackMax * (10000U + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY_PERCENT)) / 10000U;
      effectBaseVal1 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED);
      num1 = 0;
      uint num2 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM) (79 + (((int) this.RD_Rank - 1) * 4 + (int) this.RD_Kind)));
      if (num2 >= 9900U)
        num2 = 9900U;
      this.tmpEGA_Cost = (float) (1.0 - (double) num2 / 10000.0);
    }
    else
    {
      this.mBD = this.GUIM.BuildingData.GetBuildData((ushort) 12, (ushort) 0);
      this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData((ushort) 12, this.mBD.Level);
      uint num3 = 0;
      if (this.DM.queueBarData[14].bActive)
        num3 += this.DM.TrapTrainingQty;
      if (this.DM.queueBarData[15].bActive)
        num3 += this.DM.Trap_TreatmentQuantity;
      this.BarrackMax = this.mBR.Value1 - this.DM.TrapTotal - num3;
      effectBaseVal1 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAP_TRAINING_SPEED);
    }
    float effectBaseVal2 = (float) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED_DEBUFF);
    float num4 = (float) (10000U + effectBaseVal1) - effectBaseVal2;
    if ((double) num4 <= 100.0)
      num4 = 100f;
    this.tmpEGA = 10000f / num4;
    if (this.tmpSD.Science != (ushort) 0 && this.DM.GetTechLevel(this.tmpSD.Science) == (byte) 0)
      this.bRDOutput = false;
    this.UnitMax = this.CheckMax(this.BarrackMax);
    this.GameT = this.gameObject.transform;
    this.spArray = this.GameT.GetComponent<UISpritesArray>();
    this.Tmp = this.GameT.GetChild(0);
    this.Bg1 = this.Tmp.GetComponent<Image>();
    this.Bg1.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_04");
    ((MaskableGraphic) this.Bg1).material = mmaterial;
    this.Tmp1 = this.Tmp.GetChild(0);
    this.Bg_T[0] = this.Tmp1.GetComponent<Image>();
    this.Bg_T[0].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_10");
    ((MaskableGraphic) this.Bg_T[0]).material = mmaterial;
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.Bg_T[2] = this.Tmp2.GetComponent<Image>();
    this.Bg_T[2].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_12");
    ((MaskableGraphic) this.Bg_T[2]).material = mmaterial;
    this.Tmp2 = this.Tmp1.GetChild(1);
    this.Bg_T[3] = this.Tmp2.GetComponent<Image>();
    this.Bg_T[3].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_12");
    ((MaskableGraphic) this.Bg_T[3]).material = mmaterial;
    this.Tmp2 = this.Tmp1.GetChild(2);
    this.text_Arms[1] = this.Tmp2.GetComponent<UIText>();
    this.text_Arms[1].font = this.TTFont;
    this.text_Arms[1].text = this.DM.mStringTable.GetStringByID(3838U);
    this.Tmp2 = this.Tmp1.GetChild(3);
    this.text_Arms[2] = this.Tmp2.GetComponent<UIText>();
    this.text_Arms[2].font = this.TTFont;
    this.text_Arms[2].text = this.DM.mStringTable.GetStringByID(this.mSoldierArms[0]);
    this.Tmp2 = this.Tmp1.GetChild(4);
    this.text_Arms[3] = this.Tmp2.GetComponent<UIText>();
    this.text_Arms[3].font = this.TTFont;
    this.text_Arms[3].text = this.DM.mStringTable.GetStringByID(3839U);
    this.Tmp2 = this.Tmp1.GetChild(5);
    this.text_Arms[4] = this.Tmp2.GetComponent<UIText>();
    this.text_Arms[4].font = this.TTFont;
    this.text_Arms[4].text = this.DM.mStringTable.GetStringByID(this.mSoldierArms[1]);
    this.Tmp2 = this.Tmp1.GetChild(6);
    this.text_Arms[5] = this.Tmp2.GetComponent<UIText>();
    this.text_Arms[5].font = this.TTFont;
    this.text_Arms[5].text = this.DM.mStringTable.GetStringByID(3840U);
    this.Tmp2 = this.Tmp1.GetChild(7);
    this.text_Arms[6] = this.Tmp2.GetComponent<UIText>();
    this.text_Arms[6].font = this.TTFont;
    this.text_Arms[6].text = this.DM.mStringTable.GetStringByID(this.mSoldierArms[2]);
    this.Tmp2 = this.Tmp1.GetChild(8);
    this.text_Arms[0] = this.Tmp2.GetComponent<UIText>();
    this.text_Arms[0].font = this.TTFont;
    this.text_Arms[0].text = this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name);
    this.Tmp2 = this.Tmp1.GetChild(9).GetChild(0);
    this.Img_Icon1 = this.Tmp2.GetComponent<Image>();
    this.Img_Icon1.sprite = this.spArray.m_Sprites[4 + (int) this.RD_Kind];
    ((Component) this.Img_Icon1).gameObject.SetActive(true);
    this.Tmp2 = this.Tmp1.GetChild(9).GetChild(1);
    this.btn_Hint_Info = this.Tmp2.GetComponent<UIButton>();
    RectTransform component1 = this.Tmp2.GetComponent<RectTransform>();
    this.btn_Hint_Info.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Hint_Info.m_BtnID1 = 15;
    ((Component) this.btn_Hint_Info).gameObject.SetActive(true);
    if ((double) this.text_Arms[2].preferredWidth + 36.0 < 250.0)
    {
      ((Graphic) this.text_Arms[2]).rectTransform.sizeDelta = new Vector2(this.text_Arms[2].preferredWidth + 1f, ((Graphic) this.text_Arms[2]).rectTransform.sizeDelta.y);
      float num5 = (float) (((double) this.text_Arms[2].preferredWidth + 36.0) / 2.0);
      ((Graphic) this.text_Arms[2]).rectTransform.anchoredPosition = new Vector2((float) ((double) num5 - 259.5 - ((double) this.text_Arms[2].preferredWidth + 1.0) / 2.0), ((Graphic) this.text_Arms[2]).rectTransform.anchoredPosition.y);
      ((Graphic) this.Img_Icon1).rectTransform.anchoredPosition = new Vector2((float) -((double) num5 - 16.5), ((Graphic) this.Img_Icon1).rectTransform.anchoredPosition.y);
      component1.sizeDelta = new Vector2(this.text_Arms[2].preferredWidth + 36f, component1.sizeDelta.y);
    }
    else
    {
      ((Graphic) this.text_Arms[2]).rectTransform.sizeDelta = new Vector2(215f, ((Graphic) this.text_Arms[2]).rectTransform.sizeDelta.y);
      float num6 = 125f;
      ((Graphic) this.text_Arms[2]).rectTransform.anchoredPosition = new Vector2((float) ((double) num6 - 259.5 - 107.5), ((Graphic) this.text_Arms[2]).rectTransform.anchoredPosition.y);
      ((Graphic) this.Img_Icon1).rectTransform.anchoredPosition = new Vector2((float) -((double) num6 - 16.5), ((Graphic) this.Img_Icon1).rectTransform.anchoredPosition.y);
      component1.sizeDelta = new Vector2(250f, component1.sizeDelta.y);
    }
    this.Tmp2 = this.Tmp1.GetChild(10).GetChild(0);
    this.Img_Icon2[0] = this.Tmp2.GetComponent<Image>();
    this.tmpbtnHint = ((Component) this.Img_Icon2[0]).gameObject.AddComponent<UIButtonHint>();
    this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
    this.tmpbtnHint.Parm1 = (ushort) 1;
    this.Tmp2 = this.Tmp1.GetChild(10).GetChild(1);
    this.Img_Icon2[1] = this.Tmp2.GetComponent<Image>();
    this.Tmp2 = this.Tmp1.GetChild(10).GetChild(2);
    this.Img_Icon2[2] = this.Tmp2.GetComponent<Image>();
    this.Tmp2 = this.Tmp1.GetChild(10).GetChild(3);
    this.Img_Icon2[3] = this.Tmp2.GetComponent<Image>();
    if (this.mType == 0)
    {
      if (this.RD_Kind < (byte) 2)
      {
        this.Img_Icon2[0].sprite = this.spArray.m_Sprites[5 + (int) this.RD_Kind];
        this.tmpbtnHint.Parm2 = (byte) ((uint) this.RD_ID + 4U);
      }
      else if (this.RD_Kind == (byte) 2)
      {
        this.Img_Icon2[0].sprite = this.spArray.m_Sprites[4];
        this.tmpbtnHint.Parm2 = (byte) ((uint) this.RD_ID - 8U);
      }
      else
      {
        this.Img_Icon2[0].sprite = this.spArray.m_Sprites[11];
        this.tmpbtnHint.Parm2 = (byte) 29;
      }
      if (this.RD_Kind != (byte) 3)
      {
        this.Img_Icon2[1].sprite = this.spArray.m_Sprites[7];
        this.tmpbtnHint = ((Component) this.Img_Icon2[1]).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 1;
        this.tmpbtnHint.Parm2 = (byte) 13;
      }
      else
      {
        this.Img_Icon2[1].sprite = this.spArray.m_Sprites[8];
        this.tmpbtnHint = ((Component) this.Img_Icon2[1]).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 1;
        this.tmpbtnHint.Parm2 = (byte) 17;
        this.Img_Icon2[2].sprite = this.spArray.m_Sprites[9];
        this.tmpbtnHint = ((Component) this.Img_Icon2[2]).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 1;
        this.tmpbtnHint.Parm2 = (byte) 21;
        this.Img_Icon2[3].sprite = this.spArray.m_Sprites[10];
        this.tmpbtnHint = ((Component) this.Img_Icon2[3]).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 1;
        this.tmpbtnHint.Parm2 = (byte) 25;
      }
    }
    else if (this.RD_Kind == (byte) 4)
    {
      this.Img_Icon2[0].sprite = this.spArray.m_Sprites[6];
      this.tmpbtnHint.Parm2 = (byte) 9;
    }
    else if (this.RD_Kind == (byte) 5)
    {
      this.Img_Icon2[0].sprite = this.spArray.m_Sprites[5];
      this.tmpbtnHint.Parm2 = (byte) 5;
    }
    else
    {
      this.Img_Icon2[0].sprite = this.spArray.m_Sprites[4];
      this.tmpbtnHint.Parm2 = (byte) 1;
    }
    ((Component) this.Img_Icon2[0]).gameObject.SetActive(true);
    ((Component) this.text_Arms[4]).gameObject.SetActive(false);
    if (this.RD_Kind < (byte) 3)
    {
      ((Component) this.Img_Icon2[1]).gameObject.SetActive(true);
      ((Graphic) this.Img_Icon2[0]).rectTransform.anchoredPosition = new Vector2(-16.5f, ((Graphic) this.Img_Icon2[0]).rectTransform.anchoredPosition.y);
      ((Graphic) this.Img_Icon2[1]).rectTransform.anchoredPosition = new Vector2(16.5f, ((Graphic) this.Img_Icon2[1]).rectTransform.anchoredPosition.y);
    }
    else
    {
      ((Component) this.Img_Icon2[1]).gameObject.SetActive(false);
      ((Component) this.Img_Icon2[2]).gameObject.SetActive(false);
      ((Component) this.Img_Icon2[3]).gameObject.SetActive(false);
      if (this.RD_Kind == (byte) 3)
      {
        ((Graphic) this.Img_Icon2[0]).rectTransform.anchoredPosition = new Vector2(-50.5f, ((Graphic) this.Img_Icon2[0]).rectTransform.anchoredPosition.y);
        ((Graphic) this.Img_Icon2[0]).rectTransform.sizeDelta = new Vector2(34f, 34f);
        ((Graphic) this.Img_Icon2[1]).rectTransform.anchoredPosition = new Vector2(-16.5f, ((Graphic) this.Img_Icon2[1]).rectTransform.anchoredPosition.y);
        ((Graphic) this.Img_Icon2[2]).rectTransform.anchoredPosition = new Vector2(16.5f, ((Graphic) this.Img_Icon2[2]).rectTransform.anchoredPosition.y);
        ((Graphic) this.Img_Icon2[3]).rectTransform.anchoredPosition = new Vector2(49.5f, ((Graphic) this.Img_Icon2[3]).rectTransform.anchoredPosition.y);
        ((Component) this.Img_Icon2[1]).gameObject.SetActive(true);
        ((Component) this.Img_Icon2[2]).gameObject.SetActive(true);
        ((Component) this.Img_Icon2[3]).gameObject.SetActive(true);
      }
      else
      {
        ((Graphic) this.Img_Icon2[0]).rectTransform.anchoredPosition = new Vector2(0.0f, ((Graphic) this.Img_Icon2[0]).rectTransform.anchoredPosition.y);
        this.Img_Icon2[0].SetNativeSize();
      }
    }
    this.Tmp2 = this.Tmp1.GetChild(11).GetChild(0);
    this.Img_Icon3[0] = this.Tmp2.GetComponent<Image>();
    this.tmpbtnHint = ((Component) this.Img_Icon3[0]).gameObject.AddComponent<UIButtonHint>();
    this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
    this.tmpbtnHint.Parm1 = (ushort) 1;
    this.Tmp2 = this.Tmp1.GetChild(11).GetChild(1);
    this.Img_Icon3[1] = this.Tmp2.GetComponent<Image>();
    this.Tmp2 = this.Tmp1.GetChild(11).GetChild(2);
    this.Img_Icon3[2] = this.Tmp2.GetComponent<Image>();
    if (this.mType == 0)
    {
      if (this.RD_Kind < (byte) 3)
      {
        if (this.RD_Kind == (byte) 0)
        {
          this.Img_Icon3[0].sprite = this.spArray.m_Sprites[6];
          this.tmpbtnHint.Parm2 = (byte) 9;
          this.Img_Icon3[1].sprite = this.spArray.m_Sprites[10];
          this.tmpbtnHint = ((Component) this.Img_Icon3[1]).gameObject.AddComponent<UIButtonHint>();
          this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
          this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
          this.tmpbtnHint.Parm1 = (ushort) 1;
          this.tmpbtnHint.Parm2 = (byte) 25;
        }
        else if (this.RD_Kind == (byte) 1)
        {
          this.Img_Icon3[0].sprite = this.spArray.m_Sprites[4];
          this.tmpbtnHint.Parm2 = (byte) 1;
          this.Img_Icon3[1].sprite = this.spArray.m_Sprites[9];
          this.tmpbtnHint = ((Component) this.Img_Icon3[1]).gameObject.AddComponent<UIButtonHint>();
          this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
          this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
          this.tmpbtnHint.Parm1 = (ushort) 1;
          this.tmpbtnHint.Parm2 = (byte) 21;
        }
        else if (this.RD_Kind == (byte) 2)
        {
          this.Img_Icon3[0].sprite = this.spArray.m_Sprites[5];
          this.tmpbtnHint.Parm2 = (byte) 5;
          this.Img_Icon3[1].sprite = this.spArray.m_Sprites[8];
          this.tmpbtnHint = ((Component) this.Img_Icon3[1]).gameObject.AddComponent<UIButtonHint>();
          this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
          this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
          this.tmpbtnHint.Parm1 = (ushort) 1;
          this.tmpbtnHint.Parm2 = (byte) 17;
        }
        this.Img_Icon3[2].sprite = this.spArray.m_Sprites[11];
        this.tmpbtnHint = ((Component) this.Img_Icon3[2]).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 1;
        this.tmpbtnHint.Parm2 = (byte) 29;
      }
      else
      {
        this.Img_Icon3[0].sprite = this.spArray.m_Sprites[4];
        this.tmpbtnHint.Parm2 = (byte) 1;
        this.Img_Icon3[1].sprite = this.spArray.m_Sprites[5];
        this.tmpbtnHint = ((Component) this.Img_Icon3[1]).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 1;
        this.tmpbtnHint.Parm2 = (byte) 5;
        this.Img_Icon3[2].sprite = this.spArray.m_Sprites[6];
        this.tmpbtnHint = ((Component) this.Img_Icon3[2]).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 1;
        this.tmpbtnHint.Parm2 = (byte) 9;
      }
    }
    else
    {
      this.Img_Icon3[0].sprite = this.RD_Kind != (byte) 5 ? (this.RD_Kind != (byte) 6 ? this.spArray.m_Sprites[7] : this.spArray.m_Sprites[7]) : this.spArray.m_Sprites[7];
      this.tmpbtnHint.Parm2 = (byte) 13;
    }
    ((Component) this.Img_Icon3[0]).gameObject.SetActive(true);
    ((Component) this.text_Arms[6]).gameObject.SetActive(false);
    if (this.mType == 0)
    {
      ((Component) this.Img_Icon3[1]).gameObject.SetActive(true);
      ((Component) this.Img_Icon3[2]).gameObject.SetActive(true);
      ((Graphic) this.Img_Icon3[0]).rectTransform.anchoredPosition = new Vector2(-33f, ((Graphic) this.Img_Icon3[0]).rectTransform.anchoredPosition.y);
      if (this.RD_Kind != (byte) 3)
      {
        ((Graphic) this.Img_Icon3[2]).rectTransform.anchoredPosition = new Vector2(34f, ((Graphic) this.Img_Icon3[2]).rectTransform.anchoredPosition.y);
        ((Graphic) this.Img_Icon3[2]).rectTransform.sizeDelta = new Vector2(34f, 34f);
      }
      else
      {
        ((Graphic) this.Img_Icon3[2]).rectTransform.anchoredPosition = new Vector2(33f, ((Graphic) this.Img_Icon3[2]).rectTransform.anchoredPosition.y);
        this.Img_Icon3[2].SetNativeSize();
      }
    }
    else
    {
      ((Component) this.Img_Icon3[1]).gameObject.SetActive(false);
      ((Component) this.Img_Icon3[2]).gameObject.SetActive(false);
      ((Graphic) this.Img_Icon3[0]).rectTransform.anchoredPosition = new Vector2(0.0f, ((Graphic) this.Img_Icon3[0]).rectTransform.anchoredPosition.y);
    }
    this.Tmp2 = this.Tmp1.GetChild(12);
    this.Img_ArmyHint = this.Tmp2.GetComponent<Image>();
    this.Img_ArmyHint.sprite = this.mType != 0 ? this.door.LoadSprite("UI_EO_icon_02") : this.door.LoadSprite("UI_EO_icon_01");
    ((MaskableGraphic) this.Img_ArmyHint).material = this.door.LoadMaterial();
    this.tmpbtnHint = ((Component) this.Img_ArmyHint).gameObject.AddComponent<UIButtonHint>();
    this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
    this.tmpbtnHint.Parm1 = (ushort) 2;
    ((Component) this.Img_ArmyHint).gameObject.SetActive(true);
    this.Tmp1 = this.Tmp.GetChild(1);
    this.Property[0] = this.Tmp1.GetComponent<Image>();
    this.Property[0].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_27");
    Image image1 = this.Property[0];
    Material material3 = mmaterial;
    ((MaskableGraphic) this.Bg_T[3]).material = material3;
    Material material4 = material3;
    ((MaskableGraphic) image1).material = material4;
    int num7 = this.mType != 0 ? (int) this.mSoldierProperty[(int) this.tmpSD.SoldierKey - 17][0] : (int) this.mSoldierProperty[(int) this.tmpSD.SoldierKey - 1][0];
    for (int index = 0; index < num7; ++index)
    {
      this.Tmp2 = this.Tmp1.GetChild(index);
      this.Property[index + 1] = this.Tmp2.GetComponent<Image>();
      this.Property[index + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_06");
      Image image2 = this.Property[index + 1];
      Material material5 = mmaterial;
      ((MaskableGraphic) this.Bg_T[3]).material = material5;
      Material material6 = material5;
      ((MaskableGraphic) image2).material = material6;
    }
    for (int index = num7; index < 4; ++index)
    {
      this.Tmp2 = this.Tmp1.GetChild(index);
      this.Property[index + 1] = this.Tmp2.GetComponent<Image>();
      this.Property[index + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_07");
      ((MaskableGraphic) this.Property[index + 1]).material = mmaterial;
    }
    this.Tmp1 = this.Tmp.GetChild(2);
    this.Property1[0] = this.Tmp1.GetComponent<Image>();
    this.Property1[0].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_27");
    ((MaskableGraphic) this.Property1[0]).material = mmaterial;
    int num8 = this.mType != 0 ? (int) this.mSoldierProperty[(int) this.tmpSD.SoldierKey - 17][1] : (int) this.mSoldierProperty[(int) this.tmpSD.SoldierKey - 1][1];
    for (int index = 0; index < num8; ++index)
    {
      this.Tmp2 = this.Tmp1.GetChild(index);
      this.Property1[index + 1] = this.Tmp2.GetComponent<Image>();
      this.Property1[index + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_06");
      ((MaskableGraphic) this.Property1[index + 1]).material = mmaterial;
    }
    for (int index = num8; index < 4; ++index)
    {
      this.Tmp2 = this.Tmp1.GetChild(index);
      this.Property1[index + 1] = this.Tmp2.GetComponent<Image>();
      this.Property1[index + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_07");
      ((MaskableGraphic) this.Property1[index + 1]).material = mmaterial;
    }
    this.Tmp1 = this.Tmp.GetChild(3);
    this.Property2[0] = this.Tmp1.GetComponent<Image>();
    this.Property2[0].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_27");
    ((MaskableGraphic) this.Property2[0]).material = mmaterial;
    int num9 = this.mType != 0 ? (int) this.mSoldierProperty[(int) this.tmpSD.SoldierKey - 17][2] : (int) this.mSoldierProperty[(int) this.tmpSD.SoldierKey - 1][2];
    for (int index = 0; index < num9; ++index)
    {
      this.Tmp2 = this.Tmp1.GetChild(index);
      this.Property2[index + 1] = this.Tmp2.GetComponent<Image>();
      this.Property2[index + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_06");
      ((MaskableGraphic) this.Property2[index + 1]).material = mmaterial;
    }
    for (int index = num9; index < 4; ++index)
    {
      this.Tmp2 = this.Tmp1.GetChild(index);
      this.Property2[index + 1] = this.Tmp2.GetComponent<Image>();
      this.Property2[index + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_07");
      ((MaskableGraphic) this.Property2[index + 1]).material = mmaterial;
    }
    this.Tmp1 = this.Tmp.GetChild(4);
    this.Property3[0] = this.Tmp1.GetComponent<Image>();
    this.Property3[0].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_27");
    ((MaskableGraphic) this.Property3[0]).material = mmaterial;
    int num10 = this.mType != 0 ? (int) this.mSoldierProperty[(int) this.tmpSD.SoldierKey - 17][3] : (int) this.mSoldierProperty[(int) this.tmpSD.SoldierKey - 1][3];
    for (int index = 0; index < num10; ++index)
    {
      this.Tmp2 = this.Tmp1.GetChild(index);
      this.Property3[index + 1] = this.Tmp2.GetComponent<Image>();
      this.Property3[index + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_06");
      ((MaskableGraphic) this.Property3[index + 1]).material = mmaterial;
    }
    for (int index = num10; index < 4; ++index)
    {
      this.Tmp2 = this.Tmp1.GetChild(index);
      this.Property3[index + 1] = this.Tmp2.GetComponent<Image>();
      this.Property3[index + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_07");
      ((MaskableGraphic) this.Property3[index + 1]).material = mmaterial;
    }
    this.Tmp1 = this.Tmp.GetChild(5);
    this.Img_Soldier[0] = this.Tmp1.GetComponent<Image>();
    this.tmpString.Length = 0;
    this.tmpString.AppendFormat("q{0}", (object) this.tmpSD.Icon);
    this.Img_Soldier[0].sprite = this.GUIM.LoadSprite(this.AssetName1, this.tmpString.ToString());
    ((MaskableGraphic) this.Img_Soldier[0]).material = material2;
    this.Tmp2 = this.Tmp1.GetChild(0);
    Image component2 = this.Tmp2.GetComponent<Image>();
    component2.sprite = this.GUIM.LoadSprite(this.AssetName1, this.tmpString.ToString());
    ((MaskableGraphic) component2).material = material2;
    if (this.GUIM.IsArabic)
      ((Component) component2).transform.localScale = new Vector3(-1f, ((Component) component2).transform.localScale.y, ((Component) component2).transform.localScale.z);
    this.Tmp2 = this.Tmp1.GetChild(1);
    this.Img_Soldier[2] = this.Tmp2.GetComponent<Image>();
    this.Img_Soldier[2].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_20");
    ((MaskableGraphic) this.Img_Soldier[2]).material = mmaterial;
    this.Tmp3 = this.Tmp2.GetChild(0);
    this.text_SoldierNum = this.Tmp3.GetComponent<UIText>();
    this.text_SoldierNum.font = this.TTFont;
    if (this.mType == 0)
    {
      this.tmpString.Length = 0;
      GameConstants.FormatValue(this.tmpString, this.DM.RoleAttr.m_Soldier[(int) this.RD_ID - 1]);
    }
    else
    {
      this.tmpString.Length = 0;
      GameConstants.FormatValue(this.tmpString, this.DM.mTrapQty[(int) this.RD_ID - 17]);
    }
    this.text_SoldierNum.text = this.tmpString.ToString();
    this.Tmp2 = this.Tmp1.GetChild(2);
    this.Img_Soldier[4] = this.Tmp2.GetComponent<Image>();
    this.Img_Soldier[4].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_13");
    ((MaskableGraphic) this.Img_Soldier[4]).material = mmaterial;
    this.Tmp3 = this.Tmp2.GetChild(0);
    this.text_Disband[0] = this.Tmp3.GetComponent<UIText>();
    this.text_Disband[0].font = this.TTFont;
    this.tmpString.Length = 0;
    this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3875U), (object) this.UnitSoldier[0]);
    this.text_Disband[0].text = this.tmpString.ToString();
    if (this.mType == 1)
      ((Component) this.Img_Soldier[4]).gameObject.SetActive(false);
    this.Tmp2 = this.Tmp1.GetChild(3);
    this.Img_Soldier[5] = this.Tmp2.GetComponent<Image>();
    this.Img_Soldier[5].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_13");
    ((MaskableGraphic) this.Img_Soldier[5]).material = mmaterial;
    this.Tmp3 = this.Tmp2.GetChild(0);
    this.text_Disband[1] = this.Tmp3.GetComponent<UIText>();
    this.text_Disband[1].font = this.TTFont;
    this.tmpString.Length = 0;
    if (this.mType == 0)
      this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3874U), (object) this.UnitSoldier[1]);
    else
      this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3875U), (object) this.UnitSoldier[0]);
    this.text_Disband[1].text = this.tmpString.ToString();
    this.Tmp2 = this.Tmp1.GetChild(4);
    this.Img_Soldier[6] = this.Tmp2.GetComponent<Image>();
    this.Img_Soldier[6].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_13");
    ((MaskableGraphic) this.Img_Soldier[6]).material = mmaterial;
    this.Tmp3 = this.Tmp2.GetChild(0);
    this.text_Disband[2] = this.Tmp3.GetComponent<UIText>();
    this.text_Disband[2].font = this.TTFont;
    this.tmpString.Length = 0;
    this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3876U), (object) this.UnitSoldier[2]);
    this.text_Disband[2].text = this.tmpString.ToString();
    if (this.mType == 1)
      ((Component) this.Img_Soldier[6]).gameObject.SetActive(false);
    this.Tmp2 = this.Tmp1.GetChild(5);
    this.btn_Disband = this.Tmp2.GetComponent<UIButton>();
    this.btn_Disband.image.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_butt_07");
    ((MaskableGraphic) this.btn_Disband.image).material = mmaterial;
    this.btn_Disband.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Disband.m_BtnID1 = 1;
    this.btn_Disband.m_EffectType = e_EffectType.e_Scale;
    this.btn_Disband.transition = (Selectable.Transition) 0;
    this.Tmp3 = this.Tmp2.GetChild(0);
    this.text_Disband[3] = this.Tmp3.GetComponent<UIText>();
    this.text_Disband[3].font = this.TTFont;
    this.btn_Disband.m_Text = this.text_Disband[3];
    if (this.mType == 0)
    {
      this.text_Disband[3].text = this.DM.mStringTable.GetStringByID(3877U);
      if (this.DM.RoleAttr.m_Soldier[(int) this.RD_ID - 1] == 0U)
        this.btn_Disband.ForTextChange(e_BtnType.e_ChangeText);
      else
        this.btn_Disband.ForTextChange(e_BtnType.e_Normal);
    }
    else
    {
      this.text_Disband[3].text = this.DM.mStringTable.GetStringByID(3772U);
      if (this.DM.mTrapQty[(int) this.RD_ID - 17] == 0U)
        this.btn_Disband.ForTextChange(e_BtnType.e_ChangeText);
      else
        this.btn_Disband.ForTextChange(e_BtnType.e_Normal);
    }
    this.Tmp1 = this.Tmp.GetChild(6);
    this.Bg2 = this.Tmp1.GetComponent<Image>();
    this.Bg2.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_19");
    ((MaskableGraphic) this.Bg2).material = mmaterial;
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.text_Title = this.Tmp2.GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.text_Title.text = this.mType != 0 ? this.DM.mStringTable.GetStringByID(3748U) : this.DM.mStringTable.GetStringByID((uint) recordByKey.NameID);
    for (int index = 0; index < 4; ++index)
    {
      SpriteName.ClearString();
      SpriteName.IntToFormat((long) (index + 1));
      SpriteName.AppendFormat("UI_con_icons_0{0}");
      this.Tmp1 = this.Tmp.GetChild(7 + index);
      this.btn_Hint[index] = this.Tmp1.GetComponent<UIButton>();
      this.btn_Hint[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Hint[index].m_BtnID1 = 7 + index;
      this.btn_Hint[index].image.sprite = this.GUIM.LoadSprite("BuildingWindow", SpriteName);
      ((MaskableGraphic) this.btn_Hint[index].image).material = mmaterial;
      this.tmpbtnHint = ((Component) this.btn_Hint[index]).gameObject.AddComponent<UIButtonHint>();
      this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
      this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
      this.tmpbtnHint.Parm1 = (ushort) 0;
      this.Img_Hint[index] = this.Tmp1.GetChild(0).GetComponent<Image>();
      this.tmpbtnHint.ControlFadeOut = ((Component) this.Img_Hint[index]).gameObject;
      this.Img_Hint[index].sprite = this.door.LoadSprite("UI_main_box_012");
      ((MaskableGraphic) this.Img_Hint[index]).material = material1;
      this.text_Hint[index] = this.Tmp1.GetChild(0).GetChild(0).GetComponent<UIText>();
      this.text_Hint[index].font = this.TTFont;
      this.text_Hint[index].text = this.DM.mStringTable.GetStringByID((uint) this.StrId[index]);
      RectTransform component3 = ((Component) this.Img_Hint[index]).transform.GetComponent<RectTransform>();
      RectTransform component4 = ((Component) this.text_Hint[index]).transform.GetComponent<RectTransform>();
      float num11 = Mathf.Clamp(this.text_Hint[index].preferredWidth, 0.0f, component4.sizeDelta.x);
      component3.sizeDelta = new Vector2(num11 + 20f, component3.sizeDelta.y);
      RectTransform component5 = ((Component) this.text_Hint[index]).transform.GetComponent<RectTransform>();
      component5.sizeDelta = new Vector2(num11 + 20f, component5.sizeDelta.y);
    }
    this.Tmp1 = this.Tmp.GetChild(11);
    Image component6 = this.Tmp1.GetComponent<Image>();
    component6.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_divider_02");
    ((MaskableGraphic) component6).material = mmaterial;
    this.Tmp = this.GameT.GetChild(1);
    this.Training_BG = this.Tmp.GetComponent<Image>();
    this.Training_BG.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_04");
    ((MaskableGraphic) this.Training_BG).material = mmaterial;
    this.Img_LockBG = this.Tmp.GetChild(0).GetComponent<Image>();
    this.Img_Lock = this.Tmp.GetChild(3).GetComponent<Image>();
    this.btn_Lock = this.Tmp.GetChild(4).GetComponent<UIButton>();
    this.btn_Lock.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Lock.m_BtnID1 = 13;
    this.btn_Lock.m_EffectType = e_EffectType.e_Scale;
    this.btn_Lock.transition = (Selectable.Transition) 0;
    this.LockPanel = this.Tmp.GetChild(5);
    UIButton component7 = this.LockPanel.GetChild(0).GetComponent<UIButton>();
    component7.m_Handler = (IUIButtonClickHandler) this;
    component7.m_BtnID1 = 14;
    UIButton component8 = this.LockPanel.GetChild(1).GetComponent<UIButton>();
    component8.m_Handler = (IUIButtonClickHandler) this;
    component8.m_BtnID1 = 14;
    this.Tmp1 = this.Tmp.GetChild(1);
    this.Tf1 = this.Tmp1.GetComponent<Transform>();
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.Img_Resources = this.Tmp2.GetComponent<Image>();
    this.Img_Resources.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_28");
    ((MaskableGraphic) this.Img_Resources).material = mmaterial;
    this.Tmp2 = this.Tmp1.GetChild(1);
    this.m_DResources = this.Tmp2.GetComponent<DemandResources>();
    this.GUIM.InitDemandResources(this.Tmp2, 555f, 111f, true);
    this.Tmp2 = this.Tmp1.GetChild(2);
    this.m_UnitRS = this.Tmp2.GetComponent<UnitResourcesSlider>();
    this.GUIM.InitUnitResourcesSlider(this.Tmp2, eUnitSlider.Barrack, 0U, this.BarrackMax, 0.7f);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.BtnIncrease, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_01"), mmaterial);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.BtnLessen, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_02"), mmaterial);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.Input, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_05"), mmaterial);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_sliderBG1, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_03"), mmaterial);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_sliderBG2, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_04"), mmaterial);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_Img, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_06"), mmaterial);
    this.m_UnitRS.BtnInputText.m_Handler = (IUIButtonClickHandler) this;
    this.m_UnitRS.BtnInputText.m_BtnID1 = 11;
    if (this.mType == 1)
      this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_micon, this.GUIM.LoadSprite("BuildingWindow", "UI_wall_trap_01"), mmaterial);
    this.m_UnitRS.m_Handler = (IUIUnitRSliderHandler) this;
    this.m_UnitRS.m_ID = 1;
    this.Tmp2 = this.Tmp1.GetChild(3);
    this.Img_TrainingCompleted[0] = this.Tmp2.GetComponent<Image>();
    this.Img_TrainingCompleted[0].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_16");
    ((MaskableGraphic) this.Img_TrainingCompleted[0]).material = mmaterial;
    this.Tmp3 = this.Tmp2.GetChild(0);
    this.Img_TrainingCompleted[1] = this.Tmp3.GetComponent<Image>();
    this.Img_TrainingCompleted[1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_17");
    ((MaskableGraphic) this.Img_TrainingCompleted[1]).material = mmaterial;
    this.Tmp3 = this.Tmp2.GetChild(1);
    this.Img_TrainingCompleted[2] = this.Tmp3.GetComponent<Image>();
    this.Img_TrainingCompleted[2].sprite = this.door.LoadSprite("UI_main_money_02");
    ((MaskableGraphic) this.Img_TrainingCompleted[2]).material = material1;
    this.Img_TrainingCompleted[2].SetNativeSize();
    this.Tmp3 = this.Tmp2.GetChild(2);
    this.text_Gemstone = this.Tmp3.GetComponent<UIText>();
    this.text_Gemstone.font = this.TTFont;
    this.Tmp2 = this.Tmp1.GetChild(4);
    this.Img_Training[0] = this.Tmp2.GetComponent<Image>();
    this.Img_Training[0].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_16");
    ((MaskableGraphic) this.Img_Training[0]).material = mmaterial;
    this.Tmp3 = this.Tmp2.GetChild(0);
    this.Img_TrainingCompleted[1] = this.Tmp3.GetComponent<Image>();
    this.Img_TrainingCompleted[1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_17");
    ((MaskableGraphic) this.Img_TrainingCompleted[1]).material = mmaterial;
    this.Tmp3 = this.Tmp2.GetChild(1);
    this.text_Time = this.Tmp3.GetComponent<UIText>();
    this.text_Time.font = this.TTFont;
    this.Tmp2 = this.Tmp1.GetChild(5);
    this.btn_TrainingCompleted = this.Tmp2.GetComponent<UIButton>();
    this.btn_TrainingCompleted.image.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_butt_07");
    ((MaskableGraphic) this.btn_TrainingCompleted.image).material = mmaterial;
    this.btn_TrainingCompleted.m_Handler = (IUIButtonClickHandler) this;
    this.btn_TrainingCompleted.m_BtnID1 = 3;
    this.btn_TrainingCompleted.m_EffectType = e_EffectType.e_Scale;
    this.btn_TrainingCompleted.transition = (Selectable.Transition) 0;
    this.Tmp3 = this.Tmp2.GetChild(0);
    this.text_TrainingCompleted = this.Tmp3.GetComponent<UIText>();
    this.text_TrainingCompleted.font = this.TTFont;
    this.text_TrainingCompleted.text = this.mType != 0 ? this.DM.mStringTable.GetStringByID(3773U) : this.DM.mStringTable.GetStringByID(3851U);
    this.btn_TrainingCompleted.m_Text = this.text_TrainingCompleted;
    this.Tmp2 = this.Tmp1.GetChild(6);
    this.btn_Training = this.Tmp2.GetComponent<UIButton>();
    this.btn_Training.image.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_butt_07");
    ((MaskableGraphic) this.btn_Training.image).material = mmaterial;
    this.btn_Training.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Training.m_BtnID1 = 2;
    this.btn_Training.m_EffectType = e_EffectType.e_Scale;
    this.btn_Training.transition = (Selectable.Transition) 0;
    this.Img_SoldierArrow = this.Tmp2.GetChild(0).GetComponent<Image>();
    this.Tmp3 = this.Tmp2.GetChild(1);
    this.text_Training = this.Tmp3.GetComponent<UIText>();
    this.text_Training.font = this.TTFont;
    this.text_Training.text = this.mType != 0 ? this.DM.mStringTable.GetStringByID(3774U) : this.DM.mStringTable.GetStringByID(3850U);
    this.btn_Training.m_Text = this.text_Training;
    this.Tmp1 = this.Tmp.GetChild(2);
    this.Tf2 = this.Tmp1.GetComponent<Transform>();
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.Img_RDLock = this.Tmp2.GetComponent<Image>();
    this.Img_RDLock.sprite = this.door.LoadSprite("UI_main_lock");
    ((MaskableGraphic) this.Img_RDLock).material = material1;
    this.Img_RDLock.SetNativeSize();
    this.Tmp2 = this.Tmp1.GetChild(1);
    this.btn_RD = this.Tmp2.GetComponent<UIButton>();
    this.btn_RD.image.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_butt_07");
    ((MaskableGraphic) this.btn_RD.image).material = mmaterial;
    this.btn_RD.m_Handler = (IUIButtonClickHandler) this;
    this.btn_RD.m_BtnID1 = 4;
    this.btn_RD.m_EffectType = e_EffectType.e_Scale;
    this.btn_RD.transition = (Selectable.Transition) 0;
    this.Tmp3 = this.Tmp2.GetChild(0);
    this.text_RDbtn = this.Tmp3.GetComponent<UIText>();
    this.text_RDbtn.font = this.TTFont;
    this.text_RDbtn.text = this.DM.mStringTable.GetStringByID(3849U);
    this.Tmp2 = this.Tmp1.GetChild(2);
    this.text_RD = this.Tmp2.GetComponent<UIText>();
    this.text_RD.font = this.TTFont;
    this.tmpString.Length = 0;
    if (this.mType == 0)
      this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3858U), (object) this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name));
    else
      this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3775U), (object) this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name));
    this.text_RD.text = this.tmpString.ToString();
    this.Tmp = this.GameT.GetChild(2);
    this.Img_EXIT = this.Tmp.GetComponent<Image>();
    this.Img_EXIT.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.Img_EXIT).material = material1;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.Img_EXIT).enabled = false;
    this.Tmp = this.GameT.GetChild(2).GetChild(0);
    this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = material1;
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.Tmp = this.GameT.GetChild(3);
    this.ImgDisbandblack = this.Tmp.GetComponent<Image>();
    this.ImgDisbandblack.sprite = this.door.LoadSprite("UI_main_black");
    ((MaskableGraphic) this.ImgDisbandblack).material = this.door.LoadMaterial();
    if (this.GUIM.bOpenOnIPhoneX)
    {
      ((Graphic) this.ImgDisbandblack).rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
      ((Graphic) this.ImgDisbandblack).rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
    }
    HelperUIButton helperUiButton = ((Component) this.ImgDisbandblack).gameObject.AddComponent<HelperUIButton>();
    helperUiButton.m_Handler = (IUIButtonClickHandler) this;
    helperUiButton.m_BtnID1 = 5;
    this.Tmp1 = this.Tmp.GetChild(0);
    Image component9 = this.Tmp1.GetComponent<Image>();
    component9.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_29");
    ((MaskableGraphic) component9).material = mmaterial;
    this.Tmp2 = this.Tmp1.GetChild(0);
    Image component10 = this.Tmp2.GetComponent<Image>();
    component10.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_title_orange");
    ((MaskableGraphic) component10).material = mmaterial;
    this.Tmp3 = this.Tmp2.GetChild(0);
    this.text_Disband_Title = this.Tmp3.GetComponent<UIText>();
    this.text_Disband_Title.font = this.TTFont;
    this.text_Disband_Title.text = this.mType != 0 ? this.DM.mStringTable.GetStringByID(3772U) : this.DM.mStringTable.GetStringByID(4068U);
    this.Tmp1 = this.Tmp.GetChild(1);
    Image component11 = this.Tmp1.GetComponent<Image>();
    component11.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_06");
    ((MaskableGraphic) component11).material = mmaterial;
    this.Tmp1 = this.Tmp.GetChild(2);
    Image component12 = this.Tmp1.GetComponent<Image>();
    component12.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_13");
    ((MaskableGraphic) component12).material = mmaterial;
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.text_Disband_Name = this.Tmp2.GetComponent<UIText>();
    this.text_Disband_Name.font = this.TTFont;
    this.text_Disband_Name.text = this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name);
    this.Tmp1 = this.Tmp.GetChild(3);
    this.ImgDisband_Soldier = this.Tmp1.GetComponent<Image>();
    this.tmpString.Length = 0;
    this.tmpString.AppendFormat("q{0}", (object) this.tmpSD.Icon);
    this.ImgDisband_Soldier.sprite = this.GUIM.LoadSprite(this.AssetName1, this.tmpString.ToString());
    ((MaskableGraphic) this.ImgDisband_Soldier).material = material2;
    if (this.GUIM.IsArabic)
      ((Component) this.ImgDisband_Soldier).transform.localScale = new Vector3(-1f, ((Component) this.ImgDisband_Soldier).transform.localScale.y, ((Component) this.ImgDisband_Soldier).transform.localScale.z);
    this.Tmp1 = this.Tmp.GetChild(4);
    Image component13 = this.Tmp1.GetComponent<Image>();
    component13.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_20");
    ((MaskableGraphic) component13).material = mmaterial;
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.text_Disband_Num = this.Tmp2.GetComponent<UIText>();
    this.text_Disband_Num.font = this.TTFont;
    this.tmpString.Length = 0;
    if (this.mType == 0)
      GameConstants.FormatValue(this.tmpString, this.DM.RoleAttr.m_Soldier[(int) this.RD_ID - 1]);
    else
      GameConstants.FormatValue(this.tmpString, this.DM.mTrapQty[(int) this.RD_ID - 17]);
    this.text_Disband_Num.text = this.tmpString.ToString();
    this.Tmp1 = this.Tmp.GetChild(5);
    this.m_DisbandSlider = this.Tmp1.GetComponent<UnitResourcesSlider>();
    this.tmpValue = 0U;
    this.tmpValue = this.mType != 0 ? this.DM.mTrapQty[(int) this.RD_ID - 17] : this.DM.RoleAttr.m_Soldier[(int) this.RD_ID - 1];
    this.GUIM.InitUnitResourcesSlider(this.Tmp1, eUnitSlider.Other, 0U, this.tmpValue, 0.7f);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.BtnIncrease, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_01"), mmaterial);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.BtnLessen, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_02"), mmaterial);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.Input, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_05"), mmaterial);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_sliderBG1, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_03"), mmaterial);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_sliderBG2, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_04"), mmaterial);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_Img, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_06"), mmaterial);
    this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.m_Img, 5f, 52.5f, 22f, 28f, 0.0f, 0.0f);
    this.m_DisbandSlider.BtnInputText.m_Handler = (IUIButtonClickHandler) this;
    this.m_DisbandSlider.BtnInputText.m_BtnID1 = 12;
    this.m_DisbandSlider.m_Handler = (IUIUnitRSliderHandler) this;
    this.m_DisbandSlider.m_ID = 2;
    RectTransform component14 = ((Component) this.m_DisbandSlider.m_TotalText).transform.GetComponent<RectTransform>();
    if ((double) this.m_DisbandSlider.m_TotalText.preferredWidth > (double) component14.sizeDelta.x)
      component14.sizeDelta = new Vector2(this.m_DisbandSlider.m_TotalText.preferredWidth + 1f, component14.sizeDelta.y);
    component14.anchoredPosition = new Vector2(269f, component14.anchoredPosition.y);
    int index1 = 0;
    if (this.tmpValue / 1000U > 0U)
      index1 = this.tmpValue / 100000000U <= 0U ? (this.tmpValue / 10000000U <= 0U ? (this.tmpValue / 10000U <= 0U ? 1 : 2) : 3) : 4;
    this.DisbandSliderRT = this.m_DisbandSlider.GetComponent<Transform>().GetChild(3).GetComponent<RectTransform>();
    this.DisbandSliderRT.anchoredPosition = new Vector2(this.Pos[index1], this.DisbandSliderRT.anchoredPosition.y);
    this.DisbandSliderRT.sizeDelta = new Vector2(this.Width[index1], this.DisbandSliderRT.sizeDelta.y);
    this.Tmp1 = this.Tmp.GetChild(6);
    this.btn_Soldier_Disband = this.Tmp1.GetComponent<UIButton>();
    this.btn_Soldier_Disband.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Soldier_Disband.m_BtnID1 = 6;
    this.btn_Soldier_Disband.image.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_butt_07");
    ((MaskableGraphic) this.btn_Soldier_Disband.image).material = mmaterial;
    this.btn_Soldier_Disband.m_EffectType = e_EffectType.e_Scale;
    this.btn_Soldier_Disband.transition = (Selectable.Transition) 0;
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.text_tmpStr = this.Tmp2.GetComponent<UIText>();
    this.text_tmpStr.font = this.TTFont;
    this.text_tmpStr.text = this.mType != 0 ? this.DM.mStringTable.GetStringByID(3772U) : this.DM.mStringTable.GetStringByID(4050U);
    this.btn_Soldier_Disband.m_Text = this.text_tmpStr;
    this.Tmp1 = this.Tmp.GetChild(7);
    this.btn_Soldier_Exit = this.Tmp1.GetComponent<UIButton>();
    this.btn_Soldier_Exit.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Soldier_Exit.m_BtnID1 = 5;
    this.btn_Soldier_Exit.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_Soldier_Exit.image).material = material1;
    this.btn_Soldier_Exit.m_EffectType = e_EffectType.e_Scale;
    this.btn_Soldier_Exit.transition = (Selectable.Transition) 0;
    this.Tmp = this.GameT.GetChild(4);
    this.Img_Hint_Info = this.Tmp.GetComponent<Image>();
    this.Img_Hint_Info.sprite = this.door.LoadSprite("UI_main_box_012");
    ((MaskableGraphic) this.Img_Hint_Info).material = material1;
    this.tmpbtnHint = ((Component) this.btn_Hint_Info).gameObject.AddComponent<UIButtonHint>();
    this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
    this.tmpbtnHint.ControlFadeOut = ((Component) this.Img_Hint_Info).gameObject;
    this.tmpbtnHint.Parm1 = (ushort) 1;
    this.tmpbtnHint.Parm2 = this.RD_ID;
    this.text_Hint_Info = this.Tmp.GetChild(0).GetComponent<UIText>();
    this.text_Hint_Info.font = this.TTFont;
    this.Cstr_Hint_Info.ClearString();
    if (this.mType == 0)
      this.Cstr_Hint_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint) (ushort) (3841U + (uint) this.RD_Kind)));
    else
      this.Cstr_Hint_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint) (ushort) (11154U + (uint) this.RD_Kind)));
    this.Cstr_Hint_Info.AppendFormat(this.DM.mStringTable.GetStringByID(11157U));
    this.text_Hint_Info.text = this.Cstr_Hint_Info.ToString();
    this.text_Hint_Info.SetAllDirty();
    this.text_Hint_Info.cachedTextGenerator.Invalidate();
    this.text_Hint_Info.cachedTextGeneratorForLayout.Invalidate();
    ((Graphic) this.text_Hint_Info).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Hint_Info).rectTransform.sizeDelta.x, this.text_Hint_Info.preferredHeight + 1f);
    ((Graphic) this.Img_Hint_Info).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Hint_Info).rectTransform.sizeDelta.x, this.text_Hint_Info.preferredHeight + 21f);
    if (this.bRDOutput)
    {
      this.Tf1.gameObject.SetActive(true);
      this.Tf2.gameObject.SetActive(false);
      uint num12 = !this.DM.bSoldierSave || !this.DM.bSetExpediton ? this.UnitMax : this.DM.tmpSoldierTrainingQty;
      this.DM.bSoldierSave = false;
      this.DM.bSetExpediton = false;
      uint x = num12;
      bool flag = NewbieManager.IsTeachWorking(ETeachKind.SPAWN_SOLDIERS);
      if (flag)
        x = 20U;
      else if (this.DM.GuideSoldierNum != (ushort) 0 && (uint) this.DM.GuideSoldierNum < num12)
        x = (uint) this.DM.GuideSoldierNum;
      this.Cstr.ClearString();
      StringManager.IntToStr(this.Cstr, (long) x, bNumber: true);
      if (num12 > 0U || flag || this.GUIM.Barrack_Soldier_Lock == 1)
      {
        if (this.mType == 0)
        {
          if (this.GUIM.Barrack_Soldier_Lock == 2)
            this.GUIM.Barrack_Soldier_SliderValue = (long) x;
          else if (this.GUIM.Barrack_Soldier_Lock == 1 && this.GUIM.Barrack_Soldier_SliderValue <= (long) this.BarrackMax)
          {
            x = (uint) this.GUIM.Barrack_Soldier_SliderValue;
          }
          else
          {
            this.GUIM.Barrack_Soldier_Lock = 2;
            this.GUIM.Barrack_Soldier_SliderValue = (long) x;
          }
        }
        this.m_UnitRS.m_slider.value = (double) x;
        this.m_UnitRS.Value = (long) x;
      }
      this.m_UnitRS.m_inputText.text = this.Cstr.ToString();
      this.m_UnitRS.m_inputText.SetAllDirty();
      this.m_UnitRS.m_inputText.cachedTextGenerator.Invalidate();
      this.SetDRformURS(this.m_UnitRS.GetComponent<Transform>(), (double) x);
    }
    else
    {
      this.Tf1.gameObject.SetActive(false);
      this.Tf2.gameObject.SetActive(true);
    }
    if (this.GUIM.BuildingData.GuideSoldierID != (ushort) 0)
      this.GUIM.BuildingData.GuideSoldierID = (ushort) 0;
    if (this.DM.GuideSoldierNum != (ushort) 0 && !NewbieManager.IsWorking())
    {
      ((Component) this.Img_SoldierArrow).gameObject.SetActive(true);
      this.DM.GuideSoldierNum = (ushort) 0;
    }
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    if (this.mType == 0)
    {
      NewbieManager.CheckTeach(ETeachKind.SPAWN_SOLDIERS, (object) this);
      if (this.GUIM.Barrack_Soldier_Lock == 2 && !NewbieManager.IsWorking() && this.bRDOutput)
        NewbieManager.CheckSpawnSoldierDetail();
    }
    this.UpdateLcokBtnType();
  }

  public uint CheckMax(uint MaxValue)
  {
    uint[] numArray = new uint[5];
    for (int index = 0; index < 5; ++index)
      numArray[index] = this.DM.Resource[index].Stock;
    uint num1 = MaxValue;
    if (this.Resources[0] > (ushort) 0)
    {
      uint num2 = numArray[0] / GameConstants.appCeil((float) this.Resources[0] * this.tmpEGA_Cost);
      if (num2 < num1)
        num1 = num2;
    }
    if (this.Resources[1] > (ushort) 0)
    {
      uint num3 = numArray[1] / GameConstants.appCeil((float) this.Resources[1] * this.tmpEGA_Cost);
      if (num3 < num1)
        num1 = num3;
    }
    if (this.Resources[2] > (ushort) 0)
    {
      uint num4 = numArray[2] / GameConstants.appCeil((float) this.Resources[2] * this.tmpEGA_Cost);
      if (num4 < num1)
        num1 = num4;
    }
    if (this.Resources[3] > (ushort) 0)
    {
      uint num5 = numArray[3] / GameConstants.appCeil((float) this.Resources[3] * this.tmpEGA_Cost);
      if (num5 < num1)
        num1 = num5;
    }
    if (this.Resources[4] > (ushort) 0)
    {
      uint num6 = numArray[4] / GameConstants.appCeil((float) this.Resources[4] * this.tmpEGA_Cost);
      if (num6 < num1)
        num1 = num6;
    }
    return num1;
  }

  public override void OnClose()
  {
    if (this.AssetName != null)
      GUIManager.Instance.RemoveSpriteAsset(this.AssetName);
    if (this.AssetName1 != null)
      GUIManager.Instance.RemoveSpriteAsset(this.AssetName1);
    if (this.Cstr != null)
      StringManager.Instance.DeSpawnString(this.Cstr);
    if (this.Cstr_D != null)
      StringManager.Instance.DeSpawnString(this.Cstr_D);
    if (this.Cstr_D2 != null)
      StringManager.Instance.DeSpawnString(this.Cstr_D2);
    if (this.Cstr_UnitRS != null)
      StringManager.Instance.DeSpawnString(this.Cstr_UnitRS);
    if (this.Cstr_Gemstone != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Gemstone);
    if (this.Cstr_Hint_Info != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Hint_Info);
    if (this.DM.bSoldierSave)
      this.DM.tmpSoldierTrainingQty = (uint) this.m_UnitRS.Value;
    this.GUIM.ClearCalculator();
  }

  public void SetDRformURS(Transform URST, double value)
  {
    if (!((Object) URST.GetComponent<UnitResourcesSlider>() != (Object) null))
      return;
    for (int index = 0; index < 5; ++index)
      this.Rvalue[index] = (long) (value * (double) GameConstants.appCeil((float) this.Resources[index] * this.tmpEGA_Cost));
    this.GUIM.SetDemandResourcesText(this.m_DResources.GetComponent<Transform>(), this.Rvalue);
    this.btn_Training.ForTextChange(e_BtnType.e_Normal);
    this.btn_TrainingCompleted.ForTextChange(e_BtnType.e_Normal);
    uint num = 0;
    this.UnitMax = this.CheckMax(this.BarrackMax);
    if (value == 0.0)
      this.btn_TrainingCompleted.ForTextChange(e_BtnType.e_ChangeText);
    else if (value > (double) this.UnitMax)
    {
      bool flag = false;
      for (int Type = 0; Type < 5; ++Type)
      {
        if (this.Rvalue[Type] > (long) this.DM.Resource[Type].Stock)
        {
          num += this.DM.GetResourceExchange((PriceListType) Type, (uint) this.Rvalue[Type] - this.DM.Resource[Type].Stock);
          flag = true;
        }
      }
      if (flag)
        this.btn_Training.ForTextChange(e_BtnType.e_ChangeText);
    }
    uint Num = GameConstants.appCeil((float) ((uint) value * (uint) this.Resources[5]) * this.tmpEGA);
    uint x = num + this.DM.GetResourceExchange(PriceListType.Time, Num);
    this.Cstr_Gemstone.ClearString();
    this.Cstr_Gemstone.IntToFormat((long) x, bNumber: true);
    this.Cstr_Gemstone.AppendFormat("{0}");
    this.text_Gemstone.text = this.Cstr_Gemstone.ToString();
    this.text_Gemstone.SetAllDirty();
    this.text_Gemstone.cachedTextGenerator.Invalidate();
    this.tmpString.Length = 0;
    if (this.mType == 0)
      this.tmpString.Append(this.DM.mStringTable.GetStringByID(3944U));
    else
      this.tmpString.Append(this.DM.mStringTable.GetStringByID(3792U));
    this.tmpValue = Num / 3600U;
    if (this.tmpValue < 24U)
      this.tmpString.AppendFormat("{0:00}:{1:00}:{2:00}", (object) (this.tmpValue % 60U), (object) (Num / 60U % 60U), (object) (Num % 60U));
    else if (this.GUIM.IsArabic)
      this.tmpString.AppendFormat("{0:00}:{1:00}:{2:00} {3}d", (object) (this.tmpValue % 24U), (object) (Num / 60U % 60U), (object) (Num % 60U), (object) (this.tmpValue / 24U));
    else
      this.tmpString.AppendFormat("{0}d {1:00}:{2:00}:{3:00}", (object) (this.tmpValue / 24U), (object) (this.tmpValue % 24U), (object) (Num / 60U % 60U), (object) (Num % 60U));
    this.text_Time.text = this.tmpString.ToString();
    this.text_Time.SetAllDirty();
    this.text_Time.cachedTextGenerator.Invalidate();
  }

  public bool CheckDiamondToSend()
  {
    bool send = false;
    this.needDiamond = 0U;
    long[] numArray = new long[5];
    long num = this.m_UnitRS.Value;
    for (int Type = 0; Type < 5; ++Type)
    {
      numArray[Type] = (long) ((double) (num * (long) this.Resources[Type]) * (double) this.tmpEGA_Cost);
      if (numArray[Type] > (long) this.DM.Resource[Type].Stock)
        this.needDiamond += this.DM.GetResourceExchange((PriceListType) Type, (uint) numArray[Type] - this.DM.Resource[Type].Stock);
    }
    this.needDiamond += this.DM.GetResourceExchange(PriceListType.Time, GameConstants.appCeil((float) ((uint) num * (uint) this.Resources[5]) * this.tmpEGA));
    this.Cstr_Gemstone.ClearString();
    this.Cstr_Gemstone.IntToFormat((long) this.needDiamond, bNumber: true);
    this.Cstr_Gemstone.AppendFormat("{0}");
    this.text_Gemstone.text = this.Cstr_Gemstone.ToString();
    this.text_Gemstone.SetAllDirty();
    this.text_Gemstone.cachedTextGenerator.Invalidate();
    if (this.DM.RoleAttr.Diamond >= this.needDiamond)
      send = true;
    return send;
  }

  public bool CheckMaxTroops()
  {
    bool flag = false;
    long soldierTotal = this.DM.SoldierTotal;
    for (int index1 = 0; index1 < this.DM.MarchEventData.Length; ++index1)
    {
      for (int index2 = 0; index2 < this.DM.MarchEventData[index1].TroopData.Length; ++index2)
      {
        if (this.DM.MarchEventData[index1].Type != EMarchEventType.EMET_Standby)
        {
          for (int index3 = 0; index3 < this.DM.MarchEventData[index1].TroopData[index2].Length; ++index3)
            soldierTotal += (long) this.DM.MarchEventData[index1].TroopData[index2][index3];
        }
      }
    }
    if (this.DM.queueBarData[10].bActive)
      soldierTotal += (long) this.DM.SoldierQuantity;
    for (int index = 0; index < 16; ++index)
      soldierTotal += (long) this.DM.mSoldier_Hospital[index];
    if (soldierTotal + this.m_UnitRS.Value <= 4200000000L)
      flag = true;
    return flag;
  }

  public void OnButtonClick(UIButton sender)
  {
    if (((UIBehaviour) this.Img_SoldierArrow).IsActive())
      ((Component) this.Img_SoldierArrow).gameObject.SetActive(false);
    switch (sender.m_BtnID1)
    {
      case 0:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 1:
        if (this.mType == 0)
        {
          if (sender.m_BtnType != e_BtnType.e_Normal)
            break;
          ((Component) this.ImgDisbandblack).gameObject.SetActive(true);
          this.m_DisbandSlider.m_slider.maxValue = (double) this.DM.RoleAttr.m_Soldier[(int) this.RD_ID - 1];
          this.m_DisbandSlider.m_slider.value = 0.0;
          this.Cstr_D2.ClearString();
          StringManager.IntToStr(this.Cstr_D2, 0L, bNumber: true);
          this.m_DisbandSlider.m_inputText.text = this.Cstr_D2.ToString();
          this.m_DisbandSlider.m_inputText.SetAllDirty();
          this.m_DisbandSlider.m_inputText.cachedTextGenerator.Invalidate();
          this.btn_Soldier_Disband.ForTextChange(e_BtnType.e_ChangeText);
          break;
        }
        if (sender.m_BtnType != e_BtnType.e_Normal)
          break;
        ((Component) this.ImgDisbandblack).gameObject.SetActive(true);
        this.Cstr_D2.ClearString();
        StringManager.IntToStr(this.Cstr_D2, 0L, bNumber: true);
        this.m_DisbandSlider.m_slider.maxValue = (double) this.DM.mTrapQty[(int) this.RD_ID - 17];
        this.m_DisbandSlider.m_slider.value = 0.0;
        this.m_DisbandSlider.m_inputText.text = this.Cstr_D2.ToString();
        this.m_DisbandSlider.m_inputText.SetAllDirty();
        this.m_DisbandSlider.m_inputText.cachedTextGenerator.Invalidate();
        this.btn_Soldier_Disband.ForTextChange(e_BtnType.e_ChangeText);
        break;
      case 2:
        if (this.mType == 0)
        {
          if (this.DM.queueBarData[10].bActive)
          {
            this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(3928U), this.DM.mStringTable.GetStringByID(3855U), 1, YesText: this.DM.mStringTable.GetStringByID(4027U), NoText: this.DM.mStringTable.GetStringByID(4028U));
            break;
          }
          byte buildNumById = this.GUIM.BuildingData.GetBuildNumByID((ushort) 6);
          RoleBuildingData buildData = this.GUIM.BuildingData.GetBuildData((ushort) 6, (ushort) 0);
          switch (buildNumById)
          {
            case 0:
              this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4992U), (ushort) byte.MaxValue);
              return;
            case 1:
              if (this.GUIM.BuildingData.AllBuildsData[(int) this.GUIM.BuildingData.BuildingManorID].BuildID == (ushort) 6 && buildData.Level < (byte) 1)
              {
                this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4992U), (ushort) byte.MaxValue);
                return;
              }
              break;
          }
          this.TrainingMax = (uint) this.m_UnitRS.Value;
          if (this.TrainingMax == 0U)
          {
            GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(5703U), (ushort) byte.MaxValue);
            break;
          }
          if (!this.CheckMaxTroops())
          {
            GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(3923U), (ushort) byte.MaxValue);
            break;
          }
          if (sender.m_BtnType == e_BtnType.e_Normal && GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
          {
            this.DM.SoldierTrainingQty = (uint) this.m_UnitRS.Value;
            MessagePacket messagePacket = new MessagePacket((ushort) 1024);
            messagePacket.Protocol = Protocol._MSG_REQUEST_TRAINING_;
            messagePacket.AddSeqId();
            messagePacket.Add(this.RD_Kind);
            messagePacket.Add((byte) ((uint) this.RD_Rank - 1U));
            messagePacket.Add(this.TrainingMax);
            messagePacket.Send();
            if (!((Object) this.door != (Object) null))
              break;
            this.door.CloseMenu();
            break;
          }
          if (sender.m_BtnType != e_BtnType.e_ChangeText)
            break;
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(3942U), (ushort) byte.MaxValue);
          break;
        }
        if (this.DM.queueBarData[14].bActive)
        {
          this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(3738U), this.DM.mStringTable.GetStringByID(3739U), 5, YesText: this.DM.mStringTable.GetStringByID(3740U));
          break;
        }
        this.TrainingMax = (uint) this.m_UnitRS.Value;
        if (this.TrainingMax == 0U)
        {
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(5703U), (ushort) byte.MaxValue);
          break;
        }
        if (sender.m_BtnType == e_BtnType.e_Normal && GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
        {
          this.DM.TrapTrainingQty = (uint) this.m_UnitRS.Value;
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_REQUEST_TRAPCONSTRUCT;
          messagePacket.AddSeqId();
          messagePacket.Add((byte) ((uint) this.RD_Kind - 4U));
          messagePacket.Add((byte) ((uint) this.RD_Rank - 1U));
          messagePacket.Add(this.TrainingMax);
          messagePacket.Send();
          if (!((Object) this.door != (Object) null))
            break;
          this.door.CloseMenu();
          break;
        }
        if (sender.m_BtnType != e_BtnType.e_ChangeText)
          break;
        GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(3942U), (ushort) byte.MaxValue);
        break;
      case 3:
        if (this.mType == 0)
        {
          byte buildNumById = this.GUIM.BuildingData.GetBuildNumByID((ushort) 6);
          RoleBuildingData buildData = this.GUIM.BuildingData.GetBuildData((ushort) 6, (ushort) 0);
          switch (buildNumById)
          {
            case 0:
              this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4992U), (ushort) byte.MaxValue);
              return;
            case 1:
              if (this.GUIM.BuildingData.AllBuildsData[(int) this.GUIM.BuildingData.BuildingManorID].BuildID == (ushort) 6 && buildData.Level < (byte) 1)
              {
                this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4992U), (ushort) byte.MaxValue);
                return;
              }
              break;
          }
          if (sender.m_BtnType == e_BtnType.e_Normal)
          {
            if (!this.CheckDiamondToSend())
            {
              this.tmpString.Length = 0;
              this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3857U), (object) this.DM.mStringTable.GetStringByID(3851U));
              this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966U), this.tmpString.ToString(), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 2, bCloseIDSet: true);
              break;
            }
            if (!this.CheckMaxTroops())
            {
              GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(3923U), (ushort) byte.MaxValue);
              break;
            }
            if (this.GUIM.OpenCheckCrystal(this.needDiamond, (byte) 5, (int) this.m_eWindow << 16 | 100))
              break;
            this.SendTrainImmed();
            break;
          }
          if (this.m_UnitRS.Value != 0L)
            break;
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5703U), (ushort) byte.MaxValue);
          break;
        }
        if (sender.m_BtnType == e_BtnType.e_Normal)
        {
          if (!this.CheckDiamondToSend())
          {
            this.tmpString.Length = 0;
            this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3857U), (object) this.DM.mStringTable.GetStringByID(3773U));
            this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966U), this.tmpString.ToString(), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 2, bCloseIDSet: true);
            break;
          }
          if (this.GUIM.OpenCheckCrystal(this.needDiamond, (byte) 5, (int) this.m_eWindow << 16 | 101))
            break;
          this.SendTrackImmed();
          break;
        }
        if (this.m_UnitRS.Value != 0L)
          break;
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5703U), (ushort) byte.MaxValue);
        break;
      case 4:
        this.GUIM.OpenTechTree(this.tmpSD.Science, true);
        break;
      case 5:
        ((Component) this.ImgDisbandblack).gameObject.SetActive(false);
        break;
      case 6:
        if (this.mType == 0)
        {
          switch (this.GUIM.BuildingData.GetBuildNumByID((ushort) 6))
          {
            case 0:
              this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4997U), (ushort) byte.MaxValue);
              return;
            case 1:
              if (this.GUIM.BuildingData.AllBuildsData[(int) this.GUIM.BuildingData.BuildingManorID].BuildID == (ushort) 6 && this.GUIM.BuildingData.AllBuildsData[(int) this.GUIM.BuildingData.BuildingManorID].Level < (byte) 1)
              {
                this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4998U), (ushort) byte.MaxValue);
                return;
              }
              break;
          }
          if (sender.m_BtnType != e_BtnType.e_Normal)
            break;
          CString cstring = StringManager.Instance.StaticString1024();
          cstring.ClearString();
          cstring.uLongToFormat((ulong) this.m_DisbandSlider.m_slider.value, bNumber: true);
          cstring.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name));
          cstring.uLongToFormat((ulong) ((double) this.tmpSD.Strength * this.m_DisbandSlider.m_slider.value), bNumber: true);
          cstring.AppendFormat(this.DM.mStringTable.GetStringByID(4052U));
          this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4051U), cstring.ToString(), 3, YesText: this.DM.mStringTable.GetStringByID(4053U), NoText: this.DM.mStringTable.GetStringByID(4054U));
          break;
        }
        if (sender.m_BtnType != e_BtnType.e_Normal)
          break;
        CString cstring1 = StringManager.Instance.StaticString1024();
        cstring1.ClearString();
        cstring1.uLongToFormat((ulong) this.m_DisbandSlider.m_slider.value, bNumber: true);
        cstring1.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name));
        cstring1.uLongToFormat((ulong) ((double) this.tmpSD.Strength * this.m_DisbandSlider.m_slider.value), bNumber: true);
        cstring1.AppendFormat(this.DM.mStringTable.GetStringByID(3798U));
        this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(3796U), cstring1.ToString(), 7, YesText: this.DM.mStringTable.GetStringByID(4053U), NoText: this.DM.mStringTable.GetStringByID(4054U));
        break;
      case 11:
        this.GUIM.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
        this.GUIM.m_UICalculator.OpenCalculator(this.m_UnitRS.MaxValue, this.m_UnitRS.Value, -283f, -45f, this.m_UnitRS, 0L);
        break;
      case 12:
        this.GUIM.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
        this.GUIM.m_UICalculator.OpenCalculator(this.m_DisbandSlider.MaxValue, this.m_DisbandSlider.Value, -283f, 0.0f, this.m_DisbandSlider, 0L);
        break;
      case 13:
        if (this.GUIM.Barrack_Soldier_Lock == 2)
        {
          this.GUIM.Barrack_Soldier_Lock = 1;
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9773U), (ushort) byte.MaxValue);
        }
        else if (this.GUIM.Barrack_Soldier_Lock == 1)
        {
          this.GUIM.Barrack_Soldier_Lock = 2;
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9774U), (ushort) byte.MaxValue);
        }
        this.UpdateLcokBtnType();
        CString cstring2 = StringManager.Instance.StaticString1024();
        cstring2.ClearString();
        cstring2.IntToFormat(NetworkManager.UserID);
        cstring2.AppendFormat("{0}_Barrack_Soldier_Lock_UseID");
        PlayerPrefs.SetString(cstring2.ToString(), NetworkManager.UserID.ToString());
        cstring2.ClearString();
        cstring2.IntToFormat(NetworkManager.UserID);
        cstring2.AppendFormat("{0}_Barrack_Soldier_Lock");
        PlayerPrefs.SetString(cstring2.ToString(), this.GUIM.Barrack_Soldier_Lock.ToString());
        cstring2.ClearString();
        cstring2.IntToFormat(NetworkManager.UserID);
        cstring2.AppendFormat("{0}_Barrack_SliderValue");
        PlayerPrefs.SetString(cstring2.ToString(), this.GUIM.Barrack_Soldier_SliderValue.ToString());
        if (this.GUIM.Barrack_Soldier_Lock != 2 || NewbieManager.IsWorking())
          break;
        NewbieManager.CheckSpawnSoldierDetail();
        break;
      case 14:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9773U), (ushort) byte.MaxValue);
        break;
    }
  }

  private void SendTrainImmed()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_TRAINING_IMMEDIATELY;
    messagePacket.AddSeqId();
    messagePacket.Add(this.RD_Kind);
    messagePacket.Add((byte) ((uint) this.RD_Rank - 1U));
    messagePacket.Add((uint) this.m_UnitRS.Value);
    messagePacket.Send();
  }

  private void SendTrackImmed()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_INSTANTTRAPCONSTRUCT;
    messagePacket.AddSeqId();
    messagePacket.Add((byte) ((uint) this.RD_Kind - 4U));
    messagePacket.Add((byte) ((uint) this.RD_Rank - 1U));
    messagePacket.Add((uint) this.m_UnitRS.Value);
    messagePacket.Send();
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (sender.Parm1 == (ushort) 0)
    {
      UIButton button = sender.m_Button as UIButton;
      switch (button.m_BtnID1)
      {
        case 7:
        case 8:
        case 9:
        case 10:
          int index = button.m_BtnID1 - 7;
          if (this.tmpHintIdx == index)
            break;
          if (this.tmpHintIdx >= 0 && ((UIBehaviour) this.Img_Hint[this.tmpHintIdx]).IsActive())
            ((Component) this.Img_Hint[this.tmpHintIdx]).gameObject.SetActive(false);
          this.tmpHintIdx = index;
          ((Component) this.Img_Hint[index]).gameObject.SetActive(true);
          break;
      }
    }
    else if (sender.Parm1 == (ushort) 1)
    {
      ushort num = 0;
      if (sender.Parm2 < (byte) 29)
      {
        this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) sender.Parm2);
        num = (ushort) this.tmpSD.SoldierKind;
      }
      this.Cstr_Hint_Info.ClearString();
      if (sender.Parm2 < (byte) 17)
        this.Cstr_Hint_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint) (ushort) (3841U + (uint) num)));
      else if (sender.Parm2 < (byte) 29)
        this.Cstr_Hint_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint) (ushort) (11154U + (uint) num)));
      else
        this.Cstr_Hint_Info.StringToFormat(this.DM.mStringTable.GetStringByID(3895U));
      this.Cstr_Hint_Info.AppendFormat(this.DM.mStringTable.GetStringByID(11157U));
      this.text_Hint_Info.text = this.Cstr_Hint_Info.ToString();
      this.text_Hint_Info.SetAllDirty();
      this.text_Hint_Info.cachedTextGenerator.Invalidate();
      this.text_Hint_Info.cachedTextGeneratorForLayout.Invalidate();
      ((Graphic) this.text_Hint_Info).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Hint_Info).rectTransform.sizeDelta.x, this.text_Hint_Info.preferredHeight + 1f);
      ((Graphic) this.Img_Hint_Info).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Hint_Info).rectTransform.sizeDelta.x, this.text_Hint_Info.preferredHeight + 21f);
      ((Component) this.Img_Hint_Info).gameObject.SetActive(true);
      sender.GetTipPosition(((Graphic) this.Img_Hint_Info).rectTransform);
    }
    else
      GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintArmy, (byte) 0, 0.0f, 0, this.mType, 0, Vector2.zero);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if (sender.Parm1 == (ushort) 0)
    {
      UIButton button = sender.m_Button as UIButton;
      switch (button.m_BtnID1)
      {
        case 7:
        case 8:
        case 9:
        case 10:
          int index = button.m_BtnID1 - 7;
          if (((UIBehaviour) this.Img_Hint[index]).IsActive())
          {
            ((Component) this.Img_Hint[index]).gameObject.SetActive(false);
            break;
          }
          break;
      }
    }
    this.tmpHintIdx = -1;
    ((Component) this.Img_Hint_Info).gameObject.SetActive(false);
    GUIManager.Instance.m_Hint.Hide(true);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 1:
        this.DM.bSoldierSave = true;
        this.DM.bSetExpediton = true;
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 10);
        break;
      case 2:
        MallManager.Instance.Send_Mall_Info();
        break;
      case 3:
        if (!GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
          break;
        MessagePacket messagePacket1 = new MessagePacket((ushort) 1024);
        messagePacket1.Protocol = Protocol._MSG_REQUEST_TROOPDISMISS;
        messagePacket1.AddSeqId();
        messagePacket1.Add(this.RD_Kind);
        messagePacket1.Add((byte) ((uint) this.RD_Rank - 1U));
        messagePacket1.Add((uint) this.m_DisbandSlider.Value);
        messagePacket1.Send();
        ((Component) this.ImgDisbandblack).gameObject.SetActive(false);
        break;
      case 5:
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 14);
        break;
      case 7:
        if (!GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
          break;
        MessagePacket messagePacket2 = new MessagePacket((ushort) 1024);
        messagePacket2.Protocol = Protocol._MSG_REQUEST_TRAPDESTROY;
        messagePacket2.AddSeqId();
        messagePacket2.Add((byte) ((uint) this.RD_Kind - 4U));
        messagePacket2.Add((byte) ((uint) this.RD_Rank - 1U));
        messagePacket2.Add((uint) this.m_DisbandSlider.Value);
        messagePacket2.Send();
        ((Component) this.ImgDisbandblack).gameObject.SetActive(false);
        break;
    }
  }

  public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
  {
    URS.m_slider.value = (double) mValue;
    URS.SliderValueChange();
    if (this.mType != 0)
      return;
    this.GUIM.Barrack_Soldier_SliderValue = mValue;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        this.UpdateLcokBtnType();
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Soldier)
        {
          if (networkNews != NetworkNews.Refresh_AttribEffectVal)
          {
            if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
              break;
            if ((Object) this.m_DResources != (Object) null)
              this.m_DResources.Refresh_FontTexture();
            if ((Object) this.m_UnitRS != (Object) null)
              this.m_UnitRS.Refresh_FontTexture();
            if ((Object) this.m_DisbandSlider != (Object) null)
              this.m_DisbandSlider.Refresh_FontTexture();
            this.Refresh_FontTexture();
            break;
          }
          uint effectBaseVal1;
          if (this.mType == 0)
          {
            this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY);
            this.BarrackMax = this.BarrackMax * (10000U + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY_PERCENT)) / 10000U;
            effectBaseVal1 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED);
            this.m_UnitRS.MaxValue = (long) this.BarrackMax;
            this.m_UnitRS.m_slider.maxValue = (double) this.BarrackMax;
            this.Cstr_UnitRS.ClearString();
            StringManager.IntToStr(this.Cstr_UnitRS, (long) this.BarrackMax, bNumber: true);
            this.m_UnitRS.m_TotalText.text = this.Cstr_UnitRS.ToString();
            this.m_UnitRS.m_TotalText.SetAllDirty();
            this.m_UnitRS.m_TotalText.cachedTextGenerator.Invalidate();
            uint num = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM) (79 + (((int) this.RD_Rank - 1) * 4 + (int) this.RD_Kind)));
            if (num >= 9900U)
              num = 9900U;
            this.tmpEGA_Cost = (float) (1.0 - (double) num / 10000.0);
          }
          else
          {
            this.mBD = this.GUIM.BuildingData.GetBuildData((ushort) 12, (ushort) 0);
            this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData((ushort) 12, this.mBD.Level);
            uint num = 0;
            if (this.DM.queueBarData[14].bActive)
              num += this.DM.TrapTrainingQty;
            if (this.DM.queueBarData[15].bActive)
              num += this.DM.Trap_TreatmentQuantity;
            this.BarrackMax = this.mBR.Value1 - this.DM.TrapTotal - num;
            this.m_UnitRS.m_slider.maxValue = (double) this.BarrackMax;
            this.Cstr_UnitRS.ClearString();
            StringManager.IntToStr(this.Cstr_UnitRS, (long) this.BarrackMax, bNumber: true);
            this.m_UnitRS.m_TotalText.text = this.Cstr_UnitRS.ToString();
            this.m_UnitRS.m_TotalText.SetAllDirty();
            this.m_UnitRS.m_TotalText.cachedTextGenerator.Invalidate();
            effectBaseVal1 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAP_TRAINING_SPEED);
          }
          float effectBaseVal2 = (float) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED_DEBUFF);
          float num1 = (float) (10000U + effectBaseVal1) - effectBaseVal2;
          if ((double) num1 <= 100.0)
            num1 = 100f;
          this.tmpEGA = 10000f / num1;
          this.UnitMax = this.CheckMax(this.BarrackMax);
          this.SetDRformURS(this.m_UnitRS.GetComponent<Transform>(), this.m_UnitRS.m_slider.value);
          this.UpdateLcokBtnType();
          break;
        }
        uint x;
        if (this.mType == 0)
        {
          x = this.DM.RoleAttr.m_Soldier[(int) this.RD_ID - 1];
          this.BarrackMax = 0U;
          byte buildNumById = this.GUIM.BuildingData.GetBuildNumByID((ushort) 6);
          for (int Index = 0; Index < (int) buildNumById; ++Index)
          {
            this.mBD = this.GUIM.BuildingData.GetBuildData((ushort) 6, (ushort) Index);
            this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData((ushort) 6, this.mBD.Level);
            this.BarrackMax += this.mBR.Value1;
          }
          this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY);
          this.BarrackMax = this.BarrackMax * (10000U + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY_PERCENT)) / 10000U;
          this.m_UnitRS.MaxValue = (long) this.BarrackMax;
          this.m_UnitRS.m_slider.maxValue = (double) this.BarrackMax;
          this.Cstr_UnitRS.ClearString();
          StringManager.IntToStr(this.Cstr_UnitRS, (long) this.BarrackMax, bNumber: true);
          this.m_UnitRS.m_TotalText.text = this.Cstr_UnitRS.ToString();
          this.m_UnitRS.m_TotalText.SetAllDirty();
          this.m_UnitRS.m_TotalText.cachedTextGenerator.Invalidate();
        }
        else
        {
          x = this.DM.mTrapQty[(int) this.RD_ID - 17];
          this.mBD = this.GUIM.BuildingData.GetBuildData((ushort) 12, (ushort) 0);
          this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData((ushort) 12, this.mBD.Level);
          uint num = 0;
          if (this.DM.queueBarData[14].bActive)
            num += this.DM.TrapTrainingQty;
          if (this.DM.queueBarData[15].bActive)
            num += this.DM.Trap_TreatmentQuantity;
          this.BarrackMax = this.mBR.Value1 - this.DM.TrapTotal - num;
          this.m_UnitRS.MaxValue = (long) this.BarrackMax;
          this.m_UnitRS.m_slider.maxValue = (double) this.BarrackMax;
          this.Cstr_UnitRS.ClearString();
          StringManager.IntToStr(this.Cstr_UnitRS, (long) this.BarrackMax, bNumber: true);
          this.m_UnitRS.m_TotalText.text = this.Cstr_UnitRS.ToString();
          this.m_UnitRS.m_TotalText.SetAllDirty();
          this.m_UnitRS.m_TotalText.cachedTextGenerator.Invalidate();
        }
        this.UnitMax = this.CheckMax(this.BarrackMax);
        this.SetDRformURS(this.m_UnitRS.GetComponent<Transform>(), this.m_UnitRS.m_slider.value);
        this.tmpString.Length = 0;
        GameConstants.FormatValue(this.tmpString, x);
        this.text_SoldierNum.text = this.tmpString.ToString();
        this.text_Disband_Num.text = this.tmpString.ToString();
        if (x == 0U)
          this.btn_Disband.ForTextChange(e_BtnType.e_ChangeText);
        else
          this.btn_Disband.ForTextChange(e_BtnType.e_Normal);
        this.m_DisbandSlider.m_slider.maxValue = (double) x;
        this.Cstr_D2.ClearString();
        StringManager.IntToStr(this.Cstr_D2, (long) this.m_DisbandSlider.m_slider.value, bNumber: true);
        this.m_DisbandSlider.m_inputText.text = this.Cstr_D2.ToString();
        this.m_DisbandSlider.m_inputText.SetAllDirty();
        this.m_DisbandSlider.m_inputText.cachedTextGenerator.Invalidate();
        this.Cstr_D.ClearString();
        StringManager.IntToStr(this.Cstr_D, (long) x, bNumber: true);
        this.m_DisbandSlider.m_TotalText.text = this.Cstr_D.ToString();
        this.m_DisbandSlider.m_TotalText.SetAllDirty();
        this.m_DisbandSlider.m_TotalText.cachedTextGenerator.Invalidate();
        this.m_DisbandSlider.m_TotalText.cachedTextGeneratorForLayout.Invalidate();
        RectTransform component = ((Component) this.m_DisbandSlider.m_TotalText).transform.GetComponent<RectTransform>();
        if ((double) this.m_DisbandSlider.m_TotalText.preferredWidth > (double) component.sizeDelta.x)
          component.sizeDelta = new Vector2(this.m_DisbandSlider.m_TotalText.preferredWidth + 1f, component.sizeDelta.y);
        int index = 0;
        if (x / 1000U > 0U)
          index = x / 100000000U <= 0U ? (x / 10000000U <= 0U ? (x / 10000U <= 0U ? 1 : 2) : 3) : 4;
        this.DisbandSliderRT.anchoredPosition = new Vector2(this.Pos[index], this.DisbandSliderRT.anchoredPosition.y);
        this.DisbandSliderRT.sizeDelta = new Vector2(this.Width[index], this.DisbandSliderRT.sizeDelta.y);
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_tmpStr != (Object) null && ((Behaviour) this.text_tmpStr).enabled)
    {
      ((Behaviour) this.text_tmpStr).enabled = false;
      ((Behaviour) this.text_tmpStr).enabled = true;
    }
    if ((Object) this.text_SoldierNum != (Object) null && ((Behaviour) this.text_SoldierNum).enabled)
    {
      ((Behaviour) this.text_SoldierNum).enabled = false;
      ((Behaviour) this.text_SoldierNum).enabled = true;
    }
    if ((Object) this.text_Title != (Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((Object) this.text_Training != (Object) null && ((Behaviour) this.text_Training).enabled)
    {
      ((Behaviour) this.text_Training).enabled = false;
      ((Behaviour) this.text_Training).enabled = true;
    }
    if ((Object) this.text_TrainingCompleted != (Object) null && ((Behaviour) this.text_TrainingCompleted).enabled)
    {
      ((Behaviour) this.text_TrainingCompleted).enabled = false;
      ((Behaviour) this.text_TrainingCompleted).enabled = true;
    }
    if ((Object) this.text_Gemstone != (Object) null && ((Behaviour) this.text_Gemstone).enabled)
    {
      ((Behaviour) this.text_Gemstone).enabled = false;
      ((Behaviour) this.text_Gemstone).enabled = true;
    }
    if ((Object) this.text_Time != (Object) null && ((Behaviour) this.text_Time).enabled)
    {
      ((Behaviour) this.text_Time).enabled = false;
      ((Behaviour) this.text_Time).enabled = true;
    }
    if ((Object) this.text_RD != (Object) null && ((Behaviour) this.text_RD).enabled)
    {
      ((Behaviour) this.text_RD).enabled = false;
      ((Behaviour) this.text_RD).enabled = true;
    }
    if ((Object) this.text_RDbtn != (Object) null && ((Behaviour) this.text_RDbtn).enabled)
    {
      ((Behaviour) this.text_RDbtn).enabled = false;
      ((Behaviour) this.text_RDbtn).enabled = true;
    }
    if ((Object) this.text_Disband_Name != (Object) null && ((Behaviour) this.text_Disband_Name).enabled)
    {
      ((Behaviour) this.text_Disband_Name).enabled = false;
      ((Behaviour) this.text_Disband_Name).enabled = true;
    }
    if ((Object) this.text_Disband_Num != (Object) null && ((Behaviour) this.text_Disband_Num).enabled)
    {
      ((Behaviour) this.text_Disband_Num).enabled = false;
      ((Behaviour) this.text_Disband_Num).enabled = true;
    }
    if ((Object) this.text_Disband_Title != (Object) null && ((Behaviour) this.text_Disband_Title).enabled)
    {
      ((Behaviour) this.text_Disband_Title).enabled = false;
      ((Behaviour) this.text_Disband_Title).enabled = true;
    }
    if ((Object) this.text_Hint_Info != (Object) null && ((Behaviour) this.text_Hint_Info).enabled)
    {
      ((Behaviour) this.text_Hint_Info).enabled = false;
      ((Behaviour) this.text_Hint_Info).enabled = true;
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((Object) this.text_Disband[index] != (Object) null && ((Behaviour) this.text_Disband[index]).enabled)
      {
        ((Behaviour) this.text_Disband[index]).enabled = false;
        ((Behaviour) this.text_Disband[index]).enabled = true;
      }
      if ((Object) this.text_Hint[index] != (Object) null && ((Behaviour) this.text_Hint[index]).enabled)
      {
        ((Behaviour) this.text_Hint[index]).enabled = false;
        ((Behaviour) this.text_Hint[index]).enabled = true;
      }
    }
    for (int index = 0; index < 7; ++index)
    {
      if ((Object) this.text_Arms[index] != (Object) null && ((Behaviour) this.text_Arms[index]).enabled)
      {
        ((Behaviour) this.text_Arms[index]).enabled = false;
        ((Behaviour) this.text_Arms[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        if (this.GUIM.Barrack_Soldier_Lock != 2)
          break;
        uint effectBaseVal1;
        if (this.mType == 0)
        {
          this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY);
          this.BarrackMax = this.BarrackMax * (10000U + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY_PERCENT)) / 10000U;
          effectBaseVal1 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED);
          this.m_UnitRS.MaxValue = (long) this.BarrackMax;
          this.m_UnitRS.m_slider.maxValue = (double) this.BarrackMax;
          this.Cstr_UnitRS.ClearString();
          StringManager.IntToStr(this.Cstr_UnitRS, (long) this.BarrackMax, bNumber: true);
          this.m_UnitRS.m_TotalText.text = this.Cstr_UnitRS.ToString();
          this.m_UnitRS.m_TotalText.SetAllDirty();
          this.m_UnitRS.m_TotalText.cachedTextGenerator.Invalidate();
          uint num = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM) (79 + (((int) this.RD_Rank - 1) * 4 + (int) this.RD_Kind)));
          if (num >= 9900U)
            num = 9900U;
          this.tmpEGA_Cost = (float) (1.0 - (double) num / 10000.0);
        }
        else
        {
          this.mBD = this.GUIM.BuildingData.GetBuildData((ushort) 12, (ushort) 0);
          this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData((ushort) 12, this.mBD.Level);
          uint num = 0;
          if (this.DM.queueBarData[14].bActive)
            num += this.DM.TrapTrainingQty;
          if (this.DM.queueBarData[15].bActive)
            num += this.DM.Trap_TreatmentQuantity;
          this.BarrackMax = this.mBR.Value1 - this.DM.TrapTotal - num;
          this.m_UnitRS.m_slider.maxValue = (double) this.BarrackMax;
          this.Cstr_UnitRS.ClearString();
          StringManager.IntToStr(this.Cstr_UnitRS, (long) this.BarrackMax, bNumber: true);
          this.m_UnitRS.m_TotalText.text = this.Cstr_UnitRS.ToString();
          this.m_UnitRS.m_TotalText.SetAllDirty();
          this.m_UnitRS.m_TotalText.cachedTextGenerator.Invalidate();
          effectBaseVal1 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAP_TRAINING_SPEED);
        }
        float effectBaseVal2 = (float) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED_DEBUFF);
        float num1 = (float) (10000U + effectBaseVal1) - effectBaseVal2;
        if ((double) num1 <= 100.0)
          num1 = 100f;
        this.tmpEGA = 10000f / num1;
        this.UnitMax = this.CheckMax(this.BarrackMax);
        this.Cstr.ClearString();
        StringManager.IntToStr(this.Cstr, (long) this.UnitMax, bNumber: true);
        this.m_UnitRS.m_slider.value = (double) this.UnitMax;
        this.m_UnitRS.Value = (long) this.UnitMax;
        this.m_UnitRS.m_inputText.text = this.Cstr.ToString();
        this.m_UnitRS.m_inputText.SetAllDirty();
        this.m_UnitRS.m_inputText.cachedTextGenerator.Invalidate();
        this.SetDRformURS(this.m_UnitRS.GetComponent<Transform>(), (double) this.UnitMax);
        break;
      case 100:
        this.SendTrainImmed();
        break;
      case 101:
        this.SendTrackImmed();
        break;
    }
  }

  private void SetLockBtnType(int tpye = 0)
  {
    if ((Object) this.LockPanel == (Object) null || (Object) this.btn_Lock == (Object) null || (Object) this.Img_Lock == (Object) null || (Object) this.spArray == (Object) null)
      return;
    switch (tpye)
    {
      case 0:
        this.LockPanel.gameObject.SetActive(false);
        ((Component) this.Img_Lock).gameObject.SetActive(false);
        ((Component) this.btn_Lock).gameObject.SetActive(false);
        ((Component) this.Img_LockBG).gameObject.SetActive(false);
        break;
      case 1:
        this.btn_Lock.image.sprite = this.spArray.GetSprite(1);
        this.Img_Lock.sprite = this.spArray.GetSprite(3);
        ((Component) this.btn_Lock).gameObject.SetActive(true);
        ((Component) this.Img_Lock).gameObject.SetActive(true);
        this.LockPanel.gameObject.SetActive(true);
        ((Component) this.Img_LockBG).gameObject.SetActive(true);
        this.SetLockValue();
        break;
      case 2:
        this.btn_Lock.image.sprite = this.spArray.GetSprite(0);
        this.Img_Lock.sprite = this.spArray.GetSprite(2);
        ((Component) this.btn_Lock).gameObject.SetActive(true);
        ((Component) this.Img_Lock).gameObject.SetActive(true);
        this.LockPanel.gameObject.SetActive(false);
        ((Component) this.Img_LockBG).gameObject.SetActive(false);
        break;
    }
  }

  private void UpdateLcokBtnType()
  {
    if (this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 18 || !this.bRDOutput || this.mType == 1)
      this.SetLockBtnType();
    else
      this.SetLockBtnType(this.GUIM.Barrack_Soldier_Lock);
  }

  private void SetLockValue()
  {
    this.Cstr.ClearString();
    StringManager.IntToStr(this.Cstr, this.GUIM.Barrack_Soldier_SliderValue, bNumber: true);
    this.m_UnitRS.m_slider.value = (double) this.GUIM.Barrack_Soldier_SliderValue;
    this.m_UnitRS.Value = this.GUIM.Barrack_Soldier_SliderValue;
    this.m_UnitRS.m_inputText.text = this.Cstr.ToString();
    this.m_UnitRS.m_inputText.SetAllDirty();
    this.m_UnitRS.m_inputText.cachedTextGenerator.Invalidate();
  }
}
