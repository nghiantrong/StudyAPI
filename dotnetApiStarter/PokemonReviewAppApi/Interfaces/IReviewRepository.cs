﻿using PokemonReviewAppApi.Models;

namespace PokemonReviewAppApi.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int id);
        ICollection<Review> GetReviewOfAPokemon(int pokeId);
        bool ReviewExists(int id);

        bool CreateReview(Review review);

        bool UpdateReview(Review review);

        bool DeleteReview(Review review);

        bool DeleteReviews(List<Review> reviews);

        bool Save();
    }
}
