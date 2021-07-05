using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Functions.Interfaces
{
    public interface IAssessmentSpecific
    {
        public Task<int> GPA(int student_id);
    }
}
