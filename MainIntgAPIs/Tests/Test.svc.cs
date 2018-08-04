using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data;
using BLL.TestHelper;
using System.Dynamic;
using Common.CommonClasses;
using System.Xml.Linq;

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

        public ExpandoObject MYPS55(
            int PI_1I,
            int PI_2I,
            string PI_3S,
            string PI_4S,
            string PI_5S
            )
        {
            try
            {
                // Data Validations

                using (TestBLL tbl = new TestBLL())
                {
                    return tbl.Test_MYPS55(
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
                // Exceptions Handler
                throw new Exception("Errorn Ma : " + ex.Message);
            }
        }


        public ExpandoObject Test_MYPS55_2(
            int PI_1I
            )
        {
            try
            {
                // Data Validations

                using (TestBLL tbl = new TestBLL())
                {
                    return tbl.Test_MYPS55_2(
                            PI_1I
                        );
                }
            }
            catch (Exception ex)
            {
                // Exceptions Handler
                throw new Exception("Errorn Ma : " + ex.Message);
            }
        }

        public List<SrvOutPots> Test_MYPS55_3(
            int PI_1I
            )
        {
            try
            {
                /// Data Validations

                //if (String.IsNullOrEmpty(PI_1I))

                //throw new FaultException<ValidationFault>(new ValidationFault());

                using (TestBLL tbl = new TestBLL())
                {
                    return tbl.Test_MYPS55_3(
                            PI_1I
                        );
                }
            }
            catch (FaultException<ValidationFault> e)
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = true,
                    Message = "Parameter not correct",
                    Description = "Invalid Parameter Name or All Parameters are nullu"
                };

                throw new FaultException<ValidationFault>(
                    fault);
            }
            catch (Exception ex)
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = false,
                    Message = ex.Message,
                    Description = "Service have an internal error please contact service administartor m.zanaty@mlsd.gov.sa"
                };

                throw new FaultException<ValidationFault>(fault);
            }
        }

        public XElement Test_MYPS55_4(
            int PI_1I
            )
        {
            try
            {
                // Data Validations
                if (true)
                {

                }

                using (TestBLL tbl = new TestBLL())
                {
                    return tbl.Test_MYPS55_4(
                            PI_1I
                        );
                }
            }
            catch (Exception ex)
            {
                // Exceptions Handler
                throw new Exception("Errorn Ma : " + ex.Message);
            }
        }



        public XElement CH_P_ESTBLSH_REG_INFO(
           int P_REG_ID
           )
        {
            try
            {
                /// Data Validations

                //if (String.IsNullOrEmpty(PI_1I))

                //throw new FaultException<ValidationFault>(new ValidationFault());

                using (TestBLL tbl = new TestBLL())
                {
                    return tbl.CH_P_ESTBLSH_REG_INFO(
                            P_REG_ID
                        );
                }
            }
            catch (FaultException<ValidationFault> e)
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = true,
                    Message = "Parameter not correct",
                    Description = "Invalid Parameter Name or All Parameters are nullu"
                };

                throw new FaultException<ValidationFault>(
                    fault);
            }
            catch (Exception ex)
            {
                ValidationFault fault = new ValidationFault
                {
                    Result = false,
                    Message = ex.Message,
                    Description = "Service have an internal error please contact service administartor m.zanaty@mlsd.gov.sa"
                };

                throw new FaultException<ValidationFault>(fault);
            }
        }
    }

    
}
