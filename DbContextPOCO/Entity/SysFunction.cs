// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace DbContextPOCO.Entity
{

    // SysFunction
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class SysFunction
    {
        public int FunctionId { get; set; } // FunctionId (Primary key)
        public int? TreePanelId { get; set; } // TreePanelId
        public int? SysFunctionGroupId { get; set; } // SysFunctionGroupId
        public string FunctionCode { get; set; } // FunctionCode (length: 50)
        public string FunctionName { get; set; } // FunctionName (length: 50)
        public string ButtonId { get; set; } // ButtonId (length: 50)
        public int? DisplayOrder { get; set; } // Display_Order
        public bool? IsActive { get; set; } // Is_Active
        public System.DateTime? CreateDate { get; set; } // CreateDate
        public int? CreateBy { get; set; } // CreateBy
        public System.DateTime? UpateDate { get; set; } // UpateDate
        public int? UpdateBy { get; set; } // UpdateBy

        // Reverse navigation

        /// <summary>
        /// Child SysFunctionInGroups where [SysFunctionInGroup].[FuctionId] point to this entity (FK_SysFunctionInGroup_SysFunction)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SysFunctionInGroup> SysFunctionInGroups { get; set; } // SysFunctionInGroup.FK_SysFunctionInGroup_SysFunction

        // Foreign keys

        /// <summary>
        /// Parent SysFunctionGroup pointed by [SysFunction].([SysFunctionGroupId]) (FK_SysFunction_SysFunctionGroup)
        /// </summary>
        public virtual SysFunctionGroup SysFunctionGroup { get; set; } // FK_SysFunction_SysFunctionGroup

        public SysFunction()
        {
            SysFunctionInGroups = new System.Collections.Generic.List<SysFunctionInGroup>();
        }
    }

}
// </auto-generated>
