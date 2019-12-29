using CarCatalog.Service.Messages.Base;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarCatalog.Service.Messages
{
    public class PostMessageInterceptor : IValidatorInterceptor
    {
        public ValidationResult AfterMvcValidation(ControllerContext controllerContext, ValidationContext validationContext, ValidationResult result)
        {
            var error = result.Errors.Where(x => x.PropertyName == "Id").FirstOrDefault();

            if (result.Errors.Contains(error))
                result.Errors.Remove(error);

            return result;
        }

        public ValidationContext BeforeMvcValidation(ControllerContext controllerContext, ValidationContext validationContext)
        {
            return validationContext;
        }
    }
}
