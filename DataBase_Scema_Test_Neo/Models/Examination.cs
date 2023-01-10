using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBase_Scema_Test_Neo.Models
{
    public class Examination
    {
        public int Id { get; set; }
        public Candidate Candidate { get; set; }
        public Certificate Certificate { get; set; }
        public ICollection<Question> ExamQuestions { get; set; }

        //Result = CorectAns/MaxScore * 100= x%

    }
}