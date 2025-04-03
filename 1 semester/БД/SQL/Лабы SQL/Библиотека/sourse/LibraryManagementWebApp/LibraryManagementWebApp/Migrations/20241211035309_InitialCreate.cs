using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Авторы",
                columns: table => new
                {
                    ID_автора = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Авторы", x => x.ID_автора);
                });

            migrationBuilder.CreateTable(
                name: "Жанры",
                columns: table => new
                {
                    ID_жанра = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Жанры", x => x.ID_жанра);
                });

            migrationBuilder.CreateTable(
                name: "Издательства",
                columns: table => new
                {
                    ID_издательства = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Издательства", x => x.ID_издательства);
                });

            migrationBuilder.CreateTable(
                name: "Книги",
                columns: table => new
                {
                    ID_книги = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Книги", x => x.ID_книги);
                });

            migrationBuilder.CreateTable(
                name: "Комнаты",
                columns: table => new
                {
                    ID_комнаты = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Комнаты", x => x.ID_комнаты);
                });

            migrationBuilder.CreateTable(
                name: "Сотрудники_библиотеки",
                columns: table => new
                {
                    ID_сотрудника = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сотрудники_библиотеки", x => x.ID_сотрудника);
                });

            migrationBuilder.CreateTable(
                name: "Справочник_операций",
                columns: table => new
                {
                    ID_операции = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Справочник_операций", x => x.ID_операции);
                });

            migrationBuilder.CreateTable(
                name: "Читатели",
                columns: table => new
                {
                    ID_читателя = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Читательский_билет = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Читатели", x => x.ID_читателя);
                });

            migrationBuilder.CreateTable(
                name: "Авторы_книги",
                columns: table => new
                {
                    ID_автора_книги = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKкниги = table.Column<int>(type: "int", nullable: false),
                    FKавтора = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Авторы_книги", x => x.ID_автора_книги);
                    table.ForeignKey(
                        name: "FK_Авторы_книги_Авторы_FKавтора",
                        column: x => x.FKавтора,
                        principalTable: "Авторы",
                        principalColumn: "ID_автора",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Авторы_книги_Книги_FKкниги",
                        column: x => x.FKкниги,
                        principalTable: "Книги",
                        principalColumn: "ID_книги",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Жанры_книги",
                columns: table => new
                {
                    ID_жанра_книги = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKкниги = table.Column<int>(type: "int", nullable: false),
                    FKжанра = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Жанры_книги", x => x.ID_жанра_книги);
                    table.ForeignKey(
                        name: "FK_Жанры_книги_Жанры_FKжанра",
                        column: x => x.FKжанра,
                        principalTable: "Жанры",
                        principalColumn: "ID_жанра",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Жанры_книги_Книги_FKкниги",
                        column: x => x.FKкниги,
                        principalTable: "Книги",
                        principalColumn: "ID_книги",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Издательства_книги",
                columns: table => new
                {
                    ID_издательства = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKкниги = table.Column<int>(type: "int", nullable: false),
                    FKиздательства = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Издательства_книги", x => x.ID_издательства);
                    table.ForeignKey(
                        name: "FK_Издательства_книги_Издательства_FKиздательства",
                        column: x => x.FKиздательства,
                        principalTable: "Издательства",
                        principalColumn: "ID_издательства",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Издательства_книги_Книги_FKкниги",
                        column: x => x.FKкниги,
                        principalTable: "Книги",
                        principalColumn: "ID_книги",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Популярные_книги",
                columns: table => new
                {
                    ID_популярной_книги = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKкниги = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Популярные_книги", x => x.ID_популярной_книги);
                    table.ForeignKey(
                        name: "FK_Популярные_книги_Книги_FKкниги",
                        column: x => x.FKкниги,
                        principalTable: "Книги",
                        principalColumn: "ID_книги",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Секции",
                columns: table => new
                {
                    ID_секции = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKкомнаты = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Секции", x => x.ID_секции);
                    table.ForeignKey(
                        name: "FK_Секции_Комнаты_FKкомнаты",
                        column: x => x.FKкомнаты,
                        principalTable: "Комнаты",
                        principalColumn: "ID_комнаты",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ряды",
                columns: table => new
                {
                    ID_ряда = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKсекции = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ряды", x => x.ID_ряда);
                    table.ForeignKey(
                        name: "FK_Ряды_Секции_FKсекции",
                        column: x => x.FKсекции,
                        principalTable: "Секции",
                        principalColumn: "ID_секции",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Полки",
                columns: table => new
                {
                    ID_полки = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKряда = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Полки", x => x.ID_полки);
                    table.ForeignKey(
                        name: "FK_Полки_Ряды_FKряда",
                        column: x => x.FKряда,
                        principalTable: "Ряды",
                        principalColumn: "ID_ряда",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ячейки",
                columns: table => new
                {
                    ID_ячейки = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKполки = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ячейки", x => x.ID_ячейки);
                    table.ForeignKey(
                        name: "FK_Ячейки_Полки_FKполки",
                        column: x => x.FKполки,
                        principalTable: "Полки",
                        principalColumn: "ID_полки",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Экземпляры_книги",
                columns: table => new
                {
                    ID_экземпляра_книги = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKкниги = table.Column<int>(type: "int", nullable: false),
                    FKячейки = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Экземпляры_книги", x => x.ID_экземпляра_книги);
                    table.ForeignKey(
                        name: "FK_Экземпляры_книги_Книги_FKкниги",
                        column: x => x.FKкниги,
                        principalTable: "Книги",
                        principalColumn: "ID_книги",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Экземпляры_книги_Ячейки_FKячейки",
                        column: x => x.FKячейки,
                        principalTable: "Ячейки",
                        principalColumn: "ID_ячейки",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Формуляры",
                columns: table => new
                {
                    ID_формуляра = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Дата_операции = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Сроки_пользования = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FKэкземпляра_книги = table.Column<int>(type: "int", nullable: false),
                    FKчитателя = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Формуляры", x => x.ID_формуляра);
                    table.ForeignKey(
                        name: "FK_Формуляры_Читатели_FKчитателя",
                        column: x => x.FKчитателя,
                        principalTable: "Читатели",
                        principalColumn: "ID_читателя",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Формуляры_Экземпляры_книги_FKэкземпляра_книги",
                        column: x => x.FKэкземпляра_книги,
                        principalTable: "Экземпляры_книги",
                        principalColumn: "ID_экземпляра_книги",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Авторы_книги_FKавтора",
                table: "Авторы_книги",
                column: "FKавтора");

            migrationBuilder.CreateIndex(
                name: "IX_Авторы_книги_FKкниги",
                table: "Авторы_книги",
                column: "FKкниги");

            migrationBuilder.CreateIndex(
                name: "IX_Жанры_книги_FKжанра",
                table: "Жанры_книги",
                column: "FKжанра");

            migrationBuilder.CreateIndex(
                name: "IX_Жанры_книги_FKкниги",
                table: "Жанры_книги",
                column: "FKкниги");

            migrationBuilder.CreateIndex(
                name: "IX_Издательства_книги_FKиздательства",
                table: "Издательства_книги",
                column: "FKиздательства");

            migrationBuilder.CreateIndex(
                name: "IX_Издательства_книги_FKкниги",
                table: "Издательства_книги",
                column: "FKкниги");

            migrationBuilder.CreateIndex(
                name: "IX_Полки_FKряда",
                table: "Полки",
                column: "FKряда");

            migrationBuilder.CreateIndex(
                name: "IX_Популярные_книги_FKкниги",
                table: "Популярные_книги",
                column: "FKкниги");

            migrationBuilder.CreateIndex(
                name: "IX_Ряды_FKсекции",
                table: "Ряды",
                column: "FKсекции");

            migrationBuilder.CreateIndex(
                name: "IX_Секции_FKкомнаты",
                table: "Секции",
                column: "FKкомнаты");

            migrationBuilder.CreateIndex(
                name: "IX_Формуляры_FKчитателя",
                table: "Формуляры",
                column: "FKчитателя");

            migrationBuilder.CreateIndex(
                name: "IX_Формуляры_FKэкземпляра_книги",
                table: "Формуляры",
                column: "FKэкземпляра_книги");

            migrationBuilder.CreateIndex(
                name: "IX_Экземпляры_книги_FKкниги",
                table: "Экземпляры_книги",
                column: "FKкниги");

            migrationBuilder.CreateIndex(
                name: "IX_Экземпляры_книги_FKячейки",
                table: "Экземпляры_книги",
                column: "FKячейки");

            migrationBuilder.CreateIndex(
                name: "IX_Ячейки_FKполки",
                table: "Ячейки",
                column: "FKполки");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Авторы_книги");

            migrationBuilder.DropTable(
                name: "Жанры_книги");

            migrationBuilder.DropTable(
                name: "Издательства_книги");

            migrationBuilder.DropTable(
                name: "Популярные_книги");

            migrationBuilder.DropTable(
                name: "Сотрудники_библиотеки");

            migrationBuilder.DropTable(
                name: "Справочник_операций");

            migrationBuilder.DropTable(
                name: "Формуляры");

            migrationBuilder.DropTable(
                name: "Авторы");

            migrationBuilder.DropTable(
                name: "Жанры");

            migrationBuilder.DropTable(
                name: "Издательства");

            migrationBuilder.DropTable(
                name: "Читатели");

            migrationBuilder.DropTable(
                name: "Экземпляры_книги");

            migrationBuilder.DropTable(
                name: "Книги");

            migrationBuilder.DropTable(
                name: "Ячейки");

            migrationBuilder.DropTable(
                name: "Полки");

            migrationBuilder.DropTable(
                name: "Ряды");

            migrationBuilder.DropTable(
                name: "Секции");

            migrationBuilder.DropTable(
                name: "Комнаты");
        }
    }
}
