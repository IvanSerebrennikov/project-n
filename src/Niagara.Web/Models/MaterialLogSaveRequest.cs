using Niagara.Domain.Models;

namespace Niagara.Web.Models
{
    public class MaterialLogSaveRequest
    {
        public MaterialLogModel MaterialLog { get; set; }

        public string PartNumber { get; set; }

        public string Supplier { get; set; }
    }
}