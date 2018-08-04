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


            dynamic expando = new ExpandoObject();

            foreach (OracleParameter item in OPC)
            {
                // ExpandoObject supports IDictionary so we can extend it like this
                var expandoDict = expando as IDictionary<string, object>;
                if (expandoDict.ContainsKey("ss"))
                    expandoDict["ss"] = "44";
                else
                    expandoDict.Add("ss", "44");
            }


            p_dept_name = OPC["@p_dept_name"].Value.ToString();
        }


        public void MYPS55_DAL(
            in List<GENC> GENCs,
            out ExpandoObject exapo
            )
        {
            // من الممكن قراءة المخرجات الخاصه بالإجراء من قواعد البيانات وإنشائها بشكل تلقائي

            List<OracleParameter> parms = new List<OracleParameter>()
            {
                new OracleParameter() { ParameterName = "@PO_1I", OracleDbType = OracleDbType.Int32, Direction = ParameterDirection.Output, Size = 50 },
                new OracleParameter() { ParameterName = "@PO_2I", OracleDbType = OracleDbType.Int32, Direction = ParameterDirection.Output, Size = 50 },
                new OracleParameter() { ParameterName = "@PO_3S", OracleDbType = OracleDbType.Varchar2, Direction = ParameterDirection.Output, Size = 50 },
                new OracleParameter() { ParameterName = "@PO_4S", OracleDbType = OracleDbType.Varchar2, Direction = ParameterDirection.Output, Size = 50 },
                new OracleParameter() { ParameterName = "@PO_5S", OracleDbType = OracleDbType.Varchar2, Direction = ParameterDirection.Output, Size = 50 },
            };

            foreach (GENC item in GENCs)
            {
                parms.Add(new OracleParameter() { ParameterName = "@" + item.KEY, Value = item.VALUE });
            }

            ado.ExecuteStoredProcedure(
                "MYPS55",
                parms,
                out OracleParameterCollection OPCs
                );

            dynamic exapoy = new ExpandoObject();

            foreach (OracleParameter opc in OPCs)
            {
                if (opc.Direction == ParameterDirection.Output)
                {
                    var expandoDict = exapoy as IDictionary<string, object>;

                    if (expandoDict.ContainsKey(opc.ParameterName))
                        expandoDict[opc.ParameterName] = opc.Value;
                    else
                        expandoDict.Add(opc.ParameterName, opc.Value);
                }
            }

            exapo = exapoy;
            //p_dept_name = OPC["@p_dept_name"].Value.ToString();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }


        //public List<EstablishmentLicense> GetEstablishmentLicenses(string EstablishmentLicenseCode, int OwnerIdType, string OwnerId, string CRNumber)

        //{

        //    try

        //    {


        //        List<EstablishmentLicense> establishmentList = new List<EstablishmentLicense>();



        //        using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString()))

        //        {

        //            using (OracleCommand cmd = new OracleCommand())

        //            {

        //                cmd.Connection = conn;

        //                cmd.CommandText = "TMK_GET_COMPANY_DETAILS";

        //                cmd.CommandType = CommandType.StoredProcedure;



        //                cmd.Parameters.Add("@P_COMP_LICENCE_CODE", OracleDbType.NVarchar2).Value = ChangeType<string>(EstablishmentLicenseCode);

        //                cmd.Parameters.Add("@P_OWNER_ID_TYPE", OracleDbType.Int32).Value = ChangeType<int>(OwnerIdType);

        //                cmd.Parameters.Add("@P_OWNER_ID_NO", OracleDbType.NVarchar2).Value = ChangeType<string>(OwnerId);

        //                cmd.Parameters.Add("@P_CR_NUMBER", OracleDbType.NVarchar2).Value = ChangeType<string>(CRNumber);

        //                cmd.Parameters.Add("@REFCURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

        //                conn.Open();



        //                using (var reader = cmd.ExecuteReader())

        //                {

        //                    while (reader.Read())

        //                    {

        //                        var estLicense = new EstablishmentLicense();

        //                        estLicense.RegionId = (reader.IsDBNull(0)) ? "" : reader.GetString(0);

        //                        estLicense.VillageId = (reader.IsDBNull(1)) ? 0 : reader.GetInt32(1);

        //                        estLicense.EstablishmentTypeId = (reader.IsDBNull(2)) ? 0 : reader.GetInt32(2);

        //                        estLicense.SpecialityId = (reader.IsDBNull(3)) ? 0 : reader.GetInt32(3);

        //                        estLicense.EstablishmentSerialNo = (reader.IsDBNull(4)) ? 0 : reader.GetInt32(4);

        //                        estLicense.EstablishmentName = (reader.IsDBNull(5)) ? "" : reader.GetString(5);

        //                        estLicense.OwnerIdType = (reader.IsDBNull(6)) ? 0 : reader.GetInt32(6);

        //                        estLicense.OwnerIdNo = (reader.IsDBNull(7)) ? "" : reader.GetString(7);

        //                        estLicense.EstablishmentLicenseDate = (reader.IsDBNull(8)) ? "" : reader.GetString(8);

        //                        estLicense.EstablishmentRenewDate = (reader.IsDBNull(9)) ? "" : reader.GetString(9);

        //                        estLicense.EstablishmnetLicenseStatus = (reader.IsDBNull(10)) ? "" : reader.GetString(10);

        //                        estLicense.BedNo = (reader.IsDBNull(11)) ? 0 : reader.GetInt32(11);

        //                        estLicense.EstablishmentLicenseCode = (reader.IsDBNull(12)) ? "" : reader.GetString(12);

        //                        estLicense.EstablishmentNumber = (reader.IsDBNull(13)) ? "" : reader.GetString(13);



        //                        establishmentList.Add(estLicense);

        //                    }

        //                    reader.Close();

        //                }



        //                conn.Close();

        //            }



        //        }



        //        return establishmentList;

        //    }

        //    catch (FaultException<HLSService.ValidationFault> e)

        //    {

        //        ValidationFault fault = new ValidationFault();

        //        fault.Result = false;

        //        fault.Message = "Parameter not correct";

        //        fault.Description = "Invalid Parameter Name or All Parameters are null";



        //        throw new FaultException<ValidationFault>(fault, new FaultReason("Invalid Parameter Name or All Parameters are null "));

        //    }

        //    catch (Exception ex)

        //    {

        //        HLSFault fault = new HLSFault();

        //        fault.Result = false;

        //        fault.Message = ex.Message;

        //        fault.Description = "Service have an internal error please contact service administartor im@tamkeentech.sa";



        //        throw new FaultException<HLSFault>(fault);

        //    }



        //}

    }
}
