using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vision.Utility
{
  public class DateTimeModelBinderAttribute : ModelBinderAttribute
  {
    public string DateFormat { get; set; }

    public DateTimeModelBinderAttribute()
        : base(typeof(DateTimeModelBinder))
    {
    }
  }
}
