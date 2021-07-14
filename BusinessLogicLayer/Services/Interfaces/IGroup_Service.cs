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
        Task<Generic_ResultSet<Group_ResultSet>> GetGroupNameByGroupId(int group_id);
        Task<Generic_ResultSet<List<Group_ResultSet>>> GetAllGroups();

        Task<Generic_ResultSet<Group_ResultSet>> GetTopByGpaInGroup(int group_id);

    }
}
