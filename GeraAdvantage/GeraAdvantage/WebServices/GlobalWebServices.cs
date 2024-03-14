using GeraAdvantage.SQLServices;
using GeraAdvantage.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GeraAdvantage.WebServices
{
    public class GlobalWebServices
    {
        
        public async Task<bool> SyncGlobalData()
        {

            try
            {
                List<User> users = new List<User>();
                List<RootCause> rootCauses = new List<RootCause>();
                List<UnitType> unitTypes = new List<UnitType>();
                List<Severity> severities = new List<Severity>();
                List<Category> categories = new List<Category>();
                List<CheckListStatusUserRoles> checkListStatusUserRoles = new List<CheckListStatusUserRoles>();
                List<CheckListStages> checkListStages = new List<CheckListStages>();
                List<Floor> floors = new List<Floor>();
                List<StructuralMember> structuralMembers = new List<StructuralMember>();
                List<StatusGroup> statusGroups = new List<StatusGroup>();
                List<UnitTypeRoom> unitTypeRooms = new List<UnitTypeRoom>();
                List<NCStatus> nCStatuses = new List<NCStatus>();
                List<NCStatusRole> nCStatusRoles = new List<NCStatusRole>();
                List<BuildingUnit> buildingUnits = new List<BuildingUnit>();
                List<ReadyRecknor> readyRecknors = new List<ReadyRecknor>();
                List<CheckListType> checkListTypes = new List<CheckListType>();
                List<Building> buildings = new List<Building>();
                List<CheckListPointStatus> checkListPointStatuses = new List<CheckListPointStatus>();
                List<RoomType> roomTypes = new List<RoomType>();
                List<City> cities = new List<City>();
                List<Project> projects = new List<Project>();
                List<CheckList> checkLists = new List<CheckList>();
                List<ApprovalCycle> approvalCycles = new List<ApprovalCycle>();

                users = await GetUsersAsync().ConfigureAwait(false);
                rootCauses = await GetRootCauseAsync().ConfigureAwait(false);
                unitTypes = await GetUnitTypeAsync().ConfigureAwait(false);
                severities = await GetSeverityAsync().ConfigureAwait(false);
                categories = await GetCategoryAsync().ConfigureAwait(false);
                checkListStatusUserRoles = await GetCheckListStatusUserRolesAsync().ConfigureAwait(false);
                checkListTypes = await GetCheckListTypeAsync().ConfigureAwait(false);
                floors = await GetFloorAsync().ConfigureAwait(false);
                structuralMembers = await GetStructuralMemberAsync().ConfigureAwait(false);
                statusGroups = await GetStatusGroupAsync().ConfigureAwait(false);
                unitTypeRooms = await GetUnitTypeRoomAsync().ConfigureAwait(false);
                nCStatuses = await GetNCStatusAsync().ConfigureAwait(false);
                nCStatusRoles = await GetNCStatusRoleAsync().ConfigureAwait(false);
                buildingUnits = await GetBuildingUnitAsync().ConfigureAwait(false);
                readyRecknors = await GetReadyRecknorAsync().ConfigureAwait(false);
                buildings = await GetBuildingAsync().ConfigureAwait(false);
                checkListPointStatuses = await GetCheckListPointStatusAsync().ConfigureAwait(false);
                roomTypes = await GetRoomTypeAsync().ConfigureAwait(false);
                cities = await GetCityAsync().ConfigureAwait(false);
                projects = await GetProjectAsync().ConfigureAwait(false);
                checkLists = await GetCheckListAsync().ConfigureAwait(false);
                approvalCycles = await GetApprovalCycleAsync().ConfigureAwait(false);
                var checklisttypeIds = checkListTypes.Select(x => Convert.ToInt32(x.Id)).ToList();
                checkListStages = await GetCheckListStagesAsync(checklisttypeIds).ConfigureAwait(false);


                GlobalSQLServices sQLServices = new GlobalSQLServices();
                bool Saved = sQLServices.SaveAll(users, rootCauses, unitTypes,severities,categories, checkListStatusUserRoles, checkListStages, floors, structuralMembers, statusGroups,
                        unitTypeRooms, nCStatuses, nCStatusRoles, buildingUnits, readyRecknors, checkListTypes, buildings, checkListPointStatuses, roomTypes,
                        cities, projects, checkLists, approvalCycles);
                 return Saved;
            }
            catch (Exception ex)
            {

                return false;

            }
        }

        //public async Task<bool> SyncChecklistData(int buildingID)
        //{

        //    try
        //    {
        //        var buildingFloors=await GetBuildingFloorAsync().ConfigureAwait(false);
        //        var buildingflats=await GetBuildingFlatsAsync().ConfigureAwait(false);
        //        var Unitrooms=await GetUnitRoomAsync().ConfigureAwait(false);
        //        var Usercities=await GetUserCityAsync().ConfigureAwait(false);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public async Task<List<RootCause>> GetRootCauseAsync()
        {
            List<RootCause> RootCauseList = new List<RootCause>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetRootCauseURL());
            //var asd=await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri)).ConfigureAwait(false);
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    RootCauseList = JsonConvert.DeserializeObject<RootCauseList>(content).rootCause;
                return RootCauseList;
            }
            else
            {
                return new List<RootCause>();
            }
        }
        public async Task<List<User>> GetUsersAsync()
        {
            List<User> UsersList = new List<User>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetUserURL());
            //var asd=await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri)).ConfigureAwait(false);
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    UsersList = JsonConvert.DeserializeObject<UserList>(content).data;
                return UsersList;
            }
            else
            {
                return new List<User>();
            }
        }
        public async Task<List<UnitType>> GetUnitTypeAsync()
        {
            List<UnitType> UnitTypeList = new List<UnitType>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetUnitTypeURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    UnitTypeList = JsonConvert.DeserializeObject<UnitTypeList>(content).unitTypeDataModels;
                return UnitTypeList;
            }
            else
            {
                return new List<UnitType>();
            }
        }

        public async Task<bool> GetUsers()
        {
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetUserURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                //if (UtilServices.IsValidJson(content))
                //    UnitTypeList = JsonConvert.DeserializeObject<UnitTypeList>(content).unitTypeDataModels;
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<User> Login(string username, string password,string DeviceID)
        {
            User LoggedUser=null;
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetLoginURL(username,password,DeviceID));
            var response = await client.PostAsync(uri, null).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                {
                    LoggedUser = JsonConvert.DeserializeObject<UserList>(content).data[0];
                    LoggedUser = new SQLConfig().GetItems<User>().FirstOrDefault(x => x.UserName.ToUpper() == username.ToUpper());
                    return LoggedUser;
                }
                else
                    throw new Exception("Username/Password Invalid.");
            }
            else
            {
                throw new Exception("Login Unsuccessful.\nTry Again!");

            }
        }

        public async Task<List<Severity>> GetSeverityAsync()
        {
            List<Severity> SeverityList = new List<Severity>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetSeverityURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    SeverityList = JsonConvert.DeserializeObject<SeverityList>(content).severity;
                return SeverityList;
            }
            else
            {
                return new List<Severity>();
            }
        }
        public async Task<List<Category>> GetCategoryAsync()
        {
            List<Category> CategoryList = new List<Category>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetCategoryURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    CategoryList = JsonConvert.DeserializeObject<CategoryList>(content).categoryDataModels;
                return CategoryList;
            }
            else
            {
                return new List<Category>();
            }
        }
        public async Task<List<CheckListStatusUserRoles>> GetCheckListStatusUserRolesAsync()
        {
            List<CheckListStatusUserRoles> CheckListStatusUserRolesList = new List<CheckListStatusUserRoles>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetCheckListPointStatusURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    CheckListStatusUserRolesList = JsonConvert.DeserializeObject<CheckListStatusUserRolesList>(content).checkListPointStatusDataModel;
                return CheckListStatusUserRolesList;
            }
            else
            {
                return new List<CheckListStatusUserRoles>();
            }
        }
        public async Task<List<CheckListPointStatus>> GetCheckListStatusUserRolesAsync(int checklisttypeId, int categoryId)
        {
            List<CheckListPointStatus> CheckListStatusUserRolesList = new List<CheckListPointStatus>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetCheckListPointStatusURL(checklisttypeId,categoryId));
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    CheckListStatusUserRolesList = JsonConvert.DeserializeObject<CheckListPointStatusList>(content).checkListPointStatusDataModel;
                return CheckListStatusUserRolesList;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
        public async Task<List<NCStatus>> GetNCStatusAsync()
        {
            List<NCStatus> NCStatusList = new List<NCStatus>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetNCStatusURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    NCStatusList = JsonConvert.DeserializeObject<NCStatusList>(content).ncStatusDataModels;
                return NCStatusList;
            }
            else
            {
                return new List<NCStatus>();
            }
        }
        public async Task<List<Floor>> GetFloorAsync()
        {
            List<Floor> FloorList = new List<Floor>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetFloorURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    FloorList = JsonConvert.DeserializeObject<FloorList>(content).floorDataModels;
                return FloorList;
            }
            else
            {
                return new List<Floor>();
            }
        }
        public async Task<List<BuldingFloor>> GetFloorbyUserAsync()
        {
            List<BuldingFloor> FloorList = new List<BuldingFloor>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetFloorURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    FloorList = JsonConvert.DeserializeObject<BuldingFloorList>(content).data;
                return FloorList;
            }
            else
            {
                return new List<BuldingFloor>();
            }
        }
        public async Task<List<BuildingFlat>> GetBuildingFlatsAsync(int buildingId,int floorId)
        {
            List<BuildingFlat> BuildingFloorList = new List<BuildingFlat>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetBuildingFlatsURL(buildingId, floorId));
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    BuildingFloorList = JsonConvert.DeserializeObject<BuildingFlatList>(content).data;
                return BuildingFloorList;
            }
            else
            {
                return new List<BuildingFlat>();
            }
        }
        public async Task<List<UnitRoom>> GetUnitRoomAsync(int unittypeId)
        {
            List<UnitRoom> BuildingFloorList = new List<UnitRoom>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetUnitRoomsURL(unittypeId));
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    BuildingFloorList = JsonConvert.DeserializeObject<UnitRoomList>(content).data;
                return BuildingFloorList;
            }
            else
            {
                return new List<UnitRoom>();
            }
        }
        public async Task<List<BuildingFloor>> GetBuildingFloorAsync(int buildingId)
        {
            List<BuildingFloor> BuildingFloorList = new List<BuildingFloor>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetBuildingFloorURL(buildingId));
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    BuildingFloorList = JsonConvert.DeserializeObject<BuildingFloorList>(content).buildingFloorDataModel;
                return BuildingFloorList;
            }
            else
            {
                return new List<BuildingFloor>();
            }
        }
        public async Task<List<CheckListStages>> GetCheckListStagesAsync(List<int> CheckListTypeIds)
        {
            List<CheckListStages> CheckListStagesList = new List<CheckListStages>();
            HttpClient client = UtilServices.GetHttpClient();
            foreach (var item in CheckListTypeIds)
            {
                List<CheckListStages> ItemCheckListStagesList = new List<CheckListStages>();

                Uri uri = new Uri(URLManager.GetCheckListStagesURL(item));
                var response = await client.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (UtilServices.IsValidJson(content))
                       ItemCheckListStagesList = JsonConvert.DeserializeObject<CheckListStagesList>(content).checkListPointStatusDataModel;
                     CheckListStagesList.AddRange(ItemCheckListStagesList);
                }
                
            }
            return CheckListStagesList;
        }
        public async Task<List<UserRole>> GetUserRoleAsync()
        {
            List<UserRole> UserRoleList = new List<UserRole>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetUserRoleURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    UserRoleList = JsonConvert.DeserializeObject<UserRoleList>(content).roles;
                return UserRoleList;
            }
            else
            {
                return new List<UserRole>();
            }
        }
        public async Task<List<StructuralMember>> GetStructuralMemberAsync()
        {
            List<StructuralMember> StructuralMemberList = new List<StructuralMember>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetStructuralMemberURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    StructuralMemberList = JsonConvert.DeserializeObject<StructuralMemberList>(content).structuralMembers;
                return StructuralMemberList;
            }
            else
            {
                return new List<StructuralMember>();
            }
        }
        public async Task<List<StatusGroup>> GetStatusGroupAsync()
        {
            List<StatusGroup> StatusGroupList = new List<StatusGroup>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetStatusGroupURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    StatusGroupList = JsonConvert.DeserializeObject<StatusGroupList>(content).statusGroup;
                return StatusGroupList;
            }
            else
            {
                return new List<StatusGroup>();
            }
        }
        public async Task<List<UnitTypeRoom>> GetUnitTypeRoomAsync()
        {
            List<UnitTypeRoom> UnitTypeRoomList = new List<UnitTypeRoom>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetUnitTypeRoomURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    UnitTypeRoomList = JsonConvert.DeserializeObject<UnitTypeRoomList>(content).unitTypeRoomDataModel;
                return UnitTypeRoomList;
            }
            else
            {
                return new List<UnitTypeRoom>();
            }
        }
        public async Task<List<NCStatusRole>> GetNCStatusRoleAsync()
        {
            List<NCStatusRole> NCStatusRoleList = new List<NCStatusRole>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetNCStatusRoleURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    NCStatusRoleList = JsonConvert.DeserializeObject<NCStatusRoleList>(content).ncStatusDataRoleModels;
                return NCStatusRoleList;
            }
            else
            {
                return new List<NCStatusRole>();
            }
        }
        public async Task<List<BuildingUnit>> GetBuildingUnitAsync()
        {
            List<BuildingUnit> BuildingUnitList = new List<BuildingUnit>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetBuildingUnitURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    BuildingUnitList = JsonConvert.DeserializeObject<BuildingUnitList>(content).buildingUnitDataModel;
                return BuildingUnitList;
            }
            else
            {
                return new List<BuildingUnit>();
            }
        }
        public async Task<List<ReadyRecknor>> GetReadyRecknorAsync()
        {
            List<ReadyRecknor> ReadyRecknorList = new List<ReadyRecknor>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetReadyRecknorURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    ReadyRecknorList = JsonConvert.DeserializeObject<ReadyRecknorList>(content).readyRecknorDataModels;
                return ReadyRecknorList;
            }
            else
            {
                return new List<ReadyRecknor>();
            }
        }
        public async Task<List<CheckListType>> GetCheckListTypeAsync()
        {
            List<CheckListType> CheckListTypeList = new List<CheckListType>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetCheckListTypeURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    CheckListTypeList = JsonConvert.DeserializeObject<CheckListTypeList>(content).checkListTypes;
                return CheckListTypeList;
            }
            else
            {
                return new List<CheckListType>();
            }
        }
        public async Task<List<Building>> GetBuildingAsync()
        {
            List<Building> BuildingList = new List<Building>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetBuildingURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    BuildingList = JsonConvert.DeserializeObject<BuildingList>(content).buildingDataModels;
                return BuildingList;
            }
            else
            {
                return new List<Building>();
            }
        }
        public async Task<List<CheckListPointStatus>> GetCheckListPointStatusAsync()
        {
            List<CheckListPointStatus> CheckListPointStatusList = new List<CheckListPointStatus>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetCheckListPointStatusURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    CheckListPointStatusList = JsonConvert.DeserializeObject<CheckListPointStatusList>(content).checkListPointStatusDataModel;
                return CheckListPointStatusList;
            }
            else
            {
                return new List<CheckListPointStatus>();
            }
        }
        public async Task<List<RoomType>> GetRoomTypeAsync()
        {
            List<RoomType> RoomTypeList = new List<RoomType>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetRoomTypeURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    RoomTypeList = JsonConvert.DeserializeObject<RoomTypeList>(content).roomType;
                return RoomTypeList;
            }
            else
            {
                return new List<RoomType>();
            }
        }
        public async Task<List<City>> GetCityAsync()
        {
            List<City> CityList = new List<City>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetCityURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    CityList = JsonConvert.DeserializeObject<CityList>(content).cityDataModels;
                return CityList;
            }
            else
            {
                return new List<City>();
            }
        }
        public async Task<List<UserCity>> GetUserCityAsync(int userId)
        {
            List<UserCity> CityList = new List<UserCity>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetUserCityURL(userId));
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    CityList = JsonConvert.DeserializeObject<UserCityList>(content).data;
                return CityList;
            }
            else
            {
                return new List<UserCity>();
            }
        }
        public async Task<List<Project>> GetProjectAsync()
        {
            List<Project> ProjectList = new List<Project>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetProjectURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    ProjectList = JsonConvert.DeserializeObject<ProjectList>(content).projectDataModels;
                return ProjectList;
            }
            else
            {
                return new List<Project>();
            }
        }
        public async Task<List<Project>> GetProjectsbyUser(string loggedUserId)
        {
            List<Project> ProjectList = new List<Project>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetProjectbyUserURL(loggedUserId));
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    ProjectList = JsonConvert.DeserializeObject<ProjectList>(content).projectDataModels;
                return ProjectList;
            }
            else
            {
                return new List<Project>();
            }
        }
        public async Task<List<CheckList>> GetCheckListAsync()
        {
            List<CheckList> CheckListList = new List<CheckList>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetCheckListURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    CheckListList = JsonConvert.DeserializeObject<List<CheckList>>(content);
                return CheckListList;
            }
            else
            {
                return new List<CheckList>();
            }
        }
        public async Task<List<ApprovalCycle>> GetApprovalCycleAsync()
        {
            List<ApprovalCycle> ApprovalCycleList = new List<ApprovalCycle>();
            HttpClient client = UtilServices.GetHttpClient();

            Uri uri = new Uri(URLManager.GetApprovalCycleURL());
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                if (UtilServices.IsValidJson(content))
                    ApprovalCycleList = JsonConvert.DeserializeObject<List<ApprovalCycle>>(content);
                return ApprovalCycleList;
            }
            else
            {
                return new List<ApprovalCycle>();
            }
        }
    }
}
