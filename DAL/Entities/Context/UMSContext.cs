using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Entities.Context
{
    public class UMSContext : DbContext
    {
        public UMSContext(DbContextOptions<UMSContext> options)
            : base(options) { }

       
        //AUTH & AUTHORIZATION - Zobaer
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationUser> OrganizationUsers { get; set; }

        //GAME & SCORING
        public DbSet<Game> Games { get; set; }
        public DbSet<ScoringRule> ScoringRules { get; set; }

        //TOURNAMENT CORE - Zobaer
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentStage> TournamentStages { get; set; }
        public DbSet<StageGroup> StageGroups { get; set; }
        public DbSet<StageGroupTeam> StageGroupTeams { get; set; }

        //TEAM & PLAYER
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        //MATCH & POINT SYSTEM 
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchTeamResult> MatchTeamResults { get; set; }
        public DbSet<MatchPlayerStat> MatchPlayerStats { get; set; }

        //QUALIFICATION / BRACKET - Zobaer
        public DbSet<QualificationMap> QualificationMaps { get; set; }

        //MODEL CONFIGURATION
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* =========================
               USER ↔ ROLE (M:N)
               ========================= */
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            /* =========================
               ORGANIZATION ↔ USER
               ========================= */
            modelBuilder.Entity<OrganizationUser>()
                .HasIndex(ou => new { ou.OrganizationId, ou.UserId })
                .IsUnique();

            /* =========================
               GAME RULE CONSTRAINTS
               ========================= */
            modelBuilder.Entity<Game>()
                .HasIndex(g => g.GameCode)
                .IsUnique();

            modelBuilder.Entity<ScoringRule>()
                .HasIndex(sr => new { sr.GameId, sr.Placement })
                .IsUnique();

            /* =========================
               TOURNAMENT FLOW
               ========================= */
            modelBuilder.Entity<TournamentStage>()
                .HasIndex(ts => new { ts.TournamentId, ts.StageOrder })
                .IsUnique();

            modelBuilder.Entity<StageGroup>()
                .HasIndex(g => new { g.StageId, g.GroupName })
                .IsUnique();

            modelBuilder.Entity<StageGroupTeam>()
                .HasIndex(sgt => new { sgt.StageGroupId, sgt.TeamId })
                .IsUnique();

            /* =========================
               MATCH CONSTRAINTS
               ========================= */
            modelBuilder.Entity<Match>()
                .HasIndex(m => new { m.StageGroupId, m.MatchNumber })
                .IsUnique();

            modelBuilder.Entity<MatchTeamResult>()
                .HasIndex(mtr => new { mtr.MatchId, mtr.TeamId })
                .IsUnique();

            modelBuilder.Entity<MatchPlayerStat>()
                .HasIndex(mps => new { mps.MatchTeamResultId, mps.PlayerId })
                .IsUnique();

            /* =========================
               QUALIFICATION MAP
               ========================= */
            modelBuilder.Entity<QualificationMap>()
                .HasIndex(q => new { q.FromStageGroupId, q.TeamId })
                .IsUnique();
        }
    }

}
