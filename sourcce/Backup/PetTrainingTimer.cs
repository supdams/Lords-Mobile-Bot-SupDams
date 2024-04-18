// Decompiled with JetBrains decompiler
// Type: PetTrainingTimer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
internal class PetTrainingTimer
{
  private UITimeBar m_Timer;
  private UIButton m_TrainingBtn;
  private UIButton m_ReceiveBtn;
  private PetManager.EPetTrainDataState m_State;

  public void Init(UITimeBar timer, UIButton traningBtn, UIButton ReceiveBtn, int timerID)
  {
    this.m_Timer = timer;
    this.m_TrainingBtn = traningBtn;
    this.m_ReceiveBtn = ReceiveBtn;
    this.m_State = PetManager.EPetTrainDataState.Empty;
    this.m_Timer.m_TimeBarID = timerID;
    GUIManager.Instance.CreateTimerBar(this.m_Timer, 0L, 0L, 0L, eTimeBarType.CancelType, DataManager.Instance.mStringTable.GetStringByID(17113U), DataManager.Instance.mStringTable.GetStringByID(17113U));
    ((Component) this.m_Timer.m_FuntionBtn).gameObject.SetActive(false);
  }

  public void SetCancelBtnID(int dataIdx, int panelObjectIdx)
  {
    this.m_Timer.m_CancelBtn.m_BtnID2 = dataIdx;
    this.m_Timer.m_CancelBtn.m_BtnID3 = panelObjectIdx;
  }

  public void SetTrainBtnID(int dataIdx, int panelObjectIdx)
  {
    this.m_TrainingBtn.m_BtnID2 = dataIdx;
    this.m_TrainingBtn.m_BtnID3 = panelObjectIdx;
  }

  public void SetReceiveBtnID(int dataIdx, int panelObjectIdx)
  {
    this.m_ReceiveBtn.m_BtnID2 = dataIdx;
    this.m_ReceiveBtn.m_BtnID3 = panelObjectIdx;
  }

  public void SetTimer(long begin, long require, string petName, IUTimeBarOnTimer hander)
  {
    if (!((Object) this.m_Timer != (Object) null))
      return;
    this.m_Timer.m_Handler = hander;
    GUIManager.Instance.SetTimerBar(this.m_Timer, begin, begin + require, 0L, eTimeBarType.CancelType, DataManager.Instance.mStringTable.GetStringByID(17113U), petName);
  }

  public void SetState(PetManager.EPetTrainDataState state)
  {
    this.m_State = state;
    switch (this.m_State)
    {
      case PetManager.EPetTrainDataState.Empty:
        this.m_Timer.gameObject.SetActive(false);
        ((Component) this.m_TrainingBtn).gameObject.SetActive(true);
        ((Component) this.m_ReceiveBtn).gameObject.SetActive(false);
        break;
      case PetManager.EPetTrainDataState.Training:
        this.m_Timer.gameObject.SetActive(true);
        ((Component) this.m_TrainingBtn).gameObject.SetActive(false);
        ((Component) this.m_ReceiveBtn).gameObject.SetActive(false);
        break;
      case PetManager.EPetTrainDataState.CanReceive:
        this.m_Timer.gameObject.SetActive(false);
        ((Component) this.m_TrainingBtn).gameObject.SetActive(false);
        ((Component) this.m_ReceiveBtn).gameObject.SetActive(true);
        break;
      case PetManager.EPetTrainDataState.Received:
        this.m_Timer.gameObject.SetActive(false);
        ((Component) this.m_TrainingBtn).gameObject.SetActive(true);
        ((Component) this.m_ReceiveBtn).gameObject.SetActive(false);
        break;
    }
  }

  public void OnTimer() => this.SetState(PetManager.EPetTrainDataState.CanReceive);

  public void onFinish() => this.SetState(PetManager.EPetTrainDataState.Received);

  public void OnClose()
  {
    if (!((Object) this.m_Timer != (Object) null))
      return;
    GUIManager.Instance.RemoverTimeBaarToList(this.m_Timer);
  }

  public void RefreshFontTexture()
  {
    if (!(bool) (Object) this.m_Timer)
      return;
    this.m_Timer.Refresh_FontTexture();
  }

  public enum eTrainingState
  {
    Empty,
    Training,
    CanReceive,
    Received,
    Closed,
    NextOpne,
  }
}
