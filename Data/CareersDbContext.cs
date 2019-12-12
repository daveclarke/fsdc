using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using System.Reflection;
using System;
using System.Globalization;

namespace Data
{
    public class CareersDbContext: DbContext
    {
        public CareersDbContext(DbContextOptions<CareersDbContext> options) : base(options) {}
        public CareersDbContext() {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=careers.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var now = DateTime.UtcNow;
            var culture = new CultureInfo("en-NZ");
            modelBuilder.Entity<Vacancy>().HasData(
                new Vacancy
                {
                    Id = Guid.NewGuid(),
                    Title = "Alliances Operations Coordinator",
                    Description = @"Holystone sutler line boatswain gangplank lad gibbet. Pink lanyard main sheet Plate Fleet rutters barque holystone. Case shot long clothes yard lugsail galleon dead men tell no tales to go on account. Keelhaul yo-ho-ho loot nipper list American Main fluke.
Pillage furl blow the man down pinnace chase guns fire in the hole hulk. Cog spike cutlass Jack Tar aye mizzenmast handsomely. Gun Gold Road walk the plank boom draft hang the jib tender. Boatswain bilge gally brigantine tack yardarm chandler.",
                    LocationId = 3,
                    PostedDate = DateTime.Parse("26/01/2019", culture),
                    ModifiedDate = now,
                },
                new Vacancy
                {
                    Id = Guid.NewGuid(),
                    Title = "Customer Service Manager",
                    Description = @"Provost topsail crimp square-rigged boatswain red ensign Chain Shot. Run a shot across the bow brig Plate Fleet lass marooned prow gunwalls. Jack Ketch long clothes lee dance the hempen jig rutters squiffy warp. Gun Spanish Main gangplank doubloon poop deck hogshead broadside.

Haul wind lee Shiver me timbers strike colors handsomely Nelsons folly rigging. Plate Fleet Barbary Coast hail-shot cable quarterdeck list Pieces of Eight. Bowsprit aye pinnace cog Letter of Marque galleon lad. Shiver me timbers code of conduct bilge water yo-ho-ho loaded to the gunwalls driver skysail.",
                    LocationId = 2,
                    PostedDate = DateTime.Parse("01/02/2019", culture),
                    ModifiedDate = now,
                },
                new Vacancy
                {
                    Id = Guid.NewGuid(),
                    Title = "Team Leader - Customer Care",
                    Description = @"Provost Jack Tar Davy Jones' Locker snow topgallant lugsail mizzenmast. Maroon belay Sail ho grapple salmagundi rutters run a shot across the bow. Hulk clap of thunder line heave to Corsair pirate Jack Ketch. Cat o'nine tails no prey, no pay marooned carouser salmagundi squiffy Corsair.

Avast weigh anchor lugger execution dock mutiny run a shot across the bow chase guns. Deadlights coffer case shot stern gangway quarter interloper. Red ensign fluke gaff bucko skysail handsomely hempen halter. Topgallant starboard skysail hang the jib tender yawl coffer.",
                    LocationId = 2,
                    PostedDate = DateTime.Parse("07/02/2019", culture),
                    ModifiedDate = now,
                },
                new Vacancy
                {
                    Id = Guid.NewGuid(),
                    Title = "Retail Centre Consultant",
                    Description = @"Hands tack nipperkin fire ship man-of-war bilge water clap of thunder. Jib gangway jury mast parrel bowsprit Cat o'nine tails red ensign. Main sheet poop deck black jack rope's end pressgang Pieces of Eight lass. Black jack sloop chantey yard Sink me matey sheet.

American Main hands doubloon black spot knave broadside lanyard. Skysail gangplank black spot lookout pink clap of thunder yardarm. Sloop sheet careen trysail scuppers bucko black jack. Maroon ho pillage hearties jib overhaul doubloon.",
                    LocationId = 1,
                    PostedDate = DateTime.Parse("14/02/2019", culture),
                    ModifiedDate = now,
                }
            );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Vacancy> Vacancies { get; set; }
    }
}