// Decompiled with JetBrains decompiler
// Type: OpenUp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class OpenUp : Gameplay
{
  private const ushort HaloID = 51;
  private const ushort CastleDestroyEffID = 310;
  private GameObject OpenUpCorpsStage;
  private GameObject Line;
  private GameObject[] BigPoint;
  private GameObject[] Point;
  private GameObject Boss;
  private GameObject DeadBoss;
  private GameObject Pawn;
  private GameObject[] CanBeSelect;
  private GameObject[] Select;
  private GameObject Halo;
  private GameObject InOutParent;
  private GameObject Treasure;
  private MapSprite _BuildSprite;
  private Animation BossAnimation;
  private Animation DeadBossAnimation;
  private Transform[] BigPointTransform;
  private Transform[] PointTransform;
  private Transform BossTransform;
  private Transform DeadBossTransform;
  private Transform PawnTransform;
  private Transform InOutParentTransform;
  private Transform TreasureTransform;
  private OpenUp.OpenState _openState;
  private OpenUp.StateUpdateDelegate stateUpdateDelegates;
  private float Bossoffset = 1.25f;
  private float Bossscale = 4f;
  private float BossDown = 6f;
  private float Spriteoffset = 5.25f;
  private float Pawnoffset = 2f;
  private float Pawnscale = 4f;
  private float PointDown = 2f;
  private float FallStart = 55f;
  private float UpStart = 10f;
  private float InOutSpeed = 10f;
  private float BossAnimationTime;
  private float Treasurescale = 26f;
  private float Treasureoffset = 0.25f;
  private int BossassetKey;
  private int DeadBossassetKey;
  private int PawnassetKey;
  private int LineassetKey;
  private int PointassetKey;
  private int BigPointassetKey;
  private int TreasureassetKey;
  private bool bupdateChapter;
  private Vector3[] PointPos = new Vector3[12];
  private Vector3[] BigPointPos = new Vector3[6];
  private Vector3 LinePos = new Vector3(0.0f, 0.0f, 0.0f);

  public OpenUp(GameObject _CorpsStage)
  {
    this._openState = OpenUp.OpenState.Count;
    this.OpenUpCorpsStage = _CorpsStage;
    this.stateUpdateDelegates = (OpenUp.StateUpdateDelegate) null;
  }

  ~OpenUp()
  {
  }

  private byte LineID
  {
    get
    {
      byte stageMode = (byte) DataManager.StageDataController._stageMode;
      ushort num = DataManager.StageDataController.StageRecord[(int) stageMode];
      if ((int) num >= (int) DataManager.StageDataController.limitRecord[(int) stageMode] && num > (ushort) 0)
        --num;
      return (byte) (ushort) ((uint) (ushort) ((uint) num / (uint) GameConstants.LinePointNum[(int) stageMode]) % 6U);
    }
  }

  private byte PointID
  {
    get
    {
      byte stageMode = (byte) DataManager.StageDataController._stageMode;
      ushort num = DataManager.StageDataController.StageRecord[(int) stageMode];
      if ((int) num >= (int) DataManager.StageDataController.limitRecord[(int) stageMode] && num > (ushort) 0)
        --num;
      return (byte) (ushort) ((uint) num % (uint) GameConstants.LinePointNum[(int) stageMode]);
    }
  }

  private void getBossID(byte in_LineID)
  {
    ushort num = (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) (ushort) DataManager.StageDataController.currentChapterID - 1U) * 6U) + 1U);
    byte index1 = (byte) ((DataManager.StageDataController._stageMode <= StageMode.Lean ? (uint) DataManager.StageDataController._stageMode : 0U) + 1U);
    Array.Clear((Array) DataManager.msgBuffer, 0, DataManager.msgBuffer.Length);
    Array.Clear((Array) DataManager.DataBuffer, 0, DataManager.DataBuffer.Length);
    for (ushort index2 = 0; (int) index2 <= (int) in_LineID; ++index2)
    {
      HeroTeam recordByKey = DataManager.Instance.TeamTable.GetRecordByKey(DataManager.StageDataController.LevelTable[(int) index1].GetRecordByKey(num++).Team[2]);
      for (int index3 = 0; index3 < recordByKey.Arrays.Length; ++index3)
      {
        HeroTeamAttribute array = recordByKey.Arrays[index3];
        if (array.Type == (byte) 3)
        {
          GameConstants.GetBytes(array.Hero, DataManager.msgBuffer, (int) index2 << 1);
          DataManager.DataBuffer[(int) index2] = recordByKey.HeroStar;
          break;
        }
      }
    }
  }

  private bool setOpenState()
  {
    DataManager.msgBuffer[0] = (byte) 46;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    DataManager.msgBuffer[0] = (byte) 42;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    this._openState = OpenUp.OpenState.Count;
    this.stateUpdateDelegates = (OpenUp.StateUpdateDelegate) null;
    ushort currentPointId = DataManager.StageDataController.currentPointID;
    byte stageMode = (byte) DataManager.StageDataController._stageMode;
    if ((int) DataManager.StageDataController.currentChapterID < (int) DataManager.StageDataController.ChapterID)
    {
      if ((int) currentPointId - 1 == (int) DataManager.StageDataController.StageRecord[(int) stageMode])
      {
        if ((int) (ushort) ((uint) currentPointId / (uint) GameConstants.StagePointNum[(int) stageMode]) == (int) DataManager.StageDataController.currentChapterID)
        {
          this._openState = OpenUp.OpenState.FinalWin;
          DataManager.msgBuffer[0] = (byte) 45;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
      }
      else if (DataManager.StageDataController.DareNodusUpdatePointID > (ushort) 0 && DataManager.StageDataController._stageMode == StageMode.Dare && (int) DataManager.StageDataController.DareNodusUpdatePointID == (int) DataManager.StageDataController.currentPointID)
      {
        DataManager.msgBuffer[0] = (byte) 45;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      }
    }
    else if (DataManager.Instance.lastBattleResult > (short) 0 && (int) DataManager.StageDataController.lastStageRecord < (int) DataManager.StageDataController.StageRecord[(int) stageMode] && (int) DataManager.StageDataController.StageRecord[(int) stageMode] % (int) GameConstants.StagePointNum[(int) stageMode] == 0 && (int) currentPointId == (int) DataManager.StageDataController.limitRecord[(int) stageMode])
    {
      this._openState = OpenUp.OpenState.FinalWin;
      DataManager.msgBuffer[0] = (byte) 45;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
    else
    {
      ushort num;
      if ((int) (num = (ushort) ((uint) currentPointId - 1U)) == (int) DataManager.StageDataController.StageRecord[(int) stageMode])
      {
        num = (ushort) this.LineID;
        if (this.LineID == (byte) 0 && DataManager.StageDataController.isNotFirstInLine[(int) stageMode] == (byte) 0)
        {
          if (DataManager.StageDataController._stageMode == StageMode.Full && DataManager.StageDataController.isNotFirstInChapter[0] == (byte) 0)
          {
            if (NewbieManager.IsTeachWorking(ETeachKind.DARE_FULL))
            {
              this._openState = OpenUp.OpenState.First;
              DataManager.msgBuffer[0] = (byte) 45;
              GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
            }
            else
            {
              this._openState = OpenUp.OpenState.Wait;
              DataManager.msgBuffer[0] = (byte) 47;
              GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
              DataManager.msgBuffer[0] = (byte) 15;
              DataManager.msgBuffer[1] = (byte) 0;
              GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
              return true;
            }
          }
          else
          {
            if (DataManager.StageDataController.isNotFirstInChapter[(int) stageMode] == (byte) 0)
              DataManager.StageDataController.isNotFirstInChapter[(int) stageMode] = (byte) 1;
            this._openState = OpenUp.OpenState.First;
            DataManager.msgBuffer[0] = (byte) 45;
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          }
        }
        else if (DataManager.Instance.lastBattleResult > (short) 0)
        {
          this._openState = this.PointID != (byte) 0 ? OpenUp.OpenState.FullWin : OpenUp.OpenState.LeanWin;
          DataManager.msgBuffer[0] = (byte) 45;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
      }
    }
    DataManager.StageDataController.lastStageRecord = DataManager.StageDataController.StageRecord[(int) stageMode];
    if (this._openState != OpenUp.OpenState.First && DataManager.StageDataController.StageRecord[0] == (ushort) 0 && NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE))
      NewbieManager.Get().IgnoreStep(false, 0);
    return false;
  }

  private bool MoveRun(
    Transform in_transform,
    Vector3 in_direction,
    float in_speed,
    float limit,
    OpenUp.OpenState in_next)
  {
    bool flag = false;
    Vector3 vector3 = in_transform.position + in_direction * Time.deltaTime * in_speed;
    if ((double) in_speed < 0.0)
    {
      if ((double) vector3.y < (double) limit)
      {
        vector3.y = limit;
        this._openState = in_next;
        flag = true;
      }
    }
    else if ((double) vector3.y > (double) limit)
    {
      vector3.y = limit;
      this._openState = in_next;
      flag = true;
    }
    in_transform.position = vector3;
    return flag;
  }

  private void LoadLine(byte in_chapterId, CString in_str, AssetBundle in_AB)
  {
    Chapter recordByKey = DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort) in_chapterId);
    in_str.ClearString();
    in_str.StringToFormat("Role/wmapline_m");
    in_str.IntToFormat((long) recordByKey.MapID, 2);
    in_str.AppendFormat("{0}{1}");
    this.Line = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle(in_str, out this.LineassetKey).mainAsset) as GameObject;
  }

  private void FullWinLoad()
  {
    CString cstring = StringManager.Instance.SpawnString();
    byte currentChapterId = DataManager.StageDataController.currentChapterID;
    AssetBundle in_AB = (AssetBundle) null;
    this.LoadLine(currentChapterId, cstring, in_AB);
    ushort num1 = 1;
    if (DataManager.Instance.RoleAttr.Head != (ushort) 0)
      num1 = DataManager.Instance.RoleAttr.Head;
    Hero recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(num1);
    ushort x1 = recordByKey1.Modle;
    if (!DataManager.Instance.CheckHero3DMesh(num1))
      x1 = (ushort) 1;
    cstring.ClearString();
    cstring.StringToFormat("Role/hero_");
    cstring.IntToFormat((long) x1, 5);
    cstring.AppendFormat("{0}{1}");
    this.Pawn = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle(cstring, out this.PawnassetKey).Load("m")) as GameObject;
    this.PawnTransform = this.Pawn.transform;
    this.PawnTransform.localScale = Vector3.one * (float) recordByKey1.Scale * 0.01f;
    NewbieManager.pTrans = this.PawnTransform;
    ushort pointId = (ushort) this.PointID;
    GameObject mainAsset1 = AssetManager.GetAssetBundle("Role/wmap_sbt", out this.PointassetKey).mainAsset as GameObject;
    this.Point = new GameObject[(int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode] - (int) pointId];
    this.PointTransform = new Transform[this.Point.Length];
    for (int index = 0; index < this.Point.Length; ++index)
    {
      this.Point[index] = UnityEngine.Object.Instantiate((UnityEngine.Object) mainAsset1) as GameObject;
      this.PointTransform[index] = this.Point[index].transform;
    }
    byte lineId = this.LineID;
    this.CanBeSelect = new GameObject[(int) lineId + 3];
    this.CanBeSelect[0] = this.CanBeSelect[this.CanBeSelect.Length - 1] = this.CanBeSelect[this.CanBeSelect.Length - 2] = (GameObject) null;
    ushort num2;
    if ((int) (num2 = (ushort) ((uint) pointId + 1U)) != (int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode])
      this.CanBeSelect[0] = this.Pawn;
    this.getBossID(lineId);
    if (DataManager.StageDataController._stageMode == StageMode.Dare)
    {
      for (int index = 0; index < (int) lineId; ++index)
        this.CanBeSelect[index + 1] = (GameObject) null;
    }
    else if (lineId != (byte) 0)
    {
      this._BuildSprite = new MapSprite(WorldMode.OpenUp, (ushort) lineId);
      for (int index = 0; index < (int) lineId; ++index)
        this.CanBeSelect[index + 1] = this._BuildSprite.SpriteGameObject[index];
      this._BuildSprite.SetSprite(DataManager.msgBuffer, DataManager.DataBuffer);
    }
    ushort num3 = GameConstants.ConvertBytesToUShort(DataManager.msgBuffer, (int) lineId << 1);
    Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(num3);
    ushort x2 = recordByKey2.Modle;
    if (!DataManager.Instance.CheckHero3DMesh(num3))
      x2 = (ushort) 1;
    cstring.ClearString();
    cstring.StringToFormat("Role/hero_");
    cstring.IntToFormat((long) x2, 5);
    cstring.AppendFormat("{0}{1}");
    this.Boss = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle(cstring, out this.BossassetKey).Load("m")) as GameObject;
    this.BossTransform = this.Boss.transform;
    this.BossTransform.localScale = Vector3.one * (float) recordByKey2.Scale * 0.01f;
    GameObject mainAsset2 = AssetManager.GetAssetBundle("Role/wmap_bbt", out this.BigPointassetKey).mainAsset as GameObject;
    this.BigPoint = new GameObject[(int) lineId + 1];
    this.BigPointTransform = new Transform[this.BigPoint.Length];
    for (int index = 0; index < this.BigPoint.Length; ++index)
    {
      this.BigPoint[index] = UnityEngine.Object.Instantiate((UnityEngine.Object) mainAsset2) as GameObject;
      this.BigPointTransform[index] = this.BigPoint[index].transform;
    }
    if ((UnityEngine.Object) this.CanBeSelect[0] == (UnityEngine.Object) null)
      this.CanBeSelect[0] = this.Boss;
    else
      this.CanBeSelect[this.CanBeSelect.Length - 1] = this.Boss;
    int num4 = (int) DataManager.StageDataController.StageRecord[0] % (int) GameConstants.StagePointNum[0];
    if (DataManager.StageDataController._stageMode == StageMode.Full && num4 < 15)
    {
      cstring.ClearString();
      cstring.AppendFormat("Role/RewardBtn");
      this.CanBeSelect[this.CanBeSelect.Length - 2] = this.Treasure = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle(cstring, out this.TreasureassetKey).Load("m")) as GameObject;
      this.TreasureTransform = this.Treasure.transform;
    }
    StringManager.Instance.DeSpawnString(cstring);
  }

  private void LeanWinLoad()
  {
    CString cstring = StringManager.Instance.SpawnString();
    byte currentChapterId = DataManager.StageDataController.currentChapterID;
    AssetBundle in_AB = (AssetBundle) null;
    this.LoadLine(currentChapterId, cstring, in_AB);
    byte lineId = this.LineID;
    ushort pointId = (ushort) this.PointID;
    this.CanBeSelect = new GameObject[(int) lineId + 3];
    this.CanBeSelect[this.CanBeSelect.Length - 2] = (GameObject) null;
    ushort num1 = 1;
    if (DataManager.Instance.RoleAttr.Head != (ushort) 0)
      num1 = DataManager.Instance.RoleAttr.Head;
    Hero recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(num1);
    ushort x1 = recordByKey1.Modle;
    if (!DataManager.Instance.CheckHero3DMesh(num1))
      x1 = (ushort) 1;
    cstring.ClearString();
    cstring.StringToFormat("Role/hero_");
    cstring.IntToFormat((long) x1, 5);
    cstring.AppendFormat("{0}{1}");
    this.CanBeSelect[0] = this.Pawn = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle(cstring, out this.PawnassetKey).Load("m")) as GameObject;
    this.PawnTransform = this.Pawn.transform;
    this.PawnTransform.localScale = Vector3.one * (float) recordByKey1.Scale * 0.01f;
    NewbieManager.pTrans = this.PawnTransform;
    ushort num2;
    if ((int) (num2 = (ushort) ((uint) pointId + 1U)) != (int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode])
    {
      GameObject mainAsset = AssetManager.GetAssetBundle("Role/wmap_sbt", out this.PointassetKey).mainAsset as GameObject;
      this.Point = new GameObject[(int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode] - (int) num2];
      this.PointTransform = new Transform[this.Point.Length];
      for (int index = 0; index < this.Point.Length; ++index)
      {
        this.Point[index] = UnityEngine.Object.Instantiate((UnityEngine.Object) mainAsset) as GameObject;
        this.PointTransform[index] = this.Point[index].transform;
      }
    }
    this.getBossID(lineId);
    if (DataManager.StageDataController._stageMode == StageMode.Dare)
    {
      for (int index = 0; index < (int) lineId; ++index)
        this.CanBeSelect[index + 1] = (GameObject) null;
    }
    else if (lineId != (byte) 0)
    {
      this._BuildSprite = new MapSprite(WorldMode.OpenUp, (ushort) lineId);
      for (int index = 0; index < (int) lineId; ++index)
        this.CanBeSelect[index + 1] = this._BuildSprite.SpriteGameObject[index];
      this._BuildSprite.SetSprite(DataManager.msgBuffer, DataManager.DataBuffer);
    }
    ushort num3 = GameConstants.ConvertBytesToUShort(DataManager.msgBuffer, (int) lineId << 1);
    Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(num3);
    ushort x2 = recordByKey2.Modle;
    if (!DataManager.Instance.CheckHero3DMesh(num3))
      x2 = (ushort) 1;
    cstring.ClearString();
    cstring.StringToFormat("Role/hero_");
    cstring.IntToFormat((long) x2, 5);
    cstring.AppendFormat("{0}{1}");
    this.CanBeSelect[this.CanBeSelect.Length - 1] = this.Boss = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle(cstring, out this.BossassetKey).Load("m")) as GameObject;
    this.BossTransform = this.Boss.transform;
    this.BossTransform.localScale = Vector3.one * (float) recordByKey2.Scale * 0.01f;
    ushort num4 = GameConstants.ConvertBytesToUShort(DataManager.msgBuffer, (int) lineId - 1 << 1);
    Hero recordByKey3 = DataManager.Instance.HeroTable.GetRecordByKey(num4);
    ushort x3 = recordByKey3.Modle;
    if (!DataManager.Instance.CheckHero3DMesh(num4))
      x3 = (ushort) 1;
    cstring.ClearString();
    cstring.StringToFormat("Role/hero_");
    cstring.IntToFormat((long) x3, 5);
    cstring.AppendFormat("{0}{1}");
    this.DeadBoss = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle(cstring, out this.DeadBossassetKey).Load("m")) as GameObject;
    this.DeadBossTransform = this.DeadBoss.transform;
    this.DeadBossTransform.localScale = Vector3.one * (float) recordByKey3.Scale * 0.01f;
    GameObject mainAsset1 = AssetManager.GetAssetBundle("Role/wmap_bbt", out this.BigPointassetKey).mainAsset as GameObject;
    this.BigPoint = new GameObject[(int) lineId + 1];
    this.BigPointTransform = new Transform[this.BigPoint.Length];
    for (int index = 0; index < this.BigPoint.Length; ++index)
    {
      this.BigPoint[index] = UnityEngine.Object.Instantiate((UnityEngine.Object) mainAsset1) as GameObject;
      this.BigPointTransform[index] = this.BigPoint[index].transform;
    }
    int num5 = (int) DataManager.StageDataController.StageRecord[0] % (int) GameConstants.StagePointNum[0];
    if (DataManager.StageDataController._stageMode == StageMode.Full && num5 < 16)
    {
      cstring.ClearString();
      cstring.AppendFormat("Role/RewardBtn");
      this.CanBeSelect[this.CanBeSelect.Length - 2] = this.Treasure = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle(cstring, out this.TreasureassetKey).Load("m")) as GameObject;
      if (num5 == 15)
        this.CanBeSelect[this.CanBeSelect.Length - 2] = (GameObject) null;
      this.TreasureTransform = this.Treasure.transform;
    }
    StringManager.Instance.DeSpawnString(cstring);
  }

  private void FinalWinLoad()
  {
    CString cstring = StringManager.Instance.SpawnString();
    byte currentChapterId = DataManager.StageDataController.currentChapterID;
    AssetBundle in_AB = (AssetBundle) null;
    this.LoadLine(currentChapterId, cstring, in_AB);
    byte in_LineID = 5;
    this.getBossID(in_LineID);
    this._BuildSprite = new MapSprite(WorldMode.OpenUp, (ushort) 6);
    this.CanBeSelect = this._BuildSprite.SpriteGameObject;
    this._BuildSprite.SetSprite(DataManager.msgBuffer, DataManager.DataBuffer);
    ushort num1 = 1;
    if (DataManager.Instance.RoleAttr.Head != (ushort) 0)
      num1 = DataManager.Instance.RoleAttr.Head;
    Hero recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(num1);
    ushort x1 = recordByKey1.Modle;
    if (!DataManager.Instance.CheckHero3DMesh(num1))
      x1 = (ushort) 1;
    cstring.ClearString();
    cstring.StringToFormat("Role/hero_");
    cstring.IntToFormat((long) x1, 5);
    cstring.AppendFormat("{0}{1}");
    this.Pawn = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle(cstring, out this.PawnassetKey).Load("m")) as GameObject;
    this.PawnTransform = this.Pawn.transform;
    this.PawnTransform.localScale = Vector3.one * (float) recordByKey1.Scale * 0.01f;
    ushort num2 = GameConstants.ConvertBytesToUShort(DataManager.msgBuffer, (int) in_LineID << 1);
    Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(num2);
    ushort x2 = recordByKey2.Modle;
    if (!DataManager.Instance.CheckHero3DMesh(num2))
      x2 = (ushort) 1;
    cstring.ClearString();
    cstring.StringToFormat("Role/hero_");
    cstring.IntToFormat((long) x2, 5);
    cstring.AppendFormat("{0}{1}");
    this.DeadBoss = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle(cstring, out this.BossassetKey).Load("m")) as GameObject;
    this.DeadBossTransform = this.DeadBoss.transform;
    this.DeadBossTransform.localScale = Vector3.one * (float) recordByKey2.Scale * 0.01f;
    GameObject mainAsset = AssetManager.GetAssetBundle("Role/wmap_bbt", out this.BigPointassetKey).mainAsset as GameObject;
    this.BigPoint = new GameObject[(int) in_LineID + 1];
    this.BigPointTransform = new Transform[this.BigPoint.Length];
    for (int index = 0; index < this.BigPoint.Length; ++index)
    {
      this.BigPoint[index] = UnityEngine.Object.Instantiate((UnityEngine.Object) mainAsset) as GameObject;
      this.BigPointTransform[index] = this.BigPoint[index].transform;
    }
    StringManager.Instance.DeSpawnString(cstring);
  }

  private void defaultLoad()
  {
    CString cstring = StringManager.Instance.SpawnString();
    byte currentChapterId = DataManager.StageDataController.currentChapterID;
    AssetBundle in_AB = (AssetBundle) null;
    this.LoadLine(currentChapterId, cstring, in_AB);
    byte num1;
    if ((int) currentChapterId < (int) DataManager.StageDataController.ChapterID || (int) DataManager.StageDataController.StageRecord[(int) DataManager.StageDataController._stageMode] == (int) DataManager.StageDataController.limitRecord[(int) DataManager.StageDataController._stageMode])
    {
      num1 = (byte) 5;
      this.getBossID(num1);
      this._BuildSprite = new MapSprite(WorldMode.OpenUp, (ushort) 6);
      this.CanBeSelect = this._BuildSprite.SpriteGameObject;
      this._BuildSprite.SetSprite(DataManager.msgBuffer, DataManager.DataBuffer);
    }
    else
    {
      num1 = this.LineID;
      ushort pointId = (ushort) this.PointID;
      this.CanBeSelect = new GameObject[(int) num1 + 3];
      this.CanBeSelect[0] = this.CanBeSelect[this.CanBeSelect.Length - 1] = this.CanBeSelect[this.CanBeSelect.Length - 2] = (GameObject) null;
      ushort num2 = 1;
      if (DataManager.Instance.RoleAttr.Head != (ushort) 0)
        num2 = DataManager.Instance.RoleAttr.Head;
      Hero recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(num2);
      ushort x1 = recordByKey1.Modle;
      if (!DataManager.Instance.CheckHero3DMesh(num2))
        x1 = (ushort) 1;
      cstring.ClearString();
      cstring.StringToFormat("Role/hero_");
      cstring.IntToFormat((long) x1, 5);
      cstring.AppendFormat("{0}{1}");
      this.Pawn = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle(cstring, out this.PawnassetKey).Load("m")) as GameObject;
      this.PawnTransform = this.Pawn.transform;
      this.PawnTransform.localScale = Vector3.one * (float) recordByKey1.Scale * 0.01f;
      NewbieManager.pTrans = this.PawnTransform;
      ushort num3;
      if ((int) (num3 = (ushort) ((uint) pointId + 1U)) != (int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode])
      {
        this.CanBeSelect[0] = this.Pawn;
        GameObject mainAsset = AssetManager.GetAssetBundle("Role/wmap_sbt", out this.PointassetKey).mainAsset as GameObject;
        this.Point = new GameObject[(int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode] - (int) num3];
        this.PointTransform = new Transform[this.Point.Length];
        for (int index = 0; index < this.Point.Length; ++index)
        {
          this.Point[index] = UnityEngine.Object.Instantiate((UnityEngine.Object) mainAsset) as GameObject;
          this.PointTransform[index] = this.Point[index].transform;
        }
      }
      this.getBossID(num1);
      if (DataManager.StageDataController._stageMode == StageMode.Dare)
      {
        for (int index = 0; index < (int) num1; ++index)
          this.CanBeSelect[index + 1] = (GameObject) null;
      }
      else if (num1 != (byte) 0)
      {
        this._BuildSprite = new MapSprite(WorldMode.OpenUp, (ushort) num1);
        for (int index = 0; index < (int) num1; ++index)
          this.CanBeSelect[index + 1] = this._BuildSprite.SpriteGameObject[index];
        this._BuildSprite.SetSprite(DataManager.msgBuffer, DataManager.DataBuffer);
      }
      ushort num4 = GameConstants.ConvertBytesToUShort(DataManager.msgBuffer, (int) num1 << 1);
      Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(num4);
      ushort x2 = recordByKey2.Modle;
      if (!DataManager.Instance.CheckHero3DMesh(num4))
        x2 = (ushort) 1;
      cstring.ClearString();
      cstring.StringToFormat("Role/hero_");
      cstring.IntToFormat((long) x2, 5);
      cstring.AppendFormat("{0}{1}");
      this.Boss = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle(cstring, out this.BossassetKey).Load("m")) as GameObject;
      this.BossTransform = this.Boss.transform;
      this.BossTransform.localScale = Vector3.one * (float) recordByKey2.Scale * 0.01f;
      if ((UnityEngine.Object) this.CanBeSelect[0] == (UnityEngine.Object) null)
        this.CanBeSelect[0] = this.Boss;
      else
        this.CanBeSelect[this.CanBeSelect.Length - 1] = this.Boss;
      int num5 = (int) DataManager.StageDataController.StageRecord[0] % (int) GameConstants.StagePointNum[0];
      if (DataManager.StageDataController._stageMode == StageMode.Full && num5 < 15)
      {
        cstring.ClearString();
        cstring.AppendFormat("Role/RewardBtn");
        this.CanBeSelect[this.CanBeSelect.Length - 2] = this.Treasure = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle(cstring, out this.TreasureassetKey).Load("m")) as GameObject;
        this.TreasureTransform = this.Treasure.transform;
      }
    }
    GameObject mainAsset1 = AssetManager.GetAssetBundle("Role/wmap_bbt", out this.BigPointassetKey).mainAsset as GameObject;
    this.BigPoint = new GameObject[(int) num1 + 1];
    this.BigPointTransform = new Transform[this.BigPoint.Length];
    for (int index = 0; index < this.BigPoint.Length; ++index)
    {
      this.BigPoint[index] = UnityEngine.Object.Instantiate((UnityEngine.Object) mainAsset1) as GameObject;
      this.BigPointTransform[index] = this.BigPoint[index].transform;
    }
    StringManager.Instance.DeSpawnString(cstring);
  }

  private void FirstReady()
  {
    byte index1 = this.LineID;
    if ((int) index1 >= this.BigPoint.Length)
      index1 = (byte) (this.BigPoint.Length - 1);
    this.Line.transform.position = this.LinePos;
    Animation component1 = this.Line.GetComponent<Animation>();
    AnimationState animationState = component1[index1.ToString()];
    animationState.speed = 0.05f;
    if (index1 > (byte) 0)
    {
      float num = (float) (1.0 - 1.0 / (double) ((int) index1 + 1));
      animationState.time = animationState.length * num;
    }
    if (this.stateUpdateDelegates != null)
      component1.Play(index1.ToString());
    else
      component1.Stop();
    for (int index2 = 0; index2 < this.BigPoint.Length; ++index2)
      this.BigPointTransform[index2].position = this.BigPointPos[index2];
    this.BigPointTransform[(int) index1].position = this.BigPointPos[(int) index1] + Vector3.up * 50f;
    this.BigPoint[(int) index1].SetActive(false);
    Vector3 vector3;
    if (this._BuildSprite != null)
    {
      for (int id = 0; id < this._BuildSprite.SpriteGameObject.Length && id < this.BigPointPos.Length; ++id)
      {
        vector3 = this.BigPointPos[id] + Vector3.up * this.Spriteoffset;
        this._BuildSprite.SetSpritePosition((ushort) id, vector3);
        this._BuildSprite.SpriteGameObject[id].transform.LookAt(Camera.main.transform);
        vector3.Set(360f - this._BuildSprite.SpriteGameObject[id].transform.localEulerAngles.x, 182f, 0.0f);
        Quaternion localRotation = this._BuildSprite.SpriteGameObject[id].transform.localRotation with
        {
          eulerAngles = vector3
        };
        this._BuildSprite.SpriteGameObject[id].transform.rotation = localRotation;
      }
    }
    if (this.Point != null)
    {
      for (int index3 = 0; index3 < this.Point.Length; ++index3)
      {
        int index4 = (int) index1 * ((int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode] - 1) + 1 - index3;
        if (index4 >= this.PointPos.Length)
          index4 = this.PointPos.Length - 1;
        this.PointTransform[index3].position = this.PointPos[index4] + Vector3.up * this.FallStart;
        this.Point[index3].SetActive(false);
      }
      if ((UnityEngine.Object) this.Pawn != (UnityEngine.Object) null)
      {
        this.PawnTransform.localScale *= this.Pawnscale;
        this.PawnTransform.position = this.PointTransform[this.Point.Length - 1].position + Vector3.up * this.Pawnoffset;
        vector3 = (this.BigPointTransform[(int) index1].position - this.PawnTransform.position) with
        {
          y = 0.0f
        };
        if (vector3 != Vector3.zero)
          this.PawnTransform.rotation = Quaternion.LookRotation(vector3);
        this.Pawn.GetComponent<Animation>().Stop();
        this.Pawn.SetActive(false);
      }
      if (this.stateUpdateDelegates != null)
      {
        this._openState = OpenUp.OpenState.FirstPointDown;
        this.Point[1].SetActive(true);
      }
      else
        this.Point[1].SetActive(false);
    }
    else if ((UnityEngine.Object) this.Pawn != (UnityEngine.Object) null)
    {
      this.PawnTransform.localScale *= this.Pawnscale;
      this.PawnTransform.position = this.PointPos[0] + Vector3.up * (this.FallStart + this.Pawnoffset);
      vector3 = (this.BigPointTransform[(int) index1].position - this.PawnTransform.position) with
      {
        y = 0.0f
      };
      if (vector3 != Vector3.zero)
        this.PawnTransform.rotation = Quaternion.LookRotation(vector3);
      this.Pawn.GetComponent<Animation>().Stop();
      this.Pawn.SetActive(false);
      if (this.stateUpdateDelegates != null)
      {
        this._openState = OpenUp.OpenState.BigPointDown;
        this.BigPoint[(int) index1].SetActive(true);
      }
      else
        this.BigPoint[(int) index1].SetActive(false);
    }
    if ((UnityEngine.Object) this.Boss != (UnityEngine.Object) null)
    {
      this.BossTransform.position = this.BigPointTransform[(int) index1].position + Vector3.up * this.Bossoffset;
      this.BossTransform.localScale *= this.Bossscale;
      vector3 = (Camera.main.transform.position - this.BossTransform.position) with
      {
        y = 0.0f
      };
      if (vector3 != Vector3.zero)
        this.BossTransform.rotation = Quaternion.LookRotation(vector3);
      this.BossAnimation = this.Boss.GetComponent<Animation>();
      this.BossAnimation.wrapMode = WrapMode.Loop;
      this.BossAnimation.Stop();
      this.Boss.SetActive(false);
    }
    if (!((UnityEngine.Object) this.Treasure != (UnityEngine.Object) null))
      return;
    this.TreasureTransform.position = this.BigPointPos[this.BigPointPos.Length - 1] + Vector3.up * (this.FallStart + this.Treasureoffset);
    this.TreasureTransform.localScale *= this.Treasurescale;
    Animation component2 = this.Treasure.GetComponent<Animation>();
    component2.wrapMode = WrapMode.Loop;
    component2.Play("idle");
    this.Treasure.SetActive(false);
  }

  private void FullWinReady()
  {
    byte lineId = this.LineID;
    this.Line.transform.position = this.LinePos;
    Animation component1 = this.Line.GetComponent<Animation>();
    AnimationState animationState = component1[lineId.ToString()];
    animationState.time = animationState.length;
    component1.Play(lineId.ToString());
    for (int index = 0; index < this.BigPoint.Length; ++index)
      this.BigPointTransform[index].position = this.BigPointPos[index];
    if (this._BuildSprite != null)
    {
      for (ushort id = 0; (int) id < this._BuildSprite.SpriteGameObject.Length; ++id)
      {
        Vector3 pos = this.BigPointPos[(int) id] + Vector3.up * this.Spriteoffset;
        this._BuildSprite.SetSpritePosition(id, pos);
        this._BuildSprite.SpriteGameObject[(int) id].transform.LookAt(Camera.main.transform);
        pos.Set(360f - this._BuildSprite.SpriteGameObject[(int) id].transform.localEulerAngles.x, 182f, 0.0f);
        Quaternion localRotation = this._BuildSprite.SpriteGameObject[(int) id].transform.localRotation with
        {
          eulerAngles = pos
        };
        this._BuildSprite.SpriteGameObject[(int) id].transform.rotation = localRotation;
      }
    }
    if (this.Point != null)
    {
      for (int index = 0; index < this.Point.Length; ++index)
        this.PointTransform[index].position = this.PointPos[(int) lineId * ((int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode] - 1) + 1 - index];
      if ((UnityEngine.Object) this.Pawn != (UnityEngine.Object) null)
      {
        this.PawnTransform.localScale *= this.Pawnscale;
        this.PawnTransform.position = this.PointTransform[this.Point.Length - 1].position + Vector3.up * this.Pawnoffset;
        Vector3 forward = (Camera.main.transform.position - this.Pawn.transform.position) with
        {
          y = 0.0f
        };
        if (forward != Vector3.zero)
          this.PawnTransform.rotation = Quaternion.LookRotation(forward);
        Animation component2 = this.Pawn.GetComponent<Animation>();
        component2.wrapMode = WrapMode.Loop;
        component2.Play("victory");
        Transform transform = this.Halo.transform;
        transform.SetParent(this.Point[this.Point.Length - 1].transform, false);
        transform.localPosition = Vector3.forward * 0.5f;
        transform.rotation = Quaternion.identity;
        this.Halo.SetActive(true);
      }
    }
    if ((UnityEngine.Object) this.Boss != (UnityEngine.Object) null)
    {
      this.BossTransform.position = this.BigPointTransform[(int) lineId].position + Vector3.up * this.Bossoffset;
      this.BossTransform.localScale *= this.Bossscale;
      Vector3 forward = (Camera.main.transform.position - this.BossTransform.position) with
      {
        y = 0.0f
      };
      if (forward != Vector3.zero)
        this.BossTransform.rotation = Quaternion.LookRotation(forward);
      this.BossAnimation = this.Boss.GetComponent<Animation>();
      this.BossAnimation.wrapMode = WrapMode.Loop;
      this.BossAnimationTime = this.BossAnimation["victory"].length;
      this.BossAnimation.Play("victory");
    }
    if (!((UnityEngine.Object) this.Treasure != (UnityEngine.Object) null))
      return;
    this.TreasureTransform.position = this.BigPointPos[this.BigPointPos.Length - 1] + Vector3.up * this.Treasureoffset;
    this.TreasureTransform.localScale *= this.Treasurescale;
    Animation component3 = this.Treasure.GetComponent<Animation>();
    component3.wrapMode = WrapMode.Loop;
    component3.Play("idle");
  }

  private void LeanWinReady()
  {
    byte num = (byte) ((uint) this.LineID - 1U);
    this.Line.transform.position = this.LinePos;
    Animation component1 = this.Line.GetComponent<Animation>();
    AnimationState animationState = component1[num.ToString()];
    animationState.time = animationState.length;
    component1.Play(num.ToString());
    byte index1 = (byte) ((uint) num + 1U);
    for (int index2 = 0; index2 < this.BigPoint.Length; ++index2)
      this.BigPointTransform[index2].position = this.BigPointPos[index2];
    this.BigPointTransform[(int) index1].position = this.BigPointPos[(int) index1] + Vector3.up * this.FallStart;
    this.BigPoint[(int) index1].SetActive(false);
    Vector3 vector3_1;
    if (this._BuildSprite != null)
    {
      for (int id = 0; id < (int) index1; ++id)
      {
        vector3_1 = this.BigPointPos[id] + Vector3.up * this.Spriteoffset;
        this._BuildSprite.SetSpritePosition((ushort) id, vector3_1);
        this._BuildSprite.SpriteGameObject[id].transform.LookAt(Camera.main.transform);
        vector3_1.Set(360f - this._BuildSprite.SpriteGameObject[id].transform.localEulerAngles.x, 182f, 0.0f);
        Quaternion localRotation = this._BuildSprite.SpriteGameObject[id].transform.localRotation with
        {
          eulerAngles = vector3_1
        };
        this._BuildSprite.SpriteGameObject[id].transform.rotation = localRotation;
      }
      this._BuildSprite.SpriteGameObject[(int) index1 - 1].transform.position = this.BigPointPos[(int) index1 - 1] + Vector3.down * this.UpStart;
      this._BuildSprite.SpriteGameObject[(int) index1 - 1].gameObject.SetActive(false);
    }
    if (this.Point != null)
    {
      for (int index3 = 0; index3 < this.Point.Length; ++index3)
      {
        Transform transform = this.PointTransform[index3];
        Vector3 vector3_2 = this.PointPos[(int) index1 * ((int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode] - 1) + 1 - index3] + Vector3.up * this.FallStart;
        this.PointTransform[index3].position = vector3_2;
        Vector3 vector3_3 = vector3_2;
        transform.position = vector3_3;
        this.Point[index3].SetActive(false);
      }
    }
    if ((UnityEngine.Object) this.Pawn != (UnityEngine.Object) null)
    {
      this.PawnTransform.localScale *= this.Pawnscale;
      this.PawnTransform.position = (this.BigPointTransform[(int) index1 - 1].position + this.PointPos[2 * (int) index1 - 1]) * 0.5f + Vector3.up * this.Pawnoffset;
      vector3_1 = (Camera.main.transform.position - this.PawnTransform.position) with
      {
        y = 0.0f
      };
      if (vector3_1 != Vector3.zero)
        this.PawnTransform.rotation = Quaternion.LookRotation(vector3_1);
      Animation component2 = this.Pawn.GetComponent<Animation>();
      component2.wrapMode = WrapMode.Loop;
      component2.Play("victory");
    }
    if ((UnityEngine.Object) this.Boss != (UnityEngine.Object) null)
    {
      this.BossTransform.position = this.BigPointTransform[(int) index1].position + Vector3.up * this.Bossoffset;
      this.BossTransform.localScale *= this.Bossscale;
      vector3_1 = (Camera.main.transform.position - this.BossTransform.position) with
      {
        y = 0.0f
      };
      if (vector3_1 != Vector3.zero)
        this.BossTransform.rotation = Quaternion.LookRotation(vector3_1);
      this.BossAnimation = this.Boss.GetComponent<Animation>();
      this.BossAnimation.Stop();
      this.Boss.SetActive(false);
    }
    if ((UnityEngine.Object) this.DeadBoss != (UnityEngine.Object) null)
    {
      this.DeadBossTransform.position = this.BigPointTransform[(int) index1 - 1].position + Vector3.up * this.Bossoffset;
      this.DeadBossTransform.localScale *= this.Bossscale;
      vector3_1 = (Camera.main.transform.position - this.DeadBossTransform.position) with
      {
        y = 0.0f
      };
      if (vector3_1 != Vector3.zero)
        this.DeadBossTransform.rotation = Quaternion.LookRotation(vector3_1);
      this.DeadBossAnimation = this.DeadBoss.GetComponent<Animation>();
      this.DeadBossAnimation.wrapMode = WrapMode.Once;
      this.DeadBossAnimation.Play("die");
      this.DeadBossAnimation.Stop();
    }
    if ((UnityEngine.Object) this.Treasure != (UnityEngine.Object) null)
    {
      this.TreasureTransform.position = this.BigPointPos[this.BigPointPos.Length - 1] + Vector3.up * this.Treasureoffset;
      this.TreasureTransform.localScale *= this.Treasurescale;
      Animation component3 = this.Treasure.GetComponent<Animation>();
      component3.wrapMode = WrapMode.Loop;
      component3.Play("idle");
    }
    if ((int) DataManager.MissionDataManager.HeroNum != (int) DataManager.Instance.CurHeroDataCount)
      return;
    StageManager stageDataController = DataManager.StageDataController;
    if (stageDataController._stageMode == StageMode.Full || stageDataController._stageMode == StageMode.Lean)
    {
      DataManager.MissionDataManager.CheckChanged((eMissionKind) ((byte) 3 + DataManager.StageDataController._stageMode), (ushort) 1, DataManager.StageDataController.StageRecord[(int) DataManager.StageDataController._stageMode]);
    }
    else
    {
      if (stageDataController._stageMode != StageMode.Dare)
        return;
      int stagePoint = stageDataController.GetStagePoint(stageDataController.currentPointID, (byte) 0);
      DataManager.MissionDataManager.CheckChanged(eMissionKind.ChallengeStage, (ushort) 1, stageDataController.StageRecord[3]);
      if (stagePoint <= 0)
        return;
      DataManager.MissionDataManager.CheckChanged(eMissionKind.ChallengeAdvance, stageDataController.currentPointID, (ushort) stagePoint);
    }
  }

  private void FinalWinReady()
  {
    byte index1 = 5;
    this.Line.transform.position = this.LinePos;
    Animation component1 = this.Line.GetComponent<Animation>();
    AnimationState animationState = component1[index1.ToString()];
    animationState.time = animationState.length;
    component1.Play(index1.ToString());
    for (int index2 = 0; index2 < this.BigPoint.Length; ++index2)
      this.BigPointTransform[index2].position = this.BigPointPos[index2];
    Vector3 vector3;
    if (this._BuildSprite != null)
    {
      if (DataManager.StageDataController._stageMode == StageMode.Dare)
      {
        for (ushort id = 0; (int) id < this._BuildSprite.SpriteGameObject.Length; ++id)
        {
          vector3 = this.BigPointPos[(int) id] + Vector3.down * this.UpStart;
          this._BuildSprite.SetSpritePosition(id, vector3);
          this._BuildSprite.SpriteGameObject[(int) id].transform.LookAt(Camera.main.transform);
          vector3.Set(360f - this._BuildSprite.SpriteGameObject[(int) id].transform.localEulerAngles.x, 182f, 0.0f);
          Quaternion localRotation = this._BuildSprite.SpriteGameObject[(int) id].transform.localRotation with
          {
            eulerAngles = vector3
          };
          this._BuildSprite.SpriteGameObject[(int) id].transform.rotation = localRotation;
          this._BuildSprite.SpriteGameObject[(int) id].gameObject.SetActive(false);
        }
      }
      else
      {
        for (ushort id = 0; (int) id < this._BuildSprite.SpriteGameObject.Length; ++id)
        {
          vector3 = this.BigPointPos[(int) id] + Vector3.up * this.Spriteoffset;
          this._BuildSprite.SetSpritePosition(id, vector3);
          this._BuildSprite.SpriteGameObject[(int) id].transform.LookAt(Camera.main.transform);
          vector3.Set(360f - this._BuildSprite.SpriteGameObject[(int) id].transform.localEulerAngles.x, 182f, 0.0f);
          Quaternion localRotation = this._BuildSprite.SpriteGameObject[(int) id].transform.localRotation with
          {
            eulerAngles = vector3
          };
          this._BuildSprite.SpriteGameObject[(int) id].transform.rotation = localRotation;
        }
        this._BuildSprite.SpriteGameObject[(int) index1].transform.position = this.BigPointPos[(int) index1] + Vector3.down * this.UpStart;
        this._BuildSprite.SpriteGameObject[(int) index1].gameObject.SetActive(false);
      }
    }
    if ((UnityEngine.Object) this.Pawn != (UnityEngine.Object) null)
    {
      this.PawnTransform.localScale *= this.Pawnscale;
      this.PawnTransform.position = (this.BigPointTransform[(int) index1].position + this.PointPos[(int) index1 * ((int) GameConstants.LinePointNum[0] - 1) + 1]) * 0.5f + Vector3.up * this.Pawnoffset;
      vector3 = (Camera.main.transform.position - this.PawnTransform.position) with
      {
        y = 0.0f
      };
      if (vector3 != Vector3.zero)
        this.PawnTransform.rotation = Quaternion.LookRotation(vector3);
      Animation component2 = this.Pawn.GetComponent<Animation>();
      component2.wrapMode = WrapMode.Loop;
      component2.Play("victory");
    }
    if ((UnityEngine.Object) this.DeadBoss != (UnityEngine.Object) null)
    {
      this.DeadBossTransform.position = this.BigPointTransform[(int) index1].position + Vector3.up * this.Bossoffset;
      this.DeadBossTransform.localScale *= this.Bossscale;
      vector3 = (Camera.main.transform.position - this.DeadBossTransform.position) with
      {
        y = 0.0f
      };
      if (vector3 != Vector3.zero)
        this.DeadBossTransform.rotation = Quaternion.LookRotation(vector3);
      this.DeadBossAnimation = this.DeadBoss.GetComponent<Animation>();
      this.DeadBossAnimation.wrapMode = WrapMode.Once;
      this.DeadBossAnimation.Play("die");
      this.DeadBossAnimation.Stop();
    }
    if ((int) DataManager.MissionDataManager.HeroNum != (int) DataManager.Instance.CurHeroDataCount)
      return;
    StageManager stageDataController = DataManager.StageDataController;
    if (stageDataController._stageMode == StageMode.Full || stageDataController._stageMode == StageMode.Lean)
    {
      DataManager.MissionDataManager.CheckChanged((eMissionKind) ((byte) 3 + DataManager.StageDataController._stageMode), (ushort) 1, DataManager.StageDataController.StageRecord[(int) DataManager.StageDataController._stageMode]);
    }
    else
    {
      if (stageDataController._stageMode != StageMode.Dare)
        return;
      int stagePoint = stageDataController.GetStagePoint(stageDataController.currentPointID, (byte) 0);
      DataManager.MissionDataManager.CheckChanged(eMissionKind.ChallengeStage, (ushort) 1, stageDataController.StageRecord[3]);
      if (stagePoint <= 0)
        return;
      DataManager.MissionDataManager.CheckChanged(eMissionKind.ChallengeAdvance, stageDataController.currentPointID, (ushort) stagePoint);
    }
  }

  private void defaultReady()
  {
    byte index1 = (int) DataManager.StageDataController.currentChapterID >= (int) DataManager.StageDataController.ChapterID ? this.LineID : (byte) 5;
    this.Line.transform.position = this.LinePos;
    Animation component1 = this.Line.GetComponent<Animation>();
    AnimationState animationState = component1[index1.ToString()];
    animationState.time = animationState.length;
    component1.Play(index1.ToString());
    for (int index2 = 0; index2 < this.BigPoint.Length; ++index2)
      this.BigPointTransform[index2].position = this.BigPointPos[index2];
    if (this._BuildSprite != null)
    {
      for (ushort id = 0; (int) id < this._BuildSprite.SpriteGameObject.Length; ++id)
      {
        Vector3 pos = this.BigPointPos[(int) id] + Vector3.up * this.Spriteoffset;
        this._BuildSprite.SetSpritePosition(id, pos);
        this._BuildSprite.SpriteGameObject[(int) id].transform.LookAt(Camera.main.transform);
        pos.Set(360f - this._BuildSprite.SpriteGameObject[(int) id].transform.localEulerAngles.x, 182f, 0.0f);
        Quaternion localRotation = this._BuildSprite.SpriteGameObject[(int) id].transform.localRotation with
        {
          eulerAngles = pos
        };
        this._BuildSprite.SpriteGameObject[(int) id].transform.rotation = localRotation;
      }
    }
    if (this.Point != null)
    {
      for (int index3 = 0; index3 < this.Point.Length; ++index3)
        this.PointTransform[index3].position = this.PointPos[(int) index1 * ((int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode] - 1) + 1 - index3];
    }
    Vector3 forward;
    if ((UnityEngine.Object) this.Pawn != (UnityEngine.Object) null)
    {
      Animation component2 = this.Pawn.GetComponent<Animation>();
      component2.wrapMode = WrapMode.Loop;
      byte pointId = this.PointID;
      this.PawnTransform.localScale *= this.Pawnscale;
      Transform transform = this.Halo.transform;
      Vector3 position;
      if (this.Point == null || (int) pointId == (int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode] - 1)
      {
        position = this.BigPointTransform[(int) index1].position;
        this.PawnTransform.position = (position + this.PointPos[2 * ((int) index1 + 1) - 1]) * 0.5f + Vector3.up * this.Pawnoffset;
        transform.SetParent(this.BigPointTransform[(int) index1], false);
        transform.localPosition = Vector3.forward * 1.4f;
        transform.rotation = Quaternion.identity;
        this.Halo.SetActive(true);
        component2.Play("idle");
      }
      else
      {
        this.PawnTransform.position = this.PointTransform[this.Point.Length - 1].position + Vector3.up * this.Pawnoffset;
        transform.SetParent(this.PointTransform[this.Point.Length - 1], false);
        transform.localPosition = Vector3.forward * 0.5f;
        transform.rotation = Quaternion.identity;
        this.Halo.SetActive(true);
        position = this.BigPointTransform[(int) index1].position;
        component2.Play("moving");
      }
      forward = (position - this.PawnTransform.position) with
      {
        y = 0.0f
      };
      if (forward != Vector3.zero)
        this.PawnTransform.rotation = Quaternion.LookRotation(forward);
    }
    if ((UnityEngine.Object) this.Boss != (UnityEngine.Object) null)
    {
      this.BossTransform.position = this.BigPointTransform[(int) index1].position + Vector3.up * this.Bossoffset;
      this.BossTransform.localScale *= this.Bossscale;
      forward = (Camera.main.transform.position - this.BossTransform.position) with
      {
        y = 0.0f
      };
      if (forward != Vector3.zero)
        this.BossTransform.rotation = Quaternion.LookRotation(forward);
      this.BossAnimation = this.Boss.GetComponent<Animation>();
      this.BossAnimation.wrapMode = WrapMode.Loop;
      this.BossAnimationTime = this.BossAnimation["victory"].length;
      this.BossAnimation.Play("victory");
    }
    if ((UnityEngine.Object) this.Treasure != (UnityEngine.Object) null)
    {
      this.TreasureTransform.position = this.BigPointPos[this.BigPointPos.Length - 1] + Vector3.up * this.Treasureoffset;
      this.TreasureTransform.localScale *= this.Treasurescale;
      Animation component3 = this.Treasure.GetComponent<Animation>();
      component3.wrapMode = WrapMode.Loop;
      component3.Play("idle");
    }
    this.StartInOut(OpenUp.OpenState.In);
    if (DataManager.StageDataController.DareNodusUpdatePointID <= (ushort) 0 || DataManager.StageDataController._stageMode != StageMode.Dare || (int) DataManager.StageDataController.DareNodusUpdatePointID != (int) DataManager.StageDataController.currentPointID)
    {
      DataManager.msgBuffer[0] = (byte) 47;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      DataManager.msgBuffer[0] = (byte) 43;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
    if (DataManager.StageDataController._stageMode == StageMode.Dare && (int) DataManager.StageDataController.StageRecord[3] >= (int) GameConstants.StagePointNum[3] && NewbieManager.CheckDareLead() && this._BuildSprite != null)
    {
      for (int index4 = 0; index4 < this._BuildSprite.SpriteGameObject.Length; ++index4)
        NewbieManager.HeroIconCache[index4] = index4 >= 6 ? (GameObject) null : this._BuildSprite.SpriteGameObject[index4];
    }
    if ((int) DataManager.MissionDataManager.HeroNum != (int) DataManager.Instance.CurHeroDataCount)
      return;
    StageManager stageDataController = DataManager.StageDataController;
    if (stageDataController._stageMode != StageMode.Dare)
      return;
    int stagePoint = stageDataController.GetStagePoint(stageDataController.currentPointID, (byte) 0);
    DataManager.MissionDataManager.CheckChanged(eMissionKind.ChallengeStage, (ushort) 1, stageDataController.StageRecord[3]);
    if (stagePoint <= 0)
      return;
    DataManager.MissionDataManager.CheckChanged(eMissionKind.ChallengeAdvance, stageDataController.currentPointID, (ushort) stagePoint);
  }

  private void CorpsReady()
  {
    if (!((UnityEngine.Object) this.OpenUpCorpsStage != (UnityEngine.Object) null))
      return;
    if (this._openState == OpenUp.OpenState.CorpsWin)
    {
      this.DeadBoss = this.OpenUpCorpsStage.transform.GetChild(1).gameObject;
      this.DeadBossTransform = this.DeadBoss.transform;
      this.DeadBossAnimation = this.DeadBoss.GetComponent<Animation>();
      if ((bool) (UnityEngine.Object) this.DeadBossAnimation)
      {
        this.DeadBossAnimation.wrapMode = WrapMode.Once;
        this.DeadBossAnimation.Play("die");
        this.DeadBossAnimation.Stop();
      }
      CorpsStage recordByKey = DataManager.StageDataController.CorpsStageTable.GetRecordByKey(DataManager.StageDataController.StageRecord[2]);
      GUIManager.Instance.AddHUDMessage(string.Format(DataManager.Instance.mStringTable.GetStringByID(7371U), (object) DataManager.Instance.GetExpAddition((uint) recordByKey.LeadExp), (object) recordByKey.HeroExp), (ushort) 26);
      DataManager.MissionDataManager.CheckChanged(eMissionKind.CorpsPVE, (ushort) 1, DataManager.StageDataController.StageRecord[2]);
      DataManager.FBMissionDataManager.CheckHUDMsg((byte) 7);
    }
    else
    {
      this.BossAnimation = this.OpenUpCorpsStage.transform.GetChild(1).gameObject.GetComponent<Animation>();
      if ((bool) (UnityEngine.Object) this.BossAnimation)
      {
        this.BossAnimation.wrapMode = WrapMode.Loop;
        this.BossAnimation.CrossFade("victory", 0.3f);
      }
      DataManager.msgBuffer[0] = (byte) 47;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      if (DataManager.Instance.lastBattleResult != (short) 0)
        return;
      DataManager.Instance.lastBattleResult = (short) -1;
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7344U), (ushort) 23);
    }
  }

  private void FirstRun()
  {
    byte index = 0;
    switch (this._openState)
    {
      case OpenUp.OpenState.BigPointDown:
        if (!this.MoveRun(this.BigPointTransform[(int) index], Vector3.up, -200f, this.BigPointPos[(int) index].y, OpenUp.OpenState.BossZoom))
          break;
        AudioManager.Instance.PlayUISFX(UIKind.PlatformDrop);
        if (DataManager.StageDataController._stageMode == StageMode.Full)
        {
          this.Treasure.SetActive(true);
          break;
        }
        this._openState = OpenUp.OpenState.BossDown;
        this.Boss.SetActive(true);
        break;
      case OpenUp.OpenState.FirstPointDown:
        if (!this.MoveRun(this.PointTransform[1], Vector3.up, -200f, this.PointPos[0].y, OpenUp.OpenState.SecPointDown))
          break;
        AudioManager.Instance.PlayUISFX(UIKind.PlatformDrop);
        this.Point[0].SetActive(true);
        break;
      case OpenUp.OpenState.SecPointDown:
        if (!this.MoveRun(this.PointTransform[0], Vector3.up, -200f, this.PointPos[1].y, OpenUp.OpenState.BigPointDown))
          break;
        AudioManager.Instance.PlayUISFX(UIKind.PlatformDrop);
        this.BigPoint[(int) index].SetActive(true);
        break;
      case OpenUp.OpenState.BossDown:
        if (!this.MoveRun(this.BossTransform, Vector3.up, -200f, this.BigPointPos[(int) index].y + this.Bossoffset, OpenUp.OpenState.PawnDown))
          break;
        AudioManager.Instance.PlayUISFX(UIKind.BossDrop);
        this.BossAnimation.wrapMode = WrapMode.Loop;
        this.BossAnimationTime = this.BossAnimation["victory"].length;
        this.BossAnimation.Play("victory");
        this.Pawn.SetActive(true);
        break;
      case OpenUp.OpenState.PawnDown:
        if (!this.MoveRun(this.PawnTransform, Vector3.up, -200f, this.PointPos[0].y + this.Pawnoffset, OpenUp.OpenState.Count))
          break;
        Animation component1 = this.Pawn.GetComponent<Animation>();
        component1.wrapMode = WrapMode.Loop;
        component1.Play("moving");
        Transform transform = this.Halo.transform;
        if (this.Point == null)
        {
          transform.SetParent(this.BigPointTransform[0], false);
          this._openState = OpenUp.OpenState.PawnMove;
        }
        else
          transform.SetParent(this.PointTransform[1], false);
        transform.localPosition = Vector3.forward * 0.5f;
        transform.rotation = Quaternion.identity;
        this.Halo.SetActive(true);
        break;
      case OpenUp.OpenState.PawnTurn:
        if (((this.BigPointTransform[(int) index].position + this.PointPos[1]) * 0.5f - this.PawnTransform.position) with
        {
          y = 0.0f
        } == Vector3.zero)
        {
          this._openState = OpenUp.OpenState.Count;
          Animation component2 = this.Pawn.GetComponent<Animation>();
          component2.wrapMode = WrapMode.Loop;
          component2.CrossFade("idle", 0.3f);
          break;
        }
        this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation((this.BigPointTransform[(int) index].position - this.PointPos[1]) with
        {
          y = 0.0f
        }), (float) ((double) Time.deltaTime * 10.0 * 0.5));
        this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, (this.BigPointTransform[(int) index].position + this.PointPos[1]) * 0.5f + Vector3.up * this.Pawnoffset, Time.deltaTime * 10f);
        break;
      case OpenUp.OpenState.PawnMove:
        if (this.PawnTransform.position == this.PointPos[1] + Vector3.up * this.Pawnoffset)
        {
          this._openState = OpenUp.OpenState.PawnTurn;
          break;
        }
        Vector3 forward = (this.PointPos[1] - this.PawnTransform.position) with
        {
          y = 0.0f
        };
        if (!(forward != Vector3.zero))
          break;
        forward = (this.PointPos[1] - this.PointPos[0]) with
        {
          y = 0.0f
        };
        this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(forward), (float) ((double) Time.deltaTime * 10.0 * 0.5));
        this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, this.PointPos[1] + Vector3.up * this.Pawnoffset, Time.deltaTime * 10f);
        break;
      case OpenUp.OpenState.BossZoom:
        if (!this.MoveRun(this.TreasureTransform, Vector3.up, -200f, this.BigPointPos[this.BigPointPos.Length - 1].y + this.Treasureoffset, OpenUp.OpenState.BossDown))
          break;
        AudioManager.Instance.PlayUISFX(UIKind.PlatformDrop);
        this.Boss.SetActive(true);
        break;
      default:
        this._openState = OpenUp.OpenState.Count;
        this.stateUpdateDelegates = (OpenUp.StateUpdateDelegate) null;
        DataManager.msgBuffer[0] = (byte) 44;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        DataManager.msgBuffer[0] = (byte) 47;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        if (DataManager.StageDataController._stageMode == StageMode.Corps)
        {
          DataManager.msgBuffer[0] = (byte) 37;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
        else if (DataManager.StageDataController._stageMode == StageMode.Full)
        {
          if (!NewbieManager.IsTeachWorking(ETeachKind.DARE_FULL))
            DataManager.StageDataController.isNotFirstInLine[(int) DataManager.StageDataController._stageMode] = (byte) 1;
          DataManager.msgBuffer[0] = (byte) 37;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
        else
          DataManager.StageDataController.isNotFirstInLine[(int) DataManager.StageDataController._stageMode] = (byte) 1;
        DataManager.msgBuffer[0] = (byte) 43;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
    }
  }

  private void FullWinRun()
  {
    byte lineId = this.LineID;
    switch (this._openState)
    {
      case OpenUp.OpenState.FirstPointDown:
        if (!this.MoveRun(this.PointTransform[this.Point.Length - 1], Vector3.up, -1f, this.PointPos[(int) lineId * ((int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode] - 1) - this.Point.Length + 2].y - this.PointDown, OpenUp.OpenState.PawnMove))
          break;
        Animation component1 = this.Pawn.GetComponent<Animation>();
        component1.wrapMode = WrapMode.Loop;
        component1.CrossFade("moving", 0.3f);
        Transform transform = this.Halo.transform;
        if (this.PointID == (byte) 2)
        {
          transform.SetParent(this.BigPointTransform[(int) lineId], false);
          transform.localPosition = Vector3.forward * 1.4f;
        }
        else
        {
          transform.SetParent(this.PointTransform[0], false);
          transform.localPosition = Vector3.forward * 0.5f;
        }
        transform.rotation = Quaternion.identity;
        break;
      case OpenUp.OpenState.PawnTurn:
        Quaternion quaternion = Quaternion.LookRotation((this.BigPointTransform[(int) lineId].position - this.PointTransform[0].position) with
        {
          y = 0.0f
        });
        if ((double) Quaternion.Angle(quaternion, this.PawnTransform.rotation) == 0.0)
        {
          this._openState = OpenUp.OpenState.Count;
          break;
        }
        this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, quaternion, (float) ((double) Time.deltaTime * 10.0 * 0.5));
        break;
      case OpenUp.OpenState.PawnMove:
        if (this.PointID == (byte) 2)
        {
          Vector3 forward = ((this.BigPointTransform[(int) lineId].position + this.PointTransform[0].position) * 0.5f - this.PawnTransform.position) with
          {
            y = 0.0f
          };
          if (forward == Vector3.zero)
          {
            this._openState = OpenUp.OpenState.Count;
            Animation component2 = this.Pawn.GetComponent<Animation>();
            component2.wrapMode = WrapMode.Loop;
            component2.CrossFade("idle", 0.3f);
            break;
          }
          forward = (this.BigPointTransform[(int) lineId].position - this.PointTransform[0].position) with
          {
            y = 0.0f
          };
          this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(forward), (float) ((double) Time.deltaTime * 10.0 * 0.5));
          this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, (this.BigPointTransform[(int) lineId].position + this.PointTransform[0].position) * 0.5f + Vector3.up * this.Pawnoffset, Time.deltaTime * 10f);
          break;
        }
        Vector3 forward1 = (this.PointTransform[0].position - this.PawnTransform.position) with
        {
          y = 0.0f
        };
        if (forward1 == Vector3.zero)
        {
          this._openState = OpenUp.OpenState.PawnTurn;
          break;
        }
        forward1 = (this.PointTransform[0].position - this.PointTransform[1].position) with
        {
          y = 0.0f
        };
        this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(forward1), (float) ((double) Time.deltaTime * 10.0 * 0.5));
        this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, this.PointTransform[0].position + Vector3.up * this.Pawnoffset, Time.deltaTime * 10f);
        break;
      default:
        this._openState = OpenUp.OpenState.Count;
        this.stateUpdateDelegates = (OpenUp.StateUpdateDelegate) null;
        DataManager.msgBuffer[0] = (byte) 44;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        DataManager.msgBuffer[0] = (byte) 47;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        NewbieManager.CheckShowArrow(true, this.Halo);
        if (NewbieManager.CheckPutOnEquipTeach())
          NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP);
        DataManager.msgBuffer[0] = (byte) 43;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
    }
  }

  private void LeanWinRun()
  {
    byte lineId = this.LineID;
    switch (this._openState)
    {
      case OpenUp.OpenState.BigPointDown:
        if (this.MoveRun(this.BigPointTransform[(int) lineId], Vector3.up, -200f, this.BigPointPos[(int) lineId].y, OpenUp.OpenState.BossDown))
        {
          AudioManager.Instance.PlayUISFX(UIKind.PlatformDrop);
          this.Boss.SetActive(true);
          if ((UnityEngine.Object) this.Treasure != (UnityEngine.Object) null && (int) DataManager.StageDataController.StageRecord[0] % (int) GameConstants.StagePointNum[0] == 15)
            this.Treasure.SetActive(false);
          if (this.Point == null)
          {
            DataManager.msgBuffer[0] = (byte) 44;
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
            DataManager.msgBuffer[0] = (byte) 47;
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
            DataManager.msgBuffer[0] = (byte) 43;
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          }
        }
        if (this.Point == null)
          this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation((this.BigPointTransform[(int) lineId].position - this.PawnTransform.position) with
          {
            y = 0.0f
          }), (float) ((double) Time.deltaTime * 200.0 * 0.10000000149011612));
        if (!((UnityEngine.Object) this.Treasure != (UnityEngine.Object) null) || (int) DataManager.StageDataController.StageRecord[0] % (int) GameConstants.StagePointNum[0] != 15)
          break;
        float num1 = 12f;
        if ((double) this.BigPointTransform[(int) lineId].position.y >= (double) this.BigPointPos[(int) lineId].y + (double) num1)
          break;
        this.TreasureTransform.position = this.TreasureTransform.position with
        {
          y = this.BigPointTransform[(int) lineId].position.y - num1
        };
        break;
      case OpenUp.OpenState.FirstPointDown:
        if (this.MoveRun(this.PointTransform[1], Vector3.up, -200f, this.PointPos[(int) lineId * ((int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode] - 1)].y, OpenUp.OpenState.SecPointDown))
        {
          AudioManager.Instance.PlayUISFX(UIKind.PlatformDrop);
          this.Point[0].SetActive(true);
          DataManager.msgBuffer[0] = (byte) 44;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          DataManager.msgBuffer[0] = (byte) 47;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          DataManager.msgBuffer[0] = (byte) 43;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
        this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation((this.PointTransform[1].position - this.PawnTransform.position) with
        {
          y = 0.0f
        }), (float) ((double) Time.deltaTime * 200.0 * 0.10000000149011612));
        break;
      case OpenUp.OpenState.SecPointDown:
        if (!this.MoveRun(this.PointTransform[0], Vector3.up, -200f, this.PointPos[(int) lineId * ((int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode] - 1) + 1].y, OpenUp.OpenState.BigPointDown))
          break;
        AudioManager.Instance.PlayUISFX(UIKind.PlatformDrop);
        this.BigPoint[(int) lineId].SetActive(true);
        break;
      case OpenUp.OpenState.BossDown:
        if (!this.MoveRun(this.BossTransform, Vector3.up, -200f, this.BigPointPos[(int) lineId].y + this.Bossoffset, OpenUp.OpenState.PawnDown))
          break;
        AudioManager.Instance.PlayUISFX(UIKind.BossDrop);
        this.BossAnimation.wrapMode = WrapMode.Loop;
        this.BossAnimationTime = this.BossAnimation["victory"].length;
        this.BossAnimation.Play("victory");
        Transform transform = this.Halo.transform;
        if (this.Point == null)
        {
          transform.SetParent(this.BigPointTransform[(int) lineId], false);
          transform.localPosition = Vector3.forward * 1.4f;
        }
        else
        {
          transform.SetParent(this.PointTransform[1], false);
          transform.localPosition = Vector3.forward * 0.5f;
        }
        transform.rotation = Quaternion.identity;
        this.Halo.SetActive(true);
        break;
      case OpenUp.OpenState.PawnDown:
        if (this.Point == null)
        {
          Vector3 forward = (this.PointPos[2 * (int) lineId] - this.PawnTransform.position) with
          {
            y = 0.0f
          };
          if (forward == Vector3.zero)
          {
            this._openState = OpenUp.OpenState.LineUp;
            break;
          }
          this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(forward), (float) ((double) Time.deltaTime * 200.0 * 0.05000000074505806));
          this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, this.PointPos[2 * (int) lineId] + Vector3.up * this.Pawnoffset, (float) ((double) Time.deltaTime * 200.0 * 0.05000000074505806));
          break;
        }
        Vector3 forward1 = (this.PointTransform[1].position - this.PawnTransform.position) with
        {
          y = 0.0f
        };
        if (forward1 == Vector3.zero)
        {
          if (this._BuildSprite == null)
          {
            this._openState = OpenUp.OpenState.Count;
            break;
          }
          this._BuildSprite.SpriteGameObject[this._BuildSprite.SpriteGameObject.Length - 1].SetActive(true);
          this._openState = OpenUp.OpenState.SpriteUp;
          break;
        }
        this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(forward1), (float) ((double) Time.deltaTime * 200.0 * 0.02500000037252903));
        this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, this.PointTransform[1].position + Vector3.up * this.Pawnoffset, (float) ((double) Time.deltaTime * 200.0 * 0.05000000074505806));
        break;
      case OpenUp.OpenState.PawnTurn:
        Quaternion quaternion = Quaternion.LookRotation((this.BigPointPos[(int) lineId - 1] - this.PointPos[2 * (int) lineId - 1]) with
        {
          y = 0.0f
        });
        if ((double) Quaternion.Angle(quaternion, this.PawnTransform.rotation) == 0.0)
        {
          this._openState = OpenUp.OpenState.PawnMove;
          break;
        }
        this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, quaternion, (float) ((double) Time.deltaTime * 200.0 * 0.10000000149011612));
        break;
      case OpenUp.OpenState.PawnMove:
        if ((this.BigPointPos[(int) lineId - 1] - this.PawnTransform.position) with
        {
          y = 0.0f
        } == Vector3.zero)
        {
          Animation component = this.Line.GetComponent<Animation>();
          AnimationState animationState = component[lineId.ToString()];
          animationState.speed = 0.05f;
          if (lineId > (byte) 0)
          {
            float num2 = (float) (1.0 - 1.0 / (double) ((int) lineId + 1));
            animationState.time = animationState.length * num2;
          }
          component.Play(lineId.ToString());
          if (this.Point == null)
          {
            this.BigPoint[(int) lineId].SetActive(true);
            this._openState = OpenUp.OpenState.BigPointDown;
            break;
          }
          this.Point[1].SetActive(true);
          this._openState = OpenUp.OpenState.FirstPointDown;
          break;
        }
        this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, this.BigPointPos[(int) lineId - 1] + Vector3.up * this.Pawnoffset, (float) ((double) Time.deltaTime * 200.0 * 0.05000000074505806));
        break;
      case OpenUp.OpenState.BossZoom:
        if (this.DeadBossAnimation["die"].enabled)
          break;
        this._openState = OpenUp.OpenState.BossDead;
        break;
      case OpenUp.OpenState.BossDead:
        if (!this.MoveRun(this.DeadBossTransform, Vector3.up, -10f, this.BigPointPos[(int) lineId - 1].y - this.BossDown, OpenUp.OpenState.PawnTurn))
          break;
        this.DeadBoss.gameObject.SetActive(false);
        Animation component1 = this.Pawn.GetComponent<Animation>();
        component1.wrapMode = WrapMode.Loop;
        component1.CrossFade("moving", 0.3f);
        break;
      case OpenUp.OpenState.SpriteUp:
        Vector3 forward2 = (this.BossTransform.position - this.PawnTransform.position) with
        {
          y = 0.0f
        };
        if (forward2 != Vector3.zero)
        {
          this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(forward2), (float) ((double) Time.deltaTime * 200.0 * 0.02500000037252903));
          this._BuildSprite.UpdateMapSprite((ushort) lineId, (byte) 0);
        }
        if (!this.MoveRun(this._BuildSprite.SpriteGameObject[(int) lineId - 1].transform, Vector3.up, 20f, this.BigPointPos[(int) lineId - 1].y + this.Spriteoffset, OpenUp.OpenState.ShowSpriteStar))
          break;
        this._BuildSprite.UpdateMapSprite((ushort) lineId, (byte) 1);
        break;
      case OpenUp.OpenState.LineUp:
        Vector3 forward3 = ((this.BigPointPos[(int) lineId] + this.PointPos[2 * (int) lineId + 1]) * 0.5f - this.PawnTransform.position) with
        {
          y = 0.0f
        };
        if (forward3 == Vector3.zero)
        {
          this._BuildSprite.SpriteGameObject[this._BuildSprite.SpriteGameObject.Length - 1].SetActive(true);
          Animation component2 = this.Pawn.GetComponent<Animation>();
          component2.wrapMode = WrapMode.Loop;
          component2.CrossFade("idle", 0.3f);
          this._openState = OpenUp.OpenState.SpriteUp;
          break;
        }
        this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(forward3), (float) ((double) Time.deltaTime * 200.0 * 0.05000000074505806));
        this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, (this.BigPointPos[(int) lineId] + this.PointPos[2 * (int) lineId + 1]) * 0.5f + Vector3.up * this.Pawnoffset, (float) ((double) Time.deltaTime * 200.0 * 0.05000000074505806));
        break;
      case OpenUp.OpenState.ShowSpriteStar:
        if (this._BuildSprite.UpdateRun(Time.deltaTime))
          break;
        this._openState = OpenUp.OpenState.Count;
        break;
      default:
        DataManager.StageDataController.isNotFirstInLine[(int) DataManager.StageDataController._stageMode] = (byte) 1;
        NewbieManager.CheckShowArrow(true, this.Halo);
        this._openState = OpenUp.OpenState.Count;
        this.stateUpdateDelegates = (OpenUp.StateUpdateDelegate) null;
        break;
    }
  }

  private void FinalWinRun()
  {
    byte index1 = 5;
    switch (this._openState)
    {
      case OpenUp.OpenState.PawnDown:
        this.MoveRun(this.PawnTransform, Vector3.up, 200f, this.BigPointPos[(int) index1].y + this.FallStart, OpenUp.OpenState.Count);
        break;
      case OpenUp.OpenState.BossZoom:
        if (this.DeadBossAnimation.isPlaying)
          break;
        this._openState = OpenUp.OpenState.BossDead;
        break;
      case OpenUp.OpenState.BossDead:
        if (!this.MoveRun(this.DeadBossTransform, Vector3.up, -10f, this.BigPointPos[(int) index1].y + this.Bossoffset - this.BossDown, OpenUp.OpenState.SpriteUp))
          break;
        this.DeadBoss.gameObject.SetActive(false);
        if (DataManager.StageDataController._stageMode == StageMode.Dare)
        {
          for (int index2 = 0; index2 <= (int) index1; ++index2)
          {
            this._BuildSprite.SpriteGameObject[index2].SetActive(true);
            this._BuildSprite.UpdateMapSprite((ushort) (index2 + 1), (byte) 0);
          }
          AudioManager.Instance.PlayMP3SFX((ushort) 41002, 1.5f);
        }
        else
        {
          this._BuildSprite.SpriteGameObject[(int) index1].SetActive(true);
          this._BuildSprite.UpdateMapSprite((ushort) ((uint) index1 + 1U), (byte) 0);
        }
        Animation component = this.Pawn.GetComponent<Animation>();
        component.wrapMode = WrapMode.Loop;
        component.CrossFade("idle", 0.3f);
        break;
      case OpenUp.OpenState.SpriteUp:
        if (DataManager.StageDataController._stageMode == StageMode.Dare)
        {
          for (int index3 = 0; index3 <= (int) index1; ++index3)
          {
            if (this.MoveRun(this._BuildSprite.SpriteGameObject[index3].transform, Vector3.up, 5f, this.BigPointPos[index3].y + this.Spriteoffset, OpenUp.OpenState.ShowSpriteStar))
              this._BuildSprite.UpdateMapSprite((ushort) (index3 + 1), (byte) 1);
          }
          break;
        }
        if (!this.MoveRun(this._BuildSprite.SpriteGameObject[(int) index1].transform, Vector3.up, 5f, this.BigPointPos[(int) index1].y + this.Spriteoffset, OpenUp.OpenState.ShowSpriteStar))
          break;
        this._BuildSprite.UpdateMapSprite((ushort) ((uint) index1 + 1U), (byte) 1);
        break;
      case OpenUp.OpenState.ShowSpriteStar:
        if (this._BuildSprite.UpdateRun(Time.deltaTime))
          break;
        this._openState = OpenUp.OpenState.PawnDown;
        if (DataManager.StageDataController._stageMode != StageMode.Full)
          break;
        GUIManager.Instance.m_HUDMessage.MapHud.SkipMsg();
        break;
      default:
        DataManager.msgBuffer[0] = (byte) 44;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        DataManager.msgBuffer[0] = (byte) 47;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        this._openState = OpenUp.OpenState.Count;
        this.stateUpdateDelegates = (OpenUp.StateUpdateDelegate) null;
        if (DataManager.StageDataController._stageMode == StageMode.Lean)
        {
          DataManager.StageDataController.isNotFirstInChapter[(int) DataManager.StageDataController._stageMode] = (byte) 0;
          DataManager.StageDataController.SaveisNotFirstInChapter();
          if ((int) DataManager.StageDataController.StageRecord[1] == 4 * (int) GameConstants.StagePointNum[1] && DataManager.StageDataController.limitRecord[3] > (ushort) 0)
            NewbieManager.CheckDareFull(true);
          else if ((int) DataManager.StageDataController.StageRecord[1] * 3 == (int) DataManager.StageDataController.StageRecord[0] || (int) DataManager.StageDataController.StageRecord[1] == (int) DataManager.StageDataController.limitRecord[1])
          {
            DataManager.msgBuffer[0] = (byte) 4;
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          }
          else
            GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.NextStage);
          DataManager.msgBuffer[0] = (byte) 43;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          break;
        }
        if (DataManager.StageDataController._stageMode == StageMode.Dare)
        {
          DataManager.StageDataController.isNotFirstInChapter[(int) DataManager.StageDataController._stageMode] = (byte) 0;
          DataManager.StageDataController.SaveisNotFirstInChapter();
          if ((int) DataManager.StageDataController.StageRecord[3] == (int) GameConstants.StagePointNum[3])
          {
            if (NewbieManager.CheckDareLead() && this._BuildSprite != null)
            {
              for (int index4 = 0; index4 < this._BuildSprite.SpriteGameObject.Length; ++index4)
                NewbieManager.HeroIconCache[index4] = index4 >= 6 ? (GameObject) null : this._BuildSprite.SpriteGameObject[index4];
            }
          }
          else if ((int) DataManager.StageDataController.StageRecord[3] == (int) DataManager.StageDataController.StageRecord[1] * 3 - 1 || (int) DataManager.StageDataController.StageRecord[3] == (int) DataManager.StageDataController.limitRecord[3])
          {
            DataManager.msgBuffer[0] = (byte) 4;
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          }
          else
            GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.NextStage);
          DataManager.msgBuffer[0] = (byte) 43;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          break;
        }
        DataManager.msgBuffer[0] = (byte) 38;
        DataManager.msgBuffer[1] = (byte) 1;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
    }
  }

  private void CorpsWinRun()
  {
    switch (this._openState)
    {
      case OpenUp.OpenState.BossDown:
        this.PointPos[1].x = Mathf.PerlinNoise(this.DeadBossTransform.position.y, this.DeadBossTransform.position.z) - 0.5f;
        this.PointPos[1].y = Mathf.PerlinNoise(this.DeadBossTransform.position.x, this.DeadBossTransform.position.z) - 0.5f;
        this.PointPos[1].z = Mathf.PerlinNoise(this.DeadBossTransform.position.x, this.DeadBossTransform.position.y) - 0.5f;
        this.DeadBossTransform.position = this.PointPos[0];
        bool flag = this.MoveRun(this.DeadBossTransform, Vector3.up, -10f, this.LinePos.y, OpenUp.OpenState.Count);
        this.PointPos[0] = this.DeadBossTransform.position;
        Transform pawnTransform = this.PawnTransform;
        Vector3 vector3_1 = this.PointPos[0] + this.PointPos[1] * 3f;
        this.DeadBossTransform.position = vector3_1;
        Vector3 vector3_2 = vector3_1;
        pawnTransform.position = vector3_2;
        if (!flag)
          break;
        this.OpenUpCorpsStage.SetActive(false);
        this.DeadBoss = (GameObject) null;
        this.DeadBossTransform = (Transform) null;
        this.PawnTransform = (Transform) null;
        break;
      case OpenUp.OpenState.BossZoom:
        if (this.DeadBossAnimation.isPlaying)
          break;
        this._openState = OpenUp.OpenState.BossDead;
        this.LinePos = this.DeadBossTransform.position;
        this.LinePos.y -= this.BossDown;
        break;
      case OpenUp.OpenState.BossDead:
        if (!this.MoveRun(this.DeadBossTransform, Vector3.up, -10f, this.LinePos.y, OpenUp.OpenState.BossDown))
          break;
        this.DeadBoss.gameObject.SetActive(false);
        this.DeadBoss = this.OpenUpCorpsStage.transform.GetChild(0).gameObject;
        this.DeadBossTransform = this.DeadBoss.transform;
        this.PointPos[0] = this.LinePos = this.DeadBossTransform.position;
        ParticleManager.Instance.Spawn((ushort) 310, (Transform) null, this.LinePos, 1f, true);
        this.LinePos.y -= this.BossDown * 4f;
        this.PawnTransform = this.OpenUpCorpsStage.transform.GetChild(2).transform;
        AudioManager.Instance.PlaySFX((ushort) 20010);
        break;
      default:
        DataManager.Instance.lastBattleResult = (short) -1;
        DataManager.msgBuffer[0] = (byte) 44;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        DataManager.msgBuffer[0] = (byte) 47;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        this._openState = OpenUp.OpenState.Count;
        this.stateUpdateDelegates = (OpenUp.StateUpdateDelegate) null;
        DataManager.msgBuffer[0] = (byte) 15;
        DataManager.msgBuffer[1] = (byte) 1;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
    }
  }

  private void DareNodusUpdateRun()
  {
    int index = 0;
    if (DataManager.StageDataController.DareNodusUpdatePointID <= (ushort) 0)
    {
      this._openState = OpenUp.OpenState.Count;
    }
    else
    {
      index = ((int) DataManager.StageDataController.DareNodusUpdatePointID - 1) % (int) GameConstants.StagePointNum[(int) DataManager.StageDataController._stageMode] / (int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode];
      if (index >= this._BuildSprite.SpriteGameObject.Length)
        this._openState = OpenUp.OpenState.Count;
    }
    switch (this._openState)
    {
      case OpenUp.OpenState.BigPointDown:
        if (!this.MoveRun(this._BuildSprite.SpriteGameObject[index].transform, Vector3.up, -20f, this.BigPointPos[index].y - this.UpStart, OpenUp.OpenState.SpriteUp))
          break;
        this._BuildSprite.UpdateSpriteFrame(index);
        DataManager.msgBuffer[0] = (byte) 44;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        DataManager.msgBuffer[0] = (byte) 47;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        DataManager.msgBuffer[0] = (byte) 43;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
      case OpenUp.OpenState.SpriteUp:
        if (!this.MoveRun(this._BuildSprite.SpriteGameObject[index].transform, Vector3.up, 20f, this.BigPointPos[index].y + this.Spriteoffset, OpenUp.OpenState.Count))
          break;
        this._BuildSprite.ShowChallegeEffect(this._BuildSprite.SpriteGameObject[index].transform);
        break;
      default:
        DataManager.StageDataController.DareNodusUpdatePointID = (ushort) 0;
        this._openState = OpenUp.OpenState.Count;
        this.stateUpdateDelegates = (OpenUp.StateUpdateDelegate) null;
        break;
    }
  }

  private void StartInOut(OpenUp.OpenState inoutstate)
  {
    switch (inoutstate)
    {
      case OpenUp.OpenState.In:
        this.InOutSpeed = 200f;
        break;
      case OpenUp.OpenState.Out:
        this.InOutSpeed = -200f;
        break;
      default:
        return;
    }
    this._openState = inoutstate;
    DataManager.msgBuffer[0] = (byte) 46;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    DataManager.msgBuffer[0] = (byte) 42;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.InOut);
    if ((UnityEngine.Object) this.InOutParent == (UnityEngine.Object) null)
      this.InOutParent = new GameObject("InOutParent");
    this.InOutParentTransform = this.InOutParent.transform;
    if ((double) this.InOutSpeed > 0.0)
      this.InOutParentTransform.position += Vector3.up * 10f;
    else
      this.InOutParentTransform.position = Vector3.zero;
    this.Line.transform.SetParent(this.InOutParentTransform);
    if (this._BuildSprite != null)
    {
      for (int index = 0; index < this._BuildSprite.SpriteGameObject.Length; ++index)
        this._BuildSprite.SpriteGameObject[index].transform.SetParent(this.InOutParentTransform);
    }
    if (this.Point != null)
    {
      for (int index = 0; index < this.Point.Length; ++index)
        this.PointTransform[index].SetParent(this.InOutParentTransform);
    }
    if ((UnityEngine.Object) this.Pawn != (UnityEngine.Object) null)
      this.PawnTransform.SetParent(this.InOutParentTransform);
    if ((UnityEngine.Object) this.Boss != (UnityEngine.Object) null)
      this.BossTransform.SetParent(this.InOutParentTransform);
    for (int index = 0; index < this.BigPoint.Length; ++index)
      this.BigPointTransform[index].SetParent(this.InOutParentTransform);
    if ((UnityEngine.Object) this.Treasure != (UnityEngine.Object) null)
      this.TreasureTransform.SetParent(this.InOutParentTransform);
    if ((double) this.InOutSpeed <= 0.0)
      return;
    this.InOutParentTransform.position = Vector3.zero;
  }

  private void InOut()
  {
    if (this._openState == OpenUp.OpenState.Count)
    {
      this.Line.transform.SetParent((Transform) null);
      if (this._BuildSprite != null)
      {
        for (int index = 0; index < this._BuildSprite.SpriteGameObject.Length; ++index)
          this._BuildSprite.SpriteGameObject[index].transform.SetParent((Transform) null);
      }
      if (this.Point != null)
      {
        for (int index = 0; index < this.Point.Length; ++index)
          this.PointTransform[index].SetParent((Transform) null);
      }
      if ((UnityEngine.Object) this.Pawn != (UnityEngine.Object) null)
        this.PawnTransform.SetParent((Transform) null);
      if ((UnityEngine.Object) this.Boss != (UnityEngine.Object) null)
        this.BossTransform.SetParent((Transform) null);
      for (int index = 0; index < this.BigPoint.Length; ++index)
        this.BigPointTransform[index].SetParent((Transform) null);
      this.stateUpdateDelegates = (OpenUp.StateUpdateDelegate) null;
      if ((double) this.InOutSpeed < 0.0)
      {
        if (this.bupdateChapter)
        {
          DataManager.msgBuffer[0] = (byte) 34;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
        else
        {
          DataManager.msgBuffer[0] = (byte) 21;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
      }
      this.InOutParentTransform = (Transform) null;
      DataManager.msgBuffer[0] = (byte) 47;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      DataManager.msgBuffer[0] = (byte) 43;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
    else
      this.MoveRun(this.InOutParentTransform, Vector3.up, this.InOutSpeed, this.InOutSpeed * 0.05f, OpenUp.OpenState.Count);
  }

  protected override void UpdateNext(byte[] meg)
  {
    AssetManager.UnloadAssetBundle(this.LineassetKey);
    UnityEngine.Object.Destroy((UnityEngine.Object) this.Line);
    AssetManager.UnloadAssetBundle(this.PointassetKey);
    if (this.Point != null)
    {
      for (int index = 0; index < this.Point.Length; ++index)
      {
        this.PointTransform[index] = (Transform) null;
        UnityEngine.Object.Destroy((UnityEngine.Object) this.Point[index]);
        this.Point[index] = (GameObject) null;
      }
    }
    AssetManager.UnloadAssetBundle(this.BigPointassetKey);
    if (this.BigPoint != null)
    {
      for (int index = 0; index < this.BigPoint.Length; ++index)
      {
        this.BigPointTransform[index] = (Transform) null;
        UnityEngine.Object.Destroy((UnityEngine.Object) this.BigPoint[index]);
        this.BigPoint[index] = (GameObject) null;
      }
    }
    AssetManager.UnloadAssetBundle(this.BossassetKey);
    this.BossTransform = (Transform) null;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.Boss);
    AssetManager.UnloadAssetBundle(this.DeadBossassetKey);
    this.DeadBossTransform = (Transform) null;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.DeadBoss);
    AssetManager.UnloadAssetBundle(this.PawnassetKey);
    this.PawnTransform = (Transform) null;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.Pawn);
    AssetManager.UnloadAssetBundle(this.TreasureassetKey);
    this.TreasureTransform = (Transform) null;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.Treasure);
    if (this._BuildSprite != null)
      this._BuildSprite.Destroy();
    if (this.CanBeSelect != null)
      Array.Clear((Array) this.CanBeSelect, 0, this.CanBeSelect.Length);
    if (this.Select != null)
      Array.Clear((Array) this.Select, 0, this.Select.Length);
    if ((UnityEngine.Object) this.Halo != (UnityEngine.Object) null)
      ParticleManager.Instance.DeSpawn(this.Halo);
    this.InOutParentTransform = (Transform) null;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.InOutParent);
    this.Line = (GameObject) null;
    this.Point = (GameObject[]) null;
    this.BigPoint = (GameObject[]) null;
    this.Boss = (GameObject) null;
    this.DeadBoss = (GameObject) null;
    this.Pawn = (GameObject) null;
    this._BuildSprite = (MapSprite) null;
    this.CanBeSelect = (GameObject[]) null;
    this.Select = (GameObject[]) null;
    this.InOutParent = (GameObject) null;
    this.DeadBossAnimation = (Animation) null;
    this.BossAnimation = (Animation) null;
    this.Halo = (GameObject) null;
    this.stateUpdateDelegates = (OpenUp.StateUpdateDelegate) null;
    NewbieManager.CheckShowArrow(false);
    this.ClearUpdateDelegates();
  }

  protected override void UpdateLoad(byte[] meg)
  {
    this.bupdateChapter = false;
    this.Select = new GameObject[1];
    if (DataManager.StageDataController._stageMode == StageMode.Corps)
    {
      this._openState = OpenUp.OpenState.Count;
      this.stateUpdateDelegates = (OpenUp.StateUpdateDelegate) null;
      if (DataManager.StageDataController.isNotFirstInChapter[2] == (byte) 0)
      {
        this._openState = OpenUp.OpenState.Wait;
        DataManager.msgBuffer[0] = (byte) 47;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        DataManager.msgBuffer[0] = (byte) 15;
        DataManager.msgBuffer[1] = (byte) 0;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      }
      else if (DataManager.Instance.lastBattleResult > (short) 0)
      {
        DataManager.msgBuffer[0] = (byte) 46;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        DataManager.msgBuffer[0] = (byte) 42;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        this._openState = OpenUp.OpenState.CorpsWin;
        DataManager.msgBuffer[0] = (byte) 45;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      }
      else
        this._openState = OpenUp.OpenState.Corps;
    }
    else
    {
      if ((UnityEngine.Object) this.OpenUpCorpsStage != (UnityEngine.Object) null)
        this.OpenUpCorpsStage.SetActive(false);
      if (this.setOpenState())
        return;
      this.Halo = ParticleManager.Instance.Spawn((ushort) 51, (Transform) null, Vector3.zero, 1f, false, false);
      Chapter recordByKey = DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort) DataManager.StageDataController.currentChapterID);
      for (int index = 0; index < this.PointPos.Length; ++index)
        this.PointPos[index] = GameConstants.WordToVector3(recordByKey.PointPos[index].X, recordByKey.PointPos[index].Y, recordByKey.PointPos[index].Z);
      for (int index = 0; index < this.BigPointPos.Length; ++index)
        this.BigPointPos[index] = GameConstants.WordToVector3(recordByKey.BigPointPos[index].X, recordByKey.BigPointPos[index].Y, recordByKey.BigPointPos[index].Z);
      switch (this._openState)
      {
        case OpenUp.OpenState.FullWin:
          this.FullWinLoad();
          break;
        case OpenUp.OpenState.LeanWin:
          this.LeanWinLoad();
          break;
        case OpenUp.OpenState.FinalWin:
          this.FinalWinLoad();
          break;
        default:
          this.defaultLoad();
          break;
      }
    }
  }

  protected override void UpdateReady(byte[] meg)
  {
    if (this._openState == OpenUp.OpenState.Wait)
      return;
    switch (this._openState)
    {
      case OpenUp.OpenState.First:
        this.FirstReady();
        break;
      case OpenUp.OpenState.FullWin:
        this.FullWinReady();
        break;
      case OpenUp.OpenState.LeanWin:
        this.LeanWinReady();
        break;
      case OpenUp.OpenState.FinalWin:
        this.FinalWinReady();
        break;
      case OpenUp.OpenState.Corps:
      case OpenUp.OpenState.CorpsWin:
        this.CorpsReady();
        break;
      default:
        this.defaultReady();
        GUIManager.Instance.m_HUDMessage.MapHud.AddChapterMsg();
        break;
    }
  }

  protected override void UpdateRun(byte[] meg)
  {
    if (this.stateUpdateDelegates != null)
      this.stateUpdateDelegates();
    if (!((UnityEngine.Object) this.BossAnimation != (UnityEngine.Object) null))
      return;
    this.BossAnimationTime -= Time.deltaTime;
    if ((double) this.BossAnimationTime >= 0.0)
      return;
    if ((int) ((double) UnityEngine.Random.value * 10.0) % 4 == 0)
    {
      this.BossAnimationTime = this.BossAnimation["victory"].length;
      this.BossAnimation.CrossFade("victory", 0.3f);
    }
    else
    {
      this.BossAnimationTime = this.BossAnimation["idle"].length;
      this.BossAnimation.CrossFade("idle", 0.3f);
    }
  }

  protected override void UpdateNews(byte[] meg)
  {
    switch (meg[0])
    {
      case 0:
        Vector2 touch = new Vector2(GameConstants.ConvertBytesToFloat(meg, 1), GameConstants.ConvertBytesToFloat(meg, 5));
        this.Select[0] = (GameObject) null;
        if (this.CanBeSelect == null)
          break;
        this.Select[0] = GameConstants.GameObjectPick(touch, this.CanBeSelect, typeof (Renderer));
        break;
      case 1:
        if ((UnityEngine.Object) this.Select[0] != (UnityEngine.Object) null)
        {
          this.Select[0] = GameConstants.GameObjectPick(new Vector2(GameConstants.ConvertBytesToFloat(meg, 1), GameConstants.ConvertBytesToFloat(meg, 5)), this.Select, typeof (Renderer));
          if ((UnityEngine.Object) this.Select[0] != (UnityEngine.Object) null)
          {
            if (DataManager.StageDataController._stageMode == StageMode.Corps)
            {
              DataManager.msgBuffer[0] = (byte) 18;
              GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
              this.Select[0] = (GameObject) null;
              break;
            }
            AudioManager.Instance.PlayUISFX();
            if ((UnityEngine.Object) this.Select[0] == (UnityEngine.Object) this.Treasure)
            {
              this.Select[0] = (GameObject) null;
              DataManager.msgBuffer[0] = (byte) 38;
              DataManager.msgBuffer[1] = (byte) 0;
              GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
              break;
            }
            if ((UnityEngine.Object) this.Select[0].transform.GetChild(0).GetComponent<SpriteRenderer>() != (UnityEngine.Object) null)
            {
              for (ushort index = 0; (int) index < this._BuildSprite.SpriteGameObject.Length; ++index)
              {
                if ((UnityEngine.Object) this.Select[0] == (UnityEngine.Object) this._BuildSprite.SpriteGameObject[(int) index])
                {
                  DataManager.StageDataController.currentPointID = (ushort) ((uint) (((int) DataManager.StageDataController.currentChapterID - 1) * 6 + (int) index + 1) * (uint) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode]);
                  DataManager.StageDataController.SaveUserStage(DataManager.StageDataController._stageMode);
                  break;
                }
              }
            }
            else
            {
              if (DataManager.StageDataController._stageMode == StageMode.Lean && ((int) DataManager.StageDataController.StageRecord[1] + 1) * 3 > (int) DataManager.StageDataController.StageRecord[0])
              {
                GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1593U), (ushort) byte.MaxValue);
                this.Select[0] = (GameObject) null;
                break;
              }
              DataManager.StageDataController.resetCurrentPointIDwithStageRecord();
            }
            DataManager.msgBuffer[0] = (byte) 17;
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          }
        }
        this.Select[0] = (GameObject) null;
        break;
      case 2:
        if (DataManager.StageDataController._stageMode == StageMode.Corps)
        {
          DataManager.msgBuffer[0] = (byte) 21;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          break;
        }
        this.StartInOut(OpenUp.OpenState.Out);
        break;
      case 3:
        this.StartInOut(OpenUp.OpenState.In);
        break;
      case 4:
        switch (this._openState)
        {
          case OpenUp.OpenState.First:
            this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.FirstRun);
            byte lineId = this.LineID;
            this.Line.transform.position = this.LinePos;
            this.Line.GetComponent<Animation>().Play(lineId.ToString());
            if (this.Point != null)
            {
              this._openState = OpenUp.OpenState.FirstPointDown;
              this.Point[1].SetActive(true);
              return;
            }
            if ((UnityEngine.Object) this.Pawn != (UnityEngine.Object) null)
              this.BigPoint[(int) lineId].SetActive(true);
            this._openState = OpenUp.OpenState.BigPointDown;
            return;
          case OpenUp.OpenState.FullWin:
            this._openState = OpenUp.OpenState.FirstPointDown;
            this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.FullWinRun);
            return;
          case OpenUp.OpenState.LeanWin:
            this._openState = OpenUp.OpenState.BossZoom;
            this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.LeanWinRun);
            if (!((UnityEngine.Object) this.DeadBoss != (UnityEngine.Object) null))
              return;
            this.DeadBossAnimation.wrapMode = WrapMode.Once;
            this.DeadBossAnimation.Play("die");
            return;
          case OpenUp.OpenState.FinalWin:
            this._openState = OpenUp.OpenState.BossZoom;
            this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.FinalWinRun);
            if (!((UnityEngine.Object) this.DeadBoss != (UnityEngine.Object) null))
              return;
            this.DeadBossAnimation.wrapMode = WrapMode.Once;
            this.DeadBossAnimation.Play("die");
            return;
          case OpenUp.OpenState.CorpsWin:
            this._openState = OpenUp.OpenState.BossZoom;
            this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.CorpsWinRun);
            if (!((UnityEngine.Object) this.OpenUpCorpsStage != (UnityEngine.Object) null))
              return;
            this.DeadBossAnimation.wrapMode = WrapMode.Once;
            this.DeadBossAnimation.Play("die");
            AudioManager.Instance.PlaySFX(DataManager.Instance.HeroTable.GetRecordByKey(DataManager.StageDataController.CorpsStageTable.GetRecordByKey(DataManager.StageDataController.StageRecord[2]).Heros[0].HeroID).DyingSound, pitchkind: PitchKind.SpeechSound);
            Vector3 viewportPoint = Camera.main.WorldToViewportPoint(this.OpenUpCorpsStage.transform.position);
            int index1 = 0;
            GUIManager instance = GUIManager.Instance;
            Array.Clear((Array) instance.SE_Kind, 0, instance.SE_Kind.Length);
            instance.SE_Kind[index1] = SpeciallyEffect_Kind.LeadExp;
            int index2 = index1 + 1;
            instance.SE_Kind[index2] = SpeciallyEffect_Kind.HeroExp;
            int num = index2 + 1;
            Array.Clear((Array) instance.SE_ItemID, 0, instance.SE_ItemID.Length);
            instance.mStartV2 = new Vector2(((Component) instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x * viewportPoint.x, ((Component) instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.y * viewportPoint.y);
            instance.m_SpeciallyEffect.AddIconShow(instance.mStartV2, instance.SE_Kind, instance.SE_ItemID);
            return;
          default:
            if (DataManager.StageDataController.DareNodusUpdatePointID > (ushort) 0)
            {
              if (DataManager.StageDataController._stageMode == StageMode.Dare && (int) DataManager.StageDataController.DareNodusUpdatePointID == (int) DataManager.StageDataController.currentPointID && this._BuildSprite != null)
              {
                this._openState = OpenUp.OpenState.BigPointDown;
                this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.DareNodusUpdateRun);
              }
              else
                DataManager.StageDataController.DareNodusUpdatePointID = (ushort) 0;
            }
            NewbieManager.CheckShowArrow(true, this.Halo);
            return;
        }
      case 6:
        this.bupdateChapter = true;
        this.StartInOut(OpenUp.OpenState.Out);
        break;
      case 8:
        if (this._BuildSprite == null)
          break;
        this._BuildSprite.Hide();
        break;
      case 13:
        DataManager.msgBuffer[0] = (byte) 45;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.FirstRun);
        break;
    }
  }

  private enum OpenState : byte
  {
    First,
    FullWin,
    LeanWin,
    FinalWin,
    Corps,
    CorpsWin,
    Wait,
    BigPointDown,
    FirstPointDown,
    SecPointDown,
    BossDown,
    PawnDown,
    PawnTurn,
    PawnMove,
    BossZoom,
    BossDead,
    SpriteUp,
    LineUp,
    ShowSpriteStar,
    In,
    Out,
    Count,
  }

  private delegate void StateUpdateDelegate();
}
