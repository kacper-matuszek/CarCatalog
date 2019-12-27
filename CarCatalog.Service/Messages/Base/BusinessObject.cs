using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Service.Messages.Base
{
    public abstract class BusinessObject
    {
        public Guid Id { get; set; }
    }

    public abstract class BusinessObjectValidator<T> : AbstractValidator<T> where T : BusinessObject
    {
        public BusinessObjectValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
