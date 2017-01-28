using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using TrainRightMobile.Core.Models;

namespace TrainRightMobile.Droid.Adapters
{
    public class SinCatListAdapter : BaseAdapter<SinCategory>
    {
        List<SinCategory> _sinCategories;
        Activity _context;

        //Properties
        public override long GetItemId(int position)
        {
            return position;
        }

        public override SinCategory this[int position]
        {
            get
            {
                return _sinCategories[position];
            }
        }

        public override int Count
        {
            get
            {
                return _sinCategories.Count;
            }
        }




        public SinCatListAdapter(Activity context, List<SinCategory> sincats) : base()
        {
            _context = context;
            _sinCategories = sincats;
        }



        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var sincat = _sinCategories[position];

            
            if (convertView == null)
            {
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.SinCategoryRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.SinCatNameTextView).Text = sincat.SinCategoryName;
            

            return convertView;
        }



    }
}