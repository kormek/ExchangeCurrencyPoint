using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Currency
    {
        public String name = null;
        public bool isRestricted = false;
        private double amount = 0;
        public Currency(String name)
        {
            this.name = name;
        }
        public void setRestricted(bool isRestricted)
        {
            this.isRestricted = isRestricted;
        }
        public void set_amount(double amount)
        {
            this.amount = amount;
        }
        public double get_amount()
        {
            return amount;
        }

    }
}
