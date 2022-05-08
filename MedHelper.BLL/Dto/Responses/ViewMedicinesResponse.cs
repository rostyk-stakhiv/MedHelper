using System;
using System.Collections.Generic;
using System.Text;

namespace MedHelper.BLL.Dto.Responses
{
    public class ViewMedicinesResponse
    {
        public List<MedicineResponse> Medicines { get; set; }
        public string? search { get; set; }
    }
}
