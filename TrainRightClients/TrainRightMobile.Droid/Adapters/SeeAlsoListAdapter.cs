using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using TrainRightMobile.Core.Models;

namespace TrainRightMobile.Droid.Adapters
{
    public class SeeAlsoListAdapter : BaseAdapter<SeeAlso>
    {
        SeeAlso _seeAlso;
        Activity _context;

        //Properties
        public override long GetItemId(int position)
        {
            return position;
        }

        public override SeeAlso this[int position]
        {
            get
            {
                return _seeAlso;
            }
        }

        public override int Count
        {
            get
            {
                return _seeAlso.SelectedCategories.Count;
            }
        }




        public SeeAlsoListAdapter(Activity context, SeeAlso seealso) : base()
        {
            _context = context;
            _seeAlso = seealso;
        }



        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var sinSeeAlso = _seeAlso;
            var posSeeAlso = sinSeeAlso.SelectedCategories[position];



            if (convertView == null)
            {
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.SeeAlsoRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.SeeAlsoTextView).Text = posSeeAlso;
            

            return convertView;
        }



    }
}