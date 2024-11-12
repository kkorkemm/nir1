using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp234234.Entities
{
    public class Connection
    {
        public string Name { get; set; }
        public NewClass Class1 { get; set; }
        public NewClass Class2 { get; set; }
        public ConnectionType Type { get; set; }
    }

    public class ConnectionType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ConnectionType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
