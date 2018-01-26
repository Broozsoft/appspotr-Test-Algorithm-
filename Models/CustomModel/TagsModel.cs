using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppSpotr_Test.Models.CustomModel
{
    public class TagsModel
    {
        public string TagsName { get; set; }
        public List<TagsModel> EachRow { get; set; }
    }
}