using System;


namespace ContactList
{
    class Contact
    {
        private string firstName;
        private string lastName;
        private string phone;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                if (value.Length == 10)
                {
                    phone = value;
                }
                else
                {
                    phone = "0000000000";
                }
            }
        }

        public Contact()
        {
            FirstName = "Jhon";
            LastName = "Doe";
            Phone = "0000000000";
        }

        public Contact(string firstName, string lastName, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }

        public override string ToString()
        {
            string output = String.Empty;

            output += String.Format("{0}, {1} ", LastName, FirstName);
            output += String.Format("{0} {1}-{2}", Phone.Substring(0, 3), Phone.Substring(3, 3), Phone.Substring(6, 4));

            return output;
        }
    }
}
