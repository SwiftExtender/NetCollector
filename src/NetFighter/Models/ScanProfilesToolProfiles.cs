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
    public partial class ScanProfilesToolProfiles : IEquatable<ScanProfilesToolProfiles>
    {
        [Key]
        [Required]
        [DataMember(Name = "id", EmitDefaultValue = true)]
        public int Id { get; set; }

        [Required]
        [DataMember(Name="scan_profile_id", EmitDefaultValue=true)]
        public int ScanProfileId { get; set; }

        [Required]
        [DataMember(Name="startup_profile_id", EmitDefaultValue=true)]
        public int StartupProfileId { get; set; }
        [Required]
        [DataMember(Name="order", EmitDefaultValue=true)]
        public int Order { get; set; }
        [DataMember(Name = "created_at", EmitDefaultValue = false)]
        public DateTime CreatedAt { get; set; }
        [DataMember(Name = "updated_at", EmitDefaultValue = false)]
        public DateTime UpdatedAt { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ScanProfilesStartupProfiles {\n");
            sb.Append("  ScanProfileId: ").Append(ScanProfileId).Append("\n");
            sb.Append("  StartupProfileId: ").Append(StartupProfileId).Append("\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ScanProfilesToolProfiles)obj);
        }
        public bool Equals(ScanProfilesToolProfiles other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    ScanProfileId == other.ScanProfileId ||
                    
                    ScanProfileId.Equals(other.ScanProfileId)
                ) && 
                (
                    StartupProfileId == other.StartupProfileId ||
                    
                    StartupProfileId.Equals(other.StartupProfileId)
                ) && 
                (
                    Order == other.Order ||
                    
                    Order.Equals(other.Order)
                );
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 41;
                    
                    hashCode = hashCode * 59 + ScanProfileId.GetHashCode();
                    
                    hashCode = hashCode * 59 + StartupProfileId.GetHashCode();
                    
                    hashCode = hashCode * 59 + Order.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ScanProfilesToolProfiles left, ScanProfilesToolProfiles right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ScanProfilesToolProfiles left, ScanProfilesToolProfiles right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
