// Decompiled with JetBrains decompiler
// Type: UIArena_Info
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIArena_Info : GUIWindow, IUIButtonClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private ArenaManager AM;
  private Transform GameT;
  private Door door;
  private Font TTFont;
  private UIButton btn_EXIT;
  private Image ImgNowCD;
  private Image ImgNextCD;
  private UIText text_Title;
  private UIText text_NowTopic;
  private UIText text_NextTopic;
  private UIText text_Info;
  private UIText text_Close;
  private UIText[] text_NowTopic_Info = new UIText[2];
  private UIText[] text_NextTopic_Info = new UIText[2];
  private UIText[] text_NowCD = new UIText[2];
  private UIText[] text_NextCD = new UIText[2];
  private CString Cstr_NowCD;
  private CString Cstr_NextCD;
  private CString[] Cstr_NowTopic_Info = new CString[2];
  private CString[] Cstr_NextTopic_Info = new CString[2];

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.AM = ArenaManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    Material material = this.door.LoadMaterial();
    this.Cstr_NowCD = StringManager.Instance.SpawnString();
    this.Cstr_NextCD = StringManager.Instance.SpawnString();
    for (int index = 0; index < 2; ++index)
    {
      this.Cstr_NowTopic_Info[index] = StringManager.Instance.SpawnString(100);
      this.Cstr_NextTopic_Info[index] = StringManager.Instance.SpawnString(100);
    }
    Transform child1 = this.GameT.GetChild(0);
    this.text_Title = child1.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.text_Title.text = this.DM.mStringTable.GetStringByID(9111U);
    this.text_Info = child1.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_Info.font = this.TTFont;
    this.text_Info.text = this.DM.mStringTable.GetStringByID(9112U);
    Transform child2 = this.GameT.GetChild(1);
    this.ImgNowCD = child2.GetChild(0).GetComponent<Image>();
    for (int index = 0; index < 2; ++index)
    {
      Transform child3 = child2.GetChild(0).GetChild(index);
      this.text_NowCD[index] = child3.GetComponent<UIText>();
      this.text_NowCD[index].font = this.TTFont;
    }
    this.text_NowCD[0].text = this.DM.mStringTable.GetStringByID(9114U);
    this.text_NowTopic = child2.GetChild(1).GetComponent<UIText>();
    this.text_NowTopic.font = this.TTFont;
    this.text_NowTopic.text = this.DM.mStringTable.GetStringByID(9113U);
    this.text_Close = child2.GetChild(2).GetComponent<UIText>();
    this.text_Close.font = this.TTFont;
    this.text_Close.text = this.DM.mStringTable.GetStringByID(9109U);
    for (int index = 0; index < 2; ++index)
    {
      Transform child4 = child2.GetChild(3 + index);
      this.text_NowTopic_Info[index] = child4.GetComponent<UIText>();
      this.text_NowTopic_Info[index].font = this.TTFont;
      this.Cstr_NowTopic_Info[index].ClearString();
    }
    Transform child5 = this.GameT.GetChild(2);
    this.ImgNextCD = child5.GetChild(0).GetComponent<Image>();
    for (int index = 0; index < 2; ++index)
    {
      Transform child6 = child5.GetChild(0).GetChild(index);
      this.text_NextCD[index] = child6.GetComponent<UIText>();
      this.text_NextCD[index].font = this.TTFont;
    }
    this.text_NextCD[0].text = this.DM.mStringTable.GetStringByID(9121U);
    this.text_NextTopic = child5.GetChild(1).GetComponent<UIText>();
    this.text_NextTopic.font = this.TTFont;
    this.text_NextTopic.text = this.DM.mStringTable.GetStringByID(9117U);
    for (int index = 0; index < 2; ++index)
    {
      Transform child7 = child5.GetChild(2 + index);
      this.text_NextTopic_Info[index] = child7.GetComponent<UIText>();
      this.text_NextTopic_Info[index].font = this.TTFont;
    }
    this.SetTopic();
    Image component = this.GameT.GetChild(3).GetComponent<Image>();
    component.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component).material = material;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) component).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(3).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = material;
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public void SetTopic()
  {
    CString cstring1 = StringManager.Instance.StaticString1024();
    CString cstring2 = StringManager.Instance.StaticString1024();
    for (int index = 0; index < 2; ++index)
      ((Component) this.text_NextTopic_Info[index]).gameObject.SetActive(true);
    this.Cstr_NowTopic_Info[0].ClearString();
    this.Cstr_NowTopic_Info[1].ClearString();
    this.Cstr_NextTopic_Info[0].ClearString();
    this.Cstr_NextTopic_Info[1].ClearString();
    if (!this.AM.bArenaKVK)
    {
      ((Component) this.ImgNowCD).gameObject.SetActive(true);
      ((Component) this.ImgNextCD).gameObject.SetActive(false);
      for (int index = 0; index < 2; ++index)
        ((Component) this.text_NowTopic_Info[index]).gameObject.SetActive(true);
      if (this.AM.m_NowArenaTopicID[0] != (byte) 0 && this.AM.m_NowArenaTopicID[1] != (byte) 0)
      {
        this.Cstr_NowTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200U + (uint) this.AM.m_NowArenaTopicID[0]));
        this.Cstr_NowTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200U + (uint) this.AM.m_NowArenaTopicID[1]));
        this.Cstr_NowTopic_Info[0].AppendFormat(this.DM.mStringTable.GetStringByID(9115U));
      }
      else
      {
        if (this.AM.m_NowArenaTopicID[0] != (byte) 0)
          this.Cstr_NowTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200U + (uint) this.AM.m_NowArenaTopicID[0]));
        else
          this.Cstr_NowTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200U + (uint) this.AM.m_NowArenaTopicID[1]));
        this.Cstr_NowTopic_Info[0].AppendFormat(this.DM.mStringTable.GetStringByID(9152U));
      }
      this.text_NowTopic_Info[0].text = this.Cstr_NowTopic_Info[0].ToString();
      this.text_NowTopic_Info[0].SetAllDirty();
      this.text_NowTopic_Info[0].cachedTextGenerator.Invalidate();
      this.text_NowTopic_Info[0].cachedTextGeneratorForLayout.Invalidate();
      if ((double) this.text_NowTopic_Info[0].preferredHeight > (double) ((Graphic) this.text_NowTopic_Info[0]).rectTransform.sizeDelta.y)
        ((Graphic) this.text_NowTopic_Info[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_NowTopic_Info[0]).rectTransform.sizeDelta.x, this.text_NowTopic_Info[0].preferredHeight + 1f);
      ((Graphic) this.text_NowTopic_Info[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_NowTopic_Info[0]).rectTransform.anchoredPosition.x, ((Graphic) this.text_NowTopic_Info[0]).rectTransform.anchoredPosition.y - (float) ((double) this.text_NowTopic_Info[0].preferredHeight + 1.0 + 14.0));
      cstring1.ClearString();
      cstring2.ClearString();
      if (this.AM.m_NowTopicEffect[0].Effect != (ushort) 0 && this.AM.m_NowTopicEffect[1].Effect != (ushort) 0)
      {
        GameConstants.GetEffectValue(cstring1, this.AM.m_NowTopicEffect[0].Effect, (uint) this.AM.m_NowTopicEffect[0].Value, (byte) 10, 0.0f);
        GameConstants.GetEffectValue(cstring2, this.AM.m_NowTopicEffect[1].Effect, (uint) this.AM.m_NowTopicEffect[1].Value, (byte) 10, 0.0f);
        this.Cstr_NowTopic_Info[1].StringToFormat(cstring1);
        this.Cstr_NowTopic_Info[1].StringToFormat(cstring2);
        this.Cstr_NowTopic_Info[1].AppendFormat(this.DM.mStringTable.GetStringByID(9116U));
      }
      else
      {
        if (this.AM.m_NowTopicEffect[0].Effect != (ushort) 0)
          GameConstants.GetEffectValue(cstring1, this.AM.m_NowTopicEffect[0].Effect, (uint) this.AM.m_NowTopicEffect[0].Value, (byte) 10, 0.0f);
        else
          GameConstants.GetEffectValue(cstring1, this.AM.m_NowTopicEffect[1].Effect, (uint) this.AM.m_NowTopicEffect[1].Value, (byte) 10, 0.0f);
        this.Cstr_NowTopic_Info[1].StringToFormat(cstring1);
        this.Cstr_NowTopic_Info[1].AppendFormat(this.DM.mStringTable.GetStringByID(9153U));
      }
      this.text_NowTopic_Info[1].text = this.Cstr_NowTopic_Info[1].ToString();
      this.text_NowTopic_Info[1].SetAllDirty();
      this.text_NowTopic_Info[1].cachedTextGenerator.Invalidate();
      this.text_NowTopic_Info[1].cachedTextGeneratorForLayout.Invalidate();
      if ((double) this.text_NowTopic_Info[1].preferredHeight > (double) ((Graphic) this.text_NowTopic_Info[1]).rectTransform.sizeDelta.y)
        ((Graphic) this.text_NowTopic_Info[1]).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_NowTopic_Info[1]).rectTransform.sizeDelta.x, this.text_NowTopic_Info[1].preferredHeight + 1f);
      if (this.AM.m_NextArenaTopicID[0] != (byte) 0 && this.AM.m_NextArenaTopicID[1] != (byte) 0)
      {
        this.Cstr_NextTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200U + (uint) this.AM.m_NextArenaTopicID[0]));
        this.Cstr_NextTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200U + (uint) this.AM.m_NextArenaTopicID[1]));
        this.Cstr_NextTopic_Info[0].AppendFormat(this.DM.mStringTable.GetStringByID(9115U));
      }
      else
      {
        if (this.AM.m_NextArenaTopicID[0] != (byte) 0)
          this.Cstr_NextTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200U + (uint) this.AM.m_NextArenaTopicID[0]));
        else
          this.Cstr_NextTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200U + (uint) this.AM.m_NextArenaTopicID[1]));
        this.Cstr_NextTopic_Info[0].AppendFormat(this.DM.mStringTable.GetStringByID(9152U));
      }
      this.text_NextTopic_Info[0].text = this.Cstr_NextTopic_Info[0].ToString();
      this.text_NextTopic_Info[0].SetAllDirty();
      this.text_NextTopic_Info[0].cachedTextGenerator.Invalidate();
      this.text_NextTopic_Info[0].cachedTextGeneratorForLayout.Invalidate();
      if ((double) this.text_NextTopic_Info[0].preferredHeight > (double) ((Graphic) this.text_NextTopic_Info[0]).rectTransform.sizeDelta.y)
        ((Graphic) this.text_NextTopic_Info[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_NextTopic_Info[0]).rectTransform.sizeDelta.x, this.text_NextTopic_Info[0].preferredHeight + 1f);
      ((Graphic) this.text_NextTopic_Info[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_NextTopic_Info[0]).rectTransform.anchoredPosition.x, ((Graphic) this.text_NextTopic_Info[0]).rectTransform.anchoredPosition.y - (float) ((double) this.text_NextTopic_Info[0].preferredHeight + 1.0 + 14.0));
      cstring1.ClearString();
      cstring2.ClearString();
      if (this.AM.m_NextTopicEffect[0].Effect != (ushort) 0 && this.AM.m_NextTopicEffect[1].Effect != (ushort) 0)
      {
        GameConstants.GetEffectValue(cstring1, this.AM.m_NextTopicEffect[0].Effect, (uint) this.AM.m_NextTopicEffect[0].Value, (byte) 10, 0.0f);
        GameConstants.GetEffectValue(cstring2, this.AM.m_NextTopicEffect[1].Effect, (uint) this.AM.m_NextTopicEffect[1].Value, (byte) 10, 0.0f);
        this.Cstr_NextTopic_Info[1].StringToFormat(cstring1);
        this.Cstr_NextTopic_Info[1].StringToFormat(cstring2);
        this.Cstr_NextTopic_Info[1].AppendFormat(this.DM.mStringTable.GetStringByID(9116U));
      }
      else
      {
        if (this.AM.m_NextTopicEffect[0].Effect != (ushort) 0)
          GameConstants.GetEffectValue(cstring1, this.AM.m_NextTopicEffect[0].Effect, (uint) this.AM.m_NextTopicEffect[0].Value, (byte) 10, 0.0f);
        else
          GameConstants.GetEffectValue(cstring1, this.AM.m_NextTopicEffect[1].Effect, (uint) this.AM.m_NextTopicEffect[1].Value, (byte) 10, 0.0f);
        this.Cstr_NextTopic_Info[1].StringToFormat(cstring1);
        this.Cstr_NextTopic_Info[1].AppendFormat(this.DM.mStringTable.GetStringByID(9153U));
      }
      this.text_NextTopic_Info[1].text = this.Cstr_NextTopic_Info[1].ToString();
      this.text_NextTopic_Info[1].SetAllDirty();
      this.text_NextTopic_Info[1].cachedTextGenerator.Invalidate();
      this.text_NextTopic_Info[1].cachedTextGeneratorForLayout.Invalidate();
      if ((double) this.text_NextTopic_Info[1].preferredHeight > (double) ((Graphic) this.text_NextTopic_Info[1]).rectTransform.sizeDelta.y)
        ((Graphic) this.text_NextTopic_Info[1]).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_NextTopic_Info[1]).rectTransform.sizeDelta.x, this.text_NextTopic_Info[1].preferredHeight + 1f);
    }
    else
    {
      ((Component) this.text_Close).gameObject.SetActive(true);
      ((Component) this.ImgNowCD).gameObject.SetActive(false);
      for (int index = 0; index < 2; ++index)
        ((Component) this.text_NowTopic_Info[index]).gameObject.SetActive(false);
      if (this.AM.m_NextArenaTopicID[0] != (byte) 0 && this.AM.m_NextArenaTopicID[1] != (byte) 0)
      {
        this.Cstr_NextTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200U + (uint) this.AM.m_NextArenaTopicID[0]));
        this.Cstr_NextTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200U + (uint) this.AM.m_NextArenaTopicID[1]));
        this.Cstr_NextTopic_Info[0].AppendFormat(this.DM.mStringTable.GetStringByID(9115U));
      }
      else
      {
        if (this.AM.m_NextArenaTopicID[0] != (byte) 0)
          this.Cstr_NextTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200U + (uint) this.AM.m_NextArenaTopicID[0]));
        else
          this.Cstr_NowTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200U + (uint) this.AM.m_NextArenaTopicID[1]));
        this.Cstr_NextTopic_Info[0].AppendFormat(this.DM.mStringTable.GetStringByID(9152U));
      }
      this.text_NextTopic_Info[0].text = this.Cstr_NextTopic_Info[0].ToString();
      this.text_NextTopic_Info[0].SetAllDirty();
      this.text_NextTopic_Info[0].cachedTextGenerator.Invalidate();
      this.text_NextTopic_Info[0].cachedTextGeneratorForLayout.Invalidate();
      if ((double) this.text_NextTopic_Info[0].preferredHeight > (double) ((Graphic) this.text_NextTopic_Info[0]).rectTransform.sizeDelta.y)
        ((Graphic) this.text_NextTopic_Info[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_NextTopic_Info[0]).rectTransform.sizeDelta.x, this.text_NextTopic_Info[0].preferredHeight + 1f);
      ((Graphic) this.text_NextTopic_Info[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_NextTopic_Info[0]).rectTransform.anchoredPosition.x, ((Graphic) this.text_NextTopic_Info[0]).rectTransform.anchoredPosition.y - (float) ((double) this.text_NextTopic_Info[0].preferredHeight + 1.0 + 14.0));
      cstring1.ClearString();
      cstring2.ClearString();
      if (this.AM.m_NextTopicEffect[0].Effect != (ushort) 0 && this.AM.m_NextTopicEffect[1].Effect != (ushort) 0)
      {
        GameConstants.GetEffectValue(cstring1, this.AM.m_NowTopicEffect[0].Effect, (uint) this.AM.m_NextTopicEffect[0].Value, (byte) 10, 0.0f);
        GameConstants.GetEffectValue(cstring2, this.AM.m_NowTopicEffect[1].Effect, (uint) this.AM.m_NextTopicEffect[1].Value, (byte) 10, 0.0f);
        this.Cstr_NextTopic_Info[1].StringToFormat(cstring1);
        this.Cstr_NextTopic_Info[1].StringToFormat(cstring2);
        this.Cstr_NextTopic_Info[1].AppendFormat(this.DM.mStringTable.GetStringByID(9116U));
      }
      else
      {
        if (this.AM.m_NextTopicEffect[0].Effect != (ushort) 0)
          GameConstants.GetEffectValue(cstring1, this.AM.m_NextTopicEffect[0].Effect, (uint) this.AM.m_NextTopicEffect[0].Value, (byte) 10, 0.0f);
        else
          GameConstants.GetEffectValue(cstring1, this.AM.m_NextTopicEffect[1].Effect, (uint) this.AM.m_NextTopicEffect[1].Value, (byte) 10, 0.0f);
        this.Cstr_NextTopic_Info[1].StringToFormat(cstring1);
        this.Cstr_NextTopic_Info[1].AppendFormat(this.DM.mStringTable.GetStringByID(9153U));
      }
      this.text_NextTopic_Info[1].text = this.Cstr_NextTopic_Info[1].ToString();
      this.text_NextTopic_Info[1].SetAllDirty();
      this.text_NextTopic_Info[1].cachedTextGenerator.Invalidate();
      this.text_NextTopic_Info[1].cachedTextGeneratorForLayout.Invalidate();
      if ((double) this.text_NextTopic_Info[1].preferredHeight > (double) ((Graphic) this.text_NextTopic_Info[1]).rectTransform.sizeDelta.y)
        ((Graphic) this.text_NextTopic_Info[1]).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_NextTopic_Info[1]).rectTransform.sizeDelta.x, this.text_NextTopic_Info[1].preferredHeight + 1f);
    }
    if (((UIBehaviour) this.ImgNowCD).IsActive())
    {
      this.Cstr_NowCD.ClearString();
      if (this.AM.m_NowArenaTopicEndTime >= this.DM.ServerTime)
      {
        if ((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) / 86400L > 0L)
        {
          this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) / 86400L);
          this.Cstr_NowCD.AppendFormat("{0}d");
        }
        else
        {
          this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) % 86400L / 3600L, 2);
          this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) % 3600L / 60L, 2);
          this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) % 60L, 2);
          this.Cstr_NowCD.AppendFormat("{0}:{1}:{2}");
        }
      }
      else
      {
        this.Cstr_NowCD.IntToFormat(0L, 2);
        this.Cstr_NowCD.IntToFormat(0L, 2);
        this.Cstr_NowCD.IntToFormat(0L, 2);
        this.Cstr_NowCD.AppendFormat("{0}:{1}:{2}");
      }
      this.text_NowCD[1].text = this.Cstr_NowCD.ToString();
      this.text_NowCD[1].SetAllDirty();
      this.text_NowCD[1].cachedTextGenerator.Invalidate();
    }
    if (!((UIBehaviour) this.ImgNextCD).IsActive())
      return;
    this.Cstr_NextCD.ClearString();
    long num = !((UIBehaviour) this.text_Close).IsActive() ? this.AM.m_NextArenaTopicBeginTime - this.DM.ServerTime : this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime;
    if (num >= this.DM.ServerTime)
    {
      if (num / 86400L > 0L)
      {
        this.Cstr_NextCD.IntToFormat(num / 86400L);
        this.Cstr_NextCD.AppendFormat("{0}d");
      }
      else
      {
        this.Cstr_NextCD.IntToFormat(num % 86400L / 3600L, 2);
        this.Cstr_NextCD.IntToFormat(num % 3600L / 60L, 2);
        this.Cstr_NextCD.IntToFormat(num % 60L, 2);
        this.Cstr_NextCD.AppendFormat("{0}:{1}:{2}");
      }
    }
    else
    {
      this.Cstr_NextCD.IntToFormat(0L, 2);
      this.Cstr_NextCD.IntToFormat(0L, 2);
      this.Cstr_NextCD.IntToFormat(0L, 2);
      this.Cstr_NextCD.AppendFormat("{0}:{1}:{2}");
    }
    this.text_NextCD[1].text = this.Cstr_NextCD.ToString();
    this.text_NextCD[1].SetAllDirty();
    this.text_NextCD[1].cachedTextGenerator.Invalidate();
  }

  public override void OnClose()
  {
    if (this.Cstr_NowCD != null)
      StringManager.Instance.DeSpawnString(this.Cstr_NowCD);
    if (this.Cstr_NextCD != null)
      StringManager.Instance.DeSpawnString(this.Cstr_NextCD);
    for (int index = 0; index < 2; ++index)
    {
      if (this.Cstr_NowTopic_Info[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_NowTopic_Info[index]);
      if (this.Cstr_NextTopic_Info[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_NextTopic_Info[index]);
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (((UIBehaviour) this.ImgNowCD).IsActive())
    {
      this.Cstr_NowCD.ClearString();
      if (this.AM.m_NowArenaTopicEndTime >= this.DM.ServerTime)
      {
        if ((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) / 86400L > 0L)
        {
          this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) / 86400L);
          this.Cstr_NowCD.AppendFormat("{0}d");
        }
        else
        {
          this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) % 86400L / 3600L, 2);
          this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) % 3600L / 60L, 2);
          this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) % 60L, 2);
          this.Cstr_NowCD.AppendFormat("{0}:{1}:{2}");
        }
      }
      else
      {
        this.Cstr_NowCD.IntToFormat(0L, 2);
        this.Cstr_NowCD.IntToFormat(0L, 2);
        this.Cstr_NowCD.IntToFormat(0L, 2);
        this.Cstr_NowCD.AppendFormat("{0}:{1}:{2}");
      }
      this.text_NowCD[1].text = this.Cstr_NowCD.ToString();
      this.text_NowCD[1].SetAllDirty();
      this.text_NowCD[1].cachedTextGenerator.Invalidate();
    }
    if (!((UIBehaviour) this.ImgNextCD).IsActive())
      return;
    this.Cstr_NextCD.ClearString();
    long num = !((UIBehaviour) this.text_Close).IsActive() ? this.AM.m_NextArenaTopicBeginTime - this.DM.ServerTime : this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime;
    if (num >= this.DM.ServerTime)
    {
      if (num / 86400L > 0L)
      {
        this.Cstr_NextCD.IntToFormat(num / 86400L);
        this.Cstr_NextCD.AppendFormat("{0}d");
      }
      else
      {
        this.Cstr_NextCD.IntToFormat(num % 86400L / 3600L, 2);
        this.Cstr_NextCD.IntToFormat(num % 3600L / 60L, 2);
        this.Cstr_NextCD.IntToFormat(num % 60L, 2);
        this.Cstr_NextCD.AppendFormat("{0}:{1}:{2}");
      }
    }
    else
    {
      this.Cstr_NextCD.IntToFormat(0L, 2);
      this.Cstr_NextCD.IntToFormat(0L, 2);
      this.Cstr_NextCD.IntToFormat(0L, 2);
      this.Cstr_NextCD.AppendFormat("{0}:{1}:{2}");
    }
    this.text_NextCD[1].text = this.Cstr_NextCD.ToString();
    this.text_NextCD[1].SetAllDirty();
    this.text_NextCD[1].cachedTextGenerator.Invalidate();
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
      case NetworkNews.Login:
        this.SetTopic();
        break;
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
    if ((Object) this.text_NowTopic != (Object) null && ((Behaviour) this.text_NowTopic).enabled)
    {
      ((Behaviour) this.text_NowTopic).enabled = false;
      ((Behaviour) this.text_NowTopic).enabled = true;
    }
    if ((Object) this.text_NextTopic != (Object) null && ((Behaviour) this.text_NextTopic).enabled)
    {
      ((Behaviour) this.text_NextTopic).enabled = false;
      ((Behaviour) this.text_NextTopic).enabled = true;
    }
    if ((Object) this.text_Info != (Object) null && ((Behaviour) this.text_Info).enabled)
    {
      ((Behaviour) this.text_Info).enabled = false;
      ((Behaviour) this.text_Info).enabled = true;
    }
    if ((Object) this.text_Close != (Object) null && ((Behaviour) this.text_Close).enabled)
    {
      ((Behaviour) this.text_Close).enabled = false;
      ((Behaviour) this.text_Close).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_NowTopic_Info[index] != (Object) null && ((Behaviour) this.text_NowTopic_Info[index]).enabled)
      {
        ((Behaviour) this.text_NowTopic_Info[index]).enabled = false;
        ((Behaviour) this.text_NowTopic_Info[index]).enabled = true;
      }
      if ((Object) this.text_NextTopic_Info[index] != (Object) null && ((Behaviour) this.text_NextTopic_Info[index]).enabled)
      {
        ((Behaviour) this.text_NextTopic_Info[index]).enabled = false;
        ((Behaviour) this.text_NextTopic_Info[index]).enabled = true;
      }
      if ((Object) this.text_NowCD[index] != (Object) null && ((Behaviour) this.text_NowCD[index]).enabled)
      {
        ((Behaviour) this.text_NowCD[index]).enabled = false;
        ((Behaviour) this.text_NowCD[index]).enabled = true;
      }
      if ((Object) this.text_NextCD[index] != (Object) null && ((Behaviour) this.text_NextCD[index]).enabled)
      {
        ((Behaviour) this.text_NextCD[index]).enabled = false;
        ((Behaviour) this.text_NextCD[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9162U), (ushort) byte.MaxValue);
        this.SetTopic();
        break;
      case 2:
        this.AM.bArenaKVK = ActivityManager.Instance.IsInKvK((ushort) 0);
        this.SetTopic();
        break;
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
