using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aqalnet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_countries", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateOnly>(type: "date", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    mobile_number = table.Column<string>(type: "text", nullable: false),
                    oid = table.Column<string>(type: "text", nullable: false),
                    profile_picture_url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    country_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cities", x => x.id);
                    table.ForeignKey(
                        name: "fk_cities_country_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "properties",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    property_type = table.Column<int>(type: "integer", nullable: false),
                    city_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    about = table.Column<string>(type: "text", nullable: false),
                    street = table.Column<string>(type: "text", nullable: false),
                    street_number = table.Column<int>(type: "integer", nullable: false),
                    area = table.Column<decimal>(
                        type: "numeric(18,2)",
                        precision: 18,
                        scale: 2,
                        nullable: false
                    ),
                    date_published = table.Column<DateOnly>(type: "date", nullable: false),
                    is_published = table.Column<bool>(type: "boolean", nullable: false),
                    price = table.Column<decimal>(
                        type: "numeric(18,2)",
                        precision: 18,
                        scale: 2,
                        nullable: false
                    ),
                    currency = table.Column<string>(type: "text", nullable: false),
                    price_per_square_meter = table.Column<decimal>(
                        type: "numeric(18,2)",
                        precision: 18,
                        scale: 2,
                        nullable: false
                    )
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_properties_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "fk_properties_user_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "apartments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    property_id = table.Column<Guid>(type: "uuid", nullable: false),
                    floor = table.Column<int>(type: "integer", nullable: false),
                    has_balcony = table.Column<bool>(type: "boolean", nullable: false),
                    has_elevator = table.Column<bool>(type: "boolean", nullable: false),
                    has_parking = table.Column<bool>(type: "boolean", nullable: false),
                    number_of_rooms = table.Column<int>(type: "integer", nullable: false),
                    number_of_toilets = table.Column<int>(type: "integer", nullable: false),
                    year_built = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_apartments", x => x.id);
                    table.ForeignKey(
                        name: "fk_apartments_property_property_id",
                        column: x => x.property_id,
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "houses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    property_id = table.Column<Guid>(type: "uuid", nullable: false),
                    has_garage = table.Column<bool>(type: "boolean", nullable: false),
                    has_parking = table.Column<bool>(type: "boolean", nullable: false),
                    number_of_floors = table.Column<int>(type: "integer", nullable: false),
                    number_of_rooms = table.Column<int>(type: "integer", nullable: false),
                    number_of_toilets = table.Column<int>(type: "integer", nullable: false),
                    year_built = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_houses", x => x.id);
                    table.ForeignKey(
                        name: "fk_houses_property_property_id",
                        column: x => x.property_id,
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    property_id = table.Column<Guid>(type: "uuid", nullable: false),
                    alt = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_images", x => x.id);
                    table.ForeignKey(
                        name: "fk_images_properties_property_id",
                        column: x => x.property_id,
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "lands",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    property_id = table.Column<Guid>(type: "uuid", nullable: false),
                    latitude = table.Column<decimal>(
                        type: "numeric(10,7)",
                        precision: 10,
                        scale: 7,
                        nullable: false
                    ),
                    longitude = table.Column<decimal>(
                        type: "numeric(10,7)",
                        precision: 10,
                        scale: 7,
                        nullable: false
                    )
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lands", x => x.id);
                    table.ForeignKey(
                        name: "fk_lands_property_property_id",
                        column: x => x.property_id,
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "ix_apartments_property_id",
                table: "apartments",
                column: "property_id",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "ix_cities_country_id",
                table: "cities",
                column: "country_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_houses_property_id",
                table: "houses",
                column: "property_id",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "ix_images_property_id",
                table: "images",
                column: "property_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_lands_property_id",
                table: "lands",
                column: "property_id",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "ix_properties_city_id",
                table: "properties",
                column: "city_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_properties_user_id",
                table: "properties",
                column: "user_id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "apartments");

            migrationBuilder.DropTable(name: "houses");

            migrationBuilder.DropTable(name: "images");

            migrationBuilder.DropTable(name: "lands");

            migrationBuilder.DropTable(name: "properties");

            migrationBuilder.DropTable(name: "cities");

            migrationBuilder.DropTable(name: "users");

            migrationBuilder.DropTable(name: "countries");
        }
    }
}
