using Android.App;
using Android.Content;
using Android.OS;
using TrainRightMobile.Core.Models;
using TrainRightMobile.Core.Service;
using System.Collections.Generic;
using Android.Widget;
using TrainRightMobile.Droid.Adapters;

namespace TrainRightMobile.Droid
{
    [Activity(Label = "SinSubCatActivity")]
    public class SinSubCatActivity : Activity
    {
        private List<SinSubCategory> _sinSubCategories;
        private TrainRightApiService _dataService;
        protected ListView _listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SinSubCategoryListView);

            _dataService = new TrainRightApiService();
            var sinCatId = Intent.Extras.GetInt("selectedSinCatId");
            _sinSubCategories = _dataService.GetSinSubCategoriesById(sinCatId);

            FindViews();

            HandleEvents();

        }

        private void FindViews()
        {
            _listView = FindViewById<ListView>(Resource.Id.sinSubCatListView);
            _listView.Adapter = new SinSubCatListAdapter(this, _sinSubCategories);
        }


        private void HandleEvents()
        {
            _listView.ItemClick += ListView_ItemClick;
        }

        protected void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var sinSubCatId = _sinSubCategories[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(SinSubCatDetailsActivity));
            intent.PutExtra("selectedSinSubCatId", sinSubCatId.Id);

            StartActivityForResult(intent, 100);
        }

    }
}
