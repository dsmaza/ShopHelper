using Moq;
using NUnit.Framework;
using ShopHelper.Client.Main;
using ShopHelper.Client.ShoppingList;
using Xamarin.Forms;

namespace ShopHelper.Client.Tests
{
    [TestFixture]
    public class MainComponentTests
    {
        private Mock<IAppComponents> appComponentsMock;
        private Mock<IMainView> viewMock;
        
        [SetUp]
        public void SetUp()
        {
            appComponentsMock = new Mock<IAppComponents>();
            viewMock = new Mock<IMainView>();
        }

        [Test]
        public void WhenShowShoppingList_ThenComponentShow()
        {
            // Arrange
            var shoppingListMock = new Mock<IShoppingListComponent>();

            appComponentsMock
                .Setup(m => m.GetShoppingList())
                .Returns(shoppingListMock.Object);

            var viewModel = new MainViewModel(viewMock.Object);
            var component = new MainComponent(viewModel, appComponentsMock.Object);

            // Act
            viewModel.ShowShoppingListCommand.Execute(null);

            // Assert
            shoppingListMock.Verify(m => m.Show(It.IsAny<INavigation>()), Times.Once);
        }
    }
}
