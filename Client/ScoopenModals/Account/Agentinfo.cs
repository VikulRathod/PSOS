using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoopenAPIModals.Account
{
    public partial class Agentinfo
    {
        public int AgentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AgentPassword { get; set; }
        public Nullable<long> PhoneNumber { get; set; }
        public string Agent_Address { get; set; }
        public string Zipcode { get; set; }
    }
}
