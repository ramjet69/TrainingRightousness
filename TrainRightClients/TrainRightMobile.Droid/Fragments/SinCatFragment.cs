using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using TrainRightMobile.Core.Models;
using TrainRightMobile.Droid.Adapters;

namespace TrainRightMobile.Droid.Fragments
{
    public class SinCatFragment : BaseFragment
    {
        protected ListView listView;
        protected List<SinCategory> sinCats;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            FindViews();

            HandleEvents();

            sinCats = _trainRightDataService.GetSinCategories();
            listView.Adapter = new SinCatListAdapter(Activity, sinCats);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.SinCategoryFragment, container, false);
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
            var sinSubCat = sinCats[e.Position];

            var intent = new Intent();
            intent.SetClass(this.Activity, typeof(SinSubCatActivity));
            intent.PutExtra("selectedSinCatId", sinSubCat.Id);

            StartActivityForResult(intent, 100);
        }


    }
}