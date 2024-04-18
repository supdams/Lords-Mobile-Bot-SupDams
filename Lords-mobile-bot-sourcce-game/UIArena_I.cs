// Decompiled with JetBrains decompiler
// Type: UIArena_I
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIArena_I : GUIWindow, IUIButtonClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private Transform GameT;
  private Door door;
  private Font TTFont;
  private UISpritesArray SArray;
  private RectTransform Content_RT;
  private RectTransform P1_RT;
  private RectTransform P2_RT;
  private UIButton btn_EXIT;
  private UIText text_Title;
  private UIText[] text_TitleP1 = new UIText[2];
  private UIText[] text_P1 = new UIText[7];
  private UIText[] text_TitleP2 = new UIText[2];
  private UIText[] text_P2;
  private CString Cstr_CDTime;
  private CString[] Cstr_P2;
  private CString[] Cstr_P2Reward;
  private int tmpItemNum;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    Material material = this.door.LoadMaterial();
    float num1 = 0.0f;
    this.Cstr_CDTime = StringManager.Instance.SpawnString(100);
    this.tmpItemNum = this.DM.ArenaRewardData.TableCount;
    this.Cstr_P2 = new CString[this.tmpItemNum];
    this.Cstr_P2Reward = new CString[this.tmpItemNum];
    this.text_P2 = new UIText[this.tmpItemNum * 2];
    for (int index = 0; index < this.tmpItemNum; ++index)
    {
      this.Cstr_P2[index] = StringManager.Instance.SpawnString();
      this.Cstr_P2Reward[index] = StringManager.Instance.SpawnString();
    }
    this.text_Title = this.GameT.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.text_Title.text = this.DM.mStringTable.GetStringByID(9128U);
    Transform child1 = this.GameT.GetChild(1);
    this.Content_RT = child1.GetChild(0).GetComponent<RectTransform>();
    Transform child2 = child1.GetChild(0).GetChild(0);
    this.P1_RT = child2.GetComponent<RectTransform>();
    this.text_TitleP1[0] = child2.GetChild(0).GetComponent<UIText>();
    this.text_TitleP1[0].font = this.TTFont;
    this.text_TitleP1[0].text = this.DM.mStringTable.GetStringByID(9129U);
    float num2 = num1 + ((Graphic) this.text_TitleP1[0]).rectTransform.sizeDelta.y;
    for (int index = 0; index < 5; ++index)
    {
      Transform child3 = child2.GetChild(1 + index);
      this.text_P1[index] = child3.GetComponent<UIText>();
      this.text_P1[index].font = this.TTFont;
      this.text_P1[index].text = this.DM.mStringTable.GetStringByID((uint) (9130 + index));
      this.text_P1[index].SetAllDirty();
      this.text_P1[index].cachedTextGenerator.Invalidate();
      this.text_P1[index].cachedTextGeneratorForLayout.Invalidate();
      if ((double) ((Graphic) this.text_P1[index]).rectTransform.sizeDelta.y < (double) this.text_P1[index].preferredHeight)
        ((Graphic) this.text_P1[index]).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_P1[index]).rectTransform.sizeDelta.x, this.text_P1[index].preferredHeight + 1f);
      if (index == 0)
        ((Graphic) this.text_P1[0]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_P1[0]).rectTransform.anchoredPosition.x, (float) -(12.0 + (double) num2));
      else
        ((Graphic) this.text_P1[index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_P1[index]).rectTransform.anchoredPosition.x, (float) ((double) ((Graphic) this.text_P1[index - 1]).rectTransform.anchoredPosition.y - (double) ((Graphic) this.text_P1[index - 1]).rectTransform.sizeDelta.y - 2.0));
      num2 += ((Graphic) this.text_P1[index]).rectTransform.sizeDelta.y;
    }
    CString tmpS = StringManager.Instance.StaticString1024();
    tmpS.ClearString();
    this.Cstr_CDTime.ClearString();
    tmpS.IntToFormat((long) GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Hour, 2);
    tmpS.IntToFormat((long) GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Minute, 2);
    tmpS.AppendFormat("{0}:{1}");
    this.Cstr_CDTime.StringToFormat(tmpS);
    this.Cstr_CDTime.AppendFormat(this.DM.mStringTable.GetStringByID(9134U));
    this.text_P1[4].text = this.Cstr_CDTime.ToString();
    this.text_P1[5] = child2.GetChild(6).GetComponent<UIText>();
    this.text_P1[5].font = this.TTFont;
    this.text_P1[5].text = this.DM.mStringTable.GetStringByID(9135U);
    if ((double) ((Graphic) this.text_P1[5]).rectTransform.sizeDelta.y < (double) this.text_P1[5].preferredHeight)
      ((Graphic) this.text_P1[5]).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_P1[5]).rectTransform.sizeDelta.x, this.text_P1[5].preferredHeight + 1f);
    ((Graphic) this.text_P1[5]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_P1[5]).rectTransform.anchoredPosition.x, (float) ((double) ((Graphic) this.text_P1[4]).rectTransform.anchoredPosition.y - (double) ((Graphic) this.text_P1[4]).rectTransform.sizeDelta.y - 2.0));
    float num3 = num2 + ((Graphic) this.text_P1[5]).rectTransform.sizeDelta.y;
    this.text_TitleP1[1] = child2.GetChild(7).GetComponent<UIText>();
    this.text_TitleP1[1].font = this.TTFont;
    this.text_TitleP1[1].text = this.DM.mStringTable.GetStringByID(9151U);
    ((Graphic) this.text_TitleP1[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_TitleP1[1]).rectTransform.anchoredPosition.x, (float) ((double) ((Graphic) this.text_P1[5]).rectTransform.anchoredPosition.y - (double) ((Graphic) this.text_P1[5]).rectTransform.sizeDelta.y - 20.0));
    float num4 = num3 + ((Graphic) this.text_TitleP1[1]).rectTransform.sizeDelta.y;
    this.text_P1[6] = child2.GetChild(8).GetComponent<UIText>();
    this.text_P1[6].font = this.TTFont;
    this.text_P1[6].text = this.DM.mStringTable.GetStringByID(9136U);
    this.text_P1[6].SetAllDirty();
    this.text_P1[6].cachedTextGenerator.Invalidate();
    this.text_P1[6].cachedTextGeneratorForLayout.Invalidate();
    if ((double) ((Graphic) this.text_P1[6]).rectTransform.sizeDelta.y < (double) this.text_P1[6].preferredHeight)
      ((Graphic) this.text_P1[6]).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_P1[6]).rectTransform.sizeDelta.x, this.text_P1[6].preferredHeight + 1f);
    ((Graphic) this.text_P1[6]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_P1[6]).rectTransform.anchoredPosition.x, (float) ((double) ((Graphic) this.text_TitleP1[1]).rectTransform.anchoredPosition.y - (double) ((Graphic) this.text_TitleP1[1]).rectTransform.sizeDelta.y + 2.0));
    float y1 = num4 + ((Graphic) this.text_P1[6]).rectTransform.sizeDelta.y + 60f;
    this.P1_RT.sizeDelta = new Vector2(this.P1_RT.sizeDelta.x, y1);
    this.Content_RT.sizeDelta = new Vector2(this.Content_RT.sizeDelta.x, y1);
    Transform child4 = child1.GetChild(0).GetChild(1);
    this.P2_RT = child4.GetComponent<RectTransform>();
    this.P2_RT.anchoredPosition = new Vector2(this.P2_RT.anchoredPosition.x, -y1);
    float y2 = 0.0f + child4.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;
    this.text_TitleP2[0] = child4.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_TitleP2[0].font = this.TTFont;
    this.text_TitleP2[0].text = this.DM.mStringTable.GetStringByID(9137U);
    this.text_TitleP2[1] = child4.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_TitleP2[1].font = this.TTFont;
    this.text_TitleP2[1].text = this.DM.mStringTable.GetStringByID(9140U);
    Image component1 = child4.GetChild(2).GetComponent<Image>();
    for (int index1 = 0; index1 < this.tmpItemNum; ++index1)
    {
      GameObject gameObject = (GameObject) Object.Instantiate((Object) ((Component) component1).gameObject);
      gameObject.transform.SetParent(((Component) this.P2_RT).transform, false);
      gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(((Graphic) component1).rectTransform.anchoredPosition.x, -y2);
      gameObject.SetActive(true);
      y2 += ((Graphic) component1).rectTransform.sizeDelta.y;
      if (index1 % 2 == 1)
      {
        gameObject.transform.GetComponent<Image>().sprite = this.SArray.m_Sprites[0];
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = this.SArray.m_Sprites[1];
      }
      for (int index2 = 0; index2 < 2; ++index2)
      {
        Transform child5 = gameObject.transform.GetChild(2 + index2);
        this.text_P2[index1 * 2 + index2] = child5.GetComponent<UIText>();
        this.text_P2[index1 * 2 + index2].font = this.TTFont;
      }
    }
    this.P2_RT.sizeDelta = new Vector2(this.P2_RT.sizeDelta.x, y2);
    this.Content_RT.sizeDelta = new Vector2(this.Content_RT.sizeDelta.x, this.Content_RT.sizeDelta.y + y2);
    this.DM.ArenaRewardData.GetRecordByIndex(0);
    for (int Index = 0; Index < this.tmpItemNum; ++Index)
    {
      this.Cstr_P2[Index].ClearString();
      ArenaReward recordByIndex = this.DM.ArenaRewardData.GetRecordByIndex((int) (ushort) Index);
      if ((int) recordByIndex.Value1 == (int) recordByIndex.Value2)
      {
        this.Cstr_P2[Index].IntToFormat((long) recordByIndex.Value1, bNumber: true);
        this.Cstr_P2[Index].AppendFormat(this.DM.mStringTable.GetStringByID(9138U));
      }
      else
      {
        this.Cstr_P2[Index].IntToFormat((long) recordByIndex.Value1, bNumber: true);
        this.Cstr_P2[Index].IntToFormat((long) recordByIndex.Value2, bNumber: true);
        this.Cstr_P2[Index].AppendFormat(this.DM.mStringTable.GetStringByID(9139U));
      }
      this.text_P2[Index * 2].text = this.Cstr_P2[Index].ToString();
      this.Cstr_P2Reward[Index].ClearString();
      this.Cstr_P2Reward[Index].IntToFormat((long) recordByIndex.Crystal, bNumber: true);
      this.Cstr_P2Reward[Index].AppendFormat("{0}");
      this.text_P2[Index * 2 + 1].text = this.Cstr_P2Reward[Index].ToString();
    }
    Image component2 = this.GameT.GetChild(2).GetComponent<Image>();
    component2.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component2).material = material;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) component2).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(2).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = material;
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    if (this.Cstr_CDTime != null)
      StringManager.Instance.DeSpawnString(this.Cstr_CDTime);
    for (int index = 0; index < this.tmpItemNum; ++index)
    {
      if (this.Cstr_P2[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_P2[index]);
      if (this.Cstr_P2Reward[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_P2Reward[index]);
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 != 0 || !((Object) this.door != (Object) null))
      return;
    this.door.CloseMenu();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Title != (Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_TitleP1[index] != (Object) null && ((Behaviour) this.text_TitleP1[index]).enabled)
      {
        ((Behaviour) this.text_TitleP1[index]).enabled = false;
        ((Behaviour) this.text_TitleP1[index]).enabled = true;
      }
      if ((Object) this.text_TitleP2[index] != (Object) null && ((Behaviour) this.text_TitleP2[index]).enabled)
      {
        ((Behaviour) this.text_TitleP2[index]).enabled = false;
        ((Behaviour) this.text_TitleP2[index]).enabled = true;
      }
    }
    for (int index = 0; index < this.tmpItemNum * 2; ++index)
    {
      if ((Object) this.text_P2[index] != (Object) null && ((Behaviour) this.text_P2[index]).enabled)
      {
        ((Behaviour) this.text_P2[index]).enabled = false;
        ((Behaviour) this.text_P2[index]).enabled = true;
      }
    }
    for (int index = 0; index < 7; ++index)
    {
      if ((Object) this.text_P1[index] != (Object) null && ((Behaviour) this.text_P1[index]).enabled)
      {
        ((Behaviour) this.text_P1[index]).enabled = false;
        ((Behaviour) this.text_P1[index]).enabled = true;
      }
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
