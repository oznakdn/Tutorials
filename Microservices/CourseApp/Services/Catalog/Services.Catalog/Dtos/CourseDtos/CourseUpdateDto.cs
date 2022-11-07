using Services.Catalog.Dtos.FeatureDtos;

namespace Services.Catalog.Dtos.CourseDtos
{
    public class CourseUpdateDto
    {
        public string CourseId { get; set; }

        public string CourseName { get; set; }

        public decimal CoursePrice { get; set; }

        public string CoursePicture { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public string CategoryId { get; set; }

        public FeatureDto Feature { get; set; }

    }
}
