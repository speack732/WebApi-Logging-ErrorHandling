using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Example.Core
{
    public class VehicleIncentive
    {

        public int VehicleId { get; set; }


        public int IncentiveId { get; set; }



        public Vehicle Vehicle { get; set; }

        
        public Incentive Incentive { get; set; }


        [Required]
        public DateTime ValidTill { get; set; }

    }
}
