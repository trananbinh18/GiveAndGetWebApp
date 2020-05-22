using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace giveandgetwebapp.Models
{
    public class SendEmailModel
    {
        public string receiver { get; set; }

        public string subject { get; set; }

        public string message { get; set; }
    }
}