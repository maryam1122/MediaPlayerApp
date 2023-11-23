using System.Reflection;
using MediaPlayer.Core.src.Abstractions;
using MediaPlayer.Core.src.Entities;
using MediaPlayer.Framework.src;
using MediaPlayer.Framework.src.Repositories;
using MediaPlayer.Service.src;
using Microsoft.VisualBasic;
using Moq;
using MediaPlayer.Core.src.Shared;
using MediaPlayer.Service.src.Abstractions;

namespace MediaPlayer.Test.src
{
    public class MediaFileServiceTest
    {
        [Fact]
        public void GetAllFiles_WithValidLimitAndOffset_ShouldInvokeRepoMethod()
        {
            // Arrange
            // var database = new Database();
            // var repo = new MediaFileRepository(database);
            // var repo = new CutomMediaFileRepo(); // do check any value from the fake --> mock

            var repo = new Mock<IMediaFileRepo>(); // create a a mock config, which has object of tye IMediaRepo, no implementation
            var mediaFileService = new MediaFileService(repo.Object);

            // Act
            // var files = mediaFileService.GetAllFiles(5, 1);
            mediaFileService.GetAllFiles(4, 2);

            // Assert
            // Assert.Equal(2, repo.TimeToBeInvoked);
            repo.Verify(repo => repo.GetAllFiles(4, 2), Times.Once);
        }

        [Theory]
        // [InlineData(5,1, result1)]
        [ClassData(typeof(GetAllFilesData))]
        public void GetAllFiles_WithValidLimitAndOffset_ReturnValidData(int limit, int offset, List<MediaFile> result, Type exceptionType)
        {
            // Arrange
            // var database = new Database();
            // var repo = new MediaFileRepository(database);
            // var repo = new CutomMediaFileRepo(); // do not check the state or behaviour of the fake --> stub

            var repo = new Mock<IMediaFileRepo>();
            repo.Setup(repo => repo.GetAllFiles(It.IsAny<int>(), It.IsAny<int>())).Returns(new List<MediaFile>());
            var mediaFileService = new IMediaFileService(repo.Object);

            if (exceptionType is not null)
            {
                // Act + Assert
                Assert.Throws(exceptionType, () => mediaFileService.GetAllFiles(limit, offset));
            }
            else
            {
                // Act
                var files = mediaFileService.GetAllFiles(limit, offset);

                // Assert
                Assert.Equal(result, files);
            }
        }

        public class CutomMediaFileRepo : IMediaFileRepo // Custom fake implementation
        {
            public int TimeToBeInvoked { get; set; }
            private List<MediaFile> _mediaFiles;

            public CutomMediaFileRepo()
            {
                _mediaFiles = new Database().MediaFiles;
            }

            public List<MediaFile> FindByTitle(string title)
            {
                return new List<MediaFile>();
            }

            public List<MediaFile> GetAllFiles(int limit, int offset)
            {
                TimeToBeInvoked++;
                return new List<MediaFile>();
                // _mediaFiles.Sort((a, b) => a.Duration > b.Duration ? 1 : -1);
                // return _mediaFiles.Skip(offset).Take(limit).ToList();
            }
        }

        public class GetAllFilesData : TheoryData<int, int, List<MediaFile>, Type?>
        {
            public GetAllFilesData()
            {
                Add(1, 1, new List<MediaFile>(), null);
                Add(1, 2, new List<MediaFile>(), null);
                Add(-1, 1, new List<MediaFile>(), typeof(InvalidDataException));
            }
        }

        //Dummy
        public class DummyRepo : IMediaFileRepo
        {
            public List<MediaFile> FindByTitle(string title)
            {
                throw new NotImplementedException();
            }

            public List<MediaFile> GetAllFiles(int limit, int offset)
            {
                throw new NotImplementedException();
            }
        }

        // Stub
        public class StubRepo : IMediaFileRepo
        {
            public int TimesInvoked { get; set; }
            public List<MediaFile> FindByTitle(string title)
            {
                throw new NotImplementedException();
            }

            public List<MediaFile> GetAllFiles(int limit, int offset)
            {
                throw new NotImplementedException();
            }
        }

        // Spy
        public class SpyRepo : IMediaFileRepo
        {
            public List<MediaFile> FindByTitle(string title)
            {
                throw new NotImplementedException();
            }

            public List<MediaFile> GetAllFiles(int limit, int offset)
            {
                return new List<MediaFile>();
            }
        }

        // Fake
        public class FakeRepo : IMediaFileRepo
        {
            public int MyProperty { get; set; }
            public List<MediaFile> FindByTitle(string title)
            {
                throw new NotImplementedException();
            }

            public List<MediaFile> GetAllFiles(int limit, int offset)
            {
                MyProperty++;
                return new List<MediaFile>();
            }
        }

        // Mock
        public class MockRepo : IMediaFileRepo
        {
            public int MyProperty { get; set; }

            public MockRepo()
            {

            }
            public List<MediaFile> FindByTitle(string title)
            {
                return new List<MediaFile>();
            }

            public List<MediaFile> GetAllFiles(int limit, int offset)
            {
                return new List<MediaFile>();
            }
        }
    }
}