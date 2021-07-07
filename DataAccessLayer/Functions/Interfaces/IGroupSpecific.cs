using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Functions.Interfaces
{
    public interface IGroupSpecific
    {

        public Task<Dictionary<int, int>> GetTopFromGroup(int group_id);

    }
}
