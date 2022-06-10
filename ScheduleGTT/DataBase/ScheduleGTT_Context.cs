using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ScheduleGTT.DataBase
{
    public partial class ScheduleGTT_Context : DbContext
    {
        public ScheduleGTT_Context()
            : base("name=ScheduleGTT_Context_College")
        {
        }

        private static ScheduleGTT_Context context;

        public static ScheduleGTT_Context Context
        {
            get
            {
                if (context == null)
                    return context = new ScheduleGTT_Context();
                else
                    return context;
            }
        }

        #region Lists
        public static List<GroupTypes> GetGroupTypes => Context.GroupTypes.ToList();

        public static List<LessonTypes> GetLessonTypes => Context.LessonTypes.ToList();

        public static List<Specialities> GetSpecialities => Context.Specialities.ToList();

        public static List<Groups> GetGroups => Context.Groups.Include(s => s.Specialities).Include(g => g.GroupTypes).ToList();

        public static List<Rooms> GetRooms => Context.Rooms.ToList();

        public static List<Disciplines> GetDisciplines => Context.Disciplines.ToList();

        public static List<Teachers> GetTeachers => Context.Teachers.ToList();

        public static List<ScheduleLessons> GetScheduleLessons
        {
            get
            {
                return Context.ScheduleLessons
                    .Include(t => t.Teachers)
                    .Include(g => g.Groups)
                    .Include(les => les.LessonTypes)
                    .Include(r => r.Rooms)
                    .Include(d => d.Disciplines)
                    .Include(sb => sb.ScheduleBell1)
                    .ToList();
            }
        }

        public static List<ScheduleBell> GetScheduleBells => Context.ScheduleBell.ToList();
        #endregion

        #region DbSets
        public virtual DbSet<Disciplines> Disciplines { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<GroupTypes> GroupTypes { get; set; }
        public virtual DbSet<LessonTypes> LessonTypes { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<ScheduleBell> ScheduleBell { get; set; }
        public virtual DbSet<ScheduleLessons> ScheduleLessons { get; set; }
        public virtual DbSet<Specialities> Specialities { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disciplines>()
                .HasMany(e => e.ScheduleLessons)
                .WithOptional(e => e.Disciplines)
                .HasForeignKey(e => e.Discipline);

            modelBuilder.Entity<Disciplines>()
                .HasMany(e => e.Teachers)
                .WithMany(e => e.Disciplines)
                .Map(m => m.ToTable("TeacherDisciplines")
                        .MapLeftKey("DisciplineId")
                        .MapRightKey("TeacherId"));

            modelBuilder.Entity<Groups>()
                .HasMany(e => e.ScheduleLessons)
                .WithOptional(e => e.Groups)
                .HasForeignKey(e => e.GroupId);

            modelBuilder.Entity<GroupTypes>()
                .HasMany(e => e.Groups)
                .WithOptional(e => e.GroupTypes)
                .HasForeignKey(e => e.GroupType);

            modelBuilder.Entity<LessonTypes>()
                .HasMany(e => e.ScheduleLessons)
                .WithOptional(e => e.LessonTypes)
                .HasForeignKey(e => e.LessonType);

            modelBuilder.Entity<Rooms>()
                .Property(e => e.NumberRoom)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Rooms>()
                .HasMany(e => e.ScheduleLessons)
                .WithOptional(e => e.Rooms)
                .HasForeignKey(e => e.Room);

            modelBuilder.Entity<ScheduleBell>()
                .HasMany(e => e.ScheduleLessons)
                .WithOptional(e => e.ScheduleBell1)
                .HasForeignKey(e => e.ScheduleBell);

            modelBuilder.Entity<Specialities>()
                .HasMany(e => e.Groups)
                .WithOptional(e => e.Specialities)
                .HasForeignKey(e => e.Speciality);

            modelBuilder.Entity<Teachers>()
                .HasMany(e => e.ScheduleLessons)
                .WithOptional(e => e.Teachers)
                .HasForeignKey(e => e.Teacher);
        }
    }
}
