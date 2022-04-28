using MedHelper.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedHelper.DAL.Entities
{
    public partial class Role : BaseEntity
    {
        [EnumDataType(typeof(Role))]
        public string UserRole { get; set; }

        public List<User> Users { get; set; }
    }
}