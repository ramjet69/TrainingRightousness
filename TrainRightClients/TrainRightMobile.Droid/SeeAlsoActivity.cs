using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using TrainRightMobile.Core.Models;
using TrainRightMobile.Core.Service;
using TrainRightMobile.Droid.Fragments;

namespace TrainRightMobile.Droid
{
    [Activity(Label = "See Also Cross Reference")]
    public class SeeAlsoActivity : Activity
    {
        private TextView _sinSubCatTitleTextView;
        private SinSectionHeader _sinSectionHeader;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SeeAlsoView);
            
            var sinCatId = (int)Intent.Extras.GetInt("selectedSinSubCatId");
            TrainRightApiService _trainRightDataService = new TrainRightApiService();
            _sinSectionHeader = _trainRightDataService.GetSinSectionHeader(sinCatId);

            FindViews();

            BindData();

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("Cross References", Resource.Drawable.CrossRef, new SeeAlsoFragment(sinCatId));

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

        private void FindViews()
        {
            _sinSubCatTitleTextView = FindViewById<TextView>(Resource.Id.seeAlsoTitleTextView);
            
        }

        private void BindData()
        {
            _sinSubCatTitleTextView.Text = _sinSectionHeader.PageTitle; 
        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok && requestCode == 100)
            {
            //    var selectedHotDog = hotDogDataService.GetHotDogById(data.GetIntExtra("selectedHotDogId", 0));

            }
        }

    }
}