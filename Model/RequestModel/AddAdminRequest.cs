using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RequestModel
{
    /// <summary>
    /// Schema for adding new student
    /// </summary>
    public class AddAdminRequest
    {
        public int? AdminId { get; set; }

        public string? AdminName { get; set; }

        public string Manager { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}