using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace YoungEnterprise_API.Models
{
    public partial class DB_YoungEnterpriseContext : DbContext
    {
        public virtual DbSet<TblEvent> TblEvent { get; set; }
        public virtual DbSet<TblJudge> TblJudge { get; set; }
        public virtual DbSet<TblJudgePair> TblJudgePair { get; set; }
        public virtual DbSet<TblQuestion> TblQuestion { get; set; }
        public virtual DbSet<TblSchool> TblSchool { get; set; }
        public virtual DbSet<TblTeam> TblTeam { get; set; }
        public virtual DbSet<TblVote> TblVote { get; set; }
        public virtual DbSet<TblVoteAnswer> TblVoteAnswer { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DB_YoungEnterprise;Trusted_Connection=True;");
            }
        }*/

        // Replaced OnConfiguring as stated by the tutorial.
        public DB_YoungEnterpriseContext (DbContextOptions<DB_YoungEnterpriseContext> options) : base(options) { }

        public DB_YoungEnterpriseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEvent>(entity =>
            {
                entity.HasKey(e => e.FldEventId);

                entity.ToTable("tbl_Event");

                entity.Property(e => e.FldEventId).HasColumnName("fld_EventID");

                entity.Property(e => e.FldEventDate)
                    .HasColumnName("fld_EventDate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<TblJudge>(entity =>
            {
                entity.HasKey(e => e.FldJudgeId);

                entity.ToTable("tbl_Judge");

                entity.Property(e => e.FldJudgeId).HasColumnName("fld_JudgeID");

                entity.Property(e => e.FldEventId).HasColumnName("fld_EventID");

                entity.Property(e => e.FldJudgeName)
                    .IsRequired()
                    .HasColumnName("fld_JudgeName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FldJudgePassword)
                    .IsRequired()
                    .HasColumnName("fld_JudgePassword")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FldJudgeUsername)
                    .IsRequired()
                    .HasColumnName("fld_JudgeUsername")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.FldEvent)
                    .WithMany(p => p.TblJudge)
                    .HasForeignKey(d => d.FldEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Judge__fld_E__2B3F6F97");
            });

            modelBuilder.Entity<TblJudgePair>(entity =>
            {
                entity.HasKey(e => e.FldJudgePairId);

                entity.ToTable("tbl_JudgePair");

                entity.Property(e => e.FldJudgePairId).HasColumnName("fld_JudgePairID");

                entity.Property(e => e.FldJudgeIda).HasColumnName("fld_JudgeIDA");

                entity.Property(e => e.FldJudgeIdb).HasColumnName("fld_JudgeIDB");

                entity.HasOne(d => d.FldJudgeIdaNavigation)
                    .WithMany(p => p.TblJudgePairFldJudgeIdaNavigation)
                    .HasForeignKey(d => d.FldJudgeIda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Judge__fld_J__2E1BDC42");

                entity.HasOne(d => d.FldJudgeIdbNavigation)
                    .WithMany(p => p.TblJudgePairFldJudgeIdbNavigation)
                    .HasForeignKey(d => d.FldJudgeIdb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Judge__fld_J__2F10007B");
            });

            modelBuilder.Entity<TblQuestion>(entity =>
            {
                entity.HasKey(e => e.FldQuestionId);

                entity.ToTable("tbl_Question");

                entity.Property(e => e.FldQuestionId).HasColumnName("fld_QuestionID");

                entity.Property(e => e.FldQuestionCategori)
                    .IsRequired()
                    .HasColumnName("fld_QuestionCategori")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FldQuestionModifier).HasColumnName("fld_QuestionModifier");

                entity.Property(e => e.FldQuestionText)
                    .IsRequired()
                    .HasColumnName("fld_QuestionText")
                    .HasMaxLength(260)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSchool>(entity =>
            {
                entity.HasKey(e => e.FldSchoolId);

                entity.ToTable("tbl_School");

                entity.Property(e => e.FldSchoolId).HasColumnName("fld_SchoolID");

                entity.Property(e => e.FldSchoolName)
                    .IsRequired()
                    .HasColumnName("fld_SchoolName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FldSchoolPassword)
                    .IsRequired()
                    .HasColumnName("fld_SchoolPassword")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FldSchoolUsername)
                    .IsRequired()
                    .HasColumnName("fld_SchoolUsername")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTeam>(entity =>
            {
                entity.HasKey(e => e.FldTeamName);

                entity.ToTable("tbl_Team");

                entity.Property(e => e.FldTeamName)
                    .HasColumnName("fld_TeamName")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FldEventId).HasColumnName("fld_EventID");

                entity.Property(e => e.FldReport)
                    .IsRequired()
                    .HasColumnName("fld_Report");

                entity.Property(e => e.FldSchoolId).HasColumnName("fld_SchoolID");

                entity.Property(e => e.FldSubjectCategory)
                    .IsRequired()
                    .HasColumnName("fld_SubjectCategory")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.FldEvent)
                    .WithMany(p => p.TblTeam)
                    .HasForeignKey(d => d.FldEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Team__fld_Ev__276EDEB3");

                entity.HasOne(d => d.FldSchool)
                    .WithMany(p => p.TblTeam)
                    .HasForeignKey(d => d.FldSchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Team__fld_Sc__286302EC");
            });

            modelBuilder.Entity<TblVote>(entity =>
            {
                entity.HasKey(e => e.FldVoteId);

                entity.ToTable("tbl_Vote");

                entity.Property(e => e.FldVoteId).HasColumnName("fld_VoteID");

                entity.Property(e => e.FldJudgePairId).HasColumnName("fld_JudgePairID");

                entity.Property(e => e.FldTeamName)
                    .IsRequired()
                    .HasColumnName("fld_TeamName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.FldJudgePair)
                    .WithMany(p => p.TblVote)
                    .HasForeignKey(d => d.FldJudgePairId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Vote__fld_Ju__33D4B598");

                entity.HasOne(d => d.FldTeamNameNavigation)
                    .WithMany(p => p.TblVote)
                    .HasForeignKey(d => d.FldTeamName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Vote__fld_Te__34C8D9D1");
            });

            modelBuilder.Entity<TblVoteAnswer>(entity =>
            {
                entity.HasKey(e => e.FldVoteAnswerId);

                entity.ToTable("tbl_VoteAnswer");

                entity.Property(e => e.FldVoteAnswerId).HasColumnName("fld_VoteAnswerID");

                entity.Property(e => e.FldQuestionId).HasColumnName("fld_QuestionID");

                entity.Property(e => e.FldVoteId).HasColumnName("fld_VoteID");

                entity.HasOne(d => d.FldQuestion)
                    .WithMany(p => p.TblVoteAnswer)
                    .HasForeignKey(d => d.FldQuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_VoteA__fld_Q__37A5467C");

                entity.HasOne(d => d.FldVote)
                    .WithMany(p => p.TblVoteAnswer)
                    .HasForeignKey(d => d.FldVoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_VoteA__fld_V__38996AB5");
            });
        }
    }
}
