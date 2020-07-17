using EnglishSalon.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishSalon.Services
{
    public class IndexServices
    {
        public List<QuestionBank> GetData()
        {
            List<QuestionBank> list = new List<QuestionBank>();
            var data = SqlHelper.ExecuteDataTable("select * from QuestionBank");
            foreach (DataRow row in data.Rows)
            {
                list.Add(new QuestionBank()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Number = row["Number"].ToString(),
                    Label = row["Label"].ToString(),
                    Title = row["Title"].ToString(),
                    Options = row["Options"].ToString(),
                    Answer = row["Answer"].ToString(),
                    Value = row["Value"].ToString(),
                    Remark = row["Remark"].ToString()
                });
            }
            return list;
        }

        public string GetGuessWords()
        {
            return GuessWords.GetWord();

            Random random = new Random();
            List<string> list = new List<string>()
            {
                "glasses(眼镜)",
                "chongQing",
                "game",
                "glass",
                "car",
                "satellite(卫星)",
                "Atlantic(大西洋)",
                "Marvel(漫威)",
                "plan",
                "plane",
                "notebook",
                "lunch",
                "kangaroo(袋鼠)",
                "circular(圆形)",
                "mathematics",
                "nurse(护士)",
                "umbrella",
                "panda",
                "The lion king(狮子王)",
                "fish"
            };
            return list[random.Next(list.Count - 1)];
        }

        public void RemoveWord(string word)
        {
            GuessWords.RemoveWord(word);
        }

        public bool ModyfyFlag(int id)
        {
            return SqlHelper.ExecuteNonQuery("update QuestionBank set Flag = 1 where Id=" + id) > 0;
        }

        public List<QuestionBank> GetSummarize()
        {
            List<QuestionBank> list = new List<QuestionBank>();
            var data = SqlHelper.ExecuteDataTable("select [Label],[Value],count(*) [Count] from QuestionBank where Flag=0 group by [Label],[Value] order by [Label],[Value]");
            foreach (DataRow row in data.Rows)
            {
                list.Add(new QuestionBank()
                {
                    Label = row["Label"].ToString(),
                    Value = row["Value"].ToString(),
                    Count = Convert.ToInt32(row["Count"])
                });
            }
            return list;
        }

        public QuestionBank GetQuestionDetail(string Label, string Value)
        {
            var data = SqlHelper.ExecuteDataTable($"select top 1 * from QuestionBank where Flag=0 and Label = '{Label}' and Value = '{Value}'");
            DataRow row = data.Rows[0];
            return new QuestionBank()
            {
                Id = Convert.ToInt32(row["Id"]),
                Number = row["Number"].ToString(),
                Label = row["Label"].ToString(),
                Title = row["Title"].ToString(),
                Options = row["Options"].ToString(),
                Answer = row["Answer"].ToString(),
                TimeOut = Convert.ToInt32(row["TimeOut"]),
                Value = row["Value"].ToString(),
                Remark = row["Remark"].ToString()
            };
        }
    }
}
