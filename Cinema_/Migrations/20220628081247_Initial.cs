using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                create view CustomData AS
                    SELECT
                    us.Id AS Id,
                    us.Login AS Login,
                    COUNT(tc.Id) AS TicketsCount
                FROM
                    Tickets as tc
                    left join Users as us on tc.UserId = us.Id
                GROUP BY
                    us.Id,
                    us.Login
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    drop view CustomData;
                ");
        }
    }
}
