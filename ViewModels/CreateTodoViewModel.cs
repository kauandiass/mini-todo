using System.Diagnostics.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.VisualBasic;

namespace MiniTodo.ViewModels
{
    public class CreateTodoViewModel : Notifiable<Notification>
    {
        public string Title { get; set; } = string.Empty;

        public Todo MapTo()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNull(Title, "Informe o título")
                .IsGreaterThan(Title, 5, "O título deve conter mais de 5 caracteres");

            AddNotifications(contract);

            return new Todo(Guid.NewGuid(), Title, false);
        }
    }

    
}