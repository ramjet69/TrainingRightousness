using Android.App;
using TrainRightMobile.Core.Service;

namespace TrainRightMobile.Droid.Fragments
{
    public class BaseFragment : Fragment
    {
        protected TrainRightApiService _trainRightDataService;
        
        public BaseFragment()
        {
            _trainRightDataService = new TrainRightApiService();
        }

        
    }
}