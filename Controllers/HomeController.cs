using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppSpotr_Test.Models;
using AppSpotr_Test.Models.CustomModel;

namespace AppSpotr.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //this words can read from any source Database,Text file or ...
            StreamReader sreader = new StreamReader("words.txt"); //path of the file
            string strFileContent = sreader.ReadToEnd(); //Read all the content
            sreader.Close();
            string[] words = strFileContent.Split(new char[] { ' ', '\r', '\n', ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<TagsModel> TagsWords =EachRowLength(words);
            return View(TagsWords);
        }

        private List<TagsModel> EachRowLength(string[] words)
        {
            int charCount = 0;
            TagsModel tags = new TagsModel();

            List<TagsModel> TagsList = new List<TagsModel>();
            List<TagsModel> EachRowLength = new List<TagsModel>();
            int wordsNumber = words.Length;
            for (int i = 0; i < words.Length; i++)
            {
                int currentWord = words[i].ToCharArray().Length;
                if (charCount + currentWord == 99 || charCount + currentWord < 100)
                {
                    TagsList.Add(new TagsModel { TagsName = words[i] });
                    charCount += words[i].ToCharArray().Length + 1;
                }
                else
                {
                    EachRowLength.Add(new TagsModel { EachRow = TagsList });
                    TagsList = new List<TagsModel>();
                    charCount = 0;
                }

            }
            return EachRowLength;
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
