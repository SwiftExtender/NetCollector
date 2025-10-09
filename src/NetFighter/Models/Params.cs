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
    public partial class Params : IEquatable<Params>
    {
        [Key]
        [Required]
        [DataMember(Name="id", EmitDefaultValue=true)]
        public int Id { get; set; }
        [Required]
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
        [DataMember(Name="value", EmitDefaultValue=false)]
        public string Value { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Params {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Params)obj);
        }
        public bool Equals(Params other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||

                    Id.Equals(other.Id)
                ) &&
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) &&
                (
                    Value == other.Value ||
                    Value != null &&
                    Value.Equals(other.Value)
                );
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 41;
                    
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (Value != null)
                    hashCode = hashCode * 59 + Value.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Params left, Params right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Params left, Params right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
