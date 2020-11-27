using System.Collections.Generic;
using Niagara.Domain.Models;

namespace Niagara.Web.Models
{
    public class MaterialLogSaveRequest
    {
        public MaterialLogSaveRequest()
        {
            NewNotes = new List<string>();
        }

        public MaterialLogModel MaterialLog { get; set; }

        public string PartNumber { get; set; }

        public string Supplier { get; set; }

        public List<string> NewNotes { get; set; }
    }
}