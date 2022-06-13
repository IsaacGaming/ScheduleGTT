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

                ScheduleLessons scheduleLessons = new ScheduleLessons
                {
                    DateLesson = (DateTime)Date.SelectedDate,
                    Discipline = disciplines.Id,
                    Teacher = teachers.Id,
                    LessonType = lessonTypes.Id,
                    GroupId = groups.Id,
                    ScheduleBell = scheduleBell.Id,
                    Room = rooms.Id
                };

                Context.ScheduleLessons.Add(scheduleLessons);
                Context.SaveChanges();
                dgScheduleLessons.ItemsSource = GetScheduleLessons;

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

                if (scheduleLessons != null)
                {
                    scheduleLessons.DateLesson = (DateTime)Date.SelectedDate;
                    scheduleLessons.Discipline = disciplines.Id;
                    scheduleLessons.Teacher = teachers.Id;
                    scheduleLessons.LessonType = lessonTypes.Id;
                    scheduleLessons.GroupId = groups.Id;
                    scheduleLessons.ScheduleBell = scheduleBell.Id;
                    scheduleLessons.Room = rooms.Id;

                    Context.SaveChanges();
                    dgScheduleLessons.ItemsSource = GetScheduleLessons;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FilterScheduleLessons_Click(object sender, RoutedEventArgs e)
        {
            if (Date.SelectedDate != null && MultiDate.SelectedDate != null)
            {
                Groups groups = GroupsCB.SelectedItem as Groups;
                DateTime begin = (DateTime)Date.SelectedDate;
                DateTime end = (DateTime)MultiDate.SelectedDate;

                dgScheduleLessons.ItemsSource = GetFilteredScheduleLessons(begin, end, groups.Name);
            }
            else
            {
                MessageBox.Show("Необходимо указать начальный и конечный день");
            }
        }

        private void CancelFilterScheduleLessons_Click(object sender, RoutedEventArgs e)
        {
            dgScheduleLessons.ItemsSource = GetScheduleLessons;
        }

        private void ImportScheduleLessons_Click(object sender, RoutedEventArgs e)
        {
            dgScheduleLessons.ExportToExcel();
        }

    }
}
