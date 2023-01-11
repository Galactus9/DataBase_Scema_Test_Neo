using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBase_Scema_Test_Neo.Models
{
    public class PullOfQuestionPerTopic
    {
        public int Id { get; set; }
        public string TextOfQuestion { get; set; }       
        public PossibleAnswers possibleAnswers { get; set; }
        public ICollection<ExamQuestions> ExamWhat { get; set; }

    }
}