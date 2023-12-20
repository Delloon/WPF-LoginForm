using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_LoginForm
{
    internal class QuotesList
    {
        private string[] quotes =
        {
            "Самостоятельность не означает одиночество.",
            "Слова ничего не значат, пока не превратишь их в поступки.",
            "Защита слабых — долг сильных. Иначе мы жили бы посреди хаоса.",
        };

        public string GetRandomQuote()
        {
            Random random = new Random();
            int index = random.Next(quotes.Length);
            return quotes[index];
        }
    }
}
