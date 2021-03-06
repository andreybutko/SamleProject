﻿using SampleProject.Model;
using SampleProject.Service;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SampleProject.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IDataService dataService;

        public Info Info { get; set; }
        public ObservableCollection<PriceInfo> Bids { get; set; }
        public ObservableCollection<ResultData> GroupedData { get; set; }
        public decimal VolumeSum { get; set; }
        public decimal TotalSum { get; set; }

        public MainViewModel(IDataService service)
        {
            dataService = service;
        }

        public async Task GetInfo()
        {
            Info = await dataService.GetInfo();
            Bids = new ObservableCollection<PriceInfo>(Info.Bids);

            GroupedData = new ObservableCollection<ResultData>(Info.Bids.GroupBy(b => b.Price).Select(x => new ResultData
            {
                Price = x.Key,
                VolumeSum = Bids.Where(v => v.Price == x.Key).Sum(y => Math.Round(y.Volume, 3)),
                TotalSum = Bids.Where(v => v.Price == x.Key).Sum(y => Math.Round(y.Total, 3))
            }));
            VolumeSum = GroupedData.Sum(x => Math.Round(x.VolumeSum, 3));
            TotalSum = GroupedData.Sum(x => Math.Round(x.TotalSum, 3));
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
