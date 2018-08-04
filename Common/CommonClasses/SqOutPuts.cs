using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;

namespace Common.CommonClasses
{
    public class SqOutPuts
    {
        public string ParameterName { get; set; }
        public OracleDbType OracleDbType { get; set; }
        public int Size { get; set; }
    }
}
