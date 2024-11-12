using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp234234.Entities
{
    public class ConnectionLine
    {
        public Connection ConnectionInfo = User.UserConnections.LastOrDefault();

        public ConnectionLine(Canvas canvas) 
        {

        }
    }
}
