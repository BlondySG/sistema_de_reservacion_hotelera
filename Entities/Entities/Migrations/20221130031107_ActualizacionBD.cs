using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class ActualizacionBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            //migrationBuilder.CreateTable(
            //    name: "ROL",
            //    columns: table => new
            //    {
            //        IDRol = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NombreRol = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__ROL__A681ACB6B6AA7A5F", x => x.IDRol);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SERVICIO",
            //    columns: table => new
            //    {
            //        IDServicio = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NombreServicio = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        CostoServicio = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__SERVICIO__3CCE7416CDCCF2AB", x => x.IDServicio);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TIPO_HABITACION",
            //    columns: table => new
            //    {
            //        IDTipoHabitacion = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NombreTipoHabitacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        CostoTipoHabitacion = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__TIPO_HAB__1229175B93E4319C", x => x.IDTipoHabitacion);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            //migrationBuilder.CreateTable(
            //    name: "USUARIO",
            //    columns: table => new
            //    {
            //        IDUsuario = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PrimerNombre = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
            //        SegundoNombre = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
            //        PrimerApellido = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
            //        SegundoApellido = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
            //        Username = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
            //        Contrasena = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
            //        IDRol = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__USUARIO__523111698710A7B1", x => x.IDUsuario);
            //        table.ForeignKey(
            //            name: "FK__USUARIO__IDRol__3D5E1FD2",
            //            column: x => x.IDRol,
            //            principalTable: "ROL",
            //            principalColumn: "IDRol");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HABITACION",
            //    columns: table => new
            //    {
            //        IDHabitacion = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PisoHabitacion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        IDTipoHabitacion = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__HABITACI__6B4757DA9CF2F21A", x => x.IDHabitacion);
            //        table.ForeignKey(
            //            name: "FK__HABITACIO__IDTip__38996AB5",
            //            column: x => x.IDTipoHabitacion,
            //            principalTable: "TIPO_HABITACION",
            //            principalColumn: "IDTipoHabitacion");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RESERVACIONES",
            //    columns: table => new
            //    {
            //        IDReservacion = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CantidadNoches = table.Column<int>(type: "int", nullable: false),
            //        NombreCliente = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        CedulaCliente = table.Column<int>(type: "int", nullable: false),
            //        IDHabitacion = table.Column<int>(type: "int", nullable: false),
            //        IDUsuario = table.Column<int>(type: "int", nullable: true),
            //        IDServicio = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__RESERVAC__E970411BE0437683", x => x.IDReservacion);
            //        table.ForeignKey(
            //            name: "FK__RESERVACI__IDHab__403A8C7D",
            //            column: x => x.IDHabitacion,
            //            principalTable: "HABITACION",
            //            principalColumn: "IDHabitacion");
            //        table.ForeignKey(
            //            name: "FK__RESERVACI__IDSer__5CD6CB2B",
            //            column: x => x.IDServicio,
            //            principalTable: "SERVICIO",
            //            principalColumn: "IDServicio");
            //        table.ForeignKey(
            //            name: "FK__RESERVACI__IDUsu__412EB0B6",
            //            column: x => x.IDUsuario,
            //            principalTable: "USUARIO",
            //            principalColumn: "IDUsuario");
            //    });

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

            //migrationBuilder.CreateIndex(
            //    name: "IX_HABITACION_IDTipoHabitacion",
            //    table: "HABITACION",
            //    column: "IDTipoHabitacion");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RESERVACIONES_IDHabitacion",
            //    table: "RESERVACIONES",
            //    column: "IDHabitacion");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RESERVACIONES_IDServicio",
            //    table: "RESERVACIONES",
            //    column: "IDServicio");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RESERVACIONES_IDUsuario",
            //    table: "RESERVACIONES",
            //    column: "IDUsuario");

            //migrationBuilder.CreateIndex(
            //    name: "IX_USUARIO_IDRol",
            //    table: "USUARIO",
            //    column: "IDRol");
        }

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

            //migrationBuilder.DropTable(
            //    name: "RESERVACIONES");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "HABITACION");

            //migrationBuilder.DropTable(
            //    name: "SERVICIO");

            //migrationBuilder.DropTable(
            //    name: "USUARIO");

            //migrationBuilder.DropTable(
            //    name: "TIPO_HABITACION");

            //migrationBuilder.DropTable(
            //    name: "ROL");
        }
    }
}
