using CarCatalog.Service.Messages.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Service.Messages.Response
{
    public class UserResponse : BusinessObject
    {
        public string UserName { get; set; }
        public string Avatar { get; set; }
    }
}
