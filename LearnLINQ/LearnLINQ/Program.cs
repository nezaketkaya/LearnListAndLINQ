using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnLINQ
{
    class Program
    {
        static void Main()
        {
            List<Language> languages = File.ReadAllLines("./languages.tsv")
              .Skip(1)
              .Select(line => Language.FromTsv(line))
              .ToList();

            foreach (var language in languages)
            {
                Console.WriteLine(language.Prettify());
            }

            var languageInfo = languages.Select(language => language.Prettify());
            foreach (var info in languageInfo)
            {
                Console.WriteLine(info);
            }

            var cSharpLang = languages.Where(language => language.Name == "C#")
            .Select(language => language.Name);
            foreach (var lang in cSharpLang)
            {
                Console.WriteLine(lang);
            }

            var microsoftChief = languages.Where(chief => chief.ChiefDeveloper == "Microsoft")
            .Select(chief => chief.ChiefDeveloper);
            foreach (var chief in microsoftChief)
            {
                Console.WriteLine(chief);
            }

            var preLisp = languages.Where(prelisp => prelisp.Predecessors.Contains("Lisp"))
            .Select(prelisp => prelisp.Predecessors);
            foreach (var prelisp in preLisp)
            {
                Console.WriteLine(prelisp);
            }

            var scriptLanguages = languages
            .Where(language => language.Name.Contains("Script"))
            .Select(language => language.Name);

            foreach (var scriptLanguage in scriptLanguages)
            {
                Console.WriteLine(scriptLanguage);
            }

            int count = languages.Count();
            Console.WriteLine(count);

            var between = languages.Where(year => year.Year >= 1995 && year.Year <= 2005)
           .Select(language => $"{language.Name} was invented in {language.Year}");

            int cnt = between.Count();
            Console.WriteLine(cnt);
            foreach (var v in between)
            {
                Console.WriteLine(v);
            }

            static void PrettyPrintAll(IEnumerable<Language> languageCollection)
            {
                foreach (var language in languageCollection)
                {
                    Console.WriteLine(language.Prettify());
                }
            }

            static void foreachPrintAll(IEnumerable<object> objectCollection)
            {
                foreach (var obj in objectCollection)
                {
                    Console.WriteLine(obj);
                }
            }
        }
    }
}
