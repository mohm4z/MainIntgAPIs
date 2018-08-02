using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using OraDB.DbManager;
using OraDB.TestModels;
using System.Collections;
using BLL.Helpers;

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


        public R_View GetSP(int dept_no, string dept_sec_name)
        {
            using (TestDAL test = new TestDAL(new ADO()))
            {
                R_View ev = new R_View
                {
                    P_DEPT_DATA = test.GetSP_DAL(dept_no, dept_sec_name, out string ss).DataTableToList<dept>(),
                    P_DEPT_NAME = ss
                };

                return ev;
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
