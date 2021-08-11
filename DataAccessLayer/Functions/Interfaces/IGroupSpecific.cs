using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Functions.Interfaces
{
    public interface IGroupSpecific
    {

        public Task<Dictionary<int, double>> GetTopFromGroup(int group_id);

        public Task<List<Student>> GetAllFromGroup(int group_id);

    }
}
