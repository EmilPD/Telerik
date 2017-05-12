using Bytes2you.Validation;
using ProjectManager.Models.Contracts;
using ProjectManager.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Models
{
    public class Task
    {
        private readonly IUser owner;
        private string name;

        public Task(string name, IUser owner, string state)
        {
            this.name = name;
            this.owner = owner;
            this.State = state;
        }

        public string State { get; set; }

        [Required(ErrorMessage = "Task Name is required!")]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be null!");
                }

                this.name = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("    Name: " + this.name);
            builder.AppendLine("    Owner: " + this.owner);
            builder.Append("    State: " + this.State);

            return builder.ToString();
        }
    }
}