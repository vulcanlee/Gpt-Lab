using Microsoft.EntityFrameworkCore;

namespace EntityModel.Models;

public partial class MyDBContext : DbContext
{
    public MyDBContext()
    {
    }

    public MyDBContext(DbContextOptions<MyDBContext> options)
    : base(options)
    {
    }

    #region DbSets
    public DbSet<MyUser> MyUsers { get; set; } = null!;
    public DbSet<MyUserPasswordHistory> MyUserPasswordHistory { get; set; } = null!;
    public DbSet<AccountPolicy> AccountPolicy { get; set; } = null!;
     public DbSet<ExpertDirectory> ExpertDirectory { get; set; } = null!;
     public DbSet<ExpertFile> ExpertFile { get; set; } = null!;
    public DbSet<ExpertFileChunk> ExpertFileChunk { get; set; } = null!;
  #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.UseCollation("Chinese_Taiwan_Stroke_CI_AS");

        #region 設定階層級的刪除政策(預設若關聯子資料表有紀錄，父資料表不可強制刪除
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        #endregion

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
