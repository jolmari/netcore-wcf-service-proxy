using System.Runtime.Serialization;

namespace WcfServices.DTO
{
    [DataContract]
    public class CountryDto
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}