namespace WebApiCapacitacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CARGAS_FAMILIARES : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CARGAS_FAMILIARES",
                c => new
                    {
                        CARFAM_ID = c.Int(nullable: false, identity: true),
                        CARFAM_NOMBRE = c.String(),
                        EMP_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CARFAM_ID)
                .ForeignKey("dbo.EMPLEADOS", t => t.EMP_ID, cascadeDelete: true)
                .Index(t => t.EMP_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CARGAS_FAMILIARES", "EMP_ID", "dbo.EMPLEADOS");
            DropIndex("dbo.CARGAS_FAMILIARES", new[] { "EMP_ID" });
            DropTable("dbo.CARGAS_FAMILIARES");
        }
    }
}
