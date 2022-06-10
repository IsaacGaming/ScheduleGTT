﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ScheduleGTT.DataBase;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Data.Entity;
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
                    dgGroupType.ItemsSource = GetGroupTypes;
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
                    dgGroupType.ItemsSource = GetGroupTypes;
                }
                else
                {
                    MessageBox.Show("Нужно выбрать строку");
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
                dgGroupType.ItemsSource = GetGroupTypes;
            }
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
                    dgLessonsType.ItemsSource = GetLessonTypes;
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
                    dgLessonsType.ItemsSource = GetLessonTypes;
                }
                else
                {
                    MessageBox.Show("Нужно выбрать строку");
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
                    dgLessonsType.ItemsSource = GetLessonTypes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                    dgSpecialities.ItemsSource = GetSpecialities;
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
                    dgSpecialities.ItemsSource = GetSpecialities;
                }
                else
                {
                    MessageBox.Show("Нужно выбрать строку");
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
                    dgSpecialities.ItemsSource = GetSpecialities;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {               
                Specialities speciality = SpecialityCB.SelectedItem as Specialities;
                GroupTypes groupTypes = GroupTypeCB.SelectedItem as GroupTypes;
                bool groupNoEmpty = !string.IsNullOrEmpty(GroupNameTB.Text);

                if (speciality != null && groupTypes != null && groupNoEmpty)
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
                    dgGroups.ItemsSource = GetGroups;
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
                    dgGroups.ItemsSource = GetGroups;
                }
                else
                {
                    MessageBox.Show("Нужно выбрать строку");
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
                bool noNull = speciality != null && groupTypes != null && groupNoEmpty && groupsTable != null;

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
                    dgGroups.ItemsSource = GetGroups;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                    dgRooms.ItemsSource = GetRooms;
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
                    dgRooms.ItemsSource = GetRooms;
                }
                else
                {
                    MessageBox.Show("Нужно выбрать строку");
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
                    dgRooms.ItemsSource = GetRooms;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                    dgDisciplines.ItemsSource = GetDisciplines;
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
                }
                else
                {
                    MessageBox.Show("Нужно выбрать строку");
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
                    dgDisciplines.ItemsSource = GetDisciplines;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                    dgScheduleBells.ItemsSource = GetScheduleBells;
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
                    dgScheduleBells.ItemsSource = GetScheduleBells;
                }
                else
                {
                    MessageBox.Show("Нужно выбрать строку");
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
                    dgScheduleBells.ItemsSource = GetScheduleBells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                int selectedRowCount = dgScheduleLessons.Items.Count;

                if (scheduleLessons != null && selectedRowCount == 1)
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
                int selectedRowCount = dgScheduleLessons.Items.Count;

                DateTime dateLesson = Convert.ToDateTime(DateTB.Text);
                bool dateNoEmpty = string.IsNullOrEmpty(dateLesson.ToString());

                if (scheduleLessons != null && selectedRowCount == 1 && dateNoEmpty)
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
            try
            {
                //инициализация приложения Excel
                Excel.Application excel = new Excel.Application
                {
                    Visible = true
                };
                //создает книгу
                Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                //создает лист               
                Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

                //создание заголовков таблицы
                for (int j = 0; j < dgScheduleLessons.Columns.Count; j++)
                {
                    Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                    sheet1.Cells[1, j + 1].Font.Bold = true;
                    sheet1.Columns[j + 1].ColumnWidth = 50;
                    myRange.Value2 = dgScheduleLessons.Columns[j].Header;
                }

                //заполнение данных в таблицу
                for (int i = 0; i < dgScheduleLessons.Columns.Count; i++)
                {
                    for (int j = 0; j < dgScheduleLessons.Items.Count; j++)
                    {
                        TextBlock b = dgScheduleLessons.Columns[i].GetCellContent(dgScheduleLessons.Items[j]) as TextBlock;
                        Excel.Range myRange = (Excel.Range)sheet1.Cells[j + 2, i + 1];
                        myRange.Value2 = b.Text;
                    }
                }
                //автоподбор размера столбцов
                sheet1.Columns.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
