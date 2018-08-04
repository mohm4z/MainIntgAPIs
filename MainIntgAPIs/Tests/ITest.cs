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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITest" in both code and config file together.
    [ServiceContract(
        ConfigurationName ="mlsd.gov.sas",
        Namespace = "http://mlsd.gov.sa" ,
        Name ="mlsd"
        )]
    public interface ITest
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        IEnumerable<dept> GetData(
            string T_NAME
            );

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        R_View GetSP(
             int dept_no,
             string dept_sec_name
            );

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        ExpandoObject MYPS55(
             int PI_1I,
             int PI_2I,
             string PI_3S,
             string PI_4S,
             string PI_5S
           );


        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        ExpandoObject Test_MYPS55_2(
            int PI_1I
            );

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        List<SrvOutPots> Test_MYPS55_3(
            int PI_1I
          );

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        XElement Test_MYPS55_4(
           int PI_1I
         );

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        XElement CH_P_ESTBLSH_REG_INFO(
           int P_REG_ID
           );

    }


    [DataContract]
    public class ValidationFault
    {
        [DataMember]
        public bool Result { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
