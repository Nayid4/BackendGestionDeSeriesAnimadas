using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class AgregacionDeDatos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Contrasena",
                table: "Usuario",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            // Insertar el usuario después del cambio de columna
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT 1 FROM Usuario WHERE NombreDeUsuario = 'admin')
                BEGIN
                    INSERT INTO Usuario (Id, Nombre, Apellido, NombreDeUsuario, Contrasena, FechaDeCreacion, FechaDeActualizacion)
                    VALUES (NEWID(), 'Admin', 'User', 'admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', GETDATE(), GETDATE());
                END
            ");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        { 

            migrationBuilder.Sql("DELETE FROM Usuario WHERE NombreDeUsuario = 'admin';");
            
            migrationBuilder.AlterColumn<string>(
                name: "Contrasena",
                table: "Usuario",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
