using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vision.Models
{
  public class ImageTypeTree
  {
    public int ID { get; set; }
    public int? ReportsTo { get; set; }
    public string Name { get; set; }
    public string Line { get; set; }
    public int DefectCount { get; set; }
    public int LineId { get; set; }
    public int ImageTypeId { get; set; }
    public int DefectTypeId { get; set; }
  }
}
