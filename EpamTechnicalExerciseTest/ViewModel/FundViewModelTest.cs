using EpamTechnicalExercise.Model.StockModel;
using EpamTechnicalExercise.Model.FundModel;
using EpamTechnicalExercise.Validations;
using EpamTechnicalExercise.ViewModel;
using EpamTechnicalExerciseTest.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Linq;

namespace EpamTechnicalExerciseTest.ViewModel
{
    [TestClass]
    public class FundViewModelTest
    {
        private FundViewModel _fundViewModel;

        [TestInitialize]
        public void TestInitalize()
        {
            _fundViewModel = new FundViewModel(new FundFactory());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ValidationErrorContainer.ValidationErrors.Clear();
        }

        [TestMethod]
        public void ConstructorShouldGetFundFromFundFactory()
        {
            var fundFactoryMock = MockRepository.GenerateMock<IFundFactory>();
            FundViewModel fundViewModel = new FundViewModel(fundFactoryMock);

            fundFactoryMock.AssertWasCalled(factory => factory.GetFund());
        }

        [TestMethod]
        public void AddStockCommandShouldCallAddStockInFund()
        {
            var fundFactoryMock = MockRepository.GenerateMock<IFundFactory>();
            var fundMock = MockRepository.GenerateMock<IFund>();
            fundFactoryMock.Stub(fundFactory => fundFactory.GetFund()).Return(fundMock);

            FundViewModel fundViewModel = new FundViewModel(fundFactoryMock)
            {
                Price = 2,
                Quantity = 4,
                StockType = StockType.Bond
            };

            fundViewModel.AddStockCommand.Execute(null);

            fundMock.AssertWasCalled(fund => fund.AddStock(Arg<int>.Is.Equal(fundViewModel.Quantity),
                                                           Arg<double>.Is.Equal(fundViewModel.Price),
                                                           Arg<StockType>.Is.Equal(fundViewModel.StockType)));
        }

        [TestMethod]
        public void AddStockCommandCannotBeExecutedIfPriceDoesNotHaveValue()
        {
            _fundViewModel.Price = null;
            _fundViewModel.Quantity = 10;

            var result = _fundViewModel.AddStockCommand.CanExecute(null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddStockCommandCannotBeExecutedIfQuantityDoesNotHaveValue()
        {
            _fundViewModel.Price = 2;
            _fundViewModel.Quantity = null;

            var result = _fundViewModel.AddStockCommand.CanExecute(null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddStockCommandCanBeExecutedIfPriceAndQuantityHasValue()
        {
            _fundViewModel.Price = 2;
            _fundViewModel.Quantity = 4;

            var result = _fundViewModel.AddStockCommand.CanExecute(null);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddStockCommanCannotBeExecutedIfValidationErrorContainerHasErrors()
        {
            _fundViewModel.Price = 2;
            _fundViewModel.Quantity = 4;

            ValidationErrorContainer.AddError(new FakeValidationError());
            var result = _fundViewModel.AddStockCommand.CanExecute(null);
            Assert.IsFalse(result);
        }
    }
}
