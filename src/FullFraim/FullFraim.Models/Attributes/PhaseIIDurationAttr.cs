using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FullFraim.Models.Attributes
{
    public class PhaseIIDurationAttr : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var valueAsInt = (int)value;

            if(valueAsInt < 1 || valueAsInt > 24)
            {
                return false;
            }

            return true;
        }
    }
}
