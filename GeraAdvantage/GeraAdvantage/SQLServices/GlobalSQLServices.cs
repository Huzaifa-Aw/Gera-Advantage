using GeraAdvantage.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeraAdvantage.SQLServices
{
    internal class GlobalSQLServices
    {
        SQLConfig sql_SC;
        public GlobalSQLServices()
        {
            sql_SC = new SQLConfig();

        }
        public bool SaveAll(List<User> users, List<RootCause> rootCauses, List<UnitType> unitTypes,List<Severity> severities,List<Category> categories, List<CheckListStatusUserRoles> checkListStatusUserRoles, List<CheckListStages> checkListStages,
                                List<Floor> floors, List<StructuralMember> structuralMembers, List<StatusGroup> statusGroups, List<UnitTypeRoom> unitTypeRooms,
                                List<NCStatus> nCStatuses, List<NCStatusRole> nCStatusRoles, List<BuildingUnit> buildingUnits, List<ReadyRecknor> readyRecknors, List<CheckListType> checkListTypes,
                                List<Building> buildings, List<CheckListPointStatus> checkListPointStatuses, List<RoomType> roomTypes, List<City> cities, List<Project> projects,
                                List<CheckList> checkLists, List<ApprovalCycle> approvalCycles)
        {
            try
            {
                sql_SC.DeleteAllData();

                if (users.Count > 0)
                    sql_SC.InsertAll(users);

                if (rootCauses.Count > 0)
                    sql_SC.InsertAll(rootCauses);

                if (unitTypes.Count > 0)
                    sql_SC.InsertAll(unitTypes);

                if (severities.Count > 0)
                    sql_SC.InsertAll(severities);

                if (categories.Count > 0)
                    sql_SC.InsertAll(categories);

                //if (checkListStatusUserRoles.Count > 0)
                //    sql_SC.InsertAll(checkListStatusUserRoles);

                if (checkListStages.Count > 0)
                    sql_SC.InsertAll(checkListStages);

                if (floors.Count > 0)
                    sql_SC.InsertAll(floors);

                if (structuralMembers.Count > 0)
                    sql_SC.InsertAll(structuralMembers);

                if (statusGroups.Count > 0)
                    sql_SC.InsertAll(statusGroups);

                if (unitTypeRooms.Count > 0)
                    sql_SC.InsertAll(unitTypeRooms);

                if (nCStatuses.Count > 0)
                    sql_SC.InsertAll(nCStatuses);

                if (nCStatusRoles.Count > 0)
                    sql_SC.InsertAll(nCStatusRoles);

                if (buildingUnits.Count > 0)
                    sql_SC.InsertAll(buildingUnits);

                if (readyRecknors.Count > 0)
                    sql_SC.InsertAll(readyRecknors);

                if (checkListTypes.Count > 0)
                    sql_SC.InsertAll(checkListTypes);

                if (buildings.Count > 0)
                    sql_SC.InsertAll(buildings);

                //if (checkListPointStatuses.Count > 0)
                //    sql_SC.InsertAll(checkListPointStatuses);

                if (roomTypes.Count > 0)
                    sql_SC.InsertAll(roomTypes);

                if (cities.Count > 0)
                    sql_SC.InsertAll(cities);

                if (projects.Count > 0)
                    sql_SC.InsertAll(projects);

                if (checkLists.Count > 0)
                    sql_SC.InsertAll(checkLists);

                if (approvalCycles.Count > 0)
                    sql_SC.InsertAll(approvalCycles);
                return true;
            }
            catch (Exception ex)
            {

                return false;

            }
        }
        public Building GetBuilding(string Id)
        {
            return sql_SC.GetItems<Building>().FirstOrDefault(x => x.Id == Id);
        }
        //public List<Project> GetProjectsbyUser(string userId)
        //{
        //    return sql_SC.GetItems<Project>().Where(x => x.UserId == userId).ToList();
        //}
        public Project GetProject(string Id)
        {
            return sql_SC.GetItems<Project>().FirstOrDefault(x => x.Id == Id);
        }
        public UnitType GetUnit(string Id)
        {
            return sql_SC.GetItems<UnitType>().FirstOrDefault(x => x.Id == Id);
        }
        public RoomType GetRoom(string Id)
        {
            return sql_SC.GetItems<RoomType>().FirstOrDefault(x => x.Id == Id);
        }
        public Floor GetFloor(string Id)
        {
            return sql_SC.GetItems<Floor>().FirstOrDefault(x => x.Id == Id);
        }
        public Category GetCategory(string Id)
        {
            return sql_SC.GetItems<Category>().FirstOrDefault(x => x.Id == Id);
        }
        public RootCause GetRootCause(string Id)
        {
            return sql_SC.GetItems<RootCause>().FirstOrDefault(x => x.Id == Id);
        }
        public Severity GetSeverity(string Id)
        {
            return sql_SC.GetItems<Severity>().FirstOrDefault(x => x.Id == Id);
        }
        public NCStatus GetNCStatus(string Id)
        {
            return sql_SC.GetItems<NCStatus>().FirstOrDefault(x => x.Id == Id);
        }
        public User GetUser(string Id)
        {
            return sql_SC.GetItems<User>().FirstOrDefault(x => x.Id == Id);
        }


    }
}
