using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.EntityModel
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Category_ID { set; get; }

        [Required]
        public int Category_Parent_ID { set; get; }

        [Required]
        [MaxLength(50)]
        public string Category_NameVN { set; get; }

        [Required]
        [MaxLength(50)]
        public string Category_NameEN { set; get; }

        [MaxLength(255)]
        public string Category_UrlOut { set; get; }

        [Required]
        [MaxLength(255)]
        public string Category_Rewrite { set; get; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Category_SearchVN { set; get; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Category_SearchEN { set; get; }

        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string Category_Icon { set; get; }

        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string Category_Img { set; get; }

        [MaxLength(50)]
        public string Keyword_Titile { set; get; }

        public string Keyword_Content { set; get; }

        public string Keyword_Description { set; get; }

        public DateTime CreateDate { set; get; }
        public int CreateBy { set; get; }
        public DateTime UpdateDate { set; get; }
        public int UpdateBy { set; get; }
        public int Lock { set; get; }
        public bool Is_Active { set; get; }
        public bool Is_HomePage { set; get; }
        public bool Is_TopMenu { set; get; }
        public bool Is_BottomMenu { set; get; }
        public int Display_Order { set; get; }
    }
}