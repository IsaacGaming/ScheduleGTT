using Microsoft.Win32;
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
    }
}
