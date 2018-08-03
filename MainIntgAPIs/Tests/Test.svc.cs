using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data;
using BLL.TestHelper;

namespace MainIntgAPIs.Tests
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Test" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Test.svc or Test.svc.cs at the Solution Explorer and start debugging.
    public class Test : ITest
    {
        public IEnumerable<dept> GetData(
            string T_NAME
            )
        {
            try
            {
                using (TestBLL tbl = new TestBLL())
                {
                    return tbl.GetDeptHelper(
                        T_NAME
                        );
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errorn Ma : " + ex.Message);
            }
        }

        public R_View GetSP(
             int dept_no, 
             string dept_sec_name
            )
        {
            try
            {
                using (TestBLL tbl = new TestBLL())
                {
                    return tbl.GetSP(
                        dept_no, 
                        dept_sec_name
                        );
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errorn Ma : " + ex.Message);
            }
        }


        public R_View GetSP2(
             int PI_1I,
             int PI_2I,
             string PI_3S,
             string PI_4S,
             string PI_5S
           )
        {
            try
            {
                using (TestBLL tbl = new TestBLL())
                {
                    return tbl.GetSP2(
                            PI_1I,
                            PI_2I,
                            PI_3S,
                            PI_4S,
                            PI_5S
                        );
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errorn Ma : " + ex.Message);
            }
        }
    }



}
