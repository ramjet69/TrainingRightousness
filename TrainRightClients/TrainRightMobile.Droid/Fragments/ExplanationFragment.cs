using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using TrainRightMobile.Core.Models;
using TrainRightMobile.Droid.Adapters;

namespace TrainRightMobile.Droid.Fragments
{
    public class ExplanationFragment : BaseFragment
    {
        private SinSectionHeader _sinSectionHeader;
        private int _sinSubCatId;
        private TextView _explanationCommentTextView;



        public ExplanationFragment(int id)
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
            
            _sinSectionHeader = _trainRightDataService.GetSinSectionHeader(_sinSubCatId);

            BindData();

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.ExplanationFragment, container, false);
        }

        private void BindData()
        {
            _explanationCommentTextView.Text = _sinSectionHeader.PageComments;
        }

        protected void FindViews()
        {
            _explanationCommentTextView = View.FindViewById<TextView>(Resource.Id.explanationCommentsTextView);
        }

        


    }
}