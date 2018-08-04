using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data;
using BLL.TestHelper;
using System.Dynamic;

namespace MainIntgAPIs.Tests
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITest" in both code and config file together.
    [ServiceContract]
    public interface ITest
    {
        [OperationContract]
        IEnumerable<dept> GetData(
            string T_NAME
            );

        [OperationContract]
        R_View GetSP(
             int dept_no,
             string dept_sec_name
            );

        [OperationContract]
        ExpandoObject MYPS55(
             int PI_1I,
             int PI_2I,
             string PI_3S,
             string PI_4S,
             string PI_5S
           );
    }
}
