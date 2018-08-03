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

namespace BLL.TestHelper
{
    public class TestBLL : IDisposable
    {
        public IEnumerable<dept> GetDeptHelper(string T_NAME)
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


        public R_View GetSP2(
            in int PI_1I,
            in int PI_2I,
            in string PI_3S,
            in string PI_4S,
            in string PI_5S
            )
        {
            using (TestDAL test = new TestDAL(new ADO()))
            {
                List<GENC> ioj = new List<GENC>
                {
                    new GENC(){KEY = "PI_1I" ,VALUE = PI_1I},
                    new GENC(){KEY = "PI_2I" ,VALUE = PI_2I},
                    new GENC(){KEY = "PI_3S" ,VALUE = PI_3S},
                    new GENC(){KEY = "PI_4S" ,VALUE = PI_4S},
                    new GENC(){KEY = "PI_5S" ,VALUE = PI_5S},
                };

                //test.GetSP2_DAL(
                //    dept_no,
                //    dept_sec_name,
                //    out DataSet DS,
                //    out string p_dept_name
                //    );

                //R_View ev = new R_View
                //{
                //    P_DEPT_DATA = DS.Tables[0].DataTableToList<dept>(),
                //    P_DEPT_NAME = p_dept_name
                //};

                return new R_View();
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
