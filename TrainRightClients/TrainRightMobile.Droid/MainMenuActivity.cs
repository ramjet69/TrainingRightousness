using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;


namespace TrainRightMobile.Droid
{

    [Activity(Label = "Training in Righteousness", MainLauncher = true, Icon = "@drawable/smallicon")]
    public class MainMenuActivity : Activity
    {
        private Button giveInstruction;
        private Button reviewTraining;
        private Button settings;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainMenu);

            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            giveInstruction = FindViewById<Button>(Resource.Id.giveInstructionButton);
            reviewTraining = FindViewById<Button>(Resource.Id.reviewTrainingButton);
            settings = FindViewById<Button>(Resource.Id.settingsButton);
            
        }

        private void HandleEvents()
        {
            giveInstruction.Click += GiveInstructionButton_Click;
            reviewTraining.Click += ReviewTrainingButton_Click;
            settings.Click += SettingsButton_Click;
            
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(SettingsActivity));
            StartActivity(intent);
        }
        
        private void ReviewTrainingButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ReviewTrainingActivity));
            StartActivity(intent);
        }

        private void GiveInstructionButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(GiveInstructionActivity));
            StartActivity(intent);
        }

    }
}