using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Vision.Models;

namespace Vision.Managers
{
  public sealed class ImageManager
  {
    public async Task<IEnumerable<ImageTypeTree>> sp_TailSeal_TreeList_SELECT(DateTime dateTime)
    {
      var tstList = new List<ImageTypeTree>().AsEnumerable<ImageTypeTree>();
      using (SqlConnection connection = new SqlConnection(Startup.ConnectionString))
      {
        var queryParameters = new DynamicParameters();
        queryParameters.Add("@ImageDateTime", dateTime);
        tstList = await connection.QueryAsync<ImageTypeTree>("sp_TailSeal_TreeList_SELECT", queryParameters, commandType: CommandType.StoredProcedure);
      }      
      return tstList;
    }

    public async Task<IEnumerable<ImageTypeTree>> sp_WrapperInspection_TreeList_SELECT(DateTime dateTime)
    {
      var tstList = new List<ImageTypeTree>().AsEnumerable<ImageTypeTree>();
      using (SqlConnection connection = new SqlConnection(Startup.ConnectionString))
      {
        var queryParameters = new DynamicParameters();
        queryParameters.Add("@ImageDateTime", dateTime);
        tstList = await connection.QueryAsync<ImageTypeTree>("sp_WrapperInspection_TreeList_SELECT", queryParameters, commandType: CommandType.StoredProcedure);
      }
      return tstList;
    }

    public async Task<IEnumerable<Image>> sp_Images_TreeList_SELECT(int imageTypeId, int lineId, int defectTypeId, DateTime imgTimeStamp)
    {
      var tList = new List<Image>().AsEnumerable<Image>();
      using (SqlConnection connection = new SqlConnection(Startup.ConnectionString))
      {
        var queryParameters = new DynamicParameters();
        queryParameters.Add("@ImageTypeId", imageTypeId, DbType.Int32);
        queryParameters.Add("@LineId", lineId, DbType.Int32);
        if (defectTypeId != 0)
          queryParameters.Add("@DefectTypeId", defectTypeId, DbType.Int32);
        if (imgTimeStamp != default(DateTime))
          queryParameters.Add("@ImageDateTime", imgTimeStamp,DbType.DateTime);
        tList = await connection.QueryAsync<Image>("sp_Images_TreeList_SELECT", queryParameters, commandType: CommandType.StoredProcedure);
      }
      return tList;
    }

    public async Task<IEnumerable<Image>> sp_Shift_Images_SELECT(int imageTypeId, int lineId)
    {
      var tList = new List<Image>().AsEnumerable<Image>();
      using (SqlConnection connection = new SqlConnection(Startup.ConnectionString))
      {
        var queryParameters = new DynamicParameters();
        queryParameters.Add("@ImageTypeId", imageTypeId, DbType.Int32);
        queryParameters.Add("@LineId", lineId, DbType.Int32);
        tList = await connection.QueryAsync<Image>("sp_Shift_Images_SELECT", queryParameters, commandType: CommandType.StoredProcedure);
      }
      return tList;
    }
  }
}
