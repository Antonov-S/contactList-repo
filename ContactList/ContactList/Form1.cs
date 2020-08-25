using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactList
{
    public partial class Form1 : Form
    {

        private Contact[] phonebook = new Contact[1];

        public Form1()
        {
            InitializeComponent();
        }

        private void Write(Contact obj)
        {
            StreamWriter sw = new StreamWriter("Contacts.txt");
            sw.WriteLine(phonebook.Length + 1);
            sw.WriteLine(obj.FirstName);
            sw.WriteLine(obj.LastName);
            sw.WriteLine(obj.Phone);

            for (int x = 0; x < phonebook.Length; x++)
            {
                sw.WriteLine(phonebook[x].FirstName);
                sw.WriteLine(phonebook[x].LastName);
                sw.WriteLine(phonebook[x].Phone);
            }

            sw.Close();
        }

        private void Read()
        {
            StreamReader sr = new StreamReader("Contacts.txt");
            phonebook = new Contact[Convert.ToInt32(sr.ReadLine())];

            for (int x = 0; x < phonebook.Length; x++)
            {
                phonebook[x] = new Contact();
                phonebook[x].FirstName = sr.ReadLine();
                phonebook[x].LastName = sr.ReadLine();
                phonebook[x].Phone = sr.ReadLine();
            }

            sr.Close();
        }

        private void Display()
        {
            lstContacts.Items.Clear();

            for (int x = 0; x < phonebook.Length; x++)
            {
                lstContacts.Items.Add(phonebook[x].ToString());
            }
        }

        private void ClearForm()
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtPhone.Text = String.Empty;
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            Contact obj = new Contact();
            obj.FirstName = txtFirstName.Text;
            obj.LastName = txtLastName.Text;
            obj.Phone = txtPhone.Text;

            Write(obj);
            BubbleSort();
            Read();
            Display();
            ClearForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Read();
            Display();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            BubbleSort();
            Display();
        }

        private void BubbleSort()
        {
            Contact temp;
            bool swap;

            do
            {
                swap = false;

                for (int x = 0; x < (phonebook.Length - 1); x++)
                {
                    if (phonebook[x].LastName.CompareTo(phonebook[x + 1].LastName) > 0 )
                    {
                        temp = phonebook[x];
                        phonebook[x] = phonebook[x + 1];
                        phonebook[x + 1] = temp;
                        swap = true;
                    }
                }

            } while (swap == true);
        }
    }
}
