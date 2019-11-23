using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalRegistry.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mobileApps",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    short_description = table.Column<string>(nullable: true),
                    long_description = table.Column<string>(nullable: true),
                    icon_url = table.Column<string>(nullable: true),
                    language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mobileApps", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    info_url = table.Column<string>(nullable: true),
                    mobile_app_count = table.Column<int>(nullable: false),
                    social_media_count = table.Column<int>(nullable: false),
                    gallery_count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Result2",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    short_description = table.Column<string>(nullable: true),
                    long_description = table.Column<string>(nullable: true),
                    icon_url = table.Column<string>(nullable: true),
                    language = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Result3",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    organization = table.Column<string>(nullable: true),
                    account = table.Column<string>(nullable: true),
                    service_key = table.Column<string>(nullable: true),
                    short_description = table.Column<string>(nullable: true),
                    long_description = table.Column<string>(nullable: true),
                    service_display_name = table.Column<string>(nullable: true),
                    service_url = table.Column<string>(nullable: true),
                    language = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result3", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "socialMedias",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    organization = table.Column<string>(nullable: true),
                    account = table.Column<string>(nullable: true),
                    service_key = table.Column<string>(nullable: true),
                    short_description = table.Column<string>(nullable: true),
                    long_description = table.Column<string>(nullable: true),
                    service_display_name = table.Column<string>(nullable: true),
                    service_url = table.Column<string>(nullable: true),
                    language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socialMedias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Version",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    store_url = table.Column<string>(nullable: true),
                    platform = table.Column<string>(nullable: true),
                    version_number = table.Column<string>(nullable: true),
                    publish_date = table.Column<DateTime>(nullable: false),
                    screenshot = table.Column<string>(nullable: true),
                    device = table.Column<string>(nullable: true),
                    average_rating = table.Column<string>(nullable: true),
                    number_of_ratings = table.Column<int>(nullable: false),
                    Result2id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Version", x => x.id);
                    table.ForeignKey(
                        name: "FK_Version_Result2_Result2id",
                        column: x => x.Result2id,
                        principalTable: "Result2",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    info_url = table.Column<string>(nullable: true),
                    Result2id = table.Column<int>(nullable: true),
                    Result3id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.id);
                    table.ForeignKey(
                        name: "FK_Agency_Result2_Result2id",
                        column: x => x.Result2id,
                        principalTable: "Result2",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agency_Result3_Result3id",
                        column: x => x.Result3id,
                        principalTable: "Result3",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tag_text = table.Column<string>(nullable: true),
                    Result2id = table.Column<int>(nullable: true),
                    Result3id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tag_Result2_Result2id",
                        column: x => x.Result2id,
                        principalTable: "Result2",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tag_Result3_Result3id",
                        column: x => x.Result3id,
                        principalTable: "Result3",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agency_Result2id",
                table: "Agency",
                column: "Result2id");

            migrationBuilder.CreateIndex(
                name: "IX_Agency_Result3id",
                table: "Agency",
                column: "Result3id");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Result2id",
                table: "Tag",
                column: "Result2id");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Result3id",
                table: "Tag",
                column: "Result3id");

            migrationBuilder.CreateIndex(
                name: "IX_Version_Result2id",
                table: "Version",
                column: "Result2id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agency");

            migrationBuilder.DropTable(
                name: "mobileApps");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "socialMedias");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Version");

            migrationBuilder.DropTable(
                name: "Result3");

            migrationBuilder.DropTable(
                name: "Result2");
        }
    }
}
