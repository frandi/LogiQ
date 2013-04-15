using LogiQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogiQ
{
    public static class LogiQuiz
    {
        public static IEnumerable<UserQuizView> GetUserQuizes(int userId, QuizItemType type)
        {
            IEnumerable<UserQuizView> items = null;

            LogiQContext db = new LogiQContext();

            if (userId > 0)
            {
                var visited = (from uq in db.UserQuizItems
                               where uq.UserID == userId
                               select uq.VisitedQuiz).FirstOrDefault();

                if (type == QuizItemType.All)
                {
                    items = (from q in db.QuizItems
                             orderby q.CreatedDate
                             select q).AsEnumerable()
                            .Select(q => MapQuizItem(q, userId, type))
                            .ToList();

                    if (!string.IsNullOrEmpty(visited))
                    {
                        var qArr = visited.Split(';').Select(q => Guid.Parse(q));
                        foreach (var item in items)
                        {
                            item.Visited = qArr.Contains(item.ID);
                        }
                    }
                }
                else if (type == QuizItemType.Unvisited)
                {
                    List<Guid> qArr = new List<Guid>();
                    if (!string.IsNullOrEmpty(visited))
                    {
                        qArr = visited.Split(';').Select(q => Guid.Parse(q)).ToList();
                    }

                    items = (from q in db.QuizItems
                             where !qArr.Contains(q.ID)
                             select q).AsEnumerable()
                            .Select(q => MapQuizItem(q, userId, type))
                            .ToList();
                }
                else if (type == QuizItemType.Visited)
                {
                    if (!string.IsNullOrEmpty(visited))
                    {
                        var qArr = visited.Split(';').Select(q => Guid.Parse(q));
                        items = (from q in db.QuizItems
                                 where qArr.Contains(q.ID)
                                 select q).AsEnumerable()
                                .Select(q => MapQuizItem(q, userId, type))
                                .ToList();
                    }


                }
            }
            else
            {
                items = (from q in db.QuizItems
                         orderby q.CreatedDate
                         select q).AsEnumerable()
                        .Select(q => MapQuizItem(q, userId, type))
                        .ToList();
            }

            return items;
        }

        public static UserQuizView MapQuizItem(QuizItem qItem, int userId, QuizItemType type)
        {
            UserQuizView qView = null;

            if (qItem != null)
            {
                qView.ID = qItem.ID;
                qView.Title = qItem.Title;
                qView.Question = qItem.Question;
                qView.RightAnswer = qItem.RightAnswer;
                qView.CreatedDate = qItem.CreatedDate;
                qView.UpdatedDate = qItem.UpdatedDate;
                qView.UserId = userId;
                qView.Visited = type == QuizItemType.Visited;
            }

            return qView;
        }
    }
}