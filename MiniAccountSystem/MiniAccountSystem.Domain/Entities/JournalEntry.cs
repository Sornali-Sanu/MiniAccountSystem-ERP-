using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccountSystem.Domain.Entities
{
    public class JournalEntry
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string ReferenceNo { get; set; }
        public string Description { get; set; }
        public ICollection<JournalDetail>JournalDetails { get; set; }
    }
}
