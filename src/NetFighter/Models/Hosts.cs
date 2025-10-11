using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using NetFighter.Converters;

namespace NetFighter.Models
{
    [DataContract]
    public partial class Hosts : IEquatable<Hosts>
    {
        [Key]
        [Required]
        [DataMember(Name="id", EmitDefaultValue=true)]
        public int Id { get; set; }
        [Required]
        [DataMember(Name="ip", EmitDefaultValue=false)]
        public string Ip { get; set; }
        [DataMember(Name="info", EmitDefaultValue=false)]
        public string Info { get; set; }
        [DataMember(Name = "created_at", EmitDefaultValue = false)]
        public DateTime CreatedAt { get; set; }
        [DataMember(Name = "updated_at", EmitDefaultValue = false)]
        public DateTime UpdatedAt { get; set; }
        public ICollection<DomainsHosts> DomainsHosts { get; }
        public ICollection<Ports> Ports { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Hosts {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Ip: ").Append(Ip).Append("\n");
            sb.Append("  Info: ").Append(Info).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Hosts)obj);
        }
        public bool Equals(Hosts other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||

                    Id.Equals(other.Id)
                ) &&
                (
                    Ip == other.Ip ||
                    Ip != null &&
                    Ip.Equals(other.Ip)
                ) &&
                (
                    Info == other.Info ||
                    Info != null &&
                    Info.Equals(other.Info)
                );// &&
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 41;
                    
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Ip != null)
                    hashCode = hashCode * 59 + Ip.GetHashCode();
                    if (Info != null)
                    hashCode = hashCode * 59 + Info.GetHashCode();
                return hashCode;
            }
        }
        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Hosts left, Hosts right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Hosts left, Hosts right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
