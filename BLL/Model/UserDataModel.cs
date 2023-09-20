﻿using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class UserDataModel
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
