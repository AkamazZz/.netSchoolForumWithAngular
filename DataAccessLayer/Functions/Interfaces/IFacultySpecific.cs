﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DataAccessLayer.Functions.Interfaces
{
    public interface IFacultySpecific
    {

        public Task<Dictionary<int, int>> GetTopFromFaculty(int faculty_id);

    }
}