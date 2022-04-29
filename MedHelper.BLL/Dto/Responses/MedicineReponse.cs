using System.Collections.Generic;

namespace MedHelper_API.Responses
{
    public class MedicineResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public PharmacotherapeuticGroupResponse Group { get; set; }
        
        public List<DiseaseResponse> Contraindications { get; set; }
        public List<CompositionResponse> Compositions { get; set; }
        public List<MedicineInteractionResponse> MedicineInteractions { get; set; }
    }
}