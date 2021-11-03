using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapCollaborate.Helpers;
using MapCollaborate.Models;
using MapCollaborate.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MapCollaborate.Pages
{
    public partial class Index
    {
        [Inject]
        public IJSRuntime JS { get; set; }
        [Inject]
        public MarkerService MarkerService { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if(firstRender)
            {
                await JS.InvokeVoidAsync("initializeMap");
                MarkerService.Markers.CollectionChanged += Markers_CollectionChanged;
                var items = new List<Location>(MarkerService.Markers);

                if(items.Any())
                {

                    foreach (var item in items)
                    {
                        var marker = item;
                        await JS.InvokeVoidAsync("AddMarker", marker.Latitude, marker.Longitude);
                    }
                }
            }
        }



        private async void Markers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            await JS.InvokeVoidAsync("ClearMarkers");
            var items = e.NewItems;

            foreach (var item in items)
            {
                var marker = (Location)item;
                await JS.InvokeVoidAsync("AddMarker", marker.Latitude, marker.Longitude);
            }

        }

        public async Task OnClick()
        {
            var random = new Random();
            var lat = random.NextDouble(-37.5, -36.5);
            var lon = random.NextDouble(144.5, 145.4);
            //await JS.InvokeVoidAsync("AddMarker", lat, lon);

            MarkerService.Markers.Add(new Location(lat, lon));
        }

        ~Index()
        {
            MarkerService.Markers.CollectionChanged -= Markers_CollectionChanged;
        }

        //protected override bool ShouldRender()
        //{
        //    return false;
        //}
    }
}