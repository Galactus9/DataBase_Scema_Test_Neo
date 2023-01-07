using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBase_Scema_Test_Neo.Models
{
    public class SelectedAnswers
    {
        public int Id { get; set; }
        public Candidate Candidate { get; set; }
        public Certificate Certificate { get; set; }
        public Question ExamQuestion { get; set; }
        public string SelectedAnswer { get; set; }
        //public Examination Examination { get; set; }


    }
}