using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Vision.Managers;
using Vision.Utility;
/// <summary>
/// Project :   Vision Incpection
/// Author  :   Santosh Kumar Senapati
/// Date    :   7th Jan 2019 
/// </summary>
namespace Vision.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class ImagesController : ControllerBase
  {
    private readonly ImageManager _imageManager;
    public ImagesController()
    {
      this._imageManager = new ImageManager();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> GetTailSealTree([FromBody]JObject dateTime)
    {
      DateTime imgTimeStamp = _extractDate(dateTime);
      return Ok(await _imageManager.sp_TailSeal_TreeList_SELECT(imgTimeStamp));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> GetWrapperInspectionTree([FromBody]JObject dateTime)
    {
      DateTime imgTimeStamp = _extractDate(dateTime);
      return Ok(await _imageManager.sp_WrapperInspection_TreeList_SELECT(imgTimeStamp));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="jsonData"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> PostTreeListImages([FromBody]JObject jsonData)
    {
      int imageTypeId = jsonData.SelectToken("imageTypeId").Value<int>();
      int lineId = jsonData.SelectToken("lineId").Value<int>();
      int defectTypeId = jsonData.SelectToken("defectTypeId").Value<int>();
      DateTime imgTimeStamp = _extractDate(jsonData);
      return Ok(await _imageManager.sp_Images_TreeList_SELECT(imageTypeId, lineId, defectTypeId, imgTimeStamp));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="jsonData"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> PostShiftDefectSummary([FromBody]JObject jsonData)
    {
      int imageTypeId = jsonData.SelectToken("imageTypeId").Value<int>();
      int lineId = jsonData.SelectToken("lineId").Value<int>();
      return Ok(await _imageManager.sp_Shift_Images_SELECT(imageTypeId, lineId));
    }



    #region Helper functions

    private static DateTime _extractDate(JObject dateTime)
    {
      DateTime actualDateTime = new DateTime();
      JToken imageDateTimeToken;
      var isImageDateValid = dateTime.TryGetValue("dateTime", out imageDateTimeToken);
      if (isImageDateValid && imageDateTimeToken.Value<string>() != "")
        actualDateTime = dateTime.SelectToken("dateTime").Value<DateTime>();
      return actualDateTime;
    }

    #endregion
  }
}
