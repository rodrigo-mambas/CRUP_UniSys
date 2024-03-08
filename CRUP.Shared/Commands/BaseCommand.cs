using Flunt.Notifications;
using CRUP.Shared.Commands.Interfaces;

namespace CRUP.Shared.Commands
{
    public abstract class BaseCommand : Notifiable<Notification>, ICommand
    {
        public abstract void Validate();
    }
}
