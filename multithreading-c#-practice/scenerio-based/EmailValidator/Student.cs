using System.ComponentModel.DataAnnotations;

public class Student
    {
        private string email;

        [EmailValidation]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Student(string email)
        {
            Email = email;
        }
    }