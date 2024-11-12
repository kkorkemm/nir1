using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp234234.Entities
{
    public class User
    {
        public static List<NewClass> UserClasses = new List<NewClass>();
        public static List<Connection> UserConnections = new List<Connection>();

        public static List<ConnectionType> connectionTypes = new List<ConnectionType>()
        {
            new ConnectionType(1, "Ассоциация (1-1)"),
            new ConnectionType(2, "Ассоциация (1-*)"),
            new ConnectionType(3, "Ассоциация (*-*)"),
            new ConnectionType(4, "Зависимость"),
            new ConnectionType(5, "Агрегация"),
            new ConnectionType(6, "Наследование"),
        };
    }
}
