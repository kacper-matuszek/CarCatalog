using CarCatalog.Service.Messages.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Service.Messages.Request
{
    public class UserRequest : BusinessObject
    {
        public string UserName { get; set; }
        public string Avatar { get; set; }
    }

    public class CreateUserRequestValidation : BusinessObjectValidator<UserRequest>
    {
        public CreateUserRequestValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().Length(3, 20);
        }
    }
}
