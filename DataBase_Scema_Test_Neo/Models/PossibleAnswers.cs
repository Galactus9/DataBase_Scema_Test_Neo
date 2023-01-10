using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBase_Scema_Test_Neo.Models
{
    public class PossibleAnswers
    {
        public int Id { get; set; }
        public Object CorectAnswer { get; set; }
        public Object OtherAnswer1 { get; set; }
        public Object OtherAnswer2 { get; set; }
        public Object OtherAnswer3 { get; set; }



		//In the view you can check the type of the property and decide which one to show (string or image)

//		@if(Model.MyProperty is string)
//		{
//	        < p > @Model.MyProperty </ p >
//      }
//      else if (Model.MyProperty is Image)
//{
//          <img src = "@Model.MyProperty" />
//}


}
}