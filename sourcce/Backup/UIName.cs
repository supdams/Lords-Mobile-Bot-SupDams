// Decompiled with JetBrains decompiler
// Type: UIName
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIName : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
  protected Door door;
  protected UnityEngine.UI.Text[] m_InputBoxText = new UnityEngine.UI.Text[3];
  protected UnityEngine.UI.Text m_Name;
  protected UnityEngine.UI.Text m_Nick;
  protected UnityEngine.UI.Text m_error;
  protected UnityEngine.UI.Text m_content;
  protected UnityEngine.UI.Text m_descript;
  protected UnityEngine.UI.Text m_character;
  protected InputField s_input;
  protected InputField m_input;
  protected UISpritesArray USArray;
  protected Transform Transformer;
  protected GameObject Tick;
  protected GameObject Invalid;
  protected float CheckTime;
  public Protocol Checking;
  public Protocol Sending;
  public byte Tagging;
  public int Typing;
  public int Length;
  public int Limits;
  public int Counts;
  public long ItemID;
  public DataManager DM = DataManager.Instance;
  public StringBuilder Hint = new StringBuilder();

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (Object) menu)
    {
      img.sprite = menu.LoadSprite(ImageName);
      ((MaskableGraphic) img).material = menu.LoadMaterial();
    }
    img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
    ((MaskableGraphic) img).material = GUIManager.Instance.GetFrameMaterial();
  }

  private void ValueChange(string input)
  {
    if (input != string.Empty)
    {
      this.CheckTime = 1f;
      ++this.Tagging;
    }
    this.Hint.Length = 0;
    this.m_character.text = this.Hint.AppendFormat(this.DM.mStringTable.GetStringByID(4614U), (object) (this.Limits - Encoding.UTF8.GetByteCount(input))).ToString();
  }

  public override void OnOpen(int arg1, int arg2)
  {
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      ((RectTransform) this.transform).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.transform).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    this.Transformer = this.transform.GetChild(0);
    this.transform.gameObject.AddComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.Transformer.GetChild(4).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.Transformer.GetChild(6).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_Name = this.Transformer.GetChild(4).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_Name.text = this.DM.mStringTable.GetStringByID(4716U);
    this.m_Name.font = GUIManager.Instance.GetTTFFont();
    this.m_Nick = this.Transformer.GetChild(6).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.m_Nick.text = this.DM.mStringTable.GetStringByID(9099U);
    this.m_Nick.font = GUIManager.Instance.GetTTFFont();
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.m_Name != (Object) null && ((Behaviour) this.m_Name).enabled)
    {
      ((Behaviour) this.m_Name).enabled = false;
      ((Behaviour) this.m_Name).enabled = true;
    }
    if (!((Object) this.m_Nick != (Object) null) || !((Behaviour) this.m_Nick).enabled)
      return;
    ((Behaviour) this.m_Nick).enabled = false;
    ((Behaviour) this.m_Nick).enabled = true;
  }

  public void OnButtonClick(UIButton sender)
  {
    GUIManager.Instance.CloseMenu(this.m_eWindow);
    if (sender.m_BtnID1 == 21)
    {
      GUIManager.Instance.UseOrSpend((ushort) 1006, this.DM.mStringTable.GetStringByID(4957U), (ushort) 0, (ushort) 0, (ushort) 0, maxcount: (ushort) 0);
    }
    else
    {
      if (sender.m_BtnID1 != 22)
        return;
      GUIManager.Instance.UseOrSpend((ushort) 1253, this.DM.mStringTable.GetStringByID(4957U), (ushort) 0, (ushort) 0, (ushort) 0, maxcount: (ushort) 0);
    }
  }
}
