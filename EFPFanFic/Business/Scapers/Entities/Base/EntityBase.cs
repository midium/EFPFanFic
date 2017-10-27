using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPFanFic.Business.Scapers.Entities.Base
{
    public class EntityBase
    {
        private string _value = string.Empty;
        private string _name = string.Empty;

        public string Value { get => _value; set => _value = value; }
        public string Name { get => _name; set => _name = value; }

        public EntityBase(string value, string name)
        {
            _value = value;
            _name = name;
        }

        public override string ToString()  
        {  
            return Name;
        }
    }
}
