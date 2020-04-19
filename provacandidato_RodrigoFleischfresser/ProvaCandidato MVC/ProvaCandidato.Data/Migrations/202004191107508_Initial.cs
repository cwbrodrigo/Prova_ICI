namespace ProvaCandidato.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        data_nascimento = c.DateTime(),
                        CidadeId = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.Cidade", t => t.CidadeId, cascadeDelete: true)
                .Index(t => t.CidadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cliente", "CidadeId", "dbo.Cidade");
            DropIndex("dbo.Cliente", new[] { "CidadeId" });
            DropTable("dbo.Cliente");
            DropTable("dbo.Cidade");
        }
    }
}
