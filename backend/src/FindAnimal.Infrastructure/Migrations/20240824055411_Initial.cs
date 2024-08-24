using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FindAnimal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_species",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tbl_species", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_volunteers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    years_of_experience = table.Column<int>(type: "integer", nullable: false),
                    person_full_name_first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    person_full_name_last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    person_full_name_patronymic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phone_value = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    social_networks = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tbl_volunteers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_breeds",
                columns: table => new
                {
                    breed_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    species_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tbl_breeds", x => x.breed_id);
                    table.ForeignKey(
                        name: "fk_tbl_breeds_tbl_species_species_id",
                        column: x => x.species_id,
                        principalTable: "tbl_species",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_pets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    color = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    helth_information = table.Column<string>(type: "text", nullable: false),
                    height = table.Column<double>(type: "double precision", nullable: false),
                    weigth = table.Column<double>(type: "double precision", nullable: false),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: false),
                    is_castrated = table.Column<bool>(type: "boolean", nullable: false),
                    is_vaccinated = table.Column<bool>(type: "boolean", nullable: false),
                    help_status = table.Column<string>(type: "text", nullable: false),
                    volunteer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    breed_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    species_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    contact_number_value = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    location_address_city = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    location_address_house_number = table.Column<string>(type: "text", nullable: false),
                    location_address_state = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    location_address_street = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    location_address_zip_code = table.Column<string>(type: "text", nullable: false),
                    credentials = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tbl_pets", x => x.id);
                    table.ForeignKey(
                        name: "fk_tbl_pets_tbl_volunteers_volunteer_id",
                        column: x => x.volunteer_id,
                        principalTable: "tbl_volunteers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_volunteers_credentials_list",
                columns: table => new
                {
                    credential_list_volunteer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tbl_volunteers_credentials_list", x => new { x.credential_list_volunteer_id, x.id });
                    table.ForeignKey(
                        name: "fk_tbl_volunteers_credentials_list_tbl_volunteers_credential_l",
                        column: x => x.credential_list_volunteer_id,
                        principalTable: "tbl_volunteers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_petphotos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    path = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    is_main = table.Column<bool>(type: "boolean", nullable: false),
                    photos_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tbl_petphotos", x => x.id);
                    table.ForeignKey(
                        name: "fk_tbl_petphotos_tbl_pets_photos_id",
                        column: x => x.photos_id,
                        principalTable: "tbl_pets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_tbl_breeds_species_id",
                table: "tbl_breeds",
                column: "species_id");

            migrationBuilder.CreateIndex(
                name: "ix_tbl_petphotos_photos_id",
                table: "tbl_petphotos",
                column: "photos_id");

            migrationBuilder.CreateIndex(
                name: "ix_tbl_pets_volunteer_id",
                table: "tbl_pets",
                column: "volunteer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_breeds");

            migrationBuilder.DropTable(
                name: "tbl_petphotos");

            migrationBuilder.DropTable(
                name: "tbl_volunteers_credentials_list");

            migrationBuilder.DropTable(
                name: "tbl_species");

            migrationBuilder.DropTable(
                name: "tbl_pets");

            migrationBuilder.DropTable(
                name: "tbl_volunteers");
        }
    }
}
