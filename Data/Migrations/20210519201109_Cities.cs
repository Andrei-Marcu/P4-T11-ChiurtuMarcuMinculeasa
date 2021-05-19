using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement.Data.Migrations
{
    public partial class Cities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityID", "Name" },
                values: new object[,]
                {
                    { 1, "Adjud" },
                    { 75, "Roman" },
                    { 74, "Reșița" },
                    { 73, "Reghin" },
                    { 72, "Râmnicu Vâlcea" },
                    { 71, "Râmnicu Sărat" },
                    { 70, "Rădăuți" },
                    { 69, "Ploiești" },
                    { 68, "Pitești" },
                    { 67, "Piatra Neamț" },
                    { 66, "Petroșani" },
                    { 76, "Roșiorii de Vede" },
                    { 65, "Pașcani" },
                    { 63, "Orăștie" },
                    { 62, "Oradea" },
                    { 61, "Onești" },
                    { 60, "Oltenița" },
                    { 59, "Odorheiu Secuiesc" },
                    { 58, "Motru" },
                    { 57, "Moreni" },
                    { 56, "Moinești" },
                    { 55, "Miercurea Ciuc" },
                    { 54, "Mediaș" },
                    { 64, "Orșova" },
                    { 53, "Medgidia" },
                    { 77, "Săcele" },
                    { 79, "Satu Mare" },
                    { 101, "Vatra Dornei" },
                    { 100, "Vaslui" },
                    { 99, "Urziceni" },
                    { 98, "Turnu Măgurele" },
                    { 97, "Turda" },
                    { 96, "Tulcea" },
                    { 95, "Toplița" },
                    { 94, "Timișoara" },
                    { 93, "Tecuci" },
                    { 92, "Târnăveni" },
                    { 78, "Salonta" },
                    { 91, "Târgu Secuiesc" },
                    { 89, "Târgu Jiu" },
                    { 88, "Târgoviște" },
                    { 87, "Suceava" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityID", "Name" },
                values: new object[,]
                {
                    { 86, "Slobozia" },
                    { 85, "Slatina" },
                    { 84, "Sighișoara" },
                    { 83, "Sighetu Marmației" },
                    { 82, "Sibiu" },
                    { 81, "Sfântu Gheorghe" },
                    { 80, "Sebeș" },
                    { 90, "Târgu Mureș" },
                    { 102, "Vulcan" },
                    { 52, "Marghita" },
                    { 50, "Lupeni" },
                    { 23, "Câmpulung" },
                    { 22, "Câmpina" },
                    { 21, "Câmpia Turzii" },
                    { 20, "Călărași" },
                    { 19, "Calafat" },
                    { 18, "Buzău" },
                    { 17, "București" },
                    { 16, "Brașov" },
                    { 15, "Brăila" },
                    { 14, "Brad" },
                    { 24, "Câmpulung Moldovenesc" },
                    { 13, "Botoșani" },
                    { 11, "Bistrița" },
                    { 10, "Beiuș" },
                    { 9, "Bârlad" },
                    { 8, "Băilești" },
                    { 7, "Baia Mare" },
                    { 6, "Bacău" },
                    { 5, "Arad" },
                    { 4, "Alexandria" },
                    { 3, "Alba Iulia" },
                    { 2, "Aiud" },
                    { 12, "Blaj" },
                    { 51, "Mangalia" },
                    { 25, "Caracal" },
                    { 27, "Carei" },
                    { 49, "Lugoj" },
                    { 48, "Iași" },
                    { 47, "Huși" },
                    { 46, "Hunedoara" },
                    { 45, "Giurgiu" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityID", "Name" },
                values: new object[,]
                {
                    { 44, "Gherla" },
                    { 43, "Gheorgheni" },
                    { 42, "Galați" },
                    { 41, "Focșani" },
                    { 40, "Fetești" },
                    { 26, "Caransebeș" },
                    { 39, "Fălticeni" },
                    { 37, "Drobeta-Turnu Severin" },
                    { 36, "Drăgășani" },
                    { 35, "Dorohoi" },
                    { 34, "Deva" },
                    { 33, "Dej" },
                    { 32, "Curtea de Argeș" },
                    { 31, "Craiova" },
                    { 30, "Constanța" },
                    { 29, "Codlea" },
                    { 28, "Cluj Napoca" },
                    { 38, "Făgăraș" },
                    { 103, "Zalău" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 103);
        }
    }
}
