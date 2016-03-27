using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
namespace ClassProducer
{

    [DataContract]
    class ArabicToTaatik
    {
        [DataMember]
        public char arabic {
            get; set;
        }
        [DataMember]
        public string heb {
            get; set;
        }
        public ArabicToTaatik() { }
        internal ArabicToTaatik(char arabic, string heb)
        {
            this.arabic = arabic;
            this.heb = heb;
        }

    }
}
