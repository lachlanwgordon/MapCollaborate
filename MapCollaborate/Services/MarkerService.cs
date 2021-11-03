using System;
using System.Collections.ObjectModel;
using MapCollaborate.Models;

namespace MapCollaborate.Services
{
    public class MarkerService
    {
        public ObservableCollection<Location> Markers { get; set; } = new ObservableCollection<Location>();
    }
}