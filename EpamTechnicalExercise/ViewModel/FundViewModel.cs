﻿using EpamTechnicalExercise.Commands;
using EpamTechnicalExercise.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using EpamTechnicalExercise.Validations;
using EpamTechnicalExercise.Model.FundModel;
using EpamTechnicalExercise.Model.StockModel;

namespace EpamTechnicalExercise.ViewModel
{
    public class FundViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IFund _fund;

        private ObservableCollection<Stock> _stockCollection;
        public ObservableCollection<Stock> StockCollection
        {
            get
            {
                _stockCollection = new ObservableCollection<Stock>(_fund.StockList);
                return _stockCollection;
            }
        }

        private ObservableCollection<StockTotals> _stockTotalsCollection;
        public ObservableCollection<StockTotals> StockTotalsCollection
        {
            get
            {
                _stockTotalsCollection = new ObservableCollection<StockTotals>(_fund.StockTotalsList);
                return _stockTotalsCollection;
            }
        }

        private ICommand _addStockCommand;
        public ICommand AddStockCommand
        {
            get
            {
                if (_addStockCommand == null)
                    _addStockCommand = new RelayCommand(AddStock, CanAddStock);

                return _addStockCommand;
            }
        }

        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public StockType StockType { get; set; }

        public FundViewModel(IFundFactory fundFactory)
        {
            _fund = fundFactory.GetFund();
        }

        private void AddStock(object parameter)
        {
            _fund.AddStock(Quantity.Value, Price.Value, StockType);
            RaisePropertyChangedEvent("StockCollection");
            RaisePropertyChangedEvent("StockTotalsCollection");
        }

        private bool CanAddStock(object parameter)
        {
            return Quantity.HasValue && Price.HasValue && !ValidationErrorContainer.HasErrors;
        }

        protected void RaisePropertyChangedEvent(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
