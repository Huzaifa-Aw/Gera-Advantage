using GeraAdvantage.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GeraAdvantage.SQLServices
{
    public class SQLConfig
    {
        static readonly object locker = new object();
        SQLiteService SQLite = new SQLiteService();

        readonly SQLiteConnection connection;
        readonly string DatabaseName;

        public SQLConfig()
        {
            DatabaseName = SQLiteService.defaultDBName;
            connection = SQLite.GetConnection(DatabaseName);
        }
        public SQLConfig(string databaseName)
        {
            DatabaseName = databaseName;
            connection = SQLite.GetConnection(DatabaseName);
        }
        public void CreateTable<T>()
        {
            lock (locker)
            {
                connection.CreateTable<T>();
            }
        }

        public long GetSize()
        {
            return SQLite.GetSize(DatabaseName);
        }

        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }
        public void Dispose()
        {
            connection.Dispose();
        }
        public void Commit()
        {
            connection.Commit();
        }

        public bool Update<T>(T item)
        {
            lock (locker)
            {
                int i = connection.Update(item);
                if (i > 0)
                {
                    return true;
                }
                else return false;
            }
        }


        public void ExecuteQuery(string query, object[] args)
        {
            lock (locker)
            {
                connection.Execute(query, args);
            }
        }



        public List<T> Query<T>(string query, object[] args) where T : new()
        {
            lock (locker)
            {
                return connection.Query<T>(query, args);
            }
        }

        public IEnumerable<T> GetItems<T>() where T : new()
        {
            lock (locker)
            {

                return (from i in connection.Table<T>() select i).ToList();
            }
        }


        public int DeleteItem<T>(int id)
        {
            lock (locker)
            {
                return connection.Delete<T>(id);
            }
        }

        public int DeleteAll<T>(string ClassName)
        {
            lock (locker)
            {
                var ret = connection.DeleteAll<T>();
                string Query = string.Format("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='{0}'; ", ClassName);
                connection.Execute(Query, new List<object>().ToArray());
                return ret;
            }
        }
        public void DeleteAllData()
        {
            lock (locker)
            {
                var ret = connection.DeleteAll<BuildingUnit>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='BuildingUnit'; ", new List<object>().ToArray());
            }
            lock (locker)
            {
               var ret = connection.DeleteAll<BuildingFloor>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='BuildingFloor'; ", new List<object>().ToArray());
            }
            lock (locker)
            {
                var ret = connection.DeleteAll<Building>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='Building'; ", new List<object>().ToArray());
            }
            lock (locker)
            {
                var ret = connection.DeleteAll<UnitTypeRoom>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='UnitTypeRoom'; ", new List<object>().ToArray());
            }
            lock (locker)
            {
                var ret = connection.DeleteAll<UnitType>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='UnitType'; ", new List<object>().ToArray());
            }
            lock (locker)
            {
                var ret = connection.DeleteAll<StructuralMember>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='StructuralMember'; ", new List<object>().ToArray());
            }
            lock (locker)
            {
                var ret = connection.DeleteAll<RootCause>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='RootCause'; ", new List<object>().ToArray());

            }
            lock (locker)
            {
                var ret = connection.DeleteAll<Severity>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='Severity'; ", new List<object>().ToArray());

            }
            lock (locker)
            {
                var ret = connection.DeleteAll<Category>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='Category'; ", new List<object>().ToArray());

            }
            lock (locker)
            {
                var ret = connection.DeleteAll<NCStatusRole>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='NCStatusRole'; ", new List<object>().ToArray());

            }
            lock (locker)
            {
                var ret = connection.DeleteAll<NCStatus>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='NCStatus'; ", new List<object>().ToArray());

            }
            lock (locker)
            {
                var ret = connection.DeleteAll<StatusGroup>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='StatusGroup'; ", new List<object>().ToArray());

            }
            lock (locker)
            {
                var ret = connection.DeleteAll<RoomType>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='RoomType'; ", new List<object>().ToArray());

            }
            lock (locker)
            {
                var ret = connection.DeleteAll<Floor>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='Floor'; ", new List<object>().ToArray());

            }
            lock (locker)
            {
                var ret = connection.DeleteAll<Project>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='Project'; ", new List<object>().ToArray());

            }
            lock (locker)
            {
                var ret = connection.DeleteAll<City>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='City'; ", new List<object>().ToArray());

            }
            lock (locker)
            {
                var ret = connection.DeleteAll<UserRole>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='UserRole'; ", new List<object>().ToArray());

            }
            lock (locker)
            {
                var ret = connection.DeleteAll<User>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='User'; ", new List<object>().ToArray());
            }
            lock (locker)
            {
                var ret = connection.DeleteAll<CheckListType>();
                connection.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='CheckListType'; ", new List<object>().ToArray());
            }

        }

        public bool Insert<T>(T item)
        {
            lock (locker)
            {
                int i = connection.Insert(item);
                if (i > 0)
                {
                    return true;
                }
                else return false;
            }

        }
        public bool InsertAll<T>(List<T> item)
        {
            lock (locker)
            {
                int i = connection.InsertAll(item,true);
                if (i > 0)
                {
                    return true;
                }
                else return false;
            }

        }


    }
}