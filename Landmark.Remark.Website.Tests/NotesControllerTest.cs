using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Landmark.Remark.Website.Interface;
using Landmark.Remark.Website.Models;
using System.Collections.Generic;
using Moq;
using Landmark.Remark.Website.Controllers;
using System.Web.Http.Results;

namespace Landmark.Remark.Website.Tests
{
    [TestClass]
    public class NotesControllerTest
    {
        [TestMethod]
        public void NotesController_GetALLNotes_ARE_TRUE()
        {
            //Arrange
            var mockRepository = new Mock<INoteManager>();
            List<UserNote> userNoteList = new List<UserNote>();
            userNoteList.Add(new UserNote()
            {
                UserName = "Jitu",
                Note = "Hello Sir",
                Lattitude = -37.5984421f,
                Longitude = 144.941818f

            });

            userNoteList.Add(new UserNote()
            {
                UserName = "Test1 ",
                Note = "Hello Test2 ",
                Lattitude = -37.5984421f,
                Longitude = 144.941818f

            });

            mockRepository.Setup(x => x.GetAllRemarkNotes(null)).ReturnsAsync(userNoteList);
            var controller = new NotesController(mockRepository.Object);

            //Act
            var result = controller.GetAllRemarkNotes(null);
            var contentResult = result.Result as OkNegotiatedContentResult<List<UserNote>>;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.Count, 2);

        }

        [TestMethod]
        public void NotesController_GetALLNotes_IS_NULL()
        {
            //Arrange
            var mockRepository = new Mock<INoteManager>();
            List<UserNote> userNoteList = new List<UserNote>();        

            mockRepository.Setup(x => x.GetAllRemarkNotes(null)).ReturnsAsync(userNoteList);
            var controller = new NotesController(mockRepository.Object);

            //Act
            var result = controller.GetAllRemarkNotes();
            var contentResult = result.Result as NotFoundResult;

            //Assert
            Assert.IsInstanceOfType(contentResult, typeof(NotFoundResult));


        }


        [TestMethod]
        public void NotesController_PostAllNotes_WithOutUserName_BAD_Request()
        {
            //Arrange
            var mockRepository = new Mock<INoteManager>();
            var noteToPost = new UserNote()
            {
                UserName = "",
                Note = "Hello Sir",
                Lattitude = -37.5984421f,
                Longitude = 144.941818f

            };

            var controller = new NotesController(mockRepository.Object);

            //Act
            var result =  controller.PostRemarkOnCurrentLocation(noteToPost);
            var contentResult = result.Result as BadRequestErrorMessageResult;

            //Assert
            Assert.IsInstanceOfType(contentResult, typeof(BadRequestErrorMessageResult));


        }

        [TestMethod]
        public void NotesController_PostAllNotes_Returns_True()
        {
            //Arrange
            var mockRepository = new Mock<INoteManager>();
            var noteToPost = new UserNote()
            {
                UserName = "Ramesh Ji",
                Note = "Hello Sir",
                Lattitude = -37.5984421f,
                Longitude = 144.941818f

            };
            mockRepository.Setup(x => x.PostRemarkOnCurrentLocation(noteToPost)).ReturnsAsync(true);
            var controller = new NotesController(mockRepository.Object);

            //Act
            var result = controller.PostRemarkOnCurrentLocation(noteToPost);
            var contentResult = result.Result as OkNegotiatedContentResult<bool>;

            //Assert
            //Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content, true);


        }
    }
}
