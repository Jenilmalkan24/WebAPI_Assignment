using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ResponseModel
{
    public class AdminDTO
    {
        public int? AdminId { get; set; }

        public string Manager { get; set; } = null!;

        public string? Email { get; set; } = null!;
    }
}
