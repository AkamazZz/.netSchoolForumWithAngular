using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Functions.Interfaces
{
    public interface ISpecialitySpecific
    {

        public Task<Dictionary<int, int>> GetTopFromSpeciliaty(int speciliaty_id);

    }
}
