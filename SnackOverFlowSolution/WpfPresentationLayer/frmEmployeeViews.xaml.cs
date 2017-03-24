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
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class frmEmployeeViews : Window
    {
        bool inAddMode;
        private IEmployeeManager _employeeManager;
        private Employee _employee;
        private List<User> _userList;


        public frmEmployeeViews()
        {
            InitializeComponent();
        }

        public frmEmployeeViews(LogicLayer.IEmployeeManager employeeManager)
        {
            InitializeComponent();
            this._employeeManager = employeeManager;
            inAddMode = true;
        }

        public frmEmployeeViews(IEmployeeManager employeeManager, Employee employee)
        {
            InitializeComponent();
            this._employeeManager = employeeManager;
            this._employee = employee;
        }

        internal void SetEditable()
        {
            lblActiveVal.Visibility = Visibility.Collapsed;
            lblDateOfBirthVal.Visibility = Visibility.Collapsed;
            lblSalaryVal.Visibility = Visibility.Collapsed;
            lblUserIdVal.Visibility = Visibility.Collapsed;

            chkActive.Visibility = Visibility.Visible;
            dpBirthDatePicker.Visibility = Visibility.Visible;
            txtSalary.Visibility = Visibility.Visible;
            cboUserID.Visibility = Visibility.Visible;
            try
            {
                _userList = (new UserManager()).RetrieveFullUserList();
                cboUserID.ItemsSource = _userList;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                ErrorAlert.ShowDatabaseError();
            }
            btnPost.Visibility = Visibility.Visible;
        }

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            decimal parsedSalary;
            bool shouldPost=true;
            if (!Decimal.TryParse(txtSalary.Text, out parsedSalary))
            {
                shouldPost = false;
                MessageBox.Show("Salary needs a decimal");
            }
            if(null==dpBirthDatePicker.SelectedDate)
            {
                shouldPost = false;
            }
            if (shouldPost)
            {
                if (inAddMode)
                {
                    try
                    {
                        _employeeManager.CreateEmployee(new Employee()
                        {
                            Active = (bool)chkActive.IsChecked,
                            DateOfBirth = (DateTime)dpBirthDatePicker.SelectedDate,
                            Salary = parsedSalary,
                            UserId = _userList[cboUserID.SelectedIndex].UserId
                        });
                        MessageBox.Show("Employee Added");
                        this.Close();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        if (2627 == ex.Number)
                        {
                            MessageBox.Show("Unique key constraint violated");
                        }
                        else
                        {
                            ErrorAlert.ShowDatabaseError();
                        }
                    }

                }
            }
            this.Close();
        }
    }
}