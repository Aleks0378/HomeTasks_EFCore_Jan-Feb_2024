using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_EFCore_26._01._2024.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public int LoginAttempts { get; set; } = 0;
        public bool IsLocked { get; set; }=false;
    }
}
