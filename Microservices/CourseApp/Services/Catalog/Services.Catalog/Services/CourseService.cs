using AutoMapper;
using CourseApp.Shared.Results;
using MongoDB.Driver;
using Services.Catalog.Dtos.CourseDtos;
using Services.Catalog.Models;
using Services.Catalog.Settings;

namespace Services.Catalog.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMongoCollection<Course> courseCollection;
        private readonly IMongoCollection<Category> categoryCollection;
        private readonly IMapper mapper;

        public CourseService(IMapper mapper, IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var dataBase = client.GetDatabase(settings.DatabaseName);
            courseCollection = dataBase.GetCollection<Course>(settings.CourseCollectionName);
            categoryCollection = dataBase.GetCollection<Category>(settings.CategoryCollectionName);
            this.mapper = mapper;
        }

        public async Task<Response<List<CourseDto>>> GetAllAsync()
        {
            var courses = await courseCollection.Find(course => true).ToListAsync();


            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await categoryCollection.Find<Category>(c => c.CategoryId == course.CategoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Course>();
            }

            var courseDto = mapper.Map<List<CourseDto>>(courses);
            return Response<List<CourseDto>>.Success(courseDto, 200);
        }

        public async Task<Response<CourseDto>> GetByIdAsync(string courseId)
        {
            Course course = await courseCollection.Find<Course>(c => c.CourseId == courseId).FirstOrDefaultAsync();

            if (course is not null)
            {
                course.Category = await categoryCollection.Find<Category>(c => c.CategoryId == course.CategoryId).FirstAsync();

                //if (course.Category != null)
                //{
                //    course.Category = null;
                //}

                CourseDto courseDto = mapper.Map<CourseDto>(course);
                return Response<CourseDto>.Success(courseDto, 200);

            }
            return Response<CourseDto>.Fail("Course not found!", 404);
        }

        public async Task<Response<List<CourseDto>>> GetAllUserIdAsync(string userId)
        {
            var courses = await courseCollection.Find<Course>(c => c.UserId == userId).ToListAsync();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await categoryCollection.Find<Category>(c => c.CategoryId == course.CategoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Course>();
            }

            var courseDto = mapper.Map<List<CourseDto>>(courses);
            return Response<List<CourseDto>>.Success(courseDto, 200);

        }

        public async Task<Response<CourseDto>> CreateAsync(CourseCreateDto createDto)
        {
            Course course = mapper.Map<Course>(createDto);
            course.CreatedDate = DateTime.Now;
            await courseCollection.InsertOneAsync(course);

            CourseDto courseDto = mapper.Map<CourseDto>(course);

            return Response<CourseDto>.Success(courseDto, 200);
        }

        public async Task<Response<NoContentResponse>> UpdateAsync(CourseUpdateDto updateDto)
        {
           
            Course course = mapper.Map<Course>(updateDto);
            var result = await courseCollection.FindOneAndReplaceAsync(c => c.CourseId == updateDto.CourseId, course);
            if(result is null)
            {
                return Response<NoContentResponse>.Fail("Course not found!", 404);
            }

            return Response<NoContentResponse>.Success(204);
        }

        public async Task<Response<NoContentResponse>>DeleteAsync(string courseId)
        {
           var result = await courseCollection.DeleteOneAsync<Course>(c => c.CourseId == courseId);

            if(result.DeletedCount > 0)
            {
                return Response<NoContentResponse>.Success(204);

            }

            return Response<NoContentResponse>.Fail("Course not found", 404);


        }

    }
}
