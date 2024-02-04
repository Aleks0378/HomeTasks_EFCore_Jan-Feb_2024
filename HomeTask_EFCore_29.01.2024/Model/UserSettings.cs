using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_EFCore_29._01._2024.Model
{
    public class UserSettings
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
