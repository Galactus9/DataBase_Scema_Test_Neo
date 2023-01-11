using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBase_Scema_Test_Neo.Models
{
    public class PossibleAnswers
    {
        public int Id { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
		public string Answer4 { get; set; }
        public int Index { get; set; }
	}
}