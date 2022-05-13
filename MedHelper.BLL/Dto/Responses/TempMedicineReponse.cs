using System.Collections.Generic;

namespace MedHelper.BLL.Dto.Responses
{
    public class TempMedicineResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PharmacotherapeuticGroupResponse Group { get; set; }

        public List<DiseaseResponse> Contraindications { get; set; }
        public List<CompositionResponse> Compositions { get; set; }
        public List<MedicineInteractionResponse> MedicineInteractions { get; set; }

        public string? search {get; set;}
    }
}