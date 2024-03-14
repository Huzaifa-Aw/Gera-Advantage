﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GeraAdvantage.iOS;
using Foundation;
using SQLite;
using GeraAdvantage.Models;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace GeraAdvantage.iOS
{
    public class SQLite_iOS : ISQLite
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
            string sql = $"SELECT * FROM Assessment WHERE CourseId=" + id;
            List<NCAndCModel> Assessments = con.Query<NCAndCModel>(sql);
            return Assessments;
        }
       
        public void DeleteNCAndC(int Id)
        {
            string sql = $"DELETE FROM Assessment WHERE Id={Id}";
            con.Execute(sql);
        }
    }
}