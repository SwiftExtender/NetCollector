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
    public partial class Urls : IEquatable<Urls>
    {
        [Key]
        [Required]
        [DataMember(Name="id", EmitDefaultValue=true)]
        public int Id { get; set; }
        [Required]
        [DataMember(Name="url", EmitDefaultValue=false)]
        public string Url { get; set; }
        [Required]
        [DataMember(Name="vhost_id", EmitDefaultValue=true)]
        public int VhostId { get; set; }
        [DataMember(Name="info", EmitDefaultValue=false)]
        public string Info { get; set; }
        [DataMember(Name = "created_at", EmitDefaultValue = false)]
        public DateTime CreatedAt { get; set; }
        [DataMember(Name = "updated_at", EmitDefaultValue = false)]
        public DateTime UpdatedAt { get; set; }
        public ICollection<Requests> Requests { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Urls {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  VhostId: ").Append(VhostId).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Urls)obj);
        }
        public bool Equals(Urls other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    
                    Id.Equals(other.Id)
                ) && 
                (
                    Url == other.Url ||
                    Url != null &&
                    Url.Equals(other.Url)
                ) && 
                (
                    VhostId == other.VhostId ||
                    
                    VhostId.Equals(other.VhostId)
                ) && 
                (
                    Info == other.Info ||
                    Info != null &&
                    Info.Equals(other.Info)
                );
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 41;
                    
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Url != null)
                    hashCode = hashCode * 59 + Url.GetHashCode();
                    
                    hashCode = hashCode * 59 + VhostId.GetHashCode();
                    if (Info != null)
                    hashCode = hashCode * 59 + Info.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Urls left, Urls right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Urls left, Urls right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
