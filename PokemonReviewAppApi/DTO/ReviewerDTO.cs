﻿using PokemonReviewAppApi.Models;

namespace PokemonReviewAppApi.DTO
{
    public class ReviewerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public ICollection<Review> Reviews { get; set; }

    }
}
