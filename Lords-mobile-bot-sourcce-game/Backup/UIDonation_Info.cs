// Decompiled with JetBrains decompiler
// Type: UIDonation_Info
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIDonation_Info : GUIWindow, IUIButtonClickHandler
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
  private UIText text_Info;
  private CString Cstr_Info;
  private int tmpItemNum;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    Material material = this.door.LoadMaterial();
    this.Cstr_Info = StringManager.Instance.SpawnString(1024);
    this.text_Title = this.GameT.GetChild(0).GetChild(1).GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.text_Title.text = this.DM.mStringTable.GetStringByID(14544U);
    Transform child = this.GameT.GetChild(1).GetChild(0);
    this.Content_RT = child.GetComponent<RectTransform>();
    this.text_Info = child.GetChild(0).GetComponent<UIText>();
    this.text_Info.font = this.TTFont;
    this.Cstr_Info.ClearString();
    this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14551U));
    this.Cstr_Info.Append("\n\n");
    this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14552U));
    this.Cstr_Info.Append("\n\n");
    this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14553U));
    this.text_Info.text = this.Cstr_Info.ToString();
    this.text_Info.SetAllDirty();
    this.text_Info.cachedTextGenerator.Invalidate();
    this.text_Info.cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_Info.preferredHeight > (double) ((Graphic) this.text_Info).rectTransform.sizeDelta.y)
    {
      ((Graphic) this.text_Info).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Info).rectTransform.sizeDelta.x, this.text_Info.preferredHeight);
      this.Content_RT.sizeDelta = new Vector2(this.Content_RT.sizeDelta.x, this.text_Info.preferredHeight);
    }
    Image component = this.GameT.GetChild(2).GetComponent<Image>();
    component.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component).material = material;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) component).enabled = false;
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
    if (!((Object) this.text_Info != (Object) null) || !((Behaviour) this.text_Info).enabled)
      return;
    ((Behaviour) this.text_Info).enabled = false;
    ((Behaviour) this.text_Info).enabled = true;
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
