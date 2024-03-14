using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeraAdvantage.Models
{
    public  class NCAndCModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NCCode { get; set; }
        public string IsPotential { get; set; }
        public string ProjectId { get; set; }
        public string buildingId { get; set; }
        public string floorId { get; set; }
        public string flatId { get; set; }
        public string Side { get; set; }
        public string Resposible { get; set; }
        public string UnitTypeId { get; set; }
        public string UnitId { get; set; }
        public string RoomTypeId { get; set; }
        public string CategoryId { get; set; }
        public string SubCategoryId { get; set; }
        public string RouteCaseId { get; set; }
        public string SaverityId { get; set; }
        public string ContractorId { get; set; }
        public string EngneerId { get; set; }
        public string Image { get; set; }

    }
}
