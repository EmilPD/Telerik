using ProjectManager.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Models
{
    public class User : IUser
    {
        private string userName;
        private string email;

        public User(string username, string email)
        {
            this.UserName = username;
            this.Email = email;
        }

        [Required(ErrorMessage = "User Username is required!")]
        public string UserName
        {
            get
            {
                return this.userName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("UserName cannot be null!");
                }

                this.userName = value;
            }
        }

        [Required(ErrorMessage = "User Email is required!")]
        [EmailAddress(ErrorMessage = "User Email is not valid!")]
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Email cannot be null!");
                }

                this.email = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("    Username: " + this.UserName);
            builder.AppendLine("    Email: " + this.Email);
            return builder.ToString();
        }
    }
}