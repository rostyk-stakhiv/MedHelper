using MedHelper.BLL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedHelper.Web.Models
{
    public partial class RoleModel : BaseModel
    {

        [EnumDataType(typeof(RoleModel))]
        public string UserRole { get; set; }

    }
}
