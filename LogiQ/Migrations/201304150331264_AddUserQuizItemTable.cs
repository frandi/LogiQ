namespace LogiQ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserQuizItemTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserQuizItems",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        VisitedQuiz = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            AddColumn("dbo.QuizItems", "UserId", c => c.Int());
            AddColumn("dbo.QuizItems", "Visited", c => c.Boolean());
            AddColumn("dbo.QuizItems", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuizItems", "Discriminator");
            DropColumn("dbo.QuizItems", "Visited");
            DropColumn("dbo.QuizItems", "UserId");
            DropTable("dbo.UserQuizItems");
        }
    }
}
