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
    public partial class Ports : IEquatable<Ports>
    {
        [Key]
        [Required]
        [DataMember(Name="id", EmitDefaultValue=true)]
        public int Id { get; set; }
        [Required]
        [DataMember(Name="number", EmitDefaultValue=true)]
        public int Number { get; set; }
        [Required]
        [DataMember(Name="host_id", EmitDefaultValue=true)]
        public int HostId { get; set; }
        [DataMember(Name="info", EmitDefaultValue=false)]
        public string Info { get; set; }
        [Required]
        [DataMember(Name="protocol", EmitDefaultValue=false)]
        public string Protocol { get; set; }
        [DataMember(Name = "created_at", EmitDefaultValue = false)]
        public DateTime CreatedAt { get; set; }
        [DataMember(Name = "updated_at", EmitDefaultValue = false)]
        public DateTime UpdatedAt { get; set; }
        public ICollection<VhostsPorts>? VhostPorts { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Ports {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Number: ").Append(Number).Append("\n");
            sb.Append("  HostId: ").Append(HostId).Append("\n");
            sb.Append("  Info: ").Append(Info).Append("\n");
            sb.Append("  Protocol: ").Append(Protocol).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Ports)obj);
        }
        public bool Equals(Ports other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    
                    Id.Equals(other.Id)
                ) && 
                (
                    Number == other.Number ||
                    
                    Number.Equals(other.Number)
                ) && 
                (
                    HostId == other.HostId ||
                    
                    HostId.Equals(other.HostId)
                ) && 
                (
                    Info == other.Info ||
                    Info != null &&
                    Info.Equals(other.Info)
                ) && 
                (
                    Protocol == other.Protocol ||
                    Protocol != null &&
                    Protocol.Equals(other.Protocol)
                );
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 41;
                    
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    
                    hashCode = hashCode * 59 + Number.GetHashCode();
                    
                    hashCode = hashCode * 59 + HostId.GetHashCode();
                    if (Info != null)
                    hashCode = hashCode * 59 + Info.GetHashCode();
                    if (Protocol != null)
                    hashCode = hashCode * 59 + Protocol.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Ports left, Ports right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Ports left, Ports right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
