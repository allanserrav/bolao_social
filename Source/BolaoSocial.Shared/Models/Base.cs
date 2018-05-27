using BolaoSocial.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolaoSocial.Shared.Models
{
    public class Base : IModel
    {
        #region IModel

        public int Id { get; set; }

        public string Codigo { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public bool ObjDesabilitado { get; set; }

        #endregion
    }
}
