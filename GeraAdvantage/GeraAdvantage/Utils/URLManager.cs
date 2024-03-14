using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GeraAdvantage.Utils
{
    public static class URLManager
    {
        public static readonly string BaseURL = "https://windowsdev.in/Api";
        private static string GetServiceURL(string serviceName)
        {
            string url = string.Format("{0}/{1}/GetAll", BaseURL, serviceName);
            //DomainName = enSettings.DomainName;
            return url;
        }
        internal static string GetRootCauseURL()
        {
            return GetServiceURL("RootCause");
        }
        internal static string GetUnitTypeURL()
        {
            return GetServiceURL("UnitType");
        }

        internal static string GetUserURL()
        {
            return GetServiceURL("User");
        }
        internal static string GetLoginURL(string username,string Password, string DeviceID)
        {
            return string.Format("{0}/User/ValidateLogin?userName={1}&password={2}&deviceid={3}", BaseURL, username,Password,DeviceID);
        }

        internal static string GetSeverityURL()
        {
            return GetServiceURL("Severity");
        }
        internal static string GetCategoryURL()
        {
            return GetServiceURL("Category");
        }
        internal static string GetCheckListStatusUserRolesURL()
        {
            return GetServiceURL("CheckListStatusUserRoles");
        }
        internal static string GetNCStatusURL()
        {
            return GetServiceURL("NCStatus");
        }
        internal static string GetFloorURL()
        {
            return GetServiceURL("Floor");
        }
        internal static string GetBuildingFlatsURL(int BuildingId,int FloorId)
        {
            return string.Format("{0}/api/BuildingFloor/GetUnits?buildingId={1}&floorId={2}", BaseURL, BuildingId,FloorId);

        }
        internal static string GetUnitRoomsURL(int unittypeId)
        {
            return string.Format("{0}/UnitType/GetRoomTypes?unitTypeId={1}", BaseURL, unittypeId);

        }
        internal static string GetBuildingFloorURL(int BuildingId)
        {
            return string.Format("{0}/BuildingFloor/GetFloors?buildingId={1}", BaseURL, BuildingId);

        }
        internal static string GetCheckListStagesURL(int CheckListTypeId)
        {
            return string.Format("{0}/CheckListType/GetStages?checkListTypeId={1}",BaseURL, CheckListTypeId);

        }
        internal static string GetUserRoleURL()
        {
            return GetServiceURL("UserRole");
        }
        internal static string GetStructuralMemberURL()
        {
            return GetServiceURL("StructuralMember");
        }
        internal static string GetStatusGroupURL()
        {
            return GetServiceURL("StatusGroup");
        }
        internal static string GetUnitTypeRoomURL()
        {
            return GetServiceURL("UnitTypeRoom");
        }
        internal static string GetNCStatusRoleURL()
        {
            return GetServiceURL("NCStatusRole");
        }
        internal static string GetBuildingUnitURL()
        {
            return GetServiceURL("BuildingUnit");
        }
        internal static string GetNCURL()
        {
            return GetServiceURL("NC");
        }
        internal static string GetReadyRecknorURL()
        {
            return GetServiceURL("ReadyRecknor");
        }
        internal static string GetCheckListTypeURL()
        {
            return GetServiceURL("CheckListType");
        }
        internal static string GetBuildingURL()
        {
            return GetServiceURL("Building");
        }
        internal static string GetCheckListPointStatusURL()
        {
            return GetServiceURL("CheckListPointStatus");
        }
        internal static string GetCheckListPointStatusURL(int checklisttypeId, int categoryId)
        {
            return string.Format("{0}/CheckListType/GetCheckPoints?checklistTypeId={1}&categoryId={2}",BaseURL, checklisttypeId, categoryId);
        }
        internal static string GetRoomTypeURL()
        {
            return GetServiceURL("RoomType");
        }
        internal static string GetCityURL()
        {
            return GetServiceURL("City");
        }
        internal static string GetProjectURL()
        {
            return GetServiceURL("Project");
        }
        internal static string GetCheckListURL()
        {
            return GetServiceURL("CheckList");
        }
        internal static string GetApprovalCycleURL()
        {
            return GetServiceURL("ApprovalCycle");
        }

        internal static string GetProjectbyUserURL(string loggedUserId)
        {
            return string.Format("{0}/Project/GetByUser?userId={1}", BaseURL,loggedUserId);

        }

        internal static string GetUserCityURL(int userId)
        {
            return string.Format("{0}/Project/GetCityByUser?userId=1", BaseURL, userId);
        }
    }
}
