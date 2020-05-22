using giveandgetwebapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Mvc;
using System.Net.Http;
using System.Text;

namespace giveandgetwebapp.Controllers
{
    public class PublicAPIController : ApiController
    {
        private cap22t6Entities db = new cap22t6Entities();
        private string emailSender = "giveandgetvanlanggr6@gmail.com";
        private string passwordEmailSender = "vancuong123";
        private string emailSenderName = "Give And Get";
        private string bodyEmailVerify = @"<p>Bạn đã đăng ký give and get app, hãy click vào đường đẫn <a href='<replaceblockURL>'>Này</a> để xác nhận </p>";


        public JsonResult RegisterUser(RegisterUserModel model) {
            string messageError = "";

            if (ModelState.IsValid)
            {
                //Is email exist in db
                User userFind = db.Users.Where(x => x.Email == model.email).FirstOrDefault();
                if (userFind != null) {
                    messageError = "Email này đã được đăng ký";
                    ErrorMessageModel errorMessageModel1 = new ErrorMessageModel();
                    errorMessageModel1.errorMessage = messageError;
                    return new JsonResult()
                    {
                        ContentType = "application/json",
                        Data = errorMessageModel1,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }

                string stringToken = Guid.NewGuid().ToString();
                User user = new User();
                user.Avatar = 1;
                user.StudentId = model.mssv;
                user.Name = model.name;
                user.Password = model.password;
                user.Email = model.email;
                user.Phone = model.phone;
                user.IsVerify = false;
                user.VerifyToken = stringToken;

                db.Users.Add(user);
                db.SaveChanges();

                String verifyURL = Url.Link("API Default", new { controller = "PublicAPI", action = "verifyUser" });
                verifyURL += "?id=" + user.Id + "&token=" + user.VerifyToken;

                SendEmailVerify(user.Email, user.Name, verifyURL);

            }

            foreach (var error in ModelState.Values.SelectMany(modelState => modelState.Errors)) {
                messageError += error.ErrorMessage + "\n";
            }

            ErrorMessageModel errorMessageModel = new ErrorMessageModel();
            errorMessageModel.errorMessage = messageError;
            return new JsonResult() {
                ContentType = "application/json",
                Data = errorMessageModel,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };



        }

        [System.Web.Http.AcceptVerbs("GET")]
        public HttpResponseMessage verifyUser(int id, string token) {
            var result = new StringBuilder();

            //build a string

            var res = Request.CreateResponse(HttpStatusCode.OK);

            User user = db.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user != null) {
                user.IsVerify = true;
                db.SaveChanges();

                
                res.Content = new StringContent("<p>Bạn đã verify thành công.</p>", Encoding.UTF8, "text/html");

                return res;
            }

            res.Content = new StringContent("<p>Trang Không tồn tại.</p>", Encoding.UTF8, "text/html");

            return res;

        }

        private void SendEmailVerify(string email, string name, string url)
        {
            try
            {
                    var senderEmail = new MailAddress(this.emailSender, this.emailSenderName);
                    var receiverEmail = new MailAddress(email, name);
                    var password = this.passwordEmailSender;
                    var sub = "Xác nhận Email từ Give and Get";
                    var body = this.bodyEmailVerify.Replace("<replaceblockURL>",url);
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        IsBodyHtml = true,
                        Subject = "Xác nhận Email từ Give and Get",
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
            }
            catch (Exception)
            {
                
            }
        }
    }
}