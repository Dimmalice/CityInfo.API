﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class LocalMailService
    {

        private string _mailTo = "amin@mycompany.com";
        private string _mailFrom = "noreply@mycompany.com";

        public void Send (string subject, string message)

        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }




    }
}
