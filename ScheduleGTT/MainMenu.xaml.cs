using ScheduleGTT.DataBase;
using System;
using System.ComponentModel;
using System.Windows;
using static ScheduleGTT.DataBase.ScheduleGTT_Context;

namespace ScheduleGTT
{
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e) 
            => Application.Current.Shutdown();

        private void MainMenuWnd_Closing(object sender, CancelEventArgs e) 
            => WndManager.WarningOnClose(sender, e);

        private void TypeGroupRefresh()
        {
            dgGroupType.ItemsSource = GetGroupTypes;
            GroupTypeCB.ItemsSource = GetGroupTypes;
            dgGroups.ItemsSource = GetGroups;
        }

        private void AddTypeGroupButton_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (!string.IsNullOrEmpty(GroupTypeNameTB.Text))
                {
                    GroupTypes groupTypes = new GroupTypes
                    {
                        Name = GroupTypeNameTB.Text
                    };

                    Context.GroupTypes.Add(groupTypes);
                    Context.SaveChanges();
                    GroupTypeNameTB.ClearTB();
                    TypeGroupRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DeleteTypeGroupButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GroupTypes groupTypes = dgGroupType.SelectedItem as GroupTypes;
                if (groupTypes != null)
                {
                    Context.GroupTypes.Remove(groupTypes);
                    Context.SaveChanges();
                    TypeGroupRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EditTypeGroupButton_Click(object sender, RoutedEventArgs e)
        {
            GroupTypes groupTypes = dgGroupType.SelectedItem as GroupTypes;
            if (groupTypes != null && !string.IsNullOrEmpty(GroupTypeNameTB.Text))
            {
                groupTypes.Name = LessonTypeNameTB.Text;
                GroupTypeNameTB.ClearTB();
                Context.SaveChanges();
                TypeGroupRefresh();
            }
        }

        private void LessonTypeRefresh()
        {
            dgLessonsType.ItemsSource = GetLessonTypes;
            TypeLessonsCB.ItemsSource = GetLessonTypes;
            dgScheduleLessons.ItemsSource = GetScheduleLessons;
        }

        private void AddTypeLesson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(LessonTypeNameTB.Text))
                {
                    LessonTypes lessonTypes = new LessonTypes
                    {
                        Name = LessonTypeNameTB.Text
                    };

                    Context.LessonTypes.Add(lessonTypes);
                    Context.SaveChanges();
                    LessonTypeNameTB.ClearTB();
                    LessonTypeRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DeleteTypeLesson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LessonTypes lessonTypes = dgLessonsType.SelectedItem as LessonTypes;
                if (lessonTypes != null)
                {
                    Context.LessonTypes.Remove(lessonTypes);
                    Context.SaveChanges();
                    LessonTypeRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EditTypeLesson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LessonTypes lessonTypes = dgLessonsType.SelectedItem as LessonTypes;
                if (lessonTypes != null && !string.IsNullOrEmpty(LessonTypeNameTB.Text))
                {
                    lessonTypes.Name = LessonTypeNameTB.Text;
                    LessonTypeNameTB.ClearTB();
                    Context.SaveChanges();
                    LessonTypeRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SpecialitiesRefresh()
        {
            dgSpecialities.ItemsSource = GetSpecialities;
            SpecialityCB.ItemsSource = GetSpecialities;
        }

        private void AddSpecialities_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(SpecialityNameTB.Text))
                {
                    Specialities specialities = new Specialities
                    {
                        Name = SpecialityNameTB.Text
                    };

                    Context.Specialities.Add(specialities);
                    Context.SaveChanges();
                    SpecialityNameTB.ClearTB();
                    SpecialitiesRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DeleteSpecialities_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Specialities specialities = dgSpecialities.SelectedItem as Specialities;
                if (specialities != null)
                {
                    Context.Specialities.Remove(specialities);
                    Context.SaveChanges();
                    SpecialitiesRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EditSpecialities_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Specialities specialities = dgSpecialities.SelectedItem as Specialities;
                if (specialities != null && !string.IsNullOrEmpty(SpecialityNameTB.Text))
                {
                    specialities.Name = SpecialityNameTB.Text;
                    SpecialityNameTB.ClearTB();
                    Context.SaveChanges();
                    SpecialitiesRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GroupRefresh()
        {
            dgGroups.ItemsSource = GetGroups;
            GroupsCB.ItemsSource = GetGroups;
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {               
                Specialities speciality = SpecialityCB.SelectedItem as Specialities;
                GroupTypes groupTypes = GroupTypeCB.SelectedItem as GroupTypes;
                bool groupNoEmpty = !string.IsNullOrEmpty(GroupNameTB.Text);

                if (groupTypes != null && groupNoEmpty)
                {
                    Groups groups = new Groups
                    {
                        Name = GroupNameTB.Text,
                        Speciality = speciality.Id,
                        GroupType = groupTypes.Id
                    };

                    Context.Groups.Add(groups);
                    Context.SaveChanges();
                    GroupNameTB.ClearTB();
                    GroupRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Groups group = dgGroups.SelectedItem as Groups;
                
                if (group != null)
                {
                    Context.Groups.Remove(group);
                    Context.SaveChanges();
                    GroupRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EditGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Specialities speciality = SpecialityCB.SelectedItem as Specialities;
                GroupTypes groupTypes = GroupTypeCB.SelectedItem as GroupTypes;
                Groups groupsTable = dgGroups.SelectedItem as Groups;
                bool groupNoEmpty = !string.IsNullOrEmpty(GroupNameTB.Text);
                bool noNull = groupNoEmpty && groupsTable != null;

                if (noNull)
                {
                    groupsTable = new Groups
                    {
                        Name = GroupNameTB.Text,
                        Speciality = speciality.Id,
                        GroupType = groupTypes.Id
                    };

                    Context.SaveChanges();
                    GroupNameTB.ClearTB();
                    GroupRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RoomsRefresh()
        {
            dgRooms.ItemsSource = GetRooms;
            RoomsCB.ItemsSource = GetRooms;
            dgScheduleLessons.ItemsSource = GetScheduleLessons;
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool numberRoomNoNull = !string.IsNullOrEmpty(NumberRoomTB.Text);
                bool nameNoNull = !string.IsNullOrEmpty(RoomNameTB.Text);

                if (numberRoomNoNull && nameNoNull)
                {
                    Rooms room = new Rooms
                    {
                        Name = RoomNameTB.Text,
                        NumberRoom = NumberRoomTB.Text
                    };

                    Context.Rooms.Add(room);
                    Context.SaveChanges();
                    NumberRoomTB.ClearTB();
                    RoomNameTB.ClearTB();
                    RoomsRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Rooms room = dgRooms.SelectedItem as Rooms;

                if (room != null)
                {
                    Context.Rooms.Remove(room);
                    Context.SaveChanges();
                    RoomsRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EditRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool numberAuditoryNoNull = !string.IsNullOrEmpty(NumberRoomTB.Text);
                bool nameNoNull = !string.IsNullOrEmpty(RoomNameTB.Text);

                Rooms room = dgRooms.SelectedItem as Rooms;
                if (numberAuditoryNoNull && nameNoNull && room != null)
                {
                    room.Name = RoomNameTB.Text;
                    room.NumberRoom = NumberRoomTB.Text;
                    
                    Context.SaveChanges();
                    NumberRoomTB.ClearTB();
                    RoomNameTB.ClearTB();
                    RoomsRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DisciplineRefresh()
        {
            dgDisciplines.ItemsSource = GetDisciplines;
            dgScheduleLessons.ItemsSource = GetScheduleLessons;
            DisciplinesCB.ItemsSource = GetDisciplines;
            dgTeacherOnSL.ItemsSource = GetTeacherDisciplines;
        }

        private void AddDiscipline_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool nameNoNull = !string.IsNullOrEmpty(DisciplineNameTB.Text);
                bool shortNameNoNull = !string.IsNullOrEmpty(DisciplineShortNameTB.Text);

                if (shortNameNoNull && nameNoNull)
                {
                    Disciplines disciplines = new Disciplines
                    {
                        Name = DisciplineNameTB.Text,
                        ShortName = DisciplineShortNameTB.Text
                    };

                    Context.Disciplines.Add(disciplines);
                    Context.SaveChanges();
                    DisciplineNameTB.ClearTB();
                    DisciplineShortNameTB.ClearTB();
                    DisciplineRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DeleteDiscipline_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Disciplines disciplines = dgDisciplines.SelectedItem as Disciplines;

                if (disciplines != null)
                {
                    Context.Disciplines.Remove(disciplines);
                    Context.SaveChanges();
                    dgDisciplines.ItemsSource = GetDisciplines;

                    DisciplineRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EditDiscipline_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Disciplines disciplines = dgDisciplines.SelectedItem as Disciplines;
                bool nameNoNull = !string.IsNullOrEmpty(DisciplineNameTB.Text);
                bool shortNameNoNull = !string.IsNullOrEmpty(DisciplineShortNameTB.Text);

                if (shortNameNoNull && nameNoNull && disciplines != null)
                {
                    disciplines.Name = RoomNameTB.Text;
                    disciplines.ShortName = NumberRoomTB.Text;

                    Context.SaveChanges();
                    DisciplineNameTB.ClearTB();
                    DisciplineShortNameTB.ClearTB();
                    DisciplineRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BellsRefresh()
        {
            dgScheduleBells.ItemsSource = GetScheduleBells;
            dgScheduleLessons.ItemsSource = GetScheduleLessons;
        }

        private void AddBell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool nameNoNull = !string.IsNullOrEmpty(BellNameTB.Text);
                bool beginBellNoNull = !string.IsNullOrEmpty(BeginLessonTB.Text);
                bool endBellNoNull = !string.IsNullOrEmpty(EndLessonTB.Text);

                if (nameNoNull && beginBellNoNull && endBellNoNull)
                {
                    ScheduleBell scheduleBell = new ScheduleBell
                    {
                        Name = BellNameTB.Text,
                        BeginBell = Convert.ToDateTime(BeginLessonTB.Text),
                        EndBell = Convert.ToDateTime(EndLessonTB.Text)
                    };

                    Context.ScheduleBell.Add(scheduleBell);
                    Context.SaveChanges();
                    BellNameTB.ClearTB();
                    BeginLessonTB.ClearTB();
                    EndLessonTB.ClearTB();
                    BellsRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DeleteBell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ScheduleBell scheduleBell = dgScheduleBells.SelectedItem as ScheduleBell;

                if (scheduleBell != null)
                {
                    Context.ScheduleBell.Remove(scheduleBell);
                    Context.SaveChanges();
                    BellsRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EditBell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool nameNoNull = !string.IsNullOrEmpty(BellNameTB.Text);
                bool beginBellNoNull = !string.IsNullOrEmpty(BeginLessonTB.Text);
                bool endBellNoNull = !string.IsNullOrEmpty(EndLessonTB.Text);
                ScheduleBell scheduleBell = dgScheduleBells.SelectedItem as ScheduleBell;

                if (nameNoNull && beginBellNoNull && endBellNoNull && scheduleBell != null)
                {
                    scheduleBell.Name = BellNameTB.Text;
                    scheduleBell.BeginBell = Convert.ToDateTime(BeginLessonTB.Text);
                    scheduleBell.EndBell = Convert.ToDateTime(EndLessonTB.Text);
                    
                    Context.SaveChanges();
                    BellNameTB.ClearTB();
                    BeginLessonTB.ClearTB();
                    EndLessonTB.ClearTB();
                    BellsRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PrintScheduleBell_Click(object sender, RoutedEventArgs e)
        {
            dgScheduleBells.ExportToExcel();
        }

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

        private void RefreshDataTeacher()
        {
            dgTeachers.ItemsSource = GetTeachers;
            TeacherWithDisciplineCB.ItemsSource = GetTeachers;
            TeachersCB.ItemsSource = GetTeachers;
            dgScheduleLessons.ItemsSource = GetScheduleLessons;
            dgTeacherOnSL.ItemsSource = GetTeacherDisciplines;
        }

        private void AddTeacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstName = FirstNameTeacherTB.Text;
                string middleName = MiddleNameTeacherTB.Text;
                string lastName = LastNameTeacherTB.Text;

                bool fnNoEmpty = string.IsNullOrEmpty(firstName);
                bool mnNoEmpty = string.IsNullOrEmpty(middleName);
                bool lnNoEmpty = string.IsNullOrEmpty(lastName);

                if (fnNoEmpty && mnNoEmpty && lnNoEmpty)
                {
                    Teachers teachers = new Teachers
                    {
                        FirstName = firstName,
                        MiddleName = middleName,
                        LastName = lastName
                    };

                    FirstNameTeacherTB.ClearTB();
                    MiddleNameTeacherTB.ClearTB();
                    LastNameTeacherTB.ClearTB();

                    Context.Teachers.Add(teachers);
                    Context.SaveChanges();
                    RefreshDataTeacher();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteTeacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Teachers teachers = dgTeachers.SelectedItem as Teachers;

                if (teachers != null)
                {
                    Context.Teachers.Remove(teachers);
                    Context.SaveChanges();

                    RefreshDataTeacher();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditTeacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstName = FirstNameTeacherTB.Text;
                string middleName = MiddleNameTeacherTB.Text;
                string lastName = LastNameTeacherTB.Text;

                bool fnNoEmpty = string.IsNullOrEmpty(firstName);
                bool mnNoEmpty = string.IsNullOrEmpty(middleName);
                bool lnNoEmpty = string.IsNullOrEmpty(lastName);

                Teachers teachers = dgTeachers.ItemsSource as Teachers;

                if (fnNoEmpty && mnNoEmpty && lnNoEmpty && teachers != null)
                {
                    teachers.FirstName = firstName;
                    teachers.MiddleName = middleName;
                    teachers.LastName = lastName;

                    FirstNameTeacherTB.ClearTB();
                    MiddleNameTeacherTB.ClearTB();
                    LastNameTeacherTB.ClearTB();

                    Context.SaveChanges();
                    RefreshDataTeacher();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshDataTeacherDisciplines()
        {
            dgTeacherLessons.ItemsSource = GetTeacherDisciplines;
            dgTeacherOnSL.ItemsSource = GetTeacherDisciplines;
        }

        private void AddTeacherDisciplines_Click(object sender, RoutedEventArgs e)
        {
            Teachers teachers = TeacherWithDisciplineCB.SelectedItem as Teachers;
            Disciplines disciplines = DisciplinesCB.SelectedItem as Disciplines;

            TeacherDisciplines teacherDisciplines = new TeacherDisciplines()
            {
                TeacherId = teachers.Id,
                DisciplineId = disciplines.Id
            };

            Context.TeacherDisciplines.Add(teacherDisciplines);
            Context.SaveChanges();

            RefreshDataTeacherDisciplines();
        }

        private void DeleteTeacherDisciplines_Click(object sender, RoutedEventArgs e)
        {
            TeacherDisciplines teacherDisciplines = dgTeacherLessons.SelectedItems as TeacherDisciplines;

            if (teacherDisciplines != null)
            {
                Context.TeacherDisciplines.Remove(teacherDisciplines);
                Context.SaveChanges();

                RefreshDataTeacherDisciplines();
            }
        }
    }
}
