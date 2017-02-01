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
        private int _sinSubCatId;


        public InformationFragment(int id)
        {
            _sinSubCatId = id;
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
            var intent = new Intent();
            intent.PutExtra("selectedSinSubCatId", _sinSubCatId);

            switch (e.Position)
            {
                case 0:
                    intent.SetClass(Activity, typeof(SeeAlsoActivity));
                    break;

                case 2:
                    intent.SetClass(Activity, typeof(WhatHappensActivity));
                    break;

                default:
                    break;
            }

            StartActivityForResult(intent, 100);

        }


    }
}