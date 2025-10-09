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
    public partial class VhostsPorts : IEquatable<VhostsPorts>
    {
        [Key]
        [Required]
        [DataMember(Name = "id", EmitDefaultValue = true)]
        public int Id { get; set; }

        [Required]
        [DataMember(Name="vhost_id", EmitDefaultValue=true)]
        public int VhostId { get; set; }

        [Required]
        [DataMember(Name="port_id", EmitDefaultValue=true)]
        public int PortId { get; set; }

        public Ports Ports { get; }
        public Vhosts Vhosts { get; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class VhostPorts {\n");
            sb.Append("  VhostId: ").Append(VhostId).Append("\n");
            sb.Append("  PortId: ").Append(PortId).Append("\n");
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
            return obj.GetType() == GetType() && Equals((VhostsPorts)obj);
        }
        public bool Equals(VhostsPorts other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    VhostId == other.VhostId ||
                    
                    VhostId.Equals(other.VhostId)
                ) && 
                (
                    PortId == other.PortId ||
                    
                    PortId.Equals(other.PortId)
                );
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 41;
                    
                    hashCode = hashCode * 59 + VhostId.GetHashCode();
                    
                    hashCode = hashCode * 59 + PortId.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(VhostsPorts left, VhostsPorts right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(VhostsPorts left, VhostsPorts right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
