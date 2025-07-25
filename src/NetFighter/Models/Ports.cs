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
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Ports : IEquatable<Ports>
    {
        /// <summary>
        /// Note: This is a Primary Key.&lt;pk/&gt;
        /// </summary>
        /// <value>Note: This is a Primary Key.&lt;pk/&gt;</value>
        [Key]
        [Required]
        [DataMember(Name="id", EmitDefaultValue=true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Number
        /// </summary>
        [Required]
        [DataMember(Name="number", EmitDefaultValue=true)]
        public int Number { get; set; }

        /// <summary>
        /// Note: This is a Foreign Key to &#x60;hosts.id&#x60;.&lt;fk table&#x3D;&#39;hosts&#39; column&#x3D;&#39;id&#39;/&gt;
        /// </summary>
        /// <value>Note: This is a Foreign Key to &#x60;hosts.id&#x60;.&lt;fk table&#x3D;&#39;hosts&#39; column&#x3D;&#39;id&#39;/&gt;</value>
        [Required]
        [DataMember(Name="host_id", EmitDefaultValue=true)]
        public int HostId { get; set; }

        /// <summary>
        /// Gets or Sets Info
        /// </summary>
        [DataMember(Name="info", EmitDefaultValue=false)]
        public string Info { get; set; }

        /// <summary>
        /// Gets or Sets Protocol
        /// </summary>
        [Required]
        [DataMember(Name="protocol", EmitDefaultValue=false)]
        public string Protocol { get; set; }
        public ICollection<VhostsPorts>? VhostPorts { get; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
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

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Ports)obj);
        }

        /// <summary>
        /// Returns true if Ports instances are equal
        /// </summary>
        /// <param name="other">Instance of Ports to be compared</param>
        /// <returns>Boolean</returns>
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

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    
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
