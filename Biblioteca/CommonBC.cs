using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectorOracle;

namespace Biblioteca
{
    public class CommonBC
    {
        private static ATEntities _modeloEntity;
        public static ATEntities ModeloEntity
        {
            get
            {
                _modeloEntity = new ATEntities();
                return _modeloEntity;
            }
        }
    }
}
