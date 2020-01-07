using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vision.Models
{
  public class Image
  {
    public int Id { get; set; }
    public string ImagePath { get; set; }
    public string ImageFileName { get; set; }
    public int ImageTypeId { get; set; }
    public string ImageType { get; set; }
    public int LineId { get; set; }
    public string Line { get; set; }
    public int CameraId { get; set; }
    public string Camera { get; set; }
    public int CameraLocationId { get; set; }
    public string CameraLocation { get; set; }
    public DateTime ImageDateTime { get; set; }
    public string DisplayImageDateTime { get; set; }
    public int ImageNumber { get; set; }
    public bool Active { get; set; }
    public bool Processed { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public string DisplayCreatedDateTime { get; set; }
    public string DefectType { get; set; }
    public string Shift { get; set; }
    public int DefectCount { get; set; }
  }
}
