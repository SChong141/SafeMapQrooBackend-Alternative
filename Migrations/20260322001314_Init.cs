using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SafeMapQROOBackend.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    AssignedShelter = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Municipality = table.Column<int>(type: "INTEGER", nullable: false),
                    Available = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Occupancy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CurrentOccupancy = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ShelterId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupancy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occupancy_Shelter_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelter",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "5670b58e-5599-43d7-b178-2d544b2c3585", "Admin", "ADMIN" },
                    { "2", "56022a90-d091-4196-9fa6-2457b3475fd3", "Organizer", "ORGANIZER" }
                });

            migrationBuilder.InsertData(
                table: "Shelter",
                columns: new[] { "Id", "Address", "Available", "Capacity", "CreatedAt", "Deleted", "Latitude", "Longitude", "Municipality", "Name" },
                values: new object[,]
                {
                    { new Guid("052dc3df-88b3-4ae4-8033-23c19f5462ff"), "Km33 Carretera Ideal-Chiquilá", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 21.128569002243346, -87.483637323824993, 6, "Centro de Bachillerato Tecnológico Agropecuario No. 186" },
                    { new Guid("053b4b1d-9c99-4c7f-ba4f-d40c9d071c6f"), "Av. Chetumal S/N Entre Dos Aguadas Y Subteniente López", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 18.527211107161367, -88.300609758892449, 3, "Esc. Sec. Armando Escobar Nava" },
                    { new Guid("0d2a0511-6fa6-49ad-a224-b6742b92ec23"), "C. 42 Constituyentes del 74 & C. 47 Santiago Pacheco, San Antonio Tuk, 77890", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 19.748410893884273, -88.705682018779243, 5, "Esc. Primaria Niños Héroes" },
                    { new Guid("0f2e7997-5e92-45cf-8bf0-6ed2f0b13a88"), "Entre 21 Y 23 Sur", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.496017048999189, -86.954384145423958, 0, "Conalep" },
                    { new Guid("12d5c73b-4ca1-46f1-b1dd-a284376bcf61"), "Mza. 177, Lt. 3, Zona 1, Población Leona Vicario, Puerto Morelos", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.994820791715942, -87.206637911723405, 10, "Iglesia Ríos De Dios" },
                    { new Guid("15cdc779-ec60-485b-9c61-b5dc4cc2fae8"), "C. Brasil entre Bolivia y Av. México Col. La Guadalupana", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.68549552680901, -87.056682441633626, 7, "Esc. Prim. Riviera Maya" },
                    { new Guid("160a0e43-37e8-44d4-a8b6-bfef3894bd3f"), "77333 San Ángel, Q.R.", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 21.233190656324986, -87.434847971671459, 6, "Telesecundaria 'Herminia Medina Loria'" },
                    { new Guid("16636e02-e226-4cb5-bea8-dccbf99582a8"), "Celul Entre Chicozapote Y 30 De Noviembre", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 18.495383653994043, -88.294683737312042, 3, "Eva Sámano De López Mateos" },
                    { new Guid("17192969-847f-49b4-860a-30bf5a7647d5"), "Francisco May", false, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0.0, 0.0, 2, "Escuela Prescolar Comunitario" },
                    { new Guid("172d800b-d236-4272-b3be-2fb3e3381e6b"), "259 Mza. 40 Las Palmas", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 21.15781363698234, -86.913879790078084, 4, "Amado Nervo" },
                    { new Guid("178e50a5-38cc-45d2-aae5-6188e0bb7507"), "Av. 105 Entre C36 Y 38 Col. Pedregal", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.643717950964632, -87.087248854515764, 7, "Esc. Prim. José Fernandez De Lizardi" },
                    { new Guid("185cd024-abbb-4cdf-a9b5-61672e4547b2"), "Av. Insurgentes S/N Km. 6", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 18.515370467529763, -88.352859371161458, 3, "CBTA 11" },
                    { new Guid("1d33879d-88bb-49c0-a6fe-cda36bb43cd8"), "Calle Xiat entre calle Copete y Calle Chicozapote Puerto Aventura", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.511676242860254, -87.234629812056696, 7, "Esc. Prim. Miguel Ortega Navarrete" },
                    { new Guid("2012d99b-3cbe-4941-99ee-3396a7be11a9"), "SM 247 Mza. 13 LT 3 Villas Otoch 2ª Etapa", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 21.197140865657754, -86.86050333123444, 4, "Miguel Hidalgo Y Costilla" },
                    { new Guid("2159fa19-da16-4a04-bff9-2b7d8a6fe28f"), "SM 247 Mza. 33 Villas Otoch 3ª Etapa", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 21.200463843722158, -86.853726557029603, 4, "Escuela Primaria Ek Balam" },
                    { new Guid("221f3b8d-a40d-46c2-8aaf-a7457f938096"), "Reg. 17, Mza 36, Lt. 1 y 2 Calle Caoba", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.85053567421069, -86.903969030582246, 10, "Colegio De Bachilleres Pto. Morelos" },
                    { new Guid("2f1440b6-ca36-413f-af33-2edd9d582210"), "Av. Constituyentes Entre 89 Y 91, Col. Emiliano Zapata", false, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0.0, 0.0, 1, "Centro De Estudios De Bachillerato Rafael Ramírez Castañeda" },
                    { new Guid("323047d3-3914-488e-a0fb-7077401b9495"), "Calle 27 De Septiembre", false, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0.0, 0.0, 6, "C.A.M" },
                    { new Guid("3594c634-c8ce-487c-b5e0-6268b7249c6c"), "Calle Miguel Hidalgo", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 21.10651575229522, -87.484958567773049, 6, "Albergue 'Benito Juárez'" },
                    { new Guid("37dd9787-b186-4e69-b504-2117f966d743"), "Calle 12 entre avenida 9 Y 9ª", false, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0.0, 0.0, 9, "Jardín de Niños Laguna De Bacalar" },
                    { new Guid("38888ca2-8f15-49cd-aeec-dc1ca6e8995f"), "Av. Heriberto Frías No. 562 Esquina Cedro Y Siricote", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 18.525705291267954, -88.275477806131235, 3, "CBTIS 214" },
                    { new Guid("391723ca-e804-445c-814a-2bafc9e5277c"), "Venustiano Carranza Chiapas CP. 30170", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.213710222746002, -87.463116535517528, 8, "Escuela Secundaria Federal #15 'Zamna' TM / TV" },
                    { new Guid("3b752bff-8ffc-4e8f-a3bc-56bd10f819e3"), "Avenida 19a entre calles 38 Y 40", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 18.689105215437817, -88.39290885520002, 9, "Sec. Tec. Ernesto Novelo y Novelo" },
                    { new Guid("3c8b0fdc-9c08-4c18-ba2c-5c45f0566e5b"), "Calle Cherna Col. La Gloria, Isla Mujeres, Isla Mujeres, Quintana Roo C.P. 77402", false, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0.0, 0.0, 2, "Sindicato Único Para Los Trabajadores Al Servicio Del Ayto. De Isla Mujeres" },
                    { new Guid("40650a4e-4a8e-4701-a82c-b435b8cecb55"), "Calle Osiris", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.213708964239601, -87.463117206069768, 8, "Escuela Primaria 'Octaviano Solís Aguirre' T.M Y T.V." },
                    { new Guid("42efa095-a1da-4d2c-8288-7ffae24bc2f0"), "Calle Efraín Pineda Sn Col. 3 Reyes", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 21.110266227473048, -86.945734494307175, 4, "Otilio Montaño" },
                    { new Guid("4f634e3a-b2d5-41f6-9e54-203a23aa8bd9"), "Calle: Sierra, Sm: 006, Mza. 190, Lote: 011, Colonia La Gloria, Cp. 77400", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 21.225088455420973, -86.725707312776251, 2, "Escuela Primaria Julio Sauri Espinosa" },
                    { new Guid("50fc1679-a3c9-4d1f-8b24-c31e72467da1"), "Calle Mercurio", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.208293327631974, -87.457320476622229, 8, "Escuela Primaria 'Ford 198' T.M Y T.V." },
                    { new Guid("58d9c571-7e0e-46bd-afa0-ea0dbe4ab179"), "Av. 80 Esq. C26 Nte. Col. Ejido", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.636713863505857, -87.085735483351868, 7, "Esc. Sec. No. 23 Juan Rulfo" },
                    { new Guid("5a275d60-163e-4aeb-b3dd-c903aa1bab05"), "Calle 30 Entre 75 Y 73 Col. Plan De Ayala", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 19.588223146043042, -88.064325641746109, 1, "Plantel Conalep" },
                    { new Guid("5b6b1c57-da93-4037-9029-815416ab430b"), "Av. Calzada del Sol Con Av. Calzada Puerto Maya Alcaldía Puerto Aventuras", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.510261328614845, -87.228414364750265, 7, "Esc. Sec. José A. Tzuc Esparza" },
                    { new Guid("63d838f5-ba09-4447-8cd2-6e53a7b0f43a"), "Calle 55 Entre 50-a Y 52, Col Lázaro Cárdenas", false, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0.0, 0.0, 1, "Escuela De Educación Especial" },
                    { new Guid("6a0a4b62-6e35-4233-8cc0-363e5eec09ea"), "Calle 15 entre Av. 130 y Av. 135 Col. Bellavista", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.632354656169483, -87.101567518903636, 7, "Esc. Prim. José González López Esquivel" },
                    { new Guid("6a17f2cb-085f-4377-83db-c159692f3dc9"), "Avenida 5 entre calles 12 Y 14", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 18.673971341456461, -88.392410168081128, 9, "Escuela Primaria Rafael Ramírez Castañeda" },
                    { new Guid("6cdfc498-f90e-4569-825a-c5a88d252ca7"), "Calle Vicente Guerrero Y Kohunlich", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 19.749166908290125, -88.715845479087108, 5, "Esc. Primaria Carlos Lugo López" },
                    { new Guid("705f8cc2-6a71-44c9-a30f-f7b365829fe6"), "Calle 80 Entre 61 Y 67 De La Colonia Francisco May", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 19.575971504298611, -88.038594406093679, 1, "Esc. Sec. Tec. José María Luis Mora" },
                    { new Guid("735b50f3-2122-470d-84d4-164f092d6d18"), "Calle Benito Juárez Esquina Santiago Pacheco", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 19.748537443736431, -88.705841389488668, 5, "Esc. Primaria Benito Juárez" },
                    { new Guid("735e6d8a-320f-4be7-ae40-57a6c301a4c1"), "Calle 14 entre avenidas 7 Y 9", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 18.674963588205589, -88.394058247230561, 9, "Esc. Sec. Fed. Vicente Guerrero" },
                    { new Guid("74ae6db3-4fe7-483d-b8c5-db59db0f2a5a"), "Calle 3 S/N Esq. Av. Chetumal", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 18.533446028131031, -88.302344235527571, 3, "Escuela Primaria Francisco Primo De Verdad" },
                    { new Guid("76e5c86e-944f-4eff-9be1-cd759bec5fb7"), "Calle Benito Juárez Esq. 5 De Mayo Y Cecilio Chi", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 19.744573984323505, -88.71029053590398, 5, "Esc. Primaria Agustín Melgar" },
                    { new Guid("7d04da73-166c-4169-aeff-81a60c682437"), "Av. Bosque de la Generosidad Col. Cristo Rey", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.708291805276215, -87.076227601752066, 7, "Esc. Prim. Constituyentes De 1974" },
                    { new Guid("808b0eec-37da-4f08-bd48-8bc1d5af4329"), "Calle Bojon", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.217173432508588, -87.471662750121681, 8, "Escuela Primaria 'Gregorio Pérez Cahuich' TM / TV" },
                    { new Guid("80ec9b6c-9ccc-40e3-87de-9ed366843f32"), "Calle Alfa entre calle 4 Oriente", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.214037722418862, -87.464550646103504, 8, "Instituto de Capacitación para el Trabajo de TULUM (ICAT)" },
                    { new Guid("871088c1-fe86-4b58-9bdb-f25310d75ab9"), "a 97700, C. 52-a 422, Adolfo López Mateos, Yuc.", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 21.12382850497012, -88.159538324053358, 6, "Jacinto Canek" },
                    { new Guid("8a56e722-d982-4ffb-86c9-fb525bcaa487"), "Sacxan Entre Raudales Y Tres Garantías", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 18.526339797397608, -88.305566276683464, 3, "CBTIS 253" },
                    { new Guid("8a7fc629-8d8e-49a4-bdf7-18f41398bffd"), "Lote 001 Mza. 05-06 Región 13", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.205983223350799, -87.505270994412811, 8, "Universidad tecnológica de Tulum" },
                    { new Guid("93c80f15-5602-4429-8731-2a45910fc7ea"), "Av. de las Cigüeñas Entre Av. Loros y Tórtolas Col. Villas Del Sol", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.66978836445206, -87.115752513029136, 7, "Esc. Prim. Independencia De México" },
                    { new Guid("9582302a-7468-41ed-9089-616fb8454e7f"), "Calle Miguel Hidalgo, Col. Guadalupe", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 19.756444646455947, -88.701862272340605, 5, "Colegio De Bachilleres JMM" },
                    { new Guid("997ffda5-0408-483e-9432-7f9db6767ef3"), "Francisco May", false, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0.0, 0.0, 2, "Escuela Rural 'San Antonio' " },
                    { new Guid("99de916b-2dd1-4d78-b25e-06626cb65f56"), "Calle Caoba", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.856127570497915, -86.902564042238737, 10, "Telesecundaria 'Ramon Bravo Prieto'" },
                    { new Guid("9aea0ffa-e1ec-41ab-aa6e-09fd9e5e0285"), "C. Almendro Esq. C. Alamo Alcaldía Puerto Aventuras", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.652396175212225, -87.059175859425949, 7, "Centro De Atención Al Migrante" },
                    { new Guid("a401cce6-3582-472c-9a2b-e0b3fa1d3ed8"), "Av. Xel-ha Esq. Corales Col. La Guadalupana", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.656533270672895, -87.116255523365282, 7, "Conalep" },
                    { new Guid("ad79289a-8ed9-420d-a91b-606f8dfb683b"), "Calle Agustín Melgar", false, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 21.351966506718576, -87.430164143462861, 6, "Secundaria Terencio Tah Quetzal" },
                    { new Guid("b2c89b0b-759a-4aa0-a204-bb0dc85b4aa7"), "Carretera Fed. Cancún-vallad", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.881945592688428, -87.532865450328828, 6, "Colegio de Bachilleres Plantel Ignacio Zaragoza" },
                    { new Guid("b78ed8d8-37ae-4165-b77c-5f8e1265c874"), "Calle: 2 Entre Calle: 40 Sur Y Calle: 38 Sur, El Centro Comunitario, Rancho Viejo, Centro Urbano.", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 21.22607331145349, -86.851489829327932, 2, "Centro Comunitario, Zona Continental" },
                    { new Guid("b966fa02-d2b2-4a9f-ae6b-a48e27a07bb3"), "Sin Cruzamientos", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.4865903108536, -86.943468600511522, 0, "Centro De Estudio Tecnológico Del Mar 33" },
                    { new Guid("c28535ae-3d92-4f31-83c8-70ccadeb536b"), "Reg. 236 Mza. 24 Lote 33", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 21.201405877622058, -86.835542309713418, 4, "Año Del Centenario De Q.Roo" },
                    { new Guid("c4a7bc83-a425-4236-a3fb-fd4cc1d7d0d3"), "Rancho Viejo, Centro Urbano", false, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0.0, 0.0, 2, "Colegio De Bachilleres, Zona Continental" },
                    { new Guid("cc4b5b08-9ae7-4f37-8697-90123ea286e3"), "Calle Noh Bec/Laguna San Felipe Y Xul-ha", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 18.519882569200256, -88.335114092623812, 3, "Esc. Primaria Guadalupe Victoria" },
                    { new Guid("cec8cbbd-91a8-447c-8522-d252546145d2"), "Entre 27 Y 31 Sur", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.491025387279585, -86.954710406055867, 0, "Colegio De Bachilleres" },
                    { new Guid("da9c5718-2686-4611-a94e-35f4b3fa0101"), "Av. Luis Echeverria Con Salinas De Gortari", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 21.089886339335585, -86.85703588333395, 4, "Bachilleres 3" },
                    { new Guid("dc033e06-35ed-4b47-90dc-6294bf986e88"), "Calle 66 Entre 69 Y Av. Lázaro Cárdenas #783, Col. Centro", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 19.579954512625008, -88.045826637392167, 1, "Esc. Prim. Moisés Sáenz" },
                    { new Guid("dd72279a-bf37-4cc4-8a28-04af8547f544"), "Av. 135 Entre C. 1era Y 3 Sur, Col Bellavista", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.635912503977863, -87.100272452680386, 7, "Esc. Prim. Mario Chan Hoyos" },
                    { new Guid("de97a8c7-c7db-4018-9c90-d0f5058d90ed"), "Calle 4 con Av. 19 C", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 18.677695316042485, -88.392950699837371, 9, "Comedor Comunitario" },
                    { new Guid("e1553996-752e-4760-a68f-1e8a93245c1a"), "Reforma Agraria", false, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 21.10562743813621, -87.485876705139603, 6, "Kantunilkin" },
                    { new Guid("e17a7d1d-0951-4c94-92f6-77fe04f5ecab"), "C.88 entre Av. 20 Y 25 Col. Colosio", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.648489217384746, -87.060713131202036, 7, "Esc. Prim. Gregoria Cob Cob" },
                    { new Guid("e5412ed0-319f-4f64-9093-5192f25100e4"), "C. Trinidad Y Tobago Esq. Cancún Col. La Guadalupana", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.680611493774979, -87.046634566279153, 7, "Esc. Prim. Urb. Fed. Jaime Torres" },
                    { new Guid("e6108dbc-db8c-40b9-8642-21cc95df25f0"), "Calle 4 Ote", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.213798798263635, -87.464981853920406, 8, "CECYTE Plantel Tulum" },
                    { new Guid("e8983888-50f1-4fa6-a820-0e1fb1dcfc96"), "Carr. Costera del Golfo 295, 77380 Nuevo Xcán, Q.R.", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.870816194387903, -87.602493388787138, 6, "Ramón Osorio Y Osorio" },
                    { new Guid("ebf6d083-4f60-4563-bf13-407ad2f8106a"), "Entre 35 Y 37 Sur", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.482103327599656, -86.952134442252998, 0, "Esc. Sec. Octavio Paz" },
                    { new Guid("ec54c54e-5db4-47c3-9d82-38c7e54925df"), "C. Emiliano Zapata S/N, Entre Carranza Y Primo De Verdad.", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 18.506674340398099, -88.301716254010174, 3, "Escuela Primaria Francisco I. Madero" },
                    { new Guid("ee162152-451e-4b7e-86a6-d173feb52ffc"), "Entre Calles Coral Y Delfín", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.487221935756299, -86.925994447775636, 0, "Esc. Sec. Carlos Monsiváis" },
                    { new Guid("f1fca176-c51d-40ba-a046-59790d1cf8ca"), "Calle Mercurio", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.207555286203757, -87.465820152086536, 8, "Escuela Primaria 'Julio Ruelas' TM / TV" },
                    { new Guid("f20090a1-cc86-4f30-b142-d4bac72a4a69"), "Colonia La Granja", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.994028250826879, -87.211871843233396, 10, "Yucatán Península Misión" },
                    { new Guid("f2759cf4-b715-46fa-86d0-973920f3c1d8"), "Calle Júpiter Sur", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.209647664177151, -87.465278841651966, 8, "Escuela Telesecundaria 'Erick Paolo Martínez' TM / TV" },
                    { new Guid("f4c825e4-e7ff-4eb5-b1aa-643ff2243f30"), "Eje de la Aurora Esq. Calzada del Sol Alcaldía Puerto Aventuras", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 20.686807193341103, -87.049751942954828, 7, "Esc. Prim. Luis Donaldo Colosio Murrieta" },
                    { new Guid("f613793a-106f-4f45-a63c-6f64f9458a6d"), "Av. 9 con calle 20", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 18.677992165641122, -88.392907660079146, 9, "Casa del Adulto Mayor" },
                    { new Guid("f94e8d35-7eb4-4b02-b2ac-b23efae7028d"), "Av. Lázaro Cárdenas #117 Por Calle 56 Y 60 Col. Cecilio Chi", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 19.581909388815529, -88.049994505740557, 1, "Esc. Sec. Leona Vicario" },
                    { new Guid("fa7c249a-f85a-42f4-bcd0-341ec09168ff"), "Calle Sax kin", false, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0.0, 0.0, 8, "Escuela Primaria 'Tulum' TM / TV" },
                    { new Guid("fe39670c-14fa-4d19-9cbf-4f8b08d6f921"), "Calle 60 Por Calle 77 Y 79, Col. Leona Vicario", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 19.585141347295604, -88.048711057034055, 1, "Esc. Prim. Don Felipe Carrillo Puerto" },
                    { new Guid("ff96b934-d876-4fb8-a643-9cc46c501eca"), "Calle Benito Juárez, Esq. 5 De Mayo", true, 500, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 19.743748669434591, -88.711222558236713, 5, "Secundaria Lic. Andrés Q,Roo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Occupancy_ShelterId",
                table: "Occupancy",
                column: "ShelterId");
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
                name: "Occupancy");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Shelter");
        }
    }
}
