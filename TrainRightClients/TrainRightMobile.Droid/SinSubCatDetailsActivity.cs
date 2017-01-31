using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using TrainRightMobile.Core.Models;
using TrainRightMobile.Core.Service;
using TrainRightMobile.Droid.Fragments;

namespace TrainRightMobile.Droid
{
    [Activity(Label = "SinSubCatDetailsActivity")]
    public class SinSubCatDetailsActivity : Activity
    {
        private TextView _sinSubCatTitleTextView;
        private SinSectionHeader _sinSectionHeader;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SinSubCatDetailsView);
            
            var sinSubCatId = (int)Intent.Extras.GetInt("selectedSinSubCatId");
            TrainRightApiService _trainRightDataService = new TrainRightApiService();
            _sinSectionHeader = _trainRightDataService.GetSinSectionHeader(sinSubCatId);

            FindViews();

            BindData();


            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("Quotation", Resource.Drawable.Quote, new QuotationFragment(sinSubCatId));
            AddTab("Explanation", Resource.Drawable.Comment, new ExplanationFragment(sinSubCatId));
            AddTab("Information", Resource.Drawable.instruct, new InformationFragment(sinSubCatId));

        }

        private void FindViews()
        {
            _sinSubCatTitleTextView = FindViewById<TextView>(Resource.Id.sinSubCatTitleTextView);
            
        }

        private void BindData()
        {
            _sinSubCatTitleTextView.Text = _sinSectionHeader.PageTitle; 
        }

        private void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(view);
            };

            ActionBar.AddTab(tab);
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