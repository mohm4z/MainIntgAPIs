using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OraDB.DbManager;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Dynamic;
using Common.CommonClasses;
using System.Reflection.Emit;
using System.Reflection;
using System.Xml.Linq;

namespace OraDB.TestModels
{
    public class TestDAL : IDisposable
    {
        public readonly IADO ado;

        public TestDAL(IADO Ado)
        {
            this.ado = Ado;
        }

        public DataTable GetDeptDAL(
            string T_NAME
            )
        {
            return ado.SqlSelect("SELECT * FROM " + T_NAME);
        }

        public void GetSP_DAL(
            in int p_dept_no,
            in string p_dept_sec_name,
            out DataSet p_dept_data,
            out string p_dept_name
            )
        {
            List<OracleParameter> parms = new List<OracleParameter>()
            {
                  new OracleParameter(){ ParameterName ="@p_dept_no", Value= p_dept_no },
                  new OracleParameter(){ ParameterName ="@P_it_p", Value= p_dept_sec_name},
                  new OracleParameter(){ ParameterName ="@p_dept_data", OracleDbType = OracleDbType.RefCursor ,Direction =ParameterDirection.Output },
                  new OracleParameter(){ ParameterName ="@p_dept_name", OracleDbType = OracleDbType.Varchar2 ,Direction =ParameterDirection.InputOutput , Size = 50}
            };

            ado.ExecuteStoredProcedure(
                "PRC_GET_DEPTS",
                parms,
                out OracleParameterCollection OPC,
                out p_dept_data
                );


            //dynamic expando = new ExpandoObject();

            //foreach (OracleParameter item in OPC)
            //{
            //    // ExpandoObject supports IDictionary so we can extend it like this
            //    var expandoDict = expando as IDictionary<string, object>;
            //    if (expandoDict.ContainsKey("ss"))
            //        expandoDict["ss"] = "44";
            //    else
            //        expandoDict.Add("ss", "44");
            //}


            p_dept_name = OPC["@p_dept_name"].Value.ToString();
        }


        public void Test_MYPS55_DAL(
            in List<SpInPuts> GENCs,
            out ExpandoObject exapo
            )
        {
            // من الممكن قراءة المخرجات الخاصه بالإجراء من قواعد البيانات وإنشائها بشكل تلقائي

            List<SqOutPuts> oopo = new List<SqOutPuts>()
            {
                 new SqOutPuts() { ParameterName ="PO_1I" , OracleDbType= OracleDbType.Int32 , Size = 50},
                 new SqOutPuts() { ParameterName ="PO_2I" , OracleDbType= OracleDbType.Int32 , Size = 50},
                 new SqOutPuts() { ParameterName ="PO_3S" , OracleDbType= OracleDbType.Varchar2 , Size = 50},
                 new SqOutPuts() { ParameterName ="PO_4S" , OracleDbType= OracleDbType.Varchar2 , Size = 50},
                 new SqOutPuts() { ParameterName ="PO_5S" , OracleDbType= OracleDbType.Varchar2 , Size = 50},
            };

            List<OracleParameter> OpParms = new List<OracleParameter>();

            //List<OracleParameter> OpParms = ado.PapulateOPs(
            //    in oopo
            //    );

            //ado.PapulateOpsListFromGENCs(
            //    ref OpParms,
            //    in GENCs
            //    );

            ado.ExecuteStoredProcedure(
                 "MYPS55",
                 OpParms,
                 out OracleParameterCollection OPCs
                 );

            exapo = ado.CreateExapoClass(ref OPCs);
        }


        public void ExcuteSP(
            string SP_NAME,
            in List<SpInPuts> INs,
            in List<SqOutPuts> OUTs,
            out ExpandoObject exapo
           )
        {
            // من الممكن قراءة المخرجات الخاصه بالإجراء من قواعد البيانات وإنشائها بشكل تلقائي

            //List<OracleParameter> OpParms = new List<OracleParameter>();

            List<OracleParameter> OpParms = ado.PapulateOpsListFromGENCs(
                in INs
                );

            ado.PapulateOPs(
                ref OpParms,
                in OUTs
              );

            ado.ExecuteStoredProcedure(
                SP_NAME,
                OpParms,
                out OracleParameterCollection OPCs
                );

            dynamic sampleObject = new ExpandoObject();

            sampleObject.SDF = "sss";

            exapo = ado.CreateExapoClass(ref OPCs);
        }


        public void ExcuteSP3(
            string SP_NAME,
            in List<SpInPuts> INs,
            in List<SqOutPuts> OUTs,
            out List<SrvOutPots> exapo
           )
        {
            // من الممكن قراءة المخرجات الخاصه بالإجراء من قواعد البيانات وإنشائها بشكل تلقائي

            //List<OracleParameter> OpParms = new List<OracleParameter>();

            List<OracleParameter> OpParms = ado.PapulateOpsListFromGENCs(
                in INs
                );

            ado.PapulateOPs(
                ref OpParms,
                in OUTs
              );

            ado.ExecuteStoredProcedure(
                SP_NAME,
                OpParms,
                out OracleParameterCollection OPCs
                );

            List<SrvOutPots> sampleObject = new List<SrvOutPots>();

            foreach (OracleParameter opc in OPCs)
            {
                if (opc.Direction == ParameterDirection.Output)
                {
                    sampleObject.Add(new SrvOutPots()
                    {
                        KEY = opc.ParameterName.Remove(0, 1),
                        VALUE = opc.Value.ToString()
                    });
                }
            }

            exapo = sampleObject;
        }


        public void ExcuteSP4(
           in string SP_NAME,
           in List<SpInPuts> INs,
           in List<SqOutPuts> OUTs,
           out XElement exapo
          )
        {
            List<OracleParameter> OpParms = ado.PapulateOpsListFromGENCs(
                in INs
                );

            ado.PapulateOPs(
                ref OpParms,
                in OUTs
              );

            ado.ExecuteStoredProcedure(
                SP_NAME,
                OpParms,
                out OracleParameterCollection OPCs
                );

            exapo = ado.CreateXElement(
                in SP_NAME,
                ref OPCs
                );
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }




    }




    //    public class MyClass
    //    {
    //        MethodAttributes pricePropertyAttributes = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
    //        MethodBuilder getPriceBuilder = simpleType.DefineMethod("get_Price", pricePropertyAttributes, typeof(int), Type.EmptyTypes);
    //        MethodBuilder setPriceBuilder = simpleType.DefineMethod("set_Price", pricePropertyAttributes, null, new Type[] { typeof(int) });
    //        priceProperty.SetGetMethod(getPriceBuilder);
    //          priceProperty.SetSetMethod(setPriceBuilder);


    //    }

}
