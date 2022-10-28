using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroServiceTask.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Members",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamMemberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    YearOfExp = table.Column<int>(type: "int", nullable: false),
                    SkillSet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectstartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectendDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllocationPercentage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                schema: "dbo",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    membersId = table.Column<int>(type: "int", nullable: true),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deliverables = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskstartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskendDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Members_membersId",
                        column: x => x.membersId,
                        principalSchema: "dbo",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_membersId",
                schema: "dbo",
                table: "Tasks",
                column: "membersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "dbo");
        }
    }
}
