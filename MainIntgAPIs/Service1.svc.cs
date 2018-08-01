using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.Data;
using System.Collections;
//using OraDB.Models;
//using System.Data.OracleClient;


namespace MainIntgAPIs
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        //public IEnumerable<CompositeType> GetDataUsingDataContract(CompositeType composite)
        //{
        //    List<CompositeType> lsi = new List<CompositeType>();

        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        lsi.Add(new CompositeType() { BoolValue = true, StringValue = "ss1s" });
        //        lsi.Add(new CompositeType() { BoolValue = false, StringValue = "sswss" });
        //        lsi.Add(new CompositeType() { BoolValue = true, StringValue = "sssws" });
        //    }

        //    return lsi;
        //}


        //public DataTable getmydata(string composite)
        //{
        //    DataSet ds = new DataSet("Myds");

        //    DataTable dt = new DataTable("MyTaple");

        //    dt = new Departmints().GetDepts();

        //    ds.Tables.Add(dt);

        //    ds.Tables[0].TableName = "Mhytt";

        //    return dt;
        //}
    }

   
}
