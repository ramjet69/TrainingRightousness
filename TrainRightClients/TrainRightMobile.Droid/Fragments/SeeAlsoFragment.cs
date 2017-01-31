using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using TrainRightMobile.Core.Models;
using TrainRightMobile.Droid.Adapters;

namespace TrainRightMobile.Droid.Fragments
{
    public class SeeAlsoFragment : BaseFragment
    {
        protected ListView _listView;
        protected SeeAlso _seeAlso;
        private int _subId;


        public SeeAlsoFragment(int subid)
        {
            _subId = subid;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            FindViews();

            HandleEvents();

            _seeAlso = _trainRightDataService.GetSeeAlso(_subId);
            _listView.Adapter = new SeeAlsoListAdapter(Activity, _seeAlso);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.SeeAlsoFragment, container, false);
        }

        protected void HandleEvents()
        {
            _listView.ItemClick += ListView_ItemClick;
        }

        protected void FindViews()
        {
            _listView = View.FindViewById<ListView>(Resource.Id.seeAlsoListView);
        }

        protected void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //do nothing for now
        }


    }
}