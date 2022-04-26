using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedHelper.DAL.Entities
{
    public class BaseEntity
    {
        public int GetId()
        {
            var type = GetType();
            var propertyName = type.Name + "ID";

            return (int)type.GetProperty(propertyName).GetValue(this, null);
        }
    }
}
