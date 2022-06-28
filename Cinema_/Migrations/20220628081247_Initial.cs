using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                create view CustomData AS
                    select  us.Login, sum(tc.Price) as TotalPaid
                    from Tickets as tc
                    left join Users as us
                    on tc.UserId  = us.Id
                    where tc.IsPaid = 1
                    group by  us.Login
                    order by TotalPaid desc;
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
