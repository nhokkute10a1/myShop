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

    // Menu
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class Menu
    {
        public int MenuId { get; set; } // Menu_ID (Primary key)
        public int? ParentId { get; set; } // Parent_ID
        public string MenuName { get; set; } // Menu_Name (length: 50)
        public int? DisplayOrder { get; set; } // Display_Order
        public bool? IsActive { get; set; } // Is_Active
    }

}
// </auto-generated>
