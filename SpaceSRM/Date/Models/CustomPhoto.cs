using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSRM.Date.Models
{
    public class CustomPhoto
    {
        
        public Image ImageC { get; set; } = new Image();
        public Photo photo { get; set; } = new Photo();
        public override bool Equals(object obj)
        {
            if (!(obj is CustomPhoto other))
            {
                return false;
            }

            return this.ImageC.Equals(other.ImageC);
        }
    }
}
