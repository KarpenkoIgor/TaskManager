using Microsoft.EntityFrameworkCore;
using MyTaskManager.Projects;
using MyTaskManager.ProjectUsers;
using MyTaskManager.Tasks;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace MyTaskManager.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class MyTaskManagerDbContext :
    AbpDbContext<MyTaskManagerDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Project> Projects { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<ProjectUser>  ProjectUsers { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public MyTaskManagerDbContext(DbContextOptions<MyTaskManagerDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();


        builder.Entity<ProjectUser>(b => 
        {
            b.ToTable(MyTaskManagerConsts.DbTablePrefix + "ProjectUsers", MyTaskManagerConsts.DbSchema);
            b.ConfigureByConvention();
        });
        builder.Entity<Task>(b =>
        {
            b.ToTable(MyTaskManagerConsts.DbTablePrefix + "Tasks", MyTaskManagerConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            b.Property(t => t.Description)
                .HasMaxLength(1000);

            b.Property(t => t.ProjectUserId)
                .IsRequired();

            b.Property(t => t.DeadLine)
                .IsRequired();

            b.Property(t => t.IsClosed)
                .IsRequired();
        });

        builder.Entity<Comment>(b =>
        {
            b.ToTable(MyTaskManagerConsts.DbTablePrefix + "Comments", MyTaskManagerConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(c => c.Text)
                .IsRequired()
                .HasMaxLength(1000);

            b.Property(c => c.UserId)
                .IsRequired();
/*
            b.HasOne<Task>()
                .WithMany()
                .HasForeignKey(c => c.TaskId)
                .OnDelete(DeleteBehavior.Cascade);*/
        });

        builder.Entity<Project>(b =>
        {
            b.ToTable(MyTaskManagerConsts.DbTablePrefix + "Projects", MyTaskManagerConsts.DbSchema);

            b.HasKey(p => p.Id);

            b.Property(p => p.ProjectName)
                .IsRequired()
                .HasMaxLength(255);

            b.Property(p => p.ProjectDescription)
                .HasMaxLength(1000);

            b.Property(p => p.DeadLine)
                .IsRequired();
        });

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(MyTaskManagerConsts.DbTablePrefix + "YourEntities", MyTaskManagerConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
