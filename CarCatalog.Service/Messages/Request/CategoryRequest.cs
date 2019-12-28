using CarCatalog.Service.Messages.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Service.Messages.Request
{
    public class CategoryRequest : BusinessObject
    {
        public string Name { get; set; }
        public string PictureName { get; set; }
    }

    public class CategoryRequestValidator : BusinessObjectValidator<CategoryRequest>
    {
        public CategoryRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
