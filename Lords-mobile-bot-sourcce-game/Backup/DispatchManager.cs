// Decompiled with JetBrains decompiler
// Type: DispatchManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.CompilerServices;
using UnityEngine;

#nullable disable
public class DispatchManager
{
  private static DispatchManager instance;

  private DispatchManager()
  {
  }

  public static DispatchManager Instance
  {
    get
    {
      if (DispatchManager.instance == null)
        DispatchManager.instance = new DispatchManager();
      return DispatchManager.instance;
    }
  }

  public static void GuestDispatcher(MessagePacket MP)
  {
    switch (MP.Protocol)
    {
      case Protocol._MSG_GUESTLOGIN_LOGINERRORRESP:
        NetworkManager.GuestController.Login(MP);
        break;
      case Protocol._MSG_RESP_ACTIVE:
        NetworkManager.GuestController.MakeBeat(MP, 15L);
        break;
      case Protocol._MSG_RESP_UPDATE_MAPINFO_PLUS:
        if ((int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
          break;
        DataManager.MapDataController.RecvMapInfoPlus(MP);
        break;
      case Protocol._MSG_RESP_WONDER_SWITCH:
        if ((int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
          break;
        DataManager.MapDataController.UpdateYolkswitch(MP);
        break;
      case Protocol._MSG_RESP_MAP_PRISONER_LIST:
        JailManage.MSG_RESP_MAP_PRISONER_LIST(MP);
        break;
      case Protocol._MSG_RESP_WORLD_TELEPORT_ITEM:
        DataManager.Instance.RecvWorldTeleportItemCount(MP.ReadInt(), MP.ReadUShort());
        break;
      case Protocol._MSG_RESP_WORLDWONDER_OPEN:
        GUIManager.Instance.Recv_WORLDWONDER_OPEN(MP);
        break;
      case Protocol._MSG_RESP_WORLDWONDER_TAKEOVER:
        GUIManager.Instance.Recv_WORLDWONDER_TAKEOVER(MP);
        break;
      case Protocol._MSG_RESP_WORLDWONDER_CLOSE:
        GUIManager.Instance.Recv_WORLDWONDER_CLOSE(MP);
        break;
      case Protocol._MSG_RESP_KINGDOM_BULLITIN:
        DataManager.Instance.RecvKingdomBullitin(MP);
        break;
      case Protocol._MSG_RESP_KINGDOM_TITLE_LIST:
        TitleManager.Instance.Recv_KingdomTitle_List(MP);
        break;
      case Protocol._MSG_RESP_KING_GIFT:
        DataManager.Instance.KingGift.RecvKingGift(MP);
        break;
      case Protocol._MSG_RESP_KING_GIFT_INFO_PLUS:
        DataManager.Instance.KingGift.RecvKingGiftInfo(MP);
        break;
      case Protocol._MSG_RESP_NOBILITY_TITLE_LIST:
        TitleManager.Instance.Recv_NobilityTitle_List(MP);
        break;
      case Protocol._MSG_RESP_PETSKILL_STATE:
        DataManager.MapDataController.RESP_PETSKILL_STATE(MP);
        break;
    }
  }

  public static unsafe void Dispatcher(MessagePacket MP)
  {
    Protocol protocol = MP.Protocol;
    switch (protocol)
    {
      case Protocol._MSG_RESP_ARMYGROUPINFO_:
        DataManager.Instance.RecvArmygroupInfo(MP);
        break;
      case Protocol._MSG_RESP_TRAININGINFO_:
        DataManager.Instance.RecvTrainingInfo(MP);
        break;
      case Protocol._MSG_RESP_TRAINING_:
        DataManager.Instance.RecvTraining(MP);
        break;
      case Protocol._MSG_RESP_ADDSOLDIER_:
        DataManager.Instance.RecvAddSoldier(MP);
        break;
      case Protocol._MSG_RESP_CANCELTRAINING:
        DataManager.Instance.RecvCanceltraining(MP);
        break;
      case Protocol._MSG_RESP_TROOPDISMISS:
        DataManager.Instance.RecvTroopdismiss(MP);
        break;
      case Protocol._MSG_RESP_TRAINING_IMMEDIATELY:
        DataManager.Instance.RecvImmediately(MP);
        break;
      case Protocol._MSG_RESP_FINISHTRAINING:
        DataManager.Instance.RecvFinishtraining(MP);
        break;
      case Protocol._MSG_MARCH_MARCHEVENTDATA:
        DataManager.Instance.RecvMarchData(MP);
        break;
      case Protocol._MSG_RESP_TROOPMARCH:
        DataManager.Instance.RecvTroopMarch(MP);
        break;
      case Protocol._MSG_RESP_TROOPRETURN:
        DataManager.Instance.RecvTroopReturn(MP);
        break;
      case Protocol._MSG_RESP_TROOPHOME:
        DataManager.Instance.RecvTroopHome(MP);
        break;
      case Protocol._MSG_RESP_TROOPCAMPING:
        DataManager.Instance.RecvTroopCamping(MP);
        break;
      case Protocol._MSG_RESP_GATHERINGEVENT:
        DataManager.Instance.RecvGatheringEvent(MP);
        break;
      case Protocol._MSG_RESP_TROOPELIMINATE:
        DataManager.Instance.RecvTroopeliminate(MP);
        break;
      case Protocol._MSG_RESP_UPDATE_MARCHEVENTDATA:
        DataManager.Instance.RecvUpdateMarctEventData(MP);
        break;
      case Protocol._MSG_RESP_UPDATE_MARCHEVENTTIME:
        DataManager.Instance.UpdateMarchEventTime(MP);
        break;
      case Protocol._MSG_HOSPITAL_HOSPITALINFO:
        DataManager.Instance.RecvHospitalInfo(MP);
        break;
      case Protocol._MSG_RESP_HEALINGTROOP:
        DataManager.Instance.RecvHealingtroop(MP);
        break;
      case Protocol._MSG_RESP_HEALINGCOMPLETE:
        DataManager.Instance.RecvHealingcomplete(MP);
        break;
      case Protocol._MSG_RESP_CANCELHEALING:
        DataManager.Instance.RecvCancelealing(MP);
        break;
      case Protocol._MSG_RESP_INSTANTHEALING:
        DataManager.Instance.RecvInstanthealing(MP);
        break;
      case Protocol._MSG_RESP_FINISHHEALING:
        DataManager.Instance.RecvFinishhealing(MP);
        break;
      case Protocol._MSG_RESP_BEINGATTACK:
        DataManager.Instance.RecvBeingattack(MP);
        break;
      case Protocol._MSG_RESP_GIVEUP_HEALING:
        DataManager.Instance.RecvGiveUpHealing(MP);
        break;
      case Protocol._MSG_RESP_INITWATCHTOWER_INFO:
        DataManager.Instance.RecvInitWatchTowerInfo(MP);
        break;
      case Protocol._MSG_RESP_INITWATCHTOWER_INFOEND:
        DataManager.Instance.RecvInitWatchTowerInfoEnd(MP);
        break;
      case Protocol._MSG_RESP_UPDATEWATCHTOWER_ADDLINE:
        DataManager.Instance.RecvUpDateWatchTowerAddLine(MP);
        break;
      case Protocol._MSG_RESP_UPDATEWATCHTOWER_DELLINE:
        DataManager.Instance.RecvUpDateWatchTowerDelLine(MP);
        break;
      case Protocol._MSG_RESP_UPDATEWATCHTOWER_UPDATELINE:
        DataManager.Instance.RecvUpDateWatchTowerUpDateLine(MP);
        break;
      case Protocol._MSG_RESP_ADDCONFLICT_LINE:
        DataManager.Instance.RecvAddConflictLine(MP);
        break;
      case Protocol._MSG_RESP_DELCONFLICT_LINE:
        DataManager.Instance.RecvDelConflictLine(MP);
        break;
      case Protocol._MSG_RESP_WATCHTOWER_LINEDETAIL:
        DataManager.Instance.RecvWatchTowerLineDetail(MP);
        break;
      case Protocol._MSG_RESP_WATCHTOWER_LINEDETAIL_ERROR:
        DataManager.Instance.RecvWatchTowerLineDetail_ERROR(MP);
        break;
      case Protocol._MSG_RESP_SENDSCOUT:
        DataManager.Instance.RecvScout(MP);
        break;
      case Protocol._MSG_RESP_SCOUTRETURN:
        DataManager.Instance.RecvScoutReturn(MP);
        break;
      case Protocol._MSG_RESP_SCOUTHOME:
        DataManager.Instance.RecvScoutHome(MP);
        break;
      case Protocol._MSG_RESP_SEND_RESHELP:
        DataManager.Instance.RecvSHelp(MP);
        break;
      case Protocol._MSG_RESP_RESHELP_RETURN:
        DataManager.Instance.RecvHelp_Return(MP);
        break;
      case Protocol._MSG_RESP_RESHELP_HOME:
        DataManager.Instance.RecvHelp_Home(MP);
        break;
      case Protocol._MSG_RESP_INFORCE_INFO:
        DataManager.Instance.RecvInforce_Info(MP);
        break;
      case Protocol._MSG_RESP_EMBASSY_MSG:
        DataManager.Instance.RecvEmbassy_Msg(MP);
        break;
      case Protocol._MSG_RESP_SEND_INFORCE:
        DataManager.Instance.RecvSendInforce(MP);
        break;
      case Protocol._MSG_RESP_DISMISS_INFORCE:
        DataManager.Instance.RecvDimiss_Inforce(MP);
        break;
      case Protocol._MSG_RESP_INFORCE_ARRIVED:
        DataManager.Instance.RecvInforce_Arrived(MP);
        break;
      case Protocol._MSG_RESP_INFORCE_DISMISSRETURN:
        DataManager.Instance.RecvAllyInforceReturn(MP);
        break;
      case Protocol._MSG_RESP_ALLY_INFORCE_INFO:
        DataManager.Instance.RecvAllyInforceInfo(MP);
        break;
      case Protocol._MSG_RESP_BEGIN_RALLY:
        DataManager.Instance.RecvBeginRally(MP);
        break;
      case Protocol._MSG_RESP_CANCEL_RALLY:
        DataManager.Instance.RecvCancelRally(MP);
        break;
      case Protocol._MSG_RESP_JOIN_RALLY:
        DataManager.Instance.RecvJoinRally(MP);
        break;
      case Protocol._MSG_RESP_ARRIVED_RALLYPOINT:
        DataManager.Instance.RecvArrivedRallyPoint(MP);
        break;
      case Protocol._MSG_RESP_RALLY_ATKMARCH:
        DataManager.Instance.RecvRallyAtkMarch(MP);
        break;
      case Protocol._MSG_RESP_WARHALL_INITLIST:
        DataManager.Instance.RecvWallDataNum(MP);
        break;
      case Protocol._MSG_RESP_WARHALL_UPDATE_LISTELE:
        DataManager.Instance.RecvWallHallData(MP);
        break;
      case Protocol._MSG_RESP_WARHALL_DELETE_LISTELE:
        DataManager.Instance.RecvWallHallDel(MP);
        break;
      case Protocol._MSG_RESP_WARHALL_INIT_LISTDETAIL:
        DataManager.Instance.RecvWallHallDetail(MP);
        break;
      case Protocol._MSG_RESP_WARHALL_END_LISTDETAIL:
        DataManager.Instance.RecvWallHallDetailClose(MP);
        break;
      case Protocol._MSG_RESP_WARHALL_UPDATE_LISTDETAIL:
        DataManager.Instance.RecvWallHallTroop(MP);
        break;
      case Protocol._MSG_RESP_WARHALL_DELETE_LISTDETAIL:
        DataManager.Instance.RecvWallHallTroopDel(MP);
        break;
      case Protocol._MSG_RESP_BROCAST_WAR_BEGIN:
        DataManager.Instance.RecvWarBegin(MP);
        break;
      case Protocol._MSG_RESP_JOINED_RALLYDATA:
        DataManager.Instance.RecvJoinedRallyData(MP);
        break;
      case Protocol._MSG_RESP_SENDMONSTER:
        DataManager.MapDataController.RecvMapMonsterAttack(MP);
        break;
      case Protocol._MSG_RESP_MONSTERRETURN:
        DataManager.MapDataController.RecvMonsterReturn(MP);
        break;
      case Protocol._MSG_RESP_MONSTERHOME:
        DataManager.MapDataController.RecvMonsterHome(MP);
        break;
      case Protocol._MSG_RESP_MONSTER_INFO:
        DataManager.MapDataController.RecvMapMonsterInfo(MP);
        break;
      case Protocol._MSG_RESP_WONDEROCCUPIED:
        DataManager.Instance.RecvWonderOccupied(MP);
        break;
      case Protocol._MSG_RESP_WONDERINFORCE_ARRIVED:
        DataManager.Instance.RecvWonderInforceArrived(MP);
        break;
      case Protocol._MSG_RESP_WONDER_SEND_INFORCE:
        DataManager.Instance.RecvWonder_Send_Inforce(MP);
        break;
      case Protocol._MSG_RESP_WONDER_BEGIN_RALLY:
        DataManager.Instance.RecvWonder_Begin_Rally(MP);
        break;
      case Protocol._MSG_RESP_WONDER_RALLY_ATKMARCH:
        DataManager.Instance.RecvWonder_Rally_Atkmarch(MP);
        break;
      case Protocol._MSG_RESP_WONDERTEAM_INIT_LISTDETAIL:
        DataManager.Instance.RespWonderTeamInitDetail(MP);
        break;
      case Protocol._MSG_RESP_WONDERTEAM_END_LISTDETAIL:
        DataManager.Instance.RespWonderTeamEnd(MP);
        break;
      case Protocol._MSG_RESP_WONDERTEAM_UPDATE_LISTDETAIL:
        DataManager.Instance.RespWonderTeamUpdate(MP);
        break;
      case Protocol._MSG_RESP_WONDERTEAM_DELETE_LISTDETAIL:
        DataManager.Instance.RespWinderTeamDel(MP);
        break;
      case Protocol._MSG_RESP_WONDER_WARHALL_UPDATE_LISTELE:
label_340:
        DataManager.Instance.RespWonderWarhallList(MP);
        break;
      case Protocol._MSG_RESP_WONDER_WARHALL_INIT_LISTDETAIL:
label_341:
        DataManager.Instance.RespWonderListDetail(MP);
        break;
      case Protocol._MSG_RESP_JOINED_UPDATERALLYSPEED:
        DataManager.Instance.UpdateJoinedMarchEventTime(MP);
        break;
      case Protocol._MSG_RESP_AMBUSH_INFO:
        AmbushManager.Instance.RecvAmbushInfo(MP);
        break;
      case Protocol._MSG_RESP_AMBUSH_UPDATE:
        AmbushManager.Instance.RecvAmbushUpdate(MP);
        break;
      case Protocol._MSG_RESP_DISMISS_AMBUSH:
        AmbushManager.Instance.RecvDismissAmbush(MP);
        break;
      case Protocol._MSG_RESP_ALLY_AMBUSH_INFO:
        AmbushManager.Instance.RecvAllyAmbushInfo(MP);
        break;
      case Protocol._MSG_RESP_SEND_AMBUSH:
        AmbushManager.Instance.RecvAmbush(MP);
        break;
      case Protocol._MSG_RESP_AMBUSHARRIVED:
        AmbushManager.Instance.RecvAmbushArrived(MP);
        break;
      case Protocol._MSG_RESP_AMBUSH_RETURN:
        AmbushManager.Instance.RecvAmbushReturn(MP);
        break;
      default:
        switch (protocol)
        {
          case Protocol._MSG_REQUEST_ALLIANCE_INFO:
            DataManager.Instance.RecvAllianceInfo(MP);
            return;
          case Protocol._MSG_ALLIANCE_RESP_MAININFO:
            DataManager.Instance.RecvAllianceMain(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_NAMECHECK:
          case Protocol._MSG_RESP_ALLIANCE_TAGCHECK:
          case Protocol._MSG_RESP_ALLIANCE_CREATE:
          case Protocol._MSG_RESP_ALLIANCE_APPLY:
          case Protocol._MSG_RESP_ALLIANCE_USER_CANCELAPPLY:
          case Protocol._MSG_RESP_ALLIANCE_SEARCH:
          case Protocol._MSG_RESP_ALLIANCE_SRARCHRESULT:
          case Protocol._MSG_RESP_ALLIANCE_APPLYALLIANCELIST:
          case Protocol._MSG_RESP_ALLIANCE_MODIFY_NAME:
          case Protocol._MSG_RESP_ALLIANCE_MODIFY_TAG:
            DataManager.Instance.RecvAllianceCreate(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_DEALAPPLY:
            DataManager.Instance.RecvAllianceApplyResult(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_QUIT:
            DataManager.Instance.RecvAllianceQuit(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_MEMBERINFO:
            DataManager.Instance.RecvAllianceMember(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_OTHER_MEMBERINFO:
            DataManager.Instance.RecvAllianceOthorMemberInfo(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_APPLYLIST:
            DataManager.Instance.RecvAllianceApplyMember(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_STEPDOWN:
            DataManager.Instance.RecvAllianceStepDown(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_MODIFY_SLOGAN:
            DataManager.Instance.RecvAllianceSlogan(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_MODIFY_NEEDAPPLY:
            DataManager.Instance.RecvAllianceNeedApply(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_MODIFY_EMBLEM:
            DataManager.Instance.RecvAllianceModifyEmblem(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_MODIFY_LANGUAGE:
            DataManager.Instance.RecvAllianceModifyLanguage(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_MODIFY_BULLETIN:
            DataManager.Instance.RecvAllianceModifyBulletin(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_MODIFY_BRIEF:
            DataManager.Instance.RecvAllianceModifyBrief(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_MODIFY_RANK:
            DataManager.Instance.RecvAllianceModifyRank(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_QUITMEMBER:
            DataManager.Instance.RecvAllianceQuitMember(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_NEEDHELP_INFO:
            DataManager.Instance.RecvAllianceNeedHelp(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_HELP:
            DataManager.Instance.RecvAllianceHelp(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_SOMEBODY_NEEDHELP:
            DataManager.Instance.RecvAllianceSomebodyNeedHelp(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_HELP_SOMEBODY:
            DataManager.Instance.RecvAllianceHelpSomebody(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_PUBLICINFO:
            DataManager.Instance.RecvAlliancePublicInfo(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_UPDATEINFO:
            DataManager.Instance.RecvAllianceAttr(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_INVITE:
            DataManager.Instance.RecvAllianceInvite(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_GIFT_INFO:
            DataManager.Instance.RecvAllianceGift_Info(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_GIFT_OPENBOX:
            DataManager.Instance.RecvAllianceGift_Open(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_GIFT_DELETEBOX:
            DataManager.Instance.RecvAllianceGift_Delete(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_GIFT_CHECKEXPIRED:
            DataManager.Instance.RecvAllianceGift_CheckExpired(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_GIFT_OPENALLBOX:
            DataManager.Instance.RecvAllianceGift_OpenAllBox(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_WONDER_INFO:
            DataManager.Instance.RecvAllianceWonder_Info(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_MEMBERNICKNAME:
            DataManager.Instance.RecvAllianceMemberNickName(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_DISMISS_LEADER:
            DataManager.Instance.RecvAllanceDismissLeader(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_CHANGE_HOMEKINGDOM:
            DataManager.Instance.RecvAllance_Change_HomeKingdom(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_BOOKMARKINFO:
            DataManager.Instance.RoleBookMark.RecvBookMarkList_Alliance(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_MODIFYBOOKMARK:
            DataManager.Instance.RoleBookMark.RecvBookMarkAddModify_Alliance(MP);
            return;
          case Protocol._MSG_RESP_ALLIANCE_REMOVEBOOKMARK:
            DataManager.Instance.RoleBookMark.RecvBookMarkDel_Alliance(MP);
            return;
          default:
            switch (protocol)
            {
              case Protocol._MSG_RESP_ACTIVITYINFO:
                ActivityManager.Instance.RecvActivity_Info(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_PREPARE:
                ActivityManager.Instance.RecvActivity_Prepare(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_RUN:
                ActivityManager.Instance.RecvActivity_Run(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_END:
                ActivityManager.Instance.RecvActivity_End(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_EVENT_LIST:
                ActivityManager.Instance.RecvActivity_EventList(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_EVENT_LIST_SINGLE:
                ActivityManager.Instance.RecvActivity_EventListSingle(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_EVENT_DETAIL:
                ActivityManager.Instance.RecvActivity_EventDetail(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_RANKING_PRIZE:
                ActivityManager.Instance.RecvActivity_RankingPrize(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_GETPRIZE:
                ActivityManager.Instance.RecvActivity_GetPrize(MP);
                return;
              case Protocol._MSG_ACTIVITY_CLOSE:
                ActivityManager.Instance.RecvActivity_Close(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_SPEVENT_LIST_SINGLE:
                ActivityManager.Instance.RecvActivity_SpEvent_List_Single(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_UPDATE_INFO:
                ActivityManager.Instance.RecvActivity_UpDateInfo(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_KEVENT_LIST_SINGLE:
                ActivityManager.Instance.RecvActivity_KEventListSingle(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_KEVENT_DETAIL:
                ActivityManager.Instance.RecvActivity_KEventDetail(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_KEVENT_UPDATESTATE:
                ActivityManager.Instance.RecvActivity_Kevent_UpdateStateE(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_KEVENT_RANKING_PRIZE:
                ActivityManager.Instance.RecvActivity_Kevent_RankingPrize(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_AEVENT_PERSONAL_RANK:
                LeaderBoardManager.Instance.Recv_MSG_RESP_ACTIVITY_AEVENT_PERSONAL_RANK(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_AM_RANKING_PRIZE:
                ActivityManager.Instance.RecvActivity_AM_RankingPrize(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_AM_DEGREEPRIZE:
                MobilizationManager.Instance.RecvActivityAmDegeePrize(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_AM_GET_DEGREEPRIZE:
                MobilizationManager.Instance.RecvActivityAmGetDegreePrize(MP);
                return;
              case Protocol._MSG_RESP_ALLIANCEMOBLIZATION_MISSION_DATA:
                MobilizationManager.Instance.Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_DATA(MP);
                return;
              case Protocol._MSG_RESP_ALLIANCEMOBLIZATION_MISSION_BUY:
                MobilizationManager.Instance.Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_BUY(MP);
                return;
              case Protocol._MSG_RESP_ALLIANCEMOBLIZATION_MISSION_GET:
                MobilizationManager.Instance.Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_GET(MP);
                return;
              case Protocol._MSG_RESP_ALLIANCEMOBLIZATION_MISSION_DEL:
                MobilizationManager.Instance.Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_DEL(MP);
                return;
              case Protocol._MSG_RESP_ALLIANCEMOBLIZATION_MISSION_FINISH:
                MobilizationManager.Instance.Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_FINISH(MP);
                return;
              case Protocol._MSG_RESP_ALLIANCEMOBILIZATION_MISSION_UPDATE:
                MobilizationManager.Instance.Recv_MSG_RESP_ALLIANCEMOBILIZATION_MISSION_UPDATE(MP);
                return;
              case Protocol._MSG_RESP_ALLIANCEMOBILIZATION_MISSION_DONE:
                MobilizationManager.Instance.Recv_MSG_RESP_ALLIANCEMOBILIZATION_MISSION_DONE(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_AM_MEMBER_RANK:
                LeaderBoardManager.Instance.Recv_MSG_RESP_ACTIVITY_AM_MEMBER_RANK(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_AM_ALLIANCE_RANK:
                LeaderBoardManager.Instance.Recv_MSG_RESP_ACTIVITY_AM_ALLIANCE_RANK(MP);
                return;
              case Protocol._MSG_RESP_KINGOFTHEWORLD_KINGINFO:
                ActivityManager.Instance.RecvActivity_KOW_KingInfo(MP);
                return;
              case Protocol._MSG_RESP_KINGOFTHEWORLD_RANKDATA:
                LeaderBoardManager.Instance.Recv_MSG_RESP_KINGOFTHEWORLD_RANKDATA(MP);
                return;
              case Protocol._MSG_RESP_KINGOFTHEWORLD_HISTORYKINGDATA:
                LeaderBoardManager.Instance.Recv_MSG_RESP_KINGOFTHEWORLD_HISTORYKINGDATA(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_DAILYGIFT:
                DataManager.Instance.Recv_DailyGift(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_MARQUREEUPDATE:
                ActivityManager.Instance.RecvRunningText(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_SPEVENT_EXDATA:
                ActivityManager.Instance.RecvSPExtraData(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_MKEVENT_MATCHINFO:
                ActivityManager.Instance.RecvKvKMatchInfo(MP);
                return;
              case Protocol._MSG_RESP_GAMBLE_UPDATEINFO:
                GamblingManager.Instance.Recv_MSG_RESP_GAMBLE_UPDATEINFO(MP);
                return;
              case Protocol._MSG_RESP_NPCCITY_UPDATEINFO:
                ActivityManager.Instance.RecvNPCCITY_UPDATEINFO(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_AM_DEGREEPRIZE_NEW:
                MobilizationManager.Instance.RecvActivityAmDegeePrize_New(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_AS_UPDATESTATE:
                ActivityManager.Instance.RecvActivity_AllianceSummon_UpdateState(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_AS_SUMMON:
                DataManager.Instance.RecvActivityAsSummon(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_AS_SUMMON_KMSG:
                ActivityManager.Instance.RecvActivity_AllianceSummon_KMSG(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_AS_PERSONAL_RANK:
                LeaderBoardManager.Instance.Recv_MSG_RESP_AlliHunt_RANKDATA(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_AS_DONATE_BOARD:
                ActivityManager.Instance.Recv_Alliance_Donate(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_AS_DONATE_DATA:
                ActivityManager.Instance.Recv_Alliance_Donate_Data(MP);
                return;
              case Protocol._MSG_ALLIANCESUMMON_DONATEBOARDCHANGE:
                ActivityManager.Instance.Recv_Alliancesummon_DonateBoardChange(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_UPDATESTATE:
                ActivityManager.Instance.RecvActivity_UPDATESTATE(MP);
                return;
              case Protocol._MSG_RESP_ACTIVITY_HKEVENT_HUNTINFO:
                ActivityManager.Instance.RecvKvKHuntInfo(MP);
                return;
              default:
                switch (protocol)
                {
                  case Protocol._MSG_RESP_MAILMETA:
                  case Protocol._MSG_RESP_REPORTMETA:
                  case Protocol._MSG_RESP_SAVEMAILMETA:
                  case Protocol._MSG_RESP_NOTICEMETA:
                  case Protocol._MSG_RESP_MAILINFO:
                  case Protocol._MSG_RESP_MAILINFOEND:
                  case Protocol._MSG_RESP_MAILMARKREAD:
                  case Protocol._MSG_RESP_SAVEMAIL:
                  case Protocol._MSG_RESP_DELETEMAIL:
                  case Protocol._MSG_RESP_ALLMAIL_MOD:
                  case Protocol._MSG_RESP_SCOUTREPORTINFO:
                  case Protocol._MSG_RESP_COMBATREPORTINFO:
                  case Protocol._MSG_RESP_GATHERREPORTINFO:
                  case Protocol._MSG_RESP_ANTISCOUTREPORTINFO:
                  case Protocol._MSG_RESP_RESHELPREPORTINFO:
                  case Protocol._MSG_RESP_MONSTERREPORTINFO:
                  case Protocol._MSG_RESP_REPORINFOEND:
                  case Protocol._MSG_RESP_REPORTMARKREAD:
                  case Protocol._MSG_RESP_SAVEREPORT:
                  case Protocol._MSG_RESP_DELETEREPORT:
                  case Protocol._MSG_RESP_ALLREPORT_MOD:
                  case Protocol._MSG_RESP_SAVEMARKREAD:
                  case Protocol._MSG_RESP_DELETESAVE:
                  case Protocol._MSG_RESP_ALLSAVE_MOD:
                  case Protocol._MSG_RESP_NOTICEINFO:
                  case Protocol._MSG_RESP_NOTICEINFOEND:
                  case Protocol._MSG_RESP_NOTICEMARKREAD:
                  case Protocol._MSG_RESP_SAVENOTICE:
                  case Protocol._MSG_RESP_DELETENOTICE:
                  case Protocol._MSG_RESP_ALLNOTICE_MOD:
                  case Protocol._MSG_RESP_MAIL_ERROR:
                  case Protocol._MSG_RESP_REPORT_ERROR:
                  case Protocol._MSG_RESP_NOTICE_ERROR:
label_182:
                    DataManager.Instance.RecvMailing(MP);
                    return;
                  case Protocol._MSG_RESP_SENDMAIL:
                    DataManager.Instance.RecvSendMail(MP);
                    return;
                  case Protocol._MSG_RESP_COMBATREPLAY:
                    GUIManager.Instance.HideUILock(EUILock.Mailing_Battle);
                    WarManager.RecvStartWar(MP);
                    return;
                  case Protocol._MSG_RESP_COMBATDETAIL_LEADERDATA:
                    DataManager.Instance.RecvCombatDetail_Leaderdata(MP);
                    return;
                  case Protocol._MSG_RESP_COMBATDETAIL_PLAYERDATA:
label_161:
                    DataManager.Instance.RecvCombatDetail_Playerdata(MP);
                    return;
                  case Protocol._MSG_RESP_LIVECOMBATREPLAYMETA:
                    GUIManager.Instance.RecvBattleMessage(MP);
                    return;
                  case Protocol._MSG_RESP_LIVECOMBATREPLAY:
                    WarManager.RecvFastStartWar(MP);
                    return;
                  case Protocol._MSG_RESP_LIVEMONSTERREPLAYMETA:
                    GUIManager.Instance.RecvWMMessage(MP);
                    return;
                  case Protocol._MSG_RESP_LIVEWONDERREPLAYMETA:
                    GUIManager.Instance.RecvWonderMessage(MP);
                    return;
                  case Protocol._MSG_RESP_COMBATDETAIL_INJUREDATA:
label_162:
                    DataManager.Instance.RecvCombatDetail_Injuredata(MP);
                    return;
                  case Protocol._MSG_RESP_COMBATDETAIL_ERROR:
                    MP.ReadByte();
                    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8241U), (ushort) byte.MaxValue);
                    return;
                  default:
                    switch (protocol)
                    {
                      case Protocol._MSG_RESP_PET_RESOURCEINFO:
                        PetResourceData.DispatchResource(MP);
                        return;
                      case Protocol._MSG_RESP_PET_ITEMINFO:
                        PetManager.Instance.RecvPetItemInfo(MP);
                        return;
                      case Protocol._MSG_RESP_PET_TRAINING_EVENT:
                        PetManager.Instance.RecvPetTrainingEvevt(MP);
                        return;
                      case Protocol._MSG_RESP_PET_TRAINING_BEGIN:
                        PetManager.Instance.RecvPetTrainingBegin(MP);
                        return;
                      case Protocol._MSG_RESP_PET_TRAINING_CANCEL:
                        PetManager.Instance.RecvPetTrainingCancel(MP);
                        return;
                      case Protocol._MSG_RESP_PET_TRAINING_COMPLETE:
                        PetManager.Instance.RecvPetTrainingComplete(MP);
                        return;
                      case Protocol._MSG_RESP_PET_LIST:
                        PetManager.Instance.RecvPetInfo(MP);
                        return;
                      case Protocol._MSG_RESP_PET_ADD_NEW_PET:
                        PetManager.Instance.RecvPetAddNewPet(MP);
                        return;
                      case Protocol._MSG_RESP_UPDATE_PET:
                        PetManager.Instance.RecvPetUpdate(MP);
                        return;
                      case Protocol._MSG_RESP_ITEMCRAFT:
                        PetManager.Instance.Recv_MSG_RESP_ITEMCRAFT(MP);
                        return;
                      case Protocol._MSG_ITEMCRAFT_INFO:
                        PetManager.Instance.Recv_MSG_ITEMCRAFT_INFO(MP);
                        return;
                      case Protocol._MSG_ITEMCRAFT_DONE:
                        PetManager.Instance.Recv_MSG_ITEMCRAFT_DONE(MP);
                        return;
                      case Protocol._MSG_RESP_PET_CURRENT_STARUP:
                        PetManager.Instance.Recv_PET_CURRENT_STARUP(MP);
                        return;
                      case Protocol._MSG_RESP_PET_STARUP_START:
                        PetManager.Instance.Recv_PET_STARUP_START(MP);
                        return;
                      case Protocol._MSG_RESP_PET_STARUP_COMPLETE:
                        PetManager.Instance.Recv_PET_STARUP_COMPLETE(MP);
                        return;
                      case Protocol._MSG_RESP_PET_STARUP_CANCEL:
                        PetManager.Instance.Recv_PET_STARUP_CANCEL(MP);
                        return;
                      case Protocol._MSG_RESP_PETSKILL_USE:
                        PetManager.Instance.Recv_PETSKILL_USE(MP);
                        return;
                      case Protocol._MSG_RESP_PETSKILL_GETSKILL:
                        PetManager.Instance.Recv_PETSKILL_GETSKILL(MP);
                        return;
                      case Protocol._MSG_RESP_PETSKILL_FATIGUE:
                        PetManager.Instance.Recv_PETSKILL_FATIGUE(MP);
                        return;
                      case Protocol._MSG_RESP_PETSKILL_COOLDOWN:
                        PetManager.Instance.Recv_PETSKILL_COOLDOWN(MP);
                        return;
                      case Protocol._MSG_RESP_PETSKILL_BUFFINFO:
                        PetManager.Instance.Recv_PETSKILL_BUFFINFO(MP);
                        return;
                      case Protocol._MSG_RESP_PETSKILL_BUFFCOMPLETE:
                        PetManager.Instance.Recv_PETSKILL_BUFFCOMPLETE(MP);
                        return;
                      case Protocol._MSG_RESP_PETSKILL_UPGRADESKILL:
                        PetManager.Instance.Recv_PETSKILL_UPGRADESKILL(MP);
                        return;
                      case Protocol._MSG_RESP_PETSKILL_UPGRADE_STONE_AMOUNT:
                        PetManager.Instance.Recv_PETSKILL_UPGRADE_STONE_AMOUNT(MP);
                        return;
                      case Protocol._MSG_RESP_PET_OPENPETBOX:
                        PetManager.Instance.Recv_MSG_RESP_PET_OPENPETBOX(MP);
                        return;
                      case Protocol._MSG_RESP_PET_MARCHEVENTDATA:
                        PetManager.Instance.RecvPetMarchEventData(MP);
                        return;
                      case Protocol._MSG_RESP_PET_MARCH_END:
                        PetManager.Instance.RecvPetMarchEnd(MP);
                        return;
                      case Protocol._MSG_RESP_PET_REPORTINFO:
                        goto label_182;
                      case Protocol._MSG_RESP_PET_LIVEINFO:
                        GUIManager.Instance.Recv_PET_LIVEINFO(MP);
                        return;
                      case Protocol._MSG_RESP_PETSKILL_STATE:
                        DataManager.MapDataController.RESP_PETSKILL_STATE(MP);
                        return;
                      default:
                        switch (protocol)
                        {
                          case Protocol._MSG_ROLE_UPDATEINFO:
                            switch (MP.ReadByte())
                            {
                              case 0:
                                DataManager.Instance.RoleAttr.Power = MP.ReadULong();
                                break;
                              case 1:
                                DataManager.Instance.RoleAttr.Kills = MP.ReadULong();
                                break;
                              case 2:
                                DataManager.MapDataController.updateCapitalPoint(MP.ReadUShort(), MP.ReadByte(), DataManager.MapDataController.OtherKingdomData.kingdomID);
                                break;
                              case 3:
                                DataManager.Instance.RecvUpdateBuffInfo(MP);
                                break;
                              case 4:
                                ActivityManager.Instance.RecvEventPoint((byte) 0, MP);
                                break;
                              case 5:
                                ActivityManager.Instance.RecvEventPoint((byte) 1, MP);
                                break;
                              case 6:
                                LordEquipData.AddItem(MP);
                                LordEquipData.SetItemTime(MP.ReadLong());
                                break;
                              case 7:
                                LordEquipData.DeleteItem(MP);
                                LordEquipData.SetItemTime(MP.ReadLong());
                                break;
                              case 8:
                                LordEquipData.SetMatTime(MP.ReadLong());
                                break;
                              case 9:
                                LordEquipData.SetGemTime(MP.ReadLong());
                                break;
                              case 10:
                                DataManager.StageDataController.UpdateRoleAttrExp(MP.ReadUInt());
                                break;
                              case 11:
                                DataManager.StageDataController.RoleAttrLevelUp(MP);
                                break;
                              case 12:
                                DataManager.Instance.RoleAttr.recvMonsterPoint = DataManager.Instance.RoleAttr.MonsterPoint;
                                DataManager.Instance.RoleAttr.LastMonsterPointRecoverTime = MP.ReadLong();
                                DataManager.Instance.RoleAttr.MonsterPointRecoverFrequency = MP.ReadUShort();
                                DataManager.Instance.UpdateMonsterPoint();
                                break;
                              case 13:
                                DataManager.Instance.RoleAttr.Diamond = MP.ReadUInt();
                                GameManager.OnRefresh();
                                break;
                              case 14:
                                DataManager.Instance.RoleAlliance.Money = MP.ReadUInt();
                                GameManager.OnRefresh(NetworkNews.Refresh_Alliance);
                                break;
                              case 15:
                                DataManager.Instance.RoleAttr.LordEquipBagSize = MP.ReadByte();
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1);
                                break;
                              case 16:
                                ArenaManager.Instance.m_ArenaCrystalPrize = MP.ReadUInt();
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_TreasureBox, 4);
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 9);
                                GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
                                break;
                              case 17:
                                ArenaManager instance1 = ArenaManager.Instance;
                                instance1.m_ArenaNewReportNum = MP.ReadByte();
                                instance1.m_ArenaPlace = MP.ReadUInt();
                                if (instance1.m_ArenaNewReportNum != (byte) 0)
                                {
                                  ArenaReportDataType arenaReportDataType = new ArenaReportDataType();
                                  arenaReportDataType.SimulatorVersion = 0U;
                                  if (instance1.m_ArenaReportData.Count == 20)
                                    instance1.m_ArenaReportData.RemoveAt(0);
                                  bool flag = false;
                                  if (instance1.RepoetUnReadCount > (byte) 0 && instance1.RepoetUnRead[0] == (byte) 0)
                                  {
                                    flag = true;
                                    --instance1.RepoetUnReadCount;
                                  }
                                  if (flag)
                                  {
                                    for (int index = 0; index < (int) instance1.RepoetUnReadCount && instance1.RepoetUnReadCount < (byte) 19; ++index)
                                      instance1.RepoetUnRead[index] = --instance1.RepoetUnRead[index + 1];
                                  }
                                  else
                                  {
                                    for (int index = 0; index < (int) instance1.RepoetUnReadCount && index < instance1.RepoetUnRead.Length; ++index)
                                      instance1.RepoetUnRead[index] = --instance1.RepoetUnRead[index];
                                  }
                                  if (!instance1.bArenaOpenGet)
                                  {
                                    instance1.RepoetUnRead[(int) instance1.RepoetUnReadCount] = (byte) instance1.m_ArenaReportData.Count;
                                    ++instance1.RepoetUnReadCount;
                                  }
                                  instance1.m_ArenaReportData.Add(arenaReportDataType);
                                }
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 5);
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena_Replay, 2);
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_TreasureBox, 5);
                                GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
                                break;
                              case 18:
                                DataManager.Instance.RoleAttr.TPP_Point = MP.ReadUInt();
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 6);
                                break;
                              case 19:
                                DataManager.Instance.RoleAttr.PaidCrystal = MP.ReadUInt();
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 7);
                                break;
                              case 20:
                                MallManager.Instance.BuyMonthTreasureTime = MP.ReadLong();
                                MallManager.Instance.LastGetMonthTreasurePrizeTime = MP.ReadLong();
                                GUIManager.Instance.UpdateUI(EGUIWindow.Door, 23);
                                break;
                              case 21:
                                ActivityManager.Instance.RecvKVKEventPoint((byte) 2, MP);
                                break;
                              case 22:
                                ActivityManager.Instance.RecvKVKEventPoint((byte) 0, MP);
                                break;
                              case 23:
                                ActivityManager.Instance.RecvKVKEventPoint((byte) 3, MP);
                                break;
                              case 24:
                                ActivityManager.Instance.bSpecialMonsterTreasureEvent = MP.ReadULong();
                                DataManager.msgBuffer[0] = (byte) 93;
                                GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
                                Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
                                if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
                                  menu.RefreshMainEff();
                                PetManager.Instance.bActFusioncutdown = (ActivityManager.Instance.bSpecialMonsterTreasureEvent & 16UL) > 0UL;
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetFusion, 3);
                                break;
                              case 25:
                                DataManager.Instance.AllianceMoneyBonusRate = MP.ReadUShort();
                                DataManager.Instance.AllianceMoneyBonusRate = (ushort) Mathf.Clamp((int) DataManager.Instance.AllianceMoneyBonusRate, 100, 500);
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_HelpSpeedup, 5);
                                GUIManager.Instance.UpdateUI(EGUIWindow.Door, 11);
                                break;
                              case 26:
                                DataManager instance2 = DataManager.Instance;
                                instance2.mDailyGift_Pic = MP.ReadUShort();
                                instance2.mDailyGift.BeginTime = MP.ReadLong();
                                instance2.mDailyGift.EndTime = MP.ReadLong();
                                instance2.mDailyGift.ItemData.ItemID = MP.ReadUShort();
                                instance2.mDailyGift.ItemData.Num = MP.ReadUShort();
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_TreasureBox, 9);
                                GUIManager.Instance.UpdateUI(EGUIWindow.Door, 23);
                                break;
                              case 27:
                                DataManager.StageDataController.RoleAttrLevelUp(MP, 24);
                                GameManager.OnRefresh();
                                GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
                                break;
                              case 28:
                                ArenaManager.Instance.m_ArenaClose_ActivityType = (EActivityType) ((int) MP.ReadByte() - 1);
                                ArenaManager.Instance.m_ArenaClose_CDTime = MP.ReadLong();
                                if (ArenaManager.Instance.m_ArenaClose_CDTime == 0L)
                                  ArenaManager.Instance.SendArena_Refresh_Target((byte) 2);
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 6);
                                break;
                              case 29:
                                DataManager.MissionDataManager.AllianceMissionBonusRate = MP.ReadUShort();
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, 32);
                                GUIManager.Instance.UpdateUI(EGUIWindow.Door, 24);
                                break;
                              case 30:
                                GUIManager.Instance.NPCCityBonusTime = MP.ReadLong();
                                GUIManager.Instance.UpdateUI(EGUIWindow.UIAlchemy, 7);
                                GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
                                break;
                              case 31:
                                DataManager.StageDataController.UpdateRoleTalentPoint(MP.ReadUShort());
                                break;
                              case 32:
                                ActivityManager.Instance.FederalActKingdomWonderID = MP.ReadByte();
                                ActivityManager.Instance.FederalHomeKingdomWonderID = MP.ReadByte();
                                PushManage.Instance.OrderEventBeginTime = MP.ReadLong();
                                ActivityManager.Instance.FederalActKingdomID = MP.ReadUShort();
                                break;
                              case 33:
                                ActivityManager.Instance.FederalFullEventTimeWonderID = MP.ReadByte();
                                break;
                              case 34:
                                ActivityManager.Instance.AW_SignUpAllianceID = MP.ReadUInt();
                                ActivityManager.Instance.AW_GetGift = MP.ReadByte();
                                ActivityManager.Instance.CheckAWShowHint();
                                break;
                              case 35:
                                ActivityManager.Instance.AllianceWarData.bAskRankPrize = false;
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity4, 2, 210);
                                UIAllianceWar_Rank.isDataReady = false;
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWar_Rank, 3);
                                break;
                              case 36:
                                MallManager instance3 = MallManager.Instance;
                                GUIManager instance4 = GUIManager.Instance;
                                uint fullGiftNowCrystal = instance3.FullGift_NowCrystal;
                                instance3.FullGift_NowCrystal = MP.ReadUInt();
                                instance3.FullGift_MaxCrystal = MP.ReadUInt();
                                instance3.FullGift_Deadline = MP.ReadLong();
                                bool flag1 = MP.ReadByte() != (byte) 0;
                                if (flag1)
                                {
                                  instance3.SetShowEffect(true);
                                  instance4.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17511U), (ushort) byte.MaxValue);
                                  instance4.UpdateUI(EGUIWindow.UI_Mall, 9);
                                }
                                if (instance3.FullGift_Deadline == 0L)
                                  instance3.ClearFullGift();
                                else if (instance3.bLoginFinish && !flag1 && instance3.FullGift_NowCrystal > fullGiftNowCrystal)
                                  instance4.UpdateUI(EGUIWindow.UI_Mall, 10, (int) instance3.FullGift_NowCrystal - (int) fullGiftNowCrystal);
                                instance4.UpdateUI(EGUIWindow.UI_Mall, 8);
                                instance4.UpdateUI(EGUIWindow.UI_Mall_FG, 1);
                                instance4.UpdateUI(EGUIWindow.UI_Mall_FG_Detail, 1);
                                break;
                              case 37:
                                ArenaManager.Instance.m_ArenaTodayChallenge = MP.ReadByte();
                                ArenaManager.Instance.m_ArenaExtraChallenge = MP.ReadByte();
                                GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 6);
                                break;
                              case 38:
                                DataManager.Instance.RoleAttr.Diamond = MP.ReadUInt();
                                GameManager.OnRefresh();
                                uint x = MP.ReadUInt();
                                CString cstring1 = StringManager.Instance.StaticString1024();
                                cstring1.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9991U));
                                cstring1.IntToFormat((long) x, bNumber: true);
                                cstring1.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12612U));
                                GUIManager.Instance.AddHUDMessage(cstring1.ToString(), (ushort) 35);
                                GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
                                GUIManager.Instance.m_SpeciallyEffect.mDiamondValue = x;
                                GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, SpeciallyEffect_Kind.Diamond, ItemID: (ushort) 0, EndTime: 2f);
                                break;
                              case 39:
                                DataManager.StageDataController.RoleAttrLevelUp(MP, 24);
                                CString cstring2 = StringManager.Instance.StaticString1024();
                                cstring2.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(12611U));
                                cstring2.IntToFormat((long) MP.ReadUShort());
                                cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12612U));
                                GUIManager.Instance.AddHUDMessage(cstring2.ToString(), (ushort) 35);
                                GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
                                GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, SpeciallyEffect_Kind.PetSkill_Morale, ItemID: (ushort) 0, EndTime: 2f);
                                break;
                            }
                            GameManager.OnRefresh(NetworkNews.Refresh_Attr);
                            return;
                          case Protocol._MSG_RESP_ROLE_NAME_CHECK:
                          case Protocol._MSG_RESP_ROLE_RENAME:
                            DataManager.Instance.RecvUserRename(MP);
                            return;
                          case Protocol._MSG_RESP_ROLE_PRIZEFLAG:
                            DataManager.Instance.RecvPrizeFlag(MP);
                            return;
                          case Protocol._MSG_RESP_STATISTIC:
                            DataManager.Instance.RecvLordStatistic(MP);
                            return;
                          case Protocol._MSG_RESP_PROFILE:
                            DataManager.Instance.RecvLordProfile(MP);
                            return;
                          case Protocol._MSG_RESP_BUFFINFO:
                            DataManager.Instance.RecvIBuffInfo(MP);
                            return;
                          case Protocol._MSG_RESP_BUFFCOMPLETE:
                            DataManager.Instance.RecvBuffComplete(MP);
                            return;
                          case Protocol._MSG_RESP_SEARCHPLAYER:
                            DataManager.Instance.RecvSearchPlayer(MP);
                            return;
                          case Protocol._MSG_RESP_DAILY_RESET:
                            DataManager.Instance.RecvDailyReset(MP);
                            return;
                          case Protocol._MSG_RESP_ONLINE_GIFT:
                            DataManager.Instance.RecvOnline_Gift(MP);
                            return;
                          case Protocol._MSG_RESP_CASTLE_STATUS:
                            byte num1 = MP.ReadByte();
                            LandWalkerManager.HappenAttack(MP.ReadLong(), num1 == (byte) 1);
                            return;
                          case Protocol._MSG_RESP_ANNOUNCEMENT_PUBLISHING:
                            GUIManager.Instance.RecvBackMessage(MP);
                            return;
                          case Protocol._MSG_RESP_PASSNEWBIE:
                            GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4834U), DataManager.Instance.mStringTable.GetStringByID(117U), DataManager.Instance.mStringTable.GetStringByID(4836U));
                            return;
                          case Protocol._MSG_RESP_COMPENSATION_NOTICE:
                            DataManager.Instance.RecvCompensation_Notice(MP);
                            return;
                          case Protocol._MSG_RESP_GET_COMPENSATION:
                            DataManager.Instance.RecvGet_Compensation(MP);
                            return;
                          case Protocol._MSG_RESP_ANNOUNCEMENT_DELETE:
                            GUIManager.Instance.RecvBackMessageDelete(MP);
                            return;
                          case Protocol._MSG_RESP_ACC_ADDICTIONTIME:
                            DataManager.Instance.RoleAttr.AddictionTime = MP.ReadLong();
                            AntiAddictive.Instance.SetCumulativeTime(DataManager.Instance.RoleAttr.AddictionTime);
                            AntiAddictive.Instance.Start(IGGGameSDK.Instance.GetAddictedCheckNoticeSW(), IGGGameSDK.Instance.GetAddictedCheckLimitLoginSW(), IGGGameSDK.Instance.m_RealNameState, IGGGameSDK.Instance.m_AgeState);
                            return;
                          case Protocol._MSG_RESP_PUSHBACK_PRIZE:
                            MallManager.Instance.Recv_PUSHBACK_PRIZE(MP);
                            return;
                          default:
                            switch (protocol)
                            {
                              case Protocol._MSG_RESP_LORD_BEINGCAPTIVE:
                                JailManage.MSG_RESP_LORD_BEINGCAPTIVE(MP);
                                return;
                              case Protocol._MSG_RESP_UPDATE_CAPTIVE:
                                JailManage.MSG_RESP_UPDATE_CAPTIVE(MP);
                                return;
                              case Protocol._MSG_RESP_CHANGE_BOUNTY:
                                JailManage.MSG_RESP_CHANGE_BOUNTY(MP);
                                return;
                              case Protocol._MSG_RESP_PAY_RANSOM:
                                JailManage.MSG_RESP_PAY_RANSOM(MP);
                                return;
                              case Protocol._MSG_RESP_LORD_BEINGRELEASED:
                                JailManage.MSG_RESP_LORD_BEINGRELEASED(MP);
                                return;
                              case Protocol._MSG_RESP_LORD_BEINGEXECUTED:
                                JailManage.MSG_RESP_LORD_BEINGEXECUTED(MP);
                                return;
                              case Protocol._MSG_RESP_LORD_HOME:
                                JailManage.MSG_RESP_LORD_HOME(MP);
                                return;
                              case Protocol._MSG_RESP_LORD_REVIVE:
                                JailManage.MSG_RESP_LORD_REVIVE(MP);
                                return;
                              case Protocol._MSG_RESP_PRISONER_NUM_AND_HIGHESTLEVEL:
                                JailManage.MSG_RESP_PRISONER_NUM_AND_HIGHESTLEVEL(MP);
                                return;
                              case Protocol._MSG_RESP_PRISONER_LIST:
                                JailManage.MSG_RESP_PRISONER_LIST(MP);
                                return;
                              case Protocol._MSG_RESP_ADD_PRISONER:
                                JailManage.MSG_RESP_ADD_PRISONER(MP);
                                return;
                              case Protocol._MSG_RESP_UPDATE_PRISONER:
                                JailManage.MSG_RESP_UPDATE_PRISONER(MP);
                                return;
                              case Protocol._MSG_RESP_PRISONER_ESCAPED:
                                JailManage.MSG_RESP_PRISONER_ESCAPED(MP);
                                return;
                              case Protocol._MSG_RESP_PRISONER_BAILED:
                                JailManage.MSG_RESP_PRISONER_BAILED(MP);
                                return;
                              case Protocol._MSG_RESP_RELEASE_ALL_PRISONER:
                                JailManage.MSG_RESP_RELEASE_ALL_PRISONER(MP);
                                return;
                              case Protocol._MSG_RESP_CHANGE_RANSOM:
                                JailManage.MSG_RESP_CHANGE_RANSOM(MP);
                                return;
                              case Protocol._MSG_RESP_RELEASE_PRISONER:
                                JailManage.MSG_RESP_RELEASE_PRISONER(MP);
                                return;
                              case Protocol._MSG_RESP_EXECUTE_PRISONER:
                                JailManage.MSG_RESP_EXECUTE_PRISONER(MP);
                                return;
                              case Protocol._MSG_RESP_MAP_PRISONER_LIST:
                                JailManage.MSG_RESP_MAP_PRISONER_LIST(MP);
                                return;
                              case Protocol._MSG_RESP_ALTAR_BUFFTIME:
                                DataManager.Instance.RecvAltarBuffTime(MP);
                                return;
                              case Protocol._MSG_RESP_ALTAR_BUFFCLOSED:
                                DataManager.Instance.RecvAltarBuffClose();
                                return;
                              case Protocol._MSG_RESP_CLAIMBOUNTY:
                                DataManager.Instance.Resource[4].Stock = MP.ReadUInt();
                                GameManager.OnRefresh(NetworkNews.Refresh_Resource);
                                return;
                              case Protocol._MSG_PRISON_RESP_PRISONER_POISONEFFECT:
                                JailManage.MSG_PRISON_RESP_PRISONER_POISONEFFECT(MP);
                                return;
                              case Protocol._MSG_RESP_LORD_RELEASED_TIME:
                                JailManage.RecvLordReleasedTime(MP);
                                return;
                              default:
                                switch (protocol)
                                {
                                  case Protocol._MSG_RESP_WALLINFO:
                                    DataManager.Instance.RecvWallInfo(MP);
                                    return;
                                  case Protocol._MSG_RESP_TRAPINFO:
                                    DataManager.Instance.RecvTrapInfo(MP);
                                    return;
                                  case Protocol._MSG_RESP_TRAPCONSTEVENT:
                                    DataManager.Instance.RecvTrapConstevent(MP);
                                    return;
                                  case Protocol._MSG_RESP_TRAPREPAIRINFO:
                                    DataManager.Instance.RecvTrapRepairInfo(MP);
                                    return;
                                  case Protocol._MSG_RESP_TRAPCONSTRUCT:
                                    DataManager.Instance.RecvTrapConstruct(MP);
                                    return;
                                  case Protocol._MSG_RESP_TRAPCOMPLETE:
                                    DataManager.Instance.RecvTrapComplete(MP);
                                    return;
                                  case Protocol._MSG_RESP_CANCELTRAPCONSTRUCT:
                                    DataManager.Instance.RecvCancelTrapConstruct(MP);
                                    return;
                                  case Protocol._MSG_RESP_TRAPDESTROY:
                                    DataManager.Instance.RecvTrapDestroy(MP);
                                    return;
                                  case Protocol._MSG_RESP_INSTANTTRAPCONSTRUCT:
                                    DataManager.Instance.RecvInstantTrapConstruct(MP);
                                    return;
                                  case Protocol._MSG_RESP_FINISHTRAPCONSTRCT:
                                    DataManager.Instance.RecvFinishTrapConstrct(MP);
                                    return;
                                  case Protocol._MSG_RESP_REPAIRTRAP:
                                    DataManager.Instance.RecvRePairTrap(MP);
                                    return;
                                  case Protocol._MSG_RESP_REPAIRTRAPCOMPLETE:
                                    DataManager.Instance.RecvRepairTrapComplete(MP);
                                    return;
                                  case Protocol._MSG_RESP_CANCELREPAIRTRAP:
                                    DataManager.Instance.RecvCancelRepairTrap(MP);
                                    return;
                                  case Protocol._MSG_RESP_INSTANTREPAIRTRAP:
                                    DataManager.Instance.RecvInstantRepairTrap(MP);
                                    return;
                                  case Protocol._MSG_RESP_FINISHREPAIRTRAP:
                                    DataManager.Instance.RecvFinishRepairTrap(MP);
                                    return;
                                  case Protocol._MSG_RESP_WALLBEINGATTACK:
                                    DataManager.Instance.RecvWallBeingAttack(MP);
                                    return;
                                  case Protocol._MSG_RESP_DEF_HEROINFO:
                                    DataManager.Instance.RecvDefendersID(MP);
                                    return;
                                  case Protocol._MSG_RESP_INSTANTWALLREPAIR:
                                    DataManager.Instance.RecvInstantWallRepair(MP);
                                    return;
                                  case Protocol._MSG_RESP_GIVEUP_TRAP_REPAIR:
                                    DataManager.Instance.RecvGiveUpTrap(MP);
                                    return;
                                  default:
                                    switch (protocol)
                                    {
                                      case Protocol._MSG_RESP_ALLIANCEWAR_MEMBERLIST_BEGIN:
                                        ActivityManager.Instance.AllianceWarMgr.RecvAllianceWarMemberListBegin(MP);
                                        return;
                                      case Protocol._MSG_RESP_ALLIANCEWAR_MEMBERLIST_LIST:
                                        ActivityManager.Instance.AllianceWarMgr.RecvAllianceWarMemberList(MP);
                                        return;
                                      case Protocol._MSG_RESP_UPDATE_ALLIANCEWAR_MEMBERLIST:
                                        ActivityManager.Instance.AllianceWarMgr.RecvUpdateAllianceWarMemberList(MP);
                                        return;
                                      case Protocol._MSG_RESP_INSERT_ALLIANCEWAR_MEMBERLIST:
                                        ActivityManager.Instance.AllianceWarMgr.RecvInsertAllianceWarMemberList(MP);
                                        return;
                                      case Protocol._MSG_RESP_SIGNUP_ALLIANCEWAR:
                                        ActivityManager.Instance.AllianceWarMgr.Recv_MSG_RESP_SIGNUP_ALLIANCEWAR(MP);
                                        return;
                                      case Protocol._MSG_RESP_ALLIANCEWAR_MEMBER_DATA:
                                        ActivityManager.Instance.AllianceWarMgr.Recv_MSG_RESP_ALLIANCEWAR_MEMBER_DATA(MP);
                                        return;
                                      case Protocol._MSG_RESP_ALLIANCEWAR_REPLAY_FAILED:
                                        ActivityManager.Instance.AllianceWarMgr.Recv_MSG_RESP_ALLIANCEWAR_REPLAY_FAILED(MP);
                                        return;
                                      case Protocol._MSG_RESP_ALLIANCEWAR_LIVE_LEFTSIDE_LIST:
                                      case Protocol._MSG_RESP_ALLIANCEWAR_LIVE_RIGHTSIDE_LIST:
                                      case Protocol._MSG_RESP_ALLIANCEWAR_LIVE_WAR_DETAIL:
                                      case Protocol._MSG_RESP_ALLIANCEWAR_REPLAY_LEFTSIDE_LIST:
                                      case Protocol._MSG_RESP_ALLIANCEWAR_REPLAY_RIGHTSIDE_LIST:
                                      case Protocol._MSG_RESP_ALLIANCEWAR_REPLAY_WAR_DETAIL:
                                        AllianceBattle.RecvAllianceBattleStation(MP);
                                        return;
                                      case Protocol._MSG_RESP_ALLIANCEWAR_MATCH_PLAYERDATA:
                                        ActivityManager.Instance.AllianceWarMgr.Recv_MSG_RESP_ALLIANCEWAR_MATCH_PLAYERDATA(MP);
                                        return;
                                      case Protocol._MSG_RESP_ALLIANCEWAR_COMBAT_REPORT:
                                        ActivityManager.Instance.AllianceWarMgr.Recv_MSG_RESP_ALLIANCEWAR_COMBAT_REPORT(MP);
                                        return;
                                      case Protocol._MSG_RESP_ALLIANCEWAR_OPENGETPRIZEUI:
                                        UIAllianceWar_Rank.DispatchOpen(MP);
                                        return;
                                      case Protocol._MSG_RESP_ALLIANCEWAR_GETPRIZE:
                                        UIAllianceWar_Rank.DispatchReward(MP);
                                        return;
                                      case Protocol._MSG_RESP_ALLIANCEWAR_RANK:
                                        LeaderBoardManager.Instance.Recv_MSG_RESP_ALLIANCEWAR_RANK(MP);
                                        return;
                                      case Protocol._MSG_RESP_ALLIANCEWAR_RANKPRIZE:
                                        ActivityManager.Instance.Recv_RESP_ALLIANCEWAR_RANKPRIZE(MP);
                                        return;
                                      case Protocol._MSG_RESP_AWS_SCHEDULE:
                                        UI_AlliWarSchedule.RespSchedule(MP);
                                        return;
                                      default:
                                        switch (protocol)
                                        {
                                          case Protocol._MSG_RESP_BUILDINGINFO:
                                            GUIManager.Instance.BuildingData.RecvAllBuildData(MP);
                                            return;
                                          case Protocol._MSG_RESP_BUILDINGEVENT:
                                            GUIManager.Instance.BuildingData.RecvBuildingQueue(MP);
                                            return;
                                          case Protocol._MSG_RESP_BUILDBEGIN:
                                            GUIManager.Instance.BuildingData.RecvUpdateBuildData(MP);
                                            return;
                                          case Protocol._MSG_RESP_BUILDCOMPLETE:
                                            GUIManager.Instance.BuildingData.RecvBuildComplete(MP);
                                            return;
                                          case Protocol._MSG_RESP_BUILDCANCEL:
                                            GUIManager.Instance.BuildingData.RecvBuildCancel(MP);
                                            return;
                                          case Protocol._MSG_RESP_INSTANTBUILD:
                                            GUIManager.Instance.BuildingData.RecvBuildCompleteImmediate(MP);
                                            return;
                                          case Protocol._MSG_RESP_FINISHBUILD:
                                            GUIManager.Instance.BuildingData.RecvBuildFinish(MP);
                                            return;
                                          case Protocol._MSG_RESP_BUILDINGERROR:
                                            GUIManager.Instance.BuildingData.RecvBuildErrMsg(MP);
                                            return;
                                          case Protocol._MSG_RESP_RESOURCEINFO:
                                            GUIManager.Instance.BuildingData.RecvResources(MP);
                                            return;
                                          case Protocol._MSG_RESP_UPDATE_RESOURCEINFO:
                                            GUIManager.Instance.BuildingData.RecvResourcesUpdate(MP);
                                            return;
                                          case Protocol._MSG_RESP_UPDATE_RESOURCEAMOUNT:
                                            DataManager.Instance.RecvRefreshResources(MP);
                                            return;
                                          case Protocol._MSG_RESP_DECONSTRBEGIN:
                                            GUIManager.Instance.BuildingData.RecvBuildDismantle(MP);
                                            return;
                                          case Protocol._MSG_RESP_DECONSTRCOMPLETE:
                                            GUIManager.Instance.BuildingData.RecvBuildDismantleComplete(MP);
                                            return;
                                          case Protocol._MSG_RESP_DECONSTRCANCEL:
                                            GUIManager.Instance.BuildingData.RecvBuildDismantleCancel(MP);
                                            return;
                                          case Protocol._MSG_RESP_INSTANTDECONSTR:
                                            GUIManager.Instance.BuildingData.RecvBuildDismantleCompleteImmediate(MP);
                                            return;
                                          case Protocol._MSG_RESP_FINISHDECONSTR:
                                            GUIManager.Instance.BuildingData.RecvBuildDismantleCompleteFinish(MP);
                                            return;
                                          case Protocol._MSG_RESP_UPDATE_INJURE:
                                            DataManager.Instance.RecvUpdate_Injure(MP);
                                            return;
                                          default:
                                            switch (protocol)
                                            {
                                              case Protocol._MSG_RESP_BOOKMARKINFO:
                                                DataManager.Instance.RoleBookMark.RecvBookMarkInfo(MP);
                                                return;
                                              case Protocol._MSG_RESP_BOOKMARKLIST:
                                                DataManager.Instance.RoleBookMark.RecvBookMarkList(MP);
                                                return;
                                              case Protocol._MSG_RESP_ADDBOOKMARK:
                                                DataManager.Instance.RoleBookMark.RecvBookMarkAdd(MP);
                                                return;
                                              case Protocol._MSG_RESP_DELBOOKMARK:
                                                DataManager.Instance.RoleBookMark.RecvBookMarkDel(MP);
                                                return;
                                              case Protocol._MSG_RESP_MODIFYBOOKMARK:
                                                DataManager.Instance.RoleBookMark.RecvBookMarkModify(MP);
                                                return;
                                              case Protocol._MSG_RESP_MISSIONINFO:
                                                DataManager.MissionDataManager.RecvTimeMissionInfo(MP);
                                                return;
                                              case Protocol._MSG_RESP_MISSION_START:
                                                DataManager.MissionDataManager.RecvTimeMissionStart(MP);
                                                return;
                                              case Protocol._MSG_RESP_MISSION_BOOST:
                                                DataManager.MissionDataManager.RecvTimeMissionCompleteInst(MP);
                                                return;
                                              case Protocol._MSG_RESP_MISSION_FINISH:
                                                DataManager.MissionDataManager.RecvTimeMissionReward(MP);
                                                return;
                                              case Protocol._MSG_RESP_MISSION_COMPLETE:
                                                DataManager.MissionDataManager.RecvMissionComplete(MP);
                                                return;
                                              case Protocol._MSG_RESP_MISSION_FLAG:
                                                DataManager.MissionDataManager.RecvMissionFlag(MP);
                                                return;
                                              case Protocol._MSG_RESP_MISSION_MARK:
                                                DataManager.MissionDataManager.RecvMissionMark(MP);
                                                return;
                                              case Protocol._MSG_RESP_MISSION_MARKSET:
                                                DataManager.MissionDataManager.RecvMissionmarkUpdate(MP);
                                                return;
                                              case Protocol._MSG_RESP_MISSION_VIP:
                                                DataManager.MissionDataManager.RecvVipMission(MP);
                                                return;
                                              case Protocol._MSG_RESP_MISSION_VIP_SPEEDUP:
                                                DataManager.MissionDataManager.RecvVipMissionImmed(MP);
                                                return;
                                              default:
                                                switch (protocol)
                                                {
                                                  case Protocol._MSG_RESP_TALENTINFO:
                                                    DataManager.Instance.RecvTalentInfo(MP);
                                                    return;
                                                  case Protocol._MSG_RESP_TALENT_LEVEL_ADD:
                                                    DataManager.Instance.RecvTalentAdd(MP);
                                                    return;
                                                  case Protocol._MSG_RESP_ONLORDEQUIP_INFO:
                                                    LordEquipData.Recv_MSG_RESP_ONLORDEQUIP_INFO(MP);
                                                    return;
                                                  case Protocol._MSG_RESP_PUTON_TAKEOFF_LORDEQUIP:
                                                    LordEquipData.Instance().Recv_MSG_RESP_PUTON_TAKEOFF_LORDEQUIP(MP);
                                                    return;
                                                  case Protocol._MSG_RESP_SYN_MATGEM:
                                                    LordEquipData.Instance().Recv_MSG_LORD_RESPSYN_MATGEM(MP);
                                                    return;
                                                  case Protocol._MSG_RESP_SYN_LORDEQUIP:
                                                    LordEquipData.Instance().Recv_MSG_RESP_SYN_LORDEQUIP(MP);
                                                    return;
                                                  case Protocol._MSG_RESP_SYN_LORDEQUIP_EVENT_CANCEL:
                                                    LordEquipData.Instance().Recv_MSG_RESP_SYN_LORDEQUIP_EVENT_CANCEL(MP);
                                                    return;
                                                  case Protocol._MSG_RESP_SYN_LORDEQUIP_EVENT_COMPLETE:
                                                    LordEquipData.Instance().Recv_MSG_RESP_SYN_LORDEQUIP_EVENT_COMPLETE(MP);
                                                    return;
                                                  case Protocol._MSG_RESP_SYN_LORDEQUIP_INSTANT:
                                                    LordEquipData.Recv_MSG_RESP_SYN_LORDEQUIP_INSTANT(MP);
                                                    return;
                                                  case Protocol._MSG_RESP_FINISH_SYN_LORDEQUIP_EVENT:
                                                    LordEquipData.Recv_MSG_RESP_FINISH_SYN_LORDEQUIP_EVENT(MP);
                                                    return;
                                                  case Protocol._MSG_RESP_DECOMPOSE_LORDEQUIP:
                                                    LordEquipData.Instance().Recv_MSG_RESP_DECOMPOSE_LORDEQUIP(MP);
                                                    return;
                                                  case Protocol._MSG_RESP_INLAY_LORDEQUIP:
                                                    LordEquipData.Instance().Recv_MSG_RESP_INLAY_LORDEQUIP(MP);
                                                    return;
                                                  case Protocol._MSG_RESP_FREE_TAKEOFF_GEM:
                                                    LordEquipData.Instance().Recv_MSG_RESP_FREE_TAKEOFF_GEM(MP);
                                                    return;
                                                  case Protocol._MSG_RESP_DECOMPOSE_MATGEM:
                                                    LordEquipData.Instance().Recv_MSG_LORD_RESPDECOMPOSE_MATGEM(MP);
                                                    return;
                                                  default:
                                                    switch (protocol)
                                                    {
                                                      case Protocol._MSG_RESP_SCOUT_NPC_REPORTINFO:
                                                      case Protocol._MSG_RESP_NPC_COMBATREPORTINFO:
                                                        goto label_182;
                                                      case Protocol._MSG_RESP_COMBATREPLAY_NPCCITY:
                                                        GUIManager.Instance.HideUILock(EUILock.Mailing_Battle);
                                                        WarManager.RecvStartNpcWar(MP);
                                                        return;
                                                      case Protocol._MSG_RESP_COMBATDETAIL_LEADERDATA_NPCCITY:
                                                        DataManager.Instance.NPCCombatDetail_Leaderdata(MP);
                                                        return;
                                                      case Protocol._MSG_RESP_COMBATDETAIL_PLAYERDATA_NPCCITY:
                                                        goto label_161;
                                                      case Protocol._MSG_RESP_COMBATDETAIL_INJUREDATA_NPCCITY:
                                                        goto label_162;
                                                      case Protocol._MSG_RESP_LIVECOMBATREPLAYMETA_NPCCITY:
                                                        GUIManager.Instance.RecvNPCCityMessage(MP);
                                                        return;
                                                      case Protocol._MSG_RESP_LIVECOMBATREPLAY_NPCCITY:
                                                        WarManager.RecvFastStartNpcWar(MP);
                                                        return;
                                                      case Protocol._MSG_RESP_BROCAST_NPC_WAR_BEGIN:
                                                        GUIManager.Instance.Recv_BROCAST_NPC_WAR_BEGIN(MP);
                                                        return;
                                                      case Protocol._MSG_RESP_NPC_RALLY_DETAIL_FAILED:
                                                        GUIManager.Instance.Recv_NPC_RALLY_DETAIL_FAILED(MP);
                                                        return;
                                                      case Protocol._MSG_RESP_NPC_WARHALL_UPDATE_LISTELE:
                                                        DataManager.Instance.RecvNPCWallHallData(MP);
                                                        return;
                                                      case Protocol._MSG_RESP_NPC_WARHALL_INIT_LISTDETAIL:
                                                        DataManager.Instance.RecvNPCWallHallDetail(MP);
                                                        return;
                                                      case Protocol._MSG_RESP_NPC_REWARDSAVE:
                                                        GUIManager.Instance.Recv_NPC_REWARDSAVE(MP);
                                                        return;
                                                      case Protocol._MSG_RESP_NPC_START_REWARD:
                                                        GUIManager.Instance.Recv_NPC_START_REWARD(MP);
                                                        return;
                                                      case Protocol._MSG_RESP_NPC_GET_REWARD:
                                                        GUIManager.Instance.Recv_NPC_GET_REWARD(MP);
                                                        return;
                                                      case Protocol._MSG_RESP_NPC_DELETE_REWARD:
                                                        GUIManager.Instance.Recv_NPC_DELETE_REWARD(MP);
                                                        return;
                                                      case Protocol._MSG_RESP_NPC_UPDATEREWARD:
                                                        GUIManager.Instance.Recv_NPC_UPDATEREWARD(MP);
                                                        return;
                                                      case Protocol._MSG_RESP_NPCCITY_RALLY_ATKMARCH:
                                                        DataManager.Instance.Recv_NPCCITY_RALLY_ATKMARCH(MP);
                                                        return;
                                                      default:
                                                        switch (protocol)
                                                        {
                                                          case Protocol._MSG_RESP_ITEMINFO:
                                                            DataManager.Instance.RecvItemInfo(MP);
                                                            return;
                                                          case Protocol._MSG_RESP_SELLITEM:
                                                            DataManager.Instance.RecvSellItem(MP);
                                                            return;
                                                          case Protocol._MSG_RESP_SYNITEM:
                                                            DataManager.Instance.RecvSynthesis(MP);
                                                            return;
                                                          case Protocol._MSG_RESP_USEITEM:
                                                            DataManager.Instance.RecvUseItem(MP);
                                                            return;
                                                          case Protocol._MSG_RESP_BUYITEM:
                                                            DataManager.Instance.RecvBuyItem(MP);
                                                            return;
                                                          case Protocol._MSG_RESP_UPDATEITEM:
                                                            DataManager.Instance.RecvUpdateItem(MP);
                                                            return;
                                                          case Protocol._MSG_RESP_ITEMMAT:
                                                            LordEquipData.Instance().Recv_MSG_RESP_ITEMMAT(MP);
                                                            return;
                                                          case Protocol._MSG_RESP_LORDEQUIP:
                                                            LordEquipData.Instance().Recv_MSG_RESP_LORDEQUIP(MP);
                                                            return;
                                                          case Protocol._MSG_RESP_ITEMGEM:
                                                            LordEquipData.Instance().Recv_MSG_RESP_Gem(MP);
                                                            return;
                                                          case Protocol._MSG_RESP_GIFT:
                                                            DataManager.Instance.RecvBuySendItem(MP);
                                                            return;
                                                          case Protocol._MSG_GIFT_RECIVED:
                                                            DataManager.Instance.RecvBuySendItemReserved(MP);
                                                            return;
                                                          case Protocol._MSG_RESP_LORDEQUIP_EX:
                                                            LordEquipData.Instance().Recv_MSG_RESP_LORDEQUIP_EX(MP);
                                                            return;
                                                          default:
                                                            switch (protocol)
                                                            {
                                                              case Protocol._MSG_RESP_AMNESTY:
                                                                DataManager.Instance.RecvAmnesty(MP);
                                                                return;
                                                              case Protocol._MSG_RESP_MODIFY_KINGDOM_BULLITIN:
                                                                DataManager.Instance.RecvModifyKingdomBullitin(MP);
                                                                return;
                                                              case Protocol._MSG_RESP_KINGDOM_BULLITIN:
                                                                DataManager.Instance.RecvKingdomBullitin(MP);
                                                                return;
                                                              case Protocol._MSG_RESP_NEW_KINGDOM_BULLITIN:
                                                                DataManager.Instance.RecvNewKingdomBullitin(MP);
                                                                return;
                                                              case Protocol._MSG_RESP_MAIL_BULLITIN:
                                                                DataManager.Instance.RecvMailBullitin(MP);
                                                                return;
                                                              case Protocol._MSG_RESP_KINGDOM_TITLE_CHANGE:
                                                                TitleManager.Instance.Recv_KingdomTitle_Change(MP);
                                                                return;
                                                              case Protocol._MSG_RESP_KINGDOM_TITLE_REMOVE:
                                                                TitleManager.Instance.Recv_KingdomTitle_Remove(MP);
                                                                return;
                                                              case Protocol._MSG_RESP_KINGDOM_TITLE_LIST:
                                                              case Protocol._MSG_RESP_HOMEKINGDOM_TITLE_LIST:
                                                                TitleManager.Instance.Recv_KingdomTitle_List(MP);
                                                                return;
                                                              case Protocol._MSG_RESP_GET_KINGDOM_TITLE:
                                                                TitleManager.Instance.Recv_KingdomTitle_Get(MP);
                                                                return;
                                                              case Protocol._MSG_RESP_KING_GIFT:
                                                                DataManager.Instance.KingGift.RecvKingGift(MP);
                                                                return;
                                                              case Protocol._MSG_RESP_KING_GIFT_RECIVED:
                                                                DataManager.Instance.KingGift.RecvKingGiftRecived(MP);
                                                                return;
                                                              case Protocol._MSG_RESP_KINGDOM_BUFF_CD:
                                                                DataManager.Instance.KingCoolEndTime = MP.ReadLong();
                                                                return;
                                                              default:
                                                                switch (protocol)
                                                                {
                                                                  case Protocol._MSG_RESP_NOBILITY_TITLE_CHANGE:
                                                                    TitleManager.Instance.Recv_NobilityTitle_Change(MP);
                                                                    return;
                                                                  case Protocol._MSG_RESP_NOBILITY_TITLE_REMOVE:
                                                                    TitleManager.Instance.Recv_NobilityTitle_Remove(MP);
                                                                    return;
                                                                  case Protocol._MSG_RESP_NOBILITY_TITLE_LIST:
                                                                    TitleManager.Instance.Recv_NobilityTitle_List(MP);
                                                                    return;
                                                                  case Protocol._MSG_RESP_GET_NOBILITY_TITLE:
                                                                    TitleManager.Instance.Recv_NobilityTitle_Get(MP);
                                                                    return;
                                                                  case Protocol._MSG_RESP_FEDERAL_RANKDATA:
                                                                    LeaderBoardManager.Instance.Recv_MSG_RESP_Nobile_RANKDATA(MP);
                                                                    return;
                                                                  case Protocol._MSG_RESP_FEDERAL_HISTORYKINGDATA:
                                                                    LeaderBoardManager.Instance.Recv_MSG_RESP_FEDERAL_HISTORYKINGDATA(MP);
                                                                    return;
                                                                  case Protocol._MSG_RESP_FEDERAL_ORDERLIST:
                                                                    ActivityManager.Instance.Recv_FEDERAL_ORDERLIST(MP);
                                                                    return;
                                                                  case Protocol._MSG_RESP_FEDERAL_UPDATE_ORDERLIST:
                                                                    ActivityManager.Instance.Recv_FEDERAL_UPDATE_ORDERLIST(MP);
                                                                    return;
                                                                  case Protocol._MSG_RESP_FEDERAL_ORDERDETAIL:
                                                                    ActivityManager.Instance.Recv_FEDERAL_ORDERDETAIL(MP);
                                                                    return;
                                                                  case Protocol._MSG_RESP_FEDERAL_PRIZE:
                                                                    ActivityManager.Instance.Recv_ACTIVITY_MSG_RESP_FEDERAL_PRIZE(MP);
                                                                    return;
                                                                  case Protocol._MSG_RESP_FEDERAL_ORDERKINGDOMS:
                                                                    ActivityManager.Instance.Recv_FEDERAL_ORDERKINGDOMS(MP);
                                                                    return;
                                                                  case Protocol._MSG_RESP_FEDERAL_KINGKINGDOMS:
                                                                    ActivityManager.Instance.Recv_RESP_FEDERAL_KINGKINGDOMS(MP);
                                                                    return;
                                                                  case Protocol._MSG_FEDERAL_RESETEVENT:
                                                                    ActivityManager.Instance.Recv_FEDERAL_RESETEVENT(MP);
                                                                    return;
                                                                  default:
                                                                    switch (protocol)
                                                                    {
                                                                      case Protocol._MSG_RESP_TREASURE_LIST:
                                                                        MallManager.Instance.RecvMall_List(MP);
                                                                        return;
                                                                      case Protocol._MSG_RESP_TREASURE_INFO:
                                                                        MallManager.Instance.RecvMall_Info(MP);
                                                                        return;
                                                                      case Protocol._MSG_RESP_TREASURE_COMBOBOX:
                                                                        MallManager.Instance.RecvMall_Combobox(MP);
                                                                        return;
                                                                      case Protocol._MSG_RESP_TREASURE_PREBUY_CHECK:
                                                                        MallManager.Instance.RecvMall_Check(MP);
                                                                        return;
                                                                      case Protocol._MSG_TREASURE_UPDATELIST:
                                                                        MallManager.Instance.RecvMall_UpdateList(MP);
                                                                        return;
                                                                      case Protocol._MSG_RESP_TREASURE_MONTHPRIZE_INFO:
                                                                        MallManager.Instance.RecvTreasure_Monthprize_Info(MP);
                                                                        return;
                                                                      case Protocol._MSG_RESP_TREASURE_GET_MONTHPRIZE:
                                                                        MallManager.Instance.RecvTreasure_Get_Monthprize(MP);
                                                                        return;
                                                                      case Protocol._MSG_RESP_SPTREASURE_PREBUY_CHECK:
                                                                        MallManager.Instance.Recv_SPTREASURE_PREBUY_CHECK(MP);
                                                                        return;
                                                                      case Protocol._MSG_RESP_TREASUREBACK_PRIZEINFO:
                                                                        MallManager.Instance.Recv_TREASUREBACK_PRIZEINFO(MP);
                                                                        return;
                                                                      case Protocol._MSG_RESP_TREASUREBACK_RCVPRIZE:
                                                                        MallManager.Instance.Recv_TREASUREBACK_RCVPRIZE(MP);
                                                                        return;
                                                                      default:
                                                                        switch (protocol)
                                                                        {
                                                                          case Protocol._MSG_RESP_ARENA_INFO:
                                                                            ArenaManager.Instance.RecvArena_Info(MP);
                                                                            return;
                                                                          case Protocol._MSG_RESP_ARENA_REPORT:
                                                                            ArenaManager.Instance.RecvArena_Report(MP);
                                                                            return;
                                                                          case Protocol._MSG_RESP_ARENA_REFRESH_TARGET:
                                                                            ArenaManager.Instance.RecvArena_Refresh_Target(MP);
                                                                            return;
                                                                          case Protocol._MSG_RESP_ARENA_SET_DEFHERO:
                                                                            ArenaManager.Instance.RecvArena_Set_DefHero(MP);
                                                                            return;
                                                                          case Protocol._MSG_RESP_ARENA_CHALLENGE:
                                                                            ArenaManager.Instance.RecvArena_Challenge(MP);
                                                                            return;
                                                                          case Protocol._MSG_RESP_ARENA_RESET_TODAYCHALLENGE:
                                                                            ArenaManager.Instance.RecvArena_ReSet_Todaychallenge(MP);
                                                                            return;
                                                                          case Protocol._MSG_RESP_ARENA_RESET_CHALLENGE_CD:
                                                                            ArenaManager.Instance.RecvArena_ReSet_Challenge_CD(MP);
                                                                            return;
                                                                          case Protocol._MSG_RESP_ARENA_GET_PRIZE:
                                                                            ArenaManager.Instance.RecvArena_Arena_GetPrize(MP);
                                                                            return;
                                                                          case Protocol._MSG_RESP_ARENA_UPDATE_TOPIC:
                                                                            ArenaManager.Instance.RecvArena_Update_Topic(MP);
                                                                            return;
                                                                          case Protocol._MSG_RESP_ARENA_UPDATE_SINGLE_TARGET:
                                                                            ArenaManager.Instance.RecvArena_Update_Single_target(MP);
                                                                            return;
                                                                          default:
                                                                            switch (protocol)
                                                                            {
                                                                              case Protocol._MSG_RESP_FB_MISSION_INFO:
                                                                                DataManager.FBMissionDataManager.RecvFBMissionInfo(MP);
                                                                                return;
                                                                              case Protocol._MSG_RESP_FB_MISSION_START:
                                                                                DataManager.FBMissionDataManager.RecvFBMissionStart(MP);
                                                                                return;
                                                                              case Protocol._MSG_RESP_FB_GET_AWARD:
                                                                                DataManager.FBMissionDataManager.RecvFBGetReward(MP);
                                                                                return;
                                                                              case Protocol._MSG_UPDATE_FB_MISSION_PROGRESS:
                                                                                DataManager.FBMissionDataManager.UpdateFBMissionProGress(MP);
                                                                                return;
                                                                              case Protocol._MSG_UPDATE_FB_MISSION_AWARD:
                                                                                DataManager.FBMissionDataManager.UpdateMissionReward(MP);
                                                                                return;
                                                                              case Protocol._MSG_UPDATE_FB_MISSION_GOAL_TO_C:
                                                                                DataManager.FBMissionDataManager.UpdateMissionGoals(MP);
                                                                                return;
                                                                              case Protocol._MSG_RESP_BINDING_PLATFORM:
                                                                                SocialManager.Instance.Recv_RESP_BINDING_PLATFORM(MP);
                                                                                return;
                                                                              case Protocol._MSG_RESP_SOCIAL_DATA:
                                                                                DataManager.FBMissionDataManager.RecvSocialData(MP);
                                                                                return;
                                                                              case Protocol._MSG_RESP_FRIEND_USER_INFO:
                                                                                DataManager.FBMissionDataManager.RespFriendSocialInfo(MP);
                                                                                return;
                                                                              case Protocol._MSG_UPDATE_FRIEND_NAME:
                                                                                DataManager.FBMissionDataManager.UpdateFriendName(MP);
                                                                                return;
                                                                              case Protocol._MSG_RESP_SOCIAL_ENABLE:
                                                                                DataManager.FBMissionDataManager.RESP_SOCIAL_ENABLE(MP);
                                                                                return;
                                                                              default:
                                                                                switch (protocol)
                                                                                {
                                                                                  case Protocol._MSG_RESP_HEROSAVE:
                                                                                    DataManager.Instance.RecvHeroSave(MP);
                                                                                    GameManager.OnRefresh(NetworkNews.Refresh_Hero);
                                                                                    return;
                                                                                  case Protocol._MSG_RESP_HEROPUTONEQ:
                                                                                    DataManager.Instance.RecvHeroPutOnEq(MP);
                                                                                    return;
                                                                                  case Protocol._MSG_RESP_HEROENHANCE_START:
                                                                                    DataManager.Instance.RecvHeroEnhance_Start(MP);
                                                                                    return;
                                                                                  case Protocol._MSG_RESP_HEROENHANCE_COMPLETE:
                                                                                    DataManager.Instance.RecvHeroEnhance(MP);
                                                                                    return;
                                                                                  case Protocol._MSG_RESP_HEROENHANCE_CANCEL:
                                                                                    DataManager.Instance.RecvHeroEnhance_Cancel(MP);
                                                                                    return;
                                                                                  case Protocol._MSG_RESP_HEROCREATE:
                                                                                    DataManager.Instance.RecvHeroCreate(MP);
                                                                                    return;
                                                                                  case Protocol._MSG_RESP_HEROSTARUP_START:
                                                                                    DataManager.Instance.RecvHeroStarUp_Start(MP);
                                                                                    return;
                                                                                  default:
                                                                                    switch (protocol)
                                                                                    {
                                                                                      case Protocol._MSG_RESP_BATTLEINIT_NPC:
                                                                                        BattleNetwork.RecvInitBattle(MP);
                                                                                        return;
                                                                                      case Protocol._MSG_RESP_BATTLEEND:
                                                                                        BattleNetwork.RecvBattleEnd(MP);
                                                                                        return;
                                                                                      case Protocol._MSG_RESP_QUICKBATTLE:
                                                                                        GUIManager.Instance.Recv_QuickBattle(MP);
                                                                                        return;
                                                                                      case Protocol._MSG_RESP_LEAVEBATTLE:
                                                                                        GUIManager.Instance.HideUILock(EUILock.ExitHeroBattle);
                                                                                        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 9);
                                                                                        return;
                                                                                      case Protocol._MSG_RESP_COMBATEND_NPC:
                                                                                        WarManager.RecvStartStageWar(MP);
                                                                                        return;
                                                                                      case Protocol._MSG_RESP_BATTLESIM_VER:
                                                                                        DataManager.Instance.BattleSimVer = MP.ReadUInt();
                                                                                        DataManager.Instance.BattlePatchNo = MP.ReadUInt();
                                                                                        DataManager.Instance.PetVersionNo = MP.ReadUInt();
                                                                                        return;
                                                                                      case Protocol._MSG_RESP_EX_BATTLEINIT_NPC:
                                                                                        BattleNetwork.RecvInitBattleEx(MP);
                                                                                        return;
                                                                                      case Protocol._MSG_RESP_EX_BATTLEEND:
                                                                                        BattleNetwork.RecvBattleEndEx(MP);
                                                                                        return;
                                                                                      default:
                                                                                        switch (protocol)
                                                                                        {
                                                                                          case Protocol._MSG_RESP_LEADERBOARDS_CLIENT:
                                                                                            LeaderBoardManager.Instance.Recv_MSG_RESP_LEADERBOARDS_CLIENT(MP);
                                                                                            return;
                                                                                          case Protocol._MSG_RESP_BOARDCONTENT:
                                                                                            LeaderBoardManager.Instance.Recv_MSG_RESP_BOARDCONTENT(MP);
                                                                                            return;
                                                                                          case Protocol._MSG_RESP_ARENA_BOARDDATA:
                                                                                            LeaderBoardManager.Instance.Recv_MSG_RESP_ARENA_BOARDDATA(MP);
                                                                                            return;
                                                                                          case Protocol._MSG_RESP_WORLD_TELEPORT_ITEM:
                                                                                            DataManager.Instance.RecvWorldTeleportItemCount(MP.ReadInt(), MP.ReadUShort());
                                                                                            return;
                                                                                          case Protocol._MSG_RESP_KVK_TOPBORAD:
                                                                                            LeaderBoardManager.Instance.Recv_MSG_RESP_KVK_TOPBORAD(MP);
                                                                                            return;
                                                                                          case Protocol._MSG_RESP_WORLDRANKING_LEADERBOARDS_CLIENT:
                                                                                            LeaderBoardManager.Instance.Recv_MSG_RESP_WORLDRANKING_LEADERBOARDS_CLIENT(MP);
                                                                                            return;
                                                                                          case Protocol._MSG_RESP_KINGDOM_VS_TOPBOARD:
                                                                                            LeaderBoardManager.Instance.Recv_MSG_RESP_KINGDOM_VS_TOPBOARD(MP);
                                                                                            return;
                                                                                          default:
                                                                                            switch (protocol)
                                                                                            {
                                                                                              case Protocol._MSG_RESP_WORLD_TITLE_CHANGE:
                                                                                                TitleManager.Instance.Recv_WorldTitle_Change(MP);
                                                                                                return;
                                                                                              case Protocol._MSG_RESP_WORLD_TITLE_REMOVE:
                                                                                                TitleManager.Instance.Recv_WorldTitle_Remove(MP);
                                                                                                return;
                                                                                              case Protocol._MSG_RESP_WORLD_TITLE_LIST:
                                                                                                TitleManager.Instance.Recv_WorldTitle_List(MP);
                                                                                                return;
                                                                                              case Protocol._MSG_RESP_GET_WORLD_TITLE:
                                                                                                TitleManager.Instance.Recv_WorldTitle_Get(MP);
                                                                                                return;
                                                                                              case Protocol._MSG_RESP_NATIONAL_TITLE_CHANGE:
                                                                                                TitleManager.Instance.Recv_NationalTitle_Change(MP);
                                                                                                return;
                                                                                              case Protocol._MSG_RESP_NATIONAL_TITLE_LIST:
                                                                                                TitleManager.Instance.Recv_NationalTitle_List(MP);
                                                                                                return;
                                                                                              case Protocol._MSG_RESP_GET_NATIONAL_TITLE:
                                                                                                TitleManager.Instance.Recv_NationalTitle_Get(MP);
                                                                                                return;
                                                                                              case Protocol._MSG_RESP_CURRENT_NATIONAL_TITLE_NUM:
                                                                                                TitleManager.Instance.Recv_NationalTitle_Count(MP);
                                                                                                return;
                                                                                              default:
                                                                                                switch (protocol)
                                                                                                {
                                                                                                  case Protocol._MSG_RESP_KICK_RALLYMEMBER:
                                                                                                    DataManager.Instance.RespKickWarhallAttackMember(MP);
                                                                                                    return;
                                                                                                  case Protocol._MSG_RESP_KICK_INFORCEMEMBER:
                                                                                                    DataManager.Instance.RespKickWarhallDefenceMember(MP);
                                                                                                    return;
                                                                                                  case Protocol._MSG_RESP_KICKOFF_NOTICE:
                                                                                                    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9914U), (ushort) byte.MaxValue);
                                                                                                    return;
                                                                                                  case Protocol._MSG_RESP_SEND_WONDERHOST:
                                                                                                    DataManager.Instance.RecvWonderHost(MP);
                                                                                                    return;
                                                                                                  case Protocol._MSG_RESP_WONDERHOST_RETURN:
                                                                                                    DataManager.Instance.RecvWinderhostReturn(MP);
                                                                                                    return;
                                                                                                  case Protocol._MSG_RESP_WONDER_WARHALL_UPDATE_LISTELE_PARTII:
                                                                                                    goto label_340;
                                                                                                  case Protocol._MSG_RESP_WONDER_WARHALL_INIT_LISTDETAIL_PARTII:
                                                                                                    goto label_341;
                                                                                                  default:
                                                                                                    switch (protocol)
                                                                                                    {
                                                                                                      case Protocol._MSG_RESP_RESEARCHINFO:
                                                                                                        DataManager.Instance.RecvTechnologyInfo(MP);
                                                                                                        return;
                                                                                                      case Protocol._MSG_RESP_RESEARCH_EVENT_START:
                                                                                                        DataManager.Instance.RecvTechnologyResearch(MP);
                                                                                                        return;
                                                                                                      case Protocol._MSG_RESP_RESEARCH_EVENT_FREE:
                                                                                                        DataManager.Instance.RecvTechnologyCompleteFree(MP);
                                                                                                        return;
                                                                                                      case Protocol._MSG_RESP_RESEARCH_EVENT_CANCEL:
                                                                                                        DataManager.Instance.RecvTechnologyResearchCancel(MP);
                                                                                                        return;
                                                                                                      case Protocol._MSG_RESP_RESEARCH_EVENT_COMPLETE:
                                                                                                        DataManager.Instance.RecvTechnologyComplete(MP);
                                                                                                        return;
                                                                                                      case Protocol._MSG_RESP_RESEARCH_EVENT_INSTANT:
                                                                                                        DataManager.Instance.RecvTechnologyCompleteImmediate(MP);
                                                                                                        return;
                                                                                                      default:
                                                                                                        switch (protocol)
                                                                                                        {
                                                                                                          case Protocol._MSG_RESP_BLACKMARKET_DATA:
                                                                                                            MerchantmanManager.Instance.RecvBlackMarket_Data(MP);
                                                                                                            return;
                                                                                                          case Protocol._MSG_RESP_BLACKMARKET_LOCK:
                                                                                                            MerchantmanManager.Instance.RecvBlackMarket_Lock(MP);
                                                                                                            return;
                                                                                                          case Protocol._MSG_RESP_BLACKMARKET_BUY:
                                                                                                            MerchantmanManager.Instance.RecvBlackMarket_Buy(MP);
                                                                                                            return;
                                                                                                          case Protocol._MSG_RESP_BLACKMARKET_EXTRA_TRADE:
                                                                                                            MerchantmanManager.Instance.RecvExtraTrade(MP);
                                                                                                            return;
                                                                                                          case Protocol._MSG_TREASURE_COMBOBOX_CHANGE:
                                                                                                            MerchantmanManager.Instance.RecvExtraChange(MP);
                                                                                                            return;
                                                                                                          default:
                                                                                                            switch (protocol)
                                                                                                            {
                                                                                                              case Protocol._MSG_RESP_HEROSTARUP_COMPLETE:
                                                                                                                DataManager.Instance.RecvHeroStarUp(MP);
                                                                                                                return;
                                                                                                              case Protocol._MSG_RESP_HEROSTARUP_CANCEL:
                                                                                                                DataManager.Instance.RecvHeroStarUp_Cancel(MP);
                                                                                                                return;
                                                                                                              case Protocol._MSG_RESP_HEROSKILLADD:
                                                                                                                DataManager.Instance.RecvHeroSkillAdd(MP);
                                                                                                                return;
                                                                                                              case Protocol._MSG_RESP_CHANGELORD:
                                                                                                                DataManager.Instance.RecvChangeLord(MP);
                                                                                                                return;
                                                                                                              default:
                                                                                                                switch (protocol)
                                                                                                                {
                                                                                                                  case Protocol._MSG_RESP_CRYPT:
                                                                                                                    DataManager.Instance.Recv_MSG_RESP_CRYPT(MP);
                                                                                                                    return;
                                                                                                                  case Protocol._MSG_RESP_CRYPT_START:
                                                                                                                    DataManager.Instance.Recv_MSG_RESP_CRYPT_Start(MP);
                                                                                                                    return;
                                                                                                                  case Protocol._MSG_RESP_CRYPT_CANCEL:
                                                                                                                    DataManager.Instance.Recv_MSG_RESP_CRYPT_Cancel(MP);
                                                                                                                    return;
                                                                                                                  case Protocol._MSG_RESP_CRYPT_REWARD:
                                                                                                                    DataManager.Instance.Recv_MSG_RESP_CRYPT_Reward(MP);
                                                                                                                    return;
                                                                                                                  default:
                                                                                                                    switch (protocol)
                                                                                                                    {
                                                                                                                      case Protocol._MSG_RESP_WONDER_INIT_NOTICE:
                                                                                                                        GUIManager.Instance.Recv_WONDER_INIT_NOTICE(MP);
                                                                                                                        return;
                                                                                                                      case Protocol._MSG_RESP_WONDER_TAKEOVER_NOTICE:
                                                                                                                        GUIManager.Instance.Recv_WONDER_TAKEOVER_NOTICE(MP);
                                                                                                                        return;
                                                                                                                      case Protocol._MSG_RESP_WONDER_PEACE_NOTICE:
                                                                                                                        GUIManager.Instance.Recv_WONDER_PEACE_NOTICE(MP);
                                                                                                                        return;
                                                                                                                      case Protocol._MSG_RESP_WONDER_PEACE_OVER:
                                                                                                                        GUIManager.Instance.Recv_WONDER_PEACE_OVER(MP);
                                                                                                                        return;
                                                                                                                      case Protocol._MSG_RESP_WORLDWONDER_OPEN:
                                                                                                                        GUIManager.Instance.Recv_WORLDWONDER_OPEN(MP);
                                                                                                                        return;
                                                                                                                      case Protocol._MSG_RESP_WORLDWONDER_TAKEOVER:
                                                                                                                        GUIManager.Instance.Recv_WORLDWONDER_TAKEOVER(MP);
                                                                                                                        return;
                                                                                                                      case Protocol._MSG_RESP_WORLDWONDER_CLOSE:
                                                                                                                        GUIManager.Instance.Recv_WORLDWONDER_CLOSE(MP);
                                                                                                                        return;
                                                                                                                      case Protocol._MSG_RESP_GAMBLE_INFO:
                                                                                                                        GamblingManager.Instance.Recv_MSG_RESP_GAMBLE_INFO(MP);
                                                                                                                        return;
                                                                                                                      case Protocol._MSG_RESP_GAMBLE_STARTGAME:
                                                                                                                        GamblingManager.Instance.Recv_MSG_RESP_GAMBLE_STARTGAME(MP);
                                                                                                                        return;
                                                                                                                      case Protocol._MSG_RESP_GAMBLE_PRIZE:
                                                                                                                        GamblingManager.Instance.Recv_MSG_RESP_GAMBLE_PRIZE(MP);
                                                                                                                        return;
                                                                                                                      case Protocol._MSG_GAMBLE_JACKPOT:
                                                                                                                        GamblingManager.Instance.Recv_MSG_GAMBLE_JACKPOT(MP);
                                                                                                                        return;
                                                                                                                      case Protocol._MSG_GAMBLE_HISTORY:
                                                                                                                        GamblingManager.Instance.Recv_MSG_GAMBLE_HISTORY(MP);
                                                                                                                        return;
                                                                                                                      default:
                                                                                                                        switch (protocol)
                                                                                                                        {
                                                                                                                          case Protocol._MSG_RESP_SHELTER_DATA:
                                                                                                                            HideArmyManager.Instance.RecvShelterData(MP);
                                                                                                                            return;
                                                                                                                          case Protocol._MSG_RESP_HIDETROOPINSHELTER:
                                                                                                                            HideArmyManager.Instance.RecvHideTroopInshelter(MP);
                                                                                                                            return;
                                                                                                                          case Protocol._MSG_RESP_RELEASESHELTERTROOP:
                                                                                                                            HideArmyManager.Instance.RecvReleaseShelterTroop(MP);
                                                                                                                            return;
                                                                                                                          case Protocol._MSG_RESP_SHELTER_TIMESUP:
                                                                                                                            HideArmyManager.Instance.RecvShelterTimesUp();
                                                                                                                            return;
                                                                                                                          default:
                                                                                                                            switch (protocol)
                                                                                                                            {
                                                                                                                              case Protocol._MSG_RESP_REDPOCKET_LIST:
                                                                                                                                ActivityGiftManager.Instance.Recv_MSG_RESP_REDPOCKET_LIST(MP);
                                                                                                                                return;
                                                                                                                              case Protocol._MSG_RESP_REDPOCKET_LEADEREND:
                                                                                                                                ActivityGiftManager.Instance.Recv_MSG_RESP_REDPOCKET_LEADEREND(MP);
                                                                                                                                return;
                                                                                                                              case Protocol._MSG_RESP_REDPOCKET_GET:
                                                                                                                                ActivityGiftManager.Instance.Recv_MSG_RESP_REDPOCKET_GET(MP);
                                                                                                                                return;
                                                                                                                              case Protocol._MSG_RESP_REDPOCKET_BUY:
                                                                                                                                ActivityGiftManager.Instance.Recv_MSG_RESP_REDPOCKET_BUY(MP);
                                                                                                                                return;
                                                                                                                              default:
                                                                                                                                switch (protocol)
                                                                                                                                {
                                                                                                                                  case Protocol._MSG_RESP_CREATEROLE:
                                                                                                                                    MP.ReadLong();
                                                                                                                                    byte num2 = MP.ReadByte();
                                                                                                                                    MP.ReadShort();
                                                                                                                                    MP.ReadByte();
                                                                                                                                    MP.ReadByte();
                                                                                                                                    MP.ReadString(13);
                                                                                                                                    if (num2 <= (byte) 0)
                                                                                                                                      return;
                                                                                                                                    GUIManager.Instance.AddHUDMessage("Name Invalid", (ushort) byte.MaxValue);
                                                                                                                                    return;
                                                                                                                                  case Protocol._MSG_RESP_ACTIVE:
                                                                                                                                    DataManager.Instance.ServerTime = MP.ReadLong();
                                                                                                                                    GameManager.OnRefresh(NetworkNews.Refresh_ServerTime);
                                                                                                                                    NetworkManager.MakeBeat(15L);
                                                                                                                                    return;
                                                                                                                                  case Protocol._MSG_RESP_KINGDOM_TITLE_CHANGE_EX:
                                                                                                                                    TitleManager.Instance.Recv_KingdomTitle_ChangeByOthers(MP);
                                                                                                                                    return;
                                                                                                                                  case Protocol._MSG_RESP_KINGDOM_TITLE_REMOVE_EX:
                                                                                                                                    TitleManager.Instance.Recv_KingdomTitle_RemoveByOthers(MP);
                                                                                                                                    return;
                                                                                                                                  case Protocol._MSG_RESP_WORLD_TITLE_CHANGE_EX:
                                                                                                                                    TitleManager.Instance.Recv_WorldTitle_ChangeByOthers(MP);
                                                                                                                                    return;
                                                                                                                                  case Protocol._MSG_RESP_WORLD_TITLE_REMOVE_EX:
                                                                                                                                    TitleManager.Instance.Recv_WorldTitle_RemoveByOthers(MP);
                                                                                                                                    return;
                                                                                                                                  case Protocol._MSG_RESP_NOBILITY_TITLE_CHANGE_EX:
                                                                                                                                    TitleManager.Instance.Recv_NobilityTitle_ChangeByOthers(MP);
                                                                                                                                    return;
                                                                                                                                  case Protocol._MSG_RESP_NOBILITY_TITLE_REMOVE_EX:
                                                                                                                                    TitleManager.Instance.Recv_NobilityTitle_RemoveByOthers(MP);
                                                                                                                                    return;
                                                                                                                                  default:
                                                                                                                                    switch (protocol)
                                                                                                                                    {
                                                                                                                                      case Protocol._MSG_CLIENT_LOGINTOLRESP:
                                                                                                                                        NetworkManager.Instance.SetStage(LoginPhase.LP_Logon, (long) MP.ReadInt());
                                                                                                                                        return;
                                                                                                                                      case Protocol._MSG_LOGIN_CROSSKINGDOM_CLOSE:
                                                                                                                                        NetworkManager.Instance.SetStage(LoginPhase.LP_KickAss, 0L);
                                                                                                                                        for (int index = DataManager.Instance.TalkData_Kingdom.Count - 1; index >= 0; --index)
                                                                                                                                          DataManager.Instance.TalkData_KPool.despawn(DataManager.Instance.TalkData_Kingdom[index]);
                                                                                                                                        DataManager.Instance.TalkData_Kingdom.Clear();
                                                                                                                                        DataManager.Instance.bChangeKingdomClear = true;
                                                                                                                                        byte num3 = MP.ReadByte();
                                                                                                                                        ushort newKingdomID = MP.ReadUShort();
                                                                                                                                        ushort newZoneID1 = MP.ReadUShort();
                                                                                                                                        byte newPointID1 = MP.ReadByte();
                                                                                                                                        DataManager.MapDataController.ClearLayoutMapInfoYolkKind();
                                                                                                                                        DataManager.MapDataController.ClearAll();
                                                                                                                                        DataManager.MapDataController.updateCapitalPoint(newZoneID1, newPointID1, newKingdomID, true);
                                                                                                                                        if (num3 != (byte) 4)
                                                                                                                                          return;
                                                                                                                                        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(981U), (ushort) byte.MaxValue);
                                                                                                                                        return;
                                                                                                                                      default:
                                                                                                                                        switch (protocol)
                                                                                                                                        {
                                                                                                                                          case Protocol._MSG_RESP_INIT_OPENKINGDOMINFO:
                                                                                                                                            DataManager.MapDataController.INIT_OPENKINGDOMINFO(MP);
                                                                                                                                            return;
                                                                                                                                          case Protocol._MSG_RESP_UPDATE_OPENKINGDOMINFO:
                                                                                                                                            DataManager.MapDataController.UPDATE_OPENKINGDOMINFO(MP);
                                                                                                                                            return;
                                                                                                                                          case Protocol._MSG_MAP_MY_KINGDOMINFO:
                                                                                                                                            DataManager.MapDataController.MY_KINGDOMINFO(MP);
                                                                                                                                            return;
                                                                                                                                          case Protocol._MSG_RESP_UPDATE_MAPINFO_PLUS:
                                                                                                                                            if ((int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
                                                                                                                                              return;
                                                                                                                                            DataManager.MapDataController.RecvMapInfoPlus(MP);
                                                                                                                                            return;
                                                                                                                                          case Protocol._MSG_RESP_CHATMESSAGE:
                                                                                                                                            DataManager.Instance.RecvChatMessage(MP);
                                                                                                                                            return;
                                                                                                                                          case Protocol._MSG_RESP_ALLYMESSAGE:
                                                                                                                                            DataManager.Instance.Recv_MessageBoard(MP);
                                                                                                                                            return;
                                                                                                                                          default:
                                                                                                                                            switch (protocol)
                                                                                                                                            {
                                                                                                                                              case Protocol._MSG_CASTLE_SKIN_UNLOCKDATA:
                                                                                                                                                GUIManager.Instance.BuildingData.castleSkin.RecvCastleUnlockdata(MP);
                                                                                                                                                return;
                                                                                                                                              case Protocol._MSG_CASTLE_SKIN_UPDATE:
                                                                                                                                                GUIManager.Instance.BuildingData.castleSkin.RecvCastleSkinUpdate(MP);
                                                                                                                                                return;
                                                                                                                                              case Protocol._MSG_RESP_CASTLE_SKIN_CHANGE:
                                                                                                                                                GUIManager.Instance.BuildingData.castleSkin.RecvCastleSkinChange(MP);
                                                                                                                                                return;
                                                                                                                                              default:
                                                                                                                                                switch (protocol)
                                                                                                                                                {
                                                                                                                                                  case Protocol._MSG_LOGIN_ROLEINFO:
                                                                                                                                                    DataManager instance5 = DataManager.Instance;
                                                                                                                                                    instance5.RoleAttr.ReadPackNum = MP.ReadInt();
                                                                                                                                                    instance5.RoleAttr.UserId = MP.ReadLong();
                                                                                                                                                    MP.ReadStringPlus(13, instance5.RoleAttr.Name);
                                                                                                                                                    instance5.RoleAttr.Head = MP.ReadUShort();
                                                                                                                                                    if (DataManager.Instance.beCaptured.nowCaptureStat != LoadCaptureState.None)
                                                                                                                                                    {
                                                                                                                                                      DataManager.Instance.TempFightHeroID[(int) instance5.RoleAttr.Head] = (byte) 1;
                                                                                                                                                      DataManager.Instance.SetFightHeroData();
                                                                                                                                                    }
                                                                                                                                                    instance5.RoleAttr.Level = (byte) 0;
                                                                                                                                                    DataManager.StageDataController.RoleAttrLevelUp(MP, 27);
                                                                                                                                                    instance5.RoleAttr.ServerTime = MP.ReadLong();
                                                                                                                                                    instance5.RoleAttr.LogoutTime = MP.ReadLong();
                                                                                                                                                    instance5.RoleAttr.Guide = (ulong) MP.ReadUInt();
                                                                                                                                                    instance5.RoleAttr.Diamond = MP.ReadUInt();
                                                                                                                                                    instance5.RoleAttr.HeroSkillPoint = MP.ReadByte();
                                                                                                                                                    instance5.RoleAttr.LastHeroSPRecoverTime = MP.ReadLong();
                                                                                                                                                    instance5.RoleAttr.EnhanceEventHeroID = MP.ReadUShort();
                                                                                                                                                    instance5.RoleAttr.HeroEnhanceEventTime.BeginTime = MP.ReadLong();
                                                                                                                                                    instance5.RoleAttr.HeroEnhanceEventTime.RequireTime = MP.ReadUInt();
                                                                                                                                                    instance5.RoleAttr.StarUpEventHeroID = MP.ReadUShort();
                                                                                                                                                    instance5.RoleAttr.HeroStarUpEventTime.BeginTime = MP.ReadLong();
                                                                                                                                                    instance5.RoleAttr.HeroStarUpEventTime.RequireTime = MP.ReadUInt();
                                                                                                                                                    MP.ReadBlock(DataManager.StageDataController.StageInfo[0], 0, (int) GameConstants.StageInfoSize[0]);
                                                                                                                                                    MP.ReadBlock(DataManager.StageDataController.StageInfo[1], 0, (int) GameConstants.StageInfoSize[1]);
                                                                                                                                                    bool reflash = false;
                                                                                                                                                    if (DataManager.StageDataController.reflashStageRecordInfo(StageMode.Full, MP.ReadUShort()))
                                                                                                                                                      DataManager.StageDataController.StageRecord[1] = MP.ReadUShort();
                                                                                                                                                    else
                                                                                                                                                      reflash = !DataManager.StageDataController.reflashStageRecordInfo(StageMode.Lean, MP.ReadUShort());
                                                                                                                                                    instance5.RoleAttr.BattleID = MP.ReadULong();
                                                                                                                                                    ushort newZoneID2 = MP.ReadUShort();
                                                                                                                                                    byte newPointID2 = MP.ReadByte();
                                                                                                                                                    instance5.RoleAttr.LastChatterTime = MP.ReadULong();
                                                                                                                                                    instance5.RoleAttr.AllianceChatID = MP.ReadUInt();
                                                                                                                                                    instance5.RoleAttr.Power = MP.ReadULong();
                                                                                                                                                    instance5.RoleAttr.Kills = MP.ReadULong();
                                                                                                                                                    instance5.RoleAttr.VipPoint = MP.ReadUInt();
                                                                                                                                                    instance5.RoleAttr.FirstTimer = MP.ReadLong();
                                                                                                                                                    instance5.RoleAttr.PrizeFlag = MP.ReadUInt();
                                                                                                                                                    instance5.RoleAttr.BookmarkTime = MP.ReadLong();
                                                                                                                                                    instance5.RoleAttr.BookmarkLimit = MP.ReadUShort();
                                                                                                                                                    instance5.RoleAttr.BookmarkNum = MP.ReadUShort();
                                                                                                                                                    bool flag2 = !DataManager.StageDataController.UpdateCorpsStageInfo(MP, reflash);
                                                                                                                                                    instance5.RoleAttr.SuccessiveLoginDays = MP.ReadUShort();
                                                                                                                                                    instance5.RoleAttr.TodayUseMoraleItemTimes = MP.ReadByte();
                                                                                                                                                    instance5.RoleAttr.LordEquipBagSize = MP.ReadByte();
                                                                                                                                                    instance5.RoleAttr.VIPLevel = instance5.GetVIPLevel(instance5.RoleAttr.VipPoint);
                                                                                                                                                    instance5.RoleAttr.NextOnlineGiftOpenTime = MP.ReadLong();
                                                                                                                                                    instance5.RoleAttr.OnlineGiftOpenTimes = MP.ReadByte();
                                                                                                                                                    instance5.RoleAttr.OnlineGiftItemID.ItemID = MP.ReadUShort();
                                                                                                                                                    instance5.RoleAttr.OnlineGiftItemID.Quantity = MP.ReadUShort();
                                                                                                                                                    instance5.RoleAttr.LastLordEquipUpdateTime = MP.ReadLong();
                                                                                                                                                    instance5.RoleAttr.LastItemMatUpdateTime = MP.ReadLong();
                                                                                                                                                    instance5.RoleAttr.LastItemGemUpdateTime = MP.ReadLong();
                                                                                                                                                    instance5.RoleAttr.LordEquipEventData.Init();
                                                                                                                                                    instance5.RoleAttr.LordEquipEventData.ItemID = MP.ReadUShort();
                                                                                                                                                    instance5.RoleAttr.LordEquipEventData.Color = MP.ReadByte();
                                                                                                                                                    for (int index = 0; index < 4; ++index)
                                                                                                                                                      instance5.RoleAttr.LordEquipEventData.GemColor[index] = MP.ReadByte();
                                                                                                                                                    for (int index = 0; index < 4; ++index)
                                                                                                                                                      instance5.RoleAttr.LordEquipEventData.Gem[index] = MP.ReadUShort();
                                                                                                                                                    instance5.RoleAttr.LordEquipEventData.SerialNO = MP.ReadUInt();
                                                                                                                                                    instance5.RoleAttr.LordEquipEventTime.BeginTime = MP.ReadLong();
                                                                                                                                                    instance5.RoleAttr.LordEquipEventTime.RequireTime = MP.ReadUInt();
                                                                                                                                                    instance5.RoleAttr.VipLevelUp = MP.ReadByte();
                                                                                                                                                    DataManager.MapDataController.updateMyKingdom(MP.ReadUShort(), MP.ReadUShort());
                                                                                                                                                    DataManager.MapDataController.updateCapitalPoint(newZoneID2, newPointID2, DataManager.MapDataController.OtherKingdomData.kingdomID);
                                                                                                                                                    instance5.RoleAttr.recvMonsterPoint = MP.ReadUInt();
                                                                                                                                                    instance5.RoleAttr.LastMonsterPointRecoverTime = MP.ReadLong();
                                                                                                                                                    instance5.RoleAttr.MonsterPointRecoverFrequency = MP.ReadUShort();
                                                                                                                                                    instance5.mSetNotice = MP.ReadUShort();
                                                                                                                                                    instance5.RoleAttr.TPP_Point = MP.ReadUInt();
                                                                                                                                                    instance5.RoleAttr.PaidCrystal = MP.ReadUInt();
                                                                                                                                                    MallManager.Instance.BuyMonthTreasureTime = MP.ReadLong();
                                                                                                                                                    MallManager.Instance.LastGetMonthTreasurePrizeTime = MP.ReadLong();
                                                                                                                                                    MP.ReadStringPlus(41, instance5.RoleAttr.NickName);
                                                                                                                                                    int num4 = (int) MP.ReadByte();
                                                                                                                                                    instance5.RoleAttr.KingdomTitle = MP.ReadUShort();
                                                                                                                                                    instance5.RoleAttr.NowArmyCoordIndex = MP.ReadByte();
                                                                                                                                                    instance5.RoleAttr.ArmyCoordFlag = MP.ReadUInt();
                                                                                                                                                    instance5.RoleAttr.bAllianceMobilizationGetPrize = MP.ReadByte();
                                                                                                                                                    instance5.RoleAttr.WorldTitle_Personal = MP.ReadUShort();
                                                                                                                                                    instance5.RoleAttr.WorldTitle_Country = MP.ReadUShort();
                                                                                                                                                    instance5.RoleAttr.DailyFreeScardStar = MP.ReadByte();
                                                                                                                                                    instance5.RoleAttr.ScardStar = MP.ReadUInt();
                                                                                                                                                    if (flag2)
                                                                                                                                                      DataManager.StageDataController.reflashStageRecordInfo(StageMode.Dare, MP.ReadUShort());
                                                                                                                                                    else
                                                                                                                                                      DataManager.StageDataController.StageRecord[3] = MP.ReadUShort();
                                                                                                                                                    MP.ReadBlock(DataManager.StageDataController.StageInfo[3], 0, (int) GameConstants.StageInfoSize[3]);
                                                                                                                                                    instance5.mNewPushSwitch = MP.ReadULong();
                                                                                                                                                    instance5.RoleAttr.NobilityTitle = MP.ReadUShort();
                                                                                                                                                    instance5.RoleAttr.Guide |= (ulong) MP.ReadUInt() << 32;
                                                                                                                                                    instance5.RoleAttr.GuideEx = MP.ReadUInt();
                                                                                                                                                    instance5.RoleAttr.PetSkillFatigue = MP.ReadUShort();
                                                                                                                                                    instance5.RoleAlliance.JoinTime = MP.ReadLong();
                                                                                                                                                    MallManager.Instance.BackRewardComboBoxID = MP.ReadUShort();
                                                                                                                                                    if ((int) MallManager.Instance.BackRewardComboBoxID != (int) MallManager.Instance.BackRewardOpenID)
                                                                                                                                                      MallManager.Instance.BackRewardOpenID = (ushort) 0;
                                                                                                                                                    string str = instance5.RoleAttr.NickName.ToString();
                                                                                                                                                    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
                                                                                                                                                    for (int index = 0; index < instance5.RoleAttr.NickName.Length; ++index)
                                                                                                                                                    {
                                                                                                                                                      if (!instance5.isNotEmojiCharacter(instance5.RoleAttr.NickName[index]))
                                                                                                                                                        chPtr[index] = ' ';
                                                                                                                                                    }
                                                                                                                                                    str = (string) null;
                                                                                                                                                    NewbieManager.CheckNewbieLive();
                                                                                                                                                    instance5.loginFinish();
                                                                                                                                                    instance5.SetDefendersID();
                                                                                                                                                    return;
                                                                                                                                                  case Protocol._MSG_LOGIN_LOGINERRORRESP:
                                                                                                                                                    NetworkManager.Instance.SetStage(LoginPhase.LP_Login, (long) MP.ReadByte());
                                                                                                                                                    return;
                                                                                                                                                  default:
                                                                                                                                                    switch (protocol)
                                                                                                                                                    {
                                                                                                                                                      case Protocol._MSG_RESP_ALLYPOINT:
                                                                                                                                                        DataManager.Instance.RecvAllyPoint(MP);
                                                                                                                                                        return;
                                                                                                                                                      case Protocol._MSG_RESP_RESPOINT_OWNER_LV:
                                                                                                                                                        DataManager.Instance.RecvResPointOwnerLv(MP);
                                                                                                                                                        return;
                                                                                                                                                      default:
                                                                                                                                                        switch (protocol)
                                                                                                                                                        {
                                                                                                                                                          case Protocol._MSG_RESP_ALLYNICKNAME:
                                                                                                                                                            DataManager.Instance.RecvChatNickName(MP);
                                                                                                                                                            return;
                                                                                                                                                          case Protocol._MSG_RESP_DELETECHAT:
                                                                                                                                                            DataManager.Instance.Recv_DeleteMsg(MP);
                                                                                                                                                            return;
                                                                                                                                                          default:
                                                                                                                                                            switch (protocol)
                                                                                                                                                            {
                                                                                                                                                              case Protocol._MSG_RESP_ALL_LORDEQUIP_MEMORY:
                                                                                                                                                                LordEquipData.Instance().RESP_ALL_LORDEQUIP_MEMORY(MP);
                                                                                                                                                                return;
                                                                                                                                                              case Protocol._MSG_RESP_LORDEQUIP_CHANGE:
                                                                                                                                                                LordEquipData.Instance().RESP_LORDEQUIP_CHANGE(MP);
                                                                                                                                                                return;
                                                                                                                                                              default:
                                                                                                                                                                switch (protocol)
                                                                                                                                                                {
                                                                                                                                                                  case Protocol._MSG_REBOOTMSG:
                                                                                                                                                                    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(655U), (ushort) byte.MaxValue);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_RESP_LOGINVALIDATE:
                                                                                                                                                                    NetworkManager.Login(MP);
                                                                                                                                                                    DataManager.Instance.bRecvQueueBarData = 0L;
                                                                                                                                                                    DataManager.Instance.bBeginReLogin = true;
                                                                                                                                                                    DataManager.Instance.SendAllianceID = 0U;
                                                                                                                                                                    DataManager.Instance.SendMessageID = 0L;
                                                                                                                                                                    DataManager.Instance.ResetAllianceMemberData();
                                                                                                                                                                    DataManager.Instance.ResetMailingData();
                                                                                                                                                                    byte.TryParse(PlayerPrefs.GetString("SysSetting_First"), out DataManager.Instance.mFirstSetSys);
                                                                                                                                                                    if (DataManager.Instance.mFirstSetSys == (byte) 1)
                                                                                                                                                                      DataManager.Instance.GetSysSettingSave();
                                                                                                                                                                    else
                                                                                                                                                                      DataManager.Instance.ReSetSysSettingSave();
                                                                                                                                                                    DataManager.Instance.LegionBattleHero.Clear();
                                                                                                                                                                    DataManager.Instance.FightHeroCount = 0U;
                                                                                                                                                                    DataManager.Instance.NonFightHeroCount = 0U;
                                                                                                                                                                    DataManager.Instance.ServerVersionMajor = MP.ReadByte();
                                                                                                                                                                    DataManager.Instance.ServerVersionMinor = MP.ReadByte();
                                                                                                                                                                    DataManager.Instance.InitMarchData();
                                                                                                                                                                    DataManager.Instance.curHeroData.Clear();
                                                                                                                                                                    Array.Clear((Array) DataManager.Instance.sortHeroData, 0, DataManager.Instance.sortHeroData.Length);
                                                                                                                                                                    DataManager.Instance.ResetBuffData();
                                                                                                                                                                    DataManager.Instance.InitAltarTime();
                                                                                                                                                                    AudioManager.Instance.MuteSFXVol = !DataManager.Instance.MySysSetting.bSound;
                                                                                                                                                                    Array.Clear((Array) DataManager.Instance.TempFightHeroID, 0, DataManager.Instance.TempFightHeroID.Length);
                                                                                                                                                                    DataManager.Instance.beCaptured.nowCaptureStat = LoadCaptureState.None;
                                                                                                                                                                    DataManager.Instance.mHelpDataList.Clear();
                                                                                                                                                                    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 11);
                                                                                                                                                                    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 17);
                                                                                                                                                                    DataManager.Instance.WarhallProtocol = (ushort) 0;
                                                                                                                                                                    DataManager.Instance.ActiveRallyRecNum = 0U;
                                                                                                                                                                    DataManager.Instance.BeingRallyRecNum = 0U;
                                                                                                                                                                    DataManager.MissionDataManager.bFirst = (byte) 1;
                                                                                                                                                                    GUIManager.Instance.ClearBackMessageBox((byte) 1);
                                                                                                                                                                    GUIManager.Instance.ClearBackMessageBox((byte) 2);
                                                                                                                                                                    GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Newbie);
                                                                                                                                                                    MallManager.Instance.bLoginFinish = false;
                                                                                                                                                                    AmbushManager.Instance.ClearAmbushData();
                                                                                                                                                                    DataManager.Instance.mDailyGift_Pic = (ushort) 0;
                                                                                                                                                                    ArenaManager.Instance.m_ArenaClose_CDTime = 0L;
                                                                                                                                                                    ArenaManager.Instance.m_ArenaClose_ActivityType = EActivityType.EAT_MAX;
                                                                                                                                                                    GUIManager.Instance.NPCCityBonusTime = 0L;
                                                                                                                                                                    DataManager.MissionDataManager.AchievementMgr.CheckAuthenticate();
                                                                                                                                                                    MallManager.Instance.ClearFullGift();
                                                                                                                                                                    PetManager.Instance.Clear();
                                                                                                                                                                    PetManager.Instance.bRecvPetMarchFinish = false;
                                                                                                                                                                    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 7);
                                                                                                                                                                    ActivityGiftManager.Instance.cleanListData();
                                                                                                                                                                    DataManager.Instance.DelRallyUIStack();
                                                                                                                                                                    GUIManager.Instance.bShowLive = false;
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_GUESTLOGIN_RESP_TOC:
                                                                                                                                                                    NetworkManager.Peeping(MP);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_FORCE_TELEPORT_LEAVEFOREST:
                                                                                                                                                                    DataManager.Instance.Recv_TELEPORT_LEAVEFOREST(MP);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_RESP_WONDER_SWITCH:
                                                                                                                                                                    if ((int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
                                                                                                                                                                      return;
                                                                                                                                                                    DataManager.MapDataController.UpdateYolkswitch(MP);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_TREASURE_BUY:
                                                                                                                                                                    MallManager.Instance.RecvMall_GetItem(MP);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_RESP_SUICIDENUM_BY_POWER_BOARD:
                                                                                                                                                                    UISuicideBox.RespSuicideNumByPowerBoard(MP);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_BACKEND_UPDATE_ACTNEWS:
                                                                                                                                                                    ActivityManager.Instance.RecvActNews(MP);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_BACKEND_UPDATE_DAILY_ACTNEWS:
                                                                                                                                                                    ActivityManager.Instance.RecvDailyActNews(MP);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_RESP_INDEMNIFY:
                                                                                                                                                                    Indemnify.Instance.CheckIndemnify(MP);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_RESP_INDEMNIFY_RESOURCE:
                                                                                                                                                                    Indemnify.Instance.CheckIndemnifyResource(MP);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_RESP_ALL_TALENT_CACHE:
                                                                                                                                                                    DataManager.Instance.RecvTalentSave(MP);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_RESP_TALENT_CACHE_NUM_MODIFY:
                                                                                                                                                                    DataManager.Instance.RecvTalentSavePointIncreased(MP);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_RESP_KING_GIFT_INFO_PLUS:
                                                                                                                                                                    DataManager.Instance.KingGift.RecvKingGiftInfo(MP);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_RESP_TROOPMEMORY_SETUP:
                                                                                                                                                                    DataManager.Instance.RecvTroopmemory_Setup(MP);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_RESP_TROOPMEMORY_DATA:
                                                                                                                                                                    DataManager.Instance.RecvTroopmemory_Data(MP);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_RESP_COORD_CHANGE:
                                                                                                                                                                    UIFormationSelect.RecvFormation(MP);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_WEGAMER_RESP_OFFICIAL_LIVE:
                                                                                                                                                                    GUIManager.Instance.bShowLive = MP.ReadByte() == (byte) 1;
                                                                                                                                                                    if (!GUIManager.Instance.bShowLive)
                                                                                                                                                                      GUIManager.Instance.StopShowLiveScale = (byte) 0;
                                                                                                                                                                    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other, 2);
                                                                                                                                                                    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 20);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_WEGAMER_RESP_CONFIRM_OFFICIAL_LIVE:
                                                                                                                                                                    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other, 3);
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_UPDATE_EMOTION_DATA:
                                                                                                                                                                    for (int index = 0; index < 8; ++index)
                                                                                                                                                                      GUIManager.Instance.EmojiFlag[index] = MP.ReadLong();
                                                                                                                                                                    GUIManager.Instance.LoadEmojiSelectSave();
                                                                                                                                                                    if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UIEmojiSelect))
                                                                                                                                                                    {
                                                                                                                                                                      GUIManager.Instance.CloseMenu(EGUIWindow.UIEmojiSelect);
                                                                                                                                                                      GUIManager.Instance.OpenMenu(EGUIWindow.UIEmojiSelect, (int) GUIManager.Instance.EmojiOpenType, bSecWindow: true);
                                                                                                                                                                    }
                                                                                                                                                                    if (!MallManager.Instance.bLockBuyEmojiID || MallManager.Instance.SendCheckEmojiID == (ushort) 0 || !GUIManager.Instance.HasEmotionPck(MallManager.Instance.SendCheckEmojiID))
                                                                                                                                                                      return;
                                                                                                                                                                    MallManager.Instance.ClearSendCheckBuySN();
                                                                                                                                                                    return;
                                                                                                                                                                  case Protocol._MSG_RESP_ADD_EMOTION:
                                                                                                                                                                    MP.ReadUShort();
                                                                                                                                                                    AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
                                                                                                                                                                    AudioManager.Instance.PlayUISFX(UIKind.ItemUse);
                                                                                                                                                                    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(867U), (ushort) 254);
                                                                                                                                                                    GUIManager.Instance.HideUILock(EUILock.Mall);
                                                                                                                                                                    return;
                                                                                                                                                                  default:
                                                                                                                                                                    return;
                                                                                                                                                                }
                                                                                                                                                            }
                                                                                                                                                        }
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
  }
}
