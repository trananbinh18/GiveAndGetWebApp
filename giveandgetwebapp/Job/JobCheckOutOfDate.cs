using FluentScheduler;
using giveandgetwebapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace giveandgetwebapp.Job
{
    public class JobCheckOutOfDate : IJob
    {
        public void Execute()
        {
            cap22t6Entities dbEntity = new cap22t6Entities();
            Array arrPostOutOfDate = dbEntity.Posts.Where(x => x.ExpireDate <= DateTime.Now).ToArray();
            foreach (Post post in arrPostOutOfDate) {
                post.Status = 2;
                Notification notification = new Notification();
                notification.PostId = post.Id;
                notification.UserId = post.Actor ?? default(int);
                notification.Status = 1;
                notification.CreateDate = DateTime.Now;
                notification.Title = "Bài viết "+post.Title+" đã hết hạn";
                notification.Contents = "Bài viết " + post.Title + " đã hết hạn, click vào để cho đồ";
                notification.Type = 2;

                dbEntity.Notifications.Add(notification);
            }

            dbEntity.SaveChanges();

                
        }
    }
}