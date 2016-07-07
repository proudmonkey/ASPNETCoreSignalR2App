using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPNETCoreSignalRDemo.Models.DB
{
    public partial class ASPNETCoreDemoDBContext : DbContext
    {
        public ASPNETCoreDemoDBContext(DbContextOptions<ASPNETCoreDemoDBContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poll>(entity =>
            {
                entity.Property(e => e.PollId).HasColumnName("PollID");

                entity.Property(e => e.Question).HasMaxLength(300);
            });

            modelBuilder.Entity<PollOption>(entity =>
            {
                entity.Property(e => e.PollOptionId).HasColumnName("PollOptionID");

                entity.Property(e => e.Answers)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PollId).HasColumnName("PollID");

                entity.HasOne(d => d.Poll)
                    .WithMany(p => p.PollOption)
                    .HasForeignKey(d => d.PollId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PollOption_PollOption");
            });
        }
        public virtual DbSet<Poll> Poll { get; set; }
        public virtual DbSet<PollOption> PollOption { get; set; }
    }
}