using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Entities
{
    public class PermissionEntity
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return ID;
        }
    }
}
