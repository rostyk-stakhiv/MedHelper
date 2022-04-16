using MedHelper.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedHelper.DAL.Entities
{
    public partial class Role : BaseEntity
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }

        public int RoleID { get; set; }

        [EnumDataType(typeof(Role))]
        public string UserRole { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
