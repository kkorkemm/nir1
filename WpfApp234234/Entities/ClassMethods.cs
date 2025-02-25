using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp234234.Entities
{
    public class ClassMethods
    {
        private string ogran;

        public string Name { get; set; }

        /// <summary>
        /// Тип возращаемого значения
        /// </summary>
        public AttributesTypes Type { get; set; }

        /// <summary>
        /// Модификатор доступа
        /// </summary>
        public ModifTypes Modif { get; set; }

        /// <summary>
        /// Ограничения
        /// </summary>
        public string Ogran { get => ogran; set => ogran = value; }
    }
}
