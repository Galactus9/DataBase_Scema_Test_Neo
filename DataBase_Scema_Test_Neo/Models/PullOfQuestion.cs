using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBase_Scema_Test_Neo.Models
{
    public class PullOfQuestion
    {
        public int Id { get; set; }
        public string TextOfQuestion { get; set; }       
        public virtual PossibleAnswers possibleAnswers { get; set; }



	}
}