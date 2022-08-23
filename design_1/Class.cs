using System;
using design_1.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace design_1
{
    class Customer:User
    {
        public Customer()
        {

        }
    }
    class Aptekar:User
    {
        public Aptekar()
        {

        }
    }
    class Admin:User
    {
        public Admin()
        {

        }
        
    }
    interface II
    {
        void data();
    }
    abstract class User : II
    {
        public void data()
        {
           
        }
    }
}
