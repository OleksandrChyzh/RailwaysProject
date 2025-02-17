using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities;

public partial class RailwayContext : DbContext
{
    public RailwayContext()
    {
    }

    public RailwayContext(DbContextOptions<RailwayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<StationsTrain> StationsTrains { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Train> Trains { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:5432;Database=Railway;Username=postgres;Password=1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Stations_pkey1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.City).HasMaxLength(50);
        });

        modelBuilder.Entity<StationsTrain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Stations_pkey");

            entity.ToTable("Stations-Trains");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Stations_Id_seq\"'::regclass)");

            entity.HasOne(d => d.Station).WithMany(p => p.StationsTrains)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("StationFK");

            entity.HasOne(d => d.TrainNumberNavigation).WithMany(p => p.StationsTrains)
                .HasForeignKey(d => d.TrainNumber)
                .HasConstraintName("TrainFK");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Tickets_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.UserEmail).HasMaxLength(50);

            entity.HasOne(d => d.StationTrainId2Navigation).WithMany(p => p.TicketSationTrainId2Navigations)
                .HasForeignKey(d => d.StationTrainId2)
                .HasConstraintName("StationTrainFK2");

            entity.HasOne(d => d.StationTrainId1Navigation).WithMany(p => p.TicketStationTrainId1Navigations)
                .HasForeignKey(d => d.StationTrainId1)
                .HasConstraintName("StationTrainFK1");

            entity.HasOne(d => d.UserEmailNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserEmail)
                .HasConstraintName("UserFK");
        });

        modelBuilder.Entity<Train>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Trains_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TrainName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("Users_pkey");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
