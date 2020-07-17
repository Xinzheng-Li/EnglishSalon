using EnglishSalon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnglishSalon.Models;

namespace EnglishSalon.Controllers
{
    public class IndexController : Controller
    {
        IndexServices services = new IndexServices();
        // GET: Index
        public ActionResult Index()
        {
            var data = services.GetSummarize();
            ViewData["QuestionsCount"] = data;
            return View();
        }

        public ActionResult GuessWords()
        {
            var data = services.GetGuessWords();
            ViewBag.Word = data;
            return View();
        }
        public ActionResult QuestionDetail(string Label,string Value)
        {
            var data = services.GetQuestionDetail(Label,Value);
            ViewBag.QuestionsDetail = data;
            return View();
        }
        public ActionResult SubmitAndBack(int Id)
        {
            var result = services.ModyfyFlag(Id);
            Response.Redirect("Index");
            return View();
        }

        public ActionResult GetGuessWords(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                services.RemoveWord(word);
            }
            ViewBag.Word = services.GetGuessWords();
            return View();
        }
    }
}