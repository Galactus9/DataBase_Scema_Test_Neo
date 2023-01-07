using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBase_Scema_Test_Neo.Models
{
    public class PossibleAnswers
    {
        public int Id { get; set; }
        public string CorectAnswer { get; set; }
        public string OtherAnswer1 { get; set; }
        public string OtherAnswer2 { get; set; }
        public string OtherAnswer3 { get; set; }
    }
}