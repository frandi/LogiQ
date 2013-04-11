using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogiQ.Models
{
    public class QuizItem
    {
        [Key]
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public string RightAnswer { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}