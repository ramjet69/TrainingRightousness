using Android.App;
using Android.Content;
using Android.OS;
using TrainRightMobile.Core.Models;
using TrainRightMobile.Core.Service;
using System.Collections.Generic;
using Android.Widget;
using TrainRightMobile.Droid.Adapters;
using TrainRightMobile.Droid.Fragments;

namespace TrainRightMobile.Droid
{
    [Activity(Label ="")]
    public class WhatHappensActivity : Activity
    {
        private List<WhatHappens> _whatHappens;
        private TrainRightApiService _dataService;
        protected ScrollView _scrollView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.WhatHappensView);

            var sinSubCatId = (int)Intent.Extras.GetInt("selectedSinSubCatId");

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("What / Should Happen", Resource.Drawable.Categories, new WhatHappensFragment(sinSubCatId));



        }

        private void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
        }

        
    }
}
