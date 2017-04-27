using LionJobs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LionJobs.ViewModels
{
    public class CreateAJobViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title is too short.")]
        [MaxLength(30, ErrorMessage = "Title is too long.")]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [MinLength(10, ErrorMessage = "Description is too short")]
        [MaxLength(100, ErrorMessage = "Description is too long")]
        public string Description { get; set; }

        [Required]
        public TagType Tag1 { get; set; }

        [Required]
        public TagType Tag2 { get; set; }

        [Required]
        public TagType Tag3 { get; set; }

        public ICollection<Tag> GetTags()
        {
            return new List<Tag>
            {
                new Tag { TagText=Tag1},
                new Tag { TagText=Tag2},
                new Tag { TagText=Tag3}
            };
        }
    }
}