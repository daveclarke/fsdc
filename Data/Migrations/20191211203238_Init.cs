using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    PostedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Id", "Description", "LocationId", "ModifiedDate", "PostedDate", "Title" },
                values: new object[] { new Guid("654a47b1-02f1-4382-9dda-6a14f436e9a4"), @"Holystone sutler line boatswain gangplank lad gibbet. Pink lanyard main sheet Plate Fleet rutters barque holystone. Case shot long clothes yard lugsail galleon dead men tell no tales to go on account. Keelhaul yo-ho-ho loot nipper list American Main fluke.
Pillage furl blow the man down pinnace chase guns fire in the hole hulk. Cog spike cutlass Jack Tar aye mizzenmast handsomely. Gun Gold Road walk the plank boom draft hang the jib tender. Boatswain bilge gally brigantine tack yardarm chandler.", 3, new DateTime(2019, 12, 11, 20, 32, 37, 906, DateTimeKind.Utc).AddTicks(1940), new DateTime(2019, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alliances Operations Coordinator" });

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Id", "Description", "LocationId", "ModifiedDate", "PostedDate", "Title" },
                values: new object[] { new Guid("6de51672-fa28-4e51-aaee-637ec1fffc8d"), @"Provost topsail crimp square-rigged boatswain red ensign Chain Shot. Run a shot across the bow brig Plate Fleet lass marooned prow gunwalls. Jack Ketch long clothes lee dance the hempen jig rutters squiffy warp. Gun Spanish Main gangplank doubloon poop deck hogshead broadside.

Haul wind lee Shiver me timbers strike colors handsomely Nelsons folly rigging. Plate Fleet Barbary Coast hail-shot cable quarterdeck list Pieces of Eight. Bowsprit aye pinnace cog Letter of Marque galleon lad. Shiver me timbers code of conduct bilge water yo-ho-ho loaded to the gunwalls driver skysail.", 2, new DateTime(2019, 12, 11, 20, 32, 37, 906, DateTimeKind.Utc).AddTicks(1940), new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer Service Manager" });

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Id", "Description", "LocationId", "ModifiedDate", "PostedDate", "Title" },
                values: new object[] { new Guid("b37743cd-4f07-475d-a4dc-a4ce7e6de1c1"), @"Provost Jack Tar Davy Jones' Locker snow topgallant lugsail mizzenmast. Maroon belay Sail ho grapple salmagundi rutters run a shot across the bow. Hulk clap of thunder line heave to Corsair pirate Jack Ketch. Cat o'nine tails no prey, no pay marooned carouser salmagundi squiffy Corsair.

Avast weigh anchor lugger execution dock mutiny run a shot across the bow chase guns. Deadlights coffer case shot stern gangway quarter interloper. Red ensign fluke gaff bucko skysail handsomely hempen halter. Topgallant starboard skysail hang the jib tender yawl coffer.", 2, new DateTime(2019, 12, 11, 20, 32, 37, 906, DateTimeKind.Utc).AddTicks(1940), new DateTime(2019, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Team Leader - Customer Care" });

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Id", "Description", "LocationId", "ModifiedDate", "PostedDate", "Title" },
                values: new object[] { new Guid("c7737c42-ef28-40c8-8bd1-7e2459ba959c"), @"Hands tack nipperkin fire ship man-of-war bilge water clap of thunder. Jib gangway jury mast parrel bowsprit Cat o'nine tails red ensign. Main sheet poop deck black jack rope's end pressgang Pieces of Eight lass. Black jack sloop chantey yard Sink me matey sheet.

American Main hands doubloon black spot knave broadside lanyard. Skysail gangplank black spot lookout pink clap of thunder yardarm. Sloop sheet careen trysail scuppers bucko black jack. Maroon ho pillage hearties jib overhaul doubloon.", 1, new DateTime(2019, 12, 11, 20, 32, 37, 906, DateTimeKind.Utc).AddTicks(1940), new DateTime(2019, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Retail Centre Consultant" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacancies");
        }
    }
}
