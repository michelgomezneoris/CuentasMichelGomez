using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CuentasMichelGomez.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tipo_cuenta",
                columns: table => new
                {
                    tipo_cuenta_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "Varchar(1024)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_cuenta", x => x.tipo_cuenta_id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_identificacion",
                columns: table => new
                {
                    tipo_identificacion_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "Varchar(1024)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_identificacion", x => x.tipo_identificacion_id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_movimiento",
                columns: table => new
                {
                    tipo_movimiento_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "Varchar(1024)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_movimiento", x => x.tipo_movimiento_id);
                });

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    persona_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "Varchar(1024)", nullable: false),
                    genero = table.Column<string>(type: "Varchar(1024)", nullable: false),
                    edad = table.Column<int>(type: "integer", nullable: false),
                    tipo_identificacion_id = table.Column<long>(type: "bigint", nullable: false),
                    identificacion = table.Column<string>(type: "Varchar(1024)", nullable: false),
                    direccion = table.Column<string>(type: "Varchar(1024)", nullable: false),
                    telefono = table.Column<string>(type: "Varchar(1024)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.persona_id);
                    table.ForeignKey(
                        name: "FK_persona_tipo_identificacion_tipo_identificacion_id",
                        column: x => x.tipo_identificacion_id,
                        principalTable: "tipo_identificacion",
                        principalColumn: "tipo_identificacion_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    cliente_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usuario = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    estado = table.Column<bool>(type: "boolean", nullable: true),
                    persona_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.cliente_id);
                    table.ForeignKey(
                        name: "FK_cliente_persona_persona_id",
                        column: x => x.persona_id,
                        principalTable: "persona",
                        principalColumn: "persona_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cuenta",
                columns: table => new
                {
                    cuenta_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo_cuenta_id = table.Column<long>(type: "bigint", nullable: false),
                    numero_cuenta = table.Column<string>(type: "Varchar(1024)", nullable: false),
                    saldo = table.Column<int>(type: "integer", nullable: false),
                    estado = table.Column<bool>(type: "boolean", nullable: false),
                    cliente_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuenta", x => x.cuenta_id);
                    table.ForeignKey(
                        name: "FK_cuenta_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "cliente_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cuenta_tipo_cuenta_tipo_cuenta_id",
                        column: x => x.tipo_cuenta_id,
                        principalTable: "tipo_cuenta",
                        principalColumn: "tipo_cuenta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movimiento",
                columns: table => new
                {
                    movimiento_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo_movimiento_id = table.Column<long>(type: "bigint", nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: false),
                    saldo_inicial = table.Column<int>(type: "integer", nullable: false),
                    valor = table.Column<int>(type: "integer", nullable: false),
                    saldo = table.Column<int>(type: "integer", nullable: false),
                    cuenta_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimiento", x => x.movimiento_id);
                    table.ForeignKey(
                        name: "FK_movimiento_cuenta_cuenta_id",
                        column: x => x.cuenta_id,
                        principalTable: "cuenta",
                        principalColumn: "cuenta_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movimiento_tipo_movimiento_tipo_movimiento_id",
                        column: x => x.tipo_movimiento_id,
                        principalTable: "tipo_movimiento",
                        principalColumn: "tipo_movimiento_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_persona_id",
                table: "cliente",
                column: "persona_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cuenta_cliente_id",
                table: "cuenta",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_cuenta_tipo_cuenta_id",
                table: "cuenta",
                column: "tipo_cuenta_id");

            migrationBuilder.CreateIndex(
                name: "IX_movimiento_cuenta_id",
                table: "movimiento",
                column: "cuenta_id");

            migrationBuilder.CreateIndex(
                name: "IX_movimiento_tipo_movimiento_id",
                table: "movimiento",
                column: "tipo_movimiento_id");

            migrationBuilder.CreateIndex(
                name: "IX_persona_tipo_identificacion_id",
                table: "persona",
                column: "tipo_identificacion_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimiento");

            migrationBuilder.DropTable(
                name: "cuenta");

            migrationBuilder.DropTable(
                name: "tipo_movimiento");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "tipo_cuenta");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "tipo_identificacion");
        }
    }
}
