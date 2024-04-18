// Decompiled with JetBrains decompiler
// Type: AllianceJoin
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Text;
using UnityEngine;

#nullable disable
public class AllianceJoin : GUIWindow, IUIButtonClickHandler
{
  private Door door;
  protected UnityEngine.UI.Text[] m_IAllianceJoinText = new UnityEngine.UI.Text[2];

  private void Start()
  {
  }

  private void Update()
  {
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.transform.GetChild(6).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(4).GetChild(1).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(4).GetChild(2).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(4).GetChild(3).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
    this.transform.GetChild(4).GetChild(8).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(4).GetChild(9).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(4).GetChild(10).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(4).GetChild(15).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
    this.m_IAllianceJoinText[0] = this.transform.GetChild(4).GetChild(15).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.transform.GetChild(4).GetChild(17).GetChild(0).GetComponent<UnityEngine.UI.Text>().font = GUIManager.Instance.GetTTFFont();
    this.m_IAllianceJoinText[1] = this.transform.GetChild(4).GetChild(17).GetChild(0).GetComponent<UnityEngine.UI.Text>();
    this.transform.GetChild(4).GetChild(22).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(4).GetChild(23).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(4).GetChild(24).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
  }

  public override void OnClose()
  {
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public void Refresh_FontTexture()
  {
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.m_IAllianceJoinText[index] != (Object) null && ((Behaviour) this.m_IAllianceJoinText[index]).enabled)
      {
        ((Behaviour) this.m_IAllianceJoinText[index]).enabled = false;
        ((Behaviour) this.m_IAllianceJoinText[index]).enabled = true;
      }
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 4)
    {
      string str = new string(char.MinValue, 13);
      string data1 = "777";
      ushort data2 = 8;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_CREATE;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) Encoding.UTF8.GetByteCount(str));
      messagePacket.Add(str, 20);
      messagePacket.Add(data1, 3);
      messagePacket.Add(data2);
      messagePacket.Send();
    }
    else
    {
      if (sender.m_BtnID1 != 9)
        return;
      this.door.CloseMenu();
    }
  }
}
