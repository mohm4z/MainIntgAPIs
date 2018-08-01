using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;


namespace OraDB.Models
{
    public class Departmints
    {
        ADO ado;


        public Departmints()
        {
            ado = new ADO();
        }

        public DataTable GetDepts()
        {
            using (ADO ado = new ADO())
            {
                ado.cmd.CommandText = "SELECT * FROM DEPARTMENTS";

                return ado.SqlSelect(ado.cmd);
            }
        }
    }
}
