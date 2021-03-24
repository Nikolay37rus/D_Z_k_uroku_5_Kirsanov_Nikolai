// Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
//а) Вывести только те слова сообщения,  которые содержат не более n букв.
//б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
//в) Найти самое длинное слово сообщения.
//г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
//д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него передается массив слов и текст, 
//в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary.


using System;
using System.Text;
using System.Collections.Generic;

namespace ClassMessage
{

    static class Message
    {
        static public string text;

        static Message()
        {
            text = "Дохлая овца, распухшая и вздувшаяся, нацелившаяся в небо окостеневшими ногами, пошевелилась. Геральт, сидевший на корточках у стены, медленно вытащил меч, следя за тем, чтобы клинок не звякнул об оковку ножен. " +
                "В десяти шагах от него куча отбросов неожиданно взгорбилась и заколебалась. Ведьмак вскочил прежде, чем до него дошла волна вони, исторгнутой из порушенного скопища мусора и отбросов. " +
                "Оканчивающееся веретенообразным утолщением шипастое щупальце, неожиданно вырвавшееся из-под мусора, устремилось к нему с невероятной скоростью. " +
                "Ведьмак мгновенно запрыгнул на останки разбитого шкафа, балансирующие на куче гнилых овощей, удержал равновесие, одним коротким движением меча рассек щупальце, отрубив палицеобразную присоску. ";
        }

       
        static public void GetWordsByLength(int len)
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            //Console.WriteLine("Вывод слов, длинной не более " + len + ": " );
            foreach (string word in words)
            {
                if (word == "")
                    continue;
                if (word.Length <= len)
                    Console.Write(word + " ");
            }
        }

       
        static public void DeleteWordByEndChar(char ch)
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            //Console.WriteLine("Будут удалены слова, оканчивающиеся на символ '" + ch + "': ");
            foreach (string word in words)
            {
                if (word == "")
                    continue;
                if (word[word.Length - 1] == ch)
                {
                    Console.Write(word + " ");
                    text.Replace(word, "");
                }
            }
            
        }

        static public string FindMaxLengthWord()
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            string maxWord = words[0];
            int max = words[0].Length;

            foreach (string word in words)
            {
                if (word.Length > max)
                {
                    max = word.Length;
                    maxWord = word;
                }
            }
            
            return maxWord;
        }

       
        static public StringBuilder GetLongWordsString()
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            StringBuilder result = new StringBuilder();
            int max = Message.FindMaxLengthWord().Length;
            foreach (string word in words)
            {
                if (word.Length == max)
                {
                    result.Append(word.ToLower() + " ");
                }
            }
           
            return result;
        }

       
        static public void FrequencyAnalysis(string[] words, string text)
        {
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

            string[] textWords = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            foreach (string word in words)
            {
                foreach (string wordInText in textWords)
                {
                    if (word == "")
                        continue;
                    if (wordInText == word)
                    {
                        if (word == "")
                            continue;
                        if (wordFrequency.ContainsKey(word))
                            wordFrequency[word] += 1;
                        else
                            wordFrequency.Add(word, 1);
                    }
                }
            }
           
            ICollection<string> keys = wordFrequency.Keys;

            String result = String.Format("{0,-10} {1,-10}\n\n", "Слово", "Частота появления");

            foreach (string key in keys)
                result += String.Format("{0,-10} {1,-10:N0}\n",
                                   key, wordFrequency[key]);
            Console.WriteLine($"\n{result}");
        }
    }
}
