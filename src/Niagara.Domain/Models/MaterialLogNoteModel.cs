namespace Niagara.Domain.Models
{
    public class MaterialLogNoteModel
    {
        public int Id { get; set; }

        public string MaterialLogLotNumber { get; set; }

        public string Text { get; set; }

        public string CreatedBy { get; set; }

        public string DateCreated { get; set; }

        public string TimeCreated { get; set; }
    }
}