using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class QuestionPaper
    {
        public List<QuestionMaster> QuestionList { get; set; }
        public List<AnswerMaster> AnswerList { get; set; }
    }
}
