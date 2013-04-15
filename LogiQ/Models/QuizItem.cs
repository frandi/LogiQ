using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

    public class UserQuizItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }
        public string VisitedQuiz { get; set; }
    }

    #region View Models

    public class UserQuizView : QuizItem
    {
        public int UserId { get; set; }
        public bool Visited { get; set; }
    }

    #endregion View Models

    public enum QuizItemType
    {
        All, Unvisited, Visited
    }
}