using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishSalon.Models
{
    public static class GuessWords
    {
        private static List<string> list;
        public static string GetWord()
        {
            if (list == null)
            {
                list = new List<string>();
                string[] arr = new string[] {"glasses(眼镜)",
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
                "fish"};
                list.AddRange(arr);
            }
            Random random = new Random();
            return list[random.Next(list.Count - 1)];
        }
        public static void RemoveWord(string Word)
        {
            if (string.IsNullOrEmpty(Word));
            list.Remove(Word);
        }
    }
}
