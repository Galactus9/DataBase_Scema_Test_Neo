﻿using DataBase_Scema_Test_Neo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataBase_Scema_Test_Neo.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=MyConectionString") 
        {
        }
        public  DbSet<Certificate> Certificate { get; set; }
        public  DbSet<Topic> Topics { get; set; }
        public  DbSet<Question> Questions { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<SelectedAnswers> SelectedAnswers { get; set; }
    }
}
                                                                //Candidate Cascade on Delete