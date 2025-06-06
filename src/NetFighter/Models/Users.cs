using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NetFighter.Models
{
    [DataContract]
    public class Users : IEquatable<Users>
    {
        [Key]
        [Required]
        [DataMember(Name = "id", EmitDefaultValue = true)]
        public int Id { get; set; }

        [Required]
        [DataMember(Name = "username", EmitDefaultValue = false)]
        public string UserName { get; set; }

        [Required]
        [DataMember(Name = "passwordhash", EmitDefaultValue = false)]
        public string PasswordHash { get; set; }
        [Required]
        [DataMember(Name = "role", EmitDefaultValue = false)]
        public string Role { get; set; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Keywords)obj);
        }

        public bool Equals(Users other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    Id.Equals(other.Id)
                );
        }
    }
}
