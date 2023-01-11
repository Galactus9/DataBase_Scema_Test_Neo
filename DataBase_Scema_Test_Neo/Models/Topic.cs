using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBase_Scema_Test_Neo.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SubjectWeight { get; set; }
        public virtual ICollection<PullOfQuestion> Questions { get; set; }
    }
}
// test Bella push