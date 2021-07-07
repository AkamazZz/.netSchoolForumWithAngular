using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Functions.Interfaces
{
    public interface IStudentSpecific
    {

        public Task<Dictionary<int, int>> GetTop();

    }
}
