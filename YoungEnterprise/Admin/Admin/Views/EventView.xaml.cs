﻿using Admin.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Admin.Views
{
    /// <summary>
    /// Interaction logic for EventView.xaml
    /// </summary>
    public partial class EventView : UserControl
    {
        private EventViewModel model = new EventViewModel();

        public EventView()
        {
            InitializeComponent();

            ShiftDatagrid(judgePairsDataGrid);

            DataContext = model;
        }

        private void ShiftDatagrid (DataGrid dataGrid)
        {
            viewGrid.Children.Clear();
            viewGrid.Children.Add(dataGrid);
        }

        private void createJudgePairsButton_Click(object sender, RoutedEventArgs e)
        {
            ShiftDatagrid(judgePairsDataGrid);
            model.CreateJudgePairs();
            model.RefreshCollections();
        }

        private void createSchedule_Click(object sender, RoutedEventArgs e)
        {
            ShiftDatagrid(scheduleDataGrid);
            
            // Make the schedule dynamically here!

            model.RefreshCollections();
        }

        private void createEventButton_Click(object sender, RoutedEventArgs e)
        {
            if (eventDate.SelectedDate != null)
            {
                model.NewEvent((DateTime)eventDate.SelectedDate);
            } else
            {
                MessageBox.Show("Indtast en gyldig dato!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
