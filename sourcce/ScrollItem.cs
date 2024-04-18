// Decompiled with JetBrains decompiler
// Type: ScrollItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class ScrollItem : Selectable, IPointerClickHandler, IEventSystemHandler
{
  public IScrollItemHandler m_Handler;
  public int m_BtnID1;
  public byte SoundIndex;

  public void OnPointerClick(PointerEventData eventData)
  {
    if (!((UIBehaviour) this).IsActive() || !this.IsInteractable() || this.m_Handler == null)
      return;
    if (((int) this.SoundIndex & 64) > 0)
      AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex) ((int) this.SoundIndex & -65));
    this.m_Handler.ButtonOnClick(this);
  }
}
