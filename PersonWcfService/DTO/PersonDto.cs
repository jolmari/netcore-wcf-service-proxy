using System.Runtime.Serialization;

namespace PersonWcfService.DTO
{
    [DataContract]
    public class PersonDto
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string CountryCode { get; set; }
    }
}