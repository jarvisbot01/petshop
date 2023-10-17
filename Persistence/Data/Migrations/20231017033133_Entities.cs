using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "laboratory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laboratory", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movementType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movementType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "owner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_species", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "vet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    specialty = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vet", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LaboratoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medication_laboratory_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "laboratory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "breed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_breed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_breed_species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicationMovement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicationId = table.Column<int>(type: "int", nullable: false),
                    MovementTypeId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicationMovement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicationMovement_medication_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "medication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicationMovement_movementType_MovementTypeId",
                        column: x => x.MovementTypeId,
                        principalTable: "movementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicationSupplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicationId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicationSupplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicationSupplier_medication_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "medication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicationSupplier_supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pet_breed_BreedId",
                        column: x => x.BreedId,
                        principalTable: "breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pet_owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pet_species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movementDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicationId = table.Column<int>(type: "int", nullable: false),
                    MedicationMovementId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movementDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movementDetail_medicationMovement_MedicationMovementId",
                        column: x => x.MedicationMovementId,
                        principalTable: "medicationMovement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movementDetail_medication_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "medication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    appointmentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    VetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appointment_pet_PetId",
                        column: x => x.PetId,
                        principalTable: "pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_vet_VetId",
                        column: x => x.VetId,
                        principalTable: "vet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicalTreatment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    MedicationId = table.Column<int>(type: "int", nullable: false),
                    dose = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    administrationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    observation = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalTreatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicalTreatment_appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicalTreatment_medication_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "medication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_PetId",
                table: "appointment",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_VetId",
                table: "appointment",
                column: "VetId");

            migrationBuilder.CreateIndex(
                name: "IX_breed_SpeciesId",
                table: "breed",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalTreatment_AppointmentId",
                table: "medicalTreatment",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalTreatment_MedicationId",
                table: "medicalTreatment",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_medication_LaboratoryId",
                table: "medication",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_medicationMovement_MedicationId",
                table: "medicationMovement",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_medicationMovement_MovementTypeId",
                table: "medicationMovement",
                column: "MovementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_medicationSupplier_MedicationId",
                table: "medicationSupplier",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_medicationSupplier_SupplierId",
                table: "medicationSupplier",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_movementDetail_MedicationId",
                table: "movementDetail",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_movementDetail_MedicationMovementId",
                table: "movementDetail",
                column: "MedicationMovementId");

            migrationBuilder.CreateIndex(
                name: "IX_pet_BreedId",
                table: "pet",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_pet_OwnerId",
                table: "pet",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_pet_SpeciesId",
                table: "pet",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicalTreatment");

            migrationBuilder.DropTable(
                name: "medicationSupplier");

            migrationBuilder.DropTable(
                name: "movementDetail");

            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "supplier");

            migrationBuilder.DropTable(
                name: "medicationMovement");

            migrationBuilder.DropTable(
                name: "pet");

            migrationBuilder.DropTable(
                name: "vet");

            migrationBuilder.DropTable(
                name: "medication");

            migrationBuilder.DropTable(
                name: "movementType");

            migrationBuilder.DropTable(
                name: "breed");

            migrationBuilder.DropTable(
                name: "owner");

            migrationBuilder.DropTable(
                name: "laboratory");

            migrationBuilder.DropTable(
                name: "species");
        }
    }
}
