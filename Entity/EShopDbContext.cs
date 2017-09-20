namespace Entity
{
    using Entity.EntityModel;
    using System.Data.Entity;

    public class EShopDbContext : DbContext
    {
        //step 1
        //khai bao cac bang entity ben trong
        public EShopDbContext()
            : base("name=EShopEntities")
        {
            //ko load bang con
            this.Configuration.LazyLoadingEnabled = false;
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Category> Categorys { get; set; }


        //ghi de db context
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}