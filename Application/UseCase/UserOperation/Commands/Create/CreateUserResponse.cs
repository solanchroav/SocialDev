﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.UserOperation.Commands.Create
{
    public class CreateUserResponse
    {
        public int Id { get; set; }
        public string? Message { get; set; }
    }
}
