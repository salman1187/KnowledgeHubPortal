using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KnowledgeHubPortal.WebApplication.Models.Domain
{
    public interface INotificationMedium
    {
        void Send(string to, string subject,string message);
    }
}
