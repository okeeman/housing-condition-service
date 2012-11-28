﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace WCFServiceWebRole1.Model
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class HouseConditionEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new HouseConditionEntities object using the connection string found in the 'HouseConditionEntities' section of the application configuration file.
        /// </summary>
        public HouseConditionEntities() : base("name=HouseConditionEntities", "HouseConditionEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new HouseConditionEntities object.
        /// </summary>
        public HouseConditionEntities(string connectionString) : base(connectionString, "HouseConditionEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new HouseConditionEntities object.
        /// </summary>
        public HouseConditionEntities(EntityConnection connection) : base(connection, "HouseConditionEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<House> Houses
        {
            get
            {
                if ((_Houses == null))
                {
                    _Houses = base.CreateObjectSet<House>("Houses");
                }
                return _Houses;
            }
        }
        private ObjectSet<House> _Houses;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Houses EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToHouses(House house)
        {
            base.AddObject("Houses", house);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="HouseConditionModel", Name="House")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class House : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new House object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        public static House CreateHouse(global::System.Int32 id)
        {
            House house = new House();
            house.ID = id;
            return house;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                OnAddressChanging(value);
                ReportPropertyChanging("Address");
                _Address = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Address");
                OnAddressChanged();
            }
        }
        private global::System.String _Address;
        partial void OnAddressChanging(global::System.String value);
        partial void OnAddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> Repairs
        {
            get
            {
                return _Repairs;
            }
            set
            {
                OnRepairsChanging(value);
                ReportPropertyChanging("Repairs");
                _Repairs = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Repairs");
                OnRepairsChanged();
            }
        }
        private Nullable<global::System.Boolean> _Repairs;
        partial void OnRepairsChanging(Nullable<global::System.Boolean> value);
        partial void OnRepairsChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> Cost
        {
            get
            {
                return _Cost;
            }
            set
            {
                OnCostChanging(value);
                ReportPropertyChanging("Cost");
                _Cost = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Cost");
                OnCostChanged();
            }
        }
        private Nullable<global::System.Decimal> _Cost;
        partial void OnCostChanging(Nullable<global::System.Decimal> value);
        partial void OnCostChanged();

        #endregion

    
    }

    #endregion

    
}
