using CarCatalog.Service.Messages.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Service.Messages.Response
{
    public class CatalogResponse : BusinessObject
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserResponse User { get; set; }
    }
}
