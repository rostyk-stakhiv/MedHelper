using MedHelper.BLL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedHelper.BLL.Models
{
    public partial class RoleModel : BaseModel
    {
        [EnumDataType(typeof(RoleModel))]
        public string UserRole { get; set; }

    }
}
