﻿using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfPresentationLayer
{
    /// <summary>
    /// Interaction logic for frmCreateLocationWindow.xaml
    /// </summary>
    public partial class frmCreateLocationWindow : Window
    {
        ILocationManager locationMgr;
        public frmCreateLocationWindow(ILocationManager iLocationManager)
        {
            locationMgr = iLocationManager;
            InitializeComponent();
        }

        private void btnAddLocation_Click(object sender, RoutedEventArgs e)
        {
            if (txtDescription.Text.Equals(""))
            {
                MessageBox.Show("Please enter a description!");
                return;
            }

            Location location = new Location() {
                description = txtDescription.Text,
                isActive = (bool)chkActive.IsChecked
                };
            try
            {
                if (locationMgr.CreateLocation(location) == 1)
                {
                    MessageBox.Show("Location successfully created.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to create location. Error Message: " + ex.Message);
            }
        }
    }
}
