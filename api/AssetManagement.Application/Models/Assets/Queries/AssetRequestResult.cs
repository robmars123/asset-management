using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Models.Assets.Queries
{
    public class AssetRequestResult
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? EmployeeId { get; set; }
    }
}
