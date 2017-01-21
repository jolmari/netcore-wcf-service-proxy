using System.Runtime.Serialization;

namespace CountryWcfService.DTO
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