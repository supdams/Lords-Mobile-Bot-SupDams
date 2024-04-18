// Decompiled with JetBrains decompiler
// Type: BattleControllerPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class BattleControllerPanel : 
  Image,
  IPointerUpHandler,
  IPointerDownHandler,
  IEventSystemHandler
{
  private BattleController BC;

  public BattleController battleController
  {
    set => this.BC = value;
  }

  public void OnPointerDown(PointerEventData eventData)
  {
  }

  public void OnPointerUp(PointerEventData eventData)
  {
    if (this.BC == null || this.BC.StartAutoBattle || this.BC.NextLevelWorking || this.BC.m_BattleState != BattleController.BattleState.BATTLE_FINISHED || !this.BC.CheckNextLevel() || !this.BC.movePlayerOutside())
      return;
    this.BC.NextLevelWorking = true;
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.Battle);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 12);
  }
}
