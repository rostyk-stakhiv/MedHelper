using MedHelper.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedHelper.BLL.Models
{
    public partial class RoleModel : BaseModel
    {
        public RoleModel()
        {
            this.Users = new HashSet<UserModel>();
        }

        public int RoleID { get; set; }

        [EnumDataType(typeof(RoleModel))]
        public string UserRole { get; set; }

        public virtual ICollection<UserModel> Users { get; set; }
    }
}