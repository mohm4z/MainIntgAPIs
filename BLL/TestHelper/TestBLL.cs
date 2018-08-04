using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using OraDB.DbManager;
using OraDB.TestModels;
using System.Collections;
using Common.CommonHelpers;
using Common.CommonClasses;
using System.Dynamic;
using Oracle.ManagedDataAccess.Client;
using System.Xml.Linq;

namespace BLL.TestHelper
{
    public class TestBLL : IDisposable
    {
        public IEnumerable<dept> GetDeptHelper(
            string T_NAME
            )
        {
            using (TestDAL test = new TestDAL(new ADO()))
            {
                DataSet Ds = new DataSet("TestDs");

                DataTable dt = test.GetDeptDAL(T_NAME);

                dt.TableName = "TstDt";

                return dt.DataTableToList<dept>();
            }
        }


        public R_View GetSP(
            in int dept_no,
            in string dept_sec_name
            )
        {
            using (TestDAL test = new TestDAL(new ADO()))
            {
                test.GetSP_DAL(
                    dept_no,
                    dept_sec_name,
                    out DataSet DS,
                    out string p_dept_name
                    );

                R_View ev = new R_View
                {
                    P_DEPT_DATA = DS.Tables[0].DataTableToList<dept>(),
                    P_DEPT_NAME = p_dept_name
                };

                return ev;
            }
        }


        public ExpandoObject Test_MYPS55(
            in int PI_1I,
            in int PI_2I,
            in string PI_3S,
            in string PI_4S,
            in string PI_5S
            )
        {
            using (TestDAL test = new TestDAL(new ADO()))
            {
                List<SpInPuts> inputs = new List<SpInPuts>
                {
                    new SpInPuts(){KEY = "PI_1I" ,VALUE = PI_1I},
                    new SpInPuts(){KEY = "PI_2I" ,VALUE = PI_2I},
                    new SpInPuts(){KEY = "PI_3S" ,VALUE = PI_3S},
                    new SpInPuts(){KEY = "PI_4S" ,VALUE = PI_4S},
                    new SpInPuts(){KEY = "PI_5S" ,VALUE = PI_5S},
                };

                List<SqOutPuts> Outouts = new List<SqOutPuts>()
                {
                 new SqOutPuts() { ParameterName ="PO_1I" , OracleDbType= OracleDbType.Int32 , Size = 50},
                 new SqOutPuts() { ParameterName ="PO_2I" , OracleDbType= OracleDbType.Int32 , Size = 50},
                 new SqOutPuts() { ParameterName ="PO_3S" , OracleDbType= OracleDbType.Varchar2 , Size = 50},
                 new SqOutPuts() { ParameterName ="PO_4S" , OracleDbType= OracleDbType.Varchar2 , Size = 50},
                 new SqOutPuts() { ParameterName ="PO_5S" , OracleDbType= OracleDbType.Varchar2 , Size = 50},
                };


                test.ExcuteSP(
                   "ss",
                   inputs,
                   Outouts,
                   out ExpandoObject exp
                   );

                //R_View ev = new R_View
                //{
                //    P_DEPT_DATA = DS.Tables[0].DataTableToList<dept>(),
                //    P_DEPT_NAME = p_dept_name
                //};

                return exp;
            }
        }


        public ExpandoObject Test_MYPS55_2(
           in int PI_1I
           )
        {
            using (TestDAL test = new TestDAL(new ADO()))
            {
                List<SpInPuts> inputs = new List<SpInPuts>
                {
                    new SpInPuts(){KEY = "PI_1I" ,VALUE = PI_1I}
                };

                List<SqOutPuts> Outouts = new List<SqOutPuts>()
                {
                 new SqOutPuts() { ParameterName ="PO_4S" , OracleDbType= OracleDbType.Varchar2 , Size = 50},
                 new SqOutPuts() { ParameterName ="PO_5S" , OracleDbType= OracleDbType.Int32 , Size = 50}
                };

                test.ExcuteSP(
                   "Test_MYPS55_2",
                   inputs,
                   Outouts,
                   out ExpandoObject exp
                   );

                return exp;
            }
        }


        public List<SrvOutPots> Test_MYPS55_3(
           in int PI_1I
           )
        {
            using (TestDAL test = new TestDAL(new ADO()))
            {
                List<SpInPuts> inputs = new List<SpInPuts>
                {
                    new SpInPuts(){KEY = "PI_1I" ,VALUE = PI_1I}
                };

                List<SqOutPuts> Outouts = new List<SqOutPuts>()
                {
                 new SqOutPuts() { ParameterName ="PO_4S" , OracleDbType= OracleDbType.Varchar2 , Size = 50},
                 new SqOutPuts() { ParameterName ="PO_5S" , OracleDbType= OracleDbType.Int32 , Size = 50}
                };

                test.ExcuteSP3(
                   "Test_MYPS55_2",
                   inputs,
                   Outouts,
                   out List<SrvOutPots> exp
                   );

                return exp;
            }
        }


        public XElement Test_MYPS55_4(
          in int PI_1I
          )
        {
            using (TestDAL test = new TestDAL(new ADO()))
            {
                List<SpInPuts> inputs = new List<SpInPuts>
                {
                    new SpInPuts(){KEY = "PI_1I" ,VALUE = PI_1I}
                };

                List<SqOutPuts> Outouts = new List<SqOutPuts>()
                {
                    new SqOutPuts() { ParameterName ="PO_4S" , OracleDbType= OracleDbType.Varchar2 , Size = 50},
                    new SqOutPuts() { ParameterName ="PO_5S" , OracleDbType= OracleDbType.Int32 , Size = 50}
                };

                test.ExcuteSP4(
                   "Test_MYPS55_2",
                   inputs,
                   Outouts,
                   out XElement exp
                   );

                return exp;
            }
        }


        public XElement CH_P_ESTBLSH_REG_INFO(
          in int P_REG_ID
          )
        {
            using (TestDAL test = new TestDAL(new ADO()))
            {
                List<SpInPuts> inputs = new List<SpInPuts>
                {
                    new SpInPuts(){KEY = "P_REG_ID" , VALUE = P_REG_ID}
                };

                List<SqOutPuts> Outouts = new List<SqOutPuts>()
                {
                    new SqOutPuts() { ParameterName ="P_BRN_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                    new SqOutPuts() { ParameterName ="P_REG_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                    new SqOutPuts() { ParameterName ="P_REGISTRY_DT" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                    new SqOutPuts() { ParameterName ="P_SERVICE_AREA" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                    new SqOutPuts() { ParameterName ="P_SUBSIDY_ACC_NO" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                    new SqOutPuts() { ParameterName ="P_BANK_NAME" , OracleDbType= OracleDbType.Varchar2 , Size = 100},
                    new SqOutPuts() { ParameterName ="P_RESULT_CODE" , OracleDbType= OracleDbType.Varchar2 , Size = 100}
                };

                test.ExcuteSP4(
                   "CH_P_ESTBLSH_REG_INFO",
                   inputs,
                   Outouts,
                   out XElement exp
                   );

                return exp;
            }
        }




        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }



    public class R_View
    {
        public string P_DEPT_NAME { get; set; }
        public IEnumerable<dept> P_DEPT_DATA { get; set; }
    }




    public class dept
    {
        public int DEPARTMENT_NO { get; set; }
        public string DEPARTMENT_NAME_ARB { get; set; }
    }

}
