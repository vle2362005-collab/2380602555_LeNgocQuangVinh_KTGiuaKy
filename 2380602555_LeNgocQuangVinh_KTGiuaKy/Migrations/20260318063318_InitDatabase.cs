using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _2380602555_LeNgocQuangVinh_KTGiuaKy.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocPhans",
                columns: table => new
                {
                    MaHP = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TenHP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SoTinChi = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocPhans", x => x.MaHP);
                });

            migrationBuilder.CreateTable(
                name: "NganhHocs",
                columns: table => new
                {
                    MaNganh = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    TenNganh = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NganhHocs", x => x.MaNganh);
                });

            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    MaSV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaNganh = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.MaSV);
                    table.ForeignKey(
                        name: "FK_SinhViens_NganhHocs_MaNganh",
                        column: x => x.MaNganh,
                        principalTable: "NganhHocs",
                        principalColumn: "MaNganh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DangKies",
                columns: table => new
                {
                    MaDK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDK = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaSV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKies", x => x.MaDK);
                    table.ForeignKey(
                        name: "FK_DangKies_SinhViens_MaSV",
                        column: x => x.MaSV,
                        principalTable: "SinhViens",
                        principalColumn: "MaSV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDangKies",
                columns: table => new
                {
                    MaDK = table.Column<int>(type: "int", nullable: false),
                    MaHP = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDangKies", x => new { x.MaDK, x.MaHP });
                    table.ForeignKey(
                        name: "FK_ChiTietDangKies_DangKies_MaDK",
                        column: x => x.MaDK,
                        principalTable: "DangKies",
                        principalColumn: "MaDK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDangKies_HocPhans_MaHP",
                        column: x => x.MaHP,
                        principalTable: "HocPhans",
                        principalColumn: "MaHP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HocPhans",
                columns: new[] { "MaHP", "SoLuong", "SoTinChi", "TenHP" },
                values: new object[,]
                {
                    { "CNTT01", 99, 3, "Lập trình C" },
                    { "CNTT02", 99, 2, "Cơ sở dữ liệu" },
                    { "QTDK02", 99, 3, "Xác suất thống kê 1" },
                    { "QTKD01", 100, 2, "Kinh tế vi mô" }
                });

            migrationBuilder.InsertData(
                table: "NganhHocs",
                columns: new[] { "MaNganh", "TenNganh" },
                values: new object[,]
                {
                    { "CNTT", "Công nghệ thông tin" },
                    { "QTKD", "Quản trị kinh doanh" }
                });

            migrationBuilder.InsertData(
                table: "SinhViens",
                columns: new[] { "MaSV", "GioiTinh", "Hinh", "HoTen", "MaNganh", "NgaySinh" },
                values: new object[] { "2380602555", "Nam", "/Content/images/sv1.jpg", "Lê Ngọc Quang Vinh", "CNTT", new DateTime(2005, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDangKies_MaHP",
                table: "ChiTietDangKies",
                column: "MaHP");

            migrationBuilder.CreateIndex(
                name: "IX_DangKies_MaSV",
                table: "DangKies",
                column: "MaSV");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_MaNganh",
                table: "SinhViens",
                column: "MaNganh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDangKies");

            migrationBuilder.DropTable(
                name: "DangKies");

            migrationBuilder.DropTable(
                name: "HocPhans");

            migrationBuilder.DropTable(
                name: "SinhViens");

            migrationBuilder.DropTable(
                name: "NganhHocs");
        }
    }
}
