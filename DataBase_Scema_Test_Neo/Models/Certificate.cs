using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBase_Scema_Test_Neo.Models
{
    public class Certificate

    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
		public ICollection<Examination> examinations { get; set; }
		private int PossibleMarks { get; set; } // = Topics.Question.Count // Topic.SubjectWeight.Sum()

    }
}