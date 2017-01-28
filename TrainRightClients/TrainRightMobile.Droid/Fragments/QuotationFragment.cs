using Android.OS;
using Android.Views;
using Android.Widget;
using TrainRightMobile.Core.Models;

namespace TrainRightMobile.Droid.Fragments
{
    public class QuotationFragment : BaseFragment
    {
        private SinSectionHeader _sinSectionHeader;
        private int _sinSubCatId;
        private TextView _explanationQuoteTextView;


        public QuotationFragment(int id)
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
            return inflater.Inflate(Resource.Layout.QuotationFragment, container, false);
        }

        private void BindData()
        {
            _explanationQuoteTextView.Text = _sinSectionHeader.PageQuote;
        }

        protected void FindViews()
        {
            _explanationQuoteTextView = View.FindViewById<TextView>(Resource.Id.explanationQuoteTextView);
        }


    }
}