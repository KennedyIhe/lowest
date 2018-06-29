using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PathOfLowestCost.Models;
using PathOfLowestCost.Services;

namespace PathOfLowestCost.ViewModels
{
    public class MainPageViewModel: ViewModelBase
    {
        private readonly ICostService _costService;
        private bool _completePath;
        private int _totalCost;
        private string _path;
        private string _matrixData;

        public string MatrixData
        {
            get => _matrixData;
            set
            {
                OnPropertyChanged("MatrixData");
                _matrixData = value;
            }
        }

        public bool CompletePath
        {
            get => _completePath;
            set
            {
                OnPropertyChanged("CompletePath");
                _completePath = value;
            }
        }

        public int TotalCost
        {
            get => _totalCost;
            set
            {
                OnPropertyChanged("TotalCost");
                _totalCost = value;
            }
        }

        public string CostPath
        {
            get => _path;
            set
            {
                OnPropertyChanged("Path");
                _path = value;
            }
        }

        public MainPageViewModel()
        {
            _costService = new CostService();
        }

        public async Task GetAsync()
        {
            if (string.IsNullOrEmpty(MatrixData)) return;
            var result = await _costService.GetLowest(MatrixData);
            CompletePath = result.CompletePath;
            TotalCost = result.TotalCost;
            CostPath = result.Path;
        }
    }
}
