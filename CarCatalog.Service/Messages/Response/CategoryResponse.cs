using CarCatalog.Service.Messages.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Service.Messages.Response
{
    public class CategoryResponse : BusinessObject
    {
        public string Name { get; set; }
        public string PictureName { get; set; }
    }
}
