using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OracleConnector;

namespace Clases
{
    public class CommonBC
    {
        private static BD_TurismoReal _modeloEntity;
        public static BD_TurismoReal ModeloEntity
        {
            get
            {
                if (_modeloEntity == null)
                {
                    _modeloEntity = new BD_TurismoReal();
                }
                return _modeloEntity;
            }
        }
        public CommonBC()
        {

        }
    }
}
