using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.OracleClient;

namespace MainIntgAPIs.Tests
{
    public class TestGets
    {
        public List<EstablishmentLicense> GetEstablishmentLicenses(
            string EstablishmentLicenseCode,
               int OwnerIdType,
            string OwnerId,
            string CRNumber
            )
        {
            try

            {
                if (String.IsNullOrEmpty(EstablishmentLicenseCode))

                    if (String.IsNullOrEmpty(OwnerId))

                        if (string.IsNullOrEmpty(CRNumber))

                            throw new FaultException<ValidationFault>(new ValidationFault());


                List<EstablishmentLicense> establishmentList = new List<EstablishmentLicense>();


                using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString()))
                {
                    using (OracleCommand cmd = new OracleCommand())

                    {
                        cmd.Connection = conn;

                        cmd.CommandText = "TMK_GET_COMPANY_DETAILS";

                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add("@P_COMP_LICENCE_CODE", OracleDbType.NVarchar2).Value = ChangeType<string>(EstablishmentLicenseCode);

                        cmd.Parameters.Add("@P_OWNER_ID_TYPE", OracleDbType.Int32).Value = ChangeType<int>(OwnerIdType);

                        cmd.Parameters.Add("@P_OWNER_ID_NO", OracleDbType.NVarchar2).Value = ChangeType<string>(OwnerId);

                        cmd.Parameters.Add("@P_CR_NUMBER", OracleDbType.NVarchar2).Value = ChangeType<string>(CRNumber);

                        cmd.Parameters.Add("@REFCURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        conn.Open();


                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())

                            {
                                var estLicense = new EstablishmentLicense();

                                estLicense.RegionId = (reader.IsDBNull(0)) ? "" : reader.GetString(0);

                                estLicense.VillageId = (reader.IsDBNull(1)) ? 0 : reader.GetInt32(1);

                                estLicense.EstablishmentTypeId = (reader.IsDBNull(2)) ? 0 : reader.GetInt32(2);

                                estLicense.SpecialityId = (reader.IsDBNull(3)) ? 0 : reader.GetInt32(3);


                                establishmentList.Add(estLicense);

                            }

                            reader.Close();

                        }


                        conn.Close();

                    }

                }

                return establishmentList;
            }
            catch (FaultException<HLSService.ValidationFault> e)

            {
                ValidationFault fault = new ValidationFault();

                fault.Result = false;

                fault.Message = "Parameter not correct";

                fault.Description = "Invalid Parameter Name or All Parameters are null";


                throw new FaultException<ValidationFault>(fault, new FaultReason("Invalid Parameter Name or All Parameters are null "));
            }
            catch (Exception ex)
            {
                HLSFault fault = new HLSFault();

                fault.Result = false;

                fault.Message = ex.Message;

                fault.Description = "Service have an internal error please contact service administartor im@tamkeentech.sa";


                throw new FaultException<HLSFault>(fault);
            }



        }

    }
}