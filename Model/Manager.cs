using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOOD
{
    public class Manager
    {
        public int id;
        public string userEmail;
        public string staffTag;
       
        
        public Manager(int Id, string UserEmail, string StaffTag)
        {
            id = Id;
            userEmail = UserEmail;
            staffTag = StaffTag;
            
        }
    }
}