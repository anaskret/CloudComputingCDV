using MobileAppsLab3.Models.Models;
using RestEase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppsLab3.Models.Interfaces
{
    public interface IPeopleClient
    {
        [Post("people")]
        Task AddPersonAsync([Body] Person person);
    }
}
