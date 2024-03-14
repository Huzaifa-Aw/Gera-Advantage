using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace GeraAdvantage.Utils
{
    internal class Entities
    {
        public enum Status { Pending, Sent_To_QA, Approved, Pending_For_NC_Closure };
        public class Grouping<K, T> : ObservableCollection<T>
        {
            public K Key { get; private set; }

            public Grouping(K key, IEnumerable<T> items)
            {
                Key = key;
                foreach (var item in items)
                    this.Items.Add(item);
            }
        }
        public class FilterDetail
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public bool IsChecked { get; set; }
        }
        public class ConformityPie
        {
            public string Title { get; set; }
            public int Count { get; set; }
        }
        public class ReviewQ
        {

            public string Title { get; set; }
            public Color BGColor { get; set; }
            public string BtnText { get; set; }
        }
        public class MultileOps
        {
            public string Title { get; set; }
            public string Severity { get; set; }
            public bool isfour { get; set; }
            public bool isthree { get; set; }
            public bool ConverttoNC { get; set; }
            public bool AddImage { get; set; }
            public bool SEComment { get; set; }
            public bool btnYes { get; set; }
            public bool btnNo { get; set; }
            public bool btnNA { get; set; }
            public bool btnA { get; set; }
            public bool btnAWC { get; set; }
            public bool btnR { get; set; }
            public List<ImageSource> Images { get; set; }
            public List<PlaceType> Places { get; set; }
        }
        public class PlaceType
        {
            public string Title { get; set; }
            public bool IsChecked { get; set; }
        }
        public class SampleChart
        {
            public string Name { get; set; }
            public double Number { get; set; }
        }
        public class FilterType
        {
            public string Type { get; set; }
        }
        public class Project
        {
            public string Title { get; set; }
            public int TotalNCCount { get; set; }
            public int OpenNCCount { get; set; }
            public int ClosedNCCount { get; set; }
            public string Severity { get; set; }

        }
        public class StakeHolder
        {
            public string Name { get; set; }
            public string Designation { get; set; }
        }
        public class NCHistory
        {
            public string Status { get; set; }
            public string Comment { get; set; }
            public string UpdatedBy { get; set; }
            public string UpdatedAt { get; set; }

        }
        public class Checklist
        {
            public string Title { get; set; }
            public string Building { get; set; }
            public string Floor { get; set; }
            public string Category { get; set; }
            public string CreatedBy { get; set; }
            public string UpdatedBy { get; set; }
            public Status Cstatus { get; set; }
            public string ProjDate { get; set; }
            public string Deadline { get; set; }
            public bool IsPast { get; set; }

        }
        public class NCDisplayModel
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Building { get; set; }
            public string Floor { get; set; }
            public string Category { get; set; }
            public string CreatedBy { get; set; }
            public string UpdatedBy { get; set; }
            public string Cstatus { get; set; }
            public string ProjDate { get; set; }
            public string Deadline { get; set; }
            public bool IsPast { get; set; }

        }
    }
    public class NCPhotos
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        public long NCId { get; set; }
        public long UploadedBy { get; set; }
        public DateTime UploadedOn { get; set; }
        public string Filename { get; set; }
        public long StatusId { get; set; }
        public string CommentId { get; set; }
        public string FileId { get; set; }
    }
    public class NC
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string NCCode { get; set; }
        public long ProjectId { get; set; }
        public bool IsPotential { get; set; }
        public long BuildingId { get; set; }
        public long FloorId { get; set; }
        public long UnitTypeId { get; set; }
        public long UnitId { get; set; }
        public long RoomTypeId { get; set; }
        public long CategoryId { get; set; }
        public long SubCategoryId { get; set; }
        public long RootCauseId { get; set; }
        public long SeverityId { get; set; }
        public long ContractorId { get; set; }
        public long EngineerId { get; set; }
        public DateTime DeadlineDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long StatusId { get; set; }
        public bool IsChecklistLinked { get; set; }
        public string CorrectiveAction { get; set; }
        public string PrevenctiveAction { get; set; }
    }
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public int UserRoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string DeviceId { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastLoggedInOn { get; set; }
    }

    public class UserList
    {
        [JsonProperty("data")]
        public List<User> data { get; set; }
    }


    public class BuildingList
    {
        [JsonProperty("data")]
        public List<Building> buildingDataModels { get; set; }
    }
    public class Building
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Title { get; set; }
        public long ProjectId { get; set; }


    }
    public class BuildingFlatList
    {
        [JsonProperty("data")]
        public List<BuildingFlat> data { get; set; }
    }
    public class BuildingFlat
    { }
    public class UnitRoomList
    {
        [JsonProperty("data")]
        public List<UnitRoom> data { get; set; }
    }
    public class UnitRoom
    {
        public int Id { get; set; }
        public int UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
    }
    public class BuildingFloorList
    {
        [JsonProperty("data")]
        public List<BuildingFloor> buildingFloorDataModel { get; set; }
    }
    public class BuildingFloor
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public long FloorId { get; set; }
        public long BuildingId { get; set; }

    }
    public class BuildingUnitList
    {
        [JsonProperty("data")]
        public List<BuildingUnit> buildingUnitDataModel { get; set; }
    }
    public class BuildingUnit
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public long BuildingFloorId { get; set; }
        public string Title { get; set; }
        public long UnitTypeId { get; set; }


    }
    public class CheckListStatusUserRolesList
    {
        [JsonProperty("data")]
        public List<CheckListStatusUserRoles> checkListPointStatusDataModel { get; set; }
    }
    public class CheckListStatusUserRoles
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public int ChecklistPointStatusId { get; set; }
        public string Title { get; set; }
        public string DisplayText { get; set; }
        public bool ShowCommentBox { get; set; }
        public bool ShowNCButton { get; set; }
        public string ButtonImage { get; set; }
        public string ButtonImageSelected { get; set; }
        public string ButtonColour { get; set; }
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class CheckListStagesList
    {
        [JsonProperty("data")]
        public List<CheckListStages> checkListPointStatusDataModel { get; set; }
    }
    public class CheckListStages
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public int ChecklistTypeId { get; set; }
        public string Title { get; set; }
        public int StageNo { get; set; }
    }
    public class CheckList
    {

    }
    public class ApprovalCycle
    {

    }
    public class CheckListPointStatusList
    {
        [JsonProperty("data")]
        public List<CheckListPointStatus> checkListPointStatusDataModel { get; set; }
    }
    public class CheckListPointStatus
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string DisplayText { get; set; }
        public bool ShowNCButton { get; set; }
        public string ButtonImage { get; set; }
        public string ButtonImageSelected { get; set; }
        public string ButtonColour { get; set; }
    }
    public class CheckListTypeList
    {
        [JsonProperty("data")]
        public List<CheckListType> checkListTypes { get; set; }
    }
    public class CheckListType
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public long NoOfStages { get; set; }
        public bool AllowMultipleSelection { get; set; }
    }
    public class CategoryList
    {
        [JsonProperty("data")]
        public List<Category> categoryDataModels { get; set; }
    }
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Title { get; set; }
        public long ParentCategoryId { get; set; }

    }
    public class UserCityList
    {
        [JsonProperty("data")]
        public List<UserCity> data { get; set; }
    }

    public class UserCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public int UserProjectsId { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
    }

    public class CityList
    {
        [JsonProperty("data")]
        public List<City> cityDataModels { get; set; }
    }

    public class City
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        [JsonProperty("Title")]
        public string Name { get; set; }

    }
    public class FloorList
    {
        [JsonProperty("data")]
        public List<Floor> floorDataModels { get; set; }
    }
    public class Floor
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Title { get; set; }
        public long FloorNo { get; set; }

    }

    public class BuldingFloorList
    {
        [JsonProperty("data")]
        public List<BuldingFloor> data { get; set; }
    }
    public class BuldingFloor
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Title { get; set; }
        public long FloorNo { get; set; }

    }

    public class NCStatusList
    {
        [JsonProperty("data")]
        public List<NCStatus> ncStatusDataModels { get; set; }
    }
    public class NCStatus
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Title { get; set; }
        public long StatusGroupId { get; set; }

    }
    public class NCStatusRoleList
    {
        [JsonProperty("data")]
        public List<NCStatusRole> ncStatusDataRoleModels { get; set; }
    }
    public class NCStatusRole
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public long NCStatusId { get; set; }
        public long UserRoleId { get; set; }
    }
    public class ProjectList
    {
        [JsonProperty("data")]
        public List<Project> projectDataModels { get; set; }
    }
    public class Project
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Name { get; set; }
        public long CityId { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string UserId { get; set; }
        public string UserProjectsId { get; set; }

    }
}
public class ReadyRecknorList
{
    [JsonProperty("data")]
    public List<ReadyRecknor> readyRecknorDataModels { get; set; }
}
public class ReadyRecknor
{
    [PrimaryKey, AutoIncrement]
    public string Id { get; set; }
    public string CategoryId { get; set; }
    public string Title { get; set; }
    public string File { get; set; }

}
public class RoomTypeList
{
    [JsonProperty("data")]
    public List<RoomType> roomType { get; set; }
}

public class RoomType
{
    [PrimaryKey, AutoIncrement]
    public string Id { get; set; }
    public string Title { get; set; }
}
public class RootCauseList
{
    [JsonProperty("data")]
    public List<RootCause> rootCause { get; set; }
}
public class RootCause
{
    [PrimaryKey, AutoIncrement]
    public string Id { get; set; }
    public string Title { get; set; }
}
public class SeverityList
{
    [JsonProperty("data")]
    public List<Severity> severity { get; set; }
}
public class Severity
{
    [PrimaryKey, AutoIncrement]
    public string Id { get; set; }
    public string Title { get; set; }
}
public class StatusGroupList
{
    [JsonProperty("data")]
    public List<StatusGroup> statusGroup { get; set; }
}

public class StatusGroup
{
    [PrimaryKey, AutoIncrement]
    public string Id { get; set; }
    public string Title { get; set; }
}
public class StructuralMemberList
{
    [JsonProperty("data")]
    public List<StructuralMember> structuralMembers { get; set; }
}
public class StructuralMember
{
    [PrimaryKey, AutoIncrement]
    public string Id { get; set; }
    public string Title { get; set; }
}
public class UnitTypeList
{
    [JsonProperty("data")]
    public List<UnitType> unitTypeDataModels { get; set; }
}
public class UnitType
{
    [PrimaryKey, AutoIncrement]
    public string Id { get; set; }
    public string Title { get; set; }
    public long ParentUnitTypeId { get; set; }
}
public class UnitTypeRoomList
{
    [JsonProperty("data")]
    public List<UnitTypeRoom> unitTypeRoomDataModel { get; set; }
}

public class UnitTypeRoom
{
    [PrimaryKey, AutoIncrement]
    public string Id { get; set; }
    public long UnitTypeId { get; set; }
    public long RoomTypeId { get; set; }
}

public class UserRoleList
{
    [JsonProperty("data")]
    public List<UserRole> roles { get; set; }
}
public class UserRole
{
    [PrimaryKey, AutoIncrement]
    public string Id { get; set; }
    public string Title { get; set; }
}

