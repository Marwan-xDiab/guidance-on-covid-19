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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data.Sql;
namespace COVID_19
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string conictionstring = "";
        public MainWindow()
        {
            InitializeComponent();
            conictionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        }


        public string GetCOVID_19_Test(bool q1, bool q2, bool q3)
        {
            String Gool = "";
            if (q1 == true)
            {
                Gool = "Report international travel tocovid19travel@health.gatech.eduAND\n self-monitor andquarantine for 14 days";
                return Gool;

            }

            if (q1 == false && q2 == true)
            {
                Gool = "1.Stay at home.\n2. Separate yourself from others.\n3. Contact your doctor via phone";
                return Gool;

            }

            if (q1 == false && q2 == false && q3 == true)
            {
                Gool = "Watch for symptomsAND quarantine\n for14 days AND notifyStamps Health Services";
                return Gool;

            }

            if (q1 == false && q2 == false && q3 == false)
            {
                Gool = "Continue working, and continue using\n CDC best practices for prevention of illness";
                return Gool;

            }
            return " ";
        }

        public int GetCOVID_19_SuppTest(bool q1, bool q2, bool q3, bool q4, bool q5)
        {
            int gread = 0;

            if (q1 == true && q2 == true && q3 == true)
            {
                gread = 6;
                return gread;
            }

            if (q1 == false && q2 == false && q3 == false)
            {
                gread = 0;
                return gread;
            }

            if (q1 == true && q2 == true && q3 == false && q4 == true && q5 == true)
            {
                gread = 6;
                return gread;
            }

            if (q1 == true && q2 == true && q3 == false && q4 == true && q5 == false)
            {
                gread = 5;
                return gread;
            }
            if (q1 == true && q2 == true && q3 == false && q4 == false && q5 == false)
            {
                gread = 4;
                return gread;
            }
            if (q1 == true && q2 == false && q3 == true && q4 == true && q5 == true)
            {
                gread = 6;
                return gread;
            }
            if (q1 == true && q2 == false && q3 == true && q4 == false)
            {
                gread = 4;
                return gread;
            }
            if (q1 == true && q2 == false && q3 == false && q4 == true && q5 == true)
            {
                gread = 4;
                return gread;
            }
            if (q1 == true && q2 == false && q3 == false && q4 == true && q5 == true)
            {
                gread = 4;
                return gread;
            }
            if (q1 == true && q2 == false && q3 == false && q4 == false)
            {
                gread = 2;
                return gread;
            }
            if (q1 == false && q2 == true && q3 == true && q4 == true && q5 == true)
            {
                gread = 6;
                return gread;
            }
            if (q1 == false && q2 == true && q3 == true && q4 == true && q5 == false)
            {
                gread = 5;
                return gread;
            }
            if (q1 == false && q2 == true && q3 == true && q4 == false)
            {
                gread = 4;
                return gread;
            }
            if (q1 == false && q2 == true && q3 == false && q4 == true && q5 == true)
            {
                gread = 4;
                return gread;
            }
            if (q1 == false && q2 == true && q3 == false && q4 == false)
            {
                gread = 2;
                return gread;
            }
            if (q1 == false && q2 == false && q3 == true)
            {
                gread = 2;
                return gread;
            }
            return gread;
        }

        private void getruselt_Click(object sender, RoutedEventArgs e)
        {
            save.IsEnabled = true;
            int x = GetCOVID_19_SuppTest(Q3.IsChecked.Value, Q4.IsChecked.Value, Q5.IsChecked.Value, Q6.IsChecked.Value, Q7.IsChecked.Value);
            string test = "";
             bool z=  false;
           
            if (x == 6)
            {
                test = "Doubtful by : 90% : 100%";
                z = true;
            }
            else if (x == 5)
            {
                test = "Doubtful by : 70% : 80%";
                z = true;

            }
            else if (x == 4)
            {
                test = "Doubtful by : 40% : 50%";
                z = false;


            }
            else if (x == 3)
            {
                test = "Doubtful by : 30% : 40%";
                z = false;

            }
            else if (x == 2)
            {
                test = "Doubtful by : 10% : 20%";
                z = false;

            }
            else if (x < 2)
            {
                test = "Doubtful by : 0%";
                z = false;

            }
            Resualt.Text = GetCOVID_19_Test(Q1.IsChecked.Value,z, Q8.IsChecked.Value) + " \n " + test.ToString();

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            string istravel = "";
            if (Q1.IsChecked.Value == true)
            { istravel = "True"; }
            else { istravel = "False"; }
            AddItem("insert into Users VALUES (N'" + Name.Text + "',N'" + ID.Text + "',N'" + Phone.Text + "',N'" + Addres.Text + "',N'" + istravel + "',N'" + Resualt.Text + "');");
        }

        public void AddItem(string qury)
        {
           
            try
            {
                using (SqlConnection con = new SqlConnection(conictionstring))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(qury, con))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Succseful Added");
                        this.Close();
                    }
                    con.Close();
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }

        }

   
    }

}
