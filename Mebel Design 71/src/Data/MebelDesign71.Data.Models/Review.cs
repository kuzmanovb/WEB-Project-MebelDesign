﻿namespace MebelDesign71.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MebelDesign71.Data.Common.Models;

    public class Review : BaseDeletableModel<string>
    {
        public Review()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int ImageId { get; set; }

        public ImageToReview Image { get; set; }
    }
}
