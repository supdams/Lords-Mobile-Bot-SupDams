// Decompiled with JetBrains decompiler
// Type: Wild
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class Wild : Gameplay
{
  private const ushort currentCorpsStageEffID = 308;
  private const ushort cloudEffEffID = 307;
  private GameObject WildCorpsStage;
  private MapSprite _BuildSprite;
  private GameObject Select;
  private GameObject[] ConfirmSelect;
  private GameObject[] CanBeSelect;
  private GameObject currentCorpsStageObject;
  private GameObject currentCorpsStageModel;
  private GameObject currentCorpsStageEff;
  private GameObject cloudEff;
  private int currentCorpsStageKey;

  public Wild(GameObject _CorpsStage) => this.WildCorpsStage = _CorpsStage;

  ~Wild()
  {
  }

  private void PlayBoss()
  {
    if ((UnityEngine.Object) this.WildCorpsStage == (UnityEngine.Object) null)
      return;
    this.WildCorpsStage.SetActive(true);
    Animation component = this.WildCorpsStage.transform.GetChild(1).GetComponent<Animation>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    component.wrapMode = WrapMode.Loop;
    component.CrossFade("idle", 0.3f);
  }

  protected override void UpdateNext(byte[] meg)
  {
    this.WildCorpsStage = (GameObject) null;
    if (this._BuildSprite != null)
      this._BuildSprite.Destroy();
    this._BuildSprite = (MapSprite) null;
    if ((UnityEngine.Object) this.currentCorpsStageEff != (UnityEngine.Object) null)
      ParticleManager.Instance.DeSpawn(this.currentCorpsStageEff);
    this.currentCorpsStageEff = (GameObject) null;
    if ((UnityEngine.Object) this.cloudEff != (UnityEngine.Object) null)
      ParticleManager.Instance.DeSpawn(this.cloudEff);
    this.cloudEff = (GameObject) null;
    this.currentCorpsStageModel = (GameObject) null;
    this.Select = (GameObject) null;
    if ((UnityEngine.Object) this.currentCorpsStageObject != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.currentCorpsStageObject);
    this.currentCorpsStageObject = (GameObject) null;
    AssetManager.UnloadAssetBundle(this.currentCorpsStageKey);
    if (this.ConfirmSelect != null)
      Array.Clear((Array) this.ConfirmSelect, 0, this.ConfirmSelect.Length);
    this.ConfirmSelect = (GameObject[]) null;
    if (this.CanBeSelect != null)
      Array.Clear((Array) this.CanBeSelect, 0, this.CanBeSelect.Length);
    this.CanBeSelect = (GameObject[]) null;
    this.ClearUpdateDelegates();
  }

  protected override void UpdateLoad(byte[] meg)
  {
    this._BuildSprite = new MapSprite(WorldMode.Wild, (ushort) 1);
    this.CanBeSelect = new GameObject[2 + this._BuildSprite.SpriteGameObject.Length + DataManager.StageDataController.CorpsStageTable.TableCount];
    this.ConfirmSelect = new GameObject[1];
    Array.Copy((Array) this._BuildSprite.SpriteGameObject, 0, (Array) this.CanBeSelect, 2, this._BuildSprite.SpriteGameObject.Length);
    Array.Copy((Array) this._BuildSprite.StageLock, 0, (Array) this.CanBeSelect, 2 + this._BuildSprite.SpriteGameObject.Length, this._BuildSprite.StageLock.Length);
    if ((int) DataManager.StageDataController.StageRecord[2] < (int) DataManager.StageDataController.limitRecord[2])
    {
      ushort InKey = (ushort) ((uint) DataManager.StageDataController.StageRecord[2] + 1U);
      if (DataManager.StageDataController.isNotFirstInChapter[2] == (byte) 1)
      {
        this.PlayBoss();
        this.CanBeSelect[0] = this.WildCorpsStage.transform.GetChild(0).gameObject;
        this.CanBeSelect[1] = this.WildCorpsStage.transform.GetChild(1).gameObject;
      }
      else
      {
        this.currentCorpsStageObject = new GameObject("CorpsStageFlag");
        Transform transform1 = this.currentCorpsStageObject.transform;
        this.CanBeSelect[0] = this.currentCorpsStageModel = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle("Role/3dbutton02", out this.currentCorpsStageKey).mainAsset) as GameObject;
        this.CanBeSelect[1] = (GameObject) null;
        Animation component = this.currentCorpsStageModel.GetComponent<Animation>();
        component.wrapMode = WrapMode.Loop;
        component.Play("idle");
        Transform transform2 = this.currentCorpsStageModel.transform;
        transform2.localScale = Vector3.one * 20f;
        transform2.SetParent(transform1);
        this.cloudEff = ParticleManager.Instance.Spawn((ushort) 307, transform1, new Vector3(0.0f, 8.67f, -7.03f), 1f, true);
        this.currentCorpsStageEff = ParticleManager.Instance.Spawn((ushort) 308, transform1, new Vector3(0.59f, 5.69f, -3.8f), 1f, true);
        CorpsStage recordByKey1 = DataManager.StageDataController.CorpsStageTable.GetRecordByKey(InKey);
        transform1.position = GameConstants.WordToVector3(recordByKey1.StagePos.X, recordByKey1.StagePos.Y, recordByKey1.StagePos.Z);
        Chapter recordByKey2 = DataManager.StageDataController.ChapterTable.GetRecordByKey(InKey);
        transform1.LookAt(GameConstants.WordToVector3(recordByKey2.CameraPos.X, recordByKey2.CameraPos.Y, recordByKey2.CameraPos.Z));
        Vector3 eulerAngles = transform1.eulerAngles;
        eulerAngles.y = eulerAngles.z = 0.0f;
        transform1.eulerAngles = eulerAngles;
      }
    }
    else
      this.CanBeSelect[0] = this.CanBeSelect[1] = (GameObject) null;
  }

  protected override void UpdateReady(byte[] meg)
  {
    DataManager.msgBuffer[0] = (byte) 9;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    DataManager.Instance.lastBattleResult = (short) -1;
    GUIManager instance = GUIManager.Instance;
    if (instance.BuildGuildQueue <= (ushort) 0)
      return;
    instance.BuildingData.ManorGuild(GUIManager.Instance.BuildGuildQueue);
    instance.BuildGuildQueue = (ushort) 0;
  }

  protected override void UpdateRun(byte[] meg) => this._BuildSprite.UpdateGuildPos();

  protected override void UpdateNews(byte[] meg)
  {
    Vector2 touch = new Vector2(GameConstants.ConvertBytesToFloat(meg, 1), GameConstants.ConvertBytesToFloat(meg, 5));
    switch (meg[0])
    {
      case 0:
        this.Select = GameConstants.GameObjectPick(touch, this.CanBeSelect, typeof (Renderer), true);
        break;
      case 1:
        if (!((UnityEngine.Object) this.Select != (UnityEngine.Object) null))
          break;
        this.ConfirmSelect[0] = this.Select;
        this.Select = GameConstants.GameObjectPick(touch, this.ConfirmSelect, typeof (Renderer), true);
        if ((UnityEngine.Object) this.Select == (UnityEngine.Object) this.ConfirmSelect[0])
        {
          if ((UnityEngine.Object) this.Select == (UnityEngine.Object) this.CanBeSelect[0] || (UnityEngine.Object) this.Select == (UnityEngine.Object) this.CanBeSelect[1])
          {
            if (DataManager.StageDataController.isNotFirstInChapter[2] == (byte) 0)
              this.PlayBoss();
            DataManager.StageDataController.resetStageMode(StageMode.Corps);
            DataManager.msgBuffer[0] = (byte) 7;
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          }
          else
            this._BuildSprite.NotifyOpenUI(this.Select.name.GetHashCode());
        }
        this.Select = (GameObject) null;
        break;
      case 5:
        if (this._BuildSprite == null)
          break;
        this._BuildSprite.UpdateMapSprite(GameConstants.ConvertBytesToUShort(meg, 12), meg[11]);
        break;
      case 7:
        this.Select = (GameObject) null;
        break;
      case 9:
        if (this._BuildSprite == null)
          break;
        this._BuildSprite.UpdateMapSprite(GameConstants.ConvertBytesToUShort(meg, 12), (byte) 5);
        break;
      case 11:
        if (this._BuildSprite == null)
          break;
        this._BuildSprite.ShowManorGuild(GameConstants.ConvertBytesToUShort(meg, 3));
        break;
      case 12:
        if (DataManager.StageDataController.isNotFirstInChapter[2] != (byte) 0)
          break;
        this.PlayBoss();
        break;
    }
  }
}
