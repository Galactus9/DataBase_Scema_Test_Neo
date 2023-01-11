using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBase_Scema_Test_Neo.Models
{
	public class ExamQuestions
	{
		public int Id { get; set; }

		public virtual ICollection<PullOfQuestion> ExaminationQuestions { get; set; }
	}
}