// Decompiled with JetBrains decompiler
// Type: UIDefenders
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIDefenders : GUIWindow, IUIButtonClickHandler, IUIHIBtnClickHandler
{
  private const int TextMax = 13;
  private Door door;
  private CString m_Str;
  private UISpritesArray m_SpArray;
  private float m_ColorTick;
  private float m_ColorA;
  private Image m_FlashLord;
  private int MaxDefender;
  private int CanSelectNum;
  private int SelectNum;
  private bool[] IsFight = new bool[5];
  private Font TTF;
  private int mTextCount;
  private UIText[] m_tmptext = new UIText[13];
  private UIHIBtn[] m_HiBtn = new UIHIBtn[5];
  private UIText[] m_HeroTextTemp1 = new UIText[5];
  private UIText[] m_HeroTextTemp2 = new UIText[5];
  private UIText m_HeroTextTemp3;

  public override void OnOpen(int arg1, int arg2)
  {
    this.CanSelectNum = 0;
    this.SelectNum = 0;
    GUIManager instance1 = GUIManager.Instance;
    DataManager instance2 = DataManager.Instance;
    this.TTF = instance1.GetTTFFont();
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (UnityEngine.Object) this.door)
      return;
    this.MaxDefender = instance2.GetMaxDefenders();
    this.m_SpArray = this.transform.GetComponent<UISpritesArray>();
    this.m_tmptext[this.mTextCount] = this.transform.GetChild(0).GetChild(8).GetChild(0).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    this.m_tmptext[this.mTextCount].text = DataManager.Instance.mStringTable.GetStringByID(3744U);
    ++this.mTextCount;
    Image component1 = this.transform.GetChild(4).GetComponent<Image>();
    component1.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component1).material = this.door.LoadMaterial();
    if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (UnityEngine.Object) component1)
      ((Behaviour) component1).enabled = false;
    UIButton component2 = this.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 0;
    component2.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component2.image).material = this.door.LoadMaterial();
    this.m_tmptext[this.mTextCount] = this.transform.GetChild(1).GetChild(2).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    this.m_tmptext[this.mTextCount].text = instance2.mStringTable.GetStringByID(3752U);
    ++this.mTextCount;
    this.m_FlashLord = this.transform.GetChild(3).GetChild(0).GetComponent<Image>();
    this.SetData();
  }

  private void SetData()
  {
    GUIManager instance1 = GUIManager.Instance;
    DataManager instance2 = DataManager.Instance;
    this.CheckFight();
    for (int index = 0; index < 5; ++index)
    {
      Transform child = this.transform.GetChild(2).GetChild(index);
      UIHIBtn component1 = child.GetChild(1).GetComponent<UIHIBtn>();
      component1.m_BtnID1 = index;
      component1.m_Handler = (IUIHIBtnClickHandler) this;
      this.m_HiBtn[index] = component1;
      UIButton component2 = child.GetChild(2).GetChild(0).GetComponent<UIButton>();
      component2.m_Handler = (IUIButtonClickHandler) this;
      component2.m_BtnID1 = 1;
      if (index < this.MaxDefender)
      {
        if (instance2.m_DefendersID[index] != (ushort) 0)
        {
          if (DataManager.Instance.curHeroData.ContainsKey((uint) instance2.m_DefendersID[index]))
          {
            CurHeroData curHeroData = instance2.curHeroData[(uint) instance2.m_DefendersID[index]];
            Hero recordByKey = instance2.HeroTable.GetRecordByKey(curHeroData.ID);
            UIHIBtn component3 = child.GetChild(1).GetComponent<UIHIBtn>();
            instance1.InitianHeroItemImg(((Component) component3).transform, eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, curHeroData.Enhance, (int) curHeroData.Level, bAutoShowHint: false);
            this.m_HeroTextTemp1[index] = child.GetChild(4).GetChild(0).GetComponent<UIText>();
            this.m_HeroTextTemp1[index] = child.GetChild(4).GetChild(0).GetComponent<UIText>();
            this.m_HeroTextTemp1[index].font = this.TTF;
            this.m_HeroTextTemp1[index].text = instance2.mStringTable.GetStringByID((uint) recordByKey.HeroTitle);
            eHeroState heroState = instance2.GetHeroState(recordByKey.HeroKey);
            Image component4 = child.GetChild(6).GetComponent<Image>();
            if (heroState == eHeroState.None)
            {
              ((Behaviour) component4).enabled = false;
              ((Graphic) component3.HIImage).color = new Color(1f, 1f, 1f, 1f);
              ((Graphic) component3.CircleImage).color = new Color(1f, 1f, 1f, 1f);
              ((Graphic) component3.HeroRankImage).color = new Color(1f, 1f, 1f, 1f);
              ((Graphic) component3.LvOrNum).color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
              if (heroState == eHeroState.IsFighting)
                component4.sprite = this.m_SpArray.GetSprite(0);
              if (heroState == eHeroState.Captured)
                component4.sprite = this.m_SpArray.GetSprite(1);
              if (heroState == eHeroState.Dead)
                component4.sprite = this.m_SpArray.GetSprite(2);
              ((Graphic) component3.HIImage).color = new Color(0.5f, 0.5f, 0.5f, 1f);
              ((Graphic) component3.CircleImage).color = new Color(0.5f, 0.5f, 0.5f, 1f);
              ((Graphic) component3.HeroRankImage).color = new Color(0.5f, 0.5f, 0.5f, 1f);
              ((Graphic) component3.LvOrNum).color = new Color(0.5f, 0.5f, 0.5f, 1f);
              ((Behaviour) component4).enabled = true;
            }
            ++this.SelectNum;
          }
          else
            continue;
        }
        else
        {
          child.GetChild(1).gameObject.SetActive(false);
          child.GetChild(4).gameObject.SetActive(false);
          child.GetChild(2).gameObject.SetActive(true);
          ((MaskableGraphic) child.GetChild(2).GetComponent<Image>()).material = instance1.GetFrameMaterial();
          child.GetChild(2).GetComponent<Image>().sprite = instance1.LoadFrameSprite("hf000");
          UIButton component5 = child.GetChild(2).GetChild(0).GetComponent<UIButton>();
          component5.m_BtnID1 = 1;
          component5.m_Handler = (IUIButtonClickHandler) this;
        }
      }
      else
      {
        child.GetChild(1).gameObject.SetActive(false);
        child.GetChild(4).gameObject.SetActive(false);
        child.GetChild(3).gameObject.SetActive(true);
        ((MaskableGraphic) child.GetChild(3).GetComponent<Image>()).material = instance1.GetFrameMaterial();
        child.GetChild(3).GetComponent<Image>().sprite = instance1.LoadFrameSprite("hf000");
        UIButton component6 = child.GetChild(3).GetComponent<UIButton>();
        component6.m_Handler = (IUIButtonClickHandler) this;
        component6.m_BtnID1 = 2;
      }
      this.m_HeroTextTemp2[index] = child.GetChild(4).GetChild(0).GetComponent<UIText>();
      this.m_HeroTextTemp2[index].font = this.TTF;
    }
    this.m_HeroTextTemp3 = this.transform.GetChild(1).GetChild(3).GetComponent<UIText>();
    this.m_Str = StringManager.Instance.SpawnString();
    this.m_Str.ClearString();
    StringManager.Instance.IntToFormat((long) this.GetCanSelectNum());
    this.m_Str.AppendFormat(instance2.mStringTable.GetStringByID(3753U));
    this.m_HeroTextTemp3.font = this.TTF;
    this.m_HeroTextTemp3.text = this.m_Str.ToString();
  }

  private int GetCanSelectNum()
  {
    DataManager instance = DataManager.Instance;
    int canSelectNum = 0;
    for (int index1 = 0; (long) index1 < (long) instance.NonFightHeroCount; ++index1)
    {
      bool flag = true;
      for (int index2 = 0; index2 < instance.m_DefendersID.Length && index2 < this.IsFight.Length; ++index2)
      {
        if ((int) instance.NonFightHeroID[index1] == (int) instance.m_DefendersID[index2])
          flag = false;
      }
      if (flag)
        ++canSelectNum;
    }
    return canSelectNum;
  }

  private void CheckFight()
  {
    DataManager instance = DataManager.Instance;
    Array.Clear((Array) this.IsFight, 0, this.IsFight.Length);
    for (int index1 = 0; index1 < instance.FightHeroID.Length; ++index1)
    {
      for (int index2 = 0; index2 < instance.m_DefendersID.Length && index2 < this.IsFight.Length; ++index2)
      {
        if ((int) instance.FightHeroID[index1] == (int) instance.m_DefendersID[index2])
          this.IsFight[index2] = true;
      }
    }
  }

  public override void OnClose()
  {
    if (this.m_Str == null)
      return;
    StringManager.Instance.DeSpawnString(this.m_Str);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
      case NetworkNews.Refresh_Hero:
        this.SetData();
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    for (int index = 0; index < 13; ++index)
    {
      if ((UnityEngine.Object) this.m_tmptext[index] != (UnityEngine.Object) null && ((Behaviour) this.m_tmptext[index]).enabled)
      {
        ((Behaviour) this.m_tmptext[index]).enabled = false;
        ((Behaviour) this.m_tmptext[index]).enabled = true;
      }
    }
    for (int index = 0; index < this.m_HeroTextTemp1.Length; ++index)
    {
      if ((UnityEngine.Object) this.m_HeroTextTemp1[index] != (UnityEngine.Object) null && ((Behaviour) this.m_HeroTextTemp1[index]).enabled)
      {
        ((Behaviour) this.m_HeroTextTemp1[index]).enabled = false;
        ((Behaviour) this.m_HeroTextTemp1[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.m_HeroTextTemp2[index] != (UnityEngine.Object) null && ((Behaviour) this.m_HeroTextTemp2[index]).enabled)
      {
        ((Behaviour) this.m_HeroTextTemp2[index]).enabled = false;
        ((Behaviour) this.m_HeroTextTemp2[index]).enabled = true;
      }
    }
    if ((UnityEngine.Object) this.m_HeroTextTemp3 != (UnityEngine.Object) null && ((Behaviour) this.m_HeroTextTemp3).enabled)
    {
      ((Behaviour) this.m_HeroTextTemp3).enabled = false;
      ((Behaviour) this.m_HeroTextTemp3).enabled = true;
    }
    if (this.m_HiBtn == null)
      return;
    for (int index = 0; index < this.m_HiBtn.Length; ++index)
      this.m_HiBtn[index].Refresh_FontTexture();
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
  }

  public override bool OnBackButtonClick() => false;

  public void OnHIButtonClick(UIHIBtn sender)
  {
    this.door.OpenMenu(EGUIWindow.UI_HeroList_Soldier2, 1);
  }

  private void Update()
  {
    this.m_ColorTick += Time.deltaTime;
    if ((double) this.m_ColorTick < 0.05000000074505806)
      return;
    this.m_ColorA += 0.1f;
    if ((double) this.m_ColorA >= 2.0)
      this.m_ColorA = 0.0f;
    for (int index = 0; index < 3; ++index)
    {
      if ((UnityEngine.Object) this.m_FlashLord != (UnityEngine.Object) null)
      {
        if ((double) this.m_ColorA > 1.0)
          ((Graphic) this.m_FlashLord).color = new Color(1f, 1f, 1f, 2f - this.m_ColorA);
        else
          ((Graphic) this.m_FlashLord).color = new Color(1f, 1f, 1f, this.m_ColorA);
      }
    }
    this.m_ColorTick = 0.0f;
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 0)
    {
      if (!(bool) (UnityEngine.Object) this.door)
        return;
      this.door.CloseMenu();
    }
    else if (sender.m_BtnID1 == 1)
    {
      this.door.OpenMenu(EGUIWindow.UI_HeroList_Soldier2, 1);
    }
    else
    {
      if (sender.m_BtnID1 != 2)
        return;
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(330U), (ushort) byte.MaxValue);
    }
  }
}
