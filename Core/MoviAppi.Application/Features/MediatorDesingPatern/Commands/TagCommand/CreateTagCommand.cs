﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.MediatorDesingPatern.Commands.TagCommand
{

    public class CreateTagCommand:IRequest
    {
        
        public string Title { get; set; }
    }
}
