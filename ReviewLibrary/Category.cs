using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewLibrary
{
    public class Category
    {
        //properties
        private int categoryID;
        private string categoryName;

        public Category()
        {

        }

        // Encapsulate fields
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
    }
}
