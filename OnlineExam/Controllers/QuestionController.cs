using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using OnlineExam.Models;
using System.Data;

namespace OnlineExam.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public MySqlConnection con=new MySqlConnection("Server=localhost;Database=online;Uid=root;Pwd=root;");
        
        public List<Question> disp()
        {
            var listofQuestions = new List<Question>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = string.Format("Select * from onlinetest");
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Question obj = new Question();
                obj.QId = Convert.ToInt32(dr["QNo"]);
                obj.Quest = dr["Ques"].ToString();
                obj.Option1 = dr["Option1"].ToString();
                obj.Option2 = dr["Option2"].ToString();
                obj.Option3 = dr["Option3"].ToString();
                obj.Option4 = dr["Option4"].ToString();
                obj.answer = dr["Answer"].ToString();
                listofQuestions.Add(obj);
            }
            return listofQuestions;   
        }
        public ActionResult Display()
        {
            return View(disp());
        }

        public void evaluate()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = string.Format("Select ")
        }

    }
}