using CarCatalog.Service.Messages.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Service.Messages.Request
{
    public class CatalogRequest : BusinessObject
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserRequest User { get; set; }
    }

    public class CatalogRequestValidator : BusinessObjectValidator<CatalogRequest>
    {
        public CatalogRequestValidator()
        {
            RuleFor(x => x.CreatedDate).NotEmpty().LessThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.Name).NotEmpty().Length(5, 20);
            RuleFor(x => x.User).SetValidator(new UserRequestValidator());
        }
    }
}
