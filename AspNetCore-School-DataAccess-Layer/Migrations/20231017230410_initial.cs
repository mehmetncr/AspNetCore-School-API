using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetCore_School_DataAccess_Layer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "District", "Name" },
                values: new object[,]
                {
                    { 1, "Yeşilköy Mahallesi", "Bayrak Lisesi" },
                    { 2, "Merkez Mahallesi", "Güneş Lisesi" },
                    { 3, "Sahil Mahallesi", "Deniz Lisesi" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[,]
                {
                    { 1, "Sınıf 1", 1 },
                    { 2, "Sınıf 2", 1 },
                    { 3, "Sınıf 3", 1 },
                    { 4, "Sınıf 1", 2 },
                    { 5, "Sınıf 2", 2 },
                    { 6, "Sınıf 3", 2 },
                    { 7, "Sınıf 1", 3 },
                    { 8, "Sınıf 2", 3 },
                    { 9, "Sınıf 3", 3 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassId", "Name", "SchoolNo", "SurName" },
                values: new object[,]
                {
                    { 1, 1, "Ahmet", "1001", "Yılmaz" },
                    { 2, 1, "Mehmet", "1002", "Demir" },
                    { 3, 1, "Ayşe", "1003", "Kara" },
                    { 4, 1, "Fatma", "1004", "Kurt" },
                    { 5, 1, "Mustafa", "1005", "Taş" },
                    { 6, 1, "Hatice", "1006", "Aydın" },
                    { 7, 1, "Ali", "1007", "Yıldırım" },
                    { 8, 1, "Nur", "1008", "Sarı" },
                    { 9, 1, "Emir", "1009", "Kara" },
                    { 10, 1, "Ebru", "1010", "Yılmaz" },
                    { 11, 2, "Selin", "1011", "Ateş" },
                    { 12, 2, "Burak", "1012", "Demir" },
                    { 13, 2, "Zeynep", "1013", "Kurt" },
                    { 14, 2, "Kerem", "1014", "Yılmaz" },
                    { 15, 2, "Aslı", "1015", "Taş" },
                    { 16, 2, "Deniz", "1016", "Sarı" },
                    { 17, 2, "Cem", "1017", "Aydın" },
                    { 18, 2, "Elif", "1018", "Kara" },
                    { 19, 2, "Merve", "1019", "Yıldırım" },
                    { 20, 2, "Can", "1020", "Ateş" },
                    { 21, 3, "Ege", "1021", "Kara" },
                    { 22, 3, "Elif", "1022", "Yılmaz" },
                    { 23, 3, "Onur", "1023", "Taş" },
                    { 24, 3, "Yaren", "1024", "Sarı" },
                    { 25, 3, "Cemal", "1025", "Demir" },
                    { 26, 3, "Seda", "1026", "Aydın" },
                    { 27, 3, "Kaan", "1027", "Kurt" },
                    { 28, 3, "Rabia", "1028", "Yıldırım" },
                    { 29, 3, "Tolga", "1029", "Sarı" },
                    { 30, 3, "Aylin", "1030", "Ateş" },
                    { 31, 4, "Defne", "1031", "Kara" },
                    { 32, 4, "Arda", "1032", "Yılmaz" },
                    { 33, 4, "Selin", "1033", "Demir" },
                    { 34, 4, "Kerem", "1034", "Taş" },
                    { 35, 4, "Zeynep", "1035", "Kurt" },
                    { 36, 4, "Ali", "1036", "Aydın" },
                    { 37, 4, "Ela", "1037", "Sarı" },
                    { 38, 4, "Emir", "1038", "Yıldırım" },
                    { 39, 4, "Lina", "1039", "Taş" },
                    { 40, 4, "Aycan", "1040", "Ateş" },
                    { 41, 5, "Eren", "1041", "Kara" },
                    { 42, 5, "Ezgi", "1042", "Yılmaz" },
                    { 43, 5, "Alihan", "1043", "Demir" },
                    { 44, 5, "Sude", "1044", "Taş" },
                    { 45, 5, "Cemre", "1045", "Kurt" },
                    { 46, 5, "Kaan", "1046", "Aydın" },
                    { 47, 5, "Mina", "1047", "Sarı" },
                    { 48, 5, "Ayşenur", "1048", "Yıldırım" },
                    { 49, 5, "Kerim", "1049", "Taş" },
                    { 50, 5, "Lara", "1050", "Ateş" },
                    { 51, 6, "Selin", "2001", "Kara" },
                    { 52, 6, "Arda", "2002", "Yılmaz" },
                    { 53, 6, "Elif", "2003", "Demir" },
                    { 54, 6, "Kerem", "2004", "Taş" },
                    { 55, 6, "Zeynep", "2005", "Kurt" },
                    { 56, 6, "Ali", "2006", "Aydın" },
                    { 57, 6, "Ela", "2007", "Sarı" },
                    { 58, 6, "Emir", "2008", "Yıldırım" },
                    { 59, 6, "Lina", "2009", "Taş" },
                    { 60, 6, "Aycan", "2010", "Ateş" },
                    { 61, 7, "Mehmet", "2011", "Kara" },
                    { 62, 7, "Ceren", "2012", "Yılmaz" },
                    { 63, 7, "Oğuz", "2013", "Demir" },
                    { 64, 7, "Sude", "2014", "Taş" },
                    { 65, 7, "Cemre", "2015", "Kurt" },
                    { 66, 7, "Kaan", "2016", "Aydın" },
                    { 67, 7, "Ela", "2017", "Sarı" },
                    { 68, 7, "Emir", "2018", "Yıldırım" },
                    { 69, 7, "Lina", "2019", "Taş" },
                    { 70, 7, "Aycan", "2020", "Ateş" },
                    { 71, 8, "Selin", "2401", "Kara" },
                    { 72, 8, "Arda", "2402", "Yılmaz" },
                    { 73, 8, "Elif", "2403", "Demir" },
                    { 74, 8, "Kerem", "2404", "Taş" },
                    { 75, 8, "Zeynep", "2405", "Kurt" },
                    { 76, 8, "Ali", "2406", "Aydın" },
                    { 77, 8, "Ela", "2407", "Sarı" },
                    { 78, 8, "Emir", "2408", "Yıldırım" },
                    { 79, 8, "Lina", "2409", "Taş" },
                    { 80, 8, "Aycan", "2410", "Ateş" },
                    { 81, 9, "Eren", "2501", "Kara" },
                    { 82, 9, "Ezgi", "2502", "Yılmaz" },
                    { 83, 9, "Alihan", "2503", "Demir" },
                    { 84, 9, "Sude", "2504", "Taş" },
                    { 85, 9, "Cemre", "2505", "Kurt" },
                    { 86, 9, "Kaan", "2506", "Aydın" },
                    { 87, 9, "Mina", "2507", "Sarı" },
                    { 88, 9, "Ayşenur", "2508", "Yıldırım" },
                    { 89, 9, "Kerim", "2509", "Taş" },
                    { 90, 9, "Lara", "2510", "Ateş" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SchoolId",
                table: "Classes",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
