using GeraAdvantage.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeraAdvantage.SQLServices
{
    public class NCSQLServices
    {
        SQLConfig sql_SC;
        public NCSQLServices()
        {
            sql_SC = new SQLConfig();

        }
        public bool SaveNC(NC nC)
        {
            bool ret = false;
            try
            {
                ret = sql_SC.Insert(nC);
                return ret;
            }
            catch (Exception ex)
            {
                return ret;
            }
        }
        public NC GetNCbyId(string Id)
        {
            return sql_SC.GetItems<NC>().FirstOrDefault(x => x.Id == Id);
        }
        public List<NC> GetNCs()
        {
            return sql_SC.GetItems<NC>().Where(x => x.NCCode == "NC").ToList();
        }
        public List<NC> GetCs()
        {
            return sql_SC.GetItems<NC>().Where(x => x.NCCode == "C").ToList();
        }
    }
}
