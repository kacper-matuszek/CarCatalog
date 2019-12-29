using CarCatalog.Service.Messages.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Service.Messages.Request
{
    public class UserRequest : BusinessObject
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
    }

    public class UserRequestValidator : BusinessObjectValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 20);
        }
    }
}
