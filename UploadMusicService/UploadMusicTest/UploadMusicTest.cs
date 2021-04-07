using System;
using Xunit;
namespace UploadMusicTest
{
    public class UploadMusicTest() 
    {
        private readonly DnContextOptions<DBCONTEXT> options;

        public UploadMusicTest()
        {
            options = new DbContextOptionsBuilder<DBCONTEXT>()
                .UseSqlite("Filename=Test.db")
                .Options;
            Seed();
        }

        [Fact]
        public void test1()
        {
            //Arrange
            
            //Act

            //Assert
        }
    }
}