using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RequestModel
{
    public class UpdateAdminRequest
    {
        public int? AdminId { get; set; }

        public string? AdminName { get; set; }

        public string Manager { get; set; } = null!;

        public string? Email { get; set; }
    }
}
