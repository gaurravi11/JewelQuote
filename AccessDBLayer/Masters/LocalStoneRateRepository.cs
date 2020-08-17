using AccessDBLayer.Helper;
using Dapper;
using ModelLayer.Masters;
using ServiceLayer.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDBLayer.Masters
{
    public class LocalStoneRateRepository : IStoneRateRepository
    {
        public IEnumerable<StoneRateModel> GetStoneRate(short StoneType)
        {
            try
            {
                String query = @"Select * from tbl_StoneRate where StoneType = @StoneType";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("StoneType", StoneType);
                return DapperOleDBManager.GetListObject<StoneRateModel>(query, parameters);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public IEnumerable<StoneRateModel> GetStoneWeight(short StoneType)
        {
            try
            {
                String query = @"Select * from tbl_StoneRate where StoneType = @StoneType";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("StoneType", StoneType);
                return DapperOleDBManager.GetListObject<StoneRateModel>(query, parameters);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string UpdateStoneRate(StoneRateModel stoneRateModel)
        {
            try
            {
                String query = @"Update tbl_StoneRate set Rate = @Rate where StoneId = @StoneId and ShapeId = @ShapeId and StoneType = @StoneType";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Rate", stoneRateModel.Rate);
                parameters.Add("StoneId", stoneRateModel.StoneId);
                parameters.Add("ShapeId", stoneRateModel.ShapeId);
                parameters.Add("StoneType", stoneRateModel.StoneType);
                bool val = DapperOleDBManager.WriteToDb(query, parameters);
                if (val == true)
                    return "Stone Rate Updated";
                else
                    return "Something went wrong";
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string UpdateStoneWeight(StoneRateModel stoneRateModel)
        {

            try
            {
                String query = @"Update tbl_StoneRate set Weight = @Weight where StoneId = @StoneId and ShapeId = @ShapeId and StoneType = @StoneType";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Weight", stoneRateModel.Weight);
                parameters.Add("StoneId", stoneRateModel.StoneId);
                parameters.Add("ShapeId", stoneRateModel.ShapeId);
                parameters.Add("StoneType", stoneRateModel.StoneType);
                bool val = DapperOleDBManager.WriteToDb(query, parameters);
                if (val == true)
                    return "Stone Weight Updated";
                else
                    return "Something went wrong";
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
