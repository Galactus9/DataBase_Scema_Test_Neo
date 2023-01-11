﻿using DataBase_Scema_Test_Neo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBase_Scema_Test_Neo.Models
{
    public class Examination
    {
        public int Id { get; set; }

        public  ICollection<int> SelectedAnswers { get; set; }
        public ExamQuestions ExamQuestions { get; set; }


    }
}