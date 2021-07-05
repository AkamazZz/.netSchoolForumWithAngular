using System;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Group;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IGroup_Service
    {
        Task<string> GetGroupNameByGroupId(int group_id);

    
    }
}
