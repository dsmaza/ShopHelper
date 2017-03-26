using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using ShopHelper.Client.ShoppingList;

namespace ShopHelper.Client.Tests
{
    [TestFixture]
    public class ShoppingListComponentTests
    {
        private Mock<IShoppingListService> serviceMock;
        private Mock<IShoppingListView> viewMock;

        [SetUp]
        public void SetUp()
        {
            serviceMock = new Mock<IShoppingListService>();
            viewMock = new Mock<IShoppingListView>();
        }

        [Test]
        public void WhenAddShoppingListItem_ThenItemAdded()
        {
            // Arrange
            const string newValue = "test";
            var viewModel = new ShoppingListViewModel(viewMock.Object);   
            var component = new ShoppingListComponent(viewModel, serviceMock.Object);
            viewModel.NewShoppingListItemValue = newValue;

            // Act
            viewModel.AddShoppingListItemCommand.Execute(null);

            // Assert
            serviceMock.Verify(m => m.Add(It.Is<ShoppingListItem>(i => i.Title == newValue)), Times.Once);
            Assert.IsTrue(viewModel.ShoppingListItems.Any(i => i.Title == newValue));
            Assert.IsNull(viewModel.NewShoppingListItemValue);
        }

        [Test]
        public void WhenRefreshData_ThenAddItemsFromService()
        {
            // Arrange
            var items = new List<ShoppingListItem>
            {
                new ShoppingListItem { Title = "test1" },
                new ShoppingListItem { Title = "test2" },
                new ShoppingListItem { Title = "test3" }
            };
            serviceMock
                .Setup(m => m.Get())
                .ReturnsAsync(items);

            var viewModel = new ShoppingListViewModel(viewMock.Object);
            var component = new ShoppingListComponent(viewModel, serviceMock.Object);

            // Act
            viewModel.RefreshDataCommand.Execute(null);

            // Assert
            Assert.AreEqual(items.Count, viewModel.ShoppingListItems.Count);
        }

        [Test]
        public void WhenRefreshData_ThenClearAndAddItemsFromService()
        {
            // Arrange
            var items = new List<ShoppingListItem>
            {
                new ShoppingListItem { Title = "test3" }
            };
            serviceMock
                .Setup(m => m.Get())
                .ReturnsAsync(items);

            var viewModel = new ShoppingListViewModel(viewMock.Object);
            var component = new ShoppingListComponent(viewModel, serviceMock.Object);
            viewModel.ShoppingListItems.Add(new ShoppingListItem { Title = "test1" });
            viewModel.ShoppingListItems.Add(new ShoppingListItem { Title = "test2" });

            // Act
            viewModel.RefreshDataCommand.Execute(null);

            // Assert
            Assert.AreEqual(items.Count, viewModel.ShoppingListItems.Count);
            Assert.AreEqual(items[0].Title, viewModel.ShoppingListItems[0].Title);
        }
    }
}
