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
// Azure emulator.
using HousingConditionPhoneApp.ServiceReference1;
// Required to bring ServiceContract and OperationContract into scope.
using System.ServiceModel;
// Required to bring StreamReader into scope.
using System.IO;


namespace HousingConditionPhoneApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void getTotalCostsSOAP_Click(object sender, RoutedEventArgs e)
        {
            // Couldn't use using block???
            HouseConditionServiceClient c = new HouseConditionServiceClient();
            c.GetTotalCostsAsync();
            c.GetTotalCostsCompleted += new EventHandler<ServiceReference1.GetTotalCostsCompletedEventArgs>(c_getTotalCostsCompleted);
        }

        private void c_getTotalCostsCompleted(object sender, ServiceReference1.GetTotalCostsCompletedEventArgs e)
        {
            textBlock1.Text = e.Result.ToString();
        }

        private void getTotalCostsREST_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebClient wc = new WebClient();
                Uri uri = new Uri("http://127.0.0.1:81/houseconditionservice.svc/pox");
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