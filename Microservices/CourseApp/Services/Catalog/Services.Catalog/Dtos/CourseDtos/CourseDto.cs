using Services.Catalog.Dtos.FeatureDtos;
using Services.Catalog.Dtos.CategoryDtos;

namespace Services.Catalog.Dtos.CourseDtos
{
    public class CourseDto
    {
       
        public string CourseId { get; set; }

        public string CourseName { get; set; }
       
        public decimal CoursePrice { get; set; }

        public string Description { get; set; }

        public string CoursePicture { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; }

        public string CategoryId { get; set; }


        public CategoryDto Category { get; set; }

        public FeatureDto Feature { get; set; }
    }
}
