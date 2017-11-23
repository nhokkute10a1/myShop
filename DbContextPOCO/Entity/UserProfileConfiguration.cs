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

    // UserProfile
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class UserProfileConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UserProfile>
    {
        public UserProfileConfiguration()
            : this("dbo")
        {
        }

        public UserProfileConfiguration(string schema)
        {
            ToTable("UserProfile", schema);
            HasKey(x => x.UserProfileId);

            Property(x => x.UserProfileId).HasColumnName(@"UserProfile_ID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UserProfileLastName).HasColumnName(@"UserProfile_LastName").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.UserProfileFirstName).HasColumnName(@"UserProfile_FirstName").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.UserProfileFullName).HasColumnName(@"UserProfile_FullName").HasColumnType("nvarchar").IsRequired().HasMaxLength(255);
            Property(x => x.UserProfileBirthDay).HasColumnName(@"UserProfile_BirthDay").HasColumnType("datetime").IsOptional();
            Property(x => x.UserProfileAge).HasColumnName(@"UserProfile_Age").HasColumnType("int").IsOptional();
            Property(x => x.UserProfileGender).HasColumnName(@"UserProfile_Gender").HasColumnType("int").IsOptional();
            Property(x => x.UserProfilePhone).HasColumnName(@"UserProfile_Phone").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(20);
            Property(x => x.UserProfileEmail).HasColumnName(@"UserProfile_Email").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.UserProfilePass).HasColumnName(@"UserProfile_Pass").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.UserProfileAboutMe).HasColumnName(@"UserProfile_About_Me").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.UserProfileAvatar).HasColumnName(@"UserProfile_Avatar").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.UserProfileConnectId).HasColumnName(@"UserProfile_ConnectID").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").HasColumnType("datetime").IsOptional();
            Property(x => x.UpdateDate).HasColumnName(@"UpdateDate").HasColumnType("datetime").IsOptional();
            Property(x => x.Lock).HasColumnName(@"Lock").HasColumnType("int").IsOptional();
            Property(x => x.IsActive).HasColumnName(@"Is_Active").HasColumnType("bit").IsOptional();
        }
    }

}
// </auto-generated>
