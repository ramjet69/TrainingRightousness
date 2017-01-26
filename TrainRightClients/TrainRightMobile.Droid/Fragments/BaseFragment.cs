using System.Collections.Generic;

using Android.App;
using Android.Widget;
using TrainRightMobile.Core.Service;
using TrainRightMobile.Core.Models;

namespace TrainRightMobile.Droid.Fragments
{
    public class BaseFragment : Fragment
    {
        protected ListView listView;
        protected TrainRightApiService _trainRightDataService;
        protected List<SinCategory> sinCats;

        public BaseFragment()
        {
            _trainRightDataService = new TrainRightApiService();
        }

        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;
        }

        protected void FindViews()
        {
            listView = View.FindViewById<ListView>(Resource.Id.sinCatListView);
        }

        protected void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //var sinSubCat = sinSubCats[e.Position];

            //var intent = new Intent();
            //intent.SetClass(this.Activity, typeof(HotDogDetailActivity));
            //intent.PutExtra("selectedHotDogId", sinSubCat.Id);

            //StartActivityForResult(intent, 100);
        }
    }
}