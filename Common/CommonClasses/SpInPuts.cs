using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Dynamic;
using System.Runtime.Serialization;

namespace Common.CommonClasses
{
    [DataContract]
    public class SpInPuts
    {
        [DataMember]
        public string KEY { get; set; }

        [DataMember]
        public object VALUE { get; set; }
    }


    [DataContract]
    public class SrvOutPots
    {
        [DataMember]
        public string KEY { get; set; }

        [DataMember]
        public string VALUE { get; set; }
    }


    [DataContract]
    public class MyClass : MyExpando
    {
        [DataMember]
        public int Inty { get; set; }

        [DataMember]
        public string Intys { get; set; }
    }


    public class DynamicFormData : DynamicObject
    {
        private Dictionary<string, object> Fields = new Dictionary<string, object>();

        public int Count { get { return Fields.Keys.Count; } }

        public void Add(string name, string val = null)
        {
            if (!Fields.ContainsKey(name))
            {
                Fields.Add(name, val.ToString());
            }
            else
            {
                Fields[name] = val.ToString();
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (Fields.ContainsKey(binder.Name))
            {
                result = Fields[binder.Name];
                return true;
            }
            return base.TryGetMember(binder, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (!Fields.ContainsKey(binder.Name))
            {
                Fields.Add(binder.Name, value);
            }
            else
            {
                Fields[binder.Name] = value;
            }
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (Fields.ContainsKey(binder.Name) &&
                Fields[binder.Name] is Delegate)
            {
                Delegate del = Fields[binder.Name] as Delegate;
                result = del.DynamicInvoke(args);
                return true;
            }
            return base.TryInvokeMember(binder, args, out result);
        }
    }
}
