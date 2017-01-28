using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using TrainRightMobile.Core.Models;

namespace TrainRightMobile.Droid.Adapters
{
    public class InformationAdapter : BaseAdapter<SinSection>
    {
        List<SinSection> _sinSections;
        Activity _context;

        //Properties
        public override long GetItemId(int position)
        {
            return position;
        }

        public override SinSection this[int position]
        {
            get
            {
                return _sinSections[position];
            }
        }

        public override int Count
        {
            get
            {
                return _sinSections.Count;
            }
        }




        public InformationAdapter(Activity context, List<SinSection> sinsects) : base()
        {
            _context = context;
            _sinSections = sinsects;
        }



        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var sinSection = _sinSections[position];

            
            if (convertView == null)
            {
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.InformationRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.InformationTextView).Text = sinSection.SectionName;
            

            return convertView;
        }



    }
}