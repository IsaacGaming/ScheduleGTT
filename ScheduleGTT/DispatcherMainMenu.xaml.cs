using ScheduleGTT.DataBase;
using System;
using System.ComponentModel;
using System.Windows;
using static ScheduleGTT.DataBase.ScheduleGTT_Context;

namespace ScheduleGTT
{
    public partial class DispatcherMainMenu : Window
    {
        public DispatcherMainMenu()
        {
            InitializeComponent();
        }

        private void DispatcherMainMenuWnd_Closing(object sender, CancelEventArgs e) 
            => WndManager.WarningOnClose(sender, e);

        private void AddScheduleLesson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Disciplines disciplines = DisciplinesCB.SelectedItem as Disciplines;
                Teachers teachers = TeachersCB.SelectedItem as Teachers;
                Groups groups = GroupsCB.SelectedItem as Groups;
                ScheduleBell scheduleBell = NameBellCB.SelectedItem as ScheduleBell;
                Rooms rooms = RoomsCB.SelectedItem as Rooms;
                LessonTypes lessonTypes = TypeLessonsCB.SelectedItem as LessonTypes;

                DateTime dateLesson = Convert.ToDateTime(DateTB.Text);

                if (string.IsNullOrEmpty(dateLesson.ToString()))
                {
                    ScheduleLessons scheduleLessons = new ScheduleLessons
                    {
                        DateLesson = dateLesson,
                        Discipline = disciplines.Id,
                        Teacher = teachers.Id,
                        LessonType = lessonTypes.Id,
                        GroupId = groups.Id,
                        ScheduleBell = scheduleBell.Id,
                        Room = rooms.Id
                    };

                    Context.ScheduleLessons.Add(scheduleLessons);
                    Context.SaveChanges();
                    DateTB.ClearTB();
                    dgScheduleLessons.ItemsSource = GetScheduleLessons;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DeleteScheduleLesson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ScheduleLessons scheduleLessons = dgScheduleLessons.SelectedItem as ScheduleLessons;

                if (scheduleLessons != null)
                {
                    Context.ScheduleLessons.Remove(scheduleLessons);
                    Context.SaveChanges();
                    dgScheduleLessons.ItemsSource = GetScheduleLessons;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EditScheduleLesson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Disciplines disciplines = DisciplinesCB.SelectedItem as Disciplines;
                Teachers teachers = TeachersCB.SelectedItem as Teachers;
                Groups groups = GroupsCB.SelectedItem as Groups;
                ScheduleBell scheduleBell = NameBellCB.SelectedItem as ScheduleBell;
                Rooms rooms = RoomsCB.SelectedItem as Rooms;
                LessonTypes lessonTypes = TypeLessonsCB.SelectedItem as LessonTypes;

                ScheduleLessons scheduleLessons = dgScheduleLessons.SelectedItem as ScheduleLessons;

                DateTime dateLesson = Convert.ToDateTime(DateTB.Text);
                bool dateNoEmpty = string.IsNullOrEmpty(dateLesson.ToString());

                if (scheduleLessons != null && dateNoEmpty)
                {
                    scheduleLessons.DateLesson = dateLesson;
                    scheduleLessons.Discipline = disciplines.Id;
                    scheduleLessons.Teacher = teachers.Id;
                    scheduleLessons.LessonType = lessonTypes.Id;
                    scheduleLessons.GroupId = groups.Id;
                    scheduleLessons.ScheduleBell = scheduleBell.Id;
                    scheduleLessons.Room = rooms.Id;

                    Context.SaveChanges();
                    DateTB.ClearTB();
                    dgScheduleLessons.ItemsSource = GetScheduleLessons;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ImportScheduleLessons_Click(object sender, RoutedEventArgs e)
        {
            dgScheduleLessons.ExportToExcel();
        }
    }
}
