// Decompiled with JetBrains decompiler
// Type: UI_leadup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UI_leadup : GUIWindow, IUIButtonClickHandler
{
  private Transform m_PanelT;
  private GUIManager GM = GUIManager.Instance;
  private DataManager DM = DataManager.Instance;
  private CString[] tmpString = new CString[6];
  private Transform LightT2;
  private string whiteString1 = "<color=#FFFFFFFF>";
  private string whiteString2 = "{0}</color>";
  private string whiteString3 = "</color>";
  private UIText[] RBText = new UIText[10];

  public override void OnOpen(int arg1, int arg2)
  {
    this.GM.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
    Font ttfFont = this.GM.GetTTFFont();
    CString tmpS = StringManager.Instance.StaticString1024();
    for (int index = 0; index < 6; ++index)
      this.tmpString[index] = StringManager.Instance.SpawnString();
    this.m_PanelT = this.transform;
    this.m_PanelT.GetChild(16).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    if (this.GM.bOpenOnIPhoneX)
    {
      ((RectTransform) this.m_PanelT).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.m_PanelT).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0.0f);
    }
    this.RBText[0] = this.m_PanelT.GetChild(14).GetComponent<UIText>();
    this.RBText[0].text = this.DM.RoleAttr.Level.ToString();
    this.RBText[0].font = ttfFont;
    this.RBText[1] = this.m_PanelT.GetChild(15).GetComponent<UIText>();
    this.RBText[1].text = this.DM.mStringTable.GetStringByID(5797U);
    this.RBText[1].font = ttfFont;
    this.RBText[2] = this.m_PanelT.GetChild(17).GetComponent<UIText>();
    this.RBText[2].text = this.DM.mStringTable.GetStringByID(1556U);
    this.RBText[2].font = ttfFont;
    this.RBText[3] = this.m_PanelT.GetChild(23).GetComponent<UIText>();
    tmpS.Length = 0;
    tmpS.IntToFormat((long) arg1);
    tmpS.AppendFormat(this.whiteString2);
    this.tmpString[0].Length = 0;
    this.tmpString[0].Append(this.whiteString1);
    this.tmpString[0].StringToFormat(tmpS);
    this.tmpString[0].IntToFormat((long) this.DM.RoleAttr.Level);
    this.tmpString[0].AppendFormat(this.DM.mStringTable.GetStringByID(1557U));
    this.RBText[3].text = this.tmpString[0].ToString();
    this.RBText[3].font = ttfFont;
    LevelUp recordByKey = this.DM.LevelUpTable.GetRecordByKey((ushort) this.DM.RoleAttr.Level);
    this.RBText[4] = this.m_PanelT.GetChild(18).GetComponent<UIText>();
    this.RBText[4].text = this.DM.mStringTable.GetStringByID(1558U);
    this.RBText[4].font = ttfFont;
    this.RBText[5] = this.m_PanelT.GetChild(24).GetComponent<UIText>();
    this.tmpString[1].Length = 0;
    this.tmpString[1].IntToFormat((long) recordByKey.AddCoin);
    this.tmpString[1].AppendFormat(this.DM.mStringTable.GetStringByID(1559U));
    this.RBText[5].text = this.tmpString[1].ToString();
    this.RBText[5].font = ttfFont;
    uint num = 0;
    if (this.DM.RoleAttr.Level > (byte) 0)
      num = this.DM.LevelUpTable.GetRecordByKey((ushort) ((uint) this.DM.RoleAttr.Level - 1U)).AddForce;
    this.RBText[6] = this.m_PanelT.GetChild(19).GetComponent<UIText>();
    this.RBText[6].text = this.DM.mStringTable.GetStringByID(1560U);
    this.RBText[6].font = ttfFont;
    this.RBText[7] = this.m_PanelT.GetChild(25).GetComponent<UIText>();
    this.tmpString[2].Length = 0;
    this.tmpString[2].IntToFormat((long) (recordByKey.AddForce - num), bNumber: true);
    this.tmpString[2].AppendFormat(this.DM.mStringTable.GetStringByID(1561U));
    this.RBText[7].text = this.tmpString[2].ToString();
    this.RBText[7].font = ttfFont;
    this.RBText[8] = this.m_PanelT.GetChild(20).GetComponent<UIText>();
    this.RBText[8].text = this.DM.mStringTable.GetStringByID(1562U);
    this.RBText[8].font = ttfFont;
    this.RBText[9] = this.m_PanelT.GetChild(26).GetComponent<UIText>();
    this.RBText[9].font = ttfFont;
    if (this.DM.RoleAttr.Level <= (byte) 15)
    {
      this.tmpString[3].Length = 0;
      this.tmpString[3].Append(this.whiteString1);
      this.tmpString[3].Append(this.DM.mStringTable.GetStringByID(1568U));
      this.tmpString[3].Append(this.whiteString3);
    }
    else
    {
      tmpS.Length = 0;
      tmpS.IntToFormat((long) arg1);
      tmpS.AppendFormat(this.whiteString2);
      this.tmpString[3].Length = 0;
      this.tmpString[3].Append(this.whiteString1);
      this.tmpString[3].StringToFormat(tmpS);
      this.tmpString[3].IntToFormat((long) this.DM.RoleAttr.Level);
      this.tmpString[3].AppendFormat(this.DM.mStringTable.GetStringByID(1563U));
    }
    this.RBText[9].text = this.tmpString[3].ToString();
    this.LightT2 = this.m_PanelT.GetChild(3);
    if (this.DM.UserLanguage == GameLanguage.GL_Chs)
      this.m_PanelT.GetChild(8).GetComponent<UISpritesArray>().SetSpriteIndex(0);
    if (this.GM.IsArabic)
      this.m_PanelT.GetChild(8).localScale = new Vector3(-1f, 1f, 1f);
    AudioManager.Instance.PlayUISFX(UIKind.DominanceLevelup);
    this.DM.leadup_CDTime = 0.3f;
    this.GM.LoadLvUpLight(this.m_PanelT);
    DataManager.MissionDataManager.AchievementMgr.UpdateGameCenterLevel((ushort) DataManager.Instance.RoleAttr.Level);
  }

  public override void OnClose()
  {
    for (int index = 0; index < 6; ++index)
    {
      if (this.tmpString[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.tmpString[index]);
        this.tmpString[index] = (CString) null;
      }
    }
    this.GM.ReleaseLvUpLight();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    for (int index = 0; index < this.RBText.Length; ++index)
    {
      if ((Object) this.RBText[index] != (Object) null && ((Behaviour) this.RBText[index]).enabled)
      {
        ((Behaviour) this.RBText[index]).enabled = false;
        ((Behaviour) this.RBText[index]).enabled = true;
      }
    }
  }

  private void Update() => this.LightT2.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);

  public void OnButtonClick(UIButton sender)
  {
    this.GM.CloseMenu(EGUIWindow.UI_leadup);
    this.GM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
  }
}
