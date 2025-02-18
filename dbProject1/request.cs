using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbProject1
{
    public enum DeviceType
    {
        Printer,
        Computer,
        Internals,
        Server
    }

    public enum RequestStatus
    {
        New,
        InProcess,
        Done
    }
    public class Request
    {
        public int ID;
        public string creationDate;
        public DeviceType type;
        public string model;
        public string description;
        public string name;
        public string telephoneNumber;
        public RequestStatus status;
        public string? responsiveMan;

        public Request(int id, string cD, DeviceType t, string mod, string desc, string _name, string telephoneNum, RequestStatus _status)
        {
            ID = id;
            creationDate = cD;
            type = t;
            model = mod;
            description = desc;
            name = _name;
            telephoneNumber = telephoneNum;
            status = _status;
        }

        public override string ToString()
        {
            string toReturn = "";
            toReturn += ID;
            return toReturn;
        }
    }
}
