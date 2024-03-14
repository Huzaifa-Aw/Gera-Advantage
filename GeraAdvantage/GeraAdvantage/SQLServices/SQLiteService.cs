using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GeraAdvantage.SQLServices
{
    public class SQLiteService
    {
        public static string defaultDBName = "GeraAdvDB";
        readonly SQLiteConnection database;
        public SQLiteService()
        {
            var appName = "GeraAdvantage"; 
            string DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), defaultDBName + ".sqlite");
            Stream embeddedDatabaseStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(appName + "." + defaultDBName + ".sqlite");
            //Stream embeddedDatabaseStream = Assembly.GetManifestResourceStream(appName + "." + defaultDBName + ".sqlite");


            if (!File.Exists(DatabasePath))
            {
                FileStream fileStreamToWrite = File.Create(DatabasePath);
                embeddedDatabaseStream.Seek(0, SeekOrigin.Begin);
                embeddedDatabaseStream.CopyTo(fileStreamToWrite);

            }
            database = new SQLiteConnection(DatabasePath);
        }
        string GetPath(string databaseName)
        {
            if (string.IsNullOrWhiteSpace(databaseName))
            {
                throw new ArgumentException("Invalid database name", nameof(databaseName));
            }

            string DBName = databaseName + ".sqlite";
            var path = GetLocalFilePath(DBName);
            return path;
        }

        public SQLiteConnection GetConnection(string databaseName)
        {
            return new SQLiteConnection(GetPath(databaseName));
        }

        public long GetSize(string databaseName)
        {
            var fileInfo = new FileInfo(GetPath(databaseName));
            return fileInfo != null ? fileInfo.Length : 0;
        }

        public static string GetLocalFilePath(string DBName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dbPath = Path.Combine(path, DBName);

            //CopyDatabaseIfNotExists(dbPath, DBName);

            return dbPath;
        }

        //private static void CopyDatabaseIfNotExists(string dbPath, string DBName)
        //{
        //    if (!File.Exists(dbPath))
        //    {
        //        Stream input = Application.Context.Assets.Open(DBName);
        //        using (var br = new BinaryReader(Application.Context.Assets.Open(DBName)))
        //        {
        //            using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
        //            {
        //                byte[] buffer = new byte[2048];
        //                int length = 0;
        //                while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
        //                {
        //                    bw.Write(buffer, 0, length);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
