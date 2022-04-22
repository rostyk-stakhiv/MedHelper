using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHelper.BLL.Models
{
    public partial class DiseaseModel: BaseModel
    {
        public string Title { get; set; }


        public override string ToString()
        {
            return Title;
        }
    }
}
