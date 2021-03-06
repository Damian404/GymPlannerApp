﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GymPlanner
{
    public sealed partial class PlanExercises : Page
    {
        string randomMuscle1 = "";
        string randomMuscle2 = "";

        int rowSelected = 0;

        string[,] exerciseDetails = new string[43, 5];

        public PlanExercises()
        {
            this.InitializeComponent();

            var obj = App.Current as App;

            Array.Copy(obj.GlobalExerciseArray, 0, exerciseDetails, 0, obj.GlobalExerciseArray.Length);

            rowSelected = obj.planPicked - 1;

            randomMuscle1 = obj.exercise1;
            randomMuscle2 = obj.exercise2;

            if (obj.pagePath == 3)
            {
                CreateGridRandom();
            }
            else if (obj.pagePath == 2)
            {
                CreateGridSelected();
            }
            else if (obj.pagePath == 1)
            {
                CreateGridFromSaved();
            }
        }

        private void CreateGridRandom()
        {
            Grid DynamicGrid = new Grid();
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);
            DynamicGrid.BorderThickness = new Windows.UI.Xaml.Thickness(2, 2, 2, 2);
            DynamicGrid.BorderBrush = new SolidColorBrush(Colors.Black);

            var height = new GridLength(1, GridUnitType.Star);
            var width = new GridLength(1, GridUnitType.Star);

            var width2 = new GridLength(2, GridUnitType.Star);

            int counter = 0;

            for (int i = 0; i <= 1; i++)
            {
                if (i == 0)
                {
                    DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = width
                    });
                }
                if (i == 1)
                {
                    DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = width2
                    });
                }
            }

            for (int i = 0; i <= 8; i++)
            {

                DynamicGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = height
                });

            }

            Button btn = new Button();
            btn.Name = "return";
            btn.Content = "Back";
            btn.HorizontalAlignment = HorizontalAlignment.Left;
            btn.VerticalAlignment = VerticalAlignment.Top;
            btn.Click += returnButton;

            Grid.SetColumn(btn, 0);
            Grid.SetRow(btn, 0);
            DynamicGrid.Children.Add(btn);

            for (int i = 0; i <= 42; i++)
            {
                if (randomMuscle1 == exerciseDetails[i, 0] || randomMuscle2 == exerciseDetails[i, 0])
                {
                    counter++;
                    for (int j = 0; j <= 4; j++)
                    {
                        Border myBorder1 = new Border();
                        myBorder1.BorderBrush = new SolidColorBrush(Colors.Black);
                        myBorder1.BorderThickness = new Thickness(1);

                        Image img = new Image();
                        BitmapImage tmp = new BitmapImage(new Uri(exerciseDetails[i, 2], UriKind.Absolute));
                        img.Source = tmp;
                        img.Stretch = Stretch.Fill;
                        Grid.SetRow(img, counter);
                        Grid.SetColumn(img, 0);
                        DynamicGrid.Children.Add(img);

                        TextBlock exerciseName = new TextBlock();
                        exerciseName.Text = exerciseDetails[i, 1];
                        exerciseName.FontSize = 10;
                        exerciseName.VerticalAlignment = VerticalAlignment.Top;
                        exerciseName.HorizontalAlignment = HorizontalAlignment.Center;
                        Grid.SetColumn(exerciseName, 1);
                        Grid.SetRow(exerciseName, counter);
                        DynamicGrid.Children.Add(exerciseName);

                        TextBlock details = new TextBlock();
                        details.Text = exerciseDetails[i, 3];
                        details.FontSize = 10;
                        details.VerticalAlignment = VerticalAlignment.Center;
                        Grid.SetColumn(details, 1);
                        Grid.SetRow(details, counter);
                        DynamicGrid.Children.Add(details);

                        Run run1 = new Run();
                        run1.Text = "For a link to a YouTube video click here";

                        Hyperlink hyperlink = new Hyperlink()
                        {
                            NavigateUri = new Uri(exerciseDetails[i, 4])
                        };

                        Border myBorder3 = new Border();
                        myBorder3.BorderBrush = new SolidColorBrush(Colors.Black);
                        myBorder3.BorderThickness = new Thickness(1);

                        TextBlock videoLink = new TextBlock();
                        videoLink.FontSize = 10;
                        videoLink.VerticalAlignment = VerticalAlignment.Bottom;

                        hyperlink.Inlines.Add(run1);
                        videoLink.Inlines.Add(hyperlink);

                        myBorder3.Child = videoLink;

                        Grid.SetColumn(myBorder3, 1);
                        Grid.SetRow(myBorder3, counter);
                        DynamicGrid.Children.Add(myBorder3);
                    }
                }
            }

            ExerciseLayout.Children.Add(DynamicGrid);
        }

        private void CreateGridSelected()
        {
            Grid DynamicGrid = new Grid();
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);
            DynamicGrid.BorderThickness = new Windows.UI.Xaml.Thickness(2, 2, 2, 2);
            DynamicGrid.BorderBrush = new SolidColorBrush(Colors.Black);

            var height = new GridLength(1, GridUnitType.Star);
            var width = new GridLength(1, GridUnitType.Star);

            var width2 = new GridLength(2, GridUnitType.Star);

            for (int i = 0; i <= 1; i++)
            {
                if (i == 0)
                {
                    DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = width
                    });
                }
                if (i == 1)
                {
                    DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = width2
                    });
                }
            }

            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            var obj = App.Current as App;
            string one = obj.muscleExer1;
            int counter = 1;
            int g = 0, q = 0;
            bool quit = false;

            string[] boxes = new string[6];
            boxes[0] = obj.muscleExer1;
            boxes[1] = obj.muscleExer2;
            boxes[2] = obj.muscleExer3;
            boxes[3] = obj.muscleExer4;
            boxes[4] = obj.muscleExer5;
            boxes[5] = obj.muscleExer6;

            while (quit == false)
            {
                if (localSettings.Values["someSettingInStorage" + "" + g] != null)
                {
                    g++;
                }
                else
                {
                    localSettings.Values["someSettingInStorage" + "" + g] = boxes[q].ToString();
                    q++;
                    if (q > 5)
                    {
                        g++;
                        localSettings.Values["someSettingInStorage" + "" + g] = "1".ToString();

                        quit = true;
                    }
                }
            }

            for (int i = 0; i <= 6; i++)
            {

                DynamicGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = height
                });

            }

            Button btn = new Button();
            btn.Name = "return";
            btn.Content = "Back";
            btn.HorizontalAlignment = HorizontalAlignment.Left;
            btn.VerticalAlignment = VerticalAlignment.Top;
            btn.Click += returnButton1;

            Grid.SetColumn(btn, 0);
            Grid.SetRow(btn, 0);
            DynamicGrid.Children.Add(btn);

            for (int i = 0; i <= 42; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    if (boxes[j] == exerciseDetails[i, 1])
                    {
                        Border myBorder1 = new Border();
                        myBorder1.BorderBrush = new SolidColorBrush(Colors.Black);
                        myBorder1.BorderThickness = new Thickness(1);

                        Image img = new Image();
                        BitmapImage tmp = new BitmapImage(new Uri(exerciseDetails[i, 2], UriKind.Absolute));
                        img.Source = tmp;
                        img.Stretch = Stretch.Fill;
                        Grid.SetRow(img, counter);
                        Grid.SetColumn(img, 0);
                        DynamicGrid.Children.Add(img);

                        TextBlock exerciseName = new TextBlock();
                        exerciseName.Text = exerciseDetails[i, 1];
                        exerciseName.FontSize = 10;
                        exerciseName.VerticalAlignment = VerticalAlignment.Top;
                        exerciseName.HorizontalAlignment = HorizontalAlignment.Center;
                        Grid.SetColumn(exerciseName, 1);
                        Grid.SetRow(exerciseName, counter);
                        DynamicGrid.Children.Add(exerciseName);

                        TextBlock details = new TextBlock();
                        details.Text = exerciseDetails[i, 3];
                        details.FontSize = 10;
                        details.VerticalAlignment = VerticalAlignment.Center;
                        Grid.SetColumn(details, 1);
                        Grid.SetRow(details, counter);
                        DynamicGrid.Children.Add(details);

                        Run run1 = new Run();
                        run1.Text = "For a link to a YouTube video click here";

                        Hyperlink hyperlink = new Hyperlink()
                        {
                            NavigateUri = new Uri(exerciseDetails[i, 4])
                        };

                        Border myBorder3 = new Border();
                        myBorder3.BorderBrush = new SolidColorBrush(Colors.Black);
                        myBorder3.BorderThickness = new Thickness(1);

                        TextBlock videoLink = new TextBlock();
                        videoLink.FontSize = 10;
                        videoLink.VerticalAlignment = VerticalAlignment.Bottom;

                        hyperlink.Inlines.Add(run1);
                        videoLink.Inlines.Add(hyperlink);

                        myBorder3.Child = videoLink;

                        Grid.SetColumn(myBorder3, 1);
                        Grid.SetRow(myBorder3, counter);
                        DynamicGrid.Children.Add(myBorder3);

                        counter++;
                    }
                }
            }

            ExerciseLayout.Children.Add(DynamicGrid);
        }

        private void CreateGridFromSaved()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            int counter = 0;
            int arrayPos = 0;

            Grid DynamicGrid = new Grid();
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);
            DynamicGrid.BorderThickness = new Windows.UI.Xaml.Thickness(2, 2, 2, 2);
            DynamicGrid.BorderBrush = new SolidColorBrush(Colors.Black);

            var height = new GridLength(1, GridUnitType.Star);
            var width = new GridLength(1, GridUnitType.Star);
            var width2 = new GridLength(2, GridUnitType.Star);


            for (int i = 0; i <= 1; i++)
            {
                if (i == 0)
                {
                    DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = width
                    });
                }
                if (i == 1)
                {
                    DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = width2
                    });
                }
            }

            for (int i = 0; i <= 7; i++)
            {

                DynamicGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = height
                });

            }

            Button btn = new Button();
            btn.Name = "return";
            btn.Content = "Back";
            btn.HorizontalAlignment = HorizontalAlignment.Left;
            btn.VerticalAlignment = VerticalAlignment.Top;
            btn.Click += returnButton2;

            Grid.SetColumn(btn, 0);
            Grid.SetRow(btn, 0);
            DynamicGrid.Children.Add(btn);

            counter = 0;
            string[] getPlan = new string[8];
            int j = 0;
            int rowNo = 0;
            int rowCount = 1;

            while (localSettings.Values["someSettingInStorage" + "" + counter] != null)
            {
                getPlan[arrayPos] = localSettings.Values["someSettingInStorage" + "" + counter].ToString();
                string what = getPlan[arrayPos];
                if (localSettings.Values["someSettingInStorage" + "" + counter].ToString() == "1")
                {
                    if (rowNo == rowSelected)
                    {
                        for (int i = 0; i <= 42; i++)
                        {
                            for (int k = 0; k < arrayPos; k++)
                            {
                                if (getPlan[k] == exerciseDetails[i, 1])
                                {
                                    Border myBorder1 = new Border();
                                    myBorder1.BorderBrush = new SolidColorBrush(Colors.Black);
                                    myBorder1.BorderThickness = new Thickness(1);

                                    Image img = new Image();
                                    BitmapImage tmp = new BitmapImage(new Uri(exerciseDetails[i, 2], UriKind.Absolute));
                                    img.Source = tmp;
                                    img.Stretch = Stretch.Fill;
                                    Grid.SetRow(img, rowCount);
                                    Grid.SetColumn(img, 0);
                                    DynamicGrid.Children.Add(img);

                                    TextBlock exerciseName = new TextBlock();
                                    exerciseName.Text = exerciseDetails[i, 1];
                                    exerciseName.FontSize = 10;
                                    exerciseName.VerticalAlignment = VerticalAlignment.Top;
                                    exerciseName.HorizontalAlignment = HorizontalAlignment.Center;
                                    Grid.SetColumn(exerciseName, 1);
                                    Grid.SetRow(exerciseName, rowCount);
                                    DynamicGrid.Children.Add(exerciseName);

                                    TextBlock details = new TextBlock();
                                    details.Text = exerciseDetails[i, 3];
                                    details.FontSize = 10;
                                    details.VerticalAlignment = VerticalAlignment.Center;
                                    Grid.SetColumn(details, 1);
                                    Grid.SetRow(details, rowCount);
                                    DynamicGrid.Children.Add(details);

                                    Run run1 = new Run();
                                    run1.Text = "For a link to a YouTube video click here";

                                    Hyperlink hyperlink = new Hyperlink()
                                    {
                                        NavigateUri = new Uri(exerciseDetails[i, 4])
                                    };

                                    Border myBorder3 = new Border();
                                    myBorder3.BorderBrush = new SolidColorBrush(Colors.Black);
                                    myBorder3.BorderThickness = new Thickness(1);

                                    TextBlock videoLink = new TextBlock();
                                    //videoLink.Text = exerciseDetails[i, 4];
                                    videoLink.FontSize = 10;
                                    videoLink.VerticalAlignment = VerticalAlignment.Bottom;

                                    hyperlink.Inlines.Add(run1);
                                    videoLink.Inlines.Add(hyperlink);

                                    myBorder3.Child = videoLink;

                                    Grid.SetColumn(myBorder3, 1);
                                    Grid.SetRow(myBorder3, rowCount);
                                    DynamicGrid.Children.Add(myBorder3);

                                    rowCount++;
                                }
                            }
                        }
                    }

                    getPlan = new string[8];
                    string agh = getPlan[0];
                    arrayPos = 0;
                    rowNo++;
                }
                else
                {
                    arrayPos++;
                }

                counter++;
            }

            ExerciseLayout.Children.Add(DynamicGrid);
        }

        private void returnButton(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MuscleGroups));
        }

        private void returnButton1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MuscleExercises));
        }

        private void returnButton2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SavedPlans));
        }
    }
}
