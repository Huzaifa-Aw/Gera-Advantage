using GeraAdvantage.Models;
using SQLite;

using System;
using System.Collections.Generic;
using System.Text;


namespace GeraAdvantage
{
    public interface ISQLite
    {
        SQLiteConnection GetConnectionWithCreateDatabase();

        bool SaveNCAndC(NCAndCModel assessment);
        List<NCAndCModel> GetNCAndC(int id);

        void DeleteNCAndC(int Id);


    }
}
