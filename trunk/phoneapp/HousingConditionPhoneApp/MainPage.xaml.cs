using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
// Web Service.
using HousingConditionPhoneApp.HouseCondition;
// Required to bring ServiceContract and OperationContract into scope.
using System.ServiceModel;
// Required to bring StreamReader into scope.
using System.IO;


namespace HousingConditionPhoneApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void getTotalCostsSOAP_Click(object sender, RoutedEventArgs e)
        {
            HouseConditionClient c = new HouseConditionClient();
            c.GetTotalCostsAsync();
            c.GetTotalCostsCompleted += new EventHandler<HouseCondition.GetTotalCostsCompletedEventArgs>(c_getTotalCostsCompleted);
        }

        private void c_getTotalCostsCompleted(object sender, HouseCondition.GetTotalCostsCompletedEventArgs e)
        {
            textBlock1.Text = e.Result.ToString();
        }

        private void getTotalCostsREST_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebClient wc = new WebClient();
                Uri uri = new Uri("http://housingcondition.cloudapp.net/housecondition/pox");
                wc.OpenReadCompleted += new OpenReadCompletedEventHandler(wc_OpenReadCompleted);
                wc.OpenReadAsync(uri);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(e.Result);
                MessageBox.Show(reader.ReadToEnd().ToString());
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}