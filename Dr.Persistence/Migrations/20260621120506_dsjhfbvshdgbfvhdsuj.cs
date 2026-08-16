using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dr.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dsjhfbvshdgbfvhdsuj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calenders",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    IsHoliday = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calenders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryID = table.Column<long>(type: "bigint", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentCategoryID",
                        column: x => x.ParentCategoryID,
                        principalTable: "Category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Minute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RePassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppoinmentCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false),
                    IsVisited = table.Column<bool>(type: "bit", nullable: false),
                    InsuranceID = table.Column<long>(type: "bigint", nullable: false),
                    ServiceID = table.Column<long>(type: "bigint", nullable: false),
                    CalenderID = table.Column<long>(type: "bigint", nullable: false),
                    TimeID = table.Column<long>(type: "bigint", nullable: false),
                    TrackingCode = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointments_Calenders_CalenderID",
                        column: x => x.CalenderID,
                        principalTable: "Calenders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Insurances_InsuranceID",
                        column: x => x.InsuranceID,
                        principalTable: "Insurances",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Services",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Times_TimeID",
                        column: x => x.TimeID,
                        principalTable: "Times",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInRoles",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInRoles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserInRoles_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInRoles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Calenders",
                columns: new[] { "ID", "Date", "InsertTime", "IsHoliday", "IsRemoved", "Message", "RemovedTime", "UpdateTime" },
                values: new object[,]
                {
                    { 1L, new DateOnly(1405, 3, 31), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 2L, new DateOnly(1405, 4, 1), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 3L, new DateOnly(1405, 4, 2), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 4L, new DateOnly(1405, 4, 3), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 5L, new DateOnly(1405, 4, 4), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 6L, new DateOnly(1405, 4, 5), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 7L, new DateOnly(1405, 4, 6), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 8L, new DateOnly(1405, 4, 7), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 9L, new DateOnly(1405, 4, 8), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 10L, new DateOnly(1405, 4, 9), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 11L, new DateOnly(1405, 4, 10), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 12L, new DateOnly(1405, 4, 11), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 13L, new DateOnly(1405, 4, 12), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 14L, new DateOnly(1405, 4, 13), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 15L, new DateOnly(1405, 4, 14), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 16L, new DateOnly(1405, 4, 15), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 17L, new DateOnly(1405, 4, 16), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 18L, new DateOnly(1405, 4, 17), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 19L, new DateOnly(1405, 4, 18), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 20L, new DateOnly(1405, 4, 19), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 21L, new DateOnly(1405, 4, 20), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 22L, new DateOnly(1405, 4, 21), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 23L, new DateOnly(1405, 4, 22), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 24L, new DateOnly(1405, 4, 23), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 25L, new DateOnly(1405, 4, 24), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 26L, new DateOnly(1405, 4, 25), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 27L, new DateOnly(1405, 4, 26), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 28L, new DateOnly(1405, 4, 27), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 29L, new DateOnly(1405, 4, 28), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 30L, new DateOnly(1405, 4, 29), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 31L, new DateOnly(1405, 4, 30), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 32L, new DateOnly(1405, 5, 1), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 33L, new DateOnly(1405, 5, 2), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 34L, new DateOnly(1405, 5, 3), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 35L, new DateOnly(1405, 5, 4), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 36L, new DateOnly(1405, 5, 5), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 37L, new DateOnly(1405, 5, 6), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 38L, new DateOnly(1405, 5, 7), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 39L, new DateOnly(1405, 5, 8), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 40L, new DateOnly(1405, 5, 9), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 41L, new DateOnly(1405, 5, 10), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 42L, new DateOnly(1405, 5, 11), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 43L, new DateOnly(1405, 5, 12), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 44L, new DateOnly(1405, 5, 13), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 45L, new DateOnly(1405, 5, 14), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 46L, new DateOnly(1405, 5, 15), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 47L, new DateOnly(1405, 5, 16), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 48L, new DateOnly(1405, 5, 17), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 49L, new DateOnly(1405, 5, 18), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 50L, new DateOnly(1405, 5, 19), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 51L, new DateOnly(1405, 5, 20), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 52L, new DateOnly(1405, 5, 21), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 53L, new DateOnly(1405, 5, 22), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 54L, new DateOnly(1405, 5, 23), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 55L, new DateOnly(1405, 5, 24), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 56L, new DateOnly(1405, 5, 25), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 57L, new DateOnly(1405, 5, 26), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 58L, new DateOnly(1405, 5, 27), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 59L, new DateOnly(1405, 5, 28), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 60L, new DateOnly(1405, 5, 29), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 61L, new DateOnly(1405, 5, 30), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 62L, new DateOnly(1405, 5, 31), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 63L, new DateOnly(1405, 6, 1), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 64L, new DateOnly(1405, 6, 2), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 65L, new DateOnly(1405, 6, 3), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 66L, new DateOnly(1405, 6, 4), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 67L, new DateOnly(1405, 6, 5), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 68L, new DateOnly(1405, 6, 6), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 69L, new DateOnly(1405, 6, 7), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 70L, new DateOnly(1405, 6, 8), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 71L, new DateOnly(1405, 6, 9), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 72L, new DateOnly(1405, 6, 10), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 73L, new DateOnly(1405, 6, 11), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 74L, new DateOnly(1405, 6, 12), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 75L, new DateOnly(1405, 6, 13), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 76L, new DateOnly(1405, 6, 14), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 77L, new DateOnly(1405, 6, 15), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 78L, new DateOnly(1405, 6, 16), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 79L, new DateOnly(1405, 6, 17), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 80L, new DateOnly(1405, 6, 18), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 81L, new DateOnly(1405, 6, 19), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 82L, new DateOnly(1405, 6, 20), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 83L, new DateOnly(1405, 6, 21), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 84L, new DateOnly(1405, 6, 22), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 85L, new DateOnly(1405, 6, 23), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 86L, new DateOnly(1405, 6, 24), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 87L, new DateOnly(1405, 6, 25), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 88L, new DateOnly(1405, 6, 26), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 89L, new DateOnly(1405, 6, 27), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 90L, new DateOnly(1405, 6, 28), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 91L, new DateOnly(1405, 6, 29), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 92L, new DateOnly(1405, 6, 30), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 93L, new DateOnly(1405, 7, 1), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 94L, new DateOnly(1405, 7, 2), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 95L, new DateOnly(1405, 7, 3), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 96L, new DateOnly(1405, 7, 4), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 97L, new DateOnly(1405, 7, 5), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 98L, new DateOnly(1405, 7, 6), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 99L, new DateOnly(1405, 7, 7), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 100L, new DateOnly(1405, 7, 8), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 101L, new DateOnly(1405, 7, 9), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 102L, new DateOnly(1405, 7, 10), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 103L, new DateOnly(1405, 7, 11), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 104L, new DateOnly(1405, 7, 12), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 105L, new DateOnly(1405, 7, 13), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 106L, new DateOnly(1405, 7, 14), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 107L, new DateOnly(1405, 7, 15), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 108L, new DateOnly(1405, 7, 16), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 109L, new DateOnly(1405, 7, 17), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 110L, new DateOnly(1405, 7, 18), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 111L, new DateOnly(1405, 7, 19), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 112L, new DateOnly(1405, 7, 20), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 113L, new DateOnly(1405, 7, 21), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 114L, new DateOnly(1405, 7, 22), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 115L, new DateOnly(1405, 7, 23), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 116L, new DateOnly(1405, 7, 24), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 117L, new DateOnly(1405, 7, 25), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 118L, new DateOnly(1405, 7, 26), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, null },
                    { 119L, new DateOnly(1405, 7, 27), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null },
                    { 120L, new DateOnly(1405, 7, 28), new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Insurances",
                columns: new[] { "ID", "InsertTime", "IsRemoved", "Name", "RemovedTime", "UpdateTime" },
                values: new object[,]
                {
                    { 2L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "تامین اجتماعی", null, null },
                    { 3L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "خدمات درمانی", null, null },
                    { 4L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "ارتش جمهوری اسلامی ایران", null, null },
                    { 5L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "آزاد / بدون بیمه", null, null },
                    { 6L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "بانک ها", null, null },
                    { 7L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "اتباع محترم خارجی", null, null },
                    { 8L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "سایر بیمه ها", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "InsertTime", "IsRemoved", "RemoveTime", "RoleName", "UpdateTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Admin", null },
                    { 2L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Operator", null },
                    { 3L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Customer", null }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ID", "InsertTime", "IsRemoved", "Name", "Price", "RemovedTime", "UpdateTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "ایمپلنت", 17800000, null, null },
                    { 2L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "لمینیت", 17000000, null, null },
                    { 3L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "ارتودنسی ثابت 2 فک", 95000000, null, null },
                    { 4L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "کامپوزیت", 7000000, null, null },
                    { 5L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "عصب کشی یک کانال", 4500000, null, null },
                    { 6L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "ترمیم دندان", 1500000, null, null },
                    { 7L, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "روکش دندان", 2500000, null, null }
                });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "ID", "Hour", "InsertTime", "IsRemoved", "Minute", "RemovedTime", "UpdateTime" },
                values: new object[,]
                {
                    { 1L, "16", new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "00", null, null },
                    { 2L, "16", new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "30", null, null },
                    { 3L, "17", new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "00", null, null },
                    { 4L, "17", new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "30", null, null },
                    { 5L, "18", new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "00", null, null },
                    { 6L, "18", new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "30", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppoinmentCode",
                table: "Appointments",
                column: "AppoinmentCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CalenderID",
                table: "Appointments",
                column: "CalenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_InsuranceID",
                table: "Appointments",
                column: "InsuranceID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceID",
                table: "Appointments",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TimeID",
                table: "Appointments",
                column: "TimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TrackingCode",
                table: "Appointments",
                column: "TrackingCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryID",
                table: "Category",
                column: "ParentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInRoles_RoleID",
                table: "UserInRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInRoles_UserID",
                table: "UserInRoles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "UserInRoles");

            migrationBuilder.DropTable(
                name: "Calenders");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
