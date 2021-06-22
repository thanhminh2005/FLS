using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.SemesterRegister.Requests
{
    public class SemesterRegisterRequest
    {
        public int SemesterId { get; set; }
        public int LecturerId { get; set; }
    }
}
