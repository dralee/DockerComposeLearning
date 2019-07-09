using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Entity.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[,]
                {
                    { 1, "0e4ba25e-ee5f-4b7e-8dc6-9bac46589b9e", "本教程由Siegrain提供" },
                    { 2, "94083904-632f-4fda-8d6e-190990088f82", "感谢贡献~~" },
                    { 3, "81869890-7f33-4523-9806-dd80f5790db0", "博客地址为http://dralee.com" },
                    { 4, "1e10055f-0093-448d-8ffc-cfbc571dc7c7", "教程内容就是docker的windows下简单使用" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
