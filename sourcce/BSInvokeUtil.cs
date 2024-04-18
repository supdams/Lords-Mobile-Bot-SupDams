// Decompiled with JetBrains decompiler
// Type: BSInvokeUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
public class BSInvokeUtil : IDisposable
{
  private IntPtr m_pBSObject = IntPtr.Zero;
  private IntPtr m_pCSObject = IntPtr.Zero;
  private static BSInvokeUtil Self;
  private byte[] WonderCheck;

  private BSInvokeUtil()
  {
    BSInvokeUtil.DllCreateTableInstance();
    CExternalTableWithWordKey<Hero> heroTable = DataManager.Instance.HeroTable;
    BSInvokeUtil.DllSetHerosExtTable(heroTable.MapPtr, heroTable.MapCount, heroTable.TablePtr, heroTable.TableCount);
    CExternalTableWithWordKey<Skill> skillTable = DataManager.Instance.SkillTable;
    BSInvokeUtil.DllSetSkillsExtTable(skillTable.MapPtr, skillTable.MapCount, skillTable.TablePtr, skillTable.TableCount);
    CExternalTableWithWordKey<AI> aiTable = DataManager.Instance.AITable;
    BSInvokeUtil.DllSetAIExtTable(aiTable.MapPtr, aiTable.MapCount, aiTable.TablePtr, aiTable.TableCount);
    CExternalTableWithWordKey<Buff> buffTable = DataManager.Instance.BuffTable;
    BSInvokeUtil.DllSetBuffExtTable(buffTable.MapPtr, buffTable.MapCount, buffTable.TablePtr, buffTable.TableCount);
    CExternalTableWithWordKey<Enhance> enhanceTable = DataManager.Instance.EnhanceTable;
    BSInvokeUtil.DllSetEnhanceExtTable(enhanceTable.MapPtr, enhanceTable.MapCount, enhanceTable.TablePtr, enhanceTable.TableCount);
    CExternalTableWithWordKey<Equip> equipTable = DataManager.Instance.EquipTable;
    BSInvokeUtil.DllSetEquipExtTable(equipTable.MapPtr, equipTable.MapCount, equipTable.TablePtr, equipTable.TableCount);
    CExternalTableWithWordKey<Level> tableWithWordKey1 = DataManager.StageDataController.LevelTable[1];
    BSInvokeUtil.DllSetNormalStageExtTable(tableWithWordKey1.MapPtr, tableWithWordKey1.MapCount, tableWithWordKey1.TablePtr, tableWithWordKey1.TableCount);
    CExternalTableWithWordKey<HeroTeam> teamTable = DataManager.Instance.TeamTable;
    BSInvokeUtil.DllSetEnemyExtTable(teamTable.MapPtr, teamTable.MapCount, teamTable.TablePtr, teamTable.TableCount);
    CExternalTableWithWordKey<HeroArray> arrayTable = DataManager.Instance.ArrayTable;
    BSInvokeUtil.DllSetArrayExtTable(arrayTable.MapPtr, arrayTable.MapCount, arrayTable.TablePtr, arrayTable.TableCount);
    CExternalTableWithWordKey<Level> tableWithWordKey2 = DataManager.StageDataController.LevelTable[0];
    BSInvokeUtil.DllSetNormalMiniStageExtTable(tableWithWordKey2.MapPtr, tableWithWordKey2.MapCount, tableWithWordKey2.TablePtr, tableWithWordKey2.TableCount);
    CExternalTableWithWordKey<Level> tableWithWordKey3 = DataManager.StageDataController.LevelTable[2];
    BSInvokeUtil.DllSetAdvanceStageExtTable(tableWithWordKey3.MapPtr, tableWithWordKey3.MapCount, tableWithWordKey3.TablePtr, tableWithWordKey3.TableCount);
    CExternalTableWithWordKey<SoldierData> soldierDataTable = DataManager.Instance.SoldierDataTable;
    BSInvokeUtil.DllSetSoldierExtTable(soldierDataTable.MapPtr, soldierDataTable.MapCount, soldierDataTable.TablePtr, soldierDataTable.TableCount);
    CExternalTableWithWordKey<Combo> comboTable = DataManager.Instance.ComboTable;
    BSInvokeUtil.DllSetComboExtTable(comboTable.MapPtr, comboTable.MapCount, comboTable.TablePtr, comboTable.TableCount);
    CExternalTableWithWordKey<BuildLevelRequest> buildsRequest = DataManager.Instance.BuildsRequest;
    BSInvokeUtil.DllSetBuildUpExtTable(buildsRequest.MapPtr, buildsRequest.MapCount, buildsRequest.TablePtr, buildsRequest.TableCount);
    CExternalTableWithWordKey<TechLevelTbl> techLevel = DataManager.Instance.TechLevel;
    BSInvokeUtil.DllSetTechLvExtTable(techLevel.MapPtr, techLevel.MapCount, techLevel.TablePtr, techLevel.TableCount);
    CExternalTableWithWordKey<CorpsStage> corpsStageTable = DataManager.StageDataController.CorpsStageTable;
    BSInvokeUtil.DllSetCombatStageInterfaceExtTable(corpsStageTable.MapPtr, corpsStageTable.MapCount, corpsStageTable.TablePtr, corpsStageTable.TableCount);
    CExternalTableWithWordKey<CorpsStageBattle> stageBattleTable = DataManager.StageDataController.CorpsStageBattleTable;
    BSInvokeUtil.DllSetCombatStageFightExtTable(stageBattleTable.MapPtr, stageBattleTable.MapCount, stageBattleTable.TablePtr, stageBattleTable.TableCount);
    CExternalTableWithWordKey<TalentLevelTbl> talentLevel = DataManager.Instance.TalentLevel;
    BSInvokeUtil.DllSetTalentLevelExtTable(talentLevel.MapPtr, talentLevel.MapCount, talentLevel.TablePtr, talentLevel.TableCount);
    CExternalTableWithWordKey<VIP_DataTbl> vipLevelTable = DataManager.Instance.VIPLevelTable;
    BSInvokeUtil.DllSetVIPExtTable(vipLevelTable.MapPtr, vipLevelTable.MapCount, vipLevelTable.TablePtr, vipLevelTable.TableCount);
    CExternalTableWithWordKey<LordEquipEffectData> equipEffectTable = DataManager.Instance.LordEquipEffectTable;
    BSInvokeUtil.DllSetLordEquipEffectExtTable(equipEffectTable.MapPtr, equipEffectTable.MapCount, equipEffectTable.TablePtr, equipEffectTable.TableCount);
    CExternalTableWithWordKey<ArenaHeroTopic> arenaHeroTopicData = DataManager.Instance.ArenaHeroTopicData;
    BSInvokeUtil.DllSetArenaHeroTopicExtTable(arenaHeroTopicData.MapPtr, arenaHeroTopicData.MapCount, arenaHeroTopicData.TablePtr, (ushort) arenaHeroTopicData.TableCount);
    CExternalTableWithWordKey<WondersInfoTbl> wondersInfoTable = DataManager.MapDataController.MapWondersInfoTable;
    BSInvokeUtil.DllSetWondersInformationExtTable(wondersInfoTable.MapPtr, wondersInfoTable.MapCount, wondersInfoTable.TablePtr, (int) (ushort) wondersInfoTable.TableCount);
    CExternalTableWithWordKey<TitleData> titleData = DataManager.Instance.TitleData;
    BSInvokeUtil.DllSetWondersTitleExtTable(titleData.MapPtr, titleData.MapCount, titleData.TablePtr, (int) (ushort) titleData.TableCount);
    CExternalTableWithWordKey<TitleData> titleDataW = DataManager.Instance.TitleDataW;
    BSInvokeUtil.DllSetEmperorTitleExtTable(titleDataW.MapPtr, titleDataW.MapCount, titleDataW.TablePtr, (int) (ushort) titleDataW.TableCount);
    CExternalTableWithWordKey<TitleData> titleDataN = DataManager.Instance.TitleDataN;
    BSInvokeUtil.DllSetEmperorKingdomTitleExtTable(titleDataN.MapPtr, titleDataN.MapCount, titleDataN.TablePtr, (int) (ushort) titleDataN.TableCount);
    CExternalTableWithWordKey<TitleData> titleDataF = DataManager.Instance.TitleDataF;
    BSInvokeUtil.DllSetFederalTitleExtTable(titleDataF.MapPtr, titleDataF.MapCount, titleDataF.TablePtr, (int) (ushort) titleDataF.TableCount);
    CExternalTableWithWordKey<CoordData> coordTable = DataManager.Instance.CoordTable;
    BSInvokeUtil.DllSetCoordinateTable(coordTable.MapPtr, coordTable.MapCount, coordTable.TablePtr, (int) (ushort) coordTable.TableCount);
    CExternalTableWithWordKey<StageConditionData> conditionDataTable = DataManager.StageDataController.StageConditionDataTable;
    BSInvokeUtil.DllSetHeroChallengeQuestTable(conditionDataTable.MapPtr, conditionDataTable.MapCount, conditionDataTable.TablePtr, (ushort) conditionDataTable.TableCount);
    CExternalTableWithWordKey<CastleSkinTbl> castleSkinTable = GUIManager.Instance.BuildingData.castleSkin.CastleSkinTable;
    BSInvokeUtil.DllSetCastleSkinTable(castleSkinTable.MapPtr, (uint) castleSkinTable.MapCount, castleSkinTable.TablePtr, (ushort) castleSkinTable.TableCount);
    CExternalTableWithWordKey<CastleEnhanceTbl> castleEnhanceTable = GUIManager.Instance.BuildingData.castleSkin.CastleEnhanceTable;
    BSInvokeUtil.DllSetCastleSkinEnhanceTable(castleEnhanceTable.MapPtr, castleEnhanceTable.MapCount, castleEnhanceTable.TablePtr, (ushort) castleEnhanceTable.TableCount);
    CExternalTableWithWordKey<PetTbl> petTable = PetManager.Instance.PetTable;
    BSInvokeUtil.DllSetPetTable(petTable.MapPtr, petTable.MapCount, petTable.TablePtr, (ushort) petTable.TableCount);
    CExternalTableWithWordKey<PetSkillTbl> petSkillTable = PetManager.Instance.PetSkillTable;
    BSInvokeUtil.DllSetPetSkillTable(petSkillTable.MapPtr, petSkillTable.MapCount, petSkillTable.TablePtr, (ushort) petSkillTable.TableCount);
    CExternalTableWithWordKey<PetSkillValTbl> petSkillValTable = PetManager.Instance.PetSkillValTable;
    BSInvokeUtil.DllSetCPetSkillValueTable(petSkillValTable.MapPtr, petSkillValTable.MapCount, petSkillValTable.TablePtr, (ushort) petSkillValTable.TableCount);
    this.m_pBSObject = BSInvokeUtil.DllCreateBSInstance();
    this.m_pCSObject = BSInvokeUtil.DllCreateCSInstance();
  }

  [DllImport("BattleSimDll")]
  private static extern int DllCanUnload();

  [DllImport("BattleSimDll")]
  private static extern uint DllGetVersionNum();

  [DllImport("BattleSimDll")]
  private static extern IntPtr DllCreateBSInstance();

  [DllImport("BattleSimDll")]
  private static extern void DllDisposeBSInstance(IntPtr BSObject);

  [DllImport("BattleSimDll")]
  private static extern bool DllBSInit(
    IntPtr BSObject,
    ushort RandomSeed,
    ushort RandomGap,
    byte BattleType,
    byte StageKind,
    ushort StageID,
    byte primarySide);

  [DllImport("BattleSimDll")]
  private static extern bool DllBSSetHero(
    IntPtr BSObject,
    ushort Side,
    ushort id,
    CalcAttrDataType attrdata);

  [DllImport("BattleSimDll")]
  private static extern void DLLBSSetHeroOver(
    IntPtr BSObject,
    byte[] pHeroDataLeft,
    byte[] pHeroDataRight);

  [DllImport("BattleSimDll")]
  private static extern byte DllBSNextStage(
    IntPtr pBSObject,
    byte[] pHeroDataLeft,
    byte[] pHeroDataRight);

  [DllImport("BattleSimDll")]
  private static extern void DllSetHerosExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetSkillsExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetAIExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetBuffExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetEnhanceExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetEquipExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetNormalStageExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetNormalMiniStageExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetAdvanceStageExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetEnemyExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetArrayExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetSoldierExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetComboExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern uint DllUpdateFightScore(
    IntPtr pBSObject,
    ushort HeroID,
    uint HP,
    ushort[] pAttr,
    byte[] SkillLV);

  [DllImport("BattleSimDll")]
  private static extern void DllCalculateAttribute(
    IntPtr pBSObject,
    ushort HeroID,
    CalcAttrDataType CalcAttrData,
    ref uint HP,
    ushort[] pAttr);

  [DllImport("BattleSimDll")]
  private static extern void DLLCalculateHeroEquipEffect(
    IntPtr pBSObject,
    ushort HeroID,
    byte Enhance,
    byte Equip,
    ref uint HP,
    ushort[] pAttr);

  [DllImport("BattleSimDll")]
  private static extern byte DLLBSSetPVEMonsterHP(IntPtr BSObject, uint maxHp, uint nowHp);

  [DllImport("BattleSimDll")]
  private static extern uint DLLBSGetPVEMonsterHP(IntPtr BSObject);

  [DllImport("BattleSimDll")]
  private static extern bool DLLBSSetPVEMonsterAttr(IntPtr BSObject, MonsterAttrDataType AttrData);

  [DllImport("BattleSimDll")]
  private static extern IntPtr DllCreateCSInstance();

  [DllImport("BattleSimDll")]
  private static extern bool DllCSInit(IntPtr CSObject, ushort RandomSeed, ushort RandomGap);

  [DllImport("BattleSimDll")]
  private static extern bool DllCSSetCombatInfo(
    IntPtr CSObject,
    byte LeftLv,
    TroopLeaderType[] pleftLeaderData,
    byte leftLeaderNum,
    uint[,] pleftTroopForce,
    byte RightLv,
    TroopLeaderType[] prightLeaderData,
    byte rightLeaderNum,
    uint[,] prightTroopForce);

  [DllImport("BattleSimDll")]
  private static extern int DLLCSSetTroopOver(
    IntPtr CSObject,
    byte[] pHeroDataLeft,
    byte[] pHeroDataRight);

  [DllImport("BattleSimDll")]
  private static extern byte DllCSUpdateClient(
    IntPtr CSObject,
    uint Tick,
    byte[] pCommandsBuffLeft,
    byte[] pCommandsBuffRight);

  [DllImport("BattleSimDll")]
  private static extern void DllDisposeCSInstance(IntPtr CSObject);

  [DllImport("BattleSimDll")]
  private static extern bool DllCSSetWallTrapInfo(
    IntPtr BSObject,
    uint WallDefence,
    uint WallDefenceMax,
    uint[,] pTrapForce);

  [DllImport("BattleSimDll")]
  private static extern void DllCreateTableInstance();

  [DllImport("BattleSimDll")]
  private static extern void DllDisposeTableInstance();

  [DllImport("BattleSimDll")]
  private static extern uint DllBSCheckUltraCondition(IntPtr BSObject);

  [DllImport("BattleSimDll")]
  private static extern uint DllBSCheckRightUltraCondition(IntPtr BSObject);

  [DllImport("BattleSimDll")]
  private static extern bool DllBSInitUltra(
    IntPtr BSObject,
    byte HeroIndex,
    ref byte ClosestHeroIndex,
    ref float PosX,
    ref float PosY);

  [DllImport("BattleSimDll")]
  private static extern void DllBSCheckUltraHitTarget(
    IntPtr BSObject,
    byte Param1,
    byte Param2,
    ref uint HitNum);

  [DllImport("BattleSimDll")]
  private static extern void DllBSUltraInput(IntPtr BSObject, byte Param1, byte Param2);

  [DllImport("BattleSimDll")]
  private static extern byte DllBSUpdateClient(
    IntPtr BSObject,
    uint Tick,
    byte[] pCommandsBuffLeft,
    byte[] pCommandsBuffRight,
    byte[] pEventBuffer);

  [DllImport("BattleSimDll")]
  private static extern unsafe void DllCSCalculateBuildingBonus(
    IntPtr pCSObject,
    RoleBuildingData* pCalcBuildingData,
    byte bAlterOpen,
    uint[] pResultAttr);

  [DllImport("BattleSimDll")]
  private static extern void DllCSCalculateResearchBonus(
    IntPtr pCSObject,
    byte[] pCalcResearchData,
    uint[] pResultAttr);

  [DllImport("BattleSimDll")]
  private static extern void DllSetBuildUpExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetTechLvExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllCSCalculateHeroSkillBonus(
    IntPtr pCSObject,
    byte HeroNum,
    CalcHeroDataType[] pCalcHeroData,
    byte LordStatus,
    ushort LordID,
    uint[] pResultAttr);

  [DllImport("BattleSimDll")]
  private static extern int DllCSSetTroopAttrData(
    IntPtr CSObject,
    uint[] pLeftAtk,
    uint[] pLeftDef,
    uint[] pLeftHp,
    uint[] pRightAtk,
    uint[] pRightDef,
    uint[] pRightHp);

  [DllImport("BattleSimDll")]
  private static extern int DllCSSetTrapAttrData(
    IntPtr CSObject,
    CombatCastleDefAttrDataType TrapAttr);

  [DllImport("BattleSimDll")]
  private static extern void DllCSGetCombatStageAttr(
    IntPtr pCSObject,
    byte CombatStageID,
    ushort Head,
    byte HeroNum,
    TroopLeaderType[] pHeroData,
    uint[] pCalcCombatAttr,
    uint[] pCalcCombatLoadAttr,
    uint[] pResultLeftAtk,
    uint[] pResultLeftDef,
    uint[] pResultLeftHp,
    uint[] pResultRightAtk,
    uint[] pResultRightDef,
    uint[] pResultRightHp,
    ref CombatCastleDefAttrDataType pResultTrapAttr,
    bool bInDeShieldBuff);

  [DllImport("BattleSimDll")]
  private static extern void DllSetTalentLevelExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetCombatStageFightExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetCombatStageInterfaceExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllCSCalculateTalentBonus(
    IntPtr pCSObject,
    byte[] pCalcTalentData,
    uint[] pResultAttr);

  [DllImport("BattleSimDll")]
  private static extern uint DLLBSGetEventDataLen(IntPtr BSObject);

  [DllImport("BattleSimDll")]
  private static extern void DllCSCalculateBuffBonus(
    IntPtr pCSObject,
    byte BuffNum,
    ushort[] BuffItemID,
    byte PetBuffNum,
    _CalcPetBuffDataType[] PetBuffData,
    uint[] pResultAttr);

  [DllImport("BattleSimDll")]
  private static extern void DllCSCalculateVIPBonus(
    IntPtr pCSObject,
    byte VIPLevel,
    uint[] pResultAttr);

  [DllImport("BattleSimDll")]
  private static extern void DllSetVIPExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetLordEquipEffectExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllCSCalculateOnLordEquipBonus(
    IntPtr pCSObject,
    LordEquipSerialData[] pCalcOnLordEquipData,
    uint[] pResultAttr);

  [DllImport("BattleSimDll")]
  private static extern void DLLBSSetUserData(IntPtr BSObject, long UserId, ulong BattleCode);

  [DllImport("BattleSimDll")]
  private static extern void DllSetArenaHeroTopicExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    ushort RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DLLBSSetArenaTopic(
    IntPtr BSObject,
    byte TopicID1,
    byte TopicID2,
    ArenaTopicEffectDataType Effect1,
    ArenaTopicEffectDataType Effect2);

  [DllImport("BattleSimDll")]
  private static extern void DllSetWondersInformationExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllCSCalculateWonderBonus(
    IntPtr pCSObject,
    byte WonderID,
    uint[] pResultAttr);

  [DllImport("BattleSimDll")]
  private static extern void DllSetWondersTitleExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllCSCalculateWonderTitleBonus(
    IntPtr pCSObject,
    byte Title,
    uint[] pResultAttr);

  [DllImport("BattleSimDll")]
  private static extern void DllSetCoordinateTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DLLSetCoordData(ushort LeftCoord, ushort RightCoord);

  [DllImport("BattleSimDll")]
  private static extern void DllSetEmperorTitleExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetEmperorKingdomTitleExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetFederalTitleExtTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    int RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllCSCalculateWorldTitleBonus(
    IntPtr pCSObject,
    byte Title,
    byte NationTitle,
    uint[] pResultAttr);

  [DllImport("BattleSimDll")]
  private static extern void DllCSCalculateFederalTitleBonus(
    IntPtr pCSObject,
    byte Title,
    uint[] pResultAttr);

  [DllImport("BattleSimDll")]
  private static extern void DLLBSCasinoModeInput(IntPtr pBSObject, byte Param);

  [DllImport("BattleSimDll")]
  private static extern void DllSetHeroChallengeQuestTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    ushort RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DLLBSetHeroChallengeDifficulty(
    IntPtr pBSObject,
    ushort questA,
    ushort questB);

  [DllImport("BattleSimDll")]
  private static extern byte DLLBGetHeroChallengeFailedQuest(IntPtr pBSObject);

  [DllImport("BattleSimDll")]
  private static extern void DllCSCalculateCastleSKinBonus(
    IntPtr pCSObject,
    byte[] SkinUnlock,
    byte[] SkinLevel,
    uint[] pResultAttr);

  [DllImport("BattleSimDll")]
  private static extern void DllSetCastleSkinTable(
    IntPtr TableIndx,
    uint IndexCount,
    IntPtr Table,
    ushort RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetCastleSkinEnhanceTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    ushort RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllCSCalculatePetSkillBonus(
    IntPtr pCSObject,
    ushort PetNum,
    _CalcPetDataType[] pCalcPetData,
    uint[] pResultAttr);

  [DllImport("BattleSimDll")]
  private static extern void DllSetPetTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    ushort RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetPetSkillTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    ushort RecNumber);

  [DllImport("BattleSimDll")]
  private static extern void DllSetCPetSkillValueTable(
    IntPtr TableIndx,
    ushort IndexCount,
    IntPtr Table,
    ushort RecNumber);

  public static BSInvokeUtil getInstance
  {
    get
    {
      if (BSInvokeUtil.Self == null)
        BSInvokeUtil.Self = new BSInvokeUtil();
      return BSInvokeUtil.Self;
    }
  }

  public static void free()
  {
    if (BSInvokeUtil.Self == null)
      return;
    BSInvokeUtil.Self.Dispose();
    BSInvokeUtil.Self = (BSInvokeUtil) null;
  }

  ~BSInvokeUtil() => Debug.Log((object) "~BSInvokeUtil called");

  public void Dispose()
  {
    BSInvokeUtil.DllDisposeBSInstance(this.m_pBSObject);
    BSInvokeUtil.DllDisposeCSInstance(this.m_pCSObject);
    BSInvokeUtil.DllDisposeTableInstance();
    this.m_pBSObject = IntPtr.Zero;
    this.m_pCSObject = IntPtr.Zero;
  }

  public void InitSimulator(ref BattleInfo battleInfo)
  {
    if (BSInvokeUtil.DllBSInit(this.m_pBSObject, battleInfo.RandomSeed, battleInfo.RandomGap, battleInfo.BattleType, battleInfo.StageKind, battleInfo.StageID, battleInfo.PrimarySide))
      return;
    Debug.LogError((object) ("Init BS Failed IsNull:" + false.ToString() + " RandomSeed: " + battleInfo.RandomSeed.ToString() + " RandomGap: " + battleInfo.RandomGap.ToString() + " BattleType: " + battleInfo.BattleType.ToString() + " StageKind: " + battleInfo.StageKind.ToString() + " StageID: " + battleInfo.StageID.ToString() + " PrimarySide: " + battleInfo.PrimarySide.ToString()));
  }

  public void setHeroState(ushort Side, ushort id, ref CalcAttrDataType attrData)
  {
    BSInvokeUtil.DllBSSetHero(this.m_pBSObject, Side, id, attrData);
  }

  public byte updateBattleData(
    uint Tick,
    [Out] byte[] pCommandsBuffLeft,
    [Out] byte[] pCommandsBuffRight,
    [Out] byte[] pCommandsBuffForServer)
  {
    return BSInvokeUtil.DllBSUpdateClient(this.m_pBSObject, Tick, pCommandsBuffLeft, pCommandsBuffRight, pCommandsBuffForServer);
  }

  public void setHeroOver(byte[] pHeroDataLeft, byte[] pHeroDataRight)
  {
    BSInvokeUtil.DLLBSSetHeroOver(this.m_pBSObject, pHeroDataLeft, pHeroDataRight);
  }

  public byte setNextStage(byte[] pHeroDataLeft, byte[] pHeroDataRight)
  {
    return BSInvokeUtil.DllBSNextStage(this.m_pBSObject, pHeroDataLeft, pHeroDataRight);
  }

  public uint updateFightScore(ushort HeroID, uint HP, ushort[] pAttr, byte[] SkillLV)
  {
    return BSInvokeUtil.DllUpdateFightScore(this.m_pBSObject, HeroID, HP, pAttr, SkillLV);
  }

  public void setCalculateAttribute(
    ushort HeroID,
    ref CalcAttrDataType CalcAttrData,
    ref uint HP,
    [Out] ushort[] pAttr)
  {
    BSInvokeUtil.DllCalculateAttribute(this.m_pBSObject, HeroID, CalcAttrData, ref HP, pAttr);
  }

  public void setCalculateHeroEquipEffect(
    ushort HeroID,
    byte Enhance,
    byte Equip,
    ref uint HP,
    [Out] ushort[] pAttr)
  {
    BSInvokeUtil.DLLCalculateHeroEquipEffect(this.m_pBSObject, HeroID, Enhance, Equip, ref HP, pAttr);
  }

  public void InitCSSimulator(ushort RndSeed, ushort RndGap)
  {
    if (BSInvokeUtil.DllCSInit(this.m_pCSObject, RndSeed, RndGap))
      return;
    Debug.LogError((object) "Init CS Failed");
  }

  public void setCombatInfo(
    byte LeftLv,
    TroopLeaderType[] pleftLeaderData,
    byte leftLeaderNum,
    uint[,] pleftTroopForce,
    byte RightLv,
    TroopLeaderType[] prightLeaderData,
    byte rightLeaderNum,
    uint[,] prightTroopForce)
  {
    BSInvokeUtil.DllCSSetCombatInfo(this.m_pCSObject, LeftLv, pleftLeaderData, leftLeaderNum, pleftTroopForce, RightLv, prightLeaderData, rightLeaderNum, prightTroopForce);
  }

  public int setTroopOver(byte[] pHeroDataLeft, byte[] pHeroDataRight)
  {
    return BSInvokeUtil.DLLCSSetTroopOver(this.m_pCSObject, pHeroDataLeft, pHeroDataRight);
  }

  public int setTroopAttrData(
    uint[] pLeftAtk,
    uint[] pLeftDef,
    uint[] pLeftHp,
    uint[] pRightAtk,
    uint[] pRightDef,
    uint[] pRightHp)
  {
    return BSInvokeUtil.DllCSSetTroopAttrData(this.m_pCSObject, pLeftAtk, pLeftDef, pLeftHp, pRightAtk, pRightDef, pRightHp);
  }

  public int setTrapAttrData(ref CombatCastleDefAttrDataType TrapAttr)
  {
    return BSInvokeUtil.DllCSSetTrapAttrData(this.m_pCSObject, TrapAttr);
  }

  public byte updateWarData(uint Tick, byte[] pCommandsBuffLeft, byte[] pCommandsBuffRight)
  {
    return BSInvokeUtil.DllCSUpdateClient(this.m_pCSObject, Tick, pCommandsBuffLeft, pCommandsBuffRight);
  }

  public bool setWallTrapInfo(uint WallDefence, uint WallDefenceMax, uint[,] pTrapForce)
  {
    return BSInvokeUtil.DllCSSetWallTrapInfo(this.m_pCSObject, WallDefence, WallDefenceMax, pTrapForce);
  }

  public bool initUltra(byte heroIdx, ref byte closetHeroIdx, ref float posX, ref float posY)
  {
    return BSInvokeUtil.DllBSInitUltra(this.m_pBSObject, heroIdx, ref closetHeroIdx, ref posX, ref posY);
  }

  public void ultraInput(byte param1, byte param2)
  {
    BSInvokeUtil.DllBSUltraInput(this.m_pBSObject, param1, param2);
  }

  public uint checkUltraCondition() => BSInvokeUtil.DllBSCheckUltraCondition(this.m_pBSObject);

  public uint checkRightUltraCondition()
  {
    return BSInvokeUtil.DllBSCheckRightUltraCondition(this.m_pBSObject);
  }

  public void checkUltraHitTarget(byte Param1, byte Param2, ref uint HitNum)
  {
    BSInvokeUtil.DllBSCheckUltraHitTarget(this.m_pBSObject, Param1, Param2, ref HitNum);
  }

  public unsafe void updateBuildEffectval(uint[] EffVal)
  {
    byte bAlterOpen = 0;
    if (GUIManager.Instance.BuildingData.GetBuildNumByID((ushort) 19) > (byte) 0 && DataManager.Instance.m_AltarEffect.BeginTime > 0L)
      bAlterOpen = (byte) 1;
    if (GUIManager.Instance.BuildingData.AllBuildsData.Length <= 0)
      return;
    RoleBuildingData* roleBuildingDataPtr = GUIManager.Instance.BuildingData.AllBuildsData == null || GUIManager.Instance.BuildingData.AllBuildsData.Length == 0 ? (RoleBuildingData*) null : &GUIManager.Instance.BuildingData.AllBuildsData[0];
    BSInvokeUtil.DllCSCalculateBuildingBonus(this.m_pCSObject, roleBuildingDataPtr + 1, bAlterOpen, EffVal);
    roleBuildingDataPtr = (RoleBuildingData*) null;
  }

  public void updateTechnlolgyEffectval(uint[] EffVal)
  {
    BSInvokeUtil.DllCSCalculateResearchBonus(this.m_pCSObject, DataManager.Instance.AllTechData, EffVal);
  }

  public void updateHeroEffectval(byte HeroNum, CalcHeroDataType[] calcHeroData, uint[] EffVal)
  {
    if (HeroNum == (byte) 0)
      Array.Clear((Array) EffVal, 0, EffVal.Length);
    else
      BSInvokeUtil.DllCSCalculateHeroSkillBonus(this.m_pCSObject, HeroNum, calcHeroData, (byte) DataManager.Instance.beCaptured.nowCaptureStat, DataManager.Instance.GetLeaderID(), EffVal);
  }

  public void updateTalentval(uint[] EffVal)
  {
    BSInvokeUtil.DllCSCalculateTalentBonus(this.m_pCSObject, DataManager.Instance.AllTalentData, EffVal);
  }

  public void updateBuffBonus(byte buffNum, ushort[] ItemID, uint[] EffVal)
  {
    byte buffInfo = PetManager.Instance.UpdateCalculateBuffInfo();
    BSInvokeUtil.DllCSCalculateBuffBonus(this.m_pCSObject, buffNum, ItemID, buffInfo, PetManager.Instance.CalcPetBuffDataType, EffVal);
  }

  public void updateVIPBonus(uint[] EffVal)
  {
    BSInvokeUtil.DllCSCalculateVIPBonus(this.m_pCSObject, DataManager.Instance.RoleAttr.VIPLevel, EffVal);
  }

  public void updateLordBonus(uint[] EffVal)
  {
    BSInvokeUtil.DllCSCalculateOnLordEquipBonus(this.m_pCSObject, LordEquipData.RoleEquip, EffVal);
  }

  public void updateWonderBonus(uint[] EffVal)
  {
    List<WonderData> wonders = DataManager.Instance.m_Wonders;
    Array.Clear((Array) EffVal, 0, EffVal.Length);
    if (this.WonderCheck == null)
      this.WonderCheck = new byte[DataManager.MapDataController.MapWondersInfoTable.TableCount];
    else
      Array.Clear((Array) this.WonderCheck, 0, this.WonderCheck.Length);
    for (int index = 0; index < wonders.Count; ++index)
    {
      if ((int) wonders[index].WonderID < this.WonderCheck.Length && this.WonderCheck[(int) wonders[index].WonderID] <= (byte) 0)
      {
        this.WonderCheck[(int) wonders[index].WonderID] = (byte) 1;
        BSInvokeUtil.DllCSCalculateWonderBonus(this.m_pCSObject, (byte) ((uint) wonders[index].WonderID + 1U), EffVal);
      }
    }
    BSInvokeUtil.DllCSCalculateWonderTitleBonus(this.m_pCSObject, (byte) DataManager.Instance.RoleAttr.KingdomTitle, EffVal);
    BSInvokeUtil.DllCSCalculateWorldTitleBonus(this.m_pCSObject, (byte) DataManager.Instance.RoleAttr.WorldTitle_Personal, (byte) DataManager.Instance.RoleAttr.WorldTitle_Country, EffVal);
    BSInvokeUtil.DllCSCalculateFederalTitleBonus(this.m_pCSObject, (byte) DataManager.Instance.RoleAttr.NobilityTitle, EffVal);
  }

  public void updateCastleSkinBonus(uint[] EffVal)
  {
    BuildsData buildingData = GUIManager.Instance.BuildingData;
    if (buildingData.castleSkin.SkinUnlock == null || buildingData.castleSkin.SkinLevel == null || buildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 9)
      return;
    BSInvokeUtil.DllCSCalculateCastleSKinBonus(this.m_pCSObject, buildingData.castleSkin.SkinUnlock, buildingData.castleSkin.SkinLevel, EffVal);
  }

  public void updatePetAttribBonum(uint[] EffVal)
  {
    ushort petDataCount = PetManager.Instance.PetDataCount;
    PetManager instance = PetManager.Instance;
    _CalcPetDataType[] calcPetDataType = PetManager.Instance.CalcPetDataType;
    for (byte Index = 0; (int) Index < (int) petDataCount; ++Index)
    {
      PetData petData = instance.GetPetData((int) Index);
      calcPetDataType[(int) Index].PetID = petData.ID;
      calcPetDataType[(int) Index].Star = petData.Enhance;
      calcPetDataType[(int) Index].SkillLV = petData.SkillLv;
    }
    BSInvokeUtil.DllCSCalculatePetSkillBonus(this.m_pCSObject, petDataCount, calcPetDataType, EffVal);
  }

  public void getCombatStageAttr(
    byte CombatStageID,
    ushort Head,
    byte HeroNum,
    TroopLeaderType[] pHeroData,
    uint[] pCalcCombatAttr,
    uint[] pCalcCombatLoadAttr,
    uint[] pResultLeftAtk,
    uint[] pResultLeftDef,
    uint[] pResultLeftHp,
    uint[] pResultRightAtk,
    uint[] pResultRightDef,
    uint[] pResultRightHp,
    ref CombatCastleDefAttrDataType pResultTrapAttr,
    bool bInDeShieldBuff)
  {
    BSInvokeUtil.DllCSGetCombatStageAttr(this.m_pCSObject, CombatStageID, Head, HeroNum, pHeroData, pCalcCombatAttr, pCalcCombatLoadAttr, pResultLeftAtk, pResultLeftDef, pResultLeftHp, pResultRightAtk, pResultRightDef, pResultRightHp, ref pResultTrapAttr, bInDeShieldBuff);
  }

  public uint getEventDataLen() => BSInvokeUtil.DLLBSGetEventDataLen(this.m_pBSObject);

  public byte SetMonsterHP(uint MaxHP, uint NowHP)
  {
    return BSInvokeUtil.DLLBSSetPVEMonsterHP(this.m_pBSObject, MaxHP, NowHP);
  }

  public bool SetMonsterAttrData(ref MonsterAttrDataType AttrData)
  {
    return BSInvokeUtil.DLLBSSetPVEMonsterAttr(this.m_pBSObject, AttrData);
  }

  public uint GetVersion() => BSInvokeUtil.DllGetVersionNum();

  public void SetArenaTopic(
    byte TopicID1,
    byte TopicID2,
    ArenaTopicEffectDataType Effect1,
    ArenaTopicEffectDataType Effect2)
  {
    BSInvokeUtil.DLLBSSetArenaTopic(this.m_pBSObject, TopicID1, TopicID2, Effect1, Effect2);
  }

  public void SetCoordData(ushort LeftCoord, ushort RightCoord)
  {
    BSInvokeUtil.DLLSetCoordData(LeftCoord, RightCoord);
  }

  public void SetUserData(long UserId, ulong BattleCode)
  {
  }

  public void CasinoModeInput(byte Param)
  {
    BSInvokeUtil.DLLBSCasinoModeInput(this.m_pBSObject, Param);
  }

  public void SetHeroChallengeDifficulty(ushort QuestA, ushort QuestB = 0)
  {
    BSInvokeUtil.DLLBSetHeroChallengeDifficulty(this.m_pBSObject, QuestA, QuestB);
  }

  public byte GetHeroChallengeFailedQuest()
  {
    return BSInvokeUtil.DLLBGetHeroChallengeFailedQuest(this.m_pBSObject);
  }
}
