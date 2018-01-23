using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedLimitFollowup.Core.classes {
    public class Officer {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rank { get; set; }
        public int BadgeId { get; set; }

        public Citation PullOver(Driver driver) {
            throw new NotImplementedException();
        }
    }
}
