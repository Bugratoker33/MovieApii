﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviAppi.Application.Features.CQRSDesingPatern.Results.MovieResult
{
    public class GetMovieQueryResult
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime ReleasDate { get; set; }
        public string CreatedYear { get; set; }
        public bool Status { get; set; }
    }
}
