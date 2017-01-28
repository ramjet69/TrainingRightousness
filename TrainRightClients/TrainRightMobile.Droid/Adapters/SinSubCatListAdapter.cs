using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using TrainRightMobile.Core.Models;

namespace TrainRightMobile.Droid.Adapters
{
    public class SinSubCatListAdapter : BaseAdapter<SinSubCategory>
    {
        List<SinSubCategory> _sinSubCategories;
        Activity _context;

        //Properties
        public override long GetItemId(int position)
        {
            return position;
        }

        public override SinSubCategory this[int position]
        {
            get
            {
                return _sinSubCategories[position];
            }
        }

        public override int Count
        {
            get
            {
                return _sinSubCategories.Count;
            }
        }




        public SinSubCatListAdapter(Activity context, List<SinSubCategory> sinsubcats) : base()
        {
            _context = context;
            _sinSubCategories = sinsubcats;
        }



        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var sinSubcat = _sinSubCategories[position];

            
            if (convertView == null)
            {
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.SinSubCategoryRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.SinSubCatNameTextView).Text = sinSubcat.SubCategoryName;
            

            return convertView;
        }



    }
}