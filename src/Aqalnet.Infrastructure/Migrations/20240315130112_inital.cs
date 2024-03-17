using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aqalnet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_name = table.Column<string>(type: "text", nullable: false),
                    street = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    logo_url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_companies", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "agent",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    mobile_number = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent", x => x.id);
                    table.ForeignKey(
                        name: "fk_agent_company_company_id",
                        column: x => x.company_id,
                        principalTable: "Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    mobile_number = table.Column<string>(type: "text", nullable: false),
                    profile_picture_url = table.Column<string>(type: "text", nullable: true),
                    role = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateOnly>(type: "date", nullable: false),
                    updated_at = table.Column<DateOnly>(type: "date", nullable: true),
                    company_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "Companies",
                        principalColumn: "id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    price = table.Column<decimal>(
                        type: "numeric(18,2)",
                        precision: 18,
                        scale: 2,
                        nullable: false
                    ),
                    street = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    is_published = table.Column<bool>(type: "boolean", nullable: false),
                    property_type = table.Column<int>(type: "integer", nullable: false),
                    date_published = table.Column<DateOnly>(type: "date", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_properties_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "Companies",
                        principalColumn: "id"
                    );
                    table.ForeignKey(
                        name: "fk_properties_user_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    property_id = table.Column<Guid>(type: "uuid", nullable: false),
                    has_parking = table.Column<bool>(type: "boolean", nullable: false),
                    has_balcony = table.Column<bool>(type: "boolean", nullable: false),
                    floor = table.Column<int>(type: "integer", nullable: false),
                    has_elevator = table.Column<bool>(type: "boolean", nullable: false),
                    year_built = table.Column<DateOnly>(type: "date", nullable: false),
                    price_per_square_meter = table.Column<decimal>(
                        type: "numeric(18,2)",
                        precision: 18,
                        scale: 2,
                        nullable: false
                    ),
                    living_area = table.Column<decimal>(
                        type: "numeric(18,2)",
                        precision: 18,
                        scale: 2,
                        nullable: false
                    ),
                    number_of_rooms = table.Column<int>(type: "integer", nullable: false),
                    number_of_toilets = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_apartments", x => new { x.id, x.property_id });
                    table.ForeignKey(
                        name: "fk_apartments_properties_id",
                        column: x => x.id,
                        principalTable: "Properties",
                        principalColumn: "id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    property_id = table.Column<Guid>(type: "uuid", nullable: false),
                    has_garage = table.Column<bool>(type: "boolean", nullable: false),
                    has_parking = table.Column<bool>(type: "boolean", nullable: false),
                    number_of_rooms = table.Column<int>(type: "integer", nullable: false),
                    number_of_floors = table.Column<int>(type: "integer", nullable: false),
                    year_built = table.Column<DateOnly>(type: "date", nullable: false),
                    plot_area = table.Column<decimal>(
                        type: "numeric(18,2)",
                        precision: 18,
                        scale: 2,
                        nullable: false
                    ),
                    building_area = table.Column<decimal>(
                        type: "numeric(18,2)",
                        precision: 18,
                        scale: 2,
                        nullable: false
                    ),
                    price_per_square_meter = table.Column<decimal>(
                        type: "numeric(18,2)",
                        precision: 18,
                        scale: 2,
                        nullable: false
                    )
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_houses", x => new { x.id, x.property_id });
                    table.ForeignKey(
                        name: "fk_houses_properties_id",
                        column: x => x.id,
                        principalTable: "Properties",
                        principalColumn: "id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    property_id = table.Column<Guid>(type: "uuid", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                    alt = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_images", x => x.id);
                    table.ForeignKey(
                        name: "fk_images_properties_property_id",
                        column: x => x.property_id,
                        principalTable: "Properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Lands",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    property_id = table.Column<Guid>(type: "uuid", nullable: false),
                    area = table.Column<decimal>(
                        type: "numeric(18,2)",
                        precision: 18,
                        scale: 2,
                        nullable: false
                    ),
                    price_per_square_meter = table.Column<decimal>(
                        type: "numeric(18,2)",
                        precision: 18,
                        scale: 2,
                        nullable: false
                    )
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lands", x => new { x.id, x.property_id });
                    table.ForeignKey(
                        name: "fk_lands_properties_id",
                        column: x => x.id,
                        principalTable: "Properties",
                        principalColumn: "id"
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "ix_agent_company_id",
                table: "agent",
                column: "company_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_apartments_id",
                table: "Apartments",
                column: "id",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "ix_houses_id",
                table: "Houses",
                column: "id",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "ix_images_property_id",
                table: "Images",
                column: "property_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_lands_id",
                table: "Lands",
                column: "id",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "ix_properties_company_id",
                table: "Properties",
                column: "company_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_properties_user_id",
                table: "Properties",
                column: "user_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_users_company_id",
                table: "Users",
                column: "company_id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "agent");

            migrationBuilder.DropTable(name: "Apartments");

            migrationBuilder.DropTable(name: "Houses");

            migrationBuilder.DropTable(name: "Images");

            migrationBuilder.DropTable(name: "Lands");

            migrationBuilder.DropTable(name: "Properties");

            migrationBuilder.DropTable(name: "Users");

            migrationBuilder.DropTable(name: "Companies");
        }
    }
}
