using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public abstract class Operacja
    {
        protected int _id;
        private static int _opId = 0;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Operacja()
        {
            _id = _opId;
            _opId++;
        }

        public abstract void Wykonaj();
    }
}
