using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using TrainRightMobile.Core.Models;

namespace TrainRightMobile.Droid.Adapters
{
    public class WhatHappensListAdapter : BaseAdapter<WhatHappens>
    {
        List<WhatHappens> _whatHappens;
        Activity _context;

        private ImageView _bibleImageView;

        //Properties
        public override long GetItemId(int position)
        {
            return position;
        }

        public override WhatHappens this[int position]
        {
            get
            {
                return _whatHappens[position];
            }
        }

        public override int Count
        {
            get
            {
                return _whatHappens.Count;
            }
        }




        public WhatHappensListAdapter(Activity context, List<WhatHappens> whathappens) : base()
        {
            _context = context;
            _whatHappens = whathappens;
        }



        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var whatHappen = _whatHappens[position];

            
            if (convertView == null)
            {
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.WhatHappensRowView, null);
            }

            FindViews(convertView);

            _bibleImageView.SetImageResource(Resource.Drawable.Bible);
            convertView.FindViewById<TextView>(Resource.Id.bibleBook).Text = whatHappen.BibleBook;
            

            return convertView;
        }

        private void FindViews(View convertView)
        {
            _bibleImageView = convertView.FindViewById<ImageView>(Resource.Id.bibleImageView);


        }



        }
}