namespace Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 8000, unicode: false),
                        Email = c.String(maxLength: 8000, unicode: false),
                        Senha = c.String(maxLength: 8000, unicode: false),
                        DataInclusao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
        }
    }
}
