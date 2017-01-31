using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using TrainRightMobile.Core.Models;
using TrainRightMobile.Droid.Adapters;

namespace TrainRightMobile.Droid.Fragments
{
    public class WhatHappensFragment : BaseFragment
    {
        protected ListView listView;
        protected List<WhatHappens> whatHappens;
        private int _subId;


        public WhatHappensFragment(int subid)
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

            whatHappens = _trainRightDataService.GetWhatHappens(_subId);
            listView.Adapter = new WhatHappensListAdapter(Activity, whatHappens);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.WhatHappensFragment, container, false);
        }

        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;
        }

        protected void FindViews()
        {
            listView = View.FindViewById<ListView>(Resource.Id.whatHappensListView);
        }

        protected void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //do nothing for now

        }


    }
}