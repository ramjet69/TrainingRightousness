using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using TrainRightMobile.Core.Models;
using TrainRightMobile.Droid.Adapters;

namespace TrainRightMobile.Droid.Fragments
{
    public class InformationFragment : BaseFragment
    {
        protected ListView listView;
        protected List<SinSection> sinSections;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            FindViews();

            HandleEvents();

            sinSections = _trainRightDataService.GetSinSections();
            listView.Adapter = new InformationAdapter(Activity, sinSections);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.InformationFragment, container, false);
        }

        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;
        }

        protected void FindViews()
        {
            listView = View.FindViewById<ListView>(Resource.Id.infoTabsListView);
        }

        protected void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //var sinSubCat = sinCats[e.Position];

            //var intent = new Intent();
            //intent.SetClass(this.Activity, typeof(SinSubCatActivity));
            //intent.PutExtra("selectedSinCatId", sinSubCat.Id);

            //StartActivityForResult(intent, 100);
        }


    }
}