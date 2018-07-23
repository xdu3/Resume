using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xin.Models
{
    public class FullDes
    {
        public Description Descriptions { get; set; }
        public List<DesDetails> DesDetails { get; set; }
        public FullDes()
        {
            this.Descriptions = Descriptions;
            this.DesDetails = DesDetails;
        }
    }
}
