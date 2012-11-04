
namespace HousingConditionWebApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies HouseMetadata as the class
    // that carries additional metadata for the House class.
    [MetadataTypeAttribute(typeof(House.HouseMetadata))]
    public partial class House
    {

        // This class allows you to attach custom attributes to properties
        // of the House class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class HouseMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private HouseMetadata()
            {
            }

            public string Address { get; set; }

            public Nullable<decimal> Cost { get; set; }

            public int ID { get; set; }

            public Nullable<bool> Repairs { get; set; }
        }
    }
}
