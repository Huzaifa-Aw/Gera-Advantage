using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GeraAdvantage.Droid;
using SQLite;
using GeraAdvantage;
using Xamarin.Forms;
using GeraAdvantage.Models;

[assembly:Dependency(typeof(SQLite_Android))]
namespace GeraAdvantage.Droid
{
    class SQLite_Android : ISQLite
    {
        SQLiteConnection con;
        public SQLiteConnection GetConnectionWithCreateDatabase()
        {
            string fileName = "sampleDatabase.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentPath, fileName);
            con = new SQLiteConnection(path);
            con.CreateTable<NCAndCModel>();
           
            return con;
        }
    


        public bool SaveNCAndC(NCAndCModel assessment)
        {
            bool res = false;
            try
            {
                con.Insert(assessment);
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }
        public List<NCAndCModel> GetNCAndC(int id)
        {
            string sql = $"SELECT * FROM NCAndCModel WHERE Id=" + id;
            List<NCAndCModel> Assessments = con.Query<NCAndCModel>(sql);
            return Assessments;
        }
     

        public void DeleteNCAndC(int Id)
        {
            string sql = $"DELETE FROM NCAndCModel WHERE Id={Id}";
            con.Execute(sql);
        }
    }   
}